using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident
{

	public class clsHazmat
		: UpgradeHelpers.Interfaces.IDependentModel, UpgradeHelpers.Interfaces.ICreatesObjects, UpgradeHelpers
		.Interfaces.IInteractsWithView, UpgradeHelpers.Interfaces.IInitializableCommon, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(clsHazmat));
		}

		void UpgradeHelpers.Interfaces.IInitializableCommon.Common()
		{
			_cPhysicalStateCode = null;
			_cReleasedIntoCode = null;
			_cFireServiceMaterialCode = null;
			_cOutsideResourceCode = null;
			_cResourceUseCode = null;
			_cDispositionOfReleaseCode = null;
			_cCauseOfReleaseCode = null;
			_cStreetClassCode = null;
			_cHazmatActionTaken = null;
			cATHazmatID = 0;
			cUnitAction = 0;
			_cHazmatDLActionTaken = null;
			cATDLHazmatID = 0;
			cDLUnitAction = 0;
			_cChemicals = null;
			cChemicalID = 0;
			cCameoID = "";
			cNOAANO = "";
			cFormula = "";
			cUNNO = "";
			cHazlab = "";
			cChemicalName = "";
			cChemPref = 0;
			cCASNumber = "";
			cCommonName = "";
			cFlagCommon = 0;
			_cHazmatChemicalDetail = null;
			cChemicalDetailID = 0;
			cCDHazmatID = 0;
			cCDChemicalID = 0;
			cContainerTypeCode = 0;
			cContainerCapacity = 0;
			cContainerCapacityUnits = 0;
			cAmountReleased = 0;
			cAmountReleasedUnits = 0;
			cPhysicalStateStored = 0;
			cPhysicalStateReleased = 0;
			cPrimaryReleasedInto = 0;
			cSecondaryReleasedInto = 0;
			_cHazmatContributingFactorRS = null;
			cCFHazmatID = 0;
			cHazmatContributingFactor = 0;
			_cHazmatContributingFactorCode = null;
			_cHazmatDrugLab = null;
			cDLHazmatID = 0;
			cDLIncidentID = 0;
			cDrugLabType = 0;
			cDLHazmatIDSource = 0;
			cDLDispositionOfRelease = 0;
			cDLFlagRelease = 0;
			_cHazmatDrugLabCode = null;
			_cHazmatEquipmentInvolvedRS = null;
			cEIHazmatID = 0;
			cHazmatEquipmentInvolved = 0;
			_cHazmatEquipmentInvolvedCode = null;
			_cHazmatFireServiceMaterialsUsedRS = null;
			cMUHazmatID = 0;
			cFireServiceMaterial = 0;
			cMaterialQuantity = 0;
			_cHazmatIDSourceCode = null;
			_cHazmatMitigatingFactorRS = null;
			cMFHazmatID = 0;
			cHazmatMitigatingFactor = 0;
			_cHazmatMitigatingFactorCode = null;
			_cHazmatOutsideResourceRS = null;
			cORHazmatID = 0;
			cOutsideResource = 0;
			cResourceUse = 0;
			_cHazmatDLOutsideResourceRS = null;
			cORDLHazmatID = 0;
			cDLOutsideResource = 0;
			cDLResourceUse = 0;
			_cHazmatRelease = null;
			cHazmatID = 0;
			cIncidentID = 0;
			cIncidentTypeCode = 0;
			cHazmatIDSource = 0;
			cDispositionOfRelease = 0;
			cCauseOfRelease = 0;
			cAreaEffected = 0;
			cEffectedAreaUnit = 0;
			cAreaEvacuated = 0;
			cEvacuatedAreaUnit = 0;
			cPopulationDensity = 0;
			cBuildingsEvacuated = 0;
			cPeopleEvacuated = 0;
			cAreaOfOrigin = 0;
			cOccuredFirst = 0;
			cStreetClass = 0;
			cReleaseFloor = 0;
			cPropertyUse = 0;
		}

		//********************************************************
		//**    Hazmat Class                                    **
		//********************************************************
		//**        Methods                                     **
		//**------------------------------------------------------
		//**
		//**                                                    **
		//**
		//********************************************************

		//********************************************************
		//**             Private Class Variables                **
		//********************************************************
		//!!! Tables Located in Other Class Modules!!!
		// Hazmat Action Taken  -?UnitActionCode(clsUnit) or ActionTaken(clsCommon)
		// ContainerType, CapacityUnits, ReleasedUnits, Area Units,Population Density -
		//   *** All in clsCommonCodes  ****
		// Property Use Class, PropertyUseCode, Area of Origin
		//   *** All in clsFireCodes    ****
		// IncidentTypeCode - clsFireCodes, clsCommonCodes

		//Misc Code Tables
		public virtual ADORecordSetHelper _cPhysicalStateCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cPhysicalStateCode
		{
			get
			{
				if (_cPhysicalStateCode == null)
				{
					_cPhysicalStateCode = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cPhysicalStateCode;
			}
			set
			{
				_cPhysicalStateCode = value;
			}
		}

		public virtual ADORecordSetHelper _cReleasedIntoCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cReleasedIntoCode
		{
			get
			{
				if (_cReleasedIntoCode == null)
				{
					_cReleasedIntoCode = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cReleasedIntoCode;
			}
			set
			{
				_cReleasedIntoCode = value;
			}
		}

		public virtual ADORecordSetHelper _cFireServiceMaterialCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cFireServiceMaterialCode
		{
			get
			{
				if (_cFireServiceMaterialCode == null)
				{
					_cFireServiceMaterialCode = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cFireServiceMaterialCode;
			}
			set
			{
				_cFireServiceMaterialCode = value;
			}
		}

		public virtual ADORecordSetHelper _cOutsideResourceCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cOutsideResourceCode
		{
			get
			{
				if (_cOutsideResourceCode == null)
				{
					_cOutsideResourceCode = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cOutsideResourceCode;
			}
			set
			{
				_cOutsideResourceCode = value;
			}
		}

		public virtual ADORecordSetHelper _cResourceUseCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cResourceUseCode
		{
			get
			{
				if (_cResourceUseCode == null)
				{
					_cResourceUseCode = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cResourceUseCode;
			}
			set
			{
				_cResourceUseCode = value;
			}
		}

		public virtual ADORecordSetHelper _cDispositionOfReleaseCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cDispositionOfReleaseCode
		{
			get
			{
				if (_cDispositionOfReleaseCode == null)
				{
					_cDispositionOfReleaseCode = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cDispositionOfReleaseCode;
			}
			set
			{
				_cDispositionOfReleaseCode = value;
			}
		}

		public virtual ADORecordSetHelper _cCauseOfReleaseCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cCauseOfReleaseCode
		{
			get
			{
				if (_cCauseOfReleaseCode == null)
				{
					_cCauseOfReleaseCode = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cCauseOfReleaseCode;
			}
			set
			{
				_cCauseOfReleaseCode = value;
			}
		}

		public virtual ADORecordSetHelper _cStreetClassCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cStreetClassCode
		{
			get
			{
				if (_cStreetClassCode == null)
				{
					_cStreetClassCode = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cStreetClassCode;
			}
			set
			{
				_cStreetClassCode = value;
			}
		}


		//HazmatActionTaken
		public virtual ADORecordSetHelper _cHazmatActionTaken { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cHazmatActionTaken
		{
			get
			{
				if (_cHazmatActionTaken == null)
				{
					_cHazmatActionTaken = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cHazmatActionTaken;
			}
			set
			{
				_cHazmatActionTaken = value;
			}
		}

		public virtual int cATHazmatID { get; set; }

		public virtual int cUnitAction { get; set; }

		//HazmatDrugLabActionTaken
		public virtual ADORecordSetHelper _cHazmatDLActionTaken { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cHazmatDLActionTaken
		{
			get
			{
				if (_cHazmatDLActionTaken == null)
				{
					_cHazmatDLActionTaken = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cHazmatDLActionTaken;
			}
			set
			{
				_cHazmatDLActionTaken = value;
			}
		}

		public virtual int cATDLHazmatID { get; set; }

		public virtual int cDLUnitAction { get; set; }

		//Chemicals
		public virtual ADORecordSetHelper _cChemicals { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cChemicals
		{
			get
			{
				if (_cChemicals == null)
				{
					_cChemicals = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cChemicals;
			}
			set
			{
				_cChemicals = value;
			}
		}

		public virtual int cChemicalID { get; set; }

		public virtual string cCameoID { get; set; }

		public virtual string cNOAANO { get; set; }

		public virtual string cFormula { get; set; }

		public virtual string cUNNO { get; set; }

		public virtual string cHazlab { get; set; }

		public virtual string cChemicalName { get; set; }

		public virtual byte cChemPref { get; set; }

		public virtual string cCASNumber { get; set; }

		public virtual string cCommonName { get; set; }

		public virtual byte cFlagCommon { get; set; }

		//HazmatChemicalDetail
		public virtual ADORecordSetHelper _cHazmatChemicalDetail { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cHazmatChemicalDetail
		{
			get
			{
				if (_cHazmatChemicalDetail == null)
				{
					_cHazmatChemicalDetail = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cHazmatChemicalDetail;
			}
			set
			{
				_cHazmatChemicalDetail = value;
			}
		}

		public virtual int cChemicalDetailID { get; set; }

		public virtual int cCDHazmatID { get; set; }

		public virtual int cCDChemicalID { get; set; }

		public virtual int cContainerTypeCode { get; set; }

		public virtual int cContainerCapacity { get; set; }

		public virtual int cContainerCapacityUnits { get; set; }

		public virtual int cAmountReleased { get; set; }

		public virtual int cAmountReleasedUnits { get; set; }

		public virtual int cPhysicalStateStored { get; set; }

		public virtual int cPhysicalStateReleased { get; set; }

		public virtual int cPrimaryReleasedInto { get; set; }

		public virtual int cSecondaryReleasedInto { get; set; }

		//HazmatContributingFactor
		public virtual ADORecordSetHelper _cHazmatContributingFactorRS { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cHazmatContributingFactorRS
		{
			get
			{
				if (_cHazmatContributingFactorRS == null)
				{
					_cHazmatContributingFactorRS = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cHazmatContributingFactorRS;
			}
			set
			{
				_cHazmatContributingFactorRS = value;
			}
		}

		public virtual int cCFHazmatID { get; set; }

		public virtual int cHazmatContributingFactor { get; set; }

		//HazmatContributingFactorCode
		public virtual ADORecordSetHelper _cHazmatContributingFactorCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cHazmatContributingFactorCode
		{
			get
			{
				if (_cHazmatContributingFactorCode == null)
				{
					_cHazmatContributingFactorCode = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cHazmatContributingFactorCode;
			}
			set
			{
				_cHazmatContributingFactorCode = value;
			}
		}


		//HazmatDrugLab
		public virtual ADORecordSetHelper _cHazmatDrugLab { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cHazmatDrugLab
		{
			get
			{
				if (_cHazmatDrugLab == null)
				{
					_cHazmatDrugLab = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cHazmatDrugLab;
			}
			set
			{
				_cHazmatDrugLab = value;
			}
		}

		public virtual int cDLHazmatID { get; set; }

		public virtual int cDLIncidentID { get; set; }

		public virtual int cDrugLabType { get; set; }

		public virtual int cDLHazmatIDSource { get; set; }

		public virtual int cDLDispositionOfRelease { get; set; }

		public virtual byte cDLFlagRelease { get; set; }

		//HazmatDrugLabCode
		public virtual ADORecordSetHelper _cHazmatDrugLabCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cHazmatDrugLabCode
		{
			get
			{
				if (_cHazmatDrugLabCode == null)
				{
					_cHazmatDrugLabCode = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cHazmatDrugLabCode;
			}
			set
			{
				_cHazmatDrugLabCode = value;
			}
		}


		//HazmatEquipmentInvolved
		public virtual ADORecordSetHelper _cHazmatEquipmentInvolvedRS { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cHazmatEquipmentInvolvedRS
		{
			get
			{
				if (_cHazmatEquipmentInvolvedRS == null)
				{
					_cHazmatEquipmentInvolvedRS = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cHazmatEquipmentInvolvedRS;
			}
			set
			{
				_cHazmatEquipmentInvolvedRS = value;
			}
		}

		public virtual int cEIHazmatID { get; set; }

		public virtual int cHazmatEquipmentInvolved { get; set; }

		//HazmatEquipmentInvolvedCode
		public virtual ADORecordSetHelper _cHazmatEquipmentInvolvedCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cHazmatEquipmentInvolvedCode
		{
			get
			{
				if (_cHazmatEquipmentInvolvedCode == null)
				{
					_cHazmatEquipmentInvolvedCode = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cHazmatEquipmentInvolvedCode;
			}
			set
			{
				_cHazmatEquipmentInvolvedCode = value;
			}
		}


		//HazmatFireServiceMaterialsUsed
		public virtual ADORecordSetHelper _cHazmatFireServiceMaterialsUsedRS { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cHazmatFireServiceMaterialsUsedRS
		{
			get
			{
				if (_cHazmatFireServiceMaterialsUsedRS == null)
				{
					_cHazmatFireServiceMaterialsUsedRS = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cHazmatFireServiceMaterialsUsedRS;
			}
			set
			{
				_cHazmatFireServiceMaterialsUsedRS = value;
			}
		}

		public virtual int cMUHazmatID { get; set; }

		public virtual int cFireServiceMaterial { get; set; }

		public virtual int cMaterialQuantity { get; set; }

		//HazmatIDSourceCode
		public virtual ADORecordSetHelper _cHazmatIDSourceCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cHazmatIDSourceCode
		{
			get
			{
				if (_cHazmatIDSourceCode == null)
				{
					_cHazmatIDSourceCode = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cHazmatIDSourceCode;
			}
			set
			{
				_cHazmatIDSourceCode = value;
			}
		}


		//HazmatMitigatingFactor
		public virtual ADORecordSetHelper _cHazmatMitigatingFactorRS { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cHazmatMitigatingFactorRS
		{
			get
			{
				if (_cHazmatMitigatingFactorRS == null)
				{
					_cHazmatMitigatingFactorRS = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cHazmatMitigatingFactorRS;
			}
			set
			{
				_cHazmatMitigatingFactorRS = value;
			}
		}

		public virtual int cMFHazmatID { get; set; }

		public virtual int cHazmatMitigatingFactor { get; set; }

		//HazmatMitigatingFactorCode
		public virtual ADORecordSetHelper _cHazmatMitigatingFactorCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cHazmatMitigatingFactorCode
		{
			get
			{
				if (_cHazmatMitigatingFactorCode == null)
				{
					_cHazmatMitigatingFactorCode = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cHazmatMitigatingFactorCode;
			}
			set
			{
				_cHazmatMitigatingFactorCode = value;
			}
		}


		//HazmatOutsideResource
		public virtual ADORecordSetHelper _cHazmatOutsideResourceRS { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cHazmatOutsideResourceRS
		{
			get
			{
				if (_cHazmatOutsideResourceRS == null)
				{
					_cHazmatOutsideResourceRS = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cHazmatOutsideResourceRS;
			}
			set
			{
				_cHazmatOutsideResourceRS = value;
			}
		}

		public virtual int cORHazmatID { get; set; }

		public virtual int cOutsideResource { get; set; }

		public virtual int cResourceUse { get; set; }

		//HazmatDrugLabOutsideResource
		public virtual ADORecordSetHelper _cHazmatDLOutsideResourceRS { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cHazmatDLOutsideResourceRS
		{
			get
			{
				if (_cHazmatDLOutsideResourceRS == null)
				{
					_cHazmatDLOutsideResourceRS = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cHazmatDLOutsideResourceRS;
			}
			set
			{
				_cHazmatDLOutsideResourceRS = value;
			}
		}

		public virtual int cORDLHazmatID { get; set; }

		public virtual int cDLOutsideResource { get; set; }

		public virtual int cDLResourceUse { get; set; }

		//HazmatRelease
		public virtual ADORecordSetHelper _cHazmatRelease { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cHazmatRelease
		{
			get
			{
				if (_cHazmatRelease == null)
				{
					_cHazmatRelease = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cHazmatRelease;
			}
			set
			{
				_cHazmatRelease = value;
			}
		}

		public virtual int cHazmatID { get; set; }

		public virtual int cIncidentID { get; set; }

		public virtual int cIncidentTypeCode { get; set; }

		public virtual int cHazmatIDSource { get; set; }

		public virtual int cDispositionOfRelease { get; set; }

		public virtual int cCauseOfRelease { get; set; }

		public virtual int cAreaEffected { get; set; }

		public virtual int cEffectedAreaUnit { get; set; }

		public virtual int cAreaEvacuated { get; set; }

		public virtual int cEvacuatedAreaUnit { get; set; }

		public virtual int cPopulationDensity { get; set; }

		public virtual int cBuildingsEvacuated { get; set; }

		public virtual int cPeopleEvacuated { get; set; }

		public virtual int cAreaOfOrigin { get; set; }

		public virtual int cOccuredFirst { get; set; }

		public virtual int cStreetClass { get; set; }

		public virtual int cReleaseFloor { get; set; }

		public virtual int cPropertyUse { get; set; }

		//***************************************************
		//**         Class Public Properties               **
		//***************************************************
		// PhysicalStateStored
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper PhysicalStateCode
		{
			get
			{
				return cPhysicalStateCode;
			}
			set
			{
				cPhysicalStateCode = value;
			}
		}


		// ReleasedInto
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper ReleasedIntoCode
		{
			get
			{
				return cReleasedIntoCode;
			}
			set
			{
				cReleasedIntoCode = value;
			}
		}


		// FireServiceMaterial
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper FireServiceMaterialCode
		{
			get
			{
				return cFireServiceMaterialCode;
			}
			set
			{
				cFireServiceMaterialCode = value;
			}
		}


		// OutsideResourceCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper OutsideResourceCode
		{
			get
			{
				return cOutsideResourceCode;
			}
			set
			{
				cOutsideResourceCode = value;
			}
		}


		// ResourceUseCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper ResourceUseCode
		{
			get
			{
				return cResourceUseCode;
			}
			set
			{
				cResourceUseCode = value;
			}
		}


		// DispositionOfReleaseCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper DispositionOfReleaseCode
		{
			get
			{
				return cDispositionOfReleaseCode;
			}
			set
			{
				cDispositionOfReleaseCode = value;
			}
		}


		// CauseOfReleaseCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper CauseOfReleaseCode
		{
			get
			{
				return cCauseOfReleaseCode;
			}
			set
			{
				cCauseOfReleaseCode = value;
			}
		}


		// StreetClassCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper StreetClassCode
		{
			get
			{
				return cStreetClassCode;
			}
			set
			{
				cStreetClassCode = value;
			}
		}


		//HazmatActionTaken
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper HazmatActionTaken
		{
			get
			{
				return cHazmatActionTaken;
			}
			set
			{
				cHazmatActionTaken = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ATHazmatID
		{
			get
			{
				return cATHazmatID;
			}
			set
			{
				cATHazmatID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int UnitAction
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


		//HazmatDrugLabActionTaken
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper HazmatDLActionTaken
		{
			get
			{
				return cHazmatDLActionTaken;
			}
			set
			{
				cHazmatDLActionTaken = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ATDLHazmatID
		{
			get
			{
				return cATDLHazmatID;
			}
			set
			{
				cATDLHazmatID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int DLUnitAction
		{
			get
			{
				return cDLUnitAction;
			}
			set
			{
				cDLUnitAction = value;
			}
		}


		//Chemicals
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper Chemicals
		{
			get
			{
				return cChemicals;
			}
			set
			{
				cChemicals = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ChemicalID
		{
			get
			{
				return cChemicalID;
			}
			set
			{
				cChemicalID = value;
			}
		}


		//HazmatChemicalDetail
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper HazmatChemicalDetail
		{
			get
			{
				return cHazmatChemicalDetail;
			}
			set
			{
				cHazmatChemicalDetail = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ChemicalDetailID
		{
			get
			{
				return cChemicalDetailID;
			}
			set
			{
				cChemicalDetailID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int CDHazmatID
		{
			get
			{
				return cCDHazmatID;
			}
			set
			{
				cCDHazmatID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int CDChemicalID
		{
			get
			{
				return cCDChemicalID;
			}
			set
			{
				cCDChemicalID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ContainerTypeCode
		{
			get
			{
				return cContainerTypeCode;
			}
			set
			{
				cContainerTypeCode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ContainerCapacity
		{
			get
			{
				return cContainerCapacity;
			}
			set
			{
				cContainerCapacity = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ContainerCapacityUnits
		{
			get
			{
				return cContainerCapacityUnits;
			}
			set
			{
				cContainerCapacityUnits = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int AmountReleased
		{
			get
			{
				return cAmountReleased;
			}
			set
			{
				cAmountReleased = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int AmountReleasedUnits
		{
			get
			{
				return cAmountReleasedUnits;
			}
			set
			{
				cAmountReleasedUnits = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int PhysicalStateStored
		{
			get
			{
				return cPhysicalStateStored;
			}
			set
			{
				cPhysicalStateStored = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int PhysicalStateReleased
		{
			get
			{
				return cPhysicalStateReleased;
			}
			set
			{
				cPhysicalStateReleased = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int PrimaryReleasedInto
		{
			get
			{
				return cPrimaryReleasedInto;
			}
			set
			{
				cPrimaryReleasedInto = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int SecondaryReleasedInto
		{
			get
			{
				return cSecondaryReleasedInto;
			}
			set
			{
				cSecondaryReleasedInto = value;
			}
		}


		//HazmatContributingFactor
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper HazmatContributingFactorRS
		{
			get
			{
				return cHazmatContributingFactorRS;
			}
			set
			{
				cHazmatContributingFactorRS = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int CFHazmatID
		{
			get
			{
				return cCFHazmatID;
			}
			set
			{
				cCFHazmatID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int HazmatContributingFactor
		{
			get
			{
				return cHazmatContributingFactor;
			}
			set
			{
				cHazmatContributingFactor = value;
			}
		}


		//HazmatContributingFactorCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper HazmatContributingFactorCode
		{
			get
			{
				return cHazmatContributingFactorCode;
			}
			set
			{
				cHazmatContributingFactorCode = value;
			}
		}


		//HazmatDrugLab
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper HazmatDrugLab
		{
			get
			{
				return cHazmatDrugLab;
			}
			set
			{
				cHazmatDrugLab = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int DLHazmatID
		{
			get
			{
				return cDLHazmatID;
			}
			set
			{
				cDLHazmatID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int DLIncidentID
		{
			get
			{
				return cDLIncidentID;
			}
			set
			{
				cDLIncidentID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int DrugLabType
		{
			get
			{
				return cDrugLabType;
			}
			set
			{
				cDrugLabType = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int DLHazmatIDSource
		{
			get
			{
				return cDLHazmatIDSource;
			}
			set
			{
				cDLHazmatIDSource = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]

		public int DLDispositionOfRelease
		{
			get
			{
				return cDLDispositionOfRelease;
			}
			set
			{
				cDLDispositionOfRelease = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte DLFlagRelease
		{
			get
			{
				return cDLFlagRelease;
			}
			set
			{
				cDLFlagRelease = value;
			}
		}


		//HazmatDrugLabCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper HazmatDrugLabCode
		{
			get
			{
				return cHazmatDrugLabCode;
			}
			set
			{
				cHazmatDrugLabCode = value;
			}
		}


		//HazmatEquipmentInvolved
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper HazmatEquipmentInvolvedRS
		{
			get
			{
				return cHazmatEquipmentInvolvedRS;
			}
			set
			{
				cHazmatEquipmentInvolvedRS = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int EIHazmatID
		{
			get
			{
				return cEIHazmatID;
			}
			set
			{
				cEIHazmatID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int HazmatEquipmentInvolved
		{
			get
			{
				return cHazmatEquipmentInvolved;
			}
			set
			{
				cHazmatEquipmentInvolved = value;
			}
		}


		//HazmatEquipmentInvolvedCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper HazmatEquipmentInvolvedCode
		{
			get
			{
				return cHazmatEquipmentInvolvedCode;
			}
			set
			{
				cHazmatEquipmentInvolvedCode = value;
			}
		}


		//HazmatFireServiceMaterialsUsed
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper HazmatFireServiceMaterialsUsedRS
		{
			get
			{
				return cHazmatFireServiceMaterialsUsedRS;
			}
			set
			{
				cHazmatFireServiceMaterialsUsedRS = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int MUHazmatID
		{
			get
			{
				return cMUHazmatID;
			}
			set
			{
				cMUHazmatID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int FireServiceMaterial
		{
			get
			{
				return cFireServiceMaterial;
			}
			set
			{
				cFireServiceMaterial = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int MaterialQuantity
		{
			get
			{
				return cMaterialQuantity;
			}
			set
			{
				cMaterialQuantity = value;
			}
		}


		//HazmatIDSourceCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper HazmatIDSourceCode
		{
			get
			{
				return cHazmatIDSourceCode;
			}
			set
			{
				cHazmatIDSourceCode = value;
			}
		}


		//HazmatMitigatingFactor
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper HazmatMitigatingFactorRS
		{
			get
			{
				return cHazmatMitigatingFactorRS;
			}
			set
			{
				cHazmatMitigatingFactorRS = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int MFHazmatID
		{
			get
			{
				return cMFHazmatID;
			}
			set
			{
				cMFHazmatID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int HazmatMitigatingFactor
		{
			get
			{
				return cHazmatMitigatingFactor;
			}
			set
			{
				cHazmatMitigatingFactor = value;
			}
		}


		//HazmatMitigatingFactorCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper HazmatMitigatingFactorCode
		{
			get
			{
				return cHazmatMitigatingFactorCode;
			}
			set
			{
				cHazmatMitigatingFactorCode = value;
			}
		}


		//HazmatOutsideResource
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper HazmatOutsideResourceRS
		{
			get
			{
				return cHazmatOutsideResourceRS;
			}
			set
			{
				cHazmatOutsideResourceRS = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ORHazmatID
		{
			get
			{
				return cORHazmatID;
			}
			set
			{
				cORHazmatID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int OutsideResource
		{
			get
			{
				return cOutsideResource;
			}
			set
			{
				cOutsideResource = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ResourceUse
		{
			get
			{
				return cResourceUse;
			}
			set
			{
				cResourceUse = value;
			}
		}


		//HazmatDrugLabOutsideResource
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper HazmatDLOutsideResourceRS
		{
			get
			{
				return cHazmatDLOutsideResourceRS;
			}
			set
			{
				cHazmatDLOutsideResourceRS = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ORDLHazmatID
		{
			get
			{
				return cORDLHazmatID;
			}
			set
			{
				cORDLHazmatID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int DLOutsideResource
		{
			get
			{
				return cDLOutsideResource;
			}
			set
			{
				cDLOutsideResource = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int DLResourceUse
		{
			get
			{
				return cDLResourceUse;
			}
			set
			{
				cDLResourceUse = value;
			}
		}


		//HazmatRelease
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper HazmatRelease
		{
			get
			{
				return cHazmatRelease;
			}
			set
			{
				cHazmatRelease = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int HazmatID
		{
			get
			{
				return cHazmatID;
			}
			set
			{
				cHazmatID = value;
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


		public int IncidentTypeCode
		{
			get
			{
				return cIncidentTypeCode;
			}
			set
			{
				cIncidentTypeCode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int HazmatIDSource
		{
			get
			{
				return cHazmatIDSource;
			}
			set
			{
				cHazmatIDSource = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int DispositionOfRelease
		{
			get
			{
				return cDispositionOfRelease;
			}
			set
			{
				cDispositionOfRelease = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int CauseOfRelease
		{
			get
			{
				return cCauseOfRelease;
			}
			set
			{
				cCauseOfRelease = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int AreaEffected
		{
			get
			{
				return cAreaEffected;
			}
			set
			{
				cAreaEffected = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int EffectedAreaUnit
		{
			get
			{
				return cEffectedAreaUnit;
			}
			set
			{
				cEffectedAreaUnit = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int AreaEvacuated
		{
			get
			{
				return cAreaEvacuated;
			}
			set
			{
				cAreaEvacuated = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int EvacuatedAreaUnit
		{
			get
			{
				return cEvacuatedAreaUnit;
			}
			set
			{
				cEvacuatedAreaUnit = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int PopulationDensity
		{
			get
			{
				return cPopulationDensity;
			}
			set
			{
				cPopulationDensity = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int BuildingsEvacuated
		{
			get
			{
				return cBuildingsEvacuated;
			}
			set
			{
				cBuildingsEvacuated = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int PeopleEvacuated
		{
			get
			{
				return cPeopleEvacuated;
			}
			set
			{
				cPeopleEvacuated = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int AreaOfOrigin
		{
			get
			{
				return cAreaOfOrigin;
			}
			set
			{
				cAreaOfOrigin = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int OccuredFirst
		{
			get
			{
				return cOccuredFirst;
			}
			set
			{
				cOccuredFirst = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int StreetClass
		{
			get
			{
				return cStreetClass;
			}
			set
			{
				cStreetClass = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ReleaseFloor
		{
			get
			{
				return cReleaseFloor;
			}
			set
			{
				cReleaseFloor = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int PropertyUse
		{
			get
			{
				return cPropertyUse;
			}
			set
			{
				cPropertyUse = value;
			}
		}


		//**********************************************
		//**         Public Class Methods             **
		//**********************************************
		//******   Code Tables                        **
		//----------------------------------------------

		public void GetChemicals()
		{
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_ChemicalsList";
				orec = ADORecordSetHelper.Open(ocmd, "");
				cChemicals = orec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}


		public void GetCommonChemicals()
		{
			//Get List of Common Chemicals
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_CommonChemicalsList";
				orec = ADORecordSetHelper.Open(ocmd, "");
				cChemicals = orec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetFireServiceMaterialCode()
		{
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_FireServiceMaterialCode";
				orec = ADORecordSetHelper.Open(ocmd, "");
				cFireServiceMaterialCode = orec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetPhysicalStateCode()
		{
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_ChemicalPhysicalStateCode";
				orec = ADORecordSetHelper.Open(ocmd, "");
				cPhysicalStateCode = orec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetReleasedIntoCode()
		{
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_ChemicalReleasedIntoCode";
				orec = ADORecordSetHelper.Open(ocmd, "");
				cReleasedIntoCode = orec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetOutsideResourceCode()
		{
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_OutsideResourceCode";
				orec = ADORecordSetHelper.Open(ocmd, "");
				cOutsideResourceCode = orec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetResourceUseCode()
		{
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_ResourceUseCode";
				orec = ADORecordSetHelper.Open(ocmd, "");
				cResourceUseCode = orec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetDispositionOfReleaseCode()
		{
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_DispOfHazmatReleaseCode";
				orec = ADORecordSetHelper.Open(ocmd, "");
				cDispositionOfReleaseCode = orec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetCauseOfReleaseCode()
		{
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_CauseOfReleaseCode";
				orec = ADORecordSetHelper.Open(ocmd, "");
				cCauseOfReleaseCode = orec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetStreetClassCode()
		{
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_StreetClassCode";
				orec = ADORecordSetHelper.Open(ocmd, "");
				cStreetClassCode = orec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}
		//HazmatContributingFactorCode

		public void GetHazmatContributingFactorCode()
		{
			//** HazmatContributingFactorCode **

			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_HazmatContributingFactorCode";
				orec = ADORecordSetHelper.Open(ocmd, "");
				cHazmatContributingFactorCode = orec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		//HazmatDrugLabCode

		public void GetHazmatDrugLabCode()
		{
			//** HazmatDrugLabCode **

			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_HazmatDrugLabCode";
				orec = ADORecordSetHelper.Open(ocmd, "");
				cHazmatDrugLabCode = orec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		//HazmatEquipmentInvolvedCode

		public void GetHazmatEquipmentInvolvedCode()
		{
			//** HazmatEquipmentInvolvedCode **

			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_HazmatEquipmentInvolvedCode";
				orec = ADORecordSetHelper.Open(ocmd, "");
				cHazmatEquipmentInvolvedCode = orec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		//HazmatIDSourceCode

		public void GetHazmatIDSourceCode()
		{
			//** HazmatIDSourceCode **

			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_HazmatIDSourceCode";
				orec = ADORecordSetHelper.Open(ocmd, "");
				cHazmatIDSourceCode = orec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		//HazmatMitigatingFactorCode

		public void GetHazmatMitigatingFactorCode()
		{
			//** HazmatMitigatingFactorCode **

			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_HazmatMitigatingFactorCode";
				orec = ADORecordSetHelper.Open(ocmd, "");
				cHazmatMitigatingFactorCode = orec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		//************* Data Tables **********************

		//HazmatRelease --**********************************************

		public int GetHazmatRelease(int lHazmatID)
		{
			//Retrieve HazmatRelease record and Load date into
			//HazmatRelease class variables
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_HazmatRelease " + lHazmatID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					//Load Class  Variables
					cHazmatID = Convert.ToInt32(orec["hazmat_id"]);
					cIncidentID = Convert.ToInt32(orec["incident_id"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cIncidentTypeCode = Convert.ToInt32(IncidentMain.GetVal(orec["incident_type_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cHazmatIDSource = Convert.ToInt32(IncidentMain.GetVal(orec["hazmat_id_source_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cDispositionOfRelease = Convert.ToInt32(IncidentMain.GetVal(orec["disposition_of_release_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cCauseOfRelease = Convert.ToInt32(IncidentMain.GetVal(orec["cause_of_release_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cAreaEffected = Convert.ToInt32(IncidentMain.GetVal(orec["area_effected"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cEffectedAreaUnit = Convert.ToInt32(IncidentMain.GetVal(orec["effected_area_unit_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cAreaEvacuated = Convert.ToInt32(IncidentMain.GetVal(orec["area_evacuated"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cEvacuatedAreaUnit = Convert.ToInt32(IncidentMain.GetVal(orec["evacuated_area_unit_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cPopulationDensity = Convert.ToInt32(IncidentMain.GetVal(orec["population_density_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cBuildingsEvacuated = Convert.ToInt32(IncidentMain.GetVal(orec["buildings_evacuated"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cPeopleEvacuated = Convert.ToInt32(IncidentMain.GetVal(orec["people_evacuated"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cAreaOfOrigin = Convert.ToInt32(IncidentMain.GetVal(orec["area_of_origin_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cOccuredFirst = Convert.ToInt32(IncidentMain.GetVal(orec["occured_first_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cStreetClass = Convert.ToInt32(IncidentMain.GetVal(orec["street_class_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cReleaseFloor = Convert.ToInt32(IncidentMain.GetVal(orec["release_floor"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cPropertyUse = Convert.ToInt32(IncidentMain.GetVal(orec["property_use_code"]));
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

		public int AddHazmatRelease()
		{
			//Add New HazmatRelease Record using values in class variables
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;
			string SqlString = "";

			try
			{

				result = -1;
				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spInsert_HazmatRelease " + cIncidentID.ToString() + ",";
				if (cIncidentTypeCode == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cIncidentTypeCode.ToString() + ",";
				}
				if (cHazmatIDSource == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cHazmatIDSource.ToString() + ",";
				}
				if (cDispositionOfRelease == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cDispositionOfRelease.ToString() + ",";
				}
				if (cCauseOfRelease == 0)
				{
					SqlString = SqlString + "NULL," + cAreaEffected.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cCauseOfRelease.ToString() + "," + cAreaEffected.ToString() + ",";
				}
				if (cEffectedAreaUnit == 0)
				{
					SqlString = SqlString + "NULL," + cAreaEvacuated.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cEffectedAreaUnit.ToString() + "," + cAreaEvacuated.ToString() + ",";
				}
				if (cEvacuatedAreaUnit == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cEvacuatedAreaUnit.ToString() + ",";
				}
				if (cPopulationDensity == 0)
				{
					SqlString = SqlString + "NULL," + cBuildingsEvacuated.ToString() + "," + cPeopleEvacuated.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cPopulationDensity.ToString() + "," + cBuildingsEvacuated.ToString() + "," + cPeopleEvacuated.ToString() + ",";
				}
				if (cAreaOfOrigin == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cAreaOfOrigin.ToString() + ",";
				}
				if (cOccuredFirst == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cOccuredFirst.ToString() + ",";
				}
				if (cStreetClass == 0)
				{
					SqlString = SqlString + "NULL," + cReleaseFloor.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cStreetClass.ToString() + "," + cReleaseFloor.ToString() + ",";
				}
				if (cPropertyUse == 0)
				{
					SqlString = SqlString + "NULL";
				}
				else
				{
					SqlString = SqlString + cPropertyUse.ToString();
				}

				ocmd.CommandText = SqlString;
				ocmd.ExecuteNonQuery();

				if (result != 0)
				{
					ocmd.CommandText = "spSelect_NewHazmatRelease";
					orec = ADORecordSetHelper.Open(ocmd, "");
					if (!orec.EOF)
					{
						result = GetHazmatRelease(Convert.ToInt32(orec[0]));
					}
					else
					{
						result = 0;
					}
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

		public int UpdateHazmatRelease()
		{
			//Update HazmatRelease Record using values in class variables
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;
				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spUpdate_HazmatRelease " + cHazmatID.ToString() + "," + cIncidentID.ToString() + ",";
				if (cIncidentTypeCode == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cIncidentTypeCode.ToString() + ",";
				}
				if (cHazmatIDSource == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cHazmatIDSource.ToString() + ",";
				}
				if (cDispositionOfRelease == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cDispositionOfRelease.ToString() + ",";
				}
				if (cCauseOfRelease == 0)
				{
					SqlString = SqlString + "NULL," + cAreaEffected.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cCauseOfRelease.ToString() + "," + cAreaEffected.ToString() + ",";
				}
				if (cEffectedAreaUnit == 0)
				{
					SqlString = SqlString + "NULL," + cAreaEvacuated.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cEffectedAreaUnit.ToString() + "," + cAreaEvacuated.ToString() + ",";
				}
				if (cEvacuatedAreaUnit == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cEvacuatedAreaUnit.ToString() + ",";
				}
				if (cPopulationDensity == 0)
				{
					SqlString = SqlString + "NULL," + cBuildingsEvacuated.ToString() + "," + cPeopleEvacuated.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cPopulationDensity.ToString() + "," + cBuildingsEvacuated.ToString() + "," + cPeopleEvacuated.ToString() + ",";
				}
				if (cAreaOfOrigin == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cAreaOfOrigin.ToString() + ",";
				}
				if (cOccuredFirst == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cOccuredFirst.ToString() + ",";
				}
				if (cStreetClass == 0)
				{
					SqlString = SqlString + "NULL," + cReleaseFloor.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cStreetClass.ToString() + "," + cReleaseFloor.ToString() + ",";
				}
				if (cPropertyUse == 0)
				{
					SqlString = SqlString + "NULL";
				}
				else
				{
					SqlString = SqlString + cPropertyUse.ToString();
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

		public int DeleteHazmatRelease(ref int lHazmatID)
		{
			//Delete HazmatRelease Record
			//Stored Procedure called also deletes all child records
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spDelete_HazmatRelease";
				ocmd.ExecuteNonQuery(new object[] { lHazmatID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		//HazmatDrugLab --**************************************************

		public int GetHazmatDrugLab(int lHazmatID)
		{
			//Retrieve HazmatDrugLab record and Load date into
			//HazmatDrugLab class variables
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_HazmatDrugLab " + lHazmatID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					//Load Class  Variables
					cDLHazmatID = Convert.ToInt32(orec["hazmat_id"]);
					cDLIncidentID = Convert.ToInt32(orec["incident_id"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cDrugLabType = Convert.ToInt32(IncidentMain.GetVal(orec["drug_lab_type_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cDLHazmatIDSource = Convert.ToInt32(IncidentMain.GetVal(orec["hazmat_id_source_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cDLDispositionOfRelease = Convert.ToInt32(IncidentMain.GetVal(orec["disposition_of_release_code"]));
					if (Convert.ToBoolean(orec["flag_release"]))
					{
						cDLFlagRelease = 1;
					}
					else
					{
						cDLFlagRelease = 0;
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

		public int GetIncidentDrugLab(int lIncidentID)
		{
			//Retrieve HazmatDrugLab record for specified Incident and Load data into
			//HazmatDrugLab class variables
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_IncidentDrugLab " + lIncidentID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					//Load Class  Variables
					cDLHazmatID = Convert.ToInt32(orec["hazmat_id"]);
					cDLIncidentID = Convert.ToInt32(orec["incident_id"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cDrugLabType = Convert.ToInt32(IncidentMain.GetVal(orec["drug_lab_type_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cDLHazmatIDSource = Convert.ToInt32(IncidentMain.GetVal(orec["hazmat_id_source_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cDLDispositionOfRelease = Convert.ToInt32(IncidentMain.GetVal(orec["disposition_of_release_code"]));
					if (Convert.ToBoolean(orec["flag_release"]))
					{
						cDLFlagRelease = 1;
					}
					else
					{
						cDLFlagRelease = 0;
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

		public int AddHazmatDrugLab()
		{
			//Add New HazmatDrugLab Record using values in class variables
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;
			string SqlString = "";

			try
			{

				result = -1;
				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spInsert_HazmatDrugLab " + cDLIncidentID.ToString() + ",";
				if (cDrugLabType == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cDrugLabType.ToString() + ",";
				}
				if (cDLHazmatIDSource == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cDLHazmatIDSource.ToString() + ",";
				}
				if (cDLDispositionOfRelease == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cDLDispositionOfRelease.ToString() + ",";
				}
				if (cDLFlagRelease != 0)
				{
					SqlString = SqlString + "1";
				}
				else
				{
					SqlString = SqlString + "0";
				}
				ocmd.CommandText = SqlString;
				ocmd.ExecuteNonQuery();

				if (result != 0)
				{
					ocmd.CommandText = "spSelect_NewHazmatDrugLab";
					orec = ADORecordSetHelper.Open(ocmd, "");
					if (!orec.EOF)
					{
						result = GetHazmatDrugLab(Convert.ToInt32(orec[0]));
					}
					else
					{
						result = 0;
					}
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

		public int UpdateHazmatDrugLab()
		{
			//Update HazmatDrugLab Record using values in class variables
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;
				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spUpdate_HazmatDrugLab " + cDLHazmatID.ToString() + "," + cDLIncidentID.ToString() + ",";
				if (cDrugLabType == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cDrugLabType.ToString() + ",";
				}
				if (cDLHazmatIDSource == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cDLHazmatIDSource.ToString() + ",";
				}
				if (cDLDispositionOfRelease == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cDLDispositionOfRelease.ToString() + ",";
				}
				if (cDLFlagRelease != 0)
				{
					SqlString = SqlString + "1";
				}
				else
				{
					SqlString = SqlString + "0";
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

		public int DeleteHazmatDrugLab(ref int lHazmatID)
		{
			//Delete HazmatDrugLab Record
			//Stored Procedure called also deletes all child records
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spDelete_HazmatDrugLab";
				ocmd.ExecuteNonQuery(new object[] { lHazmatID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}
		//*** Hazmat Sub Tables --******************************
		//HazmatActionTaken

		public int GetHazmatActionTakenRS(int lHazmatID)
		{
			//Retrieve HazmatActionTakenRS Recordset
			//For Current Hazmat Release
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_HazmatActionTaken " + lHazmatID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cHazmatActionTaken = orec;
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

		public int GetHazmatDrugLabActionTakenRS(int lHazmatID)
		{
			//Retrieve HazmatActionTakenRS Recordset
			//For Current Hazmat Release
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_HazmatDrugLabActionTaken " + lHazmatID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cHazmatDLActionTaken = orec;
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

		public int AddHazmatActionTaken()
		{
			//Add new HazmatActionTaken Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spInsert_HazmatActionTaken";
				ocmd.ExecuteNonQuery(new object[] { cATHazmatID, cUnitAction });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int AddHazmatDrugLabActionTaken()
		{
			//Add new HazmatDrugLabActionTaken Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spInsert_HazmatDrugLabActionTaken";
				ocmd.ExecuteNonQuery(new object[] { cATDLHazmatID, cDLUnitAction });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteHazmatActionTaken(ref int lHazmatID)
		{
			//Delete all HazmatActionTaken Records for Current Hazmat Release Report
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
				ocmd.CommandText = "spDelete_HazmatActionTaken";
				ocmd.ExecuteNonQuery(new object[] { lHazmatID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteHazmatDrugLabActionTaken(ref int lHazmatID)
		{
			//Delete all HazmatActionTaken Records for Current Hazmat Release Report
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
				ocmd.CommandText = "spDelete_HazmatDrugLabActionTaken";
				ocmd.ExecuteNonQuery(new object[] { lHazmatID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}
		//HazmatChemicalDetail

		public int GetHazmatChemicalDetail(int lChemicalDetailID)
		{
			//Retrieve HazmatChemicalDetail Recordset
			//For Current Hazmat Release
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_HazmatChemicalDetail " + lChemicalDetailID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cChemicalDetailID = Convert.ToInt32(orec["chemical_detail_id"]);
					cCDHazmatID = Convert.ToInt32(orec["hazmat_id"]);
					cCDChemicalID = Convert.ToInt32(orec["chemical_id"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cContainerTypeCode = Convert.ToInt32(IncidentMain.GetVal(orec["container_type_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cContainerCapacity = Convert.ToInt32(IncidentMain.GetVal(orec["container_capacity"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cContainerCapacityUnits = Convert.ToInt32(IncidentMain.GetVal(orec["capacity_units"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cAmountReleased = Convert.ToInt32(IncidentMain.GetVal(orec["amount_released"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cAmountReleasedUnits = Convert.ToInt32(IncidentMain.GetVal(orec["amount_released_units"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cPhysicalStateStored = Convert.ToInt32(IncidentMain.GetVal(orec["physical_state_stored"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cPhysicalStateReleased = Convert.ToInt32(IncidentMain.GetVal(orec["physical_state_released"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cPrimaryReleasedInto = Convert.ToInt32(IncidentMain.GetVal(orec["primary_released_into_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cSecondaryReleasedInto = Convert.ToInt32(IncidentMain.GetVal(orec["secondary_released_into_code"]));
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

		public int GetHazmatChemicalDetailRS(int lHazmatID)
		{
			//Retrieve HazmatChemicalDetail Recordset
			//For Current Hazmat Release
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_HazmatChemicalDetailAll " + lHazmatID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cHazmatChemicalDetail = orec;
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

		public int GetChemical(int lChemicalID)
		{
			//Retrieve Hazmat Chemicals Record
			//For Specified Chemical ID
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_Chemical " + lChemicalID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cChemicals = orec;
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

		public int AddHazmatChemicalDetail()
		{
			//Add New HazmatDrugLab Record using values in class variables
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;
			string SqlString = "";

			try
			{

				result = -1;
				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spInsert_HazmatChemicalDetail " + cCDHazmatID.ToString() + "," + cCDChemicalID.ToString() + ",";
				if (cContainerTypeCode == 0)
				{
					SqlString = SqlString + "NULL," + cContainerCapacity.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cContainerTypeCode.ToString() + "," + cContainerCapacity.ToString() + ",";
				}
				if (cContainerCapacityUnits == 0)
				{
					SqlString = SqlString + "NULL," + cAmountReleased.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cContainerCapacityUnits.ToString() + "," + cAmountReleased.ToString() + ",";
				}
				if (cAmountReleasedUnits == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cAmountReleasedUnits.ToString() + ",";
				}
				if (cPhysicalStateStored == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cPhysicalStateStored.ToString() + ",";
				}
				if (cPhysicalStateReleased == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cPhysicalStateReleased.ToString() + ",";
				}
				if (cPrimaryReleasedInto == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cPrimaryReleasedInto.ToString() + ",";
				}
				if (cSecondaryReleasedInto == 0)
				{
					SqlString = SqlString + "NULL";
				}
				else
				{
					SqlString = SqlString + cSecondaryReleasedInto.ToString();
				}
				ocmd.CommandText = SqlString;
				ocmd.ExecuteNonQuery();

				if (result != 0)
				{
					ocmd.CommandText = "spSelect_NewHazmatChemicalDetail";
					orec = ADORecordSetHelper.Open(ocmd, "");
					if (!orec.EOF)
					{
						result = GetHazmatChemicalDetail(Convert.ToInt32(orec[0]));
					}
					else
					{
						result = 0;
					}
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

		public int UpdateHazmatChemicalDetail()
		{
			//Update HazmatDrugLab Record using values in class variables
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;
				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spUpdate_HazmatChemicalDetail " + cChemicalDetailID.ToString() + "," + cCDHazmatID.ToString() + "," + cCDChemicalID.ToString() + ",";
				if (cContainerTypeCode == 0)
				{
					SqlString = SqlString + "NULL," + cContainerCapacity.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cContainerTypeCode.ToString() + "," + cContainerCapacity.ToString() + ",";
				}
				if (cContainerCapacityUnits == 0)
				{
					SqlString = SqlString + "NULL," + cAmountReleased.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cContainerCapacityUnits.ToString() + "," + cAmountReleased.ToString() + ",";
				}
				if (cAmountReleasedUnits == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cAmountReleasedUnits.ToString() + ",";
				}
				if (cPhysicalStateStored == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cPhysicalStateStored.ToString() + ",";
				}
				if (cPhysicalStateReleased == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cPhysicalStateReleased.ToString() + ",";
				}
				if (cPrimaryReleasedInto == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cPrimaryReleasedInto.ToString() + ",";
				}
				if (cSecondaryReleasedInto == 0)
				{
					SqlString = SqlString + "NULL";
				}
				else
				{
					SqlString = SqlString + cSecondaryReleasedInto.ToString();
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

		public int DeleteHazmatChemicalDetail(ref int lChemicalDetailID)
		{
			//Delete specified HazmatChemicalDetail record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spDelete_HazmatChemicalDetail";
				ocmd.ExecuteNonQuery(new object[] { lChemicalDetailID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}
		//HazmatContributingFactor

		public int GetHazmatContributingFactor(int lHazmatID)
		{
			//Retrieve HazmatContributingFactor Recordset
			//For Current Hazmat Release
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_HazmatContributingFactor " + lHazmatID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cHazmatContributingFactorRS = orec;
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

		public int AddHazmatContributingFactor()
		{
			//Add new HazmatActionTaken Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spInsert_HazmatContributingFactor";
				ocmd.ExecuteNonQuery(new object[] { cCFHazmatID, cHazmatContributingFactor });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteHazmatContributingFactor(ref int lHazmatID)
		{
			//Delete all HazmatContributingFactor Records for Current Hazmat Release Report
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
				ocmd.CommandText = "spDelete_HazmatContributingFactor";
				ocmd.ExecuteNonQuery(new object[] { lHazmatID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		//HazmatEquipmentInvolved

		public int GetHazmatEquipmentInvolved(int lHazmatID)
		{
			//Retrieve HazmatEquipmentInvolved Recordset
			//For Current Hazmat Release
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_HazmatEquipmentInvolved " + lHazmatID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cHazmatEquipmentInvolvedRS = orec;
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

		public int AddHazmatEquipmentInvolved()
		{
			//Add new HazmatEquipmentInvolved Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spInsert_HazmatEquipmentInvolved";
				ocmd.ExecuteNonQuery(new object[] { cEIHazmatID, cHazmatEquipmentInvolved });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteHazmatEquipmentInvolved(ref int lHazmatID)
		{
			//Delete all HazmatEquipmentInvolved Records for Current Hazmat Release Report
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
				ocmd.CommandText = "spDelete_HazmatEquipmentInvolved";
				ocmd.ExecuteNonQuery(new object[] { lHazmatID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		//HazmatFireServiceMaterialsUsed

		public int GetHazmatFireServiceMaterialsUsed(int lHazmatID)
		{
			//Retrieve HazmatFireServiceMaterialsUsed Recordset
			//For Current Hazmat Release
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_HazmatFireServiceMaterialsUsed " + lHazmatID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cHazmatFireServiceMaterialsUsedRS = orec;
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

		public int AddHazmatFireServiceMaterialsUsed()
		{
			//Add new HazmatFireServiceMaterialsUsed Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spInsert_HazmatFireServiceMaterialsUsed";
				ocmd.ExecuteNonQuery(new object[] { cMUHazmatID, cFireServiceMaterial, cMaterialQuantity });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteHazmatFireServiceMaterialsUsedAll(ref int lHazmatID)
		{
			//Delete all HazmatFireServiceMaterialsUsed Records for Current Hazmat Release Report
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
				ocmd.CommandText = "spDelete_HazmatFireServiceMaterialsUsedAll";
				ocmd.ExecuteNonQuery(new object[] { lHazmatID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteHazmatFireServiceMaterialsUsed(ref int lHazmatID, ref int iMaterialCode)
		{
			//Delete single HazmatFireServiceMaterialsUsed Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spDelete_HazmatFireServiceMaterialsUsed";
				ocmd.ExecuteNonQuery(new object[] { lHazmatID, iMaterialCode });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		//HazmatMitigatingFactor

		public int GetHazmatMitigatingFactor(int lHazmatID)
		{
			//Retrieve HazmatMitigatingFactor Recordset
			//For Current Hazmat Release
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_HazmatMitigatingFactor " + lHazmatID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cHazmatMitigatingFactorRS = orec;
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

		public int AddHazmatMitigatingFactor()
		{
			//Add new HazmatMitigatingFactor Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spInsert_HazmatMitigatingFactor";
				ocmd.ExecuteNonQuery(new object[] { cMFHazmatID, cHazmatMitigatingFactor });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteHazmatMitigatingFactor(ref int lHazmatID)
		{
			//Delete all HazmatMitigatingFactor Records for Current Hazmat Release Report
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
				ocmd.CommandText = "spDelete_HazmatMitigatingFactor";
				ocmd.ExecuteNonQuery(new object[] { lHazmatID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		//HazmatOutsideResource

		public int GetHazmatOutsideResource(int lHazmatID)
		{
			//Retrieve HazmatOutsideResource Recordset
			//For Current Hazmat Release
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_HazmatOutsideResource " + lHazmatID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cHazmatOutsideResourceRS = orec;
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

		public int GetHazmatDLOutsideResource(int lHazmatID)
		{
			//Retrieve Hazmat Drug Lab OutsideResource Recordset
			//For Current Hazmat Release
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_HazmatDrugLabOutsideResource " + lHazmatID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cHazmatDLOutsideResourceRS = orec;
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

		public int AddHazmatDLOutsideResource()
		{
			//Add new HazmatOutsideResource Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spInsert_HazmatDrugLabOutsideResource";
				ocmd.ExecuteNonQuery(new object[] { cORDLHazmatID, cDLOutsideResource, cDLResourceUse });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int AddHazmatOutsideResource()
		{
			//Add new HazmatOutsideResource Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spInsert_HazmatOutsideResource";
				ocmd.ExecuteNonQuery(new object[] { cORHazmatID, cOutsideResource, cResourceUse });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteHazmatOutsideResourceAll(ref int lHazmatID)
		{
			//Delete all HazmatOutsideResource Records for Current Hazmat Release Report
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
				ocmd.CommandText = "spDelete_HazmatOutsideResourceAll";
				ocmd.ExecuteNonQuery(new object[] { lHazmatID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteHazmatDLOutsideResourceAll(ref int lHazmatID)
		{
			//Delete all HazmatDrugLabOutsideResource Records for Current Hazmat Release Report
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
				ocmd.CommandText = "spDelete_HazmatDrugLabOutsideResourceAll";
				ocmd.ExecuteNonQuery(new object[] { lHazmatID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteHazmatOutsideResource(ref int lHazmatID, ref int iResource)
		{
			//Delete specific HazmatOutsideResource Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spDelete_HazmatOutsideResource";
				ocmd.ExecuteNonQuery(new object[] { lHazmatID, iResource });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteHazmatDLOutsideResource(ref int lHazmatID, ref int iResource)
		{
			//Delete specific HazmatOutsideResource Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.StoredProcedure;
				ocmd.CommandText = "spDelete_HazmatDrugLabOutsideResource";
				ocmd.ExecuteNonQuery(new object[] { lHazmatID, iResource });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int GetHazmatReport(int lHazmatID)
		{
			//Retrieve Hazmat Record
			//Formatted for Reporting
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_Hazmat " + lHazmatID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cHazmatRelease = orec;
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

		public int GetHazmatChemicalDetailReport(int lHazmatID)
		{
			//Retrieve Hazmat Chemical Detail Records
			//Formatted for Reporting
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_HazmatChemicalDetail " + lHazmatID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cHazmatChemicalDetail = orec;
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

		public int GetHazmatChemicalsReport(int lHazmatID)
		{
			//Retrieve Hazmat Chemicals Records
			//Formatted for Reporting
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_HazmatChemicals " + lHazmatID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cChemicals = orec;
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

		public int GetHazmatContribFactorReport(int lHazmatID)
		{
			//Retrieve Hazmat Contributing Factor Records
			//Formatted for Reporting
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_HazmatContribFactor " + lHazmatID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cHazmatContributingFactorRS = orec;
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

		public int GetHazmatActionTakenReport(int lHazmatID)
		{
			//Retrieve Hazmat Action Taken Records
			//Formatted for Reporting
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_HazmatActionTaken " + lHazmatID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cHazmatActionTaken = orec;
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

		public int GetHazmatDLActionTakenReport(int lHazmatID)
		{
			//Retrieve Hazmat Drug Lab Action Taken Records
			//Formatted for Reporting
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_HazmatDrugLabActionTaken " + lHazmatID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cHazmatDLActionTaken = orec;
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

		public int GetHazmatDrugLabReport(int lHazmatID)
		{
			//Retrieve Hazmat Drug Lab Records
			//Formatted for Reporting
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_HazmatDrugLab " + lHazmatID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cHazmatDrugLab = orec;
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

		public int GetHazmatEquipInvolvedReport(int lHazmatID)
		{
			//Retrieve Hazmat Equipment Involved Records
			//Formatted for Reporting
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_HazmatEquipInvolved " + lHazmatID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cHazmatEquipmentInvolvedRS = orec;
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

		public int GetHazmatMaterialsUsedReport(int lHazmatID)
		{
			//Retrieve Hazmat Materials Used Records
			//Formatted for Reporting
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_HazmatMaterialsUsed " + lHazmatID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cHazmatFireServiceMaterialsUsedRS = orec;
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

		public int GetHazmatMitigatingFactorReport(int lHazmatID)
		{
			//Retrieve Hazmat Mitigating Factor Records
			//Formatted for Reporting
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_HazmatMitigatingFactor " + lHazmatID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cHazmatMitigatingFactorRS = orec;
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

		public int GetHazmatOutsideResourceReport(int lHazmatID)
		{
			//Retrieve Hazmat Outside Resource Records
			//Formatted for Reporting
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_HazmatOutsideResource " + lHazmatID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cHazmatOutsideResourceRS = orec;
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

		public int GetHazmatDLOutsideResourceReport(int lHazmatID)
		{
			//Retrieve Hazmat Drug Lab Outside Resource Records
			//Formatted for Reporting
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spReport_HazmatDLOutsideResource " + lHazmatID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");

				if (!orec.EOF)
				{
					cHazmatDLOutsideResourceRS = orec;
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