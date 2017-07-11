using System;

namespace UpgradeHelpers.Helpers
{
	public class ImageAttributes
    {

        public void SetColorMatrix(object colorMatrix, ColorMatrixFlag colorMatrixFlag, ColorAdjustType colorAdjustType)
        {
            throw new NotImplementedException();
        }

        public void SetRemapTable(ColorMap[] map)
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
