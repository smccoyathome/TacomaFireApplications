using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Server.Common;

namespace UpgradeHelpers.BasicViewModels
{



	/// <summary>
	///  Modes for this list view control
	/// </summary>
	public enum ListViewMode
	{
		LargeIcon = 0,
		Details = 1,
		SmallIcon = 2,
		List = 3,
		Tile = 4,
	}

	/// <summary>
	/// Specifies how items in the list are sorted
	/// </summary>
	public enum SortOrder
	{
		None = 0,
		Ascending = 1,
		Descending = 2,
	}

	/// <summary>
	///   Collection object for list view columns
	/// </summary>
	public class ListViewColumnsViewModel : IDependentViewModel
	{
		[JsonProperty("@k")]
		public int k = 1;
		public virtual IList<ColumnHeaderViewModel> _items { get; set; }

		[StateManagement(StateManagementValues.None)]
		public IList<ColumnHeaderViewModel> Items
		{
			get { return _items; }
		}


		public string UniqueID { get; set; }

		public void Build(IIocContainer ctx)
		{
			_items = ctx.Resolve<IList<ColumnHeaderViewModel>>();
		}
	}

	/// <summary>
	///  ViewModel for ListView controls
	/// </summary>
	public class ListViewViewModel : ControlViewModel, IInteractsWithView
	{
		private ListViewSelectedIndexCollection _selectedIndices;
		private ListViewCheckedIndicesCollection _checkedIndices;
		private int[] _listviewCheckedIndices;
		private int[] _listviewSelectedIndices;
		private ListViewItemCollection _items;
		private SortOrder _sortOrder;
		/// <summary>
		///  Control initialization
		/// </summary>
		/// <param name="ctx"></param>
		public override void Build(IIocContainer ctx)
		{
			base.Build(ctx);
			View = ListViewMode.LargeIcon;
			ListViewSelectedIndices = new[] { -1 };
			ListViewCheckedIndices = new[] { -1 };
			Columns = ctx.Resolve<ListViewColumnsViewModel>();
			ListViewItemViewModels = ctx.Resolve<IList<ListViewItemViewModel>>();
		}

		private void ListViewItemViewModels_CollectionChanged()
		{
			int i = 0;
			foreach (ListViewItemViewModel item in ListViewItemViewModels)
			{
				item.Index = i;
				i++;
			}
		}
	

		public virtual string DisplayMember { get; set; }

		/// <summary>
		/// Returns a ValueMember that will be used in to view that presents this model
		/// </summary>

		public virtual string ValueMember { get; set; }

		/// <summary>
		///  Gets or sets the mode of the ListView Control
		/// </summary>
		public virtual ListViewMode View
		{
			get;
			set;
		}
		/// <summary>
		/// Gets or sets the sort order for items in the control
		/// </summary>
		public virtual SortOrder Sorting
		{
			get
			{
				return _sortOrder;
			}
			set
			{
				_sortOrder = value;
				SortElements();
			}
		}


		private void SortElements()
		{
			if (_sortOrder == SortOrder.Descending && ListViewItemViewModels != null)
			{
				IEnumerable<ListViewItemViewModel> orderedItems = ListViewItemViewModels.OrderByDescending(t => t.Text);
				ListViewItemViewModels = orderedItems.ToList();

			}
			else if (_sortOrder == SortOrder.Ascending && ListViewItemViewModels != null)
			{
				IEnumerable<ListViewItemViewModel> orderedItems = ListViewItemViewModels.OrderBy(t => t.Text);
				ListViewItemViewModels = orderedItems.ToList();
			}
		}


		/// <summary>
		///  Gets or sets the current column definitions  for this control
		/// </summary>
		public virtual ListViewColumnsViewModel Columns
		{
			get;
			set;
		}

		/// <summary>
		///  Gets the Selected Indices collection
		/// </summary>
		public virtual ListViewSelectedIndexCollection SelectedIndices
		{
			get { return _selectedIndices ?? (_selectedIndices = new ListViewSelectedIndexCollection(this)); }
		}

		/// <summary>
		///  Gets the Checked Indices collection
		/// </summary>
		public virtual ListViewCheckedIndicesCollection CheckedIndices
		{
			get
			{
				if (this.CheckBoxes)
					return _checkedIndices ?? (_checkedIndices = new ListViewCheckedIndicesCollection(this));
				else
					return null;
			}
		}



