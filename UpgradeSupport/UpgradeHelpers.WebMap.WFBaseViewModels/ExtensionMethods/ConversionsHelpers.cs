using System;


namespace UpgradeHelpers.Extensions
{
    public static class ConversionsHelpers
    {
        public static int ToInt(this object obj)
        {
            return Convert.ToInt32(Convert.ToDouble(obj));
        }

        public static bool IsNumeric(this object obj)
        {
            if (obj != null)
            {
                double result;
                var wasNumeric = Double.TryParse("" + obj, out result);
                return wasNumeric;
            }
            return false;
        }
    }
}
