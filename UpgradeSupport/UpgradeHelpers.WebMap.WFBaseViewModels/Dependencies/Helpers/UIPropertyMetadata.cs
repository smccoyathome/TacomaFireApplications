using UpgradeHelpers.Events;

namespace UpgradeHelpers.Helpers
{
	public class UIPropertyMetadata : PropertyMetadata
    {
        // Summary:
        //     Initializes a new instance of the System.Windows.UIPropertyMetadata class.
        public UIPropertyMetadata() { }
        //
        // Summary:
        //     Initializes a new instance of the System.Windows.UIPropertyMetadata class,
        //     with the specified default value for the property.
        //
        // Parameters:
        //   defaultValue:
        //     The default value of the dependency property, usually provided as a value
        //     of some specific type.
        public UIPropertyMetadata(object defaultValue) { }
        //
        // Summary:
        //     Initializes a new instance of the System.Windows.UIPropertyMetadata class,
        //     with the specified PropertyChanged callback.
        //
        // Parameters:
        //   propertyChangedCallback:
        //     Reference to a handler implementation that is to be called by the property
        //     system whenever the effective value of the property changes.
        public UIPropertyMetadata(PropertyChangedCallback propertyChangedCallback) { }
        //
        // Summary:
        //     Initializes a new instance of the System.Windows.UIPropertyMetadata class,
        //     with the specified PropertyChanged callback.
        //
        // Parameters:
        //   defaultValue:
        //     The default value of the dependency property, usually provided as a value
        //     of some specific type.
        //
        //   propertyChangedCallback:
        //     Reference to a handler implementation that is to be called by the property
        //     system whenever the effective value of the property changes.
        public UIPropertyMetadata(object defaultValue, PropertyChangedCallback propertyChangedCallback) { }
        //
        // Summary:
        //     Initializes a new instance of the System.Windows.UIPropertyMetadata class,
        //     with the specified default value and callbacks.
        //
        // Parameters:
        //   defaultValue:
        //     The default value of the dependency property, usually provided as a value
        //     of some specific type.
        //
        //   propertyChangedCallback:
        //     Reference to a handler implementation that is to be called by the property
        //     system whenever the effective value of the property changes.
        //
        //   coerceValueCallback:
        //     Reference to a handler implementation that is to be called whenever the property
        //     system calls System.Windows.DependencyObject.CoerceValue(System.Windows.DependencyProperty)
        //     against this property.
        public UIPropertyMetadata(object defaultValue, PropertyChangedCallback propertyChangedCallback, CoerceValueCallback coerceValueCallback) { }
        //
        // Summary:
        //     Initializes a new instance of the System.Windows.UIPropertyMetadata class,
        //     with the specified default value and callbacks, and a Boolean used to disable
        //     animations on the property.
        //
        // Parameters:
        //   defaultValue:
        //     The default value of the dependency property, usually provided as a value
        //     of some specific type.
        //
        //   propertyChangedCallback:
        //     Reference to a handler implementation that is to be called by the property
        //     system whenever the effective value of the property changes.
        //
        //   coerceValueCallback:
        //     Reference to a handler implementation that is to be called whenever the property
        //     system calls System.Windows.DependencyObject.CoerceValue(System.Windows.DependencyProperty)
        //     against this property.
        //
        //   isAnimationProhibited:
        //     Set to true to prevent the property system from animating the property that
        //     this metadata is applied to. Such properties will raise run time exceptions
        //     if animations of them are attempted. The default is false.
        public UIPropertyMetadata(object defaultValue, PropertyChangedCallback propertyChangedCallback, CoerceValueCallback coerceValueCallback, bool isAnimationProhibited) { }

        // Summary:
        //     Gets or sets a value declaring whether animations should be disabled on the
        //     dependency property where the containing metadata instance is applied.
        //
        // Returns:
        //     true indicates that animations are disallowed; false indicates that animations
        //     are allowed. The default is false (animations allowed).
        public bool IsAnimationProhibited { get; set; }
    }
}
