using System;
using System.Collections.Generic;
using UpgradeHelpers.Helpers;

namespace UpgradeHelpers.Interfaces
{
	/// <summary>
	/// When some class requires special treatment when the NotifyParentVisibility is called.
	/// This HandleVisibility will only be invoked when the visible has been changed from false to true
	/// </summary>
	public interface ISpecialVisibilityBehaviour
	{
		void HandleVisibility();
	}
}