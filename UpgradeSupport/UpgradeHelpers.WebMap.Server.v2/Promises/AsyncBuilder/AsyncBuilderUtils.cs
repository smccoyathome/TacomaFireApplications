using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Helpers;

namespace UpgradeHelpers.WebMap.Server
{
	internal static class AsyncBuilderUtils
	{
		public static readonly Type TYPE_OF_VOID = typeof(void);
		public static readonly Type TYPE_OF_DIALOG_RESULT = typeof(DialogResult);

		internal delegate void OnDiposeBuilder();

		/// <summary>
		/// Sets the FamilyId from the current builder  to the promise.
		/// All of the promises within a method belong to the same family.
		/// </summary>
		/// <param name="builder">The instance of the current AsyncBuilder</param>
		/// <param name="promise">The promise to add to the family</param>
		public static void SetPromiseInfo(this IAsyncBuilder builder, IPromise promise, string familyId, PromiseType promiseType)
		{
			var basePomise = promise as BasePromiseInfo;

			if (basePomise != null)
			{
				basePomise.FamilyId = familyId + UniqueIDGenerator.UniqueIdSeparator + builder.UniqueId;
				basePomise.PromiseType = promiseType;

				if (promiseType == PromiseType.Catch)
				{
					basePomise.State = PromiseState.Skipped; 
				}
				if (promiseType == PromiseType.Finally)
				{
					basePomise.State = PromiseState.Default; 
				}
			}
		}
		/// <summary>
		/// Adds a delegate and its respective promise to the list of promises to be validated.
		/// </summary>
		/// <param name="builder">The instance of the current AsyncBuilder</param>
		/// <param name="del">The original Delgate</param>
		/// <param name="promise">The promise associeted to the Delegate</param>
		/// <param name="promiseType">Indicates the type of promise added. By default is CodeExecution</param>
		public static void AddPromise(this IAsyncBuilder builder, Delegate del, IPromise promise, PromiseType promiseType = PromiseType.CodeExecution)
		{
			var delPromise = new DelegateOrPromise() { Delegate = del };

			delPromise.CreatedPromise = promise;
			builder.Delegates.Add(delPromise);
			builder.SetPromiseInfo(delPromise.CreatedPromise, builder.FamilyId, promiseType);
			builder.HasAppendedPromises = true;
		}
		/// <summary>
		/// Mark the promises as initial state. The promises are always going to be executed unless a there is an explicit return.
		/// </summary>
		/// <param name="builder">The instance of the current AsyncBuilder</param>
		public static void SetPromisesState(this IAsyncBuilder builder)
		{
			//The appended promises are marked as pending
			foreach (var delegateinfo in builder.Delegates)
			{
				var promise = delegateinfo.CreatedPromise as PromiseInfo;
				if (promise != null && promise.State != PromiseState.Skipped)
				{
					promise.State = PromiseState.Default;
				}
			}
		}

		public static void InsertPromisesToParent(this IAsyncBuilder builder)
		{
			if (builder.Parent != null)
			{
				builder.Parent.Delegates.AddRange(builder.Delegates);
			}
		}
		public static void DisposeExceptionManager(this IAsyncBuilder builder)
		{
			if (builder.HasExceptionManager())
			{
				builder.ExceptionManager.Dispose();
			}
		}
		/// <summary>
		/// Verifies if the promises where created in the same scope (same AsyncBuilder).
		/// If any of them has not been created with an AsyncBuilder returns false.
		/// </summary>
		/// <param name="promise">The instance of the current promise</param>
		/// <param name="familyId">The Id of the possible sibling promise</param>
		/// <returns>Boolean value indicating if the promises are in the same scope</returns>
		internal static bool IsFamilyBySubFamily(this BasePromiseInfo promise, string familyId)
		{
			bool result = false;
			if (!String.IsNullOrEmpty(promise.FamilyId))
			{
				result = promise.FamilyId == familyId;
			}
			return result;
		}



        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        internal static string GetFirstFragmentOfFamily(string familyID)
        {
            for (int i = 0; i < familyID.Length; i++)
            {
                if (familyID[i] == UniqueIDGenerator.UniqueIdSeparator)
                {
                    return familyID.Substring(0, i);
                }
            }
            return null;
        }


		/// <summary>
		/// Verifies if the promises where created in the same context (same method).
		/// If any of them has not been created with an AsyncBuilder returns false.
		/// </summary>
		/// <param name="promise">The instance of the current promise</param>
		/// <param name="familyId">The Id of the possible sibling promise</param>
		/// <returns>Boolean value indicating if the promises are related</returns>
		internal static bool IsFamily(this BasePromiseInfo promise, string familyId)
		{
			bool result = false;
			if (!String.IsNullOrEmpty(promise.FamilyId) && !String.IsNullOrEmpty(familyId))
			{
				result = string.Equals(GetFirstFragmentOfFamily(promise.FamilyId),
                                      GetFirstFragmentOfFamily(familyId));
			}
			return result;
		}
		internal static bool IsApplicableException(this BasePromiseInfo promise, Exception exc)
		{
			bool result = false;
			var type = promise.GetArgumentType();

			if (type != null)
			{
				result = type.Equals(exc.GetType());
			}

			return result;
		}
	}
}
