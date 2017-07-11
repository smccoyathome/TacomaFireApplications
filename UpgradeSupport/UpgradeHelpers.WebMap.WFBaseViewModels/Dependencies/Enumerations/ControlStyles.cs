using System;
using System.ComponentModel;

namespace UpgradeHelpers.Helpers
{
	[Flags]
    public enum ControlStyles
    {
        ContainerControl = 1,
        UserPaint = 2,
        Opaque = 4,
        ResizeRedraw = 16,
        FixedWidth = 32,
        FixedHeight = 64,
        StandardClick = 256,
        Selectable = 512,
        UserMouse = 1024,
        SupportsTransparentBackColor = 2048,
        StandardDoubleClick = 4096,
        AllPaintingInWmPaint = 8192,
        CacheText = 16384,
        EnableNotifyMessage = 32768,
        [EditorBrowsable(EditorBrowsableState.Never)]
        DoubleBuffer = 65536,
        OptimizedDoubleBuffer = 131072,
        UseTextForAccessibility = 262144,
    }
}
