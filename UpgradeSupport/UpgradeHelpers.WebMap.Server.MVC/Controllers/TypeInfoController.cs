using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UpgradeHelpers.WebMap.Server
{
    /// <summary>
    /// This handler is used to provide metadata information to client side
    /// It is implemented as an IHttpHandler instead of a controller to avoid
    /// going thru all the MVC filters and processing.
    /// 
    /// It implements an IRouteHandler because it allows to register the handler
    /// programatically. See: http://stackoverflow.com/questions/1888016/any-way-to-add-httphandler-programatically-in-net
    /// </summary>
    public class TypeInfoHandler : IHttpHandler, IRouteHandler
    {

        const string TYPEINFOHANDLERDATA = "TypeInfoHandlerData@@#";
        static object typeinfolock = new object();
        //TODO Add to output cache [OutputCache(Duration = 6000, VaryByParam = "none", Location = System.Web.UI.OutputCacheLocation.Any)]
        public void ProcessRequest(HttpContext context)
        {
            //RequestContext requestContext
            string typeInfoTable = String.Empty;
            lock (typeinfolock)
            {

                lock (IocContainerImplWithUnity.backgroundPauser)
                {
                    System.Diagnostics.Trace.WriteLine("Background Thread Pause");
                    if (IocContainerImplWithUnity.backgroundPauser.IsSet)
                        IocContainerImplWithUnity.backgroundPauser.Reset(1);
                    else
                        IocContainerImplWithUnity.backgroundPauser.AddCount();
                }

                try
                {
                    ObjectCache cache = MemoryCache.Default;
                    typeInfoTable = cache[TYPEINFOHANDLERDATA] as string;

                    if (typeInfoTable==null)
                    {
                        cache[TYPEINFOHANDLERDATA] = typeInfoTable = LoadTypeTable();
                    }

                    var Response = context.Response;
                    //It is important to clear and set content type otherwise default for response will be text/html
                    Response.Clear();
                    Response.ContentType = "application/json";
                    var responseCache = context.Response.Cache;
                    responseCache.SetCacheability(HttpCacheability.Public);
                    responseCache.SetExpires(context.Timestamp.AddMinutes(60));
                    responseCache.VaryByParams.IgnoreParams = true;
                    context.Response.Output.Write(typeInfoTable);
                    //context.Response.End();
                }
                finally
                {
                    IocContainerImplWithUnity.backgroundPauser.Signal();
                }
            }
          //  return null;
        }

        private static string LoadTypeTable()
        {
            var res = new Dictionary<string, string>(StringComparer.Ordinal);
            TypeCacheUtils.LoadClientTypeMetadataTable();
            foreach (var item in TypeCacheUtils.ClientSideMappingInfo)
            {
                res.Add(item.Value + "", item.Key.FullName.Replace('.', '_'));
            }
            var serializer = new Newtonsoft.Json.JsonSerializer();
            var result = new Result() { DefaultsAndAlias = TypeCacheUtils.DefaultAndAliasMappings, TypesInfo = res };
            var stringWriter = new System.IO.StringWriter();
            serializer.Serialize(stringWriter, result);
            var typeInfoTable = stringWriter.ToString();
            return typeInfoTable;
        }

		[Serializable]
		public class Result
		{
			public Dictionary<string, string> TypesInfo;
			public Dictionary<string, Dictionary<string, object[]>> DefaultsAndAlias;
		}

        public bool IsReusable
        {
            get { return true; }
        }



        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return this;
        }
    }


#if DEBUG
    [SessionState(System.Web.SessionState.SessionStateBehavior.Disabled)]
    public class StatsController : Controller
    {

		[HttpGet]
		public string ViewModelAnalysisReport()
		{
			var result = new StringBuilder();
			result.AppendLine("<html><body><h1>ViewModel Analysis report </h1>");
#if DEBUG_TYPES
            TypePropertiesCache.ViewModelAnalysis = true;
			foreach (var improperTypeInfo in TypePropertiesCache.ImproperTypes)
			{
				result.AppendLine("<h2 style=\"color: red\">" + improperTypeInfo.Key.FullName + "</h2>");
				result.AppendLine("<table><tr><td>PropertyName</td><td>PropertyType</td></tr>");
				foreach (var info in improperTypeInfo.Value)
				{
					result.AppendLine(string.Format("<tr><td>{0}</td><td>{1}</td></tr>", info.Key, info.Value));
				}
				result.AppendLine("</table>");
			}

			foreach (var warningTypeInfo in TypePropertiesCache.WarningTypes)
			{
				result.AppendLine("<h2 style=\"color: orange\">" + warningTypeInfo.Key.FullName + "</h2>");
				result.AppendLine("<table><tr><td>PropertyName</td><td>PropertyType</td></tr>");
				foreach (var info in warningTypeInfo.Value)
				{
					result.AppendLine(string.Format("<tr><td>{0}</td><td>{1}</td></tr>", info.Key, info.Value));
				}
				result.AppendLine("</table>");
			}
#endif
            result.AppendLine("</body></html>");
			return result.ToString();
		}

		[HttpGet]
		public string TurnOnViewModelAnalysis()
		{
#if DEBUG_TYPES
            TypePropertiesCache.ViewModelAnalysis = true;
#endif
			return "<html><body><h1>ViewModels Analysis is now ON</h1></body></html>";
		}

		[HttpGet]
		public ActionResult TurnOffViewModelAnalysis()
		{
#if DEBUG_TYPES
            TypePropertiesCache.ViewModelAnalysis = false;
#endif
            return Json("{Stats: true}", JsonRequestBehavior.AllowGet);
		}


        [HttpGet]
        public ActionResult TurnOn()
        {
            Nocache();
            AppChangesResponse.TurnOnStatistics();
            return Json("{Stats: true}", JsonRequestBehavior.AllowGet);
        }

        private void Nocache()
        {
            HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            HttpContext.Response.Cache.SetValidUntilExpires(false);
            HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Response.Cache.SetNoStore();
        }

        [HttpGet]
        public ActionResult TurnOff()
        {
            Nocache();
            AppChangesResponse.TurnOffStatistics();
            return Json("{Stats: false}", JsonRequestBehavior.AllowGet);
        }


    }
#endif

        }
