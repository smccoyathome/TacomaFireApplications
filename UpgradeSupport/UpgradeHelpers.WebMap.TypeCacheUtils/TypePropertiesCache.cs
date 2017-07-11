using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UpgradeHelpers.Helpers;
using System.Linq;
using Fasterflect;
using UpgradeHelpers.Interfaces;
using System.Runtime.CompilerServices;
using System.Reflection.Emit;
using UpgradeHelpers.WebMap.Server.Common;

namespace UpgradeHelpers.WebMap.Server
{

		public class TypePropertiesCache
		{
           public static bool ALIAS_ENABLED = false;

		   internal static Dictionary<Type, PropertiesExDictionary> cachePropertiesEx = new Dictionary<Type, PropertiesExDictionary>();


        //Use to associate the proxy metadata with original type to avoid double reflection time
        internal static void AssociateTypeWithProxyType(Type originalType, Type proxyType)
        {
            var cacheEx = cachePropertiesEx[originalType];
            cachePropertiesEx[proxyType] = cacheEx;
        }







        /// <summary>   
        /// Verifies that the Type information is already loaded
        /// </summary>
        /// <param name="type"></param>
        /// <param name="tableInfo"></param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static PropertiesExDictionary GetPropertiesIndexPositionOfType(Type type)
		{
			PropertiesExDictionary tableInfo;
			if (cachePropertiesEx.TryGetValue(type, out tableInfo))
			{
				return tableInfo;
			}
			LoadTable(type);
			cachePropertiesEx.TryGetValue(type, out tableInfo);
			return tableInfo;
		}

			/// <summary>   
			/// Verifies that the Type information is already loaded and return an array of PropertyInfoEx ordered by position
			/// </summary>
			/// <param name="type"></param>
			/// <param name="tableInfo"></param>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static IList<PropertyInfoEx> GetArrayPropertiesOrderedByIndex(Type type)
			{
				PropertiesExDictionary tableInfo;
				if (cachePropertiesEx.TryGetValue(type, out tableInfo))
				{
					return tableInfo.PropertiesList;
				}
				LoadTable(type);
				cachePropertiesEx.TryGetValue(type, out tableInfo);
				return tableInfo.PropertiesList;
			}

			/// <summary>   
			/// Verifies that the Type information is already loaded and return an array of PropertyInfoEx ordered by position
			/// </summary>
			/// <param name="type"></param>
			/// <param name="tableInfo"></param>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static int GetArrayPropertiesCount(Type type)
			{
				PropertiesExDictionary tableInfo;
				if (cachePropertiesEx.TryGetValue(type, out tableInfo))
				{
					return tableInfo.PropertiesList.Count;
				}
				LoadTable(type);
				cachePropertiesEx.TryGetValue(type, out tableInfo);
                return tableInfo.PropertiesList.Count;
			}




			/// <summary>   
			/// Verifies that the Type information is already loaded
			/// </summary>
			/// <param name="type"></param>
			/// <param name="tableInfo"></param>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void VerifyInformationIsLoaded(Type type, out IList<PropertyInfoEx> tableInfo)
			{
				PropertiesExDictionary dic;
				if (cachePropertiesEx.TryGetValue(type, out dic))
				{
					tableInfo = dic.PropertiesList;
					return;
				}
				LoadTable(type);
				cachePropertiesEx.TryGetValue(type, out dic);
				tableInfo = dic.PropertiesList;
			}

            public static void getProp(Type t, string setterName,int propertyIndex, int methodType, out PropertyInfoEx prop)
            {
				IList<PropertyInfoEx> tableInfo;
                VerifyInformationIsLoaded(t, out tableInfo);
                if (methodType == 2)
                {
                    prop = tableInfo[propertyIndex];
                }
				else
				{
					prop = tableInfo[propertyIndex];
				}
            }

        static InterceptionDelegates interceptionDelegates = null;
        public static void SetupInterceptionDelegates(InterceptionDelegates delegates)
        {
            interceptionDelegates = delegates;
        }

#if DEBUG
        public static bool ViewModelAnalysis { get; set; }
        public static Dictionary<Type, Dictionary<string, Type>> ImproperTypes = new Dictionary<Type, Dictionary<string, Type>>();
        public static Dictionary<Type, Dictionary<string, Type>> WarningTypes = new Dictionary<Type, Dictionary<string, Type>>();
#endif

