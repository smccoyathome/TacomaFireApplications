using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server
{

	/// <summary>
	/// Interface used to identify Form View Model and integrate them with the LifeCycle processing in particular with DisposeView Logic
	/// </summary>
	internal interface IFormBaseViewModel : IStateObject
	{


		bool IsDisposing { get; set; }
	}
}
