using System;

namespace UpgradeHelpers.Helpers
{
	public class Image : IDisposable
    {
        //------contructors----------------------------------------------------------------------------------------------------------------------------------------------------
        public Image()
        {
            throw new NotImplementedException();
        }
        public Image(int p1, int p2)
        {
            throw new NotImplementedException();
        }
        //public Image(Image img)
        public Image(string img)
        {
            throw new NotImplementedException();
        }
        //------static method of image----------------------------------------------------------------------------------------------------------------------------------------------------
        public static string FromHbitmap(IntPtr hBitmap)
        {
            throw new NotImplementedException();
        }
        public static string FromStream(System.IO.MemoryStream ms)
        {
            //MOBILIZE,11/23/2016,TODO,mvega,MANUALLY Changes, to avoid firing a exception
            //throw new NotImplementedException();
            return null;
        }

        public static string FromStream(System.IO.Stream oStream)
        {
            throw new NotImplementedException();
        }

        public static string FromStream(System.IO.Stream stream, bool useEmbeddedColorManagement)
        {
            throw new NotImplementedException();
        }

        public static string FromFile(string p)
        {
            return p;// throw new NotImplementedException();
        }

        //------method of image----------------------------------------------------------------------------------------------------------------------------------------------------

        public static int Dispose(string image) //this method should be void
        {
            return 0;
        }

        public static void RotateFlip(string image, RotateFlipType rotateFlipType)
        {
            throw new NotImplementedException();
        }

        public static void Save(string image, string filename)
        {
            throw new NotImplementedException();
        }
        public static void Save(string image, System.IO.MemoryStream ms, ImageFormat imageFormat)
        {
            throw new NotImplementedException();
        }

        public static void Save(string image, string filename, ImageFormat format)
        {
            throw new NotImplementedException();
        }

        //------properties image----------------------------------------------------------------------------------------------------------------------------------------------------

        public static int SetWidth(string image, int Width)
        {
            throw new NotImplementedException();
        }
        public static int GetWidth(string image)
        {
			return 0;// JAR Dummy implementation, avoiding throw exception
        }

        public static int SetHeight(string image, int Height)
        {
            throw new NotImplementedException();
        }
        public static int GetHeight(string image)
        {
            return 0;// JAR Dummy implementation, avoiding throw exception
        }
        public static float SetHorizontalResolution(string image, object HorizontalResolution)
        {
            throw new NotImplementedException();
        }
        public static float GetHorizontalResolution(string image)
        {
            throw new NotImplementedException();
        }
        public static float SetVerticalResolution(string image, object VerticalResolution)
        {
            throw new NotImplementedException();
        }
        public static float GetVerticalResolution(string image)
        {
            throw new NotImplementedException();
        }

        public static object SetTag(string image, object Tag)
        {
            //throw new NotImplementedException();/*MANUAL CHANGE: scampos 1/13/2016*/
            return null;
        }
        public static object GetTag(string image)
        {
            throw new NotImplementedException();
        }
        public static Size SetSize(string image, Size size)
        {
            throw new NotImplementedException();
        }
        public static Size GetSize(string image)
        {
            throw new NotImplementedException();
        }

        public static int GetWidth(Bitmap bitmap)
        {
            throw new NotImplementedException();
        }

        public static int GetHeight(Bitmap bitmap)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            /*Dispose method has no implementation*/
	        System.Diagnostics.Debugger.Break();
		}
    }
}
