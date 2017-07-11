using System;
using System.Security;
using UpgradeHelpers.Helpers;

namespace UpgradeHelpers.Events
{
	// Summary:
	//     Provides data for postprocess input events.
	public class ProcessInputEventArgs : NotifyInputEventArgs
    {
        // Summary:
        //     Gets, but does not pop, the input event on the top of the staging area stack.
        //
        // Returns:
        //     The input event that is on the top of the staging area stack.
        [SecurityCritical]
        public StagingAreaInputItem PeekInput()
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Removes the input event off the top of the staging area stack.
        //
        // Returns:
        //     The input event that was on the top of the staging area stack. This will
        //     be null if the staging area is empty.
        [SecurityCritical]
        public StagingAreaInputItem PopInput()
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Puts the specified input event onto the top of the staging area stack.
        //
        // Parameters:
        //   input:
        //     The input event to put on the staging area stack.
        //
        // Returns:
        //     The staging area input item.
        [SecurityCritical]
        public StagingAreaInputItem PushInput(StagingAreaInputItem input)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Puts the specified input event onto the top of the specified staging area
        //     stack.
        //
        // Parameters:
        //   input:
        //     The input event to put on the staging area stack.
        //
        //   promote:
        //     An existing staging area item to promote the state from.
        //
        // Returns:
        //     The staging area input item that wraps the specified input.
        [SecurityCritical]
        public StagingAreaInputItem PushInput(InputEventArgs input, StagingAreaInputItem promote)
        {
            throw new NotImplementedException();
        }
    }
}
