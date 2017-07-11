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

	public class clsEMS
		: UpgradeHelpers.Interfaces.IDependentModel, UpgradeHelpers.Interfaces.ICreatesObjects, UpgradeHelpers
		.Interfaces.IInteractsWithView, UpgradeHelpers.Interfaces.IInitializableCommon, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(clsEMS));
		}

		void UpgradeHelpers.Interfaces.IInitializableCommon.Common()
		{
			_cEMSIncidentStaffing = null;
			_cEMSContributingFactor = null;
			cCFPatientID = 0;
			cEMSContributingFactorCode = 0;
			_cEMSCPR = null;
			cCPRPatientID = 0;
			cTimeArrestToCPR = 0;
			cTimeArrestToAls = 0;
			cTimeArrestToShock = 0;
			cFlagPulseRestored = 0;
			_cEMSCPRPerformer = null;
			cCPRID = 0;
			cCPRPerfPatientID = 0;
			cCPRPerformedBy = 0;
			cFlagArrestWitnessed = 0;
			cFlagCPRTrained = 0;
			_cEMSMedication = null;
			cMedPatientID = 0;
			cMedication = 0;
			cAdministeredDosage = 0;
			_cEMSPatient = null;
			cEMSPatientID = 0;
			cBirthdate = "";
			cNameLast = "";
			cNameFirst = "";
			cNameMI = "";
			cSocialSecurityNumber = "";
			cBillingAddress = "";
			cCity = "";
			cState = "";
			cZipcode = "";
			cPhone = "";
			cFlagDNRO = UpgradeHelpers.Helpers.CheckState.Unchecked;
			_cEMSPatientContact = null;
			_cIncidentEMSPatients = null;
			CPatientID = 0;
			cIncidentID = 0;
			cActionTaken = 0;
			cIncidentType = 0;
			cGender = 0;
			cAge = 0;
			cAgeUnit = 0;
			cRace = 0;
			cEthnicity = 0;
			cIncidentLocation = 0;
			cIncidentZipcode = "";
			cIncidentSetting = 0;
			cSeverity = 0;
			cDispatchedAlsBls = "";
			cLevelOfCareAlsBls = "";
			cTreatmentAuthorization = 0;
			cServiceProvided = 0;
			cResearchCode = 0;
			_cEMCPatientExam = null;
			cExamPatientID = 0;
			cMechCode = 0;
			cInjuryType = 0;
			cPrimaryIllness = 0;
			cPupils = 0;
			cLevelOfConsciousness = 0;
			cRespiratoryEffort = 0;
			cFlagExtricationRequired = 0;
			cExtricationTime = 0;
			_cEMSPatientIVLine = null;
			cLineID = 0;
			CivPatientID = 0;
			cIVGauge = 0;
			cIVRoute = 0;
			cIVRate = 0;
			cIVSite = 0;
			cIVAmount = 0;
			cFlagSalineLock = 0;
			_cEMSPatientNarration = null;
			cEMSNarrationID = 0;
			cNarrPatientID = 0;
			cNarrationText = "";
			cNarrationBy = "";
			cNarrationDate = "";
			_cEMSPatientTransport = null;
			cTransPatientID = 0;
			cHospitalChosenBy = 0;
			cFlagDiverted = UpgradeHelpers.Helpers.CheckState.Unchecked;
			cBaseStation = 0;
			cHospitalStaffType = 0;
			cMileage = 0;
			cTransportedTo = 0;
			cTransportedFrom = 0;
			cTransportBy = "";
			_cEMSPatientTrauma = null;
			cTraumaPatientID = 0;
			cTraumaID = "";
			cProtectiveDevice = 0;
			cTraumaLocation = 0;
			cRevisedTraumaScore = 0;
			_cEMSPatientVitals = null;
			cVitalsID = 0;
			cVitalPatientID = 0;
			cVitalsTime = "";
			cGCSEyes = 0;
			cGCSVerbal = 0;
			cGCSMotor = 0;
			cSystolic = 0;
			cDiastolic = 0;
			cFlagDiastolicPalp = 0;
			cPulse = 0;
			cRespirationRate = 0;
			cVitalsPosition = 0;
			cBloodGlucose = 0;
			cPulseOxygen = 0;
			cPercentOxygen = 0;
			cECG = 0;
			_cEMSPreExistingCondition = null;
			cPreExistPatientID = 0;
			cPreExistingConditionCode = 0;
			_cEMSProcedure = null;
			cProcedureID = 0;
			cProcedurePatientID = 0;
			cProcedure = 0;
			cPerformedBy = "";
			cAttempts = 0;
			cFlagSuccessful = 0;
			cOtherProcedureDescription = "";
			_cEMSSecondaryIllness = null;
			cSecIllPatientID = 0;
			cSecondaryIllnessCode = 0;
			_cEMSTraumaDescriptor = null;
			cTraumaDescrPatientID = 0;
			cTraumaType = 0;
			_cFDCaresReferral = null;
			cReferralID = 0;
			cReferralIncidentID = 0;
			cReferredBy = "";
			cReferralPatientID = 0;
			cReferralComment = "";
		}

		//********************************************************
		//**    EMS Class                                       **
		//********************************************************
		//**    Methods                                         **
		//**----------------------------------------------------**
		//**
		//********************************************************


		//********************************************************
		//**             Private Class Variables                **
		//********************************************************
		//EMSIncidentStaffing
		public virtual ADORecordSetHelper _cEMSIncidentStaffing { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cEMSIncidentStaffing
		{
			get
			{
				if (_cEMSIncidentStaffing == null)
				{
					_cEMSIncidentStaffing = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cEMSIncidentStaffing;
			}
			set
			{
				_cEMSIncidentStaffing = value;
			}
		}


		//EMSContributingFactor
		public virtual ADORecordSetHelper _cEMSContributingFactor { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cEMSContributingFactor
		{
			get
			{
				if (_cEMSContributingFactor == null)
				{
					_cEMSContributingFactor = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cEMSContributingFactor;
			}
			set
			{
				_cEMSContributingFactor = value;
			}
		}

		public virtual int cCFPatientID { get; set; }

		public virtual int cEMSContributingFactorCode { get; set; }

		//EMSCPR
		public virtual ADORecordSetHelper _cEMSCPR { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cEMSCPR
		{
			get
			{
				if (_cEMSCPR == null)
				{
					_cEMSCPR = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cEMSCPR;
			}
			set
			{
				_cEMSCPR = value;
			}
		}

		public virtual int cCPRPatientID { get; set; }

		public virtual int cTimeArrestToCPR { get; set; }

		public virtual int cTimeArrestToAls { get; set; }

		public virtual int cTimeArrestToShock { get; set; }

		public virtual byte cFlagPulseRestored { get; set; }

		//EMSCPRPerformer
		public virtual ADORecordSetHelper _cEMSCPRPerformer { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cEMSCPRPerformer
		{
			get
			{
				if (_cEMSCPRPerformer == null)
				{
					_cEMSCPRPerformer = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cEMSCPRPerformer;
			}
			set
			{
				_cEMSCPRPerformer = value;
			}
		}

		public virtual int cCPRID { get; set; }

		public virtual int cCPRPerfPatientID { get; set; }

		public virtual int cCPRPerformedBy { get; set; }

		public virtual byte cFlagArrestWitnessed { get; set; }

		public virtual byte cFlagCPRTrained { get; set; }


		//  EMSMedication
		public virtual ADORecordSetHelper _cEMSMedication { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cEMSMedication
		{
			get
			{
				if (_cEMSMedication == null)
				{
					_cEMSMedication = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cEMSMedication;
			}
			set
			{
				_cEMSMedication = value;
			}
		}

		public virtual int cMedPatientID { get; set; }

		public virtual int cMedication { get; set; }

		public virtual int cAdministeredDosage { get; set; }

		//  EMSPatient
		public virtual ADORecordSetHelper _cEMSPatient { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cEMSPatient
		{
			get
			{
				if (_cEMSPatient == null)
				{
					_cEMSPatient = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cEMSPatient;
			}
			set
			{
				_cEMSPatient = value;
			}
		}

		public virtual int cEMSPatientID { get; set; }

		public virtual string cBirthdate { get; set; }

		public virtual string cNameLast { get; set; }

		public virtual string cNameFirst { get; set; }

		public virtual string cNameMI { get; set; }

		public virtual string cSocialSecurityNumber { get; set; }

		public virtual string cBillingAddress { get; set; }

		public virtual string cCity { get; set; }

		public virtual string cState { get; set; }

		public virtual string cZipcode { get; set; }

		public virtual string cPhone { get; set; }

		public virtual UpgradeHelpers.Helpers.CheckState cFlagDNRO { get; set; }

		//  EMSPatientContact
		public virtual ADORecordSetHelper _cEMSPatientContact { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cEMSPatientContact
		{
			get
			{
				if (_cEMSPatientContact == null)
				{
					_cEMSPatientContact = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cEMSPatientContact;
			}
			set
			{
				_cEMSPatientContact = value;
			}
		}

		public virtual ADORecordSetHelper _cIncidentEMSPatients { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cIncidentEMSPatients
		{
			get
			{
				if (_cIncidentEMSPatients == null)
				{
					_cIncidentEMSPatients = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cIncidentEMSPatients;
			}
			set
			{
				_cIncidentEMSPatients = value;
			}
		}

		public virtual int CPatientID { get; set; }

		public virtual int cIncidentID { get; set; }

		public virtual int cActionTaken { get; set; }

		public virtual int cIncidentType { get; set; }

		public virtual int cGender { get; set; }

		public virtual int cAge { get; set; }

		public virtual int cAgeUnit { get; set; }

		public virtual int cRace { get; set; }

		public virtual int cEthnicity { get; set; }

		public virtual int cIncidentLocation { get; set; }

		public virtual string cIncidentZipcode { get; set; }

		public virtual int cIncidentSetting { get; set; }

		public virtual int cSeverity { get; set; }

		public virtual string cDispatchedAlsBls { get; set; }

		public virtual string cLevelOfCareAlsBls { get; set; }

		public virtual int cTreatmentAuthorization { get; set; }

		public virtual int cServiceProvided { get; set; }

		public virtual int cResearchCode { get; set; }

		//  EMSPatientExam
		public virtual ADORecordSetHelper _cEMCPatientExam { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cEMCPatientExam
		{
			get
			{
				if (_cEMCPatientExam == null)
				{
					_cEMCPatientExam = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cEMCPatientExam;
			}
			set
			{
				_cEMCPatientExam = value;
			}
		}

		public virtual int cExamPatientID { get; set; }

		public virtual int cMechCode { get; set; }

		public virtual int cInjuryType { get; set; }

		public virtual int cPrimaryIllness { get; set; }

		public virtual int cPupils { get; set; }

		public virtual int cLevelOfConsciousness { get; set; }

		public virtual int cRespiratoryEffort { get; set; }

		public virtual int cFlagExtricationRequired { get; set; }

		public virtual int cExtricationTime { get; set; }

		//  EMSPatientIVLine
		public virtual ADORecordSetHelper _cEMSPatientIVLine { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cEMSPatientIVLine
		{
			get
			{
				if (_cEMSPatientIVLine == null)
				{
					_cEMSPatientIVLine = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cEMSPatientIVLine;
			}
			set
			{
				_cEMSPatientIVLine = value;
			}
		}

		public virtual int cLineID { get; set; }

		public virtual int CivPatientID { get; set; }

		public virtual int cIVGauge { get; set; }

		public virtual int cIVRoute { get; set; }

		public virtual int cIVRate { get; set; }

		public virtual int cIVSite { get; set; }

		public virtual int cIVAmount { get; set; }

		public virtual byte cFlagSalineLock { get; set; }

		//EMSPatientNarration
		public virtual ADORecordSetHelper _cEMSPatientNarration { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cEMSPatientNarration
		{
			get
			{
				if (_cEMSPatientNarration == null)
				{
					_cEMSPatientNarration = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cEMSPatientNarration;
			}
			set
			{
				_cEMSPatientNarration = value;
			}
		}

		public virtual int cEMSNarrationID { get; set; }

		public virtual int cNarrPatientID { get; set; }

		public virtual string cNarrationText { get; set; }

		public virtual string cNarrationBy { get; set; }

		public virtual string cNarrationDate { get; set; }

		//  EMSPatientTransport
		public virtual ADORecordSetHelper _cEMSPatientTransport { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cEMSPatientTransport
		{
			get
			{
				if (_cEMSPatientTransport == null)
				{
					_cEMSPatientTransport = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cEMSPatientTransport;
			}
			set
			{
				_cEMSPatientTransport = value;
			}
		}

		public virtual int cTransPatientID { get; set; }

		public virtual int cHospitalChosenBy { get; set; }

		public virtual UpgradeHelpers.Helpers.CheckState cFlagDiverted { get; set; }

		public virtual int cBaseStation { get; set; }

		public virtual int cHospitalStaffType { get; set; }

		public virtual float cMileage { get; set; }

		public virtual int cTransportedTo { get; set; }

		public virtual int cTransportedFrom { get; set; }

		public virtual string cTransportBy { get; set; }

		//  EMSPatientTrauma
		public virtual ADORecordSetHelper _cEMSPatientTrauma { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cEMSPatientTrauma
		{
			get
			{
				if (_cEMSPatientTrauma == null)
				{
					_cEMSPatientTrauma = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cEMSPatientTrauma;
			}
			set
			{
				_cEMSPatientTrauma = value;
			}
		}

		public virtual int cTraumaPatientID { get; set; }

		public virtual string cTraumaID { get; set; }

		public virtual int cProtectiveDevice { get; set; }

		public virtual int cTraumaLocation { get; set; }

		public virtual int cRevisedTraumaScore { get; set; }

		// EMSPatientVitals
		public virtual ADORecordSetHelper _cEMSPatientVitals { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cEMSPatientVitals
		{
			get
			{
				if (_cEMSPatientVitals == null)
				{
					_cEMSPatientVitals = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cEMSPatientVitals;
			}
			set
			{
				_cEMSPatientVitals = value;
			}
		}

		public virtual int cVitalsID { get; set; }

		public virtual int cVitalPatientID { get; set; }

		public virtual string cVitalsTime { get; set; }

		public virtual int cGCSEyes { get; set; }

		public virtual int cGCSVerbal { get; set; }

		public virtual int cGCSMotor { get; set; }

		public virtual int cSystolic { get; set; }

		public virtual int cDiastolic { get; set; }

		public virtual byte cFlagDiastolicPalp { get; set; }

		public virtual int cPulse { get; set; }

		public virtual int cRespirationRate { get; set; }

		public virtual int cVitalsPosition { get; set; }

		public virtual int cBloodGlucose { get; set; }

		public virtual int cPulseOxygen { get; set; }

		public virtual int cPercentOxygen { get; set; }

		public virtual int cECG { get; set; }

		//  EMSPreExisingCondition
		public virtual ADORecordSetHelper _cEMSPreExistingCondition { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cEMSPreExistingCondition
		{
			get
			{
				if (_cEMSPreExistingCondition == null)
				{
					_cEMSPreExistingCondition = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cEMSPreExistingCondition;
			}
			set
			{
				_cEMSPreExistingCondition = value;
			}
		}

		public virtual int cPreExistPatientID { get; set; }

		public virtual int cPreExistingConditionCode { get; set; }

		//  EMSProcedure
		public virtual ADORecordSetHelper _cEMSProcedure { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cEMSProcedure
		{
			get
			{
				if (_cEMSProcedure == null)
				{
					_cEMSProcedure = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cEMSProcedure;
			}
			set
			{
				_cEMSProcedure = value;
			}
		}

		public virtual int cProcedureID { get; set; }

		public virtual int cProcedurePatientID { get; set; }

		public virtual int cProcedure { get; set; }

		public virtual string cPerformedBy { get; set; }

		public virtual int cAttempts { get; set; }

		public virtual byte cFlagSuccessful { get; set; }

		public virtual string cOtherProcedureDescription { get; set; }

		//  EMSSecondaryIllness
		public virtual ADORecordSetHelper _cEMSSecondaryIllness { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cEMSSecondaryIllness
		{
			get
			{
				if (_cEMSSecondaryIllness == null)
				{
					_cEMSSecondaryIllness = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cEMSSecondaryIllness;
			}
			set
			{
				_cEMSSecondaryIllness = value;
			}
		}

		public virtual int cSecIllPatientID { get; set; }

		public virtual int cSecondaryIllnessCode { get; set; }

		//  EMSTraumaDescriptor
		public virtual ADORecordSetHelper _cEMSTraumaDescriptor { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cEMSTraumaDescriptor
		{
			get
			{
				if (_cEMSTraumaDescriptor == null)
				{
					_cEMSTraumaDescriptor = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cEMSTraumaDescriptor;
			}
			set
			{
				_cEMSTraumaDescriptor = value;
			}
		}

		public virtual int cTraumaDescrPatientID { get; set; }

		public virtual int cTraumaType { get; set; }

		//  FDCaresReferral
		public virtual ADORecordSetHelper _cFDCaresReferral { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cFDCaresReferral
		{
			get
			{
				if (_cFDCaresReferral == null)
				{
					_cFDCaresReferral = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cFDCaresReferral;
			}
			set
			{
				_cFDCaresReferral = value;
			}
		}

		public virtual int cReferralID { get; set; }

		public virtual int cReferralIncidentID { get; set; }

		public virtual string cReferredBy { get; set; }

		public virtual int cReferralPatientID { get; set; }

		public virtual string cReferralComment { get; set; }


		//***************************************************
		//**         Class Public Properties               **
		//***************************************************
		//EMSIncidentStaffing
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper EMSIncidentStaffing
		{
			get
			{
				return cEMSIncidentStaffing;
			}
			set
			{
				cEMSIncidentStaffing = value;
			}
		}



		//EMSContributingFactor
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper EMSContributingFactor
		{
			get
			{
				return cEMSContributingFactor;
			}
			set
			{
				cEMSContributingFactor = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int CFPatientID
		{
			get
			{
				return cCFPatientID;
			}
			set
			{
				cCFPatientID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int EMSContributingFactorCode
		{
			get
			{
				return cEMSContributingFactorCode;
			}
			set
			{
				cEMSContributingFactorCode = value;
			}
		}


		//EMSCPR
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper EMSCPR
		{
			get
			{
				return cEMSCPR;
			}
			set
			{
				cEMSCPR = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int CPRPatientID
		{
			get
			{
				return cCPRPatientID;
			}
			set
			{
				cCPRPatientID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int TimeArrestToCPR
		{
			get
			{
				return cTimeArrestToCPR;
			}
			set
			{
				cTimeArrestToCPR = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int TimeArrestToAls
		{
			get
			{
				return cTimeArrestToAls;
			}
			set
			{
				cTimeArrestToAls = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int TimeArrestToShock
		{
			get
			{
				return cTimeArrestToShock;
			}
			set
			{
				cTimeArrestToShock = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte FlagPulseRestored
		{
			get
			{
				return cFlagPulseRestored;
			}
			set
			{
				cFlagPulseRestored = value;
			}
		}


		//EMSCPRPerformer
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper EMSCPRPerformer
		{
			get
			{
				return cEMSCPRPerformer;
			}
			set
			{
				cEMSCPRPerformer = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int CPRID
		{
			get
			{
				return cCPRID;
			}
			set
			{
				cCPRID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int CPRPerfPatientID
		{
			get
			{
				return cCPRPerfPatientID;
			}
			set
			{
				cCPRPerfPatientID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int CPRPerformedBy
		{
			get
			{
				return cCPRPerformedBy;
			}
			set
			{
				cCPRPerformedBy = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte FlagCPRTrained
		{
			get
			{
				return cFlagCPRTrained;
			}
			set
			{
				cFlagCPRTrained = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte FlagArrestWitnessed
		{
			get
			{
				return cFlagArrestWitnessed;
			}
			set
			{
				cFlagArrestWitnessed = value;
			}
		}


		//  EMSMedication
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper EMSMedication
		{
			get
			{
				return cEMSMedication;
			}
			set
			{
				cEMSMedication = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int MedPatientID
		{
			get
			{
				return cMedPatientID;
			}
			set
			{
				cMedPatientID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int Medication
		{
			get
			{
				return cMedication;
			}
			set
			{
				cMedication = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int AdministeredDosage
		{
			get
			{
				return cAdministeredDosage;
			}
			set
			{
				cAdministeredDosage = value;
			}
		}


		//  EMSPatient
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper EMSPatient
		{
			get
			{
				return cEMSPatient;
			}
			set
			{
				cEMSPatient = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int EMSPatientID
		{
			get
			{
				return cEMSPatientID;
			}
			set
			{
				cEMSPatientID = value;
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


		public string SocialSecurityNumber
		{
			get
			{
				return cSocialSecurityNumber;
			}
			set
			{
				cSocialSecurityNumber = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string BillingAddress
		{
			get
			{
				return cBillingAddress;
			}
			set
			{
				cBillingAddress = value;
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


		public string State
		{
			get
			{
				return cState;
			}
			set
			{
				cState = value;
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


		public string Phone
		{
			get
			{
				return cPhone;
			}
			set
			{
				cPhone = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte FlagDNRO
		{
			get
			{
				return (byte) cFlagDNRO;
			}
			set
			{
				//UPGRADE_WARNING: (6021) Casting 'byte' to Enum may cause different behaviour. More Information: http://www.vbtonet.com/ewis/ewi6021.aspx
				cFlagDNRO = (UpgradeHelpers.Helpers.CheckState) value;
			}
		}


		//  EMSPatientContact
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper EMSPatientContact
		{
			get
			{
				return cEMSPatientContact;
			}
			set
			{
				cEMSPatientContact = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public ADORecordSetHelper IncidentEMSPatients
		{
			get
			{
				return cIncidentEMSPatients;
			}
			set
			{
				cIncidentEMSPatients = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int PatientID
		{
			get
			{
				return CPatientID;
			}
			set
			{
				CPatientID = value;
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


		public int ActionTaken
		{
			get
			{
				return cActionTaken;
			}
			set
			{
				cActionTaken = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int IncidentType
		{
			get
			{
				return cIncidentType;
			}
			set
			{
				cIncidentType = value;
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


		public int Age
		{
			get
			{
				return cAge;
			}
			set
			{
				cAge = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int AgeUnit
		{
			get
			{
				return cAgeUnit;
			}
			set
			{
				cAgeUnit = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int Race
		{
			get
			{
				return cRace;
			}
			set
			{
				cRace = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int Ethnicity
		{
			get
			{
				return cEthnicity;
			}
			set
			{
				cEthnicity = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int IncidentLocation
		{
			get
			{
				return cIncidentLocation;
			}
			set
			{
				cIncidentLocation = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string IncidentZipcode
		{
			get
			{
				return cIncidentZipcode;
			}
			set
			{
				cIncidentZipcode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int IncidentSetting
		{
			get
			{
				return cIncidentSetting;
			}
			set
			{
				cIncidentSetting = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int Severity
		{
			get
			{
				return cSeverity;
			}
			set
			{
				cSeverity = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string DispatchedAlsBls
		{
			get
			{
				return cDispatchedAlsBls;
			}
			set
			{
				cDispatchedAlsBls = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string LevelOfCareAlsBls
		{
			get
			{
				return cLevelOfCareAlsBls;
			}
			set
			{
				cLevelOfCareAlsBls = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int TreatmentAuthorization
		{
			get
			{
				return cTreatmentAuthorization;
			}
			set
			{
				cTreatmentAuthorization = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ServiceProvided
		{
			get
			{
				return cServiceProvided;
			}
			set
			{
				cServiceProvided = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ResearchCode
		{
			get
			{
				return cResearchCode;
			}
			set
			{
				cResearchCode = value;
			}
		}


		//  EMSPatientExam
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper EMCPatientExam
		{
			get
			{
				return cEMCPatientExam;
			}
			set
			{
				cEMCPatientExam = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ExamPatientID
		{
			get
			{
				return cExamPatientID;
			}
			set
			{
				cExamPatientID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int MechCode
		{
			get
			{
				return cMechCode;
			}
			set
			{
				cMechCode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int InjuryType
		{
			get
			{
				return cInjuryType;
			}
			set
			{
				cInjuryType = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int PrimaryIllness
		{
			get
			{
				return cPrimaryIllness;
			}
			set
			{
				cPrimaryIllness = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int Pupils
		{
			get
			{
				return cPupils;
			}
			set
			{
				cPupils = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int LevelOfConsciousness
		{
			get
			{
				return cLevelOfConsciousness;
			}
			set
			{
				cLevelOfConsciousness = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int RespiratoryEffort
		{
			get
			{
				return cRespiratoryEffort;
			}
			set
			{
				cRespiratoryEffort = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte FlagExtricationRequired
		{
			get
			{
				return (byte) cFlagExtricationRequired;
			}
			set
			{
				cFlagExtricationRequired = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ExtricationTime
		{
			get
			{
				return cExtricationTime;
			}
			set
			{
				cExtricationTime = value;
			}
		}


		//  EMSPatientIVLine
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper EMSPatientIVLine
		{
			get
			{
				return cEMSPatientIVLine;
			}
			set
			{
				cEMSPatientIVLine = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int LineID
		{
			get
			{
				return cLineID;
			}
			set
			{
				cLineID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int IVPatientID
		{
			get
			{
				return CivPatientID;
			}
			set
			{
				CivPatientID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int IVGauge
		{
			get
			{
				return cIVGauge;
			}
			set
			{
				cIVGauge = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int IVRoute
		{
			get
			{
				return cIVRoute;
			}
			set
			{
				cIVRoute = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int IVRate
		{
			get
			{
				return cIVRate;
			}
			set
			{
				cIVRate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int IVSite
		{
			get
			{
				return cIVSite;
			}
			set
			{
				cIVSite = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int IVAmount
		{
			get
			{
				return cIVAmount;
			}
			set
			{
				cIVAmount = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte FlagSalineLock
		{
			get
			{
				return cFlagSalineLock;
			}
			set
			{
				cFlagSalineLock = value;
			}
		}


		//EMSPatientNarration
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper EMSPatientNarration
		{
			get
			{
				return cEMSPatientNarration;
			}
			set
			{
				cEMSPatientNarration = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int EMSNarrationID
		{
			get
			{
				return cEMSNarrationID;
			}
			set
			{
				cEMSNarrationID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int NarrPatientID
		{
			get
			{
				return cNarrPatientID;
			}
			set
			{
				cNarrPatientID = value;
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


		public string NarrationDate
		{
			get
			{
				return cNarrationDate;
			}
			set
			{
				cNarrationDate = value;
			}
		}



		//  EMSPatientTransport
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper EMSPatientTransport
		{
			get
			{
				return cEMSPatientTransport;
			}
			set
			{
				cEMSPatientTransport = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int TransPatientID
		{
			get
			{
				return cTransPatientID;
			}
			set
			{
				cTransPatientID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int HospitalChosenBy
		{
			get
			{
				return cHospitalChosenBy;
			}
			set
			{
				cHospitalChosenBy = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte FlagDiverted
		{
			get
			{
				return (byte) cFlagDiverted;
			}
			set
			{
				//UPGRADE_WARNING: (6021) Casting 'byte' to Enum may cause different behaviour. More Information: http://www.vbtonet.com/ewis/ewi6021.aspx
				cFlagDiverted = (UpgradeHelpers.Helpers.CheckState) value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int BaseStation
		{
			get
			{
				return cBaseStation;
			}
			set
			{
				cBaseStation = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int HospitalStaffType
		{
			get
			{
				return cHospitalStaffType;
			}
			set
			{
				cHospitalStaffType = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public float Mileage
		{
			get
			{
				return cMileage;
			}
			set
			{
				cMileage = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int TransportedTo
		{
			get
			{
				return cTransportedTo;
			}
			set
			{
				cTransportedTo = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int TransportedFrom
		{
			get
			{
				return cTransportedFrom;
			}
			set
			{
				cTransportedFrom = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string TransportBy
		{
			get
			{
				return cTransportBy;
			}
			set
			{
				cTransportBy = value;
			}
		}


		//  EMSPatientTrauma
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper EMSPatientTrauma
		{
			get
			{
				return cEMSPatientTrauma;
			}
			set
			{
				cEMSPatientTrauma = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int TraumaPatientID
		{
			get
			{
				return cTraumaPatientID;
			}
			set
			{
				cTraumaPatientID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string TraumaID
		{
			get
			{
				return cTraumaID;
			}
			set
			{
				cTraumaID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ProtectiveDevice
		{
			get
			{
				return cProtectiveDevice;
			}
			set
			{
				cProtectiveDevice = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int TraumaLocation
		{
			get
			{
				return cTraumaLocation;
			}
			set
			{
				cTraumaLocation = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int RevisedTraumaScore
		{
			get
			{
				return cRevisedTraumaScore;
			}
			set
			{
				cRevisedTraumaScore = value;
			}
		}


		// EMSPatientVitals
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper EMSPatientVitals
		{
			get
			{
				return cEMSPatientVitals;
			}
			set
			{
				cEMSPatientVitals = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int VitalsID
		{
			get
			{
				return cVitalsID;
			}
			set
			{
				cVitalsID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int VitalPatientID
		{
			get
			{
				return cVitalPatientID;
			}
			set
			{
				cVitalPatientID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string VitalsTime
		{
			get
			{
				return cVitalsTime;
			}
			set
			{
				cVitalsTime = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int GCSEyes
		{
			get
			{
				return cGCSEyes;
			}
			set
			{
				cGCSEyes = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int GCSVerbal
		{
			get
			{
				return cGCSVerbal;
			}
			set
			{
				cGCSVerbal = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int GCSMotor
		{
			get
			{
				return cGCSMotor;
			}
			set
			{
				cGCSMotor = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int Systolic
		{
			get
			{
				return cSystolic;
			}
			set
			{
				cSystolic = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int Diastolic
		{
			get
			{
				return cDiastolic;
			}
			set
			{
				cDiastolic = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte FlagDiastolicPalp
		{
			get
			{
				return cFlagDiastolicPalp;
			}
			set
			{
				cFlagDiastolicPalp = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int Pulse
		{
			get
			{
				return cPulse;
			}
			set
			{
				cPulse = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int RespirationRate
		{
			get
			{
				return cRespirationRate;
			}
			set
			{
				cRespirationRate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int VitalsPosition
		{
			get
			{
				return cVitalsPosition;
			}
			set
			{
				cVitalsPosition = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int BloodGlucose
		{
			get
			{
				return cBloodGlucose;
			}
			set
			{
				cBloodGlucose = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int PulseOxygen
		{
			get
			{
				return cPulseOxygen;
			}
			set
			{
				cPulseOxygen = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int PercentOxygen
		{
			get
			{
				return cPercentOxygen;
			}
			set
			{
				cPercentOxygen = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]



		public int ECG
		{
			get
			{
				return cECG;
			}
			set
			{
				cECG = value;
			}
		}


		//  EMSPreExisingCondition
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper EMSPreExistingCondition
		{
			get
			{
				return cEMSPreExistingCondition;
			}
			set
			{
				cEMSPreExistingCondition = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int PreExistPatientID
		{
			get
			{
				return cPreExistPatientID;
			}
			set
			{
				cPreExistPatientID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int PreExistingCondition
		{
			get
			{
				return cPreExistingConditionCode;
			}
			set
			{
				cPreExistingConditionCode = value;
			}
		}


		//  EMSProcedure
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]

		public ADORecordSetHelper EMSProcedure
		{
			get
			{
				return cEMSProcedure;
			}
			set
			{
				cEMSProcedure = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ProcedurePatientID
		{
			get
			{
				return cProcedurePatientID;
			}
			set
			{
				cProcedurePatientID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int Procedure
		{
			get
			{
				return cProcedure;
			}
			set
			{
				cProcedure = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PerformedBy
		{
			get
			{
				return cPerformedBy;
			}
			set
			{
				cPerformedBy = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int Attempts
		{
			get
			{
				return cAttempts;
			}
			set
			{
				cAttempts = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte FlagSuccessful
		{
			get
			{
				return cFlagSuccessful;
			}
			set
			{
				cFlagSuccessful = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string OtherProcedureDescription
		{
			get
			{
				return cOtherProcedureDescription;
			}
			set
			{
				cOtherProcedureDescription = value;
			}
		}


		//  EMSSecondaryIllness
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper EMSSecondaryIllness
		{
			get
			{
				return cEMSSecondaryIllness;
			}
			set
			{
				cEMSSecondaryIllness = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int SecIllPatientID
		{
			get
			{
				return cSecIllPatientID;
			}
			set
			{
				cSecIllPatientID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int SecondaryIllnessCode
		{
			get
			{
				return cSecondaryIllnessCode;
			}
			set
			{
				cSecondaryIllnessCode = value;
			}
		}



		//  EMSTraumaDescriptor
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper EMSTraumaDescriptor
		{
			get
			{
				return cEMSTraumaDescriptor;
			}
			set
			{
				cEMSTraumaDescriptor = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int TraumaDescrPatientID
		{
			get
			{
				return cTraumaDescrPatientID;
			}
			set
			{
				cTraumaDescrPatientID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int TraumaType
		{
			get
			{
				return cTraumaType;
			}
			set
			{
				cTraumaType = value;
			}
		}


		//  FDCaresReferral
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper FDCaresReferral
		{
			get
			{
				return cFDCaresReferral;
			}
			set
			{
				cFDCaresReferral = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ReferralID
		{
			get
			{
				return cReferralID;
			}
			set
			{
				cReferralID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ReferralIncidentID
		{
			get
			{
				return cReferralIncidentID;
			}
			set
			{
				cReferralIncidentID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string ReferredBy
		{
			get
			{
				return cReferredBy;
			}
			set
			{
				cReferredBy = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ReferralPatientID
		{
			get
			{
				return cReferralPatientID;
			}
			set
			{
				cReferralPatientID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string ReferralComment
		{
			get
			{
				return cReferralComment;
			}
			set
			{
				cReferralComment = value;
			}
		}

		//**********************************************

		//**         Public Class Methods             **
		//**********************************************
		//EMS Incident Patient Listing
		//   (All EMS Patients for specified Incident

		public int GetIncidentEMSPatients(int lIncidentID)
		{
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_IncidentEMSPatients " + lIncidentID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cIncidentEMSPatients = orec;
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
		//  EMSPatientContact

		public int GetEMSPatientContact(int lPatientID)
		{
			//Retrieve EMSPatientContact record and Load date into
			//EMSPatientContact class variables
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSPatientContact " + lPatientID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					//Load Class  Variables
					CPatientID = Convert.ToInt32(orec["patient_id"]);
					cIncidentID = Convert.ToInt32(orec["incident_id"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cActionTaken = Convert.ToInt32(IncidentMain.GetVal(orec["action_taken_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cIncidentType = Convert.ToInt32(IncidentMain.GetVal(orec["incident_type_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cGender = Convert.ToInt32(IncidentMain.GetVal(orec["gender"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cAge = Convert.ToInt32(IncidentMain.GetVal(orec["age"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cAgeUnit = Convert.ToInt32(IncidentMain.GetVal(orec["age_unit_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cRace = Convert.ToInt32(IncidentMain.GetVal(orec["race"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cEthnicity = Convert.ToInt32(IncidentMain.GetVal(orec["ethnicity"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cIncidentLocation = Convert.ToInt32(IncidentMain.GetVal(orec["incident_location_code"]));
					cIncidentZipcode = IncidentMain.Clean(orec["incident_zipcode"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cIncidentSetting = Convert.ToInt32(IncidentMain.GetVal(orec["incident_setting_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cSeverity = Convert.ToInt32(IncidentMain.GetVal(orec["severity_code"]));
					cDispatchedAlsBls = IncidentMain.Clean(orec["dispatched_als_bls"]);
					cLevelOfCareAlsBls = IncidentMain.Clean(orec["level_of_care_als_bls"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cTreatmentAuthorization = Convert.ToInt32(IncidentMain.GetVal(orec["treatment_authorization"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cServiceProvided = Convert.ToInt32(IncidentMain.GetVal(orec["service_provided_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cResearchCode = Convert.ToInt32(IncidentMain.GetVal(orec["research_code"]));
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

		public int AddEMSPatientContact()
		{
			//Add New EMSPatientContact Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;
			string SqlString = "";

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spInsert_EMSPatientContact " + cIncidentID.ToString() + ",";
				if (cActionTaken == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cActionTaken.ToString() + ",";
				}
				if (cIncidentType == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cIncidentType.ToString() + ",";
				}
				if (cGender == 0)
				{
					SqlString = SqlString + "NULL," + cAge.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cGender.ToString() + "," + cAge.ToString() + ",";
				}
				if (cAgeUnit == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cAgeUnit.ToString() + ",";
				}
				if (cRace == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cRace.ToString() + ",";
				}
				if (cEthnicity == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cEthnicity.ToString() + ",";
				}
				if (cIncidentLocation == 0)
				{
					SqlString = SqlString + "NULL,'" + cIncidentZipcode + "',";
				}
				else
				{
					SqlString = SqlString + cIncidentLocation.ToString() + ",'" + cIncidentZipcode + "',";
				}
				if (cIncidentSetting == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cIncidentSetting.ToString() + ",";
				}
				if (cSeverity == 0)
				{
					SqlString = SqlString + "NULL,'" + cDispatchedAlsBls + "','" + cLevelOfCareAlsBls + "',";
				}
				else
				{
					SqlString = SqlString + cSeverity.ToString() + ",'" + cDispatchedAlsBls + "','" + cLevelOfCareAlsBls + "',";
				}
				if (cTreatmentAuthorization == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cTreatmentAuthorization.ToString() + ",";
				}
				if (cServiceProvided == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cServiceProvided.ToString() + ",";
				}
				if (cResearchCode == 0)
				{
					SqlString = SqlString + "NULL";
				}
				else
				{
					SqlString = SqlString + cResearchCode.ToString();
				}
				ocmd.CommandText = SqlString;
				ocmd.ExecuteNonQuery();
				ocmd.CommandText = "spSelect_NewEMSPatientContact";
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					if (~GetEMSPatientContact(Convert.ToInt32(orec[0])) != 0)
					{
						result = 0;
					}
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

		public int UpdateEMSPatientContact()
		{
			//Update EMSPatientContact Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spUpdate_EMSPatientContact " + CPatientID.ToString() + "," + cIncidentID.ToString() + ",";
				if (cActionTaken == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cActionTaken.ToString() + ",";
				}
				if (cIncidentType == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cIncidentType.ToString() + ",";
				}
				if (cGender == 0)
				{
					SqlString = SqlString + "NULL," + cAge.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cGender.ToString() + "," + cAge.ToString() + ",";
				}
				if (cAgeUnit == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cAgeUnit.ToString() + ",";
				}
				if (cRace == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cRace.ToString() + ",";
				}
				if (cEthnicity == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cEthnicity.ToString() + ",";
				}
				if (cIncidentLocation == 0)
				{
					SqlString = SqlString + "NULL,'" + cIncidentZipcode + "',";
				}
				else
				{
					SqlString = SqlString + cIncidentLocation.ToString() + ",'" + cIncidentZipcode + "',";
				}
				if (cIncidentSetting == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cIncidentSetting.ToString() + ",";
				}
				if (cSeverity == 0)
				{
					SqlString = SqlString + "NULL,'" + cDispatchedAlsBls + "','" + cLevelOfCareAlsBls + "',";
				}
				else
				{
					SqlString = SqlString + cSeverity.ToString() + ",'" + cDispatchedAlsBls + "','" + cLevelOfCareAlsBls + "',";
				}
				if (cTreatmentAuthorization == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cTreatmentAuthorization.ToString() + ",";
				}
				if (cServiceProvided == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cServiceProvided.ToString() + ",";
				}
				if (cResearchCode == 0)
				{
					SqlString = SqlString + "NULL";
				}
				else
				{
					SqlString = SqlString + cResearchCode.ToString();
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

		public int DeleteEMSPatientContact(ref int lPatientID)
		{
			//Deletes All Child records and EMSPatientContact Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spDelete_EMSPatientContact";
				ocmd.ExecuteNonQuery(new object[] { lPatientID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteEMSPatientContactSubReports(ref int lPatientID)
		{
			//Deletes All Child records and EMSPatientContact Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spDelete_EMSPatientContactSubs";
				ocmd.ExecuteNonQuery(new object[] { lPatientID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteEMSPatientTransport(ref int lPatientID)
		{
			//Deletes  EMSPatientTransport Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spDelete_EMSPatientTransport";
				ocmd.ExecuteNonQuery(new object[] { lPatientID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteEMSPatientIVLine(ref int lPatientID)
		{
			//Deletes  EMSPatientIVLine Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spDelete_EMSPatientIVLine";
				ocmd.ExecuteNonQuery(new object[] { lPatientID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteEMSPatientNarration(ref int lPatientID)
		{
			//Deletes  EMSPatientNarration Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spDelete_EMSPatientNarration";
				ocmd.ExecuteNonQuery(new object[] { lPatientID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteEMSPatientTrauma(ref int lPatientID)
		{
			//Deletes  EMSPatientTrauma Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spDelete_EMSPatientTrauma";
				ocmd.ExecuteNonQuery(new object[] { lPatientID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteEMSPatientVitals(ref int lPatientID)
		{
			//Deletes  EMSPatientVitals Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spDelete_EMSPatientVitals";
				ocmd.ExecuteNonQuery(new object[] { lPatientID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteEMSCPR(ref int lPatientID)
		{
			//Deletes  EMSCPR Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spDelete_EMSCPR";
				ocmd.ExecuteNonQuery(new object[] { lPatientID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteEMSPatient(ref int lPatientID)
		{
			//Deletes  EMSPatient Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spDelete_EMSPatient";
				ocmd.ExecuteNonQuery(new object[] { lPatientID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteEMSPatientExam(ref int lPatientID)
		{
			//Deletes  EMSPatientExam Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spDelete_EMSPatientExam";
				ocmd.ExecuteNonQuery(new object[] { lPatientID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int GetEMSIncidentStaffing(int lIncidentID)
		{
			//Retrieve All Staff for Incident
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSIncidentStaffing " + lIncidentID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cEMSIncidentStaffing = orec;
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

		public int GetEMSALSStaffing(int lIncidentID)
		{
			//Retrieve All ALS Staff for Incident
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSALSStaffing " + lIncidentID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cEMSIncidentStaffing = orec;
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

		//  EMSPatient

		public int GetEMSPatient(int lPatientID)
		{
			//Retrieve EMSPatient record and Load date into
			//EMSPatient class variables
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSPatient " + lPatientID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					//Load Class  Variables
					cEMSPatientID = Convert.ToInt32(orec["patient_id"]);
					cBirthdate = IncidentMain.Clean(orec["birthdate"]);
					cNameLast = IncidentMain.Clean(orec["name_last"]);
					cNameFirst = IncidentMain.Clean(orec["name_first"]);
					cNameMI = IncidentMain.Clean(orec["name_mi"]);
					cSocialSecurityNumber = IncidentMain.Clean(orec["social_security_number"]);
					cBillingAddress = IncidentMain.Clean(orec["billing_address"]);
					cCity = IncidentMain.Clean(orec["city"]);
					cState = IncidentMain.Clean(orec["state_code"]);
					cZipcode = IncidentMain.Clean(orec["zipcode"]);
					cPhone = IncidentMain.Clean(orec["phone"]);
					if (Convert.ToBoolean(orec["flag_dnro"]))
					{
						cFlagDNRO = UpgradeHelpers.Helpers.CheckState.Checked;
					}
					else
					{
						cFlagDNRO = UpgradeHelpers.Helpers.CheckState.Unchecked;
					}
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

		public int AddEMSPatient()
		{
			//Add New EMSPatient Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spInsert_EMSPatient " + cEMSPatientID.ToString() + ",";
				if (cBirthdate == "")
				{
					SqlString = SqlString + "NULL,'";
				}
				else
				{
					SqlString = SqlString + "'" + cBirthdate + "','";
				}
				SqlString = SqlString + Strings.Replace(cNameLast, "'", "''", 1, -1, CompareMethod.Binary) + "','" + Strings.Replace(cNameFirst, "'", "''", 1, -1, CompareMethod.Binary) + "','" + cNameMI + "','";
				SqlString = SqlString + cSocialSecurityNumber + "','" + Strings.Replace(cBillingAddress, "'", "''", 1, -1, CompareMethod.Binary) + "','" + Strings.Replace(cCity, "'", "''", 1, -1, CompareMethod.Binary) + "','";
				SqlString = SqlString + cState + "','" + cZipcode + "','" + cPhone + "'," + ((int) cFlagDNRO).ToString();
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

		public int UpdateEMSPatient()
		{
			//Update EMSPatient Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spUpdate_EMSPatient " + cEMSPatientID.ToString() + ",";
				if (cBirthdate == "")
				{
					SqlString = SqlString + "NULL,'";
				}
				else
				{
					SqlString = SqlString + "'" + cBirthdate + "','";
				}
				SqlString = SqlString + Strings.Replace(cNameLast, "'", "''", 1, -1, CompareMethod.Binary) + "','" + Strings.Replace(cNameFirst, "'", "''", 1, -1, CompareMethod.Binary) + "','" + cNameMI + "','";
				SqlString = SqlString + cSocialSecurityNumber + "','" + Strings.Replace(cBillingAddress, "'", "''", 1, -1, CompareMethod.Binary) + "','" + Strings.Replace(cCity, "'", "''", 1, -1, CompareMethod.Binary) + "','";
				SqlString = SqlString + cState + "','" + cZipcode + "','" + cPhone + "'," + ((int) cFlagDNRO).ToString();
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

		//  EMSPatientExam

		public int GetEMSPatientExam(int lPatientID)
		{
			//Retrieve EMSPatientExam record and Load date into
			//EMSPatientExam class variables
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSPatientExam " + lPatientID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					//Load Class  Variables
					cExamPatientID = Convert.ToInt32(orec["patient_id"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cMechCode = Convert.ToInt32(IncidentMain.GetVal(orec["mech_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cInjuryType = Convert.ToInt32(IncidentMain.GetVal(orec["injury_type_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cPrimaryIllness = Convert.ToInt32(IncidentMain.GetVal(orec["primary_illness_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cPupils = Convert.ToInt32(IncidentMain.GetVal(orec["pupils_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cLevelOfConsciousness = Convert.ToInt32(IncidentMain.GetVal(orec["level_of_consciousness_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cRespiratoryEffort = Convert.ToInt32(IncidentMain.GetVal(orec["respiratory_effort_code"]));
					if (Convert.ToBoolean(orec["flag_extrication_required"]))
					{
						cFlagExtricationRequired = 1;
					}
					else
					{
						cFlagExtricationRequired = 0;
					}
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cExtricationTime = Convert.ToInt32(IncidentMain.GetVal(orec["extrication_time"]));
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

		public int AddEMSPatientExam()
		{
			//Add New EMSPatientExam Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spInsert_EMSPatientExam " + cExamPatientID.ToString() + ",";
				if (cMechCode == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cMechCode.ToString() + ",";
				}
				if (cInjuryType == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cInjuryType.ToString() + ",";
				}
				if (cPrimaryIllness == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cPrimaryIllness.ToString() + ",";
				}
				if (cPupils == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cPupils.ToString() + ",";
				}
				if (cLevelOfConsciousness == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cLevelOfConsciousness.ToString() + ",";
				}
				if (cRespiratoryEffort == 0)
				{
					SqlString = SqlString + "NULL," + cFlagExtricationRequired.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cRespiratoryEffort.ToString() + "," + cFlagExtricationRequired.ToString() + ",";
				}
				SqlString = SqlString + cExtricationTime.ToString();
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

		public int UpdateEMSPatientExam()
		{
			//Update EMSPatientExam Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spUpdate_EMSPatientExam " + cExamPatientID.ToString() + ",";
				if (cMechCode == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cMechCode.ToString() + ",";
				}
				if (cInjuryType == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cInjuryType.ToString() + ",";
				}
				if (cPrimaryIllness == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cPrimaryIllness.ToString() + ",";
				}
				if (cPupils == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cPupils.ToString() + ",";
				}
				if (cLevelOfConsciousness == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cLevelOfConsciousness.ToString() + ",";
				}
				if (cRespiratoryEffort == 0)
				{
					SqlString = SqlString + "NULL," + cFlagExtricationRequired.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cRespiratoryEffort.ToString() + "," + cFlagExtricationRequired.ToString() + ",";
				}
				SqlString = SqlString + cExtricationTime.ToString();
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

		//EMSPatientNarration

		public int UpdateEMSPatientNarration()
		{
			//Update EMSPatientNarration Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spUpdate_EMSPatientNarration";
				ocmd.ExecuteNonQuery(new object[] { cEMSNarrationID, cNarrPatientID, Strings.Replace(cNarrationText, "'", "''", 1, -1, CompareMethod.Binary), cNarrationBy, cNarrationDate });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int AddEMSPatientNarration()
		{
			//Add new EMSPatientNarration Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spInsert_EMSPatientNarration";
				ocmd.ExecuteNonQuery(new object[] { cNarrPatientID, Strings.Replace(cNarrationText, "'", "''", 1, -1, CompareMethod.Binary), cNarrationBy, cNarrationDate });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int GetEMSPatientNarrationRS(int lPatientID)
		{
			//Retrieve All Patient Narrations recordset
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSPatientNarrationAll " + lPatientID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					cEMSPatientNarration = orec;
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

		public int GetEMSPatientNarration(int lNarrationID)
		{
			//Retrieve EMSPatientNarration record and Load data into
			//EMSPatientNarration class variables
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSPatientNarration " + lNarrationID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					//Load Class  Variables
					cEMSNarrationID = Convert.ToInt32(orec["ems_narration_id"]);
					cNarrPatientID = Convert.ToInt32(orec["patient_id"]);
					cNarrationText = IncidentMain.Clean(orec["narration_text"]);
					cNarrationBy = IncidentMain.Clean(orec["narration_by"]);
					System.DateTime TempDate = DateTime.FromOADate(0);
					cNarrationDate = (DateTime.TryParse(IncidentMain.Clean(orec["last_update"]), out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : IncidentMain.Clean(orec["last_update"]);
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


		//  EMSPatientTransport

		public int GetEMSPatientTransport(int lPatientID)
		{
			//Retrieve EMSPatientTransport record and Load date into
			//EMSPatientTransport class variables
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSPatientTransport " + lPatientID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					//Load Class  Variables
					cTransPatientID = Convert.ToInt32(orec["patient_id"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cHospitalChosenBy = Convert.ToInt32(IncidentMain.GetVal(orec["hospital_chosen_by_code"]));
					if (Convert.ToBoolean(orec["flag_diverted"]))
					{
						cFlagDiverted = UpgradeHelpers.Helpers.CheckState.Checked;
					}
					else
					{
						cFlagDiverted = UpgradeHelpers.Helpers.CheckState.Unchecked;
					}
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cBaseStation = Convert.ToInt32(IncidentMain.GetVal(orec["base_station"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cHospitalStaffType = Convert.ToInt32(IncidentMain.GetVal(orec["hospital_staff_type_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to float. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cMileage = Convert.ToSingle(IncidentMain.GetVal(orec["mileage"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cTransportedTo = Convert.ToInt32(IncidentMain.GetVal(orec["transported_to"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cTransportedFrom = Convert.ToInt32(IncidentMain.GetVal(orec["transported_from"]));
					cTransportBy = IncidentMain.Clean(orec["transport_by"]);
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

		public int GetEMSPatientTransportReport(object lPatientID)
		{
			//Retrieve EMS Patient Exam Recordset
			//Formatted for Reporting
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				//UPGRADE_WARNING: (1068) lPatientID of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ocmd.CommandText = "spReport_EMSPatientTransport " + Convert.ToString(lPatientID);
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cEMSPatientTransport = orec;
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

		public int AddEMSPatientTransport()
		{
			//Add New EMSPatientTransport Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spInsert_EMSPatientTransport " + cTransPatientID.ToString() + ",";
				if (cHospitalChosenBy == 0)
				{
					SqlString = SqlString + "NULL," + ((int) cFlagDiverted).ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cHospitalChosenBy.ToString() + "," + ((int) cFlagDiverted).ToString() + ",";
				}
				if (cBaseStation == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cBaseStation.ToString() + ",";
				}
				if (cHospitalStaffType == 0)
				{
					SqlString = SqlString + "NULL," + cMileage.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cHospitalStaffType.ToString() + "," + cMileage.ToString() + ",";
				}
				if (cTransportedTo == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cTransportedTo.ToString() + ",";
				}
				if (cTransportedFrom == 0)
				{
					SqlString = SqlString + "NULL,'" + cTransportBy + "'";
				}
				else
				{
					SqlString = SqlString + cTransportedFrom.ToString() + ",'" + cTransportBy + "'";
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

		public int UpdateEMSPatientTransport()
		{
			//Update EMSPatientTransport Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spUpdate_EMSPatientTransport " + cTransPatientID.ToString() + ",";
				if (cHospitalChosenBy == 0)
				{
					SqlString = SqlString + "NULL," + ((int) cFlagDiverted).ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cHospitalChosenBy.ToString() + "," + ((int) cFlagDiverted).ToString() + ",";
				}
				if (cBaseStation == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cBaseStation.ToString() + ",";
				}
				if (cHospitalStaffType == 0)
				{
					SqlString = SqlString + "NULL," + cMileage.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cHospitalStaffType.ToString() + "," + cMileage.ToString() + ",";
				}
				if (cTransportedTo == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cTransportedTo.ToString() + ",";
				}
				if (cTransportedFrom == 0)
				{
					SqlString = SqlString + "NULL,'" + cTransportBy + "'";
				}
				else
				{
					SqlString = SqlString + cTransportedFrom.ToString() + ",'" + cTransportBy + "'";
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

		//  EMSPatientTrauma

		public int GetEMSPatientTrauma(int lPatientID)
		{
			//Retrieve EMSPatientTrauma record and Load date into
			//EMSPatientTrauma class variables
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSPatientTrauma " + lPatientID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					//Load Class  Variables
					cTraumaPatientID = Convert.ToInt32(orec["patient_id"]);
					cTraumaID = IncidentMain.Clean(orec["trauma_id"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cProtectiveDevice = Convert.ToInt32(IncidentMain.GetVal(orec["protective_device_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cTraumaLocation = Convert.ToInt32(IncidentMain.GetVal(orec["trauma_location_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cRevisedTraumaScore = Convert.ToInt32(IncidentMain.GetVal(orec["revised_trauma_score"]));
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

		public int AddEMSPatientTrauma()
		{
			//Add New EMSPatientTrauma Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spInsert_EMSPatientTrauma " + cTraumaPatientID.ToString() + ",'" + cTraumaID + "',";
				if (cProtectiveDevice == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cProtectiveDevice.ToString() + ",";
				}
				if (cTraumaLocation == 0)
				{
					SqlString = SqlString + "NULL," + cRevisedTraumaScore.ToString();
				}
				else
				{
					SqlString = SqlString + cTraumaLocation.ToString() + "," + cRevisedTraumaScore.ToString();
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

		public int UpdateEMSPatientTrauma()
		{
			//Update EMSPatientTrauma Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spUpdate_EMSPatientTrauma " + cTraumaPatientID.ToString() + ",'" + cTraumaID + "',";
				if (cProtectiveDevice == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cProtectiveDevice.ToString() + ",";
				}
				if (cTraumaLocation == 0)
				{
					SqlString = SqlString + "NULL," + cRevisedTraumaScore.ToString();
				}
				else
				{
					SqlString = SqlString + cTraumaLocation.ToString() + "," + cRevisedTraumaScore.ToString();
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

		//EMS Medication

		public int GetEMSMedicationRS(int lPatientID)
		{
			//Retrieve EMSMedication recordset
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSMedicationAll " + lPatientID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					cEMSMedication = orec;
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

		public int GetEMSMedication(int lPatientID, int iMedCode)
		{
			//Retrieve EMSMedication recordset
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSMedication " + lPatientID.ToString() + "," + iMedCode.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					cEMSMedication = orec;
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

		public int AddEMSMedication()
		{
			//Add new EMSMedication Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spInsert_EMSMedication";
				ocmd.ExecuteNonQuery(new object[] { cMedPatientID, cMedication, cAdministeredDosage });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public bool UpdateEMSMedication()
		{
			//Add new EMSMedication Record
			bool result = false;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = true;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spUpdate_EMSMedication";
				ocmd.ExecuteNonQuery(new object[] { cMedPatientID, cMedication, cAdministeredDosage });
			}
			catch
			{

				result = false;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteEMSMedicationAll(ref int lPatientID)
		{
			//Delete all EMSMedication Records for specified Patient ID
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spDelete_EMSMedicationAll";
				ocmd.ExecuteNonQuery(new object[] { lPatientID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteEMSMedication(ref int lPatientID, ref int iMedCode)
		{
			//Delete specific EMSMedication Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spDelete_EMSMedication";
				ocmd.ExecuteNonQuery(new object[] { lPatientID, iMedCode });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int GetEMSPreExistingConditionRS(int lPatientID)
		{
			//Retrieve EMSPreExistingConditionRS recordset
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSPreExistingCondition " + lPatientID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					cEMSPreExistingCondition = orec;
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

		public int AddEMSPreExistingCondition()
		{
			//Add new EMSPreExistingCondition Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spInsert_EMSPreExistingCondition";
				ocmd.ExecuteNonQuery(new object[] { cPreExistPatientID, cPreExistingConditionCode });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteEMSPreExistingCondition(ref int lPatientID)
		{
			//Delete all EMSMedication Records for specified Patient ID
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spDelete_EMSPreExistingCondition";
				ocmd.ExecuteNonQuery(new object[] { lPatientID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int GetEMSSecondaryIllnessRS(int lPatientID)
		{
			//Retrieve EMSSecondaryIllnessRS recordset
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSSecondaryIllness " + lPatientID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					cEMSSecondaryIllness = orec;
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

		public int AddEMSSecondaryIllness()
		{
			//Add new EMSSecondaryIllness Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spInsert_EMSSecondaryIllness";
				ocmd.ExecuteNonQuery(new object[] { cSecIllPatientID, cSecondaryIllnessCode });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteEMSSecondaryIllness(ref int lPatientID)
		{
			//Delete all EMSSecondaryIllness Records for specified Patient ID
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spDelete_EMSSecondaryIllness";
				ocmd.ExecuteNonQuery(new object[] { lPatientID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		//EMSContributingFactor

		public int GetEMSContributingFactorRS(int lPatientID)
		{
			//Retrieve EMSContributingFactorRS recordset
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSContributingFactor " + lPatientID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					cEMSContributingFactor = orec;
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

		public int AddEMSContributingFactor()
		{
			//Add new EMSContributingFactor Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spInsert_EMSContributingFactor";
				ocmd.ExecuteNonQuery(new object[] { cCFPatientID, cEMSContributingFactorCode });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteEMSContributingFactor(ref int lPatientID)
		{
			//Delete all EMSContributingFactor Records for specified Patient ID
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spDelete_EMSContributingFactor";
				ocmd.ExecuteNonQuery(new object[] { lPatientID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int GetEMSTraumaDescriptorRS(int lPatientID)
		{
			//Retrieve EMSTraumaDescriptorRS recordset
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSTraumaDescriptor " + lPatientID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					cEMSTraumaDescriptor = orec;
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

		public int AddEMSTraumaDescriptor()
		{
			//Add new EMSTraumaDescriptor Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spInsert_EMSTraumaDescriptor";
				ocmd.ExecuteNonQuery(new object[] { cTraumaDescrPatientID, cTraumaType });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteEMSTraumaDescriptor(ref int lPatientID)
		{
			//Delete all EMSTraumaDescriptor Records for specified Patient ID
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spDelete_EMSTraumaDescriptor";
				ocmd.ExecuteNonQuery(new object[] { lPatientID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		//EMSCPR

		public int GetEMSCPR(int lPatientID)
		{
			//Retrieve EMSCPR record and Load date into
			//EMSCPR class variables
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSCPR " + lPatientID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					//Load Class  Variables
					cCPRPatientID = Convert.ToInt32(orec["patient_id"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cTimeArrestToCPR = Convert.ToInt32(IncidentMain.GetVal(orec["time_arrest_to_cpr"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cTimeArrestToAls = Convert.ToInt32(IncidentMain.GetVal(orec["time_arrest_to_als"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cTimeArrestToShock = Convert.ToInt32(IncidentMain.GetVal(orec["time_arrest_to_shock"]));
					if (Convert.ToBoolean(orec["flag_pulse_restored"]))
					{
						cFlagPulseRestored = 1;
					}
					else
					{
						cFlagPulseRestored = 0;
					}
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

		public int AddEMSCPR()
		{
			//Add new EMSCPR Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spInsert_EMSCPR " + cCPRPatientID.ToString() + ",";
				if (cTimeArrestToCPR == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cTimeArrestToCPR.ToString() + ",";
				}
				if (cTimeArrestToAls == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cTimeArrestToAls.ToString() + ",";
				}
				if (cTimeArrestToShock == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cTimeArrestToShock.ToString() + ",";
				}
				SqlString = SqlString + cFlagPulseRestored.ToString();
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

		public int UpdateEMSCPR()
		{
			//Update EMSCPR Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spUpdate_EMSCPR " + cCPRPatientID.ToString() + ",";
				if (cTimeArrestToCPR == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cTimeArrestToCPR.ToString() + ",";
				}
				if (cTimeArrestToAls == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cTimeArrestToAls.ToString() + ",";
				}
				if (cTimeArrestToShock == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cTimeArrestToShock.ToString() + ",";
				}
				SqlString = SqlString + cFlagPulseRestored.ToString();
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

		//EMSCPRPerformer

		public int GetEMSCPRPerformerRS(int lPatientID)
		{
			//Retrieve EMSCPRPerformer recordset
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSCPRPerformerAll " + lPatientID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					cEMSCPRPerformer = orec;
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

		public int GetEMSCPRPerformer(int lCPRID)
		{
			//Retrieve EMSCPRPerformer recordset
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSCPRPerformer " + lCPRID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					cCPRID = Convert.ToInt32(orec["cpr_id"]);
					cCPRPerfPatientID = Convert.ToInt32(orec["patient_id"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cCPRPerformedBy = Convert.ToInt32(IncidentMain.GetVal(orec["performed_by_code"]));
					if (Convert.ToBoolean(orec["flag_arrest_witnessed"]))
					{
						cFlagArrestWitnessed = 1;
					}
					else
					{
						cFlagArrestWitnessed = 0;
					}
					if (Convert.ToBoolean(orec["flag_cpr_trained"]))
					{
						cFlagCPRTrained = 1;
					}
					else
					{
						cFlagCPRTrained = 0;
					}
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

		public int AddEMSCPRPerformer()
		{
			//Add new EMSCPRPerformer Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spInsert_EMSCPRPerformer " + cCPRPerfPatientID.ToString() + ",";
				if (cCPRPerformedBy == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cCPRPerformedBy.ToString() + ",";
				}
				SqlString = SqlString + cFlagCPRTrained.ToString() + "," + cFlagArrestWitnessed.ToString();
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

		public int DeleteEMSCPRPerformerAll(ref int lPatientID)
		{
			//Delete all EMSCPRPerformer Records for specified Patient ID
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spDelete_EMSCPRPerformerAll";
				ocmd.ExecuteNonQuery(new object[] { lPatientID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteEMSCPRPerformer(ref int lCPRID)
		{
			//Delete specific EMSCPRPerformer Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spDelete_EMSCPRPerformer";
				ocmd.ExecuteNonQuery(new object[] { lCPRID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int GetEMSPatientIVLine(int lLineID)
		{
			//Retrieve EMSPatientIVLine record and Load date into
			//EMSPatientIVLine class variables
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSPatientIVLine " + lLineID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					//Load Class  Variables
					cLineID = Convert.ToInt32(orec["line_id"]);
					CivPatientID = Convert.ToInt32(orec["patient_id"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cIVGauge = Convert.ToInt32(IncidentMain.GetVal(orec["iv_gauge_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cIVRoute = Convert.ToInt32(IncidentMain.GetVal(orec["iv_route_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cIVRate = Convert.ToInt32(IncidentMain.GetVal(orec["iv_rate_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cIVSite = Convert.ToInt32(IncidentMain.GetVal(orec["iv_site_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cIVAmount = Convert.ToInt32(IncidentMain.GetVal(orec["iv_amount"]));
					if (Convert.ToBoolean(orec["flag_saline_lock"]))
					{
						cFlagSalineLock = 1;
					}
					else
					{
						cFlagSalineLock = 0;
					}
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

		public int GetEMSPatientIVLineRS(int lPatientID)
		{
			//Retrieve EMSPatientIVLineRS records for current Patient report

			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSPatientIVLineAll " + lPatientID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cEMSPatientIVLine = orec;
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

		public int AddEMSPatientIVLine()
		{
			//Add new EMSPatientIVLine Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spInsert_EMSPatientIVLine " + CivPatientID.ToString() + ",";
				if (cIVGauge == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cIVGauge.ToString() + ",";
				}
				if (cIVRoute == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cIVRoute.ToString() + ",";
				}
				if (cIVRate == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cIVRate.ToString() + ",";
				}
				if (cIVSite == 0)
				{
					SqlString = SqlString + "NULL," + cIVAmount.ToString() + "," + cFlagSalineLock.ToString();
				}
				else
				{
					SqlString = SqlString + cIVSite.ToString() + "," + cIVAmount.ToString() + "," + cFlagSalineLock.ToString();
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

		public int UpdateEMSPatientIVLine()
		{
			//Update EMSPatientIVLine Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spUpdate_EMSPatientIVLine " + cLineID.ToString() + "," + CivPatientID.ToString() + ",";
				if (cIVGauge == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cIVGauge.ToString() + ",";
				}
				if (cIVRoute == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cIVRoute.ToString() + ",";
				}
				if (cIVRate == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cIVRate.ToString() + ",";
				}
				if (cIVSite == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cIVSite.ToString() + ",";
				}
				if (cIVAmount == 0)
				{
					SqlString = SqlString + "NULL";
				}
				else
				{
					SqlString = SqlString + cIVAmount.ToString();
				}
				SqlString = SqlString + "," + cFlagSalineLock.ToString();
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

		//EMSProcedure

		public int GetEMSProcedure(int lProcedureID)
		{
			//Retrieve EMSProcedure recordset
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSProcedure " + lProcedureID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					cCPRID = Convert.ToInt32(orec["cpr_id"]);
					cCPRPerfPatientID = Convert.ToInt32(orec["patient_id"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cCPRPerformedBy = Convert.ToInt32(IncidentMain.GetVal(orec["performed_by_code"]));
					if (Convert.ToBoolean(orec["flag_arrest_witnessed"]))
					{
						cFlagArrestWitnessed = 1;
					}
					else
					{
						cFlagArrestWitnessed = 0;
					}
					if (Convert.ToBoolean(orec["flag_cpr_trained"]))
					{
						cFlagCPRTrained = 1;
					}
					else
					{
						cFlagCPRTrained = 0;
					}
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

		public int GetEMSProcedureByType(int lPatientID, string sType)
		{
			//Retrieve EMS Procedure records for current Patient report
			//and specified Procedure Type
			//!! ALS = "A", BLS = "B"
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSProcedureByType " + lPatientID.ToString() + ",'" + sType + "'";
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cEMSProcedure = orec;
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

		public int AddEMSProcedure()
		{
			//Add New EMS Procedure Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spInsert_EMSProcedure " + cProcedurePatientID.ToString() + "," + cProcedure.ToString() + ",'";
				SqlString = SqlString + cPerformedBy + "',";
				if (cAttempts == 0)
				{
					SqlString = SqlString + "NULL," + cFlagSuccessful.ToString() + ",'";
				}
				else
				{
					SqlString = SqlString + cAttempts.ToString() + "," + cFlagSuccessful.ToString() + ",'";
				}
				SqlString = SqlString + Strings.Replace(cOtherProcedureDescription, "'", "''", 1, -1, CompareMethod.Binary) + "'";
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

		public int UpdateEMSProcedure()
		{
			//Update EMS Procedure Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spUpdate_EMSProcedure " + cProcedureID.ToString() + "," + cProcedurePatientID.ToString() + "," + cProcedure.ToString() + ",'";
				SqlString = SqlString + cPerformedBy + "',";
				if (cAttempts == 0)
				{
					SqlString = SqlString + "NULL," + cFlagSuccessful.ToString() + ",'";
				}
				else
				{
					SqlString = SqlString + cAttempts.ToString() + "," + cFlagSuccessful.ToString() + ",'";
				}
				SqlString = SqlString + Strings.Replace(cOtherProcedureDescription, "'", "''", 1, -1, CompareMethod.Binary) + "'";
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

		public int DeleteEMSProcedure(ref int lProcedureID)
		{
			//Delete specific EMSProcedure Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spDelete_EMSProcedure";
				ocmd.ExecuteNonQuery(new object[] { lProcedureID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteEMSProcedureAll(ref int lPatientID)
		{
			//Delete all EMSProcedure Records for specified Patient ID
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spDelete_EMSProcedureAll";
				ocmd.ExecuteNonQuery(new object[] { lPatientID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		// EMSPatientVitals

		public int GetEMSPatientVitals(int lVitalsID)
		{
			//Retrieve EMSPatientVitals record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSPatientVitals " + lVitalsID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					cVitalsID = Convert.ToInt32(orec["vitals_id"]);
					cVitalPatientID = Convert.ToInt32(orec["patient_id"]);
					cVitalsTime = Convert.ToDateTime(orec["vitals_time"]).ToString("HH:mm");
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cGCSEyes = Convert.ToInt32(IncidentMain.GetVal(orec["gcs_eyes"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cGCSVerbal = Convert.ToInt32(IncidentMain.GetVal(orec["gcs_verbal"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cGCSMotor = Convert.ToInt32(IncidentMain.GetVal(orec["gcs_motor"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cSystolic = Convert.ToInt32(IncidentMain.GetVal(orec["systolic"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cDiastolic = Convert.ToInt32(IncidentMain.GetVal(orec["diastolic"]));
					if (Convert.ToBoolean(orec["flag_diastolic_palp"]))
					{
						cFlagDiastolicPalp = 1;
					}
					else
					{
						cFlagDiastolicPalp = 0;
					}
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cPulse = Convert.ToInt32(IncidentMain.GetVal(orec["pulse"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cRespirationRate = Convert.ToInt32(IncidentMain.GetVal(orec["respiration_rate"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cVitalsPosition = Convert.ToInt32(IncidentMain.GetVal(orec["vitals_position"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cBloodGlucose = Convert.ToInt32(IncidentMain.GetVal(orec["blood_glucose"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cPulseOxygen = Convert.ToInt32(IncidentMain.GetVal(orec["pulse_oxygen"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cPercentOxygen = Convert.ToInt32(IncidentMain.GetVal(orec["percent_oxygen"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cECG = Convert.ToInt32(IncidentMain.GetVal(orec["ecg_code"]));
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

		public int GetEMSPatientVitalsRS(int lPatientID)
		{
			//Retrieve EMSPatientVitalsRS records for current Patient report

			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSPatientVitalsAll " + lPatientID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cEMSPatientVitals = orec;
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

		public int AddEMSPatientVitals()
		{
			//Add New EMSPatientVitals Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spInsert_EMSPatientVitals " + cVitalPatientID.ToString() + ",'" + cVitalsTime + "',";
				if (cGCSEyes == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cGCSEyes.ToString() + ",";
				}
				if (cGCSVerbal == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cGCSVerbal.ToString() + ",";
				}
				if (cGCSMotor == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cGCSMotor.ToString() + ",";
				}
				if (cSystolic == -1)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cSystolic.ToString() + ",";
				}
				if (cDiastolic == -1)
				{
					SqlString = SqlString + "NULL," + cFlagDiastolicPalp.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cDiastolic.ToString() + "," + cFlagDiastolicPalp.ToString() + ",";
				}
				if (cPulse == -1)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cPulse.ToString() + ",";
				}
				if (cRespirationRate == -1)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cRespirationRate.ToString() + ",";
				}
				if (cVitalsPosition == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cVitalsPosition.ToString() + ",";
				}
				if (cBloodGlucose == -1)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cBloodGlucose.ToString() + ",";
				}
				if (cPulseOxygen == -1)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cPulseOxygen.ToString() + ",";
				}
				if (cPercentOxygen == -1)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cPercentOxygen.ToString() + ",";
				}
				if (cECG == 0)
				{
					SqlString = SqlString + "NULL";
				}
				else
				{
					SqlString = SqlString + cECG.ToString();
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

		public int UpdateEMSPatientVitals()
		{
			//Update EMSPatientVitals Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spUpdate_EMSPatientVitals " + cVitalsID.ToString() + "," + cVitalPatientID.ToString() + ",'" + cVitalsTime + "',";
				if (cGCSEyes == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cGCSEyes.ToString() + ",";
				}
				if (cGCSVerbal == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cGCSVerbal.ToString() + ",";
				}
				if (cGCSMotor == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cGCSMotor.ToString() + ",";
				}
				if (cSystolic == -1)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cSystolic.ToString() + ",";
				}
				if (cDiastolic == -1)
				{
					SqlString = SqlString + "NULL," + cFlagDiastolicPalp.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cDiastolic.ToString() + "," + cFlagDiastolicPalp.ToString() + ",";
				}
				if (cPulse == -1)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cPulse.ToString() + ",";
				}
				if (cRespirationRate == -1)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cRespirationRate.ToString() + ",";
				}
				if (cVitalsPosition == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cVitalsPosition.ToString() + ",";
				}
				if (cBloodGlucose == -1)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cBloodGlucose.ToString() + ",";
				}
				if (cPulseOxygen == -1)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cPulseOxygen.ToString() + ",";
				}
				if (cPercentOxygen == -1)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cPercentOxygen.ToString() + ",";
				}
				if (cECG == 0)
				{
					SqlString = SqlString + "NULL";
				}
				else
				{
					SqlString = SqlString + cECG.ToString();
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

		public int GetRevisedTraumaScore(int lPatientID)
		{
			//Retrieve Revised Trauma Score
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_RevisedTraumaScore " + lPatientID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					return Convert.ToInt32(orec["revised_trauma_score"]);
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

		public int GetEMSPatientContactReport(int lPatientID)
		{
			//Retrieve EMS Patient Contact Record
			//Formatted for Reporting
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_EMSPatientContact " + lPatientID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cEMSPatientContact = orec;
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

		public int GetEMSPreExistingConditionReport(int lPatientID)
		{
			//Retrieve EMS PreExistingCondition Recordset
			//Formatted for Reporting
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_EMSPreExistingCondition " + lPatientID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cEMSPreExistingCondition = orec;
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

		public int GetEMSContributingFactorReport(int lPatientID)
		{
			//Retrieve EMS Contributing Factor Records
			//Formatted for Reporting
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_EMSContributingFactor " + lPatientID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cEMSContributingFactor = orec;
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

		public int GetEMSPatientExamReport(int lPatientID)
		{
			//Retrieve EMS Patient Exam Recordset
			//Formatted for Reporting
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_EMSPatientExam " + lPatientID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cEMCPatientExam = orec;
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

		public int GetEMSSecondaryIllnessReport(int lPatientID)
		{
			//Retrieve EMS Secondary Illness Recordset
			//Formatted for Reporting
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_EMSSecondaryIllness " + lPatientID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cEMSSecondaryIllness = orec;
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

		public int GetEMSPatientVitalsReport(int lPatientID)
		{

			//Retrieve EMS Patient Vitals Record
			//Formatted for Reporting
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_EMSPatientVitals " + lPatientID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cEMSPatientVitals = orec;
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

		public int GetEMSProceduresReport(int lPatientID)
		{
			//Retrieve EMS Procedures Performed Record
			//Formatted for Reporting
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_EMSProcedureReport " + lPatientID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cEMSProcedure = orec;
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

		public int GetEMSPatientIVLineReport(int lPatientID)
		{
			//Retrieve EMS Patient IV Lines Record
			//Formatted for Reporting
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_EMSIVLineReport " + lPatientID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cEMSPatientIVLine = orec;
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

		public int GetEMSMedicationReport(int lPatientID)
		{
			//Retrieve EMS Medication Records
			//Formatted for Reporting
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_EMSMedication " + lPatientID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cEMSMedication = orec;
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

		public int GetEMSCPRReport(int lPatientID)
		{
			//Retrieve EMS CPR Records
			//Formatted for Reporting
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_EMSCPR " + lPatientID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cEMSCPR = orec;
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

		public int GetEMSCPRPerformerReport(int lPatientID)
		{
			//Retrieve EMS CPR Performer Records
			//Formatted for Reporting
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_EMSCPRPerformer " + lPatientID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cEMSCPRPerformer = orec;
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

		public int GetEMSPatientTraumaReport(int lPatientID)
		{
			//Retrieve EMS Patient Trauma Records
			//Formatted for Reporting
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_EMSPatientTrauma " + lPatientID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cEMSPatientTrauma = orec;
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

		public int GetEMSTraumaDescriptorReport(int lPatientID, int TType)
		{
			//Retrieve EMS Patient Trauma Records
			//Formatted for Reporting
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_EMSTraumaDescriptor " + lPatientID.ToString() + "," + TType.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cEMSTraumaDescriptor = orec;
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

		public int GetEMSPatientNarrationReport(int lPatientID)
		{
			//Retrieve EMS Patient Narration Records
			//Formatted for Reporting
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_EMSPatientNarration " + lPatientID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cEMSPatientNarration = orec;
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

		public int AddFDCaresReferral()
		{
			//Add New FDCaresReferral Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spInsert_FDCaresReferral " + cReferralIncidentID.ToString() + ",'" + cReferredBy + "',";
				if (cReferralPatientID == 0)
				{
					SqlString = SqlString + "NULL, '";
				}
				else
				{
					SqlString = SqlString + cReferralPatientID.ToString() + ", '";
				}
				SqlString = SqlString + cReferralComment + "'";

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

		public int UpdateFDCaresReferral(int lIncidentID, int lPatientID, string sComment)
		{
			//Update FDCaresReferral Record with patient Id
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spUpdate_FDCaresReferral " + lIncidentID.ToString() + ", " + lPatientID.ToString() + ",'" + sComment + "'";

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

		public int GetFDCaresIncident(int lIncidentID)
		{
			//Retrieve Existing FDCares Referral record for this incident
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_IncidentFDCaresReferrals " + lIncidentID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cFDCaresReferral = orec;
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

		public int GetFDCaresIncidentPatient(int lIncidentID, int lPatientID)
		{
			//Retrieve Existing FDCares Referral record for this incident patient
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_IncidentPatientFDCaresReferrals " + lIncidentID.ToString() + ", " + lPatientID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cFDCaresReferral = orec;
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