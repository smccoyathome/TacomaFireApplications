using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeHelpers.Events
{
    /// <summary>
    ///     Event args class for TrueDBGrid FetchRowStyle event handlers.  This class is provided for compilation purposes only,
    ///     because the events are not server propagated to server side, instead they are
    ///     converted to client side events (such as JavaScript)
    /// </summary>
    public class FetchRowStyleEventArgs : EventArgs
    {
        public FetchRowStyleEventArgs(object cellStyle, int row, int split, int colIndex)
        {
            CellStyle = cellStyle;
            Row = row;
            Split = split;
            ColIndex = colIndex;
        }

        public object CellStyle { get; set; }
        public int Row { get; set; }
        public int Split { get; set; }
        public int ColIndex { get; set; }
    }
}
