using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.BasicViewModels
{
	/// <summary>
	/// Manages a the state for a related set of tab pages
	/// </summary>
	public class TabControlViewModel : ControlViewModel
	{
		[JsonProperty("@k")]
		public int k = 1;

		public virtual IList<TabPageViewModel> Items { get; set; }



		public override void Build(IIocContainer ctx)
		{
			base.Build(ctx);
			Items = ctx.Resolve<IList<TabPageViewModel>>();
		}

		/// <summary>
		/// Gets or sets the model for the currently selected tab page in the view
		/// </summary>
		//      public virtual TabPageViewModel SelectedTab { get; set;}
		private int _selectedIndex = -1;
		public virtual int SelectedIndex
		{
			get
			{
				return _selectedIndex;
			}
			set
			{
				if (Items != null)
				{
					if (value >= 0 && value < Items.Count)
					{
						if (_selectedIndex >= 0)
						{
							Items[_selectedIndex].Focused = false;
						}
						_selectedIndex = value;
						Items[_selectedIndex].Focused = true;
					}
				}
				else
				{
					_selectedIndex = value;
				}
			}
		}
	}
}
