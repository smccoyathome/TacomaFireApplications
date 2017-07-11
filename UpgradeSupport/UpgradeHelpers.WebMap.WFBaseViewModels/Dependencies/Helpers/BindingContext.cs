using System;
using System.Collections;
using System.ComponentModel;

namespace UpgradeHelpers.Helpers
{
	[DefaultEvent("CollectionChanged")]
    /// <summary>
    /// Compilation stubs
    /// They provide no functionality yet.
    /// </summary>
    /// <maps>System.Windows.Forms.BindingContext</maps>
    public class BindingContext : ICollection, IEnumerable
    {

        /// <summary>
        /// Compilation Stub. No implementation
        /// </summary>
        /// <maps>CopyTo</maps>
        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Compilation Stub. No implementation
        /// </summary>
        /// <maps><get/></maps>
        public int Count
        {
            get { throw new NotSupportedException(); }
        }

        /// <summary>
        /// Compilation Stub. No implementation
        /// </summary>
        /// <maps><get/></maps>

        public bool IsSynchronized
        {
            get { throw new NotSupportedException(); }
        }

        /// <summary>
        /// Compilation Stub. No implementation
        /// </summary>
        /// <maps><get/></maps>
        public object SyncRoot
        {
            get { throw new NotSupportedException(); }
        }

        /// <summary>
        /// Compilation Stub. No implementation
        /// </summary>
        /// <maps>GetEnumerator</maps>
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
