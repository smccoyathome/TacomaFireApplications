using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Surrogates;

namespace UpgradeHelpers.WebMap
{
    public delegate IList<object> SurrogateDependencyCalculation(object value, ISurrogateDependenciesContext dependenciesContext);


    public delegate void SerializeSurrogate(object value, BinaryWriter writer, MemoryStream ms, ISurrogateContext context);

    public delegate object DeserializeSurrogate(BinaryReader reader, ISurrogateContext context);
    /// <summary>
    /// Centralized directory to register "Surrogates"
    /// </summary>
    public static class SurrogatesDirectory
	{
        static object _syncSurrogates = new object();
        internal static Func<Type, string> TypeToContractedString;
        internal static Func<string, Type> ContractedStringToType;
        static readonly Dictionary<Type, SurrogatesInfo> TypeToSurrogate = new Dictionary<Type, SurrogatesInfo>();
		static readonly Dictionary<string, SurrogatesInfo> SignatureToSurrogate = new Dictionary<string, SurrogatesInfo>();
		public const int SignatureMaxlenght = 8;


		/// <summary>
		/// DEFAULT action for applying binding changes
		/// First parameter is the target ViewModel uniqueID, second parameter is target ViewModel property name, and third parameter is new value
		/// </summary>
		internal static Action<string, string, object> defaultApplyBindingChangedAction;

        internal static Func<object, string, bool, string> GetUniqueIDForSurrogateDelegate;

        internal static Func<string, object> RestoreSurrogateDelegate;

		public static object RestoreSurrogate(string uniqueId)
		{
			return string.IsNullOrEmpty(uniqueId) ? null : RestoreSurrogateDelegate(uniqueId);
		}

        public static string GetUniqueIdForSurrogate(object obj, string parentUniqueId = null, bool generateIfNotFound = true)
        {
            return obj == null ? string.Empty : GetUniqueIDForSurrogateDelegate(obj, parentUniqueId, generateIfNotFound);
        }


        public static void RegisterSurrogate(
                string signature,
                Type supportedType,
                Action<object, Action<bool>> applyBindingAction = null,
                Func<object, string, object> PropertyGetter = null,
                Action<object, string, object> PropertySetter = null,
                IList<SurrogateDependencyCalculation> calculateDependencies = null,
                SerializeSurrogate serializeEx = null,
                DeserializeSurrogate deserializeEx = null,
                IsValidDependency isValidDependency = null,
                Action<BinaryWriter, object> writeComparer = null
        )
        {
            if (string.IsNullOrWhiteSpace(signature) || signature.Length > SignatureMaxlenght)
            {
                throw new ArgumentException(string.Format("Signature name must be a non null of maximum of {0} characters", SignatureMaxlenght));
            }
            signature = signature.PadLeft(SignatureMaxlenght);
            var surrogateInfo = new SurrogatesInfo()
            {
                SupportedType = supportedType,
                ApplyBindingHandlers = applyBindingAction,
                PropertyGetter = PropertyGetter,
                PropertySetter = PropertySetter,
                // Begin dependency calculation.
                CalculateDependencies = calculateDependencies,
                SerializeEx = serializeEx,
                DeSerializeEx = deserializeEx,
                IsValidDependency = isValidDependency,
                WriteComparer = writeComparer,
                //End dependency calculation.
                Signature = signature
            };
            lock (_syncSurrogates)
            {
                SurrogatesInfo dummy;
                if (!TypeToSurrogate.TryGetValue(supportedType, out dummy))
                {
                    TypeToSurrogate.Add(supportedType, surrogateInfo);
                    SignatureToSurrogate.Add(signature, surrogateInfo);
                    if (applyBindingAction != null || PropertyGetter != null || PropertySetter != null)
                    {
                        if (!(applyBindingAction != null && PropertyGetter != null && PropertySetter != null))
                        {
                            throw new ArgumentException("Invalid surrogate registration. If an ApplyBindingAction is given, then a PropertyGetter and a PropertySetter must be given too");
                        }
                    }
                }
            }
        }

