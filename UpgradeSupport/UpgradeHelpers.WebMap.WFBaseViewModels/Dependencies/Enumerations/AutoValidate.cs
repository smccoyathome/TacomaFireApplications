namespace UpgradeHelpers.Helpers
{
	public enum AutoValidate
    {
        // Summary:
        //     The control inherits its System.Windows.Forms.AutoValidate behavior from
        //     its container (such as a form or another control). If there is no container
        //     control, it defaults to System.Windows.Forms.AutoValidate.EnablePreventFocusChange.
        Inherit = -1,
        //
        // Summary:
        //     Implicit validation will not occur. Setting this value will not interfere
        //     with explicit calls to System.Windows.Forms.ContainerControl.Validate() or
        //     System.Windows.Forms.ContainerControl.ValidateChildren().
        Disable = 0,
        //
        // Summary:
        //     Implicit validation occurs when the control loses focus.
        EnablePreventFocusChange = 1,
        //
        // Summary:
        //     Implicit validation occurs, but if validation fails, focus will still change
        //     to the new control. If validation fails, the System.Windows.Forms.Control.Validated
        //     event will not fire.
        EnableAllowFocusChange = 2,
    }
}