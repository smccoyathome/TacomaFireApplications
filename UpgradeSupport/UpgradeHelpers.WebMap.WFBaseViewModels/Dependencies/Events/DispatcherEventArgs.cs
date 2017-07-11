using System;
using UpgradeHelpers.Helpers;

namespace UpgradeHelpers.Events
{
	// Summary:
	//     Provides event data for System.Windows.Threading.Dispatcher related events.
	public class DispatcherEventArgs : EventArgs
    {
        // Summary:
        //     The System.Windows.Threading.Dispatcher associated with this event.
        //
        // Returns:
        //     The dispatcher.
        public Dispatcher Dispatcher { get { throw new NotImplementedException(); } }
    }
}
