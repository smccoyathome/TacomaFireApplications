using System;
using Newtonsoft.Json;
using System.Reflection;
using UpgradeHelpers.WebMap.Server;
using System.Collections;
using System.Runtime.CompilerServices;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server
{


    
	public class ObservableDictionaryExSerializer : JsonConverter
	{

        private class SerializerMethods
        {
            private Type keyType;
            private Type valueType;
            private readonly JsonReader reader;
            private readonly JsonWriter writer;
            public readonly Func<object> ReadKeyMethod;
            public readonly Func<object> ReadValueMethod;
            public readonly Action<object> WriteKeyMethod;
            public readonly Action<object> WriteValueMethod;

            public SerializerMethods(JsonWriter writer, Type keyType, Type valueType)
            {
                this.writer = writer;
                this.keyType = keyType;
                this.valueType = valueType;
                //First assign delegate depending on keyType
                if (typeof(string) == keyType)
                    WriteKeyMethod = WriteKeyGeneric;
                else if (typeof(Type) == keyType)
                    WriteKeyMethod = WriteKeyType;
                else if (typeof(IStateObject).IsAssignableFrom(keyType))
                    WriteKeyMethod = WriteKeyStateObject;
                else
                    WriteKeyMethod = WriteKeyGeneric;

                //Second assign delegate depending on valueType
                if (typeof(string) == valueType)
                    WriteValueMethod = WriteValueGeneric;
                else if (typeof(Type) == valueType)
                    WriteValueMethod = WriteValueType;
                else if (typeof(IStateObject).IsAssignableFrom(valueType) ||
                    TypeCacheUtils.IsIListOrIDictionary(valueType) ||
                    typeof(Delegate).IsAssignableFrom(valueType) ||
                    SurrogatesDirectory.IsSurrogateRegistered(valueType))
                    WriteValueMethod = WriteValueStateObject;
                else
                    WriteValueMethod = WriteValueGeneric;
            }

            public SerializerMethods(JsonReader reader, Type keyType,Type valueType)
            {
                this.reader = reader;
                this.keyType = keyType;
                this.valueType = valueType;

                //First assign delegate depending on keyType
                if (typeof(string) == keyType)
                    ReadKeyMethod = ReadInputAsString;
                else if (typeof(Type) == keyType)
                    ReadKeyMethod = ReadInputAsType;
                else if (typeof(IStateObject).IsAssignableFrom(keyType))
                    ReadKeyMethod = ReadInputAsStateObject;
                else if (keyType.IsEnum)
                    ReadKeyMethod = ReadInputAsEnum;
                else
                    ReadKeyMethod = ReadInputAsOther;

                //Second assign delegate depending on valueType
                if (typeof(string) == valueType)
                    ReadValueMethod = ReadInputAsString;
                else if (typeof(Type) == valueType)
                    ReadValueMethod = ReadInputAsType;
                else if (valueType.IsEnum)
                    ReadValueMethod = ReadInputValueAsEnum;
                else if (typeof(IStateObject).IsAssignableFrom(valueType) ||
                    TypeCacheUtils.IsIListOrIDictionary(valueType) ||
                    typeof(Delegate).IsAssignableFrom(valueType) ||
                    SurrogatesDirectory.IsSurrogateRegistered(valueType))
                    ReadValueMethod = ReadInputAsStateObject;
                else
                    ReadValueMethod = ReadInputValueAsOther;
            }



            private void WriteKeyGeneric(object val)
            {
                writer.WritePropertyName(val.ToString());
            }

            private void WriteKeyType(object val)
            {
                var typeVal = (Type)val;
                writer.WritePropertyName(TypeCacheUtils.AssemblyQualifiedNameCache(typeVal));
            }

            private void WriteKeyStateObject(object val)
            {
                var stateObjectVal = (CollectionStateObjectReference)val;
                writer.WritePropertyName(stateObjectVal.TargetUniqueID);
            }


            private void WriteValueGeneric(object val)
            {
                writer.WriteValue(val.ToString());
            }

            private void WriteValueType(object val)
            {
                var typeVal = (Type)val;
                writer.WriteValue(typeVal.AssemblyQualifiedNameCache());
            }

            private void WriteValueStateObject(object val)
            {
                var stateObjectVal = ((CollectionStateObjectReference)val).TargetUniqueID;
                writer.WriteValue(stateObjectVal);
            }


            private object ReadInputAsString()
            {
                object val = reader.Value; reader.Read();
                return val;
            }

            private object ReadInputAsType()
            {
                object val = reader.Value; reader.Read();
                val = TypeCacheUtils.GetType((string)val);
                return val;
            }

            private object ReadInputAsOther()
            {
                object val = reader.Value; reader.Read();
                val = Convert.ChangeType(val, keyType);
                return val;
            }

            private object ReadInputAsEnum()
            {
                object val = reader.Value; reader.Read();
                val = Enum.Parse(keyType, val.ToString(), true);
                return val;
            }


            private object ReadInputValueAsOther()
            {
                object val = reader.Value; reader.Read();
                val = Convert.ChangeType(val, valueType);
                return val;
            }

            private object ReadInputValueAsEnum()
            {
                object val = reader.Value; reader.Read();
                val = Enum.Parse(valueType, val.ToString(), true);
                return val;
            }

            private object ReadInputAsStateObject()
            {
                object val = reader.Value; reader.Read();
                string value = (string)val;
                var refe = new CollectionStateObjectReference(value);
                return refe;
            }

        }
        public override bool CanConvert(Type type)
		{
            return typeof(IObservableDictionaryEntries).IsAssignableFrom(type);
		}




		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.StartArray)
            {
                IObservableDictionaryEntries instanceEx = (IObservableDictionaryEntries)existingValue;
                reader.Read();
                var dictType = (long)reader.Value;
                ValidateDictType(dictType);
                var dict = instanceEx.GetInternalDictionary((int)dictType);

                reader.Read();
                var count = (long)reader.Value;
                if (count == 0) return instanceEx;
                reader.Read();//To position reader.TokenType after count

                var types = objectType.GetGenericArguments();
                var keyType = types[0];
                var valueType = types[1];
                var serializerMethods = new SerializerMethods(reader, keyType, valueType);
                try
                {
                    instanceEx.DeltaTrackerNotifications(false);
                    reader.Read();//We assume token at this point is StartToken and need to move past it
                    while (reader.TokenType != JsonToken.EndObject)
                    {
                        object key = serializerMethods.ReadKeyMethod();
                        object value = serializerMethods.ReadValueMethod();
                        dict.Add(key, value);
                    }
                    return instanceEx;
                }
                finally
                {
                    instanceEx.DeltaTrackerNotifications(true);
                }
            }
            throw new NotImplementedException("Invalid Json format for Dictionary");
		}

        private static void ValidateDictType(long dictType)
        {
            if (dictType < 1 || dictType > 6) throw new NotImplementedException("Only Dictionarytypes from 1-6 are supported ");
        }






        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			Type dictType = value.GetType();//Dictionary are marked as NonIntercept
			var dictGenericTypes = dictType.GetGenericArguments();
			var keyType = dictGenericTypes[0];
			var valueType = dictGenericTypes[1];
            var serializerMethods = new SerializerMethods(writer, keyType, valueType);
            IObservableDictionaryEntries instanceEx = (IObservableDictionaryEntries)value;
            writer.WriteStartArray();
            int caseType = instanceEx.CaseType;
            ValidateDictType(caseType);
            writer.WriteValue(caseType);
			var theDict = instanceEx.GetInternalDictionary(caseType);
            writer.WriteValue(theDict.Count);
            if (theDict.Count > 0)
            {
                writer.WriteStartObject();
                foreach (var key in theDict.Keys)
                {
                    serializerMethods.WriteKeyMethod(key);
                    serializerMethods.WriteValueMethod(theDict[key]);
                }
                writer.WriteEndObject();
            }
            writer.WriteEndArray();
		}

	}

}