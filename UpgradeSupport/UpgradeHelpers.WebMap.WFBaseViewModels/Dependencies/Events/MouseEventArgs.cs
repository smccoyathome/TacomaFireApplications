using System;
using UpgradeHelpers.Helpers;

namespace UpgradeHelpers.Events
{
	/// <summary>
	///     Event args class for Mouse event handlers.  This class is provided for compilation purposes only,
	///     because mouse events are not server propagated to server side, instead they are
	///     converted to client side events (such as JavaScript)
	/// </summary>
	public class MouseEventArgs : InputEventArgs, UpgradeHelpers.Interfaces.IStateObject  //, MOBILIZE,1/4/2017,TODO,mvega,"Manually added, "adding IStateObject because this class need to be persisted"
    {

        public string UniqueID { get; set; }  //, MOBILIZE,1/4/2017,TODO,mvega,"Manually added, "adding UniqueID property in order to implement IStateObject"

        public MouseEventArgs() :
            base(null, 0)
        {

        }
        public MouseEventArgs(string x, string y) :
            base(null, 0)
        {
            this.X = Int32.Parse(x);
            this.Y = Int32.Parse(y);
        }
        public MouseEventArgs(int x, int y) :
            base(null, 0)
        {
            this.X = x;
            this.Y = y;
        }

        public MouseEventArgs(MouseButtons button, int clicks, int x, int y, int delta) : 
            base(null, 0)
        {
            this.Button = button;
            this.Clicks = clicks;
            this.X = x;
            this.Y = y;
            this.Delta = delta;
        }
        public MouseEventArgs(MouseButtons button) :
            base(null, 0)
        {
            this.Button = button;
			this.Clicks= 1; // default
        }
        // Summary:
        //     Initializes a new instance of the System.Windows.Input.MouseEventArgs class
        //     using the specified System.Windows.Input.MouseDevice and timestamp
        //
        // Parameters:
        //   mouse:
        //     The mouse device associated with this event.
        //
        //   timestamp:
        //     The time when the input occurred.
        public MouseEventArgs(MouseDevice mouse, int timestamp)
            : base(mouse, timestamp)
        {
            throw new NotImplementedException();
        }

 

        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Input.MouseEventArgs class
        //     using the specified System.Windows.Input.MouseDevice, timestamp, and System.Windows.Input.StylusDevice.
        //
        // Parameters:
        //   mouse:
        //     The mouse device associated with this event.
        //
        //   timestamp:
        //     The time when the input occurred.
        //
        //   stylusDevice:
        //     The logical stylus device associated with this event.
        public MouseEventArgs(MouseDevice mouse, int timestamp, StylusDevice stylusDevice) : 
            base(mouse, timestamp)
        {
            throw new NotImplementedException();
        }

        public MouseButtons Button { get; set; }
        
        public int Clicks { get; set; }
        
        // Summary:
        //     Gets a value that indicates the amount that the mouse wheel has changed.
        //
        // Returns:
        //     The amount the wheel has changed. This value is positive if the mouse wheel
        //     is rotated in an upward direction (away from the user) or negative if the
        //     mouse wheel is rotated in a downward direction (toward the user).
        public int Delta { get; set; }
      
        public UpgradeHelpers.Helpers.Point Location { get; set; }
       
        public int X { get; set; }
       
        public int Y { get; set; }

        //public virtual UltraGridLayout Layout { get; set; }

        public bool Cancel { get; set; }

        //public UltraGridRow Row { get; set; }



        // ------------------------------  BUG 4857  -----------------------------------------------------

        // Summary:
        //     Gets the background color of the item that is being drawn.
        //
        // Returns:
        //     The background System.Drawing.Color of the item that is being drawn.
        public Color BackColor { get; set; }
        //
        // Summary:
        //     Gets the rectangle that represents the bounds of the item that is being drawn.
        //
        // Returns:
        //     The System.Drawing.Rectangle that represents the bounds of the item that
        //     is being drawn.
        public Rectangle Bounds { get; set; }
        //
        // Summary:
        //     Gets the font assigned to the item being drawn.
        //
        // Returns:
        //     The System.Drawing.Font assigned to the item being drawn.
        public Font Font { get; set; }
        //
        // Summary:
        //     Gets the foreground color of the of the item being drawn.
        //
        // Returns:
        //     The foreground System.Drawing.Color of the item being drawn.
        public Color ForeColor { get; set; }
        //
        // Summary:
        //     Gets the graphics surface to draw the item on.
        //
        // Returns:
        //     The System.Drawing.Graphics surface to draw the item on.
        public Graphics Graphics { get; set; }
        //
        // Summary:
        //     Gets the index value of the item that is being drawn.
        //
        // Returns:
        //     The numeric value that represents the System.Windows.Forms.Control.ControlCollection.this[System.Int32]
        //     value of the item being drawn.
        public int Index { get; set; }
        //
        // Summary:
        //     Gets the state of the item being drawn.
        //
        // Returns:
        //     The System.Windows.Forms.DrawItemState that represents the state of the item
        //     being drawn.
        public DrawItemState State { get; set; }

        // Summary:
        //     Draws the background within the bounds specified in the Overload:System.Windows.Forms.DrawItemEventArgs.#ctor
        //     constructor and with the appropriate color.
        public virtual void DrawBackground() {
            throw new NotImplementedException();

        }
        //
        // Summary:
        //     Draws a focus rectangle within the bounds specified in the Overload:System.Windows.Forms.DrawItemEventArgs.#ctor
        //     constructor.
        public virtual void DrawFocusRectangle() {
            throw new NotImplementedException();
        }

        // --------------------------------------------------------------------------------------------


    }
}