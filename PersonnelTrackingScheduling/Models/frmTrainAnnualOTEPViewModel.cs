using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmTrainAnnualOTEP))]
	public class frmTrainAnnualOTEPViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType44 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle103;
			FarPoint.ViewModels.NamedStyle namedStyle102;
			FarPoint.ViewModels.NamedStyle namedStyle101;
			var textCellType43 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle100;
			FarPoint.ViewModels.NamedStyle namedStyle99;
			var textCellType42 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle98;
			FarPoint.ViewModels.NamedStyle namedStyle97;
			var textCellType41 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle96;
			FarPoint.ViewModels.NamedStyle namedStyle95;
			var textCellType40 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle94;
			FarPoint.ViewModels.NamedStyle namedStyle93;
			var textCellType39 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle92;
			FarPoint.ViewModels.NamedStyle namedStyle91;
			var textCellType38 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle90;
			FarPoint.ViewModels.NamedStyle namedStyle89;
			var textCellType37 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle88;
			FarPoint.ViewModels.NamedStyle namedStyle87;
			var textCellType36 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle86;
			FarPoint.ViewModels.NamedStyle namedStyle85;
			var textCellType35 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle84;
			FarPoint.ViewModels.NamedStyle namedStyle83;
			var textCellType34 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle82;
			var textCellType33 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle81;
			FarPoint.ViewModels.NamedStyle namedStyle80;
			FarPoint.ViewModels.NamedStyle namedStyle79;
			FarPoint.ViewModels.NamedStyle namedStyle78;
			FarPoint.ViewModels.NamedStyle namedStyle77;
			var textCellType32 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle76;
			FarPoint.ViewModels.NamedStyle namedStyle75;
			var textCellType31 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle74;
			FarPoint.ViewModels.NamedStyle namedStyle73;
			var textCellType30 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle72;
			FarPoint.ViewModels.NamedStyle namedStyle71;
			var textCellType29 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle70;
			FarPoint.ViewModels.NamedStyle namedStyle69;
			FarPoint.ViewModels.NamedStyle namedStyle68;
			FarPoint.ViewModels.NamedStyle namedStyle67;
			FarPoint.ViewModels.NamedStyle namedStyle66;
			FarPoint.ViewModels.NamedStyle namedStyle65;
			FarPoint.ViewModels.NamedStyle namedStyle64;
			FarPoint.ViewModels.NamedStyle namedStyle63;
			FarPoint.ViewModels.NamedStyle namedStyle62;
			FarPoint.ViewModels.NamedStyle namedStyle61;
			FarPoint.ViewModels.NamedStyle namedStyle60;
			FarPoint.ViewModels.NamedStyle namedStyle59;
			FarPoint.ViewModels.NamedStyle namedStyle58;
			FarPoint.ViewModels.NamedStyle namedStyle57;
			FarPoint.ViewModels.NamedStyle namedStyle56;
			FarPoint.ViewModels.NamedStyle namedStyle55;
			var textCellType28 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle54;
			var textCellType27 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle53;
			FarPoint.ViewModels.NamedStyle namedStyle52;
			var textCellType26 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle51;
			var textCellType25 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle50;
			FarPoint.ViewModels.NamedStyle namedStyle49;
			FarPoint.ViewModels.NamedStyle namedStyle48;
			var textCellType24 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle47;
			FarPoint.ViewModels.NamedStyle namedStyle46;
			var textCellType23 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle45;
			FarPoint.ViewModels.NamedStyle namedStyle44;
			var textCellType22 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle43;
			FarPoint.ViewModels.NamedStyle namedStyle42;
			var textCellType21 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle41;
			FarPoint.ViewModels.NamedStyle namedStyle40;
			var textCellType20 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle39;
			FarPoint.ViewModels.NamedStyle namedStyle38;
			var textCellType19 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
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
			var textCellType11 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle21;
			FarPoint.ViewModels.NamedStyle namedStyle20;
			var textCellType10 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle19;
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
			var textCellType5 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle10;
			FarPoint.ViewModels.NamedStyle namedStyle9;
			var textCellType4 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle8;
			var textCellType3 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle7;
			FarPoint.ViewModels.NamedStyle namedStyle6;
			var textCellType2 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle5;
			FarPoint.ViewModels.NamedStyle namedStyle4;
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.sprReport = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprReport.MaxRows = 600;
			this.sprReport.TabIndex = 11;
			this.sprReport.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.optPM = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optPM
			// 
			this.optPM.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.optPM.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optPM.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.optPM.Name = "optPM";
			this.optPM.TabIndex = 21;
			this.optPM.Text = "PM Only";
			this.optAll = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optAll
			// 
			this.optAll.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.optAll.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optAll.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.optAll.Name = "optAll";
			this.optAll.TabIndex = 20;
			this.optAll.Text = "ALL";
			this.opt182 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// opt182
			// 
			this.opt182.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.opt182.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.opt182.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.opt182.Name = "opt182";
			this.opt182.TabIndex = 19;
			this.opt182.Text = "Batt 2";
			this.opt181 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// opt181
			// 
			this.opt181.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.opt181.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.opt181.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.opt181.Name = "opt181";
			this.opt181.TabIndex = 18;
			this.opt181.Text = "Batt 1";
			this.opt183 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// opt183
			// 
			this.opt183.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.opt183.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.opt183.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.opt183.Name = "opt183";
			this.opt183.TabIndex = 17;
			this.opt183.Text = "Batt 3";
			this.optGrp3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optGrp3
			// 
			this.optGrp3.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.optGrp3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optGrp3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.optGrp3.Name = "optGrp3";
			this.optGrp3.TabIndex = 15;
			this.optGrp3.Text = "Group 3";
			this.optGrp2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optGrp2
			// 
			this.optGrp2.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.optGrp2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optGrp2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.optGrp2.Name = "optGrp2";
			this.optGrp2.TabIndex = 14;
			this.optGrp2.Text = "Group 2";
			this.optGrp1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optGrp1
			// 
			this.optGrp1.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.optGrp1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optGrp1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.optGrp1.Name = "optGrp1";
			this.optGrp1.TabIndex = 13;
			this.optGrp1.Text = "Group 1";
			this.cboYear = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboYear
			// 
			this.cboYear.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboYear.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboYear.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboYear.Name = "cboYear";
			this.cboYear.TabIndex = 6;
			this.cboYear.Text = "cboYear";
			this.optA = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optA
			// 
			this.optA.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.optA.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optA.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.optA.Name = "optA";
			this.optA.TabIndex = 5;
			this.optA.Text = "Shift A";
			this.optB = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optB
			// 
			this.optB.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.optB.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optB.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.optB.Name = "optB";
			this.optB.TabIndex = 4;
			this.optB.Text = "Shift B";
			this.optC = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optC
			// 
			this.optC.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.optC.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optC.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.optC.Name = "optC";
			this.optC.TabIndex = 3;
			this.optC.Text = "Shift C";
			this.optD = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optD
			// 
			this.optD.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.optD.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optD.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.optD.Name = "optD";
			this.optD.TabIndex = 2;
			this.optD.Text = "Shift D";
			this._lbSubTitle_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.sprReport_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprReport_Sheet1.SheetName = "Sheet1";
            //ColumnSpan & RowSpan are OBSOLETE
            //this.sprReport_Sheet1.Cells.Get(0, 0).ColumnSpan = 18;
			this.sprReport_Sheet1.Cells.Get(0, 0).Value = "Tacoma Fire Department";
			//this.sprReport_Sheet1.Cells.Get(0, 18).ColumnSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(0, 18).RowSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(1, 0).ColumnSpan = 18;
			this.sprReport_Sheet1.Cells.Get(1, 0).Value = "Annual OTEP Training Module Report";
			//this.sprReport_Sheet1.Cells.Get(2, 0).ColumnSpan = 4;
			//this.sprReport_Sheet1.Cells.Get(2, 0).RowSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(2, 4).ColumnSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(2, 6).ColumnSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(2, 8).ColumnSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(2, 10).ColumnSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(2, 12).ColumnSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(2, 14).ColumnSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(2, 16).ColumnSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(2, 18).ColumnSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(2, 20).ColumnSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(2, 22).ColumnSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(2, 24).ColumnSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(2, 26).ColumnSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(3, 4).ColumnSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(3, 6).ColumnSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(3, 8).ColumnSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(3, 10).ColumnSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(3, 12).ColumnSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(3, 14).ColumnSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(3, 16).ColumnSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(3, 18).ColumnSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(3, 20).ColumnSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(3, 22).ColumnSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(3, 24).ColumnSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(3, 26).ColumnSpan = 2;
			this.sprReport_Sheet1.Cells.Get(4, 0).Value = "Name";
			this.sprReport_Sheet1.Cells.Get(4, 1).Value = "Cert #";
			this.sprReport_Sheet1.Cells.Get(4, 2).Value = "Unit";
			this.sprReport_Sheet1.Cells.Get(4, 3).Value = "Grp";
			this.sprReport_Sheet1.Cells.Get(4, 4).Value = "Date";
			this.sprReport_Sheet1.Cells.Get(4, 5).Value = "Skills";
			this.sprReport_Sheet1.Cells.Get(4, 6).Value = "Date";
			this.sprReport_Sheet1.Cells.Get(4, 7).Value = "Skills";
			this.sprReport_Sheet1.Cells.Get(4, 8).Value = "Date";
			this.sprReport_Sheet1.Cells.Get(4, 9).Value = "Skills";
			this.sprReport_Sheet1.Cells.Get(4, 10).Value = "Date";
			this.sprReport_Sheet1.Cells.Get(4, 11).Value = "Skills";
			this.sprReport_Sheet1.Cells.Get(4, 12).Value = "Date";
			this.sprReport_Sheet1.Cells.Get(4, 13).Value = "Skills";
			this.sprReport_Sheet1.Cells.Get(4, 14).Value = "Date";
			this.sprReport_Sheet1.Cells.Get(4, 15).Value = "Skills";
			this.sprReport_Sheet1.Cells.Get(4, 16).Value = "Date";
			this.sprReport_Sheet1.Cells.Get(4, 17).Value = "Skills";
			this.sprReport_Sheet1.Cells.Get(4, 18).Value = "Date";
			this.sprReport_Sheet1.Cells.Get(4, 19).Value = "Skills";
			this.sprReport_Sheet1.Cells.Get(4, 20).Value = "Date";
			this.sprReport_Sheet1.Cells.Get(4, 21).Value = "Skills";
			this.sprReport_Sheet1.Cells.Get(4, 22).Value = "Date";
			this.sprReport_Sheet1.Cells.Get(4, 23).Value = "Skills";
			this.sprReport_Sheet1.Cells.Get(4, 24).Value = "Date";
			this.sprReport_Sheet1.Cells.Get(4, 25).Value = "Skills";
			this.sprReport_Sheet1.Cells.Get(4, 26).Value = "Date";
			this.sprReport_Sheet1.Cells.Get(4, 27).Value = "Skills";
			//this.sprReport_Sheet1.Cells.Get(5, 4).ColumnSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(5, 6).ColumnSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(5, 8).ColumnSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(5, 10).ColumnSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(5, 12).ColumnSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(5, 14).ColumnSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(5, 16).ColumnSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(5, 20).ColumnSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(5, 22).ColumnSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(5, 24).ColumnSpan = 2;
			//this.sprReport_Sheet1.Cells.Get(5, 26).ColumnSpan = 2;
			this.sprReport_Sheet1.ColumnHeader.Rows.Get(0).Height = 0F;
			this.sprReport_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprReport_Sheet1.Rows.Get(0).Height = 23F;
			this.sprReport_Sheet1.Rows.Get(3).Height = 47F;
			this.sprReport_Sheet1.Rows.Get(5).Visible = false;
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 9;
			this.cmdClose.Text = "&Close";
			this.cmdClear = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClear
			// 
			this.cmdClear.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClear.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClear.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClear.Name = "cmdClear";
			this.cmdClear.TabIndex = 8;
			this.cmdClear.Text = "Clear Filters";
			this.cmdPrint = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrint.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrint.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.TabIndex = 7;
			this.cmdPrint.Text = "Print Report";
			this.Text = "TFD Training Annual OTEP Reporting";
			this.FirstTime = false;
			this.CurrGroup = 0;
			this.CurrYear = 0;
			this.CurrBatt = "";
			this.CurrShift = "";
			lbSubTitle = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(3);
			lbSubTitle[2] = _lbSubTitle_2;
			lbSubTitle[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbSubTitle[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbSubTitle[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			lbSubTitle[2].Name = "_lbSubTitle_2";
			lbSubTitle[2].TabIndex = 10;
			lbSubTitle[2].Text = "Report Year";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234776735557296", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text357636234776735567061", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color2192636234776735576826");
			namedStyle3.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(160)))));
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2275636234776735596356");
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2293636234776735596356");
			namedStyle5.CellType = textCellType2;
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.Renderer = textCellType2;
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font3372636234776735791656");
			namedStyle6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle7 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3419636234776735801421");
			namedStyle7.CellType = textCellType3;
			namedStyle7.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle7.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle7.Renderer = textCellType3;
			namedStyle7.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle8 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3953636234776735860011");
			namedStyle8.CellType = textCellType4;
			namedStyle8.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle8.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle8.Renderer = textCellType4;
			namedStyle8.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle9 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3991636234776735869776");
			namedStyle9.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle9.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle9.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle10 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static4009636234776735869776");
			namedStyle10.CellType = textCellType5;
			namedStyle10.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle10.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle10.Renderer = textCellType5;
			namedStyle10.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle11 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static56636234776735889306");
			namedStyle11.CellType = textCellType6;
			namedStyle11.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle11.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle11.Renderer = textCellType6;
			namedStyle11.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle12 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3935636234776735860011");
			namedStyle12.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle12.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle12.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle12.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle12.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle13 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static134636234776735899071");
			namedStyle13.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle13.CellType = textCellType7;
			namedStyle13.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle13.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle13.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle13.Renderer = textCellType7;
			namedStyle13.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle14 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx38636234776735879541");
			namedStyle14.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle14.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle14.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle14.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle14.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle15 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static212636234776735908836");
			namedStyle15.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle15.CellType = textCellType8;
			namedStyle15.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle15.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle15.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle15.Renderer = textCellType8;
			namedStyle15.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle16 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx250636234776735918601");
			namedStyle16.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle16.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle16.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle16.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle16.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle17 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static290636234776735928366");
			namedStyle17.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle17.CellType = textCellType9;
			namedStyle17.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle17.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle17.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle17.Renderer = textCellType9;
			namedStyle17.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle18 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx328636234776735928366");
			namedStyle18.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle18.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle18.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle18.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle18.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle19 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static368636234776735938131");
			namedStyle19.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle19.CellType = textCellType10;
			namedStyle19.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle19.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle19.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle19.Renderer = textCellType10;
			namedStyle19.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle20 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx406636234776735986956");
			namedStyle20.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle20.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle20.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle20.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle20.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle21 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static446636234776735996721");
			namedStyle21.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle21.CellType = textCellType11;
			namedStyle21.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle21.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle21.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle21.Renderer = textCellType11;
			namedStyle21.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle22 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx484636234776736006486");
			namedStyle22.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle22.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle22.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle22.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle22.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle23 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static524636234776736006486");
			namedStyle23.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle23.CellType = textCellType12;
			namedStyle23.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle23.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle23.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle23.Renderer = textCellType12;
			namedStyle23.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle24 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx562636234776736006486");
			namedStyle24.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(64)))));
			namedStyle24.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle24.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle24.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle24.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle25 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static602636234776736016251");
			namedStyle25.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(64)))));
			namedStyle25.CellType = textCellType13;
			namedStyle25.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle25.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle25.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle25.Renderer = textCellType13;
			namedStyle25.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle26 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx640636234776736026016");
			namedStyle26.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(64)))));
			namedStyle26.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle26.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle26.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle26.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle27 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static680636234776736035781");
			namedStyle27.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(64)))));
			namedStyle27.CellType = textCellType14;
			namedStyle27.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle27.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle27.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle27.Renderer = textCellType14;
			namedStyle27.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle28 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx718636234776736035781");
			namedStyle28.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			namedStyle28.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle28.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle28.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle28.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle29 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static758636234776736045546");
			namedStyle29.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			namedStyle29.CellType = textCellType15;
			namedStyle29.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle29.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle29.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle29.Renderer = textCellType15;
			namedStyle29.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle30 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx796636234776736055311");
			namedStyle30.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			namedStyle30.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle30.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle30.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle30.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle31 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static836636234776736065076");
			namedStyle31.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			namedStyle31.CellType = textCellType16;
			namedStyle31.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle31.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle31.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle31.Renderer = textCellType16;
			namedStyle31.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle32 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx874636234776736065076");
			namedStyle32.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(64)))));
			namedStyle32.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle32.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle32.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle32.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle33 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static914636234776736074841");
			namedStyle33.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(64)))));
			namedStyle33.CellType = textCellType17;
			namedStyle33.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle33.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle33.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle33.Renderer = textCellType17;
			namedStyle33.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle34 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx952636234776736074841");
			namedStyle34.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(64)))));
			namedStyle34.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle34.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle34.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle34.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle35 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static992636234776736084606");
			namedStyle35.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(64)))));
			namedStyle35.CellType = textCellType18;
			namedStyle35.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle35.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle35.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle35.Renderer = textCellType18;
			namedStyle35.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle36 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1030636234776736094371");
			namedStyle36.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle36.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle36.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle36.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle36.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle37 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1070636234776736094371");
			namedStyle37.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle37.CellType = textCellType19;
			namedStyle37.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle37.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle37.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle37.Renderer = textCellType19;
			namedStyle37.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle38 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1108636234776736104136");
			namedStyle38.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle38.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle38.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle38.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle38.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle39 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1148636234776736113901");
			namedStyle39.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle39.CellType = textCellType20;
			namedStyle39.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle39.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle39.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle39.Renderer = textCellType20;
			namedStyle39.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle40 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1186636234776736113901");
			namedStyle40.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
			namedStyle40.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle40.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle40.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle40.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle41 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1226636234776736123666");
			namedStyle41.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
			namedStyle41.CellType = textCellType21;
			namedStyle41.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle41.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle41.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle41.Renderer = textCellType21;
			namedStyle41.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle42 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1264636234776736133431");
			namedStyle42.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
			namedStyle42.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle42.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle42.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle42.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle43 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1304636234776736133431");
			namedStyle43.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
			namedStyle43.CellType = textCellType22;
			namedStyle43.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle43.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle43.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle43.Renderer = textCellType22;
			namedStyle43.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle44 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1342636234776736143196");
			namedStyle44.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
			namedStyle44.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle44.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle44.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle44.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle45 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1382636234776736152961");
			namedStyle45.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
			namedStyle45.CellType = textCellType23;
			namedStyle45.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle45.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle45.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle45.Renderer = textCellType23;
			namedStyle45.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle46 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1420636234776736152961");
			namedStyle46.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
			namedStyle46.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle46.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle46.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle46.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle47 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1460636234776736172491");
			namedStyle47.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
			namedStyle47.CellType = textCellType24;
			namedStyle47.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle47.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle47.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle47.Renderer = textCellType24;
			namedStyle47.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle48 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1498636234776736172491");
			namedStyle48.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle48.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle48.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle49 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1576636234776736182256");
			namedStyle49.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle49.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle49.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle50 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1975636234776736250611");
			namedStyle50.CellType = textCellType25;
			namedStyle50.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle50.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle50.Renderer = textCellType25;
			namedStyle50.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle51 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2031636234776736270141");
			namedStyle51.CellType = textCellType26;
			namedStyle51.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle51.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle51.Renderer = textCellType26;
			namedStyle51.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle52 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2069636234776736270141");
			namedStyle52.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle52.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle52.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle53 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2087636234776736328731");
			namedStyle53.CellType = textCellType27;
			namedStyle53.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle53.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle53.Renderer = textCellType27;
			namedStyle53.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle54 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2199636234776736348261");
			namedStyle54.CellType = textCellType28;
			namedStyle54.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle54.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle54.Renderer = textCellType28;
			namedStyle54.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle55 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2013636234776736260376");
			namedStyle55.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle55.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle55.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle55.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle55.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle56 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2181636234776736348261");
			namedStyle56.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle56.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle56.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle56.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle56.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle57 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2357636234776736377556");
			namedStyle57.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle57.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle57.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle57.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle57.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle58 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2417636234776736387321");
			namedStyle58.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle58.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle58.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle58.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle58.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle59 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2477636234776736397086");
			namedStyle59.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle59.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle59.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle59.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle59.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle60 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2537636234776736406851");
			namedStyle60.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle60.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle60.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle60.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle60.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle61 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2597636234776736416616");
			namedStyle61.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(64)))));
			namedStyle61.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle61.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle61.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle61.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle62 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2657636234776736426381");
			namedStyle62.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(64)))));
			namedStyle62.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle62.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle62.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle62.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle63 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2717636234776736436146");
			namedStyle63.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			namedStyle63.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle63.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle63.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle63.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle64 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2777636234776736455676");
			namedStyle64.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			namedStyle64.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle64.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle64.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle64.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle65 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2837636234776736465441");
			namedStyle65.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(64)))));
			namedStyle65.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle65.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle65.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle65.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle66 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2897636234776736475206");
			namedStyle66.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(64)))));
			namedStyle66.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle66.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle66.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle66.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle67 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2957636234776736484971");
			namedStyle67.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle67.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle67.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle67.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle67.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle68 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3017636234776736494736");
			namedStyle68.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle68.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle68.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle68.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle68.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle69 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3077636234776736514266");
			namedStyle69.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
			namedStyle69.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle69.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle69.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle69.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle70 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3117636234776736524031");
			namedStyle70.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
			namedStyle70.CellType = textCellType29;
			namedStyle70.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle70.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle70.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle70.Renderer = textCellType29;
			namedStyle70.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle71 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3155636234776736533796");
			namedStyle71.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
			namedStyle71.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle71.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle71.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle71.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle72 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3195636234776736543561");
			namedStyle72.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
			namedStyle72.CellType = textCellType30;
			namedStyle72.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle72.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle72.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle72.Renderer = textCellType30;
			namedStyle72.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle73 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3233636234776736543561");
			namedStyle73.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
			namedStyle73.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle73.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle73.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle73.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle74 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3273636234776736563091");
			namedStyle74.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
			namedStyle74.CellType = textCellType31;
			namedStyle74.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle74.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle74.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle74.Renderer = textCellType31;
			namedStyle74.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle75 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3311636234776736572856");
			namedStyle75.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
			namedStyle75.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle75.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle75.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle75.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle76 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3351636234776736582621");
			namedStyle76.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
			namedStyle76.CellType = textCellType32;
			namedStyle76.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle76.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle76.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle76.Renderer = textCellType32;
			namedStyle76.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle77 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3389636234776736592386");
			namedStyle77.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle77.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle77.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle77.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle77.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle78 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3449636234776736592386");
			namedStyle78.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle78.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle78.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle78.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle78.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle79 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3509636234776736602151");
			namedStyle79.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle79.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle79.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle80 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3569636234776736621681");
			namedStyle80.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle80.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle80.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle81 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3778636234776736650976");
			namedStyle81.CellType = textCellType33;
			namedStyle81.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle81.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle81.Renderer = textCellType33;
			namedStyle81.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle82 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3853636234776736670506");
			namedStyle82.CellType = textCellType34;
			namedStyle82.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle82.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle82.Renderer = textCellType34;
			namedStyle82.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle83 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3760636234776736650976");
			namedStyle83.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle83.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle83.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle83.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle83.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle84 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static18636234776736777921");
			namedStyle84.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle84.CellType = textCellType35;
			namedStyle84.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle84.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle84.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle84.Renderer = textCellType35;
			namedStyle84.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle85 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx75636234776736787686");
			namedStyle85.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle85.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle85.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle85.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle85.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle86 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static214636234776736826746");
			namedStyle86.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle86.CellType = textCellType36;
			namedStyle86.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle86.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle86.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle86.Renderer = textCellType36;
			namedStyle86.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle87 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx271636234776736836511");
			namedStyle87.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle87.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle87.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle87.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle87.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle88 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static410636234776736865806");
			namedStyle88.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle88.CellType = textCellType37;
			namedStyle88.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle88.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle88.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle88.Renderer = textCellType37;
			namedStyle88.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle89 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx467636234776736875571");
			namedStyle89.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(64)))));
			namedStyle89.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle89.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle89.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle89.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle90 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static606636234776736924396");
			namedStyle90.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(64)))));
			namedStyle90.CellType = textCellType38;
			namedStyle90.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle90.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle90.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle90.Renderer = textCellType38;
			namedStyle90.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle91 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx663636234776736924396");
			namedStyle91.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			namedStyle91.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle91.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle91.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle91.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle92 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static802636234776736953691");
			namedStyle92.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			namedStyle92.CellType = textCellType39;
			namedStyle92.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle92.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle92.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle92.Renderer = textCellType39;
			namedStyle92.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle93 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx859636234776736963456");
			namedStyle93.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(64)))));
			namedStyle93.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle93.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle93.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle93.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle94 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static998636234776736992751");
			namedStyle94.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(64)))));
			namedStyle94.CellType = textCellType40;
			namedStyle94.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle94.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle94.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle94.Renderer = textCellType40;
			namedStyle94.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle95 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1055636234776737002516");
			namedStyle95.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle95.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle95.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle95.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle95.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle96 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1194636234776737031811");
			namedStyle96.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle96.CellType = textCellType41;
			namedStyle96.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle96.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle96.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle96.Renderer = textCellType41;
			namedStyle96.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle97 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1251636234776737041576");
			namedStyle97.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
			namedStyle97.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle97.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle97.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle97.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle98 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1390636234776737070871");
			namedStyle98.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
			namedStyle98.CellType = textCellType42;
			namedStyle98.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle98.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle98.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle98.Renderer = textCellType42;
			namedStyle98.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle99 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1447636234776737080636");
			namedStyle99.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
			namedStyle99.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle99.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle99.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle99.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle100 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1586636234776737119696");
			namedStyle100.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
			namedStyle100.CellType = textCellType43;
			namedStyle100.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle100.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle100.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle100.Renderer = textCellType43;
			namedStyle100.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle101 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1643636234776737129461");
			namedStyle101.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle101.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle101.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle102 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color2314636234776737285701");
			namedStyle102.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle102.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle102.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle102.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle102.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle103 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3480636234776737510296");
			namedStyle103.CellType = textCellType44;
			namedStyle103.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle103.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle103.Renderer = textCellType44;
			namedStyle103.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			this.Name = "PTSProject.frmTrainAnnualOTEP";
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
			this.sprReport.NamedStyles.Add(namedStyle26);
			this.sprReport.NamedStyles.Add(namedStyle27);
			this.sprReport.NamedStyles.Add(namedStyle28);
			this.sprReport.NamedStyles.Add(namedStyle29);
			this.sprReport.NamedStyles.Add(namedStyle30);
			this.sprReport.NamedStyles.Add(namedStyle31);
			this.sprReport.NamedStyles.Add(namedStyle32);
			this.sprReport.NamedStyles.Add(namedStyle33);
			this.sprReport.NamedStyles.Add(namedStyle34);
			this.sprReport.NamedStyles.Add(namedStyle35);
			this.sprReport.NamedStyles.Add(namedStyle36);
			this.sprReport.NamedStyles.Add(namedStyle37);
			this.sprReport.NamedStyles.Add(namedStyle38);
			this.sprReport.NamedStyles.Add(namedStyle39);
			this.sprReport.NamedStyles.Add(namedStyle40);
			this.sprReport.NamedStyles.Add(namedStyle41);
			this.sprReport.NamedStyles.Add(namedStyle42);
			this.sprReport.NamedStyles.Add(namedStyle43);
			this.sprReport.NamedStyles.Add(namedStyle44);
			this.sprReport.NamedStyles.Add(namedStyle45);
			this.sprReport.NamedStyles.Add(namedStyle46);
			this.sprReport.NamedStyles.Add(namedStyle47);
			this.sprReport.NamedStyles.Add(namedStyle48);
			this.sprReport.NamedStyles.Add(namedStyle49);
			this.sprReport.NamedStyles.Add(namedStyle50);
			this.sprReport.NamedStyles.Add(namedStyle51);
			this.sprReport.NamedStyles.Add(namedStyle52);
			this.sprReport.NamedStyles.Add(namedStyle53);
			this.sprReport.NamedStyles.Add(namedStyle54);
			this.sprReport.NamedStyles.Add(namedStyle55);
			this.sprReport.NamedStyles.Add(namedStyle56);
			this.sprReport.NamedStyles.Add(namedStyle57);
			this.sprReport.NamedStyles.Add(namedStyle58);
			this.sprReport.NamedStyles.Add(namedStyle59);
			this.sprReport.NamedStyles.Add(namedStyle60);
			this.sprReport.NamedStyles.Add(namedStyle61);
			this.sprReport.NamedStyles.Add(namedStyle62);
			this.sprReport.NamedStyles.Add(namedStyle63);
			this.sprReport.NamedStyles.Add(namedStyle64);
			this.sprReport.NamedStyles.Add(namedStyle65);
			this.sprReport.NamedStyles.Add(namedStyle66);
			this.sprReport.NamedStyles.Add(namedStyle67);
			this.sprReport.NamedStyles.Add(namedStyle68);
			this.sprReport.NamedStyles.Add(namedStyle69);
			this.sprReport.NamedStyles.Add(namedStyle70);
			this.sprReport.NamedStyles.Add(namedStyle71);
			this.sprReport.NamedStyles.Add(namedStyle72);
			this.sprReport.NamedStyles.Add(namedStyle73);
			this.sprReport.NamedStyles.Add(namedStyle74);
			this.sprReport.NamedStyles.Add(namedStyle75);
			this.sprReport.NamedStyles.Add(namedStyle76);
			this.sprReport.NamedStyles.Add(namedStyle77);
			this.sprReport.NamedStyles.Add(namedStyle78);
			this.sprReport.NamedStyles.Add(namedStyle79);
			this.sprReport.NamedStyles.Add(namedStyle80);
			this.sprReport.NamedStyles.Add(namedStyle81);
			this.sprReport.NamedStyles.Add(namedStyle82);
			this.sprReport.NamedStyles.Add(namedStyle83);
			this.sprReport.NamedStyles.Add(namedStyle84);
			this.sprReport.NamedStyles.Add(namedStyle85);
			this.sprReport.NamedStyles.Add(namedStyle86);
			this.sprReport.NamedStyles.Add(namedStyle87);
			this.sprReport.NamedStyles.Add(namedStyle88);
			this.sprReport.NamedStyles.Add(namedStyle89);
			this.sprReport.NamedStyles.Add(namedStyle90);
			this.sprReport.NamedStyles.Add(namedStyle91);
			this.sprReport.NamedStyles.Add(namedStyle92);
			this.sprReport.NamedStyles.Add(namedStyle93);
			this.sprReport.NamedStyles.Add(namedStyle94);
			this.sprReport.NamedStyles.Add(namedStyle95);
			this.sprReport.NamedStyles.Add(namedStyle96);
			this.sprReport.NamedStyles.Add(namedStyle97);
			this.sprReport.NamedStyles.Add(namedStyle98);
			this.sprReport.NamedStyles.Add(namedStyle99);
			this.sprReport.NamedStyles.Add(namedStyle100);
			this.sprReport.NamedStyles.Add(namedStyle101);
			this.sprReport.NamedStyles.Add(namedStyle102);
			this.sprReport.NamedStyles.Add(namedStyle103);
			this.sprReport.Sheets.Add(this.sprReport_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optPM { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optAll { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel opt182 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel opt181 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel opt183 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optGrp3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optGrp2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optGrp1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboYear { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optA { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optB { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optC { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optD { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbSubTitle_2 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprReport_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClear { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean isInitializingComponent { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean FirstTime { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrGroup { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrYear { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrBatt { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrShift { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbSubTitle { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}