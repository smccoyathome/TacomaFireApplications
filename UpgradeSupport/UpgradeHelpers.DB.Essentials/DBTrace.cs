using System;
using System.Data.Common;

/// <summary>
/// 
/// </summary>
public static class DBTrace
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="conn"></param>
#if TargetF2 || TargetF35
    public static void OpenWithTrace(DbConnection conn)
#else
    public static void OpenWithTrace(this DbConnection conn)
#endif
    {
        conn.ConnectionString = NewConnectionstring(conn.ConnectionString);
#if DBTrace
		File.AppendAllText(LogDBTrace, "Openning connection [" + conn.ConnectionString + "] " + new System.Diagnostics.StackTrace().ToString());
#endif
        conn.Open();
    }

    /// <summary>
    /// CreateConnectionWithTrace
    /// </summary>
    /// <param name="factory"></param>
    /// <returns></returns>
#if TargetF2 || TargetF35
    public static DbConnection CreateConnectionWithTrace(DbProviderFactory factory)
#else
    public static DbConnection CreateConnectionWithTrace(this DbProviderFactory factory)
#endif
    {
#if DBTrace
		File.AppendAllText(LogDBTrace, "Creating connection " + new System.Diagnostics.StackTrace().ToString());
#endif
        return factory.CreateConnection();

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="connectionString"></param>
    /// <returns></returns>
    public static string NewConnectionstring(String connectionString)
    {
#if ConnectionPoolOff
		if (!connectionString.Contains("Pooling="))
		{
			if (connectionString.EndsWith(";"))
			{
				connectionString += "Pooling=false;";
			}
			else
			{
				connectionString += ";Pooling=false;";
			}
		}
		return connectionString;
#else
        return connectionString;
#endif

    }

}

