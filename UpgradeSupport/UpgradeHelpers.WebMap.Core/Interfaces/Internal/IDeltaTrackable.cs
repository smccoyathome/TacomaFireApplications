using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeHelpers.WebMap.Server
{
    /// <summary>
    /// This interface is meant to be implemented 
    ///  by the generated Model Proxies. It will help to 
    ///  track changes
    /// </summary>
    internal interface IDeltaTrackable
    {
            bool IsDirty { get; set; }
            bool IsModified(int propIndex);
            bool IsAnyModified();
            void SetIsModified(int propIndex);
            void ResetModifiedFlags();
    }
}
