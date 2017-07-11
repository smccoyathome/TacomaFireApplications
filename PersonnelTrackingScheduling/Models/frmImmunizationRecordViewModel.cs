using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmImmunizationRecord))]
	public class frmImmunizationRecordViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType9 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle25;
			var textCellType8 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle24;
			FarPoint.ViewModels.NamedStyle namedStyle23;
			FarPoint.ViewModels.NamedStyle namedStyle22;
			var textCellType7 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle21;
			var textCellType6 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle20;
			var textCellType5 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle19;
			FarPoint.ViewModels.NamedStyle namedStyle18;
			var emptyCellType8 = ctx.Resolve<FarPoint.ViewModels.EmptyCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle17;
			var emptyCellType7 = ctx.Resolve<FarPoint.ViewModels.EmptyCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle16;
			FarPoint.ViewModels.NamedStyle namedStyle15;
			var emptyCellType6 = ctx.Resolve<FarPoint.ViewModels.EmptyCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle14;
			var emptyCellType5 = ctx.Resolve<FarPoint.ViewModels.EmptyCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle13;
			var emptyCellType4 = ctx.Resolve<FarPoint.ViewModels.EmptyCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle12;
			var emptyCellType3 = ctx.Resolve<FarPoint.ViewModels.EmptyCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle11;
			var emptyCellType2 = ctx.Resolve<FarPoint.ViewModels.EmptyCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle10;
			var emptyCellType1 = ctx.Resolve<FarPoint.ViewModels.EmptyCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle9;
			var textCellType4 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
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
			this.cboEmpList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboEmpList
			// 
			this.cboEmpList.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboEmpList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboEmpList.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboEmpList.Name = "cboEmpList";
			this.cboEmpList.TabIndex = 0;
			this.cboEmpList.Text = "cboEmpList";
			this.sprReport = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprReport.MaxRows = 40;
			this.sprReport.TabIndex = 5;
			this.sprReport.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 2;
			this.Label1.Text = "Select Employee";
			this.lbEmpID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEmpID
			// 
			this.lbEmpID.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbEmpID.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbEmpID.Name = "lbEmpID";
			this.lbEmpID.TabIndex = 1;
			this.lbEmpID.Text = "lbEmpID";
			this.lbEmpID.Visible = false;
			this.sprReport_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprReport_Sheet1.SheetName = "Sheet1";
            //ColumnSpan is OBSOLETE
            //this.sprReport_Sheet1.Cells.Get(0, 0).ColumnSpan = 12;
            this.sprReport_Sheet1.Cells.Get(0, 0).Value = "TACOMA FIRE DEPARTMENT";
			this.sprReport_Sheet1.Cells.Get(0, 1).Value = "TACOMA FIRE DEPARTMENT";
			this.sprReport_Sheet1.Cells.Get(0, 2).Value = "TACOMA FIRE DEPARTMENT";
			this.sprReport_Sheet1.Cells.Get(0, 3).Value = "TACOMA FIRE DEPARTMENT";
			this.sprReport_Sheet1.Cells.Get(0, 4).Value = "TACOMA FIRE DEPARTMENT";
			this.sprReport_Sheet1.Cells.Get(0, 5).Value = "TACOMA FIRE DEPARTMENT";
			this.sprReport_Sheet1.Cells.Get(0, 6).Value = "TACOMA FIRE DEPARTMENT";
			this.sprReport_Sheet1.Cells.Get(0, 7).Value = "TACOMA FIRE DEPARTMENT";
			this.sprReport_Sheet1.Cells.Get(0, 8).Value = "TACOMA FIRE DEPARTMENT";
			this.sprReport_Sheet1.Cells.Get(0, 9).Value = "TACOMA FIRE DEPARTMENT";
			this.sprReport_Sheet1.Cells.Get(0, 10).Value = "TACOMA FIRE DEPARTMENT";
			this.sprReport_Sheet1.Cells.Get(0, 11).Value = "TACOMA FIRE DEPARTMENT";
            //ColumnSpan is OBSOLETE
            //this.sprReport_Sheet1.Cells.Get(1, 0).ColumnSpan = 12;
			this.sprReport_Sheet1.Cells.Get(1, 0).Value = "Individual Immunization Record";
			this.sprReport_Sheet1.Cells.Get(1, 1).Value = "Individual Immunization Record";
			this.sprReport_Sheet1.Cells.Get(1, 2).Value = "Individual Immunization Record";
			this.sprReport_Sheet1.Cells.Get(1, 3).Value = "Individual Immunization Record";
			this.sprReport_Sheet1.Cells.Get(1, 4).Value = "Individual Immunization Record";
			this.sprReport_Sheet1.Cells.Get(1, 5).Value = "Individual Immunization Record";
			this.sprReport_Sheet1.Cells.Get(1, 6).Value = "Individual Immunization Record";
			this.sprReport_Sheet1.Cells.Get(1, 7).Value = "Individual Immunization Record";
			this.sprReport_Sheet1.Cells.Get(1, 8).Value = "Individual Immunization Record";
			this.sprReport_Sheet1.Cells.Get(1, 9).Value = "Individual Immunization Record";
			this.sprReport_Sheet1.Cells.Get(1, 10).Value = "Individual Immunization Record";
			this.sprReport_Sheet1.Cells.Get(1, 11).Value = "Individual Immunization Record";
            //ColumnSpan & RowSpan are OBSOLETE
            //this.sprReport_Sheet1.Cells.Get(2, 5).ColumnSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(2, 5).RowSpan = 3;
			this.sprReport_Sheet1.Cells.Get(7, 0).Value = "NAME:";
			//this.sprReport_Sheet1.Cells.Get(7, 1).ColumnSpan = 5;
			//this.sprReport_Sheet1.Cells.Get(7, 6).ColumnSpan = 2;
			this.sprReport_Sheet1.Cells.Get(7, 6).Value = "DATE OF HIRE:";
			//this.sprReport_Sheet1.Cells.Get(7, 8).ColumnSpan = 4;
			//this.sprReport_Sheet1.Cells.Get(11, 0).ColumnSpan = 2;
			this.sprReport_Sheet1.Cells.Get(11, 0).Value = "Hep B Series:";
			this.sprReport_Sheet1.Cells.Get(11, 1).Value = "Hep B Series:";
			this.sprReport_Sheet1.Cells.Get(13, 0).Value = "#1:";
			//this.sprReport_Sheet1.Cells.Get(13, 1).ColumnSpan = 2;
			this.sprReport_Sheet1.Cells.Get(13, 1).Value = "_____________";
			this.sprReport_Sheet1.Cells.Get(13, 2).Value = "____________";
			this.sprReport_Sheet1.Cells.Get(13, 3).Value = "#2:";
			//this.sprReport_Sheet1.Cells.Get(13, 4).ColumnSpan = 2;
			this.sprReport_Sheet1.Cells.Get(13, 4).Value = "_____________";
			this.sprReport_Sheet1.Cells.Get(13, 6).Value = "#3:";
			//this.sprReport_Sheet1.Cells.Get(13, 7).ColumnSpan = 2;
			this.sprReport_Sheet1.Cells.Get(13, 7).Value = "_____________";
			this.sprReport_Sheet1.Cells.Get(13, 9).Value = "Titre:";
            //ColumnSpan is OBSOLETE
            //this.sprReport_Sheet1.Cells.Get(13, 10).ColumnSpan = 2;
			this.sprReport_Sheet1.Cells.Get(13, 10).Value = "_____________";
			this.sprReport_Sheet1.Cells.Get(16, 0).Value = "#4:";
			//this.sprReport_Sheet1.Cells.Get(16, 1).ColumnSpan = 2;
			this.sprReport_Sheet1.Cells.Get(16, 1).Value = "_____________";
			this.sprReport_Sheet1.Cells.Get(16, 3).Value = "#5:";
			//this.sprReport_Sheet1.Cells.Get(16, 4).ColumnSpan = 2;
			this.sprReport_Sheet1.Cells.Get(16, 4).Value = "_____________";
			this.sprReport_Sheet1.Cells.Get(16, 6).Value = "#6:";
			//this.sprReport_Sheet1.Cells.Get(16, 7).ColumnSpan = 2;
			this.sprReport_Sheet1.Cells.Get(16, 7).Value = "_____________";
			this.sprReport_Sheet1.Cells.Get(16, 9).Value = "Titre:";
			//this.sprReport_Sheet1.Cells.Get(16, 10).ColumnSpan = 2;
			this.sprReport_Sheet1.Cells.Get(16, 10).Value = "_____________";
			//this.sprReport_Sheet1.Cells.Get(20, 0).ColumnSpan = 2;
			this.sprReport_Sheet1.Cells.Get(20, 0).Value = "Hep A Series:";
			this.sprReport_Sheet1.Cells.Get(20, 1).Value = "Hep A Series:";
			this.sprReport_Sheet1.Cells.Get(20, 3).Value = "#1:";
            //ColumnSpan is OBSOLETE
            //this.sprReport_Sheet1.Cells.Get(20, 4).ColumnSpan = 2;
			this.sprReport_Sheet1.Cells.Get(20, 4).Value = "_____________";
			this.sprReport_Sheet1.Cells.Get(20, 6).Value = "#2:";
			//this.sprReport_Sheet1.Cells.Get(20, 7).ColumnSpan = 2;
			this.sprReport_Sheet1.Cells.Get(20, 7).Value = "_____________";
			this.sprReport_Sheet1.Cells.Get(20, 9).Value = "Titre:";
			//this.sprReport_Sheet1.Cells.Get(20, 10).ColumnSpan = 2;
			this.sprReport_Sheet1.Cells.Get(20, 10).Value = "_____________";
			//this.sprReport_Sheet1.Cells.Get(24, 0).ColumnSpan = 3;
			this.sprReport_Sheet1.Cells.Get(24, 0).Value = "Varicella: _____________";
			this.sprReport_Sheet1.Cells.Get(24, 1).Value = "Varicella:";
			this.sprReport_Sheet1.Cells.Get(24, 3).Value = "MMR:";
			//this.sprReport_Sheet1.Cells.Get(24, 4).ColumnSpan = 2;
			this.sprReport_Sheet1.Cells.Get(24, 4).Value = "_____________";
			this.sprReport_Sheet1.Cells.Get(24, 6).Value = "TDP:";
			//this.sprReport_Sheet1.Cells.Get(24, 7).ColumnSpan = 2;
			this.sprReport_Sheet1.Cells.Get(24, 7).Value = "_____________";
			this.sprReport_Sheet1.Cells.Get(24, 9).Value = "PNEU:";
			//this.sprReport_Sheet1.Cells.Get(24, 10).ColumnSpan = 2;
			this.sprReport_Sheet1.Cells.Get(24, 10).Value = "_____________";
			this.sprReport_Sheet1.Cells.Get(24, 11).Value = "_____________";
			//this.sprReport_Sheet1.Cells.Get(28, 0).ColumnSpan = 3;
			this.sprReport_Sheet1.Cells.Get(28, 0).Value = "Tetanus:  _____________";
			this.sprReport_Sheet1.Cells.Get(28, 1).Value = "Tetanus:";
			this.sprReport_Sheet1.Cells.Get(28, 3).Value = "FLU:";
			//this.sprReport_Sheet1.Cells.Get(28, 4).ColumnSpan = 2;
			this.sprReport_Sheet1.Cells.Get(28, 4).Value = "_____________";
			this.sprReport_Sheet1.Cells.Get(28, 5).Value = "_____________";
			this.sprReport_Sheet1.Cells.Get(28, 6).Value = "TB:";
			//this.sprReport_Sheet1.Cells.Get(28, 7).ColumnSpan = 2;
			this.sprReport_Sheet1.Cells.Get(28, 7).Value = "_____________";
			this.sprReport_Sheet1.ColumnHeader.Rows.Get(0).Height = 0F;
			this.sprReport_Sheet1.Columns.Get(0).Width = 58F;
			this.sprReport_Sheet1.Columns.Get(1).Width = 58F;
			this.sprReport_Sheet1.Columns.Get(2).Width = 58F;
			this.sprReport_Sheet1.Columns.Get(3).Width = 58F;
			this.sprReport_Sheet1.Columns.Get(4).Width = 58F;
			this.sprReport_Sheet1.Columns.Get(5).Width = 58F;
			this.sprReport_Sheet1.Columns.Get(6).Width = 58F;
			this.sprReport_Sheet1.Columns.Get(7).Width = 58F;
			this.sprReport_Sheet1.Columns.Get(8).Width = 58F;
			this.sprReport_Sheet1.Columns.Get(9).Width = 58F;
			this.sprReport_Sheet1.Columns.Get(10).Width = 58F;
			this.sprReport_Sheet1.Columns.Get(11).Width = 58F;
			this.sprReport_Sheet1.Columns.Get(12).Width = 22F;
			this.sprReport_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprReport_Sheet1.Rows.Get(0).Height = 68F;
			this.sprReport_Sheet1.Rows.Get(2).Height = 31F;
			this.sprReport_Sheet1.Rows.Get(3).Height = 31F;
			this.sprReport_Sheet1.Rows.Get(4).Height = 31F;
			this.cmbClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmbClose
			// 
			this.cmbClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmbClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmbClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmbClose.Name = "cmbClose";
			this.cmbClose.TabIndex = 4;
			this.cmbClose.Text = "Close";
			this.cmdPrint = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrint.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrint.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.TabIndex = 3;
			this.cmdPrint.Text = "Print Report";
			this.Text = "TFD Employee Immunization Record";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx58636234720137778021", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text507636234720137797551", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color1864636234720137846376");
			namedStyle3.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1898636234720137885436");
			namedStyle4.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle4.CellType = textCellType2;
			namedStyle4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.Renderer = textCellType2;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Bottom;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color1957636234720137904966");
			namedStyle5.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle5.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2976636234720138227211");
			namedStyle6.CellType = textCellType3;
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.Renderer = textCellType3;
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Bottom;
			namedStyle7 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font2992636234720138246741");
			namedStyle7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle7.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle7.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle7.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle8 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3021636234720138256506");
			namedStyle8.CellType = textCellType4;
			namedStyle8.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle8.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle8.Renderer = textCellType4;
			namedStyle8.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle9 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Empty323294636234720138998646");
			namedStyle9.CellType = emptyCellType1;
			namedStyle9.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle9.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle9.Renderer = emptyCellType1;
			namedStyle9.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle10 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Empty323294636234720139740786");
			namedStyle10.CellType = emptyCellType2;
			namedStyle10.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle10.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle10.Renderer = emptyCellType2;
			namedStyle10.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle11 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Empty323294636234720140434101");
			namedStyle11.CellType = emptyCellType3;
			namedStyle11.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle11.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle11.Renderer = emptyCellType3;
			namedStyle11.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle12 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Empty323294636234720141264126");
			namedStyle12.CellType = emptyCellType4;
			namedStyle12.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle12.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle12.Renderer = emptyCellType4;
			namedStyle12.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle13 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Empty323294636234720142016031");
			namedStyle13.CellType = emptyCellType5;
			namedStyle13.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle13.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle13.Renderer = emptyCellType5;
			namedStyle13.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle14 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Empty323294636234720142777701");
			namedStyle14.CellType = emptyCellType6;
			namedStyle14.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle14.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle14.Renderer = emptyCellType6;
			namedStyle14.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle15 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font45636234720142787466");
			namedStyle15.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle15.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle15.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle15.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle16 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Empty323294636234720143529606");
			namedStyle16.CellType = emptyCellType7;
			namedStyle16.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle16.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle16.Renderer = emptyCellType7;
			namedStyle16.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle17 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Empty323294636234720144222921");
			namedStyle17.CellType = emptyCellType8;
			namedStyle17.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle17.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle17.Renderer = emptyCellType8;
			namedStyle17.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle18 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font16636234720144242451");
			namedStyle18.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle18.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle18.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle18.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle19 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static45636234720144252216");
			namedStyle19.CellType = textCellType5;
			namedStyle19.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Right;
			namedStyle19.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle19.Renderer = textCellType5;
			namedStyle19.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle20 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static99636234720144281511");
			namedStyle20.CellType = textCellType6;
			namedStyle20.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle20.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle20.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle20.Renderer = textCellType6;
			namedStyle20.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Bottom;
			namedStyle21 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static181636234720144320571");
			namedStyle21.CellType = textCellType7;
			namedStyle21.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle21.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Right;
			namedStyle21.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle21.Renderer = textCellType7;
			namedStyle21.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle22 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font372636234720144359631");
			namedStyle22.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F);
			namedStyle22.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle22.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle22.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle23 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font491636234720144379161");
			namedStyle23.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F);
			namedStyle23.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle23.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle23.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle24 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static583636234720144398691");
			namedStyle24.CellType = textCellType8;
			namedStyle24.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle24.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle24.Renderer = textCellType8;
			namedStyle24.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Bottom;
			namedStyle25 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static629636234720144408456");
			namedStyle25.CellType = textCellType9;
			namedStyle25.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle25.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle25.Renderer = textCellType9;
			namedStyle25.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			this.Name = "PTSProject.frmImmunizationRecord";
			IsMdiChild = true;
			this.sprReport.NamedStyles.Add(namedStyle1);
			this.sprReport.NamedStyles.Add(namedStyle2);
			this.sprReport.NamedStyles.Add(namedStyle3);
			this.sprReport.NamedStyles.Add(namedStyle4);
			this.sprReport.NamedStyles.Add(namedStyle5);
			this.sprReport.NamedStyles.Add(namedStyle6);
			this.sprReport.NamedStyles.Add(namedStyle7);
			this.sprReport.NamedStyles.Add(namedStyle8);
			this.sprReport.NamedStyles.Add(namedStyle9);
			this.sprReport.NamedStyles.Add(namedStyle10);
			this.sprReport.NamedStyles.Add(namedStyle11);
			this.sprReport.NamedStyles.Add(namedStyle12);
			this.sprReport.NamedStyles.Add(namedStyle13);
			this.sprReport.NamedStyles.Add(namedStyle14);
			this.sprReport.NamedStyles.Add(namedStyle15);
			this.sprReport.NamedStyles.Add(namedStyle16);
			this.sprReport.NamedStyles.Add(namedStyle17);
			this.sprReport.NamedStyles.Add(namedStyle18);
			this.sprReport.NamedStyles.Add(namedStyle19);
			this.sprReport.NamedStyles.Add(namedStyle20);
			this.sprReport.NamedStyles.Add(namedStyle21);
			this.sprReport.NamedStyles.Add(namedStyle22);
			this.sprReport.NamedStyles.Add(namedStyle23);
			this.sprReport.NamedStyles.Add(namedStyle24);
			this.sprReport.NamedStyles.Add(namedStyle25);
			this.sprReport.Sheets.Add(this.sprReport_Sheet1);
		}

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboEmpList { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEmpID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprReport_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmbClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}