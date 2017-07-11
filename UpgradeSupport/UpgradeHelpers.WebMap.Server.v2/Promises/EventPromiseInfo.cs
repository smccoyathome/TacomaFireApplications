using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Server.Common;

namespace UpgradeHelpers.WebMap.Server
{
    internal class EventPromiseInfoForClient : EventPromiseInfo, IDependentViewModel
    {
        public static EventPromiseInfoForClient CreateEventInstance(StateManager stateManager,Delegate code, IStateObject parent = null, string promiseUniqueId = null, PromiseState state = PromiseState.Resolved, bool saveInStorage = false, string actionID  = "")
        {
            var instance = new EventPromiseInfoForClient { UniqueID = stateManager.UniqueIDGenerator.GetPromiseUniqueID(), State = state };
            BuildContinuationInfo(stateManager,instance, code, parent, promiseUniqueId,  actionID: actionID);
            return instance;
        }
        public void Build(IIocContainer ctx) {}
    }

	public class EventPromiseInfoConverter : JsonConverter
	{

		public override bool CanConvert(Type objectType)
		{
			return typeof(EventPromiseInfo).IsAssignableFrom(objectType);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			EventPromiseInfo target = null;
			if (reader.TokenType == JsonToken.Null)
				return null;
			target = existingValue as EventPromiseInfo;
			if (reader.TokenType == JsonToken.StartArray)
			{
				target.StateObjectUniqueId = reader.ReadAsString();

				string datastring = reader.ReadAsString();
                int baseLen = TypeCacheUtils.PADDEDCONTRACTEDTYPENAME;
				int idx = 0;
				target.DeclaringType = datastring.Substring(idx, baseLen); idx += baseLen;
				target.DelegateType = datastring.Substring(idx, baseLen); idx += baseLen;
				target.TargetType = datastring.Substring(idx, baseLen); idx += baseLen;
				if (target.TargetType == IntegerExtensions.getNullByBase(baseLen))
				{
					target.TargetType = null;
				}

				string args = datastring.Substring(idx, datastring.Length - idx);
				StringBuilder builder = new StringBuilder();
				if (args.Length > 0)
				{
					int posidx = 0;
					//add token separator(added in BuildContinuationInfo), continue use in original code
					do
					{
						builder.Append(args.Substring(posidx, baseLen));
						builder.Append("|");
						posidx += baseLen;
					} while (posidx < args.Length);
				}
				target.MethodArgs = builder.ToString();

				target.MethodName = reader.ReadAsString();
				target.State  = (PromiseState)reader.ReadAsInt32().Value;
				target.ParentId = reader.ReadAsString();
				target.ActionID = reader.ReadAsString();
			}
			return target;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var obj = value as EventPromiseInfo;
			writer.WriteStartArray();
			writer.WriteValue(obj.StateObjectUniqueId);
			string strTargetType = obj.TargetType;
			if (obj.TargetType == null ){
                strTargetType = IntegerExtensions.getNullByBase(TypeCacheUtils.PADDEDCONTRACTEDTYPENAME);
			}

			string args = "";
			if (obj.MethodArgs != null){
				//remove token separator(added in BuildContinuationInfo)
				args = obj.MethodArgs.Replace("|","");
			}

			writer.WriteValue(obj.DeclaringType + obj.DelegateType + strTargetType + args);

			writer.WriteValue(obj.MethodName);
			writer.WriteValue(obj.State);
			writer.WriteValue(obj.ParentId);
			writer.WriteValue(obj.ActionID);
			writer.WriteEndArray();
		}
	}
	[JsonConverter(typeof(EventPromiseInfoConverter))]
    internal class EventPromiseInfo : BasePromiseInfo
    {
        public string ActionID { get; set; }

        public static object GetObjectContainingMethod(IPromise promise)
        {
            return ((BasePromiseInfo)promise).ObjectContainingMethod;
        }
        public static IPromise CreateEventInstancePromise(IStateManager stateManager, Delegate code)
        {
            return CreateEventInstance((StateManager)stateManager, code);
        }

