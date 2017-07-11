namespace UpgradeHelpers.Helpers
{
	public enum ImeMode
    {
        // Summary:
        //     Inherits the IME mode of the parent control.
        Inherit = -1,
        //
        // Summary:
        //     None (Default).
        NoControl = 0,
        //
        // Summary:
        //     The IME is on. This value indicates that the IME is on and characters specific
        //     to Chinese or Japanese can be entered. This setting is valid for Japanese,
        //     Simplified Chinese, and Traditional Chinese IME only.
        On = 1,
        //
        // Summary:
        //     The IME is off. This mode indicates that the IME is off, meaning that the
        //     object behaves the same as English entry mode. This setting is valid for
        //     Japanese, Simplified Chinese, and Traditional Chinese IME only.
        Off = 2,
        //
        // Summary:
        //     The IME is disabled. With this setting, the users cannot turn the IME on
        //     from the keyboard, and the IME floating window is hidden.
        Disable = 3,
        //
        // Summary:
        //     Hiragana DBC. This setting is valid for the Japanese IME only.
        Hiragana = 4,
        //
        // Summary:
        //     Katakana DBC. This setting is valid for the Japanese IME only.
        Katakana = 5,
        //
        // Summary:
        //     Katakana SBC. This setting is valid for the Japanese IME only.
        KatakanaHalf = 6,
        //
        // Summary:
        //     Alphanumeric double-byte characters. This setting is valid for Korean and
        //     Japanese IME only.
        AlphaFull = 7,
        //
        // Summary:
        //     Alphanumeric single-byte characters(SBC). This setting is valid for Korean
        //     and Japanese IME only.
        Alpha = 8,
        //
        // Summary:
        //     Hangul DBC. This setting is valid for the Korean IME only.
        HangulFull = 9,
        //
        // Summary:
        //     Hangul SBC. This setting is valid for the Korean IME only.
        Hangul = 10,
        //
        // Summary:
        //     IME closed. This setting is valid for Chinese IME only.
        Close = 11,
        //
        // Summary:
        //     IME on HalfShape. This setting is valid for Chinese IME only.
        OnHalf = 12,
    }
}
