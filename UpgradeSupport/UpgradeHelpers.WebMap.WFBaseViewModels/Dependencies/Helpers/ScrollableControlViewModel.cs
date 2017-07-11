using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using UpgradeHelpers.Interfaces;
using Newtonsoft.Json;

namespace UpgradeHelpers.Helpers
{
	public class ScrollableControlViewModel : ControlViewModel
    {
        private int scrollState;
        private int clientWidth;
        private int clientHeight;
        public override void Build(IIocContainer ctx)
        {
            base.Build(ctx);
            AutoScrollPosition = new Point(0, 0);
            AutoScrollMargin = new Size(0, 0);

        }
      
        [UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
        public virtual int VerticalScroll
        {
            get
            {
                return Y;
            }
            set
            {
                Y = value;
                AutoScrollPosition = new UpgradeHelpers.Helpers.Point(0, Y);
            }
        }
        public int Y { get; set; }
        [DefaultValue(null)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual string ScrollToElemID { get; set; }
       

        [DefaultValue(false)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual bool AutoScroll { get; set; }


        protected void SetScrollState(int bit, bool value)
        {
            if (value)
                this.scrollState |= bit;
            else
                this.scrollState &= ~bit;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SystemParametersInfo(int nAction, int nParam, ref int value, int ignore);

        internal static bool DragFullWindows
        {
            get
            {
                int num = 0;
                SystemParametersInfo(38, 0, ref num, 0);
                return num != 0;
            }
        }

        protected override void OnMouseWheel(UpgradeHelpers.Events.MouseEventArgs e)
        {

        }

        public void ScrollControlIntoView(ControlViewModel activeControl)
        {
            if ( !this.AutoScroll )
                    return;
            if (activeControl.UniqueID != "" && activeControl.UniqueID.Split('#').Length > 0)
            {
                this.ScrollToElemID = activeControl.UniqueID.Split('#')[0];
            }
            //Rectangle clientRectangle = this.ClientRectangle;
            //if (!this.IsDescendant(activeControl) || !this.AutoScroll || !this.HScroll && !this.VScroll || (activeControl == null || clientRectangle.Width <= 0 || clientRectangle.Height <= 0))
            //    return;
            //Point point = this.ScrollToControl(activeControl);
            //this.SetScrollState(8, false);
            //this.SetDisplayRectLocation(point.X, point.Y);
            //this.SyncScrollbars(true);
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [StateManagement(StateManagementValues.ServerOnly)]
        public Rectangle ClientRectangle
        {
            get
            {
                //return new Rectangle(0, 0, this.clientWidth, this.clientHeight);
                return new Rectangle(0, 0, this.Size.Width, this.Size.Width);
            }
        }

        protected virtual Point ScrollToControl(ControlViewModel activeControl)
        {
            throw new NotImplementedException();
        }



        [StateManagement(StateManagementValues.ClientOnly)]
        public virtual Point AutoScrollPosition { 
            get { return _autoScrollPosition; } 
            set { 
                _autoScrollPosition = value;
                scrollPositionChange = true;
            } }

        [StateManagement(StateManagementValues.ServerOnly)]
        public virtual Point _autoScrollPosition { get; set; }

        [DefaultValue(false)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual bool scrollPositionChange { get; set; }

        [DefaultValue(null)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual Size AutoScrollMargin { get; set; }

        [StateManagement(StateManagementValues.ServerOnly)]
        [DefaultValue(null)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual Size AutoScrollMinSize { get; set; }

        protected virtual void OnScroll(UpgradeHelpers.Events.ScrollEventArgs se) { }
    }
}
