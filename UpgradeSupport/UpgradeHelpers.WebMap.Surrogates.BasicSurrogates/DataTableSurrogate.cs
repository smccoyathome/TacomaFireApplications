using UpgradeHelpers.WebMap;
using Fasterflect;
using System.Collections.Generic;
using System;
using UpgradeHelpers.Interfaces;
using System.Data;
using SimmoTech.Utils.Data;
using System.IO;

namespace UpgradeHelpers.WebMap.Surrogates.BasicSurrogates
{
    public class DataTableSurrogate
    {
        static MemberGetter _objectIDGetter;
        static IList<object> NO_DATASET_DEPEMDENCY = new object[0];

        public static IList<object> CalculateDataTableDependency(object obj, ISurrogateDependenciesContext dependencyContext)
        {
            var dataTable = obj as DataTable;

            if (dataTable.DataSet != null)
            {
                return new object[] { dataTable.DataSet };
            }
            return NO_DATASET_DEPEMDENCY;
        }


        public static IList<object> CalculateDataTableEventsDependencies(object obj, ISurrogateDependenciesContext dependencyContext)
        {

            var dataTable = obj as DataTable;
            var result = new List<object>();

            //The event handlers are saved in the storage
            var rowChanging = dependencyContext.ProcessEventDelegate<DataTable>("onRowChangingDelegate", "RowChanging", dataTable);
            if (rowChanging != null)
                result.Add(rowChanging);

            var rowDeleting = dependencyContext.ProcessEventDelegate<DataTable>("onRowDeletingDelegate", "RowDeleting", dataTable);
            if (rowDeleting != null)
                result.Add(rowDeleting);

            var tableClearing = dependencyContext.ProcessEventDelegate<DataTable>("onTableClearingDelegate", "TableClearing", dataTable);
            if (tableClearing != null)
                result.Add(tableClearing);

            return result;

        }

        public static void SerializeDataTable(object obj, BinaryWriter binaryWriter, MemoryStream ms, ISurrogateContext context)
        {
            var dataTable = obj as DataTable;
            var dataSetSurrogateId = String.Empty;

            binaryWriter.Write(String.Empty);
            BinaryFastSerializer.SerializeDataTable(context, dataTable, ms);

        }

        public static object DeserializeDataTable(BinaryReader binaryReader, ISurrogateContext context)
        {
            var dataSetSurrogateId = binaryReader.ReadString();
            DataTable dataTable = null;

            dataTable = BinaryFastSerializer.DeserializeDataTable(context, binaryReader.BaseStream) as DataTable;

            if (context.DependencyCount != 0)
            {
                foreach (var dependency in context.Dependencies)
                {
                    var dataSet = dependency as DataSet;
                    if (dataSet != null)
                    {
                        if (dataSet.Tables.Contains(dataTable.TableName) && dataSet.Relations.Count == 0)
                        {
                            dataSet.Tables.Remove(dataTable.TableName);
                            dataSet.Tables.Add(dataTable);
                        }
                        else if (!dataSet.Tables.Contains(dataTable.TableName))
                            dataSet.Tables.Add(dataTable);
                    }
                    else
                    {
                        DeserializeDataTableEvents(context, dataTable, dependency);

                    }
                }
            }

            return dataTable;
        }

        public static void DeserializeDataTableEvents(ISurrogateContext context, DataTable dataTable, object dependency)
        {
            var eventInfo = dependency as ISurrogateEventsInfo;

            //Hook up the events delegates.
            switch (eventInfo.EventName.ToLower())
            {
                case "rowdeleting":
                case "rowchanging":
                    context.SubscribeEvent<DataRowChangeEventHandler>(eventInfo.EventId, eventInfo.EventName, dataTable);
                    break;
                case "tableclearing":
                    context.SubscribeEvent<DataTableClearEventHandler>(eventInfo.EventId, eventInfo.EventName, dataTable);
                    break;
            }
        }

        public static SurrogateDependencyCalculation[] CalculateDependencies = new SurrogateDependencyCalculation[] { CalculateDataTableDependency, CalculateDataTableEventsDependencies };


        public static bool IsValidDependency(object obj, string dependencyIdentifier)
        {
            bool result = false;
            var dataSet = obj as DataSet;
            var strComparer = Convert.ToString(dependencyIdentifier);

            foreach (var dataTable in dataSet.Tables)
            {
                if (_objectIDGetter == null)
                    _objectIDGetter = dataTable.GetType().DelegateForGetFieldValue("_objectID");

                if (Convert.ToString(_objectIDGetter(dataTable)).Equals(strComparer))
                {
                    result = true;
                    break;
                }
            }
            return result;

        }

        public static void ExtractDependencyIdentifier(BinaryWriter binaryWriter, object obj)
        {
            var dataTable = obj as DataTable;
            if (_objectIDGetter == null)
                _objectIDGetter = dataTable.GetType().DelegateForGetFieldValue("_objectID");
            binaryWriter.Write(Convert.ToString(_objectIDGetter(dataTable)));
        }
        public static void RegisterSurrogateForDataTable()
        {

            string signature = SurrogatesDirectory.ValidSignature("DTABLE");
            SurrogatesDirectory.RegisterSurrogate(
                signature: signature,
                supportedType: typeof(System.Data.DataTable),
                applyBindingAction: null,
                calculateDependencies: CalculateDependencies,
                
                writeComparer: ExtractDependencyIdentifier,
                serializeEx: SerializeDataTable,
                deserializeEx: DeserializeDataTable,
                isValidDependency: IsValidDependency
            );
        }
    }
}