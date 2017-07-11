using System;

namespace UpgradeHelpers.Helpers
{
	public static class Screen
	{
		/// <summary>
		/// Gets screen bounds from the Web.Config appSettings SCREEN_SIZE or defaults to 800,600
		/// </summary>
		/// <returns></returns>
		public static Rectangle Bounds
		{
			get
			{
				var screenSize = System.Configuration.ConfigurationManager.AppSettings["SCREEN_SIZE"] ?? "800,600";
				var heightAndWidth = screenSize.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				var heightStr = heightAndWidth.Length > 0 ? heightAndWidth[0] : "800";
				var widthStr = heightAndWidth.Length > 1 ? heightAndWidth[1] : "600";
				int height;
				int.TryParse(heightStr, out height);
				int width;
				int.TryParse(widthStr, out width);
				return new Rectangle { Height = height, Width = width };

			}
			
		}
	}
}
