using System;
using System.ComponentModel;
using System.Globalization;

namespace UpgradeHelpers.Helpers
{
    public class PointF
    {
        private float x;
        private float y;

        [Browsable(false)]
        public bool IsEmpty
        {
            get
            {
                if ((double)this.x == 0.0)
                    return (double)this.y == 0.0;
                return false;
            }
        }

        public float X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }

        public float Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }

        public PointF(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public PointF()
        {
        }

        public override bool Equals(object obj)
        {
            if (!(obj is PointF))
                return false;
            PointF pointF = (PointF)obj;
            if ((double)pointF.X == (double)this.X && (double)pointF.Y == (double)this.Y)
                return pointF.GetType().Equals(this.GetType());
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format((IFormatProvider)CultureInfo.CurrentCulture, "{{X={0}, Y={1}}}", new object[2]
            {
                (object) X,
                (object) Y
            });
        }
    }
}
