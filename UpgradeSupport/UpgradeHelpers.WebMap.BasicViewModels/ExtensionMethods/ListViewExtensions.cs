// *************************************************************************************
//  <copyright  company="Mobilize" file="ListViewExtensions.cs">
//     Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
//      All helper classes are provided for customer use only;
//      all other use is prohibited without prior written consent from Mobilize.Net.
//      no warranty express or implied;
//      use at own risk.
//  </copyright>
// <summary></summary>
//  *************************************************************************************
namespace UpgradeHelpers.BasicViewModels.Extensions
{
    using System.Collections.Generic;
    using UpgradeHelpers.Helpers;

    /// <summary>
    /// The class is use to add extra functionality to the ListView Control
    /// </summary>
    public static class ListViewUtilityExtensions
    {
        public static ListViewItemViewModel Add(this IList<ListViewItemViewModel> collection, string text, int imageIndex)
        {
            var listViewItem = StaticContainer.Instance.Resolve<ListViewItemViewModel>();
            listViewItem.Text = text;
            listViewItem.ImageIndex = imageIndex;
            collection.Add(listViewItem);
            return listViewItem;
        }

        public static ListViewItemViewModel Add(this IList<ListViewItemViewModel> collection, string key, string text, int imageIndex = -1)
        {
            var listViewItem = StaticContainer.Instance.Resolve<ListViewItemViewModel>();
            listViewItem.Text = text;
            listViewItem.Name = key;
            listViewItem.ImageIndex = imageIndex;
            collection.Add(listViewItem);
            return listViewItem;
        }

        public static ColumnHeaderViewModel Add(this IList<ColumnHeaderViewModel> collection, string text, int columnWidth)
        {
            var columnHeader = StaticContainer.Instance.Resolve<ColumnHeaderViewModel>();
            columnHeader.Text = text;
            columnHeader.Width = columnWidth;
            collection.Add(columnHeader);
            return columnHeader;
        }

        public static ColumnHeaderViewModel Add(this IList<ColumnHeaderViewModel> collection, string key, string text, int columnWidth)
        {
            var columnHeader = StaticContainer.Instance.Resolve<ColumnHeaderViewModel>();
            columnHeader.Text = text;
            columnHeader.Name = key;
            columnHeader.Width = columnWidth;
            collection.Add(columnHeader);
            return columnHeader;
        }

        public static ColumnHeaderViewModel Add(this IList<ColumnHeaderViewModel> collection, string text, int columnWidth, Helpers.HorizontalAlignment horizontalAlignment)
        {
            var columnHeader = StaticContainer.Instance.Resolve<ColumnHeaderViewModel>();
            columnHeader.Text = text;
            columnHeader.Name = text;
            columnHeader.Width = columnWidth;
            collection.Add(columnHeader);
            return columnHeader;
        }

        public static ListViewItemViewModel Get_TopItem(this ListViewViewModel control)
        {
            return (ListViewItemViewModel)(control.GetType().GetProperty("TopItem") != null ? control.GetType().GetProperty("TopItem").GetValue(control, null) ?? null : null);
        }
    }

    /// <summary>
    /// This class is use to add extra functionality to the ListView
    /// </summary>
    public class ListViewHelper
    {
        public static ListViewSubItem GetListViewSubItem(UpgradeHelpers.BasicViewModels.ListViewItemViewModel listViewItem, int p)
        {
            return new ListViewSubItem(listViewItem, p);
        }
    }
}