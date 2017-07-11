
using System;

namespace UpgradeHelpers.Helpers
{
	public class LinearGradientBrush: Brush, IDisposable
    {

        private Rectangle rect;
        private Color color1;
        private Color color2;
        private float p;
        private Rectangle rectangle;
        private LinearGradientMode linearGradientMode;

        public LinearGradientBrush(Rectangle rect, Color color1, Color color2, float p)
        {
            // TODO: Complete member initialization
            this.rect = rect;
            this.color1 = color1;
            this.color2 = color2;
            this.p = p;
        }

        public LinearGradientBrush(Rectangle rectangle, Color color1, Color color2, LinearGradientMode linearGradientMode)
        {
            // TODO: Complete member initialization
            this.rectangle = rectangle;
            this.color1 = color1;
            this.color2 = color2;
            this.linearGradientMode = linearGradientMode;
        }

        public Blend Blend { get; set; }

        public virtual ColorBlend InterpolationColors { get; set; }

        public virtual Color[] LinearColors { get; set; }

        public WrapMode WrapMode { get; set; }

        public void SetSigmaBellShape(float p1, float p2)
        {
            throw new NotImplementedException();
        }
    }
}
