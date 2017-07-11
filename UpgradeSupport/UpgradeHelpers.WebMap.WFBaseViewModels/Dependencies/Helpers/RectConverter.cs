using System;
using System.ComponentModel;
using System.Globalization;

namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Converts instances of other types to and from instances of System.Windows.Rect.
	public sealed class RectConverter : TypeConverter
    {
        // Summary:
        //     Initializes a new instance of the System.Windows.RectConverter class.
        public RectConverter()
        {
            throw new NotImplementedException();
        }

        // Summary:
        //     Determines whether an object can be converted from a given type to an instance
        //     of System.Windows.Rect.
        //
        // Parameters:
        //   context:
        //     Provides contextual information required for conversion.
        //
        //   sourceType:
        //     The type of the source that is being evaluated for conversion.
        //
        // Returns:
        //     true if the type can be converted to a System.Windows.Rect; otherwise, false.
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Determines whether a System.Windows.Rect can be converted to the specified
        //     type.
        //
        // Parameters:
        //   context:
        //     Provides contextual information required for conversion.
        //
        //   destinationType:
        //     The desired type this System.Windows.Rect is being evaluated for conversion.
        //
        // Returns:
        //     true if a System.Windows.Rect can be converted to destinationType; otherwise,
        //     false.
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Attempts to convert the specified object to a System.Windows.Rect.
        //
        // Parameters:
        //   context:
        //     Provides contextual information required for conversion.
        //
        //   culture:
        //     Cultural information which is respected when converting.
        //
        //   value:
        //     The object being converted.
        //
        // Returns:
        //     The System.Windows.Rect created from converting value.
        //
        // Exceptions:
        //   System.NotSupportedException:
        //     Thrown if the specified object is NULL or is a type that cannot be converted
        //     to a System.Windows.Rect.
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Attempts to convert a System.Windows.Rect to the specified type.
        //
        // Parameters:
        //   context:
        //     Provides contextual information required for conversion.
        //
        //   culture:
        //     Cultural information which is respected during conversion.
        //
        //   value:
        //     The System.Windows.Rect to convert.
        //
        //   destinationType:
        //     The type to convert this System.Windows.Rect to.
        //
        // Returns:
        //     The object created from converting this System.Windows.Rect.
        //
        // Exceptions:
        //   System.NotSupportedException:
        //     value is null.- or - value is not a System.Windows.Rect.- or - The destinationType
        //     is not one of the valid types for conversion.
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            throw new NotImplementedException();
        }
    }
}
