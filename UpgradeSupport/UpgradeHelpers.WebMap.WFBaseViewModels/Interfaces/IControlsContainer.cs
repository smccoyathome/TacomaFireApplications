using System.Collections.Generic;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Interfaces
{
	public interface IControlsContainer : IControl
	{
		IList<ControlViewModel> Controls { get; set; }
	}

}
