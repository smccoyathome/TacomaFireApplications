using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Contains a collection of System.Windows.Input.StylusPoint objects.
	public class StylusPointCollection : Collection<StylusPoint>
    {
        // Summary:
        //     Initializes a new instance of the System.Windows.Input.StylusPointCollection
        //     class.
        public StylusPointCollection()
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Input.StylusPointCollection
        //     class with specified points.
        //
        // Parameters:
        //   points:
        //     A generic IEnumerable of type System.Windows.Point that specifies the System.Windows.Input.StylusPoint
        //     objects to add to the System.Windows.Input.StylusPointCollection.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     points is null.
        //
        //   System.ArgumentException:
        //     The length of points is 0.
        public StylusPointCollection(IEnumerable<Point> points)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Input.StylusPointCollection
        //     class with the specified System.Windows.Input.StylusPoint objects.
        //
        // Parameters:
        //   stylusPoints:
        //     A generic IEnumerable of type System.Windows.Input.StylusPoint to add to
        //     the System.Windows.Input.StylusPointCollection.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     stylusPoints is null.
        //
        //   System.ArgumentException:
        //     The length of points is 0.-or-The System.Windows.Input.StylusPoint objects
        //     in stylusPoints have incompatible System.Windows.Input.StylusPointDescription
        //     objects.
        public StylusPointCollection(IEnumerable<StylusPoint> stylusPoints)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Input.StylusPointCollection
        //     class that may initially contain the specified number of System.Windows.Input.StylusPoint
        //     objects.
        //
        // Parameters:
        //   initialCapacity:
        //     The number of System.Windows.Input.StylusPoint objects the System.Windows.Input.StylusPointCollection
        //     can initially contain.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     initialCapacity is negative.
        public StylusPointCollection(int initialCapacity)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Input.StylusPointCollection
        //     class that contains the properties specified in the System.Windows.Input.StylusPointDescription.
        //
        // Parameters:
        //   stylusPointDescription:
        //     A System.Windows.Input.StylusPointDescription that specifies the additional
        //     properties stored in each System.Windows.Input.StylusPoint.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     stylusPointDescription is null.
        public StylusPointCollection(StylusPointDescription stylusPointDescription)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Input.StylusPointCollection
        //     class that is the specified size and contains the properties specified in
        //     the System.Windows.Input.StylusPointDescription.
        //
        // Parameters:
        //   stylusPointDescription:
        //     A System.Windows.Input.StylusPointDescription that specifies the additional
        //     properties stored in each System.Windows.Input.StylusPoint.
        //
        //   initialCapacity:
        //     The number of System.Windows.Input.StylusPoint objects the System.Windows.Input.StylusPointCollection
        //     can initially contain.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     initialCapacity is negative.
        //
        //   System.ArgumentNullException:
        //     stylusPointDescription is null.
        public StylusPointCollection(StylusPointDescription stylusPointDescription, int initialCapacity)
        {
            throw new NotImplementedException();
        }

        // Summary:
        //     Converts a System.Windows.Input.StylusPointCollection into a point array.
        //
        // Parameters:
        //   stylusPoints:
        //     The stylus point collection to convert to a point array.
        //
        // Returns:
        //     A point array that contains points that correspond to each System.Windows.Input.StylusPoint
        //     in the System.Windows.Input.StylusPointCollection.
        public static explicit operator Point[](StylusPointCollection stylusPoints)
        {
            throw new NotImplementedException();
        }

        // Summary:
        //     Gets the System.Windows.Input.StylusPointDescription that is associated with
        //     the System.Windows.Input.StylusPoint objects in the System.Windows.Input.StylusPointCollection.
        //
        // Returns:
        //     The System.Windows.Input.StylusPointDescription that is associated with the
        //     System.Windows.Input.StylusPoint objects in the System.Windows.Input.StylusPointCollection.
        public StylusPointDescription Description { set { throw new NotImplementedException(); } }

        // Summary:
        //     Occurs when the System.Windows.Input.StylusPointCollection changes.
        public event EventHandler Changed;

        // Summary:
        //     Adds the specified System.Windows.Input.StylusPointCollection to the current
        //     System.Windows.Input.StylusPointCollection.
        //
        // Parameters:
        //   stylusPoints:
        //     The System.Windows.Input.StylusPointCollection to add to the current System.Windows.Input.StylusPointCollection.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     stylusPoints is null.
        //
        //   System.ArgumentException:
        //     The System.Windows.Input.StylusPointDescription of stylusPoints is not compatible
        //     with the System.Windows.Input.StylusPointCollection.Description property.
        public void Add(StylusPointCollection stylusPoints)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Removes all System.Windows.Input.StylusPoint objects from the System.Windows.Input.StylusPointCollection.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     The System.Windows.Input.StylusPointCollection is connected to a System.Windows.Ink.Stroke.
        protected override sealed void ClearItems()
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Copies the System.Windows.Input.StylusPointCollection.
        //
        // Returns:
        //     A new System.Windows.Input.StylusPointCollection that contains copies of
        //     the System.Windows.Input.StylusPoint objects in the current System.Windows.Input.StylusPointCollection.
        public StylusPointCollection Clone()
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Inserts the specified System.Windows.Input.StylusPoint into the System.Windows.Input.StylusPointCollection
        //     at the specified position.
        //
        // Parameters:
        //   index:
        //     The position at which to insert the System.Windows.Input.StylusPoint.
        //
        //   stylusPoint:
        //     The System.Windows.Input.StylusPoint to insert into the System.Windows.Input.StylusPointCollection.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The System.Windows.Input.StylusPointDescription of stylusPoint is not compatible
        //     with the System.Windows.Input.StylusPointCollection.Description property.
        //
        //   System.ArgumentOutOfRangeException:
        //     index is greater or equal to the number of System.Windows.Input.StylusPoint
        //     objects in the System.Windows.Input.StylusPointCollection.
        protected override sealed void InsertItem(int index, StylusPoint stylusPoint)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Raises the System.Windows.Input.StylusPointCollection.Changed event.
        //
        // Parameters:
        //   e:
        //     An System.EventArgs that contains the event data.
        protected virtual void OnChanged(EventArgs e)
        {
            throw new NotImplementedException();
        }
        
        //
        // Summary:
        //     Finds the intersection of the specified System.Windows.Input.StylusPointDescription
        //     and the System.Windows.Input.StylusPointCollection.Description property.
        //
        // Parameters:
        //   subsetToReformatTo:
        //     A System.Windows.Input.StylusPointDescription to intersect with the System.Windows.Input.StylusPointDescription
        //     of the current System.Windows.Input.StylusPointCollection.
        //
        // Returns:
        //     A System.Windows.Input.StylusPointCollection that has a System.Windows.Input.StylusPointDescription
        //     that is a subset of the specified System.Windows.Input.StylusPointDescription
        //     and the System.Windows.Input.StylusPointDescription that the current System.Windows.Input.StylusPointCollection
        //     uses.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     subsetToReformatTo is not a subset of the System.Windows.Input.StylusPointCollection.Description
        //     property.
        public StylusPointCollection Reformat(StylusPointDescription subsetToReformatTo)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Removes the System.Windows.Input.StylusPoint at the specified position from
        //     the System.Windows.Input.StylusPointCollection.
        //
        // Parameters:
        //   index:
        //     The position at which to remove the System.Windows.Input.StylusPoint.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     The System.Windows.Input.StylusPointCollection is connected to a System.Windows.Ink.Stroke
        //     and there is only one System.Windows.Input.StylusPoint in the System.Windows.Input.StylusPointCollection.
        protected override sealed void RemoveItem(int index)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Sets the specified System.Windows.Input.StylusPoint at the specified position.
        //
        // Parameters:
        //   index:
        //     The position at which to set the System.Windows.Input.StylusPoint.
        //
        //   stylusPoint:
        //     The System.Windows.Input.StylusPoint to set at the specified position.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The System.Windows.Input.StylusPointDescription of stylusPoint is not compatible
        //     with the System.Windows.Input.StylusPointCollection.Description property.
        //
        //   System.ArgumentOutOfRangeException:
        //     index is greater than the number of System.Windows.Input.StylusPoint objects
        //     in the System.Windows.Input.StylusPointCollection.
        protected override sealed void SetItem(int index, StylusPoint stylusPoint)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Converts the property values of the System.Windows.Input.StylusPoint objects
        //     into a 32-bit signed integer array.
        public int[] ToHiMetricArray()
        {
            throw new NotImplementedException();
        }
    }
}
