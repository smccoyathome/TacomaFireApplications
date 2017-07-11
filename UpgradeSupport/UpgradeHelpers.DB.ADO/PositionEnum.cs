namespace UpgradeHelpers.DB.ADO
{
    /// <summary>Determines if the operation will affect the records in a specific position.</summary>
    public enum PositionEnum
    {
        /// <summary>
        /// Begin of File Position
        /// </summary>
        adPosBOF = -2,

        /// <summary>
        /// End Of File Position
        /// </summary>
        adPosEOF = -3,

        /// <summary>
        /// Postion unknown
        /// </summary>
        adPosUnknown = -1
    }
}