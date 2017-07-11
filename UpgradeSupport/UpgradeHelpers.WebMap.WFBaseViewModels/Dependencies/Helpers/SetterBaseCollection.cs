using System;


namespace UpgradeHelpers.Helpers
{
	public class SetterBaseCollection
    {
        // Summary:
        //     Initializes a new instance of the System.Windows.SetterBaseCollection class.
        public SetterBaseCollection() { throw new NotImplementedException(); }

        // Summary:
        //     Gets a value that indicates whether this object is in a read-only state.
        //
        // Returns:
        //     true if this object is in a read-only state and cannot be changed; otherwise,
        //     false.
        public bool IsSealed { get; set; }

        public virtual void ClearItems() { throw new NotImplementedException(); }
        public virtual void InsertItem(int index, SetterBase item) { throw new NotImplementedException(); }
        public virtual void RemoveItem(int index) { throw new NotImplementedException(); }
        public virtual void SetItem(int index, SetterBase item) { throw new NotImplementedException(); }

        public void Add(object globalAllscriptsTouchWorksCommonSetter)
        {
            throw new NotImplementedException();
        }

       
    }
}
