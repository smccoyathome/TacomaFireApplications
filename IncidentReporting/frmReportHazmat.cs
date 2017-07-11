using Microsoft.VisualBasic;
using System;
using UpgradeHelpers.DB.ADO;
using UpgradeStubs;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident
{

	public partial class frmReportHazmat
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.frmReportHazmatViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmReportHazmat));
			if ( Shared.m_vb6FormDefInstance == null )
			{
				if ( Shared.m_InitializingDefInstance )
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
		}


		private void frmReportHazmat_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender )
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>)eventSender;
			}
		}

		private void LoadHazmatReport()
		{
			//Format Hazmat Report
			TFDIncident.clsHazmat HazmatReport = Container.Resolve<clsHazmat>();
			TFDIncident.clsIncident IncidentCL = Container.Resolve<clsIncident>();
			TFDIncident.clsFireCodes FireCodes = Container.Resolve<clsFireCodes>();
			TFDIncident.clsUnit UnitCL = Container.Resolve<clsUnit>();
			int x = 0;
			string CurrUnit = "";
			string sDisplay = "";
			string sDisplay2 = "";
			ViewModel.sprHazmat.Row = 1;
			ViewModel.sprHazmat.Col = 8;
			ViewModel.sprHazmat.Text = UpgradeHelpers.Helpers.StringsHelper.Format(DateTime.Now, "m/d/yyyy h:nn AM/PM");
			if ( ViewModel.ReportType == IncidentMain.HAZMATDL )
			{
				if ( ~HazmatReport.GetHazmatDrugLabReport(ViewModel.HazmatDLID) != 0 )
				{
					ViewManager.ShowMessage("Error retrieving Hazmat Drug Lab Report", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					return ;
				}
			}
			else
			{
				if ( ~HazmatReport.GetHazmatReport(ViewModel.HazmatID) != 0 )
				{
					ViewManager.ShowMessage("Error retrieving Hazmat Report", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					return ;
				}
			}
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
			this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.WaitCursor);
			ViewModel.CurrRow = 5;
			// ****** Incident Information *****
			if ( IncidentCL.GetIncident(ViewModel.CurrIncident) != 0 )
			{
				if ( ViewModel.PageCountRow > 56 )
				{
					DisplayHeadings();
				}
				else
				{
					ViewModel.sprHazmat.Row = ViewModel.CurrRow;
					ViewModel.sprHazmat.Col = 2;
					ViewModel.sprHazmat.Text = IncidentCL.IncidentNumber;
					ViewModel.IncidentNumber = IncidentCL.IncidentNumber;
					(ViewModel.CurrRow)++;
					ViewModel.sprHazmat.Row = ViewModel.CurrRow;
					ViewModel.sprHazmat.Col = 2;
					ViewModel.sprHazmat.Text = DateTime.Parse(IncidentCL.DateIncidentCreated).ToString("M/d/yyyy   HH:mm");
					(ViewModel.CurrRow)++;
					ViewModel.sprHazmat.Row = ViewModel.CurrRow;
					ViewModel.sprHazmat.Col = 2;
					ViewModel.sprHazmat.Text = IncidentCL.Location;
					ViewModel.CurrRow = 4;
					//Unit Times
					if ( UnitCL.GetUnitResponseTimesReport(ViewModel.CurrIncident) != 0 )
					{
						(ViewModel.CurrRow)++;
						ViewModel.sprHazmat.Row = ViewModel.CurrRow;

						while ( !UnitCL.UnitTimes.EOF )
						{
							if ( Convert.ToString(UnitCL.UnitTimes["Unit"]) != CurrUnit )
							{
								(ViewModel.CurrRow)++;
								ViewModel.sprHazmat.Row = ViewModel.CurrRow;
								CurrUnit = Convert.ToString(UnitCL.UnitTimes["Unit"]);
								ViewModel.sprHazmat.Col = 5;
								ViewModel.sprHazmat.Text = IncidentMain.Clean(UnitCL.UnitTimes["unit_name"]);
							}
							switch ( Convert.ToInt32(UnitCL.UnitTimes["response_time_code"]) )
							{
								case 3: //Dispatched 

									ViewModel.sprHazmat.Col = 7;
									ViewModel.sprHazmat.Text = Convert.ToDateTime(UnitCL.UnitTimes["unit_time"]).ToString("HH:mm");
									break;
								case 5: //onscene 

									ViewModel.sprHazmat.Col = 8;
									ViewModel.sprHazmat.Text = Convert.ToDateTime(UnitCL.UnitTimes["unit_time"]).ToString("HH:mm");
									break;
								case 8: //available 

									ViewModel.sprHazmat.Col = 9;
									ViewModel.sprHazmat.Text = Convert.ToDateTime(UnitCL.UnitTimes["unit_time"]).ToString("HH:mm");
									break;
							}
							UnitCL.UnitTimes.MoveNext();
						}
						;
					}
				}
			}
			ViewModel.SaveRow = ViewModel.CurrRow;
			// ****** 'Drug Lab Report *****
			ViewModel.sprHazmat.Col = 1;
			if ( ViewModel.ReportType == IncidentMain.HAZMATDL || ViewModel.ReportType == IncidentMain.HAZMATDLRELEASE )
			{
				if ( HazmatReport.GetHazmatDrugLabReport(ViewModel.HazmatDLID) != 0 )
				{
					ViewModel.CurrRow = ViewModel.SaveRow;
					(ViewModel.CurrRow)++;
					ViewModel.sprHazmat.Row = ViewModel.CurrRow;
					ViewModel.sprHazmat.Col = 1;
					ViewModel.sprHazmat.Text = "Hazmat Drug Lab Detail Information";
					ViewModel.sprHazmat.FontSize = 10;
					ViewModel.sprHazmat.FontBold = true;
					ViewModel.sprHazmat.FontItalic = true;
					ViewModel.sprHazmat.BlockMode = true;
					ViewModel.sprHazmat.Row2 = ViewModel.CurrRow;
					ViewModel.sprHazmat.Col2 = 10;
					ViewModel.sprHazmat.BackColor = IncidentMain.Shared.LTGRAY;
					ViewModel.sprHazmat.BlockMode = false;
					(ViewModel.CurrRow)++;
					ViewModel.sprHazmat.Row = ViewModel.CurrRow;
					ViewModel.sprHazmat.Col = 1;
					ViewModel.sprHazmat.Text = "Drug Lab Type:";
					ViewModel.sprHazmat.FontBold = true;
					ViewModel.sprHazmat.FontSize = 8;
					ViewModel.sprHazmat.Col = 2;
					ViewModel.sprHazmat.FontSize = 7;
					ViewModel.sprHazmat.Text = IncidentMain.Clean(HazmatReport.HazmatDrugLab["drug_lab_desc"]);
					(ViewModel.CurrRow)++;
					ViewModel.sprHazmat.Row = ViewModel.CurrRow;
					ViewModel.sprHazmat.Col = 1;
					ViewModel.sprHazmat.Text = "Material ID Source:";
					ViewModel.sprHazmat.FontBold = true;
					ViewModel.sprHazmat.FontSize = 8;
					ViewModel.sprHazmat.Col = 2;
					ViewModel.sprHazmat.FontSize = 7;
					ViewModel.sprHazmat.Text = IncidentMain.Clean(HazmatReport.HazmatDrugLab["description"]);
					(ViewModel.CurrRow)++;
					ViewModel.sprHazmat.Row = ViewModel.CurrRow;
					ViewModel.sprHazmat.Col = 1;
					ViewModel.sprHazmat.Text = "Disposition of Incident:";
					ViewModel.sprHazmat.FontBold = true;
					ViewModel.sprHazmat.FontSize = 8;
					ViewModel.sprHazmat.Col = 2;
					ViewModel.sprHazmat.FontSize = 7;
					ViewModel.sprHazmat.Text = IncidentMain.Clean(HazmatReport.HazmatDrugLab["disposition_of_release_desc"]);
					if ( HazmatReport.GetHazmatDLActionTakenReport(ViewModel.HazmatDLID) != 0 )
					{
						(ViewModel.CurrRow)++;
						ViewModel.sprHazmat.Row = ViewModel.CurrRow;
						ViewModel.sprHazmat.Col = 1;
						ViewModel.sprHazmat.Text = "Hazmat Actions Taken:";
						ViewModel.sprHazmat.FontBold = true;
						ViewModel.sprHazmat.FontSize = 8;
						ViewModel.sprHazmat.Col = 2;

						while ( !HazmatReport.HazmatDLActionTaken.EOF )
						{
							ViewModel.sprHazmat.Text = IncidentMain.Clean(HazmatReport.HazmatDLActionTaken["hazmatDL_action_taken"]);
							(ViewModel.CurrRow)++;
							ViewModel.sprHazmat.Row = ViewModel.CurrRow;
							HazmatReport.HazmatDLActionTaken.MoveNext();
						}
						;
					}
					if ( HazmatReport.GetHazmatDLOutsideResourceReport(ViewModel.HazmatDLID) != 0 )
					{
						(ViewModel.CurrRow)++;
						ViewModel.sprHazmat.Row = ViewModel.CurrRow;
						ViewModel.sprHazmat.Col = 1;
						ViewModel.sprHazmat.Text = "Outside Resources:";
						ViewModel.sprHazmat.FontBold = true;
						ViewModel.sprHazmat.FontSize = 8;
						ViewModel.sprHazmat.Col = 5;
						ViewModel.sprHazmat.Text = "Resource Use:";
						ViewModel.sprHazmat.FontBold = true;
						ViewModel.sprHazmat.FontSize = 8;
						(ViewModel.CurrRow)++;
						ViewModel.sprHazmat.Row = ViewModel.CurrRow;

						while ( !HazmatReport.HazmatDLOutsideResourceRS.EOF )
						{
							ViewModel.sprHazmat.Col = 1;
							ViewModel.sprHazmat.FontSize = 7;
							ViewModel.sprHazmat.Text = IncidentMain.Clean(HazmatReport.HazmatDLOutsideResourceRS["OutsideResource"]);
							ViewModel.sprHazmat.Col = 5;
							ViewModel.sprHazmat.Text = IncidentMain.Clean(HazmatReport.HazmatDLOutsideResourceRS["ResourceUse"]);
							(ViewModel.CurrRow)++;
							ViewModel.sprHazmat.Row = ViewModel.CurrRow;
							HazmatReport.HazmatDLOutsideResourceRS.MoveNext();
						}
						;
					}
					if ( HazmatReport.GetHazmatFireServiceMaterialsUsed(ViewModel.HazmatDLID) != 0 )
					{
						(ViewModel.CurrRow)++;
						ViewModel.sprHazmat.Row = ViewModel.CurrRow;
						ViewModel.sprHazmat.Col = 1;
						ViewModel.sprHazmat.Text = "Materials Used:";
						ViewModel.sprHazmat.FontBold = true;
						ViewModel.sprHazmat.FontSize = 8;

						while ( !HazmatReport.HazmatFireServiceMaterialsUsedRS.EOF )
						{
							ViewModel.sprHazmat.Col = 2;
							ViewModel.sprHazmat.FontSize = 7;
							ViewModel.sprHazmat.Row = ViewModel.CurrRow;
							sDisplay = IncidentMain.Clean(HazmatReport.HazmatFireServiceMaterialsUsedRS["material_quantity"]);
							sDisplay2 = IncidentMain.Clean(HazmatReport.HazmatFireServiceMaterialsUsedRS["description"]);
							ViewModel.sprHazmat.Text = sDisplay + "  -  " + sDisplay2;
							(ViewModel.CurrRow)++;
							ViewModel.sprHazmat.Row = ViewModel.CurrRow;
							HazmatReport.HazmatFireServiceMaterialsUsedRS.MoveNext();
						}
						;
					}
					(ViewModel.CurrRow)++;
				}
				ViewModel.SaveRow = ViewModel.CurrRow;
			}
			if ( ViewModel.ReportType != IncidentMain.HAZMATDL )
			{
				if ( HazmatReport.GetHazmatReport(ViewModel.HazmatID) != 0 )
				{
					ViewModel.CurrRow = ViewModel.SaveRow;
					(ViewModel.CurrRow)++;
					ViewModel.sprHazmat.Row = ViewModel.CurrRow;
					ViewModel.sprHazmat.Col = 1;
					ViewModel.sprHazmat.Text = "Hazmat Detail Information";
					ViewModel.sprHazmat.FontSize = 10;
					ViewModel.sprHazmat.FontBold = true;
					ViewModel.sprHazmat.FontItalic = true;
					ViewModel.sprHazmat.BlockMode = true;
					ViewModel.sprHazmat.Row2 = ViewModel.CurrRow;
					ViewModel.sprHazmat.Col2 = 10;
					ViewModel.sprHazmat.BackColor = IncidentMain.Shared.LTGRAY;
					ViewModel.sprHazmat.BlockMode = false;
					(ViewModel.CurrRow)++;
					ViewModel.sprHazmat.Row = ViewModel.CurrRow;
					ViewModel.sprHazmat.Text = "Hazmat Type:";
					ViewModel.sprHazmat.FontBold = true;
					ViewModel.sprHazmat.FontSize = 8;
					ViewModel.sprHazmat.Col = 2;
					ViewModel.sprHazmat.FontSize = 7;
					ViewModel.sprHazmat.Text = IncidentMain.Clean(HazmatReport.HazmatRelease["hazmat_type_desc"]);
					ViewModel.sprHazmat.FontBold = false;
					ViewModel.sprHazmat.FontSize = 8;
					ViewModel.sprHazmat.Col = 8;
					ViewModel.sprHazmat.Text = "Names Associated?";
					ViewModel.sprHazmat.FontBold = true;
					if ( IncidentCL.NameListRS(ViewModel.CurrIncident) != 0 )
					{
						ViewModel.sprHazmat.Col = 10;
						ViewModel.sprHazmat.Text = "Yes";
					}
					else
					{
						ViewModel.sprHazmat.Col = 10;
						ViewModel.sprHazmat.Text = "No";
					}
					(ViewModel.CurrRow)++;
					ViewModel.sprHazmat.Row = ViewModel.CurrRow;
					ViewModel.sprHazmat.Col = 1;
					ViewModel.sprHazmat.Text = "Material ID Source:";
					ViewModel.sprHazmat.FontBold = true;
					ViewModel.sprHazmat.FontSize = 8;
					ViewModel.sprHazmat.Col = 2;
					ViewModel.sprHazmat.FontSize = 7;
					ViewModel.sprHazmat.Text = IncidentMain.Clean(HazmatReport.HazmatRelease["hazmat_ID_desc"]);
					(ViewModel.CurrRow)++;
					ViewModel.sprHazmat.Row = ViewModel.CurrRow;
					ViewModel.sprHazmat.Col = 1;
					ViewModel.sprHazmat.Text = "Disposition of Incident:";
					ViewModel.sprHazmat.FontBold = true;
					ViewModel.sprHazmat.FontSize = 8;
					ViewModel.sprHazmat.Col = 2;
					ViewModel.sprHazmat.FontSize = 7;
					ViewModel.sprHazmat.Text = IncidentMain.Clean(HazmatReport.HazmatRelease["disp_of_release_desc"]);
					if ( HazmatReport.GetHazmatActionTakenReport(ViewModel.HazmatID) != 0 )
					{
						(ViewModel.CurrRow)++;
						ViewModel.sprHazmat.Row = ViewModel.CurrRow;
						ViewModel.sprHazmat.Col = 1;
						ViewModel.sprHazmat.Text = "Hazmat Actions Taken:";
						ViewModel.sprHazmat.FontBold = true;
						ViewModel.sprHazmat.FontSize = 8;
						ViewModel.sprHazmat.Row = ViewModel.CurrRow;
						ViewModel.sprHazmat.Col = 2;

						while ( !HazmatReport.HazmatActionTaken.EOF )
						{
							ViewModel.sprHazmat.Text = IncidentMain.Clean(HazmatReport.HazmatActionTaken["hazmat_action_taken"]);
							(ViewModel.CurrRow)++;
							ViewModel.sprHazmat.Row = ViewModel.CurrRow;
							HazmatReport.HazmatActionTaken.MoveNext();
						}
						;
					}
					if ( HazmatReport.GetHazmatOutsideResourceReport(ViewModel.HazmatID) != 0 )
					{
						(ViewModel.CurrRow)++;
						ViewModel.sprHazmat.Row = ViewModel.CurrRow;
						ViewModel.sprHazmat.Col = 1;
						ViewModel.sprHazmat.Text = "Outside Resources:";
						ViewModel.sprHazmat.FontBold = true;
						ViewModel.sprHazmat.FontSize = 8;
						ViewModel.sprHazmat.Col = 5;
						ViewModel.sprHazmat.Text = "Resource Use:";
						ViewModel.sprHazmat.FontBold = true;
						ViewModel.sprHazmat.FontSize = 8;
						(ViewModel.CurrRow)++;
						ViewModel.sprHazmat.Row = ViewModel.CurrRow;

						while ( !HazmatReport.HazmatOutsideResourceRS.EOF )
						{
							ViewModel.sprHazmat.Col = 1;
							ViewModel.sprHazmat.FontSize = 7;
							ViewModel.sprHazmat.Text = IncidentMain.Clean(HazmatReport.HazmatOutsideResourceRS["outside_resource_desc"]);
							ViewModel.sprHazmat.Col = 5;
							ViewModel.sprHazmat.Text = IncidentMain.Clean(HazmatReport.HazmatOutsideResourceRS["resource_use_desc"]);
							(ViewModel.CurrRow)++;
							ViewModel.sprHazmat.Row = ViewModel.CurrRow;
							HazmatReport.HazmatOutsideResourceRS.MoveNext();
						}
						;
					}
					ViewModel.SaveRow = ViewModel.CurrRow;
					(ViewModel.CurrRow)++;
					ViewModel.sprHazmat.Row = ViewModel.CurrRow;
					ViewModel.sprHazmat.Col = 1;
					ViewModel.sprHazmat.Text = "Hazmat Fixed Release Detail Information";
					ViewModel.sprHazmat.FontSize = 10;
					ViewModel.sprHazmat.FontBold = true;
					ViewModel.sprHazmat.FontItalic = true;
					ViewModel.sprHazmat.BlockMode = true;
					ViewModel.sprHazmat.Row2 = ViewModel.CurrRow;
					ViewModel.sprHazmat.Col2 = 10;
					ViewModel.sprHazmat.BackColor = IncidentMain.Shared.LTGRAY;
					ViewModel.sprHazmat.BlockMode = false;
					(ViewModel.CurrRow)++;
					ViewModel.sprHazmat.Row = ViewModel.CurrRow;
					ViewModel.sprHazmat.Col = 1;
					ViewModel.sprHazmat.Text = "Property Use:";
					ViewModel.sprHazmat.FontBold = true;
					ViewModel.sprHazmat.FontSize = 8;
					ViewModel.sprHazmat.Col = 2;
					ViewModel.sprHazmat.FontSize = 7;
					ViewModel.sprHazmat.Text = IncidentMain.Clean(HazmatReport.HazmatRelease["prop_use_desc"]);
					(ViewModel.CurrRow)++;
					ViewModel.sprHazmat.Row = ViewModel.CurrRow;
					ViewModel.sprHazmat.Col = 1;
					ViewModel.sprHazmat.Text = "Area Of Origin:";
					ViewModel.sprHazmat.FontBold = true;
					ViewModel.sprHazmat.FontSize = 8;
					ViewModel.sprHazmat.Col = 2;
					ViewModel.sprHazmat.FontSize = 7;
					ViewModel.sprHazmat.Text = IncidentMain.Clean(HazmatReport.HazmatRelease["area_of_origin_desc"]);
					(ViewModel.CurrRow)++;
					ViewModel.sprHazmat.Row = ViewModel.CurrRow;
					ViewModel.sprHazmat.Col = 1;
					ViewModel.sprHazmat.Text = "Cause Of Release:";
					ViewModel.sprHazmat.FontBold = true;
					ViewModel.sprHazmat.FontSize = 8;
					ViewModel.sprHazmat.Col = 2;
					ViewModel.sprHazmat.FontSize = 7;
					ViewModel.sprHazmat.Text = IncidentMain.Clean(HazmatReport.HazmatRelease["release_desc"]);
					(ViewModel.CurrRow)++;
					ViewModel.sprHazmat.Row = ViewModel.CurrRow;
					ViewModel.sprHazmat.Col = 1;
					ViewModel.sprHazmat.Text = "Release Floor:";
					ViewModel.sprHazmat.FontBold = true;
					ViewModel.sprHazmat.FontSize = 8;
					ViewModel.sprHazmat.Col = 2;
					ViewModel.sprHazmat.FontSize = 7;
					ViewModel.sprHazmat.Text = IncidentMain.Clean(HazmatReport.HazmatRelease["release_floor"]);
					(ViewModel.CurrRow)++;
					ViewModel.sprHazmat.Row = ViewModel.CurrRow;
					ViewModel.sprHazmat.Col = 1;
					ViewModel.sprHazmat.Text = "Occurred First:";
					ViewModel.sprHazmat.FontBold = true;
					ViewModel.sprHazmat.FontSize = 8;
					ViewModel.sprHazmat.Col = 2;
					ViewModel.sprHazmat.FontSize = 7;

					if ( IncidentMain.Clean(HazmatReport.HazmatRelease["occurred_first_desc"]) == "" )
					{
						ViewModel.sprHazmat.Col = 2;
						ViewModel.sprHazmat.FontSize = 7;
						ViewModel.sprHazmat.Text = "Undetermined";
					}
					else
					{
						ViewModel.sprHazmat.Col = 2;
						ViewModel.sprHazmat.FontSize = 7;
						ViewModel.sprHazmat.Text = IncidentMain.Clean(HazmatReport.HazmatRelease["occurred_first_desc"]);
					}
					(ViewModel.CurrRow)++;
					ViewModel.sprHazmat.Row = ViewModel.CurrRow;
					ViewModel.sprHazmat.Col = 1;
					ViewModel.sprHazmat.Text = "Area Affected:";
					ViewModel.sprHazmat.FontBold = true;
					ViewModel.sprHazmat.FontSize = 8;
					ViewModel.sprHazmat.Col = 2;
					ViewModel.sprHazmat.FontSize = 7;
					ViewModel.sprHazmat.Text = IncidentMain.Clean(HazmatReport.HazmatRelease["area_effected"]);
					ViewModel.sprHazmat.Col = 3;
					ViewModel.sprHazmat.Text = IncidentMain.Clean(HazmatReport.HazmatRelease["area_affected_desc"]);
					(ViewModel.CurrRow)++;
					ViewModel.sprHazmat.Row = ViewModel.CurrRow;
					ViewModel.sprHazmat.Col = 1;
					ViewModel.sprHazmat.Text = "Area Evacuated:";
					ViewModel.sprHazmat.FontBold = true;
					ViewModel.sprHazmat.FontSize = 7;
					ViewModel.sprHazmat.Col = 2;
					ViewModel.sprHazmat.FontSize = 7;
					ViewModel.sprHazmat.Text = IncidentMain.Clean(HazmatReport.HazmatRelease["area_evacuated"]);
					if ( ViewModel.sprHazmat.Text == "0" )
					{
						ViewModel.sprHazmat.Text = "None";
					}
					ViewModel.sprHazmat.Col = 3;
					ViewModel.sprHazmat.Text = IncidentMain.Clean(HazmatReport.HazmatRelease["area_evacuated_desc"]);
					(ViewModel.CurrRow)++;
					ViewModel.sprHazmat.Row = ViewModel.CurrRow;
					ViewModel.sprHazmat.Col = 1;
					ViewModel.sprHazmat.Text = "Population Density:";
					ViewModel.sprHazmat.FontBold = true;
					ViewModel.sprHazmat.FontSize = 8;
					ViewModel.sprHazmat.Col = 2;
					ViewModel.sprHazmat.FontSize = 7;
					ViewModel.sprHazmat.Text = IncidentMain.Clean(HazmatReport.HazmatRelease["pop_density_desc"]);
					(ViewModel.CurrRow)++;
					ViewModel.sprHazmat.Row = ViewModel.CurrRow;
					ViewModel.sprHazmat.Col = 1;
					ViewModel.sprHazmat.Text = "People Evacuated:";
					ViewModel.sprHazmat.FontBold = true;
					ViewModel.sprHazmat.FontSize = 8;
					ViewModel.sprHazmat.Col = 2;
					ViewModel.sprHazmat.FontSize = 7;
					ViewModel.sprHazmat.Text = IncidentMain.Clean(HazmatReport.HazmatRelease["people_evacuated"]);
					if ( ViewModel.sprHazmat.Text == "0" )
					{
						ViewModel.sprHazmat.Text = "None";
					}
					(ViewModel.CurrRow)++;
					ViewModel.sprHazmat.Row = ViewModel.CurrRow;
					ViewModel.sprHazmat.Col = 1;
					ViewModel.sprHazmat.Text = "Buildings Evacuated:";
					ViewModel.sprHazmat.FontBold = true;
					ViewModel.sprHazmat.FontSize = 8;
					ViewModel.sprHazmat.Col = 2;
					ViewModel.sprHazmat.FontSize = 7;
					ViewModel.sprHazmat.Text = IncidentMain.Clean(HazmatReport.HazmatRelease["buildings_evacuated"]);
					ViewModel.LastRow = ViewModel.CurrRow;
					//saverow = 13
					ViewModel.CurrRow += 2;
					ViewModel.sprHazmat.Row = ViewModel.CurrRow;
					if ( HazmatReport.GetHazmatContribFactorReport(ViewModel.HazmatID) != 0 )
					{
						ViewModel.CurrRow = ViewModel.SaveRow;
						ViewModel.CurrRow += 2;
						ViewModel.sprHazmat.Row = ViewModel.CurrRow;
						ViewModel.sprHazmat.Col = 7;
						ViewModel.sprHazmat.Text = "Contributing Factors:";
						ViewModel.sprHazmat.FontBold = true;
						ViewModel.sprHazmat.FontSize = 8;

						while ( !HazmatReport.HazmatContributingFactorRS.EOF )
						{
							(ViewModel.CurrRow)++;
							ViewModel.sprHazmat.Row = ViewModel.CurrRow;
							ViewModel.sprHazmat.FontSize = 7;
							ViewModel.sprHazmat.Row = ViewModel.CurrRow;
							ViewModel.sprHazmat.Text = IncidentMain.Clean(HazmatReport.HazmatContributingFactorRS["hazmat_contrib_factor"]);
							//
							HazmatReport.HazmatContributingFactorRS.MoveNext();
						}
						;
					}
					if ( HazmatReport.GetHazmatMitigatingFactorReport(ViewModel.HazmatID) != 0 )
					{
						ViewModel.CurrRow += 2;
						ViewModel.sprHazmat.Row = ViewModel.CurrRow;
						ViewModel.sprHazmat.Col = 7;
						ViewModel.sprHazmat.Text = "Mitigating Factors:";
						ViewModel.sprHazmat.FontBold = true;
						ViewModel.sprHazmat.FontSize = 8;
						(ViewModel.CurrRow)++;
						ViewModel.sprHazmat.Row = ViewModel.CurrRow;

						while ( !HazmatReport.HazmatMitigatingFactorRS.EOF )
						{
							ViewModel.sprHazmat.FontSize = 7;
							ViewModel.sprHazmat.Row = ViewModel.CurrRow;
							ViewModel.sprHazmat.Text = IncidentMain.Clean(HazmatReport.HazmatMitigatingFactorRS["mitigating_factor"]);
							(ViewModel.CurrRow)++;
							HazmatReport.HazmatMitigatingFactorRS.MoveNext();
						}
						;
					}
					if ( HazmatReport.GetHazmatEquipInvolvedReport(ViewModel.HazmatID) != 0 )
					{
						(ViewModel.CurrRow)++;
						ViewModel.sprHazmat.Row = ViewModel.CurrRow;
						ViewModel.sprHazmat.Col = 7;
						ViewModel.sprHazmat.Text = "Equipment Involved in Ignition:";
						ViewModel.sprHazmat.FontBold = true;
						ViewModel.sprHazmat.FontSize = 8;
						(ViewModel.CurrRow)++;
						ViewModel.sprHazmat.Row = ViewModel.CurrRow;

						while ( !HazmatReport.HazmatEquipmentInvolvedRS.EOF )
						{
							ViewModel.sprHazmat.FontSize = 7;
							ViewModel.sprHazmat.Row = ViewModel.CurrRow;
							ViewModel.sprHazmat.Text = IncidentMain.Clean(HazmatReport.HazmatEquipmentInvolvedRS["equipment_desc"]);
							(ViewModel.CurrRow)++;
							HazmatReport.HazmatEquipmentInvolvedRS.MoveNext();
						}
						;
					}
					if ( ViewModel.LastRow > ViewModel.CurrRow )
					{
						ViewModel.CurrRow = ViewModel.LastRow;
					}
					ViewModel.SaveRow = ViewModel.CurrRow;
					if ( HazmatReport.GetHazmatChemicalDetailReport(ViewModel.HazmatID) != 0 )
					{
						(ViewModel.CurrRow)++;
						ViewModel.sprHazmat.Row = ViewModel.CurrRow;
						ViewModel.sprHazmat.Col = 1;
						ViewModel.sprHazmat.Text = "Chemical Information";
						ViewModel.sprHazmat.FontSize = 10;
						ViewModel.sprHazmat.FontBold = true;
						ViewModel.sprHazmat.FontItalic = true;
						ViewModel.sprHazmat.BlockMode = true;
						ViewModel.sprHazmat.Row2 = ViewModel.CurrRow;
						ViewModel.sprHazmat.Col2 = 10;
						ViewModel.sprHazmat.BackColor = IncidentMain.Shared.LTGRAY;
						ViewModel.sprHazmat.BlockMode = false;
						(ViewModel.CurrRow)++;
						ViewModel.sprHazmat.Row = ViewModel.CurrRow;

						while ( !HazmatReport.HazmatChemicalDetail.EOF )
						{
							ViewModel.sprHazmat.Col = 1;
							ViewModel.sprHazmat.Text = "Chemical:";
							ViewModel.sprHazmat.FontBold = true;
							ViewModel.sprHazmat.FontSize = 8;
							ViewModel.sprHazmat.Col = 2;
							ViewModel.sprHazmat.FontSize = 7;
							ViewModel.sprHazmat.Text = IncidentMain.Clean(HazmatReport.HazmatChemicalDetail["chemical_name"]);
							ViewModel.sprHazmat.Col = 5;
							ViewModel.sprHazmat.Text = "UN#:";
							ViewModel.sprHazmat.FontBold = true;
							ViewModel.sprHazmat.FontSize = 8;
							ViewModel.sprHazmat.Col = 6;
							ViewModel.sprHazmat.Text = IncidentMain.Clean(HazmatReport.HazmatChemicalDetail["unno"]);
							(ViewModel.CurrRow)++;
							ViewModel.sprHazmat.Row = ViewModel.CurrRow;
							ViewModel.sprHazmat.Col = 1;
							ViewModel.sprHazmat.Text = "Container Size/Type:";
							ViewModel.sprHazmat.FontBold = true;
							ViewModel.sprHazmat.FontSize = 8;
							ViewModel.sprHazmat.Col = 2;
							ViewModel.sprHazmat.FontSize = 7;
							sDisplay = IncidentMain.Clean(HazmatReport.HazmatChemicalDetail["container_capacity"]);
							sDisplay2 = IncidentMain.Clean(HazmatReport.HazmatChemicalDetail["capacity_units_desc"]);
							ViewModel.sprHazmat.Col = 2;
							ViewModel.sprHazmat.FontSize = 7;
							ViewModel.sprHazmat.Text = sDisplay + " " + sDisplay2;
							ViewModel.sprHazmat.Col = 4;
							ViewModel.sprHazmat.Text = IncidentMain.Clean(HazmatReport.HazmatChemicalDetail["container_type"]);
							(ViewModel.CurrRow)++;
							ViewModel.sprHazmat.Row = ViewModel.CurrRow;
							ViewModel.sprHazmat.Col = 1;
							ViewModel.sprHazmat.Text = "Amt. Released:";
							ViewModel.sprHazmat.FontBold = true;
							ViewModel.sprHazmat.FontSize = 8;
							ViewModel.sprHazmat.Col = 2;
							ViewModel.sprHazmat.FontSize = 7;
							sDisplay = IncidentMain.Clean(HazmatReport.HazmatChemicalDetail["amount_released"]);
							sDisplay2 = IncidentMain.Clean(HazmatReport.HazmatChemicalDetail["amount_released_units_desc"]);
							ViewModel.sprHazmat.Col = 2;
							ViewModel.sprHazmat.FontSize = 7;
							ViewModel.sprHazmat.Text = sDisplay + " " + sDisplay2;
							(ViewModel.CurrRow)++;
							ViewModel.sprHazmat.Row = ViewModel.CurrRow;
							ViewModel.sprHazmat.Col = 1;
							ViewModel.sprHazmat.Text = "State Stored:";
							ViewModel.sprHazmat.FontBold = true;
							ViewModel.sprHazmat.FontSize = 8;
							ViewModel.sprHazmat.Col = 2;
							ViewModel.sprHazmat.FontSize = 7;
							ViewModel.sprHazmat.Text = IncidentMain.Clean(HazmatReport.HazmatChemicalDetail["state_stored"]);
							(ViewModel.CurrRow)++;
							ViewModel.sprHazmat.Row = ViewModel.CurrRow;
							ViewModel.sprHazmat.Col = 1;
							ViewModel.sprHazmat.Text = "State Released:";
							ViewModel.sprHazmat.FontBold = true;
							ViewModel.sprHazmat.FontSize = 8;
							ViewModel.sprHazmat.Col = 2;
							ViewModel.sprHazmat.FontSize = 7;
							ViewModel.sprHazmat.Text = IncidentMain.Clean(HazmatReport.HazmatChemicalDetail["state_released"]);
							(ViewModel.CurrRow)--;
							ViewModel.sprHazmat.Row = ViewModel.CurrRow;
							ViewModel.sprHazmat.Col = 5;
							ViewModel.sprHazmat.Text = "Primary Release:";
							ViewModel.sprHazmat.FontBold = true;
							ViewModel.sprHazmat.FontSize = 8;
							ViewModel.sprHazmat.Col = 7;
							ViewModel.sprHazmat.FontSize = 7;
							ViewModel.sprHazmat.Text = IncidentMain.Clean(HazmatReport.HazmatChemicalDetail["primary_released_into"]);
							(ViewModel.CurrRow)++;
							ViewModel.sprHazmat.Row = ViewModel.CurrRow;
							ViewModel.sprHazmat.Col = 5;
							ViewModel.sprHazmat.Text = "Secondary Release:";
							ViewModel.sprHazmat.FontBold = true;
							ViewModel.sprHazmat.FontSize = 8;
							ViewModel.sprHazmat.Col = 7;
							ViewModel.sprHazmat.FontSize = 7;
							ViewModel.sprHazmat.Text = IncidentMain.Clean(HazmatReport.HazmatChemicalDetail["secondary_released_into"]);
							(ViewModel.CurrRow)++;
							ViewModel.sprHazmat.Row = ViewModel.CurrRow;
							HazmatReport.HazmatChemicalDetail.MoveNext();
							(ViewModel.CurrRow)++;
							ViewModel.sprHazmat.Row = ViewModel.CurrRow;
						}
						;
					}
				}
			}
			//  **** HAZMAT Narration *****
			// start back at top of section
			ViewModel.PageCountRow = ViewModel.CurrRow;
			int cellheight = 0;
			if ( IncidentCL.NarrationListRS(ViewModel.CurrIncident, ViewModel.ReportType) != 0 )
			{

				while ( !IncidentCL.IncidentNarration.EOF )
				{
					IncidentCL.GetNarration(Convert.ToInt32(IncidentCL.IncidentNarration["narration_id"]));
					if ( ViewModel.PageCountRow > 56 )
					{
						DisplayHeadings();
					}
					(ViewModel.CurrRow)++;
					(ViewModel.PageCountRow)++;
					ViewModel.sprHazmat.Row = ViewModel.CurrRow;
					ViewModel.sprHazmat.Col = 1;
					ViewModel.sprHazmat.Text = "Hazmat Narration";
					ViewModel.sprHazmat.FontBold = true;
					ViewModel.sprHazmat.FontItalic = true;
					ViewModel.sprHazmat.FontSize = 10;
					ViewModel.sprHazmat.BlockMode = true;
					ViewModel.sprHazmat.Row2 = ViewModel.CurrRow;
					ViewModel.sprHazmat.Col2 = 10;
					ViewModel.sprHazmat.BackColor = IncidentMain.Shared.LTGRAY;
					ViewModel.sprHazmat.BlockMode = false;
					(ViewModel.CurrRow)++;
					(ViewModel.PageCountRow)++;
					ViewModel.sprHazmat.Row = ViewModel.CurrRow;
					ViewModel.sprHazmat.Col = 1;
					ViewModel.sprHazmat.Text = "Narration By:";
					ViewModel.sprHazmat.FontBold = true;
					ViewModel.sprHazmat.FontSize = 8;
					ViewModel.sprHazmat.Col = 2;
					ViewModel.sprHazmat.FontSize = 7;
					ViewModel.sprHazmat.Text = IncidentCL.NarrationBy;
					(ViewModel.CurrRow)++;
					(ViewModel.PageCountRow)++;
					ViewModel.sprHazmat.Row = ViewModel.CurrRow;
					ViewModel.sprHazmat.Col = 1;
					ViewModel.sprHazmat.Text = "Last Update Date:";
					ViewModel.sprHazmat.FontBold = true;
					ViewModel.sprHazmat.FontSize = 8;
					ViewModel.sprHazmat.Col = 2;
					ViewModel.sprHazmat.FontSize = 7;
					ViewModel.sprHazmat.Text = DateTime.Parse(IncidentCL.NarrationLastUpdate).ToString("M/d/yyyy");
					(ViewModel.CurrRow)++;
					(ViewModel.PageCountRow)++;
					ViewModel.sprHazmat.Row = ViewModel.CurrRow;
					ViewModel.sprHazmat.Col = 1;
					ViewModel.sprHazmat.Text = "Narration:";
					ViewModel.sprHazmat.FontBold = true;
					ViewModel.sprHazmat.FontSize = 8;
					ViewModel.sprHazmat.Col = 2;
					ViewModel.sprHazmat.FontSize = 7;
					(ViewModel.CurrRow)++;
					(ViewModel.PageCountRow)++;
					ViewModel.sprHazmat.Row = ViewModel.CurrRow;
					sDisplay = IncidentCL.NarrationText;
					sDisplay = sDisplay.Substring(0, Math.Min(Strings.Len(sDisplay) - 1, sDisplay.Length));
					ViewModel.LastRow = Strings.Len(sDisplay) / 100;
					//Count line breaks to make sure cell span will be big enough
					x = 1;
					for ( int i = 1; i <= Strings.Len(sDisplay); i++ )
					{
						if ( Strings.Asc(sDisplay.Substring(i - 1, Math.Min(1, sDisplay.Length - (i - 1)))[0]) == 13 )
						{
							x++;
							i++;
						}
						else if ( Strings.Asc(sDisplay.Substring(i - 1, Math.Min(1, sDisplay.Length - (i - 1)))[0]) == 10 )
						{
							x++;
						}
					}
					if ( x > ViewModel.LastRow )
					{
						ViewModel.LastRow = x;
					}
					ViewModel.sprHazmat.BlockMode = true;
					ViewModel.sprHazmat.Row = ViewModel.CurrRow;
					ViewModel.sprHazmat.Row2 = ViewModel.CurrRow + ViewModel.LastRow;
					ViewModel.sprHazmat.Col = 2;
					ViewModel.sprHazmat.Col2 = 9;
					ViewModel.sprHazmat.CellType = FarPoint.ViewModels.Cells.FpCellType.CellTypeStaticText;
					(ViewModel.sprHazmat.ActiveSheet.Cells[ViewModel.sprHazmat.Row, ViewModel.sprHazmat.Col].CellType as FarPoint.ViewModels.TextCellType).WordWrap = true;
					ViewModel.sprHazmat.BlockMode = false;
					//UPGRADE_ISSUE: (2064) FPSpread.vaSpread method sprHazmat.AddCellSpan was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprHazmat.AddCellSpan(2, ViewModel.CurrRow, 8, ViewModel.LastRow);
					ViewModel.sprHazmat.Row = ViewModel.CurrRow;
					ViewModel.sprHazmat.Col = 2;
					ViewModel.sprHazmat.Text = sDisplay;
					//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprHazmat.MaxTextCellHeight was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					cellheight = Convert.ToInt32(ViewModel.sprHazmat.getMaxTextCellHeight());
					// Set the height of the selected row to the value of the MaxTextCellHeight property
					ViewModel.sprHazmat.SetRowHeight(ViewModel.CurrRow, cellheight);
					ViewModel.CurrRow = ViewModel.CurrRow + ViewModel.LastRow + 1;
					ViewModel.sprHazmat.Row = ViewModel.CurrRow;

					IncidentCL.IncidentNarration.MoveNext();
				};
				}
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
			this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.Arrow);

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprHazmat.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprHazmat.setPrintAbortMsg("Printing Hazmat Report - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprHazmat.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprHazmat.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprHazmat.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprHazmat.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpread.PrintOrientationConstants property PrintOrientationConstants.PrintOrientationPortrait was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprHazmat.PrintOrientation was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprHazmat.setPrintOrientation(UpgradeStubs.FPSpread_PrintOrientationConstants.getPrintOrientationPortrait());
			ViewModel.sprHazmat.Action = FarPoint.ViewModels.FPActionConstants.ActionSmartPrint;
		}

		private void DisplayHeadings()
		{
			(ViewModel.CurrRow)++;
			ViewModel.sprHazmat.Row = ViewModel.CurrRow;
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprHazmat.RowPageBreak was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprHazmat.setRowPageBreak(true);
			(ViewModel.CurrRow)++;
			ViewModel.sprHazmat.Row = ViewModel.CurrRow;
			ViewModel.sprHazmat.Col = 7;
			ViewModel.sprHazmat.FontSize = 8;
			ViewModel.sprHazmat.FontBold = true;
			ViewModel.sprHazmat.Text = "Print Date:";
			ViewModel.sprHazmat.Col = 9;
			ViewModel.sprHazmat.FontSize = 8;
			ViewModel.sprHazmat.FontBold = false;
			ViewModel.sprHazmat.Text = UpgradeHelpers.Helpers.StringsHelper.Format(DateTime.Now, "m/d/yyyy h:nn AM/PM");
			(ViewModel.CurrRow)++;
			ViewModel.sprHazmat.Row = ViewModel.CurrRow;
			ViewModel.sprHazmat.Col = 7;
			ViewModel.sprHazmat.FontSize = 8;
			ViewModel.sprHazmat.FontBold = true;
			ViewModel.sprHazmat.Text = "Incident Number:";
			ViewModel.sprHazmat.Col = 9;
			ViewModel.sprHazmat.FontSize = 8;
			ViewModel.sprHazmat.FontBold = false;
			ViewModel.sprHazmat.Text = ViewModel.IncidentNumber;
			(ViewModel.CurrRow)++;
			ViewModel.sprHazmat.Row = ViewModel.CurrRow;
			ViewModel.sprHazmat.Col = 1;
			ViewModel.sprHazmat.Text = "Hazmat Narration";
			ViewModel.sprHazmat.FontSize = 10;
			ViewModel.sprHazmat.FontBold = true;
			ViewModel.sprHazmat.FontItalic = true;
			ViewModel.sprHazmat.BlockMode = true;
			ViewModel.sprHazmat.Row2 = ViewModel.CurrRow;
			ViewModel.sprHazmat.Col2 = 10;
			ViewModel.sprHazmat.BackColor = IncidentMain.Shared.LTGRAY;
			ViewModel.sprHazmat.BlockMode = false;
			(ViewModel.CurrRow)++;
			ViewModel.sprHazmat.Row = ViewModel.CurrRow;
			ViewModel.sprHazmat.Col = 1;
			ViewModel.sprHazmat.Text = "Narration Continued:";
			ViewModel.sprHazmat.FontBold = true;
			ViewModel.sprHazmat.FontSize = 8;
			ViewModel.sprHazmat.Col = 2;
			ViewModel.sprHazmat.FontSize = 7;
			(ViewModel.CurrRow)++;
			ViewModel.PageCountRow = 4;
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			//Produce Hazmat Report Print Preview
			//Using global gPrintReportID parameter
			//************************
			//** Database Connections for testing
			//************************
			//    oIncident.Open "Provider=SQLOLEDB; Data Source=TFDSQL3; Initial Catalog=Incident; Integrated Security=SSPI"
			//    oPTSdata.Open "Provider=SQLOLEDB; Data Source=TFDSQL3; Initial Catalog=PTSdata; Integrated Security=SSPI"
			TFDIncident.clsReportLog ReportLog = Container.Resolve<clsReportLog>();
			TFDIncident.clsHazmat HazmatCL = Container.Resolve<clsHazmat>();

			//**********************************************
			//** Hardcoded report id's for testing
			//****************************
			//Hazmat Release
			//ReportLog.GetReportLog 82925

			//Hazmat Release w/Contributing Factors
			//    ReportLog.GetReportLog 90709

			//Drug Lab w/Release
			// ReportLog.GetReportLog 47951

			//Drug Labs - okay
			//   not okay? ReportLog.GetReportLog 73695
			//ReportLog.GetReportLog 24630

			// ReportLog.GetReportLog gEditReportID

			ReportLog.GetReportLog(IncidentMain.Shared.gEditReportID);
			ViewModel.ReportType = ReportLog.ReportType;
			ViewModel.CurrIncident = ReportLog.RLIncidentID;

			if ( ViewModel.ReportType == IncidentMain.HAZMATDL )
			{
				ViewModel.HazmatDLID = ReportLog.ReportReferenceID;
			}
			else if ( ViewModel.ReportType == IncidentMain.HAZMATDLRELEASE )
			{
				ViewModel.HazmatID = ReportLog.ReportReferenceID;
				HazmatCL.GetIncidentDrugLab(ViewModel.CurrIncident);
				ViewModel.HazmatDLID = HazmatCL.DLHazmatID;
			}
			else
			{
				ViewModel.HazmatID = ReportLog.ReportReferenceID;
			}

			LoadHazmatReport();

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmReportHazmat DefInstance
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

		public static frmReportHazmat CreateInstance()
		{
			TFDIncident.frmReportHazmat theInstance = Shared.Container.Resolve<frmReportHazmat>();
			theInstance.Form_Load();
			return theInstance;
		}

		protected override void ExecuteControlsStartup()
		{
			ViewModel.sprHazmat.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprHazmat.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmReportHazmat
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.frmReportHazmatViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmReportHazmat m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}