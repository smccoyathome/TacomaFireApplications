using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace UpgradeHelpers
{
    /// <summary>
    /// Class used to manage the Alignment properties of the columns of a grid.
    /// </summary>
    public class ColAlignmentProperty
    {
        internal DataGridViewCommon parent;
        /// <summary>
        /// Creates a ColumnAlignmentProperty class for a specified grid.
        /// </summary>
        /// <param name="parent">The grid for which to create this class.</param>
        public ColAlignmentProperty(DataGridViewCommon parent)
        {
            this.parent = parent;
        }
        /// <summary>
        /// Gets/sets the Alignment property for a specified column.
        /// </summary>
        /// <param name="index">The index of the column.</param>
        /// <returns>The Alignment property of the selected column.</returns>
        public DataGridViewContentAlignment this[int index]
        {
            get
            {
                if (index == 0)
                {
                    if (parent.RowHeadersVisible)
                    {
                        return parent.RowHeadersDefaultCellStyle.Alignment;
                    }
                }
                int realindex = parent.RowHeadersVisible ? index - 1 : index;
                DataGridViewColumn column = parent.Columns[realindex];
                return column.DefaultCellStyle.Alignment;

            }
            set
            {
                if (index == 0)
                {
                    if (parent.RowHeadersVisible)
                    {
                        parent.RowHeadersDefaultCellStyle.Alignment = value;
                        return;
                    }
                }
                int realindex = parent.RowHeadersVisible ? index - 1 : index;
                DataGridViewColumn column = parent.Columns[realindex];
                if (column.CellTemplate.Style == parent.DefaultCellStyle)
                {
                    DataGridViewCellStyle style = new DataGridViewCellStyle(column.CellTemplate.Style);
                    style.Alignment = value;
                    column.CellTemplate.Style = style;
                    column.DefaultCellStyle = style;
                    if (column.HeaderCell.HasStyle)
                    {
                        if (column.HeaderCell.Style.Alignment == DataGridViewContentAlignment.NotSet)
                        {
                            column.HeaderCell.Style.Alignment = value;
                        }
                    }
                    else
                    {
                        column.HeaderCell.Style.Alignment = value;
                    }

                    foreach (DataGridViewRow row in parent.Rows)
                    {
                        if (row.Cells[realindex].Style == parent.DefaultCellStyle)
                        {
                            row.Cells[realindex].Style = style;
                        }
                        else
                        {
                            row.Cells[realindex].Style.Alignment = value;
                        }
                    }
                }
                else
                {
                    column.CellTemplate.Style.Alignment = value;
                    column.DefaultCellStyle.Alignment = value;
                    if (column.HeaderCell.HasStyle)
                    {
                        if (column.HeaderCell.Style.Alignment == DataGridViewContentAlignment.NotSet)
                        {
                            column.HeaderCell.Style.Alignment = value;
                        }
                    }
                    else
                    {
                        column.HeaderCell.Style.Alignment = value;
                    }

                }
            }
        }
    }
}
