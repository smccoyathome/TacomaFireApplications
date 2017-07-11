using System;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Events
{
    // Summary:
    //     Provides data for the System.Windows.Forms.Control.ControlAdded and System.Windows.Forms.Control.ControlRemoved
    //     events.
    public class DragEventArgs : EventArgs
    {
        public IDataObject Data { get; set; }
        public DragDropEffects Effect { get; set; }

        public int X { get; set; }

        public int Y { get; set; }
    }
}

