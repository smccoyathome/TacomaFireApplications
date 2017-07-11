using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmDispatchPayroll))]
	public class frmDispatchPayrollViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var checkBoxCellType1 = ctx.Resolve<FarPoint.ViewModels.CheckBoxCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle49;
			var textCellType25 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle48;
			FarPoint.ViewModels.NamedStyle namedStyle47;
			var textCellType24 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle46;
			FarPoint.ViewModels.NamedStyle namedStyle45;
			var textCellType23 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle44;
			var textCellType22 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle43;
			var textCellType21 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle42;
			FarPoint.ViewModels.NamedStyle namedStyle41;
			var textCellType20 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle40;
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
			FarPoint.ViewModels.NamedStyle namedStyle23;
			var textCellType12 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle22;
			FarPoint.ViewModels.NamedStyle namedStyle21;
			var textCellType11 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
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
			FarPoint.ViewModels.NamedStyle namedStyle10;
			var textCellType5 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle9;
			FarPoint.ViewModels.NamedStyle namedStyle8;
			var textCellType4 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
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
			this.cboPayPeriod = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboPayPeriod
			// 
			this.cboPayPeriod.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboPayPeriod.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboPayPeriod.Name = "cboPayPeriod";
			this.cboPayPeriod.TabIndex = 69;
			this.cboPayPeriod.Text = "cboPayPeriod";
			this._Label6_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbCount = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbCount
			// 
			this.lbCount.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.lbCount.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbCount.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.lbCount.Name = "lbCount";
			this.lbCount.TabIndex = 70;
			this.lbCount.Text = "List Count:  ";
			this.frmFilterList = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmFilterList
			// 
			this.frmFilterList.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.frmFilterList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.frmFilterList.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.frmFilterList.Name = "frmFilterList";
			this.frmFilterList.TabIndex = 66;
			this.cboOrder1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboOrder1
			// 
			this.cboOrder1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboOrder1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboOrder1.Name = "cboOrder1";
			this.cboOrder1.TabIndex = 49;
			this.cboOrder1.Text = "cboOrder1";
			this.txtWe1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtWe1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtWe1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtWe1.Name = "txtWe1";
			this.txtWe1.TabIndex = 47;
			this.txtWe1.Text = "txtWe1";
			this.txtTu1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtTu1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtTu1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtTu1.Name = "txtTu1";
			this.txtTu1.TabIndex = 46;
			this.txtTu1.Text = "txtTu1";
			this.txtMo1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtMo1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtMo1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtMo1.Name = "txtMo1";
			this.txtMo1.TabIndex = 45;
			this.txtMo1.Text = "txtMo1";
			this.txtFr1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtFr1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtFr1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtFr1.Name = "txtFr1";
			this.txtFr1.TabIndex = 44;
			this.txtFr1.Text = "txtFr1";
			this.txtTh1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtTh1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtTh1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtTh1.Name = "txtTh1";
			this.txtTh1.TabIndex = 43;
			this.txtTh1.Text = "txtTh1";
			this.cboStep1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboStep1
			// 
			this.cboStep1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboStep1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboStep1.Name = "cboStep1";
			this.cboStep1.TabIndex = 42;
			this.cboStep1.Text = "cboStep1";
			this.cboJobCode1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboJobCode1
			// 
			this.cboJobCode1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboJobCode1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboJobCode1.Name = "cboJobCode1";
			this.cboJobCode1.TabIndex = 41;
			this.cboJobCode1.Text = "cboJobCode1";
			this.cboAAType1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboAAType1
			// 
			this.cboAAType1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboAAType1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboAAType1.Name = "cboAAType1";
			this.cboAAType1.TabIndex = 40;
			this.cboAAType1.Text = "cboAAType1";
			this.txtSu1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtSu1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtSu1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtSu1.Name = "txtSu1";
			this.txtSu1.TabIndex = 39;
			this.txtSu1.Text = "txtSu1";
			this.txtSa1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtSa1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtSa1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtSa1.Name = "txtSa1";
			this.txtSa1.TabIndex = 38;
			this.txtSa1.Text = "txtSa1";
			this.txtOper1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtOper1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtOper1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtOper1.Name = "txtOper1";
			this.txtOper1.TabIndex = 37;
			this.txtOper1.Text = "txtOper1";
			this.txtWBSElement1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtWBSElement1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtWBSElement1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtWBSElement1.Name = "txtWBSElement1";
			this.txtWBSElement1.TabIndex = 36;
			this.txtWBSElement1.Text = "txtWBSElement1";
			this.txtCostCenter1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtCostCenter1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtCostCenter1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtCostCenter1.Name = "txtCostCenter1";
			this.txtCostCenter1.TabIndex = 35;
			this.txtCostCenter1.Text = "txtCostCenter1";
			this.txtActivity1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtActivity1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtActivity1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtActivity1.Name = "txtActivity1";
			this.txtActivity1.TabIndex = 34;
			this.txtActivity1.Text = "txtActivity1";
			this._Label35_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.Label19 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label19
			// 
			this.Label19.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label19.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label19.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label19.Name = "Label19";
			this.Label19.TabIndex = 64;
			this.Label19.Text = "MO";
			this.Label18 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label18
			// 
			this.Label18.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label18.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label18.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label18.Name = "Label18";
			this.Label18.TabIndex = 63;
			this.Label18.Text = "TU";
			this.Label17 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label17
			// 
			this.Label17.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label17.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label17.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label17.Name = "Label17";
			this.Label17.TabIndex = 62;
			this.Label17.Text = "WE";
			this.Label16 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label16
			// 
			this.Label16.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label16.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label16.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label16.Name = "Label16";
			this.Label16.TabIndex = 61;
			this.Label16.Text = "SA";
			this.Label15 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label15
			// 
			this.Label15.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label15.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label15.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label15.Name = "Label15";
			this.Label15.TabIndex = 60;
			this.Label15.Text = "SU";
			this.Label14 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label14
			// 
			this.Label14.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label14.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label14.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label14.Name = "Label14";
			this.Label14.TabIndex = 59;
			this.Label14.Text = "TH";
			this.Label13 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label13
			// 
			this.Label13.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label13.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label13.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label13.Name = "Label13";
			this.Label13.TabIndex = 58;
			this.Label13.Text = "FR";
			this.Label12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label12
			// 
			this.Label12.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label12.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label12.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label12.Name = "Label12";
			this.Label12.TabIndex = 57;
			this.Label12.Text = "Level";
			this.Label10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label10
			// 
			this.Label10.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label10.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label10.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label10.Name = "Label10";
			this.Label10.TabIndex = 56;
			this.Label10.Text = "A/A Type (KOT)";
			this.Label9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label9
			// 
			this.Label9.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label9.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label9.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label9.Name = "Label9";
			this.Label9.TabIndex = 55;
			this.Label9.Text = "PS Group";
			this.Label8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label8
			// 
			this.Label8.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label8.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label8.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label8.Name = "Label8";
			this.Label8.TabIndex = 54;
			this.Label8.Text = "WBS Elemt";
			this.Label7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label7
			// 
			this.Label7.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label7.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label7.Name = "Label7";
			this.Label7.TabIndex = 53;
			this.Label7.Text = "Order";
			this.Label5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label5
			// 
			this.Label5.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label5.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label5.Name = "Label5";
			this.Label5.TabIndex = 52;
			this.Label5.Text = "Oper";
			this.Label11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label11
			// 
			this.Label11.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label11.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label11.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label11.Name = "Label11";
			this.Label11.TabIndex = 51;
			this.Label11.Text = "Cost Cntr";
			this.Label20 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label20
			// 
			this.Label20.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label20.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label20.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label20.Name = "Label20";
			this.Label20.TabIndex = 50;
			this.Label20.Text = "Activity";
			this.cboOrder2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboOrder2
			// 
			this.cboOrder2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboOrder2.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboOrder2.Name = "cboOrder2";
			this.cboOrder2.TabIndex = 16;
			this.cboOrder2.Text = "cboOrder2";
			this.txtActivity2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtActivity2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtActivity2.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtActivity2.Name = "txtActivity2";
			this.txtActivity2.TabIndex = 14;
			this.txtActivity2.Text = "txtActivity2";
			this.txtCostCenter2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtCostCenter2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtCostCenter2.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtCostCenter2.Name = "txtCostCenter2";
			this.txtCostCenter2.TabIndex = 13;
			this.txtCostCenter2.Text = "txtCostCenter2";
			this.txtWBSElement2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtWBSElement2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtWBSElement2.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtWBSElement2.Name = "txtWBSElement2";
			this.txtWBSElement2.TabIndex = 12;
			this.txtWBSElement2.Text = "txtWBSElement2";
			this.txtOper2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtOper2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtOper2.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtOper2.Name = "txtOper2";
			this.txtOper2.TabIndex = 11;
			this.txtOper2.Text = "txtOper2";
			this.txtSa2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtSa2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtSa2.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtSa2.Name = "txtSa2";
			this.txtSa2.TabIndex = 10;
			this.txtSa2.Text = "txtSa2";
			this.txtSu2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtSu2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtSu2.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtSu2.Name = "txtSu2";
			this.txtSu2.TabIndex = 9;
			this.txtSu2.Text = "txtSu2";
			this.cboAAType2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboAAType2
			// 
			this.cboAAType2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboAAType2.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboAAType2.Name = "cboAAType2";
			this.cboAAType2.TabIndex = 8;
			this.cboAAType2.Text = "cboAAType2";
			this.cboJobCode2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboJobCode2
			// 
			this.cboJobCode2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboJobCode2.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboJobCode2.Name = "cboJobCode2";
			this.cboJobCode2.TabIndex = 7;
			this.cboJobCode2.Text = "cboJobCode2";
			this.cboStep2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboStep2
			// 
			this.cboStep2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboStep2.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboStep2.Name = "cboStep2";
			this.cboStep2.TabIndex = 6;
			this.cboStep2.Text = "cboStep2";
			this.txtTh2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtTh2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtTh2.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtTh2.Name = "txtTh2";
			this.txtTh2.TabIndex = 5;
			this.txtTh2.Text = "txtTh2";
			this.txtFr2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtFr2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtFr2.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtFr2.Name = "txtFr2";
			this.txtFr2.TabIndex = 4;
			this.txtFr2.Text = "txtFr2";
			this.txtMo2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtMo2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtMo2.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtMo2.Name = "txtMo2";
			this.txtMo2.TabIndex = 3;
			this.txtMo2.Text = "txtMo2";
			this.txtTu2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtTu2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtTu2.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtTu2.Name = "txtTu2";
			this.txtTu2.TabIndex = 2;
			this.txtTu2.Text = "txtTu2";
			this.txtWe2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtWe2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtWe2.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtWe2.Name = "txtWe2";
			this.txtWe2.TabIndex = 1;
			this.txtWe2.Text = "txtWe2";
			this._Label35_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.Label34 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label34
			// 
			this.Label34.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label34.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label34.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label34.Name = "Label34";
			this.Label34.TabIndex = 31;
			this.Label34.Text = "Activity";
			this.Label33 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label33
			// 
			this.Label33.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label33.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label33.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label33.Name = "Label33";
			this.Label33.TabIndex = 30;
			this.Label33.Text = "Cost Cntr";
			this.Label32 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label32
			// 
			this.Label32.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label32.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label32.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label32.Name = "Label32";
			this.Label32.TabIndex = 29;
			this.Label32.Text = "Oper";
			this.Label31 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label31
			// 
			this.Label31.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label31.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label31.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label31.Name = "Label31";
			this.Label31.TabIndex = 28;
			this.Label31.Text = "Order";
			this.Label30 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label30
			// 
			this.Label30.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label30.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label30.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label30.Name = "Label30";
			this.Label30.TabIndex = 27;
			this.Label30.Text = "WBS Elemt";
			this.Label29 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label29
			// 
			this.Label29.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label29.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label29.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label29.Name = "Label29";
			this.Label29.TabIndex = 26;
			this.Label29.Text = "PS Group";
			this.Label28 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label28
			// 
			this.Label28.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label28.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label28.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label28.Name = "Label28";
			this.Label28.TabIndex = 25;
			this.Label28.Text = "A/A Type (KOT)";
			this.Label27 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label27
			// 
			this.Label27.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label27.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label27.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label27.Name = "Label27";
			this.Label27.TabIndex = 24;
			this.Label27.Text = "Level";
			this.Label26 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label26
			// 
			this.Label26.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label26.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label26.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label26.Name = "Label26";
			this.Label26.TabIndex = 23;
			this.Label26.Text = "FR";
			this.Label25 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label25
			// 
			this.Label25.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label25.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label25.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label25.Name = "Label25";
			this.Label25.TabIndex = 22;
			this.Label25.Text = "TH";
			this.Label24 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label24
			// 
			this.Label24.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label24.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label24.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label24.Name = "Label24";
			this.Label24.TabIndex = 21;
			this.Label24.Text = "SU";
			this.Label23 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label23
			// 
			this.Label23.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label23.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label23.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label23.Name = "Label23";
			this.Label23.TabIndex = 20;
			this.Label23.Text = "SA";
			this.Label22 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label22
			// 
			this.Label22.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label22.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label22.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label22.Name = "Label22";
			this.Label22.TabIndex = 19;
			this.Label22.Text = "WE";
			this.Label21 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label21
			// 
			this.Label21.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label21.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label21.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label21.Name = "Label21";
			this.Label21.TabIndex = 18;
			this.Label21.Text = "TU";
			this.Label36 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label36
			// 
			this.Label36.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label36.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label36.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label36.Name = "Label36";
			this.Label36.TabIndex = 17;
			this.Label36.Text = "MO";
			this.sprWeek1 = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprWeek1.MaxRows = 15;
			this.sprWeek1.TabIndex = 76;
			this.sprWeek1.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprWeek2 = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprWeek2.MaxRows = 15;
			this.sprWeek2.TabIndex = 77;
			this.sprWeek2.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprTimeSheet = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprTimeSheet.MaxRows = 32;
			this.sprTimeSheet.TabIndex = 78;
			this.sprTimeSheet.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprTimeSheet.Visible = false;
			this.sprEmployeeList = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprEmployeeList.TabIndex = 79;
			this.sprEmployeeList.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this._Label2_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label2_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbTotalHrs = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbTotalHrs
			// 
			this.lbTotalHrs.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbTotalHrs.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbTotalHrs.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.lbTotalHrs.Name = "lbTotalHrs";
			this.lbTotalHrs.TabIndex = 81;
			this.lbTotalHrs.Text = "lbTotalHrs";
			this.lbPayrollHrs = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbPayrollHrs
			// 
			this.lbPayrollHrs.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbPayrollHrs.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbPayrollHrs.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.lbPayrollHrs.Name = "lbPayrollHrs";
			this.lbPayrollHrs.TabIndex = 80;
			this.lbPayrollHrs.Text = "Total Hours:";
			this.sprEmployeeList_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprEmployeeList_Sheet1.SheetName = "Sheet1";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 0].Value = "OK";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 1].Value = "Empl #";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 2].Value = "Name";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 3].Value = "Cost Center";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 4].Value = "Batt";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 5].Value = "Unit";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 6].Value = "Shift";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 7].Value = "PS Group";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 8].Value = "TFD Hire Date";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 9].Value = "ID";
			this.sprEmployeeList_Sheet1.Columns.Get(0).Label = "OK";
            //SortIndicator is OBSOLETE
            //this.sprEmployeeList_Sheet1.Columns.Get(0).SortIndicator = FarPoint.ViewModels.SortIndicator.Descending;
			this.sprEmployeeList_Sheet1.Columns.Get(0).StyleName = "CheckBox735636234697053728151";
			this.sprEmployeeList_Sheet1.Columns.Get(0).Width = 31F;
			this.sprEmployeeList_Sheet1.Columns.Get(1).Label = "Empl #";
			this.sprEmployeeList_Sheet1.Columns.Get(1).Width = 55F;
			this.sprEmployeeList_Sheet1.Columns.Get(2).Label = "Name";
			this.sprEmployeeList_Sheet1.Columns.Get(2).Width = 134F;
			this.sprEmployeeList_Sheet1.Columns.Get(4).Label = "Batt";
			this.sprEmployeeList_Sheet1.Columns.Get(4).Width = 46F;
			this.sprEmployeeList_Sheet1.Columns.Get(5).Label = "Unit";
			this.sprEmployeeList_Sheet1.Columns.Get(5).Width = 47F;
			this.sprEmployeeList_Sheet1.Columns.Get(6).Label = "Shift";
			this.sprEmployeeList_Sheet1.Columns.Get(6).Width = 41F;
			this.sprEmployeeList_Sheet1.Columns.Get(7).Label = "PS Group";
			this.sprEmployeeList_Sheet1.Columns.Get(7).Width = 58F;
			this.sprEmployeeList_Sheet1.Columns.Get(8).Label = "TFD Hire Date";
			this.sprEmployeeList_Sheet1.Columns.Get(8).Width = 62F;
			this.sprEmployeeList_Sheet1.Columns.Get(9).Label = "ID";
			this.sprEmployeeList_Sheet1.Columns.Get(9).Visible = false;
			this.sprEmployeeList_Sheet1.Columns.Get(9).Width = 0F;
			this.sprEmployeeList_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
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
            //ColumnSpan is OBSOLETE
            //this.sprTimeSheet_Sheet1.Cells.Get(0, 11).ColumnSpan = 3;
			this.sprTimeSheet_Sheet1.Cells.Get(0, 11).Value = "PERIOD END";
			this.sprTimeSheet_Sheet1.Cells.Get(0, 14).Value = "1120";
            //ColumnSpan is OBSOLETE
   //         this.sprTimeSheet_Sheet1.Cells.Get(1, 1).ColumnSpan = 2;
			//this.sprTimeSheet_Sheet1.Cells.Get(1, 8).ColumnSpan = 3;
			//this.sprTimeSheet_Sheet1.Cells.Get(1, 11).ColumnSpan = 3;
			this.sprTimeSheet_Sheet1.Cells.Get(1, 14).Value = "TO2";
            //ColumnSpan is OBSOLETE
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
            //ColumnSpan is OBSOLETE
            //this.sprTimeSheet_Sheet1.Cells.Get(30, 1).ColumnSpan = 4;
			this.sprTimeSheet_Sheet1.Cells.Get(30, 1).Value = "_________________________________________";
			this.sprTimeSheet_Sheet1.Cells.Get(30, 5).Value = "SUPERVISOR:";
            //ColumnSpan is OBSOLETE
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
			this.sprTimeSheet_Sheet1.Columns.Get(8).StyleName = "Static1171636234697349685771";
			this.sprTimeSheet_Sheet1.Columns.Get(8).Width = 42F;
			this.sprTimeSheet_Sheet1.Columns.Get(9).StyleName = "Static1171636234697349685771";
			this.sprTimeSheet_Sheet1.Columns.Get(9).Width = 42F;
			this.sprTimeSheet_Sheet1.Columns.Get(10).StyleName = "Static1171636234697349685771";
			this.sprTimeSheet_Sheet1.Columns.Get(10).Width = 42F;
			this.sprTimeSheet_Sheet1.Columns.Get(11).StyleName = "Static1171636234697349685771";
			this.sprTimeSheet_Sheet1.Columns.Get(11).Width = 42F;
			this.sprTimeSheet_Sheet1.Columns.Get(12).StyleName = "Static1171636234697349685771";
			this.sprTimeSheet_Sheet1.Columns.Get(12).Width = 42F;
			this.sprTimeSheet_Sheet1.Columns.Get(13).StyleName = "Static1171636234697349685771";
			this.sprTimeSheet_Sheet1.Columns.Get(13).Width = 42F;
			this.sprTimeSheet_Sheet1.Columns.Get(14).StyleName = "Static1171636234697349685771";
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
			this.sprWeek2_Sheet1.ColumnHeader.Cells[0, 15].Value = "MoID";
			this.sprWeek2_Sheet1.ColumnHeader.Cells[0, 16].Value = "TuID";
			this.sprWeek2_Sheet1.ColumnHeader.Cells[0, 17].Value = "WeID";
			this.sprWeek2_Sheet1.ColumnHeader.Cells[0, 18].Value = "ThID";
			this.sprWeek2_Sheet1.ColumnHeader.Cells[0, 19].Value = "FrID";
			this.sprWeek2_Sheet1.ColumnHeader.Cells[0, 20].Value = "SaID";
			this.sprWeek2_Sheet1.ColumnHeader.Cells[0, 21].Value = "SuID";
			this.sprWeek2_Sheet1.ColumnHeader.Rows.Get(0).Height = 13F;
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
			this.sprWeek2_Sheet1.Columns.Get(15).Label = "MoID";
            //SortIndicator is OBSOLETE
            //this.sprWeek2_Sheet1.Columns.Get(15).SortIndicator = FarPoint.ViewModels.SortIndicator.Descending;
            this.sprWeek2_Sheet1.Columns.Get(15).Visible = false;
			this.sprWeek2_Sheet1.Columns.Get(15).Width = 0F;
			this.sprWeek2_Sheet1.Columns.Get(16).Label = "TuID";
			//this.sprWeek2_Sheet1.Columns.Get(16).SortIndicator = FarPoint.ViewModels.SortIndicator.Descending;
			this.sprWeek2_Sheet1.Columns.Get(16).Visible = false;
			this.sprWeek2_Sheet1.Columns.Get(16).Width = 0F;
			this.sprWeek2_Sheet1.Columns.Get(17).Label = "WeID";
			//this.sprWeek2_Sheet1.Columns.Get(17).SortIndicator = FarPoint.ViewModels.SortIndicator.Descending;
			this.sprWeek2_Sheet1.Columns.Get(17).Visible = false;
			this.sprWeek2_Sheet1.Columns.Get(17).Width = 0F;
			this.sprWeek2_Sheet1.Columns.Get(18).Label = "ThID";
			//this.sprWeek2_Sheet1.Columns.Get(18).SortIndicator = FarPoint.ViewModels.SortIndicator.Descending;
			this.sprWeek2_Sheet1.Columns.Get(18).Visible = false;
			this.sprWeek2_Sheet1.Columns.Get(18).Width = 0F;
			this.sprWeek2_Sheet1.Columns.Get(19).Label = "FrID";
			//this.sprWeek2_Sheet1.Columns.Get(19).SortIndicator = FarPoint.ViewModels.SortIndicator.Descending;
			this.sprWeek2_Sheet1.Columns.Get(19).Visible = false;
			this.sprWeek2_Sheet1.Columns.Get(19).Width = 0F;
			this.sprWeek2_Sheet1.Columns.Get(20).Label = "SaID";
			//this.sprWeek2_Sheet1.Columns.Get(20).SortIndicator = FarPoint.ViewModels.SortIndicator.Descending;
			this.sprWeek2_Sheet1.Columns.Get(20).Visible = false;
			this.sprWeek2_Sheet1.Columns.Get(20).Width = 0F;
			this.sprWeek2_Sheet1.Columns.Get(21).Label = "SuID";
			//this.sprWeek2_Sheet1.Columns.Get(21).SortIndicator = FarPoint.ViewModels.SortIndicator.Descending;
			this.sprWeek2_Sheet1.Columns.Get(21).Visible = false;
			this.sprWeek2_Sheet1.Columns.Get(21).Width = 0F;
			this.sprWeek2_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprWeek2_Sheet1.Rows.Get(3).Height = 14F;
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
			this.sprWeek1_Sheet1.ColumnHeader.Cells[0, 15].Value = "MoID";
			this.sprWeek1_Sheet1.ColumnHeader.Cells[0, 16].Value = "TuID";
			this.sprWeek1_Sheet1.ColumnHeader.Cells[0, 17].Value = "WeID";
			this.sprWeek1_Sheet1.ColumnHeader.Cells[0, 18].Value = "ThID";
			this.sprWeek1_Sheet1.ColumnHeader.Cells[0, 19].Value = "FrID";
			this.sprWeek1_Sheet1.ColumnHeader.Cells[0, 20].Value = "SaID";
			this.sprWeek1_Sheet1.ColumnHeader.Cells[0, 21].Value = "SuID";
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
			this.sprWeek1_Sheet1.Columns.Get(15).Label = "MoID";
			this.sprWeek1_Sheet1.Columns.Get(15).Visible = false;
			this.sprWeek1_Sheet1.Columns.Get(15).Width = 0F;
			this.sprWeek1_Sheet1.Columns.Get(16).Label = "TuID";
			this.sprWeek1_Sheet1.Columns.Get(16).Visible = false;
			this.sprWeek1_Sheet1.Columns.Get(16).Width = 0F;
			this.sprWeek1_Sheet1.Columns.Get(17).Label = "WeID";
			this.sprWeek1_Sheet1.Columns.Get(17).Visible = false;
			this.sprWeek1_Sheet1.Columns.Get(17).Width = 0F;
			this.sprWeek1_Sheet1.Columns.Get(18).Label = "ThID";
			this.sprWeek1_Sheet1.Columns.Get(18).Visible = false;
			this.sprWeek1_Sheet1.Columns.Get(18).Width = 0F;
			this.sprWeek1_Sheet1.Columns.Get(19).Label = "FrID";
			this.sprWeek1_Sheet1.Columns.Get(19).Visible = false;
			this.sprWeek1_Sheet1.Columns.Get(19).Width = 0F;
			this.sprWeek1_Sheet1.Columns.Get(20).Label = "SaID";
			this.sprWeek1_Sheet1.Columns.Get(20).Visible = false;
			this.sprWeek1_Sheet1.Columns.Get(20).Width = 0F;
			this.sprWeek1_Sheet1.Columns.Get(21).Label = "SuID";
			this.sprWeek1_Sheet1.Columns.Get(21).Visible = false;
			this.sprWeek1_Sheet1.Columns.Get(21).Width = 0F;
			this.sprWeek1_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprWeek1_Sheet1.Rows.Get(3).Height = 14F;
			this.cmdPrint = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrint.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrint.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.TabIndex = 75;
			this.cmdPrint.Text = "Print Time Card";
			this.cmdSave = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdSave
			// 
			this.cmdSave.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdSave.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdSave.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdSave.Name = "cmdSave";
			this.cmdSave.TabIndex = 74;
			this.cmdSave.Text = "Save Timecard";
			this.cmdOKToPay = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdOKToPay
			// 
			this.cmdOKToPay.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdOKToPay.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdOKToPay.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdOKToPay.Name = "cmdOKToPay";
			this.cmdOKToPay.TabIndex = 73;
			this.cmdOKToPay.Text = "Upload Payroll";
			this.chkAll = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkAll
			// 
			this.chkAll.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.chkAll.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkAll.ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			this.chkAll.Name = "chkAll";
			this.chkAll.TabIndex = 72;
			this.chkAll.Text = "Print All Timecards";
			this.cmdPrintList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrintList
			// 
			this.cmdPrintList.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrintList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrintList.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrintList.Name = "cmdPrintList";
			this.cmdPrintList.TabIndex = 68;
			this.cmdPrintList.Text = "Print List";
			this.cboClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cboClose
			// 
			this.cboClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cboClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cboClose.Name = "cboClose";
			this.cboClose.TabIndex = 67;
			this.cboClose.Text = "Close";
			this.cmdApply1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdApply1
			// 
			this.cmdApply1.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdApply1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdApply1.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdApply1.Name = "cmdApply1";
			this.cmdApply1.TabIndex = 48;
			this.cmdApply1.Text = "Apply Changes";
			this.cmdApply2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdApply2
			// 
			this.cmdApply2.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdApply2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdApply2.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdApply2.Name = "cmdApply2";
			this.cmdApply2.TabIndex = 15;
			this.cmdApply2.Text = "Apply Changes";
			this.Text = "Dispatch Payroll";
			this.ReportDate = "";
			this.DateArray = new object[14, 3];
			this.CurrEmpID = "";
			this.SelectedRow = 0;
			this.CurrPersID = 0;
			this.CurrStartDate = "";
			this.CurrEndDate = "";
			this.PayRollExist = false;
			this.CurrSAPCode = "";
			this.CurrRow1 = 0;
			this.CurrRow2 = 0;
			this.NeedFillerCode = false;
			this.NeedAdjustment = false;
			this.OverAmount = 0;
			this.UnderAmount = 0;
			this.SetLimit = false;
			this.CurrLeaveTotal = 0;
			this.CurrentUnit = "";
			this.OKToPay = false;
			this.SchedTime = "";
			this.CurrFillerCode = "";
			this.frmWeek1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmWeek1
			// 
			this.frmWeek1.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.frmWeek1.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmWeek1.Name = "frmWeek1";
			this.frmWeek1.TabIndex = 33;
			this.frmWeek1.Visible = false;
			this.frmWeek2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmWeek2
			// 
			this.frmWeek2.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.frmWeek2.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmWeek2.Name = "frmWeek2";
			this.frmWeek2.TabIndex = 0;
			this.frmWeek2.Visible = false;
			this.CurrUnit = "";
			this.CurrGroupCode = "";
			this.CurrBenefit = "";
			this.SelectedRow1 = 0;
			this.SelectedRow2 = 0;
			this.FirstTime = false;
			this.CurrPayPeriod = 0;
			Label6 = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(1);
			Label6[0] = _Label6_0;
			Label6[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			Label6[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label6[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			Label6[0].Name = "_Label6_0";
			Label6[0].TabIndex = 71;
			Label6[0].Text = "Select a Pay Period:";
			Label35 = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(2);
			Label35[0] = _Label35_0;
			Label35[1] = _Label35_1;
			Label35[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label35[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label35[0].ForeColor = UpgradeHelpers.Helpers.Color.Lime;
			Label35[0].Name = "_Label35_0";
			Label35[0].TabIndex = 65;
			Label35[0].Text = "To Delete ~ set hours to zero";
			Label35[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label35[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label35[1].ForeColor = UpgradeHelpers.Helpers.Color.Lime;
			Label35[1].Name = "_Label35_1";
			Label35[1].TabIndex = 32;
			Label35[1].Text = "To Delete ~ set hours to zero";
			Label2 = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(2);
			Label2[1] = _Label2_1;
			Label2[0] = _Label2_0;
			Label2[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			Label2[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label2[1].ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			Label2[1].Name = "_Label2_1";
			Label2[1].TabIndex = 83;
			Label2[1].Text = "W E E K 1";
			Label2[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			Label2[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label2[0].ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			Label2[0].Name = "_Label2_0";
			Label2[0].TabIndex = 82;
			Label2[0].Text = "W E E K 2";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234697150499301", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.Locked = true;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text306636234697150509066", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.Locked = true;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234697237114851", "DataAreaDefault");
			namedStyle3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F);
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.Locked = true;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.Parent = "DataAreaDefault";
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text306636234697237134381", "DataAreaDefault");
			namedStyle4.CellType = textCellType2;
			namedStyle4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F);
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle4.Locked = true;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.Parent = "DataAreaDefault";
			namedStyle4.Renderer = textCellType2;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color59636234697349636946", "DataAreaDefault");
			namedStyle5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Courier New", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.Parent = "DataAreaDefault";
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text337636234697349646711", "DataAreaDefault");
			namedStyle6.CellType = textCellType3;
			namedStyle6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Courier New", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.Parent = "DataAreaDefault";
			namedStyle6.Renderer = textCellType3;
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle7 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1171636234697349685771");
			namedStyle7.CellType = textCellType4;
			namedStyle7.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle7.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle7.Renderer = textCellType4;
			namedStyle7.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle8 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1728636234697349744361");
			namedStyle8.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle8.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle8.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle8.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle8.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle9 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1768636234697349773656");
			namedStyle9.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle9.CellType = textCellType5;
			namedStyle9.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle9.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle9.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle9.Renderer = textCellType5;
			namedStyle9.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle10 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1827636234697349783421");
			namedStyle10.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle10.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle10.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle10.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle10.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle11 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1867636234697349793186");
			namedStyle11.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle11.CellType = textCellType6;
			namedStyle11.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle11.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle11.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle11.Renderer = textCellType6;
			namedStyle11.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle12 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1932636234697349802951");
			namedStyle12.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle12.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle12.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle13 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1972636234697349812716");
			namedStyle13.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle13.CellType = textCellType7;
			namedStyle13.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle13.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle13.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle13.Renderer = textCellType7;
			namedStyle13.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle14 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3030636234697350066606");
			namedStyle14.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle14.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle14.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle14.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle14.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle15 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3070636234697350076371");
			namedStyle15.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle15.CellType = textCellType8;
			namedStyle15.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle15.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle15.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle15.Renderer = textCellType8;
			namedStyle15.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle16 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3156636234697350095901");
			namedStyle16.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle16.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle16.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle16.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle16.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle17 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3196636234697350105666");
			namedStyle17.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle17.CellType = textCellType9;
			namedStyle17.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle17.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle17.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle17.Renderer = textCellType9;
			namedStyle17.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle18 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3234636234697350105666");
			namedStyle18.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle18.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle18.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle18.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle18.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle19 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3274636234697350125196");
			namedStyle19.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle19.CellType = textCellType10;
			namedStyle19.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle19.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle19.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle19.Renderer = textCellType10;
			namedStyle19.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle20 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3352636234697350144726");
			namedStyle20.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle20.CellType = textCellType11;
			namedStyle20.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle20.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle20.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle20.Renderer = textCellType11;
			namedStyle20.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle21 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx156636234697350291201");
			namedStyle21.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle21.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle21.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle21.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle21.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle22 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static196636234697350300966");
			namedStyle22.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle22.CellType = textCellType12;
			namedStyle22.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle22.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle22.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle22.Renderer = textCellType12;
			namedStyle22.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle23 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color236636234697350300966");
			namedStyle23.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle23.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle23.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle23.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle23.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle24 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx303636234697350310731");
			namedStyle24.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle24.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle24.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle25 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static321636234697350320496");
			namedStyle25.CellType = textCellType13;
			namedStyle25.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle25.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle25.Renderer = textCellType13;
			namedStyle25.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle26 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx359636234697350320496");
			namedStyle26.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle26.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle26.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle27 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static377636234697350330261");
			namedStyle27.CellType = textCellType14;
			namedStyle27.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle27.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle27.Renderer = textCellType14;
			namedStyle27.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle28 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1108636234697350447441");
			namedStyle28.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle28.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle28.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle29 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1126636234697350457206");
			namedStyle29.CellType = textCellType15;
			namedStyle29.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle29.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle29.Renderer = textCellType15;
			namedStyle29.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle30 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1211636234697350466971");
			namedStyle30.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle30.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle30.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle30.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle30.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle31 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1251636234697350476736");
			namedStyle31.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle31.CellType = textCellType16;
			namedStyle31.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle31.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle31.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle31.Renderer = textCellType16;
			namedStyle31.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle32 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1312636234697350486501");
			namedStyle32.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle32.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle32.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle33 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2732636234697350750156");
			namedStyle33.CellType = textCellType17;
			namedStyle33.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle33.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle33.Renderer = textCellType17;
			namedStyle33.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle34 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx928636234697352771511");
			namedStyle34.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle34.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle34.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle34.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle34.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle35 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static968636234697352791041");
			namedStyle35.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle35.CellType = textCellType18;
			namedStyle35.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle35.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle35.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle35.Renderer = textCellType18;
			namedStyle35.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle36 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3312636234697350134961");
			namedStyle36.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle36.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle36.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle36.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle36.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle37 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1069636234697352800806");
			namedStyle37.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle37.CellType = textCellType19;
			namedStyle37.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle37.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle37.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle37.Renderer = textCellType19;
			namedStyle37.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle38 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1133636234697352810571");
			namedStyle38.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle38.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle38.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle39 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2307636234697353005871");
			namedStyle39.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle39.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle39.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle39.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle39.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle40 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2347636234697353025401");
			namedStyle40.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle40.CellType = textCellType20;
			namedStyle40.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle40.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle40.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle40.Renderer = textCellType20;
			namedStyle40.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle41 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx333636234697354792866");
			namedStyle41.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Courier New", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle41.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle41.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle41.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle42 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static966636234697354861221");
			namedStyle42.CellType = textCellType21;
			namedStyle42.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Courier New", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle42.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle42.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle42.Renderer = textCellType21;
			namedStyle42.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle43 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1046636234697354870986");
			namedStyle43.CellType = textCellType22;
			namedStyle43.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle43.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle43.Renderer = textCellType22;
			namedStyle43.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Bottom;
			namedStyle44 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1158636234697354890516");
			namedStyle44.CellType = textCellType23;
			namedStyle44.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle44.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle44.Renderer = textCellType23;
			namedStyle44.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle45 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1308636234697354910046");
			namedStyle45.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle45.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle45.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle46 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1326636234697354910046");
			namedStyle46.CellType = textCellType24;
			namedStyle46.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle46.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle46.Renderer = textCellType24;
			namedStyle46.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle47 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234697053708621", "DataAreaDefault");
			namedStyle47.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle47.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle47.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle47.Parent = "DataAreaDefault";
			namedStyle47.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle48 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text315636234697053718386", "DataAreaDefault");
			namedStyle48.CellType = textCellType25;
			namedStyle48.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle48.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle48.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle48.Parent = "DataAreaDefault";
			namedStyle48.Renderer = textCellType25;
			namedStyle48.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle49 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("CheckBox735636234697053728151");
			namedStyle49.CellType = checkBoxCellType1;
			namedStyle49.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle49.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle49.Renderer = checkBoxCellType1;
			namedStyle49.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			this.Name = "PTSProject.frmDispatchPayroll";
			IsMdiChild = true;
			this.sprWeek1.NamedStyles.Add(namedStyle1);
			this.sprWeek1.NamedStyles.Add(namedStyle2);
			this.sprWeek1.Sheets.Add(this.sprWeek1_Sheet1);
			this.sprWeek2.NamedStyles.Add(namedStyle3);
			this.sprWeek2.NamedStyles.Add(namedStyle4);
			this.sprWeek2.Sheets.Add(this.sprWeek2_Sheet1);
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
			this.sprTimeSheet.NamedStyles.Add(namedStyle45);
			this.sprTimeSheet.NamedStyles.Add(namedStyle46);
			this.sprTimeSheet.Sheets.Add(this.sprTimeSheet_Sheet1);
			this.sprEmployeeList.NamedStyles.Add(namedStyle47);
			this.sprEmployeeList.NamedStyles.Add(namedStyle48);
			this.sprEmployeeList.NamedStyles.Add(namedStyle49);
			this.sprEmployeeList.Sheets.Add(this.sprEmployeeList_Sheet1);
		}

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboPayPeriod { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label6_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbCount { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmFilterList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboOrder1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtWe1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtTu1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtMo1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtFr1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtTh1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboStep1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboJobCode1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboAAType1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtSu1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtSa1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtOper1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtWBSElement1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtCostCenter1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtActivity1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label35_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label19 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label18 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label17 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label16 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label15 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label14 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label13 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label20 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboOrder2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtActivity2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtCostCenter2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtWBSElement2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtOper2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtSa2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtSu2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboAAType2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboJobCode2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboStep2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtTh2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtFr2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtMo2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtTu2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtWe2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label35_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label34 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label33 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label32 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label31 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label30 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label29 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label28 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label27 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label26 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label25 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label24 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label23 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label22 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label21 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label36 { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprWeek1 { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprWeek2 { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprTimeSheet { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprEmployeeList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label2_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label2_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbTotalHrs { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbPayrollHrs { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprEmployeeList_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprTimeSheet_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprWeek2_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprWeek1_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdSave { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdOKToPay { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkAll { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrintList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cboClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdApply1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdApply2 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String ReportDate { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Object[,] DateArray { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrEmpID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 SelectedRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrPersID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrStartDate { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrEndDate { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean PayRollExist { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrSAPCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrRow1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrRow2 { get; set; }

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
		public virtual System.Boolean OKToPay { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String SchedTime { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrFillerCode { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmWeek1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmWeek2 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrUnit { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrGroupCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrBenefit { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 SelectedRow1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 SelectedRow2 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean FirstTime { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrPayPeriod { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> Label6 { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> Label35 { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> Label2 { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}