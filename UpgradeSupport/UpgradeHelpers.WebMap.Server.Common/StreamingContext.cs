using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeHelpers.WebMap.Server
{
    public class StreamingContext
    {
        public static System.Runtime.Serialization.StreamingContext ServerSideSerialization = new System.Runtime.Serialization.StreamingContext(System.Runtime.Serialization.StreamingContextStates.Persistence, "ServerSide");
        public static System.Runtime.Serialization.StreamingContext ClientSideSerialization = new System.Runtime.Serialization.StreamingContext(System.Runtime.Serialization.StreamingContextStates.Persistence, "ServerSide");
    }
}
