using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.dlgIndSchedLegend))]
	public class dlgIndSchedLegendViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this._Label_14 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 128, 0);
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 17;
			this.Label1.Text = "* Duty Not There";
			this.CancelButton_Renamed = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// CancelButton_Renamed
			// 
			this.CancelButton_Renamed.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.CancelButton_Renamed.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.CancelButton_Renamed.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.CancelButton_Renamed.Name = "CancelButton_Renamed";
			this.CancelButton_Renamed.TabIndex = 0;
			this.CancelButton_Renamed.Text = "Close";
			this.Text = "Individual Scheduler Legend";
			Label = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(15);
			Label[14] = _Label_14;
			Label[11] = _Label_11;
			Label[10] = _Label_10;
			Label[9] = _Label_9;
			Label[3] = _Label_3;
			Label[5] = _Label_5;
			Label[6] = _Label_6;
			Label[8] = _Label_8;
			Label[7] = _Label_7;
			Label[4] = _Label_4;
			Label[2] = _Label_2;
			Label[1] = _Label_1;
			Label[0] = _Label_0;
			Label[14].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[14].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label[14].ForeColor = UpgradeHelpers.Helpers.Color.Red;
			Label[14].Name = "_Label_14";
			Label[14].TabIndex = 16;
			Label[14].Text = "Bold Font = Banked Vacation Used";
			Label[11].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[11].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label[11].ForeColor = UpgradeHelpers.Helpers.Color.Fuchsia;
			Label[11].Name = "_Label_11";
			Label[11].TabIndex = 14;
			Label[11].Text = "Overtime";
			Label[10].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[10].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label[10].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 192, 255);
			Label[10].Name = "_Label_10";
			Label[10].TabIndex = 13;
			Label[10].Text = "Notes Attached";
			Label[9].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[9].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label[9].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 192, 0);
			Label[9].Name = "_Label_9";
			Label[9].TabIndex = 12;
			Label[9].Text = "Trade (Not Working)";
			Label[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 0);
			Label[3].Name = "_Label_3";
			Label[3].TabIndex = 10;
			Label[3].Text = "Military";
			Label[5].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label[5].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 128, 0);
			Label[5].Name = "_Label_5";
			Label[5].TabIndex = 9;
			Label[5].Text = "Kelly or DNT*";
			Label[6].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label[6].ForeColor = UpgradeHelpers.Helpers.Color.Purple;
			Label[6].Name = "_Label_6";
			Label[6].TabIndex = 8;
			Label[6].Text = "Other (SCK, OJI, etc)";
			Label[8].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[8].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label[8].ForeColor = UpgradeHelpers.Helpers.Color.Fuchsia;
			Label[8].Name = "_Label_8";
			Label[8].TabIndex = 7;
			Label[8].Text = "Overtime/Education";
			Label[7].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label[7].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 192, 0);
			Label[7].Name = "_Label_7";
			Label[7].TabIndex = 6;
			Label[7].Text = "Trade (Working)";
			Label[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 192, 192);
			Label[4].Name = "_Label_4";
			Label[4].TabIndex = 5;
			Label[4].Text = "Debit";
			Label[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label[2].ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			Label[2].Name = "_Label_2";
			Label[2].TabIndex = 4;
			Label[2].Text = "Holiday";
			Label[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label[1].ForeColor = UpgradeHelpers.Helpers.Color.Red;
			Label[1].Name = "_Label_1";
			Label[1].TabIndex = 3;
			Label[1].Text = "Vacation";
			Label[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 0, 192);
			Label[0].Name = "_Label_0";
			Label[0].TabIndex = 2;
			Label[0].Text = "Regular";
			this.Name = "PTSProject.dlgIndSchedLegend";
			IsMdiChild = true;
		}

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_14 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel CancelButton_Renamed { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> Label { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}