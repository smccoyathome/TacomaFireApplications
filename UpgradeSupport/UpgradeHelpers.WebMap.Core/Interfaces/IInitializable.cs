using System;
using System.Reflection;

namespace UpgradeHelpers.Interfaces
{
	/// <summary>
	/// This interface is used for the 
	/// field initializer statements.
	/// </summary>
	public interface IInitializableCommon
	{
		void Common();
	}


	/// <summary>
	/// This interface is used to implement a constructor replacement on the 
	/// classes and forms after migration.
	/// </summary>
	public interface IInitializable
	{
		void Init();
	}
	public interface IInitializable<T1> : IInitializable
	{
		void Init(T1 p1);
	}
	public interface IInitializable<T1, T2> : IInitializable
	{
		void Init(T1 p1, T2 p2);
	}
	public interface IInitializable<T1, T2, T3> : IInitializable
	{
		void Init(T1 p1, T2 p2, T3 p3);
	}

	public interface IInitializable<T1, T2, T3, T4> : IInitializable
	{
		void Init(T1 p1, T2 p2, T3 p3, T4 p4);
	}

	public interface IInitializable<T1, T2, T3, T4, T5> : IInitializable
	{
		void Init(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5);
	}

	public interface IInitializable<T1, T2, T3, T4, T5, T6> : IInitializable
	{
		void Init(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6);
	}

	public interface IInitializable<T1, T2, T3, T4, T5, T6, T7> : IInitializable
	{
		void Init(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7);
	}

	public interface IInitializable<T1, T2, T3, T4, T5, T6, T7, T8> : IInitializable
	{
		void Init(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8);
	}

	public interface IInitializable<T1, T2, T3, T4, T5, T6, T7, T8, T9> : IInitializable
	{
		void Init(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9);
	}

	public interface IInitializable<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : IInitializable
	{
		void Init(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10);
	}

	public interface IInitializable<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : IInitializable
	{
		void Init(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11);
	}

	public interface IInitializable<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : IInitializable
	{
		void Init(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12);
	}

	public interface IInitializable<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : IInitializable
	{
		void Init(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13);
	}

	public interface IInitializable<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : IInitializable
	{
		void Init(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14);
	}

	public interface IInitializable<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : IInitializable
	{
		void Init(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15);
	}

	public interface IInitializable<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> : IInitializable
	{
		void Init(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16);
	}

	public interface IInitializable<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> : IInitializable
	{
		void Init(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16, T17 p17);
	}


	public static class BaseClassFindInit
	{
        public static Func<Type, object[],Type[], MethodInfo> _findMethod;
	}

