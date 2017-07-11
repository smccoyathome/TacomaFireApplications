using System;
namespace UpgradeHelpers.Interfaces
{
	public interface ISurrogateDependencyManager
	{
		System.Collections.Generic.List<object> GetDependencies(object obj);
		void ProcessDependencies();
		//System.Collections.Generic.List<object> RestoreDependencies(object value);
		void WriteDependencies(object obj, Action<string> callback);
		int DependencyCount(object value);
		ISurrogateEventsInfo ProcessEventDelegate<T>(string fieldName, string eventName, object value);
	}

    public interface ISurrogateDependenciesContext
    {
        ISurrogateEventsInfo ProcessEventDelegate<T>(string fieldName, string eventName, object value);
    }
	public interface ISurrogateEventsInfo
	{
		string EventId { get; set; }
		 string EventName { get; set; }

	}
}
