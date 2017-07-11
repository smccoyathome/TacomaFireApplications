using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident
{

	public class clsMiscReports
		: UpgradeHelpers.Interfaces.IDependentModel, UpgradeHelpers.Interfaces.ICreatesObjects, UpgradeHelpers
		.Interfaces.IInteractsWithView, UpgradeHelpers.Interfaces.IInitializableCommon, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(clsMiscReports));
		}

		void UpgradeHelpers.Interfaces.IInitializableCommon.Common()
		{
			_cHazardousCondition = null;
			cHCIncidentID = 0;
			cHCIncidentType = 0;
			cHCPropertyTypeClass = 0;
			_cSearchOrRescue = null;
			cSRIncidentID = 0;
			cSRIncidentType = 0;
			cSRNumberRescued = 0;
			_cFalseAlarmRS = null;
			cFAIncidentID = 0;
			cFAIncidentType = 0;
			cFAAlarmSentBy = 0;
			cFAMalfunctionDevice = 0;
			cFAComment = "";
			_cServiceReport = null;
			cServiceIncidentID = 0;
			cServiceType = 0;
			cServiceStandbyHours = 0;
			cServiceNumberSafeplace = 0;
		}

		//********************************************************
		//**    Misc. Reports Class                             **
		//********************************************************
		//**        Methods                                     **
		//**------------------------------------------------------
		//**                                                    **
		//**
		//********************************************************

		//*******************************************************
		//**            Private Class Variables                **
		//*******************************************************
		//Hazardous Condition Report
		public virtual ADORecordSetHelper _cHazardousCondition { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cHazardousCondition
		{
			get
			{
				if (_cHazardousCondition == null)
				{
					_cHazardousCondition = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cHazardousCondition;
			}
			set
			{
				_cHazardousCondition = value;
			}
		}

		public virtual int cHCIncidentID { get; set; }

		public virtual int cHCIncidentType { get; set; }

		public virtual int cHCPropertyTypeClass { get; set; }

		//Search and/or Rescue
		public virtual ADORecordSetHelper _cSearchOrRescue { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cSearchOrRescue
		{
			get
			{
				if (_cSearchOrRescue == null)
				{
					_cSearchOrRescue = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cSearchOrRescue;
			}
			set
			{
				_cSearchOrRescue = value;
			}
		}

		public virtual int cSRIncidentID { get; set; }

		public virtual int cSRIncidentType { get; set; }

		public virtual int cSRNumberRescued { get; set; }

		//False Alarm
		public virtual ADORecordSetHelper _cFalseAlarmRS { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cFalseAlarmRS
		{
			get
			{
				if (_cFalseAlarmRS == null)
				{
					_cFalseAlarmRS = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cFalseAlarmRS;
			}
			set
			{
				_cFalseAlarmRS = value;
			}
		}

		public virtual int cFAIncidentID { get; set; }

		public virtual int cFAIncidentType { get; set; }

		public virtual int cFAAlarmSentBy { get; set; }

		public virtual int cFAMalfunctionDevice { get; set; }

		public virtual string cFAComment { get; set; }

		//Service Report
		//   Investigate Only, Clean Up Only, Standby/Staging Only
		public virtual ADORecordSetHelper _cServiceReport { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cServiceReport
		{
			get
			{
				if (_cServiceReport == null)
				{
					_cServiceReport = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cServiceReport;
			}
			set
			{
				_cServiceReport = value;
			}
		}

		public virtual int cServiceIncidentID { get; set; }

		public virtual int cServiceType { get; set; }

		public virtual int cServiceStandbyHours { get; set; }

		public virtual int cServiceNumberSafeplace { get; set; }



		//***********************************************
		//**      Class Public Properties              **
		//***********************************************
		//Hazardous Condition
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper HazardousCondition
		{
			get
			{
				return cHazardousCondition;
			}
			set
			{
				cHazardousCondition = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int HCIncidentID
		{
			get
			{
				return cHCIncidentID;
			}
			set
			{
				cHCIncidentID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int HCIncidentType
		{
			get
			{
				return cHCIncidentType;
			}
			set
			{
				cHCIncidentType = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int HCPropertyTypeClass
		{
			get
			{
				return cHCPropertyTypeClass;
			}
			set
			{
				cHCPropertyTypeClass = value;
			}
		}


		//Search/Rescue
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper SearchOrRescue
		{
			get
			{
				return cSearchOrRescue;
			}
			set
			{
				cSearchOrRescue = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int SRIncidentID
		{
			get
			{
				return cSRIncidentID;
			}
			set
			{
				cSRIncidentID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int SRIncidentType
		{
			get
			{
				return cSRIncidentType;
			}
			set
			{
				cSRIncidentType = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int SRNumberRescued
		{
			get
			{
				return cSRNumberRescued;
			}
			set
			{
				cSRNumberRescued = value;
			}
		}


		//False Alarm
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper FalseAlarmRS
		{
			get
			{
				return cFalseAlarmRS;
			}
			set
			{
				cFalseAlarmRS = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int FAIncidentID
		{
			get
			{
				return cFAIncidentID;
			}
			set
			{
				cFAIncidentID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int FAIncidentType
		{
			get
			{
				return cFAIncidentType;
			}
			set
			{
				cFAIncidentType = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int FAAlarmSentBy
		{
			get
			{
				return cFAAlarmSentBy;
			}
			set
			{
				cFAAlarmSentBy = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int FAMalfunctionDevice
		{
			get
			{
				return cFAMalfunctionDevice;
			}
			set
			{
				cFAMalfunctionDevice = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string FAComment
		{
			get
			{
				return cFAComment;
			}
			set
			{
				cFAComment = value;
			}
		}


		//Service Reports - Investigate,Cleanup, Standby
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper ServiceReport
		{
			get
			{
				return cServiceReport;
			}
			set
			{
				cServiceReport = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ServiceIncidentID
		{
			get
			{
				return cServiceIncidentID;
			}
			set
			{
				cServiceIncidentID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ServiceType
		{
			get
			{
				return cServiceType;
			}
			set
			{
				cServiceType = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ServiceStandbyHours
		{
			get
			{
				return cServiceStandbyHours;
			}
			set
			{
				cServiceStandbyHours = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ServiceNumberSafeplace
		{
			get
			{
				return cServiceNumberSafeplace;
			}
			set
			{
				cServiceNumberSafeplace = value;
			}
		}


		//**************************************************
		//**            Class Public Methods              **
		//**************************************************

		//Hazardous Condition Methods

		public int GetHazardousCondition(int lIncidentID)
		{
			//Retrieve HazardousCondition record and Load data into
			//HazardousCondition class variables
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_HazardousCondition " + lIncidentID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					//Load Class  Variables
					cHCIncidentID = Convert.ToInt32(orec["incident_id"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cHCIncidentType = Convert.ToInt32(IncidentMain.GetVal(orec["incident_type_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cHCPropertyTypeClass = Convert.ToInt32(IncidentMain.GetVal(orec["property_type_class"]));
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

		public int AddHazardousCondition()
		{
			//Add New HazardousCondition Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;
			string SqlString = "";

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spInsert_HazardousCondition " + cHCIncidentID.ToString() + ",";
				if (cHCIncidentType == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cHCIncidentType.ToString() + ",";
				}
				if (cHCPropertyTypeClass == 0)
				{
					SqlString = SqlString + "NULL";
				}
				else
				{
					SqlString = SqlString + cHCPropertyTypeClass.ToString();
				}
				ocmd.CommandText = SqlString;
				ocmd.ExecuteNonQuery();
				ocmd.CommandText = "spSelect_NewHazardousCondition";
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (GetHazardousCondition(Convert.ToInt32(orec[0])) != 0)
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

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public int UpdateHazardousCondition()
		{
			//Update HazardousCondition Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spUpdate_HazardousCondition " + cHCIncidentID.ToString() + ",";
				if (cHCIncidentType == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cHCIncidentType.ToString() + ",";
				}
				if (cHCPropertyTypeClass == 0)
				{
					SqlString = SqlString + "NULL";
				}
				else
				{
					SqlString = SqlString + cHCPropertyTypeClass.ToString();
				}
				ocmd.CommandText = SqlString;
				ocmd.ExecuteNonQuery();
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteHazardousCondition(int lIncidentID)
		{
			//Delete HazardousCondition record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;
				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spDelete_HazardousCondition " + lIncidentID.ToString();
				ocmd.ExecuteNonQuery();
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		//Search/Rescue Methods

		public int GetSearchRescue(int lIncidentID)
		{
			//Retrieve Search/Rescue record and Load data into
			//Search/Rescue class variables
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_SearchRescue " + lIncidentID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					//Load Class  Variables
					cSRIncidentID = Convert.ToInt32(orec["incident_id"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cSRIncidentType = Convert.ToInt32(IncidentMain.GetVal(orec["incident_type_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cSRNumberRescued = Convert.ToInt32(IncidentMain.GetVal(orec["number_rescued"]));
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

		public int AddSearchRescue()
		{
			//Add New SearchRescue Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;
			string SqlString = "";

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spInsert_SearchRescue " + cSRIncidentID.ToString() + ",";
				if (cSRIncidentType == 0)
				{
					SqlString = SqlString + "NULL," + cSRNumberRescued.ToString();
				}
				else
				{
					SqlString = SqlString + cSRIncidentType.ToString() + "," + cSRNumberRescued.ToString();
				}

				ocmd.CommandText = SqlString;
				ocmd.ExecuteNonQuery();
				ocmd.CommandText = "spSelect_NewSearchRescue";
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (GetSearchRescue(Convert.ToInt32(orec[0])) != 0)
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

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public int UpdateSearchRescue()
		{
			//Update SearchRescue Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spUpdate_SearchRescue " + cSRIncidentID.ToString() + ",";
				if (cSRIncidentType == 0)
				{
					SqlString = SqlString + "NULL," + cSRNumberRescued.ToString();
				}
				else
				{
					SqlString = SqlString + cSRIncidentType.ToString() + "," + cSRNumberRescued.ToString();
				}

				ocmd.CommandText = SqlString;
				ocmd.ExecuteNonQuery();
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteSearchRescue(int lIncidentID)
		{
			//Delete SearchRescue record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;
				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spDelete_SearchRescue " + lIncidentID.ToString();
				ocmd.ExecuteNonQuery();
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		//False Alarm Methods

		public int GetFalseAlarm(int lIncidentID)
		{
			//Retrieve FalseAlarm record and Load data into
			//FalseAlarm class variables
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_FalseAlarm " + lIncidentID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					//Load Class  Variables
					cFAIncidentID = Convert.ToInt32(orec["incident_id"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cFAIncidentType = Convert.ToInt32(IncidentMain.GetVal(orec["incident_type_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cFAAlarmSentBy = Convert.ToInt32(IncidentMain.GetVal(orec["alarm_sent_by_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cFAMalfunctionDevice = Convert.ToInt32(IncidentMain.GetVal(orec["malfunctioning_device_code"]));
					cFAComment = IncidentMain.Clean(orec["false_alarm_comment"]);
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

		public int GetFalseAlarmReport(int lIncidentID)
		{
			//Retrieve FalseAlarm Report Data
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_FalseAlarm " + lIncidentID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					//Load Class  Variables
					cFalseAlarmRS = orec;
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

		public int GetHazardousConditionReport(int lIncidentID)
		{
			//Retrieve HazardousCondition Report Data
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_HazardousCondition " + lIncidentID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					//Load Class  Variables
					cHazardousCondition = orec;
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

		public int GetSearchRescueReport(int lIncidentID)
		{
			//Retrieve SearchRescue Report Data
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_SearchRescue " + lIncidentID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					//Load Class  Variables
					cSearchOrRescue = orec;
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


		public int AddFalseAlarm()
		{
			//Add New FalseAlarm Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;
			string SqlString = "";

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spInsert_FalseAlarm " + cFAIncidentID.ToString() + ",";
				if (cFAIncidentType == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cFAIncidentType.ToString() + ",";
				}
				if (cFAAlarmSentBy == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cFAAlarmSentBy.ToString() + ",";
				}
				if (cFAMalfunctionDevice == 0)
				{
					SqlString = SqlString + "NULL,'" + Strings.Replace(cFAComment, "'", "''", 1, -1, CompareMethod.Binary) + "'";
				}
				else
				{
					SqlString = SqlString + cFAMalfunctionDevice.ToString() + ",'" + Strings.Replace(cFAComment, "'", "''", 1, -1, CompareMethod.Binary) + "'";
				}
				ocmd.CommandText = SqlString;
				ocmd.ExecuteNonQuery();
				ocmd.CommandText = "spSelect_NewFalseAlarm";
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (GetFalseAlarm(Convert.ToInt32(orec[0])) != 0)
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

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public int UpdateFalseAlarm()
		{
			//Update FalseAlarm Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spUpdate_FalseAlarm " + cFAIncidentID.ToString() + ",";
				if (cFAIncidentType == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cFAIncidentType.ToString() + ",";
				}
				if (cFAAlarmSentBy == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cFAAlarmSentBy.ToString() + ",";
				}
				if (cFAMalfunctionDevice == 0)
				{
					SqlString = SqlString + "NULL,'" + Strings.Replace(cFAComment, "'", "''", 1, -1, CompareMethod.Binary) + "'";
				}
				else
				{
					SqlString = SqlString + cFAMalfunctionDevice.ToString() + ",'" + Strings.Replace(cFAComment, "'", "''", 1, -1, CompareMethod.Binary) + "'";
				}
				ocmd.CommandText = SqlString;
				ocmd.ExecuteNonQuery();
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public int DeleteFalseAlarm(int lIncidentID)
		{
			//Delete FalseAlarm record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;
				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spDelete_FalseAlarm" + lIncidentID.ToString();
				ocmd.ExecuteNonQuery();
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		//Service Report Methods

		public int GetServiceReport(int lIncidentID)
		{
			//Retrieve ServiceReport record and Load data into
			//GetServiceReport class variables
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_ServiceReport " + lIncidentID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					//Load Class  Variables
					cServiceIncidentID = Convert.ToInt32(orec["incident_id"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cServiceType = Convert.ToInt32(IncidentMain.GetVal(orec["incident_type_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cServiceStandbyHours = Convert.ToInt32(IncidentMain.GetVal(orec["standby_hours"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cServiceNumberSafeplace = Convert.ToInt32(IncidentMain.GetVal(orec["number_safe_place_juveniles"]));
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

		public int GetServiceReportReport(int lIncidentID)
		{
			//Retrieve Service Report Report Data
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_ServiceReport " + lIncidentID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					//Load Class  Variables
					cServiceReport = orec;
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


		public int AddServiceReport()
		{
			//Add New ServiceReport Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;
			string SqlString = "";

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spInsert_ServiceReport " + cServiceIncidentID.ToString() + ",";
				if (cServiceType == 0)
				{
					SqlString = SqlString + "NULL," + cServiceStandbyHours.ToString() + "," + cServiceNumberSafeplace.ToString();
				}
				else
				{
					SqlString = SqlString + cServiceType.ToString() + "," + cServiceStandbyHours.ToString() + "," + cServiceNumberSafeplace.ToString();
				}

				ocmd.CommandText = SqlString;
				ocmd.ExecuteNonQuery();
				ocmd.CommandText = "spSelect_NewServiceReport";
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (GetServiceReport(Convert.ToInt32(orec[0])) != 0)
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

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public int UpdateServiceReport()
		{
			//Update ServiceReport Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spUpdate_ServiceReport " + cServiceIncidentID.ToString() + ",";
				if (cServiceType == 0)
				{
					SqlString = SqlString + "NULL," + cServiceStandbyHours.ToString() + "," + cServiceNumberSafeplace.ToString();
				}
				else
				{
					SqlString = SqlString + cServiceType.ToString() + "," + cServiceStandbyHours.ToString() + "," + cServiceNumberSafeplace.ToString();
				}

				ocmd.CommandText = SqlString;
				ocmd.ExecuteNonQuery();
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteServiceReport(int lIncidentID)
		{
			//Delete ServiceReport record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;
				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spDelete_ServiceReport " + lIncidentID.ToString();
				ocmd.ExecuteNonQuery();
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public string UniqueID { get; set; }

		public UpgradeHelpers.Interfaces.IViewManager ViewManager { get; set; }

		public UpgradeHelpers.Interfaces.IIocContainer Container { get; set; }

	}
}