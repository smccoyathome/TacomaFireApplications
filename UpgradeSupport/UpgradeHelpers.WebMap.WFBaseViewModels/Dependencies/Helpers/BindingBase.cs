using System;
using System.ComponentModel;

namespace UpgradeHelpers.Helpers
{
	public abstract class BindingBase : MarkupExtension
    {
        // Summary:
        //     Gets or sets the name of the System.Windows.Data.BindingGroup to which this
        //     binding belongs.
        //
        // Returns:
        //     The name of the System.Windows.Data.BindingGroup to which this binding belongs.
        [DefaultValue("")]
        public string BindingGroupName { get; set; }
        //
        // Summary:
        //     Gets or sets the value to use when the binding is unable to return a value.
        //
        // Returns:
        //     The default value is System.Windows.DependencyProperty.UnsetValue.
        public object FallbackValue { get; set; }
        //
        // Summary:
        //     Gets or sets a string that specifies how to format the binding if it displays
        //     the bound value as a string.
        //
        // Returns:
        //     A string that specifies how to format the binding if it displays the bound
        //     value as a string.
        [DefaultValue("")]
        public string StringFormat { get; set; }
        //
        // Summary:
        //     Gets or sets the value that is used in the target when the value of the source
        //     is null.
        //
        // Returns:
        //     The value that is used in the target when the value of the source is null.
        public object TargetNullValue { get; set; }

        // Summary:
        //     Returns an object that should be set on the property where this binding and
        //     extension are applied.
        //
        // Parameters:
        //   serviceProvider:
        //     The object that can provide services for the markup extension. May be null;
        //     see the Remarks section for more information.
        //
        // Returns:
        //     The value to set on the binding target property.
        public override sealed object ProvideValue(IServiceProvider serviceProvider)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Returns a value that indicates whether serialization processes should serialize
        //     the effective value of the System.Windows.Data.BindingBase.FallbackValue
        //     property on instances of this class.
        //
        // Returns:
        //     true if the System.Windows.Data.BindingBase.FallbackValue property value
        //     should be serialized; otherwise, false.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeFallbackValue()
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Returns a value that indicates whether the System.Windows.Data.BindingBase.TargetNullValue
        //     property should be serialized.
        //
        // Returns:
        //     true if the System.Windows.Data.BindingBase.TargetNullValue property should
        //     be serialized; otherwise, false.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeTargetNullValue() 
        {
            throw new NotImplementedException();
        }
    }
}