		public static bool IsSurrogateRegistered(Type supportedType)
		{
            lock (_syncSurrogates)
            {
                        if (TypeToSurrogate.ContainsKey(supportedType)) return true;

                var isStateObject = (typeof(UpgradeHelpers.Interfaces.IStateObject).IsAssignableFrom(supportedType));
			
			if (supportedType.IsValueType || isStateObject)
				return false;
                //Generate new Surrogate 
                //Support ISerializable? Register a new surrogate for this type using a new instance of SurrogateByISerializable(type);
                if (typeof(System.Runtime.Serialization.ISerializable).IsAssignableFrom(supportedType))
                {
                    var signature = GenerateNewSurrogateFromType(supportedType);
                    var newSurrogateByISerializable = new SurrogateByISerializable(supportedType, signature);
                    RegisterSurrogate(
                        signature: signature,
                        supportedType: supportedType,
                        serializeEx: newSurrogateByISerializable.Serialize,
                        deserializeEx: newSurrogateByISerializable.Deserialize,
                        calculateDependencies: new SurrogateDependencyCalculation[] { SurrogateByISerializable.CalculateDependencies });
                    return true;
                }
                else
			{
				//Register a new surrogate for this type using a new instance of SurrogateByNewtonsoft(type);
				//var signature = GenerateNewSurrogateFromType(supportedType);
				//var newNewTon = new SurrogateByNewtonsoft(supportedType, signature);
				//RegisterSurrogate(GenerateNewSurrogateFromType(supportedType), supportedType, newNewTon.SerializeAction, newNewTon.DeserializeAction);
				return false;
			}
		}
		}

		public static string GenerateNewSurrogateFromType(Type supportedType)
		{
			var signature = supportedType.GetHashCode().ToString("X");
			if (signature.Length > SignatureMaxlenght)
			{
				throw new ArgumentException(string.Format("Invalid signature length. Max lenght is {0}", SignatureMaxlenght));
			}
			signature = signature.PadRight(SignatureMaxlenght);
			return signature;
		}


		public static object CreateInstanceFor(Type type)
		{
			return Activator.CreateInstance(type, true);
		}

		public static object ObjectToRaw(object obj, ISurrogateContext context)
		{
            lock (_syncSurrogates)
            {
                SurrogatesInfo info = null;
				if (obj != null && TypeToSurrogate.TryGetValue(obj.GetType(), out info))
				{
					object rawObject = null;
					using (var ms = new MemoryStream())
					{
						var binaryWriter = new BinaryWriter(ms);
						//The surrogate has registered dependencies
                        binaryWriter.Write(info.Signature);
						if (info.WriteComparer != null)
							info.WriteComparer(binaryWriter, obj);
						if (info.CalculateDependencies != null)
						{
							var count = context.DependencyCount;
							binaryWriter.Write(count);
                            if (count != 0)
							{
								//Writes the dependencies ids 
								context.WriteDependencies((uniqueId) => { binaryWriter.Write(uniqueId); });
							}
						}
                        else
                        {
                            //No Dependencies. Just write 0
                            binaryWriter.Write(0);
                        }
						info.SerializeEx(obj, binaryWriter, ms,context);
						rawObject = ms.ToArray();
					}

					return rawObject;
				}
                else
                {
                    if (obj!=null)
                    {
                        Trace.TraceError("No surrogate registered for type " + obj.GetType().FullName);
                        Trace.TraceError("This value will be lost in following requests");
                    }
                }
                return new object();//throw new NotSupportedException();//, MOBILIZE,9/4/2015,TODO,KMM,”Temporary code”, “Details related to ViewModels”
            }
		}
		/// <summary>
		/// Get the dependencies associated to an object.
		/// </summary>
		/// <param name="obj">Object instance</param>
		/// <param name="stateManager">StateManager instance</param>
		/// <param name="surrogateManager">SurrogateManager instance</param>
		/// <returns>List of dependencies</returns>
		public static List<object> GetObjectDependencies(object obj, IStateManager stateManager, ISurrogateManager surrogateManager, ISurrogateDependencyManager surrogateDependencyManager)
		{
			var result = new List<object>();
			lock (_syncSurrogates)
			{
				SurrogatesInfo info = null;
				if (obj != null && TypeToSurrogate.TryGetValue(obj.GetType(), out info))
				{
					//If there any dependencies register for this type?
					if (info.CalculateDependencies != null)
					{
						//Collects the object dependencies.
						foreach (var dependency in info.CalculateDependencies)
						{
							var dependencies = dependency(obj, (ISurrogateDependenciesContext)surrogateDependencyManager);
							if (dependencies != null)
							{
								result.AddRange(dependencies);
							}
						}
					}
				}
			}
			return result;
		}

