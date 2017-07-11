using System;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Abstract class that describes an input devices.
	public abstract class InputDevice : DispatcherObject
    {
        // Summary:
        //     Initializes a new instance of the System.Windows.Input.InputDevice class.
        protected InputDevice()
        {
            throw new NotImplementedException();
        }

        // Summary:
        //     When overridden in a derived class, gets the System.Windows.PresentationSource
        //     that is reporting input for this device.
        //
        // Returns:
        //     The source that is reporting input for this device.
        public abstract PresentationSource ActiveSource { get; }

        //
        // Summary:
        //     When overridden in a derived class, gets the element that receives input
        //     from this device.
        //
        // Returns:
        //     The element that receives input.
        public abstract IInputElement Target { get; }
    }
}
