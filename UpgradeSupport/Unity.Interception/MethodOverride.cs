// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using Microsoft.Practices.Unity.InterceptionExtension.Properties;
using Microsoft.Practices.Unity.Utility;
using UpgradeHelpers.Interfaces;

namespace Microsoft.Practices.Unity.InterceptionExtension
{
    /// <summary>
    /// Represents the implementation of a method override.
    /// </summary>
    public class MethodOverride
    {

        private readonly TypeBuilder typeBuilder;
        internal readonly MethodInfo methodToOverride;
        private readonly ParameterInfo[] methodParameters;
        private readonly FieldBuilder proxyInterceptionPipelineField;
        internal readonly Type targetType;
        private readonly GenericParameterMapper targetTypeParameterMapper;
        private readonly int overrideCount;

        internal MethodOverride(
            TypeBuilder typeBuilder,
            FieldBuilder proxyInterceptionPipelineField,
            MethodInfo methodToOverride,
            Type targetType,
            GenericParameterMapper targetTypeParameterMapper,
            int overrideCount)
        {
            this.typeBuilder = typeBuilder;
            this.proxyInterceptionPipelineField = proxyInterceptionPipelineField;
            this.methodToOverride = methodToOverride;
            this.methodParameters = methodToOverride.GetParameters();
            this.targetType = targetType;

            // if the method is inherited and the declaring type is generic, we need to map
            // the parameters of the original declaration to the actual intercepted type type
            // E.g. consider given class Type1<T> with virtual method "T Method<U>()", the mappings in 
            // different scenarios would look like:
            // Type2<S> : Type2<S>                  => S Method<U>()
            // Type2<S> : Type2<IEnumerable<S>>     => IEnumerable<S> Method<U>()
            // Type2 : Type1<IEnumerable<string>>   => IEnumerable<string> Method<U>()
            var declaringType = methodToOverride.DeclaringType;
            this.targetTypeParameterMapper =
                declaringType.IsGenericType && declaringType != methodToOverride.ReflectedType
                    ? new GenericParameterMapper(declaringType, targetTypeParameterMapper)
                    : targetTypeParameterMapper;
            this.overrideCount = overrideCount;
        }

        internal static bool MethodCanBeIntercepted(MethodInfo method)
        {
            return method != null &&
                (method.IsPublic || method.IsFamily || method.IsFamilyOrAssembly)
                && method.IsVirtual
                && !method.IsFinal
                && method.DeclaringType != typeof(object);
        }


        internal FieldBuilder statficfieldForMethodHandle;

		internal MethodBuilder AddMethod(int propertyIndex, FieldBuilder propsField)
        {
            MethodBuilder delegateMethod = CreateDelegateImplementation(methodToOverride);


            return CreateMethodOverride(delegateMethod, propertyIndex, propsField );
        }

        private string CreateMethodName(string purpose)
        {
            return "<" + methodToOverride.Name + "_" + purpose + ">__" +
                overrideCount.ToString(CultureInfo.InvariantCulture);
        }

        private static readonly OpCode[] LoadArgsOpcodes = 
        {
            OpCodes.Ldarg_1,
            OpCodes.Ldarg_2,
            OpCodes.Ldarg_3
        };

        private static void EmitLoadArgument(ILGenerator il, int argumentNumber)
        {
            if (argumentNumber < LoadArgsOpcodes.Length)
            {
                il.Emit(LoadArgsOpcodes[argumentNumber]);
            }
            else
            {
                il.Emit(OpCodes.Ldarg, argumentNumber + 1);
            }
        }

        private static readonly OpCode[] LoadConstOpCodes = 
        {
            OpCodes.Ldc_I4_0,
            OpCodes.Ldc_I4_1,
            OpCodes.Ldc_I4_2,
            OpCodes.Ldc_I4_3,
            OpCodes.Ldc_I4_4,
            OpCodes.Ldc_I4_5,
            OpCodes.Ldc_I4_6,
            OpCodes.Ldc_I4_7,
            OpCodes.Ldc_I4_8,
        };

        private static void EmitLoadConstant(ILGenerator il, int i)
        {
            if (i < LoadConstOpCodes.Length)
            {
                il.Emit(LoadConstOpCodes[i]);
            }
            else
            {
                il.Emit(OpCodes.Ldc_I4, i);
            }
        }