        /// <summary>
        /// Creates a PromiseInfo related to Events to be subscribed
        /// </summary>
        public static EventPromiseInfo CreateEventInstance(StateManager stateManager,Delegate code, IStateObject parent = null, string promiseUniqueId = null, PromiseState state = PromiseState.Resolved, string actionID = "")
        {
            var instance = new EventPromiseInfo { State = state };
			BuildContinuationInfo(stateManager,instance, code, parent, promiseUniqueId, actionID :actionID);
            return instance;
        }
        public bool isLocalInstance { get; set; }
		internal static EventPromiseInfo BuildContinuationInfo(StateManager stateManager,EventPromiseInfo promise, Delegate code, IStateObject parent = null, string promiseUniqueId = null, string actionID = "")
        {


            var instance = code.Target;
            Type codePromiseType = instance != null ? instance.GetType() : null;

            string internalFieldsState = null;

            //This variable holds the reference
            //to the IStateObject that is closest to the promise.
            //For example if we are referring to a method on a Form. The closest state object is a
            //ViewModel. If the object is a DisplayClass, then we try to determine
            //which was the closest IModel or IUserControl where this DisplayClass was used
            IStateObject objectContainingMethod = null;

            if (codePromiseType != null)
            {
                //For special classes it's required to register a surrogate to save the application state.
                if (TypeCacheUtils.IsSpecialClass(codePromiseType))
                {
                    PromiseUtils.RegisterSurrogateForDisplayClass(codePromiseType, code.Target);
                    objectContainingMethod = stateManager.surrogateManager.GetSurrogateFor(code.Target, generateIfNotFound: true);
                }
                else
                {
                    var stateObject = instance as IStateObject;
                    if (stateObject != null)
                        objectContainingMethod = stateObject;
                    else
                    {
                        var logicView = instance as ILogicView<IViewModel>;
                        if (logicView != null)
                        {
                            objectContainingMethod = logicView.ViewModel;
                        }
                    }
                }
            }

            string methodArgs = null;
            var parameters = code.Method.GetParameters();

            if (parameters.Length > 0)
            {
                StringBuilder builder = new StringBuilder();
                foreach (var parameter in parameters)
                {
                    builder.Append(parameter.ParameterType.AssemblyQualifiedNameCache());
                    builder.Append("|");
                }
                methodArgs = builder.ToString();
            }

            promise.DeclaringType = code.Method.DeclaringType.AssemblyQualifiedNameCache();
            //promise.SetObjectContainingMethod(objectContainingMethod);
            promise.TargetType = code.Target != null ? code.Target.GetType().AssemblyQualifiedNameCache() : null;
            promise.MethodName = code.Method.Name;
            promise.ActionID = actionID;
            promise.ParentId = parent != null ? parent.UniqueID : 
            promise.ModalUniqueId = null;
            promise.MethodArgs = methodArgs;
            promise.UniqueID = promiseUniqueId ??
                               (parent == null
                                   ? stateManager.UniqueIDGenerator.GetPromiseUniqueID()
                                   : stateManager.UniqueIDGenerator.GetRelativeUniqueID(parent));
            promise.ContinuationFields = internalFieldsState;
            promise.DelegateType =
                TypeCacheUtils.GetDelegateTypeBasedOnMethodParameters(code.Method).AssemblyQualifiedNameCache();

			stateManager.AddNewObject(promise);

			if (objectContainingMethod != null)
			{
				if (!StateManager.AllBranchesAttached(objectContainingMethod))
                    stateManager.AdoptionInformation.RegisterPossibleOrphan(promise, objectContainingMethod);

				var referenceToObjectContainingMethod = new StateObjectPointerReference();
				var relativeUid = UniqueIDGenerator.GetPointerRelativeUniqueID(promise, "PO");
				LazyBehaviours.AddDependent(promise, UniqueIDGenerator.REFERENCEPrefix + "PO");
				StateObjectPointer.AssignUniqueIdToPointer(promise, relativeUid, referenceToObjectContainingMethod);
				referenceToObjectContainingMethod.Target = objectContainingMethod;
				stateManager.isServerSideOnly.Add(referenceToObjectContainingMethod);
				stateManager.AddNewObject(referenceToObjectContainingMethod);
				stateManager.ReferencesManager.AddReference(referenceToObjectContainingMethod, objectContainingMethod);
				var surrogate = objectContainingMethod as StateObjectSurrogate;
				if (surrogate != null)
					stateManager.surrogateManager.AddSurrogateReference(surrogate, referenceToObjectContainingMethod);

				promise.SetObjectContainingMethod(referenceToObjectContainingMethod);
			}
            if (parent != null && objectContainingMethod != null && parent.Equals(objectContainingMethod))
            {
                promise.isLocalInstance = true;
            }
            else 
				if (promiseUniqueId != null && objectContainingMethod != null)
				{
                   var parentUniqueID = StateManager.GetLastPartOfUniqueID(promise);
                   promise.isLocalInstance =  string.Equals(parentUniqueID,objectContainingMethod.UniqueID);
            }

            return promise;
        }

        public override void Resolve(params object[] parameters)
        {
            try
            {
                Execute(parameters);
                SetState();
            }
            catch (Exception)
            {
                State = PromiseState.Rejected;
            }
        }
    }
}
