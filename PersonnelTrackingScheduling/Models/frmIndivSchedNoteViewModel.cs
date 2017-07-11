using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmIndivSchedNote))]
	public class frmIndivSchedNoteViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.txtEdit = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtEdit.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtEdit.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtEdit.Name = "txtEdit";
			this.txtEdit.TabIndex = 0;
			this.txtNote = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtNote.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.txtNote.Enabled = false;
			this.txtNote.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtNote.Name = "txtNote";
			this.txtNote.TabIndex = 3;
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 4;
			this.Label1.Text = "Add a new Individual Schedule Note:";
			this.cmdOK = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdOK
			// 
			this.cmdOK.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdOK.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdOK.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 1;
			this.cmdOK.Text = "&OK";
			this.cmdCancel = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdCancel
			// 
			this.cmdCancel.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdCancel.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdCancel.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 2;
			this.cmdCancel.Text = "&Cancel";
			this.Text = "Schedule Note";
			this.Name = "PTSProject.frmIndivSchedNote";
		}

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtEdit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtNote { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdOK { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdCancel { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

	}

}