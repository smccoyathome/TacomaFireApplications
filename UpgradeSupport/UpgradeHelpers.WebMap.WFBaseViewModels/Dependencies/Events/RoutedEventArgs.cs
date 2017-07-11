using System;

namespace UpgradeHelpers.Events
{
	// Summary:
	//     Contains state information and event data associated with a routed event.
	public class RoutedEventArgs : EventArgs
    {
        // Summary:
        //     Initializes a new instance of the System.Windows.RoutedEventArgs class.
        public RoutedEventArgs()
        {
         //   throw new NotImplementedException();
        }

        //
        // Summary:
        //     Initializes a new instance of the System.Windows.RoutedEventArgs class, using
        //     the supplied routed event identifier.
        //
        // Parameters:
        //   routedEvent:
        //     The routed event identifier for this instance of the System.Windows.RoutedEventArgs
        //     class.
        public RoutedEventArgs(RoutedEvent routedEvent)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Initializes a new instance of the System.Windows.RoutedEventArgs class, using
        //     the supplied routed event identifier, and providing the opportunity to declare
        //     a different source for the event.
        //
        // Parameters:
        //   routedEvent:
        //     The routed event identifier for this instance of the System.Windows.RoutedEventArgs
        //     class.
        //
        //   source:
        //     An alternate source that will be reported when the event is handled. This
        //     pre-populates the System.Windows.RoutedEventArgs.Source property.
        public RoutedEventArgs(RoutedEvent routedEvent, object source)
        {
            throw new NotImplementedException();
        }


        // Summary:
        //     Gets or sets a value that indicates the present state of the event handling
        //     for a routed event as it travels the route.
        //
        // Returns:
        //     If setting, set to true if the event is to be marked handled; otherwise false.
        //     If reading this value, true indicates that either a class handler, or some
        //     instance handler along the route, has already marked this event handled.
        //     false.indicates that no such handler has marked the event handled.The default
        //     value is false.
        public bool Handled { get { return handled; } set { handled = value; } }

        //
        // Summary:
        //     Gets the original reporting source as determined by pure hit testing, before
        //     any possible System.Windows.RoutedEventArgs.Source adjustment by a parent
        //     class.
        //
        // Returns:
        //     The original reporting source, before any possible System.Windows.RoutedEventArgs.Source
        //     adjustment made by class handling, which may have been done to flatten composited
        //     element trees.
        public object OriginalSource { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets or sets the System.Windows.RoutedEventArgs.RoutedEvent associated with
        //     this System.Windows.RoutedEventArgs instance.
        //
        // Returns:
        //     The identifier for the event that has been invoked.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     Attempted to change the System.Windows.RoutedEventArgs.RoutedEvent value
        //     while the event is being routed.
        public RoutedEvent RoutedEvent { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets or sets a reference to the object that raised the event.
        //
        // Returns:
        //     The object that raised the event.
        public object Source { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }


        // Summary:
        //     When overridden in a derived class, provides a way to invoke event handlers
        //     in a type-specific way, which can increase efficiency over the base implementation.
        //
        // Parameters:
        //   genericHandler:
        //     The generic handler / delegate implementation to be invoked.
        //
        //   genericTarget:
        //     The target on which the provided handler should be invoked.
        protected virtual void InvokeEventHandler(Delegate genericHandler, object genericTarget)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     When overridden in a derived class, provides a notification callback entry
        //     point whenever the value of the System.Windows.RoutedEventArgs.Source property
        //     of an instance changes.
        //
        // Parameters:
        //   source:
        //     The new value that System.Windows.RoutedEventArgs.Source is being set to.
        protected virtual void OnSetSource(object source)
        {
            throw new NotImplementedException();
        }

        public bool handled { get; set; }
    }
}
