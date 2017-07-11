using System;
using System.Collections.Generic;
using System.ComponentModel;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Abstract class to convert a type to and from a System.String.
	public abstract class ValueSerializer
    {
        // Summary:
        //     Initializes a new instance of the System.Windows.Markup.ValueSerializer class.
        protected ValueSerializer()
        {
            throw new NotImplementedException();
        }

        // Summary:
        //     Determines whether the specified System.String can be converted to an instance
        //     of the type that the implementation of System.Windows.Markup.ValueSerializer
        //     supports.
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
        public virtual bool CanConvertFromString(string value, IValueSerializerContext context)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Determines whether the specified object can be converted into a System.String.
        //
        // Parameters:
        //   value:
        //     The object to evaluate for conversion.
        //
        //   context:
        //     Context information that is used for conversion.
        //
        // Returns:
        //     true if the value can be converted into a System.String; otherwise, false.
        public virtual bool CanConvertToString(object value, IValueSerializerContext context)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Converts a System.String to an instance of the type that the implementation
        //     of System.Windows.Markup.ValueSerializer supports.
        //
        // Parameters:
        //   value:
        //     The string to convert.
        //
        //   context:
        //     Context information that is used for conversion.
        //
        // Returns:
        //     A new instance of the type that the implementation of System.Windows.Markup.ValueSerializer
        //     supports based on the supplied value.
        //
        // Exceptions:
        //   System.NotSupportedException:
        //     value cannot be converted.
        public virtual object ConvertFromString(string value, IValueSerializerContext context)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Converts the specified object to a System.String.
        //
        // Parameters:
        //   value:
        //     The object to convert into a string.
        //
        //   context:
        //     Context information that is used for conversion.
        //
        // Returns:
        //     A string representation of the specified object.
        //
        // Exceptions:
        //   System.NotSupportedException:
        //     value cannot be converted.
        public virtual string ConvertToString(object value, IValueSerializerContext context)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Returns an exception to throw when a conversion cannot be performed.
        //
        // Parameters:
        //   value:
        //     The object that could not be converted.
        //
        // Returns:
        //     An exception hat represents the exception to throw when a conversion cannot
        //     be performed.
        //
        // Exceptions:
        //   System.NotSupportedException:
        //     Automatically thrown by this method.
        protected Exception GetConvertFromException(object value)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Returns an exception to throw when a conversion cannot be performed.
        //
        // Parameters:
        //   value:
        //     The object that could not be converted.
        //
        //   destinationType:
        //     A type that represents the type the conversion was trying to convert to.
        //
        // Returns:
        //     An exception hat represents the exception to throw when a conversion cannot
        //     be performed.
        //
        // Exceptions:
        //   System.NotSupportedException:
        //     Automatically thrown by this method.
        protected Exception GetConvertToException(object value, Type destinationType)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Gets the System.Windows.Markup.ValueSerializer declared for the specified
        //     property.
        //
        // Parameters:
        //   descriptor:
        //     Descriptor for the property to be serialized.
        //
        // Returns:
        //     The serializer associated with the specified property.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     descriptor is null.
        public static ValueSerializer GetSerializerFor(PropertyDescriptor descriptor)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Gets the System.Windows.Markup.ValueSerializer declared for the specified
        //     type.
        //
        // Parameters:
        //   type:
        //     The type to get the System.Windows.Markup.ValueSerializer for.
        //
        // Returns:
        //     The serializer associated with the specified type.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     type is null.
        public static ValueSerializer GetSerializerFor(Type type)
        {
            throw new NotImplementedException();
        }
        
        //
        // Summary:
        //     Gets the System.Windows.Markup.ValueSerializer declared for the specified
        //     property, using the specified context.
        //
        // Parameters:
        //   descriptor:
        //     Descriptor for the property to be serialized.
        //
        //   context:
        //     Context information that is used for conversion.
        //
        // Returns:
        //     The serializer associated with the specified property.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     descriptor is null.
        public static ValueSerializer GetSerializerFor(PropertyDescriptor descriptor, IValueSerializerContext context)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Gets the System.Windows.Markup.ValueSerializer declared for the specified
        //     type, using the specified context.
        //
        // Parameters:
        //   type:
        //     The type to get the System.Windows.Markup.ValueSerializer for.
        //
        //   context:
        //     Context information that is used for conversion.
        //
        // Returns:
        //     The serializer associated with the specified type.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     type is null.
        public static ValueSerializer GetSerializerFor(Type type, IValueSerializerContext context)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Gets an enumeration of the types referenced by the System.Windows.Markup.ValueSerializer.
        //
        // Parameters:
        //   value:
        //     The value being serialized.
        //
        //   context:
        //     Context information that is used for conversion.
        //
        // Returns:
        //     The types converted by this serializer.
        public virtual IEnumerable<Type> TypeReferences(object value, IValueSerializerContext context)
        {
            throw new NotImplementedException();
        }
    }
}
