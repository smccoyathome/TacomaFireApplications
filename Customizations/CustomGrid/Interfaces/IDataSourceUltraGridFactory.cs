// *************************************************************************************
// <copyright company="Mobilize" file="IDataSourceUltraGridFactory.cs" >
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
    public delegate IDataSourceUltraGrid DataSourceCreationDelegate(object obj, UltraGridBase grid);

    public interface IDataSourceUltraGridFactory
    {
        void Register(DataSourceCreationDelegate @delegate);
        IDataSourceUltraGrid Create(object obj, UltraGridBase grid);
    }
}
