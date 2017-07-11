using System;
using System.Diagnostics;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server
{
    /// <summary>
    /// Placeholder Promiseinfo, that encapsulates the promise created when open a modal dialog
    /// </summary>
#if DEBUG
    [DebuggerDisplay("DialogPromise At = {UserCodeInfo}")]
#endif
#if (WEBMAPVS2013 || WEBMAPVS2015) && DEBUG
	[DebuggerVisualizer(
   typeof(UpgradeHelpers.WebMap.Server.DebugEx.PromiseDebugVisualizer),
   typeof(PromiseLocationObjectSource))]

#endif
	[Serializable]
    internal class ShowDialogPromiseInfo : DelimiterPromise<DialogResult>
	{
		private string _modalUniqueIdForRelatedPromise;


        public static IPromise CreateDialogPromise(string modalUniqueId)
        {
            var instance =   new ShowDialogPromiseInfo() {
#if DEBUG
                UserCodeInfo = DebugUtils.GetUserCodeInfo(new StackTrace(true)),
#endif
                UniqueID =  StateManager.Current.UniqueIDGenerator.GetPromiseUniqueID(),  State = PromiseState.Blocked, _modalUniqueIdForRelatedPromise = modalUniqueId };
            ViewManager.Instance._state.RegisterPromise(instance);
            return instance;
        }


        protected override IPromise CreatePromise(Delegate code, int insertionIndex = -1)
		{
			var result =  PromiseInfo.CreateInstance(code, modalUniqueId: _modalUniqueIdForRelatedPromise, state: State, insertionIndex: insertionIndex);
            ThenUniqueID = result.UniqueID;
            return result;
		}

        protected override IPromise<TR> CreatePromise<TR>(Delegate code, int insertionIndex = -1)
		{
			var result = PromiseInfo<TR>.CreateInstance(code, modalUniqueId: _modalUniqueIdForRelatedPromise, state: State, insertionIndex: insertionIndex);
            ThenUniqueID = result.UniqueID;
            return result;
		}

        public override void Resolve(params object[] parameters)
        {
            State = PromiseState.Resolved;
            if (parameters.Length > 0)
                ResolvedValue = (DialogResult)parameters[0];
        }
	}
}
