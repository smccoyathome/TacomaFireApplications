using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmMakeShiftAvailable))]
	public class frmMakeShiftAvailableViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.txtAvailComment = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtAvailComment.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtAvailComment.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtAvailComment.Name = "txtAvailComment";
			this.txtAvailComment.TabIndex = 3;
			this.txtAvailComment.Text = "txtAvailComment";
			this.dtpGiveOut = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dtpGiveOut.Name = "dtpGiveOut";
			this.dtpGiveOut.TabIndex = 2;
			this.Label11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label11
			// 
			this.Label11.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 0, 64);
			this.Label11.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label11.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.Label11.Name = "Label11";
			this.Label11.TabIndex = 16;
			this.Label11.Text = "Give Date Out On:";
			this.lbSelectTitle1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSelectTitle1
			// 
			this.lbSelectTitle1.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 0, 64);
			this.lbSelectTitle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbSelectTitle1.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.lbSelectTitle1.Name = "lbSelectTitle1";
			this.lbSelectTitle1.TabIndex = 15;
			this.lbSelectTitle1.Text = "Scheduled Leave Totals";
			this.lbSelectTitle1.Visible = false;
			this.lbREGpm = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbREGpm
			// 
			this.lbREGpm.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 0, 64);
			this.lbREGpm.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbREGpm.ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			this.lbREGpm.Name = "lbREGpm";
			this.lbREGpm.TabIndex = 12;
			this.lbREGpm.Text = "lbREGpm";
			this.lbREGpm.Visible = false;
			this.lbREGam = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbREGam
			// 
			this.lbREGam.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 0, 64);
			this.lbREGam.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbREGam.ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			this.lbREGam.Name = "lbREGam";
			this.lbREGam.TabIndex = 11;
			this.lbREGam.Text = "lbREGam";
			this.lbREGam.Visible = false;
			this.lbExistAM = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbExistAM
			// 
			this.lbExistAM.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbExistAM.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbExistAM.Name = "lbExistAM";
			this.lbExistAM.TabIndex = 10;
			this.lbExistAM.Text = "llbExistAM";
			this.lbExistAM.Visible = false;
			this.lbExistPM = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbExistPM
			// 
			this.lbExistPM.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbExistPM.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbExistPM.Name = "lbExistPM";
			this.lbExistPM.TabIndex = 9;
			this.lbExistPM.Text = "llbExistPM";
			this.lbExistPM.Visible = false;
			this.lbAvailComment = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAvailComment
			// 
			this.lbAvailComment.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 0, 64);
			this.lbAvailComment.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbAvailComment.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 128, 255);
			this.lbAvailComment.Name = "lbAvailComment";
			this.lbAvailComment.TabIndex = 8;
			this.lbAvailComment.Text = "Add Comment:";
			this.lbSelectAM = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSelectAM
			// 
			this.lbSelectAM.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 0, 64);
			this.lbSelectAM.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbSelectAM.ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			this.lbSelectAM.Name = "lbSelectAM";
			this.lbSelectAM.TabIndex = 13;
			this.lbSelectAM.Text = "lbSelectAM";
			this.lbSelectAM.Visible = false;
			this.lbSelectPM = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSelectPM
			// 
			this.lbSelectPM.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 0, 64);
			this.lbSelectPM.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbSelectPM.ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			this.lbSelectPM.Name = "lbSelectPM";
			this.lbSelectPM.TabIndex = 14;
			this.lbSelectPM.Text = "lbSelectPM";
			this.lbSelectPM.Visible = false;
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 5;
			this.cmdClose.Text = "Cancel";
			this.cmdAvailDone = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAvailDone
			// 
			this.cmdAvailDone.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAvailDone.Enabled = false;
			this.cmdAvailDone.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdAvailDone.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAvailDone.Name = "cmdAvailDone";
			this.cmdAvailDone.TabIndex = 4;
			this.cmdAvailDone.Text = "Done";
			this.calAvail = ctx.Resolve<UpgradeHelpers.BasicViewModels.MonthCalendarViewModel>();
			this.calAvail.Name = "calAvail";
			this.calAvail.TabIndex = 6;
			this.Text = "Make Shift Available";
			this.SelectedDate = "";
			this.chkPM = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkPM.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 0, 64);
			this.chkPM.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
			this.chkPM.Enabled = true;
			this.chkPM.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8.25f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkPM.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.chkPM.Name = "chkPM";
			this.chkPM.TabIndex = 1;
			this.chkPM.Text = "PM";
			this.chkPM.Visible = true;
			this.chkAM = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkAM.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 0, 64);
			this.chkAM.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
			this.chkAM.Enabled = true;
			this.chkAM.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8.25f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkAM.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.chkAM.Name = "chkAM";
			this.chkAM.TabIndex = 0;
			this.chkAM.Text = "AM";
			this.chkAM.Visible = true;
			this.SelectedSchedDate = "";
			this.Name = "PTSProject.frmMakeShiftAvailable";
		}

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtAvailComment { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dtpGiveOut { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSelectTitle1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbREGpm { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbREGam { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbExistAM { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbExistPM { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAvailComment { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSelectAM { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSelectPM { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAvailDone { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MonthCalendarViewModel calAvail { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String SelectedDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkPM { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkAM { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String SelectedSchedDate { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

	}

}