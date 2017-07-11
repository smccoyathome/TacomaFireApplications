namespace UpgradeHelpers.DB
{
    /// <summary>Sets or returns the type of locking (concurrency) to use.</summary>
    public enum LockTypeEnum
    {
        /// <summary>
        /// Lock not specified, value -1
        /// </summary>
        LockUnspecified = -1,

        /// <summary>
        /// Read Only Lock, value 1
        /// </summary>
        LockReadOnly = 1,

        /// <summary>
        /// Pessimistic Lock
        /// </summary>
        LockPessimistic = 2,

        /// <summary>
        /// Optimistic Lock
        /// </summary>
        LockOptimistic = 3,

        /// <summary>
        /// Batch Optimistic Lock
        /// </summary>
        LockBatchOptimistic = 4,

        /// <summary>
        /// Locked
        /// </summary>
        LockLock = 5,
        
        /// <summary>
        /// Row Lock
        /// </summary>
        LockRowver = 6,
        
        /// <summary>
        /// Value Lock
        /// </summary>
        LockValues = 7
    }
}