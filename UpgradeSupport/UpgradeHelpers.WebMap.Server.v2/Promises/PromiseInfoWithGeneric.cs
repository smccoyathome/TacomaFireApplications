using System;
using System.Diagnostics;
using System.Web.UI.WebControls;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Server.Common;

namespace UpgradeHelpers.WebMap.Server
{
	/// <summary>
	/// Defines a promise object that handles code and is associated with a typed return value
	/// </summary>
#if DEBUG
	[DebuggerDisplay("At = {UserCodeInfo}")]
#endif

#if (WEBMAPVS2013 || WEBMAPVS2015) && DEBUG
	[DebuggerVisualizer(
   typeof(UpgradeHelpers.WebMap.Server.DebugEx.PromiseDebugVisualizer),
   typeof(PromiseLocationObjectSource))]

#endif
	internal class PromiseInfo<T> : BasePromiseInfo<T>
	{
		public override T ResolvedValue { get; set; }

		public static PromiseInfo<T> CreateInstance(Delegate code, Object target = null, string modalUniqueId = null,
					bool registerPromise = true, PromiseState state = PromiseState.Unblocked, int insertionIndex = -1)
		{
			var instance = new PromiseInfo<T>
			{

#if DEBUG
				UserCodeInfo = DebugUtils.GetUserCodeInfo(new StackTrace(true)),
#endif
				State = state,
				ParentId = (ViewManager.Instance.State.InPromiseExecution && ViewManager.Instance.State.ExecutingPromiseInfo != null) ? ViewManager.Instance.State.ExecutingPromiseInfo.UniqueID : String.Empty
			};
			BuildContinuationInfo(StateManager.Current, instance, code, modalUniqueId, target);
			if (registerPromise)
				ViewManager.Instance.State.RegisterPromise(instance, insertionIndex);

			return instance;
		}

		public override bool TryGetResolvedValue(out object value)
		{
			value = ResolvedValue;
			return State == PromiseState.Resolved;
		}

		public override void Resolve(params object[] parameters)
		{
			object result = null;
			try
			{
				result = Execute(parameters);
			}
			catch (Exception)
			{
				State = PromiseState.Rejected;
				return;
			}

			if (result != null)
			{
				if (result is T)
				{
					ResolvedValue = (T)result;
					SetState();
				}
				else
				{
					throw new Exception("The promise result does not match with the expected type");
				}
			}
			else
			{
				if (null == default(T))
				{
					ResolvedValue = default(T);
					SetState();
				}
				else
				{
					throw new Exception("The promise expected type does not allow null value");
				}

			}
		}
	}
}
