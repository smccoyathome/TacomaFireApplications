using System;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.BasicViewModels
{
	/// <summary>
	/// ViewModel to represent the state of a button
	/// </summary>
	public class ButtonViewModel : ControlViewModel
	{

		/// <summary>
		/// Setup the model properties with its default values
		/// </summary>
		public override void Build(IIocContainer ctx)
		{
			base.Build(ctx);
			// CanSelect DefaultValue
			CanSelect = true;
		}

		/// <summary>
		/// Generates a Click Event for a Button
		/// </summary>
		public void PerformClick()
		{
			ViewManager.Events.Publish("click", this, this, new EventArgs());
		}

		public new void Select()
		{
			this.Enabled = true;
			this.Visible = true;
		}

        [StateManagement(StateManagementValues.Both)]
        public override bool AllowDrop
        {
            get
            {
                return base.AllowDrop;
            }

            set
            {
                base.AllowDrop = value;
            }
        }
    }
}
