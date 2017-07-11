using System;
using System.Collections.Generic;

namespace UpgradeHelpers.WebMap.Server
{
    /// <summary>
    /// A lot of the BCL collections like Dictionar<> and HashSet<>
    /// rely on the Equals and GetHashCode methods.
    /// 
    /// In WebMap internal collections we mostly are just comparing references, but we have found
    /// that some users override the Equals or GetHashCode methods. So this comparer is meant to avoid using those comparers
    /// For out internal tests
    /// </summary>

    public class ComparerByReference : EqualityComparer<object>
    {
        private ComparerByReference() { }

        public static ComparerByReference CommonInstance = new ComparerByReference();

        public override bool Equals(object b1, object b2)
        {
            return Object.ReferenceEquals(b1, b2);

        }

        public override int GetHashCode(object bx)
        {
            return System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(bx);
        }
    }

	public class ComparerByReferenceGeneric<T> : EqualityComparer<T>
	{
		private ComparerByReferenceGeneric() { }

		public static ComparerByReferenceGeneric<T> CommonInstance = new ComparerByReferenceGeneric<T>();

		public override bool Equals(T b1, T b2)
		{
			return Object.ReferenceEquals(b1, b2);

		}

		public override int GetHashCode(T bx)
		{
			return System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(bx);
		}
	}
}