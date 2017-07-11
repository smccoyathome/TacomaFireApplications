using System;
using System.Runtime.CompilerServices;

namespace UpgradeHelpers.WebMap.Server
{
    public static class StringExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EndsWithEx(this string value, string endingvalue)
        {
            int evLength = endingvalue.Length;
            int vLength = value.Length;
            if (evLength > vLength)
                return false;
            if (evLength == vLength)
                return endingvalue.Equals(value);
            return value.Substring(vLength - evLength, evLength).Equals(endingvalue);
        }




        /// <summary>
        /// Verifies that the string ends with the given endingValue with the addtional check that
        /// There is a UniqueIDGenerator.SeparatorChar.
        /// 
        /// A new method was created for performance reasons instead of using the common EndsWithEx
        /// An example of the issue is caused by uniqueID pairs like:
        /// 
        ///            Controls#0#Items#groupCollection#noteSymptomDetail#2CB5
        /// 0#m_RuntimeControls#0#Items#groupCollection#noteSymptomDetail#2CB5  
        /// </summary>
        /// <param name="childUniqueID"></param>
        /// <param name="parentUniqueID"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EndsWithExForChild(this string childUniqueID, string parentUniqueID)
        {
            int evLength = parentUniqueID.Length;
            int vLength = childUniqueID.Length;
            if (evLength > vLength)
                return false;
            if (evLength == vLength)
            {
                //This should be false, because that means that the item is not a child
				return false;
            }
            return
                //Here we know that the child unique is at least 1 bigger that the parent UniqueID
                childUniqueID.Substring(vLength - evLength, evLength).Equals(parentUniqueID) &&
                childUniqueID[(vLength - evLength) - 1] == '#';
        }
    }
}
