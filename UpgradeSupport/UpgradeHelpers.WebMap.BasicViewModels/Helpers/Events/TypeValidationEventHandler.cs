namespace UpgradeHelpers.Events
{
    /// <summary>
    ///     Defines an event handler for TypeValidation events.  This class is provided for compilation purposes only,
    ///     because mouse events are not server propagated to server side, instead they are
    ///     converted to client side events (such as JavaScript)
    /// </summary>
    public delegate void TypeValidationEventHandler(object sender, TypeValidationEventArgs e);

}
