using System;

namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Represents a property stored in a System.Windows.Input.StylusPoint.
	public class StylusPointProperty
    {
        // Summary:
        //     Initializes a new instance of the System.Windows.Input.StylusPointProperty
        //     class.
        //
        // Parameters:
        //   stylusPointProperty:
        protected StylusPointProperty(StylusPointProperty stylusPointProperty)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Input.StylusPointProperty
        //     class using the specified GUID.
        //
        // Parameters:
        //   identifier:
        //     The System.Guid that uniquely identifies the System.Windows.Input.StylusPointProperty.
        //
        //   isButton:
        //     true to indicate that the property represents a button on the stylus; otherwise,
        //     false.
        public StylusPointProperty(Guid identifier, bool isButton)
        {
            throw new NotImplementedException();
        }

        // Summary:
        //     Gets the GUID for the current System.Windows.Input.StylusPointProperty.
        //
        // Returns:
        //     The GUID for the current System.Windows.Input.StylusPointProperty.
        public Guid Id { get { throw new NotImplementedException(); } }
        //
        // Summary:
        //     Gets whether the System.Windows.Input.StylusPointProperty represents a button
        //     on the stylus.
        //
        // Returns:
        //     true if the System.Windows.Input.StylusPointProperty represents a button
        //     on the stylus; otherwise, false.
        public bool IsButton { get { throw new NotImplementedException(); } }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
