using System;

namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Represents a single data point collected from the digitizer and stylus.
	public struct StylusPoint : IEquatable<StylusPoint>
    {
        // Summary:
        //     Specifies the largest valid value for a pair of (x, y) coordinates.
        public static readonly double MaxXY;

        //
        // Summary:
        //     Specifies the smallest valid value for a pair of (x, y) coordinates.
        public static readonly double MinXY;

        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Input.StylusPoint class
        //     using specified (x, y) coordinates.
        //
        // Parameters:
        //   x:
        //
        //   y:
        public StylusPoint(double x, double y)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Input.StylusPoint class
        //     using specified (x, y) coordinates and pressure.
        //
        // Parameters:
        //   x:
        //     The x-coordinate of the System.Windows.Input.StylusPoint.
        //
        //   y:
        //     The y-coordinate of the System.Windows.Input.StylusPoint.
        //
        //   pressureFactor:
        //     The amount of pressure applied to the System.Windows.Input.StylusPoint.
        //
        // Exceptions:
        //   System.ArgumentOutOfRangeException:
        //     pressureFactor is less than 0 or greater than 1.
        public StylusPoint(double x, double y, float pressureFactor)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Input.StylusPoint class
        //     using specified (x, y) coordinates, a pressureFactor, and additional parameters
        //     specified in the System.Windows.Input.StylusPointDescription.
        //
        // Parameters:
        //   x:
        //
        //   y:
        //
        //   pressureFactor:
        //     The amount of pressure applied to the System.Windows.Input.StylusPoint.
        //
        //   stylusPointDescription:
        //     A System.Windows.Input.StylusPointDescription that specifies the additional
        //     properties stored in the System.Windows.Input.StylusPoint.
        //
        //   additionalValues:
        //     An array of 32-bit signed integers that contains the values of the properties
        //     defined in stylusPointDescription.
        //
        // Exceptions:
        //   System.ArgumentOutOfRangeException:
        //     pressureFactor is less than 0 or greater than 1.-or-The values in additionalValues
        //     that correspond to button properties are not 0 or 1.
        //
        //   System.ArgumentException:
        //     The number of values in additionalValues does not match the number of properties
        //     in stylusPointDescription minus 3.
        public StylusPoint(double x, double y, float pressureFactor, StylusPointDescription stylusPointDescription, int[] additionalValues)
        {
            throw new NotImplementedException();
        }

        // Summary:
        //     Returns a Boolean value which indicates whether the specified System.Windows.Input.StylusPoint
        //     objects are unequal.
        //
        // Parameters:
        //   stylusPoint1:
        //     The first System.Windows.Input.StylusPoint to compare.
        //
        //   stylusPoint2:
        //     The second System.Windows.Input.StylusPoint to compare.
        //
        // Returns:
        //     true if the specified System.Windows.Input.StylusPoint objects are unequal;
        //     otherwise, false.
        public static bool operator !=(StylusPoint stylusPoint1, StylusPoint stylusPoint2)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Compares two specified System.Windows.Input.StylusPoint objects and determines
        //     whether they are equal.
        //
        // Parameters:
        //   stylusPoint1:
        //     The first System.Windows.Input.StylusPoint to compare.
        //
        //   stylusPoint2:
        //     The second System.Windows.Input.StylusPoint to compare.
        //
        // Returns:
        //     true if the System.Windows.Input.StylusPoint objects are equal; otherwise,
        //     false.
        public static bool operator ==(StylusPoint stylusPoint1, StylusPoint stylusPoint2)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Casts the specified System.Windows.Input.StylusPoint to a System.Windows.Point.
        //
        // Parameters:
        //   stylusPoint:
        //     The System.Windows.Input.StylusPoint to cast to a System.Windows.Point.
        //
        // Returns:
        //     A System.Windows.Point that contains the same (x, y) coordinates as stylusPoint.
        public static explicit operator Point(StylusPoint stylusPoint)
        {
            throw new NotImplementedException();
        }


        // Summary:
        //     Gets or sets the System.Windows.Input.StylusPointDescription that specifies
        //     the properties stored in the System.Windows.Input.StylusPoint.
        //
        // Returns:
        //     The System.Windows.Input.StylusPointDescription specifies the properties
        //     stored in the System.Windows.Input.StylusPoint.
        public StylusPointDescription Description { get { throw new NotImplementedException(); } internal set { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets or sets a value between 0 and 1 that reflects the amount of pressure
        //     the stylus applies to the digitizer's surface when the System.Windows.Input.StylusPoint
        //     is created.
        //
        // Returns:
        //     Value between 0 and 1 indicating the amount of pressure the stylus applies
        //     to the digitizer's surface as the System.Windows.Input.StylusPoint is created.
        //
        // Exceptions:
        //   System.ArgumentOutOfRangeException:
        //     The System.Windows.Input.StylusPoint.PressureFactor property is set to a
        //     value less than 0 or greater than 1.
        public float PressureFactor { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets or sets the value for the x-coordinate of the System.Windows.Input.StylusPoint.
        //
        // Returns:
        //     The x-coordinate of the System.Windows.Input.StylusPoint.
        public double X { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets or sets the y-coordinate of the System.Windows.Input.StylusPoint.
        //
        // Returns:
        //     The y-coordinate of the System.Windows.Input.StylusPoint.
        public double Y { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        // Summary:
        //     Returns a value indicating whether the specified object is equal to the System.Windows.Input.StylusPoint.
        //
        // Parameters:
        //   o:
        //     The System.Windows.Input.StylusPoint to compare to the current System.Windows.Input.StylusPoint.
        //
        // Returns:
        //     true if the objects are equal; otherwise, false.
        public override bool Equals(object o)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Returns a Boolean value that indicates whether the specified System.Windows.Input.StylusPoint
        //     is equal to the current System.Windows.Input.StylusPoint.
        //
        // Parameters:
        //   value:
        //     The System.Windows.Input.StylusPoint to compare to the current System.Windows.Input.StylusPoint.
        //
        // Returns:
        //     true if the System.Windows.Input.StylusPoint objects are equal; otherwise,
        //     false.
        public bool Equals(StylusPoint value)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Returns a Boolean value that indicates whether the two specified System.Windows.Input.StylusPoint
        //     objects are equal.
        //
        // Parameters:
        //   stylusPoint1:
        //     The first System.Windows.Input.StylusPoint to compare.
        //
        //   stylusPoint2:
        //     The second System.Windows.Input.StylusPoint to compare.
        //
        // Returns:
        //     true if the System.Windows.Input.StylusPoint objects are equal; otherwise,
        //     false.
        public static bool Equals(StylusPoint stylusPoint1, StylusPoint stylusPoint2)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
        
        //
        // Summary:
        //     Returns the value of the specified property.
        //
        // Parameters:
        //   stylusPointProperty:
        //     The System.Windows.Input.StylusPointProperty that specifies which property
        //     value to get.
        //
        // Returns:
        //     The value of the specified System.Windows.Input.StylusPointProperty.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     stylusPointProperty is not one of the properties in System.Windows.Input.StylusPoint.Description.
        public int GetPropertyValue(StylusPointProperty stylusPointProperty)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Returns whether the current System.Windows.Input.StylusPoint contains the
        //     specified property.
        //
        // Parameters:
        //   stylusPointProperty:
        //     The System.Windows.Input.StylusPointProperty to check for in the System.Windows.Input.StylusPoint.
        //
        // Returns:
        //     true if the specified System.Windows.Input.StylusPointProperty is in the
        //     current System.Windows.Input.StylusPoint; otherwise, false.
        public bool HasProperty(StylusPointProperty stylusPointProperty)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Sets the specified property to the specified value.
        //
        // Parameters:
        //   stylusPointProperty:
        //     The System.Windows.Input.StylusPointProperty that specifies which property
        //     value to set.
        //
        //   value:
        //     The value of the property.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     stylusPointProperty is not one of the properties in System.Windows.Input.StylusPoint.Description.
        public void SetPropertyValue(StylusPointProperty stylusPointProperty, int value)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Converts a System.Windows.Input.StylusPoint to a System.Windows.Point.
        //
        // Returns:
        //     A System.Windows.Point structure.
        public Point ToPoint()
        {
            throw new NotImplementedException();
        }
    }
}
