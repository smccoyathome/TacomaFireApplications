using Microsoft.VisualBasic;
using System;
using System.Globalization;
using UpgradeHelpers.DB.ADO;
using UpgradeStubs;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident
{

	public partial class frmEMSReport
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.frmEMSReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmEMSReport));
			if ( Shared.m_vb6FormDefInstance == null)
			{
				if ( Shared.m_InitializingDefInstance)
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
			ReLoadForm(false);
		}


		private void frmEMSReport_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		private void UpdateHIPAA(int iAccessType)
		{
			//Update HIPAA Records Access Table
			TFDIncident.clsHIPAA cHIPAA = Container.Resolve< clsHIPAA>();

			cHIPAA.HIPAAPatientID = ViewModel.PatientID;
			cHIPAA.AccessDate = DateTime.Now.ToString("M/d/yyyy HH:mm");
			cHIPAA.AccessBy = IncidentMain.Shared.gCurrUser;
			cHIPAA.RecordsAccessType = iAccessType;
			cHIPAA.ReleasedToName = "";
			cHIPAA.ReleasedToAddress1 = "";
			cHIPAA.ReleasedToAddress2 = "";
			cHIPAA.ReleasedReason = "";
			cHIPAA.AddEMSRecordsAccess();

		}

		private void EditBasicBirthdate()
		{
			//Edit Birthdate
			string sBirthDate = "";
			System.DateTime dBirthDate = DateTime.FromOADate(0);
			int Age = 0;
			ViewModel.FirstTime = -1;

			if (!Information.IsDate(ViewModel.txtBBirthdate.Text))
			{
				ViewModel.txtBBirthdate.Text = "__/__/____";
				ViewModel.txtAge.Text = "";
				ViewModel.cboAgeUnits.SelectedIndex = -1;
			}
			else
			{
				sBirthDate = ViewModel.txtBBirthdate.Text;
				System.DateTime TempDate = DateTime.FromOADate(0);
				dBirthDate = DateTime.Parse((DateTime.TryParse(sBirthDate, out TempDate)) ? TempDate.ToString("M/d/yyyy") : sBirthDate);
				if (dBirthDate > DateTime.Now)
				{
					ViewModel.txtBBirthdate.Text = "__/__/____";
					return;
				}
				Age = (int) DateAndTime.DateDiff("d", DateTime.Parse(sBirthDate), DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
				if (Age < 30)
				{
					ViewModel.txtAge.Text = Age.ToString();
					for (int i = 0; i <= ViewModel.cboAgeUnits.Items.Count - 1; i++)
					{
						if ( ViewModel.cboAgeUnits.GetItemData(i) == 3)
						{ //Age Unit - Days

							ViewModel.cboAgeUnits.SelectedIndex = i;
							break;
						}
					}
				}
				else
				{
					Age = (int) DateAndTime.DateDiff("m", DateTime.Parse(sBirthDate), DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
					if (Age < 12)
					{
						if (dBirthDate.AddMonths(Age) > DateTime.Now)
						{
							Age--;
						}
						ViewModel.txtAge.Text = Age.ToString();
						for (int i = 0; i <= ViewModel.cboAgeUnits.Items.Count - 1; i++)
						{
							if ( ViewModel.cboAgeUnits.GetItemData(i) == 2)
							{ //AgeUnit - Months

								ViewModel.cboAgeUnits.SelectedIndex = i;
								break;
							}
						}
					}
					else
					{
						Age = (int) DateAndTime.DateDiff("yyyy", DateTime.Parse(sBirthDate), DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
						if (dBirthDate.AddYears(Age) > DateTime.Now)
						{
							Age--;
						}
						if (Age > 150)
						{
							ViewManager.ShowMessage("You Have Indicated an Unreasonable Age", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							ViewModel.txtBBirthdate.Text = "__/__/____";
						}
						else
						{
							ViewModel.txtAge.Text = Age.ToString();
							for (int i = 0; i <= ViewModel.cboAgeUnits.Items.Count - 1; i++)
							{
								if ( ViewModel.cboAgeUnits.GetItemData(i) == 1)
								{ //AgeUnit - Years

									ViewModel.cboAgeUnits.SelectedIndex = i;
									break;
								}
							}
						}
					}
				}
			}
			ViewModel.FirstTime = 0;

		}


		private void LoadNarration(int lNarrID)
		{
			//Load Narration Author combo and display requested Narration
			TFDIncident.clsEMS EMSReport = Container.Resolve< clsEMS>();
			string SaveText = "";
			string SaveAuthor = "";
			int SaveID = 0;
			int CurrNarr = 0;
			ViewModel.FirstTime = -1;
			ViewModel.rtxNarration.Text = "";
			ViewModel.lbNarrID.Text = "";
			ViewModel.lbNarrAuthor.Text = "";
			ViewModel.cboNarrList.Items.Clear();

			if (EMSReport.GetEMSPatientNarrationRS(ViewModel.PatientID) != 0)
			{
				SaveID = Convert.ToInt32(EMSReport.EMSPatientNarration["ems_narration_id"]);
				SaveAuthor = IncidentMain.Clean(EMSReport.EMSPatientNarration["name_full"]);
				SaveText = Convert.ToString(EMSReport.EMSPatientNarration["narration_text"]);

				while(!EMSReport.EMSPatientNarration.EOF)
				{
					ViewModel.cboNarrList.AddItem(IncidentMain.Clean(EMSReport.EMSPatientNarration["name_full"]));
					ViewModel.cboNarrList.SetItemData(ViewModel.cboNarrList.GetNewIndex(), Convert.ToInt32(EMSReport.EMSPatientNarration["ems_narration_id"]));

					if (lNarrID == Convert.ToDouble(EMSReport.EMSPatientNarration["ems_narration_id"]))
					{
						ViewModel.lbNarrID.Text = Convert.ToString(EMSReport.EMSPatientNarration["ems_narration_id"]);
						ViewModel.rtxNarration.Text = Convert.ToString(EMSReport.EMSPatientNarration["narration_text"]);
						ViewModel.lbNarrAuthor.Text = IncidentMain.Clean(EMSReport.EMSPatientNarration["name_full"]);
						if (IncidentMain.Clean(EMSReport.EMSPatientNarration["narration_by"]) != IncidentMain.Shared.gCurrUser)
						{
							ViewModel.rtxNarration.Enabled = false;
						}
						CurrNarr = ViewModel.cboNarrList.GetNewIndex();
					}
					else if (IncidentMain.Clean(EMSReport.EMSPatientNarration["narration_by"]) == IncidentMain.Shared.gCurrUser)
					{
						ViewModel.cmdAddNarration.Enabled = false;
						if (lNarrID == 0)
						{
							ViewModel.lbNarrID.Text = Convert.ToString(EMSReport.EMSPatientNarration["ems_narration_id"]);
							ViewModel.rtxNarration.Text = Convert.ToString(EMSReport.EMSPatientNarration["narration_text"]);
							ViewModel.lbNarrAuthor.Text = IncidentMain.Clean(EMSReport.EMSPatientNarration["name_full"]);
							ViewModel.rtxNarration.Enabled = true;
							CurrNarr = ViewModel.cboNarrList.GetNewIndex();
						}
					}

					EMSReport.EMSPatientNarration.MoveNext();
				};
				if ( ViewModel.lbNarrID.Text == "")
				{
					ViewModel.lbNarrID.Text = SaveID.ToString();
					ViewModel.lbNarrAuthor.Text = SaveAuthor;
					ViewModel.rtxNarration.Text = SaveText;
					ViewModel.rtxNarration.Enabled = false;
					ViewModel.cboNarrList.SelectedIndex = 0;
				}
				else
				{
					ViewModel.cboNarrList.SelectedIndex = CurrNarr;
				}
			}

			//Check for existing Patient FDCares Referral for this incident
			ViewModel.FDCaresBtn.Enabled = !(EMSReport.GetFDCaresIncidentPatient(ViewModel.CurrIncident, ViewModel.PatientID) != 0);
			ViewModel.FirstTime = 0;
			ViewModel.NarrationUpdated = 0;

		}

		private void SaveNarration()
		{
			//Save EMS Patient Narration
			TFDIncident.clsEMS EMSReport = Container.Resolve< clsEMS>();

			EMSReport.NarrPatientID = ViewModel.PatientID;
			EMSReport.NarrationText = ViewModel.rtxNarration.Text;
			EMSReport.NarrationBy = IncidentMain.Shared.gCurrUser;
			EMSReport.NarrationDate = DateTime.Now.ToString("MM/dd/yyyy");
			if ( ViewModel.lbNarrID.Text == "")
			{
				if (~EMSReport.AddEMSPatientNarration() != 0)
				{
					ViewManager.ShowMessage("Error Attempting to Add EMS Patient Narration", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				}
				else
				{
					ViewModel.NarrationUpdated = 0;
					//Update HIPAA Record Access
					if (IncidentMain.Shared.gHIPAAState == IncidentMain.HIPAARO)
					{
						IncidentMain.Shared.gHIPAAState = IncidentMain.HIPAACHANGE;
					}
					else if (IncidentMain.Shared.gHIPAAState == IncidentMain.HIPAAPRINT)
					{
						IncidentMain.Shared.gHIPAAState = IncidentMain.HIPAACHGPRT;
					}
				}
			}
			else
			{
				EMSReport.EMSNarrationID = Convert.ToInt32(Conversion.Val(ViewModel.lbNarrID.Text));
				if (~EMSReport.UpdateEMSPatientNarration() != 0)
				{
					ViewManager.ShowMessage("Error Attempting to Update EMS Patient Narration", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				}
				else
				{
					ViewModel.NarrationUpdated = 0;
					//Update HIPAA Record Access
					if (IncidentMain.Shared.gHIPAAState == IncidentMain.HIPAARO)
					{
						IncidentMain.Shared.gHIPAAState = IncidentMain.HIPAACHANGE;
					}
					else if (IncidentMain.Shared.gHIPAAState == IncidentMain.HIPAAPRINT)
					{
						IncidentMain.Shared.gHIPAAState = IncidentMain.HIPAACHGPRT;
					}
				}
			}

		}

		private void EditBirthdate()
		{
			//Edit Birthdate
			string sBirthDate = "";
			System.DateTime dBirthDate = DateTime.FromOADate(0);
			int Age = 0;
			ViewModel.FirstTime = -1;

			if (!Information.IsDate(ViewModel.mskBirthdate.Text))
			{
				ViewModel.mskBirthdate.Text = "__/__/____";
				ViewModel.txtPatientAge.Text = "";
				ViewModel.cboPatientAgeUnits.SelectedIndex = -1;
			}
			else
			{
				sBirthDate = ViewModel.mskBirthdate.Text;
				System.DateTime TempDate = DateTime.FromOADate(0);
				dBirthDate = DateTime.Parse((DateTime.TryParse(sBirthDate, out TempDate)) ? TempDate.ToString("M/d/yyyy") : sBirthDate);
				if (dBirthDate > DateTime.Now)
				{
					ViewModel.mskBirthdate.Text = "__/__/____";
					return;
				}
				Age = (int) DateAndTime.DateDiff("d", DateTime.Parse(sBirthDate), DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
				if (Age < 30)
				{
					ViewModel.txtPatientAge.Text = Age.ToString();
					for (int i = 0; i <= ViewModel.cboPatientAgeUnits.Items.Count - 1; i++)
					{
						if ( ViewModel.cboPatientAgeUnits.GetItemData(i) == 3)
						{ //Age Unit - Days

							ViewModel.cboPatientAgeUnits.SelectedIndex = i;
							break;
						}
					}
				}
				else
				{
					Age = (int) DateAndTime.DateDiff("m", DateTime.Parse(sBirthDate), DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
					if (Age < 12)
					{
						if (dBirthDate.AddMonths(Age) > DateTime.Now)
						{
							Age--;
						}
						ViewModel.txtPatientAge.Text = Age.ToString();
						for (int i = 0; i <= ViewModel.cboPatientAgeUnits.Items.Count - 1; i++)
						{
							if ( ViewModel.cboPatientAgeUnits.GetItemData(i) == 2)
							{ //AgeUnit - Months

								ViewModel.cboPatientAgeUnits.SelectedIndex = i;
								break;
							}
						}
					}
					else
					{
						Age = (int) DateAndTime.DateDiff("yyyy", DateTime.Parse(sBirthDate), DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
						if (dBirthDate.AddYears(Age) > DateTime.Now)
						{
							Age--;
						}
						if (Age > 150)
						{
							ViewManager.ShowMessage("You Have Indicated an Unreasonable Age", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							ViewModel.mskBirthdate.Text = "__/__/____";
						}
						else
						{
							ViewModel.txtPatientAge.Text = Age.ToString();
							for (int i = 0; i <= ViewModel.cboPatientAgeUnits.Items.Count - 1; i++)
							{
								if ( ViewModel.cboPatientAgeUnits.GetItemData(i) == 1)
								{ //AgeUnit - Years

									ViewModel.cboPatientAgeUnits.SelectedIndex = i;
									break;
								}
							}
						}
					}
				}
			}
			ViewModel.FirstTime = 0;

		}

		private void LockScreen()
		{
			//Lock Screen Controls for Readonly Access
			ViewModel.FirstTime = -1;
			ViewModel.cmdSave[0].Enabled = false;
			ViewModel.cmdSave[1].Enabled = false;
			ViewModel.cmdSave[0].Visible = false;
			ViewModel.cmdSave[1].Visible = false;
			//UPGRADE_ISSUE: (2064) ComboBox property cboIncidentLocation.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.cboIncidentLocation.setLocked(true);
			ViewModel.txtIncidentZipcode.Enabled = false;
			//UPGRADE_ISSUE: (2064) ComboBox property cboIncidentSetting.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.cboIncidentSetting.setLocked(true);
			//UPGRADE_ISSUE: (2064) ComboBox property cboResearchCode.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.cboResearchCode.setLocked(true);
			ViewModel.rtxNarration.Enabled = false;
			ViewModel.FDCaresBtn.Enabled = false;

			switch( ViewModel.ActionTaken)
			{
				case 3 : case 4 : case 5 :
					ViewModel.txtAge.Enabled = false;
					//UPGRADE_ISSUE: (2064) ComboBox property cboAgeUnits.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
					ViewModel.cboAgeUnits.setLocked(true);
					ViewModel.optEMSGender[0].Enabled = false;
					ViewModel.optEMSGender[1].Enabled = false;
					//UPGRADE_ISSUE: (2064) ComboBox property cboEMSRace.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
					ViewModel.cboEMSRace.setLocked(true);
					ViewModel.optEMSEthnicity[0].Enabled = false;
					ViewModel.optEMSEthnicity[1].Enabled = false;
					//UPGRADE_ISSUE: (2064) ComboBox property cboServiceProvided.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
					ViewModel.cboServiceProvided.setLocked(true);

					break;
				default:
					ViewModel.txtFirstName.Enabled = false;
					ViewModel.txtLastName.Enabled = false;
					ViewModel.txtMI.Enabled = false;
					ViewModel.mskSSN.Enabled = false;
					ViewModel.txtBillingAddress.Enabled = false;
					ViewModel.txtCity.Enabled = false;
					ViewModel.cboState.Enabled = false;
					ViewModel.txtZipCode.Enabled = false;
					ViewModel.txtHomePhone.Enabled = false;
					ViewModel.mskBirthdate.Enabled = false;
					ViewModel.txtPatientAge.Enabled = false;
					//UPGRADE_ISSUE: (2064) ComboBox property cboPatientAgeUnits.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
					ViewModel.cboPatientAgeUnits.setLocked(true);
					ViewModel.optGender[0].Enabled = false;
					ViewModel.optGender[1].Enabled = false;
					//UPGRADE_ISSUE: (2064) ComboBox property cboRace.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
					ViewModel.cboRace.setLocked(true);
					ViewModel.optEthnicity[0].Enabled = false;
					ViewModel.optEthnicity[1].Enabled = false;
					ViewModel.chkDNR.Enabled = false;
					ViewModel.lstPossibleFactors.Enabled = false;
					ViewModel.lstPriorMedicalHistory.Enabled = false;
					//UPGRADE_ISSUE: (2064) ComboBox property cboMechCode.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
					ViewModel.cboMechCode.setLocked(true);
					//UPGRADE_ISSUE: (2064) ComboBox property cboInjuryType.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
					ViewModel.cboInjuryType.setLocked(true);
					//UPGRADE_ISSUE: (2064) ComboBox property cboBodyPart.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
					ViewModel.cboBodyPart.setLocked(true);
					ViewModel.chkMajTrauma.Enabled = false;
					//UPGRADE_ISSUE: (2064) ComboBox property cboPrimaryIllness.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
					ViewModel.cboPrimaryIllness.setLocked(true);
					ViewModel.lstSecondaryIllness.Enabled = false;
					ViewModel.optPupils[0].Enabled = false;
					ViewModel.optPupils[1].Enabled = false;
					ViewModel.optLevelOfConsciouness[0].Enabled = false;
					ViewModel.optLevelOfConsciouness[1].Enabled = false;
					ViewModel.optLevelOfConsciouness[2].Enabled = false;
					ViewModel.optRespiratoryEffort[0].Enabled = false;
					ViewModel.optRespiratoryEffort[1].Enabled = false;
					ViewModel.optRespiratoryEffort[2].Enabled = false;
					ViewModel.optSeverity[0].Enabled = false;
					ViewModel.optSeverity[1].Enabled = false;
					ViewModel.optSeverity[2].Enabled = false;
					for (int i = 0; i <= 4; i++)
					{
						ViewModel.txtTime[i].Enabled = false;
						//UPGRADE_ISSUE: (2064) ComboBox property cboVitalsPosition.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.cboVitalsPosition[i].setLocked(true);
						ViewModel.txtPulse[i].Enabled = false;
						ViewModel.txtRespiration[i].Enabled = false;
						ViewModel.txtSystolic[i].Enabled = false;
						ViewModel.txtDiastolic[i].Enabled = false;
						ViewModel.chkPalp[i].Enabled = false;
						ViewModel.txtGlucose[i].Enabled = false;
						ViewModel.txtPulseOxy[i].Enabled = false;
						ViewModel.txtPerOxy[i].Enabled = false;
						//UPGRADE_ISSUE: (2064) ComboBox property cboECG.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.cboECG[i].setLocked(true);
						//UPGRADE_ISSUE: (2064) ComboBox property cboEyes.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.cboEyes[i].setLocked(true);
						//UPGRADE_ISSUE: (2064) ComboBox property cboVerbal.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.cboVerbal[i].setLocked(true);
						//UPGRADE_ISSUE: (2064) ComboBox property cboMotor.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.cboMotor[i].setLocked(true);
					}
					ViewModel.chkCPRPerformed.Enabled = false;
					ViewModel.lstBLSPersonnel.Enabled = false;
					//UPGRADE_ISSUE: (2064) ComboBox property cboBLSProcedures.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
					ViewModel.cboBLSProcedures.setLocked(true);
					ViewModel.txtOtherBLSProcedures.Enabled = false;
					ViewModel.cmdAddBLS.Enabled = false;
					ViewModel.lstBLSProcedures.Enabled = false;
					ViewModel.cmdRemoveBLSProcedures.Enabled = false;
					//UPGRADE_ISSUE: (2064) ComboBox property cboALSPersonnel.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
					ViewModel.cboALSPersonnel.setLocked(true);
					//UPGRADE_ISSUE: (2064) ComboBox property cboALSProcedures.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
					ViewModel.cboALSProcedures.setLocked(true);
					ViewModel.txtAttempts.Enabled = false;
					ViewModel.chkSuccessful.Enabled = false;
					ViewModel.txtOtherALSProcedures.Enabled = false;
					ViewModel.cmdAddALS.Enabled = false;
					ViewModel.lstALSProcedures.Enabled = false;
					ViewModel.cmdRemoveALSProcedures.Enabled = false;
					//UPGRADE_ISSUE: (2064) ComboBox property cboTreatmentAuth.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
					ViewModel.cboTreatmentAuth.setLocked(true);
					ViewModel.txtExtricationTime.Enabled = false;
					ViewModel.chkSalineLock.Enabled = false;
					//UPGRADE_ISSUE: (2064) ComboBox property cboMedications.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
					ViewModel.cboMedications.setLocked(true);
					ViewModel.txtDosage.Enabled = false;
					ViewModel.cmdAddMedications.Enabled = false;
					ViewModel.lstMedications.Enabled = false;
					ViewModel.cmdRemoveMedication.Enabled = false;
					for (int i = 0; i <= 4; i++)
					{
						//UPGRADE_ISSUE: (2064) ComboBox property cboGauge.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.cboGauge[i].setLocked(true);
						//UPGRADE_ISSUE: (2064) ComboBox property cboRoute.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.cboRoute[i].setLocked(true);
						//UPGRADE_ISSUE: (2064) ComboBox property cboRate.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.cboRate[i].setLocked(true);
						ViewModel.txtAmount[i].Enabled = false;
						ViewModel.cboSite[i].Enabled = false;
					}
					//UPGRADE_ISSUE: (2064) ComboBox property cboBaseStationContact.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
					ViewModel.cboBaseStationContact.setLocked(true);
					ViewModel.optMDorRN[0].Enabled = false;
					ViewModel.optMDorRN[1].Enabled = false;
					ViewModel.optMDorRN[2].Enabled = false;
					//UPGRADE_ISSUE: (2064) ComboBox property cboTransportTo.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
					ViewModel.cboTransportTo.setLocked(true);
					//UPGRADE_ISSUE: (2064) ComboBox property cboTransportFrom.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
					ViewModel.cboTransportFrom.setLocked(true);
					ViewModel.txtMileage.Enabled = false;
					ViewModel.chkDiverted.Enabled = false;
					//UPGRADE_ISSUE: (2064) ComboBox property cboHospitalChosenBy.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
					ViewModel.cboHospitalChosenBy.setLocked(true);
					ViewModel.txtTraumaID.Enabled = false;
					//UPGRADE_ISSUE: (2064) ComboBox property cboProtectiveDevice.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
					ViewModel.cboProtectiveDevice.setLocked(true);
					//UPGRADE_ISSUE: (2064) ComboBox property cboPatientLocation.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
					ViewModel.cboPatientLocation.setLocked(true);
					ViewModel.lstTrauma1.Enabled = false;
					ViewModel.lstTrauma2.Enabled = false;
					ViewModel.lstTrauma3.Enabled = false;
					//UPGRADE_ISSUE: (2064) ComboBox property cboCPRPerformedBy.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
					ViewModel.cboCPRPerformedBy.setLocked(true);
					ViewModel.chkCPRTrained.Enabled = false;
					ViewModel.chkWitnessedArrest.Enabled = false;
					ViewModel.cmdAddCPR.Enabled = false;
					ViewModel.lstCPRPerformedBy.Enabled = false;
					ViewModel.cmdRemoveCPR.Enabled = false;
					ViewModel.chkPulseRestored.Enabled = false;
					for (int i = 0; i <= 3; i++)
					{
						ViewModel.optArrestToCPR[i].Enabled = false;
						ViewModel.optArrestToALS[i].Enabled = false;
						ViewModel.optArrestToShock[i].Enabled = false;
					}
					break;
			}
			ViewModel.FirstTime = 0;

		}

		private int SaveEMSReport(int iUpdateType)
		{
			//Save EMSReport
			int result = 0;
			TFDIncident.clsEMS EMSReport = Container.Resolve< clsEMS>();
			TFDIncident.clsEMSCodes EMSCodes = Container.Resolve< clsEMSCodes>();
			TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();
			TFDIncident.clsReportLog ReportLog = Container.Resolve< clsReportLog>();
			string DateWork = "", HourWork = "";

			result = -1;
			int UpdateSwitch = 0;
			//*************************************************
			//**     EMSPatientContact Record
			//*************************************************
			EMSReport.GetEMSPatientContact(ViewModel.PatientID);
			//This retrieves non-edit data ie. PatientID, IncidentID, ActionTaken
			IncidentCL.GetIncident(ViewModel.CurrIncident);
			EMSReport.IncidentType = ViewModel.EMSType;
			switch( ViewModel.ActionTaken)
			{ // Get data from Patient or Basic tab
				case 3 : case 4 : case 5 :
					if ( ViewModel.optEMSGender[0].Checked)
					{
						EMSReport.Gender = 1;
					}
					else if ( ViewModel.optEMSGender[1].Checked)
					{
						EMSReport.Gender = 2;
					}
					else
					{
						EMSReport.Gender = 0;
					}
					EMSReport.Age = Convert.ToInt32(Conversion.Val(ViewModel.txtAge.Text));
					if ( ViewModel.cboAgeUnits.SelectedIndex == -1)
					{
						EMSReport.AgeUnit = 0;
					}
					else
					{
						EMSReport.AgeUnit = ViewModel.cboAgeUnits.GetItemData(ViewModel.cboAgeUnits.SelectedIndex);
					}
					if ( ViewModel.cboEMSRace.SelectedIndex == -1)
					{
						EMSReport.Race = 0;
					}
					else
					{
						EMSReport.Race = ViewModel.cboEMSRace.GetItemData(ViewModel.cboEMSRace.SelectedIndex);
					}
					if ( ViewModel.optEMSEthnicity[0].Checked)
					{
						EMSReport.Ethnicity = 3;
					}
					else if ( ViewModel.optEMSEthnicity[1].Checked)
					{
						EMSReport.Ethnicity = 4;
					}
					else
					{
						EMSReport.Ethnicity = 0;
					}
					if ( ViewModel.cboServiceProvided.SelectedIndex == -1)
					{
						EMSReport.ServiceProvided = 0;
					}
					else
					{
						EMSReport.ServiceProvided = ViewModel.cboServiceProvided.GetItemData(ViewModel.cboServiceProvided.SelectedIndex);
					}
					EMSReport.Severity = 4;
					EMSReport.TreatmentAuthorization = 1;  //Standard Protocol 
					break;
				default:
					if ( ViewModel.optGender[0].Checked)
					{
						EMSReport.Gender = 1;
					}
					else if ( ViewModel.optGender[1].Checked)
					{
						EMSReport.Gender = 2;
					}
					else
					{
						EMSReport.Gender = 0;
					}
					EMSReport.Age = Convert.ToInt32(Conversion.Val(ViewModel.txtPatientAge.Text));
					if ( ViewModel.cboPatientAgeUnits.SelectedIndex == -1)
					{
						EMSReport.AgeUnit = 0;
					}
					else
					{
						EMSReport.AgeUnit = ViewModel.cboPatientAgeUnits.GetItemData(ViewModel.cboPatientAgeUnits.SelectedIndex);
					}
					if ( ViewModel.cboRace.SelectedIndex == -1)
					{
						EMSReport.Race = 0;
					}
					else
					{
						EMSReport.Race = ViewModel.cboRace.GetItemData(ViewModel.cboRace.SelectedIndex);
					}
					if ( ViewModel.optEthnicity[0].Checked)
					{
						EMSReport.Ethnicity = 3;
					}
					else if ( ViewModel.optEthnicity[1].Checked)
					{
						EMSReport.Ethnicity = 4;
					}
					else
					{
						EMSReport.Ethnicity = 0;
					}
					EMSReport.ServiceProvided = 0;
					if ( ViewModel.optSeverity[0].Checked)
					{
						EMSReport.Severity = 1;
					}
					else if ( ViewModel.optSeverity[1].Checked)
					{
						EMSReport.Severity = 3;
					}
					else if ( ViewModel.optSeverity[2].Checked)
					{
						EMSReport.Severity = 4;
					}
					else
					{
						EMSReport.Severity = 0;
					}
					if ( ViewModel.cboTreatmentAuth.SelectedIndex == -1)
					{
						EMSReport.TreatmentAuthorization = 0;
					}
					else
					{
						EMSReport.TreatmentAuthorization = ViewModel.cboTreatmentAuth.GetItemData(ViewModel.cboTreatmentAuth.SelectedIndex);
					}
					break;
			}

			if ( ViewModel.cboIncidentLocation.SelectedIndex == -1)
			{
				EMSReport.IncidentLocation = 0;
			}
			else
			{
				EMSReport.IncidentLocation = ViewModel.cboIncidentLocation.GetItemData(ViewModel.cboIncidentLocation.SelectedIndex);
			}
			EMSReport.IncidentZipcode = IncidentMain.Clean(ViewModel.txtIncidentZipcode.Text);
			if ( ViewModel.cboIncidentSetting.SelectedIndex == -1)
			{
				EMSReport.IncidentSetting = 0;
			}
			else
			{
				EMSReport.IncidentSetting = ViewModel.cboIncidentSetting.GetItemData(ViewModel.cboIncidentSetting.SelectedIndex);
			}
			//Dispatched as
			if (IncidentCL.InitialIncidentType == 66 || IncidentCL.InitialIncidentType == 67)
			{ //ALS
				EMSReport.DispatchedAlsBls = "A";
			}
			else
			{
				EMSReport.DispatchedAlsBls = "B";
			}
			//Level of Care
			if ( ViewModel.EMSType == IncidentMain.ALS || ViewModel.EMSType == IncidentMain.ALSTRANS)
			{
				EMSReport.LevelOfCareAlsBls = "A";
			}
			else
			{
				EMSReport.LevelOfCareAlsBls = "B";
			}
			if ( ViewModel.cboResearchCode.SelectedIndex == -1)
			{
				EMSReport.ResearchCode = 0;
			}
			else
			{
				EMSReport.ResearchCode = ViewModel.cboResearchCode.GetItemData(ViewModel.cboResearchCode.SelectedIndex);
			}

			if (~EMSReport.UpdateEMSPatientContact() != 0)
			{
				ViewManager.ShowMessage("Error Attempting to Update EMS Patient Contact Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				result = 0;
			}

			if ( ViewModel.NarrationUpdated != 0)
			{
				SaveNarration();
			}

			if (result != 0)
			{
				//Update ReportLog
				if (~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
						{
							var ret = ReportLog.UpdateStatus(ref p1, ViewModel.PatientID, IncidentMain.COMPLETE);
							ViewModel.ReportLogID = p1;
							return ret;
						}, ViewModel.ReportLogID) != 0)
				{
					ViewManager.ShowMessage("Error Attempting to Update ReportLog Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				}
				else
				{
					if (~ReportLog.UpdateNFIRSLog(ViewModel.CurrIncident) != 0)
					{
						//Currently do nothing - odds are record is being edited before getting added
						//to the NFIRSLog table during nightly batch job
					}
				}
				//Update HIPAA Record Access
				if (IncidentMain.Shared.gHIPAAState == IncidentMain.HIPAARO)
				{
					IncidentMain.Shared.gHIPAAState = IncidentMain.HIPAACHANGE;
				}
				else if (IncidentMain.Shared.gHIPAAState == IncidentMain.HIPAAPRINT)
				{
					IncidentMain.Shared.gHIPAAState = IncidentMain.HIPAACHGPRT;
				}
				UpdateHIPAA(IncidentMain.Shared.gHIPAAState);
			}


			//************** IF Basic EMS Report Save Abreviated Patient Name Info
			//************** if available and EXIT
			if ( ViewModel.ActionTaken == 3 || ViewModel.ActionTaken == 4 || ViewModel.ActionTaken == 5)
			{
				//Save EMSPatient Record if First or Last Name Fields Completed
				if (EMSReport.GetEMSPatient(ViewModel.PatientID) != 0)
				{
					UpdateSwitch = -1;
				}
				else
				{
					UpdateSwitch = 0;
				}
				if (IncidentMain.Clean(ViewModel.txtBFirstName.Text) != "")
				{
					EMSReport.EMSPatientID = ViewModel.PatientID;
					EMSReport.NameFirst = IncidentMain.Clean(ViewModel.txtBFirstName.Text);
					EMSReport.NameLast = IncidentMain.Clean(ViewModel.txtBLastName.Text);
					EMSReport.NameMI = IncidentMain.Clean(ViewModel.txtBMI.Text);
					EMSReport.Phone = IncidentMain.Clean(ViewModel.txtBHomePhone.Text);
					if (Information.IsDate(ViewModel.txtBBirthdate.Text))
					{
						EMSReport.Birthdate = DateTime.Parse(ViewModel.txtBBirthdate.Text).ToString("MM/dd/yyyy");
					}
					else
					{
						EMSReport.Birthdate = "";
					}
					EMSReport.SocialSecurityNumber = "";
					EMSReport.BillingAddress = "";
					EMSReport.City = "";
					EMSReport.State = "";
					EMSReport.FlagDNRO = 0;
					//- Save Abreviated Patient report ------
					if (UpdateSwitch != 0)
					{
						if (~EMSReport.UpdateEMSPatient() != 0)
						{
							ViewManager.ShowMessage("Error Updating EMS Patient Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							result = 0;
						}
					}
					else
					{
						if (~EMSReport.AddEMSPatient() != 0)
						{
							ViewManager.ShowMessage("Error Attempting to Add New EMS Patient Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							result = 0;
						}
					}
				}
				else if (IncidentMain.Clean(ViewModel.txtBLastName.Text) != "")
				{
					EMSReport.EMSPatientID = ViewModel.PatientID;
					EMSReport.NameFirst = IncidentMain.Clean(ViewModel.txtBFirstName.Text);
					EMSReport.NameLast = IncidentMain.Clean(ViewModel.txtBLastName.Text);
					EMSReport.NameMI = IncidentMain.Clean(ViewModel.txtBMI.Text);
					EMSReport.Phone = IncidentMain.Clean(ViewModel.txtBHomePhone.Text);
					if (Information.IsDate(ViewModel.txtBBirthdate.Text))
					{
						EMSReport.Birthdate = DateTime.Parse(ViewModel.txtBBirthdate.Text).ToString("MM/dd/yyyy");
					}
					else
					{
						EMSReport.Birthdate = "";
					}
					EMSReport.SocialSecurityNumber = "";
					EMSReport.BillingAddress = "";
					EMSReport.City = "";
					EMSReport.State = "";
					EMSReport.FlagDNRO = 0;
					//- Save Abreviated Patient report ------
					if (UpdateSwitch != 0)
					{
						if (~EMSReport.UpdateEMSPatient() != 0)
						{
							ViewManager.ShowMessage("Error Updating EMS Patient Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							result = 0;
						}
					}
					else
					{
						if (~EMSReport.AddEMSPatient() != 0)
						{
							ViewManager.ShowMessage("Error Attempting to Add New EMS Patient Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							result = 0;
						}
					}
				}
				return result;
			}

			//****************************************************************
			//**                   EMS Patient Record
			//****************************************************************
			if (EMSReport.GetEMSPatient(ViewModel.PatientID) != 0)
			{
				UpdateSwitch = -1;
			}
			else
			{
				UpdateSwitch = 0;
			}
			EMSReport.EMSPatientID = ViewModel.PatientID;
			if (Information.IsDate(ViewModel.mskBirthdate.Text))
			{
				EMSReport.Birthdate = DateTime.Parse(ViewModel.mskBirthdate.Text).ToString("MM/dd/yyyy");
			}
			else
			{
				EMSReport.Birthdate = "";
			}
			EMSReport.NameLast = IncidentMain.Clean(ViewModel.txtLastName.Text);
			EMSReport.NameFirst = IncidentMain.Clean(ViewModel.txtFirstName.Text);
			EMSReport.NameMI = ViewModel.txtMI.Text.Substring(0, Math.Min(2, ViewModel.txtMI.Text.Length));
			EMSReport.SocialSecurityNumber = IncidentMain.Clean(ViewModel.mskSSN.Text);
			EMSReport.BillingAddress = IncidentMain.Clean(ViewModel.txtBillingAddress.Text);
			EMSReport.City = IncidentMain.Clean(ViewModel.txtCity.Text);
			if ( ViewModel.cboState.SelectedIndex == -1)
			{
				EMSReport.State = "";
			}
			else
			{
				EMSReport.State = ViewModel.cboState.Text;
			}
			EMSReport.Zipcode = IncidentMain.Clean(ViewModel.txtZipCode.Text);
			EMSReport.Phone = IncidentMain.Clean(ViewModel.txtHomePhone.Text);
			if ( ViewModel.chkDNR.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				EMSReport.FlagDNRO = 1;
			}
			else
			{
				EMSReport.FlagDNRO = 0;
			}
			if (UpdateSwitch != 0)
			{
				if (~EMSReport.UpdateEMSPatient() != 0)
				{
					ViewManager.ShowMessage("Error Updating EMS Patient Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					result = 0;
				}
			}
			else
			{
				if (~EMSReport.AddEMSPatient() != 0)
				{
					ViewManager.ShowMessage("Error Attempting to Add New EMS Patient Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					result = 0;
				}
			}
			UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
				{
					var ret =

							//Prior Medical History
							EMSReport.DeleteEMSPreExistingCondition(ref p1);
					ViewModel.PatientID = p1;
					return ret;
				}, ViewModel.PatientID);
			EMSReport.PreExistPatientID = ViewModel.PatientID;
			for (int i = 0; i <= ViewModel.lstPriorMedicalHistory.Items.Count - 1; i++)
			{
				if ( ViewModel.lstPriorMedicalHistory.GetSelected( i))
				{
					EMSReport.PreExistingCondition = ViewModel.lstPriorMedicalHistory.GetItemData(i);
					if (~EMSReport.AddEMSPreExistingCondition() != 0)
					{
						ViewManager.ShowMessage("Error Attempting to Add EMS Prior Medical History Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.
							BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						result = 0;
					}
				}
			}
			UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
				{
					var ret =

							//Contributing Factors
							EMSReport.DeleteEMSContributingFactor(ref p1);
					ViewModel.PatientID = p1;
					return ret;
				}, ViewModel.PatientID);
			EMSReport.CFPatientID = ViewModel.PatientID;
			for (int i = 0; i <= ViewModel.lstPossibleFactors.Items.Count - 1; i++)
			{
				if ( ViewModel.lstPossibleFactors.GetSelected( i))
				{
					EMSReport.EMSContributingFactorCode = ViewModel.lstPossibleFactors.GetItemData(i);
					if (~EMSReport.AddEMSContributingFactor() != 0)
					{
						ViewManager.ShowMessage("Error Attempting to Add EMS Contributing Factor Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.
							BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						result = 0;
					}
				}
			}
			//***************************************************************
			//***         Transport Record
			//***************************************************************
			if ( ViewModel.ActionTaken == 2 || ViewModel.ActionTaken == 7)
			{
				if (EMSReport.GetEMSPatientTransport(ViewModel.PatientID) != 0)
				{
					UpdateSwitch = -1;
				}
				else
				{
					UpdateSwitch = 0;
				}
				EMSReport.TransPatientID = ViewModel.PatientID;
				if ( ViewModel.cboHospitalChosenBy.SelectedIndex == -1)
				{
					EMSReport.HospitalChosenBy = 0;
				}
				else
				{
					EMSReport.HospitalChosenBy = ViewModel.cboHospitalChosenBy.GetItemData(ViewModel.cboHospitalChosenBy.SelectedIndex);
				}
				if ( ViewModel.chkDiverted.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
				{
					EMSReport.FlagDiverted = 1;
				}
				else
				{
					EMSReport.FlagDiverted = 0;
				}
				if ( ViewModel.cboBaseStationContact.SelectedIndex == -1)
				{
					EMSReport.BaseStation = 0;
				}
				else
				{
					EMSReport.BaseStation = ViewModel.cboBaseStationContact.GetItemData(ViewModel.cboBaseStationContact.SelectedIndex);
				}
				if ( ViewModel.optMDorRN[0].Checked)
				{
					EMSReport.HospitalStaffType = 1;
				}
				else if ( ViewModel.optMDorRN[1].Checked)
				{
					EMSReport.HospitalStaffType = 2;
				}
				else if ( ViewModel.optMDorRN[2].Checked)
				{
					EMSReport.HospitalStaffType = 3;
				}
				else
				{
					EMSReport.HospitalStaffType = 0;
				}
				EMSReport.Mileage = (float) Conversion.Val(ViewModel.txtMileage.Text);
				if ( ViewModel.cboTransportTo.SelectedIndex == -1)
				{
					EMSReport.TransportedTo = 0;
				}
				else
				{
					EMSReport.TransportedTo = ViewModel.cboTransportTo.GetItemData(ViewModel.cboTransportTo.SelectedIndex);
				}
				if ( ViewModel.cboTransportFrom.SelectedIndex == -1)
				{
					EMSReport.TransportedFrom = 0;
				}
				else
				{
					EMSReport.TransportedFrom = ViewModel.cboTransportFrom.GetItemData(ViewModel.cboTransportFrom.SelectedIndex);
				}
				if ( ViewModel.cboTransportBy.SelectedIndex == -1)
				{
					EMSReport.TransportBy = "";
				}
				else
				{
					EMSReport.TransportBy = ViewModel.cboTransportBy.Text;
				}
				if (UpdateSwitch != 0)
				{
					if (~EMSReport.UpdateEMSPatientTransport() != 0)
					{
						ViewManager.ShowMessage("Error Attempting to Update EMS Patient Transport Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.
							BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						result = 0;
					}
				}
				else
				{
					if (~EMSReport.AddEMSPatientTransport() != 0)
					{
						ViewManager.ShowMessage("Error Attempting to Add EMS Patient Transport Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons
							.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						result = 0;
					}
				}
				if ( ViewModel.ActionTaken == 7)
				{
					return result;
				}
			}

			//********************************************************
			//**    EMS Patient Exam
			//********************************************************
			if (EMSReport.GetEMSPatientExam(ViewModel.PatientID) != 0)
			{
				UpdateSwitch = -1;
			}
			else
			{
				UpdateSwitch = 0;
			}
			EMSReport.ExamPatientID = ViewModel.PatientID;
			if ( ViewModel.cboMechCode.SelectedIndex == -1)
			{
				EMSReport.MechCode = 0;
			}
			else
			{
				EMSReport.MechCode = ViewModel.cboMechCode.GetItemData(ViewModel.cboMechCode.SelectedIndex);
			}
			if ( ViewModel.cboInjuryType.SelectedIndex != -1 && ViewModel.cboBodyPart.SelectedIndex != -1)
			{
				//Save Injury
				EMSReport.InjuryType = EMSCodes.GetInjuryTypeCode(ViewModel.cboBodyPart.GetItemData(ViewModel.cboBodyPart
							.SelectedIndex), ViewModel.cboInjuryType.GetItemData(ViewModel.cboInjuryType.SelectedIndex));
			}
			else
			{
				EMSReport.InjuryType = 0;
			}
			if ( ViewModel.cboPrimaryIllness.SelectedIndex == -1)
			{
				EMSReport.PrimaryIllness = 0;
			}
			else
			{
				EMSReport.PrimaryIllness = ViewModel.cboPrimaryIllness.GetItemData(ViewModel.cboPrimaryIllness.SelectedIndex);
			}
			if ( ViewModel.optPupils[0].Checked)
			{
				EMSReport.Pupils = 1;
			}
			else if ( ViewModel.optPupils[1].Checked)
			{
				EMSReport.Pupils = 2;
			}
			else
			{
				EMSReport.Pupils = 0;
			}
			if ( ViewModel.optLevelOfConsciouness[0].Checked)
			{
				EMSReport.LevelOfConsciousness = 3;
			}
			else if ( ViewModel.optLevelOfConsciouness[1].Checked)
			{
				EMSReport.LevelOfConsciousness = 4;
			}
			else if ( ViewModel.optLevelOfConsciouness[2].Checked)
			{
				EMSReport.LevelOfConsciousness = 5;
			}
			else
			{
				EMSReport.LevelOfConsciousness = 0;
			}
			if ( ViewModel.optRespiratoryEffort[0].Checked)
			{
				EMSReport.RespiratoryEffort = 6;
			}
			else if ( ViewModel.optRespiratoryEffort[1].Checked)
			{
				EMSReport.RespiratoryEffort = 7;
			}
			else if ( ViewModel.optRespiratoryEffort[2].Checked)
			{
				EMSReport.RespiratoryEffort = 8;
			}
			else
			{
				EMSReport.RespiratoryEffort = 0;
			}
			if ( ViewModel.ExtricationSwitch != 0)
			{
				EMSReport.FlagExtricationRequired = 1;
				EMSReport.ExtricationTime = Convert.ToInt32(Conversion.Val(ViewModel.txtExtricationTime.Text));
			}
			else
			{
				EMSReport.FlagExtricationRequired = 0;
				EMSReport.ExtricationTime = 0;
			}
			if (UpdateSwitch != 0)
			{
				if (~EMSReport.UpdateEMSPatientExam() != 0)
				{
					ViewManager.ShowMessage("Error Attempting to Update EMS Patient Exam Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					result = 0;
				}
			}
			else
			{
				if (~EMSReport.AddEMSPatientExam() != 0)
				{
					ViewManager.ShowMessage("Error Attempting to Add EMS Patient Exam Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					result = 0;
				}
			}
			UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
				{
					var ret =
							//Secondary Illness
							EMSReport.DeleteEMSSecondaryIllness(ref p1);
					ViewModel.PatientID = p1;
					return ret;
				}, ViewModel.PatientID);
			EMSReport.SecIllPatientID = ViewModel.PatientID;
			for (int i = 0; i <= ViewModel.lstSecondaryIllness.Items.Count - 1; i++)
			{
				if ( ViewModel.lstSecondaryIllness.GetSelected( i))
				{
					EMSReport.SecondaryIllnessCode = ViewModel.lstSecondaryIllness.GetItemData(i);
					if (~EMSReport.AddEMSSecondaryIllness() != 0)
					{
						ViewManager.ShowMessage("Error Attempting to Add Secondary Illness Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						result = 0;
					}
				}
			}

			if ( ViewModel.ActionTaken == 1 || ViewModel.ActionTaken == 2 || ViewModel.ActionTaken == 6 || ViewModel.ActionTaken == 8)
			{
				//***************************************************
				//** Patient Vitals
				//***************************************************

				for (int i = 0; i <= 4; i++)
				{
					if (EMSReport.GetEMSPatientVitals(Convert.ToInt32(Conversion.Val(ViewModel.lbVitalsID[i].Text))) != 0)
					{
						UpdateSwitch = -1;
					}
					else if ( ViewModel.txtTime[i].Text != "__:__" || ViewModel.cboEyes[i].SelectedIndex != -1 || ViewModel.txtPulse[i].Text != "")
					{
						UpdateSwitch = 0;
					}
					else
					{
						//no more updates
						break;
					}
					EMSReport.VitalsID = Convert.ToInt32(Conversion.Val(ViewModel.lbVitalsID[i].Text));
					EMSReport.VitalPatientID = ViewModel.PatientID;
					if ( ViewModel.txtTime[i].Text != "__:__")
					{
						DateWork = DateTime.Parse(ViewModel.lbExamDate.Text).ToString("MM/dd/yyyy");
						HourWork = DateTime.Parse(ViewModel.lbExamDate.Text).ToString("HH:mm");
						if (String.CompareOrdinal(ViewModel.txtTime[i].Text, HourWork) < 0)
						{
							DateWork = UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Parse(DateWork).AddDays(1));
						}
						if (Information.IsDate(DateWork + " " + ViewModel.txtTime[i].Text))
						{
							EMSReport.VitalsTime = DateWork + " " + ViewModel.txtTime[i].Text;
						}
						else
						{
							EMSReport.VitalsTime = "";
						}
					}
					else
					{
						EMSReport.VitalsTime = "";
					}
					if ( ViewModel.cboEyes[i].SelectedIndex == -1)
					{
						EMSReport.GCSEyes = 0;
					}
					else
					{
						EMSReport.GCSEyes = ViewModel.cboEyes[i].GetItemData(ViewModel.cboEyes[i].SelectedIndex);
					}
					if ( ViewModel.cboVerbal[i].SelectedIndex == -1)
					{
						EMSReport.GCSVerbal = 0;
					}
					else
					{
						EMSReport.GCSVerbal = ViewModel.cboVerbal[i].GetItemData(ViewModel.cboVerbal[i].SelectedIndex);
					}
					if ( ViewModel.cboMotor[i].SelectedIndex == -1)
					{
						EMSReport.GCSMotor = 0;
					}
					else
					{
						EMSReport.GCSMotor = ViewModel.cboMotor[i].GetItemData(ViewModel.cboMotor[i].SelectedIndex);
					}

					if ( ViewModel.txtSystolic[i].Text == "")
					{
						EMSReport.Systolic = -1;
					}
					else
					{
						EMSReport.Systolic = Convert.ToInt32(Conversion.Val(ViewModel.txtSystolic[i].Text));
					}
					if ( ViewModel.txtDiastolic[i].Text == "")
					{
						EMSReport.Diastolic = -1;
					}
					else
					{
						EMSReport.Diastolic = Convert.ToInt32(Conversion.Val(ViewModel.txtDiastolic[i].Text));
					}
					if ( ViewModel.chkPalp[i].CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
					{
						EMSReport.FlagDiastolicPalp = 1;
					}
					else
					{
						EMSReport.FlagDiastolicPalp = 0;
					}
					if ( ViewModel.txtPulse[i].Text == "")
					{
						EMSReport.Pulse = -1;
					}
					else
					{
						EMSReport.Pulse = Convert.ToInt32(Conversion.Val(ViewModel.txtPulse[i].Text));
					}
					if ( ViewModel.txtRespiration[i].Text == "")
					{
						EMSReport.RespirationRate = -1;
					}
					else
					{
						EMSReport.RespirationRate = Convert.ToInt32(Conversion.Val(ViewModel.txtRespiration[i].Text));
					}
					if ( ViewModel.cboVitalsPosition[i].SelectedIndex == -1)
					{
						EMSReport.VitalsPosition = 0;
					}
					else
					{
						EMSReport.VitalsPosition = ViewModel.cboVitalsPosition[i].GetItemData(ViewModel.cboVitalsPosition[i].SelectedIndex);
					}
					if ( ViewModel.txtGlucose[i].Text == "")
					{
						EMSReport.BloodGlucose = -1;
					}
					else
					{
						EMSReport.BloodGlucose = Convert.ToInt32(Conversion.Val(ViewModel.txtGlucose[i].Text));
					}
					if ( ViewModel.txtPulseOxy[i].Text == "")
					{
						EMSReport.PulseOxygen = -1;
					}
					else
					{
						EMSReport.PulseOxygen = Convert.ToInt32(Conversion.Val(ViewModel.txtPulseOxy[i].Text));
					}
					if ( ViewModel.txtPerOxy[i].Text == "")
					{
						EMSReport.PercentOxygen = -1;
					}
					else
					{
						EMSReport.PercentOxygen = Convert.ToInt32(Conversion.Val(ViewModel.txtPerOxy[i].Text));
					}
					if ( ViewModel.cboECG[i].SelectedIndex == -1)
					{
						EMSReport.ECG = 0;
					}
					else
					{
						EMSReport.ECG = ViewModel.cboECG[i].GetItemData(ViewModel.cboECG[i].SelectedIndex);
					}
					if (UpdateSwitch != 0)
					{
						if (~EMSReport.UpdateEMSPatientVitals() != 0)
						{
							ViewManager.ShowMessage("Error Attempting to Update Patient Vitals Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							result = 0;
						}
					}
					else
					{
						if (~EMSReport.AddEMSPatientVitals() != 0)
						{
							ViewManager.ShowMessage("Error Attempting to Add New Patient Vitals Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							result = 0;
						}
					}
				}

				//*****************************************************
				//**  EMS Patient IV Lines
				//*****************************************************
				for (int i = 0; i <= 4; i++)
				{
					if (EMSReport.GetEMSPatientIVLine(Convert.ToInt32(Conversion.Val(ViewModel.lbIVID[i].Text))) != 0)
					{
						UpdateSwitch = -1;
					}
					else if ( ViewModel.cboGauge[i].SelectedIndex != -1 || ViewModel.cboRoute[i].SelectedIndex != -1 || ViewModel.txtAmount[i].Text != "")
					{
						UpdateSwitch = 0;
					}
					else
					{
						//no more updates
						break;
					}
					EMSReport.LineID = Convert.ToInt32(Conversion.Val(ViewModel.lbIVID[i].Text));
					EMSReport.IVPatientID = ViewModel.PatientID;
					if ( ViewModel.cboGauge[i].SelectedIndex == -1)
					{
						EMSReport.IVGauge = 0;
					}
					else
					{
						EMSReport.IVGauge = ViewModel.cboGauge[i].GetItemData(ViewModel.cboGauge[i].SelectedIndex);
					}
					if ( ViewModel.cboRoute[i].SelectedIndex == -1)
					{
						EMSReport.IVRoute = 0;
					}
					else
					{
						EMSReport.IVRoute = ViewModel.cboRoute[i].GetItemData(ViewModel.cboRoute[i].SelectedIndex);
					}
					if ( ViewModel.cboRate[i].SelectedIndex == -1)
					{
						EMSReport.IVRate = 0;
					}
					else
					{
						EMSReport.IVRate = ViewModel.cboRate[i].GetItemData(ViewModel.cboRate[i].SelectedIndex);
					}
					EMSReport.IVAmount = Convert.ToInt32(Conversion.Val(ViewModel.txtAmount[i].Text));
					if ( ViewModel.cboSite[i].SelectedIndex == -1)
					{
						EMSReport.IVSite = 0;
					}
					else
					{
						EMSReport.IVSite = ViewModel.cboSite[i].GetItemData(ViewModel.cboSite[i].SelectedIndex);
					}
					if (UpdateSwitch != 0)
					{
						if (~EMSReport.UpdateEMSPatientIVLine() != 0)
						{
							ViewManager.ShowMessage("Error Attempting to Update EMS Patient IV Line Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.
								BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							result = 0;
						}
					}
					else
					{
						if (~EMSReport.AddEMSPatientIVLine() != 0)
						{
							ViewManager.ShowMessage("Error Attempting to Add New EMS Patient IV Line Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.
								BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							result = 0;
						}
					}
				}
			}

			//**************************************************
			//**   Trauma
			//**************************************************
			if ( ViewModel.TraumaSwitch != 0)
			{
				if (EMSReport.GetEMSPatientTrauma(ViewModel.PatientID) != 0)
				{
					UpdateSwitch = -1;
				}
				else
				{
					UpdateSwitch = 0;
				}
				EMSReport.TraumaPatientID = ViewModel.PatientID;
				EMSReport.TraumaID = ViewModel.txtTraumaID.Text;
				if ( ViewModel.cboProtectiveDevice.SelectedIndex == -1)
				{
					EMSReport.ProtectiveDevice = 0;
				}
				else
				{
					EMSReport.ProtectiveDevice = ViewModel.cboProtectiveDevice.GetItemData(ViewModel.cboProtectiveDevice.SelectedIndex);
				}
				if ( ViewModel.cboPatientLocation.SelectedIndex == -1)
				{
					EMSReport.TraumaLocation = 0;
				}
				else
				{
					EMSReport.TraumaLocation = ViewModel.cboPatientLocation.GetItemData(ViewModel.cboPatientLocation.SelectedIndex);
				}
				EMSReport.RevisedTraumaScore = EMSReport.GetRevisedTraumaScore(ViewModel.PatientID);
				if (UpdateSwitch != 0)
				{
					if (~EMSReport.UpdateEMSPatientTrauma() != 0)
					{
						ViewManager.ShowMessage("Error Attempting to Update EMS Patient Trauma Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons
							.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						result = 0;
					}
				}
				else
				{
					if (~EMSReport.AddEMSPatientTrauma() != 0)
					{
						ViewManager.ShowMessage("Error Attempting to Add New EMS Patient Trauma Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.
							BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						result = 0;
					}
				}
				UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
					{
						var ret =
								EMSReport.DeleteEMSTraumaDescriptor(ref p1);
						ViewModel.PatientID = p1;
						return ret;
					}, ViewModel.PatientID);
				EMSReport.TraumaDescrPatientID = ViewModel.PatientID;
				for (int i = 0; i <= ViewModel.lstTrauma1.Items.Count - 1; i++)
				{
					if ( ViewModel.lstTrauma1.GetSelected( i))
					{
						EMSReport.TraumaType = ViewModel.lstTrauma1.GetItemData(i);
						if (~EMSReport.AddEMSTraumaDescriptor() != 0)
						{
							ViewManager.ShowMessage("Error Attempting to Add EMS Trauma Type Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							result = 0;
						}
					}
				}
				for (int i = 0; i <= ViewModel.lstTrauma2.Items.Count - 1; i++)
				{
					if ( ViewModel.lstTrauma2.GetSelected( i))
					{
						EMSReport.TraumaType = ViewModel.lstTrauma2.GetItemData(i);
						if (~EMSReport.AddEMSTraumaDescriptor() != 0)
						{
							ViewManager.ShowMessage("Error Attempting to Add EMS Trauma Type Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							result = 0;
						}
					}
				}
				for (int i = 0; i <= ViewModel.lstTrauma3.Items.Count - 1; i++)
				{
					if ( ViewModel.lstTrauma3.GetSelected( i))
					{
						EMSReport.TraumaType = ViewModel.lstTrauma3.GetItemData(i);
						if (~EMSReport.AddEMSTraumaDescriptor() != 0)
						{
							ViewManager.ShowMessage("Error Attempting to Add EMS Trauma Type Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							result = 0;
						}
					}
				}
			}

			//*****************************************************
			//***   EMS CPR Records
			//*****************************************************
			if ( ViewModel.CPRSwitch != 0)
			{
				if (EMSReport.GetEMSCPR(ViewModel.PatientID) != 0)
				{
					UpdateSwitch = -1;
				}
				else
				{
					UpdateSwitch = 0;
				}
				EMSReport.CPRPatientID = ViewModel.PatientID;
				if ( ViewModel.optArrestToCPR[0].Checked)
				{
					EMSReport.TimeArrestToCPR = 1;
				}
				else if ( ViewModel.optArrestToCPR[1].Checked)
				{
					EMSReport.TimeArrestToCPR = 2;
				}
				else if ( ViewModel.optArrestToCPR[2].Checked)
				{
					EMSReport.TimeArrestToCPR = 3;
				}
				else if ( ViewModel.optArrestToCPR[3].Checked)
				{
					EMSReport.TimeArrestToCPR = 4;
				}
				else
				{
					EMSReport.TimeArrestToCPR = 0;
				}
				if ( ViewModel.optArrestToALS[0].Checked)
				{
					EMSReport.TimeArrestToAls = 1;
				}
				else if ( ViewModel.optArrestToALS[1].Checked)
				{
					EMSReport.TimeArrestToAls = 2;
				}
				else if ( ViewModel.optArrestToALS[2].Checked)
				{
					EMSReport.TimeArrestToAls = 3;
				}
				else if ( ViewModel.optArrestToALS[3].Checked)
				{
					EMSReport.TimeArrestToAls = 4;
				}
				else
				{
					EMSReport.TimeArrestToAls = 0;
				}
				if ( ViewModel.optArrestToShock[0].Checked)
				{
					EMSReport.TimeArrestToShock = 1;
				}
				else if ( ViewModel.optArrestToShock[1].Checked)
				{
					EMSReport.TimeArrestToShock = 2;
				}
				else if ( ViewModel.optArrestToShock[2].Checked)
				{
					EMSReport.TimeArrestToShock = 3;
				}
				else if ( ViewModel.optArrestToShock[3].Checked)
				{
					EMSReport.TimeArrestToShock = 4;
				}
				else
				{
					EMSReport.TimeArrestToShock = 0;
				}
				if ( ViewModel.chkPulseRestored.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
				{
					EMSReport.FlagPulseRestored = 1;
				}
				else
				{
					EMSReport.FlagPulseRestored = 0;
				}
				if (UpdateSwitch != 0)
				{
					if (~EMSReport.UpdateEMSCPR() != 0)
					{
						ViewManager.ShowMessage("Error Attempting to Update CPR Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						result = 0;
					}
				}
				else
				{
					if (~EMSReport.AddEMSCPR() != 0)
					{
						ViewManager.ShowMessage("Error Attempting Add New CPR Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						result = 0;
					}
				}
			}

			return result;
		}

		private int CheckComplete()
		{
			//Check for Entries in Required Fields
			//Flip Colors as needed
			//If FirstTime Then Exit Function

			int result = 0;
			if ( ViewModel.FirstTime != 0)
			{
				return result;
			}

			int i = 0;
			int OptCheck = 0;
			TFDIncident.clsEMS EMSReport = Container.Resolve< clsEMS>();
			TFDIncident.clsUnit UnitCL = Container.Resolve< clsUnit>();
			int Age = 0;
			string AgeType = "";


			result = -1;
			ViewModel.FirstTime = -1;

			if ( ViewModel.cboIncidentLocation.SelectedIndex < 0)
			{
				ViewModel.cboIncidentLocation.BackColor = IncidentMain.Shared.REQCOLOR;
				ViewModel.cboIncidentLocation.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
				result = 0;
			}
			else
			{
				ViewModel.cboIncidentLocation.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
				ViewModel.cboIncidentLocation.ForeColor = IncidentMain.Shared.EMSFONT;
			}
			double dbNumericTemp = 0;
			if ( ViewModel.txtIncidentZipcode.Text == "")
			{
				ViewModel.txtIncidentZipcode.BackColor = IncidentMain.Shared.REQCOLOR;
				ViewModel.txtIncidentZipcode.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
				result = 0;
			}
			else if (!Double.TryParse(ViewModel.txtIncidentZipcode.Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
			{
				ViewModel.txtIncidentZipcode.BackColor = IncidentMain.Shared.REQCOLOR;
				ViewModel.txtIncidentZipcode.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
				ViewModel.txtIncidentZipcode.Text = "";
				result = 0;
			}
			else
			{
				ViewModel.txtIncidentZipcode.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
				ViewModel.txtIncidentZipcode.ForeColor = IncidentMain.Shared.EMSFONT;
			}
			if ( ViewModel.cboIncidentSetting.SelectedIndex < 0)
			{
				ViewModel.cboIncidentSetting.BackColor = IncidentMain.Shared.REQCOLOR;
				ViewModel.cboIncidentSetting.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
				result = 0;
			}
			else
			{
				ViewModel.cboIncidentSetting.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
				ViewModel.cboIncidentSetting.ForeColor = IncidentMain.Shared.EMSFONT;
			}

			if ( ViewModel.NarrationRequired != 0)
			{
				ViewModel.lbPInfo[65].Text = ViewModel.ReqNarrString;
				ViewModel.lbPInfo[65].ForeColor = IncidentMain.Shared.RED;
				if (IncidentMain.Clean(ViewModel.rtxNarration.Text) == "")
				{
					ViewModel.rtxNarration.BackColor = IncidentMain.Shared.REQCOLOR;
					result = 0;
				}
				else
				{
					ViewModel.rtxNarration.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
				}
			}
			else
			{
				ViewModel.lbPInfo[65].Text = "Narrative";
				ViewModel.lbPInfo[65].ForeColor = IncidentMain.Shared.EMSFONT;
				ViewModel.rtxNarration.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
			}

			switch( ViewModel.ActionTaken)
			{
				case 3 : case 4 : case 5 :
					//No exam, refused treatment, or DOA 
					if ( ViewModel.txtBFirstName.Text == "")
					{
						ViewModel.txtBFirstName.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.txtBFirstName.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						result = 0;
					}
					else
					{
						ViewModel.txtBFirstName.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.txtBFirstName.ForeColor = IncidentMain.Shared.EMSFONT;
					}
					if ( ViewModel.txtBLastName.Text == "")
					{
						ViewModel.txtBLastName.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.txtBLastName.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						result = 0;
					}
					else
					{
						ViewModel.txtBLastName.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.txtBLastName.ForeColor = IncidentMain.Shared.EMSFONT;
					}

					if ( ViewModel.txtBBirthdate.Text == "__/__/____")
					{
						double dbNumericTemp2 = 0;
						if ( ViewModel.txtAge.Text == "")
						{
							ViewModel.txtAge.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.txtAge.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.cboAgeUnits.SelectedIndex = -1;
							ViewModel.cboAgeUnits.Text = "";
							ViewModel.cboAgeUnits.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.cboAgeUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.txtBBirthdate.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.txtBBirthdate.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							result = 0;
						}
						else if (!Double.TryParse(ViewModel.txtAge.Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp2))
						{
							ViewModel.txtAge.Text = "";
							ViewModel.txtAge.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.txtAge.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.cboAgeUnits.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.cboAgeUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.cboAgeUnits.SelectedIndex = -1;
							ViewModel.cboAgeUnits.Text = "";
							ViewModel.txtBBirthdate.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.txtBBirthdate.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							result = 0;
						}
						else if (Conversion.Val(ViewModel.txtAge.Text) > 150)
						{
							ViewManager.ShowMessage("You have indicated an unreasonable age", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							ViewModel.txtAge.Text = "";
							ViewModel.txtAge.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.txtAge.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.cboAgeUnits.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.cboAgeUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.cboAgeUnits.SelectedIndex = -1;
							ViewModel.cboAgeUnits.Text = "";
							ViewModel.txtBBirthdate.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.txtBBirthdate.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							result = 0;
						}
						else
						{
							ViewModel.txtBBirthdate.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.txtBBirthdate.ForeColor = IncidentMain.Shared.EMSFONT;
							ViewModel.txtBBirthdate.Text = "__/__/____";
							ViewModel.txtAge.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.txtAge.ForeColor = IncidentMain.Shared.EMSFONT;
							Age = Convert.ToInt32(Conversion.Val(ViewModel.txtPatientAge.Text));
							if ( ViewModel.cboAgeUnits.SelectedIndex == -1)
							{
								ViewModel.cboAgeUnits.BackColor = IncidentMain.Shared.REQCOLOR;
								ViewModel.cboAgeUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
								ViewModel.cboAgeUnits.Text = "";
								result = 0;
							}
							else
							{
								ViewModel.cboAgeUnits.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
								ViewModel.cboAgeUnits.ForeColor = IncidentMain.Shared.EMSFONT;
								AgeType = ViewModel.cboAgeUnits.Text.Trim();
								if (Age > 11)
								{
									if (AgeType == "Months")
									{
										ViewManager.ShowMessage("Months Can NOT be Selected if Greater than 11", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.
											BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
										ViewModel.txtAge.Text = "";
										ViewModel.txtAge.BackColor = IncidentMain.Shared.REQCOLOR;
										ViewModel.txtAge.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
										ViewModel.cboAgeUnits.BackColor = IncidentMain.Shared.REQCOLOR;
										ViewModel.cboAgeUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
										ViewModel.cboAgeUnits.SelectedIndex = -1;
										result = 0;
									}
									if (Age > 29)
									{
										if (AgeType == "Days")
										{
											ViewManager.ShowMessage("Days Can NOT be Selected if Greater than 29", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.
												BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
											ViewModel.txtAge.Text = "";
											ViewModel.txtAge.BackColor = IncidentMain.Shared.REQCOLOR;
											ViewModel.txtAge.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
											ViewModel.cboAgeUnits.BackColor = IncidentMain.Shared.REQCOLOR;
											ViewModel.cboAgeUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
											ViewModel.cboAgeUnits.SelectedIndex = -1;
											result = 0;
										}
									}
								}
							}
						}
					}
					else if (!Information.IsDate(ViewModel.txtBBirthdate.Text))
					{
						ViewModel.txtBBirthdate.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.txtBBirthdate.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.txtBBirthdate.Text = "__/__/____";
						ViewModel.txtAge.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.txtAge.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.txtAge.Text = "";
						ViewModel.cboAgeUnits.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.cboAgeUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboAgeUnits.SelectedIndex = -1;
					}
					else
					{
						ViewModel.txtBBirthdate.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.txtBBirthdate.ForeColor = IncidentMain.Shared.EMSFONT;
						ViewModel.txtAge.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.txtAge.ForeColor = IncidentMain.Shared.EMSFONT;
						ViewModel.cboAgeUnits.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboAgeUnits.ForeColor = IncidentMain.Shared.EMSFONT;
						EditBasicBirthdate();
						ViewModel.FirstTime = -1;
					}
					if (!ViewModel.optEMSGender[0].Checked && !ViewModel.optEMSGender[1].Checked)
					{
						//frmBasicGender.BackColor = REQCOLOR
						ViewModel.frmBasicGender.Font = ViewModel.frmBasicGender.Font.Change(name:IncidentMain.WHITE.ToString());
						ViewModel.optEMSGender[0].BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.optEMSGender[1].BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.optEMSGender[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.optEMSGender[1].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					}
					else
					{
						ViewModel.optEMSGender[0].BackColor = IncidentMain.Shared.EMSCOLOR;
						ViewModel.optEMSGender[1].BackColor = IncidentMain.Shared.EMSCOLOR;
						ViewModel.optEMSGender[0].ForeColor = IncidentMain.Shared.EMSFONT;
						ViewModel.optEMSGender[1].ForeColor = IncidentMain.Shared.EMSFONT;
					}
					if ( ViewModel.cboEMSRace.SelectedIndex < 0)
					{
						ViewModel.cboEMSRace.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.cboEMSRace.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						result = 0;
					}
					else
					{
						ViewModel.cboEMSRace.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboEMSRace.ForeColor = IncidentMain.Shared.EMSFONT;
					}
					if ( ViewModel.cboServiceProvided.SelectedIndex < 0)
					{
						ViewModel.cboServiceProvided.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.cboServiceProvided.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						result = 0;
					}
					else
					{
						ViewModel.cboServiceProvided.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboServiceProvided.ForeColor = IncidentMain.Shared.EMSFONT;
					}
					if ( ViewModel.cboIncidentLocation.SelectedIndex < 0)
					{
						ViewModel.cboIncidentLocation.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.cboIncidentLocation.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						result = 0;
					}
					else
					{
						ViewModel.cboIncidentLocation.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboIncidentLocation.ForeColor = IncidentMain.Shared.EMSFONT;
					}
					if ( ViewModel.cboIncidentSetting.SelectedIndex < 0)
					{
						ViewModel.cboIncidentSetting.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.cboIncidentSetting.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						result = 0;
					}
					else
					{
						ViewModel.cboIncidentSetting.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboIncidentSetting.ForeColor = IncidentMain.Shared.EMSFONT;
					}
					break;
			}
			switch( ViewModel.ActionTaken)
			{
				case 1 : case 6 : case 2 : case 7 :
					//all common fields 
					if ( ViewModel.txtFirstName.Text == "")
					{
						ViewModel.txtFirstName.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.txtFirstName.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						result = 0;
					}
					else
					{
						ViewModel.txtFirstName.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.txtFirstName.ForeColor = IncidentMain.Shared.EMSFONT;
					}
					if ( ViewModel.txtLastName.Text == "")
					{
						ViewModel.txtLastName.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.txtLastName.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						result = 0;
					}
					else
					{
						ViewModel.txtLastName.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.txtLastName.ForeColor = IncidentMain.Shared.EMSFONT;
					}
					if (!ViewModel.optGender[0].Checked && !ViewModel.optGender[1].Checked)
					{
						//frmGender.BackColor = REQCOLOR
						ViewModel.frmGender.Font = ViewModel.frmGender.Font.Change(name:IncidentMain.WHITE.ToString());
						ViewModel.optGender[0].BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.optGender[1].BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.optGender[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.optGender[1].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					}
					else
					{
						ViewModel.optGender[0].BackColor = IncidentMain.Shared.EMSCOLOR;
						ViewModel.optGender[1].BackColor = IncidentMain.Shared.EMSCOLOR;
						ViewModel.optGender[0].ForeColor = IncidentMain.Shared.EMSFONT;
						ViewModel.optGender[1].ForeColor = IncidentMain.Shared.EMSFONT;
					}
					if ( ViewModel.cboRace.SelectedIndex < 0)
					{
						ViewModel.cboRace.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.cboRace.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					}
					else
					{
						ViewModel.cboRace.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboRace.ForeColor = IncidentMain.Shared.EMSFONT;
					}
					//Must enter either birthdate OR age and age units 
					if ( ViewModel.mskBirthdate.Text == "__/__/____")
					{
						double dbNumericTemp3 = 0;
						if ( ViewModel.txtPatientAge.Text == "")
						{
							ViewModel.txtPatientAge.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.txtPatientAge.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.cboPatientAgeUnits.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.cboPatientAgeUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.mskBirthdate.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.mskBirthdate.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							result = 0;
						}
						else if (!Double.TryParse(ViewModel.txtPatientAge.Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp3))
						{
							ViewModel.txtPatientAge.Text = "";
							ViewModel.txtPatientAge.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.txtPatientAge.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.cboPatientAgeUnits.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.cboPatientAgeUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.mskBirthdate.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.mskBirthdate.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							result = 0;
						}
						else if (Conversion.Val(ViewModel.txtPatientAge.Text) > 150)
						{
							ViewManager.ShowMessage("You have indicated an unreasonable age", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							ViewModel.txtPatientAge.Text = "";
							ViewModel.txtPatientAge.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.txtPatientAge.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.cboPatientAgeUnits.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.cboPatientAgeUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.mskBirthdate.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.mskBirthdate.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							result = 0;
						}
						else
						{
							ViewModel.mskBirthdate.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.mskBirthdate.ForeColor = IncidentMain.Shared.EMSFONT;
							ViewModel.mskBirthdate.Text = "__/__/____";
							ViewModel.txtPatientAge.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.txtPatientAge.ForeColor = IncidentMain.Shared.EMSFONT;
							Age = Convert.ToInt32(Conversion.Val(ViewModel.txtPatientAge.Text));
							if ( ViewModel.cboPatientAgeUnits.SelectedIndex == -1)
							{
								ViewModel.cboPatientAgeUnits.BackColor = IncidentMain.Shared.REQCOLOR;
								ViewModel.cboPatientAgeUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
								ViewModel.cboPatientAgeUnits.Text = "";
								result = 0;
							}
							else
							{
								ViewModel.cboPatientAgeUnits.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
								ViewModel.cboPatientAgeUnits.ForeColor = IncidentMain.Shared.EMSFONT;
								AgeType = ViewModel.cboPatientAgeUnits.Text.Trim();
								if (Age > 11)
								{
									if (AgeType == "Months")
									{
										ViewManager.ShowMessage("Months Can NOT be Selected if Greater than 11", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.
											BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
										ViewModel.txtPatientAge.Text = "";
										ViewModel.txtPatientAge.BackColor = IncidentMain.Shared.REQCOLOR;
										ViewModel.txtPatientAge.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
										ViewModel.cboPatientAgeUnits.BackColor = IncidentMain.Shared.REQCOLOR;
										ViewModel.cboPatientAgeUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
										ViewModel.cboPatientAgeUnits.SelectedIndex = -1;
										result = 0;
									}
									if (Age > 29)
									{
										if (AgeType == "Days")
										{
											ViewManager.ShowMessage("Days Can NOT be Selected if Greater than 29", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.
												BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
											ViewModel.txtPatientAge.Text = "";
											ViewModel.txtPatientAge.BackColor = IncidentMain.Shared.REQCOLOR;
											ViewModel.txtPatientAge.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
											ViewModel.cboPatientAgeUnits.BackColor = IncidentMain.Shared.REQCOLOR;
											ViewModel.cboPatientAgeUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
											ViewModel.cboPatientAgeUnits.SelectedIndex = -1;
											result = 0;
										}
									}
								}
							}
						}
					}
					else if (!Information.IsDate(ViewModel.mskBirthdate.Text))
					{
						ViewModel.mskBirthdate.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.mskBirthdate.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.mskBirthdate.Text = "__/__/____";
						ViewModel.txtPatientAge.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.txtPatientAge.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.txtPatientAge.Text = "";
						ViewModel.cboPatientAgeUnits.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.cboPatientAgeUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboPatientAgeUnits.SelectedIndex = -1;
					}
					else
					{
						ViewModel.mskBirthdate.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.mskBirthdate.ForeColor = IncidentMain.Shared.EMSFONT;
						ViewModel.txtPatientAge.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.txtPatientAge.ForeColor = IncidentMain.Shared.EMSFONT;
						ViewModel.cboPatientAgeUnits.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboPatientAgeUnits.ForeColor = IncidentMain.Shared.EMSFONT;
						EditBirthdate();
						ViewModel.FirstTime = -1;
					}
					break;
			}
			switch( ViewModel.ActionTaken)
			{
				case 1 : case 6 : case 2 :
					if ( ViewModel.cboMechCode.SelectedIndex == -1)
					{
						ViewModel.cboMechCode.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.cboMechCode.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						result = 0;
					}
					else
					{
						ViewModel.cboMechCode.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboMechCode.ForeColor = IncidentMain.Shared.EMSFONT;
						switch( ViewModel.cboMechCode.GetItemData(ViewModel.cboMechCode.SelectedIndex))
						{
							case 1 :  //No Mech Code 

								ViewModel.cboInjuryType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
								ViewModel.cboInjuryType.ForeColor = IncidentMain.Shared.EMSFONT;
								ViewModel.cboBodyPart.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
								ViewModel.cboBodyPart.ForeColor = IncidentMain.Shared.EMSFONT;
								ViewModel.cboPrimaryIllness.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
								ViewModel.cboPrimaryIllness.ForeColor = IncidentMain.Shared.EMSFONT;

								break;
							case 3 : case 4 : case 7 : case 12 : case 13 : case 19 : case 22 : case 23 : case 24 : case 27 : case 29 :  //Medical 
								if ( ViewModel.cboPrimaryIllness.SelectedIndex == -1)
								{
									ViewModel.cboPrimaryIllness.BackColor = IncidentMain.Shared.REQCOLOR;
									ViewModel.cboPrimaryIllness.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
									result = 0;
								}
								else
								{
									ViewModel.cboInjuryType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
									ViewModel.cboInjuryType.ForeColor = IncidentMain.Shared.EMSFONT;
									ViewModel.cboBodyPart.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
									ViewModel.cboBodyPart.ForeColor = IncidentMain.Shared.EMSFONT;
									ViewModel.cboPrimaryIllness.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
									ViewModel.cboPrimaryIllness.ForeColor = IncidentMain.Shared.EMSFONT;
								}
								break;
							default: //Injury 
								if ( ViewModel.cboInjuryType.SelectedIndex == -1)
								{
									ViewModel.cboInjuryType.BackColor = IncidentMain.Shared.REQCOLOR;
									ViewModel.cboInjuryType.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
									ViewModel.cboBodyPart.BackColor = IncidentMain.Shared.REQCOLOR;
									ViewModel.cboBodyPart.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
									result = 0;
								}
								else
								{
									ViewModel.cboPrimaryIllness.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
									ViewModel.cboPrimaryIllness.ForeColor = IncidentMain.Shared.EMSFONT;
									ViewModel.cboInjuryType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
									ViewModel.cboInjuryType.ForeColor = IncidentMain.Shared.EMSFONT;
									ViewModel.cboBodyPart.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
									ViewModel.cboBodyPart.ForeColor = IncidentMain.Shared.EMSFONT;
								}
								break;
						}
					}
					if (~ViewModel.NoVitals != 0)
					{
						if ( ViewModel.txtTime[0].Text == "__:__")
						{
							ViewModel.txtTime[0].BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.txtTime[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							result = 0;
						}
						else
						{
							ViewModel.txtTime[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.txtTime[0].ForeColor = IncidentMain.Shared.EMSFONT;
						}
						double dbNumericTemp4 = 0;
						if ( ViewModel.txtPulse[0].Text == "")
						{
							ViewModel.txtPulse[0].BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.txtPulse[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							result = 0;
						}
						else if (!Double.TryParse(ViewModel.txtPulse[0].Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp4))
						{
							ViewModel.txtPulse[0].BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.txtPulse[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.txtPulse[0].Text = "";
							result = 0;
						}
						else
						{
							ViewModel.txtPulse[i].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.txtPulse[i].ForeColor = IncidentMain.Shared.EMSFONT;
						}
						double dbNumericTemp5 = 0;
						if ( ViewModel.txtRespiration[0].Text == "")
						{
							ViewModel.txtRespiration[0].BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.txtRespiration[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							result = 0;
						}
						else if (!Double.TryParse(ViewModel.txtRespiration[0].Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp5))
						{
							ViewModel.txtRespiration[0].BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.txtRespiration[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.txtRespiration[0].Text = "";
							result = 0;
						}
						else
						{
							ViewModel.txtRespiration[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.txtRespiration[0].ForeColor = IncidentMain.Shared.EMSFONT;
						}
						double dbNumericTemp6 = 0;
						if ( ViewModel.txtSystolic[0].Text == "")
						{
							ViewModel.txtSystolic[0].BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.txtSystolic[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							result = 0;
						}
						else if (!Double.TryParse(ViewModel.txtSystolic[0].Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp6))
						{
							ViewModel.txtSystolic[0].BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.txtSystolic[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.txtSystolic[0].Text = "";
							result = 0;
						}
						else
						{
							ViewModel.txtSystolic[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.txtSystolic[0].ForeColor = IncidentMain.Shared.EMSFONT;
						}
						if ( ViewModel.txtDiastolic[0].Text == "")
						{
							if (((int)ViewModel.chkPalp[0].CheckState) == ((int)UpgradeHelpers.Helpers.CheckState.Unchecked))
							{
								ViewModel.txtDiastolic[0].BackColor = IncidentMain.Shared.REQCOLOR;
								ViewModel.txtDiastolic[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
								ViewModel.chkPalp[0].BackColor = IncidentMain.Shared.REQCOLOR;
								ViewModel.chkPalp[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
								result = 0;
							}
							else
							{
								ViewModel.txtDiastolic[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
								ViewModel.txtDiastolic[0].ForeColor = IncidentMain.Shared.EMSFONT;
								ViewModel.txtDiastolic[0].Text = "";
								ViewModel.chkPalp[0].BackColor = IncidentMain.Shared.EMSCOLOR;
								ViewModel.chkPalp[0].ForeColor = IncidentMain.Shared.EMSFONT;
							}
						}
						else
						{
							double dbNumericTemp7 = 0;
							if (!Double.TryParse(ViewModel.txtDiastolic[0].Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp7))
							{
								ViewModel.txtDiastolic[0].BackColor = IncidentMain.Shared.REQCOLOR;
								ViewModel.txtDiastolic[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
								ViewModel.txtDiastolic[0].Text = "";
								result = 0;
							}
							else
							{
								ViewModel.txtDiastolic[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
								ViewModel.txtDiastolic[0].ForeColor = IncidentMain.Shared.EMSFONT;
								ViewModel.chkPalp[0].BackColor = IncidentMain.Shared.EMSCOLOR;
								ViewModel.chkPalp[0].ForeColor = IncidentMain.Shared.EMSFONT;
								ViewModel.chkPalp[0].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
							}
						}
						double dbNumericTemp8 = 0;
						if (!Double.TryParse(ViewModel.txtGlucose[0].Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp8))
						{
							ViewModel.txtGlucose[0].Text = "";
						}
						double dbNumericTemp9 = 0;
						if (!Double.TryParse(ViewModel.txtPulseOxy[0].Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp9))
						{
							ViewModel.txtPulseOxy[0].Text = "";
						}
						else
						{
							if ( ViewModel.txtPulseOxy[0].Text != "")
							{
								double dbNumericTemp10 = 0;
								if ( ViewModel.txtPerOxy[0].Text == "")
								{
									ViewModel.txtPerOxy[0].BackColor = IncidentMain.Shared.REQCOLOR;
									ViewModel.txtPerOxy[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
									result = 0;
								}
								else if (!Double.TryParse(ViewModel.txtPerOxy[0].Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp10))
								{
									ViewModel.txtPerOxy[0].BackColor = IncidentMain.Shared.REQCOLOR;
									ViewModel.txtPerOxy[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
									ViewModel.txtPerOxy[0].Text = "";
									result = 0;
								}
								else if (Conversion.Val(ViewModel.txtPerOxy[0].Text) > 100)
								{
									ViewModel.txtPerOxy[0].BackColor = IncidentMain.Shared.REQCOLOR;
									ViewModel.txtPerOxy[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
									ViewModel.txtPerOxy[0].Text = "";
									result = 0;
								}
								else
								{
									ViewModel.txtPerOxy[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
									ViewModel.txtPerOxy[0].ForeColor = IncidentMain.Shared.EMSFONT;
								}
							}
							else
							{
								ViewModel.txtPerOxy[0].Text = "";
							}
						}
						double dbNumericTemp11 = 0;
						if (!Double.TryParse(ViewModel.txtPerOxy[0].Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp11))
						{
							ViewModel.txtPerOxy[0].Text = "";
						}
						else if (Conversion.Val(ViewModel.txtPerOxy[0].Text) > 100)
						{
							ViewModel.txtPerOxy[0].Text = "";
						}
						//Validate Additional Vitals
						for (i = 1; i <= 4; i++)
						{
							double dbNumericTemp12 = 0;
							if (!Double.TryParse(ViewModel.txtPulse[i].Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp12))
							{
								ViewModel.txtPulse[i].Text = "";
							}
							double dbNumericTemp13 = 0;
							if (!Double.TryParse(ViewModel.txtRespiration[i].Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp13))
							{
								ViewModel.txtRespiration[i].Text = "";
							}
							double dbNumericTemp14 = 0;
							if (!Double.TryParse(ViewModel.txtSystolic[i].Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp14))
							{
								ViewModel.txtSystolic[i].Text = "";
							}
							double dbNumericTemp15 = 0;
							if (!Double.TryParse(ViewModel.txtDiastolic[i].Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp15))
							{
								ViewModel.txtDiastolic[i].Text = "";
							}
							double dbNumericTemp16 = 0;
							if (!Double.TryParse(ViewModel.txtGlucose[i].Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp16))
							{
								ViewModel.txtGlucose[i].Text = "";
							}
							double dbNumericTemp17 = 0;
							if (!Double.TryParse(ViewModel.txtPulseOxy[i].Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp17))
							{
								ViewModel.txtPulseOxy[i].Text = "";
							}
							else
							{
								if ( ViewModel.txtPulseOxy[i].Text != "")
								{
									double dbNumericTemp18 = 0;
									if ( ViewModel.txtPerOxy[i].Text == "")
									{
										ViewModel.txtPerOxy[i].BackColor = IncidentMain.Shared.REQCOLOR;
										ViewModel.txtPerOxy[i].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
										result = 0;
									}
									else if (!Double.TryParse(ViewModel.txtPerOxy[i].Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp18))
									{
										ViewModel.txtPerOxy[i].BackColor = IncidentMain.Shared.REQCOLOR;
										ViewModel.txtPerOxy[i].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
										ViewModel.txtPerOxy[i].Text = "";
										result = 0;
									}
									else if (Conversion.Val(ViewModel.txtPerOxy[i].Text) > 100)
									{
										ViewModel.txtPerOxy[i].BackColor = IncidentMain.Shared.REQCOLOR;
										ViewModel.txtPerOxy[i].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
										ViewModel.txtPerOxy[i].Text = "";
										result = 0;
									}
									else
									{
										ViewModel.txtPerOxy[i].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
										ViewModel.txtPerOxy[i].ForeColor = IncidentMain.Shared.EMSFONT;
									}
								}
								else
								{
									ViewModel.txtPerOxy[i].Text = "";
								}
							}
							double dbNumericTemp19 = 0;
							if (!Double.TryParse(ViewModel.txtPerOxy[i].Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp19))
							{
								ViewModel.txtPerOxy[i].Text = "";
							}
							else if (Conversion.Val(ViewModel.txtPerOxy[i].Text) > 100)
							{
								ViewModel.txtPerOxy[i].Text = "";
							}
						}
						if ( ViewModel.cboVitalsPosition[0].SelectedIndex == -1)
						{
							ViewModel.cboVitalsPosition[0].BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.cboVitalsPosition[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							result = 0;
						}
						else
						{
							ViewModel.cboVitalsPosition[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.cboVitalsPosition[0].ForeColor = IncidentMain.Shared.EMSFONT;
						}
						if ( ViewModel.cboEyes[0].SelectedIndex < 0)
						{
							ViewModel.cboEyes[0].BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.cboEyes[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							result = 0;
						}
						else
						{
							ViewModel.cboEyes[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.cboEyes[0].ForeColor = IncidentMain.Shared.EMSFONT;
						}
						if ( ViewModel.cboVerbal[0].SelectedIndex < 0)
						{
							ViewModel.cboVerbal[0].BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.cboVerbal[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							result = 0;
						}
						else
						{
							ViewModel.cboVerbal[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.cboVerbal[0].ForeColor = IncidentMain.Shared.EMSFONT;
						}
						if ( ViewModel.cboMotor[0].SelectedIndex < 0)
						{
							ViewModel.cboMotor[0].BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.cboMotor[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							result = 0;
						}
						else
						{
							ViewModel.cboMotor[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.cboMotor[0].ForeColor = IncidentMain.Shared.EMSFONT;
						}
					}
					else
					{
						ViewModel.txtTime[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.txtTime[0].ForeColor = IncidentMain.Shared.EMSFONT;
						ViewModel.txtPulse[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.txtPulse[0].ForeColor = IncidentMain.Shared.EMSFONT;
						ViewModel.txtRespiration[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.txtRespiration[0].ForeColor = IncidentMain.Shared.EMSFONT;
						ViewModel.txtSystolic[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.txtSystolic[0].ForeColor = IncidentMain.Shared.EMSFONT;
						ViewModel.txtDiastolic[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.txtDiastolic[0].ForeColor = IncidentMain.Shared.EMSFONT;
						ViewModel.chkPalp[0].BackColor = IncidentMain.Shared.EMSCOLOR;
						ViewModel.chkPalp[0].ForeColor = IncidentMain.Shared.EMSFONT;
						ViewModel.chkPalp[0].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
						ViewModel.cboVitalsPosition[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboVitalsPosition[0].ForeColor = IncidentMain.Shared.EMSFONT;
						ViewModel.cboEyes[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboEyes[0].ForeColor = IncidentMain.Shared.EMSFONT;
						ViewModel.cboVerbal[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboVerbal[0].ForeColor = IncidentMain.Shared.EMSFONT;
						ViewModel.cboMotor[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboMotor[0].ForeColor = IncidentMain.Shared.EMSFONT;
						if ( ViewModel.rtxNarration.Text == "")
						{
							ViewModel.rtxNarration.BackColor = IncidentMain.Shared.REQCOLOR;
							result = 0;
						}
						else
						{
							ViewModel.rtxNarration.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						}
					}
					if (!ViewModel.optSeverity[0].Checked && !ViewModel.optSeverity[1].Checked && !ViewModel.optSeverity[2].Checked)
					{
						//frmSeverity.BackColor = REQCOLOR
						ViewModel.frmSeverity.Font = ViewModel.frmSeverity.Font.Change(name:IncidentMain.WHITE.ToString());
						ViewModel.optSeverity[0].BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.optSeverity[1].BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.optSeverity[2].BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.optSeverity[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.optSeverity[1].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.optSeverity[2].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					}
					else
					{
						ViewModel.optSeverity[0].BackColor = IncidentMain.Shared.EMSCOLOR;
						ViewModel.optSeverity[1].BackColor = IncidentMain.Shared.EMSCOLOR;
						ViewModel.optSeverity[2].BackColor = IncidentMain.Shared.EMSCOLOR;
						ViewModel.optSeverity[0].ForeColor = IncidentMain.Shared.EMSFONT;
						ViewModel.optSeverity[1].ForeColor = IncidentMain.Shared.EMSFONT;
						ViewModel.optSeverity[2].ForeColor = IncidentMain.Shared.EMSFONT;
					}
					if ( ViewModel.TraumaSwitch != 0)
					{
						double dbNumericTemp20 = 0;
						if ( ViewModel.txtTraumaID.Text == "")
						{
							ViewModel.txtTraumaID.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.txtTraumaID.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							result = 0;
						}
						else if (!Double.TryParse(ViewModel.txtTraumaID.Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp20))
						{
							ViewModel.txtTraumaID.Text = "";
							ViewModel.txtTraumaID.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.txtTraumaID.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							result = 0;
						}
						else
						{
							ViewModel.txtTraumaID.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.txtTraumaID.ForeColor = IncidentMain.Shared.EMSFONT;
							if (Strings.Len(ViewModel.txtTraumaID.Text) > 7)
							{
								ViewModel.txtTraumaID.Text = ViewModel.txtTraumaID.Text.Substring(0, Math.Min(7, ViewModel.txtTraumaID.Text.Length));
							}
						}
						if ( ViewModel.cboProtectiveDevice.SelectedIndex < 0)
						{
							ViewModel.cboProtectiveDevice.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.cboProtectiveDevice.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							result = 0;
						}
						else
						{
							ViewModel.cboProtectiveDevice.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.cboProtectiveDevice.ForeColor = IncidentMain.Shared.EMSFONT;
						}
						if ( ViewModel.cboPatientLocation.SelectedIndex < 0)
						{
							ViewModel.cboPatientLocation.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.cboPatientLocation.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							result = 0;
						}
						else
						{
							ViewModel.cboPatientLocation.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.cboPatientLocation.ForeColor = IncidentMain.Shared.EMSFONT;
						}
						//Trauma steps
						OptCheck = 0;
						for (i = 0; i <= ViewModel.lstTrauma1.Items.Count - 1; i++)
						{
							// not showing it selected!  why?
							if ( ViewModel.lstTrauma1.GetSelected( i))
							{
								OptCheck = -1;
								break;
							}
						}
						if (~OptCheck != 0)
						{
							for (i = 0; i <= ViewModel.lstTrauma2.Items.Count - 1; i++)
							{
								if ( ViewModel.lstTrauma2.GetSelected( i))
								{
									OptCheck = -1;
									break;
								}
							}
						}
						if (~OptCheck != 0)
						{
							for (i = 0; i <= ViewModel.lstTrauma3.Items.Count - 1; i++)
							{
								if ( ViewModel.lstTrauma3.GetSelected( i))
								{
									OptCheck = -1;
									break;
								}
							}
						}
						if (~OptCheck != 0)
						{
							ViewModel.lstTrauma1.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.lstTrauma1.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.lstTrauma2.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.lstTrauma2.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.lstTrauma3.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.lstTrauma3.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							result = 0;
						}
						else
						{
							ViewModel.lstTrauma1.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.lstTrauma1.ForeColor = IncidentMain.Shared.EMSFONT;
							ViewModel.lstTrauma2.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.lstTrauma2.ForeColor = IncidentMain.Shared.EMSFONT;
							ViewModel.lstTrauma3.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.lstTrauma3.ForeColor = IncidentMain.Shared.EMSFONT;
						}
					}
					break;
			}
			switch( ViewModel.ActionTaken)
			{
				case 2 : case 6 :  //Exam & Assist, Exam-Assist-Transport 
					if ( ViewModel.cboTreatmentAuth.SelectedIndex < 0)
					{
						ViewModel.cboTreatmentAuth.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.cboTreatmentAuth.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						result = 0;
					}
					else
					{
						ViewModel.cboTreatmentAuth.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboTreatmentAuth.ForeColor = IncidentMain.Shared.EMSFONT;
					}
					if ( ViewModel.ExtricationSwitch != 0)
					{
						double dbNumericTemp21 = 0;
						if ( ViewModel.txtExtricationTime.Text == "")
						{
							ViewModel.txtExtricationTime.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.txtExtricationTime.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							result = 0;
						}
						else if (!Double.TryParse(ViewModel.txtExtricationTime.Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp21))
						{
							ViewModel.txtExtricationTime.Text = "";
							ViewModel.txtExtricationTime.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.txtExtricationTime.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							result = 0;
						}
						else
						{
							ViewModel.txtExtricationTime.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.txtExtricationTime.ForeColor = IncidentMain.Shared.EMSFONT;
						}
					}
					else
					{
						ViewModel.txtExtricationTime.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.txtExtricationTime.ForeColor = IncidentMain.Shared.EMSFONT;
					}
					if ( ViewModel.cboALSProcedures.SelectedIndex > -1)
					{
						switch( ViewModel.cboALSProcedures.GetItemData(ViewModel.cboALSProcedures.SelectedIndex))
						{
							case 14 : case 15 : case 16 :  //IV 
								double dbNumericTemp22 = 0;
								if ( ViewModel.txtAttempts.Text == "")
								{
									ViewModel.txtAttempts.BackColor = IncidentMain.Shared.REQCOLOR;
									ViewModel.txtAttempts.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
									result = 0;
								}
								else if (!Double.TryParse(ViewModel.txtAttempts.Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp22))
								{
									ViewModel.txtAttempts.BackColor = IncidentMain.Shared.REQCOLOR;
									ViewModel.txtAttempts.Font = ViewModel.txtAttempts.Font.Change(name:IncidentMain.WHITE.ToString());
									ViewModel.txtAttempts.Text = "";
									result = 0;
								}
								else
								{
									ViewModel.txtAttempts.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
									ViewModel.txtAttempts.ForeColor = IncidentMain.Shared.EMSFONT;
								}
								break;
							case 12 : case 26 : case 27 :  //Entubation 
								double dbNumericTemp23 = 0;
								if ( ViewModel.txtAttempts.Text == "")
								{
									ViewModel.txtAttempts.BackColor = IncidentMain.Shared.REQCOLOR;
									ViewModel.txtAttempts.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
									result = 0;
								}
								else if (!Double.TryParse(ViewModel.txtAttempts.Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp23))
								{
									ViewModel.txtAttempts.BackColor = IncidentMain.Shared.REQCOLOR;
									ViewModel.txtAttempts.Font = ViewModel.txtAttempts.Font.Change(name:IncidentMain.WHITE.ToString());
									ViewModel.txtAttempts.Text = "";
									result = 0;
								}
								else
								{
									ViewModel.txtAttempts.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
									ViewModel.txtAttempts.ForeColor = IncidentMain.Shared.EMSFONT;
								}

								break;
						}
					}
					if ( ViewModel.IVSwitch != 0)
					{
						if ( ViewModel.cboGauge[0].Text == "")
						{
							ViewModel.cboGauge[0].BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.cboGauge[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							result = 0;
						}
						else
						{
							ViewModel.cboGauge[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.cboGauge[0].ForeColor = IncidentMain.Shared.EMSFONT;
						}
						if ( ViewModel.cboRoute[0].Text == "")
						{
							ViewModel.cboRoute[0].BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.cboRoute[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							result = 0;
						}
						else
						{
							ViewModel.cboRoute[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.cboRoute[0].ForeColor = IncidentMain.Shared.EMSFONT;
						}
						if ( ViewModel.cboRate[0].Text == "")
						{
							ViewModel.cboRate[0].BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.cboRate[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							result = 0;
						}
						else
						{
							ViewModel.cboRate[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.cboRate[0].ForeColor = IncidentMain.Shared.EMSFONT;
						}
						double dbNumericTemp24 = 0;
						if ( ViewModel.txtAmount[0].Text == "")
						{
							ViewModel.txtAmount[0].BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.txtAmount[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							result = 0;
						}
						else if (!Double.TryParse(ViewModel.txtAmount[0].Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp24))
						{
							ViewModel.txtAmount[0].BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.txtAmount[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.txtAmount[0].Text = "";
							result = 0;
						}
						else
						{
							ViewModel.txtAmount[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.txtAmount[0].ForeColor = IncidentMain.Shared.EMSFONT;
						}
						if ( ViewModel.cboSite[0].Text == "")
						{
							ViewModel.cboSite[0].BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.cboSite[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							result = 0;
						}
						else
						{
							ViewModel.cboSite[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.cboSite[0].ForeColor = IncidentMain.Shared.EMSFONT;
						}
					}
					else
					{
						ViewModel.cboGauge[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboGauge[0].ForeColor = IncidentMain.Shared.EMSFONT;
						ViewModel.cboRoute[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboRoute[0].ForeColor = IncidentMain.Shared.EMSFONT;
						ViewModel.cboRate[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboRate[0].ForeColor = IncidentMain.Shared.EMSFONT;
						ViewModel.txtAmount[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.txtAmount[0].ForeColor = IncidentMain.Shared.EMSFONT;
						ViewModel.cboSite[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboSite[0].ForeColor = IncidentMain.Shared.EMSFONT;
					}
					if ( ViewModel.cboMedications.SelectedIndex != -1)
					{
						double dbNumericTemp25 = 0;
						if ( ViewModel.txtDosage.Text == "")
						{
							ViewModel.txtDosage.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.txtDosage.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							result = 0;
						}
						else if (!Double.TryParse(ViewModel.txtDosage.Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp25))
						{
							ViewModel.txtDosage.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.txtDosage.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.txtDosage.Text = "";
							result = 0;
						}
						else
						{
							ViewModel.txtDosage.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.txtDosage.ForeColor = IncidentMain.Shared.EMSFONT;
						}
					}
					if ( ViewModel.CPRSwitch != 0)
					{
						if (~EMSReport.GetEMSCPRPerformerRS(ViewModel.PatientID) != 0)
						{
							ViewModel.cboCPRPerformedBy.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.cboCPRPerformedBy.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							result = 0;
						}
						else
						{
							ViewModel.cboCPRPerformedBy.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.cboCPRPerformedBy.ForeColor = IncidentMain.Shared.EMSFONT;
						}
						//CPR option buttons
						//button 1
						OptCheck = 0;
						for (i = 0; i <= 3; i++)
						{
							if ( ViewModel.optArrestToCPR[i].Checked)
							{
								for (int x = 0; x <= 3; x++)
								{
									ViewModel.optArrestToCPR[x].BackColor = IncidentMain.Shared.EMSCOLOR;
									ViewModel.optArrestToCPR[x].ForeColor = IncidentMain.Shared.EMSFONT;
								}
								OptCheck = -1;
								break;
							}
						}
						//if none are checked then...
						if (~OptCheck != 0)
						{
							for (i = 0; i <= 3; i++)
							{
								ViewModel.optArrestToCPR[i].BackColor = IncidentMain.Shared.REQCOLOR;
								ViewModel.optArrestToCPR[i].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							}
							result = 0;
						}
					}
					if ( ViewModel.cboALSProcedures.SelectedIndex > -1)
					{
						switch( ViewModel.cboALSProcedures.GetItemData(ViewModel.cboALSProcedures.SelectedIndex))
						{
							case 12 : case 14 : case 15 : case 16 : case 26 : case 27 :  //IV or Intub 
								double dbNumericTemp26 = 0;
								if ( ViewModel.txtAttempts.Text == "")
								{
									ViewModel.txtAttempts.BackColor = IncidentMain.Shared.REQCOLOR;
									ViewModel.txtAttempts.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
									result = 0;
								}
								else if (!Double.TryParse(ViewModel.txtAttempts.Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp26))
								{
									ViewModel.txtAttempts.Text = "";
									ViewModel.txtAttempts.BackColor = IncidentMain.Shared.REQCOLOR;
									ViewModel.txtAttempts.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
									result = 0;
								}
								else
								{
									ViewModel.txtAttempts.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
									ViewModel.txtAttempts.ForeColor = IncidentMain.Shared.EMSFONT;
								}
								break;
						}
					}
					//if base station contact, optMDorRN is required 
					break;
			}
			switch( ViewModel.ActionTaken)
			{
				case 2 : case 7 :  //-Transport or Interfacility Transfer 
					if ( ViewModel.cboTransportTo.SelectedIndex < 0)
					{
						ViewModel.cboTransportTo.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.cboTransportTo.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						result = 0;
					}
					else
					{
						ViewModel.cboTransportTo.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboTransportTo.ForeColor = IncidentMain.Shared.EMSFONT;
					}
					if ( ViewModel.cboTransportBy.Enabled)
					{
						ViewModel.txtMileage.Enabled = true;
						ViewModel.chkDiverted.Enabled = true;
						ViewModel.lbPInfo[41].ForeColor = IncidentMain.Shared.EMSFONT;
						if ( ViewModel.cboTransportBy.SelectedIndex == -1)
						{
							ViewModel.cboTransportBy.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.cboTransportBy.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							result = 0;
							double dbNumericTemp27 = 0;
							if ( ViewModel.txtMileage.Text == "")
							{
								ViewModel.txtMileage.BackColor = IncidentMain.Shared.REQCOLOR;
								ViewModel.txtMileage.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							}
							else if ( ViewModel.txtMileage.Text == ".")
							{
								ViewModel.txtMileage.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
								ViewModel.txtMileage.ForeColor = IncidentMain.Shared.EMSFONT;
							}
							else if (!Double.TryParse(ViewModel.txtMileage.Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp27))
							{
								ViewModel.txtMileage.BackColor = IncidentMain.Shared.REQCOLOR;
								ViewModel.txtMileage.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
								ViewModel.txtMileage.Text = "";
							}
							else
							{
								ViewModel.txtMileage.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
								ViewModel.txtMileage.ForeColor = IncidentMain.Shared.EMSFONT;
							}
						}
						else
						{
							ViewModel.cboTransportBy.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.cboTransportBy.ForeColor = IncidentMain.Shared.EMSFONT;
							//*** Check for TFD Unit

							double dbNumericTemp28 = 0;
							if (UnitCL.GetTFDUnit(ViewModel.cboTransportBy.Text) == "")
							{
								ViewModel.txtMileage.Text = "";
								ViewModel.txtMileage.Enabled = false;
								ViewModel.txtMileage.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
								ViewModel.txtMileage.ForeColor = IncidentMain.Shared.EMSFONT;
								ViewModel.lbPInfo[41].ForeColor = IncidentMain.Shared.DKGRAY;
								ViewModel.chkDiverted.Enabled = false;
							}
							else if ( ViewModel.txtMileage.Text == "")
							{
								ViewModel.txtMileage.BackColor = IncidentMain.Shared.REQCOLOR;
								ViewModel.txtMileage.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
								result = 0;
							}
							else if ( ViewModel.txtMileage.Text == ".")
							{
								ViewModel.txtMileage.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
								ViewModel.txtMileage.ForeColor = IncidentMain.Shared.EMSFONT;
							}
							else if (!Double.TryParse(ViewModel.txtMileage.Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp28))
							{
								ViewModel.txtMileage.BackColor = IncidentMain.Shared.REQCOLOR;
								ViewModel.txtMileage.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
								ViewModel.txtMileage.Text = "";
								result = 0;
							}
							else
							{
								ViewModel.txtMileage.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
								ViewModel.txtMileage.ForeColor = IncidentMain.Shared.EMSFONT;
							}
						}
					}
					else
					{
						//                txtMileage.Text = ""
						//               this behavior clearing the mileage during readonly viewing
						//                txtMileage.Enabled = False
						//                chkDiverted.Enabled = False
						//                lbMileage.ForeColor = DKGRAY
					}
					if ( ViewModel.cboHospitalChosenBy.SelectedIndex < 0)
					{
						ViewModel.cboHospitalChosenBy.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.cboHospitalChosenBy.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						result = 0;
					}
					else
					{
						ViewModel.cboHospitalChosenBy.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboHospitalChosenBy.ForeColor = IncidentMain.Shared.EMSFONT;
					}
					break;
			}
			if ( ViewModel.ActionTaken == 7)
			{
				if ( ViewModel.cboTransportFrom.SelectedIndex == -1)
				{
					ViewModel.cboTransportFrom.BackColor = IncidentMain.Shared.REQCOLOR;
					ViewModel.cboTransportFrom.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					ViewModel.lbPInfo[40].ForeColor = IncidentMain.Shared.EMSFONT;
					result = 0;
				}
				else
				{
					ViewModel.cboTransportFrom.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					ViewModel.cboTransportFrom.ForeColor = IncidentMain.Shared.EMSFONT;
					ViewModel.lbPInfo[40].ForeColor = IncidentMain.Shared.EMSFONT;
				}
			}
			else
			{
				ViewModel.cboTransportFrom.Enabled = false;
				ViewModel.lbPInfo[40].ForeColor = IncidentMain.Shared.DKGRAY;
			}
			ViewModel.cmdSave[0].Enabled = result != 0;
			ViewModel.FirstTime = 0;
			return result;
		}

		private void LoadALSProcedures()
		{
			//Load lstbox with ALS Procedures
			TFDIncident.clsEMS EMSReport = Container.Resolve< clsEMS>();
			string sDisplay = "";
			ViewModel.lstALSProcedures.Items.Clear();
			ViewModel.IVSwitch = 0;
			if (EMSReport.GetEMSProcedureByType(ViewModel.PatientID, "A") != 0)
			{

				while(!EMSReport.EMSProcedure.EOF)
				{
					sDisplay = IncidentMain.Clean(EMSReport.EMSProcedure["name_full"]) + " - ";
					sDisplay = sDisplay + IncidentMain.Clean(EMSReport.EMSProcedure["description"]);
					ViewModel.lstALSProcedures.AddItem(sDisplay);
					ViewModel.lstALSProcedures.SetItemData(ViewModel.lstALSProcedures.GetNewIndex(), Convert.ToInt32(EMSReport.EMSProcedure["procedure_id"]));
					if (Convert.ToDouble(EMSReport.EMSProcedure["proc_code"]) == 14 || Convert.ToDouble(EMSReport.EMSProcedure["proc_code"]) == 15 || Convert.ToDouble(EMSReport.EMSProcedure["proc_code"]) == 16)
					{
						ViewModel.IVSwitch = -1;
					}
					EMSReport.EMSProcedure.MoveNext();
				};
				ViewModel.cmdRemoveALSProcedures.Enabled = true;
				if ( ViewModel.cboTransportTo.SelectedIndex != -1)
				{
					ViewModel.EMSType = IncidentMain.ALSTRANS;
				}
				else
				{
					ViewModel.EMSType = IncidentMain.ALS;
				}
			}
			else
			{
				ViewModel.cmdRemoveALSProcedures.Enabled = false;
			}

			CheckComplete();

		}

		private void LoadBLSProcedures()
		{
			//Load lstbox with BLS Procedures
			TFDIncident.clsEMS EMSReport = Container.Resolve< clsEMS>();
			string sDisplay = "";
			ViewModel.lstBLSProcedures.Items.Clear();
			ViewModel.ExtricationSwitch = 0;
			if (EMSReport.GetEMSProcedureByType(ViewModel.PatientID, "B") != 0)
			{

				while(!EMSReport.EMSProcedure.EOF)
				{
					sDisplay = IncidentMain.Clean(EMSReport.EMSProcedure["name_full"]) + " - ";
					sDisplay = sDisplay + IncidentMain.Clean(EMSReport.EMSProcedure["description"]);
					ViewModel.lstBLSProcedures.AddItem(sDisplay);
					ViewModel.lstBLSProcedures.SetItemData(ViewModel.lstBLSProcedures.GetNewIndex(), Convert.ToInt32(EMSReport.EMSProcedure["procedure_id"]));
					switch(Convert.ToInt32(EMSReport.EMSProcedure["proc_code"]))
					{
						case 3 : case 5 : case 33 : case 34 : case 35 :  //Extrication 

							ViewModel.ExtricationSwitch = -1;
							break;
						case 8 : case 31 :  //CPR performed 

							ViewModel.chkCPRPerformed.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
							break;
					}

					EMSReport.EMSProcedure.MoveNext();
				};
				ViewModel.cmdRemoveBLSProcedures.Enabled = true;
			}
			else
			{
				ViewModel.cmdRemoveBLSProcedures.Enabled = false;
			}

		}

		private void LoadMedication()
		{
			//Load lstbox with Medication records
			TFDIncident.clsEMS EMSReport = Container.Resolve< clsEMS>();
			string sDisplay = "";
			ViewModel.lstMedications.Items.Clear();
			if (EMSReport.GetEMSMedicationRS(ViewModel.PatientID) != 0)
			{

				while(!EMSReport.EMSMedication.EOF)
				{
					sDisplay = IncidentMain.Clean(EMSReport.EMSMedication["description"]) + ":  ";
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					sDisplay = sDisplay + Convert.ToString(IncidentMain.GetVal(EMSReport.EMSMedication["administered_dosage"]));
					ViewModel.lstMedications.AddItem(sDisplay);
					ViewModel.lstMedications.SetItemData(ViewModel.lstMedications.GetNewIndex(), Convert.ToInt32(EMSReport.EMSMedication["med_code"]));
					EMSReport.EMSMedication.MoveNext();
				};
				ViewModel.cmdRemoveMedication.Enabled = true;
			}
			else
			{
				ViewModel.cmdRemoveMedication.Enabled = false;
			}

		}

		private void LoadCPRPerformer()
		{
			//Load lstbox with CPR Performer records
			TFDIncident.clsEMS EMSReport = Container.Resolve< clsEMS>();
			string sDisplay = "";
			ViewModel.lstCPRPerformedBy.Items.Clear();
			if (EMSReport.GetEMSCPRPerformerRS(ViewModel.PatientID) != 0)
			{

				while(!EMSReport.EMSCPRPerformer.EOF)
				{
					sDisplay = IncidentMain.Clean(EMSReport.EMSCPRPerformer["description"]);
					ViewModel.lstCPRPerformedBy.AddItem(sDisplay);
					ViewModel.lstCPRPerformedBy.SetItemData(ViewModel.lstCPRPerformedBy.GetNewIndex(), Convert.ToInt32(EMSReport.EMSCPRPerformer["cpr_id"]));
					EMSReport.EMSCPRPerformer.MoveNext();
				};
			}
			CheckComplete();

		}

		private void GetEMSData()
		{
			TFDIncident.clsEMS EMSReport = Container.Resolve< clsEMS>();
			TFDIncident.clsEMSCodes EMSCodes = Container.Resolve< clsEMSCodes>();
			TFDIncident.clsUnit UnitCL = Container.Resolve< clsUnit>();
			int x = 0;
			int BodyPart = 0, Injury = 0;
			ViewModel.FirstTime = -1;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
			this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.WaitCursor);
			//********************************
			// EMSPatientContact Record
			//********************************
			if (~EMSReport.GetEMSPatientContact(ViewModel.PatientID) != 0)
			{
				ViewManager.ShowMessage("Error Retrieving Patient Records", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				return;
			}

			//Set up Main Tabs
			if ( ViewModel.ActionTaken == 3 || ViewModel.ActionTaken == 4 || ViewModel.ActionTaken == 5)
			{
				ViewModel.tabEMS.Items[0].Text = "";
				ViewModel.tabEMS.Items[1].Text = "";
				ViewModel.tabEMS.Items[2].Text = "";
				ViewModel.tabEMS.Items[3].Text = "";
				ViewModel.tabEMS.Items[4].Text = "";
				ViewModel.tabEMS.Items[5].Text = "";
				ViewModel.tabEMS.Items[6].Text = "";
				ViewModel.tabEMS.SelectedIndex = 7;

			}
			else
{
				ViewModel.tabEMS.Items[7].Text = "";
				if ( ViewModel.ActionTaken == 1)
				{
					ViewModel.tabEMS.Items[2].Text = "";
					ViewModel.tabEMS.Items[3].Text = "";
					ViewModel.tabEMS.Items[4].Text = "";
					ViewModel.tabEMS.Items[5].Text = "";
					ViewModel.tabEMS.Items[6].Text = "";
				}
				else if ( ViewModel.ActionTaken == 6 || ViewModel.ActionTaken == 8)
				{
					ViewModel.tabEMS.Items[4].Text = "";
				}
				else if ( ViewModel.ActionTaken == 7)
				{
					ViewModel.tabEMS.Items[1].Text = "";
					ViewModel.tabEMS.Items[2].Text = "";
					ViewModel.tabEMS.Items[3].Text = "";
					ViewModel.tabEMS.Items[5].Text = "";
					ViewModel.tabEMS.Items[6].Text = "";
				}
				ViewModel.tabEMS.SelectedIndex = 0;
			}


			//Narration
			LoadNarration(0);

			for (int i = 0; i <= ViewModel.cboIncidentLocation.Items.Count - 1; i++)
			{
				if ( ViewModel.cboIncidentLocation.GetItemData(i) == EMSReport.IncidentLocation)
				{
					ViewModel.cboIncidentLocation.SelectedIndex = i;
					break;
				}
			}
			ViewModel.txtIncidentZipcode.Text = EMSReport.IncidentZipcode;
			for (int i = 0; i <= ViewModel.cboIncidentSetting.Items.Count - 1; i++)
			{
				if ( ViewModel.cboIncidentSetting.GetItemData(i) == EMSReport.IncidentSetting)
				{
					ViewModel.cboIncidentSetting.SelectedIndex = i;
					break;
				}
			}
			for (int i = 0; i <= ViewModel.cboResearchCode.Items.Count - 1; i++)
			{
				if ( ViewModel.cboResearchCode.GetItemData(i) == EMSReport.ResearchCode)
				{
					ViewModel.cboResearchCode.SelectedIndex = i;
					break;
				}
			}



			if ( ViewModel.ActionTaken == 3 || ViewModel.ActionTaken == 4 || ViewModel.ActionTaken == 5)
			{
				//Noexam -  Load Basic Info /Patient Name Info and Exit
				ViewModel.txtAge.Text = EMSReport.Age.ToString();
				for (int i = 0; i <= ViewModel.cboAgeUnits.Items.Count - 1; i++)
				{
					if ( ViewModel.cboAgeUnits.GetItemData(i) == EMSReport.AgeUnit)
					{
						ViewModel.cboAgeUnits.SelectedIndex = i;
						break;
					}
				}
				if (EMSReport.Gender == 1)
				{
					ViewModel.optEMSGender[0].Checked = true;
				}
				else if (EMSReport.Gender == 2)
				{
					ViewModel.optEMSGender[1].Checked = true;
				}
				else
				{
					ViewModel.optEMSGender[0].Checked = false;
					ViewModel.optEMSGender[1].Checked = false;
				}
				for (int i = 0; i <= ViewModel.cboEMSRace.Items.Count - 1; i++)
				{
					if ( ViewModel.cboEMSRace.GetItemData(i) == EMSReport.Race)
					{
						ViewModel.cboEMSRace.SelectedIndex = i;
						break;
					}
				}
				if (EMSReport.Ethnicity == 3)
				{
					ViewModel.optEMSEthnicity[0].Checked = true;
				}
				else if (EMSReport.Ethnicity == 4)
				{
					ViewModel.optEMSEthnicity[1].Checked = true;
				}
				else
				{
					ViewModel.optEMSEthnicity[0].Checked = false;
					ViewModel.optEMSEthnicity[1].Checked = false;
				}
				for (int i = 0; i <= ViewModel.cboServiceProvided.Items.Count - 1; i++)
				{
					if ( ViewModel.cboServiceProvided.GetItemData(i) == EMSReport.ServiceProvided)
					{
						ViewModel.cboServiceProvided.SelectedIndex = i;
						break;
					}
				}
				if (EMSReport.GetEMSPatient(ViewModel.PatientID) != 0)
				{
					//Display Name Info if Present
					if (EMSReport.Birthdate != "")
					{
						ViewModel.txtBBirthdate.Text = DateTime.Parse(EMSReport.Birthdate).ToString("MM/dd/yyyy");
					}
					else
					{
						ViewModel.txtBBirthdate.Text = "__/__/____";
					}
					ViewModel.txtBFirstName.Text = EMSReport.NameFirst;
					ViewModel.txtBLastName.Text = EMSReport.NameLast;
					ViewModel.txtBMI.Text = EMSReport.NameMI;
					ViewModel.txtBHomePhone.Text = EMSReport.Phone;
				}
				else
				{
					ViewModel.txtBFirstName.Text = "";
					ViewModel.txtBLastName.Text = "";
					ViewModel.txtBMI.Text = "";
					ViewModel.txtBHomePhone.Text = "";
					ViewModel.txtBBirthdate.Text = "__/__/____";
				}
				//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
				this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.Arrow);
				return;
			}

			//EMS Patient Contact continued...
			if (EMSReport.Age == 0)
			{
				ViewModel.txtPatientAge.Text = "";
			}
			else
			{
				ViewModel.txtPatientAge.Text = EMSReport.Age.ToString();
			}
			for (int i = 0; i <= ViewModel.cboPatientAgeUnits.Items.Count - 1; i++)
			{
				if ( ViewModel.cboPatientAgeUnits.GetItemData(i) == EMSReport.AgeUnit)
				{
					ViewModel.cboPatientAgeUnits.SelectedIndex = i;
					break;
				}
			}
			if (EMSReport.Gender == 1)
			{
				ViewModel.optGender[0].Checked = true;
			}
			else if (EMSReport.Gender == 2)
			{
				ViewModel.optGender[1].Checked = true;
			}
			else
			{
				ViewModel.optGender[0].Checked = false;
				ViewModel.optGender[1].Checked = false;
			}
			for (int i = 0; i <= ViewModel.cboRace.Items.Count - 1; i++)
			{
				if ( ViewModel.cboRace.GetItemData(i) == EMSReport.Race)
				{
					ViewModel.cboRace.SelectedIndex = i;
					break;
				}
			}
			if (EMSReport.Ethnicity == 3)
			{
				ViewModel.optEthnicity[0].Checked = true;
			}
			else if (EMSReport.Ethnicity == 4)
			{
				ViewModel.optEthnicity[1].Checked = true;
			}
			else
			{
				ViewModel.optEthnicity[0].Checked = false;
				ViewModel.optEthnicity[1].Checked = false;
			}
			if (EMSReport.Severity == 1)
			{
				ViewModel.optSeverity[0].Checked = true;
			}
			else if (EMSReport.Severity == 2)
			{
				ViewModel.optSeverity[0].Checked = true;
			}
			else if (EMSReport.Severity == 3)
			{
				ViewModel.optSeverity[1].Checked = true;
			}
			else if (EMSReport.Severity == 4)
			{
				ViewModel.optSeverity[2].Checked = true;
			}
			else
			{
				ViewModel.optSeverity[0].Checked = false;
				ViewModel.optSeverity[1].Checked = false;
				ViewModel.optSeverity[2].Checked = false;
			}
			if (EMSReport.TreatmentAuthorization != 0)
			{
				for (int i = 0; i <= ViewModel.cboTreatmentAuth.Items.Count - 1; i++)
				{
					if ( ViewModel.cboTreatmentAuth.GetItemData(i) == EMSReport.TreatmentAuthorization)
					{
						ViewModel.cboTreatmentAuth.SelectedIndex = i;
						break;
					}
				}
			}

			//***********************************************
			// EMS Patient Record
			//***********************************************
			if (EMSReport.GetEMSPatient(ViewModel.PatientID) != 0)
			{
				if (EMSReport.Birthdate != "")
				{
					ViewModel.mskBirthdate.Text = DateTime.Parse(EMSReport.Birthdate).ToString("MM/dd/yyyy");
				}
				else
				{
					ViewModel.mskBirthdate.Text = "__/__/____";

				}
				ViewModel.txtFirstName.Text = EMSReport.NameFirst;
				ViewModel.txtLastName.Text = EMSReport.NameLast;
				ViewModel.txtMI.Text = EMSReport.NameMI;
				if (EMSReport.SocialSecurityNumber != "")
				{
					ViewModel.mskSSN.Text = EMSReport.SocialSecurityNumber;
				}
				else
				{
					ViewModel.mskSSN.Text = "___-__-____";
				}
				ViewModel.txtBillingAddress.Text = EMSReport.BillingAddress;
				ViewModel.txtCity.Text = EMSReport.City;
				ViewModel.txtZipCode.Text = EMSReport.Zipcode;
				if (EMSReport.State != "")
				{
					for (int i = 0; i <= ViewModel.cboState.Items.Count - 1; i++)
					{
						ViewModel.cboState.SelectedIndex = i;
						if ( ViewModel.cboState.Text == EMSReport.State)
						{
							break;
						}
					}
				}
				ViewModel.txtHomePhone.Text = EMSReport.Phone;
				if (EMSReport.FlagDNRO != 0)
				{
					ViewModel.chkDNR.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
				}
				else
				{
					ViewModel.chkDNR.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
				}
			}
			else
			{
				ViewManager.ShowMessage("Error attempting to retrieve Patient Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
			}

			//--------- EMS PreExisting Conditions -------------
			if (EMSReport.GetEMSPreExistingConditionRS(ViewModel.PatientID) != 0)
			{
				//Load PreExisting

				while(!EMSReport.EMSPreExistingCondition.EOF)
				{
					for (int i = 0; i <= ViewModel.lstPriorMedicalHistory.Items.Count - 1; i++)
					{
						if ( ViewModel.lstPriorMedicalHistory.GetItemData(i) == Convert.ToDouble(EMSReport.EMSPreExistingCondition["pre_existing_condition_code"]))
						{
							UpgradeHelpers.Helpers.ListBoxHelper.SetSelected(ViewModel.lstPriorMedicalHistory, i, true);
							break;
						}
					}
					EMSReport.EMSPreExistingCondition.MoveNext();
				};
			}

			//--------- EMS Contributing Factors ---------------
			if (EMSReport.GetEMSContributingFactorRS(ViewModel.PatientID) != 0)
			{
				//Load Contributing Factors

				while(!EMSReport.EMSContributingFactor.EOF)
				{
					for (int i = 0; i <= ViewModel.lstPossibleFactors.Items.Count - 1; i++)
					{
						if ( ViewModel.lstPossibleFactors.GetItemData(i) == Convert.ToDouble(EMSReport.EMSContributingFactor["ems_contributing_factor_code"]))
						{
							UpgradeHelpers.Helpers.ListBoxHelper.SetSelected(ViewModel.lstPossibleFactors, i, true);
							break;
						}
					}
					EMSReport.EMSContributingFactor.MoveNext();
				};
			}
			//**************************************************
			// EMS Transport Record
			//**************************************************
			if ( ViewModel.ActionTaken == 2 || ViewModel.ActionTaken == 7)
			{
				if (EMSReport.GetEMSPatientTransport(ViewModel.PatientID) != 0)
				{
					for (int i = 0; i <= ViewModel.cboBaseStationContact.Items.Count - 1; i++)
					{
						if ( ViewModel.cboBaseStationContact.GetItemData(i) == EMSReport.BaseStation)
						{
							ViewModel.cboBaseStationContact.SelectedIndex = i;
							break;
						}
					}
					for (int i = 0; i <= ViewModel.cboTransportTo.Items.Count - 1; i++)
					{
						if ( ViewModel.cboTransportTo.GetItemData(i) == EMSReport.TransportedTo)
						{
							ViewModel.cboTransportTo.SelectedIndex = i;
							break;
						}
					}
					for (int i = 0; i <= ViewModel.cboTransportFrom.Items.Count - 1; i++)
					{
						if ( ViewModel.cboTransportFrom.GetItemData(i) == EMSReport.TransportedFrom)
						{
							ViewModel.cboTransportFrom.SelectedIndex = i;
							break;
						}
					}
					for (int i = 0; i <= ViewModel.cboTransportBy.Items.Count - 1; i++)
					{
						if ( ViewModel.cboTransportBy.GetListItem(i) == EMSReport.TransportBy)
						{
							if (UnitCL.GetTFDUnit(EMSReport.TransportBy) != "")
							{
								ViewModel.txtMileage.Enabled = true;
								ViewModel.chkDiverted.Enabled = true;
								ViewModel.lbPInfo[41].ForeColor = IncidentMain.Shared.EMSFONT;
								ViewModel.EMSType = IncidentMain.ALSTRANS;
							}
							else
							{
								//                        txtMileage.Enabled = False
								//                        chkDiverted.Enabled = False
								//                        lbMileage.ForeColor = DKGRAY
								//                        EMSType = BLSTRANS
							}

							ViewModel.cboTransportBy.SelectedIndex = i;
							break;
						}
					}
					for (int i = 0; i <= ViewModel.cboHospitalChosenBy.Items.Count - 1; i++)
					{
						if ( ViewModel.cboHospitalChosenBy.GetItemData(i) == EMSReport.HospitalChosenBy)
						{
							ViewModel.cboHospitalChosenBy.SelectedIndex = i;
							break;
						}
					}
					if (EMSReport.HospitalStaffType == 1)
					{
						ViewModel.optMDorRN[0].Checked = true;
					}
					else if (EMSReport.HospitalStaffType == 2)
					{
						ViewModel.optMDorRN[1].Checked = true;
					}
					else if (EMSReport.HospitalStaffType == 3)
					{
						ViewModel.optMDorRN[2].Checked = true;
					}
					else
					{
						ViewModel.optMDorRN[0].Checked = false;
						ViewModel.optMDorRN[1].Checked = false;
						ViewModel.optMDorRN[2].Checked = false;
					}
					ViewModel.txtMileage.Text = EMSReport.Mileage.ToString();
					if (EMSReport.FlagDiverted != 0)
					{
						ViewModel.chkDiverted.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
					}
					else
					{
						ViewModel.chkDiverted.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
					}
				}
				if ( ViewModel.ActionTaken == 7)
				{
					ViewModel.cboTransportFrom.Enabled = true;
					ViewModel.lbPInfo[40].ForeColor = IncidentMain.Shared.EMSFONT;
					//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
					this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.Arrow);
					return;
				}
				else
				{
					ViewModel.cboTransportFrom.Enabled = false;
					ViewModel.lbPInfo[40].ForeColor = IncidentMain.Shared.DKGRAY;
				}
			}

			//***************************************************
			// Patient Exam - Vitals
			//***************************************************
			if (EMSReport.GetEMSPatientExam(ViewModel.PatientID) != 0)
			{
				for (int i = 0; i <= ViewModel.cboMechCode.Items.Count - 1; i++)
				{
					if ( ViewModel.cboMechCode.GetItemData(i) == EMSReport.MechCode)
					{
						ViewModel.cboMechCode.SelectedIndex = i;
						break;
					}
				}
				switch(EMSReport.MechCode)
				{
					case 3 : case 4 : case 7 : case 12 : case 13 : case 19 : case 22 : case 23 : case 24 : case 27 : case 29 :  //Medical 

						ViewModel.cboInjuryType.Enabled = false;
						ViewModel.cboBodyPart.Enabled = false;
						ViewModel.chkMajTrauma.Enabled = false;
						ViewModel.cboPrimaryIllness.Enabled = true;
						for (int i = 0; i <= ViewModel.cboPrimaryIllness.Items.Count - 1; i++)
						{
							if ( ViewModel.cboPrimaryIllness.GetItemData(i) == EMSReport.PrimaryIllness)
							{
								ViewModel.cboPrimaryIllness.SelectedIndex = i;
								break;
							}
						}
						break;
					default: //Injury 

						ViewModel.cboInjuryType.Enabled = true;
						ViewModel.cboBodyPart.Enabled = true;
						ViewModel.chkMajTrauma.Enabled = true;
						ViewModel.cboPrimaryIllness.Enabled = false;
						BodyPart = EMSCodes.GetInjuryBodyPart(EMSReport.InjuryType);
						Injury = EMSCodes.GetInjuryInjuryDescriptor(EMSReport.InjuryType);
						for (int i = 0; i <= ViewModel.cboInjuryType.Items.Count - 1; i++)
						{
							if ( ViewModel.cboInjuryType.GetItemData(i) == Injury)
							{
								ViewModel.cboInjuryType.SelectedIndex = i;
								break;
							}
						}
						for (int i = 0; i <= ViewModel.cboBodyPart.Items.Count - 1; i++)
						{
							if ( ViewModel.cboBodyPart.GetItemData(i) == BodyPart)
							{
								ViewModel.cboBodyPart.SelectedIndex = i;
								break;
							}
						}
						if (EMSReport.GetEMSPatientTrauma(ViewModel.PatientID) != 0)
						{
							ViewModel.chkMajTrauma.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
						}
						else
						{
							ViewModel.chkMajTrauma.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
						}
						break;
				}
				if (EMSReport.Pupils == 1)
				{
					ViewModel.optPupils[0].Checked = true;
				}
				else if (EMSReport.Pupils == 2)
				{
					ViewModel.optPupils[1].Checked = true;
				}
				else
				{
					ViewModel.optPupils[0].Checked = false;
					ViewModel.optPupils[1].Checked = false;
				}
				if (EMSReport.LevelOfConsciousness == 3)
				{
					ViewModel.optLevelOfConsciouness[0].Checked = true;
				}
				else if (EMSReport.LevelOfConsciousness == 4)
				{
					ViewModel.optLevelOfConsciouness[1].Checked = true;
				}
				else if (EMSReport.LevelOfConsciousness == 5)
				{
					ViewModel.optLevelOfConsciouness[2].Checked = true;
				}
				else
				{
					ViewModel.optLevelOfConsciouness[0].Checked = false;
					ViewModel.optLevelOfConsciouness[1].Checked = false;
					ViewModel.optLevelOfConsciouness[2].Checked = false;
				}
				if (EMSReport.RespiratoryEffort == 6)
				{
					ViewModel.optRespiratoryEffort[0].Checked = true;
				}
				else if (EMSReport.RespiratoryEffort == 7)
				{
					ViewModel.optRespiratoryEffort[1].Checked = true;
				}
				else if (EMSReport.RespiratoryEffort == 8)
				{
					ViewModel.optRespiratoryEffort[2].Checked = true;
				}
				else
				{
					ViewModel.optRespiratoryEffort[0].Checked = false;
					ViewModel.optRespiratoryEffort[1].Checked = false;
					ViewModel.optRespiratoryEffort[2].Checked = false;
				}
				if (EMSReport.ExtricationTime > 0)
				{
					ViewModel.txtExtricationTime.Text = EMSReport.ExtricationTime.ToString();
				}
				else
				{
					ViewModel.txtExtricationTime.Text = "";
				}
			}
			//------------ Secondary Illness ----------------
			if (EMSReport.GetEMSSecondaryIllnessRS(ViewModel.PatientID) != 0)
			{
				//Load PreExisting

				while(!EMSReport.EMSSecondaryIllness.EOF)
				{
					for (int i = 0; i <= ViewModel.lstSecondaryIllness.Items.Count - 1; i++)
					{
						if ( ViewModel.lstSecondaryIllness.GetItemData(i) == Convert.ToDouble(EMSReport.EMSSecondaryIllness["secondary_illness_code"]))
						{
							UpgradeHelpers.Helpers.ListBoxHelper.SetSelected(ViewModel.lstSecondaryIllness, i, true);
							break;
						}
					}
					EMSReport.EMSSecondaryIllness.MoveNext();
				};
			}

			//------------ Patient Vitals -------------------
			if (EMSReport.GetEMSPatientVitalsRS(ViewModel.PatientID) != 0)
			{
				x = 0;
				System.DateTime TempDate = DateTime.FromOADate(0);
				ViewModel.lbExamDate.Text = (DateTime.TryParse(IncidentMain.Clean(EMSReport.EMSPatientVitals["vitals_time"]), out TempDate)) ? TempDate.ToString("MM/dd/yyyy HH:mm") : IncidentMain.Clean(EMSReport.EMSPatientVitals["vitals_time"]);

				while(!EMSReport.EMSPatientVitals.EOF)
				{
					ViewModel.lbVitalsID[x].Text = Convert.ToString(EMSReport.EMSPatientVitals["vitals_id"]);
					System.DateTime TempDate2 = DateTime.FromOADate(0);
					ViewModel.txtTime[x].Text = (DateTime.TryParse(IncidentMain.Clean(EMSReport.EMSPatientVitals["vitals_time"]), out TempDate2)) ? TempDate2.ToString("HH:mm") : IncidentMain.Clean(EMSReport.EMSPatientVitals["vitals_time"]);
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
					if (!Convert.IsDBNull(EMSReport.EMSPatientVitals["pulse"]))
					{
						//UPGRADE_WARNING: (1068) GetVal(EMSReport.EMSPatientVitals(pulse)) of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.txtPulse[x].Text = Convert.ToString(IncidentMain.GetVal(EMSReport.EMSPatientVitals["pulse"]));
					}
					else
					{
						ViewModel.txtPulse[x].Text = "";
					}
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
					if (!Convert.IsDBNull(EMSReport.EMSPatientVitals["respiration_rate"]))
					{
						//UPGRADE_WARNING: (1068) GetVal(EMSReport.EMSPatientVitals(respiration_rate)) of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.txtRespiration[x].Text = Convert.ToString(IncidentMain.GetVal(EMSReport.EMSPatientVitals["respiration_rate"]));
					}
					else
					{
						ViewModel.txtRespiration[x].Text = "";
					}
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
					if (!Convert.IsDBNull(EMSReport.EMSPatientVitals["systolic"]))
					{
						//UPGRADE_WARNING: (1068) GetVal(EMSReport.EMSPatientVitals(systolic)) of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.txtSystolic[x].Text = Convert.ToString(IncidentMain.GetVal(EMSReport.EMSPatientVitals["systolic"]));
					}
					else
					{
						ViewModel.txtSystolic[x].Text = "";
					}
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
					if (!Convert.IsDBNull(EMSReport.EMSPatientVitals["diastolic"]))
					{
						//UPGRADE_WARNING: (1068) GetVal(EMSReport.EMSPatientVitals(diastolic)) of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.txtDiastolic[x].Text = Convert.ToString(IncidentMain.GetVal(EMSReport.EMSPatientVitals["diastolic"]));
					}
					else
					{
						ViewModel.txtDiastolic[x].Text = "";
					}
					if (Convert.ToBoolean(EMSReport.EMSPatientVitals["flag_diastolic_palp"]))
					{
						ViewModel.chkPalp[x].CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
					}
					else
					{
						ViewModel.chkPalp[x].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
					}
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
					if (!Convert.IsDBNull(EMSReport.EMSPatientVitals["blood_glucose"]))
					{
						//UPGRADE_WARNING: (1068) GetVal(EMSReport.EMSPatientVitals(blood_glucose)) of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.txtGlucose[x].Text = Convert.ToString(IncidentMain.GetVal(EMSReport.EMSPatientVitals["blood_glucose"]));
					}
					else
					{
						ViewModel.txtGlucose[x].Text = "";
					}
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
					if (!Convert.IsDBNull(EMSReport.EMSPatientVitals["pulse_oxygen"]))
					{
						//UPGRADE_WARNING: (1068) GetVal(EMSReport.EMSPatientVitals(pulse_oxygen)) of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.txtPulseOxy[x].Text = Convert.ToString(IncidentMain.GetVal(EMSReport.EMSPatientVitals["pulse_oxygen"]));
					}
					else
					{
						ViewModel.txtPulseOxy[x].Text = "";
					}
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
					if (!Convert.IsDBNull(EMSReport.EMSPatientVitals["percent_oxygen"]))
					{
						//UPGRADE_WARNING: (1068) GetVal(EMSReport.EMSPatientVitals(percent_oxygen)) of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.txtPerOxy[x].Text = Convert.ToString(IncidentMain.GetVal(EMSReport.EMSPatientVitals["percent_oxygen"]));
					}
					else
					{
						ViewModel.txtPerOxy[x].Text = "";
					}
					for (int i = 0; i <= ViewModel.cboVitalsPosition[x].Items.Count - 1; i++)
					{
						//UPGRADE_WARNING: (1068) GetVal(EMSReport.EMSPatientVitals(vitals_position)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						if ( ViewModel.cboVitalsPosition[x].GetItemData(i) == Convert.ToDouble(IncidentMain.GetVal(EMSReport.EMSPatientVitals["vitals_position"])))
						{
							ViewModel.cboVitalsPosition[x].SelectedIndex = i;
							break;
						}
					}
					for (int i = 0; i <= ViewModel.cboECG[x].Items.Count - 1; i++)
					{
						//UPGRADE_WARNING: (1068) GetVal(EMSReport.EMSPatientVitals(ecg_code)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						if ( ViewModel.cboECG[x].GetItemData(i) == Convert.ToDouble(IncidentMain.GetVal(EMSReport.EMSPatientVitals["ecg_code"])))
						{
							ViewModel.cboECG[x].SelectedIndex = i;
							break;
						}
					}
					for (int i = 0; i <= ViewModel.cboEyes[x].Items.Count - 1; i++)
					{
						//UPGRADE_WARNING: (1068) GetVal(EMSReport.EMSPatientVitals(gcs_eyes)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						if ( ViewModel.cboEyes[x].GetItemData(i) == Convert.ToDouble(IncidentMain.GetVal(EMSReport.EMSPatientVitals["gcs_eyes"])))
						{
							ViewModel.cboEyes[x].SelectedIndex = i;
							break;
						}
					}
					for (int i = 0; i <= ViewModel.cboVerbal[x].Items.Count - 1; i++)
					{
						//UPGRADE_WARNING: (1068) GetVal(EMSReport.EMSPatientVitals(gcs_verbal)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						if ( ViewModel.cboVerbal[x].GetItemData(i) == Convert.ToDouble(IncidentMain.GetVal(EMSReport.EMSPatientVitals["gcs_verbal"])))
						{
							ViewModel.cboVerbal[x].SelectedIndex = i;
							break;
						}
					}
					for (int i = 0; i <= ViewModel.cboMotor[x].Items.Count - 1; i++)
					{
						//UPGRADE_WARNING: (1068) GetVal(EMSReport.EMSPatientVitals(gcs_motor)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						if ( ViewModel.cboMotor[x].GetItemData(i) == Convert.ToDouble(IncidentMain.GetVal(EMSReport.EMSPatientVitals["gcs_motor"])))
						{
							ViewModel.cboMotor[x].SelectedIndex = i;
							break;
						}
					}
					EMSReport.EMSPatientVitals.MoveNext();
					x++;
					if (x > 4)
					{
						ViewModel.cmdMore.Text = "Show More";
						ViewModel.cmdMore.Visible = true;
						break;
					}
					else
					{
						ViewModel.cmdMore.Visible = false;
					}
				};
			}

			//************************************************
			//  Treatment - Medication, IV's
			//************************************************
			LoadMedication();
			if (EMSReport.GetEMSPatientIVLineRS(ViewModel.PatientID) != 0)
			{
				x = 0;
				if (Convert.ToBoolean(EMSReport.EMSPatientIVLine["flag_saline_lock"]))
				{
					ViewModel.chkSalineLock.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
				}
				else
				{
					ViewModel.chkSalineLock.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
				}

				while(!EMSReport.EMSPatientIVLine.EOF)
				{
					for (int i = 0; i <= ViewModel.cboGauge[x].Items.Count - 1; i++)
					{
						if ( ViewModel.cboGauge[x].GetItemData(i) == Convert.ToDouble(EMSReport.EMSPatientIVLine["iv_gauge_code"]))
						{
							ViewModel.cboGauge[x].SelectedIndex = i;
							break;
						}
					}
					for (int i = 0; i <= ViewModel.cboRoute[x].Items.Count - 1; i++)
					{
						if ( ViewModel.cboRoute[x].GetItemData(i) == Convert.ToDouble(EMSReport.EMSPatientIVLine["iv_route_code"]))
						{
							ViewModel.cboRoute[x].SelectedIndex = i;
							break;
						}
					}
					for (int i = 0; i <= ViewModel.cboRate[x].Items.Count - 1; i++)
					{
						if ( ViewModel.cboRate[x].GetItemData(i) == Convert.ToDouble(EMSReport.EMSPatientIVLine["iv_rate_code"]))
						{
							ViewModel.cboRate[x].SelectedIndex = i;
							break;
						}
					}
					//UPGRADE_WARNING: (1068) GetVal(EMSReport.EMSPatientIVLine(iv_amount)) of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.txtAmount[x].Text = Convert.ToString(IncidentMain.GetVal(EMSReport.EMSPatientIVLine["iv_amount"]));
					for (int i = 0; i <= ViewModel.cboSite[x].Items.Count - 1; i++)
					{
						if ( ViewModel.cboSite[x].GetItemData(i) == Convert.ToDouble(EMSReport.EMSPatientIVLine["iv_site_code"]))
						{
							ViewModel.cboSite[x].SelectedIndex = i;
							break;
						}
					}
					ViewModel.lbIVID[x].Text = Convert.ToString(EMSReport.EMSPatientIVLine["line_id"]);
					x++;
					EMSReport.EMSPatientIVLine.MoveNext();
					if (x > 4)
					{
						ViewModel.cmdMoreIVs.Text = "Show More";
						ViewModel.cmdMoreIVs.Visible = true;
						break;
					}
					else
					{
						ViewModel.cmdMoreIVs.Visible = false;
					}
				};
			}

			//*****************************************************************
			// Procedures
			//*****************************************************************
			LoadALSProcedures();
			LoadBLSProcedures();

			//***********************************************
			// Trauma
			//***********************************************
			if (EMSReport.GetEMSPatientTrauma(ViewModel.PatientID) != 0)
			{
				ViewModel.txtTraumaID.Text = EMSReport.TraumaID;
				for (int i = 0; i <= ViewModel.cboProtectiveDevice.Items.Count - 1; i++)
				{
					if ( ViewModel.cboProtectiveDevice.GetItemData(i) == EMSReport.ProtectiveDevice)
					{
						ViewModel.cboProtectiveDevice.SelectedIndex = i;
						break;
					}
				}
				for (int i = 0; i <= ViewModel.cboPatientLocation.Items.Count - 1; i++)
				{
					if ( ViewModel.cboPatientLocation.GetItemData(i) == EMSReport.TraumaLocation)
					{
						ViewModel.cboPatientLocation.SelectedIndex = i;
						break;
					}
				}
				ViewModel.tabEMS.Items[5].Text = "Trauma";
				ViewModel.TraumaSwitch = -1;

			}
			if (EMSReport.GetEMSTraumaDescriptorRS(ViewModel.PatientID) != 0)
			{

				while(!EMSReport.EMSTraumaDescriptor.EOF)
				{
					switch(Convert.ToInt32(EMSReport.EMSTraumaDescriptor["trauma_type_class"]))
					{
						case 1 :
							for (int i = 0; i <= ViewModel.lstTrauma1.Items.Count - 1; i++)
							{
								if ( ViewModel.lstTrauma1.GetItemData(i) == Convert.ToDouble(EMSReport.EMSTraumaDescriptor["trauma_code"]))
								{
									UpgradeHelpers.Helpers.ListBoxHelper.SetSelected(ViewModel.lstTrauma1, i, true);
									break;
								}
							}
							break;
						case 2 :
							for (int i = 0; i <= ViewModel.lstTrauma2.Items.Count - 1; i++)
							{
								if ( ViewModel.lstTrauma2.GetItemData(i) == Convert.ToDouble(EMSReport.EMSTraumaDescriptor["trauma_code"]))
								{
									UpgradeHelpers.Helpers.ListBoxHelper.SetSelected(ViewModel.lstTrauma2, i, true);
									break;
								}
							}
							break;
						case 3 :
							for (int i = 0; i <= ViewModel.lstTrauma3.Items.Count - 1; i++)
							{
								if ( ViewModel.lstTrauma3.GetItemData(i) == Convert.ToDouble(EMSReport.EMSTraumaDescriptor["trauma_code"]))
								{
									UpgradeHelpers.Helpers.ListBoxHelper.SetSelected(ViewModel.lstTrauma3, i, true);
									break;
								}
							}
							break;
					}
					EMSReport.EMSTraumaDescriptor.MoveNext();
				};
				ViewModel.tabEMS.Items[5].Text = "Trauma";
				ViewModel.TraumaSwitch = -1;
			}

			//*******************************************
			//  CPR
			//*******************************************
			if (EMSReport.GetEMSCPR(ViewModel.PatientID) != 0)
			{
				switch(EMSReport.TimeArrestToCPR)
				{
					case 1 :
						ViewModel.optArrestToCPR[0].Checked = true;
						break;
					case 2 :
						ViewModel.optArrestToCPR[1].Checked = true;
						break;
					case 3 :
						ViewModel.optArrestToCPR[2].Checked = true;
						break;
					case 4 :
						ViewModel.optArrestToCPR[3].Checked = true;
						break;
					default:
						for (int i = 0; i <= 3; i++)
						{
							ViewModel.optArrestToCPR[i].Checked = false;
						}
						break;
				}
				switch(EMSReport.TimeArrestToAls)
				{
					case 1 :
						ViewModel.optArrestToALS[0].Checked = true;
						break;
					case 2 :
						ViewModel.optArrestToALS[1].Checked = true;
						break;
					case 3 :
						ViewModel.optArrestToALS[2].Checked = true;
						break;
					case 4 :
						ViewModel.optArrestToALS[3].Checked = true;
						break;
					default:
						for (int i = 0; i <= 3; i++)
						{
							ViewModel.optArrestToALS[i].Checked = false;
						}
						break;
				}
				switch(EMSReport.TimeArrestToShock)
				{
					case 1 :
						ViewModel.optArrestToShock[0].Checked = true;
						break;
					case 2 :
						ViewModel.optArrestToShock[1].Checked = true;
						break;
					case 3 :
						ViewModel.optArrestToShock[2].Checked = true;
						break;
					case 4 :
						ViewModel.optArrestToShock[3].Checked = true;
						break;
					default:
						for (int i = 0; i <= 3; i++)
						{
							ViewModel.optArrestToShock[i].Checked = false;
						}
						break;
				}
				if (EMSReport.FlagPulseRestored != 0)
				{
					ViewModel.chkPulseRestored.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
				}
				else
				{
					ViewModel.chkPulseRestored.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
				}
				ViewModel.tabEMS.Items[6].Text = "CPR";
				ViewModel.CPRSwitch = -1;
			}
			if (EMSReport.GetEMSCPRPerformerRS(ViewModel.PatientID) != 0)
			{
				ViewModel.tabEMS.Items[6].Text = "CPR";
				ViewModel.CPRSwitch = -1;
				LoadCPRPerformer();
			}
			ViewModel.FirstTime = 0;
			CheckComplete();
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
			this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.Arrow);
		}

		private void LoadLists()
		{
			//Load Appropriate Combo and Listbox Selections
			//Format Tabs as needed
			TFDIncident.clsEMSCodes EMSCodes = Container.Resolve< clsEMSCodes>();
			TFDIncident.clsCommonCodes CommonCodes = Container.Resolve< clsCommonCodes>();
			TFDIncident.clsEMS EMSReport = Container.Resolve< clsEMS>();
			TFDIncident.clsUnit UnitCL = Container.Resolve< clsUnit>();
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
			this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.WaitCursor);
			//**************************************************************
			//Common Lists
			//**************************************************************
			EMSCodes.GetIncidentLocationCodes();
			ViewModel.cboIncidentLocation.Items.Clear();

			while(!EMSCodes.IncidentLocationCodes.EOF)
			{
				ViewModel.cboIncidentLocation.AddItem(IncidentMain.Clean(EMSCodes.IncidentLocationCodes["description"]));
				ViewModel.cboIncidentLocation.SetItemData(ViewModel.cboIncidentLocation.GetNewIndex(), Convert.ToInt32(EMSCodes.IncidentLocationCodes["incident_location_code"]));
				EMSCodes.IncidentLocationCodes.MoveNext();
			}
			;
			EMSCodes.GetIncidentSettingCodes();
			ViewModel.cboIncidentSetting.Items.Clear();

			while(!EMSCodes.IncidentSettingCodes.EOF)
			{
				ViewModel.cboIncidentSetting.AddItem(IncidentMain.Clean(EMSCodes.IncidentSettingCodes["description"]));
				ViewModel.cboIncidentSetting.SetItemData(ViewModel.cboIncidentSetting.GetNewIndex(), Convert.ToInt32(EMSCodes.IncidentSettingCodes["incident_setting_code"]));
				EMSCodes.IncidentSettingCodes.MoveNext();
			}
			;
			EMSCodes.GetResearchCodes();
			ViewModel.cboResearchCode.Items.Clear();

			while(!EMSCodes.ResearchCodes.EOF)
			{
				ViewModel.cboResearchCode.AddItem(IncidentMain.Clean(EMSCodes.ResearchCodes["description"]));
				ViewModel.cboResearchCode.SetItemData(ViewModel.cboResearchCode.GetNewIndex(), Convert.ToInt32(EMSCodes.ResearchCodes["research_code"]));
				EMSCodes.ResearchCodes.MoveNext();
			}
			;

			//Specific Lists
			switch( ViewModel.ActionTaken)
			{
				case 3 : case 4 : case 5 :
					//********************************************** 
					//Basic Info Only 
					//********************************************** 
					ViewModel.tabEMS.Items[7].Text = "Basic";
					ViewModel.tabEMS.Items[0].Text = "";
					ViewModel.tabEMS.Items[1].Text = "";

					CommonCodes.GetAgeUnit();
					ViewModel.cboAgeUnits.Items.Clear();

					while(!CommonCodes.AgeUnit.EOF)
					{
						ViewModel.cboAgeUnits.AddItem(IncidentMain.Clean(CommonCodes.AgeUnit["description"]));
						ViewModel.cboAgeUnits.SetItemData(ViewModel.cboAgeUnits.GetNewIndex(), Convert.ToInt32(CommonCodes.AgeUnit["age_unit_code"]));
						CommonCodes.AgeUnit.MoveNext();
					}
					;
					CommonCodes.GetPeopleDescriptor("R");
					ViewModel.cboEMSRace.Items.Clear();

					while(!CommonCodes.PeopleDescriptor.EOF)
					{
						ViewModel.cboEMSRace.AddItem(IncidentMain.Clean(CommonCodes.PeopleDescriptor["description"]));
						ViewModel.cboEMSRace.SetItemData(ViewModel.cboEMSRace.GetNewIndex(), Convert.ToInt32(CommonCodes.PeopleDescriptor["people_descriptor_code"]));
						CommonCodes.PeopleDescriptor.MoveNext();
					}
					;
					EMSCodes.GetServiceProvidedCodes();
					ViewModel.cboServiceProvided.Items.Clear();

					while(!EMSCodes.ServiceProvidedCodes.EOF)
					{
						ViewModel.cboServiceProvided.AddItem(IncidentMain.Clean(EMSCodes.ServiceProvidedCodes["description"]));
						ViewModel.cboServiceProvided.SetItemData(ViewModel.cboServiceProvided.GetNewIndex(), Convert.ToInt32(EMSCodes.ServiceProvidedCodes["service_provided_code"]));
						EMSCodes.ServiceProvidedCodes.MoveNext();
					}
					;
					break;
				default:
					//**************************************************************** 
					//Patient and Exam Tabs 
					//**************************************************************** 
					//Patient Lists 
					ViewModel.tabEMS.Items[0].Text = "Patient";
					ViewModel.tabEMS.Items[7].Text = "";
					CommonCodes.GetAgeUnit();
					ViewModel.cboPatientAgeUnits.Items.Clear();

					while(!CommonCodes.AgeUnit.EOF)
					{
						ViewModel.cboPatientAgeUnits.AddItem(IncidentMain.Clean(CommonCodes.AgeUnit["description"]));
						ViewModel.cboPatientAgeUnits.SetItemData(ViewModel.cboPatientAgeUnits.GetNewIndex(), Convert.ToInt32(CommonCodes.AgeUnit["age_unit_code"]));
						CommonCodes.AgeUnit.MoveNext();
					}
					;
					CommonCodes.GetPeopleDescriptor("R");
					ViewModel.cboRace.Items.Clear();

					while(!CommonCodes.PeopleDescriptor.EOF)
					{
						ViewModel.cboRace.AddItem(IncidentMain.Clean(CommonCodes.PeopleDescriptor["description"]));
						ViewModel.cboRace.SetItemData(ViewModel.cboRace.GetNewIndex(), Convert.ToInt32(CommonCodes.PeopleDescriptor["people_descriptor_code"]));
						CommonCodes.PeopleDescriptor.MoveNext();
					}
					;
					CommonCodes.GetStateCode();
					ViewModel.cboState.Items.Clear();

					while(!CommonCodes.StateRS.EOF)
					{
						ViewModel.cboState.AddItem(IncidentMain.Clean(CommonCodes.StateRS["state_code"]));
						CommonCodes.StateRS.MoveNext();
					}
					;
					EMSCodes.GetPreExistingConditionCodes();
					ViewModel.lstPriorMedicalHistory.Items.Clear();

					while(!EMSCodes.PreExistingConditionCodes.EOF)
					{
						ViewModel.lstPriorMedicalHistory.AddItem(IncidentMain.Clean(EMSCodes.PreExistingConditionCodes["description"]));
						ViewModel.lstPriorMedicalHistory.SetItemData(ViewModel.lstPriorMedicalHistory.GetNewIndex(), Convert.ToInt32(EMSCodes.PreExistingConditionCodes["pre_existing_condition_code"]));
						EMSCodes.PreExistingConditionCodes.MoveNext();
					}
					;
					EMSCodes.GetContributingFactorCodes();
					ViewModel.lstPossibleFactors.Items.Clear();

					while(!EMSCodes.EMSContributingFactorCodes.EOF)
					{
						ViewModel.lstPossibleFactors.AddItem(IncidentMain.Clean(EMSCodes.EMSContributingFactorCodes["description"]));
						ViewModel.lstPossibleFactors.SetItemData(ViewModel.lstPossibleFactors.GetNewIndex(), Convert.ToInt32(EMSCodes.EMSContributingFactorCodes["EMS_contributing_factor_code"]));
						EMSCodes.EMSContributingFactorCodes.MoveNext();
					}
					;
					//Exam Lists 
					if ( ViewModel.ActionTaken != 7)
					{
						ViewModel.tabEMS.Items[1].Text = "Exam";
						EMSCodes.GetMechCodes();
						ViewModel.cboMechCode.Items.Clear();

						while(!EMSCodes.MechCodes.EOF)
						{
							ViewModel.cboMechCode.AddItem(IncidentMain.Clean(EMSCodes.MechCodes["description"]));
							ViewModel.cboMechCode.SetItemData(ViewModel.cboMechCode.GetNewIndex(), Convert.ToInt32(EMSCodes.MechCodes["Mech_code"]));
							EMSCodes.MechCodes.MoveNext();
						}
						;
						EMSCodes.GetInjuryDetailCodesByType("I");
						ViewModel.cboInjuryType.Items.Clear();

						while(!EMSCodes.InjuryDetailCodes.EOF)
						{
							ViewModel.cboInjuryType.AddItem(IncidentMain.Clean(EMSCodes.InjuryDetailCodes["description"]));
							ViewModel.cboInjuryType.SetItemData(ViewModel.cboInjuryType.GetNewIndex(), Convert.ToInt32(EMSCodes.InjuryDetailCodes["injury_detail_descriptor"]));
							EMSCodes.InjuryDetailCodes.MoveNext();
						}
						;
						EMSCodes.GetInjuryDetailCodesByType("B");
						ViewModel.cboBodyPart.Items.Clear();

						while(!EMSCodes.InjuryDetailCodes.EOF)
						{
							ViewModel.cboBodyPart.AddItem(IncidentMain.Clean(EMSCodes.InjuryDetailCodes["description"]));
							ViewModel.cboBodyPart.SetItemData(ViewModel.cboBodyPart.GetNewIndex(), Convert.ToInt32(EMSCodes.InjuryDetailCodes["injury_detail_descriptor"]));
							EMSCodes.InjuryDetailCodes.MoveNext();
						}
						;
						EMSCodes.GetIllnessTypeCodes();
						ViewModel.cboPrimaryIllness.Items.Clear();
						ViewModel.lstSecondaryIllness.Items.Clear();

						while(!EMSCodes.IllnessTypeCodes.EOF)
						{
							ViewModel.cboPrimaryIllness.AddItem(IncidentMain.Clean(EMSCodes.IllnessTypeCodes["description"]));
							ViewModel.cboPrimaryIllness.SetItemData(ViewModel.cboPrimaryIllness.GetNewIndex(), Convert.ToInt32(EMSCodes.IllnessTypeCodes["illness_type_code"]));
							ViewModel.lstSecondaryIllness.AddItem(IncidentMain.Clean(EMSCodes.IllnessTypeCodes["description"]));
							ViewModel.lstSecondaryIllness.SetItemData(ViewModel.lstSecondaryIllness.GetNewIndex(), Convert.ToInt32(EMSCodes.IllnessTypeCodes["illness_type_code"]));
							EMSCodes.IllnessTypeCodes.MoveNext();
						}
						;
						//****************************************************
						//Vitals
						//****************************************************
						for (int i = 0; i <= 4; i++)
						{
							ViewModel.cboECG[i].Items.Clear();
							ViewModel.cboVitalsPosition[i].Items.Clear();
							ViewModel.cboEyes[i].Items.Clear();
							ViewModel.cboVerbal[i].Items.Clear();
							ViewModel.cboMotor[i].Items.Clear();
						}
						EMSCodes.GetECGCodes();

						while(!EMSCodes.EMS_ECGCodes.EOF)
						{
							for (int i = 0; i <= 4; i++)
							{
								ViewModel.cboECG[i].AddItem(IncidentMain.Clean(EMSCodes.EMS_ECGCodes["description"]));
								ViewModel.cboECG[i].SetItemData(ViewModel.cboECG[i].GetNewIndex(), Convert.ToInt32(EMSCodes.EMS_ECGCodes["ecg_code"]));
							}
							EMSCodes.EMS_ECGCodes.MoveNext();
						}
						;
						EMSCodes.GetExamCodesByType("V");

						while(!EMSCodes.ExamCodes.EOF)
						{
							for (int i = 0; i <= 4; i++)
							{
								ViewModel.cboVitalsPosition[i].AddItem(IncidentMain.Clean(EMSCodes.ExamCodes["description"]));
								ViewModel.cboVitalsPosition[i].SetItemData(ViewModel.cboVitalsPosition[i].GetNewIndex(), Convert.ToInt32(EMSCodes.ExamCodes["exam_code"]));
							}
							EMSCodes.ExamCodes.MoveNext();
						}
						;
						EMSCodes.GetGCSCodesByType("E");

						while(!EMSCodes.EMS_GCSCodes.EOF)
						{
							for (int i = 0; i <= 4; i++)
							{
								ViewModel.cboEyes[i].AddItem(IncidentMain.Clean(EMSCodes.EMS_GCSCodes["description"]));
								ViewModel.cboEyes[i].SetItemData(ViewModel.cboEyes[i].GetNewIndex(), Convert.ToInt32(EMSCodes.EMS_GCSCodes["gcs_code"]));
							}
							EMSCodes.EMS_GCSCodes.MoveNext();
						}
						;
						EMSCodes.GetGCSCodesByType("V");

						while(!EMSCodes.EMS_GCSCodes.EOF)
						{
							for (int i = 0; i <= 4; i++)
							{
								ViewModel.cboVerbal[i].AddItem(IncidentMain.Clean(EMSCodes.EMS_GCSCodes["description"]));
								ViewModel.cboVerbal[i].SetItemData(ViewModel.cboVerbal[i].GetNewIndex(), Convert.ToInt32(EMSCodes.EMS_GCSCodes["gcs_code"]));
							}
							EMSCodes.EMS_GCSCodes.MoveNext();
						}
						;
						EMSCodes.GetGCSCodesByType("M");

						while(!EMSCodes.EMS_GCSCodes.EOF)
						{
							for (int i = 0; i <= 4; i++)
							{
								ViewModel.cboMotor[i].AddItem(IncidentMain.Clean(EMSCodes.EMS_GCSCodes["description"]));
								ViewModel.cboMotor[i].SetItemData(ViewModel.cboMotor[i].GetNewIndex(), Convert.ToInt32(EMSCodes.EMS_GCSCodes["gcs_code"]));
							}
							EMSCodes.EMS_GCSCodes.MoveNext();
						}
						;
											}
											else
											{
						ViewModel.tabEMS.Items[1].Text = "";
					}

					break;
			}
			//*********************************************************************
			//Transport
			//*********************************************************************
			if ( ViewModel.ActionTaken == 2 || ViewModel.ActionTaken == 7)
			{
				ViewModel.tabEMS.Items[4].Text = "Transport";
				EMSCodes.GetHospitalChosenByCodes();
				ViewModel.cboHospitalChosenBy.Items.Clear();

				while(!EMSCodes.HospitalChosenByCodes.EOF)
				{
					ViewModel.cboHospitalChosenBy.AddItem(IncidentMain.Clean(EMSCodes.HospitalChosenByCodes["description"]));
					ViewModel.cboHospitalChosenBy.SetItemData(ViewModel.cboHospitalChosenBy.GetNewIndex(), Convert.ToInt32(EMSCodes.HospitalChosenByCodes["hospital_chosen_by_code"]));
					EMSCodes.HospitalChosenByCodes.MoveNext();
				}
				;
				EMSCodes.GetHospitalCodes();
				ViewModel.cboBaseStationContact.Items.Clear();
				ViewModel.cboTransportTo.Items.Clear();
				ViewModel.cboTransportFrom.Items.Clear();
				ViewModel.cboTransportBy.Items.Clear();

				while(!EMSCodes.HospitalCodes.EOF)
				{
					ViewModel.cboBaseStationContact.AddItem(IncidentMain.Clean(EMSCodes.HospitalCodes["facility_name"]));
					ViewModel.cboBaseStationContact.SetItemData(ViewModel.cboBaseStationContact.GetNewIndex(), Convert.ToInt32(EMSCodes.HospitalCodes["hospital_code"]));
					ViewModel.cboTransportTo.AddItem(IncidentMain.Clean(EMSCodes.HospitalCodes["facility_name"]));
					ViewModel.cboTransportTo.SetItemData(ViewModel.cboTransportTo.GetNewIndex(), Convert.ToInt32(EMSCodes.HospitalCodes["hospital_code"]));
					ViewModel.cboTransportFrom.AddItem(IncidentMain.Clean(EMSCodes.HospitalCodes["facility_name"]));
					ViewModel.cboTransportFrom.SetItemData(ViewModel.cboTransportFrom.GetNewIndex(), Convert.ToInt32(EMSCodes.HospitalCodes["hospital_code"]));
					EMSCodes.HospitalCodes.MoveNext();
				}
				;
				if ( ViewModel.ActionTaken == 2)
				{
					ViewModel.cboTransportFrom.Enabled = false;
				}
				if (UnitCL.GetIncidentTransportResponses(ViewModel.CurrIncident) != 0)
				{

					while(!UnitCL.UnitResponse.EOF)
					{
						ViewModel.cboTransportBy.AddItem(IncidentMain.Clean(UnitCL.UnitResponse["unit_code"]));
						UnitCL.UnitResponse.MoveNext();
					};
				}
				else
				{
					//            cboTransportBy.Enabled = False
					//            lbTransportBy.ForeColor = DKGRAY
				}

			}
			else
			{
				ViewModel.tabEMS.Items[4].Text = "";
				ViewModel.cboTransportFrom.Enabled = false;
			}
			//**********************************************************************
			//Procedures & Treatment
			//**********************************************************************
			if ( ViewModel.ActionTaken == 2 || ViewModel.ActionTaken == 6 || ViewModel.ActionTaken == 8)
			{
				//Treatment
				ViewModel.ExtricationTime = 0;
				ViewModel.tabEMS.Items[3].Text = "Treatment";
				EMSCodes.GetTreatmentAuthorizationCodes();
				ViewModel.cboTreatmentAuth.Items.Clear();

				while(!EMSCodes.TreatmentAuthorizationCodes.EOF)
				{
					ViewModel.cboTreatmentAuth.AddItem(IncidentMain.Clean(EMSCodes.TreatmentAuthorizationCodes["description"]));
					ViewModel.cboTreatmentAuth.SetItemData(ViewModel.cboTreatmentAuth.GetNewIndex(), Convert.ToInt32(EMSCodes.TreatmentAuthorizationCodes["treatment_authorization_code"]));
					EMSCodes.TreatmentAuthorizationCodes.MoveNext();
				}
				;
				EMSCodes.GetMedicationCodes();
				ViewModel.cboMedications.Items.Clear();

				while(!EMSCodes.MedicationCodes.EOF)
				{
					ViewModel.cboMedications.AddItem(IncidentMain.Clean(EMSCodes.MedicationCodes["description"]));
					ViewModel.cboMedications.SetItemData(ViewModel.cboMedications.GetNewIndex(), Convert.ToInt32(EMSCodes.MedicationCodes["medication_code"]));
					EMSCodes.MedicationCodes.MoveNext();
				}
				;
				for (int i = 0; i <= 4; i++)
				{
					ViewModel.cboGauge[i].Items.Clear();
					ViewModel.cboRoute[i].Items.Clear();
					ViewModel.cboRate[i].Items.Clear();
					ViewModel.cboSite[i].Items.Clear();
				}
				EMSCodes.GetIVCodesByType("G");

				while(!EMSCodes.EMS_IVCodes.EOF)
				{
					for (int i = 0; i <= 4; i++)
					{
						ViewModel.cboGauge[i].AddItem(IncidentMain.Clean(EMSCodes.EMS_IVCodes["description"]));
						ViewModel.cboGauge[i].SetItemData(ViewModel.cboGauge[i].GetNewIndex(), Convert.ToInt32(EMSCodes.EMS_IVCodes["iv_code"]));
					}
					EMSCodes.EMS_IVCodes.MoveNext();
				}
				;
				EMSCodes.GetIVCodesByType("R");

				while(!EMSCodes.EMS_IVCodes.EOF)
				{
					for (int i = 0; i <= 4; i++)
					{
						ViewModel.cboRoute[i].AddItem(IncidentMain.Clean(EMSCodes.EMS_IVCodes["description"]));
						ViewModel.cboRoute[i].SetItemData(ViewModel.cboRoute[i].GetNewIndex(), Convert.ToInt32(EMSCodes.EMS_IVCodes["iv_code"]));
					}
					EMSCodes.EMS_IVCodes.MoveNext();
				}
				;
				EMSCodes.GetIVCodesByType("T");

				while(!EMSCodes.EMS_IVCodes.EOF)
				{
					for (int i = 0; i <= 4; i++)
					{
						ViewModel.cboRate[i].AddItem(IncidentMain.Clean(EMSCodes.EMS_IVCodes["description"]));
						ViewModel.cboRate[i].SetItemData(ViewModel.cboRate[i].GetNewIndex(), Convert.ToInt32(EMSCodes.EMS_IVCodes["iv_code"]));
					}
					EMSCodes.EMS_IVCodes.MoveNext();
				}
				;
				EMSCodes.GetIVCodesByType("S");

				while(!EMSCodes.EMS_IVCodes.EOF)
				{
					for (int i = 0; i <= 4; i++)
					{
						ViewModel.cboSite[i].AddItem(IncidentMain.Clean(EMSCodes.EMS_IVCodes["description"]));
						ViewModel.cboSite[i].SetItemData(ViewModel.cboSite[i].GetNewIndex(), Convert.ToInt32(EMSCodes.EMS_IVCodes["iv_code"]));
					}
					EMSCodes.EMS_IVCodes.MoveNext();
				}
				;

				//Procedures
				ViewModel.tabEMS.Items[2].Text = "Procedures";
				EMSCodes.GetProcedureCodesByType("B");
				ViewModel.cboBLSProcedures.Items.Clear();

				while(!EMSCodes.EMSProcedureCodes.EOF)
				{
					ViewModel.cboBLSProcedures.AddItem(IncidentMain.Clean(EMSCodes.EMSProcedureCodes["description"]));
					ViewModel.cboBLSProcedures.SetItemData(ViewModel.cboBLSProcedures.GetNewIndex(), Convert.ToInt32(EMSCodes.EMSProcedureCodes["EMS_procedure_code"]));
					EMSCodes.EMSProcedureCodes.MoveNext();
				}
				;
				EMSCodes.GetProcedureCodesByType("A");
				ViewModel.cboALSProcedures.Items.Clear();

				while(!EMSCodes.EMSProcedureCodes.EOF)
				{
					ViewModel.cboALSProcedures.AddItem(IncidentMain.Clean(EMSCodes.EMSProcedureCodes["description"]));
					ViewModel.cboALSProcedures.SetItemData(ViewModel.cboALSProcedures.GetNewIndex(), Convert.ToInt32(EMSCodes.EMSProcedureCodes["EMS_procedure_code"]));
					EMSCodes.EMSProcedureCodes.MoveNext();
				}
				;
				ViewModel.cboALSPersonnel.Items.Clear();
				if (EMSReport.GetEMSALSStaffing(ViewModel.CurrIncident) != 0)
				{

					while(!EMSReport.EMSIncidentStaffing.EOF)
					{
						ViewModel.cboALSPersonnel.AddItem(IncidentMain.Clean(EMSReport.EMSIncidentStaffing["name_full"]) + ": " + Convert.ToString(EMSReport.EMSIncidentStaffing["emp_id"]));
						EMSReport.EMSIncidentStaffing.MoveNext();
					};
				}
				ViewModel.lstBLSPersonnel.Items.Clear();
				if (EMSReport.GetEMSIncidentStaffing(ViewModel.CurrIncident) != 0)
				{

					while(!EMSReport.EMSIncidentStaffing.EOF)
					{
						ViewModel.lstBLSPersonnel.AddItem(IncidentMain.Clean(EMSReport.EMSIncidentStaffing["name_full"]) + ": " + Convert.ToString(EMSReport.EMSIncidentStaffing["emp_id"]));
						EMSReport.EMSIncidentStaffing.MoveNext();
					};
				}
				ViewModel.lbPInfo[26].Visible = false;
				ViewModel.txtOtherBLSProcedures.Visible = false;
				ViewModel.frmALSAttempts.Visible = false;
				ViewModel.lbPInfo[26].Visible = false;
				ViewModel.txtOtherALSProcedures.Visible = false;
				ViewModel.cmdAddBLS.Enabled = false;
				ViewModel.cmdAddALS.Enabled = false;
			}
			else
			{
				ViewModel.tabEMS.Items[3].Text = "";
				ViewModel.tabEMS.Items[2].Text = "";
			}
			//**********************************
			//Trauma
			//**********************************
			EMSCodes.GetTraumaLocationCodes();
			ViewModel.cboPatientLocation.Items.Clear();

			while(!EMSCodes.TraumaLocationCodes.EOF)
			{
				ViewModel.cboPatientLocation.AddItem(IncidentMain.Clean(EMSCodes.TraumaLocationCodes["description"]));
				ViewModel.cboPatientLocation.SetItemData(ViewModel.cboPatientLocation.GetNewIndex(), Convert.ToInt32(EMSCodes.TraumaLocationCodes["trauma_location_code"]));
				EMSCodes.TraumaLocationCodes.MoveNext();
			}
			;
			EMSCodes.GetProtectiveDeviceCodes();
			ViewModel.cboProtectiveDevice.Items.Clear();

			while(!EMSCodes.ProtectiveDeviceCodes.EOF)
			{
				ViewModel.cboProtectiveDevice.AddItem(IncidentMain.Clean(EMSCodes.ProtectiveDeviceCodes["description"]));
				ViewModel.cboProtectiveDevice.SetItemData(ViewModel.cboProtectiveDevice.GetNewIndex(), Convert.ToInt32(EMSCodes.ProtectiveDeviceCodes["protective_device_code"]));
				EMSCodes.ProtectiveDeviceCodes.MoveNext();
			}
			;
			EMSCodes.GetTraumaTypeCodesByClass(1);
			ViewModel.lstTrauma1.Items.Clear();

			while(!EMSCodes.TraumaTypeCodes.EOF)
			{
				ViewModel.lstTrauma1.AddItem(IncidentMain.Clean(EMSCodes.TraumaTypeCodes["description"]));
				ViewModel.lstTrauma1.SetItemData(ViewModel.lstTrauma1.GetNewIndex(), Convert.ToInt32(EMSCodes.TraumaTypeCodes["trauma_type_code"]));
				EMSCodes.TraumaTypeCodes.MoveNext();
			}
			;
			EMSCodes.GetTraumaTypeCodesByClass(2);
			ViewModel.lstTrauma2.Items.Clear();

			while(!EMSCodes.TraumaTypeCodes.EOF)
			{
				ViewModel.lstTrauma2.AddItem(IncidentMain.Clean(EMSCodes.TraumaTypeCodes["description"]));
				ViewModel.lstTrauma2.SetItemData(ViewModel.lstTrauma2.GetNewIndex(), Convert.ToInt32(EMSCodes.TraumaTypeCodes["trauma_type_code"]));
				EMSCodes.TraumaTypeCodes.MoveNext();
			}
			;
			EMSCodes.GetTraumaTypeCodesByClass(3);
			ViewModel.lstTrauma3.Items.Clear();

			while(!EMSCodes.TraumaTypeCodes.EOF)
			{
				ViewModel.lstTrauma3.AddItem(IncidentMain.Clean(EMSCodes.TraumaTypeCodes["description"]));
				ViewModel.lstTrauma3.SetItemData(ViewModel.lstTrauma3.GetNewIndex(), Convert.ToInt32(EMSCodes.TraumaTypeCodes["trauma_type_code"]));
				EMSCodes.TraumaTypeCodes.MoveNext();
			}
			;

			if (EMSReport.GetEMSPatientTrauma(ViewModel.PatientID) != 0)
			{
				//Load Trauma
				ViewModel.tabEMS.Items[5].Text = "Trauma";
				ViewModel.chkMajTrauma.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
				ViewModel.chkMajTrauma.Enabled = false;
			}
			else
			{
				ViewModel.tabEMS.Items[5].Text = "";
				ViewModel.chkMajTrauma.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
				ViewModel.chkMajTrauma.Enabled = true;
			}

			//******************************************
			// CPR
			//******************************************
			EMSCodes.GetPerformedByCodes();
			ViewModel.cboCPRPerformedBy.Items.Clear();

			while(!EMSCodes.PerformedByCodes.EOF)
			{
				ViewModel.cboCPRPerformedBy.AddItem(IncidentMain.Clean(EMSCodes.PerformedByCodes["description"]));
				ViewModel.cboCPRPerformedBy.SetItemData(ViewModel.cboCPRPerformedBy.GetNewIndex(), Convert.ToInt32(EMSCodes.PerformedByCodes["performed_by_code"]));
				EMSCodes.PerformedByCodes.MoveNext();
			}
			;

			if (EMSReport.GetEMSCPR(ViewModel.PatientID) != 0)
			{
				//Load CPR
				ViewModel.tabEMS.Items[6].Text = "CPR";
			}
			else
			{
				ViewModel.tabEMS.Items[6].Text = "";
			}
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
			this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.Arrow);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboAgeUnits_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboAgeUnits_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboAgeUnits.SelectedIndex == -1)
			{
				ViewModel.cboAgeUnits.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboALSPersonnel_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			int i = 0;

			int ProcSelect = 0;
			if ( ViewModel.cboALSPersonnel.SelectedIndex != -1)
			{
				ProcSelect = -1;
			}
			if (ProcSelect != 0)
			{
				if ( ViewModel.cboALSProcedures.SelectedIndex != -1)
				{
					ViewModel.cmdAddALS.Enabled = true;
					CheckComplete();
				}
				else
				{
					ViewModel.cmdAddALS.Enabled = false;
				}
			}
			else
			{
				ViewModel.cmdAddALS.Enabled = false;
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboALSPersonnel_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboALSPersonnel.SelectedIndex == -1)
			{
				ViewModel.cboALSPersonnel.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboALSProcedures_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			int i = 0;

			if ( ViewModel.cboALSProcedures.SelectedIndex == -1)
			{
				return;
			}

			switch( ViewModel.cboALSProcedures.GetItemData(ViewModel.cboALSProcedures.SelectedIndex))
			{
				case 13 : case 15 : case 16 : case 21 : case 22 : case 26 : case 27 : case 55 : case 56 :
					ViewModel.frmALSAttempts.Visible = true;
					break;
				default:
					ViewModel.frmALSAttempts.Visible = false;
					break;
			}
			CheckComplete();
			int ProcSelect = 0;
			if ( ViewModel.cboALSPersonnel.SelectedIndex != -1)
			{
				ProcSelect = -1;
			}
			if (ProcSelect != 0)
			{
				if ( ViewModel.frmALSAttempts.Visible)
				{
					ViewModel.cmdAddALS.Enabled = !ViewModel.txtAttempts.BackColor.Equals(IncidentMain.Shared.REQCOLOR);
				}
				else
				{
					ViewModel.cmdAddALS.Enabled = true;
				}
			}
			else
			{
				ViewModel.cmdAddALS.Enabled = false;
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboALSProcedures_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboALSProcedures.SelectedIndex == -1)
			{
				ViewModel.cboALSProcedures.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboBaseStationContact_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboBaseStationContact_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboBaseStationContact.SelectedIndex == -1)
			{
				ViewModel.cboBaseStationContact.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboBLSProcedures_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{

			if ( ViewModel.cboBLSProcedures.SelectedIndex != -1)
			{
				if ( ViewModel.cboBLSProcedures.GetItemData(ViewModel.cboBLSProcedures.SelectedIndex) == 24)
				{ //Other BLS Procedures

					ViewModel.lbPInfo[26].Visible = true;
					ViewModel.txtOtherBLSProcedures.Visible = true;
					ViewModel.txtOtherBLSProcedures.BackColor = IncidentMain.Shared.REQCOLOR;
					ViewModel.txtOtherBLSProcedures.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
				}
				else
				{
					ViewModel.lbPInfo[26].Visible = false;
					ViewModel.txtOtherBLSProcedures.Visible = false;
					ViewModel.txtOtherBLSProcedures.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					ViewModel.txtOtherBLSProcedures.ForeColor = IncidentMain.Shared.EMSFONT;
				}
			}
			else
			{
				return;
			}

			CheckComplete();

			int ProcSelect = 0;
			for (int i = 0; i <= ViewModel.lstBLSPersonnel.Items.Count - 1; i++)
			{
				if ( ViewModel.lstBLSPersonnel.GetSelected( i))
				{
					ProcSelect = -1;
					break;
				}
			}
			if (ProcSelect != 0)
			{
				ViewModel.cmdAddBLS.Enabled = ViewModel.cboBLSProcedures.SelectedIndex != -1;
			}
			else
			{
				ViewModel.cmdAddBLS.Enabled = false;
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboBLSProcedures_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboBLSProcedures.SelectedIndex == -1)
			{
				ViewModel.cboBLSProcedures.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboBodyPart_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboBodyPart_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboBodyPart.SelectedIndex == -1)
			{
				ViewModel.cboBodyPart.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboCPRPerformedBy_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboCPRPerformedBy.SelectedIndex == -1)
			{
				return;
			}
			ViewModel.cmdAddCPR.Enabled = true;
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboCPRPerformedBy_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboCPRPerformedBy.SelectedIndex == -1)
			{
				ViewModel.cboCPRPerformedBy.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboECG_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			int Index =this.ViewModel.cboECG.IndexOf((UpgradeHelpers.BasicViewModels.ComboBoxViewModel) eventSender);
			if ( ViewModel.cboECG[Index].SelectedIndex == -1)
			{
				ViewModel.cboECG[Index].Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboEMSRace_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboEMSRace_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboEMSRace.SelectedIndex == -1)
			{
				ViewModel.cboEMSRace.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboEyes_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboEyes_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			int Index =this.ViewModel.cboEyes.IndexOf((UpgradeHelpers.BasicViewModels.ComboBoxViewModel) eventSender);
			if ( ViewModel.cboEyes[Index].SelectedIndex == -1)
			{
				ViewModel.cboEyes[Index].Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboGauge_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboGauge_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			int Index =this.ViewModel.cboGauge.IndexOf((UpgradeHelpers.BasicViewModels.ComboBoxViewModel) eventSender);
			if ( ViewModel.cboGauge[Index].SelectedIndex == -1)
			{
				ViewModel.cboGauge[Index].Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboHospitalChosenBy_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboHospitalChosenBy_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboHospitalChosenBy.SelectedIndex == -1)
			{
				ViewModel.cboHospitalChosenBy.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboIncidentLocation_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboIncidentLocation_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboIncidentLocation.SelectedIndex == -1)
			{
				ViewModel.cboIncidentLocation.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboIncidentSetting_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboIncidentSetting_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboIncidentSetting.SelectedIndex == -1)
			{
				ViewModel.cboIncidentSetting.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboInjuryType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboInjuryType_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboInjuryType.SelectedIndex == -1)
			{
				ViewModel.cboInjuryType.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboMechCode_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Check if Switch Made from Injury to Illness
			if ( ViewModel.cboMechCode.SelectedIndex == -1)
			{
				return;
			}
			if ( ViewModel.FirstTime != 0)
			{
				return;
			}
			ViewModel.FirstTime = -1;
			ViewModel.NarrationRequired = 0;
			ViewModel.TraumaSwitch = 0;
			ViewModel.cboInjuryType.SelectedIndex = -1;
			ViewModel.cboBodyPart.SelectedIndex = -1;
			ViewModel.cboPrimaryIllness.SelectedIndex = -1;
			ViewModel.chkMajTrauma.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			switch( ViewModel.cboMechCode.GetItemData(ViewModel.cboMechCode.SelectedIndex))
			{
				case 1 :
					ViewModel.frmInjury.Enabled = false;
					ViewModel.frmIllness.Enabled = false;
					ViewModel.cboInjuryType.Enabled = false;
					ViewModel.cboBodyPart.Enabled = false;
					ViewModel.chkMajTrauma.Enabled = false;
					ViewModel.cboInjuryType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					ViewModel.cboInjuryType.ForeColor = IncidentMain.Shared.EMSFONT;
					ViewModel.cboBodyPart.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					ViewModel.cboBodyPart.ForeColor = IncidentMain.Shared.EMSFONT;
					ViewModel.cboPrimaryIllness.Enabled = false;
					ViewModel.cboPrimaryIllness.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					ViewModel.cboPrimaryIllness.ForeColor = IncidentMain.Shared.EMSFONT;
					break;
				case 3 : case 4 : case 7 : case 12 : case 13 : case 19 : case 22 : case 23 : case 24 : case 27 : case 29 :  //Medical 

					ViewModel.cboInjuryType.Enabled = false;
					ViewModel.cboBodyPart.Enabled = false;
					ViewModel.chkMajTrauma.Enabled = false;
					ViewModel.cboPrimaryIllness.Enabled = true;
					ViewModel.cboInjuryType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					ViewModel.cboInjuryType.ForeColor = IncidentMain.Shared.EMSFONT;
					ViewModel.cboBodyPart.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					ViewModel.cboBodyPart.ForeColor = IncidentMain.Shared.EMSFONT;
					break;
				default: //Injury 

					ViewModel.NarrationRequired = -1;
					ViewModel.cboInjuryType.Enabled = true;
					ViewModel.cboBodyPart.Enabled = true;
					ViewModel.chkMajTrauma.Enabled = true;
					ViewModel.cboPrimaryIllness.Enabled = false;
					ViewModel.cboPrimaryIllness.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					ViewModel.cboPrimaryIllness.ForeColor = IncidentMain.Shared.EMSFONT;
					break;
			}
			ViewModel.FirstTime = 0;
			CheckComplete();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboMedications_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboMedications.SelectedIndex == -1)
			{
				return;
			}

			if ( ViewModel.txtDosage.Text != "")
			{
				double dbNumericTemp = 0;
				if (Double.TryParse(ViewModel.txtDosage.Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
				{
					ViewModel.cmdAddMedications.Enabled = true;
				}
				else
				{
					ViewModel.cmdAddMedications.Enabled = false;
					CheckComplete();
				}
			}
			else
			{
				ViewModel.cmdAddMedications.Enabled = false;
				CheckComplete();
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboMedications_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboMedications.SelectedIndex == -1)
			{
				ViewModel.cboMedications.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboMotor_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboMotor_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			int Index =this.ViewModel.cboMotor.IndexOf((UpgradeHelpers.BasicViewModels.ComboBoxViewModel) eventSender);
			if ( ViewModel.cboMotor[Index].SelectedIndex == -1)
			{
				ViewModel.cboMotor[Index].Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboNarrList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Retrieve Selected Narration

			if ( ViewModel.cboNarrList.SelectedIndex == -1)
			{
				return;
			}
			if ( ViewModel.FirstTime != 0)
			{
				return;
			}
			TFDIncident.clsEMS EMSReport = Container.Resolve< clsEMS>();
			TFDIncident.clsPersonnel PersonnelCL = Container.Resolve< clsPersonnel>();

			if ( ViewModel.NarrationUpdated != 0)
			{
				SaveNarration();
			}
			ViewModel.rtxNarration.Text = "";
			ViewModel.lbNarrID.Text = "";
			ViewModel.lbNarrAuthor.Text = "";
			int NarrID = ViewModel.cboNarrList.GetItemData(ViewModel.cboNarrList.SelectedIndex);

			if (EMSReport.GetEMSPatientNarration(NarrID) != 0)
			{
				ViewModel.lbNarrID.Text = EMSReport.EMSNarrationID.ToString();
				if (PersonnelCL.GetEmployeeRecord(IncidentMain.Clean(EMSReport.NarrationBy)) != 0)
				{
					ViewModel.lbNarrAuthor.Text = IncidentMain.Clean(PersonnelCL.Employee["name_full"]);
				}
				ViewModel.rtxNarration.Text = IncidentMain.Clean(EMSReport.NarrationText);
				ViewModel.rtxNarration.Enabled = !(EMSReport.NarrationBy != IncidentMain.Shared.gCurrUser);
				ViewModel.NarrationUpdated = 0;
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboPatientAgeUnits_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboPatientAgeUnits_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboPatientAgeUnits.SelectedIndex == -1)
			{
				ViewModel.cboPatientAgeUnits.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboPatientLocation_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboPatientLocation_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboPatientLocation.SelectedIndex == -1)
			{
				ViewModel.cboPatientLocation.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboPrimaryIllness_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboPrimaryIllness_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboPrimaryIllness.SelectedIndex == -1)
			{
				ViewModel.cboPrimaryIllness.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboProtectiveDevice_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboProtectiveDevice_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboProtectiveDevice.SelectedIndex == -1)
			{
				ViewModel.cboProtectiveDevice.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboRace_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboRace_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboRace.SelectedIndex == -1)
			{
				ViewModel.cboRace.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboRate_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboRate_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			int Index =this.ViewModel.cboRate.IndexOf((UpgradeHelpers.BasicViewModels.ComboBoxViewModel) eventSender);
			if ( ViewModel.cboRate[Index].SelectedIndex == -1)
			{
				ViewModel.cboRate[Index].Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboResearchCode_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboResearchCode_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboResearchCode.SelectedIndex == -1)
			{
				ViewModel.cboResearchCode.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboRoute_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboRoute_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			int Index =this.ViewModel.cboRoute.IndexOf((UpgradeHelpers.BasicViewModels.ComboBoxViewModel) eventSender);
			if ( ViewModel.cboRoute[Index].SelectedIndex == -1)
			{
				ViewModel.cboRoute[Index].Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboServiceProvided_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboServiceProvided_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboServiceProvided.SelectedIndex == -1)
			{
				ViewModel.cboServiceProvided.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboSite_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboSite_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			int Index =this.ViewModel.cboSite.IndexOf((UpgradeHelpers.BasicViewModels.ComboBoxViewModel) eventSender);
			if ( ViewModel.cboSite[Index].SelectedIndex == -1)
			{
				ViewModel.cboSite[Index].Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboState_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboState.SelectedIndex == -1)
			{
				ViewModel.cboState.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboTransportBy_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			TFDIncident.clsUnit UnitCL = Container.Resolve< clsUnit>();

			// Save record as ALS w/Transport or BLS w/Transport
			if ( ViewModel.FirstTime != 0)
			{
				return;
			}
			if ( ViewModel.cboTransportBy.SelectedIndex != -1)
			{
				if (UnitCL.GetTFDUnit(ViewModel.cboTransportBy.Text) != "")
				{
					ViewModel.EMSType = IncidentMain.ALSTRANS;
				}
				else
				{
					ViewModel.EMSType = IncidentMain.BLSTRANS;
				}
				CheckComplete();
			}


		}

		[UpgradeHelpers.Events.Handler]
		internal void cboTransportBy_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboTransportBy.SelectedIndex == -1)
			{
				ViewModel.cboTransportBy.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboTransportFrom_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboTransportFrom_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboTransportFrom.SelectedIndex == -1)
			{
				ViewModel.cboTransportFrom.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboTransportTo_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			TFDIncident.clsUnit UnitCL = Container.Resolve< clsUnit>();

			// Save record as ALS w/Transport or BLS w/Transport
			if ( ViewModel.cboTransportTo.SelectedIndex != -1)
			{
				if ( ViewModel.cboTransportBy.SelectedIndex != -1)
				{
					if (UnitCL.GetTFDUnit(ViewModel.cboTransportBy.Text) != "")
					{
						ViewModel.EMSType = IncidentMain.ALSTRANS;
					}
					else
					{
						ViewModel.EMSType = IncidentMain.BLSTRANS;
					}
				}
				else
				{
					ViewModel.EMSType = IncidentMain.ALSTRANS;
				}
				CheckComplete();
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboTransportTo_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboTransportTo.SelectedIndex == -1)
			{
				ViewModel.cboTransportTo.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboTreatmentAuth_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboTreatmentAuth_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboTreatmentAuth.SelectedIndex == -1)
			{
				ViewModel.cboTreatmentAuth.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboVerbal_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboVerbal_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			int Index =this.ViewModel.cboVerbal.IndexOf((UpgradeHelpers.BasicViewModels.ComboBoxViewModel) eventSender);
			if ( ViewModel.cboVerbal[Index].SelectedIndex == -1)
			{
				ViewModel.cboVerbal[Index].Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboVitalsPosition_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboVitalsPosition_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			int Index =this.ViewModel.cboVitalsPosition.IndexOf((UpgradeHelpers.BasicViewModels.ComboBoxViewModel) eventSender);
			if ( ViewModel.cboVitalsPosition[Index].SelectedIndex == -1)
			{
				ViewModel.cboVitalsPosition[Index].Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void chkCPRPerformed_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			//Toggle CPRSwitch, Enable CPRTab
			if ( ViewModel.chkCPRPerformed.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				ViewModel.CPRSwitch = -1;
				ViewModel.tabEMS.Items[6].Text = "CPR";
				ViewModel.tabEMS.SelectedIndex = 2; //Return focus to Procedure tab
			}
			else
			{
				ViewModel.CPRSwitch = 0;
				ViewModel.tabEMS.Items[6].Text = "";
				ViewModel.tabEMS.SelectedIndex = 2; //Return focus to Procedure tab
			}

			CheckComplete();

		}

		[UpgradeHelpers.Events.Handler]
		internal void chkMajTrauma_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			//Toggle TraumaSwitch, Enable Trauma Tag
			if ( ViewModel.chkMajTrauma.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				ViewModel.tabEMS.Items[5].Text = "Trauma";
				ViewModel.TraumaSwitch = -1;
				ViewModel.tabEMS.SelectedIndex = 1; //Return focus to Exam Tab
			}
			else
			{
				ViewModel.tabEMS.Items[5].Text = "";
				ViewModel.TraumaSwitch = 0;
			}

			CheckComplete();

		}

		[UpgradeHelpers.Events.Handler]
		internal void chkNoVitals_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.chkNoVitals.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				ViewModel.NoVitals = -1;
			}
			else
			{
				ViewModel.NoVitals = 0;
			}
			CheckComplete();

		}

		[UpgradeHelpers.Events.Handler]
		internal void chkPalp_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAddALS_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//add als procedure record here
			TFDIncident.clsEMS EMSReport = Container.Resolve< clsEMS>();

			string EmpID = ViewModel.cboALSPersonnel.Text.Substring(Math.Max(ViewModel.cboALSPersonnel.Text.Length - 5, 0));
			EMSReport.ProcedurePatientID = ViewModel.PatientID;
			EMSReport.Procedure = ViewModel.cboALSProcedures.GetItemData(ViewModel.cboALSProcedures.SelectedIndex);
			EMSReport.PerformedBy = EmpID;
			if ( ViewModel.txtAttempts.Text != "")
			{
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				EMSReport.Attempts = Convert.ToInt32(IncidentMain.GetVal(ViewModel.txtAttempts.Text));
			}
			else
			{
				EMSReport.Attempts = 0;
			}
			if ( ViewModel.chkSuccessful.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				EMSReport.FlagSuccessful = 1;
			}
			else
			{
				EMSReport.FlagSuccessful = 0;
			}
			EMSReport.OtherProcedureDescription = ViewModel.txtOtherALSProcedures.Text;

			if (~EMSReport.AddEMSProcedure() != 0)
			{
				ViewManager.ShowMessage("Error in addding ALS Procedures", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
			}

			//Clean fields when done
			ViewModel.txtAttempts.Text = "";
			ViewModel.chkSuccessful.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.frmALSAttempts.Visible = false;
			ViewModel.txtOtherALSProcedures.Text = "";
			ViewModel.cboALSProcedures.SelectedIndex = -1;

			LoadALSProcedures();
			CheckComplete();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAddBLS_Click(Object eventSender, System.EventArgs eventArgs)
		{
			// add bls procedure record here
			string EmpID = "";
			TFDIncident.clsEMS EMSReport = Container.Resolve< clsEMS>();
			for (int i = 0; i <= ViewModel.lstBLSPersonnel.Items.Count - 1; i++)
			{
				if ( ViewModel.lstBLSPersonnel.GetSelected( i))
				{
					UpgradeHelpers.Helpers.ListBoxHelper.SetSelectedIndex(ViewModel.lstBLSPersonnel, i);
					EmpID = ViewModel.lstBLSPersonnel.Text.Substring(Math.Max(ViewModel.lstBLSPersonnel.Text.Length - 5, 0));
					EMSReport.ProcedurePatientID = ViewModel.PatientID;
					EMSReport.Procedure = ViewModel.cboBLSProcedures.GetItemData(ViewModel.cboBLSProcedures.SelectedIndex);
					EMSReport.PerformedBy = EmpID;
					EMSReport.Attempts = 0;
					EMSReport.FlagSuccessful = 1;
					EMSReport.OtherProcedureDescription = ViewModel.txtOtherBLSProcedures.Text;
					if (~EMSReport.AddEMSProcedure() != 0)
					{
						ViewManager.ShowMessage("Error in addding BLS Procedures", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					}
				}
			}
			//clear items
			ViewModel.txtOtherBLSProcedures.Text = "";
			ViewModel.txtOtherBLSProcedures.Visible = false;
			ViewModel.lbPInfo[26].Visible = false;
			ViewModel.cboBLSProcedures.SelectedIndex = -1;

			LoadBLSProcedures();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAddCPR_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Add CPR Performer record
			TFDIncident.clsEMS EMSReport = Container.Resolve< clsEMS>();

			int PerfCode = ViewModel.cboCPRPerformedBy.GetItemData(ViewModel.cboCPRPerformedBy.SelectedIndex);
			EMSReport.CPRPerfPatientID = ViewModel.PatientID;
			EMSReport.CPRPerformedBy = PerfCode;
			if ( ViewModel.chkCPRTrained.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				EMSReport.FlagCPRTrained = 1;
			}
			else
			{
				EMSReport.FlagCPRTrained = 0;
			}
			if ( ViewModel.chkWitnessedArrest.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				EMSReport.FlagArrestWitnessed = 1;
			}
			else
			{
				EMSReport.FlagArrestWitnessed = 0;
			}
			if (~EMSReport.AddEMSCPRPerformer() != 0)
			{
				ViewManager.ShowMessage("Error in adding CPR Performer Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
			}

			// Clear CPR Performer Selection Controls
			ViewModel.chkWitnessedArrest.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.chkCPRTrained.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.cboCPRPerformedBy.SelectedIndex = -1;
			ViewModel.cmdAddCPR.Enabled = false;

			LoadCPRPerformer();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAddMedications_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Add EMSMedication record
			TFDIncident.clsEMS EMSReport = Container.Resolve< clsEMS>();

			int MedCode = ViewModel.cboMedications.GetItemData(ViewModel.cboMedications.SelectedIndex);
			if (~EMSReport.GetEMSMedication(ViewModel.PatientID, MedCode) != 0)
			{
				EMSReport.MedPatientID = ViewModel.PatientID;
				EMSReport.Medication = MedCode;
				EMSReport.AdministeredDosage = Convert.ToInt32(Conversion.Val(ViewModel.txtDosage.Text));
				if (~EMSReport.AddEMSMedication() != 0)
				{
					ViewManager.ShowMessage("Error in adding Medications", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				}
			}
			else
			{
				//update
				EMSReport.MedPatientID = ViewModel.PatientID;
				EMSReport.Medication = MedCode;
				EMSReport.AdministeredDosage = Convert.ToInt32(Convert.ToDouble(EMSReport.EMSMedication["administered_dosage"]) + Conversion.Val(ViewModel.txtDosage.Text));
				if (!EMSReport.UpdateEMSMedication())
				{
					ViewManager.ShowMessage("Error in updating Medications", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				}
			}

			// Clear Medication Selection Controls
			ViewModel.cboMedications.SelectedIndex = -1;
			ViewModel.txtDosage.Text = "";

			LoadMedication();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAddNarration_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Determine Command Mode - Add New (1) or Save New (2)
			switch(Convert.ToString(ViewModel.cmdAddNarration.Tag))
			{
				case "1" :
					//    Clear Screen for New Narration 
					if ( ViewModel.NarrationUpdated != 0)
					{
						SaveNarration();
					}
					ViewModel.lbNarrID.Text = "";
					ViewModel.lbNarrAuthor.Text = IncidentMain.Shared.gCurrUserName;
					ViewModel.rtxNarration.Text = "";
					ViewModel.rtxNarration.Enabled = true;
					ViewManager.SetCurrent(ViewModel.rtxNarration);
					ViewModel.cmdAddNarration.Tag = "2";
					ViewModel.cmdAddNarration.Text = "Save New Narration";
					break;
				case "2" :
					//   Save New Narration 
					SaveNarration();
					LoadNarration(0);
					ViewModel.cmdAddNarration.Tag = "1";
					ViewModel.cmdAddNarration.Text = "Add New Narration";

					break;
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClear1_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Clear all option button selections
			ViewModel.FirstTime = -1;
			for (int i = 0; i <= 3; i++)
			{
				ViewModel.optArrestToCPR[i].Checked = false;
			}
			ViewModel.FirstTime = 0;
			CheckComplete();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClear2_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Clear all option button selections
			ViewModel.FirstTime = -1;
			for (int i = 0; i <= 3; i++)
			{
				ViewModel.optArrestToALS[i].Checked = false;
			}
			ViewModel.FirstTime = 0;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClear3_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Clear all option button selections
			ViewModel.FirstTime = -1;
			for (int i = 0; i <= 3; i++)
			{
				ViewModel.optArrestToShock[i].Checked = false;
			}
			ViewModel.FirstTime = 0;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdHIPAAInfo_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				IncidentMain.Shared.gHIPAAState = IncidentMain.HIPAARO;
				async1.Append(() =>
					{
						ViewManager.NavigateToView(
							dlgHIPAAMsg.DefInstance, true);
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdRemoveALSProcedures_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//remove als procedure records here
			//check to make sure that item has been selected
			TFDIncident.clsEMS EMScl = Container.Resolve< clsEMS>();

			int ProcSelect = 0;
			for (int i = 0; i <= ViewModel.lstALSProcedures.Items.Count - 1; i++)
			{
				if ( ViewModel.lstALSProcedures.GetSelected( i))
				{
					ProcSelect = -1;
					break;
				}
			}

			if (~ProcSelect != 0)
			{
				return;
			} //no items selected

			for (int i = 0; i <= ViewModel.lstALSProcedures.Items.Count - 1; i++)
			{
				if ( ViewModel.lstALSProcedures.GetSelected( i))
				{
					ProcSelect = ViewModel.lstALSProcedures.GetItemData(i);
					if (~EMScl.DeleteEMSProcedure(ref ProcSelect) != 0)
					{
						ViewManager.ShowMessage("Error deleting ALS Procedure", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						break;
					}
				}
			}

			LoadALSProcedures();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdRemoveBLSProcedures_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//remove bls procedure records here
			//check to make sure that item has been selected
			TFDIncident.clsEMS EMScl = Container.Resolve< clsEMS>();

			int ProcSelect = 0;
			for (int i = 0; i <= ViewModel.lstBLSProcedures.Items.Count - 1; i++)
			{
				if ( ViewModel.lstBLSProcedures.GetSelected( i))
				{
					ProcSelect = -1;
					break;
				}
			}

			if (~ProcSelect != 0)
			{
				return;
			} //no items selected

			for (int i = 0; i <= ViewModel.lstBLSProcedures.Items.Count - 1; i++)
			{
				if ( ViewModel.lstBLSProcedures.GetSelected( i))
				{
					ProcSelect = ViewModel.lstBLSProcedures.GetItemData(i);
					if (~EMScl.DeleteEMSProcedure(ref ProcSelect) != 0)
					{
						ViewManager.ShowMessage("Error deleting BLS Procedure", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						break;
					}
				}
			}

			LoadBLSProcedures();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdRemoveCPR_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Remove Selected CPR Performer Record
			//check to make sure that item has been selected
			TFDIncident.clsEMS EMScl = Container.Resolve< clsEMS>();

			int CPRSelect = 0;
			for (int i = 0; i <= ViewModel.lstCPRPerformedBy.Items.Count - 1; i++)
			{
				if ( ViewModel.lstCPRPerformedBy.GetSelected( i))
				{
					CPRSelect = -1;
					break;
				}
			}


			if (~CPRSelect != 0)
			{
				return;
			} //no items selected

			for (int i = 0; i <= ViewModel.lstCPRPerformedBy.Items.Count - 1; i++)
			{
				if ( ViewModel.lstCPRPerformedBy.GetSelected( i))
				{
					int tempRefParam = ViewModel.lstCPRPerformedBy.GetItemData(i);
					if (~EMScl.DeleteEMSCPRPerformer(ref tempRefParam) != 0)
					{
						ViewManager.ShowMessage("Error deleting CPR Performer", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						break;
					}
				}
			}

			LoadCPRPerformer();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdRemoveMedication_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Remove Selected Medication Record
			//check to make sure that item has been selected
			TFDIncident.clsEMS EMScl = Container.Resolve< clsEMS>();

			int MedSelect = 0;
			for (int i = 0; i <= ViewModel.lstMedications.Items.Count - 1; i++)
			{
				if ( ViewModel.lstMedications.GetSelected( i))
				{
					MedSelect = -1;
					break;
				}
			}

			if (~MedSelect != 0)
			{
				return;
			} //no items selected

			for (int i = 0; i <= ViewModel.lstMedications.Items.Count - 1; i++)
			{
				if ( ViewModel.lstMedications.GetSelected( i))
				{
					MedSelect = ViewModel.lstMedications.GetItemData(i);
					if (~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
							{
								var ret = EMScl.DeleteEMSMedication(ref p1, ref MedSelect);
								ViewModel.PatientID = p1;
								return ret;
							}, ViewModel.PatientID) != 0)
					{
						ViewManager.ShowMessage("Error deleting Medications", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						break;
					}
				}
			}

			LoadMedication();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdSave_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				int Index =this.ViewModel.cmdSave.IndexOf((UpgradeHelpers.BasicViewModels.ButtonViewModel) eventSender);

				if (Index == 0)
				{
					if (SaveEMSReport(IncidentMain.COMPLETE) != 0)
					{
						ViewManager.ShowMessage("EMS Patient Report Saved as Complete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
					}
					else
					{
						ViewManager.ShowMessage("Error Occured While Attempting to Save EMS Patient Report", "TFD Incident Reporting System", UpgradeHelpers.Helpers.
							BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					}
				}
				else if (Index == 1)
				{
					if (SaveEMSReport(IncidentMain.SAVEDINCOMPLETE) != 0)
					{
						ViewManager.ShowMessage("EMS Patient Report Saved as Incomplete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
					}
					else
					{
						ViewManager.ShowMessage("Error Occured While Attempting to Save EMS Patient Report", "TFD Incident Reporting System", UpgradeHelpers.Helpers.
							BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					}
				}

				if (Index != 3)
				{
					//If not Print request then Reset HIPAA variables and exit
					IncidentMain
						.Shared.gHIPAAState = IncidentMain.HIPAARO;
					IncidentMain.Shared.gHIPAAOK = 0;
					IncidentMain.Shared.gHIPAAPatientID = 0;
					ViewManager.DisposeView(this);
				}
				else
				{
					//Print Preview Report
					IncidentMain
						.Shared.gPrintReportID = ViewModel.PatientID;
					async1.Append(() =>
						{
							ViewManager.NavigateToView(
								frmReportEMS.DefInstance, true);
						});
				}
			}

			}

		[UpgradeHelpers.Events.Handler]
		internal void FDCaresBtn_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				TFDIncident.clsEMS EMScl = Container.Resolve< clsEMS>();

				IncidentMain.Shared.gFDCaresIncidentID = ViewModel.CurrIncident;
				IncidentMain.Shared.gFDCaresPatientID = ViewModel.PatientID;
				IncidentMain.Shared.gFDCaresComment = "";
				IncidentMain.Shared.gFDCaresOK = -1;
				async1.Append(() =>
					{
						ViewManager.NavigateToView(
							dlgFDCares.DefInstance, true);
					});
				async1.Append(() =>
					{
						if (IncidentMain.Shared.gFDCaresOK != 0)
						{
							if (EMScl.GetFDCaresIncident(IncidentMain.Shared.gFDCaresIncidentID) != 0)
							{
								if (~EMScl.UpdateFDCaresReferral(IncidentMain.Shared.gFDCaresIncidentID, IncidentMain.Shared.gFDCaresPatientID, IncidentMain.Shared.gFDCaresComment) != 0)
								{
									ViewManager.ShowMessage("Unable to process FDCares Referral", System.Diagnostics.FileVersionInfo.GetVersionInfo(System
										.Reflection.Assembly.GetExecutingAssembly().Location).ProductName, UpgradeHelpers.Helpers.BoxButtons.OK);
								}
								else
								{
									ViewManager.ShowMessage("Incident Referred to FDCares", System.Diagnostics.FileVersionInfo.GetVersionInfo(System.
										Reflection.Assembly.GetExecutingAssembly().Location).ProductName, UpgradeHelpers.Helpers.BoxButtons.OK);
								}
							}
							else
							{
								if (~IncidentMain.ProcessFDCaresReferral(IncidentMain.Shared.gFDCaresIncidentID, IncidentMain.Shared.gFDCaresIncidentID) != 0)
								{
									ViewManager.ShowMessage("Unable to process FDCares Referral", System.Diagnostics.FileVersionInfo.GetVersionInfo(System
										.Reflection.Assembly.GetExecutingAssembly().Location).ProductName, UpgradeHelpers.Helpers.BoxButtons.OK);
								}
								else
								{
									ViewManager.ShowMessage("Incident Referred to FDCares", System.Diagnostics.FileVersionInfo.GetVersionInfo(System.
										Reflection.Assembly.GetExecutingAssembly().Location).ProductName, UpgradeHelpers.Helpers.BoxButtons.OK);
								}
							}
							ViewModel.FDCaresBtn.Enabled = false;
						}
					});
			}
					}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			//Retrieve ReportLog Record
			//Format Form Controls
			TFDIncident.clsReportLog ReportLog = Container.Resolve< clsReportLog>();
			TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();
			TFDIncident.clsEMS EMSReport = Container.Resolve< clsEMS>();

			if (ReportLog.GetReportLog(IncidentMain.Shared.gEditReportID) != 0)
			{
				ViewModel.ReportLogID = ReportLog.ReportLogID;
				ViewModel.CurrIncident = ReportLog.RLIncidentID;
				ViewModel.PatientID = ReportLog.ReportReferenceID;
				if (~IncidentCL.GetIncident(ViewModel.CurrIncident) != 0)
				{
					ViewManager.ShowMessage("Error Retrieving Incident Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				}
				else
				{
					ViewModel.lbIncident.Text = IncidentCL.IncidentNumber;
					ViewModel.lbLocation.Text = IncidentCL.Location;
				}
				if (~EMSReport.GetEMSPatientContact(ViewModel.PatientID) != 0)
				{
					ViewManager.ShowMessage("Error Retrieving Patient Records", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					ViewManager.DisposeView(this);
				}
				else
				{
					ViewModel.ActionTaken = EMSReport.ActionTaken;
					ViewModel.EMSType = EMSReport.IncidentType;
					if ( ViewModel.EMSType == 0)
					{
						ViewModel.EMSType = IncidentMain.BLS;
					}
					ViewModel.FirstTime = -1;
					ViewModel.NarrationUpdated = 0;
					if ( ViewModel.EMSType == 5)
					{ //-Dead at scene

						ViewModel.NarrationRequired = -1;
					}
					else
					{
						ViewModel.NarrationRequired = 0;
					}
					ViewModel.ReqNarrString = "Describe the Event or Situation Involving Reported Death or Injury";
					ViewModel.ReqNarrString = ViewModel.ReqNarrString + " - Required";
					ViewModel.NoVitals = 0;
					LoadLists();
					GetEMSData();
					ViewModel.FirstTime = 0;
					CheckComplete();
					if (IncidentMain.Shared.gWizardSecurity == IncidentMain.READONLY)
					{
						LockScreen();
					}
					IncidentMain.Shared.gHIPAAState = IncidentMain.HIPAARO;
					UpdateHIPAA(IncidentMain.Shared.gHIPAAState);
				}
			}
			else
			{
				ViewManager.ShowMessage("Error Retrieving ReportLog Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				ViewManager.DisposeView(this);
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lstBLSPersonnel_SelectedIndexChanged(Object eventSender, System.EventArgs eventArgs)
		{

			int ProcSelect = 0;
			for (int i = 0; i <= ViewModel.lstBLSPersonnel.Items.Count - 1; i++)
			{
				if ( ViewModel.lstBLSPersonnel.GetSelected( i))
				{
					ProcSelect = -1;
					break;
				}
			}
			if (ProcSelect != 0)
			{
				ViewModel.cmdAddBLS.Enabled = ViewModel.cboBLSProcedures.SelectedIndex != -1;
			}
			else
			{
				ViewModel.cmdAddBLS.Enabled = false;
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void lstTrauma1_SelectedIndexChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void lstTrauma2_SelectedIndexChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void lstTrauma3_SelectedIndexChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void mskBirthdate_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			EditBirthdate();
			CheckComplete();

		}

		[UpgradeHelpers.Events.Handler]
		internal void optArrestToCPR_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				CheckComplete();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optEMSEthnicity_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				CheckComplete();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optEMSGender_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				CheckComplete();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optGender_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				CheckComplete();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optLevelOfConsciouness_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				CheckComplete();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optMDorRN_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				CheckComplete();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optPupils_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				CheckComplete();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optRespiratoryEffort_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				CheckComplete();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optSeverity_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				CheckComplete();
			}
		}

		private void rtxNarration_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime != 0)
			{
				return;
			}
			if ( ViewModel.rtxNarration.BackColor.Equals(IncidentMain.Shared.REQCOLOR))
			{
				if ( ViewModel.rtxNarration.Text != "")
				{
					CheckComplete();
				}
			}
			ViewModel.NarrationUpdated = -1;

		}



		//Mobilize: Event not map.
		//private void tabEMS_TabPageActivate(Object eventSender, AxTabproLib._DTabEvents_TabPageActivateEvent eventArgs)
		//{
		//	//Only allow movement to Valid Tabs
		//	tabEMS.Tab = eventArgs.tabToActivate;
		//	if (tabEMS.TabCaption == "")
		//	{
		//		eventArgs.tabToActivate = -1;
		//	}

		//}
		[UpgradeHelpers.Events.Handler]
		internal void txtAge_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtAmount_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtAttempts_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
			if ( ViewModel.cboALSPersonnel.SelectedIndex != -1)
			{
				if ( ViewModel.txtAttempts.Text != "")
				{
					double dbNumericTemp = 0;
					ViewModel.cmdAddALS.Enabled = Double.TryParse(ViewModel.txtAttempts.Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp);
				}
				else
				{
					ViewModel.cmdAddALS.Enabled = false;
				}
			}
			else
			{
				ViewModel.cmdAddALS.Enabled = false;
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void txtBBirthdate_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			EditBasicBirthdate();
			CheckComplete();

		}

		[UpgradeHelpers.Events.Handler]
		internal void txtBFirstName_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtBLastName_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtDiastolic_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtDosage_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboMedications.SelectedIndex != -1)
			{
				if ( ViewModel.txtDosage.Text != "")
				{
					double dbNumericTemp = 0;
					ViewModel.cmdAddMedications.Enabled = Double.TryParse(ViewModel.txtDosage.Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp);
				}
				else
				{
					ViewModel.cmdAddMedications.Enabled = false;
				}
			}
			else
			{
				ViewModel.cmdAddMedications.Enabled = false;
			}
			CheckComplete();

		}

		[UpgradeHelpers.Events.Handler]
		internal void txtExtricationTime_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtFirstName_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtGlucose_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtIncidentZipcode_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtLastName_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtMileage_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtOtherBLSProcedures_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtPatientAge_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtPerOxy_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtPulse_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtPulseOxy_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtRespiration_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtSystolic_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtTime_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtTime_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			int Index =this.ViewModel.txtTime.IndexOf((UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel) eventSender);
			//Edit TimeEntry
			//Don't edit if empty
			if ( ViewModel.txtTime[Index].Text == "__:__")
			{
				return;
			}

			string HourWork = "", MinWork = "";

			string TimeWork = ViewModel.txtTime[Index].Text;
			TimeWork = Strings.Replace(TimeWork, "_", "0", 1, -1, CompareMethod.Binary);
			int TimeCheck = Convert.ToInt32(Conversion.Val(TimeWork.Substring(0, Math.Min(2, TimeWork.Length))));
			if (TimeCheck > 23)
			{
				if ( UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.txtTime[Index]) == 0)
				{
					ViewModel.txtTime[Index].Text = "";
					ViewModel.txtTime[Index].BackColor = IncidentMain.Shared.REQCOLOR;
					ViewModel.txtTime[Index].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					ViewManager.SetCurrent(ViewModel.txtTime[Index]);
				}
				else
				{
					ViewModel.txtTime[Index].Text = "__:__";
					ViewManager.SetCurrent(ViewModel.txtTime[Index]);
				}
				return;
			}
			if (TimeCheck < 10)
			{
				HourWork = "0" + TimeCheck.ToString();
			}
			else
			{
				HourWork = TimeCheck.ToString();
			}
			TimeCheck = Convert.ToInt32(Conversion.Val(TimeWork.Substring(Math.Max(TimeWork.Length - 2, 0))));
			if (TimeCheck > 59)
			{
				if ( UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.txtTime[Index]) == 0)
				{
					ViewModel.txtTime[Index].Text = "__:__";
					ViewModel.txtTime[Index].BackColor = IncidentMain.Shared.REQCOLOR;
					ViewModel.txtTime[Index].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					ViewManager.SetCurrent(ViewModel.txtTime[Index]);
				}
				else
				{
					ViewModel.txtTime[Index].Text = "__:__";
					ViewManager.SetCurrent(ViewModel.txtTime[Index]);
				}
				return;
			}
			if (TimeCheck < 10)
			{
				MinWork = "0" + TimeCheck.ToString();
			}
			else
			{
				MinWork = TimeCheck.ToString();
			}
			ViewModel.FirstTime = -1;
			TimeWork = HourWork + ":" + MinWork;
			ViewModel.txtTime[Index].Text = TimeWork;
			ViewModel.FirstTime = 0;

		}

		[UpgradeHelpers.Events.Handler]
		internal void txtTraumaID_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmEMSReport DefInstance
		{
		    get
		    {
		        if ( Shared.m_vb6FormDefInstance == null)
				{
					Shared.
						m_InitializingDefInstance = true;
					Shared.
						m_vb6FormDefInstance = CreateInstance();
					Shared.
						m_InitializingDefInstance = false;
				}
				return Shared. m_vb6FormDefInstance;
			}
			set
			{
				Shared.
					m_vb6FormDefInstance = value;
			}
	}

		public static frmEMSReport CreateInstance()
		{
			TFDIncident.frmEMSReport theInstance = Shared.Container.Resolve< frmEMSReport>();
			theInstance.Form_Load();
			//The MDI form in the VB6 project had its
			//AutoShowChildren property set to True
			//To simulate the VB6 behavior, we need to
			//automatically Show the form whenever it
			//is loaded.  If you do not want this behavior
			//then delete the following line of code
			//UPGRADE_TODO: (2018) Remove the next line of code to stop form from automatically showing. More Information: http://www.vbtonet.com/ewis/ewi2018.aspx
			Shared.ViewManager.NavigateToView(
				//The MDI form in the VB6 project had its
				//AutoShowChildren property set to True
				//To simulate the VB6 behavior, we need to
				//automatically Show the form whenever it
				//is loaded.  If you do not want this behavior
				//then delete the following line of code
				//UPGRADE_TODO: (2018) Remove the next line of code to stop form from automatically showing. More Information: http://www.vbtonet.com/ewis/ewi2018.aspx
				theInstance
				);
			return theInstance;
	}

		void ReLoadForm(bool addEvents)
		{
			using ( var async1 = this.Async(true) )
			{
				async1.Append<TFDIncident.MDIIncident>(() => TFDIncident.MDIIncident.DefInstance);
				//This form is an MDI child.
				//This code simulates the VB6 
				// functionality of automatically
				// loading and showing an MDI
				// child's parent.
				;
				async1.Append<TFDIncident.MDIIncident>(() =>
					TFDIncident.MDIIncident.DefInstance);
				async1.Append<TFDIncident.MDIIncident>(tempNormalized1 =>
					{
						ViewManager.NavigateToView(tempNormalized1);
					});
			}
		}

		protected override void ExecuteControlsStartup()
		{
			ViewModel.tabPage19.LifeCycleStartup();
			ViewModel.tabPage18.LifeCycleStartup();
			ViewModel.tabPage17.LifeCycleStartup();
			ViewModel.tabPage16.LifeCycleStartup();
			ViewModel.tabPage15.LifeCycleStartup();
			ViewModel.tabPage14.LifeCycleStartup();
			ViewModel.tabPage13.LifeCycleStartup();
			ViewModel.tabPage12.LifeCycleStartup();
			ViewModel.tabPage11.LifeCycleStartup();
			ViewModel.tabPage10.LifeCycleStartup();
			ViewModel.tabPage9.LifeCycleStartup();
			ViewModel.tabPage8.LifeCycleStartup();
			ViewModel.tabPage7.LifeCycleStartup();
			ViewModel.tabPage6.LifeCycleStartup();
			ViewModel.tabPage5.LifeCycleStartup();
			ViewModel.tabPage4.LifeCycleStartup();
			ViewModel.tabPage3.LifeCycleStartup();
			ViewModel.tabPage2.LifeCycleStartup();
			ViewModel.tabPage1.LifeCycleStartup();
			ViewModel.picEMSBar.LifeCycleStartup();
			ViewModel.tabEMS.LifeCycleStartup();
			ViewModel.frmGender.LifeCycleStartup();
			ViewModel.frmIllness.LifeCycleStartup();
			ViewModel.frmInjury.LifeCycleStartup();
			ViewModel.frmALSAttempts.LifeCycleStartup();
			ViewModel.Shape1.LifeCycleStartup();
			ViewModel.frmArrestToShock.LifeCycleStartup();
			ViewModel.frmArrestToALS.LifeCycleStartup();
			ViewModel.frmArrestToCPR.LifeCycleStartup();
			ViewModel.frmBasicGender.LifeCycleStartup();
			ViewModel.frmSeverity.LifeCycleStartup();
			ViewModel.Frame21.LifeCycleStartup();
			ViewModel.tabVitals.LifeCycleStartup();
			ViewModel.Frame15.LifeCycleStartup();
			ViewModel.Frame17.LifeCycleStartup();
			ViewModel.Frame18.LifeCycleStartup();
			ViewModel.Frame19.LifeCycleStartup();
			ViewModel.Frame20.LifeCycleStartup();
			ViewModel.vaTabPro2.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.tabPage19.LifeCycleShutdown();
			ViewModel.tabPage18.LifeCycleShutdown();
			ViewModel.tabPage17.LifeCycleShutdown();
			ViewModel.tabPage16.LifeCycleShutdown();
			ViewModel.tabPage15.LifeCycleShutdown();
			ViewModel.tabPage14.LifeCycleShutdown();
			ViewModel.tabPage13.LifeCycleShutdown();
			ViewModel.tabPage12.LifeCycleShutdown();
			ViewModel.tabPage11.LifeCycleShutdown();
			ViewModel.tabPage10.LifeCycleShutdown();
			ViewModel.tabPage9.LifeCycleShutdown();
			ViewModel.tabPage8.LifeCycleShutdown();
			ViewModel.tabPage7.LifeCycleShutdown();
			ViewModel.tabPage6.LifeCycleShutdown();
			ViewModel.tabPage5.LifeCycleShutdown();
			ViewModel.tabPage4.LifeCycleShutdown();
			ViewModel.tabPage3.LifeCycleShutdown();
			ViewModel.tabPage2.LifeCycleShutdown();
			ViewModel.tabPage1.LifeCycleShutdown();
			ViewModel.picEMSBar.LifeCycleShutdown();
			ViewModel.tabEMS.LifeCycleShutdown();
			ViewModel.frmGender.LifeCycleShutdown();
			ViewModel.frmIllness.LifeCycleShutdown();
			ViewModel.frmInjury.LifeCycleShutdown();
			ViewModel.frmALSAttempts.LifeCycleShutdown();
			ViewModel.Shape1.LifeCycleShutdown();
			ViewModel.frmArrestToShock.LifeCycleShutdown();
			ViewModel.frmArrestToALS.LifeCycleShutdown();
			ViewModel.frmArrestToCPR.LifeCycleShutdown();
			ViewModel.frmBasicGender.LifeCycleShutdown();
			ViewModel.frmSeverity.LifeCycleShutdown();
			ViewModel.Frame21.LifeCycleShutdown();
			ViewModel.tabVitals.LifeCycleShutdown();
			ViewModel.Frame15.LifeCycleShutdown();
			ViewModel.Frame17.LifeCycleShutdown();
			ViewModel.Frame18.LifeCycleShutdown();
			ViewModel.Frame19.LifeCycleShutdown();
			ViewModel.Frame20.LifeCycleShutdown();
			ViewModel.vaTabPro2.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmEMSReport
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.frmEMSReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		public static SharedState Shared
		{
			get
			{
				return UpgradeHelpers.Helpers.StaticContainer.GetSharedItem<SharedState>();
			}
		}

		[UpgradeHelpers.Helpers.Singleton]
		public class SharedState
			: UpgradeHelpers.Interfaces.IModel, UpgradeHelpers.Interfaces.ICreatesObjects, UpgradeHelpers.
			Interfaces.IInteractsWithView, UpgradeHelpers.Interfaces.IInitializableCommon, UpgradeHelpers.Interfaces.IInitializable
		{

			public string UniqueID { get; set; }

			public UpgradeHelpers.Interfaces.IIocContainer Container { get; set; }

			public UpgradeHelpers.Interfaces.IViewManager ViewManager { get; set; }

			void UpgradeHelpers.Interfaces.IInitializableCommon.Common()
			{
			}

			public virtual frmEMSReport m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}