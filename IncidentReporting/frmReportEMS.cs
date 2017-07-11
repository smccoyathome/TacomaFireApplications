using Microsoft.VisualBasic;
using System;
using UpgradeHelpers.DB.ADO;
using UpgradeStubs;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using FarPoint.ViewModels;

namespace TFDIncident
{

	public partial class frmReportEMS
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.frmReportEMSViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmReportEMS));
			if ( Shared.m_vb6FormDefInstance == null )
			{
				if ( Shared.m_InitializingDefInstance )
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
		}


		private void frmReportEMS_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender )
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>)eventSender;
			}
		}
		//If CurrReport = 1 then EMS Patient Contact Report, if = 2 then HIPAA Access History Report

		private void DisplayHeadings()
		{
			(ViewModel.CurrRow)++;
			ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprEMSReport.RowPageBreak was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEMSReport.setRowPageBreak(true);
			(ViewModel.CurrRow)++;
			ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
			ViewModel.sprEMSReport.Col = 7;
			ViewModel.sprEMSReport.FontSize = 8;
			ViewModel.sprEMSReport.FontBold = true;
			ViewModel.sprEMSReport.Text = "Print Date:";
			ViewModel.sprEMSReport.Col = 9;
			ViewModel.sprEMSReport.FontSize = 8;
			ViewModel.sprEMSReport.FontBold = false;
			ViewModel.sprEMSReport.Text = UpgradeHelpers.Helpers.StringsHelper.Format(DateTime.Now, "m/d/yyyy h:nn AM/PM");
			(ViewModel.CurrRow)++;
			ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
			ViewModel.sprEMSReport.Col = 7;
			ViewModel.sprEMSReport.FontSize = 8;
			ViewModel.sprEMSReport.FontBold = true;
			ViewModel.sprEMSReport.Text = "Incident Number:";
			ViewModel.sprEMSReport.Col = 9;
			ViewModel.sprEMSReport.FontSize = 8;
			ViewModel.sprEMSReport.FontBold = false;
			ViewModel.sprEMSReport.Text = ViewModel.IncidentNumber;
			(ViewModel.CurrRow)++;
			ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
			ViewModel.sprEMSReport.Col = 1;
			if ( ViewModel.CurrRow > 100 )
			{
				ViewModel.sprEMSReport.Text = "EMS Patient Narration";
				ViewModel.sprEMSReport.FontSize = 10;
				ViewModel.sprEMSReport.FontBold = true;
				ViewModel.sprEMSReport.FontItalic = true;
				ViewModel.sprEMSReport.BlockMode = true;
				ViewModel.sprEMSReport.Row2 = ViewModel.CurrRow;
				ViewModel.sprEMSReport.Col2 = 10;
				ViewModel.sprEMSReport.BackColor = IncidentMain.Shared.LTGRAY;
				ViewModel.sprEMSReport.BlockMode = false;
				(ViewModel.CurrRow)++;
				ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
				ViewModel.sprEMSReport.Col = 1;
				ViewModel.sprEMSReport.Text = "Narration Continued:";
				ViewModel.sprEMSReport.FontBold = true;
				ViewModel.sprEMSReport.FontSize = 8;
				ViewModel.sprEMSReport.Col = 2;
				ViewModel.sprEMSReport.FontSize = 7;
				(ViewModel.CurrRow)++;
			}
			ViewModel.PageCountRow = 4;

		}

		private void LoadHIPAAReport()
		{
			//Format HIPAA Access History Report
			TFDIncident.clsHIPAA HIPAACL = Container.Resolve<clsHIPAA>();

			//Clear sprHIPAAReport
			ViewModel.sprHIPAAReport.BlockMode = true;
			ViewModel.sprHIPAAReport.Col = 1;
			ViewModel.sprHIPAAReport.Col2 = 5;
			ViewModel.sprHIPAAReport.Row = 6;
			ViewModel.sprHIPAAReport.Row2 = 100;
			ViewModel.sprHIPAAReport.Text = "";
			ViewModel.sprHIPAAReport.BlockMode = false;

			int CurrRow = 6;
			ViewModel.sprHIPAAReport.Col = 1;
			ViewModel.sprHIPAAReport.Row = CurrRow;

			if ( ~HIPAACL.GetCreateDate(ViewModel.PatientID) != 0 )
			{
				ViewModel.sprHIPAAReport.Text = "Unknown";
				ViewModel.sprHIPAAReport.Col = 2;
				ViewModel.sprHIPAAReport.Text = "Unknown";
				ViewModel.sprHIPAAReport.Col = 3;
				ViewModel.sprHIPAAReport.Text = "Record Created";
			}
			else
			{
				System.DateTime TempDate = DateTime.FromOADate(0);
				ViewModel.sprHIPAAReport.Text = (DateTime.TryParse(IncidentMain.Clean(HIPAACL.EMSRecordsAccess["action_date"]), out TempDate)) ? TempDate.ToString("M/d/yyyy HH:mm") : IncidentMain.Clean(HIPAACL.EMSRecordsAccess["action_date"]);
				ViewModel.sprHIPAAReport.Col = 2;
				ViewModel.sprHIPAAReport.Text = IncidentMain.Clean(HIPAACL.EMSRecordsAccess["access_by"]);
				ViewModel.sprHIPAAReport.Col = 3;
				ViewModel.sprHIPAAReport.Text = IncidentMain.Clean(HIPAACL.EMSRecordsAccess["access_type"]);
			}
			CurrRow++;
			ViewModel.sprHIPAAReport.Row = CurrRow;
			ViewModel.sprHIPAAReport.Col = 1;

			if ( ~HIPAACL.GetHIPAAHistory(ViewModel.PatientID) != 0 )
			{
				ViewModel.sprHIPAAReport.Text = "No Access History Available";
			}
			else
			{

				while ( !HIPAACL.EMSRecordsAccess.EOF )
				{
					System.DateTime TempDate2 = DateTime.FromOADate(0);
					ViewModel.sprHIPAAReport.Text = (DateTime.TryParse(IncidentMain.Clean(HIPAACL.EMSRecordsAccess["access_date"]), out TempDate2)) ? TempDate2.ToString("M/d/yyyy HH:mm") : IncidentMain.Clean(HIPAACL.EMSRecordsAccess["access_date"]);
					ViewModel.sprHIPAAReport.Col = 2;
					ViewModel.sprHIPAAReport.Text = IncidentMain.Clean(HIPAACL.EMSRecordsAccess["name_full"]);
					ViewModel.sprHIPAAReport.Col = 3;
					ViewModel.sprHIPAAReport.Text = IncidentMain.Clean(HIPAACL.EMSRecordsAccess["access_type"]);
					ViewModel.sprHIPAAReport.Col = 4;
					ViewModel.sprHIPAAReport.Text = IncidentMain.Clean(HIPAACL.EMSRecordsAccess["released_to_name"]);
					ViewModel.sprHIPAAReport.Col = 5;
					ViewModel.sprHIPAAReport.Text = IncidentMain.Clean(HIPAACL.EMSRecordsAccess["released_reason"]);
					CurrRow++;
					ViewModel.sprHIPAAReport.Row = CurrRow;
					ViewModel.sprHIPAAReport.Col = 1;
					HIPAACL.EMSRecordsAccess.MoveNext();
				};
				}



			}


		private void LoadEMSReport()
		{
			//Format EMS Report
			TFDIncident.clsEMS EMSReport = Container.Resolve<clsEMS>();
			TFDIncident.clsEMSCodes EMSCodes = Container.Resolve<clsEMSCodes>();
			TFDIncident.clsIncident IncidentCL = Container.Resolve<clsIncident>();
			TFDIncident.clsUnit UnitCL = Container.Resolve<clsUnit>();
			int ActionTaken = 0;
			int x = 0;
			string sDisplay = "";
			int Count = 0;
			string CurrUnit = "";
			ViewModel.sprEMSReport.Row = 1;
			ViewModel.sprEMSReport.Col = 8;
			ViewModel.sprEMSReport.Text = UpgradeHelpers.Helpers.StringsHelper.Format(DateTime.Now, "m/d/yyyy h:nn AM/PM");

			if ( ~EMSReport.GetEMSPatientContactReport(ViewModel.PatientID) != 0 )
			{
				ViewManager.ShowMessage("Error retrieving patient record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				return ;
			}
			else
			{
				ActionTaken = Convert.ToInt32(EMSReport.EMSPatientContact["action_code"]);
			}
			ViewModel.CurrRow = 5;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
			this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.WaitCursor);
			// ****** Incident Information *****
			if ( IncidentCL.GetIncident(Convert.ToInt32(EMSReport.EMSPatientContact["incident_id"])) != 0 )
			{
				ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
				ViewModel.sprEMSReport.Col = 2;
				ViewModel.sprEMSReport.Text = IncidentCL.IncidentNumber;
				ViewModel.IncidentNumber = IncidentCL.IncidentNumber;
				(ViewModel.CurrRow)++;
				ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
				ViewModel.sprEMSReport.Col = 2;
				ViewModel.sprEMSReport.Text = DateTime.Parse(IncidentCL.DateIncidentCreated).ToString("M/d/yyyy   HH:mm");
				(ViewModel.CurrRow)++;
				ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
				ViewModel.sprEMSReport.Col = 2;
				ViewModel.sprEMSReport.Text = IncidentCL.Location;
				(ViewModel.CurrRow)++;
				ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
				ViewModel.sprEMSReport.Col = 2;
				ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientContact["incident_zipcode"]);
				ViewModel.CurrRow -= 3;
				//Unit Times
				if ( UnitCL.GetUnitResponseTimesReport(Convert.ToInt32(EMSReport.EMSPatientContact["incident_id"])) != 0 )
				{

					while ( !UnitCL.UnitTimes.EOF )
					{
						if ( Convert.ToString(UnitCL.UnitTimes["Unit"]) != CurrUnit )
						{
							for ( x = 7; x <= 11; x++ )
							{
								ViewModel.sprEMSReport.Col = x;
								ViewModel.sprEMSReport.Action = FarPoint.ViewModels.FPActionConstants.ActionSetCellBorder;
							}
							(ViewModel.CurrRow)++;
							ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
							CurrUnit = Convert.ToString(UnitCL.UnitTimes["Unit"]);
							ViewModel.sprEMSReport.Col = 6;
							ViewModel.sprEMSReport.Text = IncidentMain.Clean(UnitCL.UnitTimes["unit_name"]);
						}
						switch ( Convert.ToInt32(UnitCL.UnitTimes["response_time_code"]) )
						{
							case 3: //Dispatched 

								ViewModel.sprEMSReport.Col = 7;
								ViewModel.sprEMSReport.Text = Convert.ToDateTime(UnitCL.UnitTimes["unit_time"]).ToString("HH:mm");
								break;
							case 5: //onscene 

								ViewModel.sprEMSReport.Col = 8;
								ViewModel.sprEMSReport.Text = Convert.ToDateTime(UnitCL.UnitTimes["unit_time"]).ToString("HH:mm");
								break;
							case 6: //tranport 

								ViewModel.sprEMSReport.Col = 9;
								ViewModel.sprEMSReport.Text = Convert.ToDateTime(UnitCL.UnitTimes["unit_time"]).ToString("HH:mm");
								break;
							case 7: //transport complete 

								ViewModel.sprEMSReport.Col = 10;
								ViewModel.sprEMSReport.Text = Convert.ToDateTime(UnitCL.UnitTimes["unit_time"]).ToString("HH:mm");
								break;
							case 8: //available 

								ViewModel.sprEMSReport.Col = 11;
								ViewModel.sprEMSReport.Text = Convert.ToDateTime(UnitCL.UnitTimes["unit_time"]).ToString("HH:mm");
								break;
						}
						UnitCL.UnitTimes.MoveNext();
					};
					for ( x = 7; x <= 11; x++ )
					{
						ViewModel.sprEMSReport.Col = x;
						ViewModel.sprEMSReport.Action = FarPoint.ViewModels.FPActionConstants.ActionSetCellBorder;
					}
				}
			}
			(ViewModel.CurrRow)++;
			if ( ViewModel.CurrRow < 10 )
			{
				ViewModel.CurrRow = 10;
			}
			ViewModel.SaveRow = ViewModel.CurrRow;
			ViewModel.PageCountRow = ViewModel.CurrRow;
			// ****** Patient Contact Information *****
			//    CurrRow = 10
			ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
			ViewModel.sprEMSReport.Col = 1;
			switch ( ActionTaken )
			{
				case 3 : case 4 : case 5 :
					ViewModel.sprEMSReport.Text = "Basic Patient Contact Information";
					ViewModel.sprEMSReport.FontSize = 10;
					ViewModel.sprEMSReport.FontBold = true;
					ViewModel.sprEMSReport.FontItalic = true;
					ViewModel.sprEMSReport.BlockMode = true;
					ViewModel.sprEMSReport.Row2 = ViewModel.CurrRow;
					ViewModel.sprEMSReport.Col2 = 11;
					ViewModel.sprEMSReport.BackColor = IncidentMain.Shared.LTGRAY;
					ViewModel.sprEMSReport.BlockMode = false;
					(ViewModel.CurrRow)++;
					ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
					ViewModel.sprEMSReport.Text = "Action Taken:";
					ViewModel.sprEMSReport.FontBold = true;
					ViewModel.sprEMSReport.FontSize = 8;
					ViewModel.sprEMSReport.Col = 2;
					ViewModel.sprEMSReport.FontSize = 7;
					ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientContact["action_desc"]);
					(ViewModel.CurrRow)++;
					ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
					ViewModel.sprEMSReport.Col = 1;
					ViewModel.sprEMSReport.FontSize = 7;
					ViewModel.sprEMSReport.Text = "Service Provided:";
					ViewModel.sprEMSReport.FontBold = true;
					ViewModel.sprEMSReport.FontSize = 8;
					ViewModel.sprEMSReport.Col = 2;
					ViewModel.sprEMSReport.FontSize = 7;
					ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientContact["service_desc"]);
					(ViewModel.CurrRow)++;
					ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
					ViewModel.sprEMSReport.Col = 1;
					ViewModel.sprEMSReport.Text = "Incident Location:";
					ViewModel.sprEMSReport.FontBold = true;
					ViewModel.sprEMSReport.FontSize = 8;
					ViewModel.sprEMSReport.Col = 2;
					ViewModel.sprEMSReport.FontSize = 7;
					ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientContact["location_desc"]);
					(ViewModel.CurrRow)++;
					ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
					ViewModel.sprEMSReport.Col = 1;
					ViewModel.sprEMSReport.Text = "Incident Setting:";
					ViewModel.sprEMSReport.FontBold = true;
					ViewModel.sprEMSReport.FontSize = 8;
					ViewModel.sprEMSReport.Col = 2;
					ViewModel.sprEMSReport.FontSize = 7;
					ViewModel.sprEMSReport.Text = Convert.ToString(EMSReport.EMSPatientContact["setting_desc"]);
					ViewModel.CurrRow -= 3;
					ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
					ViewModel.sprEMSReport.Col = 6;
					if ( EMSReport.GetEMSPatient(ViewModel.PatientID) != 0 )
					{
						ViewModel.sprEMSReport.Text = "Patient Name:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 8;
						ViewModel.sprEMSReport.FontSize = 7;
						sDisplay = EMSReport.NameFirst + " " + EMSReport.NameMI + ". " + EMSReport.NameLast;
						ViewModel.sprEMSReport.Text = sDisplay;
						ViewModel.sprEMSReport.Col = 6;
						(ViewModel.CurrRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
					}
					ViewModel.sprEMSReport.Text = "Patient Age:";
					ViewModel.sprEMSReport.FontBold = true;
					ViewModel.sprEMSReport.FontSize = 8;
					ViewModel.sprEMSReport.Col = 8;
					ViewModel.sprEMSReport.FontSize = 7;
					ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientContact["age"]);
					ViewModel.sprEMSReport.Col = 9;
					ViewModel.sprEMSReport.FontSize = 7;
					ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientContact["ageunit_desc"]);
					(ViewModel.CurrRow)++;
					ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
					ViewModel.sprEMSReport.Col = 6;
					ViewModel.sprEMSReport.Text = "Patient Descriptors:";
					ViewModel.sprEMSReport.FontBold = true;
					ViewModel.sprEMSReport.FontSize = 8;
					ViewModel.sprEMSReport.Col = 8;
					ViewModel.sprEMSReport.FontSize = 7;
					ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientContact["gender_desc"]);
					ViewModel.sprEMSReport.Col = 9;
					ViewModel.sprEMSReport.FontSize = 7;
					ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientContact["race_desc"]);
					ViewModel.sprEMSReport.Col = 8;
					ViewModel.sprEMSReport.FontSize = 7;
					(ViewModel.CurrRow)++;
					ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
					ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientContact["ethnicity_desc"]);
					(ViewModel.CurrRow)++;
					if ( EMSReport.GetEMSPatientNarrationRS(ViewModel.PatientID) != 0 )
					{

						while ( !EMSReport.EMSPatientNarration.EOF )
						{
							EMSReport.GetEMSPatientNarration(Convert.ToInt32(EMSReport.EMSPatientNarration["ems_narration_id"]));
							if ( ViewModel.PageCountRow > 56 )
							{
								DisplayHeadings();
							}
							(ViewModel.CurrRow)++;
							(ViewModel.PageCountRow)++;
							ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
							ViewModel.sprEMSReport.Col = 1;
							ViewModel.sprEMSReport.Text = "Patient Narration";
							ViewModel.sprEMSReport.FontBold = true;
							ViewModel.sprEMSReport.FontItalic = true;
							ViewModel.sprEMSReport.FontSize = 10;
							ViewModel.sprEMSReport.BlockMode = true;
							ViewModel.sprEMSReport.Row2 = ViewModel.CurrRow;
							ViewModel.sprEMSReport.Col2 = 11;
							ViewModel.sprEMSReport.BackColor = IncidentMain.Shared.LTGRAY;
							ViewModel.sprEMSReport.BlockMode = false;
							(ViewModel.CurrRow)++;
							(ViewModel.PageCountRow)++;
							ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
							ViewModel.sprEMSReport.Col = 1;
							ViewModel.sprEMSReport.Text = "Narration By:";
							ViewModel.sprEMSReport.FontBold = true;
							ViewModel.sprEMSReport.FontSize = 8;
							ViewModel.sprEMSReport.Col = 2;
							ViewModel.sprEMSReport.FontSize = 7;
							ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.NarrationBy);
							(ViewModel.CurrRow)++;
							(ViewModel.PageCountRow)++;
							ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
							ViewModel.sprEMSReport.Col = 1;
							ViewModel.sprEMSReport.Text = "Last Update Date:";
							ViewModel.sprEMSReport.FontBold = true;
							ViewModel.sprEMSReport.FontSize = 8;
							ViewModel.sprEMSReport.Col = 2;
							ViewModel.sprEMSReport.FontSize = 7;
							ViewModel.sprEMSReport.Text = DateTime.Parse(EMSReport.NarrationDate).ToString("M/d/yyyy");
							(ViewModel.CurrRow)++;
							(ViewModel.PageCountRow)++;
							ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
							ViewModel.sprEMSReport.Col = 1;
							ViewModel.sprEMSReport.Text = "Narration:";
							ViewModel.sprEMSReport.FontBold = true;
							ViewModel.sprEMSReport.FontSize = 8;
							ViewModel.sprEMSReport.Col = 2;
							ViewModel.sprEMSReport.FontSize = 7;
							sDisplay = IncidentMain.Clean(EMSReport.NarrationText);
							if ( Strings.Len(sDisplay) > 0 )
							{
								sDisplay = sDisplay.Substring(0, Math.Min(Strings.Len(sDisplay) - 1, sDisplay.Length));
								ViewModel.LastRow = Strings.Len(sDisplay) / 100 + 1;
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
							ViewModel.sprEMSReport.BlockMode = true;
							ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
							ViewModel.sprEMSReport.Row2 = ViewModel.CurrRow + ViewModel.LastRow;
							ViewModel.sprEMSReport.Col = 2;
							ViewModel.sprEMSReport.Col2 = 9;
							ViewModel.sprEMSReport.CellType = FarPoint.ViewModels.Cells.FpCellType.CellTypeStaticText;
							(ViewModel.sprEMSReport.ActiveSheet.Cells[ViewModel.sprEMSReport.Row, ViewModel.sprEMSReport.Col].CellType as FarPoint.ViewModels.TextCellType).WordWrap = true;
							ViewModel.sprEMSReport.BlockMode = false;
							//UPGRADE_ISSUE: (2064) FPSpread.vaSpread method sprEMSReport.AddCellSpan was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.sprEMSReport.AddCellSpan(2, ViewModel.CurrRow, 8, ViewModel.LastRow);
							ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
							ViewModel.sprEMSReport.Col = 2;
							ViewModel.sprEMSReport.Text = sDisplay;
							ViewModel.CurrRow = ViewModel.CurrRow + ViewModel.LastRow + 1;
							ViewModel.sprEMSReport.Row = ViewModel.CurrRow;

							//                    sDisplay = Left$(sDisplay, Len(sDisplay) - 1)
							//                    For i = 0 To CInt((Len(sDisplay) / 90))
							//                         sprEMSReport.Row = CurrRow
							//                         sprEMSReport.Text = Mid$(sDisplay, (90 * i) + 1, 90)
							//                         If Right$(sprEMSReport.Text, 1) <> " " Then
							//                             If Right$(sprEMSReport.Text, 1) <> "." Then
							//                                 sprEMSReport.Text = sprEMSReport.Text & "-"
							//                             End If
							//                         End If
							//                         CurrRow = CurrRow + 1
							//                         PageCountRow = PageCountRow + 1
							//                         If PageCountRow > 56 Then DisplayHeadings
							//                    Next i
							EMSReport.EMSPatientNarration.MoveNext();
						};
						}

					break;
				default:
					// ****** Patient Information ***** 
					ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
					ViewModel.sprEMSReport.Col = 1;
					ViewModel.sprEMSReport.Text = "Action Taken:";
					ViewModel.sprEMSReport.FontBold = true;
					ViewModel.sprEMSReport.FontSize = 8;
					ViewModel.sprEMSReport.Col = 2;
					ViewModel.sprEMSReport.FontSize = 7;
					ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientContact["action_desc"]);
					(ViewModel.CurrRow)++;
					if ( EMSReport.GetEMSPatient(ViewModel.PatientID) != 0 )
					{
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 1;
						ViewModel.sprEMSReport.Text = "Patient Information";
						ViewModel.sprEMSReport.FontSize = 10;
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontItalic = true;
						ViewModel.sprEMSReport.BlockMode = true;
						ViewModel.sprEMSReport.Row2 = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col2 = 11;
						ViewModel.sprEMSReport.BackColor = IncidentMain.Shared.LTGRAY;
						ViewModel.sprEMSReport.BlockMode = false;
						(ViewModel.CurrRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 1;
						ViewModel.sprEMSReport.Text = "Patient Name:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 2;
						ViewModel.sprEMSReport.FontSize = 7;
						sDisplay = EMSReport.NameFirst + " " + EMSReport.NameMI + ". " + EMSReport.NameLast;
						ViewModel.sprEMSReport.Text = sDisplay;
						ViewModel.sprEMSReport.Col = 1;
						(ViewModel.CurrRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Text = "Billing Address:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 2;
						ViewModel.sprEMSReport.FontSize = 7;
						ViewModel.sprEMSReport.Text = EMSReport.BillingAddress;
						(ViewModel.CurrRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 1;
						ViewModel.sprEMSReport.Text = "City/State/Zip:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 2;
						ViewModel.sprEMSReport.FontSize = 7;
						sDisplay = EMSReport.City + ", " + EMSReport.State + " " + EMSReport.Zipcode;
						ViewModel.sprEMSReport.Text = sDisplay;
						(ViewModel.CurrRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 1;
						ViewModel.sprEMSReport.Text = "Phone No.:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 2;
						ViewModel.sprEMSReport.FontSize = 7;
						ViewModel.sprEMSReport.Text = EMSReport.Phone;
						(ViewModel.CurrRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 1;
						ViewModel.sprEMSReport.Text = "SSN#:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 2;
						ViewModel.sprEMSReport.FontSize = 7;
						ViewModel.sprEMSReport.Text = EMSReport.SocialSecurityNumber;
						(ViewModel.CurrRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 1;
						ViewModel.sprEMSReport.Text = "Patient Birthdate/Age:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 3;
						ViewModel.sprEMSReport.FontSize = 7;
						if ( EMSReport.Birthdate != "" )
						{
							ViewModel.sprEMSReport.Text = EMSReport.Birthdate;
						}
						else
						{
							ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientContact["age"]);
							ViewModel.sprEMSReport.Col = 4;
							ViewModel.sprEMSReport.FontSize = 7;
							ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientContact["ageunit_desc"]);
						}
						(ViewModel.CurrRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 1;
						ViewModel.sprEMSReport.Text = "Patient Descriptors:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 3;
						ViewModel.sprEMSReport.FontSize = 7;
						sDisplay = IncidentMain.Clean(EMSReport.EMSPatientContact["gender_desc"]) + ", " + IncidentMain.Clean(EMSReport.EMSPatientContact["race_desc"]) + ", " + IncidentMain.Clean(EMSReport.EMSPatientContact["ethnicity_desc"]);
						ViewModel.sprEMSReport.Text = sDisplay;
						//save place in case no prior history or contrib factors
						ViewModel.SaveRow = ViewModel.CurrRow;
						ViewModel.CurrRow -= 6;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 7;
						ViewModel.sprEMSReport.Text = "Treatment Auth.:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 9;
						ViewModel.sprEMSReport.FontSize = 7;
						ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientContact["treatment_desc"]);
						(ViewModel.CurrRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 7;
						ViewModel.sprEMSReport.Text = "Severity:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 8;
						ViewModel.sprEMSReport.FontSize = 7;
						ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientContact["severity_desc"]);
						ViewModel.sprEMSReport.Col = 9;
						ViewModel.sprEMSReport.Text = "DNRO?:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 10;
						ViewModel.sprEMSReport.FontSize = 7;
						if ( EMSReport.FlagDNRO == UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe("1") )
						{
							ViewModel.sprEMSReport.Text = "Yes";
						}
						else
						{
							ViewModel.sprEMSReport.Text = "No";
						}
						(ViewModel.CurrRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 7;
						ViewModel.sprEMSReport.Text = "ALS/BLS:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 8;
						ViewModel.sprEMSReport.FontSize = 7;
						if ( EMSReport.LevelOfCareAlsBls == "1" )
						{
							ViewModel.sprEMSReport.Text = "ALS";
						}
						else
						{
							ViewModel.sprEMSReport.Text = "BLS";
						}
						(ViewModel.CurrRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 7;
						ViewModel.sprEMSReport.Text = "Incident Location:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 9;
						ViewModel.sprEMSReport.FontSize = 7;
						ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientContact["location_desc"]);
						(ViewModel.CurrRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 7;
						ViewModel.sprEMSReport.Text = "Incident Setting:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 9;
						ViewModel.sprEMSReport.FontSize = 7;
						ViewModel.sprEMSReport.Text = Convert.ToString(EMSReport.EMSPatientContact["setting_desc"]);
						if ( EMSReport.GetEMSPreExistingConditionReport(ViewModel.PatientID) != 0 )
						{
							(ViewModel.CurrRow)++;
							ViewModel.sprEMSReport.Col = 7;
							ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
							ViewModel.sprEMSReport.Text = "Prior Medical History:";
							ViewModel.sprEMSReport.FontBold = true;
							ViewModel.sprEMSReport.FontSize = 8;
							ViewModel.sprEMSReport.Col = 9;
							ViewModel.sprEMSReport.FontSize = 7;

							while ( !EMSReport.EMSPreExistingCondition.EOF )
							{
								ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
								ViewModel.sprEMSReport.FontSize = 7;
								ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPreExistingCondition["description"]);
								(ViewModel.CurrRow)++;
								EMSReport.EMSPreExistingCondition.MoveNext();
							}
							;
						}
						if ( EMSReport.GetEMSContributingFactorReport(ViewModel.PatientID) != 0 )
						{
							(ViewModel.CurrRow)++;
							ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
							ViewModel.sprEMSReport.Col = 7;
							ViewModel.sprEMSReport.Text = "Contributing Factors:";
							ViewModel.sprEMSReport.FontBold = true;
							ViewModel.sprEMSReport.FontSize = 8;
							ViewModel.sprEMSReport.Col = 9;
							ViewModel.sprEMSReport.FontSize = 7;

							while ( !EMSReport.EMSContributingFactor.EOF )
							{
								ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
								ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSContributingFactor["description"]);
								(ViewModel.CurrRow)++;
								EMSReport.EMSContributingFactor.MoveNext();
							}
							;
						}
						if ( ViewModel.SaveRow > ViewModel.CurrRow )
						{
							ViewModel.CurrRow = ViewModel.SaveRow;
						}
						ViewModel.PageCountRow = ViewModel.CurrRow;
					}
					// ****** Patient Examination Information ***** 
					if ( EMSReport.GetEMSPatientExamReport(ViewModel.PatientID) != 0 )
					{
						ViewModel.CurrRow += 2;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 1;
						ViewModel.sprEMSReport.Text = "Patient Examination";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontItalic = true;
						ViewModel.sprEMSReport.FontSize = 10;
						ViewModel.sprEMSReport.BlockMode = true;
						ViewModel.sprEMSReport.Row2 = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col2 = 11;
						ViewModel.sprEMSReport.BackColor = IncidentMain.Shared.LTGRAY;
						ViewModel.sprEMSReport.BlockMode = false;
						(ViewModel.CurrRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 1;
						ViewModel.sprEMSReport.Text = "Mechanism of Injury/Illness:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 3;
						ViewModel.sprEMSReport.FontSize = 7;
						ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMCPatientExam["mech_code_desc"]);
						ViewModel.sprEMSReport.Col = 7;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Text = "Resp. Effort:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 8;
						ViewModel.sprEMSReport.FontSize = 7;
						ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMCPatientExam["resp_desc"]);
						(ViewModel.CurrRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 1;
						ViewModel.sprEMSReport.Text = "Injury/Illness:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 2;
						ViewModel.sprEMSReport.FontSize = 7;
						if ( Convert.ToString(EMSReport.EMCPatientExam["injury_desc"]) != "" )
						{
							ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMCPatientExam["injury_desc"]);
						}
						else
						{
							ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMCPatientExam["illness_desc"]);
						}
						ViewModel.sprEMSReport.Col = 8;
						ViewModel.sprEMSReport.Text = "Pupils:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 9;
						ViewModel.sprEMSReport.FontSize = 7;
						ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMCPatientExam["pupils_desc"]);
						(ViewModel.CurrRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 8;
						ViewModel.sprEMSReport.Text = "L.O.C.:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 9;
						ViewModel.sprEMSReport.FontSize = 7;
						ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMCPatientExam["loc_desc"]);
						if ( Convert.ToBoolean(EMSReport.EMCPatientExam["flag_extrication_required"]) )
						{
							ViewModel.sprEMSReport.Col = 1;
							ViewModel.sprEMSReport.Text = "Extrication Req: ";
							ViewModel.sprEMSReport.FontBold = true;
							ViewModel.sprEMSReport.FontSize = 8;
							ViewModel.sprEMSReport.Col = 2;
							ViewModel.sprEMSReport.FontSize = 7;
							sDisplay = Convert.ToString(EMSReport.EMCPatientExam["extrication_time"]) + " Minutes";
							ViewModel.sprEMSReport.Text = sDisplay;
						}
						if ( EMSReport.GetEMSSecondaryIllnessReport(ViewModel.PatientID) != 0 )
						{
							(ViewModel.CurrRow)++;
							ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
							ViewModel.sprEMSReport.Col = 1;
							ViewModel.sprEMSReport.Text = "Secondary Illnesses:";
							ViewModel.sprEMSReport.FontBold = true;
							ViewModel.sprEMSReport.FontSize = 8;
							ViewModel.sprEMSReport.Col = 3;
							ViewModel.sprEMSReport.FontSize = 7;

							while ( !EMSReport.EMSSecondaryIllness.EOF )
							{
								ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
								ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSSecondaryIllness["second_illness_desc"]);
								(ViewModel.CurrRow)++;
								EMSReport.EMSSecondaryIllness.MoveNext();
							}
							;
						}
						Count = 0;
						(ViewModel.CurrRow)++;
						if ( EMSReport.GetEMSPatientVitalsReport(ViewModel.PatientID) != 0 )
						{

							while ( !EMSReport.EMSPatientVitals.EOF )
							{
								ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
								ViewModel.sprEMSReport.Col = 1;
								Count++;
								if ( Count == 1 )
								{
									sDisplay = "First ";
								}
								if ( Count == 2 )
								{
									sDisplay = "Second ";
								}
								if ( Count == 3 )
								{
									sDisplay = "Third ";
								}
								if ( Count == 4 )
								{
									sDisplay = "Fourth ";
								}
								ViewModel.sprEMSReport.Text = sDisplay + "Vitals";
								ViewModel.sprEMSReport.FontBold = true;
								ViewModel.sprEMSReport.FontSize = 8;
								(ViewModel.CurrRow)++;
								ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
								ViewModel.sprEMSReport.FontSize = 7;
								sDisplay = IncidentMain.Clean(EMSReport.EMSPatientVitals["vitals_time"]);
								System.DateTime TempDate = DateTime.FromOADate(0);
								sDisplay = (DateTime.TryParse(sDisplay, out TempDate)) ? TempDate.ToString("HH:mm ") : sDisplay;
								ViewModel.sprEMSReport.Text = sDisplay;
								(ViewModel.CurrRow)--;
								ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
								ViewModel.sprEMSReport.Col = 2;
								ViewModel.sprEMSReport.Text = "Pulse";
								ViewModel.sprEMSReport.FontBold = true;
								ViewModel.sprEMSReport.FontSize = 8;
								ViewModel.sprEMSReport.Col = 3;
								ViewModel.sprEMSReport.Text = "Resp";
								ViewModel.sprEMSReport.FontBold = true;
								ViewModel.sprEMSReport.FontSize = 8;
								ViewModel.sprEMSReport.Col = 4;
								ViewModel.sprEMSReport.Text = "BP";
								ViewModel.sprEMSReport.FontBold = true;
								ViewModel.sprEMSReport.FontSize = 8;
								ViewModel.sprEMSReport.Col = 6;
								ViewModel.sprEMSReport.Text = "Glucose";
								ViewModel.sprEMSReport.FontBold = true;
								ViewModel.sprEMSReport.FontSize = 8;
								ViewModel.sprEMSReport.Col = 7;
								ViewModel.sprEMSReport.Text = "Pulse Oxy %";
								ViewModel.sprEMSReport.FontBold = true;
								ViewModel.sprEMSReport.FontSize = 8;
								ViewModel.sprEMSReport.Col = 8;
								ViewModel.sprEMSReport.Text = "On Liters";
								ViewModel.sprEMSReport.FontBold = true;
								ViewModel.sprEMSReport.FontSize = 8;
								(ViewModel.CurrRow)++;
								ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
								ViewModel.sprEMSReport.Col = 2;
								ViewModel.sprEMSReport.FontSize = 7;
								ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientVitals["pulse"]);
								ViewModel.sprEMSReport.Col = 3;
								ViewModel.sprEMSReport.FontSize = 7;
								ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientVitals["respiration_rate"]);
								ViewModel.sprEMSReport.Col = 4;
								ViewModel.sprEMSReport.FontSize = 7;
								if ( Convert.ToBoolean(EMSReport.EMSPatientVitals["flag_diastolic_palp"]) )
								{
									//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
									sDisplay = Convert.ToString(IncidentMain.GetVal(EMSReport.EMSPatientVitals["systolic"]));
									sDisplay = sDisplay + "/Palp";
									ViewModel.sprEMSReport.Text = sDisplay;
								}
								else
								{
									//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
									sDisplay = Convert.ToString(IncidentMain.GetVal(EMSReport.EMSPatientVitals["systolic"]));
									sDisplay = sDisplay + "/" + Convert.ToString(EMSReport.EMSPatientVitals["diastolic"]);
									ViewModel.sprEMSReport.Text = sDisplay;
								}
								ViewModel.sprEMSReport.Col = 6;
								ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientVitals["blood_glucose"]);
								ViewModel.sprEMSReport.Col = 7;
								ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientVitals["pulse_oxygen"]);
								ViewModel.sprEMSReport.Col = 8;
								ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientVitals["percent_oxygen"]);
								(ViewModel.CurrRow)++;
								ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
								ViewModel.sprEMSReport.Col = 2;
								ViewModel.sprEMSReport.Text = "ECG:";
								ViewModel.sprEMSReport.FontBold = true;
								ViewModel.sprEMSReport.FontSize = 8;
								ViewModel.sprEMSReport.Col = 6;
								ViewModel.sprEMSReport.Text = "Position:";
								ViewModel.sprEMSReport.FontBold = true;
								ViewModel.sprEMSReport.FontSize = 8;
								ViewModel.sprEMSReport.Col = 3;
								ViewModel.sprEMSReport.FontSize = 7;
								ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientVitals["ecg_desc"]);
								ViewModel.sprEMSReport.Col = 7;
								ViewModel.sprEMSReport.FontSize = 7;
								ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientVitals["position_desc"]);
								(ViewModel.CurrRow)++;
								ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
								ViewModel.sprEMSReport.Col = 2;
								ViewModel.sprEMSReport.Text = "Eyes:";
								ViewModel.sprEMSReport.FontBold = true;
								ViewModel.sprEMSReport.FontSize = 8;
								ViewModel.sprEMSReport.Col = 6;
								ViewModel.sprEMSReport.Text = "Verbal:";
								ViewModel.sprEMSReport.FontBold = true;
								ViewModel.sprEMSReport.FontSize = 8;
								ViewModel.sprEMSReport.Col = 9;
								ViewModel.sprEMSReport.Text = "Motor:";
								ViewModel.sprEMSReport.FontBold = true;
								ViewModel.sprEMSReport.FontSize = 8;
								ViewModel.sprEMSReport.Col = 3;
								ViewModel.sprEMSReport.FontSize = 7;
								ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientVitals["gcs_eyes_desc"]);
								ViewModel.sprEMSReport.Col = 7;
								ViewModel.sprEMSReport.FontSize = 7;
								ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientVitals["gcs_verbal_desc"]);
								ViewModel.sprEMSReport.Col = 10;
								ViewModel.sprEMSReport.FontSize = 7;
								ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientVitals["gcs_motor_desc"]);
								ViewModel.CurrRow += 2;
								ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
								EMSReport.EMSPatientVitals.MoveNext();
							};
							}
						}
					if ( ViewModel.SaveRow > ViewModel.CurrRow )
					{
						ViewModel.CurrRow = ViewModel.SaveRow;
					}
					else
					{
						ViewModel.SaveRow = ViewModel.CurrRow;
					}
					ViewModel.PageCountRow = ViewModel.CurrRow;
					if ( ViewModel.PageCountRow > 51 )
					{
						DisplayHeadings();
					}
					// ****** Procedures Performed  ***** 
					if ( EMSReport.GetEMSProceduresReport(ViewModel.PatientID) != 0 )
					{
						ViewModel.CurrRow += 2;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 1;
						ViewModel.sprEMSReport.Text = "Procedures Performed";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontItalic = true;
						ViewModel.sprEMSReport.FontSize = 10;
						ViewModel.sprEMSReport.BlockMode = true;
						ViewModel.sprEMSReport.Row2 = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col2 = 11;
						ViewModel.sprEMSReport.BackColor = IncidentMain.Shared.LTGRAY;
						ViewModel.sprEMSReport.BlockMode = false;
						(ViewModel.CurrRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 1;
						ViewModel.sprEMSReport.Text = "BLS Personnel";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 2;
						ViewModel.sprEMSReport.Text = "BLS Procedures";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 6;
						ViewModel.sprEMSReport.Text = "ALS Personnel";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 8;
						ViewModel.sprEMSReport.Text = "ALS Procedures";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 10;
						ViewModel.sprEMSReport.Text = "Attempts";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 11;
						ViewModel.sprEMSReport.Text = "Success?";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						(ViewModel.CurrRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.SaveRow = ViewModel.CurrRow;
						ViewModel.PageCountRow += 4;

						while ( !EMSReport.EMSProcedure.EOF )
						{
							//ALS Personnel & Procedures
							if ( Convert.ToString(EMSReport.EMSProcedure["procedure_type"]) == "A" )
							{
								ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
								ViewModel.sprEMSReport.Col = 6;
								ViewModel.sprEMSReport.FontSize = 7;
								ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSProcedure["name_full"]);
								(ViewModel.CurrRow)++;
								ViewModel.sprEMSReport.Col = 8;
								ViewModel.sprEMSReport.FontSize = 7;
								ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSProcedure["proc_desc"]);
								ViewModel.sprEMSReport.Col = 10;
								ViewModel.sprEMSReport.FontSize = 7;
								//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								ViewModel.sprEMSReport.Text = Convert.ToString(IncidentMain.GetVal(EMSReport.EMSProcedure["attempts"]));
								ViewModel.sprEMSReport.Col = 11;
								ViewModel.sprEMSReport.FontSize = 7;
								//UPGRADE_WARNING: (1068) GetVal(EMSReport.EMSProcedure(flag_successful)) of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								if ( Convert.ToString(IncidentMain.GetVal(EMSReport.EMSProcedure["flag_successful"])) == "1" )
								{
									ViewModel.sprEMSReport.Text = "Yes";
								}
								else
								{
									ViewModel.sprEMSReport.Text = "No";
								}
								EMSReport.EMSProcedure.MoveNext();
							}
							else
							{
								//BLS Personnel & Procedures
								ViewModel.sprEMSReport.Row = ViewModel.SaveRow;
								ViewModel.sprEMSReport.Col = 1;
								ViewModel.sprEMSReport.FontSize = 7;
								ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSProcedure["name_full"]);
								(ViewModel.SaveRow)++;
								(ViewModel.PageCountRow)++;
								ViewModel.sprEMSReport.Col = 2;
								ViewModel.sprEMSReport.FontSize = 7;
								ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSProcedure["proc_desc"]);
								EMSReport.EMSProcedure.MoveNext();
							}
						}
						;
					}
					if ( ViewModel.SaveRow >= ViewModel.CurrRow )
					{
						ViewModel.CurrRow = ViewModel.SaveRow;
					}
					else
					{
						ViewModel.PageCountRow += (ViewModel.CurrRow - ViewModel.SaveRow);
						ViewModel.SaveRow = ViewModel.CurrRow;
					}

					if ( ViewModel.PageCountRow > 51 )
					{
						DisplayHeadings();
					}
					// ****** Treatment Information  ****** 
					if ( EMSReport.GetEMSPatientIVLineReport(ViewModel.PatientID) != 0 )
					{
						(ViewModel.CurrRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 1;
						ViewModel.sprEMSReport.Text = "Treatment Information";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontItalic = true;
						ViewModel.sprEMSReport.FontSize = 10;
						ViewModel.sprEMSReport.BlockMode = true;
						ViewModel.sprEMSReport.Row2 = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col2 = 11;
						ViewModel.sprEMSReport.BackColor = IncidentMain.Shared.LTGRAY;
						ViewModel.sprEMSReport.BlockMode = false;
						(ViewModel.CurrRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 1;
						Count = 0;
						ViewModel.PageCountRow += 2;

						while ( !EMSReport.EMSPatientIVLine.EOF )
						{
							Count++;
							ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
							ViewModel.sprEMSReport.Col = 1;
							if ( Count == 1 )
							{
								sDisplay = "First ";
							}
							if ( Count == 2 )
							{
								sDisplay = "Second ";
							}
							if ( Count == 3 )
							{
								sDisplay = "Third ";
							}
							if ( Count == 4 )
							{
								sDisplay = "Fourth ";
							}
							if ( Count == 5 )
							{
								sDisplay = "Fifth ";
							}
							ViewModel.sprEMSReport.Text = "IV Lines - " + sDisplay;
							ViewModel.sprEMSReport.FontBold = true;
							ViewModel.sprEMSReport.FontSize = 8;
							ViewModel.sprEMSReport.Col = 2;
							ViewModel.sprEMSReport.Text = "Gauge";
							ViewModel.sprEMSReport.FontBold = true;
							ViewModel.sprEMSReport.FontSize = 8;
							ViewModel.sprEMSReport.Col = 3;
							ViewModel.sprEMSReport.Text = "Route";
							ViewModel.sprEMSReport.FontBold = true;
							ViewModel.sprEMSReport.FontSize = 8;
							ViewModel.sprEMSReport.Col = 4;
							ViewModel.sprEMSReport.Text = "Rate";
							ViewModel.sprEMSReport.FontBold = true;
							ViewModel.sprEMSReport.FontSize = 8;
							ViewModel.sprEMSReport.Col = 5;
							ViewModel.sprEMSReport.Text = "Amount";
							ViewModel.sprEMSReport.FontBold = true;
							ViewModel.sprEMSReport.FontSize = 8;
							ViewModel.sprEMSReport.Col = 6;
							ViewModel.sprEMSReport.Text = "Site";
							ViewModel.sprEMSReport.FontBold = true;
							ViewModel.sprEMSReport.FontSize = 8;
							ViewModel.sprEMSReport.Col = 7;
							ViewModel.sprEMSReport.Text = "Saline Lock?";
							ViewModel.sprEMSReport.FontBold = true;
							ViewModel.sprEMSReport.FontSize = 8;
							(ViewModel.CurrRow)++;
							ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
							ViewModel.sprEMSReport.Col = 2;
							ViewModel.sprEMSReport.FontSize = 7;
							ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientIVLine["gauge_desc"]);
							ViewModel.sprEMSReport.Col = 3;
							ViewModel.sprEMSReport.FontSize = 7;
							ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientIVLine["route_desc"]);
							ViewModel.sprEMSReport.Col = 4;
							ViewModel.sprEMSReport.FontSize = 7;
							ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientIVLine["rate_desc"]);
							ViewModel.sprEMSReport.Col = 5;
							ViewModel.sprEMSReport.FontSize = 7;
							ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientIVLine["iv_amount"]);
							ViewModel.sprEMSReport.Col = 6;
							ViewModel.sprEMSReport.FontSize = 7;
							ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientIVLine["site_desc"]);
							ViewModel.sprEMSReport.Col = 7;
							ViewModel.sprEMSReport.FontSize = 7;
							//UPGRADE_WARNING: (1068) GetVal(EMSReport.EMSPatientIVLine(flag_saline_lock)) of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
							if ( Convert.ToString(IncidentMain.GetVal(EMSReport.EMSPatientIVLine["flag_saline_lock"])) == "1" )
							{
								ViewModel.sprEMSReport.Text = "Yes";
							}
							else
							{
								ViewModel.sprEMSReport.Text = "No";
							}
							ViewModel.CurrRow += 2;
							ViewModel.PageCountRow += 2;
							ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
							EMSReport.EMSPatientIVLine.MoveNext();
						}
						;
					}
					// Medication 
					if ( EMSReport.GetEMSMedicationReport(ViewModel.PatientID) != 0 )
					{
						ViewModel.CurrRow = ViewModel.SaveRow;
						ViewModel.CurrRow += 3;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 9;
						ViewModel.sprEMSReport.Text = "Medication";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 11;
						ViewModel.sprEMSReport.Text = "Dosage";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;

						while ( !EMSReport.EMSMedication.EOF )
						{
							(ViewModel.CurrRow)++;
							ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
							ViewModel.sprEMSReport.Col = 9;
							ViewModel.sprEMSReport.FontSize = 7;
							ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSMedication["description"]);
							ViewModel.sprEMSReport.Col = 11;
							ViewModel.sprEMSReport.FontSize = 7;
							ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSMedication["administered_dosage"]);
							EMSReport.EMSMedication.MoveNext();
						}
						;
					}
					if ( ViewModel.CurrRow > ViewModel.SaveRow )
					{
						ViewModel.PageCountRow += (ViewModel.CurrRow - ViewModel.SaveRow);
						ViewModel.SaveRow = ViewModel.CurrRow;
					}

					if ( ViewModel.PageCountRow > 51 )
					{
						DisplayHeadings();
					}
					// ****** Patient Transport  ***** 
					if ( EMSReport.GetEMSPatientTransportReport(ViewModel.PatientID) != 0 )
					{
						ViewModel.CurrRow += 2;
						ViewModel.PageCountRow += 2;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 1;
						ViewModel.sprEMSReport.Text = "Patient Transport";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontItalic = true;
						ViewModel.sprEMSReport.FontSize = 10;
						ViewModel.sprEMSReport.BlockMode = true;
						ViewModel.sprEMSReport.Row2 = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col2 = 11;
						ViewModel.sprEMSReport.BackColor = IncidentMain.Shared.LTGRAY;
						ViewModel.sprEMSReport.BlockMode = false;
						(ViewModel.CurrRow)++;
						(ViewModel.PageCountRow)++;
						ViewModel.SaveRow = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 1;
						ViewModel.sprEMSReport.Text = "Base Station Contact:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 3;
						ViewModel.sprEMSReport.FontSize = 7;
						ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientTransport["base_station_desc"]);
						ViewModel.sprEMSReport.Col = 7;
						ViewModel.sprEMSReport.Text = "Transported To:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 9;
						ViewModel.sprEMSReport.FontSize = 7;
						ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientTransport["transported_to_desc"]);
						(ViewModel.CurrRow)++;
						(ViewModel.PageCountRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 1;
						ViewModel.sprEMSReport.Text = "Contact Person:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 3;
						ViewModel.sprEMSReport.FontSize = 7;
						ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientTransport["staff_type"]);
						ViewModel.sprEMSReport.Col = 7;
						ViewModel.sprEMSReport.Text = "Transported From:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 8;
						ViewModel.sprEMSReport.FontSize = 7;
						ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientTransport["transported_from_desc"]);
						(ViewModel.CurrRow)++;
						(ViewModel.PageCountRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 7;
						ViewModel.sprEMSReport.Text = "Mileage:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 8;
						ViewModel.sprEMSReport.FontSize = 7;
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprEMSReport.Text = Convert.ToString(IncidentMain.GetVal(EMSReport.EMSPatientTransport["mileage"]));
						ViewModel.sprEMSReport.Col = 9;
						ViewModel.sprEMSReport.Text = "Diverted?:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 10;
						ViewModel.sprEMSReport.FontSize = 7;
						if ( ViewModel.sprEMSReport.Text == Convert.ToString(EMSReport.EMSPatientTransport["flag_diverted"]) )
						{
							ViewModel.sprEMSReport.Text = "Yes";
						}
						else
						{
							ViewModel.sprEMSReport.Text = "No";
						}
						(ViewModel.CurrRow)++;
						(ViewModel.PageCountRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 7;
						ViewModel.sprEMSReport.Text = "Hospital Chosen By:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 9;
						ViewModel.sprEMSReport.FontSize = 7;
						ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientTransport["hosp_chosen_by_desc"]);
						(ViewModel.CurrRow)++;
						(ViewModel.PageCountRow)++;

					}
					ViewModel.SaveRow = ViewModel.CurrRow;
					if ( ViewModel.PageCountRow > 51 )
					{
						DisplayHeadings();
					}
					// ****** CPR Detail Information  ***** 
					if ( EMSReport.GetEMSCPRPerformerReport(ViewModel.PatientID) != 0 )
					{
						ViewModel.CurrRow += 2;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 1;
						ViewModel.sprEMSReport.Text = "CPR Information";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontItalic = true;
						ViewModel.sprEMSReport.FontSize = 10;
						ViewModel.sprEMSReport.BlockMode = true;
						ViewModel.sprEMSReport.Row2 = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col2 = 11;
						ViewModel.sprEMSReport.BackColor = IncidentMain.Shared.LTGRAY;
						ViewModel.sprEMSReport.BlockMode = false;
						(ViewModel.CurrRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 1;
						ViewModel.sprEMSReport.Text = "CPR Performed By:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						(ViewModel.CurrRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 1;
						ViewModel.sprEMSReport.Text = "CPR Trained?:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						(ViewModel.CurrRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 1;
						ViewModel.sprEMSReport.Text = "Witnessed Arrest?:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.CurrRow -= 2;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 3;
						ViewModel.sprEMSReport.FontSize = 7;
						ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSCPRPerformer["performed_by_desc"]);
						(ViewModel.CurrRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 3;
						ViewModel.sprEMSReport.FontSize = 7;
						if ( Convert.ToDouble(EMSReport.EMSCPRPerformer["flag_witnessed_arrest"]) != 0 )
						{
							ViewModel.sprEMSReport.Text = "Yes";
						}
						else
						{
							ViewModel.sprEMSReport.Text = "No";
						}
						(ViewModel.CurrRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.FontSize = 7;
						if ( Convert.ToDouble(EMSReport.EMSCPRPerformer["flag_cpr_trained"]) != 0 )
						{
							ViewModel.sprEMSReport.Text = "Yes";
						}
						else
						{
							ViewModel.sprEMSReport.Text = "No";
						}
						(ViewModel.CurrRow)++;
						ViewModel.SaveRow = ViewModel.CurrRow;
						ViewModel.PageCountRow += 5;
					}
					if ( EMSReport.GetEMSCPRReport(ViewModel.PatientID) != 0 )
					{
						//CPR Patient Times Information
						ViewModel.CurrRow -= 3;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 7;
						ViewModel.sprEMSReport.Text = "Arrest to CPR:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						(ViewModel.CurrRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 7;
						ViewModel.sprEMSReport.Text = "Arrest to ALS:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						(ViewModel.CurrRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 7;
						ViewModel.sprEMSReport.Text = "Arrest to Shock:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						(ViewModel.CurrRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 7;
						ViewModel.sprEMSReport.Text = "Pulse Restored?:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.CurrRow -= 3;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 9;
						ViewModel.sprEMSReport.FontSize = 7;
						ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSCPR["arrest_to_cpr_desc"]);
						(ViewModel.CurrRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 9;
						ViewModel.sprEMSReport.FontSize = 7;
						ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSCPR["arrest_to_als_desc"]);
						(ViewModel.CurrRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 9;
						ViewModel.sprEMSReport.FontSize = 7;
						ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSCPR["arrest_to_shock_desc"]);
						(ViewModel.CurrRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 9;
						ViewModel.sprEMSReport.FontSize = 7;
						if ( Convert.ToDouble(EMSReport.EMSCPR["flag_pulse_restored"]) != 0 )
						{
							ViewModel.sprEMSReport.Text = "Yes";
						}
						else
						{
							ViewModel.sprEMSReport.Text = "No";
						}
						ViewModel.SaveRow = ViewModel.CurrRow;
						ViewModel.PageCountRow += 5;
					}

					if ( ViewModel.SaveRow > ViewModel.CurrRow )
					{
						ViewModel.CurrRow = ViewModel.SaveRow;
					}
					if ( ViewModel.PageCountRow > 51 )
					{
						DisplayHeadings();
					}

					//***** Major Patient Trauma Information ***** 
					if ( EMSReport.GetEMSPatientTraumaReport(ViewModel.PatientID) != 0 )
					{
						ViewModel.CurrRow += 2;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 1;
						ViewModel.sprEMSReport.Text = "Patient Trauma Information";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontItalic = true;
						ViewModel.sprEMSReport.FontSize = 10;
						ViewModel.sprEMSReport.BlockMode = true;
						ViewModel.sprEMSReport.Row2 = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col2 = 11;
						ViewModel.sprEMSReport.BackColor = IncidentMain.Shared.LTGRAY;
						ViewModel.sprEMSReport.BlockMode = false;
						(ViewModel.CurrRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 1;
						ViewModel.sprEMSReport.Text = "Trauma ID:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 2;
						ViewModel.sprEMSReport.FontSize = 7;
						ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientTrauma["trauma_id"]);
						(ViewModel.CurrRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 1;
						ViewModel.sprEMSReport.Text = "Revised Trauma Score:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 3;
						ViewModel.sprEMSReport.FontSize = 7;
						ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientTrauma["revised_trauma_score"]);
						(ViewModel.CurrRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 1;
						ViewModel.sprEMSReport.Text = "Protective Device:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 2;
						ViewModel.sprEMSReport.FontSize = 7;
						ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientTrauma["protect_device_desc"]);
						(ViewModel.CurrRow)++;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 1;
						ViewModel.sprEMSReport.Text = "Patient Location:";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;
						ViewModel.sprEMSReport.Col = 2;
						ViewModel.sprEMSReport.FontSize = 7;
						ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSPatientTrauma["location_desc"]);
						ViewModel.PageCountRow += 6;
						ViewModel.SaveRow = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;

					}

					//*****  Trauma Descriptor Information ***** 
					//               Test for existance of Trauma Descriptor Records 
					//               and adjust CurrRow if needed 
					if ( EMSReport.GetEMSTraumaDescriptorReport(ViewModel.PatientID, 1) != 0 )
					{
						ViewModel.CurrRow -= 3;
					}
					else if ( EMSReport.GetEMSTraumaDescriptorReport(ViewModel.PatientID, 2) != 0 )
					{
						ViewModel.CurrRow -= 3;
					}
					else if ( EMSReport.GetEMSTraumaDescriptorReport(ViewModel.PatientID, 3) != 0 )
					{
						ViewModel.CurrRow -= 3;
					}
					//               Step I - Vital Signs 
					if ( EMSReport.GetEMSTraumaDescriptorReport(ViewModel.PatientID, 1) != 0 )
					{
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 4;
						ViewModel.sprEMSReport.Text = "Step I - Vital Signs";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;

						while ( !EMSReport.EMSTraumaDescriptor.EOF )
						{
							ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
							ViewModel.sprEMSReport.Col = 7;
							ViewModel.sprEMSReport.FontSize = 7;
							ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSTraumaDescriptor["trauma_desc"]);
							(ViewModel.CurrRow)++;
							EMSReport.EMSTraumaDescriptor.MoveNext();
						}
						;
					}
					(ViewModel.CurrRow)++;
					//               Step II - Anatomy of Injury 
					if ( EMSReport.GetEMSTraumaDescriptorReport(ViewModel.PatientID, 2) != 0 )
					{
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 4;
						ViewModel.sprEMSReport.Text = "Step II - Anatomy of Injury";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;

						while ( !EMSReport.EMSTraumaDescriptor.EOF )
						{
							ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
							ViewModel.sprEMSReport.Col = 7;
							ViewModel.sprEMSReport.FontSize = 7;
							ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSTraumaDescriptor["trauma_desc"]);
							(ViewModel.CurrRow)++;
							EMSReport.EMSTraumaDescriptor.MoveNext();
						}
						;
					}
					(ViewModel.CurrRow)++;
					//               Step III - Biomechanics 
					if ( EMSReport.GetEMSTraumaDescriptorReport(ViewModel.PatientID, 3) != 0 )
					{
						ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
						ViewModel.sprEMSReport.Col = 4;
						ViewModel.sprEMSReport.Text = "Step III - Biomechanics";
						ViewModel.sprEMSReport.FontBold = true;
						ViewModel.sprEMSReport.FontSize = 8;

						while ( !EMSReport.EMSTraumaDescriptor.EOF )
						{
							ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
							ViewModel.sprEMSReport.Col = 7;
							ViewModel.sprEMSReport.FontSize = 7;
							ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.EMSTraumaDescriptor["trauma_desc"]);
							(ViewModel.CurrRow)++;
							EMSReport.EMSTraumaDescriptor.MoveNext();
						}
						;
					}
					if ( ViewModel.CurrRow > ViewModel.SaveRow )
					{
						ViewModel.PageCountRow += (ViewModel.CurrRow - ViewModel.SaveRow);
						ViewModel.SaveRow = ViewModel.CurrRow;
					}
					if ( ViewModel.PageCountRow > 51 )
					{
						DisplayHeadings();
					}
					//  **** EMS Narration ***** 
					ViewModel.PageCountRow = ViewModel.CurrRow;
					if ( EMSReport.GetEMSPatientNarrationRS(ViewModel.PatientID) != 0 )
					{

						while ( !EMSReport.EMSPatientNarration.EOF )
						{
							EMSReport.GetEMSPatientNarration(Convert.ToInt32(EMSReport.EMSPatientNarration["ems_narration_id"]));
							if ( ViewModel.PageCountRow > 56 )
							{
								DisplayHeadings();
							}
							(ViewModel.CurrRow)++;
							(ViewModel.PageCountRow)++;
							ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
							ViewModel.sprEMSReport.Col = 1;
							ViewModel.sprEMSReport.Text = "Patient Narration";
							ViewModel.sprEMSReport.FontBold = true;
							ViewModel.sprEMSReport.FontItalic = true;
							ViewModel.sprEMSReport.FontSize = 10;
							ViewModel.sprEMSReport.BlockMode = true;
							ViewModel.sprEMSReport.Row2 = ViewModel.CurrRow;
							ViewModel.sprEMSReport.Col2 = 11;
							ViewModel.sprEMSReport.BackColor = IncidentMain.Shared.LTGRAY;
							ViewModel.sprEMSReport.BlockMode = false;
							(ViewModel.CurrRow)++;
							(ViewModel.PageCountRow)++;
							ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
							ViewModel.sprEMSReport.Col = 1;
							ViewModel.sprEMSReport.Text = "Narration By:";
							ViewModel.sprEMSReport.FontBold = true;
							ViewModel.sprEMSReport.FontSize = 8;
							ViewModel.sprEMSReport.Col = 2;
							ViewModel.sprEMSReport.FontSize = 7;
							ViewModel.sprEMSReport.Text = IncidentMain.Clean(EMSReport.NarrationBy);
							(ViewModel.CurrRow)++;
							(ViewModel.PageCountRow)++;
							ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
							ViewModel.sprEMSReport.Col = 1;
							ViewModel.sprEMSReport.Text = "Last Update Date:";
							ViewModel.sprEMSReport.FontBold = true;
							ViewModel.sprEMSReport.FontSize = 8;
							ViewModel.sprEMSReport.Col = 2;
							ViewModel.sprEMSReport.FontSize = 7;
							ViewModel.sprEMSReport.Text = DateTime.Parse(EMSReport.NarrationDate).ToString("M/d/yyyy");
							(ViewModel.CurrRow)++;
							(ViewModel.PageCountRow)++;
							ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
							ViewModel.sprEMSReport.Col = 1;
							ViewModel.sprEMSReport.Text = "Narration:";
							ViewModel.sprEMSReport.FontBold = true;
							ViewModel.sprEMSReport.FontSize = 8;
							ViewModel.sprEMSReport.Col = 2;
							ViewModel.sprEMSReport.FontSize = 7;
							(ViewModel.CurrRow)++;
							(ViewModel.PageCountRow)++;
							ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
							sDisplay = IncidentMain.Clean(EMSReport.NarrationText);
							//                    sDisplay = Left$(sDisplay, Len(sDisplay) - 1)
							ViewModel.LastRow = Strings.Len(sDisplay) / 70;
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
							ViewModel.sprEMSReport.BlockMode = true;
							ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
							ViewModel.sprEMSReport.Row2 = ViewModel.CurrRow + ViewModel.LastRow;
							ViewModel.sprEMSReport.Col = 2;
							ViewModel.sprEMSReport.Col2 = 9;
							ViewModel.sprEMSReport.CellType = FarPoint.ViewModels.Cells.FpCellType.CellTypeStaticText;
							(ViewModel.sprEMSReport.ActiveSheet.Cells[ViewModel.sprEMSReport.Row, ViewModel.sprEMSReport.Col].CellType as FarPoint.ViewModels.TextCellType).WordWrap = true;
							ViewModel.sprEMSReport.BlockMode = false;
							//UPGRADE_ISSUE: (2064) FPSpread.vaSpread method sprEMSReport.AddCellSpan was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.sprEMSReport.AddCellSpan(2, ViewModel.CurrRow, 8, ViewModel.LastRow);
							ViewModel.sprEMSReport.Row = ViewModel.CurrRow;
							ViewModel.sprEMSReport.Col = 2;
							ViewModel.sprEMSReport.Text = sDisplay;
							ViewModel.CurrRow = ViewModel.CurrRow + ViewModel.LastRow + 1;
							ViewModel.sprEMSReport.Row = ViewModel.CurrRow;


							//                    sDisplay = Clean(EMSReport.NarrationText)
							//                    sDisplay = Left$(sDisplay, Len(sDisplay) - 1)
							//                    For i = 0 To CInt(Len(sDisplay) / 100)
							//                         sprEMSReport.Row = CurrRow
							//                         sprEMSReport.Text = Mid$(sDisplay, (100 * i) + 1, 100)
							//                         If Right$(sprEMSReport.Text, 1) <> " " Then
							//                             If Right$(sprEMSReport.Text, 1) <> "." Then
							//                                 sprEMSReport.Text = sprEMSReport.Text & "-"
							//                             End If
							//                         End If
							//                         CurrRow = CurrRow + 1
							//                         PageCountRow = PageCountRow + 1
							//                         If PageCountRow > 56 Then DisplayHeadings
							//                    Next i
							EMSReport.EMSPatientNarration.MoveNext();
						};
						}
					break;
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
			using ( var async1 = this.Async(true) )
			{
				//Determine which report to print
				UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;

				string msg = "Printing Records Access History prior to printing" + "\n";
				msg = msg + "Patient Care Report may result in inaccurate access reporting." + "\n";
				msg = msg + "Please Cancel if you intend to print Patient Care Report at this time";


				if ( ViewModel.sprHIPAAReport.Visible )
				{
					if ( IncidentMain.Shared.gHIPAAState == 1 || IncidentMain.Shared.gHIPAAState == 3 )
					{
						async1.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage(msg, "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OKCancel));
						async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
						async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
							{
								Response = tempNormalized1;
							});
						async1.Append(() =>
							{
								if ( Response == UpgradeHelpers.Helpers.DialogResult.Cancel )
								{
									this.Return();
									return ;
								}
							});
					}
					async1.Append(() =>
						{
							//Print HIPAA Access History Report
							//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprHIPAAReport.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.sprHIPAAReport.setPrintAbortMsg("Printing HIPAA Access History Report - Click Cancel to quit");
							//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprHIPAAReport.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.sprHIPAAReport.setPrintBorder(false);
							//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprHIPAAReport.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.sprHIPAAReport.setPrintColor(true);
							//UPGRADE_ISSUE: (2064) FPSpread.PrintOrientationConstants property PrintOrientationConstants.PrintOrientationPortrait was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
								//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprHIPAAReport.PrintOrientation was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.sprHIPAAReport.setPrintOrientation(UpgradeStubs.FPSpread_PrintOrientationConstants.getPrintOrientationPortrait());
							ViewModel.sprHIPAAReport.Action = FarPoint.ViewModels.FPActionConstants.ActionSmartPrint;
						});
				}
				else
				{
					//Print Patient Contact Report
					//Update HIPAA State to Print - Display Release Info Dialog
					if ( IncidentMain.Shared.gHIPAAState == 1 )
					{
						IncidentMain.Shared.gHIPAAState = 2;
					}
					else if ( IncidentMain.Shared.gHIPAAState == 3 )
					{
						IncidentMain.Shared.gHIPAAState = 4;
					}
					IncidentMain.Shared.gHIPAAOK = 0;
					IncidentMain.Shared.gHIPAAPatientID = ViewModel.PatientID;
					async1.Append(() =>
						{
							ViewManager.NavigateToView(
								dlgHIPAAMsg.DefInstance, true);
						});
					async1.Append(() =>
						{
							LoadHIPAAReport();

							//If HIPAA release info correctly completed, print report
							if ( IncidentMain.Shared.gHIPAAOK != 0 )
							{
								//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprEMSReport.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
								ViewModel.sprEMSReport.setPrintAbortMsg("Printing EMS Patient Contact Report - Click Cancel to quit");
								//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprEMSReport.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
								ViewModel.sprEMSReport.setPrintBorder(false);
								//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprEMSReport.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
								ViewModel.sprEMSReport.setPrintColor(true);
								//UPGRADE_ISSUE: (2064) FPSpread.PrintOrientationConstants property PrintOrientationConstants.PrintOrientationPortrait was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
									//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprEMSReport.PrintOrientation was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
								ViewModel.sprEMSReport.setPrintOrientation(UpgradeStubs.FPSpread_PrintOrientationConstants.getPrintOrientationPortrait());
								ViewModel.sprEMSReport.Action = FarPoint.ViewModels.FPActionConstants.ActionSmartPrint;
							}
						});
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdViewHIPAA_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Toggle visible Report and button caption
			if ( ViewModel.cmdViewHIPAA.Text == "View HIPAA Access" )
			{
				//Display HIPAA Access Report
				ViewModel.sprEMSReport.Visible = false;
				ViewModel.sprHIPAAReport.Visible = true;
				ViewModel.cmdViewHIPAA.Text = "View Patient Report";
			}
			else
			{
				//Display Patient Contact Report
				ViewModel.sprEMSReport.Visible = true;
				ViewModel.sprHIPAAReport.Visible = false;
				ViewModel.cmdViewHIPAA.Text = "View HIPAA Access";
			}

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			//Produce EMS Patient Contact Print Preview
			//Using global gPrintReportID parameter
			ViewModel.PatientID = IncidentMain.Shared.gPrintReportID;
			ViewModel.cmdViewHIPAA.Text = "View HIPAA Access";
			ViewModel.cmdPrint.Text = "Print Report";
			LoadEMSReport();
			LoadHIPAAReport();
			ViewModel.sprHIPAAReport.Visible = false;
			ViewModel.sprEMSReport.Visible = true;


		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmReportEMS DefInstance
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

		public static frmReportEMS CreateInstance()
		{
			TFDIncident.frmReportEMS theInstance = Shared.Container.Resolve<frmReportEMS>();
			theInstance.Form_Load();
			return theInstance;
		}

		protected override void ExecuteControlsStartup()
		{
			ViewModel.sprHIPAAReport.LifeCycleStartup();
			ViewModel.sprEMSReport.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprHIPAAReport.LifeCycleShutdown();
			ViewModel.sprEMSReport.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmReportEMS
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.frmReportEMSViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmReportEMS m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}