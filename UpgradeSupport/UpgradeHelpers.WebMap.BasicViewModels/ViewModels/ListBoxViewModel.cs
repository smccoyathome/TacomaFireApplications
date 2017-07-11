using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.BasicViewModels
{

	public enum SelectionMode
	{
		Single, Multiple, None
	}

	/// <summary>
	///  View model for ListBox controls
	/// </summary>
	public class ListBoxViewModel : ControlViewModel
	{
		private ListBoxItemCollection _items;
		private ListBoxSelectedIndexCollection _selectedIndices;

		/// <summary>
		///  Initialization for view model
		/// </summary>
		/// <param name="container"></param>
		public override void Build(IIocContainer ctx)
		{
			base.Build(ctx);
			Enabled = true;
			Visible = true;
			SelectionMode = SelectionMode.Single;
			ListBoxSelectedIndices = new[] { -1 };
			ListBoxItems = StaticContainer.Instance.Resolve<IList<ListBoxItem>>();
		}

		/// <summary>
		/// Returns a DisplayMember that will be used in to view that presents this model
		/// </summary>

		public virtual string DisplayMember { get; set; }

		/// <summary>
		/// Returns a ValueMember that will be used in to view that presents this model
		/// </summary>

		public virtual string ValueMember { get; set; }

		/// <summary>
		///    ListBox selection mode
		/// </summary>
		public virtual SelectionMode SelectionMode { get; set; }

		public virtual IList<ListBoxItem> ListBoxItems { get; set; }

		public ListBoxItemCollection Items
		{
			get { return _items ?? (_items = new ListBoxItemCollection(this)); }
		}

		/// <summary>
		///  Returns a dummy collection for selected items. This object is transient it is only used to 
		/// </summary>
		[StateManagement(StateManagementValues.None)]
		public ListBoxSelectedItemCollection SelectedItems
		{
			get
			{
				return new ListBoxSelectedItemCollection(this);
			}
		}

		/// <summary>
		///    This property keeps an array of indices of the selected elements
		/// </summary>
		public virtual int[] ListBoxSelectedIndices { get; set; }

		public ListBoxSelectedIndexCollection SelectedIndices
		{
			get { return _selectedIndices ?? (_selectedIndices = new ListBoxSelectedIndexCollection(this)); }
		}
		/// <summary>
		/// Gets or sets the TopIndex value for this control
		/// </summary>
		public virtual int TopIndex { get; set; }

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
					ViewManager.Events.Publish(SelectedIndexChangedKey, this, new EventArgs());
			}
		}

		/// <summary>
		///  Gets the selected item of the ListBox
		/// </summary>
		[StateManagement(StateManagementValues.None)]
		public object SelectedItem
		{
			get
			{
				if (SelectedIndex >= 0)
				{
					var listBoxItem = ListBoxItems[SelectedIndex];

					if (listBoxItem != null)
					{
						return listBoxItem.Item ?? listBoxItem.Text;
					}
					return listBoxItem;
				}
				return null;
			}
		}

		/// <summary>
		///  Gets or sets the text of the list box control
		/// </summary>
		[StateManagement(StateManagementValues.None)]
		public override string Text
		{
			get
			{
				if (SelectedIndex != -1)
				{
					return ListBoxItems[SelectedIndex].Text;
				}
				return "";
			}
			set
			{
				if (value == null) throw new ArgumentNullException("value");
				if (SelectedIndex != -1)
				{
					ListBoxItems[SelectedIndex].Text = value;
				}
			}
		}

		private object GetMemberValue(object item, string member)
		{
			if (String.IsNullOrEmpty(member))
				return item.ToString();
			// lets get the property
			var type = item.GetType();
			var prop = type.GetProperty(member);
			if (prop != null)
			{
				return prop.GetValue(item, null);
			}
			return null;
		}

		public ListBoxItem CreateItem(object item)
		{
			var newItem = StaticContainer.Instance.Resolve<ListBoxItem>();
			if (!(item is string))
			{
				newItem.Item = item;
				if (!String.IsNullOrEmpty(DisplayMember) && !String.IsNullOrEmpty(ValueMember))
				{
					newItem.Text = GetMemberValue(item, DisplayMember).ToString();
					newItem.Value = GetMemberValue(item, ValueMember);
				}
				else
				{
					if (!String.IsNullOrEmpty(DisplayMember) || !String.IsNullOrEmpty(ValueMember))
					{
						var property = String.IsNullOrEmpty(DisplayMember) ? ValueMember : DisplayMember;
						newItem.Value = GetMemberValue(item, property);
						newItem.Text = newItem.Value.ToString();
					}
					else
					{
						newItem.Text = item.ToString();
						newItem.Value = item.ToString();
					}
				}
			}
			else
			{
				newItem.Text = item.ToString();
				newItem.Value = item.ToString();
			}
			return newItem;
		}

		public ListBoxItem FindByValue(object dataValue)
		{
			return ListBoxItems.FirstOrDefault(t => t != null && t.Value.Equals(dataValue));
		}

		public int FindString(string s, int startIndex = 0)
		{
			if (startIndex < 0 || startIndex >= ListBoxItems.Count)
			{
				throw new ArgumentOutOfRangeException(
					"The startIndex parameter is less than zero or greater than or equal to the value of the UpgradeHelpers.BasicViewModels.ListBoxItemCollection.Count" +
					" property of the UpgradeHelpers.BasicViewModels.ListBoxItemCollection class.");
			}
			for (var i = startIndex; i < ListBoxItems.Count; i++)
			{
				if (ListBoxItems[i].Text.StartsWith(s))
					return i;
			}
			return -1;
		}
		public int FindStringExact(string s, int startIndex = 0)
		{
			if (startIndex < 0 || startIndex >= ListBoxItems.Count)
			{
				throw new ArgumentOutOfRangeException(
					"The startIndex parameter is less than zero or greater than or equal to the value of the UpgradeHelpers.BasicViewModels.ListBoxItemCollection.Count" +
					" property of the UpgradeHelpers.BasicViewModels.ListBoxItemCollection class.");
			}
			for (var i = startIndex; i < ListBoxItems.Count; i++)
			{
				if (ListBoxItems[i].Text.Equals(s))
					return i;
			}
			return -1;
		}

		/// <summary>
		/// Adds a new element to the combo
		/// </summary>
		/// <param name="item">item to add</param>
		/// <param name="index">position to adding</param>
		public int AddItem(object item, int index = -1)
		{
			var newItem = CreateItem(item);
			if (index == -1 || index == ListBoxItems.Count)
			{
				ListBoxItems.Add(newItem);
				return ListBoxItems.Count - 1;
			}
			ListBoxItems.Insert(index, newItem);
			return index;
		}

		/// <summary>
		///  Removes an element from the ListBox
		/// </summary>
		/// <param name="itemIndex"></param>
		public void RemoveItem(int itemIndex)
		{
			ListBoxItems.RemoveAt(itemIndex);
		}

		/// <summary>
		///  Gets the selected state of the specified element of the list
		/// </summary>
		/// <param name="itemIndex"></param>
		/// <returns></returns>
		public bool GetSelected(int itemIndex)
		{
			return ListBoxSelectedIndices.Any(index => index == itemIndex);
		}

		/// <summary>
		///    Sets the selected state of the specified list entry
		/// </summary>
		/// <param name="itemIndex"></param>
		/// <param name="selectedState"></param>
		/// <returns></returns>
		public bool SetSelected(int itemIndex, bool selectedState)
		{
			// Reset selection if working in Simple selection mode
			if (SelectionMode == SelectionMode.Single)
			{
				ListBoxSelectedIndices = new int[] { };
			}

			if (!GetSelected(itemIndex))
			{
				if (selectedState)
				{
					var indices = new int[ListBoxSelectedIndices.Length + 1];
					Array.Copy(ListBoxSelectedIndices, indices, ListBoxSelectedIndices.Length);
					indices[indices.Length - 1] = itemIndex;
					ListBoxSelectedIndices = indices;
				}
				else
				{
					ListBoxSelectedIndices = ListBoxSelectedIndices.Where(index => index != itemIndex).ToArray();
				}
			}
			return true;
		}

		/// <summary>
		///   Returns the value at the specified index
		/// </summary>
		/// <param name="index">index of th requested element</param>
		/// <returns>the value of the requested element</returns>
		public string GetListItem(int index)
		{
			string result = "";
			if (index >= 0 && index < ListBoxItems.Count)
			{
				result = ListBoxItems[index].Text;
			}
			return result;
		}

		/// <summary>
		///   Sets the item at the specified index
		/// </summary>
		/// <param name="index">index of the element to change</param>
		/// <param name="text">the value of the entry</param>
		public void SetListItem(int index, string text)
		{
			if (index >= 0 && index < ListBoxItems.Count)
			{
				ListBoxItems[index].Text = text;
			}
		}

		/// <summary>
		/// Sets the ItemData of a specific item
		/// </summary>
		/// <param name="index">The index of the item which ItemData will be set</param>
		/// <param name="value">The value of the ItemData to set</param>
		public void SetItemData(int index, int value)
		{
			if (ListBoxItems.Count > 0 && ListBoxItems.Count > index)
			{
				ListBoxItems[index].Data = value;
			}
		}

		/// <summary>
		/// <param name="index">The index of the item which ItemData will be returned</param>
		/// <returns>Return the ItemData of the item in the "index" position</returns>
		/// Gets the ItemData of a specific item
		/// </summary>
		public int GetItemData(int index)
		{
			if (ListBoxItems.Count > 0 && ListBoxItems.Count > index)
			{
				var itemData = ListBoxItems[index].Data;
				return itemData.HasValue ? itemData.Value : -1;
			}
			return 0;
		}

		/// <summary>
		/// Gets the index of the last added element
		/// </summary>
		/// <returns>The index of the last added element</returns>
		public int GetNewIndex()
		{
			return ListBoxItems.Count - 1;
		}

		[JsonObject]
		public class ListBoxItemCollection : IEnumerable
		{
			private readonly ListBoxViewModel _listBoxViewModel;

			public ListBoxItemCollection(ListBoxViewModel listBoxViewModel)
			{
				_listBoxViewModel = listBoxViewModel;
			}

			public void Add(object item)
			{
				_listBoxViewModel.AddItem(item);
			}

			public void AddRange(object[] items)
			{
				foreach (var item in items)
				{
					_listBoxViewModel.AddItem(item);
				}
			}

			public IEnumerable<T> OfType<T>()
			{
				return _listBoxViewModel.ListBoxItems.Select(item => (T)item.Value);
			}

			public void Clear()
			{
				_listBoxViewModel.ListBoxItems.Clear();
			}

			public bool Contains(object value)
			{
				var comboBoxItem = value is ListBoxItem ? value as ListBoxItem : _listBoxViewModel.FindByValue(value);
				return _listBoxViewModel.ListBoxItems.Contains(comboBoxItem);
			}

			public int Count
			{
				get { return _listBoxViewModel.ListBoxItems.Count; }
			}

			public int IndexOf(object value)
			{
				var comboBoxItem = value is ListBoxItem ? value as ListBoxItem : _listBoxViewModel.FindByValue(value);
				return _listBoxViewModel.ListBoxItems.IndexOf(comboBoxItem);
			}

			public void Insert(int index, object item)
			{
				_listBoxViewModel.AddItem(item, index);
			}

			public void Remove(object value)
			{
				var comboBoxItem = value is ListBoxItem ? value as ListBoxItem : _listBoxViewModel.FindByValue(value);
				_listBoxViewModel.ListBoxItems.Remove(comboBoxItem);
			}

			public void RemoveAt(int index)
			{
				_listBoxViewModel.ListBoxItems.RemoveAt(index);
			}

			public object this[int index]
			{
				get { return _listBoxViewModel.ListBoxItems[index].Item ?? _listBoxViewModel.ListBoxItems[index].Text; }
				set { _listBoxViewModel.ListBoxItems[index].Text = value.ToString(); }
			}

			public IEnumerator GetEnumerator()
			{
				return _listBoxViewModel.ListBoxItems.GetEnumerator();
			}
		}

		[JsonObject]
		public class ListBoxSelectedIndexCollection : IEnumerable
		{
			private readonly ListBoxViewModel _listBoxViewModel;

			public ListBoxSelectedIndexCollection(ListBoxViewModel listBoxViewModel)
			{
				_listBoxViewModel = listBoxViewModel;
			}

			public void Add(int index)
			{
				if (index < 0 || index >= _listBoxViewModel.ListBoxItems.Count)
				{
					throw new ArgumentOutOfRangeException(String.Format("Additional information: InvalidArgument=Value of '{0}' is not valid for 'index'.", index));
				}
				if (_listBoxViewModel.SelectionMode == SelectionMode.None)
				{
					throw new InvalidOperationException("Cannot call this method when SelectionMode is SelectionMode.NONE.");
				}
				if (_listBoxViewModel.SelectionMode == SelectionMode.Single)
				{
					_listBoxViewModel.ListBoxSelectedIndices = new[] { index };
				}
				else if (!_listBoxViewModel.ListBoxSelectedIndices.Contains(index))
				{
					Remove(-1);
					var indices = new int[_listBoxViewModel.ListBoxSelectedIndices.Length + 1];
					Array.Copy(_listBoxViewModel.ListBoxSelectedIndices, indices, _listBoxViewModel.ListBoxSelectedIndices.Length);
					indices[indices.Length - 1] = index;
					_listBoxViewModel.ListBoxSelectedIndices = indices;
				}
			}

			public void Clear()
			{
				_listBoxViewModel.ListBoxSelectedIndices = new[] { -1 };
			}

			public bool Contains(int selectedIndex)
			{
				return _listBoxViewModel.ListBoxSelectedIndices.Contains(selectedIndex);
			}

			public int Count
			{
				get
				{
					if (!Contains(-1))
						return _listBoxViewModel.ListBoxSelectedIndices.Length;
					return _listBoxViewModel.ListBoxSelectedIndices.Length - 1;
				}
			}

			public int IndexOf(int selectedIndex)
			{
				return Array.IndexOf(_listBoxViewModel.ListBoxSelectedIndices, selectedIndex);
			}

			public void Remove(int selectedIndex)
			{
				var listTemp = _listBoxViewModel.ListBoxSelectedIndices.ToList();
				listTemp.Remove(selectedIndex);
				_listBoxViewModel.ListBoxSelectedIndices = listTemp.ToArray();
			}

			public int this[int index]
			{
				get { return _listBoxViewModel.ListBoxSelectedIndices[index]; }
			}

			public IEnumerator GetEnumerator()
			{
				return _listBoxViewModel.ListBoxSelectedIndices.GetEnumerator();
			}
		}

		[JsonObject]
		public class ListBoxSelectedItemCollection : IEnumerable
		{
			private readonly ListBoxViewModel _listBoxViewModel;

			public ListBoxSelectedItemCollection(ListBoxViewModel listBoxViewModel)
			{
				_listBoxViewModel = listBoxViewModel;
			}

			public void Add(object item)
			{
				var comboBoxItem = item is ListBoxItem ? item as ListBoxItem : _listBoxViewModel.FindByValue(item);
				var index = _listBoxViewModel.ListBoxItems.IndexOf(comboBoxItem);
				if (index != -1)
					_listBoxViewModel.SelectedIndices.Add(index);

			}

			public void Clear()
			{
				_listBoxViewModel.SelectedIndices.Clear();
			}

			public bool Contains(object value)
			{
				var comboBoxItem = value is ListBoxItem ? value as ListBoxItem : _listBoxViewModel.FindByValue(value);
				var index = _listBoxViewModel.ListBoxItems.IndexOf(comboBoxItem);
				return _listBoxViewModel.SelectedIndices.Contains(index);
			}

			public int Count
			{
				get { return _listBoxViewModel.SelectedIndices.Count; }
			}

			public int IndexOf(object value)
			{
				var comboBoxItem = value is ListBoxItem ? value as ListBoxItem : _listBoxViewModel.FindByValue(value);
				var index = _listBoxViewModel.ListBoxItems.IndexOf(comboBoxItem);
				return _listBoxViewModel.SelectedIndices.IndexOf(index);
			}

			public void Remove(object value)
			{
				var comboBoxItem = value is ListBoxItem ? value as ListBoxItem : _listBoxViewModel.FindByValue(value);
				var index = _listBoxViewModel.ListBoxItems.IndexOf(comboBoxItem);
				_listBoxViewModel.SelectedIndices.Remove(index);
			}

			public object this[int index]
			{
				get
				{
					var realIndex = _listBoxViewModel.SelectedIndices[index];
					if (realIndex < 0 || realIndex >= _listBoxViewModel.ListBoxItems.Count)
						throw new ArgumentOutOfRangeException("");
					return _listBoxViewModel.ListBoxItems[realIndex].Item ?? _listBoxViewModel.ListBoxItems[realIndex].Text;
				}
				set { throw new NotImplementedException(); }
			}

			public IEnumerator GetEnumerator()
			{
				return (IEnumerator)new ListBoxSelectedItemEnum(_listBoxViewModel);
			}

			private class ListBoxSelectedItemEnum : IEnumerator
			{
				private readonly ListBoxViewModel _listBoxViewModel;

				// Enumerators are positioned before the first element 
				// until the first MoveNext() call. 
				int _position = -1;

				public ListBoxSelectedItemEnum(ListBoxViewModel listBoxViewModel)
				{
					_listBoxViewModel = listBoxViewModel;
				}

				public bool MoveNext()
				{
					_position++;
					return (_position < _listBoxViewModel.SelectedIndices.Count);
				}

				public void Reset()
				{
					_position = -1;
				}

				object IEnumerator.Current
				{
					get
					{
						return Current;
					}
				}

				public ListBoxItem Current
				{
					get
					{
						try
						{
							var realIndex = _listBoxViewModel.SelectedIndices[_position];
							if (realIndex < 0 || realIndex >= _listBoxViewModel.ListBoxItems.Count)
								throw new ArgumentOutOfRangeException("");
							return _listBoxViewModel.ListBoxItems[realIndex];
						}
						catch (IndexOutOfRangeException)
						{
							throw new InvalidOperationException();
						}
					}
				}
			}
		}
	}
}