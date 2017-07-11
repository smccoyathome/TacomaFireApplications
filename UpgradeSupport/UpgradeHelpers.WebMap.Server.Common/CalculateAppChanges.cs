using System.IO;
using System.Web;

namespace UpgradeHelpers.WebMap.Server
{
	public delegate void CalculateAppChanges(TextWriter writer,PiggyBackResult piggyBackingResult);

	public delegate object PiggyBackResult(object appChanges);
}