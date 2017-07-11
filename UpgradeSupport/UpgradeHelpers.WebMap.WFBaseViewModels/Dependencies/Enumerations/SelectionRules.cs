using System;

namespace UpgradeHelpers.Helpers
{
    // Summary:
    //     Defines identifiers that are used to indicate selection rules for a component.
    [Flags]
    public enum SelectionRules
    {
        // Summary:
        //     Indicates the component is locked to its container. Overrides the System.Windows.Forms.Design.SelectionRules.Moveable,
        //     System.Windows.Forms.Design.SelectionRules.AllSizeable, System.Windows.Forms.Design.SelectionRules.BottomSizeable,
        //     System.Windows.Forms.Design.SelectionRules.LeftSizeable, System.Windows.Forms.Design.SelectionRules.RightSizeable,
        //     and System.Windows.Forms.Design.SelectionRules.TopSizeable bit flags of this
        //     enumeration.
        Locked = -2147483648,
        //
        // Summary:
        //     Indicates no special selection attributes.
        None = 0,
        //
        // Summary:
        //     Indicates the component supports resize from the top.
        TopSizeable = 1,
        //
        // Summary:
        //     Indicates the component supports resize from the bottom.
        BottomSizeable = 2,
        //
        // Summary:
        //     Indicates the component supports resize from the left.
        LeftSizeable = 4,
        //
        // Summary:
        //     Indicates the component supports resize from the right.
        RightSizeable = 8,
        //
        // Summary:
        //     Indicates the component supports sizing in all directions.
        AllSizeable = 15,
        //
        // Summary:
        //     Indicates the component supports a location property that allows it to be
        //     moved on the screen.
        Moveable = 268435456,
        //
        // Summary:
        //     Indicates the component has some form of visible user interface and the selection
        //     service is drawing a selection border around this user interface. If a selected
        //     component has this rule set, you can assume that the component implements
        //     System.ComponentModel.IComponent and that it is associated with a corresponding
        //     designer instance.
        Visible = 1073741824,
    }
}