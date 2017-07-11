using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using Fasterflect;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Server.Common;
using UpgradeHelpers.WebMap.Server.Promises;

namespace UpgradeHelpers.WebMap.Server
{
    internal static class PromiseUtils
    {


        internal static Delegate CreateDelegateFromMethodInfo(object target, MethodInfo methodInfo)
        {
            Type delegateType = TypeCacheUtils.GetDelegateTypeBasedOnMethodParameters(methodInfo);
            return Delegate.CreateDelegate(delegateType, target, methodInfo, true);
        }
        private static char[] PIPE_SEPARATOR = new[] { '|' };

        internal static object RetrieveDelegateFromPromise(Type type, IPromise promise)
        {
            return FromContinuationInfo(type, (EventPromiseInfo)promise);
        }

        internal static object FromContinuationInfo(Type type, EventPromiseInfo promise, IStateObject source = null)
        {
            try
            {
                var methodDeclaringType = TypeCacheUtils.GetType(promise.DeclaringType);
                object targetInstance = null;

                Type[] types = Type.EmptyTypes;
                if (promise.MethodArgs != null)
                {
                    var typesNames = promise.MethodArgs.Split(PIPE_SEPARATOR, StringSplitOptions.RemoveEmptyEntries);
                    types = new Type[typesNames.Length];
                    int i = 0;
                    foreach (var typeName in typesNames)
                    {
                        types[i++] = TypeCacheUtils.GetType(typeName);
                    }
                }

				if (promise.isLocalInstance && source != null)
					targetInstance = source;
				else
				{
					var pointer = promise.ObjectContainingMethod as StateObjectPointerReference;
					if (pointer != null)
					{
						targetInstance = pointer.Target;
					}
					else
					{
						targetInstance = promise.ObjectContainingMethod;
					}
				}


                if (targetInstance is StateObjectSurrogate)
                {
                    targetInstance = ((StateObjectSurrogate)targetInstance).Value;
                }
				if (targetInstance == null)
                {
                    //Was this an static method?
                    if (promise.TargetType == null)
                    {
                        //Yes static
                        var staticType = TypeCacheUtils.GetType(promise.DeclaringType);
                        var staticmethod = staticType.GetMethod(promise.MethodName, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                        return Delegate.CreateDelegate(type, staticmethod);
                    }
                    else
                    {
                        //Ok, it was a not an IStateObject object. It might have been
                        //a delegate from another class
                        //So we need to instantiate it and set it to targetInstance
                        var targetType = TypeCacheUtils.GetType(promise.TargetType);
                        targetInstance = Activator.CreateInstance(targetType);
                        if (promise.ContinuationFields != null)
                        {
                            //Pending Restore state
                        }
                    }
                }
                else
                {
                    //First check if method was on this targetInstance. Why not? Because it could have been on a form

                    if (typeof(ILogicView<IViewModel>).IsAssignableFrom(methodDeclaringType))
                    {
                        var instanceWithMethodDeclaredType = TypeCacheUtils.GetType(promise.TargetType);
                        var form = IocContainerImplWithUnity.Current.Resolve(instanceWithMethodDeclaredType, parameters: new object[] { (IViewModel)targetInstance });
                        targetInstance = form;
                    }

                }
                var method = methodDeclaringType.GetMethod(promise.MethodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static, new ReflectionBinderForPromisesResolution(), types, null);
                //If type is delegate then we must build a generic delegate from Action<> or Func<> helpers
                if (typeof(Delegate) == type)
                {
                    Type methodDelegateType = TypeCacheUtils.GetDelegateTypeBasedOnMethodParameters(method);
					return Delegate.CreateDelegate(methodDelegateType, targetInstance, method);

				}
                return Delegate.CreateDelegate(type, targetInstance, method);

            }
            catch (Exception ex)
            {
                TraceUtil.TraceError("ViewManager::PromiseUtils::FromContinuationInfo error while trying to restore delegate from continuation " + ex.Message);
            }
            return null;
        }