	/// <summary>
	/// Provides Extension to easily call the Initializer which are the WebMap equivalent of a constructor
	/// </summary>
	public static class InitHelperExtensions
	{
		public static void CallInit<TCt>(this ILogic logic, TCt ct)
		{
            var method = BaseClassFindInit._findMethod(ct as Type, null,null);
			if (method != null) method.Invoke(logic, null);
		}
		public static void CallInit<TCt, T1>(this ILogic logic, TCt ct, T1 t1)
		{
            var method = BaseClassFindInit._findMethod(ct as Type, new object[] { t1 }, new Type[]{typeof(T1)});
			if (method != null)method.Invoke(logic, new object[] { t1 });
		}
		public static void CallInit<TCt ,T1, T2>(this ILogic logic, TCt ct, T1 t1, T2 t2)
		{
            var method = BaseClassFindInit._findMethod(ct as Type, new object[] { t1, t2 }, new Type[] { typeof(T1), typeof(T2) });
			if (method != null) method.Invoke(logic, new object[] { t1, t2 });
		}
		public static void CallInit<TCt, T1, T2, T3>(this ILogic logic,TCt ct, T1 t1, T2 t2, T3 t3)
		{
            var method = BaseClassFindInit._findMethod(ct as Type, new object[] { t1, t2, t3 }, new Type[] { typeof(T1), typeof(T2), typeof(T3) });
			if (method != null) method.Invoke(logic, new object[] { t1, t2, t3 });
		}
		public static void CallInit<TCt, T1, T2, T3, T4>(this ILogic logic, TCt ct, T1 t1, T2 t2, T3 t3, T4 t4)
		{
            var method = BaseClassFindInit._findMethod(ct as Type, new object[] { t1, t2, t3, t4 }, new Type[] { typeof(T1), typeof(T2), typeof(T3),typeof(T4) });
			if (method != null) method.Invoke(logic, new object[] { t1, t2, t3, t4 });
		}
		public static void CallInit<TCt, T1, T2, T3, T4, T5>(this ILogic logic, TCt ct, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
		{
            var method = BaseClassFindInit._findMethod(ct as Type, new object[] { t1, t2, t3, t4, t5 }, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4),typeof(T5) });
			if (method != null) method.Invoke(logic, new object[] { t1, t2, t3, t4, t5 });
		}
		public static void CallInit<TCt, T1, T2, T3, T4, T5, T6>(this ILogic logic, TCt ct, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
		{
            var method = BaseClassFindInit._findMethod(ct as Type, new object[] { t1, t2, t3, t4, t5, t6 },new Type[] { typeof(T1), typeof(T2), typeof(T3),typeof(T4),typeof(T5),typeof(T6) });
			if (method != null) method.Invoke(logic, new object[] { t1, t2, t3, t4, t5, t6 });
		}
		public static void CallInit<TCt, T1, T2, T3, T4, T5, T6, T7>(this ILogic logic, TCt ct, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
		{
            var method = BaseClassFindInit._findMethod(ct as Type, new object[] { t1, t2, t3, t4, t5, t6, t7 },new Type[] { typeof(T1), typeof(T2), typeof(T3),typeof(T4),typeof(T5),typeof(T6),typeof(T7) });
			if (method != null) method.Invoke(logic, new object[] { t1, t2, t3, t4, t5, t6, t7 });
		}
		public static void CallInit<TCt, T1, T2, T3, T4, T5, T6, T7, T8>(this ILogic logic, TCt ct, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
		{
            var method = BaseClassFindInit._findMethod(ct as Type, new object[] { t1, t2, t3, t4, t5, t6, t7, t8 }, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7),typeof(T8) });
			if (method != null) method.Invoke(logic, new object[] { t1, t2, t3, t4, t5, t6, t7, t8 });
		}
		public static void CallInit<TCt, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogic logic, TCt ct, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
		{
            var method = BaseClassFindInit._findMethod(ct as Type, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9 }, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8) ,typeof(T9)});
			if (method != null) method.Invoke(logic, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9 });
		}
		public static void CallInit<TCt, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogic logic, TCt ct, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10)
		{
            var method = BaseClassFindInit._findMethod(ct as Type, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10 },new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7),typeof(T8) ,typeof(T9),typeof(T10)});
			if (method != null) method.Invoke(logic, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10 });
		}
		public static void CallInit<TCt, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogic logic, TCt ct, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11)
		{
            var method = BaseClassFindInit._findMethod(ct as Type, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11 }, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9) ,typeof(T10),typeof(T11)});
			if (method != null) method.Invoke(logic, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11 });
		}
		public static void CallInit<TCt, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogic logic, TCt ct, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12)
		{
			var method = BaseClassFindInit._findMethod(ct as Type, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12 }, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9) ,typeof(T10),typeof(T11),typeof(T12)});
			if (method != null) method.Invoke(logic, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12 });
		}
		public static void CallInit<TCt, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogic logic, TCt ct, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13)
		{
            var method = BaseClassFindInit._findMethod(ct as Type, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13 }, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12),typeof(T13) });
			if (method != null) method.Invoke(logic, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13 });
		}
		public static void CallInit<TCt, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogic logic, TCt ct, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14)
		{
            var method = BaseClassFindInit._findMethod(ct as Type, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14 }, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13),typeof(T14) });
			if (method != null) method.Invoke(logic, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14 });
		}
		public static void CallInit<TCt, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this ILogic logic, TCt ct, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15)
		{
            var method = BaseClassFindInit._findMethod(ct as Type, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15 }, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14) ,typeof(T15)});
			if (method != null) method.Invoke(logic, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15 });
		}
		public static void CallInit<TCt, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this ILogic logic, TCt ct, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16)
		{
            var method = BaseClassFindInit._findMethod(ct as Type, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16 }, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15),typeof(T16) });
			if (method != null) method.Invoke(logic, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16 });
		}
		public static void CallInit<TCt, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(this ILogic logic, TCt ct, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17)
		{
            var method = BaseClassFindInit._findMethod(ct as Type, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17 }, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15), typeof(T16),typeof(T17) });
			if (method != null) method.Invoke(logic, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17 });
		}

		/***********************************************************************************************************/
		/* Call Base Contructor Method */
		public static void CallBaseInit<TCt>(this ILogic logic, TCt ct)
		{
			var type = ct as Type;
			if (type != null)
			{
                var method = BaseClassFindInit._findMethod(type.BaseType, null,null);
				if (method != null) method.Invoke(logic, null);
			}
		}

		public static void CallBaseInit<TCt, T1>(this ILogic logic, TCt ct, T1 t1)
		{
			var type = ct as Type;
			if (type != null)
			{
                var method = BaseClassFindInit._findMethod(type.BaseType, new object[] { t1 },new Type[] { typeof(T1) });
				if (method != null) method.Invoke(logic, new object[] { t1 });
			}
		}

		public static void CallBaseInit<TCt, T1, T2>(this ILogic logic, TCt ct, T1 t1, T2 t2)
		{
			var type = ct as Type;
			if (type != null)
			{
                var method = BaseClassFindInit._findMethod(type.BaseType, new object[] { t1, t2 }, new Type[] { typeof(T1), typeof(T2)});
				if (method != null) method.Invoke(logic, new object[] { t1, t2 });
			}
		}

		public static void CallBaseInit<TCt, T1, T2, T3>(this ILogic logic, TCt ct, T1 t1, T2 t2, T3 t3)
		{
			var type = ct as Type;
			if (type != null)
			{
                var method = BaseClassFindInit._findMethod(type.BaseType, new object[] { t1, t2, t3 }, new Type[] { typeof(T1), typeof(T2), typeof(T3)});
				if (method != null) method.Invoke(logic, new object[] { t1, t2, t3 });
			}
		}

		public static void CallBaseInit<TCt, T1, T2, T3, T4>(this ILogic logic, TCt ct, T1 t1, T2 t2, T3 t3, T4 t4)
		{
			var type = ct as Type;
			if (type != null)
			{
                var method = BaseClassFindInit._findMethod(type.BaseType, new object[] { t1, t2, t3, t4 }, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) });
				if (method != null) method.Invoke(logic, new object[] { t1, t2, t3, t4 });
			}
		}

		public static void CallBaseInit<TCt, T1, T2, T3, T4, T5>(this ILogic logic, TCt ct, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
		{
			var type = ct as Type;
			if (type != null)
			{
                var method = BaseClassFindInit._findMethod(type.BaseType, new object[] { t1, t2, t3, t4, t5 }, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5)});
				if (method != null) method.Invoke(logic, new object[] { t1, t2, t3, t4, t5 });
			}
		}

		public static void CallBaseInit<TCt, T1, T2, T3, T4, T5, T6>(this ILogic logic, TCt ct, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
		{
			var type = ct as Type;
			if (type != null)
			{
                var method = BaseClassFindInit._findMethod(type.BaseType, new object[] { t1, t2, t3, t4, t5, t6 }, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6) });
				if (method != null) method.Invoke(logic, new object[] { t1, t2, t3, t4, t5, t6 });
			}
		}

		public static void CallBaseInit<TCt, T1, T2, T3, T4, T5, T6, T7>(this ILogic logic, TCt ct, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
		{
			var type = ct as Type;
			if (type != null)
			{
                var method = BaseClassFindInit._findMethod(type.BaseType, new object[] { t1, t2, t3, t4, t5, t6, t7 }, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7)});
				if (method != null) method.Invoke(logic, new object[] { t1, t2, t3, t4, t5, t6, t7 });
			}
		}

		public static void CallBaseInit<TCt, T1, T2, T3, T4, T5, T6, T7, T8>(this ILogic logic, TCt ct, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
		{
			var type = ct as Type;
			if (type != null)
			{
                var method = BaseClassFindInit._findMethod(type.BaseType, new object[] { t1, t2, t3, t4, t5, t6, t7, t8 }, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8)});
				if (method != null) method.Invoke(logic, new object[] { t1, t2, t3, t4, t5, t6, t7, t8 });
			}
		}

		public static void CallBaseInit<TCt, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogic logic, TCt ct, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
		{
			var type = ct as Type;
			if (type != null)
			{
                var method = BaseClassFindInit._findMethod(type.BaseType, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9 }, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9)});
				if (method != null) method.Invoke(logic, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9 });
			}
		}

		public static void CallBaseInit<TCt, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogic logic, TCt ct, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10)
		{
			var type = ct as Type;
			if (type != null)
			{
                var method = BaseClassFindInit._findMethod(type.BaseType, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10 }, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10)});
				if (method != null) method.Invoke(logic, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10 });
			}
		}

		public static void CallBaseInit<TCt, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogic logic, TCt ct, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11)
		{
			var type = ct as Type;
			if (type != null)
			{
                var method = BaseClassFindInit._findMethod(type.BaseType, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11 }, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11) });
				if (method != null) method.Invoke(logic, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11 });
			}
		}

		public static void CallBaseInit<TCt, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogic logic, TCt ct, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12)
		{
			var type = ct as Type;
			if (type != null)
			{
                var method = BaseClassFindInit._findMethod(type.BaseType, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12 }, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12)});
				if (method != null) method.Invoke(logic, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12 });
			}
		}

		public static void CallBaseInit<TCt, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogic logic, TCt ct, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13)
		{
			var type = ct as Type;
			if (type != null)
			{
                var method = BaseClassFindInit._findMethod(type.BaseType, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13 }, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13)});
				if (method != null) method.Invoke(logic, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13 });
			}
		}

		public static void CallBaseInit<TCt, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogic logic, TCt ct, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14)
		{
			var type = ct as Type;
			if (type != null)
			{
                var method = BaseClassFindInit._findMethod(type.BaseType, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14 }, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14)});
				if (method != null) method.Invoke(logic, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13 , t14});
			}
		}

		public static void CallBaseInit<TCt, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this ILogic logic, TCt ct, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15)
		{
			var type = ct as Type;
			if (type != null)
			{
                var method = BaseClassFindInit._findMethod(type.BaseType, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15 }, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15)});
				if (method != null) method.Invoke(logic, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15 });
			}
		}

		public static void CallBaseInit<TCt, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this ILogic logic, TCt ct, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16)
		{
			var type = ct as Type;
			if (type != null)
			{
                var method = BaseClassFindInit._findMethod(type.BaseType, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16 }, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15), typeof(T16) });
				if (method != null) method.Invoke(logic, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16 });
			}
		}

		public static void CallBaseInit<TCt, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(this ILogic logic, TCt ct, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17)
		{
			var type = ct as Type;
			if (type != null)
			{
                var method = BaseClassFindInit._findMethod(type.BaseType, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17 }, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15), typeof(T16),typeof(T17) });
				if (method != null) method.Invoke(logic, new object[] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17 });
			}
		}

	}




}
