using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace UpgradeHelpers.Helpers
{


    /// <summary>
    /// Marks the ViewModel class with the associated logic type
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class LogicAttribute : Attribute
	{
        public Type Type { get; set; }
    }


    public enum StateConverterKind {
		Client,
		Server,
		Both
	}

	/// <summary>
	/// Marks a class as a JsonConverter that can be used when trying to populate existing objects from
	/// the JSON deltas from the client side.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class AppStateJsonConverter : Attribute
	{
		public StateConverterKind ConverterKind { get; set; }

        public bool SupportsDelta { get; set; }

        public Type Model { get; set; }
		public AppStateJsonConverter(StateConverterKind converterKind)
		{
			ConverterKind = converterKind;
		}
	}

	/// <summary>
	/// Used to mark object as a singlenton
	/// The singleton pattern is a design pattern that restricts the instantiation of a class to one object. 
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class Singleton : Attribute
	{
	}


	/// <summary>
	/// Kind of "state management types"
	/// StateManagementValues.Undefined  the element will not be persisted during request-response cycles and it will NOT be sent to client
	/// StateManagementValues.ClientOnly the element will not be persisted on the session but at the end of the request this value will be sent to the client
	/// StateManagementValues.ServerOnly the element will be persisted on the session but at the end of the request it will not be send to the client
	/// StateManagementValues.Both the element will persist its state during request-response cycles and it will be sent to client
	/// </summary>
	public enum StateManagementValues : byte
    {
		None,
		ClientOnly,
		ServerOnly,
		Both
	}
    /// <summary>
    /// Kind of References
    /// StateManagementValues.Weak The element is a Reference to a different IStateObjet.
    /// StateManagementValues.Strong The element is a Reference to a different IStateObjet and it Kepps track of the references to that object.
    /// </summary>
	public enum ReferenceTypeValues
	{
		Weak,
		Strong
	}

	/// <summary>
	/// This attribute is used to mark an property for "state management"
	/// that is the behaviour that will be taken when the object is persisted.
	/// The posible values are:
	/// * [StateManagement(true)] the element will persist its state during request-response cycles and it will be sent to client
	/// * [StateManagement(false)] the element will not be persisted during request-response cycles and it will NOT be sent to client
	/// * [StateManagement(StateManagementValues.Undefined)] same as [StateManagement(false)]
	/// * [StateManagement(StateManagementValues.ClientOnly)] the element will not be persisted on the session but at the end of the request this value will be sent to the client
	/// * [StateManagement(StateManagementValues.ServerOnly)] the element will be persisted on the session but at the end of the request it will not be send to the client
	/// * [StateManagement(StateManagementValues.Both)] same as [StateManagement(true)]
	/// </summary>
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class StateManagement : Attribute
	{
		public readonly StateManagementValues Value;

		[Obsolete("Use StateManagementValues enumerations instead")]
		public StateManagement(bool include)
		{
			if (include)
				Value = StateManagementValues.Both;
			else
				Value = StateManagementValues.None;
		}


		public StateManagement(StateManagementValues value = StateManagementValues.Both, string Why = null)
		{
			Value = value;
		}

		public bool RequiresStateManagement()
		{
			return (Value == StateManagementValues.Both) || (Value == StateManagementValues.ClientOnly)
				   || (Value == StateManagementValues.ServerOnly);

		}

		/// <summary>
		/// Indicates whether this property must be sent to the client or not
		/// </summary>
		/// <returns></returns>
		public bool RequiresStateManagementClient()
		{
			return (Value == StateManagementValues.Both) || (Value == StateManagementValues.ClientOnly);
		}
	}

    /// <summary>
    ///     This is used to assign an Alias to a Property in the UniqueID building process. Mainly used to reduce the 
    /// length of the UniqueIDs.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class StateManagementAlias : Attribute
    {
        public readonly string Value;
        public StateManagementAlias(string Alias)
        {
            Value = Alias;
        }
    }

    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class)]
    public class StateManagementDefaultValue : Attribute
    {
        public readonly StateManagementValues Value;

        public StateManagementDefaultValue(StateManagementValues value = StateManagementValues.Both, string Why = null)
        {
            Value = value;
        }

        public bool RequiresStateManagement()
        {
            return (Value == StateManagementValues.Both) || (Value == StateManagementValues.ClientOnly)
                   || (Value == StateManagementValues.ServerOnly);

        }

        /// <summary>
        /// Indicates whether this property must be sent to the client or not
        /// </summary>
        /// <returns></returns>
        public bool RequiresStateManagementClient()
        {
            return (Value == StateManagementValues.Both) || (Value == StateManagementValues.ClientOnly);
        }
    }

    /// <summary>
    /// This attribute is used to mark a property ViewModel as a Reference
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
	public class Reference : Attribute
	{
		public readonly ReferenceTypeValues Value;

		public Reference(ReferenceTypeValues value = ReferenceTypeValues.Strong)
		{
			Value = value;
		}
	}

	[AttributeUsage(AttributeTargets.Property)]
	public class GenericCollectionTypeInfo : System.Attribute
	{
		public Type RuntimeType;
	}

    

	public static class StateManagementUtils
	{
		public static bool MustIgnoreMember(bool forClient, MemberInfo member, bool ignoreReferences = true)
		{
			//If the property is marked as a reference we must not process is during serialization
			var isAReferenceAtt = member.GetCustomAttributes(typeof(Reference), false);
			if (isAReferenceAtt.Length > 0 && ignoreReferences) return true;

			var atts = member.GetCustomAttributes(typeof(StateManagement), false);
			if (atts.Length <= 0) return false;

			var att = ((StateManagement)atts[0]);
			var value = att.Value;
			return forClient
					? value == StateManagementValues.None || value == StateManagementValues.ServerOnly
					: value == StateManagementValues.None || value == StateManagementValues.ClientOnly;
		}

		public static bool MustIgnoreMember(MemberInfo member)
		{
			var atts = member.GetCustomAttributes(typeof(StateManagement), false);
			return atts.Length > 0 && ((StateManagement)atts[0]).Value == StateManagementValues.None;
		}
	}
}
