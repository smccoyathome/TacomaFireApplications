using System;

namespace UpgradeHelpers.WebMap.Server
{
	public class PromisesOnlySupportDelegatesFromClassesImplementingILogic : Exception
	{

		public PromisesOnlySupportDelegatesFromClassesImplementingILogic()
			:base("When delegates are used in Promises like patterns for example patterns like ...Then(delegate() { /* some code */ };\r\n" +
						"There are some limitations:\r\n" +
						"1. Those delegates must be on classes implementing ILogic interface\r\n" +
						"2. Delegates cannot use local variables, that is not supported in this version. If they do a workaround is to move those local variables to the ViewModel")
		{
			
		}
	}
}