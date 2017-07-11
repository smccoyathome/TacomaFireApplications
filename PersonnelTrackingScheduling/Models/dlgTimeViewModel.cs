using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.dlgTime))]
	public class dlgTimeViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.txtLeaveNotes = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtLeaveNotes.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtLeaveNotes.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtLeaveNotes.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtLeaveNotes.Name = "txtLeaveNotes";
			this.txtLeaveNotes.TabIndex = 14;
			this.calEndLeave = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.calEndLeave.MaxDate = System.DateTime.Parse("2999/12/31");
			this.calEndLeave.MinDate = System.DateTime.Parse("1996/1/1");
			this.calEndLeave.Name = "calEndLeave";
			this.calEndLeave.TabIndex = 13;
			this.calStartLeave = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.calStartLeave.MaxDate = System.DateTime.Parse("2999/12/31");
			this.calStartLeave.MinDate = System.DateTime.Parse("1996/1/1");
			this.calStartLeave.Name = "calStartLeave";
			this.calStartLeave.TabIndex = 12;
			this.cboJob = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboJob
			// 
			this.cboJob.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboJob.Enabled = true;
			this.cboJob.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Courier New", 10.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboJob.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboJob.Name = "cboJob";
			this.cboJob.TabIndex = 1;
			this.cboJob.Visible = false;
			this.cboLeave = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboLeave
			// 
			this.cboLeave.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboLeave.Enabled = true;
			this.cboLeave.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Courier New", 10.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboLeave.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboLeave.Name = "cboLeave";
			this.cboLeave.TabIndex = 0;
			this.cboLeave.Visible = true;
			this.lbEmpInfo = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEmpInfo
			// 
			this.lbEmpInfo.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbEmpInfo.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbEmpInfo.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.lbEmpInfo.Name = "lbEmpInfo";
			this.lbEmpInfo.TabIndex = 17;
			this.lbEmpInfo.Text = "lbEmpInfo";
			this.lblDefault = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lblDefault
			// 
			this.lblDefault.BackColor = UpgradeHelpers.Helpers.Color.Gray;
			this.lblDefault.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lblDefault.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 255, 192);
			this.lblDefault.Name = "lblDefault";
			this.lblDefault.TabIndex = 16;
			this.lblDefault.Text = "Position Job Code:  ";
			this.lblDefault.Visible = false;
			this.lbLeaveNotes = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLeaveNotes
			// 
			this.lbLeaveNotes.BackColor = UpgradeHelpers.Helpers.Color.Gray;
			this.lbLeaveNotes.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbLeaveNotes.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.lbLeaveNotes.Name = "lbLeaveNotes";
			this.lbLeaveNotes.TabIndex = 15;
			this.lbLeaveNotes.Text = "Schedule/Leave Notes";
			this.lbEnd = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEnd
			// 
			this.lbEnd.BackColor = UpgradeHelpers.Helpers.Color.Gray;
			this.lbEnd.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbEnd.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.lbEnd.Name = "lbEnd";
			this.lbEnd.TabIndex = 11;
			this.lbEnd.Text = "End Date";
			this.lbStart = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbStart
			// 
			this.lbStart.BackColor = UpgradeHelpers.Helpers.Color.Gray;
			this.lbStart.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbStart.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.lbStart.Name = "lbStart";
			this.lbStart.TabIndex = 10;
			this.lbStart.Text = "Start Date";
			this.boxVacBank = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this.boxVacBank.Enabled = false;
			this.boxVacBank.Name = "boxVacBank";
			this.boxVacBank.Visible = false;
			this.boxAMPM = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this.boxAMPM.Enabled = false;
			this.boxAMPM.Name = "boxAMPM";
			this.boxAMPM.Visible = false;
			this.lbAMPM = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAMPM
			// 
			this.lbAMPM.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAMPM.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.lbAMPM.Name = "lbAMPM";
			this.lbAMPM.TabIndex = 2;
			this.lbAMPM.Visible = false;
			this.lbJob = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbJob
			// 
			this.lbJob.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbJob.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbJob.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.lbJob.Name = "lbJob";
			this.lbJob.TabIndex = 6;
			this.lbJob.Text = "Pay Upgrade";
			this.lbJob.Visible = false;
			this.lbTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbTitle
			// 
			this.lbTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.TabIndex = 5;
			this.lbTitle.Text = "Leave Type";
			this.chkSCKflag = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkSCKflag.BackColor = UpgradeHelpers.Helpers.Color.Gray;
			this.chkSCKflag.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkSCKflag.Enabled = true;
			this.chkSCKflag.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.chkSCKflag.Name = "chkSCKflag";
			this.chkSCKflag.TabIndex = 18;
			this.chkSCKflag.Text = "Instead of SCK Leave";
			this.chkSCKflag.Visible = false;
			this.chkExtend = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkExtend.BackColor = UpgradeHelpers.Helpers.Color.Gray;
			this.chkExtend.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkExtend.Enabled = true;
			this.chkExtend.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers.
						Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Underline | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkExtend.ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			this.chkExtend.Name = "chkExtend";
			this.chkExtend.TabIndex = 9;
			this.chkExtend.Text = "Extend Leave?";
			this.chkExtend.Visible = true;
			this.chkVacBank = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkVacBank.BackColor = UpgradeHelpers.Helpers.Color.Gray;
			this.chkVacBank.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkVacBank.Enabled = true;
			this.chkVacBank.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.chkVacBank.Name = "chkVacBank";
			this.chkVacBank.TabIndex = 8;
			this.chkVacBank.Text = "Use Banked Vacation";
			this.chkVacBank.Visible = false;
			this.cmdCancel = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdCancel
			// 
			this.cmdCancel.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdCancel.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 4;
			this.cmdCancel.Text = "&Cancel";
			this.cmdOK = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdOK
			// 
			this.cmdOK.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdOK.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 3;
			this.cmdOK.Text = "&OK";
			this.Text = "Select Type of Leave";
			this.chkAMPM = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkAMPM.BackColor = UpgradeHelpers.Helpers.Color.Gray;
			this.chkAMPM.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkAMPM.Enabled = true;
			this.chkAMPM.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.chkAMPM.Name = "chkAMPM";
			this.chkAMPM.TabIndex = 7;
			this.chkAMPM.Text = "Schedule Both AM and PM Shifts";
			this.chkAMPM.Visible = false;
			this.NotesRequired = false;
			this.Name = "PTSProject.dlgTime";
		}

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtLeaveNotes { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel calEndLeave { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel calStartLeave { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboJob { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboLeave { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEmpInfo { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lblDefault { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLeaveNotes { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEnd { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbStart { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel boxVacBank { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel boxAMPM { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAMPM { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbJob { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkSCKflag { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkExtend { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkVacBank { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdCancel { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdOK { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkAMPM { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean NotesRequired { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

	}

}