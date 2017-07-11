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

	public class clsCasualty
		: UpgradeHelpers.Interfaces.IDependentModel, UpgradeHelpers.Interfaces.ICreatesObjects, UpgradeHelpers
		.Interfaces.IInteractsWithView, UpgradeHelpers.Interfaces.IInitializableCommon, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(clsCasualty));
		}

		void UpgradeHelpers.Interfaces.IInitializableCommon.Common()
		{
			_cCivilianHumanFactorCode = null;
			_cFSCasualtyContributingFactorCode = null;
			_cCasualtyContributingFactorCode = null;
			_cActivityCode = null;
			_cWhereOccuredCode = null;
			_cInjurySeverityCode = null;
			_cInjuryCausedByCode = null;
			_cInjuryLocationCode = null;
			_cFPECodeRS = null;
			cFPECode = 0;
			cFPEDescription = "";
			_cFPEStatusCode = null;
			cFPEStatusID = 0;
			cFPEStatusDescription = "";
			_cFPEProblemCode = null;
			cFPEProblemID = 0;
			cFPEProblemDescription = "";
			_cFireServiceCasualty = null;
			cCasualtyID = 0;
			cIncidentID = 0;
			cEmployeeID = "";
			cCasualtyDate = "";
			cActivity = 0;
			cWhereOccurred = 0;
			cInjuryCausedBy = 0;
			cInjurySeverity = 0;
			cBodyPartInjured = 0;
			cInjuryType = 0;
			cInjuryLocation = 0;
			cFlagProtEquipCaused = 0;
			cDetailedNarrative = "";
			cRecommendationsForPrevention = "";
			_cFSCasualtyContributingFactorRS = null;
			cFSCasualtyID = 0;
			cFSCasualtyContributingFactor = 0;
			_cFSCasualtyFailedEquipment = null;
			cFEID = 0;
			cFECasualtyID = 0;
			cFE_FPECode = 0;
			cFE_FPEStatus = 0;
			cFE_FPEProblem = 0;
			cManufacturer = "";
			cModel = "";
			cSerialNumber = "";
			_cCivCasualtyRS = null;
			cCivCasualtyID = 0;
			cCivIncidentID = 0;
			cCivInjurySeverity = 0;
			cCivInjuryCausedBy = 0;
			cCivInjuryFloor = 0;
			cCivInjuryLocation = 0;
			cCivPatientID = 0;
			_cCFCivilContribFactor = null;
			cCFCasualtyID = 0;
			cCFContributingFactor = 0;
			_cCHCivilHumanFactor = null;
			cCHCasualtyID = 0;
			cCHHumanFactor = 0;
		}

		//********************************************************
		//**    Casualty Class                                  **
		//**  Contains  Table References and Methods            **
		//**  For FS & Civilian Casualty Data Access            **
		//********************************************************
		//**    Methods                                         **
		//**----------------------------------------------------**


		//********************************************************
		//**             Private Class Variables                **
		//********************************************************
		//**$$$ Body Part and Injury Type Codes loaded from     **
		//**$$  clsEMSCodes EMSInjuryDetailCode                 **
		//********************************************************


		//CivilianHumanFactorCode
		public virtual ADORecordSetHelper _cCivilianHumanFactorCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cCivilianHumanFactorCode
		{
			get
			{
				if (_cCivilianHumanFactorCode == null)
				{
					_cCivilianHumanFactorCode = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cCivilianHumanFactorCode;
			}
			set
			{
				_cCivilianHumanFactorCode = value;
			}
		}


		//FSCasualtyContributingFactorCode
		public virtual ADORecordSetHelper _cFSCasualtyContributingFactorCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cFSCasualtyContributingFactorCode
		{
			get
			{
				if (_cFSCasualtyContributingFactorCode == null)
				{
					_cFSCasualtyContributingFactorCode = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cFSCasualtyContributingFactorCode;
			}
			set
			{
				_cFSCasualtyContributingFactorCode = value;
			}
		}


		//CasualtyContributingFactorCode
		public virtual ADORecordSetHelper _cCasualtyContributingFactorCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cCasualtyContributingFactorCode
		{
			get
			{
				if (_cCasualtyContributingFactorCode == null)
				{
					_cCasualtyContributingFactorCode = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cCasualtyContributingFactorCode;
			}
			set
			{
				_cCasualtyContributingFactorCode = value;
			}
		}


		//ActivityCode
		public virtual ADORecordSetHelper _cActivityCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cActivityCode
		{
			get
			{
				if (_cActivityCode == null)
				{
					_cActivityCode = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cActivityCode;
			}
			set
			{
				_cActivityCode = value;
			}
		}


		//WhereOccuredCode
		public virtual ADORecordSetHelper _cWhereOccuredCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cWhereOccuredCode
		{
			get
			{
				if (_cWhereOccuredCode == null)
				{
					_cWhereOccuredCode = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cWhereOccuredCode;
			}
			set
			{
				_cWhereOccuredCode = value;
			}
		}


		//InjurySeverityCode
		public virtual ADORecordSetHelper _cInjurySeverityCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cInjurySeverityCode
		{
			get
			{
				if (_cInjurySeverityCode == null)
				{
					_cInjurySeverityCode = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cInjurySeverityCode;
			}
			set
			{
				_cInjurySeverityCode = value;
			}
		}


		//InjuryCausedByCode
		public virtual ADORecordSetHelper _cInjuryCausedByCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cInjuryCausedByCode
		{
			get
			{
				if (_cInjuryCausedByCode == null)
				{
					_cInjuryCausedByCode = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cInjuryCausedByCode;
			}
			set
			{
				_cInjuryCausedByCode = value;
			}
		}


		//InjuryLocationCode
		public virtual ADORecordSetHelper _cInjuryLocationCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cInjuryLocationCode
		{
			get
			{
				if (_cInjuryLocationCode == null)
				{
					_cInjuryLocationCode = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cInjuryLocationCode;
			}
			set
			{
				_cInjuryLocationCode = value;
			}
		}


		//FPE_Code
		public virtual ADORecordSetHelper _cFPECodeRS { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cFPECodeRS
		{
			get
			{
				if (_cFPECodeRS == null)
				{
					_cFPECodeRS = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cFPECodeRS;
			}
			set
			{
				_cFPECodeRS = value;
			}
		}

		public virtual int cFPECode { get; set; }

		public virtual string cFPEDescription { get; set; }

		//FPE_Status
		public virtual ADORecordSetHelper _cFPEStatusCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cFPEStatusCode
		{
			get
			{
				if (_cFPEStatusCode == null)
				{
					_cFPEStatusCode = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cFPEStatusCode;
			}
			set
			{
				_cFPEStatusCode = value;
			}
		}

		public virtual int cFPEStatusID { get; set; }

		public virtual string cFPEStatusDescription { get; set; }

		//FPE_Problem
		public virtual ADORecordSetHelper _cFPEProblemCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cFPEProblemCode
		{
			get
			{
				if (_cFPEProblemCode == null)
				{
					_cFPEProblemCode = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cFPEProblemCode;
			}
			set
			{
				_cFPEProblemCode = value;
			}
		}

		public virtual int cFPEProblemID { get; set; }

		public virtual string cFPEProblemDescription { get; set; }

		//FireServiceCasualty
		public virtual ADORecordSetHelper _cFireServiceCasualty { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cFireServiceCasualty
		{
			get
			{
				if (_cFireServiceCasualty == null)
				{
					_cFireServiceCasualty = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cFireServiceCasualty;
			}
			set
			{
				_cFireServiceCasualty = value;
			}
		}

		public virtual int cCasualtyID { get; set; }

		public virtual int cIncidentID { get; set; }

		public virtual string cEmployeeID { get; set; }

		public virtual string cCasualtyDate { get; set; }

		public virtual int cActivity { get; set; }

		public virtual int cWhereOccurred { get; set; }

		public virtual int cInjuryCausedBy { get; set; }

		public virtual int cInjurySeverity { get; set; }

		public virtual int cBodyPartInjured { get; set; }

		public virtual int cInjuryType { get; set; }

		public virtual int cInjuryLocation { get; set; }

		public virtual byte cFlagProtEquipCaused { get; set; }

		public virtual string cDetailedNarrative { get; set; }

		public virtual string cRecommendationsForPrevention { get; set; }

		//FSCasualtyContributingFactor
		public virtual ADORecordSetHelper _cFSCasualtyContributingFactorRS { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cFSCasualtyContributingFactorRS
		{
			get
			{
				if (_cFSCasualtyContributingFactorRS == null)
				{
					_cFSCasualtyContributingFactorRS = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cFSCasualtyContributingFactorRS;
			}
			set
			{
				_cFSCasualtyContributingFactorRS = value;
			}
		}

		public virtual int cFSCasualtyID { get; set; }

		public virtual int cFSCasualtyContributingFactor { get; set; }

		//FSCasualtyFailedEquipment
		public virtual ADORecordSetHelper _cFSCasualtyFailedEquipment { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cFSCasualtyFailedEquipment
		{
			get
			{
				if (_cFSCasualtyFailedEquipment == null)
				{
					_cFSCasualtyFailedEquipment = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cFSCasualtyFailedEquipment;
			}
			set
			{
				_cFSCasualtyFailedEquipment = value;
			}
		}

		public virtual int cFEID { get; set; }

		public virtual int cFECasualtyID { get; set; }

		public virtual int cFE_FPECode { get; set; }

		public virtual int cFE_FPEStatus { get; set; }

		public virtual int cFE_FPEProblem { get; set; }

		public virtual string cManufacturer { get; set; }

		public virtual string cModel { get; set; }

		public virtual string cSerialNumber { get; set; }

		//Civilian Casualty
		public virtual ADORecordSetHelper _cCivCasualtyRS { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cCivCasualtyRS
		{
			get
			{
				if (_cCivCasualtyRS == null)
				{
					_cCivCasualtyRS = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cCivCasualtyRS;
			}
			set
			{
				_cCivCasualtyRS = value;
			}
		}

		public virtual int cCivCasualtyID { get; set; }

		public virtual int cCivIncidentID { get; set; }

		public virtual int cCivInjurySeverity { get; set; }

		public virtual int cCivInjuryCausedBy { get; set; }

		public virtual int cCivInjuryFloor { get; set; }

		public virtual int cCivInjuryLocation { get; set; }

		public virtual int cCivPatientID { get; set; }

		//CivilianContributingFactor
		public virtual ADORecordSetHelper _cCFCivilContribFactor { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cCFCivilContribFactor
		{
			get
			{
				if (_cCFCivilContribFactor == null)
				{
					_cCFCivilContribFactor = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cCFCivilContribFactor;
			}
			set
			{
				_cCFCivilContribFactor = value;
			}
		}

		public virtual int cCFCasualtyID { get; set; }

		public virtual int cCFContributingFactor { get; set; }

		//CivilianHumanFactor
		public virtual ADORecordSetHelper _cCHCivilHumanFactor { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cCHCivilHumanFactor
		{
			get
			{
				if (_cCHCivilHumanFactor == null)
				{
					_cCHCivilHumanFactor = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cCHCivilHumanFactor;
			}
			set
			{
				_cCHCivilHumanFactor = value;
			}
		}

		public virtual int cCHCasualtyID { get; set; }

		public virtual int cCHHumanFactor { get; set; }


		//*********************************************
		//**         Class Public Properties         **
		//*********************************************
		//FireServiceCasualty
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper FireServiceCasualty
		{
			get
			{
				return cFireServiceCasualty;
			}
			set
			{
				cFireServiceCasualty = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int CasualtyID
		{
			get
			{
				return cCasualtyID;
			}
			set
			{
				cCasualtyID = value;
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


		public string CasualtyDate
		{
			get
			{
				return cCasualtyDate;
			}
			set
			{
				cCasualtyDate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int Activity
		{
			get
			{
				return cActivity;
			}
			set
			{
				cActivity = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int WhereOccurred
		{
			get
			{
				return cWhereOccurred;
			}
			set
			{
				cWhereOccurred = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int InjuryCausedBy
		{
			get
			{
				return cInjuryCausedBy;
			}
			set
			{
				cInjuryCausedBy = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int InjurySeverity
		{
			get
			{
				return cInjurySeverity;
			}
			set
			{
				cInjurySeverity = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int BodyPartInjured
		{
			get
			{
				return cBodyPartInjured;
			}
			set
			{
				cBodyPartInjured = value;
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


		public int InjuryLocation
		{
			get
			{
				return cInjuryLocation;
			}
			set
			{
				cInjuryLocation = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte FlagProtEquipCaused
		{
			get
			{
				return cFlagProtEquipCaused;
			}
			set
			{
				cFlagProtEquipCaused = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string DetailedNarrative
		{
			get
			{
				return cDetailedNarrative;
			}
			set
			{
				cDetailedNarrative = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string RecommendationsForPrevention
		{
			get
			{
				return cRecommendationsForPrevention;
			}
			set
			{
				cRecommendationsForPrevention = value;
			}
		}


		//FSCasualtyContributingFactor
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper FSCasualtyContributingFactorRS
		{
			get
			{
				return cFSCasualtyContributingFactorRS;
			}
			set
			{
				cFSCasualtyContributingFactorRS = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int FSCasualtyID
		{
			get
			{
				return cFSCasualtyID;
			}
			set
			{
				cFSCasualtyID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int FSCasualtyContributingFactor
		{
			get
			{
				return cFSCasualtyContributingFactor;
			}
			set
			{
				cFSCasualtyContributingFactor = value;
			}
		}


		//FSCasualtyFailedEquipment
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper FSCasualtyFailedEquipment
		{
			get
			{
				return cFSCasualtyFailedEquipment;
			}
			set
			{
				cFSCasualtyFailedEquipment = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int FEID
		{
			get
			{
				return cFEID;
			}
			set
			{
				cFEID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int FECasualtyID
		{
			get
			{
				return cFECasualtyID;
			}
			set
			{
				cFECasualtyID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int FE_FPECode
		{
			get
			{
				return cFE_FPECode;
			}
			set
			{
				cFE_FPECode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int FE_FPEStatus
		{
			get
			{
				return cFE_FPEStatus;
			}
			set
			{
				cFE_FPEStatus = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int FE_FPEProblem
		{
			get
			{
				return cFE_FPEProblem;
			}
			set
			{
				cFE_FPEProblem = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string Manufacturer
		{
			get
			{
				return cManufacturer;
			}
			set
			{
				cManufacturer = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string Model
		{
			get
			{
				return cModel;
			}
			set
			{
				cModel = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string SerialNumber
		{
			get
			{
				return cSerialNumber;
			}
			set
			{
				cSerialNumber = value;
			}
		}


		//CivilianCasualty
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper CivCasualtyRS
		{
			get
			{
				return cCivCasualtyRS;
			}
			set
			{
				cCivCasualtyRS = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int CivCasualtyID
		{
			get
			{
				return cCivCasualtyID;
			}
			set
			{
				cCivCasualtyID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int CivIncidentID
		{
			get
			{
				return cCivIncidentID;
			}
			set
			{
				cCivIncidentID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int CivInjurySeverity
		{
			get
			{
				return cCivInjurySeverity;
			}
			set
			{
				cCivInjurySeverity = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int CivInjuryCausedBy
		{
			get
			{
				return cCivInjuryCausedBy;
			}
			set
			{
				cCivInjuryCausedBy = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int CivInjuryFloor
		{
			get
			{
				return cCivInjuryFloor;
			}
			set
			{
				cCivInjuryFloor = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int CivInjuryLocation
		{
			get
			{
				return cCivInjuryLocation;
			}
			set
			{
				cCivInjuryLocation = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int CivPatientID
		{
			get
			{
				return cCivPatientID;
			}
			set
			{
				cCivPatientID = value;
			}
		}


		//CivilianContributingFactor
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper CFCivilContribFactor
		{
			get
			{
				return cCFCivilContribFactor;
			}
			set
			{
				cCFCivilContribFactor = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int CFCasualtyID
		{
			get
			{
				return cCFCasualtyID;
			}
			set
			{
				cCFCasualtyID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int CFContributingFactor
		{
			get
			{
				return cCFContributingFactor;
			}
			set
			{
				cCFContributingFactor = value;
			}
		}


		//CivilianHumanFactor
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper CHCivilHumanFactor
		{
			get
			{
				return cCHCivilHumanFactor;
			}
			set
			{
				cCHCivilHumanFactor = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int CHCasualtyID
		{
			get
			{
				return cCHCasualtyID;
			}
			set
			{
				cCHCasualtyID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int CHHumanFactor
		{
			get
			{
				return cCHHumanFactor;
			}
			set
			{
				cCHHumanFactor = value;
			}
		}


		//CivilianHumanFactorCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper CivilianHumanFactorCode
		{
			get
			{
				return cCivilianHumanFactorCode;
			}
			set
			{
				cCivilianHumanFactorCode = value;
			}
		}


		//CasualtyContributingFactorCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper CasualtyContributingFactorCode
		{
			get
			{
				return cCasualtyContributingFactorCode;
			}
			set
			{
				cCasualtyContributingFactorCode = value;
			}
		}


		//FSCasualtyContributingFactorCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper FSCasualtyContributingFactorCode
		{
			get
			{
				return cFSCasualtyContributingFactorCode;
			}
			set
			{
				cFSCasualtyContributingFactorCode = value;
			}
		}


		//ActivityCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper ActivityCode
		{
			get
			{
				return cActivityCode;
			}
			set
			{
				cActivityCode = value;
			}
		}


		//WhereOccuredCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper WhereOccuredCode
		{
			get
			{
				return cWhereOccuredCode;
			}
			set
			{
				cWhereOccuredCode = value;
			}
		}


		//InjurySeverityCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper InjurySeverityCode
		{
			get
			{
				return cInjurySeverityCode;
			}
			set
			{
				cInjurySeverityCode = value;
			}
		}


		//InjuryCausedByCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper InjuryCausedByCode
		{
			get
			{
				return cInjuryCausedByCode;
			}
			set
			{
				cInjuryCausedByCode = value;
			}
		}


		//InjuryLocationCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper InjuryLocationCode
		{
			get
			{
				return cInjuryLocationCode;
			}
			set
			{
				cInjuryLocationCode = value;
			}
		}


		//FPE_Code
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper FPECodeRS
		{
			get
			{
				return cFPECodeRS;
			}
			set
			{
				cFPECodeRS = value;
			}
		}


		//FPE_Status
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper FPEStatusCode
		{
			get
			{
				return cFPEStatusCode;
			}
			set
			{
				cFPEStatusCode = value;
			}
		}


		//FPE_Problem
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper FPEProblemCode
		{
			get
			{
				return cFPEProblemCode;
			}
			set
			{
				cFPEProblemCode = value;
			}
		}


		//**********************************************
		//**         Public Class Methods             **
		//**********************************************

		public void GetActivityCode()
		{
			//Get ActivityCode Recordset
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_ActivityCode";
				orec = ADORecordSetHelper.Open(ocmd, "");
				cActivityCode = orec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetWhereOccuredCode()
		{
			//Get ActivityCode Recordset
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_WhereOccuredCode";
				orec = ADORecordSetHelper.Open(ocmd, "");
				cWhereOccuredCode = orec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetInjurySeverity()
		{
			//Get InjurySeverity Recordset
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_InjurySeverityCode";
				orec = ADORecordSetHelper.Open(ocmd, "");
				cInjurySeverityCode = orec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetInjuryCausedByCode()
		{
			//Get InjuryCausedByCode Recordset
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_InjuryCausedByCode";
				orec = ADORecordSetHelper.Open(ocmd, "");
				cInjuryCausedByCode = orec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetInjuryLocationCode()
		{
			//Get InjuryLocationCode Recordset
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_InjuryLocationCode";
				orec = ADORecordSetHelper.Open(ocmd, "");
				cInjuryLocationCode = orec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetFSCasualtyContributingFactorCode()
		{
			//Get FSCasualtyContributingFactorCode Recordset
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_FSCasualtyContributingFactorCode";
				orec = ADORecordSetHelper.Open(ocmd, "");
				cFSCasualtyContributingFactorCode = orec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetCasualtyContributingFactorCode()
		{
			//Get CasualtyContributingFactorCode Recordset
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_CasualtyContributingFactorCode";
				orec = ADORecordSetHelper.Open(ocmd, "");
				cCasualtyContributingFactorCode = orec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetCivilianHumanFactorCode()
		{
			//Get CivilianHumanFactorCode Recordset
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_CivilianHumanFactorCode";
				orec = ADORecordSetHelper.Open(ocmd, "");
				cCivilianHumanFactorCode = orec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}



		public void GetFPECodeRS()
		{
			//Get Fire Protective Equipment Codes Recordset
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_FPE_Code";
				orec = ADORecordSetHelper.Open(ocmd, "");
				cFPECodeRS = orec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetFPEStatusByCode(int iFPECode)
		{
			//Get Fire Protective Equipment Status Codes Recordset
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_FPEStatusByCode " + iFPECode.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");
				cFPEStatusCode = orec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetFPEProblemByCode(int iFPECode)
		{
			//Get Fire Protective Equipment Problem Code Recordset
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_FPEProblemByCode " + iFPECode.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");
				cFPEProblemCode = orec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public int GetFSCasualty(int lCasualtyID)
		{
			//Retrieve FS Casualty record and Load data into
			//FS Casualty class variables
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_FireServiceCasualty " + lCasualtyID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					//Load Class  Variables
					cCasualtyID = Convert.ToInt32(orec["casualty_id"]);
					cIncidentID = Convert.ToInt32(orec["incident_id"]);
					cEmployeeID = Convert.ToString(orec["employee_id"]);
					System.DateTime TempDate = DateTime.FromOADate(0);
					cCasualtyDate = (DateTime.TryParse(IncidentMain.Clean(orec["casualty_date"]), out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : IncidentMain.Clean(orec["casualty_date"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cActivity = Convert.ToInt32(IncidentMain.GetVal(orec["activity_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cWhereOccurred = Convert.ToInt32(IncidentMain.GetVal(orec["where_occurred_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cInjurySeverity = Convert.ToInt32(IncidentMain.GetVal(orec["injury_severity_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cBodyPartInjured = Convert.ToInt32(IncidentMain.GetVal(orec["body_part_injured"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cInjuryType = Convert.ToInt32(IncidentMain.GetVal(orec["injury_type"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cInjuryCausedBy = Convert.ToInt32(IncidentMain.GetVal(orec["injury_caused_by_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cInjuryLocation = Convert.ToInt32(IncidentMain.GetVal(orec["injury_location_code"]));
					//UPGRADE_WARNING: (1068) GetVal(orec(flag_prot_equip_caused)) of type Variant is being forced to bool. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					if (Convert.ToBoolean(IncidentMain.GetVal(orec["flag_prot_equip_caused"])))
					{
						cFlagProtEquipCaused = 1;
					}
					else
					{
						cFlagProtEquipCaused = 0;
					}
					cDetailedNarrative = IncidentMain.Clean(orec["detailed_narrative"]);
					cRecommendationsForPrevention = IncidentMain.Clean(orec["recommendations_for_prevention"]);
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

		public int GetFSCasualtyReport(int lCasualtyID)
		{
			//Retrieve FS Casualty Report record

			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_FireServiceCasualty " + lCasualtyID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cFireServiceCasualty = orec;
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

		public int AddFSCasualty()
		{
			//Add New Fire Service Casualty Report Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;
			string SqlString = "";

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spInsert_FireServiceCasualty " + cIncidentID.ToString() + ",'" + cEmployeeID + "','" + cCasualtyDate + "',";
				//Test for Nulls
				if (cActivity == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cActivity.ToString() + ",";
				}
				if (cWhereOccurred == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cWhereOccurred.ToString() + ",";
				}
				if (cInjuryCausedBy == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cInjuryCausedBy.ToString() + ",";
				}
				if (cInjurySeverity == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cInjurySeverity.ToString() + ",";
				}
				if (cBodyPartInjured == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cBodyPartInjured.ToString() + ",";
				}
				if (cInjuryType == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cInjuryType.ToString() + ",";
				}
				if (cInjuryLocation == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cInjuryLocation.ToString() + ",";
				}
				SqlString = SqlString + cFlagProtEquipCaused.ToString() + ",'" + Strings.Replace(cDetailedNarrative, "'", "''", 1, -1, CompareMethod.Binary) + "','" + Strings.Replace(cRecommendationsForPrevention, "'", "''", 1, -1, CompareMethod.Binary) + "'";
				ocmd.CommandText = SqlString;
				ocmd.ExecuteNonQuery();
				ocmd.CommandText = "spSelect_NewFSCasualtyID";
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (GetFSCasualty(Convert.ToInt32(orec[0])) != 0)
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

		public int UpdateFSCasualty()
		{
			//Update Fire Service Casualty Report Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spUpdate_FireServiceCasualty " + cCasualtyID.ToString() + "," + cIncidentID.ToString() + ",'" + cEmployeeID + "','" + cCasualtyDate + "',";
				//Test for Nulls
				if (cActivity == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cActivity.ToString() + ",";
				}
				if (cWhereOccurred == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cWhereOccurred.ToString() + ",";
				}
				if (cInjuryCausedBy == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cInjuryCausedBy.ToString() + ",";
				}
				if (cInjurySeverity == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cInjurySeverity.ToString() + ",";
				}
				if (cBodyPartInjured == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cBodyPartInjured.ToString() + ",";
				}
				if (cInjuryType == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cInjuryType.ToString() + ",";
				}
				if (cInjuryLocation == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cInjuryLocation.ToString() + ",";
				}
				SqlString = SqlString + cFlagProtEquipCaused.ToString() + ",'" + Strings.Replace(cDetailedNarrative, "'", "''", 1, -1, CompareMethod.Binary) + "','" + Strings.Replace(cRecommendationsForPrevention, "'", "''", 1, -1, CompareMethod.Binary) + "'";
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

		public int DeleteFireServiceCasualty(ref int lCasualtyID)
		{
			//Delete FireServiceCasualty and all Dependent records
			//ReportLog and ReportLogHistory updated by stored procedure
			//Parameter Required to avoid accidental execution
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spDelete_FireServiceCasualty";
				//UPGRADE_WARNING: (2081) Array has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
				ocmd.ExecuteNonQuery(new object[] { lCasualtyID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int GetFSContribFactorRS(int lCasualtyID)
		{
			//Get FireSeviceContribution Factor Records

			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{


				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_FSContributingFactors " + lCasualtyID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cFSCasualtyContributingFactorRS = orec;
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

		public int GetFSContribFactorReport(int lCasualtyID)
		{
			//Get FireSeviceContribution Factor Report Records

			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{


				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_FSCasualtyContributingFactor " + lCasualtyID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cFSCasualtyContributingFactorRS = orec;
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

		public int AddFSCasualtyContributingFactor()
		{
			//Add FSCasualtyContributingFactor Record
			//All field reference  Class Private Variables
			//Which must be set prior to calling this function

			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;
				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spInsert_FSCasualtyContributingFactor";
				ocmd.ExecuteNonQuery(new object[] { cFSCasualtyID, cFSCasualtyContributingFactor });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteFSCasualtyContributingFactor(ref int lCasualtyID)
		{
			//Delete all FS Contributing Factor Records for Current FS Casualty
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
				ocmd.CommandText = "spDelete_FSCasualtyContributingFactor";
				ocmd.ExecuteNonQuery(new object[] { lCasualtyID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int GetFSCasualtyFailedEquipment(int lCasualtyID)
		{
			//Get FPE Equipment Failure Records

			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{


				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_FSCasualtyFailedEquipment " + lCasualtyID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cFSCasualtyFailedEquipment = orec;
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

		public int GetFSCasualtyFailedEquipmentReport(int lCasualtyID)
		{
			//Get FPE Equipment Failure Report Records

			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{


				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_FSCasualtyFailedEquipment " + lCasualtyID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cFSCasualtyFailedEquipment = orec;
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


		public int AddFSCasualtyFailedEquipment()
		{
			//Add New FSCasualtyFailedEquipment Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spInsert_FSCasualtyFailedEquipment " + cFECasualtyID.ToString() + ",";
				//Test for Nulls
				if (cFE_FPECode == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cFE_FPECode.ToString() + ",";
				}
				if (cFE_FPEStatus == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cFE_FPEStatus.ToString() + ",";
				}
				if (cFE_FPEProblem == 0)
				{
					SqlString = SqlString + "NULL,'";
				}
				else
				{
					SqlString = SqlString + cFE_FPEProblem.ToString() + ",'";
				}
				SqlString = SqlString + Strings.Replace(cManufacturer, "'", "''", 1, -1, CompareMethod.Binary) + "','" + cModel + "','" + cSerialNumber + "'";
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

		public int DeleteAllFSCasualtyFailedEquipment(ref int lCasualtyID)
		{
			//Delete all FS CasualtyFailedEquipment Records for Current FS Casualty

			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spDelete_FSCasualtyFailedEquipmentAll";
				ocmd.ExecuteNonQuery(new object[] { lCasualtyID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteFSCasualtyFailedEquipment(ref int lFEID)
		{
			//Delete Individual FS CasualtyFailedEquipment Record

			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spDelete_FSCasualtyFailedEquipment";
				ocmd.ExecuteNonQuery(new object[] { lFEID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}


		public int GetCivilianCasualty(int lCasualtyID)
		{
			//Retrieve Civilian Casualty record and Load date into
			//Civilian Casualty class variables
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_CivilianCasualty " + lCasualtyID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					//Load Class  Variables
					cCivCasualtyID = Convert.ToInt32(orec["civilian_casualty_id"]);
					cCivIncidentID = Convert.ToInt32(orec["incident_id"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cCivInjurySeverity = Convert.ToInt32(IncidentMain.GetVal(orec["injury_severity_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cCivInjuryCausedBy = Convert.ToInt32(IncidentMain.GetVal(orec["injury_caused_by_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cCivInjuryFloor = Convert.ToInt32(IncidentMain.GetVal(orec["injury_floor"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cCivInjuryLocation = Convert.ToInt32(IncidentMain.GetVal(orec["injury_location_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cCivPatientID = Convert.ToInt32(IncidentMain.GetVal(orec["patient_id"]));
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

		public int GetCivilianCasualtyReport(int lCasualtyID)
		{
			//Retrieve Civilian Casualty Report recordset
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_CivilianCasualty " + lCasualtyID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					//Load Class  Variables
					cCivCasualtyRS = orec;
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

		public int AddCivilianCasualty()
		{
			//Add New Civilian Casualty Report Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;
			string SqlString = "";

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spInsert_CivilianCasualty " + cCivIncidentID.ToString() + ",";
				if (cCivInjurySeverity == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cCivInjurySeverity.ToString() + ",";
				}
				if (cCivInjuryCausedBy == 0)
				{
					SqlString = SqlString + "NULL," + cCivInjuryFloor.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cCivInjuryCausedBy.ToString() + "," + cCivInjuryFloor.ToString() + ",";
				}
				if (cCivInjuryLocation == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cCivInjuryLocation.ToString() + ",";
				}
				if (cCivPatientID == 0)
				{
					SqlString = SqlString + "NULL";
				}
				else
				{
					SqlString = SqlString + cCivPatientID.ToString();
				}
				ocmd.CommandText = SqlString;
				ocmd.ExecuteNonQuery();
				ocmd.CommandText = "spSelect_NewCivilianCasualtyID";
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (GetCivilianCasualty(Convert.ToInt32(orec[0])) != 0)
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

		public int UpdateCivilianCasualty()
		{
			//Update Civilian Casualty Report Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spUpdate_CivilianCasualty " + cCivCasualtyID.ToString() + "," + cCivIncidentID.ToString() + ",";
				if (cCivInjurySeverity == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cCivInjurySeverity.ToString() + ",";
				}
				if (cCivInjuryCausedBy == 0)
				{
					SqlString = SqlString + "NULL," + cCivInjuryFloor.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cCivInjuryCausedBy.ToString() + "," + cCivInjuryFloor.ToString() + ",";
				}
				if (cCivInjuryLocation == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cCivInjuryLocation.ToString() + ",";
				}
				if (cCivPatientID == 0)
				{
					SqlString = SqlString + "NULL";
				}
				else
				{
					SqlString = SqlString + cCivPatientID.ToString();
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

		//** Civilian Casualty Sub Tables
		//Civilian Human Factor

		public int GetCivHumanFactor(int lCasualtyID)
		{
			//Get CivHumanFactor Record

			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{


				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_CivilianHumanFactor " + lCasualtyID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cCHCivilHumanFactor = orec;
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

		public int GetCivHumanFactorReport(int lCasualtyID)
		{
			//Get CivHumanFactor Record

			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{


				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_CivilianHumanFactor " + lCasualtyID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cCHCivilHumanFactor = orec;
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


		public int AddCivHumanFactor()
		{
			//Add CivHumanFactor Record
			//All field reference  Class Private Variables
			//Which must be set prior to calling this function

			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;
				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spInsert_CivilianHumanFactor";

                ocmd.ExecuteNonQuery(new object[] { cCFCasualtyID, cCHHumanFactor });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}


		public int DeleteCivHumanFactor(ref int lCasualtyID)
		{
			//Delete all Civilian Human Factor Records for Current Civilian Casualty
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
				ocmd.CommandText = "spDelete_CivilianHumanFactor";
				ocmd.ExecuteNonQuery(new object[] { lCasualtyID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}


		public int GetCivContribFactor(int lCasualtyID)
		{
			//Get CivHumanFactor Record

			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{


				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_CivilianContributingFactor " + lCasualtyID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cCFCivilContribFactor = orec;
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

		public int GetCivContribFactorReport(int lCasualtyID)
		{
			//Get CivHumanFactor Reporting Record

			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{


				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_CivilianContribFactor " + lCasualtyID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cCFCivilContribFactor = orec;
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


		public int AddCivContributingFactor()
		{
			//Add CivHumanFactor Record
			//All field reference  Class Private Variables
			//Which must be set prior to calling this function

			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;
				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spInsert_CivilianContributingFactor";
				ocmd.ExecuteNonQuery(new object[] { cCFCasualtyID, cCFContributingFactor });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteCivContributingFactor(ref int lCasualtyID)
		{
			//Delete all Civilian Contributing Factor Records for Current Civilian Casualty
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
				ocmd.CommandText = "spDelete_CivilianContributingFactor";
				ocmd.ExecuteNonQuery(new object[] { lCasualtyID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public string GetFSCasualtyName(int lCasualtyID)
		{
			//Get FS Casualty Employee Name

			string result = "";
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{


				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_FSCasualtyName " + lCasualtyID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					return IncidentMain.Clean(orec["name_full"]);
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

		public string UniqueID { get; set; }

		public UpgradeHelpers.Interfaces.IViewManager ViewManager { get; set; }

		public UpgradeHelpers.Interfaces.IIocContainer Container { get; set; }

	}
}