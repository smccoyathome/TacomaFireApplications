// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Microsoft.Practices.Unity.InterceptionExtension
{
    internal struct GeneratedTypeKey
    {
        private readonly Type baseType;

        public GeneratedTypeKey(Type baseType)
        {
            this.baseType = baseType;
        }

        internal class GeneratedTypeKeyComparer : IEqualityComparer<GeneratedTypeKey>
        {
            public bool Equals(GeneratedTypeKey x, GeneratedTypeKey y)
            {
                if (!x.baseType.Equals(y.baseType))
                {
                    return false;
                }
                return true;
            }

            public int GetHashCode(GeneratedTypeKey obj)
            {
                return obj.baseType.GetHashCode();
            }
        }
    }
}
