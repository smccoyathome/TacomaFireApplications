using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmKOTAudit))]
	public class frmKOTAuditViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType23 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle44;
			FarPoint.ViewModels.NamedStyle namedStyle43;
			var textCellType22 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle42;
			var textCellType21 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle41;
			var textCellType20 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle40;
			FarPoint.ViewModels.NamedStyle namedStyle39;
			var textCellType19 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle38;
			FarPoint.ViewModels.NamedStyle namedStyle37;
			FarPoint.ViewModels.NamedStyle namedStyle36;
			var textCellType18 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle35;
			FarPoint.ViewModels.NamedStyle namedStyle34;
			var textCellType17 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle33;
			FarPoint.ViewModels.NamedStyle namedStyle32;
			var textCellType16 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle31;
			FarPoint.ViewModels.NamedStyle namedStyle30;
			var textCellType15 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle29;
			FarPoint.ViewModels.NamedStyle namedStyle28;
			var textCellType14 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle27;
			FarPoint.ViewModels.NamedStyle namedStyle26;
			var textCellType13 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle25;
			FarPoint.ViewModels.NamedStyle namedStyle24;
			var textCellType12 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle23;
			FarPoint.ViewModels.NamedStyle namedStyle22;
			FarPoint.ViewModels.NamedStyle namedStyle21;
			var textCellType11 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle20;
			FarPoint.ViewModels.NamedStyle namedStyle19;
			var textCellType10 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle18;
			var textCellType9 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle17;
			FarPoint.ViewModels.NamedStyle namedStyle16;
			var textCellType8 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle15;
			FarPoint.ViewModels.NamedStyle namedStyle14;
			var textCellType7 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle13;
			FarPoint.ViewModels.NamedStyle namedStyle12;
			var textCellType6 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle11;
			FarPoint.ViewModels.NamedStyle namedStyle10;
			var textCellType5 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle9;
			FarPoint.ViewModels.NamedStyle namedStyle8;
			var textCellType4 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle7;
			FarPoint.ViewModels.NamedStyle namedStyle6;
			var textCellType3 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle5;
			var textCellType2 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle4;
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.optD = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optD
			// 
			this.optD.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.optD.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8.25F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optD.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.optD.Name = "optD";
			this.optD.TabIndex = 14;
			this.optD.Text = "Shift D";
			this.optC = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optC
			// 
			this.optC.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.optC.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8.25F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optC.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.optC.Name = "optC";
			this.optC.TabIndex = 13;
			this.optC.Text = "Shift C";
			this.optB = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optB
			// 
			this.optB.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.optB.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8.25F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optB.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.optB.Name = "optB";
			this.optB.TabIndex = 12;
			this.optB.Text = "Shift B";
			this.optA = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optA
			// 
			this.optA.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.optA.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8.25F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optA.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.optA.Name = "optA";
			this.optA.TabIndex = 11;
			this.optA.Text = "Shift A";
			this.opt183 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// opt183
			// 
			this.opt183.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.opt183.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8.25F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.opt183.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.opt183.Name = "opt183";
			this.opt183.TabIndex = 23;
			this.opt183.Text = "Batt 3";
			this.optAll = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optAll
			// 
			this.optAll.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.optAll.Checked = true;
			this.optAll.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8.25F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optAll.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.optAll.Name = "optAll";
			this.optAll.TabIndex = 9;
			this.optAll.Text = "ALL";
			this.opt182 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// opt182
			// 
			this.opt182.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.opt182.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8.25F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.opt182.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.opt182.Name = "opt182";
			this.opt182.TabIndex = 8;
			this.opt182.Text = "Batt 2";
			this.opt181 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// opt181
			// 
			this.opt181.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.opt181.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8.25F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.opt181.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.opt181.Name = "opt181";
			this.opt181.TabIndex = 7;
			this.opt181.Text = "Batt 1";
			this.cboAssignmentCode = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboAssignmentCode
			// 
			this.cboAssignmentCode.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboAssignmentCode.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboAssignmentCode.Name = "cboAssignmentCode";
			this.cboAssignmentCode.TabIndex = 5;
			this.cboAssignmentCode.Text = "cboAssignmentCode";
			this.cboUnit = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboUnit
			// 
			this.cboUnit.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboUnit.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboUnit.Name = "cboUnit";
			this.cboUnit.TabIndex = 4;
			this.cboUnit.Text = "cboUnit";
			this.txtNameSearch = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtNameSearch.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtNameSearch.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtNameSearch.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtNameSearch.Name = "txtNameSearch";
			this.txtNameSearch.TabIndex = 3;
			this.txtNameSearch.Text = "txtNameSearch";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 17;
			this.Label1.Text = "Assignment Type";
			this._Label3_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label6_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.sprEmployeeList = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprEmployeeList.TabIndex = 0;
			this.sprEmployeeList.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprTimeSheet = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprTimeSheet.MaxRows = 34;
			this.sprTimeSheet.TabIndex = 1;
			this.sprTimeSheet.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprTimeSheet.Visible = false;
			this.lbCount = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbCount
			// 
			this.lbCount.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.lbCount.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbCount.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.lbCount.Name = "lbCount";
			this.lbCount.TabIndex = 22;
			this.lbCount.Text = "List Count:  ";
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 21;
			this.Label2.Text = "Select Employee for Debit & Holiday Dates, etc";
			this.sprTimeSheet_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprTimeSheet_Sheet1.SheetName = "Sheet1";
			this.sprTimeSheet_Sheet1.Cells.Get(0, 0).Value = "NUMBER";
			this.sprTimeSheet_Sheet1.Cells.Get(0, 1).Value = "EMPOYEE NAME";
			this.sprTimeSheet_Sheet1.Cells.Get(0, 2).Value = "TO2";
			this.sprTimeSheet_Sheet1.Cells.Get(0, 3).Value = "COST CENTER";
			this.sprTimeSheet_Sheet1.Cells.Get(0, 4).Value = "PS GROUP";
			this.sprTimeSheet_Sheet1.Cells.Get(0, 5).Value = "LEVEL";
			this.sprTimeSheet_Sheet1.Cells.Get(0, 6).Value = "PAY RATE";
            //ColumnSpan is OBSOLETE
            //this.sprTimeSheet_Sheet1.Cells.Get(0, 8).ColumnSpan = 3;
			this.sprTimeSheet_Sheet1.Cells.Get(0, 8).Value = "PERIOD BEGIN";
			//this.sprTimeSheet_Sheet1.Cells.Get(0, 11).ColumnSpan = 3;
			this.sprTimeSheet_Sheet1.Cells.Get(0, 11).Value = "PERIOD END";
			this.sprTimeSheet_Sheet1.Cells.Get(0, 14).Value = "1120";
			//this.sprTimeSheet_Sheet1.Cells.Get(1, 1).ColumnSpan = 2;
			//this.sprTimeSheet_Sheet1.Cells.Get(1, 8).ColumnSpan = 3;
			//this.sprTimeSheet_Sheet1.Cells.Get(1, 11).ColumnSpan = 3;
			this.sprTimeSheet_Sheet1.Cells.Get(1, 14).Value = "TO2";
			//this.sprTimeSheet_Sheet1.Cells.Get(2, 4).ColumnSpan = 2;
			this.sprTimeSheet_Sheet1.Cells.Get(2, 4).Value = "WEEK 1";
			this.sprTimeSheet_Sheet1.Cells.Get(3, 0).Value = "ACTIVITY";
			this.sprTimeSheet_Sheet1.Cells.Get(3, 1).Value = "COST CENTER";
			this.sprTimeSheet_Sheet1.Cells.Get(3, 2).Value = "WBS ELEMENT";
			this.sprTimeSheet_Sheet1.Cells.Get(3, 3).Value = "ORDER";
			this.sprTimeSheet_Sheet1.Cells.Get(3, 4).Value = "OPERATION";
			this.sprTimeSheet_Sheet1.Cells.Get(3, 5).Value = "A/A TYPE";
			this.sprTimeSheet_Sheet1.Cells.Get(3, 6).Value = "PS GROUP";
			this.sprTimeSheet_Sheet1.Cells.Get(3, 7).Value = "LEVEL";
			this.sprTimeSheet_Sheet1.Cells.Get(3, 8).Value = "MO";
			this.sprTimeSheet_Sheet1.Cells.Get(3, 9).Value = "TU";
			this.sprTimeSheet_Sheet1.Cells.Get(3, 10).Value = "WE";
			this.sprTimeSheet_Sheet1.Cells.Get(3, 11).Value = "TH";
			this.sprTimeSheet_Sheet1.Cells.Get(3, 12).Value = "FR";
			this.sprTimeSheet_Sheet1.Cells.Get(3, 13).Value = "SA";
			this.sprTimeSheet_Sheet1.Cells.Get(3, 14).Value = "SU";
			this.sprTimeSheet_Sheet1.Cells.Get(16, 4).Value = "WEEK 2";
			this.sprTimeSheet_Sheet1.Cells.Get(17, 0).Value = "ACTIVITY";
			this.sprTimeSheet_Sheet1.Cells.Get(17, 1).Value = "COST CENTER";
			this.sprTimeSheet_Sheet1.Cells.Get(17, 2).Value = "WBS ELEMENT";
			this.sprTimeSheet_Sheet1.Cells.Get(17, 3).Value = "ORDER";
			this.sprTimeSheet_Sheet1.Cells.Get(17, 4).Value = "OPERATION";
			this.sprTimeSheet_Sheet1.Cells.Get(17, 5).Value = "A/A TYPE";
			this.sprTimeSheet_Sheet1.Cells.Get(17, 6).Value = "PS GROUP";
			this.sprTimeSheet_Sheet1.Cells.Get(17, 7).Value = "LEVEL";
			this.sprTimeSheet_Sheet1.Cells.Get(17, 8).Value = "MO";
			this.sprTimeSheet_Sheet1.Cells.Get(17, 9).Value = "TU";
			this.sprTimeSheet_Sheet1.Cells.Get(17, 10).Value = "WE";
			this.sprTimeSheet_Sheet1.Cells.Get(17, 11).Value = "TH";
			this.sprTimeSheet_Sheet1.Cells.Get(17, 12).Value = "FR";
			this.sprTimeSheet_Sheet1.Cells.Get(17, 13).Value = "SA";
			this.sprTimeSheet_Sheet1.Cells.Get(17, 14).Value = "SU";
			this.sprTimeSheet_Sheet1.Cells.Get(32, 0).Value = "EMPLOYEE:";
            //ColumnSpan is OBSOLETE
            //this.sprTimeSheet_Sheet1.Cells.Get(32, 1).ColumnSpan = 4;
			this.sprTimeSheet_Sheet1.Cells.Get(32, 1).Value = "_________________________________________";
			this.sprTimeSheet_Sheet1.Cells.Get(32, 5).Value = "SUPERVISOR:";
			//this.sprTimeSheet_Sheet1.Cells.Get(32, 6).ColumnSpan = 7;
			this.sprTimeSheet_Sheet1.Cells.Get(32, 6).Value = "________________________________________________________________________________";
			this.sprTimeSheet_Sheet1.ColumnHeader.Rows.Get(0).Height = 0F;
			this.sprTimeSheet_Sheet1.Columns.Get(0).Width = 90F;
			this.sprTimeSheet_Sheet1.Columns.Get(1).Width = 104F;
			this.sprTimeSheet_Sheet1.Columns.Get(2).Width = 102F;
			this.sprTimeSheet_Sheet1.Columns.Get(3).Width = 105F;
			this.sprTimeSheet_Sheet1.Columns.Get(4).Width = 86F;
			this.sprTimeSheet_Sheet1.Columns.Get(5).Width = 90F;
			this.sprTimeSheet_Sheet1.Columns.Get(6).Width = 75F;
			this.sprTimeSheet_Sheet1.Columns.Get(7).Width = 46F;
			this.sprTimeSheet_Sheet1.Columns.Get(8).StyleName = "Static1171636234730220057916";
			this.sprTimeSheet_Sheet1.Columns.Get(8).Width = 42F;
			this.sprTimeSheet_Sheet1.Columns.Get(9).StyleName = "Static1171636234730220057916";
			this.sprTimeSheet_Sheet1.Columns.Get(9).Width = 42F;
			this.sprTimeSheet_Sheet1.Columns.Get(10).StyleName = "Static1171636234730220057916";
			this.sprTimeSheet_Sheet1.Columns.Get(10).Width = 42F;
			this.sprTimeSheet_Sheet1.Columns.Get(11).StyleName = "Static1171636234730220057916";
			this.sprTimeSheet_Sheet1.Columns.Get(11).Width = 42F;
			this.sprTimeSheet_Sheet1.Columns.Get(12).StyleName = "Static1171636234730220057916";
			this.sprTimeSheet_Sheet1.Columns.Get(12).Width = 42F;
			this.sprTimeSheet_Sheet1.Columns.Get(13).StyleName = "Static1171636234730220057916";
			this.sprTimeSheet_Sheet1.Columns.Get(13).Width = 42F;
			this.sprTimeSheet_Sheet1.Columns.Get(14).StyleName = "Static1171636234730220057916";
			this.sprTimeSheet_Sheet1.Columns.Get(14).Width = 42F;
			this.sprTimeSheet_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprTimeSheet_Sheet1.Rows.Get(0).Height = 24F;
			this.sprTimeSheet_Sheet1.Rows.Get(1).Height = 24F;
			this.sprTimeSheet_Sheet1.Rows.Get(2).Height = 24F;
			this.sprTimeSheet_Sheet1.Rows.Get(3).Height = 24F;
			this.sprTimeSheet_Sheet1.Rows.Get(4).Height = 24F;
			this.sprTimeSheet_Sheet1.Rows.Get(5).Height = 24F;
			this.sprTimeSheet_Sheet1.Rows.Get(6).Height = 24F;
			this.sprTimeSheet_Sheet1.Rows.Get(7).Height = 24F;
			this.sprTimeSheet_Sheet1.Rows.Get(8).Height = 24F;
			this.sprTimeSheet_Sheet1.Rows.Get(9).Height = 24F;
			this.sprTimeSheet_Sheet1.Rows.Get(10).Height = 24F;
			this.sprTimeSheet_Sheet1.Rows.Get(11).Height = 24F;
			this.sprTimeSheet_Sheet1.Rows.Get(12).Height = 24F;
			this.sprTimeSheet_Sheet1.Rows.Get(13).Height = 24F;
			this.sprTimeSheet_Sheet1.Rows.Get(14).Height = 24F;
			this.sprTimeSheet_Sheet1.Rows.Get(15).Height = 24F;
			this.sprTimeSheet_Sheet1.Rows.Get(16).Height = 24F;
			this.sprTimeSheet_Sheet1.Rows.Get(17).Height = 24F;
			this.sprTimeSheet_Sheet1.Rows.Get(18).Height = 24F;
			this.sprTimeSheet_Sheet1.Rows.Get(19).Height = 24F;
			this.sprTimeSheet_Sheet1.Rows.Get(20).Height = 24F;
			this.sprTimeSheet_Sheet1.Rows.Get(21).Height = 24F;
			this.sprTimeSheet_Sheet1.Rows.Get(22).Height = 24F;
			this.sprTimeSheet_Sheet1.Rows.Get(23).Height = 24F;
			this.sprTimeSheet_Sheet1.Rows.Get(24).Height = 24F;
			this.sprTimeSheet_Sheet1.Rows.Get(25).Height = 24F;
			this.sprTimeSheet_Sheet1.Rows.Get(26).Height = 24F;
			this.sprTimeSheet_Sheet1.Rows.Get(27).Height = 24F;
			this.sprTimeSheet_Sheet1.Rows.Get(28).Height = 24F;
			this.sprTimeSheet_Sheet1.Rows.Get(29).Height = 24F;
			this.sprTimeSheet_Sheet1.Rows.Get(30).Height = 24F;
			this.sprTimeSheet_Sheet1.Rows.Get(31).Height = 24F;
			this.sprTimeSheet_Sheet1.Rows.Get(32).Height = 24F;
			this.sprTimeSheet_Sheet1.Rows.Get(33).Height = 24F;
			this.sprEmployeeList_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprEmployeeList_Sheet1.SheetName = "Sheet1";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 0].Value = "Empl #";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 1].Value = "Name";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 2].Value = "Batt";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 3].Value = "Unit";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 4].Value = "Shift";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 5].Value = "Total DDF";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 6].Value = "DD Wrk/PR";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 7].Value = "Future DD";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 8].Value = "DD Not PR";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 9].Value = "Total FHL";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 10].Value = "FHL Wrk/PR";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 11].Value = "Future FHL";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 12].Value = "ID";
			this.sprEmployeeList_Sheet1.ColumnHeader.Rows.Get(0).Height = 30F;
			this.sprEmployeeList_Sheet1.Columns.Get(0).Label = "Empl #";
			this.sprEmployeeList_Sheet1.Columns.Get(0).Width = 55F;
			this.sprEmployeeList_Sheet1.Columns.Get(1).Label = "Name";
			this.sprEmployeeList_Sheet1.Columns.Get(1).Width = 134F;
			this.sprEmployeeList_Sheet1.Columns.Get(2).Label = "Batt";
			this.sprEmployeeList_Sheet1.Columns.Get(2).Width = 31F;
			this.sprEmployeeList_Sheet1.Columns.Get(3).Label = "Unit";
			this.sprEmployeeList_Sheet1.Columns.Get(3).Width = 30F;
			this.sprEmployeeList_Sheet1.Columns.Get(4).Label = "Shift";
			this.sprEmployeeList_Sheet1.Columns.Get(4).Width = 27F;
			this.sprEmployeeList_Sheet1.Columns.Get(5).Label = "Total DDF";
			this.sprEmployeeList_Sheet1.Columns.Get(5).Width = 37F;
			this.sprEmployeeList_Sheet1.Columns.Get(6).Label = "DD Wrk/PR";
			this.sprEmployeeList_Sheet1.Columns.Get(6).Width = 44F;
			this.sprEmployeeList_Sheet1.Columns.Get(7).Label = "Future DD";
			this.sprEmployeeList_Sheet1.Columns.Get(7).Width = 38F;
			this.sprEmployeeList_Sheet1.Columns.Get(8).Label = "DD Not PR";
			this.sprEmployeeList_Sheet1.Columns.Get(8).Width = 45F;
			this.sprEmployeeList_Sheet1.Columns.Get(9).Label = "Total FHL";
			this.sprEmployeeList_Sheet1.Columns.Get(9).Width = 40F;
			this.sprEmployeeList_Sheet1.Columns.Get(10).Label = "FHL Wrk/PR";
			this.sprEmployeeList_Sheet1.Columns.Get(10).Width = 50F;
			this.sprEmployeeList_Sheet1.Columns.Get(11).Label = "Future FHL";
			this.sprEmployeeList_Sheet1.Columns.Get(11).Width = 40F;
			this.sprEmployeeList_Sheet1.Columns.Get(12).Label = "ID";
			this.sprEmployeeList_Sheet1.Columns.Get(12).Visible = false;
			this.sprEmployeeList_Sheet1.Columns.Get(12).Width = 0F;
			this.sprEmployeeList_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.Text = "Debit Day - Holiday Audit";
			Label6 = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(2);
			Label6[1] = _Label6_1;
			Label6[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			Label6[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label6[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			Label6[1].Name = "_Label6_1";
			Label6[1].TabIndex = 15;
			Label6[1].Text = "Name:";
			Label3 = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(1);
			Label3[0] = _Label3_0;
			Label3[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			Label3[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label3[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			Label3[0].Name = "_Label3_0";
			Label3[0].TabIndex = 16;
			Label3[0].Text = "Unit";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234730111100046", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text315636234730111109811", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color59636234730219999326", "DataAreaDefault");
			namedStyle3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Courier New", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.Parent = "DataAreaDefault";
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text337636234730220018856", "DataAreaDefault");
			namedStyle4.CellType = textCellType2;
			namedStyle4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Courier New", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.Parent = "DataAreaDefault";
			namedStyle4.Renderer = textCellType2;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1171636234730220057916");
			namedStyle5.CellType = textCellType3;
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.Renderer = textCellType3;
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1728636234730220096976");
			namedStyle6.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle6.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle7 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1768636234730220116506");
			namedStyle7.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle7.CellType = textCellType4;
			namedStyle7.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle7.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle7.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle7.Renderer = textCellType4;
			namedStyle7.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle8 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1827636234730220145801");
			namedStyle8.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle8.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle8.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle8.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle8.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle9 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1867636234730220155566");
			namedStyle9.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle9.CellType = textCellType5;
			namedStyle9.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle9.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle9.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle9.Renderer = textCellType5;
			namedStyle9.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle10 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1932636234730220165331");
			namedStyle10.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle10.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle10.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle11 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1972636234730220175096");
			namedStyle11.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle11.CellType = textCellType6;
			namedStyle11.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle11.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle11.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle11.Renderer = textCellType6;
			namedStyle11.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle12 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3030636234730220468046");
			namedStyle12.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle12.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle12.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle12.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle12.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle13 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3070636234730220468046");
			namedStyle13.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle13.CellType = textCellType7;
			namedStyle13.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle13.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle13.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle13.Renderer = textCellType7;
			namedStyle13.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle14 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3156636234730220477811");
			namedStyle14.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle14.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle14.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle14.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle14.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle15 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3196636234730220487576");
			namedStyle15.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle15.CellType = textCellType8;
			namedStyle15.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle15.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle15.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle15.Renderer = textCellType8;
			namedStyle15.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle16 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3234636234730220487576");
			namedStyle16.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle16.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle16.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle16.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle16.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle17 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3274636234730220497341");
			namedStyle17.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle17.CellType = textCellType9;
			namedStyle17.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle17.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle17.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle17.Renderer = textCellType9;
			namedStyle17.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle18 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3352636234730220507106");
			namedStyle18.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle18.CellType = textCellType10;
			namedStyle18.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle18.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle18.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle18.Renderer = textCellType10;
			namedStyle18.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle19 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx156636234730220663346");
			namedStyle19.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle19.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle19.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle19.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle19.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle20 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static196636234730220682876");
			namedStyle20.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle20.CellType = textCellType11;
			namedStyle20.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle20.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle20.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle20.Renderer = textCellType11;
			namedStyle20.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle21 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color236636234730220692641");
			namedStyle21.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle21.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle21.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle21.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle21.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle22 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx303636234730220692641");
			namedStyle22.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle22.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle22.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle23 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static321636234730220712171");
			namedStyle23.CellType = textCellType12;
			namedStyle23.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle23.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle23.Renderer = textCellType12;
			namedStyle23.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle24 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx359636234730220712171");
			namedStyle24.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle24.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle24.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle25 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static377636234730220712171");
			namedStyle25.CellType = textCellType13;
			namedStyle25.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle25.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle25.Renderer = textCellType13;
			namedStyle25.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle26 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1108636234730220858646");
			namedStyle26.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle26.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle26.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle27 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1126636234730220858646");
			namedStyle27.CellType = textCellType14;
			namedStyle27.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle27.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle27.Renderer = textCellType14;
			namedStyle27.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle28 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1211636234730220878176");
			namedStyle28.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle28.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle28.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle28.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle28.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle29 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1251636234730220878176");
			namedStyle29.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle29.CellType = textCellType15;
			namedStyle29.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle29.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle29.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle29.Renderer = textCellType15;
			namedStyle29.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle30 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1312636234730220897706");
			namedStyle30.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle30.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle30.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle31 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2732636234730221249246");
			namedStyle31.CellType = textCellType16;
			namedStyle31.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle31.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle31.Renderer = textCellType16;
			namedStyle31.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle32 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1819636234730223485431");
			namedStyle32.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle32.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle32.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle32.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle32.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle33 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1859636234730223495196");
			namedStyle33.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle33.CellType = textCellType17;
			namedStyle33.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle33.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle33.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle33.Renderer = textCellType17;
			namedStyle33.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle34 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3312636234730220507106");
			namedStyle34.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle34.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle34.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle34.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle34.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle35 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1960636234730223504961");
			namedStyle35.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle35.CellType = textCellType18;
			namedStyle35.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle35.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle35.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle35.Renderer = textCellType18;
			namedStyle35.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle36 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2024636234730223514726");
			namedStyle36.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle36.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle36.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle37 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3198636234730223739321");
			namedStyle37.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle37.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle37.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle37.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle37.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle38 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3238636234730223749086");
			namedStyle38.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle38.CellType = textCellType19;
			namedStyle38.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle38.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle38.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle38.Renderer = textCellType19;
			namedStyle38.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle39 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2151636234730225897386");
			namedStyle39.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Courier New", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle39.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle39.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle39.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle40 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2784636234730225965741");
			namedStyle40.CellType = textCellType20;
			namedStyle40.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Courier New", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle40.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle40.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle40.Renderer = textCellType20;
			namedStyle40.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle41 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2864636234730225985271");
			namedStyle41.CellType = textCellType21;
			namedStyle41.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle41.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle41.Renderer = textCellType21;
			namedStyle41.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Bottom;
			namedStyle42 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2976636234730226004801");
			namedStyle42.CellType = textCellType22;
			namedStyle42.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle42.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle42.Renderer = textCellType22;
			namedStyle42.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle43 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3126636234730226034096");
			namedStyle43.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle43.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle43.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle44 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3144636234730226034096");
			namedStyle44.CellType = textCellType23;
			namedStyle44.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle44.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle44.Renderer = textCellType23;
			namedStyle44.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			this.Name = "PTSProject.frmKOTAudit";
			IsMdiChild = true;
			this.sprEmployeeList.NamedStyles.Add(namedStyle1);
			this.sprEmployeeList.NamedStyles.Add(namedStyle2);
			this.sprEmployeeList.Sheets.Add(this.sprEmployeeList_Sheet1);
			this.sprTimeSheet.NamedStyles.Add(namedStyle3);
			this.sprTimeSheet.NamedStyles.Add(namedStyle4);
			this.sprTimeSheet.NamedStyles.Add(namedStyle5);
			this.sprTimeSheet.NamedStyles.Add(namedStyle6);
			this.sprTimeSheet.NamedStyles.Add(namedStyle7);
			this.sprTimeSheet.NamedStyles.Add(namedStyle8);
			this.sprTimeSheet.NamedStyles.Add(namedStyle9);
			this.sprTimeSheet.NamedStyles.Add(namedStyle10);
			this.sprTimeSheet.NamedStyles.Add(namedStyle11);
			this.sprTimeSheet.NamedStyles.Add(namedStyle12);
			this.sprTimeSheet.NamedStyles.Add(namedStyle13);
			this.sprTimeSheet.NamedStyles.Add(namedStyle14);
			this.sprTimeSheet.NamedStyles.Add(namedStyle15);
			this.sprTimeSheet.NamedStyles.Add(namedStyle16);
			this.sprTimeSheet.NamedStyles.Add(namedStyle17);
			this.sprTimeSheet.NamedStyles.Add(namedStyle18);
			this.sprTimeSheet.NamedStyles.Add(namedStyle19);
			this.sprTimeSheet.NamedStyles.Add(namedStyle20);
			this.sprTimeSheet.NamedStyles.Add(namedStyle21);
			this.sprTimeSheet.NamedStyles.Add(namedStyle22);
			this.sprTimeSheet.NamedStyles.Add(namedStyle23);
			this.sprTimeSheet.NamedStyles.Add(namedStyle24);
			this.sprTimeSheet.NamedStyles.Add(namedStyle25);
			this.sprTimeSheet.NamedStyles.Add(namedStyle26);
			this.sprTimeSheet.NamedStyles.Add(namedStyle27);
			this.sprTimeSheet.NamedStyles.Add(namedStyle28);
			this.sprTimeSheet.NamedStyles.Add(namedStyle29);
			this.sprTimeSheet.NamedStyles.Add(namedStyle30);
			this.sprTimeSheet.NamedStyles.Add(namedStyle31);
			this.sprTimeSheet.NamedStyles.Add(namedStyle32);
			this.sprTimeSheet.NamedStyles.Add(namedStyle33);
			this.sprTimeSheet.NamedStyles.Add(namedStyle34);
			this.sprTimeSheet.NamedStyles.Add(namedStyle35);
			this.sprTimeSheet.NamedStyles.Add(namedStyle36);
			this.sprTimeSheet.NamedStyles.Add(namedStyle37);
			this.sprTimeSheet.NamedStyles.Add(namedStyle38);
			this.sprTimeSheet.NamedStyles.Add(namedStyle39);
			this.sprTimeSheet.NamedStyles.Add(namedStyle40);
			this.sprTimeSheet.NamedStyles.Add(namedStyle41);
			this.sprTimeSheet.NamedStyles.Add(namedStyle42);
			this.sprTimeSheet.NamedStyles.Add(namedStyle43);
			this.sprTimeSheet.NamedStyles.Add(namedStyle44);
			this.sprTimeSheet.Sheets.Add(this.sprTimeSheet_Sheet1);
		}

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optD { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optC { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optB { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optA { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel opt183 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optAll { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel opt182 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel opt181 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboAssignmentCode { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboUnit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtNameSearch { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label3_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label6_1 { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprEmployeeList { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprTimeSheet { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbCount { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprTimeSheet_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprEmployeeList_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> Label6 { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> Label3 { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}