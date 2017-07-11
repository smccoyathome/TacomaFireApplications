

using System;
namespace UpgradeHelpers.Helpers
{
	public class Bitmap : Image
    {
//------contructors----------------------------------------------------------------------------------------------------------------------------------------------------
        public Bitmap()
        {
            throw new NotImplementedException();
        }

        public Bitmap(string str)
        {
            throw new NotImplementedException();
        }

        public Bitmap(Image original)
        {
            throw new NotImplementedException();
        }


        public Bitmap(Image original, int width, int height)
            : this(width, height)
        {
            throw new NotImplementedException();
        }

        public Bitmap(string url, int width, int height)
            : this(width, height)
        {
            throw new NotImplementedException();
        }

        public Bitmap(int width, int height)
            : this(width, height, PixelFormat.Format32bppArgb)
        {
            throw new NotImplementedException();
        }

        public Bitmap(int width, int height, PixelFormat format)
        {
            throw new NotImplementedException();
        }

        public Bitmap(Image image, Size size)
        {
            throw new NotImplementedException();
        }

//------static method of bitmap----------------------------------------------------------------------------------------------------------------------------------------------------

        public static string FromResource(IntPtr hinstance, string bitmapName)
        {
            throw new NotImplementedException();
        }

//------method of bitmap----------------------------------------------------------------------------------------------------------------------------------------------------
        public static BitmapData LockBits(string bitmap,Rectangle copyArea, ImageLockMode imageLockMode, PixelFormat pixelFormat)
        {
            throw new NotImplementedException();
        }

        public static void UnlockBits(string bitmap, BitmapData alphaBits)
        {
            throw new NotImplementedException();
        }

        public static Color GetPixel(string bitmap, int x, int y)
        {
            throw new NotImplementedException();
        }

        public static void MakeTransparent(string bitmap, Color color)
        {
            throw new NotImplementedException();
        }

        public static void SetResolution(string bitmap, object p1, object p2)
        {
            throw new NotImplementedException();
        }

        public static Color GetPixel(int x, int y)
        {
            throw new NotImplementedException();
        }

    }
}