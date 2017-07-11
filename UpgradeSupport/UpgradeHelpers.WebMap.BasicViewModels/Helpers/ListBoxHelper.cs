using System;
namespace UpgradeHelpers.Helpers
{
	public class ListBoxHelper
	{
		public static int GetSelectedIndex(object listbox)
		{
			return (int)listbox.GetType().GetProperty("SelectedIndex").GetValue(listbox, null);
		}


		public static bool GetSelected(object listbox, int index)
		{
			return (bool)listbox.GetType().GetMethod("GetSelected").Invoke(listbox, new object[] { index });
		}

		public static bool SetSelected(object listbox, int index, bool value)
		{
			return (bool)listbox.GetType().GetMethod("SetSelected").Invoke(listbox, new object[] { index, value });
		}

		public static void SetSelectedIndex(object listbox, int index)
		{
			listbox.GetType().GetProperty("SelectedIndex").SetValue(listbox, index, null);
		}
	}
}