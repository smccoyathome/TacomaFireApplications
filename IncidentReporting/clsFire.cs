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

	public class clsFire
		: UpgradeHelpers.Interfaces.IDependentModel, UpgradeHelpers.Interfaces.ICreatesObjects, UpgradeHelpers
		.Interfaces.IInteractsWithView, UpgradeHelpers.Interfaces.IInitializableCommon, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(clsFire));
		}

		void UpgradeHelpers.Interfaces.IInitializableCommon.Common()
		{
			_cFireReport = null;
			cFireReportID = 0;
			cIncidentID = 0;
			cIncidentType = 0;
			cPropertyUse = 0;
			cAreaOfOrigin = 0;
			cHeatSource = 0;
			cFirstItemIgnited = 0;
			cCauseOfIgnition = 0;
			cPropertyValue = 0;
			cPropertyLoss = 0;
			cContentLoss = 0;
			_cFireStructure = null;
			cFSFireReportID = 0;
			cFloorOfOrigin = 0;
			cSpecialFloor = 0;
			cBuildingStatus = 0;
			cBurnDamage = 0;
			cSmokeDamage = 0;
			cFlagNoAlarm = 0;
			cFireAlarmType = 0;
			cDetectorPower = 0;
			cInitiatingDevice = 0;
			cAlarmEffectiveness = 0;
			cFlagAlarmOperation = 0;
			cFlagNoExtinguishSystem = 0;
			cExtinguishType = 0;
			cExtinguishEffectiveness = 0;
			cFlagExtinguishOperation = 0;
			cNumberOfStories = 0;
			cBasementLevels = 0;
			cConstructionType = 0;
			cTotalSqFootage = 0;
			cPeopleOccuping = 0;
			cBusinessesOccuping = 0;
			cSqFootBurned = 0;
			cSqFootSmokeDamaged = 0;
			cPeopleDisplaced = 0;
			cBusinessesDisplaced = 0;
			cJobsLost = 0;
			cNumberOfUnits = 0;
			cFlagRental = 0;
			cFlagExposure = 0;
			_cFireMobileProperty = null;
			cFMFireReportID = 0;
			cVehicleMake = "";
			cVehicleModel = "";
			cVehicleYear = "";
			cVehicleVin = "";
			cWaterVesselLength = 0;
			cMobileMake = "";
			cLicenseState = "";
			_cFireOutside = null;
			cFireOutsideID = 0;
			cFOIncidentID = 0;
			cFOIncidentType = 0;
			cFOHeatSource = 0;
			cFOCauseOfIgnition = 0;
			cFOContentLoss = 0;
			cAreaAffected = 0;
			cAreaUnit = 0;
			cMaterialType = null;
			_cFireExposureAddress = null;
			cFExpFireReportID = 0;
			cExpHouseNumber = "";
			cExpPrefix = "";
			cExpStreet = "";
			cExpStreetType = "";
			cExpSuffix = "";
			cExpCityCode = "";
			_cFireEquipmentInvolved = null;
			cFEFireReportID = 0;
			cFireEquipment = 0;
			cEquipmentDescription = "";
			_cHumanContributingFactor = null;
			cHFFireReportID = 0;
			cHumanFactor = 0;
			cHFAge = 0;
			cHFGender = 0;
			cHumanFactorDescription = "";
			_cItemContributingFireSpread = null;
			cICFireReportID = 0;
			cItemContributing = 0;
			cItemContributingDescription = "";
			_cPhysicalContributingFactor = null;
			cPCFireReportID = 0;
			cPhysicalFactor = 0;
			cPhysicalFactorDescription = "";
			_cFireSuppressionFactor = null;
			cSFFireReportID = 0;
			cSuppressionFactor = 0;
			cSuppressionFactorDescription = "";
			_cFireSystemsFailure = null;
			cFSysFireReportID = 0;
			cSystemFailure = 0;
			cSystemFailureDescription = "";
			_cFireWebReport = null;
			cWebReportID = 0;
			cWebIncidentID = 0;
			cWebFireReportID = 0;
			cWebIncidentNumber = "";
			cWebReportType = 0;
			cWebGeoLocation = "";
			cWebCityName = "";
			cWebIncidentDate = "";
			cWebFilePath = "";
			cWebLat = "";
			cWebLong = "";
			cWebTransferFlag = 0;
		}

		//********************************************************
		//**    FireReport Class                                **
		//********************************************************
		//**        Methods                                     **
		//**------------------------------------------------------
		//** GetFireStructure(lFireReportID As Long)            **
		//**     Loads Requested Fire Structure Report          **
		//**                                                    **
		//**
		//********************************************************

		//*******************************************************
		//**            Private Class Variables                **
		//*******************************************************

		//FireReport
		public virtual ADORecordSetHelper _cFireReport { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cFireReport
		{
			get
			{
				if (_cFireReport == null)
				{
					_cFireReport = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cFireReport;
			}
			set
			{
				_cFireReport = value;
			}
		}

		public virtual int cFireReportID { get; set; }

		public virtual int cIncidentID { get; set; }

		public virtual int cIncidentType { get; set; }

		public virtual int cPropertyUse { get; set; }

		public virtual int cAreaOfOrigin { get; set; }

		public virtual int cHeatSource { get; set; }

		public virtual int cFirstItemIgnited { get; set; }

		public virtual int cCauseOfIgnition { get; set; }

		public virtual double cPropertyValue { get; set; }

		public virtual double cPropertyLoss { get; set; }

		public virtual double cContentLoss { get; set; }

		//FireStructure
		public virtual ADORecordSetHelper _cFireStructure { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cFireStructure
		{
			get
			{
				if (_cFireStructure == null)
				{
					_cFireStructure = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cFireStructure;
			}
			set
			{
				_cFireStructure = value;
			}
		}

		public virtual int cFSFireReportID { get; set; }

		public virtual int cFloorOfOrigin { get; set; }

		public virtual int cSpecialFloor { get; set; }

		public virtual int cBuildingStatus { get; set; }

		public virtual int cBurnDamage { get; set; }

		public virtual int cSmokeDamage { get; set; }

		public virtual byte cFlagNoAlarm { get; set; }

		public virtual int cFireAlarmType { get; set; }

		public virtual int cDetectorPower { get; set; }

		public virtual int cInitiatingDevice { get; set; }

		public virtual int cAlarmEffectiveness { get; set; }

		public virtual byte cFlagAlarmOperation { get; set; }

		public virtual byte cFlagNoExtinguishSystem { get; set; }

		public virtual int cExtinguishType { get; set; }

		public virtual int cExtinguishEffectiveness { get; set; }

		public virtual byte cFlagExtinguishOperation { get; set; }

		public virtual int cNumberOfStories { get; set; }

		public virtual int cBasementLevels { get; set; }

		public virtual int cConstructionType { get; set; }

		public virtual int cTotalSqFootage { get; set; }

		public virtual int cPeopleOccuping { get; set; }

		public virtual int cBusinessesOccuping { get; set; }

		public virtual int cSqFootBurned { get; set; }

		public virtual int cSqFootSmokeDamaged { get; set; }

		public virtual int cPeopleDisplaced { get; set; }

		public virtual int cBusinessesDisplaced { get; set; }

		public virtual int cJobsLost { get; set; }

		public virtual int cNumberOfUnits { get; set; }

		public virtual byte cFlagRental { get; set; }

		public virtual byte cFlagExposure { get; set; }

		//FireMobileProperty
		public virtual ADORecordSetHelper _cFireMobileProperty { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cFireMobileProperty
		{
			get
			{
				if (_cFireMobileProperty == null)
				{
					_cFireMobileProperty = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cFireMobileProperty;
			}
			set
			{
				_cFireMobileProperty = value;
			}
		}

		public virtual int cFMFireReportID { get; set; }

		public virtual string cVehicleMake { get; set; }

		public virtual string cVehicleModel { get; set; }

		public virtual string cVehicleYear { get; set; }

		public virtual string cVehicleVin { get; set; }

		public virtual int cWaterVesselLength { get; set; }

		public virtual string cMobileMake { get; set; }

		public virtual string cLicenseState { get; set; }

		//FireOutside
		public virtual ADORecordSetHelper _cFireOutside { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cFireOutside
		{
			get
			{
				if (_cFireOutside == null)
				{
					_cFireOutside = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cFireOutside;
			}
			set
			{
				_cFireOutside = value;
			}
		}

		public virtual int cFireOutsideID { get; set; }

		public virtual int cFOIncidentID { get; set; }

		public virtual int cFOIncidentType { get; set; }

		public virtual int cFOHeatSource { get; set; }

		public virtual int cFOCauseOfIgnition { get; set; }

		public virtual double cFOContentLoss { get; set; }

		public virtual int cAreaAffected { get; set; }

		public virtual int cAreaUnit { get; set; }

		public virtual object cMaterialType { get; set; }

		//FireExposureAddress
		public virtual ADORecordSetHelper _cFireExposureAddress { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cFireExposureAddress
		{
			get
			{
				if (_cFireExposureAddress == null)
				{
					_cFireExposureAddress = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cFireExposureAddress;
			}
			set
			{
				_cFireExposureAddress = value;
			}
		}

		public virtual int cFExpFireReportID { get; set; }

		public virtual string cExpHouseNumber { get; set; }

		public virtual string cExpPrefix { get; set; }

		public virtual string cExpStreet { get; set; }

		public virtual string cExpStreetType { get; set; }

		public virtual string cExpSuffix { get; set; }

		public virtual string cExpCityCode { get; set; }

		//Sub Tables
		//FireEquipmentInvolved
		public virtual ADORecordSetHelper _cFireEquipmentInvolved { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cFireEquipmentInvolved
		{
			get
			{
				if (_cFireEquipmentInvolved == null)
				{
					_cFireEquipmentInvolved = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cFireEquipmentInvolved;
			}
			set
			{
				_cFireEquipmentInvolved = value;
			}
		}

		public virtual int cFEFireReportID { get; set; }

		public virtual int cFireEquipment { get; set; }

		public virtual string cEquipmentDescription { get; set; }

		//FireHumanContributingFactor
		public virtual ADORecordSetHelper _cHumanContributingFactor { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cHumanContributingFactor
		{
			get
			{
				if (_cHumanContributingFactor == null)
				{
					_cHumanContributingFactor = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cHumanContributingFactor;
			}
			set
			{
				_cHumanContributingFactor = value;
			}
		}

		public virtual int cHFFireReportID { get; set; }

		public virtual int cHumanFactor { get; set; }

		public virtual int cHFAge { get; set; }

		public virtual int cHFGender { get; set; }

		public virtual string cHumanFactorDescription { get; set; }

		//FireItemContributingFireSpread
		public virtual ADORecordSetHelper _cItemContributingFireSpread { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cItemContributingFireSpread
		{
			get
			{
				if (_cItemContributingFireSpread == null)
				{
					_cItemContributingFireSpread = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cItemContributingFireSpread;
			}
			set
			{
				_cItemContributingFireSpread = value;
			}
		}

		public virtual int cICFireReportID { get; set; }

		public virtual int cItemContributing { get; set; }

		public virtual string cItemContributingDescription { get; set; }

		//FirePhysicalContributingFactor
		public virtual ADORecordSetHelper _cPhysicalContributingFactor { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cPhysicalContributingFactor
		{
			get
			{
				if (_cPhysicalContributingFactor == null)
				{
					_cPhysicalContributingFactor = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cPhysicalContributingFactor;
			}
			set
			{
				_cPhysicalContributingFactor = value;
			}
		}

		public virtual int cPCFireReportID { get; set; }

		public virtual int cPhysicalFactor { get; set; }

		public virtual string cPhysicalFactorDescription { get; set; }

		//FireSuppressionFactor
		public virtual ADORecordSetHelper _cFireSuppressionFactor { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cFireSuppressionFactor
		{
			get
			{
				if (_cFireSuppressionFactor == null)
				{
					_cFireSuppressionFactor = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cFireSuppressionFactor;
			}
			set
			{
				_cFireSuppressionFactor = value;
			}
		}

		public virtual int cSFFireReportID { get; set; }

		public virtual int cSuppressionFactor { get; set; }

		public virtual string cSuppressionFactorDescription { get; set; }

		//FireSystemsFailure
		public virtual ADORecordSetHelper _cFireSystemsFailure { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cFireSystemsFailure
		{
			get
			{
				if (_cFireSystemsFailure == null)
				{
					_cFireSystemsFailure = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cFireSystemsFailure;
			}
			set
			{
				_cFireSystemsFailure = value;
			}
		}

		public virtual int cFSysFireReportID { get; set; }

		public virtual int cSystemFailure { get; set; }

		public virtual string cSystemFailureDescription { get; set; }

		//FireWebReport
		public virtual ADORecordSetHelper _cFireWebReport { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cFireWebReport
		{
			get
			{
				if (_cFireWebReport == null)
				{
					_cFireWebReport = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cFireWebReport;
			}
			set
			{
				_cFireWebReport = value;
			}
		}

		public virtual int cWebReportID { get; set; }

		public virtual int cWebIncidentID { get; set; }

		public virtual int cWebFireReportID { get; set; }

		public virtual string cWebIncidentNumber { get; set; }

		public virtual int cWebReportType { get; set; }

		public virtual string cWebGeoLocation { get; set; }

		public virtual string cWebCityName { get; set; }

		public virtual string cWebIncidentDate { get; set; }

		public virtual string cWebFilePath { get; set; }

		public virtual string cWebLat { get; set; }

		public virtual string cWebLong { get; set; }

		public virtual byte cWebTransferFlag { get; set; }





		//***********************************************
		//**      Class Public Properties              **
		//***********************************************
		//FireReport
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper FireReport
		{
			get
			{
				return cFireReport;
			}
			set
			{
				cFireReport = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int FireReportID
		{
			get
			{
				return cFireReportID;
			}
			set
			{
				cFireReportID = value;
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


		public int HeatSource
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

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int FirstItemIgnited
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

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int CauseOfIgnition
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

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public double PropertyValue
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


		public double PropertyLoss
		{
			get
			{
				return cPropertyLoss;
			}
			set
			{
				cPropertyLoss = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public double ContentLoss
		{
			get
			{
				return cContentLoss;
			}
			set
			{
				cContentLoss = value;
			}
		}


		//FireExposureAddress
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper FireExposureAddress
		{
			get
			{
				return cFireExposureAddress;
			}
			set
			{
				cFireExposureAddress = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int FExpFireReportID
		{
			get
			{
				return cFExpFireReportID;
			}
			set
			{
				cFExpFireReportID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string ExpHouseNumber
		{
			get
			{
				return cExpHouseNumber;
			}
			set
			{
				cExpHouseNumber = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string ExpPrefix
		{
			get
			{
				return cExpPrefix;
			}
			set
			{
				cExpPrefix = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string ExpStreet
		{
			get
			{
				return cExpStreet;
			}
			set
			{
				cExpStreet = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string ExpStreetType
		{
			get
			{
				return cExpStreetType;
			}
			set
			{
				cExpStreetType = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string ExpSuffix
		{
			get
			{
				return cExpSuffix;
			}
			set
			{
				cExpSuffix = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string ExpCityCode
		{
			get
			{
				return cExpCityCode;
			}
			set
			{
				cExpCityCode = value;
			}
		}


		//FireStructure
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper FIRESTRUCTURE
		{
			get
			{
				return cFireStructure;
			}
			set
			{
				cFireStructure = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int FSFireReportID
		{
			get
			{
				return cFSFireReportID;
			}
			set
			{
				cFSFireReportID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int FloorOfOrigin
		{
			get
			{
				return cFloorOfOrigin;
			}
			set
			{
				cFloorOfOrigin = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int SpecialFloor
		{
			get
			{
				return cSpecialFloor;
			}
			set
			{
				cSpecialFloor = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]



		public int BuildingStatus
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

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int BurnDamage
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

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int SmokeDamage
		{
			get
			{
				return cSmokeDamage;
			}
			set
			{
				cSmokeDamage = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte FlagNoAlarm
		{
			get
			{
				return cFlagNoAlarm;
			}
			set
			{
				cFlagNoAlarm = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte FlagNoExtinguishSystem
		{
			get
			{
				return cFlagNoExtinguishSystem;
			}
			set
			{
				cFlagNoExtinguishSystem = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte FlagAlarmOperation
		{
			get
			{
				return cFlagAlarmOperation;
			}
			set
			{
				cFlagAlarmOperation = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte FlagExtinguishOperation
		{
			get
			{
				return cFlagExtinguishOperation;
			}
			set
			{
				cFlagExtinguishOperation = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int FireAlarmType
		{
			get
			{
				return cFireAlarmType;
			}
			set
			{
				cFireAlarmType = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int DetectorPower
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

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int InitiatingDevice
		{
			get
			{
				return cInitiatingDevice;
			}
			set
			{
				cInitiatingDevice = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int AlarmEffectiveness
		{
			get
			{
				return cAlarmEffectiveness;
			}
			set
			{
				cAlarmEffectiveness = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ExtinguishType
		{
			get
			{
				return cExtinguishType;
			}
			set
			{
				cExtinguishType = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ExtinguishEffectiveness
		{
			get
			{
				return cExtinguishEffectiveness;
			}
			set
			{
				cExtinguishEffectiveness = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int NumberOfStories
		{
			get
			{
				return cNumberOfStories;
			}
			set
			{
				cNumberOfStories = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int BasementLevels
		{
			get
			{
				return cBasementLevels;
			}
			set
			{
				cBasementLevels = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ConstructionType
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

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int TotalSqFootage
		{
			get
			{
				return cTotalSqFootage;
			}
			set
			{
				cTotalSqFootage = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int PeopleOccuping
		{
			get
			{
				return cPeopleOccuping;
			}
			set
			{
				cPeopleOccuping = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int BusinessesOccuping
		{
			get
			{
				return cBusinessesOccuping;
			}
			set
			{
				cBusinessesOccuping = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int SqFootBurned
		{
			get
			{
				return cSqFootBurned;
			}
			set
			{
				cSqFootBurned = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int SqFootSmokeDamaged
		{
			get
			{
				return cSqFootSmokeDamaged;
			}
			set
			{
				cSqFootSmokeDamaged = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int PeopleDisplaced
		{
			get
			{
				return cPeopleDisplaced;
			}
			set
			{
				cPeopleDisplaced = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int BusinessesDisplaced
		{
			get
			{
				return cBusinessesDisplaced;
			}
			set
			{
				cBusinessesDisplaced = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int JobsLost
		{
			get
			{
				return cJobsLost;
			}
			set
			{
				cJobsLost = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int NumberOfUnits
		{
			get
			{
				return cNumberOfUnits;
			}
			set
			{
				cNumberOfUnits = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte FlagRental
		{
			get
			{
				return cFlagRental;
			}
			set
			{
				cFlagRental = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte FlagExposure
		{
			get
			{
				return cFlagExposure;
			}
			set
			{
				cFlagExposure = value;
			}
		}



		//FireMobileProperty
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper FireMobileProperty
		{
			get
			{
				return cFireMobileProperty;
			}
			set
			{
				cFireMobileProperty = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int FMFireReportID
		{
			get
			{
				return cFMFireReportID;
			}
			set
			{
				cFMFireReportID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string VehicleMake
		{
			get
			{
				return cVehicleMake;
			}
			set
			{
				cVehicleMake = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string VehicleModel
		{
			get
			{
				return cVehicleModel;
			}
			set
			{
				cVehicleModel = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string VehicleYear
		{
			get
			{
				return cVehicleYear;
			}
			set
			{
				cVehicleYear = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string VehicleVin
		{
			get
			{
				return cVehicleVin;
			}
			set
			{
				cVehicleVin = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int WaterVesselLength
		{
			get
			{
				return cWaterVesselLength;
			}
			set
			{
				cWaterVesselLength = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string MobileMake
		{
			get
			{
				return cMobileMake;
			}
			set
			{
				cMobileMake = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string LicenseState
		{
			get
			{
				return cLicenseState;
			}
			set
			{
				cLicenseState = value;
			}
		}



		//FireOutside
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper FIREOUTSIDE
		{
			get
			{
				return cFireOutside;
			}
			set
			{
				cFireOutside = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int FireOutsideID
		{
			get
			{
				return cFireOutsideID;
			}
			set
			{
				cFireOutsideID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int FOIncidentID
		{
			get
			{
				return cFOIncidentID;
			}
			set
			{
				cFOIncidentID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int FOIncidentType
		{
			get
			{
				return cFOIncidentType;
			}
			set
			{
				cFOIncidentType = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int FOHeatSource
		{
			get
			{
				return cFOHeatSource;
			}
			set
			{
				cFOHeatSource = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int FOCauseOfIgnition
		{
			get
			{
				return cFOCauseOfIgnition;
			}
			set
			{
				cFOCauseOfIgnition = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public double FOContentLoss
		{
			get
			{
				return cFOContentLoss;
			}
			set
			{
				cFOContentLoss = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int AreaAffected
		{
			get
			{
				return cAreaAffected;
			}
			set
			{
				cAreaAffected = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int AreaUnit
		{
			get
			{
				return cAreaUnit;
			}
			set
			{
				cAreaUnit = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int MaterialType
		{
			get
			{
				//UPGRADE_WARNING: (1068) cMaterialType of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				return Convert.ToInt32(cMaterialType);
			}
			set
			{
				cMaterialType = value;
			}
		}


		//Sub Tables
		//FireEquipmentInvolved
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper FireEquipmentInvolved
		{
			get
			{
				return cFireEquipmentInvolved;
			}
			set
			{
				cFireEquipmentInvolved = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int FEFireReportID
		{
			get
			{
				return cFEFireReportID;
			}
			set
			{
				cFEFireReportID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int FireEquipment
		{
			get
			{
				return cFireEquipment;
			}
			set
			{
				cFireEquipment = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string EquipmentDescription
		{
			get
			{
				return cEquipmentDescription;
			}
			set
			{
				cEquipmentDescription = value;
			}
		}


		//FireHumanContributingFactor
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper HumanContributingFactor
		{
			get
			{
				return cHumanContributingFactor;
			}
			set
			{
				cHumanContributingFactor = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int HFFireReportID
		{
			get
			{
				return cHFFireReportID;
			}
			set
			{
				cHFFireReportID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int HumanFactor
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

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int HFAge
		{
			get
			{
				return cHFAge;
			}
			set
			{
				cHFAge = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int HFGender
		{
			get
			{
				return cHFGender;
			}
			set
			{
				cHFGender = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string HumanFactorDescription
		{
			get
			{
				return cHumanFactorDescription;
			}
			set
			{
				cHumanFactorDescription = value;
			}
		}


		//FireItemContributingFireSpread
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper ItemContributingFireSpread
		{
			get
			{
				return cItemContributingFireSpread;
			}
			set
			{
				cItemContributingFireSpread = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ICFireReportID
		{
			get
			{
				return cICFireReportID;
			}
			set
			{
				cICFireReportID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ItemContributing
		{
			get
			{
				return cItemContributing;
			}
			set
			{
				cItemContributing = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string ItemContributingDescription
		{
			get
			{
				return cItemContributingDescription;
			}
			set
			{
				cItemContributingDescription = value;
			}
		}


		//FirePhysicalContributingFactor
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper PhysicalContributingFactor
		{
			get
			{
				return cPhysicalContributingFactor;
			}
			set
			{
				cPhysicalContributingFactor = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int PCFireReportID
		{
			get
			{
				return cPCFireReportID;
			}
			set
			{
				cPCFireReportID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int PhysicalFactor
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

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PhysicalFactorDescription
		{
			get
			{
				return cPhysicalFactorDescription;
			}
			set
			{
				cPhysicalFactorDescription = value;
			}
		}


		//FireSuppressionFactor
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper FireSuppressionFactor
		{
			get
			{
				return cFireSuppressionFactor;
			}
			set
			{
				cFireSuppressionFactor = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int SFFireReportID
		{
			get
			{
				return cSFFireReportID;
			}
			set
			{
				cSFFireReportID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int SuppressionFactor
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

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string SuppressionFactorDescription
		{
			get
			{
				return cSuppressionFactorDescription;
			}
			set
			{
				cSuppressionFactorDescription = value;
			}
		}


		//FireSystemsFailure
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper FireSystemsFailure
		{
			get
			{
				return cFireSystemsFailure;
			}
			set
			{
				cFireSystemsFailure = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int FSysFireReportID
		{
			get
			{
				return cFSysFireReportID;
			}
			set
			{
				cFSysFireReportID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int SystemFailure
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

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string SystemFailureDescription
		{
			get
			{
				return cSystemFailureDescription;
			}
			set
			{
				cSystemFailureDescription = value;
			}
		}



		//FireWebReport
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper FireWebReport
		{
			get
			{
				return cFireWebReport;
			}
			set
			{
				cFireWebReport = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int WebReportID
		{
			get
			{
				return cWebReportID;
			}
			set
			{
				cWebReportID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int WebIncidentID
		{
			get
			{
				return cWebIncidentID;
			}
			set
			{
				cWebIncidentID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int WebFireReportID
		{
			get
			{
				return cWebFireReportID;
			}
			set
			{
				cWebFireReportID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string WebIncidentNumber
		{
			get
			{
				return cWebIncidentNumber;
			}
			set
			{
				cWebIncidentNumber = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int WebReportType
		{
			get
			{
				return cWebReportType;
			}
			set
			{
				cWebReportType = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string WebGeoLocation
		{
			get
			{
				return cWebGeoLocation;
			}
			set
			{
				cWebGeoLocation = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string WebCityName
		{
			get
			{
				return cWebCityName;
			}
			set
			{
				cWebCityName = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string WebIncidentDate
		{
			get
			{
				return cWebIncidentDate;
			}
			set
			{
				cWebIncidentDate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string WebFilePath
		{
			get
			{
				return cWebFilePath;
			}
			set
			{
				cWebFilePath = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string WebLat
		{
			get
			{
				return cWebLat;
			}
			set
			{
				cWebLat = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string WebLong
		{
			get
			{
				return cWebLong;
			}
			set
			{
				cWebLong = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte WebTransferFlag
		{
			get
			{
				return cWebTransferFlag;
			}
			set
			{
				cWebTransferFlag = value;
			}
		}



		//**************************************************
		//**            Class Public Methods              **
		//**************************************************

		public int GetFireReport(int lFireReportID)
		{
			//Retrieve FireReport record and Load date into
			//Fire Report class variables
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_FireReport " + lFireReportID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					//Load Class  Variables
					cFireReportID = Convert.ToInt32(oRec["fire_report_id"]);
					cIncidentID = Convert.ToInt32(oRec["incident_id"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cIncidentType = Convert.ToInt32(IncidentMain.GetVal(oRec["incident_type_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cPropertyUse = Convert.ToInt32(IncidentMain.GetVal(oRec["property_use_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cAreaOfOrigin = Convert.ToInt32(IncidentMain.GetVal(oRec["area_of_origin_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cHeatSource = Convert.ToInt32(IncidentMain.GetVal(oRec["heat_source_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cFirstItemIgnited = Convert.ToInt32(IncidentMain.GetVal(oRec["first_item_ignited_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cCauseOfIgnition = Convert.ToInt32(IncidentMain.GetVal(oRec["cause_of_ignition_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cPropertyValue = Convert.ToDouble(IncidentMain.GetVal(oRec["property_value"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cPropertyLoss = Convert.ToDouble(IncidentMain.GetVal(oRec["property_loss"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cContentLoss = Convert.ToDouble(IncidentMain.GetVal(oRec["content_loss"]));
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

		public int GetFireExposureAddress(int lFireReportID)
		{
			//Retrieve FireExposureAddress record and Load data into
			//FireMobileProperty class variables
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_FireExposureAddress " + lFireReportID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					//Load Class  Variables
					cFExpFireReportID = Convert.ToInt32(oRec["fire_report_id"]);
					cExpHouseNumber = IncidentMain.Clean(oRec["addr_house_number"]);
					cExpPrefix = IncidentMain.Clean(oRec["addr_prefix"]);
					cExpStreet = IncidentMain.Clean(oRec["addr_street"]);
					cExpStreetType = IncidentMain.Clean(oRec["addr_street_type"]);
					cExpSuffix = IncidentMain.Clean(oRec["addr_suffix"]);
					cExpCityCode = IncidentMain.Clean(oRec["city_code"]);
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


		//***************************************
		//Insert, Update, Delete
		//Main FireReport Tables
		//***************************************

		//Insert New Records Functions
		//These Functions assume that All necessary field values
		//have been set in the Class variables

		public int AddFireReport()
		{
			//Add New Fire Report Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spInsert_FireReport " + cIncidentID.ToString() + "," + cIncidentType.ToString() + ",";
				if (cPropertyUse == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cPropertyUse.ToString() + ",";
				}
				if (cAreaOfOrigin == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cAreaOfOrigin.ToString() + ",";
				}
				if (cHeatSource == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cHeatSource.ToString() + ",";
				}
				if (cFirstItemIgnited == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cFirstItemIgnited.ToString() + ",";
				}
				if (cCauseOfIgnition == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cCauseOfIgnition.ToString() + ",";
				}
				SqlString = SqlString + cPropertyValue.ToString() + "," + cPropertyLoss.ToString() + "," + cContentLoss.ToString();
				oCmd.CommandText = SqlString;
				oCmd.ExecuteNonQuery();
				oCmd.CommandText = "spSelect_NewFireReport";
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (GetFireReport(Convert.ToInt32(oRec[0])) != 0)
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

		public int AddFireExposureAddress()
		{
			//Add New FireExposureAddress Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";
			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spInsert_FireExposureAddress " + cFExpFireReportID.ToString() + ",'" + cExpHouseNumber + "',";
				if (cExpPrefix == "")
				{
					SqlString = SqlString + "NULL,'" + Strings.Replace(cExpStreet, "'", "''", 1, -1, CompareMethod.Binary) + "',";
				}
				else
				{
					SqlString = SqlString + "'" + cExpPrefix + "','" + Strings.Replace(cExpStreet, "'", "''", 1, -1, CompareMethod.Binary) + "',";
				}
				if (cExpStreetType == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cExpStreetType + "',";
				}
				if (cExpSuffix == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cExpSuffix + "',";
				}
				if (cExpCityCode == "")
				{
					SqlString = SqlString + "NULL";
				}
				else
				{
					SqlString = SqlString + "'" + cExpCityCode + "'";
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


		//Update Functions - FireReport Tables
		//Uses values from Private Class Variables

		public int UpdateFireReport()
		{
			//Update all fields of FireReport Record
			//ReportLog and ReportLogHistory updated by stored procedure
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spUpdate_FireReport " + cFireReportID.ToString() + "," + cIncidentID.ToString() + "," + cIncidentType.ToString() + ",";
				if (cPropertyUse == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cPropertyUse.ToString() + ",";
				}
				if (cAreaOfOrigin == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cAreaOfOrigin.ToString() + ",";
				}
				if (cHeatSource == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cHeatSource.ToString() + ",";
				}
				if (cFirstItemIgnited == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cFirstItemIgnited.ToString() + ",";
				}
				if (cCauseOfIgnition == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cCauseOfIgnition.ToString() + ",";
				}
				SqlString = SqlString + cPropertyValue.ToString() + "," + cPropertyLoss.ToString() + "," + cContentLoss.ToString();
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

		public int UpdateFireExposureAddress()
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
				SqlString = "spUpdate_FireExposureAddress " + cFExpFireReportID.ToString() + ",'" + cExpHouseNumber + "',";
				if (cExpPrefix == "")
				{
					SqlString = SqlString + "NULL,'" + Strings.Replace(cExpStreet, "'", "''", 1, -1, CompareMethod.Binary) + "',";
				}
				else
				{
					SqlString = SqlString + "'" + cExpPrefix + "','" + Strings.Replace(cExpStreet, "'", "''", 1, -1, CompareMethod.Binary) + "',";
				}
				if (cExpStreetType == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cExpStreetType + "',";
				}
				if (cExpSuffix == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cExpSuffix + "',";
				}
				if (cExpCityCode == "")
				{
					SqlString = SqlString + "NULL";
				}
				else
				{
					SqlString = SqlString + "'" + cExpCityCode + "'";
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


		//Delete Report Functions:
		//!!! Note:  All Records from Related tables must always be deleted
		//!!!        Prior to deleting Parent (this is automatically done in following functions)
		//!!!Note:   These Functions used ONLY if:
		//!!!        Fire Type is changed After sub Report record created
		//!!!            (ie. Structure fire changed to Outside fire)
		//!!!        Incident Type is changed from Fire to other Incident Class
		//!!!        After FireReport record is created
		//!!!            (ie. Fire Incident changed to Rupture or Hazmat)
		//!!!        $$$Caution- Use only when Fire REMOVED  as Situation Found
		//!!!            as Multiple Situations are allowable

		public int DeleteFireReport(ref int lFireReportID)
		{
			//Delete FireReport and all Dependent records
			//ReportLog and ReportLogHistory updated by stored procedure
			//Parameter Required to avoid accidental execution
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spDelete_FireReport";
				oCmd.ExecuteNonQuery(new object[] { lFireReportID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int GetFireStructure(int lFireReportID)
		{
			//Retrieve Fire Structure Report and Load data into
			//Fire Structure  variables

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_FireStructure " + lFireReportID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					//Load Class  Variables
					cFSFireReportID = Convert.ToInt32(oRec["fire_report_id"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cFloorOfOrigin = Convert.ToInt32(IncidentMain.GetVal(oRec["floor_of_origin"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cSpecialFloor = Convert.ToInt32(IncidentMain.GetVal(oRec["special_floor_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cBuildingStatus = Convert.ToInt32(IncidentMain.GetVal(oRec["building_status_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cBurnDamage = Convert.ToInt32(IncidentMain.GetVal(oRec["burn_damage_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cSmokeDamage = Convert.ToInt32(IncidentMain.GetVal(oRec["smoke_damage_code"]));
					cFlagNoAlarm = Convert.ToByte(oRec["flag_no_alarm_involved"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cFireAlarmType = Convert.ToInt32(IncidentMain.GetVal(oRec["fire_alarm_type_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cDetectorPower = Convert.ToInt32(IncidentMain.GetVal(oRec["detector_power_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cInitiatingDevice = Convert.ToInt32(IncidentMain.GetVal(oRec["alarm_initiating_device_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cAlarmEffectiveness = Convert.ToInt32(IncidentMain.GetVal(oRec["alarm_effectiveness"]));
					cFlagAlarmOperation = Convert.ToByte(oRec["flag_alarm_operation"]);
					cFlagNoExtinguishSystem = Convert.ToByte(oRec["flag_no_extinguishing_system_involved"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cExtinguishType = Convert.ToInt32(IncidentMain.GetVal(oRec["extinguisher_type_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cExtinguishEffectiveness = Convert.ToInt32(IncidentMain.GetVal(oRec["extinguisher_effectiveness"]));
					cFlagExtinguishOperation = Convert.ToByte(oRec["flag_extinguisher_operation"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cNumberOfStories = Convert.ToInt32(IncidentMain.GetVal(oRec["number_of_stories"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cBasementLevels = Convert.ToInt32(IncidentMain.GetVal(oRec["basement_levels"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cConstructionType = Convert.ToInt32(IncidentMain.GetVal(oRec["construction_type_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cTotalSqFootage = Convert.ToInt32(IncidentMain.GetVal(oRec["total_sq_footage"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cPeopleOccuping = Convert.ToInt32(IncidentMain.GetVal(oRec["number_of_people_occuping"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cBusinessesOccuping = Convert.ToInt32(IncidentMain.GetVal(oRec["number_of_business_occuping"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cSqFootBurned = Convert.ToInt32(IncidentMain.GetVal(oRec["sq_foot_burned"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cSqFootSmokeDamaged = Convert.ToInt32(IncidentMain.GetVal(oRec["sq_foot_smoke_damaged"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cPeopleDisplaced = Convert.ToInt32(IncidentMain.GetVal(oRec["number_people_displaced"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cBusinessesDisplaced = Convert.ToInt32(IncidentMain.GetVal(oRec["number_business_displaced"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cJobsLost = Convert.ToInt32(IncidentMain.GetVal(oRec["number_jobs_lost"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cNumberOfUnits = Convert.ToInt32(IncidentMain.GetVal(oRec["number_units"]));
					cFlagRental = Convert.ToByte(oRec["flag_rental"]);
					cFlagExposure = Convert.ToByte(oRec["flag_exposure"]);
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


		public int AddFireStructure()
		{
			//Add New FireStructure Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spInsert_FireStructure " + cFSFireReportID.ToString() + "," + cFloorOfOrigin.ToString() + "," + cSpecialFloor.ToString() + ",";
				if (cBuildingStatus == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cBuildingStatus.ToString() + ",";
				}
				if (cBurnDamage == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cBurnDamage.ToString() + ",";
				}
				if (cSmokeDamage == 0)
				{
					SqlString = SqlString + "NULL," + cFlagNoAlarm.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cSmokeDamage.ToString() + "," + cFlagNoAlarm.ToString() + ",";
				}
				if (cFireAlarmType == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cFireAlarmType.ToString() + ",";
				}
				if (cDetectorPower == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cDetectorPower.ToString() + ",";
				}
				if (cAlarmEffectiveness == 0)
				{
					SqlString = SqlString + "NULL," + cFlagAlarmOperation.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cAlarmEffectiveness.ToString() + "," + cFlagAlarmOperation.ToString() + ",";
				}
				if (cInitiatingDevice == 0)
				{
					SqlString = SqlString + "NULL," + cFlagNoExtinguishSystem.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cInitiatingDevice.ToString() + "," + cFlagNoExtinguishSystem.ToString() + ",";
				}
				if (cExtinguishType == 0)
				{
					SqlString = SqlString + "NULL," + cFlagExtinguishOperation.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cExtinguishType.ToString() + "," + cFlagExtinguishOperation.ToString() + ",";
				}
				if (cExtinguishEffectiveness == 0)
				{
					SqlString = SqlString + "NULL," + cNumberOfStories.ToString() + "," + cBasementLevels.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cExtinguishEffectiveness.ToString() + "," + cNumberOfStories.ToString() + "," + cBasementLevels.ToString() + ",";
				}
				if (cConstructionType == 0)
				{
					SqlString = SqlString + "NULL," + cTotalSqFootage.ToString() + "," + cPeopleOccuping.ToString() + "," + cBusinessesOccuping.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cConstructionType.ToString() + "," + cTotalSqFootage.ToString() + "," + cPeopleOccuping.ToString() + "," + cBusinessesOccuping.ToString() + ",";
				}
				SqlString = SqlString + cSqFootBurned.ToString() + "," + cSqFootSmokeDamaged.ToString() + "," + cPeopleDisplaced.ToString() + "," + cBusinessesDisplaced.ToString() + ",";
				SqlString = SqlString + cJobsLost.ToString() + "," + cNumberOfUnits.ToString() + "," + cFlagRental.ToString() + "," + cFlagExposure.ToString();

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

		public int UpdateFireStructure()
		{
			//Update FireStructure Record
			//ReportLog and ReportLogHistory updated by stored procedure
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";


			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spUpdate_FireStructure " + cFSFireReportID.ToString() + "," + cFloorOfOrigin.ToString() + "," + cSpecialFloor.ToString() + ",";
				if (cBuildingStatus == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cBuildingStatus.ToString() + ",";
				}
				if (cBurnDamage == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cBurnDamage.ToString() + ",";
				}
				if (cSmokeDamage == 0)
				{
					SqlString = SqlString + "NULL," + cFlagNoAlarm.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cSmokeDamage.ToString() + "," + cFlagNoAlarm.ToString() + ",";
				}
				if (cFireAlarmType == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cFireAlarmType.ToString() + ",";
				}
				if (cDetectorPower == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cDetectorPower.ToString() + ",";
				}
				if (cAlarmEffectiveness == 0)
				{
					SqlString = SqlString + "NULL," + cFlagAlarmOperation.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cAlarmEffectiveness.ToString() + "," + cFlagAlarmOperation.ToString() + ",";
				}
				if (cInitiatingDevice == 0)
				{
					SqlString = SqlString + "NULL," + cFlagNoExtinguishSystem.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cInitiatingDevice.ToString() + "," + cFlagNoExtinguishSystem.ToString() + ",";
				}
				if (cExtinguishType == 0)
				{
					SqlString = SqlString + "NULL," + cFlagExtinguishOperation.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cExtinguishType.ToString() + "," + cFlagExtinguishOperation.ToString() + ",";
				}
				if (cExtinguishEffectiveness == 0)
				{
					SqlString = SqlString + "NULL," + cNumberOfStories.ToString() + "," + cBasementLevels.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cExtinguishEffectiveness.ToString() + "," + cNumberOfStories.ToString() + "," + cBasementLevels.ToString() + ",";
				}
				if (cConstructionType == 0)
				{
					SqlString = SqlString + "NULL," + cTotalSqFootage.ToString() + "," + cPeopleOccuping.ToString() + "," + cBusinessesOccuping.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cConstructionType.ToString() + "," + cTotalSqFootage.ToString() + "," + cPeopleOccuping.ToString() + "," + cBusinessesOccuping.ToString() + ",";
				}
				SqlString = SqlString + cSqFootBurned.ToString() + "," + cSqFootSmokeDamaged.ToString() + "," + cPeopleDisplaced.ToString() + "," + cBusinessesDisplaced.ToString() + ",";
				SqlString = SqlString + cJobsLost.ToString() + "," + cNumberOfUnits.ToString() + "," + cFlagRental.ToString() + "," + cFlagExposure.ToString();

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

		public int DeleteFireStructure(ref int lFireReportID)
		{
			//Delete FireStructure and all Dependent records
			//ReportLog and ReportLogHistory updated by stored procedure
			//Parameter Required to avoid accidental execution
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spDelete_FireStructure";
				oCmd.ExecuteNonQuery(new object[] { lFireReportID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int GetFireMobileProperty(int lFireReportID)
		{
			//Retrieve FireMobileProperty record and Load data into
			//FireMobileProperty class variables
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_FireMobileProperty " + lFireReportID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					//Load Class  Variables
					cFMFireReportID = Convert.ToInt32(oRec["fire_report_id"]);
					cVehicleMake = IncidentMain.Clean(oRec["vehicle_make"]);
					cVehicleModel = IncidentMain.Clean(oRec["vehicle_model"]);
					cVehicleYear = IncidentMain.Clean(oRec["vehicle_year"]);
					cVehicleVin = IncidentMain.Clean(oRec["vehicle_vin"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cWaterVesselLength = Convert.ToInt32(IncidentMain.GetVal(oRec["water_vessel_length"]));
					cMobileMake = IncidentMain.Clean(oRec["mobile_make_code"]);
					cLicenseState = IncidentMain.Clean(oRec["license_state"]);
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


		public int AddFireMobileProperty()
		{
			//Add New FireMobileProperty Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spInsert_FireMobileProperty " + cFMFireReportID.ToString() + ",'";
				SqlString = SqlString + cVehicleMake + "','" + cVehicleModel + "','";
				SqlString = SqlString + cVehicleVin + "','" + cVehicleYear + "'," + cWaterVesselLength.ToString();
				SqlString = SqlString + ",'" + cMobileMake + "','" + cLicenseState + "'";

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


		public int UpdateFireMobileProperty()
		{
			//Update FireMobileProperty Record
			//ReportLog and ReportLogHistory updated by stored procedure
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spUpdate_FireMobileProperty " + cFMFireReportID.ToString() + ",'";
				SqlString = SqlString + cVehicleMake + "','" + cVehicleModel + "','";
				SqlString = SqlString + cVehicleVin + "','" + cVehicleYear + "'," + cWaterVesselLength.ToString();
				SqlString = SqlString + ",'" + cMobileMake + "','" + cLicenseState + "'";

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

		public int DeleteFireMobileProperty(ref int lFireReportID)
		{
			//Delete FireMobileProperty and all Dependent records
			//ReportLog and ReportLogHistory updated by stored procedure
			//Parameter Required to avoid accidental execution
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spDelete_FireMobileProperty";
				oCmd.ExecuteNonQuery(new object[] { lFireReportID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int GetFireOutside(int lOutsideFireID)
		{
			//Retrieve FireOutside record and Load data into
			//FireOutside class variables
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_FireOutside " + lOutsideFireID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					//Load Class  Variables
					cFireOutsideID = Convert.ToInt32(oRec["outside_fire_id"]);
					cFOIncidentID = Convert.ToInt32(oRec["incident_id"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cFOIncidentType = Convert.ToInt32(IncidentMain.GetVal(oRec["incident_type_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cFOHeatSource = Convert.ToInt32(IncidentMain.GetVal(oRec["heat_source_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cFOCauseOfIgnition = Convert.ToInt32(IncidentMain.GetVal(oRec["cause_of_ignition_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cFOContentLoss = Convert.ToDouble(IncidentMain.GetVal(oRec["content_loss"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cAreaAffected = Convert.ToInt32(IncidentMain.GetVal(oRec["area_affected"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cAreaUnit = Convert.ToInt32(IncidentMain.GetVal(oRec["area_unit_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to Scalar. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cMaterialType = IncidentMain.GetVal(oRec["material_type_code"]);
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

		public int AddFireOutside()
		{
			//Add New FireOutside Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			ADORecordSetHelper oRec = null;
			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spInsert_FireOutside " + cFOIncidentID.ToString() + "," + cFOIncidentType.ToString() + ",";
				//Test for Null values
				if (cFOHeatSource == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cFOHeatSource.ToString() + ",";
				}
				if (cFOCauseOfIgnition == 0)
				{
					SqlString = SqlString + "NULL," + cFOContentLoss.ToString() + "," + cAreaAffected.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cFOCauseOfIgnition.ToString() + "," + cFOContentLoss.ToString() + "," + cAreaAffected.ToString() + ",";
				}
				if (cAreaUnit == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cAreaUnit.ToString() + ",";
				}
				//UPGRADE_WARNING: (1068) cMaterialType of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				if (Convert.ToDouble(cMaterialType) == 0)
				{
					SqlString = SqlString + "NULL";
				}
				else
				{
					//UPGRADE_WARNING: (1068) cMaterialType of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					SqlString = SqlString + Convert.ToString(cMaterialType);
				}
				oCmd.CommandText = SqlString;
				oCmd.ExecuteNonQuery();
				oCmd.CommandText = "spSelect_NewFireOutsideReport";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (GetFireOutside(Convert.ToInt32(oRec[0])) != 0)
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

		public int UpdateFireOutside()
		{
			//Update FireOutside Record
			//ReportLog and ReportLogHistory updated by stored procedure
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spUpdate_FireOutside " + cFireOutsideID.ToString() + "," + cFOIncidentID.ToString() + "," + cFOIncidentType.ToString() + ",";
				//Test for Null values
				if (cFOHeatSource == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cFOHeatSource.ToString() + ",";
				}
				if (cFOCauseOfIgnition == 0)
				{
					SqlString = SqlString + "NULL," + cFOContentLoss.ToString() + "," + cAreaAffected.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cFOCauseOfIgnition.ToString() + "," + cFOContentLoss.ToString() + "," + cAreaAffected.ToString() + ",";
				}
				if (cAreaUnit == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cAreaUnit.ToString() + ",";
				}
				//UPGRADE_WARNING: (1068) cMaterialType of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				if (Convert.ToDouble(cMaterialType) == 0)
				{
					SqlString = SqlString + "NULL";
				}
				else
				{
					//UPGRADE_WARNING: (1068) cMaterialType of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					SqlString = SqlString + Convert.ToString(cMaterialType);
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

		public int DeleteFireOutside(ref int lFireReportID)
		{
			//Delete FireOutside and all Dependent records
			//ReportLog and ReportLogHistory updated by stored procedure
			//Parameter Required to avoid accidental execution
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spDelete_FireOutside";
				oCmd.ExecuteNonQuery(new object[] { lFireReportID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		//Retrieve Recordset Objects for FireReport Subtables
		//For Current FireReport: cFireReportID
		//!! GetFireReport needs to be executed prior to calling these functions

		public int GetFireEquipmentInvolved(int lFireReportID)
		{
			//Retrieve FireEquipmentInvolved Recordset
			//For Current FireStructure Report
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_FireEquipmentInvolved " + lFireReportID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cFireEquipmentInvolved = oRec;
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

		public int GetFireHumanContributingFactor(int lFireReportID)
		{
			//Retrieve FireHumanContributingFactor Recordset
			//For Current FireReport
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_FireHumanContributingFactor " + lFireReportID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cHumanContributingFactor = oRec;
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

		public bool GetFireItemContributingFireSpread(int lFireReportID)
		{
			//Retrieve FireItemContributingFireSpread Recordset
			//For Current FireStructure Report
			bool result = false;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_FireItemContributingFireSpread " + lFireReportID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cItemContributingFireSpread = oRec;
					return true;
				}
				else
				{
					return false;
				}
			}
			catch
			{

				result = false;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public bool GetFirePhysicalContributingFactor(int lFireReportID)
		{
			//Retrieve FirePhysicalContributingFactor Recordset
			//For Current FireReport
			bool result = false;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_FirePhysicalContributingFactor " + lFireReportID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cPhysicalContributingFactor = oRec;
					return true;
				}
				else
				{
					return false;
				}
			}
			catch
			{

				result = false;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public bool GetFireSuppressionFactor(int lFireReportID)
		{
			//Retrieve FireSuppressionFactor Recordset
			//For Current FireReport
			bool result = false;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_FireSuppressionFactor " + lFireReportID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cFireSuppressionFactor = oRec;
					return true;
				}
				else
				{
					return false;
				}
			}
			catch
			{

				result = false;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public int GetFireSystemsFailure(int lFireReportID, string SysType)
		{
			//Retrieve System Failure records for current FireStructure report
			//and specified System Type
			//!! Alarm System Failures = "A", Extinguishing System Failures = "E"
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_SystemFailure " + lFireReportID.ToString() + ",'" + SysType + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cFireSystemsFailure = oRec;
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
		//*********************************
		//Insert,Delete Fire Sub Table Records
		//*********************************
		//Insert New Fire Sub Table Records Functions

		public int AddFireEquipmentInvolved()
		{
			//Add new FireEquipmentInvolved Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spInsert_FireEquipmentInvolved";
				oCmd.ExecuteNonQuery(new object[] { cFEFireReportID, cFireEquipment });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int AddFireHumanContributingFactor()
		{
			//Add new FireHumanContributingFactor Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spInsert_FireHumanContributingFactor " + cHFFireReportID.ToString() + ",";
				SqlString = SqlString + cHumanFactor.ToString() + ",";
				if (cHFAge == 0)
				{
					SqlString = SqlString + "NULL,NULL";
				}
				else
				{
					SqlString = SqlString + cHFAge.ToString() + ",";
					if (cHFGender != 0)
					{
						SqlString = SqlString + cHFGender.ToString();
					}
					else
					{
						SqlString = SqlString + "NULL";
					}
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

		public int AddFireItemContributingFireSpread()
		{
			//Add new FireItemContributingFireSpread Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spInsert_FireItemContributingFireSpread";
				oCmd.ExecuteNonQuery(new object[] { cICFireReportID, cItemContributing });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int AddFirePhysicalContributingFactor()
		{
			//Add new FirePhysicalContributingFactor Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spInsert_FirePhysicalContributingFactor";
				oCmd.ExecuteNonQuery(new object[] { cPCFireReportID, cPhysicalFactor });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int AddFireSuppressionFactor()
		{
			//Add new FireSuppressionFactor Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spInsert_FireSuppressionFactor";
				oCmd.ExecuteNonQuery(new object[] { cSFFireReportID, cSuppressionFactor });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int AddFireSystemsFailure()
		{
			//Add new FireSystemsFailure Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spInsert_FireSystemsFailure";
				oCmd.ExecuteNonQuery(new object[] { cFSysFireReportID, cSystemFailure });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		//Delete All Records from Fire Sub Table for Current Report

		public int DeleteFireEquipmentInvolved(ref int lFireReportID)
		{
			//Delete all FireEquipmentInvolved Records for Current FireReport
			//!!!Note:  Updates done as two steps:
			//           Delete all Current Records
			//           Add Current Selections

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spDelete_FireEquipmentInvolved";
				oCmd.ExecuteNonQuery(new object[] { lFireReportID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteFireHumanContributingFactor(ref int lFireReportID)
		{
			//Delete all FireHumanContributingFactor Records for Current FireReport
			//!!!Note:  Updates done as two steps:
			//           Delete all Current Records
			//           Add Current Selections

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spDelete_FireHumanContributingFactor";
				oCmd.ExecuteNonQuery(new object[] { lFireReportID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteFireItemContributingFireSpread(ref int lFireReportID)
		{
			//Delete all FireItemContributingFireSpread Records for Current FireReport
			//!!!Note:  Updates done as two steps:
			//           Delete all Current Records
			//           Add Current Selections

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spDelete_FireItemContributingFireSpread";
				oCmd.ExecuteNonQuery(new object[] { lFireReportID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteFirePhysicalContributingFactor(ref int lFireReportID)
		{
			//Delete all FirePhysicalContributingFactor Records for Current FireReport
			//!!!Note:  Updates done as two steps:
			//           Delete all Current Records
			//           Add Current Selections

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spDelete_FirePhysicalContributingFactor";
				oCmd.ExecuteNonQuery(new object[] { lFireReportID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteFireSuppressionFactor(ref int lFireReportID)
		{
			//Delete all FireSuppressionFactor Records for Current FireReport
			//!!!Note:  Updates done as two steps:
			//           Delete all Current Records
			//           Add Current Selections

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spDelete_FireSuppressionFactor";
				oCmd.ExecuteNonQuery(new object[] { lFireReportID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteFireSystemsFailure(ref int lFireReportID)
		{
			//Delete all FireSystemsFailure Records for Current FireReport
			//!!!Note:  Updates done as two steps:
			//           Delete all Current Records
			//           Add Current Selections
			//!!!Note:  This Function will delete both Alarm and Extinguishing Systems
			//           Records.  You must Insert selections from
			//           both Types as necessary once this function is called

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spDelete_FireSystemsFailure";
				oCmd.ExecuteNonQuery(new object[] { lFireReportID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int GetFireOutsideReport(int lOutsideFireID)
		{

			//Retrieve Fire Outside Record
			//Formatted for Reporting
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_FireOutside " + lOutsideFireID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cFireOutside = oRec;
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

		public int GetFireStructureReport(int lFireReportID)
		{
			//Retrieve Fire Structure Record
			//Formatted for Reporting
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_FireStructure " + lFireReportID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cFireStructure = oRec;
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

		public int GetFireMobileReport(int lFireReportID)
		{
			//Retrieve Fire Mobile Record
			//Formatted for Reporting
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_FireMobile " + lFireReportID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cFireMobileProperty = oRec;
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

		public int GetFireBasicReport(int lFireReportID)
		{
			//Retrieve Basic Fire Record
			//Formatted for Reporting
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_FireBasic " + lFireReportID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cFireReport = oRec;
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

		public int GetPhysicalContributingFactorReport(int lFireReportID)
		{
			//Retrieve Fire Physical Contributing Factor Records
			//Formatted for Reporting
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_FirePhysicalContribFactor " + lFireReportID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cPhysicalContributingFactor = oRec;
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

		public int GetHumanContributingFactorReport(int lFireReportID)
		{
			//Retrieve Fire Human Contributing Factor Records
			//Formatted for Reporting
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_FireHumanContribFactor " + lFireReportID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cHumanContributingFactor = oRec;
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

		public int GetItemContribFireSpreadReport(int lFireReportID)
		{
			//Retrieve Fire Item Contributing to Fire Spread Records
			//Formatted for Reporting
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_FireItemContribFireSpread " + lFireReportID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cItemContributingFireSpread = oRec;
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

		public int GetSuppressionFactorReport(int lFireReportID)
		{
			//Retrieve Fire Suppression Factor Records
			//Formatted for Reporting
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_FireSuppressionFactor " + lFireReportID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cFireSuppressionFactor = oRec;
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

		public int GetFireMobilePropertyReport(int lFireReportID)
		{
			//Retrieve Fire Mobile Property Records
			//Formatted for Reporting
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_FireMobileProperty " + lFireReportID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cFireMobileProperty = oRec;
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

		public int GetFireSystemsFailureReport(int lFireReportID, string iType)
		{

			//Retrieve Fire System Failure Records
			//Formatted for Reporting
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_FireSystemProblems " + lFireReportID.ToString() + ",'" + iType + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cFireSystemsFailure = oRec;
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

		public int GetFireEquipmentInvolvedReport(int lFireReportID)
		{
			//Retrieve Fire Equipment Involved Records
			//Formatted for Reporting
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_FireEquipmentInvolved " + lFireReportID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cFireEquipmentInvolved = oRec;
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
			}
			return result;
		}


		public int GetExposureCount(int lIncidentID)
		{
			//Retrieve count of Fire Structure Exposures
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_FireExposureCount " + lIncidentID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					return Convert.ToInt32(oRec["exp_count"]);
				}
				else
				{
					return 0;
				}
			}
			catch
			{

				result = 0;
			}
			return result;
		}


		public int GetExposureNumber(int lFireID)
		{
			//Retrieve nfirs exposure number of Fire Structure Report
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_ExposureNumber " + lFireID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					return Convert.ToInt32(oRec["nfirs_exposure_number"]);
				}
				else
				{
					return 0;
				}
			}
			catch
			{

				result = 0;
			}
			return result;
		}

		public int GetFireWebReport(int lWebIncID, int lFireReportID)
		{
			//Retrieve FireWebReport record and Load date into
			//Fire Web Report class variables

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_FireWebReport " + lWebIncID.ToString() + ", " + lFireReportID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					//Load Class  Variables
					cWebReportID = Convert.ToInt32(oRec["web_report_id"]);
					cWebIncidentID = Convert.ToInt32(oRec["incident_id"]);
					cWebFireReportID = Convert.ToInt32(oRec["fire_report_id"]);
					cWebIncidentNumber = IncidentMain.Clean(oRec["incident_number"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cWebReportType = Convert.ToInt32(IncidentMain.GetVal(oRec["report_type"]));
					cWebGeoLocation = IncidentMain.Clean(oRec["geo_location"]);
					cWebCityName = IncidentMain.Clean(oRec["city_name"]);
					System.DateTime TempDate = DateTime.FromOADate(0);
					cWebIncidentDate = (DateTime.TryParse(IncidentMain.Clean(oRec["date_incident_created"]), out TempDate)) ? TempDate.ToString("MM/dd/yyyy HH:mm:ss") : IncidentMain.Clean(oRec["date_incident_created"]);
					cWebFilePath = IncidentMain.Clean(oRec["file_path"]);
					cWebLat = IncidentMain.Clean(oRec["lat"]);
					cWebLong = IncidentMain.Clean(oRec["long"]);
					cWebTransferFlag = Convert.ToByte(oRec["transfer_flag"]);
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


		public int UpdateFireWebReport()
		{
			//Update all fields of FireWebReport Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;

				SqlString = "spUpdate_FireWebReport " + cWebReportID.ToString() + "," + cWebIncidentID.ToString() + "," + cWebFireReportID.ToString() + ",";
				SqlString = SqlString + "'" + cWebIncidentNumber + "',";

				if (cWebReportType == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cWebReportType.ToString() + ",'";
				}
				SqlString = SqlString + cWebGeoLocation + "','" + cWebCityName + "','";
				SqlString = SqlString + cWebIncidentDate + "','" + cWebFilePath + "','";
				SqlString = SqlString + cWebLat + "','" + cWebLong + "'," + cWebTransferFlag.ToString();

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

		public int AddFireWebReport()
		{
			//Add New Fire Web Report Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spInsert_FireWebReport " + cWebIncidentID.ToString() + "," + cWebFireReportID.ToString() + ",";
				SqlString = SqlString + "'" + cWebIncidentNumber + "',";
				if (cWebReportType == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cWebReportType.ToString() + ",'";
				}
				SqlString = SqlString + cWebGeoLocation + "','" + cWebCityName + "','";
				SqlString = SqlString + cWebIncidentDate + "','" + cWebFilePath + "','";
				SqlString = SqlString + cWebLat + "','" + cWebLong + "'," + cWebTransferFlag.ToString();

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

		public string UniqueID { get; set; }

		public UpgradeHelpers.Interfaces.IViewManager ViewManager { get; set; }

		public UpgradeHelpers.Interfaces.IIocContainer Container { get; set; }

	}
}