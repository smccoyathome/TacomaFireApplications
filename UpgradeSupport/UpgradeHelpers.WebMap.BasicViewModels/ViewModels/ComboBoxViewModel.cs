using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Server;
using UpgradeHelpers.WebMap.Server.Common;
using System.Reflection;

namespace UpgradeHelpers.BasicViewModels
{
	/// <summary>
	///  View model for the element for ComboBox elements
	/// </summary>
	public class ComboBoxItem : ControlViewModel
	{

		public override void Build(IIocContainer ctx)
		{
			base.Build(ctx);
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

	/// <summary>
	/// ViewModel to represent the state of a ComboBox
	/// </summary>
	public class ComboBoxViewModel : ControlViewModel
	{
		public ComboBoxData InternalData;
		private ComboBoxItemCollection _items;
		

		/// <summary>
		/// Setup the model properties with its default values
		/// </summary>
		public override void Build(IIocContainer container)
		{
			base.Build(container);
			CustomText = "";
			// Enabled DefaultValue
			Enabled = true;

			// Visible DefaultValue
			Visible = true;

			// SelectedIndex DefaultValue
			SelectedIndex = -1;

			_valueMember = string.Empty;
			_displayMember = string.Empty;

			ComboBoxItems = container.Resolve<IList<ComboBoxItem>>();
		}
		public virtual IList<ComboBoxItem> ComboBoxItems { get; set; }

		public ComboBoxItemCollection Items
		{
			get { return _items ?? (_items = new ComboBoxItemCollection(this)); }
		}

		private int _selectedIndex;

		/// <summary>
		///    The index of the selected element
		/// </summary>
		/// 
		public virtual int SelectedIndex
		{
			get
			{
				return _selectedIndex;
			}

			set
			{
				_selectedIndex = value;
				if (ViewManager != null)
					ViewManager.Events.Publish("SELECTEDINDEXCHANGED", this, this, new EventArgs());
			}
		}


		/// <summary>
		///  Text typed in a combobox that accepts typing
		/// </summary>
		//public virtual ComboBoxItem CustomText { get; set; }

		public virtual string CustomText { get; set; }

		public virtual string _displayMember { get; set; }
		/// <summary>
		/// Returns a DisplayMember that will be used in to view that presents this model
		/// </summary>
		[DefaultValue("")]
		[StateManagement(StateManagementValues.None)]
		public virtual string DisplayMember
		{
			get { return _displayMember; }
			set
			{
				_displayMember = value;
				if (DataSource != null)
				{
					PopulateComboFromDataSource(DataSource);
				}
			}
		}

		public virtual string _valueMember { get; set; }
		/// <summary>
		/// Returns a ValueMember that will be used in to view that presents this model
		/// </summary>
		[DefaultValue("")]
		[StateManagement(StateManagementValues.None)]
		public string ValueMember
		{
			get { return _valueMember; }
			set
			{
				_valueMember = value;
				if (DataSource != null)
				{
					PopulateComboFromDataSource(DataSource);
				}
			}
		}

	

		/// <summary>
		/// Gets or sets a value indicating whether the control should resize to avoid showing partial items.
		/// </summary>
		[DefaultValue(true)]
		public virtual bool IntegralHeight { get; set; }



	

		[StateManagement(StateManagementValues.None)]
		public object DropDownStyle { get; set; }

		[StateManagement(StateManagementValues.None)]
		public object AutoCompleteMode { get; set; }

		[StateManagement(StateManagementValues.None)]
		public int SelectionLength { get; set; }

		[StateManagement(StateManagementValues.None)]
		public int SelectionStart { get; set; }


		/// <summary>
		/// Gets the selected item
		/// </summary>
		[StateManagement(StateManagementValues.None)]
		public object SelectedItem
		{
			get
			{
				if (SelectedIndex >= 0)
				{
					var comboBoxItem = ComboBoxItems[SelectedIndex];

					if (comboBoxItem != null)
					{
						return comboBoxItem.Item ?? comboBoxItem.Text;
					}
					return comboBoxItem;
				}
				return null;
			}
			set
			{
				if (value != null)
				{
					bool selectedIndexChanged = false;
					for (int i = 0; i < ComboBoxItems.Count; i++)
					{
						var comboItem = ComboBoxItems[i];

						if (comboItem != null)
						{
							if (comboItem.Item != null)
							{
								if ((comboItem.Item).Equals(value))
								{
									SelectedIndex = i;
									selectedIndexChanged = true;
									break;
								}
							}
							else
							{
								if (comboItem.Value == value || comboItem.Text == (string)value ||
									(string)comboItem.Value == value.ToString())
								{
									SelectedIndex = i;
									selectedIndexChanged = true;
									break;
								}
							}
						}
						else
						{
							if (comboItem != null && comboItem.Equals(value))
							{
								SelectedIndex = i;
								selectedIndexChanged = true;
								break;
							}
						}
					}

					if (!selectedIndexChanged)
					{
						SelectedIndex = 0;
					}
                    else
                    {
                        ViewManager.Events.Publish("SELECTEDVALUECHANGED", this, new object[] { this, new EventArgs() });
                    }
                }
				else
					SelectedIndex = 0;
			}
		}

		/// <summary>
		/// Gets the selected value
		/// </summary>
		[StateManagement(StateManagementValues.None)]
		public virtual object SelectedValue
		{
			get
			{
				if (SelectedIndex >= 0)
				{
					if (ComboBoxItems[SelectedIndex] != null)
						return ComboBoxItems[SelectedIndex].Value;
				}
				return null;
			}
			set
			{
				if (value != null)
				{
					for (int itemIndex = 0; itemIndex < ComboBoxItems.Count; itemIndex++)
					{
						if (ComboBoxItems[itemIndex].Value.Equals(value))
						{
							SelectedIndex = itemIndex;
                            ViewManager.Events.Publish("SELECTEDVALUECHANGED", this, new object[] { this, new EventArgs() });
                            break;
						}
					}
				}
			}
		}

		/// <summary>
		/// Gets or sets the text associated with this model
		/// </summary>
		[StateManagement(StateManagementValues.None)]
		public override string Text
		{
			get
			{
				if (SelectedIndex >= 0 && ComboBoxItems.Count > 0)
				{
					var comboBoxItem = ComboBoxItems[SelectedIndex];

					if (comboBoxItem != null)
					{
						return comboBoxItem.Text;
					}
				}
				return CustomText;
			}
			set
			{
				if (value == null) throw new ArgumentNullException("value");
				for (var i = 0; i < Items.Count; i++)
				{
					if (ComboBoxItems[i].Text.Equals(value))
					{
						SelectedIndex = i;
						return;
					}
				}
				CustomText = value;
			}
		}

		[Reference]
		[StateManagement(StateManagementValues.None)]
		public object DataSource
		{
			get { return InternalData != null ? InternalData.DataSource : null; }
			set
            {
                Type dataSourceType = value.GetType();

                if (dataSourceType.IsGenericType && (dataSourceType.GetGenericArguments()[0] == (typeof(List<ComboBoxItem>)).GenericTypeArguments[0]))
                {
                    IList<UpgradeHelpers.BasicViewModels.ComboBoxItem> list1 = StaticContainer.Instance.Resolve<IList<UpgradeHelpers.BasicViewModels.ComboBoxItem>>();
                    list1 = value as IList<UpgradeHelpers.BasicViewModels.ComboBoxItem>;
                    foreach (Object item in list1)
                    {
                        string text = item.GetPropertyValue(this.DisplayMember).ToString();
                        string val = item.GetPropertyValue(this.ValueMember).ToString();
                        if (text != null && val != null)
                        {
                            ComboBoxItem aux = StaticContainer.Instance.Resolve<ComboBoxItem>();
                            aux.Text = text;
                            aux.Value = val;

                            this.ComboBoxItems.Add(aux);
                        }
                    }
                }
                else if (dataSourceType.IsGenericType)
                {
                    var listEnum = (IEnumerable)value;
                    var list = listEnum.Cast<object>().ToList();

                    foreach (var item in list)
                    {
                        string text = (item.GetPropertyValue(this.DisplayMember) != null) ? item.GetPropertyValue(this.DisplayMember).ToString() : null;
                        string val = (item.GetPropertyValue(this.ValueMember) != null) ? item.GetPropertyValue(this.ValueMember).ToString() : null;

                        ComboBoxItem aux = StaticContainer.Instance.Resolve<ComboBoxItem>();

                        if (text != null && val != null)
                        {
                            aux.Text = text;
                            aux.Value = val;
                        }
                        else if (item.GetType().GetProperty(this.DisplayMember, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) != null && this.ValueMember == "")
                        {
                            aux.Text = (string)item.GetType().GetProperty(this.DisplayMember, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).GetValue(item);

                            if (item.GetType().GetProperty("ID", BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) != null)
                                aux.Value = item.GetType().GetProperty("ID", BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).GetValue(item);
                            else
                                aux.Value = item;
                        }
                        else
                        {
                            aux.Text = item.ToString();
                            aux.Value = item.ToString();
                        }
                        this.ComboBoxItems.Add(aux);
                    }
                }
                else if (dataSourceType == typeof(UpgradeHelpers.BasicViewModels.ComboBoxItem[])) //done
                {
                    ComboBoxItem[] auxList = value as ComboBoxItem[];

                    foreach (ComboBoxItem item in auxList)
                    {
                        string text = item.GetPropertyValue(this.DisplayMember).ToString();
                        string val = item.GetPropertyValue(this.ValueMember).ToString();
                        if (text != null && val != null)
                        {
                            ComboBoxItem aux = StaticContainer.Instance.Resolve<ComboBoxItem>();
                            aux.Text = text;
                            aux.Value = val;

                            this.ComboBoxItems.Add(aux);
                        }
                    }
                }
                else if (dataSourceType == typeof(DataTable)) //done
                {
                    PopulateComboFromDataSource(value as DataTable);
                }
                else if (dataSourceType == typeof(DataView)) //done
                {
                    PopulateComboFromDataSource((value as DataView).ToTable());
                }

                //Binded comboboxes select the first item by default
                if (this.ComboBoxItems.Count > 0)
                {
                    this.SelectedIndex = 0;
                }

                //
                if (InternalData == null)
                    InternalData = new ComboBoxData();
                InternalData.DataSource = value;
            }
		}

		private void PopulateComboFromDataSource(object value)
		{
			ComboBoxItems = StaticContainer.Instance.Resolve<IList<ComboBoxItem>>();
			foreach (DataRow r in ((DataTable)value).Rows)
			{
				if (!string.IsNullOrEmpty(ValueMember))
				{
					var displayValue = DisplayMember ?? ValueMember;
					var item = StaticContainer.Instance.Resolve<ComboBoxItem>();
					item.Text = r[displayValue].ToString();
					item.Value = r[ValueMember];
					item.Item = r[displayValue].ToString();
					ComboBoxItems.Add(item);
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

		/// <summary>
		///  Creates an inner element for the given object
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public ComboBoxItem CreateItem(object item)
		{
			var newItem = StaticContainer.Instance.Resolve<ComboBoxItem>();

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

		public ComboBoxItem FindByValue(object dataValue)
		{
			for (var i = 0; i < ComboBoxItems.Count; i++)
			{
				if (ComboBoxItems[i].Value.Equals(dataValue))
					return ComboBoxItems[i];
			}
			return null;
		}

		/// <summary>
		/// Adds a new element to the combo
		/// </summary>
		/// <param name="item">item to add</param>
		/// <param name="index">position to adding</param>
		public int AddItem(object item, int index = -1)
		{
			var newItem = CreateItem(item);
			if (index == -1 || index == ComboBoxItems.Count)
			{
				ComboBoxItems.Add(newItem);
				return ComboBoxItems.Count - 1;
			}
			ComboBoxItems.Insert(index, newItem);
			return index;
		}

		/// <summary>
		///  Removes an element from the ComboBox
		/// </summary>
		/// <param name="itemIndex"></param>
		public void RemoveItem(int itemIndex)
		{
			ComboBoxItems.RemoveAt(itemIndex);
		}

		/// <summary>
		///   Returns the value at the specified index
		/// </summary>
		/// <param name="index">index of th requested element</param>
		/// <returns>the value of the requested element</returns>
		public string GetListItem(int index)
		{
			string result = "";
			if (index >= 0 && index < ComboBoxItems.Count)
			{
				result = ComboBoxItems[index].Text;
			}
			return result;
		}

		/// <summary>
		///  Sets the text of a combo box element
		/// </summary>
		/// <param name="index"></param>
		/// <param name="value"></param>
		public void SetListItem(int index, string value)
		{
			ComboBoxItems[index].Text = value;
		}

		/// <summary>
		/// Sets the ItemData of the combo
		/// </summary>
		/// <param name="itemData">The new ItemData for the elements of the collection</param>
		public void SetItemData(int[] itemData)
		{
			for (var i = 0; i < itemData.Length; i++)
			{
				if (i < ComboBoxItems.Count)
					ComboBoxItems[i].Data = itemData[i];
			}
		}

		/// <summary>
		/// Sets the ItemData of a specific item
		/// </summary>
		/// <param name="index">The index of the item which ItemData will be set</param>
		/// <param name="value">The value of the ItemData to set</param>
		public void SetItemData(int index, int value)
		{
			if (ComboBoxItems.Count > 0 && ComboBoxItems.Count > index)
			{
				ComboBoxItems[index].Data = value;
			}
		}

		/// <summary>
		/// Gets the ItemData of the combo
		/// </summary>
		/// <returns>The ItemData of the elements of the collection</returns>
		public int[] GetItemData()
		{
			var items = new int[ComboBoxItems.Count];
			for (var i = 0; i < ComboBoxItems.Count; i++)
			{
				var data = ComboBoxItems[i].Data;
				items[i] = data.HasValue ? data.Value : -1;
			}
			return items;
		}

		/// <summary>
		/// Gets the ItemData of a specific item
		/// </summary>
		/// <param name="index">The index of the item which ItemData will be returned</param>
		/// <returns>Return the ItemData of the item in the "index" position</returns>
		public int GetItemData(int index)
		{
            if (ComboBoxItems.Count > 0 && ComboBoxItems.Count > index)
			{
				var itemData = ComboBoxItems[index].Data;
				return itemData.HasValue ? itemData.Value : 0;
			}
			return 0;
		}

        public int? GetNullableItemData(int index)
        {
            if (index == -1)
                return null;
            if (ComboBoxItems.Count > 0 && ComboBoxItems.Count > index)
            {
                var itemData = ComboBoxItems[index].Data;
                return itemData.HasValue ? itemData.Value : 0;
            }
            return 0;
        }

        /// <summary>
        /// Gets the index of the last added element
        /// </summary>
        /// <returns>The index of the last added element</returns>
        public int GetNewIndex()
		{
			return ComboBoxItems.Count - 1;
		}

		/// <summary>
		/// Returns the index of the first item 
		/// in the combobox that starts with the specified string
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public int FindString(string s)
		{
			if (ComboBoxItems != null && ComboBoxItems.Count > 0)
			{
				var item = ComboBoxItems.FirstOrDefault(x => x.Text.Equals(s));
				if (item == null) return -1;
				return ComboBoxItems.IndexOf(item);
			}
			return -1;
		}

		public class ComboBoxData : IInternalData
		{
			public IList Data = new ArrayList();

			public object DataSource;
		}

		[JsonObject]
		public class ComboBoxItemCollection : IEnumerable
		{
			private readonly ComboBoxViewModel _comboBoxViewModel;

			public ComboBoxItemCollection(ComboBoxViewModel comboBoxViewModel)
			{
				_comboBoxViewModel = comboBoxViewModel;
			}

			public void Add(object item)
			{
				_comboBoxViewModel.AddItem(item);
			}

			public void AddRange(object[] items)
			{
				foreach (var item in items)
				{
					_comboBoxViewModel.AddItem(item);
				}
			}

			public void Clear()
			{
				_comboBoxViewModel.ComboBoxItems.Clear();
			}

			public bool Contains(object value)
			{
				var comboBoxItem = value is ComboBoxItem ? value as ComboBoxItem : _comboBoxViewModel.FindByValue(value);
				return _comboBoxViewModel.ComboBoxItems.Contains(comboBoxItem);
			}

			public int Count
			{
				get { return _comboBoxViewModel.ComboBoxItems.Count; }
			}

			public int IndexOf(object value)
			{
				var comboBoxItem = value is ComboBoxItem ? value as ComboBoxItem : _comboBoxViewModel.FindByValue(value);
				return _comboBoxViewModel.ComboBoxItems.IndexOf(comboBoxItem);
			}

			public void Insert(int index, object item)
			{
				_comboBoxViewModel.AddItem(item, index);
			}

			public void Remove(object value)
			{
				var comboBoxItem = value is ComboBoxItem ? value as ComboBoxItem : _comboBoxViewModel.FindByValue(value);
				_comboBoxViewModel.ComboBoxItems.Remove(comboBoxItem);
			}

			public void RemoveAt(int index)
			{
				_comboBoxViewModel.ComboBoxItems.RemoveAt(index);
			}

			public object this[int index]
			{
				get { return _comboBoxViewModel.ComboBoxItems[index].Item ?? _comboBoxViewModel.ComboBoxItems[index].Text; }
				set { _comboBoxViewModel.ComboBoxItems[index].Text = value.ToString(); }
			}

			public IEnumerator GetEnumerator()
			{
				return _comboBoxViewModel.ComboBoxItems.GetEnumerator();
			}

		}

        [StateManagement(StateManagementValues.Both)]
        public override bool AllowDrop
        {
            get
            {
                return base.AllowDrop;
            }

            set
            {
                base.AllowDrop = value;
            }
        }

    }

    public static class ComboBoxExtensions
    {
        public static object GetPropertyValue(this object obj, string propertyName)
        {
            if (obj == null || string.IsNullOrEmpty(propertyName))
            {
                return null;
            }
            else
            {
                PropertyInfo property = null;

                try
                {
                    property = obj.GetType().GetProperty(propertyName);
                }
                catch { }

                if (property == null)
                {
                    return null;
                }
                else
                {
                    return property.GetValue(obj, null);
                }
            }
        }
    }
}
