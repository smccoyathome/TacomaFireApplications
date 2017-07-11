﻿using System;

namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Describes the width, height, and location of a rectangle.
	[Serializable]
    [TypeConverter(typeof(RectConverter))]
    [ValueSerializer(typeof(RectValueSerializer))]
    public struct Rect : IFormattable
    {
        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Rect structure that is of
        //     the specified size and is located at (0,0).
        //
        // Parameters:
        //   size:
        //     A System.Windows.Size structure that specifies the width and height of the
        //     rectangle.
        public Rect(Size size)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Rect structure that is exactly
        //     large enough to contain the two specified points.
        //
        // Parameters:
        //   point1:
        //     The first point that the new rectangle must contain.
        //
        //   point2:
        //     The second point that the new rectangle must contain.
        public Rect(Point point1, Point point2)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Rect structure that has
        //     the specified top-left corner location and the specified width and height.
        //
        // Parameters:
        //   location:
        //     A point that specifies the location of the top-left corner of the rectangle.
        //
        //   size:
        //     A System.Windows.Size structure that specifies the width and height of the
        //     rectangle.
        public Rect(Point location, Size size)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Rect structure that is exactly
        //     large enough to contain the specified point and the sum of the specified
        //     point and the specified vector.
        //
        // Parameters:
        //   point:
        //     The first point the rectangle must contain.
        //
        //   vector:
        //     The amount to offset the specified point. The resulting rectangle will be
        //     exactly large enough to contain both points.
        public Rect(Point point, Vector vector)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Rect structure that has
        //     the specified x-coordinate, y-coordinate, width, and height.
        //
        // Parameters:
        //   x:
        //     The x-coordinate of the top-left corner of the rectangle.
        //
        //   y:
        //     The y-coordinate of the top-left corner of the rectangle.
        //
        //   width:
        //     The width of the rectangle.
        //
        //   height:
        //     The height of the rectangle.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     width is a negative value.-or-height is a negative value.
        public Rect(double x, double y, double width, double height)
        {
            throw new NotImplementedException();
        }


        // Summary:
        //     Compares two rectangles for inequality.
        //
        // Parameters:
        //   rect1:
        //     The first rectangle to compare.
        //
        //   rect2:
        //     The second rectangle to compare.
        //
        // Returns:
        //     true if the rectangles do not have the same System.Windows.Rect.Location
        //     and System.Windows.Rect.Size values; otherwise, false.
        public static bool operator !=(Rect rect1, Rect rect2)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Compares two rectangles for exact equality.
        //
        // Parameters:
        //   rect1:
        //     The first rectangle to compare.
        //
        //   rect2:
        //     The second rectangle to compare.
        //
        // Returns:
        //     true if the rectangles have the same System.Windows.Rect.Location and System.Windows.Rect.Size
        //     values; otherwise, false.
        public static bool operator ==(Rect rect1, Rect rect2)
        {
            throw new NotImplementedException();
        }

        // Summary:
        //     Gets the y-axis value of the bottom of the rectangle.
        //
        // Returns:
        //     The y-axis value of the bottom of the rectangle. If the rectangle is empty,
        //     the value is System.Double.NegativeInfinity .
        public double Bottom { get { throw new NotImplementedException(); } }
        //
        // Summary:
        //     Gets the position of the bottom-left corner of the rectangle
        //
        // Returns:
        //     The position of the bottom-left corner of the rectangle.
        public Point BottomLeft { get { throw new NotImplementedException(); } }
        //
        // Summary:
        //     Gets the position of the bottom-right corner of the rectangle.
        //
        // Returns:
        //     The position of the bottom-right corner of the rectangle.
        public Point BottomRight { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets a special value that represents a rectangle with no position or area.
        //
        // Returns:
        //     The empty rectangle, which has System.Windows.Rect.X and System.Windows.Rect.Y
        //     property values of System.Double.PositiveInfinity, and has System.Windows.Rect.Width
        //     and System.Windows.Rect.Height property values of System.Double.NegativeInfinity.
        public static Rect Empty { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets or sets the height of the rectangle.
        //
        // Returns:
        //     A positive number that represents the height of the rectangle. The default
        //     is 0.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     System.Windows.Rect.Height is set to a negative value.
        //
        //   System.InvalidOperationException:
        //     System.Windows.Rect.Height is set on an System.Windows.Rect.Empty rectangle.
        public double Height { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets a value that indicates whether the rectangle is the System.Windows.Rect.Empty
        //     rectangle.
        //
        // Returns:
        //     true if the rectangle is the System.Windows.Rect.Empty rectangle; otherwise,
        //     false.
        public bool IsEmpty { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the x-axis value of the left side of the rectangle.
        //
        // Returns:
        //     The x-axis value of the left side of the rectangle.
        public double Left { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets or sets the position of the top-left corner of the rectangle.
        //
        // Returns:
        //     The position of the top-left corner of the rectangle. The default is (0,
        //     0).
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     System.Windows.Rect.Location is set on an System.Windows.Rect.Empty rectangle.
        public Point Location { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the x-axis value of the right side of the rectangle.
        //
        // Returns:
        //     The x-axis value of the right side of the rectangle.
        public double Right { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets or sets the width and height of the rectangle.
        //
        // Returns:
        //     A System.Windows.Size structure that specifies the width and height of the
        //     rectangle.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     System.Windows.Rect.Size is set on an System.Windows.Rect.Empty rectangle.
        public Size Size { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the y-axis position of the top of the rectangle.
        //
        // Returns:
        //     The y-axis position of the top of the rectangle.
        public double Top { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the position of the top-left corner of the rectangle.
        //
        // Returns:
        //     The position of the top-left corner of the rectangle.
        public Point TopLeft { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the position of the top-right corner of the rectangle.
        //
        // Returns:
        //     The position of the top-right corner of the rectangle.
        public Point TopRight { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets or sets the width of the rectangle.
        //
        // Returns:
        //     A positive number that represents the width of the rectangle. The default
        //     is 0.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     System.Windows.Rect.Width is set to a negative value.
        //
        //   System.InvalidOperationException:
        //     System.Windows.Rect.Width is set on an System.Windows.Rect.Empty rectangle.
        public double Width { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets or sets the x-axis value of the left side of the rectangle.
        //
        // Returns:
        //     The x-axis value of the left side of the rectangle.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     System.Windows.Rect.X is set on an System.Windows.Rect.Empty rectangle.
        public double X { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets or sets the y-axis value of the top side of the rectangle.
        //
        // Returns:
        //     The y-axis value of the top side of the rectangle.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     System.Windows.Rect.Y is set on an System.Windows.Rect.Empty rectangle.
        public double Y { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        // Summary:
        //     Indicates whether the rectangle contains the specified point.
        //
        // Parameters:
        //   point:
        //     The point to check.
        //
        // Returns:
        //     true if the rectangle contains the specified point; otherwise, false.
        public bool Contains(Point point)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Indicates whether the rectangle contains the specified rectangle.
        //
        // Parameters:
        //   rect:
        //     The rectangle to check.
        //
        // Returns:
        //     true if rect is entirely contained by the rectangle; otherwise, false.
        public bool Contains(Rect rect)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Indicates whether the rectangle contains the specified x-coordinate and y-coordinate.
        //
        // Parameters:
        //   x:
        //     The x-coordinate of the point to check.
        //
        //   y:
        //     The y-coordinate of the point to check.
        //
        // Returns:
        //     true if (x, y) is contained by the rectangle; otherwise, false.
        public bool Contains(double x, double y)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Indicates whether the specified object is equal to the current rectangle.
        //
        // Parameters:
        //   o:
        //     The object to compare to the current rectangle.
        //
        // Returns:
        //     true if o is a System.Windows.Rect and has the same System.Windows.Rect.Location
        //     and System.Windows.Rect.Size values as the current rectangle; otherwise,
        //     false.
        public override bool Equals(object o)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Indicates whether the specified rectangle is equal to the current rectangle.
        //
        // Parameters:
        //   value:
        //     The rectangle to compare to the current rectangle.
        //
        // Returns:
        //     true if the specified rectangle has the same System.Windows.Rect.Location
        //     and System.Windows.Rect.Size values as the current rectangle; otherwise,
        //     false.
        public bool Equals(Rect value)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Indicates whether the specified rectangles are equal.
        //
        // Parameters:
        //   rect1:
        //     The first rectangle to compare.
        //
        //   rect2:
        //     The second rectangle to compare.
        //
        // Returns:
        //     true if the rectangles have the same System.Windows.Rect.Location and System.Windows.Rect.Size
        //     values; otherwise, false.
        public static bool Equals(Rect rect1, Rect rect2)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Creates a hash code for the rectangle.
        //
        // Returns:
        //     A hash code for the current System.Windows.Rect structure.
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Expands the rectangle by using the specified System.Windows.Size, in all
        //     directions.
        //
        // Parameters:
        //   size:
        //     Specifies the amount to expand the rectangle. The System.Windows.Size structure's
        //     System.Windows.Size.Width property specifies the amount to increase the rectangle's
        //     System.Windows.Rect.Left and System.Windows.Rect.Right properties. The System.Windows.Size
        //     structure's System.Windows.Size.Height property specifies the amount to increase
        //     the rectangle's System.Windows.Rect.Top and System.Windows.Rect.Bottom properties.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     This method is called on the System.Windows.Rect.Empty rectangle.
        public void Inflate(Size size)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Expands or shrinks the rectangle by using the specified width and height
        //     amounts, in all directions.
        //
        // Parameters:
        //   width:
        //     The amount by which to expand or shrink the left and right sides of the rectangle.
        //
        //   height:
        //     The amount by which to expand or shrink the top and bottom sides of the rectangle.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     This method is called on the System.Windows.Rect.Empty rectangle.
        public void Inflate(double width, double height)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Returns the rectangle that results from expanding the specified rectangle
        //     by the specified System.Windows.Size, in all directions.
        //
        // Parameters:
        //   rect:
        //     The System.Windows.Rect structure to modify.
        //
        //   size:
        //     Specifies the amount to expand the rectangle. The System.Windows.Size structure's
        //     System.Windows.Size.Width property specifies the amount to increase the rectangle's
        //     System.Windows.Rect.Left and System.Windows.Rect.Right properties. The System.Windows.Size
        //     structure's System.Windows.Size.Height property specifies the amount to increase
        //     the rectangle's System.Windows.Rect.Top and System.Windows.Rect.Bottom properties.
        //
        // Returns:
        //     The resulting rectangle.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     rect is an System.Windows.Rect.Empty rectangle.
        public static Rect Inflate(Rect rect, Size size)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Creates a rectangle that results from expanding or shrinking the specified
        //     rectangle by the specified width and height amounts, in all directions.
        //
        // Parameters:
        //   rect:
        //     The System.Windows.Rect structure to modify.
        //
        //   width:
        //     The amount by which to expand or shrink the left and right sides of the rectangle.
        //
        //   height:
        //     The amount by which to expand or shrink the top and bottom sides of the rectangle.
        //
        // Returns:
        //     The resulting rectangle.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     rect is an System.Windows.Rect.Empty rectangle.
        public static Rect Inflate(Rect rect, double width, double height)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Finds the intersection of the current rectangle and the specified rectangle,
        //     and stores the result as the current rectangle.
        //
        // Parameters:
        //   rect:
        //     The rectangle to intersect with the current rectangle.
        public void Intersect(Rect rect)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Returns the intersection of the specified rectangles.
        //
        // Parameters:
        //   rect1:
        //     The first rectangle to compare.
        //
        //   rect2:
        //     The second rectangle to compare.
        //
        // Returns:
        //     The intersection of the two rectangles, or System.Windows.Rect.Empty if no
        //     intersection exists.
        public static Rect Intersect(Rect rect1, Rect rect2)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Indicates whether the specified rectangle intersects with the current rectangle.
        //
        // Parameters:
        //   rect:
        //     The rectangle to check.
        //
        // Returns:
        //     true if the specified rectangle intersects with the current rectangle; otherwise,
        //     false.
        public bool IntersectsWith(Rect rect)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Moves the rectangle by the specified vector.
        //
        // Parameters:
        //   offsetVector:
        //     A vector that specifies the horizontal and vertical amounts to move the rectangle.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     This method is called on the System.Windows.Rect.Empty rectangle.
        public void Offset(Vector offsetVector)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Moves the rectangle by the specified horizontal and vertical amounts.
        //
        // Parameters:
        //   offsetX:
        //     The amount to move the rectangle horizontally.
        //
        //   offsetY:
        //     The amount to move the rectangle vertically.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     This method is called on the System.Windows.Rect.Empty rectangle.
        public void Offset(double offsetX, double offsetY)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Returns a rectangle that is offset from the specified rectangle by using
        //     the specified vector.
        //
        // Parameters:
        //   rect:
        //     The original rectangle.
        //
        //   offsetVector:
        //     A vector that specifies the horizontal and vertical offsets for the new rectangle.
        //
        // Returns:
        //     The resulting rectangle.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     rect is System.Windows.Rect.Empty.
        public static Rect Offset(Rect rect, Vector offsetVector)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Returns a rectangle that is offset from the specified rectangle by using
        //     the specified horizontal and vertical amounts.
        //
        // Parameters:
        //   rect:
        //     The rectangle to move.
        //
        //   offsetX:
        //     The horizontal offset for the new rectangle.
        //
        //   offsetY:
        //     The vertical offset for the new rectangle.
        //
        // Returns:
        //     The resulting rectangle.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     rect is System.Windows.Rect.Empty.
        public static Rect Offset(Rect rect, double offsetX, double offsetY)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Creates a new rectangle from the specified string representation.
        //
        // Parameters:
        //   source:
        //     The string representation of the rectangle, in the form "x, y, width, height".
        //
        // Returns:
        //     The resulting rectangle.
        public static Rect Parse(string source)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Multiplies the size of the current rectangle by the specified x and y values.
        //
        // Parameters:
        //   scaleX:
        //     The scale factor in the x-direction.
        //
        //   scaleY:
        //     The scale factor in the y-direction.
        public void Scale(double scaleX, double scaleY)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Returns a string representation of the rectangle.
        //
        // Returns:
        //     A string representation of the current rectangle. The string has the following
        //     form: "System.Windows.Rect.X,System.Windows.Rect.Y,System.Windows.Rect.Width,System.Windows.Rect.Height".
        public override string ToString()
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Returns a string representation of the rectangle by using the specified format
        //     provider.
        //
        // Parameters:
        //   provider:
        //     Culture-specific formatting information.
        //
        // Returns:
        //     A string representation of the current rectangle that is determined by the
        //     specified format provider.
        public string ToString(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Transforms the rectangle by applying the specified matrix.
        //
        // Parameters:
        //   matrix:
        //     A matrix that specifies the transformation to apply.
        public void Transform(Matrix matrix)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Returns the rectangle that results from applying the specified matrix to
        //     the specified rectangle.
        //
        // Parameters:
        //   rect:
        //     A rectangle that is the basis for the transformation.
        //
        //   matrix:
        //     A matrix that specifies the transformation to apply.
        //
        // Returns:
        //     The rectangle that results from the operation.
        public static Rect Transform(Rect rect, Matrix matrix)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Expands the current rectangle exactly enough to contain the specified point.
        //
        // Parameters:
        //   point:
        //     The point to include.
        public void Union(Point point)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Expands the current rectangle exactly enough to contain the specified rectangle.
        //
        // Parameters:
        //   rect:
        //     The rectangle to include.
        public void Union(Rect rect)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Creates a rectangle that is exactly large enough to include the specified
        //     rectangle and the specified point.
        //
        // Parameters:
        //   rect:
        //     The rectangle to include.
        //
        //   point:
        //     The point to include.
        //
        // Returns:
        //     A rectangle that is exactly large enough to contain the specified rectangle
        //     and the specified point.
        public static Rect Union(Rect rect, Point point)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Creates a rectangle that is exactly large enough to contain the two specified
        //     rectangles.
        //
        // Parameters:
        //   rect1:
        //     The first rectangle to include.
        //
        //   rect2:
        //     The second rectangle to include.
        //
        // Returns:
        //     The resulting rectangle.
        public static Rect Union(Rect rect1, Rect rect2)
        {
            throw new NotImplementedException();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            throw new NotImplementedException();
        }
    }
}