        public static bool IsOverride(MethodInfo method)
        {
            return !method.Equals(method.GetBaseDefinition());
        }
        /// <summary>
        /// Checks if there is a Get method along the property hierarchy
        /// </summary>
        /// <returns>true if there is no getter, false otherwise</returns>
        public static bool HasNoGetter(PropertyInfo prop)
        {
            if (prop == null) return true;
            if (!prop.CanRead)
            {
                //Check if new or virtual
                var getSetMethod = prop.GetSetMethod();
                if (getSetMethod != null)
                {

                    if (!IsOverride(getSetMethod))
                    {
                        //This is a new Property Definition hiding the ancestor
                        return true;
                    }
                }
                return HasNoGetter(prop.DeclaringType.BaseType.GetProperty(prop.Name,prop.PropertyType,Type.EmptyTypes));
            }
            return false;
        }

        public static bool HasNoSetter(PropertyInfo prop)
        {
            if (prop == null) return true;
            if (!prop.CanWrite)
            {
                //Check if new or virtual
                var getGetMethod = prop.GetGetMethod();
                if (getGetMethod != null)
                {

                    if (!IsOverride(getGetMethod))
                    {
                        //This is a new Property Definition hiding the ancestor
                        return true;
                    }
                }
                return HasNoSetter(prop.DeclaringType.BaseType.GetProperty(prop.Name,prop.PropertyType,Type.EmptyTypes));
            }
            return false;
        }

        private static PropertiesExDictionary GetAncestorProperties(Type type)
        {
            var ancestorType = type.BaseType;
            if (ancestorType == null || ancestorType == typeof(object)) return null;
            PropertiesExDictionary properties;
            lock (cachePropertiesEx)
            {
                if (cachePropertiesEx.TryGetValue(ancestorType, out properties))
                {
                    return properties;
                }
                LoadTable(ancestorType);
                return cachePropertiesEx[ancestorType];
            }
        }


