using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using UpgradeHelpers.BasicViewModels;
using UpgradeHelpers.Helpers;

namespace UpgradeHelpers.BasicViewModels.Angular
{
	public class AngularListBoxViewModel : UpgradeHelpers.BasicViewModels.ComboBoxViewModel
	{
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AngularListBoxViewModel()
		{
			CreateSelectedItems(new List<object>());
			CreateSelectedIndices(new int[] { });
		}

		public int FindString(string s, int startIndex = 0)
		{
			if (startIndex < 0 || startIndex >= ComboBoxItems.Count)
			{
				throw new ArgumentOutOfRangeException(
					"The startIndex parameter is less than zero or greater than or equal to the value of the UpgradeHelpers.BasicViewModels.ListBoxItemCollection.Count" +
					" property of the UpgradeHelpers.BasicViewModels.ListBoxItemCollection class.");
			}
			for (var i = startIndex; i <= ComboBoxItems.Count; i++)
			{
				if (ComboBoxItems[i].Text.StartsWith(s))
					return i;
			}
			return -1;
		}
		public int FindStringExact(string s, int startIndex = 0)
		{
			if (startIndex < 0 || startIndex >= ComboBoxItems.Count)
			{
				throw new ArgumentOutOfRangeException(
					"The startIndex parameter is less than zero or greater than or equal to the value of the UpgradeHelpers.BasicViewModels.ListBoxItemCollection.Count" +
					" property of the UpgradeHelpers.BasicViewModels.ListBoxItemCollection class.");
			}
			for (var i = startIndex; i <= ComboBoxItems.Count; i++)
			{
				if (ComboBoxItems[i].Text.Equals(s))
					return i;
			}
			return -1;
		}
		/// <summary>
		/// Stores the current selection Mode value
		/// </summary>
		public virtual SelectionMode SelectionMode { get; set; }

		#region Multiple Selection
		/// <summary>
		/// The selection variable will store the anonymous objects obtained from the ng-model directive
		/// in angular.js.  It will also be used to send the items selected in code back to the front end.
		/// </summary>
		[StateManagement(StateManagementValues.None)]
		private int[] selection = new int[] { };
        /// <summary>
        /// The selectedIndices variable will store the currently selected indices of the listbox.
        /// </summary>
        [StateManagement(StateManagementValues.None)]
        private ObservableCollection<int> selectedIndices;
        /// <summary>
        /// The selectedItems variable will store the currently selected items from the listbox.
        /// </summary>
        [StateManagement(StateManagementValues.None)]
        private ObservableCollection<object> selectedItems;

		/// <summary>
		/// Handles the list of items that is being obtained from the front end or sent to the front end.
		/// </summary>
		public virtual int[] Selection
		{
			get
			{
				if (selectedIndices == null) return selection;
				List<int> indices = new List<int>();
				foreach (int index in SelectedIndices)
				{
					indices.Add(index);
				}
				return selection = indices.ToArray();
			}
			set
			{
				selection = value ?? selection;
				DestroySelectedIndices();
				DestroySelectedItems();
			}
		}

        /// <summary>
        /// Contains the list of indices that have been selected.
        /// </summary>
        [StateManagement(StateManagementValues.None)]
        public ObservableCollection<int> SelectedIndices
		{
			get
			{
				return selectedIndices ?? CreateSelectedIndices(selection);
			}
			set
			{
				selectedIndices = value;
				selectedItems = null;
			}
		}

		/// <summary>
		/// Creates the SelectedIndices observable collection.
		/// </summary>
		/// <param name="indices"></param>
		/// <returns></returns>
		private ObservableCollection<int> CreateSelectedIndices(int[] indices)
		{
			if (SelectionMode == SelectionMode.Single)
			{
				selectedIndices = new ObservableCollection<int>(new[] { SelectedIndex });
				selectedIndices.CollectionChanged += selectedIndices_CollectionChanged;
				return selectedIndices;
			}
			if (selectedIndices != null) DestroySelectedIndices();
			selectedIndices = new ObservableCollection<int>(indices);
			selectedIndices.CollectionChanged += selectedIndices_CollectionChanged;
			return selectedIndices;
		}

		/// <summary>
		/// Destroys the SelectedIndices observable collection.
		/// </summary>
		private void DestroySelectedIndices()
		{
			if (selectedIndices != null)
			{
				selectedIndices.CollectionChanged -= selectedIndices_CollectionChanged;
				selectedIndices = null;
			}
		}

        [StateManagement(StateManagementValues.None)]
        private bool changingIndices = false;
		void selectedIndices_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			if (changingItems) return;
			changingIndices = true;
			selectedItems.Clear();
			foreach (int index in selectedIndices)
			{
				selectedItems.Add(Items[index]);
			}
			changingIndices = false;
		}

        /// <summary>
        /// Contains the list of selected items.
        /// </summary>
        [StateManagement(StateManagementValues.None)]
        public ObservableCollection<object> SelectedItems
		{
			get
			{
				return selectedItems ?? ParseSelectedIndices();
			}
			set
			{
				selectedItems = value;
			}
		}

		private ObservableCollection<object> ParseSelectedIndices()
		{
			List<object> objects = new List<object>();
			if (SelectedIndices == null || this.ComboBoxItems == null) return null;

			foreach (int i in selectedIndices)
			{
				objects.Add(this.Items[i]);
			}

			CreateSelectedItems(objects);
			return selectedItems;
		}

		private void DestroySelectedItems()
		{
			if (selectedItems != null)
			{
				selectedItems.CollectionChanged -= selectedItems_CollectionChanged;
				selectedItems = null;
			}
		}

		private void CreateSelectedItems(List<object> items)
		{
			if (selectedItems != null) DestroySelectedItems();
			selectedItems = new ObservableCollection<object>(items);
			selectedItems.CollectionChanged += selectedItems_CollectionChanged;
		}

        [StateManagement(StateManagementValues.None)]
        private bool changingItems = false;

		void selectedItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			if (changingIndices) return;
			changingItems = true;
			selectedIndices.Clear();
			foreach (object item in selectedItems)
			{
				selectedIndices.Add(Items.IndexOf(item));
			}
			changingItems = false;
		}


		#endregion
	}
}
