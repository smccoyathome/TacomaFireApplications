using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpgradeHelpers.Interfaces
{
    /// <summary>
    /// A Delta Watcher is capable of turning the portions of the object that you want to
    /// watch into a byte array.
    /// Comparison to this byte array will be used to detect deltas or changes.
    /// </summary>
    public interface IDeltaWatcher
    {
        byte[] GetAsBytes(object obj);
    }
}
