using System;

namespace UpgradeHelpers.Interfaces
{
    /// <summary>
    /// Defines an object that can generate promises to be executed in next server request. A promise
    /// allows to cut code execution in order to allow end user interaction and then execute a piece of
    /// code depending on user input.  Common usages of promises include:
    /// <list type="bullet">
    /// <item>Modal or dialog like views.</item>
    /// <item>Messages box requesting for user input such as action confirmiations.</item>
    /// </list> 
    /// 
    /// </summary>
    /// <seealso cref="IViewManager"/>
    /// <seealso cref="UpgradeHelpers.WebMap.Controls.Controllers.ResumeOperationController"/>
    public interface IPromise
    {
        /// <summary>
		/// Add a resolved callback that chains a non-value promise.
        /// </summary>
        /// <param name="code">The code to execute next server request.</param>
        /// <returns>An <c>IPromise</c> object so a new promises can be chained to just created one.</returns>
		IPromise Then(Action code);

		IPromise Then<T>(IPromiseCollectionInfo<T> collectionInfo, Action<T> body);

		IPromise Then(Func<bool> condition, Action body, Action increment);

		IPromise Then<TP>(Action<TP> code);

		IPromise ThenWithLogic(Action<ILogicWithViewModel<IViewModel>> code);

		IPromise<TR> Then<TP, TR>(Func<TP, TR> code);

		IPromise<TR> ThenWithLogic<TP, TR>(Func<ILogicWithViewModel<IViewModel>, TP, TR> code);

		IPromise<TR> Then<TR>(Func<TR> code);

		IPromise<TR> ThenWithLogic<TR>(Func<ILogicWithViewModel<IViewModel>, TR> code);

		IPromise<TR> ResolvedThen<TR>(TR value);

		/// <summary>
		/// Handle errors for the promise. 
		/// </summary>
		IPromise Fail(Action<Exception> onRejected);

		/// <summary>
		/// Handle errors for the promise. 
		/// </summary>
		IPromise<TR> Fail<TR>(Func<Exception, TR> onRejected);

		IPromise Always(Action<Exception> onRejected);

		IPromise<TR> Always<TR>(Func<Exception, TR> onRejected);

	}

	public interface IPromise<T> : IPromise
	{
		T ResolvedValue { get; set; }
    }
}