        internal static bool IsThisTheThisField(StateManager stateManager,object instance, FieldInfo field, Type codePromiseDeclaringType, object fieldValue, BinaryWriter writer, string prefix, ref IStateObject model)
        {
            if (codePromiseDeclaringType == field.FieldType && field.Name.EndsWith("this", StringComparison.Ordinal))
            {
                var instanceTyped = fieldValue as ILogicWithViewModel<IStateObject>;
                if (instanceTyped != null)
                {
                    //We have the field for the parent class
                    model = instanceTyped.ViewModel;
                    writer.Write(prefix + field.Name);
                    writer.Write(model.UniqueID);
                    return true;
                }
                model = fieldValue as IStateObject; //We assume model is an IDependantModel or an IUserControl
                if (model == null)
                {
                    throw new PromisesOnlySupportDelegatesFromClassesImplementingILogic();
                }
                writer.Write(prefix + field.Name);
                var orphanHolder = stateManager.AdoptionInformation.GetOrphanHolder(instance, model, field.Name);
				if (orphanHolder == null)
					writer.Write(model.UniqueID);
				else
					writer.Write(orphanHolder.UniqueID);
                return true;
			}
            return false;
		}


        internal static bool CheckTheThisField(object instance, FieldInfo field, Type codePromiseDeclaringType, object fieldValue, ref IList<object> dependencies)
        {

            IStateObject model;
            if (codePromiseDeclaringType == field.FieldType && field.Name.EndsWith("this", StringComparison.Ordinal))
            {

                if (fieldValue is ILogicWithViewModel<IStateObject>) return true;
                var instanceTyped = fieldValue as ILogicWithViewModel<IStateObject>;
                if (instanceTyped != null)
                {
                    //We have the field for the parent class
                    
                }
                model = fieldValue as IStateObject; //We assume model is an IDependantModel or an IUserControl
                if (model == null)
                {
                    throw new PromisesOnlySupportDelegatesFromClassesImplementingILogic();
                }
                if (dependencies == null) dependencies = new List<object>();
                dependencies.Add(model);
                return true;
            }
            return false;
        }



