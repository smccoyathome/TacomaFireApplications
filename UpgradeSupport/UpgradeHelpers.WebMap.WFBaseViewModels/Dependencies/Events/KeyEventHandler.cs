namespace UpgradeHelpers.Events
{
    /// <summary>
    ///     Defines an event handler for key events.  This class is provided for compilation purposes only,
    ///     because key events are not server propagated to server side, instead they are
    ///     converted to client side events (such as JavaScript)
    /// </summary>
    public delegate void KeyEventHandler(object sender, KeyEventArgs e);
}