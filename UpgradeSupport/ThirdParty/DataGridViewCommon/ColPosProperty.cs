using System;
using System.Collections.Generic;
using System.Text;

namespace UpgradeHelpers
{
    /// <summary>
    /// Class used to access the indexed ColPos property.
    /// </summary>
    public class ColPosProperty
    {
        internal DataGridViewCommon parent;
        /// <summary>
        /// Creates a ColPosProperty class for the specified grid.
        /// </summary>
        /// <param name="parent">The grid to use to create the ColPosProperty class.</param>
        public ColPosProperty(DataGridViewCommon parent)
        {
            this.parent = parent;
        }
        /// <summary>
        /// Enumerate the columns of the grid.
        /// </summary>
        /// <param name="index">The index of the column</param>
        /// <returns>The ColPos value for the specified column.</returns>
        public int this[int index]
        {
            get
            {
                if (index == 0)
                    return 0;
                else
                {
                    int result = parent.RowHeadersVisible ? parent.RowHeadersWidth : 0;
                    if (parent.FirstDisplayedCell.ColumnIndex <= index)
                    {
                        for (int i = parent.FirstDisplayedCell.ColumnIndex; i < index - 1; i++)
                        {
                            result += parent.Columns[i].Width;
                        }
                    }
                    else
                    {
                        for (int i = parent.FirstDisplayedCell.ColumnIndex; i > index - 1; i--)
                        {
                            result -= parent.Columns[i - 1].Width;
                        }
                    }
                    return result;
                }
            }

        }

    }
}
