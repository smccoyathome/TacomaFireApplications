using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Specifies the properties that are in a System.Windows.Input.StylusPoint.
	public class StylusPointDescription
    {
        // Summary:
        //     Initializes a new instance of the System.Windows.Input.StylusPointDescription
        //     class.
        public StylusPointDescription()
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Input.StylusPointDescription
        //     class with the specified System.Windows.Input.StylusPointPropertyInfo objects.
        //
        // Parameters:
        //   stylusPointPropertyInfos:
        //     A generic IEnumerable of type System.Windows.Input.StylusPointPropertyInfo
        //     that specifies the properties in the System.Windows.Input.StylusPointDescription.
        public StylusPointDescription(IEnumerable<StylusPointPropertyInfo> stylusPointPropertyInfos)
        {
            throw new NotImplementedException();
        }

        // Summary:
        //     Gets the number of properties in the System.Windows.Input.StylusPointDescription.
        //
        // Returns:
        //     The number of properties in the System.Windows.Input.StylusPointDescription.
        public int PropertyCount { get { throw new NotImplementedException(); }}

        // Summary:
        //     Returns a value that indicates whether the specified System.Windows.Input.StylusPointDescription
        //     objects are identical.
        //
        // Parameters:
        //   stylusPointDescription1:
        //     The first System.Windows.Input.StylusPointDescription to check.
        //
        //   stylusPointDescription2:
        //     The second System.Windows.Input.StylusPointDescription to check.
        //
        // Returns:
        //     true if the System.Windows.Input.StylusPointDescription objects are identical;
        //     otherwise, false.
        public static bool AreCompatible(StylusPointDescription stylusPointDescription1, StylusPointDescription stylusPointDescription2)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Returns the intersection of the specified System.Windows.Input.StylusPointDescription
        //     objects.
        //
        // Parameters:
        //   stylusPointDescription:
        //
        //   stylusPointDescriptionPreserveInfo:
        //     The second System.Windows.Input.StylusPointDescription to intersect.
        //
        // Returns:
        //     A System.Windows.Input.StylusPointDescription that contains the properties
        //     that are present if both of the specified System.Windows.Input.StylusPointDescription
        //     objects.
        public static StylusPointDescription GetCommonDescription(StylusPointDescription stylusPointDescription, StylusPointDescription stylusPointDescriptionPreserveInfo)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Gets the System.Windows.Input.StylusPointPropertyInfo for the specified property.
        //
        // Parameters:
        //   stylusPointProperty:
        //     The System.Windows.Input.StylusPointProperty that specifies the property
        //     of the desired System.Windows.Input.StylusPointPropertyInfo.
        //
        // Returns:
        //     The System.Windows.Input.StylusPointPropertyInfo for the specified System.Windows.Input.StylusPointProperty.
        public StylusPointPropertyInfo GetPropertyInfo(StylusPointProperty stylusPointProperty)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Gets all the properties of the System.Windows.Input.StylusPointDescription.
        //
        // Returns:
        //     A collection that contains all of the System.Windows.Input.StylusPointPropertyInfo
        //     objects in the System.Windows.Input.StylusPointDescription.
        public ReadOnlyCollection<StylusPointPropertyInfo> GetStylusPointProperties()
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Returns a value that indicates whether the current System.Windows.Input.StylusPointDescription
        //     has the specified property.
        //
        // Parameters:
        //   stylusPointProperty:
        //     The System.Windows.Input.StylusPointProperty to check for in the System.Windows.Input.StylusPointDescription.
        //
        // Returns:
        //     true if the System.Windows.Input.StylusPointDescription has the specified
        //     System.Windows.Input.StylusPointProperty; otherwise, false.
        public bool HasProperty(StylusPointProperty stylusPointProperty)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Returns a value that indicates whether the current System.Windows.Input.StylusPointDescription
        //     is a subset of the specified System.Windows.Input.StylusPointDescription.
        //
        // Parameters:
        //   stylusPointDescriptionSuperset:
        //     The System.Windows.Input.StylusPointDescription against which to check whether
        //     the current System.Windows.Input.StylusPointDescription is a subset.
        //
        // Returns:
        //     true if the current System.Windows.Input.StylusPointDescription is a subset
        //     of the specified System.Windows.Input.StylusPointDescription; otherwise,
        //     false.
        public bool IsSubsetOf(StylusPointDescription stylusPointDescriptionSuperset)
        {
            throw new NotImplementedException();
        }
    }
}
