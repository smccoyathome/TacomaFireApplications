using System;
using UpgradeHelpers.Helpers;

namespace UpgradeHelpers.Events
{
    // Summary:
    //     Provides data for the System.Windows.Forms.Control.ControlAdded and System.Windows.Forms.Control.ControlRemoved
    //     events.
    public class QueryContinueDragEventArgs : EventArgs
    {

        public DragAction Action { get; set; }
    }
}