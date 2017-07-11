using System;
using System.ComponentModel;
using System.Globalization;

namespace UpgradeHelpers.Helpers
{
    public class Point
    {
        [Browsable(false)]
        public bool IsEmpty
        {
            get
            {
                if (this.X == 0)
                    return this.Y == 0;
                return false;
            }
        }

        public virtual int X { get; set; }

        public virtual int Y { get; set; }

        public Point(Size sz)
        {
            this.Y = sz.Width;
            this.Y = sz.Height;
        }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Point(int dw)
        {
            this.X = (int)(short)Point.LOWORD(dw);
            this.Y = (int)(short)Point.HIWORD(dw);
        }

        public Point()
        {
            // TODO: Complete member initialization
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Point))
                return false;
            Point point = (Point)obj;
            if (point.X == this.X)
                return point.Y == this.Y;
            return false;
        }

        public override int GetHashCode()
        {
            return this.X ^ this.Y;
        }

        public static Point Empty { get; set; }

        public override string ToString()
        {
            string[] strArray = new string[5];
            int index1 = 0;
            string str1 = "{X=";
            strArray[index1] = str1;
            int index2 = 1;
            string str2 = this.X.ToString((IFormatProvider)CultureInfo.CurrentCulture);
            strArray[index2] = str2;
            int index3 = 2;
            string str3 = ",Y=";
            strArray[index3] = str3;
            int index4 = 3;
            string str4 = this.Y.ToString((IFormatProvider)CultureInfo.CurrentCulture);
            strArray[index4] = str4;
            int index5 = 4;
            string str5 = "}";
            strArray[index5] = str5;
            return string.Concat(strArray);
        }

        private static int HIWORD(int n)
        {
            return n >> 16 & (int)ushort.MaxValue;
        }

        private static int LOWORD(int n)
        {
            return n & (int)ushort.MaxValue;
        }
    }
}
