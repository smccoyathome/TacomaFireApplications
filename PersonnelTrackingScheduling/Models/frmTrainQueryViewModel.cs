using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmTrainQuery))]
	public class frmTrainQueryViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.sprReport = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprReport.MaxRows = 500000;
			this.sprReport.TabIndex = 26;
			this.sprReport.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.lstSpecific = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			this.lstSpecific.Name = "lstSpecific";
			this.lstSpecific.TabIndex = 17;
			this.optPM = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optPM
			// 
			this.optPM.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.optPM.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optPM.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.optPM.Name = "optPM";
			this.optPM.TabIndex = 38;
			this.optPM.Text = "PM Only";
			this.opt183 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// opt183
			// 
			this.opt183.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.opt183.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.opt183.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.opt183.Name = "opt183";
			this.opt183.TabIndex = 39;
			this.opt183.Text = "Batt 3";
			this.opt181 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// opt181
			// 
			this.opt181.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.opt181.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.opt181.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.opt181.Name = "opt181";
			this.opt181.TabIndex = 10;
			this.opt181.Text = "Batt 1";
			this.opt182 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// opt182
			// 
			this.opt182.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.opt182.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.opt182.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.opt182.Name = "opt182";
			this.opt182.TabIndex = 11;
			this.opt182.Text = "Batt 2";
			this.optAll = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optAll
			// 
			this.optAll.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.optAll.Checked = true;
			this.optAll.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optAll.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.optAll.Name = "optAll";
			this.optAll.TabIndex = 9;
			this.optAll.Text = "ALL";
			this.optA = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optA
			// 
			this.optA.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.optA.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optA.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.optA.Name = "optA";
			this.optA.TabIndex = 12;
			this.optA.Text = "Shift A";
			this.optB = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optB
			// 
			this.optB.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.optB.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optB.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.optB.Name = "optB";
			this.optB.TabIndex = 13;
			this.optB.Text = "Shift B";
			this.optC = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optC
			// 
			this.optC.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.optC.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optC.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.optC.Name = "optC";
			this.optC.TabIndex = 14;
			this.optC.Text = "Shift C";
			this.optD = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optD
			// 
			this.optD.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.optD.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optD.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.optD.Name = "optD";
			this.optD.TabIndex = 15;
			this.optD.Text = "Shift D";
			this.txtCommentSearch = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtCommentSearch.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtCommentSearch.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtCommentSearch.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtCommentSearch.Name = "txtCommentSearch";
			this.txtCommentSearch.TabIndex = 32;
			this.txtCommentSearch.Text = "txtCommentSearch";
			this.OptNo = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// OptNo
			// 
			this.OptNo.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.OptNo.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.OptNo.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.OptNo.Name = "OptNo";
			this.OptNo.TabIndex = 6;
			this.OptNo.Text = "No";
			this.OptYes = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// OptYes
			// 
			this.OptYes.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.OptYes.Checked = true;
			this.OptYes.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.OptYes.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.OptYes.Name = "OptYes";
			this.OptYes.TabIndex = 5;
			this.OptYes.Text = "Yes";
			this.txtNameSearch = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtNameSearch.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtNameSearch.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtNameSearch.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtNameSearch.Name = "txtNameSearch";
			this.txtNameSearch.TabIndex = 4;
			this.txtNameSearch.Text = "txtNameSearch";
			this._lbSubTitle_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbSubTitle_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbSubTitle_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.dtStart = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dtStart.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.dtStart.MinDate = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
			this.dtStart.Name = "dtStart";
			this.dtStart.TabIndex = 7;
			this.dtEnd = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dtEnd.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.dtEnd.MinDate = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
			this.dtEnd.Name = "dtEnd";
			this.dtEnd.TabIndex = 8;
			this.lbCount = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbCount
			// 
			this.lbCount.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbCount.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbCount.ForeColor = UpgradeHelpers.Helpers.Color.Lime;
			this.lbCount.Name = "lbCount";
			this.lbCount.TabIndex = 27;
			this.lbCount.Text = "Total Count:  ";
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 25;
			this.Label4.Text = "Thru:";
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 24;
			this.Label3.Text = "From:";
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 23;
			this.Label2.Text = "Select Date Range";
			this._lbSubTitle_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbSubTitle_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbSubTitle_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 31;
			this.Label1.Text = "WARNING!  It might take minutes to retrieve the data, depending on the criteria y" + "ou choose!!";
			this.sprReport_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprReport_Sheet1.SheetName = "Sheet1";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 0].Value = "Name";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 1].Value = "Shift";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 2].Value = "Unit";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 3].Value = "Batt";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 4].Value = "Primary";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 5].Value = "Secondary";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 6].Value = "Specific";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 7].Value = "Date";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 8].Value = "Hrs";
			this.sprReport_Sheet1.Columns.Get(0).Label = "Name";
			this.sprReport_Sheet1.Columns.Get(0).Width = 102F;
			this.sprReport_Sheet1.Columns.Get(1).Label = "Shift";
			this.sprReport_Sheet1.Columns.Get(1).Width = 30F;
			this.sprReport_Sheet1.Columns.Get(2).Label = "Unit";
			this.sprReport_Sheet1.Columns.Get(2).Width = 38F;
			this.sprReport_Sheet1.Columns.Get(3).Label = "Batt";
			this.sprReport_Sheet1.Columns.Get(3).Width = 25F;
			this.sprReport_Sheet1.Columns.Get(4).Label = "Primary";
			this.sprReport_Sheet1.Columns.Get(4).Width = 118F;
			this.sprReport_Sheet1.Columns.Get(5).Label = "Secondary";
			this.sprReport_Sheet1.Columns.Get(5).Width = 123F;
			this.sprReport_Sheet1.Columns.Get(6).Label = "Specific";
			this.sprReport_Sheet1.Columns.Get(6).Width = 135F;
			this.sprReport_Sheet1.Columns.Get(7).Label = "Date";
			this.sprReport_Sheet1.Columns.Get(7).Width = 51F;
			this.sprReport_Sheet1.Columns.Get(8).Label = "Hrs";
			this.sprReport_Sheet1.Columns.Get(8).Width = 28F;
			this.sprReport_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprReport_Sheet1.Rows.Get(0).Height = 14F;
			this.cboPrimary = ctx.Resolve<UpgradeHelpers.DoubleJumpSupport.ComboBoxHelper>();
			this.cboPrimary.Clicked = false;
			this.cboPrimary.ListIndex = -1;
			this.cboPrimary.Name = "cboPrimary";
			this.cboPrimary.TabIndex = 16;
			this.cboSecondary = ctx.Resolve<UpgradeHelpers.DoubleJumpSupport.ComboBoxHelper>();
			this.cboSecondary.Clicked = false;
			this.cboSecondary.ListIndex = -1;
			this.cboSecondary.Name = "cboSecondary";
			this.cboSecondary.TabIndex = 1;
			this.cmdClear = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClear
			// 
			this.cmdClear.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClear.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClear.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClear.Name = "cmdClear";
			this.cmdClear.TabIndex = 37;
			this.cmdClear.Text = "Clear Filters";
			this.cmdPrint = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrint.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrint.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.TabIndex = 36;
			this.cmdPrint.Text = "Print List";
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 35;
			this.cmdClose.Text = "Exit";
			this.cmdQuery = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdQuery
			// 
			this.cmdQuery.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdQuery.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdQuery.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdQuery.Name = "cmdQuery";
			this.cmdQuery.TabIndex = 34;
			this.cmdQuery.Text = "Query";
			this.cboUnit = ctx.Resolve<UpgradeHelpers.DoubleJumpSupport.ComboBoxHelper>();
			this.cboUnit.Clicked = false;
			this.cboUnit.ListIndex = -1;
			this.cboUnit.Name = "cboUnit";
			this.cboUnit.TabIndex = 3;
			this.Text = "Training Query";
			this.FirstTime = false;
			this.SkipLogic = false;
			this.sHeadingFilter = "";
			this.CurrBatt = "";
			this.CurrShift = "";
			lbSubTitle = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(6);
			lbSubTitle[5] = _lbSubTitle_5;
			lbSubTitle[2] = _lbSubTitle_2;
			lbSubTitle[4] = _lbSubTitle_4;
			lbSubTitle[3] = _lbSubTitle_3;
			lbSubTitle[1] = _lbSubTitle_1;
			lbSubTitle[0] = _lbSubTitle_0;
			lbSubTitle[5].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbSubTitle[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbSubTitle[5].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			lbSubTitle[5].Name = "_lbSubTitle_5";
			lbSubTitle[5].TabIndex = 33;
			lbSubTitle[5].Text = "By Comments:";
			lbSubTitle[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbSubTitle[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbSubTitle[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			lbSubTitle[2].Name = "_lbSubTitle_2";
			lbSubTitle[2].TabIndex = 29;
			lbSubTitle[2].Text = "Filter by Name:";
			lbSubTitle[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbSubTitle[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbSubTitle[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			lbSubTitle[4].Name = "_lbSubTitle_4";
			lbSubTitle[4].TabIndex = 28;
			lbSubTitle[4].Text = "Unit";
			lbSubTitle[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbSubTitle[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbSubTitle[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			lbSubTitle[3].Name = "_lbSubTitle_3";
			lbSubTitle[3].TabIndex = 22;
			lbSubTitle[3].Text = "Specific Training ";
			lbSubTitle[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbSubTitle[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbSubTitle[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			lbSubTitle[1].Name = "_lbSubTitle_1";
			lbSubTitle[1].TabIndex = 21;
			lbSubTitle[1].Text = "Secondary Training Type";
			lbSubTitle[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbSubTitle[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbSubTitle[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			lbSubTitle[0].Name = "_lbSubTitle_0";
			lbSubTitle[0].TabIndex = 20;
			lbSubTitle[0].Text = "Primary Training Type";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234781099438146", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text291636234781099594386", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			this.Name = "PTSProject.frmTrainQuery";
			IsMdiChild = true;
			this.sprReport.NamedStyles.Add(namedStyle1);
			this.sprReport.NamedStyles.Add(namedStyle2);
			this.sprReport.Sheets.Add(this.sprReport_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstSpecific { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optPM { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel opt183 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel opt181 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel opt182 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optAll { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optA { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optB { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optC { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optD { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtCommentSearch { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel OptNo { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel OptYes { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtNameSearch { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbSubTitle_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbSubTitle_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbSubTitle_4 { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dtStart { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dtEnd { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbCount { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbSubTitle_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbSubTitle_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbSubTitle_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprReport_Sheet1 { get; set; }

		public virtual UpgradeHelpers.DoubleJumpSupport.ComboBoxHelper cboPrimary { get; set; }

		public virtual UpgradeHelpers.DoubleJumpSupport.ComboBoxHelper cboSecondary { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClear { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdQuery { get; set; }

		public virtual UpgradeHelpers.DoubleJumpSupport.ComboBoxHelper cboUnit { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean isInitializingComponent { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean FirstTime { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean SkipLogic { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String sHeadingFilter { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrBatt { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrShift { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbSubTitle { get; set; }

		public virtual bool IsMdiChild { get; set; }

		public void OntxtCommentSearch_TextChanged()
		{
			if ( _txtCommentSearch_TextChanged != null )
				_txtCommentSearch_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtCommentSearch_TextChanged;

		public void OntxtNameSearch_TextChanged()
		{
			if ( _txtNameSearch_TextChanged != null )
				_txtNameSearch_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtNameSearch_TextChanged;
	}

}