        internal static void DeserializeStateForDelegate(BinaryReader reader, Type delegateClassType, object instance, ref string fieldName, string prefix = null)
		{
            var formatter = new BinaryFormatter();
            var fieldList = delegateClassType.Fields(BindingFlags.Public | BindingFlags.Instance);
            foreach (var field in fieldList)
            {
                if (fieldName == null)
                {
                    if (reader.BaseStream.Position == reader.BaseStream.Length)
                    {/*No more data*/return; }
                    fieldName = reader.ReadString();
                    if (prefix != null)
                    {
                        if (fieldName.StartsWith(prefix, StringComparison.Ordinal))
                            fieldName = fieldName.Substring(prefix.Length);
                    }

					TraceUtil.WriteLine(string.Format("Setting value for field {0}", fieldName));
                }
                //Skip until find matching field
                if (!fieldName.Equals(field.Name, StringComparison.Ordinal)) continue;

                if (field.Name.Contains("<>") && field.Name.Contains("locals"))
                {
                    //Is it in locals??
                    //Check if still goes here. 
                    var surrogateUID = reader.ReadString();
                    var localsSurrogate = (StateObjectSurrogate)StateManager.Current.GetObject(surrogateUID);
                    var localsInstance = localsSurrogate.Value;
                    field.SetValue(instance, localsInstance);
					fieldName = null;
                    continue;
                }
                //Is not locals.mmm ok is it an StateObject
                if (typeof(IStateObject).IsAssignableFrom(field.FieldType) ||
                    (field.FieldType.IsGenericType &&
                       (typeof(IList<>).IsAssignableFrom(field.FieldType.GetGenericTypeDefinition()) ||
                        typeof(IDictionary<,>).IsAssignableFrom(field.FieldType.GetGenericTypeDefinition()))
                    ))
                {
                    var uid = reader.ReadString();
                    if (!String.IsNullOrWhiteSpace(uid))
                    {
                        var fieldValue = StateManager.Current.GetObject(uid);
						var surrogate = fieldValue as StateObjectSurrogate;
						if (surrogate != null)
							fieldValue = surrogate.Value as IStateObject;
                        field.SetValue(instance, fieldValue);
                    }
                    fieldName = null;
				}
                else if (typeof(ILogicWithViewModel<IStateObject>).IsAssignableFrom(field.FieldType))
                {
                    fieldName = null;
                    var uid = reader.ReadString();
                    var vm = StateManager.Current.GetObject(uid);
                    if (vm != null)
                    {
                        Type logicType = field.FieldType;
                        if (logicType.IsInterface)
						{
                            var logicAttr = vm.GetType().GetCustomAttribute(typeof(UpgradeHelpers.Helpers.LogicAttribute)) as UpgradeHelpers.Helpers.LogicAttribute;
                            if (logicAttr == null)
                                throw new InvalidOperationException("The logic type for the viewmodel could not be determined. Please decorate the ViewModel class type with the Logic Attribute. for example [Logic(Type = typeof(LogicClass)]");
                            logicType = logicAttr.Type;
						}

                        var form = IocContainerImplWithUnity.Current.Resolve(logicType, null, IIocContainerFlags.NoView | IIocContainerFlags.RecoveredFromStorage) as ILogicView<IViewModel>;
                        form.SetPropertyValue("ViewModel", vm);
                        field.SetValue(instance, form);
                    }
                    else
                        throw new InvalidOperationException(string.Format("The ViewModel for field {0} could not be restored ", field.Name));
                }
                else
                {
                    if (field.FieldType.IsSerializable && typeof(MulticastDelegate).IsAssignableFrom(field.FieldType))
                    {
                        RestoreDelegateField(reader, instance, field);
                    }
                    else if (SurrogatesDirectory.IsSurrogateRegistered(field.FieldType))
					{
						var uid = reader.ReadString();
						if (!String.IsNullOrWhiteSpace(uid))
						{
							StateObjectSurrogate surrogate = StateManager.Current.surrogateManager.GetObject(uid);
							field.SetValue(instance, surrogate.Value);
						}
					}
                    else if (field.FieldType.IsSerializable)
					{
							var fieldValue = formatter.Deserialize(reader.BaseStream);
							field.SetValue(instance, fieldValue);
						
					}
                    fieldName = null;
                }
            }
        }
        private static void RestoreDelegateField(BinaryReader reader, object instance, FieldInfo field)
        {
            //First we retrieve the ID for the target object of delegate
            var targetID = reader.ReadString();
            if (targetID == "NULL")
            {
                //This is an static method
                var declaringTypeName = reader.ReadString();
                var declaringType = TypeCacheUtils.GetType(declaringTypeName);

            }
            else if (targetID == "INST")
			{
                var methodName = reader.ReadString();
                //Is this an Action<> or Func<>
                if (field.FieldType.IsGenericType)
				{
                    Type[] parameterTypes = ExtractParameterTypesForDelegateInField(field);
                    var methodInfo = instance.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null, parameterTypes, null);
                    var delegateValue = CreateDelegateFromMethodInfo(instance, methodInfo);
                    field.SetValue(instance, delegateValue);
				}
			}
			else
			{
                var targetInstance = StateManager.Current.GetObject(targetID);
                if (targetInstance == null) throw new NotSupportedException("Instance for delegate could not be retrieved");
                //This is an IStateObject
                var methodName = reader.ReadString();
                //Is this an Action<> or Func<>
                if (field.FieldType.IsGenericType)
                {
                    Type[] parameterTypes = ExtractParameterTypesForDelegateInField(field);
                    var methodInfo = instance.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null, parameterTypes, null);
                    var delegateValue = CreateDelegateFromMethodInfo(targetInstance, methodInfo);
                    field.SetValue(instance, delegateValue);
                }

			}
		}


