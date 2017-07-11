using System;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Converts instances of System.String to and from instances of System.Windows.Input.Key.
	public class KeyValueSerializer : ValueSerializer
    {
        // Summary:
        //     Initializes a new instance of the System.Windows.Input.KeyValueSerializer
        //     class.
        public KeyValueSerializer()
        {
            throw new NotImplementedException();
        }

        // Summary:
        //     Determines if the specified System.String can be convert to an instance of
        //     System.Windows.Input.Key.
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
        //     Determines if the specified System.Windows.Input.Key can be converted to
        //     a System.String.
        //
        // Parameters:
        //   value:
        //     The key to evaluate for conversion.
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
        //     Converts a System.String into a System.Windows.Input.Key.
        //
        // Parameters:
        //   value:
        //     The string to convert into a System.Windows.Input.Key.
        //
        //   context:
        //     Context information that is used for conversion.
        //
        // Returns:
        //     A new instance of System.Windows.Input.Key based on the supplied value.
        public override object ConvertFromString(string value, IValueSerializerContext context)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Converts an instance of System.Windows.Input.Key to a System.String.
        //
        // Parameters:
        //   value:
        //     The key to convert into a string.
        //
        //   context:
        //     Context information that is used for conversion.
        //
        // Returns:
        //     A string representation of the specified System.Windows.Input.Key.
        public override string ConvertToString(object value, IValueSerializerContext context)
        {
            throw new NotImplementedException();
        }
    }
}
