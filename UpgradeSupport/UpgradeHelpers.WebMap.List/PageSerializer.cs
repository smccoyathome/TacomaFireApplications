using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.List
{
    public class PageSerializer : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return typeof(Page).IsAssignableFrom(objectType);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			Page page = (Page)existingValue;
			JObject jobj = JObject.Load(reader);
			JArray array = (JArray)jobj["@array"];
			page.Parent = jobj["Parent"].Value<string>();
            page.ParentType = jobj["ParentType"].Value<string>();
            foreach (var item in array)
			{
                if (item.Type == JTokenType.Float || item.Type == JTokenType.Integer)
                {
                    switch (page.ParentType)
                    {
                        case "System.Decimal":
                            page.Add(new LazyObject(item.Value<decimal>()));
                            break;
                        case "System.Single":
                            page.Add(new LazyObject(item.Value<float>()));
                            break;
                        case "System.Double":
                            page.Add(new LazyObject(item.Value<double>()));
                            break;
                        case "System.Int16":
                            page.Add(new LazyObject(item.Value<short>()));
                            break;
                        case "System.Int32":
                            page.Add(new LazyObject(item.Value<int>()));
                            break;
                        case "System.Int64":
                            page.Add(new LazyObject(item.Value<long>()));
                            break;
                        case "System.SByte":
                            page.Add(new LazyObject(item.Value<sbyte>()));
                            break;
                        case "System.UInt16":
                            page.Add(new LazyObject(item.Value<ushort>()));
                            break;
                        case "System.UInt32":
                            page.Add(new LazyObject(item.Value<uint>()));
                            break;
                        case "System.UInt64":
                            page.Add(new LazyObject(item.Value<ulong>()));
                            break;
                        default:
                            var item1 = (item.Type == JTokenType.Float) ? item.Value<float>() : item.Value<int>();
                            page.Add(new LazyObject(item1));
                            break;
                    }
                }   
                else if (item.Type == JTokenType.String)
                {
                    var temp = item.Value<string>();
                    if (temp.StartsWith("_@"))
                    {
                        page.Add(new LazyObject(temp.Remove(0, 2), true));
                    }
                    else
                    {
                        page.Add(new LazyObject(temp));
                    }
                }
                else if (item.Type == JTokenType.Null)
                {
                    page.Add(new LazyObject(null));
                }
                else if (item.Type == JTokenType.Object)
                {
                    var typeFullName = jobj["StructType"].Value<string>();
                    var structType = Type.GetType(typeFullName);
                    var deserializedObject = item.ToObject(structType);
                    page.Add(new LazyObject(deserializedObject));
                }
                else if(item.Type == JTokenType.Date)
                {
                    page.Add(new LazyObject(item.Value<DateTime>()));
                }
			}
			return page;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			Page pageToBeSerialized = (Page)value;
            string structType = "";
			writer.WriteStartObject();
			writer.WritePropertyName("Parent");
			var parent = pageToBeSerialized.Parent as IStateObject;
			if (parent == null)
				writer.WriteValue(pageToBeSerialized.Parent);
			else
				writer.WriteValue(parent.UniqueID);
            writer.WritePropertyName("ParentType");
            writer.WriteValue(pageToBeSerialized.ParentType);
            writer.WritePropertyName("@array");
			writer.WriteStartArray();
			foreach (var item in pageToBeSerialized.GetStoredObjectsSafe())
			{
				LazyObject lazy = (LazyObject)item;
				if(lazy.TargetUniqueID != null)
				{
					writer.WriteValue(lazy.TargetUniqueID);
				}
				else
				{
					var i = lazy.Target;
					if (i != null)
					{
                        var type = i.GetType();
                        if (type == typeof(String))
							writer.WriteValue("_@" + lazy.Target);
                        else if (!type.IsEnum && !type.IsPrimitive && type.IsValueType && type != typeof(DateTime))
                        {
                            //This is a struct
                            serializer.Serialize(writer, lazy.Target, type);
                            structType = type.AssemblyQualifiedName;
                        }
                        else
							writer.WriteValue(lazy.Target);
					}else
					{
						writer.WriteNull();
					}
				}
			}
			writer.WriteEndArray();
            if(structType != "")
            {
                writer.WritePropertyName("StructType");
                writer.WriteValue(structType);
            }
			writer.WriteEndObject();
		}
	}
}
