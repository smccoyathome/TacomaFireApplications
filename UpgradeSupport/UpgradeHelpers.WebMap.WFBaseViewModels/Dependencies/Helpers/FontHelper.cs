using System;
using UpgradeHelpers.Helpers;

namespace UpgradeHelpers.Extensions
{
	/// <summary>
	/// The FontHelper provides functionality for Fonts.
	/// </summary>
	public static class FontHelper
	{
		/// <summary>
		/// Gets a copy of the font, changing selected attributes.
		/// </summary>
		/// <param name="font">The font that will serve as a base for the copy.</param>
		/// <param name="name">The font name</param>
		/// <param name="size">The font size</param>
		/// <param name="gdiCharSet">The gdiCharSet to use</param>
		/// <param name="bold">Indicate if the font will be bold</param>
		/// <param name="italic">Indicate if the font will be italic</param>
		/// <param name="underline">Indicate if the font will be underlined</param>
		/// <param name="strikeout">Indicate if the font will be strikeout</param>
		/// <returns>A copy of the font, with selected attributes changed.</returns>

		public static Font Change(this Font font, string name = null, float? size = null, byte? gdiCharSet = null, bool? bold = null, bool? italic = null, bool? underline = null, bool? strikeout = null)
		{
			FontStyle style = font.Style;
			if (bold.HasValue) style = bold.Value ? style | FontStyle.Bold : style & ~FontStyle.Bold;
			if (italic.HasValue) style = italic.Value ? style | FontStyle.Italic : style & ~FontStyle.Italic;
			var currentDecorations = font.Decoration;
			var result = StaticContainer.Instance.Resolve<Font>(name == null ? font.Name : name, size.HasValue ? size.Value : font.Size, style);
			if (underline.HasValue) currentDecorations = appendStyle(currentDecorations, "underline", underline.Value);
			if (strikeout.HasValue) currentDecorations = appendStyle(currentDecorations, "line-through", strikeout.Value);
			result.Decoration = currentDecorations;
			return result;
		}

		private static string appendStyle(string decorations, string decoration, bool add)
		{
			if (add)
			{
				decorations = decorations != null ? decorations.Replace("none", "") : string.Empty;
				return decorations + " " + decoration;
			}
			decorations = decorations.Replace(decoration, "");
			if (String.IsNullOrWhiteSpace(decorations))
			{
				decorations = "none";
			}
			return decorations;

		}
	}
}
