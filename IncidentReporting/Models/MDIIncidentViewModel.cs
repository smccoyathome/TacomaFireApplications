using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace TFDIncident.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(TFDIncident.MDIIncident))]
	public class MDIIncidentViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.mnuExit = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuExit
			// 
			this.mnuExit.Available = true;
			this.mnuExit.Enabled = true;
			this.mnuExit.Text = "E&xit";
			this.mnuFile = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuFile
			// 
			this.mnuFile.Available = true;
			this.mnuFile.Enabled = true;
			this.mnuFile.Text = "&File";
			this.Picture1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>();
			// 
			// Picture1
			// 
			this.Picture1.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.Picture1.Enabled = true;
			this.Picture1.Name = "Picture1";
			this.Picture1.Visible = true;
			this.Text = "TFD - Incident Reporting System";
			this.Name = "TFDIncident.MDIIncident";
			IsMdiParent = true;
		}

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuExit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuFile { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PictureBoxViewModel Picture1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiParent { get; set; }

	}

}