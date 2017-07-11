using System;

namespace UpgradeHelpers.Helpers
{
	public class SetterBase
    {

        public bool IsSealed
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected void CheckSealed() { throw new NotImplementedException(); }
    }
}
