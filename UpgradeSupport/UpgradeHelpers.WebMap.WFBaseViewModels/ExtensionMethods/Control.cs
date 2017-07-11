using System;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Helpers
{
	public class Control
	{
		public static int GetModifierKeys()
		{
			return default(int);
		}

		public static int Get_ModifierKeys()
		{
			return default(int);
		}
	}
}

namespace UpgradeHelpers.Extensions
{

	[Obsolete("Extension only provided for compilation purposes")]
	public static class FormViewModelExtensions
	{
		[Obsolete("Extension only provided for compilation purposes")]
		public static System.IntPtr Get_Handle(this IViewModel instance)
		{
			return default(System.IntPtr);
		}

		[Obsolete("Extension only provided for compilation purposes")]
		public static void Set_Cursor(this IViewModel instance, Cursor cursor)
		{
		}

		[Obsolete("Extension only provided for compilation purposes")]
		public static System.IntPtr GetHandle(this IViewModel instance)
		{
			return default(System.IntPtr);
		}
		[Obsolete("Extension only provided for compilation purposes")]
		public static void SetCursor(this IViewModel instance, Cursor cursor)
		{
		}
	}

	[Obsolete("Extension only provided for compilation purposes")]
	public static class ILogicExtensions
	{
		[Obsolete("Extension only provided for compilation purposes")]
		public static void Set_Cursor<TVM>(this ILogicWithViewModel<TVM> instance, Cursor cursor) where TVM : IViewModel
		{
		}

		[Obsolete("Extension only provided for compilation purposes")]
		public static Cursor Get_Cursor<TVM>(this ILogicWithViewModel<TVM> instance) where TVM : IViewModel
		{
			return null;
		}

		[Obsolete("Extension only provided for compilation purposes")]
		public static Cursor GetCursor<TVM>(this ILogicWithViewModel<TVM> instance) where TVM : IViewModel
		{
			return null;
		}

		[Obsolete("Extension only provided for compilation purposes")]
		public static void SetCursor<TVM>(this ILogicWithViewModel<TVM> instance, Cursor cursor) where TVM : IViewModel
		{

		}

	}


	public static partial class ControlExtensions
	{
		public static void Set_Cursor(this IControl instance, Cursor argName)
		{
		}

		public static System.IntPtr Get_Handle(this IControl instance)
		{
			return default(System.IntPtr);
		}

		public static Cursor Get_Cursor(this IControl instance)
		{
			return default(Cursor);
		}

		public static void Call_Refresh(this IControl instance)
		{

		}

		public static void SetCursor(this IControl instance, Cursor argName)
		{
		}

		public static System.IntPtr GetHandle(this IControl instance)
		{
			return default(System.IntPtr);
		}

		public static Cursor GetCursor(this IControl instance)
		{
			return default(Cursor);
		}

		public static void CallRefresh(this IControl instance)
		{

		}
	}
}