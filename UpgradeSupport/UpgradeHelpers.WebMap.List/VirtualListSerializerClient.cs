using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace UpgradeHelpers.WebMap.List
{
    public class VirtualListSerializerClient : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType.IsGenericType && typeof(IVirtualListSerializable).IsAssignableFrom(objectType);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			//The client will never send changes of the list to the server. 
			//So we don't need to read json from the client
			throw new NotImplementedException();
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			IVirtualListSerializable vlist = (IVirtualListSerializable)value;
			writer.WriteStartObject();
			writer.WritePropertyName("@arr");
			writer.WriteValue("1");
			writer.WritePropertyName("ltype");
			writer.WriteValue(vlist.ListType);
			writer.WritePropertyName("UniqueID");
			writer.WriteValue(vlist.UniqueID);
			writer.WritePropertyName("Count");
			writer.WriteValue(vlist.Count);
			writer.WritePropertyName("uids");
			writer.WriteStartArray();
            var type = vlist.GetType().GetGenericArguments()[0];
            foreach ( KeyValuePair<string, int> val in vlist.InitialPositionOfEachPage)
			{
				Page p = vlist.PageManager.LoadPage(val.Key);
				foreach (var item in p.GetStoredObjects())
				{
					LazyObject lazy = (LazyObject)item;
					if (lazy.TargetUniqueID != null)
					{
						writer.WriteValue(lazy.TargetUniqueID);
					}
					else
					{
                        //We have to validate if the type is not a Struct
                        //because the structs shouldn't go to client at this moment.
                        if (!(!type.IsEnum && !type.IsPrimitive && type.IsValueType && type != typeof(DateTime)))
                        {
                            writer.WriteValue(lazy.Target);
                        }
                    }
				}
			}
			writer.WriteEndArray();
			writer.WriteEndObject();
		}
	}
}
