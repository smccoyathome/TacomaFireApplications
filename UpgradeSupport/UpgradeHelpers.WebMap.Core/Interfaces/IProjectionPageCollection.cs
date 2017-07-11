using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpgradeHelpers.WebMap.Server.Interfaces;

namespace UpgradeHelpers.Interfaces
{
    // Summary:
    //     Represents an interface to provide the access to a collection of pages in
    //     a report.
    public interface IProjectionPageCollection : IEnumerable<IProjectionPage>, IEnumerable
    {
        // Summary:
        //     Gets the number of pages in the report.
        int Count { get; }

        // Summary:
        //     Gets a page by index.
        //
        // Parameters:
        //   index:
        //     The index of the required page.
        //
        // Returns:
        //     The page that has the specified index.
        IProjectionPage this[int index] { get; }
    }
}
