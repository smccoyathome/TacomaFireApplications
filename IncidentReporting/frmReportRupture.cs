using Microsoft.VisualBasic;
using System;
using UpgradeHelpers.DB.ADO;
using UpgradeStubs;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident
{

	public partial class frmReportRupture
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.frmReportRuptureViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmReportRupture));
			if ( Shared.m_vb6FormDefInstance == null )
			{
				if ( Shared.m_InitializingDefInstance )
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
		}


		private void frmReportRupture_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender )
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>)eventSender;
			}
		}

		private void LoadRuptureReport()
		{
			//Format Rupture Report
			TFDIncident.clsRupture RuptureReport = Container.Resolve<clsRupture>();
			TFDIncident.clsFireCodes FireCodes = Container.Resolve<clsFireCodes>();
			TFDIncident.clsIncident IncidentCL = Container.Resolve<clsIncident>();
			TFDIncident.clsUnit UnitCL = Container.Resolve<clsUnit>();
			int x = 0;
			string CurrUnit = "";
			string sDisplay = "";
			ViewModel.sprRuptureReport.Row = 1;
			ViewModel.sprRuptureReport.Col = 8;
			ViewModel.sprRuptureReport.Text = UpgradeHelpers.Helpers.StringsHelper.Format(DateTime.Now, "m/d/yyyy h:nn AM/PM");
			if ( ViewModel.ReportType == IncidentMain.RUPTUREOUTSIDE )
			{
				if ( ~RuptureReport.GetRuptureOutsideReport(ViewModel.RuptureReportID) != 0 )
				{
					ViewManager.ShowMessage("Error retrieving Rupture Report", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					return ;
				}
				else
				{
					ViewModel.RuptureReportID = RuptureReport.RuptureOutsideID;
				}
			}
			else
			{
				if ( ~RuptureReport.GetRuptureReport(ViewModel.RuptureReportID) != 0 )
				{
					ViewManager.ShowMessage("Error retrieving Rupture Report", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					return ;
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
					ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
					ViewModel.sprRuptureReport.Col = 2;
					ViewModel.sprRuptureReport.Text = IncidentCL.IncidentNumber;
					ViewModel.IncidentNumber = IncidentCL.IncidentNumber;
					(ViewModel.CurrRow)++;
					ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
					ViewModel.sprRuptureReport.Col = 2;
					ViewModel.sprRuptureReport.Text = DateTime.Parse(IncidentCL.DateIncidentCreated).ToString("M/d/yyyy   HH:mm");
					(ViewModel.CurrRow)++;
					ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
					ViewModel.sprRuptureReport.Col = 2;
					ViewModel.sprRuptureReport.Text = IncidentCL.Location;
					ViewModel.CurrRow = 5;
					//Unit Times
					if ( UnitCL.GetUnitResponseTimesReport(ViewModel.CurrIncident) != 0 )
					{

						while ( !UnitCL.UnitTimes.EOF )
						{
							if ( Convert.ToString(UnitCL.UnitTimes["Unit"]) != CurrUnit )
							{
								(ViewModel.CurrRow)++;
								ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
								CurrUnit = Convert.ToString(UnitCL.UnitTimes["Unit"]);
								ViewModel.sprRuptureReport.Col = 5;
								ViewModel.sprRuptureReport.Text = IncidentMain.Clean(UnitCL.UnitTimes["unit_name"]);
							}
							switch ( Convert.ToInt32(UnitCL.UnitTimes["response_time_code"]) )
							{
								case 3: //Dispatched 

									ViewModel.sprRuptureReport.Col = 7;
									ViewModel.sprRuptureReport.Text = Convert.ToDateTime(UnitCL.UnitTimes["unit_time"]).ToString("HH:mm");
									break;
								case 5: //onscene 

									ViewModel.sprRuptureReport.Col = 8;
									ViewModel.sprRuptureReport.Text = Convert.ToDateTime(UnitCL.UnitTimes["unit_time"]).ToString("HH:mm");
									break;
								case 8: //available 

									ViewModel.sprRuptureReport.Col = 9;
									ViewModel.sprRuptureReport.Text = Convert.ToDateTime(UnitCL.UnitTimes["unit_time"]).ToString("HH:mm");
									break;
							}
							UnitCL.UnitTimes.MoveNext();
						};
						}
					}
				}
			ViewModel.SaveRow = ViewModel.CurrRow;
			// ****** Rupture Outside Detail Information *****
			//CurrRow = 10
			ViewModel.sprRuptureReport.Col = 1;
			switch ( ViewModel.ReportType )
			{
				case IncidentMain.RUPTUREOUTSIDE:
					ViewModel.CurrRow += 2;
					ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
					ViewModel.sprRuptureReport.Text = "Outside Rupture Detail Information";
					ViewModel.sprRuptureReport.FontSize = 10;
					ViewModel.sprRuptureReport.FontBold = true;
					ViewModel.sprRuptureReport.FontItalic = true;
					ViewModel.sprRuptureReport.BlockMode = true;
					ViewModel.sprRuptureReport.Row2 = ViewModel.CurrRow;
					ViewModel.sprRuptureReport.Col2 = 10;
					ViewModel.sprRuptureReport.BackColor = IncidentMain.Shared.LTGRAY;
					ViewModel.sprRuptureReport.BlockMode = false;
					(ViewModel.CurrRow)++;
					ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
					ViewModel.sprRuptureReport.Text = "Rupture Type:";
					ViewModel.sprRuptureReport.FontBold = true;
					ViewModel.sprRuptureReport.FontSize = 8;
					ViewModel.sprRuptureReport.Col = 2;
					ViewModel.sprRuptureReport.FontSize = 7;
					ViewModel.sprRuptureReport.Text = IncidentMain.Clean(RuptureReport.RuptureOutsideRS["rupture_type_desc"]);
					ViewModel.sprRuptureReport.FontBold = false;
					ViewModel.sprRuptureReport.FontSize = 8;
					ViewModel.sprRuptureReport.Col = 5;
					ViewModel.sprRuptureReport.Text = "Names Associated?";
					ViewModel.sprRuptureReport.FontBold = true;
					if ( IncidentCL.NameListRS(ViewModel.CurrIncident) != 0 )
					{
						ViewModel.sprRuptureReport.Col = 7;
						ViewModel.sprRuptureReport.Text = "Yes";
					}
					else
					{
						ViewModel.sprRuptureReport.Col = 7;
						ViewModel.sprRuptureReport.Text = "No";
					}
					(ViewModel.CurrRow)++;
					ViewModel.sprRuptureReport.Col = 1;
					ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
					ViewModel.sprRuptureReport.Text = "Content Loss:";
					ViewModel.sprRuptureReport.FontBold = true;
					ViewModel.sprRuptureReport.FontSize = 8;
					ViewModel.sprRuptureReport.Col = 2;
					ViewModel.sprRuptureReport.FontSize = 7;
					ViewModel.sprRuptureReport.Text = IncidentMain.Clean(RuptureReport.RuptureOutsideRS["content_loss"]);
					(ViewModel.CurrRow)++;
					ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
					ViewModel.sprRuptureReport.Col = 1;
					ViewModel.sprRuptureReport.Text = "Area Affected:";
					ViewModel.sprRuptureReport.FontBold = true;
					ViewModel.sprRuptureReport.FontSize = 8;
					ViewModel.sprRuptureReport.Col = 2;
					ViewModel.sprRuptureReport.FontSize = 7;
					ViewModel.sprRuptureReport.Text = IncidentMain.Clean(RuptureReport.RuptureOutsideRS["area_affected"]);
					ViewModel.sprRuptureReport.Col = 3;
					ViewModel.sprRuptureReport.FontSize = 7;
					ViewModel.sprRuptureReport.Text = IncidentMain.Clean(RuptureReport.RuptureOutsideRS["area_unit"]);
					(ViewModel.CurrRow)++;
					ViewModel.SaveRow = ViewModel.CurrRow;
					break;
				default:
					RuptureReport.GetRuptureReport(ViewModel.RuptureReportID);
					ViewModel.CurrRow = ViewModel.SaveRow;
					ViewModel.CurrRow += 2;
					ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
					ViewModel.sprRuptureReport.Col = 1;
					ViewModel.sprRuptureReport.Text = "Rupture/Explosion Detail Information";
					ViewModel.sprRuptureReport.FontSize = 10;
					ViewModel.sprRuptureReport.FontBold = true;
					ViewModel.sprRuptureReport.FontItalic = true;
					ViewModel.sprRuptureReport.BlockMode = true;
					ViewModel.sprRuptureReport.Row2 = ViewModel.CurrRow;
					ViewModel.sprRuptureReport.Col2 = 10;
					ViewModel.sprRuptureReport.BackColor = IncidentMain.Shared.LTGRAY;
					ViewModel.sprRuptureReport.BlockMode = false;
					(ViewModel.CurrRow)++;
					ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
					ViewModel.sprRuptureReport.Text = "Rupture Type:";
					ViewModel.sprRuptureReport.FontBold = true;
					ViewModel.sprRuptureReport.FontSize = 8;
					ViewModel.sprRuptureReport.Col = 2;
					ViewModel.sprRuptureReport.FontSize = 7;
					ViewModel.sprRuptureReport.Text = IncidentMain.Clean(RuptureReport.RuptureExplosion["rupture_type_desc"]);
					ViewModel.sprRuptureReport.FontSize = 8;
					ViewModel.sprRuptureReport.Col = 5;
					ViewModel.sprRuptureReport.FontBold = true;
					ViewModel.sprRuptureReport.Text = "Names Associated?";
					if ( IncidentCL.NameListRS(ViewModel.CurrIncident) != 0 )
					{
						ViewModel.sprRuptureReport.Col = 7;
						ViewModel.sprRuptureReport.Text = "Yes";
					}
					else
					{
						ViewModel.sprRuptureReport.Col = 7;
						ViewModel.sprRuptureReport.Text = "No";
					}
					(ViewModel.CurrRow)++;
					ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
					ViewModel.sprRuptureReport.Col = 1;
					ViewModel.sprRuptureReport.Text = "Property Use:";
					ViewModel.sprRuptureReport.FontBold = true;
					ViewModel.sprRuptureReport.FontSize = 8;
					ViewModel.sprRuptureReport.Col = 2;
					ViewModel.sprRuptureReport.FontSize = 7;
					ViewModel.sprRuptureReport.Text = IncidentMain.Clean(RuptureReport.RuptureExplosion["prop_use_desc"]);
					(ViewModel.CurrRow)++;
					ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
					ViewModel.sprRuptureReport.Col = 1;
					ViewModel.sprRuptureReport.Text = "Area of Origin:";
					ViewModel.sprRuptureReport.FontBold = true;
					ViewModel.sprRuptureReport.FontSize = 8;
					ViewModel.sprRuptureReport.Col = 2;
					ViewModel.sprRuptureReport.FontSize = 7;
					ViewModel.sprRuptureReport.Text = IncidentMain.Clean(RuptureReport.RuptureExplosion["area_of_origin_desc"]);
					(ViewModel.CurrRow)++;
					ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
					ViewModel.sprRuptureReport.Col = 1;
					ViewModel.sprRuptureReport.Text = "Property Value:";
					ViewModel.sprRuptureReport.FontBold = true;
					ViewModel.sprRuptureReport.FontSize = 8;
					ViewModel.sprRuptureReport.Col = 2;
					ViewModel.sprRuptureReport.FontSize = 7;
					ViewModel.sprRuptureReport.Text = UpgradeHelpers.Helpers.StringsHelper.Format(RuptureReport.RuptureExplosion["property_value"], "$#,###");
					(ViewModel.CurrRow)++;
					ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
					ViewModel.sprRuptureReport.Col = 1;
					ViewModel.sprRuptureReport.Text = "Property Loss:";
					ViewModel.sprRuptureReport.FontBold = true;
					ViewModel.sprRuptureReport.FontSize = 8;
					ViewModel.sprRuptureReport.Col = 2;
					ViewModel.sprRuptureReport.FontSize = 7;
					ViewModel.sprRuptureReport.Text = UpgradeHelpers.Helpers.StringsHelper.Format(RuptureReport.RuptureExplosion["property_loss"], "$#,###");
					(ViewModel.CurrRow)++;
					ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
					ViewModel.sprRuptureReport.Col = 1;
					ViewModel.sprRuptureReport.Text = "Content Loss:";
					ViewModel.sprRuptureReport.FontBold = true;
					ViewModel.sprRuptureReport.FontSize = 8;
					ViewModel.sprRuptureReport.Col = 2;
					ViewModel.sprRuptureReport.FontSize = 7;
					ViewModel.sprRuptureReport.Text = UpgradeHelpers.Helpers.StringsHelper.Format(RuptureReport.RuptureExplosion["content_loss"], "$#,###");
					ViewModel.SaveRow = ViewModel.CurrRow;
					//Rupture Structure 
					if ( RuptureReport.GetRuptureStructureReport(ViewModel.RuptureReportID) != 0 )
					{
						(ViewModel.CurrRow)++;
						ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
						ViewModel.sprRuptureReport.Col = 1;
						ViewModel.sprRuptureReport.Text = "Structure Rupture/Explosion Information";
						ViewModel.sprRuptureReport.FontSize = 10;
						ViewModel.sprRuptureReport.FontBold = true;
						ViewModel.sprRuptureReport.FontItalic = true;
						ViewModel.sprRuptureReport.BlockMode = true;
						ViewModel.sprRuptureReport.Row2 = ViewModel.CurrRow;
						ViewModel.sprRuptureReport.Col2 = 10;
						ViewModel.sprRuptureReport.BackColor = IncidentMain.Shared.LTGRAY;
						ViewModel.sprRuptureReport.BlockMode = false;
						(ViewModel.CurrRow)++;
						ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
						ViewModel.sprRuptureReport.Col = 1;
						ViewModel.sprRuptureReport.Text = "Bldg. Status:";
						ViewModel.sprRuptureReport.FontBold = true;
						ViewModel.sprRuptureReport.FontSize = 8;
						ViewModel.sprRuptureReport.Col = 2;
						ViewModel.sprRuptureReport.FontSize = 7;
						ViewModel.sprRuptureReport.Text = IncidentMain.Clean(RuptureReport.RuptureStructureRS["building_status"]);
						ViewModel.sprRuptureReport.Col = 6;
						ViewModel.sprRuptureReport.Text = "Floor of Origin:";
						ViewModel.sprRuptureReport.FontBold = true;
						ViewModel.sprRuptureReport.FontSize = 8;
						ViewModel.sprRuptureReport.Col = 7;
						ViewModel.sprRuptureReport.FontSize = 7;
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprRuptureReport.Text = Convert.ToString(IncidentMain.GetVal(RuptureReport.RuptureStructureRS["floor_of_origin"]));
						if ( ViewModel.sprRuptureReport.Text == "-1" )
						{
							ViewModel.sprRuptureReport.Text = "Bsmt";
						}
						else if ( ViewModel.sprRuptureReport.Text == "99" )
						{
							ViewModel.sprRuptureReport.Text = "Attic";
						}
						else if ( ViewModel.sprRuptureReport.Text == "100" )
						{
							ViewModel.sprRuptureReport.Text = "Roof";
						}
						(ViewModel.CurrRow)++;
						ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
						ViewModel.sprRuptureReport.Col = 1;
						ViewModel.sprRuptureReport.Text = "Const. Type:";
						ViewModel.sprRuptureReport.FontBold = true;
						ViewModel.sprRuptureReport.FontSize = 8;
						ViewModel.sprRuptureReport.Col = 2;
						ViewModel.sprRuptureReport.FontSize = 7;
						ViewModel.sprRuptureReport.Text = IncidentMain.Clean(RuptureReport.RuptureStructureRS["construction_type"]);
						ViewModel.sprRuptureReport.Col = 6;
						ViewModel.sprRuptureReport.Text = "No. of Stories/Basement Levels:";
						ViewModel.sprRuptureReport.FontBold = true;
						ViewModel.sprRuptureReport.FontSize = 8;
						ViewModel.sprRuptureReport.Col = 8;
						ViewModel.sprRuptureReport.FontSize = 7;
						ViewModel.sprRuptureReport.Text = IncidentMain.Clean(RuptureReport.RuptureStructureRS["number_of_stories"]) + "/" + IncidentMain.Clean(RuptureReport.RuptureStructureRS["basement_levels"]);
						(ViewModel.CurrRow)++;
						ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
						ViewModel.sprRuptureReport.Col = 1;
						ViewModel.sprRuptureReport.Text = "Sq Ft Damaged:";
						ViewModel.sprRuptureReport.FontBold = true;
						ViewModel.sprRuptureReport.FontSize = 8;
						ViewModel.sprRuptureReport.Col = 2;
						ViewModel.sprRuptureReport.FontSize = 7;
						ViewModel.sprRuptureReport.Text = IncidentMain.Clean(RuptureReport.RuptureStructureRS["sq_foot_damaged"]);
						ViewModel.sprRuptureReport.Col = 6;
						ViewModel.sprRuptureReport.Text = "Total Sq. Ft.:";
						ViewModel.sprRuptureReport.FontBold = true;
						ViewModel.sprRuptureReport.FontSize = 8;
						ViewModel.sprRuptureReport.Col = 7;
						ViewModel.sprRuptureReport.FontSize = 7;
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprRuptureReport.Text = Convert.ToString(IncidentMain.GetVal(RuptureReport.RuptureStructureRS["total_sq_footage"]));
						(ViewModel.CurrRow)++;
						ViewModel.SaveRow = ViewModel.CurrRow;
						ViewModel.sprRuptureReport.Col = 6;
						ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
						ViewModel.sprRuptureReport.Col = 6;
						ViewModel.sprRuptureReport.Text = "No. of Occupants:";
						ViewModel.sprRuptureReport.FontBold = true;
						ViewModel.sprRuptureReport.FontSize = 8;
						ViewModel.sprRuptureReport.Col = 7;
						ViewModel.sprRuptureReport.FontSize = 7;
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprRuptureReport.Text = Convert.ToString(IncidentMain.GetVal(RuptureReport.RuptureStructureRS["number_people_occuping"]));
						(ViewModel.CurrRow)++;
						ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
						ViewModel.sprRuptureReport.Col = 6;
						ViewModel.sprRuptureReport.Text = "No. of People Displaced:";
						ViewModel.sprRuptureReport.FontBold = true;
						ViewModel.sprRuptureReport.FontSize = 8;
						ViewModel.sprRuptureReport.Col = 7;
						ViewModel.sprRuptureReport.FontSize = 7;
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprRuptureReport.Text = Convert.ToString(IncidentMain.GetVal(RuptureReport.RuptureStructureRS["number_people_displaced"]));
						(ViewModel.CurrRow)++;
						ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
						ViewModel.sprRuptureReport.Col = 6;
						ViewModel.sprRuptureReport.Text = "No. of Businesses:";
						ViewModel.sprRuptureReport.FontBold = true;
						ViewModel.sprRuptureReport.FontSize = 8;
						ViewModel.sprRuptureReport.Col = 7;
						ViewModel.sprRuptureReport.FontSize = 7;
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprRuptureReport.Text = Convert.ToString(IncidentMain.GetVal(RuptureReport.RuptureStructureRS["number_business_occuping"]));
						(ViewModel.CurrRow)++;
						ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
						ViewModel.sprRuptureReport.Col = 6;
						ViewModel.sprRuptureReport.Text = "No. Businesses Displaced:";
						ViewModel.sprRuptureReport.FontBold = true;
						ViewModel.sprRuptureReport.FontSize = 8;
						ViewModel.sprRuptureReport.Col = 7;
						ViewModel.sprRuptureReport.FontSize = 7;
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprRuptureReport.Text = Convert.ToString(IncidentMain.GetVal(RuptureReport.RuptureStructureRS["number_businesses_displaced"]));
						(ViewModel.CurrRow)++;
						ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
						ViewModel.sprRuptureReport.Col = 6;
						ViewModel.sprRuptureReport.Text = "No. Jobs Lost:";
						ViewModel.sprRuptureReport.FontBold = true;
						ViewModel.sprRuptureReport.FontSize = 8;
						ViewModel.sprRuptureReport.Col = 7;
						ViewModel.sprRuptureReport.FontSize = 7;
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprRuptureReport.Text = Convert.ToString(IncidentMain.GetVal(RuptureReport.RuptureStructureRS["number_jobs_lost"]));
						ViewModel.LastRow = ViewModel.CurrRow;
						ViewModel.CurrRow = ViewModel.SaveRow;
						(ViewModel.CurrRow)++;
						ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
						ViewModel.sprRuptureReport.Col = 1;
						if ( RuptureReport.GetRuptureSuppressionFactor(ViewModel.RuptureReportID) != 0 )
						{
							(ViewModel.CurrRow)++;
							ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
							ViewModel.sprRuptureReport.Col = 1;
							ViewModel.sprRuptureReport.Text = "Rupture/Explosion Suppression Factors:";
							ViewModel.sprRuptureReport.FontBold = true;
							ViewModel.sprRuptureReport.FontSize = 8;
							(ViewModel.CurrRow)++;
							ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;

							while ( RuptureReport.GetRuptureSuppressionFactorReport(ViewModel.RuptureReportID) == 0 )
							{
								ViewModel.sprRuptureReport.FontSize = 7;
								ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
								ViewModel.sprRuptureReport.Text = IncidentMain.Clean(RuptureReport.RuptureSuppressionFactor["suppression_factor"]);
								(ViewModel.CurrRow)++;
								RuptureReport.RuptureSuppressionFactor.MoveNext();
							}
							;
						}
						if ( RuptureReport.GetRupturePhysicalContributingFactorReport(ViewModel.RuptureReportID) )
						{
							(ViewModel.CurrRow)++;
							ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
							ViewModel.sprRuptureReport.Col = 1;
							ViewModel.sprRuptureReport.Text = "Physical Contributing Factors:";
							ViewModel.sprRuptureReport.FontBold = true;
							ViewModel.sprRuptureReport.FontSize = 8;
							(ViewModel.CurrRow)++;
							ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;

							while ( !RuptureReport.RupturePhysicalContributingFactor.EOF )
							{
								ViewModel.sprRuptureReport.FontSize = 7;
								ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
								ViewModel.sprRuptureReport.Text = IncidentMain.Clean(RuptureReport.RupturePhysicalContributingFactor["physical_contrib_factor"]);
								(ViewModel.CurrRow)++;
								RuptureReport.RupturePhysicalContributingFactor.MoveNext();
							}
							;
						}
						if ( RuptureReport.GetRuptureHumanContributingFactorReport(ViewModel.RuptureReportID) != 0 )
						{
							(ViewModel.CurrRow)++;
							ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
							ViewModel.sprRuptureReport.Col = 1;
							ViewModel.sprRuptureReport.Text = "Human Contributing Factors:";
							ViewModel.sprRuptureReport.FontBold = true;
							ViewModel.sprRuptureReport.FontSize = 8;
							(ViewModel.CurrRow)++;
							ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;

							while ( !RuptureReport.RuptureHumanContributingFactor.EOF )
							{
								ViewModel.sprRuptureReport.FontSize = 7;
								ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
								ViewModel.sprRuptureReport.Text = IncidentMain.Clean(RuptureReport.RuptureHumanContributingFactor["human_contrib_factor"]);
								(ViewModel.CurrRow)++;
								RuptureReport.RuptureHumanContributingFactor.MoveNext();
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
						if ( RuptureReport.GetRuptureMobileReport(ViewModel.RuptureReportID) != 0 )
						{
							ViewModel.CurrRow = ViewModel.SaveRow;
							(ViewModel.CurrRow)++;
							ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
							ViewModel.sprRuptureReport.Col = 1;
							ViewModel.sprRuptureReport.Text = "Mobile Rupture/Explosion Information";
							ViewModel.sprRuptureReport.FontSize = 10;
							ViewModel.sprRuptureReport.FontBold = true;
							ViewModel.sprRuptureReport.FontItalic = true;
							ViewModel.sprRuptureReport.BlockMode = true;
							ViewModel.sprRuptureReport.Row2 = ViewModel.CurrRow;
							ViewModel.sprRuptureReport.Col2 = 10;
							ViewModel.sprRuptureReport.BackColor = IncidentMain.Shared.LTGRAY;
							ViewModel.sprRuptureReport.BlockMode = false;
							(ViewModel.CurrRow)++;
							ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
							ViewModel.sprRuptureReport.Col = 1;
							if ( Convert.ToString(RuptureReport.RuptureExplosion["prop_use_desc"]) == "Water Vessels" )
							{
								ViewModel.sprRuptureReport.Text = "Vessel Length (ft.)";
								ViewModel.sprRuptureReport.FontBold = true;
								ViewModel.sprRuptureReport.FontSize = 8;
								ViewModel.sprRuptureReport.Col = 2;
								ViewModel.sprRuptureReport.FontSize = 7;
								ViewModel.sprRuptureReport.Text = Convert.ToString(RuptureReport.RuptureMobileRS["water_vessel_length"]);
								(ViewModel.CurrRow)++;
							}
							else
							{
								ViewModel.sprRuptureReport.Text = "Vehicle Make:";
								ViewModel.sprRuptureReport.FontBold = true;
								ViewModel.sprRuptureReport.FontSize = 8;
								ViewModel.sprRuptureReport.Col = 2;
								ViewModel.sprRuptureReport.FontSize = 7;
								//                        If RuptureReport.RuptureMobileRS("vehicle_make") <> "" Then
								//                            sprRuptureReport.Text = Clean(RuptureReport.RuptureMobileRS("description"]) & ": " & Clean(RuptureReport.RuptureMobileRS("vehicle_make"])
								//                        Else
								//                            sprRuptureReport.Text = Clean(RuptureReport.RuptureMobileRS("description"])
								//                        End If
								ViewModel.sprRuptureReport.Text = IncidentMain.Clean(RuptureReport.RuptureMobileRS["vehicle_make"]);
								(ViewModel.CurrRow)++;
								ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
								ViewModel.sprRuptureReport.Col = 1;
								ViewModel.sprRuptureReport.Text = "Vehicle Model:";
								ViewModel.sprRuptureReport.FontBold = true;
								ViewModel.sprRuptureReport.FontSize = 8;
								ViewModel.sprRuptureReport.Col = 2;
								ViewModel.sprRuptureReport.FontSize = 7;
								ViewModel.sprRuptureReport.Text = Convert.ToString(RuptureReport.RuptureMobileRS["vehicle_model"]);
								(ViewModel.CurrRow)++;
								ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
								ViewModel.sprRuptureReport.Col = 1;
								ViewModel.sprRuptureReport.Text = "Vehicle Year:";
								ViewModel.sprRuptureReport.FontBold = true;
								ViewModel.sprRuptureReport.FontSize = 8;
								ViewModel.sprRuptureReport.Col = 2;
								ViewModel.sprRuptureReport.FontSize = 7;
								ViewModel.sprRuptureReport.Text = Convert.ToString(RuptureReport.RuptureMobileRS["vehicle_year"]);
								(ViewModel.CurrRow)++;
								ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
								ViewModel.sprRuptureReport.Col = 1;
								ViewModel.sprRuptureReport.Text = "Vehicle Vin#:";
								ViewModel.sprRuptureReport.FontBold = true;
								ViewModel.sprRuptureReport.FontSize = 8;
								ViewModel.sprRuptureReport.Col = 2;
								ViewModel.sprRuptureReport.FontSize = 7;
								ViewModel.sprRuptureReport.Text = Convert.ToString(RuptureReport.RuptureMobileRS["vehicle_vin"]);
								(ViewModel.CurrRow)++;
								ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
								ViewModel.sprRuptureReport.Col = 1;
								ViewModel.sprRuptureReport.Text = "Vehicle License State:";
								ViewModel.sprRuptureReport.FontBold = true;
								ViewModel.sprRuptureReport.FontSize = 8;
								ViewModel.sprRuptureReport.Col = 2;
								ViewModel.sprRuptureReport.FontSize = 7;
							//                        sprRuptureReport.Text = Clean(RuptureReport.RuptureMobileRS("license_state"])
							}

							if ( RuptureReport.GetRuptureSuppressionFactor(ViewModel.RuptureReportID) != 0 )
							{
								(ViewModel.CurrRow)++;
								ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
								ViewModel.sprRuptureReport.Col = 1;
								ViewModel.sprRuptureReport.Text = "Rupture/Explosion Suppression Factors:";
								ViewModel.sprRuptureReport.FontBold = true;
								ViewModel.sprRuptureReport.FontSize = 8;
								(ViewModel.CurrRow)++;
								ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;

								while ( RuptureReport.GetRuptureSuppressionFactorReport(ViewModel.RuptureReportID) == 0 )
								{
									ViewModel.sprRuptureReport.FontSize = 7;
									ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
									ViewModel.sprRuptureReport.Text = IncidentMain.Clean(RuptureReport.RuptureSuppressionFactor["suppression_factor"]);
									(ViewModel.CurrRow)++;
									RuptureReport.RuptureSuppressionFactor.MoveNext();
								}
								;
							}
							if ( RuptureReport.GetRupturePhysicalContributingFactorReport(ViewModel.RuptureReportID) )
							{
								(ViewModel.CurrRow)++;
								ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
								ViewModel.sprRuptureReport.Col = 1;
								ViewModel.sprRuptureReport.Text = "Physical Contributing Factors:";
								ViewModel.sprRuptureReport.FontBold = true;
								ViewModel.sprRuptureReport.FontSize = 8;
								(ViewModel.CurrRow)++;
								ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;

								while ( !RuptureReport.RupturePhysicalContributingFactor.EOF )
								{
									ViewModel.sprRuptureReport.FontSize = 7;
									ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
									ViewModel.sprRuptureReport.Text = IncidentMain.Clean(RuptureReport.RupturePhysicalContributingFactor["physical_contrib_factor"]);
									(ViewModel.CurrRow)++;
									RuptureReport.RupturePhysicalContributingFactor.MoveNext();
								}
								;
							}
							if ( RuptureReport.GetRuptureHumanContributingFactorReport(ViewModel.RuptureReportID) != 0 )
							{
								(ViewModel.CurrRow)++;
								ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
								ViewModel.sprRuptureReport.Col = 1;
								ViewModel.sprRuptureReport.Text = "Human Contributing Factors:";
								ViewModel.sprRuptureReport.FontBold = true;
								ViewModel.sprRuptureReport.FontSize = 8;
								(ViewModel.CurrRow)++;
								ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;

								while ( !RuptureReport.RuptureHumanContributingFactor.EOF )
								{
									ViewModel.sprRuptureReport.FontSize = 7;
									ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
									ViewModel.sprRuptureReport.Text = IncidentMain.Clean(RuptureReport.RuptureHumanContributingFactor["human_contrib_factor"]);
									(ViewModel.CurrRow)++;
									RuptureReport.RuptureHumanContributingFactor.MoveNext();
								}
								;
							}
						}
					}
					break;
			}
			//  **** Rupture Narration *****
			ViewModel.PageCountRow = ViewModel.CurrRow;
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
					ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
					ViewModel.sprRuptureReport.Col = 1;
					ViewModel.sprRuptureReport.Text = "Fire Narration";
					ViewModel.sprRuptureReport.FontBold = true;
					ViewModel.sprRuptureReport.FontItalic = true;
					ViewModel.sprRuptureReport.FontSize = 10;
					ViewModel.sprRuptureReport.BlockMode = true;
					ViewModel.sprRuptureReport.Row2 = ViewModel.CurrRow;
					ViewModel.sprRuptureReport.Col2 = 10;
					ViewModel.sprRuptureReport.BackColor = IncidentMain.Shared.LTGRAY;
					ViewModel.sprRuptureReport.BlockMode = false;
					(ViewModel.CurrRow)++;
					(ViewModel.PageCountRow)++;
					ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
					ViewModel.sprRuptureReport.Col = 1;
					ViewModel.sprRuptureReport.Text = "Narration By:";
					ViewModel.sprRuptureReport.FontBold = true;
					ViewModel.sprRuptureReport.FontSize = 8;
					ViewModel.sprRuptureReport.Col = 2;
					ViewModel.sprRuptureReport.FontSize = 7;
					ViewModel.sprRuptureReport.Text = IncidentCL.NarrationBy;
					(ViewModel.CurrRow)++;
					(ViewModel.PageCountRow)++;
					ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
					ViewModel.sprRuptureReport.Col = 1;
					ViewModel.sprRuptureReport.Text = "Last Update Date:";
					ViewModel.sprRuptureReport.FontBold = true;
					ViewModel.sprRuptureReport.FontSize = 8;
					ViewModel.sprRuptureReport.Col = 2;
					ViewModel.sprRuptureReport.FontSize = 7;
					ViewModel.sprRuptureReport.Text = DateTime.Parse(IncidentCL.NarrationLastUpdate).ToString("M/d/yyyy");
					(ViewModel.CurrRow)++;
					(ViewModel.PageCountRow)++;
					ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
					ViewModel.sprRuptureReport.Col = 1;
					ViewModel.sprRuptureReport.Text = "Narration:";
					ViewModel.sprRuptureReport.FontBold = true;
					ViewModel.sprRuptureReport.FontSize = 8;
					ViewModel.sprRuptureReport.Col = 2;
					ViewModel.sprRuptureReport.FontSize = 7;
					(ViewModel.CurrRow)++;
					(ViewModel.PageCountRow)++;
					ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
					sDisplay = IncidentCL.NarrationText;
					if ( Strings.Len(sDisplay) > 0 )
					{
						sDisplay = sDisplay.Substring(0, Math.Min(Strings.Len(sDisplay) - 1, sDisplay.Length));
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
					(ViewModel.LastRow)++;
					ViewModel.sprRuptureReport.BlockMode = true;
					ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
					ViewModel.sprRuptureReport.Row2 = ViewModel.CurrRow + ViewModel.LastRow;
					ViewModel.sprRuptureReport.Col = 2;
					ViewModel.sprRuptureReport.Col2 = 9;
					ViewModel.sprRuptureReport.CellType = FarPoint.ViewModels.Cells.FpCellType.CellTypeStaticText;
					(ViewModel.sprRuptureReport.ActiveSheet.Cells[ViewModel.sprRuptureReport.Row, ViewModel.sprRuptureReport.Col].CellType as FarPoint.ViewModels.TextCellType).WordWrap = true;
					ViewModel.sprRuptureReport.BlockMode = false;
					//UPGRADE_ISSUE: (2064) FPSpread.vaSpread method sprRuptureReport.AddCellSpan was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprRuptureReport.AddCellSpan(2, ViewModel.CurrRow, 8, ViewModel.LastRow);
					ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
					ViewModel.sprRuptureReport.Col = 2;
					ViewModel.sprRuptureReport.Text = sDisplay;
					ViewModel.CurrRow = ViewModel.CurrRow + ViewModel.LastRow + 1;
					ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;

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
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprRuptureReport.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprRuptureReport.setPrintAbortMsg("Printing Rupture/Explosion Report - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprRuptureReport.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprRuptureReport.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprRuptureReport.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprRuptureReport.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpread.PrintOrientationConstants property PrintOrientationConstants.PrintOrientationPortrait was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprRuptureReport.PrintOrientation was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprRuptureReport.setPrintOrientation(UpgradeStubs.FPSpread_PrintOrientationConstants.getPrintOrientationPortrait());
			ViewModel.sprRuptureReport.Action = FarPoint.ViewModels.FPActionConstants.ActionSmartPrint;
		}

		private void DisplayHeadings()
		{
			(ViewModel.CurrRow)++;
			ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprRuptureReport.RowPageBreak was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprRuptureReport.setRowPageBreak(true);
			(ViewModel.CurrRow)++;
			ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
			ViewModel.sprRuptureReport.Col = 7;
			ViewModel.sprRuptureReport.FontSize = 8;
			ViewModel.sprRuptureReport.FontBold = true;
			ViewModel.sprRuptureReport.Text = "Print Date:";
			ViewModel.sprRuptureReport.Col = 9;
			ViewModel.sprRuptureReport.FontSize = 8;
			ViewModel.sprRuptureReport.FontBold = false;
			ViewModel.sprRuptureReport.Text = UpgradeHelpers.Helpers.StringsHelper.Format(DateTime.Now, "m/d/yyyy h:nn AM/PM");
			(ViewModel.CurrRow)++;
			ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
			ViewModel.sprRuptureReport.Col = 7;
			ViewModel.sprRuptureReport.FontSize = 8;
			ViewModel.sprRuptureReport.FontBold = true;
			ViewModel.sprRuptureReport.Text = "Incident Number:";
			ViewModel.sprRuptureReport.Col = 9;
			ViewModel.sprRuptureReport.FontSize = 8;
			ViewModel.sprRuptureReport.FontBold = false;
			ViewModel.sprRuptureReport.Text = ViewModel.IncidentNumber;
			(ViewModel.CurrRow)++;
			ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
			ViewModel.sprRuptureReport.Col = 1;
			ViewModel.sprRuptureReport.Text = "Rupture/Explosion Narration";
			ViewModel.sprRuptureReport.FontSize = 10;
			ViewModel.sprRuptureReport.FontBold = true;
			ViewModel.sprRuptureReport.FontItalic = true;
			ViewModel.sprRuptureReport.BlockMode = true;
			ViewModel.sprRuptureReport.Row2 = ViewModel.CurrRow;
			ViewModel.sprRuptureReport.Col2 = 10;
			ViewModel.sprRuptureReport.BackColor = IncidentMain.Shared.LTGRAY;
			ViewModel.sprRuptureReport.BlockMode = false;
			(ViewModel.CurrRow)++;
			ViewModel.sprRuptureReport.Row = ViewModel.CurrRow;
			ViewModel.sprRuptureReport.Col = 1;
			ViewModel.sprRuptureReport.Text = "Narration:";
			ViewModel.sprRuptureReport.FontBold = true;
			ViewModel.sprRuptureReport.FontSize = 8;
			ViewModel.sprRuptureReport.Col = 2;
			ViewModel.sprRuptureReport.FontSize = 7;
			(ViewModel.CurrRow)++;
			ViewModel.PageCountRow = 4;
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			//Produce Rupture Report Print Preview
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
			//Outside Rupture
			//ReportLog.GetReportLog 108402

			//Structure Rupture
			//    ReportLog.GetReportLog 103639

			//Mobile Rupture
			//ReportLog.GetReportLog 98749

			//*********************************************

			ReportLog.GetReportLog(IncidentMain.Shared.gEditReportID);
			ViewModel.ReportType = ReportLog.ReportType;
			ViewModel.CurrIncident = ReportLog.RLIncidentID;
			ViewModel.RuptureReportID = ReportLog.ReportReferenceID;
			LoadRuptureReport();

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmReportRupture DefInstance
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

		public static frmReportRupture CreateInstance()
		{
			TFDIncident.frmReportRupture theInstance = Shared.Container.Resolve<frmReportRupture>();
			theInstance.Form_Load();
			return theInstance;
		}

		protected override void ExecuteControlsStartup()
		{
			ViewModel.sprRuptureReport.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprRuptureReport.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmReportRupture
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.frmReportRuptureViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmReportRupture m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}