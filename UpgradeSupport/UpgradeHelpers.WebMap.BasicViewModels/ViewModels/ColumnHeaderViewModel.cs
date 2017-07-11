using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.BasicViewModels
{
	public class ColumnHeaderViewModel : IDependentViewModel
	{
		/// <summary>
		///  Object unique id 
		/// </summary>
		public string UniqueID { get; set; }

		/// <summary>
		///  Name of this column
		/// </summary>
		public virtual string Name { get; set; }

		/// <summary>
		///  Text to display as the header of this column
		/// </summary>
		public virtual string Text { get; set; }

		/// <summary>
		///  Text to display as the header of this column
		/// </summary>
		public virtual string field
		{
			get { return Text; }
			set { Text = value; }
		}
		/// <summary>
		/// Gets or sets Index value for this element.
		/// </summary>
		public virtual int Index { get; set; }

		/// <summary>
		/// Gets or sets IsSelected value for this element.
		/// </summary>
		public virtual bool IsSelected { get; set; }

		/// <summary>
		///   Tag related to this column
		/// </summary>

		public virtual object Tag { get; set; }

		/// <summary>
		///  The width of the column in pixels
		/// </summary>
		[DefaultValue(0)]
		public virtual int Width { get; set; }

		/// <summary>
		///  Alignment for the text in this column
		/// </summary>
		public virtual Helpers.HorizontalAlignment HorizontalAlignment { get; set; }
		/// <summary>
		/// Gets or sets the name of the data source property or database column to which the DataGridViewColumn is bounds
		/// </summary>
		public virtual string DataPropertyName { get; set; }
		/// <summary>
		/// Gets or sets a value indicating whether the user can edit the column's cells.
		/// </summary>
		public virtual bool ReadOnly { get; set; }
		/// <summary>
		/// Gets or sets a value indicating whether the column is resizable.
		/// </summary>
		public virtual DataGridViewTriState Resizable { get; set; }
		/// <summary>
		/// Gets or sets a value indicating whether the control and all its child controls are displayed.
		/// </summary>
		public virtual bool Visible { get; set; }
		/// <summary>
		/// Gets or sets a value indicating whether a column will move when a user scrolls the DataGridView control horizontally.
		/// </summary>
		public virtual bool Frozen { get; set; }

		/// <summary>
		///  Column initialization
		/// </summary>
		/// <param name="ctx"></param>
		public void Build(IIocContainer ctx)
		{
			Name = "";
			Tag = "";
			Width = 100;
			ReadOnly = false;
			Resizable = DataGridViewTriState.NotSet;
			HorizontalAlignment = Helpers.HorizontalAlignment.Left;
		}
	}

}
