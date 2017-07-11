using Microsoft.VisualBasic;
using System;
using UpgradeHelpers.DB.ADO;
using UpgradeStubs;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident
{

	public partial class frmReportCasualty
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.frmReportCasualtyViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmReportCasualty));
			if ( Shared.m_vb6FormDefInstance == null)
			{
				if ( Shared.m_InitializingDefInstance)
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
		}


		private void frmReportCasualty_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		private void LoadReport()
		{
			//Format Report
			TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();
			TFDIncident.clsUnit UnitCL = Container.Resolve< clsUnit>();
			TFDIncident.clsCommonCodes CommonCodes = Container.Resolve< clsCommonCodes>();
			TFDIncident.clsCasualty CasualtyCL = Container.Resolve< clsCasualty>();
			TFDIncident.clsEMS EMSReport = Container.Resolve< clsEMS>();
			string CurrUnit = "";
			string sDisplay1 = "";
			ViewModel.sprCasualtyReport.Row = 1;
			ViewModel.sprCasualtyReport.Col = 8;
			ViewModel.sprCasualtyReport.Text = UpgradeHelpers.Helpers.StringsHelper.Format(DateTime.Now, "m/d/yyyy h:nn AM/PM");
			switch( ViewModel.ReportType)
			{
				case IncidentMain.FSCASUALTY :
					if (~CasualtyCL.GetFSCasualtyReport(ViewModel.CasualtyID) != 0)
					{
						ViewManager.ShowMessage("Error retrieving Fire Service Casualty Report", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						return;
					}
					break;
				case IncidentMain.CIVILCASUALTY :
					if (~CasualtyCL.GetCivilianCasualtyReport(ViewModel.CasualtyID) != 0)
					{
						ViewManager.ShowMessage("Error Retrieving Civilian Casualty Report", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						return;
					}
					break;
			}
			ViewModel.sprCasualtyReport.Row = 2;
			ViewModel.sprCasualtyReport.Col = 1;
			ViewModel.sprCasualtyReport.Text = ViewModel.CurrReportTitle;
			ViewModel.CurrRow = 5;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
			this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.WaitCursor);

			// ****** Incident Information *****
			if (IncidentCL.GetIncident(ViewModel.CurrIncident) != 0)
			{
				ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
				ViewModel.sprCasualtyReport.Col = 2;
				ViewModel.sprCasualtyReport.Text = IncidentCL.IncidentNumber;
				ViewModel.IncidentNumber = IncidentCL.IncidentNumber;
				(ViewModel.CurrRow)++;
				ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
				ViewModel.sprCasualtyReport.Col = 2;
				ViewModel.sprCasualtyReport.Text = DateTime.Parse(IncidentCL.DateIncidentCreated).ToString("M/d/yyyy   HH:mm");
				(ViewModel.CurrRow)++;
				ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
				ViewModel.sprCasualtyReport.Col = 2;
				ViewModel.sprCasualtyReport.Text = IncidentCL.Location;
				ViewModel.CurrRow = 5;
				//Unit Times
				if (UnitCL.GetUnitResponseTimesReport(ViewModel.CurrIncident) != 0)
				{

					while(!UnitCL.UnitTimes.EOF)
					{
						if (Convert.ToString(UnitCL.UnitTimes["Unit"]) != CurrUnit)
						{
							(ViewModel.CurrRow)++;
							ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
							CurrUnit = Convert.ToString(UnitCL.UnitTimes["Unit"]);
							ViewModel.sprCasualtyReport.Col = 5;
							ViewModel.sprCasualtyReport.Text = IncidentMain.Clean(UnitCL.UnitTimes["unit_name"]);
						}
						switch(Convert.ToInt32(UnitCL.UnitTimes["response_time_code"]))
						{
							case 3 :  //Dispatched 

								ViewModel.sprCasualtyReport.Col = 7;
								ViewModel.sprCasualtyReport.Text = Convert.ToDateTime(UnitCL.UnitTimes["unit_time"]).ToString("HH:mm");
								break;
							case 5 :  //onscene 

								ViewModel.sprCasualtyReport.Col = 8;
								ViewModel.sprCasualtyReport.Text = Convert.ToDateTime(UnitCL.UnitTimes["unit_time"]).ToString("HH:mm");
								break;
							case 8 :  //available 

								ViewModel.sprCasualtyReport.Col = 9;
								ViewModel.sprCasualtyReport.Text = Convert.ToDateTime(UnitCL.UnitTimes["unit_time"]).ToString("HH:mm");
								break;
						}
						UnitCL.UnitTimes.MoveNext();
					};
				}
			}
			//    ' ****** Report Detail Information *****
			ViewModel.sprCasualtyReport.Col = 1;
			switch( ViewModel.ReportType)
			{
				case IncidentMain.CIVILCASUALTY :
					ViewModel.CurrRow += 3;
					ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
					ViewModel.sprCasualtyReport.Text = "Civilian Casualty Detail Information";
					ViewModel.sprCasualtyReport.FontSize = 10;
					ViewModel.sprCasualtyReport.FontBold = true;
					ViewModel.sprCasualtyReport.FontItalic = true;
					ViewModel.sprCasualtyReport.BlockMode = true;
					ViewModel.sprCasualtyReport.Row2 = ViewModel.CurrRow;
					ViewModel.sprCasualtyReport.Col2 = 10;
					ViewModel.sprCasualtyReport.BackColor = IncidentMain.Shared.LTGRAY;
					ViewModel.sprCasualtyReport.BlockMode = false;
					(ViewModel.CurrRow)++;
					ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
					ViewModel.sprCasualtyReport.Col = 1;
					ViewModel.sprCasualtyReport.Text = "Injury Severity:";
					ViewModel.sprCasualtyReport.FontBold = true;
					ViewModel.sprCasualtyReport.FontSize = 8;
					ViewModel.sprCasualtyReport.Col = 3;
					ViewModel.sprCasualtyReport.FontSize = 7;
					ViewModel.sprCasualtyReport.Text = IncidentMain.Clean(CasualtyCL.CivCasualtyRS["injury_severity"]);
					ViewModel.sprCasualtyReport.FontBold = false;
					ViewModel.sprCasualtyReport.Col = 6;
					ViewModel.sprCasualtyReport.Text = "EMS Patient Report Completed:";
					ViewModel.sprCasualtyReport.FontBold = true;
					ViewModel.sprCasualtyReport.FontSize = 8;
					ViewModel.sprCasualtyReport.Col = 7;
					ViewModel.sprCasualtyReport.FontSize = 7;
					//UPGRADE_WARNING: (1068) GetVal(CasualtyCL.CivCasualtyRS(patient_id)) of type Variant is being forced to bool. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx 
					if (Convert.ToBoolean(IncidentMain.GetVal(CasualtyCL.CivCasualtyRS["patient_id"])))
					{
						ViewModel.sprCasualtyReport.Text = "Yes";
						(ViewModel.CurrRow)++;
						ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
						ViewModel.sprCasualtyReport.Col = 6;
						ViewModel.sprCasualtyReport.Text = "EMS Patient:";
						ViewModel.sprCasualtyReport.FontBold = true;
						ViewModel.sprCasualtyReport.FontSize = 8;
						ViewModel.sprCasualtyReport.Col = 7;
						ViewModel.sprCasualtyReport.FontSize = 7;
						if (EMSReport.GetEMSPatient(Convert.ToInt32(CasualtyCL.CivCasualtyRS["patient_id"])) != 0)
						{
							ViewModel.sprCasualtyReport.Text = EMSReport.NameLast + ", " + EMSReport.NameFirst;
						}
						else
						{
							ViewModel.sprCasualtyReport.Text = "Basic EMS Patient Contact Report";
						}
					}
					else
					{
						ViewModel.sprCasualtyReport.Text = "No";
					}
					ViewModel.sprCasualtyReport.FontBold = false;
					(ViewModel.CurrRow)++;
					ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
					ViewModel.sprCasualtyReport.Col = 1;
					ViewModel.sprCasualtyReport.Text = "Injury Caused By:";
					ViewModel.sprCasualtyReport.FontBold = true;
					ViewModel.sprCasualtyReport.FontSize = 8;
					ViewModel.sprCasualtyReport.Col = 3;
					ViewModel.sprCasualtyReport.FontSize = 7;
					ViewModel.sprCasualtyReport.Text = IncidentMain.Clean(CasualtyCL.CivCasualtyRS["caused_by"]);
					(ViewModel.CurrRow)++;
					ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
					ViewModel.sprCasualtyReport.Col = 1;
					ViewModel.sprCasualtyReport.Text = "Injury Floor:";
					ViewModel.sprCasualtyReport.FontBold = true;
					ViewModel.sprCasualtyReport.FontSize = 8;
					ViewModel.sprCasualtyReport.Col = 3;
					ViewModel.sprCasualtyReport.FontSize = 7;
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx 
					ViewModel.sprCasualtyReport.Text = Convert.ToString(IncidentMain.GetVal(CasualtyCL.CivCasualtyRS["injury_floor"]));
					ViewModel.sprCasualtyReport.FontBold = false;
					(ViewModel.CurrRow)++;
					ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
					ViewModel.sprCasualtyReport.Col = 1;
					ViewModel.sprCasualtyReport.Text = "Location at Time of Injury:";
					ViewModel.sprCasualtyReport.FontBold = true;
					ViewModel.sprCasualtyReport.FontSize = 8;
					ViewModel.sprCasualtyReport.Col = 3;
					ViewModel.sprCasualtyReport.FontSize = 7;
					ViewModel.sprCasualtyReport.Text = IncidentMain.Clean(CasualtyCL.CivCasualtyRS["injury_location"]);
					ViewModel.sprCasualtyReport.FontBold = false;
					(ViewModel.CurrRow)++;
					//contributing factors 
					if (CasualtyCL.GetCivContribFactorReport(ViewModel.CasualtyID) != 0)
					{
						(ViewModel.CurrRow)++;
						ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
						ViewModel.sprCasualtyReport.Col = 1;
						ViewModel.sprCasualtyReport.Text = "Contributing Factors:";
						ViewModel.sprCasualtyReport.FontBold = true;
						ViewModel.sprCasualtyReport.FontSize = 8;
						(ViewModel.CurrRow)++;
						ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;

						while(!CasualtyCL.CFCivilContribFactor.EOF)
						{
							ViewModel.sprCasualtyReport.FontSize = 7;
							ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
							ViewModel.sprCasualtyReport.Text = IncidentMain.Clean(CasualtyCL.CFCivilContribFactor["contributing_factor"]);
							(ViewModel.CurrRow)++;
							CasualtyCL.CFCivilContribFactor.MoveNext();
						}
						;
											}
					//human factors 
					if (CasualtyCL.GetCivHumanFactorReport(ViewModel.CasualtyID) != 0)
					{
						(ViewModel.CurrRow)++;
						ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
						ViewModel.sprCasualtyReport.Col = 1;
						ViewModel.sprCasualtyReport.Text = "Human Contributing Factors:";
						ViewModel.sprCasualtyReport.FontBold = true;
						ViewModel.sprCasualtyReport.FontSize = 8;
						(ViewModel.CurrRow)++;
						ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;

						while(!CasualtyCL.CHCivilHumanFactor.EOF)
						{
							ViewModel.sprCasualtyReport.FontSize = 7;
							ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
							ViewModel.sprCasualtyReport.Text = IncidentMain.Clean(CasualtyCL.CHCivilHumanFactor["human_factor"]);
							(ViewModel.CurrRow)++;
							CasualtyCL.CHCivilHumanFactor.MoveNext();
						}
						;
											}

					break;
				case IncidentMain.FSCASUALTY :
					ViewModel.CurrRow += 3;
					ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
					ViewModel.sprCasualtyReport.Text = "Fire Service Casualty Detail Information";
					ViewModel.sprCasualtyReport.FontSize = 10;
					ViewModel.sprCasualtyReport.FontBold = true;
					ViewModel.sprCasualtyReport.FontItalic = true;
					ViewModel.sprCasualtyReport.BlockMode = true;
					ViewModel.sprCasualtyReport.Row2 = ViewModel.CurrRow;
					ViewModel.sprCasualtyReport.Col2 = 10;
					ViewModel.sprCasualtyReport.BackColor = IncidentMain.Shared.LTGRAY;
					ViewModel.sprCasualtyReport.BlockMode = false;
					(ViewModel.CurrRow)++;
					ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
					ViewModel.sprCasualtyReport.Col = 1;
					ViewModel.sprCasualtyReport.Text = "Injuried Employee:";
					ViewModel.sprCasualtyReport.FontBold = true;
					ViewModel.sprCasualtyReport.FontSize = 8;
					ViewModel.sprCasualtyReport.Col = 3;
					ViewModel.sprCasualtyReport.FontSize = 7;
					ViewModel.sprCasualtyReport.Text = IncidentMain.Clean(CasualtyCL.FireServiceCasualty["name_full"]);
					ViewModel.sprCasualtyReport.FontBold = false;
					ViewModel.sprCasualtyReport.Col = 6;
					ViewModel.sprCasualtyReport.Text = "Employee ID:";
					ViewModel.sprCasualtyReport.FontBold = true;
					ViewModel.sprCasualtyReport.FontSize = 8;
					ViewModel.sprCasualtyReport.Col = 7;
					ViewModel.sprCasualtyReport.FontSize = 7;
					ViewModel.sprCasualtyReport.Text = Convert.ToString(CasualtyCL.FireServiceCasualty["emp_id"]);
					ViewModel.sprCasualtyReport.FontBold = false;
					(ViewModel.CurrRow)++;
					ViewModel.SaveRow = ViewModel.CurrRow + 2;
					ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
					ViewModel.sprCasualtyReport.Col = 1;
					ViewModel.sprCasualtyReport.Text = "Activity at Time of Injury:";
					ViewModel.sprCasualtyReport.FontBold = true;
					ViewModel.sprCasualtyReport.FontSize = 8;
					ViewModel.sprCasualtyReport.Col = 3;
					ViewModel.sprCasualtyReport.FontSize = 7;
					ViewModel.sprCasualtyReport.Text = IncidentMain.Clean(CasualtyCL.FireServiceCasualty["activity"]);
					ViewModel.sprCasualtyReport.FontBold = false;
					(ViewModel.CurrRow)++;
					ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
					ViewModel.sprCasualtyReport.Col = 1;
					ViewModel.sprCasualtyReport.Text = "Where Injury Occurred:";
					ViewModel.sprCasualtyReport.FontBold = true;
					ViewModel.sprCasualtyReport.FontSize = 8;
					ViewModel.sprCasualtyReport.Col = 3;
					ViewModel.sprCasualtyReport.FontSize = 7;
					ViewModel.sprCasualtyReport.Text = IncidentMain.Clean(CasualtyCL.FireServiceCasualty["where_occured"]);
					ViewModel.sprCasualtyReport.FontBold = false;
					(ViewModel.CurrRow)++;
					ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
					ViewModel.sprCasualtyReport.Col = 1;
					ViewModel.sprCasualtyReport.Text = "Injury Caused By:";
					ViewModel.sprCasualtyReport.FontBold = true;
					ViewModel.sprCasualtyReport.FontSize = 8;
					ViewModel.sprCasualtyReport.Col = 3;
					ViewModel.sprCasualtyReport.FontSize = 7;
					ViewModel.sprCasualtyReport.Text = IncidentMain.Clean(CasualtyCL.FireServiceCasualty["caused_by"]);
					(ViewModel.CurrRow)++;
					ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
					ViewModel.sprCasualtyReport.Col = 1;
					ViewModel.sprCasualtyReport.Text = "Injury Severity:";
					ViewModel.sprCasualtyReport.FontBold = true;
					ViewModel.sprCasualtyReport.FontSize = 8;
					ViewModel.sprCasualtyReport.Col = 3;
					ViewModel.sprCasualtyReport.FontSize = 7;
					ViewModel.sprCasualtyReport.Text = IncidentMain.Clean(CasualtyCL.FireServiceCasualty["injury_severity"]);
					ViewModel.sprCasualtyReport.FontBold = false;
					(ViewModel.CurrRow)++;
					ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
					ViewModel.sprCasualtyReport.Col = 1;
					ViewModel.sprCasualtyReport.Text = "Body Part Injuried:";
					ViewModel.sprCasualtyReport.FontBold = true;
					ViewModel.sprCasualtyReport.FontSize = 8;
					ViewModel.sprCasualtyReport.Col = 3;
					ViewModel.sprCasualtyReport.FontSize = 7;
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx 
					ViewModel.sprCasualtyReport.Text = Convert.ToString(IncidentMain.GetVal(CasualtyCL.FireServiceCasualty["body_part"]));
					ViewModel.sprCasualtyReport.FontBold = false;
					(ViewModel.CurrRow)++;
					ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
					ViewModel.sprCasualtyReport.Col = 1;
					ViewModel.sprCasualtyReport.Text = "Injury Type:";
					ViewModel.sprCasualtyReport.FontBold = true;
					ViewModel.sprCasualtyReport.FontSize = 8;
					ViewModel.sprCasualtyReport.Col = 3;
					ViewModel.sprCasualtyReport.FontSize = 7;
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx 
					ViewModel.sprCasualtyReport.Text = Convert.ToString(IncidentMain.GetVal(CasualtyCL.FireServiceCasualty["type_of_injury"]));
					ViewModel.sprCasualtyReport.FontBold = false;
					(ViewModel.CurrRow)++;
					ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
					ViewModel.sprCasualtyReport.Col = 1;
					ViewModel.sprCasualtyReport.Text = "Location at Time of Injury:";
					ViewModel.sprCasualtyReport.FontBold = true;
					ViewModel.sprCasualtyReport.FontSize = 8;
					ViewModel.sprCasualtyReport.Col = 3;
					ViewModel.sprCasualtyReport.FontSize = 7;
					ViewModel.sprCasualtyReport.Text = IncidentMain.Clean(CasualtyCL.FireServiceCasualty["injury_location"]);
					ViewModel.sprCasualtyReport.FontBold = false;
					(ViewModel.CurrRow)++;
					ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
					ViewModel.sprCasualtyReport.Col = 1;
					ViewModel.sprCasualtyReport.Text = "PPE Contributing Factor?:";
					ViewModel.sprCasualtyReport.FontBold = true;
					ViewModel.sprCasualtyReport.FontSize = 8;
					ViewModel.sprCasualtyReport.Col = 3;
					ViewModel.sprCasualtyReport.FontSize = 7;
					if (Convert.ToBoolean(CasualtyCL.FireServiceCasualty["flag_prot_equip_caused"]))
					{
						ViewModel.sprCasualtyReport.Text = "Yes";
					}
					else
					{
						ViewModel.sprCasualtyReport.Text = "No";
					}
					ViewModel.sprCasualtyReport.FontBold = false;
					(ViewModel.CurrRow)++;
					//Detail & Recommendation Narratives 
					ViewModel.LastRow = ViewModel.CurrRow;
					ViewModel.CurrRow = ViewModel.SaveRow;
					ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
					ViewModel.sprCasualtyReport.Col = 6;
					if (IncidentMain.Clean(CasualtyCL.FireServiceCasualty["detailed_narrative"]) != "")
					{
						ViewModel.sprCasualtyReport.Text = "Detailed Narrative:";
						ViewModel.sprCasualtyReport.FontBold = true;
						ViewModel.sprCasualtyReport.FontSize = 8;
						(ViewModel.CurrRow)++;
						ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
						ViewModel.sprCasualtyReport.FontSize = 7;
						ViewModel.sprCasualtyReport.FontBold = false;
						sDisplay1 = IncidentMain.Clean(CasualtyCL.FireServiceCasualty["detailed_narrative"]);
						for (int i = 0; i <= Strings.Len(sDisplay1) / 60; i++)
						{
							ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
							ViewModel.sprCasualtyReport.Text = sDisplay1.Substring(60 * i, Math.Min(60, sDisplay1.Length - 60 * i));
							if ( ViewModel.sprCasualtyReport.Text.Substring(Math.Max(ViewModel.sprCasualtyReport.Text.Length - 1, 0)) != " ")
							{
								if ( ViewModel.sprCasualtyReport.Text.Substring(Math.Max(ViewModel.sprCasualtyReport.Text.Length - 1, 0)) != ".")
								{
									ViewModel.sprCasualtyReport.Text = ViewModel.sprCasualtyReport.Text + "-";
								}
							}
							(ViewModel.CurrRow)++;
						}
						(ViewModel.CurrRow)++;
					}
					ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
					ViewModel.sprCasualtyReport.Col = 6;
					if (IncidentMain.Clean(CasualtyCL.FireServiceCasualty["recommendations_for_prevention"]) != "")
					{
						ViewModel.sprCasualtyReport.Text = "Recommendations For Prevention:";
						ViewModel.sprCasualtyReport.FontBold = true;
						ViewModel.sprCasualtyReport.FontSize = 8;
						(ViewModel.CurrRow)++;
						ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
						ViewModel.sprCasualtyReport.FontSize = 7;
						ViewModel.sprCasualtyReport.FontBold = false;
						sDisplay1 = IncidentMain.Clean(CasualtyCL.FireServiceCasualty["recommendations_for_prevention"]);
						for (int i = 0; i <= Strings.Len(sDisplay1) / 60; i++)
						{
							ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
							ViewModel.sprCasualtyReport.Text = sDisplay1.Substring(60 * i, Math.Min(60, sDisplay1.Length - 60 * i));
							if ( ViewModel.sprCasualtyReport.Text.Substring(Math.Max(ViewModel.sprCasualtyReport.Text.Length - 1, 0)) != " ")
							{
								if ( ViewModel.sprCasualtyReport.Text.Substring(Math.Max(ViewModel.sprCasualtyReport.Text.Length - 1, 0)) != ".")
								{
									ViewModel.sprCasualtyReport.Text = ViewModel.sprCasualtyReport.Text + "-";
								}
							}
							(ViewModel.CurrRow)++;
						}
						(ViewModel.CurrRow)++;
					}

					if ( ViewModel.CurrRow < ViewModel.LastRow)
					{
						ViewModel.CurrRow = ViewModel.LastRow;
					}

					//FPE Records 
					if (CasualtyCL.GetFSCasualtyFailedEquipmentReport(ViewModel.CasualtyID) != 0)
					{
						(ViewModel.CurrRow)++;
						ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
						ViewModel.sprCasualtyReport.Col = 1;
						ViewModel.sprCasualtyReport.Text = "PPE Failed Equipment Information:";
						ViewModel.sprCasualtyReport.FontBold = true;
						ViewModel.sprCasualtyReport.FontSize = 8;
						(ViewModel.CurrRow)++;

						while(!CasualtyCL.FSCasualtyFailedEquipment.EOF)
						{
							ViewModel.sprCasualtyReport.Col = 1;
							ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
							ViewModel.sprCasualtyReport.Text = "PPE";
							ViewModel.sprCasualtyReport.FontBold = true;
							ViewModel.sprCasualtyReport.FontSize = 8;
							ViewModel.sprCasualtyReport.Col = 2;
							ViewModel.sprCasualtyReport.Text = IncidentMain.Clean(CasualtyCL.FSCasualtyFailedEquipment["fpe_desc"]);
							(ViewModel.CurrRow)++;
							ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
							ViewModel.sprCasualtyReport.Col = 1;
							ViewModel.sprCasualtyReport.Text = "Status";
							ViewModel.sprCasualtyReport.FontBold = true;
							ViewModel.sprCasualtyReport.FontSize = 8;
							ViewModel.sprCasualtyReport.Col = 2;
							ViewModel.sprCasualtyReport.Text = IncidentMain.Clean(CasualtyCL.FSCasualtyFailedEquipment["fpe_status_desc"]);
							(ViewModel.CurrRow)++;
							ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
							ViewModel.sprCasualtyReport.Col = 1;
							ViewModel.sprCasualtyReport.Text = "Problem";
							ViewModel.sprCasualtyReport.FontBold = true;
							ViewModel.sprCasualtyReport.FontSize = 8;
							ViewModel.sprCasualtyReport.Col = 2;
							ViewModel.sprCasualtyReport.Text = IncidentMain.Clean(CasualtyCL.FSCasualtyFailedEquipment["fpe_problem"]);
							ViewModel.CurrRow += 2;
							//Currently not collecting Manufacture Info - left in just in case
							//                    sprCasualtyReport.Row = CurrRow
							//                    sprCasualtyReport.Col = 1
							//                    sprCasualtyReport.Text = "Manufacturer:"
							//                    sprCasualtyReport.FontBold = True
							//                    sprCasualtyReport.FontSize = 8
							//                    sprCasualtyReport.Col = 3
							//                    sprCasualtyReport.Text = Clean(CasualtyCL.FSCasualtyFailedEquipment("manufacturer"])
							//                    sprCasualtyReport.Col = 5
							//                    sprCasualtyReport.Text = "Model:"
							//                    sprCasualtyReport.FontBold = True
							//                    sprCasualtyReport.FontSize = 8
							//                    sprCasualtyReport.Col = 6
							//                    sprCasualtyReport.Text = Clean(CasualtyCL.FSCasualtyFailedEquipment("model"])
							//                    sprCasualtyReport.Col = 8
							//                    sprCasualtyReport.Text = "Serial Number"
							//                    sprCasualtyReport.FontBold = True
							//                    sprCasualtyReport.FontSize = 8
							//                    sprCasualtyReport.Col = 9
							//                    sprCasualtyReport.Text = Clean(CasualtyCL.FSCasualtyFailedEquipment("serial_number"])
							//                    CurrRow = CurrRow + 2
							CasualtyCL.FSCasualtyFailedEquipment.MoveNext();
						}
						;
											}


					//Contributing Factors 
					if (CasualtyCL.GetFSContribFactorReport(ViewModel.CasualtyID) != 0)
					{
						(ViewModel.CurrRow)++;
						ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
						ViewModel.sprCasualtyReport.Col = 1;
						ViewModel.sprCasualtyReport.Text = "Contributing Factors:";
						ViewModel.sprCasualtyReport.FontBold = true;
						ViewModel.sprCasualtyReport.FontSize = 8;
						(ViewModel.CurrRow)++;
						ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;

						while(!CasualtyCL.FSCasualtyContributingFactorRS.EOF)
						{
							ViewModel.sprCasualtyReport.FontSize = 7;
							ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
							ViewModel.sprCasualtyReport.Text = IncidentMain.Clean(CasualtyCL.FSCasualtyContributingFactorRS["contributing_factor"]);
							(ViewModel.CurrRow)++;
							CasualtyCL.FSCasualtyContributingFactorRS.MoveNext();
						}
						;
											}

					break;
			}
			//'  **** Report Narration *****
			sDisplay1 = "";
			if (IncidentCL.NarrationListRS(ViewModel.CurrIncident, ViewModel.ReportType) != 0)
			{

				while(!IncidentCL.IncidentNarration.EOF)
				{
					IncidentCL.GetNarration(Convert.ToInt32(IncidentCL.IncidentNarration["narration_id"]));
					ViewModel.CurrRow += 2;
					ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
					ViewModel.sprCasualtyReport.Col = 1;
					ViewModel.sprCasualtyReport.Text = "Report Narration";
					ViewModel.sprCasualtyReport.FontBold = true;
					ViewModel.sprCasualtyReport.FontItalic = true;
					ViewModel.sprCasualtyReport.FontSize = 10;
					ViewModel.sprCasualtyReport.BlockMode = true;
					ViewModel.sprCasualtyReport.Row2 = ViewModel.CurrRow;
					ViewModel.sprCasualtyReport.Col2 = 10;
					ViewModel.sprCasualtyReport.BackColor = IncidentMain.Shared.LTGRAY;
					ViewModel.sprCasualtyReport.BlockMode = false;
					(ViewModel.CurrRow)++;
					ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
					ViewModel.sprCasualtyReport.Col = 1;
					ViewModel.sprCasualtyReport.Text = "Narration By:";
					ViewModel.sprCasualtyReport.FontBold = true;
					ViewModel.sprCasualtyReport.FontSize = 8;
					ViewModel.sprCasualtyReport.Col = 2;
					ViewModel.sprCasualtyReport.FontSize = 7;
					ViewModel.sprCasualtyReport.Text = IncidentCL.NarrationBy;
					(ViewModel.CurrRow)++;
					ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
					ViewModel.sprCasualtyReport.Col = 1;
					ViewModel.sprCasualtyReport.Text = "Last Update Date:";
					ViewModel.sprCasualtyReport.FontBold = true;
					ViewModel.sprCasualtyReport.FontSize = 8;
					ViewModel.sprCasualtyReport.Col = 2;
					ViewModel.sprCasualtyReport.FontSize = 7;
					ViewModel.sprCasualtyReport.Text = DateTime.Parse(IncidentCL.NarrationLastUpdate).ToString("M/d/yyyy");
					(ViewModel.CurrRow)++;
					ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
					ViewModel.sprCasualtyReport.Col = 1;
					ViewModel.sprCasualtyReport.Text = "Narration:";
					ViewModel.sprCasualtyReport.FontBold = true;
					ViewModel.sprCasualtyReport.FontSize = 8;
					ViewModel.sprCasualtyReport.Col = 2;
					ViewModel.sprCasualtyReport.FontSize = 7;
					(ViewModel.CurrRow)++;
					ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
					sDisplay1 = IncidentCL.NarrationText;
					for (int i = 0; i <= Strings.Len(sDisplay1) / 80; i++)
					{
						ViewModel.sprCasualtyReport.Row = ViewModel.CurrRow;
						ViewModel.sprCasualtyReport.Text = sDisplay1.Substring(80 * i, Math.Min(80, sDisplay1.Length - 80 * i));
						if ( ViewModel.sprCasualtyReport.Text.Substring(Math.Max(ViewModel.sprCasualtyReport.Text.Length - 1, 0)) != " ")
						{
							if ( ViewModel.sprCasualtyReport.Text.Substring(Math.Max(ViewModel.sprCasualtyReport.Text.Length - 1, 0)) != ".")
							{
								ViewModel.sprCasualtyReport.Text = ViewModel.sprCasualtyReport.Text + "-";
							}
						}
						(ViewModel.CurrRow)++;
					}
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
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprCasualtyReport.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprCasualtyReport.setPrintAbortMsg("Printing Report - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprCasualtyReport.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprCasualtyReport.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprCasualtyReport.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprCasualtyReport.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpread.PrintOrientationConstants property PrintOrientationConstants.PrintOrientationPortrait was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprCasualtyReport.PrintOrientation was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprCasualtyReport.setPrintOrientation(UpgradeStubs.FPSpread_PrintOrientationConstants.getPrintOrientationPortrait());
			ViewModel.sprCasualtyReport.Action = FarPoint.ViewModels.FPActionConstants.ActionSmartPrint;
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			//Produce Fire Service Casualty or Civilian Casualty Report.
			//Using global gEditReportID parameter
			//************************
			//** Database Connections for testing
			//************************
			//    oIncident.Open "Provider=SQLOLEDB; Data Source=TFDSQL3; Initial Catalog=Incident; Integrated Security=SSPI"
			//    oPTSdata.Open "Provider=SQLOLEDB; Data Source=TFDSQL3; Initial Catalog=PTSdata; Integrated Security=SSPI"
			TFDIncident.clsReportLog ReportLog = Container.Resolve< clsReportLog>();

			//**********************************************
			//** Hardcoded report id's for testing
			//****************************
			//Fire Service Casualty
			//    ReportLog.GetReportLog 109916

			//Civilian Casualty
			//    ReportLog.GetReportLog 109937

			//*********************************************

			ReportLog.GetReportLog(IncidentMain.Shared.gEditReportID);
			ViewModel.ReportType = ReportLog.ReportType;
			ViewModel.CurrIncident = ReportLog.RLIncidentID;
			ViewModel.CasualtyID = ReportLog.ReportReferenceID;

			switch( ViewModel.ReportType)
			{
				case IncidentMain.FSCASUALTY :
					ViewModel.CurrReportTitle = "Fire Service Casualty Report";
					break;
				case IncidentMain.CIVILCASUALTY :
					ViewModel.CurrReportTitle = "Civilian Casualty Report";
					break;
			}
			ViewModel.lbTitle.Text = ViewModel.CurrReportTitle + " - Print Preview";
			LoadReport();

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmReportCasualty DefInstance
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

		public static frmReportCasualty CreateInstance()
		{
			TFDIncident.frmReportCasualty theInstance = Shared.Container.Resolve< frmReportCasualty>();
			theInstance.Form_Load();
			return theInstance;
		}

		protected override void ExecuteControlsStartup()
		{
			ViewModel.sprCasualtyReport.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprCasualtyReport.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmReportCasualty
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.frmReportCasualtyViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmReportCasualty m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}