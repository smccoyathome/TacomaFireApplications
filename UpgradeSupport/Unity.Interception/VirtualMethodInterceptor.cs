// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using Microsoft.Practices.Unity.InterceptionExtension.Properties;
using Microsoft.Practices.Unity.Utility;
using System.Linq;
using UpgradeHelpers.WebMap.Server;
using System.Linq.Expressions;

namespace Microsoft.Practices.Unity.InterceptionExtension
{
    /// <summary>
    /// A type based interceptor that works by generated a new class
    /// on the fly that derives from the target class.
    /// </summary>
    public class VirtualMethodInterceptor 
    {
        private static readonly Dictionary<GeneratedTypeKey, Tuple<Type, Func<object>>> DerivedClasses =
            new Dictionary<GeneratedTypeKey, Tuple<Type, Func<object>>>(new GeneratedTypeKey.GeneratedTypeKeyComparer());

        /// <summary>
        /// Can this interceptor generate a proxy for the given type?
        /// </summary>
        /// <param name="t">Type to check.</param>
        /// <returns>True if interception is possible, false if not.</returns>
        [SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods",
            Justification = "Validation done via Guard class")]
        public bool CanIntercept(Type t)
        {
            return t.IsClass &&
                (t.IsPublic || t.IsNestedPublic) &&
                t.IsVisible &&
                !t.IsSealed;
        }

        /// <summary>
        /// Returns a sequence of methods on the given type that can be
        /// intercepted.
        /// </summary>
        /// <param name="interceptedType">The intercepted type.</param>
        /// <param name="implementationType">The concrete type of the implementing object.</param>
        /// <returns>Sequence of <see cref="MethodInfo"/> objects.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Interceptable",
            Justification = "Spelling is fine")]
        [SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods",
            Justification = "Validation done via Guard class")]
        public IEnumerable<MethodImplementationInfo> GetInterceptableMethods(Type interceptedType, Type implementationType)
        {
            return DoGetInterceptableMethods(implementationType);
        }

        private IEnumerable<MethodImplementationInfo> DoGetInterceptableMethods(Type implementationType)
        {
            var interceptableMethodsToInterfaceMap = new Dictionary<MethodInfo, MethodInfo>();

            foreach (MethodInfo method in
                implementationType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (MethodOverride.MethodCanBeIntercepted(method))
                {
                    interceptableMethodsToInterfaceMap[method] = null;
                }
            }

            foreach (Type itf in implementationType.GetInterfaces())
            {
                var mapping = implementationType.GetInterfaceMap(itf);
                for (int i = 0; i < mapping.InterfaceMethods.Length; ++i)
                {
                    if (interceptableMethodsToInterfaceMap.ContainsKey(mapping.TargetMethods[i]))
                    {
                        interceptableMethodsToInterfaceMap[mapping.TargetMethods[i]] = mapping.InterfaceMethods[i];
                    }
                }
            }

            foreach (var kvp in interceptableMethodsToInterfaceMap)
            {
                yield return new MethodImplementationInfo(kvp.Value, kvp.Key);
            }
        }



        /// <summary>
        /// Create a type to proxy for the given type <paramref name="t"/>.
        /// </summary>
        /// <param name="t">Type to proxy.</param>
        /// <param name="additionalInterfaces">Additional interfaces the proxy must implement.</param>
        /// <returns>New type that can be instantiated instead of the
        /// original type t, and supports interception.</returns>
        [SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods",
            Justification = "Validation done via Guard class")]
		public Tuple<Type, Func<object>> CreateProxyType(Type t, bool compileProxyContructor = true)
        {
			Type interceptorType;
			Type typeToDerive = t;
            bool genericType = false;
			GeneratedTypeKey key = new GeneratedTypeKey(typeToDerive);
			Tuple<Type, Func<object>> tuple;
			if (DerivedClasses.TryGetValue(key, out tuple))
			{
				return tuple;
			}
			if (t.IsGenericType)
			{
				typeToDerive = t.GetGenericTypeDefinition();
				genericType = true;
			}
            if (!CanIntercept(t))
            {
                throw new InvalidOperationException(
                    string.Format(CultureInfo.CurrentCulture, Resources.InterceptionNotSupported, t.Name));
            }
			lock (DerivedClasses)
            {
                    InterceptingClassGenerator generator =new InterceptingClassGenerator(typeToDerive);
                    interceptorType = generator.GenerateType();
					if (genericType)
						interceptorType = interceptorType.MakeGenericType(t.GetGenericArguments());
					Func<object> contructor = null;
					if(compileProxyContructor)
						contructor = Expression.Lambda<Func<object>>(Expression.New(interceptorType)).Compile();
					tuple = new Tuple<Type, Func<object>>(interceptorType, contructor);
					DerivedClasses[key] = tuple;

					
            }
            if (genericType)
            {
				IList<PropertyInfoEx> tableInfo;
                TypePropertiesCache.VerifyInformationIsLoaded(interceptorType, out tableInfo);
            }
            else
            {
                TypePropertiesCache.AssociateTypeWithProxyType(t, interceptorType);
            }
			PropertiesExDictionary dic;
			TypePropertiesCache.cachePropertiesEx.TryGetValue(interceptorType, out dic);
			interceptorType.GetField("__Props").SetValue(null, (PropertyInfoEx[])dic.PropertiesList);
			//PropertyInfoEx[] currentProps;
			//TypePropertiesCache.cachePropertiesEx.TryGetValue(t, out currentProps);
			//TypePropertiesCache.cachePropertiesEx.Remove(t);
			//TypePropertiesCache.cachePropertiesEx.Add(interceptorType, currentProps);
            return tuple;
        }
    }
}
