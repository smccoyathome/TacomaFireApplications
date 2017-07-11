using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Helpers
{
    public class ContainerControl : ScrollableControlViewModel, IInteractsWithView
    {
        private AutoValidate autoValidate = AutoValidate.Inherit; // Indicates whether automatic validation is turned on.
        private ControlViewModel activeControl; // current active control
        private ControlViewModel unvalidatedControl; // The last control that requires validation.  Do not directly edit this value.
        private ControlViewModel focusedControl; // Current focused control. Do not directly edit this value.
        private BitVector32 state = new BitVector32();
        private EventHandler autoValidateChanged; // Event fired whenever the AutoValidate property changes.

        private static readonly int stateScalingNeededOnLayout = BitVector32.CreateMask(); // True if we need to perform scaling when layout resumes
        private static readonly int stateValidating = BitVector32.CreateMask(stateScalingNeededOnLayout); // Indicates whether we're currently state[stateValidating].
        private static readonly int stateProcessingMnemonic = BitVector32.CreateMask(stateValidating); // Indicates whether we or one of our children is currently processing a mnemonic.
        private static readonly int stateScalingChild = BitVector32.CreateMask(stateProcessingMnemonic); // True while we are scaling a child control
        private static readonly int stateParentChanged = BitVector32.CreateMask(stateScalingChild); // Flagged when a parent changes so we can adapt our scaling logic to match

        public override void Build(IIocContainer ctx)
        {
            base.Build(ctx);
        }

        [Reference]
        public virtual ControlViewModel ActiveControl { get; set; }

        //[StateManagement(StateManagementValues.None)]
        //public virtual UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel> ParentForm
        //{
        //    get { return GetParentForm(this); }
        //}

        private UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel> GetParentForm(IStateObject obj)
        {
            IStateObject parent = ViewManager.GetParent(obj);

            if (parent == null)
                return null;

            if (typeof(IViewModel).IsAssignableFrom(parent.GetType()))
                return (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>)parent;

            return GetParentForm(parent);
        }


       // return (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>)(ViewManager.GetParent(this));
        /// <include file='doc\ContainerControl.uex' path='docs/doc[@for="ContainerControl.Validate"]/*' />
        /// <devdoc>
        ///     <para>
        ///     Validates the last unvalidated control and its ancestors up through, but not including the current control.
        ///
        ///     This version always performs validation, regardless of the AutoValidate setting of the control's parent.
        ///     </para>
        /// </devdoc>
        //
        // -------------------------------
        // INTERNAL NOTE FOR [....] DEVS: This version is intended for user code that wants to force validation, even
        // while auto-validation is turned off. When adding any explicit Validate() calls to our code, consider using
        // Validate(true) rather than Validate(), so that you will be sensitive to the current auto-validation setting.
        // -------------------------------
        //
        public bool Validate()
        {
            return Validate(false);
        }

        /// <include file='doc\ContainerControl.uex' path='docs/doc[@for="ContainerControl.Validate2"]/*' />
        /// <devdoc>
        ///     <para>
        ///     Validates the last unvalidated control and its ancestors up through, but not including the current control.
        ///
        ///     This version will skip validation if checkAutoValidate is true and the effective AutoValidate setting, as
        ///     determined by the control's parent, is AutoValidate.Disable.
        ///     </para>
        /// </devdoc>
        public bool Validate(bool checkAutoValidate)
        {
            bool validatedControlAllowsFocusChange;
            return ValidateInternal(checkAutoValidate, out validatedControlAllowsFocusChange);
        }

        internal bool ValidateInternal(bool checkAutoValidate, out bool validatedControlAllowsFocusChange)
        {
            validatedControlAllowsFocusChange = false;

            if (this.AutoValidate == AutoValidate.EnablePreventFocusChange ||
                (activeControl != null && activeControl.CausesValidation))
            {
                if (unvalidatedControl == null)
                {
                    if (focusedControl is ContainerControl && focusedControl.CausesValidation)
                    {
                        ContainerControl c = (ContainerControl)focusedControl;
                        if (!c.ValidateInternal(checkAutoValidate, out validatedControlAllowsFocusChange))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        unvalidatedControl = focusedControl;
                    }
                }

                // Should we force focus to stay on same control if there is a validation error?
                bool preventFocusChangeOnError = true;

                ControlViewModel controlToValidate = unvalidatedControl != null ? unvalidatedControl : focusedControl;

                if (controlToValidate != null)
                {
                    // Get the effective AutoValidate mode for unvalidated control (based on its container control)
                    AutoValidate autoValidateMode = ControlViewModel.GetAutoValidateForControl(controlToValidate);

                    // Auto-validate has been turned off in container of unvalidated control - stop now
                    if (checkAutoValidate && autoValidateMode == AutoValidate.Disable)
                    {
                        return true;
                    }
                    preventFocusChangeOnError = (autoValidateMode == AutoValidate.EnablePreventFocusChange);
                    validatedControlAllowsFocusChange = (autoValidateMode == AutoValidate.EnableAllowFocusChange);
                }

                return ValidateThroughAncestor(null, preventFocusChangeOnError);
            }
            return true;
        }

        public virtual AutoValidate AutoValidate
        {
            get
            {
                if (autoValidate == AutoValidate.Inherit)
                {
                    return GetAutoValidateForControl(this);
                }
                else
                {
                    return autoValidate;
                }
            }
            set
            {
                // PERF/FXCop: dont use Enum.IsDefined.
                switch (value)
                {
                    case AutoValidate.Disable:
                    case AutoValidate.EnablePreventFocusChange:
                    case AutoValidate.EnableAllowFocusChange:
                    case AutoValidate.Inherit:
                        break;
                    default:
                        throw new InvalidEnumArgumentException("AutoValidate", (int)value, typeof(AutoValidate));
                }

                if (autoValidate != value)
                {
                    autoValidate = value;
                    OnAutoValidateChanged(EventArgs.Empty);
                }
            }
        }

        /// <include file='doc\ContainerControl.uex' path='docs/doc[@for="Binding.OnAutoValidateChanged"]/*' />
        /// <devdoc>
        ///    Raises the AutoValidateChanged event.
        /// </devdoc>
        protected virtual void OnAutoValidateChanged(EventArgs e)
        {
            if (autoValidateChanged != null)
            {
                autoValidateChanged(this, e);
            }
        }

        private bool ValidateThroughAncestor(ControlViewModel ancestorControl, bool preventFocusChangeOnError)
        {
            if (ancestorControl == null)
                ancestorControl = this;
            if (state[stateValidating])
                return false;
            if (unvalidatedControl == null)
                unvalidatedControl = focusedControl;
            //return true for a Container Control with no controls to validate....
            //
            if (unvalidatedControl == null)
                return true;
            if (!ancestorControl.IsDescendant(unvalidatedControl))
                return false;

            this.state[stateValidating] = true;
            bool cancel = false;

            ControlViewModel currentActiveControl = activeControl;
            ControlViewModel currentValidatingControl = unvalidatedControl;
            if (currentActiveControl != null)
            {
                currentActiveControl.ValidationCancelled = false;
                if (currentActiveControl is ContainerControl)
                {
                    ContainerControl currentActiveContainerControl = currentActiveControl as ContainerControl;

                    currentActiveContainerControl.ResetValidationFlag();
                }
            }
            try
            {
                while (currentValidatingControl != null && currentValidatingControl != ancestorControl)
                {
                    try
                    {
                        cancel = currentValidatingControl.PerformControlValidation(false);
                    }
                    catch
                    {
                        cancel = true;
                        throw;
                    }

                    if (cancel)
                    {
                        break;
                    }

                    currentValidatingControl = currentValidatingControl.ParentInternal;
                }

                if (cancel && preventFocusChangeOnError)
                {
                    if (unvalidatedControl == null && currentValidatingControl != null &&
                        ancestorControl.IsDescendant(currentValidatingControl))
                    {
                        unvalidatedControl = currentValidatingControl;
                    }
                    // This bit 'marks' the control that was going to get the focus, so that it will ignore any pending
                    // mouse or key events. Otherwise it would still perform its default 'click' action or whatever.
                    if (currentActiveControl == activeControl)
                    {
                        if (currentActiveControl != null)
                        {
                            CancelEventArgs ev = new CancelEventArgs();
                            ev.Cancel = true;
                            currentActiveControl.NotifyValidationResult(currentValidatingControl, ev);
                            if (currentActiveControl is ContainerControl)
                            {
                                ContainerControl currentActiveContainerControl = currentActiveControl as ContainerControl;
                                if (currentActiveContainerControl.focusedControl != null)
                                {
                                    currentActiveContainerControl.focusedControl.ValidationCancelled = true;
                                }
                                currentActiveContainerControl.ResetActiveAndFocusedControlsRecursive();
                            }
                        }
                    }
                    // This bit forces the focus to move back to the invalid control
                    SetActiveControlInternal(unvalidatedControl);
                }
            }
            finally
            {
                unvalidatedControl = null;
                state[stateValidating] = false;
            }

            return !cancel;
        }

        private void ResetValidationFlag()
        {
            // PERFNOTE: This is more efficient than using Foreach.  Foreach
            // forces the creation of an array subset enum each time we
            // enumerate
            IList<ControlViewModel> children = this.Controls;
            int count = children.Count;
            for (int i = 0; i < count; i++)
            {
                children[i].ValidationCancelled = false;
            }
        }

        internal void ResetActiveAndFocusedControlsRecursive()
        {
            if (activeControl is ContainerControl)
            {
                ((ContainerControl)activeControl).ResetActiveAndFocusedControlsRecursive();
            }
            activeControl = null;
            focusedControl = null;
        }

        /// <devdoc>
        ///     Unsafe version of SetActiveControl - Use with caution!
        /// </devdoc>
        internal void SetActiveControlInternal(ControlViewModel value)
        {
            if (activeControl != value || (value != null && !value.Focused))
            {
                if (value != null && !Contains(value))
                {
                    throw new ArgumentException(UpgradeHelpers.Helpers.SafeNativeMethods.SR.GetString(UpgradeHelpers.Helpers.SafeNativeMethods.SR.CannotActivateControl));
                }

                bool ret;
                ContainerControl cc = this;

                if (value != null && value.ParentInternal != null)
                {
                    cc = (value.ParentInternal.GetContainerControlInternal()) as ContainerControl;
                }
                if (cc != null)
                {
                    // Call to the recursive function that corrects the chain
                    // of active controls
                    ret = cc.ActivateControlInternal(value, false);
                }
                else
                {
                    ret = AssignActiveControlInternal(value);
                }

                if (cc != null && ret)
                {
                    ContainerControl ccAncestor = this;
                    while (ccAncestor.ParentInternal != null &&
                           ccAncestor.ParentInternal.GetContainerControlInternal() is ContainerControl)
                    {
                        ccAncestor = ccAncestor.ParentInternal.GetContainerControlInternal() as ContainerControl;
                    }

                    if (ccAncestor.ContainsFocus &&
                        (value == null ||
                         !(value is IUserControl) ||
                         (value is IUserControl && !((IUserControl)value).HasFocusableChild())))
                    {
                        cc.FocusActiveControlInternal();
                    }
                }
            }
        }

        private void FocusActiveControlInternal()
        {
            throw new NotImplementedException();
        }

        private bool AssignActiveControlInternal(ControlViewModel value)
        {
            throw new NotImplementedException();
        }

        private bool ActivateControlInternal(ControlViewModel value, bool p)
        {
            throw new NotImplementedException();
        }

        /// <internalonly/>
        /// <devdoc>
        ///     Used for UserControls - checks if the control
        ///     has a focusable control inside or not
        /// </devdoc>
        internal bool HasFocusableChild()
        {
            ControlViewModel ctl = null;
            do
            {
                ctl = GetNextControl(ctl, true);
                if (ctl != null &&
                    ctl.CanSelect &&
                    ctl.TabStop)
                {
                    break;
                }
            } while (ctl != null);
            return ctl != null;
        }
    }
}
