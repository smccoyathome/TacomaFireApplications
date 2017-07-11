// // *************************************************************************************
// // <copyright company="Mobilize.Net" file="Border.cs" >
// //      Copyright (c) 2017 Mobilize, Inc. All Rights Reserved.
// //      All classes are provided for customer use only,
// //      all other use is prohibited without prior written consent from Mobilize.Net.
// //      no warranty express or implied,
// //      use at own risk.
// // </copyright>
// // <summary></summary>
// // ************************************************************************************* 

namespace FarPoint.ViewModels
{
    using System;

    /// <summary>
    /// Border Enumeration
    /// </summary>
    [Flags]
    public enum Border
    {
        None = 0,

        Left = 1,

        Top = 2,

        Right = 4,

        Bottom = 8
    }

    /// <summary>
    /// BorderStyle Enumeration
    /// </summary>
    [Obsolete]
    public enum BorderStyle
    {
        None = 0,

        FixedSingle = 1,

        Fixed3D = 2
    }
}