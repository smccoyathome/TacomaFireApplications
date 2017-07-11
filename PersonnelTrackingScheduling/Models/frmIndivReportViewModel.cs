using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmIndivReport))]
	public class frmIndivReportViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType19 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle44;
			FarPoint.ViewModels.NamedStyle namedStyle43;
			FarPoint.ViewModels.NamedStyle namedStyle42;
			var textCellType18 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle41;
			FarPoint.ViewModels.NamedStyle namedStyle40;
			var textCellType17 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle39;
			FarPoint.ViewModels.NamedStyle namedStyle38;
			var textCellType16 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle37;
			FarPoint.ViewModels.NamedStyle namedStyle36;
			FarPoint.ViewModels.NamedStyle namedStyle35;
			FarPoint.ViewModels.NamedStyle namedStyle34;
			var textCellType15 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle33;
			FarPoint.ViewModels.NamedStyle namedStyle32;
			var textCellType14 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle31;
			FarPoint.ViewModels.NamedStyle namedStyle30;
			FarPoint.ViewModels.NamedStyle namedStyle29;
			FarPoint.ViewModels.NamedStyle namedStyle28;
			var textCellType13 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle27;
			var textCellType12 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle26;
			var textCellType11 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle25;
			FarPoint.ViewModels.NamedStyle namedStyle24;
			var textCellType10 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle23;
			FarPoint.ViewModels.NamedStyle namedStyle22;
			var textCellType9 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle21;
			FarPoint.ViewModels.NamedStyle namedStyle20;
			var textCellType8 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle19;
			FarPoint.ViewModels.NamedStyle namedStyle18;
			var textCellType7 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle17;
			var textCellType6 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle16;
			FarPoint.ViewModels.NamedStyle namedStyle15;
			var textCellType5 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle14;
			FarPoint.ViewModels.NamedStyle namedStyle13;
			FarPoint.ViewModels.NamedStyle namedStyle12;
			var textCellType4 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle11;
			FarPoint.ViewModels.NamedStyle namedStyle10;
			var textCellType3 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle9;
			var textCellType2 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle8;
			FarPoint.ViewModels.NamedStyle namedStyle7;
			FarPoint.ViewModels.NamedStyle namedStyle6;
			FarPoint.ViewModels.NamedStyle namedStyle5;
			FarPoint.ViewModels.NamedStyle namedStyle4;
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.sprIndiv = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprIndiv.TabIndex = 4;
			this.sprIndiv.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.cboYear = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboYear
			// 
			this.cboYear.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboYear.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboYear.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboYear.Name = "cboYear";
			this.cboYear.TabIndex = 5;
			this.cboNameList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboNameList
			// 
			this.cboNameList.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboNameList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboNameList.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboNameList.Name = "cboNameList";
			this.cboNameList.TabIndex = 3;
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 7;
			this.Label2.Text = "* = Instead Of Sick Leave...";
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 6;
			this.Label3.Text = "Report Year";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 2;
			this.Label1.Text = "Select Employee";
			this.sprIndiv_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprIndiv_Sheet1.SheetName = "Sheet1";
			this.sprIndiv_Sheet1.Cells.Get(0, 0).Value = "Tacoma Fire Department";
			this.sprIndiv_Sheet1.Cells.Get(1, 0).Value = "Individual Leave Report";
			this.sprIndiv_Sheet1.Cells.Get(1, 6).Value = "Print Date";
			this.sprIndiv_Sheet1.Cells.Get(1, 7).Value = "Date";
			this.sprIndiv_Sheet1.Cells.Get(3, 0).Value = "Name";
			this.sprIndiv_Sheet1.Cells.Get(3, 2).Value = "EmpID";
			this.sprIndiv_Sheet1.Cells.Get(3, 3).Value = "Address";
			this.sprIndiv_Sheet1.Cells.Get(3, 5).Value = "City";
			this.sprIndiv_Sheet1.Cells.Get(3, 6).Value = "Zip";
			this.sprIndiv_Sheet1.Cells.Get(4, 0).Value = "Job Title";
			this.sprIndiv_Sheet1.Cells.Get(4, 2).Value = "Unit";
			this.sprIndiv_Sheet1.Cells.Get(4, 3).Value = "Position";
			this.sprIndiv_Sheet1.Cells.Get(4, 4).Value = "Shift";
			this.sprIndiv_Sheet1.Cells.Get(4, 5).Value = "Debit Grp";
			this.sprIndiv_Sheet1.Cells.Get(6, 0).Value = "Scheduled Leave:";
			this.sprIndiv_Sheet1.Cells.Get(6, 3).Value = "Unscheduled Leave:";
			this.sprIndiv_Sheet1.Cells.Get(6, 6).Value = "Scheduled Debit Days:";
			this.sprIndiv_Sheet1.Cells.Get(7, 0).Value = "Leave Type";
			this.sprIndiv_Sheet1.Cells.Get(7, 1).Value = "AM Shift";
			this.sprIndiv_Sheet1.Cells.Get(7, 2).Value = "PM Shift";
			this.sprIndiv_Sheet1.Cells.Get(7, 3).Value = "Leave Type";
			this.sprIndiv_Sheet1.Cells.Get(7, 4).Value = "AM Shift";
			this.sprIndiv_Sheet1.Cells.Get(7, 5).Value = "PM Shift";
			this.sprIndiv_Sheet1.Cells.Get(7, 6).Value = "AM Shift";
			this.sprIndiv_Sheet1.Cells.Get(7, 7).Value = "PM Shift";
			this.sprIndiv_Sheet1.Cells.Get(33, 5).Value = "Available Leave Summary for Active Only";
			this.sprIndiv_Sheet1.Cells.Get(34, 5).Value = "Type ";
			this.sprIndiv_Sheet1.Cells.Get(34, 6).Value = "Earned";
			this.sprIndiv_Sheet1.Cells.Get(34, 7).Value = "Available";
			this.sprIndiv_Sheet1.Cells.Get(39, 5).Value = "VACBANK";
			this.sprIndiv_Sheet1.Cells.Get(39, 6).Value = "Used";
			this.sprIndiv_Sheet1.Cells.Get(39, 7).Value = "Available";
			this.sprIndiv_Sheet1.Cells.Get(43, 5).Value = "Note:";
			this.sprIndiv_Sheet1.Cells.Get(44, 5).Value = "Beginning Oct 1, 2001, Military Leave is";
			this.sprIndiv_Sheet1.Cells.Get(45, 5).Value = "based on fiscal year, which runs from Oct 1st";
			this.sprIndiv_Sheet1.Cells.Get(46, 5).Value = "through Sep 30.";
			this.sprIndiv_Sheet1.Cells.Get(48, 5).Value = "This report displays totals from Oct 1 of ";
			this.sprIndiv_Sheet1.Cells.Get(49, 5).Value = "the previous year through Sep 30 of this";
			this.sprIndiv_Sheet1.Cells.Get(50, 5).Value = "year (ML1) AND totals from Oct 1 of this";
			this.sprIndiv_Sheet1.Cells.Get(51, 5).Value = "year through Sep 30 of next year (ML2).";
			this.sprIndiv_Sheet1.ColumnHeader.Rows.Get(0).Height = 0F;
			this.sprIndiv_Sheet1.Columns.Get(0).Width = 102F;
			this.sprIndiv_Sheet1.Columns.Get(1).Width = 67F;
			this.sprIndiv_Sheet1.Columns.Get(2).Width = 106F;
			this.sprIndiv_Sheet1.Columns.Get(3).Width = 92F;
			this.sprIndiv_Sheet1.Columns.Get(4).Width = 73F;
			this.sprIndiv_Sheet1.Columns.Get(5).Width = 114F;
			this.sprIndiv_Sheet1.Columns.Get(6).Width = 74F;
			this.sprIndiv_Sheet1.Columns.Get(7).Width = 88F;
			this.sprIndiv_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.chkInactive = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkInactive
			// 
			this.chkInactive.BackColor = UpgradeHelpers.Helpers.Color.Teal;
			this.chkInactive.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkInactive.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.chkInactive.Name = "chkInactive";
			this.chkInactive.TabIndex = 8;
			this.chkInactive.Text = "Display Inactive Employees";
			this.cmdPrint = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrint.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrint.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.TabIndex = 1;
			this.cmdPrint.Text = "&Print";
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 0;
			this.cmdClose.Text = "&Close";
			this.Text = "Individual Leave Report";
			this.LastRow = 0;
			this.ReportYear = 0;
			this.bUseNewMILMAX = false;
			this.bBothMILMAX = false;
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color65636234723286970991", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text502636234723286990521", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font1184636234723287019816");
			namedStyle3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 12F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1286636234723287058876");
			namedStyle4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 12F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1378636234723287078406");
			namedStyle5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1647636234723287136996");
			namedStyle6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F, UpgradeHelpers.Helpers.FontStyle.Italic);
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle7 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1742636234723287185821");
			namedStyle7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle7.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle7.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle7.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle8 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1776636234723287254176");
			namedStyle8.CellType = textCellType2;
			namedStyle8.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle8.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle8.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle8.Renderer = textCellType2;
			namedStyle8.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle9 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1851636234723287293236");
			namedStyle9.CellType = textCellType3;
			namedStyle9.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle9.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle9.Renderer = textCellType3;
			namedStyle9.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle10 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1833636234723287273706");
			namedStyle10.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle10.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle10.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle10.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle11 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1923636234723287351826");
			namedStyle11.CellType = textCellType4;
			namedStyle11.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle11.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle11.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle11.Renderer = textCellType4;
			namedStyle11.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle12 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1981636234723287361591");
			namedStyle12.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle12.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle12.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle13 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2312636234723287605716");
			namedStyle13.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle13.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle13.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle13.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle14 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2346636234723287635011");
			namedStyle14.CellType = textCellType5;
			namedStyle14.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle14.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle14.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle14.Renderer = textCellType5;
			namedStyle14.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle15 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2395636234723287664306");
			namedStyle15.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle15.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle15.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle15.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle16 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2429636234723287703366");
			namedStyle16.CellType = textCellType6;
			namedStyle16.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle16.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle16.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle16.Renderer = textCellType6;
			namedStyle16.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle17 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2509636234723287761956");
			namedStyle17.CellType = textCellType7;
			namedStyle17.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle17.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle17.Renderer = textCellType7;
			namedStyle17.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle18 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2491636234723287732661");
			namedStyle18.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle18.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle18.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle18.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle19 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2581636234723287830311");
			namedStyle19.CellType = textCellType8;
			namedStyle19.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle19.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle19.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle19.Renderer = textCellType8;
			namedStyle19.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle20 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2638636234723287840076");
			namedStyle20.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle20.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle20.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle21 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2995636234723288172086");
			namedStyle21.CellType = textCellType9;
			namedStyle21.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle21.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle21.Renderer = textCellType9;
			namedStyle21.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle22 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font3033636234723288191616");
			namedStyle22.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle22.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle22.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle22.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle23 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3051636234723288211146");
			namedStyle23.CellType = textCellType10;
			namedStyle23.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle23.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle23.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle23.Renderer = textCellType10;
			namedStyle23.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle24 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font3939636234723288992346");
			namedStyle24.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle24.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle24.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle24.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle25 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3957636234723289021641");
			namedStyle25.CellType = textCellType11;
			namedStyle25.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle25.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle25.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle25.Renderer = textCellType11;
			namedStyle25.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle26 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3991636234723289089996");
			namedStyle26.CellType = textCellType12;
			namedStyle26.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle26.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle26.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle26.Renderer = textCellType12;
			namedStyle26.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle27 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3129636234723304762821");
			namedStyle27.CellType = textCellType13;
			namedStyle27.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle27.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle27.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle27.Renderer = textCellType13;
			namedStyle27.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle28 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3427636234723305241306");
			namedStyle28.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle28.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle28.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle29 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3571636234723305436606");
			namedStyle29.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle29.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle29.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle30 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3824636234723305924856");
			namedStyle30.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle30.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle30.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle30.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle31 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3858636234723305993211");
			namedStyle31.CellType = textCellType14;
			namedStyle31.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle31.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle31.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle31.Renderer = textCellType14;
			namedStyle31.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle32 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3930636234723306110391");
			namedStyle32.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle32.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle32.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle32.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle33 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3964636234723306168981");
			namedStyle33.CellType = textCellType15;
			namedStyle33.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle33.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle33.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle33.Renderer = textCellType15;
			namedStyle33.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle34 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx90636234723306588876");
			namedStyle34.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle34.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle34.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle35 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx196636234723306764646");
			namedStyle35.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle35.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle35.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle36 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx808636234723307916916");
			namedStyle36.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle36.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle36.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle36.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle37 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static842636234723307985271");
			namedStyle37.CellType = textCellType16;
			namedStyle37.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle37.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle37.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle37.Renderer = textCellType16;
			namedStyle37.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle38 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx902636234723308063391");
			namedStyle38.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle38.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle38.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle38.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle39 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static936636234723308141511");
			namedStyle39.CellType = textCellType17;
			namedStyle39.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle39.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle39.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle39.Renderer = textCellType17;
			namedStyle39.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle40 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx993636234723308170806");
			namedStyle40.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle40.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle40.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle40.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle41 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1027636234723308229396");
			namedStyle41.CellType = textCellType18;
			namedStyle41.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle41.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle41.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle41.Renderer = textCellType18;
			namedStyle41.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle42 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1270636234723308590701");
			namedStyle42.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle42.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle42.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle43 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2977636234723288152556");
			namedStyle43.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle43.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle43.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle43.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle44 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1448636234723308893416");
			namedStyle44.CellType = textCellType19;
			namedStyle44.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle44.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle44.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle44.Renderer = textCellType19;
			namedStyle44.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			this.Name = "PTSProject.frmIndivReport";
			IsMdiChild = true;
			cboYear.Items.Add("1998");
			cboYear.Items.Add("1999");
			cboYear.Items.Add("2000");
			cboYear.Items.Add("2001");
			cboYear.Items.Add("2002");
			cboYear.Items.Add("2003");
			cboYear.Items.Add("2004");
			cboYear.Items.Add("2005");
			this.sprIndiv.NamedStyles.Add(namedStyle1);
			this.sprIndiv.NamedStyles.Add(namedStyle2);
			this.sprIndiv.NamedStyles.Add(namedStyle3);
			this.sprIndiv.NamedStyles.Add(namedStyle4);
			this.sprIndiv.NamedStyles.Add(namedStyle5);
			this.sprIndiv.NamedStyles.Add(namedStyle6);
			this.sprIndiv.NamedStyles.Add(namedStyle7);
			this.sprIndiv.NamedStyles.Add(namedStyle8);
			this.sprIndiv.NamedStyles.Add(namedStyle9);
			this.sprIndiv.NamedStyles.Add(namedStyle10);
			this.sprIndiv.NamedStyles.Add(namedStyle11);
			this.sprIndiv.NamedStyles.Add(namedStyle12);
			this.sprIndiv.NamedStyles.Add(namedStyle13);
			this.sprIndiv.NamedStyles.Add(namedStyle14);
			this.sprIndiv.NamedStyles.Add(namedStyle15);
			this.sprIndiv.NamedStyles.Add(namedStyle16);
			this.sprIndiv.NamedStyles.Add(namedStyle17);
			this.sprIndiv.NamedStyles.Add(namedStyle18);
			this.sprIndiv.NamedStyles.Add(namedStyle19);
			this.sprIndiv.NamedStyles.Add(namedStyle20);
			this.sprIndiv.NamedStyles.Add(namedStyle21);
			this.sprIndiv.NamedStyles.Add(namedStyle22);
			this.sprIndiv.NamedStyles.Add(namedStyle23);
			this.sprIndiv.NamedStyles.Add(namedStyle24);
			this.sprIndiv.NamedStyles.Add(namedStyle25);
			this.sprIndiv.NamedStyles.Add(namedStyle26);
			this.sprIndiv.NamedStyles.Add(namedStyle27);
			this.sprIndiv.NamedStyles.Add(namedStyle28);
			this.sprIndiv.NamedStyles.Add(namedStyle29);
			this.sprIndiv.NamedStyles.Add(namedStyle30);
			this.sprIndiv.NamedStyles.Add(namedStyle31);
			this.sprIndiv.NamedStyles.Add(namedStyle32);
			this.sprIndiv.NamedStyles.Add(namedStyle33);
			this.sprIndiv.NamedStyles.Add(namedStyle34);
			this.sprIndiv.NamedStyles.Add(namedStyle35);
			this.sprIndiv.NamedStyles.Add(namedStyle36);
			this.sprIndiv.NamedStyles.Add(namedStyle37);
			this.sprIndiv.NamedStyles.Add(namedStyle38);
			this.sprIndiv.NamedStyles.Add(namedStyle39);
			this.sprIndiv.NamedStyles.Add(namedStyle40);
			this.sprIndiv.NamedStyles.Add(namedStyle41);
			this.sprIndiv.NamedStyles.Add(namedStyle42);
			this.sprIndiv.NamedStyles.Add(namedStyle43);
			this.sprIndiv.NamedStyles.Add(namedStyle44);
			this.sprIndiv.Sheets.Add(this.sprIndiv_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprIndiv { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboYear { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboNameList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprIndiv_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkInactive { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 LastRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 ReportYear { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean bUseNewMILMAX { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean bBothMILMAX { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}