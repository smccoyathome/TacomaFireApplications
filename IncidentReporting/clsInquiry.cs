using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident
{

	public class clsInquiry
		: UpgradeHelpers.Interfaces.IDependentModel, UpgradeHelpers.Interfaces.ICreatesObjects, UpgradeHelpers
		.Interfaces.IInteractsWithView, UpgradeHelpers.Interfaces.IInitializableCommon, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(clsInquiry));
		}

		void UpgradeHelpers.Interfaces.IInitializableCommon.Common()
		{
			_cInquiryManagerRS = null;
			cInquiryManagerID = 0;
			cInquiryDisplay = "";
			cInquiryView = "";
			cInquiryOrderBy = "";
			cInquirySecurity = 0;
			_cInquiryFields = null;
			cInquiryFieldsID = 0;
			cIFInquiryID = 0;
			cFieldName = "";
			cFieldDisplay = "";
			cFlagDisplay = 0;
			cFlagFilter = 0;
			cFlagDate = 0;
			cCodeView = "";
			cCodeDataType = "";
			_cFieldReport = null;
		}


		//********************************************************
		//**    Inquiry Class                                   **
		//**                                                    **
		//********************************************************
		//**    Methods                                         **
		//**----------------------------------------------------**


		//********************************************************
		//**             Private Class Variables                **
		//********************************************************
		//InquiryManager
		public virtual ADORecordSetHelper _cInquiryManagerRS { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cInquiryManagerRS
		{
			get
			{
				if (_cInquiryManagerRS == null)
				{
					_cInquiryManagerRS = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cInquiryManagerRS;
			}
			set
			{
				_cInquiryManagerRS = value;
			}
		}

		public virtual int cInquiryManagerID { get; set; }

		public virtual string cInquiryDisplay { get; set; }

		public virtual string cInquiryView { get; set; }

		public virtual string cInquiryOrderBy { get; set; }

		public virtual int cInquirySecurity { get; set; }

		//InquiryFields
		public virtual ADORecordSetHelper _cInquiryFields { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cInquiryFields
		{
			get
			{
				if (_cInquiryFields == null)
				{
					_cInquiryFields = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cInquiryFields;
			}
			set
			{
				_cInquiryFields = value;
			}
		}

		public virtual int cInquiryFieldsID { get; set; }

		public virtual int cIFInquiryID { get; set; }

		public virtual string cFieldName { get; set; }

		public virtual string cFieldDisplay { get; set; }

		public virtual byte cFlagDisplay { get; set; }

		public virtual byte cFlagFilter { get; set; }

		public virtual byte cFlagDate { get; set; }

		public virtual string cCodeView { get; set; }

		public virtual string cCodeDataType { get; set; }

		//FieldReport Recordset
		public virtual ADORecordSetHelper _cFieldReport { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cFieldReport
		{
			get
			{
				if (_cFieldReport == null)
				{
					_cFieldReport = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cFieldReport;
			}
			set
			{
				_cFieldReport = value;
			}
		}


		//*********************************************
		//**         Class Public Properties         **
		//*********************************************
		//InquiryManager
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper InquiryManagerRS
		{
			get
			{
				return cInquiryManagerRS;
			}
			set
			{
				cInquiryManagerRS = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int InquiryManagerID
		{
			get
			{
				return cInquiryManagerID;
			}
			set
			{
				cInquiryManagerID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string InquiryDisplay
		{
			get
			{
				return cInquiryDisplay;
			}
			set
			{
				cInquiryDisplay = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string InquiryView
		{
			get
			{
				return cInquiryView;
			}
			set
			{
				cInquiryView = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string InquiryOrderBy
		{
			get
			{
				return cInquiryOrderBy;
			}
			set
			{
				cInquiryOrderBy = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int InquirySecurity
		{
			get
			{
				return cInquirySecurity;
			}
			set
			{
				cInquirySecurity = value;
			}
		}


		//InquiryFields
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper InquiryFields
		{
			get
			{
				return cInquiryFields;
			}
			set
			{
				cInquiryFields = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int InquiryFieldsID
		{
			get
			{
				return cInquiryFieldsID;
			}
			set
			{
				cInquiryFieldsID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int IFInquiryID
		{
			get
			{
				return cIFInquiryID;
			}
			set
			{
				cIFInquiryID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string FieldName
		{
			get
			{
				return cFieldName;
			}
			set
			{
				cFieldName = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string FieldDisplay
		{
			get
			{
				return cFieldDisplay;
			}
			set
			{
				cFieldDisplay = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte FlagDisplay
		{
			get
			{
				return cFlagDisplay;
			}
			set
			{
				cFlagDisplay = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte FlagFilter
		{
			get
			{
				return cFlagFilter;
			}
			set
			{
				cFlagFilter = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte FlagDate
		{
			get
			{
				return cFlagDate;
			}
			set
			{
				cFlagDate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string CodeView
		{
			get
			{
				return cCodeView;
			}
			set
			{
				cCodeView = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string CodeDataType
		{
			get
			{
				return cCodeDataType;
			}
			set
			{
				cCodeDataType = value;
			}
		}


		//Field Report Recordset
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper FieldReport
		{
			get
			{
				return cFieldReport;
			}
			set
			{
				cFieldReport = value;
			}
		}



		//**********************************************
		//**         Public Class Methods             **
		//**********************************************

		public void GetInquiries(object iSecurity)
		{
			//Get Inquiries code Recordset
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				//UPGRADE_WARNING: (1068) iSecurity of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				oCmd.CommandText = "spSelect_InquiryManagerAll " + Convert.ToString(iSecurity);
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cInquiryManagerRS = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public int GetInquiryManager(int lInquiryManagerID)
		{
			//Get Individual InquiryManager Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{


				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_InquiryManager " + lInquiryManagerID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					//Load Class Private Variables
					cInquiryManagerID = Convert.ToInt32(oRec["inquiry_id"]);
					cInquiryDisplay = IncidentMain.Clean(oRec["inquiry_display"]);
					cInquiryView = IncidentMain.Clean(oRec["inquiry_view"]);
					cInquiryOrderBy = IncidentMain.Clean(oRec["order_by"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cInquirySecurity = Convert.ToInt32(IncidentMain.GetVal(oRec["inquiry_security"]));
					return -1;
				}
				else
				{
					return 0;
				}
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public int GetInquiryFieldsRS(int lInquiryManagerID)
		{
			//Get InquiryFields Recordset for specified Query
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_InquiryFieldsAll " + lInquiryManagerID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cInquiryFields = oRec;
					return -1;
				}
				else
				{
					return 0;
				}
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public int GetInquiryFields(int lInquiryFieldsID)
		{
			//Get Individual InquiryFields Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{


				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_InquiryFields " + lInquiryFieldsID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					//Load Class Private Variables
					cInquiryFieldsID = Convert.ToInt32(oRec["inquiry_field_id"]);
					cIFInquiryID = Convert.ToInt32(oRec["inquiry_id"]);
					cFieldName = IncidentMain.Clean(oRec["field_name"]);
					cFieldDisplay = IncidentMain.Clean(oRec["field_display"]);
					if (Convert.ToBoolean(oRec["flag_display"]))
					{
						cFlagDisplay = 1;
					}
					else
					{
						cFlagDisplay = 0;
					}
					if (Convert.ToBoolean(oRec["flag_filter"]))
					{
						cFlagFilter = 1;
					}
					else
					{
						cFlagFilter = 0;
					}
					if (Convert.ToBoolean(oRec["flag_date"]))
					{
						cFlagDate = 1;
					}
					else
					{
						cFlagDate = 0;
					}
					cCodeView = IncidentMain.Clean(oRec["code_view"]);

					cCodeDataType = IncidentMain.Clean(oRec["code_data_type"]);
					return -1;
				}
				else
				{
					return 0;
				}
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public string GetFieldDisplay(int lInquiryID, string sFieldName)
		{
			//Return Field Display Name
			string result = "";
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_InquiryFieldsDisplay " + lInquiryID.ToString() + ",'" + sFieldName + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					return IncidentMain.Clean(oRec["field_display"]);
				}
				else
				{
					return "";
				}
			}
			catch
			{

				result = "";
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public void GetFieldReports()
		{
			//Get Inquiries code Recordset
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_InquiryFieldReports";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cInquiryManagerRS = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public int GetOtepReport(string sStartdate, string sEnddate, string sEmpID)
		{
			//Retrieve Otep Procedures Recordset for specified Employee

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_OTEPProcedures '" + sEmpID + "','" + sStartdate + "','" + sEnddate + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");


				if (!oRec.EOF)
				{
					cFieldReport = oRec;
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

		public int GetALSReport(string sStartdate, string sEnddate, string sEmpID)
		{
			//Retrieve ALS Procedures Recordset for specified Employee

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_ALSProcedures '" + sEmpID + "','" + sStartdate + "','" + sEnddate + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");


				if (!oRec.EOF)
				{
					cFieldReport = oRec;
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

		public int GetUnitSummary(string sUnitID, string sShift, string sStartdate, string sEnddate)
		{
			//Retrieve Unit Response Summary

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_UnitActivitySummary '" + sUnitID + "','" + sShift + "','" + sStartdate + "','" + sEnddate + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");


				if (!oRec.EOF)
				{
					cFieldReport = oRec;
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

		public int GetUnitReporting(string sUnitID, string sShift, string sStartdate, string sEnddate)
		{
			//Retrieve Unit Reporting Summary

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_UnitReportsSummary '" + sUnitID + "','" + sShift + "','" + sStartdate + "','" + sEnddate + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");


				if (!oRec.EOF)
				{
					cFieldReport = oRec;
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

		public int GetUnitReportsIncomplete(string sUnitID, string sShift, string sStartdate, string sEnddate)
		{
			//Retrieve Incomplete Report Detail for specified Unit

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_UnitReportsIncomplete '" + sUnitID + "','" + sShift + "','" + sStartdate + "','" + sEnddate + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");


				if (!oRec.EOF)
				{
					cFieldReport = oRec;
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


		public int GetBattIncompleteReports(string sBatt, string sShift, string sStartdate, string sEnddate)
		{
			//Retrieve Incomplete Report Detail for specified Battalion

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_BattIncompleteReports '" + sBatt + "','" + sShift + "','" + sStartdate + "','" + sEnddate + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");


				if (!oRec.EOF)
				{
					cFieldReport = oRec;
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


		public int GetUnitAction(string sUnitID, string sShift, string sStartdate, string sEnddate)
		{
			//Retrieve Unit Actions

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_UnitAction '" + sUnitID + "','" + sShift + "','" + sStartdate + "','" + sEnddate + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");


				if (!oRec.EOF)
				{
					cFieldReport = oRec;
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


		public int GetUnitPersonnelAction(string sUnitID, string sShift, string sStartdate, string sEnddate)
		{
			//Retrieve Unit Personnel Actions

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_UnitPersonnelActivity '" + sUnitID + "','" + sShift + "','" + sStartdate + "','" + sEnddate + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");


				if (!oRec.EOF)
				{
					cFieldReport = oRec;
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