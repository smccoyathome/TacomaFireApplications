using System;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server.Promises
{
	public enum LoopState
	{
		Condition,
		WaitingCondition,
		Body,
		PreBody,
		PostBody
	}

	internal class LoopPromiseInfo : BasePromiseInfo
	{
		#region Property Condition
		PromiseInfo<bool> _condition;

		[Newtonsoft.Json.JsonIgnore]
		public virtual PromiseInfo<bool> Condition
		{
			get
			{
				return GetRelativePropertyValue(_condition, "Condition");
			}
			protected set
			{
				SetRelativePropertyValue(value, ref _condition, "Condition");
			}
		}
		#endregion

		#region Property Body

		PromiseInfo _body;

		[Newtonsoft.Json.JsonIgnore]
		public virtual PromiseInfo Body
		{
			get
			{
				return GetRelativePropertyValue(_body, "Body");
			}
			protected set
			{
				SetRelativePropertyValue(value, ref _body, "Body");
			}
		}

		#endregion

		#region Property PostBody

		PromiseInfo _postBody;

		[Newtonsoft.Json.JsonIgnore]
		public virtual PromiseInfo PostBody
		{
			get
			{
				return GetRelativePropertyValue(_postBody, "PostBody");
			}
			protected set
			{
				SetRelativePropertyValue(value, ref _postBody, "PostBody");
			}
		}

		#endregion
		public virtual LoopState LoopState { get; set; }

		internal static LoopPromiseInfo CreateInstance(Func<bool> delCondition, Action delBody, Action delPostBody, object target = null,
			string modalUniqueId = null, PromiseState state = PromiseState.Unblocked, int insertionIndex = -1)
		{
			var instance = new LoopPromiseInfo
			{
				UniqueID = StateManager.Current.UniqueIDGenerator.GetPromiseUniqueID(),
				Condition = PromiseInfo<bool>.CreateInstance(delCondition, target, modalUniqueId, false, PromiseState.Unblocked, insertionIndex),
				Body = PromiseInfo.CreateInstance(delBody, target, modalUniqueId, false, PromiseState.Unblocked, insertionIndex),
				State = PromiseState.Pinned,
				LoopState = LoopState.Condition,
				PostBody = (delPostBody != null) ? PromiseInfo.CreateInstance(delPostBody, target, modalUniqueId, false, PromiseState.Unblocked, insertionIndex) : null
			};

            instance.NeedsSerialization = (instance.Body.NeedsSerialization || (instance.PostBody != null ? instance.PostBody.NeedsSerialization: false) || instance.Condition.NeedsSerialization);
			ViewManager.Instance.State.RegisterPromise(instance, insertionIndex);
			return instance;
		}

        public override void PreProcess(SurrogateManager surrogateManager) {
            Condition.PreProcess(surrogateManager);
            Body.PreProcess(surrogateManager);
            if(PostBody != null)
                PostBody.PreProcess(surrogateManager);
        }

		public override void Resolve(params object[] parameters)
		{
			try
			{
				object resolvedValue = null;
				bool exit = false;
				switch (LoopState)
				{
					case LoopState.Condition:
						Condition.Resolve();
						if (Condition.TryGetResolvedValue(out resolvedValue))
						{
							exit = !Convert.ToBoolean(resolvedValue);
							if (exit)
							{
								State = PromiseState.Unpinned;
							}
							else
							{
								LoopState = LoopState.Body;
							}
						}
						else
						{
							LoopState = LoopState.WaitingCondition;
						}
						break;

					case LoopState.WaitingCondition:
						if (parameters.Length > 0)
						{
							exit = !Convert.ToBoolean(parameters[0]);
							if (exit)
							{
								State = PromiseState.Unpinned;
								return;
							}
							else
							{
								LoopState = LoopState.Body;
							}
						}
						else
						{
							throw new Exception("The condition is not being returned as expected in loop promise");
						}
						break;

					case LoopState.Body:
						Body.Resolve();
						LoopState = LoopState.PostBody;
						break;

					case LoopState.PostBody:
						if (PostBody != null)
						{
							PostBody.Resolve();
						}
						LoopState = LoopState.Condition;
						break;
				}
			}
			catch (Exception)
			{
				State = PromiseState.Rejected;
			}
		}

		internal void SetRelativePropertyValue<T>(T value, ref T backingField, string propertyName) where T : IStateObject
		{
			backingField = value;
			if (value != null)
			{
				backingField.UniqueID = UniqueIDGenerator.GetRelativeUniqueID(this, propertyName);
				StateManager.Current.AddNewObject(backingField);
			}
		}

		internal T GetRelativePropertyValue<T>(T backingField, string propertyName) where T : IStateObject
		{
			if (backingField == null)
			{
				var relativeUid = UniqueIDGenerator.GetRelativeUniqueID(this, propertyName);
				backingField = (T)StateManager.Current.GetObject(relativeUid);
			}
			return backingField;
		}

		protected override IPromise CreatePromise(Delegate code, int insertionIndex = -1)
		{
			var result = PromiseInfo.CreateInstance(code, state: PromiseState.Unblocked , insertionIndex: insertionIndex);
			ThenUniqueID = result.UniqueID;
			return result;
		}

		protected override IPromise<TR> CreatePromise<TR>(Delegate code, int insertionIndex = -1)
		{
			var result = PromiseInfo<TR>.CreateInstance(code, state: PromiseState.Unblocked, insertionIndex: insertionIndex);
			ThenUniqueID = result.UniqueID;
			return result;
		}

	}

	internal class LoopPromiseInfo<TElement> : LoopPromiseInfo
	{

		#region Property Collection
		IPromiseCollectionInfo<TElement> _collection;

		[Newtonsoft.Json.JsonIgnore]
		public virtual IPromiseCollectionInfo<TElement> Collection
		{
			get
			{
				return GetRelativePropertyValue(_collection, "Collection");
			}
			protected set
			{
				SetRelativePropertyValue(value, ref _collection, "Collection");
			}
		}
		#endregion

		#region Property PreBody
		PromiseInfo<TElement> _preBody;

		[Newtonsoft.Json.JsonIgnore]
		public virtual PromiseInfo<TElement> PreBody
		{
			get
			{
				return GetRelativePropertyValue(_preBody, "PreBody");
			}
			protected set
			{
				SetRelativePropertyValue(value, ref _preBody, "PreBody");
			}
		}
		#endregion

		public static LoopPromiseInfo<T> CreateInstance<T>(IPromiseCollectionInfo<T> collection, Action<T> delBody,
			object target = null, string modalUniqueId = null, int insertionIndex = -1)
		{
			var instance = new LoopPromiseInfo<T>
			{
				UniqueID = StateManager.Current.UniqueIDGenerator.GetPromiseUniqueID(),
				Collection = collection,
				State = PromiseState.Pinned,
				LoopState = LoopState.Condition,
				Condition = PromiseInfo<bool>.CreateInstance((Func<bool>)collection.LoopCondition, collection, modalUniqueId, false, PromiseState.Unblocked, insertionIndex),
				Body = PromiseInfo.CreateInstance(delBody, target, modalUniqueId, false, PromiseState.Unblocked, insertionIndex),
				PostBody = PromiseInfo.CreateInstance((Action)collection.Next, collection, modalUniqueId, false, PromiseState.Unblocked, insertionIndex),
				PreBody = PromiseInfo<T>.CreateInstance((Func<T>)collection.Item, collection, modalUniqueId, false, PromiseState.Unblocked, insertionIndex)
			};

            instance.NeedsSerialization = (instance.Body.NeedsSerialization || (instance.PostBody != null ? instance.PostBody.NeedsSerialization : false) || instance.Condition.NeedsSerialization || instance.PreBody.NeedsSerialization);

			ViewManager.Instance.State.RegisterPromise(instance, insertionIndex);
			return instance;
		}

        public override void PreProcess(SurrogateManager surrogateManager)
        {
            base.PreProcess(surrogateManager);
            PreBody.PreProcess(surrogateManager);
        }

		public override void Resolve(params object[] parameters)
		{
			try
			{
				object resolvedValue = null;
				bool exit = false;
				switch (LoopState)
				{
					case LoopState.Condition:
						Condition.Resolve();
						if (Condition.TryGetResolvedValue(out resolvedValue))
						{
							exit = !Convert.ToBoolean(resolvedValue);
							if (exit)
							{
								State = PromiseState.Unpinned;
							}
							else
							{
								LoopState = LoopState.PreBody;
							}
						}
						else
						{
							LoopState = LoopState.WaitingCondition;
						}
						break;

					case LoopState.WaitingCondition:
						if (parameters.Length > 0)
						{
							exit = !Convert.ToBoolean(parameters[0]);
							if (exit)
							{
								State = PromiseState.Unpinned;
								return;
							}
							else
							{
								LoopState = LoopState.PreBody;
							}
						}
						else
						{
							throw new Exception("The condition is not being returned as expected in loop promise");
						}
						break;

					case LoopState.PreBody:
						PreBody.Resolve();
						if (PreBody.TryGetResolvedValue(out resolvedValue))
						{
							var elementValue = (TElement)resolvedValue;
							Body.Resolve(elementValue);
							LoopState = LoopState.PostBody;
						}
						else
						{
							throw new Exception("Could not get the item element in loop promise");
						}
						break;

					case LoopState.PostBody:
						if (PostBody != null)
						{
							PostBody.Resolve();
						}
						LoopState = LoopState.Condition;
						break;
				}
			}
			catch (Exception)
			{
				State = PromiseState.Rejected;
			}
		}
	}
}
