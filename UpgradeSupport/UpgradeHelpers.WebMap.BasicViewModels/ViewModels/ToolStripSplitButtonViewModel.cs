using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.BasicViewModels
{
	public class ToolStripSplitButtonViewModel : ToolStripItemViewModel
	{

		/// <summary>
		/// Setup the model properties with its default values
		/// </summary>
		public override void Build(IIocContainer ctx)
		{
			base.Build(ctx);
			// tooltipText DefaultValue
			ToolTipText = "";
		}
	}
}