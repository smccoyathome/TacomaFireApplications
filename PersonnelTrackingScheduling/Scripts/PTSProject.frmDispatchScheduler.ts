/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmDispatchScheduler", [ "files/text!views/PTSProject.frmDispatchScheduler.html", "files/css!views/PTSProject.frmDispatchScheduler.css","usercontrols/UpgradeHelpers_Gui_ShapeHelper"],
    (htmlTemplate) => {
    return class frmDispatchScheduler extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("frmDispatchScheduler_Activated",this.frmDispatchScheduler_Activated);
this.bind("frmDispatchScheduler_Deactivate",this.frmDispatchScheduler_Deactivate);
this.bind("mnuPrintPayReport_Click",this.mnuPrintPayReport_Click);
this.bind("mnuClose_Click",this.mnuClose_Click);
this.bind("mnuEmpInfo_Click",this.mnuEmpInfo_Click);
this.bind("mnuSeniorInq_Click",this.mnuSeniorInq_Click);
this.bind("mnuImmune_Click",this.mnuImmune_Click);
this.bind("mnu_transfer_req_Click",this.mnu_transfer_req_Click);
this.bind("mnuPMCerts_Click",this.mnuPMCerts_Click);
this.bind("mnuPPE_Click",this.mnuPPE_Click);
this.bind("mnuIndSchedule_Click",this.mnuIndSchedule_Click);
this.bind("mnuBattalion1_Click",this.mnuBattalion1_Click);
this.bind("mnuBattalion2_Click",this.mnuBattalion2_Click);
this.bind("mnuNewBatt3_Click",this.mnuNewBatt3_Click);
this.bind("mnuBattalion3_Click",this.mnuBattalion3_Click);
this.bind("mnuBattalion4_Click",this.mnuBattalion4_Click);
this.bind("mnuEMS_Click",this.mnuEMS_Click);
this.bind("mnuEMSDaily_Click",this.mnuEMSDaily_Click);
this.bind("mnu_watch_duty_Click",this.mnu_watch_duty_Click);
this.bind("mnu_Vacation_Click",this.mnu_Vacation_Click);
this.bind("mnu_PMVacationSched_Click",this.mnu_PMVacationSched_Click);
this.bind("mnu_FCCVacationSched_Click",this.mnu_FCCVacationSched_Click);
this.bind("mnuAssign_Click",this.mnuAssign_Click);
this.bind("mnuRoster_Click",this.mnuRoster_Click);
this.bind("mnu_DDGroups_Click",this.mnu_DDGroups_Click);
this.bind("mnuProlist_Click",this.mnuProlist_Click);
this.bind("mnuBenefit_Click",this.mnuBenefit_Click);
this.bind("mnu_emp_facility_Click",this.mnu_emp_facility_Click);
this.bind("mnuAuditDDHOL_Click",this.mnuAuditDDHOL_Click);
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
this.bind("mnuExtraOff_Click",this.mnuExtraOff_Click);
this.bind("mnu_sa_report_Click",this.mnu_sa_report_Click);
this.bind("mnuShiftCal_Click",this.mnuShiftCal_Click);
this.bind("mnuTransfer_Click",this.mnuTransfer_Click);
this.bind("mnuDailyLeave_Click",this.mnuDailyLeave_Click);
this.bind("mnuAnnual_Click",this.mnuAnnual_Click);
this.bind("mnu_dailysickleave_Click",this.mnu_dailysickleave_Click);
this.bind("mnuIndLeave_Click",this.mnuIndLeave_Click);
this.bind("mnu_sick_usage_Click",this.mnu_sick_usage_Click);
this.bind("mnu_PMLeave_Click",this.mnu_PMLeave_Click);
this.bind("mnuDispatchLeave_Click",this.mnuDispatchLeave_Click);
this.bind("mnutimecard_Click",this.mnutimecard_Click);
this.bind("mnuIndAnnualPayroll_Click",this.mnuIndAnnualPayroll_Click);
this.bind("mnupersonnelsignoff_Click",this.mnupersonnelsignoff_Click);
this.bind("mnu_QuarterlyMinimumDrill_Click",this.mnu_QuarterlyMinimumDrill_Click);
this.bind("mnu_FCCMinDrills_Click",this.mnu_FCCMinDrills_Click);
this.bind("mnu_ReadingAssign_Click",this.mnu_ReadingAssign_Click);
this.bind("mnu_OTEPReport_Click",this.mnu_OTEPReport_Click);
this.bind("mnu_PMRecertReport_Click",this.mnu_PMRecertReport_Click);
this.bind("mnu_PMBaseStaReport_Click",this.mnu_PMBaseStaReport_Click);
this.bind("mnu_trainingtracker_Click",this.mnu_trainingtracker_Click);
this.bind("mnu_IndTrainReport_Click",this.mnu_IndTrainReport_Click);
this.bind("mnu_IndPMRecert_Click",this.mnu_IndPMRecert_Click);
this.bind("mnuALSProc_Click",this.mnuALSProc_Click);
this.bind("mnuTrainQuery_Click",this.mnuTrainQuery_Click);
this.bind("mnu_TrainingQuerynew_Click",this.mnu_TrainingQuerynew_Click);
this.bind("mnuCascade_Click",this.mnuCascade_Click);
this.bind("mnuPrintScreen_Click",this.mnuPrintScreen_Click);
this.bind("mnuAbout_Click",this.mnuAbout_Click);
this.bind("mnu_HelpPrntScrn_Click",this.mnu_HelpPrntScrn_Click);
this.bind("mnu_timecodes_Click",this.mnu_timecodes_Click);
this.bind("mnu_payrolllegend_Click",this.mnu_payrolllegend_Click);
this.bind("mnu_legend_Click",this.mnu_legend_Click);
this.bind("mnu_IndLegend_Click",this.mnu_IndLegend_Click);
this.bind("mnu_payup_calc_Click",this.mnu_payup_calc_Click);
this.bind("mnuTrainCodeHelp_Click",this.mnuTrainCodeHelp_Click);
this.bind("mnuLeave_Click",this.mnuLeave_Click);
this.bind("mnuPayUp_Click",this.mnuPayUp_Click);
this.bind("mnuPayDown_Click",this.mnuPayDown_Click);
this.bind("mnuKOT_Click",this.mnuKOT_Click);
this.bind("mnuTrade_Click",this.mnuTrade_Click);
this.bind("mnuRemove_Click",this.mnuRemove_Click);
this.bind("mnuReport_Click",this.mnuReport_Click);
this.bind("mnu_viewtimecard_Click",this.mnu_viewtimecard_Click);
this.bind("mnuViewDetail_Click",this.mnuViewDetail_Click);
this.bind("Ctx_mnuWeeklyPopUp_Opening",this.Ctx_mnuWeeklyPopUp_Opening);
this.bind("Ctx_mnuWeeklyPopUp_Closing",this.Ctx_mnuWeeklyPopUp_Closing);
this.bind("calWeek_Click",this.calWeek_Click);
this.bind("pnSelected_MouseDown",this.pnSelected_MouseDown);
this.bind("cboSelectName_SelectionChangeCommitted",this.cboSelectName_SelectionChangeCommitted);
this.bind("cboFullList_SelectionChangeCommitted",this.cboFullList_SelectionChangeCommitted);
this.bind("lbPos1am_DragDrop",this.lbPos1am_DragDrop);
this.bind("lbPos1am_MouseDown",this.lbPos1am_MouseDown);
this.bind("_lbPos1am_0_MouseDown",this._lbPos1am_0_MouseDown);
this.bind("lbPos1am_DragOver",this.lbPos1am_DragOver);
this.bind("_lbPos1am_1_MouseDown",this._lbPos1am_1_MouseDown);
this.bind("_lbPos1am_2_MouseDown",this._lbPos1am_2_MouseDown);
this.bind("_lbPos1am_3_MouseDown",this._lbPos1am_3_MouseDown);
this.bind("_lbPos1am_4_MouseDown",this._lbPos1am_4_MouseDown);
this.bind("_lbPos1am_5_MouseDown",this._lbPos1am_5_MouseDown);
this.bind("_lbPos1am_6_MouseDown",this._lbPos1am_6_MouseDown);
this.bind("lbPos2am_DragDrop",this.lbPos2am_DragDrop);
this.bind("lbPos2am_MouseDown",this.lbPos2am_MouseDown);
this.bind("_lbPos2am_0_MouseDown",this._lbPos2am_0_MouseDown);
this.bind("lbPos2am_DragOver",this.lbPos2am_DragOver);
this.bind("_lbPos2am_1_MouseDown",this._lbPos2am_1_MouseDown);
this.bind("_lbPos2am_2_MouseDown",this._lbPos2am_2_MouseDown);
this.bind("_lbPos2am_3_MouseDown",this._lbPos2am_3_MouseDown);
this.bind("_lbPos2am_4_MouseDown",this._lbPos2am_4_MouseDown);
this.bind("_lbPos2am_5_MouseDown",this._lbPos2am_5_MouseDown);
this.bind("_lbPos2am_6_MouseDown",this._lbPos2am_6_MouseDown);
this.bind("lbPos3am_DragDrop",this.lbPos3am_DragDrop);
this.bind("lbPos3am_MouseDown",this.lbPos3am_MouseDown);
this.bind("_lbPos3am_0_MouseDown",this._lbPos3am_0_MouseDown);
this.bind("lbPos3am_DragOver",this.lbPos3am_DragOver);
this.bind("_lbPos3am_1_MouseDown",this._lbPos3am_1_MouseDown);
this.bind("_lbPos3am_2_MouseDown",this._lbPos3am_2_MouseDown);
this.bind("_lbPos3am_3_MouseDown",this._lbPos3am_3_MouseDown);
this.bind("_lbPos3am_4_MouseDown",this._lbPos3am_4_MouseDown);
this.bind("_lbPos3am_5_MouseDown",this._lbPos3am_5_MouseDown);
this.bind("_lbPos3am_6_MouseDown",this._lbPos3am_6_MouseDown);
this.bind("lbPos3pm_DragDrop",this.lbPos3pm_DragDrop);
this.bind("lbPos3pm_MouseDown",this.lbPos3pm_MouseDown);
this.bind("_lbPos3pm_0_MouseDown",this._lbPos3pm_0_MouseDown);
this.bind("lbPos3pm_DragOver",this.lbPos3pm_DragOver);
this.bind("_lbPos3pm_1_MouseDown",this._lbPos3pm_1_MouseDown);
this.bind("_lbPos3pm_2_MouseDown",this._lbPos3pm_2_MouseDown);
this.bind("_lbPos3pm_3_MouseDown",this._lbPos3pm_3_MouseDown);
this.bind("_lbPos3pm_4_MouseDown",this._lbPos3pm_4_MouseDown);
this.bind("_lbPos3pm_5_MouseDown",this._lbPos3pm_5_MouseDown);
this.bind("_lbPos3pm_6_MouseDown",this._lbPos3pm_6_MouseDown);
this.bind("lbPos4am_DragDrop",this.lbPos4am_DragDrop);
this.bind("lbPos4am_MouseDown",this.lbPos4am_MouseDown);
this.bind("_lbPos4am_0_MouseDown",this._lbPos4am_0_MouseDown);
this.bind("lbPos4am_DragOver",this.lbPos4am_DragOver);
this.bind("_lbPos4am_1_MouseDown",this._lbPos4am_1_MouseDown);
this.bind("_lbPos4am_2_MouseDown",this._lbPos4am_2_MouseDown);
this.bind("_lbPos4am_3_MouseDown",this._lbPos4am_3_MouseDown);
this.bind("_lbPos4am_4_MouseDown",this._lbPos4am_4_MouseDown);
this.bind("_lbPos4am_5_MouseDown",this._lbPos4am_5_MouseDown);
this.bind("_lbPos4am_6_MouseDown",this._lbPos4am_6_MouseDown);
this.bind("lbPos4pm_DragDrop",this.lbPos4pm_DragDrop);
this.bind("lbPos4pm_MouseDown",this.lbPos4pm_MouseDown);
this.bind("_lbPos4pm_0_MouseDown",this._lbPos4pm_0_MouseDown);
this.bind("lbPos4pm_DragOver",this.lbPos4pm_DragOver);
this.bind("_lbPos4pm_1_MouseDown",this._lbPos4pm_1_MouseDown);
this.bind("_lbPos4pm_2_MouseDown",this._lbPos4pm_2_MouseDown);
this.bind("_lbPos4pm_3_MouseDown",this._lbPos4pm_3_MouseDown);
this.bind("_lbPos4pm_4_MouseDown",this._lbPos4pm_4_MouseDown);
this.bind("_lbPos4pm_5_MouseDown",this._lbPos4pm_5_MouseDown);
this.bind("_lbPos4pm_6_MouseDown",this._lbPos4pm_6_MouseDown);
this.bind("lbPos5am_DragDrop",this.lbPos5am_DragDrop);
this.bind("lbPos5am_MouseDown",this.lbPos5am_MouseDown);
this.bind("_lbPos5am_0_MouseDown",this._lbPos5am_0_MouseDown);
this.bind("lbPos5am_DragOver",this.lbPos5am_DragOver);
this.bind("_lbPos5am_1_MouseDown",this._lbPos5am_1_MouseDown);
this.bind("_lbPos5am_2_MouseDown",this._lbPos5am_2_MouseDown);
this.bind("_lbPos5am_3_MouseDown",this._lbPos5am_3_MouseDown);
this.bind("_lbPos5am_4_MouseDown",this._lbPos5am_4_MouseDown);
this.bind("_lbPos5am_5_MouseDown",this._lbPos5am_5_MouseDown);
this.bind("_lbPos5am_6_MouseDown",this._lbPos5am_6_MouseDown);
this.bind("lbPos5pm_DragDrop",this.lbPos5pm_DragDrop);
this.bind("lbPos5pm_MouseDown",this.lbPos5pm_MouseDown);
this.bind("_lbPos5pm_0_MouseDown",this._lbPos5pm_0_MouseDown);
this.bind("lbPos5pm_DragOver",this.lbPos5pm_DragOver);
this.bind("_lbPos5pm_1_MouseDown",this._lbPos5pm_1_MouseDown);
this.bind("_lbPos5pm_2_MouseDown",this._lbPos5pm_2_MouseDown);
this.bind("_lbPos5pm_3_MouseDown",this._lbPos5pm_3_MouseDown);
this.bind("_lbPos5pm_4_MouseDown",this._lbPos5pm_4_MouseDown);
this.bind("_lbPos5pm_5_MouseDown",this._lbPos5pm_5_MouseDown);
this.bind("_lbPos5pm_6_MouseDown",this._lbPos5pm_6_MouseDown);
this.bind("lbPos6am_DragDrop",this.lbPos6am_DragDrop);
this.bind("lbPos6am_MouseDown",this.lbPos6am_MouseDown);
this.bind("_lbPos6am_0_MouseDown",this._lbPos6am_0_MouseDown);
this.bind("lbPos6am_DragOver",this.lbPos6am_DragOver);
this.bind("_lbPos6am_1_MouseDown",this._lbPos6am_1_MouseDown);
this.bind("_lbPos6am_2_MouseDown",this._lbPos6am_2_MouseDown);
this.bind("_lbPos6am_3_MouseDown",this._lbPos6am_3_MouseDown);
this.bind("_lbPos6am_4_MouseDown",this._lbPos6am_4_MouseDown);
this.bind("_lbPos6am_5_MouseDown",this._lbPos6am_5_MouseDown);
this.bind("_lbPos6am_6_MouseDown",this._lbPos6am_6_MouseDown);
this.bind("lbPos6pm_DragDrop",this.lbPos6pm_DragDrop);
this.bind("lbPos6pm_MouseDown",this.lbPos6pm_MouseDown);
this.bind("_lbPos6pm_0_MouseDown",this._lbPos6pm_0_MouseDown);
this.bind("lbPos6pm_DragOver",this.lbPos6pm_DragOver);
this.bind("_lbPos6pm_1_MouseDown",this._lbPos6pm_1_MouseDown);
this.bind("_lbPos6pm_2_MouseDown",this._lbPos6pm_2_MouseDown);
this.bind("_lbPos6pm_3_MouseDown",this._lbPos6pm_3_MouseDown);
this.bind("_lbPos6pm_4_MouseDown",this._lbPos6pm_4_MouseDown);
this.bind("_lbPos6pm_5_MouseDown",this._lbPos6pm_5_MouseDown);
this.bind("_lbPos6pm_6_MouseDown",this._lbPos6pm_6_MouseDown);
this.bind("lbPos7am_DragDrop",this.lbPos7am_DragDrop);
this.bind("lbPos7am_MouseDown",this.lbPos7am_MouseDown);
this.bind("_lbPos7am_0_MouseDown",this._lbPos7am_0_MouseDown);
this.bind("lbPos7am_DragOver",this.lbPos7am_DragOver);
this.bind("_lbPos7am_1_MouseDown",this._lbPos7am_1_MouseDown);
this.bind("_lbPos7am_2_MouseDown",this._lbPos7am_2_MouseDown);
this.bind("_lbPos7am_3_MouseDown",this._lbPos7am_3_MouseDown);
this.bind("_lbPos7am_4_MouseDown",this._lbPos7am_4_MouseDown);
this.bind("_lbPos7am_5_MouseDown",this._lbPos7am_5_MouseDown);
this.bind("_lbPos7am_6_MouseDown",this._lbPos7am_6_MouseDown);
this.bind("lbPos7pm_DragDrop",this.lbPos7pm_DragDrop);
this.bind("lbPos7pm_MouseDown",this.lbPos7pm_MouseDown);
this.bind("_lbPos7pm_0_MouseDown",this._lbPos7pm_0_MouseDown);
this.bind("lbPos7pm_DragOver",this.lbPos7pm_DragOver);
this.bind("_lbPos7pm_1_MouseDown",this._lbPos7pm_1_MouseDown);
this.bind("_lbPos7pm_2_MouseDown",this._lbPos7pm_2_MouseDown);
this.bind("_lbPos7pm_3_MouseDown",this._lbPos7pm_3_MouseDown);
this.bind("_lbPos7pm_4_MouseDown",this._lbPos7pm_4_MouseDown);
this.bind("_lbPos7pm_5_MouseDown",this._lbPos7pm_5_MouseDown);
this.bind("_lbPos7pm_6_MouseDown",this._lbPos7pm_6_MouseDown);
this.bind("lbPos8am_DragDrop",this.lbPos8am_DragDrop);
this.bind("lbPos8am_MouseDown",this.lbPos8am_MouseDown);
this.bind("_lbPos8am_0_MouseDown",this._lbPos8am_0_MouseDown);
this.bind("lbPos8am_DragOver",this.lbPos8am_DragOver);
this.bind("_lbPos8am_1_MouseDown",this._lbPos8am_1_MouseDown);
this.bind("_lbPos8am_2_MouseDown",this._lbPos8am_2_MouseDown);
this.bind("_lbPos8am_3_MouseDown",this._lbPos8am_3_MouseDown);
this.bind("_lbPos8am_4_MouseDown",this._lbPos8am_4_MouseDown);
this.bind("_lbPos8am_5_MouseDown",this._lbPos8am_5_MouseDown);
this.bind("_lbPos8am_6_MouseDown",this._lbPos8am_6_MouseDown);
this.bind("lbPos9am_DragDrop",this.lbPos9am_DragDrop);
this.bind("lbPos9am_MouseDown",this.lbPos9am_MouseDown);
this.bind("_lbPos9am_0_MouseDown",this._lbPos9am_0_MouseDown);
this.bind("lbPos9am_DragOver",this.lbPos9am_DragOver);
this.bind("_lbPos9am_1_MouseDown",this._lbPos9am_1_MouseDown);
this.bind("_lbPos9am_2_MouseDown",this._lbPos9am_2_MouseDown);
this.bind("_lbPos9am_3_MouseDown",this._lbPos9am_3_MouseDown);
this.bind("_lbPos9am_4_MouseDown",this._lbPos9am_4_MouseDown);
this.bind("_lbPos9am_5_MouseDown",this._lbPos9am_5_MouseDown);
this.bind("_lbPos9am_6_MouseDown",this._lbPos9am_6_MouseDown);
this.bind("lbPos9pm_DragDrop",this.lbPos9pm_DragDrop);
this.bind("lbPos9pm_MouseDown",this.lbPos9pm_MouseDown);
this.bind("_lbPos9pm_0_MouseDown",this._lbPos9pm_0_MouseDown);
this.bind("lbPos9pm_DragOver",this.lbPos9pm_DragOver);
this.bind("_lbPos9pm_1_MouseDown",this._lbPos9pm_1_MouseDown);
this.bind("_lbPos9pm_2_MouseDown",this._lbPos9pm_2_MouseDown);
this.bind("_lbPos9pm_3_MouseDown",this._lbPos9pm_3_MouseDown);
this.bind("_lbPos9pm_4_MouseDown",this._lbPos9pm_4_MouseDown);
this.bind("_lbPos9pm_5_MouseDown",this._lbPos9pm_5_MouseDown);
this.bind("_lbPos9pm_6_MouseDown",this._lbPos9pm_6_MouseDown);
this.bind("lbPos10am_DragDrop",this.lbPos10am_DragDrop);
this.bind("lbPos10am_MouseDown",this.lbPos10am_MouseDown);
this.bind("_lbPos10am_0_MouseDown",this._lbPos10am_0_MouseDown);
this.bind("lbPos10am_DragOver",this.lbPos10am_DragOver);
this.bind("_lbPos10am_1_MouseDown",this._lbPos10am_1_MouseDown);
this.bind("_lbPos10am_2_MouseDown",this._lbPos10am_2_MouseDown);
this.bind("_lbPos10am_3_MouseDown",this._lbPos10am_3_MouseDown);
this.bind("_lbPos10am_4_MouseDown",this._lbPos10am_4_MouseDown);
this.bind("_lbPos10am_5_MouseDown",this._lbPos10am_5_MouseDown);
this.bind("_lbPos10am_6_MouseDown",this._lbPos10am_6_MouseDown);
this.bind("lbPos10pm_DragDrop",this.lbPos10pm_DragDrop);
this.bind("lbPos10pm_MouseDown",this.lbPos10pm_MouseDown);
this.bind("_lbPos10pm_0_MouseDown",this._lbPos10pm_0_MouseDown);
this.bind("lbPos10pm_DragOver",this.lbPos10pm_DragOver);
this.bind("_lbPos10pm_1_MouseDown",this._lbPos10pm_1_MouseDown);
this.bind("_lbPos10pm_2_MouseDown",this._lbPos10pm_2_MouseDown);
this.bind("_lbPos10pm_3_MouseDown",this._lbPos10pm_3_MouseDown);
this.bind("_lbPos10pm_4_MouseDown",this._lbPos10pm_4_MouseDown);
this.bind("_lbPos10pm_5_MouseDown",this._lbPos10pm_5_MouseDown);
this.bind("_lbPos10pm_6_MouseDown",this._lbPos10pm_6_MouseDown);
this.bind("lbPos11am_DragDrop",this.lbPos11am_DragDrop);
this.bind("lbPos11am_MouseDown",this.lbPos11am_MouseDown);
this.bind("_lbPos11am_0_MouseDown",this._lbPos11am_0_MouseDown);
this.bind("lbPos11am_DragOver",this.lbPos11am_DragOver);
this.bind("_lbPos11am_1_MouseDown",this._lbPos11am_1_MouseDown);
this.bind("_lbPos11am_2_MouseDown",this._lbPos11am_2_MouseDown);
this.bind("_lbPos11am_3_MouseDown",this._lbPos11am_3_MouseDown);
this.bind("_lbPos11am_4_MouseDown",this._lbPos11am_4_MouseDown);
this.bind("_lbPos11am_5_MouseDown",this._lbPos11am_5_MouseDown);
this.bind("_lbPos11am_6_MouseDown",this._lbPos11am_6_MouseDown);
this.bind("lbPos11pm_DragDrop",this.lbPos11pm_DragDrop);
this.bind("lbPos11pm_MouseDown",this.lbPos11pm_MouseDown);
this.bind("_lbPos11pm_0_MouseDown",this._lbPos11pm_0_MouseDown);
this.bind("lbPos11pm_DragOver",this.lbPos11pm_DragOver);
this.bind("_lbPos11pm_1_MouseDown",this._lbPos11pm_1_MouseDown);
this.bind("_lbPos11pm_2_MouseDown",this._lbPos11pm_2_MouseDown);
this.bind("_lbPos11pm_3_MouseDown",this._lbPos11pm_3_MouseDown);
this.bind("_lbPos11pm_4_MouseDown",this._lbPos11pm_4_MouseDown);
this.bind("_lbPos11pm_5_MouseDown",this._lbPos11pm_5_MouseDown);
this.bind("_lbPos11pm_6_MouseDown",this._lbPos11pm_6_MouseDown);
this.bind("lbPos12am_DragDrop",this.lbPos12am_DragDrop);
this.bind("lbPos12am_MouseDown",this.lbPos12am_MouseDown);
this.bind("_lbPos12am_0_MouseDown",this._lbPos12am_0_MouseDown);
this.bind("lbPos12am_DragOver",this.lbPos12am_DragOver);
this.bind("_lbPos12am_1_MouseDown",this._lbPos12am_1_MouseDown);
this.bind("_lbPos12am_2_MouseDown",this._lbPos12am_2_MouseDown);
this.bind("_lbPos12am_3_MouseDown",this._lbPos12am_3_MouseDown);
this.bind("_lbPos12am_4_MouseDown",this._lbPos12am_4_MouseDown);
this.bind("_lbPos12am_5_MouseDown",this._lbPos12am_5_MouseDown);
this.bind("_lbPos12am_6_MouseDown",this._lbPos12am_6_MouseDown);
this.bind("lbPos12pm_DragDrop",this.lbPos12pm_DragDrop);
this.bind("lbPos12pm_MouseDown",this.lbPos12pm_MouseDown);
this.bind("_lbPos12pm_0_MouseDown",this._lbPos12pm_0_MouseDown);
this.bind("lbPos12pm_DragOver",this.lbPos12pm_DragOver);
this.bind("_lbPos12pm_1_MouseDown",this._lbPos12pm_1_MouseDown);
this.bind("_lbPos12pm_2_MouseDown",this._lbPos12pm_2_MouseDown);
this.bind("_lbPos12pm_3_MouseDown",this._lbPos12pm_3_MouseDown);
this.bind("_lbPos12pm_4_MouseDown",this._lbPos12pm_4_MouseDown);
this.bind("_lbPos12pm_5_MouseDown",this._lbPos12pm_5_MouseDown);
this.bind("_lbPos12pm_6_MouseDown",this._lbPos12pm_6_MouseDown);
this.bind("lbPos13am_DragDrop",this.lbPos13am_DragDrop);
this.bind("lbPos13am_MouseDown",this.lbPos13am_MouseDown);
this.bind("_lbPos13am_0_MouseDown",this._lbPos13am_0_MouseDown);
this.bind("lbPos13am_DragOver",this.lbPos13am_DragOver);
this.bind("_lbPos13am_1_MouseDown",this._lbPos13am_1_MouseDown);
this.bind("_lbPos13am_2_MouseDown",this._lbPos13am_2_MouseDown);
this.bind("_lbPos13am_3_MouseDown",this._lbPos13am_3_MouseDown);
this.bind("_lbPos13am_4_MouseDown",this._lbPos13am_4_MouseDown);
this.bind("_lbPos13am_5_MouseDown",this._lbPos13am_5_MouseDown);
this.bind("_lbPos13am_6_MouseDown",this._lbPos13am_6_MouseDown);
this.bind("lbPos13pm_DragDrop",this.lbPos13pm_DragDrop);
this.bind("lbPos13pm_MouseDown",this.lbPos13pm_MouseDown);
this.bind("_lbPos13pm_0_MouseDown",this._lbPos13pm_0_MouseDown);
this.bind("lbPos13pm_DragOver",this.lbPos13pm_DragOver);
this.bind("_lbPos13pm_1_MouseDown",this._lbPos13pm_1_MouseDown);
this.bind("_lbPos13pm_2_MouseDown",this._lbPos13pm_2_MouseDown);
this.bind("_lbPos13pm_3_MouseDown",this._lbPos13pm_3_MouseDown);
this.bind("_lbPos13pm_4_MouseDown",this._lbPos13pm_4_MouseDown);
this.bind("_lbPos13pm_5_MouseDown",this._lbPos13pm_5_MouseDown);
this.bind("_lbPos13pm_6_MouseDown",this._lbPos13pm_6_MouseDown);
this.bind("picTrash_DragDrop",this.picTrash_DragDrop);
this.bind("picTrash_DragOver",this.picTrash_DragOver);
this.bind("lstLeave_DoubleClick",this.lstLeave_DoubleClick);
this.bind("lstLeave_Leave",this.lstLeave_Leave);
this.bind("lstLeave_MouseDown",this.lstLeave_MouseDown);
this.bind("cmdPayroll_Click",this.cmdPayroll_Click);
this.bind("cmdReport_Click",this.cmdReport_Click);
this.bind("cmdClose_Click",this.cmdClose_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmDispatchScheduler";
            }

            public loaded() {
			
            }

        
        public frmDispatchScheduler_Activated(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

        public frmDispatchScheduler_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmDispatchScheduler",action:"frmDispatchScheduler_Close"});
                e.preventDefault();
            }
            
        }
        public frmDispatchScheduler_Deactivate(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuPrintPayReport_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuClose_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuEmpInfo_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuSeniorInq_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuImmune_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_transfer_req_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuPMCerts_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuPPE_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuIndSchedule_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuBattalion1_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuBattalion2_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuNewBatt3_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuBattalion3_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuBattalion4_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuEMS_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuEMSDaily_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_watch_duty_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_Vacation_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_PMVacationSched_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_FCCVacationSched_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuAssign_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuRoster_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_DDGroups_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuProlist_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuBenefit_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_emp_facility_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuAuditDDHOL_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_IndivPayrollSO_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuIndTimeCard2_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu181_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu182_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu183_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuEMSPay_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuHazPay_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuMarPay_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuBattPay_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuDisPay_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuIndTimeCard_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuIndYearSched_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuDailyStaff_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuOvertime_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuExtraOff_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_sa_report_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuShiftCal_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuTransfer_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuDailyLeave_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuAnnual_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_dailysickleave_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuIndLeave_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_sick_usage_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_PMLeave_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuDispatchLeave_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnutimecard_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuIndAnnualPayroll_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnupersonnelsignoff_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_QuarterlyMinimumDrill_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_FCCMinDrills_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_ReadingAssign_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_OTEPReport_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_PMRecertReport_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_PMBaseStaReport_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_trainingtracker_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_IndTrainReport_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_IndPMRecert_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuALSProc_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuTrainQuery_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_TrainingQuerynew_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuCascade_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuPrintScreen_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuAbout_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_HelpPrntScrn_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_timecodes_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_payrolllegend_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_legend_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_IndLegend_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_payup_calc_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuTrainCodeHelp_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuLeave_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuPayUp_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuPayDown_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuKOT_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuTrade_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuRemove_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuReport_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_viewtimecard_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuViewDetail_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public Ctx_mnuWeeklyPopUp_Opening(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public Ctx_mnuWeeklyPopUp_Closing(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public calWeek_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public pnSelected_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null ,() => {(window as any).app.disableLoading = false;}));            

        }
        public cboSelectName_SelectionChangeCommitted(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboFullList_SelectionChangeCommitted(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public lbPos1am_DragDrop(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public lbPos1am_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos1am_0_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos1am_DragOver(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public _lbPos1am_1_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos1am_2_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos1am_3_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos1am_4_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos1am_5_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos1am_6_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos2am_DragDrop(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public lbPos2am_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos2am_0_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos2am_DragOver(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public _lbPos2am_1_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos2am_2_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos2am_3_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos2am_4_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos2am_5_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos2am_6_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos3am_DragDrop(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public lbPos3am_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos3am_0_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos3am_DragOver(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public _lbPos3am_1_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos3am_2_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos3am_3_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos3am_4_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos3am_5_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos3am_6_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos3pm_DragDrop(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public lbPos3pm_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos3pm_0_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos3pm_DragOver(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public _lbPos3pm_1_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos3pm_2_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos3pm_3_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos3pm_4_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos3pm_5_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos3pm_6_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos4am_DragDrop(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public lbPos4am_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos4am_0_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos4am_DragOver(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public _lbPos4am_1_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos4am_2_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos4am_3_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos4am_4_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos4am_5_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos4am_6_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos4pm_DragDrop(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public lbPos4pm_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos4pm_0_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos4pm_DragOver(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public _lbPos4pm_1_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos4pm_2_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos4pm_3_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos4pm_4_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos4pm_5_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos4pm_6_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos5am_DragDrop(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public lbPos5am_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos5am_0_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos5am_DragOver(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public _lbPos5am_1_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos5am_2_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos5am_3_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos5am_4_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos5am_5_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos5am_6_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos5pm_DragDrop(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public lbPos5pm_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos5pm_0_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos5pm_DragOver(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public _lbPos5pm_1_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos5pm_2_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos5pm_3_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos5pm_4_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos5pm_5_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos5pm_6_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos6am_DragDrop(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public lbPos6am_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos6am_0_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos6am_DragOver(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public _lbPos6am_1_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos6am_2_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos6am_3_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos6am_4_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos6am_5_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos6am_6_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos6pm_DragDrop(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public lbPos6pm_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos6pm_0_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos6pm_DragOver(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public _lbPos6pm_1_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos6pm_2_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos6pm_3_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos6pm_4_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos6pm_5_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos6pm_6_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos7am_DragDrop(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public lbPos7am_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos7am_0_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos7am_DragOver(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public _lbPos7am_1_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos7am_2_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos7am_3_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos7am_4_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos7am_5_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos7am_6_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos7pm_DragDrop(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public lbPos7pm_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos7pm_0_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos7pm_DragOver(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public _lbPos7pm_1_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos7pm_2_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos7pm_3_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos7pm_4_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos7pm_5_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos7pm_6_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos8am_DragDrop(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public lbPos8am_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos8am_0_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos8am_DragOver(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public _lbPos8am_1_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos8am_2_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos8am_3_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos8am_4_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos8am_5_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos8am_6_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos9am_DragDrop(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public lbPos9am_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos9am_0_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos9am_DragOver(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public _lbPos9am_1_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos9am_2_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos9am_3_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos9am_4_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos9am_5_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos9am_6_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos9pm_DragDrop(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public lbPos9pm_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos9pm_0_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos9pm_DragOver(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public _lbPos9pm_1_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos9pm_2_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos9pm_3_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos9pm_4_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos9pm_5_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos9pm_6_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos10am_DragDrop(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public lbPos10am_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos10am_0_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos10am_DragOver(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public _lbPos10am_1_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos10am_2_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos10am_3_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos10am_4_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos10am_5_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos10am_6_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos10pm_DragDrop(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public lbPos10pm_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos10pm_0_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos10pm_DragOver(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public _lbPos10pm_1_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos10pm_2_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos10pm_3_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos10pm_4_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos10pm_5_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos10pm_6_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos11am_DragDrop(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public lbPos11am_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos11am_0_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos11am_DragOver(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public _lbPos11am_1_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos11am_2_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos11am_3_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos11am_4_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos11am_5_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos11am_6_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos11pm_DragDrop(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public lbPos11pm_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos11pm_0_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos11pm_DragOver(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public _lbPos11pm_1_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos11pm_2_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos11pm_3_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos11pm_4_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos11pm_5_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos11pm_6_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos12am_DragDrop(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public lbPos12am_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos12am_0_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos12am_DragOver(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public _lbPos12am_1_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos12am_2_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos12am_3_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos12am_4_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos12am_5_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos12am_6_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos12pm_DragDrop(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public lbPos12pm_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos12pm_0_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos12pm_DragOver(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public _lbPos12pm_1_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos12pm_2_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos12pm_3_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos12pm_4_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos12pm_5_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos12pm_6_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos13am_DragDrop(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public lbPos13am_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos13am_0_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos13am_DragOver(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public _lbPos13am_1_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos13am_2_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos13am_3_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos13am_4_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos13am_5_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos13am_6_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos13pm_DragDrop(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public lbPos13pm_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos13pm_0_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPos13pm_DragOver(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public _lbPos13pm_1_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos13pm_2_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos13pm_3_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos13pm_4_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos13pm_5_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPos13pm_6_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public picTrash_DragDrop(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID}));            

        }
        public picTrash_DragOver(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID}));            

        }
        public lstLeave_DoubleClick(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public lstLeave_Leave(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public lstLeave_MouseDown(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public cmdPayroll_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdReport_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmDispatchScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

