// *************************************************************************************
// <copyright company="Mobilize" file="UltraGridAction.cs" >
//      Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
//      All helper classes are provided for customer use only;
//      all other use is prohibited without prior written consent from Mobilize.Net.
//      no warranty express or implied;
//      use at own risk.
// </copyright>
// <summary></summary>
// *************************************************************************************
namespace Custom.ViewModels.Grid
{
    /// <summary>
    /// Enum UltraGridAction
    /// </summary>
    public enum UltraGridAction
    {
        /// <summary>
        /// The toggle edit mode
        /// </summary>
        ToggleEditMode = 13,

        /// <summary>
        /// The toggle dropdown
        /// </summary>
        ToggleDropdown = 14,

        /// <summary>
        /// The undo cell
        /// </summary>
        UndoCell = 21,

        /// <summary>
        /// The undo row
        /// </summary>
        UndoRow = 22,

        /// <summary>
        /// The close dropdown
        /// </summary>
        CloseDropdown = 23,

        /// <summary>
        /// The enter edit mode
        /// </summary>
        EnterEditMode = 24,

        /// <summary>
        /// The enter edit mode and dropdown
        /// </summary>
        EnterEditModeAndDropdown = 25,

        /// <summary>
        /// The expand row
        /// </summary>
        ExpandRow = 30,

        /// <summary>
        /// The delete rows
        /// </summary>
        DeleteRows = 37,

        /// <summary>
        /// The deactivate cell
        /// </summary>
        DeactivateCell = 38,

        /// <summary>
        /// The activate cell
        /// </summary>
        ActivateCell = 39,

        /// <summary>
        /// The collapse row
        /// </summary>
        CollapseRow = 40,

        /// <summary>
        /// The toggle checkbox
        /// </summary>
        ToggleCheckbox = 41,

        /// <summary>
        /// The exit edit mode
        /// </summary>
        ExitEditMode = 44,

        /// <summary>
        /// The commit row
        /// </summary>
        CommitRow = 47,

        /// <summary>
        /// The copy
        /// </summary>
        Copy = 48,

        /// <summary>
        /// The cut
        /// </summary>
        Cut = 49,

        /// <summary>
        /// The delete cells
        /// </summary>
        DeleteCells = 50,

        /// <summary>
        /// The paste
        /// </summary>
        Paste = 51,

        /// <summary>
        /// The undo
        /// </summary>
        Undo = 52,

        /// <summary>
        /// The redo
        /// </summary>
        Redo = 53,
    }
}