using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.BasicViewModels
{
	/// <summary>
	///     A view model to hold state for element in the view which could be should as part of a toolbar
	/// </summary>
	public class ToolStripViewModel : ControlViewModel
	{

		/// <summary>
		///     Setup the model properties with its default values
		/// </summary>
		public override void Build(IIocContainer ctx)
		{
			base.Build(ctx);
			Items = ctx.Resolve<IList<ToolStripItemViewModel>>();
		}

		#region Data Members

		/// <summary>
		/// Shows or hides the contextMenu
		/// </summary>
		public virtual object[] ContextShow { get; set; }

		public virtual IList<ToolStripItemViewModel> Items { get; set; }
		#endregion

		#region Methods

		public ToolStripItemViewModel FindByKey(string key)
		{
			return Items.FirstOrDefault(item => item != null && item.Name != null && item.Name.Equals(key));
		}

		public void AddItem(ToolStripItemViewModel item)
		{
			var newItem = Container.Resolve<ToolStripItemViewModel>();
			newItem.Available = item.Available;
			newItem.Enabled = item.Enabled;
			newItem.ImageIndex = item.ImageIndex;
			newItem.Name = item.Name;
			newItem.Text = item.Text;
			newItem.ToolTipText = item.ToolTipText;
			newItem.Visible = item.Visible;
			newItem.Tag = item.Tag;
			Items.Add(newItem);
		}
		#endregion

		public void Show(object control, int x, int y)
		{
			ContextShow = new object[4];
			var stateObject = control as IStateObject;
			if (stateObject != null)
			{
				this.ContextShow[1] = stateObject.UniqueID;
			}
			var iLogicView = control as ILogicView<IViewModel>;
			if (iLogicView != null)
			{
				var viewName = iLogicView.ViewModel.Name;
				this.ContextShow[1] = viewName.Substring(viewName.LastIndexOf('.') + 1);
			}
			this.ContextShow[0] = true;
			this.ContextShow[2] = x;
			this.ContextShow[3] = y;
		}
	}
}