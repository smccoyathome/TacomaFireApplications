using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Helpers
{
    public class ControlHelper
    {
        /// <summary>
        /// Sets the enabled of a IControl object
        /// </summary>
        /// <param name="ctl">The control</param>
        /// <param name="bEnable">The enabled value to set</param>
        public static void SetEnabled(IControl ctl, bool bEnable)
        {
            ctl.Enabled = bEnable;
        }

        /// <summary>
        /// Returns the enabled value of a IControl object
        /// </summary>
        /// <param name="ctl">The control</param>
        /// <returns>The enabled value</returns>
        public static bool GetEnabled(IControl ctl)
        {
            return ctl.Enabled;
        }

        /// <summary>
        /// Returns the tag of a IControl object
        /// </summary>
        /// <param name="ctl">The control</param>
        /// <returns>The tag value</returns>
        public static object GetTag(IControl ctl)
        {
            return ctl.Tag;
        }

        /// <summary>
        /// Sets the tag of a IControl object
        /// </summary>
        /// <param name="ctl">The control</param>
        /// <param name="sTag">The tag value to set</param>
        public static void SetTag(IControl ctl, string sTag)
        {
            ctl.Tag = sTag;
        }

        /// <summary>
        /// Returns the visible of a IControl object
        /// </summary>
        /// <param name="ctl">The control</param>
        /// <returns>The visible value</returns>
        public static bool GetVisible(IControl ctl)
        {
            return ctl.Visible;
        }

        /// <summary>
        /// Sets the visible value of a IControl object
        /// </summary>
        /// <param name="ctl">The control</param>
        /// <param name="bVisible">The visible value to set</param>
        public static void SetVisible(IControl ctl, bool bVisible)
        {
            ctl.Visible = bVisible;
        }
    }
}