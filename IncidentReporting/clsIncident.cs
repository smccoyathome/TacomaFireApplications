using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.Globalization;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident
{

	public class clsIncident
		: UpgradeHelpers.Interfaces.IDependentModel, UpgradeHelpers.Interfaces.ICreatesObjects, UpgradeHelpers
		.Interfaces.IInteractsWithView, UpgradeHelpers.Interfaces.IInitializableCommon, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(clsIncident));
		}

		void UpgradeHelpers.Interfaces.IInitializableCommon.Common()
		{
			_cIncidentRS = null;
			cIncidentID = 0;
			cAgencyID = 0;
			cIncidentNumber = "";
			cDateIncidentCreated = "";
			cDateReceivedE911 = "";
			cDateFirstUnitDispatched = "";
			cDateFirstUnitEnroute = "";
			cDateFirstUnitOnscene = "";
			cDateFirstUnitTransport = "";
			cDateFirstUnitTransComplete = "";
			cDateIncidentClosed = "";
			cDateIncidentFinalClosed = "";
			cReportingName = "";
			cReportingAddress = "";
			cReportingPhone = "";
			cLocation = "";
			cCommonPlace = "";
			cX_coord = 0;
			cY_coord = 0;
			cCensus = 0;
			cFlagMutualAid = 0;
			cFlagLocationVerify = 0;
			cFlagCatchUp = 0;
			cFlagLAR = 0;
			cCityCode = "";
			cGeoLocation = "";
			cDispatchTerminal_1 = "";
			cDispatcher1ID = "";
			cDispatchTerminal_2 = "";
			cDispatcher2ID = "";
			cInitialIncidentType = 0;
			cFinalIncidentType = 0;
			cInitialAlarmLevel = "";
			cFinalAlarmLevel = "";
			cReportDisposition = "";
			cFirstUnitDispatched = "";
			cFirstAssistingUnit = "";
			cClearingUnit = "";
			cNumberOfPatients = 0;
			cTransferStatus = "";
			cIncidentShift = "";
			cCADInitialType = "";
			cCADFinalType = "";
			cDispatched = 0;
			cALS_BLS = "";
			cIncLat = "";
			cIncLong = "";
			cLLIncidentID = 0;
			cLLlat = "";
			cLLlong = "";
			cCADType = "";
			_cEventRS = null;
			cEventID = 0;
			cEventIncidentID = 0;
			cEventNumber = 0;
			cEventType = "";
			cEventTime = "";
			cFlagMDT = 0;
			cSendTerminal = "";
			cSendOpID = "";
			cReceiveTerminal = "";
			cEventText = "";
			_cIncidentName = null;
			cNameID = 0;
			cNameIncidentID = 0;
			cNameFirst = "";
			cNameLast = "";
			cNameMI = "";
			cNameBusiness = "";
			cBirthdate = "";
			cHomePhone = "";
			cWorkPhone = "";
			cWorkPlace = "";
			cGender = 0;
			cRaceCode = 0;
			cEthnicityCode = 0;
			cHouseNumber = "";
			cPrefix = "";
			cStreet = "";
			cStreetType = "";
			cSuffix = "";
			cCity = "";
			cZipcode = "";
			cStateCode = "";
			cIncidentRoleCode = 0;
			cNameLastUpdate = "";
			cLastUpdateBy = "";
			_cIncidentNarration = null;
			cNarrationID = 0;
			cNarrationIncidentID = 0;
			cReportType = 0;
			cNarrationText = "";
			cNarrationBy = "";
			cNarrationLastUpdate = "";
			_cIncidentAddressCorrection = null;
			cIACIncidentID = 0;
			cIACHouseNumber = "";
			cIACPrefix = "";
			cIACStreet = "";
			cIACStreetType = "";
			cIACSuffix = "";
			cIACCityCode = "";
			cIACAmendedLocation = "";
			_cIncidentCrossRef = null;
			cXRefPrimaryID = 0;
			cXRefReferenceID = 0;
			cXRefNumber = "";
			_cIncidentSecurity = null;
			cCPType = "";
			cCPHouse = "";
			cCPStreet = "";
			cCPStreetType = "";
			cCPPrefix = "";
			cCPSuffix = "";
			cCPAptNo = "";
			cCPCrossStreet = "";
			cCPCrossType = "";
			cCPCrossPrefix = "";
			cCPCrossSuffix = "";
		}

		//********************************************************
		//**    Incident Class                                  **
		//********************************************************
		//**    Methods                                         **
		//**----------------------------------------------------**
		//** GetIncident(lIncidentID As Long)                   **
		//**     Returns Requested Incident Record              **
		//**
		//** UpdateFinalType()                                  **
		//**     Updates Final Incident Type Code               **
		//**
		//** Clear()                                            **
		//**     Clears all Private Variables                   **
		//********************************************************


		//********************************************************
		//**             Private Class Variables                **
		//********************************************************

		//Incident
		public virtual ADORecordSetHelper _cIncidentRS { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cIncidentRS
		{
			get
			{
				if (_cIncidentRS == null)
				{
					_cIncidentRS = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cIncidentRS;
			}
			set
			{
				_cIncidentRS = value;
			}
		}

		public virtual int cIncidentID { get; set; }

		public virtual int cAgencyID { get; set; }

		public virtual string cIncidentNumber { get; set; }

		public virtual string cDateIncidentCreated { get; set; }

		public virtual string cDateReceivedE911 { get; set; }

		public virtual string cDateFirstUnitDispatched { get; set; }

		public virtual string cDateFirstUnitEnroute { get; set; }

		public virtual string cDateFirstUnitOnscene { get; set; }

		public virtual string cDateFirstUnitTransport { get; set; }

		public virtual string cDateFirstUnitTransComplete { get; set; }

		public virtual string cDateIncidentClosed { get; set; }

		public virtual string cDateIncidentFinalClosed { get; set; }

		public virtual string cReportingName { get; set; }

		public virtual string cReportingAddress { get; set; }

		public virtual string cReportingPhone { get; set; }

		public virtual string cLocation { get; set; }

		public virtual string cCommonPlace { get; set; }

		public virtual double cX_coord { get; set; }

		public virtual double cY_coord { get; set; }

		public virtual int cCensus { get; set; }

		public virtual byte cFlagMutualAid { get; set; }

		public virtual byte cFlagLocationVerify { get; set; }

		public virtual byte cFlagCatchUp { get; set; }

		public virtual byte cFlagLAR { get; set; }

		public virtual string cCityCode { get; set; }

		public virtual string cGeoLocation { get; set; }

		public virtual string cDispatchTerminal_1 { get; set; }

		public virtual string cDispatcher1ID { get; set; }

		public virtual string cDispatchTerminal_2 { get; set; }

		public virtual string cDispatcher2ID { get; set; }

		public virtual int cInitialIncidentType { get; set; }

		public virtual int cFinalIncidentType { get; set; }

		public virtual string cInitialAlarmLevel { get; set; }

		public virtual string cFinalAlarmLevel { get; set; }

		public virtual string cReportDisposition { get; set; }

		public virtual string cFirstUnitDispatched { get; set; }

		public virtual string cFirstAssistingUnit { get; set; }

		public virtual string cClearingUnit { get; set; }

		public virtual int cNumberOfPatients { get; set; }

		public virtual string cTransferStatus { get; set; }

		public virtual string cIncidentShift { get; set; }

		public virtual string cCADInitialType { get; set; }

		public virtual string cCADFinalType { get; set; }

		public virtual byte cDispatched { get; set; }

		public virtual string cALS_BLS { get; set; }

		public virtual string cIncLat { get; set; }

		public virtual string cIncLong { get; set; }

		//Incident - LAT,LONG only
		public virtual int cLLIncidentID { get; set; }

		public virtual string cLLlat { get; set; }

		public virtual string cLLlong { get; set; }

		//Incident - CAD dispatch type description
		public virtual string cCADType { get; set; }

		//IncidentEvent
		public virtual ADORecordSetHelper _cEventRS { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cEventRS
		{
			get
			{
				if (_cEventRS == null)
				{
					_cEventRS = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cEventRS;
			}
			set
			{
				_cEventRS = value;
			}
		}

		public virtual int cEventID { get; set; }

		public virtual int cEventIncidentID { get; set; }

		public virtual int cEventNumber { get; set; }

		public virtual string cEventType { get; set; }

		public virtual string cEventTime { get; set; }

		public virtual byte cFlagMDT { get; set; }

		public virtual string cSendTerminal { get; set; }

		public virtual string cSendOpID { get; set; }

		public virtual string cReceiveTerminal { get; set; }

		public virtual string cEventText { get; set; }

		//IncidentName
		public virtual ADORecordSetHelper _cIncidentName { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cIncidentName
		{
			get
			{
				if (_cIncidentName == null)
				{
					_cIncidentName = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cIncidentName;
			}
			set
			{
				_cIncidentName = value;
			}
		}

		public virtual int cNameID { get; set; }

		public virtual int cNameIncidentID { get; set; }

		public virtual string cNameFirst { get; set; }

		public virtual string cNameLast { get; set; }

		public virtual string cNameMI { get; set; }

		public virtual string cNameBusiness { get; set; }

		public virtual string cBirthdate { get; set; }

		public virtual string cHomePhone { get; set; }

		public virtual string cWorkPhone { get; set; }

		public virtual string cWorkPlace { get; set; }

		public virtual int cGender { get; set; }

		public virtual int cRaceCode { get; set; }

		public virtual int cEthnicityCode { get; set; }

		public virtual string cHouseNumber { get; set; }

		public virtual string cPrefix { get; set; }

		public virtual string cStreet { get; set; }

		public virtual string cStreetType { get; set; }

		public virtual string cSuffix { get; set; }

		public virtual string cCity { get; set; }

		public virtual string cZipcode { get; set; }

		public virtual string cStateCode { get; set; }

		public virtual int cIncidentRoleCode { get; set; }

		public virtual string cNameLastUpdate { get; set; }

		public virtual string cLastUpdateBy { get; set; }

		//IncidentNarration
		public virtual ADORecordSetHelper _cIncidentNarration { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cIncidentNarration
		{
			get
			{
				if (_cIncidentNarration == null)
				{
					_cIncidentNarration = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cIncidentNarration;
			}
			set
			{
				_cIncidentNarration = value;
			}
		}

		public virtual int cNarrationID { get; set; }

		public virtual int cNarrationIncidentID { get; set; }

		public virtual int cReportType { get; set; }

		public virtual string cNarrationText { get; set; }

		public virtual string cNarrationBy { get; set; }

		public virtual string cNarrationLastUpdate { get; set; }

		//IncidentAddressCorrection
		public virtual ADORecordSetHelper _cIncidentAddressCorrection { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cIncidentAddressCorrection
		{
			get
			{
				if (_cIncidentAddressCorrection == null)
				{
					_cIncidentAddressCorrection = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cIncidentAddressCorrection;
			}
			set
			{
				_cIncidentAddressCorrection = value;
			}
		}

		public virtual int cIACIncidentID { get; set; }

		public virtual string cIACHouseNumber { get; set; }

		public virtual string cIACPrefix { get; set; }

		public virtual string cIACStreet { get; set; }

		public virtual string cIACStreetType { get; set; }

		public virtual string cIACSuffix { get; set; }

		public virtual string cIACCityCode { get; set; }

		public virtual string cIACAmendedLocation { get; set; }

		//IncidentCrossRef
		public virtual ADORecordSetHelper _cIncidentCrossRef { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cIncidentCrossRef
		{
			get
			{
				if (_cIncidentCrossRef == null)
				{
					_cIncidentCrossRef = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cIncidentCrossRef;
			}
			set
			{
				_cIncidentCrossRef = value;
			}
		}

		public virtual int cXRefPrimaryID { get; set; }

		public virtual int cXRefReferenceID { get; set; }

		public virtual string cXRefNumber { get; set; }

		//IncidentSecurity
		public virtual ADORecordSetHelper _cIncidentSecurity { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cIncidentSecurity
		{
			get
			{
				if (_cIncidentSecurity == null)
				{
					_cIncidentSecurity = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cIncidentSecurity;
			}
			set
			{
				_cIncidentSecurity = value;
			}
		}


		//Central Pierce Address Variables
		public virtual string cCPType { get; set; }

		public virtual string cCPHouse { get; set; }

		public virtual string cCPStreet { get; set; }

		public virtual string cCPStreetType { get; set; }

		public virtual string cCPPrefix { get; set; }

		public virtual string cCPSuffix { get; set; }

		public virtual string cCPAptNo { get; set; }

		public virtual string cCPCrossStreet { get; set; }

		public virtual string cCPCrossType { get; set; }

		public virtual string cCPCrossPrefix { get; set; }

		public virtual string cCPCrossSuffix { get; set; }

		//***************************************************
		//**         Class Public Properties               **
		//***************************************************

		//Incident
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper IncidentRS
		{
			get
			{
				return cIncidentRS;
			}
			set
			{
				cIncidentRS = value;
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


		public string IncidentNumber
		{
			get
			{
				return cIncidentNumber;
			}
			set
			{
				cIncidentNumber = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string DateIncidentCreated
		{
			get
			{
				return cDateIncidentCreated;
			}
			set
			{
				cDateIncidentCreated = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string DateReceivedE911
		{
			get
			{
				return cDateReceivedE911;
			}
			set
			{
				cDateReceivedE911 = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string DateFirstUnitDispatched
		{
			get
			{
				return cDateFirstUnitDispatched;
			}
			set
			{
				cDateFirstUnitDispatched = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string DateFirstUnitEnroute
		{
			get
			{
				return cDateFirstUnitEnroute;
			}
			set
			{
				cDateFirstUnitEnroute = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string DateFirstUnitOnscene
		{
			get
			{
				return cDateFirstUnitOnscene;
			}
			set
			{
				cDateFirstUnitOnscene = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string DateFirstUnitTransport
		{
			get
			{
				return cDateFirstUnitTransport;
			}
			set
			{
				cDateFirstUnitTransport = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string DateFirstUnitTransComplete
		{
			get
			{
				return cDateFirstUnitTransComplete;
			}
			set
			{
				cDateFirstUnitTransComplete = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string DateIncidentClosed
		{
			get
			{
				return cDateIncidentClosed;
			}
			set
			{
				cDateIncidentClosed = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string DateIncidentFinalClosed
		{
			get
			{
				return cDateIncidentFinalClosed;
			}
			set
			{
				cDateIncidentFinalClosed = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string ReportingName
		{
			get
			{
				return cReportingName;
			}
			set
			{
				cReportingName = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string ReportingAddress
		{
			get
			{
				return cReportingAddress;
			}
			set
			{
				cReportingAddress = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string ReportingPhone
		{
			get
			{
				return cReportingPhone;
			}
			set
			{
				cReportingPhone = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string Location
		{
			get
			{
				return cLocation;
			}
			set
			{
				cLocation = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string CommonPlace
		{
			get
			{
				return cCommonPlace;
			}
			set
			{
				cCommonPlace = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public double X_Coord
		{
			get
			{
				return cX_coord;
			}
			set
			{
				cX_coord = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int Census
		{
			get
			{
				return cCensus;
			}
			set
			{
				cCensus = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public double Y_Coord
		{
			get
			{
				return cY_coord;
			}
			set
			{
				cY_coord = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte FlagMutualAid
		{
			get
			{
				return cFlagMutualAid;
			}
			set
			{
				cFlagMutualAid = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte FlagLocationVerify
		{
			get
			{
				return cFlagLocationVerify;
			}
			set
			{
				cFlagLocationVerify = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte FlagCatchUp
		{
			get
			{
				return cFlagCatchUp;
			}
			set
			{
				cFlagCatchUp = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte FlagLAR
		{
			get
			{
				return cFlagLAR;
			}
			set
			{
				cFlagLAR = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string CityCode
		{
			get
			{
				return cCityCode;
			}
			set
			{
				cCityCode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string GeoLocation
		{
			get
			{
				return cGeoLocation;
			}
			set
			{
				cGeoLocation = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string DispatchTerminal_1
		{
			get
			{
				return cDispatchTerminal_1;
			}
			set
			{
				cDispatchTerminal_1 = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string DispatchTerminal_2
		{
			get
			{
				return cDispatchTerminal_2;
			}
			set
			{
				cDispatchTerminal_2 = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string Dispatcher1ID
		{
			get
			{
				return cDispatcher1ID;
			}
			set
			{
				cDispatcher1ID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string Dispatcher2ID
		{
			get
			{
				return cDispatcher2ID;
			}
			set
			{
				cDispatcher2ID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int InitialIncidentType
		{
			get
			{
				return cInitialIncidentType;
			}
			set
			{
				cInitialIncidentType = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int FinalIncidentType
		{
			get
			{
				return cFinalIncidentType;
			}
			set
			{
				cFinalIncidentType = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string InitialAlarmLevel
		{
			get
			{
				return cInitialAlarmLevel;
			}
			set
			{
				cInitialAlarmLevel = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string FinalAlarmLevel
		{
			get
			{
				return cFinalAlarmLevel;
			}
			set
			{
				cFinalAlarmLevel = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string ReportDisposition
		{
			get
			{
				return cReportDisposition;
			}
			set
			{
				cReportDisposition = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string FirstUnitDispatched
		{
			get
			{
				return cFirstUnitDispatched;
			}
			set
			{
				cFirstUnitDispatched = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string FirstAssistingUnit
		{
			get
			{
				return cFirstAssistingUnit;
			}
			set
			{
				cFirstAssistingUnit = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string ClearingUnit
		{
			get
			{
				return cClearingUnit;
			}
			set
			{
				cClearingUnit = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int NumberOfPatients
		{
			get
			{
				return cNumberOfPatients;
			}
			set
			{
				cNumberOfPatients = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string TransferStatus
		{
			get
			{
				return cTransferStatus;
			}
			set
			{
				cTransferStatus = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string IncidentShift
		{
			get
			{
				return cIncidentShift;
			}
			set
			{
				cIncidentShift = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string CADInitialType
		{
			get
			{
				return cCADInitialType;
			}
			set
			{
				cCADInitialType = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string CADFinalType
		{
			get
			{
				return cCADFinalType;
			}
			set
			{
				cCADFinalType = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte Dispatched
		{
			get
			{
				return cDispatched;
			}
			set
			{
				cDispatched = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string ALS_BLS
		{
			get
			{
				return cALS_BLS;
			}
			set
			{
				cALS_BLS = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string IncLat
		{
			get
			{
				return cIncLat;
			}
			set
			{
				cIncLat = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string IncLong
		{
			get
			{
				return cIncLong;
			}
			set
			{
				cIncLong = value;
			}
		}


		//CAD Type description
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]

		public string CADType
		{
			get
			{
				return cCADType;
			}
			set
			{
				cCADType = value;
			}
		}




		//IncidentEvent
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper EventRS
		{
			get
			{
				return cEventRS;
			}
			set
			{
				cEventRS = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int EventID
		{
			get
			{
				return cEventID;
			}
			set
			{
				cEventID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int EventIncidentID
		{
			get
			{
				return cEventIncidentID;
			}
			set
			{
				cEventIncidentID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int EventNumber
		{
			get
			{
				return cEventNumber;
			}
			set
			{
				cEventNumber = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string EventType
		{
			get
			{
				return cEventType;
			}
			set
			{
				cEventType = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string EventTime
		{
			get
			{
				return cEventTime;
			}
			set
			{
				cEventTime = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte FlagMDT
		{
			get
			{
				return cFlagMDT;
			}
			set
			{
				cFlagMDT = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string SendTerminal
		{
			get
			{
				return cSendTerminal;
			}
			set
			{
				cSendTerminal = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string SendOpID
		{
			get
			{
				return cSendOpID;
			}
			set
			{
				cSendOpID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string ReceiveTerminal
		{
			get
			{
				return cReceiveTerminal;
			}
			set
			{
				cReceiveTerminal = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string EventText
		{
			get
			{
				return cEventText;
			}
			set
			{
				cEventText = value;
			}
		}


		//IncidentName
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper IncidentName
		{
			get
			{
				return cIncidentName;
			}
			set
			{
				cIncidentName = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int NameID
		{
			get
			{
				return cNameID;
			}
			set
			{
				cNameID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int NameIncidentID
		{
			get
			{
				return cNameIncidentID;
			}
			set
			{
				cNameIncidentID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string NameFirst
		{
			get
			{
				return cNameFirst;
			}
			set
			{
				cNameFirst = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string NameLast
		{
			get
			{
				return cNameLast;
			}
			set
			{
				cNameLast = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string NameMI
		{
			get
			{
				return cNameMI;
			}
			set
			{
				cNameMI = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string NameBusiness
		{
			get
			{
				return cNameBusiness;
			}
			set
			{
				cNameBusiness = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string Birthdate
		{
			get
			{
				return cBirthdate;
			}
			set
			{
				cBirthdate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string HomePhone
		{
			get
			{
				return cHomePhone;
			}
			set
			{
				cHomePhone = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string WorkPhone
		{
			get
			{
				return cWorkPhone;
			}
			set
			{
				cWorkPhone = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string WorkPlace
		{
			get
			{
				return cWorkPlace;
			}
			set
			{
				cWorkPlace = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int Gender
		{
			get
			{
				return cGender;
			}
			set
			{
				cGender = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int RaceCode
		{
			get
			{
				return cRaceCode;
			}
			set
			{
				cRaceCode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int EthnicityCode
		{
			get
			{
				return cEthnicityCode;
			}
			set
			{
				cEthnicityCode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string HouseNumber
		{
			get
			{
				return cHouseNumber;
			}
			set
			{
				cHouseNumber = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string Prefix
		{
			get
			{
				return cPrefix;
			}
			set
			{
				cPrefix = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string Street
		{
			get
			{
				return cStreet;
			}
			set
			{
				cStreet = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string StreetType
		{
			get
			{
				return cStreetType;
			}
			set
			{
				cStreetType = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string Suffix
		{
			get
			{
				return cSuffix;
			}
			set
			{
				cSuffix = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string City
		{
			get
			{
				return cCity;
			}
			set
			{
				cCity = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string Zipcode
		{
			get
			{
				return cZipcode;
			}
			set
			{
				cZipcode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string StateCode
		{
			get
			{
				return cStateCode;
			}
			set
			{
				cStateCode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int IncidentRoleCode
		{
			get
			{
				return cIncidentRoleCode;
			}
			set
			{
				cIncidentRoleCode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string NameLastUpdate
		{
			get
			{
				return cNameLastUpdate;
			}
			set
			{
				cNameLastUpdate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string LastUpdateBy
		{
			get
			{
				return cLastUpdateBy;
			}
			set
			{
				cLastUpdateBy = value;
			}
		}


		//IncidentNarration
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper IncidentNarration
		{
			get
			{
				return cIncidentNarration;
			}
			set
			{
				cIncidentNarration = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int NarrationID
		{
			get
			{
				return cNarrationID;
			}
			set
			{
				cNarrationID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int NarrationIncidentID
		{
			get
			{
				return cNarrationIncidentID;
			}
			set
			{
				cNarrationIncidentID = value;
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


		public string NarrationText
		{
			get
			{
				return cNarrationText;
			}
			set
			{
				cNarrationText = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string NarrationBy
		{
			get
			{
				return cNarrationBy;
			}
			set
			{
				cNarrationBy = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string NarrationLastUpdate
		{
			get
			{
				return cNarrationLastUpdate;
			}
			set
			{
				cNarrationLastUpdate = value;
			}
		}


		//IncidentAddressCorrection
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper IncidentAddressCorrection
		{
			get
			{
				return cIncidentAddressCorrection;
			}
			set
			{
				cIncidentAddressCorrection = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int IACIncidentID
		{
			get
			{
				return cIACIncidentID;
			}
			set
			{
				cIACIncidentID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string IACHouseNumber
		{
			get
			{
				return cIACHouseNumber;
			}
			set
			{
				cIACHouseNumber = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string IACPrefix
		{
			get
			{
				return cIACPrefix;
			}
			set
			{
				cIACPrefix = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string IACStreet
		{
			get
			{
				return cIACStreet;
			}
			set
			{
				cIACStreet = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string IACStreetType
		{
			get
			{
				return cIACStreetType;
			}
			set
			{
				cIACStreetType = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string IACSuffix
		{
			get
			{
				return cIACSuffix;
			}
			set
			{
				cIACSuffix = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string IACCityCode
		{
			get
			{
				return cIACCityCode;
			}
			set
			{
				cIACCityCode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string IACAmendedLocation
		{
			get
			{
				return cIACAmendedLocation;
			}
			set
			{
				cIACAmendedLocation = value;
			}
		}


		//IncidentCrossRef
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper IncidentCrossRef
		{
			get
			{
				return cIncidentCrossRef;
			}
			set
			{
				cIncidentCrossRef = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int XRefPrimaryID
		{
			get
			{
				return cXRefPrimaryID;
			}
			set
			{
				cXRefPrimaryID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int XRefReferenceID
		{
			get
			{
				return cXRefReferenceID;
			}
			set
			{
				cXRefReferenceID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string XRefNumber
		{
			get
			{
				return cXRefNumber;
			}
			set
			{
				cXRefNumber = value;
			}
		}


		//Incident Security
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper IncidentSecurity
		{
			get
			{
				return cIncidentSecurity;
			}
			set
			{
				cIncidentSecurity = value;
			}
		}


		//Central Pierce Address Variables
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public string CPType
		{
			get
			{
				return cCPType;
			}
			set
			{
				cCPType = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string CPHouse
		{
			get
			{
				return cCPHouse;
			}
			set
			{
				cCPHouse = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string CPStreet
		{
			get
			{
				return cCPStreet;
			}
			set
			{
				cCPStreet = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string CPStreetType
		{
			get
			{
				return cCPStreetType;
			}
			set
			{
				cCPStreetType = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string CPPrefix
		{
			get
			{
				return cCPPrefix;
			}
			set
			{
				cCPPrefix = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string CPSuffix
		{
			get
			{
				return cCPSuffix;
			}
			set
			{
				cCPSuffix = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string CPAptNo
		{
			get
			{
				return cCPAptNo;
			}
			set
			{
				cCPAptNo = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string CPCrossStreet
		{
			get
			{
				return cCPCrossStreet;
			}
			set
			{
				cCPCrossStreet = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string CPCrossType
		{
			get
			{
				return cCPCrossType;
			}
			set
			{
				cCPCrossType = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string CPCrossPrefix
		{
			get
			{
				return cCPCrossPrefix;
			}
			set
			{
				cCPCrossPrefix = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string CPCrossSuffix
		{
			get
			{
				return cCPCrossSuffix;
			}
			set
			{
				cCPCrossSuffix = value;
			}
		}


		//Incident LAT - LONG fields
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public int LLIncidentID
		{
			get
			{
				return cLLIncidentID;
			}
			set
			{
				cLLIncidentID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string LLlong
		{
			get
			{
				return cLLlong;
			}
			set
			{
				cLLlong = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string LLlat
		{
			get
			{
				return cLLlat;
			}
			set
			{
				cLLlat = value;
			}
		}



		//**********************************************
		//**         Public Class Methods             **
		//**********************************************

		public int GetIncident(int lIncidentID)
		{
			//Retrieve Requested Incident Record
			//Set Class  Variables to Retrieved Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_Incident " + lIncidentID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					Clear();
					//Set Incident  Class Variables
					cIncidentID = Convert.ToInt32(oRec["incident_id"]);
					cAgencyID = Convert.ToInt32(oRec["agency_id"]);
					cIncidentNumber = IncidentMain.Clean(oRec["incident_number"]);
					System.DateTime TempDate = DateTime.FromOADate(0);
					cDateIncidentCreated = (DateTime.TryParse(IncidentMain.Clean(oRec["date_incident_created"]), out TempDate)) ? TempDate.ToString("MM/dd/yyyy HH:mm:ss") : IncidentMain.Clean(oRec["date_incident_created"]);
					System.DateTime TempDate2 = DateTime.FromOADate(0);
					cDateReceivedE911 = (DateTime.TryParse(IncidentMain.Clean(oRec["date_received_E911"]), out TempDate2)) ? TempDate2.ToString("MM/dd/yyyy HH:mm:ss") : IncidentMain.Clean(oRec["date_received_E911"]);
					System.DateTime TempDate3 = DateTime.FromOADate(0);
					cDateFirstUnitDispatched = (DateTime.TryParse(IncidentMain.Clean(oRec["date_first_unit_dispatched"]), out TempDate3)) ? TempDate3.ToString("MM/dd/yyyy HH:mm:ss") : IncidentMain.Clean(oRec["date_first_unit_dispatched"]);
					System.DateTime TempDate4 = DateTime.FromOADate(0);
					cDateFirstUnitEnroute = (DateTime.TryParse(IncidentMain.Clean(oRec["date_first_unit_dispatched"]), out TempDate4)) ? TempDate4.ToString("MM/dd/yyyy HH:mm:ss") : IncidentMain.Clean(oRec["date_first_unit_dispatched"]);
					System.DateTime TempDate5 = DateTime.FromOADate(0);
					cDateFirstUnitOnscene = (DateTime.TryParse(IncidentMain.Clean(oRec["date_first_unit_onscene"]), out TempDate5)) ? TempDate5.ToString("MM/dd/yyyy HH:mm:ss") : IncidentMain.Clean(oRec["date_first_unit_onscene"]);
					System.DateTime TempDate6 = DateTime.FromOADate(0);
					cDateFirstUnitTransport = (DateTime.TryParse(IncidentMain.Clean(oRec["date_first_unit_transport"]), out TempDate6)) ? TempDate6.ToString("MM/dd/yyyy HH:mm:ss") : IncidentMain.Clean(oRec["date_first_unit_transport"]);
					System.DateTime TempDate7 = DateTime.FromOADate(0);
					cDateFirstUnitTransComplete = (DateTime.TryParse(IncidentMain.Clean(oRec["date_first_unit_trans_complete"]), out TempDate7)) ? TempDate7.ToString("MM/dd/yyyy HH:mm:ss") : IncidentMain.Clean(oRec["date_first_unit_trans_complete"]);
					System.DateTime TempDate8 = DateTime.FromOADate(0);
					cDateIncidentClosed = (DateTime.TryParse(IncidentMain.Clean(oRec["date_incident_closed"]), out TempDate8)) ? TempDate8.ToString("MM/dd/yyyy HH:mm:ss") : IncidentMain.Clean(oRec["date_incident_closed"]);
					System.DateTime TempDate9 = DateTime.FromOADate(0);
					cDateIncidentFinalClosed = (DateTime.TryParse(IncidentMain.Clean(oRec["date_incident_final_closed"]), out TempDate9)) ? TempDate9.ToString("MM/dd/yyyy HH:mm:ss") : IncidentMain.Clean(oRec["date_incident_final_closed"]);
					cReportingName = IncidentMain.Clean(oRec["reporting_name"]);
					cReportingAddress = IncidentMain.Clean(oRec["reporting_address"]);
					cReportingPhone = IncidentMain.Clean(oRec["reporting_phone"]);
					cLocation = IncidentMain.Clean(oRec["location"]);
					cCommonPlace = IncidentMain.Clean(oRec["common_place"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cX_coord = Convert.ToDouble(IncidentMain.GetVal(oRec["x_coord"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cY_coord = Convert.ToDouble(IncidentMain.GetVal(oRec["y_coord"]));
					cFlagMutualAid = Convert.ToByte(oRec["flag_mutual_aid"]);
					cFlagLocationVerify = Convert.ToByte(oRec["flag_location_verify"]);
					cFlagCatchUp = Convert.ToByte(oRec["flag_catch_up"]);
					cFlagLAR = Convert.ToByte(oRec["flag_lar"]);
					cCityCode = IncidentMain.Clean(oRec["city_code"]);
					cGeoLocation = IncidentMain.Clean(oRec["geo_location"]);
					cDispatchTerminal_1 = IncidentMain.Clean(oRec["dispatch_terminal_1"]);
					cDispatcher1ID = IncidentMain.Clean(oRec["dispatcher_1_id"]);
					cDispatchTerminal_2 = IncidentMain.Clean(oRec["dispatch_terminal_2"]);
					cDispatcher2ID = IncidentMain.Clean(oRec["dispatcher_2_id"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cInitialIncidentType = Convert.ToInt32(IncidentMain.GetVal(oRec["initial_incident_type"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cFinalIncidentType = Convert.ToInt32(IncidentMain.GetVal(oRec["final_incident_type"]));
					cInitialAlarmLevel = IncidentMain.Clean(oRec["initial_alarm_level"]);
					cFinalAlarmLevel = IncidentMain.Clean(oRec["final_alarm_level"]);
					cReportDisposition = IncidentMain.Clean(oRec["report_disposition"]);
					cFirstUnitDispatched = IncidentMain.Clean(oRec["first_unit_dispatched"]);
					cFirstAssistingUnit = IncidentMain.Clean(oRec["first_assisting_unit"]);
					cClearingUnit = IncidentMain.Clean(oRec["clearing_unit"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cNumberOfPatients = Convert.ToInt32(IncidentMain.GetVal(oRec["number_of_patients"]));
					cTransferStatus = IncidentMain.Clean(oRec["transfer_status"]);
					cIncidentShift = IncidentMain.Clean(oRec["incident_shift"]);
					cCADInitialType = IncidentMain.Clean(oRec["cad_initial_type"]);
					cCADFinalType = IncidentMain.Clean(oRec["cad_final_type"]);
					//UPGRADE_WARNING: (1068) GetVal(oRec(dispatched)) of type Variant is being forced to bool. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					if (Convert.ToBoolean(IncidentMain.GetVal(oRec["dispatched"])))
					{
						cDispatched = 1;
					}
					else
					{
						cDispatched = 0;
					}
					cALS_BLS = IncidentMain.Clean(oRec["als_bls"]);
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

		public int CheckIncidentNumber(string sIncidentNumber)
		{
			//Check for Existing Incident Record using Incident Number
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_IncidentCheckNumber '" + sIncidentNumber + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					return Convert.ToInt32(oRec["incident_id"]);
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

		public int CheckValidIncident(string sIncidentNumber, int iAgency)
		{
			//Check for Existing Incident Record using Incident Number and agency
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_IncidentValidNumber '" + sIncidentNumber + "'," + iAgency.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					return Convert.ToInt32(oRec["incident_id"]);
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

		public int CheckIncidentParticipant(int lIncidentID, string sEmpID)
		{
			//Determine if specified user was participant at specified Incident
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_IncidentParticipant " + lIncidentID.ToString() + ",'" + sEmpID + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
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


		public int AddIncident()
		{
			//Add Incident Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{

				result = -1;
				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spInsert_Incident " + cAgencyID.ToString() + ",'" + cIncidentNumber + "','";
				if (cDateIncidentCreated == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cDateIncidentCreated + "',";
				}
				if (cDateReceivedE911 == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cDateReceivedE911 + "',";
				}
				if (cDateFirstUnitDispatched == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cDateFirstUnitDispatched + "',";
				}
				if (cDateFirstUnitEnroute == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cDateFirstUnitEnroute + "',";
				}
				if (cDateFirstUnitOnscene == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cDateFirstUnitOnscene + "',";
				}
				if (cDateFirstUnitTransport == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cDateFirstUnitTransport + "',";
				}
				if (cDateFirstUnitTransComplete == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cDateFirstUnitTransComplete + "',";
				}
				if (cDateIncidentClosed == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cDateIncidentClosed + "',";
				}
				if (cDateIncidentFinalClosed == "")
				{
					SqlString = SqlString + "NULL,'";
				}
				else
				{
					SqlString = SqlString + "'" + cDateIncidentFinalClosed + "','";
				}
				SqlString = SqlString + Strings.Replace(cReportingName, "'", "''", 1, -1, CompareMethod.Binary) + "','" + Strings.Replace(cReportingAddress, "'", "''", 1, -1, CompareMethod.Binary) + "','" + cReportingPhone + "','";
				SqlString = SqlString + cLocation + "','" + Strings.Replace(cCommonPlace, "'", "''", 1, -1, CompareMethod.Binary) + "',";
				if (cX_coord == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cX_coord.ToString() + ",";
				}
				if (cY_coord == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cY_coord.ToString() + ",";
				}
				SqlString = SqlString + cFlagMutualAid.ToString() + "," + cFlagLocationVerify.ToString() + "," + cFlagCatchUp.ToString() + ",";
				SqlString = SqlString + cFlagLAR.ToString() + ",";
				if (cCityCode == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cCityCode + "',";
				}
				if (cGeoLocation == "")
				{
					SqlString = SqlString + "NULL,'";
				}
				else
				{
					SqlString = SqlString + "'" + Strings.Replace(cGeoLocation, "'", "''", 1, -1, CompareMethod.Binary) + "','";
				}
				SqlString = SqlString + cDispatchTerminal_1 + "','" + cDispatcher1ID + "','";
				SqlString = SqlString + cDispatchTerminal_2 + "','" + cDispatcher2ID + "',";
				if (cInitialIncidentType == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cInitialIncidentType.ToString() + ",";
				}
				if (cFinalIncidentType == 0)
				{
					SqlString = SqlString + "NULL,'";
				}
				else
				{
					SqlString = SqlString + cFinalIncidentType.ToString() + ",'";
				}
				SqlString = SqlString + cInitialAlarmLevel + "','" + cFinalAlarmLevel + "','";
				SqlString = SqlString + cReportDisposition + "','" + cFirstUnitDispatched + "',";
				if (cFirstAssistingUnit == "")
				{
					SqlString = SqlString + "NULL,'";
				}
				else
				{
					SqlString = SqlString + "'" + cFirstAssistingUnit + "','";
				}
				SqlString = SqlString + cClearingUnit + "'," + cNumberOfPatients.ToString();

				oCmd.CommandText = SqlString;
				oCmd.ExecuteNonQuery();

				oCmd.CommandText = "spSelect_NewIncident";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (~GetIncident(Convert.ToInt32(oRec[0])) != 0)
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

		public int UpdateIncident()
		{
			//Update Incident Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;
				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spUpdate_Incident " + cIncidentID.ToString() + "," + cAgencyID.ToString() + ",'" + cIncidentNumber + "','";
				if (cDateIncidentCreated == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cDateIncidentCreated + "',";
				}
				if (cDateReceivedE911 == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cDateReceivedE911 + "',";
				}
				if (cDateFirstUnitDispatched == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cDateFirstUnitDispatched + "',";
				}
				if (cDateFirstUnitEnroute == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cDateFirstUnitEnroute + "',";
				}
				if (cDateFirstUnitOnscene == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cDateFirstUnitOnscene + "',";
				}
				if (cDateFirstUnitTransport == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cDateFirstUnitTransport + "',";
				}
				if (cDateFirstUnitTransComplete == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cDateFirstUnitTransComplete + "',";
				}
				if (cDateIncidentClosed == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cDateIncidentClosed + "',";
				}
				if (cDateIncidentFinalClosed == "")
				{
					SqlString = SqlString + "NULL,'";
				}
				else
				{
					SqlString = SqlString + "'" + cDateIncidentFinalClosed + "','";
				}
				SqlString = SqlString + Strings.Replace(cReportingName, "'", "''", 1, -1, CompareMethod.Binary) + "','" + Strings.Replace(cReportingAddress, "'", "''", 1, -1, CompareMethod.Binary) + "','" + cReportingPhone + "','";
				SqlString = SqlString + cLocation + "','" + Strings.Replace(cCommonPlace, "'", "''", 1, -1, CompareMethod.Binary) + "',";
				if (cX_coord == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cX_coord.ToString() + ",";
				}
				if (cY_coord == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cY_coord.ToString() + ",";
				}
				SqlString = SqlString + cFlagMutualAid.ToString() + "," + cFlagLocationVerify.ToString() + "," + cFlagCatchUp.ToString() + ",";
				SqlString = SqlString + cFlagLAR.ToString() + ",'" + cCityCode + "','" + Strings.Replace(cGeoLocation, "'", "''", 1, -1, CompareMethod.Binary) + "','";
				SqlString = SqlString + cDispatchTerminal_1 + "','" + cDispatcher1ID + "','";
				SqlString = SqlString + cDispatchTerminal_2 + "','" + cDispatcher2ID + "',";
				if (cInitialIncidentType == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cInitialIncidentType.ToString() + ",";
				}
				if (cFinalIncidentType == 0)
				{
					SqlString = SqlString + "NULL,'";
				}
				else
				{
					SqlString = SqlString + cFinalIncidentType.ToString() + ",'";
				}
				SqlString = SqlString + cInitialAlarmLevel + "','" + cFinalAlarmLevel + "','";
				SqlString = SqlString + cReportDisposition + "','" + cFirstUnitDispatched + "',";
				if (cFirstAssistingUnit == "")
				{
					SqlString = SqlString + "NULL,'";
				}
				else
				{
					SqlString = SqlString + "'" + cFirstAssistingUnit + "','";
				}
				SqlString = SqlString + cClearingUnit + "'," + cNumberOfPatients.ToString();

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

		public int UpdateFinalType()
		{
			//Update Final Type Code with Primary Incident Situation Found
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spUpdate_IncidentFinalType";

				oCmd.ExecuteNonQuery(new object[] { cIncidentID, cFinalIncidentType, cNumberOfPatients });

				return -1;
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public int UpdateLatLong()
		{
			//Update Incident Lat/Long fields
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spUpdate_IncidentLatLong";
				oCmd.ExecuteNonQuery(new object[] { cIncidentID, cIncLat, cIncLong });

				return -1;
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
			//Clear all Private Variables

			cIncidentID = 0;
			cAgencyID = 0;
			cIncidentNumber = "";
			cDateIncidentCreated = "";
			cDateReceivedE911 = "";
			cDateFirstUnitDispatched = "";
			cDateFirstUnitEnroute = "";
			cDateFirstUnitOnscene = "";
			cDateFirstUnitTransport = "";
			cDateFirstUnitTransComplete = "";
			cDateIncidentClosed = "";
			cDateIncidentFinalClosed = "";
			cReportingName = "";
			cReportingAddress = "";
			cReportingPhone = "";
			cLocation = "";
			cCommonPlace = "";
			cX_coord = 0;
			cY_coord = 0;
			cFlagMutualAid = 0;
			cFlagLocationVerify = 0;
			cFlagCatchUp = 0;
			cFlagLAR = 0;
			cCityCode = "";
			cGeoLocation = "";
			cDispatchTerminal_1 = "";
			cDispatcher1ID = "";
			cDispatchTerminal_2 = "";
			cDispatcher2ID = "";
			cInitialIncidentType = 0;
			cFinalIncidentType = 0;
			cInitialAlarmLevel = "";
			cFinalAlarmLevel = "";
			cReportDisposition = "";
			cFirstUnitDispatched = "";
			cFirstAssistingUnit = "";
			cClearingUnit = "";
			cNumberOfPatients = 0;


		}


		public int IncidentListRS(string StartDate, string EndDate, string UnitParm, int TypeParm)
		{
			//Retrieve Recordset list of Incidents for Selected Date
			//With possible Unit and/or Incident Type Parameters
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				//*** Test filter parameters to determine which sp to call  ***'
				//--- Only dates, default --
				if (UnitParm == "" && TypeParm == 0)
				{
					oCmd.CommandText = "spSelect_IncidentList1 '" + StartDate + "','" + EndDate + "'";
					//---Unit filter only --
				}
				else if (UnitParm != "" && TypeParm == 0)
				{
					oCmd.CommandText = "spSelect_IncidentList2 '" + StartDate + "','" + EndDate + "','" + UnitParm + "'";
					//---Type filter only --
				}
				else if (UnitParm == "" && TypeParm != 0)
				{
					oCmd.CommandText = "spSelect_IncidentList3 '" + StartDate + "','" + EndDate + "'," + TypeParm.ToString();
					//---Both Unit and Type filter --
				}
				else if (UnitParm != "" && TypeParm != 0)
				{
					oCmd.CommandText = "spSelect_IncidentList4 '" + StartDate + "','" + EndDate + "','" + UnitParm + "'," + TypeParm.ToString();
					//--otherwise back to default??
				}
				else
				{
					oCmd.CommandText = "spSelect_IncidentList1 '" + StartDate + "','" + EndDate + "'";
				}
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cIncidentRS = oRec;
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

		public int NameListRS(int lIncidentID)
		{
			//Retrieve Recordset list of Names for Selected Incident
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_IncidentNameList " + lIncidentID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cIncidentName = oRec;
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

		public int GetName(int lNameID)
		{
			//Retrieve Requested IncidentName Record
			//Set Class  Variables to Retrieved Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_IncidentName " + lNameID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					//Set IncidentName  Class Variables
					cNameID = Convert.ToInt32(oRec["name_id"]);
					cNameIncidentID = Convert.ToInt32(oRec["incident_id"]);
					cNameFirst = IncidentMain.Clean(oRec["name_first"]);
					cNameLast = IncidentMain.Clean(oRec["name_last"]);
					cNameMI = IncidentMain.Clean(oRec["name_mi"]);
					cNameBusiness = IncidentMain.Clean(oRec["name_business"]);
					System.DateTime TempDate = DateTime.FromOADate(0);
					cBirthdate = (DateTime.TryParse(IncidentMain.Clean(oRec["birthdate"]), out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : IncidentMain.Clean(oRec["birthdate"]);
					cHomePhone = IncidentMain.Clean(oRec["home_phone"]);
					cWorkPhone = IncidentMain.Clean(oRec["work_phone"]);
					cWorkPlace = IncidentMain.Clean(oRec["work_place"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cGender = Convert.ToInt32(IncidentMain.GetVal(oRec["gender"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cRaceCode = Convert.ToInt32(IncidentMain.GetVal(oRec["race_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cEthnicityCode = Convert.ToInt32(IncidentMain.GetVal(oRec["ethnicity_code"]));
					cHouseNumber = IncidentMain.Clean(oRec["addr_house_number"]);
					cPrefix = IncidentMain.Clean(oRec["addr_prefix"]);
					cStreet = IncidentMain.Clean(oRec["addr_street_name"]);
					cStreetType = IncidentMain.Clean(oRec["addr_street_type"]);
					cSuffix = IncidentMain.Clean(oRec["addr_suffix"]);
					cCity = IncidentMain.Clean(oRec["city"]);
					cZipcode = IncidentMain.Clean(oRec["zipcode"]);
					cStateCode = IncidentMain.Clean(oRec["state_code"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cIncidentRoleCode = Convert.ToInt32(IncidentMain.GetVal(oRec["incident_role_code"]));
					System.DateTime TempDate2 = DateTime.FromOADate(0);
					cNameLastUpdate = (DateTime.TryParse(IncidentMain.Clean(oRec["last_update"]), out TempDate2)) ? TempDate2.ToString("MM/dd/yyyy") : IncidentMain.Clean(oRec["last_update"]);
					cLastUpdateBy = IncidentMain.Clean(oRec["last_update_by"]);
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

		public int AddName()
		{
			//Add New Incident Name Record
			//Uses Values loaded into Private Class Variables
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spInsert_IncidentName " + cNameIncidentID.ToString() + ",'" + Strings.Replace(cNameFirst, "'", "''", 1, -1, CompareMethod.Binary) + "','" + Strings.Replace(cNameLast, "'", "''", 1, -1, CompareMethod.Binary) + "','";
				SqlString = SqlString + cNameMI + "','" + Strings.Replace(cNameBusiness, "'", "''", 1, -1, CompareMethod.Binary) + "',";
				if (cBirthdate == "")
				{
					SqlString = SqlString + "NULL,'" + cHomePhone + "','" + cWorkPhone + "','" + cWorkPlace + "',";
				}
				else
				{
					SqlString = SqlString + "'" + cBirthdate + "','" + cHomePhone + "','" + cWorkPhone + "','" + Strings.Replace(cWorkPlace, "'", "''", 1, -1, CompareMethod.Binary) + "',";
				}
				if (cGender == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cGender.ToString() + ",";
				}
				if (cRaceCode == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cRaceCode.ToString() + ",";
				}
				if (cEthnicityCode == 0)
				{
					SqlString = SqlString + "NULL,'";
				}
				else
				{
					SqlString = SqlString + cEthnicityCode.ToString() + ",'";
				}
				SqlString = SqlString + cHouseNumber + "',";
				if (cPrefix == "")
				{
					SqlString = SqlString + "NULL,'" + Strings.Replace(cStreet, "'", "''", 1, -1, CompareMethod.Binary) + "',";
				}
				else
				{
					SqlString = SqlString + "'" + cPrefix + "','" + Strings.Replace(cStreet, "'", "''", 1, -1, CompareMethod.Binary) + "',";
				}
				if (cStreetType == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cStreetType + "',";
				}
				if (cSuffix == "")
				{
					SqlString = SqlString + "NULL,'" + cCity + "','" + cZipcode + "',";
				}
				else
				{
					SqlString = SqlString + "'" + cSuffix + "','" + cCity + "','" + cZipcode + "',";
				}
				if (cStateCode == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cStateCode + "',";
				}
				if (cIncidentRoleCode == 0)
				{
					SqlString = SqlString + "NULL,'";
				}
				else
				{
					SqlString = SqlString + cIncidentRoleCode.ToString() + ",'";
				}
				SqlString = SqlString + cNameLastUpdate + "','" + cLastUpdateBy + "'";
				oCmd.CommandText = SqlString;
				oCmd.ExecuteNonQuery();
				return -1;
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public int UpdateName()
		{
			//Update Incident Name Record
			//Uses Values loaded into Private Class Variables
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spUpdate_IncidentName " + cNameID.ToString() + "," + cNameIncidentID.ToString() + ",'" + Strings.Replace(cNameFirst, "'", "''", 1, -1, CompareMethod.Binary) + "','" + Strings.Replace(cNameLast, "'", "''", 1, -1, CompareMethod.Binary) + "','";
				SqlString = SqlString + cNameMI + "','" + cNameBusiness + "',";
				if (cBirthdate == "")
				{
					SqlString = SqlString + "NULL,'" + cHomePhone + "','" + cWorkPhone + "','" + cWorkPlace + "',";
				}
				else
				{
					SqlString = SqlString + "'" + cBirthdate + "','" + cHomePhone + "','" + cWorkPhone + "','" + Strings.Replace(cWorkPlace, "'", "''", 1, -1, CompareMethod.Binary) + "',";
				}
				if (cGender == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cGender.ToString() + ",";
				}
				if (cRaceCode == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cRaceCode.ToString() + ",";
				}
				if (cEthnicityCode == 0)
				{
					SqlString = SqlString + "NULL,'";
				}
				else
				{
					SqlString = SqlString + cEthnicityCode.ToString() + ",'";
				}
				SqlString = SqlString + cHouseNumber + "',";
				if (cPrefix == "")
				{
					SqlString = SqlString + "NULL,'" + Strings.Replace(cStreet, "'", "''", 1, -1, CompareMethod.Binary) + "',";
				}
				else
				{
					SqlString = SqlString + "'" + cPrefix + "','" + Strings.Replace(cStreet, "'", "''", 1, -1, CompareMethod.Binary) + "',";
				}
				if (cStreetType == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cStreetType + "',";
				}
				if (cSuffix == "")
				{
					SqlString = SqlString + "NULL,'" + cCity + "','" + cZipcode + "',";
				}
				else
				{
					SqlString = SqlString + "'" + cSuffix + "','" + cCity + "','" + cZipcode + "',";
				}
				if (cStateCode == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cStateCode + "',";
				}
				if (cIncidentRoleCode == 0)
				{
					SqlString = SqlString + "NULL,'";
				}
				else
				{
					SqlString = SqlString + cIncidentRoleCode.ToString() + ",'";
				}
				SqlString = SqlString + cNameLastUpdate + "','" + cLastUpdateBy + "'";
				oCmd.CommandText = SqlString;
				oCmd.ExecuteNonQuery();
				return -1;
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public int NarrationListRS(int lIncidentID, int iReportType)
		{
			//Retrieve Recordset list of Narrations for Selected Incident and ReportType
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_NarrationList " + lIncidentID.ToString() + "," + iReportType.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cIncidentNarration = oRec;
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

		public int GetNarration(int lNarrationID)
		{
			//Retrieve Requested IncidentNarration Record
			//Set Class  Variables to Retrieved Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_IncidentNarration " + lNarrationID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					//Set IncidentNarration  Class Variables
					cNarrationID = Convert.ToInt32(oRec["narration_id"]);
					cNarrationIncidentID = Convert.ToInt32(oRec["incident_id"]);
					cReportType = Convert.ToInt32(oRec["report_type"]);
					cNarrationText = IncidentMain.Clean(oRec["narration_text"]);
					cNarrationBy = IncidentMain.Clean(oRec["narration_by"]);
					System.DateTime TempDate = DateTime.FromOADate(0);
					cNarrationLastUpdate = (DateTime.TryParse(IncidentMain.Clean(oRec["last_update"]), out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : IncidentMain.Clean(oRec["last_update"]);
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

		public int GetNarrationSecurity(int lNarrationID, string sEmpID)
		{
			//Retrieve Update Permission for Requested IncidentNarration Record
			//Set Class  Variables to Retrieved Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_IncidentNarration " + lNarrationID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					//Test if Narration author is same as parameter empid
					if (IncidentMain.Clean(oRec["narration_by"]) == sEmpID)
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


		public int AddNarration()
		{
			//Add New Incident Narration Record
			//Uses Values loaded into Private Class Variables
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spInsert_IncidentNarration";

				oCmd.ExecuteNonQuery(new object[] { cNarrationIncidentID, cReportType, Strings.Replace(cNarrationText, "'", "''", 1, -1, CompareMethod.Binary), cNarrationBy, cNarrationLastUpdate });
				return -1;
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public int UpdateNarration()
		{
			//Update Incident Narration Record
			//Uses Values loaded into Private Class Variables
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spUpdate_IncidentNarration";

				oCmd.ExecuteNonQuery(new object[] { cNarrationID, cNarrationIncidentID, cReportType, Strings.Replace(cNarrationText, "'", "''", 1, -1, CompareMethod.Binary), cNarrationBy, cNarrationLastUpdate });
				return -1;
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public int GetAddressCorrection(int lIncidentID)
		{
			//Retrieve Requested IncidentNarration Record
			//Set Class  Variables to Retrieved Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_IncidentAddressCorrection " + lIncidentID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					//Set IncidentNarration  Class Variables
					cIACIncidentID = Convert.ToInt32(oRec["incident_id"]);
					cIACHouseNumber = IncidentMain.Clean(oRec["addr_house_number"]);
					cIACPrefix = IncidentMain.Clean(oRec["addr_prefix"]);
					cIACStreet = IncidentMain.Clean(oRec["addr_street"]);
					cIACStreetType = IncidentMain.Clean(oRec["addr_street_type"]);
					cIACSuffix = IncidentMain.Clean(oRec["addr_suffix"]);
					cIACCityCode = IncidentMain.Clean(oRec["city_code"]);
					cIACAmendedLocation = IncidentMain.Clean(oRec["amended_location"]);
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

		public int AddIncidentAddressCorrection()
		{
			//Add New IncidentAddressCorrection Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";
			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spInsert_IncidentAddressCorrection " + cIACIncidentID.ToString() + ",'" + cIACHouseNumber + "',";
				if (cIACPrefix == "")
				{
					SqlString = SqlString + "NULL,'" + Strings.Replace(cIACStreet, "'", "''", 1, -1, CompareMethod.Binary) + "',";
				}
				else
				{
					SqlString = SqlString + "'" + cIACPrefix + "','" + Strings.Replace(cIACStreet, "'", "''", 1, -1, CompareMethod.Binary) + "',";
				}
				if (cIACStreet == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cIACStreetType + "',";
				}
				if (cIACSuffix == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cIACSuffix + "',";
				}
				if (cIACCityCode == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cIACCityCode + "',";
				}
				if (cIACAmendedLocation == "")
				{
					SqlString = SqlString + "NULL";
				}
				else
				{
					SqlString = SqlString + "'" + Strings.Replace(cIACAmendedLocation, "'", "''", 1, -1, CompareMethod.Binary) + "'";
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

		public int UpdateIncidentAddressCorrection()
		{
			//Update FireExposureAddress Record
			//ReportLog and ReportLogHistory updated by stored procedure
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spUpdate_IncidentAddressCorrection " + cIACIncidentID.ToString() + ",'" + cIACHouseNumber + "',";
				if (cIACPrefix == "")
				{
					SqlString = SqlString + "NULL,'" + Strings.Replace(cIACStreet, "'", "''", 1, -1, CompareMethod.Binary) + "',";
				}
				else
				{
					SqlString = SqlString + "'" + cIACPrefix + "','" + Strings.Replace(cIACStreet, "'", "''", 1, -1, CompareMethod.Binary) + "',";
				}
				if (cIACStreetType == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cIACStreetType + "',";
				}
				if (cIACSuffix == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cIACSuffix + "',";
				}
				if (cIACCityCode == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cIACCityCode + "',";
				}
				if (cIACAmendedLocation == "")
				{
					SqlString = SqlString + "NULL";
				}
				else
				{
					SqlString = SqlString + "'" + cIACAmendedLocation + "'";
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

		public int DeleteIncidentAddressCorrection(ref int lIncidentID)
		{
			//Delete IncidentAddressCorrection

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spDelete_IncidentAddressCorrection";

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


		public int ConvertTypeCode(string sOldType)
		{
			//Retrieve New Incident Type Class
			//From Old Type Code
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_NewIncidentType '" + sOldType + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					return Convert.ToInt32(oRec["incident_type_class"]);
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

		public int AddXRef()
		{
			//Add New Incident CrossReference Record
			//Uses Values loaded into Private Class Variables
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;
				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spInsert_IncidentCrossRef " + cXRefPrimaryID.ToString() + ",";
				if (cXRefReferenceID == 0)
				{
					SqlString = SqlString + "NULL,'" + cXRefNumber + "'";
				}
				else
				{
					SqlString = SqlString + cXRefReferenceID.ToString() + ",'" + cXRefNumber + "'";
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

		public int GetUserSecurity(string EmpID)
		{
			//Select Security Setting From IncidentSecurity Table for this employee
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_IncidentSecurity '" + EmpID + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cIncidentSecurity = oRec;
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

		public int GetSecurityByType(int lSecCode)
		{
			//Select all employees with selected type of system security
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_IncidentSecurityByType " + lSecCode.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cIncidentSecurity = oRec;
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


		public int UpdateIncidentTransferStatus(ref int lIncidentID, ref string sStatus)
		{
			//Update Incident Transfer Status
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spUpdate_IncidentTransferStatus";

				oCmd.ExecuteNonQuery(new object[] { lIncidentID, sStatus });

				return -1;
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public int UpdateIncidentShift(ref int lIncidentID, ref string sShift)
		{
			//Update Incident Shift
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spUpdate_IncidentShift";

				oCmd.ExecuteNonQuery(new object[] { lIncidentID, sShift });

				return -1;
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public int UpdateIncidentTypes(ref int lIncidentID, ref string sInitialType, ref string sFinalType)
		{
			//Update Incident CAD Initial and Final Type Code fields
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spUpdate_IncidentTypes";
				oCmd.ExecuteNonQuery(new object[] { lIncidentID, sInitialType, sFinalType });

				return -1;
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public int UpdateIncidentDispFlag(ref int lIncidentID, ref byte bDispFlag)
		{
			//Update Incident Dispatched Flag
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spUpdate_IncidentDispFlag";
				oCmd.ExecuteNonQuery(new object[] { lIncidentID, bDispFlag });

				return -1;
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}


		public string GetShift(string sShiftDate)
		{
			//Retrieve Shift for Incident date
			string result = "";
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oPTSdata;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "sp_GetShift '" + sShiftDate + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					return Convert.ToString(oRec["shift_code"]);
				}
				else
				{
					return "";
				}
			}
			catch
			{

				result = "";
			}
			return result;
		}

		public int GetEvent(int lEventID)
		{
			//Retreive specified IncidentEvent Record
			//Set Class  Variables to Retrieved Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_IncidentEvent " + lEventID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					//Set IncidentNarration  Class Variables
					cEventID = Convert.ToInt32(oRec["event_id"]);
					cEventIncidentID = Convert.ToInt32(oRec["incident_id"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cEventNumber = Convert.ToInt32(IncidentMain.GetVal(oRec["event_number"]));
					cEventType = IncidentMain.Clean(oRec["event"]);
					cEventTime = IncidentMain.Clean(oRec["event_time"]);
					if (Convert.ToBoolean(oRec["flag_mdt"]))
					{
						cFlagMDT = 1;
					}
					else
					{
						cFlagMDT = 0;
					}
					cSendTerminal = IncidentMain.Clean(oRec["sending_terminal"]);
					cSendOpID = IncidentMain.Clean(oRec["sending_op_id"]);
					cReceiveTerminal = IncidentMain.Clean(oRec["receiving_terminal"]);
					cEventText = IncidentMain.Clean(oRec["event_text"]);
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

		public int GetIncidentEvents(int lIncidentID)
		{
			//Retrieve Recordset list of IncidentEvents for Selected Incident
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_IncidentEventAll " + lIncidentID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cEventRS = oRec;
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

		public int AddEvent()
		{
			//Add New Incident Event Record
			//Uses Values loaded into Private Class Variables
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			string SqlString = "";

			try
			{

				result = -1;
				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spInsert_IncidentEvent " + cEventIncidentID.ToString() + "," + cEventNumber.ToString() + ",'";
				SqlString = SqlString + cEventType + "',";
				if (cEventTime == "")
				{
					SqlString = SqlString + "NULL," + cFlagMDT.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + "'" + cEventTime + "'," + cFlagMDT.ToString() + ",";
				}
				if (cSendTerminal == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cSendTerminal + "',";
				}
				if (cSendOpID == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cSendOpID + "',";
				}
				if (cReceiveTerminal == "")
				{
					SqlString = SqlString + "NULL,'" + Strings.Replace(cEventText, "'", "''", 1, -1, CompareMethod.Binary) + "'";
				}
				else
				{
					SqlString = SqlString + "'" + cReceiveTerminal + "','" + Strings.Replace(cEventText, "'", "''", 1, -1, CompareMethod.Binary) + "'";
				}
				oCmd.CommandText = SqlString;
				oCmd.ExecuteNonQuery();

				oCmd.CommandText = "spSelect_NewIncidentEvent";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (~GetEvent(Convert.ToInt32(oRec[0])) != 0)
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

		public int UpdateEvent()
		{
			//Update Incident Event Record
			//Uses Values loaded into Private Class Variables
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			string SqlString = "";

			try
			{

				result = -1;
				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spUpdate_IncidentEvent " + cEventID.ToString() + "," + cEventIncidentID.ToString() + "," + cEventNumber.ToString() + ",'";
				SqlString = SqlString + cEventType + "',";
				if (cEventTime == "")
				{
					SqlString = SqlString + "NULL," + cFlagMDT.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + "'" + cEventTime + "'," + cFlagMDT.ToString() + ",";
				}
				if (cSendTerminal == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cSendTerminal + "',";
				}
				if (cSendOpID == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cSendOpID + "',";
				}
				if (cReceiveTerminal == "")
				{
					SqlString = SqlString + "NULL,'" + Strings.Replace(cEventText, "'", "''", 1, -1, CompareMethod.Binary) + "'";
				}
				else
				{
					SqlString = SqlString + "'" + cReceiveTerminal + "','" + Strings.Replace(cEventText, "'", "''", 1, -1, CompareMethod.Binary) + "'";
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


		public int CheckIncidentEvent(int lIncidentID, int EventNumber)
		{
			//Check for Existing IncidentEvent Record using IncidentID and Event Number
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_IncidentEventCheck " + lIncidentID.ToString() + "," + EventNumber.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					return Convert.ToInt32(oRec["event_id"]);
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

		public int GetIncidentReport(int lIncidentID)
		{
			//Retrieve Incident Record
			//Formatted for Reporting
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_Incident " + lIncidentID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cIncidentRS = oRec;
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

		public int GetIncidentNameReport(int lIncidentID)
		{
			//Retrieve Incident Name Records
			//Formatted for Reporting
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_IncidentName " + lIncidentID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cIncidentName = oRec;
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

		public int GetIncidentEventReport(int lIncidentID)
		{
			//Retrieve Incident Event Record
			//Formatted for Reporting
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_IncidentEvent " + lIncidentID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cEventRS = oRec;
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

		public int UpdateIncidentSecurity(ref string sEmpID, ref int lSecurityCode)
		{
			//Update Security Code for selected Employee
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spUpdate_IncidentSecurity";
				oCmd.ExecuteNonQuery(new object[] { sEmpID, lSecurityCode });

				return -1;
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public int ProcessCPIncident(int lIncidentID)
		{
			//Create Central Pierce Fire & Rescue Incident extract file

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string BackupFilePath = "", FilePath = "", Fileline = "";
			string ArchiveFilePath = "";
			string Header01 = "", Header02 = "";
			int x = 0;
			int ReturnCode = 0;


			try
			{

				result = -1;
				if (~GetIncident(lIncidentID) != 0)
				{
					return 0;
				}
				Header01 = Strings.Chr(1).ToString() + "INC01" + Strings.Chr(28).ToString() + new System.String(' ', 4) + Strings.Chr(28).ToString() + DateTime.Now.ToString("yyyyMMddHHNNSS");
				Header01 = Header01 + Strings.Chr(28).ToString() + new System.String(' ', 1) + Strings.Chr(28).ToString() + Strings.Chr(28).ToString() + new System.String(' ', 12);
				Header01 = Header01 + Strings.Chr(28).ToString() + Strings.Chr(28).ToString() + Strings.Chr(28).ToString() + Strings.Chr(28).ToString() + Strings.Chr(2).ToString();
				Header02 = Strings.Chr(1).ToString() + "INC03" + Strings.Chr(28).ToString() + new System.String(' ', 4) + Strings.Chr(28).ToString() + DateTime.Now.ToString("yyyyMMddHHNNSS");
				Header02 = Header02 + Strings.Chr(28).ToString() + new System.String(' ', 1) + Strings.Chr(28).ToString() + Strings.Chr(28).ToString() + new System.String(' ', 12);
				Header02 = Header02 + Strings.Chr(28).ToString() + Strings.Chr(28).ToString() + Strings.Chr(28).ToString() + Strings.Chr(28).ToString() + Strings.Chr(2).ToString();

				//Create File, Write File Header
				Fileline = "";
				FilePath = IncidentMain.CPFILEPATH;
				BackupFilePath = IncidentMain.CPFILEBACKUP;
				ArchiveFilePath = IncidentMain.CPFILEARCHIVE;

				if (cTransferStatus == "Z")
				{
					FilePath = FilePath + "inc01_cp" + cIncidentNumber + ".txt";
					BackupFilePath = BackupFilePath + "inc01_cp" + cIncidentNumber + ".txt";
					ArchiveFilePath = ArchiveFilePath + "inc01_cp" + cIncidentNumber + ".txt";
				}
				else
				{
					FilePath = FilePath + "inc03_cp" + cIncidentNumber + ".txt";
					BackupFilePath = BackupFilePath + "inc03_cp" + cIncidentNumber + ".txt";
					ArchiveFilePath = ArchiveFilePath + "inc03_cp" + cIncidentNumber + ".txt";

				}

				if (cTransferStatus == "Z")
				{
					Fileline = Header01;
				}
				else
				{
					Fileline = Header02;
				}
				//CP Agency number - Position 48, beginning of incident number
				//48 - 55
				Fileline = Fileline + "06   CP";
				//56 - 64
				Fileline = Fileline + cIncidentNumber;
				//Alarm Date callreceived or call entered
				if (String.CompareOrdinal(cDateReceivedE911, "") > 0)
				{
					System.DateTime TempDate = DateTime.FromOADate(0);
					Fileline = Fileline + ((DateTime.TryParse(cDateReceivedE911, out TempDate)) ? TempDate.ToString("yyyyMMddHHNNSS") : cDateReceivedE911);
				}
				else
				{
					System.DateTime TempDate2 = DateTime.FromOADate(0);
					Fileline = Fileline + ((DateTime.TryParse(cDateIncidentCreated, out TempDate2)) ? TempDate2.ToString("yyyyMMddHHNNSS") : cDateIncidentCreated);
				}
				//First unit onscene
				if (String.CompareOrdinal(cDateFirstUnitOnscene, "") > 0)
				{
					System.DateTime TempDate3 = DateTime.FromOADate(0);
					Fileline = Fileline + ((DateTime.TryParse(cDateFirstUnitOnscene, out TempDate3)) ? TempDate3.ToString("yyyyMMddHHNNSS") : cDateFirstUnitOnscene);
				}
				else
				{
					Fileline = Fileline + new System.String(' ', 14);
				}

				//Firescene under control - not available
				Fileline = Fileline + new System.String(' ', 14);

				//Incident Cleared Time
				if (String.CompareOrdinal(cDateIncidentClosed, "") > 0)
				{
					System.DateTime TempDate4 = DateTime.FromOADate(0);
					Fileline = Fileline + ((DateTime.TryParse(cDateIncidentClosed, out TempDate4)) ? TempDate4.ToString("yyyyMMddHHNNSS") : cDateIncidentClosed);
				}
				else
				{
					Fileline = Fileline + new System.String(' ', 14);
				}

				//Initial dispatch type
				Fileline = Fileline + cCADInitialType + new System.String(' ', 6 - Strings.Len(cCADInitialType));

				//Space fill for Responding Station
				Fileline = Fileline + "00-0   ";

				if ( UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.String, System.Int32>((p1) =>
						{
							var ret = ParceAddress(ref p1);
							cGeoLocation = p1;
							return ret;
						}, cGeoLocation) != 0)
				{
					//Housenumber
					Fileline = Fileline + cCPHouse + new System.String(' ', 8 - Strings.Len(cCPHouse));
					//Street
					if (Strings.Len(cCPStreet) < 30)
					{
						Fileline = Fileline + cCPStreet + new System.String(' ', 30 - Strings.Len(cCPStreet));
					}
					else
					{
						Fileline = Fileline + cCPStreet.Substring(0, Math.Min(30, cCPStreet.Length));
					}
					//StreetType
					Fileline = Fileline + cCPStreetType + new System.String(' ', 4 - Strings.Len(cCPStreetType));
					//Prefix
					Fileline = Fileline + cCPPrefix + new System.String(' ', 2 - Strings.Len(cCPPrefix));
					//Suffix
					Fileline = Fileline + cCPSuffix + new System.String(' ', 2 - Strings.Len(cCPSuffix));
					//Apt number
					if (cLocation.IndexOf('#') >= 0)
					{
						x = (cLocation.IndexOf('#') + 1);
						cCPAptNo = cLocation.Substring(x - 1, Math.Min(Strings.Len(cLocation), cLocation.Length - (x - 1))).Trim();
						if (cCPAptNo.IndexOf(' ') >= 0)
						{
							x = (cCPAptNo.IndexOf(' ') + 1);
							cCPAptNo = cCPAptNo.Substring(0, Math.Min(x - 1, cCPAptNo.Length));
						}
						Fileline = Fileline + cCPAptNo + new System.String(' ', 10 - Strings.Len(cCPAptNo));
					}
					else
					{
						Fileline = Fileline + new System.String(' ', 10);
					}
					//********** City Code goes Here  *************
					//        Fileline = Fileline & "06" & Space(18)
					Fileline = Fileline + cCityCode + new System.String(' ', 20 - Strings.Len(cCityCode));
					//CrossStreet
					if (Strings.Len(cCPCrossStreet) < 30)
					{
						Fileline = Fileline + cCPCrossStreet + new System.String(' ', 30 - Strings.Len(cCPCrossStreet));
					}
					else if (cCPCrossStreet != "")
					{
						Fileline = Fileline + cCPCrossStreet.Substring(0, Math.Min(30, cCPCrossStreet.Length));
					}
					else
					{
						Fileline = Fileline + new System.String(' ', 30);
					}
					//Cross Street Type
					Fileline = Fileline + cCPCrossType + new System.String(' ', 4 - Strings.Len(cCPCrossType));
					//Cross Street Prefix
					Fileline = Fileline + cCPCrossPrefix + new System.String(' ', 2 - Strings.Len(cCPCrossPrefix));
					//Cross Street Suffix
					Fileline = Fileline + cCPCrossSuffix + new System.String(' ', 2 - Strings.Len(cCPCrossSuffix));
				}
				else
				{
					//House number
					Fileline = Fileline + new System.String(' ', 8);
					//All address goes in street
					if (Strings.Len(cGeoLocation) < 30)
					{
						Fileline = Fileline + cGeoLocation + new System.String(' ', 30 - Strings.Len(cGeoLocation));
					}
					else if (cGeoLocation != "")
					{
						Fileline = Fileline + cGeoLocation.Substring(0, Math.Min(30, cGeoLocation.Length));
					}
					else
					{
						Fileline = Fileline + new System.String(' ', 30);
					}
					//Rest of address fields
					Fileline = Fileline + new System.String(' ', 18);
					//********** City Code goes Here  *************
					Fileline = Fileline + "06" + new System.String(' ', 18);
					//Cross street fields
					Fileline = Fileline + new System.String(' ', 38);
				}
				if (~GetLatLong(lIncidentID) != 0)
				{
					//Longitude
					Fileline = Fileline + new System.String(' ', 11);
					//Latitude
					Fileline = Fileline + new System.String(' ', 11);
				}
				else
				{
					//Longitude
					Fileline = Fileline + cLLlong;
					//Latitude
					Fileline = Fileline + cLLlat;
				}

				//Fill for Map Page
				Fileline = Fileline + new System.String(' ', 11);
				//Fill for Run Card
				Fileline = Fileline + new System.String(' ', 7);
				//end of file delimiter
				Fileline = Fileline + Strings.Chr(3).ToString();

				//    Set FSO = CreateObject("Scripting.FileSystemObject")
				//    Set TextStm = FSO.CreateTextFile(FilePath)
				//    TextStm.Write (FileLine)
				ReturnCode = WriteCPIncident(Fileline, FilePath, BackupFilePath);
				//    ReturnCode = WriteCPIncident(Fileline, ArchiveFilePath, ArchiveFilePath)
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




		public int ParceAddress(ref string sAddress)
		{
			//Parce Incident geo_location into Central Pierce address fields
			int result = 0;
			string Address1 = "";
			string Address2 = "";
			int x = 0;


			try
			{
				//Clear Address Variables
				cCPHouse = "";
				cCPStreet = "";
				cCPStreetType = "";
				cCPPrefix = "";
				cCPSuffix = "";
				cCPAptNo = "";
				cCPCrossStreet = "";
				cCPCrossType = "";
				cCPCrossPrefix = "";
				cCPCrossSuffix = "";

				result = -1;

				//Look for intersection
				if (sAddress.IndexOf('/') >= 0)
				{
					x = (sAddress.IndexOf('/') + 1);
					Address1 = sAddress.Substring(0, Math.Min(x - 1, sAddress.Length));
					Address2 = sAddress.Substring(x, Math.Min(Strings.Len(sAddress), sAddress.Length - x)).Trim();
					if (~GetStreetFields(Address1) != 0)
					{
						cCPStreet = Address1;
					}
					if (~GetCrossStreetFields(Address2) != 0)
					{
						cCPCrossStreet = Address2;
					}
					return result;
				}

				//Check for CAD LAR
				if (CheckCAD_LAR(sAddress) != 0)
				{
					return result;
				}
				//Process Regular Address
				if (sAddress.IndexOf(' ') >= 0)
				{
					//Check for House number
					x = (sAddress.IndexOf(' ') + 1);
					cCPHouse = sAddress.Substring(0, Math.Min(x - 1, sAddress.Length));
					Address1 = sAddress.Substring(x - 1, Math.Min(Strings.Len(sAddress), sAddress.Length - (x - 1))).Trim();
					double dbNumericTemp = 0;
					if (Double.TryParse(cCPHouse, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
					{
						if (~GetStreetFields(Address1) != 0)
						{
							cCPStreet = Address1;
						}
					}
					else
					{
						Address1 = cCPHouse + " " + Address1;
						if (~GetStreetFields(Address1) != 0)
						{
							cCPStreet = Address1;
						}
					}
				}
				else
				{
					cCPStreet = sAddress;
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

		public int GetStreetFields(string sAddress)
		{
			//Load street fields into Central Pierce Class Variables
			int result = 0;
			string x = "";

			string AddressWork1 = sAddress;
			result = -1;
			//Check for Prefix
			if (AddressWork1.Substring(1, Math.Min(1, AddressWork1.Length - 1)) == " ")
			{
				cCPPrefix = AddressWork1.Substring(0, Math.Min(1, AddressWork1.Length));
				if (~ValidFix(cCPPrefix) != 0)
				{
					cCPPrefix = "";
				}
				else
				{
					AddressWork1 = AddressWork1.Substring(1, Math.Min(Strings.Len(AddressWork1), AddressWork1.Length - 1)).Trim();
				}
			}
			else if (AddressWork1.Substring(2, Math.Min(1, AddressWork1.Length - 2)) == " ")
			{
				cCPPrefix = AddressWork1.Substring(0, Math.Min(2, AddressWork1.Length));
				if (~ValidFix(cCPPrefix) != 0)
				{
					cCPPrefix = "";
				}
				else
				{
					AddressWork1 = AddressWork1.Substring(2, Math.Min(Strings.Len(AddressWork1), AddressWork1.Length - 2)).Trim();
				}
			}
			//Check for StreetType

			if (AddressWork1.IndexOf(' ') >= 0)
			{
				x = (AddressWork1.IndexOf(' ') + 1).ToString();
				cCPStreet = AddressWork1.Substring(0, Math.Min(Convert.ToInt32(Double.Parse(x) - 1), AddressWork1.Length));
				AddressWork1 = AddressWork1.Substring(Convert.ToInt32(Double.Parse(x)) - 1, Math.Min(Strings.Len(AddressWork1), AddressWork1.Length - (Convert.ToInt32(Double.Parse(x)) - 1))).Trim();
				if (ValidStreet(AddressWork1) != 0)
				{
					cCPStreetType = AddressWork1;
					//done
				}
				else if (AddressWork1.StartsWith("AV CT"))
				{
					cCPStreetType = "AVCT";
					if (Strings.Len(AddressWork1) > 5)
					{
						AddressWork1 = AddressWork1.Substring(5, Math.Min(Strings.Len(AddressWork1), AddressWork1.Length - 5)).Trim();
						if (ValidFix(AddressWork1) != 0)
						{
							cCPSuffix = AddressWork1;
						}
					}
					//done
				}
				else if (AddressWork1.IndexOf(' ') >= 0)
				{
					//StreetType & Suffix or  / Street Name with space?
					x = (AddressWork1.IndexOf(' ') + 1).ToString();
					if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(x) > 5)
					{
						cCPStreet = cCPStreet + " " + AddressWork1.Substring(0, Math.Min(Convert.ToInt32(Double.Parse(x) - 1), AddressWork1.Length));
						AddressWork1 = AddressWork1.Substring(Convert.ToInt32(Double.Parse(x)) - 1, Math.Min(Strings.Len(AddressWork1), AddressWork1.Length - (Convert.ToInt32(Double.Parse(x)) - 1))).Trim();
						if (AddressWork1.IndexOf(' ') >= 0)
						{
							x = (AddressWork1.IndexOf(' ') + 1).ToString();
							if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(x) > 5)
							{
								cCPStreet = cCPStreet + " " + AddressWork1.Substring(0, Math.Min(Convert.ToInt32(Double.Parse(x) - 1), AddressWork1.Length));
								AddressWork1 = AddressWork1.Substring(Convert.ToInt32(Double.Parse(x)) - 1, Math.Min(Strings.Len(AddressWork1), AddressWork1.Length - (Convert.ToInt32(Double.Parse(x)) - 1))).Trim();
								if (AddressWork1.IndexOf(' ') >= 0)
								{
									x = (AddressWork1.IndexOf(' ') + 1).ToString();
									cCPStreetType = AddressWork1.Substring(0, Math.Min(Convert.ToInt32(Double.Parse(x) - 1), AddressWork1.Length));
									AddressWork1 = AddressWork1.Substring(Convert.ToInt32(Double.Parse(x)) - 1, Math.Min(Strings.Len(AddressWork1), AddressWork1.Length - (Convert.ToInt32(Double.Parse(x)) - 1))).Trim();
									if (ValidStreet(cCPStreetType) != 0)
									{
										if (ValidFix(AddressWork1) != 0)
										{
											cCPSuffix = AddressWork1;
										}
									}
									else if (ValidFix(cCPStreetType) != 0)
									{
										cCPSuffix = cCPStreetType;
										cCPStreetType = "";
									}
									else
									{
										cCPStreet = cCPStreet + " " + cCPStreetType + " " + AddressWork1;
										cCPStreetType = "";
										//give up
									}
								}
								else if (ValidStreet(AddressWork1) != 0)
								{
									cCPStreetType = AddressWork1;
								}
								else if (ValidFix(AddressWork1) != 0)
								{
									cCPSuffix = AddressWork1;
								}
								else
								{
									//give up
									cCPStreet = cCPStreet + " " + AddressWork1;
								}
							}
							else
							{
								cCPStreetType = AddressWork1.Substring(0, Math.Min(Convert.ToInt32(Double.Parse(x) - 1), AddressWork1.Length));
								AddressWork1 = AddressWork1.Substring(Convert.ToInt32(Double.Parse(x)) - 1, Math.Min(Strings.Len(AddressWork1), AddressWork1.Length - (Convert.ToInt32(Double.Parse(x)) - 1))).Trim();
								if (ValidStreet(cCPStreetType) != 0)
								{
									if (ValidFix(AddressWork1) != 0)
									{
										cCPSuffix = AddressWork1;
									}
								}
								else if (ValidFix(cCPStreetType) != 0)
								{
									cCPSuffix = cCPStreetType;
									cCPStreetType = "";
								}
								else
								{
									cCPStreet = cCPStreet + " " + cCPStreetType;
									cCPStreetType = AddressWork1;
									if (~ValidStreet(cCPStreetType) != 0)
									{
										if (~ValidFix(cCPStreetType) != 0)
										{
											cCPStreet = cCPStreet + " " + cCPStreetType;
											cCPStreetType = "";
										}
										else
										{
											cCPSuffix = cCPStreetType;
											cCPStreetType = "";
										}
									}
								}
							}
						}
						else
						{
							cCPStreetType = AddressWork1;
							if (~ValidStreet(cCPStreetType) != 0)
							{
								cCPSuffix = cCPStreetType;
								cCPStreetType = "";
								if (~ValidFix(cCPSuffix) != 0)
								{
									cCPStreet = cCPStreet + " " + cCPSuffix;
									cCPSuffix = "";
								}
							}
						}
					}
					else
					{
						cCPStreetType = AddressWork1.Substring(0, Math.Min(Convert.ToInt32(Double.Parse(x) - 1), AddressWork1.Length));
						AddressWork1 = AddressWork1.Substring(Convert.ToInt32(Double.Parse(x)) - 1, Math.Min(Strings.Len(AddressWork1), AddressWork1.Length - (Convert.ToInt32(Double.Parse(x)) - 1))).Trim();
						if (~ValidStreet(cCPStreetType) != 0)
						{
							cCPStreet = cCPStreet + " " + cCPStreetType;
							cCPStreetType = AddressWork1;
							if (~ValidStreet(cCPStreetType) != 0)
							{
								cCPSuffix = cCPStreetType;
								cCPStreetType = "";
								if (~ValidFix(cCPSuffix) != 0)
								{
									cCPStreet = cCPStreet + " " + cCPSuffix;
									cCPSuffix = "";
								}
							}
						}
						else if (ValidFix(AddressWork1) != 0)
						{
							cCPSuffix = AddressWork1;
						}
					}
				}
				else
				{
					cCPStreet = cCPStreet + " " + AddressWork1;
				}
			}
			else
			{
				cCPStreet = AddressWork1;
			}

			return result;
		}


		public int ValidFix(string sFix)
		{
			//Test variable for validity as a Prefix or Suffix
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;
				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_StreetFixValid '" + sFix + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (oRec.EOF)
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

		public int ValidStreet(string sStreetType)
		{
			//Test variable for validity as a streettype
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;
				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_StreetTypeValid '" + sStreetType + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (oRec.EOF)
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

		public int GetCrossStreetFields(string sAddress)
		{
			//Load cross street fields into Central Pierce Class Variables
			string x = "";

			string AddressWork2 = sAddress;

			if (AddressWork2.Substring(1, Math.Min(1, AddressWork2.Length - 1)) == " ")
			{
				cCPCrossPrefix = AddressWork2.Substring(0, Math.Min(1, AddressWork2.Length));
				if (~ValidFix(cCPCrossPrefix) != 0)
				{
					cCPCrossPrefix = "";
				}
				else
				{
					AddressWork2 = AddressWork2.Substring(1, Math.Min(Strings.Len(AddressWork2), AddressWork2.Length - 1)).Trim();
				}
			}
			else if (AddressWork2.Substring(2, Math.Min(1, AddressWork2.Length - 2)) == " ")
			{
				cCPCrossPrefix = AddressWork2.Substring(0, Math.Min(2, AddressWork2.Length));
				if (~ValidFix(cCPCrossPrefix) != 0)
				{
					cCPCrossPrefix = "";
				}
				else
				{
					AddressWork2 = AddressWork2.Substring(2, Math.Min(Strings.Len(AddressWork2), AddressWork2.Length - 2)).Trim();
				}
			}
			//Check for StreetType
			if (AddressWork2.IndexOf(' ') >= 0)
			{
				x = (AddressWork2.IndexOf(' ') + 1).ToString();
				cCPCrossStreet = AddressWork2.Substring(0, Math.Min(Convert.ToInt32(Double.Parse(x) - 1), AddressWork2.Length));
				AddressWork2 = AddressWork2.Substring(Convert.ToInt32(Double.Parse(x)) - 1, Math.Min(Strings.Len(AddressWork2), AddressWork2.Length - (Convert.ToInt32(Double.Parse(x)) - 1))).Trim();
				//-------2-----------
				if (ValidStreet(AddressWork2) != 0)
				{
					cCPCrossType = AddressWork2;
					//done
				}
				else if (AddressWork2.StartsWith("AV CT"))
				{
					cCPCrossType = "AVCT";
					if (Strings.Len(AddressWork2) > 5)
					{
						AddressWork2 = AddressWork2.Substring(5, Math.Min(Strings.Len(AddressWork2), AddressWork2.Length - 5)).Trim();
						if (ValidFix(AddressWork2) != 0)
						{
							cCPCrossSuffix = AddressWork2;
						}
					}
					//done
				}
				else if (AddressWork2.IndexOf(' ') >= 0)
				{
					//StreetType & Suffix or  / Street Name with space?
					x = (AddressWork2.IndexOf(' ') + 1).ToString();
					//-------3------
					if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(x) > 5)
					{
						cCPCrossStreet = cCPCrossStreet + " " + AddressWork2.Substring(0, Math.Min(Convert.ToInt32(Double.Parse(x) - 1), AddressWork2.Length));
						AddressWork2 = AddressWork2.Substring(Convert.ToInt32(Double.Parse(x)) - 1, Math.Min(Strings.Len(AddressWork2), AddressWork2.Length - (Convert.ToInt32(Double.Parse(x)) - 1))).Trim();
						//-------4-----------
						if (AddressWork2.IndexOf(' ') >= 0)
						{
							x = (AddressWork2.IndexOf(' ') + 1).ToString();
							//--5--------
							if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(x) > 5)
							{
								cCPCrossStreet = cCPCrossStreet + " " + AddressWork2.Substring(0, Math.Min(Convert.ToInt32(Double.Parse(x) - 1), AddressWork2.Length));
								AddressWork2 = AddressWork2.Substring(Convert.ToInt32(Double.Parse(x)) - 1, Math.Min(Strings.Len(AddressWork2), AddressWork2.Length - (Convert.ToInt32(Double.Parse(x)) - 1))).Trim();
								if (AddressWork2.IndexOf(' ') >= 0)
								{
									x = (AddressWork2.IndexOf(' ') + 1).ToString();
									cCPCrossType = AddressWork2.Substring(0, Math.Min(Convert.ToInt32(Double.Parse(x) - 1), AddressWork2.Length));
									AddressWork2 = AddressWork2.Substring(Convert.ToInt32(Double.Parse(x)) - 1, Math.Min(Strings.Len(AddressWork2), AddressWork2.Length - (Convert.ToInt32(Double.Parse(x)) - 1))).Trim();
									if (ValidStreet(cCPCrossType) != 0)
									{
										if (ValidFix(AddressWork2) != 0)
										{
											cCPCrossSuffix = AddressWork2;
										}
									}
									else if (ValidFix(cCPCrossType) != 0)
									{
										cCPCrossSuffix = cCPCrossType;
										cCPCrossType = "";
									}
									else
									{
										cCPCrossStreet = cCPCrossStreet + " " + cCPCrossType + " " + AddressWork2;
										cCPCrossType = "";
										//give up
									}
								}
								else if (ValidStreet(AddressWork2) != 0)
								{
									cCPCrossType = AddressWork2;
								}
								else if (ValidFix(AddressWork2) != 0)
								{
									cCPCrossSuffix = AddressWork2;
								}
								else
								{
									//give up
									cCPCrossStreet = cCPCrossStreet + " " + AddressWork2;
								}
							}
							else
							{
								cCPCrossType = AddressWork2.Substring(0, Math.Min(Convert.ToInt32(Double.Parse(x) - 1), AddressWork2.Length));
								AddressWork2 = AddressWork2.Substring(Convert.ToInt32(Double.Parse(x)) - 1, Math.Min(Strings.Len(AddressWork2), AddressWork2.Length - (Convert.ToInt32(Double.Parse(x)) - 1))).Trim();
								if (ValidStreet(cCPCrossType) != 0)
								{
									if (ValidFix(AddressWork2) != 0)
									{
										cCPCrossSuffix = AddressWork2;
									}
								}
								else if (ValidFix(cCPCrossType) != 0)
								{
									cCPCrossSuffix = cCPCrossType;
									cCPCrossType = "";
								}
								else
								{
									cCPCrossStreet = cCPCrossStreet + " " + cCPCrossType;
									cCPCrossType = AddressWork2;
									if (~ValidStreet(cCPCrossType) != 0)
									{
										if (~ValidFix(cCPCrossType) != 0)
										{
											cCPCrossStreet = cCPCrossStreet + " " + cCPCrossType;
											cCPCrossType = "";
										}
										else
										{
											cCPCrossSuffix = cCPCrossType;
											cCPCrossType = "";
										}
									}
								}
							}
							//------------5
						}
						else
						{
							cCPCrossType = AddressWork2;
							if (~ValidStreet(cCPCrossType) != 0)
							{
								cCPCrossSuffix = cCPCrossType;
								cCPCrossType = "";
								if (~ValidFix(cCPCrossSuffix) != 0)
								{
									cCPCrossStreet = cCPCrossStreet + " " + cCPCrossSuffix;
									cCPCrossSuffix = "";
								}
							}
						}
						//----4
					}
					else
					{
						cCPCrossType = AddressWork2.Substring(0, Math.Min(Convert.ToInt32(Double.Parse(x) - 1), AddressWork2.Length));
						AddressWork2 = AddressWork2.Substring(Convert.ToInt32(Double.Parse(x)) - 1, Math.Min(Strings.Len(AddressWork2), AddressWork2.Length - (Convert.ToInt32(Double.Parse(x)) - 1))).Trim();
						if (~ValidStreet(cCPCrossType) != 0)
						{
							cCPCrossStreet = cCPCrossStreet + " " + cCPCrossType;
							cCPCrossType = AddressWork2;
							if (~ValidStreet(cCPCrossType) != 0)
							{
								cCPCrossSuffix = cCPCrossType;
								cCPCrossType = "";
								if (~ValidFix(cCPCrossSuffix) != 0)
								{
									cCPCrossStreet = cCPCrossStreet + " " + cCPCrossSuffix;
									cCPCrossSuffix = "";
								}
							}
						}
						else if (ValidFix(AddressWork2) != 0)
						{
							cCPCrossSuffix = AddressWork2;
						}
					}
				}
				else
				{
					cCPCrossStreet = cCPCrossStreet + " " + AddressWork2;
				}
				//----1
			}
			else
			{
				cCPCrossStreet = AddressWork2;
			}

			return 0;
		}


		public int CheckCAD_LAR(string sAddress)
		{
			//Test to see if Address is LAR alias
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;
				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_CADLAR '" + sAddress + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cCPHouse = IncidentMain.Clean(oRec["house"]);
					cCPPrefix = IncidentMain.Clean(oRec["prefix"]);
					cCPStreet = IncidentMain.Clean(oRec["street"]);
					cCPStreetType = IncidentMain.Clean(oRec["street_type"]);
					cCPSuffix = IncidentMain.Clean(oRec["suffix"]);
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

		public int CheckCAD_AdvisedIncident(string sType)
		{
			//Test to see if Incident is Advised Event
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;
				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_AdvisedIncident '" + sType + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");


				if (!oRec.EOF)
				{
					return Convert.ToInt32(oRec["ADVType"]);
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


		public int WriteCPIncident(string sFileline, string sFilePath, string sBackUpPath)
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
			    //    If sTrans = "Z" Then
			    //        FilePath = FilePath & "inc01_cp" & cIncidentNumber & ".txt"
			    //        BackupFilePath = BackupFilePath & "inc01_cp" & cIncidentNumber & ".txt"
			    //    Else
			    //        FilePath = FilePath & "inc03_cp" & cIncidentNumber & ".txt"
			    //        BackupFilePath = BackupFilePath & "inc03_cp" & cIncidentNumber & ".txt"
			    //    End If
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


		public int GetLatLong(int lIncidentID)
{
	//Retreive specified Incident Lat Long fields
	//Set Class  Variables to Retrieved Record
	int result = 0;
	DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
	ADORecordSetHelper oRec = null;

	try
	{

		oCmd.Connection = IncidentMain.oIncident;
		oCmd.CommandType = CommandType.Text;
		oCmd.CommandText = "spSelect_IncidentLATLONG " + lIncidentID.ToString();
		oRec = ADORecordSetHelper.Open(oCmd, "");

		if (!oRec.EOF)
		{
			//Set Incident Lat Long Class Variables
			cLLIncidentID = lIncidentID;
			cLLlat = IncidentMain.Clean(oRec["lat"]);
			cLLlong = IncidentMain.Clean(oRec["long"]);
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

		public int GetCADType(int lIncidentID)
		{
			//Retreive specified Incident CAD Initial Type Code Description
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_IncidentCADType " + lIncidentID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cCADType = IncidentMain.Clean(oRec["CADType"]);
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