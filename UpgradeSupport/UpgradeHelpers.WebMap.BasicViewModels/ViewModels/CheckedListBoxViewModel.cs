using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UpgradeHelpers.Events;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.BasicViewModels
{
	/// <summary>
	///  View model of each entry of a CheckedListBox
	/// </summary>

	public class CheckedListBoxItem : ControlViewModel
	{
		public virtual object Value { get; set; }
		public virtual bool Checked { get; set; }
		public virtual int ItemData { get; set; }

		public override void Build(IIocContainer ctx)
		{
			base.Build(ctx);
			Text = string.Empty;
			Value = 0;
		}
		public override string ToString()
		{
			return Text ?? string.Empty;
		}

	}

	/// <summary>
	///   View Model for List boxes with check box items
	/// </summary>
	public class CheckedListBoxViewModel : ControlViewModel
	{

		[JsonProperty("@k")]
		public int k = 1;

		public virtual IList<CheckedListBoxItem> _items { get; set; }

		[StateManagement(StateManagementValues.None)]
		public IList<CheckedListBoxItem> Items
		{
			get
			{
				return _items;
			}
		}
		/// <summary>
		/// ItemCheck EventName
		/// </summary>
		private const string ItemCheckEvent = "ItemCheck";


		private const string SelectedIndexChangedKey = "SelectedIndexChanged";

		/// <summary>
		///  This property returns the current selected index
		/// </summary>
		[StateManagement(StateManagementValues.None)]
		public int SelectedIndex
		{
			get
			{
				if (ListBoxSelectedIndices.Any())
				{
					return ListBoxSelectedIndices.First();
				}
				return -1;
			}
			set
			{
				if (value >= 0 && value <= _items.Count - 1)
				{
					ListBoxSelectedIndices = new[] { value };
				}
				if (ViewManager != null)
					ViewManager.Events.Publish(SelectedIndexChangedKey, this, new object[] { this, new EventArgs() });
			}
		}

		/// <summary>
		/// Items Collection
		/// </summary>
		[StateManagement(StateManagementValues.None)]
		public CheckedListBoxItemsCollection ListBoxItems
		{
			get { return new CheckedListBoxItemsCollection(this); }
		}

		/// <summary>
		///    This property keeps an array of indices of the selected elements
		/// </summary>
		public virtual int[] ListBoxSelectedIndices { get; set; }


		/// <summary>
		///    This property keeps an array of indices of the selected elements
		/// </summary>
		public virtual int[] ListBoxCheckedIndices { get; set; }

		public CheckedListBoxSelectedIndexCollection SelectedIndices
		{
			get { return new CheckedListBoxSelectedIndexCollection(this); }
		}
		/// <summary>
		///    CheckedListBox selection mode
		/// </summary>
		public virtual SelectionMode SelectionMode { get; set; }


		/// <summary>
		///  Initialization for view model
		/// </summary>
		/// <param name="ctx"></param>
		public override void Build(IIocContainer ctx)
		{
			base.Build(ctx);
			ListBoxSelectedIndices = new[] { -1 };
			_items = ctx.Resolve<IList<CheckedListBoxItem>>();
			//ListBoxItems = new CheckedListBoxItemsCollection(this);
		}
		
		/// <summary>
		///  Adds an element to the ListBox
		/// </summary>
		/// <param name="itemText">item text</param>
		public int AddItem(object itemText)
		{
			if (itemText is CheckedListBoxItem)
			{
				Items.Add((CheckedListBoxItem)itemText);
			}
			else
			{
				var tmp = Container.Resolve<CheckedListBoxItem>();
				tmp.Text = "" + itemText;
				Items.Add(tmp);
			}
            return this.Items.Count - 1;
		}

		/// <summary>
		///   Returns the text of the specified item
		/// </summary>
		/// <param name="itemIndex">item to get the text from</param>
		/// <returns></returns>
		public string GetListItem(int itemIndex)
		{
			return Items[itemIndex].Text;
		}

		/// <summary>
		///   Gets the check box state of the specified item
		/// </summary>
		/// <param name="itemIndex">item index to get the 'checked' state from</param>
		/// <returns></returns>
		public bool GetItemChecked(int itemIndex)
		{
			return Items[itemIndex].Checked;
		}

		/// <summary>
		///   Sets the 'checked' stated
		/// </summary>
		/// <param name="itemIndex"></param>
		/// <param name="checkedValue"></param>
		public void SetItemChecked(int itemIndex, bool checkedValue)
		{
			var currentCheckState = GetItemCheckState(itemIndex);
			ListBoxItems[itemIndex].Checked = checkedValue;
			if (ViewManager != null && ViewManager.Events != null && !ViewManager.Events.IsSuspended())
				ViewManager.Events.Publish(ItemCheckEvent, this, this, new ItemCheckEventArgs(itemIndex, GetItemCheckState(itemIndex), currentCheckState));
		}
		/// <summary>
		/// Sets the item as selected
		/// </summary>
		/// <param name="itemIndex"></param>
		/// <param name="checkedValue"></param>
		public void SetItemSelected(int itemIndex, bool checkedValue)
		{
			if (checkedValue)
				SelectedIndices.Add(Items[itemIndex]);
			else
			{
				SelectedIndices.Remove(itemIndex);
			}
		}


		/// <summary>
		///   Sets the item 'checked' stated
		/// </summary>
		/// <param name="itemIndex"></param>
		/// <param name="checkState"></param>
		public void SetItemCheckState(int itemIndex, CheckState checkState)
		{
			var currentCheckState = GetItemCheckState(itemIndex);
			if (checkState.Equals(CheckState.Checked))
			{
				ListBoxItems[itemIndex].Checked = true;
			}
			else
			{
				ListBoxItems[itemIndex].Checked = false;
			}
			var newValue = GetItemCheckState(itemIndex);
			if (ViewManager != null && ViewManager.Events != null && !ViewManager.Events.IsSuspended())
				ViewManager.Events.Publish(ItemCheckEvent, this, this, new ItemCheckEventArgs(itemIndex, newValue, currentCheckState));
		}
		/// <summary>
		/// Collection of Checked Items
		/// </summary>
		public CheckedListBoxCheckedCollection CheckedItems
		{
			get
			{
				return new CheckedListBoxCheckedCollection(this);
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether the check box should be toggled when an item is selected.
		/// </summary>
		public virtual bool CheckOnClick { get; set; }

		/// <summary>
		/// Collection of checked indexes
		/// </summary>
		[StateManagement(StateManagementValues.None)]
		public List<int> CheckedIndices
		{
			get
			{
				return CheckedItems.Select(item => CheckedItems.IndexOfItem(item)).ToList();
			}
		}
		/// <summary>
		/// Sets the ItemData of a specific item
		/// </summary>
		/// <param name="index">The index of the item which ItemData will be set</param>
		/// <param name="value">The value of the ItemData to set</param>
		public void SetItemData(int index, int value)
		{
			if (Items.Count > 0 && Items.Count > index)
			{
				Items[index].ItemData = value;
			}
		}


		/// <summary>
		/// Gets the ItemData of a specific item
		/// </summary>
		/// <param name="index">The index of the item which ItemData will be returned</param>
		/// <returns>Return the ItemData of the item in the "index" position</returns>
		public int GetItemData(int index)
		{
			if (Items.Count > 0 && Items.Count > index)
			{
				return Items[index].ItemData;
			}
			return 0;
		}

		/// <summary>
		/// Returns a value indicating the check state of the current item.
		/// </summary>
		/// <param name="indexChecked">Returns a value indicating the check state of the current item</param>
		/// <returns></returns>
		public CheckState GetItemCheckState(int indexChecked)
		{
			if (Items.Count > 0 && Items.Count > indexChecked)
			{
				var _checkState = Items[indexChecked].Checked;
				if (_checkState)
					return CheckState.Checked;
				return CheckState.Unchecked;
			}
			return CheckState.Indeterminate;
		}
		
		/// <summary>
		/// Remove item at position n
		/// </summary>
		/// <param name="n">The item's position that will be removed</param>
		public void RemoveItem(int n)
		{
			Items.RemoveAt(n);
		}

		public class CheckedListBoxCheckedCollection : IList<CheckedListBoxItem>
		{
			CheckedListBoxViewModel _viewModel;
			internal CheckedListBoxCheckedCollection(CheckedListBoxViewModel viewModel)
			{
				_viewModel = viewModel;
			}

			private IEnumerable<CheckedListBoxItem> AllItems()
			{
				for (int i = 0; i < _viewModel.Items.Count; i++)
				{
					yield return _viewModel.Items[i];
				}
			}
			private IEnumerable<CheckedListBoxItem> SelectedItems()
			{
				for (int i = 0; i < _viewModel.Items.Count; i++)
				{
					if (_viewModel.Items[i].Checked)
					{
						yield return _viewModel.Items[i];
					}
				}
			}

			public int IndexOf(CheckedListBoxItem item)
			{
				int result = -1;
				int i = 0;
				foreach (var innerItem in SelectedItems())
				{
					if (innerItem == item)
					{
						result = i;
						break;
					}
					i++;
				}
				return result;
			}

			public void Insert(int index, CheckedListBoxItem item)
			{
				int innerIndex = IndexOfItem(item);
				_viewModel.Items[innerIndex].Checked = true;
			}

			public int IndexOfItem(CheckedListBoxItem item)
			{
				int innerIndex = -1;
				for (int i = 0; i < _viewModel.Items.Count; i++)
				{
					if (item == _viewModel.Items[i])
					{
						innerIndex = i;
					}
				}
				return innerIndex;
			}

			public void RemoveAt(int index)
			{
				_viewModel.Items[index].Checked = false;
			}

			public CheckedListBoxItem this[int index]
			{
				get
				{
					return SelectedItems().ElementAt(index);
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			public void Add(CheckedListBoxItem item)
			{
				int innerIndex = IndexOfItem(item);
				_viewModel.Items[innerIndex].Checked = true;
			}

			public void Clear()
			{
				for (int i = 0; i < _viewModel.Items.Count; i++)
				{
					if (_viewModel.Items[i].Checked)
					{
						_viewModel.Items[i].Checked = false;
					}
				}
			}

			public bool Contains(CheckedListBoxItem item)
			{
				return SelectedItems().Any(innerItem => innerItem == item);
			}

			public void CopyTo(CheckedListBoxItem[] array, int arrayIndex)
			{
				throw new NotImplementedException();
			}

			public int Count
			{
				get { return SelectedItems().Count(); }
			}

			public bool IsReadOnly
			{
				get { return true; }
			}

			public bool Remove(CheckedListBoxItem item)
			{
				RemoveAt(IndexOfItem(item));
				return true;
			}

			public IEnumerator<CheckedListBoxItem> GetEnumerator()
			{
				return SelectedItems().GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return SelectedItems().GetEnumerator();
			}
		}




		public class CheckedListBoxSelectedIndexCollection : IList<CheckedListBoxItem>
		{
			CheckedListBoxViewModel _viewModel;
			internal CheckedListBoxSelectedIndexCollection(CheckedListBoxViewModel viewModel)
			{
				_viewModel = viewModel;
			}

			private IEnumerable<CheckedListBoxItem> AllItems()
			{
				for (int i = 0; i < _viewModel.Items.Count; i++)
				{
					yield return _viewModel.Items[i];
				}
			}
			private IEnumerable<CheckedListBoxItem> SelectedItems()
			{
				for (int i = 0; i < _viewModel.ListBoxSelectedIndices.Length; i++)
				{
					if (_viewModel.ListBoxSelectedIndices[i] != -1)
						yield return _viewModel.Items[_viewModel.ListBoxSelectedIndices[i]];
				}
			}

			public int IndexOf(CheckedListBoxItem item)
			{
				int result = -1;
				int i = 0;
				foreach (var innerItem in SelectedItems())
				{
					if (innerItem == item)
					{
						result = i;
						break;
					}
					i++;
				}
				return result;
			}

			public void Insert(int index, CheckedListBoxItem item)
			{
				int innerIndex = IndexOfItem(item);
				_viewModel.Items[innerIndex].Checked = true;
			}

			private int IndexOfItem(CheckedListBoxItem item)
			{
				int innerIndex = -1;
				for (int i = 0; i < _viewModel.Items.Count; i++)
				{
					if (item == _viewModel.Items[i])
					{
						innerIndex = i;
					}
				}
				return innerIndex;
			}

			public void RemoveAt(int index)
			{
				Remove(index);
			}
			public void Remove(int selectedIndex)
			{
				var listTemp = _viewModel.ListBoxSelectedIndices.ToList();
				listTemp.Remove(selectedIndex);
				_viewModel.ListBoxSelectedIndices = listTemp.ToArray();
			}

			public CheckedListBoxItem this[int index]
			{
				get
				{
					return SelectedItems().ElementAt(index);
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			public void Add(CheckedListBoxItem item)
			{
				int innerIndex = IndexOfItem(item);
				if (!_viewModel.ListBoxSelectedIndices.Contains(innerIndex))
				{
					Remove(-1);
					var indices = new int[_viewModel.ListBoxSelectedIndices.Length + 1];
					Array.Copy(_viewModel.ListBoxSelectedIndices, indices, _viewModel.ListBoxSelectedIndices.Length);
					indices[indices.Length - 1] = innerIndex;
					_viewModel.ListBoxSelectedIndices = indices;
				}
			}

			public void Clear()
			{
				_viewModel.ListBoxSelectedIndices = new[] { -1 };
			}

			public bool Contains(CheckedListBoxItem item)
			{
				return SelectedItems().Any(innerItem => innerItem == item);
			}

			public void CopyTo(CheckedListBoxItem[] array, int arrayIndex)
			{
				throw new NotImplementedException();
			}

			public int Count
			{
				get { return SelectedItems().Count(); }
			}

			public bool IsReadOnly
			{
				get { return true; }
			}

			public bool Remove(CheckedListBoxItem item)
			{
				RemoveAt(IndexOfItem(item));
				return true;
			}

			public IEnumerator<CheckedListBoxItem> GetEnumerator()
			{
				return SelectedItems().GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return SelectedItems().GetEnumerator();
			}
		}

		public class CheckedListBoxItemsCollection : IEnumerable
		{
			CheckedListBoxViewModel _viewModel;
			internal CheckedListBoxItemsCollection(CheckedListBoxViewModel viewModel)
			{
				_viewModel = viewModel;
			}

			private IEnumerable<CheckedListBoxItem> AllItems()
			{
				for (int i = 0; i < _viewModel.Items.Count; i++)
				{
					yield return _viewModel.Items[i];
				}
			}
			private IEnumerable<CheckedListBoxItem> SelectedItems()
			{
				for (int i = 0; i < _viewModel.Items.Count; i++)
				{
					yield return _viewModel.Items[i];
				}
			}

			public int IndexOf(object item)
			{
				if (item is CheckedListBoxItem)
				{
					int result = -1;
					int i = 0;
					foreach (var innerItem in SelectedItems())
					{
						if (innerItem == item)
						{
							result = i;
							break;
						}
						i++;
					}
					return result;
				}
				if (item is string)
				{

					int result = -1;
					int i = 0;
					foreach (var innerItem in SelectedItems())
					{
						if (innerItem.Text.Equals(item))
						{
							result = i;
							break;
						}
						i++;
					}
					return result;

				}
				return -1;
			}

			public void Insert(int index, CheckedListBoxItem item)
			{
				_viewModel.Items.Insert(index, item);
			}
			public void Insert(int index, string item)
			{
				CheckedListBoxItem newItem = _viewModel.Container.Resolve<CheckedListBoxItem>();
				newItem.Text = item;
				newItem.Value = item;
				newItem.Checked = false;
				_viewModel.Items.Insert(index, newItem);
			}

			private int IndexOfItem(CheckedListBoxItem item)
			{
				int innerIndex = -1;
				for (int i = 0; i < _viewModel.Items.Count; i++)
				{
					if (item == _viewModel.Items[i])
					{
						innerIndex = i;
					}
				}
				return innerIndex;
			}

			public void RemoveAt(int index)
			{
				_viewModel.Items.RemoveAt(index);
			}

			public CheckedListBoxItem this[int index]
			{
				get
				{
					return SelectedItems().ElementAt(index);
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			public void Add(Object item)
			{
				if (item is CheckedListBoxItem)
				{
					CheckedListBoxItem value = ((CheckedListBoxItem)item);
					CheckedListBoxItem newItem = _viewModel.Container.Resolve<CheckedListBoxItem>();
					newItem.Text = value.Text;
					newItem.Value = value.Value;
					newItem.Checked = value.Checked;
					_viewModel.AddItem(newItem);
				}
				else
				{
					CheckedListBoxItem newItem = _viewModel.Container.Resolve<CheckedListBoxItem>();
					newItem.Text = item.ToString();
					newItem.Value = item;
					_viewModel.AddItem(newItem);
				}
			}

			public void Add(object item, bool check)
			{
				CheckedListBoxItem newItem = _viewModel.Container.Resolve<CheckedListBoxItem>();
				newItem.Text = item.ToString();
				newItem.Value = item;
				newItem.Checked = check;
				_viewModel.AddItem(newItem);
			}

			public void Add(object item, CheckState checkState)
			{
				var check = (checkState == CheckState.Checked) ? true : false;
				CheckedListBoxItem newItem = _viewModel.Container.Resolve<CheckedListBoxItem>();
				newItem.Text = item.ToString();
				newItem.Value = item;
				newItem.Checked = check;
				_viewModel.AddItem(newItem);

			}

			public void AddRange(object[] items)
			{
				foreach (var item in items)
				{
					_viewModel.AddItem(item);
				}

			}

			public void Clear()
			{
				_viewModel.Items.Clear();
			}

			public bool Contains(CheckedListBoxItem item)
			{
				return SelectedItems().Any(innerItem => innerItem == item);
			}
			public bool Contains(string item)
			{
				return SelectedItems().Any(innerItem => innerItem.Text.Equals(item));
			}

			public void CopyTo(CheckedListBoxItem[] array, int arrayIndex)
			{
				throw new NotImplementedException();
			}

			public int Count
			{
				get { return SelectedItems().Count(); }
			}

			public bool IsReadOnly
			{
				get { return true; }
			}

			public bool Remove(CheckedListBoxItem item)
			{
				RemoveAt(IndexOfItem(item));
				return true;
			}

			public IEnumerator<CheckedListBoxItem> GetEnumerator()
			{
				return SelectedItems().GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return SelectedItems().GetEnumerator();
			}
		}
	}
}
