using System;

namespace UpgradeHelpers.Helpers
{
	public class GridViewRowPresenter : FrameworkElement
    {


        #region From FrameworkElement
        public double ActualHeight { get; set; }

        #endregion



        public static readonly DependencyProperty ContentProperty;

        public GridViewRowPresenter()
        {
            throw new NotImplementedException();
        }

        public object Content { get; set; }

        protected override Size ArrangeOverride(Size arrangeSize)
        {
            throw new NotImplementedException();
        }

        protected Size MeasureOverride(Size constraint)
        {
            throw new NotImplementedException();
        }
        protected override int VisualChildrenCount { get { throw new NotImplementedException(); } }


        #region From GeneralTransform
        public Point Transform(Point point) { throw new NotImplementedException(); }

        #endregion

        protected virtual Visual GetVisualChild(int index)
        {
            throw new NotImplementedException();
        }

    }
}
