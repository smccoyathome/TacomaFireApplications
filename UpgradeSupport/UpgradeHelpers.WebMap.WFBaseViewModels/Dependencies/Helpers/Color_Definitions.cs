using Newtonsoft.Json;
using System;

namespace UpgradeHelpers.Helpers
{

	public class ColorJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Color).IsAssignableFrom(objectType) || objectType.GetType() == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Color target = null;
            if (reader.TokenType == JsonToken.Null)
                return null;

            if (reader.TokenType == JsonToken.StartObject)
            {
                reader.Read();
                if (reader.TokenType == JsonToken.PropertyName)                
                {
                    var propName = reader.Value as string;
                    if (!string.IsNullOrEmpty(propName) && propName == "Value")
                    {
                        reader.Read();
                        if (reader.TokenType == JsonToken.String)
                        {
                            target = new Color(reader.Value.ToString());
                        }
                        reader.Read();
                        if (reader.TokenType != JsonToken.EndObject)
                        {
                            while (reader.Read());
                        }
                    }
                }
            }
            else if (reader.TokenType == JsonToken.String)
            {
                target = new Color(reader.Value.ToString());
            }
            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Color v = (Color)value;
            writer.WriteStartObject();
            writer.WritePropertyName("Value");
            writer.WriteValue(v.Value);
            writer.WriteEndObject();
        }
    }

    [JsonConverter(typeof(ColorJsonConverter))]
	public partial class Color
	{
        public static readonly Color Empty = new Color(0, KnownColor.UnKnown);
        public static readonly Color Black = new Color("#000000", "Black");
        public static readonly Color Navy = new Color("#000080", "Navy");
        public static readonly Color DarkBlue = new Color("#00008B", "DarkBlue");
        public static readonly Color MediumBlue = new Color("#0000CD", "MediumBlue");
        public static readonly Color Blue = new Color("#0000FF", "Blue");
        public static readonly Color DarkGreen = new Color("#006400", "DarkGreen");
        public static readonly Color Green = new Color("#008000", "Green");
        public static readonly Color Teal = new Color("#008080", "Teal");
        public static readonly Color DarkCyan = new Color("#008B8B", "DarkCyan");
        public static readonly Color DeepSkyBlue = new Color("#00BFFF", "DeepSkyBlue");
        public static readonly Color DarkTurquoise = new Color("#00CED1", "DarkTurquoise");
        public static readonly Color MediumSpringGreen = new Color("#00FA9A", "MediumSpringGreen");
        public static readonly Color Lime = new Color("#00FF00", "Lime");
        public static readonly Color SpringGreen = new Color("#00FF7F", "SpringGreen");
        public static readonly Color Cyan = new Color("#00FFFF", "Cyan");
        public static readonly Color Aqua = new Color("#00FFFF", "Aqua");
        public static readonly Color MidnightBlue = new Color("#191970", "MidnightBlue");
        public static readonly Color DodgerBlue = new Color("#1E90FF", "DodgerBlue");
        public static readonly Color LightSeaGreen = new Color("#20B2AA", "LightSeaGreen");
        public static readonly Color ForestGreen = new Color("#228B22", "ForestGreen");
        public static readonly Color SeaGreen = new Color("#2E8B57", "SeaGreen");
        public static readonly Color DarkSlateGray = new Color("#2F4F4F", "DarkSlateGray");
        public static readonly Color DarkSlateGrey = new Color("#2F4F4F", "DarkSlateGrey");
        public static readonly Color LimeGreen = new Color("#32CD32", "LimeGreen");
        public static readonly Color MediumSeaGreen = new Color("#3CB371", "MediumSeaGreen");
        public static readonly Color Turquoise = new Color("#40E0D0", "Turquoise");
        public static readonly Color RoyalBlue = new Color("#4169E1", "RoyalBlue");
        public static readonly Color SteelBlue = new Color("#4682B4", "SteelBlue");
        public static readonly Color DarkSlateBlue = new Color("#483D8B", "DarkSlateBlue");
        public static readonly Color MediumTurquoise = new Color("#48D1CC", "MediumTurquoise");
        public static readonly Color Indigo = new Color("#4B0082", "Indigo");
        public static readonly Color DarkOliveGreen = new Color("#556B2F", "DarkOliveGreen");
        public static readonly Color CadetBlue = new Color("#5F9EA0", "CadetBlue");
        public static readonly Color CornflowerBlue = new Color("#6495ED", "CornflowerBlue");
        public static readonly Color MediumAquaMarine = new Color("#66CDAA", "MediumAquaMarine");
        public static readonly Color DimGray = new Color("#696969", "DimGray");
        public static readonly Color DimGrey = new Color("#696969", "DimGrey");
        public static readonly Color SlateBlue = new Color("#6A5ACD", "SlateBlue");
        public static readonly Color OliveDrab = new Color("#6B8E23", "OliveDrab");
        public static readonly Color SlateGray = new Color("#708090", "SlateGray");
        public static readonly Color SlateGrey = new Color("#708090", "SlateGrey");
        public static readonly Color LightSlateGray = new Color("#778899", "LightSlateGray");
        public static readonly Color LightSlateGrey = new Color("#778899", "LightSlateGrey");
        public static readonly Color MediumSlateBlue = new Color("#7B68EE", "MediumSlateBlue");
        public static readonly Color LawnGreen = new Color("#7CFC00", "LawnGreen");
        public static readonly Color Chartreuse = new Color("#7FFF00", "Chartreuse");
        public static readonly Color Aquamarine = new Color("#7FFFD4", "Aquamarine");
        public static readonly Color Maroon = new Color("#800000", "Maroon");
        public static readonly Color Purple = new Color("#800080", "Purple");
        public static readonly Color Olive = new Color("#808000", "Olive");
        public static readonly Color Gray = new Color("#808080", "Gray");
        public static readonly Color Grey = new Color("#808080", "Grey");
        public static readonly Color SkyBlue = new Color("#87CEEB", "SkyBlue");
        public static readonly Color LightSkyBlue = new Color("#87CEFA", "LightSkyBlue");
        public static readonly Color BlueViolet = new Color("#8A2BE2", "BlueViolet");
        public static readonly Color DarkRed = new Color("#8B0000", "DarkRed");
        public static readonly Color DarkMagenta = new Color("#8B008B", "DarkMagenta");
        public static readonly Color SaddleBrown = new Color("#8B4513", "SaddleBrown");
        public static readonly Color DarkSeaGreen = new Color("#8FBC8F", "DarkSeaGreen");
        public static readonly Color LightGreen = new Color("#90EE90", "LightGreen");
        public static readonly Color MediumPurple = new Color("#9370D8", "MediumPurple");
        public static readonly Color DarkViolet = new Color("#9400D3", "DarkViolet");
        public static readonly Color PaleGreen = new Color("#98FB98", "PaleGreen");
        public static readonly Color DarkOrchid = new Color("#9932CC", "DarkOrchid");
        public static readonly Color YellowGreen = new Color("#9ACD32", "YellowGreen");
        public static readonly Color Sienna = new Color("#A0522D", "Sienna");
        public static readonly Color Brown = new Color("#A52A2A", "Brown");
        public static readonly Color DarkGray = new Color("#A9A9A9", "DarkGray");
        public static readonly Color DarkGrey = new Color("#A9A9A9", "DarkGrey");
        public static readonly Color LightBlue = new Color("#ADD8E6", "LightBlue");
        public static readonly Color GreenYellow = new Color("#ADFF2F", "GreenYellow");
        public static readonly Color PaleTurquoise = new Color("#AFEEEE", "PaleTurquoise");
        public static readonly Color LightSteelBlue = new Color("#B0C4DE", "LightSteelBlue");
        public static readonly Color PowderBlue = new Color("#B0E0E6", "PowderBlue");
        public static readonly Color FireBrick = new Color("#B22222", "FireBrick");
        public static readonly Color DarkGoldenrod = new Color("#B8860B", "DarkGoldenrod");
        public static readonly Color MediumOrchid = new Color("#BA55D3", "MediumOrchid");
        public static readonly Color RosyBrown = new Color("#BC8F8F", "RosyBrown");
        public static readonly Color DarkKhaki = new Color("#BDB76B", "DarkKhaki");
        public static readonly Color Silver = new Color("#C0C0C0", "Silver");
        public static readonly Color MediumVioletRed = new Color("#C71585", "MediumVioletRed");
        public static readonly Color IndianRed = new Color("#CD5C5C", "IndianRed");
        public static readonly Color Peru = new Color("#CD853F", "Peru");
        public static readonly Color Chocolate = new Color("#D2691E", "Chocolate");
        public static readonly Color Tan = new Color("#D2B48C", "Tan");
        public static readonly Color LightGray = new Color("#D3D3D3", "LightGray");
        public static readonly Color LightGrey = new Color("#D3D3D3", "LightGrey");
        public static readonly Color PaleVioletRed = new Color("#D87093", "PaleVioletRed");
        public static readonly Color Thistle = new Color("#D8BFD8", "Thistle");
        public static readonly Color Orchid = new Color("#DA70D6", "Orchid");
        public static readonly Color Goldenrod = new Color("#DAA520", "Goldenrod");
        public static readonly Color Crimson = new Color("#DC143C", "Crimson");
        public static readonly Color Gainsboro = new Color("#DCDCDC", "Gainsboro");
        public static readonly Color Plum = new Color("#DDA0DD", "Plum");
        public static readonly Color BurlyWood = new Color("#DEB887", "BurlyWood");
        public static readonly Color LightCyan = new Color("#E0FFFF", "LightCyan");
        public static readonly Color Lavender = new Color("#E6E6FA", "Lavender");
        public static readonly Color DarkSalmon = new Color("#E9967A", "DarkSalmon");
        public static readonly Color Violet = new Color("#EE82EE", "Violet");
        public static readonly Color PaleGoldenRod = new Color("#EEE8AA", "PaleGoldenRod");
        public static readonly Color LightCoral = new Color("#F08080", "LightCoral");
        public static readonly Color Khaki = new Color("#F0E68C", "Khaki");
        public static readonly Color AliceBlue = new Color("#F0F8FF", "AliceBlue");
        public static readonly Color HoneyDew = new Color("#F0FFF0", "HoneyDew");
        public static readonly Color Azure = new Color("#F0FFFF", "Azure");
        public static readonly Color SandyBrown = new Color("#F4A460", "SandyBrown");
        public static readonly Color Wheat = new Color("#F5DEB3", "Wheat");
        public static readonly Color Beige = new Color("#F5F5DC", "Beige");
        public static readonly Color WhiteSmoke = new Color("#F5F5F5", "WhiteSmoke");
        public static readonly Color MintCream = new Color("#F5FFFA", "MintCream");
        public static readonly Color GhostWhite = new Color("#F8F8FF", "GhostWhite");
        public static readonly Color Salmon = new Color("#FA8072", "Salmon");
        public static readonly Color AntiqueWhite = new Color("#FAEBD7", "AntiqueWhite");
        public static readonly Color Linen = new Color("#FAF0E6", "Linen");
        public static readonly Color LightGoldenRodYellow = new Color("#FAFAD2", "LightGoldenRodYellow");
        public static readonly Color OldLace = new Color("#FDF5E6", "OldLace");
        public static readonly Color Red = new Color("#FF0000", "Red");
        public static readonly Color Fuchsia = new Color("#FF00FF", "Fuchsia");
        public static readonly Color Magenta = new Color("#FF00FF", "Magenta");
        public static readonly Color DeepPink = new Color("#FF1493", "DeepPink");
        public static readonly Color OrangeRed = new Color("#FF4500", "OrangeRed");
        public static readonly Color Tomato = new Color("#FF6347", "Tomato");
        public static readonly Color HotPink = new Color("#FF69B4", "HotPink");
        public static readonly Color Coral = new Color("#FF7F50", "Coral");
        public static readonly Color DarkOrange = new Color("#FF8C00", "DarkOrange");
        public static readonly Color LightSalmon = new Color("#FFA07A", "LightSalmon");
        public static readonly Color Orange = new Color("#FFA500", "Orange");
        public static readonly Color LightPink = new Color("#FFB6C1", "LightPink");
        public static readonly Color Pink = new Color("#FFC0CB", "Pink");
        public static readonly Color Gold = new Color("#FFD700", "Gold");
        public static readonly Color PeachPuff = new Color("#FFDAB9", "PeachPuff");
        public static readonly Color NavajoWhite = new Color("#FFDEAD", "NavajoWhite");
        public static readonly Color Moccasin = new Color("#FFE4B5", "Moccasin");
        public static readonly Color Bisque = new Color("#FFE4C4", "Bisque");
        public static readonly Color MistyRose = new Color("#FFE4E1", "MistyRose");
        public static readonly Color BlanchedAlmond = new Color("#FFEBCD", "BlanchedAlmond");
        public static readonly Color PapayaWhip = new Color("#FFEFD5", "PapayaWhip");
        public static readonly Color LavenderBlush = new Color("#FFF0F5", "LavenderBlush");
        public static readonly Color SeaShell = new Color("#FFF5EE", "SeaShell");
        public static readonly Color Cornsilk = new Color("#FFF8DC", "Cornsilk");
        public static readonly Color LemonChiffon = new Color("#FFFACD", "LemonChiffon");
        public static readonly Color FloralWhite = new Color("#FFFAF0", "FloralWhite");
        public static readonly Color Snow = new Color("#FFFAFA", "Snow");
        public static readonly Color Yellow = new Color("#FFFF00", "Yellow");
        public static readonly Color LightYellow = new Color("#FFFFE0", "LightYellow");
        public static readonly Color Ivory = new Color("#FFFFF0", "Ivory");
        public static readonly Color White = new Color("#FFFFFF", "White");
        public static readonly Color Transparent = new Color(-2, KnownColor.Transparent);



        public Color(string hex) : this(hex, null)
        {
		}

        private Color(string hex, string name)
        {
            knownColor = (short)KnownColor.Empty;
            if (string.IsNullOrEmpty(hex))
            {
                
            }
            else 
            if (hex.Length > 1 && hex[0] == '#')
            {
                this.value = int.Parse(hex.Substring(1), System.Globalization.NumberStyles.HexNumber);
                knownColor = (short)KnownColor.GivenName;
            }
            else
            {
                if (hex == "transparent")
                {
                    value = -2;
                    knownColor = (short)KnownColor.Transparent;
                }
                else
                {
                    var parts = hex.Split(',');
                    byte red = (byte)int.Parse(parts[0]);
                    byte green = (byte)int.Parse(parts[1]);
                    byte blue = (byte)int.Parse(parts[2]);
                    value = MakeArgb(0, red, green, blue);
                    knownColor = (short)KnownColor.GivenName;
                }
            }
        }


		public string Value
		{
			get
			{
                if (knownColor == (short)KnownColor.Empty)
                {
                    return String.Empty;
                }
                else if (knownColor == (short)KnownColor.Transparent || value == -2)
                {
                    return "transparent";
                }
                else if (knownColor == (short)KnownColor.GivenName || IsKnownColor)
                {
                    return string.Concat("#", value.ToString("X6"));
                }
                return String.Empty;
            }
		}

		public static implicit operator Color(string color)
		{
			return new Color(color);
		}

		public static bool operator ==(Color color1, Color color2)
		{
			if (Object.Equals(null,color1) && Object.Equals(null, color2))
            {
                return true;
            }    
			if (Object.Equals(null, color1) || Object.Equals(null, color2))
                return false;
			return color1.Equals(color2);
		}

		public static bool operator !=(Color color1, Color color2)
		{
			return !(color1 == color2);
		}

		public static Color FromArgb(int red, int green, int blue)
		{
			return new Color(MakeArgb(0,(byte)red,(byte)green,(byte)blue),KnownColor.GivenName);
		}

        public static Color FromHex(string hex)
        {
           /* var fields = typeof(Color).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
            foreach (var f in fields)
            {
                if (f.FieldType != typeof(Color))
                    continue;

                var c = f.GetValue(null) as Color;
                if (c.Value.Equals(hex, StringComparison.OrdinalIgnoreCase))
                    return c;
            }*/

            return new Color(hex); //, "ff" + hex.Replace("#", "")
        }

		protected bool Equals(Color other)
		{
            return other.value == this.value;
		}

		public override bool Equals(object obj)
		{
			if ( obj == null ) return false;
			if (ReferenceEquals(this, obj)) return true;
			var other = obj as Color;
			return other != null && Equals(other);
		}

		public override int GetHashCode()
		{
			return value.GetHashCode();
		}
	}
}
