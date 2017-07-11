using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.BasicViewModels
{
	/// <summary>
	/// Represents a model that can be used for an status strip on the view
	/// </summary>
	public class StatusStripViewModel : ScrollableControlViewModel
	{

		[JsonProperty("@k")]
		public int k = 1;

		public virtual ToolStripItemCollectionViewModel Items { get; set; }

		/// <summary>
		/// Setup the model properties with its default values
		/// </summary>
		public override void Build(IIocContainer ctx)
		{
			base.Build(ctx);
			Items = StaticContainer.Instance.Resolve<ToolStripItemCollectionViewModel>();
		}

	}
}
