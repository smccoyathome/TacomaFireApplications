using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace TFDIncident.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(TFDIncident.Form1))]
	public class Form1ViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.Text1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.Text1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.Text1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.Text1.Name = "Text1";
			this.Text1.TabIndex = 7;
			this.Text1.Text = "Text1";
			this.List1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// List1
			// 
			this.List1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.List1.Enabled = true;
			this.List1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.List1.Name = "List1";
			this.List1.TabIndex = 3;
			this.List1.Visible = true;
			this.List1.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this._optMA_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optMA_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.Label4.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 8;
			this.Label4.Text = "Other Agencies Incident Number";
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 13.8f, UpgradeHelpers.
						Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label2.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 5;
			this.Label2.Text = "Mutual Aid Report";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.Label1.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 4;
			this.Label1.Text = "Involved Agencies";
			this.Text = "Form1";
			optMA = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(2);
			optMA[1] = _optMA_1;
			optMA[0] = _optMA_0;
			optMA[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			optMA[1].Checked = false;
			optMA[1].Enabled = true;
			optMA[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			optMA[1].Name = "_optMA_1";
			optMA[1].TabIndex = 2;
			optMA[1].Text = "Received";
			optMA[1].Visible = true;
			optMA[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			optMA[0].Checked = false;
			optMA[0].Enabled = true;
			optMA[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			optMA[0].Name = "_optMA_0";
			optMA[0].TabIndex = 1;
			optMA[0].Text = "Given";
			optMA[0].Visible = true;
			this.Name = "TFDIncident.Form1";
			List1.Items.Add("Lakewood");
			List1.Items.Add("Central Pierce");
			List1.Items.Add("Federal Way");
			List1.Items.Add("Gig Harbor");
			List1.Items.Add("Puyallup");
			List1.Items.Add("Riverside");
			List1.Items.Add("Other");
		}

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel Text1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel List1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optMA_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optMA_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optMA { get; set; }

	}

}