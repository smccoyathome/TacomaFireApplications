using System;
using UpgradeHelpers.WebMap.Server;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Linq;

namespace UpgradeHelpers.WebMap.Server
{
    public static class DebugUtils
    {
        static string HELPERS_NAMESPACE = typeof(DebugUtils).Namespace.Split('.').First();
        public static string GetUserCodeInfo(StackTrace st)
        {

            var frames = st.GetFrames();
            int frameIndex = -1;
            for (int i = 0; i < frames.Length; i++)
            {
                var method = frames[i];
                if (method!=null)
                {
                    var nmspace = method.GetMethod().DeclaringType.Namespace;
					if (nmspace.StartsWith(HELPERS_NAMESPACE,StringComparison.Ordinal))
					{
                        continue;
                    }
                    else
                    {
                        frameIndex = i;
                        break;
                    }
                }
            }
            if (frameIndex != -1)
            {
                var frame = frames[frameIndex];
                var res = string.Format(" file {0}, line {1}, column {2}", frame.GetFileName(), frame.GetFileLineNumber(), frame.GetFileColumnNumber());
                if (frameIndex > 0)
                {
                    var previousframe = frames[frameIndex-1];
                    if (previousframe.GetMethod().Name.Equals("Then"))
                    {
                        res = string.Format(" Then call at file {0}, line {1}, column {2}", frame.GetFileName(), frame.GetFileLineNumber(), frame.GetFileColumnNumber());
                    }
                }
                return res;
            }
            else return " unknown location ";
        }

    }

}
namespace UpgradeHelpers.WebMap.Server.DebugEx
{

#if (WEBMAPVS2013 || WEBMAPVS2015) && DEBUG
	using Microsoft.VisualStudio.DebuggerVisualizers;
	using EnvDTE;
	public class PromiseDebugVisualizer : DialogDebuggerVisualizer
	{
		protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
		{

			string text = new StreamReader(objectProvider.GetData()).ReadLine();
			if (!String.IsNullOrWhiteSpace(text))
			{

				// Get an instance of the currently running Visual Studio IDE.
				EnvDTE80.DTE2 dte;
#if WEBMAPVS2013
				dte = (EnvDTE80.DTE2)System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.12.0");
#else
				dte = (EnvDTE80.DTE2)System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.14.0");
#endif

				var info = text.Split(',');
				if (info.Length == 3)
				{

					var fileIndex = info[0].IndexOf("file") + 5;
					var lineIndex = info[1].IndexOf("line") + 5;
					var filename = info[0].Substring(fileIndex);
					var line = info[1].Substring(lineIndex);
					dte.ExecuteCommand("File.OpenFile", filename);
					dte.ExecuteCommand("Edit.GoTo", line);

				}
			}
		}
	}

#endif
			}