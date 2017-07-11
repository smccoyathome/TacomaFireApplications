using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeHelpers.WebMap.Server
{
    /// <summary>
    /// This interface will be implemented by webmap serializer and can be used by JsonConverters to 
    /// determine if this is server side or client side serialization
    /// </summary>
    public interface IWebMapContractResolver
    {
        bool IsServerSide { get;}
    }
}
