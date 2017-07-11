using System;
using System.Collections.Generic;
using System.Data;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.WebMap.Server.Interfaces;

namespace UpgradeHelpers.Interfaces
{
	public delegate DataTable DataSourceProviderDelegate();


	public static class ViewManagerExtensions
	{
		public static IPromise<DialogResult> ShowMessage(this IViewManager vm, string message, string caption = "",
			BoxButtons buttons = BoxButtons.OK, BoxIcons icons = BoxIcons.None,
			string promptMessage = "", bool inputRequest = false)
		{
			//If the message box just has an OK button there is no need to register a promise
			bool registerPromise = buttons != BoxButtons.OK;

			var promise = vm.ExecOnClient<DialogResult>("msg",
				new {text = message, caption, buttons, icons, promptMessage, inputRequest}, registerPromise);

			if (buttons == BoxButtons.OK && promise != null)
			{
				promise.ResolvedValue = DialogResult.OK;
			}

			return promise;
		}




		public static IPromise<string> InputBox(this IViewManager vm, string prompt, string title = "",
			string defaultResponse = "")
		{
			return (IPromise<string>) vm.ExecOnClient<string>("inputbox", new {prompt, title, defaultResponse});
		}
	}


	public interface IViewManager
	{
		[Obsolete("This Property stays for backward compatibility, but is going to be removed for future implementations")]
		DialogResult InteractionResult { get; set; }

		[Obsolete("This Method stays for backward compatibility, but is going to be removed for future implementations")]
		IPromise Then(Action code);

		string RequestedInput { get; set; }
		IEnumerable<IViewModel> LoadedViews { get; }
		IEventAggregator Events { get; }
		IAsyncBuilderManager AsyncBuilderManager { get; }

        IPromise<DialogResult> NavigateToView(ILogicWithViewModel<IViewModel> logic, bool isModal = false);

		bool IsViewInLoadedViews(IViewModel uniqueId);

		IStateObject GetTopLevelObject(IStateObject uniqueId);

		ILogicView<IViewModel> GetTopLevelForm(IStateObject uniqueId);

		IPromise<T> ExecOnClient<T>(string commandId, object parameters, bool registerPromise = true, bool isOneWay=false);

		IEnumerable<ILogicView<IViewModel>> GetOpenForms();

		ILogicView<IViewModel> GetOpenFormAt(int index);

		int OpenFormsCount { get; }

        IPromise Async(Action action);

		IPromise Async<TR>(Action<TR> action);

		IPromise<TR> Async<TR>(Func<TR> action);

		IPromise<TR> Async<TP, TR>(Func<TP, TR> action);

		TR PendingResult<TR>();

		void PendingResult();

		/// <summary>
		/// Disposes a view.
		/// It will trigger the Closed and Closing events as well.
		/// </summary>
		/// <param name="logic">The logic object that references the ViewModel that will be disposed</param>
		/// <param name="later">If true, the form will be disposed at the end of the request processing</param>
		void DisposeView(ILogicWithViewModel<IViewModel> logic, bool later = false);
        void SetCurrent(IDependentViewModel item, IDependentViewModel parent=null);

        void SetCurrentView(IViewModel item);

        /// <summary>
        ///     Hides the give view
        /// </summary>
        /// <param name="view">The view to hide</param>
        void HideView(ILogicWithViewModel<IViewModel> view);

		void ResumePendingOperation(string dialogResult, string requestedInput);

		/// <summary>
		///     Gets the <c>IDataPageableViewModel</c> object matching the given control id.
		/// </summary>
		/// <param name="controlId">The id of the control to get</param>
		/// <returns></returns>
		IDataPageableViewModel GetDataPageableViewModel(string controlId);

		IStateObject[] GetCollectionPage(string collectionUid, int take, int skip, out int total);

		IStateObject GetObject(string uniqueID);

		/// <summary>
		///     Get the ParentViewModel
		/// </summary>
		/// <param name="getUniqueIdentifier">Function to calculate the parent ViewModel unique id</param>
		/// <returns></returns>
		[Obsolete]
		IStateObject GetParentViewModel(Func<string> getUniqueIdentifier);
		/// <summary>
		///     Get the parent for an state object
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		IStateObject GetParent(IStateObject obj);

        /// <summary>
        /// Dictionary that contains the visual parent of the control which is found by GetVisualParent method from ControlExtender.cs
        /// </summary>
        /// <returns></returns>
        Dictionary<string, IStateObject> GetVisualParentDictionary();

        void ExecParallel(Action code, bool wait = true);

        void ExecParallel(List<Action> code, Action callback);


        System.Threading.SynchronizationContext CurrentSyncronizationContext { get; }
    }
}