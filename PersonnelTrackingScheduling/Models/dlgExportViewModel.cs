using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.dlgExport))]
	public class dlgExportViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.txtFileName = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtFileName.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtFileName.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtFileName.Name = "txtFileName";
			this.txtFileName.TabIndex = 0;
			this.txtFileName.Text = "*.xls";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 6;
			this.Label1.Text = "Save File as...";
			this.OKButton = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// OKButton
			// 
			this.OKButton.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.OKButton.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.OKButton.Name = "OKButton";
			this.OKButton.TabIndex = 5;
			this.OKButton.Text = "OK";
			this.CancelButton_Renamed = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// CancelButton_Renamed
			// 
			this.CancelButton_Renamed.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.CancelButton_Renamed.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.CancelButton_Renamed.Name = "CancelButton_Renamed";
			this.CancelButton_Renamed.TabIndex = 4;
			this.CancelButton_Renamed.Text = "Cancel";
			this.Drive1 = ctx.Resolve<Stubs._Microsoft.VisualBasic.Compatibility.VB6.DriveListBox>();
			// 
			// Drive1
			// 
			this.Drive1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.Drive1.Enabled = true;
			this.Drive1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.Drive1.Name = "Drive1";
			this.Drive1.TabIndex = 3;
			this.Drive1.Visible = true;
			this.Dir1 = ctx.Resolve<Stubs._Microsoft.VisualBasic.Compatibility.VB6.DirListBox>();
			// 
			// Dir1
			// 
			this.Dir1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.Dir1.Enabled = true;
			this.Dir1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.Dir1.Name = "Dir1";
			this.Dir1.TabIndex = 2;
			this.Dir1.Visible = true;
			this.File1 = ctx.Resolve<Stubs._Microsoft.VisualBasic.Compatibility.VB6.FileListBox>();
			this.File1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.File1.Enabled = true;
			this.File1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.File1.Name = "File1";
			this.File1.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.File1.TabIndex = 1;
			this.File1.Visible = true;
			this.Text = "Export to Excel";
			this.Name = "PTSProject.dlgExport";
		}

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtFileName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel OKButton { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel CancelButton_Renamed { get; set; }

		public virtual Stubs._Microsoft.VisualBasic.Compatibility.VB6.DriveListBox Drive1 { get; set; }

		public virtual Stubs._Microsoft.VisualBasic.Compatibility.VB6.DirListBox Dir1 { get; set; }

		public virtual Stubs._Microsoft.VisualBasic.Compatibility.VB6.FileListBox File1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

	}

}