		/// <summary>
		/// Validates that the string that will be used as a signature follows the expected format. Adjust length if necessary
		/// </summary>
		/// <param name="signature"></param>
		/// <returns></returns>
		public static string ValidSignature(string signature)
		{
			if (signature.Length > SignatureMaxlenght)
			{
				throw new ArgumentException(string.Format("Invalid signature length. Max lenght is {0}", SignatureMaxlenght));
			}
			signature = signature.PadRight(SignatureMaxlenght);
			return signature;
		}

			public static object RawToObject(object raw, ISurrogateContext context)
		{
			byte[] rawBytes = (byte[])raw;
			lock (_syncSurrogates)
            {
				using (var ms = new MemoryStream(rawBytes))
				{
					using (var reader = new BinaryReader(ms))
					{
						var signature = reader.ReadString();
						SurrogatesInfo info = null;

						if (SignatureToSurrogate.TryGetValue(signature, out info))
						{
								var comparer = "";
								if (info.WriteComparer != null)
									comparer = reader.ReadString();
                                //Read Dependencies count
								int count = reader.ReadInt32();
                                //Iterate restoring dependencies
								for (int i = 0; i < count; i++)
								{
									context.RestoreDependency(reader.ReadString(), comparer, info.IsValidDependency);
								}
								return info.DeSerializeEx(reader, context);
						}
						throw new NotSupportedException();
					}
				}
			}
		}



		public static Func<object, string, object> GetPropertyGetter(object obj)
		{
            lock (_syncSurrogates)
            {
			Debug.Assert(obj != null);
			SurrogatesInfo info = null;
			if (TypeToSurrogate.TryGetValue(obj.GetType(), out info))
			{
				return info.PropertyGetter;
			}
			return null;
		}
		}

		public static Action<object, string, object> GetPropertySetter(object obj)
		{
            lock (_syncSurrogates)
            {
			SurrogatesInfo info = null;
			Debug.Assert(obj != null);
			if (TypeToSurrogate.TryGetValue(obj.GetType(), out info))
			{
				return info.PropertySetter;
			}
			return null;
		}
		}


		public static void RegisterBinding(object ds, string dataSourceProperty, string viewModelUniqueID, string viewModelProperty, bool firstTime = false)
		{
			if (ds == null)
				throw new ArgumentException("The object for which a binding will be register cannot be null");
            lock (_syncSurrogates)
            {
			SurrogatesInfo info = null;
			if (TypeToSurrogate.TryGetValue(ds.GetType(), out info))
			{
				info.RegisterBinding(ds, dataSourceProperty, viewModelUniqueID, viewModelProperty, firstTime);
				return;
			}
			throw new InvalidOperationException(string.Format("There is no surrogate information for objects of type {0}", ds.GetType()));
            }
		}

		public static void ApplyBindingHandlers(object surrogateValue, Action<bool> bindingAction)
		{
			SurrogatesInfo info = null;
            lock (_syncSurrogates)
            {
			if (TypeToSurrogate.TryGetValue(surrogateValue.GetType(), out info))
			{
				Debug.Assert(info.ApplyBindingHandlers != null);
				if (info.ApplyBindingHandlers != null)
					info.ApplyBindingHandlers(surrogateValue, bindingAction);
				return;
			}
		}
		}


		public static bool SupportsBinding(object surrogateValue)
		{
            lock (_syncSurrogates)
            {
			SurrogatesInfo info = null;

			if (TypeToSurrogate.TryGetValue(surrogateValue.GetType(), out info))
			{
				return info.ApplyBindingHandlers != null;
			}
			return false;
            }
		}
	}
}