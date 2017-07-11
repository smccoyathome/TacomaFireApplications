// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace Microsoft.Practices.Unity.InterceptionExtension
{


    public partial class VirtualMethodInvocation 
    {
		public bool newInstance;
        /// <summary>
        /// Field to hold the return value
        /// </summary>
        public object myReturnValue;

		public int MethodType {get;set;}

#pragma warning disable		
		public UpgradeHelpers.WebMap.Server.PropertyInfoEx PropertyInfo { get; set; }
#pragma warning restore

		/// <summary>
        /// 
        /// </summary>
        public object ReturnValue
        {
            get
            {
                return myReturnValue;
            }

            set
            {
                myReturnValue = value;
            }
        }
    };


    /// <summary>
    /// Implementation of <see cref="IMethodInvocation"/> used
    /// by the virtual method interceptor.
    /// </summary>
    public partial class VirtualMethodInvocation 
    {
        //private readonly ParameterCollection inputs;
        //private readonly ParameterCollection arguments;
        //private readonly Dictionary<string, object> context;
        private readonly object target;

        /// <summary>
        /// Constructor for set calls
        /// </summary>
        /// <param name="target"></param>
        /// <param name="targetMethod"></param>
        /// <param name="returnValue"></param>
#pragma warning disable		
        public VirtualMethodInvocation(object target, object returnValue, int methodType, UpgradeHelpers.WebMap.Server.PropertyInfoEx propertyInfo)
        {
            this.target = target;
            this.myReturnValue = returnValue;
			this.MethodType = methodType;
			this.PropertyInfo = propertyInfo;
        }
#pragma warning restore



        /// <summary>
        /// Constructor For Get
        /// </summary>
        /// <param name="target"></param>
        /// <param name="targetMethod"></param>
		 #pragma warning disable		
        public VirtualMethodInvocation(object target, UpgradeHelpers.WebMap.Server.PropertyInfoEx propertyInfo)
        {
            this.target = target;
			this.MethodType = 2;
			this.PropertyInfo = propertyInfo;
        }
		#pragma warning restore



		/// <summary>
        /// The object that the call is made on.
        /// </summary>
        public object Target
        {
            get { return target; }
        }

        /// <summary>
        /// Factory method that creates the correct implementation of
        /// IMethodReturn.
        /// </summary>
        /// <param name="returnValue">Return value to be placed in the IMethodReturn object.</param>
        /// <returns>New IMethodReturn object.</returns>
        public VirtualMethodInvocation CreateMethodReturn(object returnValue)
        {
            this.myReturnValue = returnValue;
            return this;
        }

       
    }
}
