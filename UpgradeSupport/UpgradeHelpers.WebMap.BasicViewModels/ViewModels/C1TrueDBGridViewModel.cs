using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UpgradeHelpers.BasicViewModels.Interfaces;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Events;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Server.Common;
using CancelEventArgs = UpgradeHelpers.Events.CancelEventArgs;

namespace UpgradeHelpers.BasicViewModels
{
	public enum MultiSelectEnum
	{
		Extended,
		None,
		Simple,
	}

	public enum LineStyleEnum
	{
		Double,
		Inset,
		None,
		Raised,
		Single
	}

	public enum PresentationEnum
	{
		CheckBox,//   Values are displayed as a checkbox.
		ComboBox,//    Values are displayed as a dropdown combobox.
		Normal,//  Values are displayed as text or graphics.
		RadioButton,// Values are displayed as a group of Radio Buttons.
		SortedComboBox // Values are displayed as a dropdown combobox in sorted order.

	}

	public enum MarqueeEnum
	{
		HighlightRow,
		HighlightCell,
		NoMarquee
	}

	#region elementClasses

	public class GridLinesViewModel : IDependentViewModel
	{
		public string UniqueID { get; set; }
		public void Build(IIocContainer ctx)
		{
			Style = new LineStyleEnum();
		}
		public virtual Color Color { get; set; }

		public virtual LineStyleEnum Style { get; set; }
	}

	public class C1DisplayColumn : IDependentViewModel
	{
		public string UniqueID { get; set; }
		public void Build(IIocContainer ctx)
		{
			Visible = true;
			Name = "";
			Locked = false;
		}
		/// <summary>
		/// Gets or sets a value indicating the visibility of a column.  
		/// </summary>
		public virtual bool Visible { get; set; }

		public virtual Style FooterStyle { get; set; }

		/// <summary>
		/// Gets the caption of the associated C1DataColumn objects.
		/// </summary>
		public virtual string Name { get; set; }

		public virtual int Width { get; set; }

		public virtual bool Locked { get; set; }


	}
	/// <summary>
	/// The DisplayColumns collection
	/// </summary>
	public class C1DisplayColumnsCollectionViewModel : IDependentViewModel, IEnumerable
	{
		private readonly C1TrueDBGridViewModel trueDbGridViewModel;

		public string UniqueID { get; set; }

		[JsonProperty("@k")]
		public int k = 1;

		public virtual IList<C1DisplayColumn> _items { get; set; }

		[StateManagement(StateManagementValues.None)]
		public IList<C1DisplayColumn> Items { get { return _items; } }

		public void Build(IIocContainer ctx)
		{
			_items = ctx.Resolve<IList<C1DisplayColumn>>();
		}

		public void Add(C1DisplayColumn displayColumn)
		{
			Items.Add(displayColumn);
		}

		public C1DisplayColumn this[int index]
		{
			get { return this.Items[index]; }
			set { this.Items[index] = value; }
		}
		public C1DisplayColumn this[string name]
		{
			get { return Items.FirstOrDefault(c => c.Name.Equals(name)); }
			set
			{
				var collectionIndex = GetDisplayColumnIndex(name);
				if (collectionIndex > -1)
				{
					Items[collectionIndex] = value;
				}
			}
		}

		public int GetDisplayColumnIndex(string columnName)
		{
			var index = -1;
			foreach (var column in Items)
			{
				if (column.Name.Equals(columnName)) break;
				index++;
			}
			return index;
		}

		public void Clear()
		{
			this.Items.Clear();
		}


		public IEnumerator GetEnumerator()
		{
			return Items.GetEnumerator();
		}
	}



	public class C1SplitViewModel : IDependentViewModel
	{
		public string UniqueID { get; set; }
		public virtual bool AllowColMove { get; set; }
		public virtual bool AlternatingRowStyle { get; set; }
		public virtual MarqueeEnum MarqueeStyle { get; set; }
		public virtual bool ExtendRightColumn { get; set; }

