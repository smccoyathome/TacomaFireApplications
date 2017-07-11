using System;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.BasicViewModels
{
	public class ListBoxItem : ControlViewModel
	{
		public override void Build(IIocContainer ctx)
		{
			Text = String.Empty;
			Value = null;
		}

		public virtual object Value { get; set; }

		public virtual int? Data { get; set; }

		public virtual object Item { get; set; }

		public override string ToString()
		{
			return Text;
		}
	}
}