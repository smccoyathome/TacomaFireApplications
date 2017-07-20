// *************************************************************************************
// <copyright company="Mobilize" file="UltraGridCardSettings.cs" >
//      Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
//      All helper classes are provided for customer use only;
//      all other use is prohibited without prior written consent from Mobilize.Net.
//      no warranty express or implied;
//      use at own risk.
// </copyright>
// <summary></summary>
// *************************************************************************************
using System;

namespace Custom.ViewModels.Grid
{
    /// <summary>
    /// Class UltraGridCardSettings.
    /// </summary>
    public class UltraGridCardSettings
    {
        public bool AllowLabelSizing { get; set; }
        public bool AllowSizing { get; set; }
        public bool AutoFit { get; set; }
        public int CaptionLines { get; set; }
        public int LabelWidth { get; set; }
        public int MaxCardAreaCols { get; set; }
        public int MaxCardAreaRows { get; set; }
        public bool ShowCaption { get; set; }
        public int Style { get; set; }
        public int Width { get; set; }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}