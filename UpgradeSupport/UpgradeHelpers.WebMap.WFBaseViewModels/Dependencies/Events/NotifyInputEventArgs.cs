using System;
using UpgradeHelpers.Helpers;

namespace UpgradeHelpers.Events
{
	// Summary:
	//     Provides data for raw input being processed by the System.Windows.Input.NotifyInputEventArgs.InputManager.
	public class NotifyInputEventArgs : EventArgs
    {
        // Summary:
        //     Gets the input manager processing the input event.
        //
        // Returns:
        //     The input manager.
        public InputManager InputManager { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the staging area input item being processed by the input manager.
        //
        // Returns:
        //     The staging area.
        public StagingAreaInputItem StagingItem { get { throw new NotImplementedException(); } }
    }
}
