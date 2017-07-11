using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.Text;
using UpgradeHelpers.DB.ADO;
using UpgradeStubs;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class frmStaffingReport
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmStaffingReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmStaffingReport));
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


		private void frmStaffingReport_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//************************************
		//* Staffing To Determine Callbacks  *
		//************************************
		//ADODB

		public void ClearGrid()
		{
			//clear Grid
			int Putty = UpgradeHelpers.Helpers.ColorTranslator.ToOle(UpgradeHelpers.Helpers.Color.FromArgb(189, 185, 170));
			ViewModel.sprReport.MaxRows = 40;
			ViewModel.sprReport.Col = 8;
			ViewModel.sprReport.Row = 1;
			ViewModel.sprReport.Text = "";
			ViewModel.sprDetail.Col = 1;
			ViewModel.sprDetail.Col2 = ViewModel.sprDetail.MaxCols;
			ViewModel.sprDetail.Row = 1;
			ViewModel.sprDetail.Row2 = ViewModel.sprDetail.MaxRows;
			ViewModel.sprDetail.BlockMode = true;
			ViewModel.sprDetail.Text = "";
			ViewModel.sprDetail.BlockMode = false;
			ViewModel.sprCSRs.Col = 1;
			ViewModel.sprCSRs.Col2 = ViewModel.sprCSRs.MaxCols;
			ViewModel.sprCSRs.Row = 1;
			ViewModel.sprCSRs.Row2 = ViewModel.sprCSRs.MaxRows;
			ViewModel.sprCSRs.BlockMode = true;
			ViewModel.sprCSRs.Text = "";
			ViewModel.sprCSRs.BlockMode = false;
			ViewModel.sprCallBackDetail.Col = 1;
			ViewModel.sprCallBackDetail.Col2 = ViewModel.sprCallBackDetail.MaxCols;
			ViewModel.sprCallBackDetail.Row = 1;
			ViewModel.sprCallBackDetail.Row2 = ViewModel.sprCallBackDetail.MaxRows;
			ViewModel.sprCallBackDetail.BlockMode = true;
			ViewModel.sprCallBackDetail.Text = "";
			ViewModel.sprCallBackDetail.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprCallBackDetail.BlockMode = false;
			ViewModel.sprReport.BlockMode = true;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Row = 5;
			ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
			ViewModel.sprReport.Row2 = ViewModel.sprReport.MaxRows;
			ViewModel.sprReport.Text = "";
			ViewModel.sprReport.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprReport.FontBold = false;

			//Center cell alignment
			ViewModel.sprReport.Col = 2;
			ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
			ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprReport.Col = 15;
			ViewModel.sprReport.Col2 = 16;
			ViewModel.sprReport.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(Putty);
			ViewModel.sprReport.BlockMode = false;
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprReport.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.ClearSelection();

			//Grid
			ViewModel.sprReportGrid.BlockMode = true;
			ViewModel.sprReportGrid.Col = 1;
			ViewModel.sprReportGrid.Row = 1;
			ViewModel.sprReportGrid.Col2 = ViewModel.sprReport.MaxCols;
			ViewModel.sprReportGrid.Row2 = ViewModel.sprReport.MaxRows;
			ViewModel.sprReportGrid.Text = "";
			ViewModel.sprReportGrid.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprReportGrid.FontBold = false;

			//Center cell alignment
			ViewModel.sprReportGrid.Col = 2;
			ViewModel.sprReportGrid.Col2 = ViewModel.sprReport.MaxCols;
			ViewModel.sprReportGrid.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprReportGrid.Col = 15;
			ViewModel.sprReportGrid.Col2 = 16;
			ViewModel.sprReportGrid.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(Putty);
			ViewModel.sprReportGrid.BlockMode = false;
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprReportGrid.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReportGrid.ClearSelection();

		}

		public void FillGrid()
		{
			//Fill Grid with Selected Months OT Detail
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string NewDate = "";

			ClearGrid();
			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			ViewModel.MinStaff = Convert.ToInt32(modGlobal.GetVal(ViewModel.txtTotal.Text));
			ViewModel.sprReport.Row = 1;
			ViewModel.sprReport.Col = 8;
			ViewModel.sprReport.Text = ViewModel.cboMonth.Text + " " + ViewModel.cboYear.Text;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			int ThisMonthFlag = 0;
			System.DateTime TempDate = DateTime.FromOADate(0);
			string StartDate = (DateTime.TryParse(ViewModel.OTMonth.ToString() + "/1/" + ViewModel.OTYear.ToString()
						, out TempDate)) ? TempDate.ToString("M/d/yyyy") : ViewModel.OTMonth.ToString() + "/1/" + ViewModel.OTYear.ToString();
			System.DateTime TempDate2 = DateTime.FromOADate(0);
			System.DateTime ThisDate = DateTime.Parse((DateTime.TryParse(StartDate, out TempDate2)) ? TempDate2.ToString("M/d/yyyy") : StartDate);
			if (ThisDate.Month == DateTime.Now.Month && ThisDate.Year == DateTime.Now.Year)
			{
				ThisMonthFlag = -1;
			}
			string EndDate = DateTime.Parse(StartDate).AddMonths(1).ToString("M/d/yyyy");

			int CurrRow = 5;
			int GridRow = 1;
			string TestDate = "";

			oCmd.CommandText = "spReport_DailyTotalStaff '" + StartDate + "','" + EndDate + "'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (oRec.EOF)
			{
				ViewManager.ShowMessage("There are no Staffing Records for this month", "Overtime Detail Report", UpgradeHelpers.Helpers.BoxButtons.OK);

				return;
			}


			while(!oRec.EOF)
			{
				ViewModel.sprReport.Row = CurrRow;
				ViewModel.sprReportGrid.Row = GridRow;
				NewDate = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
				if (NewDate != TestDate)
				{
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.Text = NewDate;
					ViewModel.sprReportGrid.Col = 1;
					ViewModel.sprReportGrid.Text = NewDate;
					ViewModel.sprReport.Col = 2;
					ViewModel.sprReport.Text = Convert.ToString(oRec["shift"]);
					ViewModel.sprReportGrid.Col = 2;
					ViewModel.sprReportGrid.Text = Convert.ToString(oRec["shift"]);

					TestDate = NewDate;
					CurrRow++;
					GridRow++;
				}
				oRec.MoveNext();
			};
			int TotalRows = CurrRow - 1;
			int TotalGridRows = GridRow - 1;


			//Retrieve the Total Working Staff Counts
			oCmd.CommandText = "spReport_WorkingStaffCountByDate '" + StartDate + "','" + EndDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			CurrRow = 5;
			GridRow = 1;
			ViewModel.sprReport.Row = CurrRow;
			ViewModel.sprReportGrid.Row = GridRow;


			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy");
				ViewModel.sprReport.Col = 1;
				if (TestDate == ViewModel.sprReport.Text)
				{
					if (Convert.ToString(oRec["AMPM"]) == "AM")
					{
						ViewModel.sprReport.Col = 15;
						ViewModel.sprReport.Text = Convert.ToString(oRec["off_count"]);
						ViewModel.sprReportGrid.Col = 15;
						ViewModel.sprReportGrid.Text = Convert.ToString(oRec["off_count"]);
					}
					else
					{
						ViewModel.sprReport.Col = 16;
						ViewModel.sprReport.Text = Convert.ToString(oRec["off_count"]);
						ViewModel.sprReportGrid.Col = 16;
						ViewModel.sprReportGrid.Text = Convert.ToString(oRec["off_count"]);
					}
					oRec.MoveNext();
				}
				else
				{
					CurrRow++;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.Row = CurrRow;
					GridRow++;
					ViewModel.sprReportGrid.Col = 1;
					ViewModel.sprReportGrid.Row = GridRow;
					if ( ViewModel.sprReport.Text == "")
					{
						break;
					}
				}
			};

			//Retrieve the Total Working Paramedic Counts
			oCmd.CommandText = "spReport_WorkingPMCountByDate '" + StartDate + "','" + EndDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			CurrRow = 5;
			GridRow = 1;
			ViewModel.sprReport.Row = CurrRow;
			ViewModel.sprReportGrid.Row = GridRow;


			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy");
				ViewModel.sprReport.Col = 1;
				if (TestDate == ViewModel.sprReport.Text)
				{
					if (Convert.ToString(oRec["AMPM"]) == "AM")
					{
						ViewModel.sprReport.Col = 11;
						ViewModel.sprReport.Text = Convert.ToString(oRec["off_count"]);
						ViewModel.sprReportGrid.Col = 11;
						ViewModel.sprReportGrid.Text = Convert.ToString(oRec["off_count"]);
					}
					else
					{
						ViewModel.sprReport.Col = 12;
						ViewModel.sprReport.Text = Convert.ToString(oRec["off_count"]);
						ViewModel.sprReportGrid.Col = 12;
						ViewModel.sprReportGrid.Text = Convert.ToString(oRec["off_count"]);
					}
					oRec.MoveNext();
				}
				else
				{
					CurrRow++;
					GridRow++;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.Row = CurrRow;
					ViewModel.sprReportGrid.Col = 1;
					ViewModel.sprReportGrid.Row = GridRow;
					if ( ViewModel.sprReport.Text == "")
					{
						break;
					}
				}
			};

			//Retrieve Working BC counts
			oCmd.CommandText = "spReport_WorkingBCCountByDate '" + StartDate + "','" + EndDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			CurrRow = 5;
			GridRow = 1;
			ViewModel.sprReport.Row = CurrRow;
			ViewModel.sprReportGrid.Row = GridRow;


			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy");
				ViewModel.sprReport.Col = 1;
				if (TestDate == ViewModel.sprReport.Text)
				{
					if (Convert.ToString(oRec["AMPM"]) == "AM")
					{
						ViewModel.sprReport.Col = 3;
						ViewModel.sprReport.Text = Convert.ToString(oRec["off_count"]);
						ViewModel.sprReportGrid.Col = 3;
						ViewModel.sprReportGrid.Text = Convert.ToString(oRec["off_count"]);
					}
					else
					{
						ViewModel.sprReport.Col = 4;
						ViewModel.sprReport.Text = Convert.ToString(oRec["off_count"]);
						ViewModel.sprReportGrid.Col = 4;
						ViewModel.sprReportGrid.Text = Convert.ToString(oRec["off_count"]);
					}
					oRec.MoveNext();
				}
				else
				{
					CurrRow++;
					GridRow++;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.Row = CurrRow;
					ViewModel.sprReportGrid.Col = 1;
					ViewModel.sprReportGrid.Row = GridRow;
					if ( ViewModel.sprReport.Text == "")
					{
						break;
					}
				}
			};

			//Retrieve Working Officer counts
			oCmd.CommandText = "spReport_WorkingOfficerCountByDate '" + StartDate + "','" + EndDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			CurrRow = 5;
			GridRow = 1;
			ViewModel.sprReport.Row = CurrRow;
			ViewModel.sprReportGrid.Row = GridRow;


			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy");
				ViewModel.sprReport.Col = 1;
				if (TestDate == ViewModel.sprReport.Text)
				{
					if (Convert.ToString(oRec["AMPM"]) == "AM")
					{
						ViewModel.sprReport.Col = 9;
						ViewModel.sprReport.Text = Convert.ToString(oRec["off_count"]);
						ViewModel.sprReportGrid.Col = 9;
						ViewModel.sprReportGrid.Text = Convert.ToString(oRec["off_count"]);
					}
					else
					{
						ViewModel.sprReport.Col = 10;
						ViewModel.sprReport.Text = Convert.ToString(oRec["off_count"]);
						ViewModel.sprReportGrid.Col = 10;
						ViewModel.sprReportGrid.Text = Convert.ToString(oRec["off_count"]);
					}
					oRec.MoveNext();
				}
				else
				{
					CurrRow++;
					GridRow++;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.Row = CurrRow;
					ViewModel.sprReportGrid.Col = 1;
					ViewModel.sprReportGrid.Row = GridRow;
					if ( ViewModel.sprReport.Text == "")
					{
						break;
					}
				}
			};

			//Retrieve Working SAFLT Count
			oCmd.CommandText = "spReport_WorkingISOCountByDate '" + StartDate + "','" + EndDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			CurrRow = 5;
			GridRow = 1;
			ViewModel.sprReport.Row = CurrRow;
			ViewModel.sprReportGrid.Row = GridRow;


			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy");
				ViewModel.sprReport.Col = 1;
				if (TestDate == ViewModel.sprReport.Text)
				{
					if (Convert.ToString(oRec["AMPM"]) == "AM")
					{
						ViewModel.sprReport.Col = 5;
						ViewModel.sprReport.Text = Convert.ToString(oRec["off_count"]);
						ViewModel.sprReportGrid.Col = 5;
						ViewModel.sprReportGrid.Text = Convert.ToString(oRec["off_count"]);
					}
					else
					{
						ViewModel.sprReport.Col = 6;
						ViewModel.sprReport.Text = Convert.ToString(oRec["off_count"]);
						ViewModel.sprReportGrid.Col = 6;
						ViewModel.sprReportGrid.Text = Convert.ToString(oRec["off_count"]);
					}
					oRec.MoveNext();
				}
				else
				{
					CurrRow++;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.Row = CurrRow;
					GridRow++;
					ViewModel.sprReportGrid.Col = 1;
					ViewModel.sprReportGrid.Row = GridRow;
					if ( ViewModel.sprReport.Text == "")
					{
						break;
					}
				}
			};

			//Retrieve Scheduled Incharge Dispatcher Count
			oCmd.CommandText = "spReport_WorkingICDispatchCountByDate '" + StartDate + "','" + EndDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			CurrRow = 5;
			GridRow = 1;
			ViewModel.sprReport.Row = CurrRow;
			ViewModel.sprReportGrid.Row = GridRow;


			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy");
				ViewModel.sprReport.Col = 1;
				if (TestDate == ViewModel.sprReport.Text)
				{
					if (Convert.ToString(oRec["AMPM"]) == "AM")
					{
						ViewModel.sprReport.Col = 13;
						ViewModel.sprReport.Text = Convert.ToString(oRec["off_count"]);
						ViewModel.sprReportGrid.Col = 13;
						ViewModel.sprReportGrid.Text = Convert.ToString(oRec["off_count"]);
					}
					else
					{
						ViewModel.sprReport.Col = 14;
						ViewModel.sprReport.Text = Convert.ToString(oRec["off_count"]);
						ViewModel.sprReportGrid.Col = 14;
						ViewModel.sprReportGrid.Text = Convert.ToString(oRec["off_count"]);
					}
					oRec.MoveNext();
				}
				else
				{
					CurrRow++;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.Row = CurrRow;
					GridRow++;
					ViewModel.sprReportGrid.Col = 1;
					ViewModel.sprReportGrid.Row = GridRow;
					if ( ViewModel.sprReport.Text == "")
					{
						break;
					}
				}
			};

			//Retrieve Scheduled Fireboat Qualified Count
			oCmd.CommandText = "spReport_WorkingFBQualifiedCountByDate '" + StartDate + "','" + EndDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			CurrRow = 5;
			GridRow = 1;
			ViewModel.sprReport.Row = CurrRow;
			ViewModel.sprReportGrid.Row = GridRow;


			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy");
				ViewModel.sprReport.Col = 1;
				if (TestDate == ViewModel.sprReport.Text)
				{
					if (Convert.ToString(oRec["AMPM"]) == "AM")
					{
						ViewModel.sprReport.Col = 7;
						ViewModel.sprReport.Text = Convert.ToString(oRec["off_count"]);
						ViewModel.sprReportGrid.Col = 7;
						ViewModel.sprReportGrid.Text = Convert.ToString(oRec["off_count"]);
					}
					else
					{
						ViewModel.sprReport.Col = 8;
						ViewModel.sprReport.Text = Convert.ToString(oRec["off_count"]);
						ViewModel.sprReportGrid.Col = 8;
						ViewModel.sprReportGrid.Text = Convert.ToString(oRec["off_count"]);
					}
					oRec.MoveNext();
				}
				else
				{
					CurrRow++;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.Row = CurrRow;
					GridRow++;
					ViewModel.sprReportGrid.Col = 1;
					ViewModel.sprReportGrid.Row = GridRow;
					if ( ViewModel.sprReport.Text == "")
					{
						break;
					}
				}
			};

			for (int i = 5; i <= TotalRows; i++)
			{
				//        For X = 3 To sprReport.MaxCols
				for (int x = 3; x <= 14; x++)
				{ //for now...

					ViewModel.sprReport.Row = i;
					ViewModel.sprReport.Col = x;
					if ( ViewModel.sprReport.Text == "")
					{
						ViewModel.sprReport.FontBold = true;
						ViewModel.sprReport.Text = "0";
					}
					else
					{
						if (x == 11 || x == 12)
						{
							//UPGRADE_WARNING: (1068) GetVal(sprReport.Text) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
							if (Convert.ToDouble(modGlobal.GetVal(ViewModel.sprReport.Text)) < 13)
							{
								ViewModel.sprReport.FontBold = true;
							}
						}
						if (x == 7 || x == 8)
						{
							//UPGRADE_WARNING: (1068) GetVal(sprReport.Text) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
							if (Convert.ToDouble(modGlobal.GetVal(ViewModel.sprReport.Text)) < 2)
							{
								ViewModel.sprReport.FontBold = true;
							}
						}
						if (x == 9 || x == 10)
						{
							//UPGRADE_WARNING: (1068) GetVal(sprReport.Text) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
							if (Convert.ToDouble(modGlobal.GetVal(ViewModel.sprReport.Text)) < 20)
							{
								ViewModel.sprReport.FontBold = true;
							}
						}
					}

				}
			}

			for (int i = 5; i <= TotalRows; i++)
			{
				//        For X = 3 To sprReport.MaxCols
				for (int x = 15; x <= 16; x++)
				{ //for now...

					ViewModel.sprReport.Row = i;
					ViewModel.sprReport.Col = x;
					//UPGRADE_WARNING: (1068) GetVal(sprReport.Text) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					if (Convert.ToDouble(modGlobal.GetVal(ViewModel.sprReport.Text)) < ViewModel.MinStaff)
					{
						ViewModel.sprReport.FontBold = true;
					}
				}
			}

			if (ThisMonthFlag != 0)
			{
				for (int i = 5; i <= TotalRows; i++)
				{
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.Row = i;
					if ( ViewModel.sprReport.Text != "")
					{
						if (DateTime.Parse(ViewModel.sprReport.Text).ToString("M/d/yyyy") == DateTime.Now.ToString("M/d/yyyy"));
						{
							//ViewModel.sprReport.SetSelection(1, i, 14, i);
							ViewModel.sprReport.Row = i;
							ViewModel.sprReport.Row2 = i;
							ViewModel.sprReport.Col = 1;
							ViewModel.sprReport.Col2 = 14;
							ViewModel.sprReport.BlockMode = true;
							ViewModel.sprReport.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
							ViewModel.sprReport.BlockMode = false;
							break;
						}
					}
				}
			}

			//grid ***********
			for (int i = 1; i <= TotalGridRows; i++)
			{
				//        For X = 3 To sprReport.MaxCols
				for (int x = 3; x <= 14; x++)
				{ //for now...

					ViewModel.sprReportGrid.Row = i;
					ViewModel.sprReportGrid.Col = x;
					if ( ViewModel.sprReportGrid.Text == "")
					{
						ViewModel.sprReportGrid.FontBold = true;
						ViewModel.sprReportGrid.Text = "0";
					}
					else
					{
						if (x == 11 || x == 12)
						{
							//UPGRADE_WARNING: (1068) GetVal(sprReportGrid.Text) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
							if (Convert.ToDouble(modGlobal.GetVal(ViewModel.sprReportGrid.Text)) < 13)
							{
								ViewModel.sprReportGrid.FontBold = true;
							}
						}
						if (x == 7 || x == 8)
						{
							//UPGRADE_WARNING: (1068) GetVal(sprReportGrid.Text) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
							if (Convert.ToDouble(modGlobal.GetVal(ViewModel.sprReportGrid.Text)) < 2)
							{
								ViewModel.sprReportGrid.FontBold = true;
							}
						}
						if (x == 9 || x == 10)
						{
							//UPGRADE_WARNING: (1068) GetVal(sprReportGrid.Text) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
							if (Convert.ToDouble(modGlobal.GetVal(ViewModel.sprReportGrid.Text)) < 19)
							{
								ViewModel.sprReportGrid.FontBold = true;
							}
						}
					}

				}
			}

			for (int i = 1; i <= TotalGridRows; i++)
			{
				//        For X = 3 To sprReport.MaxCols
				for (int x = 15; x <= 16; x++)
				{ //for now...

					ViewModel.sprReportGrid.Row = i;
					ViewModel.sprReportGrid.Col = x;
					//UPGRADE_WARNING: (1068) GetVal(sprReportGrid.Text) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					if (Convert.ToDouble(modGlobal.GetVal(ViewModel.sprReportGrid.Text)) < ViewModel.MinStaff)
					{
						ViewModel.sprReportGrid.FontBold = true;
					}
				}
			}

			if (ThisMonthFlag != 0)
			{
				for (int i = 1; i <= TotalGridRows; i++)
				{
					ViewModel.sprReportGrid.Col = 1;
					ViewModel.sprReportGrid.Row = i;
					if ( ViewModel.sprReportGrid.Text != "")
					{
						if (DateTime.Parse(ViewModel.sprReportGrid.Text).ToString("M/d/yyyy") == DateTime.Now.ToString("M/d/yyyy"));
						{
							//ViewModel.sprReportGrid.SetSelection(1, i, 14, i);
							ViewModel.sprReportGrid.Row = i;
							ViewModel.sprReportGrid.Row2 = i;
							ViewModel.sprReportGrid.Col = 1;
							ViewModel.sprReportGrid.Col2 = 14;
							ViewModel.sprReportGrid.BlockMode = true;
							ViewModel.sprReportGrid.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
							ViewModel.sprReportGrid.BlockMode = false;
							break;
						}
					}
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboMonth_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}
			if ( ViewModel.cboMonth.SelectedIndex < 0)
			{
				return;
			}
			ViewModel.OTMonth = ViewModel.cboMonth.GetItemData(ViewModel.cboMonth.SelectedIndex);
			ViewModel.OTYear = Convert.ToInt32(Double.Parse(ViewModel.cboYear.Text));

			FillGrid();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboYear_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}
			if ( ViewModel.cboMonth.SelectedIndex < 0)
			{
				return;
			}
			ViewModel.OTMonth = ViewModel.cboMonth.GetItemData(ViewModel.cboMonth.SelectedIndex);
			ViewModel.OTYear = Convert.ToInt32(Double.Parse(ViewModel.cboYear.Text));

			FillGrid();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Print SpreadSheet

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintAbortMsg("Printing Daily Staffing To Determine Callbacks - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintColHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintColHeaders(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintColor(true);
			//    sprReport.PrintMarginTop = 720
			//    sprReport.PrintMarginLeft = 500
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintRowHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintRowHeaders(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintSmartPrint was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintSmartPrint(true);

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprReport.PrintSheet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//object tempRefParam = null;
			//WEBMAP_UPGRADE_ISSUE: (1101) FarPoint.Win.Spread.FpSpread.PrintSheet was not upgraded
			ViewModel.sprReport.PrintSheet(null);

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrintDetail_Click(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.optWorking.Checked)
			{
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprDetail.PrintHeader was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprDetail.setPrintHeader("/lPTS Scheduled Staffing - /n" + modGlobal.Clean(ViewModel.lbDetailDisplayed.Text));
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprDetail.PrintFooter was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprDetail.setPrintFooter("/nPrinted on " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "/r Page /p of /pc");
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprDetail.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprDetail.setPrintAbortMsg("Printing Scheduled Staff Detail Grid");
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprDetail.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprDetail.setPrintColor(true);
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprDetail.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprDetail.setPrintBorder(false);
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprDetail.PrintColHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprDetail.setPrintColHeaders(true);
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprDetail.PrintSmartPrint was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprDetail.setPrintSmartPrint(true);

				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprDetail.PrintSheet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				//object tempRefParam = null;
				//WEBMAP_UPGRADE_ISSUE: (1101) FarPoint.Win.Spread.FpSpread.PrintSheet was not upgraded
				ViewModel.sprDetail.PrintSheet(null);
			}
			else if ( ViewModel.optCallback.Checked)
			{
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCallBackDetail.PrintHeader was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprCallBackDetail.setPrintHeader("/lPTS Callback List - /n" + modGlobal.Clean(ViewModel.lbDetailDisplayed.Text));
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCallBackDetail.PrintFooter was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprCallBackDetail.setPrintFooter("/nPrinted on " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "/r Page /p of /pc");
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCallBackDetail.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprCallBackDetail.setPrintAbortMsg("Printing Callback Staff Detail Grid");
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCallBackDetail.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprCallBackDetail.setPrintColor(true);
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCallBackDetail.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprCallBackDetail.setPrintBorder(false);
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCallBackDetail.PrintColHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprCallBackDetail.setPrintColHeaders(true);
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCallBackDetail.PrintSmartPrint was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprCallBackDetail.setPrintSmartPrint(true);

				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprCallBackDetail.PrintSheet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				//object tempRefParam2 = null;
				//WEBMAP_UPGRADE_ISSUE: (1101) FarPoint.Win.Spread.FpSpread.PrintSheet was not upgraded
				ViewModel.sprCallBackDetail.PrintSheet(null);
			}
			else
			{
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCSRs.PrintHeader was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprCSRs.setPrintHeader("/lPTS Callback List - /n" + modGlobal.Clean(ViewModel.lbDetailDisplayed.Text));
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCSRs.PrintFooter was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprCSRs.setPrintFooter("/nPrinted on " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "/r Page /p of /pc");
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCSRs.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprCSRs.setPrintAbortMsg("Printing Available Cross Shift Rovers Grid");
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCSRs.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprCSRs.setPrintColor(true);
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCSRs.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprCSRs.setPrintBorder(false);
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCSRs.PrintColHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprCSRs.setPrintColHeaders(true);
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCSRs.PrintSmartPrint was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprCSRs.setPrintSmartPrint(true);

				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprCSRs.PrintSheet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				//object tempRefParam3 = null;
				//WEBMAP_UPGRADE_ISSUE: (1101) FarPoint.Win.Spread.FpSpread.PrintSheet was not upgraded
				ViewModel.sprCSRs.PrintSheet(null);
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdRunReport_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.cmdRunReport.Enabled = false;
			FillGrid();
			ViewModel.cmdRunReport.Enabled = true;
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ViewModel.FirstTime = true;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			ViewModel.selCol = 0;
			ViewModel.selRow = 0;

			oCmd.CommandText = "spSelect_TargetStaffingTotal ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (!oRec.EOF)
			{
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.txtTotal.Text = Convert.ToString(modGlobal.GetVal(oRec["TargetTotal"]));
			}
			else
			{
				ViewModel.txtTotal.Text = "70";
			}

			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			ViewModel.MinStaff = Convert.ToInt32(modGlobal.GetVal(ViewModel.txtTotal.Text));

			oCmd.CommandText = "sp_GetYearList ";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			//Initialize Year Combobox
			ViewModel.cboYear.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboYear.AddItem(Convert.ToString(oRec["cal_year"]).Trim());
				oRec.MoveNext();
			};
			ViewModel.cboYear.Text = DateTime.Now.Year.ToString();
			ViewModel.FirstTime = false;
			ViewModel.cboMonth.SelectedIndex = DateTime.Now.Month - 1;

		}

		[UpgradeHelpers.Events.Handler]
		internal void optCallback_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.optCallback.Checked)
				{
					ViewModel.sprDetail.Visible = false;
					ViewModel.sprCallBackDetail.Visible = true;
					ViewModel.sprCSRs.Visible = false;
					ViewModel.lbListNote.Visible = true;
					if ( ViewModel.selCol != 0)
					{
						sprReportGrid_CellClick(ViewModel.sprReportGrid, new Stubs._FarPoint.Win.Spread.CellClickEventArgs(ViewModel
							.selRow, ViewModel.selCol));
					}
				}
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optCSRs_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.optCSRs.Checked)
				{
					ViewModel.sprDetail.Visible = false;
					ViewModel.sprCallBackDetail.Visible = false;
					ViewModel.sprCSRs.Visible = true;
					ViewModel.lbListNote.Visible = true;
					if ( ViewModel.selCol != 0)
					{
						sprReportGrid_CellClick(ViewModel.sprReportGrid, new Stubs._FarPoint.Win.Spread.CellClickEventArgs(ViewModel
							.selRow, ViewModel.selCol));
					}
				}
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optWorking_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.optWorking.Checked)
				{
					ViewModel.sprDetail.Visible = true;
					ViewModel.sprCallBackDetail.Visible = false;
					ViewModel.sprCSRs.Visible = false;
					ViewModel.lbListNote.Visible = false;
					if ( ViewModel.selCol != 0)
					{
						sprReportGrid_CellClick(ViewModel.sprReportGrid, new Stubs._FarPoint.Win.Spread.CellClickEventArgs(ViewModel
							.selRow, ViewModel.selCol));
					}
				}
			}
		}

		private void sprReportGrid_CellClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
		{
			int Col = eventArgs.Column;
			int Row = eventArgs.Row;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			StringBuilder sText = new System.Text.StringBuilder();
			int iFilter = 0;
			string sDebitGroup = "";

			int iCol = 0;
			int iRow = 0;
			ViewModel.selCol = Col;
			ViewModel.selRow = Row;
			ViewModel.lbDetailDisplayed.Text = "";

			//clear sprDetail grid and sprCallBackDetail
			ViewModel.sprDetail.Col = 1;
			ViewModel.sprDetail.Col2 = ViewModel.sprDetail.MaxCols;
			ViewModel.sprDetail.Row = 1;
			ViewModel.sprDetail.Row2 = ViewModel.sprDetail.MaxRows;
			ViewModel.sprDetail.BlockMode = true;
			ViewModel.sprDetail.Text = "";
			ViewModel.sprDetail.BlockMode = false;
			ViewModel.sprCSRs.Col = 1;
			ViewModel.sprCSRs.Col2 = ViewModel.sprCSRs.MaxCols;
			ViewModel.sprCSRs.Row = 1;
			ViewModel.sprCSRs.Row2 = ViewModel.sprCSRs.MaxRows;
			ViewModel.sprCSRs.BlockMode = true;
			ViewModel.sprCSRs.Text = "";
			ViewModel.sprCSRs.BlockMode = false;
			ViewModel.sprCallBackDetail.Col = 1;
			ViewModel.sprCallBackDetail.Col2 = ViewModel.sprCallBackDetail.MaxCols;
			ViewModel.sprCallBackDetail.Row = 1;
			ViewModel.sprCallBackDetail.Row2 = ViewModel.sprCallBackDetail.MaxRows;
			ViewModel.sprCallBackDetail.BlockMode = true;
			ViewModel.sprCallBackDetail.Text = "";
			ViewModel.sprCallBackDetail.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprCallBackDetail.BlockMode = false;

			//If report headers clicked... then exit
			if (Row < 1)
			{

				return;
			}
			//    If Col = 1 Or Col = 2 Or Col = 15 Or Col = 16 Then
			//        If optWorking.Value = True Then
			//            Screen.MousePointer = vbDefault
			//            Exit Sub
			//        End If
			//    End If
			ViewModel.sprReportGrid.Col = 2;
			ViewModel.sprReportGrid.Row = Row;
			if (modGlobal.Clean(ViewModel.sprReportGrid.Text) != "A" && modGlobal.Clean(ViewModel.sprReportGrid.Text
						) != "B" && modGlobal.Clean(ViewModel.sprReportGrid.Text) != "C" && modGlobal.Clean(ViewModel.sprReportGrid.Text) != "D")
			{
;
				return;
			}
			else
			{
				ViewModel.sShift = modGlobal.Clean(ViewModel.sprReportGrid.Text);
			}
			ViewModel.sprReportGrid.Col = 1;
			if (!Information.IsDate(ViewModel.sprReportGrid.Text))
			{
				return;
			}
			else
			{
				ViewModel.sDate = DateTime.Parse(ViewModel.sprReportGrid.Text).ToString("M/d/yyyy");
			}


			iCol = Col;
			iRow = Row;
			ViewModel.sprReportGrid.Col = iCol;
			ViewModel.sprReportGrid.Row = iRow;
			if (modGlobal.Clean(ViewModel.sprReportGrid.Text) == "")
			{
				return;
			}
			//UPGRADE_WARNING: (1068) GetVal(sprReportGrid.Text) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			if (Convert.ToDouble(modGlobal.GetVal(ViewModel.sprReportGrid.Text)) == 0)
			{
				if ( ViewModel.optWorking.Checked)
				{
					return;
				}
			}

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//Get Shift for this Date
			oCmd.CommandText = "sp_GetShift '" + ViewModel.sDate + " 7:00AM'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				sDebitGroup = modGlobal.Clean(oRec["debit_group_code"]);
			}

			if ( ViewModel.optWorking.Checked)
			{
				switch(iCol)
				{
					case 11 : case 12 :  //Working Paramedics 

						ViewModel.lbDetailDisplayed.Text = "Qualified Paramedics Scheduled";
						oCmd.CommandText = "spReport_WorkingPMDetailByDate '" + ViewModel.sDate + "' ";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						break;
					case 3 : case 4 :  //Working BCs 

						ViewModel.lbDetailDisplayed.Text = "  Qualified BC(s) Scheduled";
						oCmd.CommandText = "spReport_WorkingBCDetailByDate '" + ViewModel.sDate + "' ";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						break;
					case 5 : case 6 :  //Working SAFLT 

						ViewModel.lbDetailDisplayed.Text = "  Qualified SAFLT Scheduled";
						oCmd.CommandText = "spReport_WorkingISODetailByDate '" + ViewModel.sDate + "' ";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						break;
					case 13 : case 14 :  //Incharge Dispatcher 

						ViewModel.lbDetailDisplayed.Text = "Incharge Dispatcher Scheduled";
						oCmd.CommandText = "spReport_WorkingICDispatchDetailByDate '" + ViewModel.sDate + "' ";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						break;
					case 7 : case 8 :  //Fireboat Qualified 

						ViewModel.lbDetailDisplayed.Text = "Qualified Fireboat Staff Scheduled";
						oCmd.CommandText = "spReport_WorkingFBQualifiedDetailByDate '" + ViewModel.sDate + "' ";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						break;
					case 9 : case 10 :  //Callback Officers 

						ViewModel.lbDetailDisplayed.Text = "Officers Scheduled";
						oCmd.CommandText = "spReport_WorkingOfficerDetailByDate '" + ViewModel.sDate + "' ";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						break;
					default: //display all 

						ViewModel.lbDetailDisplayed.Text = "All Staff Scheduled";
						oCmd.CommandText = "spReport_WorkingStaffDetailByDate '" + ViewModel.sDate + "' ";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						break;
				}
			}
			else if ( ViewModel.optCallback.Checked)
			{
				switch(iCol)
				{
					case 11 : case 12 :  //Callback Paramedics 
						iFilter = 1;
						ViewModel.lbDetailDisplayed.Text = "Callback Qualified Paramedic(s)";
						break;
					case 3 : case 4 :  //Callback BCs 
						iFilter = 2;
						ViewModel.lbDetailDisplayed.Text = "     Callback Qualified BC";
						break;
					case 5 : case 6 :  //Callback SAFLT 
						iFilter = 3;
						ViewModel.lbDetailDisplayed.Text = "     Callback Qualified SAFLT";
						break;
					case 13 : case 14 :  //Callback Dispatcher 
						iFilter = 4;
						ViewModel.lbDetailDisplayed.Text = "Callback Qualified Dispatcher";
						break;
					case 7 : case 8 :  //Callback Fireboat Qualified 
						iFilter = 5;
						ViewModel.lbDetailDisplayed.Text = "Callback Qualified Fireboat Staff";
						break;
					case 9 : case 10 :  //Callback Officers 
						iFilter = 6;
						ViewModel.lbDetailDisplayed.Text = "Callback Qualified Officers";
						break;
					default: //Display all 
						iFilter = 0;
						ViewModel.lbDetailDisplayed.Text = "Callback List For " + ViewModel.sDate + " - DbGrp " + sDebitGroup;
						break;
				}
				oCmd.CommandText = "spReport_CallBackFilteredList '" + ViewModel.sShift + "', '" + ViewModel.sDate + "', " + iFilter.ToString() + " ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
			}
			else
			{
				switch(iCol)
				{
					case 11 : case 12 :  //Callback Paramedics 
						iFilter = 1;
						ViewModel.lbDetailDisplayed.Text = "Available PM Cross Shift Rovers";
						break;
					case 3 : case 4 :  //Callback BCs 
						iFilter = 2;
						ViewModel.lbDetailDisplayed.Text = "Available Cross Shift Rover BC";
						break;
					case 5 : case 6 :  //Callback SAFLT 
						iFilter = 3;
						ViewModel.lbDetailDisplayed.Text = "Available Cross Shift Rover SAFLT";
						break;
					case 13 : case 14 :  //Callback Dispatcher 
						iFilter = 4;
						ViewModel.lbDetailDisplayed.Text = "Available Cross Shift Rover Dispatchers";
						break;
					case 7 : case 8 :  //Callback Fireboat Qualified 
						iFilter = 5;
						ViewModel.lbDetailDisplayed.Text = "Available Cross Shift Rover Pilot";
						break;
					case 9 : case 10 :  //Callback Officers 
						iFilter = 6;
						ViewModel.lbDetailDisplayed.Text = "Available Cross Shift Rover Officers";
						break;
					default: //Display all 
						iFilter = 0;
						ViewModel.lbDetailDisplayed.Text = "All Available Cross Shift Rovers";
						break;
				}
				oCmd.CommandText = "spReport_CallBackCSRAvailableList '" + ViewModel.sDate + "', " + iFilter.ToString() + " ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
			}

			int CurrRow = 0;
			string CurrEmployee = "";

			if ( ViewModel.optWorking.Checked)
			{

				while(!oRec.EOF)
				{
					CurrRow++;
					ViewModel.sprDetail.Row = CurrRow;
					ViewModel.sprDetail.Col = 1;
					ViewModel.sprDetail.Text = Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy HH:mm");

					sText = new System.Text.StringBuilder("");
					if (modGlobal.Clean(oRec["unit_code"]) != "")
					{
						sText = new System.Text.StringBuilder(modGlobal.Clean(oRec["unit_code"]) + "-");
					}
					if (modGlobal.Clean(oRec["position_code"]) != "")
					{
						sText.Append(modGlobal.Clean(oRec["position_code"]));
					}
					ViewModel.sprDetail.Col = 2;
					ViewModel.sprDetail.Text = sText.ToString();
					ViewModel.sprDetail.Col = 3;
					ViewModel.sprDetail.Text = modGlobal.Clean(oRec["EmployeeName"]);
					ViewModel.sprDetail.Col = 4;
					ViewModel.sprDetail.Text = modGlobal.Clean(oRec["CreatorName"]);
					ViewModel.sprDetail.Col = 5;
					if (modGlobal.Clean(oRec["update_date"]) == "")
					{
						ViewModel.sprDetail.Text = "";
					}
					else
					{
						ViewModel.sprDetail.Text = Convert.ToDateTime(oRec["update_date"]).ToString("M/d/yyyy HH:mm:ss");
					}
					ViewModel.sprDetail.Col = 6;
					ViewModel.sprDetail.Text = modGlobal.Clean(oRec["time_code_id"]);

					oRec.MoveNext();
				};
			}
			else if ( ViewModel.optCallback.Checked)
			{

				while(!oRec.EOF)
				{
					if (modGlobal.Clean(oRec["employee_id"]) == CurrEmployee)
					{
						sText.Append("      " + modGlobal.Clean(oRec["phone_number"]));
						ViewModel.sprCallBackDetail.Col = 4;
						ViewModel.sprCallBackDetail.Text = sText.ToString();
					}
					else
					{
						sText = new System.Text.StringBuilder("");
						sText = new System.Text.StringBuilder(modGlobal.Clean(oRec["phone_number"]));
						CurrEmployee = modGlobal.Clean(oRec["employee_id"]);

						CurrRow++;
						ViewModel.sprCallBackDetail.Row = CurrRow;
						ViewModel.sprCallBackDetail.Col = 1; //Callback #

						ViewModel.sprCallBackDetail.Text = modGlobal.Clean(oRec["call_back_number"]);
						ViewModel.sprCallBackDetail.Col = 2; //Employee
						//determine if cell needs color
						if (modGlobal.Clean(oRec["position_code"]) == "BC")
						{
							ViewModel.sprCallBackDetail.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.CNOTES);
						}
						else if (modGlobal.Clean(oRec["position_code"]) == "SAFLT")
						{
							ViewModel.sprCallBackDetail.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.PUMPKIN);
						}
						else if (modGlobal.Clean(oRec["assignment_type_code"]) == "PM")
						{
							ViewModel.sprCallBackDetail.BackColor = modGlobal.Shared.YELLOW;
						}
						else if (modGlobal.Clean(oRec["assignment_type_code"]) == "PILOT")
						{
							ViewModel.sprCallBackDetail.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
						}
						else if (modGlobal.Clean(oRec["assignment_type_code"]) == "DISP")
						{
							ViewModel.sprCallBackDetail.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.PEACH);
						}
						else if (modGlobal.Clean(oRec["position_code"]) == "OFF")
						{
							ViewModel.sprCallBackDetail.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_GREEN);
						}
						else if (modGlobal.Clean(oRec["position_code"]) == "ROVLT")
						{
							ViewModel.sprCallBackDetail.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_GREEN);
						}
						else
						{
							ViewModel.sprCallBackDetail.BackColor = modGlobal.Shared.WHITE;
						}
						ViewModel.sprCallBackDetail.Text = modGlobal.Clean(oRec["name_full"]);
						ViewModel.sprCallBackDetail.Col = 3;
						ViewModel.sprCallBackDetail.Text = modGlobal.Clean(oRec["special_event"]);
						if ( ViewModel.sprCallBackDetail.Text == "No")
						{
							ViewModel.sprCallBackDetail.BackColor = modGlobal.Shared.RED;
						}
						else
						{
							ViewModel.sprCallBackDetail.BackColor = modGlobal.Shared.WHITE;
						}
						ViewModel.sprCallBackDetail.Col = 4;
						ViewModel.sprCallBackDetail.Text = sText.ToString();
						ViewModel.sprCallBackDetail.Col = 5;
						ViewModel.sprCallBackDetail.Text = modGlobal.Clean(oRec["debit_group"]);
						ViewModel.sprCallBackDetail.Col = 6;
						ViewModel.sprCallBackDetail.Text = modGlobal.Clean(oRec["assignment_type_code"]);
						ViewModel.sprCallBackDetail.Col = 7; //comments... always blank

						ViewModel.sprCallBackDetail.Text = "               ";
					}
					oRec.MoveNext();
				};
			}
			else
			{

				while(!oRec.EOF)
				{
					CurrRow++;
					ViewModel.sprCSRs.Row = CurrRow;
					ViewModel.sprCSRs.Col = 1;
					ViewModel.sprCSRs.Text = modGlobal.Clean(oRec["name_full"]);
					ViewModel.sprCSRs.Col = 2;
					ViewModel.sprCSRs.Text = modGlobal.Clean(oRec["assignment_type_code"]);
					ViewModel.sprCSRs.Col = 3;
					ViewModel.sprCSRs.Text = modGlobal.Clean(oRec["position_code"]);
					ViewModel.sprCSRs.Col = 4;
					if (modGlobal.Clean(oRec["WorkLast"]) == "")
					{
						ViewModel.sprCSRs.Text = "";
					}
					else
					{
						ViewModel.sprCSRs.Text = Convert.ToDateTime(oRec["WorkLast"]).ToString("M/d/yyyy HH:mm:ss");
					}
					ViewModel.sprCSRs.Col = 5;
					if (modGlobal.Clean(oRec["WorkNext"]) == "")
					{
						ViewModel.sprCSRs.Text = "";
					}
					else
					{
						ViewModel.sprCSRs.Text = Convert.ToDateTime(oRec["WorkNext"]).ToString("M/d/yyyy HH:mm:ss");
					}

					oRec.MoveNext();
				};
			}

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmStaffingReport DefInstance
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

		public static frmStaffingReport CreateInstance()
		{
			PTSProject.frmStaffingReport theInstance = Shared.Container.Resolve< frmStaffingReport>();
			theInstance.Form_Load();
			return theInstance;
		}

		void ReLoadForm(bool addEvents)
		{
			ViewManager.NavigateToView(
				PTSProject.MDIForm1.DefInstance);
			}

		protected override void ExecuteControlsStartup()
		{
			ViewModel.sprCallBackDetail.LifeCycleStartup();
			ViewModel.sprReport.LifeCycleStartup();
			ViewModel.sprReportGrid.LifeCycleStartup();
			ViewModel.sprDetail.LifeCycleStartup();
			ViewModel.sprCSRs.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprCallBackDetail.LifeCycleShutdown();
			ViewModel.sprReport.LifeCycleShutdown();
			ViewModel.sprReportGrid.LifeCycleShutdown();
			ViewModel.sprDetail.LifeCycleShutdown();
			ViewModel.sprCSRs.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmStaffingReport
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmStaffingReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmStaffingReport m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}