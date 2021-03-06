﻿using System;

namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Specifies what type to use as a converter for the object this attribute is
	//     bound to. This class cannot be inherited.
	[AttributeUsage(AttributeTargets.All)]
    public sealed class TypeConverterAttribute : Attribute
    {
        // Summary:
        //     Specifies the type to use as a converter for the object this attribute is
        //     bound to. This static field is read-only.
        public static readonly TypeConverterAttribute Default;

        // Summary:
        //     Initializes a new instance of the System.ComponentModel.TypeConverterAttribute
        //     class with the default type converter, which is an empty string ("").
        public TypeConverterAttribute()
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Initializes a new instance of the System.ComponentModel.TypeConverterAttribute
        //     class, using the specified type name as the data converter for the object
        //     this attribute is bound to.
        //
        // Parameters:
        //   typeName:
        //     The fully qualified name of the class to use for data conversion for the
        //     object this attribute is bound to.
        public TypeConverterAttribute(string typeName)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Initializes a new instance of the System.ComponentModel.TypeConverterAttribute
        //     class, using the specified type as the data converter for the object this
        //     attribute is bound to.
        //
        // Parameters:
        //   type:
        //     A System.Type that represents the type of the converter class to use for
        //     data conversion for the object this attribute is bound to.
        public TypeConverterAttribute(Type type)
        {
            throw new NotImplementedException();
        }

        // Summary:
        //     Gets the fully qualified type name of the System.Type to use as a converter
        //     for the object this attribute is bound to.
        //
        // Returns:
        //     The fully qualified type name of the System.Type to use as a converter for
        //     the object this attribute is bound to, or an empty string ("") if none exists.
        //     The default value is an empty string ("").
        public string ConverterTypeName { get { throw new NotImplementedException(); } }

        // Summary:
        //     Returns whether the value of the given object is equal to the current System.ComponentModel.TypeConverterAttribute.
        //
        // Parameters:
        //   obj:
        //     The object to test the value equality of.
        //
        // Returns:
        //     true if the value of the given object is equal to that of the current; otherwise,
        //     false.
        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Returns the hash code for this instance.
        //
        // Returns:
        //     A hash code for the current System.ComponentModel.TypeConverterAttribute.
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
