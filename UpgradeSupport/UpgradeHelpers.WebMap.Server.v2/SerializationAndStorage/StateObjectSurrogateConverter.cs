using System;
using Newtonsoft.Json;
using System.Diagnostics;

namespace UpgradeHelpers.WebMap.Server
{
    public class StateObjectSurrogateConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var surrogate = (StateObjectSurrogate) value;
            writer.WriteStartObject();
            writer.WritePropertyName("UniqueID");
            writer.WriteValue(surrogate.UniqueID);
            writer.WritePropertyName("$type");
            writer.WriteValue("StateObjectSurrogate");
            writer.WritePropertyName("SurrogateType");
            writer.WriteValue(surrogate.Value.GetType().AssemblyQualifiedName);
            writer.WritePropertyName("Refs");
            writer.WriteStartArray();
#if DEBUG
            int refsCount = 0;
#endif
            foreach (var v in surrogate.objectRefs)
            {
                if (StateManager.AllBranchesAttached(v.UniqueID))
                {
                    writer.WriteValue(v.UniqueID);
#if DEBUG
                    refsCount++;
#endif
                }
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
#if DEBUG
            Debug.Assert(refsCount > 0, "A surrogate must have at least one attached reference");
#endif
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
           
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof (StateObjectSurrogate) == objectType;
        }
    }
}