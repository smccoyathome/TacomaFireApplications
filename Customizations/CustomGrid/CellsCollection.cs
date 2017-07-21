// *************************************************************************************
// <copyright company="Mobilize" file="CellsCollection.cs" >
//      Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
//      All helper classes are provided for customer use only;
//      all other use is prohibited without prior written consent from Mobilize.Net.
//      no warranty express or implied;
//      use at own risk.
// </copyright>
// <summary></summary>
// *************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace Custom.ViewModels.Grid
{
    /// <summary>
    /// Collection for the Cells
    /// </summary>
    public class CellsCollection : IDependentViewModel, ICreatesObjects
    {
        public string UniqueID { get; set; }

        public virtual IList<UltraGridCell> Items { get; set; }

        public void Build(IIocContainer ctx)
        {
            Items = ctx.Resolve<IList<UltraGridCell>>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public UltraGridCell this[string key]
        {
            get { return Items.FirstOrDefault(x => x.Key.Equals(key)); }
            set
            {
                var cell = Items.FirstOrDefault(x => x.Key.Equals(key));
                var index = Items.IndexOf(cell);
                if (index > -1)
                {
                    Items[index] = value;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public UltraGridCell this[int index]
        {
            get { return Items.ElementAt(index); }
            set
            {
                Items[index] = value;

            }
        }

        [StateManagement(StateManagementValues.None)]
        /// <summary>
        /// Returns the number of elements in this collection.
        /// </summary>
        public int Count => Items.Count;

        public IIocContainer Container { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newCell"></param>
        /// <returns></returns>
        public UltraGridCell Insert(int index, UltraGridCell newCell)
        {
            if (Items.Count > index)
            {
                Items[index] = newCell;
            }
            else
            {
                Items.Add(newCell);
            }
            return newCell;
        }

        /// <summary>
        /// Gets the index of item
        /// </summary>
        /// <param name="key">Value that identifies an object in a collection</param>
        /// <returns>The index of the item collection or -1 if key not found</returns>
        public int IndexOf(string key)
        {
            return Items.IndexOf(Items.FirstOrDefault(x => x.Key.Equals(key)));
        }
    }
}