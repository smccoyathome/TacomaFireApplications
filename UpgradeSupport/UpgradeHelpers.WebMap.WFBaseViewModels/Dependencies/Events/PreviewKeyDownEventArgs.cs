using System;
using UpgradeHelpers.Helpers;

namespace UpgradeHelpers.Events
{
    public class PreviewKeyDownEventArgs : EventArgs
    {

        private readonly Keys _keyData;
        private bool _isInputKey;

        public PreviewKeyDownEventArgs(Keys keyData)
        {
            _keyData = keyData;
        }

        public bool Alt
        {
            get
            {
                return (_keyData & Keys.Alt) == Keys.Alt;
            }
        }

        public bool Control
        {
            get
            {
                return (_keyData & Keys.Control) == Keys.Control;
            }
        }

        public Keys KeyCode
        {
            get
            {
                Keys keyGenerated = _keyData & Keys.KeyCode;

                // since Keys can be discontiguous, keeping Enum.IsDefined.
                if (!Enum.IsDefined(typeof(Keys), (int)keyGenerated))
                    return Keys.None;
                else
                    return keyGenerated;
            }
        }

        //subhag : added the KeyValue as per the new requirements. 
        public int KeyValue
        {
            get
            {
                return (int)(_keyData & Keys.KeyCode);
            }
        }

        public Keys KeyData
        {
            get
            {
                return _keyData;
            }
        }

        public Keys Modifiers
        {
            get
            {
                return _keyData & Keys.Modifiers;
            }
        }

        public bool Shift
        {
            get
            {
                return (_keyData & Keys.Shift) == Keys.Shift;
            }
        }

        public bool IsInputKey
        {
            get
            {
                return _isInputKey;
            }
            set
            {
                _isInputKey = value;
            }
        }
    }
}