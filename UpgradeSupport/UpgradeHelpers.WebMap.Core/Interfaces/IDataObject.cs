using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpgradeHelpers.Interfaces
{
    public interface IDataObject
    {

        bool GetDataPresent(object p);

        object GetData(object p);
    }
}
