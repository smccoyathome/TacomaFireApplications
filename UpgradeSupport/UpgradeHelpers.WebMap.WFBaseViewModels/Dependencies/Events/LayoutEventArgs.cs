using System;
using UpgradeHelpers.Helpers;

namespace UpgradeHelpers.Events
{
	public class LayoutEventArgs : EventArgs
    {
        public ControlViewModel AffectedControl { get; set; }
    }
}
