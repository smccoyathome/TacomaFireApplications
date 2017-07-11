using System;

namespace UpgradeHelpers.Helpers
{
    [Flags]
    public enum ControlState : short
    {
        None = 0,
        Enabled = 2,
        Loaded = 4,
        IsHandleCreated = 8,
        IsDisposed = 16,
        IsModal = 32
    }

    [Flags]
    public enum VisibleState : short
    {
        None = 0,
        Visible = 2,
        ParentVisible = 4
    }
}