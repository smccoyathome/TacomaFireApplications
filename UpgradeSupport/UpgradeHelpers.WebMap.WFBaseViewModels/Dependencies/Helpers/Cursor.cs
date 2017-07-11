
namespace UpgradeHelpers.Helpers
{
    /// <summary>
    /// Represents the image used to paint the mouse pointer.
    /// This concept has no equivalent on ASP.NET/HTML
    /// This class is just a stub for compilation purposes
    /// </summary>
    public class Cursor
    {
        public static Cursor Current { get; set; }
        public static Point Position { get; set; }
    }

    /// <summary>
    /// Provides a collection of Cursor objects for use by a Windows Forms application.
    /// This concept has no equivalent on ASP.NET/HTML
    /// This class is just a stub for compilation purposes
    /// </summary>
    public class Cursors
    {
        public static Cursor Arrow { get { return null; } }
        public static Cursor WaitCursor { get { return null; } }
        public static Cursor Default { get { return null; } }

        public static Cursor Cross { get; set; }

        public static Cursor IBeam { get; set; }

        public static Cursor SizeNESW { get; set; }

        public static Cursor SizeNS { get; set; }

        public static Cursor SizeNWSE { get; set; }

        public static Cursor SizeWE { get; set; }

        public static Cursor UpArrow { get; set; }

        public static Cursor No { get; set; }

        public static Cursor Help { get; set; }

        public static Cursor SizeAll { get; set; }
    }
}
