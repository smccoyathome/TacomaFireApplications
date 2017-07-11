namespace WebSite
{
	public partial class MvcApplication : System.Web.HttpApplication
	{
		/**
		 * The default Session comparer uses a culture dependant comparer. This might affect performance.
		 * The following method changes the default comparer to use an Ordinal one.
		 */
		private void UpdateSessionComparerForPerformance()
		{

			var session = System.Web.HttpContext.Current.Session;
			var sessionContainer = session.GetType().GetProperty("Container", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(session);
			var sessionItems = sessionContainer.GetType().GetField("_sessionItems", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(sessionContainer);
			var comparerField = sessionItems.GetType().GetProperty("Comparer", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
			comparerField.SetValue(sessionItems, System.StringComparer.Ordinal);
		}

		protected void Application_Start()
		{
		}

		protected void Session_Start()
		{
			UpdateSessionComparerForPerformance();
		}
	}
}

