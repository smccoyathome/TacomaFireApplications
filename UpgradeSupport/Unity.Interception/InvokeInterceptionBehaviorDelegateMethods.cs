// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Reflection;

namespace Microsoft.Practices.Unity.InterceptionExtension
{
    internal static class InvokeInterceptionBehaviorDelegateMethods
    {
        internal static ConstructorInfo InvokeInterceptionBehaviorDelegate = typeof(InvokeInterceptionBehaviorDelegate)
                    .GetConstructor(new Type[] { typeof(object), typeof(IntPtr) } );
    }
}
