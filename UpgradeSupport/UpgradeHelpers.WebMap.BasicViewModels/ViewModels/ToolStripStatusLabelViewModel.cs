using System.Collections.Generic;
using System.ComponentModel;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.BasicViewModels
{
	public class ToolStripStatusLabelViewModel : ControlViewModel
	{
		public override void Build(IIocContainer ctx)
		{
			base.Build(ctx);
			this.Text = "";
		}

		#region Data Members

		/// <summary>
		/// Reference to the ToolStripViewModel object owning this item.
		/// </summary>
		public virtual ToolStripViewModel Owner { get; set; }

		/// <summary>
		/// Gets or sets the index value of the image that is displayed on the item.
		/// </summary>
		public virtual int ImageIndex { get; set; }
	}
	#endregion
}
