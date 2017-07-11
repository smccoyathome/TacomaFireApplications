using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpgradeHelpers.Helpers
{

    // Summary:
    //     Specifies values representing possible roles for an accessible object.
    public enum AccessibleRole
    {
        // Summary:
        //     A system-provided role.
        Default = -1,
        //
        // Summary:
        //     No role.
        None = 0,
        //
        // Summary:
        //     A title or caption bar for a window.
        TitleBar = 1,
        //
        // Summary:
        //     A menu bar, usually beneath the title bar of a window, from which users can
        //     select menus.
        MenuBar = 2,
        //
        // Summary:
        //     A vertical or horizontal scroll bar, which can be either part of the client
        //     area or used in a control.
        ScrollBar = 3,
        //
        // Summary:
        //     A special mouse pointer, which allows a user to manipulate user interface
        //     elements such as a window. For example, a user can click and drag a sizing
        //     grip in the lower-right corner of a window to resize it.
        Grip = 4,
        //
        // Summary:
        //     A system sound, which is associated with various system events.
        Sound = 5,
        //
        // Summary:
        //     A mouse pointer.
        Cursor = 6,
        //
        // Summary:
        //     A caret, which is a flashing line, block, or bitmap that marks the location
        //     of the insertion point in a window's client area.
        Caret = 7,
        //
        // Summary:
        //     An alert or condition that you can notify a user about. Use this role only
        //     for objects that embody an alert but are not associated with another user
        //     interface element, such as a message box, graphic, text, or sound.
        Alert = 8,
        //
        // Summary:
        //     A window frame, which usually contains child objects such as a title bar,
        //     client, and other objects typically contained in a window.
        Window = 9,
        //
        // Summary:
        //     A window's user area.
        Client = 10,
        //
        // Summary:
        //     A menu, which presents a list of options from which the user can make a selection
        //     to perform an action. All menu types must have this role, including drop-down
        //     menus that are displayed by selection from a menu bar, and shortcut menus
        //     that are displayed when the right mouse button is clicked.
        MenuPopup = 11,
        //
        // Summary:
        //     A menu item, which is an entry in a menu that a user can choose to carry
        //     out a command, select an option, or display another menu. Functionally, a
        //     menu item can be equivalent to a push button, radio button, check box, or
        //     menu.
        MenuItem = 12,
        //
        // Summary:
        //     A tool tip, which is a small rectangular pop-up window that displays a brief
        //     description of the purpose of a button.
        ToolTip = 13,
        //
        // Summary:
        //     The main window for an application.
        Application = 14,
        //
        // Summary:
        //     A document window, which is always contained within an application window.
        //     This role applies only to multiple-document interface (MDI) windows and refers
        //     to an object that contains the MDI title bar.
        Document = 15,
        //
        // Summary:
        //     A separate area in a frame, a split document window, or a rectangular area
        //     of the status bar that can be used to display information. Users can navigate
        //     between panes and within the contents of the current pane, but cannot navigate
        //     between items in different panes. Thus, panes represent a level of grouping
        //     lower than frame windows or documents, but above individual controls. Typically,
        //     the user navigates between panes by pressing TAB, F6, or CTRL+TAB, depending
        //     on the context.
        Pane = 16,
        //
        // Summary:
        //     A graphical image used to represent data.
        Chart = 17,
        //
        // Summary:
        //     A dialog box or message box.
        Dialog = 18,
        //
        // Summary:
        //     A window border. The entire border is represented by a single object, rather
        //     than by separate objects for each side.
        Border = 19,
        //
        // Summary:
        //     The objects grouped in a logical manner. There can be a parent-child relationship
        //     between the grouping object and the objects it contains.
        Grouping = 20,
        //
        // Summary:
        //     A space divided visually into two regions, such as a separator menu item
        //     or a separator dividing split panes within a window.
        Separator = 21,
        //
        // Summary:
        //     A toolbar, which is a grouping of controls that provide easy access to frequently
        //     used features.
        ToolBar = 22,
        //
        // Summary:
        //     A status bar, which is an area typically at the bottom of an application
        //     window that displays information about the current operation, state of the
        //     application, or selected object. The status bar can have multiple fields
        //     that display different kinds of information, such as an explanation of the
        //     currently selected menu command in the status bar.
        StatusBar = 23,
        //
        // Summary:
        //     A table containing rows and columns of cells and, optionally, row headers
        //     and column headers.
        Table = 24,
        //
        // Summary:
        //     A column header, which provides a visual label for a column in a table.
        ColumnHeader = 25,
        //
        // Summary:
        //     A row header, which provides a visual label for a table row.
        RowHeader = 26,
        //
        // Summary:
        //     A column of cells within a table.
        Column = 27,
        //
        // Summary:
        //     A row of cells within a table.
        Row = 28,
        //
        // Summary:
        //     A cell within a table.
        Cell = 29,
        //
        // Summary:
        //     A link, which is a connection between a source document and a destination
        //     document. This object might look like text or a graphic, but it acts like
        //     a button.
        Link = 30,
        //
        // Summary:
        //     A Help display in the form of a ToolTip or Help balloon, which contains buttons
        //     and labels that users can click to open custom Help topics.
        HelpBalloon = 31,
        //
        // Summary:
        //     A cartoon-like graphic object, such as Microsoft Office Assistant, which
        //     is typically displayed to provide help to users of an application.
        Character = 32,
        //
        // Summary:
        //     A list box, which allows the user to select one or more items.
        List = 33,
        //
        // Summary:
        //     An item in a list box or the list portion of a combo box, drop-down list
        //     box, or drop-down combo box.
        ListItem = 34,
        //
        // Summary:
        //     An outline or tree structure, such as a tree view control, which displays
        //     a hierarchical list and usually allows the user to expand and collapse branches.
        Outline = 35,
        //
        // Summary:
        //     An item in an outline or tree structure.
        OutlineItem = 36,
        //
        // Summary:
        //     A property page that allows a user to view the attributes for a page, such
        //     as the page's title, whether it is a home page, or whether the page has been
        //     modified. Normally, the only child of this control is a grouped object that
        //     contains the contents of the associated page.
        PageTab = 37,
        //
        // Summary:
        //     A property page, which is a dialog box that controls the appearance and the
        //     behavior of an object, such as a file or resource. A property page's appearance
        //     differs according to its purpose.
        PropertyPage = 38,
        //
        // Summary:
        //     An indicator, such as a pointer graphic, that points to the current item.
        Indicator = 39,
        //
        // Summary:
        //     A picture.
        Graphic = 40,
        //
        // Summary:
        //     The read-only text, such as in a label, for other controls or instructions
        //     in a dialog box. Static text cannot be modified or selected.
        StaticText = 41,
        //
        // Summary:
        //     The selectable text that can be editable or read-only.
        Text = 42,
        //
        // Summary:
        //     A push button control, which is a small rectangular control that a user can
        //     turn on or off. A push button, also known as a command button, has a raised
        //     appearance in its default off state and a sunken appearance when it is turned
        //     on.
        PushButton = 43,
        //
        // Summary:
        //     A check box control, which is an option that can be turned on or off independent
        //     of other options.
        CheckButton = 44,
        //
        // Summary:
        //     An option button, also known as a radio button. All objects sharing a single
        //     parent that have this attribute are assumed to be part of a single mutually
        //     exclusive group. You can use grouped objects to divide option buttons into
        //     separate groups when necessary.
        RadioButton = 45,
        //
        // Summary:
        //     A combo box, which is an edit control with an associated list box that provides
        //     a set of predefined choices.
        ComboBox = 46,
        //
        // Summary:
        //     A drop-down list box. This control shows one item and allows the user to
        //     display and select another from a list of alternative choices.
        DropList = 47,
        //
        // Summary:
        //     A progress bar, which indicates the progress of a lengthy operation by displaying
        //     colored lines inside a horizontal rectangle. The length of the lines in relation
        //     to the length of the rectangle corresponds to the percentage of the operation
        //     that is complete. This control does not take user input.
        ProgressBar = 48,
        //
        // Summary:
        //     A dial or knob. This can also be a read-only object, like a speedometer.
        Dial = 49,
        //
        // Summary:
        //     A hot-key field that allows the user to enter a combination or sequence of
        //     keystrokes to be used as a hot key, which enables users to perform an action
        //     quickly. A hot-key control displays the keystrokes entered by the user and
        //     ensures that the user selects a valid key combination.
        HotkeyField = 50,
        //
        // Summary:
        //     A control, sometimes called a trackbar, that enables a user to adjust a setting
        //     in given increments between minimum and maximum values by moving a slider.
        //     The volume controls in the Windows operating system are slider controls.
        Slider = 51,
        //
        // Summary:
        //     A spin box, also known as an up-down control, which contains a pair of arrow
        //     buttons. A user clicks the arrow buttons with a mouse to increment or decrement
        //     a value. A spin button control is most often used with a companion control,
        //     called a buddy window, where the current value is displayed.
        SpinButton = 52,
        //
        // Summary:
        //     A graphical image used to diagram data.
        Diagram = 53,
        //
        // Summary:
        //     An animation control, which contains content that is changing over time,
        //     such as a control that displays a series of bitmap frames, like a filmstrip.
        //     Animation controls are usually displayed when files are being copied, or
        //     when some other time-consuming task is being performed.
        Animation = 54,
        //
        // Summary:
        //     A mathematical equation.
        Equation = 55,
        //
        // Summary:
        //     A button that drops down a list of items.
        ButtonDropDown = 56,
        //
        // Summary:
        //     A button that drops down a menu.
        ButtonMenu = 57,
        //
        // Summary:
        //     A button that drops down a grid.
        ButtonDropDownGrid = 58,
        //
        // Summary:
        //     A blank space between other objects.
        WhiteSpace = 59,
        //
        // Summary:
        //     A container of page tab controls.
        PageTabList = 60,
        //
        // Summary:
        //     A control that displays the time.
        Clock = 61,
        //
        // Summary:
        //     A toolbar button that has a drop-down list icon directly adjacent to the
        //     button.
        SplitButton = 62,
        //
        // Summary:
        //     A control designed for entering Internet Protocol (IP) addresses.
        IpAddress = 63,
        //
        // Summary:
        //     A control that navigates like an outline item.
        OutlineButton = 64,
    }
}
