using System.Collections.Generic;
using System.IO;


namespace WebSite
{
	public class ExternalConfig
	{
		public static List<string> ExternalLinks = new List<string>();
		public static void RegisterLocalScripts()
		{
			try
			{
				var path = System.Web.HttpContext.Current.Server.MapPath("~/Scripts/directives");
				foreach (var file in Directory.GetFiles(path, "*.js", SearchOption.AllDirectories))
				{
					var index = file.LastIndexOf("Scripts", System.StringComparison.InvariantCulture);
					var resolved = file.Substring(index);
					ExternalLinks.Add(resolved);
				}
			}
			catch (DirectoryNotFoundException e)
			{
				//This case does not contains custom script files
			}
		}
	}
}