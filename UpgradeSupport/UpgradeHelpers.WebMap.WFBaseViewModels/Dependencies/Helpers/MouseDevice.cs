using System;
using System.Security;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Represents a mouse device.
	public abstract class MouseDevice : InputDevice
    {
        // Summary:
        //     Gets the System.Windows.PresentationSource that is reporting input for this
        //     device.
        //
        // Returns:
        //     The source of input for this device.
        public override PresentationSource ActiveSource { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the System.Windows.IInputElement that is captured by the mouse.
        //
        // Returns:
        //     The element which is captured by the mouse.
        public IInputElement Captured { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the element that the mouse pointer is directly over.
        //
        // Returns:
        //     The element the mouse pointer is over.
        public IInputElement DirectlyOver { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the state of the left mouse button of this mouse device.
        //
        // Returns:
        //     The state of the button.
        public MouseButtonState LeftButton { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     The state of the middle button of this mouse device.
        //
        // Returns:
        //     The state of the button.
        public MouseButtonState MiddleButton { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets or sets the cursor for the entire application.
        //
        // Returns:
        //     The override cursor or null if System.Windows.Input.MouseDevice.OverrideCursor
        //     is not set.
		public Cursor OverrideCursor { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the state of the right button of this mouse device.
        //
        // Returns:
        //     The state of the button.
        public MouseButtonState RightButton { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the System.Windows.IInputElement that the input from this mouse device
        //     is sent to.
        //
        // Returns:
        //     The element that receives the input.
        public override IInputElement Target { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the state of the first extended button on this mouse device.
        //
        // Returns:
        //     The state of the button.
        public MouseButtonState XButton1 { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the state of the second extended button of this mouse device.
        //
        // Returns:
        //     The state of the button.
        public MouseButtonState XButton2 { get { throw new NotImplementedException(); } }

        // Summary:
        //     Captures mouse events to the specified element.
        //
        // Parameters:
        //   element:
        //     The element to capture the mouse.
        //
        // Returns:
        //     true if the element was able to capture the mouse; otherwise, false.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     element is not a System.Windows.UIElement or System.Windows.ContentElement.
        public bool Capture(IInputElement element)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Captures mouse input to the specified element using the specified System.Windows.Input.CaptureMode.
        //
        // Parameters:
        //   element:
        //     The element to capture the mouse..
        //
        //   captureMode:
        //     The capture policy to use.
        //
        // Returns:
        //     true if the element was able to capture the mouse; otherwise, false.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     element is not a System.Windows.UIElement or System.Windows.ContentElement.
        //
        //   System.ComponentModel.InvalidEnumArgumentException:
        //     captureMode is not a valid System.Windows.Input.CaptureMode.
        [SecurityCritical]
        public bool Capture(IInputElement element, CaptureMode captureMode)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Gets the state of the specified mouse button.
        //
        // Parameters:
        //   mouseButton:
        //     The button which is being queried.
        //
        // Returns:
        //     The state of the button.
        protected MouseButtonState GetButtonState(MouseButtons mouseButton)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Calculates, in client coordinates, the position of the mouse pointer.
        [SecurityCritical]
        [SecurityTreatAsSafe]
        protected Point GetClientPosition()
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Calculates, in client coordinates, the position of the mouse pointer. in
        //     the specified System.Windows.PresentationSource.
        //
        // Parameters:
        //   presentationSource:
        //     The source in which to obtain the mouse position.
        protected Point GetClientPosition(PresentationSource presentationSource)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Gets the position of the mouse relative to a specified element.
        //
        // Parameters:
        //   relativeTo:
        //     The frame of reference in which to calculate the position of the mouse.
        //
        // Returns:
        //     The position of the mouse relative to the parameter relativeTo.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     relativeTo is null or is not a System.Windows.UIElement or System.Windows.ContentElement.
        [SecurityCritical]
        public Point GetPosition(IInputElement relativeTo)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Calculates the screen position of the mouse pointer.
        //
        // Returns:
        //     The position of the mouse pointer.
        protected Point GetScreenPosition()
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Sets the mouse pointer to the specified System.Windows.Input.Cursor
        //
        // Parameters:
        //   cursor:
        //     The cursor to set the mouse pointer to.
        //
        // Returns:
        //     true if the mouse cursor is set { throw new NotImplementedException(); } otherwise, false.
        [SecurityCritical]
		public bool SetCursor(Cursor cursor)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Forces the mouse to resynchronize.
        [SecurityCritical]
        public void Synchronize()
        {
            throw new NotImplementedException();
        }
        
        //
        // Summary:
        //     Forces the mouse cursor to update.
        public void UpdateCursor()
        {
            throw new NotImplementedException();
        }

    }
}
