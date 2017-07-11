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

	public partial class frmHazmatReport
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.frmHazmatReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmHazmatReport));
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


		private void frmHazmatReport_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//TFD Incident Reporting System - Hazmat Report Editing Form
		//********************************************************
		//**      Hazmat Report Editing Form                    **
		//********************************************************


		//*****************************************************
		//** Form Level Variables
		//*****************************************************

		//***************************************************
		//**  Form Functions and Subroutines
		//***************************************************


		private void SaveNarration()
		{
			//determine if Insert or Update
			//Save Incident Narration Record
			TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();
			IncidentCL.NarrationIncidentID = ViewModel.CurrIncident;
			IncidentCL.ReportType = ViewModel.CurrReport;
			IncidentCL.NarrationText = ViewModel.rtxNarration.Text;
			IncidentCL.NarrationBy = IncidentMain.Shared.gCurrUser;
			IncidentCL.NarrationLastUpdate = DateTime.Now.ToString("MM/dd/yyyy");
			int NarrID = Convert.ToInt32(Conversion.Val(ViewModel.lbNarrID.Text));
			if (NarrID == 0)
			{
				if (~IncidentCL.AddNarration() != 0)
				{
					ViewManager.ShowMessage("Error attempting to save Narration Record", "Edit Hazmat Report", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
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
						ViewManager.ShowMessage("Error attempting to update Narration Record", "Edit Hazmat Report", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					}
					else
					{
						ViewModel.NarrationUpdated = 0;
					}
				}
			}
		}

		private void LockScreen()
		{
			//Lock Controls for ReadOnly Access
			//UPGRADE_ISSUE: (2064) ComboBox property cboIncidentType.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.cboIncidentType.setLocked(true);
			//UPGRADE_ISSUE: (2064) ComboBox property cboHazmatIDSource.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.cboHazmatIDSource.setLocked(true);
			//UPGRADE_ISSUE: (2064) ComboBox property cboDisposition.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.cboDisposition.setLocked(true);
			ViewModel.lstActionsTaken.Enabled = false;
			//UPGRADE_ISSUE: (2064) ComboBox property cboOutsideResource.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.cboOutsideResource.setLocked(true);
			//UPGRADE_ISSUE: (2064) ComboBox property cboResourceUse.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.cboResourceUse.setLocked(true);
			ViewModel.cmdAddResource.Enabled = false;
			ViewModel.cmdRemoveResource.Enabled = false;
			ViewModel.lstOutsideResource.Enabled = false;
			//UPGRADE_ISSUE: (2064) ComboBox property cboGeneralPropertyUse.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.cboGeneralPropertyUse.setLocked(true);
			//UPGRADE_ISSUE: (2064) ComboBox property cboSpecificPropertyUse.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.cboSpecificPropertyUse.setLocked(true);
			//UPGRADE_ISSUE: (2064) ComboBox property cboAreaOfOrigin.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.cboAreaOfOrigin.setLocked(true);
			//UPGRADE_ISSUE: (2064) ComboBox property cboCauseOfRelease.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.cboCauseOfRelease.setLocked(true);
			ViewModel.txtReleaseFloor.Enabled = false;
			//UPGRADE_ISSUE: (2064) ComboBox property cboStreetClass.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.cboStreetClass.setLocked(true);
			ViewModel.lstContributingFactors.Enabled = false;
			ViewModel.lstMitigatingFactors.Enabled = false;
			ViewModel.optOccurredFirst[0].Enabled = false;
			ViewModel.optOccurredFirst[1].Enabled = false;
			ViewModel.optOccurredFirst[2].Enabled = false;
			//UPGRADE_ISSUE: (2064) ComboBox property cboAreaAffectedUnits.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.cboAreaAffectedUnits.setLocked(true);
			ViewModel.txtAreaAffected.Enabled = false;
			//UPGRADE_ISSUE: (2064) ComboBox property cboAreaEvacuatedUnits.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.cboAreaEvacuatedUnits.setLocked(true);
			ViewModel.txtAreaEvacuated.Enabled = false;
			//UPGRADE_ISSUE: (2064) ComboBox property cboPopulationDensity.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.cboPopulationDensity.setLocked(true);
			ViewModel.txtPeopleEvacuated.Enabled = false;
			ViewModel.txtBuildingsEvacuated.Enabled = false;
			ViewModel.lstEquipmentInvolved.Enabled = false;
			//UPGRADE_ISSUE: (2064) ComboBox property cboContainerType.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.cboContainerType.setLocked(true);
			//UPGRADE_ISSUE: (2064) ComboBox property cboCommonChemicals.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.cboCommonChemicals.setLocked(true);
			//UPGRADE_ISSUE: (2064) ComboBox property cboChemicalName.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.cboChemicalName.setLocked(true);
			//UPGRADE_ISSUE: (2064) ComboBox property cboUN.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.cboUN.setLocked(true);
			//UPGRADE_ISSUE: (2064) ComboBox property cboContainerCapacityUnits.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.cboContainerCapacityUnits.setLocked(true);
			ViewModel.txtEstContainerCapacity.Enabled = true;
			//UPGRADE_ISSUE: (2064) ComboBox property cboAmountReleasedUnits.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.cboAmountReleasedUnits.setLocked(true);
			ViewModel.txtEstAmountReleased.Enabled = false;
			//UPGRADE_ISSUE: (2064) ComboBox property cboPhysicalStateStored.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.cboPhysicalStateStored.setLocked(true);
			//UPGRADE_ISSUE: (2064) ComboBox property cboPhysicalStateReleased.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.cboPhysicalStateReleased.setLocked(true);
			//UPGRADE_ISSUE: (2064) ComboBox property cboPrimaryReleasedInto.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.cboPrimaryReleasedInto.setLocked(true);
			//UPGRADE_ISSUE: (2064) ComboBox property cboSecondaryReleasedInto.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.cboSecondaryReleasedInto.setLocked(true);
			//UPGRADE_ISSUE: (2064) ComboBox property cboDrugLabType.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.cboDrugLabType.setLocked(true);
			//UPGRADE_ISSUE: (2064) ComboBox property cboMaterialUsed.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.cboMaterialUsed.setLocked(true);
			ViewModel.lstMaterialUsed.Enabled = false;
			ViewModel.txtQuantity.Enabled = false;
			ViewModel.cmdAddMaterial.Enabled = false;
			ViewModel.cmdRemoveMaterial.Enabled = false;
			ViewModel.rtxNarration.Enabled = false;
			ViewModel.cmdAddNarration.Visible = false;
			ViewModel.cmdSave[0].Enabled = false;
			ViewModel.cmdSave[1].Enabled = false;
			ViewModel.cmdSave[0].Visible = false;
			ViewModel.cmdSave[1].Visible = false;

		}

		private int SaveChemicalDetail()
		{
			//Save Current Chemical Detail record
			//Clear Selections/Entries of Current Chemical for new record
			int result = 0;
			TFDIncident.clsHazmat HazmatCL = Container.Resolve< clsHazmat>();
			int ChemDetailID = 0;

			result = -1;
			if ( ViewModel.ChemicalDetailUpdated != 0)
			{
				ChemDetailID = Convert.ToInt32(Conversion.Val(ViewModel.lbChemDetailID.Text));
				HazmatCL.CDHazmatID = ViewModel.HazmatID;
				HazmatCL.CDChemicalID = Convert.ToInt32(Conversion.Val(ViewModel.lbChemicalID.Text));
				if ( ViewModel.cboContainerType.SelectedIndex == -1)
				{
					HazmatCL.ContainerTypeCode = 0;
				}
				else
				{
					HazmatCL.ContainerTypeCode = ViewModel.cboContainerType.GetItemData(ViewModel.cboContainerType.SelectedIndex);
				}
				HazmatCL.ContainerCapacity = Convert.ToInt32(Conversion.Val(ViewModel.txtEstContainerCapacity.Text));
				if ( ViewModel.cboContainerCapacityUnits.SelectedIndex == -1)
				{
					HazmatCL.ContainerCapacityUnits = 0;
				}
				else
				{
					HazmatCL.ContainerCapacityUnits = ViewModel.cboContainerCapacityUnits.GetItemData(ViewModel.cboContainerCapacityUnits.SelectedIndex);
				}
				HazmatCL.AmountReleased = Convert.ToInt32(Conversion.Val(ViewModel.txtEstAmountReleased.Text));
				if ( ViewModel.cboAmountReleasedUnits.SelectedIndex == -1)
				{
					HazmatCL.AmountReleasedUnits = 0;
				}
				else
				{
					HazmatCL.AmountReleasedUnits = ViewModel.cboAmountReleasedUnits.GetItemData(ViewModel.cboAmountReleasedUnits.SelectedIndex);
				}
				if ( ViewModel.cboPhysicalStateStored.SelectedIndex == -1)
				{
					HazmatCL.PhysicalStateStored = 0;
				}
				else
				{
					HazmatCL.PhysicalStateStored = ViewModel.cboPhysicalStateStored.GetItemData(ViewModel.cboPhysicalStateStored.SelectedIndex);
				}
				if ( ViewModel.cboPhysicalStateReleased.SelectedIndex == -1)
				{
					HazmatCL.PhysicalStateReleased = 0;
				}
				else
				{
					HazmatCL.PhysicalStateReleased = ViewModel.cboPhysicalStateReleased.GetItemData(ViewModel.cboPhysicalStateReleased.SelectedIndex);
				}
				if ( ViewModel.cboPrimaryReleasedInto.SelectedIndex == -1)
				{
					HazmatCL.PrimaryReleasedInto = 0;
				}
				else
				{
					HazmatCL.PrimaryReleasedInto = ViewModel.cboPrimaryReleasedInto.GetItemData(ViewModel.cboPrimaryReleasedInto.SelectedIndex);
				}
				if ( ViewModel.cboSecondaryReleasedInto.SelectedIndex == -1)
				{
					HazmatCL.SecondaryReleasedInto = 0;
				}
				else
				{
					HazmatCL.SecondaryReleasedInto = ViewModel.cboSecondaryReleasedInto.GetItemData(ViewModel.cboSecondaryReleasedInto.SelectedIndex);
				}
				if (ChemDetailID == 0)
				{
					//Add New Record
					if (~HazmatCL.AddHazmatChemicalDetail() != 0)
					{
						result = 0;
					}
					else
					{
						ChemDetailID = HazmatCL.ChemicalDetailID;
					}
				}
				else
				{
					//Update existing Record
					HazmatCL.ChemicalDetailID = ChemDetailID;
					if (~HazmatCL.UpdateHazmatChemicalDetail() != 0)
					{
						result = 0;
					}
				}
			}
			if (result != 0)
			{
				//Clear current selections/entries
				if (ChemDetailID != 0)
				{
					LoadChemicalDetail(ChemDetailID); //Put possible new entry in list
					CheckComplete();
					ViewModel.ChemicalDetailUpdated = 0;
				}
				else
				{
					ViewModel.FirstTime = -1;
					ViewModel.cboCommonChemicals.SelectedIndex = -1;
					ViewModel.cboChemicalName.SelectedIndex = -1;
					ViewModel.cboUN.SelectedIndex = -1;
					ViewModel.lbChemicalID.Text = "";
					ViewModel.cboContainerType.SelectedIndex = -1;
					ViewModel.cboContainerCapacityUnits.SelectedIndex = -1;
					ViewModel.txtEstContainerCapacity.Text = "";
					ViewModel.cboAmountReleasedUnits.SelectedIndex = -1;
					ViewModel.txtEstAmountReleased.Text = "";
					ViewModel.cboPhysicalStateStored.SelectedIndex = -1;
					ViewModel.cboPhysicalStateReleased.SelectedIndex = -1;
					ViewModel.cboPrimaryReleasedInto.SelectedIndex = -1;
					ViewModel.cboSecondaryReleasedInto.SelectedIndex = -1;
					ViewModel.cmdMoreChemicals.Enabled = false;
					ViewModel.FirstTime = 0;
					ViewModel.ChemicalDetailUpdated = 0;
				}
			}

			return result;
		}

		private int SaveHazmatReport(int iUpdateType)
		{
			//Save Hazmat Report(s)
			//Update ReportLog
			int result = 0;
			TFDIncident.clsHazmat HazmatCL = Container.Resolve< clsHazmat>();
			TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();
			TFDIncident.clsReportLog ReportLog = Container.Resolve< clsReportLog>();

			result = -1;
			if ( ViewModel.CurrReport == IncidentMain.HAZMATDL || ViewModel.CurrReport == IncidentMain.HAZMATDLRELEASE)
			{
				//Update Hazmat Drug Lab record
				HazmatCL.DLHazmatID = ViewModel.HazmatDLID;
				HazmatCL.DLIncidentID = ViewModel.CurrIncident;
				if ( ViewModel.cboDrugLabType.SelectedIndex == -1)
				{
					HazmatCL.DrugLabType = 0;
				}
				else
				{
					HazmatCL.DrugLabType = ViewModel.cboDrugLabType.GetItemData(ViewModel.cboDrugLabType.SelectedIndex);
				}
				if ( ViewModel.cboHazmatIDSource.SelectedIndex == -1)
				{
					HazmatCL.DLHazmatIDSource = 0;
				}
				else
				{
					HazmatCL.DLHazmatIDSource = ViewModel.cboHazmatIDSource.GetItemData(ViewModel.cboHazmatIDSource.SelectedIndex);
				}
				if ( ViewModel.cboDisposition.SelectedIndex == -1)
				{
					HazmatCL.DLDispositionOfRelease = 0;
				}
				else
				{
					HazmatCL.DLDispositionOfRelease = ViewModel.cboDisposition.GetItemData(ViewModel.cboDisposition.SelectedIndex);
				}
				if ( ViewModel.CurrReport == IncidentMain.HAZMATDLRELEASE)
				{
					HazmatCL.DLFlagRelease = 1;
				}
				else
				{
					HazmatCL.DLFlagRelease = 0;
				}
				if (~HazmatCL.UpdateHazmatDrugLab() != 0)
				{
					ViewManager.ShowMessage("Error Attempting to Update Hazmat Drug Lab Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					result = 0;
				}
				if ( ViewModel.CurrReport == IncidentMain.HAZMATDL)
				{
					UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
						{
							var ret =
									HazmatCL.DeleteHazmatDrugLabActionTaken(ref p1);
							ViewModel.HazmatDLID = p1;
							return ret;
						}, ViewModel.HazmatDLID);
					for (int i = 0; i <= ViewModel.lstActionsTaken.Items.Count - 1; i++)
					{
						if ( ViewModel.lstActionsTaken.GetSelected( i))
						{
							HazmatCL.ATDLHazmatID = ViewModel.HazmatDLID;
							HazmatCL.DLUnitAction = ViewModel.lstActionsTaken.GetItemData(i);
							if (~HazmatCL.AddHazmatDrugLabActionTaken() != 0)
							{
								//error
							}
						}
					}
				}
			}

			if ( ViewModel.CurrReport != IncidentMain.HAZMATDL)
			{
				//Update Hazmat Release record
				HazmatCL.HazmatID = ViewModel.HazmatID;
				HazmatCL.IncidentID = ViewModel.CurrIncident;
				if ( ViewModel.cboIncidentType.SelectedIndex == -1)
				{
					HazmatCL.IncidentTypeCode = 0;
				}
				else
				{
					HazmatCL.IncidentTypeCode = ViewModel.cboIncidentType.GetItemData(ViewModel.cboIncidentType.SelectedIndex);
				}
				if ( ViewModel.cboHazmatIDSource.SelectedIndex == -1)
				{
					HazmatCL.HazmatIDSource = 0;
				}
				else
				{
					HazmatCL.HazmatIDSource = ViewModel.cboHazmatIDSource.GetItemData(ViewModel.cboHazmatIDSource.SelectedIndex);
				}
				if ( ViewModel.cboDisposition.SelectedIndex == -1)
				{
					HazmatCL.DispositionOfRelease = 0;
				}
				else
				{
					HazmatCL.DispositionOfRelease = ViewModel.cboDisposition.GetItemData(ViewModel.cboDisposition.SelectedIndex);
				}
				if ( ViewModel.cboCauseOfRelease.SelectedIndex == -1)
				{
					HazmatCL.CauseOfRelease = 0;
				}
				else
				{
					HazmatCL.CauseOfRelease = ViewModel.cboCauseOfRelease.GetItemData(ViewModel.cboCauseOfRelease.SelectedIndex);
				}
				HazmatCL.AreaEffected = Convert.ToInt32(Conversion.Val(ViewModel.txtAreaAffected.Text));
				if ( ViewModel.cboAreaAffectedUnits.SelectedIndex == -1)
				{
					HazmatCL.EffectedAreaUnit = 0;
				}
				else
				{
					HazmatCL.EffectedAreaUnit = ViewModel.cboAreaAffectedUnits.GetItemData(ViewModel.cboAreaAffectedUnits.SelectedIndex);
				}
				HazmatCL.AreaEvacuated = Convert.ToInt32(Conversion.Val(ViewModel.txtAreaEvacuated.Text));
				if ( ViewModel.cboAreaEvacuatedUnits.SelectedIndex == -1)
				{
					HazmatCL.EvacuatedAreaUnit = 0;
				}
				else
				{
					HazmatCL.EvacuatedAreaUnit = ViewModel.cboAreaEvacuatedUnits.GetItemData(ViewModel.cboAreaEvacuatedUnits.SelectedIndex);
				}
				if ( ViewModel.cboPopulationDensity.SelectedIndex == -1)
				{
					HazmatCL.PopulationDensity = 0;
				}
				else
				{
					HazmatCL.PopulationDensity = ViewModel.cboPopulationDensity.GetItemData(ViewModel.cboPopulationDensity.SelectedIndex);
				}
				HazmatCL.BuildingsEvacuated = Convert.ToInt32(Conversion.Val(ViewModel.txtBuildingsEvacuated.Text));
				HazmatCL.PeopleEvacuated = Convert.ToInt32(Conversion.Val(ViewModel.txtPeopleEvacuated.Text));
				if ( ViewModel.cboAreaOfOrigin.SelectedIndex == -1)
				{
					HazmatCL.AreaOfOrigin = 0;
				}
				else
				{
					HazmatCL.AreaOfOrigin = ViewModel.cboAreaOfOrigin.GetItemData(ViewModel.cboAreaOfOrigin.SelectedIndex);
				}
				if ( ViewModel.optOccurredFirst[0].Checked)
				{
					HazmatCL.OccuredFirst = 1;
				}
				else if ( ViewModel.optOccurredFirst[1].Checked)
				{
					HazmatCL.OccuredFirst = 4;
				}
				else if ( ViewModel.optOccurredFirst[2].Checked)
				{
					HazmatCL.OccuredFirst = 2;
				}
				else
				{
					HazmatCL.OccuredFirst = 0;
				}
				if ( ViewModel.cboStreetClass.SelectedIndex == -1)
				{
					HazmatCL.StreetClass = 0;
				}
				else
				{
					HazmatCL.StreetClass = ViewModel.cboStreetClass.GetItemData(ViewModel.cboStreetClass.SelectedIndex);
				}
				HazmatCL.ReleaseFloor = Convert.ToInt32(Conversion.Val(ViewModel.txtReleaseFloor.Text));
				if ( ViewModel.cboSpecificPropertyUse.SelectedIndex == -1)
				{
					HazmatCL.PropertyUse = 0;
				}
				else
				{
					HazmatCL.PropertyUse = ViewModel.cboSpecificPropertyUse.GetItemData(ViewModel.cboSpecificPropertyUse.SelectedIndex);
				}
				if (~HazmatCL.UpdateHazmatRelease() != 0)
				{
					ViewManager.ShowMessage("Error Attempting to Update Hazmat Release Report", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					result = 0;
				}
				//Add Non-Drug Lab Subtable Data
				if (result != 0)
				{
					//Save ChemicalDetail
					if ( ViewModel.ChemicalDetailUpdated != 0)
					{
						if (~SaveChemicalDetail() != 0)
						{
							ViewManager.ShowMessage("Error Attempting to Save ChemicalDetail Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						}
					}
					UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
						{
							var ret =
									HazmatCL.DeleteHazmatContributingFactor(ref p1);
							ViewModel.HazmatID = p1;
							return ret;
						}, ViewModel.HazmatID);
					for (int i = 0; i <= ViewModel.lstContributingFactors.Items.Count - 1; i++)
					{
						if ( ViewModel.lstContributingFactors.GetSelected( i))
						{
							HazmatCL.CFHazmatID = ViewModel.HazmatID;
							HazmatCL.HazmatContributingFactor = ViewModel.lstContributingFactors.GetItemData(i);
							if (~HazmatCL.AddHazmatContributingFactor() != 0)
							{
								//error
							}
						}
					}
					UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
						{
							var ret =
									HazmatCL.DeleteHazmatMitigatingFactor(ref p1);
							ViewModel.HazmatID = p1;
							return ret;
						}, ViewModel.HazmatID);
					for (int i = 0; i <= ViewModel.lstMitigatingFactors.Items.Count - 1; i++)
					{
						if ( ViewModel.lstMitigatingFactors.GetSelected( i))
						{
							HazmatCL.MFHazmatID = ViewModel.HazmatID;
							HazmatCL.HazmatMitigatingFactor = ViewModel.lstMitigatingFactors.GetItemData(i);
							if (~HazmatCL.AddHazmatMitigatingFactor() != 0)
							{
								//error
							}
						}
					}
					UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
						{
							var ret =
									HazmatCL.DeleteHazmatEquipmentInvolved(ref p1);
							ViewModel.HazmatID = p1;
							return ret;
						}, ViewModel.HazmatID);
					for (int i = 0; i <= ViewModel.lstEquipmentInvolved.Items.Count - 1; i++)
					{
						if ( ViewModel.lstEquipmentInvolved.GetSelected( i))
						{
							HazmatCL.EIHazmatID = ViewModel.HazmatID;
							HazmatCL.HazmatEquipmentInvolved = ViewModel.lstEquipmentInvolved.GetItemData(i);
							if (~HazmatCL.AddHazmatEquipmentInvolved() != 0)
							{
								//error
							}
						}
					}
					UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
						{
							var ret =
									HazmatCL.DeleteHazmatActionTaken(ref p1);
							ViewModel.HazmatID = p1;
							return ret;
						}, ViewModel.HazmatID);
					for (int i = 0; i <= ViewModel.lstActionsTaken.Items.Count - 1; i++)
					{
						if ( ViewModel.lstActionsTaken.GetSelected( i))
						{
							HazmatCL.ATHazmatID = ViewModel.HazmatID;
							HazmatCL.UnitAction = ViewModel.lstActionsTaken.GetItemData(i);
							if (~HazmatCL.AddHazmatActionTaken() != 0)
							{
								//error
							}
						}
					}
				}
			}

			//Save Narration
			if ( ViewModel.NarrationUpdated != 0)
			{
				SaveNarration();
			}


			//Update ReportLog
			if (result != 0)
			{
				//Update ReportLog Record
				ReportLog.ReportLogID = ViewModel.ReportLogID;
				ReportLog.RLIncidentID = ViewModel.CurrIncident;
				if ( ViewModel.CurrReport == IncidentMain.HAZMATDL)
				{
					ReportLog.ReportReferenceID = ViewModel.HazmatDLID;
				}
				else
				{
					ReportLog.ReportReferenceID = ViewModel.HazmatID;
				}
				ReportLog.ReportType = ViewModel.CurrReport;
				ReportLog.ReportStatus = iUpdateType;
				ReportLog.ResponsibleUnit = IncidentMain.Shared.gCurrUnit;
				if (~ReportLog.UpDate() != 0)
				{
					ViewManager.ShowMessage("Error Attempting to Update Reportlog", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
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
			ViewModel.rtxNarration.Text = "";
			ViewModel.lbNarrID.Text = "";
			ViewModel.lbNarrAuthor.Text = "";
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
						ViewModel.lbNarrID.Text = Convert.ToString(IncidentCL.IncidentNarration["narration_id"]);
						ViewModel.rtxNarration.Text = Convert.ToString(IncidentCL.IncidentNarration["narration_text"]);
						ViewModel.lbNarrAuthor.Text = IncidentMain.Clean(IncidentCL.IncidentNarration["name_full"]);
						if (IncidentMain.Clean(IncidentCL.IncidentNarration["narration_by"]) != IncidentMain.Shared.gCurrUser)
						{
							ViewModel.rtxNarration.Enabled = false;
						}
						CurrNarr = ViewModel.cboNarrList.GetNewIndex();
					}
					else if (IncidentMain.Clean(IncidentCL.IncidentNarration["narration_by"]) == IncidentMain.Shared.gCurrUser)
					{
						ViewModel.cmdAddNarration.Enabled = false;
						if (lNarrID == 0)
						{
							ViewModel.lbNarrID.Text = Convert.ToString(IncidentCL.IncidentNarration["narration_id"]);
							ViewModel.rtxNarration.Text = Convert.ToString(IncidentCL.IncidentNarration["narration_text"]);
							ViewModel.lbNarrAuthor.Text = IncidentMain.Clean(IncidentCL.IncidentNarration["name_full"]);
							ViewModel.rtxNarration.Enabled = true;
							CurrNarr = ViewModel.cboNarrList.GetNewIndex();
						}
					}
					IncidentCL.IncidentNarration.MoveNext();
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
			ViewModel.FirstTime = 0;
			ViewModel.NarrationUpdated = 0;

		}

		private void LoadChemicalDetail(int lChemicalDetailID)
		{
			//Load Chemical Detail Fields with specified Record
			TFDIncident.clsHazmat HazmatCL = Container.Resolve< clsHazmat>();
			ViewModel.FirstTime = -1;
			ViewModel.cboSelectChemical.Items.Clear();
			ViewModel.cboCommonChemicals.SelectedIndex = -1;
			ViewModel.cboChemicalName.SelectedIndex = -1;
			ViewModel.cboUN.SelectedIndex = -1;
			ViewModel.lbChemicalID.Text = "";
			ViewModel.cboContainerType.SelectedIndex = -1;
			ViewModel.cboContainerCapacityUnits.SelectedIndex = -1;
			ViewModel.txtEstContainerCapacity.Text = "";
			ViewModel.cboAmountReleasedUnits.SelectedIndex = -1;
			ViewModel.txtEstAmountReleased.Text = "";
			ViewModel.cboPhysicalStateStored.SelectedIndex = -1;
			ViewModel.cboPhysicalStateReleased.SelectedIndex = -1;
			ViewModel.cboPrimaryReleasedInto.SelectedIndex = -1;
			ViewModel.cboSecondaryReleasedInto.SelectedIndex = -1;


			if (HazmatCL.GetHazmatChemicalDetailRS(ViewModel.HazmatID) != 0)
			{
				if (lChemicalDetailID == 0)
				{
					HazmatCL.GetHazmatChemicalDetail(Convert.ToInt32(HazmatCL.HazmatChemicalDetail["chemical_detail_id"]));
					ViewModel.FirstTime = 0;
					for (int i = 0; i <= ViewModel.cboCommonChemicals.Items.Count - 1; i++)
					{
						if ( ViewModel.cboCommonChemicals.GetItemData(i) == HazmatCL.CDChemicalID)
						{
							ViewModel.cboCommonChemicals.SelectedIndex = i; // This will trigger selecting the other chem combos

							break;
						}
					}
					for (int i = 0; i <= ViewModel.cboChemicalName.Items.Count - 1; i++)
					{
						if ( ViewModel.cboChemicalName.GetItemData(i) == HazmatCL.CDChemicalID)
						{
							ViewModel.cboChemicalName.SelectedIndex = i;
							break;
						}
					}
					for (int i = 0; i <= ViewModel.cboUN.Items.Count - 1; i++)
					{
						if ( ViewModel.cboUN.GetItemData(i) == HazmatCL.CDChemicalID)
						{
							ViewModel.cboUN.SelectedIndex = i;
							break;
						}
					}
					ViewModel.FirstTime = -1;
					for (int i = 0; i <= ViewModel.cboContainerType.Items.Count - 1; i++)
					{
						if ( ViewModel.cboContainerType.GetItemData(i) == HazmatCL.ContainerTypeCode)
						{
							ViewModel.cboContainerType.SelectedIndex = i;
							break;
						}
					}
					for (int i = 0; i <= ViewModel.cboContainerCapacityUnits.Items.Count - 1; i++)
					{
						if ( ViewModel.cboContainerCapacityUnits.GetItemData(i) == HazmatCL.ContainerCapacityUnits)
						{
							ViewModel.cboContainerCapacityUnits.SelectedIndex = i;
							break;
						}
					}
					ViewModel.txtEstContainerCapacity.Text = HazmatCL.ContainerCapacity.ToString();
					for (int i = 0; i <= ViewModel.cboAmountReleasedUnits.Items.Count - 1; i++)
					{
						if ( ViewModel.cboAmountReleasedUnits.GetItemData(i) == HazmatCL.AmountReleasedUnits)
						{
							ViewModel.cboAmountReleasedUnits.SelectedIndex = i;
							break;
						}
					}
					ViewModel.txtEstAmountReleased.Text = HazmatCL.AmountReleased.ToString();
					for (int i = 0; i <= ViewModel.cboPhysicalStateStored.Items.Count - 1; i++)
					{
						if ( ViewModel.cboPhysicalStateStored.GetItemData(i) == HazmatCL.PhysicalStateStored)
						{
							ViewModel.cboPhysicalStateStored.SelectedIndex = i;
							break;
						}
					}
					for (int i = 0; i <= ViewModel.cboPhysicalStateReleased.Items.Count - 1; i++)
					{
						if ( ViewModel.cboPhysicalStateReleased.GetItemData(i) == HazmatCL.PhysicalStateReleased)
						{
							ViewModel.cboPhysicalStateReleased.SelectedIndex = i;
							break;
						}
					}
					for (int i = 0; i <= ViewModel.cboPrimaryReleasedInto.Items.Count - 1; i++)
					{
						if ( ViewModel.cboPrimaryReleasedInto.GetItemData(i) == HazmatCL.PrimaryReleasedInto)
						{
							ViewModel.cboPrimaryReleasedInto.SelectedIndex = i;
							break;
						}
					}
					for (int i = 0; i <= ViewModel.cboSecondaryReleasedInto.Items.Count - 1; i++)
					{
						if ( ViewModel.cboSecondaryReleasedInto.GetItemData(i) == HazmatCL.SecondaryReleasedInto)
						{
							ViewModel.cboSecondaryReleasedInto.SelectedIndex = i;
							break;
						}
					}
				}


				while(!HazmatCL.HazmatChemicalDetail.EOF)
				{
					HazmatCL.GetChemical(Convert.ToInt32(HazmatCL.HazmatChemicalDetail["chemical_id"]));
					ViewModel.cboSelectChemical.AddItem(IncidentMain.Clean(HazmatCL.Chemicals["chemical_name"]));
					ViewModel.cboSelectChemical.SetItemData(ViewModel.cboSelectChemical.GetNewIndex(), Convert.ToInt32(HazmatCL.HazmatChemicalDetail["chemical_detail_id"]));
					if (Convert.ToDouble(HazmatCL.HazmatChemicalDetail["chemical_detail_id"]) == lChemicalDetailID)
					{
						HazmatCL.GetHazmatChemicalDetail(Convert.ToInt32(HazmatCL.HazmatChemicalDetail["chemical_detail_id"]));
						for (int i = 0; i <= ViewModel.cboCommonChemicals.Items.Count - 1; i++)
						{
							if ( ViewModel.cboCommonChemicals.GetItemData(i) == HazmatCL.CDChemicalID)
							{
								ViewModel.cboCommonChemicals.SelectedIndex = i; // This will trigger selecting the other chem combos

								break;
							}
						}
						for (int i = 0; i <= ViewModel.cboChemicalName.Items.Count - 1; i++)
						{
							if ( ViewModel.cboChemicalName.GetItemData(i) == HazmatCL.CDChemicalID)
							{
								ViewModel.cboChemicalName.SelectedIndex = i;
								break;
							}
						}
						for (int i = 0; i <= ViewModel.cboUN.Items.Count - 1; i++)
						{
							if ( ViewModel.cboUN.GetItemData(i) == HazmatCL.CDChemicalID)
							{
								ViewModel.cboUN.SelectedIndex = i;
								break;
							}
						}
						for (int i = 0; i <= ViewModel.cboContainerType.Items.Count - 1; i++)
						{
							if ( ViewModel.cboContainerType.GetItemData(i) == HazmatCL.ContainerTypeCode)
							{
								ViewModel.cboContainerType.SelectedIndex = i;
								break;
							}
						}
						for (int i = 0; i <= ViewModel.cboContainerCapacityUnits.Items.Count - 1; i++)
						{
							if ( ViewModel.cboContainerCapacityUnits.GetItemData(i) == HazmatCL.ContainerCapacityUnits)
							{
								ViewModel.cboContainerCapacityUnits.SelectedIndex = i;
								break;
							}
						}
						ViewModel.txtEstContainerCapacity.Text = HazmatCL.ContainerCapacity.ToString();
						for (int i = 0; i <= ViewModel.cboAmountReleasedUnits.Items.Count - 1; i++)
						{
							if ( ViewModel.cboAmountReleasedUnits.GetItemData(i) == HazmatCL.AmountReleasedUnits)
							{
								ViewModel.cboAmountReleasedUnits.SelectedIndex = i;
								break;
							}
						}
						ViewModel.txtEstAmountReleased.Text = HazmatCL.AmountReleased.ToString();
						for (int i = 0; i <= ViewModel.cboPhysicalStateStored.Items.Count - 1; i++)
						{
							if ( ViewModel.cboPhysicalStateStored.GetItemData(i) == HazmatCL.PhysicalStateStored)
							{
								ViewModel.cboPhysicalStateStored.SelectedIndex = i;
								break;
							}
						}
						for (int i = 0; i <= ViewModel.cboPhysicalStateReleased.Items.Count - 1; i++)
						{
							if ( ViewModel.cboPhysicalStateReleased.GetItemData(i) == HazmatCL.PhysicalStateReleased)
							{
								ViewModel.cboPhysicalStateReleased.SelectedIndex = i;
								break;
							}
						}
						for (int i = 0; i <= ViewModel.cboPrimaryReleasedInto.Items.Count - 1; i++)
						{
							if ( ViewModel.cboPrimaryReleasedInto.GetItemData(i) == HazmatCL.PrimaryReleasedInto)
							{
								ViewModel.cboPrimaryReleasedInto.SelectedIndex = i;
								break;
							}
						}
						for (int i = 0; i <= ViewModel.cboSecondaryReleasedInto.Items.Count - 1; i++)
						{
							if ( ViewModel.cboSecondaryReleasedInto.GetItemData(i) == HazmatCL.SecondaryReleasedInto)
							{
								ViewModel.cboSecondaryReleasedInto.SelectedIndex = i;
								break;
							}
						}
					}
					HazmatCL.HazmatChemicalDetail.MoveNext();
				};
			}
			ViewModel.FirstTime = 0;
			ViewModel.ChemicalDetailUpdated = 0;
			CheckComplete();

		}

		private void GetHazmatData()
		{
			//Retrieve Data for this record
			TFDIncident.clsHazmat HazmatCL = Container.Resolve< clsHazmat>();
			TFDIncident.clsFireCodes FireCodes = Container.Resolve< clsFireCodes>();
			TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();
			int PropClass = 0;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
			this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.WaitCursor);
			//Format Tabs
			switch( ViewModel.CurrReport)
			{
				case IncidentMain.HAZMATDL :
					ViewModel.tabHazmat.Items[1].Text = "";
					ViewModel.tabHazmat.Items[2].Text = "";
					break;
				case IncidentMain.HAZMATFIXED : case IncidentMain.HAZMATMOBILE :
					ViewModel.tabHazmat.Items[3].Text = "";
					break;
			}


			//Drug Lab
			if ( ViewModel.CurrReport == IncidentMain.HAZMATDL || ViewModel.CurrReport == IncidentMain.HAZMATDLRELEASE)
			{
				//Load DrugLab Data
				if (~HazmatCL.GetHazmatDrugLab(ViewModel.HazmatDLID) != 0)
				{
					ViewManager.ShowMessage("Error Retrieving Hazmat Drug Lab Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				}
				else
				{
					for (int i = 0; i <= ViewModel.cboDrugLabType.Items.Count - 1; i++)
					{
						if ( ViewModel.cboDrugLabType.GetItemData(i) == HazmatCL.DrugLabType)
						{
							ViewModel.cboDrugLabType.SelectedIndex = i;
							break;
						}
					}
					for (int i = 0; i <= ViewModel.cboIncidentType.Items.Count - 1; i++)
					{
						if ( ViewModel.cboIncidentType.GetItemData(i) == IncidentMain.HAZMATDLTYPE)
						{ // IncidentType Hazmat Drug Lab (71)

							ViewModel.cboIncidentType.SelectedIndex = i;
							break;
						}
					}
					for (int i = 0; i <= ViewModel.cboHazmatIDSource.Items.Count - 1; i++)
					{
						if ( ViewModel.cboHazmatIDSource.GetItemData(i) == HazmatCL.DLHazmatIDSource)
						{
							ViewModel.cboHazmatIDSource.SelectedIndex = i;
							break;
						}
					}
					for (int i = 0; i <= ViewModel.cboDisposition.Items.Count - 1; i++)
					{
						if ( ViewModel.cboDisposition.GetItemData(i) == HazmatCL.DLDispositionOfRelease)
						{
							ViewModel.cboDisposition.SelectedIndex = i;
							break;
						}
					}
					//Fire Service Materials Used
					LoadMaterialUsed();
					if ( ViewModel.CurrReport == IncidentMain.HAZMATDL)
					{
						LoadOutsideResource();
						//Actions taken
						if (HazmatCL.GetHazmatDrugLabActionTakenRS(ViewModel.HazmatDLID) != 0)
						{

							while(!HazmatCL.HazmatDLActionTaken.EOF)
							{
								for (int i = 0; i <= ViewModel.lstActionsTaken.Items.Count - 1; i++)
								{
									if ( ViewModel.lstActionsTaken.GetItemData(i) == Convert.ToDouble(HazmatCL.HazmatDLActionTaken["unit_action_code"]))
									{
										UpgradeHelpers.Helpers.ListBoxHelper.SetSelected(ViewModel.lstActionsTaken, i, true);
										break;
									}
								}
								HazmatCL.HazmatDLActionTaken.MoveNext();
							};
						}
					}
				}
			}

			//Release
			if ( ViewModel.CurrReport != IncidentMain.HAZMATDL)
			{
				if (~HazmatCL.GetHazmatRelease(ViewModel.HazmatID) != 0)
				{
					ViewManager.ShowMessage("Error Retrieving Hazmat Release Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				}
				else
				{
					for (int i = 0; i <= ViewModel.cboIncidentType.Items.Count - 1; i++)
					{
						if ( ViewModel.cboIncidentType.GetItemData(i) == HazmatCL.IncidentTypeCode)
						{ // IncidentType Hazmat Drug Lab (71)

							ViewModel.cboIncidentType.SelectedIndex = i;
							break;
						}
					}
					for (int i = 0; i <= ViewModel.cboHazmatIDSource.Items.Count - 1; i++)
					{
						if ( ViewModel.cboHazmatIDSource.GetItemData(i) == HazmatCL.HazmatIDSource)
						{
							ViewModel.cboHazmatIDSource.SelectedIndex = i;
							break;
						}
					}
					for (int i = 0; i <= ViewModel.cboDisposition.Items.Count - 1; i++)
					{
						if ( ViewModel.cboDisposition.GetItemData(i) == HazmatCL.DispositionOfRelease)
						{
							ViewModel.cboDisposition.SelectedIndex = i;
							break;
						}
					}
					//Actions taken
					if (HazmatCL.GetHazmatActionTakenRS(ViewModel.HazmatID) != 0)
					{

						while(!HazmatCL.HazmatActionTaken.EOF)
						{
							for (int i = 0; i <= ViewModel.lstActionsTaken.Items.Count - 1; i++)
							{
								if ( ViewModel.lstActionsTaken.GetItemData(i) == Convert.ToDouble(HazmatCL.HazmatActionTaken["unit_action_code"]))
								{
									UpgradeHelpers.Helpers.ListBoxHelper.SetSelected(ViewModel.lstActionsTaken, i, true);
									break;
								}
							}
							HazmatCL.HazmatActionTaken.MoveNext();
						};
					}
					LoadOutsideResource();
					if (FireCodes.GetPropertyUseByCode(HazmatCL.PropertyUse) != 0)
					{
						FireCodes.PropertyUse.Open();
						if (!FireCodes.PropertyUse.EOF)
						{
							PropClass = Convert.ToInt32(FireCodes.PropertyUse["property_use_class"]);

							while(!FireCodes.PropertyUse.EOF)
							{
								ViewModel.cboSpecificPropertyUse.AddItem(Convert.ToString(FireCodes.PropertyUse["description"]));
								ViewModel.cboSpecificPropertyUse.SetItemData(ViewModel.cboSpecificPropertyUse.GetNewIndex(), Convert.ToInt32(FireCodes.PropertyUse["property_use_code"]));
								FireCodes.PropertyUse.MoveNext();
							};
							//Set Values
							for (int i = 0; i <= ViewModel.cboGeneralPropertyUse.Items.Count - 1; i++)
							{
								if ( ViewModel.cboGeneralPropertyUse.GetItemData(i) == PropClass)
								{
									ViewModel.cboGeneralPropertyUse.SelectedIndex = i;
									break;
								}
							}
							for (int i = 0; i <= ViewModel.cboSpecificPropertyUse.Items.Count - 1; i++)
							{
								if ( ViewModel.cboSpecificPropertyUse.GetItemData(i) == HazmatCL.PropertyUse)
								{
									ViewModel.cboSpecificPropertyUse.SelectedIndex = i;
									break;
								}
							}


							while(!FireCodes.AreaOfOrigin.EOF)
							{
								ViewModel.cboAreaOfOrigin.AddItem(Convert.ToString(FireCodes.AreaOfOrigin["description"]));
								ViewModel.cboAreaOfOrigin.SetItemData(ViewModel.cboAreaOfOrigin.GetNewIndex(), Convert.ToInt32(FireCodes.AreaOfOrigin["area_of_origin_code"]));
								FireCodes.AreaOfOrigin.MoveNext();
							};
							//Set Values
							for (int i = 0; i <= ViewModel.cboAreaOfOrigin.Items.Count - 1; i++)
							{
								if ( ViewModel.cboAreaOfOrigin.GetItemData(i) == HazmatCL.AreaOfOrigin)
								{
									ViewModel.cboAreaOfOrigin.SelectedIndex = i;
									break;
								}
							}
						}
					}
					for (int i = 0; i <= ViewModel.cboCauseOfRelease.Items.Count - 1; i++)
					{
						if ( ViewModel.cboCauseOfRelease.GetItemData(i) == HazmatCL.CauseOfRelease)
						{
							ViewModel.cboCauseOfRelease.SelectedIndex = i;
							break;
						}
					}
					for (int i = 0; i <= ViewModel.cboStreetClass.Items.Count - 1; i++)
					{
						if ( ViewModel.cboStreetClass.GetItemData(i) == HazmatCL.StreetClass)
						{
							ViewModel.cboStreetClass.SelectedIndex = i;
							break;
						}
					}
					ViewModel.txtReleaseFloor.Text = HazmatCL.ReleaseFloor.ToString();
					if (HazmatCL.OccuredFirst == 1)
					{
						ViewModel.optOccurredFirst[0].Checked = true;
					}
					else if (HazmatCL.OccuredFirst == 4)
					{
						ViewModel.optOccurredFirst[1].Checked = true;
					}
					else if (HazmatCL.OccuredFirst == 2)
					{
						ViewModel.optOccurredFirst[2].Checked = true;
					}
					else
					{
						ViewModel.optOccurredFirst[0].Checked = false;
						ViewModel.optOccurredFirst[1].Checked = false;
						ViewModel.optOccurredFirst[2].Checked = false;
					}
					for (int i = 0; i <= ViewModel.cboAreaAffectedUnits.Items.Count - 1; i++)
					{
						if ( ViewModel.cboAreaAffectedUnits.GetItemData(i) == HazmatCL.EffectedAreaUnit)
						{
							ViewModel.cboAreaAffectedUnits.SelectedIndex = i;
							break;
						}
					}
					ViewModel.txtAreaAffected.Text = HazmatCL.AreaEffected.ToString();
					for (int i = 0; i <= ViewModel.cboAreaEvacuatedUnits.Items.Count - 1; i++)
					{
						if ( ViewModel.cboAreaEvacuatedUnits.GetItemData(i) == HazmatCL.EvacuatedAreaUnit)
						{
							ViewModel.cboAreaEvacuatedUnits.SelectedIndex = i;
							break;
						}
					}
					ViewModel.txtAreaEvacuated.Text = HazmatCL.AreaEvacuated.ToString();
					for (int i = 0; i <= ViewModel.cboPopulationDensity.Items.Count - 1; i++)
					{
						if ( ViewModel.cboPopulationDensity.GetItemData(i) == HazmatCL.PopulationDensity)
						{
							ViewModel.cboPopulationDensity.SelectedIndex = i;
							break;
						}
					}
					ViewModel.txtPeopleEvacuated.Text = HazmatCL.PeopleEvacuated.ToString();
					ViewModel.txtBuildingsEvacuated.Text = HazmatCL.BuildingsEvacuated.ToString();
					if (HazmatCL.GetHazmatContributingFactor(ViewModel.HazmatID) != 0)
					{

						while(!HazmatCL.HazmatContributingFactorRS.EOF)
						{
							for (int i = 0; i <= ViewModel.lstContributingFactors.Items.Count - 1; i++)
							{
								if ( ViewModel.lstContributingFactors.GetItemData(i) == Convert.ToDouble(HazmatCL.HazmatContributingFactorRS["hazmat_contributing_factor_code"]))
								{
									UpgradeHelpers.Helpers.ListBoxHelper.SetSelected(ViewModel.lstContributingFactors, i, true);
									break;
								}
							}
							HazmatCL.HazmatContributingFactorRS.MoveNext();
						};
					}
					if (HazmatCL.GetHazmatMitigatingFactor(ViewModel.HazmatID) != 0)
					{

						while(!HazmatCL.HazmatMitigatingFactorRS.EOF)
						{
							for (int i = 0; i <= ViewModel.lstMitigatingFactors.Items.Count - 1; i++)
							{
								if ( ViewModel.lstMitigatingFactors.GetItemData(i) == Convert.ToDouble(HazmatCL.HazmatMitigatingFactorRS["hazmat_mitigating_factor_code"]))
								{
									UpgradeHelpers.Helpers.ListBoxHelper.SetSelected(ViewModel.lstMitigatingFactors, i, true);
									break;
								}
							}
							HazmatCL.HazmatMitigatingFactorRS.MoveNext();
						};
					}
					if (HazmatCL.GetHazmatEquipmentInvolved(ViewModel.HazmatID) != 0)
					{

						while(!HazmatCL.HazmatEquipmentInvolvedRS.EOF)
						{
							for (int i = 0; i <= ViewModel.lstEquipmentInvolved.Items.Count - 1; i++)
							{
								if ( ViewModel.lstEquipmentInvolved.GetItemData(i) == Convert.ToDouble(HazmatCL.HazmatEquipmentInvolvedRS["hazmat_equipment_involved_code"]))
								{
									UpgradeHelpers.Helpers.ListBoxHelper.SetSelected(ViewModel.lstEquipmentInvolved, i, true);
									break;
								}
							}
							HazmatCL.HazmatEquipmentInvolvedRS.MoveNext();
						};
					}

					//Chemical Detail
					LoadChemicalDetail(0);
				}
			}

			//Narration
			LoadNarration(0);
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
			this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.Arrow);

		}

		private void LoadChemicalLists()
		{
			//Load Code data into frmChemicalDetail Controls
			TFDIncident.clsHazmat HazmatCL = Container.Resolve< clsHazmat>();
			TFDIncident.clsCommonCodes CommonCodes = Container.Resolve< clsCommonCodes>();
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
			this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.WaitCursor); //Hour Glass

			ViewModel.cboCommonChemicals.Items.Clear();
			ViewModel.cboChemicalName.Items.Clear();
			ViewModel.cboUN.Items.Clear();

			HazmatCL.GetChemicals();

			while(!HazmatCL.Chemicals.EOF)
			{
				ViewModel.cboChemicalName.AddItem(IncidentMain.Clean(HazmatCL.Chemicals["chemical_name"]));
				ViewModel.cboChemicalName.SetItemData(ViewModel.cboChemicalName.GetNewIndex(), Convert.ToInt32(HazmatCL.Chemicals["chemical_id"]));
				ViewModel.cboUN.AddItem(IncidentMain.Clean(HazmatCL.Chemicals["unno"]));
				ViewModel.cboUN.SetItemData(ViewModel.cboUN.GetNewIndex(), Convert.ToInt32(HazmatCL.Chemicals["chemical_id"]));
				HazmatCL.Chemicals.MoveNext();
			}
			;
			HazmatCL.GetCommonChemicals();

			while(!HazmatCL.Chemicals.EOF)
			{
				ViewModel.cboCommonChemicals.AddItem(IncidentMain.Clean(HazmatCL.Chemicals["chemical_name"]));
				ViewModel.cboCommonChemicals.SetItemData(ViewModel.cboCommonChemicals.GetNewIndex(), Convert.ToInt32(HazmatCL.Chemicals["chemical_id"]));
				HazmatCL.Chemicals.MoveNext();
			}
			;
			ViewModel.cboContainerType.Items.Clear();
			CommonCodes.GetContainerType();

			while(!CommonCodes.ContainerType.EOF)
			{
				ViewModel.cboContainerType.AddItem(IncidentMain.Clean(CommonCodes.ContainerType["description"]));
				ViewModel.cboContainerType.SetItemData(ViewModel.cboContainerType.GetNewIndex(), Convert.ToInt32(CommonCodes.ContainerType["container_type_code"]));
				CommonCodes.ContainerType.MoveNext();
			}
			;
			ViewModel.cboContainerCapacityUnits.Items.Clear();
			ViewModel.cboAmountReleasedUnits.Items.Clear();
			CommonCodes.GetCapacityUnits();

			while(!CommonCodes.CapacityUnit.EOF)
			{
				ViewModel.cboContainerCapacityUnits.AddItem(IncidentMain.Clean(CommonCodes.CapacityUnit["description"]));
				ViewModel.cboContainerCapacityUnits.SetItemData(ViewModel.cboContainerCapacityUnits.GetNewIndex(), Convert.ToInt32(CommonCodes.CapacityUnit["capacity_unit_code"]));
				ViewModel.cboAmountReleasedUnits.AddItem(IncidentMain.Clean(CommonCodes.CapacityUnit["description"]));
				ViewModel.cboAmountReleasedUnits.SetItemData(ViewModel.cboAmountReleasedUnits.GetNewIndex(), Convert.ToInt32(CommonCodes.CapacityUnit["capacity_unit_code"]));
				CommonCodes.CapacityUnit.MoveNext();
			}
			;
			ViewModel.cboPhysicalStateStored.Items.Clear();
			ViewModel.cboPhysicalStateReleased.Items.Clear();
			HazmatCL.GetPhysicalStateCode();

			while(!HazmatCL.PhysicalStateCode.EOF)
			{
				ViewModel.cboPhysicalStateStored.AddItem(IncidentMain.Clean(HazmatCL.PhysicalStateCode["description"]));
				ViewModel.cboPhysicalStateStored.SetItemData(ViewModel.cboPhysicalStateStored.GetNewIndex(), Convert.ToInt32(HazmatCL.PhysicalStateCode["physical_state_code"]));
				ViewModel.cboPhysicalStateReleased.AddItem(IncidentMain.Clean(HazmatCL.PhysicalStateCode["description"]));
				ViewModel.cboPhysicalStateReleased.SetItemData(ViewModel.cboPhysicalStateReleased.GetNewIndex(), Convert.ToInt32(HazmatCL.PhysicalStateCode["physical_state_code"]));
				HazmatCL.PhysicalStateCode.MoveNext();
			}
			;
			ViewModel.cboPrimaryReleasedInto.Items.Clear();
			ViewModel.cboSecondaryReleasedInto.Items.Clear();
			HazmatCL.GetReleasedIntoCode();

			while(!HazmatCL.ReleasedIntoCode.EOF)
			{
				ViewModel.cboPrimaryReleasedInto.AddItem(IncidentMain.Clean(HazmatCL.ReleasedIntoCode["description"]));
				ViewModel.cboPrimaryReleasedInto.SetItemData(ViewModel.cboPrimaryReleasedInto.GetNewIndex(), Convert.ToInt32(HazmatCL.ReleasedIntoCode["released_into_code"]));
				ViewModel.cboSecondaryReleasedInto.AddItem(IncidentMain.Clean(HazmatCL.ReleasedIntoCode["description"]));
				ViewModel.cboSecondaryReleasedInto.SetItemData(ViewModel.cboSecondaryReleasedInto.GetNewIndex(), Convert.ToInt32(HazmatCL.ReleasedIntoCode["released_into_code"]));
				HazmatCL.ReleasedIntoCode.MoveNext();
			}
			;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
			this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.Arrow); //Regular

		}

		private void LoadOutsideResource()
		{
			//load OutsideResource list box with existing records
			TFDIncident.clsHazmat HazmatCL = Container.Resolve< clsHazmat>();
			string sDisplay = "";
			ViewModel.lstOutsideResource.Items.Clear();

			if ( ViewModel.CurrReport == IncidentMain.HAZMATDL)
			{
				if (HazmatCL.GetHazmatDLOutsideResource(ViewModel.HazmatDLID) != 0)
				{

					while(!HazmatCL.HazmatDLOutsideResourceRS.EOF)
					{
						sDisplay = IncidentMain.Clean(HazmatCL.HazmatDLOutsideResourceRS["or_description"]) + " - ";
						sDisplay = sDisplay + IncidentMain.Clean(HazmatCL.HazmatDLOutsideResourceRS["ru_description"]);
						ViewModel.lstOutsideResource.AddItem(sDisplay);
						ViewModel.lstOutsideResource.SetItemData(ViewModel.lstOutsideResource.GetNewIndex(), Convert.ToInt32(HazmatCL.HazmatDLOutsideResourceRS["outside_resource"]));
						HazmatCL.HazmatDLOutsideResourceRS.MoveNext();
					};
					ViewModel.cmdRemoveResource.Enabled = true;
				}
				else
				{
					ViewModel.cmdRemoveResource.Enabled = false;
				}
			}
			else
			{
				if (HazmatCL.GetHazmatOutsideResource(ViewModel.HazmatID) != 0)
				{

					while(!HazmatCL.HazmatOutsideResourceRS.EOF)
					{
						sDisplay = IncidentMain.Clean(HazmatCL.HazmatOutsideResourceRS["or_description"]) + " - ";
						sDisplay = sDisplay + IncidentMain.Clean(HazmatCL.HazmatOutsideResourceRS["ru_description"]);
						ViewModel.lstOutsideResource.AddItem(sDisplay);
						ViewModel.lstOutsideResource.SetItemData(ViewModel.lstOutsideResource.GetNewIndex(), Convert.ToInt32(HazmatCL.HazmatOutsideResourceRS["outside_resource"]));
						HazmatCL.HazmatOutsideResourceRS.MoveNext();
					};
					ViewModel.cmdRemoveResource.Enabled = true;
				}
				else
				{
					ViewModel.cmdRemoveResource.Enabled = false;
				}
			}


		}

		private void LoadMaterialUsed()
		{
			//Load Material Used listbox with existing records
			TFDIncident.clsHazmat HazmatCL = Container.Resolve< clsHazmat>();
			string sDisplay = "";
			ViewModel.lstMaterialUsed.Items.Clear();
			if (HazmatCL.GetHazmatFireServiceMaterialsUsed(ViewModel.HazmatDLID) != 0)
			{

				while(!HazmatCL.HazmatFireServiceMaterialsUsedRS.EOF)
				{
					sDisplay = IncidentMain.Clean(HazmatCL.HazmatFireServiceMaterialsUsedRS["description"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					sDisplay = sDisplay + " - " + Convert.ToString(IncidentMain.GetVal(HazmatCL.HazmatFireServiceMaterialsUsedRS["material_quantity"]));
					ViewModel.lstMaterialUsed.AddItem(sDisplay);
					ViewModel.lstMaterialUsed.SetItemData(ViewModel.lstMaterialUsed.GetNewIndex(), Convert.ToInt32(HazmatCL.HazmatFireServiceMaterialsUsedRS["material_code"]));
					HazmatCL.HazmatFireServiceMaterialsUsedRS.MoveNext();
				};
				ViewModel.cmdRemoveMaterial.Enabled = true;
			}
			else
			{
				ViewModel.cmdRemoveMaterial.Enabled = false;
			}

		}

		private void LoadLists()
		{
			//Load combo and listboxes with code table data
			TFDIncident.clsHazmat HazmatCL = Container.Resolve< clsHazmat>();
			TFDIncident.clsUnit UnitCL = Container.Resolve< clsUnit>();
			TFDIncident.clsCommonCodes CommonCodes = Container.Resolve< clsCommonCodes>();
			TFDIncident.clsFireCodes FireCodes = Container.Resolve< clsFireCodes>();
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
			this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.WaitCursor);
			ViewModel.FirstTime = -1;
			ViewModel.cboIncidentType.Items.Clear();
			CommonCodes.GetIncidentTypeCodeByClass(3); //Hazmat

			while(!CommonCodes.IncidentType.EOF)
			{
				ViewModel.cboIncidentType.AddItem(IncidentMain.Clean(CommonCodes.IncidentType["description"]));
				ViewModel.cboIncidentType.SetItemData(ViewModel.cboIncidentType.GetNewIndex(), Convert.ToInt32(CommonCodes.IncidentType["incident_type_code"]));
				CommonCodes.IncidentType.MoveNext();
			}
			;
			ViewModel.cboHazmatIDSource.Items.Clear();
			HazmatCL.GetHazmatIDSourceCode();

			while(!HazmatCL.HazmatIDSourceCode.EOF)
			{
				ViewModel.cboHazmatIDSource.AddItem(IncidentMain.Clean(HazmatCL.HazmatIDSourceCode["description"]));
				ViewModel.cboHazmatIDSource.SetItemData(ViewModel.cboHazmatIDSource.GetNewIndex(), Convert.ToInt32(HazmatCL.HazmatIDSourceCode["hazmat_id_source_code"]));
				HazmatCL.HazmatIDSourceCode.MoveNext();
			}
			;
			ViewModel.lstActionsTaken.Items.Clear();
			CommonCodes.GetUnitActionCodeByClass(2);

			while(!CommonCodes.UnitAction.EOF)
			{
				ViewModel.lstActionsTaken.AddItem(IncidentMain.Clean(CommonCodes.UnitAction["description"]));
				ViewModel.lstActionsTaken.SetItemData(ViewModel.lstActionsTaken.GetNewIndex(), Convert.ToInt32(CommonCodes.UnitAction["unit_action_code"]));
				CommonCodes.UnitAction.MoveNext();
			}
			;
			ViewModel.cboDisposition.Items.Clear();
			HazmatCL.GetDispositionOfReleaseCode();

			while(!HazmatCL.DispositionOfReleaseCode.EOF)
			{
				ViewModel.cboDisposition.AddItem(IncidentMain.Clean(HazmatCL.DispositionOfReleaseCode["description"]));
				ViewModel.cboDisposition.SetItemData(ViewModel.cboDisposition.GetNewIndex(), Convert.ToInt32(HazmatCL.DispositionOfReleaseCode["disposition_of_release_code"]));
				HazmatCL.DispositionOfReleaseCode.MoveNext();
			}
			;
			ViewModel.cboOutsideResource.Items.Clear();
			HazmatCL.GetOutsideResourceCode();

			while(!HazmatCL.OutsideResourceCode.EOF)
			{
				ViewModel.cboOutsideResource.AddItem(IncidentMain.Clean(HazmatCL.OutsideResourceCode["description"]));
				ViewModel.cboOutsideResource.SetItemData(ViewModel.cboOutsideResource.GetNewIndex(), Convert.ToInt32(HazmatCL.OutsideResourceCode["outside_resource_code"]));
				HazmatCL.OutsideResourceCode.MoveNext();
			}
			;
			ViewModel.cboResourceUse.Items.Clear();
			HazmatCL.GetResourceUseCode();

			while(!HazmatCL.ResourceUseCode.EOF)
			{
				ViewModel.cboResourceUse.AddItem(IncidentMain.Clean(HazmatCL.ResourceUseCode["description"]));
				ViewModel.cboResourceUse.SetItemData(ViewModel.cboResourceUse.GetNewIndex(), Convert.ToInt32(HazmatCL.ResourceUseCode["resource_use_code"]));
				HazmatCL.ResourceUseCode.MoveNext();
			}
			;
			ViewModel.rtxNarration.Text = "";

			if ( ViewModel.CurrReport == IncidentMain.HAZMATDL || ViewModel.CurrReport == IncidentMain.HAZMATDLRELEASE)
			{
				ViewModel.cboDrugLabType.Items.Clear();
				HazmatCL.GetHazmatDrugLabCode();

				while(!HazmatCL.HazmatDrugLabCode.EOF)
				{
					ViewModel.cboDrugLabType.AddItem(IncidentMain.Clean(HazmatCL.HazmatDrugLabCode["description"]));
					ViewModel.cboDrugLabType.SetItemData(ViewModel.cboDrugLabType.GetNewIndex(), Convert.ToInt32(HazmatCL.HazmatDrugLabCode["drug_lab_type_code"]));
					HazmatCL.HazmatDrugLabCode.MoveNext();
				}
				;
				ViewModel.cboMaterialUsed.Items.Clear();
				HazmatCL.GetFireServiceMaterialCode();

				while(!HazmatCL.FireServiceMaterialCode.EOF)
				{
					ViewModel.cboMaterialUsed.AddItem(IncidentMain.Clean(HazmatCL.FireServiceMaterialCode["description"]));
					ViewModel.cboMaterialUsed.SetItemData(ViewModel.cboMaterialUsed.GetNewIndex(), Convert.ToInt32(HazmatCL.FireServiceMaterialCode["fire_service_material_code"]));
					HazmatCL.FireServiceMaterialCode.MoveNext();
				}
				;
							}
			if ( ViewModel.CurrReport != IncidentMain.HAZMATDL)
			{
				ViewModel.cboGeneralPropertyUse.Items.Clear();
				FireCodes.GetPropertyUseClass();

				while(!FireCodes.PropertyUseClassRS.EOF)
				{
					ViewModel.cboGeneralPropertyUse.AddItem(IncidentMain.Clean(FireCodes.PropertyUseClassRS["class_description"]));
					ViewModel.cboGeneralPropertyUse.SetItemData(ViewModel.cboGeneralPropertyUse.GetNewIndex(), Convert.ToInt32(FireCodes.PropertyUseClassRS["property_use_class"]));
					FireCodes.PropertyUseClassRS.MoveNext();
				}
				;
				ViewModel.cboSpecificPropertyUse.Items.Clear();
				ViewModel.cboAreaOfOrigin.Items.Clear();
				ViewModel.cboStreetClass.Items.Clear();
				HazmatCL.GetStreetClassCode();

				while(!HazmatCL.StreetClassCode.EOF)
				{
					ViewModel.cboStreetClass.AddItem(IncidentMain.Clean(HazmatCL.StreetClassCode["description"]));
					ViewModel.cboStreetClass.SetItemData(ViewModel.cboStreetClass.GetNewIndex(), Convert.ToInt32(HazmatCL.StreetClassCode["street_class_code"]));
					HazmatCL.StreetClassCode.MoveNext();
				}
				;
				ViewModel.cboCauseOfRelease.Items.Clear();
				HazmatCL.GetCauseOfReleaseCode();

				while(!HazmatCL.CauseOfReleaseCode.EOF)
				{
					ViewModel.cboCauseOfRelease.AddItem(IncidentMain.Clean(HazmatCL.CauseOfReleaseCode["description"]));
					ViewModel.cboCauseOfRelease.SetItemData(ViewModel.cboCauseOfRelease.GetNewIndex(), Convert.ToInt32(HazmatCL.CauseOfReleaseCode["cause_of_release_code"]));
					HazmatCL.CauseOfReleaseCode.MoveNext();
				}
				;
				ViewModel.cboAreaAffectedUnits.Items.Clear();
				ViewModel.cboAreaEvacuatedUnits.Items.Clear();
				CommonCodes.GetAreaUnits();

				while(!CommonCodes.AreaUnits.EOF)
				{
					ViewModel.cboAreaAffectedUnits.AddItem(IncidentMain.Clean(CommonCodes.AreaUnits["area_description"]));
					ViewModel.cboAreaAffectedUnits.SetItemData(ViewModel.cboAreaAffectedUnits.GetNewIndex(), Convert.ToInt32(CommonCodes.AreaUnits["area_unit_code"]));
					ViewModel.cboAreaEvacuatedUnits.AddItem(IncidentMain.Clean(CommonCodes.AreaUnits["area_description"]));
					ViewModel.cboAreaEvacuatedUnits.SetItemData(ViewModel.cboAreaEvacuatedUnits.GetNewIndex(), Convert.ToInt32(CommonCodes.AreaUnits["area_unit_code"]));
					CommonCodes.AreaUnits.MoveNext();
				}
				;
				ViewModel.cboPopulationDensity.Items.Clear();
				CommonCodes.GetPopulationDensity();

				while(!CommonCodes.PopulationDensity.EOF)
				{
					ViewModel.cboPopulationDensity.AddItem(IncidentMain.Clean(CommonCodes.PopulationDensity["description"]));
					ViewModel.cboPopulationDensity.SetItemData(ViewModel.cboPopulationDensity.GetNewIndex(), Convert.ToInt32(CommonCodes.PopulationDensity["population_density_code"]));
					CommonCodes.PopulationDensity.MoveNext();
				}
				;
				ViewModel.lstContributingFactors.Items.Clear();
				HazmatCL.GetHazmatContributingFactorCode();

				while(!HazmatCL.HazmatContributingFactorCode.EOF)
				{
					ViewModel.lstContributingFactors.AddItem(IncidentMain.Clean(HazmatCL.HazmatContributingFactorCode["description"]));
					ViewModel.lstContributingFactors.SetItemData(ViewModel.lstContributingFactors.GetNewIndex(), Convert.ToInt32(HazmatCL.HazmatContributingFactorCode["hazmat_contributing_factor_code"]));
					HazmatCL.HazmatContributingFactorCode.MoveNext();
				}
				;
				ViewModel.lstMitigatingFactors.Items.Clear();
				HazmatCL.GetHazmatMitigatingFactorCode();

				while(!HazmatCL.HazmatMitigatingFactorCode.EOF)
				{
					ViewModel.lstMitigatingFactors.AddItem(IncidentMain.Clean(HazmatCL.HazmatMitigatingFactorCode["description"]));
					ViewModel.lstMitigatingFactors.SetItemData(ViewModel.lstMitigatingFactors.GetNewIndex(), Convert.ToInt32(HazmatCL.HazmatMitigatingFactorCode["hazmat_mitigating_factor_code"]));
					HazmatCL.HazmatMitigatingFactorCode.MoveNext();
				}
				;
				ViewModel.lstEquipmentInvolved.Items.Clear();
				HazmatCL.GetHazmatEquipmentInvolvedCode();

				while(!HazmatCL.HazmatEquipmentInvolvedCode.EOF)
				{
					ViewModel.lstEquipmentInvolved.AddItem(IncidentMain.Clean(HazmatCL.HazmatEquipmentInvolvedCode["description"]));
					ViewModel.lstEquipmentInvolved.SetItemData(ViewModel.lstEquipmentInvolved.GetNewIndex(), Convert.ToInt32(HazmatCL.HazmatEquipmentInvolvedCode["hazmat_equipment_involved_code"]));
					HazmatCL.HazmatEquipmentInvolvedCode.MoveNext();
				}
				;
				//Chemicals
				LoadChemicalLists();
			}
			ViewModel.FirstTime = 0;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
			this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.Arrow);
		}


		private int CheckComplete()
		{
			//Check Required Fields for Completion
			int result = 0;
			if ( ViewModel.FirstTime != 0)
			{
				return result;
			}

			result = -1;

			if ( ViewModel.cboHazmatIDSource.SelectedIndex == -1)
			{
				ViewModel.cboHazmatIDSource.BackColor = IncidentMain.Shared.REQCOLOR;
				ViewModel.cboHazmatIDSource.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
				result = 0;
			}
			else
			{
				ViewModel.cboHazmatIDSource.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
				ViewModel.cboHazmatIDSource.ForeColor = IncidentMain.Shared.HAZMATFONT;
			}

			if ( ViewModel.CurrReport == IncidentMain.HAZMATDL)
			{
				if ( ViewModel.cboDrugLabType.SelectedIndex == -1)
				{
					ViewModel.cboDrugLabType.BackColor = IncidentMain.Shared.REQCOLOR;
					ViewModel.cboDrugLabType.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					result = 0;
				}
				else
				{
					ViewModel.cboDrugLabType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					ViewModel.cboDrugLabType.ForeColor = IncidentMain.Shared.HAZMATFONT;
				}
				//Check for status of Add Materials
				double dbNumericTemp = 0;
				if ( ViewModel.cboMaterialUsed.SelectedIndex == -1)
				{
					ViewModel.cmdAddMaterial.Enabled = false;
				}
				else if ( ViewModel.txtQuantity.Text == "")
				{
					ViewModel.cmdAddMaterial.Enabled = false;
				}
				else if (!Double.TryParse(ViewModel.txtQuantity.Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
				{
					ViewModel.cmdAddMaterial.Enabled = false;
					ViewModel.txtQuantity.Text = "";
				}
				else
				{
					ViewModel.cmdAddMaterial.Enabled = true;
				}
			}
			if ( ViewModel.CurrReport != IncidentMain.HAZMATDL)
			{
				if ( ViewModel.CurrReport == IncidentMain.HAZMATFIXED)
				{
					if ( ViewModel.cboGeneralPropertyUse.SelectedIndex == -1)
					{
						ViewModel.cboGeneralPropertyUse.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.cboGeneralPropertyUse.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						result = 0;
					}
					else
					{
						ViewModel.cboGeneralPropertyUse.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboGeneralPropertyUse.ForeColor = IncidentMain.Shared.HAZMATFONT;
					}
					if ( ViewModel.txtReleaseFloor.Text != "")
					{
						double dbNumericTemp2 = 0;
						if (!Double.TryParse(ViewModel.txtReleaseFloor.Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp2))
						{
							ViewModel.txtReleaseFloor.Text = "";
						}
					}
				}
				if ( ViewModel.cboIncidentType.SelectedIndex == -1)
				{
					ViewModel.cboIncidentType.BackColor = IncidentMain.Shared.REQCOLOR;
					ViewModel.cboIncidentType.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					result = 0;
				}
				else
				{
					ViewModel.cboIncidentType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					ViewModel.cboIncidentType.ForeColor = IncidentMain.Shared.HAZMATFONT;
				}
				if ( ViewModel.cboSpecificPropertyUse.SelectedIndex == -1)
				{
					ViewModel.cboSpecificPropertyUse.BackColor = IncidentMain.Shared.REQCOLOR;
					ViewModel.cboSpecificPropertyUse.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					result = 0;
				}
				else
				{
					ViewModel.cboSpecificPropertyUse.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					ViewModel.cboSpecificPropertyUse.ForeColor = IncidentMain.Shared.HAZMATFONT;
				}
				if ( ViewModel.cboAreaOfOrigin.SelectedIndex == -1)
				{
					ViewModel.cboAreaOfOrigin.BackColor = IncidentMain.Shared.REQCOLOR;
					ViewModel.cboAreaOfOrigin.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					result = 0;
				}
				else
				{
					ViewModel.cboAreaOfOrigin.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					ViewModel.cboAreaOfOrigin.ForeColor = IncidentMain.Shared.HAZMATFONT;
				}
				if ( ViewModel.cboCauseOfRelease.SelectedIndex == -1)
				{
					ViewModel.cboCauseOfRelease.BackColor = IncidentMain.Shared.REQCOLOR;
					ViewModel.cboCauseOfRelease.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					result = 0;
				}
				else
				{
					ViewModel.cboCauseOfRelease.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					ViewModel.cboCauseOfRelease.ForeColor = IncidentMain.Shared.HAZMATFONT;
				}
				if ( ViewModel.cboAreaAffectedUnits.SelectedIndex == -1)
				{
					ViewModel.cboAreaAffectedUnits.BackColor = IncidentMain.Shared.REQCOLOR;
					ViewModel.cboAreaAffectedUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					result = 0;
				}
				else
				{
					ViewModel.cboAreaAffectedUnits.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					ViewModel.cboAreaAffectedUnits.ForeColor = IncidentMain.Shared.HAZMATFONT;
				}
				double dbNumericTemp3 = 0;
				if ( ViewModel.txtAreaAffected.Text == "")
				{
					ViewModel.txtAreaAffected.BackColor = IncidentMain.Shared.REQCOLOR;
					ViewModel.txtAreaAffected.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					result = 0;
				}
				else if (!Double.TryParse(ViewModel.txtAreaAffected.Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp3))
				{
					ViewModel.txtAreaAffected.Text = "";
					ViewModel.txtAreaAffected.BackColor = IncidentMain.Shared.REQCOLOR;
					ViewModel.txtAreaAffected.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					result = 0;
				}
				else
				{
					ViewModel.txtAreaAffected.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					ViewModel.txtAreaAffected.ForeColor = IncidentMain.Shared.HAZMATFONT;
				}
				if ( ViewModel.txtAreaEvacuated.Text != "" && ViewModel.txtAreaEvacuated.Text != "0")
				{
					double dbNumericTemp4 = 0;
					if (!Double.TryParse(ViewModel.txtAreaEvacuated.Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp4))
					{
						ViewModel.txtAreaEvacuated.Text = "";
					}
					else
					{
						if ( ViewModel.cboAreaEvacuatedUnits.SelectedIndex == -1)
						{
							ViewModel.cboAreaEvacuatedUnits.BackColor = IncidentMain.Shared.REQCOLOR;
							ViewModel.cboAreaEvacuatedUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							result = 0;
						}
						else
						{
							ViewModel.cboAreaEvacuatedUnits.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.cboAreaEvacuatedUnits.ForeColor = IncidentMain.Shared.HAZMATFONT;
						}
					}
				}
				if ( ViewModel.cboPopulationDensity.SelectedIndex == -1)
				{
					ViewModel.cboPopulationDensity.BackColor = IncidentMain.Shared.REQCOLOR;
					ViewModel.cboPopulationDensity.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					result = 0;
				}
				else
				{
					ViewModel.cboPopulationDensity.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					ViewModel.cboPopulationDensity.ForeColor = IncidentMain.Shared.HAZMATFONT;
				}
				if ( ViewModel.txtPeopleEvacuated.Text != "")
				{
					double dbNumericTemp5 = 0;
					if (!Double.TryParse(ViewModel.txtPeopleEvacuated.Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp5))
					{
						ViewModel.txtPeopleEvacuated.Text = "";
					}
				}
				if ( ViewModel.txtBuildingsEvacuated.Text != "")
				{
					double dbNumericTemp6 = 0;
					if (!Double.TryParse(ViewModel.txtBuildingsEvacuated.Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp6))
					{
						ViewModel.txtBuildingsEvacuated.Text = "";
					}
				}

				//Chemical Detail
				if ( ViewModel.cboCommonChemicals.SelectedIndex == -1 && ViewModel.cboChemicalName.SelectedIndex == -1 && ViewModel.cboUN.SelectedIndex == -1)
				{
					ViewModel.cboCommonChemicals.BackColor = IncidentMain.Shared.REQCOLOR;
					ViewModel.cboCommonChemicals.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					ViewModel.cboChemicalName.BackColor = IncidentMain.Shared.REQCOLOR;
					ViewModel.cboChemicalName.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					ViewModel.cboUN.BackColor = IncidentMain.Shared.REQCOLOR;
					ViewModel.cboUN.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					//don't require detail fields if Chemical not selected
					ViewModel.cboContainerCapacityUnits.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					ViewModel.cboContainerCapacityUnits.ForeColor = IncidentMain.Shared.HAZMATFONT;
					ViewModel.cboContainerType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					ViewModel.cboContainerType.ForeColor = IncidentMain.Shared.HAZMATFONT;
					ViewModel.cboAmountReleasedUnits.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					ViewModel.cboAmountReleasedUnits.ForeColor = IncidentMain.Shared.HAZMATFONT;
					ViewModel.cboPhysicalStateStored.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					ViewModel.cboPhysicalStateStored.ForeColor = IncidentMain.Shared.HAZMATFONT;
					ViewModel.cboPhysicalStateReleased.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					ViewModel.cboPhysicalStateReleased.ForeColor = IncidentMain.Shared.HAZMATFONT;
					ViewModel.cboPrimaryReleasedInto.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					ViewModel.cboPrimaryReleasedInto.ForeColor = IncidentMain.Shared.HAZMATFONT;
					result = 0;
				}
				else
				{
					ViewModel.cboCommonChemicals.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					ViewModel.cboCommonChemicals.ForeColor = IncidentMain.Shared.HAZMATFONT;
					ViewModel.cboChemicalName.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					ViewModel.cboChemicalName.ForeColor = IncidentMain.Shared.HAZMATFONT;
					ViewModel.cboUN.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					ViewModel.cboUN.ForeColor = IncidentMain.Shared.HAZMATFONT;
					//Only Check Other fields if Chemical has been selected
					if ( ViewModel.txtEstContainerCapacity.Text != "" && ViewModel.txtEstContainerCapacity.Text != "0")
					{
						double dbNumericTemp7 = 0;
						if (!Double.TryParse(ViewModel.txtEstContainerCapacity.Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp7))
						{
							ViewModel.txtEstContainerCapacity.Text = "";
							ViewModel.cboContainerCapacityUnits.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.cboContainerCapacityUnits.ForeColor = IncidentMain.Shared.HAZMATFONT;
							ViewModel.cboContainerType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.cboContainerType.ForeColor = IncidentMain.Shared.HAZMATFONT;
						}
						else
						{
							if ( ViewModel.cboContainerCapacityUnits.SelectedIndex == -1)
							{
								ViewModel.cboContainerCapacityUnits.BackColor = IncidentMain.Shared.REQCOLOR;
								ViewModel.cboContainerCapacityUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
								result = 0;
							}
							else
							{
								ViewModel.cboContainerCapacityUnits.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
								ViewModel.cboContainerCapacityUnits.ForeColor = IncidentMain.Shared.HAZMATFONT;
							}
							if ( ViewModel.cboContainerType.SelectedIndex == -1)
							{
								ViewModel.cboContainerType.BackColor = IncidentMain.Shared.REQCOLOR;
								ViewModel.cboContainerType.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
								result = 0;
							}
							else
							{
								ViewModel.cboContainerType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
								ViewModel.cboContainerType.ForeColor = IncidentMain.Shared.HAZMATFONT;
							}
						}
					}
					else
					{
						ViewModel.cboContainerCapacityUnits.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboContainerCapacityUnits.ForeColor = IncidentMain.Shared.HAZMATFONT;
						ViewModel.cboContainerType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboContainerType.ForeColor = IncidentMain.Shared.HAZMATFONT;
					}
					double dbNumericTemp8 = 0;
					if ( ViewModel.txtEstAmountReleased.Text == "")
					{
						ViewModel.txtEstAmountReleased.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.txtEstAmountReleased.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						result = 0;
					}
					else if (!Double.TryParse(ViewModel.txtEstAmountReleased.Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp8))
					{
						ViewModel.txtEstAmountReleased.Text = "";
						ViewModel.txtEstAmountReleased.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.txtEstAmountReleased.ForeColor = IncidentMain.Shared.HAZMATFONT;
						result = 0;
					}
					else
					{
						ViewModel.txtEstAmountReleased.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.txtEstAmountReleased.ForeColor = IncidentMain.Shared.HAZMATFONT;
					}
					if ( ViewModel.cboAmountReleasedUnits.SelectedIndex == -1)
					{
						ViewModel.cboAmountReleasedUnits.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.cboAmountReleasedUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						result = 0;
					}
					else
					{
						ViewModel.cboAmountReleasedUnits.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboAmountReleasedUnits.ForeColor = IncidentMain.Shared.HAZMATFONT;
					}
					if ( ViewModel.cboPhysicalStateStored.SelectedIndex == -1)
					{
						ViewModel.cboPhysicalStateStored.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.cboPhysicalStateStored.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						result = 0;
					}
					else
					{
						ViewModel.cboPhysicalStateStored.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboPhysicalStateStored.ForeColor = IncidentMain.Shared.HAZMATFONT;
					}
					if ( ViewModel.cboPhysicalStateReleased.SelectedIndex == -1)
					{
						ViewModel.cboPhysicalStateReleased.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.cboPhysicalStateReleased.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						result = 0;
					}
					else
					{
						ViewModel.cboPhysicalStateReleased.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboPhysicalStateReleased.ForeColor = IncidentMain.Shared.HAZMATFONT;
					}
					if ( ViewModel.cboPrimaryReleasedInto.SelectedIndex == -1)
					{
						ViewModel.cboPrimaryReleasedInto.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.cboPrimaryReleasedInto.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						result = 0;
					}
					else
					{
						ViewModel.cboPrimaryReleasedInto.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						ViewModel.cboPrimaryReleasedInto.ForeColor = IncidentMain.Shared.HAZMATFONT;
					}
				}
			}

			if ( ViewModel.cboDisposition.SelectedIndex == -1)
			{
				ViewModel.cboDisposition.BackColor = IncidentMain.Shared.REQCOLOR;
				ViewModel.cboDisposition.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
				result = 0;
			}
			else
			{
				ViewModel.cboDisposition.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
				ViewModel.cboDisposition.ForeColor = IncidentMain.Shared.HAZMATFONT;
			}
			ViewModel.cmdSave[0].Enabled = result != 0;

			return result;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboAmountReleasedUnits_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime != 0)
			{
				return;
			}
			ViewModel.ChemicalDetailUpdated = -1;
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboAmountReleasedUnits_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboAmountReleasedUnits.SelectedIndex == -1)
			{
				ViewModel.cboAmountReleasedUnits.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboAreaAffectedUnits_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboAreaAffectedUnits_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboAreaAffectedUnits.SelectedIndex == -1)
			{
				ViewModel.cboAreaAffectedUnits.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboAreaEvacuatedUnits_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboAreaEvacuatedUnits.SelectedIndex == -1)
			{
				ViewModel.cboAreaEvacuatedUnits.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboAreaOfOrigin_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboAreaOfOrigin_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboAreaOfOrigin.SelectedIndex == -1)
			{
				ViewModel.cboAreaOfOrigin.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboCauseOfRelease_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboCauseOfRelease_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboCauseOfRelease.SelectedIndex == -1)
			{
				ViewModel.cboCauseOfRelease.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboChemicalName_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Sync Chemical Selection Combos and save
			//selected Chemical ID in hidden label (lbChemicalID)

			if ( ViewModel.cboChemicalName.SelectedIndex == -1)
			{
				return;
			}
			if ( ViewModel.FirstTime != 0)
			{
				return;
			}
			ViewModel.FirstTime = -1;

			int SelectedChemical = ViewModel.cboChemicalName.GetItemData(ViewModel.cboChemicalName.SelectedIndex);
			ViewModel.lbChemicalID.Text = SelectedChemical.ToString();
			ViewModel.cboCommonChemicals.SelectedIndex = -1;
			for (int i = 0; i <= ViewModel.cboCommonChemicals.Items.Count - 1; i++)
			{
				if ( ViewModel.cboCommonChemicals.GetItemData(i) == SelectedChemical)
				{
					ViewModel.cboCommonChemicals.SelectedIndex = i;
					break;
				}
			}
			for (int i = 0; i <= ViewModel.cboUN.Items.Count - 1; i++)
			{
				if ( ViewModel.cboUN.GetItemData(i) == SelectedChemical)
				{
					ViewModel.cboUN.SelectedIndex = i;
					break;
				}
			}
			ViewModel.FirstTime = 0;
			CheckComplete();
			ViewModel.ChemicalDetailUpdated = -1;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboChemicalName_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboChemicalName.SelectedIndex == -1)
			{
				ViewModel.cboChemicalName.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboCommonChemicals_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Sync Chemical Selection Combos and save
			//selected Chemical ID in hidden label (lbChemicalID)

			if ( ViewModel.cboCommonChemicals.SelectedIndex == -1)
			{
				return;
			}
			if ( ViewModel.FirstTime != 0)
			{
				return;
			}
			ViewModel.FirstTime = -1;

			int SelectedChemical = ViewModel.cboCommonChemicals.GetItemData(ViewModel.cboCommonChemicals.SelectedIndex);
			ViewModel.lbChemicalID.Text = SelectedChemical.ToString();
			for (int i = 0; i <= ViewModel.cboChemicalName.Items.Count - 1; i++)
			{
				if ( ViewModel.cboChemicalName.GetItemData(i) == SelectedChemical)
				{
					ViewModel.cboChemicalName.SelectedIndex = i;
					break;
				}
			}
			for (int i = 0; i <= ViewModel.cboUN.Items.Count - 1; i++)
			{
				if ( ViewModel.cboUN.GetItemData(i) == SelectedChemical)
				{
					ViewModel.cboUN.SelectedIndex = i;
					break;
				}
			}
			ViewModel.FirstTime = 0;
			CheckComplete();
			ViewModel.ChemicalDetailUpdated = -1;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboCommonChemicals_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboCommonChemicals.SelectedIndex == -1)
			{
				ViewModel.cboCommonChemicals.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboContainerCapacityUnits_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime != 0)
			{
				return;
			}
			ViewModel.ChemicalDetailUpdated = -1;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboContainerCapacityUnits_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboContainerCapacityUnits.SelectedIndex == -1)
			{
				ViewModel.cboContainerCapacityUnits.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboContainerType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime != 0)
			{
				return;
			}
			ViewModel.ChemicalDetailUpdated = -1;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboContainerType_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboContainerType.SelectedIndex == -1)
			{
				ViewModel.cboContainerType.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboDisposition_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboDisposition_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboDisposition.SelectedIndex == -1)
			{
				ViewModel.cboDisposition.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboDrugLabType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboDrugLabType_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboDrugLabType.SelectedIndex == -1)
			{
				ViewModel.cboDrugLabType.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboGeneralPropertyUse_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Reload Specific Property Use and Area of Origin Combos
			TFDIncident.clsFireCodes FireCodes = Container.Resolve< clsFireCodes>();
			ViewModel.FirstTime = -1;

			if ( ViewModel.cboGeneralPropertyUse.SelectedIndex == -1)
			{
				return;
			}
			int PropClass = ViewModel.cboGeneralPropertyUse.GetItemData(ViewModel.cboGeneralPropertyUse.SelectedIndex);
			ViewModel.cboSpecificPropertyUse.Items.Clear();
			ViewModel.cboAreaOfOrigin.Items.Clear();
			FireCodes.GetPropertyUseByClass(PropClass);
			FireCodes.PropertyUse.Open();

			while(!FireCodes.PropertyUse.EOF)
			{
				ViewModel.cboSpecificPropertyUse.AddItem(IncidentMain.Clean(FireCodes.PropertyUse["description"]));
				ViewModel.cboSpecificPropertyUse.SetItemData(ViewModel.cboSpecificPropertyUse.GetNewIndex(), Convert.ToInt32(FireCodes.PropertyUse["property_use_code"]));
				FireCodes.PropertyUse.MoveNext();
			}
			;

			while(!FireCodes.AreaOfOrigin.EOF)
			{
				ViewModel.cboAreaOfOrigin.AddItem(IncidentMain.Clean(FireCodes.AreaOfOrigin["description"]));
				ViewModel.cboAreaOfOrigin.SetItemData(ViewModel.cboAreaOfOrigin.GetNewIndex(), Convert.ToInt32(FireCodes.AreaOfOrigin["area_of_origin_code"]));
				FireCodes.AreaOfOrigin.MoveNext();
			}
			;
			ViewModel.FirstTime = 0;
			CheckComplete();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboGeneralPropertyUse_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboGeneralPropertyUse.SelectedIndex == -1)
			{
				ViewModel.cboGeneralPropertyUse.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboHazmatIDSource_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboHazmatIDSource_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboHazmatIDSource.SelectedIndex == -1)
			{
				ViewModel.cboHazmatIDSource.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboIncidentType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboIncidentType_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboIncidentType.SelectedIndex == -1)
			{
				ViewModel.cboIncidentType.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboMaterialUsed_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboMaterialUsed.SelectedIndex == -1)
			{
				ViewModel.cboMaterialUsed.Text = "";
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
			TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();
			TFDIncident.clsPersonnel PersonnelCL = Container.Resolve< clsPersonnel>();

			if ( ViewModel.NarrationUpdated != 0)
			{
				SaveNarration();
			}
			ViewModel.rtxNarration.Text = "";
			ViewModel.lbNarrID.Text = "";
			ViewModel.lbNarrAuthor.Text = "";
			int NarrID = ViewModel.cboNarrList.GetItemData(ViewModel.cboNarrList.SelectedIndex);

			if (IncidentCL.GetNarration(NarrID) != 0)
			{
				ViewModel.lbNarrID.Text = IncidentCL.NarrationID.ToString();
				if (PersonnelCL.GetEmployeeRecord(IncidentMain.Clean(IncidentCL.NarrationBy)) != 0)
				{
					ViewModel.lbNarrAuthor.Text = IncidentMain.Clean(PersonnelCL.Employee["name_full"]);
				}
				ViewModel.rtxNarration.Text = IncidentMain.Clean(IncidentCL.NarrationText);
				ViewModel.rtxNarration.Enabled = !(IncidentCL.NarrationBy != IncidentMain.Shared.gCurrUser);
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboOutsideResource_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Toggle AddResourceButton
			if ( ViewModel.cboOutsideResource.SelectedIndex == -1)
			{
				ViewModel.cmdAddResource.Enabled = false;
			}
			else if ( ViewModel.cboResourceUse.SelectedIndex != -1)
			{
				ViewModel.cmdAddResource.Enabled = true;
			}
			else
			{
				ViewModel.cmdAddResource.Enabled = false;
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboOutsideResource_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboOutsideResource.SelectedIndex == -1)
			{
				ViewModel.cboOutsideResource.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboPhysicalStateReleased_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime != 0)
			{
				return;
			}
			ViewModel.ChemicalDetailUpdated = -1;
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboPhysicalStateReleased_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboPhysicalStateReleased.SelectedIndex == -1)
			{
				ViewModel.cboPhysicalStateReleased.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboPhysicalStateStored_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime != 0)
			{
				return;
			}
			ViewModel.ChemicalDetailUpdated = -1;
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboPhysicalStateStored_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboPhysicalStateStored.SelectedIndex == -1)
			{
				ViewModel.cboPhysicalStateStored.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboPopulationDensity_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboPopulationDensity_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboPopulationDensity.SelectedIndex == -1)
			{
				ViewModel.cboPopulationDensity.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboPrimaryReleasedInto_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime != 0)
			{
				return;
			}
			ViewModel.ChemicalDetailUpdated = -1;
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboPrimaryReleasedInto_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboPrimaryReleasedInto.SelectedIndex == -1)
			{
				ViewModel.cboPrimaryReleasedInto.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboResourceUse_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Toggle AddResourceButton
			if ( ViewModel.cboResourceUse.SelectedIndex == -1)
			{
				ViewModel.cmdAddResource.Enabled = false;
			}
			else if ( ViewModel.cboOutsideResource.SelectedIndex != -1)
			{
				ViewModel.cmdAddResource.Enabled = true;
			}
			else
			{
				ViewModel.cmdAddResource.Enabled = false;
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboResourceUse_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboResourceUse.SelectedIndex == -1)
			{
				ViewModel.cboResourceUse.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboSecondaryReleasedInto_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime != 0)
			{
				return;
			}
			ViewModel.ChemicalDetailUpdated = -1;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboSecondaryReleasedInto_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboSecondaryReleasedInto.SelectedIndex == -1)
			{
				ViewModel.cboSecondaryReleasedInto.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboSelectChemical_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Load Chemical Detail for Selected Record
			if ( ViewModel.cboSelectChemical.SelectedIndex == -1)
			{
				return;
			}
			ViewModel.lbChemDetailID.Text = ViewModel.cboSelectChemical.GetItemData(ViewModel.cboSelectChemical.SelectedIndex).ToString();
			LoadChemicalDetail(ViewModel.cboSelectChemical.GetItemData(ViewModel.cboSelectChemical.SelectedIndex));
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboSelectChemical_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboSelectChemical.SelectedIndex == -1)
			{
				ViewModel.cboSelectChemical.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboSpecificPropertyUse_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboSpecificPropertyUse_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboSpecificPropertyUse.SelectedIndex == -1)
			{
				ViewModel.cboSpecificPropertyUse.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboStreetClass_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboStreetClass.SelectedIndex == -1)
			{
				ViewModel.cboStreetClass.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboUN_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Sync Chemical Selection Combos and save
			//selected Chemical ID in hidden label (lbChemicalID)

			if ( ViewModel.cboUN.SelectedIndex == -1)
			{
				return;
			}
			if ( ViewModel.FirstTime != 0)
			{
				return;
			}
			ViewModel.FirstTime = -1;

			int SelectedChemical = ViewModel.cboUN.GetItemData(ViewModel.cboUN.SelectedIndex);
			ViewModel.lbChemicalID.Text = SelectedChemical.ToString();
			ViewModel.cboCommonChemicals.SelectedIndex = -1;
			for (int i = 0; i <= ViewModel.cboCommonChemicals.Items.Count - 1; i++)
			{
				if ( ViewModel.cboCommonChemicals.GetItemData(i) == SelectedChemical)
				{
					ViewModel.cboCommonChemicals.SelectedIndex = i;
					break;
				}
			}
			for (int i = 0; i <= ViewModel.cboChemicalName.Items.Count - 1; i++)
			{
				if ( ViewModel.cboChemicalName.GetItemData(i) == SelectedChemical)
				{
					ViewModel.cboChemicalName.SelectedIndex = i;
					break;
				}
			}
			ViewModel.FirstTime = 0;
			CheckComplete();
			ViewModel.ChemicalDetailUpdated = -1;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboUN_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboUN.SelectedIndex == -1)
			{
				ViewModel.cboUN.Text = "";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAddMaterial_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Check to make sure valid selections made
			//Add FireServiceMaterialUsed Record
			double dbNumericTemp = 0;
			if ( ViewModel.cboMaterialUsed.SelectedIndex == -1)
			{
				ViewModel.cmdAddMaterial.Enabled = false;
				return;
			}
			else if ( ViewModel.txtQuantity.Text == "")
			{
				ViewModel.cmdAddMaterial.Enabled = false;
				return;
			}
			else if (!Double.TryParse(ViewModel.txtQuantity.Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
			{
				ViewModel.cmdAddMaterial.Enabled = false;
				return;
			}
			TFDIncident.clsHazmat HazmatCL = Container.Resolve< clsHazmat>();

			HazmatCL.MUHazmatID = ViewModel.HazmatDLID;
			HazmatCL.FireServiceMaterial = ViewModel.cboMaterialUsed.GetItemData(ViewModel.cboMaterialUsed.SelectedIndex);
			HazmatCL.MaterialQuantity = Convert.ToInt32(Conversion.Val(ViewModel.txtQuantity.Text));
			if (~HazmatCL.AddHazmatFireServiceMaterialsUsed() != 0)
			{
				ViewManager.ShowMessage("Error Attempting to Add Material Used Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
			}

			LoadMaterialUsed();
			ViewModel.cboMaterialUsed.SelectedIndex = -1;
			ViewModel.txtQuantity.Text = "";

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
		internal void cmdAddResource_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Check to see if OutsideResource can be added

			if ( ViewModel.cboOutsideResource.SelectedIndex == -1)
			{
				ViewModel.cmdAddResource.Enabled = false;
				return;
			}
			else if ( ViewModel.cboResourceUse.SelectedIndex == -1)
			{
				ViewModel.cmdAddResource.Enabled = false;
				return;
			}
			TFDIncident.clsHazmat HazmatCL = Container.Resolve< clsHazmat>();

			if ( ViewModel.CurrReport == IncidentMain.HAZMATDL)
			{
				HazmatCL.ORDLHazmatID = ViewModel.HazmatDLID;
				HazmatCL.DLOutsideResource = ViewModel.cboOutsideResource.GetItemData(ViewModel.cboOutsideResource.SelectedIndex);
				HazmatCL.DLResourceUse = ViewModel.cboResourceUse.GetItemData(ViewModel.cboResourceUse.SelectedIndex);
				if (~HazmatCL.AddHazmatDLOutsideResource() != 0)
				{
					ViewManager.ShowMessage("Error Attempting to Add Outside Resource Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				}
			}
			else
			{
				HazmatCL.ORHazmatID = ViewModel.HazmatID;
				HazmatCL.OutsideResource = ViewModel.cboOutsideResource.GetItemData(ViewModel.cboOutsideResource.SelectedIndex);
				HazmatCL.ResourceUse = ViewModel.cboResourceUse.GetItemData(ViewModel.cboResourceUse.SelectedIndex);
				if (~HazmatCL.AddHazmatOutsideResource() != 0)
				{
					ViewManager.ShowMessage("Error Attempting to Add Outside Resource Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				}
			}

			LoadOutsideResource();
			ViewModel.cboOutsideResource.SelectedIndex = -1;
			ViewModel.cboResourceUse.SelectedIndex = -1;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdMoreChemicals_Click(Object eventSender, System.EventArgs eventArgs)
		{
			if (~SaveChemicalDetail() != 0)
			{
				ViewManager.ShowMessage("Error Attempting to Add Chemical Detail Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdRemoveMaterial_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Check to make sure that item has been selected
			TFDIncident.clsHazmat HazmatCL = Container.Resolve< clsHazmat>();

			int MaterialSelected = 0;
			for (int i = 0; i <= ViewModel.lstMaterialUsed.Items.Count - 1; i++)
			{
				if ( ViewModel.lstMaterialUsed.GetSelected( i))
				{
					MaterialSelected = -1;
					break;
				}
			}

			if (~MaterialSelected != 0)
			{
				return;
			} //no items selected

			for (int i = 0; i <= ViewModel.lstMaterialUsed.Items.Count - 1; i++)
			{
				if ( ViewModel.lstMaterialUsed.GetSelected( i))
				{
					MaterialSelected = ViewModel.lstMaterialUsed.GetItemData(i);
					if (~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
							{
								var ret = HazmatCL.DeleteHazmatFireServiceMaterialsUsed(ref p1, ref MaterialSelected);
								ViewModel.HazmatDLID = p1;
								return ret;
							}, ViewModel.HazmatDLID) != 0)
					{
						ViewManager.ShowMessage("Error Deleting Hazmat Material Used Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						break;
					}
				}
			}

			LoadMaterialUsed();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdRemoveResource_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Check to make sure that item has been selected
			TFDIncident.clsHazmat HazmatCL = Container.Resolve< clsHazmat>();

			int ResourceSelected = 0;
			for (int i = 0; i <= ViewModel.lstOutsideResource.Items.Count - 1; i++)
			{
				if ( ViewModel.lstOutsideResource.GetSelected( i))
				{
					ResourceSelected = -1;
					break;
				}
			}

			if (~ResourceSelected != 0)
			{
				return;
			} //no items selected

			if ( ViewModel.CurrReport == IncidentMain.HAZMATDL)
			{
				for (int i = 0; i <= ViewModel.lstOutsideResource.Items.Count - 1; i++)
				{
					if ( ViewModel.lstOutsideResource.GetSelected( i))
					{
						ResourceSelected = ViewModel.lstOutsideResource.GetItemData(i);
						if (~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
								{
									var ret = HazmatCL.DeleteHazmatDLOutsideResource(ref p1, ref ResourceSelected);
									ViewModel.HazmatDLID = p1;
									return ret;
								}, ViewModel.HazmatDLID) != 0)
						{
							ViewManager.ShowMessage("Error Deleting Outside Resource Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							break;
						}
					}
				}
			}
			else
			{
				for (int i = 0; i <= ViewModel.lstOutsideResource.Items.Count - 1; i++)
				{
					if ( ViewModel.lstOutsideResource.GetSelected( i))
					{
						ResourceSelected = ViewModel.lstOutsideResource.GetItemData(i);
						if (~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
								{
									var ret = HazmatCL.DeleteHazmatOutsideResource(ref p1, ref ResourceSelected);
									ViewModel.HazmatID = p1;
									return ret;
								}, ViewModel.HazmatID) != 0)
						{
							ViewManager.ShowMessage("Error Deleting Outside Resource Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							break;
						}
					}
				}
			}

			LoadOutsideResource();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdSave_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				int Index =this.ViewModel.cmdSave.IndexOf((UpgradeHelpers.BasicViewModels.ButtonViewModel) eventSender);
				using ( var async2 = this.Async() )
				{
					switch(Index)
					{
						case 0 :
							if (~SaveHazmatReport(IncidentMain.COMPLETE) != 0)
							{
								ViewManager.ShowMessage("Error Attempting to Save Hazmat Report", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
							else
							{
								ViewManager.ShowMessage("Hazmat Report Saved as Complete", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK);
							}
							break;
						case 1 :
							if (~SaveHazmatReport(IncidentMain.SAVEDINCOMPLETE) != 0)
							{
								ViewManager.ShowMessage("Error Attempting to Save Hazmat Report", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
							else
							{
								ViewManager.ShowMessage("Hazmat Report Saved as Incomplete", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK);
							}
							break;
						case 3 :
							//Print Preview Report 
							IncidentMain
								.Shared.gPrintReportID = ViewModel.ReportLogID;
							async2.Append(() =>
								{
									ViewManager.NavigateToView(
										frmReportHazmat.DefInstance, true);
								});

							break;
					}
				}
				async1.Append(() =>
					{
						ViewManager.DisposeView(this);
					});
			}
		}
		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			//Format Initial Load of Hazmat Report Entry System
			TFDIncident.clsReportLog ReportLog = Container.Resolve< clsReportLog>();
			TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();
			TFDIncident.clsHazmat HazmatCL = Container.Resolve< clsHazmat>();

			if (ReportLog.GetReportLog(IncidentMain.Shared.gEditReportID) != 0)
			{
				ViewModel.CurrIncident = ReportLog.RLIncidentID;
				ViewModel.ReportLogID = ReportLog.ReportLogID;
				ViewModel.CurrReport = ReportLog.ReportType;
				if ( ViewModel.CurrReport == IncidentMain.HAZMATDL)
				{
					ViewModel.HazmatDLID = ReportLog.ReportReferenceID;
				}
				else if ( ViewModel.CurrReport == IncidentMain.HAZMATDLRELEASE)
				{
					ViewModel.HazmatID = ReportLog.ReportReferenceID;
					ViewModel.lbStreetClass.Visible = false;
					ViewModel.cboStreetClass.Visible = false;
					ViewModel.lbReleaseFloor.Visible = true;
					ViewModel.txtReleaseFloor.Visible = true;
					if (HazmatCL.GetIncidentDrugLab(ViewModel.CurrIncident) != 0)
					{
						ViewModel.HazmatDLID = HazmatCL.DLHazmatID;
					}
					else
					{
						ViewManager.ShowMessage("Error retrieving Hazmat Drug Lab Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					}
				}
				else
				{
					ViewModel.HazmatID = ReportLog.ReportReferenceID;
					if ( ViewModel.CurrReport == IncidentMain.HAZMATFIXED)
					{
						ViewModel.lbStreetClass.Visible = false;
						ViewModel.cboStreetClass.Visible = false;
						ViewModel.lbReleaseFloor.Visible = true;
						ViewModel.txtReleaseFloor.Visible = true;
					}
					else
					{
						ViewModel.lbStreetClass.Visible = true;
						ViewModel.cboStreetClass.Visible = true;
						ViewModel.lbReleaseFloor.Visible = false;
						ViewModel.txtReleaseFloor.Visible = false;
					}
				}
			}
			else
			{
				ViewManager.ShowMessage("Error Retrieving ReportLog Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				ViewManager.DisposeView(this);
				return;
			}

			if (IncidentCL.GetIncident(ViewModel.CurrIncident) != 0)
			{
				ViewModel.lbLocation.Text = IncidentMain.Clean(IncidentCL.Location);
				ViewModel.lbIncident.Text = IncidentMain.Clean(IncidentCL.IncidentNumber);
			}
			else
			{
				ViewManager.ShowMessage("Error Retrieving Incident Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
			}
			ViewModel.FirstTime = -1;
			ViewModel.NarrationUpdated = 0;
			ViewModel.ChemicalDetailUpdated = 0;
			LoadLists();
			GetHazmatData();
			ViewModel.FirstTime = 0;
			CheckComplete();
			if (IncidentMain.Shared.gWizardSecurity == IncidentMain.READONLY)
			{
				LockScreen();
			}

		}






		private void rtxNarration_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime != 0)
			{
				return;
			}
			ViewModel.NarrationUpdated = -1;
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtAreaAffected_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtEstAmountReleased_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime != 0)
			{
				return;
			}
			ViewModel.ChemicalDetailUpdated = -1;
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtEstContainerCapacity_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime != 0)
			{
				return;
			}
			ViewModel.ChemicalDetailUpdated = -1;
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtQuantity_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			//Check to see if AddMaterials button should be enabled
			double dbNumericTemp = 0;
			if ( ViewModel.cboMaterialUsed.SelectedIndex == -1)
			{
				ViewModel.cmdAddMaterial.Enabled = false;
				return;
			}
			else if ( ViewModel.txtQuantity.Text == "")
			{
				ViewModel.cmdAddMaterial.Enabled = false;
				return;
			}
			else if (!Double.TryParse(ViewModel.txtQuantity.Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
			{
				ViewModel.txtQuantity.Text = "";
				ViewModel.cmdAddMaterial.Enabled = false;
				return;
			}
			else
			{
				ViewModel.cmdAddMaterial.Enabled = true;
			}

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmHazmatReport DefInstance
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

		public static frmHazmatReport CreateInstance()
		{
			TFDIncident.frmHazmatReport theInstance = Shared.Container.Resolve< frmHazmatReport>();
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
			ViewModel.tabPage5.LifeCycleStartup();
			ViewModel.tabPage4.LifeCycleStartup();
			ViewModel.tabPage3.LifeCycleStartup();
			ViewModel.tabPage2.LifeCycleStartup();
			ViewModel.tabPage1.LifeCycleStartup();
			ViewModel.picHazmatBar.LifeCycleStartup();
			ViewModel.tabHazmat.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.tabPage5.LifeCycleShutdown();
			ViewModel.tabPage4.LifeCycleShutdown();
			ViewModel.tabPage3.LifeCycleShutdown();
			ViewModel.tabPage2.LifeCycleShutdown();
			ViewModel.tabPage1.LifeCycleShutdown();
			ViewModel.picHazmatBar.LifeCycleShutdown();
			ViewModel.tabHazmat.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmHazmatReport
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.frmHazmatReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmHazmatReport m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}