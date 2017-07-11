
namespace UpgradeHelpers.WebMap.Server
{
	internal class StorageManagerFactory
	{
		internal static bool UseTestImpl = false;

		internal static IStorageManager obj;

		internal static void ResetSingleton()
		{
			obj = null;
		}

		public static IStorageManager CreateInstance(StateManager stateManager, SurrogateManager surrogateManager)
		{
			if (UseTestImpl)
				return obj ?? (obj = new TempDictStorageManager());
			else
			{
				var sessionMode = System.Web.HttpContext.Current.Session.Mode;
				if (sessionMode == System.Web.SessionState.SessionStateMode.InProc)
				{
					// A new object is needed each time, otherwise when having more than 1 user and a static StorageManager the single cache for the session keys would be shared among all the active users.
					return new SessionStorageManagerInproc(stateManager, surrogateManager);
				}
				else
				{
					return new SessionStorageManager(stateManager, surrogateManager);
				}
			}
		}
	}
}