		public void Build(IIocContainer ctx)
		{
			DisplayColumns = ctx.Resolve<C1DisplayColumnsCollectionViewModel>();
		}
		public virtual C1DisplayColumnsCollectionViewModel DisplayColumns { get; set; }

	}

	public class C1DataColumnViewModel : IDependentViewModel, IInitializable<string, Type>
	{
		public string UniqueID { get; set; }
		public virtual string Name { get; set; }
		/// <summary>
		///Gets or sets the text in the column header. 
		/// </summary>
		public virtual string Caption { get; set; }
		/// <summary>
		/// Gets or sets the default value for a column when a new row is added by the grid.
		/// </summary>
		public virtual string DefaultValue { get; set; }
		/// <summary>
		/// Gets or sets the type of object stored for a column.
		/// </summary>
		public virtual Type DataType { get; set; }
		/// <summary>
		/// Gets or sets the database field name for a column.
		/// </summary>
		public virtual string DataField { get; set; }
		/// <summary>
		/// Gets or sets the formatting string for a column.
		/// </summary>
		public virtual string NumberFormat { get; set; }
		/// <summary>
		/// Gets or sets the maximum number of characters which may be entered for cells in this column.
		/// </summary>
		public virtual int DataWidth { get; set; }
		/// <summary>
		/// Gets or sets the FooterText value
		/// </summary>
		public virtual string FooterText { get; set; }
		public virtual object Tag { get; set; }
		public virtual int Width { get; set; }
		public virtual string Text { get; set; }
		[StateManagement(StateManagementValues.ServerOnly)]
		public virtual string Value
		{
			get { return Text; }
			set { Text = value; }
		}

		public void Build(IIocContainer ctx)
		{
			Name = "";
			NumberFormat = "";
			Width = 65;
			Caption = "";
			ValueItems = new ValueItems();
		}

		public virtual ValueItems ValueItems { get; set; }

		/// <summary>
		/// Initializes a new C1DataColumn object
		/// </summary>
		/// <param name="caption">The Caption property value</param>
		/// <param name="dataType">The dataType value</param>
		public void Init(string caption, Type dataType)
		{
			this.Caption = caption;
			this.DataType = dataType;
		}

		public void Init()
		{
			//Do Nothing
		}


	}

	public class ValueItems
	{
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors", Justification = "This method is already in production and it cannot be changed without breaking changes")]
        public ValueItems()
		{
			Presentation = PresentationEnum.Normal;
		}

		public virtual PresentationEnum Presentation { get; set; }
	}

	/// <summary>
	/// The Columns Collection ViewModel
	/// </summary>
	public class C1DataColumnsViewModel
	{
		private C1TrueDBGridViewModel _viewModel;

		internal C1DataColumnsViewModel(C1TrueDBGridViewModel viewModel)
		{
			_viewModel = viewModel;
		}

		public IList<C1DataColumnViewModel> Items { get { return _viewModel.Columns; } }
		public int Count
		{
			get { return Items.Count; }
		}

		public void Add(C1DataColumnViewModel column)
		{
			this.Items.Add(column);
			var displayColumn = StaticContainer.Instance.Resolve<C1DisplayColumn>();
			displayColumn.Name = column.Caption;
			_viewModel.Splits[0].DisplayColumns.Add(displayColumn);
		}

		public void Add(string caption)
		{
			var col = StaticContainer.Instance.Resolve<C1DataColumnViewModel>();
			col.Caption = caption;
			col.Name = caption;
			col.Text = caption;
			this.Add(col);
		}


		//Gets or sets the value on an specific datagrid cell
		[StateManagement(StateManagementValues.None)]
		public C1DataColumnViewModel this[int columnIndex]
		{
			get
			{
				if (columnIndex < Items.Count)
				{
					return Items[columnIndex];
				}
				return null;
			}

			set
			{
				if (columnIndex < Items.Count)
				{
					var columnValue = value as C1DataColumnViewModel;
					if (columnValue != null)
					{
						Items[columnIndex] = columnValue;
					}
					else
					{
						Items[columnIndex].Text = value.ToString();
					}
				}
			}
		}

