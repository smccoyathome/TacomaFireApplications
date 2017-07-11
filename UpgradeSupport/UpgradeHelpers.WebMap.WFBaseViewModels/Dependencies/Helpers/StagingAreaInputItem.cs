using System;
using UpgradeHelpers.Events;

namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Encapsulates an input event when it is being processed by the input manager.
	public class StagingAreaInputItem
    {
        // Summary:
        //     Gets the input event data associated with this System.Windows.Input.StagingAreaInputItem
        //     object
        //
        // Returns:
        //     The event.
        public InputEventArgs Input {
            get { throw new NotImplementedException(); } 
        }

        // Summary:
        //     Gets the input data associated with the specified key.
        //
        // Parameters:
        //   key:
        //     An arbitrary key for the data. This cannot be null.
        //
        // Returns:
        //     The data for this key, or null.
        public object GetData(object key)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Creates a dictionary entry by using the specified key and the specified data.
        //
        // Parameters:
        //   key:
        //     An arbitrary key for the data. This cannot be null.
        //
        //   value:
        //     The data to set for this key. This can be null.
        public void SetData(object key, object value)
        {
            throw new NotImplementedException();
        }
    }
}
