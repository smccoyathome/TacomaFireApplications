using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace UpgradeHelpers.DB
{
    /// <summary>
    /// 
    /// </summary>
    public interface IConnectionContainers
    {
        /// <summary>
        /// 
        /// </summary>
        DbProviderFactory Factory { get; set; }
    }
}
