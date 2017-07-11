using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeHelpers.Events
{

    /// <summary>
    ///     Defines an event handler for BeforeColUpdate events.  This class is provided for compilation purposes only,
    ///     because mouse events are not server propagated to server side, instead they are
    ///     converted to client side events (such as JavaScript)
    /// </summary>
    public delegate void BeforeColUpdateEventHandler(object sender, BeforeColUpdateEventArgs e);
    //Event args class for TrueDBGrid BeforeColUpdate event handlers.This class is provided for compilation purposes only,
    ///     because the events are not server propagated to server side, instead they are
    ///     converted to client side events (such as JavaScript)
    public class BeforeColUpdateEventArgs : EventArgs
    {
        public BeforeColUpdateEventArgs(bool cancel, int colIndex, object column, object oldValue)
        {
            this.Cancel = cancel;
            this.ColIndex = colIndex;
            this.Column = column;
            this.OldValue = oldValue;
        }

        public bool Cancel { get; set; }
        public int ColIndex { get; set; }
        public object Column { get; set; }
        public object OldValue { get; set; }

    }
}
