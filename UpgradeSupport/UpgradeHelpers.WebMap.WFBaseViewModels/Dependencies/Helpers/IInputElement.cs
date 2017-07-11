using System;
using UpgradeHelpers.Events;

namespace UpgradeHelpers.Interfaces
{
	// Summary:
	//     Establishes the common events and also the event-related properties and methods
	//     for basic input processing by Windows Presentation Foundation (WPF) elements.
	public interface IInputElement
    {
        // Summary:
        //     Gets or sets a value that indicates whether focus can be set to this element.
        //
        // Returns:
        //     true if the element can have focus set to it; otherwise, false.
        bool Focusable { get; set; }

        //
        // Summary:
        //     Gets a value that indicates whether this element is enabled in the user interface
        //     (UI).
        //
        // Returns:
        //     true if the element is enabled; otherwise, false.
        bool IsEnabled { get; }

        //
        // Summary:
        //     Gets a value that indicates whether this element has keyboard focus.
        //
        // Returns:
        //     true if this element has keyboard focus; otherwise, false.
        bool IsKeyboardFocused { get; }

        //
        // Summary:
        //     Gets a value that indicates whether keyboard focus is anywhere inside the
        //     element bounds, including if keyboard focus is inside the bounds of any visual
        //     child elements.
        //
        // Returns:
        //     true if keyboard focus is on the element or its child elements; otherwise,
        //     false.
        bool IsKeyboardFocusWithin { get; }

        //
        // Summary:
        //     Gets a value that indicates whether the mouse is captured to this element.
        //
        // Returns:
        //     true if the element has mouse capture; otherwise, false.
        bool IsMouseCaptured { get; }

        //
        // Summary:
        //     Gets a value that indicates whether the mouse pointer is over this element
        //     in the strictest hit testing sense.
        //
        // Returns:
        //     true if the mouse pointer is over this element; otherwise, false.
        bool IsMouseDirectlyOver { get; }

        //
        // Summary:
        //     Gets a value that indicates whether the mouse pointer is located over this
        //     element (including visual children elements that are inside its bounds).
        //
        // Returns:
        //     true if the mouse pointer is over the element or its child elements; otherwise,
        //     false.
        bool IsMouseOver { get; }

        //
        // Summary:
        //     Gets a value that indicates whether the stylus is captured to this element.
        //
        // Returns:
        //     true if the element has stylus capture; otherwise, false.
        bool IsStylusCaptured { get; }

        //
        // Summary:
        //     Gets a value that indicates whether the stylus is over this element in the
        //     strictest hit testing sense.
        //
        // Returns:
        //     true if the stylus is over the element; otherwise, false.
        bool IsStylusDirectlyOver { get; }

        //
        // Summary:
        //     Gets a value that indicates whether the stylus is located over this element
        //     (or over visual child elements that are inside its bounds).
        //
        // Returns:
        //     true if the stylus cursor is over the element or its child elements; otherwise,
        //     false.
        bool IsStylusOver { get; }

        // Summary:
        //     Occurs when the keyboard is focused on this element.
        event KeyboardFocusChangedEventHandler GotKeyboardFocus;

        //
        // Summary:
        //     Occurs when the element captures the mouse.
        event MouseEventHandler GotMouseCapture;

        //
        // Summary:
        //     Occurs when the element captures the stylus.
        event StylusEventHandler GotStylusCapture;

        //
        // Summary:
        //     Occurs when a key is pressed while the keyboard is focused on this element.
        event KeyEventHandler KeyDown;

        //
        // Summary:
        //     Occurs when a key is released while the keyboard is focused on this element.
        event KeyEventHandler KeyUp;

        //
        // Summary:
        //     Occurs when the keyboard is no longer focused on this element.
        event KeyboardFocusChangedEventHandler LostKeyboardFocus;

        //
        // Summary:
        //     Occurs when this element loses mouse capture.
        event MouseEventHandler LostMouseCapture;

        //
        // Summary:
        //     Occurs when this element loses stylus capture.
        event StylusEventHandler LostStylusCapture;

        //
        // Summary:
        //     Occurs when the mouse pointer enters the bounds of this element.
        event MouseEventHandler MouseEnter;

