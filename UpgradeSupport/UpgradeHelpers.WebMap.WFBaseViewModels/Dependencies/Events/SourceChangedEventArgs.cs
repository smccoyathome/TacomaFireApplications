using System;
using System.Security;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Events
{
	// Summary:
	//     Provides data for the SourceChanged event, used for interoperation. This
	//     class cannot be inherited.
	public sealed class SourceChangedEventArgs : RoutedEventArgs
    {
        // Summary:
        //     Initializes a new instance of the System.Windows.SourceChangedEventArgs class,
        //     using supplied information for the old and new sources.
        //
        // Parameters:
        //   oldSource:
        //     The old System.Windows.PresentationSource that this handler is being notified
        //     about.
        //
        //   newSource:
        //     The new System.Windows.PresentationSource that this handler is being notified
        //     about.
        [SecurityCritical]
        public SourceChangedEventArgs(PresentationSource oldSource, PresentationSource newSource)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Initializes a new instance of the System.Windows.SourceChangedEventArgs class,
        //     using supplied information for the old and new sources, the element that
        //     this change effects, and the previous reported parent of that element.
        //
        // Parameters:
        //   oldSource:
        //     The old System.Windows.PresentationSource that this handler is being notified
        //     about.
        //
        //   newSource:
        //     The new System.Windows.PresentationSource that this handler is being notified
        //     about.
        //
        //   element:
        //     The element whose parent changed causing the source to change.
        //
        //   oldParent:
        //     The old parent of the element whose parent changed causing the source to
        //     change.
        [SecurityCritical]
        public SourceChangedEventArgs(PresentationSource oldSource, PresentationSource newSource, IInputElement element, IInputElement oldParent)
        {
            throw new NotImplementedException();
        }

        // Summary:
        //     Gets the element whose parent change causing the presentation source information
        //     to change.
        //
        // Returns:
        //     The element that is reporting the change.
        public IInputElement Element { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the new source involved in this source change.
        //
        // Returns:
        //     The new System.Windows.PresentationSource.
        public PresentationSource NewSource { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the previous parent of the element whose parent change causing the presentation
        //     source information to change.
        //
        // Returns:
        //     The previous parent element source.
        public IInputElement OldParent { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the old source involved in this source change.
        //
        // Returns:
        //     The old System.Windows.PresentationSource.
        public PresentationSource OldSource { get { throw new NotImplementedException(); } }


        protected override void InvokeEventHandler(Delegate genericHandler, object genericTarget)
        {
            throw new NotImplementedException();
        }
    }
}
