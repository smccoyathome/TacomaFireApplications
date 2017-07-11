

namespace UpgradeHelpers.WebMap.Server
{
	internal class UnblockedPromiseInfo<T> : PromiseInfo<T>
	{
		public UnblockedPromiseInfo(T value)
		{
			State = PromiseState.Unblocked;
			ResolvedValue = value;
		}

		public override void Resolve(params object[] parameters)
		{
			State = PromiseState.Resolved;
			//Nothing to do
		}
	}
}
