using System;
using System.ComponentModel;
using System.Globalization;

namespace UpgradeHelpers.Helpers
{
    public enum DataSourceUpdateMode
    {
        OnValidation,
        OnPropertyChanged,
        Never,
    }
}