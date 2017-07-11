// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

//#define DEBUG_SAVE_GENERATED_ASSEMBLY

using Microsoft.Practices.Unity.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security;
using UpgradeHelpers.WebMap.Server;

namespace Microsoft.Practices.Unity.InterceptionExtension
{
    /// <summary>
    /// Class that handles generating the dynamic types used for interception.
    /// </summary>
    public partial class InterceptingClassGenerator
    {


        public static bool OPTIMIZE_NOGETTER_FORNONSURROGATES = true;

        public static bool OPTIMIZE_INTERCEPTION_FOR_LOCALPROPERTIES_WITH_ONLY_GETTER_OR_SETTER = true;

        private static ModuleBuilder GetModuleBuilder()
        {
            string moduleName = Guid.NewGuid().ToString("N");
            //System.Diagnostics.Trace.WriteLine("Module" + moduleName);
#if DEBUG_SAVE_GENERATED_ASSEMBLY
            return AssemblyBuilder.DefineDynamicModule(moduleName, moduleName + ".dll", true);
#else
			return AssemblyBuilder.DefineDynamicModule(moduleName);
#endif
        }

        private static readonly AssemblyBuilder AssemblyBuilder;

        internal readonly Type typeToIntercept;
        private Type targetType;
        internal GenericParameterMapper mainTypeMapper;

        private FieldBuilder proxyInterceptionPipelineField;
        private TypeBuilder typeBuilder;

        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline",
            Justification = "Need to use constructor so we can place attribute on it.")]
        static InterceptingClassGenerator()
        {
            AssemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(
                new AssemblyName("Unity_ILEmit_DynamicClasses"),
#if DEBUG_SAVE_GENERATED_ASSEMBLY
                AssemblyBuilderAccess.RunAndSave,"s:\\temp\\Assemblies");
#else
                AssemblyBuilderAccess.Run);
