
using System;

namespace UpgradeHelpers.Helpers
{
	public class SolidBrush : Brush, IDisposable
    {
        public Color Color { get; set; }

        public string UniqueID { get; set; }
        

        public SolidBrush(Color color)
        {

        }

        [Obsolete("Added for debug purposes. this constructor is not present on original class.")]
        public SolidBrush()
        {
        }


    }
}
