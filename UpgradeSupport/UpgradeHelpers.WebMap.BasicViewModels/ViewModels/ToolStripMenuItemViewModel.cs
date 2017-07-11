using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.BasicViewModels
{
	public class ToolStripMenuItemViewModel : ToolStripItemViewModel
	{
		public new void Build(IIocContainer ctx)
		{
			base.Build(ctx);
		}
	}
}
