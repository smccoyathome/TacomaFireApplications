namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Indicates the routing strategy of a routed event.
	public enum RoutingStrategy
    {
        // Summary:
        //     The routed event uses a tunneling strategy, where the event instance routes
        //     downwards through the tree, from root to source element.
        Tunnel = 0,

        //
        // Summary:
        //     The routed event uses a bubbling strategy, where the event instance routes
        //     upwards through the tree, from event source to root.
        Bubble = 1,

        //
        // Summary:
        //     The routed event does not route through an element tree, but does support
        //     other routed event capabilities such as class handling, System.Windows.EventTrigger
        //     or System.Windows.EventSetter.
        Direct = 2
    }
}
