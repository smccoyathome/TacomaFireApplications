using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident
{

	public class clsEMSCodes
		: UpgradeHelpers.Interfaces.IDependentModel, UpgradeHelpers.Interfaces.ICreatesObjects, UpgradeHelpers
		.Interfaces.IInteractsWithView, UpgradeHelpers.Interfaces.IInitializableCommon, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(clsEMSCodes));
		}

		void UpgradeHelpers.Interfaces.IInitializableCommon.Common()
		{
			_cEMS_ECGCodes = null;
			_cEMS_GCSCodes = null;
			_cEMS_IVCodes = null;
			_cActionTakenCodes = null;
			_cEMSContributingFactorCodes = null;
			_cExamCodes = null;
			_cHospitalChosenByCodes = null;
			_cHospitalCodes = null;
			_cIllnessTypeCodes = null;
			_cIncidentLocationCodes = null;
			_cIncidentSettingCodes = null;
			_cInjuryDetailCodes = null;
			_cInjuryTypeCodes = null;
			_cMechCodes = null;
			_cMedicationCodes = null;
			_cPerformedByCodes = null;
			_cPreExistingConditionCodes = null;
			_cEMSProcedureCodes = null;
			_cProtectiveDeviceCodes = null;
			_cResearchCodes = null;
			_cServiceProvidedCodes = null;
			_cSeverityCodes = null;
			_cTraumaLocationCodes = null;
			_cTraumaTypeCodes = null;
			_cTreatmentAuthorizationCodes = null;
		}

		//********************************************************
		//**    EMS Codes Class                                 **
		//********************************************************
		//**    Methods                                         **
		//**----------------------------------------------------**
		//**
		//********************************************************


		//********************************************************
		//**             Private Class Variables                **
		//********************************************************

		//EMS_ECGCode
		public virtual ADORecordSetHelper _cEMS_ECGCodes { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cEMS_ECGCodes
		{
			get
			{
				if (_cEMS_ECGCodes == null)
				{
					_cEMS_ECGCodes = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cEMS_ECGCodes;
			}
			set
			{
				_cEMS_ECGCodes = value;
			}
		}


		// EMS_GCSCode
		public virtual ADORecordSetHelper _cEMS_GCSCodes { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cEMS_GCSCodes
		{
			get
			{
				if (_cEMS_GCSCodes == null)
				{
					_cEMS_GCSCodes = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cEMS_GCSCodes;
			}
			set
			{
				_cEMS_GCSCodes = value;
			}
		}


		// EMS_IVCode
		public virtual ADORecordSetHelper _cEMS_IVCodes { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cEMS_IVCodes
		{
			get
			{
				if (_cEMS_IVCodes == null)
				{
					_cEMS_IVCodes = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cEMS_IVCodes;
			}
			set
			{
				_cEMS_IVCodes = value;
			}
		}


		// EMSActionTakenCode
		public virtual ADORecordSetHelper _cActionTakenCodes { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cActionTakenCodes
		{
			get
			{
				if (_cActionTakenCodes == null)
				{
					_cActionTakenCodes = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cActionTakenCodes;
			}
			set
			{
				_cActionTakenCodes = value;
			}
		}


		// EMSContributingFactorCode
		public virtual ADORecordSetHelper _cEMSContributingFactorCodes { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cEMSContributingFactorCodes
		{
			get
			{
				if (_cEMSContributingFactorCodes == null)
				{
					_cEMSContributingFactorCodes = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cEMSContributingFactorCodes;
			}
			set
			{
				_cEMSContributingFactorCodes = value;
			}
		}


		// EMSExamCode
		public virtual ADORecordSetHelper _cExamCodes { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cExamCodes
		{
			get
			{
				if (_cExamCodes == null)
				{
					_cExamCodes = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cExamCodes;
			}
			set
			{
				_cExamCodes = value;
			}
		}


		// EMSHospitalChosenByCode
		public virtual ADORecordSetHelper _cHospitalChosenByCodes { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cHospitalChosenByCodes
		{
			get
			{
				if (_cHospitalChosenByCodes == null)
				{
					_cHospitalChosenByCodes = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cHospitalChosenByCodes;
			}
			set
			{
				_cHospitalChosenByCodes = value;
			}
		}


		// EMSHospitalCode
		public virtual ADORecordSetHelper _cHospitalCodes { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cHospitalCodes
		{
			get
			{
				if (_cHospitalCodes == null)
				{
					_cHospitalCodes = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cHospitalCodes;
			}
			set
			{
				_cHospitalCodes = value;
			}
		}


		// EMSIllnessTypeCode
		public virtual ADORecordSetHelper _cIllnessTypeCodes { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cIllnessTypeCodes
		{
			get
			{
				if (_cIllnessTypeCodes == null)
				{
					_cIllnessTypeCodes = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cIllnessTypeCodes;
			}
			set
			{
				_cIllnessTypeCodes = value;
			}
		}


		// EMSIncidentLocationCode
		public virtual ADORecordSetHelper _cIncidentLocationCodes { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cIncidentLocationCodes
		{
			get
			{
				if (_cIncidentLocationCodes == null)
				{
					_cIncidentLocationCodes = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cIncidentLocationCodes;
			}
			set
			{
				_cIncidentLocationCodes = value;
			}
		}


		//EMSIncidentSettingCode
		public virtual ADORecordSetHelper _cIncidentSettingCodes { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cIncidentSettingCodes
		{
			get
			{
				if (_cIncidentSettingCodes == null)
				{
					_cIncidentSettingCodes = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cIncidentSettingCodes;
			}
			set
			{
				_cIncidentSettingCodes = value;
			}
		}


		// EMSInjuryDetailCode
		public virtual ADORecordSetHelper _cInjuryDetailCodes { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cInjuryDetailCodes
		{
			get
			{
				if (_cInjuryDetailCodes == null)
				{
					_cInjuryDetailCodes = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cInjuryDetailCodes;
			}
			set
			{
				_cInjuryDetailCodes = value;
			}
		}


		// EMSInjuryTypeCode
		public virtual ADORecordSetHelper _cInjuryTypeCodes { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cInjuryTypeCodes
		{
			get
			{
				if (_cInjuryTypeCodes == null)
				{
					_cInjuryTypeCodes = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cInjuryTypeCodes;
			}
			set
			{
				_cInjuryTypeCodes = value;
			}
		}


		// EMSMechCode
		public virtual ADORecordSetHelper _cMechCodes { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cMechCodes
		{
			get
			{
				if (_cMechCodes == null)
				{
					_cMechCodes = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cMechCodes;
			}
			set
			{
				_cMechCodes = value;
			}
		}


		// EMSMedicationCode
		public virtual ADORecordSetHelper _cMedicationCodes { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cMedicationCodes
		{
			get
			{
				if (_cMedicationCodes == null)
				{
					_cMedicationCodes = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cMedicationCodes;
			}
			set
			{
				_cMedicationCodes = value;
			}
		}


		//EMSPerformedByCode
		public virtual ADORecordSetHelper _cPerformedByCodes { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cPerformedByCodes
		{
			get
			{
				if (_cPerformedByCodes == null)
				{
					_cPerformedByCodes = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cPerformedByCodes;
			}
			set
			{
				_cPerformedByCodes = value;
			}
		}


		//EMSPreExistingConditionCode
		public virtual ADORecordSetHelper _cPreExistingConditionCodes { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cPreExistingConditionCodes
		{
			get
			{
				if (_cPreExistingConditionCodes == null)
				{
					_cPreExistingConditionCodes = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cPreExistingConditionCodes;
			}
			set
			{
				_cPreExistingConditionCodes = value;
			}
		}


		// EMSProcedureCode
		public virtual ADORecordSetHelper _cEMSProcedureCodes { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cEMSProcedureCodes
		{
			get
			{
				if (_cEMSProcedureCodes == null)
				{
					_cEMSProcedureCodes = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cEMSProcedureCodes;
			}
			set
			{
				_cEMSProcedureCodes = value;
			}
		}


		// EMSProtectiveDeviceCode
		public virtual ADORecordSetHelper _cProtectiveDeviceCodes { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cProtectiveDeviceCodes
		{
			get
			{
				if (_cProtectiveDeviceCodes == null)
				{
					_cProtectiveDeviceCodes = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cProtectiveDeviceCodes;
			}
			set
			{
				_cProtectiveDeviceCodes = value;
			}
		}


		// EMSResearchCode
		public virtual ADORecordSetHelper _cResearchCodes { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cResearchCodes
		{
			get
			{
				if (_cResearchCodes == null)
				{
					_cResearchCodes = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cResearchCodes;
			}
			set
			{
				_cResearchCodes = value;
			}
		}


		//EMSServiceProvidedCode
		public virtual ADORecordSetHelper _cServiceProvidedCodes { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cServiceProvidedCodes
		{
			get
			{
				if (_cServiceProvidedCodes == null)
				{
					_cServiceProvidedCodes = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cServiceProvidedCodes;
			}
			set
			{
				_cServiceProvidedCodes = value;
			}
		}


		// EMSSeverityCode
		public virtual ADORecordSetHelper _cSeverityCodes { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cSeverityCodes
		{
			get
			{
				if (_cSeverityCodes == null)
				{
					_cSeverityCodes = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cSeverityCodes;
			}
			set
			{
				_cSeverityCodes = value;
			}
		}


		//EMSTraumaLocationCode
		public virtual ADORecordSetHelper _cTraumaLocationCodes { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cTraumaLocationCodes
		{
			get
			{
				if (_cTraumaLocationCodes == null)
				{
					_cTraumaLocationCodes = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cTraumaLocationCodes;
			}
			set
			{
				_cTraumaLocationCodes = value;
			}
		}


		// EMSTraumaTypeCode
		public virtual ADORecordSetHelper _cTraumaTypeCodes { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cTraumaTypeCodes
		{
			get
			{
				if (_cTraumaTypeCodes == null)
				{
					_cTraumaTypeCodes = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cTraumaTypeCodes;
			}
			set
			{
				_cTraumaTypeCodes = value;
			}
		}


		//EMSTreatmentAuthorizationCode
		public virtual ADORecordSetHelper _cTreatmentAuthorizationCodes { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cTreatmentAuthorizationCodes
		{
			get
			{
				if (_cTreatmentAuthorizationCodes == null)
				{
					_cTreatmentAuthorizationCodes = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cTreatmentAuthorizationCodes;
			}
			set
			{
				_cTreatmentAuthorizationCodes = value;
			}
		}




		//***************************************************
		//**         Class Public Properties               **
		//***************************************************
		// EMS_GCSCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper EMS_GCSCodes
		{
			get
			{
				return cEMS_GCSCodes;
			}
			set
			{
				cEMS_GCSCodes = value;
			}
		}


		//EMS_ECGCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper EMS_ECGCodes
		{
			get
			{
				return cEMS_ECGCodes;
			}
			set
			{
				cEMS_ECGCodes = value;
			}
		}


		// EMS_IVCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper EMS_IVCodes
		{
			get
			{
				return cEMS_IVCodes;
			}
			set
			{
				cEMS_IVCodes = value;
			}
		}


		// EMSActionTakenCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper ActionTakenCodes
		{
			get
			{
				return cActionTakenCodes;
			}
			set
			{
				cActionTakenCodes = value;
			}
		}


		// EMSContributingFactorCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper EMSContributingFactorCodes
		{
			get
			{
				return cEMSContributingFactorCodes;
			}
			set
			{
				cEMSContributingFactorCodes = value;
			}
		}


		// EMSExamCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper ExamCodes
		{
			get
			{
				return cExamCodes;
			}
			set
			{
				cExamCodes = value;
			}
		}


		// EMSHospitalChosenByCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper HospitalChosenByCodes
		{
			get
			{
				return cHospitalChosenByCodes;
			}
			set
			{
				cHospitalChosenByCodes = value;
			}
		}


		// EMSHospitalCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper HospitalCodes
		{
			get
			{
				return cHospitalCodes;
			}
			set
			{
				cHospitalCodes = value;
			}
		}


		// EMSIllnessTypeCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper IllnessTypeCodes
		{
			get
			{
				return cIllnessTypeCodes;
			}
			set
			{
				cIllnessTypeCodes = value;
			}
		}


		// EMSIncidentLocationCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper IncidentLocationCodes
		{
			get
			{
				return cIncidentLocationCodes;
			}
			set
			{
				cIncidentLocationCodes = value;
			}
		}


		//EMSIncidentSettingCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper IncidentSettingCodes
		{
			get
			{
				return cIncidentSettingCodes;
			}
			set
			{
				cIncidentSettingCodes = value;
			}
		}


		// EMSInjuryDetailCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper InjuryDetailCodes
		{
			get
			{
				return cInjuryDetailCodes;
			}
			set
			{
				cInjuryDetailCodes = value;
			}
		}


		// EMSInjuryTypeCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper InjuryTypeCodes
		{
			get
			{
				return cInjuryTypeCodes;
			}
			set
			{
				cInjuryTypeCodes = value;
			}
		}


		// EMSMechCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper MechCodes
		{
			get
			{
				return cMechCodes;
			}
			set
			{
				cMechCodes = value;
			}
		}


		// EMSMedicationCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper MedicationCodes
		{
			get
			{
				return cMedicationCodes;
			}
			set
			{
				cMedicationCodes = value;
			}
		}


		//EMSPerformedByCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper PerformedByCodes
		{
			get
			{
				return cPerformedByCodes;
			}
			set
			{
				cPerformedByCodes = value;
			}
		}


		//EMSPreExistingConditionCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper PreExistingConditionCodes
		{
			get
			{
				return cPreExistingConditionCodes;
			}
			set
			{
				cPreExistingConditionCodes = value;
			}
		}


		// EMSProcedureCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper EMSProcedureCodes
		{
			get
			{
				return cEMSProcedureCodes;
			}
			set
			{
				cEMSProcedureCodes = value;
			}
		}


		// EMSProtectiveDeviceCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper ProtectiveDeviceCodes
		{
			get
			{
				return cProtectiveDeviceCodes;
			}
			set
			{
				cProtectiveDeviceCodes = value;
			}
		}


		// EMSResearchCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper ResearchCodes
		{
			get
			{
				return cResearchCodes;
			}
			set
			{
				cResearchCodes = value;
			}
		}


		// EMSSeverityCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper SeverityCodes
		{
			get
			{
				return cSeverityCodes;
			}
			set
			{
				cSeverityCodes = value;
			}
		}


		//EMSServiceProvidedCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper ServiceProvidedCodes
		{
			get
			{
				return cServiceProvidedCodes;
			}
			set
			{
				cServiceProvidedCodes = value;
			}
		}


		//EMSTraumaLocationCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper TraumaLocationCodes
		{
			get
			{
				return cTraumaLocationCodes;
			}
			set
			{
				cTraumaLocationCodes = value;
			}
		}


		// EMSTraumaTypeCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper TraumaTypeCodes
		{
			get
			{
				return cTraumaTypeCodes;
			}
			set
			{
				cTraumaTypeCodes = value;
			}
		}


		//EMSTreatmentAuthorizationCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper TreatmentAuthorizationCodes
		{
			get
			{
				return cTreatmentAuthorizationCodes;
			}
			set
			{
				cTreatmentAuthorizationCodes = value;
			}
		}



		//**********************************************
		//**         Public Class Methods             **
		//**********************************************
		//---- GetXXXXXXX methods for retrieving codetable recordsets

		//EMS_ECGCode

		public void GetECGCodes()
		{
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMS_ECGCode";
				oRec = ADORecordSetHelper.Open(ocmd, "");
				cEMS_ECGCodes = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		// EMS_GCSCode

		public void GetGCSCodesByType(string sType)
		{
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMS_GCSCode '" + sType + "'";
				oRec = ADORecordSetHelper.Open(ocmd, "");
				cEMS_GCSCodes = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		// EMS_IVCode

		public void GetIVCodesByType(string sType)
		{
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMS_IVCode '" + sType + "'";
				oRec = ADORecordSetHelper.Open(ocmd, "");
				cEMS_IVCodes = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		// EMSActionTakenCode

		public void GetActionTakenCodes()
		{
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSActionTakenCode";
				oRec = ADORecordSetHelper.Open(ocmd, "");
				cActionTakenCodes = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		// EMSContributingFactorCode

		public void GetContributingFactorCodes()
		{
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSContributingFactorCode";
				oRec = ADORecordSetHelper.Open(ocmd, "");
				cEMSContributingFactorCodes = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		// EMSExamCode

		public void GetExamCodesByType(string sType)
		{
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSExamCode '" + sType + "'";
				oRec = ADORecordSetHelper.Open(ocmd, "");
				cExamCodes = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		// EMSHospitalChosenByCode

		public void GetHospitalChosenByCodes()
		{
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSHospitalChosenByCode";
				oRec = ADORecordSetHelper.Open(ocmd, "");
				cHospitalChosenByCodes = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		// EMSHospitalCode

		public void GetHospitalCodes()
		{
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSHospitalCode";
				oRec = ADORecordSetHelper.Open(ocmd, "");
				cHospitalCodes = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		// EMSIllnessTypeCode

		public void GetIllnessTypeCodes()
		{
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSIllnessTypeCode";
				oRec = ADORecordSetHelper.Open(ocmd, "");
				cIllnessTypeCodes = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		// EMSIncidentLocationCode

		public void GetIncidentLocationCodes()
		{
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSIncidentLocationCode";
				oRec = ADORecordSetHelper.Open(ocmd, "");
				cIncidentLocationCodes = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		//EMSIncidentSettingCode

		public void GetIncidentSettingCodes()
		{
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSIncidentSettingCode";
				oRec = ADORecordSetHelper.Open(ocmd, "");
				cIncidentSettingCodes = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		// EMSInjuryDetailCode

		public void GetInjuryDetailCodesByType(string sType)
		{
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSInjuryDetailCode '" + sType + "'";
				oRec = ADORecordSetHelper.Open(ocmd, "");
				cInjuryDetailCodes = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		// EMSInjuryTypeCode

		public int GetInjuryTypeCode(int iBodyPart, int iInjuryType)
		{
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSInjuryTypeCode " + iBodyPart.ToString() + "," + iInjuryType.ToString();
				oRec = ADORecordSetHelper.Open(ocmd, "");
				if (!oRec.EOF)
				{
					return Convert.ToInt32(oRec["injury_type_code"]);
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

		public int GetInjuryBodyPart(int iInjuryCode)
		{
			//Retrieve Body Part from Injury Type Code
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSInjuryDescriptor " + iInjuryCode.ToString();
				oRec = ADORecordSetHelper.Open(ocmd, "");
				if (!oRec.EOF)
				{
					return Convert.ToInt32(oRec["body_part"]);
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

		public int GetInjuryInjuryDescriptor(int iInjuryCode)
		{
			//Retrieve Injury Descriptor from Injury Type Code
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSInjuryDescriptor " + iInjuryCode.ToString();
				oRec = ADORecordSetHelper.Open(ocmd, "");
				if (!oRec.EOF)
				{
					return Convert.ToInt32(oRec["injury_descriptor"]);
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

		// EMSMechCode

		public void GetMechCodes()
		{
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSMechCode";
				oRec = ADORecordSetHelper.Open(ocmd, "");
				cMechCodes = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		// EMSMedicationCode

		public void GetMedicationCodes()
		{
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSMedicationCode";
				oRec = ADORecordSetHelper.Open(ocmd, "");
				cMedicationCodes = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		//EMSPerformedByCode

		public void GetPerformedByCodes()
		{
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSPerformedByCode";
				oRec = ADORecordSetHelper.Open(ocmd, "");
				cPerformedByCodes = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		//EMSPreExistingConditionCode

		public void GetPreExistingConditionCodes()
		{
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSPreExistingConditionCode";
				oRec = ADORecordSetHelper.Open(ocmd, "");
				cPreExistingConditionCodes = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		// EMSProcedureCode

		public void GetProcedureCodesByType(string sType)
		{
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSProcedureCode '" + sType + "'";
				oRec = ADORecordSetHelper.Open(ocmd, "");
				cEMSProcedureCodes = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		// EMSProtectiveDeviceCode

		public void GetProtectiveDeviceCodes()
		{
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSProtectiveDeviceCode";
				oRec = ADORecordSetHelper.Open(ocmd, "");
				cProtectiveDeviceCodes = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		// EMSResearchCode

		public void GetResearchCodes()
		{
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSResearchCode";
				oRec = ADORecordSetHelper.Open(ocmd, "");
				cResearchCodes = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		// EMSSeverityCode

		public void GetSeverityCodes()
		{
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSSeverityCode";
				oRec = ADORecordSetHelper.Open(ocmd, "");
				cSeverityCodes = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		//EMSServiceProvidedCode

		public void GetServiceProvidedCodes()
		{
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSServiceProvidedCode";
				oRec = ADORecordSetHelper.Open(ocmd, "");
				cServiceProvidedCodes = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		//EMSTraumaLocationCode

		public void GetTraumaLocationCodes()
		{
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSTraumaLocationCode";
				oRec = ADORecordSetHelper.Open(ocmd, "");
				cTraumaLocationCodes = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}


		// EMSTraumaTypeCode

		public void GetTraumaTypeCodesByClass(int iTraumaClass)
		{
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSTraumaTypeCode " + iTraumaClass.ToString();
				oRec = ADORecordSetHelper.Open(ocmd, "");
				cTraumaTypeCodes = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		//EMSTreatmentAuthorizationCode

		public void GetTreatmentAuthorizationCodes()
		{
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_EMSTreatmentAuthorizationCode";
				oRec = ADORecordSetHelper.Open(ocmd, "");
				cTreatmentAuthorizationCodes = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public string UniqueID { get; set; }

		public UpgradeHelpers.Interfaces.IViewManager ViewManager { get; set; }

		public UpgradeHelpers.Interfaces.IIocContainer Container { get; set; }

	}
}