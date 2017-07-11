using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UpgradeHelpers.WebMap.List
{
    /// <summary>
    /// Serializes list as JSON with a format like [type,count,{Page1UniqueID:StartIndex,...,PageNUniqueID:StartIndex}
    /// </summary>
    public class VirtualListSerializer : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return typeof(IVirtualListSerializable).IsAssignableFrom(objectType);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			IVirtualListSerializable vlist = (IVirtualListSerializable)existingValue;
            reader.Read();
            var typelist = (long)reader.Value;

            reader.Read();
            int count = (int)(long)reader.Value;

			vlist.ListType = (VirtualListTypeEnum)typelist;
			vlist.InitializeOperationHelper();
			vlist.PageUniqueIdOfTheIndexes = new List<string>();
			if (count > 0)
			{
                reader.Read();
                var dictToDeserialize = serializer.Deserialize<Dictionary<string, int>>(reader);
                dictToDeserialize = 
				vlist.InitialPositionOfEachPage = dictToDeserialize;
				for (int i = 0; i < dictToDeserialize.Values.Count; i++)
				{
					var current = dictToDeserialize.Values.ElementAt(i);
					int next;
					if (i + 1 < dictToDeserialize.Values.Count)
						next = dictToDeserialize.Values.ElementAt(i + 1);
					else
						next = count;
					for (var j = vlist.PageUniqueIdOfTheIndexes.Count; j < next; j++)
					{
						vlist.PageUniqueIdOfTheIndexes.Add(dictToDeserialize.Keys.ElementAt(i));
					}
				}
			}
			return vlist;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			IVirtualListSerializable vlist = (IVirtualListSerializable)value;
            Dictionary<string, int> dictToSerialize = vlist.InitialPositionOfEachPage;

            if (dictToSerialize.Count > 1) {
                dictToSerialize = dictToSerialize.GroupBy(k => k.Value)
				.Select(group => group.Last())
				.ToDictionary(pair => pair.Key, pair => pair.Value);
            }
			writer.WriteStartArray();
			writer.WriteValue(vlist.ListType);
			writer.WriteValue(vlist.Count);
			if (vlist.Count > 0)
			{
				serializer.Serialize(writer,dictToSerialize);
			}
			writer.WriteEndArray();
		}
	}
}
