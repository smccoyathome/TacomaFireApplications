using System;

namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Represents the Dispatcher when it is in a disable state and provides a means
	//     to re-enable dispatcher processing.
	public struct DispatcherProcessingDisabled : IDisposable
    {

        // Summary:
        //     Determines whether two System.Windows.Threading.DispatcherProcessingDisabled
        //     objects are not equal.
        //
        // Parameters:
        //   left:
        //     The first object to compare.
        //
        //   right:
        //     The second object to compare.
        //
        // Returns:
        //     true if the System.Windows.Threading.DispatcherProcessingDisabled objects
        //     are not equal; otherwise, false.
        public static bool operator !=(DispatcherProcessingDisabled left, DispatcherProcessingDisabled right)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Determines whether two System.Windows.Threading.DispatcherProcessingDisabled
        //     objects are equal.
        //
        // Parameters:
        //   left:
        //     The first object to compare.
        //
        //   right:
        //     The second object to compare.
        //
        // Returns:
        //     true if the System.Windows.Threading.DispatcherProcessingDisabled objects
        //     are equal; otherwise, false.
        public static bool operator ==(DispatcherProcessingDisabled left, DispatcherProcessingDisabled right)
        {
            throw new NotImplementedException();
        }

        // Summary:
        //     Re-enables dispatcher processing.
        public void Dispose()
        {
            /*Dispose method has no implementation*/
	        System.Diagnostics.Debugger.Break();
		}

        //
        // Summary:
        //     Determines whether the specified System.Windows.Threading.DispatcherProcessingDisabled
        //     object is equal to this System.Windows.Threading.DispatcherProcessingDisabled
        //     object.
        //
        // Parameters:
        //   obj:
        //     The object to evaluate for equality.
        //
        // Returns:
        //     true if the specified object is equal to this System.Windows.Threading.DispatcherProcessingDisabled
        //     object; otherwise, false.
        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Gets a hash code for this instance.
        //
        // Returns:
        //     A signed 32-bit integer hash code.
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
