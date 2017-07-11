using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Surrogates.BasicSurrogates
{
	public class DataViewSurrogate
	{

        public static void SerializeDataView(object obj, BinaryWriter binaryWriter, MemoryStream ms, ISurrogateContext context)
        {

            //DataView members
            var dataView = obj as DataView;
            var dataTable = dataView.Table;
            var rowFilter = dataView.RowFilter;
            var sort = dataView.Sort;
            var rowState = (int)dataView.RowStateFilter;
            var applyDefaultSort = dataView.ApplyDefaultSort;
            var allowDelete = dataView.AllowDelete;
            var allowEdit = dataView.AllowEdit;
            var allowNew = dataView.AllowNew;

            binaryWriter.Write(rowFilter);
            binaryWriter.Write(sort);
            binaryWriter.Write(rowState);
            binaryWriter.Write(applyDefaultSort);
            binaryWriter.Write(allowDelete);
            binaryWriter.Write(allowEdit);
            binaryWriter.Write(allowNew);

        }

        public static object DeserializeDataView(BinaryReader binaryReader, ISurrogateContext context)
        {
            var rowFilter = binaryReader.ReadString();
            var sort = binaryReader.ReadString();
            var rowState = (DataViewRowState)binaryReader.ReadInt32();
            var applyDefaultSort = binaryReader.ReadBoolean();
            var allowDelete = binaryReader.ReadBoolean();
            var allowEdit = binaryReader.ReadBoolean();
            var allowNew = binaryReader.ReadBoolean();

            if (context.Dependencies.Count == 0)
            {
                System.Diagnostics.Debug.WriteLine("DataView corrupted " + context.SurrogateUniqueID);
                System.Diagnostics.Debug.WriteLine(new System.Diagnostics.StackTrace().ToString());
            }

            //Gets DataTable reference
            var dataTable = context.Dependencies[0] as DataTable;

            //Creates the DataView instance
            var res = new DataView(dataTable, rowFilter, sort, rowState);
            res.ApplyDefaultSort = applyDefaultSort;
            res.AllowDelete = allowDelete;
            res.AllowEdit = allowEdit;
            res.AllowNew = allowNew;

            return res;
        }

        public static IList<object> CalculateDataViewDependencies(object value, ISurrogateDependenciesContext dependenciesContext)
        {
            var dataTable = (value as DataView).Table;
            return new object[] { dataTable };
        }

        public static string signature = null;
		public static void RegisterSurrogateForDataView()
		{


			signature = SurrogatesDirectory.ValidSignature("DVIEW");

			SurrogatesDirectory.RegisterSurrogate(
                signature:signature, 
                supportedType:typeof(System.Data.DataView),
                applyBindingAction: null,
                serializeEx: SerializeDataView,
                deserializeEx: DeserializeDataView, 
                calculateDependencies: new SurrogateDependencyCalculation[] { CalculateDataViewDependencies }
                );
		}

	}
}
