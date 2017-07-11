using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.dlgBattLegend))]
	public class dlgBattLegendViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this._Label_13 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 0;
			this.cmdClose.Text = "Close";
			this.Text = "Battalion Scheduler Legend";
			Label = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(14);
			Label[13] = _Label_13;
			Label[8] = _Label_8;
			Label[7] = _Label_7;
			Label[6] = _Label_6;
			Label[12] = _Label_12;
			Label[11] = _Label_11;
			Label[10] = _Label_10;
			Label[9] = _Label_9;
			Label[5] = _Label_5;
			Label[4] = _Label_4;
			Label[3] = _Label_3;
			Label[2] = _Label_2;
			Label[1] = _Label_1;
			Label[0] = _Label_0;
			Label[13].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[13].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label[13].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 128);
			Label[13].Name = "_Label_13";
			Label[13].TabIndex = 14;
			Label[13].Text = "fb = Fire Boat";
			Label[8].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[8].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label[8].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 128);
			Label[8].Name = "_Label_8";
			Label[8].TabIndex = 13;
			Label[8].Text = "tr = Tech Rescue";
			Label[7].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label[7].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 128);
			Label[7].Name = "_Label_7";
			Label[7].TabIndex = 12;
			Label[7].Text = "hm = Hazmat";
			Label[6].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label[6].ForeColor = UpgradeHelpers.Helpers.Color.Gray;
			Label[6].Name = "_Label_6";
			Label[6].TabIndex = 11;
			Label[6].Text = "*An asterisk (*) before last name in the Rover/Debit dropdown lists also identifies an employee on the Sick Leave Report that may be \"Still Out\"";
			Label[12].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[12].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label[12].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 128);
			Label[12].Name = "_Label_12";
			Label[12].TabIndex = 10;
			Label[12].Text = "% = Central Pierce Dispatcher         or other Non-TFD Employee";
			Label[11].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[11].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label[11].ForeColor = UpgradeHelpers.Helpers.Color.Gray;
			Label[11].Name = "_Label_11";
			Label[11].TabIndex = 9;
			Label[11].Text = "Gray = Still Out?*";
			Label[10].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[10].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label[10].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 128);
			Label[10].Name = "_Label_10";
			Label[10].TabIndex = 8;
			Label[10].Text = "( = Paramedic or available                 to work as a medic";
			Label[9].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[9].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers
					.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label[9].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 192, 128);
			Label[9].Name = "_Label_9";
			Label[9].TabIndex = 7;
			Label[9].Text = "Note:  \"Banked\" Leave is underlined";
			Label[5].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label[5].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 128);
			Label[5].Name = "_Label_5";
			Label[5].TabIndex = 6;
			Label[5].Text = "# = Probationary FF";
			Label[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 128);
			Label[4].Name = "_Label_4";
			Label[4].TabIndex = 5;
			Label[4].Text = "* = Cross Shift Rover";
			Label[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label[3].ForeColor = UpgradeHelpers.Helpers.Color.Red;
			Label[3].Name = "_Label_3";
			Label[3].TabIndex = 4;
			Label[3].Text = "Red DOT = Pay Upgrade";
			Label[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label[2].ForeColor = UpgradeHelpers.Helpers.Color.Green;
			Label[2].Name = "_Label_2";
			Label[2].TabIndex = 3;
			Label[2].Text = "Green = Trade";
			Label[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label[1].ForeColor = UpgradeHelpers.Helpers.Color.Blue;
			Label[1].Name = "_Label_1";
			Label[1].TabIndex = 2;
			Label[1].Text = "Blue = Debit";
			Label[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label[0].ForeColor = UpgradeHelpers.Helpers.Color.Red;
			Label[0].Name = "_Label_0";
			Label[0].TabIndex = 1;
			Label[0].Text = "Red = Overtime";
			this.Name = "PTSProject.dlgBattLegend";
			IsMdiChild = true;
		}

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_13 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> Label { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}