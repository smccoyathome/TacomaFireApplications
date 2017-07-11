using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeHelpers.WebMap.Server.Common
{
    public static class TraceUtil
    {
        public static void TraceInformation(string format, params object[] args)
        {
#if TraceOutput
            Trace.TraceInformation(format, args);
#endif
        }

        public static void TraceInformation(string str)
        {
#if TraceOutput
            Trace.TraceInformation(str);
#endif
        }

        public static void TraceError(string format, params object[] args)
        {
#if TraceOutput
            Trace.TraceError(format, args);
#endif
        }

        public static void TraceError(string str)
        {
#if TraceOutput
            Trace.TraceError(str);
#endif
        }

		public static void TraceWarning(string format, params object[] args)
		{
#if TraceOutput
            Trace.TraceWarning(format, args);
#endif
		}

        public static void WriteLine(string str)
        {
#if TraceOutput
            Trace.WriteLine(str);
#endif
        }

        public static void WriteLine(string str, params object[] args)
        {
#if TraceOutput
            Trace.WriteLine(str, args);
#endif
        }
    }
}
