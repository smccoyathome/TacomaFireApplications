using System;

namespace UpgradeHelpers.Helpers
{
    // Summary:
    //     Specifies which child controls to skip.
    [Flags]
    public enum GetChildAtPointSkip
    {
        // Summary:
        //     Does not skip any child windows.
        None = 0,
        //
        // Summary:
        //     Skips invisible child windows.
        Invisible = 1,
        //
        // Summary:
        //     Skips disabled child windows.
        Disabled = 2,
        //
        // Summary:
        //     Skips transparent child windows.
        Transparent = 4,
    }
}
