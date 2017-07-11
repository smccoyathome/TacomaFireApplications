using System;
using UpgradeHelpers.WebMap.Server;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Collections;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server
{
    //Helper class to Show TestUtils output on Debug Console
    class TextWriterDebug : System.IO.TextWriter
    {
        public override System.Text.Encoding Encoding
        {
            get { return System.Text.Encoding.Default; }
        }

        //public override System.IFormatProvider FormatProvider
        //{ get; }
        //public override string NewLine
        //{ get; set; }

        public override void Close()
        {
            System.Diagnostics.Debug.Close();
            base.Close();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public override void Flush()
        {
            System.Diagnostics.Debug.Flush();
            base.Flush();
        }

        public override void Write(bool value)
        {
            System.Diagnostics.Debug.Write(value);
        }

        public override void Write(char value)
        {
            System.Diagnostics.Debug.Write(value);
        }

        public override void Write(char[] buffer)
        {
            System.Diagnostics.Debug.Write(buffer);
        }

        public override void Write(decimal value)
        {
            System.Diagnostics.Debug.Write(value);
        }

        public override void Write(double value)
        {
            System.Diagnostics.Debug.Write(value);
        }

        public override void Write(float value)
        {
            System.Diagnostics.Debug.Write(value);
        }

        public override void Write(int value)
        {
            System.Diagnostics.Debug.Write(value);
        }

        public override void Write(long value)
        {
            System.Diagnostics.Debug.Write(value);
        }

        public override void Write(object value)
        {
            System.Diagnostics.Debug.Write(value);
        }

        public override void Write(string value)
        {
            System.Diagnostics.Debug.Write(value);
        }

        public override void Write(uint value)
        {
            System.Diagnostics.Debug.Write(value);
        }

        public override void Write(ulong value)
        {
            System.Diagnostics.Debug.Write(value);
        }

        public override void Write(string format, object arg0)
        {
            System.Diagnostics.Debug.Write(string.Format(format, arg0));
        }

        public override void Write(string format, params object[] arg)
        {
            System.Diagnostics.Debug.Write(string.Format(format, arg));
        }

        public override void Write(char[] buffer, int index, int count)
        {
            string x = new string(buffer, index, count);
            System.Diagnostics.Debug.Write(x);
        }

        public override void Write(string format, object arg0, object arg1)
        {
            System.Diagnostics.Debug.Write(string.Format(format, arg0, arg1));
        }

        public override void Write(string format, object arg0, object arg1, object arg2)
        {
            System.Diagnostics.Debug.Write(string.Format(format, arg0, arg1, arg2));
        }

        public override void WriteLine()
        {
            System.Diagnostics.Debug.WriteLine(string.Empty);
        }

        public override void WriteLine(bool value)
        {
            System.Diagnostics.Debug.WriteLine(value);
        }

        public override void WriteLine(char value)
        {
            System.Diagnostics.Debug.WriteLine(value);
        }

        public override void WriteLine(char[] buffer)
        {
            System.Diagnostics.Debug.WriteLine(buffer);
        }

        public override void WriteLine(decimal value)
        {
            System.Diagnostics.Debug.WriteLine(value);
        }

        public override void WriteLine(double value)
        {
            System.Diagnostics.Debug.WriteLine(value);
        }

        public override void WriteLine(float value)
        {
            System.Diagnostics.Debug.WriteLine(value);
        }

        public override void WriteLine(int value)
        {
            System.Diagnostics.Debug.WriteLine(value);
        }

        public override void WriteLine(long value)
        {
            System.Diagnostics.Debug.WriteLine(value);
        }

        public override void WriteLine(object value)
        {
            System.Diagnostics.Debug.WriteLine(value);
        }

        public override void WriteLine(string value)
        {
            System.Diagnostics.Debug.WriteLine(value);
        }

        public override void WriteLine(uint value)
        {
            System.Diagnostics.Debug.WriteLine(value);
        }

        public override void WriteLine(ulong value)
        {
            System.Diagnostics.Debug.WriteLine(value);
        }

        public override void WriteLine(string format, object arg0)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(format, arg0));
        }

        public override void WriteLine(string format, params object[] arg)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(format, arg));
        }

        public override void WriteLine(char[] buffer, int index, int count)
        {
            string x = new string(buffer, index, count);
            System.Diagnostics.Debug.WriteLine(x);

        }

        public override void WriteLine(string format, object arg0, object arg1)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(format, arg0, arg1));
        }

        public override void WriteLine(string format, object arg0, object arg1, object arg2)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(format, arg0, arg1, arg2));
        }

    } // Ends class TextWriterDebug 
	public class TestUtils
	{


		public TestUtils ()
		{
		}

        public object GetObjectByUniqueID(string UniqueID)
        {
            return StateManager.Current.GetObject(UniqueID);
        }


		public static TestStorageInfo DumpStorageContents(TextWriter writer=null)
		{
            writer = writer ?? new TextWriterDebug();
			var tempdic = StorageManagerFactory.CreateInstance (StateManager.Current, StateManager.Current.surrogateManager) as TempDictStorageManager;
			return tempdic.Dump (writer);		
		}




		public static void DumpStateCacheCurrentContents(TextWriter writer = null)
		{
            writer = writer ?? new TextWriterDebug();
			var table = StateManager.Current._cache;
			writer.WriteLine("StateCache Current");
			writer.WriteLine("=================================");
			writer.WriteLine("Entries:" + table.Count);

			foreach (var key in table.Keys)
			{
				var value = table.Get(key);
				writer.WriteLine("[ {0}, {1} ]", key, table.Get(key));
			}



		}


		public static void SimulateStartOfRequest(string jsonRequest) {
			WebMapLifeCycle.StartRequest (jsonRequest);
		}

		public static string lastResult;
		/// <summary>
		/// Simulates the end of request.
		/// That means persisting the StateCache
		/// and destroy the requesttimestorage
		/// </summary>
		public static void SimulateEndOfRequest() {

			var strWriter = new StringWriter();
			StateManager.GenerateAppChanges (strWriter, x => x);
			lastResult = strWriter.ToString();
			ViewManager.Instance.FulfillPromises();
			WebMapLifeCycle.EndRequest();
            ViewManager.Instance.FulfillPromises();
			if (StateManager.IsAvailable) {
				StateManager.Current.Persist();
			}
            WebMapLifeCycle.ClearInstanceVariables();
        }

		private static bool initialized = false;
		public static void SetupTestEnvironment(params Assembly[] additionalLibraries)
		{
			if (!initialized)
			{

				initialized = true;
				StorageManagerFactory.UseTestImpl = true;
				var assemblyServerv2 = Assembly.GetAssembly(typeof(UpgradeHelpers.WebMap.Server.StateManager));

				var assemblyList = new List<Assembly>();
				assemblyList.Add(assemblyServerv2);
				assemblyList.AddRange(additionalLibraries);

				UpgradeHelpers.WebMap.Server.Bootstrapper._assembliesToExtractTypesForRegistration = assemblyList;
				UpgradeHelpers.WebMap.Server.Bootstrapper.Initialize();
                StorageManagerFactory.UseTestImpl = true;
            }
		}

		public static void ResetStorage()
		{
			StorageManagerFactory.UseTestImpl = true;
			StorageManagerFactory.ResetSingleton();

		}



        public static object GetFromStorage(string key)
        {
            var tempdic = StorageManagerFactory.CreateInstance(StateManager.Current,StateManager.Current.surrogateManager) as TempDictStorageManager;
            return tempdic.table[key];
        }
    }

    public class WebMapRequestContext : IDisposable
    {


        public Newtonsoft.Json.JsonSerializer AjaxResponseSerializer
        {
            get
            {
                return StateManager._serializer;
            }
        }

        public WebMapRequestContext(string jsonRequest="{}")
        {
            TestUtils.SimulateStartOfRequest(jsonRequest);
        }
        public void Dispose()
        {
            TestUtils.SimulateEndOfRequest();
        }


        public IViewManager ViewManager
        {
            get
            {
                return IocContainerImplWithUnity.Current.Resolve<IViewManager>();
            }
        }


        public IIocContainer Container
        {
            get
            {
                return IocContainerImplWithUnity.Current;
            }
        }
    }
}

