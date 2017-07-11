using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident
{

	public class clsCommonCodes
		: UpgradeHelpers.Interfaces.IDependentModel, UpgradeHelpers.Interfaces.ICreatesObjects, UpgradeHelpers
		.Interfaces.IInteractsWithView, UpgradeHelpers.Interfaces.IInitializableCommon, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(clsCommonCodes));
		}

		void UpgradeHelpers.Interfaces.IInitializableCommon.Common()
		{
			_cUnitAction = null;
			_cAddressVerification = null;
			_cAgeUnit = null;
			_cAlarmSentBy = null;
			_cAreaUnits = null;
			_cCapacityUnit = null;
			_cCityCode = null;
			_cContainerType = null;
			_cDelay = null;
			_cExposureType = null;
			_cIncidentRole = null;
			_cIncidentTypeClassRS = null;
			_cIncidentType = null;
			_cIRSMessage = null;
			cMessageID = 0;
			cMessageText = "";
			cActiveFlag = 0;
			_cPeopleDescriptor = null;
			_cPopulationDensity = null;
			_cReasonAmended = null;
			_cStateRS = null;
			_cSecurityCode = null;
			_cHelpText = null;
			_cHelpList = null;
			_cHelpCode = null;
		}

		//********************************************************
		//**    Common Codes Class                              **
		//**  Contains Common Code Table References and Methods **
		//********************************************************
		//**    Methods                                         **
		//**----------------------------------------------------**


		//********************************************************
		//**             Private Class Variables                **
		//********************************************************
		//ActionTaken
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


		//AddressVerificationCode
		public virtual ADORecordSetHelper _cAddressVerification { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cAddressVerification
		{
			get
			{
				if (_cAddressVerification == null)
				{
					_cAddressVerification = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cAddressVerification;
			}
			set
			{
				_cAddressVerification = value;
			}
		}


		//AgeUnitCode
		public virtual ADORecordSetHelper _cAgeUnit { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cAgeUnit
		{
			get
			{
				if (_cAgeUnit == null)
				{
					_cAgeUnit = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cAgeUnit;
			}
			set
			{
				_cAgeUnit = value;
			}
		}


		//AlarmSentByCode
		public virtual ADORecordSetHelper _cAlarmSentBy { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cAlarmSentBy
		{
			get
			{
				if (_cAlarmSentBy == null)
				{
					_cAlarmSentBy = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cAlarmSentBy;
			}
			set
			{
				_cAlarmSentBy = value;
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


		//CapacityUnitCode
		public virtual ADORecordSetHelper _cCapacityUnit { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cCapacityUnit
		{
			get
			{
				if (_cCapacityUnit == null)
				{
					_cCapacityUnit = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cCapacityUnit;
			}
			set
			{
				_cCapacityUnit = value;
			}
		}


		//CityCode
		public virtual ADORecordSetHelper _cCityCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cCityCode
		{
			get
			{
				if (_cCityCode == null)
				{
					_cCityCode = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cCityCode;
			}
			set
			{
				_cCityCode = value;
			}
		}


		//ContainerTypeCode
		public virtual ADORecordSetHelper _cContainerType { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cContainerType
		{
			get
			{
				if (_cContainerType == null)
				{
					_cContainerType = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cContainerType;
			}
			set
			{
				_cContainerType = value;
			}
		}


		//DelayCode
		public virtual ADORecordSetHelper _cDelay { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cDelay
		{
			get
			{
				if (_cDelay == null)
				{
					_cDelay = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cDelay;
			}
			set
			{
				_cDelay = value;
			}
		}


		//ExposureTypeCode
		public virtual ADORecordSetHelper _cExposureType { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cExposureType
		{
			get
			{
				if (_cExposureType == null)
				{
					_cExposureType = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cExposureType;
			}
			set
			{
				_cExposureType = value;
			}
		}


		//IncidentRoleCode
		public virtual ADORecordSetHelper _cIncidentRole { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cIncidentRole
		{
			get
			{
				if (_cIncidentRole == null)
				{
					_cIncidentRole = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cIncidentRole;
			}
			set
			{
				_cIncidentRole = value;
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


		//IRSMessage
		public virtual ADORecordSetHelper _cIRSMessage { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cIRSMessage
		{
			get
			{
				if (_cIRSMessage == null)
				{
					_cIRSMessage = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cIRSMessage;
			}
			set
			{
				_cIRSMessage = value;
			}
		}

		public virtual int cMessageID { get; set; }

		public virtual string cMessageText { get; set; }

		public virtual byte cActiveFlag { get; set; }

		//PeopleDescriptorCode
		public virtual ADORecordSetHelper _cPeopleDescriptor { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cPeopleDescriptor
		{
			get
			{
				if (_cPeopleDescriptor == null)
				{
					_cPeopleDescriptor = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cPeopleDescriptor;
			}
			set
			{
				_cPeopleDescriptor = value;
			}
		}


		//PopulationDensityCode
		public virtual ADORecordSetHelper _cPopulationDensity { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cPopulationDensity
		{
			get
			{
				if (_cPopulationDensity == null)
				{
					_cPopulationDensity = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cPopulationDensity;
			}
			set
			{
				_cPopulationDensity = value;
			}
		}


		//ReasonAmendedCode
		public virtual ADORecordSetHelper _cReasonAmended { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cReasonAmended
		{
			get
			{
				if (_cReasonAmended == null)
				{
					_cReasonAmended = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cReasonAmended;
			}
			set
			{
				_cReasonAmended = value;
			}
		}


		//StateCode
		public virtual ADORecordSetHelper _cStateRS { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cStateRS
		{
			get
			{
				if (_cStateRS == null)
				{
					_cStateRS = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cStateRS;
			}
			set
			{
				_cStateRS = value;
			}
		}


		//SecurityCode
		public virtual ADORecordSetHelper _cSecurityCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cSecurityCode
		{
			get
			{
				if (_cSecurityCode == null)
				{
					_cSecurityCode = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cSecurityCode;
			}
			set
			{
				_cSecurityCode = value;
			}
		}


		//HelpCode
		public virtual ADORecordSetHelper _cHelpText { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cHelpText
		{
			get
			{
				if (_cHelpText == null)
				{
					_cHelpText = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cHelpText;
			}
			set
			{
				_cHelpText = value;
			}
		}

		public virtual ADORecordSetHelper _cHelpList { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cHelpList
		{
			get
			{
				if (_cHelpList == null)
				{
					_cHelpList = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cHelpList;
			}
			set
			{
				_cHelpList = value;
			}
		}

		public virtual ADORecordSetHelper _cHelpCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cHelpCode
		{
			get
			{
				if (_cHelpCode == null)
				{
					_cHelpCode = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cHelpCode;
			}
			set
			{
				_cHelpCode = value;
			}
		}




		//*********************************************
		//**         Class Public Properties         **
		//*********************************************

		//AddressVerificationCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper AddressVerification
		{
			get
			{
				return cAddressVerification;
			}
			set
			{
				cAddressVerification = value;
			}
		}


		//ActionTaken
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


		//AgeUnitCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper AgeUnit
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

		//AlarmSentByCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper AlarmSentBy
		{
			get
			{
				return cAlarmSentBy;
			}
			set
			{
				cAlarmSentBy = value;
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


		//CapacityUnitCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper CapacityUnit
		{
			get
			{
				return cCapacityUnit;
			}
			set
			{
				cCapacityUnit = value;
			}
		}

		//CityCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper CityCode
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


		//ContainerTypeCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper ContainerType
		{
			get
			{
				return cContainerType;
			}
			set
			{
				cContainerType = value;
			}
		}


		//DelayCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper Delay
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


		//ExposureTypeCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper ExposureType
		{
			get
			{
				return cExposureType;
			}
			set
			{
				cExposureType = value;
			}
		}


		//IncidentRoleCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper IncidentRole
		{
			get
			{
				return cIncidentRole;
			}
			set
			{
				cIncidentRole = value;
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


		//PeopleDescriptorCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper PeopleDescriptor
		{
			get
			{
				return cPeopleDescriptor;
			}
			set
			{
				cPeopleDescriptor = value;
			}
		}


		//PopulationDensityCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper PopulationDensity
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


		//ReasonAmendedCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper ReasonAmended
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


		//StateCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper StateRS
		{
			get
			{
				return cStateRS;
			}
			set
			{
				cStateRS = value;
			}
		}


		//SecurityCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper SecurityCode
		{
			get
			{
				return cSecurityCode;
			}
			set
			{
				cSecurityCode = value;
			}
		}



		//IRSMessage
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper IRSMessage
		{
			get
			{
				return cIRSMessage;
			}
			set
			{
				cIRSMessage = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int MessageID
		{
			get
			{
				return cMessageID;
			}
			set
			{
				cMessageID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string MessageText
		{
			get
			{
				return cMessageText;
			}
			set
			{
				cMessageText = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte ActiveFlag
		{
			get
			{
				return cActiveFlag;
			}
			set
			{
				cActiveFlag = value;
			}
		}



		//HelpCodes
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper HelpText
		{
			get
			{
				return cHelpText;
			}
			set
			{
				cHelpText = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public ADORecordSetHelper HelpList
		{
			get
			{
				return cHelpList;
			}
			set
			{
				cHelpList = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public ADORecordSetHelper HelpCode
		{
			get
			{
				return cHelpCode;
			}
			set
			{
				cHelpCode = value;
			}
		}


		//**********************************************
		//**         Public Class Methods             **
		//**********************************************

		public void GetUnitActionCodeByClass(int iActionClass)
		{
			//Get AreaUnits code Recordset
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_UnitActionCodeByClass " + iActionClass.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cUnitAction = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetAddressVerification(string AddressType)
		{
			//Get AddressVerification code Recordset
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_AddressVerificationCode '" + AddressType + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cAddressVerification = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetAgeUnit()
		{
			//Get AddressVerification code Recordset
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_AgeUnitCode";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cAgeUnit = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetAlarmSentBy()
		{
			//Get AlarmSentBy code Recordset
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_AlarmSentByCode";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cAlarmSentBy = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetAreaUnits()
		{
			//Get AreaUnits code Recordset
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_AreaUnits";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cAreaUnits = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetCapacityUnits()
		{
			//Get Capacity Units code Recordset
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_CapacityUnitCode";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cCapacityUnit = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetCityCode()
		{
			//Get CityCode code Recordset
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_CityCode";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cCityCode = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public string GetCityName(string sCityCode)
		{
			//Get City Name
			string result = "";
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = "";
				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_CityName '" + sCityCode + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					result = IncidentMain.Clean(oRec["city_name"]);
				}
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}


		public void GetContainerType()
		{
			//Get Container Type code Recordset
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_ContainerTypeCode";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cContainerType = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetDelayCodes()
		{
			//Get Delay Codes Recordset
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_DelayCode";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cDelay = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetExposureType()
		{
			//Get Exposure Type code Recordset
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_ExposureTypeCode";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cExposureType = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}



		public void GetPeopleDescriptor(string DescripType)
		{
			//Get People Descriptor code Recordset
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_PeopleDescriptorCode '" + DescripType + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cPeopleDescriptor = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetPopulationDensity()
		{
			//Get Population Density code Recordset
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_PopulationDensityCode";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cPopulationDensity = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetReasonAmendedCode()
		{
			//Get Reason Amended code Recordset
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_ReasonAmendedCode";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cReasonAmended = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetStateCode()
		{
			//Get State Code Recordset
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_StateCode";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cStateRS = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetSecurityCode()
		{
			//Get Security Code Recordset
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_SecurityCode";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cSecurityCode = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}


		public void GetIncidentTypeClassRS()
		{
			//Get Incident Type Class Recordset
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_IncidentTypeClass";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cIncidentTypeClassRS = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public int GetIncidentTypeCodeByClass(int iTypeClass)
		{
			//Get Incident Type Codes for specified Class
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;
				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_IncidentTypeCodeByClass " + iTypeClass.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cIncidentType = oRec;
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public int GetIncidentTypeCodeByCode(int iTypeCode)
		{
			//Get Incident Type Codes for Class specified by Code
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;
				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_IncidentTypeCodeByCode " + iTypeCode.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cIncidentType = oRec;
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public void GetIncidentRole()
		{
			//Get IncidentRole Code Recordset
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_IncidentRoleCode";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cIncidentRole = oRec;
			}
			catch
			{

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void GetIRSMessageRS()
		{
			//Get All IRS Splash Screen Messages
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_IRSMessageAll";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				cIRSMessage = oRec;
			}
			catch
			{

				return;
			}
		}

		public int UpdateIRSMessage(int lMessageID)
		{
			//Set different message as active message
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;
				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spUpdate_IRSMessage " + lMessageID.ToString();
				oCmd.ExecuteNonQuery();
			}
			catch
			{

				return 0;
			}
			return result;
		}

		public int InsertIRSMessage(string sMessageText)
		{
			//Add new IRS Message - set as active
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;
				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spInsert_IRSMessage '" + sMessageText + "'";
				oCmd.ExecuteNonQuery();
				oCmd.CommandText = "spSelect_NewIRSMessage";
				oRec = ADORecordSetHelper.Open(oCmd, "");

				oCmd.CommandText = "spUpdate_IRSMessage " + Convert.ToString(oRec["new_message_id"]);
				oCmd.ExecuteNonQuery();
			}
			catch
			{

				return 0;
			}
			return result;
		}

		public int DeleteIRSMessage(int lMessageID)
		{
			//Delete selected message
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;
				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spDelete_IRSMessage " + lMessageID.ToString();
				oCmd.ExecuteNonQuery();
			}
			catch
			{

				return 0;
			}
			return result;
		}

		public int GetHelpText(int lHelpScreen, int lHelpControl)
		{
			//Retrieve Help Text
			//Formatted for Reporting
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_IRSHelp " + lHelpScreen.ToString() + "," + lHelpControl.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cHelpText = oRec;
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

		public int GetHelpList()
		{
			//Retrieve Help Topics List
			//Formatted for Reporting
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_IRSHelpList";
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cHelpList = oRec;
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

		public int GetHelpCodes(int lHelpID)
		{
			//Retrieve Help Text Codes
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_IRSHelpCodes " + lHelpID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cHelpCode = oRec;
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



		public int GetHelpByID(int lHelpID)
		{
			//Retrieve specific Help Record by ID
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_IRSHelpByID " + lHelpID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cHelpText = oRec;
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

		public int UpdateIRSHelp(int lHelpID, string sTitle, string sText)
		{
			//Update specific Help Record by ID
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;
				oCmd.Connection = IncidentMain.oIncident;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spUpdate_IRSHelp " + lHelpID.ToString() + ",'" + sTitle + "','" + sText + "'";
				oCmd.ExecuteNonQuery();
			}
			catch
			{

				result = 0;
			}

			return result;
		}

		public string UniqueID { get; set; }

		public UpgradeHelpers.Interfaces.IViewManager ViewManager { get; set; }

		public UpgradeHelpers.Interfaces.IIocContainer Container { get; set; }

	}
}