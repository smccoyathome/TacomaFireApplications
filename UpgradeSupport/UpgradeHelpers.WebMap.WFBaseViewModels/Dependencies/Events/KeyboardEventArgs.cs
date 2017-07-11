using System;
using UpgradeHelpers.Helpers;

namespace UpgradeHelpers.Events
{
	// Summary:
	//     Provides data for keyboard-related events.
	public class KeyboardEventArgs : InputEventArgs
    {
        // Summary:
        //     Initializes a new instance of the System.Windows.Input.KeyboardEventArgs
        //     class.
        //
        // Parameters:
        //   keyboard:
        //     The logical keyboard device associated with this event.
        //
        //   timestamp:
        //     The time when the input occurred.
        public KeyboardEventArgs(KeyboardDevice keyboard, int timestamp) : 
            base(keyboard, timestamp)
        {
            throw new NotImplementedException();
        }

        // Summary:
        //     Gets the keyboard device associated with the input event.
        //
        // Returns:
        //     The logical keyboard device associated with the event.
        public KeyboardDevice KeyboardDevice
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        // Summary:
        //     Invokes event handlers in a type-specific way, which can increase event system
        //     efficiency.
        //
        // Parameters:
        //   genericHandler:
        //     The generic handler to call in a type-specific way.
        //
        //   genericTarget:
        //     The target to call the handler on.
        protected override void InvokeEventHandler(Delegate genericHandler, object genericTarget)
        {
            throw new NotImplementedException();
        }
    }
}
