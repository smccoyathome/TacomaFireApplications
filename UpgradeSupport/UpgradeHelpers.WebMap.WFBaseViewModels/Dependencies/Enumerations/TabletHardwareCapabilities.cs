using System;

namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Defines values that specify the hardware capabilities of a tablet device,
	//     including desktop digitizers and mice.
	[Serializable]
    [Flags]
    public enum TabletHardwareCapabilities
    {
        // Summary:
        //     Indicates the tablet device cannot provide this information.
        None = 0,

        //
        // Summary:
        //     Indicates the digitizer is integrated with the display.
        Integrated = 1,

        //
        // Summary:
        //     Indicates the stylus must be in physical contact with the tablet device to
        //     report its position.
        StylusMustTouch = 2,

        //
        // Summary:
        //     Indicates the tablet device can generate in-air packets when the stylus is
        //     in the physical detection range (proximity) of the tablet device.
        HardProximity = 4,

        //
        // Summary:
        //     Indicates the tablet device can uniquely identify the active stylus.
        StylusHasPhysicalIds = 8,

        //
        // Summary:
        //     Indicates that the tablet device can detect the amount of pressure the user
        //     applies when using the stylus.
        SupportsPressure = 1073741824
    }
}
