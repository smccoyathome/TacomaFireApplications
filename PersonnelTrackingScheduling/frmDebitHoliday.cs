using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeStubs;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class frmDebitHoliday
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmDebitHolidayViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmDebitHoliday));
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


		private void frmDebitHoliday_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		public void FormatReport()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			double dAmount = 0;

			ViewModel.sprEmployeeList.Row = 1;
			ViewModel.sprEmployeeList.Row2 = ViewModel.sprEmployeeList.MaxRows;
			ViewModel.sprEmployeeList.Col = 1;
			ViewModel.sprEmployeeList.Col2 = ViewModel.sprEmployeeList.MaxCols;
			ViewModel.sprEmployeeList.BlockMode = true;
			ViewModel.sprEmployeeList.Text = "";
			ViewModel.sprEmployeeList.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprEmployeeList.FontBold = false;
			ViewModel.sprEmployeeList.BlockMode = false;

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprEmployeeList.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeList.ClearSelection();

			//Fill Employee Grid
			string sStringText = "";

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			sStringText = "spReport_PersonnelAnnualDebitHolidayCounts " + ViewModel.ReportYear + ", ";

			if (modGlobal.Clean(ViewModel.ReportBatt) == "")
			{
				sStringText = sStringText + "Null, ";
			}
			else
			{
				sStringText = sStringText + "'" + modGlobal.Clean(ViewModel.ReportBatt) + "', ";
			}

			if (modGlobal.Clean(ViewModel.ReportShift) == "")
			{
				sStringText = sStringText + "Null, ";
			}
			else
			{
				sStringText = sStringText + "'" + modGlobal.Clean(ViewModel.ReportShift) + "', ";
			}

			sStringText = sStringText + "'" + ViewModel.ReportDate + "' ";
			oCmd.CommandText = sStringText;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			int GridRow = 0;

			while(!oRec.EOF)
			{
				GridRow++;
				ViewModel.sprEmployeeList.Row = GridRow;
				ViewModel.sprEmployeeList.Col = 1;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["employee_id"]);
				ViewModel.sprEmployeeList.Col = 2;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["name_full"]);
				ViewModel.sprEmployeeList.Col = 3;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["battalion_code"]);
				ViewModel.sprEmployeeList.Col = 4;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["unit_code"]);
				ViewModel.sprEmployeeList.Col = 5;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["shift_code"]);

				//Fill in the amounts...
				ViewModel.sprEmployeeList.Col = 6;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				//UPGRADE_WARNING: (1068) GetVal(oRec(DebitTaken)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				if (Convert.ToDouble(modGlobal.GetVal(oRec["DebitTaken"])) == 0)
				{
					ViewModel.sprEmployeeList.Text = "0";
				}
				else
				{
					dAmount = Convert.ToDouble(oRec["DebitTaken"]) / 2;
					ViewModel.sprEmployeeList.Text = dAmount.ToString();
				}
				ViewModel.sprEmployeeList.Col = 15;
				ViewModel.sprEmployeeList.Text = Convert.ToDouble(oRec["DebitTaken"]).ToString();
				ViewModel.sprEmployeeList.Col = 7;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				//UPGRADE_WARNING: (1068) GetVal(oRec(PaidDebit)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				if (Convert.ToDouble(modGlobal.GetVal(oRec["PaidDebit"])) == 0)
				{
					ViewModel.sprEmployeeList.Text = "0";
				}
				else
				{
					dAmount = Convert.ToDouble(oRec["PaidDebit"]) / 2;
					ViewModel.sprEmployeeList.Text = dAmount.ToString();
				}
				ViewModel.sprEmployeeList.Col = 16;
				ViewModel.sprEmployeeList.Text = Convert.ToDouble(oRec["PaidDebit"]).ToString();

				//If DebitTaken <> PaidDebit... Red Bold the font...
				if (Convert.ToDouble(oRec["DebitTaken"]) != (Convert.ToDouble(oRec["PaidDebit"]) + Convert.ToDouble(oRec["PaidUDD"])))
				{
					ViewModel.sprEmployeeList.Col = 6;
					ViewModel.sprEmployeeList.FontBold = true;

					//sprEmployeeList.Col = 7
					//sprEmployeeList.FontBold = True
					//sprEmployeeList.ForeColor = RED
				}
				else
				{
					ViewModel.sprEmployeeList.Col = 6;
					ViewModel.sprEmployeeList.FontBold = false;
					ViewModel.sprEmployeeList.Col2 = 7;
					ViewModel.sprEmployeeList.FontBold = false;
				}
				ViewModel.sprEmployeeList.Col = 8;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				//UPGRADE_WARNING: (1068) GetVal(oRec(PaidUDD)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				if (Convert.ToDouble(modGlobal.GetVal(oRec["PaidUDD"])) == 0)
				{
					ViewModel.sprEmployeeList.Text = "0";
				}
				else
				{
					dAmount = Convert.ToDouble(oRec["PaidUDD"]) / 2;
					ViewModel.sprEmployeeList.Text = dAmount.ToString();
				}
				ViewModel.sprEmployeeList.Col = 17;
				ViewModel.sprEmployeeList.Text = Convert.ToDouble(oRec["PaidDebit"]).ToString();
				ViewModel.sprEmployeeList.Col = 9;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				//UPGRADE_WARNING: (1068) GetVal(oRec(FutureDebit)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				if (Convert.ToDouble(modGlobal.GetVal(oRec["FutureDebit"])) == 0)
				{
					ViewModel.sprEmployeeList.Text = "0";
				}
				else
				{
					dAmount = Convert.ToDouble(oRec["FutureDebit"]) / 2;
					ViewModel.sprEmployeeList.Text = dAmount.ToString();
				}
				ViewModel.sprEmployeeList.Col = 18;
				ViewModel.sprEmployeeList.Text = Convert.ToDouble(oRec["FutureDebit"]).ToString();
				ViewModel.sprEmployeeList.Col = 10;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				//UPGRADE_WARNING: (1068) GetVal(oRec(TotalDebit)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				if (Convert.ToDouble(modGlobal.GetVal(oRec["TotalDebit"])) == 0)
				{
					ViewModel.sprEmployeeList.Text = "0";
				}
				else
				{
					dAmount = Convert.ToDouble(oRec["TotalDebit"]) / 2;
					ViewModel.sprEmployeeList.Text = dAmount.ToString();
				}
				ViewModel.sprEmployeeList.Col = 19;
				ViewModel.sprEmployeeList.Text = Convert.ToDouble(oRec["TotalDebit"]).ToString();
				ViewModel.sprEmployeeList.Col = 11;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				//UPGRADE_WARNING: (1068) GetVal(oRec(HolidayTaken)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				if (Convert.ToDouble(modGlobal.GetVal(oRec["HolidayTaken"])) == 0)
				{
					ViewModel.sprEmployeeList.Text = "0";
				}
				else
				{
					dAmount = Convert.ToDouble(oRec["HolidayTaken"]) / 2;
					ViewModel.sprEmployeeList.Text = dAmount.ToString();
				}
				ViewModel.sprEmployeeList.Col = 20;
				ViewModel.sprEmployeeList.Text = Convert.ToDouble(oRec["HolidayTaken"]).ToString();
				ViewModel.sprEmployeeList.Col = 12;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				//UPGRADE_WARNING: (1068) GetVal(oRec(PaidHoliday)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				if (Convert.ToDouble(modGlobal.GetVal(oRec["PaidHoliday"])) == 0)
				{
					ViewModel.sprEmployeeList.Text = "0";
				}
				else
				{
					dAmount = Convert.ToDouble(oRec["PaidHoliday"]) / 2;
					ViewModel.sprEmployeeList.Text = dAmount.ToString();
				}
				ViewModel.sprEmployeeList.Col = 21;
				ViewModel.sprEmployeeList.Text = Convert.ToDouble(oRec["PaidHoliday"]).ToString();
				ViewModel.sprEmployeeList.Col = 13;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				//UPGRADE_WARNING: (1068) GetVal(oRec(FutureHoliday)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				if (Convert.ToDouble(modGlobal.GetVal(oRec["FutureHoliday"])) == 0)
				{
					ViewModel.sprEmployeeList.Text = "0";
				}
				else
				{
					dAmount = Convert.ToDouble(oRec["FutureHoliday"]) / 2;
					ViewModel.sprEmployeeList.Text = dAmount.ToString();
				}
				ViewModel.sprEmployeeList.Col = 22;
				ViewModel.sprEmployeeList.Text = Convert.ToDouble(oRec["FutureHoliday"]).ToString();
				ViewModel.sprEmployeeList.Col = 14;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				//UPGRADE_WARNING: (1068) GetVal(oRec(TotalHoliday)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				if (Convert.ToDouble(modGlobal.GetVal(oRec["TotalHoliday"])) == 0)
				{
					ViewModel.sprEmployeeList.Text = "0";
				}
				else
				{
					dAmount = Convert.ToDouble(oRec["TotalHoliday"]) / 2;
					ViewModel.sprEmployeeList.Text = dAmount.ToString();
				}
				ViewModel.sprEmployeeList.Col = 23;
				ViewModel.sprEmployeeList.Text = Convert.ToDouble(oRec["TotalHoliday"]).ToString();

				oRec.MoveNext();
			};

			if (GridRow > 0)
			{
				ViewModel.sprEmployeeList.MaxRows = GridRow;
			}
			else
			{
				ViewModel.sprEmployeeList.MaxRows = 1;
			}
			ViewModel.lbCount.Text = "List Count: " + GridRow.ToString();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboYear_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}
			if (modGlobal.Clean(ViewModel.cboYear.Text) == "")
			{
				return;
			}

			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			ViewModel.ReportYear = Convert.ToString(modGlobal.GetVal(ViewModel.cboYear.Text));
			FormatReport();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClear_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.FirstTime = true;
			ViewModel.ReportYear = DateTime.Now.Year.ToString();
			ViewModel.ReportDate = DateTime.Now.ToString("MM/dd/yyyy");
			ViewModel.ReportBatt = "";
			ViewModel.ReportShift = "";
			ViewModel.optAll.Checked = true;
			ViewModel.optA.Checked = false;
			ViewModel.optB.Checked = false;
			ViewModel.optC.Checked = false;
			ViewModel.optD.Checked = false;
			ViewModel.cboYear.Text = ViewModel.ReportYear;
			ViewModel.dteReportDate.Text = ViewModel.ReportDate;
			ViewModel.FirstTime = false;
			FormatReport();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//MsgBox "This option is under construction", vbOKOnly, "Print Debit/Holiday Audit"
			//Print Employee Grid List
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprEmployeeList.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeList.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprEmployeeList.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeList.setPrintBorder(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprEmployeeList.PrintColHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeList.setPrintColHeaders(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprEmployeeList.PrintSmartPrint was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeList.setPrintSmartPrint(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprEmployeeList.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeList.setPrintAbortMsg("Printing PTS Debit/Holiday Audit Report");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprEmployeeList.PrintSheet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//object tempRefParam = null;
			//WEBMAP_UPGRADE_ISSUE: (1101) FarPoint.Win.Spread.FpSpread.PrintSheet was not upgraded
			ViewModel.sprEmployeeList.PrintSheet(null);
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ViewModel.FirstTime = true;
			ViewModel.ReportYear = DateTime.Now.Year.ToString();
			ViewModel.ReportDate = DateTime.Now.ToString("MM/dd/yyyy");
			ViewModel.ReportBatt = "";
			ViewModel.ReportShift = "";
			ViewModel.optAll.Checked = true;
			ViewModel.optA.Checked = false;
			ViewModel.optB.Checked = false;
			ViewModel.optC.Checked = false;
			ViewModel.optD.Checked = false;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			oCmd.CommandText = "sp_GetYearList ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			//Initialize Year Combobox
			ViewModel.cboYear.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboYear.AddItem(Convert.ToString(oRec["cal_year"]).Trim());
				oRec.MoveNext();
			};
			ViewModel.cboYear.Text = ViewModel.ReportYear;
			ViewModel.dteReportDate.Text = ViewModel.ReportDate;

			FormatReport();
			ViewModel.FirstTime = false;

		}

		[UpgradeHelpers.Events.Handler]
		internal void opt181_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.ReportBatt = "1";
				FormatReport();

			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void opt182_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.ReportBatt = "2";
				FormatReport();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void opt183_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.ReportBatt = "3";
				FormatReport();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optA_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.ReportShift = "A";
				FormatReport();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optAll_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.ReportBatt = "";
				ViewModel.ReportShift = "";
				ViewModel.optA.Checked = false;
				ViewModel.optB.Checked = false;
				ViewModel.optC.Checked = false;
				ViewModel.optD.Checked = false;

				FormatReport();

			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optB_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.ReportShift = "B";
				FormatReport();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optC_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.ReportShift = "C";
				FormatReport();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optD_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.ReportShift = "D";
				FormatReport();
			}
		}

		//UPGRADE_WARNING: (2050) FPSpreadADO.fpSpread Event sprEmployeeList.BeforeUserSort was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2050.aspx

		private void sprEmployeeList_BeforeUserSort(int Col, int State, ref int DefaultAction)
		{
			switch(Col)
			{
				case 6 :
					DefaultAction = 2;
					ViewModel.sprEmployeeList.SetSortKey(1, 15);
					ViewModel.sprEmployeeList.SetSortKey(2, 2);
					break;
				case 7 :
					DefaultAction = 2;
					ViewModel.sprEmployeeList.SetSortKey(1, 16);
					ViewModel.sprEmployeeList.SetSortKey(2, 2);
					break;
				case 8 :
					DefaultAction = 2;
					ViewModel.sprEmployeeList.SetSortKey(1, 17);
					ViewModel.sprEmployeeList.SetSortKey(2, 2);
					break;
				case 9 :
					DefaultAction = 2;
					ViewModel.sprEmployeeList.SetSortKey(1, 18);
					ViewModel.sprEmployeeList.SetSortKey(2, 2);
					break;
				case 10 :
					DefaultAction = 2;
					ViewModel.sprEmployeeList.SetSortKey(1, 19);
					ViewModel.sprEmployeeList.SetSortKey(2, 2);
					break;
				case 11 :
					DefaultAction = 2;
					ViewModel.sprEmployeeList.SetSortKey(1, 20);
					ViewModel.sprEmployeeList.SetSortKey(2, 2);
					break;
				case 12 :
					DefaultAction = 2;
					ViewModel.sprEmployeeList.SetSortKey(1, 21);
					ViewModel.sprEmployeeList.SetSortKey(2, 2);
					break;
				case 13 :
					DefaultAction = 2;
					ViewModel.sprEmployeeList.SetSortKey(1, 22);
					ViewModel.sprEmployeeList.SetSortKey(2, 2);
					break;
				case 14 :
					DefaultAction = 2;
					ViewModel.sprEmployeeList.SetSortKey(1, 23);
					ViewModel.sprEmployeeList.SetSortKey(2, 2);
					break;
				default:
					DefaultAction = 1;
					{
					}
					sprEmployeeList_CellClick(ViewModel.sprEmployeeList, new Stubs._FarPoint.Win.Spread.CellClickEventArgs(1, 1));
					return;
			}

			if (State == 1)
			{
				ViewModel.sprEmployeeList.SetSortKeyOrder(1, FarPoint.ViewModels.SortKeyOrderConstants.SortKeyOrderDescending);
				ViewModel.sprEmployeeList.SetSortKeyOrder(2, FarPoint.ViewModels.SortKeyOrderConstants.SortKeyOrderAscending);
				//ViewModel.sprEmployeeList.SetColUserSortIndicator(Col, FarPoint.ViewModels.SortIndicator.Descending);
			}
else
{
				ViewModel.sprEmployeeList.SetSortKeyOrder(1, FarPoint.ViewModels.SortKeyOrderConstants.SortKeyOrderAscending);
				ViewModel.sprEmployeeList.SetSortKeyOrder(2, FarPoint.ViewModels.SortKeyOrderConstants.SortKeyOrderAscending);
				//ViewModel.sprEmployeeList.SetColUserSortIndicator(Col, FarPoint.ViewModels.SortIndicator.Ascending);
			}

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprEmployeeList.Sort was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//object tempRefParam = null;
			//object tempRefParam2 = null;
			ViewModel.sprEmployeeList.Sort(-1, -1, -1, -1, FarPoint.ViewModels.SortByConstants.SortByRow, null, null);
			sprEmployeeList_CellClick(ViewModel.sprEmployeeList, new Stubs._FarPoint.Win.Spread.CellClickEventArgs(1, 1));
		}

		private void sprEmployeeList_CellClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
		{
			int Col = eventArgs.Column;
			int Row = eventArgs.Row;
			if (Row == 0)
			{
				return;
			}
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmDebitHoliday DefInstance
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

		public static frmDebitHoliday CreateInstance()
		{
			PTSProject.frmDebitHoliday theInstance = Shared.Container.Resolve< frmDebitHoliday>();
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
			ViewModel.sprEmployeeList.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprEmployeeList.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmDebitHoliday
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmDebitHolidayViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmDebitHoliday m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}