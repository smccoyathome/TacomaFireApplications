using System;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Events
{
	// Summary:
	//     Provides data for System.Windows.UIElement.LostKeyboardFocus and System.Windows.UIElement.GotKeyboardFocus routed
	//     events, as well as related attached and Preview events.
	public class KeyboardFocusChangedEventArgs : KeyboardEventArgs
    {
        // Summary:
        //     Initializes a new instance of the System.Windows.Input.KeyboardFocusChangedEventArgs
        //     class.
        //
        // Parameters:
        //   keyboard:
        //     The logical keyboard device associated with this event.
        //
        //   timestamp:
        //     The time when the input occurred.
        //
        //   oldFocus:
        //     The element that previously had focus.
        //
        //   newFocus:
        //     The element that now has focus.
        public KeyboardFocusChangedEventArgs(KeyboardDevice keyboard, int timestamp, IInputElement oldFocus, IInputElement newFocus) : 
            base(keyboard, timestamp)
        {
            throw new NotImplementedException();
        }

        // Summary:
        //     Gets the element that focus has moved to.
        //
        // Returns:
        //     The element with focus.
        public IInputElement NewFocus { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the element that previously had focus.
        //
        // Returns:
        //     The previously focused element.
        public IInputElement OldFocus { get { throw new NotImplementedException(); } }

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
