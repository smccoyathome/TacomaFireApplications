using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server.Surrogates
{
	internal class SurrogateContext : ISurrogateContext
	{
        public const string EventsSeparator = "+";
        public string SurrogateUniqueID { get; set; }        
        public List<object> Dependencies		{
			get
			{
				if (Value != null)
				{
                    //Value != null means that the surrogate is being written
					return DependencyManager.GetDependencies(Value);
				}
				else
				{
					if (_restoredDependencies == null)
					{
						_restoredDependencies = new List<object>();
					}
					return _restoredDependencies;

				}
			}
		}

		internal ISurrogateDependencyManager DependencyManager { get; set; }
		public IViewManager _viewManager { get; set; }
		public IStateManager _stateManager { get; set; }
		public SurrogateManager _surrogateManager { get; set; }

		public object Value { get; set; }

		public void WriteDependencies(Action<string> callback)
		{
			DependencyManager.WriteDependencies(Value, callback);
		}

		public int DependencyCount
		{
			get
			{
				return Dependencies == null ? 0 : Dependencies.Count;
			}
		}

        public void RestoreDependency(string UniqueId, string comparer, IsValidDependency isValidDependency)
		{
			var isEvent = UniqueId.IndexOf(EventsSeparator);
			//Gets the dependency value from storage if any.
			var dependency = _stateManager.GetObject(UniqueId);
			var surrogate = dependency as StateObjectSurrogate;
			if (String.IsNullOrWhiteSpace(UniqueId))
			{
				Dependencies.Add(null);
				return;
			}

			if (isEvent != -1)
			{
				var eventInfo = new SurrogateEventsInfo()
				{
					EventId = UniqueId.Substring(0, isEvent),
					EventName = UniqueId.Substring(++isEvent)
				};

				Dependencies.Add(eventInfo);

				return;
			}
			if (dependency == null)
			{
				if (_stateManager.IsInElementsToRemove(UniqueId))
					//Its OK to return "null" if the object is in the elements to be removed, 
					//if not returned the dependency list gets inconsistent.
					Dependencies.Add(null);
				return;
			}

			//The dependency must be valid:
			//1. The dependency value can be retrieved from storage or cache.
			//2. If it is a surrogate the value cannot be null.
			//3. The dependency must be registered as a valid dependency for the surrogate instance.
			object dependencyValue = (surrogate != null && surrogate.Value != null) ? surrogate.Value : dependency;
			var verifiedDependency = (isValidDependency == null) ? true : isValidDependency(dependencyValue, comparer);

			if (verifiedDependency)
				Dependencies.Add(dependencyValue);
		}

        public void RemoveDependency(object dataTable)
        {
            _surrogateManager.RemoveDependency(dataTable, this.SurrogateUniqueID);
        }

        private List<object> _restoredDependencies;


        public object GetStateObjectSurrogate(object newValueObject, bool generateIfNotFound)
        {
            return _surrogateManager.GetStateObjectSurrogate(newValueObject, generateIfNotFound);
        }


        public IStateObject RestoreStateObject(string uniqueID)
        {
            return _stateManager.GetObject(uniqueID);
        }

        public void SubscribeEvent<T>(string eventID, string eventName, object value)
        {
            _surrogateManager.WireEvent<T>(eventID, eventName, value);
        }

        public object RestoreSurrogateValue(string uniqueID)
        {
            var surrogate = _surrogateManager.GetObject(uniqueID, isOkForSurrogateToBeMissing : false);
            return surrogate.Value;
        }


    }
}
