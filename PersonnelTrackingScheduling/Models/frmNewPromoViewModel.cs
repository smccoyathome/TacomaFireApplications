using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmNewPromo))]
	public class frmNewPromoViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.cboPromotion = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboPromotion
			// 
			this.cboPromotion.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboPromotion.Enabled = true;
			this.cboPromotion.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboPromotion.Name = "cboPromotion";
			this.cboPromotion.TabIndex = 7;
			this.cboPromotion.Text = "cboPromotion";
			this.cboPromotion.Visible = true;
			this.txtPromotionDate = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtPromotionDate.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtPromotionDate.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtPromotionDate.Name = "txtPromotionDate";
			this.txtPromotionDate.TabIndex = 6;
			this.txtEDays = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtEDays.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtEDays.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtEDays.Name = "txtEDays";
			this.txtEDays.TabIndex = 5;
			this.txtComments = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtComments.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtComments.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtComments.Name = "txtComments";
			this.txtComments.TabIndex = 4;
			this.lbName = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbName
			// 
			this.lbName.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbName.Name = "lbName";
			this.lbName.TabIndex = 13;
			this.lbName.Text = "lbName";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.6f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 12;
			this.Label1.Text = "New Promotion For :";
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.Teal;
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 11;
			this.Label2.Text = "Promotion List";
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.Teal;
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 10;
			this.Label3.Text = "Promotion Date";
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.Teal;
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 9;
			this.Label4.Text = "Exclusion Days";
			this.Label5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label5
			// 
			this.Label5.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label5.ForeColor = UpgradeHelpers.Helpers.Color.Teal;
			this.Label5.Name = "Label5";
			this.Label5.TabIndex = 8;
			this.Label5.Text = "Comments";
			this.Line1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Line1
			// 
			this.Line1.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			this.Line1.Enabled = false;
			this.Line1.Name = "Line1";
			this.Line1.Visible = true;
			this.Shape1 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this.Shape1.Enabled = false;
			this.Shape1.Name = "Shape1";
			this.Shape1.Visible = true;
			this.cmdAddPromo = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAddPromo
			// 
			this.cmdAddPromo.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAddPromo.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAddPromo.Name = "cmdAddPromo";
			this.cmdAddPromo.TabIndex = 2;
			this.cmdAddPromo.Text = "&Add Promotion";
			this.cmdCancel = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdCancel
			// 
			this.cmdCancel.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdCancel.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 1;
			this.cmdCancel.Text = "&Cancel";
			this.Text = "New Promotion";
			this.chkStatus = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkStatus.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.chkStatus.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
			this.chkStatus.Enabled = true;
			this.chkStatus.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkStatus.ForeColor = UpgradeHelpers.Helpers.Color.Teal;
			this.chkStatus.Name = "chkStatus";
			this.chkStatus.TabIndex = 3;
			this.chkStatus.Text = "Active for this list";
			this.chkStatus.Visible = true;
			this.Name = "PTSProject.frmNewPromo";
			IsMdiChild = true;
		}

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboPromotion { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtPromotionDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtEDays { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtComments { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Line1 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel Shape1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAddPromo { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdCancel { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkStatus { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}