		[StateManagement(StateManagementValues.None)]
		public C1DataColumnViewModel this[string columnName]
		{
			get
			{
				return Items.FirstOrDefault(column => column.Name.Equals(columnName));
			}
			set
			{
				var index = GetColumnIndex(columnName);
				this.Items[index] = value;
			}
		}

		public int GetColumnIndex(string columnName)
		{
			var index = -1;
			foreach (var column in Items)
			{
				if (column.Name.Equals(columnName)) break;
				index++;
			}
			return index;
		}

		public void Clear()
		{
			Items.Clear();
		}

		public void Remove(C1DataColumnViewModel column)
		{
			Items.Remove(column);
		}

		public void RemoveAt(int index)
		{
			Items.RemoveAt(index);
		}
	}

	/// <summary>
	/// The Rows collection view model
	/// </summary>
	public class C1DataRowsViewModel : IDependentViewModel, IEnumerable
	{
		public string UniqueID { get; set; }

		[JsonProperty("@k")]
		public int k = 1;

		public virtual IList<C1RowViewModel> _items { get; set; }

		[StateManagement(StateManagementValues.None)]
		public IList<C1RowViewModel> Items { get { return _items; } }

		public void Build(IIocContainer ctx)
		{
			_items = ctx.Resolve<IList<C1RowViewModel>>();
		}

		public C1RowViewModel this[int rowIndex]
		{
			get { return this.Items[rowIndex]; }
			set { this.Items[rowIndex] = value; }
		}
		public void Clear()
		{
			this.Items.Clear();
		}

		public IEnumerator GetEnumerator()
		{
			return Items.GetEnumerator();
		}
	}

	#endregion
	public class C1TrueDBGridViewModel : ControlViewModel, IDataGrid
	{
		private const string BeforeColUpdateEvent = "BeforeColUpdate";
		private const string BeforeUpdateEvent = "BeforeUpdate";
		private const string AfterUpdateEvent = "AfterUpdate";
		private const string AfterColUpdateEvent = "AfterColUpdate";
		private const string BeforeDeleteEvent = "BeforeDelete";
		public virtual C1DataRowsViewModel _rows { get; set; }


		/// <summary>
		///  Control initalization
		/// </summary>
		/// <param name="ctx"></param>
		public override void Build(IIocContainer ctx)
		{
			base.Build(ctx);
			AllowUpdate = true;
			AllowDelete = true;
			Visible = true;
			Enabled = true;
			Columns = ctx.Resolve<IList<C1DataColumnViewModel>>();
			_rows = ctx.Resolve<C1DataRowsViewModel>();
			SelectedIndices = new[] { -1 };
			RowDivider = ctx.Resolve<GridLinesViewModel>();
			DataSourceVersion = false;
			InitializeDefaultSplits();
			SelectedStyle = ctx.Resolve<Style>();
			Style = ctx.Resolve<Style>();
		}
		/// <summary>
		/// Contains the set of current grid columns
		/// </summary>
		public virtual C1DataColumnsViewModel GridColumns
		{
			get { return new C1DataColumnsViewModel(this); }
		}
		public virtual IList<C1DataColumnViewModel> Columns { get; set; }

		public virtual string PropBag { get; set; }
		/// <summary>
		/// Gets or sets a value indicating the ability of a user to modify data.  
		/// </summary>
		public virtual bool AllowUpdate { get; set; }

		public virtual bool AllowDelete { get; set; }

		public virtual MultiSelectEnum MultiSelect { get; set; }


		public virtual IList<C1SplitViewModel> Splits { get; set; }

		/// <summary>
		/// This property is used to create a FetchRowStyleEventArgs Instance
		/// Gets or Sets the selected ColumnIndex 
		/// </summary>
		public virtual int ColumnIndex { get; set; }

