using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Helpers;

namespace UpgradeHelpers.WebMap.Server
{
	internal class AsyncBuilderImplBase<T> : AsyncBuilder<T>, IAsyncBuilder
	{
		public ViewManager viewManager;
		public string FamilyId { get; set; }
		public bool HasAppendedPromises { get; set; }
		public IAsyncBuilder Parent { get; set; }
		public event AsyncBuilderUtils.OnDiposeBuilder DisposeBuilder;
		public List<DelegateOrPromise> Delegates { get; set; }
		private ExceptionManager _exceptionManager;
		public override IExceptionManager ExceptionManager
		{
			get
			{
				if (this._exceptionManager == null)
				{
					this._exceptionManager = new ExceptionManager(viewManager) { FamilyId = this.FamilyId, AsyncBuilder = this };
				}
				return this._exceptionManager;
			}
		}

		private void AppendLoop(Func<bool> conditionFunc, Action bodyAction, Action incrementAction)
		{
			this.AddPromise(null, viewManager.Async(conditionFunc, bodyAction, incrementAction));
		}

		private void AppendLoop<TElement>(ForEachCollectionInfo<TElement> collectionInfo, Action<TElement> bodyAction)
		{
			this.AddPromise(null, viewManager.Async(collectionInfo, bodyAction));
		}

		public override void AppendFor(Action initializationAction, Func<bool> conditionFunc, Action bodyAction, Action incrementAction)
		{
			Append(initializationAction);
			AppendLoop(conditionFunc, bodyAction, incrementAction);
		}

		public override void AppendWhile(Func<bool> conditionFunc, Action bodyAction)
		{
			AppendLoop(conditionFunc, bodyAction, null);
		}

		public override void AppendForeach<TElement>(Func<IList<TElement>> func, Action<TElement> action)
		{
			ForEachCollectionInfo<TElement> info = UpgradeHelpers.Helpers.StaticContainer.Instance.Resolve<ForEachCollectionInfo<TElement>>();
			Append(func);
			Append<IList<TElement>>((collection) => { info.List = collection; });
			AppendLoop<TElement>(info, action);
		}

		public override void AppendDoWhile(Func<bool> conditionFunc, Action bodyAction)
		{
			Append(bodyAction);
			AppendLoop(conditionFunc, bodyAction, null);
		}


		public bool HasExceptionManager()
		{
			return this._exceptionManager != null;
		}

		public AsyncBuilderImplBase()
		{
			Delegates = new List<DelegateOrPromise>();
		}

		#region Append

		/// <summary>
		/// Register an action to the Promises Queue.
		/// </summary>
		/// <param name="action">The delegate of the promise that recieves an argument</param>
		public void Append(Action<T> action)
		{
			this.AddPromise(action, viewManager.Async<T>(action));
		}
		/// <summary>
		/// Register an action to the Promises Queue.
		/// </summary>
		/// <param name="action"></param>
		public override void Append(Action action)
		{
			this.AddPromise(action, viewManager.Async(action));
		}
		/// <summary>
		/// Register an action to the Promises Queue.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="function"></param>
		public override void Append<TA>(Func<TA> function)
		{
			this.AddPromise(function, viewManager.Async<TA>(function));
		}
		/// <summary>
		/// Register a function to the Promises Queue.
		/// </summary>
		/// <param name="function"></param>
		public override void Append(Func<IPromise> function)
		{
			var promise = function();
			this.AddPromise(null, promise);
		}
		/// <summary>
		/// Register a function to the Promises Queue.
		/// </summary>
		/// <param name="function"></param>
		public override void Append<TR>(Func<IPromise<TR>> function)
		{
			var promise = function();
			this.AddPromise(null, promise);
		}
		/// <summary>
		/// Register a function to the Promises Queue.
		/// </summary>
		/// <param name="function"></param>
		public override void Append(Func<T> function)
		{
			this.AddPromise(function, viewManager.Async<T>(function));
		}
		/// <summary>
		/// Register a function to the Promises Queue.
		/// </summary>
		/// <typeparam name="TR">Return Type</typeparam>
		/// <typeparam name="TA">Argument Type</typeparam>
		/// <param name="function"></param>
		public override void Append<TR, TA>(Func<TR, TA> function)
		{
			this.AddPromise(function, viewManager.Async<TR, TA>(function));
		}
		/// <summary>
		/// Register a promise to the Promises Queue.
		/// </summary>
		/// <param name="promise"></param>
		public override void Append(IPromise promise)
		{
			this.AddPromise(null, promise);
		}
		/// <summary>
		/// Register a promise to the Promises Queue.
		/// </summary>
		/// <param name="promise"></param>
		public override void Append<TR>(IPromise<TR> promise)
		{
			this.AddPromise(null, promise);
		}
		/// <summary>
		/// Register an action to the Promises Queue.
		/// </summary>
		/// <param name="action">The delegate to be added as a promise</param>
		public override void Append<TA>(Action<TA> action)
		{
			this.AddPromise(action, viewManager.Async<TA>(action));
		}

		#endregion
		/// <summary>
		/// Closes the current builder, if is the last also closes the builders stack.
		/// </summary>
		public override void Dispose()
		{
			this.SetPromisesState();
			if (HasAppendedPromises)
			{
				this.ValidateDelegates();
			}
			this.InsertPromisesToParent();
			this.DisposeExceptionManager();

			//When the current scope (TopBuilder) is closed the builder stack is destroyed.
			if (DisposeBuilder != null)
			{
				DisposeBuilder();
			}
		}
		protected virtual void ValidateDelegates() { }

		public override Promise GetPromise()
		{
			throw new NotImplementedException();
		}

		public override Promise<T> GetPromiseEx()
		{
			throw new NotImplementedException();
		}
		public override void Return<TR>(Func<TR> function)
		{
			var promise = viewManager.Async<TR>(function) as BasePromiseInfo;
			this.AddPromise(function, promise, PromiseType.Return);
		}

		public override void Return<TP, TR>(Func<TP, TR> function)
		{
			var promise = viewManager.Async<TP, TR>(function) as BasePromiseInfo;
			this.AddPromise(function, promise, PromiseType.Return);
		}

		public override void Return(Action action)
		{
			var promise = viewManager.Async(action) as BasePromiseInfo;
			this.AddPromise(action, promise, PromiseType.Return);
		}
		public string UniqueId { get; set; }
	}
}
