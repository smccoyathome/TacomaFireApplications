// <copyright file="CollectionSupportExtensions.cs" company="Mobilize.Net">
// Copyright (c) Mobilize.Net. All rights reserved.
// </copyright>

namespace UpgradeHelpers.WebMap.Server
{
    using System;
    using System.Collections.Generic;

    internal static class CollectionSupportExtensions
    {
        private static Type iListGenericType = typeof(IList<>);
        private static Type iDictionaryGenericType = typeof(IDictionary<,>);

        /// <summary>
        /// Validates if the type is an IList or IDictionary which are the collection types that
        /// supported on WebMap ViewModels
        /// </summary>
        /// <param name="t">The type to be verified sa supported collection type</param>
        /// <returns>
        /// Indicates if the given parameter is considered as a collection supported type
        /// </returns>
        internal static bool IsSupportedCollectionType(this Type t)
        {
            if (t.IsGenericType && t.IsInterface)
            {
                var genericTypeDefinition = t.GetGenericTypeDefinition();
                return genericTypeDefinition == iListGenericType ||
                       genericTypeDefinition == iDictionaryGenericType;
            }

            return false;
        }
    }
}