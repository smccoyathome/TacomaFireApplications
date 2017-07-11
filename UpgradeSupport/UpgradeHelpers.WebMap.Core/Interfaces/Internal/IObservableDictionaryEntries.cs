using System.Collections;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server
{
	internal interface IObservableDictionaryEntries
	{
        int CaseType { get; }
        void Initialize(IStateManager stateManager, IReferenceManager referenceManager, ISurrogateManager surrogateManager);
        IDictionary GetInternalDictionary(int caseType);
		void DeltaTrackerNotifications(bool onOff);
		//void Add (object key, object value);
	}
}