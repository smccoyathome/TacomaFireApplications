using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public class clsUnit
		: UpgradeHelpers.Interfaces.IDependentModel, UpgradeHelpers.Interfaces.ICreatesObjects, UpgradeHelpers
		.Interfaces.IInteractsWithView, UpgradeHelpers.Interfaces.IInitializableCommon, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(clsUnit));
		}

		void UpgradeHelpers.Interfaces.IInitializableCommon.Common()
		{
			_cUnit = null;
			cUnitID = "";
			cFacilityID = 0;
			cUnitType = 0;
			cAgencyID = 0;
			cUnitName = "";
			cUnitBattalion = "";
			cUnitConversionCode = "";
			_cUnitResponse = null;
			_cUnitListing = null;
			cUnitResponseID = 0;
			cIncidentID = 0;
			cURUnitID = "";
			cFlagClearingUnit = 0;
			cFlagICUnit = 0;
			cUnitNarrative = "";
			_cUnitTimes = null;
			cUTUnitResponseID = 0;
			cResponseTime = 0;
			cResponseTimeDescription = "";
			cActualTime = "";
			cAmendedTime = "";
			cReasonAmended = 0;
			_cUnitPersonnel = null;
			cUPUnitResponseID = 0;
			cEmployeeID = "";
			cPosition = "";
			cCasualtyFlag = 0;
			cExposureFlag = 0;
			cPersonnelNameFull = "";
			_cUnitDelay = null;
			cUDUnitResponseID = 0;
			cDelay = 0;
			cDelayDescription = "";
			_cUnitAction = null;
			cUAUnitResponseID = 0;
			cAction = 0;
			cActionDescription = "";
			_cTransportUnit = null;
		}

		//********************************************************
		//**    Unit Class                                      **
		//********************************************************


		//Private Class Variables
		//Unit
		public virtual ADORecordSetHelper _cUnit { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cUnit
		{
			get
			{
				if (_cUnit == null)
				{
					_cUnit = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cUnit;
			}
			set
			{
				_cUnit = value;
			}
		}

		public virtual string cUnitID { get; set; }

		public virtual int cFacilityID { get; set; }

		public virtual int cUnitType { get; set; }

		public virtual int cAgencyID { get; set; }

		public virtual string cUnitName { get; set; }

		public virtual string cUnitBattalion { get; set; }

		public virtual string cUnitConversionCode { get; set; }


		//UnitResponse
		public virtual ADORecordSetHelper _cUnitResponse { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cUnitResponse
		{
			get
			{
				if (_cUnitResponse == null)
				{
					_cUnitResponse = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cUnitResponse;
			}
			set
			{
				_cUnitResponse = value;
			}
		}

		public virtual ADORecordSetHelper _cUnitListing { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cUnitListing
		{
			get
			{
				if (_cUnitListing == null)
				{
					_cUnitListing = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cUnitListing;
			}
			set
			{
				_cUnitListing = value;
			}
		}

		public virtual int cUnitResponseID { get; set; }

		public virtual int cIncidentID { get; set; }

		public virtual string cURUnitID { get; set; }

		public virtual byte cFlagClearingUnit { get; set; }

		public virtual byte cFlagICUnit { get; set; }

		public virtual string cUnitNarrative { get; set; }

		//UnitResponseTime
		public virtual ADORecordSetHelper _cUnitTimes { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cUnitTimes
		{
			get
			{
				if (_cUnitTimes == null)
				{
					_cUnitTimes = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cUnitTimes;
			}
			set
			{
				_cUnitTimes = value;
			}
		}

		public virtual int cUTUnitResponseID { get; set; }

		public virtual int cResponseTime { get; set; }

		public virtual string cResponseTimeDescription { get; set; }

		public virtual string cActualTime { get; set; }

		public virtual string cAmendedTime { get; set; }

		public virtual int cReasonAmended { get; set; }

		//UnitPersonnel
		public virtual ADORecordSetHelper _cUnitPersonnel { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cUnitPersonnel
		{
			get
			{
				if (_cUnitPersonnel == null)
				{
					_cUnitPersonnel = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cUnitPersonnel;
			}
			set
			{
				_cUnitPersonnel = value;
			}
		}

		public virtual int cUPUnitResponseID { get; set; }

		public virtual string cEmployeeID { get; set; }

		public virtual string cPosition { get; set; }

		public virtual byte cCasualtyFlag { get; set; }

		public virtual byte cExposureFlag { get; set; }

		public virtual string cPersonnelNameFull { get; set; }

		//UnitDelay
		public virtual ADORecordSetHelper _cUnitDelay { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cUnitDelay
		{
			get
			{
				if (_cUnitDelay == null)
				{
					_cUnitDelay = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cUnitDelay;
			}
			set
			{
				_cUnitDelay = value;
			}
		}

		public virtual int cUDUnitResponseID { get; set; }

		public virtual int cDelay { get; set; }

		public virtual string cDelayDescription { get; set; }

		//UnitAction
		public virtual ADORecordSetHelper _cUnitAction { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cUnitAction
		{
			get
			{
				if (_cUnitAction == null)
				{
					_cUnitAction = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cUnitAction;
			}
			set
			{
				_cUnitAction = value;
			}
		}

		public virtual int cUAUnitResponseID { get; set; }

		public virtual int cAction { get; set; }

		public virtual string cActionDescription { get; set; }

		//TransportUnit
		public virtual ADORecordSetHelper _cTransportUnit { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cTransportUnit
		{
			get
			{
				if (_cTransportUnit == null)
				{
					_cTransportUnit = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cTransportUnit;
			}
			set
			{
				_cTransportUnit = value;
			}
		}



		//Class Public Properties
		//Unit
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper Unit
		{
			get
			{
				return cUnit;
			}
			set
			{
				cUnit = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UnitID
		{
			get
			{
				return cUnitID;
			}
			set
			{
				cUnitID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int FacilityID
		{
			get
			{
				return cFacilityID;
			}
			set
			{
				cFacilityID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int UnitType
		{
			get
			{
				return cUnitType;
			}
			set
			{
				cUnitType = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int AgencyID
		{
			get
			{
				return cAgencyID;
			}
			set
			{
				cAgencyID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UnitName
		{
			get
			{
				return cUnitName;
			}
			set
			{
				cUnitName = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UnitBattalion
		{
			get
			{
				return cUnitBattalion;
			}
			set
			{
				cUnitBattalion = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UnitConversionCode
		{
			get
			{
				return cUnitConversionCode;
			}
			set
			{
				cUnitConversionCode = value;
			}
		}


		//UnitResponse
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper UnitResponse
		{
			get
			{
				return cUnitResponse;
			}
			set
			{
				cUnitResponse = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public ADORecordSetHelper UnitListing
		{
			get
			{
				return cUnitListing;
			}
			set
			{
				cUnitListing = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int UnitResponseID
		{
			get
			{
				return cUnitResponseID;
			}
			set
			{
				cUnitResponseID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int IncidentID
		{
			get
			{
				return cIncidentID;
			}
			set
			{
				cIncidentID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string URUnitID
		{
			get
			{
				return cURUnitID;
			}
			set
			{
				cURUnitID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte FlagClearingUnit
		{
			get
			{
				return cFlagClearingUnit;
			}
			set
			{
				cFlagClearingUnit = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte FlagICUnit
		{
			get
			{
				return cFlagICUnit;
			}
			set
			{
				cFlagICUnit = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UnitNarrative
		{
			get
			{
				return cUnitNarrative;
			}
			set
			{
				cUnitNarrative = value;
			}
		}


		//UnitResponseTimes
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper UnitTimes
		{
			get
			{
				return cUnitTimes;
			}
			set
			{
				cUnitTimes = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int UTUnitResponseID
		{
			get
			{
				return cUTUnitResponseID;
			}
			set
			{
				cUTUnitResponseID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ResponseTime
		{
			get
			{
				return cResponseTime;
			}
			set
			{
				cResponseTime = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string ResponseTimeDescription
		{
			get
			{
				return cResponseTimeDescription;
			}
			set
			{
				cResponseTimeDescription = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string ActualTime
		{
			get
			{
				return cActualTime;
			}
			set
			{
				cActualTime = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string AmendedTime
		{
			get
			{
				return cAmendedTime;
			}
			set
			{
				cAmendedTime = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ReasonAmended
		{
			get
			{
				return cReasonAmended;
			}
			set
			{
				cReasonAmended = value;
			}
		}


		//UnitPersonnel
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper UnitPersonnel
		{
			get
			{
				return cUnitPersonnel;
			}
			set
			{
				cUnitPersonnel = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int UPUnitResponseID
		{
			get
			{
				return cUPUnitResponseID;
			}
			set
			{
				cUPUnitResponseID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string EmployeeID
		{
			get
			{
				return cEmployeeID;
			}
			set
			{
				cEmployeeID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string Position
		{
			get
			{
				return cPosition;
			}
			set
			{
				cPosition = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte CasualtyFlag
		{
			get
			{
				return cCasualtyFlag;
			}
			set
			{
				cCasualtyFlag = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte ExposureFlag
		{
			get
			{
				return cExposureFlag;
			}
			set
			{
				cExposureFlag = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PersonnelNameFull
		{
			get
			{
				return cPersonnelNameFull;
			}
			set
			{
				cPersonnelNameFull = value;
			}
		}


		//UnitDelay
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper UnitDelay
		{
			get
			{
				return cUnitDelay;
			}
			set
			{
				cUnitDelay = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int UDUnitResponseID
		{
			get
			{
				return cUDUnitResponseID;
			}
			set
			{
				cUDUnitResponseID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int Delay
		{
			get
			{
				return cDelay;
			}
			set
			{
				cDelay = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string DelayDescription
		{
			get
			{
				return cDelayDescription;
			}
			set
			{
				cDelayDescription = value;
			}
		}


		//UnitAction
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper UnitAction
		{
			get
			{
				return cUnitAction;
			}
			set
			{
				cUnitAction = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int UAUnitResponseID
		{
			get
			{
				return cUAUnitResponseID;
			}
			set
			{
				cUAUnitResponseID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int Action
		{
			get
			{
				return cAction;
			}
			set
			{
				cAction = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string ActionDescription
		{
			get
			{
				return cActionDescription;
			}
			set
			{
				cActionDescription = value;
			}
		}


		//TransportUnit
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper TransportUnit
		{
			get
			{
				return cTransportUnit;
			}
			set
			{
				cTransportUnit = value;
			}
		}


		//***************************************
		//**     Public Class Methods          **
		//***************************************
		//Select Methods

		public int TFDUnitListRS()
		{
			//Retrieve Recordset with list of TFD Units
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_UnitTrainingList";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cUnit = oRec;
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

		public int GetUnit(string sUnitID)
		{
			//Retrieve Individual Unit  Record
			//Load Class  Variables with selected Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = modGlobal.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_Unit '" + sUnitID + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					//Load Class  Variables
					cUnitID = modGlobal.Clean(oRec["unit_id"]);
					cFacilityID = Convert.ToInt32(oRec["facility_id"]);
					cUnitType = Convert.ToInt32(Double.Parse(modGlobal.Clean(oRec["unit_type_code"])));
					cAgencyID = Convert.ToInt32(oRec["agency_id"]);
					cUnitName = Convert.ToString(oRec["unit_name"]);
					cUnitBattalion = modGlobal.Clean(oRec["unit_battalion"]);
					cUnitConversionCode = modGlobal.Clean(oRec["unit_conversion_code"]);
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

		public int GetInspector(string sUnitID)
		{
			//Retrieve Inspector and position for specified Unit
			//From PTSdata database
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_Inspector '" + sUnitID + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cUnitPersonnel = oRec;
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

		public int GetUnitResponse(int lUnitResponseID)
		{
			//Retrieve Individual Unit Response Record
			//Load Class  Variables with selected Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = modGlobal.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_UnitResponse " + lUnitResponseID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					//Load Class  Variables
					cUnitResponseID = Convert.ToInt32(oRec["unit_response_id"]);
					cIncidentID = Convert.ToInt32(oRec["incident_id"]);
					cURUnitID = modGlobal.Clean(oRec["unit_id"]);
					cFlagClearingUnit = Convert.ToByte(oRec["flag_clearing_unit"]);
					cFlagICUnit = Convert.ToByte(oRec["flag_ic_unit"]);
					cUnitNarrative = modGlobal.Clean(oRec["unit_narrative"]);
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

		public int CheckUnitResponse(int lIncidentID, string sUnit)
		{
			//Check for Existing UnitResponse Record using IncidentID and Unit
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = modGlobal.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_UnitResponseCheck " + lIncidentID.ToString() + ",'" + sUnit + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					return Convert.ToInt32(oRec["unit_response_id"]);
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

		public int GetUnitListing(string sStartDate, string sEndDate, string sUnit, int iType, string sBatt, int iStatus)
		{
			//Retrieve Unit Response Listing for given date range
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;
				oCmd.Connection = modGlobal.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_UnitRespListing '" + sStartDate + "','" + sEndDate + "','" + sUnit + "'," + iType.ToString() + ",'" + sBatt + "'," + iStatus.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");


				if (!oRec.EOF)
				{
					cUnitListing = oRec;
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


		public string GetTFDUnit(string sUnitID)
		{
			//Validate UnitID as TFD Unit
			string result = "";
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = (true).ToString();
				oCmd.Connection = modGlobal.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_TFDUnit '" + sUnitID + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");


				if (!oRec.EOF)
				{
					return Convert.ToString(oRec["unit_id"]);
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

		public string ConvertUnitToCAD(string sUnitID)
		{
			//Validate UnitID as TFD Unit
			string result = "";
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = "";
				oCmd.Connection = modGlobal.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_UnitCADCode '" + sUnitID + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");


				if (!oRec.EOF)
				{
					return Convert.ToString(oRec["unit_conversion_code"]);
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

		public int GetIncidentUnitResponses(int lIncidentID)
		{
			//Retrieve UnitResponse Recordset of All Unit Responses
			//For specified Incident
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = modGlobal.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_IncidentUnitResponses " + lIncidentID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					//Load UnitResponse Recordset Private  Variable
					cUnitResponse = oRec;
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

		public int GetIncidentTransportResponses(int lIncidentID)
		{
			//Retrieve Recordset of All Transport Unit Responses (Rescue & Ambulance)
			//For specified Incident
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = modGlobal.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_IncidentTransResponse " + lIncidentID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					//Load UnitResponse Recordset Private  Variable
					cUnitResponse = oRec;
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

		public int GetIncidentTFDUnitResponses(int lIncidentID)
		{
			//Retrieve UnitResponse Recordset of All TFD Unit Responses
			//For specified Incident
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = modGlobal.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_IncidentTFDResponses " + lIncidentID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					//Load UnitResponse Recordset Private  Variable
					cUnitResponse = oRec;
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

		public int GetUnitTimesRS(int lUnitResponseID)
		{
			//Retrieve UnitTimes Recordset of All Unit Time
			//For specified UnitResponse
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = modGlobal.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_UnitResponseUnitTimes " + lUnitResponseID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					//Load UnitTimes Recordset Private  Variable
					cUnitTimes = oRec;
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

		public int GetUnitTime(int lUnitResponseID, int iTimeCode)
		{
			//Retrieve Specific UnitTimes Record
			//For specified UnitResponse
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = modGlobal.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_UnitResponseTime " + lUnitResponseID.ToString() + "," + iTimeCode.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					//Load UnitTimes Private Class Variables
					cUTUnitResponseID = Convert.ToInt32(oRec["unit_response_id"]);
					cResponseTime = Convert.ToInt32(oRec["response_time_code"]);
					cActualTime = modGlobal.Clean(oRec["actual_time"]);
					cAmendedTime = modGlobal.Clean(oRec["amended_time"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cReasonAmended = Convert.ToInt32(modGlobal.GetVal(oRec["reason_amended_code"]));
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


		public int GetUnitPersonnelRS(int lUnitResponseID)
		{
			//Retrieve UnitPersonnel Recordset of All Unit Personnel
			//For specified UnitResponse
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = modGlobal.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_UnitResponseUnitPersonnel " + lUnitResponseID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					//Load UnitPersonnel Recordset Private  Variable
					cUnitPersonnel = oRec;
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

		public int GetIncidentUnitPersonnel(int lIncidentID)
		{
			//Retrieve UnitPersonnel Recordset of All Unit Personnel
			//For specified Incident
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = modGlobal.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_IncidentUnitResponsePersonnel " + lIncidentID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					//Load Unit Personnel Recordset Private  Variable
					cUnitPersonnel = oRec;
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

		public int GetPTSPersonnel(string sUnit, string sShiftDate)
		{
			//Retrieve staff and positions for specified Unit, Date
			//From PTSdata database
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_PTSTrainingUnitStaffing '" + sUnit + "','" + sShiftDate + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cUnitPersonnel = oRec;
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

		public string ConvertUnitCode(string sUnit)
		{
			//Convert CAD Unit Code to RMS Unit Code
			string result = "";
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = modGlobal.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_ConvertUnitID '" + sUnit + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					return Convert.ToString(oRec["unit_id"]);
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

		public string ConvertTFDUnitID(string sUnit)
		{
			//Convert CAD TFD Unit Code to RMS Unit Code
			string result = "";
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = modGlobal.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_ConvertTFDUnitID '" + sUnit + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					return Convert.ToString(oRec["unit_id"]);
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

		public int GetUnitDelayRS(int lUnitResponseID)
		{
			//Retrieve UnitDelay Recordset of All Unit Delay
			//For specified UnitResponse
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = modGlobal.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_UnitResponseUnitDelay " + lUnitResponseID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					//Load UnitTimes Recordset Private  Variable
					cUnitDelay = oRec;
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

		public int GetUnitActionRS(int lUnitResponseID)
		{
			//Retrieve UnitAction Recordset of All Unit Action
			//For specified UnitResponse
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = modGlobal.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_UnitResponseUnitAction " + lUnitResponseID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					//Load UnitTimes Recordset Private  Variable
					cUnitAction = oRec;
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

		//Insert Methods
		//!!!  Note:
		//       All Inserts Done using  Class Private Variable Values

		public int AddUnitPersonnel()
		{
			//Add UnitPersonnel Record
			//All fields reference  Class Private Variables
			//Which must be set prior to calling this function

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;
				oCmd.Connection = modGlobal.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spInsert_UnitResponsePersonnel";
				oCmd.ExecuteNonQuery(new object[] { cUPUnitResponseID, cEmployeeID, cPosition, cCasualtyFlag, cExposureFlag });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int AddUnitDelay()
		{
			//Add UnitDelay Record
			//All field reference  Class Private Variables
			//Which must be set prior to calling this function

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;
				oCmd.Connection = modGlobal.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spInsert_UnitResponseDelay";
				oCmd.ExecuteNonQuery(new object[] { cUDUnitResponseID, cDelay });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int AddUnitAction()
		{
			//Add UnitAction Record
			//All fields reference  Class Private Variables
			//Which must be set prior to calling this function

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;
				oCmd.Connection = modGlobal.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spInsert_UnitResponseAction";
				oCmd.ExecuteNonQuery(new object[] { cUAUnitResponseID, cAction });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int AddUnitResponse()
		{
			//Add new UnitResponseRecord
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;
				oCmd.Connection = modGlobal.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spInsert_UnitResponse";
				oCmd.ExecuteNonQuery(new object[] { cIncidentID, cURUnitID, cFlagClearingUnit, cFlagICUnit, Strings.Replace(cUnitNarrative, "'", "''", 1, -1, CompareMethod.Binary) });
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_NewUnitResponse";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				cUnitResponseID = Convert.ToInt32(modGlobal.GetVal(oRec.GetField(0)));
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}
		//Update Methods
		//!!!  Note:
		//       All Updates Done using  Class Private Variable Values

		public int UpdateUnitResponse()
		{
			//Update UnitResponse Record
			//!!! Note: Only IC Unit and Narrative Updated
			//All fields reference  Class Private Variables
			//Which must be set prior to calling this function

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;
				oCmd.Connection = modGlobal.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spUpdate_UnitResponse";
				oCmd.ExecuteNonQuery(new object[] { cUnitResponseID, cFlagICUnit, Strings.Replace(cUnitNarrative, "'", "''", 1, -1, CompareMethod.Binary) });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int AddUnitTimes()
		{
			//Update UnitTimes Record
			//!!! Note: Only AmendedTime & ReasonAmended Updated
			//All fields reference  Class Private Variables
			//Which must be set prior to calling this function

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;
				oCmd.Connection = modGlobal.oIncident;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spInsert_UnitResponseTime " + cUTUnitResponseID.ToString() + "," + cResponseTime.ToString() + ",";
				if (cActualTime == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cActualTime + "',";
				}
				if (cAmendedTime == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cAmendedTime + "',";
				}
				if (cReasonAmended == 0)
				{
					SqlString = SqlString + "NULL";
				}
				else
				{
					SqlString = SqlString + cReasonAmended.ToString();
				}
				oCmd.CommandText = SqlString;
				oCmd.ExecuteNonQuery();
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int UpdateUnitTimes()
		{
			//Update UnitTimes Record
			//!!! Note: Only AmendedTime & ReasonAmended Updated
			//All fields reference  Class Private Variables
			//Which must be set prior to calling this function

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;
				oCmd.Connection = modGlobal.oIncident;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spUpdate_UnitResponseTime " + cUTUnitResponseID.ToString() + "," + cResponseTime.ToString();
				SqlString = SqlString + ",'" + cAmendedTime + "'," + cReasonAmended.ToString();
				oCmd.CommandText = SqlString;
				oCmd.ExecuteNonQuery();
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int UpdateUnitPersonnel()
		{
			//Update UnitPersonnel Record
			//!!! Note: Only Position,CasualtyFlag & ExposureFlag Updated
			//All fields reference  Class Private Variables
			//Which must be set prior to calling this function

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;
				oCmd.Connection = modGlobal.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spUpdate_UnitPersonnel";
				oCmd.ExecuteNonQuery(new object[] { cUPUnitResponseID, cEmployeeID, cPosition, cCasualtyFlag, cExposureFlag });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		//Delete Methods

		public int DeleteUnitPersonnel(ref int lUnitResponseID)
		{
			//Delete  All UnitPersonnel Records for specified UnitResponse
			//!!!Note: FSCasualty or Exposure Reports may exist for
			//         These Employees for this Incident
			//         This needs to be handled prior to executing this Function
			//         Called Stored Procedure does NOT delete related
			//         FSCasualty or Exposure Reports

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spDelete_UnitResponsePersonnel";
				oCmd.ExecuteNonQuery(new object[] { lUnitResponseID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		//Delete All Subtable records for Current UnitResponse

		public int DeleteUnitDelay()
		{
			//Delete all UnitDelay Records for Current UnitResponse
			//!!!Note:  Updates done as two steps:
			//           Delete all Current Records
			//           Add Current Selections

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spDelete_UnitResponseDelay";
				oCmd.ExecuteNonQuery(new object[] { cUnitResponseID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteUnitAction()
		{
			//Delete all UnitAction Records for Current UnitResponse
			//!!!Note:  Updates done as two steps:
			//           Delete all Current Records
			//           Add Current Selections

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spDelete_UnitResponseAction";
				oCmd.ExecuteNonQuery(new object[] { cUnitResponseID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}


		//Inquiry Methods

		public int CheckIC(int lIncidentID, string sUnit)
		{
			//Determine if passed Unit is IC or only Dispatched TFD Unit
			//For this Incident
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = modGlobal.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_FindResponsibleUnit " + lIncidentID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					if (modGlobal.Clean(oRec["unit_id"]) == sUnit)
					{
						return -1;
					}
				}
				//UPGRADE_WARNING: (2065) ADODB.Recordset method oRec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
				oRec = oRec.NextRecordSet();
				if (!oRec.EOF)
				{
					if (modGlobal.Clean(oRec["unit_id"]) == sUnit)
					{
						//UPGRADE_WARNING: (2065) ADODB.Recordset method oRec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
						oRec = oRec.NextRecordSet();
						if (!oRec.EOF)
						{
							if (Convert.ToDouble(oRec["total_tfd"]) == 1)
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



		public int GetUnitResponseTimesReport(int lIncidentID)
		{
			//Retrieve Unit Response Times for Reporting
			//For specified Incident
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = modGlobal.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_UnitResponseTimes " + lIncidentID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cUnitTimes = oRec;
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

		//TransportUnit

		public int GetTranportUnitALSFlag(string sUnitID)
		{
			//Retrieve ALS Flag for specified TFD Transport Unit
			//Return True if ALS, False if BLS
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = modGlobal.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_TransportUnitALSFlag '" + sUnitID + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					if (Convert.ToBoolean(oRec["als_flag"]))
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
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public int GetPTSPersonnelByGroup(string sGroup)
		{
			//Retrieve staff and positions for specified Assignment Group Code
			//From PTSdata database
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_PersonnelByGroupCode '" + sGroup + "' ";
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cUnitPersonnel = oRec;
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