using System;
using UpgradeHelpers.Helpers;

namespace UpgradeHelpers.Events
{
    /// <summary>
    ///     Event args class for key event handlers.  This class is provided for compilation purposes only,
    ///     because key events are not server propagated to server side, instead they are
    ///     converted to client side events (such as JavaScript)
    /// </summary>
    public class KeyEventArgs : EventArgs
    {

        private Keys keyData;
        private bool handled = false;
        private bool suppressKeyPress = false;

        public KeyEventArgs(Keys _keyData)
        {
            this.keyData = _keyData;
        }

        public KeyEventArgs(int _keyCode)
        {
            this.keyData = (Keys)_keyCode;
        }

        public KeyEventArgs()
        {
        }

        public virtual bool Alt
        {
            get
            {
                return (keyData & Keys.Alt) == Keys.Alt;
            }
        }

        public bool Control
        {
            get
            {
                return (keyData & Keys.ControlKey) == Keys.ControlKey;
            }
        }

        public bool Handled
        {
            get
            {
                return handled;
            }
            set
            {
                handled = value;
            }
        }

        public Keys KeyCode
        {
            get
            {
                Keys keyGenerated = keyData & Keys.KeyCode;

                // since Keys can be discontiguous, keeping Enum.IsDefined.
                if (!Enum.IsDefined(typeof(Keys), (int)keyGenerated))
                    return Keys.None;
                else
                    return keyGenerated;
            }
        }

        public int KeyValue
        {
            get
            {
                return (int)(keyData & Keys.KeyCode);
            }
        }

        public Keys KeyData
        {
            get
            {
                return keyData;
            }
        }

        public Keys Modifiers
        {
            get
            {
                return keyData & Keys.Modifiers;
            }
        }

        public virtual bool Shift
        {
            get
            {
                return (keyData & Keys.ShiftKey) == Keys.ShiftKey;
            }
        }

        public bool SuppressKeyPress
        {
            get
            {
                return suppressKeyPress;
            }
            set
            {
                suppressKeyPress = value;
                handled = value;
            }
        }


    }
}