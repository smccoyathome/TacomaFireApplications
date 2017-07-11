namespace UpgradeHelpers.Events
{
	// Summary:
	//     Represents the method that will handle System.Windows.Threading.DispatcherHooks
	//     related events.
	//
	// Parameters:
	//   sender:
	//     The source of the event.
	//
	//   e:
	//     The event data.
	public delegate void DispatcherHookEventHandler(object sender, DispatcherHookEventArgs e);
}
