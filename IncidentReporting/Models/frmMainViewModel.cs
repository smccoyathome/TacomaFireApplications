using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace TFDIncident.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(TFDIncident.frmMain))]
	public class frmMainViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			FarPoint.ViewModels.NamedStyle namedStyle31;
			var textCellType10 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle30;
			FarPoint.ViewModels.NamedStyle namedStyle29;
			FarPoint.ViewModels.NamedStyle namedStyle28;
			var textCellType9 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle27;
			FarPoint.ViewModels.NamedStyle namedStyle26;
			FarPoint.ViewModels.NamedStyle namedStyle25;
			var textCellType8 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle24;
			FarPoint.ViewModels.NamedStyle namedStyle23;
			FarPoint.ViewModels.NamedStyle namedStyle22;
			var textCellType7 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle21;
			FarPoint.ViewModels.NamedStyle namedStyle20;
			FarPoint.ViewModels.NamedStyle namedStyle19;
			var textCellType6 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle18;
			FarPoint.ViewModels.NamedStyle namedStyle17;
			FarPoint.ViewModels.NamedStyle namedStyle16;
			FarPoint.ViewModels.NamedStyle namedStyle15;
			var textCellType5 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle14;
			FarPoint.ViewModels.NamedStyle namedStyle13;
			FarPoint.ViewModels.NamedStyle namedStyle12;
			FarPoint.ViewModels.NamedStyle namedStyle11;
			var textCellType4 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle10;
			FarPoint.ViewModels.NamedStyle namedStyle9;
			FarPoint.ViewModels.NamedStyle namedStyle8;
			FarPoint.ViewModels.NamedStyle namedStyle7;
			var textCellType3 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle6;
			FarPoint.ViewModels.NamedStyle namedStyle5;
			var textCellType2 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle4;
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.calFRStart = ctx.Resolve<UpgradeHelpers.BasicViewModels.MonthCalendarViewModel>();
			this.calFRStart.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.calFRStart.Name = "calFRStart";
			this.calFRStart.TabIndex = 71;
			this.calFREnd = ctx.Resolve<UpgradeHelpers.BasicViewModels.MonthCalendarViewModel>();
			this.calFREnd.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.calFREnd.Name = "calFREnd";
			this.calFREnd.TabIndex = 72;
			this.cboFieldReport = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboFieldReport
			// 
			this.cboFieldReport.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboFieldReport.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboFieldReport.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboFieldReport.Name = "cboFieldReport";
			this.cboFieldReport.TabIndex = 69;
			this.cboFieldReport.Text = "cboFieldReport";
			this.cboSelection1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboSelection1
			// 
			this.cboSelection1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboSelection1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboSelection1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboSelection1.Name = "cboSelection1";
			this.cboSelection1.TabIndex = 78;
			this.cboSelection1.Text = "cboSelection1";
			this.cboSelection1.Visible = false;
			this.cboSelection2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboSelection2
			// 
			this.cboSelection2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboSelection2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboSelection2.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboSelection2.Name = "cboSelection2";
			this.cboSelection2.TabIndex = 77;
			this.cboSelection2.Text = "cboSelection2";
			this.cboSelection2.Visible = false;
			this.txtHelpTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtHelpTitle.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtHelpTitle.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtHelpTitle.Name = "txtHelpTitle";
			this.txtHelpTitle.TabIndex = 105;
			this.txtHelpTitle.Text = "txtHelpTitle";
			this.txtHelpText = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtHelpText.Name = "txtHelpText";
			this.txtHelpText.TabIndex = 104;
			this.cboReportList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboReportList
			// 
			this.cboReportList.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboReportList.Enabled = false;
			this.cboReportList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboReportList.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboReportList.Name = "cboReportList";
			this.cboReportList.TabIndex = 88;
			this.cboReportList.Visible = false;
			this.cboSysAdm2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboSysAdm2
			// 
			this.cboSysAdm2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboSysAdm2.Enabled = false;
			this.cboSysAdm2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboSysAdm2.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboSysAdm2.Name = "cboSysAdm2";
			this.cboSysAdm2.TabIndex = 86;
			this.cboSysAdm2.Text = "cboSysAdm2";
			this.cboSysAdm2.Visible = false;
			this.cboSysAdm1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboSysAdm1
			// 
			this.cboSysAdm1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboSysAdm1.Enabled = false;
			this.cboSysAdm1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboSysAdm1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboSysAdm1.Name = "cboSysAdm1";
			this.cboSysAdm1.TabIndex = 84;
			this.cboSysAdm1.Text = "cboSysAdm1";
			this.cboSysAdm1.Visible = false;
			this.txtSysAdm1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtSysAdm1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtSysAdm1.Enabled = false;
			this.txtSysAdm1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtSysAdm1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtSysAdm1.Name = "txtSysAdm1";
			this.txtSysAdm1.TabIndex = 82;
			this.txtSysAdm1.Text = "txtSysAdm1";
			this.txtSysAdm1.Visible = false;
			this.cboSystemAction = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboSystemAction
			// 
			this.cboSystemAction.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboSystemAction.Enabled = false;
			this.cboSystemAction.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboSystemAction.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboSystemAction.Name = "cboSystemAction";
			this.cboSystemAction.TabIndex = 79;
			this.cboSystemAction.Text = "cboSystemAction";
			this._cboFilter_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboFilter_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboFilter_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboFilter_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboFilter_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboFilter_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._txtFilter_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtFilter_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtFilter_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtFilter_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtFilter_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtFilter_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.cboInquiryList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboInquiryList
			// 
			this.cboInquiryList.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboInquiryList.Enabled = false;
			this.cboInquiryList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboInquiryList.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboInquiryList.Name = "cboInquiryList";
			this.cboInquiryList.TabIndex = 43;
			this.cboInquiryList.Text = "cboInquiryList";
			this.lstFields = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstFields
			// 
			this.lstFields.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.lstFields.Enabled = false;
			this.lstFields.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.lstFields.Name = "lstFields";
			this.lstFields.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstFields.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstFields.TabIndex = 42;
			this.lstFilters = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
            // 
            // lstFilters
            // 
            this.lstFilters.BackColor = UpgradeHelpers.Helpers.Color.White;
            this.lstFilters.Enabled = true;
			this.lstFilters.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.lstFilters.Name = "lstFilters";
			this.lstFilters.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstFilters.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstFilters.TabIndex = 41;
			this._optBattalion_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optBattalion_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optBattalion_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.cboStatus = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboStatus
			// 
			this.cboStatus.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboStatus.Enabled = true;
			this.cboStatus.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboStatus.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboStatus.Name = "cboStatus";
			this.cboStatus.TabIndex = 31;
			this.cboIncType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboIncType
			// 
			this.cboIncType.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboIncType.Enabled = true;
			this.cboIncType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboIncType.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboIncType.Name = "cboIncType";
			this.cboIncType.TabIndex = 10;
			this.cboIncType.Text = "cboIncType";
			this.cboIncUnit = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboIncUnit
			// 
			this.cboIncUnit.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboIncUnit.Enabled = true;
			this.cboIncUnit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboIncUnit.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboIncUnit.Name = "cboIncUnit";
			this.cboIncUnit.TabIndex = 9;
			this.cboIncUnit.Text = "cboIncUnit";
			this.cboUnit = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboUnit
			// 
			this.cboUnit.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboUnit.Enabled = true;
			this.cboUnit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboUnit.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboUnit.Name = "cboUnit";
			this.cboUnit.TabIndex = 3;
            this.cboUnit.SelectedIndex = -1;
            

            this.cboType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboType
			// 
			this.cboType.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboType.Enabled = true;
			this.cboType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboType.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboType.Name = "cboType";
			this.cboType.TabIndex = 2;

			this.sprUnitList = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
            this.sprUnitList.Name = "sprUnitList";
            this.sprUnitList.Enabled = true;
			this.sprUnitList.TabIndex = 89;
			this.sprUnitList.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
            this.sprUnitList.Lock = true;
            this.sprUnitList.HideLeftRightBorders = true;


            this.sprIncident = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
            this.sprIncident.Name = "sprIncident";
			this.sprIncident.Enabled = true;
			this.sprIncident.TabIndex = 90;
			this.sprIncident.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;

			this.sprIncReports = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
            this.sprIncReports.Name = "sprIncReports";
			this.sprIncReports.Enabled = true;
			this.sprIncReports.TabIndex = 91;
			this.sprIncReports.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;

            this.sprUnitReports = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
            this.sprUnitReports.Name = "sprUnitReports";          
            this.sprUnitReports.Enabled = true;
            this.sprUnitReports.TabIndex = 92;
            this.sprUnitReports.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;

            //this.sprUnitReports.BorderStyle = UpgradeHelpers.Helpers.BorderStyle.None;			
			//this.sprUnitReports.Get_HorizontalScrollBar().Name = "";
			//this.sprUnitReports.Get_HorizontalScrollBar().TabIndex = 6;						
			//this.sprUnitReports.Get_VerticalScrollBar().Name = "";
			//this.sprUnitReports.Get_VerticalScrollBar().TabIndex = 2;
			this.sprNoteLog = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprNoteLog.Enabled = false;
			this.sprNoteLog.TabIndex = 93;
			this.sprNoteLog.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprNoteLog.Visible = false;
			this.sprSysAdm = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprSysAdm.Enabled = false;
			this.sprSysAdm.MaxRows = 100;
			this.sprSysAdm.TabIndex = 94;
			this.sprSysAdm.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprSysAdm.Visible = false;
			this.sprNotify = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprNotify.Enabled = false;
			this.sprNotify.MaxRows = 100;
			this.sprNotify.TabIndex = 95;
			this.sprNotify.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprNotify.Visible = false;
			this.Label29 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label29
			// 
			this.Label29.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label29.Enabled = false;
			this.Label29.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label29.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(240)))), ((int)(((byte)(177)))));
			this.Label29.Name = "Label29";
			this.Label29.TabIndex = 87;
			this.Label29.Text = "Select  Report";
			this.Label29.Visible = false;
			this.Line1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Line1
			// 
			this.Line1.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(240)))), ((int)(((byte)(177)))));
			this.Line1.Enabled = false;
			this.Line1.Name = "Line1";
			this.Line1.TabIndex = 0;
			this.lbSysAdmin3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSysAdmin3
			// 
			this.lbSysAdmin3.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSysAdmin3.Enabled = false;
			this.lbSysAdmin3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbSysAdmin3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(240)))), ((int)(((byte)(177)))));
			this.lbSysAdmin3.Name = "lbSysAdmin3";
			this.lbSysAdmin3.TabIndex = 85;
			this.lbSysAdmin3.Text = "lbSysAdmin3";
			this.lbSysAdmin3.Visible = false;
			this.lbSysAdmin2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSysAdmin2
			// 
			this.lbSysAdmin2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSysAdmin2.Enabled = false;
			this.lbSysAdmin2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbSysAdmin2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(240)))), ((int)(((byte)(177)))));
			this.lbSysAdmin2.Name = "lbSysAdmin2";
			this.lbSysAdmin2.TabIndex = 83;
			this.lbSysAdmin2.Text = "lbSysAdmin2";
			this.lbSysAdmin2.Visible = false;
			this.lbSysAdmin1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSysAdmin1
			// 
			this.lbSysAdmin1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSysAdmin1.Enabled = false;
			this.lbSysAdmin1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbSysAdmin1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(240)))), ((int)(((byte)(177)))));
			this.lbSysAdmin1.Name = "lbSysAdmin1";
			this.lbSysAdmin1.TabIndex = 81;
			this.lbSysAdmin1.Text = "lbSysAdmin1";
			this.lbSysAdmin1.Visible = false;
			this.Label28 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label28
			// 
			this.Label28.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label28.Enabled = false;
			this.Label28.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label28.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(240)))), ((int)(((byte)(177)))));
			this.Label28.Name = "Label28";
			this.Label28.TabIndex = 80;
			this.Label28.Text = "Select System Activity";
			this.lbSelection1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSelection1
			// 
			this.lbSelection1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSelection1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbSelection1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(240)))), ((int)(((byte)(177)))));
			this.lbSelection1.Name = "lbSelection1";
			this.lbSelection1.TabIndex = 76;
			this.lbSelection1.Text = "Selection Label 1";
			this.lbSelection1.Visible = false;
			this.lbSelection2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSelection2
			// 
			this.lbSelection2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSelection2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbSelection2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(240)))), ((int)(((byte)(177)))));
			this.lbSelection2.Name = "lbSelection2";
			this.lbSelection2.TabIndex = 75;
			this.lbSelection2.Text = "Selection Label 2";
			this.lbSelection2.Visible = false;
			this.Label27 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label27
			// 
			this.Label27.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label27.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label27.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(240)))), ((int)(((byte)(177)))));
			this.Label27.Name = "Label27";
			this.Label27.TabIndex = 74;
			this.Label27.Text = "Select Starting Report Date";
			this.Label26 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label26
			// 
			this.Label26.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label26.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label26.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(240)))), ((int)(((byte)(177)))));
			this.Label26.Name = "Label26";
			this.Label26.TabIndex = 73;
			this.Label26.Text = "Select Ending Report Date";
			this.Label25 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label25
			// 
			this.Label25.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label25.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label25.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(240)))), ((int)(((byte)(177)))));
			this.Label25.Name = "Label25";
			this.Label25.TabIndex = 70;
			this.Label25.Text = "Select Report";
			this.lbCal1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbCal1
			// 
			this.lbCal1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbCal1.Enabled = false;
			this.lbCal1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbCal1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(240)))), ((int)(((byte)(177)))));
			this.lbCal1.Name = "lbCal1";
			this.lbCal1.TabIndex = 62;
			this.lbCal1.Text = "Calendar 1 Label";
			this.lbCal1.Visible = false;
			this.lbCal2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbCal2
			// 
			this.lbCal2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbCal2.Enabled = false;
			this.lbCal2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbCal2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(240)))), ((int)(((byte)(177)))));
			this.lbCal2.Name = "lbCal2";
			this.lbCal2.TabIndex = 61;
			this.lbCal2.Text = "Calendar 2 Label";
			this.lbCal2.Visible = false;
			this._lbFilter_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbFilter_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbFilter_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbFilter_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbFilter_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbFilter_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbSelectInquiry = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSelectInquiry
			// 
			this.lbSelectInquiry.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSelectInquiry.Enabled = false;
			this.lbSelectInquiry.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbSelectInquiry.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(240)))), ((int)(((byte)(177)))));
			this.lbSelectInquiry.Name = "lbSelectInquiry";
			this.lbSelectInquiry.TabIndex = 46;
			this.lbSelectInquiry.Text = "Select Subject Data to Query";
			this.lbViewFields = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbViewFields
			// 
			this.lbViewFields.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbViewFields.Enabled = false;
			this.lbViewFields.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbViewFields.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.lbViewFields.Name = "lbViewFields";
			this.lbViewFields.TabIndex = 45;
			this.lbViewFields.Text = "Select Which Items You Would Like To View";
			this.lbFilterFields = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbFilterFields
			// 
			this.lbFilterFields.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbFilterFields.Enabled = false;
			this.lbFilterFields.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbFilterFields.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.lbFilterFields.Name = "lbFilterFields";
			this.lbFilterFields.TabIndex = 44;
			this.lbFilterFields.Text = "Select Which Items You Would Like To Use as Filters";
			this.Label5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label5
			// 
			this.Label5.BackColor = UpgradeHelpers.Helpers.Color.Navy;
			this.Label5.Enabled = false;
			this.Label5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label5.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.Label5.Name = "Label5";
			this.Label5.TabIndex = 38;
			this.Label5.Text = "Incident#";
			this.Label24 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label24
			// 
			this.Label24.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label24.Enabled = false;
			this.Label24.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label24.ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.Label24.Name = "Label24";
			this.Label24.TabIndex = 32;
			this.Label24.Text = "Filter By Report Status";
			this.Label23 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label23
			// 
			this.Label23.BackColor = UpgradeHelpers.Helpers.Color.Navy;
			this.Label23.Enabled = false;
			this.Label23.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label23.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.Label23.Name = "Label23";
			this.Label23.TabIndex = 29;
			this.Label23.Text = "Incident#";
			this.Label22 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label22
			// 
			this.Label22.BackColor = UpgradeHelpers.Helpers.Color.Navy;
			this.Label22.Enabled = false;
			this.Label22.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label22.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.Label22.Name = "Label22";
			this.Label22.TabIndex = 28;
			this.Label22.Text = "Time";
			this.Label21 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label21
			// 
			this.Label21.BackColor = UpgradeHelpers.Helpers.Color.Navy;
			this.Label21.Enabled = false;
			this.Label21.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label21.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.Label21.Name = "Label21";
			this.Label21.TabIndex = 27;
			this.Label21.Text = "Location";
			this.Label20 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label20
			// 
			this.Label20.BackColor = UpgradeHelpers.Helpers.Color.Navy;
			this.Label20.Enabled = false;
			this.Label20.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label20.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.Label20.Name = "Label20";
			this.Label20.TabIndex = 26;
			this.Label20.Text = "Type";
			this.Label19 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label19
			// 
			this.Label19.BackColor = UpgradeHelpers.Helpers.Color.Navy;
			this.Label19.Enabled = false;
			this.Label19.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label19.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.Label19.Name = "Label19";
			this.Label19.TabIndex = 25;
			this.Label19.Text = "   Unit";
			this.Label18 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label18
			// 
			this.Label18.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label18.Enabled = false;
			this.Label18.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label18.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.Label18.Name = "Label18";
			this.Label18.TabIndex = 24;
			this.Label18.Text = "Unit Reports";
			this.Label17 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label17
			// 
			this.Label17.BackColor = UpgradeHelpers.Helpers.Color.Navy;
			this.Label17.Enabled = false;
			this.Label17.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label17.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.Label17.Name = "Label17";
			this.Label17.TabIndex = 23;
			this.Label17.Text = "Unit";
			this.Label16 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label16
			// 
			this.Label16.BackColor = UpgradeHelpers.Helpers.Color.Navy;
			this.Label16.Enabled = false;
			this.Label16.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label16.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.Label16.Name = "Label16";
			this.Label16.TabIndex = 22;
			this.Label16.Text = "Type";
			this.Label15 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label15
			// 
			this.Label15.BackColor = UpgradeHelpers.Helpers.Color.Navy;
			this.Label15.Enabled = false;
			this.Label15.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label15.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.Label15.Name = "Label15";
			this.Label15.TabIndex = 21;
			this.Label15.Text = "Location";
			this.Label14 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label14
			// 
			this.Label14.BackColor = UpgradeHelpers.Helpers.Color.Navy;
			this.Label14.Enabled = false;
			this.Label14.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label14.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.Label14.Name = "Label14";
			this.Label14.TabIndex = 20;
			this.Label14.Text = "Time";
			this.Label12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label12
			// 
			this.Label12.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label12.Enabled = false;
			this.Label12.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 14.4F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label12.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.Label12.Name = "Label12";
			this.Label12.TabIndex = 19;
			this.Label12.Text = "Incident Listing Filters";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Enabled = false;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Impact", 24F, UpgradeHelpers.Helpers.FontStyle.Italic, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 7;
			this.Label1.Text = "Unit Response";
			this.Label9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label9
			// 
			this.Label9.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label9.Enabled = false;
			this.Label9.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Impact", 24F, UpgradeHelpers.Helpers.FontStyle.Italic, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label9.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.Label9.Name = "Label9";
			this.Label9.TabIndex = 16;
			this.Label9.Text = "Incident Reports";
			this.Label11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label11
			// 
			this.Label11.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label11.Enabled = false;
			this.Label11.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label11.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.Label11.Name = "Label11";
			this.Label11.TabIndex = 18;
			this.Label11.Text = "Limit List to this Incident Type";
			this.Shape3 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this.Shape3.Enabled = false;
			this.Shape3.Name = "Shape3";
			this.Shape3.TabIndex = 94;
			this.Label10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label10
			// 
			this.Label10.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label10.Enabled = false;
			this.Label10.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Impact", 24F, UpgradeHelpers.Helpers.FontStyle.Italic, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label10.ForeColor = UpgradeHelpers.Helpers.Color.Gray;
			this.Label10.Name = "Label10";
			this.Label10.TabIndex = 17;
			this.Label10.Text = "Incident Reports";
			this.Label8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label8
			// 
			this.Label8.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label8.Enabled = false;
			this.Label8.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label8.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.Label8.Name = "Label8";
			this.Label8.TabIndex = 15;
			this.Label8.Text = "Limit List to this Unit";
			this.Label6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label6
			// 
			this.Label6.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label6.Enabled = false;
			this.Label6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label6.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.Label6.Name = "Label6";
			this.Label6.TabIndex = 14;
			this.Label6.Text = "Reports for Incident#";
			this.lbIncidentMain = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbIncidentMain
			// 
			this.lbIncidentMain.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbIncidentMain.Enabled = false;
			this.lbIncidentMain.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, ((UpgradeHelpers
						.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbIncidentMain.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.lbIncidentMain.Name = "lbIncidentMain";
			this.lbIncidentMain.TabIndex = 13;
			this.lbIncidentMain.Text = "lbIncidentMain";
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label2.Enabled = false;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Impact", 24F, UpgradeHelpers.Helpers.FontStyle.Italic, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.Gray;
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 8;
			this.Label2.Text = "Unit Response";
			this.Shape1 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this.Shape1.Enabled = false;
			this.Shape1.Name = "Shape1";
			this.Shape1.TabIndex = 37;
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label3.Enabled = false;
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 6;
			this.Label3.Text = "Filter By Unit";
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label4.Enabled = false;
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 5;
			this.Label4.Text = "Filter By Primary Incident Type";
			this.Shape4 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this.Shape4.Enabled = false;
			this.Shape4.Name = "Shape4";
			this.Shape4.TabIndex = 93;
			this.MainTabs = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabControlViewModel>();
			this.MainTabs.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 18F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.MainTabs.Name = "MainTabs";
			this.MainTabs.SelectedIndex = 0;
			this.MainTabs.TabIndex = 0;
			this.sprUnitRpt_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprHIPAAMsg_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprOtherReport_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprCasualtyReport_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprRuptureReport_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprHazmat_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprFireReport_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprIncidentRpt_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprQuery_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprHIPAAReport_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprEMSReport_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprNotify_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprNotify_Sheet1.SheetName = "Sheet1";
			this.sprNotify_Sheet1.Cells.Get(0, 0).Value = "Notification List";
			this.sprNotify_Sheet1.Cells.Get(0, 1).Value = "Receivers";
			this.sprNotify_Sheet1.ColumnHeader.Rows.Get(0).Height = 0F;
			this.sprNotify_Sheet1.Columns.Get(0).StyleName = "Font675636234558841620951";
			this.sprNotify_Sheet1.Columns.Get(0).Width = 244F;
			this.sprNotify_Sheet1.Columns.Get(1).StyleName = "Font675636234558841620951";
			this.sprNotify_Sheet1.Columns.Get(1).Width = 268F;
			this.sprNotify_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprSysAdm_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprSysAdm_Sheet1.SheetName = "Sheet1";
			this.sprSysAdm_Sheet1.Cells.Get(0, 0).Value = "Incident #";
			this.sprSysAdm_Sheet1.Cells.Get(0, 1).Value = "Report Type";
			this.sprSysAdm_Sheet1.Cells.Get(0, 2).Value = "Report Status";
			this.sprSysAdm_Sheet1.Cells.Get(0, 3).Value = "Responsible Unit";
			this.sprSysAdm_Sheet1.Cells.Get(0, 4).Value = "Patient Name";
			this.sprSysAdm_Sheet1.ColumnHeader.Rows.Get(0).Height = 0F;
			this.sprSysAdm_Sheet1.Columns.Get(0).StyleName = "Font675636234557587169991";
			this.sprSysAdm_Sheet1.Columns.Get(0).Width = 92F;
			this.sprSysAdm_Sheet1.Columns.Get(1).StyleName = "Font675636234557587169991";
			this.sprSysAdm_Sheet1.Columns.Get(1).Width = 138F;
			this.sprSysAdm_Sheet1.Columns.Get(2).StyleName = "Font675636234557587169991";
			this.sprSysAdm_Sheet1.Columns.Get(2).Width = 136F;
			this.sprSysAdm_Sheet1.Columns.Get(3).StyleName = "Font675636234557587169991";
			this.sprSysAdm_Sheet1.Columns.Get(3).Width = 117F;
			this.sprSysAdm_Sheet1.Columns.Get(4).StyleName = "Font675636234557587169991";
			this.sprSysAdm_Sheet1.Columns.Get(4).Width = 269F;
			this.sprSysAdm_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprNoteLog_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprNoteLog_Sheet1.SheetName = "Sheet1";
			this.sprNoteLog_Sheet1.Cells.Get(0, 0).Value = "Tacoma Fire Department";
			this.sprNoteLog_Sheet1.Cells.Get(1, 0).Value = "IRS Notification Message Log";
			this.sprNoteLog_Sheet1.Cells.Get(3, 1).Value = "Date Created";
			this.sprNoteLog_Sheet1.Cells.Get(3, 2).Value = "Date Received";
			this.sprNoteLog_Sheet1.Cells.Get(3, 3).Value = "Notification Message";
			this.sprNoteLog_Sheet1.Cells.Get(3, 4).Value = "Mess ID";
			this.sprNoteLog_Sheet1.ColumnHeader.Rows.Get(0).Height = 0F;
			this.sprNoteLog_Sheet1.Columns.Get(0).StyleName = "Font651636234559567687761";
			this.sprNoteLog_Sheet1.Columns.Get(0).Width = 49F;
			this.sprNoteLog_Sheet1.Columns.Get(1).StyleName = "Font651636234559567687761";
			this.sprNoteLog_Sheet1.Columns.Get(1).Width = 102F;
			this.sprNoteLog_Sheet1.Columns.Get(2).StyleName = "Font651636234559567687761";
			this.sprNoteLog_Sheet1.Columns.Get(2).Width = 91F;
			this.sprNoteLog_Sheet1.Columns.Get(3).StyleName = "Font651636234559567687761";
			this.sprNoteLog_Sheet1.Columns.Get(3).Width = 364F;
			this.sprNoteLog_Sheet1.Columns.Get(4).StyleName = "Font651636234559567687761";
			this.sprNoteLog_Sheet1.Columns.Get(4).Width = 65F;
			this.sprNoteLog_Sheet1.RowHeader.Columns.Get(0).Width = 0F;


			this.sprUnitReports_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprUnitReports_Sheet1.SheetName = "Sheet1";
			this.sprUnitReports_Sheet1.ColumnHeader.Rows.Get(0).Height = 0F;
			this.sprUnitReports_Sheet1.Columns.Get(0).StyleName = "Color653636234556848555156";
			this.sprUnitReports_Sheet1.Columns.Get(0).Width = 0F;
            this.sprUnitReports_Sheet1.Columns.Get(1).StyleName = "Color653636234556848555156";
            this.sprUnitReports_Sheet1.Columns.Get(1).Width = 100F;
            this.sprUnitReports_Sheet1.Columns.Get(2).StyleName = "Font737636234556848564921";
			this.sprUnitReports_Sheet1.Columns.Get(2).Visible = false;
			this.sprUnitReports_Sheet1.Columns.Get(2).Width = 0F;
			this.sprUnitReports_Sheet1.RowHeader.Columns.Get(0).Width = 0F;


			this.sprIncReports_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprIncReports_Sheet1.SheetName = "Sheet1";
			this.sprIncReports_Sheet1.ColumnHeader.Rows.Get(0).Height = 0F;
			this.sprIncReports_Sheet1.Columns.Get(0).StyleName = "Color653636234556766333856";
			this.sprIncReports_Sheet1.Columns.Get(0).Width = 0F;
            this.sprIncReports_Sheet1.Columns.Get(1).StyleName = "Color653636234556766333856";
            this.sprIncReports_Sheet1.Columns.Get(1).Width = 359F;
            this.sprIncReports_Sheet1.Columns.Get(2).StyleName = "Font737636234556766343621";
			this.sprIncReports_Sheet1.Columns.Get(2).Visible = false;
			this.sprIncReports_Sheet1.Columns.Get(2).Width = 0F;
			this.sprIncReports_Sheet1.RowHeader.Columns.Get(0).Width = 0F;

			this.sprIncident_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprIncident_Sheet1.SheetName = "Sheet1";
            this.sprIncident_Sheet1.ColumnHeader.Rows.Get(0).Height = 0F;
            //this.sprIncident_Sheet1.ColumnHeader.Cells.Get(2).Value = "Incident";
            this.sprIncident_Sheet1.Columns.Get(0).StyleName = "Color651636234556647464511";
			this.sprIncident_Sheet1.Columns.Get(0).Width = 0F;
			this.sprIncident_Sheet1.Columns.Get(1).StyleName = "Font735636234556647484041";
			this.sprIncident_Sheet1.Columns.Get(1).Width = 20F;
			this.sprIncident_Sheet1.Columns.Get(2).StyleName = "Font735636234556647484041";
			this.sprIncident_Sheet1.Columns.Get(2).Width = 90F;
			this.sprIncident_Sheet1.Columns.Get(3).StyleName = "Font735636234556647484041";
			this.sprIncident_Sheet1.Columns.Get(3).Width = 45F;
			this.sprIncident_Sheet1.Columns.Get(4).StyleName = "Font735636234556647484041";
			this.sprIncident_Sheet1.Columns.Get(4).Width = 225F;
			this.sprIncident_Sheet1.Columns.Get(5).StyleName = "Font735636234556647484041";
			this.sprIncident_Sheet1.Columns.Get(5).Width = 100F;
            this.sprIncident_Sheet1.Columns.Get(6).StyleName = "Font735636234556647484041";
            this.sprIncident_Sheet1.Columns.Get(6).Width = 90F;
            this.sprIncident_Sheet1.Columns.Get(7).StyleName = "Font735636234556647484041";
			this.sprIncident_Sheet1.Columns.Get(7).Visible = false;
			this.sprIncident_Sheet1.Columns.Get(7).Width = 0F;
			this.sprIncident_Sheet1.RowHeader.Columns.Get(0).Width = 0F;


			this.sprUnitList_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprUnitList_Sheet1.SheetName = "Sheet1";
			this.sprUnitList_Sheet1.ColumnHeader.Rows.Get(0).Height = 0F;
			this.sprUnitList_Sheet1.Columns.Get(0).StyleName = "Font660636234556471528506";
			this.sprUnitList_Sheet1.Columns.Get(0).Width = 0F;
			this.sprUnitList_Sheet1.Columns.Get(1).StyleName = "Font660636234556471528506";
			this.sprUnitList_Sheet1.Columns.Get(1).Width = 15F;
			this.sprUnitList_Sheet1.Columns.Get(2).StyleName = "Font660636234556471528506";
			this.sprUnitList_Sheet1.Columns.Get(2).Width = 70F;
			this.sprUnitList_Sheet1.Columns.Get(3).StyleName = "Font660636234556471528506";
			this.sprUnitList_Sheet1.Columns.Get(3).Width = 100F;
			this.sprUnitList_Sheet1.Columns.Get(4).StyleName = "Font660636234556471528506";
			this.sprUnitList_Sheet1.Columns.Get(4).Width = 70F;
			this.sprUnitList_Sheet1.Columns.Get(5).StyleName = "Font660636234556471528506";
			this.sprUnitList_Sheet1.Columns.Get(5).Width = 250F;
            this.sprUnitList_Sheet1.Columns.Get(6).StyleName = "Font660636234556471528506";
            this.sprUnitList_Sheet1.Columns.Get(6).Width = 150F;
            this.sprUnitList_Sheet1.Columns.Get(7).StyleName = "Font660636234556471528506";
			this.sprUnitList_Sheet1.Columns.Get(7).Visible = false;
			this.sprUnitList_Sheet1.Columns.Get(7).Width = 0F;
			this.sprUnitList_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.cmdExitApp = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdExitApp
			// 
			this.cmdExitApp.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdExitApp.Enabled = true;
			this.cmdExitApp.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdExitApp.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdExitApp.Name = "cmdExitApp";
			this.cmdExitApp.TabIndex = 30;
			this.cmdExitApp.Text = "E&xit";
			this.cmdRefreshUnit = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdRefreshUnit
			// 
			this.cmdRefreshUnit.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdRefreshUnit.Enabled = true;
			this.cmdRefreshUnit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdRefreshUnit.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdRefreshUnit.Name = "cmdRefreshUnit";
			this.cmdRefreshUnit.TabIndex = 36;
			this.cmdRefreshUnit.Text = "&Refresh";
			this.cmdClearUnit = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClearUnit
			// 
			this.cmdClearUnit.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClearUnit.Enabled = true;
			this.cmdClearUnit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClearUnit.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClearUnit.Name = "cmdClearUnit";
			this.cmdClearUnit.TabIndex = 1;
			this.cmdClearUnit.Text = "Clear All Filters";
			this.calUnit = ctx.Resolve<UpgradeHelpers.BasicViewModels.MonthCalendarViewModel>();
			this.calUnit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.calUnit.Name = "calUnit";
			this.calUnit.TabIndex = 4;
			this.cmdSysButt3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this.cmdSysButt3.Name = "cmdSysButt3";
			this.cmdSysButt3.TabIndex = 99;
			//this.cmdRefreshIncident = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdRefreshIncident
			// 
			//this.cmdRefreshIncident.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			//this.cmdRefreshIncident.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 13.8F, UpgradeHelpers.Helpers
			//.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			//this.cmdRefreshIncident.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			//this.cmdRefreshIncident.Name = "cmdRefreshIncident";
			//this.cmdRefreshIncident.TabIndex = 37;
			//this.cmdRefreshIncident.Text = "&Refresh";
			this.cmdExit2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdExit2
			// 
			this.cmdExit2.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdExit2.Enabled = true;
			this.cmdExit2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdExit2.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdExit2.Name = "cmdExit2";
			this.cmdExit2.TabIndex = 40;
			this.cmdExit2.Text = "E&xit";
			this.cmdRefreshIncList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdRefreshIncList
			// 
			this.cmdRefreshIncList.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdRefreshIncList.Enabled = true;
			this.cmdRefreshIncList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdRefreshIncList.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdRefreshIncList.Name = "cmdRefreshIncList";
			this.cmdRefreshIncList.TabIndex = 39;
			this.cmdRefreshIncList.Text = "&Refresh";
			this.cmdClearIncident = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClearIncident
			// 
			this.cmdClearIncident.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClearIncident.Enabled = true;
			this.cmdClearIncident.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClearIncident.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClearIncident.Name = "cmdClearIncident";
			this.cmdClearIncident.TabIndex = 11;
			this.cmdClearIncident.Text = "Clear All Filters";
			this.calIncident = ctx.Resolve<UpgradeHelpers.BasicViewModels.MonthCalendarViewModel>();
			this.calIncident.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.calIncident.Name = "calIncident";
			this.calIncident.TabIndex = 12;
			this.cmdViewReport = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this.cmdViewReport.Name = "cmdViewReport";
			this.cmdViewReport.TabIndex = 96;
			this.cmdView = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this.cmdView.Name = "cmdView";
			this.cmdView.TabIndex = 97;
			this.cmdClearSelections = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this.cmdClearSelections.Name = "cmdClearSelections";
			this.cmdClearSelections.TabIndex = 98;
			this.cmdSysButt1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this.cmdSysButt1.Name = "cmdSysButt1";
			this.cmdSysButt1.TabIndex = 100;
			this.cmdSysButt2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this.cmdSysButt2.Name = "cmdSysButt2";
			this.cmdSysButt2.TabIndex = 101;
			this.tvHelpList = ctx.Resolve<UpgradeHelpers.BasicViewModels.TreeViewViewModel>();
			// 
			// tvHelpList
			// 
			this.tvHelpList.LabelEdit = true;
			this.tvHelpList.Name = "tvHelpList";
			this.tvHelpList.TabIndex = 103;
			this.tabPage1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Text = "Unit Response";
			this.tabPage2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Text = "Report Editing";
			this.tabPage3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Text = "Field Reports";
			this.tabPage4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Text = "Admin Inquiry";
			this.tabPage5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Text = "System Admin";
			//this.Text = "Form1";
			this.CurrentHelpID = 0;
			this.mNode = null;
			this.frmAdmHelp = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmAdmHelp
			// 
			this.frmAdmHelp.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(108)))), ((int)(((byte)(74)))));
			this.frmAdmHelp.Enabled = false;
			this.frmAdmHelp.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmAdmHelp.Name = "frmAdmHelp";
			this.frmAdmHelp.TabIndex = 102;
			this.frmAdmHelp.Visible = false;
			this.calInquiry1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.MonthCalendarViewModel>();
			this.calInquiry1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.calInquiry1.Name = "calInquiry1";
			this.calInquiry1.TabIndex = 53;
			this.calInquiry1.Visible = false;
			this.calInquiry2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.MonthCalendarViewModel>();
			this.calInquiry2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.calInquiry2.Name = "calInquiry2";
			this.calInquiry2.TabIndex = 54;
			this.calInquiry2.Visible = false;
			txtFilter = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel>>(6);
			txtFilter[0] = _txtFilter_0;
			txtFilter[1] = _txtFilter_1;
			txtFilter[2] = _txtFilter_2;
			txtFilter[3] = _txtFilter_3;
			txtFilter[4] = _txtFilter_4;
			txtFilter[5] = _txtFilter_5;
			txtFilter[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtFilter[0].Enabled = false;
			txtFilter[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtFilter[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			txtFilter[0].Name = "_txtFilter_0";
			txtFilter[0].TabIndex = 52;
			txtFilter[0].Text = "txtFilter(0)";
			txtFilter[0].Visible = false;
			txtFilter[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtFilter[1].Enabled = false;
			txtFilter[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtFilter[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			txtFilter[1].Name = "_txtFilter_1";
			txtFilter[1].TabIndex = 51;
			txtFilter[1].Text = "txtFilter(1)";
			txtFilter[1].Visible = false;
			txtFilter[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtFilter[2].Enabled = false;
			txtFilter[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtFilter[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			txtFilter[2].Name = "_txtFilter_2";
			txtFilter[2].TabIndex = 50;
			txtFilter[2].Text = "txtFilter(2)";
			txtFilter[2].Visible = false;
			txtFilter[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtFilter[3].Enabled = false;
			txtFilter[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtFilter[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			txtFilter[3].Name = "_txtFilter_3";
			txtFilter[3].TabIndex = 49;
			txtFilter[3].Text = "txtFilter(3)";
			txtFilter[3].Visible = false;
			txtFilter[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtFilter[4].Enabled = false;
			txtFilter[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtFilter[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			txtFilter[4].Name = "_txtFilter_4";
			txtFilter[4].TabIndex = 48;
			txtFilter[4].Text = "txtFilter(4)";
			txtFilter[4].Visible = false;
			txtFilter[5].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtFilter[5].Enabled = false;
			txtFilter[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtFilter[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			txtFilter[5].Name = "_txtFilter_5";
			txtFilter[5].TabIndex = 47;
			txtFilter[5].Text = "txtFilter(5)";
			txtFilter[5].Visible = false;
			cboFilter = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>>(6);
			cboFilter[0] = _cboFilter_0;
			cboFilter[1] = _cboFilter_1;
			cboFilter[2] = _cboFilter_2;
			cboFilter[3] = _cboFilter_3;
			cboFilter[4] = _cboFilter_4;
			cboFilter[5] = _cboFilter_5;
			cboFilter[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboFilter[0].Enabled = false;
			cboFilter[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboFilter[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboFilter[0].Name = "_cboFilter_0";
			cboFilter[0].TabIndex = 68;
			cboFilter[0].Text = "cboFilter(0)";
			cboFilter[0].Visible = false;
			cboFilter[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboFilter[1].Enabled = false;
			cboFilter[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboFilter[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboFilter[1].Name = "_cboFilter_1";
			cboFilter[1].TabIndex = 67;
			cboFilter[1].Text = "cboFilter(1)";
			cboFilter[1].Visible = false;
			cboFilter[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboFilter[2].Enabled = false;
			cboFilter[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboFilter[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboFilter[2].Name = "_cboFilter_2";
			cboFilter[2].TabIndex = 66;
			cboFilter[2].Text = "cboFilter(2)";
			cboFilter[2].Visible = false;
			cboFilter[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboFilter[3].Enabled = false;
			cboFilter[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboFilter[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboFilter[3].Name = "_cboFilter_3";
			cboFilter[3].TabIndex = 65;
			cboFilter[3].Text = "cboFilter(3)";
			cboFilter[3].Visible = false;
			cboFilter[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboFilter[4].Enabled = false;
			cboFilter[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboFilter[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboFilter[4].Name = "_cboFilter_4";
			cboFilter[4].TabIndex = 64;
			cboFilter[4].Text = "cboFilter(4)";
			cboFilter[4].Visible = false;
			cboFilter[5].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboFilter[5].Enabled = false;
			cboFilter[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboFilter[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboFilter[5].Name = "_cboFilter_5";
			cboFilter[5].TabIndex = 63;
			cboFilter[5].Text = "cboFilter(5)";
			cboFilter[5].Visible = false;
			lbFilter = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(6);
			lbFilter[0] = _lbFilter_0;
			lbFilter[1] = _lbFilter_1;
			lbFilter[2] = _lbFilter_2;
			lbFilter[3] = _lbFilter_3;
			lbFilter[4] = _lbFilter_4;
			lbFilter[5] = _lbFilter_5;
			lbFilter[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFilter[0].Enabled = false;
			lbFilter[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbFilter[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(240)))), ((int)(((byte)(177)))));
			lbFilter[0].Name = "_lbFilter_0";
			lbFilter[0].TabIndex = 60;
			lbFilter[0].Text = "Filter Label (0)";
			lbFilter[0].Visible = false;
			lbFilter[5].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFilter[5].Enabled = false;
			lbFilter[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbFilter[5].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(240)))), ((int)(((byte)(177)))));
			lbFilter[5].Name = "_lbFilter_5";
			lbFilter[5].TabIndex = 55;
			lbFilter[5].Text = "Filter Label (5)";
			lbFilter[5].Visible = false;
			lbFilter[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFilter[4].Enabled = false;
			lbFilter[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbFilter[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(240)))), ((int)(((byte)(177)))));
			lbFilter[4].Name = "_lbFilter_4";
			lbFilter[4].TabIndex = 56;
			lbFilter[4].Text = "Filter Label (4)";
			lbFilter[4].Visible = false;
			lbFilter[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFilter[3].Enabled = false;
			lbFilter[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbFilter[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(240)))), ((int)(((byte)(177)))));
			lbFilter[3].Name = "_lbFilter_3";
			lbFilter[3].TabIndex = 57;
			lbFilter[3].Text = "Filter Label (3)";
			lbFilter[3].Visible = false;
			lbFilter[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFilter[2].Enabled = false;
			lbFilter[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbFilter[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(240)))), ((int)(((byte)(177)))));
			lbFilter[2].Name = "_lbFilter_2";
			lbFilter[2].TabIndex = 58;
			lbFilter[2].Text = "Filter Label (2)";
			lbFilter[2].Visible = false;
			lbFilter[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFilter[1].Enabled = false;
			lbFilter[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbFilter[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(240)))), ((int)(((byte)(177)))));
			lbFilter[1].Name = "_lbFilter_1";
			lbFilter[1].TabIndex = 59;
			lbFilter[1].Text = "Filter Label (1)";
			lbFilter[1].Visible = false;
			optBattalion = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(3);
			optBattalion[2] = _optBattalion_2;
			optBattalion[1] = _optBattalion_1;
			optBattalion[0] = _optBattalion_0;
			optBattalion[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(188)))), ((int)(((byte)(192)))));
			optBattalion[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optBattalion[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optBattalion[2].Name = "_optBattalion_2";
			optBattalion[2].TabIndex = 106;
			optBattalion[2].Text = "BC3";
			optBattalion[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(188)))), ((int)(((byte)(192)))));
			optBattalion[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optBattalion[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optBattalion[1].Name = "_optBattalion_1";
			optBattalion[1].TabIndex = 35;
			optBattalion[1].Text = "BC2";
			optBattalion[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(188)))), ((int)(((byte)(192)))));
			optBattalion[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optBattalion[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optBattalion[0].Name = "_optBattalion_0";
			optBattalion[0].TabIndex = 34;
			optBattalion[0].Text = "BC1";
			this.CurrIncident = 0;
			this.SummaryReportFlag = 0;
			this.DontRespond = 0;
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234556471323441", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text349636234556471508976", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font660636234556471528506");
			namedStyle3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1232636234556472006991");
			namedStyle4.CellType = textCellType2;
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.Renderer = textCellType2;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234556647444981", "DataAreaDefault");
			namedStyle5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.Parent = "DataAreaDefault";
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text349636234556647454746", "DataAreaDefault");
			namedStyle6.CellType = textCellType3;
			namedStyle6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.Parent = "DataAreaDefault";
			namedStyle6.Renderer = textCellType3;
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle7 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color651636234556647464511");
			namedStyle7.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle7.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle7.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle7.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle7.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle8 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font735636234556647484041");
			namedStyle8.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle8.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle8.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle8.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle9 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234556766294796", "DataAreaDefault");
			namedStyle9.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle9.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle9.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle9.Parent = "DataAreaDefault";
			namedStyle9.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle10 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text351636234556766324091", "DataAreaDefault");
			namedStyle10.CellType = textCellType4;
			namedStyle10.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle10.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle10.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle10.Parent = "DataAreaDefault";
			namedStyle10.Renderer = textCellType4;
			namedStyle10.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle11 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color653636234556766333856");
			namedStyle11.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle11.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle11.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle11.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle11.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle11.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle12 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font737636234556766343621");
			namedStyle12.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle12.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle12.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle12.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle13 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234559567658466", "DataAreaDefault");
			namedStyle13.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle13.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle13.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle13.Parent = "DataAreaDefault";
			namedStyle13.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle14 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text355636234559567687761", "DataAreaDefault");
			namedStyle14.CellType = textCellType5;
			namedStyle14.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle14.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle14.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle14.Parent = "DataAreaDefault";
			namedStyle14.Renderer = textCellType5;
			namedStyle14.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle15 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font651636234559567687761");
			namedStyle15.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9F);
			namedStyle15.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle15.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle15.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle16 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1256636234559567785411");
			namedStyle16.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle16.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle16.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle17 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1294636234559567795176");
			namedStyle17.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle17.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle17.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle18 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1443636234559567844001");
			namedStyle18.CellType = textCellType6;
			namedStyle18.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle18.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle18.Renderer = textCellType6;
			namedStyle18.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle19 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1516636234559567902591");
			namedStyle19.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle19.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle19.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle20 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234557587130931", "DataAreaDefault");
			namedStyle20.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle20.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle20.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle20.Parent = "DataAreaDefault";
			namedStyle20.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle21 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text379636234557587150461", "DataAreaDefault");
			namedStyle21.CellType = textCellType7;
			namedStyle21.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle21.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle21.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle21.Parent = "DataAreaDefault";
			namedStyle21.Renderer = textCellType7;
			namedStyle21.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle22 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font675636234557587169991");
			namedStyle22.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9F);
			namedStyle22.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle22.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle22.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle23 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font1091636234557587209051");
			namedStyle23.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle23.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle23.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle23.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle24 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1109636234557587218816");
			namedStyle24.CellType = textCellType8;
			namedStyle24.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle24.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle24.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle24.Renderer = textCellType8;
			namedStyle24.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle25 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1449636234557587335996");
			namedStyle25.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle25.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle25.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle26 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234558841591656", "DataAreaDefault");
			namedStyle26.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle26.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle26.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle26.Parent = "DataAreaDefault";
			namedStyle26.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle27 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text379636234558841611186", "DataAreaDefault");
			namedStyle27.CellType = textCellType9;
			namedStyle27.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle27.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle27.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle27.Parent = "DataAreaDefault";
			namedStyle27.Renderer = textCellType9;
			namedStyle27.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle28 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font675636234558841620951");
			namedStyle28.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9F);
			namedStyle28.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle28.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle28.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle29 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font887636234558841640481");
			namedStyle29.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle29.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle29.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle29.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle30 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static905636234558841650246");
			namedStyle30.CellType = textCellType10;
			namedStyle30.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle30.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle30.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle30.Renderer = textCellType10;
			namedStyle30.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle31 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1062636234558841718601");
			namedStyle31.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle31.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle31.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;

			this.Name = "TFDIncident.frmMain";
			IsMdiChild = true;
			cboReportList.Items.Add("NFPA Survey");
			cboStatus.Items.Add("Incomplete");
			cboStatus.Items.Add("Saved Incomplete");
			cboStatus.Items.Add("Complete");
            cboStatus.SetItemData(0, 1);
            cboStatus.SetItemData(1, 2);
            cboStatus.SetItemData(2, 3);
            MainTabs.Items.Add(tabPage1);
			MainTabs.Items.Add(tabPage2);
			MainTabs.Items.Add(tabPage3);
			MainTabs.Items.Add(tabPage4);
			MainTabs.Items.Add(tabPage5);
			sprUnitList.Sheets.Add(this.sprUnitList_Sheet1);
			sprIncident.Sheets.Add(this.sprIncident_Sheet1);
			sprIncReports.Sheets.Add(this.sprIncReports_Sheet1);
			sprUnitReports.Sheets.Add(this.sprUnitReports_Sheet1);
			sprNoteLog.Sheets.Add(this.sprNoteLog_Sheet1);
			sprSysAdm.Sheets.Add(this.sprSysAdm_Sheet1);
			sprNotify.Sheets.Add(this.sprNotify_Sheet1);
		}

		public virtual UpgradeHelpers.BasicViewModels.MonthCalendarViewModel calFRStart { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MonthCalendarViewModel calFREnd { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboFieldReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboSelection1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboSelection2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtHelpTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtHelpText { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboReportList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboSysAdm2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboSysAdm1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtSysAdm1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboSystemAction { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboFilter_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboFilter_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboFilter_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboFilter_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboFilter_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboFilter_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtFilter_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtFilter_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtFilter_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtFilter_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtFilter_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtFilter_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboInquiryList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstFields { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstFilters { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optBattalion_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optBattalion_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optBattalion_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboStatus { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboIncType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboIncUnit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboUnit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboType { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprUnitList { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprIncident { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprIncReports { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprUnitReports { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprNoteLog { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprSysAdm { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprNotify { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label29 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Line1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSysAdmin3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSysAdmin2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSysAdmin1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label28 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSelection1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSelection2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label27 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label26 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label25 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbCal1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbCal2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFilter_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFilter_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFilter_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFilter_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFilter_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFilter_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSelectInquiry { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbViewFields { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbFilterFields { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label24 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label23 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label22 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label21 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label20 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label19 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label18 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label17 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label16 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label15 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label14 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label11 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel Shape3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbIncidentMain { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel Shape1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel Shape4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabControlViewModel MainTabs { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprUnitRpt_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprHIPAAMsg_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprOtherReport_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprCasualtyReport_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprRuptureReport_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprHazmat_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprFireReport_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprIncidentRpt_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprQuery_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprHIPAAReport_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprEMSReport_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprNotify_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprSysAdm_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprNoteLog_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprUnitReports_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprIncReports_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprIncident_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprUnitList_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdExitApp { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdRefreshUnit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClearUnit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MonthCalendarViewModel calUnit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdSysButt3 { get; set; }

		//public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdRefreshIncident { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdExit2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdRefreshIncList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClearIncident { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MonthCalendarViewModel calIncident { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdViewReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdView { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClearSelections { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdSysButt1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdSysButt2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TreeViewViewModel tvHelpList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage5 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean isInitializingComponent { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrentHelpID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual UpgradeHelpers.BasicViewModels.TreeNodeViewModel mNode { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmAdmHelp { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MonthCalendarViewModel calInquiry1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MonthCalendarViewModel calInquiry2 { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel> txtFilter { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel> cboFilter { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbFilter { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optBattalion { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrIncident { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 SummaryReportFlag { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 DontRespond { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}