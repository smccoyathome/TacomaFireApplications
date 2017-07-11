using System;

namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Specifies which System.Windows.Markup.ValueSerializer class to use for a
	//     particular type or overrides which System.Windows.Markup.ValueSerializer
	//     to use for a property.
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
    public sealed class ValueSerializerAttribute : Attribute
    {
        // Summary:
        //     Initializes a new instance of the System.Windows.Markup.ValueSerializerAttribute
        //     class, using the specified type name as the data converter for the object
        //     this attribute is bound to.
        //
        // Parameters:
        //   valueSerializerTypeName:
        //     The fully qualified type name of the System.Windows.Markup.ValueSerializer
        //     class to use for data conversion for the object this attribute is bound to.
        public ValueSerializerAttribute(string valueSerializerTypeName)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Markup.ValueSerializerAttribute
        //     class, using the specified type as the data converter for the object this
        //     attribute is bound to.
        //
        // Parameters:
        //   valueSerializerType:
        //     A type that represents the type of the System.Windows.Markup.ValueSerializer
        //     class to use for data conversion for the object this attribute is bound to.
        public ValueSerializerAttribute(Type valueSerializerType)
        {
            throw new NotImplementedException();
        }

        // Summary:
        //     Gets the type of the System.Windows.Markup.ValueSerializer class to use for
        //     data conversion for the object this attribute is bound to.
        //
        // Returns:
        //     The type.
        public Type ValueSerializerType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        //
        // Summary:
        //     Gets the assembly qualified name of the System.Windows.Markup.ValueSerializer
        //     type for this type or property.
        //
        // Returns:
        //     The name of the type.
        public string ValueSerializerTypeName
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
