using System;

namespace UpgradeHelpers.Helpers
{
    public abstract class FontCollection : IDisposable
    {
        internal IntPtr nativeFontCollection;

        public FontFamily[] Families
        {
            get
            {
                return new FontFamily[] {};
            }
        }

        public FontCollection()
        {
            this.nativeFontCollection = IntPtr.Zero;
        }

        ~FontCollection()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize((object)this);
        }

        protected virtual void Dispose( bool disposing)
        {
        }
    }
}
