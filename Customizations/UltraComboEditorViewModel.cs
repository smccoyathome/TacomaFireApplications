//-----------------------------------------------------------------------
// <copyright file="UltraComboEditorViewModel.cs" company="Mobilize.net">
//
//  MOBILIZE CONFIDENTIAL
// _______________________________________________________________________
//
//  Mobilize Company
//  All Rights Reserved.
//  
//  NOTICE: All helper classes are provided for customers use only;
//  all other use is prohibited without prior written consent from Mobilize.Net.
//  no warranty express or implied;
//  use at own risk.
// </copyright>
//-----------------------------------------------------------------------
namespace Custom.ViewModels
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using Newtonsoft.Json;
    using UpgradeHelpers.BasicViewModels;
    using UpgradeHelpers.Helpers;
    using UpgradeHelpers.Interfaces;
    using UpgradeHelpers.WebMap.Server;

    /// <summary>
    /// ViewModel to represent the state of a ComboBox
    /// </summary>
    public class UltraComboEditorViewModel : ControlViewModel
    {
        /// <summary>
        /// object used to save the original dataSource
        /// </summary>
        private ComboBoxData internalData;

        /// <summary>
        /// Used to save items for the UltraComboEditor. Items will be display in the UltraComboEditor
        /// </summary>
        private ComboBoxItemCollection items;

        /// <summary>
        /// Use to keep private selectedIndex from the UltraComboEditor.
        /// </summary>
        private int selectedIndex;

        public virtual IList<ValueListItem> ComboBoxItems { get; set; }

        /// <summary>
        /// Gets the items of the ultraComboEditor, 
        /// if it is null, return a new instance of <see cref="ComboBoxItemCollection"/>
        /// </summary>
        public ComboBoxItemCollection Items
        {
            get
            {
                return this.items ?? (this.items = new ComboBoxItemCollection(this));
            }
        }

        /// <summary>
        /// Gets or sets the index of the selected element
        /// </summary>
        [DefaultValue(-1)]
        public virtual int SelectedIndex
        {
            get
            {
                return this.selectedIndex;
            }

            set
            {
                this.selectedIndex = value;
                if (this.ViewManager != null)
                {
                    this.ViewManager.Events.Publish("SELECTEDINDEXCHANGED", this, this, new EventArgs());
                }
            }
        }

        /// <summary>
        ///  Gets or sets text typed in a comboBox that accepts typing
        /// </summary>
        public virtual string CustomText { get; set; }
		
        public virtual string _displayMember { get; set; }

        /// <summary>
        /// Gets or sets a DisplayMember that will be used in to view that presents this model
        /// </summary>
        [DefaultValue("")]

        [StateManagement(StateManagementValues.None)]
        public virtual string DisplayMember
        {
            get
            {
                return this._displayMember;
            }

            set
            {
                this._displayMember = value;
                if (this.DataSource != null)
                {
                    this.PopulateComboFromDataSource(this.DataSource);
                }
            }
        }

        public virtual string _valueMember { get; set; }

        /// <summary>
        /// Gets or sets a ValueMember that will be used in to view that presents this model
        /// </summary>
        [DefaultValue("")]

        [StateManagement(StateManagementValues.None)]
        public string ValueMember
        {
            get
            {
                return this._valueMember;
            }

            set
            {
                this._valueMember = value;
                if (this.DataSource != null)
                {
                    this.PopulateComboFromDataSource(this.DataSource);
                }
            }
        }

        /// <summary>
        /// Gets or sets a style to display the comboBoxEditor.
        /// </summary>
        [DefaultValue(DropDownStyleViewModel.DropDown)]
        public virtual DropDownStyleViewModel DropDownStyle { get; set; }

        /// <summary>
        /// Gets or sets the selected item
        /// </summary>
        [StateManagement(StateManagementValues.None)]
        public ValueListItem SelectedItem
        {
            get
            {
                if (this.SelectedIndex >= 0)
                {
                    var valueListItem = this.ComboBoxItems[this.SelectedIndex];
                    return valueListItem;
                }

                return null;
            }

            set
            {
                if (value != null)
                {
                    bool selectedIndexChanged = false;
                    for (int i = 0; i < this.ComboBoxItems.Count; i++)
                    {
                        var comboItem = this.ComboBoxItems[i];

                        if (comboItem != null)
                        {
                            if (comboItem.Item != null)
                            {
                                if (comboItem.Item.Equals(value))
                                {
                                    this.SelectedIndex = i;
                                    selectedIndexChanged = true;
                                    break;
                                }
                            }
                            else
                            {
                                if (comboItem.Value == value || comboItem.Text == value.Text ||
                                    (string)comboItem.Value == value.ToString())
                                {
                                    this.SelectedIndex = i;
                                    selectedIndexChanged = true;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (comboItem != null && comboItem.Equals(value))
                            {
                                this.SelectedIndex = i;
                                selectedIndexChanged = true;
                                break;
                            }
                        }
                    }

                    if (!selectedIndexChanged)
                    {
                        this.SelectedIndex = -1;
                    }
                }
                else
                {
                    this.SelectedIndex = -1;
                }
            }
        }

        /// <summary>
        /// Gets or sets the selected value
        /// </summary>
        [StateManagement(StateManagementValues.None)]
        public virtual object SelectedValue
        {
            get
            {
                if (this.SelectedIndex >= 0)
                {
                    if (this.ComboBoxItems[this.SelectedIndex] != null)
                    {
                        return this.ComboBoxItems[this.SelectedIndex].Value;
                    }
                }

                return null;
            }

            set
            {
                if (value != null)
                {
                    for (int itemIndex = 0; itemIndex < this.ComboBoxItems.Count; itemIndex++)
                    {
                        if (this.ComboBoxItems[itemIndex].Value.Equals(value))
                        {
                            this.SelectedIndex = itemIndex;
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
                if (this.SelectedIndex >= 0 && this.ComboBoxItems.Count > 0)
                {
                    var valueListItem = this.ComboBoxItems[this.SelectedIndex];

                    if (valueListItem != null)
                    {
                        return valueListItem.Text;
                    }
                }

                return this.CustomText;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }

                for (var i = 0; i < this.Items.Count; i++)
                {
                    if (this.ComboBoxItems[i].Text.Equals(value))
                    {
                        this.SelectedIndex = i;
                        return;
                    }
                }

                this.CustomText = value;
            }
        }

        [Reference]

        [StateManagement(StateManagementValues.None)]
        public object DataSource
        {
            get
            {
                return this.InternalData != null ? this.InternalData.DataSource : null;
            }

            set
            {
                if (value != null)
                {
                    this.PopulateComboFromDataSource(value);
                }

                if (this.InternalData == null)
                {
                    this.InternalData = new ComboBoxData();
                }

                this.InternalData.DataSource = value;
            }
        }

        public ComboBoxData InternalData
        {
            get
            {
                return this.internalData;
            }

            set
            {
                this.internalData = value;
            }
        }

        /// <summary>
        ///  Setup the model properties with its default values
        /// </summary>
        /// <param name="container">It has the info types to resolve them with the current context</param>
        public override void Build(IIocContainer container)
        {
			base.Build(container);
            // Name defaultValue
            this.Name = string.Empty;

            this.CustomText = string.Empty;

            // Enabled DefaultValue
            this.Enabled = true;

            // Visible DefaultValue
            this.Visible = true;

            // SelectedIndex DefaultValue
            this.SelectedIndex = -1;

            // DropdownStyle DefaultValue
            this.DropDownStyle = DropDownStyleViewModel.DropDown;

            this._valueMember = string.Empty;
            this._displayMember = string.Empty;

            this.ComboBoxItems = container.Resolve<IList<ValueListItem>>();
        }

        /// <summary>
        ///  Creates an inner element for the given object
        /// </summary>
        /// <param name="item">An object with data</param>
        /// <returns>returns a valueList created with parameter data</returns>
        public ValueListItem CreateItem(object item)
        {
            var newItem = this.Container.Resolve<ValueListItem>();

            if (!(item is string))
            {
                newItem.Item = item;
                if (!string.IsNullOrEmpty(this.DisplayMember) && !string.IsNullOrEmpty(this.ValueMember))
                {
                    newItem.Text = this.GetMemberValue(item, this.DisplayMember).ToString();
                    newItem.Value = this.GetMemberValue(item, this.ValueMember);
                }
                else
                {
                    if (!string.IsNullOrEmpty(this.DisplayMember) || !string.IsNullOrEmpty(this.ValueMember))
                    {
                        var property = string.IsNullOrEmpty(this.DisplayMember) ? this.ValueMember : this.DisplayMember;
                        newItem.Value = this.GetMemberValue(item, property);
                        newItem.Text = newItem.Value.ToString();
                    }

                    var tempItem = item as ValueListItemViewModel;
                    if (tempItem != null)
                    {
                        if (tempItem.DisplayText != null)
                        {
                            newItem.DisplayText = tempItem.DisplayText;
                        }

                        if (tempItem.DataValue != null)
                        {
                            newItem.DataValue = tempItem.DataValue;
                        }
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

        public ValueListItem FindByValue(object dataValue)
        {
            for (var i = 0; i < this.ComboBoxItems.Count; i++)
            {
                if (this.ComboBoxItems[i].Value.Equals(dataValue))
                {
                    return this.ComboBoxItems[i];
                }
            }

            return null;
        }

        /// <summary>
        /// Adds a new element to the combo
        /// </summary>
        /// <param name="item">item to add</param>
        /// <param name="index">position to adding</param>
        /// <returns>return the new index of the list</returns>
        public int AddItem(object item, int index = -1)
        {
            var newItem = this.CreateItem(item);
            if (index == -1 || index == this.ComboBoxItems.Count)
            {
                this.ComboBoxItems.Add(newItem);
                return this.ComboBoxItems.Count - 1;
            }

            this.ComboBoxItems.Insert(index, newItem);
            return index;
        }

        /// <summary>
        ///  Removes an element from the ComboBox
        /// </summary>
        /// <param name="itemIndex">index in the array</param>
        public void RemoveItem(int itemIndex)
        {
            this.ComboBoxItems.RemoveAt(itemIndex);
        }

        /// <summary>
        ///   Returns the value at the specified index
        /// </summary>
        /// <param name="index">index of the requested element</param>
        /// <returns>the value of the requested element</returns>
        public string GetListItem(int index)
        {
            string result = string.Empty;
            if (index >= 0 && index < this.ComboBoxItems.Count)
            {
                result = this.ComboBoxItems[index].Text;
            }

            return result;
        }

        /// <summary>
        ///  Sets the text of a combo box element
        /// </summary>
        /// <param name="index">index in the collection</param>
        /// <param name="value">new value</param>
        public void SetListItem(int index, string value)
        {
            this.ComboBoxItems[index].Text = value;
        }

        /// <summary>
        /// Sets the ItemData of the combo
        /// </summary>
        /// <param name="itemData">The new ItemData for the elements of the collection</param>
        public void SetItemData(int[] itemData)
        {
            for (var i = 0; i < itemData.Length; i++)
            {
                if (i < this.ComboBoxItems.Count)
                {
                    this.ComboBoxItems[i].Data = itemData[i];
                }
            }
        }

        /// <summary>
        /// Sets the ItemData of a specific item
        /// </summary>
        /// <param name="index">The index of the item which ItemData will be set</param>
        /// <param name="value">The value of the ItemData to set</param>
        public void SetItemData(int index, int value)
        {
            if (this.ComboBoxItems.Count > 0 && this.ComboBoxItems.Count > index)
            {
                this.ComboBoxItems[index].Data = value;
            }
        }

        /// <summary>
        /// Gets the ItemData of the combo
        /// </summary>
        /// <returns>The ItemData of the elements of the collection</returns>
        public int[] GetItemData()
        {
            var items = new int[this.ComboBoxItems.Count];
            for (var i = 0; i < this.ComboBoxItems.Count; i++)
            {
                var data = this.ComboBoxItems[i].Data;
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
            if (this.ComboBoxItems.Count > 0 && this.ComboBoxItems.Count > index)
            {
                var itemData = this.ComboBoxItems[index].Data;
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
            return this.ComboBoxItems.Count - 1;
        }

        private object GetMemberValue(object item, string member)
        {
            if (string.IsNullOrEmpty(member))
            {
                return item.ToString();
            }

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
        /// Use to create a DataSource from the parameter
        /// </summary>
        /// <param name="value">original dataSource to be transform</param>
        private void PopulateComboFromDataSource(object value)
        {
            this.ComboBoxItems = this.Container.Resolve<IList<ValueListItem>>();
            foreach (DataRow r in ((DataTable)value).Rows)
            {
                if (!string.IsNullOrEmpty(this.ValueMember))
                {
                    var displayValue = this.ValueMember;
                    if (!string.IsNullOrEmpty(this.DisplayMember))
                    {
                        displayValue = this.DisplayMember;
                    }

                    var item = this.Container.Resolve<ValueListItem>();
                    item.Text = r[displayValue].ToString();
                    item.Value = r[this.ValueMember];
                    item.Item = r[displayValue].ToString();
                    this.ComboBoxItems.Add(item);
                }
            }
        }

        public class ComboBoxData : IInternalData
        {
            private IList data = new ArrayList();
            private object dataSource;

            public IList Data
            {
                get
                {
                    return this.data;
                }

                set
                {
                    this.data = value;
                }
            }

            public object DataSource
            {
                get
                {
                    return this.dataSource;
                }

                set
                {
                    this.dataSource = value;
                }
            }
        }

        [JsonObject]
        public class ComboBoxItemCollection : IEnumerable
        {
            private readonly UltraComboEditorViewModel comboEditorViewModel;

            public ComboBoxItemCollection(UltraComboEditorViewModel comboEditorViewModel)
            {
                this.comboEditorViewModel = comboEditorViewModel;
            }

            public int Count
            {
                get { return this.comboEditorViewModel.ComboBoxItems.Count; }
            }

            public object this[int index]
            {
                get { return this.comboEditorViewModel.ComboBoxItems[index].Item ?? this.comboEditorViewModel.ComboBoxItems[index].Text; }
                set { this.comboEditorViewModel.ComboBoxItems[index].Text = value.ToString(); }
            }

            public void Add(object item)
            {
                this.comboEditorViewModel.AddItem(item);
            }

            public void AddRange(object[] items)
            {
                foreach (var item in items)
                {
                    this.comboEditorViewModel.AddItem(item);
                }
            }

            public void Clear()
            {
                this.comboEditorViewModel.ComboBoxItems.Clear();
            }

            public bool Contains(object value)
            {
                var valueListItem = value is ValueListItem ? value as ValueListItem : this.comboEditorViewModel.FindByValue(value);
                return this.comboEditorViewModel.ComboBoxItems.Contains(valueListItem);
            }

            public int IndexOf(object value)
            {
                var valueListItem = value is ValueListItem ? value as ValueListItem : this.comboEditorViewModel.FindByValue(value);
                return this.comboEditorViewModel.ComboBoxItems.IndexOf(valueListItem);
            }

            public void Insert(int index, object item)
            {
                this.comboEditorViewModel.AddItem(item, index);
            }

            public void Remove(object value)
            {
                var valueListItem = value is ValueListItem ? value as ValueListItem : this.comboEditorViewModel.FindByValue(value);
                this.comboEditorViewModel.ComboBoxItems.Remove(valueListItem);
            }

            public void RemoveAt(int index)
            {
                this.comboEditorViewModel.ComboBoxItems.RemoveAt(index);
            }

            public IEnumerator GetEnumerator()
            {
                return this.comboEditorViewModel.ComboBoxItems.GetEnumerator();
            }
        }
    }

    public class ValueListItem : ComboBoxItem, IInitializable<object>, IInitializable<object, string>
    {
        /// <summary>
        /// Override 'ToString' method for return the right property.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (this.DisplayText != null)
            {
                return this.DisplayText.ToString();
            }
            else if (this.DataValue != null)
            {
                return this.DataValue.ToString();
            }
            else if (this.Data != null)
            {
                return this.Data.ToString();
            }
            return base.ToString();
        }

        [StateManagement(StateManagementValues.ServerOnly)]
        public object DataValue
        {
            get
            {
                return this.Value;
            }

            set
            {
                this.Value = value;
                if (string.IsNullOrEmpty(this.Text))
                {
                    this.Text = value.ToString();
                }
            }
        }

        public string DisplayText
        {
            get
            {
                return this.Text;
            }

            set
            {
                this.Text = value;
            }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                base.Text = value;
                if (string.IsNullOrEmpty(base.Text) && this.Value != null)
                {
                    this.Text = this.Value.ToString();
                }
            }
        }

        public void Init()
        {
        }

        public void Init(object datavalue)
        {
            this.Value = datavalue;
        }

        public void Init(object datavalue, string displayString)
        {
            this.Value = datavalue;
            this.Text = displayString;
        }

        public object Get_ListObject()
        {
            throw new NotImplementedException("This is an automatic generated code, please implement the requested logic.");
        }

    }
}
