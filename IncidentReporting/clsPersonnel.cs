using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident
{

	public class clsPersonnel
		: UpgradeHelpers.Interfaces.IDependentModel, UpgradeHelpers.Interfaces.ICreatesObjects, UpgradeHelpers
		.Interfaces.IInteractsWithView, UpgradeHelpers.Interfaces.IInitializableCommon, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(clsPersonnel));
		}

		void UpgradeHelpers.Interfaces.IInitializableCommon.Common()
		{
			cCurrentUserID = "";
			cCurrentUserLogon = "";
			cCurrentUserNameFull = "";
			cCurrentUserJob = "";
			cUnitOfficerID = "";
			cUnitOfficer = "";
			_cEmployee = null;
			_cOperationsList = null;
			_cPositionList = null;
		}

		//********************************************************
		//**    Personnel Class                                 **
		//********************************************************
		//**    Methods                                         **
		//**----------------------------------------------------**
		//**                                                    **
		//********************************************************


		//********************************************************
		//**             Private Class Variables                **
		//********************************************************
		//Logon Info
		public virtual string cCurrentUserID { get; set; }

		public virtual string cCurrentUserLogon { get; set; }

		public virtual string cCurrentUserNameFull { get; set; }

		public virtual string cCurrentUserJob { get; set; }

		//Unit Officer for Selected Date
		public virtual string cUnitOfficerID { get; set; }

		public virtual string cUnitOfficer { get; set; }

		//Employee
		public virtual ADORecordSetHelper _cEmployee { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cEmployee
		{
			get
			{
				if (_cEmployee == null)
				{
					_cEmployee = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cEmployee;
			}
			set
			{
				_cEmployee = value;
			}
		}


		//List of All Operations Staff
		public virtual ADORecordSetHelper _cOperationsList { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cOperationsList
		{
			get
			{
				if (_cOperationsList == null)
				{
					_cOperationsList = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cOperationsList;
			}
			set
			{
				_cOperationsList = value;
			}
		}


		//List of Positions
		public virtual ADORecordSetHelper _cPositionList { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cPositionList
		{
			get
			{
				if (_cPositionList == null)
				{
					_cPositionList = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cPositionList;
			}
			set
			{
				_cPositionList = value;
			}
		}


		//*********************************************
		//**         Class Public Properties         **
		//*********************************************
		//Current User Info
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public string CurrentUserID
		{
			get
			{
				return cCurrentUserID;
			}
			set
			{
				cCurrentUserID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string CurrentUserLogon
		{
			get
			{
				return cCurrentUserLogon;
			}
			set
			{
				cCurrentUserLogon = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string CurrentUserNameFull
		{
			get
			{
				return cCurrentUserNameFull;
			}
			set
			{
				cCurrentUserNameFull = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string CurrentUserJob
		{
			get
			{
				return cCurrentUserJob;
			}
			set
			{
				cCurrentUserJob = value;
			}
		}


		//Unit Officer
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public string UnitOfficerID
		{
			get
			{
				return cUnitOfficerID;
			}
			set
			{
				cUnitOfficerID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UnitOfficer
		{
			get
			{
				return cUnitOfficer;
			}
			set
			{
				cUnitOfficer = value;
			}
		}


		//Employee
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper Employee
		{
			get
			{
				return cEmployee;
			}
			set
			{
				cEmployee = value;
			}
		}


		//OperationsList
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper OperationsList
		{
			get
			{
				return cOperationsList;
			}
			set
			{
				cOperationsList = value;
			}
		}


		//PositionList
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper PositionList
		{
			get
			{
				return cPositionList;
			}
			set
			{
				cPositionList = value;
			}
		}


		//**********************************************
		//**         Public Class Methods             **
		//**********************************************

		//Get Currently Logoned on Employee Info

		public int GetCurrUserInfo()
		{
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oPTSdata;
				ocmd.CommandType = CommandType.Text;

				ocmd.CommandText = "sp_getuser";
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					cCurrentUserLogon = Convert.ToString(orec["user_id"]);
					result = -1;
				}
				else
				{
					return 0;
				}

				ocmd.CommandText = "sp_GetUserInfo '" + cCurrentUserLogon + "'";
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					cCurrentUserID = Convert.ToString(orec["EmpID"]);
					cCurrentUserNameFull = IncidentMain.Clean(orec["name_last"]) + ", " + IncidentMain.Clean(orec["name_first"]);
					cCurrentUserJob = IncidentMain.Clean(orec["job_code"]);
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

		public void GetOperationsList()
		{
			//Get Recordset of All Operations Staff
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oPTSdata;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spOpNameList";
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					cOperationsList = orec;
				}
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetNonOperationsList()
		{
			//Get Recordset of All Non Operations Staff Types
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oPTSdata;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_NonTFDStaffingList";
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					cOperationsList = orec;
				}
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetAllPersonnelList()
		{
			//Get Recordset of All TFD Staff
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oPTSdata;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spFullNameList";
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					cOperationsList = orec;
				}
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetInspectorList()
		{
			//Get List of all Inspectors, DFM, Fire Prot. Engineers
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oPTSdata;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_InspectorList";
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					cOperationsList = orec;
				}
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}


		public int GetEmployeeRecord(string sEmpID)
		{
			//Get Recordset of Requested Employee Information
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oPTSdata;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_Employee '" + sEmpID + "'";
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					cEmployee = orec;
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

		public int GetAnyUserInfo(string sEmpID)
		{
			//Get Recordset of Requested Employee Information
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oPTSdata;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EmployeeInfo '" + sEmpID + "'";
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					cEmployee = orec;
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

		public int GetPositionList(string sUnit)
		{
			//Get Recordset of All Positions for requested Unit
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oPTSdata;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_UnitStaffingPositions '" + sUnit + "'";
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					cPositionList = orec;
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

		public void GetPositionListAll()
		{
			//Get Recordset of All Positions for requested Unit
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oPTSdata;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_ReportingUnitPositions";
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					cPositionList = orec;
				}
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}



		public string GetPTSSecurity(string sEmpID)
		{
			//Get Security from PTS system
			string result = "";
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oPTSdata;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "sp_GetSecurity '" + sEmpID + "'";
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					return Convert.ToString(orec["security_code"]);
				}
				else
				{
					return "";
				}
			}
			catch
			{

				result = (false).ToString();
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public int CheckBC(string sIncDate)
		{
			//Find out if Employee was a BC on Incident Date
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;
			int AssignID = 0;

			try
			{

				ocmd.Connection = IncidentMain.oPTSdata;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "sp_GetAssignID '" + IncidentMain.Shared.gCurrUser + "','" + sIncDate + "'";
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					AssignID = Convert.ToInt32(orec["assignment_id"]);
					ocmd.CommandText = "sp_GetAssignInfo " + AssignID.ToString();
					orec = ADORecordSetHelper.Open(ocmd, "");
					if (!orec.EOF)
					{
						if (Convert.ToString(orec["position_code"]).Trim() == "BC")
						{
							return -1;
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

		//Get Unit Officer for specific Date

		public int GetUnitOfficer(string sUnit, System.DateTime dDate)
		{
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oInspection;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_TFDUnitOfficer '" + sUnit + "','" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(dDate) + "'";
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					cUnitOfficerID = Convert.ToString(orec["employee_id"]);
					cUnitOfficer = IncidentMain.Clean(orec["name_full"]);
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

		public int GetUnitInspectorID(string sUnitID)
		{
			//Get Inspector ID from PTS system
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oPTSdata;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_Inspector '" + sUnitID + "'";
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					cEmployee = orec;
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

		public int GetNextInspectionDueDate(string sEmployeeID, System.DateTime dCalcDate)
		{
			//Get Officer Next Schedule Date
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oPTSdata;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_NextInspectionDueDate '" + sEmployeeID + "','" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(dCalcDate) + "'";
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					cEmployee = orec;
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

		public int GetPersonnelRecord(string sEmpID)
		{
			//Get Recordset of Requested Employee Information
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oPTSdata;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "sp_GetPersonnelDetail '" + sEmpID + "'";
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					cEmployee = orec;
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

		public string UniqueID { get; set; }

		public UpgradeHelpers.Interfaces.IViewManager ViewManager { get; set; }

		public UpgradeHelpers.Interfaces.IIocContainer Container { get; set; }

	}
}