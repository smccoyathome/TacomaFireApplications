using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident
{

	public class clsRupture
		: UpgradeHelpers.Interfaces.IDependentModel, UpgradeHelpers.Interfaces.ICreatesObjects, UpgradeHelpers
		.Interfaces.IInteractsWithView, UpgradeHelpers.Interfaces.IInitializableCommon, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(clsRupture));
		}

		void UpgradeHelpers.Interfaces.IInitializableCommon.Common()
		{
			_cRuptureExplosion = null;
			cRuptureID = 0;
			cRuptureIncidentID = 0;
			cRuptureIncidentType = 0;
			cRupturePropertyUseCode = 0;
			cRuptureAreaOfOrigin = 0;
			cRupturePropertyValue = 0;
			cRupturePropertyLoss = 0;
			cRuptureContentLoss = 0;
			_cRuptureMobileRS = null;
			cRuptureMobileRuptureID = 0;
			cVehicleMake = "";
			cVehicleModel = "";
			cVehicleYear = "";
			cVehicleVin = "";
			cWaterVesseLength = 0;
			cMobileMake = "";
			cLicenseState = "";
			_cRuptureStructureRS = null;
			cRuptureStructureRuptureID = 0;
			cFloorOfOrigin = 0;
			cSpecialFloor = 0;
			cBuildingStatus = 0;
			cNumberOfStories = 0;
			cBasementLevels = 0;
			cConstructionType = 0;
			cTotalSqFootage = 0;
			cNumberPeopleOccuping = 0;
			cNumberBusinessOccuping = 0;
			cSqFootDamaged = 0;
			cPeopleDisplaced = 0;
			cBusinessesDisplaced = 0;
			cJobsLost = 0;
			_cRuptureOutsideRS = null;
			cRuptureOutsideID = 0;
			cROIncidentID = 0;
			cROIncidentType = 0;
			cROContentLoss = 0;
			cROAreaAffected = 0;
			cROAreaUnit = 0;
			_cRupturePhysicalContributingFactor = null;
			cRPCRuptureID = 0;
			cRPhysicalFactor = 0;
			_cRuptureHumanContributingFactor = null;
			cRHCRuptureID = 0;
			cRHumanFactor = 0;
			_cRuptureSuppressionFactor = null;
			cRSFRuptureID = 0;
			cRSuppressionFactor = 0;
		}

		//********************************************************
		//**    Rupture/Explosion Class                         **
		//********************************************************
		//**        Methods                                     **
		//**------------------------------------------------------
		//**                                                    **
		//**
		//********************************************************

		//********************************************************
		//**             Private Class Variables                **
		//********************************************************
		//RuptureExplosion
		public virtual ADORecordSetHelper _cRuptureExplosion { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cRuptureExplosion
		{
			get
			{
				if (_cRuptureExplosion == null)
				{
					_cRuptureExplosion = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cRuptureExplosion;
			}
			set
			{
				_cRuptureExplosion = value;
			}
		}

		public virtual int cRuptureID { get; set; }

		public virtual int cRuptureIncidentID { get; set; }

		public virtual int cRuptureIncidentType { get; set; }

		public virtual int cRupturePropertyUseCode { get; set; }

		public virtual int cRuptureAreaOfOrigin { get; set; }

		public virtual int cRupturePropertyValue { get; set; }

		public virtual int cRupturePropertyLoss { get; set; }

		public virtual int cRuptureContentLoss { get; set; }

		//RuptureMobile
		public virtual ADORecordSetHelper _cRuptureMobileRS { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cRuptureMobileRS
		{
			get
			{
				if (_cRuptureMobileRS == null)
				{
					_cRuptureMobileRS = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cRuptureMobileRS;
			}
			set
			{
				_cRuptureMobileRS = value;
			}
		}

		public virtual int cRuptureMobileRuptureID { get; set; }

		public virtual string cVehicleMake { get; set; }

		public virtual string cVehicleModel { get; set; }

		public virtual string cVehicleYear { get; set; }

		public virtual string cVehicleVin { get; set; }

		public virtual int cWaterVesseLength { get; set; }

		public virtual string cMobileMake { get; set; }

		public virtual string cLicenseState { get; set; }

		//RuptureStructure
		public virtual ADORecordSetHelper _cRuptureStructureRS { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cRuptureStructureRS
		{
			get
			{
				if (_cRuptureStructureRS == null)
				{
					_cRuptureStructureRS = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cRuptureStructureRS;
			}
			set
			{
				_cRuptureStructureRS = value;
			}
		}

		public virtual int cRuptureStructureRuptureID { get; set; }

		public virtual int cFloorOfOrigin { get; set; }

		public virtual int cSpecialFloor { get; set; }

		public virtual int cBuildingStatus { get; set; }

		public virtual int cNumberOfStories { get; set; }

		public virtual int cBasementLevels { get; set; }

		public virtual int cConstructionType { get; set; }

		public virtual int cTotalSqFootage { get; set; }

		public virtual int cNumberPeopleOccuping { get; set; }

		public virtual int cNumberBusinessOccuping { get; set; }

		public virtual int cSqFootDamaged { get; set; }

		public virtual int cPeopleDisplaced { get; set; }

		public virtual int cBusinessesDisplaced { get; set; }

		public virtual int cJobsLost { get; set; }

		//RuptureOutside
		public virtual ADORecordSetHelper _cRuptureOutsideRS { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cRuptureOutsideRS
		{
			get
			{
				if (_cRuptureOutsideRS == null)
				{
					_cRuptureOutsideRS = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cRuptureOutsideRS;
			}
			set
			{
				_cRuptureOutsideRS = value;
			}
		}

		public virtual int cRuptureOutsideID { get; set; }

		public virtual int cROIncidentID { get; set; }

		public virtual int cROIncidentType { get; set; }

		public virtual int cROContentLoss { get; set; }

		public virtual int cROAreaAffected { get; set; }

		public virtual int cROAreaUnit { get; set; }

		//Sub Tables
		//RupturePhysicalContributingFactor
		public virtual ADORecordSetHelper _cRupturePhysicalContributingFactor { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cRupturePhysicalContributingFactor
		{
			get
			{
				if (_cRupturePhysicalContributingFactor == null)
				{
					_cRupturePhysicalContributingFactor = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cRupturePhysicalContributingFactor;
			}
			set
			{
				_cRupturePhysicalContributingFactor = value;
			}
		}

		public virtual int cRPCRuptureID { get; set; }

		public virtual int cRPhysicalFactor { get; set; }

		//RuptureHumanContributingFactor
		public virtual ADORecordSetHelper _cRuptureHumanContributingFactor { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cRuptureHumanContributingFactor
		{
			get
			{
				if (_cRuptureHumanContributingFactor == null)
				{
					_cRuptureHumanContributingFactor = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cRuptureHumanContributingFactor;
			}
			set
			{
				_cRuptureHumanContributingFactor = value;
			}
		}

		public virtual int cRHCRuptureID { get; set; }

		public virtual int cRHumanFactor { get; set; }

		//RuptureSuppressionFactor
		public virtual ADORecordSetHelper _cRuptureSuppressionFactor { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cRuptureSuppressionFactor
		{
			get
			{
				if (_cRuptureSuppressionFactor == null)
				{
					_cRuptureSuppressionFactor = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cRuptureSuppressionFactor;
			}
			set
			{
				_cRuptureSuppressionFactor = value;
			}
		}

		public virtual int cRSFRuptureID { get; set; }

		public virtual int cRSuppressionFactor { get; set; }

		//*********************************************
		//**         Class Public Properties         **
		//*********************************************
		//RuptureExplosion
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper RuptureExplosion
		{
			get
			{
				return cRuptureExplosion;
			}
			set
			{
				cRuptureExplosion = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int RuptureID
		{
			get
			{
				return cRuptureID;
			}
			set
			{
				cRuptureID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int RuptureIncidentID
		{
			get
			{
				return cRuptureIncidentID;
			}
			set
			{
				cRuptureIncidentID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int RuptureIncidentType
		{
			get
			{
				return cRuptureIncidentType;
			}
			set
			{
				cRuptureIncidentType = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int RupturePropertyUseCode
		{
			get
			{
				return cRupturePropertyUseCode;
			}
			set
			{
				cRupturePropertyUseCode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int RuptureAreaOfOrigin
		{
			get
			{
				return cRuptureAreaOfOrigin;
			}
			set
			{
				cRuptureAreaOfOrigin = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int RupturePropertyValue
		{
			get
			{
				return cRupturePropertyValue;
			}
			set
			{
				cRupturePropertyValue = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int RupturePropertyLoss
		{
			get
			{
				return cRupturePropertyLoss;
			}
			set
			{
				cRupturePropertyLoss = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int RuptureContentLoss
		{
			get
			{
				return cRuptureContentLoss;
			}
			set
			{
				cRuptureContentLoss = value;
			}
		}


		//RuptureMobile
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper RuptureMobileRS
		{
			get
			{
				return cRuptureMobileRS;
			}
			set
			{
				cRuptureMobileRS = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int RuptureMobileRuptureID
		{
			get
			{
				return cRuptureMobileRuptureID;
			}
			set
			{
				cRuptureMobileRuptureID = value;
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


		public int WaterVesseLength
		{
			get
			{
				return cWaterVesseLength;
			}
			set
			{
				cWaterVesseLength = value;
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


		//RuptureStructure
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper RuptureStructureRS
		{
			get
			{
				return cRuptureStructureRS;
			}
			set
			{
				cRuptureStructureRS = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int RuptureStructureRuptureID
		{
			get
			{
				return cRuptureStructureRuptureID;
			}
			set
			{
				cRuptureStructureRuptureID = value;
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


		public int NumberPeopleOccuping
		{
			get
			{
				return cNumberPeopleOccuping;
			}
			set
			{
				cNumberPeopleOccuping = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int NumberBusinessOccuping
		{
			get
			{
				return cNumberBusinessOccuping;
			}
			set
			{
				cNumberBusinessOccuping = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int SqFootDamaged
		{
			get
			{
				return cSqFootDamaged;
			}
			set
			{
				cSqFootDamaged = value;
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


		//RuptureOutside
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper RuptureOutsideRS
		{
			get
			{
				return cRuptureOutsideRS;
			}
			set
			{
				cRuptureOutsideRS = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int RuptureOutsideID
		{
			get
			{
				return cRuptureOutsideID;
			}
			set
			{
				cRuptureOutsideID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ROIncidentID
		{
			get
			{
				return cROIncidentID;
			}
			set
			{
				cROIncidentID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ROIncidentType
		{
			get
			{
				return cROIncidentType;
			}
			set
			{
				cROIncidentType = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ROContentLoss
		{
			get
			{
				return cROContentLoss;
			}
			set
			{
				cROContentLoss = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ROAreaAffected
		{
			get
			{
				return cROAreaAffected;
			}
			set
			{
				cROAreaAffected = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int ROAreaUnit
		{
			get
			{
				return cROAreaUnit;
			}
			set
			{
				cROAreaUnit = value;
			}
		}


		//Sub Tables
		//RupturePhysicalContributingFactor
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper RupturePhysicalContributingFactor
		{
			get
			{
				return cRupturePhysicalContributingFactor;
			}
			set
			{
				cRupturePhysicalContributingFactor = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int RPCRuptureID
		{
			get
			{
				return cRPCRuptureID;
			}
			set
			{
				cRPCRuptureID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int RPhysicalFactor
		{
			get
			{
				return cRPhysicalFactor;
			}
			set
			{
				cRPhysicalFactor = value;
			}
		}


		//RuptureHumanContributingFactor
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper RuptureHumanContributingFactor
		{
			get
			{
				return cRuptureHumanContributingFactor;
			}
			set
			{
				cRuptureHumanContributingFactor = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int RHCRuptureID
		{
			get
			{
				return cRHCRuptureID;
			}
			set
			{
				cRHCRuptureID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int RHumanFactor
		{
			get
			{
				return cRHumanFactor;
			}
			set
			{
				cRHumanFactor = value;
			}
		}


		//RuptureSuppressionFactor
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper RuptureSuppressionFactor
		{
			get
			{
				return cRuptureSuppressionFactor;
			}
			set
			{
				cRuptureSuppressionFactor = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int RSFRuptureID
		{
			get
			{
				return cRSFRuptureID;
			}
			set
			{
				cRSFRuptureID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int RSuppressionFactor
		{
			get
			{
				return cRSuppressionFactor;
			}
			set
			{
				cRSuppressionFactor = value;
			}
		}


		//**********************************************
		//**         Public Class Methods             **
		//**********************************************
		//RuptureExplosion

		public int GetRupture(int lRuptureID)
		{
			//Retrieve Rupture Report record and Load data into
			//Rupture Report class variables
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_RuptureExplosion " + lRuptureID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					//Load Class  Variables
					cRuptureID = Convert.ToInt32(oRec["rupture_id"]);
					cRuptureIncidentID = Convert.ToInt32(oRec["incident_id"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cRuptureIncidentType = Convert.ToInt32(IncidentMain.GetVal(oRec["incident_type_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cRupturePropertyUseCode = Convert.ToInt32(IncidentMain.GetVal(oRec["property_use_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cRuptureAreaOfOrigin = Convert.ToInt32(IncidentMain.GetVal(oRec["area_of_origin_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cRupturePropertyValue = Convert.ToInt32(IncidentMain.GetVal(oRec["property_value"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cRupturePropertyLoss = Convert.ToInt32(IncidentMain.GetVal(oRec["property_loss"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cRuptureContentLoss = Convert.ToInt32(IncidentMain.GetVal(oRec["content_loss"]));
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

		//RuptureStructure

		public int GetRuptureStructure(int lRuptureID)
		{
			//Retrieve Rupture Structure Report and Load data into
			//Rupture Structure  variables

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_RuptureStructure " + lRuptureID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					//Load Class  Variables
					cRuptureStructureRuptureID = Convert.ToInt32(oRec["rupture_id"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cFloorOfOrigin = Convert.ToInt32(IncidentMain.GetVal(oRec["floor_of_origin"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cSpecialFloor = Convert.ToInt32(IncidentMain.GetVal(oRec["special_floor_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cBuildingStatus = Convert.ToInt32(IncidentMain.GetVal(oRec["building_status_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cNumberOfStories = Convert.ToInt32(IncidentMain.GetVal(oRec["number_of_stories"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cBasementLevels = Convert.ToInt32(IncidentMain.GetVal(oRec["basement_levels"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cConstructionType = Convert.ToInt32(IncidentMain.GetVal(oRec["construction_type_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cTotalSqFootage = Convert.ToInt32(IncidentMain.GetVal(oRec["total_sq_footage"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cNumberPeopleOccuping = Convert.ToInt32(IncidentMain.GetVal(oRec["number_people_occuping"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cNumberBusinessOccuping = Convert.ToInt32(IncidentMain.GetVal(oRec["number_business_occuping"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cSqFootDamaged = Convert.ToInt32(IncidentMain.GetVal(oRec["sq_foot_damaged"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cPeopleDisplaced = Convert.ToInt32(IncidentMain.GetVal(oRec["number_people_displaced"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cBusinessesDisplaced = Convert.ToInt32(IncidentMain.GetVal(oRec["number_businesses_displaced"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cJobsLost = Convert.ToInt32(IncidentMain.GetVal(oRec["number_jobs_lost"]));
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

		//RuptureMobile

		public int GetRuptureMobileProperty(int lRuptureID)
		{
			//Retrieve RuptureMobile record and Load data into
			//RuptureMobile class variables
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_RuptureMobile " + lRuptureID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					//Load Class  Variables
					cRuptureMobileRuptureID = Convert.ToInt32(oRec["rupture_id"]);
					cVehicleMake = IncidentMain.Clean(oRec["vehicle_make"]);
					cVehicleModel = IncidentMain.Clean(oRec["vehicle_model"]);
					cVehicleYear = IncidentMain.Clean(oRec["vehicle_year"]);
					cVehicleVin = IncidentMain.Clean(oRec["vehicle_vin"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cWaterVesseLength = Convert.ToInt32(IncidentMain.GetVal(oRec["water_vessel_length"]));
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

		//RuptureOutside

		public int GetRuptureOutside(int lOutsideRuptureID)
		{
			//Retrieve RuptureOutside record and Load data into
			//RuptureOutside class variables
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_RuptureOutside " + lOutsideRuptureID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					//Load Class  Variables
					cRuptureOutsideID = Convert.ToInt32(oRec["outside_rupture_id"]);
					cROIncidentID = Convert.ToInt32(oRec["incident_id"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cROIncidentType = Convert.ToInt32(IncidentMain.GetVal(oRec["incident_type_code"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cROContentLoss = Convert.ToInt32(IncidentMain.GetVal(oRec["content_loss"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cROAreaAffected = Convert.ToInt32(IncidentMain.GetVal(oRec["area_affected"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cROAreaUnit = Convert.ToInt32(IncidentMain.GetVal(oRec["area_unit_code"]));
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
		//Main RuptureReport Tables
		//***************************************

		//Insert New Records Functions
		//These Functions assume that All necessary field values
		//have been set in the Class variables

		public int AddRupture()
		{
			//Add New Rupture Report Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;

				SqlString = "spInsert_Rupture " + cRuptureIncidentID.ToString() + ",";
				if (cRuptureIncidentType == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cRuptureIncidentType.ToString() + ",";
				}
				if (cRupturePropertyUseCode == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cRupturePropertyUseCode.ToString() + ",";
				}
				if (cRuptureAreaOfOrigin == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cRuptureAreaOfOrigin.ToString() + ",";
				}
				SqlString = SqlString + cRupturePropertyValue.ToString() + "," + cRupturePropertyLoss.ToString() + "," + cRuptureContentLoss.ToString();
				oCmd.CommandText = SqlString;
				oCmd.ExecuteNonQuery();
				oCmd.CommandText = "spSelect_NewRupture";
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (GetRupture(Convert.ToInt32(oRec[0])) != 0)
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

		public int UpdateRupture()
		{
			//Update Rupture Report Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;

				SqlString = "spUpdate_Rupture " + cRuptureID.ToString() + "," + cRuptureIncidentID.ToString() + ",";
				if (cRuptureIncidentType == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cRuptureIncidentType.ToString() + ",";
				}
				if (cRupturePropertyUseCode == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cRupturePropertyUseCode.ToString() + ",";
				}
				if (cRuptureAreaOfOrigin == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cRuptureAreaOfOrigin.ToString() + ",";
				}
				SqlString = SqlString + cRupturePropertyValue.ToString() + "," + cRupturePropertyLoss.ToString() + "," + cRuptureContentLoss.ToString();
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

		public int DeleteRupture(ref int lRuptureID)
		{
			//Delete Specified  Rupture Report
			//Also Deletes all dependent child records
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spDelete_Rupture";
				oCmd.ExecuteNonQuery(new object[] { lRuptureID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}


		public int AddRuptureStructure()
		{
			//Add New RuptureStructure Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;

				SqlString = "spInsert_RuptureStructure " + cRuptureStructureRuptureID.ToString() + "," + cFloorOfOrigin.ToString() + "," + cSpecialFloor.ToString() + ",";
				if (cBuildingStatus == 0)
				{
					SqlString = SqlString + "NULL," + cNumberOfStories.ToString() + "," + cBasementLevels.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cBuildingStatus.ToString() + "," + cNumberOfStories.ToString() + "," + cBasementLevels.ToString() + ",";
				}
				if (cConstructionType == 0)
				{
					SqlString = SqlString + "NULL," + cTotalSqFootage.ToString() + "," + cNumberPeopleOccuping.ToString() + "," + cNumberBusinessOccuping.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cConstructionType.ToString() + "," + cTotalSqFootage.ToString() + "," + cNumberPeopleOccuping.ToString() + "," + cNumberBusinessOccuping.ToString() + ",";
				}
				SqlString = SqlString + cSqFootDamaged.ToString() + "," + cPeopleDisplaced.ToString() + "," + cBusinessesDisplaced.ToString() + ",";
				SqlString = SqlString + cJobsLost.ToString();

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

		public int UpdateRuptureStructure()
		{
			//Update RuptureStructure Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;

				SqlString = "spUpdate_RuptureStructure " + cRuptureStructureRuptureID.ToString() + "," + cFloorOfOrigin.ToString() + "," + cSpecialFloor.ToString() + ",";
				if (cBuildingStatus == 0)
				{
					SqlString = SqlString + "NULL," + cNumberOfStories.ToString() + "," + cBasementLevels.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cBuildingStatus.ToString() + "," + cNumberOfStories.ToString() + "," + cBasementLevels.ToString() + ",";
				}
				if (cConstructionType == 0)
				{
					SqlString = SqlString + "NULL," + cTotalSqFootage.ToString() + "," + cNumberPeopleOccuping.ToString() + "," + cNumberBusinessOccuping.ToString() + ",";
				}
				else
				{
					SqlString = SqlString + cConstructionType.ToString() + "," + cTotalSqFootage.ToString() + "," + cNumberPeopleOccuping.ToString() + "," + cNumberBusinessOccuping.ToString() + ",";
				}
				SqlString = SqlString + cSqFootDamaged.ToString() + "," + cPeopleDisplaced.ToString() + "," + cBusinessesDisplaced.ToString() + ",";
				SqlString = SqlString + cJobsLost.ToString();

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

		public int DeleteRuptureStructure(ref int lRuptureID)
		{
			//Delete Specified  RuptureStructure Report
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spDelete_RuptureStructure";
				oCmd.ExecuteNonQuery(new object[] { lRuptureID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}


		public int AddRuptureMobile()
		{
			//Add New RuptureMobile Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spInsert_RuptureMobile " + cRuptureMobileRuptureID.ToString() + ",'";
				SqlString = SqlString + cVehicleMake + "','" + cVehicleModel + "','";
				SqlString = SqlString + cVehicleVin + "','" + cVehicleYear + "'," + cWaterVesseLength.ToString();
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

		public int UpdateRuptureMobile()
		{
			//Update RuptureMobile Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;
				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spUpdate_RuptureMobile " + cRuptureMobileRuptureID.ToString() + ",'";
				SqlString = SqlString + cVehicleMake + "','" + cVehicleModel + "','";
				SqlString = SqlString + cVehicleVin + "','" + cVehicleYear + "'," + cWaterVesseLength.ToString();
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

		public int DeleteRuptureMobile(ref int lRuptureID)
		{
			//Delete Specified  RuptureMobile Report
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spDelete_RuptureMobile";
				oCmd.ExecuteNonQuery(new object[] { lRuptureID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}


		public int AddRuptureOutside()
		{
			//Add New RuptureOutside Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			ADORecordSetHelper oRec = null;
			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spInsert_RuptureOutside " + cROIncidentID.ToString() + ",";
				//Test for Null values
				if (cROIncidentType == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cROIncidentType.ToString() + ",";
				}
				SqlString = SqlString + cROContentLoss.ToString() + "," + cROAreaAffected.ToString() + ",";
				if (cROAreaUnit == 0)
				{
					SqlString = SqlString + "NULL";
				}
				else
				{
					SqlString = SqlString + cROAreaUnit.ToString();
				}
				oCmd.CommandText = SqlString;
				oCmd.ExecuteNonQuery();
				oCmd.CommandText = "spSelect_NewRuptureOutside";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (GetRuptureOutside(Convert.ToInt32(oRec[0])) != 0)
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

		public int UpdateRuptureOutside()
		{
			//Update RuptureOutside Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			ADORecordSetHelper oRec = null;
			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spUpdate_RuptureOutside " + cRuptureOutsideID.ToString() + "," + cROIncidentID.ToString() + ",";
				//Test for Null values
				if (cROIncidentType == 0)
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + cROIncidentType.ToString() + ",";
				}

				SqlString = SqlString + cROContentLoss.ToString() + "," + cROAreaAffected.ToString() + ",";
				if (cROAreaUnit == 0)
				{
					SqlString = SqlString + "NULL";
				}
				else
				{
					SqlString = SqlString + cROAreaUnit.ToString();
				}
				oCmd.CommandText = SqlString;
				oCmd.ExecuteNonQuery();
				oCmd.CommandText = "spSelect_NewRuptureOutside";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (GetRuptureOutside(Convert.ToInt32(oRec[0])) != 0)
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

		public int DeleteRuptureOutside(ref int lRuptureOutsideID)
		{
			//Delete Specified Outside Rupture Report
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spDelete_RuptureOutside";
				oCmd.ExecuteNonQuery(new object[] { lRuptureOutsideID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		//Sub Tables
		//RupturePhysicalContributingFactor

		public int GetRupturePhysicalContributingFactor(int lRuptureID)
		{
			//Retrieve RupturePhysicalContributingFactor Recordset
			//For Current Rupture Report
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_RupturePhysicalContributingFactor " + lRuptureID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cRupturePhysicalContributingFactor = oRec;
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

		public int AddRupturePhysicalContributingFactor()
		{
			//Add new RupturePhysicalContributingFactor Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spInsert_RupturePhysicalContributingFactor";
				oCmd.ExecuteNonQuery(new object[] { cRPCRuptureID, cRPhysicalFactor });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteRupturePhysicalContributingFactor(ref int lRuptureID)
		{
			//Delete all RupturePhysicalContributingFactor Records for Current RuptureReport
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
				oCmd.CommandText = "spDelete_RupturePhysicalContributingFactor";
				oCmd.ExecuteNonQuery(new object[] { lRuptureID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		//RuptureHumanContributingFactor

		public int GetRuptureHumanContributingFactor(int lRuptureID)
		{
			//Retrieve RuptureHumanContributingFactor Recordset
			//For Current Rupture Report
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_RuptureHumanContributingFactor " + lRuptureID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cRuptureHumanContributingFactor = oRec;
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

		public int AddRuptureHumanContributingFactor()
		{
			//Add new RuptureHumanContributingFactor Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spInsert_RuptureHumanContributingFactor";
				oCmd.ExecuteNonQuery(new object[] { cRHCRuptureID, cRHumanFactor });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteRuptureHumanContributingFactor(ref int lRuptureID)
		{
			//Delete all RuptureHumanContributingFactor Records for Current RuptureReport
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
				oCmd.CommandText = "spDelete_RuptureHumanContributingFactor";
				oCmd.ExecuteNonQuery(new object[] { lRuptureID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		//RuptureSuppressionFactor

		public int GetRuptureSuppressionFactor(int lRuptureID)
		{
			//Retrieve RuptureSuppressionFactor Recordset
			//For Current Rupture Report
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_RuptureSuppressionFactor " + lRuptureID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cRuptureSuppressionFactor = oRec;
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

		public int AddRuptureSuppressionFactor()
		{
			//Add new RuptureSuppressionFactor Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spInsert_RuptureSuppressionFactor";
				oCmd.ExecuteNonQuery(new object[] { cRSFRuptureID, cRSuppressionFactor });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteRuptureSuppressionFactor(ref int lRuptureID)
		{
			//Delete all RuptureSuppressionFactor Records for Current RuptureReport
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
				oCmd.CommandText = "spDelete_RuptureSuppressionFactor";
				oCmd.ExecuteNonQuery(new object[] { lRuptureID });
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int GetRuptureOutsideReport(int lOutsideRuptureID)
		{

			//Retrieve Rupture Outside Record
			//Formatted for Reporting
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_RuptureOutside " + lOutsideRuptureID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cRuptureOutsideRS = oRec;
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

		public int GetRuptureMobileReport(int lRuptureReportID)
		{
			//Retrieve Rupture Mobile Record
			//Formatted for Reporting
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_RuptureMobile " + lRuptureReportID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cRuptureMobileRS = oRec;
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

		public int GetRuptureReport(int lRuptureReportID)
		{
			//Retrieve Basic Rupture Record
			//Formatted for Reporting
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_Rupture " + lRuptureReportID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cRuptureExplosion = oRec;
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

		public int GetRuptureStructureReport(int lRuptureReportID)
		{
			//Retrieve Rupture Structure Record
			//Formatted for Reporting
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_RuptureStructure " + lRuptureReportID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cRuptureStructureRS = oRec;
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

		public int GetRuptureSuppressionFactorReport(int lRuptureID)
		{
			//Retrieve Rupture Suppression Factor Records
			//Formatted for Reporting
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_RuptureSuppressionFactor " + lRuptureID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cRuptureSuppressionFactor = oRec;
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

		public bool GetRupturePhysicalContributingFactorReport(int lRuptureID)
		{
			//Retrieve RupturePhysicalContributingFactor Recordset
			//For Current Rupture Report
			bool result = false;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_RupturePhysicalContribFactor " + lRuptureID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cRupturePhysicalContributingFactor = oRec;
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

		public int GetRuptureHumanContributingFactorReport(int lRuptureID)
		{
			//Retrieve RuptureHumanContributingFactor Recordset
			//For Current Rupture Report
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_RuptureHumanContribFactor " + lRuptureID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cRuptureHumanContributingFactor = oRec;
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