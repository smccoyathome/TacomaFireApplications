using System;
using System.Runtime.InteropServices;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server.Common
{
	public  class StructsWatcher : IDeltaWatcher
	{
		public byte[] GetAsBytes(object theStruct)
		{
			// converts a struct to byte[]
			int rawSize = Marshal.SizeOf(theStruct);
			IntPtr buffer = Marshal.AllocHGlobal(rawSize);
			Marshal.StructureToPtr(theStruct, buffer, false);
			byte[] rawDatas = new byte[rawSize];
			Marshal.Copy(buffer, rawDatas, 0, rawSize);
			Marshal.FreeHGlobal(buffer);
			return rawDatas;
		}

	}
}
