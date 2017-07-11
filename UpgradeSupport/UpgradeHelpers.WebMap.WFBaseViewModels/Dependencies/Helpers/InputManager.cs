using System;
using System.Collections;
using System.Security;
using UpgradeHelpers.Events;

namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Manages all the input systems in Windows Presentation Foundation (WPF).
	public sealed class InputManager : DispatcherObject
    {
        // Summary:
        //     Gets the System.Windows.Input.InputManager associated with the current thread.
        //
        // Returns:
        //     The input manager.
        public static InputManager Current { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets a collection of System.Windows.Input.InputManager.InputProviders registered
        //     with the System.Windows.Input.InputManager.
        //
        // Returns:
        //     The collection of input provides.
        public ICollection InputProviders { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets a value that represents the input device associated with the most recent
        //     input event.
        //
        // Returns:
        //     The input device.
        public InputDevice MostRecentInputDevice { get { throw new NotImplementedException(); } internal set { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the primary keyboard device.
        //
        // Returns:
        //     The keyboard device.
        public KeyboardDevice PrimaryKeyboardDevice { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the primary mouse device.
        //
        // Returns:
        //     The mouse device.
        public MouseDevice PrimaryMouseDevice { get { throw new NotImplementedException(); } }


        // Summary:
        //     Occurs when the result of a hit-test may have changed.
        public event EventHandler HitTestInvalidatedAsync;

        //
        // Summary:
        //     Occurs after the System.Windows.Input.InputManager.PreNotifyInput handlers
        //     have finished processing the input and the corresponding Windows Presentation
        //     Foundation (WPF) events have been raised.
        public event NotifyInputEventHandler PostNotifyInput;

        //
        // Summary:
        //     Occurs after the System.Windows.Input.InputManager.PreNotifyInput handlers
        //     have finished processing the input.
        public event ProcessInputEventHandler PostProcessInput;

        //
        // Summary:
        //     Occurs when the System.Windows.Input.InputManager.PreProcessInput handlers
        //     have finished processing the input, if the input was not canceled.
        public event NotifyInputEventHandler PreNotifyInput;

        //
        // Summary:
        //     Occurs when the System.Windows.Input.InputManager starts to process the input
        //     item.
        public event PreProcessInputEventHandler PreProcessInput;

        // Summary:
        //     Processes the specified input synchronously.
        //
        // Parameters:
        //   input:
        //     The input to process.
        //
        // Returns:
        //     true if all input events were handled; otherwise, false.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     input is null.
        [SecurityCritical]
        public bool ProcessInput(InputEventArgs input)
        {
            throw new NotImplementedException();
        }
    }
}
