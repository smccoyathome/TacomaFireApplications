using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace UpgradeHelpers.Helpers
{
    public class ColorMatrix
    {
        private float[][] ptsArray;

        public ColorMatrix(float[][] ptsArray)
        {
            // TODO: Complete member initialization
            this.ptsArray = ptsArray;
        }

        public ColorMatrix()
        {
            // TODO: Complete member initialization
        }

        public void SetColorMatrix(ColorMatrix colorMatrix, ColorMatrixFlag colorMatrixFlag, ColorAdjustType colorAdjustType)
        {
            throw new NotImplementedException();
        }
    }
}
