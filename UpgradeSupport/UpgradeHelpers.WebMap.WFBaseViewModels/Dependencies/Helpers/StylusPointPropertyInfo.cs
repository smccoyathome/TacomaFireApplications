using System;

namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Specifies the constraints of a property in a System.Windows.Input.StylusPoint.
	public class StylusPointPropertyInfo : StylusPointProperty
    {
        // Summary:
        //     Initializes a new instance of the System.Windows.Input.StylusPointPropertyInfo
        //     class.
        //
        // Parameters:
        //   stylusPointProperty:
        //     The System.Windows.Input.StylusPointProperty to base the new System.Windows.Input.StylusPointProperty
        //     on.
        public StylusPointPropertyInfo(StylusPointProperty stylusPointProperty) : base(stylusPointProperty)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Input.StylusPointPropertyInfo
        //     class using the specified values.
        //
        // Parameters:
        //   stylusPointProperty:
        //     The System.Windows.Input.StylusPointProperty to base the new System.Windows.Input.StylusPointProperty
        //     on.
        //
        //   minimum:
        //     The minimum value accepted for the System.Windows.Input.StylusPoint property.
        //
        //   maximum:
        //     The maximum value accepted for the System.Windows.Input.StylusPoint property.
        //
        //   unit:
        //
        //   resolution:
        //     The scale that converts a System.Windows.Input.StylusPoint property value
        //     into its units.
        public StylusPointPropertyInfo(StylusPointProperty stylusPointProperty, int minimum, int maximum, StylusPointPropertyUnit unit, float resolution) 
            : base(stylusPointProperty)
        {
            throw new NotImplementedException();
        }

        // Summary:
        //     Gets the maximum value accepted for the System.Windows.Input.StylusPoint
        //     property.
        //
        // Returns:
        //     The maximum value accepted for the System.Windows.Input.StylusPoint property.
        public int Maximum { get { throw new NotImplementedException(); } }
        //
        // Summary:
        //     Gets the minimum value accepted for the System.Windows.Input.StylusPoint
        //     property.
        //
        // Returns:
        //     The minimum value accepted for the System.Windows.Input.StylusPoint property.
        public int Minimum { get { throw new NotImplementedException(); } }
        //
        // Summary:
        //     Gets the scale that converts a System.Windows.Input.StylusPoint property
        //     value into units.
        //
        // Returns:
        //     The scale that converts a System.Windows.Input.StylusPoint property value
        //     into units.
        public float Resolution { get { throw new NotImplementedException(); } }
        //
        // Summary:
        //     Gets the type of measurement that is used by System.Windows.Input.StylusPoint
        //     property.
        //
        // Returns:
        //     One of the System.Windows.Input.StylusPointPropertyUnit values.
        public StylusPointPropertyUnit Unit { get { throw new NotImplementedException(); } }
    }
}
