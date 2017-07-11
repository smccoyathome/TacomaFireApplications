using System;
using UpgradeHelpers.Helpers;

namespace UpgradeHelpers.Events
{
	// Summary:
	//     Represents and identifies a routed event and declares its characteristics.
	public sealed class RoutedEvent
    {
        // Summary:
        //     Gets the handler type of the routed event.
        //
        // Returns:
        //     The handler type of the routed event.
        public Type HandlerType { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the identifying name of the routed event.
        //
        // Returns:
        //     The name of the routed event.
        public string Name { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the registered owner type of the routed event.
        //
        // Returns:
        //     The owner type of the routed event.
        public Type OwnerType { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the routing strategy of the routed event.
        //
        // Returns:
        //     One of the enumeration values. The default is the enumeration default, System.Windows.RoutingStrategy.Bubble.
        public RoutingStrategy RoutingStrategy { get { throw new NotImplementedException(); } }

        // Summary:
        //     Associates another owner class with this routed event, and enables routing
        //     of the event and handling on this class.
        //
        // Parameters:
        //   ownerType:
        //     The type of the class where the routed event is added.
        //
        // Returns:
        //     The identifier field for the event. This return value should be used to set
        //     a public static read-only field that will store the identifier for the representation
        //     of the routed event on the owning class. This field must be accessible because
        //     it will be required to attach any instance handlers for the event when using
        //     the System.Windows.UIElement.AddHandler(System.Windows.RoutedEvent,System.Delegate,System.Boolean)
        //     utility method.
        public RoutedEvent AddOwner(Type ownerType)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Returns the string representation of this System.Windows.RoutedEvent.
        //
        // Returns:
        //     A string representation for this object, which is identical to the value
        //     returned by System.Windows.RoutedEvent.Name.
        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
