using System;

namespace UpgradeHelpers.Events
{
	public class CancelEventArgs : EventArgs
    {
        private bool cancel;

        public bool Cancel
        {
            get
            {
                return this.cancel;
            }
            set
            {
                this.cancel = value;
            }
        }

        public CancelEventArgs()
            : this(false)
        {
        }

        public CancelEventArgs(bool cancel)
        {
            this.cancel = cancel;
        }
    }
}
