using System;

namespace UpgradeHelpers.Helpers
{
	public class Metafile
    {
        private System.IO.MemoryStream _stream;
        private IntPtr _hdc;

        public Metafile(System.IO.MemoryStream _stream, IntPtr _hdc)
        {
            // TODO: Complete member initialization
            this._stream = _stream;
            this._hdc = _hdc;
        }

        public IntPtr GetHenhmetafile()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            /*Dispose method has no implementation*/
	        System.Diagnostics.Debugger.Break();
		}
    }
}
