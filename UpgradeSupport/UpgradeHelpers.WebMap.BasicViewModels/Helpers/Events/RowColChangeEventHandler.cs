using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeHelpers.Events;

namespace UpgradeHelpers.WebMap.Core.Events
{
	/// <summary>
	///     Defines an event handler for TrueDBGrid RowColEvent events.  This class is provided for compilation purposes only,
	///     because mouse events are not server propagated to server side, instead they are
	///     converted to client side events (such as JavaScript)
	/// </summary>
	public delegate void RowColChangeEventHandler(object sender, RowColChangeEventArgs e);
}
