using System;
using UpgradeHelpers.Interfaces;


namespace UpgradeHelpers.Helpers
{
	public static class Information
	{
		private static ErrObject errObj = new ErrObject();
		public static ErrObject Err()
		{
			return errObj;
		}
		//#if !PORTABLE
		//				public static Microsoft.VisualBasic.VariantType VarType(object VarName)
		//		{
		//			NotUpgradedHelper.NotifyNotUpgradedElement("Information.VarType");
		//						return default(Microsoft.VisualBasic.VariantType);
		//		}
		//#endif

		public static bool IsArray(string[] arrSearch)
		{
			throw new NotImplementedException();
		}

		public static bool IsDate(string p)
		{
			throw new NotImplementedException();
		}
	}

	public sealed class ErrObject
	{
		private Exception ex = null;
		public void Clear()
		{
			ex = null;
		}

		public int Number
		{
			get
			{
				// TODO: especific number exception?
				return (ex == null) ? 0 : -1;
			}
		}

		public string Description
		{
			get
			{
				return (ex == null) ? string.Empty : ex.Message;
			}
		}

		internal void SetError(Exception e)
		{
			ex = e;
		}
	}
}