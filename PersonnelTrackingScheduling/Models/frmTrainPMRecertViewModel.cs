using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmTrainPMRecert))]
	public class frmTrainPMRecertViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.sprReport2 = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprReport2.MaxCols = 24;
			this.sprReport2.TabIndex = 24;
			this.sprReport = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprReport.MaxCols = 22;
			this.sprReport.TabIndex = 14;
			this.sprReport.Visible = false;
			this.optAll = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.optAll.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.optAll.Checked = true;
			this.optAll.Enabled = true;
			this.optAll.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.optAll.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 128);
			this.optAll.Name = "optAll";
			this.optAll.TabIndex = 23;
			this.optAll.Text = "ALL";
			this.optAll.Visible = true;
			this.opt182 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.opt182.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.opt182.Checked = false;
			this.opt182.Enabled = true;
			this.opt182.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.opt182.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 128);
			this.opt182.Name = "opt182";
			this.opt182.TabIndex = 22;
			this.opt182.Text = "Batt 2";
			this.opt182.Visible = true;
			this.opt181 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.opt181.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.opt181.Checked = false;
			this.opt181.Enabled = true;
			this.opt181.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.opt181.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 128);
			this.opt181.Name = "opt181";
			this.opt181.TabIndex = 21;
			this.opt181.Text = "Batt 1";
			this.opt181.Visible = true;
			this.opt183 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.opt183.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.opt183.Checked = false;
			this.opt183.Enabled = true;
			this.opt183.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.opt183.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 128);
			this.opt183.Name = "opt183";
			this.opt183.TabIndex = 20;
			this.opt183.Text = "Batt 3";
			this.opt183.Visible = true;
			this.optGrp1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.optGrp1.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.optGrp1.Checked = false;
			this.optGrp1.Enabled = true;
			this.optGrp1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.optGrp1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 128);
			this.optGrp1.Name = "optGrp1";
			this.optGrp1.TabIndex = 18;
			this.optGrp1.Text = "Group 1";
			this.optGrp1.Visible = true;
			this.optGrp2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.optGrp2.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.optGrp2.Checked = false;
			this.optGrp2.Enabled = true;
			this.optGrp2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.optGrp2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 128);
			this.optGrp2.Name = "optGrp2";
			this.optGrp2.TabIndex = 17;
			this.optGrp2.Text = "Group 2";
			this.optGrp2.Visible = true;
			this.optGrp3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.optGrp3.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.optGrp3.Checked = false;
			this.optGrp3.Enabled = true;
			this.optGrp3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.optGrp3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 128);
			this.optGrp3.Name = "optGrp3";
			this.optGrp3.TabIndex = 16;
			this.optGrp3.Text = "Group 3";
			this.optGrp3.Visible = true;
			this.optD = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.optD.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.optD.Checked = false;
			this.optD.Enabled = true;
			this.optD.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.optD.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 128);
			this.optD.Name = "optD";
			this.optD.TabIndex = 8;
			this.optD.Text = "Shift D";
			this.optD.Visible = true;
			this.optC = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.optC.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.optC.Checked = false;
			this.optC.Enabled = true;
			this.optC.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.optC.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 128);
			this.optC.Name = "optC";
			this.optC.TabIndex = 7;
			this.optC.Text = "Shift C";
			this.optC.Visible = true;
			this.optB = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.optB.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.optB.Checked = false;
			this.optB.Enabled = true;
			this.optB.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.optB.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 128);
			this.optB.Name = "optB";
			this.optB.TabIndex = 6;
			this.optB.Text = "Shift B";
			this.optB.Visible = true;
			this.optA = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.optA.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.optA.Checked = false;
			this.optA.Enabled = true;
			this.optA.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.optA.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 128);
			this.optA.Name = "optA";
			this.optA.TabIndex = 5;
			this.optA.Text = "Shift A";
			this.optA.Visible = true;
			this.dtStart = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dtStart.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.dtStart.MinDate = System.DateTime.Parse("1990/1/1");
			this.dtStart.Name = "dtStart";
			this.dtStart.TabIndex = 9;
			this.dtEnd = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dtEnd.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.dtEnd.MinDate = System.DateTime.Parse("1990/1/1");
			this.dtEnd.Name = "dtEnd";
			this.dtEnd.TabIndex = 10;
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 192, 128);
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 13;
			this.Label2.Text = "Select Date Range";
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 255, 255);
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 12;
			this.Label3.Text = "From:";
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 255, 255);
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 11;
			this.Label4.Text = "Thru:";
			this.sprReport_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			// 
			// sprReport_Sheet1
			// 
			this.sprReport_Sheet1.SheetName = "Sheet1";
			this.sprReport2_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			// 
			// sprReport2_Sheet1
			// 
			this.sprReport2_Sheet1.SheetName = "Sheet1";
			this.cmdPrint = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrint.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdPrint.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.TabIndex = 3;
			this.cmdPrint.Text = "Print Report";
			this.cmdClear = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClear
			// 
			this.cmdClear.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClear.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdClear.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClear.Name = "cmdClear";
			this.cmdClear.TabIndex = 2;
			this.cmdClear.Text = "Clear Filters";
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 1;
			this.cmdClose.Text = "&Close";
			this.Text = "TFD Training Paramedic Recertification";
			this.FirstTime = false;
			this.CurrBatt = "";
			this.CurrShift = "";
			this.CurrGroup = 0;
			this.Name = "PTSProject.frmTrainPMRecert";
			IsMdiChild = true;
			this.sprReport2.Sheets.Add(sprReport2_Sheet1);
			this.sprReport.Sheets.Add(sprReport_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprReport2 { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optAll { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel opt182 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel opt181 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel opt183 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optGrp1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optGrp2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optGrp3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optD { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optC { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optB { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optA { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dtStart { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dtEnd { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprReport_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprReport2_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClear { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean isInitializingComponent { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean FirstTime { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrBatt { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrShift { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrGroup { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}