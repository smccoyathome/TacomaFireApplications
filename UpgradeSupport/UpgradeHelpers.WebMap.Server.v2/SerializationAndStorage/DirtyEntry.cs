using System.Collections.Generic;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server
{
	public struct DirtyEntry
	{
		public DirtyEntry(IStateObject value, object delta, bool isNew = false)
		{
			this.Value = value;
			this.Delta = delta;
			this.IsNew = isNew;
		}
		public readonly IStateObject Value;
		public readonly object Delta;
		public readonly bool IsNew;
	}

    public class DirtyEntryComparer : IComparer<DirtyEntry>
    {
        public static DirtyEntryComparer CommonInstance = new DirtyEntryComparer();
        public int Compare(DirtyEntry x, DirtyEntry y)
        {
            return x.Value.UniqueID.Length.CompareTo(y.Value.UniqueID.Length);
        }
    }
}