using System;

namespace UpgradeHelpers.Events
{
	// Summary:
	//     Provides data for preprocess input events.
	public sealed class PreProcessInputEventArgs : ProcessInputEventArgs
    {
        // Summary:
        //     Determines whether processing of the input event was canceled.
        //
        // Returns:
        //     true if the processing was canceled; otherwise, false.
        public bool Canceled { get { throw new NotImplementedException(); } }

        // Summary:
        //     Cancels the processing of the input event.
        public void Cancel()
        {
            throw new NotImplementedException();
        }
    }
}
