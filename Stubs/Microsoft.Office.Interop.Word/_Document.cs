using System;
using Stubs._Microsoft.Office.Interop.Word;

namespace Stubs._Microsoft.Office.Interop.Word
{

	public interface _Document
	{

		void CheckSpelling(ref object CustomDictionary, ref object IgnoreUppercase, ref object AlwaysSuggest,
			ref object CustomDictionary2, ref object CustomDictionary3, ref object CustomDictionary4, ref object
			CustomDictionary5, ref object CustomDictionary6, ref object CustomDictionary7, ref object CustomDictionary8, ref object CustomDictionary9, ref object CustomDictionary10);

		Range Content { get; }

		void Activate();

		PageSetup PageSetup { get; set; }

	}

}