using System;
using System.Diagnostics;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Server;

namespace UpgradeHelpers.WebMap.Surrogates.BasicSurrogates
{
    public class BasicSurrogates : ISurrogateRegistration
    {
        public void Register()
        {
            Debug.WriteLine("BasicSurrogate Registration Start");
            AssemblySurrogate.RegisterForAssembly();
            SurrogateForConnection.RegisterForConnection();
            DataCommandSurrogate.RegisterSurrogateForCommand();
            DataSetSurrogate.RegisterSurrogateForDataset();
            DataTableSurrogate.RegisterSurrogateForDataTable();
            DataViewSurrogate.RegisterSurrogateForDataView();
            DataRowViewSurrogate.RegisterSurrogateForDataRowView();
            DataRowSurrogate.RegisterSurrogateForDataRow();
            XmlElementSurrogate.RegisterSurrogateForXmlElement();
            XmlNodeSurrogate.RegisterSurrogateForXmlNode();
            XmlDocumentSurrogate.RegisterSurrogateForXmlDocument();
            Debug.WriteLine("BasicSurrogate Registration End");
        }
    }
}
