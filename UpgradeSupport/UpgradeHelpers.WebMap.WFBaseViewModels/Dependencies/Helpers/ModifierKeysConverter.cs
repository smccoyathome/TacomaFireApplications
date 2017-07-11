using System;
using System.ComponentModel;
using System.Globalization;

namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Converts a System.Windows.Input.ModifierKeys object to and from other types.
	public class ModifierKeysConverter : TypeConverter
    {
        // Summary:
        //     Initializes a new instance of the System.Windows.Input.ModifierKeysConverter
        //     class.
        public ModifierKeysConverter()
        {
            throw new NotImplementedException();
        }

        // Summary:
        //     Determines whether an object of the specified type can be converted to an
        //     instance of System.Windows.Input.ModifierKeys, using the specified context.
        //
        // Parameters:
        //   context:
        //     A format context that provides information about the environment from which
        //     this converter is being invoked.
        //
        //   sourceType:
        //     The type being evaluated for conversion.
        //
        // Returns:
        //     true if this converter can perform the operation; otherwise, false.
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Determines whether an instance of System.Windows.Input.ModifierKeys can be
        //     converted to the specified type, using the specified context.
        //
        // Parameters:
        //   context:
        //     A format context that provides information about the environment from which
        //     this converter is being invoked.
        //
        //   destinationType:
        //     The type being evaluated for conversion.
        //
        // Returns:
        //     true if this converter can perform the operation; otherwise, false.
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Attempts to convert the specified object to a System.Windows.Input.ModifierKeys,
        //     using the specified context.
        //
        // Parameters:
        //   context:
        //     A format context that provides information about the environment from which
        //     this converter is being invoked.
        //
        //   culture:
        //     Culture specific information.
        //
        //   source:
        //     The object to convert.
        //
        // Returns:
        //     The converted object.
        //
        // Exceptions:
        //   System.NotSupportedException:
        //     source cannot be converted.
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object source)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Attempts to convert a System.Windows.Input.ModifierKeys to the specified
        //     type, using the specified context.
        //
        // Parameters:
        //   context:
        //     A format context that provides information about the environment from which
        //     this converter is being invoked.
        //
        //   culture:
        //     Culture specific information.
        //
        //   value:
        //     The object to convert.
        //
        //   destinationType:
        //     The type to convert the object to.
        //
        // Returns:
        //     The converted object.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     destinationType is null.
        //
        //   System.ComponentModel.InvalidEnumArgumentException:
        //     value does not map to a valid System.Windows.Input.ModifierKeys.
        //
        //   System.NotSupportedException:
        //     value cannot be converted.
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Determines whether the specified value is a valid System.Windows.Input.ModifierKeys.
        //
        // Parameters:
        //   modifierKeys:
        //     The value to check for validity.
        //
        // Returns:
        //     true if valid; otherwise, false.
        public static bool IsDefinedModifierKeys(ModifierKeys modifierKeys)
        {
            throw new NotImplementedException();
        }
    }
}