        /// <summary>
        ///If field is an Action<> there is no problem
        ///but if field is Func<> then that means that 
        ///for int Foo(bool,string) it would be something
        ///like int,bool,string and to find foo we would need to do GetMethod("Foo",,{ bool,string} );
        /// </summary>
        /// <param name="field">field containing delegate inside a DisplayClass</param>
        /// <returns></returns>
        private static Type[] ExtractParameterTypesForDelegateInField(FieldInfo field)
		{
            var parameterTypes = field.FieldType.GetGenericArguments();
            if (TypeCacheUtils.IsFuncType(field.FieldType))
			{
                var res = new Type[parameterTypes.Length - 1];
                Array.Copy(parameterTypes, 0, res, 0, res.Length);
                parameterTypes = res;
            }
            return parameterTypes;
		}


        internal static void CalculateDependencies(object instance, Type codePromiseType , ref IList<object> dependencies)
        {
            var fieldList = codePromiseType.Fields(BindingFlags.Public | BindingFlags.Instance);
            if (fieldList.Count == 0)
            {
                return;
            }
            if (dependencies == null)
                dependencies  = new List<object>(fieldList.Count);
            var logicObjectType = codePromiseType.DeclaringType;
            foreach (var field in fieldList)
            {
                //TODO skip value type. However some delegates return IsValueType true
#if DEBUG
                Trace.WriteLine(string.Format("Checking promise dependency field {0}", field.Name));
#endif
                var objValue = field.GetValue(instance);
                if (objValue == null) continue; //We do not need to save null fields
                if (CheckTheThisField(instance, field, logicObjectType, objValue, ref dependencies)) continue;
                if (field.Name.Contains("locals"))
                {
                    //Here we know that this is a display class
                    
                    dependencies.Add(objValue);
                    RegisterSurrogateForDisplayClass(field.FieldType, objValue);
                    continue;
                }
                var isISerializable = false;
                //If we have a value we need to serialize
                //We will write the fieldName + Value
                if (objValue is IStateObject)
                {
                    dependencies.Add(objValue);
                }
                else if
                    ((isISerializable = (field.FieldType.IsSerializable || objValue.GetType().IsSerializable)) &&
                    objValue is MulticastDelegate)
                {
                    var delegateObj = ((MulticastDelegate)objValue);
                    if (delegateObj.Target != null && delegateObj.Target != instance)
                    {
                        dependencies.Add(delegateObj);
                    }
                  
                }
                else if (objValue is ILogicWithViewModel<IStateObject>)
                {
                    //var value = (ILogicWithViewModel<IStateObject>)objValue;
                }
                else if (SurrogatesDirectory.IsSurrogateRegistered(field.FieldType))
                {
                    dependencies.Add(objValue);
                }
                else if (field.FieldType.IsSerializable || objValue.GetType().IsSerializable)
                {

                //    if (typeof(MulticastDelegate).IsAssignableFrom(field.FieldType))
                //    {
                //        var delegateObj = ((MulticastDelegate)objValue);
                //        var target = delegateObj.Target;
                //        if (target == null)
                //        {
                //        }
                //        else
                //        {
                //            //Is the target the display class?
                //            if (Object.ReferenceEquals(instance, target))
                //            {
                //            }
                //            else if (target is IStateObject)
                //            {
                //                dependencies.Add(target);
                //            }
                //            else
                //                throw new NotImplementedException("No serialization for this delegates has been implemented yet!");
                //        }
                //    }
                //    else if (field.FieldType.IsClass)
                //    {

                //    }
                }
                //else if (TypeCacheUtils.IsSpecialClass (objValue.GetType()))
                //{
                //    CalculateDependencies(objValue, objValue.GetType(), ref dependencies);
                //}
                else
                {
                    throw new NotSupportedException("Error serializing field " + field.Name + " with type " + field.FieldType.FullName + " inside object of type " + instance.GetType().FullName);
                }
            }
        }


