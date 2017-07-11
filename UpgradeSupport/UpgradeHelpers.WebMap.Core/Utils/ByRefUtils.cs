using System;

namespace UpgradeHelpers.Helpers
{
	public class ByRefUtils
	{

		public static void With<T1>(Action<T1> action, T1 arg1)
		{
			action.Method.Invoke(action.Target, new object[] { arg1 });
		}

		public static void With<T1, T2>(Action<T1, T2> action, T1 arg1, T2 arg2)
		{
			action.Method.Invoke(action.Target, new object[] { arg1, arg2 });
		}

		public static void With<T1, T2, T3>(Action<T1, T2, T3> action, T1 arg1, T2 arg2, T3 arg3)
		{
			action.Method.Invoke(action.Target, new object[] { arg1, arg2, arg3 });
		}

		public static void With<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			action.Method.Invoke(action.Target, new object[] { arg1, arg2, arg3, arg4 });
		}

		public static void With<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4,
			T5 arg5)
		{
			action.Method.Invoke(action.Target, new object[] { arg1, arg2, arg3, arg4, arg5 });
		}

		public static void With<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> action, T1 arg1, T2 arg2, T3 arg3,
			T4 arg4, T5 arg5, T6 arg6)
		{
			action.Method.Invoke(action.Target, new object[] { arg1, arg2, arg3, arg4, arg5, arg6 });
		}

		public static void With<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> action, T1 arg1, T2 arg2,
			T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			action.Method.Invoke(action.Target, new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
		}

		public static void With<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> action, T1 arg1,
			T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			action.Method.Invoke(action.Target, new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
		}

		public static void With<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action, T1 arg1,
			T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			action.Method.Invoke(action.Target, new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
		}

		public static void With<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
			Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7,
			T8 arg8, T9 arg9, T10 arg10)
		{
			action.Method.Invoke(action.Target, new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 });
		}

		public static TReturn WithReturn<T1, TReturn>(Func<T1, TReturn> func, T1 arg1)
		{
			return (TReturn)func.Method.Invoke(func.Target, new object[] { arg1 });
		}

		public static TReturn WithReturn<T1, T2, TReturn>(Func<T1, T2, TReturn> func, T1 arg1, T2 arg2)
		{
			return (TReturn)func.Method.Invoke(func.Target, new object[] { arg1, arg2 });
		}

		public static TReturn WithReturn<T1, T2, T3, TReturn>(Func<T1, T2, T3, TReturn> func, T1 arg1, T2 arg2, T3 arg3)
		{
			return (TReturn)func.Method.Invoke(func.Target, new object[] { arg1, arg2, arg3 });
		}

		public static TReturn WithReturn<T1, T2, T3, T4, TReturn>(Func<T1, T2, T3, T4, TReturn> func, T1 arg1, T2 arg2,
			T3 arg3, T4 arg4)
		{
			return (TReturn)func.Method.Invoke(func.Target, new object[] { arg1, arg2, arg3, arg4 });
		}

		public static TReturn WithReturn<T1, T2, T3, T4, T5, TReturn>(Func<T1, T2, T3, T4, T5, TReturn> func, T1 arg1, T2 arg2,
			T3 arg3, T4 arg4, T5 arg5)
		{
			return (TReturn)func.Method.Invoke(func.Target, new object[] { arg1, arg2, arg3, arg4, arg5 });
		}

		public static TReturn WithReturn<T1, T2, T3, T4, T5, T6, TReturn>(Func<T1, T2, T3, T4, T5, T6, TReturn> func, T1 arg1,
			T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			return (TReturn)func.Method.Invoke(func.Target, new object[] { arg1, arg2, arg3, arg4, arg5, arg6 });
		}

		public static TReturn WithReturn<T1, T2, T3, T4, T5, T6, T7, TReturn>(Func<T1, T2, T3, T4, T5, T6, T7, TReturn> func,
			T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			return (TReturn)func.Method.Invoke(func.Target, new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
		}

		public static TReturn WithReturn<T1, T2, T3, T4, T5, T6, T7, T8, TReturn>(
			Func<T1, T2, T3, T4, T5, T6, T7, T8, TReturn> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7,
			T8 arg8)
		{
			return (TReturn)func.Method.Invoke(func.Target, new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
		}

		public static TReturn WithReturn<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn>(
			Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7,
			T8 arg8, T9 arg9)
		{
			return (TReturn)func.Method.Invoke(func.Target, new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
		}

		public static TReturn WithReturn<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TReturn>(
			Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TReturn> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6,
			T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			return
				(TReturn)
					func.Method.Invoke(func.Target, new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 });
		}
	}
}