		/// <summary>
		/// Creates a new EventArguments for evente raised from the client
		/// </summary>
		[StateManagement(StateManagementValues.ServerOnly)]
		public FetchRowStyleEventArgs FetchRowStyleEventArgs
		{
			get
			{
				var row = 0;
				if (SelectedIndices != null)
				{
					row = SelectedIndices.FirstOrDefault();
				}
				return new FetchRowStyleEventArgs(null, row, 0, ColumnIndex);
			}

		}

		/// <summary>
		/// The DisplayColumns collection
		/// </summary>
		public class C1DisplayColumnsCollectionViewModel
		{
			private readonly C1TrueDBGridViewModel trueDbGridViewModel;

			public C1DisplayColumnsCollectionViewModel(C1TrueDBGridViewModel gridViewModel)
			{
				trueDbGridViewModel = gridViewModel;
			}
			public string UniqueID { get; set; }

			[JsonProperty("@k")]
			public int k = 1;

			public virtual IList<C1DisplayColumn> _items { get; set; }

			[StateManagement(StateManagementValues.None)]
			public IList<C1DisplayColumn> Items { get { return _items; } }

			public void Build(IIocContainer ctx)
			{
				_items = ctx.Resolve<IList<C1DisplayColumn>>();
			}

			public void Add(C1DisplayColumn displayColumn)
			{
				Items.Add(displayColumn);
			}

			public C1DisplayColumn this[int index]
			{
				get { return this.Items[index]; }
				set { this.Items[index] = value; }
			}
			public C1DisplayColumn this[string name]
			{
				get { return Items.FirstOrDefault(c => c.Name.Equals(name)); }
				set
				{
					var collectionIndex = GetDisplayColumnIndex(name);
					if (collectionIndex > -1)
					{
						Items[collectionIndex] = value;
					}
				}
			}

			public int GetDisplayColumnIndex(string columnName)
			{
				var index = -1;
				foreach (var column in Items)
				{
					if (column.Name.Equals(columnName)) break;
					index++;
				}
				return index;
			}

			public void Clear()
			{
				this.Items.Clear();
			}



		}
		[StateManagement(StateManagementValues.None)]
		public C1DataRowsViewModel Rows
		{
			get
			{
				if (DataSource != null)
				{
					throw new InvalidOperationException("Not supported when the grid is bound");
				}
				return _rows ?? (_rows = StaticContainer.Instance.Resolve<C1DataRowsViewModel>());
			}
		}
		/// <summary>
		/// Gets or sets the current row
		/// </summary>
		[StateManagement(StateManagementValues.None)]
		public int Row
		{
			get
			{
				if (SelectedIndices.Any())
				{
					return SelectedIndices.FirstOrDefault();
				}
				else
					return -1;
			}
			set
			{
				if (value >= 0 && value <= Rows.Items.Count - 1)
				{
					SelectedIndices = new[] { value };
				}
			}
		}

		public virtual GridLinesViewModel RowDivider { get; set; }

		public virtual Style SelectedStyle { get; set; }

		public virtual Style Style { get; set; }

		[StateManagement(StateManagementValues.None)]
		public virtual SelectedRowCollection SelectedRows
		{
			get
			{
				return new SelectedRowCollection(this);
			}
		}


		public int RowCount()
		{
			if (DataSource != null)
			{
				return ((ADORecordSetHelper)DataSource).Tables[0].DefaultView.Count;
			}
			return this.Rows.Items.Count;
		}

