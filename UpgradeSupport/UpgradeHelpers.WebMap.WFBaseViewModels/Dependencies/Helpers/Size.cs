using System;
using System.ComponentModel;
using System.Globalization;


namespace UpgradeHelpers.Helpers
{
	//[System.ComponentModel.TypeConverter(typeof(SizeConverter))]
	public class Size 
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        [Browsable(false)]
        public bool IsEmpty
        {
            get
            {
                if (Width == 0)
                    return Height == 0;
                return false;
            }
        }

        public Size(Point pt)
        {
            Width = pt.X;
            Height = pt.Y;
        }

        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public Size()
        {
            // TODO: Complete member initialization
        }

        public override string ToString()
        {
            return "{Width=" + Width.ToString((IFormatProvider)CultureInfo.CurrentCulture) + ", Height=" + Height.ToString((IFormatProvider)CultureInfo.CurrentCulture) + "}";
        }

        static Size EmptyInstance = new Size();

        public static Size Empty
        {
            get
            {
                return EmptyInstance;
            }
        }

        //
        // Summary:
        //     Adds the width and height of one System.Drawing.Size structure to the width
        //     and height of another System.Drawing.Size structure.
        //
        // Parameters:
        //   sz1:
        //     The first System.Drawing.Size to add.
        //
        //   sz2:
        //     The second System.Drawing.Size to add.
        //
        // Returns:
        //     A System.Drawing.Size structure that is the result of the addition operation.
        public static Size operator +(Size sz1, Size sz2)
        {
            var res = new Size();
            res.Height = sz1.Height + sz2.Height;
            res.Width = sz1.Width + sz2.Width;
            return res;
        }
    }
}