#define CODE_ANALYSIS
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Server;




namespace UpgradeHelpers.BasicViewModels
{
	/// <summary>
	/// Represents an item in a ListViewModel item collection
	/// </summary>
	public class ListViewItemViewModel : ControlViewModel, INotifyPropertyChanged, UpgradeHelpers.Interfaces.IInitializable<string[]>, UpgradeHelpers.Interfaces.IInitializable<string>
	{
		public bool _checked;
		private bool _focused;
		private ListViewItemSubItemCollection _subItems;
		/// <summary>
		///  Raw content of the ListView item
		/// </summary>
		public virtual string[] ItemContent { get; set; }

		/// <summary>
		///  Index for th element in the current image list
		/// </summary>
		public virtual int ImageIndex { get; set; }
		/// <summary>
		///  Key for the element in the current image list
		/// </summary>

		public string ImageKey { get; set; }

		/// <summary>
		/// Gets or sets the item index
		/// </summary>
		public virtual int Index { get; set; }

		/// <summary>
		///   ListView Item initialization
		/// </summary>
		/// <param name="ctx"></param>
		public override void Build(IIocContainer ctx)
		{
			base.Build(ctx);
			ItemContent = new string[1];
			ImageIndex = -1;
			Name = "";
			Text = "";
			SubItemsViewModels = new ObservableCollection<ListViewSubItem>();
			SubItems = new ListViewItemSubItemCollection(this);

		}

		/// <summary>
		///   Gets or sets the text for the ListViewItem
		/// </summary>
		[StateManagement(StateManagementValues.None)]
		public override string Text
		{
			get
			{
				try
				{
					return ItemContent[0];

				}
				catch (NullReferenceException)
				{
					return "";
				}
			}
			set
			{
				var tmpArray = ItemContent;
				tmpArray[0] = value;
				// Force marking this property as 'dirty'
				ItemContent = null;
				ItemContent = tmpArray;

			}
		}


		/// <summary>
		///  Gets or sets a flag for the 'Selected' state of this element
		/// </summary>
		public bool Selected
		{
			get;
			set;
		}
		/// <summary>
		///  Gets or sets a flag for the 'Checked' state of the current element
		/// </summary>
		public bool Checked
		{
			get
			{

				return _checked;
			}
			set
			{
				_checked = value;
				RaisePropertyChanged("Checked");
			}
		}

		/// <summary>
		/// Returns the state of the item
		/// </summary>
		/// <returns></returns>
		public bool Get_Focused()
		{
			return Selected;
		}

		/// <summary>
		///   Sets the sub item element for this item
		/// </summary>
		/// <param name="item"></param>
		/// <param name="value"></param>
		public void SetSubItem(int item, string value)
		{
			if (ItemContent.Length > item)
			{
				var tmpArray = ItemContent;
				tmpArray[item] = value;
				// Force marking this property as 'dirty'
				ItemContent = null;
				ItemContent = tmpArray;
			}
			else
			{
				string[] tmp = ItemContent;
				string[] newArray = new string[item + 1];
				Array.Copy(tmp, newArray, tmp.Length);
				newArray[item] = value;
				ItemContent = newArray;
			}

		}

		/// <summary>
		/// Look for an specific subitem
		/// </summary>
		/// <param name="listViewSubItem"></param>
		/// <returns></returns>
		internal bool ContainsSubItem(ListViewSubItem listViewSubItem)
		{
			foreach (ListViewSubItem sub in SubItems)
			{
				if (sub.Text.Equals(listViewSubItem.Text))
				{
					return true;
				}
			}
			return false;
		}


