using System;
using System.Linq;
using System.Reflection;
using Fasterflect;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Server;
using System.Diagnostics;

namespace UpgradeHelpers.WebMap.Server
{
	internal class StateObjectSerializer : JsonConverter
	{
		private readonly bool writeTypeInfo;
		private readonly bool writeUniqueID;

		public StateObjectSerializer(bool writeTypeInfo, bool writeUniqueID)
		{
			this.writeTypeInfo = writeTypeInfo;
			this.writeUniqueID = writeUniqueID;
		}

		public StateObjectSerializer()
			: this(true, true)
		{
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			writer.WriteStartObject();
			Type valueType = value.GetType();
			if (writeTypeInfo)
			{
				writer.WritePropertyName("__type");

				string assemblyQualifiedName = valueType.AssemblyQualifiedName;
				writer.WriteValue(assemblyQualifiedName);
			}
			var propArr = TypePropertiesCache.GetArrayPropertiesOrderedByIndex(valueType);
			for (var i = 0; i < propArr.Count; i++)
			{
				var propEx = propArr[i];
                if (propEx == null) continue;
                var prop = propEx.prop;
				if (propEx.mustIgnoreMemberForClient)
				{
					continue;
				}
                object propValue=null;
                try
                {
                    propValue = prop.GetValue(value, null);
                    writer.WritePropertyName(prop.Name);
                    serializer.Serialize(writer, propValue);
                }
                catch(Exception ex)
                {
                    Debug.WriteLine("Problem while writing JSON for object of type " + valueType + " property " + prop.Name);
                    Debug.WriteLine("Error " + ex.Message);
                }
				
			}

			writer.WriteEndObject();
		}





		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			JObject jobj = JObject.Load(reader);
			var assemblyQualifiedType = jobj["__type"].Value<string>();
			Type targetType = Type.GetType(assemblyQualifiedType, false, false);
			if (TypeCacheUtils.IsControlArray(targetType))
			{
				var size = jobj["Count"].Value<int>();
				var uid = jobj["UniqueID"].Value<string>();
				dynamic value = IocContainerImplWithUnity.Current.ResolveUnPrepared(targetType);
				value.SetupLazy(size, uid);
				return value;
			}
			object newInstance = IocContainerImplWithUnity.Current.ResolveUnPrepared(targetType);
			foreach (JProperty prop in jobj.Properties().ToList())
			{
				if (prop.Name == "__type") continue;
				//WARNING Fasterflect result might vary frp, the reflection results
				PropertyInfo reflectedProperty = targetType.Property(prop.Name);
				object adapterValue = Convert.ChangeType(prop.Value, reflectedProperty.PropertyType);
				reflectedProperty.SetValue(newInstance, adapterValue, null);
			}
			return newInstance;
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(IStateObject).IsAssignableFrom(objectType);
		}
	}

}