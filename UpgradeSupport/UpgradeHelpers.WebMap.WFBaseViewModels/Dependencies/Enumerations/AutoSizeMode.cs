namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Specifies how a control will behave when its System.Windows.Forms.Control.AutoSize
	//     property is enabled.
	public enum AutoSizeMode
    {
        // Summary:
        //     The control grows or shrinks to fit its contents. The control cannot be resized
        //     manually.
        GrowAndShrink = 0,
        //
        // Summary:
        //     The control grows as much as necessary to fit its contents but does not shrink
        //     smaller than the value of its System.Windows.Forms.Control.Size property.
        //     The form can be resized, but cannot be made so small that any of its contained
        //     controls are hidden.
        GrowOnly = 1,
    }
}
