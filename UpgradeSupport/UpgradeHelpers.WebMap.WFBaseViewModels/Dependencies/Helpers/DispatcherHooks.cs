using System;
using UpgradeHelpers.Events;

namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Provides additional event information about System.Windows.Threading.Dispatcher
	//     processing.
	public sealed class DispatcherHooks
    {
        // Summary:
        //     Occurs when the dispatcher has no more operations to process.
        public event EventHandler DispatcherInactive;
        //
        // Summary:
        //     Occurs when an operation is aborted.
        public event DispatcherHookEventHandler OperationAborted;

        //
        // Summary:
        //     Occurs when an operation completes.
        public event DispatcherHookEventHandler OperationCompleted;

        //
        // Summary:
        //     Occurs when an operation is posted to the dispatcher.
        public event DispatcherHookEventHandler OperationPosted;

        //
        // Summary:
        //     Occurs when the priority of an operation is changed.
        public event DispatcherHookEventHandler OperationPriorityChanged;
    }
}
