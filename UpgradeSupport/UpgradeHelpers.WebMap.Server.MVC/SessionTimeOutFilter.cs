using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace UpgradeHelpers.WebMap.Server
{

    public class SessionExpireFilterAttribute : ActionFilterAttribute
    {

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			HttpContext ctx = HttpContext.Current;
			if (ctx != null)
			{
				var request = ctx.Request;
				var session = ctx.Session;

				if (request.HttpMethod == "POST")
				{
					if (session != null)
					{
						if (!StillValidSession(session, request))
						{
							var result = new JsonResult { Data = new { SessionTimeOut = true } };
							filterContext.Result = result;
							return;
						}
					}
				}
			}
			base.OnActionExecuting(filterContext);
		}

	    private bool StillValidSession(HttpSessionState session, HttpRequest request)
	    {
			if (session.IsNewSession)
			{
				//If it says it is a new session, but an existing cookie exists then it must have timed out
				string sessionCookie = request.Headers["Cookie"];
				if ((null != sessionCookie) && (sessionCookie.IndexOf("ASP.NET_SessionId", System.StringComparison.Ordinal) >= 0))
					return false;
			}
		    return true;
	    }

	    public static bool StillValidSession(HttpSessionStateBase session, HttpRequestBase request)
		{
		    try
		    {
			    if (session.IsNewSession)
			    {
				    //If it says it is a new session, but an existing cookie exists then it must have timed out
				    string sessionCookie = request.Headers["Cookie"];
				    if ((null != sessionCookie) && (sessionCookie.IndexOf("ASP.NET_SessionId", System.StringComparison.Ordinal) >= 0))
					    return false;
			    }
		    }
		    catch
		    {
		    }
		    return true;
		}
    }

}