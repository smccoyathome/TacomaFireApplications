using UpgradeHelpers.Extensions;

namespace UpgradeHelpers.Helpers
{
	public struct SizeF /*: IDisposable*/
    {
        private float p { get; set; }
        private int p1 { get; set; }
        private int p2 { get; set; }
        private float p3 { get; set; }
        private float p4{ get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public PointF PointF { get; set; }

        public SizeF(int p1, int p2)
            : this()
        {
            // TODO: Complete member initialization
            this.p1 = p1;
            this.p2 = p2;
        }

        public SizeF(float p3, float p4)
            : this()
        {
            // TODO: Complete member initialization
            this.p3 = p3;
            this.p4 = p4;
        }

        public SizeF(float p)
            : this()
        {
            // TODO: Complete member initialization
            this.p = p;
        }

        public PointF ToPointF()
        {
            return this.PointF != null ? this.PointF : new PointF();
        }
        public PointF ToPointF(float x, float y)
        {
            this.PointF =  new PointF(x, y);
            return this.PointF;
        }

        public static SizeF operator +(SizeF c1, SizeF c2)
        {
            return new SizeF(c1.p3 + c2.p4);
        }

        public Size ToSize()
        {
			return new Size(Width.ToInt(),Height.ToInt());
        }
    }
}
