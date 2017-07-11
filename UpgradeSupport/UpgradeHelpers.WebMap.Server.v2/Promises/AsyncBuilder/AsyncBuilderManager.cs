using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Helpers;

namespace UpgradeHelpers.WebMap.Server
{
	internal class AsyncBuilderManager : IAsyncBuilderManager
	{
		private readonly ViewManager _viewManager;
		private readonly StateManager _stateManager;


		internal AsyncBuilderManager(StateManager stateManager, ViewManager viewManager)
		{
			_viewManager = viewManager;
			_stateManager = stateManager;
		}
		/// <summary>
		/// Indicates that a void method has made a return inside a promise.
		/// The following promises are removed in the same family are removed.
		/// </summary>
		public void Return()
		{
			//A dummy promise is insert in the Queue to ensure that the following promises (if any) are going to be marked as Skipped.
			Action action = () => { return; };
			if (_currentBuilders != null)
			{
				bool isTempBuilder = false;
				IAsyncBuilder builder;
				if (_currentBuilders.Count == 0)
				{
					//If has no context a new builder is going to be created based in the current promise information
					builder = (IAsyncBuilder)this.AsyncBuilder(false);
					isTempBuilder = true;
				}
				else
					builder = _currentBuilders.Peek();

				////Discard the following promises in the same family
				((AsyncBuilder)builder).Return(action);

				//This builder was created only to register the return promise and must be removed from the stack
				if (isTempBuilder) builder.Dispose();
			}
			else if (_viewManager.State.ExecutingPromiseInfo != null)
			{
				var promise = _viewManager.Async(action) as BasePromiseInfo;

				promise.FamilyId = _viewManager.State.ExecutingPromiseInfo.FamilyId;
				promise.PromiseType = PromiseType.Return;
			}
			else
			{
				var promise = _viewManager.Async(action) as BasePromiseInfo;

				promise.FamilyId = _stateManager.UniqueIDGenerator.GetFamilyUniqueID();
				promise.PromiseType = PromiseType.Return;
			}
		}

		/// <summary>
		/// Exits the current loop of promises.
		/// The loop promise is going to be resolved.
		/// </summary>
		public void LoopBreak()
		{
			if (_viewManager.State.InPromiseExecution)
			{
				_viewManager.State.ExecutingPromiseInfo.State = PromiseState.LoopBreak;
			}
			else
			{
				throw new InvalidOperationException("LoopBreak method can only be used inside an executing promise.");
			}
		}

		/// <summary>
		/// Skips any promises until reach the current loop of promises.
		/// and continues its execution
		/// </summary>
		public void LoopContinue()
		{
			if (_viewManager.State.InPromiseExecution)
			{
				_viewManager.State.ExecutingPromiseInfo.State = PromiseState.LoopContinue;
			}
			else
			{
				throw new InvalidOperationException("LoopContinue method can only be used inside an executing promise.");
			}
		}

		/// <summary>
		/// Indicates that a with method has made a return inside a promise.
		/// The following promises are removed in the same family are removed.
		/// </summary>
		/// <typeparam name="T">Return Type</typeparam>
		/// <param name="func">The function to be append to the promises</param>
		/// <returns>The default value of the return type</returns>
		public T Return<T>(Func<T> func)
		{
			if (_currentBuilders != null)
			{
				IAsyncBuilder builder;
				bool isTempBuilder = false;
				if (_currentBuilders.Count == 0)
				{
					//If has no context a new builder is going to be created based in the current promise information
					builder = (IAsyncBuilder)this.AsyncBuilder<T>(false);
					isTempBuilder = true;
				}
				else
					builder = _currentBuilders.Peek();

				////Discard the following promises in the same family
				((AsyncBuilder)builder).Return(func);

				//This builder was created only to register the return promise and must be removed from the stack
				if (isTempBuilder) builder.Dispose();
			}
			else if (_viewManager.State.ExecutingPromiseInfo != null)
			{
				//If no builder is open so we check for the an executing promise and take the Family Id from there
				var promise = _viewManager.Async<T>(func) as BasePromiseInfo;

				promise.FamilyId = _viewManager.State.ExecutingPromiseInfo.FamilyId;
				promise.PromiseType = PromiseType.Return;
			}
			else
			{
				//There is no builder open nor promise been executed so this is a is equivalent to a top builder, 
				//a new Family Id is created
				var promise = _viewManager.Async<T>(func) as BasePromiseInfo;

				promise.FamilyId = _stateManager.UniqueIDGenerator.GetFamilyUniqueID();
				promise.PromiseType = PromiseType.Return;
			}
			return default(T);
		}