		public IEnumerable<IGridRow> GetRows(int skip, int take)
		{


			if (this._dataSource != null)
			{
				var dsRows = StaticContainer.Instance.Resolve<IList<C1RowViewModel>>();
				var current = skip;
				var rowsCount = this._dataSource.Tables[0].DefaultView.Count;
				for (var i = 0; i < take; i++)
				{
					if (i < rowsCount && current < rowsCount)
					{
						var dataRowView = this._dataSource.Tables[0].DefaultView[current];
						var dr = StaticContainer.Instance.Resolve<C1RowViewModel>();
						if (HoldFields)
						{
							var index = 0;
							foreach (var col in Columns)
							{
								object data = string.Empty;
								if (!string.IsNullOrEmpty(col.DataField))
								{
									data = dataRowView.Row[col.DataField] ?? string.Empty;
								}
								dr.SetColumnValue(index, data.ToString());
								index++;
							}
						}
						else
						{
							dr.ItemContent = dataRowView.Row.ItemArray;
						}
						dr.RecordSetIndex = current;
						dsRows.Add(dr);
					}
					else
					{
						break;
					}
					current++;
				}
				return dsRows;
			}
			return StaticContainer.Instance.Resolve<IList<C1RowViewModel>>();

		}
		[Reference]
		[StateManagement(StateManagementValues.ServerOnly)]
		public virtual ADORecordSetHelper _dataSource { get; set; }
		public virtual bool DataSourceVersion { get; set; }

		[StateManagement(StateManagementValues.None)]
		public virtual object DataSource
		{
			get { return _dataSource; }
			set
			{
				_dataSource = value as ADORecordSetHelper;
				if (_dataSource == null && value != null)
				{
					throw new ArgumentException("Data Source type not supported");
				}
				DataSourceVersion = true;
				if (!HoldFields && _dataSource != null && _dataSource.Tables.Count > 0)
				{
					GridColumns.Clear();
					foreach (var column in _dataSource.Tables[0].Columns)
					{
						GridColumns.Add(column.ToString());
					}
				}
			}
		}
		/// <summary>
		/// Stores the selected rows
		/// </summary>
		public virtual int[] SelectedIndices { get; set; }

		#region Methods

		public int AddRow(string data)
		{
			return AddRow(data, ';');
		}
		/// <summary>
		/// Adds a Row to an unbound grid.
		/// </summary>
		/// <param name="data">The data used to populate the new row</param>
		/// <param name="separator">Charater used to separate the data fields</param>
		/// <returns></returns>
		public int AddRow(string data, char separator)
		{
			var elements = data.Split(separator);
			var newRow = StaticContainer.Instance.Resolve<C1RowViewModel>();
			newRow.trueDbGridViewModel = this;
			var columnIndex = 0;
			foreach (var element in elements)
			{
				newRow.SetColumnValue(columnIndex, element);
				columnIndex++;
			}
			newRow.Resize(Columns.Count);
			this.Rows.Items.Add(newRow);
			return Rows.Items.Count - 1;
		}
		/// <summary>
		/// Adds the number of given rows to an unbound grid.
		/// </summary>
		/// <param name="count">the number of rows to add</param>
		/// <returns></returns>
		public int AddRows(int count)
		{
			if (count > 0)
			{
				var currentRowsCount = Rows.Items.Count;
				for (int i = 0; i < count; i++)
				{
					var newRow = StaticContainer.Instance.Resolve<C1RowViewModel>();
					newRow.trueDbGridViewModel = this;
					newRow.Resize(Columns.Count);
					this.Rows.Items.Add(newRow);
				}
				return currentRowsCount + 1;
			}
			return 0;
		}

		private void InitializeDefaultSplits()
		{
			Splits = StaticContainer.Instance.Resolve<IList<C1SplitViewModel>>();
			var split = StaticContainer.Instance.Resolve<C1SplitViewModel>();
			Splits.Add(split);
		}
		[Reference]
		[StateManagement(StateManagementValues.ServerOnly)]
		public virtual ADORecordSetHelper RecordSet { get; set; }

		/// <summary>
		/// True to preserve design time layout
		/// </summary>
		public virtual bool HoldFields { get; set; }

		/// <summary>
		/// Binds the grid at run time. 
		/// </summary>
		/// <param name="datasource">Source of the data. </param>
		/// <param name="dataMember">The table to bind to within the object returned by the DataSource property. </param>
		/// <param name="holdFields">True to preserve design time layout. </param>
		public void SetDataBinding(object datasource, string dataMember, bool holdFields)
		{
			if (Columns.Count > 0)
				this.HoldFields = holdFields;
			else
			{
				HoldFields = false;
			}
			ADORecordSetHelper rs = datasource as ADORecordSetHelper;
			RecordSet = rs;
			this.DataSource = rs;
		}

