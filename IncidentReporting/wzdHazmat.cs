using Microsoft.VisualBasic;
using System;
using System.Globalization;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;


namespace TFDIncident
{

	public partial class wzdHazmat
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.wzdHazmatViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(wzdHazmat));
			if ( Shared.m_vb6FormDefInstance == null )
			{
				if ( Shared.m_InitializingDefInstance )
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
			ReLoadForm(false);
		}


		private void wzdHazmat_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender )
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>)eventSender;
			}
		}

		private void LoadReportStatus()
		{
			//Format ReportStatus frame
			TFDIncident.clsPersonnel PersonnelCL = Container.Resolve<clsPersonnel>();
			ViewModel.lbRSIncidentNumber.Text = ViewModel.lbIncidentNo.Text;
			ViewModel.lbRSReportedBy.Text = IncidentMain.Shared.gCurrUserName;
			ViewModel.lbRSEmployeeID.Text = IncidentMain.Shared.gCurrUser;
			switch ( ViewModel.CurrReport )
			{
				case IncidentMain.HAZMATFIXED:
					ViewModel.lbRSCurrReportType.Text = "Fixed Property - Hazmat Release Report";
					break;
				case IncidentMain.HAZMATMOBILE:
					ViewModel.lbRSCurrReportType.Text = "Transportation - Hazmat Release Report";
					break;
				case IncidentMain.HAZMATDLRELEASE:
					ViewModel.lbRSCurrReportType.Text = "Hazmat Drug Lab w/ Release Report";
					break;
				case IncidentMain.HAZMATDL:
					ViewModel.lbRSCurrReportType.Text = "Hazmat Drug Lab Report";
					break;
				default:
					ViewModel.lbRSCurrReportType.Text = "";
					break;
			}

			if ( PersonnelCL.GetEmployeeRecord(IncidentMain.Shared.gCurrUser) != 0 )
			{
				ViewModel.lbRSPosition.Text = IncidentMain.Clean(PersonnelCL.Employee["job_title"]);
				ViewModel.lbRSUnit.Text = IncidentMain.Clean(PersonnelCL.Employee["unit_code"]);
				ViewModel.lbRSShift.Text = IncidentMain.Clean(PersonnelCL.Employee["shift_code"]) + " Shift";
			}
			else
			{
				ViewModel.lbRSPosition.Text = "Unknown";
				ViewModel.lbRSUnit.Text = "Unknown";
				ViewModel.lbRSShift.Text = "Unknown";
			}
			CheckComplete();

			IncidentMain.ReportMessage(ViewModel.CurrIncident, ViewModel.lstMessage);

		}

		private void LoadChemicalLists()
		{
			//Load Code data into frmChemicalDetail Controls
			TFDIncident.clsHazmat HazmatCL = Container.Resolve<clsHazmat>();
			TFDIncident.clsCommonCodes CommonCodes = Container.Resolve<clsCommonCodes>();
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
			this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.WaitCursor); //Hour Glass

			ViewModel.cboCommonChemicals.Items.Clear();
			ViewModel.cboChemicalName.Items.Clear();
			ViewModel.cboUN.Items.Clear();

			HazmatCL.GetChemicals();

			while ( !HazmatCL.Chemicals.EOF )
			{
				ViewModel.cboChemicalName.AddItem(IncidentMain.Clean(HazmatCL.Chemicals["chemical_name"]));
				ViewModel.cboChemicalName.SetItemData(ViewModel.cboChemicalName.GetNewIndex(), Convert.ToInt32(HazmatCL.Chemicals["chemical_id"]));
				ViewModel.cboUN.AddItem(IncidentMain.Clean(HazmatCL.Chemicals["unno"]));
				ViewModel.cboUN.SetItemData(ViewModel.cboUN.GetNewIndex(), Convert.ToInt32(HazmatCL.Chemicals["chemical_id"]));
				HazmatCL.Chemicals.MoveNext();
			}
			;
			HazmatCL.GetCommonChemicals();

			while ( !HazmatCL.Chemicals.EOF )
			{
				ViewModel.cboCommonChemicals.AddItem(IncidentMain.Clean(HazmatCL.Chemicals["chemical_name"]));
				ViewModel.cboCommonChemicals.SetItemData(ViewModel.cboCommonChemicals.GetNewIndex(), Convert.ToInt32(HazmatCL.Chemicals["chemical_id"]));
				HazmatCL.Chemicals.MoveNext();
			}
			;
			ViewModel.cboContainerType.Items.Clear();
			CommonCodes.GetContainerType();

			while ( !CommonCodes.ContainerType.EOF )
			{
				ViewModel.cboContainerType.AddItem(IncidentMain.Clean(CommonCodes.ContainerType["description"]));
				ViewModel.cboContainerType.SetItemData(ViewModel.cboContainerType.GetNewIndex(), Convert.ToInt32(CommonCodes.ContainerType["container_type_code"]));
				CommonCodes.ContainerType.MoveNext();
			}
			;
			ViewModel.cboContainerCapacityUnits.Items.Clear();
			ViewModel.cboAmountReleasedUnits.Items.Clear();
			CommonCodes.GetCapacityUnits();

			while ( !CommonCodes.CapacityUnit.EOF )
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

			while ( !HazmatCL.PhysicalStateCode.EOF )
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

			while ( !HazmatCL.ReleasedIntoCode.EOF )
			{
				ViewModel.cboPrimaryReleasedInto.AddItem(IncidentMain.Clean(HazmatCL.ReleasedIntoCode["description"]));
				ViewModel.cboPrimaryReleasedInto.SetItemData(ViewModel.cboPrimaryReleasedInto.GetNewIndex(), Convert.ToInt32(HazmatCL.ReleasedIntoCode["released_into_code"]));
				ViewModel.cboSecondaryReleasedInto.AddItem(IncidentMain.Clean(HazmatCL.ReleasedIntoCode["description"]));
				ViewModel.cboSecondaryReleasedInto.SetItemData(ViewModel.cboSecondaryReleasedInto.GetNewIndex(), Convert.ToInt32(HazmatCL.ReleasedIntoCode["released_into_code"]));
				HazmatCL.ReleasedIntoCode.MoveNext();
			}
			;
			ViewModel.ChemicalsLoaded = -1;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
			this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.Arrow); //Regular

		}

		private int SaveChemicalDetail()
		{
			//Save Current Chemical Detail record
			//Clear Selections/Entries of Current Chemical for new record
			int result = 0;
			TFDIncident.clsHazmat HazmatCL = Container.Resolve<clsHazmat>();

			result = -1;
			HazmatCL.CDHazmatID = ViewModel.HazmatID;
			HazmatCL.CDChemicalID = Convert.ToInt32(Conversion.Val(ViewModel.lbChemicalID.Text));
			if ( ViewModel.cboContainerType.SelectedIndex == -1 )
			{
				HazmatCL.ContainerTypeCode = 0;
			}
			else
			{
				HazmatCL.ContainerTypeCode = ViewModel.cboContainerType.GetItemData(ViewModel.cboContainerType.SelectedIndex);
			}
			HazmatCL.ContainerCapacity = Convert.ToInt32(Conversion.Val(ViewModel.txtEstContainerCapacity.Text));
			if ( ViewModel.cboContainerCapacityUnits.SelectedIndex == -1 )
			{
				HazmatCL.ContainerCapacityUnits = 0;
			}
			else
			{
				HazmatCL.ContainerCapacityUnits = ViewModel.cboContainerCapacityUnits.GetItemData(ViewModel.cboContainerCapacityUnits.SelectedIndex);
			}
			HazmatCL.AmountReleased = Convert.ToInt32(Conversion.Val(ViewModel.txtEstAmountReleased.Text));
			if ( ViewModel.cboAmountReleasedUnits.SelectedIndex == -1 )
			{
				HazmatCL.AmountReleasedUnits = 0;
			}
			else
			{
				HazmatCL.AmountReleasedUnits = ViewModel.cboAmountReleasedUnits.GetItemData(ViewModel.cboAmountReleasedUnits.SelectedIndex);
			}
			if ( ViewModel.cboPhysicalStateStored.SelectedIndex == -1 )
			{
				HazmatCL.PhysicalStateStored = 0;
			}
			else
			{
				HazmatCL.PhysicalStateStored = ViewModel.cboPhysicalStateStored.GetItemData(ViewModel.cboPhysicalStateStored.SelectedIndex);
			}
			if ( ViewModel.cboPhysicalStateReleased.SelectedIndex == -1 )
			{
				HazmatCL.PhysicalStateReleased = 0;
			}
			else
			{
				HazmatCL.PhysicalStateReleased = ViewModel.cboPhysicalStateReleased.GetItemData(ViewModel.cboPhysicalStateReleased.SelectedIndex);
			}
			if ( ViewModel.cboPrimaryReleasedInto.SelectedIndex == -1 )
			{
				HazmatCL.PrimaryReleasedInto = 0;
			}
			else
			{
				HazmatCL.PrimaryReleasedInto = ViewModel.cboPrimaryReleasedInto.GetItemData(ViewModel.cboPrimaryReleasedInto.SelectedIndex);
			}
			if ( ViewModel.cboSecondaryReleasedInto.SelectedIndex == -1 )
			{
				HazmatCL.SecondaryReleasedInto = 0;
			}
			else
			{
				HazmatCL.SecondaryReleasedInto = ViewModel.cboSecondaryReleasedInto.GetItemData(ViewModel.cboSecondaryReleasedInto.SelectedIndex);
			}

			if ( ~HazmatCL.AddHazmatChemicalDetail() != 0 )
			{
				result = 0;
			}
			else
			{
				//Clear current selections/entries
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
				ViewModel.SaveChemical = 0;
			}

			return result;
		}

		private void LoadOutsideResource()
		{
			//load OutsideResource list box with existing records
			TFDIncident.clsHazmat HazmatCL = Container.Resolve<clsHazmat>();
			string sDisplay = "";
			ViewModel.lstOutsideResource.Items.Clear();

			if ( ViewModel.CurrReport == IncidentMain.HAZMATDL )
			{
				if ( HazmatCL.GetHazmatDLOutsideResource(ViewModel.HazmatDLID) != 0 )
				{

					while ( !HazmatCL.HazmatDLOutsideResourceRS.EOF )
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
				if ( HazmatCL.GetHazmatOutsideResource(ViewModel.HazmatID) != 0 )
				{

					while ( !HazmatCL.HazmatOutsideResourceRS.EOF )
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
			TFDIncident.clsHazmat HazmatCL = Container.Resolve<clsHazmat>();
			string sDisplay = "";
			ViewModel.lstMaterialUsed.Items.Clear();
			if ( HazmatCL.GetHazmatFireServiceMaterialsUsed(ViewModel.HazmatDLID) != 0 )
			{

				while ( !HazmatCL.HazmatFireServiceMaterialsUsedRS.EOF )
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

		private int SaveHazmatReport(int iUpdateType)
		{
			//Save Hazmat Report(s)
			//Update ReportLog
			int result = 0;
			TFDIncident.clsHazmat HazmatCL = Container.Resolve<clsHazmat>();
			TFDIncident.clsIncident IncidentCL = Container.Resolve<clsIncident>();
			TFDIncident.clsReportLog ReportLog = Container.Resolve<clsReportLog>();

			result = -1;
			if ( ViewModel.CurrReport == IncidentMain.HAZMATDL || ViewModel.CurrReport == IncidentMain.HAZMATDLRELEASE )
			{
				//Update Hazmat Drug Lab record
				HazmatCL.DLHazmatID = ViewModel.HazmatDLID;
				HazmatCL.DLIncidentID = ViewModel.CurrIncident;
				if ( ViewModel.cboDrugLabType.SelectedIndex == -1 )
				{
					HazmatCL.DrugLabType = 0;
				}
				else
				{
					HazmatCL.DrugLabType = ViewModel.cboDrugLabType.GetItemData(ViewModel.cboDrugLabType.SelectedIndex);
				}
				if ( ViewModel.cboHazmatIDSource.SelectedIndex == -1 )
				{
					HazmatCL.DLHazmatIDSource = 0;
				}
				else
				{
					HazmatCL.DLHazmatIDSource = ViewModel.cboHazmatIDSource.GetItemData(ViewModel.cboHazmatIDSource.SelectedIndex);
				}
				if ( ViewModel.cboDisposition.SelectedIndex == -1 )
				{
					HazmatCL.DLDispositionOfRelease = 0;
				}
				else
				{
					HazmatCL.DLDispositionOfRelease = ViewModel.cboDisposition.GetItemData(ViewModel.cboDisposition.SelectedIndex);
				}
				if ( ViewModel.CurrReport == IncidentMain.HAZMATDLRELEASE )
				{
					HazmatCL.DLFlagRelease = 1;
				}
				else
				{
					HazmatCL.DLFlagRelease = 0;
				}
				if ( ~HazmatCL.UpdateHazmatDrugLab() != 0 )
				{
					ViewManager.ShowMessage("Error Attempting to Update Hazmat Drug Lab Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					result = 0;
				}
				if ( ViewModel.CurrReport == IncidentMain.HAZMATDL )
				{
					for ( int i = 0; i <= ViewModel.lstActionsTaken.Items.Count - 1; i++ )
					{
						if ( ViewModel.lstActionsTaken.GetSelected(i) )
						{
							HazmatCL.ATDLHazmatID = ViewModel.HazmatDLID;
							HazmatCL.DLUnitAction = ViewModel.lstActionsTaken.GetItemData(i);
							if ( ~HazmatCL.AddHazmatDrugLabActionTaken() != 0 )
							{
							//error
							}
						}
					}
				}
			}

			if ( ViewModel.CurrReport != IncidentMain.HAZMATDL )
			{
				//Update Hazmat Release record
				HazmatCL.HazmatID = ViewModel.HazmatID;
				HazmatCL.IncidentID = ViewModel.CurrIncident;
				if ( ViewModel.cboIncidentType.SelectedIndex == -1 )
				{
					HazmatCL.IncidentTypeCode = 0;
				}
				else
				{
					HazmatCL.IncidentTypeCode = ViewModel.cboIncidentType.GetItemData(ViewModel.cboIncidentType.SelectedIndex);
				}
				if ( ViewModel.cboHazmatIDSource.SelectedIndex == -1 )
				{
					HazmatCL.HazmatIDSource = 0;
				}
				else
				{
					HazmatCL.HazmatIDSource = ViewModel.cboHazmatIDSource.GetItemData(ViewModel.cboHazmatIDSource.SelectedIndex);
				}
				if ( ViewModel.cboDisposition.SelectedIndex == -1 )
				{
					HazmatCL.DispositionOfRelease = 0;
				}
				else
				{
					HazmatCL.DispositionOfRelease = ViewModel.cboDisposition.GetItemData(ViewModel.cboDisposition.SelectedIndex);
				}
				if ( ViewModel.cboCauseOfRelease.SelectedIndex == -1 )
				{
					HazmatCL.CauseOfRelease = 0;
				}
				else
				{
					HazmatCL.CauseOfRelease = ViewModel.cboCauseOfRelease.GetItemData(ViewModel.cboCauseOfRelease.SelectedIndex);
				}
				HazmatCL.AreaEffected = Convert.ToInt32(Conversion.Val(ViewModel.txtAreaAffected.Text));
				if ( ViewModel.cboAreaAffectedUnits.SelectedIndex == -1 )
				{
					HazmatCL.EffectedAreaUnit = 0;
				}
				else
				{
					HazmatCL.EffectedAreaUnit = ViewModel.cboAreaAffectedUnits.GetItemData(ViewModel.cboAreaAffectedUnits.SelectedIndex);
				}
				HazmatCL.AreaEvacuated = Convert.ToInt32(Conversion.Val(ViewModel.txtAreaEvacuated.Text));
				if ( ViewModel.cboAreaEvacuatedUnits.SelectedIndex == -1 )
				{
					HazmatCL.EvacuatedAreaUnit = 0;
				}
				else
				{
					HazmatCL.EvacuatedAreaUnit = ViewModel.cboAreaEvacuatedUnits.GetItemData(ViewModel.cboAreaEvacuatedUnits.SelectedIndex);
				}
				if ( ViewModel.cboPopulationDensity.SelectedIndex == -1 )
				{
					HazmatCL.PopulationDensity = 0;
				}
				else
				{
					HazmatCL.PopulationDensity = ViewModel.cboPopulationDensity.GetItemData(ViewModel.cboPopulationDensity.SelectedIndex);
				}
				HazmatCL.BuildingsEvacuated = Convert.ToInt32(Conversion.Val(ViewModel.txtBuildingsEvacuated.Text));
				HazmatCL.PeopleEvacuated = Convert.ToInt32(Conversion.Val(ViewModel.txtPeopleEvacuated.Text));
				if ( ViewModel.cboAreaOfOrigin.SelectedIndex == -1 )
				{
					HazmatCL.AreaOfOrigin = 0;
				}
				else
				{
					HazmatCL.AreaOfOrigin = ViewModel.cboAreaOfOrigin.GetItemData(ViewModel.cboAreaOfOrigin.SelectedIndex);
				}
				if ( ViewModel.optOccurredFirst[0].Checked )
				{
					HazmatCL.OccuredFirst = 1;
				}
				else if ( ViewModel.optOccurredFirst[1].Checked )
				{
					HazmatCL.OccuredFirst = 4;
				}
				else if ( ViewModel.optOccurredFirst[2].Checked )
				{
					HazmatCL.OccuredFirst = 2;
				}
				else
				{
					HazmatCL.OccuredFirst = 0;
				}
				if ( ViewModel.cboStreetClass.SelectedIndex == -1 )
				{
					HazmatCL.StreetClass = 0;
				}
				else
				{
					HazmatCL.StreetClass = ViewModel.cboStreetClass.GetItemData(ViewModel.cboStreetClass.SelectedIndex);
				}
				HazmatCL.ReleaseFloor = Convert.ToInt32(Conversion.Val(ViewModel.txtReleaseFloor.Text));
				if ( ViewModel.cboSpecificPropertyUse.SelectedIndex == -1 )
				{
					HazmatCL.PropertyUse = 0;
				}
				else
				{
					HazmatCL.PropertyUse = ViewModel.cboSpecificPropertyUse.GetItemData(ViewModel.cboSpecificPropertyUse.SelectedIndex);
				}
				if ( ~HazmatCL.UpdateHazmatRelease() != 0 )
				{
					ViewManager.ShowMessage("Error Attempting to Update Hazmat Release Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					result = 0;
				}
				//Add Non-Drug Lab Subtable Data
				if ( result != 0 )
				{
					//Save ChemicalDetail
					if ( ViewModel.SaveChemical != 0 )
					{
						if ( ~SaveChemicalDetail() != 0 )
						{
							ViewManager.ShowMessage("Error Attempting to Save ChemicalDetail Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						}
					}
					for ( int i = 0; i <= ViewModel.lstContributingFactors.Items.Count - 1; i++ )
					{
						if ( ViewModel.lstContributingFactors.GetSelected(i) )
						{
							HazmatCL.CFHazmatID = ViewModel.HazmatID;
							HazmatCL.HazmatContributingFactor = ViewModel.lstContributingFactors.GetItemData(i);
							if ( ~HazmatCL.AddHazmatContributingFactor() != 0 )
							{
							//error
							}
						}
					}
					for ( int i = 0; i <= ViewModel.lstMitigatingFactors.Items.Count - 1; i++ )
					{
						if ( ViewModel.lstMitigatingFactors.GetSelected(i) )
						{
							HazmatCL.MFHazmatID = ViewModel.HazmatID;
							HazmatCL.HazmatMitigatingFactor = ViewModel.lstMitigatingFactors.GetItemData(i);
							if ( ~HazmatCL.AddHazmatMitigatingFactor() != 0 )
							{
							//error
							}
						}
					}
					for ( int i = 0; i <= ViewModel.lstEquipmentInvolved.Items.Count - 1; i++ )
					{
						if ( ViewModel.lstEquipmentInvolved.GetSelected(i) )
						{
							HazmatCL.EIHazmatID = ViewModel.HazmatID;
							HazmatCL.HazmatEquipmentInvolved = ViewModel.lstEquipmentInvolved.GetItemData(i);
							if ( ~HazmatCL.AddHazmatEquipmentInvolved() != 0 )
							{
							//error
							}
						}
					}
					for ( int i = 0; i <= ViewModel.lstActionsTaken.Items.Count - 1; i++ )
					{
						if ( ViewModel.lstActionsTaken.GetSelected(i) )
						{
							HazmatCL.ATHazmatID = ViewModel.HazmatID;
							HazmatCL.UnitAction = ViewModel.lstActionsTaken.GetItemData(i);
							if ( ~HazmatCL.AddHazmatActionTaken() != 0 )
							{
							//error
							}
						}
					}
				}
			}

			//Save Hazmat Narration
			if ( result != 0 )
			{
				if ( ViewModel.rtxNarration.Text != "" )
				{
					IncidentCL.NarrationIncidentID = ViewModel.CurrIncident;
					IncidentCL.ReportType = ViewModel.CurrReport;
					IncidentCL.NarrationText = ViewModel.rtxNarration.Text;
					IncidentCL.NarrationBy = IncidentMain.Shared.gCurrUser;
					IncidentCL.NarrationLastUpdate = DateTime.Now.ToString("MM/dd/yyyy");
					if ( ~IncidentCL.AddNarration() != 0 )
					{
						ViewManager.ShowMessage("Error Attempting to Add Hazmat Narration Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					}
				}
			}

			//Update ReportLog
			if ( result != 0 )
			{
				//Update ReportLog Record
				ReportLog.ReportLogID = ViewModel.ReportLogID;
				ReportLog.RLIncidentID = ViewModel.CurrIncident;
				if ( ViewModel.CurrReport == IncidentMain.HAZMATDL )
				{
					ReportLog.ReportReferenceID = ViewModel.HazmatDLID;
				}
				else
				{
					ReportLog.ReportReferenceID = ViewModel.HazmatID;
				}
				ReportLog.ReportType = ViewModel.CurrReport;
				ReportLog.ReportStatus = iUpdateType;
				ReportLog.ResponsibleUnit = IncidentMain.Shared.gWizardUnitID;
				if ( ~ReportLog.UpDate() != 0 )
				{
					ViewManager.ShowMessage("Error Attempting to Update Reportlog", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				}
			}




			return result;
		}

		private void LoadLists()
		{
			//Load combo and listboxes with code table data
			TFDIncident.clsHazmat HazmatCL = Container.Resolve<clsHazmat>();
			TFDIncident.clsUnit UnitCL = Container.Resolve<clsUnit>();
			TFDIncident.clsCommonCodes CommonCodes = Container.Resolve<clsCommonCodes>();
			TFDIncident.clsFireCodes FireCodes = Container.Resolve<clsFireCodes>();
			ViewModel.FirstTime = -1;
			//frmHazmatType Controls
			ViewModel.cboHazmatIDSource.Items.Clear();
			HazmatCL.GetHazmatIDSourceCode();

			while ( !HazmatCL.HazmatIDSourceCode.EOF )
			{
				ViewModel.cboHazmatIDSource.AddItem(IncidentMain.Clean(HazmatCL.HazmatIDSourceCode["description"]));
				ViewModel.cboHazmatIDSource.SetItemData(ViewModel.cboHazmatIDSource.GetNewIndex(), Convert.ToInt32(HazmatCL.HazmatIDSourceCode["hazmat_id_source_code"]));
				HazmatCL.HazmatIDSourceCode.MoveNext();
			}
			;
			ViewModel.lstActionsTaken.Items.Clear();
			// This needs to be modified to bring back HazmatActions
			CommonCodes.GetUnitActionCodeByClass(2);

			while ( !CommonCodes.UnitAction.EOF )
			{
				ViewModel.lstActionsTaken.AddItem(IncidentMain.Clean(CommonCodes.UnitAction["description"]));
				ViewModel.lstActionsTaken.SetItemData(ViewModel.lstActionsTaken.GetNewIndex(), Convert.ToInt32(CommonCodes.UnitAction["unit_action_code"]));
				CommonCodes.UnitAction.MoveNext();
			}
			;
			ViewModel.cboDrugLabType.Items.Clear();
			HazmatCL.GetHazmatDrugLabCode();

			while ( !HazmatCL.HazmatDrugLabCode.EOF )
			{
				ViewModel.cboDrugLabType.AddItem(IncidentMain.Clean(HazmatCL.HazmatDrugLabCode["description"]));
				ViewModel.cboDrugLabType.SetItemData(ViewModel.cboDrugLabType.GetNewIndex(), Convert.ToInt32(HazmatCL.HazmatDrugLabCode["drug_lab_type_code"]));
				HazmatCL.HazmatDrugLabCode.MoveNext();
			}
			;
			ViewModel.cboMaterialUsed.Items.Clear();
			HazmatCL.GetFireServiceMaterialCode();

			while ( !HazmatCL.FireServiceMaterialCode.EOF )
			{
				ViewModel.cboMaterialUsed.AddItem(IncidentMain.Clean(HazmatCL.FireServiceMaterialCode["description"]));
				ViewModel.cboMaterialUsed.SetItemData(ViewModel.cboMaterialUsed.GetNewIndex(), Convert.ToInt32(HazmatCL.FireServiceMaterialCode["fire_service_material_code"]));
				HazmatCL.FireServiceMaterialCode.MoveNext();
			}
			;
			ViewModel.cboIncidentType.Items.Clear();
			CommonCodes.GetIncidentTypeCodeByClass(3); //Hazmat

			while ( !CommonCodes.IncidentType.EOF )
			{
				ViewModel.cboIncidentType.AddItem(IncidentMain.Clean(CommonCodes.IncidentType["description"]));
				ViewModel.cboIncidentType.SetItemData(ViewModel.cboIncidentType.GetNewIndex(), Convert.ToInt32(CommonCodes.IncidentType["incident_type_code"]));
				CommonCodes.IncidentType.MoveNext();
			}
			;
			ViewModel.cboGeneralPropertyUse.Items.Clear();
			FireCodes.GetPropertyUseClass();

			while ( !FireCodes.PropertyUseClassRS.EOF )
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

			while ( !HazmatCL.StreetClassCode.EOF )
			{
				ViewModel.cboStreetClass.AddItem(IncidentMain.Clean(HazmatCL.StreetClassCode["description"]));
				ViewModel.cboStreetClass.SetItemData(ViewModel.cboStreetClass.GetNewIndex(), Convert.ToInt32(HazmatCL.StreetClassCode["street_class_code"]));
				HazmatCL.StreetClassCode.MoveNext();
			}
			;
			ViewModel.cboCauseOfRelease.Items.Clear();
			HazmatCL.GetCauseOfReleaseCode();

			while ( !HazmatCL.CauseOfReleaseCode.EOF )
			{
				ViewModel.cboCauseOfRelease.AddItem(IncidentMain.Clean(HazmatCL.CauseOfReleaseCode["description"]));
				ViewModel.cboCauseOfRelease.SetItemData(ViewModel.cboCauseOfRelease.GetNewIndex(), Convert.ToInt32(HazmatCL.CauseOfReleaseCode["cause_of_release_code"]));
				HazmatCL.CauseOfReleaseCode.MoveNext();
			}
			;
			ViewModel.cboAreaAffectedUnits.Items.Clear();
			ViewModel.cboAreaEvacuatedUnits.Items.Clear();
			CommonCodes.GetAreaUnits();

			while ( !CommonCodes.AreaUnits.EOF )
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

			while ( !CommonCodes.PopulationDensity.EOF )
			{
				ViewModel.cboPopulationDensity.AddItem(IncidentMain.Clean(CommonCodes.PopulationDensity["description"]));
				ViewModel.cboPopulationDensity.SetItemData(ViewModel.cboPopulationDensity.GetNewIndex(), Convert.ToInt32(CommonCodes.PopulationDensity["population_density_code"]));
				CommonCodes.PopulationDensity.MoveNext();
			}
			;
			ViewModel.lstContributingFactors.Items.Clear();
			HazmatCL.GetHazmatContributingFactorCode();

			while ( !HazmatCL.HazmatContributingFactorCode.EOF )
			{
				ViewModel.lstContributingFactors.AddItem(IncidentMain.Clean(HazmatCL.HazmatContributingFactorCode["description"]));
				ViewModel.lstContributingFactors.SetItemData(ViewModel.lstContributingFactors.GetNewIndex(), Convert.ToInt32(HazmatCL.HazmatContributingFactorCode["hazmat_contributing_factor_code"]));
				HazmatCL.HazmatContributingFactorCode.MoveNext();
			}
			;
			ViewModel.lstMitigatingFactors.Items.Clear();
			HazmatCL.GetHazmatMitigatingFactorCode();

			while ( !HazmatCL.HazmatMitigatingFactorCode.EOF )
			{
				ViewModel.lstMitigatingFactors.AddItem(IncidentMain.Clean(HazmatCL.HazmatMitigatingFactorCode["description"]));
				ViewModel.lstMitigatingFactors.SetItemData(ViewModel.lstMitigatingFactors.GetNewIndex(), Convert.ToInt32(HazmatCL.HazmatMitigatingFactorCode["hazmat_mitigating_factor_code"]));
				HazmatCL.HazmatMitigatingFactorCode.MoveNext();
			}
			;
			ViewModel.lstEquipmentInvolved.Items.Clear();
			HazmatCL.GetHazmatEquipmentInvolvedCode();

			while ( !HazmatCL.HazmatEquipmentInvolvedCode.EOF )
			{
				ViewModel.lstEquipmentInvolved.AddItem(IncidentMain.Clean(HazmatCL.HazmatEquipmentInvolvedCode["description"]));
				ViewModel.lstEquipmentInvolved.SetItemData(ViewModel.lstEquipmentInvolved.GetNewIndex(), Convert.ToInt32(HazmatCL.HazmatEquipmentInvolvedCode["hazmat_equipment_involved_code"]));
				HazmatCL.HazmatEquipmentInvolvedCode.MoveNext();
			}
			;

			//frmNarration Controls
			ViewModel.cboDisposition.Items.Clear();
			HazmatCL.GetDispositionOfReleaseCode();

			while ( !HazmatCL.DispositionOfReleaseCode.EOF )
			{
				ViewModel.cboDisposition.AddItem(IncidentMain.Clean(HazmatCL.DispositionOfReleaseCode["description"]));
				ViewModel.cboDisposition.SetItemData(ViewModel.cboDisposition.GetNewIndex(), Convert.ToInt32(HazmatCL.DispositionOfReleaseCode["disposition_of_release_code"]));
				HazmatCL.DispositionOfReleaseCode.MoveNext();
			}
			;
			ViewModel.cboOutsideResource.Items.Clear();
			HazmatCL.GetOutsideResourceCode();

			while ( !HazmatCL.OutsideResourceCode.EOF )
			{
				ViewModel.cboOutsideResource.AddItem(IncidentMain.Clean(HazmatCL.OutsideResourceCode["description"]));
				ViewModel.cboOutsideResource.SetItemData(ViewModel.cboOutsideResource.GetNewIndex(), Convert.ToInt32(HazmatCL.OutsideResourceCode["outside_resource_code"]));
				HazmatCL.OutsideResourceCode.MoveNext();
			}
			;
			ViewModel.cboResourceUse.Items.Clear();
			HazmatCL.GetResourceUseCode();

			while ( !HazmatCL.ResourceUseCode.EOF )
			{
				ViewModel.cboResourceUse.AddItem(IncidentMain.Clean(HazmatCL.ResourceUseCode["description"]));
				ViewModel.cboResourceUse.SetItemData(ViewModel.cboResourceUse.GetNewIndex(), Convert.ToInt32(HazmatCL.ResourceUseCode["resource_use_code"]));
				HazmatCL.ResourceUseCode.MoveNext();
			}
			;
			ViewModel.rtxNarration.Text = "";
			ViewModel.FirstTime = 0;

		}


		private int CheckComplete()
		{
			//Check Required Fields for Completion
			int result = 0;
			if ( ViewModel.FirstTime != 0 )
			{
				return result;
			}


			result = -1;

			if ( ViewModel.cboHazmatIDSource.SelectedIndex == -1 )
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

			if ( ViewModel.CurrReport == IncidentMain.HAZMATDL )
			{
				if ( ViewModel.cboDrugLabType.SelectedIndex == -1 )
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
				if ( ViewModel.cboMaterialUsed.SelectedIndex == -1 )
				{
					ViewModel.cmdAddMaterial.Enabled = false;
				}
				else if ( ViewModel.txtQuantity.Text == "" )
				{
					ViewModel.cmdAddMaterial.Enabled = false;
				}
				else if ( !Double.TryParse(ViewModel.txtQuantity.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp) )
				{
					ViewModel.cmdAddMaterial.Enabled = false;
					ViewModel.txtQuantity.Text = "";
				}
				else
				{
					ViewModel.cmdAddMaterial.Enabled = true;
				}
			}
			if ( ViewModel.CurrReport != IncidentMain.HAZMATDL )
			{
				if ( ViewModel.CurrReport == IncidentMain.HAZMATFIXED || ViewModel.CurrReport == IncidentMain.HAZMATDLRELEASE )
				{
					if ( ViewModel.cboGeneralPropertyUse.SelectedIndex == -1 )
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
					if ( ViewModel.txtReleaseFloor.Text != "" )
					{
						double dbNumericTemp2 = 0;
						if ( !Double.TryParse(ViewModel.txtReleaseFloor.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp2) )
						{
							ViewModel.txtReleaseFloor.Text = "";
						}
					}
				}
				if ( ViewModel.cboIncidentType.SelectedIndex == -1 )
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
				if ( ViewModel.cboSpecificPropertyUse.SelectedIndex == -1 )
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
				if ( ViewModel.cboAreaOfOrigin.SelectedIndex == -1 )
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
				if ( ViewModel.cboCauseOfRelease.SelectedIndex == -1 )
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
				if ( ViewModel.cboAreaAffectedUnits.SelectedIndex == -1 )
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
				if ( ViewModel.txtAreaAffected.Text == "" )
				{
					ViewModel.txtAreaAffected.BackColor = IncidentMain.Shared.REQCOLOR;
					ViewModel.txtAreaAffected.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					result = 0;
				}
				else if ( !Double.TryParse(ViewModel.txtAreaAffected.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp3) )
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
				if ( ViewModel.txtAreaEvacuated.Text != "" )
				{
					double dbNumericTemp4 = 0;
					if ( !Double.TryParse(ViewModel.txtAreaEvacuated.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp4) )
					{
						ViewModel.txtAreaEvacuated.Text = "";
					}
					else
					{
						if ( ViewModel.cboAreaEvacuatedUnits.SelectedIndex == -1 )
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
				if ( ViewModel.cboPopulationDensity.SelectedIndex == -1 )
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
				if ( ViewModel.txtPeopleEvacuated.Text != "" )
				{
					double dbNumericTemp5 = 0;
					if ( !Double.TryParse(ViewModel.txtPeopleEvacuated.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp5) )
					{
						ViewModel.txtPeopleEvacuated.Text = "";
					}
				}
				if ( ViewModel.txtBuildingsEvacuated.Text != "" )
				{
					double dbNumericTemp6 = 0;
					if ( !Double.TryParse(ViewModel.txtBuildingsEvacuated.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp6) )
					{
						ViewModel.txtBuildingsEvacuated.Text = "";
					}
				}

				//Chemical Detail
				if ( ViewModel.cboCommonChemicals.SelectedIndex == -1 && ViewModel.cboChemicalName.SelectedIndex == -1 && ViewModel.cboUN.SelectedIndex == -1 )
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
					ViewModel.SaveChemical = 0;
					ViewModel.cmdMoreChemicals.Enabled = false;
				}
				else
				{
					ViewModel.cboCommonChemicals.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					ViewModel.cboCommonChemicals.ForeColor = IncidentMain.Shared.HAZMATFONT;
					ViewModel.cboChemicalName.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					ViewModel.cboChemicalName.ForeColor = IncidentMain.Shared.HAZMATFONT;
					ViewModel.cboUN.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
					ViewModel.cboUN.ForeColor = IncidentMain.Shared.HAZMATFONT;
					ViewModel.SaveChemical = -1;
					ViewModel.cmdMoreChemicals.Enabled = true;
					//Only Check Other fields if Chemical has been selected
					if ( ViewModel.txtEstContainerCapacity.Text != "" )
					{
						double dbNumericTemp7 = 0;
						if ( !Double.TryParse(ViewModel.txtEstContainerCapacity.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp7) )
						{
							ViewModel.txtEstContainerCapacity.Text = "";
							ViewModel.cboContainerCapacityUnits.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.cboContainerCapacityUnits.ForeColor = IncidentMain.Shared.HAZMATFONT;
							ViewModel.cboContainerType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
							ViewModel.cboContainerType.ForeColor = IncidentMain.Shared.HAZMATFONT;
						}
						else
						{
							if ( ViewModel.cboContainerCapacityUnits.SelectedIndex == -1 )
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
							if ( ViewModel.cboContainerType.SelectedIndex == -1 )
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
					if ( ViewModel.txtEstAmountReleased.Text == "" )
					{
						ViewModel.txtEstAmountReleased.BackColor = IncidentMain.Shared.REQCOLOR;
						ViewModel.txtEstAmountReleased.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
						result = 0;
					}
					else if ( !Double.TryParse(ViewModel.txtEstAmountReleased.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp8) )
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
					if ( ViewModel.cboAmountReleasedUnits.SelectedIndex == -1 )
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
					if ( ViewModel.cboPhysicalStateStored.SelectedIndex == -1 )
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
					if ( ViewModel.cboPhysicalStateReleased.SelectedIndex == -1 )
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
					if ( ViewModel.cboPrimaryReleasedInto.SelectedIndex == -1 )
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

			if ( ViewModel.cboDisposition.SelectedIndex == -1 )
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
			ViewModel.cmdSave.Enabled = result != 0;

			return result;
		}

		private void FormatFrame()
		{
			//Format Frame Controls as Needed
			TFDIncident.clsFireCodes FireCodes = Container.Resolve<clsFireCodes>();
			ViewModel.FirstTime = -1;

			switch ( ViewModel.CurrFrame.Name )
			{
				case "frmHazmatType":
					ViewModel.NavButton[0].Visible = true;
					ViewModel.NavButton[1].Visible = false;
					ViewModel.NavButton[2].Visible = false;
					ViewModel.NavButton[3].Visible = false;
					ViewModel.NavButton[4].Visible = false;
					break;
				case "frmHazReleaseInfo":
					if ( ViewModel.CurrReport == IncidentMain.HAZMATMOBILE )
					{
						ViewModel.lbGenPropUse.Visible = false;
						ViewModel.cboGeneralPropertyUse.Visible = false;
						ViewModel.cboSpecificPropertyUse.Items.Clear();
						ViewModel.cboAreaOfOrigin.Items.Clear();
						FireCodes.GetPropertyUseByClass(7);
						//FireCodes.PropertyUse.Open();

						while ( !FireCodes.PropertyUse.EOF )
						{
							ViewModel.cboSpecificPropertyUse.AddItem(IncidentMain.Clean(FireCodes.PropertyUse["description"]));
							ViewModel.cboSpecificPropertyUse.SetItemData(ViewModel.cboSpecificPropertyUse.GetNewIndex(), Convert.ToInt32(FireCodes.PropertyUse["property_use_code"]));
							FireCodes.PropertyUse.MoveNext();
						}
						;

						while ( !FireCodes.AreaOfOrigin.EOF )
						{
							ViewModel.cboAreaOfOrigin.AddItem(IncidentMain.Clean(FireCodes.AreaOfOrigin["description"]));
							ViewModel.cboAreaOfOrigin.SetItemData(ViewModel.cboAreaOfOrigin.GetNewIndex(), Convert.ToInt32(FireCodes.AreaOfOrigin["area_of_origin_code"]));
							FireCodes.AreaOfOrigin.MoveNext();
						}
						;
						ViewModel.lbStreetClass.Visible = true;
						ViewModel.cboStreetClass.Visible = true;
						ViewModel.lbReleaseFloor.Visible = false;
						ViewModel.txtReleaseFloor.Visible = false;
					}
					else
					{
						ViewModel.lbGenPropUse.Visible = true;
						ViewModel.cboGeneralPropertyUse.Visible = true;
						ViewModel.lbStreetClass.Visible = false;
						ViewModel.cboStreetClass.Visible = false;
						ViewModel.lbReleaseFloor.Visible = true;
						ViewModel.txtReleaseFloor.Visible = true;
					}
					ViewModel.NavButton[0].Visible = true;
					ViewModel.NavButton[1].Visible = true;
					ViewModel.NavButton[2].Visible = true;
					ViewModel.NavButton[3].Visible = true;
					ViewModel.NavButton[4].Visible = false;
					break;
				case "frmDrugLab":
					ViewModel.NavButton[0].Visible = true;
					ViewModel.NavButton[1].Visible = true;
					ViewModel.NavButton[2].Visible = true;
					ViewModel.NavButton[3].Visible = true;
					ViewModel.NavButton[4].Visible = false;
					break;
				case "frmReportStatus":
					ViewModel.NavButton[0].Visible = true;
					ViewModel.NavButton[1].Visible = true;
					ViewModel.NavButton[2].Visible = false;
					ViewModel.NavButton[3].Visible = false;
					ViewModel.NavButton[4].Visible = false;
					LoadReportStatus();

					break;
			}
			ViewModel.CurrFrame.Visible = true;
			ViewModel.FirstTime = 0;

		}

		private void FlipImage()
		{
			//Generate random image pick

			VBMath.Randomize();
			int ImageNumber = Convert.ToInt32(Math.Floor((double)(35 * VBMath.Rnd() + 1)));
			string ImageFile = IncidentMain.IMAGEPATH + ImageNumber.ToString() + ".jpg";

		}


		private void StepBack()
		{
            //Navigate to Previous Reporting Step

            ViewModel.CurrFrame.Visible = false;

            switch ( ViewModel.CurrFrame.Name )
			{
				case "frmDrugLab":
					ViewModel.CurrFrame = ViewModel.frmHazmatType;
					ViewModel.NavButton[0].Visible = true;
					ViewModel.NavButton[1].Visible = false;
					ViewModel.NavButton[2].Visible = true;
					ViewModel.NavButton[3].Visible = false;
					ViewModel.NavButton[4].Visible = false;
					break;
				case "frmHazReleaseInfo":
					if ( ViewModel.CurrReport == IncidentMain.HAZMATDLRELEASE )
					{
						ViewModel.CurrFrame = ViewModel.frmDrugLab;
					}
					else
					{
						ViewModel.CurrFrame = ViewModel.frmHazmatType;
					}
					ViewModel.NavButton[0].Visible = true;
					ViewModel.NavButton[1].Visible = false;
					ViewModel.NavButton[2].Visible = true;
					ViewModel.NavButton[3].Visible = false;
					ViewModel.NavButton[4].Visible = false;
					break;
				case "frmChemicalDetail":
					ViewModel.CurrFrame = ViewModel.frmHazReleaseInfo;
					ViewModel.NavButton[0].Visible = true;
					ViewModel.NavButton[1].Visible = true;
					ViewModel.NavButton[2].Visible = true;
					ViewModel.NavButton[3].Visible = true;
					ViewModel.NavButton[4].Visible = false;
					break;
				case "frmNarration":
					if ( ViewModel.CurrReport == IncidentMain.HAZMATDL )
					{
						ViewModel.CurrFrame = ViewModel.frmDrugLab;
					}
					else
					{
						ViewModel.CurrFrame = ViewModel.frmChemicalDetail;
					}
					ViewModel.NavButton[0].Visible = true;
					ViewModel.NavButton[1].Visible = true;
					ViewModel.NavButton[2].Visible = true;
					ViewModel.NavButton[3].Visible = true;
					ViewModel.NavButton[4].Visible = false;
					break;
				case "frmReportStatus":
					ViewModel.CurrFrame = ViewModel.frmNarration;
					ViewModel.NavButton[0].Visible = true;
					ViewModel.NavButton[1].Visible = true;
					ViewModel.NavButton[2].Visible = true;
					ViewModel.NavButton[3].Visible = true;
					ViewModel.NavButton[4].Visible = false;
					break;
			}
            ViewModel.CurrFrame.Visible = true;

        }

		private void StepNext()
		{
			//Navigate to Next Reporting Step
            ViewModel.CurrFrame.Visible = false;

            string switchVar = ViewModel.CurrFrame.Name;
			if ( switchVar == "frmHazmatType" )
			{
				switch ( ViewModel.CurrReport )
				{
					case IncidentMain.HAZMATDL : case IncidentMain.HAZMATDLRELEASE :
						ViewModel.CurrFrame = ViewModel.frmDrugLab;
						break;
					default:
						ViewModel.CurrFrame = ViewModel.frmHazReleaseInfo;
						break;
				}
			}
			else if ( switchVar == "frmDrugLab" )
			{
				if ( ViewModel.CurrReport == IncidentMain.HAZMATDLRELEASE )
				{
					ViewModel.CurrFrame = ViewModel.frmHazReleaseInfo;
				}
				else
				{
					ViewModel.CurrFrame = ViewModel.frmNarration;
				}
			}
			else if ( switchVar == "frmHazReleaseInfo" )
			{
				ViewModel.CurrFrame = ViewModel.frmChemicalDetail;
			}
			else if ( switchVar == "frmChemicalDetail" )
			{
				ViewModel.CurrFrame = ViewModel.frmNarration;
			}
			else if ( switchVar == "frmNarration" )
			{
				ViewModel.CurrFrame = ViewModel.frmReportStatus;
			}

			FormatFrame();

		}

		private void StepQuit()
		{
			//Display Save as Incomplete msgbox
			//And Exit
			if ( CheckComplete() != 0 )
			{
				if ( SaveHazmatReport(IncidentMain.COMPLETE) != 0 )
				{
					ViewManager.ShowMessage("Hazmat Report Saved as Complete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
				}
				else
				{
					ViewManager.ShowMessage("Error Attempting to Save Hazmat Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				}
			}
			else
			{
				if ( SaveHazmatReport(IncidentMain.SAVEDINCOMPLETE) != 0 )
				{
					ViewManager.ShowMessage("Hazmat Report Saved as Incomplete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
				}
				else
				{
					ViewManager.ShowMessage("Error Attempting to Save Hazmat Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				}
			}
			IncidentMain.Shared.gWizCancel = -1;

			ViewManager.DisposeView(this);

		}

		private void StepFinish()
		{
			//Determine Reporting Status
			//And Exit Saving or Exit Not Saving or Cancel Finish Request
			IncidentMain
				.Shared.gWizCancel = 0;
			ViewManager.DisposeView(this);

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboAmountReleasedUnits_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboAreaAffectedUnits_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboAreaEvacuatedUnits_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboAreaOfOrigin_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboCauseOfRelease_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboChemicalName_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Sync Chemical Selection Combos and save
			//selected Chemical ID in hidden label (lbChemicalID)

			if ( ViewModel.cboChemicalName.SelectedIndex == -1 )
			{
				return ;
			}
			if ( ViewModel.FirstTime != 0 )
			{
				return ;
			}
			ViewModel.FirstTime = -1;

			int SelectedChemical = ViewModel.cboChemicalName.GetItemData(ViewModel.cboChemicalName.SelectedIndex);
			ViewModel.lbChemicalID.Text = SelectedChemical.ToString();
			ViewModel.cboCommonChemicals.SelectedIndex = -1;
			for ( int i = 0; i <= ViewModel.cboCommonChemicals.Items.Count - 1; i++ )
			{
				if ( ViewModel.cboCommonChemicals.GetItemData(i) == SelectedChemical )
				{
					ViewModel.cboCommonChemicals.SelectedIndex = i;
					break;
				}
			}
			for ( int i = 0; i <= ViewModel.cboUN.Items.Count - 1; i++ )
			{
				if ( ViewModel.cboUN.GetItemData(i) == SelectedChemical )
				{
					ViewModel.cboUN.SelectedIndex = i;
					break;
				}
			}
			ViewModel.FirstTime = 0;
			CheckComplete();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboCommonChemicals_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Sync Chemical Selection Combos and save
			//selected Chemical ID in hidden label (lbChemicalID)

			if ( ViewModel.cboCommonChemicals.SelectedIndex == -1 )
			{
				return ;
			}
			if ( ViewModel.FirstTime != 0 )
			{
				return ;
			}
			ViewModel.FirstTime = -1;

			int SelectedChemical = ViewModel.cboCommonChemicals.GetItemData(ViewModel.cboCommonChemicals.SelectedIndex);
			ViewModel.lbChemicalID.Text = SelectedChemical.ToString();
			for ( int i = 0; i <= ViewModel.cboChemicalName.Items.Count - 1; i++ )
			{
				if ( ViewModel.cboChemicalName.GetItemData(i) == SelectedChemical )
				{
					ViewModel.cboChemicalName.SelectedIndex = i;
					break;
				}
			}
			for ( int i = 0; i <= ViewModel.cboUN.Items.Count - 1; i++ )
			{
				if ( ViewModel.cboUN.GetItemData(i) == SelectedChemical )
				{
					ViewModel.cboUN.SelectedIndex = i;
					break;
				}
			}
			ViewModel.FirstTime = 0;
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboContainerCapacityUnits_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboContainerType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboDisposition_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboDrugLabType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboGeneralPropertyUse_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Reload Specific Property Use and Area of Origin Combos
			TFDIncident.clsFireCodes FireCodes = Container.Resolve<clsFireCodes>();
			ViewModel.FirstTime = -1;

			if ( ViewModel.cboGeneralPropertyUse.SelectedIndex == -1 )
			{
				return ;
			}
			int PropClass = ViewModel.cboGeneralPropertyUse.GetItemData(ViewModel.cboGeneralPropertyUse.SelectedIndex);
			ViewModel.cboSpecificPropertyUse.Items.Clear();
			ViewModel.cboAreaOfOrigin.Items.Clear();
			FireCodes.GetPropertyUseByClass(PropClass);
			//FireCodes.PropertyUse.Open();

			while ( !FireCodes.PropertyUse.EOF )
			{
				ViewModel.cboSpecificPropertyUse.AddItem(IncidentMain.Clean(FireCodes.PropertyUse["description"]));
				ViewModel.cboSpecificPropertyUse.SetItemData(ViewModel.cboSpecificPropertyUse.GetNewIndex(), Convert.ToInt32(FireCodes.PropertyUse["property_use_code"]));
				FireCodes.PropertyUse.MoveNext();
			}
			;

			while ( !FireCodes.AreaOfOrigin.EOF )
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
		internal void cboHazmatIDSource_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboIncidentType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboMaterialUsed_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Check to see if AddMaterials button should be enabled
			double dbNumericTemp = 0;
			if ( ViewModel.cboMaterialUsed.SelectedIndex == -1 )
			{
				ViewModel.cmdAddMaterial.Enabled = false;
				return ;
			}
			else if ( ViewModel.txtQuantity.Text == "" )
			{
				ViewModel.cmdAddMaterial.Enabled = false;
				return ;
			}
			else if ( !Double.TryParse(ViewModel.txtQuantity.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp) )
			{
				ViewModel.txtQuantity.Text = "";
				ViewModel.cmdAddMaterial.Enabled = false;
				return ;
			}
			else
			{
				ViewModel.cmdAddMaterial.Enabled = true;
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboOutsideResource_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Check to see if AddOutsideResource button should be enabled

			if ( ViewModel.cboOutsideResource.SelectedIndex == -1 )
			{
				ViewModel.cmdAddResource.Enabled = false;
			}
			else if ( ViewModel.cboResourceUse.SelectedIndex == -1 )
			{
				ViewModel.cmdAddResource.Enabled = false;
			}
			else
			{
				ViewModel.cmdAddResource.Enabled = true;
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboPhysicalStateReleased_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboPhysicalStateStored_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboPopulationDensity_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboPrimaryReleasedInto_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboResourceUse_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Check to see if AddOutsideResource button should be enabled

			if ( ViewModel.cboOutsideResource.SelectedIndex == -1 )
			{
				ViewModel.cmdAddResource.Enabled = false;
			}
			else if ( ViewModel.cboResourceUse.SelectedIndex == -1 )
			{
				ViewModel.cmdAddResource.Enabled = false;
			}
			else
			{
				ViewModel.cmdAddResource.Enabled = true;
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboSpecificPropertyUse_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboUN_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Sync Chemical Selection Combos and save
			//selected Chemical ID in hidden label (lbChemicalID)

			if ( ViewModel.cboUN.SelectedIndex == -1 )
			{
				return ;
			}
			if ( ViewModel.FirstTime != 0 )
			{
				return ;
			}
			ViewModel.FirstTime = -1;

			int SelectedChemical = ViewModel.cboUN.GetItemData(ViewModel.cboUN.SelectedIndex);
			ViewModel.lbChemicalID.Text = SelectedChemical.ToString();
			ViewModel.cboCommonChemicals.SelectedIndex = -1;
			for ( int i = 0; i <= ViewModel.cboCommonChemicals.Items.Count - 1; i++ )
			{
				if ( ViewModel.cboCommonChemicals.GetItemData(i) == SelectedChemical )
				{
					ViewModel.cboCommonChemicals.SelectedIndex = i;
					break;
				}
			}
			for ( int i = 0; i <= ViewModel.cboChemicalName.Items.Count - 1; i++ )
			{
				if ( ViewModel.cboChemicalName.GetItemData(i) == SelectedChemical )
				{
					ViewModel.cboChemicalName.SelectedIndex = i;
					break;
				}
			}
			ViewModel.FirstTime = 0;
			CheckComplete();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAbandon_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Delete all records created for this Hazmat Incident
			//And Exit Form
			TFDIncident.clsHazmat HazmatCL = Container.Resolve<clsHazmat>();
			ViewManager.ShowMessage("All Changes Abandoned - Better Luck Next Time!", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);

			if ( ViewModel.CurrReport == IncidentMain.HAZMATDL || ViewModel.CurrReport == IncidentMain.HAZMATDLRELEASE )
			{
				if ( ~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
						{
							var ret = HazmatCL.DeleteHazmatDrugLab(ref p1);
							ViewModel.HazmatDLID = p1;
							return ret;
						}, ViewModel.HazmatDLID) != 0 )
				{
					ViewManager.ShowMessage("Error Deleting Hazmat Drug Lab Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				}
			}
			if ( ViewModel.CurrReport != IncidentMain.HAZMATDL )
			{
				if ( ~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
						{
							var ret = HazmatCL.DeleteHazmatRelease(ref p1);
							ViewModel.HazmatID = p1;
							return ret;
						}, ViewModel.HazmatID) != 0 )
				{
					ViewManager.ShowMessage("Error Deleting Hazmat Release Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				}
			}
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAddMaterial_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Check to make sure valid selections made
			//Add FireServiceMaterialUsed Record
			double dbNumericTemp = 0;
			if ( ViewModel.cboMaterialUsed.SelectedIndex == -1 )
			{
				ViewModel.cmdAddMaterial.Enabled = false;
				return ;
			}
			else if ( ViewModel.txtQuantity.Text == "" )
			{
				ViewModel.cmdAddMaterial.Enabled = false;
				return ;
			}
			else if ( !Double.TryParse(ViewModel.txtQuantity.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp) )
			{
				ViewModel.cmdAddMaterial.Enabled = false;
				return ;
			}
			TFDIncident.clsHazmat HazmatCL = Container.Resolve<clsHazmat>();

			HazmatCL.MUHazmatID = ViewModel.HazmatDLID;
			HazmatCL.FireServiceMaterial = ViewModel.cboMaterialUsed.GetItemData(ViewModel.cboMaterialUsed.SelectedIndex);
			HazmatCL.MaterialQuantity = Convert.ToInt32(Conversion.Val(ViewModel.txtQuantity.Text));
			if ( ~HazmatCL.AddHazmatFireServiceMaterialsUsed() != 0 )
			{
				ViewManager.ShowMessage("Error Attempting to Add Material Used Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
			}

			LoadMaterialUsed();
			ViewModel.cboMaterialUsed.SelectedIndex = -1;
			ViewModel.txtQuantity.Text = "";

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAddResource_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Check to see if OutsideResource can be added

			if ( ViewModel.cboOutsideResource.SelectedIndex == -1 )
			{
				ViewModel.cmdAddResource.Enabled = false;
				return ;
			}
			else if ( ViewModel.cboResourceUse.SelectedIndex == -1 )
			{
				ViewModel.cmdAddResource.Enabled = false;
				return ;
			}
			TFDIncident.clsHazmat HazmatCL = Container.Resolve<clsHazmat>();

			if ( ViewModel.CurrReport == IncidentMain.HAZMATDL )
			{
				HazmatCL.ORDLHazmatID = ViewModel.HazmatDLID;
				HazmatCL.DLOutsideResource = ViewModel.cboOutsideResource.GetItemData(ViewModel.cboOutsideResource.SelectedIndex);
				HazmatCL.DLResourceUse = ViewModel.cboResourceUse.GetItemData(ViewModel.cboResourceUse.SelectedIndex);
				if ( ~HazmatCL.AddHazmatDLOutsideResource() != 0 )
				{
					ViewManager.ShowMessage("Error Attempting to Add Outside Resource Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				}
			}
			else
			{
				HazmatCL.ORHazmatID = ViewModel.HazmatID;
				HazmatCL.OutsideResource = ViewModel.cboOutsideResource.GetItemData(ViewModel.cboOutsideResource.SelectedIndex);
				HazmatCL.ResourceUse = ViewModel.cboResourceUse.GetItemData(ViewModel.cboResourceUse.SelectedIndex);
				if ( ~HazmatCL.AddHazmatOutsideResource() != 0 )
				{
					ViewManager.ShowMessage("Error Attempting to Add Outside Resource Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				}
			}

			LoadOutsideResource();
			ViewModel.cboOutsideResource.SelectedIndex = -1;
			ViewModel.cboResourceUse.SelectedIndex = -1;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdMoreChemicals_Click(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ~SaveChemicalDetail() != 0 )
			{
				ViewManager.ShowMessage("Error Attempting to Add Chemical Detail Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdRemoveMaterial_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Check to make sure that item has been selected
			TFDIncident.clsHazmat HazmatCL = Container.Resolve<clsHazmat>();

			int MaterialSelected = 0;
			for ( int i = 0; i <= ViewModel.lstMaterialUsed.Items.Count - 1; i++ )
			{
				if ( ViewModel.lstMaterialUsed.GetSelected(i) )
				{
					MaterialSelected = -1;
					break;
				}
			}

			if ( ~MaterialSelected != 0 )
			{
				return ;
			} //no items selected

			for ( int i = 0; i <= ViewModel.lstMaterialUsed.Items.Count - 1; i++ )
			{
				if ( ViewModel.lstMaterialUsed.GetSelected(i) )
				{
					MaterialSelected = ViewModel.lstMaterialUsed.GetItemData(i);
					if ( ~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
							{
								var ret = HazmatCL.DeleteHazmatFireServiceMaterialsUsed(ref p1, ref MaterialSelected);
								ViewModel.HazmatDLID = p1;
								return ret;
							}, ViewModel.HazmatDLID) != 0 )
					{
						ViewManager.ShowMessage("Error Deleting Hazmat Material Used Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
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
			TFDIncident.clsHazmat HazmatCL = Container.Resolve<clsHazmat>();

			int ResourceSelected = 0;
			for ( int i = 0; i <= ViewModel.lstOutsideResource.Items.Count - 1; i++ )
			{
				if ( ViewModel.lstOutsideResource.GetSelected(i) )
				{
					ResourceSelected = -1;
					break;
				}
			}

			if ( ~ResourceSelected != 0 )
			{
				return ;
			} //no items selected

			if ( ViewModel.CurrReport == IncidentMain.HAZMATDL )
			{
				for ( int i = 0; i <= ViewModel.lstOutsideResource.Items.Count - 1; i++ )
				{
					if ( ViewModel.lstOutsideResource.GetSelected(i) )
					{
						ResourceSelected = ViewModel.lstOutsideResource.GetItemData(i);
						if ( ~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
								{
									var ret = HazmatCL.DeleteHazmatDLOutsideResource(ref p1, ref ResourceSelected);
									ViewModel.HazmatDLID = p1;
									return ret;
								}, ViewModel.HazmatDLID) != 0 )
						{
							ViewManager.ShowMessage("Error Deleting Outside Resource Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							break;
						}
					}
				}
			}
			else
			{
				for ( int i = 0; i <= ViewModel.lstOutsideResource.Items.Count - 1; i++ )
				{
					if ( ViewModel.lstOutsideResource.GetSelected(i) )
					{
						ResourceSelected = ViewModel.lstOutsideResource.GetItemData(i);
						if ( ~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
								{
									var ret = HazmatCL.DeleteHazmatOutsideResource(ref p1, ref ResourceSelected);
									ViewModel.HazmatID = p1;
									return ret;
								}, ViewModel.HazmatID) != 0 )
						{
							ViewManager.ShowMessage("Error Deleting Outside Resource Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
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
			//Save Hazmat Report as complete
			if ( ~SaveHazmatReport(IncidentMain.COMPLETE) != 0 )
			{
				ViewManager.ShowMessage("Error attempting to Save Hazmat Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
			}
			else
			{
				ViewManager.ShowMessage("Hazmat Report Saved as Complete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
			}
			ViewManager.DisposeView(this);

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdSaveIncomplete_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Save Hazmat Report as complete
			if ( ~SaveHazmatReport(IncidentMain.SAVEDINCOMPLETE) != 0 )
			{
				ViewManager.ShowMessage("Error attempting to Save Hazmat Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
			}
			else
			{
				ViewManager.ShowMessage("Hazmat Report Saved as Incomplete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
			}
			ViewManager.DisposeView(this);

		}

		private void Form_Load()
		{
			//Format Initial Load of Hazmat Report Entry Wizard
			TFDIncident.clsReportLog ReportLog = Container.Resolve<clsReportLog>();
			TFDIncident.clsIncident IncidentCL = Container.Resolve<clsIncident>();

			if ( ReportLog.GetReportLog(IncidentMain.Shared.gNewReportID) != 0 )
			{
				ViewModel.CurrIncident = ReportLog.RLIncidentID;
				ViewModel.ReportLogID = ReportLog.ReportLogID;
			}
			else
			{
				ViewManager.ShowMessage("Error Retrieving ReportLog Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				ViewManager.DisposeView(this);
				return ;
			}

			if ( IncidentCL.GetIncident(ViewModel.CurrIncident) != 0 )
			{
				ViewModel.lbLocation.Text = IncidentMain.Clean(IncidentCL.Location);
				ViewModel.lbIncidentNo.Text = IncidentMain.Clean(IncidentCL.IncidentNumber);
			}
			else
			{
				ViewManager.ShowMessage("Error Retrieving Incident Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
			}
			ViewModel.lbUnit.Text = IncidentMain.Shared.gWizardUnitID;
			ViewModel.FirstTime = -1;
			ViewModel.ReportSaved = 0;
			ViewModel.SaveChemical = 0;
			ViewModel.ChemicalsLoaded = 0;
			LoadLists();
			ViewModel.CurrFrame = ViewModel.frmHazmatType;
			FormatFrame();
			ViewModel.FirstTime = 0;
			CheckComplete();
			//IncidentMain.MoveForm(wzdHazmat.DefInstance);
		}

		[UpgradeHelpers.Events.Handler]
		internal void NavButton_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				int Index = this.ViewModel.NavButton.IndexOf((UpgradeHelpers.BasicViewModels.ButtonViewModel)eventSender);
				//Navigation Button Pressed
				UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;

				clsHazmat HazmatCL = null;
				using ( var async2 = this.Async() )
				{
					switch ( Index )
					{
						case 0: //Cancel 

							async2.Append<UpgradeHelpers.Helpers.DialogResult>(()
									=> ViewManager.ShowMessage("Do you wish to Exit Without Saving any Changes?", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.YesNo));
							async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
							async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
								{
									Response = tempNormalized1;
								});
							async2.Append(() =>
								{
									if ( Response == UpgradeHelpers.Helpers.DialogResult.Yes )
									{
										//Delete all records created for this Hazmat Incident
										//And Exit Form
										HazmatCL
											= Container.Resolve< clsHazmat>();
										if ( ViewModel.ReportSaved != 0 )
										{
											if ( ViewModel.CurrReport == IncidentMain.HAZMATDL || ViewModel.CurrReport == IncidentMain.HAZMATDLRELEASE )
											{
												if ( ~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
														{
															var ret = HazmatCL.DeleteHazmatDrugLab(ref p1);
															ViewModel.HazmatDLID = p1;
															this.Return(() => ret);
															return 0;
														}, ViewModel.HazmatDLID) != 0 )
												{
													ViewManager.ShowMessage("Error Deleting Hazmat Drug Lab Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
												}
											}
											if ( ViewModel.CurrReport != IncidentMain.HAZMATDL )
											{
												if ( ~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
														{
															var ret = HazmatCL.DeleteHazmatRelease(ref p1);
															ViewModel.HazmatID = p1;
															this.Return(() => ret);
															return 0 ;
														}, ViewModel.HazmatID) != 0 )
												{
													ViewManager.ShowMessage("Error Deleting Hazmat Release Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
												}
											}
										}
										IncidentMain.Shared.gWizCancel = -1;
										ViewManager.DisposeView(this);
									}
									else
									{
										this.Return();
										return ;
									}
								});
							break;
						case 1: //Back 
							StepBack();
							break;
						case 2: //Next 
							StepNext();
							break;
						case 3: //Quit 
							StepQuit();
							break;
						case 4: //Finish 
							StepFinish();
							break;
					}
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void optType_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
			{
				if ( ViewModel.isInitializingComponent )
				{
					return ;
				}
				int Index = this.ViewModel.optType.IndexOf((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender);
				//Set CurrReport as selected type
				//Enable Next button
				if ( ViewModel.FirstTime != 0 )
				{
					return ;
				}
				TFDIncident.clsHazmat HazmatCL = Container.Resolve<clsHazmat>();

				int InitialType = ViewModel.CurrReport;
				switch ( Index )
				{
					case 0:
						if ( ViewModel.ReportSaved != 0 )
						{
							if ( ViewModel.CurrReport == IncidentMain.HAZMATDL || ViewModel.CurrReport == IncidentMain.HAZMATDLRELEASE )
							{
								if ( ~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
										{
											var ret = HazmatCL.DeleteHazmatDrugLab(ref p1);
											ViewModel.HazmatDLID = p1;
											return ret;
										}, ViewModel.HazmatDLID) != 0 )
								{
									ViewManager.ShowMessage("Error Removing Hazmat Drug Lab Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
								ViewModel.ReportSaved = 0;
							}
						}
						ViewModel.CurrReport = IncidentMain.HAZMATFIXED;
						if ( ~ViewModel.ChemicalsLoaded != 0 )
						{
							LoadChemicalLists();
						}
						break;
					case 1:
						if ( ViewModel.ReportSaved != 0 )
						{
							if ( ViewModel.CurrReport == IncidentMain.HAZMATDL || ViewModel.CurrReport == IncidentMain.HAZMATDLRELEASE )
							{
								if ( ~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
										{
											var ret = HazmatCL.DeleteHazmatDrugLab(ref p1);
											ViewModel.HazmatDLID = p1;
											return ret;
										}, ViewModel.HazmatDLID) != 0 )
								{
									ViewManager.ShowMessage("Error Removing Hazmat Drug Lab Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
								ViewModel.ReportSaved = 0;
							}
						}
						ViewModel.CurrReport = IncidentMain.HAZMATMOBILE;
						for ( int i = 0; i <= ViewModel.cboGeneralPropertyUse.Items.Count - 1; i++ )
						{
							if ( ViewModel.cboGeneralPropertyUse.GetItemData(i) == 7 )
							{ //Mobile Property Use Type

								ViewModel.cboGeneralPropertyUse.SelectedIndex = i;
								break;
							}
						}
						ViewModel.cboGeneralPropertyUse.Visible = false;
						ViewModel.lbGenPropUse.Visible = false;
						if ( ~ViewModel.ChemicalsLoaded != 0 )
						{
							LoadChemicalLists();
						}
						break;
					case 2:
						if ( ViewModel.ReportSaved != 0 )
						{
							if ( ViewModel.CurrReport != IncidentMain.HAZMATDL )
							{
								if ( ~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
										{
											var ret = HazmatCL.DeleteHazmatRelease(ref p1);
											ViewModel.HazmatID = p1;
											return ret;
										}, ViewModel.HazmatID) != 0 )
								{
									ViewManager.ShowMessage("Error Removing Hazmat Release Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
								ViewModel.ReportSaved = 0;
							}
						}
						ViewModel.CurrReport = IncidentMain.HAZMATDL;
						break;
					case 3:
						ViewModel.CurrReport = IncidentMain.HAZMATDLRELEASE;
						if ( ~ViewModel.ChemicalsLoaded != 0 )
						{
							LoadChemicalLists();
						}
						break;
				}

				//Save Partial Hazmat Report and Retrieve HazmatID
				if ( ~ViewModel.ReportSaved != 0 )
				{
					if ( ViewModel.CurrReport == IncidentMain.HAZMATDL || ViewModel.CurrReport == IncidentMain.HAZMATDLRELEASE )
					{
						HazmatCL.DLIncidentID = ViewModel.CurrIncident;
						HazmatCL.DrugLabType = 0;
						HazmatCL.DLHazmatIDSource = 0;
						HazmatCL.DLDispositionOfRelease = 0;
						HazmatCL.DLFlagRelease = 0;
						if ( ~HazmatCL.AddHazmatDrugLab() != 0 )
						{
							ViewManager.ShowMessage("Error Attempting Creation of Hazmat Drug Lab Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.
								BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						}
						else
						{
							ViewModel.HazmatDLID = HazmatCL.DLHazmatID;
							ViewModel.ReportSaved = -1;
						}
					}
					if ( ViewModel.CurrReport != IncidentMain.HAZMATDL )
					{
						HazmatCL.IncidentID = ViewModel.CurrIncident;
						HazmatCL.IncidentTypeCode = 0; // Change This, should be apparent
						HazmatCL.HazmatIDSource = 0;
						HazmatCL.DispositionOfRelease = 0;
						HazmatCL.CauseOfRelease = 0;
						HazmatCL.AreaEffected = 0;
						HazmatCL.EffectedAreaUnit = 0;
						HazmatCL.AreaEvacuated = 0;
						HazmatCL.EvacuatedAreaUnit = 0;
						HazmatCL.PopulationDensity = 0;
						HazmatCL.BuildingsEvacuated = 0;
						HazmatCL.PeopleEvacuated = 0;
						HazmatCL.AreaOfOrigin = 0;
						HazmatCL.OccuredFirst = 0;
						HazmatCL.StreetClass = 0;
						HazmatCL.ReleaseFloor = 0;
						HazmatCL.PropertyUse = 0;
						if ( ~HazmatCL.AddHazmatRelease() != 0 )
						{
							ViewManager.ShowMessage("Error Attempting Creation of Hazmat Release Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons
								.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						}
						else
						{
							ViewModel.HazmatID = HazmatCL.HazmatID;
							ViewModel.ReportSaved = -1;
						}
					}
				}
				else if ( InitialType == IncidentMain.HAZMATDL && ViewModel.CurrReport == IncidentMain.HAZMATDLRELEASE )
				{ //ReportType Changed
					HazmatCL.IncidentID = ViewModel.CurrIncident;
					HazmatCL.IncidentTypeCode = 0; // Change This, should be apparent
					HazmatCL.HazmatIDSource = 0;
					HazmatCL.DispositionOfRelease = 0;
					HazmatCL.CauseOfRelease = 0;
					HazmatCL.AreaEffected = 0;
					HazmatCL.EffectedAreaUnit = 0;
					HazmatCL.AreaEvacuated = 0;
					HazmatCL.EvacuatedAreaUnit = 0;
					HazmatCL.PopulationDensity = 0;
					HazmatCL.BuildingsEvacuated = 0;
					HazmatCL.PeopleEvacuated = 0;
					HazmatCL.AreaOfOrigin = 0;
					HazmatCL.OccuredFirst = 0;
					HazmatCL.StreetClass = 0;
					HazmatCL.ReleaseFloor = 0;
					HazmatCL.PropertyUse = 0;
					if ( ~HazmatCL.AddHazmatRelease() != 0 )
					{
						ViewManager.ShowMessage("Error Attempting Creation of Hazmat Release Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					}
					else
					{
						ViewModel.HazmatID = HazmatCL.HazmatID;
						ViewModel.ReportSaved = -1;
					}
				}
				else if ( InitialType != IncidentMain.HAZMATDL && ViewModel.CurrReport == IncidentMain.HAZMATDLRELEASE )
				{
					HazmatCL.DLIncidentID = ViewModel.CurrIncident;
					HazmatCL.DrugLabType = 0;
					HazmatCL.DLHazmatIDSource = 0;
					HazmatCL.DLDispositionOfRelease = 0;
					HazmatCL.DLFlagRelease = 0;
					if ( ~HazmatCL.AddHazmatDrugLab() != 0 )
					{
						ViewManager.ShowMessage("Error Attempting Creation of Hazmat Drug Lab Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					}
					else
					{
						ViewModel.HazmatDLID = HazmatCL.DLHazmatID;
						ViewModel.ReportSaved = -1;
					}
				}
				ViewModel.NavButton[2].Visible = true;

			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtAreaAffected_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtAreaEvacuated_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtBuildingsEvacuated_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtEstAmountReleased_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtEstContainerCapacity_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtPeopleEvacuated_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtQuantity_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			//Check to see if AddMaterials button should be enabled
			double dbNumericTemp = 0;
			if ( ViewModel.cboMaterialUsed.SelectedIndex == -1 )
			{
				ViewModel.cmdAddMaterial.Enabled = false;
				return ;
			}
			else if ( ViewModel.txtQuantity.Text == "" )
			{
				ViewModel.cmdAddMaterial.Enabled = false;
				return ;
			}
			else if ( !Double.TryParse(ViewModel.txtQuantity.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp) )
			{
				ViewModel.txtQuantity.Text = "";
				ViewModel.cmdAddMaterial.Enabled = false;
				return ;
			}
			else
			{
				ViewModel.cmdAddMaterial.Enabled = true;
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void txtReleaseFloor_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static wzdHazmat DefInstance
		{
			get
			{
				if ( Shared.m_vb6FormDefInstance == null )
				{
					Shared.
						m_InitializingDefInstance = true;
					Shared.
						m_vb6FormDefInstance = CreateInstance();
					Shared.
						m_InitializingDefInstance = false;
				}
				return Shared.m_vb6FormDefInstance;
			}
			set
			{
				Shared.
					m_vb6FormDefInstance = value;
			}
		}

		public static wzdHazmat CreateInstance()
		{
			TFDIncident.wzdHazmat theInstance = Shared.Container.Resolve<wzdHazmat>();
			theInstance.Form_Load();
			return theInstance;
		}

		void ReLoadForm(bool addEvents)
		{
		}

		protected override void ExecuteControlsStartup()
		{
			ViewModel.frmHazReleaseInfo.LifeCycleStartup();
			ViewModel.frmChemicalDetail.LifeCycleStartup();
			ViewModel.frmDrugLab.LifeCycleStartup();
			ViewModel.frmNarration.LifeCycleStartup();
			ViewModel.frmReportStatus.LifeCycleStartup();
			ViewModel.frmHazmatType.LifeCycleStartup();
			ViewModel.NavBar.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.frmHazReleaseInfo.LifeCycleShutdown();
			ViewModel.frmChemicalDetail.LifeCycleShutdown();
			ViewModel.frmDrugLab.LifeCycleShutdown();
			ViewModel.frmNarration.LifeCycleShutdown();
			ViewModel.frmReportStatus.LifeCycleShutdown();
			ViewModel.frmHazmatType.LifeCycleShutdown();
			ViewModel.NavBar.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class wzdHazmat
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.wzdHazmatViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual wzdHazmat m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}