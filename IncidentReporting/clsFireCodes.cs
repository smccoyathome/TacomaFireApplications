using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident
{

	public class clsFireCodes
		: UpgradeHelpers.Interfaces.IDependentModel, UpgradeHelpers.Interfaces.ICreatesObjects, UpgradeHelpers
		.Interfaces.IInteractsWithView, UpgradeHelpers.Interfaces.IInitializableCommon, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(clsFireCodes));
		}

		void UpgradeHelpers.Interfaces.IInitializableCommon.Common()
		{
			_cAlarmDevice = null;
			_cAreaOfOrigin = null;
			_cAreaUnits = null;
			_cBuildingStatus = null;
			_cBurnDamage = null;
			_cCauseOfIgnitionClassRS = null;
			_cCauseOfIgnition = null;
			_cConstructionType = null;
			_cDetectorPower = null;
			_cEffectiveness = null;
			_cEquipmentInvolved = null;
			_cFireSystemType = null;
			_cFirstItemIgnited = null;
			_cHeatSource = null;
			_cHumanFactor = null;
			_cIncidentTypeClassRS = null;
			_cIncidentType = null;
			_cMaterialType = null;
			_cPhysicalFactor = null;
			_cPropertyUseClassRS = null;
			_cPropertyUse = null;
			_cPropertyValue = null;
			cSqFootValue = 0;
			cPropValueCalc = 0;
			cPropLossCalc = 0;
			_cSuppressionFactor = null;
			_cSystemFailure = null;
			_cMobileMakeCode = null;
		}

		//********************************************************
		//**    Fire Codes Class                                **
		//**  Contains Fire Code Table References and Methods   **
		//********************************************************
		//**    Methods                                         **
		//**----------------------------------------------------**



		//********************************************************
		//**             Private Class Variables                **
		//********************************************************

		//AlarmDeviceCode
		public virtual ADORecordSetHelper _cAlarmDevice { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cAlarmDevice
		{
			get
			{
				if (_cAlarmDevice == null)
				{
					_cAlarmDevice = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cAlarmDevice;
			}
			set
			{
				_cAlarmDevice = value;
			}
		}


		//AreaOfOriginCode
		public virtual ADORecordSetHelper _cAreaOfOrigin { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cAreaOfOrigin
		{
			get
			{
				if (_cAreaOfOrigin == null)
				{
					_cAreaOfOrigin = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cAreaOfOrigin;
			}
			set
			{
				_cAreaOfOrigin = value;
			}
		}


		//AreaUnits
		public virtual ADORecordSetHelper _cAreaUnits { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cAreaUnits
		{
			get
			{
				if (_cAreaUnits == null)
				{
					_cAreaUnits = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cAreaUnits;
			}
			set
			{
				_cAreaUnits = value;
			}
		}


		//BuildingStatusCode
		public virtual ADORecordSetHelper _cBuildingStatus { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cBuildingStatus
		{
			get
			{
				if (_cBuildingStatus == null)
				{
					_cBuildingStatus = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cBuildingStatus;
			}
			set
			{
				_cBuildingStatus = value;
			}
		}


		//BurnDamageCode
		public virtual ADORecordSetHelper _cBurnDamage { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cBurnDamage
		{
			get
			{
				if (_cBurnDamage == null)
				{
					_cBurnDamage = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cBurnDamage;
			}
			set
			{
				_cBurnDamage = value;
			}
		}


		//CauseOfIgnitionClass
		public virtual ADORecordSetHelper _cCauseOfIgnitionClassRS { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cCauseOfIgnitionClassRS
		{
			get
			{
				if (_cCauseOfIgnitionClassRS == null)
				{
					_cCauseOfIgnitionClassRS = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cCauseOfIgnitionClassRS;
			}
			set
			{
				_cCauseOfIgnitionClassRS = value;
			}
		}


		//CauseOfIgnitionCode
		public virtual ADORecordSetHelper _cCauseOfIgnition { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cCauseOfIgnition
		{
			get
			{
				if (_cCauseOfIgnition == null)
				{
					_cCauseOfIgnition = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cCauseOfIgnition;
			}
			set
			{
				_cCauseOfIgnition = value;
			}
		}


		//ConstructionTypeCode
		public virtual ADORecordSetHelper _cConstructionType { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cConstructionType
		{
			get
			{
				if (_cConstructionType == null)
				{
					_cConstructionType = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cConstructionType;
			}
			set
			{
				_cConstructionType = value;
			}
		}


		//DetectorPowerCode
		public virtual ADORecordSetHelper _cDetectorPower { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cDetectorPower
		{
			get
			{
				if (_cDetectorPower == null)
				{
					_cDetectorPower = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cDetectorPower;
			}
			set
			{
				_cDetectorPower = value;
			}
		}


		//EffectivenessCode
		public virtual ADORecordSetHelper _cEffectiveness { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cEffectiveness
		{
			get
			{
				if (_cEffectiveness == null)
				{
					_cEffectiveness = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cEffectiveness;
			}
			set
			{
				_cEffectiveness = value;
			}
		}


		//EquipmentInvolvedCode
		public virtual ADORecordSetHelper _cEquipmentInvolved { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cEquipmentInvolved
		{
			get
			{
				if (_cEquipmentInvolved == null)
				{
					_cEquipmentInvolved = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cEquipmentInvolved;
			}
			set
			{
				_cEquipmentInvolved = value;
			}
		}


		//FireSystemsTypeCode
		public virtual ADORecordSetHelper _cFireSystemType { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cFireSystemType
		{
			get
			{
				if (_cFireSystemType == null)
				{
					_cFireSystemType = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cFireSystemType;
			}
			set
			{
				_cFireSystemType = value;
			}
		}


		//FirstItemIgnitedCode
		public virtual ADORecordSetHelper _cFirstItemIgnited { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cFirstItemIgnited
		{
			get
			{
				if (_cFirstItemIgnited == null)
				{
					_cFirstItemIgnited = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cFirstItemIgnited;
			}
			set
			{
				_cFirstItemIgnited = value;
			}
		}


		//HeatSourceCode
		public virtual ADORecordSetHelper _cHeatSource { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cHeatSource
		{
			get
			{
				if (_cHeatSource == null)
				{
					_cHeatSource = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cHeatSource;
			}
			set
			{
				_cHeatSource = value;
			}
		}


		//HumanFactorCode
		public virtual ADORecordSetHelper _cHumanFactor { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cHumanFactor
		{
			get
			{
				if (_cHumanFactor == null)
				{
					_cHumanFactor = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cHumanFactor;
			}
			set
			{
				_cHumanFactor = value;
			}
		}


		//IncidentTypeClass
		public virtual ADORecordSetHelper _cIncidentTypeClassRS { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cIncidentTypeClassRS
		{
			get
			{
				if (_cIncidentTypeClassRS == null)
				{
					_cIncidentTypeClassRS = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cIncidentTypeClassRS;
			}
			set
			{
				_cIncidentTypeClassRS = value;
			}
		}


		//IncidentTypeCode
		public virtual ADORecordSetHelper _cIncidentType { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cIncidentType
		{
			get
			{
				if (_cIncidentType == null)
				{
					_cIncidentType = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cIncidentType;
			}
			set
			{
				_cIncidentType = value;
			}
		}


		//MaterialTypeCode
		public virtual ADORecordSetHelper _cMaterialType { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cMaterialType
		{
			get
			{
				if (_cMaterialType == null)
				{
					_cMaterialType = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cMaterialType;
			}
			set
			{
				_cMaterialType = value;
			}
		}


		//PhysicalFactorCode
		public virtual ADORecordSetHelper _cPhysicalFactor { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cPhysicalFactor
		{
			get
			{
				if (_cPhysicalFactor == null)
				{
					_cPhysicalFactor = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cPhysicalFactor;
			}
			set
			{
				_cPhysicalFactor = value;
			}
		}


		//PropertyUseClass
		public virtual ADORecordSetHelper _cPropertyUseClassRS { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cPropertyUseClassRS
		{
			get
			{
				if (_cPropertyUseClassRS == null)
				{
					_cPropertyUseClassRS = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cPropertyUseClassRS;
			}
			set
			{
				_cPropertyUseClassRS = value;
			}
		}


		//PropertyUseCode
		public virtual ADORecordSetHelper _cPropertyUse { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cPropertyUse
		{
			get
			{
				if (_cPropertyUse == null)
				{
					_cPropertyUse = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cPropertyUse;
			}
			set
			{
				_cPropertyUse = value;
			}
		}


		//PropertyValue
		public virtual ADORecordSetHelper _cPropertyValue { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cPropertyValue
		{
			get
			{
				if (_cPropertyValue == null)
				{
					_cPropertyValue = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cPropertyValue;
			}
			set
			{
				_cPropertyValue = value;
			}
		}

		public virtual int cSqFootValue { get; set; }

		public virtual int cPropValueCalc { get; set; }

		public virtual int cPropLossCalc { get; set; }

		//SuppressionFactorCode
		public virtual ADORecordSetHelper _cSuppressionFactor { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cSuppressionFactor
		{
			get
			{
				if (_cSuppressionFactor == null)
				{
					_cSuppressionFactor = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cSuppressionFactor;
			}
			set
			{
				_cSuppressionFactor = value;
			}
		}


		//SystemFailureCode
		public virtual ADORecordSetHelper _cSystemFailure { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cSystemFailure
		{
			get
			{
				if (_cSystemFailure == null)
				{
					_cSystemFailure = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cSystemFailure;
			}
			set
			{
				_cSystemFailure = value;
			}
		}


		//FireMobileMakeCode
		public virtual ADORecordSetHelper _cMobileMakeCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cMobileMakeCode
		{
			get
			{
				if (_cMobileMakeCode == null)
				{
					_cMobileMakeCode = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cMobileMakeCode;
			}
			set
			{
				_cMobileMakeCode = value;
			}
		}


		//*********************************************
		//**         Class Public Properties         **
		//*********************************************

		//AlarmDeviceCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper AlarmDevice
		{
			get
			{
				return cAlarmDevice;
			}
			set
			{
				cAlarmDevice = value;
			}
		}


		//AreaOfOriginCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper AreaOfOrigin
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


		//AreaUnits
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper AreaUnits
		{
			get
			{
				return cAreaUnits;
			}
			set
			{
				cAreaUnits = value;
			}
		}


		//BuildingStatusCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper BuildingStatus
		{
			get
			{
				return cBuildingStatus;
			}
			set
			{
				cBuildingStatus = value;
			}
		}


		//BurnDamageCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper BurnDamage
		{
			get
			{
				return cBurnDamage;
			}
			set
			{
				cBurnDamage = value;
			}
		}


		//CauseOfIgnitionClass
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper CauseOfIgnitionClassRS
		{
			get
			{
				return cCauseOfIgnitionClassRS;
			}
			set
			{
				cCauseOfIgnitionClassRS = value;
			}
		}


		//CauseOfIgnitionCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper CauseOfIgnition
		{
			get
			{
				return cCauseOfIgnition;
			}
			set
			{
				cCauseOfIgnition = value;
			}
		}


		//ConstructionTypeCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper ConstructionType
		{
			get
			{
				return cConstructionType;
			}
			set
			{
				cConstructionType = value;
			}
		}


		//DetectorPowerCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper DetectorPower
		{
			get
			{
				return cDetectorPower;
			}
			set
			{
				cDetectorPower = value;
			}
		}


		//EffectivenessCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper Effectiveness
		{
			get
			{
				return cEffectiveness;
			}
			set
			{
				cEffectiveness = value;
			}
		}


		//EquipmentInvolvedCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper EquipmentInvolved
		{
			get
			{
				return cEquipmentInvolved;
			}
			set
			{
				cEquipmentInvolved = value;
			}
		}


		//FireSystemsTypeCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper FireSystemType
		{
			get
			{
				return cFireSystemType;
			}
			set
			{
				cFireSystemType = value;
			}
		}


		//FirstItemIgnitedCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper FirstItemIgnited
		{
			get
			{
				return cFirstItemIgnited;
			}
			set
			{
				cFirstItemIgnited = value;
			}
		}


		//HeatSourceCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper HeatSource
		{
			get
			{
				return cHeatSource;
			}
			set
			{
				cHeatSource = value;
			}
		}


		//HumanFactorCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper HumanFactor
		{
			get
			{
				return cHumanFactor;
			}
			set
			{
				cHumanFactor = value;
			}
		}


		//IncidentTypeClass
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper IncidentTypeClassRS
		{
			get
			{
				return cIncidentTypeClassRS;
			}
			set
			{
				cIncidentTypeClassRS = value;
			}
		}


		//IncidentTypeCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper IncidentType
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


		//MaterialTypeCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper MaterialType
		{
			get
			{
				return cMaterialType;
			}
			set
			{
				cMaterialType = value;
			}
		}


		//PhysicalFactorCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper PhysicalFactor
		{
			get
			{
				return cPhysicalFactor;
			}
			set
			{
				cPhysicalFactor = value;
			}
		}


		//PropertyUseClass
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper PropertyUseClassRS
		{
			get
			{
				return cPropertyUseClassRS;
			}
			set
			{
				cPropertyUseClassRS = value;
			}
		}


		//PropertyUseCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper PropertyUse
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


		//PropertyValue
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper PropertyValue
		{
			get
			{
				return cPropertyValue;
			}
			set
			{
				cPropertyValue = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int SqFootValue
		{
			get
			{
				return cSqFootValue;
			}
			set
			{
				cSqFootValue = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int PropValueCalc
		{
			get
			{
				return cPropValueCalc;
			}
			set
			{
				cPropValueCalc = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int PropLossCalc
		{
			get
			{
				return cPropLossCalc;
			}
			set
			{
				cPropLossCalc = value;
			}
		}



		//SuppressionFactorCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper SuppressionFactor
		{
			get
			{
				return cSuppressionFactor;
			}
			set
			{
				cSuppressionFactor = value;
			}
		}


		//SystemFailureCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper SystemFailure
		{
			get
			{
				return cSystemFailure;
			}
			set
			{
				cSystemFailure = value;
			}
		}


		//FireMobileMakeCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper MobileMakeCode
		{
			get
			{
				return cMobileMakeCode;
			}
			set
			{
				cMobileMakeCode = value;
			}
		}


		//**************************************************
		//**            Class Public Methods              **
		//**************************************************

		//Retrieve CodeTable Recordsets for Loading Listboxes

		public void GetFireInfoCodes()
		{
			//** Fire Info Report Codes **
			//Load Class Recordsets for FireInfo Codes

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_FireInfoCodes";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cHeatSource = oRec;
				//UPGRADE_WARNING: (2065) ADODB.Recordset method oRec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
				oRec = oRec.NextRecordSet();
				cCauseOfIgnitionClassRS = oRec;
				//UPGRADE_WARNING: (2065) ADODB.Recordset method oRec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
				oRec = oRec.NextRecordSet();
				cFirstItemIgnited = oRec;
				//UPGRADE_WARNING: (2065) ADODB.Recordset method oRec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
				oRec = oRec.NextRecordSet();
				cPhysicalFactor = oRec;
				//UPGRADE_WARNING: (2065) ADODB.Recordset method oRec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
				oRec = oRec.NextRecordSet();
				cHumanFactor = oRec;
				//UPGRADE_WARNING: (2065) ADODB.Recordset method oRec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
				oRec = oRec.NextRecordSet();
				cSuppressionFactor = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetSuppressionFactorCodes()
		{
			//Load Class Recordset for SuppressionFactorCodes

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_SuppressionFactorCode";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cSuppressionFactor = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetHumanFactorCodes()
		{
			//Load Class Recordset for HumanFactorCodes Codes

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_HumanFactorCode";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cHumanFactor = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetPhysicalFactorCodes()
		{
			//Load Class Recordset for PhysicalFactorCodes Codes

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_PhysicalFactorCode";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cPhysicalFactor = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetFirstItemIgnitedCodes()
		{
			//Load Class Recordset for FirstItemIgnited Codes

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_FirstItemIgnitedCode";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cFirstItemIgnited = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetHeatSourceCodes()
		{
			//Load Class Recordset for HeatSource Codes

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_HeatSourceCode";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cHeatSource = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetExposureHeatSourceCodes()
		{
			//Load Class Recordset for Exposure HeatSource Codes

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_ExposureHeatSourceCode";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cHeatSource = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}


		public void GetCauseOfIgnitionClass()
		{
			//Load Class Recordset for CauseOfIgnition Classes

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_CauseOfIgnitionClass";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cCauseOfIgnitionClassRS = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetBuildingInfoCodes()
		{
			//** Fire Structure Report Codes **
			//Load Class Recordsets for BuildingInfo Codes
			//!!! Note: FireSystemType, Effectiveness, SystemFailure
			//!!!       Are all defaulting to Extinguishing System Codes
			//!!!       For Initial Load.
			//!!!       Use GetSystemCodes for Alarm specific codes
			//!!!       Use GetDetectorCodes for Detector specific codes

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_BuildingInfoCodes";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cPropertyUseClassRS = oRec;
				//UPGRADE_WARNING: (2065) ADODB.Recordset method oRec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
				oRec = oRec.NextRecordSet();
				cBuildingStatus = oRec;
				//UPGRADE_WARNING: (2065) ADODB.Recordset method oRec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
				oRec = oRec.NextRecordSet();
				cConstructionType = oRec;
				//UPGRADE_WARNING: (2065) ADODB.Recordset method oRec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
				oRec = oRec.NextRecordSet();
				cBurnDamage = oRec;
				//UPGRADE_WARNING: (2065) ADODB.Recordset method oRec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
				oRec = oRec.NextRecordSet();
				cFirstItemIgnited = oRec;
				//UPGRADE_WARNING: (2065) ADODB.Recordset method oRec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
				oRec = oRec.NextRecordSet();
				cEquipmentInvolved = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetEquipmentInvolvedCodes()
		{
			//Load Class Recordset for EquipmentInvolved

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_EquipmentInvolvedCode";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cEquipmentInvolved = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetBurnDamageCodes()
		{
			//Load Class Recordset for BurnDamageCodes

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_BurnDamageCode";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cBurnDamage = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetConstructionTypeCodes()
		{
			//Load Class Recordset for ConstructionTypeCodes

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_ConstructionTypeCode";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cConstructionType = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetBuildingStatusCodes()
		{
			//Load Class Recordset for BuildingStatusCodes

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_BuildingStatusCode";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cBuildingStatus = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetPropertyUseClass()
		{
			//Load Class Recordset for PropertyUseClass

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_PropertyUseClass";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cPropertyUseClassRS = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetOutSideFireCodes()
		{
			//** Fire Outside Report Codes **
			//Load Class Recordsets for FireOutside Codes

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_OutsideFireCodes";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cHeatSource = oRec;
				//UPGRADE_WARNING: (2065) ADODB.Recordset method oRec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
				oRec = oRec.NextRecordSet();
				cCauseOfIgnitionClassRS = oRec;
				//UPGRADE_WARNING: (2065) ADODB.Recordset method oRec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
				oRec = oRec.NextRecordSet();
				cAreaUnits = oRec;
				//UPGRADE_WARNING: (2065) ADODB.Recordset method oRec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
				oRec = oRec.NextRecordSet();
				cMaterialType = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetMaterialTypeCodes()
		{
			//Load Class Recordset for MaterialTypeCodes

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_MaterialTypeCode";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cMaterialType = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetEffectiveness(string SysType)
		{
			//!! Alarm - SysType = "A", Extinguish - SysType = "E", Detector = SysType "D"
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_EffectivenessCode '" + SysType + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cEffectiveness = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetFireSystemType(string SysType)
		{
			//!! Alarm - SysType = "A", Extinguish - SysType = "E", Detector = SysType "D"
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_FireSystemTypeCode '" + SysType + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cFireSystemType = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetSystemFailure(string SysType)
		{
			//!! Alarm - SysType = "A", Extinguish - SysType = "E", Detector = SysType "D"
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_SystemFailureCode '" + SysType + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cSystemFailure = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetAlarmDevice()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_AlarmDeviceCode";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cAlarmDevice = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetDetectorPowerCodes()
		{
			//** Detector Power Codes **
			//Load Class Recordsets for Detector Codes

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_DetectorPowerCode";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cDetectorPower = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetMobileMakeCode()
		{
			//** Mobile Property Make Codes **

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_FireMobileMakeCode";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cMobileMakeCode = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		//Retrieve Code Table Recordset for Dependent Codes
		//!! PropertyUseCode, AreaOfOriginCode, CauseOfIgnitionCode

		public void GetPropertyUseByClass(int iPropClass)
		{
			//** PropertyUseCodes and AreaOfOriginCodes**
			//** For Specified Property Use Class

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_PropertyUseCodeByClass_new " + iPropClass.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cPropertyUse = oRec;
                oCmd.CommandText = "spSelect_AreaOfOriginCodeByClass_new " + iPropClass.ToString();
                oRec = ADORecordSetHelper.Open(oCmd, "");
                cAreaOfOrigin = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public int GetPropertyUseByCode(int iPropCode)
		{
			//** PropertyUseCodes and AreaOfOriginCodes**
			//** For Specified Property Use Code
			//** Lookup Join used to determine PropertyUseClass

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_PropertyUseCodeByCode " + iPropCode.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cPropertyUse = oRec;
				//UPGRADE_WARNING: (2065) ADODB.Recordset method oRec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
				oRec = oRec.NextRecordSet();
				cAreaOfOrigin = oRec;
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

		public void GetCauseOfIgnitionByClass(int iCauseClass)
		{
			//** CauseOfIgnitionCodes **
			//** For Specified CauseOfIgnition Class

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_CauseOfIgnitionCodeByClass " + iCauseClass.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cCauseOfIgnition = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetCauseOfIgnitionByCode(int iCauseCode)
		{
			//** CauseOfIgnitionCodes **
			//** For Specified CauseOfIgnition Code
			//** Look up Join used to determine CauseOfIgnition Class

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_CauseOfIgnitionCodeByCode " + iCauseCode.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cCauseOfIgnition = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public int GetSqFootValue(int iPropUse, int iConstType)
		{
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_PropertyValue " + iPropUse.ToString() + "," + iConstType.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					return Convert.ToInt32(oRec["sq_foot_value"]);
				}
				else
				{
					return -1;
				}
			}
			catch
			{

				result = -1;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public int CalculatePropertyValue(int iPropUse, int iConstType, int lSqFoot)
		{
			//Calculate Property Value

			cPropValueCalc = 0;
			//Test for missing Calc factors
			if (iPropUse == 0)
			{
				return 0;
			}
			else if (iConstType == 0)
			{
				return 0;
			}
			else if (lSqFoot == 0)
			{
				return 0;
			}


			int SqFootValue = GetSqFootValue(iPropUse, iConstType);
			if (SqFootValue != -1)
			{
				cPropValueCalc = SqFootValue * lSqFoot;
				return -1;
			}
			else
			{
				return 0;
			}

		}

		public int CalculatePropertyLoss(int iPropUse, int iConstType, int lSqFoot)
		{
			//Calculate Property Loss

			cPropLossCalc = 0;
			//Test for missing Calc factors
			if (iPropUse == 0)
			{
				return 0;
			}
			else if (iConstType == 0)
			{
				return 0;
			}
			else if (lSqFoot == 0)
			{
				return 0;
			}


			int SqFootValue = GetSqFootValue(iPropUse, iConstType);
			if (SqFootValue != -1)
			{
				cPropLossCalc = SqFootValue * lSqFoot;
				return -1;
			}
			else
			{
				return 0;
			}

		}

		public string UniqueID { get; set; }

		public UpgradeHelpers.Interfaces.IViewManager ViewManager { get; set; }

		public UpgradeHelpers.Interfaces.IIocContainer Container { get; set; }

	}
}