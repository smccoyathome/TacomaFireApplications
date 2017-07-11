using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Collections;
using System.IO;

namespace UpgradeHelpers.WebMap.Server
{

        [JsonConverter(typeof(AppChangesResponse))]
		internal class AppChangesResponse : JsonConverter
        {
#if DEBUG
			public static bool CollectStats;

			 
			public static void TurnOnStatistics()
			{
				CollectStats = true;
			}

			public static void TurnOffStatistics()
			{
				CollectStats = false;
			}

#endif
            public ViewsStateDelta VD;
            public IList           MD;
            public int[]           MDT;
            public string[]        RM;
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string[][]      SW;
			public string		   NV;
#if DEBUG
			class SerializationStatisticsDetail
			{
				public long count;
				public long TotalSentPerType;
                public long ellapsedTotalTime;
			}

			class SerializationStatistics
			{
				Dictionary<Type, SerializationStatisticsDetail> info = new Dictionary<Type, SerializationStatisticsDetail>();
				int totalSize;
                long totalTime;
				public void Register(object obj,string jsonpayload,long ellapsedMilliseconds)
				{
					var type = obj.GetType();
					if (type.Assembly.IsDynamic)
					{
						type = type.BaseType;
					}
					SerializationStatisticsDetail detail;
					if (!info.TryGetValue(type, out detail))
					{
						info.Add(type, detail = new SerializationStatisticsDetail());
					}
					detail.count++;
					totalSize += jsonpayload.Length;
                    totalTime += ellapsedMilliseconds;
                    detail.ellapsedTotalTime += ellapsedMilliseconds;
					detail.TotalSentPerType += jsonpayload.Length;
				}


				public void DumpStats()
				{
					if (totalSize == 0) totalSize = 1;

                    Debug.WriteLine("========================= Request Response Summary ===========================================================================================================================================================================");
                    Debug.WriteLine("          |Type Name                                                                                           |Count     |Avg Size(chars)     |Percentage          |Avg Time ms    |Total Size          |Total Time");
					foreach (var entry in info)
					{
						var fullName = entry.Key.FullName;
                        fullName = fullName.Replace("Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "V1");
                        fullName = fullName.Replace("Version=11.410.0.0, Culture=neutral, PublicKeyToken=null", "V11");
                        fullName = fullName.Replace("Version=4.0.0.0, Culture=neutral, PublicKeyToken=", "VKey=");
                        fullName = fullName.Replace("Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", "VKey");

						if (fullName.Length > 100)
						{
                            fullName = fullName.Replace("Allscripts.TouchWorks.Workspace", "A.T.W");
                            fullName = fullName.Replace("Allscripts.TouchWorks.Common", "A.T.C");
                            fullName = fullName.Replace("UpgradeHelpers.WebMap.Server", "U.W.S");
                            fullName = fullName.Replace("UpgradeHelpers.WebMap.BasicViewModels", "U.W.B");
                            fullName = fullName.Replace("UpgradeHelpers.Helpers", "U.H");
                            fullName = fullName.Replace("UpgradeHelpers.Interfaces", "U.I");
						}
                        Debug.WriteLine(string.Format("{0,-10}|{1,100}|{2,10}|{3,20}|{4,20}|{5,15}|{6,20}|{7,20}", "))))))", fullName, entry.Value.count, (entry.Value.TotalSentPerType / entry.Value.count), (entry.Value.TotalSentPerType * 100 / totalSize), (entry.Value.ellapsedTotalTime / entry.Value.count), entry.Value.TotalSentPerType, entry.Value.ellapsedTotalTime));
					}
                    Debug.WriteLine("=============================================================================================================================================================================================================================");
                    Debug.WriteLine("Total bytes sent " + totalSize + " total time " + totalTime);

				}
			}
#endif
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                
                var st = new Stopwatch();
                st.Start();

#if DEBUG
                SerializationStatistics stats = null;
#endif

                AppChangesResponse response = (AppChangesResponse)value;
                writer.WriteStartObject();
                writer.WritePropertyName("MDT");
                serializer.Serialize(writer,response.MDT);
				writer.WritePropertyName("NV");
				serializer.Serialize(writer, response.NV);
                writer.Flush();
                writer.WritePropertyName("MD");
                writer.WriteStartArray();
                for (int i = 0; i < response.MD.Count; i++)
                {
#if DEBUG
					if (CollectStats)
					{
						var stringWriter = new StringWriter();
						var obj = response.MD[i];
                        st.Reset();
                        st.Start();
						serializer.Serialize(stringWriter, response.MD[i]);
						var result = stringWriter.ToString();
                        writer.WriteRawValue(result);
                        st.Stop();
						stats = stats ?? new SerializationStatistics();
                        stats.Register(response.MD[i], result, st.ElapsedMilliseconds);
					}
					else
					{
#endif
                        serializer.Serialize(writer, response.MD[i]);
#if DEBUG
				}
#endif
                    writer.Flush();

                }
                writer.WriteEndArray();

                writer.WritePropertyName("VD");
                serializer.Serialize(writer, response.VD);
                writer.WritePropertyName("RM");
                serializer.Serialize(writer, response.RM);
                if (response.SW != null)
                {
                    writer.WritePropertyName("SW");
                    serializer.Serialize(writer, response.SW);
                }
                writer.WriteEndObject();
                writer.Flush();
#if DEBUG
				if (CollectStats && stats != null)
					stats.DumpStats();
#endif
                st.Stop();
                System.Diagnostics.Trace.TraceInformation(">>>>>>>>>>>>>>>>> REQUEST RESPONSE Serialization time " + st.ElapsedMilliseconds);

            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }

            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(AppChangesResponse);
            }
        }
}