		/// <summary>
		///    This property keeps an array of indices of the selected elements
		/// </summary>
		public virtual int[] ListViewSelectedIndices
		{
			get
			{
				return _listviewSelectedIndices;
			}
			set
			{
				_listviewSelectedIndices = value;
				if (ListViewItemViewModels != null)
				{
					for (int i = 0; i < ListViewItemViewModels.Count; i++)
					{
						if (_listviewSelectedIndices.Contains(i))
						{
							ListViewItemViewModels[i].Selected = true;
							ListViewItemViewModels[i].Focused = true;
						}
						else
						{
							ListViewItemViewModels[i].Selected = false;
							ListViewItemViewModels[i].Focused = false;
						}
					}
				}

			}
		}



		/// <summary>
		///    This property keeps an array of indices of the checked elements
		/// </summary>
		public virtual int[] ListViewCheckedIndices
		{
			get
			{
				return _listviewCheckedIndices;
			}
			set
			{
				_listviewCheckedIndices = value;
				if (ListViewItemViewModels != null)
				{
					for (int i = 0; i < ListViewItemViewModels.Count; i++)
					{
						if (_listviewCheckedIndices.Contains(i))
							ListViewItemViewModels[i].Checked = true;
						else
							ListViewItemViewModels[i].Checked = false;
					}
				}
			}
		}

		/// <summary>
		///  This property returns the current selected index
		/// </summary>
		[StateManagement(StateManagementValues.None)]
		public int SelectedIndex
		{
			get
			{
				if (ListViewSelectedIndices.Any())
				{
					return ListViewSelectedIndices.First();
				}
				return -1;
			}
			set
			{
				if (value >= 0 && value <= _items.Count - 1)
				{
					ListViewSelectedIndices = new[] { value };
				}
				if (ViewManager != null)
					ViewManager.Events.Publish(SelectedIndexChangedKey, this, new EventArgs());
			}
		}

		private const string SelectedIndexChangedKey = "SelectedIndexChanged";

		/// <summary>
		///  Returns the selected element
		/// </summary>
		[StateManagement(StateManagementValues.None)]
		public ListViewItemViewModel FocusedItem
		{
			get
			{
				return SelectedIndex >= 0 && SelectedIndex < this.Items.Count ? this.Items[SelectedIndex] : null;
			}
			set
			{
				int valueIndex = -1;
				for (int i = 0; i < this.Items.Count; i++)
				{
					if (value == this.Items[i])
					{
						valueIndex = i;
						break;
					}
				}
				if (valueIndex != -1)
				{
					SelectedIndex = valueIndex;
				}
			}
		}

	


		/// <summary>
		///     Gets or sets if a CheckBox element must appears next to each item in the control.
		/// </summary>
		public virtual bool CheckBoxes { get; set; }

		/// <summary>
		///    ListView selection mode
		/// </summary>
		public virtual bool MultiSelect { get; set; }

		/// <summary>
		/// Collection of Items
		/// </summary>
		//[Watchable(typeof(ObjectWatcher))]
		public virtual IList<ListViewItemViewModel> ListViewItemViewModels { get; set; }

		/// <summary>
		///  Internal element creation
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		//public override Interfaces.IStateObject CreateItem(object item)
		//{
		//    var result = Container.Resolve<ListViewItemViewModel>();
		//    result.Cells = new string[1];
		//    result.Cells[0] = item.ToString();
		//    return result;
		//}

		public ListViewItemViewModel FindByValue(object dataValue)
		{
			return ListViewItemViewModels.FirstOrDefault(t => t.Text.Equals(dataValue));
		}


		public ListViewItemViewModel FindByKey(object dataValue)
		{
			try
			{
				return ListViewItemViewModels.FirstOrDefault(t => t.Name != null && t.Name.Equals(dataValue.ToString(), StringComparison.CurrentCultureIgnoreCase));
			}
			catch (NullReferenceException e)
			{
				return null;
			}
		}

