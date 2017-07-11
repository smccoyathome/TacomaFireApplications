using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Surrogates
{
    /// <summary>
    /// This is a multi purpose and generic JSON serializer
    /// </summary>
    public class GlobalSerializer
    {


        public static FieldInfo GetFieldInfoIncludingBaseClasses(Type type,string fieldName, BindingFlags bindingFlags)
        {
            var fieldInfo = type.GetField(fieldName,bindingFlags);

            // If this class doesn't have a base, don't waste any time
            if (type.BaseType == typeof(object))
            {
                return fieldInfo;
            }
            else
            {   // Otherwise, collect all types up to the furthest base class
                var currentType = type;
                while (currentType != typeof(object))
                {
                    fieldInfo = currentType.GetField(fieldName,bindingFlags);
                    if (fieldInfo != null) return fieldInfo;
                    currentType = currentType.BaseType;
                }
                return null;
            }
        }

        public static IList<FieldInfo> GetFieldInfosIncludingBaseClasses(Type type, BindingFlags bindingFlags)
        {
            FieldInfo[] fieldInfos = type.GetFields(bindingFlags);

            // If this class doesn't have a base, don't waste any time
            if (type.BaseType == typeof(object))
            {
                return fieldInfos;
            }
            else
            {   // Otherwise, collect all types up to the furthest base class
                var currentType = type;
                var fieldComparer = new FieldInfoComparer();
                var fieldInfoList = new HashSet<FieldInfo>(fieldInfos, fieldComparer);
                while (currentType != typeof(object))
                {
                    fieldInfos = currentType.GetFields(bindingFlags);
                    fieldInfoList.UnionWith(fieldInfos);
                    currentType = currentType.BaseType;
                }
                return fieldInfoList.ToArray();
            }
        }

        private class FieldInfoComparer : IEqualityComparer<FieldInfo>
        {
            public bool Equals(FieldInfo x, FieldInfo y)
            {
                return x.DeclaringType == y.DeclaringType && x.Name == y.Name;
            }

            public int GetHashCode(FieldInfo obj)
            {
                return obj.Name.GetHashCode() ^ obj.DeclaringType.GetHashCode();
            }
        }



		public static IList<object> CalculateDependencies(object value, ISurrogateDependenciesContext dependenciesContext)
		{
			var fldArr = GetFieldInfosIncludingBaseClasses(value.GetType(),BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
			var res = new object[fldArr.Count];
			for (int i = 0; i < res.Length; i++)
			{
				var currentField = fldArr[i];
				if (typeof(IStateObject).IsAssignableFrom(currentField.FieldType))
				{
					res[i] = currentField.GetValue(value);
				}
				else if (currentField.FieldType.IsSerializable && typeof(MulticastDelegate).IsAssignableFrom(currentField.FieldType))
				{
					//Skip do no support delegate fields
				}
				else if (SurrogatesDirectory.IsSurrogateRegistered(currentField.FieldType))
				{
					res[i] = currentField.GetValue(value);
				}
			}
			return res;
		}


        /// <summary>
        /// Writes the given object and returns the JSON string
        /// </summary>
        public static void WriteObject(JsonWriter writer, object value, ISurrogateContext context)
        {
            writer.WriteStartObject();
            Type valueType = value.GetType();
            writer.WritePropertyName("__type");
            string assemblyQualifiedName = SurrogatesDirectory.TypeToContractedString(valueType);
            writer.WriteValue(assemblyQualifiedName);
            if(value is System.Collections.IDictionary)
            {
                SerializeDictionary(writer, value,context);
            }
            else if (value is System.Collections.IEnumerable)
            {
                SerializeEnumerable(writer, value, valueType,context);
            }
            else
            {
                var fldArr = GetFieldInfosIncludingBaseClasses(valueType, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

                for (var i = 0; i < fldArr.Count; i++)
                {
                    var propEx = fldArr[i];
                    var propValue = propEx.GetValue(value);
					var currentField = fldArr[i];
					if (typeof(IStateObject).IsAssignableFrom(currentField.FieldType))
					{
						writer.WritePropertyName(propEx.Name);
						writer.WriteValue(((IStateObject)propValue).UniqueID);
					}
					else if (currentField.FieldType.IsSerializable && typeof(MulticastDelegate).IsAssignableFrom(currentField.FieldType))
					{
						//Skip do no support delegate fields
					}
					else if (SurrogatesDirectory.IsSurrogateRegistered(currentField.FieldType))
					{
						if (propValue != null)
						{
							var surr = context.GetStateObjectSurrogate(propValue, generateIfNotFound: false);
							if (surr == null) throw new InvalidOperationException();

							writer.WritePropertyName(propEx.Name);
							writer.WriteValue(((IStateObject)surr).UniqueID);
						}
						else
						{
							writer.WritePropertyName(propEx.Name);
							writer.WriteValue(String.Empty);
						}

					}
					else
					{
						//Lets check if that value is not a dependency.
						//if (dependencies != null && IsObjectInDependencies(dependencies, propValue))
						//    continue;
						writer.WritePropertyName(propEx.Name);
						WriteValueAux(writer, propValue, propEx.FieldType,context);
					}
                }
            }
            writer.WriteEndObject();
        }

        private static void SerializeEnumerable(JsonWriter writer, object obj, Type valueType,ISurrogateContext context)
        {
            var isArray = valueType.IsArray;
            if (isArray)
            {
                var length = (obj as Array).Length;
                writer.WritePropertyName("__isArray");
                writer.WriteValue(isArray);
                writer.WritePropertyName("__arrayLength");
                writer.WriteValue(length);
                writer.WritePropertyName("__elementType");
                string elementTypeName = SurrogatesDirectory.TypeToContractedString(valueType.GetElementType());
                writer.WriteValue(elementTypeName);
            }
            writer.WritePropertyName("__arr");

            var array = obj as IEnumerable;
            writer.WriteStartArray();
            foreach (object item in array)
            {
                var prop = item.GetType();
                WriteValueAux(writer, item, prop,context);
            }

            writer.WriteEndArray();
        }

        private static void SerializeDictionary(JsonWriter writer, object obj, ISurrogateContext context)
        {
            var dict = obj as System.Collections.IDictionary;
            writer.WritePropertyName("__dict");
            writer.WriteStartObject();
            writer.WritePropertyName("_keys");
            writer.WriteStartArray();
            foreach (var key in dict.Keys)
            {
                writer.WriteValue(key);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("_values");
            writer.WriteStartArray();
            foreach (var value in dict.Values)
            {
                var _valueType = value.GetType();
                WriteValueAux(writer, value, _valueType,context);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        static bool IsObjectInDependencies(List<object> dependencies, object instance)
        {
            foreach (UpgradeHelpers.Interfaces.IStateObjectSurrogate surrogate in dependencies)
            {
                if (surrogate.Value == instance)
                    return true;
            }
            return false;
        }

        private static void WriteValueAux(JsonWriter writer, object item, Type prop,ISurrogateContext context)
        {
            if (prop.IsClass && !prop.IsValueType && !prop.Name.Equals("String"))
            {
                if (item != null)
                    WriteObject(writer, item,context);
                else writer.WriteValue(String.Empty);
            }
            else
            {
                writer.WriteValue(item);
            }
        }

        /// <summary>
        /// Reads the JSON and converts to the real object.
        /// </summary>
        public static object ReadObject(JsonReader reader, Type expectedType = null,ISurrogateContext context=null)
        {
            object newInstance = null;
            Array newInstanceAsArray = null;
            IList newInstanceAsIList = null;
            IDictionary newInstanceAsIDictionary = null;
            Type elementType = null;
            JObject jobj = JObject.Load(reader);

            var assemblyQualifiedType = jobj["__type"].Value<string>();
            Type targetType = SurrogatesDirectory.ContractedStringToType(assemblyQualifiedType);

            var isArray = jobj["__isArray"] != null ? jobj["__isArray"].Value<bool>() : false;
            if (isArray)
            {
                var length = jobj["__arrayLength"].Value<int>();
                var elementTypeName = jobj["__elementType"].Value<string>();
                elementType = SurrogatesDirectory.ContractedStringToType(elementTypeName);
                newInstance = newInstanceAsArray = Array.CreateInstance(elementType, length);
            }
            else
                newInstance = Activator.CreateInstance(targetType);

            foreach (JProperty prop in jobj.Properties())
            {
                MemberInfo reflectedMember = null;
                object adapterValue = null;

                if (prop.Name == "__type") continue;
                if (prop.Name == "__isArray") continue;
                if (prop.Name == "__arrayLength") continue;
                if (prop.Name == "__elementType") continue;
                if(prop.Name == "__dict")
                {
                    newInstanceAsIDictionary = newInstance as IDictionary;
                    var keys = prop.Value["_keys"].Value<JArray>();
                    var values = prop.Value["_values"].Value<JArray>();
                    var index = 0;
                    foreach(var key in keys)
                    {
                        newInstanceAsIDictionary.Add(key, values[index++]);
                    }
                }
                else if (prop.Name == "__arr")
                {
                    var values = prop.Value as IEnumerable;
                    var index = 0;
                    if (!isArray) newInstanceAsIList = (IList)newInstance;
                    foreach (var item in values)
                    {
                        var itemAsJValue = item as JValue;
                        if (isArray)
                        {

                            if (itemAsJValue != null)
                            {
                                if (itemAsJValue.Type == JTokenType.Object)
                                    newInstanceAsArray.SetValue(ReadObject(itemAsJValue.CreateReader(),null,context), index);
                                else
                                    newInstanceAsArray.SetValue(Convert.ChangeType(itemAsJValue.Value, elementType), index);
                            }
                            else
                                newInstanceAsArray.SetValue(ReadObject((item as JObject).CreateReader(),null,context), index);
                        }
                        else
                        {
                            if (itemAsJValue != null)
                            {
                                if (itemAsJValue.Type == JTokenType.Object)
                                    newInstanceAsIList.Add(ReadObject(itemAsJValue.CreateReader(),null,context));
                                else
                                    newInstanceAsIList.Add(itemAsJValue.Value);
                            }
                            else
                                newInstanceAsIList.Add(ReadObject((item as JObject).CreateReader(),null,context));
                        }
                        index++;
                    }
                }
                else
                {

		//Check that is always ONE member.

                        reflectedMember = GetFieldInfoIncludingBaseClasses(targetType, prop.Name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
						var reflectedField = reflectedMember as FieldInfo;
						try
						{
							if (reflectedField != null)
							{
								if (reflectedField.FieldType.IsValueType || reflectedField.FieldType.Name.Equals("String"))
								{
									adapterValue = Convert.ChangeType(prop.Value, reflectedField.FieldType);
									reflectedField.SetValue(newInstance, adapterValue);
								}
								else
								{
									var currentField = reflectedField;
									if (typeof(IStateObject).IsAssignableFrom(currentField.FieldType))
									{
										var uniqueID = prop.Value.Value<string>();
										if (!String.IsNullOrWhiteSpace(uniqueID))
											reflectedField.SetValue(newInstance, context.RestoreStateObject(uniqueID));
										
									}
									else if (currentField.FieldType.IsSerializable && typeof(MulticastDelegate).IsAssignableFrom(currentField.FieldType))
									{
										//Skip do no support delegate fields
									}
									else if (SurrogatesDirectory.IsSurrogateRegistered(currentField.FieldType))
									{

										var uniqueID = prop.Value.Value<string>();
										if (!String.IsNullOrWhiteSpace(uniqueID))
											reflectedField.SetValue(newInstance, context.RestoreSurrogateValue(uniqueID));
									}
									else
									{

										adapterValue = (prop.Value.ToString() == String.Empty) ? null : ReadObject(prop.Value.CreateReader(), reflectedField.FieldType,context);
										reflectedField.SetValue(newInstance, adapterValue);
									}
								}

							}
						}
						catch
						{
							throw new InvalidOperationException("Error While deserialing object.");
						}
                }
            }
            return newInstance;
        }
    }
}
