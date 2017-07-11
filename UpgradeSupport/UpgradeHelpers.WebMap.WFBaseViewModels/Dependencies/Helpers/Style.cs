using System;
using UpgradeHelpers.Reports.Helpers;


namespace UpgradeHelpers.Helpers
{
	public class Style 
    {

        public Style(Font font, Brush brush) { throw new NotImplementedException(); }

        public Style() { throw new NotImplementedException(); }

        public Style(Type targetType) { throw new NotImplementedException(); }

        public Brush Brush { get; set; }

        public float CharSpacing { get; set; }

        public Font Font { get; set; }

        public FontVariant FontVariant { get; set; }

        public Brush Highlight { get; set; }

        public float WordSpacing { get; set; }

        public Style Clone() { throw new NotImplementedException(); }

        public StyleHashKey GetHashKey() { throw new NotImplementedException(); }

        public ShortStyleHashKey GetShortHashKey() { throw new NotImplementedException(); }


        public SetterBaseCollection Setters { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public Type TargetType { get; set; }
    }
}
