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

	public partial class frmOtherReports
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.frmOtherReportsViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmOtherReports));
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

        [UpgradeHelpers.Events.Handler]
        internal void cmdDone_Click(object p1, object p2)
        {
            ViewModel.frmFPE.Left = IncidentMain.WIZARDWIDTH;
            ViewModel.cmdSave[0].Enabled = true;
            ViewModel.cmdSave[1].Enabled = true;
        }

        private void frmOtherReports_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}


		private void SaveNarration()
		{
			//determine if Insert or Update
			//Save Incident Narration Record
			int NarrID = 0;
			TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();

			switch( ViewModel.CurrReport)
			{
				case IncidentMain.HAZCONDITION : case IncidentMain.SEARCHRESCUE : case IncidentMain.FALSEALARM :

					IncidentCL.NarrationIncidentID = ViewModel.CurrIncident;
					IncidentCL.ReportType = ViewModel.CurrReport;
					IncidentCL.NarrationText = ViewModel.rtxAllNarration.Text;
					IncidentCL.NarrationBy = IncidentMain.Shared.gCurrUser;
					IncidentCL.NarrationLastUpdate = DateTime.Now.ToString("MM/dd/yyyy");
					NarrID = Convert.ToInt32(Conversion.Val(ViewModel.lbAllNarrID.Text));

					break;
				case IncidentMain.INVESTIGATION : case IncidentMain.CLEANUP : case IncidentMain.STANDBY :

					IncidentCL.NarrationIncidentID = ViewModel.CurrIncident;
					IncidentCL.ReportType = ViewModel.CurrReport;
					IncidentCL.NarrationText = ViewModel.rtxServiceNarration.Text;
					IncidentCL.NarrationBy = IncidentMain.Shared.gCurrUser;
					IncidentCL.NarrationLastUpdate = DateTime.Now.ToString("MM/dd/yyyy");
					NarrID = Convert.ToInt32(Conversion.Val(ViewModel.lbServiceNarrID.Text));
					break;
				case IncidentMain.CIVILCASUALTY :
					IncidentCL.NarrationIncidentID = ViewModel.CurrIncident;
					IncidentCL.ReportType = ViewModel.CurrReport;
					IncidentCL.NarrationText = ViewModel.rtxCivilNarration.Text;
					IncidentCL.NarrationBy = IncidentMain.Shared.gCurrUser;
					IncidentCL.NarrationLastUpdate = DateTime.Now.ToString("MM/dd/yyyy");
					NarrID = Convert.ToInt32(Conversion.Val(ViewModel.lbCivilNarrID.Text));

					break;
			}

			if (NarrID == 0)
			{
				if (~IncidentCL.AddNarration() != 0)
				{
					ViewManager.ShowMessage("Error attempting to save Narration Record", "Edit Report", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				}
				else
				{
					ViewModel.NarrationUpdated = 0;
				}
			}
			else
			{
				IncidentCL.NarrationID = NarrID;
				if (IncidentCL.GetNarrationSecurity(NarrID, IncidentMain.Shared.gCurrUser) != 0)
				{
					if (~IncidentCL.UpdateNarration() != 0)
					{
						ViewManager.ShowMessage("Error attempting to update Narration Record", "Edit Report", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					}
					else
					{
						ViewModel.NarrationUpdated = 0;
					}
				}
			}




		}


		private void LoadNarration(int lNarrID)
		{
			//Load Narration combo and display requested narration
			//**** Change to display narration of current user *****
			TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();
			string SaveText = "";
			string SaveAuthor = "";
			int SaveID = 0;
			int CurrNarr = 0;
			ViewModel.FirstTime = -1;

			switch( ViewModel.CurrReport)
			{
				case IncidentMain.HAZCONDITION : case IncidentMain.SEARCHRESCUE : case IncidentMain.FALSEALARM :
					ViewModel.rtxAllNarration.Text = "";
					ViewModel.lbAllNarrID.Text = "";
					ViewModel.lbAllNarrAuthor.Text = "";
					ViewModel.cboNarrList.Items.Clear();

					if (IncidentCL.NarrationListRS(ViewModel.CurrIncident, ViewModel.CurrReport) != 0)
					{
						SaveID = Convert.ToInt32(IncidentCL.IncidentNarration["narration_id"]);
						SaveAuthor = IncidentMain.Clean(IncidentCL.IncidentNarration["name_full"]);
						SaveText = Convert.ToString(IncidentCL.IncidentNarration["narration_text"]);

						while(!IncidentCL.IncidentNarration.EOF)
						{
							ViewModel.cboNarrList.AddItem(IncidentMain.Clean(IncidentCL.IncidentNarration["name_full"]));
							ViewModel.cboNarrList.SetItemData(ViewModel.cboNarrList.GetNewIndex(), Convert.ToInt32(IncidentCL.IncidentNarration["narration_id"]));

							if (lNarrID == Convert.ToDouble(IncidentCL.IncidentNarration["narration_id"]))
							{
								ViewModel.lbAllNarrID.Text = Convert.ToString(IncidentCL.IncidentNarration["narration_id"]);
								ViewModel.rtxAllNarration.Text = Convert.ToString(IncidentCL.IncidentNarration["narration_text"]);
								ViewModel.lbAllNarrAuthor.Text = IncidentMain.Clean(IncidentCL.IncidentNarration["name_full"]);
								if (IncidentMain.Clean(IncidentCL.IncidentNarration["narration_by"]) != IncidentMain.Shared.gCurrUser)
								{
									ViewModel.rtxAllNarration.Enabled = false;
								}
								CurrNarr = ViewModel.cboNarrList.GetNewIndex();
							}
							else if (IncidentMain.Clean(IncidentCL.IncidentNarration["narration_by"]) == IncidentMain.Shared.gCurrUser)
							{
								ViewModel.cmdAddNarration.Enabled = false;
								if (lNarrID == 0)
								{
									ViewModel.lbAllNarrID.Text = Convert.ToString(IncidentCL.IncidentNarration["narration_id"]);
									ViewModel.rtxAllNarration.Text = Convert.ToString(IncidentCL.IncidentNarration["narration_text"]);
									ViewModel.lbAllNarrAuthor.Text = IncidentMain.Clean(IncidentCL.IncidentNarration["name_full"]);
									ViewModel.rtxAllNarration.Enabled = true;
									CurrNarr = ViewModel.cboNarrList.GetNewIndex();
								}
							}
							IncidentCL.IncidentNarration.MoveNext();
						};
						if ( ViewModel.lbAllNarrID.Text == "")
						{
							ViewModel.lbAllNarrID.Text = SaveID.ToString();
							ViewModel.lbAllNarrAuthor.Text = SaveAuthor;
							ViewModel.rtxAllNarration.Text = SaveText;
							ViewModel.rtxAllNarration.Enabled = false;
							ViewModel.cboNarrList.SelectedIndex = 0;
						}
						else
						{
							ViewModel.cboNarrList.SelectedIndex = CurrNarr;
						}
					}

					break;
				case IncidentMain.INVESTIGATION : case IncidentMain.CLEANUP : case IncidentMain.STANDBY :
					ViewModel.rtxServiceNarration.Text = "";
					ViewModel.lbServiceNarrID.Text = "";
					ViewModel.lbServNarrAuthor.Text = "";
					ViewModel.cboServiceNarrList.Items.Clear();

					if (IncidentCL.NarrationListRS(ViewModel.CurrIncident, ViewModel.CurrReport) != 0)
					{
						SaveID = Convert.ToInt32(IncidentCL.IncidentNarration["narration_id"]);
						SaveAuthor = IncidentMain.Clean(IncidentCL.IncidentNarration["name_full"]);
						SaveText = Convert.ToString(IncidentCL.IncidentNarration["narration_text"]);

						while(!IncidentCL.IncidentNarration.EOF)
						{
							ViewModel.cboServiceNarrList.AddItem(IncidentMain.Clean(IncidentCL.IncidentNarration["name_full"]));
							ViewModel.cboServiceNarrList.SetItemData(ViewModel.cboServiceNarrList.GetNewIndex(), Convert.ToInt32(IncidentCL.IncidentNarration["narration_id"]));

							if (lNarrID == Convert.ToDouble(IncidentCL.IncidentNarration["narration_id"]))
							{
								ViewModel.lbServiceNarrID.Text = Convert.ToString(IncidentCL.IncidentNarration["narration_id"]);
								ViewModel.rtxServiceNarration.Text = Convert.ToString(IncidentCL.IncidentNarration["narration_text"]);
								ViewModel.lbServNarrAuthor.Text = IncidentMain.Clean(IncidentCL.IncidentNarration["name_full"]);
								if (IncidentMain.Clean(IncidentCL.IncidentNarration["narration_by"]) != IncidentMain.Shared.gCurrUser)
								{
									ViewModel.rtxServiceNarration.Enabled = false;
								}
							}
							else if (IncidentMain.Clean(IncidentCL.IncidentNarration["narration_by"]) == IncidentMain.Shared.gCurrUser)
							{
								ViewModel.cmdServAddNarration.Enabled = false;
								if (lNarrID == 0)
								{
									ViewModel.lbServiceNarrID.Text = Convert.ToString(IncidentCL.IncidentNarration["narration_id"]);
									ViewModel.rtxServiceNarration.Text = Convert.ToString(IncidentCL.IncidentNarration["narration_text"]);
									ViewModel.lbServNarrAuthor.Text = IncidentMain.Clean(IncidentCL.IncidentNarration["name_full"]);
									ViewModel.rtxServiceNarration.Enabled = true;
								}
							}
							IncidentCL.IncidentNarration.MoveNext();
						};
						if ( ViewModel.lbServiceNarrID.Text == "")
						{
							ViewModel.lbServiceNarrID.Text = SaveID.ToString();
							ViewModel.lbServNarrAuthor.Text = SaveAuthor;
							ViewModel.rtxServiceNarration.Text = SaveText;
							ViewModel.rtxServiceNarration.Enabled = false;
							ViewModel.cboServiceNarrList.SelectedIndex = 0;
						}
					}

					break;
				case IncidentMain.CIVILCASUALTY :
					ViewModel.rtxCivilNarration.Text = "";
					ViewModel.lbCivilNarrID.Text = "";
					ViewModel.lbCCAuthor.Text = "";
					ViewModel.cboCivNarrList.Items.Clear();

					if (IncidentCL.NarrationListRS(ViewModel.CurrIncident, ViewModel.CurrReport) != 0)
					{
						SaveID = Convert.ToInt32(IncidentCL.IncidentNarration["narration_id"]);
						SaveAuthor = IncidentMain.Clean(IncidentCL.IncidentNarration["name_full"]);
						SaveText = Convert.ToString(IncidentCL.IncidentNarration["narration_text"]);

						while(!IncidentCL.IncidentNarration.EOF)
						{
							ViewModel.cboCivNarrList.AddItem(IncidentMain.Clean(IncidentCL.IncidentNarration["name_full"]));
							ViewModel.cboCivNarrList.SetItemData(ViewModel.cboCivNarrList.GetNewIndex(), Convert.ToInt32(IncidentCL.IncidentNarration["narration_id"]));

							if (lNarrID == Convert.ToDouble(IncidentCL.IncidentNarration["narration_id"]))
							{
								ViewModel.lbCivilNarrID.Text = Convert.ToString(IncidentCL.IncidentNarration["narration_id"]);
								ViewModel.rtxCivilNarration.Text = Convert.ToString(IncidentCL.IncidentNarration["narration_text"]);
								ViewModel.lbCCAuthor.Text = IncidentMain.Clean(IncidentCL.IncidentNarration["name_full"]);
								if (IncidentMain.Clean(IncidentCL.IncidentNarration["narration_by"]) != IncidentMain.Shared.gCurrUser)
								{
									ViewModel.rtxCivilNarration.Enabled = false;
								}
							}
							else if (IncidentMain.Clean(IncidentCL.IncidentNarration["narration_by"]) == IncidentMain.Shared.gCurrUser)
							{
								ViewModel.cmdCivAddNarration.Enabled = false;
								if (lNarrID == 0)
								{
									ViewModel.lbCivilNarrID.Text = Convert.ToString(IncidentCL.IncidentNarration["narration_id"]);
									ViewModel.rtxCivilNarration.Text = Convert.ToString(IncidentCL.IncidentNarration["narration_text"]);
									ViewModel.lbCCAuthor.Text = IncidentMain.Clean(IncidentCL.IncidentNarration["name_full"]);
									ViewModel.rtxCivilNarration.Enabled = true;
								}
							}
							IncidentCL.IncidentNarration.MoveNext();
						};
						if ( ViewModel.lbCivilNarrID.Text == "")
						{
							ViewModel.lbCivilNarrID.Text = SaveID.ToString();
							ViewModel.lbCCAuthor.Text = SaveAuthor;
							ViewModel.rtxCivilNarration.Text = SaveText;
							ViewModel.rtxCivilNarration.Enabled = false;
							ViewModel.cboCivNarrList.SelectedIndex = 0;
						}
					}

					break;
			}
			ViewModel.FirstTime = 0;
			ViewModel.NarrationUpdated = 0;

		}


		private int SaveCasualty(int UType)
		{
			//Create ReportLog record and FSCasualty Record
			//*** Under Construction ***
			int result = 0;
			TFDIncident.clsCasualty CasualtyCL = Container.Resolve< clsCasualty>();
			TFDIncident.clsReportLog ReportLog = Container.Resolve< clsReportLog>();

			result = -1;
			//Update Fire Service Casualty Record & ReportLog
			if (~CasualtyCL.GetFSCasualty(ViewModel.CurrReportID) != 0)
			{
				result = 0;
				ViewManager.ShowMessage("Error Attempting to Update Fire Service Casualty Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
			}
			else
			{
				if ( ViewModel.cboActivity.SelectedIndex == -1)
				{
					CasualtyCL.Activity = 0;
				}
				else
				{
					CasualtyCL.Activity = ViewModel.cboActivity.GetItemData(ViewModel.cboActivity.SelectedIndex);
				}
				if ( ViewModel.cboWhereOccured.SelectedIndex == -1)
				{
					CasualtyCL.WhereOccurred = 0;
				}
				else
				{
					CasualtyCL.WhereOccurred = ViewModel.cboWhereOccured.GetItemData(ViewModel.cboWhereOccured.SelectedIndex);
				}
				if ( ViewModel.cboInjuryCausedBy.SelectedIndex == -1)
				{
					CasualtyCL.InjuryCausedBy = 0;
				}
				else
				{
					CasualtyCL.InjuryCausedBy = ViewModel.cboInjuryCausedBy.GetItemData(ViewModel.cboInjuryCausedBy.SelectedIndex);
				}
				if ( ViewModel.cboInjurySeverity.SelectedIndex == -1)
				{
					CasualtyCL.InjurySeverity = 0;
				}
				else
				{
					CasualtyCL.InjurySeverity = ViewModel.cboInjurySeverity.GetItemData(ViewModel.cboInjurySeverity.SelectedIndex);
				}
				if ( ViewModel.cboBodyPart.SelectedIndex == -1)
				{
					CasualtyCL.BodyPartInjured = 0;
				}
				else
				{
					CasualtyCL.BodyPartInjured = ViewModel.cboBodyPart.GetItemData(ViewModel.cboBodyPart.SelectedIndex);
				}
				if ( ViewModel.cboInjuryType.SelectedIndex == -1)
				{
					CasualtyCL.InjuryType = 0;
				}
				else
				{
					CasualtyCL.InjuryType = ViewModel.cboInjuryType.GetItemData(ViewModel.cboInjuryType.SelectedIndex);
				}
				if ( ViewModel.cboLocationAtInjury.SelectedIndex == -1)
				{
					CasualtyCL.InjuryLocation = 0;
				}
				else
				{
					CasualtyCL.InjuryLocation = ViewModel.cboLocationAtInjury.GetItemData(ViewModel.cboLocationAtInjury.SelectedIndex);
				}
				if ( ViewModel.chkFPEProblem.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
				{
					CasualtyCL.FlagProtEquipCaused = 0;
				}
				else
				{
					CasualtyCL.FlagProtEquipCaused = 1;
				}
				CasualtyCL.DetailedNarrative = ViewModel.rtxNarrative.Text;
				CasualtyCL.RecommendationsForPrevention = ViewModel.rtxRecommend.Text;
				if (~CasualtyCL.UpdateFSCasualty() != 0)
				{
					result = 0;
					ViewManager.ShowMessage("Error Attempting to Update Fire Service Casualty Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.
						BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				}
				else
				{
					result = -1;
					UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
						{
							var ret =
									//------Contributing Factors
									CasualtyCL.DeleteFSCasualtyContributingFactor(ref p1);
							ViewModel.CurrReportID = p1;
							return ret;
						}, ViewModel.CurrReportID);
					CasualtyCL.FSCasualtyID = ViewModel.CurrReportID;
					for (int i = 0; i <= ViewModel.lstContributingFactors.Items.Count - 1; i++)
					{
						if ( ViewModel.lstContributingFactors.GetSelected( i))
						{
							CasualtyCL.FSCasualtyContributingFactor = ViewModel.lstContributingFactors.GetItemData(i);
							CasualtyCL.AddFSCasualtyContributingFactor();
						}
					}
					//----------Update Reportlog ----------------
					if (~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
							{
								var ret = ReportLog.UpdateStatus(ref p1, ViewModel.CurrReportID, UType);
								ViewModel.ReportLogID = p1;
								return ret;
							}, ViewModel.ReportLogID) != 0)
					{
						ViewManager.ShowMessage("Error Updating ReportLog Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					}
					else
					{
						if (~ReportLog.UpdateNFIRSLog(ViewModel.CurrIncident) != 0)
						{
							//Currently do nothing - odds are record is being edited before getting added
							//to the NFIRSLog table during nightly batch job
						}
					}
				}
			}

			return result;
		}

		private void LoadPPEList()
		{
			//Load Listbox with FSCasualtyFailedEquipment Records
			TFDIncident.clsCasualty Casualty = Container.Resolve< clsCasualty>();
			string sDisplay = "";
			ViewModel.cmdRemovePPE.Enabled = false;
			ViewModel.cmdEDITFPE.Enabled = false;
			ViewModel.lstPPE.Items.Clear();
			if (Casualty.GetFSCasualtyFailedEquipment(ViewModel.CurrReportID) != 0)
			{

				while(!Casualty.FSCasualtyFailedEquipment.EOF)
				{
					sDisplay = IncidentMain.Clean(Casualty.FSCasualtyFailedEquipment["equip_descrip"]) + " - ";
					sDisplay = sDisplay + IncidentMain.Clean(Casualty.FSCasualtyFailedEquipment["status_descrip"]) + " - ";
					sDisplay = sDisplay + IncidentMain.Clean(Casualty.FSCasualtyFailedEquipment["problem_descrip"]);
					ViewModel.lstPPE.AddItem(sDisplay);
					ViewModel.lstPPE.SetItemData(ViewModel.lstPPE.GetNewIndex(), Convert.ToInt32(Casualty.FSCasualtyFailedEquipment["FPE_failure_id"]));
					Casualty.FSCasualtyFailedEquipment.MoveNext();
				};
				ViewModel.cmdRemovePPE.Enabled = true;
				ViewModel.cmdEDITFPE.Enabled = true;
				ViewModel.chkFPEProblem.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
				ViewModel.chkFPEProblem.Enabled = false;
			}
			else
			{
				ViewModel.chkFPEProblem.Enabled = true;
			}

			CheckComplete();

		}

		private void LoadFSCasualty()
		{
			//Load List and combos for FS Casualty & FPE frames
			//Retrieve Existing record and display data
			TFDIncident.clsCasualty Casualty = Container.Resolve< clsCasualty>();
			TFDIncident.clsEMSCodes EMSCodes = Container.Resolve< clsEMSCodes>();
			TFDIncident.clsPersonnel PersonnelCL = Container.Resolve< clsPersonnel>();
			TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();
			ViewModel.DontRespond = -1;
			ViewModel.rtxNarrative.Text = "";
			ViewModel.rtxRecommend.Text = "";
			ViewModel.chkFPEProblem.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.cboActivity.Items.Clear();
			Casualty.GetActivityCode();

			while(!Casualty.ActivityCode.EOF)
			{
				ViewModel.cboActivity.AddItem(IncidentMain.Clean(Casualty.ActivityCode["description"]));
				ViewModel.cboActivity.SetItemData(ViewModel.cboActivity.GetNewIndex(), Convert.ToInt32(Casualty.ActivityCode["activity_code"]));
				Casualty.ActivityCode.MoveNext();
			}
			;
			ViewModel.cboWhereOccured.Items.Clear();
			Casualty.GetWhereOccuredCode();

			while(!Casualty.WhereOccuredCode.EOF)
			{
				ViewModel.cboWhereOccured.AddItem(IncidentMain.Clean(Casualty.WhereOccuredCode["description"]));
				ViewModel.cboWhereOccured.SetItemData(ViewModel.cboWhereOccured.GetNewIndex(), Convert.ToInt32(Casualty.WhereOccuredCode["where_occured_code"]));
				Casualty.WhereOccuredCode.MoveNext();
			}
			;
			ViewModel.cboInjuryCausedBy.Items.Clear();
			Casualty.GetInjuryCausedByCode();

			while(!Casualty.InjuryCausedByCode.EOF)
			{
				ViewModel.cboInjuryCausedBy.AddItem(IncidentMain.Clean(Casualty.InjuryCausedByCode["description"]));
				ViewModel.cboInjuryCausedBy.SetItemData(ViewModel.cboInjuryCausedBy.GetNewIndex(), Convert.ToInt32(Casualty.InjuryCausedByCode["injury_caused_by_code"]));
				Casualty.InjuryCausedByCode.MoveNext();
			}
			;
			ViewModel.cboLocationAtInjury.Items.Clear();
			Casualty.GetInjuryLocationCode();

			while(!Casualty.InjuryLocationCode.EOF)
			{
				ViewModel.cboLocationAtInjury.AddItem(IncidentMain.Clean(Casualty.InjuryLocationCode["description"]));
				ViewModel.cboLocationAtInjury.SetItemData(ViewModel.cboLocationAtInjury.GetNewIndex(), Convert.ToInt32(Casualty.InjuryLocationCode["injury_location_code"]));
				Casualty.InjuryLocationCode.MoveNext();
			}
			;
			ViewModel.cboInjurySeverity.Items.Clear();
			Casualty.GetInjurySeverity();

			while(!Casualty.InjurySeverityCode.EOF)
			{
				ViewModel.cboInjurySeverity.AddItem(IncidentMain.Clean(Casualty.InjurySeverityCode["description"]));
				ViewModel.cboInjurySeverity.SetItemData(ViewModel.cboInjurySeverity.GetNewIndex(), Convert.ToInt32(Casualty.InjurySeverityCode["injury_severity_code"]));
				Casualty.InjurySeverityCode.MoveNext();
			}
			;
			ViewModel.cboBodyPart.Items.Clear();
			EMSCodes.GetInjuryDetailCodesByType("B");

			while(!EMSCodes.InjuryDetailCodes.EOF)
			{
				ViewModel.cboBodyPart.AddItem(IncidentMain.Clean(EMSCodes.InjuryDetailCodes["description"]));
				ViewModel.cboBodyPart.SetItemData(ViewModel.cboBodyPart.GetNewIndex(), Convert.ToInt32(EMSCodes.InjuryDetailCodes["injury_detail_descriptor"]));
				EMSCodes.InjuryDetailCodes.MoveNext();
			}
			;
			ViewModel.cboInjuryType.Items.Clear();
			EMSCodes.GetInjuryDetailCodesByType("I");

			while(!EMSCodes.InjuryDetailCodes.EOF)
			{
				ViewModel.cboInjuryType.AddItem(IncidentMain.Clean(EMSCodes.InjuryDetailCodes["description"]));
				ViewModel.cboInjuryType.SetItemData(ViewModel.cboInjuryType.GetNewIndex(), Convert.ToInt32(EMSCodes.InjuryDetailCodes["injury_detail_descriptor"]));
				EMSCodes.InjuryDetailCodes.MoveNext();
			}
			;
			ViewModel.lstContributingFactors.Items.Clear();
			Casualty.GetFSCasualtyContributingFactorCode();

			while(!Casualty.FSCasualtyContributingFactorCode.EOF)
			{
				ViewModel.lstContributingFactors.AddItem(IncidentMain.Clean(Casualty.FSCasualtyContributingFactorCode["description"]));
				ViewModel.lstContributingFactors.SetItemData(ViewModel.lstContributingFactors.GetNewIndex(), Convert.ToInt32(Casualty.FSCasualtyContributingFactorCode["fs_casualty_contributing_factor_code"]));
				Casualty.FSCasualtyContributingFactorCode.MoveNext();
			}
			;
			ViewModel.cboFPEEquipment.Items.Clear();
			ViewModel.cboFPEStatus.Items.Clear();
			ViewModel.cboFPEProblem.Items.Clear();
			ViewModel.lstPPE.Items.Clear();
			ViewModel.cmdAddPPE.Enabled = false;
			ViewModel.cmdRemovePPE.Enabled = false;

			Casualty.GetFPECodeRS();

			while(!Casualty.FPECodeRS.EOF)
			{
				ViewModel.cboFPEEquipment.AddItem(IncidentMain.Clean(Casualty.FPECodeRS["Description"]));
				ViewModel.cboFPEEquipment.SetItemData(ViewModel.cboFPEEquipment.GetNewIndex(), Convert.ToInt32(Casualty.FPECodeRS["FPE_Code_ID"]));
				Casualty.FPECodeRS.MoveNext();
			}
			;

			//Retrieve Existing Record
			if (~Casualty.GetFSCasualty(ViewModel.CurrReportID) != 0)
			{
				ViewManager.ShowMessage("Error Attempting to Retrieve Fire Service Casualty Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.
					BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				return;
			}

			PersonnelCL.GetEmployeeRecord(Casualty.EmployeeID);
			ViewModel.lbEmployee.Text = IncidentMain.Clean(PersonnelCL.Employee["name_full"]);
			IncidentCL.GetIncident(Casualty.IncidentID);
			ViewModel.lbFSCasualtyIncident.Text = IncidentCL.IncidentNumber;
			ViewModel.lbCasualtyDate.Text = DateTime.Parse(Casualty.CasualtyDate).ToString("M/d/yyyy");

			for (int i = 0; i <= ViewModel.cboActivity.Items.Count - 1; i++)
			{
				if ( ViewModel.cboActivity.GetItemData(i) == Casualty.Activity)
				{
					ViewModel.cboActivity.SelectedIndex = i;
					break;
				}
			}
			for (int i = 0; i <= ViewModel.cboWhereOccured.Items.Count - 1; i++)
			{
				if ( ViewModel.cboWhereOccured.GetItemData(i) == Casualty.WhereOccurred)
				{
					ViewModel.cboWhereOccured.SelectedIndex = i;
					break;
				}
			}
			for (int i = 0; i <= ViewModel.cboInjuryCausedBy.Items.Count - 1; i++)
			{
				if ( ViewModel.cboInjuryCausedBy.GetItemData(i) == Casualty.InjuryCausedBy)
				{
					ViewModel.cboInjuryCausedBy.SelectedIndex = i;
					break;
				}
			}
			for (int i = 0; i <= ViewModel.cboLocationAtInjury.Items.Count - 1; i++)
			{
				if ( ViewModel.cboLocationAtInjury.GetItemData(i) == Casualty.InjuryLocation)
				{
					ViewModel.cboLocationAtInjury.SelectedIndex = i;
					break;
				}
			}
			for (int i = 0; i <= ViewModel.cboInjurySeverity.Items.Count - 1; i++)
			{
				if ( ViewModel.cboInjurySeverity.GetItemData(i) == Casualty.InjurySeverity)
				{
					ViewModel.cboInjurySeverity.SelectedIndex = i;
					break;
				}
			}
			for (int i = 0; i <= ViewModel.cboBodyPart.Items.Count - 1; i++)
			{
				if ( ViewModel.cboBodyPart.GetItemData(i) == Casualty.BodyPartInjured)
				{
					ViewModel.cboBodyPart.SelectedIndex = i;
					break;
				}
			}
			for (int i = 0; i <= ViewModel.cboInjuryType.Items.Count - 1; i++)
			{
				if ( ViewModel.cboInjuryType.GetItemData(i) == Casualty.InjuryType)
				{
					ViewModel.cboInjuryType.SelectedIndex = i;
					break;
				}
			}
			ViewModel.rtxNarrative.Text = Casualty.DetailedNarrative;
			ViewModel.rtxRecommend.Text = Casualty.RecommendationsForPrevention;
			if (Casualty.GetFSContribFactorRS(ViewModel.CurrReportID) != 0)
			{

				while(!Casualty.FSCasualtyContributingFactorRS.EOF)
				{
					for (int i = 0; i <= ViewModel.lstContributingFactors.Items.Count - 1; i++)
					{
						if ( ViewModel.lstContributingFactors.GetItemData(i) == Convert.ToDouble(Casualty.FSCasualtyContributingFactorRS["fs_casualty_contributing_factor_code"]))
						{
							UpgradeHelpers.Helpers.ListBoxHelper.SetSelected(ViewModel.lstContributingFactors, i, true);
							break;
						}
					}
					Casualty.FSCasualtyContributingFactorRS.MoveNext();
				};
			}
			ViewModel.DontRespond = 0;
			LoadPPEList();

		}

		private void LockScreen()
		{
			//Lock Current Screen for ReadOnly Access
			switch( ViewModel.CurrReport)
			{
				case IncidentMain.HAZCONDITION : case IncidentMain.SEARCHRESCUE : case IncidentMain.FALSEALARM :
					//UPGRADE_ISSUE: (2064) ComboBox property cboAllInfo1.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
					ViewModel.cboAllInfo1.setLocked(true);
					//UPGRADE_ISSUE: (2064) ComboBox property cboAllInfo2.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
					ViewModel.cboAllInfo2.setLocked(true);
					//UPGRADE_ISSUE: (2064) ComboBox property cboAllInfo3.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
					ViewModel.cboAllInfo3.setLocked(true);
					ViewModel.txtAllInfo1.Enabled = false;
					ViewModel.rtxFalseAlarmComment.Enabled = false;
					ViewModel.rtxAllNarration.Enabled = false;
					ViewModel.cmdAddNarration.Visible = false;

					break;
				case IncidentMain.INVESTIGATION : case IncidentMain.CLEANUP : case IncidentMain.STANDBY :
					//UPGRADE_ISSUE: (2064) ComboBox property cboServiceType.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
					ViewModel.cboServiceType.setLocked(true);
					ViewModel.txtStandbyHours.Enabled = false;
					ViewModel.txtNumberSafePlace.Enabled = true;
					ViewModel.rtxServiceNarration.Enabled = false;
					ViewModel.cmdServAddNarration.Visible = false;

					break;
				case IncidentMain.CIVILCASUALTY :
					ViewModel.chkEMR.Enabled = false;
					//UPGRADE_ISSUE: (2064) ComboBox property cboEMSPatient.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
					ViewModel.cboEMSPatient.setLocked(true);
					//UPGRADE_ISSUE: (2064) ComboBox property cboSeverity.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
					ViewModel.cboSeverity.setLocked(true);
					//UPGRADE_ISSUE: (2064) ComboBox property cboInjuryCause.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
					ViewModel.cboInjuryCause.setLocked(true);
					//UPGRADE_ISSUE: (2064) ComboBox property cboCCLocation.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
					ViewModel.cboCCLocation.setLocked(true);
					ViewModel.txtFloor.Enabled = false;
					ViewModel.lstContribFactors.Enabled = false;
					ViewModel.lstHumanContribFactors.Enabled = false;
					ViewModel.rtxCivilNarration.Enabled = false;
					ViewModel.cmdCivAddNarration.Visible = false;

					break;
			}
			ViewModel.cmdSave[0].Enabled = false;
			ViewModel.cmdSave[1].Enabled = false;
			ViewModel.cmdSave[0].Visible = false;
			ViewModel.cmdSave[1].Visible = false;

		}

		private void GetServiceInfo()
		{
			//Get Service Report Data
			TFDIncident.clsMiscReports ServiceCL = Container.Resolve< clsMiscReports>();
			TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();


			if (~ServiceCL.GetServiceReport(ViewModel.CurrIncident) != 0)
			{
				ViewManager.ShowMessage("New Service Report Entry", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK);
			}
			else
			{
				for (int i = 0; i <= ViewModel.cboServiceType.Items.Count - 1; i++)
				{
					if ( ViewModel.cboServiceType.GetItemData(i) == ServiceCL.ServiceType)
					{
						ViewModel.cboServiceType.SelectedIndex = i;
						if (ServiceCL.ServiceType == 63)
						{
							ViewModel.lbSafePlace.Visible = true;
							ViewModel.txtNumberSafePlace.Visible = true;
						}
						else
						{
							ViewModel.lbSafePlace.Visible = false;
							ViewModel.txtNumberSafePlace.Visible = false;
						}
						break;
					}
				}

				if ( ViewModel.CurrReport == IncidentMain.STANDBY)
				{
					ViewModel.txtStandbyHours.Text = ServiceCL.ServiceStandbyHours.ToString();
					ViewModel.txtNumberSafePlace.Text = ServiceCL.ServiceNumberSafeplace.ToString();
				}
			}


			//Narration
			LoadNarration(0);


		}

		private void GetAllInfoData()
		{
			//Get AllInfo Data
			TFDIncident.clsMiscReports AllInfo = Container.Resolve< clsMiscReports>();
			TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();

			switch( ViewModel.CurrReport)
			{
				case IncidentMain.HAZCONDITION :
					if (~AllInfo.GetHazardousCondition(ViewModel.CurrIncident) != 0)
					{
						ViewManager.ShowMessage("New Hazardous Condition Report Entry", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK);
					}
					else
					{
						for (int i = 0; i <= ViewModel.cboAllInfo1.Items.Count - 1; i++)
						{
							if ( ViewModel.cboAllInfo1.GetItemData(i) == AllInfo.HCIncidentType)
							{
								ViewModel.cboAllInfo1.SelectedIndex = i;
								break;
							}
						}
						for (int i = 0; i <= ViewModel.cboAllInfo2.Items.Count - 1; i++)
						{
							if ( ViewModel.cboAllInfo2.GetItemData(i) == AllInfo.HCPropertyTypeClass)
							{
								ViewModel.cboAllInfo2.SelectedIndex = i;
								break;
							}
						}
					}
					break;
				case IncidentMain.SEARCHRESCUE :
					if (~AllInfo.GetSearchRescue(ViewModel.CurrIncident) != 0)
					{
						ViewManager.ShowMessage("New Search/Rescue Report Entry", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK);

					}
					else
					{
						for (int i = 0; i <= ViewModel.cboAllInfo1.Items.Count - 1; i++)
						{
							if ( ViewModel.cboAllInfo1.GetItemData(i) == AllInfo.SRIncidentType)
							{
								ViewModel.cboAllInfo1.SelectedIndex = i;
								break;
							}
						}
						ViewModel.txtAllInfo1.Text = AllInfo.SRNumberRescued.ToString();
					}
					break;
				case IncidentMain.FALSEALARM :
					if (~AllInfo.GetFalseAlarm(ViewModel.CurrIncident) != 0)
					{
						ViewManager.ShowMessage("New False Alarm Report Entry", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK);

					}
					else
					{
						for (int i = 0; i <= ViewModel.cboAllInfo1.Items.Count - 1; i++)
						{
							if ( ViewModel.cboAllInfo1.GetItemData(i) == AllInfo.FAIncidentType)
							{
								ViewModel.cboAllInfo1.SelectedIndex = i;
								break;
							}
						}
						for (int i = 0; i <= ViewModel.cboAllInfo2.Items.Count - 1; i++)
						{
							if ( ViewModel.cboAllInfo2.GetItemData(i) == AllInfo.FAAlarmSentBy)
							{
								ViewModel.cboAllInfo2.SelectedIndex = i;
								break;
							}
						}
						for (int i = 0; i <= ViewModel.cboAllInfo3.Items.Count - 1; i++)
						{
							if ( ViewModel.cboAllInfo3.GetItemData(i) == AllInfo.FAMalfunctionDevice)
							{
								ViewModel.cboAllInfo3.SelectedIndex = i;
								break;
							}
						}
						ViewModel.rtxFalseAlarmComment.Text = AllInfo.FAComment;
					}
					break;
			}

			//Narration
			LoadNarration(0);

		}

		private int SaveServiceReport(int UpdateType)
		{
			//Create New Service Report Record
			//Update ReportLog
			int result = 0;
			TFDIncident.clsMiscReports ServiceReport = Container.Resolve< clsMiscReports>();
			TFDIncident.clsReportLog ReportLog = Container.Resolve< clsReportLog>();
			TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();

			//Save Narration - if any
			if ( ViewModel.NarrationUpdated != 0)
			{
				SaveNarration();
			}

			result = -1;
			ServiceReport.ServiceIncidentID = ViewModel.CurrIncident;
			if ( ViewModel.cboServiceType.SelectedIndex != -1)
			{
				ServiceReport.ServiceType = ViewModel.cboServiceType.GetItemData(ViewModel.cboServiceType.SelectedIndex);
			}
			else
			{
				ServiceReport.ServiceType = 0;
			}
			ServiceReport.ServiceStandbyHours = Convert.ToInt32(Conversion.Val(ViewModel.txtStandbyHours.Text));
			ServiceReport.ServiceNumberSafeplace = Convert.ToInt32(Conversion.Val(ViewModel.txtNumberSafePlace.Text));
			if (~ServiceReport.UpdateServiceReport() != 0)
			{
				result = 0;
			}
			else
			{
				//Update ReportLog
				if (~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
						{
							var ret = ReportLog.UpdateStatus(ref p1, ViewModel.CurrIncident, UpdateType);
							ViewModel.ReportLogID = p1;
							return ret;
						}, ViewModel.ReportLogID) != 0)
				{
					ViewManager.ShowMessage("Error Updating ReportLog", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					result = 0;
				}
				else
				{
					if (~ReportLog.UpdateNFIRSLog(ViewModel.CurrIncident) != 0)
					{
						//Currently do nothing - odds are record is being edited before getting added
						//to the NFIRSLog table during nightly batch job
					}
				}
			}

			return result;
		}

		private int SaveAllInfo(int UpdateType)
		{
			//Create New Service Report Record
			//Update ReportLog
			int result = 0;
			TFDIncident.clsMiscReports MiscReport = Container.Resolve< clsMiscReports>();
			TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();
			TFDIncident.clsReportLog ReportLog = Container.Resolve< clsReportLog>();

			result = -1;
			//Save Narration - if any
			if ( ViewModel.NarrationUpdated != 0)
			{
				SaveNarration();
			}

			switch( ViewModel.CurrReport)
			{
				case IncidentMain.HAZCONDITION :
					MiscReport.HCIncidentID = ViewModel.CurrIncident;
					if ( ViewModel.cboAllInfo1.SelectedIndex != -1)
					{
						MiscReport.HCIncidentType = ViewModel.cboAllInfo1.GetItemData(ViewModel.cboAllInfo1.SelectedIndex);
					}
					else
					{
						MiscReport.HCIncidentType = 0;
					}
					if ( ViewModel.cboAllInfo2.SelectedIndex != -1)
					{
						MiscReport.HCPropertyTypeClass = ViewModel.cboAllInfo2.GetItemData(ViewModel.cboAllInfo2.SelectedIndex);
					}
					else
					{
						MiscReport.HCPropertyTypeClass = 0;
					}
					if (~MiscReport.UpdateHazardousCondition() != 0)
					{
						result = 0;
					}
					else
					{
						//Update ReportLog
						if (~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
								{
									var ret = ReportLog.UpdateStatus(ref p1, ViewModel.CurrIncident, UpdateType);
									ViewModel.ReportLogID = p1;
									return ret;
								}, ViewModel.ReportLogID) != 0)
						{
							ViewManager.ShowMessage("Error Updating ReportLog", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							result = 0;
						}
						else
						{
							if (~ReportLog.UpdateNFIRSLog(ViewModel.CurrIncident) != 0)
							{
								//Currently do nothing - odds are record is being edited before getting added
								//to the NFIRSLog table during nightly batch job
							}
						}
					}
					break;
				case IncidentMain.SEARCHRESCUE :
					MiscReport.SRIncidentID = ViewModel.CurrIncident;
					if ( ViewModel.cboAllInfo1.SelectedIndex != -1)
					{
						MiscReport.SRIncidentType = ViewModel.cboAllInfo1.GetItemData(ViewModel.cboAllInfo1.SelectedIndex);
					}
					else
					{
						MiscReport.SRIncidentType = 0;
					}
					MiscReport.SRNumberRescued = Convert.ToInt32(Conversion.Val(ViewModel.txtAllInfo1.Text));
					if (~MiscReport.UpdateSearchRescue() != 0)
					{
						result = 0;
					}
					else
					{
						//Update ReportLog
						if (~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
								{
									var ret = ReportLog.UpdateStatus(ref p1, ViewModel.CurrIncident, UpdateType);
									ViewModel.ReportLogID = p1;
									return ret;
								}, ViewModel.ReportLogID) != 0)
						{
							ViewManager.ShowMessage("Error Updating ReportLog", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							result = 0;
						}
					}
					break;
				case IncidentMain.FALSEALARM :
					MiscReport.FAIncidentID = ViewModel.CurrIncident;
					if ( ViewModel.cboAllInfo1.SelectedIndex != -1)
					{
						MiscReport.FAIncidentType = ViewModel.cboAllInfo1.GetItemData(ViewModel.cboAllInfo1.SelectedIndex);
					}
					else
					{
						MiscReport.FAIncidentType = 0;
					}
					if ( ViewModel.cboAllInfo2.SelectedIndex != -1)
					{
						MiscReport.FAAlarmSentBy = ViewModel.cboAllInfo2.GetItemData(ViewModel.cboAllInfo2.SelectedIndex);
					}
					else
					{
						MiscReport.FAAlarmSentBy = 0;
					}
					if ( ViewModel.cboAllInfo3.SelectedIndex != -1)
					{
						MiscReport.FAMalfunctionDevice = ViewModel.cboAllInfo3.GetItemData(ViewModel.cboAllInfo3.SelectedIndex);
					}
					else
					{
						MiscReport.FAMalfunctionDevice = 0;
					}
					MiscReport.FAComment = ViewModel.rtxFalseAlarmComment.Text;
					if (~MiscReport.UpdateFalseAlarm() != 0)
					{
						result = 0;
					}
					else
					{
						//Update ReportLog
						if (~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
								{
									var ret = ReportLog.UpdateStatus(ref p1, ViewModel.CurrIncident, UpdateType);
									ViewModel.ReportLogID = p1;
									return ret;
								}, ViewModel.ReportLogID) != 0)
						{
							ViewManager.ShowMessage("Error Updating ReportLog", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							result = 0;
						}
						else
						{
							if (~ReportLog.UpdateNFIRSLog(ViewModel.CurrIncident) != 0)
							{
								//Currently do nothing - odds are record is being edited before getting added
								//to the NFIRSLog table during nightly batch job
							}
						}
					}
					break;
			}


			return result;
		}


		private int SaveCivilianCasualty(int UpdateType)
		{
			//Save Civilian Casualty Report Record
			//Update ReportLog
			int result = 0;
			TFDIncident.clsCasualty Casualty = Container.Resolve< clsCasualty>();
			TFDIncident.clsReportLog ReportLog = Container.Resolve< clsReportLog>();
			TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();

			//Save Narration - if any
			if ( ViewModel.NarrationUpdated != 0)
			{
				SaveNarration();
			}

			result = -1;

			Casualty.CivIncidentID = ViewModel.CurrIncident;
			if ( ViewModel.cboEMSPatient.SelectedIndex != -1)
			{
				Casualty.CivPatientID = ViewModel.cboEMSPatient.GetItemData(ViewModel.cboEMSPatient.SelectedIndex);
			}
			else
			{
				Casualty.CivPatientID = 0;
			}

			if ( ViewModel.cboSeverity.SelectedIndex != -1)
			{
				Casualty.CivInjurySeverity = ViewModel.cboSeverity.GetItemData(ViewModel.cboSeverity.SelectedIndex);
			}
			else
			{
				Casualty.CivInjurySeverity = 0;
			}

			if ( ViewModel.cboInjuryCause.SelectedIndex != -1)
			{
				Casualty.CivInjuryCausedBy = ViewModel.cboInjuryCause.GetItemData(ViewModel.cboInjuryCause.SelectedIndex);
			}
			else
			{
				Casualty.CivInjuryCausedBy = 0;
			}

			if ( ViewModel.cboCCLocation.SelectedIndex != -1)
			{
				Casualty.CivInjuryLocation = ViewModel.cboCCLocation.GetItemData(ViewModel.cboCCLocation.SelectedIndex);
			}
			else
			{
				Casualty.CivInjuryLocation = 0;
			}
			Casualty.CivInjuryFloor = Convert.ToInt32(Conversion.Val(ViewModel.txtFloor.Text));

			if ( ViewModel.CurrReportID == 0)
			{
				if (~Casualty.AddCivilianCasualty() != 0)
				{
					return 0;
				}
				else
				{
					ViewModel.CurrReportID = Casualty.CivCasualtyID;
				}
			}
			else
			{
				Casualty.CivCasualtyID = ViewModel.CurrReportID;
				if (~Casualty.UpdateCivilianCasualty() != 0)
				{
					return 0;
				}
			}
			//Save Sub Tables
			int tempRefParam = Casualty.CivCasualtyID;
			Casualty.DeleteCivContributingFactor(ref tempRefParam);
			Casualty.CFCasualtyID = Casualty.CivCasualtyID;
			for (int i = 0; i <= ViewModel.lstContribFactors.Items.Count - 1; i++)
			{
				if ( ViewModel.lstContribFactors.GetSelected( i))
				{
					Casualty.CFContributingFactor = ViewModel.lstContribFactors.GetItemData(i);
					Casualty.AddCivContributingFactor();
				}
			}

			int tempRefParam2 = Casualty.CivCasualtyID;
			Casualty.DeleteCivHumanFactor(ref tempRefParam2);
			Casualty.CHCasualtyID = Casualty.CivCasualtyID;
			for (int i = 0; i <= ViewModel.lstHumanContribFactors.Items.Count - 1; i++)
			{
				if ( ViewModel.lstHumanContribFactors.GetSelected( i))
				{
					Casualty.CHHumanFactor = ViewModel.lstHumanContribFactors.GetItemData(i);
					Casualty.AddCivHumanFactor();
				}
			}

			//Update ReportLog
			if (~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
					{
						var ret = ReportLog.UpdateStatus(ref p1, Casualty.CivCasualtyID, UpdateType);
						ViewModel.ReportLogID = p1;
						return ret;
					}, ViewModel.ReportLogID) != 0)
			{
				ViewManager.ShowMessage("Error Updating ReportLog", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				result = 0;
			}
			else
			{
				if (~ReportLog.UpdateNFIRSLog(ViewModel.CurrIncident) != 0)
				{
					//Currently do nothing - odds are record is being edited before getting added
					//to the NFIRSLog table during nightly batch job
				}
			}

			return result;
		}

		private void CheckComplete()
		{
			//Check Entry Screens for SaveComplete or SaveIncomplete for ReportStatus frame

			int ReportComplete = -1;
			switch( ViewModel.CurrReport)
			{
				case IncidentMain.INVESTIGATION : case IncidentMain.CLEANUP :
					if ( ViewModel.cboServiceType.SelectedIndex == -1)
					{
						ViewModel.cboServiceType.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.cboServiceType.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ReportComplete = 0;
					}
					else
					{
						ViewModel.cboServiceType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboServiceType.ForeColor = IncidentMain.Shared.SERVICEFONT;
					}
					break;
				case IncidentMain.STANDBY :
					if ( ViewModel.cboServiceType.SelectedIndex == -1)
					{
						ViewModel.cboServiceType.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.cboServiceType.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ReportComplete = 0;
					}
					else
					{
						ViewModel.cboServiceType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboServiceType.ForeColor = IncidentMain.Shared.SERVICEFONT;
					}
					double dbNumericTemp = 0;
					if ( ViewModel.txtStandbyHours.Text == "")
					{
						ViewModel.txtStandbyHours.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.txtStandbyHours.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ReportComplete = 0;
					}
					else if (!Double.TryParse(ViewModel.txtStandbyHours.Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
					{
						ViewModel.txtStandbyHours.Text = "";
						ViewModel.txtStandbyHours.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.txtStandbyHours.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ReportComplete = 0;
					}
					else
					{
						ViewModel.txtStandbyHours.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.txtStandbyHours.ForeColor = IncidentMain.Shared.SERVICEFONT;
					}
					if ( ViewModel.txtNumberSafePlace.Visible)
					{
						double dbNumericTemp2 = 0;
						if ( ViewModel.txtNumberSafePlace.Text == "")
						{
							ViewModel.txtNumberSafePlace.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.txtNumberSafePlace.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ReportComplete = 0;
						}
						else if (!Double.TryParse(ViewModel.txtNumberSafePlace.Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp2))
						{
							ViewModel.txtNumberSafePlace.Text = "";
							ViewModel.txtNumberSafePlace.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.txtNumberSafePlace.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ReportComplete = 0;
						}
						else
						{
							ViewModel.txtNumberSafePlace.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.txtNumberSafePlace.ForeColor = IncidentMain.Shared.SERVICEFONT;
						}
					}
					break;
				case IncidentMain.HAZCONDITION :
					if ( ViewModel.cboAllInfo1.SelectedIndex == -1)
					{
						ViewModel.cboAllInfo1.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.cboAllInfo1.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ReportComplete = 0;
					}
					else
					{
						ViewModel.cboAllInfo1.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboAllInfo1.ForeColor = IncidentMain.Shared.FIREFONT;
					}
					if ( ViewModel.cboAllInfo2.SelectedIndex == -1)
					{
						ViewModel.cboAllInfo2.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.cboAllInfo2.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ReportComplete = 0;
					}
					else
					{
						ViewModel.cboAllInfo2.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboAllInfo2.ForeColor = IncidentMain.Shared.FIREFONT;
					}
					// COME BACK TO HERE TO FIX FALSEALARM 
					break;
				case IncidentMain.SEARCHRESCUE :
					if ( ViewModel.cboAllInfo1.SelectedIndex == -1)
					{
						ViewModel.cboAllInfo1.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.cboAllInfo1.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ReportComplete = 0;
					}
					else
					{
						ViewModel.cboAllInfo1.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboAllInfo1.ForeColor = IncidentMain.Shared.FIREFONT;
					}

					break;
				case IncidentMain.FALSEALARM :
					if ( ViewModel.cboAllInfo1.SelectedIndex == -1)
					{
						ViewModel.cboAllInfo1.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.cboAllInfo1.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ReportComplete = 0;
					}
					else
					{
						ViewModel.cboAllInfo1.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboAllInfo1.ForeColor = IncidentMain.Shared.EMSFONT;
					}
					if ( ViewModel.cboAllInfo2.SelectedIndex == -1)
					{
						ViewModel.cboAllInfo2.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.cboAllInfo2.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ReportComplete = 0;
					}
					else
					{
						ViewModel.cboAllInfo2.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboAllInfo2.ForeColor = IncidentMain.Shared.EMSFONT;
					}
					if ( ViewModel.cboAllInfo3.SelectedIndex == -1)
					{
						ViewModel.cboAllInfo3.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.cboAllInfo3.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ReportComplete = 0;
					}
					else
					{
						ViewModel.cboAllInfo3.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboAllInfo3.ForeColor = IncidentMain.Shared.EMSFONT;
					}

					break;
				//UPGRADE_NOTE: (7001) The following case (switch) seems to be dead code More Information: http://www.vbtonet.com/ewis/ewi7001.aspx
				//case IncidentMain.INVESTIGATION : 
					//break;
				//UPGRADE_NOTE: (7001) The following case (switch) seems to be dead code More Information: http://www.vbtonet.com/ewis/ewi7001.aspx
				//case IncidentMain.CLEANUP : 
					//break;
				//UPGRADE_NOTE: (7001) The following case (switch) seems to be dead code More Information: http://www.vbtonet.com/ewis/ewi7001.aspx
				//case IncidentMain.STANDBY : 
					//if (cboServiceType.SelectedIndex == -1)
					//{
						//cboServiceType.BackColor = IncidentMain.REQCOLOR;
						//cboServiceType.ForeColor = ColorTranslator.FromOle(IncidentMain.WHITE);
						//ReportComplete = 0;
					//}
					//else
					//{
						//cboServiceType.BackColor = ColorTranslator.FromOle(IncidentMain.WHITE);
						//cboServiceType.ForeColor = IncidentMain.SERVICEFONT;
					//} 
					// 
					//break;
				case IncidentMain.FSCASUALTY :
					if ( ViewModel.cboActivity.SelectedIndex == -1)
					{
						ViewModel.cboActivity.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.cboActivity.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ReportComplete = 0;
					}
					else
					{
						ViewModel.cboActivity.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboActivity.ForeColor = IncidentMain.Shared.FSCASUALTYFONT;
					}
					if ( ViewModel.cboWhereOccured.SelectedIndex == -1)
					{
						ViewModel.cboWhereOccured.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.cboWhereOccured.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ReportComplete = 0;
					}
					else
					{
						ViewModel.cboWhereOccured.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboWhereOccured.ForeColor = IncidentMain.Shared.FSCASUALTYFONT;
					}
					if ( ViewModel.cboInjuryCausedBy.SelectedIndex == -1)
					{
						ViewModel.cboInjuryCausedBy.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.cboInjuryCausedBy.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ReportComplete = 0;
					}
					else
					{
						ViewModel.cboInjuryCausedBy.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboInjuryCausedBy.ForeColor = IncidentMain.Shared.FSCASUALTYFONT;
					}
					if ( ViewModel.cboLocationAtInjury.SelectedIndex == -1)
					{
						ViewModel.cboLocationAtInjury.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.cboLocationAtInjury.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ReportComplete = 0;
					}
					else
					{
						ViewModel.cboLocationAtInjury.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboLocationAtInjury.ForeColor = IncidentMain.Shared.FSCASUALTYFONT;
					}
					if ( ViewModel.cboInjurySeverity.SelectedIndex == -1)
					{
						ViewModel.cboInjurySeverity.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.cboInjurySeverity.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ReportComplete = 0;
					}
					else
					{
						ViewModel.cboInjurySeverity.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboInjurySeverity.ForeColor = IncidentMain.Shared.FSCASUALTYFONT;
					}
					if ( ViewModel.PPEFlag != 0)
					{
						if ( ViewModel.lstPPE.Items.Count == 0)
						{
							ViewModel.cboFPEEquipment.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.cboFPEEquipment.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.cboFPEStatus.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.cboFPEStatus.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.cboFPEProblem.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.cboFPEProblem.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.cmdRemovePPE.Enabled = false;
							ReportComplete = 0;
						}
						else
						{
							ViewModel.cboFPEEquipment.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.cboFPEEquipment.ForeColor = IncidentMain.Shared.FSCASUALTYFONT;
							ViewModel.cboFPEStatus.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.cboFPEStatus.ForeColor = IncidentMain.Shared.FSCASUALTYFONT;
							ViewModel.cboFPEProblem.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.cboFPEProblem.ForeColor = IncidentMain.Shared.FSCASUALTYFONT;
							ViewModel.cmdRemovePPE.Enabled = true;
						}
					}

					break;
				case IncidentMain.CIVILCASUALTY :
					if ( ViewModel.chkEMR.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
					{
						ViewModel.chkEMR.BackColor = IncidentMain.Shared.CIVCSTYCOLOR;
						ViewModel.chkEMR.ForeColor = IncidentMain.Shared.CIVCSTYFONT;
						ViewModel.cboEMSPatient.Enabled = true;
						if ( ViewModel.cboEMSPatient.SelectedIndex == -1)
						{
							ViewModel.cboEMSPatient.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.cboEMSPatient.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ReportComplete = 0;
						}
						else
						{
							ViewModel.cboEMSPatient.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.cboEMSPatient.ForeColor = IncidentMain.Shared.BLACK;
						}
					}
					else
					{
						ViewModel.chkEMR.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.chkEMR.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboEMSPatient.Enabled = false;
						ReportComplete = 0;
					}
					if ( ViewModel.cboSeverity.SelectedIndex == -1)
					{
						ViewModel.cboSeverity.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.cboSeverity.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ReportComplete = 0;
					}
					else
					{
						ViewModel.cboSeverity.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboSeverity.ForeColor = IncidentMain.Shared.BLACK;
					}
					break;
			}
			ViewModel.cmdSave[0].Enabled = ReportComplete != 0;


		}


		private void LoadCivilianCasualty()
		{
			//Load list and combo boxes for Civilian Casualty frame
			TFDIncident.clsCasualty Casualty = Container.Resolve< clsCasualty>();
			TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();
			TFDIncident.clsEMS EMSReport = Container.Resolve< clsEMS>();
			string ListDisplay = "";
			ViewModel.cboEMSPatient.Items.Clear();
			if (EMSReport.GetIncidentEMSPatients(ViewModel.CurrIncident) != 0)
			{

				while(!EMSReport.IncidentEMSPatients.EOF)
				{
					ListDisplay = IncidentMain.Clean(EMSReport.IncidentEMSPatients["name_last"]) + ", " + IncidentMain.Clean(EMSReport.IncidentEMSPatients["name_first"]);
					if (ListDisplay == ", ")
					{
						ListDisplay = "No Patient Name Available";
					}
					ViewModel.cboEMSPatient.AddItem(ListDisplay);
					ViewModel.cboEMSPatient.SetItemData(ViewModel.cboEMSPatient.GetNewIndex(), Convert.ToInt32(EMSReport.IncidentEMSPatients["pat_id"]));
					EMSReport.IncidentEMSPatients.MoveNext();
				};
			}
			ViewModel.cboSeverity.Items.Clear();
			Casualty.GetInjurySeverity();

			while(!Casualty.InjurySeverityCode.EOF)
			{
				ViewModel.cboSeverity.AddItem(IncidentMain.Clean(Casualty.InjurySeverityCode["description"]));
				ViewModel.cboSeverity.SetItemData(ViewModel.cboSeverity.GetNewIndex(), Convert.ToInt32(Casualty.InjurySeverityCode["injury_severity_code"]));
				Casualty.InjurySeverityCode.MoveNext();
			}
			;
			ViewModel.cboInjuryCause.Items.Clear();
			Casualty.GetInjuryCausedByCode();

			while(!Casualty.InjuryCausedByCode.EOF)
			{
				ViewModel.cboInjuryCause.AddItem(IncidentMain.Clean(Casualty.InjuryCausedByCode["description"]));
				ViewModel.cboInjuryCause.SetItemData(ViewModel.cboInjuryCause.GetNewIndex(), Convert.ToInt32(Casualty.InjuryCausedByCode["injury_caused_by_code"]));
				Casualty.InjuryCausedByCode.MoveNext();
			}
			;
			ViewModel.cboCCLocation.Items.Clear();
			Casualty.GetInjuryLocationCode();

			while(!Casualty.InjuryLocationCode.EOF)
			{
				ViewModel.cboCCLocation.AddItem(IncidentMain.Clean(Casualty.InjuryLocationCode["description"]));
				ViewModel.cboCCLocation.SetItemData(ViewModel.cboCCLocation.GetNewIndex(), Convert.ToInt32(Casualty.InjuryLocationCode["injury_location_code"]));
				Casualty.InjuryLocationCode.MoveNext();
			}
			;
			ViewModel.lstHumanContribFactors.Items.Clear();
			Casualty.GetCivilianHumanFactorCode();

			while(!Casualty.CivilianHumanFactorCode.EOF)
			{
				ViewModel.lstHumanContribFactors.AddItem(IncidentMain.Clean(Casualty.CivilianHumanFactorCode["description"]));
				ViewModel.lstHumanContribFactors.SetItemData(ViewModel.lstHumanContribFactors.GetNewIndex(), Convert.ToInt32(Casualty.CivilianHumanFactorCode["civilian_human_factor_code"]));
				Casualty.CivilianHumanFactorCode.MoveNext();
			}
			;
			ViewModel.lstContribFactors.Items.Clear();
			Casualty.GetCasualtyContributingFactorCode();

			while(!Casualty.CasualtyContributingFactorCode.EOF)
			{
				ViewModel.lstContribFactors.AddItem(IncidentMain.Clean(Casualty.CasualtyContributingFactorCode["description"]));
				ViewModel.lstContribFactors.SetItemData(ViewModel.lstContribFactors.GetNewIndex(), Convert.ToInt32(Casualty.CasualtyContributingFactorCode["casualty_contributing_factor_code"]));
				Casualty.CasualtyContributingFactorCode.MoveNext();
			}
			;


			if (~Casualty.GetCivilianCasualty(ViewModel.CurrReportID) != 0)
			{
				ViewManager.ShowMessage("New Civilian Casualty Report Entry", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK);
			}
			else
			{
				ViewModel.chkEMR.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
				if (Casualty.CivPatientID != 0)
				{
					for (int i = 0; i <= ViewModel.cboEMSPatient.Items.Count - 1; i++)
					{
						if ( ViewModel.cboEMSPatient.GetItemData(i) == Casualty.CivPatientID)
						{
							ViewModel.cboEMSPatient.SelectedIndex = i;
							ViewModel.chkEMR.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
							break;
						}
					}
				}
				for (int i = 0; i <= ViewModel.cboSeverity.Items.Count - 1; i++)
				{
					if ( ViewModel.cboSeverity.GetItemData(i) == Casualty.CivInjurySeverity)
					{
						ViewModel.cboSeverity.SelectedIndex = i;
						break;
					}
				}
				for (int i = 0; i <= ViewModel.cboInjuryCause.Items.Count - 1; i++)
				{
					if ( ViewModel.cboInjuryCause.GetItemData(i) == Casualty.CivInjuryCausedBy)
					{
						ViewModel.cboInjuryCause.SelectedIndex = i;
						break;
					}
				}
				for (int i = 0; i <= ViewModel.cboCCLocation.Items.Count - 1; i++)
				{
					if ( ViewModel.cboCCLocation.GetItemData(i) == Casualty.CivInjuryLocation)
					{
						ViewModel.cboCCLocation.SelectedIndex = i;
						break;
					}
				}
				ViewModel.txtFloor.Text = Casualty.CivInjuryFloor.ToString();

				//Contributing factors
				if (Casualty.GetCivContribFactor(ViewModel.CurrReportID) != 0)
				{

					while(!Casualty.CFCivilContribFactor.EOF)
					{
						for (int i = 0; i <= ViewModel.lstContribFactors.Items.Count - 1; i++)
						{
							if ( ViewModel.lstContribFactors.GetItemData(i) == Convert.ToDouble(Casualty.CFCivilContribFactor["casualty_contributing_factor_code"]))
							{
								UpgradeHelpers.Helpers.ListBoxHelper.SetSelected(ViewModel.lstContribFactors, i, true);
								break;
							}
						}
						Casualty.CFCivilContribFactor.MoveNext();
					};
				}

				//Human Factors
				if (Casualty.GetCivHumanFactor(ViewModel.CurrReportID) != 0)
				{

					while(!Casualty.CHCivilHumanFactor.EOF)
					{
						for (int i = 0; i <= ViewModel.lstHumanContribFactors.Items.Count - 1; i++)
						{
							if ( ViewModel.lstHumanContribFactors.GetItemData(i) == Convert.ToDouble(Casualty.CHCivilHumanFactor["civilian_human_factor_code"]))
							{
								UpgradeHelpers.Helpers.ListBoxHelper.SetSelected(ViewModel.lstHumanContribFactors, i, true);
								break;
							}
						}
						Casualty.CHCivilHumanFactor.MoveNext();
					};
				}
			}

			//Narration
			LoadNarration(0);

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboActivity_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.DontRespond != 0)
			{
				return;
			}
			CheckComplete();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboAllInfo1_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboAllInfo2_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboAllInfo3_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboCCLocation_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboCivNarrList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Retrieve Selected Narration
			if ( ViewModel.cboCivNarrList.SelectedIndex == -1)
			{
				return;
			}
			if ( ViewModel.FirstTime != 0)
			{
				return;
			}
			TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();
			TFDIncident.clsPersonnel PersonnelCL = Container.Resolve< clsPersonnel>();

			if ( ViewModel.NarrationUpdated != 0)
			{
				SaveNarration();
			}
			ViewModel.rtxCivilNarration.Text = "";
			ViewModel.lbCivilNarrID.Text = "";
			ViewModel.lbCCAuthor.Text = "";
			int NarrID = ViewModel.cboCivNarrList.GetItemData(ViewModel.cboCivNarrList.SelectedIndex);

			if (IncidentCL.GetNarration(NarrID) != 0)
			{
				ViewModel.lbCivilNarrID.Text = IncidentCL.NarrationID.ToString();
				if (PersonnelCL.GetEmployeeRecord(IncidentMain.Clean(IncidentCL.NarrationBy)) != 0)
				{
					ViewModel.lbCCAuthor.Text = IncidentMain.Clean(PersonnelCL.Employee["name_full"]);
				}
				ViewModel.rtxCivilNarration.Text = IncidentMain.Clean(IncidentCL.NarrationText);
				ViewModel.rtxCivilNarration.Enabled = !(IncidentCL.NarrationBy != IncidentMain.Shared.gCurrUser);
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboEMSPatient_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboFPEEquipment_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.DontRespond != 0)
			{
				return;
			}
			TFDIncident.clsCasualty Casualty = Container.Resolve< clsCasualty>();

			//if EquipmentSelected then Load Status and Problem Lists
			if ( ViewModel.cboFPEEquipment.SelectedIndex != -1)
			{
				ViewModel.DontRespond = -1;
				ViewModel.cboFPEStatus.Items.Clear();
				ViewModel.cboFPEProblem.Items.Clear();
				Casualty.GetFPEStatusByCode(ViewModel.cboFPEEquipment.GetItemData(ViewModel.cboFPEEquipment.SelectedIndex));

				while(!Casualty.FPEStatusCode.EOF)
				{
					ViewModel.cboFPEStatus.AddItem(IncidentMain.Clean(Casualty.FPEStatusCode["Description"]));
					ViewModel.cboFPEStatus.SetItemData(ViewModel.cboFPEStatus.GetNewIndex(), Convert.ToInt32(Casualty.FPEStatusCode["fpe_status_code"]));
					Casualty.FPEStatusCode.MoveNext();
				}
				;
				Casualty.GetFPEProblemByCode(ViewModel.cboFPEEquipment.GetItemData(ViewModel.cboFPEEquipment.SelectedIndex));

				while(!Casualty.FPEProblemCode.EOF)
				{
					ViewModel.cboFPEProblem.AddItem(IncidentMain.Clean(Casualty.FPEProblemCode["Description"]));
					ViewModel.cboFPEProblem.SetItemData(ViewModel.cboFPEProblem.GetNewIndex(), Convert.ToInt32(Casualty.FPEProblemCode["fpe_problem_code"]));
					Casualty.FPEProblemCode.MoveNext();
				}
				;
				ViewModel.DontRespond = 0;
			}
			ViewModel.cmdAddPPE.Enabled = false;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboFPEProblem_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.DontRespond != 0)
			{
				return;
			}
			//Check for Selections to Enable Add Button
			if ( ViewModel.cboFPEEquipment.SelectedIndex != -1)
			{
				if ( ViewModel.cboFPEStatus.SelectedIndex != -1)
				{
					ViewModel.cmdAddPPE.Enabled = ViewModel.cboFPEProblem.SelectedIndex != -1;
				}
				else
				{
					ViewModel.cmdAddPPE.Enabled = false;
				}
			}
			else
			{
				ViewModel.cmdAddPPE.Enabled = false;
			}


		}

		[UpgradeHelpers.Events.Handler]
		internal void cboFPEStatus_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.DontRespond != 0)
			{
				return;
			}
			//Check for Selections to Enable Add Button
			if ( ViewModel.cboFPEEquipment.SelectedIndex != -1)
			{
				if ( ViewModel.cboFPEStatus.SelectedIndex != -1)
				{
					ViewModel.cmdAddPPE.Enabled = ViewModel.cboFPEProblem.SelectedIndex != -1;
				}
				else
				{
					ViewModel.cmdAddPPE.Enabled = false;
				}
			}
			else
			{
				ViewModel.cmdAddPPE.Enabled = false;
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboInjuryCause_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboInjuryCausedBy_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.DontRespond != 0)
			{
				return;
			}
			CheckComplete();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboInjurySeverity_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.DontRespond != 0)
			{
				return;
			}
			CheckComplete();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboLocationAtInjury_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.DontRespond != 0)
			{
				return;
			}
			CheckComplete();

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
			TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();
			TFDIncident.clsPersonnel PersonnelCL = Container.Resolve< clsPersonnel>();

			if ( ViewModel.NarrationUpdated != 0)
			{
				SaveNarration();
			}
			ViewModel.rtxAllNarration.Text = "";
			ViewModel.lbAllNarrID.Text = "";
			ViewModel.lbAllNarrAuthor.Text = "";
			int NarrID = ViewModel.cboNarrList.GetItemData(ViewModel.cboNarrList.SelectedIndex);

			if (IncidentCL.GetNarration(NarrID) != 0)
			{
				ViewModel.lbAllNarrID.Text = IncidentCL.NarrationID.ToString();
				if (PersonnelCL.GetEmployeeRecord(IncidentMain.Clean(IncidentCL.NarrationBy)) != 0)
				{
					ViewModel.lbAllNarrAuthor.Text = IncidentMain.Clean(PersonnelCL.Employee["name_full"]);
				}
				ViewModel.rtxAllNarration.Text = IncidentMain.Clean(IncidentCL.NarrationText);
				ViewModel.rtxAllNarration.Enabled = !(IncidentCL.NarrationBy != IncidentMain.Shared.gCurrUser);
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboServiceNarrList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Retrieve Selected Narration
			if ( ViewModel.cboServiceNarrList.SelectedIndex == -1)
			{
				return;
			}
			if ( ViewModel.FirstTime != 0)
			{
				return;
			}
			TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();
			TFDIncident.clsPersonnel PersonnelCL = Container.Resolve< clsPersonnel>();

			if ( ViewModel.NarrationUpdated != 0)
			{
				SaveNarration();
			}
			ViewModel.rtxServiceNarration.Text = "";
			ViewModel.lbServiceNarrID.Text = "";
			ViewModel.lbServNarrAuthor.Text = "";
			int NarrID = ViewModel.cboServiceNarrList.GetItemData(ViewModel.cboServiceNarrList.SelectedIndex);

			if (IncidentCL.GetNarration(NarrID) != 0)
			{
				ViewModel.lbServiceNarrID.Text = IncidentCL.NarrationID.ToString();
				if (PersonnelCL.GetEmployeeRecord(IncidentMain.Clean(IncidentCL.NarrationBy)) != 0)
				{
					ViewModel.lbServNarrAuthor.Text = IncidentMain.Clean(PersonnelCL.Employee["name_full"]);
				}
				ViewModel.rtxServiceNarration.Text = IncidentMain.Clean(IncidentCL.NarrationText);
				ViewModel.rtxServiceNarration.Enabled = !(IncidentCL.NarrationBy != IncidentMain.Shared.gCurrUser);
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboServiceType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboServiceType.GetItemData(ViewModel.cboServiceType.SelectedIndex) == 63)
			{
				ViewModel.lbSafePlace.Visible = true;
				ViewModel.txtNumberSafePlace.Visible = true;
			}
			else
			{
				ViewModel.lbSafePlace.Visible = false;
				ViewModel.txtNumberSafePlace.Visible = false;
			}

			CheckComplete();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboSeverity_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboWhereOccured_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.DontRespond != 0)
			{
				return;
			}
			CheckComplete();

		}

		[UpgradeHelpers.Events.Handler]
		internal void chkEMR_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();

		}

		[UpgradeHelpers.Events.Handler]
		internal void chkFPEProblem_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.DontRespond != 0)
			{
				return;
			}

			if ( ViewModel.chkFPEProblem.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				ViewModel.PPEFlag = -1;
				ViewModel.cmdEDITFPE.Enabled = true;
			}
			else
			{
				ViewModel.PPEFlag = 0;
			}
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
					ViewModel.lbAllNarrID.Text = "";
					ViewModel.lbAllNarrAuthor.Text = IncidentMain.Shared.gCurrUserName;
					ViewModel.rtxAllNarration.Text = "";
					ViewModel.rtxAllNarration.Enabled = true;
					ViewManager.SetCurrent(ViewModel.rtxAllNarration);
					ViewModel.cmdAddNarration.Tag = "2";
					ViewModel.cmdAddNarration.Text = "Save New Narration";
					ViewModel.NarrationUpdated = 0;
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
		internal void cmdAddPPE_Click(Object eventSender, System.EventArgs eventArgs)
		{
			TFDIncident.clsCasualty Casualty = Container.Resolve< clsCasualty>();
			int i = 0;

			//Add new Personal Protective Equipment Problem Record

			if ( ViewModel.cboFPEEquipment.SelectedIndex != -1)
			{
				Casualty.FE_FPECode = ViewModel.cboFPEEquipment.GetItemData(ViewModel.cboFPEEquipment.SelectedIndex);
				if ( ViewModel.cboFPEStatus.SelectedIndex != -1)
				{
					Casualty.FE_FPEStatus = ViewModel.cboFPEStatus.GetItemData(ViewModel.cboFPEStatus.SelectedIndex);
					if ( ViewModel.cboFPEProblem.SelectedIndex != -1)
					{
						Casualty.FE_FPEProblem = ViewModel.cboFPEProblem.GetItemData(ViewModel.cboFPEProblem.SelectedIndex);
						Casualty.FECasualtyID = ViewModel.CurrReportID;
						Casualty.Manufacturer = "";
						Casualty.Model = "";
						Casualty.SerialNumber = "";
						if (~Casualty.AddFSCasualtyFailedEquipment() != 0)
						{
							ViewManager.ShowMessage("Error Attempting to Add PPE Problem Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						}
						LoadPPEList();
					}
				}
			}


		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdCivAddNarration_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Determine Command Mode - Add New (1) or Save New (2)

			switch(Convert.ToString(ViewModel.cmdCivAddNarration.Tag))
			{
				case "1" :
					//    Clear Screen for New Narration 
					if ( ViewModel.NarrationUpdated != 0)
					{
						SaveNarration();
					}
					ViewModel.lbCivilNarrID.Text = "";
					ViewModel.lbCCAuthor.Text = IncidentMain.Shared.gCurrUserName;
					ViewModel.rtxCivilNarration.Text = "";
					ViewModel.rtxCivilNarration.Enabled = true;
					ViewManager.SetCurrent(ViewModel.rtxCivilNarration);
					ViewModel.cmdCivAddNarration.Tag = "2";
					ViewModel.cmdCivAddNarration.Text = "Save New Narration";
					ViewModel.NarrationUpdated = 0;
					break;
				case "2" :
					//   Save New Narration 
					SaveNarration();
					LoadNarration(0);
					ViewModel.cmdCivAddNarration.Tag = "1";
					ViewModel.cmdCivAddNarration.Text = "Add New Narration";
					break;
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdEDITFPE_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.frmFPE.Left = 0;
			ViewModel.cmdSave[0].Enabled = false;
			ViewModel.cmdSave[1].Enabled = false;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdRemovePPE_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Check For a Selected Entry
			//Delete Selected Record
			TFDIncident.clsCasualty Casualty = Container.Resolve< clsCasualty>();

			int ItemSelected = 0;
			for (int i = 0; i <= ViewModel.lstPPE.Items.Count - 1; i++)
			{
				if ( ViewModel.lstPPE.GetSelected( i))
				{
					ItemSelected = -1;
					break;
				}
			}
			if (~ItemSelected != 0)
			{
				return;
			}

			for (int i = 0; i <= ViewModel.lstPPE.Items.Count - 1; i++)
			{
				if ( ViewModel.lstPPE.GetSelected( i))
				{
					int tempRefParam = ViewModel.lstPPE.GetItemData(i);
					if (~Casualty.DeleteFSCasualtyFailedEquipment(ref tempRefParam) != 0)
					{
						ViewManager.ShowMessage("Error Attempting to Delete PPE Problem Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					}
				}
			}

			LoadPPEList();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdSave_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				int Index =this.ViewModel.cmdSave.IndexOf((UpgradeHelpers.BasicViewModels.ButtonViewModel) eventSender);
				//Save Report if requested and exit form

				int UpdateType = 0;
				if (Index == 0 || Index == 1)
				{
					if (Index == 0)
					{
						UpdateType = IncidentMain.COMPLETE;
					}
					else
					{
						UpdateType = IncidentMain.SAVEDINCOMPLETE;
					}
					switch( ViewModel.CurrReport)
					{
						case IncidentMain.INVESTIGATION : case IncidentMain.CLEANUP : case IncidentMain.STANDBY :
							if (~SaveServiceReport(UpdateType) != 0)
							{
								ViewManager.ShowMessage("Error Attempting to Save Report", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
							else
							{
								if (UpdateType == IncidentMain.COMPLETE)
								{
									ViewManager.ShowMessage("Report Saved as Complete", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK);
								}
								else
								{
									ViewManager.ShowMessage("Report Saved as Incomplete", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK);
								}
							}
							break;
						case IncidentMain.CIVILCASUALTY :
							if (~SaveCivilianCasualty(UpdateType) != 0)
							{
								ViewManager.ShowMessage("Error Attempting to Save Report", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
							else
							{
								if (UpdateType == IncidentMain.COMPLETE)
								{
									ViewManager.ShowMessage("Report Saved as Complete", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK);
								}
								else
								{
									ViewManager.ShowMessage("Report Saved as Incomplete", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK);
								}
							}
							break;
						case IncidentMain.FSCASUALTY :
							if (~SaveCasualty(UpdateType) != 0)
							{
								ViewManager.ShowMessage("Error Attempting to Save Report", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
							else
							{
								if (UpdateType == IncidentMain.COMPLETE)
								{
									ViewManager.ShowMessage("Report Saved as Complete", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK);
								}
								else
								{
									ViewManager.ShowMessage("Report Saved as Incomplete", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK);
								}
							}

							break;
						default:
							if (~SaveAllInfo(UpdateType) != 0)
							{
								ViewManager.ShowMessage("Error Attempting to Save Report", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
							else
							{
								if (UpdateType == IncidentMain.COMPLETE)
								{
									ViewManager.ShowMessage("Report Saved as Complete", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK);
								}
								else
								{
									ViewManager.ShowMessage("Report Saved as Incomplete", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK);
								}
							}
							break;
					}
				}
				else if (Index == 3)
				{
					//Show Report Print Preview
					IncidentMain
						.Shared.gEditReportID = ViewModel.ReportLogID;
					using ( var async2 = this.Async() )
					{
						switch( ViewModel.CurrReport)
						{
							case IncidentMain.FSCASUALTY : case IncidentMain.CIVILCASUALTY :
								async2.Append(() =>
									{
										ViewManager.NavigateToView(
											frmReportCasualty.DefInstance, true);
									});
								break;
							default:
								async2.Append(() =>
									{
										ViewManager.NavigateToView(
											frmReportOther.DefInstance, true);
									});

								break;
						}
					}
					}
				async1.Append(() =>
					{
						ViewManager.DisposeView(this);
					});
			}


		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdServAddNarration_Click(Object eventSender, System.EventArgs eventArgs)
		{
			switch(Convert.ToString(ViewModel.cmdServAddNarration.Tag))
			{
				case "1" :
					//    Clear Screen for New Narration 
					if ( ViewModel.NarrationUpdated != 0)
					{
						SaveNarration();
					}
					ViewModel.lbServiceNarrID.Text = "";
					ViewModel.lbServNarrAuthor.Text = IncidentMain.Shared.gCurrUserName;
					ViewModel.rtxServiceNarration.Text = "";
					ViewModel.rtxServiceNarration.Enabled = true;
					ViewManager.SetCurrent(ViewModel.rtxServiceNarration);
					ViewModel.cmdServAddNarration.Tag = "2";
					ViewModel.cmdServAddNarration.Text = "Save New Narration";
					ViewModel.NarrationUpdated = 0;
					break;
				case "2" :
					//   Save New Narration 
					SaveNarration();
					LoadNarration(0);
					ViewModel.cmdServAddNarration.Tag = "1";
					ViewModel.cmdServAddNarration.Text = "Add New Narration";
					break;
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			//Determine Report Type
			//Format Form Controls
			TFDIncident.clsReportLog ReportLog = Container.Resolve< clsReportLog>();
			TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();
			TFDIncident.clsCommonCodes CommonCodes = Container.Resolve< clsCommonCodes>();
			TFDIncident.clsFireCodes FireCodes = Container.Resolve< clsFireCodes>();
			ViewModel.ReportLogID = IncidentMain.Shared.gEditReportID;

			if (ReportLog.GetReportLog(ViewModel.ReportLogID) != 0)
			{
				ViewModel.CurrReportID = ReportLog.ReportReferenceID;
				ViewModel.CurrIncident = ReportLog.RLIncidentID;
				ViewModel.CurrReport = ReportLog.ReportType;
				if (~IncidentCL.GetIncident(ViewModel.CurrIncident) != 0)
				{
					ViewManager.ShowMessage("Error Retrieving Incident Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				}
				else
				{
					ViewModel.lbIncident.Text = IncidentCL.IncidentNumber;
					ViewModel.lbLocation.Text = IncidentCL.Location;
				}
			}
			else
			{
				ViewManager.ShowMessage("Error Retrieving ReportLog Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				ViewManager.DisposeView(this);
			}

			switch( ViewModel.CurrReport)
			{
				case IncidentMain.HAZCONDITION :
					ViewModel.frmAllInfo.BackColor = IncidentMain.Shared.FIRECOLOR;
					ViewModel.lbAllInfoTitle.Text = "HAZARDOUS CONDITION REPORT";
					ViewModel.lbAllInfoTitle.ForeColor = IncidentMain.Shared.ALLINFOFONT;
					ViewModel.lbAllInfo1.Text = "Hazardous Condition Situation";
					ViewModel.lbAllInfo1.ForeColor = IncidentMain.Shared.FIREFONT;
					ViewModel.lbAllInfo1.Visible = true;
					ViewModel.lbAllInfo2.Text = "General Property Use";
					ViewModel.lbAllInfo2.Visible = true;
					ViewModel.lbAllInfo2.ForeColor = IncidentMain.Shared.FIREFONT;
					ViewModel.lbAllInfo3.Visible = false;
					ViewModel.lbAllInfo4.Visible = false;
					ViewModel.cboAllInfo1.Visible = true;
					ViewModel.cboAllInfo1.ForeColor = IncidentMain.Shared.FIREFONT;
					ViewModel.cboAllInfo1.Items.Clear();
					ViewModel.cboAllInfo2.Visible = true;
					ViewModel.cboAllInfo2.ForeColor = IncidentMain.Shared.FIREFONT;
					ViewModel.cboAllInfo2.Items.Clear();
					ViewModel.cboAllInfo3.Visible = false;
					ViewModel.txtAllInfo1.Visible = false;
					ViewModel.rtxFalseAlarmComment.Visible = false;
					CommonCodes.GetIncidentTypeCodeByClass(5);  //Hazardous Condition 

					while(!CommonCodes.IncidentType.EOF)
					{
						ViewModel.cboAllInfo1.AddItem(IncidentMain.Clean(CommonCodes.IncidentType["description"]));
						ViewModel.cboAllInfo1.SetItemData(ViewModel.cboAllInfo1.GetNewIndex(), Convert.ToInt32(CommonCodes.IncidentType["incident_type_code"]));
						CommonCodes.IncidentType.MoveNext();
					}
					;
					FireCodes.GetPropertyUseClass();

					while(!FireCodes.PropertyUseClassRS.EOF)
					{
						ViewModel.cboAllInfo2.AddItem(IncidentMain.Clean(FireCodes.PropertyUseClassRS["class_description"]));
						ViewModel.cboAllInfo2.SetItemData(ViewModel.cboAllInfo2.GetNewIndex(), Convert.ToInt32(FireCodes.PropertyUseClassRS["property_use_class"]));
						FireCodes.PropertyUseClassRS.MoveNext();
					}
					;
					GetAllInfoData();
					ViewModel.frmAllInfo.Left = 0;
					break;
				case IncidentMain.SEARCHRESCUE :
					ViewModel.frmAllInfo.BackColor = IncidentMain.Shared.TEAL;
					ViewModel.lbAllInfoTitle.Text = "SEARCH AND/OR RESCUE REPORT";
					ViewModel.lbAllInfoTitle.ForeColor = IncidentMain.Shared.SALMON;
					ViewModel.lbAllInfo1.Text = "TYPE OF SEARCH AND/OR RESCUE REPORT";
					ViewModel.lbAllInfo1.ForeColor = IncidentMain.Shared.SALMON;
					ViewModel.lbAllInfo1.Visible = true;
					ViewModel.lbAllInfo2.Visible = false;
					ViewModel.lbAllInfo3.Visible = false;
					ViewModel.lbAllInfo4.Text = "NUMBER RESCUED";
					ViewModel.lbAllInfo4.ForeColor = IncidentMain.Shared.SALMON;
					ViewModel.lbAllInfo4.Visible = true;
					ViewModel.cboAllInfo1.Visible = true;
					ViewModel.cboAllInfo1.ForeColor = IncidentMain.Shared.FIREFONT;
					ViewModel.cboAllInfo1.Items.Clear();
					ViewModel.cboAllInfo2.Visible = false;
					ViewModel.cboAllInfo3.Visible = false;
					ViewModel.txtAllInfo1.Visible = true;
					ViewModel.txtAllInfo1.Text = "0";
					ViewModel.txtAllInfo1.ForeColor = IncidentMain.Shared.FIREFONT;
					ViewModel.rtxFalseAlarmComment.Visible = false;
					CommonCodes.GetIncidentTypeCodeByClass(6);  //Search/Rescue 

					while(!CommonCodes.IncidentType.EOF)
					{
						ViewModel.cboAllInfo1.AddItem(IncidentMain.Clean(CommonCodes.IncidentType["description"]));
						ViewModel.cboAllInfo1.SetItemData(ViewModel.cboAllInfo1.GetNewIndex(), Convert.ToInt32(CommonCodes.IncidentType["incident_type_code"]));
						CommonCodes.IncidentType.MoveNext();
					}
					;
					GetAllInfoData();
					ViewModel.frmAllInfo.Left = 0;
					break;
				case IncidentMain.FALSEALARM :
					ViewModel.frmAllInfo.BackColor = IncidentMain.Shared.EMSCOLOR;
					ViewModel.lbAllInfoTitle.Text = "FALSE ALARM REPORT";
					ViewModel.lbAllInfoTitle.ForeColor = IncidentMain.Shared.EMSFONT;
					ViewModel.lbAllInfo1.Text = "WHY ALARM ACTIVATED";
					ViewModel.lbAllInfo1.ForeColor = IncidentMain.Shared.EMSFONT;
					ViewModel.lbAllInfo1.Visible = true;
					ViewModel.lbAllInfo2.Text = "ALARM SENT BY";
					ViewModel.lbAllInfo2.Visible = true;
					ViewModel.lbAllInfo2.ForeColor = IncidentMain.Shared.EMSFONT;
					ViewModel.lbAllInfo3.Visible = true;
					ViewModel.lbAllInfo3.Text = "DEVICE INITIATING FALSE ALARM";
					ViewModel.lbAllInfo3.ForeColor = IncidentMain.Shared.EMSFONT;
					ViewModel.lbAllInfo4.Visible = true;
					ViewModel.lbAllInfo4.Text = "FALSE ALARM COMMENT";
					ViewModel.cboAllInfo1.Visible = true;
					ViewModel.cboAllInfo1.ForeColor = IncidentMain.Shared.EMSFONT;
					ViewModel.cboAllInfo1.Items.Clear();
					ViewModel.cboAllInfo2.Visible = true;
					ViewModel.cboAllInfo2.ForeColor = IncidentMain.Shared.EMSFONT;
					ViewModel.cboAllInfo2.Items.Clear();
					ViewModel.cboAllInfo3.Visible = true;
					ViewModel.cboAllInfo3.ForeColor = IncidentMain.Shared.EMSFONT;
					ViewModel.cboAllInfo3.Items.Clear();
					ViewModel.txtAllInfo1.Visible = false;
					ViewModel.rtxFalseAlarmComment.Visible = true;
					ViewModel.rtxFalseAlarmComment.Text = "";
					//False Alarm Incident Type Codes 
					CommonCodes.GetIncidentTypeCodeByClass(7);  //False Alarm 

					while(!CommonCodes.IncidentType.EOF)
					{
						ViewModel.cboAllInfo1.AddItem(IncidentMain.Clean(CommonCodes.IncidentType["description"]));
						ViewModel.cboAllInfo1.SetItemData(ViewModel.cboAllInfo1.GetNewIndex(), Convert.ToInt32(CommonCodes.IncidentType["incident_type_code"]));
						CommonCodes.IncidentType.MoveNext();
					}
					;
					//Alarm Sent By 
					CommonCodes.GetAlarmSentBy();

					while(!CommonCodes.AlarmSentBy.EOF)
					{
						ViewModel.cboAllInfo2.AddItem(IncidentMain.Clean(CommonCodes.AlarmSentBy["description"]));
						ViewModel.cboAllInfo2.SetItemData(ViewModel.cboAllInfo2.GetNewIndex(), Convert.ToInt32(CommonCodes.AlarmSentBy["alarm_sent_by_code"]));
						CommonCodes.AlarmSentBy.MoveNext();
					}
					;
					//Device Initiating False Alarm 
					FireCodes.GetAlarmDevice();

					while(!FireCodes.AlarmDevice.EOF)
					{
						ViewModel.cboAllInfo3.AddItem(IncidentMain.Clean(FireCodes.AlarmDevice["description"]));
						ViewModel.cboAllInfo3.SetItemData(ViewModel.cboAllInfo3.GetNewIndex(), Convert.ToInt32(FireCodes.AlarmDevice["alarm_device_code"]));
						FireCodes.AlarmDevice.MoveNext();
					}
					;
					GetAllInfoData();
					ViewModel.frmAllInfo.Left = 0;
					break;
				case IncidentMain.INVESTIGATION :
					ViewModel.lbServiceTitle.Text = "INVESTIGATION ONLY - REPORT";
					ViewModel.lbServiceProvided.Text = "TYPE OF INVESTIGATION";
					ViewModel.cboServiceType.Items.Clear();
					ViewModel.lbStandbyHours.Visible = false;
					ViewModel.txtStandbyHours.Visible = false;
					ViewModel.txtStandbyHours.Text = "";
					ViewModel.lbSafePlace.Visible = false;
					ViewModel.txtNumberSafePlace.Visible = false;
					ViewModel.txtNumberSafePlace.Text = "";
					CommonCodes.GetIncidentTypeCodeByClass(9);  //Investigate Only 

					while(!CommonCodes.IncidentType.EOF)
					{
						ViewModel.cboServiceType.AddItem(IncidentMain.Clean(CommonCodes.IncidentType["description"]));
						ViewModel.cboServiceType.SetItemData(ViewModel.cboServiceType.GetNewIndex(), Convert.ToInt32(CommonCodes.IncidentType["incident_type_code"]));
						CommonCodes.IncidentType.MoveNext();
					}
					;
					GetServiceInfo();
					ViewModel.frmService.Left = 0;
					break;
				case IncidentMain.CLEANUP :
					ViewModel.lbServiceTitle.Text = "CLEAN UP ONLY - REPORT";
					ViewModel.lbServiceProvided.Text = "TYPE OF CLEAN UP";
					ViewModel.cboServiceType.Items.Clear();
					ViewModel.lbStandbyHours.Visible = false;
					ViewModel.txtStandbyHours.Visible = false;
					ViewModel.txtStandbyHours.Text = "";
					ViewModel.lbSafePlace.Visible = false;
					ViewModel.txtNumberSafePlace.Visible = false;
					ViewModel.txtNumberSafePlace.Text = "";
					CommonCodes.GetIncidentTypeCodeByClass(8);  //Cleanup Only 

					while(!CommonCodes.IncidentType.EOF)
					{
						ViewModel.cboServiceType.AddItem(IncidentMain.Clean(CommonCodes.IncidentType["description"]));
						ViewModel.cboServiceType.SetItemData(ViewModel.cboServiceType.GetNewIndex(), Convert.ToInt32(CommonCodes.IncidentType["incident_type_code"]));
						CommonCodes.IncidentType.MoveNext();
					}
					;
					GetServiceInfo();
					ViewModel.frmService.Left = 0;
					break;
				case IncidentMain.STANDBY :
					ViewModel.lbServiceTitle.Text = "STANDBY/STAGING ONLY - REPORT";
					ViewModel.lbServiceProvided.Text = "TYPE OF STANDBY/STAGING";
					ViewModel.cboServiceType.Items.Clear();
					ViewModel.lbStandbyHours.Visible = true;
					ViewModel.txtStandbyHours.Visible = true;
					ViewModel.txtNumberSafePlace.Text = "";
					ViewModel.lbSafePlace.Visible = false;
					ViewModel.txtNumberSafePlace.Visible = false;
					ViewModel.txtNumberSafePlace.Text = "";
					CommonCodes.GetIncidentTypeCodeByClass(10);  //Standby/Staging Only 

					while(!CommonCodes.IncidentType.EOF)
					{
						ViewModel.cboServiceType.AddItem(IncidentMain.Clean(CommonCodes.IncidentType["description"]));
						ViewModel.cboServiceType.SetItemData(ViewModel.cboServiceType.GetNewIndex(), Convert.ToInt32(CommonCodes.IncidentType["incident_type_code"]));
						CommonCodes.IncidentType.MoveNext();
					}
					;
					GetServiceInfo();
					ViewModel.frmService.Left = 0;
					break;
				case IncidentMain.CIVILCASUALTY :
					LoadCivilianCasualty();
					ViewModel.frmCivilianCasualty.Left = 0;
					break;
				case IncidentMain.FSCASUALTY :
					LoadFSCasualty();
					ViewModel.frmFSCasualty.Left = 0;
					break;
			}

			CheckComplete();
			if (IncidentMain.Shared.gWizardSecurity == IncidentMain.READONLY)
			{
				LockScreen();
			}


		}

		private void rtxAllNarration_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime != 0)
			{
				return;
			}
			ViewModel.NarrationUpdated = -1;
		}

		private void rtxCivilNarration_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.NarrationUpdated = -1;
		}

		private void rtxServiceNarration_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.NarrationUpdated = -1;
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtAllInfo1_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtNumberSafePlace_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();

		}

		[UpgradeHelpers.Events.Handler]
		internal void txtStandbyHours_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmOtherReports DefInstance
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

		public static frmOtherReports CreateInstance()
		{
			TFDIncident.frmOtherReports theInstance = Shared.Container.Resolve< frmOtherReports>();
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
			ViewModel.picEMSBar.LifeCycleStartup();
			ViewModel.frmAllInfo.LifeCycleStartup();
			ViewModel.frmService.LifeCycleStartup();
			ViewModel.frmCivilianCasualty.LifeCycleStartup();
			ViewModel.frmFSCasualty.LifeCycleStartup();
			ViewModel.frmFPE.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.picEMSBar.LifeCycleShutdown();
			ViewModel.frmAllInfo.LifeCycleShutdown();
			ViewModel.frmService.LifeCycleShutdown();
			ViewModel.frmCivilianCasualty.LifeCycleShutdown();
			ViewModel.frmFSCasualty.LifeCycleShutdown();
			ViewModel.frmFPE.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmOtherReports
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.frmOtherReportsViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmOtherReports m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}