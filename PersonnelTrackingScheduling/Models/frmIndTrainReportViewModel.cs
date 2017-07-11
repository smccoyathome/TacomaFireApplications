using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmIndTrainReport))]
	public class frmIndTrainReportViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType5 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle12;
			FarPoint.ViewModels.NamedStyle namedStyle11;
			FarPoint.ViewModels.NamedStyle namedStyle10;
			var textCellType4 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle9;
			FarPoint.ViewModels.NamedStyle namedStyle8;
			var textCellType3 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle7;
			FarPoint.ViewModels.NamedStyle namedStyle6;
			FarPoint.ViewModels.NamedStyle namedStyle5;
			var textCellType2 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle4;
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.sprInd = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprInd.MaxRows = 2000;
			this.sprInd.TabIndex = 0;
			this.sprInd.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.lstSpecific = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			this.lstSpecific.Name = "lstSpecific";
			this.lstSpecific.TabIndex = 2;
			this.cboEmployee = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboEmployee
			// 
			this.cboEmployee.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboEmployee.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboEmployee.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboEmployee.Name = "cboEmployee";
			this.cboEmployee.TabIndex = 7;
			this.dtStart = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dtStart.MinDate = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
			this.dtStart.Name = "dtStart";
			this.dtStart.TabIndex = 9;
			this.dtEnd = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dtEnd.MinDate = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
			this.dtEnd.Name = "dtEnd";
			this.dtEnd.TabIndex = 10;
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 17;
			this.Label2.Text = "Select date Range";
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 16;
			this.Label3.Text = "From:";
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 15;
			this.Label4.Text = "Thru:";
			this._lbSubTitle_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbSubTitle_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbSubTitle_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 11;
			this.Label1.Text = "Select Employee:";
			this.lbEmpName = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEmpName
			// 
			this.lbEmpName.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbEmpName.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbEmpName.Name = "lbEmpName";
			this.lbEmpName.TabIndex = 20;
			this.lbEmpName.Visible = false;
			this.sprInd_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprInd_Sheet1.SheetName = "Sheet1";
			this.sprInd_Sheet1.Cells.Get(0, 0).Value = "Tacoma Fire Department";
			this.sprInd_Sheet1.Cells.Get(1, 0).Value = "Individual Training Report";
			this.sprInd_Sheet1.Cells.Get(2, 0).Value = "Training By Year";
			this.sprInd_Sheet1.ColumnHeader.Rows.Get(0).Height = 0F;
			this.sprInd_Sheet1.Columns.Get(0).Width = 36F;
			this.sprInd_Sheet1.Columns.Get(1).Width = 76F;
			this.sprInd_Sheet1.Columns.Get(2).Width = 74F;
			this.sprInd_Sheet1.Columns.Get(3).Width = 83F;
			this.sprInd_Sheet1.Columns.Get(4).Width = 89F;
			this.sprInd_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprInd_Sheet1.Rows.Get(0).Height = 19F;
			this.cmdPrint = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrint.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrint.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.TabIndex = 19;
			this.cmdPrint.Text = "&Print";
			this.cmdExit = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdExit
			// 
			this.cmdExit.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdExit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdExit.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdExit.Name = "cmdExit";
			this.cmdExit.TabIndex = 18;
			this.cmdExit.Text = "E&xit";
			this.cboSecondary = ctx.Resolve<UpgradeHelpers.DoubleJumpSupport.ComboBoxHelper>();
			this.cboSecondary.Clicked = false;
			this.cboSecondary.ListIndex = -1;
			this.cboSecondary.Name = "cboSecondary";
			this.cboSecondary.TabIndex = 4;
			this.cboPrimary = ctx.Resolve<UpgradeHelpers.DoubleJumpSupport.ComboBoxHelper>();
			this.cboPrimary.Clicked = false;
			this.cboPrimary.ListIndex = -1;
			this.cboPrimary.Name = "cboPrimary";
			this.cboPrimary.TabIndex = 3;
			this.cmdClear = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClear
			// 
			this.cmdClear.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClear.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClear.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClear.Name = "cmdClear";
			this.cmdClear.TabIndex = 21;
			this.cmdClear.Tag = "T";
			this.cmdClear.Text = "Clear Filters";
			this.chkInactive = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkInactive
			// 
			this.chkInactive.BackColor = UpgradeHelpers.Helpers.Color.Navy;
			this.chkInactive.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkInactive.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.chkInactive.Name = "chkInactive";
			this.chkInactive.TabIndex = 8;
			this.chkInactive.Text = "Display Inactive Employees";
			this.cmdReportLevel = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdReportLevel
			// 
			this.cmdReportLevel.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdReportLevel.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdReportLevel.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdReportLevel.Name = "cmdReportLevel";
			this.cmdReportLevel.TabIndex = 6;
			this.cmdReportLevel.Tag = "S";
			this.cmdReportLevel.Text = "&Summary";
			this.cmdByDate = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdByDate
			// 
			this.cmdByDate.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdByDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdByDate.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdByDate.Name = "cmdByDate";
			this.cmdByDate.TabIndex = 5;
			this.cmdByDate.Tag = "T";
			this.cmdByDate.Text = "Sort by &Type";
			this.Text = "Individual Training Report";
			this.TotalRows = 0;
			this.CurrEmp = "";
			this.lSpecificID = 0;
			this.ReportMode = "";
			this.ReportLevel = "";
			lbSubTitle = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(4);
			lbSubTitle[0] = _lbSubTitle_0;
			lbSubTitle[1] = _lbSubTitle_1;
			lbSubTitle[3] = _lbSubTitle_3;
			lbSubTitle[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbSubTitle[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbSubTitle[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			lbSubTitle[0].Name = "_lbSubTitle_0";
			lbSubTitle[0].TabIndex = 14;
			lbSubTitle[0].Text = "Primary Training Type";
			lbSubTitle[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbSubTitle[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbSubTitle[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			lbSubTitle[1].Name = "_lbSubTitle_1";
			lbSubTitle[1].TabIndex = 13;
			lbSubTitle[1].Text = "Secondary Training Type";
			lbSubTitle[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbSubTitle[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbSubTitle[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			lbSubTitle[3].Name = "_lbSubTitle_3";
			lbSubTitle[3].TabIndex = 12;
			lbSubTitle[3].Text = "Specific Training ";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color65636234725475975256", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text436636234725475985020", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font115636234725476024076");
			namedStyle3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static133636234725476033840");
			namedStyle4.CellType = textCellType2;
			namedStyle4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.Renderer = textCellType2;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font357636234725476121716");
			namedStyle5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F);
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx470636234725476258412");
			namedStyle6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F);
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle7 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static504636234725476277940");
			namedStyle7.CellType = textCellType3;
			namedStyle7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F);
			namedStyle7.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle7.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle7.Renderer = textCellType3;
			namedStyle7.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle8 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx542636234725476287704");
			namedStyle8.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F);
			namedStyle8.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle8.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle8.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle9 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static576636234725476316996");
			namedStyle9.CellType = textCellType4;
			namedStyle9.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F);
			namedStyle9.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle9.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle9.Renderer = textCellType4;
			namedStyle9.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle10 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx614636234725476326760");
			namedStyle10.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle10.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle10.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle11 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx812636234725476424400");
			namedStyle11.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F);
			namedStyle11.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle11.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle11.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle12 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static905636234725476473220");
			namedStyle12.CellType = textCellType5;
			namedStyle12.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F);
			namedStyle12.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle12.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle12.Renderer = textCellType5;
			namedStyle12.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			this.Name = "PTSProject.frmIndTrainReport";
			IsMdiChild = true;
			this.sprInd.NamedStyles.Add(namedStyle1);
			this.sprInd.NamedStyles.Add(namedStyle2);
			this.sprInd.NamedStyles.Add(namedStyle3);
			this.sprInd.NamedStyles.Add(namedStyle4);
			this.sprInd.NamedStyles.Add(namedStyle5);
			this.sprInd.NamedStyles.Add(namedStyle6);
			this.sprInd.NamedStyles.Add(namedStyle7);
			this.sprInd.NamedStyles.Add(namedStyle8);
			this.sprInd.NamedStyles.Add(namedStyle9);
			this.sprInd.NamedStyles.Add(namedStyle10);
			this.sprInd.NamedStyles.Add(namedStyle11);
			this.sprInd.NamedStyles.Add(namedStyle12);
			this.sprInd.Sheets.Add(this.sprInd_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprInd { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstSpecific { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboEmployee { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dtStart { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dtEnd { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbSubTitle_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbSubTitle_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbSubTitle_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEmpName { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprInd_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdExit { get; set; }

		public virtual UpgradeHelpers.DoubleJumpSupport.ComboBoxHelper cboSecondary { get; set; }

		public virtual UpgradeHelpers.DoubleJumpSupport.ComboBoxHelper cboPrimary { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClear { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkInactive { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdReportLevel { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdByDate { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 TotalRows { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrEmp { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 lSpecificID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String ReportMode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String ReportLevel { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbSubTitle { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}