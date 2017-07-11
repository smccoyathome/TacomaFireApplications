using System;
using System.Collections.Generic;
using UpgradeHelpers.WebMap.Server.Common.Config;
using System.Reflection;
using System.Linq;
using System.Runtime.InteropServices;
using Fasterflect;
using UpgradeHelpers.Events;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Helpers;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace UpgradeHelpers.WebMap.Server
{

    //Provides a Cache to shorten type names for serialization
    public static class TypeCacheUtils
    {
        

        internal static Dictionary<int,Type> _actionTypes = new Dictionary<int,Type>
        {
            {1, typeof(Action<>) },
            {2, typeof(Action<,>) },
            {3, typeof(Action<,,>) },
            {4, typeof(Action<,,,>) },
            {5, typeof(Action<,,,,>) },
            {6, typeof(Action<,,,,,>)},
            {7, typeof(Action<,,,,,,>)},
            {8, typeof(Action<,,,,,,,>)},
            {9, typeof(Action<,,,,,,,,>)},
            {10, typeof(Action<,,,,,,,,,>)},
            {11, typeof(Action<,,,,,,,,,,>)},
            {12, typeof(Action<,,,,,,,,,,,>)},
            {13, typeof(Action<,,,,,,,,,,,,>)},
            {14, typeof(Action<,,,,,,,,,,,,,>)},
            {15, typeof(Action<,,,,,,,,,,,,,,>)},
            {16, typeof(Action<,,,,,,,,,,,,,,,>)}
        };


        internal static Dictionary<int, Type> _funcTypesDict = new Dictionary<int, Type>
        {
            {1, typeof(Func<,>) },
            {2, typeof(Func<,,>) },
            {3, typeof(Func<,,,>) },
            {4, typeof(Func<,,,,>) },
            {5, typeof(Func<,,,,,>) },
            {6, typeof(Func<,,,,,,>)},
            {7, typeof(Func<,,,,,,,>)},
            {8, typeof(Func<,,,,,,,,>)},
            {9, typeof(Func<,,,,,,,,,>)},
            {10, typeof(Func<,,,,,,,,,,>)},
            {11, typeof(Func<,,,,,,,,,,,>)},
            {12, typeof(Func<,,,,,,,,,,,,>)},
            {13, typeof(Func<,,,,,,,,,,,,,>)},
            {14, typeof(Func<,,,,,,,,,,,,,,>)},
            {15, typeof(Func<,,,,,,,,,,,,,,,>)},
            {16, typeof(Func<,,,,,,,,,,,,,,,,>)}
        };



        public static Type GetDelegateTypeBasedOnMethodParameters(MethodInfo methodInfo)
        {
            var parameters = methodInfo.GetParameters();
            if (methodInfo.ReturnType == typeof(void))
            {
                if (parameters.Length == 0) return typeof(Action);
                Type[] types = new Type[parameters.Length];
                for (int i = 0; i < parameters.Length; i++)
                {
                    types[i] = parameters[i].ParameterType;
                }
                return _actionTypes[parameters.Length].MakeGenericType(types);
            }
            else
            {
                if (parameters.Length == 0) return typeof(Func<>).MakeGenericType(methodInfo.ReturnType);
                Type[] types = new Type[parameters.Length+1];
                for (int i = 0; i < parameters.Length; i++)
                {
                    types[i] = parameters[i].ParameterType;
                }
                types[types.Length - 1] = methodInfo.ReturnType;
                return _funcTypesDict[parameters.Length].MakeGenericType(types);
            }
        }

        internal static HashSet<Type> _funcTypes = new HashSet<Type>
        {
            typeof(Func<>),
            typeof(Func<,>),
            typeof(Func<,,>),
            typeof(Func<,,,>),
            typeof(Func<,,,,>),
            typeof(Func<,,,,,>),
            typeof(Func<,,,,,,>),
            typeof(Func<,,,,,,,>),
            typeof(Func<,,,,,,,,>),
            typeof(Func<,,,,,,,,,>),
            typeof(Func<,,,,,,,,,,>),
            typeof(Func<,,,,,,,,,,,>),
            typeof(Func<,,,,,,,,,,,,>),
            typeof(Func<,,,,,,,,,,,,,>),
            typeof(Func<,,,,,,,,,,,,,,>),
            typeof(Func<,,,,,,,,,,,,,,,>),
            typeof(Func<,,,,,,,,,,,,,,,,>),
        };

		/// <summary>
		/// Simple types and the matching Type Id.
		/// </summary>
		internal enum SympleTypes
		{
 			String = 20
		}
        /// <summary>
        /// Used to determine if type is a Func<>
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsFuncType(Type t)
        {
            return t.IsGenericType && _funcTypes.Contains(t.GetGenericTypeDefinition());
        }

		/// <summary>
		/// Gets all PropertyInfoEx registered for a given type
		/// </summary>
		/// <param name="t"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IList<PropertyInfoEx> GetPropertyInfoExFor(Type typeName)
		{
			IList<PropertyInfoEx> tableInfo;
			TypePropertiesCache.VerifyInformationIsLoaded(typeName, out tableInfo);
			return tableInfo;
		}

        /// <summary>
        /// This type will hold the information that indicates how a fully qualified
        /// type name is associated to an integer.
        /// A direct dictionary was not used, because the implementation might change,
        /// so using an overloaded class provides some abstraction.
        /// </summary>
        /// <summary>
        /// Holds the global information about how current types are configured
        /// </summary>
        public static ClientSideMappingInfoDictionary ClientSideMappingInfo = new ClientSideMappingInfoDictionary();


        /// <summary>
        /// Makes sure that client metadata is already loaded
        /// </summary>
        public static void LoadClientTypeMetadataTable()
        {
            bool hasValues = TypeCacheUtils.DefaultAndAliasMappings.Count > 0;
            if (!hasValues)
            {
                Debug.WriteLine("Loading Client Type Metadata tables");
                foreach (var item in TypeCacheUtils.ClientSideMappingInfo)
                {
                    try
                    {
                        TypeCacheUtils.FillDefaultAndAliasInfoForType(item.Key, item.Value);
                    }
                    catch (Exception) { /*Ignore exception */ }
                }
                Debug.WriteLine("Finished Loading Client Type Metadata tables");
            }
        }


		public static Dictionary<string, Dictionary<string, object[]>> DefaultAndAliasMappings = new Dictionary<string, Dictionary<string, object[]>>();
        private static int clientTypeInfoCounter = 100;

        /// <summary>
        /// Retrieves type information for an state object
        /// </summary>
        /// <param name="m"></param>
        /// <returns>0 if not found or a number greater that 0 from the type map table</returns>
        public static int GetModelTypedInt(IStateObject m)
        {
            if (ClientSideMappingInfo == null || m == null)
                return 0;
            var type = m.GetType();
            return GetModelTypedInt(type);
        }

        public static int GetModelTypedInt(Type type)
        {
            if (TypeCacheUtils.IsGeneratedType(type))
                type = type.BaseType;
            int mappedType = 0;
            ClientSideMappingInfo.TryGetValue(type, out mappedType);
            return mappedType;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsIListOrIDictionary(Type tvalue)
        {
            return
            tvalue.IsGenericType &&
            (
            (typeof(IList<>) == tvalue.GetGenericTypeDefinition() &&
            (typeof(IStateObject).IsAssignableFrom(tvalue.GetGenericArguments()[0]) || IsIListOrIDictionary(tvalue.GetGenericArguments()[0]))) ||
            typeof(IDictionary<,>) == tvalue.GetGenericTypeDefinition()
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsAnIListOfSomethingThatImplementsIStateObject(Type returnType)
		{
			return returnType.IsGenericType &&
				typeof(System.Collections.Generic.IList<>).IsAssignableFrom(returnType.GetGenericTypeDefinition()) &&
				typeof(IStateObject).IsAssignableFrom(returnType.GetGenericArguments()[0]);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsAnIList(Type returnType)
		{
			return returnType.IsGenericType && 
				typeof(System.Collections.Generic.IList<>).IsAssignableFrom(returnType.GetGenericTypeDefinition());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsAnIDictionary(Type returnType)
		{
			return returnType.IsGenericType &&
			typeof(System.Collections.Generic.IDictionary<,>).IsAssignableFrom(returnType.GetGenericTypeDefinition());

		}

        public static void NeedsAutoWire(IEnumerable<Type> typesToRegister)
        {
            foreach (var typeToRegister in typesToRegister)
            {
                if (!typeToRegister.IsAbstract && typeToRegister.IsClass)
                {
                    try
                    {
                        if (typeof(IDependentViewModel).IsAssignableFrom(typeToRegister) || typeof(IViewModel).IsAssignableFrom(typeToRegister))
                            NeedsAutoWire(typeToRegister);
                    }
                    catch { }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AddClientTypeRegistration(Type typeToRegister)
        {
            if (typeof(IUserControl).IsAssignableFrom(typeToRegister))
            {
                //Get next multiple of 10
                while ((clientTypeInfoCounter % 10)!=0)
                {
                    clientTypeInfoCounter++;
                }
            }
            else
            {
                if ((clientTypeInfoCounter % 10) == 0) 
                    clientTypeInfoCounter++;
            }
            if (!ClientSideMappingInfo.ContainsKey(typeToRegister))
            {
                ClientSideMappingInfo.Add(typeToRegister, clientTypeInfoCounter);
            }
            else
            {
                System.Diagnostics.Trace.TraceError("Configuration Error. Conflicting Type [{0}]", typeToRegister.AssemblyQualifiedName);
            }
            clientTypeInfoCounter++;
        }

		public static object GetDefault(Type type)
		{
			if(type.IsValueType && !type.IsGenericType /*For generic classes IsValueType returns true but the second check allows us to detect that*/)
			{
			 return Activator.CreateInstance(type);
			}
			 return null;
		}
		public static void FillDefaultAndAliasInfoForType(Type type, int typeID)
		{
			var props = GetPropertyInfoExFor(type);
			var internalDic = new Dictionary<string, object[]>();
			foreach(var prop in props)
			{
				if (prop!=null && prop.alias != null)
				{
					var value = GetDefault(prop.prop.PropertyType);
					int typeOfProp = -1;
					ClientSideMappingInfo.TryGetValue(prop.prop.PropertyType, out typeOfProp);
					if (prop.prop.PropertyType == typeof(string))
						typeOfProp = Convert.ToInt32(SympleTypes.String);
                    if (prop.stateManagementAttribute == StateManagementValues.ServerOnly)
                        internalDic.Add(prop.alias, new object[] { prop.prop.Name, null, typeOfProp });
                    else
                        internalDic.Add(prop.alias, new object[] { prop.prop.Name, value, typeOfProp });
				}
			}
			DefaultAndAliasMappings.Add(typeID+"", internalDic);

		}


        static object syncPropsForAppState = new object();
        static Dictionary<Type, List<PropertyInfo>> propsfoprAppState = new Dictionary<Type, List<PropertyInfo>>();

        public const bool SHORTENTYPENAME = true;

        const bool useKnownTypesFromWebConfig = false;

        const bool loadTypesOnRegisterTypes = true;

        /// <summary>
        /// This setting must not be set when a distributed memory storage is used
        /// </summary>
        public const bool ISSAFETOSHORTENALLTYPES = true;

        public static bool IsAnStructType(Type type)
        {
            return !type.IsEnum && !type.IsPrimitive && type.IsValueType;
        }


        public static bool IsAnUserStructType(Type type)
        {
            return !type.IsEnum && !type.IsPrimitive && type.IsValueType && type.Assembly != mscorlib;
        }


        public static System.Reflection.Assembly mscorlib = typeof(DateTime).Assembly;

        /// <summary>
        /// This method is detect if what we have is one of the wrapper types generated by the Unity Interception
        /// </summary>
        /// <param name="valueType"></param>
        /// <returns>true if this a Proxy generated for Interception</returns>

        public static bool IsGeneratedType(Type type)
        {
            return type.Assembly.IsDynamic;
        }

        private static readonly object SyncNeedsAutoWite = new object();
        private static Dictionary<Type, IList<MethodInfoEx>> needsAutoWire = new Dictionary<Type, IList<MethodInfoEx>>();

		private static readonly IDictionary<Type, IList<Type>> InitializableCommonExecutionHierachy = new Dictionary<Type, IList<Type>>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool MethodNameFollowConventionPattern(string methodName)
		{
			return methodName.LastIndexOf('_') != -1;
		}
		static System.Text.RegularExpressions.Regex eventHandlerPattern = new System.Text.RegularExpressions.Regex("^(.+)_([^_]+)$");
		private static string[] SplitMethodAndEventParts(bool isDefault, string methodName)
		{
			if (!isDefault) return null;
			if (MethodNameFollowConventionPattern(methodName))
			{
				var match = eventHandlerPattern.Match(methodName);
				if (match.Success)
				{
					return new string[] { match.Groups[1].Value, match.Groups[2].Value };
				}
				else
				{
					return null;
				}
			}
			return null;
		}

        static IList<MethodInfoEx> EMPTY_AUTOWIRE = new MethodInfoEx[] { };

        /// <summary>
        /// Checks if this class will need autowiring.
        /// This table is used to avoid excess processing of classes
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IList<MethodInfoEx> NeedsAutoWire(Type type)
        {
            lock (SyncNeedsAutoWite)
            {
                if (needsAutoWire.ContainsKey(type))
                {
                    return needsAutoWire[type];
                }
                else
                {
                    if (typeof(INotAutoWire).IsAssignableFrom(type))
                    {
                        needsAutoWire.Add(type, EMPTY_AUTOWIRE);
                        return EMPTY_AUTOWIRE;
                    }
                    else
                    {
						List<MethodInfoEx> handlers = null ;
						foreach (var method in type.Methods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | Flags.ExcludeBackingMembers))
						{
							var attribute = (Handler)Attribute.GetCustomAttribute(method, typeof(Handler));
							if (attribute != null)
							{
								handlers = handlers ?? new List<MethodInfoEx>();
								handlers.Add(new MethodInfoEx() { method = method, HandlerAttribute = attribute, MethodAndEventParts = SplitMethodAndEventParts(attribute.IsDefault, method.Name) });
							}
						}
						if (handlers != null)
                        {
							needsAutoWire.Add(type, handlers);
							return handlers;
                        }
                        else
                        {
                            needsAutoWire.Add(type, EMPTY_AUTOWIRE);
                            return EMPTY_AUTOWIRE;
                        }
                    }
                }
            }
        }

        //This table is used to compress types names during state serialization

        private static readonly object SyncTypeTables = new object();
        internal static Dictionary<string, Type> typeContractorForward = new Dictionary<string, Type>(StringComparer.Ordinal);
        internal static Dictionary<Type, string> typeContractorReverse = new Dictionary<Type, string>();

        internal static Dictionary<string, string> assemblyContractorForward = new Dictionary<string, string>(StringComparer.Ordinal);
        internal static Dictionary<string, string> assemblyContractorReverse = new Dictionary<string, string>(StringComparer.Ordinal);

        internal static void AddBasicTypes()
        {
            if (useKnownTypesFromWebConfig)
            {
                var config = InternalWebMAPConfiguration.KnownTypesConfiguration;
                if (config != null)
                {
                    foreach (KnownType knownType in config.KnownTypes)
                    {
                        string resolvedTypeName = string.Format("{0},{1}", knownType.FullClassName, knownType.AssemblyName);
                        var type = Type.GetType(resolvedTypeName, false);
                        if (type != null)
                            AddToTypeContractorCache(type);
                    }
                }
            }
        }

        public static void AddAssemblyToTypeContractorCache(Assembly assembly)
        {
            var longName = assembly.FullName;
            if (SHORTENTYPENAME)
            {
                lock (SyncTypeTables)
                {
                    var key = "A" + Base62.Encode(assemblyContractorForward.Count);
                    assemblyContractorForward.Add(key, longName);
                    assemblyContractorReverse.Add(longName, key);
                }
            }
        }
        public static int PADDEDCONTRACTEDTYPENAME = 2;

        public static void AddToTypeContractorCache(Type t)
        {
            if (SHORTENTYPENAME)
            {
                lock (SyncTypeTables)
                {
                    if (TypeCacheUtils.IsGeneratedType(t))
                    {
                        //We will map the intercept types to their base types
                        //This typecontractor cache is used for serialization
                        //We do not need to know the intercepted type
                        var interceptedType = t;
                        TypeCacheUtils.GetOriginalType(ref t);
                        string currentKey;
                        if (!typeContractorReverse.TryGetValue(t, out currentKey))
                        {
                            AddToTypeContractorCache(t);
                            currentKey = typeContractorReverse[t];
                        }
                        typeContractorReverse.Add(interceptedType, currentKey);
                    }
                    else
                    {
                        string key = typeContractorForward.Count.ToBase95ToString(PADDEDCONTRACTEDTYPENAME);
                        if (key.Length == 1) key += '~';  //by now the size is 2 then only add one char '~'

                        typeContractorForward.Add(key, t);
                        typeContractorReverse.Add(t, key);         
                    }
                }
            }
        }


        #region methods created to test shortening assembly names
        //public static void ShortenRegisteredType(Type t)
        //{
        //    if (loadTypesOnRegisterTypes)
        //    {
        //        AddToTypeContractorCache(t);
        //    }
        //}

        //public static string ToShortAssembly(string assemblyLongName)
        //{
        //    lock (SyncTypeTables)
        //    {
        //        string res;
        //        if (assemblyContractorForward.TryGetValue(assemblyLongName, out res))
        //        {
        //            return res;
        //        }
        //        return assemblyLongName;
        //    }
        //}


        //public static string FromShortAssembly(string shortAssembly)
        //{
        //    string res;
        //    if (assemblyContractorReverse.TryGetValue(shortAssembly, out res))
        //    {
        //        return res;
        //    }
        //    return shortAssembly;
        //}
        #endregion

        public static Type GetType(string typeName)
        {
            lock (SyncTypeTables)
            {
                Type res;
                if (typeContractorForward.TryGetValue(typeName, out res))
                {
                    return res;
                }
            }
            return Type.GetType(typeName, false);
        }

        public static string AssemblyQualifiedNameCache(this Type t)
        {
            lock (SyncTypeTables)
            {
                string res;

                if (typeContractorReverse.TryGetValue(t, out res))
                {
                    return res;
                }
                if (SHORTENTYPENAME && ISSAFETOSHORTENALLTYPES)
                {
                    AddToTypeContractorCache(t);
                    return typeContractorReverse[t];
                }
                return t.AssemblyQualifiedName;
            }
        }

        public static Type GetType(string assemblyName, string typeName)
        {
            if (assemblyName == "W")
            {
                Type res;
                if (typeContractorForward.TryGetValue(typeName, out res))
                {
                    return res;
                }
            }
            typeName = typeName + "," + assemblyName;
            return Type.GetType(typeName, false);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsControlArray(Type type)
        {
            return type.IsGenericType && typeof(IWebMapList).IsAssignableFrom(type);
        }


        public static void AssemblyQualifiedNameCache(Type t, out string assemblyName, out string typeName)
        {
            string res;
            if (typeContractorReverse.TryGetValue(t, out res))
            {
                assemblyName = "W";
                typeName = res;
                return;
            }
            else
            {
                if (SHORTENTYPENAME && ISSAFETOSHORTENALLTYPES)
                {
                    AddToTypeContractorCache(t);
                    assemblyName = "W";
                    typeName = typeContractorReverse[t];

                }

            }
            assemblyName = t.Assembly.FullName;
            typeName = t.FullName;
        }


        public static string GetOriginalTypeName(Type type)
        {
            var myType = type;
            if (IsGeneratedType(type))
            {
                GetOriginalType(ref myType);
            }
            return myType.FullName;
        }

        public static void GetOriginalType(ref Type type)
        {
            type = type.BaseType;
        }

        /// <summary>
        /// Indicates if a property must be excluded from serialization or not.
        /// Which properties must be excluded of serialization?
        /// * Container and ViewManager properties are excluded they are injected and they do not need to be serialized
        /// * any property which its property type is an IStateObject is skipped because of the Lazy Loading
        /// * any property that is IList<T> or IDictionary<K,V> because they are implemented as IStateObjects and will use Lazy Loading as well
        /// * and properties with parameters
        /// </summary>
        /// <param name="prop"><c>PropertyInfo</c> object containing the information of the property to test for.</param>
        /// <returns><c>true</c> if the property must be excluded, <c>false</c> otherwise.</returns>
        public static bool IsExcludedProperty(PropertyInfo prop)
        {
            var propType = prop.PropertyType;
            return IsExcludedPropertyType(propType) || prop.GetIndexParameters().Any();
        }


        /// <summary>
        /// Indicates if a property type must be excluded from serialization or not.
        /// Which properties must be excluded of serialization?
        /// * IIocContainer and IViewManager types are excluded they are injected and they do not need to be serialized
        /// * IStateObject type and its implementors are skipped because of the Lazy Loading
        /// * IList<T> or IDictionary<K,V> because they are implemented as IStateObjects and will use Lazy Loading as well
        /// </summary>
        /// <param name="propType"> type to be checked.</param>
        /// <returns><c>true</c> if the type must be excluded, <c>false</c> otherwise.</returns>
        private static bool IsExcludedPropertyType(Type propType)
        {
            Type genericType = null;
            return typeof(IStateObject).IsAssignableFrom(propType) ||
                   typeof(IIocContainer).IsAssignableFrom(propType) ||
                   typeof(IViewManager).IsAssignableFrom(propType) ||
                   (propType.IsGenericType &&
                    (typeof(IList<>).IsAssignableFrom((genericType = propType.GetGenericTypeDefinition())) ||
                     typeof(IDictionary<,>).IsAssignableFrom(genericType)));

        }

        internal static bool IsExcludedPropertyForClient(PropertyInfo prop)
        {

            var attr = (StateManagement)prop.GetCustomAttributes(typeof(StateManagement), true).FirstOrDefault();
            if (attr != null && !attr.RequiresStateManagementClient()) return true;
            return false;

        }

        public static IEnumerable<PropertyInfo> GetPropertiesForAppState(Type type)
        {
            lock (syncPropsForAppState)
            {
                List<PropertyInfo> props;
                if (!propsfoprAppState.TryGetValue(type, out props))
                {
                    props = new List<PropertyInfo>();
                    foreach (PropertyInfo prop in type.Properties(BindingFlags.Public | BindingFlags.Instance))
                    {
                        //We will load only Visual Objects or Lists
                        if (typeof(IViewModel).IsAssignableFrom(prop.PropertyType) ||
                            typeof(IDependentViewModel).IsAssignableFrom(prop.PropertyType) ||
                            TypeCacheUtils.IsAnIListOfSomethingThatImplementsIStateObject(prop.PropertyType))
                        {
                            //If this is a indexed property then skip
                            if (prop.GetIndexParameters().Length > 0) continue;
                            if (TypeCacheUtils.IsExcludedPropertyForClient(prop)) continue;
                            props.Add(prop);
                        }
                    }
                    propsfoprAppState.Add(type, props);
                }
                return props;
            }
        }

        public static bool IsSpecialClass(Type codePromiseType)
        {
            return (codePromiseType.FullName.Contains("DisplayClass") || codePromiseType.GetCustomAttribute(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute)) != null);
        }



        /// <summary>
        /// Returns true if the type is supported by our implementation of non IStateObject Lists
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsSupportedGenericTypeForList(Type t)
        {
            return t.IsValueType || t == typeof(string) || t == typeof(Type);
        }
    }
}

