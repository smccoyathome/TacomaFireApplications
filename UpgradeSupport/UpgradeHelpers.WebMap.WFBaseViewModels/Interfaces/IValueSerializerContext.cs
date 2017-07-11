using System;
using System.ComponentModel;
using UpgradeHelpers.Helpers;

namespace UpgradeHelpers.Interfaces
{
	// Summary:
	//     Defines a context that is provided to a System.Windows.Markup.ValueSerializer
	//     which can be used to specify special cases of serialization or different
	//     modes of serialization.
	public interface IValueSerializerContext : ITypeDescriptorContext, IServiceProvider
    {
        // Summary:
        //     Gets a System.Windows.Markup.ValueSerializer for the given property descriptor.
        //
        // Parameters:
        //   descriptor:
        //     The descriptor of the property being converted.
        //
        // Returns:
        //     A System.Windows.Markup.ValueSerializer capable of serializing the specified
        //     property.
        ValueSerializer GetValueSerializerFor(PropertyDescriptor descriptor);

        //
        // Summary:
        //     Gets the System.Windows.Markup.ValueSerializer associated with the specified
        //     type.
        //
        // Parameters:
        //   type:
        //     The type of the value being converted.
        //
        // Returns:
        //     A System.Windows.Markup.ValueSerializer capable of serializing the specified
        //     type.
        ValueSerializer GetValueSerializerFor(Type type);
    }
}
