namespace UpgradeHelpers.Events
{
	// Summary:
	//     Represents the method that will handle the System.Windows.Threading.Dispatcher.UnhandledException
	//     event.
	//
	// Parameters:
	//   sender:
	//     The source of the event.
	//
	//   e:
	//     The event data.
	public delegate void DispatcherUnhandledExceptionEventHandler(object sender, DispatcherUnhandledExceptionEventArgs e);
}
