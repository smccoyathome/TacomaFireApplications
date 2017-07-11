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
			_cFireUnitNarrative = null;
			_cTransportUnit = null;
			_cUnitHistory = null;
			cUnitHistoryID = 0;
			cUHUnitID = "";
			cUHActivity = "";
			cUHTime = "";
			cUHEntryType = "";
			cUHTimeType = "";
			cUHEntryTerminal = "";
			cUHEntryOperator = "";
			cUHIncidentNumber = "";
			cUHComments = "";
			cStaffErrorID = 0;
			cSEUnitID = "";
			cSEErrorTime = "";
			cSEEmployeeID = "";
			cSEIncidentID = 0;
			cSEStaffedIn = "";
			_cEmployee = null;
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

		public virtual int? cReasonAmended { get; set; }

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

		//FireUnitNarrative
		public virtual ADORecordSetHelper _cFireUnitNarrative { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cFireUnitNarrative
		{
			get
			{
				if (_cFireUnitNarrative == null)
				{
					_cFireUnitNarrative = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cFireUnitNarrative;
			}
			set
			{
				_cFireUnitNarrative = value;
			}
		}


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


		//UnitHistory
		public virtual ADORecordSetHelper _cUnitHistory { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cUnitHistory
		{
			get
			{
				if (_cUnitHistory == null)
				{
					_cUnitHistory = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cUnitHistory;
			}
			set
			{
				_cUnitHistory = value;
			}
		}

		public virtual int cUnitHistoryID { get; set; }

		public virtual string cUHUnitID { get; set; }

		public virtual string cUHActivity { get; set; }

		public virtual string cUHTime { get; set; }

		public virtual string cUHEntryType { get; set; }

		public virtual string cUHTimeType { get; set; }

		public virtual string cUHEntryTerminal { get; set; }

		public virtual string cUHEntryOperator { get; set; }

		public virtual string cUHIncidentNumber { get; set; }

		public virtual string cUHComments { get; set; }

		//StaffingErrorLog  - (table in PTSData)
		public virtual int cStaffErrorID { get; set; }

		public virtual string cSEUnitID { get; set; }

		public virtual string cSEErrorTime { get; set; }

		public virtual string cSEEmployeeID { get; set; }

		public virtual int cSEIncidentID { get; set; }

		public virtual string cSEStaffedIn { get; set; }

		//Employee Record
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


		public int? ReasonAmended
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



		//FireUnitNarrative
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper FireUnitNarrative
		{
			get
			{
				return cFireUnitNarrative;
			}
			set
			{
				cFireUnitNarrative = value;
			}
		}

		//UnitHistory
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper UnitHistory
		{
			get
			{
				return cUnitHistory;
			}
			set
			{
				cUnitHistory = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int UnitHistoryID
		{
			get
			{
				return cUnitHistoryID;
			}
			set
			{
				cUnitHistoryID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UHUnitID
		{
			get
			{
				return cUHUnitID;
			}
			set
			{
				cUHUnitID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UHActivity
		{
			get
			{
				return cUHActivity;
			}
			set
			{
				cUHActivity = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UHTime
		{
			get
			{
				return cUHTime;
			}
			set
			{
				cUHTime = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UHEntryType
		{
			get
			{
				return cUHEntryType;
			}
			set
			{
				cUHEntryType = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UHTimeType
		{
			get
			{
				return cUHTimeType;
			}
			set
			{
				cUHTimeType = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UHEntryTerminal
		{
			get
			{
				return cUHEntryTerminal;
			}
			set
			{
				cUHEntryTerminal = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UHEntryOperator
		{
			get
			{
				return cUHEntryOperator;
			}
			set
			{
				cUHEntryOperator = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UHIncidentNumber
		{
			get
			{
				return cUHIncidentNumber;
			}
			set
			{
				cUHIncidentNumber = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UHComments
		{
			get
			{
				return cUHComments;
			}
			set
			{
				cUHComments = value;
			}
		}



		//StaffingErrorLog
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public int StaffErrorID
		{
			get
			{
				return cStaffErrorID;
			}
			set
			{
				cStaffErrorID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string SEUnitID
		{
			get
			{
				return cSEUnitID;
			}
			set
			{
				cSEUnitID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string SEErrorTime
		{
			get
			{
				return cSEErrorTime;
			}
			set
			{
				cSEErrorTime = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string SEEmployeeID
		{
			get
			{
				return cSEEmployeeID;
			}
			set
			{
				cSEEmployeeID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int SEIncidentID
		{
			get
			{
				return cSEIncidentID;
			}
			set
			{
				cSEIncidentID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string SEStaffedIn
		{
			get
			{
				return cSEStaffedIn;
			}
			set
			{
				cSEStaffedIn = value;
			}
		}


		//Employee Record
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


		//***************************************
		//**     Public Class Methods          **
		//***************************************
		//Select Methods

		public int TFDUnitListRS()
		{
			//Retrieve Recordset with list of TFD Units
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_UnitTFDList";
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					cUnit = orec;
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
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_Unit '" + sUnitID + "'";
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					//Load Class  Variables
					cUnitID = IncidentMain.Clean(orec["unit_id"]);
					cFacilityID = Convert.ToInt32(orec["facility_id"]);
					cUnitType = Convert.ToInt32(Double.Parse(IncidentMain.Clean(orec["unit_type_code"])));
					cAgencyID = Convert.ToInt32(orec["agency_id"]);
					cUnitName = Convert.ToString(orec["unit_name"]);
					cUnitBattalion = IncidentMain.Clean(orec["unit_battalion"]);
					cUnitConversionCode = IncidentMain.Clean(orec["unit_conversion_code"]);
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
					cUnitPersonnel = orec;
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
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_UnitResponse " + lUnitResponseID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					//Load Class  Variables
					cUnitResponseID = Convert.ToInt32(orec["unit_response_id"]);
					cIncidentID = Convert.ToInt32(orec["incident_id"]);
					cURUnitID = IncidentMain.Clean(orec["unit_id"]);
					cFlagClearingUnit = Convert.ToByte(orec["flag_clearing_unit"]);
					cFlagICUnit = Convert.ToByte(orec["flag_ic_unit"]);
					cUnitNarrative = IncidentMain.Clean(orec["unit_narrative"]);
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
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_UnitResponseCheck " + lIncidentID.ToString() + ",'" + sUnit + "'";
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					return Convert.ToInt32(orec["unit_response_id"]);
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

		public int GetUnitListing(string sStartdate, string sEnddate, string sUnit, int iType, string sBatt, int iStatus)
		{
			//Retrieve Unit Response Listing for given date range
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				result = -1;
				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				//Select Query based on parameters
				if (sUnit == "" && iType == 0 && sBatt == "" && iStatus == 0)
				{
					//No filters
					ocmd.CommandText = "spSelect_UnitRespList1 '" + sStartdate + "','" + sEnddate + "'";
					//** Note: Filter selection Unit or Batt (not both) **
				}
				else if (sUnit != "" && iType == 0 && iStatus == 0)
				{
					//Unit Filter Only
					ocmd.CommandText = "spSelect_UnitRespList2 '" + sStartdate + "','" + sEnddate + "','" + sUnit + "'";
				}
				else if (sUnit != "" && iType != 0 && iStatus == 0)
				{
					//Unit and Type Filter
					ocmd.CommandText = "spSelect_UnitRespList3 '" + sStartdate + "','" + sEnddate + "','" + sUnit + "'," + iType.ToString();
				}
				else if (sUnit != "" && iType != 0 && iStatus != 0)
				{
					//Unit ,Type and Status Filter
					ocmd.CommandText = "spSelect_UnitRespList4 '" + sStartdate + "','" + sEnddate + "','" + sUnit + "'," + iType.ToString() + "," + iStatus.ToString();
				}
				else if (sUnit != "" && iType == 0 && iStatus != 0)
				{
					//Unit and Status Filter
					ocmd.CommandText = "spSelect_UnitRespList5 '" + sStartdate + "','" + sEnddate + "','" + sUnit + "'," + iStatus.ToString();
				}
				else if (sBatt != "" && iType == 0 && iStatus == 0)
				{
					//Batt Filter Only
					ocmd.CommandText = "spSelect_UnitRespList6 '" + sStartdate + "','" + sEnddate + "','" + sBatt + "'";
				}
				else if (sBatt != "" && iType != 0 && iStatus == 0)
				{
					//Batt and Type Filter
					ocmd.CommandText = "spSelect_UnitRespList7 '" + sStartdate + "','" + sEnddate + "','" + sBatt + "'," + iType.ToString();
				}
				else if (sBatt != "" && iType != 0 && iStatus != 0)
				{
					//Batt ,Type and Status Filter
					ocmd.CommandText = "spSelect_UnitRespList8 '" + sStartdate + "','" + sEnddate + "','" + sBatt + "'," + iType.ToString() + "," + iStatus.ToString();
				}
				else if (sBatt != "" && iType == 0 && iStatus != 0)
				{
					//Batt and Status Filter
					ocmd.CommandText = "spSelect_UnitRespList9 '" + sStartdate + "','" + sEnddate + "','" + sBatt + "'," + iStatus.ToString();
				}
				else if (sUnit == "" && sBatt == "" && iType == 0 && iStatus != 0)
				{
					//Status Filter Only
					ocmd.CommandText = "spSelect_UnitRespList10 '" + sStartdate + "','" + sEnddate + "'," + iStatus.ToString();
				}
				else if (sUnit == "" && sBatt == "" && iType != 0 && iStatus == 0)
				{
					//Type Filter Only
					ocmd.CommandText = "spSelect_UnitRespList11 '" + sStartdate + "','" + sEnddate + "'," + iType.ToString();
				}
				else if (sUnit == "" && sBatt == "" && iType != 0 && iStatus != 0)
				{
					//Type and Status Filter
					ocmd.CommandText = "spSelect_UnitRespList12 '" + sStartdate + "','" + sEnddate + "'," + iType.ToString() + "," + iStatus.ToString();
				}
				else
				{
					//Default to basic dates with no filter
					ocmd.CommandText = "spSelect_UnitRespList1 '" + sStartdate + "','" + sEnddate + "'";
				}

				orec = ADORecordSetHelper.Open(ocmd, "");


				if (!orec.EOF)
				{
					cUnitListing = orec;
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
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				result = (true).ToString();
				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_TFDUnit '" + sUnitID + "'";
				orec = ADORecordSetHelper.Open(ocmd, "");


				if (!orec.EOF)
				{
					return Convert.ToString(orec["unit_id"]);
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
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				result = "";
				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_UnitCADCode '" + sUnitID + "'";
				orec = ADORecordSetHelper.Open(ocmd, "");


				if (!orec.EOF)
				{
					return Convert.ToString(orec["unit_conversion_code"]);
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
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_IncidentUnitResponses " + lIncidentID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					//Load UnitResponse Recordset Private  Variable
					cUnitResponse = orec;
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
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_IncidentTransResponse " + lIncidentID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					//Load UnitResponse Recordset Private  Variable
					cUnitResponse = orec;
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
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_IncidentTFDResponses " + lIncidentID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					//Load UnitResponse Recordset Private  Variable
					cUnitResponse = orec;
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
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_UnitResponseUnitTimes " + lUnitResponseID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					//Load UnitTimes Recordset Private  Variable
					cUnitTimes = orec;
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
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_UnitResponseTime " + lUnitResponseID.ToString() + "," + iTimeCode.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					//Load UnitTimes Private Class Variables
					cUTUnitResponseID = Convert.ToInt32(orec["unit_response_id"]);
					cResponseTime = Convert.ToInt32(orec["response_time_code"]);
					cActualTime = IncidentMain.Clean(orec["actual_time"]);
					cAmendedTime = IncidentMain.Clean(orec["amended_time"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cReasonAmended = Convert.ToInt32(IncidentMain.GetVal(orec["reason_amended_code"]));
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
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_UnitResponseUnitPersonnel " + lUnitResponseID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					//Load UnitPersonnel Recordset Private  Variable
					cUnitPersonnel = orec;
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
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_IncidentUnitResponsePersonnel " + lIncidentID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					//Load Unit Personnel Recordset Private  Variable
					cUnitPersonnel = orec;
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
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oPTSdata;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_IncidentUnitStaffing '" + sUnit + "','" + sShiftDate + "'";
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cUnitPersonnel = orec;
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
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_ConvertUnitID '" + sUnit + "'";
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					return Convert.ToString(orec["unit_id"]);
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
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_ConvertTFDUnitID '" + sUnit + "'";
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					return Convert.ToString(orec["unit_id"]);
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
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_UnitResponseUnitDelay " + lUnitResponseID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					//Load UnitTimes Recordset Private  Variable
					cUnitDelay = orec;
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
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_UnitResponseUnitAction " + lUnitResponseID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					//Load UnitTimes Recordset Private  Variable
					cUnitAction = orec;
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
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;
				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spInsert_UnitResponsePersonnel";
				
				ocmd.ExecuteNonQuery(new object[] { cUPUnitResponseID, cEmployeeID, cPosition, cCasualtyFlag, cExposureFlag });
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
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;
				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spInsert_UnitResponseDelay";
				ocmd.ExecuteNonQuery(new object[] { cUDUnitResponseID, cDelay });
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
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;
				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spInsert_UnitResponseAction";
				ocmd.ExecuteNonQuery(new object[] { cUAUnitResponseID, cAction });
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
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				result = -1;
				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spInsert_UnitResponse";
				ocmd.ExecuteNonQuery(new object[] { cIncidentID, cURUnitID, cFlagClearingUnit, cFlagICUnit, Strings.Replace(cUnitNarrative, "'", "''", 1, -1, CompareMethod.Binary) });

                ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_NewUnitResponse";
				orec = ADORecordSetHelper.Open(ocmd, "");
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				cUnitResponseID = Convert.ToInt32(IncidentMain.GetVal(orec.GetField(0)));
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
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;
				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spUpdate_UnitResponse";
				
				ocmd.ExecuteNonQuery(new object[] { cUnitResponseID, cFlagICUnit, Strings.Replace(cUnitNarrative, "'", "''", 1, -1, CompareMethod.Binary) });
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
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;
				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
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
					SqlString = SqlString + (cReasonAmended != null ? cReasonAmended.ToString() : "NULL");
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

		public int UpdateUnitTimes()
		{
			//Update UnitTimes Record
			//!!! Note: Only AmendedTime & ReasonAmended Updated
			//All fields reference  Class Private Variables
			//Which must be set prior to calling this function

			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;
				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spUpdate_UnitResponseTime " + cUTUnitResponseID.ToString() + "," + cResponseTime.ToString();
				SqlString = SqlString + ",'" + cAmendedTime + "'," + (cReasonAmended != null ? cReasonAmended.ToString() : "NULL");
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

		public int UpdateUnitPersonnel()
		{
			//Update UnitPersonnel Record
			//!!! Note: Only Position,CasualtyFlag & ExposureFlag Updated
			//All fields reference  Class Private Variables
			//Which must be set prior to calling this function

			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;
				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spUpdate_UnitPersonnel";
				ocmd.ExecuteNonQuery(new object[] { cUPUnitResponseID, cEmployeeID, cPosition, cCasualtyFlag, cExposureFlag });
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

		public int DeleteUnitTimes(ref int lUnitResponseID)
		{
			//Delete  All UnitTimes Records for specified UnitResponse

			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spDelete_UnitResponseTime";
				ocmd.ExecuteNonQuery(new object[] { lUnitResponseID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}


		public int DeleteUnitPersonnel(ref int lUnitResponseID)
		{
			//Delete  All UnitPersonnel Records for specified UnitResponse
			//!!!Note: FSCasualty or Exposure Reports may exist for
			//         These Employees for this Incident
			//         This needs to be handled prior to executing this Function
			//         Called Stored Procedure does NOT delete related
			//         FSCasualty or Exposure Reports

			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spDelete_UnitResponsePersonnel";

				ocmd.ExecuteNonQuery(new object[] { lUnitResponseID });
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
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spDelete_UnitResponseDelay";
				//UPGRADE_WARNING: (2081) Array has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
				ocmd.ExecuteNonQuery(new object[] { cUnitResponseID });
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
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spDelete_UnitResponseAction";

				ocmd.ExecuteNonQuery(new object[] { cUnitResponseID });
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
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_FindResponsibleUnit " + lIncidentID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					if (IncidentMain.Clean(orec["unit_id"]) == sUnit)
					{
						return -1;
					}
				}
				//UPGRADE_WARNING: (2065) ADODB.Recordset method orec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
				orec = orec.NextRecordSet();
				if (!orec.EOF)
				{
					if (IncidentMain.Clean(orec["unit_id"]) == sUnit)
					{
						//UPGRADE_WARNING: (2065) ADODB.Recordset method orec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
						orec = orec.NextRecordSet();
						if (!orec.EOF)
						{
							if (Convert.ToDouble(orec["total_tfd"]) == 1)
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

		public int GetRespUnitRespID(int lReportLogID)
		{
			//Determine Staffing for Specified Report
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;
			TFDIncident.clsReportLog ReportLog = Container.Resolve< clsReportLog>();

			try
			{

				ReportLog.GetReportLog(lReportLogID);

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_ResponsibleUnitPersonnel " + ReportLog.RLIncidentID.ToString() + ",'" + ReportLog.ResponsibleUnit + "'";
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					return Convert.ToInt32(orec["unit_response_id"]);
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
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_UnitResponseTimes " + lIncidentID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					cUnitTimes = orec;
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

		public int GetUnitFireNarratives(int lIncidentID)
		{
			//Retrieve Unit Narration text for Fire Reporting
			//For specified Incident
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_FireUnitNarratives " + lIncidentID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					cFireUnitNarrative = orec;
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
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_TransportUnitALSFlag '" + sUnitID + "'";
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					if (Convert.ToBoolean(orec["als_flag"]))
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

		public int GetCPFRUnit(string sUnitID)
		{

			//Validate UnitID as Central Pierce Unit
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				result = -1;
				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_CPFRUnit '" + sUnitID + "'";
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (orec.EOF)
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

		public int ProcessCPUnit(int lIncidentID, int lUnitID)
		{

			//Create Central Pierce Fire & Rescue Unit extract file

			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			TFDIncident.clsIncident cIncident = Container.Resolve< clsIncident>();
			string BackupFilePath = "", FilePath = "", Fileline = "";
			string Header01 = "";
			string Dispatch = "";
			string Enroute = "";
			string Onscene = "";
			string Transport = "";
			string TranComplete = "";
			string Available = "";
			int ReturnCode = 0;




			try
			{
				Dispatch = new System.String(' ', 10) + Strings.Chr(28).ToString() + new System.String(' ', 8);
				Enroute = new System.String(' ', 10) + Strings.Chr(28).ToString() + new System.String(' ', 8);
				Onscene = new System.String(' ', 10) + Strings.Chr(28).ToString() + new System.String(' ', 8);
				Transport = new System.String(' ', 10) + Strings.Chr(28).ToString() + new System.String(' ', 8);
				TranComplete = new System.String(' ', 10) + Strings.Chr(28).ToString() + new System.String(' ', 8);
				Available = new System.String(' ', 10) + Strings.Chr(28).ToString() + new System.String(' ', 8);


				result = -1;
				if (~cIncident.GetIncident(lIncidentID) != 0)
				{
					return 0;
				}
				if (~GetUnitResponse(lUnitID) != 0)
				{
					return 0;
				}
				if (~GetUnitTimesRS(lUnitID) != 0)
				{
					return 0;
				}
				else
				{

					while(!cUnitTimes.EOF)
					{
						switch(Convert.ToInt32(cUnitTimes["response_time_code"]))
						{
							case 3 :
								Dispatch = Convert.ToDateTime(cUnitTimes["actual_time"]).ToString("MM/dd/yyyy");
								Dispatch = Dispatch + Strings.Chr(28).ToString();
								Dispatch = Dispatch + Convert.ToDateTime(cUnitTimes["actual_time"]).ToString("HH:NN:SS");
								if (Strings.Len(Dispatch) < 19)
								{
									Dispatch = Dispatch + new System.String(' ', 19 - Strings.Len(Dispatch));
								}
								break;
							case 4 :
								Enroute = Convert.ToDateTime(cUnitTimes["actual_time"]).ToString("MM/dd/yyyy");
								Enroute = Enroute + Strings.Chr(28).ToString();
								Enroute = Enroute + Convert.ToDateTime(cUnitTimes["actual_time"]).ToString("HH:NN:SS");
								if (Strings.Len(Enroute) < 19)
								{
									Enroute = Enroute + new System.String(' ', 19 - Strings.Len(Enroute));
								}
								break;
							case 5 :
								Onscene = Convert.ToDateTime(cUnitTimes["actual_time"]).ToString("MM/dd/yyyy");
								Onscene = Onscene + Strings.Chr(28).ToString();
								Onscene = Onscene + Convert.ToDateTime(cUnitTimes["actual_time"]).ToString("HH:NN:SS");
								if (Strings.Len(Onscene) < 19)
								{
									Onscene = Onscene + new System.String(' ', 19 - Strings.Len(Onscene));
								}
								break;
							case 6 :
								Transport = Convert.ToDateTime(cUnitTimes["actual_time"]).ToString("MM/dd/yyyy");
								Transport = Transport + Strings.Chr(28).ToString();
								Transport = Transport + Convert.ToDateTime(cUnitTimes["actual_time"]).ToString("HH:NN:SS");
								if (Strings.Len(Transport) < 19)
								{
									Transport = Transport + new System.String(' ', 19 - Strings.Len(Transport));
								}
								break;
							case 7 :
								TranComplete = Convert.ToDateTime(cUnitTimes["actual_time"]).ToString("MM/dd/yyyy");
								TranComplete = TranComplete + Strings.Chr(28).ToString();
								TranComplete = TranComplete + Convert.ToDateTime(cUnitTimes["actual_time"]).ToString("HH:NN:SS");
								if (Strings.Len(TranComplete) < 19)
								{
									TranComplete = TranComplete + new System.String(' ', 19 - Strings.Len(TranComplete));
								}
								break;
							case 8 :
								Available = Convert.ToDateTime(cUnitTimes["actual_time"]).ToString("MM/dd/yyyy");
								Available = Available + Strings.Chr(28).ToString();
								Available = Available + Convert.ToDateTime(cUnitTimes["actual_time"]).ToString("HH:NN:SS");
								if (Strings.Len(Available) < 19)
								{
									Available = Available + new System.String(' ', 19 - Strings.Len(Available));
								}
								break;
						}
						cUnitTimes.MoveNext();
					};
				}
				Header01 = Strings.Chr(1).ToString() + "INC02" + Strings.Chr(28).ToString() + new System.String(' ', 4) + Strings.Chr(28).ToString() + DateTime.Now.ToString("yyyyMMddHHNNSS");
				Header01 = Header01 + Strings.Chr(28).ToString() + new System.String(' ', 1) + Strings.Chr(28).ToString() + Strings.Chr(28).ToString() + new System.String(' ', 12);
				Header01 = Header01 + Strings.Chr(28).ToString() + Strings.Chr(28).ToString() + Strings.Chr(28).ToString() + Strings.Chr(28).ToString() + Strings.Chr(2).ToString();

				//Create File, Write File Header
				Fileline = "";
				FilePath = IncidentMain.CPFILEPATH;
				BackupFilePath = IncidentMain.CPFILEBACKUP;

				FilePath = FilePath + "inc02_cp" + cIncident.IncidentNumber + "_" + cURUnitID.Trim() + ".txt";
				BackupFilePath = BackupFilePath + "inc02_cp" + cIncident.IncidentNumber + "_" + cURUnitID.Trim() + ".txt";
				//    Set FSO = Nothing
				//    Set TextStm = Nothing
				//
				//    Set FSO = CreateObject("Scripting.FileSystemObject")
				//    Set TextStm = FSO.CreateTextFile(FilePath)

				Fileline = Header01;
				Fileline = Fileline + "06   " + Strings.Chr(28).ToString();
				Fileline = Fileline + "CP";
				Fileline = Fileline + cIncident.IncidentNumber;
				Fileline = Fileline + Strings.Chr(28).ToString();
				Fileline = Fileline + cURUnitID.Trim() + new System.String(' ', 6 - Strings.Len(cURUnitID.Trim()));
				Fileline = Fileline + Strings.Chr(28).ToString();
				Fileline = Fileline + Dispatch;
				Fileline = Fileline + Strings.Chr(28).ToString();
				Fileline = Fileline + Enroute;
				Fileline = Fileline + Strings.Chr(28).ToString();
				Fileline = Fileline + Onscene;
				Fileline = Fileline + Strings.Chr(28).ToString();
				Fileline = Fileline + Transport;
				Fileline = Fileline + Strings.Chr(28).ToString();
				Fileline = Fileline + TranComplete;
				Fileline = Fileline + Strings.Chr(28).ToString();
				Fileline = Fileline + Available;
				Fileline = Fileline + Strings.Chr(28).ToString() + Strings.Chr(28).ToString() + Strings.Chr(28).ToString();
				Fileline = Fileline + cURUnitID.Trim() + new System.String(' ', 6 - Strings.Len(cURUnitID.Trim()));
				Fileline = Fileline + Strings.Chr(28).ToString();
				Fileline = Fileline + new System.String(' ', 6);
				Fileline = Fileline + Strings.Chr(28).ToString() + Strings.Chr(28).ToString() + Strings.Chr(28).ToString() + Strings.Chr(28).ToString() + Strings.Chr(28).ToString();
				//map page
				Fileline = Fileline + new System.String(' ', 11) + Strings.Chr(28).ToString();
				//run card
				Fileline = Fileline + new System.String(' ', 7) + Strings.Chr(28).ToString() + Strings.Chr(3).ToString();

				//    TextStm.Write (Fileline)
				//    If WriteCPUnit(Fileline, cURUnitID) Then
				//        ProcessCPUnit = True
				//    Else
				//        ProcessCPUnit = False
				//    End If
				ReturnCode = WriteCPUnit(Fileline, FilePath, BackupFilePath);

				switch(ReturnCode)
				{
					case 0 :
						return -1;
					case 3 :
						return IncidentMain.CPBACKUP;
					default:
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

		public int AddUnitHistory()
		{
			//Add Unit History Record

			//All fields reference  Class Private Variables
			//Which must be set prior to calling this function

			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;
				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spInsert_UnitHistory '" + cUHUnitID + "','" + cUHActivity + "','";
				SqlString = SqlString + cUHTime + "','" + cUHEntryType + "','";
				SqlString = SqlString + cUHTimeType + "','" + cUHEntryTerminal + "','";
				SqlString = SqlString + cUHEntryOperator + "','" + cUHIncidentNumber + "','";
				SqlString = SqlString + cUHComments + "'";
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

		public int ClearUnitHistory()
		{
			//Clear Unit History Record
			cUHUnitID = "";
			cUHActivity = "";
			cUHTime = "";
			cUHEntryType = "";
			cUHTimeType = "";
			cUHEntryTerminal = "";
			cUHEntryOperator = "";
			cUHIncidentNumber = "";
			cUHComments = "";

			return 0;
		}


		public int AddStaffingErrorLog()
		{
			//Add Staffing Error Log Record

			//All fields reference  Class Private Variables
			//Which must be set prior to calling this function

			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;
				ocmd.Connection = IncidentMain.oPTSdata;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spInsert_StaffingErrorLog '" + cSEUnitID + "','" + cSEErrorTime + "','";
				SqlString = SqlString + cSEEmployeeID + "'," + cSEIncidentID.ToString() + ",'";
				SqlString = SqlString + cSEStaffedIn + "'";
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

		public int GetAnyUserInfo(string sEmpID)
		{
			//Get Recordset of Requested Employee Information
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				result = -1;
				ocmd.Connection = IncidentMain.oPTSdata;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_Employee '" + sEmpID + "'";
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (orec.EOF)
				{
					result = 0;
				}
			}
			catch
			{

				return 0;
			}
			return result;
		}



		public int WriteCPUnit(string sFileline, string sFilePath, string sBackUpPath)
		{
		    //Write CPFR data record on their server , if error in process then
		    //Write the record to a backup folder on server
		    //        Dim FilePath, BackupFilePath As String
		    int result = 0;
		    object FSO = null;
		    System.IO.StreamWriter TextStm = null;

			try
			{

			    result = -1;
			    //    FilePath = CPFILEPATH
			    //    BackupFilePath = CPFILEBACKUP
			    //    FilePath = FilePath & "inc02_cp" & cIncident.IncidentNumber & "_" & Trim$(sUnit) & ".txt"
			    //    BackupFilePath = BackupFilePath & "inc02_cp" & cIncident.IncidentNumber & "_" & Trim$(sUnit) & ".txt"
			    FSO = null;
			    TextStm = null;
			    FSO = new System.Object();
			    TextStm = System.IO.File.CreateText(sFilePath);
			    TextStm.Write(sFileline);
			    TextStm.Flush();
			    TextStm.Close();
			    //UPGRADE_TODO: (1067) Member CreateTextFile is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			    //TextStm = FSO.CreateTextFile(sFilePath);
			    //UPGRADE_TODO: (1067) Member Write is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			    //TextStm.Write(sFileline);
			}
			catch
			{

			    //First try writing to back up file path
			    try
			    {

			        FSO = null;
			        TextStm = null;
			        FSO = new System.Object();
			        TextStm = System.IO.File.CreateText(sBackUpPath);
			        TextStm.Write(sFileline);
			        TextStm.Flush();
			        TextStm.Close();
			        //UPGRADE_TODO: (1067) Member CreateTextFile is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			        //TextStm = FSO.CreateTextFile(sBackUpPath);
			        //UPGRADE_TODO: (1067) Member Write is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			        //TextStm.Write(sFileline);
			        return IncidentMain.CPBACKUP;
			    }
			    catch
			    {

			        result = 0;
			        //UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
			        UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			    }
			}
			return result;
	}

		public int GetReportingUnit(string sUnitID)
{
	//Determine if Unit should generate an IRS reportlog record
	int result = 0;
	DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
	ADORecordSetHelper orec = null;

	try
	{

		ocmd.Connection = IncidentMain.oIncident;
		ocmd.CommandType = CommandType.Text;
		ocmd.CommandText = "spSelect_ReportingUnit '" + sUnitID + "'";
		orec = ADORecordSetHelper.Open(ocmd, "");
		if (!orec.EOF)
		{
			//Set return values
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

		public int Get40hrUnit(string sUnitID)
		{
			//Determine if Unit is 40 hr staff - Admin and Investigators
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_40hrStaff '" + sUnitID + "'";
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					//Set return values
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