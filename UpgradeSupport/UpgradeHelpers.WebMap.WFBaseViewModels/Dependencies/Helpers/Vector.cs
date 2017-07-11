using System;

namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Represents a displacement in 2-D space.
	[Serializable]
    [TypeConverter(typeof(VectorConverter))]
    [ValueSerializer(typeof(VectorValueSerializer))]
    public struct Vector : IFormattable
    {
        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Vector structure.
        //
        // Parameters:
        //   x:
        //     The System.Windows.Vector.X-offset of the new System.Windows.Vector.
        //
        //   y:
        //     The System.Windows.Vector.Y-offset of the new System.Windows.Vector.
        public Vector(double x, double y)
        {
            throw new NotImplementedException();
        }

        // Summary:
        //     Negates the specified vector.
        //
        // Parameters:
        //   vector:
        //     The vector to negate.
        //
        // Returns:
        //     A vector with System.Windows.Vector.X and System.Windows.Vector.Y values
        //     opposite of the System.Windows.Vector.X and System.Windows.Vector.Y values
        //     of vector.
        public static Vector operator -(Vector vector)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Subtracts one specified vector from another.
        //
        // Parameters:
        //   vector1:
        //     The vector from which vector2 is subtracted.
        //
        //   vector2:
        //     The vector to subtract from vector1.
        //
        // Returns:
        //     The difference between vector1 and vector2.
        public static Vector operator -(Vector vector1, Vector vector2)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Compares two vectors for inequality.
        //
        // Parameters:
        //   vector1:
        //     The first vector to compare.
        //
        //   vector2:
        //     The second vector to compare.
        //
        // Returns:
        //     true if the System.Windows.Vector.X and System.Windows.Vector.Y components
        //     of vector1 and vector2 are different; otherwise, false.
        public static bool operator !=(Vector vector1, Vector vector2)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Multiplies the specified scalar by the specified vector and returns the resulting
        //     vector.
        //
        // Parameters:
        //   scalar:
        //     The scalar to multiply.
        //
        //   vector:
        //     The vector to multiply.
        //
        // Returns:
        //     The result of multiplying scalar and vector.
        public static Vector operator *(double scalar, Vector vector)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Multiplies the specified vector by the specified scalar and returns the resulting
        //     vector.
        //
        // Parameters:
        //   vector:
        //     The vector to multiply.
        //
        //   scalar:
        //     The scalar to multiply.
        //
        // Returns:
        //     The result of multiplying vector and scalar.
        public static Vector operator *(Vector vector, double scalar)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Transforms the coordinate space of the specified vector using the specified
        //     System.Windows.Media.Matrix.
        //
        // Parameters:
        //   vector:
        //     The vector to transform.
        //
        //   matrix:
        //     The transformation to apply to vector.
        //
        // Returns:
        //     The result of transforming vector by matrix.
        public static Vector operator *(Vector vector, Matrix matrix)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Calculates the dot product of the two specified vector structures and returns
        //     the result as a System.Double.
        //
        // Parameters:
        //   vector1:
        //     The first vector to multiply.
        //
        //   vector2:
        //     The second vector to multiply.
        //
        // Returns:
        //     Returns a System.Double containing the scalar dot product of vector1 and
        //     vector2, which is calculated using the following formula:vector1.X * vector2.X
        //     + vector1.Y * vector2.Y
        public static double operator *(Vector vector1, Vector vector2)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Divides the specified vector by the specified scalar and returns the resulting
        //     vector.
        //
        // Parameters:
        //   vector:
        //     The vector to divide.
        //
        //   scalar:
        //     The scalar by which vector will be divided.
        //
        // Returns:
        //     The result of dividing vector by scalar.
        public static Vector operator /(Vector vector, double scalar)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Translates a point by the specified vector and returns the resulting point.
        //
        // Parameters:
        //   vector:
        //     The vector used to translate point.
        //
        //   point:
        //     The point to translate.
        //
        // Returns:
        //     The result of translating point by vector.
        public static Point operator +(Vector vector, Point point)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Adds two vectors and returns the result as a vector.
        //
        // Parameters:
        //   vector1:
        //     The first vector to add.
        //
        //   vector2:
        //     The second vector to add.
        //
        // Returns:
        //     The sum of vector1 and vector2.
        public static Vector operator +(Vector vector1, Vector vector2)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Compares two vectors for equality.
        //
        // Parameters:
        //   vector1:
        //     The first vector to compare.
        //
        //   vector2:
        //     The second vector to compare.
        //
        // Returns:
        //     true if the System.Windows.Vector.X and System.Windows.Vector.Y components
        //     of vector1 and vector2 are equal; otherwise, false.
        public static bool operator ==(Vector vector1, Vector vector2)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Creates a System.Windows.Size from the offsets of this vector.
        //
        // Parameters:
        //   vector:
        //     The vector to convert.
        //
        // Returns:
        //     A System.Windows.Size with a System.Windows.Size.Width equal to the absolute
        //     value of this vector's System.Windows.Vector.X property and a System.Windows.Size.Height
        //     equal to the absolute value of this vector's System.Windows.Vector.Y property.
        public static explicit operator Size(Vector vector)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Creates a System.Windows.Point with the System.Windows.Vector.X and System.Windows.Vector.Y
        //     values of this vector.
        //
        // Parameters:
        //   vector:
        //     The vector to convert.
        //
        // Returns:
        //     A point with System.Windows.Point.X- and System.Windows.Point.Y-coordinate
        //     values equal to the System.Windows.Vector.X and System.Windows.Vector.Y offset
        //     values of vector.
        public static explicit operator Point(Vector vector)
        {
            throw new NotImplementedException();
        }

        // Summary:
        //     Gets the length of this vector.
        //
        // Returns:
        //     The length of this vector.
        public double Length { get { throw new NotImplementedException(); } }
        //
        // Summary:
        //     Gets the square of the length of this vector.
        //
        // Returns:
        //     The square of the System.Windows.Vector.Length of this vector.
        public double LengthSquared { get { throw new NotImplementedException(); } }
        //
        // Summary:
        //     Gets or sets the System.Windows.Vector.X component of this vector.
        //
        // Returns:
        //     The System.Windows.Vector.X component of this vector. The default value is
        //     0.
        public double X { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        //
        // Summary:
        //     Gets or sets the System.Windows.Vector.Y component of this vector.
        //
        // Returns:
        //     The System.Windows.Vector.Y component of this vector. The default value is
        //     0.
        public double Y { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        // Summary:
        //     Translates the specified point by the specified vector and returns the resulting
        //     point.
        //
        // Parameters:
        //   vector:
        //     The amount to translate the specified point.
        //
        //   point:
        //     The point to translate.
        //
        // Returns:
        //     The result of translating point by vector.
        public static Point Add(Vector vector, Point point)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Adds two vectors and returns the result as a System.Windows.Vector structure.
        //
        // Parameters:
        //   vector1:
        //     The first vector to add.
        //
        //   vector2:
        //     The second vector to add.
        //
        // Returns:
        //     The sum of vector1 and vector2.
        public static Vector Add(Vector vector1, Vector vector2)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Retrieves the angle, expressed in degrees, between the two specified vectors.
        //
        // Parameters:
        //   vector1:
        //     The first vector to evaluate.
        //
        //   vector2:
        //     The second vector to evaluate.
        //
        // Returns:
        //     The angle, in degrees, between vector1 and vector2.
        public static double AngleBetween(Vector vector1, Vector vector2)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Calculates the cross product of two vectors.
        //
        // Parameters:
        //   vector1:
        //     The first vector to evaluate.
        //
        //   vector2:
        //     The second vector to evaluate.
        //
        // Returns:
        //     The cross product of vector1 and vector2. The following formula is used to
        //     calculate the cross product: (Vector1.X * Vector2.Y) - (Vector1.Y * Vector2.X)
        public static double CrossProduct(Vector vector1, Vector vector2)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Calculates the determinant of two vectors.
        //
        // Parameters:
        //   vector1:
        //     The first vector to evaluate.
        //
        //   vector2:
        //     The second vector to evaluate.
        //
        // Returns:
        //     The determinant of vector1 and vector2.
        public static double Determinant(Vector vector1, Vector vector2)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Divides the specified vector by the specified scalar and returns the result
        //     as a System.Windows.Vector.
        //
        // Parameters:
        //   vector:
        //     The vector structure to divide.
        //
        //   scalar:
        //     The amount by which vector is divided.
        //
        // Returns:
        //     The result of dividing vector by scalar.
        public static Vector Divide(Vector vector, double scalar)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Determines whether the specified System.Object is a System.Windows.Vector
        //     structure and, if it is, whether it has the same System.Windows.Vector.X
        //     and System.Windows.Vector.Y values as this vector.
        //
        // Parameters:
        //   o:
        //     The vector to compare.
        //
        // Returns:
        //     true if o is a System.Windows.Vector and has the same System.Windows.Vector.X
        //     and System.Windows.Vector.Y values as this vector; otherwise, false.
        public override bool Equals(object o)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Compares two vectors for equality.
        //
        // Parameters:
        //   value:
        //     The vector to compare with this vector.
        //
        // Returns:
        //     true if value has the same System.Windows.Vector.X and System.Windows.Vector.Y
        //     values as this vector; otherwise, false.
        public bool Equals(Vector value)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Compares the two specified vectors for equality.
        //
        // Parameters:
        //   vector1:
        //     The first vector to compare.
        //
        //   vector2:
        //     The second vector to compare.
        //
        // Returns:
        //     true if t he System.Windows.Vector.X and System.Windows.Vector.Y components
        //     of vector1 and vector2 are equal; otherwise, false.
        public static bool Equals(Vector vector1, Vector vector2)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Returns the hash code for this vector.
        //
        // Returns:
        //     The hash code for this instance.
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Multiplies the specified scalar by the specified vector and returns the resulting
        //     System.Windows.Vector.
        //
        // Parameters:
        //   scalar:
        //     The scalar to multiply.
        //
        //   vector:
        //     The vector to multiply.
        //
        // Returns:
        //     The result of multiplying scalar and vector.
        public static Vector Multiply(double scalar, Vector vector)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Multiplies the specified vector by the specified scalar and returns the resulting
        //     System.Windows.Vector.
        //
        // Parameters:
        //   vector:
        //     The vector to multiply.
        //
        //   scalar:
        //     The scalar to multiply.
        //
        // Returns:
        //     The result of multiplying vector and scalar.
        public static Vector Multiply(Vector vector, double scalar)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Transforms the coordinate space of the specified vector using the specified
        //     System.Windows.Media.Matrix.
        //
        // Parameters:
        //   vector:
        //     The vector structure to transform.
        //
        //   matrix:
        //     The transformation to apply to vector.
        //
        // Returns:
        //     The result of transforming vector by matrix.
        public static Vector Multiply(Vector vector, Matrix matrix)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Calculates the dot product of the two specified vectors and returns the result
        //     as a System.Double.
        //
        // Parameters:
        //   vector1:
        //     The first vector to multiply.
        //
        //   vector2:
        //     The second vector structure to multiply.
        //
        // Returns:
        //     A System.Double containing the scalar dot product of vector1 and vector2,
        //     which is calculated using the following formula: (vector1.X * vector2.X)
        //     + (vector1.Y * vector2.Y)
        public static double Multiply(Vector vector1, Vector vector2)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Negates this vector. The vector has the same magnitude as before, but its
        //     direction is now opposite.
        public void Negate()
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Normalizes this vector.
        public void Normalize()
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Converts a string representation of a vector into the equivalent System.Windows.Vector
        //     structure.
        //
        // Parameters:
        //   source:
        //     The string representation of the vector.
        //
        // Returns:
        //     The equivalent System.Windows.Vector structure.
        public static Vector Parse(string source)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Subtracts the specified vector from another specified vector.
        //
        // Parameters:
        //   vector1:
        //     The vector from which vector2 is subtracted.
        //
        //   vector2:
        //     The vector to subtract from vector1.
        //
        // Returns:
        //     The difference between vector1 and vector2.
        public static Vector Subtract(Vector vector1, Vector vector2)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Returns the string representation of this System.Windows.Vector structure.
        //
        // Returns:
        //     A string that represents the System.Windows.Vector.X and System.Windows.Vector.Y
        //     values of this System.Windows.Vector.
        public override string ToString()
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Returns the string representation of this System.Windows.Vector structure
        //     with the specified formatting information.
        //
        // Parameters:
        //   provider:
        //     The culture-specific formatting information.
        //
        // Returns:
        //     A string that represents the System.Windows.Vector.X and System.Windows.Vector.Y
        //     values of this System.Windows.Vector.
        public string ToString(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            throw new NotImplementedException();
        }
    }
}
