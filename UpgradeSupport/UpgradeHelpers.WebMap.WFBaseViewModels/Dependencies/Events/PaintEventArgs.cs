using System;
using UpgradeHelpers.Helpers;

namespace UpgradeHelpers.Events
{
    public class PaintEventArgs : EventArgs, IDisposable
    {
        private Graphics graphics;
        private readonly Rectangle clipRect;

        public PaintEventArgs(Graphics graphics, Rectangle clipRect)
        {
            if (graphics == null)
                throw new ArgumentNullException("graphics");
            this.graphics = graphics;
            this.clipRect = clipRect;
        }
		public PaintEventArgs()
		{

		}


        public Graphics Graphics
        {
            get
            {
                return this.graphics;
            }
        }

        public Rectangle ClipRectangle { get; set; }

        public void Dispose()
        {
            /*Dispose method has no implementation*/
	        System.Diagnostics.Debugger.Break();
		}
    }
}