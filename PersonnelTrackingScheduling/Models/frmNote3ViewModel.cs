using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmNote3))]
	public class frmNote3ViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.txtNote = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtNote.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtNote.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtNote.Name = "txtNote";
			this.txtNote.TabIndex = 2;
			this.lbTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbTitle
			// 
			this.lbTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbTitle.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.TabIndex = 4;
			this.lbTitle.Text = "Notes for 12/31/97";
			this.lbLocked = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLocked
			// 
			this.lbLocked.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbLocked.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbLocked.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.lbLocked.Name = "lbLocked";
			this.lbLocked.TabIndex = 3;
			this.lbLocked.Text = "Schedule Locked";
			this.lbLocked.Visible = false;
			this.Shape1 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this.Shape1.Enabled = false;
			this.Shape1.Name = "Shape1";
			this.Shape1.Visible = true;
			this.cmdOK = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdOK
			// 
			this.cmdOK.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdOK.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdOK.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 1;
			this.cmdOK.Text = "&OK";
			this.cmdCancel = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdCancel
			// 
			this.cmdCancel.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdCancel.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdCancel.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 0;
			this.cmdCancel.Text = "&Cancel";
			this.Text = "Battalion 183 Notes";
			this.NoteID = 0;
			this.Name = "PTSProject.frmNote3";
			IsMdiChild = true;
		}

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtNote { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLocked { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel Shape1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdOK { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdCancel { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 NoteID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}