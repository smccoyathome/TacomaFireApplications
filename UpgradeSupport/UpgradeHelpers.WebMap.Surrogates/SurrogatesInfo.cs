using System;
using System.Collections.Generic;
using System.IO;
using UpgradeHelpers.Interfaces;


namespace UpgradeHelpers.WebMap
{

    /// <summary>
    /// Stores information necessary for "Surrogate" functionality in WebMap
    /// </summary>
    internal class SurrogatesInfo
    {
        public Type SupportedType { get; set; }
        public Action<object> InstantionDelegate { get; set; }
        public string Signature { get; set; }
        public IList<SurrogateDependencyCalculation> CalculateDependencies { get; set; }
        public Action<object, string, string, string, bool> RegisterBinding { get; set; }
        public Func<object> CreateInstanceFor { get; set; }
        public Action<object, Action<bool>> ApplyBindingHandlers { get; set; }
        public Func<object, string, object> PropertyGetter { get; set; }
        public Action<object, string, object> PropertySetter { get; set; }
        public SerializeSurrogate SerializeEx { get; set; }
        public DeserializeSurrogate DeSerializeEx { get; set; }
        public IsValidDependency IsValidDependency { get; set; }

        public Action<BinaryWriter, object> WriteComparer { get; set; }
    }
}