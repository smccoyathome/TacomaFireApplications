using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.BasicViewModels
{
	public class BindingSourceViewModel : ControlViewModel
	{
		/// <summary>
		///    Gets or sets the specific list in the data source to which the connector
		//     currently binds to.
		/// </summary>
		public virtual string DataMember { get; set; }
		/// <summary>
		/// Gets or sets the data source that the connector binds to
		/// </summary>
		public virtual object DataSource { get; set; }
		public override void Build(IIocContainer ctx)
		{
			base.Build(ctx);
			this.DataMember = string.Empty;
			this.DataMember = null;
		}
	}
}
