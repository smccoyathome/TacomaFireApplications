using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpgradeHelpers.Events
{
    public class KeyPressEventArgs : EventArgs
    {

        public KeyPressEventArgs(char keyChar)
        {
            this.KeyChar = keyChar;
        }

        public KeyPressEventArgs(int keyChar)
        {
            this.KeyChar = Convert.ToChar(keyChar);
        }
        public char KeyChar { get; set; }

        public bool Handled { get; set; }
    }
}
