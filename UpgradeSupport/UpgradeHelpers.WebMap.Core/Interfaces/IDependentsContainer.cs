using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeHelpers.Interfaces
{
	public interface IDependentsContainer
	{
		List<string> Dependents { get; set; }
	}
}
