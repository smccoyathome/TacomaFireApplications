/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmBatt2SchedNew", [ "files/text!views/PTSProject.frmBatt2SchedNew.html", "files/css!views/PTSProject.frmBatt2SchedNew.css","usercontrols/UpgradeHelpers_Gui_ShapeHelper"],
    (htmlTemplate) => {
    return class frmBatt2SchedNew extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("frmBatt2SchedNew_Activated",this.frmBatt2SchedNew_Activated);
this.bind("frmBatt2SchedNew_Deactivate",this.frmBatt2SchedNew_Deactivate);
this.bind("mnuTimeCard_Click",this.mnuTimeCard_Click);
this.bind("mnuException_Click",this.mnuException_Click);
this.bind("mnuPrintDailyLeave_Click",this.mnuPrintDailyLeave_Click);
this.bind("mnuPrintAll_Click",this.mnuPrintAll_Click);
this.bind("mnuClose_Click",this.mnuClose_Click);
this.bind("mnuEmpInfo_Click",this.mnuEmpInfo_Click);
this.bind("mnuSenoirInq_Click",this.mnuSenoirInq_Click);
this.bind("mnuImmune_Click",this.mnuImmune_Click);
this.bind("mnu_transfer_req_Click",this.mnu_transfer_req_Click);
this.bind("mnuPMCerts_Click",this.mnuPMCerts_Click);
this.bind("mnuPPE_Click",this.mnuPPE_Click);
this.bind("mnuIndSchedule_Click",this.mnuIndSchedule_Click);
this.bind("mnuNewBatt1_Click",this.mnuNewBatt1_Click);
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
this.bind("mnu_HZMVacationSched_Click",this.mnu_HZMVacationSched_Click);
this.bind("mnu_FCCVacationSched_Click",this.mnu_FCCVacationSched_Click);
this.bind("mnuAssignReport_Click",this.mnuAssignReport_Click);
this.bind("mnuRoster_Click",this.mnuRoster_Click);
this.bind("mnuFRoster_Click",this.mnuFRoster_Click);
this.bind("mnuDebitReport_Click",this.mnuDebitReport_Click);
this.bind("mnuProlist_Click",this.mnuProlist_Click);
this.bind("mnuSenior_Click",this.mnuSenior_Click);
this.bind("mnu_emp_facility_Click",this.mnu_emp_facility_Click);
this.bind("MnuAuditDDHOL_Click",this.MnuAuditDDHOL_Click);
this.bind("mnu_IndivPayrollSO_Click",this.mnu_IndivPayrollSO_Click);
this.bind("mnuIndTimeCard2_Click",this.mnuIndTimeCard2_Click);
this.bind("mnu181_Click",this.mnu181_Click);
this.bind("mnu182_Click",this.mnu182_Click);
this.bind("mnuEMSPay_Click",this.mnuEMSPay_Click);
this.bind("mnuHazPay_Click",this.mnuHazPay_Click);
this.bind("mnuMarPay_Click",this.mnuMarPay_Click);
this.bind("mnuBattPay_Click",this.mnuBattPay_Click);
this.bind("mnuDisPay_Click",this.mnuDisPay_Click);
this.bind("mnuIndTimeCard_Click",this.mnuIndTimeCard_Click);
this.bind("mnuIndYearSched_Click",this.mnuIndYearSched_Click);
this.bind("mnuDailyStaff_Click",this.mnuDailyStaff_Click);
this.bind("mnuOvertime_Click",this.mnuOvertime_Click);
this.bind("MnuExtraOff_Click",this.MnuExtraOff_Click);
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
this.bind("mnu_HZMLeave_Click",this.mnu_HZMLeave_Click);
this.bind("MnuCBStaffing_Click",this.MnuCBStaffing_Click);
this.bind("mnu_LeaveNoSched_Click",this.mnu_LeaveNoSched_Click);
this.bind("mnu_staffdiscrepancy_Click",this.mnu_staffdiscrepancy_Click);
this.bind("mnu_PMCSRCalc_Click",this.mnu_PMCSRCalc_Click);
this.bind("mnu_SchedNotes_Click",this.mnu_SchedNotes_Click);
this.bind("mnu_PPEQuery_Click",this.mnu_PPEQuery_Click);
this.bind("mnu_timecard_Click",this.mnu_timecard_Click);
this.bind("mnuindannualpayroll_Click",this.mnuindannualpayroll_Click);
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
this.bind("mnu_timecodes_Click",this.mnu_timecodes_Click);
this.bind("mnuTrainCodeHelp_Click",this.mnuTrainCodeHelp_Click);
this.bind("mnu_HelpPrntScrn_Click",this.mnu_HelpPrntScrn_Click);
this.bind("mnu_payup_calc_Click",this.mnu_payup_calc_Click);
this.bind("mnu_payrolllegend_Click",this.mnu_payrolllegend_Click);
this.bind("mnu_legend_Click",this.mnu_legend_Click);
this.bind("mnu_IndLegend_Click",this.mnu_IndLegend_Click);
this.bind("mnuLeave_Click",this.mnuLeave_Click);
this.bind("mnuNewSched_Click",this.mnuNewSched_Click);
this.bind("mnuPayUp_Click",this.mnuPayUp_Click);
this.bind("mnuPayDown_Click",this.mnuPayDown_Click);
this.bind("mnuKOT_Click",this.mnuKOT_Click);
this.bind("mnuRover_Click",this.mnuRover_Click);
this.bind("mnuDebit_Click",this.mnuDebit_Click);
this.bind("mnuTrade_Click",this.mnuTrade_Click);
this.bind("mnuCancelTrade_Click",this.mnuCancelTrade_Click);
this.bind("mnuRemove_Click",this.mnuRemove_Click);
this.bind("mnuSendTo181_Click",this.mnuSendTo181_Click);
this.bind("mnuReport_Click",this.mnuReport_Click);
this.bind("mnuTradeDetail_Click",this.mnuTradeDetail_Click);
this.bind("mnu_viewtimecard_Click",this.mnu_viewtimecard_Click);
this.bind("mnuSADetail_Click",this.mnuSADetail_Click);
this.bind("mnuReschedSA_Click",this.mnuReschedSA_Click);
this.bind("Ctx_mnu182PopUp_Closing",this.Ctx_mnu182PopUp_Closing);
this.bind("Ctx_mnu182PopUp_Opening",this.Ctx_mnu182PopUp_Opening);
this.bind("calSchedDate_Click",this.calSchedDate_Click);
this.bind("cboRovers_SelectionChangeCommitted",this.cboRovers_SelectionChangeCommitted);
this.bind("cboRovers_DragOver",this.cboRovers_DragOver);
this.bind("cboRovers_DragDrop",this.cboRovers_DragDrop);
this.bind("cboDebit_SelectionChangeCommitted",this.cboDebit_SelectionChangeCommitted);
this.bind("cboDebit_DragOver",this.cboDebit_DragOver);
this.bind("cboDebit_DragDrop",this.cboDebit_DragDrop);
this.bind("cmdToday_Click",this.cmdToday_Click);
this.bind("pnSelected_MouseDown",this.pnSelected_MouseDown);
this.bind("lbPosam_DragDrop",this.lbPosam_DragDrop);
this.bind("lbPosam_DragOver",this.lbPosam_DragOver);
this.bind("_lbPosam_0_MouseDown",this._lbPosam_0_MouseDown);
this.bind("_lbPosam_4_MouseDown",this._lbPosam_4_MouseDown);
this.bind("_lbPosam_8_MouseDown",this._lbPosam_8_MouseDown);
this.bind("_lbPosam_12_MouseDown",this._lbPosam_12_MouseDown);
this.bind("_lbPosam_16_MouseDown",this._lbPosam_16_MouseDown);
this.bind("_lbPosam_68_MouseDown",this._lbPosam_68_MouseDown);
this.bind("lbPospm_DragDrop",this.lbPospm_DragDrop);
this.bind("lbPospm_DragOver",this.lbPospm_DragOver);
this.bind("_lbPospm_0_MouseDown",this._lbPospm_0_MouseDown);
this.bind("_lbPospm_4_MouseDown",this._lbPospm_4_MouseDown);
this.bind("_lbPospm_8_MouseDown",this._lbPospm_8_MouseDown);
this.bind("_lbPospm_12_MouseDown",this._lbPospm_12_MouseDown);
this.bind("_lbPospm_16_MouseDown",this._lbPospm_16_MouseDown);
this.bind("_lbPospm_68_MouseDown",this._lbPospm_68_MouseDown);
this.bind("_lbPosam_1_MouseDown",this._lbPosam_1_MouseDown);
this.bind("_lbPosam_5_MouseDown",this._lbPosam_5_MouseDown);
this.bind("_lbPosam_9_MouseDown",this._lbPosam_9_MouseDown);
this.bind("_lbPosam_13_MouseDown",this._lbPosam_13_MouseDown);
this.bind("_lbPosam_17_MouseDown",this._lbPosam_17_MouseDown);
this.bind("_lbPosam_69_MouseDown",this._lbPosam_69_MouseDown);
this.bind("_lbPospm_1_MouseDown",this._lbPospm_1_MouseDown);
this.bind("_lbPospm_5_MouseDown",this._lbPospm_5_MouseDown);
this.bind("_lbPospm_9_MouseDown",this._lbPospm_9_MouseDown);
this.bind("_lbPospm_13_MouseDown",this._lbPospm_13_MouseDown);
this.bind("_lbPospm_17_MouseDown",this._lbPospm_17_MouseDown);
this.bind("_lbPospm_69_MouseDown",this._lbPospm_69_MouseDown);
this.bind("_lbPosam_2_MouseDown",this._lbPosam_2_MouseDown);
this.bind("_lbPosam_6_MouseDown",this._lbPosam_6_MouseDown);
this.bind("_lbPosam_10_MouseDown",this._lbPosam_10_MouseDown);
this.bind("_lbPosam_14_MouseDown",this._lbPosam_14_MouseDown);
this.bind("_lbPosam_18_MouseDown",this._lbPosam_18_MouseDown);
this.bind("_lbPosam_70_MouseDown",this._lbPosam_70_MouseDown);
this.bind("_lbPospm_2_MouseDown",this._lbPospm_2_MouseDown);
this.bind("_lbPospm_6_MouseDown",this._lbPospm_6_MouseDown);
this.bind("_lbPospm_10_MouseDown",this._lbPospm_10_MouseDown);
this.bind("_lbPospm_14_MouseDown",this._lbPospm_14_MouseDown);
this.bind("_lbPospm_18_MouseDown",this._lbPospm_18_MouseDown);
this.bind("_lbPospm_70_MouseDown",this._lbPospm_70_MouseDown);
this.bind("_lbPosam_3_MouseDown",this._lbPosam_3_MouseDown);
this.bind("_lbPosam_7_MouseDown",this._lbPosam_7_MouseDown);
this.bind("_lbPosam_11_MouseDown",this._lbPosam_11_MouseDown);
this.bind("_lbPosam_15_MouseDown",this._lbPosam_15_MouseDown);
this.bind("_lbPosam_19_MouseDown",this._lbPosam_19_MouseDown);
this.bind("_lbPosam_71_MouseDown",this._lbPosam_71_MouseDown);
this.bind("_lbPospm_3_MouseDown",this._lbPospm_3_MouseDown);
this.bind("_lbPospm_7_MouseDown",this._lbPospm_7_MouseDown);
this.bind("_lbPospm_11_MouseDown",this._lbPospm_11_MouseDown);
this.bind("_lbPospm_15_MouseDown",this._lbPospm_15_MouseDown);
this.bind("_lbPospm_19_MouseDown",this._lbPospm_19_MouseDown);
this.bind("_lbPospm_71_MouseDown",this._lbPospm_71_MouseDown);
this.bind("_lbPosam_72_MouseDown",this._lbPosam_72_MouseDown);
this.bind("_lbPosam_20_MouseDown",this._lbPosam_20_MouseDown);
this.bind("_lbPosam_24_MouseDown",this._lbPosam_24_MouseDown);
this.bind("_lbPosam_28_MouseDown",this._lbPosam_28_MouseDown);
this.bind("_lbPosam_32_MouseDown",this._lbPosam_32_MouseDown);
this.bind("_lbPosam_36_MouseDown",this._lbPosam_36_MouseDown);
this.bind("_lbPospm_72_MouseDown",this._lbPospm_72_MouseDown);
this.bind("_lbPospm_20_MouseDown",this._lbPospm_20_MouseDown);
this.bind("_lbPospm_24_MouseDown",this._lbPospm_24_MouseDown);
this.bind("_lbPospm_28_MouseDown",this._lbPospm_28_MouseDown);
this.bind("_lbPospm_32_MouseDown",this._lbPospm_32_MouseDown);
this.bind("_lbPospm_36_MouseDown",this._lbPospm_36_MouseDown);
this.bind("_lbPosam_73_MouseDown",this._lbPosam_73_MouseDown);
this.bind("_lbPosam_21_MouseDown",this._lbPosam_21_MouseDown);
this.bind("_lbPosam_25_MouseDown",this._lbPosam_25_MouseDown);
this.bind("_lbPosam_29_MouseDown",this._lbPosam_29_MouseDown);
this.bind("_lbPosam_33_MouseDown",this._lbPosam_33_MouseDown);
this.bind("_lbPosam_37_MouseDown",this._lbPosam_37_MouseDown);
this.bind("_lbPospm_73_MouseDown",this._lbPospm_73_MouseDown);
this.bind("_lbPospm_21_MouseDown",this._lbPospm_21_MouseDown);
this.bind("_lbPospm_25_MouseDown",this._lbPospm_25_MouseDown);
this.bind("_lbPospm_29_MouseDown",this._lbPospm_29_MouseDown);
this.bind("_lbPospm_33_MouseDown",this._lbPospm_33_MouseDown);
this.bind("_lbPospm_37_MouseDown",this._lbPospm_37_MouseDown);
this.bind("_lbPosam_74_MouseDown",this._lbPosam_74_MouseDown);
this.bind("_lbPosam_22_MouseDown",this._lbPosam_22_MouseDown);
this.bind("_lbPosam_26_MouseDown",this._lbPosam_26_MouseDown);
this.bind("_lbPosam_30_MouseDown",this._lbPosam_30_MouseDown);
this.bind("_lbPosam_34_MouseDown",this._lbPosam_34_MouseDown);
this.bind("_lbPosam_38_MouseDown",this._lbPosam_38_MouseDown);
this.bind("_lbPospm_74_MouseDown",this._lbPospm_74_MouseDown);
this.bind("_lbPospm_22_MouseDown",this._lbPospm_22_MouseDown);
this.bind("_lbPospm_26_MouseDown",this._lbPospm_26_MouseDown);
this.bind("_lbPospm_30_MouseDown",this._lbPospm_30_MouseDown);
this.bind("_lbPospm_34_MouseDown",this._lbPospm_34_MouseDown);
this.bind("_lbPospm_38_MouseDown",this._lbPospm_38_MouseDown);
this.bind("_lbPosam_75_MouseDown",this._lbPosam_75_MouseDown);
this.bind("_lbPosam_23_MouseDown",this._lbPosam_23_MouseDown);
this.bind("_lbPosam_27_MouseDown",this._lbPosam_27_MouseDown);
this.bind("_lbPosam_31_MouseDown",this._lbPosam_31_MouseDown);
this.bind("_lbPosam_35_MouseDown",this._lbPosam_35_MouseDown);
this.bind("_lbPosam_39_MouseDown",this._lbPosam_39_MouseDown);
this.bind("_lbPospm_75_MouseDown",this._lbPospm_75_MouseDown);
this.bind("_lbPospm_27_MouseDown",this._lbPospm_27_MouseDown);
this.bind("_lbPospm_31_MouseDown",this._lbPospm_31_MouseDown);
this.bind("_lbPospm_35_MouseDown",this._lbPospm_35_MouseDown);
this.bind("_lbPospm_23_MouseDown",this._lbPospm_23_MouseDown);
this.bind("_lbPospm_39_MouseDown",this._lbPospm_39_MouseDown);
this.bind("_lbPosam_76_MouseDown",this._lbPosam_76_MouseDown);
this.bind("_lbPospm_76_MouseDown",this._lbPospm_76_MouseDown);
this.bind("_lbPosam_40_MouseDown",this._lbPosam_40_MouseDown);
this.bind("_lbPosam_44_MouseDown",this._lbPosam_44_MouseDown);
this.bind("_lbPosam_48_MouseDown",this._lbPosam_48_MouseDown);
this.bind("_lbPosam_52_MouseDown",this._lbPosam_52_MouseDown);
this.bind("_lbPosam_56_MouseDown",this._lbPosam_56_MouseDown);
this.bind("_lbPosam_77_MouseDown",this._lbPosam_77_MouseDown);
this.bind("_lbPospm_40_MouseDown",this._lbPospm_40_MouseDown);
this.bind("_lbPospm_44_MouseDown",this._lbPospm_44_MouseDown);
this.bind("_lbPospm_48_MouseDown",this._lbPospm_48_MouseDown);
this.bind("_lbPospm_52_MouseDown",this._lbPospm_52_MouseDown);
this.bind("_lbPospm_56_MouseDown",this._lbPospm_56_MouseDown);
this.bind("_lbPospm_77_MouseDown",this._lbPospm_77_MouseDown);
this.bind("_lbPosam_41_MouseDown",this._lbPosam_41_MouseDown);
this.bind("_lbPosam_45_MouseDown",this._lbPosam_45_MouseDown);
this.bind("_lbPosam_49_MouseDown",this._lbPosam_49_MouseDown);
this.bind("_lbPosam_53_MouseDown",this._lbPosam_53_MouseDown);
this.bind("_lbPosam_57_MouseDown",this._lbPosam_57_MouseDown);
this.bind("_lbPosam_78_MouseDown",this._lbPosam_78_MouseDown);
this.bind("_lbPospm_41_MouseDown",this._lbPospm_41_MouseDown);
this.bind("_lbPospm_45_MouseDown",this._lbPospm_45_MouseDown);
this.bind("_lbPospm_49_MouseDown",this._lbPospm_49_MouseDown);
this.bind("_lbPospm_53_MouseDown",this._lbPospm_53_MouseDown);
this.bind("_lbPospm_57_MouseDown",this._lbPospm_57_MouseDown);
this.bind("_lbPospm_78_MouseDown",this._lbPospm_78_MouseDown);
this.bind("_lbPosam_42_MouseDown",this._lbPosam_42_MouseDown);
this.bind("_lbPosam_46_MouseDown",this._lbPosam_46_MouseDown);
this.bind("_lbPosam_50_MouseDown",this._lbPosam_50_MouseDown);
this.bind("_lbPosam_54_MouseDown",this._lbPosam_54_MouseDown);
this.bind("_lbPosam_58_MouseDown",this._lbPosam_58_MouseDown);
this.bind("_lbPosam_79_MouseDown",this._lbPosam_79_MouseDown);
this.bind("_lbPospm_42_MouseDown",this._lbPospm_42_MouseDown);
this.bind("_lbPospm_46_MouseDown",this._lbPospm_46_MouseDown);
this.bind("_lbPospm_50_MouseDown",this._lbPospm_50_MouseDown);
this.bind("_lbPospm_54_MouseDown",this._lbPospm_54_MouseDown);
this.bind("_lbPospm_58_MouseDown",this._lbPospm_58_MouseDown);
this.bind("_lbPospm_79_MouseDown",this._lbPospm_79_MouseDown);
this.bind("_lbPosam_43_MouseDown",this._lbPosam_43_MouseDown);
this.bind("_lbPosam_47_MouseDown",this._lbPosam_47_MouseDown);
this.bind("_lbPosam_51_MouseDown",this._lbPosam_51_MouseDown);
this.bind("_lbPosam_55_MouseDown",this._lbPosam_55_MouseDown);
this.bind("_lbPosam_59_MouseDown",this._lbPosam_59_MouseDown);
this.bind("_lbPosam_80_MouseDown",this._lbPosam_80_MouseDown);
this.bind("_lbPospm_43_MouseDown",this._lbPospm_43_MouseDown);
this.bind("_lbPospm_47_MouseDown",this._lbPospm_47_MouseDown);
this.bind("_lbPospm_51_MouseDown",this._lbPospm_51_MouseDown);
this.bind("_lbPospm_55_MouseDown",this._lbPospm_55_MouseDown);
this.bind("_lbPospm_59_MouseDown",this._lbPospm_59_MouseDown);
this.bind("_lbPospm_80_MouseDown",this._lbPospm_80_MouseDown);
this.bind("_lbPosam_60_MouseDown",this._lbPosam_60_MouseDown);
this.bind("_lbPosam_64_MouseDown",this._lbPosam_64_MouseDown);
this.bind("lstSA_SelectedIndexChanged",this.lstSA_SelectedIndexChanged);
this.bind("cmdBattWorkSheet_Click",this.cmdBattWorkSheet_Click);
this.bind("_lbPospm_60_MouseDown",this._lbPospm_60_MouseDown);
this.bind("_lbPospm_64_MouseDown",this._lbPospm_64_MouseDown);
this.bind("_lbPosam_61_MouseDown",this._lbPosam_61_MouseDown);
this.bind("_lbPosam_65_MouseDown",this._lbPosam_65_MouseDown);
this.bind("_lbPospm_61_MouseDown",this._lbPospm_61_MouseDown);
this.bind("_lbPospm_65_MouseDown",this._lbPospm_65_MouseDown);
this.bind("_lbPosam_62_MouseDown",this._lbPosam_62_MouseDown);
this.bind("_lbPosam_66_MouseDown",this._lbPosam_66_MouseDown);
this.bind("_lbPospm_62_MouseDown",this._lbPospm_62_MouseDown);
this.bind("_lbPospm_66_MouseDown",this._lbPospm_66_MouseDown);
this.bind("lbTo181_DragDrop",this.lbTo181_DragDrop);
this.bind("lbTo181_DragOver",this.lbTo181_DragOver);
this.bind("_lbPosam_63_MouseDown",this._lbPosam_63_MouseDown);
this.bind("_lbPosam_67_MouseDown",this._lbPosam_67_MouseDown);
this.bind("_lbPospm_63_MouseDown",this._lbPospm_63_MouseDown);
this.bind("_lbPospm_67_MouseDown",this._lbPospm_67_MouseDown);
this.bind("cmdPayRoll_Click",this.cmdPayRoll_Click);
this.bind("cmdMissing_Click",this.cmdMissing_Click);
this.bind("cmdRefresh_Click",this.cmdRefresh_Click);
this.bind("cmdSignOff_Click",this.cmdSignOff_Click);
this.bind("cmdListGray_Click",this.cmdListGray_Click);
this.bind("picTrash_DragDrop",this.picTrash_DragDrop);
this.bind("picTrash_DragOver",this.picTrash_DragOver);
this.bind("cmdBatt1_Click",this.cmdBatt1_Click);
this.bind("cmdAvailToWork_Click",this.cmdAvailToWork_Click);
this.bind("cmdNotes_Click",this.cmdNotes_Click);
this.bind("cmdClose_Click",this.cmdClose_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmBatt2SchedNew";
            }

            public loaded() {

            }

        
        public frmBatt2SchedNew_Activated(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

        public frmBatt2SchedNew_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmBatt2SchedNew",action:"frmBatt2SchedNew_Close"});
                e.preventDefault();
            }
            
        }
        public frmBatt2SchedNew_Deactivate(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuTimeCard_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuException_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuPrintDailyLeave_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuPrintAll_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuClose_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuEmpInfo_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuSenoirInq_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuImmune_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_transfer_req_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuPMCerts_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuPPE_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuIndSchedule_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuNewBatt1_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuBattalion3_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuBattalion4_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuEMS_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuHazmat_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuMarine_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuBattStaff_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuDispatch_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_watch_duty_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_Vacation_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_PMVacationSched_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_HZMVacationSched_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_FCCVacationSched_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuAssignReport_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuRoster_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuFRoster_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuDebitReport_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuProlist_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuSenior_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_emp_facility_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public MnuAuditDDHOL_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_IndivPayrollSO_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuIndTimeCard2_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu181_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu182_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuEMSPay_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuHazPay_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuMarPay_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuBattPay_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuDisPay_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuIndTimeCard_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuIndYearSched_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuDailyStaff_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuOvertime_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public MnuExtraOff_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_sa_report_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuShiftCal_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuTransfer_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuDailyLeave_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuAnnual_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_dailysickleave_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuIndLeave_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_sick_usage_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_PMLeave_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuDispatchLeave_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_HZMLeave_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public MnuCBStaffing_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_LeaveNoSched_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_staffdiscrepancy_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_PMCSRCalc_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_SchedNotes_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_PPEQuery_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_timecard_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuindannualpayroll_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnupersonnelsignoff_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_QuarterlyMinimumDrill_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_FCCMinDrills_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_ReadingAssign_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_OTEPReport_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_PMRecertReport_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_PMBaseStaReport_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_trainingtracker_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_IndTrainReport_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_IndPMRecert_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuALSProc_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuTrainQuery_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_TrainingQuerynew_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuCascade_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuPrintScreen_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuAbout_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_timecodes_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuTrainCodeHelp_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_HelpPrntScrn_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_payup_calc_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_payrolllegend_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_legend_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_IndLegend_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuLeave_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuNewSched_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuPayUp_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuPayDown_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuKOT_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuRover_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuDebit_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuTrade_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuCancelTrade_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuRemove_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuSendTo181_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuReport_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuTradeDetail_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnu_viewtimecard_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuSADetail_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public mnuReschedSA_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public Ctx_mnu182PopUp_Closing(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public Ctx_mnu182PopUp_Opening(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public calSchedDate_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboRovers_SelectionChangeCommitted(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboRovers_DragOver(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID}));            

        }
        public cboRovers_DragDrop(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID}));            

        }
        public cboDebit_SelectionChangeCommitted(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboDebit_DragOver(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID}));            

        }
        public cboDebit_DragDrop(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID}));            

        }
        public cmdToday_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public pnSelected_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPosam_DragDrop(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public lbPosam_DragOver(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public _lbPosam_0_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_4_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_8_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_12_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_16_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_68_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbPospm_DragDrop(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { 'objectForId': e.ControlUID, "index": $(e.srcElement || e.targetElement || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));            

        }
        public lbPospm_DragOver(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID, "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public _lbPospm_0_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_4_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_8_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_12_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_16_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_68_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_1_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_5_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_9_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_13_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_17_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_69_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_1_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_5_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_9_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_13_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_17_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_69_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_2_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_6_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_10_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_14_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_18_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_70_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_2_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_6_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_10_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_14_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_18_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_70_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_3_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_7_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_11_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_15_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_19_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_71_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_3_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_7_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_11_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_15_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_19_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_71_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_72_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_20_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_24_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_28_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_32_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_36_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_72_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_20_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_24_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_28_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_32_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_36_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_73_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_21_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_25_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_29_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_33_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_37_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_73_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_21_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_25_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_29_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_33_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_37_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_74_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_22_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_26_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_30_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_34_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_38_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_74_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_22_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_26_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_30_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_34_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_38_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_75_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_23_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_27_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_31_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_35_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_39_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_75_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_27_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_31_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_35_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_23_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_39_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_76_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_76_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_40_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_44_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_48_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_52_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_56_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_77_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_40_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_44_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_48_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_52_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_56_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_77_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_41_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_45_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_49_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_53_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_57_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_78_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_41_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_45_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_49_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_53_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_57_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_78_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_42_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_46_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_50_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_54_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_58_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_79_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_42_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_46_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_50_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_54_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_58_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_79_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_43_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_47_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_51_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_55_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_59_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_80_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_43_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_47_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_51_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_55_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_59_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_80_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_60_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_64_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
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
        public lstSA_SelectedIndexChanged(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdBattWorkSheet_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public _lbPospm_60_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_64_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_61_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_65_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_61_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_65_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_62_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_66_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_62_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_66_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public lbTo181_DragDrop(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID}));            

        }
        public lbTo181_DragOver(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID}));            

        }
        public _lbPosam_63_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPosam_67_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_63_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public _lbPospm_67_MouseDown(sender: frmBatt2SchedNew, action: string, e: any) {
            (window as any).app.mouseDragEvent = e; 
 	 	 	(window as any).app.disableLoading = true;
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")} ,() => {(window as any).app.disableLoading = false;}));            

        }
        public cmdPayRoll_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdMissing_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdRefresh_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdSignOff_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdListGray_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public picTrash_DragDrop(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID}));            

        }
        public picTrash_DragOver(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, {'objectForId':e.ControlUID}));            

        }
        public cmdBatt1_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAvailToWork_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdNotes_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmBatt2SchedNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

