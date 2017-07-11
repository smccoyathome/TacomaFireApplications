namespace UpgradeHelpers.Events
{
	// Summary:
	//     Represents the method that will handle System.Windows.Input.InputManager.PreNotifyInput
	//     and System.Windows.Input.InputManager.PostNotifyInput events.
	//
	// Parameters:
	//   sender:
	//     The source of the event.
	//
	//   e:
	//     The event data.
	public delegate void NotifyInputEventHandler(object sender, NotifyInputEventArgs e);
}
