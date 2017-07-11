using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmChangeCallBackNum))]
	public class frmChangeCallBackNumViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.cboDebitGroup = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboDebitGroup
			// 
			this.cboDebitGroup.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboDebitGroup.Enabled = true;
			this.cboDebitGroup.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboDebitGroup.Name = "cboDebitGroup";
			this.cboDebitGroup.TabIndex = 10;
			this.cboDebitGroup.Text = "cboDebitGroup";
			this.cboDebitGroup.Visible = true;
			this.cboNumber = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboNumber
			// 
			this.cboNumber.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboNumber.Enabled = true;
			this.cboNumber.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboNumber.Name = "cboNumber";
			this.cboNumber.TabIndex = 8;
			this.cboNumber.Text = "cboNumber";
			this.cboNumber.Visible = true;
			this.cboShift = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboShift
			// 
			this.cboShift.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboShift.Enabled = true;
			this.cboShift.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboShift.Name = "cboShift";
			this.cboShift.TabIndex = 6;
			this.cboShift.Text = "cboShift";
			this.cboShift.Visible = true;
			this.Label5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label5
			// 
			this.Label5.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label5.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 0, 0);
			this.Label5.Name = "Label5";
			this.Label5.TabIndex = 11;
			this.Label5.Text = "* Note:  To Delete Record... Just blank out  Shift, Number & Debit Group...";
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 0, 64);
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 255, 128);
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 9;
			this.Label4.Text = "Debit Group";
			this.lbRecordID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRecordID
			// 
			this.lbRecordID.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbRecordID.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbRecordID.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbRecordID.Name = "lbRecordID";
			this.lbRecordID.TabIndex = 7;
			this.lbRecordID.Text = "lbRecordID";
			this.lbRecordID.Visible = false;
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 0, 64);
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 255, 128);
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 5;
			this.Label3.Text = "Shift";
			this.lblEmployeeName = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lblEmployeeName
			// 
			this.lblEmployeeName.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 0, 64);
			this.lblEmployeeName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lblEmployeeName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 128);
			this.lblEmployeeName.Name = "lblEmployeeName";
			this.lblEmployeeName.TabIndex = 4;
			this.lblEmployeeName.Text = "lblEmployeeName";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 0, 64);
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 255, 255);
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 3;
			this.Label1.Text = "Change the Callback Number for:";
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 0, 64);
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 255, 128);
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 2;
			this.Label2.Text = "Number";
			this.OKButton = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// OKButton
			// 
			this.OKButton.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.OKButton.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.OKButton.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.OKButton.Name = "OKButton";
			this.OKButton.TabIndex = 1;
			this.OKButton.Text = "Done";
			this.CancelButton_Renamed = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// CancelButton_Renamed
			// 
			this.CancelButton_Renamed.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.CancelButton_Renamed.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.CancelButton_Renamed.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.CancelButton_Renamed.Name = "CancelButton_Renamed";
			this.CancelButton_Renamed.TabIndex = 0;
			this.CancelButton_Renamed.Text = "Cancel";
			this.Text = "Change Employee's Callback Number";
			this._cScheduler = null;
			this.sEmpID = "";
			this.chkAvailSpecEvent = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkAvailSpecEvent.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 0, 64);
			this.chkAvailSpecEvent.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkAvailSpecEvent.Enabled = true;
			this.chkAvailSpecEvent.ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			this.chkAvailSpecEvent.Name = "chkAvailSpecEvent";
			this.chkAvailSpecEvent.TabIndex = 14;
			this.chkAvailSpecEvent.Text = "Available For Special Events";
			this.chkAvailSpecEvent.Visible = true;
			this.chkAvailMedic6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkAvailMedic6.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 0, 64);
			this.chkAvailMedic6.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkAvailMedic6.Enabled = true;
			this.chkAvailMedic6.ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			this.chkAvailMedic6.Name = "chkAvailMedic6";
			this.chkAvailMedic6.TabIndex = 13;
			this.chkAvailMedic6.Text = "Available For Medic 6";
			this.chkAvailMedic6.Visible = true;
			this.FirstTime = false;
			this.Name = "PTSProject.frmChangeCallBackNum";
		}

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboDebitGroup { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboNumber { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboShift { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRecordID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lblEmployeeName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel OKButton { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel CancelButton_Renamed { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual PTSProject.clsScheduler _cScheduler { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String sEmpID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkAvailSpecEvent { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkAvailMedic6 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean FirstTime { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

	}

}