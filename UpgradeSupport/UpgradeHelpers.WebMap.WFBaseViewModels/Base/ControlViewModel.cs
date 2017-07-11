using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UpgradeHelpers.Events;
using UpgradeHelpers.Interfaces;
using System.Linq;
using UpgradeHelpers.Extensions;
using Newtonsoft.Json;

namespace UpgradeHelpers.Helpers
{
    public partial class ControlViewModel : ControlBaseViewModel, IControl, IDependentViewModel, UpgradeHelpers.Interfaces.IComponent, IControlsContainer
    {
        public virtual Cursor Cursor { get; set; }

        [Obsolete]
        public void SetValue(DependencyProperty dp, object value)
        {
        }

        [Obsolete]
        public object GetValue(DependencyProperty dependencyProperty)
        {
            return null;
        }


        [Reference]
        public virtual object ultratoolbarsmanager { get; set; }
        [Reference]
        public virtual object ContextMenuUltra { get; set; }
        [Reference]
        public virtual object ContextMenuUltraRemove { get; set; }
        protected bool ResizeRedraw { get; set; }
        protected virtual void Select(bool directed, bool forward)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnMouseWheel(UpgradeHelpers.Events.MouseEventArgs e)
        {
        }

        [DefaultValue(null)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual Padding Padding
        {
            get
            {
                return new Padding(0);
            }
            set { }
        }

        public virtual ControlViewModel TopLevelControl { get; set; }

        protected virtual Padding DefaultMargin
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #region public event

        /// <summary>
        /// Occurs when the control receives focus.
        /// Added for compatibility purposes, but no needed in webmap´s architecture  
        /// </summary>
        public event System.EventHandler GotFocus;

        /// <summary>
        /// Occurs when the value of the Checked property changes.
        /// Added for compatibility purposes, but no needed in webmap´s architecture  
        /// </summary>
        public event System.EventHandler CheckedChanged;

        public event System.EventHandler CheckedValueChanged;

        public event System.EventHandler MouseEnter;

        public event System.EventHandler MouseLeave;

        public event System.EventHandler MouseHover;

        public event System.EventHandler HandleCreated;

        public event System.EventHandler Enter;

        public event System.EventHandler Leave;

        public event System.EventHandler DoubleClick;

        public event System.EventHandler ClientSizeChanged;

        public event System.EventHandler CheckStateChanged;

        public event System.EventHandler VisibleChanged;

        public event System.EventHandler ParentChanged;

        public event System.EventHandler RegionChanged;

        public event System.EventHandler Disposed;

        public event UpgradeHelpers.Events.MouseEventHandler MouseDown;

        public event UpgradeHelpers.Events.MouseEventHandler MouseUp;

        public event UpgradeHelpers.Events.MouseEventHandler MouseClick;

        public event UpgradeHelpers.Events.MouseEventHandler MouseMove;

        public event UpgradeHelpers.Events.KeyPressEventHandler KeyPress;

        public event UpgradeHelpers.Events.LayoutEventHandler Layout;

        public event UpgradeHelpers.Events.ControlEventHandler ControlAdded;

        public event UpgradeHelpers.Events.ControlEventHandler ControlRemoved;

        public event UpgradeHelpers.Events.KeyEventHandler KeyDown;

        public event UpgradeHelpers.Events.RoutedEventHandler Unloaded;

        public event UpgradeHelpers.Events.DragEventHandler DragOver;

        /// <summary>
        /// Occurs when the control is redrawn.
        /// Added for compatibility issues, not needed in webmap's current architecture
        /// </summary> 
        public event UpgradeHelpers.Events.PaintEventHandler Paint;

        #endregion
        //[StateManagement(StateManagementValues.ServerOnly)]
        public virtual object DataContext { get; set; }
        public static Keys ModifierKeys { get; set; }

        protected virtual void OnPaintBackground(PaintEventArgs pevent)
        {
            throw new NotImplementedException();
        }

        protected virtual bool IsInputChar(char charCode)
        {
            throw new NotImplementedException();
        }

        public static bool IsMnemonic(char charCode, string p)
        {
            return false;
        }

        public void Hide() {
            this.Visible = false;
        }

        /// <summary>
        /// Activates the next control.
        /// </summary>
        /// <param name="ctl"> The Control at which to start the search.</param>
        /// <param name="forward"> true to move forward in the tab order; false to move backward in the tab order.</param>
        /// <param name="tabStopOnly"> true to ignore the controls with the TabStop property set to false; otherwise, false.</param>
        /// <param name="nested"> true to include nested (children of child controls) child controls; otherwise, false.</param>
        /// <param name="wrap"> true to continue searching from the first control in the tab order after the last control has been reached; otherwise, false.</param>
        /// <maps>SelectNextControl</maps> 
        public bool SelectNextControl(ControlViewModel ctl, bool forward, bool tabStopOnly, bool nested, bool wrap)
        {
            return false;
        }

        protected virtual void OnBackColorChanged(EventArgs e)
        {
            throw new NotImplementedException();
        }

        public object FindResource(object resourceKey)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnGotFocus(EventArgs e)
        {
            throw new NotImplementedException();
        }
        public DragDropEffects DoDragDrop(object data, DragDropEffects dragDropEffects)
        {
            throw new NotImplementedException();
        }
        protected virtual void OnSystemColorsChanged(EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected bool DesignMode { get; set; }

        protected virtual void OnAutoSizeChanged(EventArgs e)
        {

        }

        protected virtual bool ProcessCmdKey(ref Object msg, UpgradeHelpers.Helpers.Keys keyData)
        {
            return false;
        }

        protected override bool ProcessCmdKey(ref UpgradeHelpers.Helpers.Message msg, UpgradeHelpers.Helpers.Keys keyData)
        {
            return false;
        }

        [StateManagement(StateManagementValues.ServerOnly)]
        public virtual Rectangle DisplayRectangle { get; set; }

        public static MouseButtons MouseButtons { get; set; }

        [StateManagement(StateManagementValues.ServerOnly)]
        public Rectangle Bounds { get; set; }

        [Reference]
        public virtual ControlViewModel _parent { get; set; }
        [StateManagement(StateManagementValues.ClientOnly)]
        public ControlViewModel Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                if (value != null)
                {
                    value.Controls.AddControl(this, value);
                }
                else
                {
                    if (_parent != null)
                    {
                        //Removes the control from the current parent
                        this._parent.Controls.RemoveControl(this);
                    }
                }
            }
        }

