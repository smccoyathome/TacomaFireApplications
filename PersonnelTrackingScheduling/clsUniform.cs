using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public class clsUniform
		: UpgradeHelpers.Interfaces.IDependentModel, UpgradeHelpers.Interfaces.ICreatesObjects, UpgradeHelpers
		.Interfaces.IInteractsWithView, UpgradeHelpers.Interfaces.IInitializableCommon, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(clsUniform));
		}

		void UpgradeHelpers.Interfaces.IInitializableCommon.Common()
		{
			_cUniformEmployee = null;
			_cPersonnelUniform = null;
			cPersUniformID = 0;
			cPersUniformEmpID = "";
			cPersUniformIssuedDate = "";
			cPersUniformReturnedDate = "";
			_cUniform = null;
			cUniformID = 0;
			cUniformType = 0;
			cUniformTrackingNumber = "";
			cUniformSizeType = 0;
			cUniformColorType = 0;
			cUniformRetiredDate = "";
			cUniformManufacturerID = 0;
			cUniformManufacturedDate = "";
			cUniformAlternateNum = "";
			_cUniformInspection = null;
			cUniformInspectID = 0;
			cUniformInspectUniformID = 0;
			cUniformInspectDate = "";
			cUniformInspectedBy = "";
			cUniformInspectPassedFlag = 0;
			_cUniformInspectionComment = null;
			cUniformInspCommentID = 0;
			cUniformInspCommentEmpID = "";
			cUniformInspCommentDate = "";
			cUniformInspectComment = "";
			_cUniformCommentForInsp = null;
			cUniformCommentInspID = 0;
			cUniformComment = "";
			cUniformCommentCreatedBy = "";
			cUniformCommentCreatedDate = "";
			cUniformCommentUpdatedBy = "";
			cUniformCommentUpdatedDate = "";
			_cUniformInventory = null;
			cUniformInventoryStation = "";
			cUniformInventoryUniformID = 0;
			_cUniformReasonRetiredInfo = null;
			cUniformReasonRetiredID = 0;
			cUniformReasonRetiredUniformID = 0;
			cUniformReasonRetiredReasonID = 0;
			cUniformReasonRetiredCreatedBy = "";
			cUniformReasonRetiredCreatedDate = "";
			cUniformReasonRetiredComment = "";
			_cUniformRepair = null;
			cUniformRepairID = 0;
			cUniformRepairUniformID = 0;
			cUniformRepairerID = 0;
			cUniformRepairDateIn = "";
			cUniformRepairDateOut = "";
			cUniformRepairComment = "";
			_cUniformLaundry = null;
			cUniformLaunderID = 0;
			cUniformLaunderUniformID = 0;
			cUniformLaunderDateFlagged = "";
			cUniformLaunderFlaggedBy = "";
			cUniformLaunderDateApproved = "";
			cUniformLaunderApprovedBy = "";
			cUniformLaunderComment = "";
			cUniformLaunderDateCleaned = "";
			cUniformLaunderCleanedBy = "";
			cUniformLaunderCleaningComments = "";
			cUniformLaunderVendorCleaned = "";
			_cEmployeeUniformSizes = null;
			cEmployeeUniformSizeEmployeeID = "";
			cEmployeeUniformSizeInDate = "";
			cEmployeeUniformSizePantSizeDesc = "";
			cEmployeeUniformSizePantSizeCode = 0;
			cEmployeeUniformSizeCoatSpreadDesc = "";
			cEmployeeUniformSizeCoatSizeDesc = "";
			cEmployeeUniformSizeCoatSizeCode = 0;
			cEmployeeUniformSizeBootManufDesc = "";
			cEmployeeUniformSizeBootManufID = 0;
			cEmployeeUniformSizeBootSpreadDesc = "";
			cEmployeeUniformSizeBootSizeCode = 0;
			cEmployeeUniformSizeGloveSizeDesc = "";
			cEmployeeUniformSizeGloveSizeCode = 0;
			cEmployeeUniformSizeBootSizeDesc = "";
			_cPersonnelUniformSizes = null;
			cPersonnelUniformSizesID = 0;
			cPersonnelUniformSizesEmployeeID = "";
			cPersonnelUniformSizesUniformType = 0;
			cPersonnelUniformSizesDateSized = "";
			cPersonnelUniformSizesSizeDescription = "";
			cPersonnelUniformSizesCreatedDate = "";
			cPersonnelUniformSizesCreatedBy = "";
		}

		//********************************************************
		//**    Uniform Class                                   **
		//********************************************************

		//Private Class Variables
		//Employee
		public virtual ADORecordSetHelper _cUniformEmployee { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cUniformEmployee
		{
			get
			{
				if (_cUniformEmployee == null)
				{
					_cUniformEmployee = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cUniformEmployee;
			}
			set
			{
				_cUniformEmployee = value;
			}
		}


		//PersonnelUniform
		public virtual ADORecordSetHelper _cPersonnelUniform { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cPersonnelUniform
		{
			get
			{
				if (_cPersonnelUniform == null)
				{
					_cPersonnelUniform = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cPersonnelUniform;
			}
			set
			{
				_cPersonnelUniform = value;
			}
		}

		public virtual int cPersUniformID { get; set; }

		public virtual string cPersUniformEmpID { get; set; }

		public virtual string cPersUniformIssuedDate { get; set; }

		public virtual string cPersUniformReturnedDate { get; set; }

		//Uniform
		public virtual ADORecordSetHelper _cUniform { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cUniform
		{
			get
			{
				if (_cUniform == null)
				{
					_cUniform = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cUniform;
			}
			set
			{
				_cUniform = value;
			}
		}

		public virtual int cUniformID { get; set; }

		public virtual int cUniformType { get; set; }

		public virtual string cUniformTrackingNumber { get; set; }

		public virtual int cUniformSizeType { get; set; }

		public virtual int cUniformColorType { get; set; }

		public virtual string cUniformRetiredDate { get; set; }

		public virtual int cUniformManufacturerID { get; set; }

		public virtual string cUniformManufacturedDate { get; set; }

		public virtual string cUniformAlternateNum { get; set; }

		//UniformInspection
		public virtual ADORecordSetHelper _cUniformInspection { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cUniformInspection
		{
			get
			{
				if (_cUniformInspection == null)
				{
					_cUniformInspection = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cUniformInspection;
			}
			set
			{
				_cUniformInspection = value;
			}
		}

		public virtual int cUniformInspectID { get; set; }

		public virtual int cUniformInspectUniformID { get; set; }

		public virtual string cUniformInspectDate { get; set; }

		public virtual string cUniformInspectedBy { get; set; }

		public virtual byte cUniformInspectPassedFlag { get; set; }

		//UniformInspectionComment
		public virtual ADORecordSetHelper _cUniformInspectionComment { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cUniformInspectionComment
		{
			get
			{
				if (_cUniformInspectionComment == null)
				{
					_cUniformInspectionComment = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cUniformInspectionComment;
			}
			set
			{
				_cUniformInspectionComment = value;
			}
		}

		public virtual int cUniformInspCommentID { get; set; }

		public virtual string cUniformInspCommentEmpID { get; set; }

		public virtual string cUniformInspCommentDate { get; set; }

		public virtual string cUniformInspectComment { get; set; }

		//UniformCommentForInspection
		public virtual ADORecordSetHelper _cUniformCommentForInsp { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cUniformCommentForInsp
		{
			get
			{
				if (_cUniformCommentForInsp == null)
				{
					_cUniformCommentForInsp = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cUniformCommentForInsp;
			}
			set
			{
				_cUniformCommentForInsp = value;
			}
		}

		public virtual int cUniformCommentInspID { get; set; }

		public virtual string cUniformComment { get; set; }

		public virtual string cUniformCommentCreatedBy { get; set; }

		public virtual string cUniformCommentCreatedDate { get; set; }

		public virtual string cUniformCommentUpdatedBy { get; set; }

		public virtual string cUniformCommentUpdatedDate { get; set; }

		//'UniformCommentForInspection
		//    inspection_id       int         IDENTITY    NOT NULL
		//    Comment Not Text
		//    created_by Not Char(5)
		//    created_date Not DateTime
		//    updated_by Not Char(5)
		//    updated_date Not DateTime


		//UniformInventory
		public virtual ADORecordSetHelper _cUniformInventory { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cUniformInventory
		{
			get
			{
				if (_cUniformInventory == null)
				{
					_cUniformInventory = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cUniformInventory;
			}
			set
			{
				_cUniformInventory = value;
			}
		}

		public virtual string cUniformInventoryStation { get; set; }

		public virtual int cUniformInventoryUniformID { get; set; }

		//UniformReasonRetiredInfo
		public virtual ADORecordSetHelper _cUniformReasonRetiredInfo { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cUniformReasonRetiredInfo
		{
			get
			{
				if (_cUniformReasonRetiredInfo == null)
				{
					_cUniformReasonRetiredInfo = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cUniformReasonRetiredInfo;
			}
			set
			{
				_cUniformReasonRetiredInfo = value;
			}
		}

		public virtual int cUniformReasonRetiredID { get; set; }

		public virtual int cUniformReasonRetiredUniformID { get; set; }

		public virtual int cUniformReasonRetiredReasonID { get; set; }

		public virtual string cUniformReasonRetiredCreatedBy { get; set; }

		public virtual string cUniformReasonRetiredCreatedDate { get; set; }

		public virtual string cUniformReasonRetiredComment { get; set; }

		//UniformRepair
		public virtual ADORecordSetHelper _cUniformRepair { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cUniformRepair
		{
			get
			{
				if (_cUniformRepair == null)
				{
					_cUniformRepair = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cUniformRepair;
			}
			set
			{
				_cUniformRepair = value;
			}
		}

		public virtual int cUniformRepairID { get; set; }

		public virtual int cUniformRepairUniformID { get; set; }

		public virtual int cUniformRepairerID { get; set; }

		public virtual string cUniformRepairDateIn { get; set; }

		public virtual string cUniformRepairDateOut { get; set; }

		public virtual string cUniformRepairComment { get; set; }

		//UniformLaunderInfo
		public virtual ADORecordSetHelper _cUniformLaundry { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cUniformLaundry
		{
			get
			{
				if (_cUniformLaundry == null)
				{
					_cUniformLaundry = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cUniformLaundry;
			}
			set
			{
				_cUniformLaundry = value;
			}
		}

		public virtual int cUniformLaunderID { get; set; }

		public virtual int cUniformLaunderUniformID { get; set; }

		public virtual string cUniformLaunderDateFlagged { get; set; }

		public virtual string cUniformLaunderFlaggedBy { get; set; }

		public virtual string cUniformLaunderDateApproved { get; set; }

		public virtual string cUniformLaunderApprovedBy { get; set; }

		public virtual string cUniformLaunderComment { get; set; }

		public virtual string cUniformLaunderDateCleaned { get; set; }

		public virtual string cUniformLaunderCleanedBy { get; set; }

		public virtual string cUniformLaunderCleaningComments { get; set; }

		public virtual string cUniformLaunderVendorCleaned { get; set; }

		//UniformEmployeePPESizes
		public virtual ADORecordSetHelper _cEmployeeUniformSizes { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cEmployeeUniformSizes
		{
			get
			{
				if (_cEmployeeUniformSizes == null)
				{
					_cEmployeeUniformSizes = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cEmployeeUniformSizes;
			}
			set
			{
				_cEmployeeUniformSizes = value;
			}
		}

		public virtual string cEmployeeUniformSizeEmployeeID { get; set; }

		public virtual string cEmployeeUniformSizeInDate { get; set; }

		public virtual string cEmployeeUniformSizePantSizeDesc { get; set; }

		public virtual int cEmployeeUniformSizePantSizeCode { get; set; }

		public virtual string cEmployeeUniformSizeCoatSpreadDesc { get; set; }

		public virtual string cEmployeeUniformSizeCoatSizeDesc { get; set; }

		public virtual int cEmployeeUniformSizeCoatSizeCode { get; set; }

		public virtual string cEmployeeUniformSizeBootManufDesc { get; set; }

		public virtual int cEmployeeUniformSizeBootManufID { get; set; }

		public virtual string cEmployeeUniformSizeBootSpreadDesc { get; set; }

		public virtual int cEmployeeUniformSizeBootSizeCode { get; set; }

		public virtual string cEmployeeUniformSizeGloveSizeDesc { get; set; }

		public virtual int cEmployeeUniformSizeGloveSizeCode { get; set; }

		public virtual string cEmployeeUniformSizeBootSizeDesc { get; set; }

		//PersonnelUniformSizes
		public virtual ADORecordSetHelper _cPersonnelUniformSizes { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cPersonnelUniformSizes
		{
			get
			{
				if (_cPersonnelUniformSizes == null)
				{
					_cPersonnelUniformSizes = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cPersonnelUniformSizes;
			}
			set
			{
				_cPersonnelUniformSizes = value;
			}
		}

		public virtual int cPersonnelUniformSizesID { get; set; }

		public virtual string cPersonnelUniformSizesEmployeeID { get; set; }

		public virtual int cPersonnelUniformSizesUniformType { get; set; }

		public virtual string cPersonnelUniformSizesDateSized { get; set; }

		public virtual string cPersonnelUniformSizesSizeDescription { get; set; }

		public virtual string cPersonnelUniformSizesCreatedDate { get; set; }

		public virtual string cPersonnelUniformSizesCreatedBy { get; set; }

		//Class Public Properties
		//Employee
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper UniformEmployee
		{
			get
			{
				return cUniformEmployee;
			}
			set
			{
				cUniformEmployee = value;
			}
		}


		//PersonnelUniform
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper PersonnelUniform
		{
			get
			{
				return cPersonnelUniform;
			}
			set
			{
				cPersonnelUniform = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int PersUniformID
		{
			get
			{
				return cPersUniformID;
			}
			set
			{
				cPersUniformID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PersUniformEmpID
		{
			get
			{
				return cPersUniformEmpID;
			}
			set
			{
				cPersUniformEmpID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PersUniformIssuedDate
		{
			get
			{
				return cPersUniformIssuedDate;
			}
			set
			{
				cPersUniformIssuedDate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PersUniformReturnedDate
		{
			get
			{
				return cPersUniformReturnedDate;
			}
			set
			{
				cPersUniformReturnedDate = value;
			}
		}


		//Uniform
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper Uniform
		{
			get
			{
				return cUniform;
			}
			set
			{
				cUniform = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int UniformID
		{
			get
			{
				return cUniformID;
			}
			set
			{
				cUniformID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int UniformType
		{
			get
			{
				return cUniformType;
			}
			set
			{
				cUniformType = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UniformTrackingNumber
		{
			get
			{
				return cUniformTrackingNumber;
			}
			set
			{
				cUniformTrackingNumber = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int UniformSizeType
		{
			get
			{
				return cUniformSizeType;
			}
			set
			{
				cUniformSizeType = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int UniformColorType
		{
			get
			{
				return cUniformColorType;
			}
			set
			{
				cUniformColorType = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UniformRetiredDate
		{
			get
			{
				return cUniformRetiredDate;
			}
			set
			{
				cUniformRetiredDate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int UniformManufacturerID
		{
			get
			{
				return cUniformManufacturerID;
			}
			set
			{
				cUniformManufacturerID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UniformManufacturedDate
		{
			get
			{
				return cUniformManufacturedDate;
			}
			set
			{
				cUniformManufacturedDate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UniformAlternateNum
		{
			get
			{
				return cUniformAlternateNum;
			}
			set
			{
				cUniformAlternateNum = value;
			}
		}


		//UniformInspection
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper UniformInspection
		{
			get
			{
				return cUniformInspection;
			}
			set
			{
				cUniformInspection = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int UniformInspectID
		{
			get
			{
				return cUniformInspectID;
			}
			set
			{
				cUniformInspectID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int UniformInspectUniformID
		{
			get
			{
				return cUniformInspectUniformID;
			}
			set
			{
				cUniformInspectUniformID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UniformInspectDate
		{
			get
			{
				return cUniformInspectDate;
			}
			set
			{
				cUniformInspectDate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UniformInspectedBy
		{
			get
			{
				return cUniformInspectedBy;
			}
			set
			{
				cUniformInspectedBy = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte UniformInspectPassedFlag
		{
			get
			{
				return cUniformInspectPassedFlag;
			}
			set
			{
				cUniformInspectPassedFlag = value;
			}
		}


		//UniformInspectionComment
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper UniformInspectionComment
		{
			get
			{
				return cUniformInspectionComment;
			}
			set
			{
				cUniformInspectionComment = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int UniformInspCommentID
		{
			get
			{
				return cUniformInspCommentID;
			}
			set
			{
				cUniformInspCommentID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UniformInspCommentEmpID
		{
			get
			{
				return cUniformInspCommentEmpID;
			}
			set
			{
				cUniformInspCommentEmpID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UniformInspCommentDate
		{
			get
			{
				return cUniformInspCommentDate;
			}
			set
			{
				cUniformInspCommentDate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UniformInspectComment
		{
			get
			{
				return cUniformInspectComment;
			}
			set
			{
				cUniformInspectComment = value;
			}
		}


		//UniformCommentForInspection
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper UniformCommentForInsp
		{
			get
			{
				return cUniformCommentForInsp;
			}
			set
			{
				cUniformCommentForInsp = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int UniformCommentInspID
		{
			get
			{
				return cUniformCommentInspID;
			}
			set
			{
				cUniformCommentInspID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UniformComment
		{
			get
			{
				return cUniformComment;
			}
			set
			{
				cUniformComment = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UniformCommentCreatedBy
		{
			get
			{
				return cUniformCommentCreatedBy;
			}
			set
			{
				cUniformCommentCreatedBy = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UniformCommentCreatedDate
		{
			get
			{
				return cUniformCommentCreatedDate;
			}
			set
			{
				cUniformCommentCreatedDate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UniformCommentUpdatedBy
		{
			get
			{
				return cUniformCommentUpdatedBy;
			}
			set
			{
				cUniformCommentUpdatedBy = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UniformCommentUpdatedDate
		{
			get
			{
				return cUniformCommentUpdatedDate;
			}
			set
			{
				cUniformCommentUpdatedDate = value;
			}
		}


		//UniformInventory
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper UniformInventory
		{
			get
			{
				return cUniformInventory;
			}
			set
			{
				cUniformInventory = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UniformInventoryStation
		{
			get
			{
				return cUniformInventoryStation;
			}
			set
			{
				cUniformInventoryStation = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int UniformInventoryUniformID
		{
			get
			{
				return cUniformInventoryUniformID;
			}
			set
			{
				cUniformInventoryUniformID = value;
			}
		}


		//UniformReasonRetiredInfo
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper UniformReasonRetiredInfo
		{
			get
			{
				return cUniformReasonRetiredInfo;
			}
			set
			{
				cUniformReasonRetiredInfo = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int UniformReasonRetiredID
		{
			get
			{
				return cUniformReasonRetiredID;
			}
			set
			{
				cUniformReasonRetiredID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int UniformReasonRetiredUniformID
		{
			get
			{
				return cUniformReasonRetiredUniformID;
			}
			set
			{
				cUniformReasonRetiredUniformID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int UniformReasonRetiredReasonID
		{
			get
			{
				return cUniformReasonRetiredReasonID;
			}
			set
			{
				cUniformReasonRetiredReasonID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UniformReasonRetiredCreatedBy
		{
			get
			{
				return cUniformReasonRetiredCreatedBy;
			}
			set
			{
				cUniformReasonRetiredCreatedBy = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UniformReasonRetiredCreatedDate
		{
			get
			{
				return cUniformReasonRetiredCreatedDate;
			}
			set
			{
				cUniformReasonRetiredCreatedDate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UniformReasonRetiredComment
		{
			get
			{
				return cUniformReasonRetiredComment;
			}
			set
			{
				cUniformReasonRetiredComment = value;
			}
		}


		//UniformRepair
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper UniformRepair
		{
			get
			{
				return cUniformRepair;
			}
			set
			{
				cUniformRepair = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int UniformRepairID
		{
			get
			{
				return cUniformRepairID;
			}
			set
			{
				cUniformRepairID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int UniformRepairUniformID
		{
			get
			{
				return cUniformRepairUniformID;
			}
			set
			{
				cUniformRepairUniformID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int UniformRepairerID
		{
			get
			{
				return cUniformRepairerID;
			}
			set
			{
				cUniformRepairerID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UniformRepairDateIn
		{
			get
			{
				return cUniformRepairDateIn;
			}
			set
			{
				cUniformRepairDateIn = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UniformRepairDateOut
		{
			get
			{
				return cUniformRepairDateOut;
			}
			set
			{
				cUniformRepairDateOut = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UniformRepairComment
		{
			get
			{
				return cUniformRepairComment;
			}
			set
			{
				cUniformRepairComment = value;
			}
		}


		//UniformLaunderInfo
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper UniformLaundry
		{
			get
			{
				return cUniformLaundry;
			}
			set
			{
				cUniformLaundry = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int UniformLaunderID
		{
			get
			{
				return cUniformLaunderID;
			}
			set
			{
				cUniformLaunderID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int UniformLaunderUniformID
		{
			get
			{
				return cUniformLaunderUniformID;
			}
			set
			{
				cUniformLaunderUniformID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UniformLaunderDateFlagged
		{
			get
			{
				return cUniformLaunderDateFlagged;
			}
			set
			{
				cUniformLaunderDateFlagged = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UniformLaunderFlaggedBy
		{
			get
			{
				return cUniformLaunderFlaggedBy;
			}
			set
			{
				cUniformLaunderFlaggedBy = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UniformLaunderDateApproved
		{
			get
			{
				return cUniformLaunderDateApproved;
			}
			set
			{
				cUniformLaunderDateApproved = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UniformLaunderApprovedBy
		{
			get
			{
				return cUniformLaunderApprovedBy;
			}
			set
			{
				cUniformLaunderApprovedBy = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UniformLaunderComment
		{
			get
			{
				return cUniformLaunderComment;
			}
			set
			{
				cUniformLaunderComment = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UniformLaunderDateCleaned
		{
			get
			{
				return cUniformLaunderDateCleaned;
			}
			set
			{
				cUniformLaunderDateCleaned = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UniformLaunderCleanedBy
		{
			get
			{
				return cUniformLaunderCleanedBy;
			}
			set
			{
				cUniformLaunderCleanedBy = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UniformLaunderCleaningComments
		{
			get
			{
				return cUniformLaunderCleaningComments;
			}
			set
			{
				cUniformLaunderCleaningComments = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UniformLaunderVendorCleaned
		{
			get
			{
				return cUniformLaunderVendorCleaned;
			}
			set
			{
				cUniformLaunderVendorCleaned = value;
			}
		}


		//UniformEmployeePPESizes
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper EmployeeUniformSizes
		{
			get
			{
				return cEmployeeUniformSizes;
			}
			set
			{
				cEmployeeUniformSizes = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string EmployeeUniformSizeEmployeeID
		{
			get
			{
				return cEmployeeUniformSizeEmployeeID;
			}
			set
			{
				cEmployeeUniformSizeEmployeeID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string EmployeeUniformSizeInDate
		{
			get
			{
				return cEmployeeUniformSizeInDate;
			}
			set
			{
				cEmployeeUniformSizeInDate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string EmployeeUniformSizePantSizeDesc
		{
			get
			{
				return cEmployeeUniformSizePantSizeDesc;
			}
			set
			{
				cEmployeeUniformSizePantSizeDesc = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int EmployeeUniformSizePantSizeCode
		{
			get
			{
				return cEmployeeUniformSizePantSizeCode;
			}
			set
			{
				cEmployeeUniformSizePantSizeCode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string EmployeeUniformSizeCoatSpreadDesc
		{
			get
			{
				return cEmployeeUniformSizeCoatSpreadDesc;
			}
			set
			{
				cEmployeeUniformSizeCoatSpreadDesc = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string EmployeeUniformSizeCoatSizeDesc
		{
			get
			{
				return cEmployeeUniformSizeCoatSizeDesc;
			}
			set
			{
				cEmployeeUniformSizeCoatSizeDesc = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int EmployeeUniformSizeCoatSizeCode
		{
			get
			{
				return cEmployeeUniformSizeCoatSizeCode;
			}
			set
			{
				cEmployeeUniformSizeCoatSizeCode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string EmployeeUniformSizeBootManufDesc
		{
			get
			{
				return cEmployeeUniformSizeBootManufDesc;
			}
			set
			{
				cEmployeeUniformSizeBootManufDesc = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int EmployeeUniformSizeBootManufID
		{
			get
			{
				return cEmployeeUniformSizeBootManufID;
			}
			set
			{
				cEmployeeUniformSizeBootManufID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string EmployeeUniformSizeBootSpreadDesc
		{
			get
			{
				return cEmployeeUniformSizeBootSpreadDesc;
			}
			set
			{
				cEmployeeUniformSizeBootSpreadDesc = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int EmployeeUniformSizeBootSizeCode
		{
			get
			{
				return cEmployeeUniformSizeBootSizeCode;
			}
			set
			{
				cEmployeeUniformSizeBootSizeCode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string EmployeeUniformSizeGloveSizeDesc
		{
			get
			{
				return cEmployeeUniformSizeGloveSizeDesc;
			}
			set
			{
				cEmployeeUniformSizeGloveSizeDesc = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int EmployeeUniformSizeGloveSizeCode
		{
			get
			{
				return cEmployeeUniformSizeGloveSizeCode;
			}
			set
			{
				cEmployeeUniformSizeGloveSizeCode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string EmployeeUniformSizeBootSizeDesc
		{
			get
			{
				return cEmployeeUniformSizeBootSizeDesc;
			}
			set
			{
				cEmployeeUniformSizeBootSizeDesc = value;
			}
		}


		//PersonnelUniformSizes
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper PersonnelUniformSizes
		{
			get
			{
				return cPersonnelUniformSizes;
			}
			set
			{
				cPersonnelUniformSizes = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int PersonnelUniformSizesID
		{
			get
			{
				return cPersonnelUniformSizesID;
			}
			set
			{
				cPersonnelUniformSizesID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PersonnelUniformSizesEmployeeID
		{
			get
			{
				return cPersonnelUniformSizesEmployeeID;
			}
			set
			{
				cPersonnelUniformSizesEmployeeID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int PersonnelUniformSizesUniformType
		{
			get
			{
				return cPersonnelUniformSizesUniformType;
			}
			set
			{
				cPersonnelUniformSizesUniformType = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PersonnelUniformSizesDateSized
		{
			get
			{
				return cPersonnelUniformSizesDateSized;
			}
			set
			{
				cPersonnelUniformSizesDateSized = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PersonnelUniformSizesSizeDescription
		{
			get
			{
				return cPersonnelUniformSizesSizeDescription;
			}
			set
			{
				cPersonnelUniformSizesSizeDescription = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PersonnelUniformSizesCreatedDate
		{
			get
			{
				return cPersonnelUniformSizesCreatedDate;
			}
			set
			{
				cPersonnelUniformSizesCreatedDate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PersonnelUniformSizesCreatedBy
		{
			get
			{
				return cPersonnelUniformSizesCreatedBy;
			}
			set
			{
				cPersonnelUniformSizesCreatedBy = value;
			}
		}



		public int InsertUniform()
		{
			//Insert Record into Uniform table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spInsertUniform " + cUniformType.ToString() + ",'" + cUniformTrackingNumber;
				if (cUniformSizeType == 0)
				{
					SqlString = SqlString + "', NULL,";
				}
				else
				{
					SqlString = SqlString + "'," + cUniformSizeType.ToString() + ",";
				}
				if (cUniformColorType == 0)
				{
					SqlString = SqlString + " NULL,";
				}
				else
				{
					SqlString = SqlString + cUniformColorType.ToString() + ",";
				}
				if (cUniformRetiredDate == "")
				{
					SqlString = SqlString + "NULL,";
				}
				else
				{
					SqlString = SqlString + "'" + cUniformRetiredDate + "',";
				}
				if (cUniformManufacturerID == 0)
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + cUniformManufacturerID.ToString() + ", ";
				}
				if (cUniformManufacturedDate == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cUniformManufacturedDate + "', ";
				}
				if (cUniformAlternateNum == "")
				{
					SqlString = SqlString + "NULL ";
				}
				else
				{
					SqlString = SqlString + "'" + cUniformAlternateNum + "' ";
				}

				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				//UPGRADE_WARNING: (2065) ADODB.Recordset method oRec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
				oRec = oRec.NextRecordSet();
				if (!oRec.EOF)
				{
					cUniformID = Convert.ToInt32(oRec[0]);
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

		public int InsertPersonnelUniform()
		{
			//Insert Record into PersonnelUniform table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spInsertPersonnelUniform " + cPersUniformID.ToString() + ", '" + cPersUniformEmpID + "', ";
				SqlString = SqlString + "'" + cPersUniformIssuedDate + "', NULL ";

				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int GetPPEInfoForSecurity(string sEmpID)
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
				oCmd.CommandText = "spSelect_PPEUserSecurityInfo '" + sEmpID + "' ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cUniformEmployee = oRec;
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

		public int UpdateUniform()
		{
			//Update Uniform Table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spUpdateUniform " + cUniformID.ToString() + ", " + cUniformType.ToString() + ", '";
				SqlString = SqlString + modGlobal.Clean(cUniformTrackingNumber) + "', ";
				if (cUniformSizeType == 0)
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + cUniformSizeType.ToString() + ", ";
				}
				if (cUniformColorType == 0)
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + cUniformColorType.ToString() + ", ";
				}
				if (modGlobal.Clean(cUniformRetiredDate) == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cUniformRetiredDate + "', ";
				}
				if (cUniformManufacturerID == 0)
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + cUniformManufacturerID.ToString() + ", ";
				}
				if (modGlobal.Clean(cUniformManufacturedDate) == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cUniformManufacturedDate + "', ";
				}
				if (cUniformAlternateNum == "")
				{
					SqlString = SqlString + "NULL ";
				}
				else
				{
					SqlString = SqlString + "'" + cUniformAlternateNum + "' ";
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

		public int GetUniformByID(int lUniformID)
		{
			//Retrieve Records from Uniform by specific ID
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_UniformByID " + lUniformID.ToString() + " ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cUniformID = Convert.ToInt32(modGlobal.GetVal(oRec["uniform_id"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cUniformType = Convert.ToInt32(modGlobal.GetVal(oRec["uniform_type"]));
					cUniformTrackingNumber = modGlobal.Clean(oRec["tracking_number"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cUniformSizeType = Convert.ToInt32(modGlobal.GetVal(oRec["size_type"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cUniformColorType = Convert.ToInt32(modGlobal.GetVal(oRec["color_type"]));
					if (modGlobal.Clean(oRec["retired_date"]) == "")
					{
						cUniformRetiredDate = "";
					}
					else
					{
						cUniformRetiredDate = Convert.ToDateTime(oRec["retired_date"]).ToString("MM/dd/yyyy");
					}
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cUniformManufacturerID = Convert.ToInt32(modGlobal.GetVal(oRec["manufacturer_id"]));
					if (modGlobal.Clean(oRec["manufactured_date"]) == "")
					{
						cUniformManufacturedDate = "";
					}
					else
					{
						cUniformManufacturedDate = Convert.ToDateTime(oRec["manufactured_date"]).ToString("MM/dd/yyyy");
					}
					cUniformAlternateNum = modGlobal.Clean(oRec["alternate_num"]);
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

		public int UpdatePersonnelUniform()
		{
			//Update PersonnelUniform Table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spUpdatePersonnelUniform " + cPersUniformID.ToString() + ", '" + cPersUniformEmpID + "', ";
				if (modGlobal.Clean(cPersUniformIssuedDate) == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cPersUniformIssuedDate + "', ";
				}
				if (modGlobal.Clean(cPersUniformReturnedDate) == "")
				{
					SqlString = SqlString + "NULL ";
				}
				else
				{
					SqlString = SqlString + "'" + cPersUniformReturnedDate + "' ";
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

		public int UpdatePersonnelUniformReturnDate()
		{
			//Update PersonnelUniform.return_date field
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spUpdatePersonnelUniformReturnedDate " + cPersUniformID.ToString() + ", '" + cPersUniformEmpID + "', ";
				if (modGlobal.Clean(cPersUniformReturnedDate) == "")
				{
					SqlString = SqlString + "NULL ";
				}
				else
				{
					SqlString = SqlString + "'" + cPersUniformReturnedDate + "' ";
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

		public int InsertUniformReasonRetiredInfo()
		{
			//Insert Record into UniformReasonRetiredInfo table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spInsertUniformReasonRetiredInfo " + cUniformReasonRetiredUniformID.ToString();
				if (cUniformReasonRetiredReasonID == 0)
				{
					SqlString = SqlString + ", NULL,";
				}
				else
				{
					SqlString = SqlString + ", " + cUniformReasonRetiredReasonID.ToString() + ", ";
				}
				SqlString = SqlString + " '" + cUniformReasonRetiredCreatedBy + "', '";
				SqlString = SqlString + cUniformReasonRetiredCreatedDate + "', ";
				if (cUniformReasonRetiredComment == "")
				{
					SqlString = SqlString + "NULL ";
				}
				else
				{
					SqlString = SqlString + "'" + cUniformReasonRetiredComment + "' ";
				}
				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int GetUniformInventoryList(int iStation, int iType, int iManufId, int iColor, int iSize)
		{
			//Retrieve Uniform Inventory List from the database
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string sSQLString = "";

			try
			{

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				sSQLString = "spSelect_UniformInventoryList ";

				if (iStation == 0)
				{
					sSQLString = sSQLString + "NULL, ";
				}
				else
				{
					sSQLString = sSQLString + iStation.ToString() + ", ";
				}

				if (iType == 0)
				{
					sSQLString = sSQLString + "NULL, ";
				}
				else
				{
					sSQLString = sSQLString + iType.ToString() + ", ";
				}

				if (iManufId == 0)
				{
					sSQLString = sSQLString + "NULL, ";
				}
				else
				{
					sSQLString = sSQLString + iManufId.ToString() + ", ";
				}

				if (iColor == 0)
				{
					sSQLString = sSQLString + "NULL, ";
				}
				else
				{
					sSQLString = sSQLString + iColor.ToString() + ", ";
				}

				if (iSize == 0)
				{
					sSQLString = sSQLString + "NULL ";
				}
				else
				{
					sSQLString = sSQLString + iSize.ToString() + " ";
				}

				oCmd.CommandText = sSQLString;
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cUniform = oRec;
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

		public int GetInactiveUniformInventoryList(int iStation, int iType, int iManufId, int iColor, int iSize)
		{
			//Retrieve Uniform Inventory List from the database
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string sSQLString = "";

			try
			{

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				sSQLString = "spSelect_InactiveUniformList ";

				if (iStation == 0)
				{
					sSQLString = sSQLString + "NULL, ";
				}
				else
				{
					sSQLString = sSQLString + iStation.ToString() + ", ";
				}

				if (iType == 0)
				{
					sSQLString = sSQLString + "NULL, ";
				}
				else
				{
					sSQLString = sSQLString + iType.ToString() + ", ";
				}

				if (iManufId == 0)
				{
					sSQLString = sSQLString + "NULL, ";
				}
				else
				{
					sSQLString = sSQLString + iManufId.ToString() + ", ";
				}

				if (iColor == 0)
				{
					sSQLString = sSQLString + "NULL, ";
				}
				else
				{
					sSQLString = sSQLString + iColor.ToString() + ", ";
				}

				if (iSize == 0)
				{
					sSQLString = sSQLString + "NULL ";
				}
				else
				{
					sSQLString = sSQLString + iSize.ToString() + " ";
				}

				oCmd.CommandText = sSQLString;
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cUniform = oRec;
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

		public int InsertUniformInspection()
		{
			//Insert Record into UniformInspection table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spInsertUniformInspection " + cUniformInspectUniformID.ToString() + ",'" + cUniformInspectDate;
				SqlString = SqlString + "', '" + cUniformInspectedBy + "', " + cUniformInspectPassedFlag.ToString() + " ";

				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				//UPGRADE_WARNING: (2065) ADODB.Recordset method oRec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
				oRec = oRec.NextRecordSet();
				if (!oRec.EOF)
				{
					cUniformInspectID = Convert.ToInt32(oRec[0]);
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

		public int InsertUniformInspectionComment()
		{
			//Insert Record into UniformInspectionComment table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spInsertUniformInspectionComment '" + cUniformInspCommentEmpID + "','" + cUniformInspCommentDate;
				SqlString = SqlString + "', '" + cUniformInspectComment + "' ";

				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				//UPGRADE_WARNING: (2065) ADODB.Recordset method oRec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
				oRec = oRec.NextRecordSet();
				if (!oRec.EOF)
				{
					cUniformInspCommentID = Convert.ToInt32(oRec[0]);
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

		public int GetUniformInspectionCommentByEmpDate(string sEmpID, string sDate)
		{
			//Retrieve Row from UniformInspectionCommentRecord for specific
			// Employee ID and Inspection Date
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_UniformInspectionCommentByEmpDate '" + sEmpID + "', '" + sDate + "' ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cUniformInspCommentID = Convert.ToInt32(modGlobal.GetVal(oRec["comment_id"]));
					cUniformInspCommentEmpID = modGlobal.Clean(oRec["employee_id"]);
					cUniformInspCommentDate = Convert.ToDateTime(oRec["inspection_date"]).ToString("M/d/yyyy");
					cUniformInspectComment = modGlobal.Clean(oRec["comment"]);
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

		public int UpdateUniformInspection()
		{
			//Update UniformInspection Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spUpdateUniformInspection " + cUniformInspectID.ToString() + ", '" + cUniformInspectDate + "', '";
				SqlString = SqlString + cUniformInspectedBy + "', " + cUniformInspectPassedFlag.ToString() + " ";

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

		public int UpdateUniformInspectionComment()
		{
			//Update UniformInspectionComment Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spUpdateUniformInspectionComment " + cUniformInspCommentID.ToString() + ", '" + cUniformInspCommentDate + "', '";
				SqlString = SqlString + cUniformInspectComment + "' ";

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

		public int GetLastUniformInspectionDate(string sEmpID)
		{
			//Retrieve Last UniformInspection.inspection_date for specific Employee
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string sSQLString = "";

			try
			{

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				sSQLString = "spSelect_LastUniformInspectionDate '" + sEmpID + "' ";

				oCmd.CommandText = sSQLString;
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					if (modGlobal.Clean(oRec["last_inspection"]) != "")
					{
						cUniformInspectDate = Convert.ToString(oRec["last_inspection"]);
						return -1;
					}
				}

				return 0;
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public int GetPersonnelUniformByEmpIDUniformID(string sEmpID, int lUniformID)
		{
			//Retrieve Records from PersonnelUniform by Employee ID & Uniform ID
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_PersonnelUniformByEmpID '" + sEmpID + "', " + lUniformID.ToString() + " ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cPersUniformID = Convert.ToInt32(modGlobal.GetVal(oRec["uniform_id"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cPersUniformEmpID = Convert.ToString(modGlobal.GetVal(oRec["employee_id"]));
					if (modGlobal.Clean(oRec["issued_date"]) == "")
					{
						cPersUniformIssuedDate = "";
					}
					else
					{
						cPersUniformIssuedDate = Convert.ToDateTime(oRec["issued_date"]).ToString("M/d/yyyy");
					}
					if (modGlobal.Clean(oRec["returned_date"]) == "")
					{
						cPersUniformReturnedDate = "";
					}
					else
					{
						cPersUniformReturnedDate = Convert.ToDateTime(oRec["returned_date"]).ToString("M/d/yyyy");
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

		public int InsertUniformInventory()
		{
			//Insert Record into UniformInventory table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				if (modGlobal.Clean(cUniformInventoryStation) != "")
				{
					SqlString = "spInsert_UniformInventory " + cUniformInventoryStation + ", " + cUniformInventoryUniformID.ToString() + " ";
					oCmd.CommandText = SqlString;
					oRec = ADORecordSetHelper.Open(oCmd, "");
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

		public int DeleteUniformInventory(int lUniformID)
		{
			//Delete Record from UniformInventory table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spDelete_UniformInventory " + lUniformID.ToString() + " ";

				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int GetUniformReasonRetiredByID(int lUniformID)
		{
			//Retrieve Records from UniformReaspmRetiredInfo by specific Uniform ID
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_UniformReasonRetiredInfoByUniformID " + lUniformID.ToString() + " ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cUniformReasonRetiredID = Convert.ToInt32(modGlobal.GetVal(oRec["retired_id"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cUniformReasonRetiredUniformID = Convert.ToInt32(modGlobal.GetVal(oRec["uniform_id"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cUniformReasonRetiredReasonID = Convert.ToInt32(modGlobal.GetVal(oRec["reason_id"]));
					cUniformReasonRetiredCreatedBy = modGlobal.Clean(oRec["created_by"]);
					cUniformReasonRetiredCreatedDate = modGlobal.Clean(oRec["created_date"]);
					cUniformReasonRetiredComment = modGlobal.Clean("comment");
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

		public int DeleteUniformReasonRetiredByUniformID(int lUniformID)
		{
			//Delete Record from UniformReasonRetiredInfo table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spDelete_UniformReasonRetiredInfo " + lUniformID.ToString() + " ";

				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int GetRefreshedUniformInventoryRow(int lUniformID)
		{
			//Retrieve specificUniform Inventory Row from the database
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string sSQLString = "";

			try
			{

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				sSQLString = "spSelect_RefreshUniformInventoryRowByID " + lUniformID.ToString() + " ";

				oCmd.CommandText = sSQLString;
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cUniform = oRec;
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

		public int GetUniformGlobeList(int iType, int iStation, string sName, string sOrder, string sSyle, string sColor, string sLength, string sSleeve, string sDate, string sChstWaist)
		{
			//Retrieve Uniform Globe Data List from the database
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string sSQLString = "";

			try
			{

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				sSQLString = "spSelect_UniformGlobalDataList ";

				if (iType == 0)
				{
					sSQLString = sSQLString + "NULL, ";
				}
				else
				{
					sSQLString = sSQLString + iType.ToString() + ", ";
				}

				if (iStation == 0)
				{
					sSQLString = sSQLString + "NULL, ";
				}
				else
				{
					sSQLString = sSQLString + iStation.ToString() + ", ";
				}

				if (sName == "")
				{
					sSQLString = sSQLString + "NULL, ";
				}
				else
				{
					sSQLString = sSQLString + "'" + sName + "', ";
				}

				if (sOrder == "")
				{
					sSQLString = sSQLString + "NULL, ";
				}
				else
				{
					sSQLString = sSQLString + "'" + sOrder + "', ";
				}

				if (sSyle == "")
				{
					sSQLString = sSQLString + "NULL, ";
				}
				else
				{
					sSQLString = sSQLString + "'" + sSyle + "', ";
				}

				if (sColor == "")
				{
					sSQLString = sSQLString + "NULL, ";
				}
				else
				{
					sSQLString = sSQLString + "'" + sColor + "', ";
				}

				if (sLength == "")
				{
					sSQLString = sSQLString + "NULL, ";
				}
				else
				{
					sSQLString = sSQLString + "'" + sLength + "', ";
				}

				if (sSleeve == "")
				{
					sSQLString = sSQLString + "NULL, ";
				}
				else
				{
					sSQLString = sSQLString + "'" + sSleeve + "', ";
				}

				if (sDate == "")
				{
					sSQLString = sSQLString + "NULL, ";
				}
				else
				{
					sSQLString = sSQLString + "'" + sDate + "', ";
				}

				if (sChstWaist == "")
				{
					sSQLString = sSQLString + "NULL ";
				}
				else
				{
					sSQLString = sSQLString + "'" + sChstWaist + "' ";
				}

				oCmd.CommandText = sSQLString;
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cUniform = oRec;
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

		public int GetPPEInfoForLaundering(string sEmpID)
		{
			// Get Employee Information for PPE Laundering
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string sDate = "";

			try
			{

				result = -1;

				sDate = DateTime.Now.ToString("M/d/yyyy");

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_PPEUserLaunderSecurityInfo '" + sEmpID + "', '" + sDate + "' ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cUniformEmployee = oRec;
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

		public int GetUniformLaunderInfoByID(int lLaunderID)
		{
			//Retrieve Records from UniformLaunderInfo by specific Record ID
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_UniformLaunderInfoByID " + lLaunderID.ToString() + " ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cUniformLaunderID = Convert.ToInt32(modGlobal.GetVal(oRec["launder_id"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cUniformLaunderUniformID = Convert.ToInt32(modGlobal.GetVal(oRec["uniform_id"]));

					if (modGlobal.Clean(oRec["date_flagged"]) == "")
					{
						cUniformLaunderDateFlagged = "";
					}
					else
					{
						cUniformLaunderDateFlagged = Convert.ToDateTime(oRec["date_flagged"]).ToString("MM/dd/yyyy");
					}
					cUniformLaunderFlaggedBy = modGlobal.Clean(oRec["flagged_by"]);

					if (modGlobal.Clean(oRec["date_approved"]) == "")
					{
						cUniformLaunderDateApproved = "";
					}
					else
					{
						cUniformLaunderDateApproved = Convert.ToDateTime(oRec["date_approved"]).ToString("MM/dd/yyyy");
					}
					cUniformLaunderApprovedBy = modGlobal.Clean(oRec["approved_by"]);
					cUniformLaunderComment = modGlobal.Clean(oRec["comment"]);

					if (modGlobal.Clean(oRec["date_cleaned"]) == "")
					{
						cUniformLaunderDateCleaned = "";
					}
					else
					{
						cUniformLaunderDateCleaned = Convert.ToDateTime(oRec["date_cleaned"]).ToString("MM/dd/yyyy");
					}
					cUniformLaunderCleanedBy = modGlobal.Clean(oRec["cleaned_by"]);
					cUniformLaunderCleaningComments = modGlobal.Clean(oRec["laundry_comment"]);
					cUniformLaunderVendorCleaned = modGlobal.Clean(oRec["vendor_cleaned"]);
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

		public int GetUniformDetailByID(int lUniformID)
		{
			//Retrieve Uniform Detail for display by Uniform ID
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string sSQLString = "";

			try
			{

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				sSQLString = "spSelect_UniformDetailByID " + lUniformID.ToString() + " ";

				oCmd.CommandText = sSQLString;
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cUniform = oRec;
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

		public int GetUniformRepairByID(int lRepairID)
		{
			//Retrieve Records from UniformRepair by specific Record ID
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_UniformRepairByID " + lRepairID.ToString() + " ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{

					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cUniformRepairID = Convert.ToInt32(modGlobal.GetVal(oRec["repair_id"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cUniformRepairUniformID = Convert.ToInt32(modGlobal.GetVal(oRec["uniform_id"]));

					if (modGlobal.Clean(oRec["repairer_id"]) == "")
					{
						cUniformRepairerID = 0;
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						cUniformRepairerID = Convert.ToInt32(modGlobal.GetVal(oRec["repairer_id"]));
					}

					if (modGlobal.Clean(oRec["date_in"]) == "")
					{
						cUniformRepairDateIn = "";
					}
					else
					{
						cUniformRepairDateIn = Convert.ToDateTime(oRec["date_in"]).ToString("MM/dd/yyyy");
					}

					if (modGlobal.Clean(oRec["date_out"]) == "")
					{
						cUniformRepairDateOut = "";
					}
					else
					{
						cUniformRepairDateOut = Convert.ToDateTime(oRec["date_out"]).ToString("MM/dd/yyyy");
					}

					cUniformRepairComment = modGlobal.Clean(oRec["comment"]);

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

		public int GetPPERepairHistoryByItem(int lUniformID)
		{
			// Get UniformRepair List for specific PPE Item
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = " spSelect_UniformRepairHistoryByItem " + lUniformID.ToString() + " ";

				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cUniformRepair = oRec;
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

		public int GetPPELaundryInfoHistoryByItem(int lUniformID)
		{
			// Get UniformLaundryInfo List for specific PPE Item
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_UniformLaundryInfoHistoryByItem " + lUniformID.ToString() + " ";

				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cUniformLaundry = oRec;
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

		public int InsertUniformRepair()
		{
			//Insert Record into UniformRepair table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spInsertUniformRepair " + cUniformRepairUniformID.ToString() + ", ";

				if (cUniformRepairerID == 0)
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + cUniformRepairerID.ToString() + ", ";
				}

				if (cUniformRepairDateIn == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cUniformRepairDateIn + "', ";
				}

				if (cUniformRepairDateOut == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cUniformRepairDateOut + "', ";
				}

				if (cUniformRepairComment == "")
				{
					SqlString = SqlString + "NULL ";
				}
				else
				{
					SqlString = SqlString + "'" + cUniformRepairComment + "' ";
				}

				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				//UPGRADE_WARNING: (2065) ADODB.Recordset method oRec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
				oRec = oRec.NextRecordSet();
				if (!oRec.EOF)
				{
					cUniformRepairID = Convert.ToInt32(oRec[0]);
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

		public int UpdateUniformRepair()
		{
			//Update Record in UniformRepair table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spUpdateUniformRepair " + cUniformRepairID.ToString() + ", " + cUniformRepairUniformID.ToString() + ", ";

				if (cUniformRepairerID == 0)
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + cUniformRepairerID.ToString() + ", ";
				}

				if (cUniformRepairDateIn == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cUniformRepairDateIn + "', ";
				}

				if (cUniformRepairDateOut == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cUniformRepairDateOut + "', ";
				}

				if (cUniformRepairComment == "")
				{
					SqlString = SqlString + "NULL ";
				}
				else
				{
					SqlString = SqlString + "'" + cUniformRepairComment + "' ";
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

		public int InsertUniformLaunderInfo()
		{
			//Insert Record into UniformLaunderInfo table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spInsert_UniformLaunderInfo " + cUniformLaunderUniformID.ToString() + ", '";
				SqlString = SqlString + cUniformLaunderDateFlagged + "', '" + cUniformLaunderFlaggedBy + "', ";

				if (cUniformLaunderDateApproved == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cUniformLaunderDateApproved + "', ";
				}

				if (cUniformLaunderApprovedBy == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cUniformLaunderApprovedBy + "', ";
				}

				if (cUniformLaunderComment == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cUniformLaunderComment + "', ";
				}

				if (cUniformLaunderDateCleaned == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cUniformLaunderDateCleaned + "', ";
				}

				if (cUniformLaunderCleanedBy == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cUniformLaunderCleanedBy + "', ";
				}

				if (cUniformLaunderCleaningComments == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cUniformLaunderCleaningComments + "', ";
				}

				if (cUniformLaunderVendorCleaned == "")
				{
					SqlString = SqlString + "NULL ";
				}
				else
				{
					SqlString = SqlString + "'" + cUniformLaunderVendorCleaned + "' ";
				}


				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				//UPGRADE_WARNING: (2065) ADODB.Recordset method oRec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
				oRec = oRec.NextRecordSet();
				if (!oRec.EOF)
				{
					cUniformLaunderID = Convert.ToInt32(oRec[0]);
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

		public int UpdateUniformLaunderInfo()
		{
			//Update Record in UniformLaunderInfo table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = " spUpdate_UniformLaunderInfo " + cUniformLaunderID.ToString() + ", ";

				if (cUniformLaunderDateApproved == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cUniformLaunderDateApproved + "', ";
				}

				if (cUniformLaunderApprovedBy == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cUniformLaunderApprovedBy + "', ";
				}

				if (cUniformLaunderComment == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cUniformLaunderComment + "', ";
				}

				if (cUniformLaunderDateCleaned == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cUniformLaunderDateCleaned + "', ";
				}

				if (cUniformLaunderCleanedBy == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cUniformLaunderCleanedBy + "', ";
				}


				if (cUniformLaunderCleaningComments == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cUniformLaunderCleaningComments + "', ";
				}

				if (cUniformLaunderVendorCleaned == "")
				{
					SqlString = SqlString + "NULL ";
				}
				else
				{
					SqlString = SqlString + "'" + cUniformLaunderVendorCleaned + "' ";
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

		public int InsertUniformRepairLaunderInfo()
		{
			//Insert Record into PersonnelUniform table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spInsert_UniformRepairLaunderInfo " + cUniformRepairID.ToString() + ", " + cUniformLaunderID.ToString();

				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int GetUniformRepairLaunderInfoByID(int lRepairID)
		{
			//Retrieve Records from UniformLaunderInfo by specific Record ID
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_UniformRepairLaunderInfoByID " + lRepairID.ToString() + " ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cUniformLaunderID = Convert.ToInt32(modGlobal.GetVal(oRec["launder_id"]));
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

		public int GetUniformEmployeePPESizesByID(string sEmpID)
		{
			//Retrieve Records from UniformEmployeePPESizes by specific Employee ID
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_UniformEmployeePPESizesByEmpID '" + sEmpID + "' ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cEmployeeUniformSizeEmployeeID = modGlobal.Clean(oRec["emp_id"]);

					if (modGlobal.Clean(oRec["in_date"]) == "")
					{
						cEmployeeUniformSizeInDate = "";
					}
					else
					{
						cEmployeeUniformSizeInDate = Convert.ToDateTime(oRec["in_date"]).ToString("MM/dd/yyyy");
					}

					if (modGlobal.Clean(oRec["pant_size_desc"]) == "")
					{
						cEmployeeUniformSizePantSizeDesc = "";
					}
					else
					{
						cEmployeeUniformSizePantSizeDesc = modGlobal.Clean(oRec["pant_size_desc"]);
					}

					if (modGlobal.Clean(oRec["pant_size_code"]) == "")
					{
						cEmployeeUniformSizePantSizeCode = 0;
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						cEmployeeUniformSizePantSizeCode = Convert.ToInt32(modGlobal.GetVal(oRec["pant_size_code"]));
					}

					if (modGlobal.Clean(oRec["spread_coat_desc"]) == "")
					{
						cEmployeeUniformSizeCoatSpreadDesc = "";
					}
					else
					{
						cEmployeeUniformSizeCoatSpreadDesc = modGlobal.Clean(oRec["spread_coat_desc"]);
					}

					if (modGlobal.Clean(oRec["coat_size_desc"]) == "")
					{
						cEmployeeUniformSizeCoatSizeDesc = "";
					}
					else
					{
						cEmployeeUniformSizeCoatSizeDesc = modGlobal.Clean(oRec["coat_size_desc"]);
					}

					if (modGlobal.Clean(oRec["coat_size_code"]) == "")
					{
						cEmployeeUniformSizeCoatSizeCode = 0;
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						cEmployeeUniformSizeCoatSizeCode = Convert.ToInt32(modGlobal.GetVal(oRec["coat_size_code"]));
					}

					if (modGlobal.Clean(oRec["boot_mauf_desc"]) == "")
					{
						cEmployeeUniformSizeBootManufDesc = "";
					}
					else
					{
						cEmployeeUniformSizeBootManufDesc = modGlobal.Clean(oRec["boot_mauf_desc"]);
					}

					if (modGlobal.Clean(oRec["boot_manuf_id"]) == "")
					{
						cEmployeeUniformSizeBootManufID = 0;
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						cEmployeeUniformSizeBootManufID = Convert.ToInt32(modGlobal.GetVal(oRec["boot_manuf_id"]));
					}

					if (modGlobal.Clean(oRec["spread_boot_desc"]) == "")
					{
						cEmployeeUniformSizeBootSpreadDesc = "";
					}
					else
					{
						cEmployeeUniformSizeBootSpreadDesc = modGlobal.Clean(oRec["spread_boot_desc"]);
					}

					if (modGlobal.Clean(oRec["boot_size_code"]) == "")
					{
						cEmployeeUniformSizeBootSizeCode = 0;
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						cEmployeeUniformSizeBootSizeCode = Convert.ToInt32(modGlobal.GetVal(oRec["boot_size_code"]));
					}

					if (modGlobal.Clean(oRec["glove_size_desc"]) == "")
					{
						cEmployeeUniformSizeGloveSizeDesc = "";
					}
					else
					{
						cEmployeeUniformSizeGloveSizeDesc = modGlobal.Clean(oRec["glove_size_desc"]);
					}

					if (modGlobal.Clean(oRec["glove_size_code"]) == "")
					{
						cEmployeeUniformSizeGloveSizeCode = 0;
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						cEmployeeUniformSizeGloveSizeCode = Convert.ToInt32(modGlobal.GetVal(oRec["glove_size_code"]));
					}

					if (modGlobal.Clean(oRec["boot_size_desc"]) == "")
					{
						cEmployeeUniformSizeBootSizeDesc = "";
					}
					else
					{
						cEmployeeUniformSizeBootSizeDesc = modGlobal.Clean(oRec["boot_size_desc"]);
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

		public int InsertUniformEmployeePPESizes()
		{
			//Insert Record into UniformEmployeePPESizestable
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spInsert_UniformEmployeePPESizes  '" + cEmployeeUniformSizeEmployeeID + "', ";
				if (cEmployeeUniformSizeInDate == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cEmployeeUniformSizeInDate + "', ";
				}

				if (cEmployeeUniformSizePantSizeDesc == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cEmployeeUniformSizePantSizeDesc + "', ";
				}

				if (cEmployeeUniformSizePantSizeCode == 0)
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + cEmployeeUniformSizePantSizeCode.ToString() + ", ";
				}

				if (cEmployeeUniformSizeCoatSpreadDesc == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cEmployeeUniformSizeCoatSpreadDesc + "', ";
				}

				if (cEmployeeUniformSizeCoatSizeDesc == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cEmployeeUniformSizeCoatSizeDesc + "', ";
				}

				if (cEmployeeUniformSizeCoatSizeCode == 0)
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + cEmployeeUniformSizeCoatSizeCode.ToString() + ", ";
				}

				if (cEmployeeUniformSizeBootManufDesc == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cEmployeeUniformSizeBootManufDesc + "', ";
				}

				if (cEmployeeUniformSizeBootManufID == 0)
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + cEmployeeUniformSizeBootManufID.ToString() + ", ";
				}

				if (cEmployeeUniformSizeBootSpreadDesc == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cEmployeeUniformSizeBootSpreadDesc + "', ";
				}

				if (cEmployeeUniformSizeBootSizeCode == 0)
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + cEmployeeUniformSizeBootSizeCode.ToString() + ", ";
				}

				if (cEmployeeUniformSizeGloveSizeDesc == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cEmployeeUniformSizeGloveSizeDesc + "', ";
				}

				if (cEmployeeUniformSizeGloveSizeCode == 0)
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + cEmployeeUniformSizeGloveSizeCode.ToString() + ", ";
				}

				if (cEmployeeUniformSizeBootSizeDesc == "")
				{
					SqlString = SqlString + "NULL ";
				}
				else
				{
					SqlString = SqlString + "'" + cEmployeeUniformSizeBootSizeDesc + "' ";
				}

				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int UpdateUniformEmployeePPESizes()
		{
			//Update Record from UniformEmployeePPESizestable
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spUpdate_UniformEmployeePPESizes '" + cEmployeeUniformSizeEmployeeID + "', ";
				if (cEmployeeUniformSizeInDate == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cEmployeeUniformSizeInDate + "', ";
				}

				if (cEmployeeUniformSizePantSizeDesc == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cEmployeeUniformSizePantSizeDesc + "', ";
				}

				if (cEmployeeUniformSizePantSizeCode == 0)
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + cEmployeeUniformSizePantSizeCode.ToString() + ", ";
				}

				if (cEmployeeUniformSizeCoatSpreadDesc == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cEmployeeUniformSizeCoatSpreadDesc + "', ";
				}

				if (cEmployeeUniformSizeCoatSizeDesc == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cEmployeeUniformSizeCoatSizeDesc + "', ";
				}

				if (cEmployeeUniformSizeCoatSizeCode == 0)
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + cEmployeeUniformSizeCoatSizeCode.ToString() + ", ";
				}

				if (cEmployeeUniformSizeBootManufDesc == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cEmployeeUniformSizeBootManufDesc + "', ";
				}

				if (cEmployeeUniformSizeBootManufID == 0)
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + cEmployeeUniformSizeBootManufID.ToString() + ", ";
				}

				if (cEmployeeUniformSizeBootSpreadDesc == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cEmployeeUniformSizeBootSpreadDesc + "', ";
				}

				if (cEmployeeUniformSizeBootSizeCode == 0)
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + cEmployeeUniformSizeBootSizeCode.ToString() + ", ";
				}

				if (cEmployeeUniformSizeGloveSizeDesc == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cEmployeeUniformSizeGloveSizeDesc + "', ";
				}

				if (cEmployeeUniformSizeGloveSizeCode == 0)
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + cEmployeeUniformSizeGloveSizeCode.ToString() + ", ";
				}

				if (cEmployeeUniformSizeBootSizeDesc == "")
				{
					SqlString = SqlString + "NULL ";
				}
				else
				{
					SqlString = SqlString + "'" + cEmployeeUniformSizeBootSizeDesc + "' ";
				}

				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int GetPersonnelUniformSizesByEmpItem(string sEmpID, int iType)
		{
			//Retrieve Records from UniformEmployeePPESizes by specific Employee ID
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_PersonnelUniformSizesByEmpType '" + sEmpID + "', " + iType.ToString() + " ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cPersonnelUniformSizesID = Convert.ToInt32(oRec["pers_size_id"]);
					cPersonnelUniformSizesEmployeeID = modGlobal.Clean(oRec["employee_id"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cPersonnelUniformSizesUniformType = Convert.ToInt32(modGlobal.GetVal(oRec["uniform_type"]));
					cPersonnelUniformSizesDateSized = Convert.ToDateTime(oRec["date_sized"]).ToString("MM/dd/yyyy");
					cPersonnelUniformSizesSizeDescription = modGlobal.Clean(oRec["size_description"]);
					cPersonnelUniformSizesCreatedDate = Convert.ToDateTime(oRec["created_date"]).ToString("M/d/yyyy HH:mm:ss");
					cPersonnelUniformSizesCreatedBy = modGlobal.Clean(oRec["created_by"]);
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

		public int GetPersonnelUniformSizesByID(float lRecordID)
		{
			//Retrieve Records from UniformEmployeePPESizes by specific Employee ID
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_PersonnelUniformSizesByID " + lRecordID.ToString() + " ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cPersonnelUniformSizesID = Convert.ToInt32(oRec["pers_size_id"]);
					cPersonnelUniformSizesEmployeeID = modGlobal.Clean(oRec["employee_id"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cPersonnelUniformSizesUniformType = Convert.ToInt32(modGlobal.GetVal(oRec["uniform_type"]));
					cPersonnelUniformSizesDateSized = Convert.ToDateTime(oRec["date_sized"]).ToString("MM/dd/yyyy");
					cPersonnelUniformSizesSizeDescription = modGlobal.Clean(oRec["size_description"]);
					cPersonnelUniformSizesCreatedDate = Convert.ToDateTime(oRec["created_date"]).ToString("M/d/yyyy HH:mm:ss");
					cPersonnelUniformSizesCreatedBy = modGlobal.Clean(oRec["created_by"]);
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

		public int InsertPersonnelUniformSizes()
		{
			//Insert Record into PersonnelUniformSizes
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = " spInsert_PersonnelUniformSizes '" + cPersonnelUniformSizesEmployeeID + "', ";
				SqlString = SqlString + cPersonnelUniformSizesUniformType.ToString() + ", ";
				SqlString = SqlString + "'" + cPersonnelUniformSizesDateSized + "', ";
				SqlString = SqlString + "'" + cPersonnelUniformSizesSizeDescription + "', ";
				SqlString = SqlString + "'" + cPersonnelUniformSizesCreatedDate + "', ";
				SqlString = SqlString + "'" + cPersonnelUniformSizesCreatedBy + "' ";

				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				//UPGRADE_WARNING: (2065) ADODB.Recordset method oRec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
				oRec = oRec.NextRecordSet();
				if (!oRec.EOF)
				{
					cPersonnelUniformSizesID = Convert.ToInt32(oRec[0]);
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

		public int UpdatePersonnelUniformSizes()
		{
			//Update PersonnelUniformSizesRecord
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spUpdate_PersonnelUniformSizes " + cPersonnelUniformSizesID.ToString() + ", ";
				SqlString = SqlString + "'" + cPersonnelUniformSizesEmployeeID + "', ";
				SqlString = SqlString + cPersonnelUniformSizesUniformType.ToString() + ", ";
				SqlString = SqlString + "'" + cPersonnelUniformSizesDateSized + "', ";
				SqlString = SqlString + "'" + cPersonnelUniformSizesSizeDescription + "', ";
				SqlString = SqlString + "'" + cPersonnelUniformSizesCreatedDate + "', ";
				SqlString = SqlString + "'" + cPersonnelUniformSizesCreatedBy + "' ";

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

		public int GetTurnOutForLaundering(string sEmpID)
		{
			// Get Employee TurnOut Information For Laundering
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_UniformTurnOutLaunderInfo '" + sEmpID + "' ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cUniformEmployee = oRec;
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

		public int GetTurnOutLastLaunderedInfo(string sEmpID)
		{
			// Get Employee TurnOut Last Launder Info
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_UniformTurnOutLastLaundered '" + sEmpID + "' ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cUniformEmployee = oRec;
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

		public int GetLastUniformInspectionForItem(int lUniformID)
		{
			//Retrieve Last UniformInspection.inspection for specific item
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string sSQLString = "";

			try
			{


				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				sSQLString = "spSelect_LastUniformInspection " + lUniformID.ToString() + " ";

				oCmd.CommandText = sSQLString;
				oRec = ADORecordSetHelper.Open(oCmd, "");


				if (!oRec.EOF)
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cUniformInspectID = Convert.ToInt32(modGlobal.GetVal(oRec["inspection_id"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cUniformInspectUniformID = Convert.ToInt32(modGlobal.GetVal(oRec["uniform_id"]));
					cUniformInspectDate = Convert.ToDateTime(oRec["inspection_date"]).ToString("MM/dd/yyyy");
					cUniformInspectedBy = modGlobal.Clean(oRec["inspected_by"]);
					//UPGRADE_WARNING: (1068) GetVal(oRec(passed_flag)) of type Variant is being forced to bool. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					if (Convert.ToBoolean(modGlobal.GetVal(oRec["passed_flag"])))
					{
						cUniformInspectPassedFlag = 1;
					}
					else
					{
						cUniformInspectPassedFlag = 0;
					}
					cUniformComment = modGlobal.Clean(oRec["comment"]);

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

		public int GetUniformInspectByID(int lInspectID)
		{
			//Retrieve UniformInspection record for specific ID
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string sSQLString = "";

			try
			{


				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				sSQLString = "spSelect_UniformInspectionByID " + lInspectID.ToString() + " ";

				oCmd.CommandText = sSQLString;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cUniformInspectID = Convert.ToInt32(modGlobal.GetVal(oRec["inspection_id"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cUniformInspectUniformID = Convert.ToInt32(modGlobal.GetVal(oRec["uniform_id"]));
					cUniformInspectDate = Convert.ToDateTime(oRec["inspection_date"]).ToString("MM/dd/yyyy");
					cUniformInspectedBy = modGlobal.Clean(oRec["inspected_by"]);
					//UPGRADE_WARNING: (1068) GetVal(oRec(passed_flag)) of type Variant is being forced to bool. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					if (Convert.ToBoolean(modGlobal.GetVal(oRec["passed_flag"])))
					{
						cUniformInspectPassedFlag = 1;
					}
					else
					{
						cUniformInspectPassedFlag = 0;
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

		public int GetUniformCommentForInspectionByID(int lInspectID)
		{
			//Retrieve UniformCommentForInspection record for specific ID
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string sSQLString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				sSQLString = "spSelect_UniformCommentForInspectionByID " + lInspectID.ToString() + " ";

				oCmd.CommandText = sSQLString;
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{

					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cUniformCommentInspID = Convert.ToInt32(modGlobal.GetVal(oRec["inspection_id"]));
					cUniformComment = modGlobal.Clean(oRec["comment"]);
					cUniformCommentCreatedBy = modGlobal.Clean(oRec["created_by"]);
					cUniformCommentCreatedDate = Convert.ToDateTime(oRec["created_date"]).ToString("MM/dd/yyyy HH:mm:ss");
					cUniformCommentUpdatedBy = modGlobal.Clean(oRec["updated_by"]);
					cUniformCommentUpdatedDate = Convert.ToDateTime(oRec["updated_date"]).ToString("MM/dd/yyyy HH:mm:ss");

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

		public bool AddUniformCommentForInspection()
		{
			//Add UniformCommentForInspection record
			bool result = false;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{
				result = true;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spInsert_UniformCommentForInspection " + cUniformCommentInspID.ToString();
				SqlString = SqlString + ", '" + cUniformComment + "', '";
				SqlString = SqlString + cUniformCommentCreatedBy + "', '";
				SqlString = SqlString + cUniformCommentCreatedDate + "' ";

				oCmd.CommandText = SqlString;
				oCmd.ExecuteNonQuery();
			}
			catch
			{

				result = false;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public bool UpdateUniformCommentForInspection()
		{
			//Update UniformCommentForInspection record
			bool result = false;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{
				result = true;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spUpdate_UniformCommentForInspection " + cUniformCommentInspID.ToString();
				SqlString = SqlString + ", '" + cUniformComment + "', '";
				SqlString = SqlString + cUniformCommentUpdatedBy + "', '";
				SqlString = SqlString + cUniformCommentUpdatedDate + "' ";

				oCmd.CommandText = SqlString;
				oCmd.ExecuteNonQuery();
			}
			catch
			{

				result = false;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public int DeleteUniformCommentForInspection()
		{
			//Delete Record from UniformCommentForInspection table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spDelete_UniformCommentForInspectionByID " + cUniformCommentInspID.ToString() + " ";

				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");
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