#endif
        }

        /// <summary>
        /// Create a new <see cref="InterceptingClassGenerator"/> that will generate a
        /// wrapper class for the requested <paramref name="typeToIntercept"/>.
        /// </summary>
        /// <param name="typeToIntercept">Type to generate the wrapper for.</param>
        /// <param name="additionalInterfaces">Additional interfaces the proxy must implement.</param>
        public InterceptingClassGenerator(Type typeToIntercept)
        {
            this.typeToIntercept = typeToIntercept;
            CreateTypeBuilder();
        }

        List<MethodOverride> methodOverrides = new List<MethodOverride>();

        /// <summary>
        /// Create the wrapper class for the given type.
        /// </summary>
        /// <returns>Wrapper type.</returns>
		public Type GenerateType()
		{
			var props = TypePropertiesCache.GetArrayPropertiesOrderedByIndex(typeToIntercept);
			AddProperties(props);
			AddConstructors();



			ConstructorBuilder staticConstructorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard, Type.EmptyTypes);
			ILGenerator staticConstructorILGenerator = staticConstructorBuilder.GetILGenerator();

			foreach (var method in methodOverrides)
			{

				if (method.statficfieldForMethodHandle != null)
				{
					staticConstructorILGenerator.Emit(OpCodes.Ldtoken, method.methodInfoForMethodHandle);
					if (method.methodToOverride.DeclaringType.IsGenericType)
					{
						// if the declaring type is generic, we need to get the method from the target type
						staticConstructorILGenerator.Emit(OpCodes.Ldtoken, method.targetType);
						staticConstructorILGenerator.Emit(OpCodes.Call, MethodBaseMethods.GetMethodForGenericFromHandle);
					}
					else
					{
						staticConstructorILGenerator.Emit(OpCodes.Call, MethodBaseMethods.GetMethodFromHandle); // target method
					}
				}
				staticConstructorILGenerator.Emit(OpCodes.Stsfld, method.statficfieldForMethodHandle);
			}
			staticConstructorILGenerator.Emit(OpCodes.Ret);


			Type result = typeBuilder.CreateType();
			return result;
		}


        private void AddProperties(IList<PropertyInfoEx> props)
        {
            // We don't actually add new properties to this class. We just override
            // the get / set methods as available. Inheritance makes sure the properties
            // show up properly on the derived class.

			FieldBuilder propsField = typeBuilder.DefineField("__Props",typeof(UpgradeHelpers.WebMap.Server.PropertyInfoEx[]), 
                FieldAttributes.Public | FieldAttributes.Static);
            int propertyCount = 0;
			foreach (PropertyInfoEx propertyEx in props)
            {
                if (propertyEx == null) continue;
                if (propertyEx.OnlyHasGetter)
                {
                    //Properties that only have getters do not need interception
                    continue;
                }
				var property = propertyEx.prop;
                if (property.PropertyType.IsValueType || typeof(string) == property.PropertyType)
                {
                    //In this case they can be skipped
                }
                else
                {
					OverridePropertyMethod(property.GetGetMethod(true), propertyEx.propertyPositionIndex, propsField);
                }
				OverridePropertyMethod(property.GetSetMethod(true), propertyEx.propertyPositionIndex, propsField);
				++propertyCount;
            }
        }

        private void OverridePropertyMethod(MethodInfo method, int count, FieldBuilder propsField)
        {
            if (method != null && MethodOverride.MethodCanBeIntercepted(method))
            {
                var methodOverride = new MethodOverride(typeBuilder, proxyInterceptionPipelineField, method, targetType, mainTypeMapper, count);
                methodOverride.AddMethod(count, propsField);
                this.methodOverrides.Add(methodOverride);
            }
        }
        private void AddConstructors()
        {
            BindingFlags bindingFlags =
                this.typeToIntercept.IsAbstract
                    ? BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic
                    : BindingFlags.Public | BindingFlags.Instance;

            foreach (ConstructorInfo ctor in typeToIntercept.GetConstructors(bindingFlags))
            {
                AddConstructor(ctor);
            }
        }

        private void AddConstructor(ConstructorInfo ctor)
        {
            if (!(ctor.IsPublic || ctor.IsFamily || ctor.IsFamilyOrAssembly))
            {
                return;
            }

            MethodAttributes attributes =
                (ctor.Attributes
                & ~MethodAttributes.ReservedMask
                & ~MethodAttributes.MemberAccessMask)
                | MethodAttributes.Public;

            ParameterInfo[] parameters = ctor.GetParameters();

            Type[] paramTypes = parameters.Select(item => item.ParameterType).ToArray();

            ConstructorBuilder ctorBuilder = typeBuilder.DefineConstructor(
                attributes, ctor.CallingConvention, paramTypes);

            for (int i = 0; i < parameters.Length; i++)
            {
                ctorBuilder.DefineParameter(i + 1, parameters[i].Attributes, parameters[i].Name);
            }

            ILGenerator il = ctorBuilder.GetILGenerator();

            // Initialize pipeline field
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Newobj, InterceptionBehaviorPipelineMethods.Constructor);
            il.Emit(OpCodes.Stfld, proxyInterceptionPipelineField);

            // call base class constructor
            il.Emit(OpCodes.Ldarg_0);
            for (int i = 0; i < paramTypes.Length; ++i)
            {
                il.Emit(OpCodes.Ldarg, i + 1);
            }

            il.Emit(OpCodes.Call, ctor);

            il.Emit(OpCodes.Ret);
        }

        private void CreateTypeBuilder()
        {
            TypeAttributes newAttributes = typeToIntercept.Attributes;
            newAttributes = FilterTypeAttributes(newAttributes);

            Type baseClass = GetGenericType(typeToIntercept);
            //System.Diagnostics.Trace.WriteLine("TypeToIntercept " + typeToIntercept.AssemblyQualifiedName);
            ModuleBuilder moduleBuilder = GetModuleBuilder();
            

            var name = "DynamicModule.ns.Wrapped_" + typeToIntercept.Name + "_" + Guid.NewGuid().ToString("N");
            //System.Diagnostics.Trace.TraceInformation("--> " + name);
            typeBuilder = moduleBuilder.DefineType(name,newAttributes,baseClass);

            this.mainTypeMapper = DefineGenericArguments(typeBuilder, baseClass);

            if (this.typeToIntercept.IsGenericType)
            {
                var definition = this.typeToIntercept.GetGenericTypeDefinition();
                var mappedParameters = definition.GetGenericArguments().Select(t => this.mainTypeMapper.Map(t)).ToArray();
                this.targetType = definition.MakeGenericType(mappedParameters);
            }
            else
            {
                this.targetType = this.typeToIntercept;
            }

            proxyInterceptionPipelineField = InterceptingProxyImplementor.ImplementIInterceptingProxy(typeBuilder);
        }

        private static Type GetGenericType(Type typeToIntercept)
        {
            if (typeToIntercept.IsGenericType)
            {
                return typeToIntercept.GetGenericTypeDefinition();
            }
            return typeToIntercept;
        }

        internal static GenericParameterMapper DefineGenericArguments(TypeBuilder typeBuilder, Type baseClass)
        {
            if (!baseClass.IsGenericType)
            {
                return GenericParameterMapper.DefaultMapper;
            }
            Type[] genericArguments = baseClass.GetGenericArguments();

            GenericTypeParameterBuilder[] genericTypes = typeBuilder.DefineGenericParameters(
                genericArguments.Select(t => t.Name).ToArray());

            for (int i = 0; i < genericArguments.Length; ++i)
            {
                genericTypes[i].SetGenericParameterAttributes(genericArguments[i].GenericParameterAttributes);
                var interfaceConstraints = new List<Type>();
                foreach (Type constraint in genericArguments[i].GetGenericParameterConstraints())
                {
                    if (constraint.IsClass)
                    {
                        genericTypes[i].SetBaseTypeConstraint(constraint);
                    }
                    else
                    {
                        interfaceConstraints.Add(constraint);
                    }
                }
                if (interfaceConstraints.Count > 0)
                {
                    genericTypes[i].SetInterfaceConstraints(interfaceConstraints.ToArray());
                }
            }

            return new GenericParameterMapper(genericArguments, genericTypes.Cast<Type>().ToArray());
        }

        private static TypeAttributes FilterTypeAttributes(TypeAttributes attributes)
        {
            if ((attributes & TypeAttributes.NestedPublic) != 0)
            {
                attributes &= ~TypeAttributes.NestedPublic;
                attributes |= TypeAttributes.Public;
            }

            attributes &= ~TypeAttributes.ReservedMask;
            attributes &= ~TypeAttributes.Abstract;

            return attributes;
        }



    }
}
