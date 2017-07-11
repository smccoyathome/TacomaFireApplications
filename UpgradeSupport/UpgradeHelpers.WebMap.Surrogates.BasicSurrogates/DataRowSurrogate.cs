using Fasterflect;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Surrogates.BasicSurrogates
{
	public class DataRowSurrogate
	{

        public static IList<object> CalculateDataTableDependency(object value, ISurrogateDependenciesContext dependenciesContext)
        {
            var table = value as DataRow;
            
            return new object[] { table.Table };
        }

        public static void SerializeDataRow(object obj, BinaryWriter binaryWriter, MemoryStream ms, ISurrogateContext context)
        {
            var dataRow = obj as DataRow;
            var dataTable = dataRow.Table;
            var rowIndex = dataRow.Table.Rows.IndexOf(dataRow);
            var rowError = dataRow.RowError == null ? "null" : dataRow.RowError;
            var rowID = SurrogateUtils.GetRowID(dataRow);

            binaryWriter.Write(rowIndex);
            binaryWriter.Write(rowID);
            binaryWriter.Write(rowError);

        }

        public static object DeserializeDataRow(BinaryReader binaryReader, ISurrogateContext context)
        {
            DataRow res = null;

            var rowIndex = binaryReader.ReadInt32();
            var rowID = binaryReader.ReadInt32();
            var rowError = binaryReader.ReadString();
            rowError = rowError == "null" ? null : rowError;




            var dataTable = (DataTable)context.Dependencies[0];
            try
            {
                
                //If the data table has been cleared a dummy row is return instead
                //To-do: Implement a DataTable Surrogate in order to ensure rows consistency
                if (dataTable.Rows.Count > 0 && rowIndex != -1)
                {
                    //Lets try to find the Row in the table, if it's still there...
                    res = SurrogateUtils.GetRowInDataTable(dataTable, rowIndex, rowID);
                    if (res == null)
                    {
                        //If the table has no rows then current surrogate is not valid and must be removed as reference for the Table
                        res = dataTable.NewRow();
                        context.RemoveDependency(dataTable);
                    }
                }
                else
                {
                    //If the table has no rows then current surrogate is not valid and must be removed as reference for the Table
                    res = dataTable.NewRow();
                    context.RemoveDependency(dataTable);
                }
            }
            catch
            {
                //Temporary change: ensure that there is always a row to be returned
                res = dataTable.NewRow();
                context.RemoveDependency(dataTable);
            }
            return res;

        }

        static string signature = null;
        public static void RegisterSurrogateForDataRow()
		{
			signature = SurrogatesDirectory.ValidSignature("DROW");
            SurrogatesDirectory.RegisterSurrogate(

                signature: signature,
                supportedType: typeof(System.Data.DataRow),
                applyBindingAction: null,
                serializeEx: SerializeDataRow,
                deserializeEx: DeserializeDataRow,
                calculateDependencies: new SurrogateDependencyCalculation[] { CalculateDataTableDependency }
                );
		}

	}
}