        private static void EmitBox(ILGenerator il, Type typeOnStack)
        {
            if (typeOnStack.IsValueType || typeOnStack.IsGenericParameter)
            {
                il.Emit(OpCodes.Box, typeOnStack);
            }
        }

        private static void EmitUnboxOrCast(ILGenerator il, Type typeOnStack)
        {
            if (typeOnStack.IsValueType || typeOnStack.IsGenericParameter)
            {
                il.Emit(OpCodes.Unbox_Any, typeOnStack);
            }
            else
            {
                il.Emit(OpCodes.Castclass, typeOnStack);
            }
        }

        private MethodBuilder CreateDelegateImplementation(MethodInfo callBaseMethod)
        {
            string methodName = CreateMethodName("DelegateImplementation");

            MethodBuilder methodBuilder = typeBuilder.DefineMethod(methodName,
                MethodAttributes.Private | MethodAttributes.HideBySig);

            var paramMapper = new MethodOverrideParameterMapper(methodToOverride);
            paramMapper.SetupParameters(methodBuilder, this.targetTypeParameterMapper);

            methodBuilder.SetReturnType(typeof(VirtualMethodInvocation));
            // Adding parameters
            methodBuilder.SetParameters(typeof(VirtualMethodInvocation), typeof(GetNextInterceptionBehaviorDelegate));
            // Parameter 
            methodBuilder.DefineParameter(1, ParameterAttributes.None, "inputs");
            // Parameter 
            methodBuilder.DefineParameter(2, ParameterAttributes.None, "getNext");

            methodBuilder.SetCustomAttribute(new CustomAttributeBuilder(CompilerGeneratedAttributeMethods.CompilerGeneratedAttribute, new object[0]));

            ILGenerator il = methodBuilder.GetILGenerator();

            if (!this.methodToOverride.IsAbstract)
            {
                if (MethodHasReturnValue)
                {
                    il.Emit(OpCodes.Ldarg_1);
                }

                // Call the base method
                il.Emit(OpCodes.Ldarg_0);

                if (methodParameters.Length > 0)
                {
                    il.Emit(OpCodes.Ldarg_1); // inputs
                    il.Emit(OpCodes.Ldfld, VirtualMethodInvocationMethods.GetReturnValue);
                    EmitUnboxOrCast(il, paramMapper.GetParameterType(methodParameters[0].ParameterType));
                }

                MethodInfo baseTarget = callBaseMethod;
                if (baseTarget.IsGenericMethod)
                {
                    baseTarget = callBaseMethod.MakeGenericMethod(paramMapper.GenericMethodParameters);
                }

                il.Emit(OpCodes.Call, baseTarget);
                // Generate  the return value
                if (MethodHasReturnValue)
                {
                    //il.Emit(OpCodes.Ldloc, baseReturn);
                    if (ReturnType.IsValueType || ReturnType.IsGenericParameter)
                    {
                        il.Emit(OpCodes.Box, paramMapper.GetReturnType());
                    }
                    il.Emit(OpCodes.Callvirt, VirtualMethodInvocationMethods.CreateReturn);
                }
                else
                {
                    il.Emit(OpCodes.Ldarg_1);
                }

                il.Emit(OpCodes.Ret);
            }
            else
            {
                throw new NotSupportedException();
            }
            return methodBuilder;
        }

        internal MethodInfo methodInfoForMethodHandle;

