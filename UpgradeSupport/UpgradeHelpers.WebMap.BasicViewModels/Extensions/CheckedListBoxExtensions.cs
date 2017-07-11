using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpgradeHelpers.Helpers;

namespace UpgradeHelpers.BasicViewModels.Extensions
{
	public static class CheckedListBoxExtensionMethods
	{
		public static void Add(this IList<CheckedListBoxItem> list, string itemText, bool checkedState)
		{
			list.Add(itemText, checkedState ? UpgradeHelpers.Helpers.CheckState.Checked : UpgradeHelpers.Helpers.CheckState.Unchecked);
		}

		public static void Add(this IList<CheckedListBoxItem> list, object newitem)
		{
			Add(list, newitem, CheckState.Unchecked);
		}

		public static void Add(this IList<CheckedListBoxItem> list, object newitem, UpgradeHelpers.Helpers.CheckState checkedState)
		{
			var boxItem = newitem as CheckedListBoxItem;
			if (boxItem != null)
			{
				list.Add(boxItem);
			}
			else
			{
				CheckedListBoxItem item = UpgradeHelpers.Helpers.StaticContainer.Instance.Resolve<CheckedListBoxItem>();
				item.Text = "" + newitem;
				item.Checked = checkedState == CheckState.Checked;
				list.Add(item);
			}
		}

		public static void Add(this IList<CheckedListBoxItem> list, object newitem, bool checkedState)
		{
			list.Add(newitem, checkedState ? UpgradeHelpers.Helpers.CheckState.Checked : UpgradeHelpers.Helpers.CheckState.Unchecked);
		}

		public static IEnumerable<string> GetAll(this IList<CheckedListBoxItem> list)
		{
			foreach (CheckedListBoxItem item in list)
				yield return item.Text;
		}
	}
}
