
using System.Reflection;
using UpgradeHelpers.Events;

namespace UpgradeHelpers.WebMap.Server
{

    //Holds the methodInfo + HandlerAttributeInfo
    public class MethodInfoEx
    {
        public MethodInfo method;
        public Handler HandlerAttribute;
        public string[] MethodAndEventParts;
    }

}