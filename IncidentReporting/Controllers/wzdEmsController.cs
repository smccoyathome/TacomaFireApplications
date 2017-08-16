using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident.Controllers
{

	public class wzdEmsController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult cboRoute_SelectionChangeCommitted(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.cboRoute_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboRoute_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.cboRoute_Leave(logic.ViewModel.cboRoute[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboRate_SelectionChangeCommitted(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.cboRate_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboRate_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.cboRate_Leave(logic.ViewModel.cboRate[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult txtAmount_TextChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.txtAmount_TextChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboSite_SelectionChangeCommitted(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.cboSite_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboSite_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.cboSite_Leave(logic.ViewModel.cboSite[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboGauge_SelectionChangeCommitted(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.cboGauge_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboGauge_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.cboGauge_Leave(logic.ViewModel.cboGauge[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult chkNoVitals_CheckStateChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.chkNoVitals_CheckStateChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult txtTime_TextChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.txtTime_TextChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult txtTime_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.txtTime_Leave(logic.ViewModel.txtTime[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboVitalsPosition_SelectionChangeCommitted(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.cboVitalsPosition_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboVitalsPosition_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.cboVitalsPosition_Leave(logic.ViewModel.cboVitalsPosition[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult txtRespiration_TextChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.txtRespiration_TextChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult txtPulse_TextChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.txtPulse_TextChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboECG_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.cboECG_Leave(logic.ViewModel.cboECG[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult txtSystolic_TextChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.txtSystolic_TextChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult txtDiastolic_TextChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.txtDiastolic_TextChanged(logic.ViewModel.txtDiastolic[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult chkPalp_CheckStateChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.chkPalp_CheckStateChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult txtGlucose_TextChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.txtGlucose_TextChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult txtPulseOxy_TextChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.txtPulseOxy_TextChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult txtPerOxy_TextChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.txtPerOxy_TextChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboEyes_SelectionChangeCommitted(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.cboEyes_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboEyes_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.cboEyes_Leave(logic.ViewModel.cboEyes[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboVerbal_SelectionChangeCommitted(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.cboVerbal_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboVerbal_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.cboVerbal_Leave(logic.ViewModel.cboVerbal[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboMotor_SelectionChangeCommitted(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.cboMotor_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboMotor_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.cboMotor_Leave(logic.ViewModel.cboMotor[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboMechCode_SelectionChangeCommitted(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboMechCode_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboMechCode_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboMechCode_Leave(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboInjuryType_SelectionChangeCommitted(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboInjuryType_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboInjuryType_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboInjuryType_Leave(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboBodyPart_SelectionChangeCommitted(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboBodyPart_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboBodyPart_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboBodyPart_Leave(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult chkMajTrauma_CheckStateChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.chkMajTrauma_CheckStateChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboPrimaryIllness_SelectionChangeCommitted(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboPrimaryIllness_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboPrimaryIllness_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboPrimaryIllness_Leave(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optPupils_CheckedChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.optPupils_CheckedChanged(logic.ViewModel.optPupils[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optLevelOfConsciouness_CheckedChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.optLevelOfConsciouness_CheckedChanged(logic.ViewModel.optLevelOfConsciouness[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optRespiratoryEffort_CheckedChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.optRespiratoryEffort_CheckedChanged(logic.ViewModel.optRespiratoryEffort[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optSeverity_CheckedChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.optSeverity_CheckedChanged(logic.ViewModel.optSeverity[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboTreatmentAuth_SelectionChangeCommitted(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboTreatmentAuth_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboTreatmentAuth_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboTreatmentAuth_Leave(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult txtExtricationTime_TextChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.txtExtricationTime_TextChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboMedications_SelectionChangeCommitted(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboMedications_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboMedications_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboMedications_Leave(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult txtDosage_TextChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.txtDosage_TextChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdAddMedications_Click(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdAddMedications_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdRemoveMedication_Click(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdRemoveMedication_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult FDCaresBtn_Click(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.FDCaresBtn_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboIncidentLocation_SelectionChangeCommitted(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboIncidentLocation_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboIncidentLocation_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboIncidentLocation_Leave(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult txtIncidentZipcode_TextChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.txtIncidentZipcode_TextChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboIncidentSetting_SelectionChangeCommitted(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboIncidentSetting_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboIncidentSetting_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboIncidentSetting_Leave(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboResearchCode_SelectionChangeCommitted(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboResearchCode_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboResearchCode_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboResearchCode_Leave(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboBaseStationContact_SelectionChangeCommitted(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboBaseStationContact_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboBaseStationContact_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboBaseStationContact_Leave(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboTransportBy_SelectionChangeCommitted(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboTransportBy_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboTransportBy_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboTransportBy_Leave(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboTransportTo_SelectionChangeCommitted(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboTransportTo_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboTransportTo_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboTransportTo_Leave(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboTransportFrom_SelectionChangeCommitted(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboTransportFrom_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboTransportFrom_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboTransportFrom_Leave(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult txtMileage_TextChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.txtMileage_TextChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboHospitalChosenBy_SelectionChangeCommitted(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboHospitalChosenBy_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboHospitalChosenBy_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboHospitalChosenBy_Leave(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboCPRPerformedBy_SelectionChangeCommitted(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboCPRPerformedBy_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboCPRPerformedBy_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboCPRPerformedBy_Leave(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optArrestToCPR_CheckedChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.optArrestToCPR_CheckedChanged(logic.ViewModel.optArrestToCPR[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClear1_Click(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdClear1_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optArrestToALS_CheckedChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.optArrestToALS_CheckedChanged(logic.ViewModel.optArrestToALS[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClear2_Click(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdClear2_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdAddCPR_Click(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdAddCPR_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optArrestToShock_CheckedChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.optArrestToShock_CheckedChanged(logic.ViewModel.optArrestToShock[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClear3_Click(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdClear3_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdRemoveCPR_Click(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdRemoveCPR_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult txtFirstName_TextChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.txtFirstName_TextChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult txtLastName_TextChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.txtLastName_TextChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboState_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboState_Leave(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult txtZipCode_TextChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.txtZipCode_TextChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

        public System.Web.Mvc.ActionResult dpBirthdate_Click(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
        {
            logic.ViewModel = viewFromClient;
            logic.dpBirthdate_Click(null, null);
            return new UpgradeHelpers.WebMap.Server.AppChanges();
        }

        public System.Web.Mvc.ActionResult txtPatientAge_TextChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.txtPatientAge_TextChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboPatientAgeUnits_SelectionChangeCommitted(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboPatientAgeUnits_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboPatientAgeUnits_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboPatientAgeUnits_Leave(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optGender_CheckedChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.optGender_CheckedChanged(logic.ViewModel.optGender[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboRace_SelectionChangeCommitted(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboRace_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboRace_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboRace_Leave(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult txtTraumaID_TextChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.txtTraumaID_TextChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboProtectiveDevice_SelectionChangeCommitted(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboProtectiveDevice_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboProtectiveDevice_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboProtectiveDevice_Leave(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboPatientLocation_SelectionChangeCommitted(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboPatientLocation_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboPatientLocation_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboPatientLocation_Leave(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lstTrauma1_SelectedIndexChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.lstTrauma1_SelectedIndexChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lstTrauma3_SelectedIndexChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.lstTrauma3_SelectedIndexChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lstTrauma2_SelectedIndexChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.lstTrauma2_SelectedIndexChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboALSProcedures_SelectionChangeCommitted(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboALSProcedures_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboALSProcedures_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboALSProcedures_Leave(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult txtAttempts_TextChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.txtAttempts_TextChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboALSPersonnel_SelectionChangeCommitted(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboALSPersonnel_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboALSPersonnel_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboALSPersonnel_Leave(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdAddALS_Click(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdAddALS_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdRemoveALSProcedures_Click(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdRemoveALSProcedures_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult chkCPRPerformed_CheckStateChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.chkCPRPerformed_CheckStateChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboBLSProcedures_SelectionChangeCommitted(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboBLSProcedures_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboBLSProcedures_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboBLSProcedures_Leave(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult txtOtherBLSProcedures_TextChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.txtOtherBLSProcedures_TextChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lstBLSPersonnel_SelectedIndexChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.lstBLSPersonnel_SelectedIndexChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdAddBLS_Click(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdAddBLS_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdRemoveBLSProcedures_Click(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdRemoveBLSProcedures_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optActionTaken_CheckedChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.optActionTaken_CheckedChanged(logic.ViewModel.optActionTaken[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult txtBFirstName_TextChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.txtBFirstName_TextChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult txtBLastName_TextChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.txtBLastName_TextChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult txtBBirthdate_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.txtBBirthdate_Leave(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult txtAge_TextChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.txtAge_TextChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboAgeUnits_SelectionChangeCommitted(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboAgeUnits_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboAgeUnits_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboAgeUnits_Leave(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optEMSGender_CheckedChanged(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.optEMSGender_CheckedChanged(logic.ViewModel.optEMSGender[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboEMSRace_SelectionChangeCommitted(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboEMSRace_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboEMSRace_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboEMSRace_Leave(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboServiceProvided_SelectionChangeCommitted(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboServiceProvided_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboServiceProvided_Leave(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboServiceProvided_Leave(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdSave_Click(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdSave_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdSaveIncomplete_Click(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdSaveIncomplete_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdAbandon_Click(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdAbandon_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult NavButton_Click(TFDIncident.ViewModels.wzdEmsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.NavButton_Click(logic.ViewModel.NavButton[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

        public System.Web.Mvc.ActionResult Index()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
			return View();
		}

		public TFDIncident.wzdEms logic { get; set; }

	}

}