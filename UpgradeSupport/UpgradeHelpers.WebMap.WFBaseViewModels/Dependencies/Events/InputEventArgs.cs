using System;
using UpgradeHelpers.Helpers;

namespace UpgradeHelpers.Events
{
	// Summary:
	//     Provides data for input related events.
	public class InputEventArgs : RoutedEventArgs
    {
        // Summary:
        //     Initializes a new instance of the System.Windows.Input.InputEventArgs class.
        //
        // Parameters:
        //   inputDevice:
        //     The input device to associate with this event.
        //
        //   timestamp:
        //     The time when the input occurred.
        public InputEventArgs(InputDevice inputDevice, int timestamp)
        {
           // throw new NotImplementedException();
        }

        // Summary:
        //     Gets the input device that initiated this event.
        //
        // Returns:
        //     The input device associated with this event.
        public InputDevice Device { get { throw new NotImplementedException(); } internal set { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the time when this event occurred.
        //
        // Returns:
        //     The timestamp.
        public int Timestamp { get { throw new NotImplementedException(); } }

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
