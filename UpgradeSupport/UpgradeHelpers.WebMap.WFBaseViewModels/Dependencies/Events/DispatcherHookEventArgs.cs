using System;
using UpgradeHelpers.Helpers;

namespace UpgradeHelpers.Events
{
	// Summary:
	//     Provides event data for System.Windows.Threading.DispatcherHooks events.
	public sealed class DispatcherHookEventArgs : EventArgs
    {
        // Summary:
        //     Initializes a new instance of the System.Windows.Threading.DispatcherHookEventArgs
        //     class.
        //
        // Parameters:
        //   operation:
        //     The operation associated with the event.
        public DispatcherHookEventArgs(DispatcherOperation operation)
        {
            throw new NotImplementedException();
        }

        // Summary:
        //     Gets the System.Windows.Threading.Dispatcher associated with this event.
        //
        // Returns:
        //     The System.Windows.Threading.Dispatcher.
        public Dispatcher Dispatcher { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the System.Windows.Threading.DispatcherOperation associated with this
        //     event.
        //
        // Returns:
        //     The operation.
        public DispatcherOperation Operation { get { throw new NotImplementedException(); } }
    }
}
