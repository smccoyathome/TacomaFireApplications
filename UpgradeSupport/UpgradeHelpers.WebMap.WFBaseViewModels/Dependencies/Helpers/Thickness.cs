using System;

namespace UpgradeHelpers.Helpers
{
	public class Thickness : IEquatable<Thickness>
    {
        public Thickness(double uniformLength) 
        {
            Bottom = 0;
            Left = 0;
            Right = 0;
            Top = 0;
        }

        public Thickness(double left, double top, double right, double bottom) 
        {
            Bottom = bottom;
            Left = left;
            Right = right;
            Top = top;
        }

        public static bool operator !=(Thickness t1, Thickness t2)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(Thickness t1, Thickness t2)
        {
            throw new NotImplementedException();
        }

        public double Bottom { get; set; }

        public double Left { get; set; }

        public double Right { get; set; }

        public double Top { get; set; }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public bool Equals(Thickness thickness)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}