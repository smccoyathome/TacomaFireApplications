using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpgradeHelpers.Helpers
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class Watchable : Attribute
    {
        public Type WatcherType { get; private set; }
        public Watchable(Type watcher)
        {
            WatcherType = watcher;
        }
    }
}
