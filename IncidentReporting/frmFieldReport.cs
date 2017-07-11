using System;
using UpgradeHelpers.DB.ADO;
using UpgradeStubs;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident
{

	public partial class frmFieldReport
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.frmFieldReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmFieldReport));
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


		private void frmFieldReport_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender )
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>)eventSender;
			}
		}

		//UPGRADE_ISSUE: (2068) PrintOrientationConstants object was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2068.aspx
		//UPGRADE_ISSUE: (2064) FPSpread.PrintOrientationConstants property PrintOrientationConstants.PrintOrientationDefault was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx

		private void FillSpread()
		{
			//FillSpread with Results from DataInquiry Recordset
			TFDIncident.clsInquiry InquiryCL = Container.Resolve<clsInquiry>();
			string EmpID = "";
			string UnitID = "", Shift = "";
			string DisplayMonth = "", CurrMonth = "";
			int MonthTotal = 0, UnitTotal = 0;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
			this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.WaitCursor);
			//UPGRADE_WARNING: (1068) frmMain.calFRStart.Value of type Variant is being forced to DateTime. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.MonthCalendar.SelectionStart was not upgraded
			string StartDate = Convert.ToDateTime(frmMain.DefInstance.ViewModel.calFRStart.Value).ToString("MM/dd/yyyy");
			//UPGRADE_WARNING: (1068) frmMain.calFREnd.Value of type Variant is being forced to DateTime. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.MonthCalendar.SelectionStart was not upgraded
			string EndDate = Convert.ToDateTime(frmMain.DefInstance.ViewModel.calFREnd.Value).ToString("MM/dd/yyyy");
			ViewModel.sprQuery.Row = 4;
			ViewModel.sprQuery.Col = 2;
			ViewModel.sprQuery.Text = DateTime.Now.ToString("M/d/yyyy");
			ViewModel.sprQuery.Row = 5;
			ViewModel.sprQuery.Text = frmMain.DefInstance.ViewModel.cboFieldReport.Text;
			int CurrRow = 5;
			ViewModel.sprQuery.Row = CurrRow;

			switch ( frmMain.DefInstance.ViewModel.cboFieldReport.GetItemData(frmMain.DefInstance.ViewModel.cboFieldReport.SelectedIndex) )
			{
				case 2:
					//OTEP Procedures Report 
					EmpID = frmMain.DefInstance.ViewModel.cboSelection1.Text.Substring(Math.Max(frmMain.DefInstance.ViewModel.cboSelection1.Text.Length - 5, 0));
					ViewModel.sprQuery.Text = "Start Date: " + StartDate;
					CurrRow++;
					ViewModel.sprQuery.Row = CurrRow;
					ViewModel.sprQuery.Text = "End Date: " + EndDate;
					EndDate = DateTime.Parse(EndDate).AddDays(1).ToString("MM/dd/yyyy");
					CurrRow++;
					ViewModel.sprQuery.Row = CurrRow;
					ViewModel.sprQuery.Text = "Employee: " + frmMain.DefInstance.ViewModel.cboSelection1.Text;
					CurrRow++;
					ViewModel.sprQuery.Row = CurrRow;
					ViewModel.sprQuery.Col = 1;
					ViewModel.sprQuery.Text = "OTEP Procedure";
					ViewModel.sprQuery.Col = 2;
					ViewModel.sprQuery.Text = "Incident #";
					ViewModel.sprQuery.Col = 3;
					ViewModel.sprQuery.Text = "Incident Date";
					ViewModel.sprQuery.BlockMode = true;
					ViewModel.sprQuery.Row2 = CurrRow;
					ViewModel.sprQuery.Col = 1;
					ViewModel.sprQuery.Col2 = 5;
					ViewModel.sprQuery.BackColor = IncidentMain.Shared.LTGRAY;
					ViewModel.sprQuery.FontBold = true;
					ViewModel.sprQuery.BlockMode = false;

					CurrRow++;

					if ( InquiryCL.GetOtepReport(StartDate, EndDate, EmpID) != 0 )
					{

						while ( !InquiryCL.FieldReport.EOF )
						{
							ViewModel.sprQuery.Row = CurrRow;
							ViewModel.sprQuery.Col = 1;
							ViewModel.sprQuery.Text = IncidentMain.Clean(InquiryCL.FieldReport["description"]);
							ViewModel.sprQuery.Col = 2;
							ViewModel.sprQuery.Text = IncidentMain.Clean(InquiryCL.FieldReport["incident_number"]);
							ViewModel.sprQuery.Col = 3;
							System.DateTime TempDate = DateTime.FromOADate(0);
							ViewModel.sprQuery.Text = (DateTime.TryParse(IncidentMain.Clean(InquiryCL.FieldReport["date_incident_created"]), out TempDate)) ? TempDate.ToString("M/d/yyyy HH:mm") : IncidentMain.Clean(InquiryCL.FieldReport["date_incident_created"]);
							InquiryCL.FieldReport.MoveNext();
							CurrRow++;
						};
						}
					break;
				case 4:
					//ALS Procedures Report 
					EmpID = frmMain.DefInstance.ViewModel.cboSelection1.Text.Substring(Math.Max(frmMain.DefInstance.ViewModel.cboSelection1.Text.Length - 5, 0));
					ViewModel.sprQuery.Text = "Start Date: " + StartDate;
					CurrRow++;
					ViewModel.sprQuery.Row = CurrRow;
					ViewModel.sprQuery.Text = "End Date: " + EndDate;
					EndDate = DateTime.Parse(EndDate).AddDays(1).ToString("MM/dd/yyyy");
					CurrRow++;
					ViewModel.sprQuery.Row = CurrRow;
					ViewModel.sprQuery.Text = "Employee: " + frmMain.DefInstance.ViewModel.cboSelection1.Text;
					CurrRow++;
					ViewModel.sprQuery.Row = CurrRow;
					ViewModel.sprQuery.Col = 1;
					ViewModel.sprQuery.Text = "ALS Procedure";
					ViewModel.sprQuery.Col = 2;
					ViewModel.sprQuery.Text = "Attempts";
					ViewModel.sprQuery.Col = 3;
					ViewModel.sprQuery.Text = "Successful?";
					ViewModel.sprQuery.Col = 4;
					ViewModel.sprQuery.Text = "Incident #";
					ViewModel.sprQuery.Col = 5;
					ViewModel.sprQuery.Text = "Incident Date";
					ViewModel.sprQuery.BlockMode = true;
					ViewModel.sprQuery.Row2 = CurrRow;
					ViewModel.sprQuery.Col = 1;
					ViewModel.sprQuery.Col2 = 6;
					ViewModel.sprQuery.BackColor = IncidentMain.Shared.LTGRAY;
					ViewModel.sprQuery.FontBold = true;
					ViewModel.sprQuery.BlockMode = false;

					CurrRow++;

					if ( InquiryCL.GetALSReport(StartDate, EndDate, EmpID) != 0 )
					{

						while ( !InquiryCL.FieldReport.EOF )
						{
							ViewModel.sprQuery.Row = CurrRow;
							ViewModel.sprQuery.Col = 1;
							ViewModel.sprQuery.Text = IncidentMain.Clean(InquiryCL.FieldReport["description"]);
							ViewModel.sprQuery.Col = 2;
							ViewModel.sprQuery.Text = IncidentMain.Clean(InquiryCL.FieldReport["attempts"]);
							ViewModel.sprQuery.Col = 3;
							if ( Convert.ToBoolean(InquiryCL.FieldReport["flag_successful"]) )
							{
								ViewModel.sprQuery.Text = "Yes";
							}
							else
							{
								ViewModel.sprQuery.Text = "No";
							}
							ViewModel.sprQuery.Col = 4;
							ViewModel.sprQuery.Text = Convert.ToString(InquiryCL.FieldReport["incident_number"]);
							ViewModel.sprQuery.Col = 5;
							ViewModel.sprQuery.Text = Convert.ToDateTime(InquiryCL.FieldReport["date_incident_created"]).ToString("M/d/yyyy HH:mm");
							InquiryCL.FieldReport.MoveNext();
							CurrRow++;
						};
						}
					break;
				case 7:
					//Unit Response Summary 
					UnitID = frmMain.DefInstance.ViewModel.cboSelection1.Text;
					Shift = frmMain.DefInstance.ViewModel.cboSelection2.Text;
					ViewModel.sprQuery.Text = "Start Date: " + StartDate;
					CurrRow++;
					ViewModel.sprQuery.Row = CurrRow;
					ViewModel.sprQuery.Text = "End Date: " + EndDate;
					EndDate = DateTime.Parse(EndDate).AddDays(1).ToString("MM/dd/yyyy");
					CurrRow++;
					ViewModel.sprQuery.Row = CurrRow;
					ViewModel.sprQuery.Text = "Unit: " + UnitID;
					CurrRow++;
					ViewModel.sprQuery.Row = CurrRow;
					ViewModel.sprQuery.Text = "Shift: " + Shift;
					if ( Shift == "All Shifts" )
					{
						Shift = "";
					}
					CurrRow++;
					ViewModel.sprQuery.Row = CurrRow;
					ViewModel.sprQuery.Col = 1;
					ViewModel.sprQuery.Text = "Month";
					ViewModel.sprQuery.Col = 2;
					ViewModel.sprQuery.Text = "Response Type";
					ViewModel.sprQuery.Col = 3;
					ViewModel.sprQuery.Text = "Unit Response Count";
					ViewModel.sprQuery.BlockMode = true;
					ViewModel.sprQuery.Row2 = CurrRow;
					ViewModel.sprQuery.Col = 1;
					ViewModel.sprQuery.Col2 = 3;
					ViewModel.sprQuery.BackColor = IncidentMain.Shared.LTGRAY;
					ViewModel.sprQuery.FontBold = true;
					ViewModel.sprQuery.BlockMode = false;

					CurrRow++;

					if ( InquiryCL.GetUnitSummary(UnitID, Shift, StartDate, EndDate) != 0 )
					{
						DisplayMonth = Convert.ToString(InquiryCL.FieldReport["incident_month"]) + "/" + Convert.ToString(InquiryCL.FieldReport["incident_year"]);

						while ( !InquiryCL.FieldReport.EOF )
						{
							ViewModel.sprQuery.Row = CurrRow;
							ViewModel.sprQuery.Col = 1;
							CurrMonth = Convert.ToString(InquiryCL.FieldReport["incident_month"]) + "/" + Convert.ToString(InquiryCL.FieldReport["incident_year"]);
							if ( DisplayMonth == CurrMonth )
							{
								ViewModel.sprQuery.Text = CurrMonth;
								ViewModel.sprQuery.Col = 2;
								ViewModel.sprQuery.Text = IncidentMain.Clean(InquiryCL.FieldReport["description"]);
								ViewModel.sprQuery.Col = 3;
								ViewModel.sprQuery.Text = IncidentMain.Clean(InquiryCL.FieldReport["unit_count"]);
								MonthTotal = Convert.ToInt32(MonthTotal + Convert.ToDouble(InquiryCL.FieldReport["unit_count"]));
								InquiryCL.FieldReport.MoveNext();
								CurrRow++;
							}
							else
							{
								ViewModel.sprQuery.Text = "Total for " + DisplayMonth;
								ViewModel.sprQuery.Col = 3;
								ViewModel.sprQuery.Text = MonthTotal.ToString();
								ViewModel.sprQuery.BlockMode = true;
								ViewModel.sprQuery.Row2 = CurrRow;
								ViewModel.sprQuery.Col = 1;
								ViewModel.sprQuery.Col2 = 3;
								ViewModel.sprQuery.BackColor = IncidentMain.Shared.LTGRAY;
								ViewModel.sprQuery.FontBold = true;
								ViewModel.sprQuery.BlockMode = false;
								CurrRow += 2;
								DisplayMonth = CurrMonth;
								UnitTotal += MonthTotal;
								MonthTotal = 0;
							}
						};
						//Last total
						ViewModel.sprQuery.Row = CurrRow;
						ViewModel.sprQuery.Col = 1;
						ViewModel.sprQuery.Text = "Total for " + DisplayMonth;
						ViewModel.sprQuery.Col = 3;
						ViewModel.sprQuery.Text = MonthTotal.ToString();
						UnitTotal += MonthTotal;
						ViewModel.sprQuery.BlockMode = true;
						ViewModel.sprQuery.Row2 = CurrRow;
						ViewModel.sprQuery.Col = 1;
						ViewModel.sprQuery.Col2 = 3;
						ViewModel.sprQuery.BackColor = IncidentMain.Shared.LTGRAY;
						ViewModel.sprQuery.FontBold = true;
						ViewModel.sprQuery.BlockMode = false;
						ViewModel.sprQuery.Row = CurrRow + 2;
						ViewModel.sprQuery.Col = 1;
						ViewModel.sprQuery.Text = "Total for Reporting Period";
						ViewModel.sprQuery.Col = 3;
						ViewModel.sprQuery.Text = UnitTotal.ToString();
						ViewModel.sprQuery.BlockMode = true;
						ViewModel.sprQuery.Row2 = CurrRow;
						ViewModel.sprQuery.Col = 1;
						ViewModel.sprQuery.Col2 = 3;
						ViewModel.sprQuery.BackColor = IncidentMain.Shared.LTGRAY;
						ViewModel.sprQuery.FontBold = true;
						ViewModel.sprQuery.BlockMode = false;
					}
					break;
				case 8:
					//Unit Reporting Status 
					//Includes both Summary and detail of Incomplete Reports 
					UnitID = frmMain.DefInstance.ViewModel.cboSelection1.Text;
					Shift = frmMain.DefInstance.ViewModel.cboSelection2.Text;
					ViewModel.sprQuery.Text = "Start Date: " + StartDate;
					CurrRow++;
					ViewModel.sprQuery.Row = CurrRow;
					ViewModel.sprQuery.Text = "End Date: " + EndDate;
					EndDate = DateTime.Parse(EndDate).AddDays(1).ToString("MM/dd/yyyy");
					CurrRow++;
					ViewModel.sprQuery.Row = CurrRow;
					ViewModel.sprQuery.Text = "Unit: " + UnitID;
					CurrRow++;
					ViewModel.sprQuery.Row = CurrRow;
					ViewModel.sprQuery.Text = "Shift: " + Shift;
					if ( Shift == "All Shifts" )
					{
						Shift = "";
					}
					CurrRow++;
					ViewModel.sprQuery.Row = CurrRow;
					ViewModel.sprQuery.Col = 1;
					ViewModel.sprQuery.Text = "Unit Reporting Summary";
					ViewModel.sprQuery.FontBold = true;
					CurrRow++;
					ViewModel.sprQuery.Row = CurrRow;
					ViewModel.sprQuery.Col = 1;
					ViewModel.sprQuery.Text = "Month";
					ViewModel.sprQuery.Col = 2;
					ViewModel.sprQuery.Text = "Report Description";
					ViewModel.sprQuery.Col = 3;
					ViewModel.sprQuery.Text = "Report Status";
					ViewModel.sprQuery.Col = 4;
					ViewModel.sprQuery.Text = "Report Count";
					ViewModel.sprQuery.BlockMode = true;
					ViewModel.sprQuery.Row = CurrRow - 1;
					ViewModel.sprQuery.Row2 = CurrRow;
					ViewModel.sprQuery.Col = 1;
					ViewModel.sprQuery.Col2 = 4;
					ViewModel.sprQuery.BackColor = IncidentMain.Shared.LTGRAY;
					ViewModel.sprQuery.FontBold = true;
					ViewModel.sprQuery.BlockMode = false;

					CurrRow++;

					if ( InquiryCL.GetUnitReporting(UnitID, Shift, StartDate, EndDate) != 0 )
					{
						DisplayMonth = Convert.ToString(InquiryCL.FieldReport["report_month"]) + "/" + Convert.ToString(InquiryCL.FieldReport["report_year"]);

						while ( !InquiryCL.FieldReport.EOF )
						{
							ViewModel.sprQuery.Row = CurrRow;
							ViewModel.sprQuery.Col = 1;
							CurrMonth = Convert.ToString(InquiryCL.FieldReport["report_month"]) + "/" + Convert.ToString(InquiryCL.FieldReport["report_year"]);
							if ( DisplayMonth == CurrMonth )
							{
								ViewModel.sprQuery.Text = CurrMonth;
								ViewModel.sprQuery.Col = 2;
								ViewModel.sprQuery.Text = IncidentMain.Clean(InquiryCL.FieldReport["report_desc"]);
								ViewModel.sprQuery.Col = 3;
								ViewModel.sprQuery.Text = IncidentMain.Clean(InquiryCL.FieldReport["report_stat"]);
								ViewModel.sprQuery.Col = 4;
								ViewModel.sprQuery.Text = IncidentMain.Clean(InquiryCL.FieldReport["report_count"]);
								MonthTotal = Convert.ToInt32(MonthTotal + Convert.ToDouble(InquiryCL.FieldReport["report_count"]));
								InquiryCL.FieldReport.MoveNext();
								CurrRow++;
							}
							else
							{
								ViewModel.sprQuery.Text = "Total for " + DisplayMonth;
								ViewModel.sprQuery.Col = 4;
								ViewModel.sprQuery.Text = MonthTotal.ToString();
								ViewModel.sprQuery.BlockMode = true;
								ViewModel.sprQuery.Row2 = CurrRow;
								ViewModel.sprQuery.Col = 1;
								ViewModel.sprQuery.Col2 = 4;
								ViewModel.sprQuery.BackColor = IncidentMain.Shared.LTGRAY;
								ViewModel.sprQuery.FontBold = true;
								ViewModel.sprQuery.BlockMode = false;
								CurrRow += 2;
								DisplayMonth = CurrMonth;
								UnitTotal += MonthTotal;
								MonthTotal = 0;
							}
						};
						//Last total
						ViewModel.sprQuery.Row = CurrRow;
						ViewModel.sprQuery.Col = 1;
						ViewModel.sprQuery.Text = "Total for " + DisplayMonth;
						ViewModel.sprQuery.Col = 4;
						ViewModel.sprQuery.Text = MonthTotal.ToString();
						ViewModel.sprQuery.BlockMode = true;
						ViewModel.sprQuery.Row2 = CurrRow;
						ViewModel.sprQuery.Col = 1;
						ViewModel.sprQuery.Col2 = 4;
						ViewModel.sprQuery.BackColor = IncidentMain.Shared.LTGRAY;
						ViewModel.sprQuery.FontBold = true;
						ViewModel.sprQuery.BlockMode = false;
						CurrRow += 2;
						ViewModel.sprQuery.Row = CurrRow;
						ViewModel.sprQuery.Col = 1;
						ViewModel.sprQuery.Text = "Total for Reporting Period";
						ViewModel.sprQuery.Col = 4;
						ViewModel.sprQuery.Text = UnitTotal.ToString();
						ViewModel.sprQuery.BlockMode = true;
						ViewModel.sprQuery.Row2 = CurrRow;
						ViewModel.sprQuery.Col = 1;
						ViewModel.sprQuery.Col2 = 4;
						ViewModel.sprQuery.BackColor = IncidentMain.Shared.LTGRAY;
						ViewModel.sprQuery.FontBold = true;
						ViewModel.sprQuery.BlockMode = false;
						//Display Detail for Incomplete Reports
						CurrRow += 2;
						ViewModel.sprQuery.Row = CurrRow;
						ViewModel.sprQuery.Col = 1;
						ViewModel.sprQuery.Text = "Report Detail - Incomplete Reports";
						CurrRow++;
						ViewModel.sprQuery.Row = CurrRow;
						ViewModel.sprQuery.Text = "Incident Number";
						ViewModel.sprQuery.Col = 2;
						ViewModel.sprQuery.Text = "Incident Date";
						ViewModel.sprQuery.Col = 3;
						ViewModel.sprQuery.Text = "Report Type";
						ViewModel.sprQuery.Col = 4;
						ViewModel.sprQuery.Text = "Responsible Individual";
						ViewModel.sprQuery.BlockMode = true;
						ViewModel.sprQuery.Row = CurrRow - 1;
						ViewModel.sprQuery.Row2 = CurrRow;
						ViewModel.sprQuery.Col = 1;
						ViewModel.sprQuery.Col2 = 4;
						ViewModel.sprQuery.BackColor = IncidentMain.Shared.LTGRAY;
						ViewModel.sprQuery.FontBold = true;
						ViewModel.sprQuery.BlockMode = false;
						CurrRow++;
						UnitTotal = 0;
						if ( InquiryCL.GetUnitReportsIncomplete(UnitID, Shift, StartDate, EndDate) != 0 )
						{

							while ( !InquiryCL.FieldReport.EOF )
							{
								ViewModel.sprQuery.Row = CurrRow;
								ViewModel.sprQuery.Col = 1;
								ViewModel.sprQuery.Text = IncidentMain.Clean(InquiryCL.FieldReport["incident_number"]);
								ViewModel.sprQuery.Col = 2;
								System.DateTime TempDate2 = DateTime.FromOADate(0);
								ViewModel.sprQuery.Text = (DateTime.TryParse(IncidentMain.Clean(InquiryCL.FieldReport["date_incident_created"]), out TempDate2)) ? TempDate2.ToString("M/d/yyyy HH:mm") : IncidentMain.Clean(InquiryCL.FieldReport["date_incident_created"]);
								ViewModel.sprQuery.Col = 3;
								ViewModel.sprQuery.Text = IncidentMain.Clean(InquiryCL.FieldReport["report_desc"]);
								ViewModel.sprQuery.Col = 4;
								ViewModel.sprQuery.Text = IncidentMain.Clean(InquiryCL.FieldReport["name_full"]);
								InquiryCL.FieldReport.MoveNext();
								CurrRow++;
								UnitTotal++;
							};
							ViewModel.sprQuery.Row = CurrRow;
							ViewModel.sprQuery.Col = 1;
							ViewModel.sprQuery.Text = "Total Incomplete Reports";
							ViewModel.sprQuery.Col = 4;
							ViewModel.sprQuery.Text = UnitTotal.ToString();
							ViewModel.sprQuery.BlockMode = true;
							ViewModel.sprQuery.Row2 = CurrRow;
							ViewModel.sprQuery.Col = 1;
							ViewModel.sprQuery.Col2 = 4;
							ViewModel.sprQuery.BackColor = IncidentMain.Shared.LTGRAY;
							ViewModel.sprQuery.FontBold = true;
							ViewModel.sprQuery.BlockMode = false;
						}
						else
						{
							ViewModel.sprQuery.Row = CurrRow;
							ViewModel.sprQuery.Col = 1;
							ViewModel.sprQuery.Text = "No Incomplete Reports";
						}
					}
					break;
				case 9:
					//Battalion Incomplete Reports 
					ViewModel.sprQuery.SetColWidth(1, 8);
					ViewModel.sprQuery.SetColWidth(2, 10);
					ViewModel.sprQuery.SetColWidth(3, 14.7f);
					ViewModel.sprQuery.SetColWidth(4, 14.7f);
					ViewModel.sprQuery.SetColWidth(5, 16);

					UnitID = frmMain.DefInstance.ViewModel.cboSelection1.Text;
					Shift = frmMain.DefInstance.ViewModel.cboSelection2.Text;
					ViewModel.sprQuery.Col = 3;
					ViewModel.sprQuery.Text = "Start Date: " + StartDate;
					CurrRow++;
					ViewModel.sprQuery.Row = CurrRow;
					ViewModel.sprQuery.Text = "End Date: " + EndDate;
					EndDate = DateTime.Parse(EndDate).AddDays(1).ToString("MM/dd/yyyy");
					CurrRow++;
					ViewModel.sprQuery.Row = CurrRow;
					ViewModel.sprQuery.Text = "Battalion: " + UnitID;
					if ( UnitID == "BC1" )
					{
						UnitID = "1";
					}
					else if ( UnitID == "BC2" )
					{
						UnitID = "2";
					}
					else
					{
						UnitID = "3";
					}
					CurrRow++;
					ViewModel.sprQuery.Row = CurrRow;
					ViewModel.sprQuery.Text = "Shift: " + Shift;
					if ( Shift == "All Shifts" )
					{
						Shift = "";
					}
					CurrRow++;
					ViewModel.sprQuery.Row = CurrRow;
					ViewModel.sprQuery.Col = 1;
					ViewModel.sprQuery.Text = "Unit";
					ViewModel.sprQuery.Col = 2;
					ViewModel.sprQuery.Text = "Incident #";
					ViewModel.sprQuery.Col = 3;
					ViewModel.sprQuery.Text = "Incident Date";
					ViewModel.sprQuery.Col = 4;
					ViewModel.sprQuery.Text = "Report Type";
					ViewModel.sprQuery.Col = 5;
					ViewModel.sprQuery.Text = "Report Status";
					ViewModel.sprQuery.Col = 6;
					ViewModel.sprQuery.Text = "Responsible";
					ViewModel.sprQuery.BlockMode = true;
					ViewModel.sprQuery.Row2 = CurrRow;
					ViewModel.sprQuery.Col = 1;
					ViewModel.sprQuery.Col2 = 6;
					ViewModel.sprQuery.BackColor = IncidentMain.Shared.LTGRAY;
					ViewModel.sprQuery.FontBold = true;
					ViewModel.sprQuery.BlockMode = false;
					CurrRow++;
					UnitTotal = 0;
					if ( InquiryCL.GetBattIncompleteReports(UnitID, Shift, StartDate, EndDate) != 0 )
					{

						while ( !InquiryCL.FieldReport.EOF )
						{
							ViewModel.sprQuery.Row = CurrRow;
							ViewModel.sprQuery.Col = 1;
							ViewModel.sprQuery.Text = IncidentMain.Clean(InquiryCL.FieldReport["responsible_unit_id"]);
							ViewModel.sprQuery.Col = 2;
							ViewModel.sprQuery.Text = IncidentMain.Clean(InquiryCL.FieldReport["incident_number"]);
							ViewModel.sprQuery.Col = 3;
							System.DateTime TempDate3 = DateTime.FromOADate(0);
							ViewModel.sprQuery.Text = (DateTime.TryParse(IncidentMain.Clean(InquiryCL.FieldReport["date_incident_created"]), out TempDate3)) ? TempDate3.ToString("M/d/yyyy HH:mm") : IncidentMain.Clean(InquiryCL.FieldReport["date_incident_created"]);
							ViewModel.sprQuery.Col = 4;
							ViewModel.sprQuery.Text = IncidentMain.Clean(InquiryCL.FieldReport["report_desc"]);
							ViewModel.sprQuery.Col = 5;
							ViewModel.sprQuery.Text = IncidentMain.Clean(InquiryCL.FieldReport["report_stat"]);
							ViewModel.sprQuery.Col = 6;
							ViewModel.sprQuery.Text = IncidentMain.Clean(InquiryCL.FieldReport["name_full"]);
							InquiryCL.FieldReport.MoveNext();
							CurrRow++;
							UnitTotal++;
						};
						ViewModel.sprQuery.Row = CurrRow;
						ViewModel.sprQuery.Col = 1;
						ViewModel.sprQuery.Text = "Total Incomplete Reports";
						ViewModel.sprQuery.Col = 6;
						ViewModel.sprQuery.Text = UnitTotal.ToString();
						ViewModel.sprQuery.BlockMode = true;
						ViewModel.sprQuery.Row2 = CurrRow;
						ViewModel.sprQuery.Col = 1;
						ViewModel.sprQuery.Col2 = 6;
						ViewModel.sprQuery.BackColor = IncidentMain.Shared.LTGRAY;
						ViewModel.sprQuery.FontBold = true;
						ViewModel.sprQuery.BlockMode = false;
					}
					else
					{
						ViewModel.sprQuery.Row = CurrRow;
						ViewModel.sprQuery.Col = 1;
						ViewModel.sprQuery.Text = "No Incomplete Reports";
					}
					break;
				case 10:
					//Unit Activity Report 
					ViewModel.sprQuery.SetColWidth(2, 40);
					UnitID = frmMain.DefInstance.ViewModel.cboSelection1.Text;
					Shift = frmMain.DefInstance.ViewModel.cboSelection2.Text;
					ViewModel.sprQuery.Text = "Start Date: " + StartDate;
					CurrRow++;
					ViewModel.sprQuery.Row = CurrRow;
					ViewModel.sprQuery.Text = "End Date: " + EndDate;
					EndDate = DateTime.Parse(EndDate).AddDays(1).ToString("MM/dd/yyyy");
					CurrRow++;
					ViewModel.sprQuery.Row = CurrRow;
					ViewModel.sprQuery.Text = "Unit: " + UnitID;
					CurrRow++;
					ViewModel.sprQuery.Row = CurrRow;
					ViewModel.sprQuery.Text = "Shift: " + Shift;
					if ( Shift == "All Shifts" )
					{
						Shift = "";
					}
					CurrRow++;
					ViewModel.sprQuery.Row = CurrRow;
					ViewModel.sprQuery.Col = 1;
					ViewModel.sprQuery.Text = "Unit Response Actions";
					CurrRow++;
					ViewModel.sprQuery.Row = CurrRow;
					ViewModel.sprQuery.Text = "Month";
					ViewModel.sprQuery.Col = 2;
					ViewModel.sprQuery.Text = "Unit Action";
					ViewModel.sprQuery.Col = 3;
					ViewModel.sprQuery.Text = "Unit Action Count";
					ViewModel.sprQuery.BlockMode = true;
					ViewModel.sprQuery.Row = CurrRow - 1;
					ViewModel.sprQuery.Row2 = CurrRow;
					ViewModel.sprQuery.Col = 1;
					ViewModel.sprQuery.Col2 = 3;
					ViewModel.sprQuery.BackColor = IncidentMain.Shared.LTGRAY;
					ViewModel.sprQuery.FontBold = true;
					ViewModel.sprQuery.BlockMode = false;
					CurrRow++;

					if ( InquiryCL.GetUnitAction(UnitID, Shift, StartDate, EndDate) != 0 )
					{
						DisplayMonth = Convert.ToString(InquiryCL.FieldReport["action_month"]) + "/" + Convert.ToString(InquiryCL.FieldReport["action_year"]);

						while ( !InquiryCL.FieldReport.EOF )
						{
							ViewModel.sprQuery.Row = CurrRow;
							ViewModel.sprQuery.Col = 1;
							CurrMonth = Convert.ToString(InquiryCL.FieldReport["action_month"]) + "/" + Convert.ToString(InquiryCL.FieldReport["action_year"]);
							if ( DisplayMonth != CurrMonth )
							{
								CurrRow++;
								ViewModel.sprQuery.Row = CurrRow;
								DisplayMonth = CurrMonth;
							}
							ViewModel.sprQuery.Text = CurrMonth;
							ViewModel.sprQuery.Col = 2;
							ViewModel.sprQuery.Text = IncidentMain.Clean(InquiryCL.FieldReport["description"]);
							ViewModel.sprQuery.Col = 3;
							ViewModel.sprQuery.Text = IncidentMain.Clean(InquiryCL.FieldReport["action_count"]);
							InquiryCL.FieldReport.MoveNext();
							CurrRow++;
						};

						//Unit Personnel Actions
						CurrRow++;
						ViewModel.sprQuery.Row = CurrRow;
						ViewModel.sprQuery.Col = 1;
						ViewModel.sprQuery.Text = "Unit Personnel Actions";
						CurrRow++;
						ViewModel.sprQuery.Row = CurrRow;
						ViewModel.sprQuery.Text = "Personnel";
						ViewModel.sprQuery.Col = 2;
						ViewModel.sprQuery.Text = "Unit Action";
						ViewModel.sprQuery.Col = 3;
						ViewModel.sprQuery.Text = "Unit Action Count";
						ViewModel.sprQuery.BlockMode = true;
						ViewModel.sprQuery.Row = CurrRow - 1;
						ViewModel.sprQuery.Row2 = CurrRow;
						ViewModel.sprQuery.Col = 1;
						ViewModel.sprQuery.Col2 = 3;
						ViewModel.sprQuery.BackColor = IncidentMain.Shared.LTGRAY;
						ViewModel.sprQuery.FontBold = true;
						ViewModel.sprQuery.BlockMode = false;
						CurrRow++;
						if ( InquiryCL.GetUnitPersonnelAction(UnitID, Shift, StartDate, EndDate) != 0 )
						{
							DisplayMonth = IncidentMain.Clean(InquiryCL.FieldReport["name_full"]);

							while ( !InquiryCL.FieldReport.EOF )
							{
								ViewModel.sprQuery.Row = CurrRow;
								ViewModel.sprQuery.Col = 1;
								CurrMonth = IncidentMain.Clean(InquiryCL.FieldReport["name_full"]);
								if ( DisplayMonth != CurrMonth )
								{
									CurrRow++;
									ViewModel.sprQuery.Row = CurrRow;
									DisplayMonth = CurrMonth;
								}
								ViewModel.sprQuery.Text = CurrMonth;
								ViewModel.sprQuery.Text = IncidentMain.Clean(InquiryCL.FieldReport["name_full"]);
								ViewModel.sprQuery.Col = 2;
								ViewModel.sprQuery.Text = IncidentMain.Clean(InquiryCL.FieldReport["description"]);
								ViewModel.sprQuery.Col = 3;
								ViewModel.sprQuery.Text = IncidentMain.Clean(InquiryCL.FieldReport["action_count"]);
								InquiryCL.FieldReport.MoveNext();
								CurrRow++;
							};
							}
						else
						{
							ViewModel.sprQuery.Row = CurrRow;
							ViewModel.sprQuery.Col = 1;
							ViewModel.sprQuery.Text = "No Unit Personnel Actions Recorded for selected time period";
						}
					}
					else
					{
						ViewModel.sprQuery.Row = CurrRow;
						ViewModel.sprQuery.Col = 1;
						ViewModel.sprQuery.Text = "No Unit Actions Recorded for selected time period";
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
			//Print Spread
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprQuery.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprQuery.setPrintAbortMsg("Printing Query Results - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprQuery.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprQuery.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprQuery.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprQuery.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprQuery.PrintOrientation was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprQuery.setPrintOrientation(ViewModel.PrintOry);
			ViewModel.sprQuery.Action = FarPoint.ViewModels.FPActionConstants.ActionSmartPrint;

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			FillSpread();
			IncidentMain.MoveForm(frmFieldReport.DefInstance);
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmFieldReport DefInstance
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

		public static frmFieldReport CreateInstance()
		{
			TFDIncident.frmFieldReport theInstance = Shared.Container.Resolve<frmFieldReport>();
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
			ViewModel.sprQuery.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprQuery.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmFieldReport
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.frmFieldReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmFieldReport m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}