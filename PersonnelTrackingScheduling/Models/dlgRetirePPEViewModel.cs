using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.dlgRetirePPE))]
	public class dlgRetirePPEViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.txtTrackingNumber = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtTrackingNumber.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtTrackingNumber.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtTrackingNumber.Name = "txtTrackingNumber";
			this.txtTrackingNumber.TabIndex = 7;
			this.txtTrackingNumber.Text = "txtTrackingNumber";
			this.cboColorSize = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboColorSize
			// 
			this.cboColorSize.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboColorSize.Enabled = true;
			this.cboColorSize.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboColorSize.Name = "cboColorSize";
			this.cboColorSize.TabIndex = 6;
			this.cboColorSize.Text = "cboColorSize";
			this.cboColorSize.Visible = true;
			this.cboItemBrand = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboItemBrand
			// 
			this.cboItemBrand.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboItemBrand.Enabled = true;
			this.cboItemBrand.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboItemBrand.Name = "cboItemBrand";
			this.cboItemBrand.TabIndex = 5;
			this.cboItemBrand.Text = "cboItemBrand";
			this.cboItemBrand.Visible = true;
			this.cboItemType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboItemType
			// 
			this.cboItemType.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboItemType.Enabled = true;
			this.cboItemType.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboItemType.Name = "cboItemType";
			this.cboItemType.TabIndex = 4;
			this.cboItemType.Text = "cboItemType";
			this.cboItemType.Visible = true;
			this.cboReason = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboReason
			// 
			this.cboReason.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboReason.Enabled = true;
			this.cboReason.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboReason.Name = "cboReason";
			this.cboReason.TabIndex = 2;
			this.cboReason.Text = "cboReason";
			this.cboReason.Visible = true;
			this.txtComment = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtComment.Name = "txtComment";
			this.txtComment.TabIndex = 1;
			this.dteManufDate = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dteManufDate.MinDate = System.DateTime.Parse("2000/1/1");
			this.dteManufDate.Name = "dteManufDate";
			this.dteManufDate.TabIndex = 9;
			this.dteManufDate.Visible = false;
			this.dteRetired = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dteRetired.MinDate = System.DateTime.Parse("2000/1/1");
			this.dteRetired.Name = "dteRetired";
			this.dteRetired.TabIndex = 18;
			this.lbRetiredDate = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRetiredDate
			// 
			this.lbRetiredDate.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRetiredDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbRetiredDate.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 255, 192);
			this.lbRetiredDate.Name = "lbRetiredDate";
			this.lbRetiredDate.TabIndex = 19;
			this.lbRetiredDate.Text = "Retired Date";
			this.lbUniformID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbUniformID
			// 
			this.lbUniformID.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbUniformID.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbUniformID.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbUniformID.Name = "lbUniformID";
			this.lbUniformID.TabIndex = 16;
			this.lbUniformID.Text = "lbUniformID";
			this.lbUniformID.Visible = false;
			this.Label17 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label17
			// 
			this.Label17.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label17.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label17.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 255, 192);
			this.Label17.Name = "Label17";
			this.Label17.TabIndex = 15;
			this.Label17.Text = "Tracking / Barcode";
			this.lbItemColorSize = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbItemColorSize
			// 
			this.lbItemColorSize.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbItemColorSize.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbItemColorSize.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 255, 192);
			this.lbItemColorSize.Name = "lbItemColorSize";
			this.lbItemColorSize.TabIndex = 14;
			this.lbItemColorSize.Text = "Size/Color";
			this.lbItemBrand = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbItemBrand
			// 
			this.lbItemBrand.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbItemBrand.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbItemBrand.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 255, 192);
			this.lbItemBrand.Name = "lbItemBrand";
			this.lbItemBrand.TabIndex = 13;
			this.lbItemBrand.Text = "Brand/Manufacturer";
			this.Label14 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label14
			// 
			this.Label14.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label14.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label14.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 255, 192);
			this.Label14.Name = "Label14";
			this.Label14.TabIndex = 12;
			this.Label14.Text = "PPE Item";
			this.lbReason = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbReason
			// 
			this.lbReason.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbReason.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbReason.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 255, 192);
			this.lbReason.Name = "lbReason";
			this.lbReason.TabIndex = 11;
			this.lbReason.Text = "Retire Reason";
			this.lbRetireComment = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRetireComment
			// 
			this.lbRetireComment.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRetireComment.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbRetireComment.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 255, 192);
			this.lbRetireComment.Name = "lbRetireComment";
			this.lbRetireComment.TabIndex = 10;
			this.lbRetireComment.Text = "Retire Comment";
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 17;
			this.cmdClose.Tag = "0";
			this.cmdClose.Text = "Close";
			this.cmdEditItem = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdEditItem
			// 
			this.cmdEditItem.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdEditItem.Enabled = false;
			this.cmdEditItem.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdEditItem.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdEditItem.Name = "cmdEditItem";
			this.cmdEditItem.TabIndex = 3;
			this.cmdEditItem.Tag = "0";
			this.cmdEditItem.Text = "Update";
			this.Text = "Retire PPE Information";
			this.chkManufDate = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkManufDate.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 0);
			this.chkManufDate.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkManufDate.Enabled = true;
			this.chkManufDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkManufDate.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 255, 192);
			this.chkManufDate.Name = "chkManufDate";
			this.chkManufDate.TabIndex = 8;
			this.chkManufDate.Text = "PPE Manufacturered Date?";
			this.chkManufDate.Visible = true;
			this.Name = "PTSProject.dlgRetirePPE";
		}

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtTrackingNumber { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboColorSize { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboItemBrand { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboItemType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboReason { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtComment { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dteManufDate { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dteRetired { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRetiredDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbUniformID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label17 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbItemColorSize { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbItemBrand { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label14 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbReason { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRetireComment { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdEditItem { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkManufDate { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean isInitializingComponent { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

	}

}