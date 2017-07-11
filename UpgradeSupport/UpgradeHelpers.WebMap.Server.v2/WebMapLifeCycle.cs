using System;
using System.IO;
using UpgradeHelpers.Helpers;

namespace UpgradeHelpers.WebMap.Server
{
    public class WebMapLifeCycle
    {

        internal static void ClearInstanceVariables()
        {
            StateManager.Current = null;
        }

        /// <summary>
        ///     Must be invoked before starting a request to init tracking of view models and other
        ///     structures
        /// </summary>
        public static void StartRequest(string jsonRequest = null, Func<TextReader> DefaultRequestProvider = null)
        {
            //Clearing singleton thread static variables. They are also cleared on Request End using an HttpModule
            StateManager.Current = null;
            ViewManager._instance = null;
            //Then we sync with any changes from client

			StaticContainer.SharedItems = null;

            //We clear orphans here for security as well as in on 
            //Persist
            StateManager.Current.ClearOrphans();
            ViewManager.Instance.State.Start();
            StateManager.Current.SyncronizeWithChangesFromClient(jsonRequest, DefaultRequestProvider);
            
        }

        /// <summary>
        ///     Must be invoked after the request has been executed to free any pending resources
        ///     structures
        ///    The view state delta result will be cached on the EndStateDelta field
        /// </summary>
        public static void EndRequest()
        {
            var st = new System.Diagnostics.Stopwatch();
            st.Start();
            var stateManager = StateManager.Current;
            var viewManager = ViewManager.Instance;
			//Resolve surrogates dependencies.
            stateManager.surrogateManager._surrogateDependencyManager.ProcessDependencies();

            //Lets free the object with the last request
            stateManager.lastRequestFromClient = null;

            //No more events can be triggered at this point
            //The request has ended and therefore no more code should be executed related to events
            if (viewManager.Events != null)
                viewManager.Events.Suspend();

			if (StaticContainer.SharedItems != null)
			{
				StaticContainer.SharedItems.Dispose();
				StaticContainer.SharedItems = null;
			}
            stateManager.HandleOrphans();
            stateManager.PageManager.CleanUpPages(); //Removes the Pages that reference NON attached objects
			stateManager.TryRemoveObjectThatInThePastHadValidReferences();

            viewManager.EndStateDelta = viewManager.State.End();
            viewManager.State.PruneOneWayCommands();
			viewManager.Events.Reset();
            st.Stop();
            System.Diagnostics.Trace.TraceInformation(">>>>>>>>>>>>>>>>> REQUEST WEBMAP END REQUEST " + st.ElapsedMilliseconds);
        }
    }
}
