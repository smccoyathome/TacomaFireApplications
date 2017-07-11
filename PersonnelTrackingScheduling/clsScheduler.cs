using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public class clsScheduler
		: UpgradeHelpers.Interfaces.IDependentModel, UpgradeHelpers.Interfaces.ICreatesObjects, UpgradeHelpers
		.Interfaces.IInteractsWithView, UpgradeHelpers.Interfaces.IInitializableCommon, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(clsScheduler));
		}

		void UpgradeHelpers.Interfaces.IInitializableCommon.Common()
		{
			_cPersonnelRecord = null;
			_cAssignmentRecord = null;
			_cLeaveRecord = null;
			_cScheduleRecord = null;
			_cTransferPosition = null;
			cTransferPositionPositionID = 0;
			cTransferPositionAssignmentID = 0;
			cTransferPositionDateOpen = "";
			cTransferPositionDateClosed = "";
			cTransferPositionActiveFlag = "";
			cTransferPositionDateCreated = "";
			cTransferPositionCreatedBy = "";
			cTransferPositionStatusChanged = "";
			cTransferPositionChangedBy = "";
			cTransferPositionParamedicOnly = "";
			_cTransferPriorityCode = null;
			cTransferPriorityCodePriorityCode = 0;
			cTransferPriorityCodeDescription = "";
			cTransferPriorityCodeValue = 0;
			_cTransferRequest = null;
			cTransferRequestID = 0;
			cTransferRequestEmployeeID = "";
			cTransferRequestPositionID = 0;
			cTransferRequestPriorityCode = 0;
			cTransferRequestCreatedDate = "";
			cTransferRequestCreatedBy = "";
			cTransferRequestComment = "";
			_cLeaveReturn = null;
			cLeaveReturnID = 0;
			cLeaveReturnEmployeeID = "";
			cLeaveReturnDate = "";
			cLeaveReturnCreatedBy = "";
			cLeaveReturnCreatedDate = "";
			cLeaveReturnComments = "";
			_cLeaveReportUpdate = null;
			cLeaveReportUpdateID = 0;
			cLeaveReportUpdateDate = "";
			cLeaveReportUpdateUpdatedBy = "";
			cLeaveReportUpdateUpdatedDate = "";
			_cPersonnelCallBackNumber = null;
			cCallBackID = 0;
			cCallBackEmployeeID = "";
			cCallBackNumberFormatted = "";
			cCallBackShift = "";
			cCallBackNumber = 0;
			cCallBackDebitGroup = "";
			cCallBackSpecEventFlag = "";
			cCallBackMedicFlag = "";
			_cBattalionLineUpComplete = null;
			cBattLineupID = 0;
			cBattLineupBattCode = "";
			cBattLineupDate = "";
			cBattLineupUpdatedBy = "";
			cBattLineupUpdatedDate = "";
			_cWatchDutyAssignment = null;
			cWatchDutyAssignDutyID = 0;
			cWatchDutyAssignEmpID = "";
			cWatchDutyAssignDutyDate = "";
			cWatchDutyAssignedBy = "";
			cWatchDutyAssignedDate = "";
			_cEmployeeAvailableToWork = null;
			cEmpAvailToWorkID = 0;
			cEmpAvailToWorkEmpID = "";
			cEmpAvailToWorkShiftDate = "";
			cEmpAvailToWorkCreatedBy = "";
			cEmpAvailToWorkCreatedOn = "";
			cEmpAvailToWorkComment = "";
		}

		//*******************************************************
		//**    PTS Scheduler Class                            **
		//**    Properties & Methods                           **
		//*******************************************************


		//*************************************************
		//**             Private Class Variables         **
		//*************************************************

		//Personnel
		public virtual ADORecordSetHelper _cPersonnelRecord { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cPersonnelRecord
		{
			get
			{
				if (_cPersonnelRecord == null)
				{
					_cPersonnelRecord = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cPersonnelRecord;
			}
			set
			{
				_cPersonnelRecord = value;
			}
		}


		//Assignment
		public virtual ADORecordSetHelper _cAssignmentRecord { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cAssignmentRecord
		{
			get
			{
				if (_cAssignmentRecord == null)
				{
					_cAssignmentRecord = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cAssignmentRecord;
			}
			set
			{
				_cAssignmentRecord = value;
			}
		}


		//Leave
		public virtual ADORecordSetHelper _cLeaveRecord { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cLeaveRecord
		{
			get
			{
				if (_cLeaveRecord == null)
				{
					_cLeaveRecord = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cLeaveRecord;
			}
			set
			{
				_cLeaveRecord = value;
			}
		}


		//Schedule
		public virtual ADORecordSetHelper _cScheduleRecord { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cScheduleRecord
		{
			get
			{
				if (_cScheduleRecord == null)
				{
					_cScheduleRecord = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cScheduleRecord;
			}
			set
			{
				_cScheduleRecord = value;
			}
		}


		//TransferPosition
		public virtual ADORecordSetHelper _cTransferPosition { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cTransferPosition
		{
			get
			{
				if (_cTransferPosition == null)
				{
					_cTransferPosition = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cTransferPosition;
			}
			set
			{
				_cTransferPosition = value;
			}
		}

		public virtual int cTransferPositionPositionID { get; set; }

		public virtual int cTransferPositionAssignmentID { get; set; }

		public virtual string cTransferPositionDateOpen { get; set; }

		public virtual string cTransferPositionDateClosed { get; set; }

		public virtual string cTransferPositionActiveFlag { get; set; }

		public virtual string cTransferPositionDateCreated { get; set; }

		public virtual string cTransferPositionCreatedBy { get; set; }

		public virtual string cTransferPositionStatusChanged { get; set; }

		public virtual string cTransferPositionChangedBy { get; set; }

		public virtual string cTransferPositionParamedicOnly { get; set; }

		//TransferPriorityCode
		public virtual ADORecordSetHelper _cTransferPriorityCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cTransferPriorityCode
		{
			get
			{
				if (_cTransferPriorityCode == null)
				{
					_cTransferPriorityCode = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cTransferPriorityCode;
			}
			set
			{
				_cTransferPriorityCode = value;
			}
		}

		public virtual int cTransferPriorityCodePriorityCode { get; set; }

		public virtual string cTransferPriorityCodeDescription { get; set; }

		public virtual int cTransferPriorityCodeValue { get; set; }

		//TransferRequest
		public virtual ADORecordSetHelper _cTransferRequest { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cTransferRequest
		{
			get
			{
				if (_cTransferRequest == null)
				{
					_cTransferRequest = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cTransferRequest;
			}
			set
			{
				_cTransferRequest = value;
			}
		}

		public virtual int cTransferRequestID { get; set; }

		public virtual string cTransferRequestEmployeeID { get; set; }

		public virtual int cTransferRequestPositionID { get; set; }

		public virtual int cTransferRequestPriorityCode { get; set; }

		public virtual string cTransferRequestCreatedDate { get; set; }

		public virtual string cTransferRequestCreatedBy { get; set; }

		public virtual string cTransferRequestComment { get; set; }

		//LeaveReturn
		public virtual ADORecordSetHelper _cLeaveReturn { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cLeaveReturn
		{
			get
			{
				if (_cLeaveReturn == null)
				{
					_cLeaveReturn = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cLeaveReturn;
			}
			set
			{
				_cLeaveReturn = value;
			}
		}

		public virtual int cLeaveReturnID { get; set; }

		public virtual string cLeaveReturnEmployeeID { get; set; }

		public virtual string cLeaveReturnDate { get; set; }

		public virtual string cLeaveReturnCreatedBy { get; set; }

		public virtual string cLeaveReturnCreatedDate { get; set; }

		public virtual string cLeaveReturnComments { get; set; }

		//LeaveReportUpdate
		public virtual ADORecordSetHelper _cLeaveReportUpdate { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cLeaveReportUpdate
		{
			get
			{
				if (_cLeaveReportUpdate == null)
				{
					_cLeaveReportUpdate = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cLeaveReportUpdate;
			}
			set
			{
				_cLeaveReportUpdate = value;
			}
		}

		public virtual int cLeaveReportUpdateID { get; set; }

		public virtual string cLeaveReportUpdateDate { get; set; }

		public virtual string cLeaveReportUpdateUpdatedBy { get; set; }

		public virtual string cLeaveReportUpdateUpdatedDate { get; set; }

		//PersonnelCallBackNumber
		public virtual ADORecordSetHelper _cPersonnelCallBackNumber { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cPersonnelCallBackNumber
		{
			get
			{
				if (_cPersonnelCallBackNumber == null)
				{
					_cPersonnelCallBackNumber = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cPersonnelCallBackNumber;
			}
			set
			{
				_cPersonnelCallBackNumber = value;
			}
		}

		public virtual int cCallBackID { get; set; }

		public virtual string cCallBackEmployeeID { get; set; }

		public virtual string cCallBackNumberFormatted { get; set; }

		public virtual string cCallBackShift { get; set; }

		public virtual int cCallBackNumber { get; set; }

		public virtual string cCallBackDebitGroup { get; set; }

		public virtual string cCallBackSpecEventFlag { get; set; }

		public virtual string cCallBackMedicFlag { get; set; }

		//BattalionLineUpComplete
		public virtual ADORecordSetHelper _cBattalionLineUpComplete { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cBattalionLineUpComplete
		{
			get
			{
				if (_cBattalionLineUpComplete == null)
				{
					_cBattalionLineUpComplete = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cBattalionLineUpComplete;
			}
			set
			{
				_cBattalionLineUpComplete = value;
			}
		}

		public virtual int cBattLineupID { get; set; }

		public virtual string cBattLineupBattCode { get; set; }

		public virtual string cBattLineupDate { get; set; }

		public virtual string cBattLineupUpdatedBy { get; set; }

		public virtual string cBattLineupUpdatedDate { get; set; }

		//PersonnelWatchDutyAssignment
		public virtual ADORecordSetHelper _cWatchDutyAssignment { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cWatchDutyAssignment
		{
			get
			{
				if (_cWatchDutyAssignment == null)
				{
					_cWatchDutyAssignment = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cWatchDutyAssignment;
			}
			set
			{
				_cWatchDutyAssignment = value;
			}
		}

		public virtual int cWatchDutyAssignDutyID { get; set; }

		public virtual string cWatchDutyAssignEmpID { get; set; }

		public virtual string cWatchDutyAssignDutyDate { get; set; }

		public virtual string cWatchDutyAssignedBy { get; set; }

		public virtual string cWatchDutyAssignedDate { get; set; }

		//EmployeeAvailableToWork
		public virtual ADORecordSetHelper _cEmployeeAvailableToWork { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cEmployeeAvailableToWork
		{
			get
			{
				if (_cEmployeeAvailableToWork == null)
				{
					_cEmployeeAvailableToWork = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cEmployeeAvailableToWork;
			}
			set
			{
				_cEmployeeAvailableToWork = value;
			}
		}

		public virtual int cEmpAvailToWorkID { get; set; }

		public virtual string cEmpAvailToWorkEmpID { get; set; }

		public virtual string cEmpAvailToWorkShiftDate { get; set; }

		public virtual string cEmpAvailToWorkCreatedBy { get; set; }

		public virtual string cEmpAvailToWorkCreatedOn { get; set; }

		public virtual string cEmpAvailToWorkComment { get; set; }

		//**********************************************
		//**         Public Class Methods             **
		//**********************************************
		//Personnel
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper PersonnelRecord
		{
			get
			{
				return cPersonnelRecord;
			}
			set
			{
				cPersonnelRecord = value;
			}
		}


		//Assignment
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper AssignmentRecord
		{
			get
			{
				return cAssignmentRecord;
			}
			set
			{
				cAssignmentRecord = value;
			}
		}


		//Leave
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper LeaveRecord
		{
			get
			{
				return cLeaveRecord;
			}
			set
			{
				cLeaveRecord = value;
			}
		}


		//Schedule
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper ScheduleRecord
		{
			get
			{
				return cScheduleRecord;
			}
			set
			{
				cScheduleRecord = value;
			}
		}


		//TransferPosition
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper TransferPosition
		{
			get
			{
				return cTransferPosition;
			}
			set
			{
				cTransferPosition = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int TransferPositionPositionID
		{
			get
			{
				return cTransferPositionPositionID;
			}
			set
			{
				cTransferPositionPositionID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string TransferPositionAssignmentID
		{
			get
			{
				return cTransferPositionAssignmentID.ToString();
			}
			set
			{
				cTransferPositionAssignmentID = Convert.ToInt32(Double.Parse(value));
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string TransferPositionDateOpen
		{
			get
			{
				return cTransferPositionDateOpen;
			}
			set
			{
				cTransferPositionDateOpen = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string TransferPositionDateClosed
		{
			get
			{
				return cTransferPositionDateClosed;
			}
			set
			{
				cTransferPositionDateClosed = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string TransferPositionActiveFlag
		{
			get
			{
				return cTransferPositionActiveFlag;
			}
			set
			{
				cTransferPositionActiveFlag = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string TransferPositionDateCreated
		{
			get
			{
				return cTransferPositionDateCreated;
			}
			set
			{
				cTransferPositionDateCreated = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string TransferPositionCreatedBy
		{
			get
			{
				return cTransferPositionCreatedBy;
			}
			set
			{
				cTransferPositionCreatedBy = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string TransferPositionStatusChanged
		{
			get
			{
				return cTransferPositionStatusChanged;
			}
			set
			{
				cTransferPositionStatusChanged = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string TransferPositionChangedBy
		{
			get
			{
				return cTransferPositionChangedBy;
			}
			set
			{
				cTransferPositionChangedBy = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string TransferPositionParamedicOnly
		{
			get
			{
				return cTransferPositionParamedicOnly;
			}
			set
			{
				cTransferPositionParamedicOnly = value;
			}
		}


		//TransferPriorityCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper TransferPriorityCode
		{
			get
			{
				return cTransferPriorityCode;
			}
			set
			{
				cTransferPriorityCode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int TransferPriorityCodePriorityCode
		{
			get
			{
				return cTransferPriorityCodePriorityCode;
			}
			set
			{
				cTransferPriorityCodePriorityCode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string TransferPriorityCodeDescription
		{
			get
			{
				return cTransferPriorityCodeDescription;
			}
			set
			{
				cTransferPriorityCodeDescription = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int TransferPriorityCodeValue
		{
			get
			{
				return cTransferPriorityCodeValue;
			}
			set
			{
				cTransferPriorityCodeValue = value;
			}
		}


		//TransferRequest
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper TransferRequest
		{
			get
			{
				return cTransferRequest;
			}
			set
			{
				cTransferRequest = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int TransferRequestID
		{
			get
			{
				return cTransferRequestID;
			}
			set
			{
				cTransferRequestID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string TransferRequestEmployeeID
		{
			get
			{
				return cTransferRequestEmployeeID;
			}
			set
			{
				cTransferRequestEmployeeID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int TransferRequestPositionID
		{
			get
			{
				return cTransferRequestPositionID;
			}
			set
			{
				cTransferRequestPositionID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int TransferRequestPriorityCode
		{
			get
			{
				return cTransferRequestPriorityCode;
			}
			set
			{
				cTransferRequestPriorityCode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string TransferRequestCreatedDate
		{
			get
			{
				return cTransferRequestCreatedDate;
			}
			set
			{
				cTransferRequestCreatedDate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string TransferRequestCreatedBy
		{
			get
			{
				return cTransferRequestCreatedBy;
			}
			set
			{
				cTransferRequestCreatedBy = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string TransferRequestComment
		{
			get
			{
				return cTransferRequestComment;
			}
			set
			{
				cTransferRequestComment = value;
			}
		}


		//LeaveReturn
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper LeaveReturn
		{
			get
			{
				return cLeaveReturn;
			}
			set
			{
				cLeaveReturn = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int LeaveReturnID
		{
			get
			{
				return cLeaveReturnID;
			}
			set
			{
				cLeaveReturnID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string LeaveReturnEmployeeID
		{
			get
			{
				return cLeaveReturnEmployeeID;
			}
			set
			{
				cLeaveReturnEmployeeID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string LeaveReturnDate
		{
			get
			{
				return cLeaveReturnDate;
			}
			set
			{
				cLeaveReturnDate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string LeaveReturnCreatedBy
		{
			get
			{
				return cLeaveReturnCreatedBy;
			}
			set
			{
				cLeaveReturnCreatedBy = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string LeaveReturnCreatedDate
		{
			get
			{
				return cLeaveReturnCreatedDate;
			}
			set
			{
				cLeaveReturnCreatedDate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string LeaveReturnComments
		{
			get
			{
				return cLeaveReturnComments;
			}
			set
			{
				cLeaveReturnComments = value;
			}
		}


		//LeaveReportUpdate
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper LeaveReportUpdate
		{
			get
			{
				return cLeaveReportUpdate;
			}
			set
			{
				cLeaveReportUpdate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int LeaveReportUpdateID
		{
			get
			{
				return cLeaveReportUpdateID;
			}
			set
			{
				cLeaveReportUpdateID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string LeaveReportUpdateDate
		{
			get
			{
				return cLeaveReportUpdateDate;
			}
			set
			{
				cLeaveReportUpdateDate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string LeaveReportUpdateUpdatedBy
		{
			get
			{
				return cLeaveReportUpdateUpdatedBy;
			}
			set
			{
				cLeaveReportUpdateUpdatedBy = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string LeaveReportUpdateUpdatedDate
		{
			get
			{
				return cLeaveReportUpdateUpdatedDate;
			}
			set
			{
				cLeaveReportUpdateUpdatedDate = value;
			}
		}


		//PersonnelCallBackNumber
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper PersonnelCallBackNumber
		{
			get
			{
				return cPersonnelCallBackNumber;
			}
			set
			{
				cPersonnelCallBackNumber = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int CallBackID
		{
			get
			{
				return cCallBackID;
			}
			set
			{
				cCallBackID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string CallBackEmployeeID
		{
			get
			{
				return cCallBackEmployeeID;
			}
			set
			{
				cCallBackEmployeeID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string CallBackNumberFormatted
		{
			get
			{
				return cCallBackNumberFormatted;
			}
			set
			{
				cCallBackNumberFormatted = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string CallBackShift
		{
			get
			{
				return cCallBackShift;
			}
			set
			{
				cCallBackShift = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int CallBackNumber
		{
			get
			{
				return cCallBackNumber;
			}
			set
			{
				cCallBackNumber = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string CallBackDebitGroup
		{
			get
			{
				return cCallBackDebitGroup;
			}
			set
			{
				cCallBackDebitGroup = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string CallBackSpecEventFlag
		{
			get
			{
				return cCallBackSpecEventFlag;
			}
			set
			{
				cCallBackSpecEventFlag = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string CallBackMedicFlag
		{
			get
			{
				return cCallBackMedicFlag;
			}
			set
			{
				cCallBackMedicFlag = value;
			}
		}


		//BattalionLineUpComplete
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper BattalionLineUpComplete
		{
			get
			{
				return cBattalionLineUpComplete;
			}
			set
			{
				cBattalionLineUpComplete = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int BattLineupID
		{
			get
			{
				return cBattLineupID;
			}
			set
			{
				cBattLineupID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string BattLineupBattCode
		{
			get
			{
				return cBattLineupBattCode;
			}
			set
			{
				cBattLineupBattCode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string BattLineupDate
		{
			get
			{
				return cBattLineupDate;
			}
			set
			{
				cBattLineupDate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string BattLineupUpdatedBy
		{
			get
			{
				return cBattLineupUpdatedBy;
			}
			set
			{
				cBattLineupUpdatedBy = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string BattLineupUpdatedDate
		{
			get
			{
				return cBattLineupUpdatedDate;
			}
			set
			{
				cBattLineupUpdatedDate = value;
			}
		}


		//PersonnelWatchDutyAssignment
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper WatchDutyAssignment
		{
			get
			{
				return cWatchDutyAssignment;
			}
			set
			{
				cWatchDutyAssignment = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int WatchDutyAssignDutyID
		{
			get
			{
				return cWatchDutyAssignDutyID;
			}
			set
			{
				cWatchDutyAssignDutyID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string WatchDutyAssignEmpID
		{
			get
			{
				return cWatchDutyAssignEmpID;
			}
			set
			{
				cWatchDutyAssignEmpID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string WatchDutyAssignDutyDate
		{
			get
			{
				return cWatchDutyAssignDutyDate;
			}
			set
			{
				cWatchDutyAssignDutyDate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string WatchDutyAssignedBy
		{
			get
			{
				return cWatchDutyAssignedBy;
			}
			set
			{
				cWatchDutyAssignedBy = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string WatchDutyAssignedDate
		{
			get
			{
				return cWatchDutyAssignedDate;
			}
			set
			{
				cWatchDutyAssignedDate = value;
			}
		}


		//EmployeeAvailableToWork
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper EmployeeAvailableToWork
		{
			get
			{
				return cEmployeeAvailableToWork;
			}
			set
			{
				cEmployeeAvailableToWork = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int EmpAvailToWorkID
		{
			get
			{
				return cEmpAvailToWorkID;
			}
			set
			{
				cEmpAvailToWorkID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string EmpAvailToWorkEmpID
		{
			get
			{
				return cEmpAvailToWorkEmpID;
			}
			set
			{
				cEmpAvailToWorkEmpID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string EmpAvailToWorkShiftDate
		{
			get
			{
				return cEmpAvailToWorkShiftDate;
			}
			set
			{
				cEmpAvailToWorkShiftDate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string EmpAvailToWorkCreatedBy
		{
			get
			{
				return cEmpAvailToWorkCreatedBy;
			}
			set
			{
				cEmpAvailToWorkCreatedBy = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string EmpAvailToWorkCreatedOn
		{
			get
			{
				return cEmpAvailToWorkCreatedOn;
			}
			set
			{
				cEmpAvailToWorkCreatedOn = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string EmpAvailToWorkComment
		{
			get
			{
				return cEmpAvailToWorkComment;
			}
			set
			{
				cEmpAvailToWorkComment = value;
			}
		}


		//*********************************************
		//**     Public Class Functions/Subroutines  **
		//*********************************************

		public int CheckForDateShiftAvailable(string sEmployeeID, string dLeaveDateTime)
		{
			//Retrieve Records from PayrollTransfer table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string sGroupType = "";
			int iMaxAllowed = 0;
			string sDate = "";

			try
			{

				//default to FALSE
				result = 0;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;

				//Step 1 - Check to see if the Date/Shift is already available
				oCmd.CommandText = "spSelect_VacationAvailableByShiftDate '" + dLeaveDateTime + "' ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					return result;
				}

				//Step 2 - Check Employee's Group Code... If REG, the continue
				oCmd.CommandText = "spSelect_PersonnelAssignmentGroupCode '" + sEmployeeID + "' ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					sGroupType = modGlobal.Clean(oRec["group_code"]);
					if (sGroupType != "REG")
					{
						return result;
					}
				}
				else
				{
					return result;
				}

				//Step 3 - Determine the Maximum Allowed for Leave
				System
					.DateTime TempDate = DateTime.FromOADate(0);
				sDate = (DateTime.TryParse(dLeaveDateTime, out TempDate)) ? TempDate.ToString("M/d/yyyy") : dLeaveDateTime;
				oCmd.CommandText = "spSelect_MaxLeaveAllowed '" + sDate + "' ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					iMaxAllowed = Convert.ToInt32(modGlobal.GetVal(oRec["max_leave_allowed"]));
				}
				else
				{
					iMaxAllowed = 9;
				}

				//Step 4 - Determine if Date/Shift can be made Available (yellow on Vacation Scheduler)
				oCmd.CommandText = "sp_GetLeaveCounts '" + sGroupType + "', '" + dLeaveDateTime + "' ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					//UPGRADE_WARNING: (1068) GetVal(oRec(total_leave)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					if ((Convert.ToDouble(modGlobal.GetVal(oRec["total_leave"])) + 1) <= iMaxAllowed)
					{
						//continue
					}
					else
					{
						return 0;
					}
				}

				//Step 4 - Determine if Anyone has a Vacation Requeste this Date/Shift
				oCmd.CommandText = "spSelect_PendingVacationRequestForShiftDate '" + dLeaveDateTime + "' ";
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
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

		public int GetTransferPositionList()
		{
			//Get List of Transfer Positions for grid display
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;
				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_TransferPositionList ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTransferPosition = oRec;
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

		public int GetTransferRequestList()
		{
			//Get List of Transfer Requests for grid display
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;
				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_TransferRequestList ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTransferRequest = oRec;
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

		public int GetTransferRequestByID(int lRequestID)
		{
			//Retrieve Record from TransferRequest by specific Record ID
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_TransferRequest " + lRequestID.ToString() + " ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTransferRequestID = Convert.ToInt32(oRec["request_id"]);
					cTransferRequestEmployeeID = modGlobal.Clean(oRec["employee_id"]);
					cTransferRequestPositionID = Convert.ToInt32(oRec["position_id"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cTransferRequestPriorityCode = Convert.ToInt32(modGlobal.GetVal(oRec["priority_code"]));
					cTransferRequestCreatedDate = Convert.ToDateTime(oRec["created_date"]).ToString("MM/dd/yyyy HH:mm:ss");
					cTransferRequestCreatedBy = modGlobal.Clean(oRec["created_by"]);
					cTransferRequestComment = modGlobal.Clean(oRec["comment"]);
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

		public int GetTransferPositionByID(int lPositionID)
		{
			//Retrieve Record from TransferPosition by specific Record ID
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_TransferPosition " + lPositionID.ToString() + " ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTransferPositionPositionID = Convert.ToInt32(oRec["position_id"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cTransferPositionAssignmentID = Convert.ToInt32(modGlobal.GetVal(oRec["assignment_id"]));
					cTransferPositionDateOpen = Convert.ToDateTime(oRec["date_open"]).ToString("MM/dd/yyyy");

					if (modGlobal.Clean(oRec["date_closed"]) == "")
					{
						cTransferPositionDateClosed = "";
					}
					else
					{
						cTransferPositionDateClosed = Convert.ToDateTime(oRec["date_closed"]).ToString("MM/dd/yyyy");
					}

					cTransferPositionActiveFlag = modGlobal.Clean(oRec["active_flag"]);
					cTransferPositionDateCreated = Convert.ToDateTime(oRec["created_date"]).ToString("MM/dd/yyyy HH:mm:ss");
					cTransferPositionCreatedBy = modGlobal.Clean(oRec["created_by"]);

					if (modGlobal.Clean(oRec["status_changed"]) == "")
					{
						cTransferPositionStatusChanged = "";
					}
					else
					{
						cTransferPositionStatusChanged = Convert.ToDateTime(oRec["status_changed"]).ToString("MM/dd/yyyy HH:mm:ss");
					}

					if (modGlobal.Clean(oRec["changed_by"]) == "")
					{
						cTransferPositionChangedBy = "";
					}
					else
					{
						cTransferPositionChangedBy = modGlobal.Clean(oRec["changed_by"]);
					}

					cTransferPositionParamedicOnly = modGlobal.Clean(oRec["paramedic_only"]);

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

		public int GetTransferPriorityCodeList()
		{
			//Get List of TransferPriorityCodes for dropdown list
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_TransferPriorityCodes ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTransferPriorityCode = oRec;
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

		public int GetTransferPriorityCodeByID(int iCode)
		{
			//Retrieve Record from TransferPriorityCode by specific Record ID
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_TransferPriorityCodeByID " + iCode.ToString() + " ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cTransferPriorityCodePriorityCode = Convert.ToInt32(modGlobal.GetVal(oRec["priority_code"]));
					cTransferPriorityCodeDescription = modGlobal.Clean(oRec["description"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cTransferPriorityCodeValue = Convert.ToInt32(modGlobal.GetVal(oRec["priority_value"]));
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

		public bool InsertTransferRequest()
		{
			//Add new record to TransferRequest table
			bool result = false;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{
				result = true;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spInsert_TransferRequest '" + cTransferRequestEmployeeID + "', ";
				SqlString = SqlString + cTransferRequestPositionID.ToString() + ", ";
				SqlString = SqlString + cTransferRequestPriorityCode.ToString() + ", ";
				SqlString = SqlString + "'" + cTransferRequestCreatedDate + "', ";
				SqlString = SqlString + "'" + cTransferRequestCreatedBy + "', ";

				if (cTransferRequestComment == "")
				{
					SqlString = SqlString + "NULL ";
				}
				else
				{
					SqlString = SqlString + "'" + cTransferRequestComment + "'";
				}

				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				//UPGRADE_WARNING: (2065) ADODB.Recordset method oRec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
				oRec = oRec.NextRecordSet();
				if (!oRec.EOF)
				{
					cTransferRequestID = Convert.ToInt32(oRec[0]);
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

		public bool InsertTransferPosition()
		{
			//Add new record to TransferPosition table
			bool result = false;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{
				result = true;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spInsert_TransferPosition " + cTransferPositionAssignmentID.ToString() + ", ";
				SqlString = SqlString + "'" + cTransferPositionDateOpen + "', ";
				if (cTransferPositionDateClosed == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cTransferPositionDateClosed + "', ";
				}
				SqlString = SqlString + "'" + cTransferPositionActiveFlag + "', ";
				SqlString = SqlString + "'" + cTransferPositionDateCreated + "', ";
				SqlString = SqlString + "'" + cTransferPositionCreatedBy + "', ";
				if (cTransferPositionStatusChanged == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cTransferPositionStatusChanged + "', ";
				}
				if (cTransferPositionChangedBy == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cTransferPositionChangedBy + "', ";
				}
				if (cTransferPositionParamedicOnly == "")
				{
					SqlString = SqlString + "NULL ";
				}
				else
				{
					SqlString = SqlString + "'" + cTransferPositionParamedicOnly + "' ";
				}

				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				//UPGRADE_WARNING: (2065) ADODB.Recordset method oRec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
				oRec = oRec.NextRecordSet();
				if (!oRec.EOF)
				{
					cTransferPositionPositionID = Convert.ToInt32(oRec[0]);
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

		public bool UpdateTransferRequest()
		{
			//Update existing record in TransferRequest table
			bool result = false;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{
				result = true;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spupdate_TransferRequest " + cTransferRequestID.ToString() + ", ";
				SqlString = SqlString + "'" + cTransferRequestEmployeeID + "', ";
				SqlString = SqlString + cTransferRequestPositionID.ToString() + ", ";
				SqlString = SqlString + cTransferRequestPriorityCode.ToString() + ", ";
				SqlString = SqlString + "'" + cTransferRequestCreatedDate + "', ";
				SqlString = SqlString + "'" + cTransferRequestCreatedBy + "', ";

				if (cTransferRequestComment == "")
				{
					SqlString = SqlString + "NULL ";
				}
				else
				{
					SqlString = SqlString + "'" + cTransferRequestComment;
				}

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

		public bool UpdateTransferPosition()
		{
			//Update existing record in TransferPosition table
			bool result = false;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{
				result = true;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spUpdate_TransferPosition " + cTransferPositionPositionID.ToString() + ", ";
				SqlString = SqlString + cTransferPositionAssignmentID.ToString() + ", ";
				SqlString = SqlString + "'" + cTransferPositionDateOpen + "', ";
				if (cTransferPositionDateClosed == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cTransferPositionDateClosed + "', ";
				}
				SqlString = SqlString + "'" + cTransferPositionActiveFlag + "', ";
				SqlString = SqlString + "'" + cTransferPositionDateCreated + "', ";
				SqlString = SqlString + "'" + cTransferPositionCreatedBy + "', ";
				if (cTransferPositionStatusChanged == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cTransferPositionStatusChanged + "', ";
				}
				if (cTransferPositionChangedBy == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cTransferPositionChangedBy + "', ";
				}
				if (cTransferPositionParamedicOnly == "")
				{
					SqlString = SqlString + "NULL ";
				}
				else
				{
					SqlString = SqlString + "'" + cTransferPositionParamedicOnly + "' ";
				}

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

		public int GetTransferPositionActiveList()
		{
			//Get List of Active Transfer Positions for grid display
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_TransferPositionActiveList ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTransferPosition = oRec;
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

		public int GetTransferRequestActiveList(string sEmpID, int lPosition)
		{
			//Get List of Active Transfer Requests for grid display
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spSelect_TransferRequestActiveList ";
				if (sEmpID == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + sEmpID + "', ";
				}
				if (lPosition == 0)
				{
					SqlString = SqlString + "NULL ";
				}
				else
				{
					SqlString = SqlString + lPosition.ToString() + " ";
				}
				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTransferRequest = oRec;
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

		public int CheckTransferRequestForEmployee(string sEmpID, int iAssignID)
		{
			//Check to see if there is a TransferRequest/TransferPosition for Employee
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;

				//Step 1 - See If an Active TransferRequest for Assignment exists from Employee
				SqlString = "spSelect_CheckTransferReqForEmp '" + sEmpID + "', " + iAssignID.ToString() + " ";
				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					//Step 2 - If it does... Inactivate TransferPosition
					cTransferPositionPositionID = Convert.ToInt32(oRec["position_id"]);
					if (this.GetTransferPositionByID(cTransferPositionPositionID) != 0)
					{
						cTransferPositionActiveFlag = "N";
						cTransferPositionStatusChanged = DateTime.Now.ToString("M/d/yyyy HH:mm:ss");
						cTransferPositionChangedBy = modGlobal.Shared.gUser;
						if (this.UpdateTransferPosition())
						{
							//success!!
						}
						else
						{
							return 0;
						}
					}
					else
					{
						return 0;
					}
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

		public int GetActiveTransferRequestsForEmployee(string sEmpID)
		{
			//Get List of Active Transfer Requests for Employee
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spSelect_ActiveTransfReqForEmployee '" + sEmpID + "' ";

				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cTransferRequest = oRec;
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

		public int GetScheduleMaxYear()
		{
			//Get the Max Year for Schedule.shift_start
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spSelect_ScheduleMaxYear ";

				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cScheduleRecord = oRec;
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

		public int DeleteTransferRequest()
		{

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string sSQLString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;

				sSQLString = "spDelete_TransferRequest " + cTransferRequestID.ToString() + " ";
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

		public int InsertLeaveReturn()
		{
			//Add new record to LeaveReturn table
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

				SqlString = "spInsert_LeaveReturn '" + cLeaveReturnEmployeeID + "', ";
				SqlString = SqlString + "'" + cLeaveReturnDate + "', ";
				SqlString = SqlString + "'" + cLeaveReturnCreatedBy + "', ";
				SqlString = SqlString + "'" + cLeaveReturnCreatedDate + "', ";
				if (cLeaveReturnComments == "")
				{
					SqlString = SqlString + "NULL ";
				}
				else
				{
					SqlString = SqlString + "'" + cLeaveReturnComments + "' ";
				}

				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				//UPGRADE_WARNING: (2065) ADODB.Recordset method oRec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
				oRec = oRec.NextRecordSet();
				if (!oRec.EOF)
				{
					cLeaveReturnID = Convert.ToInt32(oRec[0]);
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

		public int UpdateLeaveReturn()
		{
			//Update existing record in LeaveReturn table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spUpdate_LeaveReturn " + cLeaveReturnID.ToString() + ", ";
				SqlString = SqlString + "'" + cLeaveReturnEmployeeID + "', ";
				SqlString = SqlString + "'" + cLeaveReturnDate + "', ";
				SqlString = SqlString + "'" + cLeaveReturnCreatedBy + "', ";
				SqlString = SqlString + "'" + cLeaveReturnCreatedDate + "', ";
				if (cLeaveReturnComments == "")
				{
					SqlString = SqlString + "NULL ";
				}
				else
				{
					SqlString = SqlString + "'" + cLeaveReturnComments + "' ";
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

		public int DeleteLeaveReturn()
		{
			//Delete existing record in LeaveReturn table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spDelete_LeaveReturn " + cLeaveReturnID.ToString() + " ";

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

		public int InsertLeaveReportUpdate()
		{
			//Add new record to LeaveReportUpdate table
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

				SqlString = "spInsert_LeaveReportUpdate '" + cLeaveReportUpdateDate + "', ";
				SqlString = SqlString + "'" + cLeaveReportUpdateUpdatedBy + "', ";
				SqlString = SqlString + "'" + cLeaveReportUpdateUpdatedDate + "' ";

				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				//UPGRADE_WARNING: (2065) ADODB.Recordset method oRec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
				oRec = oRec.NextRecordSet();
				if (!oRec.EOF)
				{
					cLeaveReportUpdateID = Convert.ToInt32(oRec[0]);
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

		public int UpdateLeaveReportUpdate()
		{
			//Update existing record in LeaveReportUpdate table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spUpdate_LeaveReportUpdate " + cLeaveReportUpdateID.ToString() + ", ";
				SqlString = SqlString + "'" + cLeaveReportUpdateDate + "', ";
				SqlString = SqlString + "'" + cLeaveReportUpdateUpdatedBy + "', ";
				SqlString = SqlString + "'" + cLeaveReportUpdateUpdatedDate + "' ";

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

		public int DeleteLeaveReportUpdate()
		{
			//Delete existing record in LeaveReportUpdate table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spDelete_LeaveReportUpdate " + cLeaveReportUpdateID.ToString() + " ";

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

		public int GetLeaveReportUpdateByDate(string sDate)
		{
			//Retrieve Record from LeaveReportUpdate by specific date
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_LeaveReportUpdateByDate '" + sDate + "' ";
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cLeaveReportUpdateID = Convert.ToInt32(oRec["report_id"]);
					cLeaveReportUpdateDate = Convert.ToDateTime(oRec["report_date"]).ToString("MM/dd/yyyy");
					cLeaveReportUpdateUpdatedBy = modGlobal.Clean(oRec["updated_by"]);
					cLeaveReportUpdateUpdatedDate = Convert.ToDateTime(oRec["updated_date"]).ToString("MM/dd/yyyy");
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

		public int GetPersonnelCallBackNumberByID(int lRecordID)
		{
			//Retrieve Record from PersonnelCallBackNumber by specific Record ID
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_PersonnelCallBackNumberByID " + lRecordID.ToString() + " ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cCallBackID = Convert.ToInt32(oRec["call_back_id"]);
					cCallBackEmployeeID = modGlobal.Clean(oRec["employee_id"]);
					cCallBackNumberFormatted = modGlobal.Clean(oRec["call_back_number"]);
					cCallBackShift = modGlobal.Clean(oRec["shift"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cCallBackNumber = Convert.ToInt32(modGlobal.GetVal(oRec["number"]));
					cCallBackDebitGroup = modGlobal.Clean(oRec["debit_group"]);
					cCallBackSpecEventFlag = modGlobal.Clean(oRec["special_event"]);
					cCallBackMedicFlag = modGlobal.Clean(oRec["medic_flag"]);
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

		public bool InsertPersonnelCallBackNumber()
		{
			//Add new record to TransferPosition table
			bool result = false;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{
				result = true;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spInsert_PersonnelCallBackNumber '" + cCallBackEmployeeID + "', ";
				SqlString = SqlString + "'" + cCallBackNumberFormatted + "', '" + cCallBackShift + "', ";
				SqlString = SqlString + cCallBackNumber.ToString() + ", ";
				if (cCallBackDebitGroup == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cCallBackDebitGroup + "', ";
				}
				SqlString = SqlString + "'" + cCallBackSpecEventFlag + "', ";
				SqlString = SqlString + "'" + cCallBackMedicFlag + "' ";

				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				//UPGRADE_WARNING: (2065) ADODB.Recordset method oRec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
				oRec = oRec.NextRecordSet();
				if (!oRec.EOF)
				{
					cCallBackID = Convert.ToInt32(oRec[0]);
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

		public bool UpdatePersonnelCallBackNumber()
		{
			//Add new record to TransferPosition table
			bool result = false;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{
				result = true;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spUpdate_PersonnelCallBackNumber " + cCallBackID.ToString() + ", ";
				SqlString = SqlString + "'" + cCallBackNumberFormatted + "', '" + cCallBackShift + "', ";
				SqlString = SqlString + cCallBackNumber.ToString() + ", ";
				if (cCallBackDebitGroup == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cCallBackDebitGroup + "', ";
				}
				SqlString = SqlString + "'" + cCallBackSpecEventFlag + "', ";
				SqlString = SqlString + "'" + cCallBackMedicFlag + "' ";

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

		public int DeletePersonnelCallBackNumber(int lRecordID)
		{
			//Delete existing record in PersonnelCallBackNumber table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spDelete_PersonnelCallBackNumber " + lRecordID.ToString() + " ";

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

		public int CheckCallBackNumberInUse(string sShift, int iNumber, string sEmpID)
		{
			//Check to see if PersonnelCallBackNumber exists for someone else
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spSelect_CheckCallNumberInUse '" + modGlobal.Clean(sShift) + "', ";
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				SqlString = SqlString + Convert.ToString(modGlobal.GetVal(iNumber)) + ", '" + modGlobal.Clean(sEmpID) + "' ";
				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cPersonnelCallBackNumber = oRec;
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

		public int GetEmployeeIDByPerSysID(int lPerSysID)
		{
			//Retrieve Employee ID from Personnel table by PerSysID
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_EmployeeIDByPerSysID " + lPerSysID.ToString() + " ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cPersonnelRecord = oRec;
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

		public int GetBattLineupCompleteByBattDate(string sBatt, string sDate)
		{
			//Retrieve Record from BattalionLineUpComplete by specific battalion and date
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_BattalionLineUpCompleteByBattDate '" + sBatt + "', '" + sDate + "' ";
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cBattLineupID = Convert.ToInt32(oRec["lineup_id"]);
					cBattLineupBattCode = modGlobal.Clean(oRec["battalion_code"]);
					cBattLineupDate = Convert.ToDateTime(oRec["lineup_date"]).ToString("MM/dd/yyyy");
					cBattLineupUpdatedBy = modGlobal.Clean(oRec["updated_by"]);
					cBattLineupUpdatedDate = Convert.ToDateTime(oRec["updated_datetime"]).ToString("MM/dd/yyyy HH:mm:ss");
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

		public int DeleteBattalionLineUpComplete()
		{
			//Delete existing record in BattalionLineUpComplete table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spDelete_BattalionLineUpComplete " + cBattLineupID.ToString() + " ";

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

		public int InsertBattalionLineUpComplete()
		{
			//Add new record to BattalionLineUpComplete table
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

				SqlString = "spInsert_BattalionLineUpComplete '" + cBattLineupBattCode + "', ";
				SqlString = SqlString + "'" + cBattLineupDate + "', ";
				SqlString = SqlString + "'" + cBattLineupUpdatedBy + "', ";
				SqlString = SqlString + "'" + cBattLineupUpdatedDate + "' ";

				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				//UPGRADE_WARNING: (2065) ADODB.Recordset method oRec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
				oRec = oRec.NextRecordSet();
				if (!oRec.EOF)
				{
					cBattLineupID = Convert.ToInt32(oRec[0]);
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

		public int UpdateBattalionLineUpComplete()
		{
			//Update existing record in BattalionLineUpComplete table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spUpdate_BattalionLineUpComplete " + cBattLineupID.ToString() + ", ";
				SqlString = SqlString + "'" + cBattLineupBattCode + "', ";
				SqlString = SqlString + "'" + cBattLineupDate + "', ";
				SqlString = SqlString + "'" + cBattLineupUpdatedBy + "', ";
				SqlString = SqlString + "'" + cBattLineupUpdatedDate + "' ";

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

		public int CheckForUnscheduledDebit(string sEmpID, string sDate)
		{
			//Check to see if Scheduled Employee TimeCode = UDD
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spSelect_CheckForUnschedDebit '" + modGlobal.Clean(sEmpID) + "', ";
				SqlString = SqlString + "'" + modGlobal.Clean(sDate) + "' ";
				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cScheduleRecord = oRec;
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

		public int GetStaffingDiscrepancyList(string sStartDate, string sEndDate)
		{
			//Check to see if Scheduled Employee TimeCode = UDD
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spSelect_StaffingErrorLogList ";
				if (modGlobal.Clean(sStartDate) == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + sStartDate + "', ";
				}
				if (modGlobal.Clean(sEndDate) == "")
				{
					SqlString = SqlString + "NULL ";
				}
				else
				{
					SqlString = SqlString + "'" + sEndDate + "' ";
				}

				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cScheduleRecord = oRec;
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

		public int DeleteWatchDutyAssignmentRecord()
		{
			//Delete existing record in PersonnelWatchDutyAssignment table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spDelete_PersonnelWatchDutyAssignment " + cWatchDutyAssignDutyID.ToString() + " ";

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

		public bool AddWatchDutyAssignmentRecord()
		{
			//Add new record to PersonnelWatchDutyAssignment
			bool result = false;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{
				result = true;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spInsert_PersonnelWatchDutyAssignment '" + cWatchDutyAssignEmpID + "', ";
				SqlString = SqlString + "'" + cWatchDutyAssignDutyDate + "', '" + cWatchDutyAssignedBy + "', ";
				SqlString = SqlString + "'" + cWatchDutyAssignedDate + "' ";

				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				//UPGRADE_WARNING: (2065) ADODB.Recordset method oRec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
				oRec = oRec.NextRecordSet();
				if (!oRec.EOF)
				{
					cWatchDutyAssignDutyID = Convert.ToInt32(oRec[0]);
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

		public int GetEmployeeWatchDutyList(string sDate, int iStationID, string sAssignFlag)
		{
			//Get Employee Watch Duty List
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spSelect_WatchDutyEmployeeListFiltered '" + sDate + "', ";
				//UPGRADE_WARNING: (1068) GetVal(iStationID) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				if (Convert.ToDouble(modGlobal.GetVal(iStationID)) == 0)
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + iStationID.ToString() + ", ";
				}
				SqlString = SqlString + "'" + sAssignFlag + "' ";

				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cWatchDutyAssignment = oRec;
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

		public int GetPersonnelSchedNotesFiltered(string sStartDate, string sEndDate, string sText)
		{
			//Get PersonnelScheduleNotes by To/From Date and/or text
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spSelect_PersonnelScheduleNotesByDateText ";
				SqlString = SqlString + "'" + sStartDate + "', ";
				SqlString = SqlString + "'" + sEndDate + "', ";
				SqlString = SqlString + "'" + modGlobal.Clean(sText) + "' ";
				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cScheduleRecord = oRec;
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

		public bool AddEmployeeAvailableToWork()
		{
			//Add new record to EmployeeAvailableToWork
			bool result = false;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{
				result = true;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spInsert_EmployeeAvailableToWork '" + cEmpAvailToWorkEmpID + "', ";
				SqlString = SqlString + "'" + cEmpAvailToWorkShiftDate + "', '" + cEmpAvailToWorkCreatedBy + "', ";
				SqlString = SqlString + "'" + cEmpAvailToWorkCreatedOn + "', ";

				if (cEmpAvailToWorkComment == "")
				{
					SqlString = SqlString + "NULL ";
				}
				else
				{
					SqlString = SqlString + "'" + cEmpAvailToWorkComment + "' ";
				}

				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				//UPGRADE_WARNING: (2065) ADODB.Recordset method oRec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
				oRec = oRec.NextRecordSet();
				if (!oRec.EOF)
				{
					cEmpAvailToWorkID = Convert.ToInt32(oRec[0]);
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

		public int DeleteEmployeeAvailableToWork()
		{
			//Delete existing record in EmployeeAvailableToWork table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spDelete_EmployeeAvailableToWork " + cEmpAvailToWorkID.ToString() + " ";

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

		public int GetEmployeeAvailableToWorkByEmp(string sEmpID)
		{
			//Get EmployeeAvailableToWork for selected Employee ID
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spSelect_EmployeeAvailableToWorkByEmpID '" + sEmpID + "' ";

				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cEmployeeAvailableToWork = oRec;
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

		public int GetEmployeeAvailableToWorkByDate(string sDate)
		{
			//Get EmployeeAvailableToWork for selected Date
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spSelect_EmployeeAvailableToWorkByDate '" + sDate + "' ";

				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cEmployeeAvailableToWork = oRec;
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

		public int GetEmployeeAvailableToWorkByID(int lRecordID)
		{
			//Retrieve Record from EmployeeAvailableToWork by specific Record ID
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_EmployeeAvailableToWorkByRecordID " + lRecordID.ToString() + " ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cEmpAvailToWorkID = Convert.ToInt32(modGlobal.GetVal(oRec["available_id"]));
					cEmpAvailToWorkEmpID = modGlobal.Clean(oRec["employee_id"]);
					cEmpAvailToWorkShiftDate = Convert.ToDateTime(oRec["shift_start"]).ToString("MM/dd/yyyy HH:mm");
					cEmpAvailToWorkCreatedOn = Convert.ToDateTime(oRec["created_on"]).ToString("MM/dd/yyyy HH:mm:ss");
					cEmpAvailToWorkCreatedBy = modGlobal.Clean(oRec["created_by"]);
					cEmpAvailToWorkComment = modGlobal.Clean(oRec["comment"]);
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

		public int GetEmployeeCallBackPhoneList(string sEmpID)
		{
			//Get List of CallBack Phone Numbers for specific Employee
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;
				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_CallBackPhoneForEmployee '" + sEmpID + "' ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cEmployeeAvailableToWork = oRec;
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

		public int GetWatchDutySecurity(string sEmpID)
		{
			// Get Employee Information for Staff Permissions to update
			// Watch Duty Information
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_WatchDutySecurity '" + sEmpID + "' ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cScheduleRecord = oRec;
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

		public int CheckIfTransferClosed(int lPosition)
		{
			//Check to see if Active TransferPosition is still open
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_CheckIfTransferClosed " + lPosition.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTransferPosition = oRec;
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

		public int CheckRequestForPositionPriority()
		{
			//Check to see if Active TransferPosition exist for Position or Priority... only use once
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_CheckRequestForPositionPriority '" + TransferRequestEmployeeID + "', " + TransferRequestPositionID.ToString() + ", " + TransferRequestPriorityCode.ToString() + " ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cTransferPosition = oRec;
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

		public string UniqueID { get; set; }

		public UpgradeHelpers.Interfaces.IViewManager ViewManager { get; set; }

		public UpgradeHelpers.Interfaces.IIocContainer Container { get; set; }

	}
}