namespace UpgradeHelpers.Events
{
	// Summary:
	//     Represents the method that will handle various routed events that do not
	//     have specific event data beyond the data that is common for all routed events.
	//
	// Parameters:
	//   sender:
	//     The object where the event handler is attached.
	//
	//   e:
	//     The event data.
	public delegate void RoutedEventHandler(object sender, RoutedEventArgs e);
}