		/// <summary>
		///   Search for an element inside the ListView items collection
		/// </summary>
		/// <param name="text">text used to serach the item</param>
		/// <param name="includeSubItems">flag to indicate if the search will be performed on sub items</param>
		/// <param name="startIndex">the initial index where the search starts</param>
		/// <param name="isPrefixSearch">flag to indicate if this is a prefix search</param>
		/// <returns></returns>
		public ListViewItemViewModel FindItemWithText(string text, bool includeSubItems = false, int startIndex = 0, bool isPrefixSearch = false)
		{
			ListViewItemViewModel result = null;
			var count = this.Items.Count;
			for (int i = startIndex; i < count; i++)
			{
				var current = this.Items[i];
				if (FindItemCompare(text, includeSubItems, isPrefixSearch, current))
				{
					result = current;
					break;
				}
			}
			return result;
		}


		private static bool FindItemCompare(string text, bool includeSubItems, bool isPrefixSearch, ListViewItemViewModel current)
		{
			bool result = false;
			if (!isPrefixSearch)
			{
				result = (text == current.Text
						|| (includeSubItems
							&& Array.IndexOf(current.ItemContent, text) != -1));
			}
			else
			{
				result = (current.Text.StartsWith(text)
						|| (includeSubItems
							&& current.ItemContent.Any(item => item.StartsWith(text))));
			}
			return result;
		}

		[StateManagement(StateManagementValues.None)]
		public ListViewItemCollection Items
		{
			get { return _items ?? (_items = new ListViewItemCollection(this)); }
		}

		public ListViewItemViewModel GetItemByKey(string key)
		{
			ListViewItemViewModel result = null;
			/* for (int i = 0; i < this.Items.Count; i++)
			 {
				 if (this.Items[i].Name == key)
				 {
					 result = this.Items[i];
					 break;
				 }
			 }*/
			return result;
		}

		/// <summary>
		/// Gets the currently selected items in the control. 
		/// </summary>
		[StateManagement(StateManagementValues.None)]
		public ListViewSelectedItemCollection SelectedItems
		{
			get
			{
				return new ListViewSelectedItemCollection(this);
			}
		}

		/// <summary>
		/// Gets the currently checked items in the control.
		/// </summary>
		[StateManagement(StateManagementValues.None)]
		public ListViewCheckedItemCollection CheckedItems
		{
			get
			{
				if (this.CheckBoxes)
					return new ListViewCheckedItemCollection(this);
				else
					return null;
			}
		}

		/// <summary>
		/// Adds a new element to the combo
		/// </summary>
		/// <param name="item">item to add</param>
		/// <param name="index">position to adding</param>
		public int AddItem(object item, int index = -1)
		{
			var newItem = CreateItem(item);
			if (index == -1 || index == ListViewItemViewModels.Count)
			{
				ListViewItemViewModels.Add(newItem);
				SortElements();
				ListViewItemViewModels_CollectionChanged();
				if (newItem.Selected)
					SelectedIndices.Add(newItem.Index);
				if (newItem.Checked)
					CheckedIndices.Add(newItem.Index);

				return newItem.Index;
			}
			ListViewItemViewModels.Insert(index, newItem);
			SortElements();
			return index;
		}

		/// <summary>
		/// Creates a new ListViewItem
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public ListViewItemViewModel CreateItem(object item)
		{
			var newItem = StaticContainer.Instance.Resolve<ListViewItemViewModel>();
			newItem.ItemContent = new string[1];
			if (item is ListViewItemViewModel)
			{
				newItem = ((ListViewItemViewModel)item);

			}
			else
				newItem.ItemContent[0] = item.ToString();
			return newItem;
		}

		public void newItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			ListViewItemViewModel item = ((ListViewItemViewModel)sender);

			if (item.Selected || item.Focused)
			{
				int index = Items.IndexOf(item);
				if (index > -1)
					SelectedIndices.Add(index);
			}
			if (item.Checked)
			{
				int index = Items.IndexOf(item);
				if (index > -1)
					CheckedIndices.Add(index);
			}

		}

		/// <summary>
		///  Removes an element from the ListView
		/// </summary>
		/// <param name="itemIndex"></param>
		public void RemoveItem(int itemIndex)
		{
			ListViewItemViewModels.RemoveAt(itemIndex);
			ListViewItemViewModels_CollectionChanged();
		}



