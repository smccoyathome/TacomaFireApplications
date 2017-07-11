using System;
using System.Security;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Abstract class that represents a keyboard device.
	public abstract class KeyboardDevice : InputDevice
    {
        // Summary:
        //     Initializes a new instance of the System.Windows.Input.KeyboardDevice class.
        //
        // Parameters:
        //   inputManager:
        //     The input manager associated with this System.Windows.Input.KeyboardDevice.
        [SecurityCritical]
        [SecurityTreatAsSafe]
        protected KeyboardDevice(InputManager inputManager)
        {
            throw new NotImplementedException();
        }

        // Summary:
        //     Gets the System.Windows.PresentationSource that is reporting input for this
        //     device.
        //
        // Returns:
        //     The source of input for this device.
        public override PresentationSource ActiveSource
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        //
        // Summary:
        //     Gets the element that has keyboard focus.
        //
        // Returns:
        //     The element with keyboard focus.
        public IInputElement FocusedElement
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        //
        // Summary:
        //     Gets the set of System.Windows.Input.ModifierKeys which are currently pressed.
        //
        // Returns:
        //     The set of modifier keys.
        public ModifierKeys Modifiers
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        //
        // Summary:
        //     Gets the specified System.Windows.IInputElement that input from this device
        //     is sent to.
        //
        // Returns:
        //     The element that receives input.
        public override IInputElement Target
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        // Summary:
        //     Sets keyboard focus on the specified System.Windows.IInputElement.
        //
        // Parameters:
        //   element:
        //     The element to move focus to.
        //
        // Returns:
        //     The element that has keyboard focus.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     element is not a System.Windows.UIElement or System.Windows.ContentElement.
        public IInputElement Focus(IInputElement element)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Gets the set of key states for the specified System.Windows.Input.Key.
        //
        // Parameters:
        //   key:
        //     The key to check.
        //
        // Returns:
        //     The set of key states for the specified key.
        //
        // Exceptions:
        //   System.ComponentModel.InvalidEnumArgumentException:
        //     key is not a valid key.
        public KeyStates GetKeyStates(KeyInput key)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     When overridden in a derived class, obtains the System.Windows.Input.KeyStates
        //     for the specified System.Windows.Input.Key.
        //
        // Parameters:
        //   key:
        //     The key to check.
        //
        // Returns:
        //     The set of key states for the specified key.
        protected abstract KeyStates GetKeyStatesFromSystem(KeyInput key);

        //
        // Summary:
        //     Determines whether the specified System.Windows.Input.Key is in the down
        //     state.
        //
        // Parameters:
        //   key:
        //     The key to check.
        //
        // Returns:
        //     true if key is in the down state; otherwise, false.
        //
        // Exceptions:
        //   System.ComponentModel.InvalidEnumArgumentException:
        //     key is not a valid key.
        public bool IsKeyDown(KeyInput key)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Determines whether the specified System.Windows.Input.Key is in the toggled
        //     state.
        //
        // Parameters:
        //   key:
        //     The key to check.
        //
        // Returns:
        //     true if key is in the toggled state; otherwise, false.
        //
        // Exceptions:
        //   System.ComponentModel.InvalidEnumArgumentException:
        //     key is not a valid key.
        public bool IsKeyToggled(KeyInput key)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Determines whether the specified System.Windows.Input.Key is in the up state.
        //
        // Parameters:
        //   key:
        //     The key to check.
        //
        // Returns:
        //     true if key is in the up state; otherwise, false.
        //
        // Exceptions:
        //   System.ComponentModel.InvalidEnumArgumentException:
        //     key is not a valid key.
        public bool IsKeyUp(KeyInput key)
        {
            throw new NotImplementedException();
        }
    }
}