        internal static void SerializeStateForDelegate(StateManager stateManager,object instance, BinaryWriter writer, Type codePromiseType, out Type declaringType, out IStateObject viewModel)
        {
            var fieldList = codePromiseType.Fields(BindingFlags.Public | BindingFlags.Instance);
            if (fieldList.Count == 0)
            {
                declaringType = null;
                viewModel = null;
                return;
			}
            declaringType = codePromiseType;
            viewModel = null;
            var logicObjectType = codePromiseType.DeclaringType;
            SerializeFields(stateManager,instance, ref viewModel, writer, logicObjectType, fieldList);
		}

        private static void SerializeFields(StateManager stateManager,object instance, ref IStateObject viewModel, BinaryWriter writer, Type logicObjectType, IList<FieldInfo> fieldList, string fieldPrefix = "")
		{
            var formatter = new BinaryFormatter();
			foreach (var field in fieldList)
			{
#if DEBUG
				Trace.WriteLine(string.Format("Serializing promise field {0}.{1}", fieldPrefix, field.Name));
#endif
                var objValue = field.GetValue(instance);
                if (objValue == null) continue; //We do not need to save null fields

                ///The delegate can be an instance method. We are looking to determine if there is a reference to the "this instance"
                if (IsThisTheThisField(stateManager,instance, field, logicObjectType, objValue, writer, fieldPrefix, ref viewModel)) continue;
                if (field.Name.Contains("locals"))
                {
					var parentSurrogate = stateManager.surrogateManager.GetSurrogateFor(instance, generateIfNotFound: false);
                    if (parentSurrogate == null) throw new InvalidOperationException("A parent surrogate is needed");
					var localsSurrogate = stateManager.surrogateManager.GetSurrogateFor(objValue, generateIfNotFound: false);
                    if (localsSurrogate == null) //There was not a previous surrogate!! Ok we need a lastminute one
                    {
                        throw new Exception("Invalid condition. Surrogate dependency should have been reported previously");
                        //RegisterSurrogateForDisplayClass(field.FieldType, objValue,parentSurrogate.UniqueID);

                        //localsSurrogate = stateManager.surrogateManager.GetSurrogateFor(objValue, generateIfNotFound: true, parentSurrogate: parentSurrogate.UniqueID);
                        //stateManager.surrogateManager.AddSurrogateReference(localsSurrogate, parentSurrogate.UniqueID);
                    }
                    writer.Write(field.Name);
                    writer.Write(localsSurrogate.UniqueID);
                    continue;
                }
                //If we have a value we need to serialize
                //We will write the fieldName + Value
                bool isSerializable = false;
                if (objValue is IStateObject || IsInterfaceThatMightBeAnStateObject(objValue))
                {
                    //For IStateObject only the UniqueID is needed for the other we would use the ISerialize
                    var value = (IStateObject)objValue;
                    //If this field is not the this then we are goint to save its value
                    writer.Write(fieldPrefix + field.Name);
					var orphanHolder = stateManager.AdoptionInformation.GetOrphanHolder(instance, value, field.Name);
					if (orphanHolder == null)
						writer.Write(value.UniqueID);
					else
						writer.Write(orphanHolder.UniqueID);
                }
                else if (objValue is ILogicWithViewModel<IStateObject>)
                {
                    var value = (ILogicWithViewModel<IStateObject>)objValue;
                    Debug.Assert(value.ViewModel != null);
                    writer.Write(fieldPrefix + field.Name);
                    writer.Write(value.ViewModel.UniqueID);
                }
                else if ((isSerializable=( field.FieldType.IsSerializable || objValue.GetType().IsSerializable)) && objValue is MulticastDelegate)
                {
                    SerializeDelegate(stateManager, instance, writer, fieldPrefix, field, objValue);
                }
                else if (SurrogatesDirectory.IsSurrogateRegistered(field.FieldType))
                {
                    var surrogate = stateManager.surrogateManager.GetSurrogateFor(objValue, generateIfNotFound: true);
                    if (surrogate == null)
                    {
                        // Something is wrong here, throw an exception
                        throw new InvalidOperationException("Error getting the surrogate for field " + field.Name + " with type " + field.FieldType.FullName + " inside object of type " + instance.GetType().FullName);
                    }
                    var parentSurrogate = stateManager.surrogateManager.GetSurrogateFor(instance, generateIfNotFound: false);
                    stateManager.surrogateManager.AddSurrogateReference(surrogate, parentSurrogate);
                    writer.Write(field.Name);
                    writer.Write(surrogate.UniqueID);
                }
                else if (isSerializable)
				{
                    writer.Write(fieldPrefix + field.Name);
                    formatter.Serialize(writer.BaseStream, objValue);
				}
				else
				{
					throw new NotSupportedException("Error serializing field " + field.Name + " with type " + field.FieldType.FullName + " inside object of type " + instance.GetType().FullName);
				}
			}
		}

