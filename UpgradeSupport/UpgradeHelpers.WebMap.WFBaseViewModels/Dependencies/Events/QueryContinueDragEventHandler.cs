namespace UpgradeHelpers.Events
{
	// Summary:
	//     Represents a method that will handle the routed events that enables a drag-and-drop
	//     operation to be canceled by the drag source, for example System.Windows.UIElement.QueryContinueDrag.
	//
	// Parameters:
	//   sender:
	//     The object where the event handler is attached.
	//
	//   e:
	//     The event data.
	public delegate void QueryContinueDragEventHandler(object sender, QueryContinueDragEventArgs e);
}
