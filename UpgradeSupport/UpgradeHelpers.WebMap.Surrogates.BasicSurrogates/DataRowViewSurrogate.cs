using Fasterflect;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Surrogates.BasicSurrogates
{
	public class DataRowViewSurrogate
	{
		static ConstructorInfo constructorDataViewRow;


        public static void SerializeDataRowView(object obj, BinaryWriter binaryWriter, MemoryStream ms, ISurrogateContext context)
        {
        }


        public static object DeserializeDataRowView(BinaryReader binaryReader, ISurrogateContext context)
        {
            DataView dataView = context.Dependencies[0] as DataView;
            DataRow dataRow = context.Dependencies[1] as DataRow;
            if (dataView == null || dataRow == null)
            {
                throw new ArgumentException();
            }
            object res = constructorDataViewRow.Invoke(new object[] { dataView, dataRow });
            return res;
        }

        public static IList<object> CalculateDataRowViewDependencies(object value, ISurrogateDependenciesContext dependenciesContext)
        {
            var dataRowView = (value as DataRowView);
            return new object[] { dataRowView.DataView, dataRowView.Row };
        }

        public static void RegisterSurrogateForDataRowView()
        {

            constructorDataViewRow = typeof(DataRowView).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(DataView), typeof(DataRow) }, null);

            string signature = SurrogatesDirectory.ValidSignature("DRVIEW");

            SurrogatesDirectory.RegisterSurrogate(

                signature: signature, supportedType: typeof(System.Data.DataRowView),
                serializeEx: SerializeDataRowView,
                deserializeEx: DeserializeDataRowView,
                calculateDependencies: new SurrogateDependencyCalculation[] { CalculateDataRowViewDependencies });
		}

	}
}
