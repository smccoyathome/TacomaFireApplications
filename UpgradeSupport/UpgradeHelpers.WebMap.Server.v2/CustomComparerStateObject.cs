using System;
using System.Collections.Generic;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server
{

    public class CustomComparerStateObject : EqualityComparer<IStateObject>
    {
        private CustomComparerStateObject() { }

        public static CustomComparerStateObject CommonInstance = new CustomComparerStateObject();

        public override bool Equals(IStateObject obj1, IStateObject obj2)
        {
            return Object.ReferenceEquals(obj1, obj2);

        }
        public override int GetHashCode(IStateObject obj)
        {
            if (obj != null && obj.UniqueID != null)
            {
                return obj.UniqueID.GetHashCode();
            }
            else
            {
                return 0;
            }

        }
    }

}