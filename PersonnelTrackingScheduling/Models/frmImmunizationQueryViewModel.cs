using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmImmunizationQuery))]
	public class frmImmunizationQueryViewModel
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
			this.sprReport.TabIndex = 0;
			this.sprReport.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.opt183 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// opt183
			// 
			this.opt183.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.opt183.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.opt183.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.opt183.Name = "opt183";
			this.opt183.TabIndex = 31;
			this.opt183.Text = "Batt 3";
			this.optAll = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optAll
			// 
			this.optAll.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.optAll.Checked = true;
			this.optAll.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optAll.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.optAll.Name = "optAll";
			this.optAll.TabIndex = 30;
			this.optAll.Text = "ALL";
			this.opt182 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// opt182
			// 
			this.opt182.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.opt182.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.opt182.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.opt182.Name = "opt182";
			this.opt182.TabIndex = 29;
			this.opt182.Text = "Batt 2";
			this.opt181 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// opt181
			// 
			this.opt181.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.opt181.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.opt181.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.opt181.Name = "opt181";
			this.opt181.TabIndex = 28;
			this.opt181.Text = "Batt 1";
			this.dtStart = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dtStart.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.dtStart.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dtStart.Name = "dtStart";
			this.dtStart.TabIndex = 19;
			this.dtEnd = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dtEnd.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.dtEnd.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dtEnd.Name = "dtEnd";
			this.dtEnd.TabIndex = 20;
			this._lbSubTitle_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 23;
			this.Label2.Text = "Date Range";
			this._Label3_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 21;
			this.Label4.Text = "Thru:";
			this.txtNameSearch = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtNameSearch.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtNameSearch.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtNameSearch.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtNameSearch.Name = "txtNameSearch";
			this.txtNameSearch.TabIndex = 12;
			this.txtNameSearch.Text = "txtNameSearch";
			this.cboAssignmentCode = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboAssignmentCode
			// 
			this.cboAssignmentCode.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboAssignmentCode.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboAssignmentCode.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboAssignmentCode.Name = "cboAssignmentCode";
			this.cboAssignmentCode.TabIndex = 8;
			this.cboAssignmentCode.Text = "cboAssignmentCode";
			this.optD = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optD
			// 
			this.optD.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.optD.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optD.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.optD.Name = "optD";
			this.optD.TabIndex = 7;
			this.optD.Text = "Shift D";
			this.optC = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optC
			// 
			this.optC.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.optC.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optC.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.optC.Name = "optC";
			this.optC.TabIndex = 6;
			this.optC.Text = "Shift C";
			this.optB = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optB
			// 
			this.optB.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.optB.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optB.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.optB.Name = "optB";
			this.optB.TabIndex = 5;
			this.optB.Text = "Shift B";
			this.optA = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optA
			// 
			this.optA.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.optA.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optA.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.optA.Name = "optA";
			this.optA.TabIndex = 4;
			this.optA.Text = "Shift A";
			this.lbCount = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbCount
			// 
			this.lbCount.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbCount.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbCount.ForeColor = UpgradeHelpers.Helpers.Color.Lime;
			this.lbCount.Name = "lbCount";
			this.lbCount.TabIndex = 26;
			this.lbCount.Text = "Total Count:  ";
			this._lbSubTitle_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbSubTitle_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label3_3120 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.sprReport_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprReport_Sheet1.SheetName = "Sheet1";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 0].Value = "Name";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 1].Value = "Shift";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 2].Value = "Unit";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 3].Value = "Batt";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 4].Value = "Immunization";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 5].Value = "Date";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 6].Value = "Results";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 7].Value = "Comments";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 8].Value = "ID";
			this.sprReport_Sheet1.Columns.Get(0).Label = "Name";
			this.sprReport_Sheet1.Columns.Get(0).Width = 102F;
			this.sprReport_Sheet1.Columns.Get(1).Label = "Shift";
			this.sprReport_Sheet1.Columns.Get(1).Width = 30F;
			this.sprReport_Sheet1.Columns.Get(2).Label = "Unit";
			this.sprReport_Sheet1.Columns.Get(2).Width = 35F;
			this.sprReport_Sheet1.Columns.Get(3).Label = "Batt";
			this.sprReport_Sheet1.Columns.Get(3).Width = 28F;
			this.sprReport_Sheet1.Columns.Get(4).Label = "Immunization";
			this.sprReport_Sheet1.Columns.Get(4).Width = 74F;
			this.sprReport_Sheet1.Columns.Get(5).Label = "Date";
			this.sprReport_Sheet1.Columns.Get(5).Width = 70F;
			this.sprReport_Sheet1.Columns.Get(6).Label = "Results";
			this.sprReport_Sheet1.Columns.Get(6).Width = 43F;
			this.sprReport_Sheet1.Columns.Get(7).Label = "Comments";
			this.sprReport_Sheet1.Columns.Get(7).Width = 268F;
			this.sprReport_Sheet1.Columns.Get(8).Label = "ID";
			this.sprReport_Sheet1.Columns.Get(8).Visible = false;
			this.sprReport_Sheet1.Columns.Get(8).Width = 0F;
			this.sprReport_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprReport_Sheet1.Rows.Get(0).Height = 14F;
			this.cboUnit = ctx.Resolve<UpgradeHelpers.DoubleJumpSupport.ComboBoxHelper>();
			this.cboUnit.Clicked = false;
			this.cboUnit.ListIndex = -1;
			this.cboUnit.Name = "cboUnit";
			this.cboUnit.TabIndex = 10;
			this.cboType = ctx.Resolve<UpgradeHelpers.DoubleJumpSupport.ComboBoxHelper>();
			this.cboType.Clicked = false;
			this.cboType.ListIndex = -1;
			this.cboType.Name = "cboType";
			this.cboType.TabIndex = 18;
			this.chkNotReceived = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkNotReceived
			// 
			this.chkNotReceived.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.chkNotReceived.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkNotReceived.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.chkNotReceived.Name = "chkNotReceived";
			this.chkNotReceived.TabIndex = 25;
			this.chkNotReceived.Text = "Display Not Received";
			this._cmdClear_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this.cmdPrint = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrint.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrint.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.TabIndex = 15;
			this.cmdPrint.Text = "Print List";
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 14;
			this.cmdClose.Text = "Exit";
			this.cmdQuery = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdQuery
			// 
			this.cmdQuery.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdQuery.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdQuery.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdQuery.Name = "cmdQuery";
			this.cmdQuery.TabIndex = 2;
			this.cmdQuery.Text = "Query";
			this.cmdQuery.Visible = false;
			this.Text = "Immunization Query";
			this.FirstTime = false;
			this.SkipLogic = false;
			this.sHeadingFilter = "";
			this.CurrBatt = "";
			this.CurrShift = "";
			this.CurrUnit = "";
			this.CurrGroup = "";
			lbSubTitle = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(5);
			lbSubTitle[0] = _lbSubTitle_0;
			lbSubTitle[2] = _lbSubTitle_2;
			lbSubTitle[4] = _lbSubTitle_4;
			lbSubTitle[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbSubTitle[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbSubTitle[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			lbSubTitle[0].Name = "_lbSubTitle_0";
			lbSubTitle[0].TabIndex = 24;
			lbSubTitle[0].Text = "Type Code";
			lbSubTitle[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbSubTitle[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbSubTitle[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			lbSubTitle[2].Name = "_lbSubTitle_2";
			lbSubTitle[2].TabIndex = 13;
			lbSubTitle[2].Text = "Filter by Name:";
			lbSubTitle[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbSubTitle[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbSubTitle[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			lbSubTitle[4].Name = "_lbSubTitle_4";
			lbSubTitle[4].TabIndex = 11;
			lbSubTitle[4].Text = "Unit ";
			cmdClear = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel>>(1);
			cmdClear[0] = _cmdClear_0;
			cmdClear[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdClear[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cmdClear[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdClear[0].Name = "_cmdClear_0";
			cmdClear[0].TabIndex = 16;
			cmdClear[0].Text = "Clear Filters";
			Label3 = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(3121);
			Label3[0] = _Label3_0;
			Label3[3120] = _Label3_3120;
			Label3[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label3[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label3[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			Label3[0].Name = "_Label3_0";
			Label3[0].TabIndex = 22;
			Label3[0].Text = "From:";
			Label3[3120].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			Label3[3120].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label3[3120].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			Label3[3120].Name = "_Label3_3120";
			Label3[3120].TabIndex = 9;
			Label3[3120].Text = "Assignment Group";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234718471829961", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text291636234718472005731", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			this.Name = "PTSProject.frmImmunizationQuery";
			IsMdiChild = true;
			this.sprReport.NamedStyles.Add(namedStyle1);
			this.sprReport.NamedStyles.Add(namedStyle2);
			this.sprReport.Sheets.Add(this.sprReport_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel opt183 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optAll { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel opt182 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel opt181 { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dtStart { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dtEnd { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbSubTitle_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label3_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtNameSearch { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboAssignmentCode { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optD { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optC { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optB { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optA { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbCount { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbSubTitle_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbSubTitle_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label3_3120 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprReport_Sheet1 { get; set; }

		public virtual UpgradeHelpers.DoubleJumpSupport.ComboBoxHelper cboUnit { get; set; }

		public virtual UpgradeHelpers.DoubleJumpSupport.ComboBoxHelper cboType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkNotReceived { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdClear_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdQuery { get; set; }

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
		public virtual System.String CurrUnit { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrGroup { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbSubTitle { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel> cmdClear { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> Label3 { get; set; }

		public virtual bool IsMdiChild { get; set; }

		public void OntxtNameSearch_TextChanged()
		{
			if ( _txtNameSearch_TextChanged != null )
				_txtNameSearch_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtNameSearch_TextChanged;
	}

}