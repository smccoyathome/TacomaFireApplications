using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server.Common
{
    public class ObjectWatcher : IDeltaWatcher
    {
        public byte[] GetAsBytes(object obj)
        {
            var res = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            using (MemoryStream ms = new MemoryStream())
            {
                var sw = new StreamWriter(ms);
                sw.Write(res);
                sw.Flush();
                return ms.ToArray();
            }
        }
    }
}
