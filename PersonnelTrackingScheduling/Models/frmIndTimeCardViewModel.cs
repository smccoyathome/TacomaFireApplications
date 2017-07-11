using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmIndTimeCard))]
	public class frmIndTimeCardViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType24 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle46;
			FarPoint.ViewModels.NamedStyle namedStyle45;
			var textCellType23 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle44;
			FarPoint.ViewModels.NamedStyle namedStyle43;
			var textCellType22 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle42;
			FarPoint.ViewModels.NamedStyle namedStyle41;
			var textCellType21 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle40;
			var textCellType20 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle39;
			var textCellType19 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle38;
			FarPoint.ViewModels.NamedStyle namedStyle37;
			var textCellType18 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle36;
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
			FarPoint.ViewModels.NamedStyle namedStyle19;
			var textCellType10 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle18;
			FarPoint.ViewModels.NamedStyle namedStyle17;
			var textCellType9 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
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
			FarPoint.ViewModels.NamedStyle namedStyle4;
			var textCellType2 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.sprTimeSheet = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprTimeSheet.MaxRows = 32;
			this.sprTimeSheet.TabIndex = 24;
			this.sprTimeSheet.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprTimeSheet.Visible = false;
			this.cboYear = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboYear
			// 
			this.cboYear.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboYear.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboYear.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboYear.Name = "cboYear";
			this.cboYear.TabIndex = 95;
			this.cboYear.Text = "cboYear";
			this.txtWe2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtWe2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtWe2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtWe2.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtWe2.Name = "txtWe2";
			this.txtWe2.TabIndex = 76;
			this.txtWe2.Text = "txtWe2";
			this.txtTu2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtTu2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtTu2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtTu2.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtTu2.Name = "txtTu2";
			this.txtTu2.TabIndex = 75;
			this.txtTu2.Text = "txtTu2";
			this.txtMo2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtMo2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtMo2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtMo2.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtMo2.Name = "txtMo2";
			this.txtMo2.TabIndex = 74;
			this.txtMo2.Text = "txtMo2";
			this.txtFr2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtFr2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtFr2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtFr2.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtFr2.Name = "txtFr2";
			this.txtFr2.TabIndex = 73;
			this.txtFr2.Text = "txtFr2";
			this.txtTh2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtTh2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtTh2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtTh2.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtTh2.Name = "txtTh2";
			this.txtTh2.TabIndex = 72;
			this.txtTh2.Text = "txtTh2";
			this.cboStep2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboStep2
			// 
			this.cboStep2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboStep2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboStep2.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboStep2.Name = "cboStep2";
			this.cboStep2.TabIndex = 71;
			this.cboStep2.Text = "cboStep2";
			this.cboJobCode2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboJobCode2
			// 
			this.cboJobCode2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboJobCode2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboJobCode2.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboJobCode2.Name = "cboJobCode2";
			this.cboJobCode2.TabIndex = 70;
			this.cboJobCode2.Text = "cboJobCode2";
			this.cboAAType2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboAAType2
			// 
			this.cboAAType2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboAAType2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboAAType2.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboAAType2.Name = "cboAAType2";
			this.cboAAType2.TabIndex = 69;
			this.cboAAType2.Text = "cboAAType2";
			this.txtSu2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtSu2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtSu2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtSu2.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtSu2.Name = "txtSu2";
			this.txtSu2.TabIndex = 68;
			this.txtSu2.Text = "txtSu2";
			this.txtSa2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtSa2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtSa2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtSa2.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtSa2.Name = "txtSa2";
			this.txtSa2.TabIndex = 67;
			this.txtSa2.Text = "txtSa2";
			this.txtOper2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtOper2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtOper2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtOper2.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtOper2.Name = "txtOper2";
			this.txtOper2.TabIndex = 66;
			this.txtOper2.Text = "txtOper2";
			this.txtWBSElement2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtWBSElement2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtWBSElement2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtWBSElement2.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtWBSElement2.Name = "txtWBSElement2";
			this.txtWBSElement2.TabIndex = 65;
			this.txtWBSElement2.Text = "txtWBSElement2";
			this.txtCostCenter2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtCostCenter2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtCostCenter2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtCostCenter2.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtCostCenter2.Name = "txtCostCenter2";
			this.txtCostCenter2.TabIndex = 64;
			this.txtCostCenter2.Text = "txtCostCenter2";
			this.txtActivity2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtActivity2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtActivity2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtActivity2.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtActivity2.Name = "txtActivity2";
			this.txtActivity2.TabIndex = 63;
			this.txtActivity2.Text = "txtActivity2";
			this.cboOrder2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboOrder2
			// 
			this.cboOrder2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboOrder2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboOrder2.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboOrder2.Name = "cboOrder2";
			this.cboOrder2.TabIndex = 61;
			this.cboOrder2.Text = "cboOrder2";
			this.Label36 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label36
			// 
			this.Label36.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.Label36.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label36.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label36.Name = "Label36";
			this.Label36.TabIndex = 92;
			this.Label36.Text = "MO";
			this.Label21 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label21
			// 
			this.Label21.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.Label21.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label21.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label21.Name = "Label21";
			this.Label21.TabIndex = 91;
			this.Label21.Text = "TU";
			this.Label22 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label22
			// 
			this.Label22.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.Label22.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label22.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label22.Name = "Label22";
			this.Label22.TabIndex = 90;
			this.Label22.Text = "WE";
			this.Label23 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label23
			// 
			this.Label23.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.Label23.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label23.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label23.Name = "Label23";
			this.Label23.TabIndex = 89;
			this.Label23.Text = "SA";
			this.Label24 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label24
			// 
			this.Label24.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.Label24.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label24.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label24.Name = "Label24";
			this.Label24.TabIndex = 88;
			this.Label24.Text = "SU";
			this.Label25 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label25
			// 
			this.Label25.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.Label25.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label25.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label25.Name = "Label25";
			this.Label25.TabIndex = 87;
			this.Label25.Text = "TH";
			this.Label26 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label26
			// 
			this.Label26.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.Label26.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label26.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label26.Name = "Label26";
			this.Label26.TabIndex = 86;
			this.Label26.Text = "FR";
			this.Label27 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label27
			// 
			this.Label27.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.Label27.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label27.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label27.Name = "Label27";
			this.Label27.TabIndex = 85;
			this.Label27.Text = "Level";
			this.Label28 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label28
			// 
			this.Label28.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.Label28.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label28.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label28.Name = "Label28";
			this.Label28.TabIndex = 84;
			this.Label28.Text = "A/A Type (KOT)";
			this.Label29 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label29
			// 
			this.Label29.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.Label29.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label29.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label29.Name = "Label29";
			this.Label29.TabIndex = 83;
			this.Label29.Text = "PS Group";
			this.Label30 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label30
			// 
			this.Label30.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.Label30.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label30.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label30.Name = "Label30";
			this.Label30.TabIndex = 82;
			this.Label30.Text = "WBS Elemt";
			this.Label31 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label31
			// 
			this.Label31.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.Label31.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label31.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label31.Name = "Label31";
			this.Label31.TabIndex = 81;
			this.Label31.Text = "Order";
			this.Label32 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label32
			// 
			this.Label32.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.Label32.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label32.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label32.Name = "Label32";
			this.Label32.TabIndex = 80;
			this.Label32.Text = "Oper";
			this.Label33 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label33
			// 
			this.Label33.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.Label33.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label33.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label33.Name = "Label33";
			this.Label33.TabIndex = 79;
			this.Label33.Text = "Cost Cntr";
			this.Label34 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label34
			// 
			this.Label34.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.Label34.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label34.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label34.Name = "Label34";
			this.Label34.TabIndex = 78;
			this.Label34.Text = "Activity";
			this._Label35_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.txtActivity1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtActivity1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtActivity1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtActivity1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtActivity1.Name = "txtActivity1";
			this.txtActivity1.TabIndex = 43;
			this.txtActivity1.Text = "txtActivity1";
			this.txtCostCenter1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtCostCenter1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtCostCenter1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtCostCenter1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtCostCenter1.Name = "txtCostCenter1";
			this.txtCostCenter1.TabIndex = 42;
			this.txtCostCenter1.Text = "txtCostCenter1";
			this.txtWBSElement1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtWBSElement1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtWBSElement1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtWBSElement1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtWBSElement1.Name = "txtWBSElement1";
			this.txtWBSElement1.TabIndex = 41;
			this.txtWBSElement1.Text = "txtWBSElement1";
			this.txtOper1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtOper1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtOper1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtOper1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtOper1.Name = "txtOper1";
			this.txtOper1.TabIndex = 40;
			this.txtOper1.Text = "txtOper1";
			this.txtSa1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtSa1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtSa1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtSa1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtSa1.Name = "txtSa1";
			this.txtSa1.TabIndex = 39;
			this.txtSa1.Text = "txtSa1";
			this.txtSu1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtSu1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtSu1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtSu1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtSu1.Name = "txtSu1";
			this.txtSu1.TabIndex = 38;
			this.txtSu1.Text = "txtSu1";
			this.cboAAType1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboAAType1
			// 
			this.cboAAType1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboAAType1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboAAType1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboAAType1.Name = "cboAAType1";
			this.cboAAType1.TabIndex = 37;
			this.cboAAType1.Text = "cboAAType1";
			this.cboJobCode1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboJobCode1
			// 
			this.cboJobCode1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboJobCode1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboJobCode1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboJobCode1.Name = "cboJobCode1";
			this.cboJobCode1.TabIndex = 36;
			this.cboJobCode1.Text = "cboJobCode1";
			this.cboStep1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboStep1
			// 
			this.cboStep1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboStep1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboStep1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboStep1.Name = "cboStep1";
			this.cboStep1.TabIndex = 35;
			this.cboStep1.Text = "cboStep1";
			this.txtTh1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtTh1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtTh1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtTh1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtTh1.Name = "txtTh1";
			this.txtTh1.TabIndex = 34;
			this.txtTh1.Text = "txtTh1";
			this.txtFr1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtFr1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtFr1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtFr1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtFr1.Name = "txtFr1";
			this.txtFr1.TabIndex = 33;
			this.txtFr1.Text = "txtFr1";
			this.txtMo1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtMo1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtMo1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtMo1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtMo1.Name = "txtMo1";
			this.txtMo1.TabIndex = 32;
			this.txtMo1.Text = "txtMo1";
			this.txtTu1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtTu1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtTu1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtTu1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtTu1.Name = "txtTu1";
			this.txtTu1.TabIndex = 31;
			this.txtTu1.Text = "txtTu1";
			this.txtWe1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtWe1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtWe1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtWe1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtWe1.Name = "txtWe1";
			this.txtWe1.TabIndex = 30;
			this.txtWe1.Text = "txtWe1";
			this.cboOrder1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboOrder1
			// 
			this.cboOrder1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboOrder1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboOrder1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboOrder1.Name = "cboOrder1";
			this.cboOrder1.TabIndex = 28;
			this.cboOrder1.Text = "cboOrder1";
			this._Label20_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label11_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.Label5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label5
			// 
			this.Label5.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.Label5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label5.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label5.Name = "Label5";
			this.Label5.TabIndex = 57;
			this.Label5.Text = "Oper";
			this.Label7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label7
			// 
			this.Label7.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.Label7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label7.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label7.Name = "Label7";
			this.Label7.TabIndex = 56;
			this.Label7.Text = "Order";
			this.Label8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label8
			// 
			this.Label8.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.Label8.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label8.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label8.Name = "Label8";
			this.Label8.TabIndex = 55;
			this.Label8.Text = "WBS Elemt";
			this.Label9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label9
			// 
			this.Label9.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.Label9.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label9.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label9.Name = "Label9";
			this.Label9.TabIndex = 54;
			this.Label9.Text = "PS Group";
			this.Label10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label10
			// 
			this.Label10.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.Label10.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label10.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label10.Name = "Label10";
			this.Label10.TabIndex = 53;
			this.Label10.Text = "A/A Type (KOT)";
			this.Label12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label12
			// 
			this.Label12.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.Label12.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label12.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label12.Name = "Label12";
			this.Label12.TabIndex = 52;
			this.Label12.Text = "Level";
			this.Label13 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label13
			// 
			this.Label13.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.Label13.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label13.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label13.Name = "Label13";
			this.Label13.TabIndex = 51;
			this.Label13.Text = "FR";
			this.Label14 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label14
			// 
			this.Label14.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.Label14.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label14.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label14.Name = "Label14";
			this.Label14.TabIndex = 50;
			this.Label14.Text = "TH";
			this.Label15 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label15
			// 
			this.Label15.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.Label15.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label15.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label15.Name = "Label15";
			this.Label15.TabIndex = 49;
			this.Label15.Text = "SU";
			this.Label16 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label16
			// 
			this.Label16.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.Label16.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label16.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label16.Name = "Label16";
			this.Label16.TabIndex = 48;
			this.Label16.Text = "SA";
			this.Label17 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label17
			// 
			this.Label17.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.Label17.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label17.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label17.Name = "Label17";
			this.Label17.TabIndex = 47;
			this.Label17.Text = "WE";
			this.Label18 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label18
			// 
			this.Label18.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.Label18.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label18.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label18.Name = "Label18";
			this.Label18.TabIndex = 46;
			this.Label18.Text = "TU";
			this.Label19 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label19
			// 
			this.Label19.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.Label19.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label19.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label19.Name = "Label19";
			this.Label19.TabIndex = 45;
			this.Label19.Text = "MO";
			this._Label35_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.cboNotify = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboNotify
			// 
			this.cboNotify.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboNotify.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboNotify.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboNotify.Name = "cboNotify";
			this.cboNotify.TabIndex = 1;
			this.cboNameList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboNameList
			// 
			this.cboNameList.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboNameList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboNameList.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboNameList.Name = "cboNameList";
			this.cboNameList.TabIndex = 0;
			this.sprWeek2 = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprWeek2.MaxRows = 12;
			this.sprWeek2.TabIndex = 3;
			this.sprWeek2.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprWeek1 = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprWeek1.MaxRows = 12;
			this.sprWeek1.TabIndex = 2;
			this.sprWeek1.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.txtStep = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtStep.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtStep.Enabled = false;
			this.txtStep.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtStep.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtStep.Name = "txtStep";
			this.txtStep.TabIndex = 18;
			this.txtStep.Text = "txtStep";
			this.txtJobCode = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtJobCode.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtJobCode.Enabled = false;
			this.txtJobCode.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtJobCode.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtJobCode.Name = "txtJobCode";
			this.txtJobCode.TabIndex = 17;
			this.txtJobCode.Text = "txtJobCode";
			this.txtEmpName = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtEmpName.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtEmpName.Enabled = false;
			this.txtEmpName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtEmpName.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtEmpName.Name = "txtEmpName";
			this.txtEmpName.TabIndex = 14;
			this.txtEmpName.Text = "txtEmpName";
			this.txtEmplNum = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtEmplNum.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtEmplNum.Enabled = false;
			this.txtEmplNum.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtEmplNum.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtEmplNum.Name = "txtEmplNum";
			this.txtEmplNum.TabIndex = 13;
			this.txtEmplNum.Text = "txtEmplNum";
			this.lbVerify = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbVerify
			// 
			this.lbVerify.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbVerify.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbVerify.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.lbVerify.Name = "lbVerify";
			this.lbVerify.TabIndex = 97;
			this.lbVerify.Text = "PAYROLL WAS ACCEPTED ON MM/DD/YYYY";
			this.lbVerify.Visible = false;
			this.lblPayRate = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lblPayRate
			// 
			this.lblPayRate.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lblPayRate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lblPayRate.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblPayRate.Name = "lblPayRate";
			this.lblPayRate.TabIndex = 26;
			this.lblPayRate.Text = "lblPayRate";
			this.lblPayRate.Visible = false;
			this.lblCostCenter = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lblCostCenter
			// 
			this.lblCostCenter.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lblCostCenter.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lblCostCenter.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblCostCenter.Name = "lblCostCenter";
			this.lblCostCenter.TabIndex = 25;
			this.lblCostCenter.Text = "lblCostCenter";
			this.lblCostCenter.Visible = false;
			this._Label3_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbJobCodeDescription = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbJobCodeDescription
			// 
			this.lbJobCodeDescription.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.lbJobCodeDescription.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbJobCodeDescription.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.lbJobCodeDescription.Name = "lbJobCodeDescription";
			this.lbJobCodeDescription.TabIndex = 19;
			this.lbJobCodeDescription.Text = "lbJobCodeDescription";
			this._Label3_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label3_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label3_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label3_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 8.4F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 99;
			this.Label4.Text = "** Note:  Default list is operations only...";
			this._Label3_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbTotalHrs = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbTotalHrs
			// 
			this.lbTotalHrs.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbTotalHrs.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbTotalHrs.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.lbTotalHrs.Name = "lbTotalHrs";
			this.lbTotalHrs.TabIndex = 22;
			this.lbTotalHrs.Text = "txtTotalHrs";
			this._Label3_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 9;
			this.Label2.Text = "Week 2:";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 8;
			this.Label1.Text = "Week 1:";
			this.lbSearch = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSearch
			// 
			this.lbSearch.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSearch.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbSearch.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.lbSearch.Name = "lbSearch";
			this.lbSearch.TabIndex = 5;
			this.lbSearch.Text = "Select Pay Period";
			this._Label11_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.sprWeek1_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprWeek1_Sheet1.SheetName = "Sheet1";
			this.sprWeek1_Sheet1.ColumnHeader.Cells[0, 0].Value = "Activity";
			this.sprWeek1_Sheet1.ColumnHeader.Cells[0, 1].Value = "Cost Center";
			this.sprWeek1_Sheet1.ColumnHeader.Cells[0, 2].Value = "WBS Element";
			this.sprWeek1_Sheet1.ColumnHeader.Cells[0, 3].Value = "Order";
			this.sprWeek1_Sheet1.ColumnHeader.Cells[0, 4].Value = "Operation";
			this.sprWeek1_Sheet1.ColumnHeader.Cells[0, 5].Value = "A/A Type";
			this.sprWeek1_Sheet1.ColumnHeader.Cells[0, 6].Value = "PS Group";
			this.sprWeek1_Sheet1.ColumnHeader.Cells[0, 7].Value = "Level";
			this.sprWeek1_Sheet1.ColumnHeader.Cells[0, 8].Value = "MO";
			this.sprWeek1_Sheet1.ColumnHeader.Cells[0, 9].Value = "TU";
			this.sprWeek1_Sheet1.ColumnHeader.Cells[0, 10].Value = "WE";
			this.sprWeek1_Sheet1.ColumnHeader.Cells[0, 11].Value = "TH";
			this.sprWeek1_Sheet1.ColumnHeader.Cells[0, 12].Value = "FR";
			this.sprWeek1_Sheet1.ColumnHeader.Cells[0, 13].Value = "SA";
			this.sprWeek1_Sheet1.ColumnHeader.Cells[0, 14].Value = "SU";
			this.sprWeek1_Sheet1.ColumnHeader.Cells[0, 15].Value = "MonID";
			this.sprWeek1_Sheet1.ColumnHeader.Cells[0, 16].Value = "TueID";
			this.sprWeek1_Sheet1.ColumnHeader.Cells[0, 17].Value = "WedID";
			this.sprWeek1_Sheet1.ColumnHeader.Cells[0, 18].Value = "ThrID";
			this.sprWeek1_Sheet1.ColumnHeader.Cells[0, 19].Value = "FriID";
			this.sprWeek1_Sheet1.ColumnHeader.Cells[0, 20].Value = "SatID";
			this.sprWeek1_Sheet1.ColumnHeader.Cells[0, 21].Value = "SunID";
			this.sprWeek1_Sheet1.Columns.Get(0).Label = "Activity";
			this.sprWeek1_Sheet1.Columns.Get(0).Width = 53F;
			this.sprWeek1_Sheet1.Columns.Get(2).Label = "WBS Element";
			this.sprWeek1_Sheet1.Columns.Get(2).Width = 81F;
			this.sprWeek1_Sheet1.Columns.Get(3).Label = "Order";
			this.sprWeek1_Sheet1.Columns.Get(3).Width = 63F;
			this.sprWeek1_Sheet1.Columns.Get(7).Label = "Level";
			this.sprWeek1_Sheet1.Columns.Get(7).Width = 43F;
			this.sprWeek1_Sheet1.Columns.Get(8).Label = "MO";
			this.sprWeek1_Sheet1.Columns.Get(8).Width = 30F;
			this.sprWeek1_Sheet1.Columns.Get(9).Label = "TU";
			this.sprWeek1_Sheet1.Columns.Get(9).Width = 28F;
			this.sprWeek1_Sheet1.Columns.Get(10).Label = "WE";
			this.sprWeek1_Sheet1.Columns.Get(10).Width = 33F;
			this.sprWeek1_Sheet1.Columns.Get(11).Label = "TH";
			this.sprWeek1_Sheet1.Columns.Get(11).Width = 32F;
			this.sprWeek1_Sheet1.Columns.Get(12).Label = "FR";
			this.sprWeek1_Sheet1.Columns.Get(12).Width = 28F;
			this.sprWeek1_Sheet1.Columns.Get(13).Label = "SA";
			this.sprWeek1_Sheet1.Columns.Get(13).Width = 30F;
			this.sprWeek1_Sheet1.Columns.Get(14).Label = "SU";
			this.sprWeek1_Sheet1.Columns.Get(14).Width = 26F;
			this.sprWeek1_Sheet1.Columns.Get(15).Label = "MonID";
            //SortIndicator is OBSOLETE
            //this.sprWeek1_Sheet1.Columns.Get(15).SortIndicator = FarPoint.ViewModels.SortIndicator.Ascending;
            this.sprWeek1_Sheet1.Columns.Get(15).Visible = false;
			this.sprWeek1_Sheet1.Columns.Get(15).Width = 0F;
			this.sprWeek1_Sheet1.Columns.Get(16).Label = "TueID";
			//this.sprWeek1_Sheet1.Columns.Get(16).SortIndicator = FarPoint.ViewModels.SortIndicator.Ascending;
			this.sprWeek1_Sheet1.Columns.Get(16).Visible = false;
			this.sprWeek1_Sheet1.Columns.Get(16).Width = 0F;
			this.sprWeek1_Sheet1.Columns.Get(17).Label = "WedID";
			//this.sprWeek1_Sheet1.Columns.Get(17).SortIndicator = FarPoint.ViewModels.SortIndicator.Ascending;
			this.sprWeek1_Sheet1.Columns.Get(17).Visible = false;
			this.sprWeek1_Sheet1.Columns.Get(17).Width = 0F;
			this.sprWeek1_Sheet1.Columns.Get(18).Label = "ThrID";
			//this.sprWeek1_Sheet1.Columns.Get(18).SortIndicator = FarPoint.ViewModels.SortIndicator.Ascending;
			this.sprWeek1_Sheet1.Columns.Get(18).Visible = false;
			this.sprWeek1_Sheet1.Columns.Get(18).Width = 0F;
			this.sprWeek1_Sheet1.Columns.Get(19).Label = "FriID";
			//this.sprWeek1_Sheet1.Columns.Get(19).SortIndicator = FarPoint.ViewModels.SortIndicator.Ascending;
			this.sprWeek1_Sheet1.Columns.Get(19).Visible = false;
			this.sprWeek1_Sheet1.Columns.Get(19).Width = 0F;
			this.sprWeek1_Sheet1.Columns.Get(20).Label = "SatID";
			//this.sprWeek1_Sheet1.Columns.Get(20).SortIndicator = FarPoint.ViewModels.SortIndicator.Ascending;
			this.sprWeek1_Sheet1.Columns.Get(20).Visible = false;
			this.sprWeek1_Sheet1.Columns.Get(20).Width = 0F;
			this.sprWeek1_Sheet1.Columns.Get(21).Label = "SunID";
			//this.sprWeek1_Sheet1.Columns.Get(21).SortIndicator = FarPoint.ViewModels.SortIndicator.Ascending;
			this.sprWeek1_Sheet1.Columns.Get(21).Visible = false;
			this.sprWeek1_Sheet1.Columns.Get(21).Width = 0F;
			this.sprWeek1_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprWeek1_Sheet1.Rows.Get(0).Height = 14F;
			this.sprWeek1_Sheet1.Rows.Get(3).Height = 14F;
			this.sprWeek2_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprWeek2_Sheet1.SheetName = "Sheet1";
			this.sprWeek2_Sheet1.ColumnHeader.Cells[0, 0].Value = "Activity";
			this.sprWeek2_Sheet1.ColumnHeader.Cells[0, 1].Value = "Cost Center";
			this.sprWeek2_Sheet1.ColumnHeader.Cells[0, 2].Value = "WBS Element";
			this.sprWeek2_Sheet1.ColumnHeader.Cells[0, 3].Value = "Order";
			this.sprWeek2_Sheet1.ColumnHeader.Cells[0, 4].Value = "Operation";
			this.sprWeek2_Sheet1.ColumnHeader.Cells[0, 5].Value = "A/A Type";
			this.sprWeek2_Sheet1.ColumnHeader.Cells[0, 6].Value = "PS Group";
			this.sprWeek2_Sheet1.ColumnHeader.Cells[0, 7].Value = "Level";
			this.sprWeek2_Sheet1.ColumnHeader.Cells[0, 8].Value = "MO";
			this.sprWeek2_Sheet1.ColumnHeader.Cells[0, 9].Value = "TU";
			this.sprWeek2_Sheet1.ColumnHeader.Cells[0, 10].Value = "WE";
			this.sprWeek2_Sheet1.ColumnHeader.Cells[0, 11].Value = "TH";
			this.sprWeek2_Sheet1.ColumnHeader.Cells[0, 12].Value = "FR";
			this.sprWeek2_Sheet1.ColumnHeader.Cells[0, 13].Value = "SA";
			this.sprWeek2_Sheet1.ColumnHeader.Cells[0, 14].Value = "SU";
			this.sprWeek2_Sheet1.ColumnHeader.Cells[0, 15].Value = "MonID";
			this.sprWeek2_Sheet1.ColumnHeader.Cells[0, 16].Value = "TueID";
			this.sprWeek2_Sheet1.ColumnHeader.Cells[0, 17].Value = "WedID";
			this.sprWeek2_Sheet1.ColumnHeader.Cells[0, 18].Value = "ThrID";
			this.sprWeek2_Sheet1.ColumnHeader.Cells[0, 19].Value = "FriID";
			this.sprWeek2_Sheet1.ColumnHeader.Cells[0, 20].Value = "SatID";
			this.sprWeek2_Sheet1.ColumnHeader.Cells[0, 21].Value = "SunID";
			this.sprWeek2_Sheet1.Columns.Get(0).Label = "Activity";
			this.sprWeek2_Sheet1.Columns.Get(0).Width = 53F;
			this.sprWeek2_Sheet1.Columns.Get(2).Label = "WBS Element";
			this.sprWeek2_Sheet1.Columns.Get(2).Width = 81F;
			this.sprWeek2_Sheet1.Columns.Get(3).Label = "Order";
			this.sprWeek2_Sheet1.Columns.Get(3).Width = 63F;
			this.sprWeek2_Sheet1.Columns.Get(7).Label = "Level";
			this.sprWeek2_Sheet1.Columns.Get(7).Width = 43F;
			this.sprWeek2_Sheet1.Columns.Get(8).Label = "MO";
			this.sprWeek2_Sheet1.Columns.Get(8).Width = 30F;
			this.sprWeek2_Sheet1.Columns.Get(9).Label = "TU";
			this.sprWeek2_Sheet1.Columns.Get(9).Width = 28F;
			this.sprWeek2_Sheet1.Columns.Get(10).Label = "WE";
			this.sprWeek2_Sheet1.Columns.Get(10).Width = 33F;
			this.sprWeek2_Sheet1.Columns.Get(11).Label = "TH";
			this.sprWeek2_Sheet1.Columns.Get(11).Width = 32F;
			this.sprWeek2_Sheet1.Columns.Get(12).Label = "FR";
			this.sprWeek2_Sheet1.Columns.Get(12).Width = 28F;
			this.sprWeek2_Sheet1.Columns.Get(13).Label = "SA";
			this.sprWeek2_Sheet1.Columns.Get(13).Width = 30F;
			this.sprWeek2_Sheet1.Columns.Get(14).Label = "SU";
			this.sprWeek2_Sheet1.Columns.Get(14).Width = 26F;
			this.sprWeek2_Sheet1.Columns.Get(15).Label = "MonID";
			//this.sprWeek2_Sheet1.Columns.Get(15).SortIndicator = FarPoint.ViewModels.SortIndicator.Descending;
			this.sprWeek2_Sheet1.Columns.Get(15).Visible = false;
			this.sprWeek2_Sheet1.Columns.Get(15).Width = 0F;
			this.sprWeek2_Sheet1.Columns.Get(16).Label = "TueID";
			//this.sprWeek2_Sheet1.Columns.Get(16).SortIndicator = FarPoint.ViewModels.SortIndicator.Descending;
			this.sprWeek2_Sheet1.Columns.Get(16).Visible = false;
			this.sprWeek2_Sheet1.Columns.Get(16).Width = 0F;
			this.sprWeek2_Sheet1.Columns.Get(17).Label = "WedID";
			//this.sprWeek2_Sheet1.Columns.Get(17).SortIndicator = FarPoint.ViewModels.SortIndicator.Descending;
			this.sprWeek2_Sheet1.Columns.Get(17).Visible = false;
			this.sprWeek2_Sheet1.Columns.Get(17).Width = 0F;
			this.sprWeek2_Sheet1.Columns.Get(18).Label = "ThrID";
			//this.sprWeek2_Sheet1.Columns.Get(18).SortIndicator = FarPoint.ViewModels.SortIndicator.Descending;
			this.sprWeek2_Sheet1.Columns.Get(18).Visible = false;
			this.sprWeek2_Sheet1.Columns.Get(18).Width = 0F;
			this.sprWeek2_Sheet1.Columns.Get(19).Label = "FriID";
			//this.sprWeek2_Sheet1.Columns.Get(19).SortIndicator = FarPoint.ViewModels.SortIndicator.Descending;
			this.sprWeek2_Sheet1.Columns.Get(19).Visible = false;
			this.sprWeek2_Sheet1.Columns.Get(19).Width = 0F;
			this.sprWeek2_Sheet1.Columns.Get(20).Label = "SatID";
			//this.sprWeek2_Sheet1.Columns.Get(20).SortIndicator = FarPoint.ViewModels.SortIndicator.Descending;
			this.sprWeek2_Sheet1.Columns.Get(20).Visible = false;
			this.sprWeek2_Sheet1.Columns.Get(20).Width = 0F;
			this.sprWeek2_Sheet1.Columns.Get(21).Label = "SunID";
			////this.sprWeek2_Sheet1.Columns.Get(21).SortIndicator = FarPoint.ViewModels.SortIndicator.Descending;
			this.sprWeek2_Sheet1.Columns.Get(21).Visible = false;
			this.sprWeek2_Sheet1.Columns.Get(21).Width = 0F;
			this.sprWeek2_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprWeek2_Sheet1.Rows.Get(0).Height = 14F;
			this.sprWeek2_Sheet1.Rows.Get(3).Height = 14F;
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
			this.sprTimeSheet_Sheet1.Cells.Get(15, 4).Value = "WEEK 2";
			this.sprTimeSheet_Sheet1.Cells.Get(16, 0).Value = "ACTIVITY";
			this.sprTimeSheet_Sheet1.Cells.Get(16, 1).Value = "COST CENTER";
			this.sprTimeSheet_Sheet1.Cells.Get(16, 2).Value = "WBS ELEMENT";
			this.sprTimeSheet_Sheet1.Cells.Get(16, 3).Value = "ORDER";
			this.sprTimeSheet_Sheet1.Cells.Get(16, 4).Value = "OPERATION";
			this.sprTimeSheet_Sheet1.Cells.Get(16, 5).Value = "A/A TYPE";
			this.sprTimeSheet_Sheet1.Cells.Get(16, 6).Value = "PS GROUP";
			this.sprTimeSheet_Sheet1.Cells.Get(16, 7).Value = "LEVEL";
			this.sprTimeSheet_Sheet1.Cells.Get(16, 8).Value = "MO";
			this.sprTimeSheet_Sheet1.Cells.Get(16, 9).Value = "TU";
			this.sprTimeSheet_Sheet1.Cells.Get(16, 10).Value = "WE";
			this.sprTimeSheet_Sheet1.Cells.Get(16, 11).Value = "TH";
			this.sprTimeSheet_Sheet1.Cells.Get(16, 12).Value = "FR";
			this.sprTimeSheet_Sheet1.Cells.Get(16, 13).Value = "SA";
			this.sprTimeSheet_Sheet1.Cells.Get(16, 14).Value = "SU";
			this.sprTimeSheet_Sheet1.Cells.Get(30, 0).Value = "EMPLOYEE:";
			//this.sprTimeSheet_Sheet1.Cells.Get(30, 1).ColumnSpan = 4;
			this.sprTimeSheet_Sheet1.Cells.Get(30, 1).Value = "_________________________________________";
			this.sprTimeSheet_Sheet1.Cells.Get(30, 5).Value = "SUPERVISOR:";
			//this.sprTimeSheet_Sheet1.Cells.Get(30, 6).ColumnSpan = 7;
			this.sprTimeSheet_Sheet1.Cells.Get(30, 6).Value = "________________________________________________________________________________";
			this.sprTimeSheet_Sheet1.ColumnHeader.Rows.Get(0).Height = 0F;
			this.sprTimeSheet_Sheet1.Columns.Get(0).Width = 90F;
			this.sprTimeSheet_Sheet1.Columns.Get(1).Width = 104F;
			this.sprTimeSheet_Sheet1.Columns.Get(2).Width = 102F;
			this.sprTimeSheet_Sheet1.Columns.Get(3).Width = 105F;
			this.sprTimeSheet_Sheet1.Columns.Get(4).Width = 86F;
			this.sprTimeSheet_Sheet1.Columns.Get(5).Width = 90F;
			this.sprTimeSheet_Sheet1.Columns.Get(6).Width = 75F;
			this.sprTimeSheet_Sheet1.Columns.Get(7).Width = 46F;
			this.sprTimeSheet_Sheet1.Columns.Get(8).StyleName = "Static1171636234725132262928";
			this.sprTimeSheet_Sheet1.Columns.Get(8).Width = 42F;
			this.sprTimeSheet_Sheet1.Columns.Get(9).StyleName = "Static1171636234725132262928";
			this.sprTimeSheet_Sheet1.Columns.Get(9).Width = 42F;
			this.sprTimeSheet_Sheet1.Columns.Get(10).StyleName = "Static1171636234725132262928";
			this.sprTimeSheet_Sheet1.Columns.Get(10).Width = 42F;
			this.sprTimeSheet_Sheet1.Columns.Get(11).StyleName = "Static1171636234725132262928";
			this.sprTimeSheet_Sheet1.Columns.Get(11).Width = 42F;
			this.sprTimeSheet_Sheet1.Columns.Get(12).StyleName = "Static1171636234725132262928";
			this.sprTimeSheet_Sheet1.Columns.Get(12).Width = 42F;
			this.sprTimeSheet_Sheet1.Columns.Get(13).StyleName = "Static1171636234725132262928";
			this.sprTimeSheet_Sheet1.Columns.Get(13).Width = 42F;
			this.sprTimeSheet_Sheet1.Columns.Get(14).StyleName = "Static1171636234725132262928";
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
			this.chkAllEmp = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkAllEmp
			// 
			this.chkAllEmp.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.chkAllEmp.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkAllEmp.ForeColor = UpgradeHelpers.Helpers.Color.Lime;
			this.chkAllEmp.Name = "chkAllEmp";
			this.chkAllEmp.TabIndex = 98;
			this.chkAllEmp.Text = "Display All Employees";
			this.cmdApply2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdApply2
			// 
			this.cmdApply2.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdApply2.Enabled = false;
			this.cmdApply2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdApply2.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdApply2.Name = "cmdApply2";
			this.cmdApply2.TabIndex = 62;
			this.cmdApply2.Text = "Apply Changes";
			this.cmdApply1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdApply1
			// 
			this.cmdApply1.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdApply1.Enabled = false;
			this.cmdApply1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdApply1.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdApply1.Name = "cmdApply1";
			this.cmdApply1.TabIndex = 29;
			this.cmdApply1.Text = "Apply Changes";
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 7;
			this.cmdClose.Text = "&Close";
			this.cmdPrint = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrint.Enabled = false;
			this.cmdPrint.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrint.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.TabIndex = 6;
			this.cmdPrint.Text = "&Print";
			this.cmdVerify = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdVerify
			// 
			this.cmdVerify.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdVerify.Enabled = false;
			this.cmdVerify.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.6F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdVerify.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdVerify.Name = "cmdVerify";
			this.cmdVerify.TabIndex = 94;
			this.cmdVerify.Text = "Accept Payroll";
			this.cmdVerify.Visible = false;
			this.cmdUpload = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdUpload
			// 
			this.cmdUpload.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdUpload.Enabled = false;
			this.cmdUpload.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.6F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdUpload.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdUpload.Name = "cmdUpload";
			this.cmdUpload.TabIndex = 93;
			this.cmdUpload.Text = "&Upload Payroll";
			this.cmdUpload.Visible = false;
			this.cmdApprove = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdApprove
			// 
			this.cmdApprove.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdApprove.Enabled = false;
			this.cmdApprove.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.6F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdApprove.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdApprove.Name = "cmdApprove";
			this.cmdApprove.TabIndex = 23;
			this.cmdApprove.Text = "&Save Timecard";
			this.Text = "Review Individual Time Cards";
			this.CurrPersID = 0;
			this.CurrStartDate = "";
			this.CurrEndDate = "";
			this.DateArray = new object[14, 3];
			this.SpecialEndDate = System.DateTime.FromOADate(0);
			this.PayRollExist = false;
			this.CurrSAPCode = "";
			this.CurrRow1 = 0;
			this.CurrRow2 = 0;
			this.frmWeek1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmWeek1
			// 
			this.frmWeek1.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.frmWeek1.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmWeek1.Name = "frmWeek1";
			this.frmWeek1.TabIndex = 27;
			this.frmWeek1.Visible = false;
			this.frmWeek2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmWeek2
			// 
			this.frmWeek2.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.frmWeek2.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmWeek2.Name = "frmWeek2";
			this.frmWeek2.TabIndex = 60;
			this.frmWeek2.Visible = false;
			this.NeedFillerCode = false;
			this.NeedAdjustment = false;
			this.OverAmount = 0;
			this.UnderAmount = 0;
			this.SetLimit = false;
			this.CurrLeaveTotal = 0;
			this.CurrentUnit = "";
			this.CurrEmpID = "";
			this.SchedTime = "";
			this.CurrFillerCode = "";
			this.CurrPayPeriod = 0;
			this.HasAuthority = false;
			this.RecordIsMurrayMorganWO = false;
			this.SelectedRow = 0;
			this.SelectedRow2 = 0;
			this.CurrUnit = "";
			Label35 = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(2);
			Label35[1] = _Label35_1;
			Label35[0] = _Label35_0;
			Label35[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label35[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label35[1].ForeColor = UpgradeHelpers.Helpers.Color.Lime;
			Label35[1].Name = "_Label35_1";
			Label35[1].TabIndex = 77;
			Label35[1].Text = "To Delete ~ set hours to zero";
			Label35[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label35[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label35[0].ForeColor = UpgradeHelpers.Helpers.Color.Lime;
			Label35[0].Name = "_Label35_0";
			Label35[0].TabIndex = 44;
			Label35[0].Text = "To Delete ~ set hours to zero";
			Label3 = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(7);
			Label3[2] = _Label3_2;
			Label3[4] = _Label3_4;
			Label3[3] = _Label3_3;
			Label3[1] = _Label3_1;
			Label3[0] = _Label3_0;
			Label3[6] = _Label3_6;
			Label3[5] = _Label3_5;
			Label3[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			Label3[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label3[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			Label3[2].Name = "_Label3_2";
			Label3[2].TabIndex = 20;
			Label3[2].Text = "Assignment";
			Label3[4].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			Label3[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label3[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			Label3[4].Name = "_Label3_4";
			Label3[4].TabIndex = 16;
			Label3[4].Text = "Level";
			Label3[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			Label3[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label3[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			Label3[3].Name = "_Label3_3";
			Label3[3].TabIndex = 15;
			Label3[3].Text = "PS Group";
			Label3[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			Label3[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label3[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			Label3[1].Name = "_Label3_1";
			Label3[1].TabIndex = 12;
			Label3[1].Text = "Employee Name";
			Label3[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			Label3[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label3[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			Label3[0].Name = "_Label3_0";
			Label3[0].TabIndex = 11;
			Label3[0].Text = "Number";
			Label3[6].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label3[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label3[6].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			Label3[6].Name = "_Label3_6";
			Label3[6].TabIndex = 96;
			Label3[6].Text = "Select Payroll Yr";
			Label3[5].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			Label3[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label3[5].ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			Label3[5].Name = "_Label3_5";
			Label3[5].TabIndex = 21;
			Label3[5].Text = "Total Hours:";
			Label20 = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(2);
			Label20[1] = _Label20_1;
			Label20[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			Label20[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label20[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			Label20[1].Name = "_Label20_1";
			Label20[1].TabIndex = 59;
			Label20[1].Text = "Activity";
			Label11 = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(2);
			Label11[1] = _Label11_1;
			Label11[0] = _Label11_0;
			Label11[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			Label11[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label11[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			Label11[1].Name = "_Label11_1";
			Label11[1].TabIndex = 58;
			Label11[1].Text = "Cost Cntr";
			Label11[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label11[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label11[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			Label11[0].Name = "_Label11_0";
			Label11[0].TabIndex = 4;
			Label11[0].Text = "Select Employee";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color59636234725132204344", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Courier New", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text337636234725132223872", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Courier New", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1171636234725132262928");
			namedStyle3.CellType = textCellType2;
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.Renderer = textCellType2;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1728636234725132321512");
			namedStyle4.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1768636234725132331276");
			namedStyle5.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle5.CellType = textCellType3;
			namedStyle5.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.Renderer = textCellType3;
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1827636234725132350804");
			namedStyle6.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle6.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle7 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1867636234725132370332");
			namedStyle7.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle7.CellType = textCellType4;
			namedStyle7.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle7.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle7.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle7.Renderer = textCellType4;
			namedStyle7.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle8 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1932636234725132380096");
			namedStyle8.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle8.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle8.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle9 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1972636234725132467972");
			namedStyle9.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle9.CellType = textCellType5;
			namedStyle9.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle9.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle9.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle9.Renderer = textCellType5;
			namedStyle9.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle10 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3030636234725132673016");
			namedStyle10.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle10.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle10.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle10.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle10.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle11 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3070636234725132682780");
			namedStyle11.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle11.CellType = textCellType6;
			namedStyle11.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle11.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle11.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle11.Renderer = textCellType6;
			namedStyle11.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle12 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3156636234725132692544");
			namedStyle12.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle12.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle12.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle12.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle12.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle13 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3196636234725132702308");
			namedStyle13.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle13.CellType = textCellType7;
			namedStyle13.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle13.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle13.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle13.Renderer = textCellType7;
			namedStyle13.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle14 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3234636234725132702308");
			namedStyle14.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle14.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle14.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle14.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle14.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle15 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3274636234725132712072");
			namedStyle15.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle15.CellType = textCellType8;
			namedStyle15.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle15.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle15.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle15.Renderer = textCellType8;
			namedStyle15.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle16 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3352636234725132721836");
			namedStyle16.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle16.CellType = textCellType9;
			namedStyle16.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle16.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle16.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle16.Renderer = textCellType9;
			namedStyle16.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle17 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx156636234725132868296");
			namedStyle17.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle17.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle17.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle17.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle17.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle18 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static196636234725132868296");
			namedStyle18.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle18.CellType = textCellType10;
			namedStyle18.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle18.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle18.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle18.Renderer = textCellType10;
			namedStyle18.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle19 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color236636234725132878060");
			namedStyle19.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle19.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle19.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle19.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle19.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle20 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx303636234725132887824");
			namedStyle20.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle20.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle20.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle21 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static321636234725132887824");
			namedStyle21.CellType = textCellType11;
			namedStyle21.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle21.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle21.Renderer = textCellType11;
			namedStyle21.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle22 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx359636234725132897588");
			namedStyle22.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle22.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle22.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle23 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static377636234725132907352");
			namedStyle23.CellType = textCellType12;
			namedStyle23.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle23.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle23.Renderer = textCellType12;
			namedStyle23.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle24 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1108636234725133044048");
			namedStyle24.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle24.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle24.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle25 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1126636234725133053812");
			namedStyle25.CellType = textCellType13;
			namedStyle25.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle25.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle25.Renderer = textCellType13;
			namedStyle25.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle26 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1211636234725133063576");
			namedStyle26.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle26.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle26.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle26.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle26.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle27 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1251636234725133073340");
			namedStyle27.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle27.CellType = textCellType14;
			namedStyle27.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle27.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle27.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle27.Renderer = textCellType14;
			namedStyle27.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle28 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1312636234725133083104");
			namedStyle28.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle28.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle28.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle29 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2732636234725133356496");
			namedStyle29.CellType = textCellType15;
			namedStyle29.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle29.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle29.Renderer = textCellType15;
			namedStyle29.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle30 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx928636234725135182364");
			namedStyle30.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle30.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle30.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle30.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle30.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle31 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static968636234725135192128");
			namedStyle31.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle31.CellType = textCellType16;
			namedStyle31.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle31.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle31.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle31.Renderer = textCellType16;
			namedStyle31.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle32 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3312636234725132712072");
			namedStyle32.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle32.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle32.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle32.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle32.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle33 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1069636234725135211656");
			namedStyle33.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle33.CellType = textCellType17;
			namedStyle33.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle33.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle33.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle33.Renderer = textCellType17;
			namedStyle33.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle34 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1133636234725135221420");
			namedStyle34.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle34.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle34.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle35 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2307636234725135416700");
			namedStyle35.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle35.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle35.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle35.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle35.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle36 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2347636234725135426464");
			namedStyle36.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle36.CellType = textCellType18;
			namedStyle36.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle36.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle36.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle36.Renderer = textCellType18;
			namedStyle36.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle37 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx333636234725137174220");
			namedStyle37.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Courier New", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle37.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle37.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle37.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle38 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static966636234725137262096");
			namedStyle38.CellType = textCellType19;
			namedStyle38.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Courier New", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle38.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle38.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle38.Renderer = textCellType19;
			namedStyle38.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle39 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1046636234725137262096");
			namedStyle39.CellType = textCellType20;
			namedStyle39.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle39.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle39.Renderer = textCellType20;
			namedStyle39.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Bottom;
			namedStyle40 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1158636234725137281624");
			namedStyle40.CellType = textCellType21;
			namedStyle40.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle40.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle40.Renderer = textCellType21;
			namedStyle40.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle41 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1308636234725137320680");
			namedStyle41.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle41.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle41.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle42 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1326636234725137349972");
			namedStyle42.CellType = textCellType22;
			namedStyle42.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle42.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle42.Renderer = textCellType22;
			namedStyle42.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle43 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234725043615572", "DataAreaDefault");
			namedStyle43.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F);
			namedStyle43.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle43.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle43.Parent = "DataAreaDefault";
			namedStyle43.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle44 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text291636234725043625336", "DataAreaDefault");
			namedStyle44.CellType = textCellType23;
			namedStyle44.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F);
			namedStyle44.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle44.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle44.Parent = "DataAreaDefault";
			namedStyle44.Renderer = textCellType23;
			namedStyle44.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle45 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234724928478484", "DataAreaDefault");
			namedStyle45.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F);
			namedStyle45.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle45.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle45.Parent = "DataAreaDefault";
			namedStyle45.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle46 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text291636234724928488248", "DataAreaDefault");
			namedStyle46.CellType = textCellType24;
			namedStyle46.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F);
			namedStyle46.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle46.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle46.Parent = "DataAreaDefault";
			namedStyle46.Renderer = textCellType24;
			namedStyle46.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			this.Name = "PTSProject.frmIndTimeCard";
			IsMdiChild = true;
			this.sprTimeSheet.NamedStyles.Add(namedStyle1);
			this.sprTimeSheet.NamedStyles.Add(namedStyle2);
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
			this.sprTimeSheet.Sheets.Add(this.sprTimeSheet_Sheet1);
			this.sprWeek2.NamedStyles.Add(namedStyle43);
			this.sprWeek2.NamedStyles.Add(namedStyle44);
			this.sprWeek2.Sheets.Add(this.sprWeek2_Sheet1);
			this.sprWeek1.NamedStyles.Add(namedStyle45);
			this.sprWeek1.NamedStyles.Add(namedStyle46);
			this.sprWeek1.Sheets.Add(this.sprWeek1_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprTimeSheet { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboYear { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtWe2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtTu2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtMo2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtFr2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtTh2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboStep2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboJobCode2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboAAType2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtSu2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtSa2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtOper2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtWBSElement2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtCostCenter2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtActivity2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboOrder2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label36 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label21 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label22 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label23 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label24 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label25 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label26 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label27 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label28 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label29 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label30 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label31 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label32 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label33 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label34 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label35_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtActivity1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtCostCenter1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtWBSElement1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtOper1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtSa1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtSu1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboAAType1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboJobCode1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboStep1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtTh1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtFr1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtMo1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtTu1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtWe1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboOrder1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label20_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label11_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label13 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label14 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label15 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label16 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label17 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label18 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label19 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label35_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboNotify { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboNameList { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprWeek2 { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprWeek1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtStep { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtJobCode { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtEmpName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtEmplNum { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbVerify { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lblPayRate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lblCostCenter { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label3_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbJobCodeDescription { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label3_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label3_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label3_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label3_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label3_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbTotalHrs { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label3_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSearch { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label11_0 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprWeek1_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprWeek2_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprTimeSheet_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkAllEmp { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdApply2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdApply1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdVerify { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdUpload { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdApprove { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrPersID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrStartDate { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrEndDate { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Object[,] DateArray { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.DateTime SpecialEndDate { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean PayRollExist { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrSAPCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrRow1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrRow2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmWeek1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmWeek2 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean NeedFillerCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean NeedAdjustment { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Single OverAmount { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Single UnderAmount { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean SetLimit { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Single CurrLeaveTotal { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrentUnit { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrEmpID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String SchedTime { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrFillerCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrPayPeriod { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean HasAuthority { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean RecordIsMurrayMorganWO { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 SelectedRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 SelectedRow2 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrUnit { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> Label35 { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> Label3 { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> Label20 { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> Label11 { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}