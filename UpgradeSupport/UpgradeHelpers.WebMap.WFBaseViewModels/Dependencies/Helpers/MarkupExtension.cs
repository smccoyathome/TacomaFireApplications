using System;

namespace UpgradeHelpers.Helpers
{
	public abstract class MarkupExtension
    {
        // Summary:
        //     Initializes a new instance of a class derived from System.Windows.Markup.MarkupExtension.
        protected MarkupExtension() { }

        // Summary:
        //     When implemented in a derived class, returns an object that is set as the
        //     value of the target property for this markup extension.
        //
        // Parameters:
        //   serviceProvider:
        //     Object that can provide services for the markup extension.
        //
        // Returns:
        //     The object value to set on the property where the extension is applied.
        public abstract object ProvideValue(IServiceProvider serviceProvider);
    }
}