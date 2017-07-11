using System;

namespace UpgradeHelpers.Helpers
{
    // Summary:
    //     Specifies the possible effects of a drag-and-drop operation.
    [Flags]
    public enum DragDropEffects
    {
        // Summary:
        //     The target can be scrolled while dragging to locate a drop position that
        //     is not currently visible in the target.
        Scroll = -2147483648,
        //
        // Summary:
        //     The combination of the System.Windows.DragDropEffects.Copy, System.Windows.Forms.DragDropEffects.Move,
        //     and System.Windows.Forms.DragDropEffects.Scroll effects.
        All = -2147483645,
        //
        // Summary:
        //     The drop target does not accept the data.
        None = 0,
        //
        // Summary:
        //     The data from the drag source is copied to the drop target.
        Copy = 1,
        //
        // Summary:
        //     The data from the drag source is moved to the drop target.
        Move = 2,
        //
        // Summary:
        //     The data from the drag source is linked to the drop target.
        Link = 4,
    }
}
