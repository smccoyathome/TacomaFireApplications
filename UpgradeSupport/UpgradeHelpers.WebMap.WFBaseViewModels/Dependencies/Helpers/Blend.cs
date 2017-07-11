﻿namespace UpgradeHelpers.Helpers
{
	public class Blend
    {
        private float[] factors;
        private float[] positions;

        public float[] Factors
        {
            get
            {
                return this.factors;
            }
            set
            {
                this.factors = value;
            }
        }

        public float[] Positions
        {
            get
            {
                return this.positions;
            }
            set
            {
                this.positions = value;
            }
        }

        public Blend()
        {
            this.factors = new float[1];
            this.positions = new float[1];
        }

        public Blend(int count)
        {
            this.factors = new float[count];
            this.positions = new float[count];
        }
    }
}
