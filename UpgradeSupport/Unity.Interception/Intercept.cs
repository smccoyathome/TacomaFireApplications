// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.Practices.Unity.InterceptionExtension.Properties;
using Microsoft.Practices.Unity.Utility;
using System.Linq.Expressions;

namespace Microsoft.Practices.Unity.InterceptionExtension
{




	/// <summary>
	/// High-level API for performing interception on existing and new objects.
	/// </summary>
	public static class Intercept
	{

		static VirtualMethodInterceptor _typeInterceptor = new VirtualMethodInterceptor();


		static class ProxyCache<T>
		{
			public static readonly Func<T> Instance = CreateNewInstance();

			static Func<T> CreateNewInstance()
			{

				Type interceptionType = _typeInterceptor.CreateProxyType(typeof(T), false).Item1;
				return Expression.Lambda<Func<T>>(Expression.New(interceptionType)).Compile();
			}
		}

		/// <summary>
		/// Creates a new instance of type <typeparamref name="T"/> that is intercepted with the behaviors in 
		/// <paramref name="interceptionBehaviors"/>.
		/// </summary>
		/// <typeparam name="T">The type of the object to create.</typeparam>
		/// <param name="interceptionBehaviors">The interception behaviors for the new proxy.</param>
		/// <param name="constructorParameters">The arguments for the creation of the new instance.</param>
		/// <returns>An instance of a class compatible with <typeparamref name="T"/> that includes execution of the
		/// given <paramref name="interceptionBehaviors"/>.</returns>
		/// <exception cref="ArgumentNullException">when <paramref name="interceptor"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentNullException">when <paramref name="interceptionBehaviors"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException">when <paramref name="interceptor"/> cannot intercept 
		/// <typeparamref name="T"/>.</exception>
		public static T NewInstance<T>(IInterceptionBehavior interceptionBehavior)
			where T : class
		{
			var proxy = ProxyCache<T>.Instance();
			((IInterceptingProxy)proxy).AddInterceptionBehavior(interceptionBehavior);
			return proxy;
		}


		/// <summary>
		/// Creates a new instance of type <paramref name="type"/> that is intercepted with the behaviors in 
		/// <paramref name="interceptionBehaviors"/>.
		/// </summary>
		/// <param name="type">The type of the object to create.</param>
		/// <param name="interceptionBehaviors">The interception behaviors for the new proxy.</param>
		/// <returns>An instance of a class compatible with <paramref name="type"/> that includes execution of the
		/// given <paramref name="interceptionBehaviors"/>.</returns>
		/// <exception cref="ArgumentException">when <paramref name="interceptor"/> cannot intercept 
		/// <paramref name="type"/>.</exception>
		public static object NewInstance(Type type, IInterceptionBehavior interceptionBehavior)
		{
			var tuple = _typeInterceptor.CreateProxyType(type, true);
			var proxy = (IInterceptingProxy)tuple.Item2();
			proxy.AddInterceptionBehavior(interceptionBehavior);
			return proxy;
		}
		public static Type PreLoadProxyType(Type type)
		{
			return _typeInterceptor.CreateProxyType(type).Item1;
		}
	}
}
