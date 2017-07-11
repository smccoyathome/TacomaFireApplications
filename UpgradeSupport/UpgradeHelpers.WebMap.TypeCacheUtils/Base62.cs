/// <summary>
/// A Base62 De- and Encoder
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace UpgradeHelpers.WebMap.Server
{
	internal static class Base62
	{
		private const string CharList = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

		private const int BASE = 62;

		/// <summary>
		/// Encode the given number into a Base62 string
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static String Encode(long input)
		{
			return  input.ToString();
			//if (input < 0) throw new ArgumentOutOfRangeException("input", input, "input cannot be negative");

			//char[] clistarr = CharList.ToCharArray();
			//var result = new Stack<char>();
			//while (input != 0)
			//{
			//	result.Push(clistarr[input % BASE]);
			//	input /= BASE;
			//}
			//return new string(result.ToArray());
		}

		/// <summary>
		/// Decode the Base62 Encoded string into a number
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static Int64 Decode(string input)
		{
			var reversed = input.Reverse();
			long result = 0;
			int pos = 0;
			foreach (char c in reversed)
			{
				result += CharList.IndexOf(c) * (long)Math.Pow(BASE, pos);
				pos++;
			}
			return result;
		}
	}
}