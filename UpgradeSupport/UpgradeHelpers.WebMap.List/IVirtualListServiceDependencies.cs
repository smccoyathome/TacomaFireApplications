using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.EventAggregator;

namespace UpgradeHelpers.WebMap.List
{


    public interface IVirtualListServiceDependencies
    {
        IReferenceManager ReferenceManager { get; }
        ISurrogateManager SurrogateManager { get; }
        IStateManager StateManager { get; }

        IUniqueIDGenerator UniqueIdGenerator { get; }
        IServerEventAggregator ServerEventAggregator { get; }
        IPageManager Pager { get; }
    }
}