using System.Collections.Generic;

namespace UpgradeHelpers.WebMap.List
{

    public interface IVirtualListContext
    {
        List<string> pageIndexes { get; }
        Dictionary<string, int> initialIndexDictionary { get; }
    }
}