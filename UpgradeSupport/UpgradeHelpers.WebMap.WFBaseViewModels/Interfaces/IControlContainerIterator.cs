namespace UpgradeHelpers.Interfaces
{
	public interface IControlContainerIterator
	{
		System.Collections.Generic.IEnumerable<UpgradeHelpers.Helpers.ControlViewModel> GetControlsIterator(UpgradeHelpers.Interfaces.IStateObject control = null);
	}
}