using System;

namespace UpgradeHelpers.Events
{
	// Summary:
	//     Provides data for the System.Windows.Threading.Dispatcher System.Windows.Threading.Dispatcher.UnhandledException
	//     event. This class cannot be inherited.
	public sealed class DispatcherUnhandledExceptionEventArgs : DispatcherEventArgs
    {
        // Summary:
        //     Gets the exception that was raised when executing code by way of the dispatcher.
        //
        // Returns:
        //     The exception.
        public Exception Exception { get { throw new NotImplementedException(); } }
        //
        // Summary:
        //     Gets or sets whether the exception event has been handled.
        //
        // Returns:
        //     true if the exception was handled; otherwise, false.
        public bool Handled { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
    }
}
