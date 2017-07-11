using System;
using System.Web;

internal static class WebMapMVCUtils
{
    internal static System.IO.TextReader DefaultJsonProviderFromPOST()
    {
        //If not read the json appchanges from the Request
        var context = HttpContext.Current;
        //It must be an Ajax Call
        if (context != null && context.Request.ContentType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase))
        {
            //But not any Ajax call. Only a call with an special header
            string wmHeader = context.Request.Headers["WM"];
            if (wmHeader != null)
            {
                System.IO.Stream inputStream = context.Request.InputStream;
                // get a generic stream reader (get reader for the http stream)
                return new System.IO.StreamReader(inputStream);
                // convert stream reader to a JSON Text Reader
            }
        }
        return null;
    }
}