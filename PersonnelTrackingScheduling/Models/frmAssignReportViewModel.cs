using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmAssignReport))]
	public class frmAssignReportViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType11 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle25;
			FarPoint.ViewModels.NamedStyle namedStyle24;
			FarPoint.ViewModels.NamedStyle namedStyle23;
			var textCellType10 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle22;
			FarPoint.ViewModels.NamedStyle namedStyle21;
			FarPoint.ViewModels.NamedStyle namedStyle20;
			var textCellType9 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle19;
			FarPoint.ViewModels.NamedStyle namedStyle18;
			var textCellType8 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle17;
			FarPoint.ViewModels.NamedStyle namedStyle16;
			FarPoint.ViewModels.NamedStyle namedStyle15;
			FarPoint.ViewModels.NamedStyle namedStyle14;
			FarPoint.ViewModels.NamedStyle namedStyle13;
			var textCellType7 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle12;
			FarPoint.ViewModels.NamedStyle namedStyle11;
			FarPoint.ViewModels.NamedStyle namedStyle10;
			var textCellType6 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle9;
			FarPoint.ViewModels.NamedStyle namedStyle8;
			var textCellType5 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle7;
			var textCellType4 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle6;
			var textCellType3 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle5;
			var textCellType2 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle4;
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.sprAssign = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprAssign.MaxRows = 400;
			this.sprAssign.TabIndex = 2;
            this.sprAssign.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprAssign_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprAssign_Sheet1.SheetName = "Sheet1";
            this.sprAssign_Sheet1.HideCellBorders = true;//Hide Cell Borders
            this.sprAssign_Sheet1.Cells.Get(0, 0).Value = "Tacoma Fire Department";
            this.sprAssign_Sheet1.Cells.Get(0, 0).Font.Bold = true;
            this.sprAssign_Sheet1.Cells.Get(0, 0).Font.Size = 14;
            this.sprAssign_Sheet1.Cells.Get(1, 0).Value = "Assignment Report";
            this.sprAssign_Sheet1.Cells.Get(1, 0).Font.Size = 14;
            this.sprAssign_Sheet1.Cells.Get(1, 0).Font.Bold = true;
            this.sprAssign_Sheet1.Cells.Get(2, 0).Value = "Unit";
			this.sprAssign_Sheet1.Cells.Get(2, 1).Value = "Position";
			this.sprAssign_Sheet1.Cells.Get(2, 2).Value = "Debit Group";
			this.sprAssign_Sheet1.Cells.Get(2, 3).Value = "House Fund";
			this.sprAssign_Sheet1.Cells.Get(2, 4).Value = "A Shift";
			this.sprAssign_Sheet1.Cells.Get(2, 5).Value = "B Shift";
			this.sprAssign_Sheet1.Cells.Get(2, 6).Value = "C Shift";
			this.sprAssign_Sheet1.Cells.Get(2, 7).Value = "D Shift";
			//this.sprAssign_Sheet1.ColumnHeader.Rows.Get(0).Height = 0F;
			this.sprAssign_Sheet1.Columns.Get(0).Width = 160F;
			this.sprAssign_Sheet1.Columns.Get(1).Width = 71F;
			this.sprAssign_Sheet1.Columns.Get(2).StyleName = "Static932636234682956978636";
			this.sprAssign_Sheet1.Columns.Get(2).Width = 100F;
			this.sprAssign_Sheet1.Columns.Get(3).StyleName = "Static991636234682956978636";
			this.sprAssign_Sheet1.Columns.Get(3).Width = 120F;
			this.sprAssign_Sheet1.Columns.Get(4).StyleName = "Static1050636234682956988401";
			this.sprAssign_Sheet1.Columns.Get(4).Width = 160F;
			this.sprAssign_Sheet1.Columns.Get(5).StyleName = "Static1125636234682956998166";
			this.sprAssign_Sheet1.Columns.Get(5).Width = 160F;
			this.sprAssign_Sheet1.Columns.Get(6).StyleName = "Static1050636234682956988401";
			this.sprAssign_Sheet1.Columns.Get(6).Width = 160F;
			this.sprAssign_Sheet1.Columns.Get(7).StyleName = "Static1050636234682956988401";
			this.sprAssign_Sheet1.Columns.Get(7).Width = 160F;
            //TODO: Check this
            //this.sprAssign_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
            this.sprAssign_Sheet1.Rows.Get(2).Height = 19F;
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 1;
			this.cmdClose.Text = "&Close";
			this.cmdPrint = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrint.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrint.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.TabIndex = 0;
			this.cmdPrint.Text = "&Print";
			this.Text = "Assignment Report";
			this.CurrRow = 0;
			this.PageCountRow = 0;
			this.MaxRow = 0;
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color65636234682956705216", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text495636234682956959106", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font873636234682956968871");
			namedStyle3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static932636234682956978636");
			namedStyle4.CellType = textCellType2;
			namedStyle4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.Renderer = textCellType2;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static991636234682956978636");
			namedStyle5.CellType = textCellType3;
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.Renderer = textCellType3;
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1050636234682956988401");
			namedStyle6.CellType = textCellType4;
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.Renderer = textCellType4;
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle7 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1125636234682956998166");
			namedStyle7.CellType = textCellType5;
			namedStyle7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle7.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle7.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle7.Renderer = textCellType5;
			namedStyle7.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle8 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font1335636234682957037226");
			namedStyle8.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle8.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle8.Locked = false;
			namedStyle8.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle8.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle9 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1368636234682957056756");
			namedStyle9.CellType = textCellType6;
			namedStyle9.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle9.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle9.Locked = false;
			namedStyle9.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle9.Renderer = textCellType6;
			namedStyle9.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle10 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Style1");
			namedStyle10.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle10.Locked = false;
			namedStyle10.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle10.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle11 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font1511636234682957125111");
			namedStyle11.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle11.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle11.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle11.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle12 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1770636234682957232526");
			namedStyle12.CellType = textCellType7;
			namedStyle12.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle12.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle12.Renderer = textCellType7;
			namedStyle12.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle13 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1808636234682957252056");
			namedStyle13.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle13.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F);
			namedStyle13.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle13.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle13.Locked = false;
			namedStyle13.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle13.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle14 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1918636234682957291116");
			namedStyle14.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle14.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F);
			namedStyle14.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle14.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle14.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle14.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle15 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2032636234682957339941");
			namedStyle15.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle15.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle15.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle15.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle15.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle16 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2149636234682957379001");
			namedStyle16.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle16.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle16.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle17 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2336636234682957486416");
			namedStyle17.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle17.CellType = textCellType8;
			namedStyle17.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F);
			namedStyle17.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle17.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle17.Locked = false;
			namedStyle17.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle17.Renderer = textCellType8;
			namedStyle17.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle18 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font2814636234682957798896");
			namedStyle18.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F);
			namedStyle18.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle18.Locked = false;
			namedStyle18.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle18.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle19 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2847636234682957837956");
			namedStyle19.CellType = textCellType9;
			namedStyle19.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F);
			namedStyle19.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle19.Locked = false;
			namedStyle19.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle19.Renderer = textCellType9;
			namedStyle19.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle20 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font2863636234682957847721");
			namedStyle20.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F);
			namedStyle20.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle20.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle20.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle21 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color3223636234682958257851");
			namedStyle21.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle21.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F);
			namedStyle21.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle21.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle21.Locked = false;
			namedStyle21.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle21.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle22 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3272636234682958306676");
			namedStyle22.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle22.CellType = textCellType10;
			namedStyle22.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F);
			namedStyle22.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle22.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle22.Locked = false;
			namedStyle22.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle22.Renderer = textCellType10;
			namedStyle22.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle23 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color3294636234682958316441");
			namedStyle23.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle23.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F);
			namedStyle23.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle23.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle23.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle23.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle24 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color3365636234682958384796");
			namedStyle24.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle24.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle24.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle24.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle24.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle25 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2247636234683070701826");
			namedStyle25.CellType = textCellType11;
			namedStyle25.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F);
			namedStyle25.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle25.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle25.Renderer = textCellType11;
			namedStyle25.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			this.Name = "PTSProject.frmAssignReport";
			IsMdiChild = true;
			this.sprAssign.NamedStyles.Add(namedStyle1);
			this.sprAssign.NamedStyles.Add(namedStyle2);
			this.sprAssign.NamedStyles.Add(namedStyle3);
			this.sprAssign.NamedStyles.Add(namedStyle4);
			this.sprAssign.NamedStyles.Add(namedStyle5);
			this.sprAssign.NamedStyles.Add(namedStyle6);
			this.sprAssign.NamedStyles.Add(namedStyle7);
			this.sprAssign.NamedStyles.Add(namedStyle8);
			this.sprAssign.NamedStyles.Add(namedStyle9);
			this.sprAssign.NamedStyles.Add(namedStyle10);
			this.sprAssign.NamedStyles.Add(namedStyle11);
			this.sprAssign.NamedStyles.Add(namedStyle12);
			this.sprAssign.NamedStyles.Add(namedStyle13);
			this.sprAssign.NamedStyles.Add(namedStyle14);
			this.sprAssign.NamedStyles.Add(namedStyle15);
			this.sprAssign.NamedStyles.Add(namedStyle16);
			this.sprAssign.NamedStyles.Add(namedStyle17);
			this.sprAssign.NamedStyles.Add(namedStyle18);
			this.sprAssign.NamedStyles.Add(namedStyle19);
			this.sprAssign.NamedStyles.Add(namedStyle20);
			this.sprAssign.NamedStyles.Add(namedStyle21);
			this.sprAssign.NamedStyles.Add(namedStyle22);
			this.sprAssign.NamedStyles.Add(namedStyle23);
			this.sprAssign.NamedStyles.Add(namedStyle24);
			this.sprAssign.NamedStyles.Add(namedStyle25);
			this.sprAssign.Sheets.Add(this.sprAssign_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprAssign { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprAssign_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 PageCountRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 MaxRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}