        private static void LoadTable(Type type)
			{
				lock (cachePropertiesEx)
				{
					if (cachePropertiesEx.ContainsKey(type))
					{
						return;
					}



                    PropertiesExDictionary properties;
                    var ancestorProperties = GetAncestorProperties(type);
                    properties = ancestorProperties != null ? new PropertiesExDictionary(ancestorProperties) : new PropertiesExDictionary();

					//Use to asign a IndexParameter field when don't have index parameters for the property
					int numberOfParentProperties = 0;
					if (ALIAS_ENABLED)
					{
                        //Determine how many properties the parent has
                        var baseType = type.BaseType;
						while (baseType != null)
						{
							numberOfParentProperties += baseType.GetProperties(BindingFlags.Public | BindingFlags.Instance).Count();
							baseType = baseType.BaseType;
						}
					}
					//short i = 0;
					var aliasIndex = numberOfParentProperties;
					//TODO: should we exclude properties here? like non-virtual or stateobject false?
					var assemblyAttribute = (StateManagementDefaultValue)type.Assembly.GetCustomAttribute(typeof(StateManagementDefaultValue));
                    var typeName = type.Name;
                    bool flag = false;
					foreach (PropertyInfo prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
					{
                        var propName = prop.Name;
						string propertyAlias = aliasIndex.ToBase48ToString();
						aliasIndex++;
						var typeAttribute = (StateManagementDefaultValue)Attribute.GetCustomAttribute(prop.DeclaringType, typeof(StateManagementDefaultValue), false);
						var attr = (StateManagement)prop.GetCustomAttributes(typeof(StateManagement), true).FirstOrDefault();

                        if (attr != null && !attr.RequiresStateManagement())
                        {
                            properties.RemoveProperty(propName);
                            continue;
                        }
						
						bool isStrongReference = false;
						bool isWeakReference = false;
						bool onlyHasGetter = false;
						bool isAssignableFromIModel;
						bool isAssignableFromITopLevelStateObject;
						bool isAssignableFromIViewManager;
						bool isAssignableFromIIocContainer;
						bool isAssignableFromILogicWithViewModel_IViewModel;
						bool isVisibleStateFlag = false;
						bool hasIndexParameters = false;
						bool isAssignableFromIDependantViewModel = false;
                        //if (HasNoGetter(prop))
                        //{
                        //    //It will not be added to the list of propertyInfoEx
                        //    continue;
                        //}
                        //else if (HasNoSetter(prop))
                        //{
                        //    //It will not added to the list of propertyInfoEx but we will keep the flag
                        //    if (attr == null)
                        //        attr = new StateManagement(StateManagementValues.ClientOnly);
                        //    onlyHasGetter = true;
                        //}

                        /*if (!prop.CanRead)
                        {
                            attr = new StateManagement(StateManagementValues.None);
                        }*/
						//We should exclude ViewManager and Container
						if ((propName == "ViewManager" && prop.PropertyType == typeof(IViewManager)) ||
							(propName == "Container" && prop.PropertyType == typeof(IIocContainer)))
							continue;

						var isStateObject = typeof(IStateObject).IsAssignableFrom(prop.PropertyType);
						var propertyType = prop.PropertyType;
						var propertyInfoEx = new PropertyInfoEx();
                        propertyInfoEx.OnlyHasGetter = onlyHasGetter;
						if (ALIAS_ENABLED)
						{
							var aliasAttribute = (StateManagementAlias)prop.GetCustomAttributes(typeof(StateManagementAlias), true).FirstOrDefault();
							if (aliasAttribute != null)
								propertyInfoEx.alias = aliasAttribute.Value;
							else
								propertyInfoEx.alias = propertyAlias;
						}
						propertyInfoEx.prop = prop;
						propertyInfoEx.hasSurrogate = SurrogatesDirectory.IsSurrogateRegistered(propertyType);
						var attrRef = prop.GetCustomAttributes(typeof(Reference), true).FirstOrDefault() as Reference;
						propertyInfoEx.hasReferenceAttribute = attrRef != null;
						if (propertyInfoEx.hasReferenceAttribute)
						{
							isStrongReference = attrRef.Value == ReferenceTypeValues.Strong;
							isWeakReference = attrRef.Value == ReferenceTypeValues.Weak;
						}
						isAssignableFromIModel = typeof(IModel).IsAssignableFrom(propertyType);
						propertyInfoEx.isAssignableFromIDependantStateObject = typeof(IDependentStateObject).IsAssignableFrom(propertyType);
						isAssignableFromIDependantViewModel = typeof(IDependentViewModel).IsAssignableFrom(propertyType);
						isAssignableFromITopLevelStateObject = typeof(ITopLevelStateObject).IsAssignableFrom(propertyType);
						isAssignableFromIIocContainer = typeof(IIocContainer).IsAssignableFrom(propertyType);
						isAssignableFromIViewManager = typeof(IViewManager).IsAssignableFrom(propertyType);

						propertyInfoEx.isAnIDictionary = TypeCacheUtils.IsAnIDictionary(propertyType);
						propertyInfoEx.isAnIList = TypeCacheUtils.IsAnIList(propertyType);
                        if (prop.Name.Equals("VisibleState", StringComparison.Ordinal) && prop.PropertyType == typeof(VisibleState))
                            isVisibleStateFlag = true;
                        StateManagementValues stateManagementAttribute = StateManagementValues.Both;
						if (attr != null)
							stateManagementAttribute = attr.Value;
						else if (typeAttribute != null)
						{
							if (!propertyInfoEx.isAnIList && !isAssignableFromIDependantViewModel)
								stateManagementAttribute = typeAttribute.Value;
						}
						else if (assemblyAttribute != null)
						{
							if (!propertyInfoEx.isAnIList && !isAssignableFromIDependantViewModel)
								stateManagementAttribute = assemblyAttribute.Value;
						}

						propertyInfoEx.stateManagementAttribute = stateManagementAttribute;
						var indexParameters = prop.GetIndexParameters();
						hasIndexParameters = (indexParameters != null) && (indexParameters.Length > 0);
						//propertyInfoEx.propertyPositionIndex = i;

						propertyInfoEx.mustIgnoreMemberForClient =
							StateManagementUtils.MustIgnoreMember(true, prop) /*check the statemanagement attribute*/||
							  TypeCacheUtils.IsExcludedProperty(prop) ||
							  propertyInfoEx.hasSurrogate || isAssignableFromIDependantViewModel;

						// propertyInfoEx.CanRead = prop.CanRead && prop.GetGetMethod(false) != null;
						//	propertyInfoEx.CanWrite = prop.CanWrite && prop.GetGetMethod(false) != null;

						//Read JsonNet attributes

						//propertyInfoEx.jsonPropertyAttribute = Attribute.GetCustomAttribute(prop, typeof(Newtonsoft.Json.Serialization.JsonProperty), false);

						//propertyInfoEx.defaultValueAttribute = Attribute.GetCustomAttribute(prop, typeof(System.ComponentModel.DefaultValueAttribute), false) as System.

						//Validate if this is an IList of object
						bool isASupportedValueTypeForIList = false;
                    if (propertyInfoEx.isAnIList && !propertyInfoEx.isAnIList)
                    {
                        //It could be an IList<object>, but it need to have the statemanagement attribute Generict
                        //var collAtt =
                        //	(GenericCollectionTypeInfo)prop.GetCustomAttributes(typeof(GenericCollectionTypeInfo), true).FirstOrDefault();
                        //if (collAtt != null && collAtt.RuntimeType == typeof(IList<IStateObject>))
                        //{
                        //	propertyInfoEx.isAnIListOfSomethingThatImplementsIStateObject = true;
                        //}
                        //else
                        //{
                        var listItemType = propertyType.GetGenericArguments()[0];
                        isASupportedValueTypeForIList = interceptionDelegates.isASupportedValueTypeForIListDelegate(listItemType);
                        TraceUtil.TraceError("invalid IList<object> possible statemanagement issues");
                        //}

                    }

						isAssignableFromILogicWithViewModel_IViewModel =
							typeof(ILogicWithViewModel<IViewModel>).IsAssignableFrom(propertyType);
						propertyInfoEx.isStateObject = isStateObject;
						propertyInfoEx.isNonStateObjectFixedType = propertyType.IsValueType || typeof(string) == propertyType ||
																   typeof(Type) == propertyType;
						propertyInfoEx.isObjectPropertyType = typeof(Object) == propertyType;
						//We Assign the corresponding getter Action
						if (isStrongReference || propertyInfoEx.isObjectPropertyType)
						{
							propertyInfoEx.ProcessGetter = interceptionDelegates.ProcessGetterStrongReference;
						}
						else if (isWeakReference)
						{
							propertyInfoEx.ProcessGetter = interceptionDelegates.ProcessGetterWeakReference;
						}
						else if (propertyInfoEx.hasSurrogate)
						{
							propertyInfoEx.ProcessGetter = interceptionDelegates.ProcessGetterSurrogate;
						}
						else if (propertyInfoEx.isAssignableFromIDependantStateObject ||
								 propertyInfoEx.isAnIList ||
							 propertyInfoEx.isAnIDictionary || isASupportedValueTypeForIList)
						{
							propertyInfoEx.ProcessGetter = interceptionDelegates.ProcessGetterNonTopLevelIStateObject;
						}
						else if (isAssignableFromITopLevelStateObject)
						{
							propertyInfoEx.ProcessGetter = interceptionDelegates.ProcessGetterTopLevelIStateObject;
						}
						else if (isAssignableFromILogicWithViewModel_IViewModel)
						{
							propertyInfoEx.ProcessGetter = interceptionDelegates.ProcessGetterNoAction;
						}
						else
						{
							propertyInfoEx.ProcessGetter = interceptionDelegates.ProcessGetterNoAction;
						}

						//We Assign the corresponding setter Action

                        if(isVisibleStateFlag)
                        {
                            //This is a special process setter for handling property VisibleState of ControlBase or FormBase
                            propertyInfoEx.ProcessSetter = interceptionDelegates.ProcessSetterVisibleState;
                        }
                        else if (propertyInfoEx.isObjectPropertyType)
						{
							propertyInfoEx.ProcessSetter = interceptionDelegates.ProcessSetterObjectReference;
						}
						else if (propertyInfoEx.hasSurrogate)
						{
							propertyInfoEx.ProcessSetter = interceptionDelegates.ProcessSetterSurrogate;
						}
						else if (isStrongReference)
						{
							propertyInfoEx.ProcessSetter = interceptionDelegates.ProcessSetterStrongReference;
						}
						else if (propertyInfoEx.hasReferenceAttribute)
						{
							propertyInfoEx.ProcessSetter = interceptionDelegates.ProcessSetterWeakReference;
						}
                        else if (!propertyInfoEx.hasReferenceAttribute && !propertyInfoEx.hasSurrogate)
                        {
                            if (propertyInfoEx.prop.PropertyType.IsValueType || propertyInfoEx.prop.PropertyType == typeof(string))
                            {
                                propertyInfoEx.ProcessSetter = interceptionDelegates.ProcessSetterSimpleTypes;
                            }
                            else if (isAssignableFromILogicWithViewModel_IViewModel)
                                propertyInfoEx.ProcessSetter = interceptionDelegates.ProcessSetterSimpleTypes;
                            else
                            {
                                if (propertyInfoEx.prop.PropertyType.IsClass && !typeof(IStateObject).IsAssignableFrom(propertyInfoEx.prop.PropertyType))
                                {
                                    propertyInfoEx.ProcessSetter = interceptionDelegates.ProcessSetterSimpleTypes;
                                }
                                else
                                    propertyInfoEx.ProcessSetter = interceptionDelegates.ProcessSetterMostCases;
                            }

                        }
                        RegisterProperty(propertyInfoEx, properties, hasIndexParameters);

#if DEBUG
						if (ViewModelAnalysis)
						{
							if (!typeof(IInternalData).IsAssignableFrom(type))
							{
								if (propertyType.IsInterface &&
									//!propertyInfoEx.isAnIListOfSomethingThatImplementsIStateObject &&
									!isAssignableFromIIocContainer &&
									!isAssignableFromIViewManager &&
									!propertyInfoEx.isAssignableFromIDependantStateObject &&
									!(propertyInfoEx.isAnIList && isASupportedValueTypeForIList) &&
									!isAssignableFromIModel &&
									!typeof(IViewModel).IsAssignableFrom(propertyType))
								{
									var improperType = type;
									if (improperType.Assembly.IsDynamic) improperType = improperType.BaseType;
									Dictionary<string, Type> improperTypeTable;
									if (!ImproperTypes.TryGetValue(improperType, out improperTypeTable))
									{
										ImproperTypes[improperType] = improperTypeTable = new Dictionary<string, Type>();
									}
									improperTypeTable[prop.Name] = propertyType;
								}
								else if (propertyType == typeof(object) && !propertyInfoEx.hasReferenceAttribute)
								{
									var warningType = type;
									if (warningType.Assembly.IsDynamic) warningType = warningType.BaseType;
									Dictionary<string, Type> warningTypeTable;
									if (!WarningTypes.TryGetValue(warningType, out warningTypeTable))
									{
										WarningTypes[warningType] = warningTypeTable = new Dictionary<string, Type>();
									}
									warningTypeTable[prop.Name] = propertyType;
								}
							}
						}
#endif

					}
                    ////for loop is faster, but cannot iterate on the dictionary
                    //foreach (var item in properties)
                    //{
                    //    tuple2.Add(item.Key, item.Value.propertyPositionIndex);

                    //    bitArrayMappedTable[item.Value.propertyPositionIndex] = item.Value;
                    //}
					//cache with position
                    properties.PropertiesList = properties.PropertiesList.ToArray();
					cachePropertiesEx.Add(type, properties);
				}
			}

		private static void RegisterProperty(PropertyInfoEx propEx, PropertiesExDictionary properties, bool hasIndexParameters)
			{
				var prop = propEx.prop;
				if (!hasIndexParameters)
				{
					var propName = prop.Name;
					//A property might be overriden by a descendant class
					int existingPos = -1;
					//If we have already registered then we check
					//Descendant property will always win
                    if (!properties.TryGetValue(propName, out existingPos))
					{
						properties.AddProperty(propName, propEx);
					}
                    else
                    {
                        propEx.propertyPositionIndex = (short)existingPos;
                        properties.PropertiesList[existingPos] = propEx;
                    }
				}
			}

		}
}