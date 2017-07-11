using System;
using System.Diagnostics;
using System.Threading;
using System.Web.Mvc;
using UpgradeHelpers.WebMap.Server.Common;

namespace UpgradeHelpers.WebMap.Server
{
    public class PromisesActionFilter : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
            //Execute all Resolved promises, if is not in modalExecuting;
            ViewManager.Instance.FulfillPromises();
        }
    }
	public class ViewManagerRequestStartAndEndActionFilter : ActionFilterAttribute, IExceptionFilter
	{
		Stopwatch st = new Stopwatch();
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			st.Restart();
			TraceUtil.TraceInformation(">>>>>>>>>>>>>>>>> REQUEST START for URL [{0}] SessionId [{1}] ThreadID [{2}]", filterContext.HttpContext.Request.Url, filterContext.HttpContext.Session!=null?filterContext.HttpContext.Session.SessionID:"no session", Thread.CurrentThread.ManagedThreadId);
			base.OnActionExecuting(filterContext);
		}


		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			base.OnActionExecuted(filterContext);
			ViewManager.Instance.ExecuteAnyPendingWork();
		}

		public override void OnResultExecuting(ResultExecutingContext filterContext)
		{
			base.OnResultExecuting(filterContext);
            ViewManager.Instance.WaitForAsyncActions();
            WebMapLifeCycle.EndRequest();
		}

		//Init is not required because on first access StateManager will be created
		//And it is a per-request item
		public override void OnResultExecuted(ResultExecutedContext filterContext)
		{

			if (filterContext.Exception == null)
			{
				if (StateManager.IsAvailable)
				{
                    var session = filterContext.HttpContext.Session;
                    if (session != null)
                    {
                        var sessionId = session.SessionID;
                        var currentURL = filterContext.HttpContext.Request.Url;
                        WebMapHttpModule.LockSessionRequests(sessionId);
                        base.OnResultExecuted(filterContext);
                        Trace.TraceInformation(">>>>>>>>>>>>>>>>> REQUEST END for URL [{1}]. Elapsed action processing time was {0} ms", st.ElapsedMilliseconds, currentURL);
                        st.Stop();
                        ViewManager.Instance.ExecParallel(() =>
                        {
                            try
                            {
                                var sw = new Stopwatch();
                                sw.Start();
                                StateManager.Current.Persist();
                                sw.Stop();
                                Trace.TraceInformation(">>>>>>>>>>>>>>>>> PERSIST END for URL [{1}]. Elapsed action processing time was {0} ms", sw.ElapsedMilliseconds, currentURL);
                            }
                            finally
                            {
                            //We need to be sure that we clean as much as possible. One reference an object could trap everything.
                            ViewManager.Instance.Dispose();
                                StateManager.Current.Dispose();
                                UpgradeHelpers.Helpers.StaticContainer.instance = null;
                                WebMapHttpModule.UnlockSessionRequests(sessionId);
                            }
                        }, false);
                    }
					
				}
			}
		}

		public void OnException(ExceptionContext filterContext)
		{
			//If an exception occurs during an Ajax call
			//we would return it, so the front end app
			//and handle it
			if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
			{
                Debug.WriteLine("Unhandled Exception occured" + filterContext.Exception.Message);
                Debug.WriteLine(filterContext.Exception.StackTrace);
                filterContext.ExceptionHandled = true;
				filterContext.Result = new JsonResult() { Data = new { ErrorOcurred = true, ExMessage = filterContext.Exception.Message, ExStackTrace = filterContext.Exception.StackTrace } };
			}
		}
	}
}