        //
        // Summary:
        //     Occurs when the mouse pointer leaves the bounds of this element.
        event MouseEventHandler MouseLeave;

        /*//
        // Summary:
        //     Occurs when the left mouse button is pressed while the mouse pointer is over
        //     the element.
        event MouseButtonEventHandler MouseLeftButtonDown;

        //
        // Summary:
        //     Occurs when the left mouse button is released while the mouse pointer is
        //     over the element.
        event MouseButtonEventHandler MouseLeftButtonUp;*/

        //
        // Summary:
        //     Occurs when the mouse pointer moves while the mouse pointer is over the element.
        event MouseEventHandler MouseMove;

        /*//
        // Summary:
        //     Occurs when the right mouse button is pressed while the mouse pointer is
        //     over the element.
        event MouseButtonEventHandler MouseRightButtonDown;

        //
        // Summary:
        //     Occurs when the right mouse button is released while the mouse pointer is
        //     over the element.
        event MouseButtonEventHandler MouseRightButtonUp;

        //
        // Summary:
        //     Occurs when the mouse wheel moves while the mouse pointer is over this element.
        event MouseWheelEventHandler MouseWheel; */

        //
        // Summary:
        //     Occurs when the keyboard is focused on this element.
        event KeyboardFocusChangedEventHandler PreviewGotKeyboardFocus;

        //
        // Summary:
        //     Occurs when a key is pressed while the keyboard is focused on this element.
        event KeyEventHandler PreviewKeyDown;

        //
        // Summary:
        //     Occurs when a key is released while the keyboard is focused on this element.
        event KeyEventHandler PreviewKeyUp;

        //
        // Summary:
        //     Occurs when the keyboard is no longer focused on this element.
        event KeyboardFocusChangedEventHandler PreviewLostKeyboardFocus;

        /*//
        // Summary:
        //     Occurs when the left mouse button is pressed while the mouse pointer is over
        //     the element.
        event MouseButtonEventHandler PreviewMouseLeftButtonDown;
        //
        // Summary:
        //     Occurs when the left mouse button is released while the mouse pointer is
        //     over the element.
        event MouseButtonEventHandler PreviewMouseLeftButtonUp; */
        //
        // Summary:
        //     Occurs when the mouse pointer moves while the mouse pointer is over the element.
        event MouseEventHandler PreviewMouseMove;
        
        /*//
        // Summary:
        //     Occurs when the right mouse button is pressed while the mouse pointer is
        //     over the element.
        event MouseButtonEventHandler PreviewMouseRightButtonDown;
        //
        // Summary:
        //     Occurs when the right mouse button is released while the mouse pointer is
        //     over the element.
        event MouseButtonEventHandler PreviewMouseRightButtonUp;
        //
        // Summary:
        //     Occurs when the mouse wheel moves while the mouse pointer is over this element.
        event MouseWheelEventHandler PreviewMouseWheel;
        //
        // Summary:
        //     Occurs when the stylus button is pressed down while the stylus is over this
        //     element.
        event StylusButtonEventHandler PreviewStylusButtonDown;
        //
        // Summary:
        //     Occurs when the stylus button is released while the stylus is over this element.
        event StylusButtonEventHandler PreviewStylusButtonUp;
        //
        // Summary:
        //     Occurs when the stylus touches the digitizer while over this element.
        event StylusDownEventHandler PreviewStylusDown; */
        //
        // Summary:
        //     Occurs when the stylus moves over an element, but without touching the digitizer.
        event StylusEventHandler PreviewStylusInAirMove;
        //
        // Summary:
        //     Occurs when the stylus is close enough to the digitizer to be detected.
        event StylusEventHandler PreviewStylusInRange;
        //
        // Summary:
        //     Occurs when the stylus moves while the stylus is over the element.
        event StylusEventHandler PreviewStylusMove;
        //
        // Summary:
        //     Occurs when the stylus is too far from the digitizer to be detected.
        event StylusEventHandler PreviewStylusOutOfRange;
       
