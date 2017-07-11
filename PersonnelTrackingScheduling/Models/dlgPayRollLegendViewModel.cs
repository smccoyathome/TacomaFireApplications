using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.dlgPayRollLegend))]
	public class dlgPayRollLegendViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 16;
			this.Label3.Text = "For Example:  L40010";
			this._Label2_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label2_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label2_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 12;
			this.Label1.Text = "Activity Type is one of the following Letter with the Job Code:";
			this._Label_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.cmdCancel = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdCancel
			// 
			this.cmdCancel.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdCancel.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdCancel.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 5;
			this.cmdCancel.Text = "Close";
			this.Text = "PayRoll Legend";
			Label2 = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(3);
			Label2[2] = _Label2_2;
			Label2[1] = _Label2_1;
			Label2[0] = _Label2_0;
			Label2[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label2[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label2[2].ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			Label2[2].Name = "_Label2_2";
			Label2[2].TabIndex = 15;
			Label2[2].Text = "T = Time & Half";
			Label2[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label2[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label2[1].ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			Label2[1].Name = "_Label2_1";
			Label2[1].TabIndex = 14;
			Label2[1].Text = "D = Double Time";
			Label2[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label2[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label2[0].ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			Label2[0].Name = "_Label2_0";
			Label2[0].TabIndex = 13;
			Label2[0].Text = "L = Regular Time";
			Label = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(8);
			Label[7] = _Label_7;
			Label[0] = _Label_0;
			Label[1] = _Label_1;
			Label[2] = _Label_2;
			Label[6] = _Label_6;
			Label[5] = _Label_5;
			Label[4] = _Label_4;
			Label[3] = _Label_3;
			Label[7].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers
			.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label[7].ForeColor = UpgradeHelpers.Helpers.Color.Red;
			Label[7].Name = "_Label_7";
			Label[7].TabIndex = 17;
			Label[7].Text = "* Note:  Rows once Blue will become red...";
			Label[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label[0].ForeColor = UpgradeHelpers.Helpers.Color.Blue;
			Label[0].Name = "_Label_0";
			Label[0].TabIndex = 4;
			Label[0].Text = "Blue - Payroll Needed (Schedule Exceptions exist)";
			Label[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label[1].ForeColor = UpgradeHelpers.Helpers.Color.Red;
			Label[1].Name = "_Label_1";
			Label[1].TabIndex = 3;
			Label[1].Text = "Red - No *Outstanding Payroll (No Schedule Exceptions)";
			Label[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label[2].ForeColor = UpgradeHelpers.Helpers.Color.White;
			Label[2].Name = "_Label_2";
			Label[2].TabIndex = 2;
			Label[2].Text = "Black - No Schedule (Civilian Employees)";
			Label[6].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label[6].ForeColor = UpgradeHelpers.Helpers.Color.White;
			Label[6].Name = "_Label_6";
			Label[6].TabIndex = 9;
			Label[6].Text = "Black - Payroll Saved, Needs to be Uploaded";
			Label[5].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label[5].ForeColor = UpgradeHelpers.Helpers.Color.Green;
			Label[5].Name = "_Label_5";
			Label[5].TabIndex = 8;
			Label[5].Text = "Green - Payroll Uploaded to SAP Successfully";
			Label[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label[4].ForeColor = UpgradeHelpers.Helpers.Color.Red;
			Label[4].Name = "_Label_4";
			Label[4].TabIndex = 7;
			Label[4].Text = "Red - Payroll Saved, but Upload Failed";
			Label[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label[3].ForeColor = UpgradeHelpers.Helpers.Color.Blue;
			Label[3].Name = "_Label_3";
			Label[3].TabIndex = 6;
			Label[3].Text = "Blue - No Payroll Exists, Needs to be Saved or Applied";
			this.Name = "PTSProject.dlgPayRollLegend";
			IsMdiChild = true;
		}

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label2_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label2_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label2_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdCancel { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> Label2 { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> Label { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}