		public ImageListViewModel SmallImageList { get; set; }
	}


	[JsonObject]
	public class ListViewSelectedIndexCollection : IEnumerable
	{
		private readonly ListViewViewModel _ListViewViewModel;

		public ListViewSelectedIndexCollection(ListViewViewModel ListViewViewModel)
		{
			_ListViewViewModel = ListViewViewModel;
		}

		public void Add(int index)
		{
			if (index < 0 || index >= _ListViewViewModel.Items.Count)
			{
				throw new ArgumentOutOfRangeException(String.Format("Additional information: InvalidArgument=Value of '{0}' is not valid for 'index'.", index));
			}
			//if (_ListViewViewModel.SelectionMode == SelectionMode.None)
			//{
			//    throw new InvalidOperationException("Cannot call this method when SelectionMode is SelectionMode.NONE.");
			//}
			//if (!_ListViewViewModel.MultiSelect)
			//{
			//    _ListViewViewModel.ListViewSelectedIndices = new[] { index };
			//}
			if (!_ListViewViewModel.ListViewSelectedIndices.Contains(index))
			{
				Remove(-1);
				var indices = new int[_ListViewViewModel.ListViewSelectedIndices.Length + 1];
				Array.Copy(_ListViewViewModel.ListViewSelectedIndices, indices, _ListViewViewModel.ListViewSelectedIndices.Length);
				indices[indices.Length - 1] = index;
				_ListViewViewModel.ListViewSelectedIndices = indices;
			}
		}

		public void Clear()
		{
			_ListViewViewModel.ListViewSelectedIndices = new[] { -1 };
		}

		public bool Contains(int selectedIndex)
		{
			return _ListViewViewModel.ListViewSelectedIndices.Contains(selectedIndex);
		}

		public int Count
		{
			get
			{
				if (!Contains(-1))
					return _ListViewViewModel.ListViewSelectedIndices.Length;
				return _ListViewViewModel.ListViewSelectedIndices.Length - 1;
			}
		}

		public int IndexOf(int selectedIndex)
		{
			return Array.IndexOf(_ListViewViewModel.ListViewSelectedIndices, selectedIndex);
		}



		public void Remove(int selectedIndex)
		{
			var listTemp = _ListViewViewModel.ListViewSelectedIndices.ToList();
			listTemp.Remove(selectedIndex);
			_ListViewViewModel.ListViewSelectedIndices = listTemp.ToArray();
		}

		public int this[int index]
		{
			get { return _ListViewViewModel.ListViewSelectedIndices[index]; }
		}

		public IEnumerator GetEnumerator()
		{
			return _ListViewViewModel.ListViewSelectedIndices.GetEnumerator();
		}
	}

	[JsonObject]
	public class ListViewSelectedItemCollection : IEnumerable
	{
		private readonly ListViewViewModel _ListViewViewModel;

		public ListViewSelectedItemCollection(ListViewViewModel ListViewViewModel)
		{
			_ListViewViewModel = ListViewViewModel;
		}

		public void Add(object item)
		{
			var listViewItem = item is ListViewItemViewModel ? item as ListViewItemViewModel : _ListViewViewModel.FindByValue(item);
			var index = _ListViewViewModel.ListViewItemViewModels.IndexOf(listViewItem);
			if (index != -1)
				_ListViewViewModel.SelectedIndices.Add(index);

		}

		public void Clear()
		{
			_ListViewViewModel.SelectedIndices.Clear();
		}

		public bool Contains(object value)
		{
			var listViewItem = value is ListViewItemViewModel ? value as ListViewItemViewModel : _ListViewViewModel.FindByValue(value);
			var index = _ListViewViewModel.ListViewItemViewModels.IndexOf(listViewItem);
			return _ListViewViewModel.SelectedIndices.Contains(index);
		}

		public bool ContainsKey(object value)
		{
			var listViewItem = value is ListViewItemViewModel ? value as ListViewItemViewModel : _ListViewViewModel.FindByKey(value);
			var index = _ListViewViewModel.ListViewItemViewModels.IndexOf(listViewItem);
			return _ListViewViewModel.SelectedIndices.Contains(index);
		}

		public int Count
		{
			get { return _ListViewViewModel.SelectedIndices.Count; }
		}

		public int IndexOf(object value)
		{
			var listViewItem = value is ListViewItemViewModel ? value as ListViewItemViewModel : _ListViewViewModel.FindByValue(value);
			var index = _ListViewViewModel.ListViewItemViewModels.IndexOf(listViewItem);
			return _ListViewViewModel.SelectedIndices.IndexOf(index);
		}

		public int IndexOfKey(object value)
		{
			var listViewItem = value is ListViewItemViewModel ? value as ListViewItemViewModel : _ListViewViewModel.FindByKey(value);
			var index = _ListViewViewModel.ListViewItemViewModels.IndexOf(listViewItem);
			return _ListViewViewModel.SelectedIndices.IndexOf(index);
		}

		public void Remove(object value)
		{
			var listViewItem = value is ListViewItemViewModel ? value as ListViewItemViewModel : _ListViewViewModel.FindByValue(value);
			var index = _ListViewViewModel.ListViewItemViewModels.IndexOf(listViewItem);
			_ListViewViewModel.SelectedIndices.Remove(index);
		}

		public ListViewItemViewModel this[int index]
		{
			get
			{
				var realIndex = _ListViewViewModel.ListViewSelectedIndices[index] - 1;
				if (realIndex < 0 || realIndex >= _ListViewViewModel.ListViewItemViewModels.Count)
					throw new ArgumentOutOfRangeException("");
				else
					return ((ListViewItemViewModel)_ListViewViewModel.ListViewItemViewModels[realIndex]) ?? ((ListViewItemViewModel)_ListViewViewModel.ListViewItemViewModels[realIndex]);
			}
			set { throw new NotImplementedException(); }
		}

		public IEnumerator GetEnumerator()
		{
			return (IEnumerator)new ListViewSelectedItemEnum(_ListViewViewModel);
		}

		private class ListViewSelectedItemEnum : IEnumerator
		{
			private readonly ListViewViewModel _ListViewViewModel;

			// Enumerators are positioned before the first element 
			// until the first MoveNext() call. 
			int _position = -1;

			public ListViewSelectedItemEnum(ListViewViewModel ListViewViewModel)
			{
				_ListViewViewModel = ListViewViewModel;
			}

			public bool MoveNext()
			{
				_position++;
				return (_position < _ListViewViewModel.SelectedIndices.Count);
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

			public ListViewItemViewModel Current
			{
				get
				{
					try
					{
						var realIndex = _ListViewViewModel.SelectedIndices[_position];
						if (realIndex < 0 || realIndex >= _ListViewViewModel.ListViewItemViewModels.Count)
							throw new ArgumentOutOfRangeException("");
						return _ListViewViewModel.ListViewItemViewModels[realIndex];
					}
					catch (IndexOutOfRangeException)
					{
						throw new InvalidOperationException();
					}
				}
			}
		}
	}

	[JsonObject]
	public class ListViewItemCollection : IEnumerable
	{
		private readonly ListViewViewModel _ListViewViewModel;

		public ListViewItemCollection(ListViewViewModel ListViewViewModel)
		{
			_ListViewViewModel = ListViewViewModel;
		}

		public ListViewItemViewModel Add(object item)
		{
			_ListViewViewModel.AddItem(item);
			return _ListViewViewModel.ListViewItemViewModels.Last<ListViewItemViewModel>();
		}


		public virtual ListViewItemViewModel Add(string text, int imageIndex)
		{
			ListViewItemViewModel newItem = StaticContainer.Instance.Resolve<ListViewItemViewModel>();
			newItem.Text = text;
			newItem.ImageIndex = imageIndex;
			_ListViewViewModel.AddItem(newItem);
			return newItem;
		}

		public virtual ListViewItemViewModel Add(string text, string imageKey)
		{
			ListViewItemViewModel newItem = StaticContainer.Instance.Resolve<ListViewItemViewModel>();
			newItem.Text = text;
			newItem.ImageKey = imageKey;
			_ListViewViewModel.AddItem(newItem);
			return newItem;

		}

		public virtual ListViewItemViewModel Add(string key, string text, int imageIndex)
		{
			ListViewItemViewModel newItem = StaticContainer.Instance.Resolve<ListViewItemViewModel>();
			newItem.Text = text;
			newItem.ImageIndex = imageIndex;
			newItem.Name = key;
			_ListViewViewModel.AddItem(newItem);
			return newItem;
		}

		public virtual ListViewItemViewModel Add(string key, string text, string imageKey)
		{
			ListViewItemViewModel newItem = StaticContainer.Instance.Resolve<ListViewItemViewModel>();
			newItem.Text = text;
			newItem.ImageKey = imageKey;
			_ListViewViewModel.AddItem(newItem);
			return newItem;

		}

		public void AddRange(object[] items)
		{
			foreach (var item in items)
			{
				_ListViewViewModel.AddItem(item);
			}
		}

		public void Clear()
		{
			_ListViewViewModel.ListViewItemViewModels.Clear();
		}

		public bool Contains(object value)
		{
			var listViewItem = value is ListViewItemViewModel ? value as ListViewItemViewModel : _ListViewViewModel.FindByValue(value);
			return _ListViewViewModel.ListViewItemViewModels.Contains(listViewItem);
		}

		public bool ContainsKey(object value)
		{
			var listViewItem = value is ListViewItemViewModel ? value as ListViewItemViewModel : _ListViewViewModel.FindByKey(value);
			return _ListViewViewModel.ListViewItemViewModels.Contains(listViewItem);
		}

		public int Count
		{
			get { return _ListViewViewModel.ListViewItemViewModels.Count; }
		}

		public int IndexOf(object value)
		{
			var listViewItem = value is ListViewItemViewModel ? value as ListViewItemViewModel : _ListViewViewModel.FindByValue(value);
			return _ListViewViewModel.ListViewItemViewModels.IndexOf(listViewItem);
		}

		public int IndexOfKey(object value)
		{
			var listViewItem = value is ListViewItemViewModel ? value as ListViewItemViewModel : _ListViewViewModel.FindByKey(value);
			return _ListViewViewModel.ListViewItemViewModels.IndexOf(listViewItem);
		}

		public ListViewItemViewModel Insert(int index, object item)
		{
			ListViewItemViewModel newItem = StaticContainer.Instance.Resolve<ListViewItemViewModel>();
			newItem.Text = ((ListViewItemViewModel)item).Text ?? "";
			_ListViewViewModel.AddItem(newItem, index);
			return newItem;
		}

		public ListViewItemViewModel Insert(int index, string text)
		{
			ListViewItemViewModel newItem = StaticContainer.Instance.Resolve<ListViewItemViewModel>();
			newItem.Text = text;
			newItem.PropertyChanged += _ListViewViewModel.newItem_PropertyChanged;
			_ListViewViewModel.AddItem(newItem, index);
			return newItem;
		}
		public ListViewItemViewModel Insert(int index, string text, int imageIndex)
		{
			ListViewItemViewModel newItem = StaticContainer.Instance.Resolve<ListViewItemViewModel>();
			newItem.Text = text;
			newItem.PropertyChanged += _ListViewViewModel.newItem_PropertyChanged;
			newItem.ImageIndex = imageIndex;
			_ListViewViewModel.AddItem(newItem, index);
			return newItem;
		}
		public ListViewItemViewModel Insert(int index, string text, string imageKey)
		{
			ListViewItemViewModel newItem = StaticContainer.Instance.Resolve<ListViewItemViewModel>();
			newItem.Text = text;
			newItem.PropertyChanged += _ListViewViewModel.newItem_PropertyChanged;
			newItem.ImageKey = imageKey;
			_ListViewViewModel.AddItem(newItem, index);
			return newItem;
		}
		public virtual ListViewItemViewModel Insert(int index, string key, string text, int imageIndex)
		{
			ListViewItemViewModel newItem = StaticContainer.Instance.Resolve<ListViewItemViewModel>();
			newItem.Text = text;
			newItem.PropertyChanged += _ListViewViewModel.newItem_PropertyChanged;
			newItem.ImageIndex = imageIndex;
			newItem.Name = key;
			_ListViewViewModel.AddItem(newItem, index);
			return newItem;
		}
		public virtual ListViewItemViewModel Insert(int index, string key, string text, string imageKey)
		{
			ListViewItemViewModel newItem = StaticContainer.Instance.Resolve<ListViewItemViewModel>();
			newItem.Text = text;
			newItem.PropertyChanged += _ListViewViewModel.newItem_PropertyChanged;
			newItem.ImageKey = imageKey;
			newItem.Name = key;
			_ListViewViewModel.AddItem(newItem, index);
			return newItem;
		}

		public void Remove(object value)
		{
			var listViewItem = value is ListViewItemViewModel ? value as ListViewItemViewModel : _ListViewViewModel.FindByValue(value);
			_ListViewViewModel.ListViewItemViewModels.Remove(listViewItem);
		}

		public void RemoveAt(int index)
		{
			_ListViewViewModel.ListViewItemViewModels.RemoveAt(index);
		}

		public void RemoveByKey(string key)
		{
			var listViewItem = _ListViewViewModel.FindByKey(key);
			_ListViewViewModel.ListViewItemViewModels.Remove(listViewItem);
		}

		public ListViewItemViewModel this[int index]
		{
			get
			{

				ListViewItemViewModel item = ((ListViewItemViewModel)_ListViewViewModel.ListViewItemViewModels[index]);
				item.PropertyChanged += _ListViewViewModel.newItem_PropertyChanged;
				return item;
			}



			set { _ListViewViewModel.ListViewItemViewModels[index].Text = value.ToString(); }
		}

		public ListViewItemViewModel[] Find(object value, bool searchAllSubItems)
		{
			var result = new List<ListViewItemViewModel>();
			foreach (var item in _ListViewViewModel.ListViewItemViewModels)
			{
				item.PropertyChanged += _ListViewViewModel.newItem_PropertyChanged;
				if (item.Name.Equals(value.ToString()))
				{
					result.Add(item);
				}
				else
					if (searchAllSubItems)
					{
						foreach (var subitem in item.SubItems)
						{
							if (subitem.Name.Equals(value.ToString()))
							{
								result.Add(item);
								break;
							}
						}

					}

			}
			return result.ToArray();
		}

		public IEnumerator GetEnumerator()
		{
			return _ListViewViewModel.ListViewItemViewModels.GetEnumerator();
		}


	}

	[JsonObject]
	public class ListViewCheckedIndicesCollection : IEnumerable
	{
		private readonly ListViewViewModel _ListViewViewModel;

		public ListViewCheckedIndicesCollection(ListViewViewModel ListViewViewModel)
		{
			_ListViewViewModel = ListViewViewModel;
		}

		public void Add(int index)
		{
			if (index < 0 || index >= _ListViewViewModel.Items.Count)
			{
				throw new ArgumentOutOfRangeException(String.Format("Additional information: InvalidArgument=Value of '{0}' is not valid for 'index'.", index));
			}
			//if (_ListViewViewModel.SelectionMode == SelectionMode.None)
			//{
			//    throw new InvalidOperationException("Cannot call this method when SelectionMode is SelectionMode.NONE.");
			//}
			//if (!_ListViewViewModel.MultiSelect)
			//{
			//    _ListViewViewModel.ListViewSelectedIndices = new[] { index };
			//}
			if (!_ListViewViewModel.ListViewCheckedIndices.Contains(index))
			{
				Remove(-1);
				var indices = new int[_ListViewViewModel.ListViewCheckedIndices.Length + 1];
				Array.Copy(_ListViewViewModel.ListViewCheckedIndices, indices, _ListViewViewModel.ListViewCheckedIndices.Length);
				indices[indices.Length - 1] = index;
				_ListViewViewModel.ListViewCheckedIndices = indices;
			}
		}

		public void Clear()
		{
			_ListViewViewModel.ListViewCheckedIndices = new[] { -1 };
		}

		public bool Contains(int selectedIndex)
		{
			return _ListViewViewModel.ListViewCheckedIndices.Contains(selectedIndex);
		}

		public int Count
		{
			get
			{
				if (!Contains(-1))
					return _ListViewViewModel.ListViewCheckedIndices.Length;
				return _ListViewViewModel.ListViewCheckedIndices.Length - 1;
			}
		}

		public int IndexOf(int selectedIndex)
		{
			return Array.IndexOf(_ListViewViewModel.ListViewCheckedIndices, selectedIndex);
		}



		public void Remove(int selectedIndex)
		{
			var listTemp = _ListViewViewModel.ListViewCheckedIndices.ToList();
			listTemp.Remove(selectedIndex);
			_ListViewViewModel.ListViewCheckedIndices = listTemp.ToArray();
		}

		public int this[int index]
		{
			get { return _ListViewViewModel.ListViewCheckedIndices[index]; }
		}

		public IEnumerator GetEnumerator()
		{
			return _ListViewViewModel.ListViewCheckedIndices.GetEnumerator();
		}
	}


	[JsonObject]
	public class ListViewCheckedItemCollection : IEnumerable
	{
		private readonly ListViewViewModel _ListViewViewModel;

		public ListViewCheckedItemCollection(ListViewViewModel ListViewViewModel)
		{
			_ListViewViewModel = ListViewViewModel;
		}

		public void Add(object item)
		{
			var listViewItem = item is ListViewItemViewModel ? item as ListViewItemViewModel : _ListViewViewModel.FindByValue(item);
			var index = _ListViewViewModel.ListViewItemViewModels.IndexOf(listViewItem);
			if (index != -1)
				_ListViewViewModel.CheckedIndices.Add(index);

		}

		public void Clear()
		{
			_ListViewViewModel.CheckedIndices.Clear();
		}

		public bool Contains(object value)
		{
			var listViewItem = value is ListViewItemViewModel ? value as ListViewItemViewModel : _ListViewViewModel.FindByValue(value);
			var index = _ListViewViewModel.ListViewItemViewModels.IndexOf(listViewItem);
			return _ListViewViewModel.CheckedIndices.Contains(index);
		}

		public bool ContainsKey(object value)
		{
			var listViewItem = value is ListViewItemViewModel ? value as ListViewItemViewModel : _ListViewViewModel.FindByKey(value);
			var index = _ListViewViewModel.ListViewItemViewModels.IndexOf(listViewItem);
			return _ListViewViewModel.CheckedIndices.Contains(index);
		}

		public int Count
		{
			get { return _ListViewViewModel.CheckedIndices.Count; }
		}

		public int IndexOf(object value)
		{
			var listViewItem = value is ListViewItemViewModel ? value as ListViewItemViewModel : _ListViewViewModel.FindByValue(value);
			var index = _ListViewViewModel.ListViewItemViewModels.IndexOf(listViewItem);
			return _ListViewViewModel.CheckedIndices.IndexOf(index);
		}

		public int IndexOfKey(object value)
		{
			var listViewItem = value is ListViewItemViewModel ? value as ListViewItemViewModel : _ListViewViewModel.FindByKey(value);
			var index = _ListViewViewModel.ListViewItemViewModels.IndexOf(listViewItem);
			return _ListViewViewModel.CheckedIndices.IndexOf(index);
		}

		public void Remove(object value)
		{
			var listViewItem = value is ListViewItemViewModel ? value as ListViewItemViewModel : _ListViewViewModel.FindByValue(value);
			var index = _ListViewViewModel.ListViewItemViewModels.IndexOf(listViewItem);
			_ListViewViewModel.CheckedIndices.Remove(index);
		}

		public ListViewItemViewModel this[int index]
		{
			get
			{
				var realIndex = _ListViewViewModel.CheckedIndices[index];
				if (realIndex < 0 || realIndex >= _ListViewViewModel.ListViewItemViewModels.Count)
					throw new ArgumentOutOfRangeException("");
				else
					return ((ListViewItemViewModel)_ListViewViewModel.ListViewItemViewModels[realIndex]);
			}
			set { throw new NotImplementedException(); }
		}

		public IEnumerator GetEnumerator()
		{
			return (IEnumerator)new ListViewCheckedItemEnum(_ListViewViewModel);
		}

		private class ListViewCheckedItemEnum : IEnumerator
		{
			private readonly ListViewViewModel _ListViewViewModel;

			// Enumerators are positioned before the first element 
			// until the first MoveNext() call. 
			int _position = -1;

			public ListViewCheckedItemEnum(ListViewViewModel ListViewViewModel)
			{
				_ListViewViewModel = ListViewViewModel;
			}

			public bool MoveNext()
			{
				_position++;
				return (_position < _ListViewViewModel.CheckedIndices.Count);
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

			public ListViewItemViewModel Current
			{
				get
				{
					try
					{
						var realIndex = _ListViewViewModel.CheckedIndices[_position];
						if (realIndex < 0 || realIndex >= _ListViewViewModel.ListViewItemViewModels.Count)
							throw new ArgumentOutOfRangeException("");
						return _ListViewViewModel.ListViewItemViewModels[realIndex];
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