		/// <summary>
		/// Look for an specific subitem
		/// </summary>
		/// <param name="listViewSubItem"></param>
		/// <returns></returns>
		internal bool ContainsSubItemKey(ListViewSubItem listViewSubItem)
		{
			if (listViewSubItem != null)
			{
				foreach (ListViewSubItem sub in SubItems)
				{
					if (sub.Name.Equals(listViewSubItem.Name))
					{
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>
		///  Gets the specified sub item
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public new ListViewSubItem GetSubItem(int index)
		{
			return new ListViewSubItem(this, index);
		}

		/// <summary>
		///  Returns a collection of subitems for this item
		///  
		public virtual ObservableCollection<ListViewSubItem> SubItemsViewModels { get; set; }

		public virtual ListViewItemSubItemCollection SubItems
		{
			get { return _subItems ?? (_subItems = new ListViewItemSubItemCollection(this)); }
			set { _subItems = value; }

		}

		/// <summary>
		/// Remove the item of the control
		/// </summary>
		public void Remove()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Finds an especific subitem by its value
		/// </summary>
		/// <param name="dataValue"></param>
		/// <returns></returns>
		public ListViewSubItem FindByValue(object dataValue)
		{
			foreach (ListViewSubItem sub in SubItems)
			{
				if (sub.Text.Equals(dataValue.ToString()))
				{
					return sub;
				}
			}
			return null;
		}

		/// <summary>
		/// Finds an especific subitem by its key
		/// </summary>
		/// <param name="dataValue"></param>
		/// <returns></returns>
		public ListViewSubItem FindByKey(object dataValue)
		{
			foreach (ListViewSubItem sub in SubItems)
			{
				if (sub.Name.Equals(dataValue.ToString()))
				{
					return sub;
				}
			}
			return null;
		}

		//-- INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		private void RaisePropertyChanged(string prop)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}



		/// <summary>
		/// Add a new SubItem to the ListViewItem
		/// </summary>
		/// <param name="newItem"></param>
		/// <param name="index"></param>
		internal int AddItem(ListViewSubItem newSubItem, int index = -1)
		{

			if (index == -1 || index == SubItems.Count)
			{
				SubItems.Add(newSubItem);
				return SubItems.Count - 1;
			}
			SubItems.Insert(index, newSubItem);
			return index;
		}

		/// <summary>
		/// Removes a subitem
		/// </summary>
		/// <param name="listViewSubItem"></param>
		public void RemoveSubItem(ListViewSubItem listViewSubItem)
		{
			List<string> tmp = new List<string>();
			foreach (string content in ItemContent)
			{
				if (!content.Equals(listViewSubItem.Text))
				{
					tmp.Add(content);
				}
			}
			ItemContent = tmp.ToArray<string>();
		}

		/// <summary>
		/// Removes a Subtiem on index
		/// </summary>
		/// <param name="index"></param>
		internal void RemoveSubItemAt(int index)
		{
			var list = new List<string>(ItemContent);
			list.RemoveAt(index);
			ItemContent = list.ToArray();
		}


		[SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Justification = "ViewModel must implement IInitializable methods explicitly to avoid collitions with client code")]
		void UpgradeHelpers.Interfaces.IInitializable<string[]>.Init(string[] p1)
		{
			foreach (var s in p1)
			{
				SubItems.Add(s);
			}
		}

		[SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Justification = "ViewModel must implement IInitializable methods explicitly to avoid collitions with client code")]
		void UpgradeHelpers.Interfaces.IInitializable<string>.Init(string p1)
		{
			SubItems.Add(p1);
		}

		[SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Justification = "ViewModel must implement IInitializable methods explicitly to avoid collitions with client code")]
		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{

		}

	}


	[JsonObject]
	public class ListViewItemSubItemCollection : IEnumerable
	{
		ListViewItemViewModel _viewModel;

		internal ListViewItemSubItemCollection(ListViewItemViewModel viewModel)
		{
			_viewModel = viewModel;
		}

		public int IndexOf(object item)
		{
			var subitem = item is ListViewSubItem ? item as ListViewSubItem : _viewModel.FindByValue(item);
			if (subitem != null)
				return subitem.subItemIndex;
			else
				return -1;
		}

		public int IndexOfKey(object key)
		{
			var subitem = _viewModel.FindByKey(key);
			if (subitem != null)
				return subitem.subItemIndex;
			else
				return -1;

		}

		public ListViewSubItem Insert(int index, ListViewSubItem item)
		{
			ListViewSubItem newSubItem = new ListViewSubItem(_viewModel, index);
			newSubItem.Text = ((ListViewSubItem)item)._text ?? "";
			return newSubItem;

		}

		public void RemoveAt(int index)
		{
			_viewModel.RemoveSubItemAt(index);

		}

		public ListViewSubItem this[int index]
		{
			get
			{
				return _viewModel.GetSubItem(index);
			}
			set
			{
				_viewModel.SetSubItem(index, value.Text);
			}
		}

		public void Add(string itemText)
		{
			var index = (_viewModel.ItemContent[0] == null || _viewModel.ItemContent[0].Equals("")) ? 0 : _viewModel.ItemContent.Length;
			_viewModel.SetSubItem(index, itemText);
		}

		public ListViewSubItem Add(ListViewSubItem item)
		{
			_viewModel.AddItem(item);
			return _viewModel.SubItemsViewModels.Last<ListViewSubItem>();
		}

		public void Clear()
		{
			_viewModel.SubItemsViewModels.Clear();
		}

		public bool Contains(object item)
		{
			var listViewSubItem = item is ListViewSubItem ? item as ListViewSubItem : _viewModel.FindByValue(item);
			return _viewModel.ContainsSubItem(listViewSubItem);
		}

		public bool ContainsKey(object item)
		{
			var listViewSubItem = item is ListViewSubItem ? item as ListViewSubItem : _viewModel.FindByKey(item);
			return _viewModel.ContainsSubItemKey(listViewSubItem);
		}

		public void CopyTo(ListViewSubItem[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		public int Count
		{
			get
			{
				var count = this._viewModel.SubItemsViewModels.Count;
				if (count <= 0)
					count = _viewModel.ItemContent.Length;
				return count;
			}
		}

		public bool IsReadOnly
		{
			get { return true; }
		}

		public bool Remove(object item)
		{
			var listViewSubItem = item is ListViewSubItem ? item as ListViewSubItem : _viewModel.FindByValue(item);
			if (listViewSubItem != null)
			{
				_viewModel.RemoveSubItem(listViewSubItem);
				return true;
			}
			else
				return false;
		}

		public IEnumerator<ListViewSubItem> GetEnumerator()
		{
			return EnumerateSubItems().GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return EnumerateSubItems().GetEnumerator();
		}

		IEnumerable<ListViewSubItem> EnumerateSubItems()
		{
			for (int i = 0; i < this._viewModel.ItemContent.Length; i++)
			{
				yield return _viewModel.GetSubItem(i);
			}
		}
	}
}
