using System;


namespace UpgradeHelpers.Helpers
{
	public class Graphics : IDisposable
    {

        private IntPtr nativeGraphics;
        internal IntPtr NativeGraphics
        {
            get
            {
                return this.nativeGraphics;
            }
        }

		public Graphics() { }

        public void DrawLine(Pen pen, Point pt1, Point pt2)
        {
            //this.DrawLine(pen, pt1.X, pt1.Y, pt2.X, pt2.Y);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public SizeF MeasureString(string p, Font font)
        {
            SizeF size = new SizeF();
            if (font != null && !String.IsNullOrEmpty(p)) { 
                size.ToPointF((float)(font.Size * 0.76 * p.Length),0);
                //font.Size * 0.76 * p.Length;
                return size;
            }

            return new SizeF();
        }

        public static Graphics FromHwnd(IntPtr intPtr)
        {
            return new Graphics(intPtr);
        }
        public void DrawString(string s, Font f, Brush b, Point point, StringFormat sf)
        {
            throw new NotImplementedException();
        }

        public void DrawString(string s, Font font, Brush brush, PointF point)
        {
            throw new NotImplementedException();
        }
        public void DrawImage(String image, Point[] destPoints)
        {
            throw new NotImplementedException();
        }
        public void DrawImage(String image, int left, int top, int width, int height)
        {
            throw new NotImplementedException();
        }

        public void DrawImage(String ImgPhoto, Rectangle objRect, int p1, int p2, int p3, int p4, GraphicsUnit graphicsUnit)
        {
            throw new NotImplementedException();
        }

        public Region[] MeasureCharacterRanges(string text, Font font, RectangleF layoutRect, StringFormat format)
        {
            throw new NotImplementedException();
        }

        public void DrawLine(Pen pen, int p1, int p2, int p3, int p4)
        {
            throw new NotImplementedException();
        }

        public void FillRectangle(SolidBrush solidBrush, int p1, int p2, int p3, int p4)
        {
            throw new NotImplementedException();
        }

        public void DrawRectangle(Pen pen, int p1, int p2, int p3, int p4)
        {
            throw new NotImplementedException();
        }

        public void DrawString(string p, Font font, SolidBrush solidBrush, Rectangle bounds, StringFormat stringFormat)

        {
            throw new NotImplementedException();
        }

        public void DrawString(string p, Font font, SolidBrush solidBrush, Point point, StringFormat stringFormat)
        {
            throw new NotImplementedException();
        }

        public void DrawString(string p, Font font, Brush brush, Rectangle rectangle, StringFormat stringFormat)
        {
            throw new NotImplementedException();
        }
        

        public void DrawString(string p, Font font, SolidBrush solidBrush, Rectangle rectangle)
        {
            throw new NotImplementedException();
        }

        public void DrawString(string p, Font font, Brush brush, RectangleF rectangleF)
        {
            throw new NotImplementedException();
        }

        public CompositingQuality CompositingQuality { get; set; }

        public void FillRectangles(SolidBrush solidBrush, Rectangle[] rectangle)
        {
            throw new NotImplementedException();
        }



        public void FillRectangle(LinearGradientBrush LinearGradientBrush, int p1, int p2, int p3, int p4)
        {
            throw new NotImplementedException();
        }

        public void FillRectangle(LinearGradientBrush linearGradientBrush, Rectangle rectangle)
        {
            throw new NotImplementedException();
        }

        public void FillRectangles(LinearGradientBrush linearGradientBrush, Rectangle[] rectangle)
        {
            throw new NotImplementedException();
        }

        public void DrawString(string s, Font font, SolidBrush brush, float x, float y, StringFormat format)
        {
            throw new NotImplementedException();
        }
        public void DrawString(string p, Font font, Brush brush, Rectangle rectangle)
        {
            throw new NotImplementedException();
        }

        public void DrawEllipse(Pen pen, float x, float y, float width, float height)
        {
            throw new NotImplementedException();
        }

        public void FillPolygon(object brush, Point[] points)
        {
            throw new NotImplementedException();
        }

        public void FillRectangle(TextureBrush brush, Rectangle rectangle)
        {
            throw new NotImplementedException();
        }

        public void DrawImage(String image, Rectangle destRect, int srcX, int srcY, int srcWidth, int srcHeight, GraphicsUnit srcUnit, ImageAttributes imageAttr)
        {
            System.Diagnostics.Debug.WriteLine("DrawImage1 Not implemented");
        }
        public void DrawImage(String image, Rectangle rect)
        {
            System.Diagnostics.Debug.WriteLine("DrawImage2 Not implemented");
        }

        public void FillRectangle(Brush brush, int p1, int p2, int width, int p3)
        {
            /// JAR Avoiding exception, pending implementation
        }

        public static Graphics FromImage(Bitmap bitmap)
        {
            throw new NotImplementedException();
        }

        public static Graphics FromImage(UpgradeHelpers.Helpers.Image image)
        {
            throw new NotImplementedException();
        }

        public void DrawBezier(Pen pen, int p1, int p2, int p3, int p4, int p5, int p6, int p7, int p8)
        {
            System.Diagnostics.Debug.WriteLine("DrawBezier Not implemented");
        }

        public void Clear(object p)
        {
            System.Diagnostics.Debug.WriteLine("Clear Not implemented");
        }

        public static Graphics FromImage(String image)
        {
			return new Graphics(); // JAR Dummy implementation, avoiding throw exception
        }

        public IntPtr GetHdc()
        {
            throw new NotImplementedException();
        }

        public void ReleaseHdc(IntPtr hDC)
        {
            System.Diagnostics.Debug.WriteLine("ReleaseHdc Not implemented");
        }

        public SizeF MeasureString(string p, Font font, SizeF sizeF, StringFormat stringFormat)
        {
            throw new NotImplementedException();
        }

        public SizeF MeasureString(string p, Font font, int width, StringFormat stringFormat)
        {
            throw new NotImplementedException();
        }

        public SizeF MeasureString(string text, Font font, SizeF layoutArea, StringFormat stringFormat, out int charactersFitted, out int linesFilled)
        {
			//, MOBILIZE,10/11/2016,TODO,JAR,"Dummy implementation, just avoiding exception"	
			charactersFitted = 0;
			linesFilled = 0;
			return new SizeF();
        }

        public void DrawImage(String image, Rectangle rectangle, int p1, int y, int p2, int p3, GraphicsUnit graphicsUnit, ColorMatrix imageAttributes)
        {
            System.Diagnostics.Debug.WriteLine("DrawImage3 Not implemented");
        }

        public void DrawImage(String arrowImage, int xArrow, int yArrow)
        {
            System.Diagnostics.Debug.WriteLine("DrawImage4 Not implemented");
        }

        public void DrawImage(String image, Rectangle rectangle1, Rectangle rectangle2, GraphicsUnit graphicsUnit)
        {
            System.Diagnostics.Debug.WriteLine("DrawImage5 Not implemented");
        }

        public void FillPath(LinearGradientBrush brush, GraphicsPath path)
        {
            System.Diagnostics.Debug.WriteLine("FillPath Not implemented");
        }

        public SmoothingMode SmoothingMode { get; set; }

        public void FillRectangle(SolidBrush brush, Rectangle rectangle)
        {
            System.Diagnostics.Debug.WriteLine("FillRectangle Not implemented");
        }

        public GraphicsState Save()
        {
            throw new NotImplementedException();
        }

        public void TranslateTransform(int p1, int p2)
        {
            throw new NotImplementedException();
        }

        public void Restore(GraphicsState state)
        {
            System.Diagnostics.Debug.WriteLine("Restore Not implemented");
        }

        public void DrawImageUnscaled(String image, int p1, int p2)
        {
            System.Diagnostics.Debug.WriteLine("DrawImageUnscaled Not implemented");
        }

        public void FillRectangle(Brush brush, Rectangle rectangle)
        {
            System.Diagnostics.Debug.WriteLine("FillRectangle Not implemented");
        }

        public void DrawString(string label, Font font, Brush brush, int x, int labelY, StringFormat stringFormat)
        {
            System.Diagnostics.Debug.WriteLine("DrawString1 Not implemented");
        }

        public InterpolationMode InterpolationMode { get; set; }

        public void DrawString(string text, Font font, Brush brush, int x, int y)
        {
            System.Diagnostics.Debug.WriteLine("DrawString2 Not implemented");
        }

        public void DrawImage(string img, Point point)
        {
            System.Diagnostics.Debug.WriteLine("DrawImage10 Not implemented");
        }

        public void DrawImage(String image, PointF point)
        {
            System.Diagnostics.Debug.WriteLine("DrawImage11 Not implemented");
        }

        public void DrawPolygon(Pen pen, Point[] ptGridLines)
        {
            System.Diagnostics.Debug.WriteLine("DrawImage12 Not implemented");
        }

        public Matrix Transform { get; set; }

        public void FillRegion(Brush lgbElapsed, Region elapsedReg)
        {
            throw new NotImplementedException();
        }

        public void DrawRectangle(Pen pen, Rectangle rect)
        {
            System.Diagnostics.Debug.WriteLine("DrawImage10 Not implemented");
        }

        public void DrawPath(Pen pen, GraphicsPath path)
        {
            System.Diagnostics.Debug.WriteLine("DrawImage11 Not implemented");
        }

        public PixelOffsetMode PixelOffsetMode { get; set; }

        public static Graphics FromImage(Metafile _metaFile)
        {
            throw new NotImplementedException();
        }

        public float DpiX { get; set; }

        public float DpiY { get; set; }

        public GraphicsUnit PageUnit { get; set; }

        public SizeF MeasureString(string p1, Font font, int p2)
        {
            throw new NotImplementedException();
        }

        public void DrawRectangles(Pen hotPen, Rectangle[] rectangle)
        {
            throw new NotImplementedException();
        }

        public void TranslateTransform(float p1, int p2)
        {
            throw new NotImplementedException();
        }

        public void TranslateTransform(float p1, float p2)
        {
            throw new NotImplementedException();
        }

        public void DrawString(string Text, Font Font, SolidBrush textBrush, PointF pointf)
        {
            throw new NotImplementedException();
        }

        public void FillEllipse(LinearGradientBrush fillBrush, int p1, int p2, int p3, int p4)
        {
            throw new NotImplementedException();
        }

        public void FillEllipse(Brush fillColorBrush, int p1, int p2, int p3, int p4)
        {
            throw new NotImplementedException();
        }

        public void DrawString(string letter, Font font, Brush brush, float textX, float textY)
        {
            throw new NotImplementedException();
        }

        public void DrawLines(Pen checkPen, PointF[] points)
        {
            throw new NotImplementedException();
        }

        public void FillEllipse(LinearGradientBrush fillBrush, Rectangle m_RectYes)
        {
            throw new NotImplementedException();
        }

        public void DrawEllipse(Pen borderPen, Rectangle m_RectYes)
        {
            throw new NotImplementedException();
        }

        public void FillPath(Brush brush, GraphicsPath pth)
        {
            throw new NotImplementedException();
        }

        public void DrawImage(Bitmap bm, Rectangle rectImage, int p1, int p2, int p3, int p4, GraphicsUnit graphicsUnit)
        {
            throw new NotImplementedException();
        }

        public void DrawLine(Pen penBlack, int p1, int p2, float p3, float p4)
        {
            throw new NotImplementedException();
        }

        public void DrawArc(Pen penRed, int p1, int p2, int p3, int p4, int p5, int p6)
        {
            throw new NotImplementedException();
        }

        public void DrawLine(Pen penBlack2, float p1, float p2, float p3, float p4)
        {
            throw new NotImplementedException();
        }

        public void DrawRectangle(Pen penPercentage, int p1, float p2, int p3, float m_MapStdItem)
        {
            throw new NotImplementedException();
        }

        public void FillRectangle(Brush solidGrayBrush, int p1, float p2, int p3, float m_MapHMPItem)
        {
            throw new NotImplementedException();
        }

        public void ScaleTransform(float xScale, float yScale)
        {
            throw new NotImplementedException();
        }

        public void ResetTransform()
        {
            throw new NotImplementedException();
        }

        public void FillEllipse(Brush brush, RectangleF rc)
        {
            throw new NotImplementedException();
        }

        public void DrawEllipse(Pen pen, RectangleF rc)
        {
            throw new NotImplementedException();
        }

        public void FillRectangle(Brush rotateBrush, RectangleF rc)
        {
            throw new NotImplementedException();
        }

        public void FillPolygon(Brush b, PointF[] points)
        {
            throw new NotImplementedException();
        }

        public TextRenderingHint TextRenderingHint { get; set; }

        public void DrawRectangle(Pen rotatePen, float p1, float p2, int p3, int p4)
        {
            throw new NotImplementedException();
        }

        public void DrawRectangle(Pen rotatePen, float p1, float p2, float p3, float p4)
        {
            throw new NotImplementedException();
        }

        public void DrawImage(Bitmap bitmap, Rectangle BitmapBounds)
        {
            throw new NotImplementedException();
        }

        public void DrawString(string text, Font font, Brush brush, Point textLocation)
        {
            throw new NotImplementedException();
        }

        public SizeF MeasureString(string p, Font font, SizeF layoutSize)
        {
            throw new NotImplementedException();
        }

        public void DrawString(string p, Font font, Brush br, RectangleF rect, StringFormat sf)
        {
            throw new NotImplementedException();
        }

        private Graphics(IntPtr gdipNativeGraphics)
        {
            //if (gdipNativeGraphics == IntPtr.Zero)
                //throw new ArgumentNullException("gdipNativeGraphics");
            this.nativeGraphics = gdipNativeGraphics;
        }

        public static Graphics FromHdcInternal(IntPtr hdc)
        {
            IntPtr graphics = hdc;
            int fromHdc = SafeNativeMethods.Gdip.GdipCreateFromHDC(new HandleRef((object)null, hdc), out graphics);
            /*if (fromHdc != 0) 
                throw SafeNativeMethods.Gdip.StatusException(fromHdc);*/
            return new Graphics(graphics);
        }
    }
}
