using Newtonsoft.Json;
using System;

namespace UpgradeHelpers.WebMap.Server
{
	internal class StateObjectSerializerIndex : StateObjectSerializer
	{
		public StateObjectSerializerIndex(bool writeTypeInfo, bool writeUniqueID)
			: base(writeTypeInfo, writeUniqueID)
		{
		}

		public StateObjectSerializerIndex()
			: this(true, true)
		{
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			Type valueType = value.GetType();
			if (TypeCacheUtils.IsControlArray(valueType))
			{
				writer.WriteStartObject();
                var coll = (IObservableCollectionMarkerInterface)value;
				writer.WritePropertyName("UniqueID");
				writer.WriteValue(coll.UniqueID);
				writer.WritePropertyName("Count");
				writer.WriteValue(coll.Count);
				writer.WritePropertyName("@arr");
				writer.WriteValue("1");
				writer.WriteEndObject();
			}
			else
			{
				try
				{
					base.WriteJson(writer, value, serializer);
				}
				catch (Exception ex)
				{
					System.Diagnostics.Debug.Fail("StateObjectSerializerIndex::WriteJSON error trying to seialize object " + ex.Message);
					writer.WriteStartObject();
					writer.WriteEndObject();
				}
			}
		}
	}
}