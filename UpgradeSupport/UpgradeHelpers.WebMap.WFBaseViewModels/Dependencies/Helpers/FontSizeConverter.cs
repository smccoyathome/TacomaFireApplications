using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeHelpers.WebMap.WFBaseViewModels.Dependencies.Helpers
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    class FontSizeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {

            var size = (float)value;
            if (size > 8.25f)
            {
                writer.WriteValue(size * 72f / 60f + "px");
            }
            else
            {
                writer.WriteNull();
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return 8.25f;
            }
            else
            {
                var pixelSize = reader.Value.ToString();
                if (pixelSize.EndsWith("px"))
                {
                    pixelSize = pixelSize.Substring(0, pixelSize.Length - 2);
                }
                var size = float.Parse(pixelSize);
                return size * 60f / 72f;
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(float));
        }
    }
}