		public void Rebind(bool value)
		{
		}

		public void RefetchRow(int rows)
		{
		}

		public void UpdateData()
		{
		}

		public bool Get_CausesValidation()
		{
			return CausesValidation;
		}

		#endregion


		internal C1RowViewModel FindByValue(object item)
		{
			return Rows.Items.FirstOrDefault(t => t.ItemContent[0].Equals(item));
		}

		internal C1RowViewModel FindByKey(object value)
		{
			try
			{
				return
					Rows.Items.FirstOrDefault(
						t => t.Name != null && t.Name.Equals(value.ToString(), StringComparison.CurrentCultureIgnoreCase));
			}
			catch (NullReferenceException)
			{
				return null;
			}

		}

		[StateManagement(StateManagementValues.None)]
		public int Bookmark
		{
			get { return SelectedIndices.FirstOrDefault(); }
		}


		/// <summary>
		/// Used by the GridDataSourceController to update a record after an edit event
		/// </summary>
		/// <param name="recordSetIndex"></param>
		/// <param name="itemContent"></param>
		/// <param name="columnIndex"></param>
		/// <param name="value"></param>
		public void UpdateRecord(int recordSetIndex, int columnIndex, string value)
		{
			if (ViewManager != null && _dataSource != null)
			{
				//Trigger before edition events
				ViewManager.Events.Publish(BeforeColUpdateEvent, this, this, new BeforeColUpdateEventArgs(false, 0, null, null));
				ViewManager.Events.Publish(BeforeUpdateEvent, this, this, new CancelEventArgs(false));
				if (HoldFields)
				{
					foreach (var col in Columns)
					{
						if (!string.IsNullOrEmpty(col.DataField))
						{
							if (!string.IsNullOrEmpty(col.DataField))
								this._dataSource.Tables[0].DefaultView[recordSetIndex].Row[col.DataField] = value;
						}
					}
				}
				else
					this._dataSource.Tables[0].DefaultView[recordSetIndex].Row.ItemArray[columnIndex] = value;
				//Trigger after edition events
				ViewManager.Events.Publish(AfterColUpdateEvent, this, this, FetchRowStyleEventArgs);
				ViewManager.Events.Publish(AfterUpdateEvent, this, this, new EventArgs());
			}
		}


		public void RemoveRecord(int rowIndex)
		{
			if (ViewManager != null)
			{
				ViewManager.Events.Publish(BeforeDeleteEvent, this, this, new CancelEventArgs(false));
				this._dataSource.Tables[0].DefaultView.Delete(rowIndex);
				DataSourceVersion = true;
			}
		}
	}

	[JsonObject]
	public class SelectedRowCollection : IDependentModel
	{
		private readonly C1TrueDBGridViewModel trueDbGridViewModel;

		public SelectedRowCollection(C1TrueDBGridViewModel gridViewModel)
		{
			trueDbGridViewModel = gridViewModel;

		}
		public IList<C1RowViewModel> Items { get; set; }

		public void Add(object item)
		{
			var gridItem = item is C1RowViewModel ? item as C1RowViewModel : trueDbGridViewModel.FindByValue(item);
			var index = trueDbGridViewModel.Rows.Items.IndexOf(gridItem);
			if (index != -1)
				Array.IndexOf(trueDbGridViewModel.SelectedIndices, index);

		}

		public void Clear()
		{
			trueDbGridViewModel.SelectedIndices = new[] { -1 };
		}

		public bool Contains(object item)
		{
			var gridItem = item is C1RowViewModel ? item as C1RowViewModel : trueDbGridViewModel.FindByValue(item);
			var index = trueDbGridViewModel.Rows.Items.IndexOf(gridItem);
			return trueDbGridViewModel.SelectedIndices.Contains(index);
		}

