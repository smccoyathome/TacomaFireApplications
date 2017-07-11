using System;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server
{
  /// <summary>
  /// StateObjectPointerReference is to support Pointers on client ViewModels
  /// </summary>
  public class StateObjectPointerReference : StateObjectPointer { }


  public abstract class StateObjectPointerReferenceSuperValueBase : StateObjectPointerReference
  {
	  public abstract object SuperTarget { get; set; }

  }

  public class StateObjectPointerReferenceSuperValue : StateObjectPointerReferenceSuperValueBase
  {

	  public object myValue;
	  public override object SuperTarget
	  {
		  get
		  {
			  return myValue;
		  }

		  set
		  {
			  myValue = value;
		  }
	  }

	  public override bool IsCompatibleWith(object value)
	  {
		  var valueType = value.GetType();
		  if (valueType.IsValueType || valueType == typeof(string) || valueType == typeof(Type))
			  return true;
		  return false;
	  }
  
  }

    public class StateObjectPointerReferenceSuperStruct : StateObjectPointerReferenceSuperValue
    {
       

        public override bool IsCompatibleWith(object value)
        {
            var valueType = value.GetType();
            if (valueType.IsValueType && TypeCacheUtils.IsAnUserStructType(valueType))
                return true;
            return false;
        }

    }


    public class StateObjectPointerReferenceSerializable : StateObjectPointerReferenceSuperValueBase
  {

	  public object myValue;
	  public override object SuperTarget
	  {
		  get
		  {
			  return myValue;
		  }

		  set
		  {
			  myValue = value;
		  }
	  }

	  public override bool IsCompatibleWith(object value)
	  {
		 	  return true;
	  }

  }

	public class StateObjectPointerReferenceSuperSurrogate : StateObjectPointerReferenceSuperValueBase
	{


	  internal string _targetSurrogateUniqueId;
	  private StateObjectSurrogate _surrogate;


	  public override object SuperTarget
	  {
		  get
		  {

			  if (_surrogate != null)
			  {
					return _surrogate;
				}
			  if (_targetSurrogateUniqueId != null)
			  {
				  _surrogate = (StateObjectSurrogate)StateManager.Current.GetObject(_targetSurrogateUniqueId);
					return _surrogate;
				}
			  else
				{
				  throw new InvalidOperationException("Neither surrogate nor targetSurrogateUniqueId are set");
			  }
		  }
		  set
		  {
			  if (_surrogate == null)
			  {
				  //it might be that it has not been loaded
				  if (_targetSurrogateUniqueId!=null)
					{

					  //Theres is currently an id and it has not been loaded 
					  //but we need to delete the reference
					  _surrogate = (StateObjectSurrogate)StateManager.Current.GetObject(_targetSurrogateUniqueId);
					  StateManager.Current.surrogateManager.RemoveSurrogateReference(_surrogate, this);
				  }
					_surrogate = StateManager.Current.surrogateManager.GetSurrogateFor(value, true);
					StateManager.Current.surrogateManager.AddSurrogateReference(_surrogate, this);
				  _targetSurrogateUniqueId = _surrogate.UniqueID;
			  }
			  else
			  {
				  if (Object.ReferenceEquals(_surrogate.Value, value)) { /*Nothing to do*/}
				  else
				  {
					  //Remove old surrogate reference
                      StateManager.Current.surrogateManager.RemoveSurrogateReference(_surrogate, this);
					  //Get a new one
						_surrogate = StateManager.Current.surrogateManager.GetSurrogateFor(value, true);
						StateManager.Current.surrogateManager.AddSurrogateReference(_surrogate, this);
					  _targetSurrogateUniqueId = _surrogate.UniqueID;
				  }
			  }
		  }
	  }


	  public override bool IsCompatibleWith(object value)
	  {
		  var valueType = value.GetType();
		  if (SurrogatesDirectory.IsSurrogateRegistered(valueType))
			  return true;
		  return false;
	  }
  }
}
