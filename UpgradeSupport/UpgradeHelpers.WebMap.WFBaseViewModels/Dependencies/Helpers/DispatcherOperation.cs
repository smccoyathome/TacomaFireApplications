using System;
using System.Security;

namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Represents an object that is used to interact with an operation that has
	//     been posted to the System.Windows.Threading.Dispatcher queue.
	public sealed class DispatcherOperation
    {
        // Summary:
        //     Gets the System.Windows.Threading.Dispatcher that the operation was posted
        //     to.
        //
        // Returns:
        //     The dispatcher.
        public Dispatcher Dispatcher { get { throw new NotImplementedException(); } }
        //
        // Summary:
        //     Gets or sets the priority of the operation in the System.Windows.Threading.Dispatcher
        //     queue.
        //
        // Returns:
        //     The priority of the delegate on the queue.
        public DispatcherPriority Priority { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        //
        // Summary:
        //     Gets the result of the operation after it has completed.
        //
        // Returns:
        //     The result of the operation -or- null if the operation has not completed.
        public object Result { get { throw new NotImplementedException(); } }
        //
        // Summary:
        //     Gets the current status of the operation..
        //
        // Returns:
        //     The status of the operation.
        public DispatcherOperationStatus Status { get { throw new NotImplementedException(); } }

        // Summary:
        //     Occurs when the operation is aborted.
        public event EventHandler Aborted;

        //
        // Summary:
        //     Occurs when the operation has completed.
        public event EventHandler Completed;

        // Summary:
        //     Aborts the operation.
        //
        // Returns:
        //     true if the operation was aborted; otherwise, false.
        public bool Abort()
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Waits for the operation to complete
        //
        // Returns:
        //     The status of the operation.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     System.Windows.Threading.DispatcherOperation.Status is equal to System.Windows.Threading.DispatcherOperationStatus.Executing.
        //     This can occur when waiting for an operation that is already executing on
        //     the same thread.
        public DispatcherOperationStatus Wait()
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Waits for the operation to complete in the specified period of time.
        //
        // Parameters:
        //   timeout:
        //     The maximum period of time to wait.
        //
        // Returns:
        //     The status of the operation.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     System.Windows.Threading.DispatcherOperation.Status is equal to System.Windows.Threading.DispatcherOperationStatus.Executing.
        //     This can occur when waiting for an operation that is already executing on
        //     the same thread.
        [SecurityCritical]
        public DispatcherOperationStatus Wait(TimeSpan timeout)
        {
            throw new NotImplementedException();
        }
    }
}
