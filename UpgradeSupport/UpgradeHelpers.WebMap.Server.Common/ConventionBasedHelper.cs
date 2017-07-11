using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server
{
	public static class ConventionBasedHelper
	{
		internal static IIocContainer Container;

		public static ActionResult DefaultEventHandlerBasedOnConventions(Type refType, string id, string form, IStateObject viewFromClient,
		                                                                 string eventSender)
		{
			string classForLogic = string.Format("{0}.{1}", refType.Namespace, form);
			Type classType = refType.Assembly.GetType(classForLogic, false);
			if (classType != null)
			{
				////Get Reflection reference to static method Create

				//var createMethod = classType.BaseType.GetMethod("Create");
				MethodInfo method = classType.GetMethod(id, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

				if (method != null)
				{
					//TODO StateManager.Instance.Save(viewFromClient);
					object instance = Container.Resolve(refType,null);


					int lastUnderscode = method.Name.LastIndexOf("_");
					string propertyName = method.Name.Substring(0, lastUnderscode);


					object argEventSender = viewFromClient;
					PropertyInfo prop = viewFromClient.GetType().GetProperty(propertyName);
					if (prop != null)
					{
						argEventSender = prop.GetValue(viewFromClient, null);
						if (argEventSender != null && typeof (IList<>).IsAssignableFrom(prop.PropertyType))
						{
							//Control array
							int index = 0;
							if (int.TryParse(eventSender, out index))
							{
								argEventSender = ((IList) argEventSender)[index];
							}
						}
					}

					method.Invoke(instance, new[] {argEventSender, null});
				}
				return new AppChanges();
			}
			else
			{
				return new JsonResult {Data = "NotAHandler", ContentType = null, ContentEncoding = null, JsonRequestBehavior = JsonRequestBehavior.DenyGet};
			}
		}
	}
}