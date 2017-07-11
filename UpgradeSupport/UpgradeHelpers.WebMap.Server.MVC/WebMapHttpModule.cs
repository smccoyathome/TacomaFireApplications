using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Web;

[assembly: PreApplicationStartMethod(typeof(UpgradeHelpers.WebMap.Server.WebMapHttpModule), "Register")]
namespace UpgradeHelpers.WebMap.Server
{
    public class WebMapHttpModule : IHttpModule
    {
        public WebMapHttpModule()
        {
        }

		/// <summary>
		/// Dynamically registers "WebMapHttpModule" into the application
		/// </summary>
		public static void Register()
		{
			DynamicModuleUtility.RegisterModule(typeof(WebMapHttpModule));
		}

		public String ModuleName
        {
            get { return "WebMapHttpModule"; }
        }

        // In the Init function, register for HttpApplication 
        // events by adding your handlers.
        public void Init(HttpApplication application)
        {
            application.BeginRequest += Application_BeginRequest;
            application.PostAcquireRequestState += application_PostAcquireRequestState;
            application.EndRequest +=
                (new EventHandler(this.Application_EndRequest));
        }


        internal static HashSet<string> pendingBackoundPersist = new HashSet<string>();
        static readonly object pendingBackoundPersistLocker = new object();
        void application_PostAcquireRequestState(object sender, EventArgs e)
        {
            var session = HttpContext.Current.Session;
            if (session != null)
            {
                var id = session.SessionID;
                bool hasToWait = false;
                do
                {
                    hasToWait = false;
                    lock (pendingBackoundPersistLocker)
                    {
                        if (pendingBackoundPersist.Contains(id))
                        {
                            hasToWait = true;
                        }
                    }
                    if (hasToWait)
                        Thread.Sleep(1);
                } while (hasToWait);
            }
        }

        private bool IsWebMapRequest(HttpContext ctx)
        {
            return ctx.Request.Headers["WM"] != null;
        }

        private void Application_BeginRequest(object sender, EventArgs e)
        {
            var application = (HttpApplication)sender;
            if (IsWebMapRequest(application.Context))
            {
                lock (IocContainerImplWithUnity.backgroundPauser)
                {
                    //System.Diagnostics.Trace.WriteLine("Background Thread Pause");
                    if (IocContainerImplWithUnity.backgroundPauser.IsSet)
                        IocContainerImplWithUnity.backgroundPauser.Reset(1);
                    else
                        IocContainerImplWithUnity.backgroundPauser.AddCount();
        }
            }
        }

        private void Application_EndRequest(Object source, EventArgs e)
        {
            ClearInstanceVariables();
            var application = (HttpApplication)source;
            if (IsWebMapRequest(application.Context))
            {
                IocContainerImplWithUnity.backgroundPauser.Signal();
                //System.Diagnostics.Trace.WriteLine("Background Thread Resume");

            }

        }

        internal static void ClearInstanceVariables()
        {
            StateManager.Current = null;
        }

        public void Dispose() { }

        internal static void LockSessionRequests(string sessionId)
        {
            lock (pendingBackoundPersistLocker)
            {
                WebMapHttpModule.pendingBackoundPersist.Add(sessionId);
            }
        }

        internal static void UnlockSessionRequests(string sessionId)
        {
            lock (pendingBackoundPersistLocker)
            {
                WebMapHttpModule.pendingBackoundPersist.Remove(sessionId);
            }
        }
    }
}