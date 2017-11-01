using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.ViewModels.Grid
{
    /// <summary>
    /// This attribute is used to mark a property when it is not required to be shown in the client side (grid widget)
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class UltraGridExcludedColumnAttribute : System.Attribute
    {   
    }
}
