using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace UpgradeHelpers.WebMap.Server
{
    public static class MEFManager
    {


        static string GetAssemblyDirectory(System.Reflection.Assembly assembly)
        {
                string codeBase = assembly.CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return System.IO.Path.GetDirectoryName(path);
        }
        internal static IPlatformInitializer PlatformInitializer()
        {
            
            CompositionContainer _container;
            //An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog();
            //Adds all the parts found in the same assembly as the Program class
            catalog.Catalogs.Add(new DirectoryCatalog(GetAssemblyDirectory(typeof(MEFManager).Assembly),"UpgradeHelpers.WebMap.Server.*"));

            //Create the CompositionContainer with the parts in the catalog
            _container = new CompositionContainer(catalog);
            //Fill the imports of this object
            try
            {
                var value = _container.GetExports<IPlatformInitializer>().FirstOrDefault();
                if (value != null)
                    return value.Value;
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
            return null;
        }


    }
}
