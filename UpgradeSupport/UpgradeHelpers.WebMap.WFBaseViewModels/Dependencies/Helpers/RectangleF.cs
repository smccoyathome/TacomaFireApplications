using System;

namespace UpgradeHelpers.Helpers
{

	[Obsolete("Class only provided for compilation purposes")]
    public class RectangleF : FrameworkElement
    {
        private int p1;
        private int p2;
        private int p3;
        private int p4;
        private float x;
        private float y;
        private float width;
        private float height;
        private int p;
        private SizeF sizeF;
        private PointF pointF;

        public RectangleF()
        {
            this.p1 = 0;
            this.p2 = 0;
            this.p3 = 0;
            this.p4 = 0;
        }

        public RectangleF(int p1, int p2, int p3, int p4)
        {
            // TODO: Complete member initialization
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.p4 = p4;
        }

        public RectangleF(float x, float y, float width, float height)
        {
            // TODO: Complete member initialization
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public RectangleF(int p, SizeF sizeF)
        {
            // TODO: Complete member initialization
            this.p = p;
            this.sizeF = sizeF;
        }

        public RectangleF(PointF pointF, SizeF sizeF)
        {
            // TODO: Complete member initialization
            this.pointF = pointF;
            this.sizeF = sizeF;
        }
        public float X { get; set; }
        public float Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public int Left { get; set; }

        public int Top { get; set; }

        public int Location { get; set; }

        public int Bottom { get; set; }

        public int Right { get; set; }

        public static object Empty { get; set; }

        public Brush Fill { get; set; }

    }
}
