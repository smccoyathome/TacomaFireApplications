using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public class clsFireUpload
		: UpgradeHelpers.Interfaces.IDependentModel, UpgradeHelpers.Interfaces.ICreatesObjects, UpgradeHelpers
		.Interfaces.IInteractsWithView, UpgradeHelpers.Interfaces.IInitializableCommon, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(clsFireUpload));
		}

		void UpgradeHelpers.Interfaces.IInitializableCommon.Common()
		{
			_cPersonnelPayroll = null;
			cPPpayroll_sys_id = 0;
			cPPcalendar_year = 0;
			cPPpay_period = 0;
			cPPper_sys_id = 0;
			cPPpayroll_date = "";
			cPPsap_acttype = "";
			cPPa_a_type = "";
			cPPhours = 0;
			cPPexception_job_code = "";
			cPPexception_step = "";
			cPPsap_rec_center = "";
			cPPsap_rec_order = "";
			cPPwbs_element = "";
			cPPsap_activity = "";
			cPPcreate_date = "";
			cPPcreate_by = "";
			cPPlast_update_date = "";
			cPPlast_update_by = "";
			cPPpayroll_status_code = "";
			cPPFillerCodeId = "";
			_cPayrollTransfer = null;
			_cPayrollRS = null;
			_cPayrollReconciliation = null;
			cPRReturnmsg = "";
			cPRWorkdate = "";
			cPRActtype = "";
			cPRRec_cctr = "";
			cPREmployeenumber = 0;
			cPRRec_order = "";
			cPRActivity = "";
			cPRWbs_element = "";
			cPRAbs_att_type = "";
			cPRPayscalegroup = "";
			cPRPayscalelevel = "";
			cPRCatshours = 0;
			cPRUnit = "";
			cPRApproved_by = 0;
			cPRStatus = "";
			cPRUploadDate = "";
			cPRCounter = "";
			cPRPayroll_sys_id = 0;
			_cTimeCode = null;
			cTCtimecodesysid = 0;
			cTCtimecodeid = "";
			cTCdescription = "";
			cTCtimetypecode = "";
			cTCnotesavailable = 0;
			cTCaatype = "";
			cTCaatype2 = "";
			cTCwagetype = "";
			cTCfillercode = "";
			cTCpensionlimit = 0;
			cTCactivitytype = "";
			_cPPayrollSignOff = null;
			cPPSOpayroll_sys_id = 0;
			cPPSOper_sys_id = 0;
			cPPSOcalendar_year = 0;
			cPPSOpay_period = 0;
			cPPSignOff_date = "";
			_cSupervisorTCApproval = null;
			cSTCApprovalID = 0;
			cSTCApprovalcalendar_year = 0;
			cSTCApprovalpay_period = 0;
			cSTCApprovalEmployee = 0;
			cSTCApprovalSupervisor = 0;
			cSTCApprovaldate = "";
			_cMurrayMorganWorkOrder = null;
		}

		//*******************************************************
		//**    PayRoll Transfer Class                         **
		//**    Properties & Methods                           **
		//*******************************************************


		//*************************************************
		//**             Private Class Variables         **
		//*************************************************
		//PersonnelPayroll
		public virtual ADORecordSetHelper _cPersonnelPayroll { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cPersonnelPayroll
		{
			get
			{
				if (_cPersonnelPayroll == null)
				{
					_cPersonnelPayroll = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cPersonnelPayroll;
			}
			set
			{
				_cPersonnelPayroll = value;
			}
		}

		public virtual int cPPpayroll_sys_id { get; set; }

		public virtual int cPPcalendar_year { get; set; }

		public virtual int cPPpay_period { get; set; }

		public virtual int cPPper_sys_id { get; set; }

		public virtual string cPPpayroll_date { get; set; }

		public virtual string cPPsap_acttype { get; set; }

		public virtual string cPPa_a_type { get; set; }

		public virtual double cPPhours { get; set; }

		public virtual string cPPexception_job_code { get; set; }

		public virtual string cPPexception_step { get; set; }

		public virtual string cPPsap_rec_center { get; set; }

		public virtual string cPPsap_rec_order { get; set; }

		public virtual string cPPwbs_element { get; set; }

		public virtual string cPPsap_activity { get; set; }

		public virtual string cPPcreate_date { get; set; }

		public virtual string cPPcreate_by { get; set; }

		public virtual string cPPlast_update_date { get; set; }

		public virtual string cPPlast_update_by { get; set; }

		public virtual string cPPpayroll_status_code { get; set; }

		public virtual string cPPFillerCodeId { get; set; }

		//PayrollTransfer
		public virtual ADORecordSetHelper _cPayrollTransfer { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cPayrollTransfer
		{
			get
			{
				if (_cPayrollTransfer == null)
				{
					_cPayrollTransfer = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cPayrollTransfer;
			}
			set
			{
				_cPayrollTransfer = value;
			}
		}

		public virtual ADORecordSetHelper _cPayrollRS { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cPayrollRS
		{
			get
			{
				if (_cPayrollRS == null)
				{
					_cPayrollRS = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cPayrollRS;
			}
			set
			{
				_cPayrollRS = value;
			}
		}


		//PayrollReconciliation
		public virtual ADORecordSetHelper _cPayrollReconciliation { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cPayrollReconciliation
		{
			get
			{
				if (_cPayrollReconciliation == null)
				{
					_cPayrollReconciliation = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cPayrollReconciliation;
			}
			set
			{
				_cPayrollReconciliation = value;
			}
		}

		public virtual string cPRReturnmsg { get; set; }

		public virtual string cPRWorkdate { get; set; }

		public virtual string cPRActtype { get; set; }

		public virtual string cPRRec_cctr { get; set; }

		public virtual int cPREmployeenumber { get; set; }

		public virtual string cPRRec_order { get; set; }

		public virtual string cPRActivity { get; set; }

		public virtual string cPRWbs_element { get; set; }

		public virtual string cPRAbs_att_type { get; set; }

		public virtual string cPRPayscalegroup { get; set; }

		public virtual string cPRPayscalelevel { get; set; }

		public virtual double cPRCatshours { get; set; }

		public virtual string cPRUnit { get; set; }

		public virtual int cPRApproved_by { get; set; }

		public virtual string cPRStatus { get; set; }

		public virtual string cPRUploadDate { get; set; }

		public virtual string cPRCounter { get; set; }

		public virtual int cPRPayroll_sys_id { get; set; }

		//TimeCode
		public virtual ADORecordSetHelper _cTimeCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cTimeCode
		{
			get
			{
				if (_cTimeCode == null)
				{
					_cTimeCode = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cTimeCode;
			}
			set
			{
				_cTimeCode = value;
			}
		}

		public virtual int cTCtimecodesysid { get; set; }

		public virtual string cTCtimecodeid { get; set; }

		public virtual string cTCdescription { get; set; }

		public virtual string cTCtimetypecode { get; set; }

		public virtual byte cTCnotesavailable { get; set; }

		public virtual string cTCaatype { get; set; }

		public virtual string cTCaatype2 { get; set; }

		public virtual string cTCwagetype { get; set; }

		public virtual string cTCfillercode { get; set; }

		public virtual byte cTCpensionlimit { get; set; }

		public virtual string cTCactivitytype { get; set; }

		//PersonnelPayrollSignOff
		public virtual ADORecordSetHelper _cPPayrollSignOff { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cPPayrollSignOff
		{
			get
			{
				if (_cPPayrollSignOff == null)
				{
					_cPPayrollSignOff = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cPPayrollSignOff;
			}
			set
			{
				_cPPayrollSignOff = value;
			}
		}

		public virtual int cPPSOpayroll_sys_id { get; set; }

		public virtual int cPPSOper_sys_id { get; set; }

		public virtual int cPPSOcalendar_year { get; set; }

		public virtual int cPPSOpay_period { get; set; }

		public virtual string cPPSignOff_date { get; set; }

		//Supervisor Timecard Approval
		public virtual ADORecordSetHelper _cSupervisorTCApproval { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cSupervisorTCApproval
		{
			get
			{
				if (_cSupervisorTCApproval == null)
				{
					_cSupervisorTCApproval = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cSupervisorTCApproval;
			}
			set
			{
				_cSupervisorTCApproval = value;
			}
		}

		public virtual int cSTCApprovalID { get; set; }

		public virtual int cSTCApprovalcalendar_year { get; set; }

		public virtual int cSTCApprovalpay_period { get; set; }

		public virtual int cSTCApprovalEmployee { get; set; }

		public virtual int cSTCApprovalSupervisor { get; set; }

		public virtual string cSTCApprovaldate { get; set; }

		public virtual ADORecordSetHelper _cMurrayMorganWorkOrder { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cMurrayMorganWorkOrder
		{
			get
			{
				if (_cMurrayMorganWorkOrder == null)
				{
					_cMurrayMorganWorkOrder = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cMurrayMorganWorkOrder;
			}
			set
			{
				_cMurrayMorganWorkOrder = value;
			}
		}




		//**********************************************
		//**         Public Class Methods             **
		//**********************************************
		//PersonnelPayroll
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper PersonnelPayroll
		{
			get
			{
				return cPersonnelPayroll;
			}
			set
			{
				cPersonnelPayroll = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int PPpayroll_sys_id
		{
			get
			{
				return cPPpayroll_sys_id;
			}
			set
			{
				cPPpayroll_sys_id = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int PPcalendar_year
		{
			get
			{
				return cPPcalendar_year;
			}
			set
			{
				cPPcalendar_year = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int PPpay_period
		{
			get
			{
				return cPPpay_period;
			}
			set
			{
				cPPpay_period = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int PPper_sys_id
		{
			get
			{
				return cPPper_sys_id;
			}
			set
			{
				cPPper_sys_id = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PPpayroll_date
		{
			get
			{
				return cPPpayroll_date;
			}
			set
			{
				cPPpayroll_date = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PPsap_acttype
		{
			get
			{
				return cPPsap_acttype;
			}
			set
			{
				cPPsap_acttype = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PPa_a_type
		{
			get
			{
				return cPPa_a_type;
			}
			set
			{
				cPPa_a_type = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public double PPhours
		{
			get
			{
				return cPPhours;
			}
			set
			{
				cPPhours = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PPexception_job_code
		{
			get
			{
				return cPPexception_job_code;
			}
			set
			{
				cPPexception_job_code = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PPexception_step
		{
			get
			{
				return cPPexception_step;
			}
			set
			{
				cPPexception_step = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PPsap_rec_center
		{
			get
			{
				return cPPsap_rec_center;
			}
			set
			{
				cPPsap_rec_center = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PPsap_rec_order
		{
			get
			{
				return cPPsap_rec_order;
			}
			set
			{
				cPPsap_rec_order = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PPwbs_element
		{
			get
			{
				return cPPwbs_element;
			}
			set
			{
				cPPwbs_element = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PPsap_activity
		{
			get
			{
				return cPPsap_activity;
			}
			set
			{
				cPPsap_activity = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PPcreate_date
		{
			get
			{
				return cPPcreate_date;
			}
			set
			{
				cPPcreate_date = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PPcreate_by
		{
			get
			{
				return cPPcreate_by;
			}
			set
			{
				cPPcreate_by = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PPlast_update_date
		{
			get
			{
				return cPPlast_update_date;
			}
			set
			{
				cPPlast_update_date = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PPlast_update_by
		{
			get
			{
				return cPPlast_update_by;
			}
			set
			{
				cPPlast_update_by = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PPpayroll_status_code
		{
			get
			{
				return cPPpayroll_status_code;
			}
			set
			{
				cPPpayroll_status_code = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PPFillerCodeID
		{
			get
			{
				return cPPFillerCodeId;
			}
			set
			{
				cPPFillerCodeId = value;
			}
		}


		//PayrollTransfer
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper PayrollTransfer
		{
			get
			{
				return cPayrollTransfer;
			}
			set
			{
				cPayrollTransfer = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public ADORecordSetHelper PayrollRS
		{
			get
			{
				return cPayrollRS;
			}
			set
			{
				cPayrollRS = value;
			}
		}


		//PayrollReconciliation
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper PayrollReconciliation
		{
			get
			{
				return cPayrollReconciliation;
			}
			set
			{
				cPayrollReconciliation = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PRReturnmsg
		{
			get
			{
				return cPRReturnmsg;
			}
			set
			{
				cPRReturnmsg = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PRWorkdate
		{
			get
			{
				return cPRWorkdate;
			}
			set
			{
				cPRWorkdate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PRActtype
		{
			get
			{
				return cPRActtype;
			}
			set
			{
				cPRActtype = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PRRec_cctr
		{
			get
			{
				return cPRRec_cctr;
			}
			set
			{
				cPRRec_cctr = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int PREmployeenumber
		{
			get
			{
				return cPREmployeenumber;
			}
			set
			{
				cPREmployeenumber = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PRRec_order
		{
			get
			{
				return cPRRec_order;
			}
			set
			{
				cPRRec_order = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PRActivity
		{
			get
			{
				return cPRActivity;
			}
			set
			{
				cPRActivity = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PRWbs_element
		{
			get
			{
				return cPRWbs_element;
			}
			set
			{
				cPRWbs_element = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PRAbs_att_type
		{
			get
			{
				return cPRAbs_att_type;
			}
			set
			{
				cPRAbs_att_type = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PRPayscalegroup
		{
			get
			{
				return cPRPayscalegroup;
			}
			set
			{
				cPRPayscalegroup = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PRPayscalelevel
		{
			get
			{
				return cPRPayscalelevel;
			}
			set
			{
				cPRPayscalelevel = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public double PRCatshours
		{
			get
			{
				return cPRCatshours;
			}
			set
			{
				cPRCatshours = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PRUnit
		{
			get
			{
				return cPRUnit;
			}
			set
			{
				cPRUnit = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int PRApproved_by
		{
			get
			{
				return cPRApproved_by;
			}
			set
			{
				cPRApproved_by = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PRStatus
		{
			get
			{
				return cPRStatus;
			}
			set
			{
				cPRStatus = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PRUploadDate
		{
			get
			{
				return cPRUploadDate;
			}
			set
			{
				cPRUploadDate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PRCounter
		{
			get
			{
				return cPRCounter;
			}
			set
			{
				cPRCounter = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int PRPayroll_sys_id
		{
			get
			{
				return cPRPayroll_sys_id;
			}
			set
			{
				cPRPayroll_sys_id = value;
			}
		}


		//TimeCode
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper TimeCode
		{
			get
			{
				return cTimeCode;
			}
			set
			{
				cTimeCode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int TCtimecodesysid
		{
			get
			{
				return cTCtimecodesysid;
			}
			set
			{
				cTCtimecodesysid = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string TCtimecodeid
		{
			get
			{
				return cTCtimecodeid;
			}
			set
			{
				cTCtimecodeid = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string TCdescription
		{
			get
			{
				return cTCdescription;
			}
			set
			{
				cTCdescription = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string TCtimetypecode
		{
			get
			{
				return cTCtimetypecode;
			}
			set
			{
				cTCtimetypecode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte TCnotesavailable
		{
			get
			{
				return cTCnotesavailable;
			}
			set
			{
				cTCnotesavailable = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string TCaatype
		{
			get
			{
				return cTCaatype;
			}
			set
			{
				cTCaatype = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string TCaatype2
		{
			get
			{
				return cTCaatype2;
			}
			set
			{
				cTCaatype2 = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string TCwagetype
		{
			get
			{
				return cTCwagetype;
			}
			set
			{
				cTCwagetype = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string TCfillercode
		{
			get
			{
				return cTCfillercode;
			}
			set
			{
				cTCfillercode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte TCpensionlimit
		{
			get
			{
				return cTCpensionlimit;
			}
			set
			{
				cTCpensionlimit = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string TCactivitytype
		{
			get
			{
				return cTCactivitytype;
			}
			set
			{
				cTCactivitytype = value;
			}
		}


		//PersonnelPayrollSignOff
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper PPayrollSignOff
		{
			get
			{
				return cPPayrollSignOff;
			}
			set
			{
				cPPayrollSignOff = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int PPSOpayroll_sys_id
		{
			get
			{
				return cPPSOpayroll_sys_id;
			}
			set
			{
				cPPSOpayroll_sys_id = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int PPSOcalendar_year
		{
			get
			{
				return cPPSOcalendar_year;
			}
			set
			{
				cPPSOcalendar_year = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int PPSOpay_period
		{
			get
			{
				return cPPSOpay_period;
			}
			set
			{
				cPPSOpay_period = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int PPSOper_sys_id
		{
			get
			{
				return cPPSOper_sys_id;
			}
			set
			{
				cPPSOper_sys_id = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PPSignOff_date
		{
			get
			{
				return cPPSignOff_date;
			}
			set
			{
				cPPSignOff_date = value;
			}
		}


		//Supervisor Timecard Approval
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper SupervisorTCApproval
		{
			get
			{
				return cSupervisorTCApproval;
			}
			set
			{
				cSupervisorTCApproval = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int STCApprovalID
		{
			get
			{
				return cSTCApprovalID;
			}
			set
			{
				cSTCApprovalID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int STCApprovalcalendar_year
		{
			get
			{
				return cSTCApprovalcalendar_year;
			}
			set
			{
				cSTCApprovalcalendar_year = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int STCApprovalpay_period
		{
			get
			{
				return cSTCApprovalpay_period;
			}
			set
			{
				cSTCApprovalpay_period = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int STCApprovalEmployee
		{
			get
			{
				return cSTCApprovalEmployee;
			}
			set
			{
				cSTCApprovalEmployee = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int STCApprovalSupervisor
		{
			get
			{
				return cSTCApprovalSupervisor;
			}
			set
			{
				cSTCApprovalSupervisor = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string STCApprovaldate
		{
			get
			{
				return cSTCApprovaldate;
			}
			set
			{
				cSTCApprovaldate = value;
			}
		}


		//cMurrayMorganWorkOrder
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper MurrayMorganWorkOrder
		{
			get
			{
				return cMurrayMorganWorkOrder;
			}
			set
			{
				cMurrayMorganWorkOrder = value;
			}
		}


		//*********************************************
		//**     Public Class Functions/Subroutines  **
		//*********************************************

		public int GetPayrollTransfer(int lsapUser)
		{
			//Retrieve Records from PayrollTransfer table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modPTSPayroll.oPayroll;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_PayrollTransfer " + lsapUser.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cPayrollTransfer = oRec;
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

		public int InsertReconciliation()
		{
			//Insert Records into PayrollReconciliation table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modPTSPayroll.oPayroll;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spInsert_PayrollReconciliation '";
				SqlString = SqlString + cPRReturnmsg + "','" + cPRWorkdate + "','" + cPRActtype + "','";
				SqlString = SqlString + cPRRec_cctr + "'," + cPREmployeenumber.ToString() + ",'" + cPRRec_order + "','";
				SqlString = SqlString + cPRActivity + "','" + cPRWbs_element + "','" + cPRAbs_att_type + "','";
				SqlString = SqlString + cPRPayscalegroup + "','" + cPRPayscalelevel + "'," + cPRCatshours.ToString() + ",'";
				SqlString = SqlString + cPRUnit + "'," + cPRApproved_by.ToString() + ",'" + cPRStatus + "','" + cPRUploadDate;
				SqlString = SqlString + "','" + cPRCounter + "'," + cPRPayroll_sys_id.ToString();
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

		public int DeletePayrollTransfer(int lPSysID)
		{
			//Retrieve Records from PayrollTransfer table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{
				result = -1;

				oCmd.Connection = modPTSPayroll.oPayroll;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spDelete_PayrollTransfer " + lPSysID.ToString();
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


		public int GetPayrollReconciliation(int lSysID)
		{
			//Retrieve Records from PayrollTransfer table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modPTSPayroll.oPayroll;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_PayrollReconciliationBySysID " + lSysID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cPayrollReconciliation = oRec;
					LoadPayrollReconciliation();
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

		public int GetReconciliationLastAction(int lSysID)
		{
			//Retrieve Records from PayrollTransfer table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modPTSPayroll.oPayroll;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_PayrollReconciliationLastAction " + lSysID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cPayrollReconciliation = oRec;
					LoadPayrollReconciliation();
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

		public int GetReconciliationForDelete(int lSysID)
		{
			//Retrieve Records from PayrollTransfer table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modPTSPayroll.oPayroll;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_PayrollReconciliationForDelete " + lSysID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cPayrollReconciliation = oRec;
					LoadPayrollReconciliation();
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

		public int GetPayrollTransferBySysID(int lSysID)
		{
			//Retrieve Records from PayrollTransfer table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modPTSPayroll.oPayroll;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_PayrollTransferBySysID " + lSysID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cPayrollRS = oRec;
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

		private void LoadPayrollReconciliation()
		{
			//Load Payroll Reconciliation private variables with values from retrieved recordset

			cPRReturnmsg = Convert.ToString(cPayrollReconciliation["return_msg"]);
			cPRWorkdate = Convert.ToString(cPayrollReconciliation["workdate"]);
			cPRActtype = Convert.ToString(cPayrollReconciliation["acttype"]);
			cPREmployeenumber = Convert.ToInt32(cPayrollReconciliation["employeenumber"]);
			cPRRec_order = Convert.ToString(cPayrollReconciliation["rec_order"]);
			cPRActivity = Convert.ToString(cPayrollReconciliation["activity"]);
			cPRWbs_element = Convert.ToString(cPayrollReconciliation["wbs_element"]);
			cPRAbs_att_type = Convert.ToString(cPayrollReconciliation["abs_att_type"]);
			cPRPayscalegroup = Convert.ToString(cPayrollReconciliation["payscalegroup"]);
			cPRPayscalelevel = Convert.ToString(cPayrollReconciliation["payscalelevel"]);
			cPRCatshours = Convert.ToDouble(cPayrollReconciliation["catshours"]);
			cPRUnit = Convert.ToString(cPayrollReconciliation["unit"]);
			cPRApproved_by = Convert.ToInt32(cPayrollReconciliation["approved_by"]);
			cPRStatus = Convert.ToString(cPayrollReconciliation["status"]);
			cPRUploadDate = Convert.ToString(cPayrollReconciliation["upload_date"]);
			cPRCounter = Convert.ToString(cPayrollReconciliation["counter"]);
			cPRPayroll_sys_id = Convert.ToInt32(cPayrollReconciliation["payroll_sys_id"]);

		}

		public int InsertPersonnelPayroll()
		{
			//Insert Record into PersonnelPayrolltable
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

				SqlString = "spInsertPersonnelPayRoll " + cPPcalendar_year.ToString() + "," + cPPpay_period.ToString() + ",";
				SqlString = SqlString + cPPper_sys_id.ToString() + ",'" + cPPpayroll_date + "',";
				if (cPPsap_acttype != "")
				{
					SqlString = SqlString + "'" + cPPsap_acttype + "',";
				}
				else
				{
					SqlString = SqlString + "Null,";
				}
				SqlString = SqlString + "'" + cPPa_a_type + "'," + Math.Round((double) cPPhours, 2).ToString() + ",";
				if (cPPexception_job_code != "")
				{
					SqlString = SqlString + "'" + cPPexception_job_code + "',";
				}
				else
				{
					SqlString = SqlString + "Null,";
				}
				if (cPPexception_step != "")
				{
					SqlString = SqlString + modGlobal.Clean(cPPexception_step) + ",";
				}
				else
				{
					SqlString = SqlString + "Null,";
				}
				if (cPPsap_rec_center != "")
				{
					SqlString = SqlString + "'" + cPPsap_rec_center + "',";
				}
				else
				{
					SqlString = SqlString + "Null,";
				}
				if (cPPsap_rec_order != "")
				{
					SqlString = SqlString + "'" + cPPsap_rec_order + "',";
				}
				else
				{
					SqlString = SqlString + "Null,";
				}
				if (cPPwbs_element != "")
				{
					SqlString = SqlString + "'" + cPPwbs_element + "',";
				}
				else
				{
					SqlString = SqlString + "Null,";
				}
				if (cPPsap_activity != "")
				{
					SqlString = SqlString + "'" + cPPsap_activity + "',";
				}
				else
				{
					SqlString = SqlString + "Null,";
				}
				SqlString = SqlString + "'" + cPPcreate_date + "','" + cPPcreate_by + "' ";

				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				//UPGRADE_WARNING: (2065) ADODB.Recordset method oRec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
				oRec = oRec.NextRecordSet();
				if (!oRec.EOF)
				{
					cPPpayroll_sys_id = Convert.ToInt32(oRec[0]);
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

		public int DeletePersonnelPayroll(int lPayrollSysID)
		{
			//Delete Record from PersonnelPayroll table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				if (CheckForPreviousSAPInsert(lPayrollSysID) != 0)
				{
					if (GetPersonnelPayrollRecord(lPayrollSysID) != 0)
					{
						cPPhours = 0;
						cPPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
						cPPlast_update_by = modGlobal.Shared.gUser;
						cPPpayroll_status_code = "N";
						if (UpdatePersonnelPayroll(lPayrollSysID) != 0)
						{
							return -1;
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
					result = -1;
				}

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spDeletePersonnelPayRoll " + lPayrollSysID.ToString();
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

		public int GetPersonnelPayrollRecord(int lPayrollSysID)
		{
			//Retrieve PersonnelPayroll  Record
			//Load Class  Variables with selected Record
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_PersonnelPayRollRecord " + lPayrollSysID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					//Load Class  Variables
					cPPpayroll_sys_id = Convert.ToInt32(oRec["payroll_sys_id"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cPPcalendar_year = Convert.ToInt32(modGlobal.GetVal(oRec["calendar_year"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cPPpay_period = Convert.ToInt32(modGlobal.GetVal(oRec["pay_period"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cPPper_sys_id = Convert.ToInt32(modGlobal.GetVal(oRec["per_sys_id"]));
					cPPpayroll_date = Convert.ToDateTime(oRec["payroll_date"]).ToString("MM/dd/yyyy");
					cPPsap_acttype = modGlobal.Clean(oRec["sap_acttype"]);
					cPPa_a_type = modGlobal.Clean(oRec["a_a_type"]);
					cPPhours = Math.Round((double) Convert.ToDouble(oRec["hours"]), 2);
					cPPexception_job_code = modGlobal.Clean(oRec["exception_job_code"]);
					cPPexception_step = modGlobal.Clean(oRec["exception_step"]);
					cPPsap_rec_center = modGlobal.Clean(oRec["sap_rec_center"]);
					cPPsap_rec_order = modGlobal.Clean(oRec["sap_rec_order"]);
					cPPwbs_element = modGlobal.Clean(oRec["wbs_element"]);
					cPPsap_activity = modGlobal.Clean(oRec["sap_activity"]);
					cPPcreate_date = Convert.ToDateTime(oRec["create_date"]).ToString("MM/dd/yyyy");
					cPPcreate_by = modGlobal.Clean(oRec["create_by"]);
					cPPlast_update_date = Convert.ToDateTime(oRec["last_update_date"]).ToString("MM/dd/yyyy");
					cPPlast_update_by = modGlobal.Clean(oRec["last_update_by"]);
					cPPpayroll_status_code = modGlobal.Clean(oRec["payroll_status_code"]);

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

		public int UpdatePersonnelPayroll(int lPayrollSysID)
		{
			//UpdatePersonnelPayroll  Record

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spUpdatePersonnelPayRoll " + lPayrollSysID.ToString() + ",";
				if (cPPsap_acttype != "")
				{
					SqlString = SqlString + "'" + cPPsap_acttype + "',";
				}
				else
				{
					SqlString = SqlString + "Null,";
				}
				SqlString = SqlString + "'" + cPPa_a_type + "'," + Math.Round((double) cPPhours, 2).ToString() + ",";
				if (cPPexception_job_code != "")
				{
					SqlString = SqlString + "'" + cPPexception_job_code + "',";
				}
				else
				{
					SqlString = SqlString + "Null,";
				}
				if (cPPexception_step != "")
				{
					SqlString = SqlString + "'" + cPPexception_step + "',";
				}
				else
				{
					SqlString = SqlString + "Null,";
				}
				if (cPPsap_rec_center != "")
				{
					SqlString = SqlString + "'" + cPPsap_rec_center + "',";
				}
				else
				{
					SqlString = SqlString + "Null,";
				}
				if (cPPsap_rec_order != "")
				{
					SqlString = SqlString + "'" + cPPsap_rec_order + "',";
				}
				else
				{
					SqlString = SqlString + "Null,";
				}
				if (cPPwbs_element != "")
				{
					SqlString = SqlString + "'" + cPPwbs_element + "',";
				}
				else
				{
					SqlString = SqlString + "Null,";
				}
				if (cPPsap_activity != "")
				{
					SqlString = SqlString + "'" + cPPsap_activity + "',";
				}
				else
				{
					SqlString = SqlString + "Null,";
				}
				SqlString = SqlString + "'" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + cPPlast_update_by + "','" + cPPpayroll_status_code + "'";

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

		public int UpdatePersonnelPayrollStatus(int lPayrollSysID)
		{
			//UpdatePersonnelPayroll  Status

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spUpdatePersonnelPayRollProcessFlag " + lPayrollSysID.ToString() + ",";
				SqlString = SqlString + "'" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + cPPlast_update_by + "','" + cPPpayroll_status_code + "'";

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

		public int GetAssociatedPersonnelPayRollRecord(int lSysID, string sFillerCode)
		{
			//Retrieve Records from PayrollTransfer table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_PersonnelPayRollAssociatedRecord " + lSysID.ToString() + ",'" + modGlobal.Clean(sFillerCode) + "' ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cPPFillerCodeId = Convert.ToString(oRec[0]);
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

		public int GetTimeCodeByKOT(string sKOT)
		{
			//Retrieve Record from Time_Code table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = " spSelectTimeCodeByKOT '" + sKOT + "' ";
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cTCtimecodesysid = Convert.ToInt32(oRec["timecode_sys_id"]);
					cTCtimecodeid = modGlobal.Clean(oRec["time_code_id"]);
					cTCdescription = modGlobal.Clean(oRec["description"]);
					cTCtimetypecode = modGlobal.Clean(oRec["time_type_code"]);
					cTCnotesavailable = Convert.ToByte(oRec["notes_available"]);
					cTCaatype = modGlobal.Clean(oRec["a_a_type"]);
					cTCaatype2 = modGlobal.Clean(oRec["a_a_type_2"]);
					cTCwagetype = modGlobal.Clean(oRec["wage_type"]);
					cTCfillercode = modGlobal.Clean(oRec["filler_code"]);
					cTCpensionlimit = Convert.ToByte(oRec["pension_limit"]);
					cTCactivitytype = modGlobal.Clean(oRec["activity_type"]);
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

		public int AddPayRollTransferForPayperiod(int SAPUserID, int CalendarYear, int PayPeriod)
		{
			//Insert Records into PayrollReconciliation table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spInsertPayrollTransferForPayperiod ";
				SqlString = SqlString + SAPUserID.ToString() + ", " + CalendarYear.ToString() + ", " + PayPeriod.ToString() + " ";
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

		public int AddPayRollTransferForDate(int SAPUserID, int CalendarYear, int PayPeriod, System.DateTime UpdateDate)
		{
			//Insert Records into PayrollReconciliation table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spInsertPayrollTransferForDate ";
				SqlString = SqlString + SAPUserID.ToString() + ", " + CalendarYear.ToString() + ", " + PayPeriod.ToString() + ", '" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(UpdateDate) + "' ";
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

		public int DeletePayrollTransferForUser(int lSAPUserID)
		{
			//Delete Records from PayrollTransfer table approved by
			//a specific User
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{
				result = -1;

				oCmd.Connection = modPTSPayroll.oPayroll;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spDelete_PayrollTransferForApprovedBy " + lSAPUserID.ToString();
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

		public int GetPayrollReconciliationReport(int SAPUserID, int CalendarYear, int PayPeriod)
		{
			//Retrieve Records from PayrollTransfer table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_PayrollSummaryError " + SAPUserID.ToString() + ", " + CalendarYear.ToString() + ", " + PayPeriod.ToString() + " ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cPayrollReconciliation = oRec;
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

		public int GetPayPeriodReconciliationErrors(int CalendarYear, int PayPeriod)
		{
			//Retrieve Records from PayrollTransfer table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_PayrollPayperiodError " + CalendarYear.ToString() + ", " + PayPeriod.ToString() + " ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cPayrollReconciliation = oRec;
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

		public int GetPayPeriodReconciliationSummary(int CalendarYear, int PayPeriod)
		{
			//Retrieve Records from PayrollTransfer table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_PayrollPayperiodSummary " + CalendarYear.ToString() + ", " + PayPeriod.ToString() + " ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cPayrollReconciliation = oRec;
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

		public int UpdatePersonnelPayrollForUpload(int lPayPeriod, int iYear, string sUpdateBy)
		{
			//UpdatePersonnelPayroll  Status

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spUpdatePersonnelPayRollForUpload " + lPayPeriod.ToString() + ", ";
				SqlString = SqlString + iYear.ToString() + ", '" + sUpdateBy + "' ";

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

		public int CheckForPreviousSAPInsert(int lSysID)
		{
			//Check to see if record ever had a successful SAP Insert
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_PreviousSAPInsert " + lSysID.ToString() + " ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (oRec.EOF)
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

		public int CheckPayRollStatus(int iYear, int iPayPeriod)
		{
			//Check to see if record ever had a successful SAP Insert
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_CheckPayrollStatus " + iYear.ToString() + ", " + iPayPeriod.ToString() + " ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (oRec.EOF)
				{
					result = 0;
				}
				else
				{
					cPayrollReconciliation = oRec;
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

		public int GetPersonnelPayRollSignOff(int iYear, int iPayPeriod, int lSAPEmpID)
		{
			//Retrieve Records from PersonnelPayRollSignOff table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_PersonnelPayRollSignOff " + iYear.ToString() + ", " + iPayPeriod.ToString() + ", " + lSAPEmpID.ToString() + " ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cPPSOpayroll_sys_id = Convert.ToInt32(oRec["signoff_id"]);
					cPPSOper_sys_id = Convert.ToInt32(oRec["sap_id"]);
					cPPSOcalendar_year = Convert.ToInt32(oRec["payperiod_year"]);
					cPPSOpay_period = Convert.ToInt32(oRec["pay_period"]);
					cPPSignOff_date = Convert.ToString(oRec["signoff_date"]);
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

		public int AddPersonnelPayRollSignOff()
		{
			//Insert Records into PersonnelPayRollSignOff table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spInsert_PersonnelPayrollSignOff ";
				SqlString = SqlString + cPPSOper_sys_id.ToString() + ", " + cPPSOcalendar_year.ToString() + ", " + cPPSOpay_period.ToString() + " ";
				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				//UPGRADE_WARNING: (2065) ADODB.Recordset method oRec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
				oRec = oRec.NextRecordSet();
				if (!oRec.EOF)
				{
					cPPSOpayroll_sys_id = Convert.ToInt32(oRec[0]);
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

		public int UpdatePersonnelPayRollSignOff()
		{
			//Update PersonnelPayRollSignOff Record

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spUpdate_PersonnelPayrollSignOff " + cPPSOpayroll_sys_id.ToString() + " ";
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

		public int GetSupervisorTCApproval(int iYear, int iPayPeriod, int lSAPEmpID)
		{
			//Retrieve Records from SupervisorTimecardApproval table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_SupervisorTimecardApproval " + iYear.ToString() + ", " + iPayPeriod.ToString() + ", " + lSAPEmpID.ToString() + " ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cSTCApprovalID = Convert.ToInt32(oRec["approve_id"]);
					cSTCApprovalcalendar_year = Convert.ToInt32(oRec["calendar_year"]);
					cSTCApprovalpay_period = Convert.ToInt32(oRec["pay_period"]);
					cSTCApprovalEmployee = Convert.ToInt32(oRec["employee_sap_id"]);
					cSTCApprovalSupervisor = Convert.ToInt32(oRec["suprv_sap_id"]);
					cSTCApprovaldate = Convert.ToString(oRec["approve_datetime"]);
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

		public int AddSupervisorTCApproval()
		{
			//Insert Records into SupervisorTimecardApproval table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spInsert_SupervisorTimeCardApproval ";
				SqlString = SqlString + cSTCApprovalcalendar_year.ToString() + ", " + cSTCApprovalpay_period.ToString() + ", " + cSTCApprovalEmployee.ToString() + ", " + cSTCApprovalSupervisor.ToString() + ", '" + cSTCApprovaldate + "' ";
				oCmd.CommandText = SqlString;

				oRec = ADORecordSetHelper.Open(oCmd, "");

				//UPGRADE_WARNING: (2065) ADODB.Recordset method oRec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
				oRec = oRec.NextRecordSet();
				if (!oRec.EOF)
				{
					cSTCApprovalID = Convert.ToInt32(oRec[0]);
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

		public int UpdateSupervisorTCApproval()
		{
			//Update SupervisorTimecardApproval Record

			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spUpdate_SupervisorTimecardApproval " + cSTCApprovalID.ToString() + ", " + cSTCApprovalSupervisor.ToString() + " ";
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

		public int GetEmployeePayrollSignOffReport(int SAPUserID)
		{
			//Retrieve Records from PersonnelPayrollSignOff for specific Employee
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spReport_PayrollSignOffByEmployee " + SAPUserID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cPPayrollSignOff = oRec;
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

		public int GetMurrayMorganPayrollHours(string sDate)
		{
			//Retrieve total payrolled hours related to Murray Morgan Bridge closure
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_MurrayMorganPayrollOT '" + sDate + "' ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cMurrayMorganWorkOrder = oRec;
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

		public int GetMurrayMorganScheduledOT(string sDate)
		{
			//Retrieve list of employees scheduled overtime related to Murray Morgan Bridge closure
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_MurrayMorganOTList '" + sDate + "' ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cMurrayMorganWorkOrder = oRec;
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

		public int GetMurrayMorganOTByEmpPayperiod(int lPersID, int iYear, int iPayPeriod)
		{
			//Retrieve list of Murray Morgan Records for specific employee / payperiod
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spSelect_MurrayMorganOTByEmployeePayperiod " + lPersID.ToString() + ", ";
				SqlString = SqlString + iYear.ToString() + ", " + iPayPeriod.ToString() + " ";
				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cMurrayMorganWorkOrder = oRec;
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

		public int GetMurrayMorganForEmpDate(int lPersID, string sDate)
		{
			//Retrieve list of Murray Morgan Records for specific employee / date
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "spSelect_MurrayMorganForEmpDate " + lPersID.ToString() + ", '";
				SqlString = SqlString + sDate + "' ";
				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cMurrayMorganWorkOrder = oRec;
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