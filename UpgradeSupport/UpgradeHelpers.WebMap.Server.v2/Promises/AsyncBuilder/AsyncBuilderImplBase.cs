using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Helpers;

namespace UpgradeHelpers.WebMap.Server
{
	public class ForEachCollectionInfo<T> : IPromiseCollectionInfo<T>
	{
		public virtual int Current { get; set; }
		public string UniqueID { get; set; }

		[UpgradeHelpers.Helpers.Reference(UpgradeHelpers.Helpers.ReferenceTypeValues.Strong)]
		public virtual IList<T> List { get; set; }
		public bool LoopCondition()
		{
			if (List != null)
				return Current < List.Count;
			return false;
		}
		public void Next()
		{
			Current++;
		}
		public T Item()
		{
			if (List != null)
				return List[Current];
			else
				return default(T);
		}
	}

	internal class AsyncBuilderImplBase : AsyncBuilder, IAsyncBuilder
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

		private void AppendLoop<T>(ForEachCollectionInfo<T> collectionInfo, Action<T> bodyAction)
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

		public override void AppendForeach<T>(Func<IList<T>> func, Action<T> action)
		{
			ForEachCollectionInfo<T> info = UpgradeHelpers.Helpers.StaticContainer.Instance.Resolve<ForEachCollectionInfo<T>>();
			Append(func);
			Append<IList<T>>((collection) => { info.List = collection;});
			AppendLoop<T>(info, action);
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
		/// <param name="action">The delegate to be added as a promise</param>
		public override void Append(Action action)
		{
			this.AddPromise(action, viewManager.Async(action));
		}
		/// <summary>
		/// Register a function to the Promises Queue.
		/// </summary>
		/// <typeparam name="TR">Return Type</typeparam>
		/// <typeparam name="TA">Argument Type</typeparam>
		/// <param name="function"></param>
		public override void Append<TA, TR>(Func<TA, TR> function)
		{
			this.AddPromise(function, viewManager.Async<TA, TR>(function));
		}

		/// <summary>
		/// Register an action to the Promises Queue.
		/// </summary>
		/// <param name="action">The delegate to be added as a promise</param>
		public override void Append<T>(Action<T> action)
		{
			this.AddPromise(action, viewManager.Async<T>(action));
		}

		/// <summary>
		/// Register an action to the Promises Queue.
		/// </summary>
		/// <typeparam name="T">Return Type</typeparam>
		/// <param name="function">The delegate to be added as a promise</param>
		public override void Append<T>(Func<T> function)
		{
			this.AddPromise(function, viewManager.Async<T>(function));
		}

		/// <summary>
		/// Register an action to the Promises Queue.
		/// </summary>
		/// <param name="function">The delegate to be added as a promise</param>
		public override void Append(Func<IPromise> function)
		{
			var promise = viewManager.Async(function);
			this.AddPromise(null, promise);
		}
		/// <summary>
		/// Register an action to the Promises Queue.
		/// </summary>
		/// <param name="function">The delegate to be added as a promise</param>
		public override void Append<TR>(Func<IPromise<TR>> function)
		{
			var promise = viewManager.Async(function);
			this.AddPromise(null, promise);
		}
		/// <summary>
		/// Register a promise to the Promises Queue.
		/// </summary>
		/// <param name="promise">The instance of the promise</param>
		public override void Append(IPromise promise)
		{
			this.AddPromise(null, promise);
		}
		/// <summary>
		/// Register a promise to the Promises Queue.
		/// </summary>
		/// <param name="promise">The instance of the promise</param>
		public override void Append<T>(IPromise<T> promise)
		{
			this.AddPromise(null, promise);
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

		public override void Return<T>(Func<T> function)
		{
			var promise = viewManager.Async<T>(function) as BasePromiseInfo;
			this.AddPromise(function, promise, PromiseType.Return);
		}

		public override void Return<T,TR>(Func<T,TR> function)
		{
			var promise = viewManager.Async<T,TR>(function) as BasePromiseInfo;
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
