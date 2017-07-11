using System;
using System.Globalization;

namespace UpgradeHelpers.Helpers
{
	public class Padding
    {
        private bool _all;
        private int _top;
        private int _left;
        private int _right;
        private int _bottom;

        public virtual int All
        {
            get
            {
                if (!this._all)
                    return -1;
                return this._top;
            }
            set
            {
                if (this._all && this._top == value)
                    return;
                this._all = true;
                this._top = this._left = this._right = this._bottom = value;
            }
        }

        public virtual int Bottom
        {
            get
            {
                if (this._all)
                    return this._top;
                return this._bottom;
            }
            set
            {
                if (!this._all && this._bottom == value)
                    return;
                this._all = false;
                this._bottom = value;
            }
        }

        public virtual int Left
        {
            get
            {
                if (this._all)
                    return this._top;
                return this._left;
            }
            set
            {
                if (!this._all && this._left == value)
                    return;
                this._all = false;
                this._left = value;
            }
        }

        public virtual int Right
        {
            get
            {
                if (this._all)
                    return this._top;
                return this._right;
            }
            set
            {
                if (!this._all && this._right == value)
                    return;
                this._all = false;
                this._right = value;
            }
        }

        public virtual int Top
        {
            get
            {
                return this._top;
            }
            set
            {
                if (!this._all && this._top == value)
                    return;
                this._all = false;
                this._top = value;
            }
        }


        public virtual int Horizontal
        {
            get
            {
                return this.Left + this.Right;
            }
        }


        public  int Vertical
        {
            get
            {
                return this.Top + this.Bottom;
            }
        }

        public int Heigth
        {
            get { return Vertical; }
            set
            {
                Top = value/2;
                Bottom = value/2;
            }
        }
        public int Width
        {
            get { return Horizontal; }
            set
            {
                Left = value / 2;
                Right = value / 2;
            }
        }


        public  Size Size
        {
            get
            {
                return new Size(this.Horizontal, this.Vertical);
            }
        }

        public Padding(int all)
        {
            this._all = true;
            this._top = this._left = this._right = this._bottom = all;
        }

        public Padding(int left, int top, int right, int bottom)
        {
            this._top = top;
            this._left = left;
            this._right = right;
            this._bottom = bottom;
            this._all = this._top == this._left && this._top == this._right && this._top == this._bottom;
        }

        public Padding(int h, int w)
        {
            this.Heigth = h;
            this.Width = w;
        }

        public Padding()
        {
           
        }

        public override string ToString()
        {
            return "{Left=" + this.Left.ToString((IFormatProvider)CultureInfo.CurrentCulture) + ",Top=" + this.Top.ToString((IFormatProvider)CultureInfo.CurrentCulture) + ",Right=" + this.Right.ToString((IFormatProvider)CultureInfo.CurrentCulture) + ",Bottom=" + this.Bottom.ToString((IFormatProvider)CultureInfo.CurrentCulture) + "}";
        }

    }
}
