using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident
{

	public class clsHIPAA
		: UpgradeHelpers.Interfaces.IDependentModel, UpgradeHelpers.Interfaces.ICreatesObjects, UpgradeHelpers
		.Interfaces.IInteractsWithView, UpgradeHelpers.Interfaces.IInitializableCommon, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(clsHIPAA));
		}

		void UpgradeHelpers.Interfaces.IInitializableCommon.Common()
		{
			_cEMSRecordsAccess = null;
			cRecordsAccessID = 0;
			cHIPAAPatientID = 0;
			cAccessDate = "";
			cAccessBy = "";
			cRecordsAccessType = 0;
			cReleasedToName = "";
			cReleasedToAddress1 = "";
			cReleasedToAddress2 = "";
			cReleasedReason = "";
			_cEMSRecordAccessCode = null;
			_cSystemHIPAAMsg = null;
		}

		//********************************************************
		//**    HIPAA Data                                                   **
		//**                                                                         **
		//********************************************************


		//********************************************************
		//**             Private Class Variables                **
		//********************************************************
		//EMSRecordsAccess
		public virtual ADORecordSetHelper _cEMSRecordsAccess { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cEMSRecordsAccess
		{
			get
			{
				if (_cEMSRecordsAccess == null)
				{
					_cEMSRecordsAccess = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cEMSRecordsAccess;
			}
			set
			{
				_cEMSRecordsAccess = value;
			}
		}

		public virtual int cRecordsAccessID { get; set; }

		public virtual int cHIPAAPatientID { get; set; }

		public virtual string cAccessDate { get; set; }

		public virtual string cAccessBy { get; set; }

		public virtual int cRecordsAccessType { get; set; }

		public virtual string cReleasedToName { get; set; }

		public virtual string cReleasedToAddress1 { get; set; }

		public virtual string cReleasedToAddress2 { get; set; }

		public virtual string cReleasedReason { get; set; }

		//EMSRecordAccessCode
		public virtual ADORecordSetHelper _cEMSRecordAccessCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cEMSRecordAccessCode
		{
			get
			{
				if (_cEMSRecordAccessCode == null)
				{
					_cEMSRecordAccessCode = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cEMSRecordAccessCode;
			}
			set
			{
				_cEMSRecordAccessCode = value;
			}
		}


		//SystemHIPAAMsg
		public virtual ADORecordSetHelper _cSystemHIPAAMsg { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cSystemHIPAAMsg
		{
			get
			{
				if (_cSystemHIPAAMsg == null)
				{
					_cSystemHIPAAMsg = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cSystemHIPAAMsg;
			}
			set
			{
				_cSystemHIPAAMsg = value;
			}
		}


		//*********************************************
		//**         Class Public Properties         **
		//*********************************************

		//Property description
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper EMSRecordsAccess
		{
			get
			{
				return cEMSRecordsAccess;
			}
			set
			{
				cEMSRecordsAccess = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int RecordsAccessID
		{
			get
			{
				return cRecordsAccessID;
			}
			set
			{
				cRecordsAccessID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int HIPAAPatientID
		{
			get
			{
				return cHIPAAPatientID;
			}
			set
			{
				cHIPAAPatientID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string AccessDate
		{
			get
			{
				return cAccessDate;
			}
			set
			{
				cAccessDate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string AccessBy
		{
			get
			{
				return cAccessBy;
			}
			set
			{
				cAccessBy = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int RecordsAccessType
		{
			get
			{
				return cRecordsAccessType;
			}
			set
			{
				cRecordsAccessType = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string ReleasedToName
		{
			get
			{
				return cReleasedToName;
			}
			set
			{
				cReleasedToName = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string ReleasedToAddress1
		{
			get
			{
				return cReleasedToAddress1;
			}
			set
			{
				cReleasedToAddress1 = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string ReleasedToAddress2
		{
			get
			{
				return cReleasedToAddress2;
			}
			set
			{
				cReleasedToAddress2 = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string ReleasedReason
		{
			get
			{
				return cReleasedReason;
			}
			set
			{
				cReleasedReason = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public ADORecordSetHelper EMSRecordAccessCode
		{
			get
			{
				return cEMSRecordAccessCode;
			}
			set
			{
				cEMSRecordAccessCode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public ADORecordSetHelper SystemHIPAAMsg
		{
			get
			{
				return cSystemHIPAAMsg;
			}
			set
			{
				cSystemHIPAAMsg = value;
			}
		}


		//**********************************************
		//**         Public Class Methods             **
		//**********************************************

		public int GetSystemHIPAAMsg()
		{
			//Get HIPAA Policy Message Recordset
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_SystemHIPAAMsg";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cSystemHIPAAMsg = oRec;
				if (!cSystemHIPAAMsg.EOF)
				{
					return -1;
				}
				else
				{
					return 0;
				}
			}
			catch
			{

				return 0;
			}
		}


		public int AddEMSRecordsAccess()
		{
			//Add EMSRecordsAccess Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			//    Dim SqlString As String

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spInsert_EMSRecordsAccess";
				oCmd.ExecuteNonQuery(new object[] { cHIPAAPatientID, cAccessDate, cAccessBy, cRecordsAccessType, cReleasedToName, cReleasedToAddress1, cReleasedToAddress2, cReleasedReason });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int GetCreateDate(int lPatientID)
		{
			//Get Date Patient Contact Record Created
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_EMSPatientContactCreateDate " + lPatientID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cEMSRecordsAccess = oRec;
				if (!cEMSRecordsAccess.EOF)
				{
					return -1;
				}
				else
				{
					return 0;
				}
			}
			catch
			{

				return 0;
			}
		}

		public int GetHIPAAHistory(int lPatientID)
		{
			//Get HIPAA Access History
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_EMSRecordsAccess " + lPatientID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cEMSRecordsAccess = oRec;
				if (!oRec.EOF)
				{
					cEMSRecordsAccess = oRec;
					return -1;
				}
				else
				{
					return 0;
				}
			}
			catch
			{

				return 0;
			}
		}

		public string UniqueID { get; set; }

		public UpgradeHelpers.Interfaces.IViewManager ViewManager { get; set; }

		public UpgradeHelpers.Interfaces.IIocContainer Container { get; set; }

	}
}