using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public class clsTraining
		: UpgradeHelpers.Interfaces.IDependentModel, UpgradeHelpers.Interfaces.ICreatesObjects, UpgradeHelpers
		.Interfaces.IInteractsWithView, UpgradeHelpers.Interfaces.IInitializableCommon, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(clsTraining));
		}

		void UpgradeHelpers.Interfaces.IInitializableCommon.Common()
		{
			_cEmployee = null;
			cPMRecertPerSysID = 0;
			cPMRecertDate = "";
			cPMRecertNRNumber = "";
			cPMRecertStateNumber = "";
			cPMRecertCountyNumber = "";
			cPMRecertGroupNumber = 0;
			cPMRecertLastUpdated = "";
			cPMRecertLastUpdateBy = "";
			cWorkAsMedicFlag = "";
			cWAMPerSysID = 0;
			cWAMInactivateDate = "";
			cWAMUpdateDate = "";
			cWAMUpdateBy = "";
			_cTrainingPrimaryCode = null;
			cPrimaryCode = 0;
			cPrimaryDescription = "";
			cPrimaryFieldEdit = 0;
			cPrimarySortOrder = 0;
			_cTrainingSecondaryCode = null;
			cSecondaryCode = 0;
			cSecondaryPrimaryCode = 0;
			cSecondaryDescription = "";
			cSecondaryFieldEdit = 0;
			cSecondaryTrackHrs = 0;
			cSecondarySortOrder = 0;
			_cTrainingSpecificCode = null;
			cSpecificCode = 0;
			cSpecificSecondaryCode = 0;
			cSpecificDescription = "";
			cSpecificFieldEdit = 0;
			cSpecificComment = "";
			cSpecificSortOrder = 0;
			cSpecificDisplayBox = 0;
			cSpecificDisplayCat = 0;
			cSpecificDisplayScore = 0;
			_cTrainingDisplayMessage = null;
			cDisplaySecondaryCode = 0;
			cDisplayMessage = "";
			_cTrainingRecord = null;
			cRecordID = 0;
			cRecordEmployeeID = "";
			cRecordSpecificCode = 0;
			cRecordHours = 0;
			cRecordComments = "";
			cRecordTrainingDate = DateTime.FromOADate(0);
			cRecordCreateDate = DateTime.FromOADate(0);
			cRecordCreateBy = 0;
			cRecordUpdateBy = 0;
			cRecordUpdateDate = DateTime.FromOADate(0);
			cRecordProviderFlag = 0;
			cRecordInstructorFlag = 0;
			cRecordCategoryID = 0;
			cRecordPassFail = "";
		}

		//********************************************************
		//**    Training Class                                  **
		//********************************************************

		//Private Class Variables
		//Employee
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


		//ParamedicRecertificationInfo
		public virtual int cPMRecertPerSysID { get; set; }

		public virtual string cPMRecertDate { get; set; }

		public virtual string cPMRecertNRNumber { get; set; }

		public virtual string cPMRecertStateNumber { get; set; }

		public virtual string cPMRecertCountyNumber { get; set; }

		public virtual int cPMRecertGroupNumber { get; set; }

		public virtual string cPMRecertLastUpdated { get; set; }

		public virtual string cPMRecertLastUpdateBy { get; set; }

		public virtual string cWorkAsMedicFlag { get; set; }

		//PersonnelWorkAsParamedic
		public virtual int cWAMPerSysID { get; set; }

		public virtual string cWAMInactivateDate { get; set; }

		public virtual string cWAMUpdateDate { get; set; }

		public virtual string cWAMUpdateBy { get; set; }

		//Training Tables
		//TrainingPrimaryCode
		public virtual ADORecordSetHelper _cTrainingPrimaryCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cTrainingPrimaryCode
		{
			get
			{
				if (_cTrainingPrimaryCode == null)
				{
					_cTrainingPrimaryCode = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cTrainingPrimaryCode;
			}
			set
			{
				_cTrainingPrimaryCode = value;
			}
		}

		public virtual int cPrimaryCode { get; set; }

		public virtual string cPrimaryDescription { get; set; }

		public virtual byte cPrimaryFieldEdit { get; set; }

		public virtual int cPrimarySortOrder { get; set; }

		//TrainingSecondaryCode
		public virtual ADORecordSetHelper _cTrainingSecondaryCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cTrainingSecondaryCode
		{
			get
			{
				if (_cTrainingSecondaryCode == null)
				{
					_cTrainingSecondaryCode = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cTrainingSecondaryCode;
			}
			set
			{
				_cTrainingSecondaryCode = value;
			}
		}

		public virtual int cSecondaryCode { get; set; }

		public virtual int cSecondaryPrimaryCode { get; set; }

		public virtual string cSecondaryDescription { get; set; }

		public virtual byte cSecondaryFieldEdit { get; set; }

		public virtual byte cSecondaryTrackHrs { get; set; }

		public virtual int cSecondarySortOrder { get; set; }

		//TrainingpecificCode
		public virtual ADORecordSetHelper _cTrainingSpecificCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cTrainingSpecificCode
		{
			get
			{
				if (_cTrainingSpecificCode == null)
				{
					_cTrainingSpecificCode = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cTrainingSpecificCode;
			}
			set
			{
				_cTrainingSpecificCode = value;
			}
		}

		public virtual int cSpecificCode { get; set; }

		public virtual int cSpecificSecondaryCode { get; set; }

		public virtual string cSpecificDescription { get; set; }

		public virtual byte cSpecificFieldEdit { get; set; }

		public virtual string cSpecificComment { get; set; }

		public virtual int cSpecificSortOrder { get; set; }

		public virtual byte cSpecificDisplayBox { get; set; }

		public virtual byte cSpecificDisplayCat { get; set; }

		public virtual byte cSpecificDisplayScore { get; set; }

		//TrainingDisplayMessage
		public virtual ADORecordSetHelper _cTrainingDisplayMessage { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cTrainingDisplayMessage
		{
			get
			{
				if (_cTrainingDisplayMessage == null)
				{
					_cTrainingDisplayMessage = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cTrainingDisplayMessage;
			}
			set
			{
				_cTrainingDisplayMessage = value;
			}
		}

		public virtual int cDisplaySecondaryCode { get; set; }

		public virtual string cDisplayMessage { get; set; }

		//TrainingRecord
		public virtual ADORecordSetHelper _cTrainingRecord { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cTrainingRecord
		{
			get
			{
				if (_cTrainingRecord == null)
				{
					_cTrainingRecord = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cTrainingRecord;
			}
			set
			{
				_cTrainingRecord = value;
			}
		}

		public virtual int cRecordID { get; set; }

		public virtual string cRecordEmployeeID { get; set; }

		public virtual int cRecordSpecificCode { get; set; }

		public virtual float cRecordHours { get; set; }

		public virtual string cRecordComments { get; set; }

		public virtual System.DateTime cRecordTrainingDate { get; set; }

		public virtual System.DateTime cRecordCreateDate { get; set; }

		public virtual int cRecordCreateBy { get; set; }

		public virtual int cRecordUpdateBy { get; set; }

		public virtual System.DateTime cRecordUpdateDate { get; set; }

		public virtual byte cRecordProviderFlag { get; set; }

		public virtual byte cRecordInstructorFlag { get; set; }

		public virtual int cRecordCategoryID { get; set; }

		public virtual string cRecordPassFail { get; set; }

		//Class Public Properties
		//Employee
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


		//ParamedicRecertificationInfo
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public int PMRecertPerSysID
		{
			get
			{
				return cPMRecertPerSysID;
			}
			set
			{
				cPMRecertPerSysID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PMRecertDate
		{
			get
			{
				return cPMRecertDate;
			}
			set
			{
				cPMRecertDate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PMRecertNRNumber
		{
			get
			{
				return cPMRecertNRNumber;
			}
			set
			{
				cPMRecertNRNumber = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PMRecertStateNumber
		{
			get
			{
				return cPMRecertStateNumber;
			}
			set
			{
				cPMRecertStateNumber = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PMRecertCountyNumber
		{
			get
			{
				return cPMRecertCountyNumber;
			}
			set
			{
				cPMRecertCountyNumber = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int PMRecertGroupNumber
		{
			get
			{
				return cPMRecertGroupNumber;
			}
			set
			{
				cPMRecertGroupNumber = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]



		public string PMRecertLastUpdated
		{
			get
			{
				return cPMRecertLastUpdated;
			}
			set
			{
				cPMRecertLastUpdated = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PMRecertLastUpdateBy
		{
			get
			{
				return cPMRecertLastUpdateBy;
			}
			set
			{
				cPMRecertLastUpdateBy = value;
			}
		}


		//Misc
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public string WorkAsMedicFlag
		{
			get
			{
				return cWorkAsMedicFlag;
			}
			set
			{
				cWorkAsMedicFlag = value;
			}
		}


		//PersonnelWorkAsParamedic
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public int WAMPerSysID
		{
			get
			{
				return cWAMPerSysID;
			}
			set
			{
				cWAMPerSysID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string WAMInactivateDate
		{
			get
			{
				return cWAMInactivateDate;
			}
			set
			{
				cWAMInactivateDate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string WAMUpdateDate
		{
			get
			{
				return cWAMUpdateDate;
			}
			set
			{
				cWAMUpdateDate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string WAMUpdateBy
		{
			get
			{
				return cWAMUpdateBy;
			}
			set
			{
				cWAMUpdateBy = value;
			}
		}


		//Training Codes
		//TrainingPrimaryCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper TrainingPrimaryCode
		{
			get
			{
				return cTrainingPrimaryCode;
			}
			set
			{
				cTrainingPrimaryCode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int PrimaryCode
		{
			get
			{
				return cPrimaryCode;
			}
			set
			{
				cPrimaryCode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PrimaryDescription
		{
			get
			{
				return cPrimaryDescription;
			}
			set
			{
				cPrimaryDescription = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte PrimaryFieldEdit
		{
			get
			{
				return cPrimaryFieldEdit;
			}
			set
			{
				cPrimaryFieldEdit = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int PrimarySortOrder
		{
			get
			{
				return cPrimarySortOrder;
			}
			set
			{
				cPrimarySortOrder = value;
			}
		}


		//TrainingSecondaryCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper TrainingSecondaryCode
		{
			get
			{
				return cTrainingSecondaryCode;
			}
			set
			{
				cTrainingSecondaryCode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int SecondaryCode
		{
			get
			{
				return cSecondaryCode;
			}
			set
			{
				cSecondaryCode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int SecondaryPrimaryCode
		{
			get
			{
				return cSecondaryPrimaryCode;
			}
			set
			{
				cSecondaryPrimaryCode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string SecondaryDescription
		{
			get
			{
				return cSecondaryDescription;
			}
			set
			{
				cSecondaryDescription = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte SecondaryFieldEdit
		{
			get
			{
				return cSecondaryFieldEdit;
			}
			set
			{
				cSecondaryFieldEdit = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte SecondaryTrackHrs
		{
			get
			{
				return cSecondaryTrackHrs;
			}
			set
			{
				cSecondaryTrackHrs = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int SecondarySortOrder
		{
			get
			{
				return cSecondarySortOrder;
			}
			set
			{
				cSecondarySortOrder = value;
			}
		}


		//TrainingpecificCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper TrainingSpecificCode
		{
			get
			{
				return cTrainingSpecificCode;
			}
			set
			{
				cTrainingSpecificCode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int SpecificCode
		{
			get
			{
				return cSpecificCode;
			}
			set
			{
				cSpecificCode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int SpecificSecondaryCode
		{
			get
			{
				return cSpecificSecondaryCode;
			}
			set
			{
				cSpecificSecondaryCode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string SpecificDescription
		{
			get
			{
				return cSpecificDescription;
			}
			set
			{
				cSpecificDescription = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte SpecificFieldEdit
		{
			get
			{
				return cSpecificFieldEdit;
			}
			set
			{
				cSpecificFieldEdit = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string SpecificComment
		{
			get
			{
				return cSpecificComment;
			}
			set
			{
				cSpecificComment = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int SpecificSortOrder
		{
			get
			{
				return cSpecificSortOrder;
			}
			set
			{
				cSpecificSortOrder = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte SpecificDisplayBox
		{
			get
			{
				return cSpecificDisplayBox;
			}
			set
			{
				cSpecificDisplayBox = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte SpecificDisplayCat
		{
			get
			{
				return cSpecificDisplayCat;
			}
			set
			{
				cSpecificDisplayCat = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte SpecificDisplayScore
		{
			get
			{
				return cSpecificDisplayScore;
			}
			set
			{
				cSpecificDisplayScore = value;
			}
		}



		//TrainingDisplayMessage
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper TrainingDisplayMessage
		{
			get
			{
				return cTrainingDisplayMessage;
			}
			set
			{
				cTrainingDisplayMessage = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int DisplaySecondaryCode
		{
			get
			{
				return cDisplaySecondaryCode;
			}
			set
			{
				cDisplaySecondaryCode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string DisplayMessage
		{
			get
			{
				return cDisplayMessage;
			}
			set
			{
				cDisplayMessage = value;
			}
		}


		//TrainingRecord
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper TrainingRecord
		{
			get
			{
				return cTrainingRecord;
			}
			set
			{
				cTrainingRecord = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int RecordID
		{
			get
			{
				return cRecordID;
			}
			set
			{
				cRecordID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string RecordEmployeeID
		{
			get
			{
				return cRecordEmployeeID;
			}
			set
			{
				cRecordEmployeeID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int RecordSpecificCode
		{
			get
			{
				return cRecordSpecificCode;
			}
			set
			{
				cRecordSpecificCode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public float RecordHours
		{
			get
			{
				return cRecordHours;
			}
			set
			{
				cRecordHours = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string RecordComments
		{
			get
			{
				return cRecordComments;
			}
			set
			{
				cRecordComments = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public System.DateTime RecordTrainingDate
		{
			get
			{
				return cRecordTrainingDate;
			}
			set
			{
				cRecordTrainingDate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public System.DateTime RecordCreateDate
		{
			get
			{
				return cRecordCreateDate;
			}
			set
			{
				cRecordCreateDate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public System.DateTime RecordUpdateDate
		{
			get
			{
				return cRecordUpdateDate;
			}
			set
			{
				cRecordUpdateDate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int RecordCreateBy
		{
			get
			{
				return cRecordCreateBy;
			}
			set
			{
				cRecordCreateBy = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int RecordUpdateBy
		{
			get
			{
				return cRecordUpdateBy;
			}
			set
			{
				cRecordUpdateBy = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte RecordProviderFlag
		{
			get
			{
				return cRecordProviderFlag;
			}
			set
			{
				cRecordProviderFlag = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte RecordInstructorFlag
		{
			get
			{
				return cRecordInstructorFlag;
			}
			set
			{
				cRecordInstructorFlag = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int RecordCategoryID
		{
			get
			{
				return cRecordCategoryID;
			}
			set
			{
				cRecordCategoryID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string RecordPassFail
		{
			get
			{
				return cRecordPassFail;
			}
			set
			{
				cRecordPassFail = value;
			}
		}



		//***************************************
		//**     Public Class Methods             **
		//***************************************
		//Select Methods

		public int GetEmployee(string sEmpID)
		{
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;
				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_Employee '" + sEmpID + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cEmployee = oRec;
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

		public int GetPrimaryCodesForField()
		{

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;
				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_TrainingPrimaryCodesField";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingPrimaryCode = oRec;
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

		public int GetSecondaryCodesForField(int iPrimary)
		{

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;
				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_TrainingSecondaryCodeField " + iPrimary.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingSecondaryCode = oRec;
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

		public int GetSpecificCodesForField(int iSecondary)
		{

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;
				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_TrainingSpecificCodeField " + iSecondary.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingSpecificCode = oRec;
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

		public int CheckForAffirmationDisplay(int iSecondary)
		{

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spTraining_SelectDisplayMessage " + iSecondary.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingSpecificCode = oRec;
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

		public int GetSecondaryCodeByID(int iSecondary)
		{

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spTraining_SelectSecondaryCodeByID " + iSecondary.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingSpecificCode = oRec;
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

		public int AddTrainingRecord()
		{

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			result = -1;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			string sSQLString = "spTrainingNew_InsertTrainingRecord '" + cRecordEmployeeID + "', " +
			                    cRecordSpecificCode.ToString() + ", '" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(cRecordTrainingDate) + "', " + cRecordHours.ToString() +
													", '" + cRecordComments + "', " + cRecordCreateBy.ToString() + ", " + cRecordProviderFlag.ToString() +
													", " + cRecordInstructorFlag.ToString() + ", ";

			if (cRecordCategoryID == 0)
			{
				sSQLString = sSQLString + "NULL, ";
			}
			else
			{
				sSQLString = sSQLString + cRecordCategoryID.ToString() + ", ";
			}

			if (cRecordPassFail == "")
			{
				sSQLString = sSQLString + "NULL ";
			}
			else
			{
				sSQLString = sSQLString + "'" + cRecordPassFail + "' ";
			}

			oCmd.CommandText = sSQLString;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			//UPGRADE_WARNING: (2065) ADODB.Recordset method oRec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
			oRec = oRec.NextRecordSet();

			if (!oRec.EOF)
			{
				cRecordID = Convert.ToInt32(oRec[0]);
			}
			else
			{
				result = 0;
			}

			return result;

            // UNREACHABLE CODE
			//result = 0;
			//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
			//UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			//return result;
		}

		public int DeleteTrainingRecord()
		{

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			result = -1;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			string sSQLString = "spTrainingNew_DeleteTrainingRecord " + cRecordID.ToString() + " ";
			oCmd.CommandText = sSQLString;
			oCmd.ExecuteNonQuery();

			return result;

            // UNREACHABLE CODE
   //         result = 0;
			////UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
			//UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			//return result;
		}

		public int UpdateTrainingRecord()
		{

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string sSQLString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;

				sSQLString = "spTrainingNew_UpdateTrainingRecord " + cRecordID.ToString() + ", " + cRecordSpecificCode.ToString() + ",'" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(cRecordTrainingDate) + "'," +
																cRecordHours.ToString() + ",'" + cRecordComments + "', " + cRecordUpdateBy.ToString() +
																", " + cRecordProviderFlag.ToString() + ", " + cRecordInstructorFlag.ToString() + ", ";

									 if (cRecordCategoryID == 0)
									 {
										 sSQLString = sSQLString + "NULL, ";
									 }
									 else
									 {
										 sSQLString = sSQLString + cRecordCategoryID.ToString() + ", ";
									 }

									 if (cRecordPassFail == "")
									 {
										 sSQLString = sSQLString + "NULL ";
									 }
									 else
									 {
										 sSQLString = sSQLString + "'" + cRecordPassFail + "' ";
									 }

									 oCmd.CommandText = sSQLString;
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

		public int GetTrainingInfoForSecurity(string sEmpID, string sTrainingDate)
		{
			// Get Employee Information for Training Record Insert Ability
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_FieldTrainingInfo '" + sEmpID + "', '" +
				                   sTrainingDate + "' ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingRecord = oRec;
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


		public int GetSecondaryCodesByPrimary(int iPrimary)
		{

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;
				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spTrainingNew_GetAllSecondaryCodesByPrimary " + iPrimary.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingSecondaryCode = oRec;
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

		public int GetSpecificCodesBySecondary(int iSecondary)
		{

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;
				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spTrainingNew_GetAllSpecificCodesBySecondary " + iSecondary.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingSpecificCode = oRec;
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

		public int GetPrimaryCodes()
		{

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;
				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_TrainingPrimaryCodes";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingPrimaryCode = oRec;
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

		public int GetSecondaryCodes(int iPrimary)
		{

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;
				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_TrainingSecondaryCode " + iPrimary.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingSecondaryCode = oRec;
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

		public int GetSpecificCodes(int iSecondary)
		{

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;
				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_TrainingSpecificCode " + iSecondary.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingSpecificCode = oRec;
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

		public int GetTrainingStandardYearList()
		{
			// Get TrainingMinimumStandardDrills Year List
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_TrainingStandardYearList ";

				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingRecord = oRec;
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

		public int GetTrainingDrillsByYearQuarter(int iYear, int iQuarter)
		{
			// Get Training Minimum Standard Drills for Year/Quarter
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_TrainingStandardsByYearQuarter " + iYear.ToString() + ", " + iQuarter.ToString() + " ";

				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingRecord = oRec;
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

		public int GetTrainingQuarterlyStandardReport(int iYear, int iQuarter, string sBatt, string sShift)
		{
			// Get Training Minimum Standard Drill Quarterly Report for Year/Quarter/Batt/Shift
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spReport_TrainingQuarterlyStandardDrills " + iYear.ToString() + ", " + iQuarter.ToString() + ", ";

				if (modGlobal.Clean(sBatt) == "")
				{
					SqlString = SqlString + "Null, ";
				}
				else
				{
					SqlString = SqlString + "'" + sBatt + "', ";
				}
				if (modGlobal.Clean(sShift) == "")
				{
					SqlString = SqlString + "Null ";
				}
				else
				{
					SqlString = SqlString + "'" + sShift + "' ";
				}

				oCmd.CommandText = SqlString;

				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingRecord = oRec;
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

		public int GetTrainingQueryFiltered(string sStartDte, string sEndDte, int iPrimary, int lSecondary, int lSpecific, string sShift, string sUnit, string sBatt, string sName, string sComment, byte bFlag)
		{
			// Get Training Information for Filters
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spReport_TrainingQueryFiltered '" + sStartDte + "', '" + sEndDte + "', ";

				if (iPrimary == 0)
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + iPrimary.ToString() + ", ";
				}
				if (lSecondary == 0)
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + lSecondary.ToString() + ", ";
				}
				if (lSpecific == 0)
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + lSpecific.ToString() + ", ";
				}
				if (modGlobal.Clean(sShift) == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + sShift + "', ";
				}
				if (modGlobal.Clean(sUnit) == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + sUnit + "', ";
				}
				if (modGlobal.Clean(sBatt) == "")
				{
					SqlString = SqlString + "Null, ";
				}
				else
				{
					SqlString = SqlString + "'" + sBatt + "', ";
				}
				if (modGlobal.Clean(sName) == "")
				{
					SqlString = SqlString + "Null, ";
				}
				else
				{
					SqlString = SqlString + "'" + sName + "', ";
				}
				if (modGlobal.Clean(sComment) == "")
				{
					SqlString = SqlString + "Null, ";
				}
				else
				{
					SqlString = SqlString + "'" + sComment + "', ";
				}
				SqlString = SqlString + bFlag.ToString() + " ";

				oCmd.CommandText = SqlString;

				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingRecord = oRec;
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

		public int GetTrainingQueryFilteredForField(string sStartDte, string sEndDte, int iPrimary, int lSecondary, int lSpecific, string sShift, string sUnit, string sBatt, string sName, string sComment, byte bFlag)
		{
			// Get Training Information for Filters
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spReport_TrainingQueryFilteredForField '" + sStartDte + "', '" + sEndDte + "', ";

				if (iPrimary == 0)
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + iPrimary.ToString() + ", ";
				}
				if (lSecondary == 0)
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + lSecondary.ToString() + ", ";
				}
				if (lSpecific == 0)
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + lSpecific.ToString() + ", ";
				}
				if (modGlobal.Clean(sShift) == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + sShift + "', ";
				}
				if (modGlobal.Clean(sUnit) == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + sUnit + "', ";
				}
				if (modGlobal.Clean(sBatt) == "")
				{
					SqlString = SqlString + "Null, ";
				}
				else
				{
					SqlString = SqlString + "'" + sBatt + "', ";
				}
				if (modGlobal.Clean(sName) == "")
				{
					SqlString = SqlString + "Null, ";
				}
				else
				{
					SqlString = SqlString + "'" + sName + "', ";
				}
				if (modGlobal.Clean(sComment) == "")
				{
					SqlString = SqlString + "Null, ";
				}
				else
				{
					SqlString = SqlString + "'" + sComment + "', ";
				}
				SqlString = SqlString + bFlag.ToString() + " ";

				oCmd.CommandText = SqlString;

				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingRecord = oRec;
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

		public int GetTrainingDrillsByYearType(int iYear, int iType)
		{
			// Get Training Minimum Standard Drills for Year/Type
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_TrainingStandardsByYearType " + iYear.ToString() + ", " + iType.ToString() + " ";

				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingRecord = oRec;
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

		public int GetTrainingStandardCodeList()
		{
			// Get TrainingMinimumStandardDrills Year List
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_TrainingStandardCodeList ";

				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingRecord = oRec;
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

		public int GetTrainingAnnualStandardReportByType(int iYear, int iType, string sBatt, string sShift)
		{
			// Get Training Minimum Standard Drill Report for Year/Standard Type/Quarter/Batt/Shift
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spReport_TrainingAnnualStandardDrillsByType " + iYear.ToString() + ", " + iType.ToString() + ", ";

				if (modGlobal.Clean(sBatt) == "")
				{
					SqlString = SqlString + "Null, ";
				}
				else
				{
					SqlString = SqlString + "'" + sBatt + "', ";
				}
				if (modGlobal.Clean(sShift) == "")
				{
					SqlString = SqlString + "Null ";
				}
				else
				{
					SqlString = SqlString + "'" + sShift + "' ";
				}

				oCmd.CommandText = SqlString;

				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingRecord = oRec;
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

		public int GetTrainingReadingGroupList()
		{
			// Get TrainingReadingGroup List
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_TrainingReadingGroupList ";

				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingRecord = oRec;
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

		public int GetTrainingReqReadingByYearQuarter(int iYear, int iQuarter)
		{
			// Get Training Required Reading Assignments for Year/Quarter
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_TrainingReadingAssignmentsByYearQuarter " + iYear.ToString() + ", " + iQuarter.ToString() + " ";

				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingRecord = oRec;
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

		public int GetTrainingReqReadingByYearType(int iYear, int iType)
		{
			// Get Training Required Reading Assignments for Year/Group Type
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_TrainingReadingAssignmentsByYearType " + iYear.ToString() + ", " + iType.ToString() + " ";

				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingRecord = oRec;
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

		public int GetTrainingQuarterlyReqReadingReport(int iYear, int iQuarter, string sBatt, string sShift)
		{
			// Get Training Required Reading Quarterly Report for Year/Quarter/Batt/Shift
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spReport_TrainingQuarterlyReadingAssignments " + iYear.ToString() + ", " + iQuarter.ToString() + ", ";

				if (modGlobal.Clean(sBatt) == "")
				{
					SqlString = SqlString + "Null, ";
				}
				else
				{
					SqlString = SqlString + "'" + sBatt + "', ";
				}
				if (modGlobal.Clean(sShift) == "")
				{
					SqlString = SqlString + "Null ";
				}
				else
				{
					SqlString = SqlString + "'" + sShift + "' ";
				}

				oCmd.CommandText = SqlString;

				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingRecord = oRec;
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

		public int GetTrainingAnnualReqReadingReportByType(int iYear, int iType, string sBatt, string sShift)
		{
			// Get Training Minimum Standard Drill Report for Year/Standard Type/Quarter/Batt/Shift
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spReport_TrainingAnnualReadingAssignmentsByGroup " + iYear.ToString() + ", " + iType.ToString() + ", ";

				if (modGlobal.Clean(sBatt) == "")
				{
					SqlString = SqlString + "Null, ";
				}
				else
				{
					SqlString = SqlString + "'" + sBatt + "', ";
				}
				if (modGlobal.Clean(sShift) == "")
				{
					SqlString = SqlString + "Null ";
				}
				else
				{
					SqlString = SqlString + "'" + sShift + "' ";
				}

				oCmd.CommandText = SqlString;

				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingRecord = oRec;
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

		public int GetTrainingAnnualOTEPReport(int iYear, string sBatt, string sShift, int iGroup)
		{
			// Get Training OTEP Report for Year/Batt/Shift
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spReport_TrainingAnnualOTEPModules " + iYear.ToString() + ", ";

				if (modGlobal.Clean(sBatt) == "")
				{
					SqlString = SqlString + "Null, ";
				}
				else
				{
					SqlString = SqlString + "'" + sBatt + "', ";
				}

				if (modGlobal.Clean(sShift) == "")
				{
					SqlString = SqlString + "Null, ";
				}
				else
				{
					SqlString = SqlString + "'" + sShift + "', ";
				}

				if (iGroup == 0)
				{
					SqlString = SqlString + "Null ";
				}
				else
				{
					SqlString = SqlString + iGroup.ToString();
				}

				oCmd.CommandText = SqlString;

				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingRecord = oRec;
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

		public int GetTrainingSchedOTEPByYear(int iYear)
		{
			// Get Training Scheduled OTEP Modules for Year
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_TrainingSchedOTEPModulesByYear " + iYear.ToString() + " ";

				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingRecord = oRec;
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

		public int GetParamedicList(int iGroup, int iYear)
		{
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{

				result = -1;
				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spSelect_ParamedicGridList ";
				if (iGroup == 0)
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + iGroup.ToString() + ", ";
				}
				if (iYear == 0)
				{
					SqlString = SqlString + "NULL ";
				}
				else
				{
					SqlString = SqlString + iYear.ToString() + " ";
				}

				oCmd.CommandText = SqlString;

				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cEmployee = oRec;
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

		public int GetParamedicRecertificationInfo(int lPerSysID)
		{
			//Retrieve Records from ParamedicRecertificationInfo by PerSysID
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_ParamedicRecertificationInfoByEmp " + lPerSysID.ToString() + " ";
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cPMRecertPerSysID = Convert.ToInt32(modGlobal.GetVal(oRec["per_sys_id"]));
					cPMRecertDate = Convert.ToDateTime(oRec["recert_date"]).ToString("M/d/yyyy");
					if (modGlobal.Clean(oRec["nr_number"]) == "")
					{
						cPMRecertNRNumber = "";
					}
					else
					{
						cPMRecertNRNumber = modGlobal.Clean(oRec["nr_number"]);
					}
					if (modGlobal.Clean(oRec["state_number"]) == "")
					{
						cPMRecertStateNumber = "";
					}
					else
					{
						cPMRecertStateNumber = modGlobal.Clean(oRec["state_number"]);
					}
					if (modGlobal.Clean(oRec["county_number"]) == "")
					{
						cPMRecertCountyNumber = "";
					}
					else
					{
						cPMRecertCountyNumber = modGlobal.Clean(oRec["county_number"]);
					}
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cPMRecertGroupNumber = Convert.ToInt32(modGlobal.GetVal(oRec["group_number"]));
					cPMRecertLastUpdated = Convert.ToDateTime(oRec["last_updated"]).ToString("M/d/yyyy HH:mm:ss");
					cPMRecertLastUpdateBy = modGlobal.Clean(oRec["last_update_by"]);

					cWorkAsMedicFlag = modGlobal.Clean(oRec["WorkAsMedic"]);
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

		public int AddParamedicRecertificationInfo()
		{
			//Insert Record into ParamedicRecertificationInfo table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spInsert_ParamedicRecertificationInfo " + cPMRecertPerSysID.ToString() + ",'";
				SqlString = SqlString + cPMRecertDate + "',";

				if (cPMRecertNRNumber == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cPMRecertNRNumber + "',";
				}
				if (cPMRecertStateNumber == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cPMRecertStateNumber + "',";
				}
				if (cPMRecertCountyNumber == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cPMRecertCountyNumber + "', ";
				}
				SqlString = SqlString + cPMRecertGroupNumber.ToString() + ", ";
				SqlString = SqlString + "'" + cPMRecertLastUpdated + "','";
				SqlString = SqlString + cPMRecertLastUpdateBy + "' ";

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

		public int UpdateParamedicRecertificationInfo()
		{
			//Update Record into ParamedicRecertificationInfo table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spUpdate_ParamedicRecertificationInfo " + cPMRecertPerSysID.ToString() + ",'";
				SqlString = SqlString + cPMRecertDate + "',";

				if (cPMRecertNRNumber == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cPMRecertNRNumber + "',";
				}
				if (cPMRecertStateNumber == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cPMRecertStateNumber + "',";
				}
				if (cPMRecertCountyNumber == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cPMRecertCountyNumber + "', ";
				}
				SqlString = SqlString + cPMRecertGroupNumber.ToString() + ", ";
				SqlString = SqlString + "'" + cPMRecertLastUpdated + "','";
				SqlString = SqlString + cPMRecertLastUpdateBy + "' ";

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

		public int GetPMTrainingAnnualOTEPReport(int iYear, string sBatt, string sShift, int iGroup)
		{
			// Get Training OTEP Report for Year/PM Only/Shift
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spReport_TrainingPMOnlyAnnualOTEPModules " + iYear.ToString() + ", ";

				if (modGlobal.Clean(sBatt) == "")
				{
					SqlString = SqlString + "Null, ";
				}
				else
				{
					SqlString = SqlString + "'" + sBatt + "', ";
				}

				if (modGlobal.Clean(sShift) == "")
				{
					SqlString = SqlString + "Null, ";
				}
				else
				{
					SqlString = SqlString + "'" + sShift + "', ";
				}

				if (iGroup == 0)
				{
					SqlString = SqlString + "NULL ";
				}
				else
				{
					SqlString = SqlString + iGroup.ToString();
				}

				oCmd.CommandText = SqlString;

				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingRecord = oRec;
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

		public int GetPMTrainingQueryFiltered(string sStartDte, string sEndDte, int iPrimary, int lSecondary, int lSpecific, string sShift, string sUnit, string sBatt, string sName, string sComment, byte bFlag)
		{
			// Get Training Information for Filters
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spReport_TrainingPMOnlyQueryFiltered '" + sStartDte + "', '" + sEndDte + "', ";

				if (iPrimary == 0)
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + iPrimary.ToString() + ", ";
				}
				if (lSecondary == 0)
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + lSecondary.ToString() + ", ";
				}
				if (lSpecific == 0)
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + lSpecific.ToString() + ", ";
				}
				if (modGlobal.Clean(sShift) == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + sShift + "', ";
				}
				if (modGlobal.Clean(sUnit) == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + sUnit + "', ";
				}
				if (modGlobal.Clean(sBatt) == "")
				{
					SqlString = SqlString + "Null, ";
				}
				else
				{
					SqlString = SqlString + "'" + sBatt + "', ";
				}
				if (modGlobal.Clean(sName) == "")
				{
					SqlString = SqlString + "Null, ";
				}
				else
				{
					SqlString = SqlString + "'" + sName + "', ";
				}
				if (modGlobal.Clean(sComment) == "")
				{
					SqlString = SqlString + "Null, ";
				}
				else
				{
					SqlString = SqlString + "'" + sComment + "', ";
				}
				SqlString = SqlString + bFlag.ToString() + " ";

				oCmd.CommandText = SqlString;

				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingRecord = oRec;
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

		public int GetSpecificCodeByID(int lSpecific)
		{

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_TrainingSpecificCodeByID " + lSpecific.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingSpecificCode = oRec;
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

		public int GetTrainingParamedicRecertClasses()
		{
			// Get Training Paramedic Classes for Report
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_TrainingPMRecertClassesNew ";

				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingRecord = oRec;
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


		public int GetTrainingPMRecertificationReport(string dStartDate, string dEndDate, string sBatt, string sShift, int iGroup)
		{
			// Get Training Paramedic Only Recertification Report for Date Range /Batt/Shift
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spReport_TrainingPMOnlyRecertReport2 '" + dStartDate + "', '";
				SqlString = SqlString + dEndDate + "', ";

				if (modGlobal.Clean(sBatt) == "")
				{
					SqlString = SqlString + "Null, ";
				}
				else
				{
					SqlString = SqlString + "'" + sBatt + "', ";
				}

				if (modGlobal.Clean(sShift) == "")
				{
					SqlString = SqlString + "Null, ";
				}
				else
				{
					SqlString = SqlString + "'" + sShift + "', ";
				}

				if (iGroup == 0)
				{
					SqlString = SqlString + "Null ";
				}
				else
				{
					SqlString = SqlString + iGroup.ToString() + " ";
				}


				oCmd.CommandText = SqlString;

				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingRecord = oRec;
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

		public int GetEmployeePMRecertInfoByID(string sEmpID)
		{
			//Retrieve a record from Personnel/ParamedicRecertificationInfo by Employee ID
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_PersonnelParamedicRecertInfoByID '" + sEmpID + "' ";
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cEmployee = oRec;
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

		public int GetEmployeePMRecertOTEPTraining(string sEmpID, string sDateStart, string sDateEnd)
		{
			// Get Training Recertification Classes for Employee and Date
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string sSQLString = "";

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				sSQLString = "spReport_PMRecertOTEPTrainingbyEmpID '" + sEmpID + "', '" + sDateStart + "', ";
				sSQLString = sSQLString + "'" + sDateEnd + "' ";

				oCmd.CommandText = sSQLString;

				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingRecord = oRec;
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

		public int GetEmployeeALSProceduresForPMRecert(string sEmpID, string sDateStart, string sDateEnd)
		{
			// Get specific IRS ALS Procedures for Employee and Date
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string sSQLString = "";

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				sSQLString = "spReport_ParamedicALSRecertProcedures '" + sEmpID + "', '" + sDateStart + "', ";
				sSQLString = sSQLString + "'" + sDateEnd + "' ";

				oCmd.CommandText = sSQLString;

				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingRecord = oRec;
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

		public int GetEmployeeParamedicRecertTraining(string sEmpID, string sDateStart, string sDateEnd)
		{
			// Get Training Recertification Classes for Employee and Date
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string sSQLString = "";

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				sSQLString = "spReport_ParamedicRecertTrainingbyEmpID '" + sEmpID + "', '" + sDateStart + "', ";
				sSQLString = sSQLString + "'" + sDateEnd + "' ";

				oCmd.CommandText = sSQLString;

				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingRecord = oRec;
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

		public int GetEmployeePMRecertAdditionalCMEHours(string sEmpID, string sDateStart, string sDateEnd)
		{
			// Get Training Recertification Classes for Employee and Date
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string sSQLString = "";

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				sSQLString = "spReport_PMRecertAdditionalCMEHoursbyEmpID '" + sEmpID + "', '" + sDateStart + "', ";
				sSQLString = sSQLString + "'" + sDateEnd + "' ";

				oCmd.CommandText = sSQLString;

				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingRecord = oRec;
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

		public int GetEmployeePMRecertBaseStationHours(string sEmpID, string sDateStart, string sDateEnd)
		{
			// Get Training Recertification Classes for Employee and Date
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string sSQLString = "";

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				sSQLString = "spReport_PMRecertBaseStationHoursbyEmpID '" + sEmpID + "', '" + sDateStart + "', ";
				sSQLString = sSQLString + "'" + sDateEnd + "' ";

				oCmd.CommandText = sSQLString;

				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingRecord = oRec;
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

		public int GetEmployeePMRecertCategoryTotals(string sEmpID, string sDateStart, string sDateEnd)
		{
			// Get Training Recertification Classes for Employee and Date
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string sSQLString = "";

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				sSQLString = "spReport_PMRecertCatTotalHoursbyEmpID '" + sEmpID + "', '" + sDateStart + "', ";
				sSQLString = sSQLString + "'" + sDateEnd + "' ";

				oCmd.CommandText = sSQLString;

				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingRecord = oRec;
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

		public int GetEmployeePMRecertOTEPSummary(string sEmpID, string sDateStart, string sDateEnd)
		{
			// Get Training Recertification Classes for Employee and Date
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string sSQLString = "";

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				sSQLString = "spReport_PMRecertOTEPSummarybyEmpID '" + sEmpID + "', '" + sDateStart + "', ";
				sSQLString = sSQLString + "'" + sDateEnd + "' ";

				oCmd.CommandText = sSQLString;

				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingRecord = oRec;
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

		public int GetTrainingFCCDrillsByYearQuarter(int iYear, int iQuarter)
		{
			// Get Training FCC Standard Drills for Year/Quarter
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_TrainingFCCStandardsByYearQuarter " + iYear.ToString() + ", " + iQuarter.ToString() + " ";

				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingRecord = oRec;
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

		public int GetTrainingFCCQuarterlyStandardReport(int iYear, int iQuarter, string sShift)
		{
			// Get Training FCC Standard Drill Quarterly Report for Year/Quarter/Shift
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spReport_TrainingFCCQuarterlyStandardDrills " + iYear.ToString() + ", " + iQuarter.ToString() + ", ";

				if (modGlobal.Clean(sShift) == "")
				{
					SqlString = SqlString + "Null ";
				}
				else
				{
					SqlString = SqlString + "'" + sShift + "' ";
				}

				oCmd.CommandText = SqlString;

				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingRecord = oRec;
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

		public int GetPMAnnualBaseStationReport(int iYear, string sBatt, string sShift, int iGroup)
		{
			// Get Training Base Station Report for Year/PM Only/Shift/Group
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spReport_TrainingPMOnlyAnnualBaseStation " + iYear.ToString() + ", ";

				if (modGlobal.Clean(sBatt) == "")
				{
					SqlString = SqlString + "Null, ";
				}
				else
				{
					SqlString = SqlString + "'" + sBatt + "', ";
				}

				if (modGlobal.Clean(sShift) == "")
				{
					SqlString = SqlString + "Null, ";
				}
				else
				{
					SqlString = SqlString + "'" + sShift + "', ";
				}

				if (iGroup == 0)
				{
					SqlString = SqlString + "NULL ";
				}
				else
				{
					SqlString = SqlString + iGroup.ToString();
				}

				oCmd.CommandText = SqlString;

				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTrainingRecord = oRec;
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

		public int GetPersonnelWorkAsParamedicByID(int lPerSysID)
		{
			//Retrieve Records from PersonnelWorkAsParamedic by PerSysID
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_PersonnelWorkAsParamedicByID " + lPerSysID.ToString() + " ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cWAMPerSysID = Convert.ToInt32(modGlobal.GetVal(oRec["per_sys_id"]));
					if (modGlobal.Clean(oRec["inactivate_date"]) == "")
					{
						cWAMInactivateDate = "";
					}
					else
					{
						cWAMInactivateDate = Convert.ToDateTime(oRec["inactivate_date"]).ToString("MM/dd/yyyy");
					}
					cWAMUpdateDate = Convert.ToDateTime(oRec["update_date"]).ToString("MM/dd/yyyy HH:mm:ss");
					cWAMUpdateBy = modGlobal.Clean(oRec["update_by"]);
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

		public int AddPersonnelWorkAsParamedic()
		{
			//Insert Record into PersonnelWorkAsParamedic table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spInsert_PersonnelWorkAsParamedic " + cWAMPerSysID.ToString() + ",";

				SqlString = SqlString + "'" + cWAMUpdateDate + "','";
				SqlString = SqlString + cWAMUpdateBy + "' ";

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

		public int UpdatePersonnelWorkAsParamedic()
		{
			//Update Record into PersonnelWorkAsParamedic table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spUpdate_PersonnelWorkAsParamedic " + cWAMPerSysID.ToString() + ",";

				if (cWAMInactivateDate == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cWAMInactivateDate + "',";
				}

				SqlString = SqlString + "'" + cWAMUpdateDate + "','";
				SqlString = SqlString + cWAMUpdateBy + "' ";

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