        [SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling",
            Justification = "Possibly agree with this, but requires more deliberate refactoring")]
		private MethodBuilder CreateMethodOverride(MethodBuilder delegateMethod, int porpertyIndex, FieldBuilder propsField)
        {
            MethodAttributes attrs =
                methodToOverride.Attributes & ~MethodAttributes.NewSlot & ~MethodAttributes.Abstract;

            MethodBuilder methodBuilder = typeBuilder.DefineMethod(methodToOverride.Name, attrs);

            var paramMapper = new MethodOverrideParameterMapper(methodToOverride);
            paramMapper.SetupParameters(methodBuilder, this.targetTypeParameterMapper);

            methodBuilder.SetReturnType(paramMapper.GetParameterType(methodToOverride.ReturnType));
            methodBuilder.SetParameters(methodParameters.Select(pi => paramMapper.GetParameterType(pi.ParameterType)).ToArray());

            int paramNum = 1;
            foreach (ParameterInfo pi in methodParameters)
            {
                methodBuilder.DefineParameter(paramNum++, pi.Attributes, pi.Name);
            }

            ILGenerator il = methodBuilder.GetILGenerator();

            LocalBuilder methodReturn = il.DeclareLocal(typeof(VirtualMethodInvocation));
            LocalBuilder inputs = methodReturn;
            var endlbl = il.DefineLabel();


            // Create instance of VirtualMethodInvocation
            il.Emit(OpCodes.Ldarg_0); // target object

            // If we have a generic method, we want to make sure we're using the open constructed generic method
            // so when a closed generic version of the method is invoked the actual type parameters are used

            methodInfoForMethodHandle = methodToOverride.IsGenericMethodDefinition
                    ? methodToOverride.MakeGenericMethod(paramMapper.GenericMethodParameters)
                    : methodToOverride;

            if (!methodToOverride.IsGenericMethodDefinition)
            {
                statficfieldForMethodHandle =
                    typeBuilder.DefineField("methodBase" + methodToOverride.Name,typeof(MethodBase),FieldAttributes.Private | FieldAttributes.Static);
            }

            if (MethodHasReturnValue)
            {
				int index = porpertyIndex;
				il.Emit(OpCodes.Ldsfld, propsField);
				il.Emit(OpCodes.Ldc_I4, index);
				il.Emit(OpCodes.Ldelem_Ref);
				il.Emit(OpCodes.Newobj, VirtualMethodInvocationMethods.VirtualMethodInvocationContructorGet);
            }
            else
            {
                //Emit reference to argument
                var methodParameter = methodParameters[0];
                EmitLoadArgument(il, 0);
                if (methodParameter.ParameterType.IsValueType || methodParameter.ParameterType.IsGenericParameter)
                {
                    il.Emit(OpCodes.Box, paramMapper.GetParameterType(methodParameter.ParameterType));
                }
                else if (methodParameter.ParameterType.IsByRef)
                {
                    Type elementType = paramMapper.GetElementType(methodParameter.ParameterType);
                    il.Emit(OpCodes.Ldobj, elementType);
                    if (elementType.IsValueType || elementType.IsGenericParameter)
                    {
                        il.Emit(OpCodes.Box, elementType);
                    }
                }
				
				int methodType = 1;
				il.Emit(OpCodes.Ldc_I4, methodType);
				int index = porpertyIndex;
				il.Emit(OpCodes.Ldsfld, propsField);
				il.Emit(OpCodes.Ldc_I4, index);
				il.Emit(OpCodes.Ldelem_Ref);
                il.Emit(OpCodes.Newobj, VirtualMethodInvocationMethods.VirtualMethodInvocationContructorSet);
            }
            il.Emit(OpCodes.Stloc, inputs);


            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldfld, proxyInterceptionPipelineField);
            il.Emit(OpCodes.Ldloc, inputs);

            // Put delegate reference onto the stack
            il.Emit(OpCodes.Ldarg_0);

            MethodInfo invokeTarget = delegateMethod;
            if (delegateMethod.IsGenericMethod)
            {
                invokeTarget = delegateMethod.MakeGenericMethod(paramMapper.GenericMethodParameters);
            }

            il.Emit(OpCodes.Ldftn, invokeTarget);
            il.Emit(OpCodes.Newobj, InvokeInterceptionBehaviorDelegateMethods.InvokeInterceptionBehaviorDelegate);

            // And call the pipeline
            il.Emit(OpCodes.Call, InterceptionBehaviorPipelineMethods.Invoke);

            // handle return value
            if (MethodHasReturnValue)
            {
                //il.Emit(OpCodes.Ldloc, methodReturn);
                il.Emit(OpCodes.Ldfld, VirtualMethodInvocationMethods.GetReturnValue);
                if (ReturnType.IsValueType || ReturnType.IsGenericParameter)
                {
                    il.Emit(OpCodes.Unbox_Any, paramMapper.GetReturnType());
                }
                else
                {
                    il.Emit(OpCodes.Castclass, paramMapper.GetReturnType());
                }
            }
            il.MarkLabel(endlbl);
            if (!MethodHasReturnValue)
                il.Emit(OpCodes.Pop);
            il.Emit(OpCodes.Ret);

            return methodBuilder;
        }

        private bool MethodHasReturnValue
        {
            get { return methodToOverride.ReturnType != typeof(void); }
        }

        private Type ReturnType
        {
            get { return methodToOverride.ReturnType; }
        }

    }
}
