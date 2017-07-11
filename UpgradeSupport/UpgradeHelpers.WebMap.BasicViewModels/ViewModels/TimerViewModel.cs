namespace UpgradeHelpers.BasicViewModels
{
    using System.ComponentModel;
    using UpgradeHelpers.Interfaces;

    public class TimerViewModel : IDependentViewModel
    {
        public string UniqueID { get; set; }

        public virtual bool Enabled { get; set; }

        public virtual int Interval { get; set; }

        public void Build(IIocContainer ctx)
        {
        }

        public void Start()
        {
            this.Enabled = true;
        }

        public void Stop()
        {
            this.Enabled = false;
        }

        public void Dispose()
        {
            this.Enabled = false;
        }
    }
}
