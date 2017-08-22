// *************************************************************************************
// <copyright company="Mobilize" file="UltraGrid.cs" >
//      Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
//      All helper classes are provided for customer use only;
//      all other use is prohibited without prior written consent from Mobilize.Net.
//      no warranty express or implied;
//      use at own risk.
// </copyright>
// <summary></summary>
// *************************************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;
using System.Reflection;
using Custom.ViewModels.Grid.Event;
using Newtonsoft.Json;

namespace Custom.ViewModels.Grid
{
	public class UltraGridBase : ControlViewModel
	{
		public override void Build(IIocContainer ctx)
		{
			base.Build(ctx);
            Rows = ctx.Resolve<RowsCollection>(this);
            Bands = ctx.Resolve<IList<UltraGridBand>>();
            Columns = ctx.Resolve<ColumnsCollection>(this.Bands);
			PageSize = 25; //Set this as default in the widget definition.
            DisplayLayout = ctx.Resolve<UltraGridLayout>(Rows.Grid);
		}
        /// <summary>
		/// Gets or sets the bands.
		/// </summary>
		/// <value>The bands.</value>
		[JsonProperty]
        public virtual IList<UltraGridBand> Bands { get; set; }

		#region DataSource definition

		/// <summary>
		/// Gets or sets the data source.
		/// </summary>
		/// <value>The data source.</value>
		[StateManagement(StateManagementValues.None)]
		public object DataSource
		{
			get
			{
				return _dataSource;
			}
			set
			{
				_dataSource = value;
				if (_dataSource == null) return;
				NeedRefresh = true;
				if (AvoidSelectColumns) return;
				ClearDataSource();
				SetColumns();
			}
		}




		[Reference]
		[StateManagement(StateManagementValues.ServerOnly)]
		public virtual object _dataSource { get; set; }

		public virtual bool NeedRefresh { get; set; }

		[StateManagement(StateManagementValues.None)]
		public int DataSourceCount
		{
			get
			{
				if (DataSource is IList)
				{
					return ((IList)DataSource).Count;
				}
				if (DataSource is DataTable)
				{
					return ((DataTable)DataSource).Rows.Count;
				}
				return 0;
			}
		}

		/// <summary>
		/// the Data bind.
		/// </summary>
		public void DataBind()
		{
			this.ClearDataSource();
			DataSource = _dataSource;

			this.ViewManager.Events.Publish(
				Events.InitializeLayout,
				this,
				new InitializeLayoutEventArgs(this.DisplayLayout));
		}

		/// <summary>
		/// Clear the columns collection when the datasource is 
		/// initialized.
		/// </summary>
		public void ClearDataSource()
		{
            Columns = Container.Resolve<ColumnsCollection>(this.Bands);
		}

		#endregion

		#region Columns definition

		/// <summary>
		/// Flag that indicates if SetColumns must be applied
		/// </summary>
		public virtual bool AvoidSelectColumns { get; set; }

		private void SetColumns()
		{
			if (DataSource is CollectionBase)
			{
				var collection = (CollectionBase)DataSource;
				SetColumns(collection);
			}
			else if (DataSource is IList)
			{
				var list = (IList)DataSource;
				SetColumns(list);
			}
			else if (DataSource is DataTable)
			{
				var dataTable = (DataTable)DataSource;
				SetColumns(dataTable);
			}
		}

		private void SetColumns(IList dataSource)
		{
			IList<PropertyInfo> props = null;
			//IList<PropertyInfo> filterProps = null;
			//Get Properties from first element
			if (!dataSource.GetType().IsGenericType) throw new NotSupportedException("Only IList<T> instances are supported");
			var objectType = dataSource.GetType().GetGenericArguments()[0];

			if (objectType == null) return;
			var itemType = objectType;
			var excludedProps = new string[] { "ViewManager", "Container", "UniqueID" };
			//if (objectType.GetCustomAttribute())
			props = new List<PropertyInfo>(itemType.GetProperties(BindingFlags.Public
																  | BindingFlags.Instance).Where(prop => !excludedProps.Contains(prop.Name)));
			//else
			if (this.Columns.Count != 0) return;
			{
				//set columns
				if (props == null) return;
                var band = this.Container.Resolve<UltraGridBand>(this);
				foreach (PropertyInfo prop in props)
				{
					var column = StaticContainer.Instance.Resolve<UltraGridColumn>(this, prop.Name, prop.Name, prop.PropertyType, Columns.Count);
					column.Caption = prop.Name;
					column.Key = prop.Name;
					Columns.Items.Add(column);

				}
                band.Columns = Columns;
                this.Bands.Add(band);
			}
		}

