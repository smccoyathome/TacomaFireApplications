﻿using System;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Converts instances of System.String to and from instances of System.Windows.Rect.
	public class RectValueSerializer : ValueSerializer
    {
        // Summary:
        //     Initializes a new instance of the System.Windows.Converters.RectValueSerializer
        //     class.
        public RectValueSerializer()
        {
            throw new NotImplementedException();
        }

        // Summary:
        //     Determines whether the specified System.String can be converted to an instance
        //     of System.Windows.Rect.
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
        //     Determines whether the specified System.Windows.Rect can be converted to
        //     a System.String.
        //
        // Parameters:
        //   value:
        //     The object to evaluate for conversion.
        //
        //   context:
        //     Context information that is used for conversion.
        //
        // Returns:
        //     true if value can be converted into a System.String; otherwise, false.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     value is not a System.Windows.Rect.
        public override bool CanConvertToString(object value, IValueSerializerContext context)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Converts a System.String into a System.Windows.Rect.
        //
        // Parameters:
        //   value:
        //     The string to convert.
        //
        //   context:
        //     Context information that is used for conversion.
        //
        // Returns:
        //     A new instance of System.Windows.Rect based on the supplied value.
        //
        // Exceptions:
        //   System.NotSupportedException:
        //     value is null
        public override object ConvertFromString(string value, IValueSerializerContext context)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Converts an instance of System.Windows.Rect to a System.String.
        //
        // Parameters:
        //   value:
        //     The object to convert into a string.
        //
        //   context:
        //     Context information that is used for conversion.
        //
        // Returns:
        //     A string representation of the specified System.Windows.Rect.
        //
        // Exceptions:
        //   System.NotSupportedException:
        //     value is not a System.Windows.Rect.
        public override string ConvertToString(object value, IValueSerializerContext context)
        {
            throw new NotImplementedException();
        }
    }
}
