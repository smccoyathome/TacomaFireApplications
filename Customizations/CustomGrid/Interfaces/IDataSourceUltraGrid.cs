// *************************************************************************************
// <copyright company="Mobilize" file="IDataSourceUltraGrid.cs" >
//      Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
//      All helper classes are provided for customer use only;
//      all other use is prohibited without prior written consent from Mobilize.Net.
//      no warranty express or implied;
//      use at own risk.
// </copyright>
// <summary></summary>
// *************************************************************************************
namespace Custom.ViewModels.Grid
{
    public interface IDataSourceUltraGrid
    {
        UltraGridBase _grid { get; set; }
        void IDataSource(object datasource, UltraGridBase grid);
        void Load();
        void SetColumns();

        void SetCells(UltraGridRow row);

        object GetItemContent(UltraGridRow row);

        object GetCellsAppearance(UltraGridRow row);
    }
}
