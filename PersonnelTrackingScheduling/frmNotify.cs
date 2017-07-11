using Microsoft.VisualBasic;
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

	public partial class frmNotify
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmNotifyViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmNotify));
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


		private void frmNotify_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		public void ClearGrid()
		{
			//Clear Grid
			ViewModel.sprPay.Row = 1;
			ViewModel.sprPay.Col = 14;
			ViewModel.sprPay.Text = "";
			ViewModel.sprPay.Row = 2;
			ViewModel.sprPay.Text = "";

			for (int CurrRow = 4; CurrRow <= 13; CurrRow++)
			{
				for (int CurrCol = 1; CurrCol <= 20; CurrCol++)
				{
					ViewModel.sprPay.Col = CurrCol;
					ViewModel.sprPay.Row = CurrRow;
					ViewModel.sprPay.Text = "";
					ViewModel.sprPay.TypeButtonText = "";
					if ( ViewModel.sprPay.Row == 4 || ViewModel.sprPay.Row == 9)
					{
					}
				}
			}
			ViewModel.sprPay.BlockMode = true;
			ViewModel.sprPay.Col = 1;
			ViewModel.sprPay.Row = 14;
			ViewModel.sprPay.Col2 = ViewModel.sprPay.MaxCols;
			ViewModel.sprPay.Row2 = ViewModel.sprPay.MaxRows;
			ViewModel.sprPay.Text = "";
			ViewModel.sprPay.BlockMode = false;

		}

		public void FillGrid()
		{
			//Fill Grid with Pay Period status
			//For Each Day within Pay Period
			int DDay = 0;
			string DMonth = "";
			int i = 0, LockStat1 = 0;
			int LockStat3 = 0, LockStat2 = 0;
			int CurrRow = 0, CurrCol = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			ClearGrid();

			int PayPeriod = ViewModel.cboNotify.GetItemData(ViewModel.cboNotify.SelectedIndex);
			ViewModel.sprPay.Row = 1;
			ViewModel.sprPay.Col = 14;
			ViewModel.sprPay.Text = ViewModel.cboNotify.Text;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//Look up Status of PayPeriod
			oCmd.CommandText = "sp_GetPPStatus " + PayPeriod.ToString() + "," + modGlobal.Shared.gPayrollYear.ToString();
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				ViewModel.sprPay.Row = 2;
				ViewModel.sprPay.Col = 11;
				if (Convert.ToBoolean(oRec["status"]))
				{
					ViewModel.sprPay.Text = "Pay Period Closed";
					ViewModel.sprPay.BlockMode = true;
					ViewModel.sprPay.Row2 = 2;
					ViewModel.sprPay.Col2 = 14;
					ViewModel.sprPay.BlockMode = false;
					ViewModel.cmdClosePeriod.Text = "&Re-Open Pay Period";
					ViewModel.cmdClosePeriod.Tag = "Closed";
				}
				else
				{
					ViewModel.sprPay.Text = "Pay Period Open";
					ViewModel.sprPay.BlockMode = true;
					ViewModel.sprPay.Row2 = 2;
					ViewModel.sprPay.Col2 = 14;
					ViewModel.sprPay.BlockMode = false;
					ViewModel.cmdClosePeriod.Text = "&Close Pay Period";
					ViewModel.cmdClosePeriod.Tag = "Open";
				}
			}
			else
			{
				ViewManager.ShowMessage("Unable to Access Pay Period Status", "Pay Period Review", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			oCmd.CommandText = "sp_GetPPDetail " + PayPeriod.ToString() + "," + modGlobal.Shared.gPayrollYear.ToString();
			oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				DMonth = Convert.ToDateTime(oRec["shift_start"]).ToString("MMMM");
				i = 1;
				modGlobal.Shared.gPayPeriod = PayPeriod;
			}
			else
			{
				ViewManager.ShowMessage("No PayRoll Signoff Records for this Pay Period", "Pay Period Review", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}


			while(!oRec.EOF)
			{
				LockStat1 = 0;
				LockStat2 = 0;
				LockStat3 = 0;
				switch(i)
				{
					case 1 :
						ViewModel.sprPay.Row = 4;
						ViewModel.sprPay.Col = 1;
						ViewModel.sprPay.Text = DMonth;
						CurrRow = 5;
						CurrCol = 1;
						break;
					case 2 :
						if (Convert.ToDateTime(oRec["shift_start"]).ToString("MMMM") != DMonth)
						{
							ViewModel.sprPay.Row = 4;
							ViewModel.sprPay.Col = 4;
							DMonth = Convert.ToDateTime(oRec["shift_start"]).ToString("MMMM");
							ViewModel.sprPay.Text = DMonth;
						}
						CurrRow = 5;
						CurrCol = 4;
						break;
					case 3 :
						if (Convert.ToDateTime(oRec["shift_start"]).ToString("MMMM") != DMonth)
						{
							ViewModel.sprPay.Row = 4;
							ViewModel.sprPay.Col = 7;
							DMonth = Convert.ToDateTime(oRec["shift_start"]).ToString("MMMM");
							ViewModel.sprPay.Text = DMonth;
						}
						CurrRow = 5;
						CurrCol = 7;
						break;
					case 4 :
						if (Convert.ToDateTime(oRec["shift_start"]).ToString("MMMM") != DMonth)
						{
							ViewModel.sprPay.Row = 4;
							ViewModel.sprPay.Col = 10;
							DMonth = Convert.ToDateTime(oRec["shift_start"]).ToString("MMMM");
							ViewModel.sprPay.Text = DMonth;
						}
						CurrRow = 5;
						CurrCol = 10;
						break;
					case 5 :
						if (Convert.ToDateTime(oRec["shift_start"]).ToString("MMMM") != DMonth)
						{
							ViewModel.sprPay.Row = 4;
							ViewModel.sprPay.Col = 13;
							DMonth = Convert.ToDateTime(oRec["shift_start"]).ToString("MMMM");
							ViewModel.sprPay.Text = DMonth;
						}
						CurrRow = 5;
						CurrCol = 13;
						break;
					case 6 :
						if (Convert.ToDateTime(oRec["shift_start"]).ToString("MMMM") != DMonth)
						{
							ViewModel.sprPay.Row = 4;
							ViewModel.sprPay.Col = 16;
							DMonth = Convert.ToDateTime(oRec["shift_start"]).ToString("MMMM");
							ViewModel.sprPay.Text = DMonth;
						}
						CurrRow = 5;
						CurrCol = 16;
						break;
					case 7 :
						if (Convert.ToDateTime(oRec["shift_start"]).ToString("MMMM") != DMonth)
						{
							ViewModel.sprPay.Row = 4;
							ViewModel.sprPay.Col = 19;
							DMonth = Convert.ToDateTime(oRec["shift_start"]).ToString("MMMM");
							ViewModel.sprPay.Text = DMonth;
						}
						CurrRow = 5;
						CurrCol = 19;
						break;
					case 8 :
						if (Convert.ToDateTime(oRec["shift_start"]).ToString("MMMM") != DMonth)
						{
							ViewModel.sprPay.Row = 9;
							ViewModel.sprPay.Col = 1;
							DMonth = Convert.ToDateTime(oRec["shift_start"]).ToString("MMMM");
							ViewModel.sprPay.Text = DMonth;
						}
						CurrRow = 10;
						CurrCol = 1;
						break;
					case 9 :
						if (Convert.ToDateTime(oRec["shift_start"]).ToString("MMMM") != DMonth)
						{
							ViewModel.sprPay.Row = 9;
							ViewModel.sprPay.Col = 4;
							DMonth = Convert.ToDateTime(oRec["shift_start"]).ToString("MMMM");
							ViewModel.sprPay.Text = DMonth;
						}
						CurrRow = 10;
						CurrCol = 4;
						break;
					case 10 :
						if (Convert.ToDateTime(oRec["shift_start"]).ToString("MMMM") != DMonth)
						{
							ViewModel.sprPay.Row = 9;
							ViewModel.sprPay.Col = 7;
							DMonth = Convert.ToDateTime(oRec["shift_start"]).ToString("MMMM");
							ViewModel.sprPay.Text = DMonth;
						}
						CurrRow = 10;
						CurrCol = 7;
						break;
					case 11 :
						if (Convert.ToDateTime(oRec["shift_start"]).ToString("MMMM") != DMonth)
						{
							ViewModel.sprPay.Row = 9;
							ViewModel.sprPay.Col = 10;
							DMonth = Convert.ToDateTime(oRec["shift_start"]).ToString("MMMM");
							ViewModel.sprPay.Text = DMonth;
						}
						CurrRow = 10;
						CurrCol = 10;
						break;
					case 12 :
						if (Convert.ToDateTime(oRec["shift_start"]).ToString("MMMM") != DMonth)
						{
							ViewModel.sprPay.Row = 9;
							ViewModel.sprPay.Col = 13;
							DMonth = Convert.ToDateTime(oRec["shift_start"]).ToString("MMMM");
							ViewModel.sprPay.Text = DMonth;
						}
						CurrRow = 10;
						CurrCol = 13;
						break;
					case 13 :
						if (Convert.ToDateTime(oRec["shift_start"]).ToString("MMMM") != DMonth)
						{
							ViewModel.sprPay.Row = 9;
							ViewModel.sprPay.Col = 16;
							DMonth = Convert.ToDateTime(oRec["shift_start"]).ToString("MMMM");
							ViewModel.sprPay.Text = DMonth;
						}
						CurrRow = 10;
						CurrCol = 16;
						break;
					case 14 :
						if (Convert.ToDateTime(oRec["shift_start"]).ToString("MMMM") != DMonth)
						{
							ViewModel.sprPay.Row = 9;
							ViewModel.sprPay.Col = 19;
							DMonth = Convert.ToDateTime(oRec["shift_start"]).ToString("MMMM");
							ViewModel.sprPay.Text = DMonth;
						}
						CurrRow = 10;
						CurrCol = 19;
						break;
				}

				//Batt 1 SignOff
				ViewModel.sprPay.Row = CurrRow + 10;
				ViewModel.sprPay.Col = CurrCol + 1;
				ViewModel.sprPay.Text = Convert.ToString(oRec["signoff_id"]);
				ViewModel.sprPay.Row = CurrRow;
				ViewModel.sprPay.Col = CurrCol;
				DDay = Convert.ToInt32(Double.Parse(Convert.ToDateTime(oRec["shift_start"]).ToString("d")));
				ViewModel.sprPay.TypeButtonText = DDay.ToString();
				LockStat1 = Convert.ToInt32(oRec["status"]);

				if (LockStat1 != 0)
				{
					ViewModel.sprPay.Row = CurrRow + 1;
					System.DateTime TempDate = DateTime.FromOADate(0);
					ViewModel.sprPay.Text = modGlobal.Clean(oRec["battalion_code"]).Trim() + "-" + modGlobal.Clean(oRec["name_last"]).Trim() + ": " + ((DateTime.TryParse(modGlobal.Clean(oRec["last_update_date"]), out TempDate)) ? TempDate.ToString("M/d") : modGlobal.Clean(oRec["last_update_date"]));
				}

				//Batt 2 SignOff
				oRec.MoveNext();
				if (!oRec.EOF)
				{
					if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(Convert.ToDateTime(oRec["shift_start"]).ToString("d")) == DDay)
					{
						LockStat2 = Convert.ToInt32(oRec["status"]);
						if (LockStat2 != 0)
						{
							ViewModel.sprPay.Row = CurrRow + 2;
							System.DateTime TempDate2 = DateTime.FromOADate(0);
							ViewModel.sprPay.Text = modGlobal.Clean(oRec["battalion_code"]).Trim() + "-" + modGlobal.Clean(oRec["name_last"]).Trim() + ": " + ((DateTime.TryParse(modGlobal.Clean(oRec["last_update_date"]), out TempDate2)) ? TempDate2.ToString("M/d") : modGlobal.Clean(oRec["last_update_date"]));
						}
						ViewModel.sprPay.Row = CurrRow + 11;
						ViewModel.sprPay.Col = CurrCol + 1;
						ViewModel.sprPay.Text = Convert.ToString(oRec["signoff_id"]);
						ViewModel.sprPay.Row = CurrRow;
						ViewModel.sprPay.Col = CurrCol + 1;
					}
					else
					{
						ViewModel.sprPay.Row = CurrRow;
						ViewModel.sprPay.Col = CurrCol + 1;
						ViewModel.sprPay.Text = "OPEN";
					}
				}
				else
				{
					ViewModel.sprPay.Row = CurrRow;
					ViewModel.sprPay.Col = CurrCol + 1;
					ViewModel.sprPay.Text = "OPEN";
				}

				//'Batt 3 SignOff
				oRec.MoveNext();
				if (!oRec.EOF)
				{
					if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(Convert.ToDateTime(oRec["shift_start"]).ToString("d")) == DDay)
					{
						LockStat3 = Convert.ToInt32(oRec["status"]);
						if (LockStat3 != 0)
						{
							ViewModel.sprPay.Col = CurrCol;
							ViewModel.sprPay.Row = CurrRow + 3;
							System.DateTime TempDate3 = DateTime.FromOADate(0);
							ViewModel.sprPay.Text = modGlobal.Clean(oRec["battalion_code"]).Trim() + "-" + modGlobal.Clean(oRec["name_last"]).Trim() + ": " + ((DateTime.TryParse(modGlobal.Clean(oRec["last_update_date"]), out TempDate3)) ? TempDate3.ToString("M/d") : modGlobal.Clean(oRec["last_update_date"]));
						}
						ViewModel.sprPay.Row = CurrRow + 12;
						ViewModel.sprPay.Col = CurrCol + 1;
						ViewModel.sprPay.Text = Convert.ToString(oRec["signoff_id"]);
						ViewModel.sprPay.Row = CurrRow;
						ViewModel.sprPay.Col = CurrCol + 1;
						if ((LockStat1 & LockStat2 & LockStat3) != 0)
						{
							ViewModel.sprPay.Text = "LOCKED";
						}
						else
						{
							ViewModel.sprPay.Text = "OPEN";
						}
						oRec.MoveNext();
					}
					else
					{
						ViewModel.sprPay.Row = CurrRow;
						ViewModel.sprPay.Col = CurrCol + 1;
						ViewModel.sprPay.Text = "OPEN";
					}
					i++;
				}
				else
				{
					ViewModel.sprPay.Row = CurrRow;
					ViewModel.sprPay.Col = CurrCol + 1;
					ViewModel.sprPay.Text = "OPEN";
				}
			};



		}

		[UpgradeHelpers.Events.Handler]
		internal void cboNotify_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Fill Grid Dates
			FillGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClosePeriod_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Determine if Close or Open request
			//Update PayRoll_PayPeriod Record

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			int PayPeriod = ViewModel.cboNotify.GetItemData(ViewModel.cboNotify.SelectedIndex);
			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			if (Convert.ToString(ViewModel.cmdClosePeriod.Tag) == "Open")
			{
				oCmd.CommandText = "spUpdate_PayPeriodStatus " + PayPeriod.ToString() + "," + modGlobal.Shared.gPayrollYear.ToString() + ",1";
				oCmd.ExecuteNonQuery();
				ViewModel.sprPay.Row = 2;
				ViewModel.sprPay.Col = 11;
				ViewModel.sprPay.Text = "Pay Period Closed";
				ViewModel.sprPay.BlockMode = true;
				ViewModel.sprPay.Row2 = 2;
				ViewModel.sprPay.Col2 = 14;
				ViewModel.sprPay.BlockMode = false;
				ViewModel.cmdClosePeriod.Text = "&Re-Open Pay Period";
				ViewModel.cmdClosePeriod.Tag = "Closed";
			}
			else
			{
				oCmd.CommandText = "spUpdate_PayPeriodStatus " + PayPeriod.ToString() + "," + modGlobal.Shared.gPayrollYear.ToString() + ",0";
				oCmd.ExecuteNonQuery();
				ViewModel.sprPay.Row = 2;
				ViewModel.sprPay.Col = 11;
				ViewModel.sprPay.Text = "Pay Period Open";
				ViewModel.sprPay.BlockMode = true;
				ViewModel.sprPay.Row2 = 2;
				ViewModel.sprPay.Col2 = 14;
				ViewModel.sprPay.BlockMode = false;
				ViewModel.cmdClosePeriod.Text = "&Close Pay Period";
				ViewModel.cmdClosePeriod.Tag = "Open";
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPayDetail_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//open Review Individual Time Cards Window
			modGlobal
				.Shared.gPayPeriod = 0;
			modGlobal.Shared.gReportUser = "";
			modGlobal.Shared.gStartTrans = DateTime.Now.ToString("M/d/yyyy");
			ViewManager.NavigateToView(
				frmIndTimeCard.DefInstance);
			/*			frmIndTimeCard.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			modGlobal.Shared.gReportUser = "";
			//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Timestamp report and print
			ViewModel.sprPay.Col = 14;
			ViewModel.sprPay.Row = 16;
			ViewModel.sprPay.Text = DateTime.Now.ToString("M/d/yy HH:mm");

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPay.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprPay.setPrintAbortMsg("Printing Pay Period Review - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPay.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprPay.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPay.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprPay.setPrintColor(true);
            //    sprPay.PrintOrientation = 2
            ViewModel.sprPay.PrintSheet(null);
			//ViewModel.sprPay.Action = (FarPoint.ViewModels.FPActionConstants) 32;

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			//Customize by menu selection
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			ViewModel.cboNotify.Items.Clear();
			modGlobal.Shared.gPayrollYear = modGlobal.Shared.gCurrentYear;

			oCmd.CommandText = "spSelect_PayRollYearPayPeriod '" + DateTime.Now.ToString("M/d/yyyy") + "' ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				modGlobal.Shared.gPayrollYear = Convert.ToInt32(oRec["calendar_year"]);
			}

			oCmd.CommandText = "sp_GetPayRollPeriods " + modGlobal.Shared.gPayrollYear.ToString();
			oRec = ADORecordSetHelper.Open(oCmd, "");

			while(!oRec.EOF)
			{
				ViewModel.cboNotify.AddItem(Convert.ToString(oRec["start_date"]) + " - " + Convert.ToString(oRec["end_date"]));
				ViewModel.cboNotify.SetItemData(ViewModel.cboNotify.GetNewIndex(), Convert.ToInt32(oRec["pay_period"]));
				oRec.MoveNext();
			};

			modGlobal.Shared.gPayPeriod = 0;
			ViewModel.SignOffAuthority = false;

			if (modGlobal.Shared.gSecurity == "ADM")
			{
				ViewModel.SignOffAuthority = true;
				ViewModel.cmdClosePeriod.Enabled = true;
			}
			//    If gSecurity = "PER" Then
			//        If gUserLogon <> "PDUNDAS" And gUserLogon <> "LDAY" And gUserLogon <> "YCHISA" _
			//'        And gUserLogon <> "MWALTER" And gUserLogon <> "PBUCHANA" _
			//'        And gUserLogon <> "JSTILL" Then
			//            'continue
			//        Else
			//            SignOffAuthority = True
			//            cmdClosePeriod.Enabled = True
			//        End If
			//    End If

		}


		private void sprPay_ButtonClicked(object eventSender, Stubs._FarPoint.Win.Spread.EditorNotifyEventArgs eventArgs)
		{
			int Col = eventArgs.Column;
			int Row = eventArgs.Row;
			//int ButtonDown = 0;
			//Display and Fill lstLog with SignOff log entries
			//For Selected Date
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string ListStr = "";
			ViewModel.sprPay.Row = Row + 10;
			ViewModel.sprPay.Col = Col + 1;
			int SignOff1 = Convert.ToInt32(Conversion.Val(ViewModel.sprPay.Text));
			ViewModel.sprPay.Row = Row + 11;
			int SignOff2 = Convert.ToInt32(Conversion.Val(ViewModel.sprPay.Text));
			ViewModel.sprPay.Row = Row + 12;
			int SignOff3 = Convert.ToInt32(Conversion.Val(ViewModel.sprPay.Text));

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "sp_GetSignLog " + SignOff1.ToString() + "," + SignOff2.ToString() + "," + SignOff3.ToString();
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.lstLog.Items.Clear();

			while(!oRec.EOF)
			{
				ListStr = Convert.ToDateTime(oRec["activity_date"]).ToString("M/d/yyyy HH:mm");
				if (Convert.ToString(oRec["battalion_code"]).Trim() == "1")
				{
					ListStr = ListStr + " Batt 1 - ";
				}
				else if (Convert.ToString(oRec["battalion_code"]).Trim() == "2")
				{
					ListStr = ListStr + " Batt 2 - ";
				}
				else
				{
					ListStr = ListStr + " Batt 3 - ";
				}
				if (Convert.ToDouble(oRec["log_description_code"]) == 1)
				{
					ListStr = ListStr + " LOCKED    ";
				}
				else
				{
					ListStr = ListStr + " UNLOCKED  ";
				}
				ListStr = ListStr + modGlobal.Clean(oRec["name_last"]).Trim();
				ViewModel.lstLog.AddItem(ListStr);
				oRec.MoveNext();
			};


		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmNotify DefInstance
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

		public static frmNotify CreateInstance()
		{
			PTSProject.frmNotify theInstance = Shared.Container.Resolve< frmNotify>();
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
			ViewModel.sprPay.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprPay.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmNotify
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmNotifyViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmNotify m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}