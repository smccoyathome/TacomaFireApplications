using System;
using System.Collections.Generic;
using System.Text;

namespace UpgradeHelpers
{

    /// <summary>
    /// This class manages the Column Data of a specified grid.
    /// </summary>
    public class ColDataProperty
    {
        /// <summary>
        /// Parent control.
        /// </summary>
        public DataGridViewCommon parent;
        /// <summary>
        /// Creates a ColDataProperty class for a specified grid.
        /// </summary>
        /// <param name="parent">The grid for which this class should be created.</param>
        public ColDataProperty(DataGridViewCommon parent)
        {
            this.parent = parent;
        }
        /// <summary>
        /// Gets/sets the Column Data property for the specified column.
        /// </summary>
        /// <param name="index">The index of the column.</param>
        /// <returns>The column data of the selected column.</returns>
        public int this[int index]
        {
            get
            {
                if (index == 0)
                {
                    if (parent.RowHeadersVisible)
                        return parent.RowHeadersTag != null ? (int)parent.RowHeadersTag : 0;
                }
                int realindex = parent.RowHeadersVisible ? index - 1 : index;
                return parent.Columns[realindex].Tag != null ? (int)parent.Columns[realindex].Tag : 0;
            }
            set
            {
                if (index == 0)
                {
                    if (parent.RowHeadersVisible)
                    {
                        parent.RowHeadersTag = value;
                        return;
                    }
                }
                int realindex = parent.RowHeadersVisible ? index - 1 : index;
                parent.Columns[realindex].Tag = value;
            }
        }
    }
}
