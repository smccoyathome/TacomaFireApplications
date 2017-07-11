using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using UpgradeHelpers.DB.ADO.Events;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap;

namespace UpgradeHelpers.DB.ADO.Surrogates
{
    public class ADOSurrogates : ISurrogateRegistration
    {
        public void Register()
        {
            RegisterSurrogateForAdoRecordSetHelper();
        }

        public static void Serialize(object instance, BinaryWriter binaryWriter, MemoryStream ms, ISurrogateContext context)
        {
            var rs = instance as ADORecordSetHelper;
            //ADORecordSet serialized
            var ms_adorecordset = new MemoryStream();
			var source = rs.Source;
			if (source is DbCommand)
			{
				DbCommand cmd = (DbCommand)source;
				binaryWriter.Write(true);
				binaryWriter.Write(cmd.CommandText);
			}
			else if (source is string)
			{
				binaryWriter.Write(true);
				binaryWriter.Write(source.ToString());
			}
			else
			{
				binaryWriter.Write(false);
			}
			BinaryFormatter bFormat = new BinaryFormatter();
            bFormat.Serialize(ms_adorecordset, rs);
            binaryWriter.Write(ms_adorecordset.ToArray());
        }

        public static object Deserialize(BinaryReader binaryReader, ISurrogateContext context)
        {
            DbConnection conn = null;
            if (context.DependencyCount > 0)
            {
                conn = context.Dependencies[0] as DbConnection;
            }
			var hasSource = binaryReader.ReadBoolean();
			string source = "";
			if (hasSource)
			{
				source = binaryReader.ReadString();
			}
			BinaryFormatter bFormat = new BinaryFormatter();
            ADORecordSetHelper rs = (ADORecordSetHelper)bFormat.Deserialize(binaryReader.BaseStream);
			rs.ProviderFactory = AdoFactoryManager.GetFactory("");
			rs.ActiveConnection = conn;
			if (hasSource)
			{
				rs.Source = source;
			}
			return rs;
        }

        public static IList<object> EMPTY_LIST = new object[0];

        public static IList<object> CalculateDependencies(object value, ISurrogateDependenciesContext dependenciesContext)
        {
            var adoRecordSet = value as ADORecordSetHelper;
            if (adoRecordSet.ActiveConnection != null)
            {
                return new object[] { adoRecordSet.ActiveConnection };
            }
            return EMPTY_LIST;
        }

        internal static void ApplyBindingAction(object ds, Action<bool> applyAction)
        {
            var rs = ds as ADORecordSetHelper;
            if (rs != null)
            {
                MoveEventHandler onWillMove = null;
                MoveCompleteEventHandler onMoveComplete = null;
                //Events.After
                EventHandler onAfterQuery = null;
                if (onWillMove == null)
                {
                    onWillMove = (sender, args) =>
                    {
                        var theRS = sender as ADORecordSetHelper;
                        if (theRS != null)
                        {
                            if (theRS.CurrentRow != null)
                            {
                                applyAction(false);
                            }
                        }
                    };
                }

                if (onMoveComplete == null)
                {
                    onMoveComplete = (sender, args) => applyAction(true);
                }
                if (onAfterQuery == null)
                {
                    onAfterQuery =
                        (sender, args) =>
                        applyAction(true);
                }
                rs.WillMove -= onWillMove;
                rs.WillMove += onWillMove;
                rs.MoveComplete -= onMoveComplete;
                rs.MoveComplete += onMoveComplete;
                rs.AfterQuery -= onAfterQuery;
                rs.AfterQuery += onAfterQuery;
                return;
            }
            throw new ArgumentException("SurrogateRegisterBinding object was expected to by of UpgradeHelpers.DB.ADO.ADORecordSetHelper type");

        }

        internal static object PropertyGetter(object ds, string propertyName)
        {
            var rs = ds as ADORecordSetHelper;
            if (rs != null)
            {
                propertyName = propertyName.Replace("Table.", "");
                if (rs.Opened)
                    return rs[propertyName];
                else
                    return null;
            }
            throw new ArgumentException("SurrogateRegisterBinding object was expected to by of UpgradeHelpers.DB.ADO.ADORecordSetHelper type");

        }

        internal static void PropertySetter(object ds, string propertyName, object value)
        {
            var rs = ds as ADORecordSetHelper;
            if (rs != null)
            {
                propertyName = propertyName.Replace("Table.", "");
                var original_val = rs[propertyName];
                if (!original_val.Equals(value))
                {
                    rs[propertyName] = value;
                }
                return;
            }
            throw new ArgumentException("SurrogateRegisterBinding object was expected to by of UpgradeHelpers.DB.ADO.ADORecordSetHelper type");
        }

        private static void RegisterSurrogateForAdoRecordSetHelper()
        {
            string signatureAdoRecordSetHelper = SurrogatesDirectory.ValidSignature("ADORS");
            SurrogatesDirectory.RegisterSurrogate(signatureAdoRecordSetHelper, typeof(ADORecordSetHelper),
                serializeEx: Serialize,
                deserializeEx: Deserialize,
                applyBindingAction: ApplyBindingAction,
                calculateDependencies: new SurrogateDependencyCalculation[] { CalculateDependencies },
                PropertyGetter: PropertyGetter,
                PropertySetter: PropertySetter);
        }
    }
}