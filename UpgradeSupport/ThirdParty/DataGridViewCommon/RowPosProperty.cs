using System;
using System.Collections.Generic;
using System.Text;

namespace UpgradeHelpers
{
    /// <summary>
    /// Enumeration class used to access the indexed ColPos property.
    /// </summary>
    public class RowPosProperty
    {
        internal DataGridViewCommon parent;
        /// <summary>
        /// Creates a RowPosProperty class for the specified grid.
        /// </summary>
        /// <param name="parent">The grid to use to create the RowPosProperty class.</param>
        public RowPosProperty(DataGridViewCommon parent)
        {
            this.parent = parent;
        }
        /// <summary>
        /// Enumerate the rows of the grid.
        /// </summary>
        /// <param name="index">The index of the rows</param>
        /// <returns>The RowPos value for the specified row.</returns>
        public int this[int index]
        {
            get
            {
                if (index == 0)
                    return 0;
                else
                {
                    int result = parent.ColumnHeadersVisible ? parent.ColumnHeadersHeight : 0;
                    if (parent.FirstDisplayedCell.RowIndex <= index)
                    {
                        for (int i = parent.FirstDisplayedCell.RowIndex; i < index - 1; i++)
                        {
                            result += parent.Rows[i].Height;
                        }
                    }
                    else
                    {
                        for (int i = parent.FirstDisplayedCell.RowIndex; i > index - 1; i--)
                        {
                            result -= parent.Rows[i - 1].Height;
                        }
                    }
                    return result;
                }
            }

        }

    }
}
