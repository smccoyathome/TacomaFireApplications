﻿using System;

namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Specifies the set of modifier keys.
	[Flags]
    [TypeConverter(typeof(ModifierKeysConverter))]
    [ValueSerializer(typeof(ModifierKeysValueSerializer))]
    public enum ModifierKeys
    {
        // Summary:
        //     No modifiers are pressed.
        None = 0,

        //
        // Summary:
        //     The ALT key.
        Alt = 1,

        //
        // Summary:
        //     The CTRL key.
        Control = 2,

        //
        // Summary:
        //     The SHIFT key.
        Shift = 4,

        //
        // Summary:
        //     The Windows logo key.
        Windows = 8
    }
}
