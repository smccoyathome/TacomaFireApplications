// *************************************************************************************
// <copyright company="Mobilize" file="UltraGridRow.cs" >
//      Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
//      All helper classes are provided for customer use only;
//      all other use is prohibited without prior written consent from Mobilize.Net.
//      no warranty express or implied;
//      use at own risk.
// </copyright>
// <summary></summary>
// *************************************************************************************
using System;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace Custom.ViewModels.Grid
{
	/// <summary>
	/// Class UltraGridRow.
	/// </summary>
	public class UltraGridRow : ControlBaseViewModel, IInitializable<RowsCollection>
	{

		/// <summary>
		/// Gets/sets whether the row is selected.
		/// </summary>
		public virtual bool Selected { get; set; }

		public virtual string ToolTipText { get; set; }

		/// <summary>
		/// Gets or sets the index property for this element.
		/// </summary>
		public virtual int Index { get; set; }

		public virtual CellsCollection Cells { get; set; }

		/// <summary>
		/// Reference to Rows collection parent
		/// </summary>
		[Reference]
		[StateManagement(StateManagementValues.ServerOnly)]
		public virtual RowsCollection RowsCollection { get; set; }

		/// <summary>
		/// Returns or sets a value that determines how an object will behave when it is activated.
		/// </summary>
		public Activation Activation { get; set; }

		/// <summary>
		/// Returns or sets the Appearance object that controls the object's formatting.S:\demos\GridCases\GridDemo\MS8\MigratedSolution\resources\GridDemo.FormDataTable.css
		/// </summary>
		public AppearanceViewModel Appearance { get; set; }

		/// <summary>
		/// Determines whether the object will be displayed. This property is not available at design-time.
		/// </summary>
		public virtual bool Hidden { get; set; }

		/// <summary>
		/// Returns the index corresponding to this row from the IList that the control is bound to. 
		/// Return value of -1 indicates that a row has been deleted or doesn't exist anymore.
		/// </summary>
		public int ListIndex { get; set; }

		/// <summary>
		/// Cancels the update.
		/// </summary>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public bool CancelUpdate()
		{
			return false;
		}

		/// <summary>
		/// Expands this instance.
		/// </summary>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public bool Expand()
		{
			return false;
		}

		/// <summary>
		/// Collapses this instance.
		/// </summary>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public bool Collapse()
		{
			return false;
		}

		/// <summary>
		/// Commits the row.
		/// </summary>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public bool CommitRow()
		{
			return false;
		}

		public override void Build(IIocContainer ctx)
		{
			Cells = ctx.Resolve<CellsCollection>();
			ItemContent = new object[1] { "" };
		}
		public object[] ItemContent { get; set; }
		public void SetColumnValue(int column, string value)
		{
			if (ItemContent.Length > column)
			{
				var tmpArray = ItemContent;
				tmpArray[column] = value;
				// Force marking this property as 'dirty'
				ItemContent = null;
				ItemContent = tmpArray;
			}
			else
			{
				object[] tmp = ItemContent;
				string[] newArray = new string[column + 1];
				Array.Copy(tmp, newArray, tmp.Length);
				newArray[column] = value;
				ItemContent = newArray;
			}
		}
		/// <summary>
		/// Creates a new cell with the row Information
		/// </summary>
		/// <param name="column"></param>
		/// <param name="rowIndex"></param>
		/// <param name="value"></param>
		/// <param name="prop"></param>
		/// <param name="isSelected"></param>
		public void SetCellValue(int column, int rowIndex,
			string value, string prop, bool isSelected = false)
		{
			var cell = Container.Resolve<UltraGridCell>(this);
			cell.Key = prop;
			cell.RowIndex = rowIndex;
			cell.Value = value;
			cell.Selected = isSelected;
			Cells.Insert(column, cell);
		}

		public void Init(RowsCollection parent)
		{
			RowsCollection = parent;
		}

		public void Init()
		{

		}
        public virtual Object Tag { get; set; }
        public int VisibleIndex { get; set; }
    }
}