using System;

namespace UpgradeHelpers.Helpers
{
	public class Brush : IDisposable
    {
        private Color color;

        public Brush(Color color)
        {
            // TODO: Complete member initialization
            this.color = color;
        }
        public Brush()
        {

        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
