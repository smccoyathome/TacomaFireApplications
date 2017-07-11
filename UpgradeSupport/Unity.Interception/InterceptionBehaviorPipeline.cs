// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity.InterceptionExtension
{
    /// <summary>
    /// The InterceptionBehaviorPipeline class encapsulates a list of <see cref="IInterceptionBehavior"/>s
    /// and manages calling them in the proper order with the right inputs.
    /// </summary>
    public class InterceptionBehaviorPipeline
    {

        IInterceptionBehavior interceptionBehaviors;

 

        /// <summary>
        /// Execute the pipeline with the given input.
        /// </summary>
        /// <param name="input">Input to the method call.</param>
        /// <param name="target">The ultimate target of the call.</param>
        /// <returns>Return value from the pipeline.</returns>
        public VirtualMethodInvocation Invoke(VirtualMethodInvocation input, InvokeInterceptionBehaviorDelegate target)
        {
            if (interceptionBehaviors == null)
            {
                return target(input, null);
            }
            return interceptionBehaviors.Invoke(input, ()=>target);
        }

        /// <summary>
        /// Adds a <see cref="IInterceptionBehavior"/> to the pipeline.
        /// </summary>
        /// <param name="interceptionBehavior">The interception behavior to add.</param>
        public void Add(IInterceptionBehavior interceptionBehavior)
        {
            interceptionBehaviors = interceptionBehavior;
        }
    }
}
