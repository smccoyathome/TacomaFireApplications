// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using UpgradeHelpers.Interfaces;

namespace Microsoft.Practices.Unity.InterceptionExtension
{
    /// <summary>
    /// This class provides the code needed to implement the <see cref="IInterceptingProxy"/>
    /// interface on a class.
    /// </summary>
    internal static class InterceptingProxyImplementor
    {
        internal static FieldBuilder ImplementIInterceptingProxy(TypeBuilder typeBuilder)
        {
            typeBuilder.AddInterfaceImplementation(typeof(IInterceptingProxy));
            FieldBuilder proxyInterceptorPipelineField =
                typeBuilder.DefineField(
                    "pipeline",
                    typeof(InterceptionBehaviorPipeline),
                    FieldAttributes.Private | FieldAttributes.InitOnly);

            ImplementAddInterceptionBehavior(typeBuilder, proxyInterceptorPipelineField);
			typeBuilder.AddInterfaceImplementation(typeof(IDependentsContainer));
			ImplementIDependentsContainer(typeBuilder);

            return proxyInterceptorPipelineField;
        }

		private static void ImplementIDependentsContainer(TypeBuilder typeBuilder)
		{
			var theType = typeof(List<string>);
			// Define field
			FieldBuilder fieldBuilder = typeBuilder.DefineField("__Dependents", theType, FieldAttributes.Private);
			PropertyBuilder propertyBuilder = typeBuilder.DefineProperty("Dependents", PropertyAttributes.None, theType, null);

			// Define "getter" for Dependents property
			MethodAttributes getSetAttr = MethodAttributes.Public |
			MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.Virtual;


			MethodBuilder getter = typeBuilder.DefineMethod("get_Dependents", getSetAttr, theType, Type.EmptyTypes);

			ILGenerator getIL = getter.GetILGenerator();
			getIL.Emit(OpCodes.Ldarg_0);
			getIL.Emit(OpCodes.Ldfld, fieldBuilder);
			getIL.Emit(OpCodes.Ret);

			MethodBuilder setter = typeBuilder.DefineMethod("set_Dependents", getSetAttr, null, new Type[] { theType });

			ILGenerator setIL = setter.GetILGenerator();
			setIL.Emit(OpCodes.Ldarg_0);
			setIL.Emit(OpCodes.Ldarg_1);
			setIL.Emit(OpCodes.Stfld, fieldBuilder);
			setIL.Emit(OpCodes.Ret);


			propertyBuilder.SetGetMethod(getter);
			propertyBuilder.SetSetMethod(setter);
		}

        private static void ImplementAddInterceptionBehavior(TypeBuilder typeBuilder, FieldInfo proxyInterceptorPipelineField)
        {
            // Declaring method builder
            // Method attributes
            const MethodAttributes MethodAttributes = MethodAttributes.Private | MethodAttributes.Virtual
                | MethodAttributes.Final | MethodAttributes.HideBySig
                    | MethodAttributes.NewSlot;

            MethodBuilder methodBuilder =
                typeBuilder.DefineMethod(
                    "Microsoft.Practices.Unity.InterceptionExtension.IInterceptingProxy.AddInterceptionBehavior",
                    MethodAttributes);

            // Setting return type
            methodBuilder.SetReturnType(typeof(void));
            // Adding parameters
            methodBuilder.SetParameters(typeof(IInterceptionBehavior));
            // Parameter method
            methodBuilder.DefineParameter(1, ParameterAttributes.None, "interceptor");

            ILGenerator il = methodBuilder.GetILGenerator();
            // Writing body
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldfld, proxyInterceptorPipelineField);
            il.Emit(OpCodes.Ldarg_1);
            il.EmitCall(OpCodes.Callvirt, InterceptionBehaviorPipelineMethods.Add, null);
            il.Emit(OpCodes.Ret);
            typeBuilder.DefineMethodOverride(methodBuilder, IInterceptingProxyMethods.AddInterceptionBehavior);

			

        }
    }
}
