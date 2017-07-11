using System.Reflection;
namespace WebSite
{
	public class RegisterVirtualPathProvider
	{
        static ResourceVirtualPathProvider.ResourceCacheControl NO_CACHE = new ResourceVirtualPathProvider.ResourceCacheControl() { Cacheability = System.Web.HttpCacheability.NoCache }; 
        static ResourceVirtualPathProvider.ResourceCacheControl CACHE_CONTROL = new ResourceVirtualPathProvider.ResourceCacheControl() { Cacheability = System.Web.HttpCacheability.Public, MaxAge = 60 * 15 };
        public static void AppInitialize()
		{
          
            //By default, we scan all non system assemblies for embedded resources
            System.Collections.Generic.List<Assembly> assemblies = new System.Collections.Generic.List<Assembly>();
            foreach(Assembly a in System.Web.Compilation.BuildManager.GetReferencedAssemblies())
            {
                  if (  a.GetName().Name.Equals("UpgradeHelpers.WebMap.Controls") ||
                        a.GetName().Name.Equals("UpgradeHelpers.WebMap.Client") ||
                        (!a.GetName().Name.StartsWith("System") && !a.GetName().Name.StartsWith("UpgradeHelpers") &&
                         !a.GetName().Name.StartsWith("Microsoft"))) {
                      assemblies.Add(a);
                  }
            }


            var pathProvider = new ResourceVirtualPathProvider.Vpp(assemblies.ToArray())
            {
                //you can do a specific assembly registration too. If you provide the assemly source path, it can read
                //from the source file so you can change the content while the app is running without needing to rebuild
                // { typeof(SomeAssembly.SomeClass).Assembly, @"..\SomeAssembly"}
            };

            
            pathProvider.CacheControl = (ResourceVirtualPathProvider.Resource r) =>
            {
                //Uncomment to enable caching return CACHE_CONTROL;
                return NO_CACHE;
            };
            System.Web.Hosting.HostingEnvironment.RegisterVirtualPathProvider(pathProvider);
		}
	}
}