namespace UpgradeHelpers.Events
{
    /// <summary>
    ///     Defines the different reasons (or ways) a window is closed.  Basically it helps to identify
    ///     if the window was closed by an end user action or a programming decision.
    /// </summary>
    public enum CloseReason
    {
        /// <summary>
        ///     Indicates that window was closed by end user request.
        /// </summary>
        UserClosing,
        /// <summary>
        ///     Indicates that no specific close reason was specified (referring to an internal programming decision).
        /// </summary>
        None
    }
}