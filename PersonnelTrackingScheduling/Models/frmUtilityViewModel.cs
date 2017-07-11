using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmUtility))]
	public class frmUtilityViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var _chkTable_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkTable_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkTable_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.calStart = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.calStart.MaxDate = System.DateTime.Parse("2999/12/31");
			this.calStart.MinDate = System.DateTime.Parse("1998/1/1");
			this.calStart.Name = "calStart";
			this.calStart.TabIndex = 2;
			this.calStart.Visible = false;
			this.cboAction = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboAction
			// 
			this.cboAction.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboAction.Enabled = true;
			this.cboAction.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboAction.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboAction.Name = "cboAction";
			this.cboAction.TabIndex = 0;
			this.cboAction.Visible = true;
			this.calEnd = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.calEnd.MaxDate = System.DateTime.Parse("2999/12/31");
			this.calEnd.MinDate = System.DateTime.Parse("1998/1/1");
			this.calEnd.Name = "calEnd";
			this.calEnd.TabIndex = 4;
			this.calEnd.Visible = false;
			this.lbStatus = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbStatus
			// 
			this.lbStatus.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.lbStatus.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbStatus.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbStatus.Name = "lbStatus";
			this.lbStatus.TabIndex = 16;
			this.lbStatus.Text = "lbStatus";
			this.lbStatus.Visible = false;
			this.lbLastDate = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLastDate
			// 
			this.lbLastDate.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.lbLastDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbLastDate.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.lbLastDate.Name = "lbLastDate";
			this.lbLastDate.TabIndex = 15;
			this.lbLastDate.Text = "lbLastDate";
			this.lbLastDate.Visible = false;
			this.lbLastDateTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLastDateTitle
			// 
			this.lbLastDateTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbLastDateTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbLastDateTitle.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.lbLastDateTitle.Name = "lbLastDateTitle";
			this.lbLastDateTitle.TabIndex = 14;
			this.lbLastDateTitle.Text = "Last Date of Current Schedule:";
			this.lbLastDateTitle.Visible = false;
			this.lbEnd = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEnd
			// 
			this.lbEnd.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbEnd.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbEnd.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			this.lbEnd.Name = "lbEnd";
			this.lbEnd.TabIndex = 5;
			this.lbEnd.Text = "Select End Date";
			this.lbEnd.Visible = false;
			this.lbStart = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbStart
			// 
			this.lbStart.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbStart.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbStart.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			this.lbStart.Name = "lbStart";
			this.lbStart.TabIndex = 3;
			this.lbStart.Text = "Select Start Date";
			this.lbStart.Visible = false;
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 1;
			this.Label1.Text = "Select Action";
			this.cmdExit = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdExit
			// 
			this.cmdExit.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdExit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdExit.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdExit.Name = "cmdExit";
			this.cmdExit.TabIndex = 8;
			this.cmdExit.Text = "&Exit";
			this.cmdGo = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdGo
			// 
			this.cmdGo.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdGo.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdGo.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdGo.Name = "cmdGo";
			this.cmdGo.TabIndex = 6;
			this.cmdGo.Tag = "\"Sched\"";
			this.cmdGo.Text = "Create New Schedule Records Now";
			this.cmdGo.Visible = false;
			this.Text = "Schedule Calendar Utilities";
			this.pb1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ProgressBarViewModel>();
			this.pb1.Name = "pb1";
			this.pb1.TabIndex = 17;
			this.pb1.Visible = false;
			this.cmdCancel = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdCancel
			// 
			this.cmdCancel.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdCancel.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdCancel.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 7;
			this.cmdCancel.Text = "&Cancel";
			this.cmdCancel.Visible = false;
			this.chkRemove = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkRemove.BackColor = UpgradeHelpers.Helpers.Color.Teal;
			this.chkRemove.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkRemove.Enabled = true;
			this.chkRemove.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers.
						Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkRemove.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.chkRemove.Name = "chkRemove";
			this.chkRemove.TabIndex = 13;
			this.chkRemove.Text = "Remove Old Records ";
			this.chkRemove.Visible = false;
			this.frArchive = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frArchive
			// 
			this.frArchive.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			this.frArchive.Enabled = true;
			this.frArchive.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frArchive.Name = "frArchive";
			this.frArchive.TabIndex = 9;
			this.frArchive.Text = "Archive These Tables";
			this.frArchive.Visible = false;
			chkTable = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>>(3);
			chkTable[2] = _chkTable_2;
			chkTable[1] = _chkTable_1;
			chkTable[0] = _chkTable_0;
			chkTable[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			chkTable[2].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkTable[2].Enabled = true;
			chkTable[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkTable[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			chkTable[2].Name = "_chkTable_2";
			chkTable[2].TabIndex = 12;
			chkTable[2].Text = "Notes";
			chkTable[2].Visible = true;
			chkTable[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			chkTable[1].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkTable[1].Enabled = true;
			chkTable[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkTable[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			chkTable[1].Name = "_chkTable_1";
			chkTable[1].TabIndex = 11;
			chkTable[1].Text = "Leave";
			chkTable[1].Visible = true;
			chkTable[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			chkTable[0].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkTable[0].Enabled = true;
			chkTable[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkTable[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			chkTable[0].Name = "_chkTable_0";
			chkTable[0].TabIndex = 10;
			chkTable[0].Text = "Schedule";
			chkTable[0].Visible = true;
			this.Name = "PTSProject.frmUtility";
			IsMdiChild = true;
			cboAction.Items.Add("Create New Schedule Records");
			cboAction.Items.Add("Archive Schedule/Leave Records");
			cboAction.Items.Add("Create New Shift CalendarRecords");
		}

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel calStart { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboAction { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel calEnd { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbStatus { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLastDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLastDateTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEnd { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbStart { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdExit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdGo { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ProgressBarViewModel pb1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdCancel { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkRemove { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frArchive { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.CheckBoxViewModel> chkTable { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}