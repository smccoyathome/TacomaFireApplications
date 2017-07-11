using System;

namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Specifies constants that define the state of a key.
	[Flags]
    public enum KeyStates
    {
        // Summary:
        //     The key is not pressed.
        None = 0,

        //
        // Summary:
        //     The key is pressed.
        Down = 1,

        //
        // Summary:
        //     The key is toggled.
        Toggled = 2
    }
}
