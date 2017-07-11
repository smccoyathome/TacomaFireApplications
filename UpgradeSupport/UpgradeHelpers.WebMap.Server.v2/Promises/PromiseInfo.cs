using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using Fasterflect;
using Newtonsoft.Json;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Server.Common;
using UpgradeHelpers.WebMap.Server.Promises;
using UpgradeHelpers.Helpers;

namespace UpgradeHelpers.WebMap.Server
{
	/// <summary>
	/// Defines a promise object that handles code
	/// </summary>
	/// 
#if DEBUG
	[DebuggerDisplay("At = {UserCodeInfo}")]
#endif

#if (WEBMAPVS2013 || WEBMAPVS2015) && DEBUG
	[DebuggerVisualizer(
   typeof(UpgradeHelpers.WebMap.Server.DebugEx.PromiseDebugVisualizer),
   typeof(PromiseLocationObjectSource))]

#endif
	internal class PromiseInfo : BasePromiseInfo, IInternalData
	{

		public static PromiseInfo CreateInstance(Delegate code, object target = null, string modalUniqueId = null, bool registerPromise = true, PromiseState state = PromiseState.Unblocked, int insertionIndex = -1)
		{
			var instance = new PromiseInfo
			{
#if DEBUG
				UserCodeInfo = DebugUtils.GetUserCodeInfo(new StackTrace(true)),
#endif
				State = state,
				// We will use the ParentId to identify promises belongs from a exploited promise, and know they are relative between them.
				ParentId = (ViewManager.Instance.State.InPromiseExecution && ViewManager.Instance.State.ExecutingPromiseInfo != null) ? ViewManager.Instance.State.ExecutingPromiseInfo.UniqueID : String.Empty
			};
			BuildContinuationInfo(StateManager.Current, instance, code, modalUniqueId, target);
			if (registerPromise)
				ViewManager.Instance.State.RegisterPromise(instance, insertionIndex);

			return instance;
		}

		public override void Resolve(params object[] parameters)
		{
			try
			{
				Execute(parameters);
				SetState();
			}
			catch (Exception)
			{
				State = PromiseState.Rejected;
			}
		}
	}
	internal class DelimiterPromise<T> : PromiseInfo<T>, IDelimiterPromise
	{

	}

	internal class FailPromise : PromiseInfo<Exception>
	{

	}
}
