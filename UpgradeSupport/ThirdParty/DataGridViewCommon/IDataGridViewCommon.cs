using System;
using System.Collections.Generic;
using System.Text;

namespace UpgradeHelpers
{
    /// <summary>
    /// DataGrid View Common
    /// </summary>
    public abstract class DataGridViewCommon : System.Windows.Forms.DataGridView
    {
        private object _rowHeaderTag;
        /// <summary>
        /// Row Headers Tag
        /// </summary>
        public object RowHeadersTag
        {
            get
            {
                return _rowHeaderTag;
            }
            set
            {
                _rowHeaderTag = value;
            }
        }
    }
}
