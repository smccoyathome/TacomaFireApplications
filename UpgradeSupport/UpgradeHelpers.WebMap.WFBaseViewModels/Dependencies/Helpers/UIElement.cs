using System;

namespace UpgradeHelpers.Helpers.Windows
{
	public class UIElement : Visual
	{
		#region From Visual, consider to review hierarchy
		public GridViewRowPresenter TransformToAncestor(GridViewRowPresenter ancestor) { throw new NotImplementedException(); }
		#endregion
		public void Measure(Size availableSize) { throw new NotImplementedException(); }
		public void Arrange(Rect finalRect) { throw new NotImplementedException(); }
	}
}
