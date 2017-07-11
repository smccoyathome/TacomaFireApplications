using System;
using UpgradeHelpers.BasicViewModels;

namespace UpgradeHelpers.DoubleJumpSupport
{
    /// <summary>
    /// This helper gives support to the VBUC ComboBoxHelper
    /// </summary>
    public class ComboBoxHelper : ComboBoxViewModel
    {
        /// <summary>
        /// Clears the list of items
        /// </summary>
        public void Clear()
        {
            this.Items.Clear();
        }

        /// <summary>
        /// Handles if ComboBox was clicked.
        /// </summary>
        public virtual Boolean Clicked { get; set; }

        /// <summary>
        /// Get/Set List Index
        /// </summary>
        public virtual Int32 ListIndex
        {
            get
            {
                return this.SelectedIndex;
            }
            set
            {
                if (value >= 0 && value < this.Items.Count)
                {
                    this.SelectedIndex = value;
                }
            }
        }
    }
}
