namespace UpgradeHelpers.Events
{
	// Summary:
	//     Represents the method that will handle the System.Windows.UIElement.LostKeyboardFocus
	//     and System.Windows.UIElement.GotKeyboardFocus routed events, as well as related
	//     attached and Preview events.
	//
	// Parameters:
	//   sender:
	//     The object where the event handler is attached.
	//
	//   e:
	//     The event data.
	public delegate void KeyboardFocusChangedEventHandler(object sender, KeyboardFocusChangedEventArgs e);
}
