using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.EventAggregator;

namespace UpgradeHelpers.WebMap.List
{
    public class LazyObject : ILazyObject , ISubscriber<UniqueIdChanged>
	{
		internal IStateManager StateManager;

		private object _obj { get; set; }

		internal LazyObject(object obj, IStateManager statemanager)
		{
			this._obj = obj;
			this.StateManager = statemanager;
		}

        internal LazyObject(object obj, IStateManager statemanager, IServerEventAggregator ea)
		{
			this._obj = obj;
			ea.SubsribeEvent(this);
			this.StateManager = statemanager;
		}
        public LazyObject(object anyObject)
        {
            this._obj = anyObject;
        }
        public LazyObject(string textOrUniqueId, bool stringType = false)
		{
			if (stringType)
			{
				this._obj = textOrUniqueId;
			}
			else
			{
				_targetUniqueID = textOrUniqueId;
			}
		}

		public object Target
        {
            get
            {
                if (_obj == null && _targetUniqueID != null && this.StateManager != null)
                {
                    _obj = this.StateManager.GetObject(_targetUniqueID);
                }
                return _obj;
            }
            set
            {
                _obj = value;
            }
        }

		private string _targetUniqueID;
		public string TargetUniqueID
		{
			get
			{
				var objIStateObject = _obj as IStateObject;
				if (objIStateObject != null)
					return objIStateObject.UniqueID;
				return _targetUniqueID;
			}
			set
			{
				_targetUniqueID = value;
			}
		}

		public void OnEventHandler(UniqueIdChanged e)
		{
			if (string.CompareOrdinal(this.TargetUniqueID, e.OldUniqueID) == 0)
				this.TargetUniqueID = e.NewUniqueID;
		}
	}
}
