using System;
using System.Collections.ObjectModel;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Represents the digitizer device of a Tablet PC.
	public sealed class TabletDevice : InputDevice
    {
        // Summary:
        //     Gets the System.Windows.PresentationSource that reports current input for
        //     the tablet device.
        //
        // Returns:
        //     The System.Windows.PresentationSource that reports current input for the
        //     tablet device.
        public override PresentationSource ActiveSource { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the unique identifier for the tablet device on the system.
        //
        // Returns:
        //     The unique identifier for the tablet device on the system.
        public int Id { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the name of the tablet device.
        //
        // Returns:
        //     The name of the tablet device.
        public string Name { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the product identifier for the tablet device.
        //
        // Returns:
        //     The product identifier for the tablet device.
        public string ProductId { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the System.Windows.Input.StylusDeviceCollection associated with the
        //     tablet device.
        //
        // Returns:
        //     The System.Windows.Input.StylusDeviceCollection associated with the tablet
        //     device.
        public StylusDeviceCollection StylusDevices { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets a collection of System.Windows.Input.StylusPointProperty objects that
        //     the System.Windows.Input.TabletDevice supports.
        //
        // Returns:
        //     A collection of System.Windows.Input.StylusPointProperty objects that the
        //     System.Windows.Input.TabletDevice supports.
        public ReadOnlyCollection<StylusPointProperty> SupportedStylusPointProperties { get { throw new NotImplementedException(); } }
        //
        // Summary:
        //     Gets the System.Windows.Input.TabletHardwareCapabilities for the tablet device.
        //
        // Returns:
        //     The System.Windows.Input.TabletHardwareCapabilities for the tablet device.
        public TabletHardwareCapabilities TabletHardwareCapabilities { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the System.Windows.IInputElement that provides basic input processing
        //     for the tablet device.
        //
        // Returns:
        //     The System.Windows.IInputElement that provides basic input processing for
        //     the tablet device.
        public override IInputElement Target { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the System.Windows.Input.TabletDeviceType of the tablet device.
        //
        // Returns:
        //     The System.Windows.Input.TabletDeviceType of the tablet device.
        public TabletDeviceType Type { get { throw new NotImplementedException(); } }

        // Summary:
        //     Returns the name of the tablet device.
        //
        // Returns:
        //     A System.String that contains the name of the System.Windows.Input.TabletDevice.
        public override string ToString() {
            throw new NotImplementedException();
        }
    }
}
