using System;

namespace UpgradeHelpers.Helpers
{
    // Summary:
    //     Implements a Windows message.
    public struct Message
    {

        // Summary:
        //     Determines whether two instances of System.Windows.Forms.Message are not
        //     equal.
        //
        // Parameters:
        //   a:
        //     A System.Windows.Forms.Message to compare to b.
        //
        //   b:
        //     A System.Windows.Forms.Message to compare to a.
        //
        // Returns:
        //     true if a and b do not represent the same System.Windows.Forms.Message; otherwise,
        //     false.
        public static bool operator !=(Message a, Message b) 
        {
            return true;
        }


        //
        // Summary:
        //     Determines whether two instances of System.Windows.Forms.Message are equal.
        //
        // Parameters:
        //   a:
        //     A System.Windows.Forms.Message to compare to b.
        //
        //   b:
        //     A System.Windows.Forms.Message to compare to a.
        //
        // Returns:
        //     true if a and b represent the same System.Windows.Forms.Message; otherwise,
        //     false.
        public static bool operator ==(Message a, Message b) 
        {
            return true;
        }

        // Summary:
        //     Gets or sets the window handle of the message.
        //
        // Returns:
        //     The window handle of the message.
        public IntPtr HWnd { get; set; }
        //
        // Summary:
        //     Specifies the System.Windows.Forms.Message.LParam field of the message.
        //
        // Returns:
        //     The System.Windows.Forms.Message.LParam field of the message.
        public IntPtr LParam { get; set; }
        //
        // Summary:
        //     Gets or sets the ID number for the message.
        //
        // Returns:
        //     The ID number for the message.
        public int Msg { get; set; }
        //
        // Summary:
        //     Specifies the value that is returned to Windows in response to handling the
        //     message.
        //
        // Returns:
        //     The return value of the message.
        public IntPtr Result { get; set; }
        //
        // Summary:
        //     Gets or sets the System.Windows.Forms.Message.WParam field of the message.
        //
        // Returns:
        //     The System.Windows.Forms.Message.WParam field of the message.
        public IntPtr WParam { get; set; }

        // Summary:
        //     Creates a new System.Windows.Forms.Message.
        //
        // Parameters:
        //   hWnd:
        //     The window handle that the message is for.
        //
        //   msg:
        //     The message ID.
        //
        //   wparam:
        //     The message wparam field.
        //
        //   lparam:
        //     The message lparam field.
        //
        // Returns:
        //     A System.Windows.Forms.Message that represents the message that was created.
        public static Message Create(IntPtr hWnd, int msg, IntPtr wparam, IntPtr lparam) 
        {
            Message newMsg = new Message();
            newMsg.HWnd = hWnd;
            newMsg.Msg = msg;
            newMsg.WParam = wparam;
            newMsg.LParam = lparam;

            return newMsg;
        }

        //
        // Summary:
        //     Determines whether the specified object is equal to the current object.
        //
        // Parameters:
        //   o:
        //     The object to compare with the current object.
        //
        // Returns:
        //     true if the specified object is equal to the current object; otherwise, false.
        public override bool Equals(object o) 
        {
            return false;
        }

        //
        //
        // Returns:
        //     A 32-bit signed integer that is the hash code for this instance.
        public override int GetHashCode() 
        {
            return base.GetHashCode();
        }
        
        //
        // Summary:
        //     Gets the System.Windows.Forms.Message.LParam value and converts the value
        //     to an object.
        //
        // Parameters:
        //   cls:
        //     The type to use to create an instance. This type must be declared as a structure
        //     type.
        //
        // Returns:
        //     An System.Object that represents an instance of the class specified by the
        //     cls parameter, with the data from the System.Windows.Forms.Message.LParam
        //     field of the message.
        public object GetLParam(Type cls) 
        {
            return null;
        }
        //
        // Summary:
        //     Returns a System.String that represents the current System.Windows.Forms.Message.
        //
        // Returns:
        //     A System.String that represents the current System.Windows.Forms.Message.
        public override string ToString() 
        {
            return base.ToString();
        }
    }
}