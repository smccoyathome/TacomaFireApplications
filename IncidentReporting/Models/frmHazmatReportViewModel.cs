using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace TFDIncident.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(TFDIncident.frmHazmatReport))]
	public class frmHazmatReportViewModel
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
			this.cboNarrList.TabIndex = 50;
			this.cboNarrList.Text = " cboNarrList";
			this.Label9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label9
			// 
			this.Label9.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label9.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label9.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.Label9.Name = "Label9";
			this.Label9.TabIndex = 118;
			this.Label9.Text = "Select Narration Author";
			this.lbNarrID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbNarrID
			// 
			this.lbNarrID.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbNarrID.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbNarrID.Name = "lbNarrID";
			this.lbNarrID.TabIndex = 117;
			this.lbNarrID.Text = "lbNarrID";
			this.lbNarrID.Visible = false;
			this.lbNarrMessage = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbNarrMessage
			// 
			this.lbNarrMessage.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbNarrMessage.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, ((UpgradeHelpers
						.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbNarrMessage.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbNarrMessage.Name = "lbNarrMessage";
			this.lbNarrMessage.TabIndex = 113;
			this.lbNarrMessage.Text = "Narrations may only be edited by Original Author";
			this._lbFrameTitle_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbNarrAuthor = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbNarrAuthor
			// 
			this.lbNarrAuthor.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lbNarrAuthor.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbNarrAuthor.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbNarrAuthor.Name = "lbNarrAuthor";
			this.lbNarrAuthor.TabIndex = 111;
			this.txtQuantity = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtQuantity.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtQuantity.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtQuantity.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.txtQuantity.Name = "txtQuantity";
			this.txtQuantity.TabIndex = 46;
			this.lstMaterialUsed = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstMaterialUsed
			// 
			this.lstMaterialUsed.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstMaterialUsed.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lstMaterialUsed.Name = "lstMaterialUsed";
			this.lstMaterialUsed.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstMaterialUsed.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstMaterialUsed.TabIndex = 48;
			this.cboDrugLabType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboDrugLabType
			// 
			this.cboDrugLabType.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboDrugLabType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboDrugLabType.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboDrugLabType.Name = "cboDrugLabType";
			this.cboDrugLabType.TabIndex = 44;
			this.cboDrugLabType.Text = " cboDrugLabType";
			this.cboMaterialUsed = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboMaterialUsed
			// 
			this.cboMaterialUsed.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboMaterialUsed.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboMaterialUsed.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboMaterialUsed.Name = "cboMaterialUsed";
			this.cboMaterialUsed.TabIndex = 45;
			this.cboMaterialUsed.Text = " cboMaterialUsed";
			this.lbQuantity = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbQuantity
			// 
			this.lbQuantity.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbQuantity.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbQuantity.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbQuantity.Name = "lbQuantity";
			this.lbQuantity.TabIndex = 109;
			this.lbQuantity.Text = "QUANTITY";
			this.lbDrugLabType = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbDrugLabType
			// 
			this.lbDrugLabType.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbDrugLabType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbDrugLabType.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbDrugLabType.Name = "lbDrugLabType";
			this.lbDrugLabType.TabIndex = 108;
			this.lbDrugLabType.Text = "DRUG LAB TYPE";
			this.lbFireServiceMaterialTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbFireServiceMaterialTitle
			// 
			this.lbFireServiceMaterialTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbFireServiceMaterialTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbFireServiceMaterialTitle.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbFireServiceMaterialTitle.Name = "lbFireServiceMaterialTitle";
			this.lbFireServiceMaterialTitle.TabIndex = 107;
			this.lbFireServiceMaterialTitle.Text = "FIRE SERVICE MATERIAL USED:";
			this.Line1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Line1
			// 
			this.Line1.BackColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Name = "Line1";
			this.Line1.TabIndex = 110;
			this.cboSecondaryReleasedInto = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboSecondaryReleasedInto
			// 
			this.cboSecondaryReleasedInto.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboSecondaryReleasedInto.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboSecondaryReleasedInto.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboSecondaryReleasedInto.Name = "cboSecondaryReleasedInto";
			this.cboSecondaryReleasedInto.TabIndex = 42;
			this.cboSecondaryReleasedInto.Text = " cboSecondaryReleasedInto";
			this.cboPrimaryReleasedInto = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboPrimaryReleasedInto
			// 
			this.cboPrimaryReleasedInto.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboPrimaryReleasedInto.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboPrimaryReleasedInto.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboPrimaryReleasedInto.Name = "cboPrimaryReleasedInto";
			this.cboPrimaryReleasedInto.TabIndex = 41;
			this.cboPrimaryReleasedInto.Text = " cboPrimaryReleasedInto";
			this.cboPhysicalStateReleased = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboPhysicalStateReleased
			// 
			this.cboPhysicalStateReleased.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboPhysicalStateReleased.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboPhysicalStateReleased.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboPhysicalStateReleased.Name = "cboPhysicalStateReleased";
			this.cboPhysicalStateReleased.TabIndex = 40;
			this.cboPhysicalStateReleased.Text = " cboPhysicalStateReleased";
			this.cboPhysicalStateStored = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboPhysicalStateStored
			// 
			this.cboPhysicalStateStored.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboPhysicalStateStored.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboPhysicalStateStored.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboPhysicalStateStored.Name = "cboPhysicalStateStored";
			this.cboPhysicalStateStored.TabIndex = 39;
			this.cboPhysicalStateStored.Text = " cboPhysicalStateStored";
			this.lbSecondReleasedInto = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSecondReleasedInto
			// 
			this.lbSecondReleasedInto.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSecondReleasedInto.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbSecondReleasedInto.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbSecondReleasedInto.Name = "lbSecondReleasedInto";
			this.lbSecondReleasedInto.TabIndex = 105;
			this.lbSecondReleasedInto.Text = "SECONDARY RELEASED INTO";
			this.lbPrimaryReleasedInto = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbPrimaryReleasedInto
			// 
			this.lbPrimaryReleasedInto.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbPrimaryReleasedInto.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbPrimaryReleasedInto.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbPrimaryReleasedInto.Name = "lbPrimaryReleasedInto";
			this.lbPrimaryReleasedInto.TabIndex = 104;
			this.lbPrimaryReleasedInto.Text = "PRIMARY RELEASED INTO";
			this.lbPhyStateReleased = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbPhyStateReleased
			// 
			this.lbPhyStateReleased.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbPhyStateReleased.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbPhyStateReleased.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbPhyStateReleased.Name = "lbPhyStateReleased";
			this.lbPhyStateReleased.TabIndex = 103;
			this.lbPhyStateReleased.Text = "PHYSICAL STATE RELEASED";
			this.lbPhyStateStored = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbPhyStateStored
			// 
			this.lbPhyStateStored.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbPhyStateStored.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbPhyStateStored.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbPhyStateStored.Name = "lbPhyStateStored";
			this.lbPhyStateStored.TabIndex = 102;
			this.lbPhyStateStored.Text = "PHYSICAL STATE STORED";
			this.cboAmountReleasedUnits = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboAmountReleasedUnits
			// 
			this.cboAmountReleasedUnits.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboAmountReleasedUnits.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboAmountReleasedUnits.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboAmountReleasedUnits.Name = "cboAmountReleasedUnits";
			this.cboAmountReleasedUnits.TabIndex = 37;
			this.cboAmountReleasedUnits.Text = " cboAmountReleasedUnits";
			this.txtEstContainerCapacity = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtEstContainerCapacity.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtEstContainerCapacity.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtEstContainerCapacity.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.txtEstContainerCapacity.Name = "txtEstContainerCapacity";
			this.txtEstContainerCapacity.TabIndex = 36;
			this.cboContainerCapacityUnits = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboContainerCapacityUnits
			// 
			this.cboContainerCapacityUnits.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboContainerCapacityUnits.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboContainerCapacityUnits.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboContainerCapacityUnits.Name = "cboContainerCapacityUnits";
			this.cboContainerCapacityUnits.TabIndex = 35;
			this.cboContainerCapacityUnits.Text = " cboContainerCapacityUnits";
			this.cboContainerType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboContainerType
			// 
			this.cboContainerType.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboContainerType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboContainerType.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboContainerType.Name = "cboContainerType";
			this.cboContainerType.TabIndex = 34;
			this.cboContainerType.Text = " cboContainerType";
			this.txtEstAmountReleased = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtEstAmountReleased.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtEstAmountReleased.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtEstAmountReleased.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.txtEstAmountReleased.Name = "txtEstAmountReleased";
			this.txtEstAmountReleased.TabIndex = 38;
			this.Label7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label7
			// 
			this.Label7.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label7.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.Label7.Name = "Label7";
			this.Label7.TabIndex = 100;
			this.Label7.Text = "AMOUNT RELEASED UNITS";
			this.lbEstContainerCap = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEstContainerCap
			// 
			this.lbEstContainerCap.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbEstContainerCap.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbEstContainerCap.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbEstContainerCap.Name = "lbEstContainerCap";
			this.lbEstContainerCap.TabIndex = 99;
			this.lbEstContainerCap.Text = "EST. CONTAINER CAPACITY";
			this.lbContainerCapUnits = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbContainerCapUnits
			// 
			this.lbContainerCapUnits.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbContainerCapUnits.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbContainerCapUnits.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbContainerCapUnits.Name = "lbContainerCapUnits";
			this.lbContainerCapUnits.TabIndex = 98;
			this.lbContainerCapUnits.Text = "CONTAINER CAPACITY UNITS";
			this.lbContainerType = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbContainerType
			// 
			this.lbContainerType.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbContainerType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbContainerType.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbContainerType.Name = "lbContainerType";
			this.lbContainerType.TabIndex = 97;
			this.lbContainerType.Text = "CONTAINER TYPE";
			this.lbEstAmountReleased = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEstAmountReleased
			// 
			this.lbEstAmountReleased.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbEstAmountReleased.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbEstAmountReleased.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbEstAmountReleased.Name = "lbEstAmountReleased";
			this.lbEstAmountReleased.TabIndex = 96;
			this.lbEstAmountReleased.Text = "EST. AMOUNT RELEASED";
			this.cboSelectChemical = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboSelectChemical
			// 
			this.cboSelectChemical.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboSelectChemical.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboSelectChemical.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboSelectChemical.Name = "cboSelectChemical";
			this.cboSelectChemical.TabIndex = 30;
			this.cboSelectChemical.Text = " cboSelectChemical";
			this.Label8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label8
			// 
			this.Label8.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label8.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label8.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.Label8.Name = "Label8";
			this.Label8.TabIndex = 94;
			this.Label8.Text = "Select Chemical Detail to Edit";
			this.txtBuildingsEvacuated = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtBuildingsEvacuated.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtBuildingsEvacuated.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtBuildingsEvacuated.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.txtBuildingsEvacuated.Name = "txtBuildingsEvacuated";
			this.txtBuildingsEvacuated.TabIndex = 27;
			this.txtPeopleEvacuated = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtPeopleEvacuated.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtPeopleEvacuated.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtPeopleEvacuated.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.txtPeopleEvacuated.Name = "txtPeopleEvacuated";
			this.txtPeopleEvacuated.TabIndex = 26;
			this.cboPopulationDensity = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboPopulationDensity
			// 
			this.cboPopulationDensity.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboPopulationDensity.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboPopulationDensity.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboPopulationDensity.Name = "cboPopulationDensity";
			this.cboPopulationDensity.TabIndex = 25;
			this.cboPopulationDensity.Text = " cboPopulationDensity";
			this.cboAreaEvacuatedUnits = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboAreaEvacuatedUnits
			// 
			this.cboAreaEvacuatedUnits.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboAreaEvacuatedUnits.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboAreaEvacuatedUnits.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboAreaEvacuatedUnits.Name = "cboAreaEvacuatedUnits";
			this.cboAreaEvacuatedUnits.TabIndex = 23;
			this.cboAreaEvacuatedUnits.Text = " cboAraEvacuatedUnit";
			this.cboAreaAffectedUnits = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboAreaAffectedUnits
			// 
			this.cboAreaAffectedUnits.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboAreaAffectedUnits.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboAreaAffectedUnits.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboAreaAffectedUnits.Name = "cboAreaAffectedUnits";
			this.cboAreaAffectedUnits.TabIndex = 21;
			this.cboAreaAffectedUnits.Text = " cboAreaAffectedUnits";
			this.txtAreaAffected = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtAreaAffected.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtAreaAffected.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtAreaAffected.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.txtAreaAffected.Name = "txtAreaAffected";
			this.txtAreaAffected.TabIndex = 22;
			this.txtAreaEvacuated = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtAreaEvacuated.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtAreaEvacuated.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtAreaEvacuated.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.txtAreaEvacuated.Name = "txtAreaEvacuated";
			this.txtAreaEvacuated.TabIndex = 24;
			this.lstEquipmentInvolved = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstEquipmentInvolved
			// 
			this.lstEquipmentInvolved.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lstEquipmentInvolved.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(102)))), ((int)(((byte)(92)))));
			this.lstEquipmentInvolved.Name = "lstEquipmentInvolved";
			this.lstEquipmentInvolved.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstEquipmentInvolved.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstEquipmentInvolved.TabIndex = 28;
			this.lbPeopleEvac = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbPeopleEvac
			// 
			this.lbPeopleEvac.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbPeopleEvac.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbPeopleEvac.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbPeopleEvac.Name = "lbPeopleEvac";
			this.lbPeopleEvac.TabIndex = 92;
			this.lbPeopleEvac.Text = "PEOPLE EVACUATED";
			this.lbBldgEvac = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbBldgEvac
			// 
			this.lbBldgEvac.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbBldgEvac.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbBldgEvac.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbBldgEvac.Name = "lbBldgEvac";
			this.lbBldgEvac.TabIndex = 91;
			this.lbBldgEvac.Text = "BUILDINGS EVACUATED";
			this.lbPopDensity = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbPopDensity
			// 
			this.lbPopDensity.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbPopDensity.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbPopDensity.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbPopDensity.Name = "lbPopDensity";
			this.lbPopDensity.TabIndex = 90;
			this.lbPopDensity.Text = "POPULATION DENSITY";
			this.lbAreaEvac = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAreaEvac
			// 
			this.lbAreaEvac.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAreaEvac.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbAreaEvac.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbAreaEvac.Name = "lbAreaEvac";
			this.lbAreaEvac.TabIndex = 89;
			this.lbAreaEvac.Text = "AREA EVACUATED";
			this.lbAreaEvacUnits = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAreaEvacUnits
			// 
			this.lbAreaEvacUnits.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAreaEvacUnits.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbAreaEvacUnits.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbAreaEvacUnits.Name = "lbAreaEvacUnits";
			this.lbAreaEvacUnits.TabIndex = 88;
			this.lbAreaEvacUnits.Text = "AREA EVACUATED UNITS";
			this.lbAreaAffect = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAreaAffect
			// 
			this.lbAreaAffect.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAreaAffect.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbAreaAffect.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbAreaAffect.Name = "lbAreaAffect";
			this.lbAreaAffect.TabIndex = 87;
			this.lbAreaAffect.Text = "AREA AFFECTED";
			this.lbAreaAffectUnits = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAreaAffectUnits
			// 
			this.lbAreaAffectUnits.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAreaAffectUnits.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbAreaAffectUnits.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbAreaAffectUnits.Name = "lbAreaAffectUnits";
			this.lbAreaAffectUnits.TabIndex = 86;
			this.lbAreaAffectUnits.Text = "AREA AFFECTED UNITS";
			this.lbEquipInvolved = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEquipInvolved
			// 
			this.lbEquipInvolved.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbEquipInvolved.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbEquipInvolved.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbEquipInvolved.Name = "lbEquipInvolved";
			this.lbEquipInvolved.TabIndex = 85;
			this.lbEquipInvolved.Text = "EQUIPMENT INVOLVED";
			this.txtReleaseFloor = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtReleaseFloor.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtReleaseFloor.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtReleaseFloor.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.txtReleaseFloor.Name = "txtReleaseFloor";
			this.txtReleaseFloor.TabIndex = 14;
			this.lstMitigatingFactors = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstMitigatingFactors
			// 
			this.lstMitigatingFactors.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lstMitigatingFactors.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lstMitigatingFactors.Name = "lstMitigatingFactors";
			this.lstMitigatingFactors.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstMitigatingFactors.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstMitigatingFactors.TabIndex = 17;
			this.lstContributingFactors = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstContributingFactors
			// 
			this.lstContributingFactors.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lstContributingFactors.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(102)))), ((int)(((byte)(92)))));
			this.lstContributingFactors.Name = "lstContributingFactors";
			this.lstContributingFactors.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstContributingFactors.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstContributingFactors.TabIndex = 16;
			this.cboAreaOfOrigin = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboAreaOfOrigin
			// 
			this.cboAreaOfOrigin.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboAreaOfOrigin.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboAreaOfOrigin.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboAreaOfOrigin.Name = "cboAreaOfOrigin";
			this.cboAreaOfOrigin.TabIndex = 12;
			this.cboAreaOfOrigin.Text = " cboAreaOfOrigin";
			this.cboCauseOfRelease = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboCauseOfRelease
			// 
			this.cboCauseOfRelease.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboCauseOfRelease.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboCauseOfRelease.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboCauseOfRelease.Name = "cboCauseOfRelease";
			this.cboCauseOfRelease.TabIndex = 13;
			this.cboCauseOfRelease.Text = " cboCauseOfRelease";
			this.cboStreetClass = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboStreetClass
			// 
			this.cboStreetClass.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboStreetClass.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboStreetClass.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboStreetClass.Name = "cboStreetClass";
			this.cboStreetClass.TabIndex = 15;
			this.cboStreetClass.Text = " cboStreetClass";
			this.cboStreetClass.Visible = false;
			this.cboGeneralPropertyUse = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboGeneralPropertyUse
			// 
			this.cboGeneralPropertyUse.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboGeneralPropertyUse.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboGeneralPropertyUse.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboGeneralPropertyUse.Name = "cboGeneralPropertyUse";
			this.cboGeneralPropertyUse.TabIndex = 10;
			this.cboGeneralPropertyUse.Text = " cboGeneralPropertyUse";
			this.cboSpecificPropertyUse = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboSpecificPropertyUse
			// 
			this.cboSpecificPropertyUse.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboSpecificPropertyUse.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboSpecificPropertyUse.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboSpecificPropertyUse.Name = "cboSpecificPropertyUse";
			this.cboSpecificPropertyUse.TabIndex = 11;
			this.cboSpecificPropertyUse.Text = " cboSpecificPropertyUse";
			this.lbMitigatingFactors = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbMitigatingFactors
			// 
			this.lbMitigatingFactors.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbMitigatingFactors.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbMitigatingFactors.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbMitigatingFactors.Name = "lbMitigatingFactors";
			this.lbMitigatingFactors.TabIndex = 83;
			this.lbMitigatingFactors.Text = "MITIGATING FACTORS";
			this.lbContribFactors = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbContribFactors
			// 
			this.lbContribFactors.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbContribFactors.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbContribFactors.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbContribFactors.Name = "lbContribFactors";
			this.lbContribFactors.TabIndex = 82;
			this.lbContribFactors.Text = "CONTRIBUTING FACTORS";
			this.lbStreetClass = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbStreetClass
			// 
			this.lbStreetClass.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbStreetClass.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbStreetClass.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbStreetClass.Name = "lbStreetClass";
			this.lbStreetClass.TabIndex = 81;
			this.lbStreetClass.Text = "STREET CLASS";
			this.lbAreaOrigin = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAreaOrigin
			// 
			this.lbAreaOrigin.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAreaOrigin.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbAreaOrigin.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbAreaOrigin.Name = "lbAreaOrigin";
			this.lbAreaOrigin.TabIndex = 80;
			this.lbAreaOrigin.Text = "AREA OF ORIGIN";
			this.lbCauseOfRelease = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbCauseOfRelease
			// 
			this.lbCauseOfRelease.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbCauseOfRelease.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbCauseOfRelease.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbCauseOfRelease.Name = "lbCauseOfRelease";
			this.lbCauseOfRelease.TabIndex = 79;
			this.lbCauseOfRelease.Text = "CAUSE OF RELEASE";
			this.lbGenPropUse = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbGenPropUse
			// 
			this.lbGenPropUse.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbGenPropUse.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbGenPropUse.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbGenPropUse.Name = "lbGenPropUse";
			this.lbGenPropUse.TabIndex = 78;
			this.lbGenPropUse.Text = "GENERAL PROPERTY USE";
			this.lbSpecPropUse = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSpecPropUse
			// 
			this.lbSpecPropUse.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSpecPropUse.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbSpecPropUse.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbSpecPropUse.Name = "lbSpecPropUse";
			this.lbSpecPropUse.TabIndex = 77;
			this.lbSpecPropUse.Text = "SPECIFIC PROPERTY USE";
			this.lbReleaseFloor = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbReleaseFloor
			// 
			this.lbReleaseFloor.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbReleaseFloor.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbReleaseFloor.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbReleaseFloor.Name = "lbReleaseFloor";
			this.lbReleaseFloor.TabIndex = 76;
			this.lbReleaseFloor.Text = "RELEASE FLOOR";
			this.lbReleaseFloor.Visible = false;
			this.lstActionsTaken = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstActionsTaken
			// 
			this.lstActionsTaken.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstActionsTaken.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lstActionsTaken.Name = "lstActionsTaken";
			this.lstActionsTaken.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstActionsTaken.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstActionsTaken.TabIndex = 4;
			this.cboIncidentType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboIncidentType
			// 
			this.cboIncidentType.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboIncidentType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboIncidentType.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboIncidentType.Name = "cboIncidentType";
			this.cboIncidentType.TabIndex = 1;
			this.cboIncidentType.Text = " cboIncidentType";
			this.cboHazmatIDSource = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboHazmatIDSource
			// 
			this.cboHazmatIDSource.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboHazmatIDSource.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboHazmatIDSource.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboHazmatIDSource.Name = "cboHazmatIDSource";
			this.cboHazmatIDSource.TabIndex = 2;
			this.cboHazmatIDSource.Text = " cboHazmatIDSource";
			this.cboDisposition = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboDisposition
			// 
			this.cboDisposition.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboDisposition.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboDisposition.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboDisposition.Name = "cboDisposition";
			this.cboDisposition.TabIndex = 3;
			this.cboDisposition.Text = " cboDisposition";
			this.Label6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label6
			// 
			this.Label6.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label6.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.Label6.Name = "Label6";
			this.Label6.TabIndex = 74;
			this.Label6.Text = "HAZMAT ACTIONS TAKEN";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 73;
			this.Label1.Text = "HAZMAT INCIDENT TYPE";
			this.Label5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label5
			// 
			this.Label5.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label5.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.Label5.Name = "Label5";
			this.Label5.TabIndex = 72;
			this.Label5.Text = "HAZARDOUS MATERIAL ID SOURCE";
			this.lbDispOfRelease = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbDispOfRelease
			// 
			this.lbDispOfRelease.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbDispOfRelease.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbDispOfRelease.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbDispOfRelease.Name = "lbDispOfRelease";
			this.lbDispOfRelease.TabIndex = 71;
			this.lbDispOfRelease.Text = "DISPOSITION OF HAZMAT INCIDENT";
			this.cboUN = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboUN
			// 
			this.cboUN.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboUN.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboUN.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboUN.Name = "cboUN";
			this.cboUN.TabIndex = 33;
			this.cboUN.Text = " cboUN";
			this.cboChemicalName = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboChemicalName
			// 
			this.cboChemicalName.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboChemicalName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboChemicalName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboChemicalName.Name = "cboChemicalName";
			this.cboChemicalName.TabIndex = 32;
			this.cboChemicalName.Text = " cboChemicalName";
			this.cboCommonChemicals = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboCommonChemicals
			// 
			this.cboCommonChemicals.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboCommonChemicals.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboCommonChemicals.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboCommonChemicals.Name = "cboCommonChemicals";
			this.cboCommonChemicals.TabIndex = 31;
			this.cboCommonChemicals.Text = " cboCommonChemicals";
			this.lbUN = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbUN
			// 
			this.lbUN.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbUN.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbUN.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbUN.Name = "lbUN";
			this.lbUN.TabIndex = 67;
			this.lbUN.Text = "UN #";
			this.lbCommonChemicals = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbCommonChemicals
			// 
			this.lbCommonChemicals.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbCommonChemicals.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbCommonChemicals.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbCommonChemicals.Name = "lbCommonChemicals";
			this.lbCommonChemicals.TabIndex = 66;
			this.lbCommonChemicals.Text = "COMMON CHEMICALS";
			this.lbChemicalName = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbChemicalName
			// 
			this.lbChemicalName.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbChemicalName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbChemicalName.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbChemicalName.Name = "lbChemicalName";
			this.lbChemicalName.TabIndex = 65;
			this.lbChemicalName.Text = "CHEMICAL NAME";
			this.lbChemicalID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbChemicalID
			// 
			this.lbChemicalID.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbChemicalID.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbChemicalID.Name = "lbChemicalID";
			this.lbChemicalID.TabIndex = 64;
			this.lbChemicalID.Visible = false;
			this.cboOutsideResource = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboOutsideResource
			// 
			this.cboOutsideResource.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboOutsideResource.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboOutsideResource.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboOutsideResource.Name = "cboOutsideResource";
			this.cboOutsideResource.TabIndex = 5;
			this.cboOutsideResource.Text = " cboOutsideResource";
			this.cboResourceUse = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboResourceUse
			// 
			this.cboResourceUse.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboResourceUse.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboResourceUse.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.cboResourceUse.Name = "cboResourceUse";
			this.cboResourceUse.TabIndex = 6;
			this.cboResourceUse.Text = " cboResourceUse";
			this.lstOutsideResource = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstOutsideResource
			// 
			this.lstOutsideResource.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstOutsideResource.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			this.lstOutsideResource.Name = "lstOutsideResource";
			this.lstOutsideResource.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstOutsideResource.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstOutsideResource.TabIndex = 8;
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 62;
			this.Label3.Text = "RESOURCE:";
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 61;
			this.Label4.Text = "USED FOR:";
			this._optOccurredFirst_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optOccurredFirst_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optOccurredFirst_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.lbChemDetailID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbChemDetailID
			// 
			this.lbChemDetailID.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbChemDetailID.Enabled = false;
			this.lbChemDetailID.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbChemDetailID.Name = "lbChemDetailID";
			this.lbChemDetailID.TabIndex = 69;
			this.lbChemDetailID.Visible = false;
			this.tabHazmat = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabControlViewModel>();
			this.tabHazmat.Name = "tabHazmat";
			this.tabHazmat.SelectedIndex = 0;
			this.tabHazmat.TabIndex = 58;
			this.lbLockedMessage = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLockedMessage
			// 
			this.lbLockedMessage.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lbLockedMessage.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbLockedMessage.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.lbLockedMessage.Name = "lbLockedMessage";
			this.lbLockedMessage.TabIndex = 114;
			this.lbLockedMessage.Text = "READ ONLY - Records Locked";
			this.lbIncident = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbIncident
			// 
			this.lbIncident.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbIncident.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbIncident.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.lbIncident.Name = "lbIncident";
			this.lbIncident.TabIndex = 57;
			this.lbIncident.Text = "001230012";
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 56;
			this.Label2.Text = "Incident #";
			this.lbLocation = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLocation
			// 
			this.lbLocation.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbLocation.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbLocation.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.lbLocation.Name = "lbLocation";
			this.lbLocation.TabIndex = 55;
			this.lbLocation.Text = "lbLocation";
			this.picHazmatBar = ctx.Resolve<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>();
			// 
			// picHazmatBar
			// 
			this.picHazmatBar.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.picHazmatBar.Name = "picHazmatBar";
			this.cmdAddResource = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAddResource
			// 
			this.cmdAddResource.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAddResource.Enabled = false;
			this.cmdAddResource.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdAddResource.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAddResource.Name = "cmdAddResource";
			this.cmdAddResource.TabIndex = 7;
			this.cmdAddResource.Text = "Add Resource";
			this.cmdRemoveResource = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdRemoveResource
			// 
			this.cmdRemoveResource.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdRemoveResource.Enabled = false;
			this.cmdRemoveResource.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdRemoveResource.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdRemoveResource.Name = "cmdRemoveResource";
			this.cmdRemoveResource.TabIndex = 9;
			this.cmdRemoveResource.Text = "Remove Resource";
			this.cmdRemoveMaterial = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdRemoveMaterial
			// 
			this.cmdRemoveMaterial.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdRemoveMaterial.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdRemoveMaterial.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdRemoveMaterial.Name = "cmdRemoveMaterial";
			this.cmdRemoveMaterial.TabIndex = 49;
			this.cmdRemoveMaterial.Text = "Remove Material";
			this.cmdAddMaterial = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAddMaterial
			// 
			this.cmdAddMaterial.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAddMaterial.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdAddMaterial.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAddMaterial.Name = "cmdAddMaterial";
			this.cmdAddMaterial.TabIndex = 47;
			this.cmdAddMaterial.Text = "Add Material";

			this.rtxNarration = ctx.Resolve<Stubs._System.Windows.Forms.RichTextBox>();
			// 
			// rtxNarration
			// 
			this.rtxNarration.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.rtxNarration.Name = "rtxNarration";
			this.rtxNarration.TabIndex = 52;
			this.rtxNarration.Text = "";
			this.cmdAddNarration = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAddNarration
			// 
			this.cmdAddNarration.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAddNarration.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdAddNarration.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAddNarration.Name = "cmdAddNarration";
			this.cmdAddNarration.TabIndex = 51;
			this.cmdAddNarration.Tag = "1";
			this.cmdAddNarration.Text = "Add New Narration";
			this.cmdMoreChemicals = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdMoreChemicals
			// 
			this.cmdMoreChemicals.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdMoreChemicals.Enabled = false;
			this.cmdMoreChemicals.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdMoreChemicals.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdMoreChemicals.Name = "cmdMoreChemicals";
			this.cmdMoreChemicals.TabIndex = 68;
			this.cmdMoreChemicals.Text = "ADD ADDITIONAL CHEMICALS...";
			this._cmdSave_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._cmdSave_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._cmdSave_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._cmdSave_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this.tabPage1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Text = "General Information";
			this.tabPage2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Text = "Hazmat Release";
			this.tabPage3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Text = "Chemical Detail";
			this.tabPage4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Text = "Drug Lab";
			this.tabPage5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Text = "Narration";
			this.Text = "Form1";
			this.CurrIncident = 0;
			this.CurrReport = 0;
			this.NarrationUpdated = 0;
			optOccurredFirst = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(3);
			optOccurredFirst[1] = _optOccurredFirst_1;
			optOccurredFirst[0] = _optOccurredFirst_0;
			optOccurredFirst[2] = _optOccurredFirst_2;
			optOccurredFirst[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(217)))), ((int)(((byte)(172)))));
			optOccurredFirst[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optOccurredFirst[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			optOccurredFirst[1].Name = "_optOccurredFirst_1";
			optOccurredFirst[1].TabIndex = 19;
			optOccurredFirst[1].Text = "EXPLOSION";
			optOccurredFirst[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(217)))), ((int)(((byte)(172)))));
			optOccurredFirst[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optOccurredFirst[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			optOccurredFirst[0].Name = "_optOccurredFirst_0";
			optOccurredFirst[0].TabIndex = 18;
			optOccurredFirst[0].Text = "FIRE";
			optOccurredFirst[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(217)))), ((int)(((byte)(172)))));
			optOccurredFirst[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optOccurredFirst[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(65)))));
			optOccurredFirst[2].Name = "_optOccurredFirst_2";
			optOccurredFirst[2].TabIndex = 20;
			optOccurredFirst[2].Text = "HAZMAT RELEASE";
			cmdSave = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel>>(4);
			cmdSave[3] = _cmdSave_3;
			cmdSave[0] = _cmdSave_0;
			cmdSave[1] = _cmdSave_1;
			cmdSave[2] = _cmdSave_2;
			cmdSave[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdSave[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cmdSave[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdSave[3].Name = "_cmdSave_3";
			cmdSave[3].TabIndex = 115;
			cmdSave[3].Text = "Print";
			cmdSave[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdSave[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cmdSave[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdSave[0].Name = "_cmdSave_0";
			cmdSave[0].TabIndex = 54;
			cmdSave[0].Text = "Save as Complete";
			cmdSave[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdSave[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cmdSave[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdSave[1].Name = "_cmdSave_1";
			cmdSave[1].TabIndex = 43;
			cmdSave[1].Text = "Save as Incomplete";
			cmdSave[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdSave[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cmdSave[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdSave[2].Name = "_cmdSave_2";
			cmdSave[2].TabIndex = 29;
			cmdSave[2].Text = "Cancel and Exit";
			this.ChemicalDetailUpdated = 0;
			this.HazmatID = 0;
			this.FirstTime = 0;
			this.HazmatDLID = 0;
			this.ReportLogID = 0;
			lbFrameTitle = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(8);
			lbFrameTitle[7] = _lbFrameTitle_7;
			lbFrameTitle[7].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, ((UpgradeHelpers
					.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbFrameTitle[7].ForeColor = UpgradeHelpers.Helpers.Color.Black;
			lbFrameTitle[7].Name = "_lbFrameTitle_7";
			lbFrameTitle[7].TabIndex = 112;
			lbFrameTitle[7].Text = "HAZMAT NARRATION - Author:";
			this.Name = "TFDIncident.frmHazmatReport";
			IsMdiChild = true;
			tabHazmat.Items.Add(tabPage1);
			tabHazmat.Items.Add(tabPage2);
			tabHazmat.Items.Add(tabPage3);
			tabHazmat.Items.Add(tabPage4);
			tabHazmat.Items.Add(tabPage5);
		}

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboNarrList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbNarrID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbNarrMessage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbNarrAuthor { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtQuantity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstMaterialUsed { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboDrugLabType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboMaterialUsed { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbQuantity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbDrugLabType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbFireServiceMaterialTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Line1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboSecondaryReleasedInto { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboPrimaryReleasedInto { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboPhysicalStateReleased { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboPhysicalStateStored { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSecondReleasedInto { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbPrimaryReleasedInto { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbPhyStateReleased { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbPhyStateStored { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboAmountReleasedUnits { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtEstContainerCapacity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboContainerCapacityUnits { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboContainerType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtEstAmountReleased { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEstContainerCap { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbContainerCapUnits { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbContainerType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEstAmountReleased { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboSelectChemical { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtBuildingsEvacuated { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtPeopleEvacuated { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboPopulationDensity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboAreaEvacuatedUnits { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboAreaAffectedUnits { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtAreaAffected { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtAreaEvacuated { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstEquipmentInvolved { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbPeopleEvac { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbBldgEvac { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbPopDensity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAreaEvac { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAreaEvacUnits { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAreaAffect { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAreaAffectUnits { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEquipInvolved { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtReleaseFloor { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstMitigatingFactors { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstContributingFactors { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboAreaOfOrigin { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboCauseOfRelease { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboStreetClass { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboGeneralPropertyUse { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboSpecificPropertyUse { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbMitigatingFactors { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbContribFactors { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbStreetClass { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAreaOrigin { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbCauseOfRelease { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbGenPropUse { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSpecPropUse { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbReleaseFloor { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstActionsTaken { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboIncidentType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboHazmatIDSource { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboDisposition { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbDispOfRelease { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboUN { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboChemicalName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboCommonChemicals { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbUN { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbCommonChemicals { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbChemicalName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbChemicalID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboOutsideResource { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboResourceUse { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstOutsideResource { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optOccurredFirst_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optOccurredFirst_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optOccurredFirst_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbChemDetailID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabControlViewModel tabHazmat { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLockedMessage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbIncident { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLocation { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PictureBoxViewModel picHazmatBar { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAddResource { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdRemoveResource { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdRemoveMaterial { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAddMaterial { get; set; }

		public virtual Stubs._System.Windows.Forms.RichTextBox rtxNarration { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAddNarration { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdMoreChemicals { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdSave_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdSave_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdSave_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdSave_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage5 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrIncident { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrReport { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 NarrationUpdated { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optOccurredFirst { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel> cmdSave { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 ChemicalDetailUpdated { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 HazmatID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 FirstTime { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 HazmatDLID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 ReportLogID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbFrameTitle { get; set; }

		public virtual bool IsMdiChild { get; set; }

		public void OntxtAreaAffected_TextChanged()
		{
			if ( _txtAreaAffected_TextChanged != null )
				_txtAreaAffected_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtAreaAffected_TextChanged;

		public void OntxtEstContainerCapacity_TextChanged()
		{
			if ( _txtEstContainerCapacity_TextChanged != null )
				_txtEstContainerCapacity_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtEstContainerCapacity_TextChanged;

		public void OntxtEstAmountReleased_TextChanged()
		{
			if ( _txtEstAmountReleased_TextChanged != null )
				_txtEstAmountReleased_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtEstAmountReleased_TextChanged;

		public void OntxtQuantity_TextChanged()
		{
			if ( _txtQuantity_TextChanged != null )
				_txtQuantity_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtQuantity_TextChanged;
	}

}