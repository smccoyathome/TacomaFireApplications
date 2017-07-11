using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmSplash))]
	public class frmSplashViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.lbTrainingMode = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbTrainingMode.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 255, 255);
			this.lbTrainingMode.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 18f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbTrainingMode.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 0, 192);
			this.lbTrainingMode.Name = "lbTrainingMode";
			this.lbTrainingMode.TabIndex = 8;
			this.lbTrainingMode.Text = "Training Mode Active";
			this.lbTrainingMode.Visible = false;
			this.lbVersionDate = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbVersionDate.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			this.lbVersionDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 14.4f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbVersionDate.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbVersionDate.Name = "lbVersionDate";
			this.lbVersionDate.TabIndex = 7;
			this.lbVersionDate.Text = "Version Date 8/8/2016";
			this.imgLogo = ctx.Resolve<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>();
			this.imgLogo.Enabled = true;
			this.imgLogo.Name = "imgLogo";
			this.imgLogo.Visible = true;
			this.lblCopyright = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lblCopyright
			// 
			this.lblCopyright.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			this.lblCopyright.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lblCopyright.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lblCopyright.Name = "lblCopyright";
			this.lblCopyright.TabIndex = 3;
			this.lblCopyright.Text = "Tacoma Fire Department";
			this.lblCompany = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lblCompany
			// 
			this.lblCompany.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			this.lblCompany.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lblCompany.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lblCompany.Name = "lblCompany";
			this.lblCompany.TabIndex = 2;
			this.lblCompany.Text = "Information Systems";
			this.lblWarning = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lblWarning
			// 
			this.lblWarning.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			this.lblWarning.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lblWarning.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lblWarning.Name = "lblWarning";
			this.lblWarning.TabIndex = 1;
			this.lblWarning.Text = "Authorized for Use By TFD Personnel Only";
			this.lblVersion = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lblVersion.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			this.lblVersion.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lblVersion.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.TabIndex = 4;
			this.lblVersion.Text = "XP Version 5.8";
			this.lblProductName = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lblProductName.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			this.lblProductName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 20.4f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lblProductName.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lblProductName.Name = "lblProductName";
			this.lblProductName.TabIndex = 6;
			this.lblProductName.Text = "Personnel Tracking and Scheduling";
			this.lblCompanyProduct = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lblCompanyProduct.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			this.lblCompanyProduct.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 18f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lblCompanyProduct.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lblCompanyProduct.Name = "lblCompanyProduct";
			this.lblCompanyProduct.TabIndex = 5;
			this.lblCompanyProduct.Text = "Tacoma Fire Department";
			this.Frame1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// Frame1
			// 
			this.Frame1.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.Frame1.Name = "Frame1";
			this.Frame1.TabIndex = 0;
			this.Frame1.Visible = true;
			this.Name = "PTSProject.frmSplash";
		}

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbTrainingMode { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbVersionDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PictureBoxViewModel imgLogo { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lblCopyright { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lblCompany { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lblWarning { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lblVersion { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lblProductName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lblCompanyProduct { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel Frame1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

	}

}