        private static void SerializeDelegate(StateManager stateManager, object instance, BinaryWriter writer, string fieldPrefix, FieldInfo field, object objValue)
        {
            writer.Write(fieldPrefix + field.Name);
            var delegateObj = ((MulticastDelegate)objValue);
            var target = delegateObj.Target;
            if (target == null)
            {
                writer.Write("NULL");
                writer.Write(delegateObj.Method.DeclaringType.AssemblyQualifiedNameCache());
            }
            else
            {
                //Is the target the display class?
                if (Object.ReferenceEquals(instance, target))
                {
                    writer.Write("INST");
                }
                else if (target is IStateObject)
                {
                    var orphanHolder = stateManager.AdoptionInformation.GetOrphanHolder(instance, ((IStateObject)target), field.Name);
                    if (orphanHolder == null)
                        writer.Write(((IStateObject)target).UniqueID);
                    else
                        writer.Write(orphanHolder.UniqueID);

                }
                else
                    throw new NotImplementedException("No serialization for this delegates has been implemented yet!");
            }
            writer.Write(delegateObj.Method.Name);
        }

        private static bool IsInterfaceThatMightBeAnStateObject(object value)
        {
            var type = value.GetType();
            if (!type.IsArray /*If the type is an array it means that it cannot be an state object */ && type.IsGenericType && type.IsInterface)
            {
                var genericType = type.GetGenericTypeDefinition();
                return typeof(IList<>).IsAssignableFrom(genericType) || typeof(IDictionary<,>).IsAssignableFrom(genericType);
            }
            return false;
        }
        /// <summary>
        /// Method to register a surrogate in order to save the State of the method being executed.
        /// </summary>
        /// <param name="codePromiseType"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        internal static void RegisterSurrogateForDisplayClass(Type codePromiseType, object target,string parentSurrogateId = null)
        {
            //Lets register the surrogate only if it's not already registered.
            if (!SurrogatesDirectory.IsSurrogateRegistered(codePromiseType))
            {
                var signature = SurrogatesDirectory.GenerateNewSurrogateFromType(codePromiseType);
                var surrogateForDisplayClass = new SurrogateForDisplayClass(codePromiseType, signature);
                SurrogatesDirectory.RegisterSurrogate(
                    signature: signature,
                    supportedType: codePromiseType,
                    serializeEx: surrogateForDisplayClass.Serialize,
                    deserializeEx: surrogateForDisplayClass.Deserialize,
                    calculateDependencies: new SurrogateDependencyCalculation[] { surrogateForDisplayClass.CalculateDependencies });
            }
			
        }
    }
}