using Newtonsoft.Json;
using System.Collections.Generic;

using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;
namespace UpgradeHelpers.BasicViewModels
{
	/// <summary>
	/// A view model to hold state for element in the view which could be should as part of a toolbar
	/// </summary>
	public class ToolStripItemCollectionViewModel : IDependentViewModel
	{
		public string UniqueID { get; set; }

		[JsonProperty("@k")]
		public int k = 1;

		public virtual IList<ToolStripItemViewModel> _items { get; set; }

		[StateManagement(StateManagementValues.None)]
		public IList<ToolStripItemViewModel> Items { get { return _items; } }

		public void Build(IIocContainer ctx)
		{
			_items = ctx.Resolve<IList<ToolStripItemViewModel>>();
		}

		public void Add(ToolStripItemViewModel item)
		{
			_items.Add(item);
		}

		public void Remove(ToolStripItemViewModel item)
		{
			_items.Remove(item);
		}
		public void RemoveAt(int index)
		{
			_items.RemoveAt(index);
		}

		public int Count()
		{
			return _items.Count;
		}

		public ToolStripItemViewModel this[int n]
		{
			get { return _items[n]; }
			set { _items[n] = value; }
		}

	}
}

