using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;


namespace TFDIncident
{

	public class clsReportLog
		: UpgradeHelpers.Interfaces.IDependentModel, UpgradeHelpers.Interfaces.ICreatesObjects, UpgradeHelpers
		.Interfaces.IInteractsWithView, UpgradeHelpers.Interfaces.IInitializableCommon, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(clsReportLog));
		}

		void UpgradeHelpers.Interfaces.IInitializableCommon.Common()
		{
			_cReportLogRS = null;
			_cMultiLogRS = null;
			cReportLogID = 0;
			cRLIncidentID = 0;
			cReportReferenceID = 0;
			cReportType = 0;
			cReportStatus = 0;
			cResponsibleUnit = "";
			cLogHistoryID = 0;
			cLogID = 0;
			cReportAction = 0;
			cActionBy = "";
			cActionDate = DateTime.FromOADate(0);
		}

		//********************************************************
		//**    ReportLog Class                                 **
		//********************************************************
		//**    Methods                                         **
		//**----------------------------------------------------**
		//** GetReportLog(lReportID As Long)                    **
		//**     Loads Requested Reportlog Record               **
		//**
		//** GetReportLogRS(lIncidentID As Long)                **
		//**     Returns Recordset - All IncidentReportlogs     **
		//**     For Requested Incident                         **
		//**
		//** GetUnitReportRS(iIncidentID As Long)               **
		//**     Returns Recordset - All UnitReportLogs         **
		//**     For Requested Incident                         **
		//**
		//** AddNew(lIncidentID As Long, iReportType As Integer,
		//**             sResponsibleUnit As String)
		//**     AddsNew ReportLog Record                       **
		//**
		//** Clear()                                            **
		//**     Clear all Private Class Variables              **
		//**
		//** Update()                                           **
		//**     Update all Fields of ReportLog Record          **
		//********************************************************


		//********************************************************
		//**           Private Class Variables                  **
		//********************************************************

		//ReportLog
		public virtual ADORecordSetHelper _cReportLogRS { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cReportLogRS
		{
			get
			{
				if (_cReportLogRS == null)
				{
					_cReportLogRS = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cReportLogRS;
			}
			set
			{
				_cReportLogRS = value;
			}
		}

		public virtual ADORecordSetHelper _cMultiLogRS { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cMultiLogRS
		{
			get
			{
				if (_cMultiLogRS == null)
				{
					_cMultiLogRS = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cMultiLogRS;
			}
			set
			{
				_cMultiLogRS = value;
			}
		}

		public virtual int cReportLogID { get; set; }

		public virtual int cRLIncidentID { get; set; }

		public virtual int cReportReferenceID { get; set; }

		public virtual int cReportType { get; set; }

		public virtual int cReportStatus { get; set; }

		public virtual string cResponsibleUnit { get; set; }

		//ReportLogHistory
		public virtual int cLogHistoryID { get; set; }

		public virtual int cLogID { get; set; }

		public virtual int cReportAction { get; set; }

		public virtual string cActionBy { get; set; }

		public virtual System.DateTime cActionDate { get; set; }


		//********************************************************
		//**             Class Public Properties                **
		//********************************************************

		//ReportLog
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper ReportLogRS
		{
			get
			{
				return cReportLogRS;
			}
			set
			{
				cReportLogRS = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public ADORecordSetHelper MultiLogRS
		{
			get
			{
				return cMultiLogRS;
			}
			set
			{
				cMultiLogRS = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ReportLogID
		{
			get
			{
				return cReportLogID;
			}
			set
			{
				cReportLogID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int RLIncidentID
		{
			get
			{
				return cRLIncidentID;
			}
			set
			{
				cRLIncidentID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ReportReferenceID
		{
			get
			{
				return cReportReferenceID;
			}
			set
			{
				cReportReferenceID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ReportType
		{
			get
			{
				return cReportType;
			}
			set
			{
				cReportType = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ReportStatus
		{
			get
			{
				return cReportStatus;
			}
			set
			{
				cReportStatus = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string ResponsibleUnit
		{
			get
			{
				return cResponsibleUnit;
			}
			set
			{
				cResponsibleUnit = value;
			}
		}


		//ReportLogHistory
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public int LogHistoryID
		{
			get
			{
				return cLogHistoryID;
			}
			set
			{
				cLogHistoryID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int LogID
		{
			get
			{
				return cLogID;
			}
			set
			{
				cLogID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ReportAction
		{
			get
			{
				return cReportAction;
			}
			set
			{
				cReportAction = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string ActionBy
		{
			get
			{
				return cActionBy;
			}
			set
			{
				cActionBy = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public System.DateTime ActionDate
		{
			get
			{
				return cActionDate;
			}
			set
			{
				cActionDate = value;
			}
		}


		//*********************************************
		//**        Class Public Methods             **
		//*********************************************

		public int GetReportLog(int lReportID)
		{
			//Retrieve Requested ReportLog Record
			//Set Class Private Variables to Retrieved Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_Report " + lReportID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					//Set ReportLog Object Properties
					cReportLogID = Convert.ToInt32(oRec["report_log_id"]);
					cRLIncidentID = Convert.ToInt32(oRec["incident_id"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cReportReferenceID = Convert.ToInt32(IncidentMain.GetVal(oRec["report_reference_id"]));
					cReportType = Convert.ToInt32(oRec["report_type"]);
					cReportStatus = Convert.ToInt32(oRec["report_status_id"]);
					cResponsibleUnit = IncidentMain.Clean(oRec["responsible_unit_id"]);
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

		public int GetReportLogRS(int lIncidentID)
		{
			//Retrieve all ReportLog Records for specified IncidentID
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_IncidentReports " + lIncidentID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cReportLogRS = oRec;
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

		public int GetIncidentEditReports(int lIncidentID)
		{
			//Retrieve all Saved Report ReportLog Records for specified IncidentID
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_IncidentEditReports " + lIncidentID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cReportLogRS = oRec;
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

		public int GetUnitReportRS(int iIncidentID)
		{
			//Retrieve all Unit ReportLog records for specified IncidentID
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_IncidentUnitReports " + iIncidentID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cReportLogRS = oRec;
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

		public int GetUnitReportStatus(int lIncidentID, string sUnit)
		{
			//Retrieve Unit Report Status
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_UnitReportStatus " + lIncidentID.ToString() + ",'" + sUnit + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");


				if (!oRec.EOF)
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cReportStatus = Convert.ToInt32(IncidentMain.GetVal(oRec["r_status"]));
					return -1;
				}
				else
				{
					cReportStatus = 0;
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

		public int GetIncidentReportStatus(int lIncidentID)
		{
			//Retrieve Incident Report Status
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_IncidentReportStatus " + lIncidentID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");


				if (!oRec.EOF)
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cReportStatus = Convert.ToInt32(IncidentMain.GetVal(oRec["r_status"]));
					return -1;
				}
				else
				{
					cReportStatus = 0;
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

		public int GetNextIncompleteReport(int lIncidentID, string sUnit)
		{
			//Retrieve Next Incomplete Report
			//For Specified Incident,Unit
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_NextIncompleteReport " + lIncidentID.ToString() + ",'" + sUnit + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");


				if (!oRec.EOF)
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					return Convert.ToInt32(IncidentMain.GetVal(oRec["report_log_id"]));
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

		public int GetIncidentReportLogByType(int lIncidentID, int iType)
		{
			//Retrieve Next Incomplete Report
			//For Specified Incident,Unit
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_ReportLogByType " + lIncidentID.ToString() + "," + iType.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					result = Convert.ToInt32(IncidentMain.GetVal(oRec["report_log_id"]));
					GetReportLog(Convert.ToInt32(oRec["report_log_id"]));
				}
				else
				{
					result = 0;
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

		public void GetLogHistory(int lLogID)
		{
			//Retrieve Requested ReportLogHistory Record
			//Call LoadLogHistory to set Report Object Properties
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			oCmd.Connection = IncidentMain.oIncident;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spSelect_ReportHistoryLog " + lLogID.ToString();
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				LoadLogHistory(oRec);
			}
			else
			{
				ViewManager.ShowMessage("Error Loading ReportLogHistory", "Incident Report Log History Class", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				return;
			}

		}

		public int GetMultiReportLogs(int lIncidentID, int iType)
		{
			//Retrieve RecordSet of Multiple type Reports -
			//(EMSPatient & Casulty ReportLog records)
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_IncidentMultiReports " + lIncidentID.ToString() + "," + iType.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cMultiLogRS = oRec;
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

		private void LoadLogHistory(ADORecordSetHelper oRec)
		{
			//Set ReportLogHistory Object Properties
			cLogHistoryID = Convert.ToInt32(oRec["log_history_id"]);
			cLogID = Convert.ToInt32(oRec["report_log_id"]);
			cReportAction = Convert.ToInt32(oRec["report_action"]);
			cActionBy = Convert.ToString(oRec["action_by"]);
			cActionDate = Convert.ToDateTime(oRec["action_date"]);

		}


		public int AddNew()
		{
			//Add New ReportLog Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			DbCommand oCmdIn = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";


			try
			{

				result = -1;
				oCmd.Connection = IncidentMain.oIncident;
				oCmdIn.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmdIn.CommandType = CommandType.StoredProcedure;
				SqlString = "spInsert_ReportLog " + cRLIncidentID.ToString() + ",";
				if (cReportReferenceID == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cReportReferenceID.ToString() + ",";
				}
				SqlString = SqlString + cReportType.ToString() + "," + cReportStatus.ToString() + ",'" + cResponsibleUnit + "'";
				oCmd.CommandText = SqlString;
				oCmd.ExecuteNonQuery();

				//Load New Record as Current Record
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_LastReportLog";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				GetReportLog(Convert.ToInt32(oRec["last_log_id"]));
				//Add New ReportLogHistory Record
				oCmdIn.CommandText = "spInsert_ReportLogHistory";

				oCmdIn.ExecuteNonQuery(new object[] { oRec["last_log_id"], 1, "55539", DateTime.Now.ToString("MM/dd/yyyy HH:mm") });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}


		public void Clear()
		{
			//Clear all Class Variables
			cReportLogID = 0;
			cRLIncidentID = 0;
			cReportReferenceID = 0;
			cReportType = 0;
			cReportStatus = 0;
			cResponsibleUnit = "";
		}

		public int UpDate()
		{
			//Update ReportLog Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			DbCommand oCmdIn = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;
				oCmd.Connection = IncidentMain.oIncident;
				oCmdIn.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmdIn.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spUpdate_ReportLog";
				
				oCmd.ExecuteNonQuery(new object[] { cReportLogID, cRLIncidentID, cReportReferenceID, cReportType, cReportStatus, cResponsibleUnit });
				
                //Add ReportLogHistory Record
				oCmdIn.CommandText = "spInsert_ReportLogHistory";

				oCmdIn.ExecuteNonQuery(new object[] { cReportLogID, 2, IncidentMain.Shared.gCurrUser, DateTime.Now.ToString("MM/dd/yyyy HH:mm") });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int UpdateStatus(ref int lReportLogID, int lReportRef, int iStatus)
		{
			//Update ReportLogStatus
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			DbCommand oCmdIn = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";
			int ReportAction = 0;

			try
			{

				result = -1;
				oCmd.Connection = IncidentMain.oIncident;
				oCmdIn.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmdIn.CommandType = CommandType.StoredProcedure;
				SqlString = "spUpdate_ReportLogStatus " + lReportLogID.ToString() + ",";
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
				if (Convert.IsDBNull(lReportRef))
				{
					SqlString = SqlString + "NULL," + iStatus.ToString();
				}
				else if (lReportRef == 0)
				{
					SqlString = SqlString + "NULL," + iStatus.ToString();
				}
				else
				{
					SqlString = SqlString + lReportRef.ToString() + "," + iStatus.ToString();
				}
				oCmd.CommandText = SqlString;
				oCmd.ExecuteNonQuery();
				//Add ReportLogHistory Record
				if (iStatus == 0)
				{
					ReportAction = 3;
				}
				else if (iStatus == 2)
				{
					ReportAction = 4;
				}
				else if (iStatus == 3)
				{
					ReportAction = 5;
				}
				//First Insert Update log history if saving
				if (ReportAction == 4 || ReportAction == 5)
				{
                    oCmdIn.CommandText = "spInsert_ReportLogHistory";
                    oCmdIn.ExecuteNonQuery(new object[]{ lReportLogID, 2, IncidentMain.Shared.gCurrUser, DateTime.Now.ToString("MM/dd/yyyy HH:mm")});
				}
				//Insert final report history record into log
				oCmdIn.CommandText = "spInsert_ReportLogHistory";
				oCmdIn.ExecuteNonQuery(new object[] { lReportLogID, ReportAction, IncidentMain.Shared.gCurrUser, DateTime.Now.ToString("MM/dd/yyyy HH:mm") });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		//*********************************************************
		//***  Delete ReportLog - Log History
		//**   This Method is invoked when saving Situation Found
		//**   Report - All existing report types above 2
		//**   (1 = Unit, 2 = Incident Situation found)
		//**   Are deleted and new selections are added
		//**   This situation is routinely called from the Wizard,
		//**   Needs to be combined with a delete all existing reports
		//**   If called from Edit Window
		//*********************************************************

		public int ClearReportLog(int lIncidentID)
		{
			//Deletes all non-unit(1), non-incident(2),non-fs casualty
			//ReportLog, ReportLogHistory records for requested Incident
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;
				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spDelete_ClearReportLog";
				
				oCmd.ExecuteNonQuery(new object[] { lIncidentID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int GetReportOrder(int lIncidentID, int iReportType, string sUnit)
		{
			//Determine order of  Report for specified type
			//1-Check number of Patients
			//2-Check number of saved reports
			//3-Return current order (1-first, 2-second....)
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			int TotalReports = 0, TotalIncomplete = 0;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_TotalReportsByType " + lIncidentID.ToString() + "," + iReportType.ToString() + ",'" + sUnit + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					TotalReports = Convert.ToInt32(oRec["TotalReports"]);
					oCmd.CommandText = "spSelect_TotalIncompleteReportsByType " + lIncidentID.ToString() + "," + iReportType.ToString() + ",'" + sUnit + "'";
					oRec = ADORecordSetHelper.Open(oCmd, "");
					if (!oRec.EOF)
					{
						TotalIncomplete = Convert.ToInt32(oRec["TotalReports"]);
						TotalReports = (TotalReports - TotalIncomplete) + 1;
						return TotalReports;
					}
					else
					{
						return 0;
					}
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

		public int GetReportLogReport(int lIncidentID)
		{
			//Retrieve Report Log Record
			//Formatted for Reporting
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_ReportLog " + lIncidentID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cReportLogRS = oRec;
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

		public int GetReportLogSysAdm(string sIncident)
		{
			//Retrieve Report Log Recordset
			//Formatted for Reporting for System Administration
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_ReportLogSysAdm '" + sIncident + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cReportLogRS = oRec;
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

		public int DeleteReport(int lReportLogID)
		{
			//System Admin Function - Delete Requested Report and all
			//associated records
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				clsHazmat HazmatCL = null;

				if (GetReportLog(lReportLogID) != 0)
				{
					oCmd.CommandText = "";
					switch(cReportType)
					{
						case 4 : case 5 :  //Fire Structure, Fire Mobile 
							oCmd.CommandText = "spDelete_FireReport " + cReportReferenceID.ToString();
							break;
						case 6 :  //Outside Fire 
							oCmd.CommandText = "spDelete_FireOutside " + cReportReferenceID.ToString();
							break;
						case 8 : case 9 :  //Hazmat Fixed, Mobile 
							oCmd.CommandText = "spDelete_HazmatRelease " + cReportReferenceID.ToString();
							break;
						case 10 :  //Hazmat DrugLab 
							oCmd.CommandText = "spDelete_HazmatDrugLab " + cReportReferenceID.ToString();
							break;
						case 12 : case 13 :  //Rupture Structure, Mobile 
							oCmd.CommandText = "spDelete_Rupture " + cReportReferenceID.ToString();
							break;
						case 14 :  //Rupture Outside 
							oCmd.CommandText = "spDelete_RuptureOutside " + cReportReferenceID.ToString();
							break;
						case 15 :  //EMS Patient 
							oCmd.CommandText = "spDelete_EMSPatientContact " + cReportReferenceID.ToString();
							break;
						case 16 :  //Hazardous Condition 
							oCmd.CommandText = "spDelete_HazardousCondition " + cReportReferenceID.ToString();
							break;
						case 17 :  //Search/Rescue 
							oCmd.CommandText = "spDelete_SearchRescue " + cReportReferenceID.ToString();
							break;
						case 18 :  //False Alarm 
							oCmd.CommandText = "spDelete_FalseAlarm " + cReportReferenceID.ToString();
							break;
						case 19 : case 20 : case 21 :  //Investigate Only, Clean Up, Standby/Staging 
							oCmd.CommandText = "spDelete_ServiceReport " + cReportReferenceID.ToString();
							break;
						case 23 :  //Fire Service Casualty 
							oCmd.CommandText = "spDelete_FireServiceCasualty " + cReportReferenceID.ToString();
							break;
						case 24 :
							oCmd.CommandText = "spDelete_CivilianCasualty " + cReportReferenceID.ToString();
							break;
						case 31 :  //Hazmat Druglab w/ Release 
							oCmd.CommandText = "spDelete_HazmatRelease " + cReportReferenceID.ToString();
							oCmd.ExecuteNonQuery();
							HazmatCL = Container.Resolve< clsHazmat>();
							if (HazmatCL.GetIncidentDrugLab(cRLIncidentID) != 0)
							{
								oCmd.CommandText = "spDelete_HazmatDrugLab " + HazmatCL.DLHazmatID.ToString();
							}
							else
							{
								oCmd.CommandText = "";
							}
							break;
						case 33 :  //Address Correction 
							oCmd.CommandText = "spDelete_IncidentAddressCorrection " + cReportReferenceID.ToString();
							break;
					}
					if (oCmd.CommandText != "")
					{
						oCmd.ExecuteNonQuery();
					}
					//Delete ReportLog Records
					oCmd.CommandText = "spDelete_ReportLog " + lReportLogID.ToString();
					oCmd.ExecuteNonQuery();
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

		public int UpdateNFIRSLog(int CurrIncident)
		{
			//Resets Log For Changed Reports
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;

				oCmd.CommandText = "spSelect_NFIRSLog " + CurrIncident.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					oCmd.CommandText = "spUpdate_NFIRSLogStatus " + CurrIncident.ToString() + ",2";
					oCmd.ExecuteNonQuery();
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