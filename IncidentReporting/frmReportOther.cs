using Microsoft.VisualBasic;
using System;
using UpgradeHelpers.DB.ADO;
using UpgradeStubs;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident
{

	public partial class frmReportOther
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.frmReportOtherViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmReportOther));
			if ( Shared.m_vb6FormDefInstance == null )
			{
				if ( Shared.m_InitializingDefInstance )
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
		}


		private void frmReportOther_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender )
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>)eventSender;
			}
		}

		private void LoadReport()
		{
			//Format Report
			TFDIncident.clsIncident IncidentCL = Container.Resolve<clsIncident>();
			TFDIncident.clsUnit UnitCL = Container.Resolve<clsUnit>();
			TFDIncident.clsCommonCodes CommonCodes = Container.Resolve<clsCommonCodes>();
			TFDIncident.clsMiscReports MiscRept = Container.Resolve<clsMiscReports>();
			int x = 0;
			string CurrUnit = "";
			string sDisplay1 = "";
			ViewModel.sprOtherReport.Row = 1;
			ViewModel.sprOtherReport.Col = 8;
			ViewModel.sprOtherReport.Text = UpgradeHelpers.Helpers.StringsHelper.Format(DateTime.Now, "m/d/yyyy h:nn AM/PM");
			switch ( ViewModel.ReportType )
			{
				case IncidentMain.HAZCONDITION:
					if ( ~MiscRept.GetHazardousConditionReport(ViewModel.CurrIncident) != 0 )
					{
						ViewManager.ShowMessage("Error retrieving Hazardous Condition Report", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						return ;
					}
					break;
				case IncidentMain.SEARCHRESCUE:
					if ( ~MiscRept.GetSearchRescueReport(ViewModel.CurrIncident) != 0 )
					{
						ViewManager.ShowMessage("Error retrieving Search/Rescue Report", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						return ;
					}
					break;
				case IncidentMain.FALSEALARM:
					if ( ~MiscRept.GetFalseAlarmReport(ViewModel.CurrIncident) != 0 )
					{
						ViewManager.ShowMessage("Error retrieving False Alarm Report", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						return ;
					}
					break;
				case IncidentMain.INVESTIGATION : case IncidentMain.CLEANUP : case IncidentMain.STANDBY :
					if ( ~MiscRept.GetServiceReportReport(ViewModel.CurrIncident) != 0 )
					{
						ViewManager.ShowMessage("Error Retrieving " + ViewModel.CurrReportTitle, "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						return ;
					}
					break;
			}
			ViewModel.sprOtherReport.Row = 2;
			ViewModel.sprOtherReport.Col = 1;
			ViewModel.sprOtherReport.Text = ViewModel.CurrReportTitle;
			ViewModel.CurrRow = 5;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
			this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.WaitCursor);

			// ****** Incident Information *****
			if ( IncidentCL.GetIncident(ViewModel.CurrIncident) != 0 )
			{
				ViewModel.sprOtherReport.Row = ViewModel.CurrRow;
				ViewModel.sprOtherReport.Col = 2;
				ViewModel.sprOtherReport.Text = IncidentCL.IncidentNumber;
				ViewModel.IncidentNumber = IncidentCL.IncidentNumber;
				(ViewModel.CurrRow)++;
				ViewModel.sprOtherReport.Row = ViewModel.CurrRow;
				ViewModel.sprOtherReport.Col = 2;
				ViewModel.sprOtherReport.Text = DateTime.Parse(IncidentCL.DateIncidentCreated).ToString("M/d/yyyy   HH:mm");
				(ViewModel.CurrRow)++;
				ViewModel.sprOtherReport.Row = ViewModel.CurrRow;
				ViewModel.sprOtherReport.Col = 2;
				ViewModel.sprOtherReport.Text = IncidentCL.Location;
				ViewModel.CurrRow = 5;
				//Unit Times
				if ( UnitCL.GetUnitResponseTimesReport(ViewModel.CurrIncident) != 0 )
				{

					while ( !UnitCL.UnitTimes.EOF )
					{
						if ( Convert.ToString(UnitCL.UnitTimes["Unit"]) != CurrUnit )
						{
							(ViewModel.CurrRow)++;
							ViewModel.sprOtherReport.Row = ViewModel.CurrRow;
							CurrUnit = Convert.ToString(UnitCL.UnitTimes["Unit"]);
							ViewModel.sprOtherReport.Col = 5;
							ViewModel.sprOtherReport.Text = IncidentMain.Clean(UnitCL.UnitTimes["unit_name"]);
						}
						switch ( Convert.ToInt32(UnitCL.UnitTimes["response_time_code"]) )
						{
							case 3: //Dispatched 

								ViewModel.sprOtherReport.Col = 7;
								ViewModel.sprOtherReport.Text = Convert.ToDateTime(UnitCL.UnitTimes["unit_time"]).ToString("HH:mm");
								break;
							case 5: //onscene 

								ViewModel.sprOtherReport.Col = 8;
								ViewModel.sprOtherReport.Text = Convert.ToDateTime(UnitCL.UnitTimes["unit_time"]).ToString("HH:mm");
								break;
							case 8: //available 

								ViewModel.sprOtherReport.Col = 9;
								ViewModel.sprOtherReport.Text = Convert.ToDateTime(UnitCL.UnitTimes["unit_time"]).ToString("HH:mm");
								break;
						}
						UnitCL.UnitTimes.MoveNext();
					};
					}
				}
			//    ' ****** Report Detail Information *****
			ViewModel.sprOtherReport.Col = 1;
			switch ( ViewModel.ReportType )
			{
				case IncidentMain.HAZCONDITION:
					ViewModel.CurrRow += 3;
					ViewModel.sprOtherReport.Row = ViewModel.CurrRow;
					ViewModel.sprOtherReport.Text = "Hazardous Condition Detail Information";
					ViewModel.sprOtherReport.FontSize = 10;
					ViewModel.sprOtherReport.FontBold = true;
					ViewModel.sprOtherReport.FontItalic = true;
					ViewModel.sprOtherReport.BlockMode = true;
					ViewModel.sprOtherReport.Row2 = ViewModel.CurrRow;
					ViewModel.sprOtherReport.Col2 = 10;
					ViewModel.sprOtherReport.BackColor = IncidentMain.Shared.LTGRAY;
					ViewModel.sprOtherReport.BlockMode = false;
					(ViewModel.CurrRow)++;
					ViewModel.sprOtherReport.Row = ViewModel.CurrRow;
					ViewModel.sprOtherReport.Text = "Hazardous Condition Type:";
					ViewModel.sprOtherReport.FontBold = true;
					ViewModel.sprOtherReport.FontSize = 8;
					ViewModel.sprOtherReport.Col = 3;
					ViewModel.sprOtherReport.FontSize = 7;
					ViewModel.sprOtherReport.Text = IncidentMain.Clean(MiscRept.HazardousCondition["Haz_Type"]);
					ViewModel.sprOtherReport.FontBold = false;
					(ViewModel.CurrRow)++;
					ViewModel.sprOtherReport.Row = ViewModel.CurrRow;
					ViewModel.sprOtherReport.Col = 1;
					ViewModel.sprOtherReport.Text = "General Property Use:";
					ViewModel.sprOtherReport.FontBold = true;
					ViewModel.sprOtherReport.FontSize = 8;
					ViewModel.sprOtherReport.Col = 3;
					ViewModel.sprOtherReport.FontSize = 7;
					ViewModel.sprOtherReport.Text = IncidentMain.Clean(MiscRept.HazardousCondition["Prop_Type"]);
					(ViewModel.CurrRow)++;
					break;
				case IncidentMain.SEARCHRESCUE:
					ViewModel.CurrRow += 2;
					ViewModel.sprOtherReport.Row = ViewModel.CurrRow;
					ViewModel.sprOtherReport.Text = "Search and/or Rescue Detail Information";
					ViewModel.sprOtherReport.FontSize = 10;
					ViewModel.sprOtherReport.FontBold = true;
					ViewModel.sprOtherReport.FontItalic = true;
					ViewModel.sprOtherReport.BlockMode = true;
					ViewModel.sprOtherReport.Row2 = ViewModel.CurrRow;
					ViewModel.sprOtherReport.Col2 = 10;
					ViewModel.sprOtherReport.BackColor = IncidentMain.Shared.LTGRAY;
					ViewModel.sprOtherReport.BlockMode = false;
					(ViewModel.CurrRow)++;
					ViewModel.sprOtherReport.Row = ViewModel.CurrRow;
					ViewModel.sprOtherReport.Text = "Search/Rescue Type:";
					ViewModel.sprOtherReport.FontBold = true;
					ViewModel.sprOtherReport.FontSize = 8;
					ViewModel.sprOtherReport.Col = 3;
					ViewModel.sprOtherReport.FontSize = 7;
					ViewModel.sprOtherReport.Text = IncidentMain.Clean(MiscRept.SearchOrRescue["Rescue_Type"]);
					ViewModel.sprOtherReport.FontBold = false;
					(ViewModel.CurrRow)++;
					ViewModel.sprOtherReport.Row = ViewModel.CurrRow;
					ViewModel.sprOtherReport.Col = 1;
					ViewModel.sprOtherReport.Text = "Number Rescued:";
					ViewModel.sprOtherReport.FontBold = true;
					ViewModel.sprOtherReport.FontSize = 8;
					ViewModel.sprOtherReport.Col = 3;
					ViewModel.sprOtherReport.FontSize = 7;
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx 
					ViewModel.sprOtherReport.Text = Convert.ToString(IncidentMain.GetVal(MiscRept.SearchOrRescue["number_rescued"]));
					(ViewModel.CurrRow)++;
					break;
				case IncidentMain.FALSEALARM:
					ViewModel.CurrRow += 2;
					ViewModel.sprOtherReport.Row = ViewModel.CurrRow;
					ViewModel.sprOtherReport.Text = "False Alarm Detail Information";
					ViewModel.sprOtherReport.FontSize = 10;
					ViewModel.sprOtherReport.FontBold = true;
					ViewModel.sprOtherReport.FontItalic = true;
					ViewModel.sprOtherReport.BlockMode = true;
					ViewModel.sprOtherReport.Row2 = ViewModel.CurrRow;
					ViewModel.sprOtherReport.Col2 = 10;
					ViewModel.sprOtherReport.BackColor = IncidentMain.Shared.LTGRAY;
					ViewModel.sprOtherReport.BlockMode = false;
					(ViewModel.CurrRow)++;
					ViewModel.sprOtherReport.Row = ViewModel.CurrRow;
					ViewModel.sprOtherReport.Text = "False Alarm Type:";
					ViewModel.sprOtherReport.FontBold = true;
					ViewModel.sprOtherReport.FontSize = 8;
					ViewModel.sprOtherReport.Col = 3;
					ViewModel.sprOtherReport.FontSize = 7;
					ViewModel.sprOtherReport.Text = IncidentMain.Clean(MiscRept.FalseAlarmRS["FalseAlarm_Type"]);
					ViewModel.sprOtherReport.FontBold = false;
					(ViewModel.CurrRow)++;
					ViewModel.sprOtherReport.Row = ViewModel.CurrRow;
					ViewModel.sprOtherReport.Col = 1;
					ViewModel.sprOtherReport.Text = "Alarm Sent By:";
					ViewModel.sprOtherReport.FontBold = true;
					ViewModel.sprOtherReport.FontSize = 8;
					ViewModel.sprOtherReport.Col = 3;
					ViewModel.sprOtherReport.FontSize = 7;
					ViewModel.sprOtherReport.Text = IncidentMain.Clean(MiscRept.FalseAlarmRS["alarm_sent_by"]);
					ViewModel.sprOtherReport.FontBold = false;
					(ViewModel.CurrRow)++;
					ViewModel.sprOtherReport.Row = ViewModel.CurrRow;
					ViewModel.sprOtherReport.Col = 1;
					ViewModel.sprOtherReport.Text = "Device Initiating False Alarm:";
					ViewModel.sprOtherReport.FontBold = true;
					ViewModel.sprOtherReport.FontSize = 8;
					ViewModel.sprOtherReport.Col = 3;
					ViewModel.sprOtherReport.FontSize = 7;
					ViewModel.sprOtherReport.Text = IncidentMain.Clean(MiscRept.FalseAlarmRS["Malf_Device"]);
					ViewModel.sprOtherReport.FontBold = false;
					(ViewModel.CurrRow)++;
					ViewModel.sprOtherReport.Row = ViewModel.CurrRow;
					ViewModel.sprOtherReport.Col = 1;
					ViewModel.sprOtherReport.Text = "False Alarm Comment:";
					ViewModel.sprOtherReport.FontBold = true;
					ViewModel.sprOtherReport.FontSize = 8;
					ViewModel.sprOtherReport.Col = 3;
					ViewModel.sprOtherReport.FontSize = 7;
					sDisplay1 = IncidentMain.Clean(MiscRept.FalseAlarmRS["false_alarm_comment"]);
					if ( sDisplay1 != "" )
					{
						sDisplay1 = sDisplay1.Substring(0, Math.Min(Strings.Len(sDisplay1) - 1, sDisplay1.Length));
						for ( int i = 0; i <= Strings.Len(sDisplay1) / 80; i++ )
						{
							ViewModel.sprOtherReport.Row = ViewModel.CurrRow;
							ViewModel.sprOtherReport.Text = sDisplay1.Substring(80 * i, Math.Min(80, sDisplay1.Length - 80 * i));
							if ( ViewModel.sprOtherReport.Text.Substring(Math.Max(ViewModel.sprOtherReport.Text.Length - 1, 0)) != " " )
							{
								if ( ViewModel.sprOtherReport.Text.Substring(Math.Max(ViewModel.sprOtherReport.Text.Length - 1, 0)) != "." )
								{
									ViewModel.sprOtherReport.Text = ViewModel.sprOtherReport.Text + "-";
								}
							}
							(ViewModel.CurrRow)++;
						}
					}
					break;
				case IncidentMain.INVESTIGATION:
					ViewModel.CurrRow += 2;
					ViewModel.sprOtherReport.Row = ViewModel.CurrRow;
					ViewModel.sprOtherReport.Text = "Investigate Only Detail Information";
					ViewModel.sprOtherReport.FontSize = 10;
					ViewModel.sprOtherReport.FontBold = true;
					ViewModel.sprOtherReport.FontItalic = true;
					ViewModel.sprOtherReport.BlockMode = true;
					ViewModel.sprOtherReport.Row2 = ViewModel.CurrRow;
					ViewModel.sprOtherReport.Col2 = 10;
					ViewModel.sprOtherReport.BackColor = IncidentMain.Shared.LTGRAY;
					ViewModel.sprOtherReport.BlockMode = false;
					(ViewModel.CurrRow)++;
					ViewModel.sprOtherReport.Row = ViewModel.CurrRow;
					ViewModel.sprOtherReport.Text = "Investigation Type:";
					ViewModel.sprOtherReport.FontBold = true;
					ViewModel.sprOtherReport.FontSize = 8;
					ViewModel.sprOtherReport.Col = 3;
					ViewModel.sprOtherReport.FontSize = 7;
					ViewModel.sprOtherReport.Text = IncidentMain.Clean(MiscRept.ServiceReport["Service_Type"]);
					ViewModel.sprOtherReport.FontBold = false;
					(ViewModel.CurrRow)++;
					break;
				case IncidentMain.CLEANUP:
					ViewModel.CurrRow += 2;
					ViewModel.sprOtherReport.Row = ViewModel.CurrRow;
					ViewModel.sprOtherReport.Text = "Clean Up Only Detail Information";
					ViewModel.sprOtherReport.FontSize = 10;
					ViewModel.sprOtherReport.FontBold = true;
					ViewModel.sprOtherReport.FontItalic = true;
					ViewModel.sprOtherReport.BlockMode = true;
					ViewModel.sprOtherReport.Row2 = ViewModel.CurrRow;
					ViewModel.sprOtherReport.Col2 = 10;
					ViewModel.sprOtherReport.BackColor = IncidentMain.Shared.LTGRAY;
					ViewModel.sprOtherReport.BlockMode = false;
					(ViewModel.CurrRow)++;
					ViewModel.sprOtherReport.Row = ViewModel.CurrRow;
					ViewModel.sprOtherReport.Text = "Clean Up Type:";
					ViewModel.sprOtherReport.FontBold = true;
					ViewModel.sprOtherReport.FontSize = 8;
					ViewModel.sprOtherReport.Col = 3;
					ViewModel.sprOtherReport.FontSize = 7;
					ViewModel.sprOtherReport.Text = IncidentMain.Clean(MiscRept.ServiceReport["Service_Type"]);
					ViewModel.sprOtherReport.FontBold = false;
					(ViewModel.CurrRow)++;
					break;
				case IncidentMain.STANDBY:
					ViewModel.CurrRow += 2;
					ViewModel.sprOtherReport.Row = ViewModel.CurrRow;
					ViewModel.sprOtherReport.Text = "Standby/Staging Detail Information";
					ViewModel.sprOtherReport.FontSize = 10;
					ViewModel.sprOtherReport.FontBold = true;
					ViewModel.sprOtherReport.FontItalic = true;
					ViewModel.sprOtherReport.BlockMode = true;
					ViewModel.sprOtherReport.Row2 = ViewModel.CurrRow;
					ViewModel.sprOtherReport.Col2 = 10;
					ViewModel.sprOtherReport.BackColor = IncidentMain.Shared.LTGRAY;
					ViewModel.sprOtherReport.BlockMode = false;
					(ViewModel.CurrRow)++;
					ViewModel.sprOtherReport.Row = ViewModel.CurrRow;
					ViewModel.sprOtherReport.Text = "Standby Type:";
					ViewModel.sprOtherReport.FontBold = true;
					ViewModel.sprOtherReport.FontSize = 8;
					ViewModel.sprOtherReport.Col = 3;
					ViewModel.sprOtherReport.FontSize = 7;
					ViewModel.sprOtherReport.Text = IncidentMain.Clean(MiscRept.ServiceReport["Service_Type"]);
					ViewModel.sprOtherReport.FontBold = false;
					(ViewModel.CurrRow)++;
					ViewModel.sprOtherReport.Row = ViewModel.CurrRow;
					ViewModel.sprOtherReport.Col = 1;
					ViewModel.sprOtherReport.Text = "Standby Hours:";
					ViewModel.sprOtherReport.FontBold = true;
					ViewModel.sprOtherReport.FontSize = 8;
					ViewModel.sprOtherReport.Col = 3;
					ViewModel.sprOtherReport.FontSize = 7;
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx 
					ViewModel.sprOtherReport.Text = Convert.ToString(IncidentMain.GetVal(MiscRept.ServiceReport["standby_hours"]));
					ViewModel.sprOtherReport.FontBold = false;
					(ViewModel.CurrRow)++;
					//UPGRADE_WARNING: (1068) GetVal(MiscRept.ServiceReport(number_safe_place_juveniles)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx 
					if ( Convert.ToDouble(IncidentMain.GetVal(MiscRept.ServiceReport["number_safe_place_juveniles"])) > 0 )
					{
						ViewModel.sprOtherReport.Row = ViewModel.CurrRow;
						ViewModel.sprOtherReport.Col = 1;
						ViewModel.sprOtherReport.Text = "Number-Safe Place Juveniles:";
						ViewModel.sprOtherReport.FontBold = true;
						ViewModel.sprOtherReport.FontSize = 8;
						ViewModel.sprOtherReport.Col = 3;
						ViewModel.sprOtherReport.FontSize = 7;
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprOtherReport.Text = Convert.ToString(IncidentMain.GetVal(MiscRept.ServiceReport["number_safe_place_juveniles"]));
					}
					(ViewModel.CurrRow)++;
					break;
			}
			//'  **** Report Narration *****
			sDisplay1 = "";
			if ( IncidentCL.NarrationListRS(ViewModel.CurrIncident, ViewModel.ReportType) != 0 )
			{

				while ( !IncidentCL.IncidentNarration.EOF )
				{
					IncidentCL.GetNarration(Convert.ToInt32(IncidentCL.IncidentNarration["narration_id"]));
					ViewModel.CurrRow += 2;
					ViewModel.sprOtherReport.Row = ViewModel.CurrRow;
					ViewModel.sprOtherReport.Col = 1;
					ViewModel.sprOtherReport.Text = "Report Narration";
					ViewModel.sprOtherReport.FontBold = true;
					ViewModel.sprOtherReport.FontItalic = true;
					ViewModel.sprOtherReport.FontSize = 10;
					ViewModel.sprOtherReport.BlockMode = true;
					ViewModel.sprOtherReport.Row2 = ViewModel.CurrRow;
					ViewModel.sprOtherReport.Col2 = 10;
					ViewModel.sprOtherReport.BackColor = IncidentMain.Shared.LTGRAY;
					ViewModel.sprOtherReport.BlockMode = false;
					(ViewModel.CurrRow)++;
					ViewModel.sprOtherReport.Row = ViewModel.CurrRow;
					ViewModel.sprOtherReport.Col = 1;
					ViewModel.sprOtherReport.Text = "Narration By:";
					ViewModel.sprOtherReport.FontBold = true;
					ViewModel.sprOtherReport.FontSize = 8;
					ViewModel.sprOtherReport.Col = 2;
					ViewModel.sprOtherReport.FontSize = 7;
					ViewModel.sprOtherReport.Text = IncidentCL.NarrationBy;
					(ViewModel.CurrRow)++;
					ViewModel.sprOtherReport.Row = ViewModel.CurrRow;
					ViewModel.sprOtherReport.Col = 1;
					ViewModel.sprOtherReport.Text = "Last Update Date:";
					ViewModel.sprOtherReport.FontBold = true;
					ViewModel.sprOtherReport.FontSize = 8;
					ViewModel.sprOtherReport.Col = 2;
					ViewModel.sprOtherReport.FontSize = 7;
					ViewModel.sprOtherReport.Text = DateTime.Parse(IncidentCL.NarrationLastUpdate).ToString("M/d/yyyy");
					(ViewModel.CurrRow)++;
					ViewModel.sprOtherReport.Row = ViewModel.CurrRow;
					ViewModel.sprOtherReport.Col = 1;
					ViewModel.sprOtherReport.Text = "Narration:";
					ViewModel.sprOtherReport.FontBold = true;
					ViewModel.sprOtherReport.FontSize = 8;
					ViewModel.sprOtherReport.Col = 2;
					ViewModel.sprOtherReport.FontSize = 7;
					(ViewModel.CurrRow)++;
					ViewModel.sprOtherReport.Row = ViewModel.CurrRow;
					sDisplay1 = IncidentCL.NarrationText;
					sDisplay1 = sDisplay1.Substring(0, Math.Min(Strings.Len(sDisplay1) - 1, sDisplay1.Length));
					ViewModel.LastRow = Strings.Len(sDisplay1) / 100;
					//Count line breaks to make sure cell span will be big enough
					x = 1;
					for ( int i = 1; i <= Strings.Len(sDisplay1); i++ )
					{
						if ( Strings.Asc(sDisplay1.Substring(i - 1, Math.Min(1, sDisplay1.Length - (i - 1)))[0]) == 13 )
						{
							x++;
							i++;
						}
						else if ( Strings.Asc(sDisplay1.Substring(i - 1, Math.Min(1, sDisplay1.Length - (i - 1)))[0]) == 10 )
						{
							x++;
						}
					}
					if ( x > ViewModel.LastRow )
					{
						ViewModel.LastRow = x;
					}
					(ViewModel.LastRow)++;
					ViewModel.sprOtherReport.BlockMode = true;
					ViewModel.sprOtherReport.Row = ViewModel.CurrRow;
					ViewModel.sprOtherReport.Row2 = ViewModel.CurrRow + ViewModel.LastRow;
					ViewModel.sprOtherReport.Col = 2;
					ViewModel.sprOtherReport.Col2 = 9;
					ViewModel.sprOtherReport.CellType = FarPoint.ViewModels.Cells.FpCellType.CellTypeStaticText;
					(ViewModel.sprOtherReport.ActiveSheet.Cells[ViewModel.sprOtherReport.Row, ViewModel.sprOtherReport.Col].CellType as FarPoint.ViewModels.TextCellType).WordWrap = true;
					ViewModel.sprOtherReport.BlockMode = false;
					//UPGRADE_ISSUE: (2064) FPSpread.vaSpread method sprOtherReport.AddCellSpan was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprOtherReport.AddCellSpan(2, ViewModel.CurrRow, 8, ViewModel.LastRow);
					ViewModel.sprOtherReport.Row = ViewModel.CurrRow;
					ViewModel.sprOtherReport.Col = 2;
					ViewModel.sprOtherReport.Text = sDisplay1;
					ViewModel.CurrRow = ViewModel.CurrRow + ViewModel.LastRow + 1;
					ViewModel.sprOtherReport.Row = ViewModel.CurrRow;
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
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprOtherReport.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprOtherReport.setPrintAbortMsg("Printing Report - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprOtherReport.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprOtherReport.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprOtherReport.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprOtherReport.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpread.PrintOrientationConstants property PrintOrientationConstants.PrintOrientationPortrait was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprOtherReport.PrintOrientation was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprOtherReport.setPrintOrientation(UpgradeStubs.FPSpread_PrintOrientationConstants.getPrintOrientationPortrait());
			ViewModel.sprOtherReport.Action = FarPoint.ViewModels.FPActionConstants.ActionSmartPrint;
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			//Produce Hazardous Condition, Search/Rescue, False Alarm
			//Investigate Only, Standby/Staging, or Cleanup Only Report.
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
			//Hazardous Condition
			//    ReportLog.GetReportLog 109916

			//Search/Rescue
			//    ReportLog.GetReportLog 109937

			//False Alarm
			//    ReportLog.GetReportLog 36604

			//Investigate Only
			//    ReportLog.GetReportLog 110207

			//Cleanup
			//    ReportLog.GetReportLog 108793

			//Standby Staging
			//    ReportLog.GetReportLog 109328
			//*********************************************

			ReportLog.GetReportLog(IncidentMain.Shared.gEditReportID);
			ViewModel.ReportType = ReportLog.ReportType;
			ViewModel.CurrIncident = ReportLog.RLIncidentID;

			switch ( ViewModel.ReportType )
			{
				case IncidentMain.HAZCONDITION:
					ViewModel.CurrReportTitle = "Hazardous Condition Report";
					break;
				case IncidentMain.SEARCHRESCUE:
					ViewModel.CurrReportTitle = "Search/Rescue Report";

					break;
				case IncidentMain.FALSEALARM:
					ViewModel.CurrReportTitle = "False Alarm Report";

					break;
				case IncidentMain.INVESTIGATION:
					ViewModel.CurrReportTitle = "Investigate Only Report";

					break;
				case IncidentMain.STANDBY:
					ViewModel.CurrReportTitle = "Standby/Staging Only Report";

					break;
				case IncidentMain.CLEANUP:
					ViewModel.CurrReportTitle = "Clean Up Only Report";

					break;
			}
			ViewModel.lbTitle.Text = ViewModel.CurrReportTitle + " - Print Preview";
			LoadReport();

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmReportOther DefInstance
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

		public static frmReportOther CreateInstance()
		{
			TFDIncident.frmReportOther theInstance = Shared.Container.Resolve<frmReportOther>();
			theInstance.Form_Load();
			return theInstance;
		}

		protected override void ExecuteControlsStartup()
		{
			ViewModel.sprOtherReport.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprOtherReport.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmReportOther
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.frmReportOtherViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmReportOther m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}