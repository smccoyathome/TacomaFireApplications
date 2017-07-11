using System;
using System.Linq;
using System.Reflection;
using Fasterflect;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;
using System.Collections;

namespace UpgradeHelpers.WebMap.Server
{
	internal class IEnumerableSerializer : JsonConverter
	{
		private readonly bool writeTypeInfo;
		private readonly bool writeUniqueID;

		public IEnumerableSerializer(bool writeTypeInfo, bool writeUniqueID)
		{
			this.writeTypeInfo = writeTypeInfo;
			this.writeUniqueID = writeUniqueID;
		}

		public IEnumerableSerializer()
			: this(true, true)
		{
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			writer.WriteStartObject();
            var props = TypePropertiesCache.GetArrayPropertiesOrderedByIndex(value.GetType());
            for (int i = 0; i < props.Count; i++)
            {
                var propEx = props[i];
                if (propEx==null || propEx.mustIgnoreMemberForClient)
                {
                    continue;
                }
                PropertyInfo prop = propEx.prop;
                var propValue = prop.GetValue(value, null);
                //We should not send in the json for an object, any property that is an stateobject
                //they should travel independenly
                //This check is important because we have properties 
                if (!(propValue is IStateObject))
                {
                    writer.WritePropertyName(prop.Name);
                    serializer.Serialize(writer, propValue);
                }
            }
			writer.WriteEndObject();
		}





		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			//{ a:"aa", size: { width: 10, height} }
			if (reader.TokenType == JsonToken.StartObject) reader.Read();
			int maxCycles = 0;
			object newInstance = existingValue;
			var targetType = newInstance.GetType();
			do
			{
				String propertyName = "";
				if (reader.TokenType == JsonToken.PropertyName)
				{
					propertyName = reader.Value.ToString();
					reader.Read();//Advance to next token
				}
				PropertyInfo reflectedProperty = targetType.Property(propertyName);
				var adapterValue = serializer.Deserialize(reader, reflectedProperty.PropertyType);
				if (reflectedProperty.GetSetMethod() != null)
				{
					reflectedProperty.SetValue(newInstance, adapterValue, null);
				}
				maxCycles++;
				reader.Read();
			} while (reader.TokenType != JsonToken.EndObject && maxCycles < 900000);
			return newInstance;
		}

		public override bool CanConvert(Type objectType)
		{
			return !typeof(IEnumerableException).IsAssignableFrom(objectType) && typeof(IEnumerable).IsAssignableFrom(objectType) && typeof(IStateObject).IsAssignableFrom(objectType);
		}
	}

}