		/// <summary>
		/// Indicates that a with method has made a return inside a promise.
		/// The following promises are removed in the same family are removed.
		/// </summary>
		/// <typeparam name="T">Parameter Type</typeparam>
		/// <typeparam name="TR">Return Type</typeparam>
		/// <param name="func">The function to be append to the promises</param>
		/// <returns>The default value of the return type</returns>
		public TR Return<T,TR>(Func<T,TR> func)
		{
			if (_currentBuilders != null)
			{
				IAsyncBuilder builder;
				bool isTempBuilder = false;
				if (_currentBuilders.Count == 0)
				{
					//If has no context a new builder is going to be created based in the current promise information
					builder = (IAsyncBuilder)this.AsyncBuilder<TR>(false);
					isTempBuilder = true;
				}
				else
					builder = _currentBuilders.Peek();

				////Discard the following promises in the same family
				((AsyncBuilder)builder).Return(func);
				//This builder was created only to register the return promise and must be removed from the stack
				if (isTempBuilder) builder.Dispose();
			}
			else if (_viewManager.State.ExecutingPromiseInfo != null)
			{
				//If no builder is open so we check for the an executing promise and take the Family Id from there
				var promise = _viewManager.Async<T,TR>(func) as BasePromiseInfo;

				promise.FamilyId = _viewManager.State.ExecutingPromiseInfo.FamilyId;
				promise.PromiseType = PromiseType.Return;
			}
			else
			{
				//There is no builder open nor promise been executed so this is a is equivalent to a top builder, 
				//a new Family Id is created
				var promise = _viewManager.Async<T,TR>(func) as BasePromiseInfo;

				promise.FamilyId = _stateManager.UniqueIDGenerator.GetFamilyUniqueID();
				promise.PromiseType = PromiseType.Return;
			}
			return default(TR);
		}

		/// <summary>
		/// Marks the 
		/// </summary>
		/// <typeparam name="T">Return Type</typeparam>
		/// <param name="func">The function to be append to the promises</param>
		/// <returns>The default value of the return type</returns>
		public T Continue<T>()
		{
			_viewManager.PendingResult<T>();
			return default(T);
		}
		/// <summary>
		/// Initializes a new instance of the AsyncBuilder class.
		/// </summary>
		/// <param name="topBuilder">Indicates whether or not is a Top Builder (the first one of a method)</param>
		public AsyncBuilder AsyncBuilder(bool topBuilder = false)
		{
			var builder = new AsyncBuilderImpl() { viewManager = this._viewManager };

			InitBuilder(topBuilder, builder);
			_currentBuilders.Push(builder);

			return builder;
		}
		/// <summary>
		/// Initializes a new instance of the AsyncBuilder<T> class.
		/// </summary>
		/// <param name="topBuilder">Indicates whether or not is a Top Builder (the first one of a method)</param>
		public AsyncBuilder<T> AsyncBuilder<T>(bool topBuilder = false)
		{
			var builder = new AsyncBuilderImpl<T>() { viewManager = this._viewManager };

			InitBuilder(topBuilder, builder);
			_currentBuilders.Push(builder);

			return builder;
		}
		/// <summary>
		/// Sets the initial values for an AsyncBuilder
		/// </summary>
		/// <param name="topBuilder">Indicates if the builder creates a new context</param>
		/// <param name="builder">The AsyncBuilder instance</param>
		private void InitBuilder(bool topBuilder, IAsyncBuilder builder)
		{
			if (_currentBuilders == null)
			{
				_currentBuilders = new Stack<IAsyncBuilder>();
			}

			if (_currentBuilders.Count > 0)
			{
				builder.Parent = _currentBuilders.Peek();
			}

			builder.UniqueId = _stateManager.UniqueIDGenerator.GetBuilderUniqueID();
			builder.DisposeBuilder += RemoveFromStack;

			if (topBuilder)
			{
#if DEBUG
				if (_currentBuilders.Count > 0)
				{
					UpgradeHelpers.WebMap.Server.Common.TraceUtil.TraceInformation("A new Top Async Builder has been open within another.");
				}
#endif
				//A new scope has been open, all of the following builder are grouped in the current family.
				builder.FamilyId = _stateManager.UniqueIDGenerator.GetFamilyUniqueID();
			}
			else if (builder.Parent != null)
			{
				//Inherits the FamilyId from the last builder
				builder.FamilyId = builder.Parent.FamilyId;
			}
			else
			{
				//The FamilyId is calculated based on the current executing promise
				if (_viewManager.State.ExecutingPromiseInfo != null)
				{
					builder.FamilyId = _viewManager.State.ExecutingPromiseInfo.FamilyId;
				}
			}
		}
		/// <summary>
		/// Once a builder has been disposed it is removed from the Stack.
		/// </summary>
		private void VerifyContext()
		{
			if (_currentBuilders == null)
			{
				throw new InvalidOperationException("There is no context created. Open a new Async to add a new promise");
			}
		}
		/// <summary>
		/// Cleans up the Builders Stack to close the current context.
		/// </summary>
		private void RemoveFromStack()
		{
			if (this._currentBuilders.Count != 0)
			{
				this._currentBuilders.Pop();
			}
		}

		Stack<IAsyncBuilder> _currentBuilders;
	}
}
