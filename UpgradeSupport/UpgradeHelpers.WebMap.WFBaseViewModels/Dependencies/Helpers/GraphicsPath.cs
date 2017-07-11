using System;

namespace UpgradeHelpers.Helpers
{
    public class GraphicsPath: IDisposable
    {
        internal IntPtr nativePath;

        public void AddArc(float x, float y, float width, float height, float startAngle, float sweepAngle)
        {
            int status = SafeNativeMethods.Gdip.GdipAddPathArc(new HandleRef((object)this, this.nativePath), x, y, width, height, startAngle, sweepAngle);
            if (status != 0)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        public void AddLine(int x1, int y1, int x2, int y2)
        {
            int status = SafeNativeMethods.Gdip.GdipAddPathLineI(new HandleRef((object)this, this.nativePath), x1, y1, x2, y2);
            if (status != 0)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }


        public void AddLines(Point[] points)
        {
            throw new NotImplementedException();
        }

        public void AddRectangle(Rectangle rect)
        {
            throw new NotImplementedException();
        }

        public RectangleF GetBounds() { throw new NotImplementedException(); }

        public void Dispose()
        {
            /*Dispose method has no implementation*/
	        System.Diagnostics.Debugger.Break();
		}

        public void Transform(Matrix m)
        {
            throw new NotImplementedException();
        }

        public void AddString(string letter, FontFamily fontFamily, int p1, float p2, Point point, object p3)
        {
            throw new NotImplementedException();
        }

        public void AddRectangle(RectangleF baseRect)
        {
            throw new NotImplementedException();
        }

        public void CloseFigure()
        {
            throw new NotImplementedException();
        }

        public void AddArc(RectangleF arc, int p1, int p2)
        {
            throw new NotImplementedException();
        }

        public void AddEllipse(RectangleF baseRect)
        {
            throw new NotImplementedException();
        }
    }
}
