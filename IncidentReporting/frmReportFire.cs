using Microsoft.VisualBasic;
using System;
using UpgradeHelpers.DB.ADO;
using UpgradeStubs;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident
{

	public partial class frmReportFire
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.frmReportFireViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmReportFire));
			if ( Shared.m_vb6FormDefInstance == null )
			{
				if ( Shared.m_InitializingDefInstance )
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
		}


		private void frmReportFire_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender )
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>)eventSender;
			}
		}



		private void LoadFireReport()
		{
			//Format Fire Report
			TFDIncident.clsFire FireReport = Container.Resolve<clsFire>();
			TFDIncident.clsFireCodes FireCodes = Container.Resolve<clsFireCodes>();
			TFDIncident.clsIncident IncidentCL = Container.Resolve<clsIncident>();
			TFDIncident.clsUnit UnitCL = Container.Resolve<clsUnit>();
			int x = 0;
			string CurrUnit = "";
			string sDisplay = "", FireAddress = "";
			ViewModel.sprFireReport.Row = 1;
			ViewModel.sprFireReport.Col = 8;
			ViewModel.sprFireReport.Text = UpgradeHelpers.Helpers.StringsHelper.Format(DateTime.Now, "m/d/yyyy h:nn AM/PM");
			if ( ViewModel.ReportType == IncidentMain.FIREOUTSIDE )
			{
				if ( ~FireReport.GetFireOutside(ViewModel.FireReportID) != 0 )
				{
					ViewManager.ShowMessage("Error retrieving Fire Report", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					return ;
				}
				else
				{
					ViewModel.FireReportID = FireReport.FireOutsideID;
				}
			}
			else
			{
				if ( ~FireReport.GetFireReport(ViewModel.FireReportID) != 0 )
				{
					ViewManager.ShowMessage("Error retrieving Fire Report", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					return ;
				}
				else
				{
					ViewModel.FireReportID = FireReport.FireReportID;
				}
			}
			ViewModel.CurrRow = 5;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
			this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.WaitCursor);
			// ****** Incident Information *****
			if ( IncidentCL.GetIncident(ViewModel.CurrIncident) != 0 )
			{
				if ( ViewModel.PageCountRow > 56 )
				{
					DisplayHeadings();
				}
				else
				{
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					ViewModel.sprFireReport.Col = 2;
					ViewModel.sprFireReport.Text = IncidentCL.IncidentNumber;
					ViewModel.IncidentNumber = IncidentCL.IncidentNumber;
					(ViewModel.CurrRow)++;
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					ViewModel.sprFireReport.Col = 2;
					ViewModel.sprFireReport.Text = DateTime.Parse(IncidentCL.DateIncidentCreated).ToString("M/d/yyyy   HH:mm");
					(ViewModel.CurrRow)++;
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					ViewModel.sprFireReport.Col = 2;
					ViewModel.sprFireReport.Text = IncidentCL.Location;
					ViewModel.CurrRow = 5;
					//Unit Times
					if ( UnitCL.GetUnitResponseTimesReport(ViewModel.CurrIncident) != 0 )
					{

						while ( !UnitCL.UnitTimes.EOF )
						{
							if ( Convert.ToString(UnitCL.UnitTimes["Unit"]) != CurrUnit )
							{
								(ViewModel.CurrRow)++;
								ViewModel.sprFireReport.Row = ViewModel.CurrRow;
								CurrUnit = Convert.ToString(UnitCL.UnitTimes["Unit"]);
								ViewModel.sprFireReport.Col = 5;
								ViewModel.sprFireReport.Text = IncidentMain.Clean(UnitCL.UnitTimes["unit_name"]);
							}
							switch ( Convert.ToInt32(UnitCL.UnitTimes["response_time_code"]) )
							{
								case 3: //Dispatched 

									ViewModel.sprFireReport.Col = 7;
									ViewModel.sprFireReport.Text = Convert.ToDateTime(UnitCL.UnitTimes["unit_time"]).ToString("HH:mm");
									break;
								case 5: //onscene 

									ViewModel.sprFireReport.Col = 8;
									ViewModel.sprFireReport.Text = Convert.ToDateTime(UnitCL.UnitTimes["unit_time"]).ToString("HH:mm");
									break;
								case 8: //available 

									ViewModel.sprFireReport.Col = 9;
									ViewModel.sprFireReport.Text = Convert.ToDateTime(UnitCL.UnitTimes["unit_time"]).ToString("HH:mm");
									break;
							}
							UnitCL.UnitTimes.MoveNext();
						};
						}
					}
				}
			ViewModel.SaveRow = ViewModel.CurrRow;
			// ****** Fire Outside Detail Information *****
			//CurrRow = 10
			ViewModel.sprFireReport.Col = 1;
			switch ( ViewModel.ReportType )
			{
				case IncidentMain.FIREOUTSIDE:
					ViewModel.CurrRow += 2;
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					ViewModel.sprFireReport.Text = "Outside Fire Detail Information";
					ViewModel.sprFireReport.FontSize = 10;
					ViewModel.sprFireReport.FontBold = true;
					ViewModel.sprFireReport.FontItalic = true;
					ViewModel.sprFireReport.BlockMode = true;
					ViewModel.sprFireReport.Row2 = ViewModel.CurrRow;
					ViewModel.sprFireReport.Col2 = 10;
					ViewModel.sprFireReport.BackColor = IncidentMain.Shared.LTGRAY;
					ViewModel.sprFireReport.BlockMode = false;
					(ViewModel.CurrRow)++;
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					ViewModel.sprFireReport.Text = "Fire Type:";
					ViewModel.sprFireReport.FontBold = true;
					ViewModel.sprFireReport.FontSize = 8;
					ViewModel.sprFireReport.Col = 2;
					FireReport.GetFireOutsideReport(ViewModel.FireReportID);
					ViewModel.sprFireReport.FontSize = 7;
					ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FIREOUTSIDE["fire_type_desc"]);
					ViewModel.sprFireReport.FontBold = false;
					ViewModel.sprFireReport.FontSize = 8;
					ViewModel.sprFireReport.Col = 5;
					ViewModel.sprFireReport.Text = "Names Associated?";
					ViewModel.sprFireReport.FontBold = true;
					if ( IncidentCL.NameListRS(ViewModel.CurrIncident) != 0 )
					{
						ViewModel.sprFireReport.Col = 7;
						ViewModel.sprFireReport.Text = "Yes";
					}
					else
					{
						ViewModel.sprFireReport.Col = 7;
						ViewModel.sprFireReport.Text = "No";
					}
					(ViewModel.CurrRow)++;
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					ViewModel.sprFireReport.Col = 1;
					ViewModel.sprFireReport.Text = "Heat Source:";
					ViewModel.sprFireReport.FontBold = true;
					ViewModel.sprFireReport.FontSize = 8;
					ViewModel.sprFireReport.Col = 2;
					ViewModel.sprFireReport.FontSize = 7;
					ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FIREOUTSIDE["heat_source_code_desc"]);
					(ViewModel.CurrRow)++;
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					ViewModel.sprFireReport.Col = 1;
					ViewModel.sprFireReport.Text = "General Cause Of Fire:";
					ViewModel.sprFireReport.FontBold = true;
					ViewModel.sprFireReport.FontSize = 8;
					ViewModel.sprFireReport.Col = 2;
					ViewModel.sprFireReport.FontSize = 7;
					ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FIREOUTSIDE["gen_cause_desc"]);
					(ViewModel.CurrRow)++;
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					ViewModel.sprFireReport.Col = 1;
					ViewModel.sprFireReport.Text = "Specific Cause of Fire";
					ViewModel.sprFireReport.FontBold = true;
					ViewModel.sprFireReport.FontSize = 8;
					ViewModel.sprFireReport.Col = 2;
					ViewModel.sprFireReport.FontSize = 7;
					ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FIREOUTSIDE["spec_cause_desc"]);
					(ViewModel.CurrRow)++;
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					ViewModel.sprFireReport.Col = 1;
					ViewModel.sprFireReport.Text = "Content Loss:";
					ViewModel.sprFireReport.FontBold = true;
					ViewModel.sprFireReport.FontSize = 8;
					ViewModel.sprFireReport.Col = 2;
					ViewModel.sprFireReport.FontSize = 7;
					ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FIREOUTSIDE["content_loss"]);
					(ViewModel.CurrRow)++;
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					ViewModel.sprFireReport.Col = 1;
					ViewModel.sprFireReport.Text = "Area Affected:";
					ViewModel.sprFireReport.FontBold = true;
					ViewModel.sprFireReport.FontSize = 8;
					ViewModel.sprFireReport.Col = 2;
					ViewModel.sprFireReport.FontSize = 7;
					ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FIREOUTSIDE["area_affected"]);
					ViewModel.sprFireReport.Col = 3;
					ViewModel.sprFireReport.FontSize = 7;
					ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FIREOUTSIDE["area_unit"]);
					(ViewModel.CurrRow)++;
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					ViewModel.sprFireReport.Col = 1;
					ViewModel.sprFireReport.Text = "Material Type:";
					ViewModel.sprFireReport.FontBold = true;
					ViewModel.sprFireReport.FontSize = 8;
					ViewModel.sprFireReport.Col = 2;
					ViewModel.sprFireReport.FontSize = 7;
					ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FIREOUTSIDE["material_type"]);
					ViewModel.SaveRow = ViewModel.CurrRow;
					break;
				default:
					FireReport.GetFireBasicReport(ViewModel.FireReportID);
					ViewModel.CurrRow = ViewModel.SaveRow;
					ViewModel.CurrRow += 2;
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					ViewModel.sprFireReport.Col = 1;
					ViewModel.sprFireReport.Text = "Fire Detail Information";
					ViewModel.sprFireReport.FontSize = 10;
					ViewModel.sprFireReport.FontBold = true;
					ViewModel.sprFireReport.FontItalic = true;
					ViewModel.sprFireReport.BlockMode = true;
					ViewModel.sprFireReport.Row2 = ViewModel.CurrRow;
					ViewModel.sprFireReport.Col2 = 10;
					ViewModel.sprFireReport.BackColor = IncidentMain.Shared.LTGRAY;
					ViewModel.sprFireReport.BlockMode = false;
					(ViewModel.CurrRow)++;
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					ViewModel.sprFireReport.Text = "Fire Type:";
					ViewModel.sprFireReport.FontBold = true;
					ViewModel.sprFireReport.FontSize = 8;
					ViewModel.sprFireReport.Col = 2;
					ViewModel.sprFireReport.FontSize = 7;
					ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FireReport["fire_type_desc"]);
					ViewModel.sprFireReport.FontSize = 8;
					ViewModel.sprFireReport.Col = 5;
					ViewModel.sprFireReport.FontBold = true;
					ViewModel.sprFireReport.Text = "Names Associated?";
					if ( IncidentCL.NameListRS(ViewModel.CurrIncident) != 0 )
					{
						ViewModel.sprFireReport.Col = 7;
						ViewModel.sprFireReport.Text = "Yes";
					}
					else
					{
						ViewModel.sprFireReport.Col = 7;
						ViewModel.sprFireReport.Text = "No";
					}
					(ViewModel.CurrRow)++;
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					ViewModel.sprFireReport.Col = 1;
					ViewModel.sprFireReport.Text = "General Property Use:";
					ViewModel.sprFireReport.FontBold = true;
					ViewModel.sprFireReport.FontSize = 8;
					ViewModel.sprFireReport.Col = 2;
					ViewModel.sprFireReport.FontSize = 7;
					ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FireReport["gen_prop_use_desc"]);
					(ViewModel.CurrRow)++;
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					ViewModel.sprFireReport.Col = 1;
					ViewModel.sprFireReport.Text = "Specific Property Use:";
					ViewModel.sprFireReport.FontBold = true;
					ViewModel.sprFireReport.FontSize = 8;
					ViewModel.sprFireReport.Col = 2;
					ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FireReport["prop_use_desc"]);
					(ViewModel.CurrRow)++;
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					ViewModel.sprFireReport.Col = 1;
					ViewModel.sprFireReport.Text = "Area of Origin:";
					ViewModel.sprFireReport.FontBold = true;
					ViewModel.sprFireReport.FontSize = 8;
					ViewModel.sprFireReport.Col = 2;
					ViewModel.sprFireReport.FontSize = 7;
					ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FireReport["area_of_origin_desc"]);
					(ViewModel.CurrRow)++;
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					ViewModel.sprFireReport.Col = 1;
					ViewModel.sprFireReport.Text = "Heat Source:";
					ViewModel.sprFireReport.FontBold = true;
					ViewModel.sprFireReport.FontSize = 8;
					ViewModel.sprFireReport.Col = 2;
					ViewModel.sprFireReport.FontSize = 7;
					ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FireReport["heat_source_code_desc"]);
					(ViewModel.CurrRow)++;
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					ViewModel.sprFireReport.Col = 1;
					ViewModel.sprFireReport.Text = "First Item Ignited:";
					ViewModel.sprFireReport.FontBold = true;
					ViewModel.sprFireReport.FontSize = 8;
					ViewModel.sprFireReport.Col = 2;
					ViewModel.sprFireReport.FontSize = 7;
					ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FireReport["first_item_ign_desc"]);
					ViewModel.sprFireReport.Col = 1;
					(ViewModel.CurrRow)++;
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					ViewModel.sprFireReport.Text = "Gen. Cause of Ignition:";
					ViewModel.sprFireReport.FontBold = true;
					ViewModel.sprFireReport.FontSize = 8;
					ViewModel.sprFireReport.Col = 2;
					ViewModel.sprFireReport.FontSize = 7;
					ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FireReport["gen_cause_desc"]);
					(ViewModel.CurrRow)++;
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					ViewModel.sprFireReport.Col = 1;
					ViewModel.sprFireReport.Text = "Spec. Cause of Ignition:";
					ViewModel.sprFireReport.FontBold = true;
					ViewModel.sprFireReport.FontSize = 8;
					ViewModel.sprFireReport.Col = 2;
					ViewModel.sprFireReport.FontSize = 7;
					ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FireReport["spec_cause_desc"]);
					(ViewModel.CurrRow)++;
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					ViewModel.sprFireReport.Col = 1;
					ViewModel.sprFireReport.Text = "Property Value:";
					ViewModel.sprFireReport.FontBold = true;
					ViewModel.sprFireReport.FontSize = 8;
					ViewModel.sprFireReport.Col = 2;
					ViewModel.sprFireReport.FontSize = 7;
					ViewModel.sprFireReport.Text = UpgradeHelpers.Helpers.StringsHelper.Format(FireReport.FireReport["property_value"], "$#,###");
					(ViewModel.CurrRow)++;
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					ViewModel.sprFireReport.Col = 1;
					ViewModel.sprFireReport.Text = "Property Loss:";
					ViewModel.sprFireReport.FontBold = true;
					ViewModel.sprFireReport.FontSize = 8;
					ViewModel.sprFireReport.Col = 2;
					ViewModel.sprFireReport.FontSize = 7;
					ViewModel.sprFireReport.Text = UpgradeHelpers.Helpers.StringsHelper.Format(FireReport.FireReport["property_loss"], "$#,###");
					(ViewModel.CurrRow)++;
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					ViewModel.sprFireReport.Col = 1;
					ViewModel.sprFireReport.Text = "Content Loss:";
					ViewModel.sprFireReport.FontBold = true;
					ViewModel.sprFireReport.FontSize = 8;
					ViewModel.sprFireReport.Col = 2;
					ViewModel.sprFireReport.FontSize = 7;
					ViewModel.sprFireReport.Text = UpgradeHelpers.Helpers.StringsHelper.Format(FireReport.FireReport["content_loss"], "$#,###");
					ViewModel.SaveRow = ViewModel.CurrRow;
					string auxVar = "";
					if ( FireReport.GetFireStructureReport(ViewModel.FireReportID) != 0 )
					{
						//Check for Exposure
						if ( Convert.ToBoolean(FireReport.FIRESTRUCTURE["flag_exposure"]) )
						{
							ViewModel.sprFireReport.Row = 8;
							ViewModel.sprFireReport.Col = 1;
							ViewModel.sprFireReport.Text = "-- Exposure Fire --";
							ViewModel.ExportExposureFlag = -1;
							//check for exposure address
							if ( FireReport.GetFireExposureAddress(ViewModel.FireReportID) != 0 )
							{
								FireAddress = IncidentMain.Clean(FireReport.ExpHouseNumber);
								if ( IncidentMain.Clean(FireReport.ExpPrefix) != "" )
								{
									FireAddress = FireAddress + " " + IncidentMain.Clean(FireReport.ExpPrefix);
								}
								if ( IncidentMain.Clean(FireReport.ExpStreet) != "" )
								{
									FireAddress = FireAddress + " " + IncidentMain.Clean(FireReport.ExpStreet);
								}
								if ( IncidentMain.Clean(FireReport.ExpStreetType) != "" )
								{
									FireAddress = FireAddress + " " + IncidentMain.Clean(FireReport.ExpStreetType);
								}
								if ( IncidentMain.Clean(FireReport.ExpSuffix) != "" )
								{
									FireAddress = FireAddress + " " + IncidentMain.Clean(FireReport.ExpSuffix);
								}
								if ( IncidentMain.Clean(FireReport.ExpCityCode) != "" )
								{
									FireAddress = FireAddress + ", " + IncidentMain.Clean(FireReport.ExpCityCode);
								}
								ViewModel.sprFireReport.Row = 9;
								ViewModel.sprFireReport.Col = 1;
								ViewModel.sprFireReport.Text = FireAddress;

							}
						}
						(ViewModel.CurrRow)++;
						ViewModel.sprFireReport.Row = ViewModel.CurrRow;
						ViewModel.sprFireReport.Col = 1;
						ViewModel.sprFireReport.Text = "Structure Fire Information";
						ViewModel.sprFireReport.FontSize = 10;
						ViewModel.sprFireReport.FontBold = true;
						ViewModel.sprFireReport.FontItalic = true;
						ViewModel.sprFireReport.BlockMode = true;
						ViewModel.sprFireReport.Row2 = ViewModel.CurrRow;
						ViewModel.sprFireReport.Col2 = 10;
						ViewModel.sprFireReport.BackColor = IncidentMain.Shared.LTGRAY;
						ViewModel.sprFireReport.BlockMode = false;
						(ViewModel.CurrRow)++;
						ViewModel.sprFireReport.Row = ViewModel.CurrRow;
						ViewModel.sprFireReport.Col = 1;
						ViewModel.sprFireReport.Text = "Bldg. Status:";
						ViewModel.sprFireReport.FontBold = true;
						ViewModel.sprFireReport.FontSize = 8;
						ViewModel.sprFireReport.Col = 2;
						ViewModel.sprFireReport.FontSize = 7;
						ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FIRESTRUCTURE["building_status"]);
						ViewModel.sprFireReport.Col = 6;
						ViewModel.sprFireReport.Text = "Floor of Origin:";
						ViewModel.sprFireReport.FontBold = true;
						ViewModel.sprFireReport.FontSize = 8;
						ViewModel.sprFireReport.Col = 8;
						ViewModel.sprFireReport.FontSize = 7;
						//UPGRADE_WARNING: (1068) GetVal(FireReport.FIRESTRUCTURE(floor_of_origin)) of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						if ( Convert.ToString(IncidentMain.GetVal(FireReport.FIRESTRUCTURE["floor_of_origin"])) == "-1" )
						{
							sDisplay = "Bsmt";
						}
						else if ( Convert.ToString(IncidentMain.GetVal(FireReport.FIRESTRUCTURE["floor_of_origin"])) == "99" )
						{
							sDisplay = "Attic";
						}
						else if ( Convert.ToString(IncidentMain.GetVal(FireReport.FIRESTRUCTURE["floor_of_origin"])) == "100" )
						{
							sDisplay = "Roof";
						}
						else
						{
							//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
							sDisplay = Convert.ToString(IncidentMain.GetVal(FireReport.FIRESTRUCTURE["floor_of_origin"]));
						//                    If Clean(FireReport.FIRESTRUCTURE("sp_floor"]) <> "Normal Floor" Then
						//                        sDisplay = sDisplay & " - " & Clean(FireReport.FIRESTRUCTURE("sp_floor"])
						//                    End If
						}

						ViewModel.sprFireReport.Text = sDisplay;
						(ViewModel.CurrRow)++;
						ViewModel.sprFireReport.Row = ViewModel.CurrRow;
						ViewModel.sprFireReport.Col = 1;
						ViewModel.sprFireReport.Text = "Const. Type:";
						ViewModel.sprFireReport.FontBold = true;
						ViewModel.sprFireReport.FontSize = 8;
						ViewModel.sprFireReport.Col = 2;
						ViewModel.sprFireReport.FontSize = 7;
						ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FIRESTRUCTURE["construction_type"]);
						ViewModel.sprFireReport.Col = 6;
						ViewModel.sprFireReport.Text = "No. of Stories:";
						ViewModel.sprFireReport.FontBold = true;
						ViewModel.sprFireReport.FontSize = 8;
						ViewModel.sprFireReport.Col = 8;
						ViewModel.sprFireReport.FontSize = 7;
						ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FIRESTRUCTURE["number_of_stories"]);
						(ViewModel.CurrRow)++;
						ViewModel.sprFireReport.Row = ViewModel.CurrRow;
						ViewModel.sprFireReport.Col = 1;
						ViewModel.sprFireReport.Text = "Burn Damage:";
						ViewModel.sprFireReport.FontBold = true;
						ViewModel.sprFireReport.FontSize = 8;
						ViewModel.sprFireReport.Col = 2;
						ViewModel.sprFireReport.FontSize = 7;
						ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FIRESTRUCTURE["burn_damage"]);
						ViewModel.sprFireReport.Col = 6;
						ViewModel.sprFireReport.Text = "Basement Levels:";
						ViewModel.sprFireReport.FontBold = true;
						ViewModel.sprFireReport.FontSize = 8;
						ViewModel.sprFireReport.Col = 8;
						ViewModel.sprFireReport.FontSize = 7;
						(
//                sprFireReport.Text = Clean(FireReport.FIRESTRUCTURE("basement_levels"])
ViewModel.CurrRow)++;
						ViewModel.sprFireReport.Row = ViewModel.CurrRow;
						ViewModel.sprFireReport.Col = 1;
						ViewModel.sprFireReport.Text = "SQ FT Burn Damage:";
						ViewModel.sprFireReport.FontBold = true;
						ViewModel.sprFireReport.FontSize = 8;
						ViewModel.sprFireReport.Col = 2;
						ViewModel.sprFireReport.FontSize = 7;
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprFireReport.Text = Convert.ToString(IncidentMain.GetVal(FireReport.FIRESTRUCTURE["sq_foot_burned"]));
						ViewModel.SaveRow = ViewModel.CurrRow;
						ViewModel.sprFireReport.Col = 6;
						ViewModel.sprFireReport.Text = "Total Sq. Ft.:";
						ViewModel.sprFireReport.FontBold = true;
						ViewModel.sprFireReport.FontSize = 8;
						ViewModel.sprFireReport.Col = 8;
						ViewModel.sprFireReport.FontSize = 7;
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprFireReport.Text = Convert.ToString(IncidentMain.GetVal(FireReport.FIRESTRUCTURE["total_sq_footage"]));
						(ViewModel.CurrRow)++;
						ViewModel.sprFireReport.Row = ViewModel.CurrRow;
						ViewModel.sprFireReport.Col = 1;
						ViewModel.sprFireReport.Text = "Smoke Damage:";
						ViewModel.sprFireReport.FontBold = true;
						ViewModel.sprFireReport.FontSize = 8;
						ViewModel.sprFireReport.Col = 2;
						ViewModel.sprFireReport.FontSize = 7;
						ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FIRESTRUCTURE["smoke_damage"]);
						ViewModel.sprFireReport.Col = 6;
						ViewModel.sprFireReport.Text = "Rental:";
						ViewModel.sprFireReport.FontBold = true;
						ViewModel.sprFireReport.FontSize = 8;
						ViewModel.sprFireReport.Col = 8;
						ViewModel.sprFireReport.FontSize = 7;
						bool tempBool = false;
						auxVar = IncidentMain.Clean(FireReport.FIRESTRUCTURE["flag_rental"]);
						if ( (Boolean.TryParse(auxVar, out tempBool)) ? tempBool : Convert.ToBoolean(Double.Parse(auxVar)) )
						{
							ViewModel.sprFireReport.Text = "Yes";
						}
						else
						{
							ViewModel.sprFireReport.Text = "No";
						}
						(ViewModel.CurrRow)++;
						ViewModel.sprFireReport.Row = ViewModel.CurrRow;
						ViewModel.sprFireReport.Col = 1;
						ViewModel.sprFireReport.Text = "SQ FT Smoke Damage:";
						ViewModel.sprFireReport.FontBold = true;
						ViewModel.sprFireReport.FontSize = 8;
						ViewModel.sprFireReport.Col = 2;
						ViewModel.sprFireReport.FontSize = 7;
						ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FIRESTRUCTURE["sq_foot_smoke_damaged"]);
						ViewModel.sprFireReport.Col = 6;
						ViewModel.sprFireReport.Text = "No. of Units:";
						ViewModel.sprFireReport.FontBold = true;
						ViewModel.sprFireReport.FontSize = 8;
						ViewModel.sprFireReport.Col = 8;
						ViewModel.sprFireReport.FontSize = 7;
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprFireReport.Text = Convert.ToString(IncidentMain.GetVal(FireReport.FIRESTRUCTURE["number_units"]));
						(ViewModel.CurrRow)++;
						ViewModel.sprFireReport.Row = ViewModel.CurrRow;
						ViewModel.SaveRow = ViewModel.CurrRow;
						ViewModel.sprFireReport.Col = 6;
						ViewModel.sprFireReport.Text = "No. of Occupants:";
						ViewModel.sprFireReport.FontBold = true;
						ViewModel.sprFireReport.FontSize = 8;
						ViewModel.sprFireReport.Col = 8;
						ViewModel.sprFireReport.FontSize = 7;
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprFireReport.Text = Convert.ToString(IncidentMain.GetVal(FireReport.FIRESTRUCTURE["number_of_people_occuping"]));
						(ViewModel.CurrRow)++;
						ViewModel.sprFireReport.Row = ViewModel.CurrRow;
						ViewModel.sprFireReport.Col = 6;
						ViewModel.sprFireReport.Text = "No. of People Displaced:";
						ViewModel.sprFireReport.FontBold = true;
						ViewModel.sprFireReport.FontSize = 8;
						ViewModel.sprFireReport.Col = 8;
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprFireReport.Text = Convert.ToString(IncidentMain.GetVal(FireReport.FIRESTRUCTURE["number_people_displaced"]));
						(ViewModel.CurrRow)++;
						ViewModel.sprFireReport.Row = ViewModel.CurrRow;
						ViewModel.sprFireReport.Col = 6;
						ViewModel.sprFireReport.Text = "No. of Businesses:";
						ViewModel.sprFireReport.FontBold = true;
						ViewModel.sprFireReport.FontSize = 8;
						ViewModel.sprFireReport.Col = 8;
						ViewModel.sprFireReport.FontSize = 7;
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprFireReport.Text = Convert.ToString(IncidentMain.GetVal(FireReport.FIRESTRUCTURE["number_of_business_occuping"]));
						(ViewModel.CurrRow)++;
						ViewModel.sprFireReport.Row = ViewModel.CurrRow;
						ViewModel.sprFireReport.Col = 6;
						ViewModel.sprFireReport.Text = "No. Businesses Displaced:";
						ViewModel.sprFireReport.FontBold = true;
						ViewModel.sprFireReport.FontSize = 8;
						ViewModel.sprFireReport.Col = 8;
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprFireReport.Text = Convert.ToString(IncidentMain.GetVal(FireReport.FIRESTRUCTURE["number_business_displaced"]));
						(ViewModel.CurrRow)++;
						ViewModel.sprFireReport.Row = ViewModel.CurrRow;
						ViewModel.sprFireReport.Col = 6;
						ViewModel.sprFireReport.Text = "No. Jobs Lost:";
						ViewModel.sprFireReport.FontBold = true;
						ViewModel.sprFireReport.FontSize = 8;
						ViewModel.sprFireReport.Col = 8;
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprFireReport.Text = Convert.ToString(IncidentMain.GetVal(FireReport.FIRESTRUCTURE["number_jobs_lost"]));
						(ViewModel.CurrRow)++;
						ViewModel.sprFireReport.Row = ViewModel.CurrRow;
						if ( FireReport.FlagNoAlarm == UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe("0") )
						{
							(ViewModel.CurrRow)++;
							ViewModel.sprFireReport.Row = ViewModel.CurrRow;
							ViewModel.sprFireReport.Col = 6;
							ViewModel.sprFireReport.Text = "Alarm Type:";
							ViewModel.sprFireReport.FontBold = true;
							ViewModel.sprFireReport.FontSize = 8;
							ViewModel.sprFireReport.Col = 7;
							ViewModel.sprFireReport.FontSize = 7;
							ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FIRESTRUCTURE["alarm_type"]);
							(ViewModel.CurrRow)++;
							ViewModel.sprFireReport.Row = ViewModel.CurrRow;
							ViewModel.sprFireReport.Col = 6;
							ViewModel.sprFireReport.Text = "Detector Power:";
							ViewModel.sprFireReport.FontBold = true;
							ViewModel.sprFireReport.FontSize = 8;
							ViewModel.sprFireReport.Col = 7;
							ViewModel.sprFireReport.FontSize = 7;
							ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FIRESTRUCTURE["power_desc"]);
							(ViewModel.CurrRow)++;
							ViewModel.sprFireReport.Row = ViewModel.CurrRow;
							ViewModel.sprFireReport.Col = 6;
							ViewModel.sprFireReport.Text = "Effectiveness:";
							ViewModel.sprFireReport.FontBold = true;
							ViewModel.sprFireReport.FontSize = 8;
							ViewModel.sprFireReport.Col = 7;
							ViewModel.sprFireReport.FontSize = 7;
							ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FIRESTRUCTURE["alarm_effectiveness"]);
							(ViewModel.CurrRow)++;
							ViewModel.sprFireReport.Row = ViewModel.CurrRow;
							ViewModel.sprFireReport.Col = 6;
							ViewModel.sprFireReport.Text = "Initiating Device:";
							ViewModel.sprFireReport.FontBold = true;
							ViewModel.sprFireReport.FontSize = 8;
							ViewModel.sprFireReport.Col = 7;
							ViewModel.sprFireReport.FontSize = 7;
							ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FIRESTRUCTURE["initiating_device"]);
							(ViewModel.CurrRow)++;
							ViewModel.sprFireReport.Row = ViewModel.CurrRow;
							if ( FireReport.GetFireSystemsFailureReport(ViewModel.FireReportID, "A") != 0 )
							{
								//CurrRow = CurrRow + 1
								ViewModel.sprFireReport.Col = ViewModel.CurrRow;
								ViewModel.sprFireReport.Col = 6;
								ViewModel.sprFireReport.Text = "Alarm Problem:";
								ViewModel.sprFireReport.FontBold = true;
								ViewModel.sprFireReport.FontSize = 8;
								(ViewModel.CurrRow)++;

								while ( !FireReport.FireSystemsFailure.EOF )
								{
									ViewModel.sprFireReport.Col = 6;
									ViewModel.sprFireReport.FontSize = 7;
									ViewModel.sprFireReport.Row = ViewModel.CurrRow;
									ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FireSystemsFailure["system_problem"]);
									(ViewModel.CurrRow)++;
									FireReport.FireSystemsFailure.MoveNext();
								}
								;
							}
						}
						if ( FireReport.FlagNoExtinguishSystem == UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe("0") )
						{
							(ViewModel.CurrRow)++;
							ViewModel.sprFireReport.Row = ViewModel.CurrRow;
							ViewModel.sprFireReport.Col = 6;
							ViewModel.sprFireReport.Text = "System Type:";
							ViewModel.sprFireReport.FontBold = true;
							ViewModel.sprFireReport.FontSize = 8;
							ViewModel.sprFireReport.Col = 7;
							ViewModel.sprFireReport.FontSize = 7;
							ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FIRESTRUCTURE["extinguisher_type"]);
							(ViewModel.CurrRow)++;
							ViewModel.sprFireReport.Row = ViewModel.CurrRow;
							ViewModel.sprFireReport.Col = 6;
							ViewModel.sprFireReport.Text = "Effectiveness:";
							ViewModel.sprFireReport.FontBold = true;
							ViewModel.sprFireReport.FontSize = 8;
							ViewModel.sprFireReport.Col = 7;
							ViewModel.sprFireReport.FontSize = 7;
							ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FIRESTRUCTURE["system_effectiveness"]);
							if ( FireReport.GetFireSystemsFailureReport(ViewModel.FireReportID, "E") != 0 )
							{
								(ViewModel.CurrRow)++;
								ViewModel.sprFireReport.Row = ViewModel.CurrRow;
								ViewModel.sprFireReport.Col = 6;
								ViewModel.sprFireReport.Text = "System Problem:";
								ViewModel.sprFireReport.FontBold = true;
								ViewModel.sprFireReport.FontSize = 8;
								(ViewModel.CurrRow)++;

								while ( !FireReport.FireSystemsFailure.EOF )
								{
									ViewModel.sprFireReport.Row = ViewModel.CurrRow;
									ViewModel.sprFireReport.Col = 6;
									ViewModel.sprFireReport.FontSize = 7;
									ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FireSystemsFailure["system_problem"]);
									(ViewModel.CurrRow)++;
									FireReport.FireSystemsFailure.MoveNext();
								}
								;
							}

						}
						ViewModel.LastRow = ViewModel.CurrRow;
						ViewModel.CurrRow = ViewModel.SaveRow;
						(ViewModel.CurrRow)++;
						ViewModel.sprFireReport.Row = ViewModel.CurrRow;
						ViewModel.sprFireReport.Col = 1;
						if ( FireReport.GetSuppressionFactorReport(ViewModel.FireReportID) != 0 )
						{
							(ViewModel.CurrRow)++;
							ViewModel.sprFireReport.Row = ViewModel.CurrRow;
							ViewModel.sprFireReport.Col = 1;
							ViewModel.sprFireReport.Text = "Fire Suppression Factors:";
							ViewModel.sprFireReport.FontBold = true;
							ViewModel.sprFireReport.FontSize = 8;
							(ViewModel.CurrRow)++;
							ViewModel.sprFireReport.Row = ViewModel.CurrRow;

							while ( !FireReport.FireSuppressionFactor.EOF )
							{
								ViewModel.sprFireReport.FontSize = 7;
								ViewModel.sprFireReport.Row = ViewModel.CurrRow;
								ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FireSuppressionFactor["suppression_factor"]);
								(ViewModel.CurrRow)++;
								FireReport.FireSuppressionFactor.MoveNext();
							}
							;
						}
						if ( FireReport.GetItemContribFireSpreadReport(ViewModel.FireReportID) != 0 )
						{
							(ViewModel.CurrRow)++;
							ViewModel.sprFireReport.Row = ViewModel.CurrRow;
							ViewModel.sprFireReport.Col = 1;
							ViewModel.sprFireReport.Text = "Items Contributing to Fire Spread:";
							ViewModel.sprFireReport.FontBold = true;
							ViewModel.sprFireReport.FontSize = 8;
							(ViewModel.CurrRow)++;
							ViewModel.sprFireReport.Row = ViewModel.CurrRow;

							while ( !FireReport.ItemContributingFireSpread.EOF )
							{
								ViewModel.sprFireReport.FontSize = 7;
								ViewModel.sprFireReport.Row = ViewModel.CurrRow;
								ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.ItemContributingFireSpread["item_contrib_fire_spread"]);
								(ViewModel.CurrRow)++;
								FireReport.ItemContributingFireSpread.MoveNext();
							}
							;
						}
						if ( FireReport.GetFireEquipmentInvolvedReport(ViewModel.FireReportID) != 0 )
						{
							(ViewModel.CurrRow)++;
							ViewModel.sprFireReport.Row = ViewModel.CurrRow;
							ViewModel.sprFireReport.Col = 1;
							ViewModel.sprFireReport.Text = "Equipment Involved in Ignition:";
							ViewModel.sprFireReport.FontBold = true;
							ViewModel.sprFireReport.FontSize = 8;
							(ViewModel.CurrRow)++;
							ViewModel.sprFireReport.Row = ViewModel.CurrRow;

							while ( !FireReport.FireEquipmentInvolved.EOF )
							{
								ViewModel.sprFireReport.FontSize = 7;
								ViewModel.sprFireReport.Row = ViewModel.CurrRow;
								ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FireEquipmentInvolved["equipment_desc"]);
								(ViewModel.CurrRow)++;
								FireReport.FireEquipmentInvolved.MoveNext();
							}
							;
						}
						if ( FireReport.GetPhysicalContributingFactorReport(ViewModel.FireReportID) != 0 )
						{
							(ViewModel.CurrRow)++;
							ViewModel.sprFireReport.Row = ViewModel.CurrRow;
							ViewModel.sprFireReport.Col = 1;
							ViewModel.sprFireReport.Text = "Physical Contributing Factors:";
							ViewModel.sprFireReport.FontBold = true;
							ViewModel.sprFireReport.FontSize = 8;
							(ViewModel.CurrRow)++;
							ViewModel.sprFireReport.Row = ViewModel.CurrRow;

							while ( !FireReport.PhysicalContributingFactor.EOF )
							{
								ViewModel.sprFireReport.FontSize = 7;
								ViewModel.sprFireReport.Row = ViewModel.CurrRow;
								ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.PhysicalContributingFactor["physical_contrib_factor"]);
								(ViewModel.CurrRow)++;
								FireReport.PhysicalContributingFactor.MoveNext();
							}
							;
						}
						if ( FireReport.GetHumanContributingFactorReport(ViewModel.FireReportID) != 0 )
						{
							(ViewModel.CurrRow)++;
							ViewModel.sprFireReport.Row = ViewModel.CurrRow;
							ViewModel.sprFireReport.Col = 1;
							ViewModel.sprFireReport.Text = "Human Contributing Factors:";
							ViewModel.sprFireReport.FontBold = true;
							ViewModel.sprFireReport.FontSize = 8;
							(ViewModel.CurrRow)++;
							ViewModel.sprFireReport.Row = ViewModel.CurrRow;
							(
//                    If GetVal(FireReport.HumanContributingFactor("hf_age"]) <> 0 Then
//                        sprFireReport.Col = 2
//                        sprFireReport.Text = "Age: " & GetVal(FireReport.HumanContributingFactor("hf_age"])
//                        sprFireReport.Col = 3
//                        If GetVal(FireReport.HumanContributingFactor("hf_gender"]) = 1 Then
//                            sprFireReport.Text = "Gender: Male"
//                        ElseIf GetVal(FireReport.HumanContributingFactor("hf_gender"]) = 2 Then
//                            sprFireReport.Text = "Gender:Female"
//                        End If
//                    End If
ViewModel.CurrRow)++;
							ViewModel.sprFireReport.Row = ViewModel.CurrRow;
							ViewModel.sprFireReport.Col = 1;

							while ( !FireReport.HumanContributingFactor.EOF )
							{
								ViewModel.sprFireReport.FontSize = 7;
								ViewModel.sprFireReport.Row = ViewModel.CurrRow;
								ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.HumanContributingFactor["human_contrib_factor"]);
								(ViewModel.CurrRow)++;
								FireReport.HumanContributingFactor.MoveNext();
							}
							;
						}

						if ( ViewModel.LastRow > ViewModel.CurrRow )
						{
							ViewModel.CurrRow = ViewModel.LastRow;
						}
					//  PageCountRow = CurrRow
					}
					else
					{
						if ( FireReport.GetFireMobilePropertyReport(ViewModel.FireReportID) != 0 )
						{
							ViewModel.CurrRow = ViewModel.SaveRow;
							(ViewModel.CurrRow)++;
							ViewModel.sprFireReport.Row = ViewModel.CurrRow;
							ViewModel.sprFireReport.Col = 1;
							ViewModel.sprFireReport.Text = "Mobile Fire Information";
							ViewModel.sprFireReport.FontSize = 10;
							ViewModel.sprFireReport.FontBold = true;
							ViewModel.sprFireReport.FontItalic = true;
							ViewModel.sprFireReport.BlockMode = true;
							ViewModel.sprFireReport.Row2 = ViewModel.CurrRow;
							ViewModel.sprFireReport.Col2 = 10;
							ViewModel.sprFireReport.BackColor = IncidentMain.Shared.LTGRAY;
							ViewModel.sprFireReport.BlockMode = false;
							(ViewModel.CurrRow)++;
							ViewModel.sprFireReport.Row = ViewModel.CurrRow;
							ViewModel.sprFireReport.Col = 1;
							if ( Convert.ToString(FireReport.FireReport["prop_use_desc"]) == "Water Vessels" )
							{
								ViewModel.sprFireReport.Text = "Vessel Length (ft.)";
								ViewModel.sprFireReport.FontBold = true;
								ViewModel.sprFireReport.FontSize = 8;
								ViewModel.sprFireReport.Col = 2;
								ViewModel.sprFireReport.FontSize = 7;
								ViewModel.sprFireReport.Text = FireReport.WaterVesselLength.ToString();
								(ViewModel.CurrRow)++;
							}
							else
							{
								ViewModel.sprFireReport.Text = "Vehicle Make:";
								ViewModel.sprFireReport.FontBold = true;
								ViewModel.sprFireReport.FontSize = 8;
								ViewModel.sprFireReport.Col = 2;
								ViewModel.sprFireReport.FontSize = 7;
								if ( Convert.ToString(FireReport.FireMobileProperty["vehicle_make"]) != "" )
								{
									ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FireMobileProperty["description"]) + ": " + IncidentMain.Clean(FireReport.FireMobileProperty["vehicle_make"]);
								}
								else
								{
									ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FireMobileProperty["description"]);
								}
								(ViewModel.CurrRow)++;
								ViewModel.sprFireReport.Row = ViewModel.CurrRow;
								ViewModel.sprFireReport.Col = 1;
								ViewModel.sprFireReport.Text = "Vehicle Model:";
								ViewModel.sprFireReport.FontBold = true;
								ViewModel.sprFireReport.FontSize = 8;
								ViewModel.sprFireReport.Col = 2;
								ViewModel.sprFireReport.FontSize = 7;
								ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FireMobileProperty["vehicle_model"]);
								(ViewModel.CurrRow)++;
								ViewModel.sprFireReport.Row = ViewModel.CurrRow;
								ViewModel.sprFireReport.Col = 1;
								ViewModel.sprFireReport.Text = "Vehicle Year:";
								ViewModel.sprFireReport.FontBold = true;
								ViewModel.sprFireReport.FontSize = 8;
								ViewModel.sprFireReport.Col = 2;
								ViewModel.sprFireReport.FontSize = 7;
								ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FireMobileProperty["vehicle_year"]);
								(ViewModel.CurrRow)++;
								ViewModel.sprFireReport.Row = ViewModel.CurrRow;
								ViewModel.sprFireReport.Col = 1;
								ViewModel.sprFireReport.Text = "Vehicle Vin#:";
								ViewModel.sprFireReport.FontBold = true;
								ViewModel.sprFireReport.FontSize = 8;
								ViewModel.sprFireReport.Col = 2;
								ViewModel.sprFireReport.FontSize = 7;
								ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FireMobileProperty["vehicle_vin"]);
								(ViewModel.CurrRow)++;
								ViewModel.sprFireReport.Row = ViewModel.CurrRow;
								ViewModel.sprFireReport.Col = 1;
								ViewModel.sprFireReport.Text = "Vehicle License State:";
								ViewModel.sprFireReport.FontBold = true;
								ViewModel.sprFireReport.FontSize = 8;
								ViewModel.sprFireReport.Col = 2;
								ViewModel.sprFireReport.FontSize = 7;
								ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FireMobileProperty["license_state"]);
							}
							if ( FireReport.GetSuppressionFactorReport(ViewModel.FireReportID) != 0 )
							{
								(ViewModel.CurrRow)++;
								ViewModel.sprFireReport.Row = ViewModel.CurrRow;
								ViewModel.sprFireReport.Col = 1;
								ViewModel.sprFireReport.Text = "Fire Suppression Factors:";
								ViewModel.sprFireReport.FontBold = true;
								ViewModel.sprFireReport.FontSize = 8;
								(ViewModel.CurrRow)++;
								ViewModel.sprFireReport.Row = ViewModel.CurrRow;

								while ( !FireReport.FireSuppressionFactor.EOF )
								{
									ViewModel.sprFireReport.FontSize = 7;
									ViewModel.sprFireReport.Row = ViewModel.CurrRow;
									ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.FireSuppressionFactor["suppression_factor"]);
									(ViewModel.CurrRow)++;
									FireReport.FireSuppressionFactor.MoveNext();
								}
								;
							}
							if ( FireReport.GetPhysicalContributingFactorReport(ViewModel.FireReportID) != 0 )
							{
								(ViewModel.CurrRow)++;
								ViewModel.sprFireReport.Row = ViewModel.CurrRow;
								ViewModel.sprFireReport.Col = 1;
								ViewModel.sprFireReport.Text = "Physical Contributing Factors:";
								ViewModel.sprFireReport.FontBold = true;
								ViewModel.sprFireReport.FontSize = 8;
								(ViewModel.CurrRow)++;
								ViewModel.sprFireReport.Row = ViewModel.CurrRow;

								while ( !FireReport.PhysicalContributingFactor.EOF )
								{
									ViewModel.sprFireReport.FontSize = 7;
									ViewModel.sprFireReport.Row = ViewModel.CurrRow;
									ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.PhysicalContributingFactor["physical_contrib_factor"]);
									(ViewModel.CurrRow)++;
									FireReport.PhysicalContributingFactor.MoveNext();
								}
								;
							}
							if ( FireReport.GetHumanContributingFactorReport(ViewModel.FireReportID) != 0 )
							{
								(ViewModel.CurrRow)++;
								ViewModel.sprFireReport.Row = ViewModel.CurrRow;
								ViewModel.sprFireReport.Col = 1;
								ViewModel.sprFireReport.Text = "Human Contributing Factors:";
								ViewModel.sprFireReport.FontBold = true;
								ViewModel.sprFireReport.FontSize = 8;
								(ViewModel.CurrRow)++;
								ViewModel.sprFireReport.Row = ViewModel.CurrRow;

								while ( !FireReport.HumanContributingFactor.EOF )
								{
									ViewModel.sprFireReport.FontSize = 7;
									ViewModel.sprFireReport.Row = ViewModel.CurrRow;
									ViewModel.sprFireReport.Text = IncidentMain.Clean(FireReport.HumanContributingFactor["human_contrib_factor"]);
									(ViewModel.CurrRow)++;
									FireReport.HumanContributingFactor.MoveNext();
								}
								;
							}
						}
					}
					break;
			}

			//  **** FIRE Narration *****
			ViewModel.PageCountRow = ViewModel.CurrRow - 56;
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
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					ViewModel.sprFireReport.Col = 1;
					ViewModel.sprFireReport.Text = "Fire Narration";
					ViewModel.sprFireReport.FontBold = true;
					ViewModel.sprFireReport.FontItalic = true;
					ViewModel.sprFireReport.FontSize = 10;
					ViewModel.sprFireReport.BlockMode = true;
					ViewModel.sprFireReport.Row2 = ViewModel.CurrRow;
					ViewModel.sprFireReport.Col2 = 10;
					ViewModel.sprFireReport.BackColor = IncidentMain.Shared.LTGRAY;
					ViewModel.sprFireReport.BlockMode = false;
					(ViewModel.CurrRow)++;
					(ViewModel.PageCountRow)++;
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					ViewModel.sprFireReport.Col = 1;
					ViewModel.sprFireReport.Text = "Narration By:";
					ViewModel.sprFireReport.FontBold = true;
					ViewModel.sprFireReport.FontSize = 8;
					ViewModel.sprFireReport.Col = 2;
					ViewModel.sprFireReport.FontSize = 7;
					ViewModel.sprFireReport.Text = IncidentCL.NarrationBy;
					(ViewModel.CurrRow)++;
					(ViewModel.PageCountRow)++;
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					ViewModel.sprFireReport.Col = 1;
					ViewModel.sprFireReport.Text = "Last Update Date:";
					ViewModel.sprFireReport.FontBold = true;
					ViewModel.sprFireReport.FontSize = 8;
					ViewModel.sprFireReport.Col = 2;
					ViewModel.sprFireReport.FontSize = 7;
					ViewModel.sprFireReport.Text = DateTime.Parse(IncidentCL.NarrationLastUpdate).ToString("M/d/yyyy");
					(ViewModel.CurrRow)++;
					(ViewModel.PageCountRow)++;
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					ViewModel.sprFireReport.Col = 1;
					ViewModel.sprFireReport.Text = "Narration:";
					ViewModel.sprFireReport.FontBold = true;
					ViewModel.sprFireReport.FontSize = 8;
					ViewModel.sprFireReport.Col = 2;
					ViewModel.sprFireReport.FontSize = 7;
					(ViewModel.CurrRow)++;
					(ViewModel.PageCountRow)++;
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					sDisplay = IncidentCL.NarrationText;
					if ( Strings.Len(sDisplay) > 0 )
					{
						sDisplay = sDisplay.Substring(0, Math.Min(Strings.Len(sDisplay), sDisplay.Length));
						ViewModel.LastRow = Strings.Len(sDisplay) / 75;
					}
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
					if ( ViewModel.PageCountRow + ViewModel.LastRow > 60 )
					{
						DisplayHeadings();
					}
					ViewModel.sprFireReport.BlockMode = true;
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					ViewModel.sprFireReport.Row2 = ViewModel.CurrRow + ViewModel.LastRow;
					ViewModel.sprFireReport.Col = 2;
					ViewModel.sprFireReport.Col2 = 9;
					ViewModel.sprFireReport.CellType = FarPoint.ViewModels.Cells.FpCellType.CellTypeStaticText;
					(ViewModel.sprFireReport.ActiveSheet.Cells[ViewModel.sprFireReport.Row, ViewModel.sprFireReport.Col].CellType as FarPoint.ViewModels.TextCellType).WordWrap = true;
					ViewModel.sprFireReport.BlockMode = false;
					//UPGRADE_ISSUE: (2064) FPSpread.vaSpread method sprFireReport.AddCellSpan was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprFireReport.AddCellSpan(2, ViewModel.CurrRow, 8, ViewModel.LastRow);
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					ViewModel.sprFireReport.Col = 2;
					ViewModel.sprFireReport.Text = sDisplay;
					ViewModel.CurrRow = ViewModel.CurrRow + ViewModel.LastRow + 1;
					ViewModel.PageCountRow = ViewModel.PageCountRow + ViewModel.LastRow + 1;
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;

					IncidentCL.IncidentNarration.MoveNext();
				};
				}

			// Unit Narratives
			if ( UnitCL.GetUnitFireNarratives(ViewModel.CurrIncident) != 0 )
			{

				while ( !UnitCL.FireUnitNarrative.EOF )
				{
					//IncidentCL.GetNarration IncidentCL.IncidentNarration("narration_id")
					if ( ViewModel.PageCountRow > 56 )
					{
						DisplayHeadings();
					}
					(ViewModel.CurrRow)++;
					(ViewModel.PageCountRow)++;
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					ViewModel.sprFireReport.Col = 1;
					ViewModel.sprFireReport.Text = "Unit Narration";
					ViewModel.sprFireReport.FontBold = true;
					ViewModel.sprFireReport.FontItalic = true;
					ViewModel.sprFireReport.FontSize = 10;
					ViewModel.sprFireReport.BlockMode = true;
					ViewModel.sprFireReport.Row2 = ViewModel.CurrRow;
					ViewModel.sprFireReport.Col2 = 10;
					ViewModel.sprFireReport.BackColor = IncidentMain.Shared.LTGRAY;
					ViewModel.sprFireReport.BlockMode = false;
					(ViewModel.CurrRow)++;
					(ViewModel.PageCountRow)++;
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					ViewModel.sprFireReport.Col = 1;
					ViewModel.sprFireReport.Text = "Narration Unit:";
					ViewModel.sprFireReport.FontBold = true;
					ViewModel.sprFireReport.FontSize = 8;
					ViewModel.sprFireReport.Col = 2;
					ViewModel.sprFireReport.FontSize = 7;
					ViewModel.sprFireReport.Text = Convert.ToString(UnitCL.FireUnitNarrative["NarrUnit"]);
					(ViewModel.CurrRow)++;
					(ViewModel.PageCountRow)++;
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					//                sprFireReport.Col = 1
					//                sprFireReport.Text = "Last Update Date:"
					//                sprFireReport.FontBold = True
					//                sprFireReport.FontSize = 8
					//                sprFireReport.Col = 2
					//                sprFireReport.FontSize = 7
					//                sprFireReport.Text = Format$(IncidentCL.NarrationLastUpdate, "m/d/yyyy")
					//                CurrRow = CurrRow + 1
					//                PageCountRow = PageCountRow + 1
					//                sprFireReport.Row = CurrRow
					ViewModel.sprFireReport.Col = 1;
					ViewModel.sprFireReport.Text = "Narration:";
					ViewModel.sprFireReport.FontBold = true;
					ViewModel.sprFireReport.FontSize = 8;
					ViewModel.sprFireReport.Col = 2;
					ViewModel.sprFireReport.FontSize = 7;
					(ViewModel.CurrRow)++;
					(ViewModel.PageCountRow)++;
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					sDisplay = Convert.ToString(UnitCL.FireUnitNarrative["NarrText"]);
					if ( Strings.Len(sDisplay) > 0 )
					{
						sDisplay = sDisplay.Substring(0, Math.Min(Strings.Len(sDisplay), sDisplay.Length));
						ViewModel.LastRow = Strings.Len(sDisplay) / 75;
					}
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
					if ( ViewModel.PageCountRow + ViewModel.LastRow > 60 )
					{
						DisplayHeadings();
					}
					ViewModel.sprFireReport.BlockMode = true;
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					ViewModel.sprFireReport.Row2 = ViewModel.CurrRow + ViewModel.LastRow;
					ViewModel.sprFireReport.Col = 2;
					ViewModel.sprFireReport.Col2 = 9;
					ViewModel.sprFireReport.CellType = FarPoint.ViewModels.Cells.FpCellType.CellTypeStaticText;
					(ViewModel.sprFireReport.ActiveSheet.Cells[ViewModel.sprFireReport.Row, ViewModel.sprFireReport.Col].CellType as FarPoint.ViewModels.TextCellType).WordWrap = true;
					ViewModel.sprFireReport.BlockMode = false;
					//UPGRADE_ISSUE: (2064) FPSpread.vaSpread method sprFireReport.AddCellSpan was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprFireReport.AddCellSpan(2, ViewModel.CurrRow, 8, ViewModel.LastRow);
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;
					ViewModel.sprFireReport.Col = 2;
					ViewModel.sprFireReport.Text = sDisplay;
					ViewModel.CurrRow = ViewModel.CurrRow + ViewModel.LastRow + 1;
					ViewModel.PageCountRow = ViewModel.PageCountRow + ViewModel.LastRow + 1;
					ViewModel.sprFireReport.Row = ViewModel.CurrRow;

					UnitCL.FireUnitNarrative.MoveNext();
				};
				}
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
			this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.Arrow);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			string htmlpath = "";
			int ExpNumber = 0;
			TFDIncident.clsFire FireReport = Container.Resolve<clsFire>();

			if ( IncidentMain.Shared.gExportFlag != 0 )
			{
				htmlpath = IncidentMain.FIREWEBPATH;
				htmlpath = htmlpath + ViewModel.IncidentNumber;
				//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprFireReport.VirtualMode was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprFireReport.setVirtualMode(false);
				if ( ViewModel.ReportType == IncidentMain.FIREOUTSIDE )
				{
					htmlpath = htmlpath + "-Outside.htm";

				}
				else if ( ViewModel.ReportType == IncidentMain.FIREMOBILE )
				{
					htmlpath = htmlpath + "-Mobile.htm";
				}
				else if ( ViewModel.ReportType == IncidentMain.FIRESTRUCTURE )
				{
					if ( ViewModel.ExportExposureFlag != 0 )
					{
						if ( FireReport.GetExposureNumber(ViewModel.FireReportID) != 0 )
						{
							ExpNumber = FireReport.GetExposureNumber(ViewModel.FireReportID);
							htmlpath = htmlpath + "-Structure_exp" + ExpNumber.ToString() + ".htm";
						}
						else
						{
							htmlpath = htmlpath + "-Structure_exp.htm";
						}
					}
					else
					{
						htmlpath = htmlpath + "-Structure.htm";
					}
				}
				else
				{
					IncidentMain.Shared.gExportFlag = 0;
					ViewManager.DisposeView(this);
				}
				//UPGRADE_ISSUE: (2064) FPSpread.vaSpread method sprFireReport.ExportRangeToHTML was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				if ( !ViewModel.sprFireReport.ExportRangeToHTML(1, 1, 10, ViewModel.CurrRow + 2, htmlpath, false, "") )
				{
				//opps!
				}
				else
				{
					if ( ~ProcessWebReport(htmlpath) != 0 )
					{
					//opps!
					}
				}
				IncidentMain.Shared.gExportFlag = 0;
				ViewManager.DisposeView(this);
			}
			else
			{
				ViewManager.DisposeView(this);
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			string htmlpath = "";
			int ExpNumber = 0;
			TFDIncident.clsFire FireReport = Container.Resolve<clsFire>();

			if ( IncidentMain.Shared.gExportFlag != 0 )
			{
				htmlpath = IncidentMain.FIREWEBPATH;
				htmlpath = htmlpath + ViewModel.IncidentNumber;
				//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprFireReport.VirtualMode was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprFireReport.setVirtualMode(false);
				if ( ViewModel.ReportType == IncidentMain.FIREOUTSIDE )
				{
					htmlpath = htmlpath + "-Outside.htm";
				}
				else if ( ViewModel.ReportType == IncidentMain.FIREMOBILE )
				{
					htmlpath = htmlpath + "-Mobile.htm";
				}
				else if ( ViewModel.ReportType == IncidentMain.FIRESTRUCTURE )
				{
					if ( ViewModel.ExportExposureFlag != 0 )
					{
						if ( FireReport.GetExposureNumber(ViewModel.FireReportID) != 0 )
						{
							ExpNumber = FireReport.GetExposureNumber(ViewModel.FireReportID);
							htmlpath = htmlpath + "-Structure_exp" + ExpNumber.ToString() + ".htm";
						}
						else
						{
							htmlpath = htmlpath + "-Structure_exp.htm";
						}
					}
					else
					{
						htmlpath = htmlpath + "-Structure.htm";
					}
				}
				else
				{
					IncidentMain.Shared.gExportFlag = 0;
					ViewManager.DisposeView(this);
				}
				//UPGRADE_ISSUE: (2064) FPSpread.vaSpread method sprFireReport.ExportRangeToHTML was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				if ( !ViewModel.sprFireReport.ExportRangeToHTML(1, 1, 10, ViewModel.CurrRow + 2, htmlpath, false, "") )
				{
				//opps!
				}
				IncidentMain.Shared.gExportFlag = 0;
				ViewManager.DisposeView(this);

			}
			else
			{
				//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprFireReport.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprFireReport.setPrintAbortMsg("Printing Fire Report - Click Cancel to quit");
				//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprFireReport.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprFireReport.setPrintBorder(false);
				//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprFireReport.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprFireReport.setPrintColor(true);
				//UPGRADE_ISSUE: (2064) FPSpread.PrintOrientationConstants property PrintOrientationConstants.PrintOrientationPortrait was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprFireReport.PrintOrientation was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprFireReport.setPrintOrientation(UpgradeStubs.FPSpread_PrintOrientationConstants.getPrintOrientationPortrait());
				ViewModel.sprFireReport.Action = FarPoint.ViewModels.FPActionConstants.ActionSmartPrint;
			}

		}

		private void DisplayHeadings()
		{
			if ( IncidentMain.Shared.gExportFlag != 0 )
			{
				return ;
			}
			(ViewModel.CurrRow)++;
			ViewModel.sprFireReport.Row = ViewModel.CurrRow;
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprFireReport.RowPageBreak was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprFireReport.setRowPageBreak(true);
			(ViewModel.CurrRow)++;
			ViewModel.sprFireReport.Row = ViewModel.CurrRow;
			ViewModel.sprFireReport.Col = 7;
			ViewModel.sprFireReport.FontSize = 8;
			ViewModel.sprFireReport.FontBold = true;
			ViewModel.sprFireReport.Text = "Print Date:";
			ViewModel.sprFireReport.Col = 9;
			ViewModel.sprFireReport.FontSize = 8;
			ViewModel.sprFireReport.FontBold = false;
			ViewModel.sprFireReport.Text = UpgradeHelpers.Helpers.StringsHelper.Format(DateTime.Now, "m/d/yyyy h:nn AM/PM");
			(ViewModel.CurrRow)++;
			ViewModel.sprFireReport.Row = ViewModel.CurrRow;
			ViewModel.sprFireReport.Col = 7;
			ViewModel.sprFireReport.FontSize = 8;
			ViewModel.sprFireReport.FontBold = true;
			ViewModel.sprFireReport.Text = "Incident Number:";
			ViewModel.sprFireReport.Col = 9;
			ViewModel.sprFireReport.FontSize = 8;
			ViewModel.sprFireReport.FontBold = false;
			ViewModel.sprFireReport.Text = ViewModel.IncidentNumber;
			(ViewModel.CurrRow)++;
			//    sprFireReport.Row = CurrRow
			//    sprFireReport.Col = 1
			//    sprFireReport.Text = "Fire Narration"
			//    sprFireReport.FontSize = 10
			//    sprFireReport.FontBold = True
			//    sprFireReport.FontItalic = True
			//    sprFireReport.BlockMode = True
			//    sprFireReport.Row2 = CurrRow
			//    sprFireReport.Col2 = 10
			//    sprFireReport.BackColor = LTGRAY
			//    sprFireReport.BlockMode = False
			//    CurrRow = CurrRow + 1
			//    sprFireReport.Row = CurrRow
			//    sprFireReport.Col = 1
			//'    sprFireReport.Text = "Narration Continued:"
			//    sprFireReport.FontBold = True
			//    sprFireReport.FontSize = 8
			//    sprFireReport.Col = 2
			//    sprFireReport.FontSize = 7
			//    CurrRow = CurrRow + 1
			ViewModel.PageCountRow = 3;
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			//Produce Fire Report Print Preview
			//Using global gPrintReportID parameter
			//************************
			//** Database Connections for testing
			//************************
			//    oIncident.Open "Provider=SQLOLEDB; Data Source=TFDSQL3; Initial Catalog=Incident; Integrated Security=SSPI"
			//    oPTSdata.Open "Provider=SQLOLEDB; Data Source=TFDSQL3; Initial Catalog=PTSdata; Integrated Security=SSPI"
			TFDIncident.clsReportLog ReportLog = Container.Resolve<clsReportLog>();

			//**********************************************
			//** Hardcoded report id's for testing
			//****************************
			//Outside Fire
			//ReportLog.GetReportLog 84321

			//Structure Fire
			//ReportLog.GetReportLog 84208

			//Mobile Fire
			//ReportLog.GetReportLog 84559

			//Vessel Fire
			//ReportLog.GetReportLog 27525
			//*********************************************

			ReportLog.GetReportLog(IncidentMain.Shared.gEditReportID);
			ViewModel.CurrRow = 0;
			ViewModel.SaveRow = 0;
			ViewModel.PageCountRow = 0;
			ViewModel.LastRow = 0;
			ViewModel.IncidentNumber = "";
			ViewModel.ExportExposureFlag = 0;
			ViewModel.SkippedExport = 0;
			ViewModel.ReportType = ReportLog.ReportType;
			ViewModel.CurrIncident = ReportLog.RLIncidentID;
			ViewModel.FireReportID = ReportLog.ReportReferenceID;
			if ( IncidentMain.Shared.gExportFlag != 0 )
			{
				ViewModel.cmdPrint.Visible = false;
				ViewModel.cmdClose.Text = "Post to Web";
				ViewModel.Label1.Text = "Fire Report - Publish";
				ViewModel.SkippedExport = -1;
			}
			else
			{
				ViewModel.cmdPrint.Visible = true;
				ViewModel.cmdPrint.Text = "Print";
				ViewModel.cmdClose.Text = "Close";
				ViewModel.Label1.Text = "Fire Report - Print Preview";
			}

			LoadFireReport();

		}


		public int ProcessWebReport(string sFilePath)
		{
			//Save or update Web report record
			int result = 0;
			TFDIncident.clsFire FireReport = Container.Resolve<clsFire>();
			TFDIncident.clsIncident IncidentClass = Container.Resolve<clsIncident>();
			TFDIncident.clsCommonCodes cCommonCodes = Container.Resolve<clsCommonCodes>();

			try
			{

				result = -1;

				if ( ~IncidentClass.GetIncident(ViewModel.CurrIncident) != 0 )
				{
					return 0;
				}


				if ( ~FireReport.GetFireWebReport(ViewModel.CurrIncident, ViewModel.FireReportID) != 0 )
				{
					//Add Fire Web Report
					FireReport.WebIncidentID = ViewModel.CurrIncident;
					FireReport.WebFireReportID = ViewModel.FireReportID;
					FireReport.WebIncidentNumber = ViewModel.IncidentNumber;
					FireReport.WebReportType = ViewModel.ReportType;
					FireReport.WebGeoLocation = IncidentMain.Clean(IncidentClass.GeoLocation);
					FireReport.WebCityName = cCommonCodes.GetCityName(IncidentClass.CityCode);
					FireReport.WebIncidentDate = IncidentClass.DateIncidentCreated;
					FireReport.WebFilePath = sFilePath;
					if ( IncidentClass.GetLatLong(ViewModel.CurrIncident) != 0 )
					{
						FireReport.WebLat = IncidentClass.LLlat;
						FireReport.WebLong = IncidentClass.LLlong;
					}
					else
					{
						FireReport.WebLat = "";
						FireReport.WebLong = "";
					}
					FireReport.WebTransferFlag = 0;

					if ( ~FireReport.AddFireWebReport() != 0 )
					{
						result = 0;
					}
					else
					{
						ViewModel.SkippedExport = 0;
					}

				}
				else
				{
					//Update Fire Web Report
					FireReport.WebReportType = ViewModel.ReportType;
					FireReport.WebGeoLocation = IncidentMain.Clean(IncidentClass.GeoLocation);
					FireReport.WebCityName = IncidentMain.Clean(cCommonCodes.GetCityName(IncidentClass.CityCode));
					FireReport.WebIncidentDate = IncidentClass.DateIncidentCreated;
					FireReport.WebFilePath = sFilePath;
					if ( IncidentClass.GetLatLong(ViewModel.CurrIncident) != 0 )
					{
						FireReport.WebLat = IncidentClass.LLlat;
						FireReport.WebLong = IncidentClass.LLlong;
					}
					else
					{
						FireReport.WebLat = "";
						FireReport.WebLong = "";
					}
					FireReport.WebTransferFlag = 0;

					if ( ~FireReport.UpdateFireWebReport() != 0 )
					{
						result = 0;
					}
					else
					{
						ViewModel.SkippedExport = 0;
					}


				}
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
			//check to see if report was not posted to the web
			string htmlpath = "";
			int ExpNumber = 0;
			TFDIncident.clsFire FireReport = Container.Resolve<clsFire>();


			if ( ViewModel.SkippedExport != 0 )
			{
				htmlpath = IncidentMain.FIREWEBPATH;
				htmlpath = htmlpath + ViewModel.IncidentNumber;
				//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprFireReport.VirtualMode was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprFireReport.setVirtualMode(false);
				if ( ViewModel.ReportType == IncidentMain.FIREOUTSIDE )
				{
					htmlpath = htmlpath + "-Outside.htm";

				}
				else if ( ViewModel.ReportType == IncidentMain.FIREMOBILE )
				{
					htmlpath = htmlpath + "-Mobile.htm";
				}
				else if ( ViewModel.ReportType == IncidentMain.FIRESTRUCTURE )
				{
					if ( ViewModel.ExportExposureFlag != 0 )
					{
						if ( FireReport.GetExposureNumber(ViewModel.FireReportID) != 0 )
						{
							ExpNumber = FireReport.GetExposureNumber(ViewModel.FireReportID);
							htmlpath = htmlpath + "-Structure_exp" + ExpNumber.ToString() + ".htm";
						}
						else
						{
							htmlpath = htmlpath + "-Structure_exp.htm";
						}
					}
					else
					{
						htmlpath = htmlpath + "-Structure.htm";
					}
				}
				else
				{
					IncidentMain.Shared.gExportFlag = 0;
					ViewManager.DisposeView(this);
				}
				//UPGRADE_ISSUE: (2064) FPSpread.vaSpread method sprFireReport.ExportRangeToHTML was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				if ( !ViewModel.sprFireReport.ExportRangeToHTML(1, 1, 10, ViewModel.CurrRow + 2, htmlpath, false, "") )
				{
				//opps!
				}
				else
				{
					if ( ~ProcessWebReport(htmlpath) != 0 )
					{
					//opps!
					}
				}
				IncidentMain.Shared.gExportFlag = 0;
				ViewManager.DisposeView(this);
			}
			else
			{
				ViewManager.DisposeView(this);
			}

		}

		public static frmReportFire DefInstance
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

		public static frmReportFire CreateInstance()
		{
			TFDIncident.frmReportFire theInstance = Shared.Container.Resolve<frmReportFire>();
			theInstance.Form_Load();
			return theInstance;
		}

		protected override void ExecuteControlsStartup()
		{
			ViewModel.sprFireReport.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprFireReport.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmReportFire
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.frmReportFireViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmReportFire m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}