using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace UpgradeHelpers.Helpers
{
	public partial class Color
    {
        private readonly Int32 value;
        private readonly short knownColor;

        public Color(Int32 value, KnownColor knownColor = KnownColor.GivenName)
        {
            this.value = value;
            this.knownColor = (short)knownColor;
        }

        public static Color FromArgb(int alpha, int red, int green, int blue)
        {
            Color.CheckByte(alpha, "alpha");
            Color.CheckByte(red, "red");
            Color.CheckByte(green, "green");
            Color.CheckByte(blue, "blue");
            return new Color(Color.MakeArgb((byte)alpha, (byte)red, (byte)green, (byte)blue),KnownColor.GivenName);
        }

        [JsonIgnore]
        public string Name
        {
            get
            {
                string name;
                if (Colors.TryGetValue(value,out name))
                {
                    return name;
                }
                return "ff" + value.ToString("X");
            }
        }

        [JsonIgnore]
        public bool IsEmpty
        {
            get
            {
                return (int)this.value == -1;
            }
        }

        [JsonIgnore]

        public bool IsKnownColor
        {
            get
            {
                return knownColor > 0;
            }
        }

        
        public int ToArgb()
        {
            return (int)this.value;
        }

        public bool IsSystemColor
        {
            get
            {
                if (!this.IsKnownColor)
                    return false;
                if ((int)this.knownColor > 26)
                    return (int)this.knownColor > 167;
                return true;
            }
        }

        internal bool IsNamedColor
        {
            get
            {
                return IsKnownColor;
            }
        }

        [JsonIgnore]
        public byte R
        {
            get
            {
                return (byte)((ulong)(this.value >> 16) & (UInt32)byte.MaxValue);
            }
        }

        [JsonIgnore]
        public byte G
        {
            get
            {
                return (byte)((ulong)(this.value >> 8) & (ulong)byte.MaxValue);
            }
        }

        [JsonIgnore]
        public byte B
        {
            get
            {
                return (byte)((ulong)this.value & (ulong)byte.MaxValue);
            }
        }

        [JsonIgnore]
        public byte A
        {
            get
            {
                return (byte)((ulong)(this.value >> 24) & (ulong)byte.MaxValue);
            }
        }

        public static Color FromName(string name)
        {
            var fields = typeof(Color).GetFields(BindingFlags.Public |BindingFlags.Static);
            foreach (var f in fields)
            {
                if (f.FieldType != typeof(Color))
                    continue;

                if (f.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    return f.GetValue(null) as Color;
            }

            return Color.Empty;
        }

        private static void CheckByte(int value, string name)
        {
            if (value < 0 || value > (int)byte.MaxValue)
                throw new ArgumentException(name);
        }

        private static Int32 MakeArgb(byte alpha, byte red, byte green, byte blue)
        {
            return (Int32) ((red << 16 | green << 8 | blue | alpha << 24) & UInt32.MaxValue);
        }


        private static Dictionary<Int32,string> Colors
        {
            get
            {
                if (Color.colorConstants == null)
                {
                    lock (Color.ColorConstantsLock)
                    {
                        if (Color.colorConstants == null)
                        {
                            var dict = new Dictionary<Int32, string>();
                            Color.FillConstants(dict, typeof(Color));
                            Color.colorConstants = dict;
                        }
                    }
                }
                return Color.colorConstants;
            }
        }

        private static string ColorConstantsLock = "colorConstants";
        private static Dictionary<Int32,string> colorConstants;
        private static Dictionary<Int32,string> systemColorConstants;
        private static string SystemColorConstantsLock = "systemColorConstants";
        private static Dictionary<Int32, string> SystemColors
        {
            get
            {
                if (Color.systemColorConstants == null)
                {
                    lock (Color.SystemColorConstantsLock)
                    {
                        if (Color.systemColorConstants == null)
                        {
                            var dict = new Dictionary<Int32, string>();
                            Color.FillConstants(dict, typeof(SystemColors));
                            Color.systemColorConstants = dict;
                        }
                    }
                }
                return Color.systemColorConstants;
            }
        }

        private static void FillConstants(IDictionary<Int32,string> hash, Type enumType)
        {
            foreach (var field in enumType.GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                if (field.FieldType == typeof(Color))
                {
                    var value = (Color)field.GetValue(null);
                    hash[value.value] = field.Name;
                }
            }
        }
        internal static class KnownColorTable
        {
            private static int[] colorTable;

            private static void EnsureColorTable()
            {
                if (KnownColorTable.colorTable != null)
                    return;
                KnownColorTable.InitColorTable();
            }

            public static int KnownColorToArgb(KnownColor color)
            {
                KnownColorTable.EnsureColorTable();
                if (color <= KnownColor.MenuHighlight)
                    return KnownColorTable.colorTable[(int)color];
                return 0;
            }

            private static int SystemColorToArgb(int index)
            {
                return KnownColorTable.FromWin32Value(SafeNativeMethods.GetSysColor(index));
                throw new NotImplementedException();
            }

            private static int Encode(int alpha, int red, int green, int blue)
            {
                return red << 16 | green << 8 | blue | alpha << 24;
            }

            private static int FromWin32Value(int value)
            {
                return KnownColorTable.Encode((int)byte.MaxValue, value & (int)byte.MaxValue, value >> 8 & (int)byte.MaxValue, value >> 16 & (int)byte.MaxValue);
            }

            private static void UpdateSystemColors(int[] colorTable)
            {
                colorTable[1] = KnownColorTable.SystemColorToArgb(10);
                colorTable[2] = KnownColorTable.SystemColorToArgb(2);
                colorTable[3] = KnownColorTable.SystemColorToArgb(9);
                colorTable[4] = KnownColorTable.SystemColorToArgb(12);
                colorTable[168] = KnownColorTable.SystemColorToArgb(15);
                colorTable[169] = KnownColorTable.SystemColorToArgb(20);
                colorTable[170] = KnownColorTable.SystemColorToArgb(16);
                colorTable[5] = KnownColorTable.SystemColorToArgb(15);
                colorTable[6] = KnownColorTable.SystemColorToArgb(16);
                colorTable[7] = KnownColorTable.SystemColorToArgb(21);
                colorTable[8] = KnownColorTable.SystemColorToArgb(22);
                colorTable[9] = KnownColorTable.SystemColorToArgb(20);
                colorTable[10] = KnownColorTable.SystemColorToArgb(18);
                colorTable[11] = KnownColorTable.SystemColorToArgb(1);
                colorTable[171] = KnownColorTable.SystemColorToArgb(27);
                colorTable[172] = KnownColorTable.SystemColorToArgb(28);
                colorTable[12] = KnownColorTable.SystemColorToArgb(17);
                colorTable[13] = KnownColorTable.SystemColorToArgb(13);
                colorTable[14] = KnownColorTable.SystemColorToArgb(14);
                colorTable[15] = KnownColorTable.SystemColorToArgb(26);
                colorTable[16] = KnownColorTable.SystemColorToArgb(11);
                colorTable[17] = KnownColorTable.SystemColorToArgb(3);
                colorTable[18] = KnownColorTable.SystemColorToArgb(19);
                colorTable[19] = KnownColorTable.SystemColorToArgb(24);
                colorTable[20] = KnownColorTable.SystemColorToArgb(23);
                colorTable[21] = KnownColorTable.SystemColorToArgb(4);
                colorTable[173] = KnownColorTable.SystemColorToArgb(30);
                colorTable[174] = KnownColorTable.SystemColorToArgb(29);
                colorTable[22] = KnownColorTable.SystemColorToArgb(7);
                colorTable[23] = KnownColorTable.SystemColorToArgb(0);
                colorTable[24] = KnownColorTable.SystemColorToArgb(5);
                colorTable[25] = KnownColorTable.SystemColorToArgb(6);
                colorTable[26] = KnownColorTable.SystemColorToArgb(8);
            }

            private static void InitColorTable()
            {
                int[] colorTable = new int[175];
                SystemEvents.UserPreferenceChanging += new UserPreferenceChangingEventHandler(KnownColorTable.OnUserPreferenceChanging);
                KnownColorTable.UpdateSystemColors(colorTable);
                colorTable[27] = 16777215;
                colorTable[28] = -984833;
                colorTable[29] = -332841;
                colorTable[30] = -16711681;
                colorTable[31] = -8388652;
                colorTable[32] = -983041;
                colorTable[33] = -657956;
                colorTable[34] = -6972;
                colorTable[35] = -16777216;
                colorTable[36] = -5171;
                colorTable[37] = -16776961;
                colorTable[38] = -7722014;
                colorTable[39] = -5952982;
                colorTable[40] = -2180985;
                colorTable[41] = -10510688;
                colorTable[42] = -8388864;
                colorTable[43] = -2987746;
                colorTable[44] = -32944;
                colorTable[45] = -10185235;
                colorTable[46] = -1828;
                colorTable[47] = -2354116;
                colorTable[48] = -16711681;
                colorTable[49] = -16777077;
                colorTable[50] = -16741493;
                colorTable[51] = -4684277;
                colorTable[52] = -5658199;
                colorTable[53] = -16751616;
                colorTable[54] = -4343957;
                colorTable[55] = -7667573;
                colorTable[56] = -11179217;
                colorTable[57] = -29696;
                colorTable[58] = -6737204;
                colorTable[59] = -7667712;
                colorTable[60] = -1468806;
                colorTable[61] = -7357301;
                colorTable[62] = -12042869;
                colorTable[63] = -13676721;
                colorTable[64] = -16724271;
                colorTable[65] = -7077677;
                colorTable[66] = -60269;
                colorTable[67] = -16728065;
                colorTable[68] = -9868951;
                colorTable[69] = -14774017;
                colorTable[70] = -5103070;
                colorTable[71] = -1296;
                colorTable[72] = -14513374;
                colorTable[73] = -65281;
                colorTable[74] = -2302756;
                colorTable[75] = -460545;
                colorTable[76] = -10496;
                colorTable[77] = -2448096;
                colorTable[78] = -8355712;
                colorTable[79] = -16744448;
                colorTable[80] = -5374161;
                colorTable[81] = -983056;
                colorTable[82] = -38476;
                colorTable[83] = -3318692;
                colorTable[84] = -11861886;
                colorTable[85] = -16;
                colorTable[86] = -989556;
                colorTable[87] = -1644806;
                colorTable[88] = -3851;
                colorTable[89] = -8586240;
                colorTable[90] = -1331;
                colorTable[91] = -5383962;
                colorTable[92] = -1015680;
                colorTable[93] = -2031617;
                colorTable[94] = -329006;
                colorTable[95] = -2894893;
                colorTable[96] = -7278960;
                colorTable[97] = -18751;
                colorTable[98] = -24454;
                colorTable[99] = -14634326;
                colorTable[100] = -7876870;
                colorTable[101] = -8943463;
                colorTable[102] = -5192482;
                colorTable[103] = -32;
                colorTable[104] = -16711936;
                colorTable[105] = -13447886;
                colorTable[106] = -331546;
                colorTable[107] = -65281;
                colorTable[108] = -8388608;
                colorTable[109] = -10039894;
                colorTable[110] = -16777011;
                colorTable[111] = -4565549;
                colorTable[112] = -7114533;
                colorTable[113] = -12799119;
                colorTable[114] = -8689426;
                colorTable[115] = -16713062;
                colorTable[116] = -12004916;
                colorTable[117] = -3730043;
                colorTable[118] = -15132304;
                colorTable[119] = -655366;
                colorTable[120] = -6943;
                colorTable[121] = -6987;
                colorTable[122] = -8531;
                colorTable[123] = -16777088;
                colorTable[124] = -133658;
                colorTable[125] = -8355840;
                colorTable[126] = -9728477;
                colorTable[(int)sbyte.MaxValue] = -23296;
                colorTable[128] = -47872;
                colorTable[129] = -2461482;
                colorTable[130] = -1120086;
                colorTable[131] = -6751336;
                colorTable[132] = -5247250;
                colorTable[133] = -2396013;
                colorTable[134] = -4139;
                colorTable[135] = -9543;
                colorTable[136] = -3308225;
                colorTable[137] = -16181;
                colorTable[138] = -2252579;
                colorTable[139] = -5185306;
                colorTable[140] = -8388480;
                colorTable[141] = -65536;
                colorTable[142] = -4419697;
                colorTable[143] = -12490271;
                colorTable[144] = -7650029;
                colorTable[145] = -360334;
                colorTable[146] = -744352;
                colorTable[147] = -13726889;
                colorTable[148] = -2578;
                colorTable[149] = -6270419;
                colorTable[150] = -4144960;
                colorTable[151] = -7876885;
                colorTable[152] = -9807155;
                colorTable[153] = -9404272;
                colorTable[154] = -1286;
                colorTable[155] = -16711809;
                colorTable[156] = -12156236;
                colorTable[157] = -2968436;
                colorTable[158] = -16744320;
                colorTable[159] = -2572328;
                colorTable[160] = -40121;
                colorTable[161] = -12525360;
                colorTable[162] = -1146130;
                colorTable[163] = -663885;
                colorTable[164] = -1;
                colorTable[165] = -657931;
                colorTable[166] = -256;
                colorTable[167] = -6632142;
                KnownColorTable.colorTable = colorTable;
            }

            private static void OnUserPreferenceChanging(object sender, UserPreferenceChangingEventArgs e)
            {
                if (e.Category != UserPreferenceCategory.Color || KnownColorTable.colorTable == null)
                    return;
                KnownColorTable.UpdateSystemColors(KnownColorTable.colorTable);
            }

        }

        public static Color FromKnownColor(KnownColor knownColor)
        {
            return Color.FromName(knownColor.ToString());
        }

        public int GetBrightness()
        {
			return 0;
        }

        public static Color FromArgb(int alpha, Color baseColor)
        {
			return baseColor;
        }

        public static Color FromArgb(int argb)
        {
            int r = (argb >> 16) & 0xFF;
            int g = (argb >> 8) & 0xFF;
            int b = (argb >> 0) & 0xFF;
            int a = (argb >> 24) & 0xFF;

            return Color.FromArgb(a, r, g, b);
        }

    }
}
