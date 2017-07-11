using System;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Converts instances of System.String to and from instances of System.Windows.Input.ModifierKeys.
	public class ModifierKeysValueSerializer : ValueSerializer
    {
        // Summary:
        //     Initializes a new instance of the System.Windows.Input.ModifierKeysValueSerializer
        //     class.
        public ModifierKeysValueSerializer()
        {
            throw new NotImplementedException();
        }

        // Summary:
        //     Determines if the specified System.String can be convert to an instance of
        //     System.Windows.Input.ModifierKeys.
        //
        // Parameters:
        //   value:
        //     String to evaluate for conversion.
        //
        //   context:
        //     Context information that is used for conversion.
        //
        // Returns:
        //     true if the value can be converted; otherwise, false.
        public override bool CanConvertFromString(string value, IValueSerializerContext context)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Determines if the specified System.Windows.Input.ModifierKeys can be converted
        //     to a System.String.
        //
        // Parameters:
        //   value:
        //     The modifier keys to evaluate for conversion.
        //
        //   context:
        //     Context information that is used for conversion.
        //
        // Returns:
        //     true if value can be converted into a System.String; otherwise, false.
        public override bool CanConvertToString(object value, IValueSerializerContext context)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Converts a System.String into a System.Windows.Input.ModifierKeys.
        //
        // Parameters:
        //   value:
        //     The string to convert into a System.Windows.Input.ModifierKeys.
        //
        //   context:
        //     Context information that is used for conversion.
        //
        // Returns:
        //     A new instance of System.Windows.Input.ModifierKeys based on the supplied
        //     value.
        public override object ConvertFromString(string value, IValueSerializerContext context)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Converts an instance of System.Windows.Input.ModifierKeys to a System.String.
        //
        // Parameters:
        //   value:
        //     The key to convert into a string.
        //
        //   context:
        //     Context information that is used for conversion.
        //
        // Returns:
        //     A string representation of the specified System.Windows.Input.ModifierKeys.
        public override string ConvertToString(object value, IValueSerializerContext context)
        {
            throw new NotImplementedException();
        }
    }
}