		public bool ContainsKey(object item)
		{
			var gridItem = item is C1RowViewModel ? item as C1RowViewModel : trueDbGridViewModel.FindByValue(item);
			var index = trueDbGridViewModel.Rows.Items.IndexOf(gridItem);
			return trueDbGridViewModel.SelectedIndices.Contains(index);
		}

		public int Count
		{
			get { return trueDbGridViewModel.SelectedIndices.Length; }
		}

		public int IndexOf(object item)
		{
			var gridItem = item is C1RowViewModel ? item as C1RowViewModel : trueDbGridViewModel.FindByValue(item);
			var index = trueDbGridViewModel.Rows.Items.IndexOf(gridItem);
			return Array.IndexOf(trueDbGridViewModel.SelectedIndices, index);
		}

		public int IndexOfKey(object item)
		{
			var gridItem = item is C1RowViewModel ? item as C1RowViewModel : trueDbGridViewModel.FindByKey(item);
			var index = trueDbGridViewModel.Rows.Items.IndexOf(gridItem);
			return Array.IndexOf(trueDbGridViewModel.SelectedIndices, index);
		}

		public void Remove(object item)
		{
			var gridItem = item is C1RowViewModel ? item as C1RowViewModel : trueDbGridViewModel.FindByValue(item);
			var index = trueDbGridViewModel.Rows.Items.IndexOf(gridItem);
			var tmpList = trueDbGridViewModel.SelectedIndices.ToList();
			tmpList.Remove(index);
			trueDbGridViewModel.SelectedIndices = tmpList.ToArray();
		}

		public int this[int index]
		{
			get
			{
				var realIndex = trueDbGridViewModel.SelectedIndices[index];
				if (realIndex < 0 || realIndex >= trueDbGridViewModel.RowCount())
					throw new ArgumentOutOfRangeException("");
				else
					return realIndex;
			}
			set { throw new NotImplementedException(); }
		}

		public IEnumerator GetEnumerator()
		{
			return (IEnumerator)new SelectedRowCollectionEnum(trueDbGridViewModel);
		}

		private class SelectedRowCollectionEnum : IEnumerator
		{
			private readonly C1TrueDBGridViewModel _C1TrueDBGridViewModel;

			// Enumerators are positioned before the first element 
			// until the first MoveNext() call. 
			int _position = -1;

			public SelectedRowCollectionEnum(C1TrueDBGridViewModel C1TrueDBGridViewModel)
			{
				_C1TrueDBGridViewModel = C1TrueDBGridViewModel;
			}

			public bool MoveNext()
			{
				_position++;
				return (_position < _C1TrueDBGridViewModel.SelectedIndices.Length);
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

			public C1RowViewModel Current
			{
				get
				{
					try
					{
						var realIndex = _C1TrueDBGridViewModel.SelectedIndices[_position];
						if (realIndex < 0 || realIndex >= _C1TrueDBGridViewModel.Rows.Items.Count)
							throw new ArgumentOutOfRangeException("");
						return _C1TrueDBGridViewModel.Rows.Items[realIndex];
					}
					catch (IndexOutOfRangeException)
					{
						throw new InvalidOperationException();
					}
				}
			}
		}

		public string UniqueID { get; set; }
	}

	public class C1RowViewModel : DataGridRowViewModel
	{
		[StateManagement(StateManagementValues.ServerOnly)]
		public virtual C1TrueDBGridViewModel trueDbGridViewModel { get; set; }

		public virtual int RecordSetIndex { get; set; }

		public string this[int columnIndex]
		{
			get
			{
				if (ItemContent.Length > columnIndex)
					return ItemContent[columnIndex].ToString();
				return string.Empty;
			}
			set
			{
				if (ItemContent.Length > columnIndex)
					ItemContent[columnIndex] = value;
			}
		}

		public string this[string columnValue]
		{
			get { return this[trueDbGridViewModel.GridColumns.GetColumnIndex(columnValue)]; }
			set
			{
				var index = trueDbGridViewModel.GridColumns.GetColumnIndex(columnValue);
				this[index] = value;
			}
		}

	}
}
