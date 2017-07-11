using System;
using Stubs._Microsoft.Office.Interop.Word;

namespace Stubs._Microsoft.Office.Interop.Word
{

	public interface Documents
	{

		Document Add(ref object Template, ref object NewTemplate, ref object DocumentType, ref object Visible);

	}

}