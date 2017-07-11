using System;
using System.Diagnostics;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server
{
	internal struct CollectionStateObjectReference  : ILazyObject{

        public const string NULLID = "@NUL";
        public  string TargetUniqueID
        {
            get
            {
                if (_obj == null)
                    return _uniqueID;
                else
                    return _obj.UniqueID;
            }
        }

        string _uniqueID;

		IStateObject _obj;

		public CollectionStateObjectReference(string uniqueID) {
			_uniqueID = uniqueID;
            _obj = null;
		}

		public CollectionStateObjectReference(IStateObject obj)
		{
			_obj = obj;
            _uniqueID = null;
		}

		public  IStateObject Target 
		{
			get {
				if (_obj == null) {
					_obj = StateManager.Current.GetObject (_uniqueID);
				}
				return _obj;
			}
		}

		public override bool Equals (object obj)
		{
			if (obj == null)
				return false;
			if (obj is CollectionStateObjectReference) {
				if (_obj == null)
					return _uniqueID == ((CollectionStateObjectReference)obj).TargetUniqueID;
				else
					return ((CollectionStateObjectReference)obj).Equals (_obj); 
			}
			if (obj is IStateObject) {
				if (_obj == null)
					return _uniqueID == ((IStateObject)obj).UniqueID;
				else
					return _obj.UniqueID == ((IStateObject)obj).UniqueID;
						
			}
			return false;
		}

		public override int GetHashCode()
		{
			if (_obj != null)
				return _obj.GetHashCode();
			return _uniqueID.GetHashCode();
		}

        object ILazyObject.Target
        {
            get
            {
                return this.Target;
            }
        }

    }

}

