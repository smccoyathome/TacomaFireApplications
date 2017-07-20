// *************************************************************************************
// <copyright company="Mobilize" file="DataTypeExtension.cs" >
//      Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
//      All helper classes are provided for customer use only;
//      all other use is prohibited without prior written consent from Mobilize.Net.
//      no warranty express or implied;
//      use at own risk.
// </copyright>
// <summary></summary>
// *************************************************************************************
namespace Custom.ViewModels.Grid.Extensions
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class DataTypeExtension.
    /// </summary>
    public static class DataTypeExtension
    {
        /// <summary>
        /// The styles
        /// </summary>
        public static IDictionary<Type, ColumnStyle> Styles
            =>
                new Dictionary<Type, ColumnStyle>
                    {
                        { typeof(int), ColumnStyle.Integer },
                        { typeof(DateTime), ColumnStyle.DateTime },
                        { typeof(bool), ColumnStyle.CheckBox },
                        { typeof(double), ColumnStyle.Double },
                        { typeof(IList<>), ColumnStyle.DropDown },
                        { typeof(TimeSpan), ColumnStyle.Time }
                    };

        /// <summary>
        /// As the style.
        /// </summary>
        /// <param name="dataType">Type of the data.</param>
        /// <returns>the ColumnStyle.</returns>
        public static ColumnStyle ToStyle(this Type dataType)
        {
            return Styles.ContainsKey(dataType) ? Styles[dataType] : ColumnStyle.Default;
        }
    }
}