        [DefaultValue(RightToLeft.No)] // = 0
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual RightToLeft RightToLeft { get; set; }

        //todo not uset public virtual IntPtr Handle { get; set; }

        [StateManagement(StateManagementValues.None)]
        public virtual Color BackGroundColor { get; set; }


        [DefaultValue(0)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual ContentAlignment CheckAlign { get; set; }

        [DefaultValue(AutoSizeMode.GrowAndShrink)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual AutoSizeMode AutoSizeMode { get; set; }

        [StateManagement(StateManagementValues.ClientOnly)]
        public override Point Location
        {
            get
            {
                return new Point(Left, Top);
            }
            set
            {
                if (value != null)
                {
                    Left = value.X;
                    Top = value.Y;
                }
            }
        }

        [StateManagement(StateManagementValues.ClientOnly)]
        public override Size Size
        {
            get
            {
                return new Size(this.Width, this.Height);
            }
            set
            {
                if (value != null)
                {
                    Height = value.Height;
                    Width = value.Width;
                }
            }
        }

        [StateManagement(StateManagementValues.None)]
        public virtual Size ClientSize
        {
            get
            {
                return Size;
            }
        }


        [StateManagement(StateManagementValues.ServerOnly)]
        public virtual bool DoubleBuffered { get; set; }

        public static UpgradeHelpers.Helpers.Keys Get_ModifierKeys()
        {
            return ModifierKeys;
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }
		

        public virtual UpgradeHelpers.Helpers.FlatStyle FlatStyle { get; set; }
		
        //
        // Summary:
        //     Invalidates a specific region of the control and causes a paint message to
        //     be sent to the control. Optionally, invalidates the child controls assigned
        //     to the control.
        //
        // Parameters:
        //   invalidateChildren:
        //     true to invalidate the control's child controls; otherwise, false.
        public virtual void Invalidate(bool invalidateChildren)
        {
        }

        //
        // Summary:
        //     Invalidates the specified region of the control (adds it to the control's
        //     update region, which is the area that will be repainted at the next paint
        //     operation), and causes a paint message to be sent to the control.
        //
        // Parameters:
        //   rc:
        //     A System.Drawing.Rectangle that represents the region to invalidate.
        public virtual void Invalidate(Rectangle rc)
        {
            //throw new NotImplementedException();
        }

        //
        // Summary:
        //     Invalidates the specified region of the control (adds it to the control's
        //     update region, which is the area that will be repainted at the next paint
        //     operation), and causes a paint message to be sent to the control.
        //
        // Parameters:
        //   region:
        //     The System.Drawing.Region to invalidate.
        public virtual void Invalidate(Region region)
        {
            //throw new NotImplementedException();
        }

        //
        // Summary:
        //     Invalidates the specified region of the control (adds it to the control's
        //     update region, which is the area that will be repainted at the next paint
        //     operation), and causes a paint message to be sent to the control. Optionally,
        //     invalidates the child controls assigned to the control.
        //
        // Parameters:
        //   rc:
        //     A System.Drawing.Rectangle that represents the region to invalidate.
        //
        //   invalidateChildren:
        //     true to invalidate the control's child controls; otherwise, false.
        public virtual void Invalidate(Rectangle rc, bool invalidateChildren)
        {
            //throw new NotImplementedException();
        }

        //
        // Summary:
        //     Invalidates the specified region of the control (adds it to the control's
        //     update region, which is the area that will be repainted at the next paint
        //     operation), and causes a paint message to be sent to the control. Optionally,
        //     invalidates the child controls assigned to the control.
        //
        // Parameters:
        //   region:
        //     The System.Drawing.Region to invalidate.
        //
        //   invalidateChildren:
        //     true to invalidate the control's child controls; otherwise, false.
        public virtual void Invalidate(Region region, bool invalidateChildren)
        {
            //throw new NotImplementedException();
        }

        public Point PointToClient(Point point)
        {
            throw new NotImplementedException();
        }

        [StateManagement(StateManagementValues.None)]
        public int Bottom
        {
            get
            {
                if (this.Location == null && this.Size == null)
                    return 0;

                return this.Location.Y + this.Size.Height;
            }
        }

        [StateManagement(StateManagementValues.ServerOnly)]
        public bool InvokeRequired { get; set; }

        public virtual void Invalidate() { }

        public class ControlCollection : System.Collections.CollectionBase, IDependentModel, IInitializable 
        {
            [StateManagement(StateManagementValues.None)]
            [DefaultValue(false)]
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
            /// <summary>
            /// This is just a wrapper around the capacity property
            /// </summary>
            public new int Capacity { get { return 0; } set { } }

            /// <summary>
            /// This flag is used to avoid overhead checking if Items property is set because that is 
            /// an intercepted property
            /// </summary>
            private bool itemsLoaded;

            private IList<object> MakeSureThereIsAnItemsList()
            {
                if (!itemsLoaded && Items == null)
                {
                    
                    itemsLoaded = true;
                    return Items = StaticContainer.Instance.Resolve<IList<object>>();
                }
                return Items;
            }
            public virtual IList<object> Items { get; set; }

            public void Init() {}

            public ControlCollection(){}
            public void Add(object value)
            {
                MakeSureThereIsAnItemsList();
                Items.Add(value);
            }
            public void Add(object value, object controlParent)
            {
                IControl control = value as IControl;
                IStateObject parent = controlParent as IStateObject;
                if (control == null)
                    return;

                var wrappedControl = control as ControlViewModel;
                var wrappedParent = parent as ControlViewModel;
                var validParent = false;

                var items = MakeSureThereIsAnItemsList();
                //If the Control is already there, we should not insert it in the list.
                if (items.Contains(control))
                    return;

                items.Add(control);

                //  If the collection is attached, the TopLevelObject is a View and that View is loaded
                //then we should call Load method for the control...If exists
                if (parent != null)
                {
                    //Sets the control parent
                    if (wrappedControl != null && wrappedParent != null)
                    {
                        wrappedControl._parent = wrappedParent;
                        validParent = true;
                        if (control != null)
                        {
                            if (wrappedParent.Visible)
                                (control as IControlWithState).VisibleState |= VisibleState.ParentVisible;
                            else
                                (control as IControlWithState).VisibleState &= ~VisibleState.ParentVisible;
                            (control as IControlWithState).NotifyParentVisibility(control, wrappedParent.Visible);
                        }
                    }
                }

                //The LifeCycle logic is executed for the current control
                var iloadableObj = control as ILifeCycle;
                if (iloadableObj != null)
                    iloadableObj.LifeCycleStartup(parent as IControlWithState);

                //Control added event is triggered
                if (validParent)
                {
                    wrappedParent.HandleAddControlEvents(wrappedControl);
                }
            }
            public new void Clear()
            {
                List.Clear();
            }

            public bool Contains(object value)
            {
                IList<object> items=null;
                if (!itemsLoaded && (items=Items) == null)
                {
                    return false;
                }
                return items.Contains(value);
            }

            public int IndexOf(object value)
            {
                IList<object> items = null;
                if (!itemsLoaded && (items = Items) == null)
                {
                    return -1;
                }
                return items.IndexOf(value);
            }

            public void Insert(int index, object value)
            {
                var items = MakeSureThereIsAnItemsList();
                items.Insert(index, value);
            }

            [StateManagement(StateManagementValues.None)]
            [DefaultValue(false)]
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
            public bool IsFixedSize
            {
                get;
                set;
            }

            [StateManagement(StateManagementValues.None)]
            [DefaultValue(false)]
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
            public bool IsReadOnly
            {
                get
                {
                    return false;
                }
            }

            public bool Remove(object value)
            {
                return false;
            }

            public new void RemoveAt(int index)
            {
                IList<object> items = null;
                if (!itemsLoaded && (items = Items) == null)
                {
                    return;
                }
                 items.RemoveAt(index);
            }

            EventHandler Resize { get; set; }

            [StateManagement(StateManagementValues.None)]
            [DefaultValue(false)]
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
            public int Bottom { get; set; }

            public ControlViewModel this[int index]
            {
                get
                {
                    IList<object> items = null;
                    if (!itemsLoaded && (items = Items) == null)
                    {
                        throw new IndexOutOfRangeException("The Item collections is null any indexed reference is invalid at this point");
                    }
                    return (ControlViewModel)items[index];
                }
                set
                {
                    IList<object> items = null;
                    if (!itemsLoaded && (items = Items) == null)
                    {
                        throw new IndexOutOfRangeException("The Item collections is null any indexed reference is invalid at this point");
                    }
                    items[index] = value;
                }
            }

            public ControlViewModel this[string indexAux]
            {

                get
                {
                    IList<object> items = null;
                    if (!itemsLoaded && (items = Items) == null)
                    {
                        throw new IndexOutOfRangeException("The Item collections is null any indexed reference is invalid at this point");
                    }
                    int index;
                    Int32.TryParse(indexAux, out index);
                    return (ControlViewModel)items[index];
                }
                set
                {
                    IList<object> items = null;
                    if (!itemsLoaded && (items = Items) == null)
                    {
                        throw new IndexOutOfRangeException("The Item collections is null any indexed reference is invalid at this point");
                    }
                    int index;
                    Int32.TryParse(indexAux, out index);
                    items[index] = value;
                }
            }
            


            public void CopyTo(object[] array, int index)
            {
                throw new NotImplementedException();
            }


            [StateManagement(StateManagementValues.None)]
            [DefaultValue(false)]
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
            public new int Count
            {
                get {

                    IList<object> items = null;
                    if (!itemsLoaded && (items = Items) == null)
                    {
                        return 0;
                    }
                    return items.Count;
                }
            }


            [StateManagement(StateManagementValues.None)]
            [DefaultValue(false)]
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
            public bool IsSynchronized
            {
                get;
                set;
            }

            [StateManagement(StateManagementValues.None)]
            [DefaultValue(false)]
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
            public object SyncRoot
            {
                get;
                set;
            }

            public string UniqueID { get; set; }

            public new IEnumerator<object> GetEnumerator()
            {
                return this.Items.GetEnumerator();
            }
            public void AddRange(ControlViewModel[] controls)
            {
                var items = MakeSureThereIsAnItemsList();
                foreach (ControlViewModel control in controls)
                {
                    items.Add(control);
                }
            }

            public void SetChildIndex(object obj, int p)
            {
                int objectRemovedIndex = IndexOf(obj);
                RemoveAt(objectRemovedIndex);
                Insert(p, obj);
            }



            public void Add(object globalUpgradeHelpersBasicViewModelsLabelViewModel, int p1, int p2)
            {

            }

            public ControlViewModel[] Find(string Key, bool Recursive)
            {
                return this.Cast<ControlViewModel>().Where(x => x.Name.Contains(Key)).ToArray<ControlViewModel>();

            }

            public bool ContainsKey(string p)
            {
                throw new NotImplementedException();
            }

            public int IndexOfKey(string p)
            {
                var idx = -1;
                for (int i = 0; i <= Count; i++)
                {
                    if (this[i].Name == p)
                    {
                        idx = i;
                        break;
                    }
                }
                return idx;
            }

            public void RemoveByKey(string p)
            {
                throw new NotImplementedException();
            }

            public void CopyTo(Array array, int index)
            {
                throw new NotImplementedException();
            }

        }

        [DefaultValue("")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual string ToolTipText { get; set; }

        [DefaultValue(null)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual string ToolTipTitle { get; set; }

        [DefaultValue(false)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual bool InToolTipManager { get; set; }

        [DefaultValue(null)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual Size MinimumSize { get; set; }


        [DefaultValue(AnchorStyles.None)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual AnchorStyles Anchor { get; set; }

        [DefaultValue(false)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual bool Focused { get; set; }

        [StateManagement(StateManagementValues.ServerOnly)]
        public Size PreferredSize
        {
            get { return GetPreferredSize(Size.Empty); }
        }

        [DefaultValue(null)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual Padding Margin { get; set; }

        [StateManagement(StateManagementValues.ServerOnly)]
        public virtual ControlBindingsCollection DataBindings { get; set; }

        [StateManagement(StateManagementValues.ServerOnly)]
        public UpgradeHelpers.Helpers.Region Region { get; set; }

        public Graphics CreateGraphics()
        {
            return Graphics.FromHwnd(new IntPtr());
        }

        public UpgradeHelpers.Helpers.Point PointToScreen(Point point)
        {
            throw new NotImplementedException();
        }

        public Point PointToClient(object p)
        {
            throw new NotImplementedException();
        }

        public object Invoke(Delegate method, params object[] args)
        {
            return this.BeginInvoke(method, args);
        }

        public void Select()
        {

        }

        public void DeselectAll()
        {

        }

        [StateManagement(StateManagementValues.None)]
        public EventHandler TextChanged { get; set; }


        [DefaultValue(true)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual bool TabStop { get; set; }

        public virtual UpgradeHelpers.Helpers.ControlViewModel GetNextControl(IControl startCtrl, bool p) //IControl 
        {
            if (this.Controls != null)
            {
                int index = this.Controls.IndexOf((ControlViewModel)startCtrl);

                if (index != -1)
                {
                    if (p)
                    {
                        index++;

                        if (index > this.Controls.Count - 1)
                        {
                            return null;
                        }
                        else
                        {
                            return this.Controls[index];
                        }
                    }
                    else
                    {
                        index--;

                        if (index < 0)
                        {
                            return null;
                        }
                        else
                        {
                            return this.Controls[index];
                        }
                    }
                }

                return null;

            }

            return null;

        }

        /// <summary>
        /// Temporarily suspends the layout logic for the control.
        /// Added by compatibility purposes because webmap doesn't support SuspendLayout method
        /// </summary>
        /// <maps>SuspendLayout</maps>
        public void SuspendLayout()
        {
             throw new NotImplementedException();
        }

        /// <summary>
        /// Resumes usual layout logic.
        /// Added by compatibility purposes because webmap doesn't support ResumeLayout method
        /// </summary>
        /// <maps>ResumeLayout</maps>
        public void ResumeLayout() { }

        /// <summary>
        /// Resumes usual layout logic, optionally forcing an immediate layout of pending layout requests.
        /// Added by compatibility purposes because webmap doesn't support ResumeLayout method
        /// </summary>
        /// <param name="performLayout"> true to execute pending layout requests; otherwise, false.</param>
        /// <maps>ResumeLayout</maps>
        public void ResumeLayout(bool performLayout)
        {
             throw new NotImplementedException();
        }

        /// <summary>
        /// Forces the control to apply layout logic to all its child controls.
        /// Added by compatibility purposes because webmap doesn't support PerformLayout method
        /// </summary>
        /// <maps>PerformLayout</maps>
        public void PerformLayout() { }

        [StateManagement(StateManagementValues.ServerOnly)]
        public UpgradeHelpers.Interfaces.ISite Site { get; set; }

        public static bool CheckForIllegalCrossThreadCalls { get; set; }

        public ControlViewModel GetChildAtPoint(Point point, GetChildAtPointSkip skip) //IControl
        {
            throw new NotImplementedException();
        }
        public ControlViewModel GetChildAtPoint(Point point)//IControl
        {
            throw new NotImplementedException();
        }

        [StateManagement(StateManagementValues.ServerOnly)]
        public bool AllowEmpty { get; set; }

        /// <summary>
        /// Occurs when the control is clicked. Added for compatibility purposes because in webmap's
        /// architecture is not longer needed
        /// </summary>
        [StateManagement(StateManagementValues.None)]
        public virtual EventHandler Click { get; set; }

        //public virtual ContextMenu ContextMenu { get; set; }

        [StateManagement(StateManagementValues.None)]
        public EventHandler SizeChanged { get; set; }

        [StateManagement(StateManagementValues.None)]
        public EventHandler Resize { get; set; }

        [StateManagement(StateManagementValues.None)]
        public EventHandler Move { get; set; }




        public Rectangle Get_ClientRectangle()
        {
            return new Rectangle();
        }

        public Rectangle RectangleToScreen(Rectangle rectangle)
        {
            throw new NotImplementedException();
        }

        public Rectangle RectangleToScreen(object p)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnPaint(PaintEventArgs e) { throw new NotImplementedException(); }


        [StateManagement(StateManagementValues.None)]
        [DefaultValue(false)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual bool HasChildren {
            set
            {

            }
            get
            {
                return this.GetControlsIterator().Count() > 0;
            }
        }

    
        [DefaultValue(null)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual UpgradeHelpers.Helpers.Size MaximumSize { get; set; }



        [DefaultValue("")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual string TooltipText { get; set; }

        public override void Build(IIocContainer ctx)
        {
            base.Build(ctx);
            this.ToolTipText = "";
            this.TabStop = true;
            this.TabIndex = 0;
            this.Name = string.Empty;
            this.Size = new UpgradeHelpers.Helpers.Size(0, 0);
            this.DisplayRectangle = new Rectangle();
            this.DataBindings = ctx.Resolve<ControlBindingsCollection>();
        }

        public void CreateRegion()
        {
            throw new NotImplementedException();
        }

        public void CreatePensBrushes()
        {
            throw new NotImplementedException();
        }

        public void DisposePensBrushes()
        {
            //throw new NotImplementedException();//,MOBILIZE,09/08/2016,TODO,FGM,"MANUALLY CHANGED","DISPOSE ERROR ON CREATE VOID"
        }

        protected virtual void OnParentChanged(EventArgs e)
        {
            throw new NotImplementedException();
        }

        public object GetSubItem(int expandCollapseColumn)
        {
            throw new NotImplementedException();
        }

        public void Show()
        {
            this.Visible = true;
        }

        [DefaultValue(false)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool ShowFocusCues { get; set; }

        protected virtual void OnSizeChanged(EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected virtual CreateParams CreateParams { get; set; }

        public static Point MousePosition
        {
            get
            {
                return new Point(0, 0);// throw new NotImplementedException();
            }
        }

        public static Color DefaultBackColor { get; set; }

        [StateManagement(StateManagementValues.ServerOnly)]
        [DefaultValue(false)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool ContainsFocus { get; set; }

        public bool SetVisible(Boolean visible)
        {
            this.Visible = visible;
            return visible;
        }

        public void ResetText()
        {
            this.Text = string.Empty;
        }

        protected virtual void OnTextChanged(EventArgs e)
        {
            ViewManager.Events.Publish("TEXTCHANGED", this, new object[] { this, e });
        }

        protected virtual void OnSelectedIndexChanged(EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnMouseUp(MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnMouseMove(MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnDragOver(DragEventArgs drgevent)
        {
            throw new NotImplementedException();
        }

        protected virtual bool ProcessMnemonic(char charCode)
        {
            return false;
        }

        //protected virtual bool ProcessDialogKey(UpgradeHelpers.Helpers.Keys keyData)
        //{
        //    return false;
        //}

        protected virtual bool ProcessTabKey(bool forward)
        {
            return false;
        }

        protected virtual void OnDrawItem(UpgradeHelpers.Events.MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        //protected virtual void OnKeyPress(UpgradeHelpers.Events.KeyPressEventArgs kpea)
        //{
        //    throw new NotImplementedException();
        //}

        protected virtual void OnMouseLeave(EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnMouseEnter(EventArgs e)
        {
            throw new NotImplementedException();
        }

        //public virtual void OnMouseDown(MouseEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        protected virtual void OnLeave(EventArgs e)
        {
            throw new NotImplementedException();
        }

        //protected virtual void OnKeyUp(KeyEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        public UpgradeHelpers.Events.KeyEventHandler KeyUp { get; set; }

        protected virtual void OnKeyDown(KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnEnter(EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnClick(EventArgs e)
        {
            throw new NotImplementedException();
        }
        protected virtual void OnDoubleClick(EventArgs e)
        {
        }

        protected virtual void OnSelectionChanged(EventArgs e)
        {
        }

        [StateManagement(StateManagementValues.ServerOnly)]
        [DefaultValue(false)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool CanSelect { get; set; }

        public IAsyncResult BeginInvoke(Delegate method)
        {
            throw new NotImplementedException();
        }
        public IAsyncResult BeginInvoke(Delegate method, params Object[] args)
        {
            method.Method.Invoke(method.Target, args);
            return null;
        }

        public UpgradeHelpers.Events.CancelEventHandler Validating { get; set; }

        public DragDropEffects DoDragDrop(DragDropEffects dragDropEffects)
        {
            throw new NotImplementedException();
        }
        public UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel> FindForm()
        {
            // throw new NotImplementedException();
            return null; // MOBILIZE.KMM pending PME
        }
        //public void OnDragDrop(DragEventArgs drgevent)
        //{
        //    throw new NotImplementedException();
        //}
        //public void OnDragEnter(DragEventArgs drgevent)
        //{
        //    UpgradeHelpers.Extensions.IControlExtensions.OnDragEnter(this, drgevent);
        //}
        //public void OnDragLeave(EventArgs drgevent)
        //{
        //    throw new NotImplementedException();
        //}
        //protected virtual void OnLostFocus(EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}
        //public void OnMouseDown(EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //protected virtual void OnMouseClick(EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //public void OnQueryContinueDrag(QueryContinueDragEventArgs qcdevent)
        //{
        //    throw new NotImplementedException();
        //}
        protected override void OnValidating(UpgradeHelpers.Events.CancelEventArgs e)
        {
            UpgradeHelpers.Extensions.IControlExtensions.OnValidating(this, e);
        }
        protected virtual void WndProc(ref Message o)
        {
            UpgradeHelpers.Extensions.IControlExtensions.WndProc(o);
        }

        public virtual bool Focus()
        {
            this.Focused = true;
            return this.Focused;
        }

        //todo not used public virtual bool setFocus { get; set; }
        [StateManagement(StateManagementValues.ServerOnly)]
        public virtual bool AllowDrop { get; set; }
        [StateManagement(StateManagementValues.None)]
        public DragEventHandler DragDrop { get; set; }

        /// <summary>
        /// Gets or sets the name of the control used by accessibility client applications.
        /// </summary>
        /// <maps><get/><set/></maps> 
        [StateManagement(StateManagementValues.None, Why: "Property is assigned but never used")]
        public string AccessibleName { get; set; }
        [StateManagement(StateManagementValues.None, Why: "Property is assigned but never used")]
        public string AccessibleDescription { get; set; }

        /// <summary>
        /// Gets or sets the accessible role of the control
        /// </summary>
        /// <maps><get/><set/></maps> 
        [StateManagement(StateManagementValues.None, Why: "Property is assigned but never used")]
        public AccessibleRole AccessibleRole { get; set; }

        [StateManagement(StateManagementValues.None, Why: "Property is assigned but never used")]
        public ImeMode ImeMode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use the wait cursor for the current control and all child controls.
        /// </summary>
        /// <maps><get/><set/></maps>
        [StateManagement(StateManagementValues.None, Why: "Property is assigned but never used")]
        public bool UseWaitCursor { get; set; }

        [StateManagement(StateManagementValues.None, Why: "Property is assigned but never used")]
        public virtual Point AutoScrollOffset { get; set; }

        [StateManagement(StateManagementValues.ServerOnly)]
        [DefaultValue(ImageLayout.None)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual ImageLayout BackgroundImageLayout { get; set; }

        [StateManagement(StateManagementValues.ServerOnly)]
        [DefaultValue(null)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual BindingContext BindingContext { get; set; }

        [DefaultValue(null)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual String BackgroundImage { get; set; }

        [StateManagement(StateManagementValues.ServerOnly)]
        [DefaultValue(false)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool CausesValidation { get; set; }

        public DialogResult ShowDialog()
        {
            throw new NotImplementedException();
        }
        public override void Refresh()
        {
            ViewManager.Events.Publish("PAINT", this as IStateObject, new object[] { this, null });

            var parent = this.ViewManager.GetParent(this as IStateObject);
            ControlViewModel ctrlToIterate;

            if (parent != null)
            {
                var iterator = parent as IControlContainerIterator;
                ctrlToIterate = this;
                if (iterator == null)
                {
                    iterator = this as IControlContainerIterator;
                    ctrlToIterate = null;
                }

                if (iterator == null) return;

                foreach (ControlViewModel childControl in iterator.GetControlsIterator(ctrlToIterate))
                {
                    if (childControl != null)
                    {
                        childControl.Refresh();
                    }
                }
            }
        }

        public virtual void Update()
        {


        }

        protected virtual void InvokePaint(ControlViewModel c, PaintEventArgs e)
        {
            // throw new NotImplementedException();
        }

        protected virtual void InvokePaintBackground(ControlViewModel c, PaintEventArgs e)
        {
            // throw new NotImplementedException();
        }

        protected virtual void DefWndProc(ref Message m)
        {
            // throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves a value indicating whether the specified control is a child of the control.
        /// </summary>
        /// 
        /// <returns>
        /// true if the specified control is a child of the control; otherwise, false.
        /// </returns>
        /// <param name="ctl">The <see cref="T:System.Windows.Forms.Control"/> to evaluate. </param><filterpriority>1</filterpriority>
        public bool Contains(ControlViewModel ctl)
        {
            while (ctl != null)
            {
                ctl = ctl.Parent;
                if (ctl == null)
                    return false;
                if (ctl == this)
                    return true;
            }
            return false;
        }

        //
        // Summary:
        //     Gets a value indicating whether the control can receive focus.
        //
        // Returns:
        //     true if the control can receive focus; otherwise, false.
        [StateManagement(StateManagementValues.ServerOnly)]
        [DefaultValue(false)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual bool _canFocus { get; set; }
        [StateManagement(StateManagementValues.None)]
        public bool CanFocus
        {
            get
            {
                if (this.Visible && this.Enabled)
                    this._canFocus = true;
                return this._canFocus;
            }
        }

        protected void SetStyle(ControlStyles flag, bool value)
        {

        }
        protected void UpdateStyles() { }


        protected virtual void InitLayout()
        {
            throw new NotImplementedException();
        }

        public virtual Size GetPreferredSize(Size proposedSize)
        {
            return proposedSize;
        }

        protected virtual Size DefaultMinimumSize
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected virtual Size DefaultSize
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected static AutoValidate GetAutoValidateForControl(ControlViewModel controlToValidate)
        {
            return AutoValidate.EnableAllowFocusChange; //KMASIS
        }

        internal bool IsDescendant(ControlViewModel unvalidatedControl)
        {
            throw new NotImplementedException();
        }

        [StateManagement(StateManagementValues.ServerOnly)]
        [DefaultValue(false)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool ValidationCancelled { get; set; }

        internal bool PerformControlValidation(bool p)
        {
            throw new NotImplementedException();
        }

        [StateManagement(StateManagementValues.ServerOnly)]
        public ControlViewModel ParentInternal { get; set; }

        internal void NotifyValidationResult(ControlViewModel currentValidatingControl, System.ComponentModel.CancelEventArgs ev)
        {
            throw new NotImplementedException();
        }

		internal ContainerControl GetContainerControlInternal()
		{
			throw new NotImplementedException();
		}

		protected virtual void OnResize(EventArgs e) { }


        protected override void Dispose(bool disposing)
        {
            if (this.Parent != null && Parent.Controls != null)
            {
                Parent.Controls.Remove(this);
                _parent = null;
            }

            base.Dispose(disposing);
        }
    }

    public static class UserControlExtensions
    {
        public static Point PointToClient(this IUserControl instance, object p)
        {
            return default(Point);
        }
        public static void BeginInvoke(this IUserControl instance, object p, object p1)
        {
        }
        public static void BeginInvoke(this IUserControl instance, object p)
        {
        }

        public static bool HasFocusableChild(this IUserControl userControl)
        {
            ControlViewModel ctl = null;
            do
            {
                ctl = ((ControlViewModel)userControl).GetNextControl(ctl, true);
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