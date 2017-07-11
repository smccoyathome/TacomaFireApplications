

using System;
namespace UpgradeHelpers.Helpers
{
    public class Region : MarshalByRefObject, IDisposable
    {
        private Rectangle elapsedRect;

        public Region()
        {

        }

        public Region Clone()
        {
            throw new System.NotImplementedException();
        }
        public void Dispose() { }

        public Region(GraphicsPath path) {
            throw new System.NotImplementedException();
        }
        public Region(Rectangle elapsedRect)
        {
            // TODO: Complete member initialization
            this.elapsedRect = elapsedRect;
        }
        public object GetBounds(Graphics graphics)
        {
            throw new System.NotImplementedException();
        }

        public void Exclude(GraphicsPath thumbPath)
        {
            throw new System.NotImplementedException();
        }

    }
}