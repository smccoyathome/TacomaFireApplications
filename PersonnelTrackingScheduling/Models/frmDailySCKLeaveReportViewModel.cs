using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmDailySCKLeaveReport))]
	public class frmDailySCKLeaveReportViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType17 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle37;
			var textCellType16 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle36;
			FarPoint.ViewModels.NamedStyle namedStyle35;
			var textCellType15 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle34;
			var textCellType14 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle33;
			FarPoint.ViewModels.NamedStyle namedStyle32;
			var textCellType13 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle31;
			FarPoint.ViewModels.NamedStyle namedStyle30;
			FarPoint.ViewModels.NamedStyle namedStyle29;
			FarPoint.ViewModels.NamedStyle namedStyle28;
			FarPoint.ViewModels.NamedStyle namedStyle27;
			var textCellType12 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle26;
			FarPoint.ViewModels.NamedStyle namedStyle25;
			var textCellType11 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle24;
			FarPoint.ViewModels.NamedStyle namedStyle23;
			var textCellType10 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle22;
			FarPoint.ViewModels.NamedStyle namedStyle21;
			var textCellType9 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle20;
			var textCellType8 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle19;
			var textCellType7 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle18;
			FarPoint.ViewModels.NamedStyle namedStyle17;
			var textCellType6 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle16;
			FarPoint.ViewModels.NamedStyle namedStyle15;
			var textCellType5 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle14;
			FarPoint.ViewModels.NamedStyle namedStyle13;
			var textCellType4 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle12;
			FarPoint.ViewModels.NamedStyle namedStyle11;
			var textCellType3 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle10;
			var emptyCellType3 = ctx.Resolve<FarPoint.ViewModels.EmptyCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle9;
			FarPoint.ViewModels.NamedStyle namedStyle8;
			var emptyCellType2 = ctx.Resolve<FarPoint.ViewModels.EmptyCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle7;
			var textCellType2 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle6;
			FarPoint.ViewModels.NamedStyle namedStyle5;
			var emptyCellType1 = ctx.Resolve<FarPoint.ViewModels.EmptyCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle4;
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.sprNewReport = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprNewReport.MaxRows = 60;
			this.sprNewReport.TabIndex = 0;
			this.sprNewReport.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.txtNameSearch = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtNameSearch.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtNameSearch.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtNameSearch.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtNameSearch.Name = "txtNameSearch";
			this.txtNameSearch.TabIndex = 13;
			this.txtNameSearch.Text = "txtNameSearch";
			this.txtComment = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtComment.Name = "txtComment";
			this.txtComment.TabIndex = 5;
			this.sprEmployee = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprEmployee.MaxRows = 100;
			this.sprEmployee.TabIndex = 2;
			this.sprEmployee.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.dteReturnDate = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dteReturnDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.dteReturnDate.MinDate = new System.DateTime(1998, 1, 1, 0, 0, 0, 0);
			this.dteReturnDate.Name = "dteReturnDate";
			this.dteReturnDate.TabIndex = 3;
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 4;
			this.Label2.Text = "Return Date";
			this.dtReportDate = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dtReportDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.dtReportDate.MinDate = new System.DateTime(1998, 1, 1, 0, 0, 0, 0);
			this.dtReportDate.Name = "dtReportDate";
			this.dtReportDate.TabIndex = 7;
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 17;
			this.Label3.Text = "Note:  The box must be checked before the Report Update Done button is enabled..." + "";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 8;
			this.Label1.Text = "Report Date";
			this.sprEmployee_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprEmployee_Sheet1.SheetName = "Sheet1";
			this.sprEmployee_Sheet1.ColumnHeader.Cells[0, 0].Value = "Name";
			this.sprEmployee_Sheet1.ColumnHeader.Cells[0, 1].Value = "Shift";
			this.sprEmployee_Sheet1.ColumnHeader.Cells[0, 2].Value = "KOT";
			this.sprEmployee_Sheet1.ColumnHeader.Cells[0, 3].Value = "ID";
			this.sprEmployee_Sheet1.Columns.Get(0).Label = "Name";
			this.sprEmployee_Sheet1.Columns.Get(0).Width = 121F;
			this.sprEmployee_Sheet1.Columns.Get(1).Label = "Shift";
			this.sprEmployee_Sheet1.Columns.Get(1).Width = 39F;
			this.sprEmployee_Sheet1.Columns.Get(2).Label = "KOT";
			this.sprEmployee_Sheet1.Columns.Get(2).Width = 46F;
			this.sprEmployee_Sheet1.Columns.Get(3).Label = "ID";
            //SortIndicator is OBSOLETE
            //this.sprEmployee_Sheet1.Columns.Get(3).SortIndicator = FarPoint.ViewModels.SortIndicator.Descending;
            this.sprEmployee_Sheet1.Columns.Get(3).Visible = false;
			this.sprEmployee_Sheet1.Columns.Get(3).Width = 0F;
			this.sprEmployee_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprEmployee_Sheet1.Rows.Get(1).Height = 14F;
			this.sprNewReport_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprNewReport_Sheet1.SheetName = "Sheet1";
            //RowSpan is OBSOLETE
            //this.sprNewReport_Sheet1.Cells.Get(0, 0).RowSpan = 3;
            //ColumnSpan is OBSOLETE
            //this.sprNewReport_Sheet1.Cells.Get(0, 1).ColumnSpan = 16;
			this.sprNewReport_Sheet1.Cells.Get(0, 1).Value = "Tacoma Fire Department - Leave Report";
			this.sprNewReport_Sheet1.Cells.Get(0, 2).Value = "Tacoma Fire Department - Leave Report";
			this.sprNewReport_Sheet1.Cells.Get(0, 4).Value = "Tacoma Fire Department - Leave Report";
			this.sprNewReport_Sheet1.Cells.Get(0, 5).Value = "Tacoma Fire Department - Leave Report";
			this.sprNewReport_Sheet1.Cells.Get(0, 6).Value = "Tacoma Fire Department - Leave Report";
			this.sprNewReport_Sheet1.Cells.Get(0, 8).Value = "Tacoma Fire Department - Leave Report";
			this.sprNewReport_Sheet1.Cells.Get(0, 9).Value = "Tacoma Fire Department - Leave Report";
			this.sprNewReport_Sheet1.Cells.Get(0, 10).Value = "Tacoma Fire Department - Leave Report";
			this.sprNewReport_Sheet1.Cells.Get(0, 12).Value = "Tacoma Fire Department - Leave Report";
            //ColumnSpan is OBSOLETE
            //this.sprNewReport_Sheet1.Cells.Get(1, 1).ColumnSpan = 12;
            //this.sprNewReport_Sheet1.Cells.Get(2, 1).ColumnSpan = 2;
            this.sprNewReport_Sheet1.Cells.Get(2, 1).Value = "Color Code =";
			this.sprNewReport_Sheet1.Cells.Get(2, 2).Value = "Color Code =";
			this.sprNewReport_Sheet1.Cells.Get(2, 4).Value = "LONG TERM,";
            //ColumnSpan is OBSOLETE
            //this.sprNewReport_Sheet1.Cells.Get(2, 5).ColumnSpan = 2;
			this.sprNewReport_Sheet1.Cells.Get(2, 5).Value = "TRANSITION,";
			this.sprNewReport_Sheet1.Cells.Get(2, 6).Value = "TRANSITION,";
            //ColumnSpan is OBSOLETE
            //this.sprNewReport_Sheet1.Cells.Get(2, 7).ColumnSpan = 2;
			this.sprNewReport_Sheet1.Cells.Get(2, 7).Value = "MILITARY";
            //ColumnSpan is OBSOLETE
            //this.sprNewReport_Sheet1.Cells.Get(2, 9).ColumnSpan = 3;
			this.sprNewReport_Sheet1.Cells.Get(2, 9).Value = "* = 1/2 Day (One Shift) ";
			this.sprNewReport_Sheet1.Cells.Get(2, 12).Value = "+= Multiple KOT";
            //ColumnSpan is OBSOLETE
            //this.sprNewReport_Sheet1.Cells.Get(2, 13).ColumnSpan = 3;
            this.sprNewReport_Sheet1.Cells.Get(2, 13).Value = "() = # of 12-hr Shifts";
			this.sprNewReport_Sheet1.Cells.Get(2, 16).Value = "Returning";
            //ColumnSpan is OBSOLETE
            //this.sprNewReport_Sheet1.Cells.Get(3, 0).ColumnSpan = 4;
            this.sprNewReport_Sheet1.Cells.Get(3, 0).Value = "A - Shift";
			this.sprNewReport_Sheet1.Cells.Get(3, 1).Value = "A - Shift";
			this.sprNewReport_Sheet1.Cells.Get(3, 2).Value = "A - Shift";
            //ColumnSpan is OBSOLETE
            //this.sprNewReport_Sheet1.Cells.Get(3, 4).ColumnSpan = 4;
			this.sprNewReport_Sheet1.Cells.Get(3, 4).Value = "B - Shift";
			this.sprNewReport_Sheet1.Cells.Get(3, 5).Value = "B - Shift";
			this.sprNewReport_Sheet1.Cells.Get(3, 6).Value = "B - Shift";
            //ColumnSpan is OBSOLETE
            //this.sprNewReport_Sheet1.Cells.Get(3, 8).ColumnSpan = 4;
			this.sprNewReport_Sheet1.Cells.Get(3, 8).Value = "C - Shift";
			this.sprNewReport_Sheet1.Cells.Get(3, 9).Value = "C - Shift";
			this.sprNewReport_Sheet1.Cells.Get(3, 10).Value = "C - Shift";
            //ColumnSpan is OBSOLETE
            //this.sprNewReport_Sheet1.Cells.Get(3, 12).ColumnSpan = 4;
			this.sprNewReport_Sheet1.Cells.Get(3, 12).Value = "D - Shift";
			this.sprNewReport_Sheet1.Cells.Get(3, 13).Value = "D - Shift";
			this.sprNewReport_Sheet1.Cells.Get(3, 14).Value = "D - Shift";
			this.sprNewReport_Sheet1.Cells.Get(3, 16).Value = "mm/dd/yy";
			this.sprNewReport_Sheet1.ColumnHeader.Rows.Get(0).Height = 0F;
			this.sprNewReport_Sheet1.Columns.Get(0).Width = 90F;
			this.sprNewReport_Sheet1.Columns.Get(1).Width = 48F;
			this.sprNewReport_Sheet1.Columns.Get(2).Width = 48F;
			this.sprNewReport_Sheet1.Columns.Get(3).Width = 48F;
			this.sprNewReport_Sheet1.Columns.Get(4).Width = 90F;
			this.sprNewReport_Sheet1.Columns.Get(5).Width = 48F;
			this.sprNewReport_Sheet1.Columns.Get(6).Width = 48F;
			this.sprNewReport_Sheet1.Columns.Get(7).Width = 48F;
			this.sprNewReport_Sheet1.Columns.Get(8).Width = 90F;
			this.sprNewReport_Sheet1.Columns.Get(9).Width = 48F;
			this.sprNewReport_Sheet1.Columns.Get(10).Width = 48F;
			this.sprNewReport_Sheet1.Columns.Get(11).Width = 48F;
			this.sprNewReport_Sheet1.Columns.Get(12).Width = 90F;
			this.sprNewReport_Sheet1.Columns.Get(13).Width = 48F;
			this.sprNewReport_Sheet1.Columns.Get(14).Width = 48F;
			this.sprNewReport_Sheet1.Columns.Get(15).Width = 48F;
			this.sprNewReport_Sheet1.Columns.Get(16).Width = 86F;
			this.sprNewReport_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprNewReport_Sheet1.Rows.Get(8).Height = 14F;
			this.sprNewReport_Sheet1.Rows.Get(26).Height = 14F;
			this.sprNewReport_Sheet1.Rows.Get(27).Height = 14F;
			this.sprNewReport_Sheet1.Rows.Get(32).Height = 14F;
			this.sprNewReport_Sheet1.Rows.Get(35).Height = 14F;
			this.sprNewReport_Sheet1.Rows.Get(37).Height = 14F;
			this.sprNewReport_Sheet1.Rows.Get(39).Height = 14F;
			this.sprNewReport_Sheet1.Rows.Get(42).Height = 14F;
			this.sprNewReport_Sheet1.Rows.Get(46).Height = 14F;
			this.chkStaff = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkStaff
			// 
			this.chkStaff.BackColor = UpgradeHelpers.Helpers.Color.Navy;
			this.chkStaff.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkStaff.ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			this.chkStaff.Name = "chkStaff";
			this.chkStaff.TabIndex = 16;
			this.chkStaff.Text = "Verify Personnel with 3 or more shifts...   Contact Battalion Chief";
			this.cmdRefresh = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdRefresh
			// 
			this.cmdRefresh.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdRefresh.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdRefresh.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdRefresh.Name = "cmdRefresh";
			this.cmdRefresh.TabIndex = 11;
			this.cmdRefresh.Text = "Refresh";
			this.cmdPrint = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrint.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrint.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.TabIndex = 9;
			this.cmdPrint.Text = "&Print Report";
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 15;
			this.cmdClose.Text = "&Close";
			this.cmdClear = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClear
			// 
			this.cmdClear.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClear.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClear.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClear.Name = "cmdClear";
			this.cmdClear.TabIndex = 14;
			this.cmdClear.Text = "Clear";
			this.cmdUndo = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdUndo
			// 
			this.cmdUndo.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdUndo.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdUndo.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdUndo.Name = "cmdUndo";
			this.cmdUndo.TabIndex = 12;
			this.cmdUndo.Text = "Undo";
			this.cmdApproved = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdApproved
			// 
			this.cmdApproved.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdApproved.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdApproved.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdApproved.Name = "cmdApproved";
			this.cmdApproved.TabIndex = 10;
			this.cmdApproved.Text = "Report Update Done";
			this.cmdEdit = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdEdit
			// 
			this.cmdEdit.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdEdit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdEdit.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.TabIndex = 6;
			this.cmdEdit.Text = "OK";
			this.Text = "Manage Leave Returns";
			this.LastMoveUpdateReport = false;
			this.ReportDate = "";
			this.CurrEmpID = "";
			this.bYesterday = false;
			this.AShift = 0;
			this.BShift = 0;
			this.CShift = 0;
			this.DShift = 0;
			this.CurrRow = 0;
			this.LimitedPower = false;
			this.Part2 = false;
			this.OtherAShift = 0;
			this.OtherBShift = 0;
			this.OtherCShift = 0;
			this.OtherDShift = 0;
			this.StudentAShift = 0;
			this.StudentBShift = 0;
			this.StudentCShift = 0;
			this.StudentDShift = 0;
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx58636234689576882481", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text397636234689577204726", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color1838636234689577302376");
			namedStyle3.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Empty323294636234689578210521");
			namedStyle4.CellType = emptyCellType1;
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.Renderer = emptyCellType1;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color22636234689578220286");
			namedStyle5.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle5.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(160)))));
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static56636234689578230051");
			namedStyle6.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle6.CellType = textCellType2;
			namedStyle6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle6.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(160)))));
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.Renderer = textCellType2;
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle7 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Empty323294636234689579089371");
			namedStyle7.CellType = emptyCellType2;
			namedStyle7.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle7.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle7.Renderer = emptyCellType2;
			namedStyle7.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle8 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color22636234689579099136");
			namedStyle8.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle8.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle8.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle8.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle8.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle9 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Empty323294636234689579841276");
			namedStyle9.CellType = emptyCellType3;
			namedStyle9.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle9.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle9.Renderer = emptyCellType3;
			namedStyle9.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle10 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static18636234689579860806");
			namedStyle10.CellType = textCellType3;
			namedStyle10.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle10.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle10.Renderer = textCellType3;
			namedStyle10.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle11 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color112636234689579899866");
			namedStyle11.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle11.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, ((UpgradeHelpers.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))));
			namedStyle11.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle11.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle11.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle11.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle12 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static146636234689579899866");
			namedStyle12.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle12.CellType = textCellType4;
			namedStyle12.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, ((UpgradeHelpers.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))));
			namedStyle12.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle12.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle12.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle12.Renderer = textCellType4;
			namedStyle12.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle13 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color193636234689579909631");
			namedStyle13.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle13.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, ((UpgradeHelpers.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))));
			namedStyle13.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			namedStyle13.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle13.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle13.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle14 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static227636234689579919396");
			namedStyle14.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle14.CellType = textCellType5;
			namedStyle14.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, ((UpgradeHelpers.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))));
			namedStyle14.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			namedStyle14.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle14.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle14.Renderer = textCellType5;
			namedStyle14.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle15 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color130636234689578239816");
			namedStyle15.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle15.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, ((UpgradeHelpers.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))));
			namedStyle15.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(160)))));
			namedStyle15.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle15.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle15.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle16 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static309636234689579929161");
			namedStyle16.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle16.CellType = textCellType6;
			namedStyle16.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, ((UpgradeHelpers.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))));
			namedStyle16.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(160)))));
			namedStyle16.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle16.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle16.Renderer = textCellType6;
			namedStyle16.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle17 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color357636234689579938926");
			namedStyle17.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle17.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, ((UpgradeHelpers.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))));
			namedStyle17.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			namedStyle17.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle17.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle17.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle18 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static391636234689579948691");
			namedStyle18.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle18.CellType = textCellType7;
			namedStyle18.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, ((UpgradeHelpers.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))));
			namedStyle18.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			namedStyle18.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle18.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle18.Renderer = textCellType7;
			namedStyle18.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle19 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static432636234689579958456");
			namedStyle19.CellType = textCellType8;
			namedStyle19.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle19.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle19.Renderer = textCellType8;
			namedStyle19.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle20 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static537636234689579987751");
			namedStyle20.CellType = textCellType9;
			namedStyle20.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle20.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle20.Renderer = textCellType9;
			namedStyle20.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle21 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx665636234689579997516");
			namedStyle21.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle21.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle21.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle21.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle21.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle22 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static705636234689580007281");
			namedStyle22.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle22.CellType = textCellType10;
			namedStyle22.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle22.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle22.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle22.Renderer = textCellType10;
			namedStyle22.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle23 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx767636234689580017046");
			namedStyle23.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle23.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle23.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle23.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle23.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle24 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static807636234689580017046");
			namedStyle24.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle24.CellType = textCellType11;
			namedStyle24.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle24.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle24.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle24.Renderer = textCellType11;
			namedStyle24.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle25 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx869636234689580026811");
			namedStyle25.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle25.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle25.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle25.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle25.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle26 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static909636234689580036576");
			namedStyle26.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle26.CellType = textCellType12;
			namedStyle26.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle26.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle26.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle26.Renderer = textCellType12;
			namedStyle26.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle27 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx971636234689580046341");
			namedStyle27.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle27.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle27.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle28 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1009636234689580046341");
			namedStyle28.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle28.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle28.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle29 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1213636234689580085401");
			namedStyle29.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle29.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle29.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle30 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2041636234689580241641");
			namedStyle30.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle30.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle30.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle30.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle30.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle31 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2081636234689580251406");
			namedStyle31.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle31.CellType = textCellType13;
			namedStyle31.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle31.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle31.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle31.Renderer = textCellType13;
			namedStyle31.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle32 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2153636234689580261171");
			namedStyle32.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle32.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle32.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle33 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2209636234689580270936");
			namedStyle33.CellType = textCellType14;
			namedStyle33.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle33.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle33.Renderer = textCellType14;
			namedStyle33.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle34 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3097636234689581813806");
			namedStyle34.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle34.CellType = textCellType15;
			namedStyle34.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle34.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle34.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle34.Renderer = textCellType15;
			namedStyle34.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle35 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234689482523286", "DataAreaDefault");
			namedStyle35.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle35.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle35.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle35.Parent = "DataAreaDefault";
			namedStyle35.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle36 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text325636234689482533051", "DataAreaDefault");
			namedStyle36.CellType = textCellType16;
			namedStyle36.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle36.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle36.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle36.Parent = "DataAreaDefault";
			namedStyle36.Renderer = textCellType16;
			namedStyle36.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle37 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static967636234689482562346");
			namedStyle37.CellType = textCellType17;
			namedStyle37.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle37.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle37.Renderer = textCellType17;
			namedStyle37.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			this.Name = "PTSProject.frmDailySCKLeaveReport";
			IsMdiChild = true;
			this.sprNewReport.NamedStyles.Add(namedStyle1);
			this.sprNewReport.NamedStyles.Add(namedStyle2);
			this.sprNewReport.NamedStyles.Add(namedStyle3);
			this.sprNewReport.NamedStyles.Add(namedStyle4);
			this.sprNewReport.NamedStyles.Add(namedStyle5);
			this.sprNewReport.NamedStyles.Add(namedStyle6);
			this.sprNewReport.NamedStyles.Add(namedStyle7);
			this.sprNewReport.NamedStyles.Add(namedStyle8);
			this.sprNewReport.NamedStyles.Add(namedStyle9);
			this.sprNewReport.NamedStyles.Add(namedStyle10);
			this.sprNewReport.NamedStyles.Add(namedStyle11);
			this.sprNewReport.NamedStyles.Add(namedStyle12);
			this.sprNewReport.NamedStyles.Add(namedStyle13);
			this.sprNewReport.NamedStyles.Add(namedStyle14);
			this.sprNewReport.NamedStyles.Add(namedStyle15);
			this.sprNewReport.NamedStyles.Add(namedStyle16);
			this.sprNewReport.NamedStyles.Add(namedStyle17);
			this.sprNewReport.NamedStyles.Add(namedStyle18);
			this.sprNewReport.NamedStyles.Add(namedStyle19);
			this.sprNewReport.NamedStyles.Add(namedStyle20);
			this.sprNewReport.NamedStyles.Add(namedStyle21);
			this.sprNewReport.NamedStyles.Add(namedStyle22);
			this.sprNewReport.NamedStyles.Add(namedStyle23);
			this.sprNewReport.NamedStyles.Add(namedStyle24);
			this.sprNewReport.NamedStyles.Add(namedStyle25);
			this.sprNewReport.NamedStyles.Add(namedStyle26);
			this.sprNewReport.NamedStyles.Add(namedStyle27);
			this.sprNewReport.NamedStyles.Add(namedStyle28);
			this.sprNewReport.NamedStyles.Add(namedStyle29);
			this.sprNewReport.NamedStyles.Add(namedStyle30);
			this.sprNewReport.NamedStyles.Add(namedStyle31);
			this.sprNewReport.NamedStyles.Add(namedStyle32);
			this.sprNewReport.NamedStyles.Add(namedStyle33);
			this.sprNewReport.NamedStyles.Add(namedStyle34);
			this.sprNewReport.Sheets.Add(this.sprNewReport_Sheet1);
			this.sprEmployee.NamedStyles.Add(namedStyle35);
			this.sprEmployee.NamedStyles.Add(namedStyle36);
			this.sprEmployee.NamedStyles.Add(namedStyle37);
			this.sprEmployee.Sheets.Add(this.sprEmployee_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprNewReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtNameSearch { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtComment { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprEmployee { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dteReturnDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dtReportDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprEmployee_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprNewReport_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkStaff { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdRefresh { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClear { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdUndo { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdApproved { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdEdit { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean LastMoveUpdateReport { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String ReportDate { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrEmpID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean bYesterday { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 AShift { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 BShift { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CShift { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 DShift { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean LimitedPower { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean Part2 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 OtherAShift { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 OtherBShift { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 OtherCShift { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 OtherDShift { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 StudentAShift { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 StudentBShift { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 StudentCShift { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 StudentDShift { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

		public void OntxtNameSearch_TextChanged()
		{
			if ( _txtNameSearch_TextChanged != null )
				_txtNameSearch_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtNameSearch_TextChanged;
	}

}