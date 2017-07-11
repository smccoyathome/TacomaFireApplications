using System;

namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Each property of the System.Drawing.TextureBrush class is a System.Drawing.Brush
	//     object that uses an image to fill the interior of a shape. This class cannot
	//     be inherited.
	public class TextureBrush : Brush
    {
        private string image;
        private WrapMode wrapMode;
        private Bitmap bitmap;
        private string p;

        public TextureBrush(string image, WrapMode wrapMode)
        {
            // TODO: Complete member initialization
            this.image = image;
            this.wrapMode = wrapMode;
        }
        public TextureBrush(string image, Rectangle dstRect)
        {
            throw new NotImplementedException();
        }

        public TextureBrush(Bitmap bitmap)
        {
            // TODO: Complete member initialization
            this.bitmap = bitmap;
        }

        public TextureBrush(string p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }
    }
}
