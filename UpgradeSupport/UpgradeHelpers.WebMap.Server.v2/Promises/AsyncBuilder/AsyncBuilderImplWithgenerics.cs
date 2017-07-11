using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.WebMap.Helpers;
using System.Reflection;

namespace UpgradeHelpers.WebMap.Server
{
	internal class AsyncBuilderImpl<T> : AsyncBuilderImplBase<T>
	{

		protected override void ValidateDelegates()
		{
			ValidateLastPromise();

			Type lastReturnType = AsyncBuilderUtils.TYPE_OF_VOID;
			for (int i = 0; i < Delegates.Count; i++)
			{
				var del = Delegates[i].Delegate;
				if (del != null)
				{
					var methodInfo = del.GetMethodInfo();
					var parameters = methodInfo.GetParameters();
					Type currentReturnType = methodInfo.ReturnType;

					if (parameters.Length == 0)
					{
						//Has no arguments and no return
						if (currentReturnType == AsyncBuilderUtils.TYPE_OF_VOID)
						{
							lastReturnType = currentReturnType;
							continue;
						}

						//Has no arguments an a return
					}
					else
					{
						Type currentArgumentType = parameters[0].ParameterType;

						//Has arguments and no return
						if (currentReturnType == AsyncBuilderUtils.TYPE_OF_VOID && currentArgumentType == AsyncBuilderUtils.TYPE_OF_DIALOG_RESULT)
						{
							lastReturnType = currentReturnType;
							//There is no problem if previous was Promise or better promise DialogResult or DialogResult
							continue;
						}

						//Has return and arguments
						if (lastReturnType != AsyncBuilderUtils.TYPE_OF_VOID && !currentArgumentType.IsAssignableFrom(lastReturnType))
						{
							throw new InvalidOperationException("Invalid promises chain. The current promise must return the same type as the return of its previous one");
						}
					}
					lastReturnType = currentReturnType;
				}
			}
		}

		public override Promise GetPromise()
		{
			throw new NotImplementedException();
		}
		/// <summary>
		/// Validates that return type of the last promise is consistent with <T>.
		/// </summary>
		private void ValidateLastPromise()
		{
			var last = Delegates.LastOrDefault();

			//The last Promise must have the same return type as the Async Builder
			if (last != null)
			{
				if (last.Promise != null && !(last.Promise is T))
				{
					throw new InvalidOperationException("Invalid promises chain. This async block must end with lambda that returns " + typeof(T).FullName);
				}
				if (last.Delegate != null && !typeof(T).IsAssignableFrom(last.Delegate.GetMethodInfo().ReturnType))
				{
					throw new InvalidOperationException("Invalid promises chain. This async block must end with lambda that returns " +
														typeof(T).FullName);
				}
			}
		}

	}

}
