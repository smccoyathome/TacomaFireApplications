using System;
using System.Collections.Generic;
using System.ComponentModel;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.BasicViewModels
{
	/// <summary>
	/// Represents a view model that deals with panel in the view.
	/// </summary>
	public class PanelViewModel : ControlViewModel
	{
		public override void Build(IIocContainer ctx)
		{
			base.Build(ctx);
			Controls = ctx.Resolve<IList<ControlViewModel>>();

		}

        [StateManagement(StateManagementValues.ClientOnly)]
        public string LeftString
        {
            get {
                return Left + "px";
            }
        }
	}
}
