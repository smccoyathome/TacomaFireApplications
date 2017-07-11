using System;
using UpgradeHelpers.Helpers;

namespace UpgradeHelpers.Events
{
    // Summary:
    //     Provides data for the System.Windows.Forms.Control.ControlAdded and System.Windows.Forms.Control.ControlRemoved
    //     events.
    public class ControlEventArgs : EventArgs
    {
        private ControlViewModel control;

        public ControlViewModel Control
        {
            get
            {
                return this.control;
            }
        }

        public ControlEventArgs(ControlViewModel control)
        {
            this.control = control;
        }
    }
}