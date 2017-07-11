using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Helpers;
using System.ComponentModel;


namespace UpgradeHelpers.BasicViewModels
{
	public class PictureBoxViewModel : ControlViewModel
	{
		public override void Build(IIocContainer ctx)
		{
			base.Build(ctx);
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
