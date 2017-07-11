using System;

namespace Stubs._SAPBAPIControlLib
{

	public interface _CWdoAuto
	{

		object Connection { get; set; }

		object GetSAPObject(string ObjType, object ObjKey1, object ObjKey2, object ObjKey3, object ObjKey4, object
		ObjKey5, object ObjKey6, object ObjKey7, object ObjKey8, object ObjKey9, object ObjKey10);

	}

}