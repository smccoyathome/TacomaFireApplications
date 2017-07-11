using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpgradeHelpers.Interfaces
{
    // Summary:
    //     ISelectableItem is implemented by any sub object that can be selected and/or
    //     activated (e.g. a cell, row, header etc.)
    public interface ISelectableItem
    {
        // Summary:
        //     True if the item is Draggable (read-only).
        bool IsDraggable { get; }

        //
        // Summary:
        //     True if the item is selectable (read-only).
        bool IsSelectable { get; }

        //
        // Summary:
        //     True if the item is currently selected (read-only).
        bool IsSelected { get; }

        //
        // Summary:
        //     True if this item is a tab stop
        bool IsTabStop { get; }
    }
}
