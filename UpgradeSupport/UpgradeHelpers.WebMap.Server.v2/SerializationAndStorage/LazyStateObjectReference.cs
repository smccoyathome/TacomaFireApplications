using System;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server
{


		internal class LazyStateObjectReference
		{

			public LazyStateObjectReference(StateManager parent, string uniqueId)
			{
				_uniqueId = uniqueId;
			}

			readonly private IStateObject _target;

			public LazyStateObjectReference(StateManager parent, IStateObject target)
			{
				_uniqueId = target.UniqueID;
				_target = target;
			}

			private string _uniqueId;

			public String UniqueID
			{
				get
				{
					if (_target != null)
					{
						return _target.UniqueID;
					}
					return _uniqueId;
				}
				set { _uniqueId = value; }
			}

            public override bool Equals(object obj)
            {
                var other = obj as LazyStateObjectReference;
                if (other != null) return other._uniqueId.Equals(this._uniqueId, StringComparison.Ordinal);
                return false;
            }

            public override int GetHashCode()
            {
                if (_target != null)
                    return _target.GetHashCode();
                return _uniqueId.GetHashCode();
            }

		}
}