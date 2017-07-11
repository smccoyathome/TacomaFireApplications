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

	public partial class frmTransferReport
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmTransferReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmTransferReport));
			if ( Shared.m_vb6FormDefInstance == null)
			{
				if ( Shared.m_InitializingDefInstance)
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
		}


		private void frmTransferReport_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//********************************
		//* Individual Transfer Report      *
		//********************************
		//ADODB

		public bool FillSpread()
		{
			//Fill Spread Control with data for selected employee

			bool result = false;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string NewShift = "", NewDebit = "";
			float PriorShifts = 0, FutureShifts = 0;
			float PriorDebits = 0, FutureDebits = 0;

			result = true;
			ViewModel.sprIndiv.Row = 2;
			ViewModel.sprIndiv.Col = 8;
			ViewModel.sprIndiv.Text = DateTime.Now.ToString("M/d/yyyy HH:mm");

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spReport_Employee '" + ViewModel.Empid + "'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (!oRec.EOF)
			{
				ViewModel.sprIndiv.Row = 4;
				ViewModel.sprIndiv.Col = 2;
				ViewModel.sprIndiv.Text = Convert.ToString(oRec["name_full"]).Trim();
				ViewModel.sprIndiv.Col = 6;
				ViewModel.sprIndiv.Text = Convert.ToString(oRec["employee_id"]);
				ViewModel.sprIndiv.Row = 5;
				ViewModel.sprIndiv.Col = 2;
				ViewModel.sprIndiv.Text = modGlobal.Clean(oRec["unit_code"]).Trim() + " " + modGlobal.Clean(oRec["position_code"]).Trim() + "-" + modGlobal.Clean(oRec["shift_code"]);
				ViewModel.sprIndiv.Row = 6;
				ViewModel.sprIndiv.Col = 2;
				System.DateTime TempDate = DateTime.FromOADate(0);
				ViewModel.sprIndiv.Text = (DateTime.TryParse(modGlobal.Shared.gStartTrans, out TempDate)) ? TempDate.ToString("M/d/yyyy") : modGlobal.Shared.gStartTrans;
				ViewModel.sprIndiv.Col = 6;
				if (modGlobal.Shared.gTempTrans != 0)
				{
					ViewModel.sprIndiv.Text = "Temporary";
				}
				else
				{
					ViewModel.sprIndiv.Text = "Permanent";
				}
			}
			else
			{
				oCmd.CommandText = "spReport_Personnel '" + ViewModel.Empid + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					ViewModel.sprIndiv.Row = 4;
					ViewModel.sprIndiv.Col = 2;
					ViewModel.sprIndiv.Text = Convert.ToString(oRec["name_full"]).Trim();
					ViewModel.sprIndiv.Col = 6;
					ViewModel.sprIndiv.Text = Convert.ToString(oRec["employee_id"]);
					ViewModel.sprIndiv.Row = 6;
					ViewModel.sprIndiv.Col = 2;
					System.DateTime TempDate2 = DateTime.FromOADate(0);
					ViewModel.sprIndiv.Text = (DateTime.TryParse(modGlobal.Shared.gStartTrans, out TempDate2)) ? TempDate2.ToString("M/d/yyyy") : modGlobal.Shared.gStartTrans;
					ViewModel.sprIndiv.Col = 6;
					if (modGlobal.Shared.gTempTrans != 0)
					{
						ViewModel.sprIndiv.Text = "Temporary";
					}
					else
					{
						ViewModel.sprIndiv.Text = "Permanent";
					}
				}
				else
				{
					return false;
				}
			}

			oCmd.CommandText = "sp_GetAssignInfo " + ViewModel.NewPos.ToString();
			oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				ViewModel.sprIndiv.Row = 5;
				ViewModel.sprIndiv.Col = 6;
				ViewModel.sprIndiv.Text = Convert.ToString(oRec["unit_code"]).Trim() + " " + Convert.ToString(oRec["position_code"]).Trim() + "-" + Convert.ToString(oRec["shift_code"]);
				NewShift = Convert.ToString(oRec["shift_code"]);
				NewDebit = modGlobal.Clean(oRec["debit_group_code"]);
			}
			else
			{
				return false;
			}

			System.DateTime TempDate3 = DateTime.FromOADate(0);
			string YearStart = (DateTime.TryParse("1/1/" + DateTime.Parse(modGlobal.Shared.gStartTrans).Year.ToString(
							), out TempDate3)) ? TempDate3.ToString("M/d/yyyy") : "1/1/" + DateTime.Parse(modGlobal.Shared.gStartTrans).Year.ToString();
			System.DateTime TempDate4 = DateTime.FromOADate(0);
			string YearEnd = (DateTime.TryParse(modGlobal.Shared.gEndTrans, out TempDate4)) ? TempDate4.ToString("M/d/yyyy") : modGlobal.Shared.gEndTrans;
			ViewModel.CurrRow = 10;
			//List Future Scheduled Leave
			oCmd.CommandText = "spReport_TransLeave '" + ViewModel.Empid + "','" + modGlobal.Shared.gStartTrans + "','" + modGlobal.Shared.gEndTrans + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");



			while(!oRec.EOF)
			{
				ViewModel.sprIndiv.Row = ViewModel.CurrRow;
				ViewModel.sprIndiv.Col = 1;
				ViewModel.sprIndiv.Text = Convert.ToString(oRec["shift_date"]);
				ViewModel.sprIndiv.Col = 2;
				ViewModel.sprIndiv.Text = modGlobal.Clean(oRec["time_code_id"]);
				ViewModel.sprIndiv.Col = 3;
				ViewModel.sprIndiv.Text = Convert.ToString(oRec["AMPM"]);
				(ViewModel.CurrRow)++;
				oRec.MoveNext();
			};

			//create break between leave & debits
			ViewModel.sprIndiv.Row = ViewModel.CurrRow;
			ViewModel.sprIndiv.Col = 1;
			ViewModel.sprIndiv.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
			ViewModel.sprIndiv.Col = 2;
			ViewModel.sprIndiv.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
			ViewModel.sprIndiv.Col = 3;
			ViewModel.sprIndiv.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
			(ViewModel.CurrRow)++;

			oCmd.CommandText = "spReport_TransDebits '" + ViewModel.Empid + "','" + modGlobal.Shared.gStartTrans + "','" + modGlobal.Shared.gEndTrans + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				ViewModel.sprIndiv.Row = ViewModel.CurrRow;
				ViewModel.sprIndiv.Col = 1;
				ViewModel.sprIndiv.Text = Convert.ToString(oRec["shift_date"]);
				ViewModel.sprIndiv.Col = 2;
				ViewModel.sprIndiv.Text = modGlobal.Clean(oRec["time_code_id"]);
				ViewModel.sprIndiv.Col = 3;
				ViewModel.sprIndiv.Text = Convert.ToString(oRec["AMPM"]);
				(ViewModel.CurrRow)++;
				oRec.MoveNext();
			};
			ViewModel.LastRow = ViewModel.CurrRow;

			//List Trades to be Canceled
			oCmd.CommandText = "sp_GetCancelTradeDetails '" + modGlobal.Shared.gStartTrans + "','" + modGlobal.Shared.gEndTrans + "','" + ViewModel.Empid + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.CurrRow = 10;

			while(!oRec.EOF)
			{
				ViewModel.sprIndiv.Row = ViewModel.CurrRow;
				ViewModel.sprIndiv.Col = 5;
				ViewModel.sprIndiv.Text = Convert.ToDateTime(oRec["trade_date"]).ToString("M/d/yyyy");
				ViewModel.sprIndiv.Col = 6;
				ViewModel.sprIndiv.Text = Convert.ToString(oRec["sched_name"]);
				ViewModel.sprIndiv.Col = 7;
				ViewModel.sprIndiv.Text = Convert.ToString(oRec["working_name"]);
				ViewModel.sprIndiv.Col = 8;
				ViewModel.sprIndiv.Text = Convert.ToString(oRec["unit_code"]).Trim() + " " + Convert.ToString(oRec["position_code"]).Trim() + "-" + Convert.ToString(oRec["shift_code"]);
				ViewModel.sprIndiv.Col = 9;
				ViewModel.sprIndiv.Text = UpgradeHelpers.Helpers.StringsHelper.Format(oRec["trade_date"], "AM/PM");
				(ViewModel.CurrRow)++;
				oRec.MoveNext();
			};

			if ( ViewModel.CurrRow > ViewModel.LastRow)
			{
				ViewModel.LastRow = ViewModel.CurrRow;
			}
			ViewModel.CurrRow = ViewModel.LastRow + 1;

			//List Count of Debits worked vs Debits to be scheduled
			//And Shifts worked vs shifts to be scheduled for current year
			oCmd.CommandText = "spReport_PriorSched '" + YearStart + "','" + modGlobal.Shared.gStartTrans + "','" + ViewModel.Empid + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				PriorShifts = Convert.ToSingle(oRec["prior_sched"]);
			}
			else
			{
				PriorShifts = 0;
			}
			oCmd.CommandText = "spReport_FutureSched '" + modGlobal.Shared.gStartTrans + "','" + YearEnd + "','" + NewShift + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				FutureShifts = Convert.ToSingle(oRec["future_sched"]);
			}
			else
			{
				FutureShifts = 0;
			}

			oCmd.CommandText = "spReport_PriorDebit '" + YearStart + "','" + modGlobal.Shared.gStartTrans + "','" + ViewModel.Empid + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				PriorDebits = Convert.ToSingle(oRec["prior_debit"]);
			}
			else
			{
				PriorDebits = 0;
			}

			oCmd.CommandText = "spReport_FutureDebitNew '" + modGlobal.Shared.gStartTrans + "','" + YearEnd + "','" + ViewModel.Empid + "'";
			//    oCmd.CommandText = "spReport_FutureDebit '" & gStartTrans & "','" & YearEnd & "','" & NewDebit & "'"
			oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				FutureDebits = Convert.ToSingle(oRec["future_debit"]);
			}
			else
			{
				FutureDebits = 0;
			}
			ViewModel.sprIndiv.BlockMode = true;
			ViewModel.sprIndiv.Row = ViewModel.CurrRow;
			ViewModel.sprIndiv.Col = 1;
			ViewModel.sprIndiv.Row2 = 60;
			ViewModel.sprIndiv.Col2 = 9;
			//ViewModel.sprIndiv.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprIndiv.BlockMode = false;
			ViewModel.sprIndiv.Text = "Shift Summary";
			ViewModel.sprIndiv.Col = 6;
			ViewModel.sprIndiv.Text = "Debit Summary";
			(ViewModel.CurrRow)++;
			ViewModel.sprIndiv.Row = ViewModel.CurrRow;
			ViewModel.sprIndiv.Col = 1;
			ViewModel.sprIndiv.Text = "Total Shifts Worked Before Transfer: " + PriorShifts.ToString();
			ViewModel.sprIndiv.Row = ViewModel.CurrRow + 1;
			ViewModel.sprIndiv.Text = "Total Shifts Scheduled After Transfer: " + FutureShifts.ToString();
			ViewModel.sprIndiv.Row = ViewModel.CurrRow + 2;
			ViewModel.sprIndiv.Text = "Total Annual Shifts To Be Scheduled: " + (PriorShifts + FutureShifts).ToString();
			ViewModel.sprIndiv.Row = ViewModel.CurrRow;
			ViewModel.sprIndiv.Col = 6;
			ViewModel.sprIndiv.Text = "Total Debits Worked Before Transfer: " + PriorDebits.ToString();
			ViewModel.sprIndiv.Row = ViewModel.CurrRow + 1;
			ViewModel.sprIndiv.Text = "Total Debits Scheduled After Transfer: " + FutureDebits.ToString();
			ViewModel.sprIndiv.Row = ViewModel.CurrRow + 2;
			ViewModel.sprIndiv.Text = "Total Annual Debits To Be Scheduled: " + (PriorDebits + FutureDebits).ToString();



			return result;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Transfer Canceled
			modGlobal
				.Shared.gTransCancel = -1;
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdOK_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//OK Transfer
			modGlobal
				.Shared.gTransCancel = 0;
			ViewManager.DisposeView(this);

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprIndiv.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprIndiv.setPrintAbortMsg("Printing Individual Transfer Report - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprIndiv.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprIndiv.setPrintBorder(false);
			//    sprIndiv.PrintOrientation = 1
			//ViewModel.sprIndiv.Action = (FarPoint.ViewModels.FPActionConstants) 13;
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
			//Clear Global ReportYear variable
			modGlobal
				.Shared.gReportYear = 0;
		}

		public static frmTransferReport DefInstance
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

		public static frmTransferReport CreateInstance()
		{
			PTSProject.frmTransferReport theInstance = Shared.Container.Resolve< frmTransferReport>();
			return theInstance;
		}

		protected override void ExecuteControlsStartup()
		{
			ViewModel.sprIndiv.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprIndiv.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmTransferReport
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmTransferReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmTransferReport m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}