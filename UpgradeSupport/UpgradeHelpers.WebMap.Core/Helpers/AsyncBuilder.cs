using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Helpers;

namespace UpgradeHelpers.Extensions
{
	public static class AsyncBuilderExtensionMethods
	{

		static Func<bool> returnTrue = () => true;
		static Func<bool> returnFalse = () => false;


		public static void Return(this IInteractsWithView obj)
		{
			obj.ViewManager.AsyncBuilderManager.Return();
		}

		public static T Return<T>(this IInteractsWithView obj, Func<T> returnFunc)
		{
			return obj.ViewManager.AsyncBuilderManager.Return(returnFunc);
		}

		public static TR Return<T,TR>(this IInteractsWithView obj, Func<T,TR> returnFunc)
		{
			return obj.ViewManager.AsyncBuilderManager.Return(returnFunc);
		}

		public static T Return<T>(this IInteractsWithView obj, T returnValue)
		{
			return obj.ViewManager.AsyncBuilderManager.Return<T>(() => returnValue);
		}
		public static T Continue<T>(this IInteractsWithView obj)
		{
			return obj.ViewManager.AsyncBuilderManager.Continue<T>();
		}

		public static bool Return(this IInteractsWithView obj, bool value)
		{
			if (value)
				obj.ViewManager.Async(returnTrue);
			else
				obj.ViewManager.Async(returnFalse);
			return false;
		}

		public static void LoopBreak(this IInteractsWithView obj)
		{
			obj.ViewManager.AsyncBuilderManager.LoopBreak();
		}

		public static void LoopContinue(this IInteractsWithView obj)
		{
			obj.ViewManager.AsyncBuilderManager.LoopContinue();
		}

		public static AsyncBuilder Async(this IInteractsWithView obj, bool topBuilder = false)
		{
			return obj.ViewManager.AsyncBuilderManager.AsyncBuilder(topBuilder);
		}

		public static AsyncBuilder<T> Async<T>(this IInteractsWithView obj, bool topBuilder = false)
		{
			return obj.ViewManager.AsyncBuilderManager.AsyncBuilder<T>(topBuilder);
		}

	}
}
namespace UpgradeHelpers.WebMap.Helpers
{


	public abstract class Promise : IPromise
	{
		public abstract IPromise Always(Action<Exception> onRejected);
		public abstract IPromise<TR> Always<TR>(Func<Exception, TR> onRejected);
		public abstract IPromise Fail(Action<Exception> onRejected);
		public abstract IPromise<TR> Fail<TR>(Func<Exception, TR> onRejected);
		public abstract IPromise<TR> ResolvedThen<TR>(TR value);
		public abstract IPromise Then(Action code);
		public abstract IPromise Then<T>(IPromiseCollectionInfo<T> collection, Action<T> body);
		public abstract IPromise Then(Func<bool> condition, Action body, Action increment);
		public abstract IPromise<TR> Then<TR>(Func<TR> code);
		public abstract IPromise Then<TP>(Action<TP> code);
		public abstract IPromise<TR> Then<TP, TR>(Func<TP, TR> code);
		public abstract IPromise ThenWithLogic(Action<ILogicWithViewModel<IViewModel>> code);
		public abstract IPromise<TR> ThenWithLogic<TR>(Func<ILogicWithViewModel<IViewModel>, TR> code);
		public abstract IPromise<TR> ThenWithLogic<TP, TR>(Func<ILogicWithViewModel<IViewModel>, TP, TR> code);

		public virtual bool TryGetResolvedValue(out object value)
		{
			value = null;
			return false;
		}

		protected virtual object Execute(params object[] parameters) { return null; }

	}

	public abstract class Promise<T> : Promise, IPromise<T>
	{
		public abstract T ResolvedValue { get; set; }
	}

	public abstract class AsyncBuilder : IDisposable
	{
		public abstract void Append(Action action);
		public abstract void Append<T>(Action<T> action);
		public abstract void Append<TR>(Func<TR> function);
		public abstract void Append<TA, TR>(Func<TA, TR> function);
		public abstract void Append(Func<IPromise> action);
		public abstract void Append<TR>(Func<IPromise<TR>> action);
		public abstract void Append(IPromise promise);
		public abstract void Append<TR>(IPromise<TR> promise);
		public abstract Promise GetPromise();
		public abstract void Return<T>(Func<T> function);
		public abstract void Return<T, TR>(Func<T, TR> function);
		public abstract void Return(Action function);
		public abstract void Dispose();
		public abstract IExceptionManager ExceptionManager { get; }
		public abstract void AppendFor(Action initializationAction, Func<bool> conditionFunc, Action bodyAction, Action incrementAction);
		public abstract void AppendWhile(Func<bool> conditionFunc, Action bodyAction);
		public abstract void AppendForeach<T>(Func<IList<T>> func, Action<T> action);
		public abstract void AppendDoWhile(Func<bool> conditionFunc, Action bodyAction);

		public static implicit operator Promise(AsyncBuilder obj)
		{
			return obj.GetPromise();
		}

		public static AsyncBuilder operator +(AsyncBuilder builder, Action func)
		{
			return builder;
		}

		
	}

	public abstract class AsyncBuilder<T> : AsyncBuilder
	{
		public abstract void Append(Func<T> action);

		public abstract Promise<T> GetPromiseEx();

		public static implicit operator Promise<T>(AsyncBuilder<T> obj)
		{
			return obj.GetPromiseEx();
		}

		public static implicit operator Promise(AsyncBuilder<T> obj)
		{
			return obj.GetPromise();
		}

		public static implicit operator T(AsyncBuilder<T> obj)
		{
			return default(T);
		}

		public static AsyncBuilder<T> operator +(AsyncBuilder<T> builder, Func<T> func)
		{
			return builder;
		}

		public static AsyncBuilder<T> operator +(AsyncBuilder<T> builder, Func<IPromise<T>> func)
		{
			return builder;
		}
	}
}
