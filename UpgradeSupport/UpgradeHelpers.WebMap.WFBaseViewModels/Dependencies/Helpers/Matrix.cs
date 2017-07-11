using System;

namespace UpgradeHelpers.Helpers
{
	public sealed class Matrix : IDisposable
    {
        private float p1;
        private int p2;
        private int p3;
        private float p4;
        private float p5;
        private float p6;

        public Matrix(float p1, int p2, int p3, float p4, float p5, float p6)
        {
            // TODO: Complete member initialization
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.p4 = p4;
            this.p5 = p5;
            this.p6 = p6;
        }

        public Matrix()
        {
            // TODO: Complete member initialization
        }

        public void Translate(int p1, int p2)
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
