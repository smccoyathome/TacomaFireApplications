using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Contains the System.Windows.Input.StylusDevice objects that represent a Tablet
	//     PC's stylus devices.
	public class StylusDeviceCollection : ReadOnlyCollection<StylusDevice>
    {
        public StylusDeviceCollection(IList<StylusDevice> list) : base(list)
        {

        }

        public StylusDeviceCollection()
            : base(new List<StylusDevice>())
        {

        }
    }
}
