using System;
using System.Diagnostics;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Server.Common;

namespace UpgradeHelpers.WebMap.Server
{



	/// <summary>
	/// The StateObject pointer is for internal use
	/// </summary>
	public class StateObjectPointer : IStateObject, IInternalData, IReturnWholeObjectAsDelta, NoInterception
	{
		public string UniqueID { get; set; }

		internal string _targetUniqueId;

		internal string TargetUniqueId
		{
			get
			{
				if (_target != null)
				{
					return _target.UniqueID;
				}
				return _targetUniqueId;
			}
			set
			{
				if (_targetUniqueId != value)
				{
					_targetUniqueId = value;
                    if (_target != null)
					{
						Target = null;
					}
				}
			}
		}

		private IStateObject _target;

		public IStateObject Target
		{
			get
			{
				if (_target == null)
				{
					if (String.IsNullOrWhiteSpace(TargetUniqueId))
					{
                        TraceUtil.TraceError("StateObjectPointer::Target TargetUniqueId should not be null");
						return null;
					}
					try
					{
						_target = (IStateObject) StateManager.Current.GetObject(TargetUniqueId);
					}
					catch
					{
                        TraceUtil.TraceError("StateObjectPointer::Target points to null");
						_target = null;
					}
				}
				return _target;
			}
			set
			{
				_target = value;
			}
		}

		internal static void AssignUniqueIdToPointer(IStateObject parentInstance, string relativeUid,
			StateObjectPointer pointer)
		{
			var stateManager = StateManager.Current;
			if (StateManager.AllBranchesAttached(parentInstance))
			{
				//at this point we have a new pointer with an attached parent
				//which means that it was born on the temp stateManager
				//we cannot just do a switchunique ids because switching
				//is only on the stateManager level
				//we need to promote it from temp to StateManager
				//to make sure that it will be persisted
				pointer.UniqueID = relativeUid;
				stateManager.AddNewAttachedObject(pointer);
			}
			else
			{
				//at this point we have a new pointer with an UNATTACHED parent
				//which means both the parent and the pointer are on the temp stateManager
				//we need to switchunique ids because 
				//they are at the stateManager level
				//if the parent is promoted so will be the pointer
				pointer.UniqueID = relativeUid;
				stateManager.AddNewTemporaryObject(pointer);
			}
			
		}

		public virtual bool IsCompatibleWith(object value)
		{
			if (value is IStateObject)
				return true;
			return false;
		}
	}

	
}
