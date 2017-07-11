using System;
using System.ComponentModel;

namespace UpgradeHelpers.Helpers
{
	/// <summary>
	/// Stores a set of four integers that represent the location and size of a rectangle
	/// </summary>
	[Serializable]
	//[Obsolete("Extension only provided for compilation purposes")]
	public class Rectangle
	{
		private int width;
		private int height;


		[Browsable(false)]
		public Point Location
		{
			get
			{
				return new Point(this.X, this.Y);
			}
			set
			{
				this.X = value.X;
				this.Y = value.Y;
			}
		}

		[Browsable(false)]
		public Size Size
		{
			get
			{
				return new Size(this.Width, this.Height);
			}
			set
			{
				this.Width = value.Width;
				this.Height = value.Height;
			}
		}

		public Rectangle()
		{

		}

		public Rectangle(Point location, Size size)
		{
			this.X = location.X;
			this.Y = location.Y;
			this.width = size.Width;
			this.height = size.Height;
		}

		public Rectangle(int x, int y, int width, int height)
		{
			this.X = x;
			this.Y = y;
			this.Width = width;
			this.Height = height;
		}

		public virtual int X
		{
			get;
			set;
		}

		public virtual int Y
		{
			get;
			set;
		}

		public int Width
		{
			get;
			set;
		}

		public int Height
		{
			get;
			set;
		}

		[Browsable(false)]
		public int Left
		{
			get
			{
				return this.X;
			}
		}

		[Browsable(false)]
		public int Top
		{
			get
			{
				return this.Y;
			}
		}

		[Browsable(false)]
		public int Right
		{
			get
			{
				return this.X + this.Width;
			}
		}

		[Browsable(false)]
		public int Bottom
		{
			get
			{
				return this.Y + this.Height;
			}
		}

        /// <summary>
        /// Compilation Stub. 
        /// </summary>
        /// <maps></maps>
		public bool Contains(int x, int y)
		{
			if (this.X <= x && x < this.X + this.Width && this.Y <= y)
				return y < this.Y + this.Height;
			return false;
		}

        /// <summary>
        /// Compilation Stub. 
        /// </summary>
        /// <maps></maps>
		public bool Contains(Rectangle oRect)
		{
			throw new NotImplementedException();
		}

		public bool Contains(Point pt)
		{
			return this.Contains(pt.X, pt.Y);
		}

		public static Rectangle Round(object p)
		{
			throw new NotImplementedException();
		}

		public void Offset(int p1, int p2)
		{
			throw new NotImplementedException();
		}

		public bool IntersectsWith(Rectangle rectangle)
		{
			throw new NotImplementedException();
		}

		public void Offset(Point point)
		{
			throw new NotImplementedException();
		}

		public static Rectangle Empty { get; set; }

		public Brush Fill { get; set; }

		public void Inflate(Size size)
		{

			Inflate(size.Width, size.Height);
		}

		public void Inflate(int width, int height)
		{
			this.X -= width;
			this.Y -= height;
			this.Width += 2 * width;
			this.Height += 2 * height;
		}

		public Rectangle Value { get; set; }
	}

}