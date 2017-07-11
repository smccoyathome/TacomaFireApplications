using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeHelpers.Interfaces
{

    public delegate bool IsValidDependency(object value, string dependencyUniqueID);

    /// <summary>
    /// The context that can be accessed during Surrogate serialization
    /// </summary>
    public interface ISurrogateContext
    {
        /// <summary>
        /// UniqueId of the surrogate that is currently being serialized or deserialized
        /// </summary>
        string SurrogateUniqueID { get; }

        /// <summary>
        /// The list of dependend objects that are needed when deserializing 
        /// </summary>
        List<object> Dependencies { get; }

        /// <summary>
        /// The number of Dependends
        /// </summary>
        int DependencyCount { get; }

        /// <summary>
        /// The current value. Available only during serialization
        /// </summary>
        object Value { get; set; }

        void WriteDependencies(Action<string> callback);
        void RestoreDependency(string storedIds, string comparer, IsValidDependency IsValidDependency);
        object GetStateObjectSurrogate(object newValueObject, bool generateIfNotFound);
        object RestoreSurrogateValue(string uniqueID);
        IStateObject RestoreStateObject(string uniqueID);
        void SubscribeEvent<T>(string eventID, string eventName, object value);
        void RemoveDependency(object dataTable);
    }
}
