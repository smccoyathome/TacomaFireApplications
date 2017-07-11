using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace TFDIncident.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(TFDIncident.frmFireReport))]
	public class frmFireReportViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.cboNarrList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboNarrList
			// 
			this.cboNarrList.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboNarrList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboNarrList.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboNarrList.Name = "cboNarrList";
			this.cboNarrList.TabIndex = 80;
			this.cboNarrList.Text = "cboNarrList";
			this.lbNarrID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbNarrID
			// 
			this.lbNarrID.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbNarrID.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbNarrID.Name = "lbNarrID";
			this.lbNarrID.TabIndex = 212;
			this.lbNarrID.Text = "lbNarrID";
			this.lbNarrID.Visible = false;
			this.lbNarrSelTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbNarrSelTitle
			// 
			this.lbNarrSelTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbNarrSelTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, ((UpgradeHelpers
						.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbNarrSelTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.lbNarrSelTitle.Name = "lbNarrSelTitle";
			this.lbNarrSelTitle.TabIndex = 211;
			this.lbNarrSelTitle.Text = "Select Narration Author";
			this.cboXSuffix = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboXSuffix
			// 
			this.cboXSuffix.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboXSuffix.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboXSuffix.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboXSuffix.Name = "cboXSuffix";
			this.cboXSuffix.TabIndex = 195;
			this.cboXStreetType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboXStreetType
			// 
			this.cboXStreetType.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboXStreetType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboXStreetType.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboXStreetType.Name = "cboXStreetType";
			this.cboXStreetType.TabIndex = 194;
			this.cboXPrefix = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboXPrefix
			// 
			this.cboXPrefix.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboXPrefix.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboXPrefix.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboXPrefix.Name = "cboXPrefix";
			this.cboXPrefix.TabIndex = 193;
			this.txtXStreetName = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtXStreetName.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtXStreetName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtXStreetName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.txtXStreetName.Name = "txtXStreetName";
			this.txtXStreetName.TabIndex = 192;
			this.txtXHouseNumber = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtXHouseNumber.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtXHouseNumber.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtXHouseNumber.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.txtXHouseNumber.Name = "txtXHouseNumber";
			this.txtXHouseNumber.TabIndex = 191;
			this.cboCityCode = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboCityCode
			// 
			this.cboCityCode.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboCityCode.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboCityCode.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboCityCode.Name = "cboCityCode";
			this.cboCityCode.TabIndex = 190;
			this.lbAddressTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAddressTitle
			// 
			this.lbAddressTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAddressTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, ((UpgradeHelpers
						.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbAddressTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.lbAddressTitle.Name = "lbAddressTitle";
			this.lbAddressTitle.TabIndex = 202;
			this.lbAddressTitle.Text = "FIRE ADDRESS CORRECTION";
			this.Label8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label8
			// 
			this.Label8.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label8.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label8.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.Label8.Name = "Label8";
			this.Label8.TabIndex = 201;
			this.Label8.Text = "CITY";
			this.Label6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label6
			// 
			this.Label6.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label6.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.Label6.Name = "Label6";
			this.Label6.TabIndex = 200;
			this.Label6.Text = "SUFFIX";
			this.Label5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label5
			// 
			this.Label5.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label5.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.Label5.Name = "Label5";
			this.Label5.TabIndex = 199;
			this.Label5.Text = "STREET TYPE";
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 198;
			this.Label4.Text = "STREET NAME";
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 197;
			this.Label3.Text = "PREFIX";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 196;
			this.Label1.Text = "HOUSE#";
			this.txtBasementLevels = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtBasementLevels.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.txtBasementLevels.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtBasementLevels.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.txtBasementLevels.Name = "txtBasementLevels";
			this.txtBasementLevels.TabIndex = 171;
			this.txtNumberOfBusinesses = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtNumberOfBusinesses.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.txtNumberOfBusinesses.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtNumberOfBusinesses.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.txtNumberOfBusinesses.Name = "txtNumberOfBusinesses";
			this.txtNumberOfBusinesses.TabIndex = 174;
			this.txtNumberOfOccupants = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtNumberOfOccupants.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.txtNumberOfOccupants.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtNumberOfOccupants.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.txtNumberOfOccupants.Name = "txtNumberOfOccupants";
			this.txtNumberOfOccupants.TabIndex = 173;
			this.txtNumberOfUnits = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtNumberOfUnits.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.txtNumberOfUnits.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtNumberOfUnits.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.txtNumberOfUnits.Name = "txtNumberOfUnits";
			this.txtNumberOfUnits.TabIndex = 172;
			this.txtNumberOfStories = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtNumberOfStories.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.txtNumberOfStories.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtNumberOfStories.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.txtNumberOfStories.Name = "txtNumberOfStories";
			this.txtNumberOfStories.TabIndex = 170;
			this.cboConstructionType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboConstructionType
			// 
			this.cboConstructionType.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.cboConstructionType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboConstructionType.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.cboConstructionType.Name = "cboConstructionType";
			this.cboConstructionType.TabIndex = 167;
			this.cboConstructionType.Text = " cboConstructionType";
			this.cboBuildingStatus = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboBuildingStatus
			// 
			this.cboBuildingStatus.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.cboBuildingStatus.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboBuildingStatus.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.cboBuildingStatus.Name = "cboBuildingStatus";
			this.cboBuildingStatus.TabIndex = 166;
			this.cboBuildingStatus.Text = " cboBuildingStatus";
			this.cboSpecificPropertyUse = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboSpecificPropertyUse
			// 
			this.cboSpecificPropertyUse.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.cboSpecificPropertyUse.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboSpecificPropertyUse.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.cboSpecificPropertyUse.Name = "cboSpecificPropertyUse";
			this.cboSpecificPropertyUse.TabIndex = 165;
			this.cboSpecificPropertyUse.Text = " cboSpecificPropertyUse";
			this.cboGeneralPropertyUse = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboGeneralPropertyUse
			// 
			this.cboGeneralPropertyUse.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.cboGeneralPropertyUse.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboGeneralPropertyUse.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.cboGeneralPropertyUse.Name = "cboGeneralPropertyUse";
			this.cboGeneralPropertyUse.TabIndex = 164;
			this.cboGeneralPropertyUse.Text = " cboGeneralPropertyUse";
			this.txtTotalSqFootage = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this.txtTotalSqFootage.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.txtTotalSqFootage.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtTotalSqFootage.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.txtTotalSqFootage.Name = "txtTotalSqFootage";
			this.txtTotalSqFootage.TabIndex = 168;
			this.txtPropValue = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this.txtPropValue.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.txtPropValue.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtPropValue.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.txtPropValue.Name = "txtPropValue";
			this.txtPropValue.TabIndex = 175;
			this.lbBasementLevel = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbBasementLevel
			// 
			this.lbBasementLevel.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbBasementLevel.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbBasementLevel.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbBasementLevel.Name = "lbBasementLevel";
			this.lbBasementLevel.TabIndex = 219;
			this.lbBasementLevel.Text = "BASEMENT LEVELS";
			this.lbNoStories = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbNoStories
			// 
			this.lbNoStories.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbNoStories.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbNoStories.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbNoStories.Name = "lbNoStories";
			this.lbNoStories.TabIndex = 218;
			this.lbNoStories.Text = "STORIES";
			this.lbTotSqFt = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbTotSqFt
			// 
			this.lbTotSqFt.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbTotSqFt.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbTotSqFt.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbTotSqFt.Name = "lbTotSqFt";
			this.lbTotSqFt.TabIndex = 184;
			this.lbTotSqFt.Text = "TOTAL SQ. FOOTAGE";
			this.lbNumberOfUnits = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbNumberOfUnits
			// 
			this.lbNumberOfUnits.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbNumberOfUnits.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbNumberOfUnits.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbNumberOfUnits.Name = "lbNumberOfUnits";
			this.lbNumberOfUnits.TabIndex = 183;
			this.lbNumberOfUnits.Text = "NUMBER OF UNITS/SUITES";
			this.lbNoOccupants = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbNoOccupants
			// 
			this.lbNoOccupants.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbNoOccupants.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbNoOccupants.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbNoOccupants.Name = "lbNoOccupants";
			this.lbNoOccupants.TabIndex = 182;
			this.lbNoOccupants.Text = "NUMBER OF OCCUPANTS";
			this.lbNoBusinesses = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbNoBusinesses
			// 
			this.lbNoBusinesses.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbNoBusinesses.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbNoBusinesses.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbNoBusinesses.Name = "lbNoBusinesses";
			this.lbNoBusinesses.TabIndex = 181;
			this.lbNoBusinesses.Text = "NUMBER OF BUSINESSES";
			this.lbPropValue = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbPropValue
			// 
			this.lbPropValue.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbPropValue.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbPropValue.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbPropValue.Name = "lbPropValue";
			this.lbPropValue.TabIndex = 180;
			this.lbPropValue.Text = "PROPERTY VALUE";
			this.lbConstructionType = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbConstructionType
			// 
			this.lbConstructionType.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbConstructionType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbConstructionType.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbConstructionType.Name = "lbConstructionType";
			this.lbConstructionType.TabIndex = 179;
			this.lbConstructionType.Text = "CONSTRUCTION TYPE";
			this.lbBldgStatus = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbBldgStatus
			// 
			this.lbBldgStatus.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbBldgStatus.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbBldgStatus.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbBldgStatus.Name = "lbBldgStatus";
			this.lbBldgStatus.TabIndex = 178;
			this.lbBldgStatus.Text = "BUILDING STATUS";
			this.lbSpecificOccupancy = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSpecificOccupancy
			// 
			this.lbSpecificOccupancy.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSpecificOccupancy.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbSpecificOccupancy.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbSpecificOccupancy.Name = "lbSpecificOccupancy";
			this.lbSpecificOccupancy.TabIndex = 177;
			this.lbSpecificOccupancy.Text = "SPECIFIC OCCUPANCY";
			this.lbGenOccupancy = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbGenOccupancy
			// 
			this.lbGenOccupancy.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbGenOccupancy.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbGenOccupancy.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbGenOccupancy.Name = "lbGenOccupancy";
			this.lbGenOccupancy.TabIndex = 176;
			this.lbGenOccupancy.Text = "GENERAL OCCUPANCY";
			this.frmBI1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmBI1
			// 
			this.frmBI1.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			this.frmBI1.Enabled = false;
			this.frmBI1.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmBI1.Name = "frmBI1";
			this.frmBI1.TabIndex = 163;
			this.txtMobilePropValue = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtMobilePropValue.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.txtMobilePropValue.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtMobilePropValue.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.txtMobilePropValue.Name = "txtMobilePropValue";
			this.txtMobilePropValue.TabIndex = 12;
			this.cboMobilePropType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboMobilePropType
			// 
			this.cboMobilePropType.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.cboMobilePropType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboMobilePropType.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.cboMobilePropType.Name = "cboMobilePropType";
			this.cboMobilePropType.TabIndex = 11;
			this.cboMobilePropType.Text = " cboMobilePropType";
			this.txtVesselLength = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtVesselLength.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtVesselLength.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtVesselLength.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(102)))), ((int)(((byte)(92)))));
			this.txtVesselLength.Name = "txtVesselLength";
			this.txtVesselLength.TabIndex = 13;
			this.lbMobilePropValue = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbMobilePropValue
			// 
			this.lbMobilePropValue.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbMobilePropValue.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbMobilePropValue.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(102)))), ((int)(((byte)(92)))));
			this.lbMobilePropValue.Name = "lbMobilePropValue";
			this.lbMobilePropValue.TabIndex = 162;
			this.lbMobilePropValue.Text = "PROPERTY VALUE";
			this.lbMobilePropType = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbMobilePropType
			// 
			this.lbMobilePropType.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbMobilePropType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbMobilePropType.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(102)))), ((int)(((byte)(92)))));
			this.lbMobilePropType.Name = "lbMobilePropType";
			this.lbMobilePropType.TabIndex = 161;
			this.lbMobilePropType.Text = "TYPE OF MOBILE PROPERTY";
			this.lbVesselLength = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbVesselLength
			// 
			this.lbVesselLength.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbVesselLength.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbVesselLength.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(102)))), ((int)(((byte)(92)))));
			this.lbVesselLength.Name = "lbVesselLength";
			this.lbVesselLength.TabIndex = 160;
			this.lbVesselLength.Text = "WATER VESSEL LENGTH (FT)";
			this.frmMobile1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmMobile1
			// 
			this.frmMobile1.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			this.frmMobile1.Enabled = false;
			this.frmMobile1.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmMobile1.Name = "frmMobile1";
			this.frmMobile1.TabIndex = 159;
			this._optHFGender_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optHFGender_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.txtHFAge = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtHFAge.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtHFAge.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtHFAge.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.txtHFAge.Name = "txtHFAge";
			this.txtHFAge.TabIndex = 224;
			this.Label11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label11
			// 
			this.Label11.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label11.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label11.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.Label11.Name = "Label11";
			this.Label11.TabIndex = 227;
			this.Label11.Text = "AGE";
			this.frmHFDetail = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmHFDetail
			// 
			this.frmHFDetail.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(189)))), ((int)(((byte)(100)))));
			this.frmHFDetail.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmHFDetail.Name = "frmHFDetail";
			this.frmHFDetail.TabIndex = 223;
			this.frmHFDetail.Visible = false;
			this.lstPhysicalContribFactors = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstPhysicalContribFactors
			// 
			this.lstPhysicalContribFactors.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lstPhysicalContribFactors.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lstPhysicalContribFactors.Name = "lstPhysicalContribFactors";
			this.lstPhysicalContribFactors.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.lstPhysicalContribFactors.TabIndex = 27;
			this.lstHumanContribFactors = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstHumanContribFactors
			// 
			this.lstHumanContribFactors.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lstHumanContribFactors.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lstHumanContribFactors.Name = "lstHumanContribFactors";
			this.lstHumanContribFactors.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.lstHumanContribFactors.TabIndex = 28;
			this.lstSuppressionFactors = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstSuppressionFactors
			// 
			this.lstSuppressionFactors.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lstSuppressionFactors.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lstSuppressionFactors.Name = "lstSuppressionFactors";
			this.lstSuppressionFactors.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.lstSuppressionFactors.TabIndex = 29;
			this.cboSpecCauseOfIgnition = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboSpecCauseOfIgnition
			// 
			this.cboSpecCauseOfIgnition.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.cboSpecCauseOfIgnition.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboSpecCauseOfIgnition.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.cboSpecCauseOfIgnition.Name = "cboSpecCauseOfIgnition";
			this.cboSpecCauseOfIgnition.TabIndex = 26;
			this.cboSpecCauseOfIgnition.Text = "cboSpecCauseOfIgnition";
			this.cboFirstItemIgnited = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboFirstItemIgnited
			// 
			this.cboFirstItemIgnited.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.cboFirstItemIgnited.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboFirstItemIgnited.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.cboFirstItemIgnited.Name = "cboFirstItemIgnited";
			this.cboFirstItemIgnited.TabIndex = 24;
			this.cboFirstItemIgnited.Text = " cboFirstItemIgnited";
			this.cboAreaOfOrigin = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboAreaOfOrigin
			// 
			this.cboAreaOfOrigin.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.cboAreaOfOrigin.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboAreaOfOrigin.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.cboAreaOfOrigin.Name = "cboAreaOfOrigin";
			this.cboAreaOfOrigin.TabIndex = 22;
			this.cboAreaOfOrigin.Text = " cboAreaOfOrigin";
			this.cboGenCauseOfIgnition = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboGenCauseOfIgnition
			// 
			this.cboGenCauseOfIgnition.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.cboGenCauseOfIgnition.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboGenCauseOfIgnition.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.cboGenCauseOfIgnition.Name = "cboGenCauseOfIgnition";
			this.cboGenCauseOfIgnition.TabIndex = 25;
			this.cboGenCauseOfIgnition.Text = "cboGenCauseOfIgnition";
			this.cboHeatSource = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboHeatSource
			// 
			this.cboHeatSource.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.cboHeatSource.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboHeatSource.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.cboHeatSource.Name = "cboHeatSource";
			this.cboHeatSource.TabIndex = 23;
			this.cboHeatSource.Text = " cboHeatSource";
			this.lbExposure1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbExposure1
			// 
			this.lbExposure1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbExposure1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbExposure1.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.lbExposure1.Name = "lbExposure1";
			this.lbExposure1.TabIndex = 203;
			this.lbExposure1.Text = "EXPOSURE";
			this.lbExposure1.Visible = false;
			this.lbPhyContribFactors = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbPhyContribFactors
			// 
			this.lbPhyContribFactors.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbPhyContribFactors.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbPhyContribFactors.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbPhyContribFactors.Name = "lbPhyContribFactors";
			this.lbPhyContribFactors.TabIndex = 158;
			this.lbPhyContribFactors.Text = "PHYSICAL CONTRIBUTING FACTORS";
			this.lbHumanContribFactors = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbHumanContribFactors
			// 
			this.lbHumanContribFactors.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbHumanContribFactors.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbHumanContribFactors.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbHumanContribFactors.Name = "lbHumanContribFactors";
			this.lbHumanContribFactors.TabIndex = 157;
			this.lbHumanContribFactors.Text = "HUMAN CONTRIBUTING FACTORS";
			this.lbSuppressFactors = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSuppressFactors
			// 
			this.lbSuppressFactors.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSuppressFactors.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbSuppressFactors.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbSuppressFactors.Name = "lbSuppressFactors";
			this.lbSuppressFactors.TabIndex = 156;
			this.lbSuppressFactors.Text = "SUPPRESSION FACTORS";
			this.lbSpecCauseIgnition = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSpecCauseIgnition
			// 
			this.lbSpecCauseIgnition.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			this.lbSpecCauseIgnition.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbSpecCauseIgnition.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbSpecCauseIgnition.Name = "lbSpecCauseIgnition";
			this.lbSpecCauseIgnition.TabIndex = 155;
			this.lbSpecCauseIgnition.Text = "SPECIFIC CAUSE OF FIRE";
			this.lbFirstIgnited = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbFirstIgnited
			// 
			this.lbFirstIgnited.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			this.lbFirstIgnited.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbFirstIgnited.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbFirstIgnited.Name = "lbFirstIgnited";
			this.lbFirstIgnited.TabIndex = 154;
			this.lbFirstIgnited.Text = "FIRST ITEM IGNITED";
			this.lbAreaOrigin = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAreaOrigin
			// 
			this.lbAreaOrigin.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAreaOrigin.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbAreaOrigin.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbAreaOrigin.Name = "lbAreaOrigin";
			this.lbAreaOrigin.TabIndex = 153;
			this.lbAreaOrigin.Text = "AREA OF ORIGIN";
			this.lbGenCauseOfIgnition = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbGenCauseOfIgnition
			// 
			this.lbGenCauseOfIgnition.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbGenCauseOfIgnition.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbGenCauseOfIgnition.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbGenCauseOfIgnition.Name = "lbGenCauseOfIgnition";
			this.lbGenCauseOfIgnition.TabIndex = 152;
			this.lbGenCauseOfIgnition.Text = "GENERAL CAUSE OF FIRE";
			this.lbHeatSource = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbHeatSource
			// 
			this.lbHeatSource.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbHeatSource.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbHeatSource.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbHeatSource.Name = "lbHeatSource";
			this.lbHeatSource.TabIndex = 151;
			this.lbHeatSource.Text = "HEAT SOURCE";
			this.frmFireInfo1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmFireInfo1
			// 
			this.frmFireInfo1.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			this.frmFireInfo1.Enabled = false;
			this.frmFireInfo1.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmFireInfo1.Name = "frmFireInfo1";
			this.frmFireInfo1.TabIndex = 150;
			this.txtPropLoss = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this.txtPropLoss.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.txtPropLoss.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtPropLoss.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.txtPropLoss.Name = "txtPropLoss";
			this.txtPropLoss.TabIndex = 40;
			this.txtContentLoss = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this.txtContentLoss.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.txtContentLoss.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtContentLoss.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.txtContentLoss.Name = "txtContentLoss";
			this.txtContentLoss.TabIndex = 41;
			this.lbContentLoss = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbContentLoss
			// 
			this.lbContentLoss.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbContentLoss.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbContentLoss.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbContentLoss.Name = "lbContentLoss";
			this.lbContentLoss.TabIndex = 149;
			this.lbContentLoss.Text = "CONTENT LOSS";
			this.lbPropLoss = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbPropLoss
			// 
			this.lbPropLoss.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbPropLoss.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbPropLoss.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbPropLoss.Name = "lbPropLoss";
			this.lbPropLoss.TabIndex = 148;
			this.lbPropLoss.Text = "PROPERTY LOSS";
			this.txtBusinessName = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtBusinessName.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtBusinessName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtBusinessName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.txtBusinessName.Name = "txtBusinessName";
			this.txtBusinessName.TabIndex = 90;
			this.cboRole = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboRole
			// 
			this.cboRole.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboRole.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboRole.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboRole.Name = "cboRole";
			this.cboRole.TabIndex = 99;
			this.cboRole.Text = "cboRole";
			this.cboRace = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboRace
			// 
			this.cboRace.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboRace.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboRace.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboRace.Name = "cboRace";
			this.cboRace.TabIndex = 103;
			this.cboRace.Text = "cboRace";
			this.txtHomePhone = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtHomePhone.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtHomePhone.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtHomePhone.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.txtHomePhone.Name = "txtHomePhone";
			this.txtHomePhone.TabIndex = 106;
			this.txtWorkPlace = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtWorkPlace.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtWorkPlace.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtWorkPlace.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.txtWorkPlace.Name = "txtWorkPlace";
			this.txtWorkPlace.TabIndex = 108;
			this.txtWorkPhone = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtWorkPhone.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtWorkPhone.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtWorkPhone.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.txtWorkPhone.Name = "txtWorkPhone";
			this.txtWorkPhone.TabIndex = 107;
			this._optGender_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optGender_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optEthnicity_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optEthnicity_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.txtHouseNumber = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtHouseNumber.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtHouseNumber.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtHouseNumber.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.txtHouseNumber.Name = "txtHouseNumber";
			this.txtHouseNumber.TabIndex = 91;
			this.txtStreetName = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtStreetName.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtStreetName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtStreetName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.txtStreetName.Name = "txtStreetName";
			this.txtStreetName.TabIndex = 93;
			this.cboPrefix = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboPrefix
			// 
			this.cboPrefix.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboPrefix.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboPrefix.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboPrefix.Name = "cboPrefix";
			this.cboPrefix.TabIndex = 92;
			this.cboPrefix.Text = "cboPrefix";
			this.cboStreetType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboStreetType
			// 
			this.cboStreetType.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboStreetType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboStreetType.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboStreetType.Name = "cboStreetType";
			this.cboStreetType.TabIndex = 94;
			this.cboStreetType.Text = "cboStreetType";
			this.cboSuffix = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboSuffix
			// 
			this.cboSuffix.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboSuffix.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboSuffix.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboSuffix.Name = "cboSuffix";
			this.cboSuffix.TabIndex = 95;
			this.cboSuffix.Text = "cboSuffix";
			this.txtCity = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtCity.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtCity.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtCity.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.txtCity.Name = "txtCity";
			this.txtCity.TabIndex = 96;
			this.cboState = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboState
			// 
			this.cboState.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboState.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboState.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboState.Name = "cboState";
			this.cboState.TabIndex = 98;
			this.cboState.Text = "cboState";
			this.txtFirstName = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtFirstName.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtFirstName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtFirstName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.txtFirstName.Name = "txtFirstName";
			this.txtFirstName.TabIndex = 87;
			this.txtMI = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtMI.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtMI.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtMI.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.txtMI.Name = "txtMI";
			this.txtMI.TabIndex = 89;
			this.cboNameList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboNameList
			// 
			this.cboNameList.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboNameList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboNameList.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboNameList.Name = "cboNameList";
			this.cboNameList.TabIndex = 86;
			this.cboNameList.Text = "cboNameList";
			this.txtLastName = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtLastName.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtLastName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtLastName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.txtLastName.Name = "txtLastName";
			this.txtLastName.TabIndex = 88;
			this.txtZipcode = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtZipcode.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtZipcode.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtZipcode.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.txtZipcode.Name = "txtZipcode";
			this.txtZipcode.TabIndex = 97;
			this.txtBirthdate = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this.txtBirthdate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtBirthdate.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.txtBirthdate.Mask = "##/##/####";
			this.txtBirthdate.Name = "txtBirthdate";
			this.txtBirthdate.TabIndex = 100;
			this.lbBusinessName = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbBusinessName
			// 
			this.lbBusinessName.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbBusinessName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbBusinessName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbBusinessName.Name = "lbBusinessName";
			this.lbBusinessName.TabIndex = 205;
			this.lbBusinessName.Text = "BUSINESS NAME";
			this.lbRole = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRole
			// 
			this.lbRole.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRole.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbRole.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbRole.Name = "lbRole";
			this.lbRole.TabIndex = 146;
			this.lbRole.Text = "ROLE";
			this.lbGender = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbGender
			// 
			this.lbGender.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbGender.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbGender.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbGender.Name = "lbGender";
			this.lbGender.TabIndex = 145;
			this.lbGender.Text = "GENDER";
			this.lbRace = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRace
			// 
			this.lbRace.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRace.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbRace.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbRace.Name = "lbRace";
			this.lbRace.TabIndex = 144;
			this.lbRace.Text = "RACE";
			this.lbEthnicity = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEthnicity
			// 
			this.lbEthnicity.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbEthnicity.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbEthnicity.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbEthnicity.Name = "lbEthnicity";
			this.lbEthnicity.TabIndex = 143;
			this.lbEthnicity.Text = "ETHNICITY";
			this.lbBirthdate = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbBirthdate
			// 
			this.lbBirthdate.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbBirthdate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbBirthdate.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbBirthdate.Name = "lbBirthdate";
			this.lbBirthdate.TabIndex = 142;
			this.lbBirthdate.Text = "BIRTHDATE";
			this.lbHomePhone = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbHomePhone
			// 
			this.lbHomePhone.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbHomePhone.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbHomePhone.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbHomePhone.Name = "lbHomePhone";
			this.lbHomePhone.TabIndex = 141;
			this.lbHomePhone.Text = "HOME PHONE";
			this.lbWorkPhone = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbWorkPhone
			// 
			this.lbWorkPhone.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbWorkPhone.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbWorkPhone.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbWorkPhone.Name = "lbWorkPhone";
			this.lbWorkPhone.TabIndex = 140;
			this.lbWorkPhone.Text = "WORK PHONE";
			this.lbWorkPlace = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbWorkPlace
			// 
			this.lbWorkPlace.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbWorkPlace.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbWorkPlace.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbWorkPlace.Name = "lbWorkPlace";
			this.lbWorkPlace.TabIndex = 139;
			this.lbWorkPlace.Text = "WORK PLACE";
			this.lbMI = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbMI
			// 
			this.lbMI.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbMI.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbMI.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbMI.Name = "lbMI";
			this.lbMI.TabIndex = 136;
			this.lbMI.Text = "M.I.";
			this.lbHouseNum = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbHouseNum
			// 
			this.lbHouseNum.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbHouseNum.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbHouseNum.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbHouseNum.Name = "lbHouseNum";
			this.lbHouseNum.TabIndex = 135;
			this.lbHouseNum.Text = "HOUSE #";
			this.lbPrefix = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbPrefix
			// 
			this.lbPrefix.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbPrefix.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbPrefix.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbPrefix.Name = "lbPrefix";
			this.lbPrefix.TabIndex = 134;
			this.lbPrefix.Text = "PREFIX";
			this.lbStreetName = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbStreetName
			// 
			this.lbStreetName.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbStreetName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbStreetName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbStreetName.Name = "lbStreetName";
			this.lbStreetName.TabIndex = 133;
			this.lbStreetName.Text = "STREET NAME";
			this.lbSuffix = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSuffix
			// 
			this.lbSuffix.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSuffix.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbSuffix.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbSuffix.Name = "lbSuffix";
			this.lbSuffix.TabIndex = 132;
			this.lbSuffix.Text = "SUFFIX";
			this.lbCity = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbCity
			// 
			this.lbCity.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbCity.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbCity.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbCity.Name = "lbCity";
			this.lbCity.TabIndex = 131;
			this.lbCity.Text = "CITY";
			this.lbState = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbState
			// 
			this.lbState.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbState.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbState.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbState.Name = "lbState";
			this.lbState.TabIndex = 130;
			this.lbState.Text = "STATE";
			this.lbFirstName = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbFirstName
			// 
			this.lbFirstName.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbFirstName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbFirstName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbFirstName.Name = "lbFirstName";
			this.lbFirstName.TabIndex = 129;
			this.lbFirstName.Text = "FIRST NAME";
			this.lbLastName = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLastName
			// 
			this.lbLastName.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbLastName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbLastName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbLastName.Name = "lbLastName";
			this.lbLastName.TabIndex = 128;
			this.lbLastName.Text = "LAST NAME";
			this.lbStreetType = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbStreetType
			// 
			this.lbStreetType.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbStreetType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbStreetType.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbStreetType.Name = "lbStreetType";
			this.lbStreetType.TabIndex = 127;
			this.lbStreetType.Text = "TYPE";
			this.lbNameTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbNameTitle
			// 
			this.lbNameTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbNameTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, ((UpgradeHelpers
					.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbNameTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.lbNameTitle.Name = "lbNameTitle";
			this.lbNameTitle.TabIndex = 126;
			this.lbNameTitle.Text = "Select Individual";
			this.lbZip = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbZip
			// 
			this.lbZip.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbZip.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbZip.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbZip.Name = "lbZip";
			this.lbZip.TabIndex = 125;
			this.lbZip.Text = "ZIPCODE";
			this.lbNameID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbNameID
			// 
			this.lbNameID.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbNameID.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbNameID.Name = "lbNameID";
			this.lbNameID.TabIndex = 124;
			this.lbNameID.Text = "lbNameID";
			this.lbNameID.Visible = false;
			this.lbNarrAuthor = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbNarrAuthor
			// 
			this.lbNarrAuthor.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.lbNarrAuthor.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbNarrAuthor.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbNarrAuthor.Name = "lbNarrAuthor";
			this.lbNarrAuthor.TabIndex = 187;
			this.lbNarrMessage = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbNarrMessage
			// 
			this.lbNarrMessage.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbNarrMessage.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, ((UpgradeHelpers
						.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbNarrMessage.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.lbNarrMessage.Name = "lbNarrMessage";
			this.lbNarrMessage.TabIndex = 186;
			this.lbNarrMessage.Text = "Narrations may only be edited by Original Author";
			this.lbNarTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbNarTitle
			// 
			this.lbNarTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbNarTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, ((UpgradeHelpers.
					Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbNarTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.lbNarTitle.Name = "lbNarTitle";
			this.lbNarTitle.TabIndex = 185;
			this.lbNarTitle.Text = "FIRE INCIDENT NARRATION - Author:";
			this.cboOSMaterialInvolved = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboOSMaterialInvolved
			// 
			this.cboOSMaterialInvolved.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboOSMaterialInvolved.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboOSMaterialInvolved.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboOSMaterialInvolved.Name = "cboOSMaterialInvolved";
			this.cboOSMaterialInvolved.TabIndex = 51;
			this.cboOSMaterialInvolved.Text = " cboOSMaterialInvolved";
			this.cboOSAreaUnits = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboOSAreaUnits
			// 
			this.cboOSAreaUnits.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.cboOSAreaUnits.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboOSAreaUnits.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.cboOSAreaUnits.Name = "cboOSAreaUnits";
			this.cboOSAreaUnits.TabIndex = 50;
			this.cboOSAreaUnits.Text = " cboOSAreaUniits";
			this.txtOSAreaAffected = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtOSAreaAffected.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.txtOSAreaAffected.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtOSAreaAffected.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.txtOSAreaAffected.Name = "txtOSAreaAffected";
			this.txtOSAreaAffected.TabIndex = 49;
			this.txtOSAreaAffected.Text = "0";
			this.cboOSCauseOfIgnition = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboOSCauseOfIgnition
			// 
			this.cboOSCauseOfIgnition.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.cboOSCauseOfIgnition.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboOSCauseOfIgnition.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.cboOSCauseOfIgnition.Name = "cboOSCauseOfIgnition";
			this.cboOSCauseOfIgnition.TabIndex = 46;
			this.cboOSCauseOfIgnition.Text = " cboOSCauseOfIgnition";
			this.cboOSSpecCauseOfIgnition = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboOSSpecCauseOfIgnition
			// 
			this.cboOSSpecCauseOfIgnition.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.cboOSSpecCauseOfIgnition.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboOSSpecCauseOfIgnition.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.cboOSSpecCauseOfIgnition.Name = "cboOSSpecCauseOfIgnition";
			this.cboOSSpecCauseOfIgnition.TabIndex = 47;
			this.cboOSSpecCauseOfIgnition.Text = " cboOSSpecCauseOfIgnition";
			this.cboOSHeatSource = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboOSHeatSource
			// 
			this.cboOSHeatSource.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.cboOSHeatSource.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboOSHeatSource.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.cboOSHeatSource.Name = "cboOSHeatSource";
			this.cboOSHeatSource.TabIndex = 45;
			this.cboOSHeatSource.Text = " cboOSHeatSource";
			this.txtOSLoss = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this.txtOSLoss.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.txtOSLoss.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtOSLoss.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.txtOSLoss.Name = "txtOSLoss";
			this.txtOSLoss.TabIndex = 48;
			this.lbOSAreaAffected = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbOSAreaAffected
			// 
			this.lbOSAreaAffected.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbOSAreaAffected.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbOSAreaAffected.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbOSAreaAffected.Name = "lbOSAreaAffected";
			this.lbOSAreaAffected.TabIndex = 121;
			this.lbOSAreaAffected.Text = "AREA AFFECTED";
			this.lbOSContentLoss = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbOSContentLoss
			// 
			this.lbOSContentLoss.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbOSContentLoss.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbOSContentLoss.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbOSContentLoss.Name = "lbOSContentLoss";
			this.lbOSContentLoss.TabIndex = 120;
			this.lbOSContentLoss.Text = "CONTENT LOSS";
			this.lbOSAreaUnits = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbOSAreaUnits
			// 
			this.lbOSAreaUnits.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbOSAreaUnits.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbOSAreaUnits.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbOSAreaUnits.Name = "lbOSAreaUnits";
			this.lbOSAreaUnits.TabIndex = 119;
			this.lbOSAreaUnits.Text = "AREA UNITS";
			this.lbOSMaterialInvolved = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbOSMaterialInvolved
			// 
			this.lbOSMaterialInvolved.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbOSMaterialInvolved.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbOSMaterialInvolved.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbOSMaterialInvolved.Name = "lbOSMaterialInvolved";
			this.lbOSMaterialInvolved.TabIndex = 118;
			this.lbOSMaterialInvolved.Text = "MATERIAL INVOLVED";
			this.lbOSCauseOfIgnition = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbOSCauseOfIgnition
			// 
			this.lbOSCauseOfIgnition.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbOSCauseOfIgnition.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbOSCauseOfIgnition.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbOSCauseOfIgnition.Name = "lbOSCauseOfIgnition";
			this.lbOSCauseOfIgnition.TabIndex = 117;
			this.lbOSCauseOfIgnition.Text = "GENERAL CAUSE OF FIRE";
			this.lbOSSpecCauseOfIgnition = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbOSSpecCauseOfIgnition
			// 
			this.lbOSSpecCauseOfIgnition.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbOSSpecCauseOfIgnition.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbOSSpecCauseOfIgnition.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbOSSpecCauseOfIgnition.Name = "lbOSSpecCauseOfIgnition";
			this.lbOSSpecCauseOfIgnition.TabIndex = 116;
			this.lbOSSpecCauseOfIgnition.Text = "SPECIFIC CAUSE OF FIRE";
			this.lbOSHeatSource = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbOSHeatSource
			// 
			this.lbOSHeatSource.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbOSHeatSource.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbOSHeatSource.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbOSHeatSource.Name = "lbOSHeatSource";
			this.lbOSHeatSource.TabIndex = 115;
			this.lbOSHeatSource.Text = "HEAT SOURCE";
			this._optOSType_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optOSType_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optOSType_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.cboLicenseState = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboLicenseState
			// 
			this.cboLicenseState.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboLicenseState.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboLicenseState.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboLicenseState.Name = "cboLicenseState";
			this.cboLicenseState.TabIndex = 217;
			this.cboLicenseState.Text = "WA";
			this.cboMobileMake = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboMobileMake
			// 
			this.cboMobileMake.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.cboMobileMake.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboMobileMake.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.cboMobileMake.Name = "cboMobileMake";
			this.cboMobileMake.TabIndex = 17;
			this.cboMobileMake.Text = " cboMobileMake";
			this.txtVehicleMake = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtVehicleMake.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.txtVehicleMake.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtVehicleMake.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.txtVehicleMake.Name = "txtVehicleMake";
			this.txtVehicleMake.TabIndex = 18;
			this.txtVehicleYear = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtVehicleYear.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.txtVehicleYear.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtVehicleYear.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.txtVehicleYear.Name = "txtVehicleYear";
			this.txtVehicleYear.TabIndex = 20;
			this.txtVehicleModel = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtVehicleModel.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtVehicleModel.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtVehicleModel.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(102)))), ((int)(((byte)(92)))));
			this.txtVehicleModel.Name = "txtVehicleModel";
			this.txtVehicleModel.TabIndex = 19;
			this.txtVIN = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtVIN.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtVIN.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtVIN.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(102)))), ((int)(((byte)(92)))));
			this.txtVIN.Name = "txtVIN";
			this.txtVIN.TabIndex = 21;
			this.lbLicenseSt = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLicenseSt
			// 
			this.lbLicenseSt.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbLicenseSt.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbLicenseSt.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbLicenseSt.Name = "lbLicenseSt";
			this.lbLicenseSt.TabIndex = 216;
			this.lbLicenseSt.Text = "LICENSE STATE";
			this.lbOtherMake = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbOtherMake
			// 
			this.lbOtherMake.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbOtherMake.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbOtherMake.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(102)))), ((int)(((byte)(92)))));
			this.lbOtherMake.Name = "lbOtherMake";
			this.lbOtherMake.TabIndex = 215;
			this.lbOtherMake.Text = "OTHER";
			this.lbVIN = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbVIN
			// 
			this.lbVIN.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbVIN.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbVIN.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(102)))), ((int)(((byte)(92)))));
			this.lbVIN.Name = "lbVIN";
			this.lbVIN.TabIndex = 78;
			this.lbVIN.Text = "VIN #";
			this.lbVehicleMake = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbVehicleMake
			// 
			this.lbVehicleMake.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbVehicleMake.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbVehicleMake.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(102)))), ((int)(((byte)(92)))));
			this.lbVehicleMake.Name = "lbVehicleMake";
			this.lbVehicleMake.TabIndex = 77;
			this.lbVehicleMake.Text = "MAKE";
			this.lbVehicleModel = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbVehicleModel
			// 
			this.lbVehicleModel.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbVehicleModel.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbVehicleModel.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(102)))), ((int)(((byte)(92)))));
			this.lbVehicleModel.Name = "lbVehicleModel";
			this.lbVehicleModel.TabIndex = 76;
			this.lbVehicleModel.Text = "MODEL";
			this.lbVehicleYear = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbVehicleYear
			// 
			this.lbVehicleYear.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbVehicleYear.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbVehicleYear.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(102)))), ((int)(((byte)(92)))));
			this.lbVehicleYear.Name = "lbVehicleYear";
			this.lbVehicleYear.TabIndex = 75;
			this.lbVehicleYear.Text = "YEAR";
			this.txtJobsLost = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtJobsLost.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtJobsLost.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtJobsLost.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.txtJobsLost.Name = "txtJobsLost";
			this.txtJobsLost.TabIndex = 39;
			this.txtJobsLost.Text = "0";
			this.txtNoPeopleDisplaced = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtNoPeopleDisplaced.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtNoPeopleDisplaced.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtNoPeopleDisplaced.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.txtNoPeopleDisplaced.Name = "txtNoPeopleDisplaced";
			this.txtNoPeopleDisplaced.TabIndex = 38;
			this.txtNoPeopleDisplaced.Text = "0";
			this.txtNoBusinessDisplaced = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtNoBusinessDisplaced.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtNoBusinessDisplaced.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtNoBusinessDisplaced.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.txtNoBusinessDisplaced.Name = "txtNoBusinessDisplaced";
			this.txtNoBusinessDisplaced.TabIndex = 37;
			this.txtNoBusinessDisplaced.Text = "0";
			this.txtSqFtBurned = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this.txtSqFtBurned.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.txtSqFtBurned.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtSqFtBurned.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.txtSqFtBurned.Name = "txtSqFtBurned";
			this.txtSqFtBurned.TabIndex = 32;
			this.txtSqFtSmokeDamage = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this.txtSqFtSmokeDamage.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.txtSqFtSmokeDamage.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtSqFtSmokeDamage.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.txtSqFtSmokeDamage.Name = "txtSqFtSmokeDamage";
			this.txtSqFtSmokeDamage.TabIndex = 34;
			this.lbSqFtSmokeDamage = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSqFtSmokeDamage
			// 
			this.lbSqFtSmokeDamage.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSqFtSmokeDamage.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbSqFtSmokeDamage.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbSqFtSmokeDamage.Name = "lbSqFtSmokeDamage";
			this.lbSqFtSmokeDamage.TabIndex = 111;
			this.lbSqFtSmokeDamage.Text = "SQ FT SMOKE DAMAGED";
			this.lbSqFtBurned = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSqFtBurned
			// 
			this.lbSqFtBurned.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSqFtBurned.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbSqFtBurned.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbSqFtBurned.Name = "lbSqFtBurned";
			this.lbSqFtBurned.TabIndex = 110;
			this.lbSqFtBurned.Text = "SQ FT BURNED";
			this.lbNoBusinessDisplaced = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbNoBusinessDisplaced
			// 
			this.lbNoBusinessDisplaced.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbNoBusinessDisplaced.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbNoBusinessDisplaced.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbNoBusinessDisplaced.Name = "lbNoBusinessDisplaced";
			this.lbNoBusinessDisplaced.TabIndex = 73;
			this.lbNoBusinessDisplaced.Text = "NUMBER OF BUSINESSES DISPLACED";
			this.lbNoPeopleDisplaced = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbNoPeopleDisplaced
			// 
			this.lbNoPeopleDisplaced.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbNoPeopleDisplaced.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbNoPeopleDisplaced.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbNoPeopleDisplaced.Name = "lbNoPeopleDisplaced";
			this.lbNoPeopleDisplaced.TabIndex = 72;
			this.lbNoPeopleDisplaced.Text = "NUMBER OF PEOPLE DISPLACED";
			this.lbJobsLost = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbJobsLost
			// 
			this.lbJobsLost.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbJobsLost.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbJobsLost.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbJobsLost.Name = "lbJobsLost";
			this.lbJobsLost.TabIndex = 71;
			this.lbJobsLost.Text = "JOBS LOST";
			this.txtNumberExposures = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtNumberExposures.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtNumberExposures.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtNumberExposures.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(102)))), ((int)(((byte)(92)))));
			this.txtNumberExposures.Name = "txtNumberExposures";
			this.txtNumberExposures.TabIndex = 230;
			this.txtNumberExposures.Visible = false;
			this.txtFloorOfOrigin = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtFloorOfOrigin.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.txtFloorOfOrigin.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtFloorOfOrigin.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.txtFloorOfOrigin.Name = "txtFloorOfOrigin";
			this.txtFloorOfOrigin.TabIndex = 30;
			this.cboBurnDamage = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboBurnDamage
			// 
			this.cboBurnDamage.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.cboBurnDamage.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboBurnDamage.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.cboBurnDamage.Name = "cboBurnDamage";
			this.cboBurnDamage.TabIndex = 31;
			this.cboBurnDamage.Text = " cboBurnDamage";
			this.lstEquipInvolvIgnition = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstEquipInvolvIgnition
			// 
			this.lstEquipInvolvIgnition.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lstEquipInvolvIgnition.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lstEquipInvolvIgnition.Name = "lstEquipInvolvIgnition";
			this.lstEquipInvolvIgnition.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.lstEquipInvolvIgnition.TabIndex = 36;
			this.lstItemContribFireSpread = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstItemContribFireSpread
			// 
			this.lstItemContribFireSpread.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lstItemContribFireSpread.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lstItemContribFireSpread.Name = "lstItemContribFireSpread";
			this.lstItemContribFireSpread.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.lstItemContribFireSpread.TabIndex = 35;
			this.cboSmokeDamage = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboSmokeDamage
			// 
			this.cboSmokeDamage.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.cboSmokeDamage.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboSmokeDamage.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.cboSmokeDamage.Name = "cboSmokeDamage";
			this.cboSmokeDamage.TabIndex = 33;
			this.cboSmokeDamage.Text = "cboSmokeDamage";
			this.lbNumExp = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbNumExp
			// 
			this.lbNumExp.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbNumExp.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbNumExp.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbNumExp.Name = "lbNumExp";
			this.lbNumExp.TabIndex = 229;
			this.lbNumExp.Text = "# OF EXPOSURES";
			this.lbNumExp.Visible = false;
			this.lbFlOfOrigin = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbFlOfOrigin
			// 
			this.lbFlOfOrigin.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbFlOfOrigin.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbFlOfOrigin.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbFlOfOrigin.Name = "lbFlOfOrigin";
			this.lbFlOfOrigin.TabIndex = 85;
			this.lbFlOfOrigin.Text = "FLOOR OF ORIGIN";
			this.lbBurnDamage = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbBurnDamage
			// 
			this.lbBurnDamage.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			this.lbBurnDamage.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbBurnDamage.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbBurnDamage.Name = "lbBurnDamage";
			this.lbBurnDamage.TabIndex = 84;
			this.lbBurnDamage.Text = "BURN DAMAGE";
			this._lbEquipInvolvIgnition_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbContribFireSpread = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbContribFireSpread
			// 
			this.lbContribFireSpread.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			this.lbContribFireSpread.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbContribFireSpread.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbContribFireSpread.Name = "lbContribFireSpread";
			this.lbContribFireSpread.TabIndex = 68;
			this.lbContribFireSpread.Text = "ITEMS CONTRIBUTING TO FIRE SPREAD";
			this.lbSmokeDamage = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSmokeDamage
			// 
			this.lbSmokeDamage.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			this.lbSmokeDamage.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbSmokeDamage.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbSmokeDamage.Name = "lbSmokeDamage";
			this.lbSmokeDamage.TabIndex = 67;
			this.lbSmokeDamage.Text = "SMOKE DAMAGE";
			this._optExtinguish_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optExtinguish_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.lstExtFailure = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstExtFailure
			// 
			this.lstExtFailure.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lstExtFailure.Enabled = false;
			this.lstExtFailure.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lstExtFailure.Name = "lstExtFailure";
			this.lstExtFailure.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.lstExtFailure.TabIndex = 15;
			this.cboExtEffectiveness = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboExtEffectiveness
			// 
			this.cboExtEffectiveness.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.cboExtEffectiveness.Enabled = false;
			this.cboExtEffectiveness.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboExtEffectiveness.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.cboExtEffectiveness.Name = "cboExtEffectiveness";
			this.cboExtEffectiveness.TabIndex = 14;
			this.cboExtEffectiveness.Text = "cboExtEffectiveness";
			this.cboSysType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboSysType
			// 
			this.cboSysType.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.cboSysType.Enabled = false;
			this.cboSysType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboSysType.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.cboSysType.Name = "cboSysType";
			this.cboSysType.TabIndex = 10;
			this.cboSysType.Text = " cboSysType";
			this.Line2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Line2
			// 
			this.Line2.BackColor = UpgradeHelpers.Helpers.Color.Gray;
			this.Line2.Enabled = false;
			this.Line2.Name = "Line2";
			this.Line2.TabIndex = 17;
			this.lbExtEffective = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbExtEffective
			// 
			this.lbExtEffective.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbExtEffective.Enabled = false;
			this.lbExtEffective.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbExtEffective.ForeColor = UpgradeHelpers.Helpers.Color.Gray;
			this.lbExtEffective.Name = "lbExtEffective";
			this.lbExtEffective.TabIndex = 61;
			this.lbExtEffective.Text = "EFFECTIVENESS";
			this.lbSysType = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSysType
			// 
			this.lbSysType.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSysType.Enabled = false;
			this.lbSysType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbSysType.ForeColor = UpgradeHelpers.Helpers.Color.Gray;
			this.lbSysType.Name = "lbSysType";
			this.lbSysType.TabIndex = 60;
			this.lbSysType.Text = "SYSTEM TYPE";
			this.lbSysReasonFailure = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSysReasonFailure
			// 
			this.lbSysReasonFailure.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSysReasonFailure.Enabled = false;
			this.lbSysReasonFailure.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbSysReasonFailure.ForeColor = UpgradeHelpers.Helpers.Color.Gray;
			this.lbSysReasonFailure.Name = "lbSysReasonFailure";
			this.lbSysReasonFailure.TabIndex = 59;
			this.lbSysReasonFailure.Text = "PROBLEMS";
			this.cboInitiatingDevice = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboInitiatingDevice
			// 
			this.cboInitiatingDevice.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.cboInitiatingDevice.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboInitiatingDevice.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.cboInitiatingDevice.Name = "cboInitiatingDevice";
			this.cboInitiatingDevice.TabIndex = 4;
			this.cboInitiatingDevice.Text = " cboInitiatingDevice";
			this.cboInitiatingDevice.Visible = false;
			this._optAlarmType_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optAlarmType_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optAlarmType_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.lstAlarmFailure = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstAlarmFailure
			// 
			this.lstAlarmFailure.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lstAlarmFailure.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lstAlarmFailure.Name = "lstAlarmFailure";
			this.lstAlarmFailure.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.lstAlarmFailure.TabIndex = 6;
			this.lstAlarmFailure.Visible = false;
			this.cboEffectiveness = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboEffectiveness
			// 
			this.cboEffectiveness.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.cboEffectiveness.Enabled = false;
			this.cboEffectiveness.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboEffectiveness.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.cboEffectiveness.Name = "cboEffectiveness";
			this.cboEffectiveness.TabIndex = 5;
			this.cboEffectiveness.Text = " cboEffectiveness";
			this.cboAlarmType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboAlarmType
			// 
			this.cboAlarmType.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.cboAlarmType.Enabled = false;
			this.cboAlarmType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboAlarmType.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.cboAlarmType.Name = "cboAlarmType";
			this.cboAlarmType.TabIndex = 52;
			this.cboAlarmType.Text = " cboAlarmType";
			this.Line1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Line1
			// 
			this.Line1.BackColor = UpgradeHelpers.Helpers.Color.Gray;
			this.Line1.Enabled = false;
			this.Line1.Name = "Line1";
			this.Line1.TabIndex = 53;
			this.lbInitiatingDevice = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbInitiatingDevice
			// 
			this.lbInitiatingDevice.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbInitiatingDevice.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbInitiatingDevice.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbInitiatingDevice.Name = "lbInitiatingDevice";
			this.lbInitiatingDevice.TabIndex = 79;
			this.lbInitiatingDevice.Text = "INITIATING DEVICE";
			this.lbInitiatingDevice.Visible = false;
			this.lbReasonFailure = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbReasonFailure
			// 
			this.lbReasonFailure.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbReasonFailure.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbReasonFailure.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lbReasonFailure.Name = "lbReasonFailure";
			this.lbReasonFailure.TabIndex = 58;
			this.lbReasonFailure.Text = "PROBLEMS";
			this.lbReasonFailure.Visible = false;
			this.lbEffectiveness = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEffectiveness
			// 
			this.lbEffectiveness.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbEffectiveness.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbEffectiveness.ForeColor = UpgradeHelpers.Helpers.Color.Gray;
			this.lbEffectiveness.Name = "lbEffectiveness";
			this.lbEffectiveness.TabIndex = 57;
			this.lbEffectiveness.Text = "EFFECTIVENESS";
			this.lbAlarmType = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAlarmType
			// 
			this.lbAlarmType.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAlarmType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbAlarmType.ForeColor = UpgradeHelpers.Helpers.Color.Gray;
			this.lbAlarmType.Name = "lbAlarmType";
			this.lbAlarmType.TabIndex = 56;
			this.lbAlarmType.Text = "SYSTEM TYPE";
			this.lbVYearMes = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbVYearMes
			// 
			this.lbVYearMes.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbVYearMes.Enabled = false;
			this.lbVYearMes.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 16.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbVYearMes.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.lbVYearMes.Name = "lbVYearMes";
			this.lbVYearMes.TabIndex = 213;
			this.lbVYearMes.Text = "4 digit Year required If unknown make best guess";
			this.lbVYearMes.Visible = false;
			this.tabFire = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabControlViewModel>();
			this.tabFire.Name = "tabFire";
			this.tabFire.SelectedIndex = 0;
			this.tabFire.TabIndex = 0;
			this.lbExposure2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbExposure2
			// 
			this.lbExposure2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbExposure2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbExposure2.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.lbExposure2.Name = "lbExposure2";
			this.lbExposure2.TabIndex = 204;
			this.lbExposure2.Text = "EXPOSURE";
			this.lbExposure2.Visible = false;
			this.lbLockedMessage = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLockedMessage
			// 
			this.lbLockedMessage.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lbLockedMessage.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.lbLockedMessage.Name = "lbLockedMessage";
			this.lbLockedMessage.TabIndex = 188;
			this.lbLockedMessage.Text = "READ ONLY - Records Locked";
			this.lbLocation = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLocation
			// 
			this.lbLocation.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbLocation.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbLocation.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.lbLocation.Name = "lbLocation";
			this.lbLocation.TabIndex = 65;
			this.lbLocation.Text = "lbLocation";
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 64;
			this.Label2.Text = "Incident #";
			this.lbIncident = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbIncident
			// 
			this.lbIncident.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbIncident.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbIncident.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.lbIncident.Name = "lbIncident";
			this.lbIncident.TabIndex = 63;
			this.lbIncident.Text = "001230012";
			this.picFireBar = ctx.Resolve<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>();
			// 
			// picFireBar
			// 
			this.picFireBar.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.picFireBar.Name = "picFireBar";
			this.chkAlarmOperation = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkAlarmOperation
			// 
			this.chkAlarmOperation.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			this.chkAlarmOperation.Enabled = false;
			this.chkAlarmOperation.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkAlarmOperation.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.chkAlarmOperation.Name = "chkAlarmOperation";
			this.chkAlarmOperation.TabIndex = 7;
			this.chkAlarmOperation.Text = "DETECTOR/ALARM OPERATED";
			this.chkExtOperation = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkExtOperation
			// 
			this.chkExtOperation.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			this.chkExtOperation.Enabled = false;
			this.chkExtOperation.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkExtOperation.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.chkExtOperation.Name = "chkExtOperation";
			this.chkExtOperation.TabIndex = 16;
			this.chkExtOperation.Text = "EXTINGUISHING SYSTEM OPERATED";
			this.cmdCancelExit = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdCancelExit
			// 
			this.cmdCancelExit.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdCancelExit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.6F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdCancelExit.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdCancelExit.Name = "cmdCancelExit";
			this.cmdCancelExit.TabIndex = 53;
			this.cmdCancelExit.Text = "Exit Without Saving";
			this.chkExposures = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkExposures
			// 
			this.chkExposures.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			this.chkExposures.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkExposures.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.chkExposures.Name = "chkExposures";
			this.chkExposures.TabIndex = 228;
			this.chkExposures.Text = "STRUCTURE EXPOSURES?";
			this._optFloor_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this._optFloor_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this._optFloor_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkMobileInvolved = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkMobileInvolved
			// 
			this.chkMobileInvolved.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			this.chkMobileInvolved.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkMobileInvolved.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.chkMobileInvolved.Name = "chkMobileInvolved";
			this.chkMobileInvolved.TabIndex = 231;
			this.chkMobileInvolved.Text = "MOBILE PROPERTY INVOLVED?";
			this.cmdAddNarration = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAddNarration
			// 
			this.cmdAddNarration.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAddNarration.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdAddNarration.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAddNarration.Name = "cmdAddNarration";
			this.cmdAddNarration.TabIndex = 81;
			this.cmdAddNarration.Tag = "1";
			this.cmdAddNarration.Text = "Add New Narration";

			this.rtxNarration = ctx.Resolve<Stubs._System.Windows.Forms.RichTextBox>();
			// 
			// rtxNarration
			// 
			this.rtxNarration.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.rtxNarration.Name = "rtxNarration";
			this.rtxNarration.TabIndex = 82;
			this.rtxNarration.Tag = "1";
			this.rtxNarration.Text = "";
			this.cmdMoreNames = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdMoreNames
			// 
			this.cmdMoreNames.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdMoreNames.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdMoreNames.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdMoreNames.Name = "cmdMoreNames";
			this.cmdMoreNames.TabIndex = 109;
			this.cmdMoreNames.Tag = "1";
			this.cmdMoreNames.Text = "Add New Name Record";
			this.cmdHelp = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this.cmdHelp.Name = "cmdHelp";
			this.cmdHelp.TabIndex = 214;
			this._cmdSave_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._cmdSave_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._cmdSave_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._cmdSave_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this.tabPage1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Text = "Building Info";
			this.tabPage2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Text = "Mobile Property";
			this.tabPage3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Text = "Fire Info";
			this.tabPage4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Text = "Loss Info";
			this.tabPage5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Text = "Outside Fire";
			this.tabPage6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Text = "Narration";
			this.tabPage7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage7.Name = "tabPage7";
			this.tabPage7.Text = "Names";
			this.tabPage8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage8.Name = "tabPage8";
			this.tabPage8.Text = "Address";
			this.Text = "Form1";
			this.frmNar1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmNar1
			// 
			this.frmNar1.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			this.frmNar1.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmNar1.Name = "frmNar1";
			this.frmNar1.TabIndex = 122;
			this.frmNarrSelect = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmNarrSelect
			// 
			this.frmNarrSelect.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			this.frmNarrSelect.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmNarrSelect.Name = "frmNarrSelect";
			this.frmNarrSelect.TabIndex = 210;
			this.frmName1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmName1
			// 
			this.frmName1.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			this.frmName1.Enabled = false;
			this.frmName1.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmName1.Name = "frmName1";
			this.frmName1.TabIndex = 123;
			this.frmGender = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmGender
			// 
			this.frmGender.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			this.frmGender.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmGender.Name = "frmGender";
			this.frmGender.TabIndex = 138;
			optGender = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(2);
			optGender[0] = _optGender_0;
			optGender[1] = _optGender_1;
			optGender[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			optGender[0].Checked = true;
			optGender[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optGender[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			optGender[0].Name = "_optGender_0";
			optGender[0].TabIndex = 101;
			optGender[0].Text = "MALE";
			optGender[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			optGender[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optGender[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			optGender[1].Name = "_optGender_1";
			optGender[1].TabIndex = 102;
			optGender[1].Text = "FEMALE";
			this.frmEthnicity = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmEthnicity
			// 
			this.frmEthnicity.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			this.frmEthnicity.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmEthnicity.Name = "frmEthnicity";
			this.frmEthnicity.TabIndex = 137;
			optEthnicity = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(2);
			optEthnicity[0] = _optEthnicity_0;
			optEthnicity[1] = _optEthnicity_1;
			optEthnicity[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			optEthnicity[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optEthnicity[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			optEthnicity[0].Name = "_optEthnicity_0";
			optEthnicity[0].TabIndex = 104;
			optEthnicity[0].Text = "HISPANIC";
			optEthnicity[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			optEthnicity[1].Checked = true;
			optEthnicity[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optEthnicity[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			optEthnicity[1].Name = "_optEthnicity_1";
			optEthnicity[1].TabIndex = 105;
			optEthnicity[1].Text = "NON-HISPANIC";
			this.ReportType = 0;
			this.frmAlarm = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmAlarm
			// 
			this.frmAlarm.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			this.frmAlarm.Enabled = false;
			this.frmAlarm.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.frmAlarm.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.frmAlarm.Name = "frmAlarm";
			this.frmAlarm.TabIndex = 54;
			this.frmAlarm.Text = "FIRE ALARM INFORMATION";
			this.frmExtinguish = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmExtinguish
			// 
			this.frmExtinguish.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			this.frmExtinguish.Enabled = false;
			this.frmExtinguish.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.frmExtinguish.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.frmExtinguish.Name = "frmExtinguish";
			this.frmExtinguish.TabIndex = 55;
			this.frmExtinguish.Text = "EXTINGUISHING SYSTEM INFORMATION";
			this.chkRental = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkRental
			// 
			this.chkRental.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			this.chkRental.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkRental.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.chkRental.Name = "chkRental";
			this.chkRental.TabIndex = 169;
			this.chkRental.Text = "RENTAL?";
			this.frmFireOnly = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmFireOnly
			// 
			this.frmFireOnly.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			this.frmFireOnly.Enabled = false;
			this.frmFireOnly.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmFireOnly.Name = "frmFireOnly";
			this.frmFireOnly.TabIndex = 66;
			this.frmFloor = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmFloor
			// 
			this.frmFloor.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			this.frmFloor.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.frmFloor.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.frmFloor.Name = "frmFloor";
			this.frmFloor.TabIndex = 113;
			optFloor = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>>(3);
			optFloor[2] = _optFloor_2;
			optFloor[1] = _optFloor_1;
			optFloor[0] = _optFloor_0;
			optFloor[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			optFloor[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optFloor[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			optFloor[2].Name = "_optFloor_2";
			optFloor[2].TabIndex = 222;
			optFloor[2].Text = "ROOF";
			optFloor[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			optFloor[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optFloor[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			optFloor[1].Name = "_optFloor_1";
			optFloor[1].TabIndex = 221;
			optFloor[1].Text = "ATTIC";
			optFloor[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			optFloor[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optFloor[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			optFloor[0].Name = "_optFloor_0";
			optFloor[0].TabIndex = 220;
			optFloor[0].Text = "BASEMENT";
			lbEquipInvolvIgnition = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(1);
			lbEquipInvolvIgnition[0] = _lbEquipInvolvIgnition_0;
			lbEquipInvolvIgnition[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			lbEquipInvolvIgnition[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbEquipInvolvIgnition[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			lbEquipInvolvIgnition[0].Name = "_lbEquipInvolvIgnition_0";
			lbEquipInvolvIgnition[0].TabIndex = 69;
			lbEquipInvolvIgnition[0].Text = "EQUIPMENT INVOLVED IN IGNITION";
			this.frmFireLoss = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmFireLoss
			// 
			this.frmFireLoss.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			this.frmFireLoss.Enabled = false;
			this.frmFireLoss.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmFireLoss.Name = "frmFireLoss";
			this.frmFireLoss.TabIndex = 70;
			this.frmPropLoss = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmPropLoss
			// 
			this.frmPropLoss.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			this.frmPropLoss.Enabled = false;
			this.frmPropLoss.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmPropLoss.Name = "frmPropLoss";
			this.frmPropLoss.TabIndex = 147;
			this.frmVehicle = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmVehicle
			// 
			this.frmVehicle.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			this.frmVehicle.Enabled = false;
			this.frmVehicle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.frmVehicle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(102)))), ((int)(((byte)(92)))));
			this.frmVehicle.Name = "frmVehicle";
			this.frmVehicle.TabIndex = 74;
			this.frmVehicle.Text = "Vehicle Information";
			this.frmOSType = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmOSType
			// 
			this.frmOSType.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			this.frmOSType.Enabled = false;
			this.frmOSType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.frmOSType.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.frmOSType.Name = "frmOSType";
			this.frmOSType.TabIndex = 112;
			this.frmOSType.Text = "Outside Fire Type";
			this.frmOSMain = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmOSMain
			// 
			this.frmOSMain.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			this.frmOSMain.Enabled = false;
			this.frmOSMain.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmOSMain.Name = "frmOSMain";
			this.frmOSMain.TabIndex = 114;
			this.RuptureReportID = 0;
			this.FirstTime = 0;
			cmdSave = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel>>(4);
			cmdSave[2] = _cmdSave_2;
			cmdSave[1] = _cmdSave_1;
			cmdSave[0] = _cmdSave_0;
			cmdSave[3] = _cmdSave_3;
			cmdSave[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdSave[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cmdSave[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdSave[2].Name = "_cmdSave_2";
			cmdSave[2].TabIndex = 209;
			cmdSave[2].Text = "Cancel and Exit";
			cmdSave[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdSave[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cmdSave[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdSave[1].Name = "_cmdSave_1";
			cmdSave[1].TabIndex = 208;
			cmdSave[1].Text = "Save as Incomplete";
			cmdSave[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdSave[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cmdSave[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdSave[0].Name = "_cmdSave_0";
			cmdSave[0].TabIndex = 207;
			cmdSave[0].Text = "Save as Complete";
			cmdSave[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdSave[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cmdSave[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdSave[3].Name = "_cmdSave_3";
			cmdSave[3].TabIndex = 206;
			cmdSave[3].Text = "Print";
			optOSType = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(3);
			optOSType[2] = _optOSType_2;
			optOSType[1] = _optOSType_1;
			optOSType[0] = _optOSType_0;
			optOSType[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			optOSType[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optOSType[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			optOSType[2].Name = "_optOSType_2";
			optOSType[2].TabIndex = 44;
			optOSType[2].Text = "Other Outside Fire";
			optOSType[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			optOSType[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optOSType[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			optOSType[1].Name = "_optOSType_1";
			optOSType[1].TabIndex = 43;
			optOSType[1].Text = "Dumpster";
			optOSType[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			optOSType[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optOSType[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			optOSType[0].Name = "_optOSType_0";
			optOSType[0].TabIndex = 42;
			optOSType[0].Text = "Grass/Brush/Trees";
			optAlarmType = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(3);
			optAlarmType[2] = _optAlarmType_2;
			optAlarmType[1] = _optAlarmType_1;
			optAlarmType[0] = _optAlarmType_0;
			optAlarmType[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			optAlarmType[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optAlarmType[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			optAlarmType[2].Name = "_optAlarmType_2";
			optAlarmType[2].TabIndex = 3;
			optAlarmType[2].Text = "ALARM SYSTEM";
			optAlarmType[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			optAlarmType[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optAlarmType[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			optAlarmType[1].Name = "_optAlarmType_1";
			optAlarmType[1].TabIndex = 2;
			optAlarmType[1].Text = "UNIT DETECTORS ONLY (RESIDENTIAL)";
			optAlarmType[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			optAlarmType[0].Checked = true;
			optAlarmType[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optAlarmType[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			optAlarmType[0].Name = "_optAlarmType_0";
			optAlarmType[0].TabIndex = 1;
			optAlarmType[0].Text = "NO ALARM INVOLVED";
			optExtinguish = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(2);
			optExtinguish[1] = _optExtinguish_1;
			optExtinguish[0] = _optExtinguish_0;
			optExtinguish[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			optExtinguish[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optExtinguish[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			optExtinguish[1].Name = "_optExtinguish_1";
			optExtinguish[1].TabIndex = 9;
			optExtinguish[1].Text = "EXTINGUISHING SYSTEM INVOLVED";
			optExtinguish[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
			optExtinguish[0].Checked = true;
			optExtinguish[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optExtinguish[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			optExtinguish[0].Name = "_optExtinguish_0";
			optExtinguish[0].TabIndex = 8;
			optExtinguish[0].Text = "NO EXTINGUISHING SYSTEM INVOLVED";
			this.CurrIncident = 0;
			this.NarrationUpdated = 0;
			this.NameUpdated = 0;
			this.ADDRESSCORRECTION = 0;
			this.AddressUpdated = 0;
			this.HumansAFactor = 0;
			this.FireReportID = 0;
			optHFGender = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(2);
			optHFGender[0] = _optHFGender_0;
			optHFGender[1] = _optHFGender_1;
			optHFGender[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(189)))), ((int)(((byte)(100)))));
			optHFGender[0].Checked = true;
			optHFGender[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optHFGender[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			optHFGender[0].Name = "_optHFGender_0";
			optHFGender[0].TabIndex = 226;
			optHFGender[0].Text = "MALE";
			optHFGender[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(189)))), ((int)(((byte)(100)))));
			optHFGender[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optHFGender[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			optHFGender[1].Name = "_optHFGender_1";
			optHFGender[1].TabIndex = 225;
			optHFGender[1].Text = "FEMALE";
			this.ExposureOccured = 0;
			this.ReportingUnit = "";
			this.Name = "TFDIncident.frmFireReport";
			IsMdiChild = true;
			lstPhysicalContribFactors.Items.Add("lstPhysicalContribFactors");
			lstHumanContribFactors.Items.Add("lstHumanContribFactors");
			lstSuppressionFactors.Items.Add("lstSuppressionFactors");
			lstEquipInvolvIgnition.Items.Add("lstEquipInvolvIgnition");
			lstItemContribFireSpread.Items.Add("lstItemContribFireSpread");
			lstExtFailure.Items.Add("lstExtFailure");
			lstAlarmFailure.Items.Add("lstAlarmFailure");
			tabFire.Items.Add(tabPage1);
			tabFire.Items.Add(tabPage2);
			tabFire.Items.Add(tabPage3);
			tabFire.Items.Add(tabPage4);
			tabFire.Items.Add(tabPage5);
			tabFire.Items.Add(tabPage6);
			tabFire.Items.Add(tabPage7);
			tabFire.Items.Add(tabPage8);
		}

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboNarrList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbNarrID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbNarrSelTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboXSuffix { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboXStreetType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboXPrefix { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtXStreetName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtXHouseNumber { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboCityCode { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAddressTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtBasementLevels { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtNumberOfBusinesses { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtNumberOfOccupants { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtNumberOfUnits { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtNumberOfStories { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboConstructionType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboBuildingStatus { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboSpecificPropertyUse { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboGeneralPropertyUse { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel txtTotalSqFootage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel txtPropValue { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbBasementLevel { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbNoStories { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbTotSqFt { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbNumberOfUnits { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbNoOccupants { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbNoBusinesses { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbPropValue { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbConstructionType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbBldgStatus { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSpecificOccupancy { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbGenOccupancy { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmBI1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtMobilePropValue { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboMobilePropType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtVesselLength { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbMobilePropValue { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbMobilePropType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbVesselLength { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmMobile1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optHFGender_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optHFGender_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtHFAge { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmHFDetail { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstPhysicalContribFactors { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstHumanContribFactors { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstSuppressionFactors { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboSpecCauseOfIgnition { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboFirstItemIgnited { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboAreaOfOrigin { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboGenCauseOfIgnition { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboHeatSource { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbExposure1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbPhyContribFactors { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbHumanContribFactors { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSuppressFactors { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSpecCauseIgnition { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbFirstIgnited { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAreaOrigin { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbGenCauseOfIgnition { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbHeatSource { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmFireInfo1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel txtPropLoss { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel txtContentLoss { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbContentLoss { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbPropLoss { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtBusinessName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboRole { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboRace { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtHomePhone { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtWorkPlace { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtWorkPhone { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optGender_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optGender_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optEthnicity_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optEthnicity_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtHouseNumber { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtStreetName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboPrefix { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboStreetType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboSuffix { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtCity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboState { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtFirstName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtMI { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboNameList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtLastName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtZipcode { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel txtBirthdate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbBusinessName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRole { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbGender { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRace { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEthnicity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbBirthdate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbHomePhone { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbWorkPhone { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbWorkPlace { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbMI { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbHouseNum { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbPrefix { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbStreetName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSuffix { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbCity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbState { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbFirstName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLastName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbStreetType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbNameTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbZip { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbNameID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbNarrAuthor { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbNarrMessage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbNarTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboOSMaterialInvolved { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboOSAreaUnits { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtOSAreaAffected { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboOSCauseOfIgnition { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboOSSpecCauseOfIgnition { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboOSHeatSource { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel txtOSLoss { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbOSAreaAffected { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbOSContentLoss { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbOSAreaUnits { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbOSMaterialInvolved { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbOSCauseOfIgnition { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbOSSpecCauseOfIgnition { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbOSHeatSource { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optOSType_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optOSType_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optOSType_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboLicenseState { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboMobileMake { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtVehicleMake { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtVehicleYear { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtVehicleModel { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtVIN { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLicenseSt { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbOtherMake { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbVIN { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbVehicleMake { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbVehicleModel { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbVehicleYear { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtJobsLost { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtNoPeopleDisplaced { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtNoBusinessDisplaced { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel txtSqFtBurned { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel txtSqFtSmokeDamage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSqFtSmokeDamage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSqFtBurned { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbNoBusinessDisplaced { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbNoPeopleDisplaced { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbJobsLost { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtNumberExposures { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtFloorOfOrigin { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboBurnDamage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstEquipInvolvIgnition { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstItemContribFireSpread { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboSmokeDamage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbNumExp { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbFlOfOrigin { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbBurnDamage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbEquipInvolvIgnition_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbContribFireSpread { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSmokeDamage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optExtinguish_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optExtinguish_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstExtFailure { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboExtEffectiveness { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboSysType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Line2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbExtEffective { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSysType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSysReasonFailure { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboInitiatingDevice { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optAlarmType_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optAlarmType_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optAlarmType_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstAlarmFailure { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboEffectiveness { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboAlarmType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Line1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbInitiatingDevice { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbReasonFailure { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEffectiveness { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAlarmType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbVYearMes { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabControlViewModel tabFire { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbExposure2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLockedMessage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLocation { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbIncident { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PictureBoxViewModel picFireBar { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkAlarmOperation { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkExtOperation { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdCancelExit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkExposures { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _optFloor_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _optFloor_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _optFloor_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkMobileInvolved { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAddNarration { get; set; }

		public virtual Stubs._System.Windows.Forms.RichTextBox rtxNarration { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdMoreNames { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdHelp { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdSave_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdSave_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdSave_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdSave_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage8 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean isInitializingComponent { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmNar1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmNarrSelect { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmName1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmGender { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optGender { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmEthnicity { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optEthnicity { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 ReportType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmAlarm { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmExtinguish { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkRental { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmFireOnly { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmFloor { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.CheckBoxViewModel> optFloor { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbEquipInvolvIgnition { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmFireLoss { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmPropLoss { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmVehicle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmOSType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmOSMain { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 RuptureReportID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 FirstTime { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel> cmdSave { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optOSType { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optAlarmType { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optExtinguish { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrIncident { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 NarrationUpdated { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 NameUpdated { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 ADDRESSCORRECTION { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 AddressUpdated { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 HumansAFactor { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 FireReportID { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optHFGender { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 ExposureOccured { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String ReportingUnit { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

		public void OntxtNumberOfBusinesses_TextChanged()
		{
			if ( _txtNumberOfBusinesses_TextChanged != null )
				_txtNumberOfBusinesses_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtNumberOfBusinesses_TextChanged;

		public void OntxtNumberOfOccupants_TextChanged()
		{
			if ( _txtNumberOfOccupants_TextChanged != null )
				_txtNumberOfOccupants_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtNumberOfOccupants_TextChanged;

		public void OntxtNumberOfUnits_TextChanged()
		{
			if ( _txtNumberOfUnits_TextChanged != null )
				_txtNumberOfUnits_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtNumberOfUnits_TextChanged;

		public void OntxtNumberOfStories_TextChanged()
		{
			if ( _txtNumberOfStories_TextChanged != null )
				_txtNumberOfStories_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtNumberOfStories_TextChanged;

		public void OntxtVehicleMake_TextChanged()
		{
			if ( _txtVehicleMake_TextChanged != null )
				_txtVehicleMake_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtVehicleMake_TextChanged;

		public void OntxtFloorOfOrigin_TextChanged()
		{
			if ( _txtFloorOfOrigin_TextChanged != null )
				_txtFloorOfOrigin_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtFloorOfOrigin_TextChanged;

		public void OntxtHFAge_TextChanged()
		{
			if ( _txtHFAge_TextChanged != null )
				_txtHFAge_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtHFAge_TextChanged;

		public void OntxtBusinessName_TextChanged()
		{
			if ( _txtBusinessName_TextChanged != null )
				_txtBusinessName_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtBusinessName_TextChanged;

		public void OntxtHomePhone_TextChanged()
		{
			if ( _txtHomePhone_TextChanged != null )
				_txtHomePhone_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtHomePhone_TextChanged;

		public void OntxtWorkPlace_TextChanged()
		{
			if ( _txtWorkPlace_TextChanged != null )
				_txtWorkPlace_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtWorkPlace_TextChanged;

		public void OntxtWorkPhone_TextChanged()
		{
			if ( _txtWorkPhone_TextChanged != null )
				_txtWorkPhone_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtWorkPhone_TextChanged;

		public void OntxtHouseNumber_TextChanged()
		{
			if ( _txtHouseNumber_TextChanged != null )
				_txtHouseNumber_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtHouseNumber_TextChanged;

		public void OntxtStreetName_TextChanged()
		{
			if ( _txtStreetName_TextChanged != null )
				_txtStreetName_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtStreetName_TextChanged;

		public void OntxtCity_TextChanged()
		{
			if ( _txtCity_TextChanged != null )
				_txtCity_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtCity_TextChanged;

		public void OntxtFirstName_TextChanged()
		{
			if ( _txtFirstName_TextChanged != null )
				_txtFirstName_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtFirstName_TextChanged;

		public void OntxtMI_TextChanged()
		{
			if ( _txtMI_TextChanged != null )
				_txtMI_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtMI_TextChanged;

		public void OntxtLastName_TextChanged()
		{
			if ( _txtLastName_TextChanged != null )
				_txtLastName_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtLastName_TextChanged;

		public void OntxtZipcode_TextChanged()
		{
			if ( _txtZipcode_TextChanged != null )
				_txtZipcode_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtZipcode_TextChanged;

		public void OntxtXStreetName_TextChanged()
		{
			if ( _txtXStreetName_TextChanged != null )
				_txtXStreetName_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtXStreetName_TextChanged;

		public void OntxtXHouseNumber_TextChanged()
		{
			if ( _txtXHouseNumber_TextChanged != null )
				_txtXHouseNumber_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtXHouseNumber_TextChanged;
	}

}