		private void SetColumns(CollectionBase dataSource)
		{
			IList<PropertyInfo> props = null;
			if (dataSource.Count == 0) return;
			var listDataSource = ((IList)dataSource);
			var objectType = listDataSource[0].GetType();
			var itemType = objectType;
            var excludedProps = new string[] { "ViewManager", "Container", "UniqueID", "Dependents" };
			props = new List<PropertyInfo>(itemType.GetProperties(BindingFlags.Public
				| BindingFlags.Instance).Where(prop => !excludedProps.Contains(prop.Name)));
			if (this.Columns.Count != 0) return;
			{
				//set columns
				if (props == null) return;
                var band = this.Container.Resolve<UltraGridBand>(this);
				foreach (PropertyInfo prop in props)
				{
					var column = StaticContainer.Instance.Resolve<UltraGridColumn>(this, prop.Name, prop.Name, prop.PropertyType, Columns.Count);
					column.Caption = prop.Name;
					column.Key = prop.Name;
					Columns.Items.Add(column);

				}
                //this.Columns.Grid = this.Rows.Grid;
                band.Columns = Columns;
                this.Bands.Add(band);
			}
		}

		private void SetColumns(DataTable dataSource)
		{
            var band = this.Container.Resolve<UltraGridBand>(this);
			foreach (System.Data.DataColumn dc in dataSource.Columns)
			{
				var column = StaticContainer.Instance.Resolve<UltraGridColumn>(this, dc.ColumnName, dc.ColumnName, dc.DataType, Columns.Count);
				column.Caption = dc.ColumnName;
				column.Key = dc.ColumnName;
				Columns.Items.Add(column);
			}
            band.Columns = Columns;
            this.Bands.Add(band);
		}
		#endregion


		/// <summary>
		/// Gets or sets the active cell.
		/// </summary>
		/// <value>The active cell.</value>
		public virtual UltraGridCell ActiveCell { get; set; }
		/// <summary>
		/// Gets or sets the active row.
		/// Use the ActiveRow Index to send the selected item to the widget
		/// </summary>
		/// <value>The active row.</value>
		[StateManagement(StateManagementValues.None)]
		public UltraGridRow ActiveRow
		{
			get
			{
				if (ActiveRowIndex != null)
				{
					if (ActiveRowIndex.Length == 3)
					{
						var page = ActiveRowIndex[1] - 1;
						var pageSize = ActiveRowIndex[2];
						var realIndexBase = page * pageSize;
						return Rows[realIndexBase + ActiveRowIndex[0]];
					}
				}
				return default(UltraGridRow);
			}
			set
			{
				var index = Rows.IndexOf(value);
				var pageNumber = index / PageSize;
				var widgetIndex = Math.Abs(pageNumber * PageSize - index);
                ActiveRowIndex = new[] { widgetIndex, pageNumber - 1, PageSize };
            }
		}

		/// <summary>
		/// Gets or sets the current pageSize
		/// </summary>
		public virtual int PageSize { get; set; }

		/// <summary>
		/// This property gets or sets the activeIndex
		/// The expected structure is
		/// [RowIndex, Page, PageSize]
		/// </summary>
		public virtual int[] ActiveRowIndex { get; set; }

		/// <summary>
		///  Returns a collection of the topmost level of rows in the grid.
		/// </summary>
		public virtual RowsCollection Rows { get; set; }
		public virtual ColumnsCollection Columns { get; set; }

		/// <summary>
		/// Return a default UltraGridLayout 
		/// because the appeareance will be managed in a different way
		/// TODO: Review this property assignation to return the expected object
		/// </summary>
		public virtual UltraGridLayout DisplayLayout { get; set; }
		
	}
}
