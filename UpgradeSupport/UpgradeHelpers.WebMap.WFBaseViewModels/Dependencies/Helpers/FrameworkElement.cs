using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using UpgradeHelpers.Helpers.Windows;

namespace UpgradeHelpers.Helpers
{
    public class FrameworkElement : UIElement, ISupportInitialize
    {

        public void BeginInit()
        {
            throw new NotImplementedException();
        }

        public void EndInit()
        {
            throw new NotImplementedException();
        }

        public Style Style { get; set; }
        public int ActualWidth { get; set; }
        public Thickness Margin { get; set; }

        protected virtual Size ArrangeOverride(Size finalSize)
        {
            throw new NotImplementedException();
        }

        protected override int VisualChildrenCount { get { throw new NotImplementedException(); } }

        public event UpgradeHelpers.Events.SizeChangedEventHandler SizeChanged;
    }
}
