using System;
using System.Security;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Represents a tablet pen used with a Tablet PC.
	public sealed class StylusDevice : InputDevice
    {
        // Summary:
        //     Gets the System.Windows.PresentationSource that reports current input for
        //     the stylus.
        //
        // Returns:
        //     The System.Windows.PresentationSource that reports current input for the
        //     stylus.
        public override PresentationSource ActiveSource { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the element that captured the stylus.
        //
        // Returns:
        //     The System.Windows.IInputElement that captured the stylus.
        public IInputElement Captured { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the System.Windows.IInputElement that the pointer is positioned over.
        //
        // Returns:
        //     The element the pointer is over.
        public IInputElement DirectlyOver { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the identifier for the stylus device.
        //
        // Returns:
        //     The identifier for the stylus device.
        public int Id { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets whether the tablet pen is positioned above, yet not in contact with,
        //     the digitizer.
        //
        // Returns:
        //     true if the pen is positioned above, yet not in contact with, the digitizer;
        //     otherwise, false. The default is false.
        public bool InAir { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets a value that indicates whether the tablet pen is in range of the digitizer.
        //
        // Returns:
        //     true if the pen is within range of the digitizer; otherwise, false. The default
        //     is false.
        public bool InRange { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets a value that indicates whether the secondary tip of the stylus is in
        //     use.
        //
        // Returns:
        //     true if the secondary tip of the stylus is in use; otherwise, false. The
        //     default is false.
        public bool Inverted { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the name of the stylus.
        //
        // Returns:
        //     The name of the stylus.
        public string Name { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the stylus buttons on the stylus.
        //
        // Returns:
        //     A reference to a System.Windows.Input.StylusButtonCollection object representing
        //     all of the buttons on the stylus.
        public StylusButtonCollection StylusButtons { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the System.Windows.Input.TabletDevice representing the digitizer associated
        //     with the current System.Windows.Input.StylusDevice.
        //
        // Returns:
        //     The System.Windows.Input.TabletDevice represents the digitizer associated
        //     with the current System.Windows.Input.StylusDevice.
        public TabletDevice TabletDevice { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the element that receives input.
        //
        // Returns:
        //     The System.Windows.IInputElement object that receives input.
        public override IInputElement Target { get { throw new NotImplementedException(); } }

        // Summary:
        //     Binds input from the stylus to the specified element.
        //
        // Parameters:
        //   element:
        //     The element to which the stylus is bound.
        //
        // Returns:
        //     true if the input element is captured successfully; otherwise, false. The
        //     default is false.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     element is null.
        //
        //   System.InvalidOperationException:
        //     element is neither System.Windows.UIElement or System.Windows.FrameworkContentElement.
        public bool Capture(IInputElement element)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Binds the stylus to the specified element.
        //
        // Parameters:
        //   element:
        //
        //   captureMode:
        //     One of the System.Windows.Input.CaptureMode values.
        //
        // Returns:
        //     true if the input element is captured successfully; otherwise, false. The
        //     default is false.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     element or captureMode is null.
        //
        //   System.InvalidOperationException:
        //     element is neither System.Windows.UIElement or System.Windows.FrameworkContentElement.
        public bool Capture(IInputElement element, CaptureMode captureMode)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Gets the position of the stylus.
        //
        // Parameters:
        //   relativeTo:
        //     The System.Windows.IInputElement to which the (x,y) coordinates are mapped.
        //
        // Returns:
        //     A System.Windows.Point that represents the position of the stylus, in relation
        //     to relativeTo.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     relativeTo is neither System.Windows.UIElement or System.Windows.FrameworkContentElement.
        [SecurityCritical]
        public Point GetPosition(IInputElement relativeTo)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Returns a System.Windows.Input.StylusPointCollection that contains System.Windows.Input.StylusPoint
        //     objects collected from the stylus.
        //
        // Parameters:
        //   relativeTo:
        //     The System.Windows.IInputElement to which the (x,y) coordinates in the System.Windows.Input.StylusPointCollection
        //     are mapped.
        //
        // Returns:
        //     A System.Windows.Input.StylusPointCollection that contains System.Windows.Input.StylusPoint
        //     objects that the stylus collected.
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
        //     Returns a System.Windows.Input.StylusPointCollection that contains System.Windows.Input.StylusPoint
        //     objects collected from the stylus. Uses the specified System.Windows.Input.StylusPointDescription.
        //
        // Parameters:
        //   relativeTo:
        //     The System.Windows.IInputElement to which the (x y) coordinates in the System.Windows.Input.StylusPointCollection
        //     are mapped.
        //
        //   subsetToReformatTo:
        //     The System.Windows.Input.StylusPointDescription to be used by the System.Windows.Input.StylusPointCollection.
        //
        // Returns:
        //     A System.Windows.Input.StylusPointCollection that contains System.Windows.Input.StylusPoint
        //     objects collected from the stylus.
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
        //     Synchronizes the cursor and the user interface.
        [SecurityCritical]
        public void Synchronize()
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Returns the name of the stylus device.
        //
        // Returns:
        //     The name of the System.Windows.Input.StylusDevice.
        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