        /* //
        // Summary:
        //     Occurs when one of several stylus gestures are detected, for example, System.Windows.Input.SystemGesture.Tap
        //     or System.Windows.Input.SystemGesture.Drag.
        event StylusSystemGestureEventHandler PreviewStylusSystemGesture;
        //
        // Summary:
        //     Occurs when the stylus is raised off the digitizer while over this element.
        event StylusEventHandler PreviewStylusUp;
        //
        // Summary:
        //     Occurs when this element gets text in a device-independent manner.
        event TextCompositionEventHandler PreviewTextInput;
        //
        // Summary:
        //     Occurs when the stylus button is pressed while the stylus is over this element.
        event StylusButtonEventHandler StylusButtonDown;
        //
        // Summary:
        //     Occurs when the stylus button is released while the stylus is over this element.
        event StylusButtonEventHandler StylusButtonUp;
        //
        // Summary:
        //     Occurs when the stylus touches the digitizer while over this element.
        event StylusDownEventHandler StylusDown; */

        //
        // Summary:
        //     Occurs when the stylus cursor enters the bounds of the element.
        event StylusEventHandler StylusEnter;

        //
        // Summary:
        //     Occurs when the stylus moves over an element, but without touching the digitizer.
        event StylusEventHandler StylusInAirMove;

        //
        // Summary:
        //     Occurs when the stylus is close enough to the digitizer to be detected.
        event StylusEventHandler StylusInRange;

        //
        // Summary:
        //     Occurs when the stylus cursor leaves the bounds of the element.
        event StylusEventHandler StylusLeave;

        //
        // Summary:
        //     Occurs when the stylus cursor moves over the element.
        event StylusEventHandler StylusMove;

        //
        // Summary:
        //     Occurs when the stylus is too far from the digitizer to be detected.
        event StylusEventHandler StylusOutOfRange;
        //
        // Summary:
        //     Occurs when one of several stylus gestures are detected, for example, System.Windows.Input.SystemGesture.Tap
        //     or System.Windows.Input.SystemGesture.Drag.
       // event StylusSystemGestureEventHandler StylusSystemGesture;

        //
        // Summary:
        //     Occurs when the stylus is raised off the digitizer while over this element.
        event StylusEventHandler StylusUp;

        //
        // Summary:
        //     Occurs when this element gets text in a device-independent manner.
        //event TextCompositionEventHandler TextInput;

        // Summary:
        //     Adds a routed event handler for a specific routed event to an element.
        //
        // Parameters:
        //   routedEvent:
        //     The identifier for the routed event that is being handled.
        //
        //   handler:
        //     A reference to the handler implementation.
        void AddHandler(RoutedEvent routedEvent, Delegate handler);

        //
        // Summary:
        //     Attempts to force capture of the mouse to this element.
        //
        // Returns:
        //     true if the mouse is successfully captured; otherwise, false.
        bool CaptureMouse();

        //
        // Summary:
        //     Attempts to force capture of the stylus to this element.
        //
        // Returns:
        //     true if the stylus is successfully captured; otherwise, false.
        bool CaptureStylus();

        //
        // Summary:
        //     Attempts to focus the keyboard on this element.
        //
        // Returns:
        //     true if keyboard focus is moved to this element or already was on this element;
        //     otherwise, false.
        bool Focus();

        //
        // Summary:
        //     Raises the routed event that is specified by the System.Windows.RoutedEventArgs.RoutedEvent
        //     property within the provided System.Windows.RoutedEventArgs.
        //
        // Parameters:
        //   e:
        //     An instance of the System.Windows.RoutedEventArgs class that contains the
        //     identifier for the event to raise.
        void RaiseEvent(RoutedEventArgs e);

        //
        // Summary:
        //     Releases the mouse capture, if this element holds the capture.
        void ReleaseMouseCapture();

        //
        // Summary:
        //     Releases the stylus capture, if this element holds the capture.
        void ReleaseStylusCapture();

        //
        // Summary:
        //     Removes all instances of the specified routed event handler from this element.
        //
        // Parameters:
        //   routedEvent:
        //     Identifier of the routed event for which the handler is attached.
        //
        //   handler:
        //     The specific handler implementation to remove from this element's event handler
        //     collection.
        void RemoveHandler(RoutedEvent routedEvent, Delegate handler);
    }
}
