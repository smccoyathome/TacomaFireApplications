using System;

namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Represents a button on a stylus.
	public class StylusButton
    {
        // Summary:
        //     Gets the System.Guid that represents the stylus button.
        //
        // Returns:
        //     The System.Guid property that represents the stylus button.
        public Guid Guid { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the name of the stylus button.
        //
        // Returns:
        //     The name of the stylus button.
        public string Name { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the state of the stylus button.
        //
        // Returns:
        //     One of the System.Windows.Input.StylusButtonState values.
        public StylusButtonState StylusButtonState { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the stylus that this button belongs to.
        //
        // Returns:
        //     A System.Windows.Input.StylusDevice that represents the stylus of the current
        //     System.Windows.Input.StylusButton.
        public StylusDevice StylusDevice { get { throw new NotImplementedException(); } }


        // Summary:
        //     Creates a string representation of the System.Windows.Input.StylusButton.
        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
