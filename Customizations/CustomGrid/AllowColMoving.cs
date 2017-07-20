namespace Custom.ViewModels.Grid
{
    public enum AllowColMoving
    {
        /// <summary>
        /// Use Default. The setting of the object's parent will be used
        /// </summary>
        Default = 0,
        /// <summary>
        /// Not Allowed. Columns cannot be moved by the user.
        /// </summary>
        NotAllowed = 1,
        /// <summary>
        /// Within Group. Columns can be moved by the user within the same Group.
        /// </summary>
        WithinGroup = 2,
        /// <summary>
        /// Within Band. Columns can be moved by the user within the same Band.
        /// </summary>
        WithinBand = 3,
    }
}
