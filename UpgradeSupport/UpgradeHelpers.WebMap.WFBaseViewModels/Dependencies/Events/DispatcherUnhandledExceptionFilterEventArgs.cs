using System;

namespace UpgradeHelpers.Events
{
	// Summary:
	//     Provides data for the System.Windows.Threading.Dispatcher System.Windows.Threading.Dispatcher.UnhandledExceptionFilter
	//     event. This class cannot be inherited.
	public sealed class DispatcherUnhandledExceptionFilterEventArgs : DispatcherEventArgs
    {
        // Summary:
        //     Gets the exception that was raised when executing code by way of the dispatcher.
        //
        // Returns:
        //     The exception.
        public Exception Exception { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets or sets whether the exception should be caught and the event handlers
        //     called.
        //
        // Returns:
        //     true if the System.Windows.Threading.Dispatcher.UnhandledException should
        //     be raised; otherwise; false. The default value is true.
        public bool RequestCatch { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
    }
}
