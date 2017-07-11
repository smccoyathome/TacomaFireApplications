// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Reflection;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity.InterceptionExtension

{


    internal static class VirtualMethodInvocationMethods
    {


        internal static FieldInfo GetReturnValue = typeof(VirtualMethodInvocation).GetField("myReturnValue", BindingFlags.Instance | BindingFlags.Public);


        internal static MethodInfo CreateReturn = typeof(VirtualMethodInvocation).GetMethod("CreateMethodReturn");



        internal static ConstructorInfo VirtualMethodInvocationContructorSet =
			StaticReflection.GetConstructorInfo(() => new VirtualMethodInvocation(default(object), default(object), default(int), default(UpgradeHelpers.WebMap.Server.PropertyInfoEx)));



        internal static ConstructorInfo VirtualMethodInvocationContructorGet = StaticReflection.GetConstructorInfo(
                    () => new VirtualMethodInvocation(default(object), default(UpgradeHelpers.WebMap.Server.PropertyInfoEx)));

    }
}
