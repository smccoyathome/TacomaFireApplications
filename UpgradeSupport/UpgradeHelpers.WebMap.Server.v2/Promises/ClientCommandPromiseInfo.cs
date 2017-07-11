using System;
using System.Diagnostics;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server
{
#if DEBUG
	[DebuggerDisplay("ClientPromise At = {UserCodeInfo}")]
#endif
	internal class ClientCommandPromiseInfo<T> : DelimiterPromise<T>
	{
		private string _currentCommand;
		private ViewManager _viewManager;

		public static ClientCommandPromiseInfo<T> CreateClientPromise(StateManager stateManager, ViewManager viewManager, string commandId)
		{
            var instance = new ClientCommandPromiseInfo<T>() {
#if DEBUG
				UserCodeInfo = DebugUtils.GetUserCodeInfo(new StackTrace(true)),
#endif

				UniqueID = stateManager.UniqueIDGenerator.GetPromiseUniqueID(),
				_viewManager = viewManager,
				_currentCommand = commandId,
				State = PromiseState.Blocked
			};
			viewManager._state.RegisterPromise(instance);
			return instance;
		}


		protected override IPromise CreatePromise(Delegate code, int insertionIndex = -1)
		{
			var promise = PromiseInfo.CreateInstance(code, insertionIndex: insertionIndex);
			ThenUniqueID = promise.UniqueID;
			return promise;
		}

		protected override IPromise<TR> CreatePromise<TR>(Delegate code, int insertionIndex = -1)
		{
			var promise = PromiseInfo<TR>.CreateInstance(code, insertionIndex: insertionIndex);
			ThenUniqueID = promise.UniqueID;
			return promise;
		}

		protected override IPromise CreatePromise(Func<bool> condition, Action body, Action increment, int insertionIndex = -1)
		{
			var promise = Promises.LoopPromiseInfo.CreateInstance(condition, body, increment, state: State, insertionIndex: insertionIndex);
			ThenUniqueID = promise.UniqueID;
			return promise;
		}

		protected override IPromise CreatePromise<TElement>(IPromiseCollectionInfo<TElement> collection, Action<TElement> body, int insertionIndex = -1)
		{
			var promise = Promises.LoopPromiseInfo<TElement>.CreateInstance<TElement>(collection, body, insertionIndex: insertionIndex); ;
			ThenUniqueID = promise.UniqueID;
			return promise;
		}

		public override void Resolve(params object[] parameters)
		{
			State = PromiseState.Resolved;
			if (parameters.Length > 0)
				ResolvedValue = (T)parameters[0];

		}
	}
}