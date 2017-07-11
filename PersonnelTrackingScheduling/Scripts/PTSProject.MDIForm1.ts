/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.MDIForm1", [ "files/text!views/PTSProject.MDIForm1.html", "files/css!views/PTSProject.MDIForm1.css"],
    (htmlTemplate) => {
    return class MDIForm1 extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("mnuPrintSetup_Click",this.mnuPrintSetup_Click);
this.bind("mnuExit_Click",this.mnuExit_Click);
this.bind("mnuAddnew_Click",this.mnuAddnew_Click);
this.bind("mnuEmpInfo_Click",this.mnuEmpInfo_Click);
this.bind("mnuPosition_Click",this.mnuPosition_Click);
this.bind("mnuPhone_Click",this.mnuPhone_Click);
this.bind("mnuAddress_Click",this.mnuAddress_Click);
this.bind("mnuEmergency_Click",this.mnuEmergency_Click);
this.bind("mnuImmune_Click",this.mnuImmune_Click);
this.bind("mnuPromoli_Click",this.mnuPromoli_Click);
this.bind("mnuSeniorInq_Click",this.mnuSeniorInq_Click);
this.bind("mnu_transfer_req_Click",this.mnu_transfer_req_Click);
this.bind("mnuPMCerts_Click",this.mnuPMCerts_Click);
this.bind("mnuPPE_Click",this.mnuPPE_Click);
this.bind("mnuIndSchedule_Click",this.mnuIndSchedule_Click);
this.bind("mnuBattalion_Click",this.mnuBattalion_Click);
this.bind("mnuBattalion2_Click",this.mnuBattalion2_Click);
this.bind("mnuNewBatt3_Click",this.mnuNewBatt3_Click);
this.bind("mnuBattalion3_Click",this.mnuBattalion3_Click);
this.bind("mnuBattalion4_Click",this.mnuBattalion4_Click);
this.bind("mnuEMS_Click",this.mnuEMS_Click);
this.bind("mnuEMSDaily_Click",this.mnuEMSDaily_Click);
this.bind("mnuHazmat_Click",this.mnuHazmat_Click);
this.bind("mnuMarine_Click",this.mnuMarine_Click);
this.bind("mnuBattStaff_Click",this.mnuBattStaff_Click);
this.bind("mnuDispatch_Click",this.mnuDispatch_Click);
this.bind("mnu_watch_duty_Click",this.mnu_watch_duty_Click);
this.bind("mnu_Vacation_Click",this.mnu_Vacation_Click);
this.bind("mnu_PMVacationSched_Click",this.mnu_PMVacationSched_Click);
this.bind("mnu_HZMVacationSched_Click",this.mnu_HZMVacationSched_Click);
this.bind("mnu_FCCVacationSched_Click",this.mnu_FCCVacationSched_Click);
this.bind("mnuNewBatt1_Click",this.mnuNewBatt1_Click);
this.bind("mnuNewBatt2_Click",this.mnuNewBatt2_Click);
this.bind("mnuAssign_Click",this.mnuAssign_Click);
this.bind("mnuRoster_Click",this.mnuRoster_Click);
this.bind("mnuFRoster_Click",this.mnuFRoster_Click);
this.bind("mnuPublicRoster_Click",this.mnuPublicRoster_Click);
this.bind("mnu_DDGroups_Click",this.mnu_DDGroups_Click);
this.bind("mnuProlist_Click",this.mnuProlist_Click);
this.bind("mnuSenior_Click",this.mnuSenior_Click);
this.bind("mnuBenefit_Click",this.mnuBenefit_Click);
this.bind("mnu_rankedops_Click",this.mnu_rankedops_Click);
this.bind("mnu_emp_facility_Click",this.mnu_emp_facility_Click);
this.bind("MnuAuditDDHOL_Click",this.MnuAuditDDHOL_Click);
this.bind("mnu_IndivPayrollSO_Click",this.mnu_IndivPayrollSO_Click);
this.bind("mnuIndTimeCard2_Click",this.mnuIndTimeCard2_Click);
this.bind("mnuPhoneList_Click",this.mnuPhoneList_Click);
this.bind("mnu181_Click",this.mnu181_Click);
this.bind("mnu182_Click",this.mnu182_Click);
this.bind("mnu183_Click",this.mnu183_Click);
this.bind("mnuEMSWeekly_Click",this.mnuEMSWeekly_Click);
this.bind("mnuHZMWeekly_Click",this.mnuHZMWeekly_Click);
this.bind("mnuMRNWeekly_Click",this.mnuMRNWeekly_Click);
this.bind("mnuBatWeekly_Click",this.mnuBatWeekly_Click);
this.bind("mnuDispWeekly_Click",this.mnuDispWeekly_Click);
this.bind("mnuIndYearSched_Click",this.mnuIndYearSched_Click);
this.bind("mnuDailyStaffing_Click",this.mnuDailyStaffing_Click);
this.bind("mnuOvertime_Click",this.mnuOvertime_Click);
this.bind("mnuExtraOff_Click",this.mnuExtraOff_Click);
this.bind("mnu_sa_report_Click",this.mnu_sa_report_Click);
this.bind("mnuCalendar_Click",this.mnuCalendar_Click);
this.bind("mnuTransfer_Click",this.mnuTransfer_Click);
this.bind("mnu_daily_Click",this.mnu_daily_Click);
this.bind("mnu_Annual_Click",this.mnu_Annual_Click);
this.bind("mnu_dailysickleave_Click",this.mnu_dailysickleave_Click);
this.bind("mnu_Individual_Click",this.mnu_Individual_Click);
this.bind("mnu_sick_usage_Click",this.mnu_sick_usage_Click);
this.bind("mnu_PMLeave_Click",this.mnu_PMLeave_Click);
this.bind("mnuDispatchLeave_Click",this.mnuDispatchLeave_Click);
this.bind("mnu_HZMLeave_Click",this.mnu_HZMLeave_Click);
this.bind("mnuCBStaffing_Click",this.mnuCBStaffing_Click);
this.bind("mnu_LeaveNoSched_Click",this.mnu_LeaveNoSched_Click);
this.bind("mnuInsteadOfSCKLeave_Click",this.mnuInsteadOfSCKLeave_Click);
this.bind("mnu_staffdiscrepancy_Click",this.mnu_staffdiscrepancy_Click);
this.bind("mnu_PMCSRCalc_Click",this.mnu_PMCSRCalc_Click);
this.bind("mnu_EmpNotes_Click",this.mnu_EmpNotes_Click);
this.bind("mnu_SchedNotes_Click",this.mnu_SchedNotes_Click);
this.bind("mnuCycleHrs_Click",this.mnuCycleHrs_Click);
this.bind("mnu_PPEQuery_Click",this.mnu_PPEQuery_Click);
this.bind("mnuPPAudit_Click",this.mnuPPAudit_Click);
this.bind("mnuTimeCard_Click",this.mnuTimeCard_Click);
this.bind("mnuIndAnnualPayroll_Click",this.mnuIndAnnualPayroll_Click);
this.bind("mnu_personnelsignoff_Click",this.mnu_personnelsignoff_Click);
this.bind("mnu_BCApprovedTC_Click",this.mnu_BCApprovedTC_Click);
this.bind("mnu_QuarterlyMinimumDrill_Click",this.mnu_QuarterlyMinimumDrill_Click);
this.bind("mnu_FCCMinDrills_Click",this.mnu_FCCMinDrills_Click);
this.bind("mnu_ReadingAssign_Click",this.mnu_ReadingAssign_Click);
this.bind("mnu_OTEPReport_Click",this.mnu_OTEPReport_Click);
this.bind("mnu_PMRecertReport_Click",this.mnu_PMRecertReport_Click);
this.bind("mnu_PMBaseStaReport_Click",this.mnu_PMBaseStaReport_Click);
this.bind("mnu_TrainingQuerynew_Click",this.mnu_TrainingQuerynew_Click);
this.bind("mnu_trainingtracker_Click",this.mnu_trainingtracker_Click);
this.bind("mnu_IndTrainReport_Click",this.mnu_IndTrainReport_Click);
this.bind("mnu_IndPMRecert_Click",this.mnu_IndPMRecert_Click);
this.bind("mnuALSProc_Click",this.mnuALSProc_Click);
this.bind("mnu_TrainingQueryTool_Click",this.mnu_TrainingQueryTool_Click);
this.bind("mnuNewTrainQuery_Click",this.mnuNewTrainQuery_Click);
this.bind("mnuTrainQuery_Click",this.mnuTrainQuery_Click);
this.bind("mnuReviewPay_Click",this.mnuReviewPay_Click);
this.bind("mnuIndTimeCard_Click",this.mnuIndTimeCard_Click);
this.bind("mnu_ReportPayroll_Click",this.mnu_ReportPayroll_Click);
this.bind("mnuOtherPayroll_Click",this.mnuOtherPayroll_Click);
this.bind("mnuResource_Click",this.mnuResource_Click);
this.bind("mnuPersonnelCodes_Click",this.mnuPersonnelCodes_Click);
this.bind("mnuMakeNewSched_Click",this.mnuMakeNewSched_Click);
this.bind("mnuSecure_Click",this.mnuSecure_Click);
this.bind("mnuCascade_Click",this.mnuCascade_Click);
this.bind("mnuPrintScreen_Click",this.mnuPrintScreen_Click);
this.bind("mnuCon_Click",this.mnuCon_Click);
this.bind("mnuAbout_Click",this.mnuAbout_Click);
this.bind("mnu_HelpPrntScrn_Click",this.mnu_HelpPrntScrn_Click);
this.bind("mnu_timecodes_Click",this.mnu_timecodes_Click);
this.bind("mnu_payrolllegend_Click",this.mnu_payrolllegend_Click);
this.bind("mnu_legend_Click",this.mnu_legend_Click);
this.bind("mnu_IndLegend_Click",this.mnu_IndLegend_Click);
this.bind("mnu_payup_calc_Click",this.mnu_payup_calc_Click);
this.bind("mnuTrainCodeHelp_Click",this.mnuTrainCodeHelp_Click);
this.bind("mnuCalendarHelp_Click",this.mnuCalendarHelp_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "MDIForm1";
            }

            public loaded() {
			
            }

        

        public MDIForm1_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"MDIForm1",action:"MDIForm1_Close"});
                e.preventDefault();
            }
            
        }
        public mnuPrintSetup_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuExit_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuAddnew_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuEmpInfo_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuPosition_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuPhone_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuAddress_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuEmergency_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuImmune_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuPromoli_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuSeniorInq_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_transfer_req_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuPMCerts_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuPPE_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuIndSchedule_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuBattalion_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuBattalion2_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuNewBatt3_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuBattalion3_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuBattalion4_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuEMS_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuEMSDaily_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuHazmat_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuMarine_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuBattStaff_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuDispatch_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_watch_duty_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_Vacation_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_PMVacationSched_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_HZMVacationSched_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_FCCVacationSched_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuNewBatt1_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuNewBatt2_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuAssign_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuRoster_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuFRoster_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuPublicRoster_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_DDGroups_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuProlist_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuSenior_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuBenefit_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_rankedops_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_emp_facility_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public MnuAuditDDHOL_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_IndivPayrollSO_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuIndTimeCard2_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuPhoneList_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu181_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu182_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu183_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuEMSWeekly_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuHZMWeekly_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuMRNWeekly_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuBatWeekly_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuDispWeekly_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuIndYearSched_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuDailyStaffing_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuOvertime_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuExtraOff_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_sa_report_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuCalendar_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuTransfer_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_daily_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_Annual_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_dailysickleave_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_Individual_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_sick_usage_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_PMLeave_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuDispatchLeave_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_HZMLeave_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuCBStaffing_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_LeaveNoSched_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuInsteadOfSCKLeave_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_staffdiscrepancy_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_PMCSRCalc_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_EmpNotes_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_SchedNotes_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuCycleHrs_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_PPEQuery_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuPPAudit_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuTimeCard_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuIndAnnualPayroll_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_personnelsignoff_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_BCApprovedTC_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_QuarterlyMinimumDrill_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_FCCMinDrills_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_ReadingAssign_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_OTEPReport_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_PMRecertReport_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_PMBaseStaReport_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_TrainingQuerynew_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_trainingtracker_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_IndTrainReport_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_IndPMRecert_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuALSProc_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_TrainingQueryTool_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuNewTrainQuery_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuTrainQuery_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuReviewPay_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuIndTimeCard_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_ReportPayroll_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuOtherPayroll_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuResource_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuPersonnelCodes_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuMakeNewSched_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuSecure_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuCascade_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuPrintScreen_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuCon_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuAbout_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_HelpPrntScrn_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_timecodes_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_payrolllegend_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_legend_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_IndLegend_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_payup_calc_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuTrainCodeHelp_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuCalendarHelp_Click(sender: MDIForm1, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

