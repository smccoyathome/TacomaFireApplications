using System;
using System.Collections;
using System.Security;
using UpgradeHelpers.Events;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Provides an abstract base for classes that present content from another technology
	//     as part of an interoperation scenario. In addition, this class provides static
	//     methods for working with these sources, as well as the basic visual-layer
	//     presentation architecture.
	public abstract class PresentationSource : DispatcherObject
    {
        // Summary:
        //     Provides initialization for base class values when called by the constructor
        //     of a derived class.
        protected PresentationSource()
        {
            throw new NotImplementedException();
        }

        // Summary:
        //     Gets the visual target for the visuals being presented in the source.
        //
        // Returns:
        //     A visual target (instance of a System.Windows.Media.CompositionTarget derived
        //     class).
        public CompositionTarget CompositionTarget { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Returns a list of sources.
        public static IEnumerable CurrentSources { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     When overridden in a derived class, gets a value that declares whether the
        //     object is disposed.
        //
        // Returns:
        //     true if the object is disposed; otherwise, false.
        public abstract bool IsDisposed { get; }

        //
        // Summary:
        //     When overridden in a derived class, gets or sets the root visual being presented
        //     in the source.
        //
        // Returns:
        //     The root visual.
        public abstract Visual RootVisual { get; set; }

        // Summary:
        //     Occurs when content is rendered and ready for user interaction.
        public event EventHandler ContentRendered;

        // Summary:
        //     Adds a System.Windows.PresentationSource derived class instance to the list
        //     of known presentation sources.
        protected void AddSource()
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Adds a handler for the SourceChanged event to the provided element.
        //
        // Parameters:
        //   element:
        //     The element to add the handler to.
        //
        //   handler:
        //     The hander implementation to add.
        [SecurityCritical]
        public static void AddSourceChangedHandler(IInputElement element, SourceChangedEventHandler handler)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Sets the list of listeners for the System.Windows.PresentationSource.ContentRendered
        //     event to null.
        protected void ClearContentRenderedListeners()
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Returns the source in which a provided System.Windows.DependencyObject is
        //     presented.
        //
        // Parameters:
        //   dependencyObject:
        //     The System.Windows.DependencyObject to find the source for.
        //
        // Returns:
        //     The System.Windows.PresentationSource in which the dependency object is being
        //     presented.
        [SecurityCritical]
        public static PresentationSource FromDependencyObject(DependencyObject dependencyObject)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Returns the source in which a provided System.Windows.Media.Visual is presented.
        //
        // Parameters:
        //   visual:
        //     The System.Windows.Media.Visual to find the source for.
        //
        // Returns:
        //     The System.Windows.PresentationSource in which the visual is being presented,
        //     or null if visual is disposed.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     visual is null.
        [SecurityCritical]
        public static PresentationSource FromVisual(Visual visual)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     When overridden in a derived class, returns a visual target for the given
        //     source.
        //
        // Returns:
        //     Returns a System.Windows.Media.CompositionTarget that is target for rendering
        //     the visual.
        protected abstract CompositionTarget GetCompositionTargetCore();

        //
        // Summary:
        //     Removes a System.Windows.PresentationSource derived class instance from the
        //     list of known presentation sources.
        protected void RemoveSource()
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Removes a handler for the SourceChanged event from the provided element.
        //
        // Parameters:
        //   e:
        //     The element to remove the handler from.
        //
        //   handler:
        //     The handler implementation to remove.
        public static void RemoveSourceChangedHandler(IInputElement e, SourceChangedEventHandler handler)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Provides notification that the root System.Windows.Media.Visual has changed.
        //
        // Parameters:
        //   oldRoot:
        //     The old root System.Windows.Media.Visual.
        //
        //   newRoot:
        //     The new root System.Windows.Media.Visual.
        [SecurityCritical]
        [SecurityTreatAsSafe]
        protected void RootChanged(Visual oldRoot, Visual newRoot)
        {
            throw new NotImplementedException();
        }
    }
}
