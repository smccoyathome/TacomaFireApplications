using System;

namespace UpgradeHelpers.Helpers
{
	public class ColorTranslator
	{
		public static int ToOle(Color color)
		{
			//AIS-TODO: Code this to use OLE colors instead of just plain RGB.
			return Convert.ToInt32(color.Value.Substring(1, 6), 16);
		}

		public static UpgradeHelpers.Helpers.Color FromOle(int value)
		{
			//AIS-TODO: Code this instead of using System.Drawing.ColorTranslator
			//var c = System.Drawing.ColorTranslator.FromOle(value);
			//return UpgradeHelpers.Helpers.Color.FromArgb(c.R, c.G, c.B);
			int b = (value & 0xFF0000) >> 16;
			int g = (value & 0xFF00) >> 8;
			int r = (value & 0xFF);
			return Color.FromArgb(r, g, b);
		}

	}
}