using System.ComponentModel;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;
namespace UpgradeHelpers.BasicViewModels
{
	/// <summary>
	/// A view model to hold state for element in the view which could be should as part of a toolbar
	/// </summary>
	public class ToolStripItemViewModel : ControlViewModel
	{
		/// <summary>
		/// Setup the model properties with its default values
		/// </summary>
		public override void Build(IIocContainer ctx)
		{
			base.Build(ctx);
			// Available DefaultValue
			this.Available = true;

			// Enabled DefaultValue
			Enabled = true;

			// Visible DefaultValue
			Visible = true;

			// tooltipText DefaultValue
			ToolTipText = "";

			Text = "";
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

		public virtual bool Available { get; set; }

		public virtual bool Checked { get; set; }

	}

	#endregion
}

