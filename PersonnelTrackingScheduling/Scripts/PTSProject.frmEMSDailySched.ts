/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmEMSDailySched", [ "files/text!views/PTSProject.frmEMSDailySched.html", "files/css!views/PTSProject.frmEMSDailySched.css","usercontrols/UpgradeHelpers_Gui_ShapeHelper"],
    (htmlTemplate) => {
    return class frmEMSDailySched extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("frmEMSDailySched_Activated",this.frmEMSDailySched_Activated);
this.bind("frmEMSDailySched_Deactivate",this.frmEMSDailySched_Deactivate);
this.bind("mnuPrintPayPeriodReport_Click",this.mnuPrintPayPeriodReport_Click);
this.bind("mnuClose_Click",this.mnuClose_Click);
this.bind("mnuEmpInfo_Click",this.mnuEmpInfo_Click);
this.bind("mnuSeniorityInq_Click",this.mnuSeniorityInq_Click);
this.bind("mnuImmune_Click",this.mnuImmune_Click);
this.bind("mnu_transfer_req_Click",this.mnu_transfer_req_Click);
this.bind("mnuPPE_Click",this.mnuPPE_Click);
this.bind("mnuIndSchedule_Click",this.mnuIndSchedule_Click);
this.bind("mnuBattalion1_Click",this.mnuBattalion1_Click);
this.bind("mnuBattalion2_Click",this.mnuBattalion2_Click);
this.bind("mnuNewBatt3_Click",this.mnuNewBatt3_Click);
this.bind("mnuBattalion3_Click",this.mnuBattalion3_Click);
this.bind("mnuBattalion4_Click",this.mnuBattalion4_Click);
this.bind("mnuEMS_Click",this.mnuEMS_Click);
this.bind("mnuHazmat_Click",this.mnuHazmat_Click);
this.bind("mnuMarine_Click",this.mnuMarine_Click);
this.bind("mnuBattStaff_Click",this.mnuBattStaff_Click);
this.bind("mnuDispatch_Click",this.mnuDispatch_Click);
this.bind("mnu_watch_duty_Click",this.mnu_watch_duty_Click);
this.bind("mnu_Vacation_Click",this.mnu_Vacation_Click);
this.bind("mnu_PMVacationSched_Click",this.mnu_PMVacationSched_Click);
this.bind("mnuAssign_Click",this.mnuAssign_Click);
this.bind("mnuRoster_Click",this.mnuRoster_Click);
this.bind("mnu_DDGroups_Click",this.mnu_DDGroups_Click);
this.bind("mnuProlist_Click",this.mnuProlist_Click);
this.bind("mnuSenior_Click",this.mnuSenior_Click);
this.bind("mnuBenefit_Click",this.mnuBenefit_Click);
this.bind("mnu_emp_facility_Click",this.mnu_emp_facility_Click);
this.bind("mnu_IndivPayrollSO_Click",this.mnu_IndivPayrollSO_Click);
this.bind("mnuIndTimeCard2_Click",this.mnuIndTimeCard2_Click);
this.bind("mnu181_Click",this.mnu181_Click);
this.bind("mnu182_Click",this.mnu182_Click);
this.bind("mnu183_Click",this.mnu183_Click);
this.bind("mnuEMSPay_Click",this.mnuEMSPay_Click);
this.bind("mnuHazPay_Click",this.mnuHazPay_Click);
this.bind("mnuMarPay_Click",this.mnuMarPay_Click);
this.bind("mnuBattPay_Click",this.mnuBattPay_Click);
this.bind("mnuDisPay_Click",this.mnuDisPay_Click);
this.bind("mnuIndTimeCard_Click",this.mnuIndTimeCard_Click);
this.bind("mnuIndYearSched_Click",this.mnuIndYearSched_Click);
this.bind("mnuDailyStaff_Click",this.mnuDailyStaff_Click);
this.bind("mnuOvertime_Click",this.mnuOvertime_Click);
this.bind("mnu_sa_report_Click",this.mnu_sa_report_Click);
this.bind("mnuShiftCal_Click",this.mnuShiftCal_Click);
this.bind("mnuTransfer_Click",this.mnuTransfer_Click);
this.bind("mnuDailyLeave_Click",this.mnuDailyLeave_Click);
this.bind("mnuAnnual_Click",this.mnuAnnual_Click);
this.bind("mnu_dailysickleave_Click",this.mnu_dailysickleave_Click);
this.bind("mnuIndLeave_Click",this.mnuIndLeave_Click);
this.bind("mnu_PMLeave_Click",this.mnu_PMLeave_Click);
this.bind("mnuDispatchLeave_Click",this.mnuDispatchLeave_Click);
this.bind("mnutimecard_Click",this.mnutimecard_Click);
this.bind("mnuindannualpayroll_Click",this.mnuindannualpayroll_Click);
this.bind("mnupersonnelsignoff_Click",this.mnupersonnelsignoff_Click);
this.bind("mnu_QuarterlyMinimumDrill_Click",this.mnu_QuarterlyMinimumDrill_Click);
this.bind("mnu_ReadingAssign_Click",this.mnu_ReadingAssign_Click);
this.bind("mnu_OTEPReport_Click",this.mnu_OTEPReport_Click);
this.bind("mnu_PMRecertReport_Click",this.mnu_PMRecertReport_Click);
this.bind("mnu_trainingtracker_Click",this.mnu_trainingtracker_Click);
this.bind("mnu_IndTrainReport_Click",this.mnu_IndTrainReport_Click);
this.bind("mnu_IndPMRecert_Click",this.mnu_IndPMRecert_Click);
this.bind("mnuTrainQuery_Click",this.mnuTrainQuery_Click);
this.bind("mnu_TrainingQuerynew_Click",this.mnu_TrainingQuerynew_Click);
this.bind("mnuCascade_Click",this.mnuCascade_Click);
this.bind("mnuPrintScreen_Click",this.mnuPrintScreen_Click);
this.bind("mnuAbout_Click",this.mnuAbout_Click);
this.bind("mnu_timecodes_Click",this.mnu_timecodes_Click);
this.bind("mnu_payrolllegend_Click",this.mnu_payrolllegend_Click);
this.bind("mnu_legend_Click",this.mnu_legend_Click);
this.bind("mnu_IndLegend_Click",this.mnu_IndLegend_Click);
this.bind("mnu_payup_calc_Click",this.mnu_payup_calc_Click);
this.bind("mnuTrainCodeHelp_Click",this.mnuTrainCodeHelp_Click);
this.bind("mnuNewSched_Click",this.mnuNewSched_Click);
this.bind("mnuLeave_Click",this.mnuLeave_Click);
this.bind("mnuPayUp_Click",this.mnuPayUp_Click);
this.bind("mnuPayDown_Click",this.mnuPayDown_Click);
this.bind("mnuKOT_Click",this.mnuKOT_Click);
this.bind("mnuRemove_Click",this.mnuRemove_Click);
this.bind("mnuSendTo181_Click",this.mnuSendTo181_Click);
this.bind("mnuSendTo182_Click",this.mnuSendTo182_Click);
this.bind("mnuSendTo183_Click",this.mnuSendTo183_Click);
this.bind("mnu_viewtimecard_Click",this.mnu_viewtimecard_Click);
this.bind("mnuReport_Click",this.mnuReport_Click);
this.bind("mnuViewDetail_Click",this.mnuViewDetail_Click);
this.bind("Ctx_mnuEMSPopup_Closing",this.Ctx_mnuEMSPopup_Closing);
this.bind("Ctx_mnuEMSPopup_Opening",this.Ctx_mnuEMSPopup_Opening);
this.bind("calSchedDate_Click",this.calSchedDate_Click);
this.bind("pnSelected_MouseDown",this.pnSelected_MouseDown);
this.bind("cboSelectName_SelectionChangeCommitted",this.cboSelectName_SelectionChangeCommitted);
this.bind("lbPosam_DragDrop",this.lbPosam_DragDrop);
this.bind("lbPosam_DragOver",this.lbPosam_DragOver);
this.bind("_lbPosam_36_MouseDown",this._lbPosam_36_MouseDown);
this.bind("_lbPosam_0_MouseDown",this._lbPosam_0_MouseDown);
this.bind("_lbPosam_4_MouseDown",this._lbPosam_4_MouseDown);
this.bind("_lbPosam_8_MouseDown",this._lbPosam_8_MouseDown);
this.bind("_lbPosam_12_MouseDown",this._lbPosam_12_MouseDown);
this.bind("_lbPosam_16_MouseDown",this._lbPosam_16_MouseDown);
this.bind("lbPospm_DragDrop",this.lbPospm_DragDrop);
this.bind("lbPospm_DragOver",this.lbPospm_DragOver);
this.bind("_lbPospm_36_MouseDown",this._lbPospm_36_MouseDown);
this.bind("_lbPospm_0_MouseDown",this._lbPospm_0_MouseDown);
this.bind("_lbPospm_4_MouseDown",this._lbPospm_4_MouseDown);
this.bind("_lbPospm_8_MouseDown",this._lbPospm_8_MouseDown);
this.bind("_lbPospm_12_MouseDown",this._lbPospm_12_MouseDown);
this.bind("_lbPospm_16_MouseDown",this._lbPospm_16_MouseDown);
this.bind("_lbPosam_37_MouseDown",this._lbPosam_37_MouseDown);
this.bind("_lbPosam_1_MouseDown",this._lbPosam_1_MouseDown);
this.bind("_lbPosam_5_MouseDown",this._lbPosam_5_MouseDown);
this.bind("_lbPosam_9_MouseDown",this._lbPosam_9_MouseDown);
this.bind("_lbPosam_13_MouseDown",this._lbPosam_13_MouseDown);
this.bind("_lbPosam_17_MouseDown",this._lbPosam_17_MouseDown);
this.bind("_lbPospm_37_MouseDown",this._lbPospm_37_MouseDown);
this.bind("_lbPospm_1_MouseDown",this._lbPospm_1_MouseDown);
this.bind("_lbPospm_5_MouseDown",this._lbPospm_5_MouseDown);
this.bind("_lbPospm_9_MouseDown",this._lbPospm_9_MouseDown);
this.bind("_lbPospm_13_MouseDown",this._lbPospm_13_MouseDown);
this.bind("_lbPospm_17_MouseDown",this._lbPospm_17_MouseDown);
this.bind("_lbPosam_38_MouseDown",this._lbPosam_38_MouseDown);
this.bind("_lbPosam_2_MouseDown",this._lbPosam_2_MouseDown);
this.bind("_lbPosam_6_MouseDown",this._lbPosam_6_MouseDown);
this.bind("_lbPosam_10_MouseDown",this._lbPosam_10_MouseDown);
this.bind("_lbPosam_14_MouseDown",this._lbPosam_14_MouseDown);
this.bind("_lbPosam_18_MouseDown",this._lbPosam_18_MouseDown);
this.bind("_lbPospm_38_MouseDown",this._lbPospm_38_MouseDown);
this.bind("_lbPospm_2_MouseDown",this._lbPospm_2_MouseDown);
this.bind("_lbPospm_6_MouseDown",this._lbPospm_6_MouseDown);
this.bind("_lbPospm_10_MouseDown",this._lbPospm_10_MouseDown);
this.bind("_lbPospm_14_MouseDown",this._lbPospm_14_MouseDown);
this.bind("_lbPospm_18_MouseDown",this._lbPospm_18_MouseDown);
this.bind("_lbPosam_39_MouseDown",this._lbPosam_39_MouseDown);
this.bind("_lbPosam_3_MouseDown",this._lbPosam_3_MouseDown);
this.bind("_lbPosam_7_MouseDown",this._lbPosam_7_MouseDown);
this.bind("_lbPosam_11_MouseDown",this._lbPosam_11_MouseDown);
this.bind("_lbPosam_15_MouseDown",this._lbPosam_15_MouseDown);
this.bind("_lbPosam_19_MouseDown",this._lbPosam_19_MouseDown);
this.bind("_lbPospm_39_MouseDown",this._lbPospm_39_MouseDown);
this.bind("_lbPospm_3_MouseDown",this._lbPospm_3_MouseDown);
this.bind("_lbPospm_7_MouseDown",this._lbPospm_7_MouseDown);
this.bind("_lbPospm_15_MouseDown",this._lbPospm_15_MouseDown);
this.bind("_lbPospm_19_MouseDown",this._lbPospm_19_MouseDown);
this.bind("_lbPospm_11_MouseDown",this._lbPospm_11_MouseDown);
this.bind("_lbPosam_20_MouseDown",this._lbPosam_20_MouseDown);
this.bind("_lbPosam_24_MouseDown",this._lbPosam_24_MouseDown);
this.bind("_lbPosam_28_MouseDown",this._lbPosam_28_MouseDown);
this.bind("_lbPosam_32_MouseDown",this._lbPosam_32_MouseDown);
this.bind("_lbPospm_20_MouseDown",this._lbPospm_20_MouseDown);
this.bind("_lbPospm_24_MouseDown",this._lbPospm_24_MouseDown);
this.bind("_lbPospm_28_MouseDown",this._lbPospm_28_MouseDown);
this.bind("_lbPospm_32_MouseDown",this._lbPospm_32_MouseDown);
this.bind("_lbPosam_21_MouseDown",this._lbPosam_21_MouseDown);
this.bind("_lbPosam_25_MouseDown",this._lbPosam_25_MouseDown);
this.bind("_lbPosam_29_MouseDown",this._lbPosam_29_MouseDown);
this.bind("_lbPosam_33_MouseDown",this._lbPosam_33_MouseDown);
this.bind("_lbPospm_21_MouseDown",this._lbPospm_21_MouseDown);
this.bind("_lbPospm_25_MouseDown",this._lbPospm_25_MouseDown);
this.bind("_lbPospm_29_MouseDown",this._lbPospm_29_MouseDown);
this.bind("_lbPospm_33_MouseDown",this._lbPospm_33_MouseDown);
this.bind("_lbPosam_22_MouseDown",this._lbPosam_22_MouseDown);
this.bind("_lbPosam_26_MouseDown",this._lbPosam_26_MouseDown);
this.bind("_lbPosam_30_MouseDown",this._lbPosam_30_MouseDown);
this.bind("_lbPosam_34_MouseDown",this._lbPosam_34_MouseDown);
this.bind("_lbPospm_22_MouseDown",this._lbPospm_22_MouseDown);
this.bind("_lbPospm_26_MouseDown",this._lbPospm_26_MouseDown);
this.bind("_lbPospm_30_MouseDown",this._lbPospm_30_MouseDown);
this.bind("_lbPospm_34_MouseDown",this._lbPospm_34_MouseDown);
this.bind("_lbPosam_23_MouseDown",this._lbPosam_23_MouseDown);
this.bind("_lbPosam_27_MouseDown",this._lbPosam_27_MouseDown);
this.bind("_lbPosam_31_MouseDown",this._lbPosam_31_MouseDown);
this.bind("_lbPosam_35_MouseDown",this._lbPosam_35_MouseDown);
this.bind("_lbPospm_23_MouseDown",this._lbPospm_23_MouseDown);
this.bind("_lbPospm_27_MouseDown",this._lbPospm_27_MouseDown);
this.bind("_lbPospm_31_MouseDown",this._lbPospm_31_MouseDown);
this.bind("_lbPospm_35_MouseDown",this._lbPospm_35_MouseDown);
this.bind("picTrash_DragDrop",this.picTrash_DragDrop);
this.bind("picTrash_DragOver",this.picTrash_DragOver);
this.bind("cmdPayroll_Click",this.cmdPayroll_Click);
this.bind("cmdReport_Click",this.cmdReport_Click);
this.bind("cmdRefresh_Click",this.cmdRefresh_Click);
this.bind("cmdClose_Click",this.cmdClose_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmEMSDailySched";
            }

            public loaded() {

            }

        
        public frmEMSDailySched_Activated(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

        public frmEMSDailySched_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmEMSDailySched",action:"frmEMSDailySched_Close"});
                e.preventDefault();
            }
            
        }
        public frmEMSDailySched_Deactivate(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuPrintPayPeriodReport_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuClose_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuEmpInfo_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuSeniorityInq_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuImmune_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_transfer_req_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuPPE_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuIndSchedule_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuBattalion1_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuBattalion2_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuNewBatt3_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuBattalion3_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuBattalion4_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuEMS_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuHazmat_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuMarine_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuBattStaff_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuDispatch_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_watch_duty_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_Vacation_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_PMVacationSched_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuAssign_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuRoster_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_DDGroups_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuProlist_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuSenior_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuBenefit_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_emp_facility_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_IndivPayrollSO_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuIndTimeCard2_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu181_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu182_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu183_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuEMSPay_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuHazPay_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuMarPay_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuBattPay_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuDisPay_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuIndTimeCard_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuIndYearSched_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuDailyStaff_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuOvertime_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_sa_report_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuShiftCal_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuTransfer_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuDailyLeave_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuAnnual_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_dailysickleave_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuIndLeave_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_PMLeave_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuDispatchLeave_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnutimecard_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuindannualpayroll_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnupersonnelsignoff_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_QuarterlyMinimumDrill_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_ReadingAssign_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_OTEPReport_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_PMRecertReport_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_trainingtracker_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_IndTrainReport_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_IndPMRecert_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuTrainQuery_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_TrainingQuerynew_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuCascade_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuPrintScreen_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuAbout_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_timecodes_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_payrolllegend_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_legend_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_IndLegend_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_payup_calc_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuTrainCodeHelp_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuNewSched_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuLeave_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuPayUp_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuPayDown_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuKOT_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuRemove_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuSendTo181_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuSendTo182_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuSendTo183_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_viewtimecard_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuReport_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuViewDetail_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public Ctx_mnuEMSPopup_Closing(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public Ctx_mnuEMSPopup_Opening(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public calSchedDate_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public pnSelected_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null ,() => {(window as any).app.disableLoading = false;}));            

        }
        public cboSelectName_SelectionChangeCommitted(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public lbPosam_DragDrop(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { 'objectForId': e.ControlUID, "index": $(e.srcElement || e.targetElement || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));            

        }
        public lbPosam_DragOver(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public _lbPosam_36_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_0_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_4_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_8_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_12_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_16_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPospm_DragDrop(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { 'objectForId': e.ControlUID, "index": $(e.srcElement || e.targetElement || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));           

        }
        public lbPospm_DragOver(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public _lbPospm_36_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_0_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_4_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_8_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_12_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_16_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_37_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_1_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_5_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_9_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_13_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_17_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_37_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_1_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_5_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_9_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_13_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_17_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_38_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_2_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_6_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_10_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_14_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_18_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_38_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_2_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_6_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_10_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_14_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_18_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_39_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_3_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_7_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_11_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_15_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_19_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_39_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_3_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_7_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_15_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_19_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_11_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
            public loadSpread(name: string) {
                var uniqueId = this.model.UniqueID;
                require(["spread"], (spread) => {
                    spread(name, uniqueId);
                });
            }
        public _lbPosam_20_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_24_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_28_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_32_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_20_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_24_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_28_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_32_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_21_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_25_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_29_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_33_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_21_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_25_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_29_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_33_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_22_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_26_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_30_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_34_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_22_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_26_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_30_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_34_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_23_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_27_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_31_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_35_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_23_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_27_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_31_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_35_MouseDown(sender: frmEMSDailySched, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public picTrash_DragDrop(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID}));            

        }
        public picTrash_DragOver(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID}));            

        }
        public cmdPayroll_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdReport_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdRefresh_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmEMSDailySched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

