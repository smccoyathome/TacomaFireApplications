using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Contains a collection of System.Windows.Input.StylusButton objects.
	public class StylusButtonCollection : ReadOnlyCollection<StylusButton>
    {
        public StylusButtonCollection(IList<StylusButton> list)
            : base(list)
        {
            throw new NotImplementedException();
        }

        public StylusButtonCollection()
            : base(new List<StylusButton>())
        {
            throw new NotImplementedException();
        }

        // Summary:
        //     Gets the System.Windows.Input.StylusButton that the specified GUID identifies.
        //
        // Parameters:
        //   guid:
        //     The System.Guid that specifies the desired System.Windows.Input.StylusButton.
        //
        // Returns:
        //     The System.Windows.Input.StylusButton of the specified GUID.
        public StylusButton GetStylusButtonByGuid(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}
