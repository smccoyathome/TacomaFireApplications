using System;
using System.ComponentModel;
using System.Globalization;

namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Converts instances of other types to and from a System.Windows.Vector.
	public sealed class VectorConverter : TypeConverter
    {
        // Summary:
        //     Initializes a new instance of the System.Windows.Vector structure.
        public VectorConverter()
        {
            throw new NotImplementedException();
        }

        // Summary:
        //     Indicates whether an object can be converted from a given type to an instance
        //     of a System.Windows.Vector.
        //
        // Parameters:
        //   context:
        //     Describes the context information of a type.
        //
        //   sourceType:
        //     The source System.Type that is being queried for conversion support.
        //
        // Returns:
        //     true if objects of the specified type can be converted to a System.Windows.Vector;
        //     otherwise, false.
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Determines whether instances of System.Windows.Vector can be converted to
        //     the specified type.
        //
        // Parameters:
        //   context:
        //     Describes the context information of a type.
        //
        //   destinationType:
        //     The desired type this System.Windows.Vector is being evaluated for conversion.
        //
        // Returns:
        //     true if instances of System.Windows.Vector can be converted to destinationType;
        //     otherwise, false.
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Converts the specified object to a System.Windows.Vector.
        //
        // Parameters:
        //   context:
        //     Describes the context information of a type.
        //
        //   culture:
        //     Describes the System.Globalization.CultureInfo of the type being converted.
        //
        //   value:
        //     The object being converted.
        //
        // Returns:
        //     The System.Windows.Vector created from converting value.
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Converts the specified System.Windows.Vector to the specified type.
        //
        // Parameters:
        //   context:
        //     Describes the context information of a type.
        //
        //   culture:
        //     Describes the System.Globalization.CultureInfo of the type being converted.
        //
        //   value:
        //     The System.Windows.Vector to convert.
        //
        //   destinationType:
        //     The type to convert this System.Windows.Vector to.
        //
        // Returns:
        //     The object created from converting this System.Windows.Vector.
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            throw new NotImplementedException();
        }
    }
}
