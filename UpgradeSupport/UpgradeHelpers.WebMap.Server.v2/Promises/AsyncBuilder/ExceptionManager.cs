using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server
{
	internal class ExceptionManager : IExceptionManager
	{
		private static Type TYPE_OF_EXCEPTION = typeof(Exception);
		internal IAsyncBuilder AsyncBuilder { get; set; }
		internal string FamilyId { get; set; }
		internal Dictionary<Type, Delegate> Exceptions = new Dictionary<Type, Delegate>();
		internal Action Finally;
        private readonly ViewManager _viewManager;

        internal ExceptionManager(ViewManager viewManager) { _viewManager = viewManager; }

		/// <summary>
		/// Triggers the logic associated to a catch block on synchronic code.
		/// </summary>
		/// <typeparam name="T">The type of the exception</typeparam>
		/// <param name="ex">The instance of the exception</param>
		public void HandleException<T>(T ex) where T : Exception
		{
			Delegate genericException = null;
			Delegate specificException = null;
			Exceptions.TryGetValue(TYPE_OF_EXCEPTION, out genericException);

			//If System.Exception no need to look for a more specific exception.
			if (typeof(T) != TYPE_OF_EXCEPTION)
			{
				Exceptions.TryGetValue(typeof(T), out specificException);
				if (specificException != null)
				{
					//The type of the thrown exception is different than System.Exception and has catch that handles it specifically.
					(specificException as Action<T>)(ex);
					return;
				}
			}

			if (genericException != null)
			{
				//If no specific excption is declared then the generic catch handles it.
				(genericException as Action<T>)(ex);
				return;
			}
			// Look in the stack for a suitable exception
			this.HandleException(ex, this.AsyncBuilder.Parent);
		}
		/// <summary>
		/// Triggers the logic associated to a catch block on synchronic code. Looks for a suitable excpetion through the same family
		/// </summary>
		/// <typeparam name="T">The type of the exception</typeparam>
		/// <param name="ex">The instance of the exception</param>
		/// <param name="builder">The instance of the parent builder</param>
		private void HandleException<T>(T ex, IAsyncBuilder builder) where T : Exception
		{
			if (builder != null && builder.HasExceptionManager())
			{
				var exceptionManager = builder.ExceptionManager as ExceptionManager;
				Delegate genericException = null;
				Delegate specificException = null;
				exceptionManager.Exceptions.TryGetValue(TYPE_OF_EXCEPTION, out genericException);

				//If System.Exception no need to look for a more specific exception.
				if (typeof(T) != TYPE_OF_EXCEPTION)
				{
					exceptionManager.Exceptions.TryGetValue(typeof(T), out specificException);
					if (specificException != null)
					{
						//The type of the thrown exception is different than System.Exception and has catch that handles it specifically.
						(specificException as Action<T>)(ex);
						return;
					}
				}

				if (genericException != null)
				{
					//If no specific excption is declared then the generic catch handles it.
					(genericException as Action<T>)(ex);
					return;
				}
				else if (builder == null)
				{
					//If no more parents the exception must be handled asynchronically.
					return;
				}
				else
				{
					//Look for another exception in the chain
					HandleException<T>(ex, builder.Parent);
				}
			}
		}
		/// <summary>
		/// Execute the code marked enclosed in the finally statement added for the current context.
		/// </summary>
		public void ExecuteFinally()
		{
			if (this.Finally != null)
			{
				this.Finally();
			}
		}
		/// <summary>
		/// Executes ExceptionManger Dispose. Register the associated promises for the catch and finnaly blocks.
		/// </summary>
		public void Dispose()
		{
			foreach (var exception in Exceptions.Values)
			{
				//Adds a promise for every catch appended.
				AsyncBuilder.AddPromise(exception, _viewManager.Async(exception), PromiseType.Catch);
			}
			if (this.Finally != null)
			{
				//Adds a promise for the finally block
				AsyncBuilder.AddPromise(this.Finally, _viewManager.Async(this.Finally), PromiseType.Finally);
			}
		}

		/// <summary>
		/// Adds a delegate that contains the code of the exception handling. At this point there is no promise added to the Queue
		/// </summary>
		/// <typeparam name="T">The type of the exception</typeparam>
		/// <param name="action">The action that contains the exception handling code</param>
		public void AppendCatch<T>(Action<T> action) where T : Exception
		{
			this.Exceptions.Add(action.Method.GetParameters()[0].ParameterType, action);
		}
		/// <summary>
		/// Adds a delegate that contains the code of the finally. At this point there is no promise added to the Queue
		/// </summary>
		/// <param name="action">The action that contains the finally code</param>
		public void AppendFinally(Action action)
		{
			this.Finally = action;
		}

	}
}
