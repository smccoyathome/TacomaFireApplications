using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmIndALSProcReport))]
	public class frmIndALSProcReportViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			FarPoint.ViewModels.NamedStyle namedStyle19;
			var textCellType9 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle18;
			FarPoint.ViewModels.NamedStyle namedStyle17;
			var textCellType8 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle16;
			FarPoint.ViewModels.NamedStyle namedStyle15;
			var textCellType7 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle14;
			FarPoint.ViewModels.NamedStyle namedStyle13;
			var textCellType6 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle12;
			var textCellType5 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
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
			this.cboEmployee = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboEmployee
			// 
			this.cboEmployee.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboEmployee.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboEmployee.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboEmployee.Name = "cboEmployee";
			this.cboEmployee.TabIndex = 4;
			this.dtStart = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dtStart.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.dtStart.MinDate = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
			this.dtStart.Name = "dtStart";
			this.dtStart.TabIndex = 5;
			this.dtEnd = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dtEnd.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.dtEnd.MinDate = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
			this.dtEnd.Name = "dtEnd";
			this.dtEnd.TabIndex = 6;
			this._Label3_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 9;
			this.Label1.Text = "Select Employee:";
			this.lbEmpName = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEmpName
			// 
			this.lbEmpName.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbEmpName.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbEmpName.Name = "lbEmpName";
			this.lbEmpName.TabIndex = 8;
			this.lbEmpName.Visible = false;
			this._Label3_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.sprReport = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprReport.MaxRows = 600;
			this.sprReport.TabIndex = 0;
			this.sprReport.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprReport_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprReport_Sheet1.SheetName = "Sheet1";
            //ColumnSpan is OBSOLETE
            //this.sprReport_Sheet1.Cells.Get(0, 0).ColumnSpan = 4;
			this.sprReport_Sheet1.Cells.Get(0, 0).Value = "Tacoma Fire Department ";
			this.sprReport_Sheet1.Cells.Get(0, 1).Value = "Tacoma Fire Department ";
			this.sprReport_Sheet1.Cells.Get(0, 2).Value = "Tacoma Fire Department ";
			this.sprReport_Sheet1.Cells.Get(0, 3).Value = "Tacoma Fire Department ";
			//this.sprReport_Sheet1.Cells.Get(1, 0).ColumnSpan = 4;
			this.sprReport_Sheet1.Cells.Get(1, 0).Value = "Paramedic Recertification Report";
			this.sprReport_Sheet1.Cells.Get(1, 1).Value = "Paramedic Recertification Training Classes";
			this.sprReport_Sheet1.Cells.Get(1, 2).Value = "Paramedic Recertification Training Classes";
			this.sprReport_Sheet1.Cells.Get(1, 3).Value = "Paramedic Recertification Training Classes";
			//this.sprReport_Sheet1.Cells.Get(2, 0).ColumnSpan = 5;
			//this.sprReport_Sheet1.Cells.Get(3, 0).ColumnSpan = 5;
			//this.sprReport_Sheet1.Cells.Get(4, 0).ColumnSpan = 5;
			this.sprReport_Sheet1.Cells.Get(5, 0).Value = "ALS Procedures (IRS)";
			this.sprReport_Sheet1.ColumnHeader.Rows.Get(0).Height = 0F;
			this.sprReport_Sheet1.Columns.Get(0).Width = 452F;
			this.sprReport_Sheet1.Columns.Get(1).Width = 10F;
			this.sprReport_Sheet1.Columns.Get(2).Width = 127F;
			this.sprReport_Sheet1.Columns.Get(3).Width = 89F;
			this.sprReport_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprReport_Sheet1.Rows.Get(1).Height = 19F;
			this.sprReport_Sheet1.Rows.Get(2).Height = 31F;
			this.sprReport_Sheet1.Rows.Get(3).Height = 19F;
			this.sprReport_Sheet1.Rows.Get(4).Height = 19F;
			this.sprReport_Sheet1.Rows.Get(5).Height = 18F;
			this.cmdPrint = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrint.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrint.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.TabIndex = 3;
			this.cmdPrint.Text = "&Print";
			this.cmdExit = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdExit
			// 
			this.cmdExit.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdExit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdExit.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdExit.Name = "cmdExit";
			this.cmdExit.TabIndex = 2;
			this.cmdExit.Text = "E&xit";
			this.Text = "Individual ALS Procedure Report";
			this.CurrEmp = "";
			this.FirstTime = false;
			Label3 = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(2);
			Label3[0] = _Label3_0;
			Label3[1] = _Label3_1;
			Label3[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label3[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label3[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			Label3[0].Name = "_Label3_0";
			Label3[0].TabIndex = 10;
			Label3[0].Text = "Report Start Date:";
			Label3[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label3[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label3[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			Label3[1].Name = "_Label3_1";
			Label3[1].TabIndex = 7;
			Label3[1].Text = "End Date:";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx58636234720684207891", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text397636234720684227421", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color1042636234720684266481");
			namedStyle3.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(160)))));
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1105636234720684276246");
			namedStyle4.CellType = textCellType2;
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.Renderer = textCellType2;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color1333636234720684325071");
			namedStyle5.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle5.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(160)))));
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font1684636234720684373896");
			namedStyle6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle7 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1731636234720684383661");
			namedStyle7.CellType = textCellType3;
			namedStyle7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle7.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle7.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle7.Renderer = textCellType3;
			namedStyle7.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Bottom;
			namedStyle8 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1769636234720684383661");
			namedStyle8.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle8.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle8.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle8.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle8.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle9 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1809636234720684393426");
			namedStyle9.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle9.CellType = textCellType4;
			namedStyle9.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle9.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle9.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle9.Renderer = textCellType4;
			namedStyle9.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Bottom;
			namedStyle10 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1847636234720684393426");
			namedStyle10.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle10.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle10.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle11 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1887636234720684403191");
			namedStyle11.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle11.CellType = textCellType5;
			namedStyle11.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle11.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle11.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle11.Renderer = textCellType5;
			namedStyle11.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Bottom;
			namedStyle12 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2166636234720684471546");
			namedStyle12.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle12.CellType = textCellType6;
			namedStyle12.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle12.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle12.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle12.Renderer = textCellType6;
			namedStyle12.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle13 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color2619636234720684618021");
			namedStyle13.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle13.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle13.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle13.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle13.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle13.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle14 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2720636234720684637551");
			namedStyle14.CellType = textCellType7;
			namedStyle14.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle14.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle14.Renderer = textCellType7;
			namedStyle14.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle15 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font2943636234720684686376");
			namedStyle15.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F);
			namedStyle15.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle15.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle15.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle16 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3070636234720684696141");
			namedStyle16.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle16.CellType = textCellType8;
			namedStyle16.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle16.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle16.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle16.Renderer = textCellType8;
			namedStyle16.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle17 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2702636234720684637551");
			namedStyle17.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle17.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle17.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle17.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle17.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle18 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3148636234720684715671");
			namedStyle18.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle18.CellType = textCellType9;
			namedStyle18.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle18.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle18.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle18.Renderer = textCellType9;
			namedStyle18.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle19 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3186636234720684715671");
			namedStyle19.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle19.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle19.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			this.Name = "PTSProject.frmIndALSProcReport";
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
			this.sprReport.Sheets.Add(this.sprReport_Sheet1);
		}

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboEmployee { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dtStart { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dtEnd { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label3_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEmpName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label3_1 { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprReport { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprReport_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdExit { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrEmp { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean FirstTime { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> Label3 { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}