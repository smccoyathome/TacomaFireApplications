using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace UpgradeHelpers
{
    /// <summary>
    /// Enumeration class used to access the indexed FixedAlignment property.
    /// </summary>
    public class FixedAlignmentProperty
    {
        internal DataGridViewCommon parent;
        /// <summary>
        /// Creates a FixedAlignmentProperty class for a specified grid.
        /// </summary>
        /// <param name="parent">The grid for which to create the class.</param>
        public FixedAlignmentProperty(DataGridViewCommon parent)
        {
            this.parent = parent;
        }
        /// <summary>
        /// Obtains the FixedAlignment property for the specified column.
        /// </summary>
        /// <param name="index">The index of the column.</param>
        /// <returns>The Fixed Alignment of the column.</returns>
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
                if (column.Frozen)
                    return column.DefaultCellStyle.Alignment;
                else
                    return DataGridViewContentAlignment.NotSet;
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
                DataGridViewContentAlignment align = value;
                align = align == DataGridViewContentAlignment.NotSet ? DataGridViewContentAlignment.MiddleLeft : align;
                DataGridViewColumn column = parent.Columns[realindex];
                if (column.Frozen)
                    column.DefaultCellStyle.Alignment = align;
                else
                    column.HeaderCell.Style.Alignment = align;
            }
        }
    }
}
