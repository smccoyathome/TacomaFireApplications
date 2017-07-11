using System;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Events
{
	// Summary:
	//     Provides data for several of the events that are associated with the System.Windows.Input.Stylus
	//     class.
	public class StylusEventArgs : InputEventArgs
    {
        // Summary:
        //     Initializes a new instance of the System.Windows.Input.StylusEventArgs class.
        //
        // Parameters:
        //   stylus:
        //     The stylus to associate with the event.
        //
        //   timestamp:
        //     The time when the event occurs.
        public StylusEventArgs(StylusDevice stylus, int timestamp) :
            base(stylus, timestamp)
        {
            throw new NotImplementedException();
        }

        // Summary:
        //     Gets a value that indicates whether the stylus is in proximity to, but not
        //     touching, the digitizer.
        //
        // Returns:
        //     true if the stylus is in proximity to, but not touching, the digitizer; otherwise,
        //     false.
        public bool InAir { get { throw new NotImplementedException(); } }
        //
        // Summary:
        //     Gets a value that indicates whether the stylus in inverted.
        //
        // Returns:
        //     true if the stylus is inverted; otherwise, false.
        public bool Inverted { get { throw new NotImplementedException(); } }
        //
        // Summary:
        //     Gets the System.Windows.Input.StylusDevice that represents the stylus.
        //
        // Returns:
        //     The System.Windows.Input.StylusDevice that represents the stylus.
        public StylusDevice StylusDevice { get { throw new NotImplementedException(); } }

        // Summary:
        //     Gets the position of the stylus.
        //
        // Parameters:
        //   relativeTo:
        //     The System.Windows.IInputElement that the (x,y) coordinates are mapped to.
        //
        // Returns:
        //     A System.Windows.Point that represents the position of the stylus, based
        //     on the coordinates of relativeTo.
        public Point GetPosition(IInputElement relativeTo)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Returns a System.Windows.Input.StylusPointCollection that contains System.Windows.Input.StylusPoint
        //     objects relative to the specified input element.
        //
        // Parameters:
        //   relativeTo:
        //     The System.Windows.IInputElement to which the (x,y) coordinates in the System.Windows.Input.StylusPointCollection
        //     are mapped.
        //
        // Returns:
        //     A System.Windows.Input.StylusPointCollection that contains System.Windows.Input.StylusPoint
        //     objects collected in the event.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     relativeTo is neither System.Windows.UIElement or System.Windows.FrameworkContentElement.
        public StylusPointCollection GetStylusPoints(IInputElement relativeTo)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Returns a System.Windows.Input.StylusPointCollection that uses the specified
        //     System.Windows.Input.StylusPointDescription and contains System.Windows.Input.StylusPoint
        //     objects relating to the specified input element.
        //
        // Parameters:
        //   relativeTo:
        //     The System.Windows.IInputElement to which the (x,y) coordinates in the System.Windows.Input.StylusPointCollection
        //     are mapped.
        //
        //   subsetToReformatTo:
        //     The System.Windows.Input.StylusPointDescription to be used by the System.Windows.Input.StylusPointCollection.
        //
        // Returns:
        //     A System.Windows.Input.StylusPointCollection that contains System.Windows.Input.StylusPoint
        //     objects collected during an event.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     relativeTo is neither System.Windows.UIElement or System.Windows.FrameworkContentElement.
        public StylusPointCollection GetStylusPoints(IInputElement relativeTo, StylusPointDescription subsetToReformatTo)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Invokes event handlers in a type-specific way, which can increase event system
        //     efficiency.
        //
        // Parameters:
        //   genericHandler:
        //     The generic handler to call in a type-specific way.
        //
        //   genericTarget:
        //     The target to call the handler on.
        protected override void InvokeEventHandler(Delegate genericHandler, object genericTarget)
        {
            throw new NotImplementedException();
        }
    }
}
