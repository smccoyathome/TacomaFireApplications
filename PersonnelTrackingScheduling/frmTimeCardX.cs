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

	public partial class frmTimeCardX
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmTimeCardXViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmTimeCardX));
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


		private void frmTimeCardX_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//*******************************
		//* Time Card Worksheet for     *
		//* Special Units               *
		//*******************************
		//ADODB

		public void ClearSpread()
		{
			ViewModel.sprWeek.BlockMode = false;
			ViewModel.sprWeek.Col = 5;
			ViewModel.sprWeek.Row = 2;
			ViewModel.sprWeek.Text = "";
			ViewModel.sprWeek.Col = 7;
			ViewModel.sprWeek.Text = "";
			ViewModel.sprWeek.BlockMode = true;
			ViewModel.sprWeek.Col = 1;
			ViewModel.sprWeek.Row = 5;
			ViewModel.sprWeek.Col2 = 9;
			ViewModel.sprWeek.Row2 = 400;
			//ViewModel.sprWeek.Action = (FarPoint.ViewModels.FPActionConstants) 12;
			ViewModel.sprWeek.FontBold = false;
			ViewModel.sprWeek.BlockMode = false;

		}

		public void FillSpread()
		{
			//Fill Spread with new days Exceptions
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string CurrDate = "";
			string CurrRecord = "";
			StringBuilder NewRecord = new System.Text.StringBuilder();
			string CurrEmp = "";
			string CurrPos = "";
			string CurrKOT = "";
			string CurrLeave = "";
			int CurrPayUp = 0;
			string CurrJobCode = "";
			string strAMPM = "";

			ClearSpread();

			string StartDate = DateTime.Parse(ViewModel.calWeek.Text).ToString("M/d/yyyy");
			string EndDate = DateTime.Parse(StartDate).AddDays(14).ToString("M/d/yyyy");
			ViewModel.sprWeek.Col = 5;
			ViewModel.sprWeek.Row = 2;
			ViewModel.sprWeek.Text = StartDate;
			ViewModel.sprWeek.Col = 7;
			ViewModel.sprWeek.Text = EndDate;

			int CurrRow = 4;
			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spReport_TimeSheetX '" + StartDate + "','" + EndDate + "','" + modGlobal.Shared.gRType + "'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				CurrPos = Convert.ToString(oRec["unit_code"]).Trim() + "-" + Convert.ToString(oRec["position_code"]).Trim();
				NewRecord = new System.Text.StringBuilder(Convert.ToString(oRec["name_full"]).Trim() + CurrPos + modGlobal.Clean(oRec["work_time"]));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
				if (!Convert.IsDBNull(oRec["leave_time"]))
				{
					NewRecord.Append(modGlobal.Clean(oRec["leave_time"]));
				}
				if (Convert.ToBoolean(oRec["pay_upgrade"]))
				{
					NewRecord.Append(Convert.ToString(oRec["job_code_id"]));
				}
			}

			while(!oRec.EOF)
			{
				if (CurrDate != Convert.ToString(oRec["shift_date"]))
				{
					CurrRow++;
					ViewModel.sprWeek.Row = CurrRow;
					ViewModel.sprWeek.Col = 1;
					ViewModel.sprWeek.Text = Convert.ToString(oRec["shift_date"]);
					CurrDate = Convert.ToString(oRec["shift_date"]);
					CurrRecord = "";
				}

				if (CurrRecord != NewRecord.ToString())
				{
					ViewModel.sprWeek.Row = CurrRow;
					ViewModel.sprWeek.Col = 3;
					ViewModel.sprWeek.Text = Convert.ToString(oRec["name_full"]);
					ViewModel.sprWeek.Col = 2;
					CurrPos = Convert.ToString(oRec["unit_code"]).Trim() + "-" + Convert.ToString(oRec["position_code"]).Trim();
					ViewModel.sprWeek.Text = CurrPos;
					ViewModel.sprWeek.Col = 4;
					ViewModel.sprWeek.Text = modGlobal.Clean(oRec["work_time"]);
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
					if (!Convert.IsDBNull(oRec["leave_time"]))
					{
						ViewModel.sprWeek.Col = 5;
						ViewModel.sprWeek.Text = modGlobal.Clean(oRec["leave_time"]);
						if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1)
						{
							ViewModel.sprWeek.FontBold = true;
						}
					}
					if (Convert.ToBoolean(oRec["pay_upgrade"]))
					{
						ViewModel.sprWeek.Col = 6;
						ViewModel.sprWeek.Text = "X";
						ViewModel.sprWeek.Col = 7;
						ViewModel.sprWeek.Text = Convert.ToString(oRec["job_code_id"]);
						ViewModel.sprWeek.Col = 8;
						ViewModel.sprWeek.Text = modGlobal.Clean(oRec["step"]);
					}
					ViewModel.sprWeek.Col = 9;
					ViewModel.sprWeek.Text = Convert.ToString(oRec["AMPM"]);
					CurrEmp = Convert.ToString(oRec["name_full"]);
					CurrKOT = modGlobal.Clean(oRec["work_time"]);
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
					if (!Convert.IsDBNull(oRec["leave_time"]))
					{
						CurrLeave = modGlobal.Clean(oRec["leave_time"]);
					}
					else
					{
						CurrLeave = "";
					}
					CurrPayUp = Convert.ToInt32(oRec["pay_upgrade"]);
					if (CurrPayUp != 0)
					{
						CurrJobCode = Convert.ToString(oRec["job_code_id"]);
					}
					else
					{
						CurrJobCode = "";
					}
					CurrRow++;
					CurrRecord = NewRecord.ToString();
				}
				else
				{
					ViewModel.sprWeek.Col = 9;
					strAMPM = ViewModel.sprWeek.Text + "/" + Convert.ToString(oRec["AMPM"]);
					ViewModel.sprWeek.Text = strAMPM;
				}

				oRec.MoveNext();
				if (!oRec.EOF)
				{
					CurrPos = Convert.ToString(oRec["unit_code"]).Trim() + "-" + Convert.ToString(oRec["position_code"]).Trim();
					NewRecord = new System.Text.StringBuilder(Convert.ToString(oRec["name_full"]).Trim() + CurrPos + modGlobal.Clean(oRec["work_time"]));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
					if (!Convert.IsDBNull(oRec["leave_time"]))
					{
						NewRecord.Append(modGlobal.Clean(oRec["leave_time"]));
					}
					if (Convert.ToBoolean(oRec["pay_upgrade"]))
					{
						NewRecord.Append(Convert.ToString(oRec["job_code_id"]));
					}
				}
			};
		}

		[UpgradeHelpers.Events.Handler]
		internal void calWeek_Click(Object eventSender, System.EventArgs eventArgs)
		{
			FillSpread();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprWeek.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprWeek.setPrintAbortMsg(ViewModel.PrintMsg);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprWeek.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprWeek.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprWeek.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprWeek.setPrintColor(true);
            //    sprWeek.PrintOrientation = 1
            ViewModel.sprWeek.PrintSheet(null);
            //ViewModel.sprWeek.Action = (FarPoint.ViewModels.FPActionConstants) 32;

        }

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string NextWeek = "";
			int UDays = 0;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			string StartDate = "1/1/" + modGlobal.Shared.gCurrentYear.ToString();
			string EndDate = DateTime.Parse(StartDate).AddYears(1).ToString("M/d/yyyy");
			string FocusDate = "";
			//If launched from frmWeekly or frmEMS get date
			if (modGlobal.Shared.gRType == "PM")
			{
				for (int i = 0; i <= ViewManager.OpenFormsCount - 1; i++)
				{
					if ( ViewManager.GetOpenFormAt(i).ViewModel.Name == "frmNewEMS")
					{
						FocusDate = frmNewEMS.DefInstance.ViewModel.calWeek.Value.Date.ToString("M/d/yyyy");
					}
				}
			}
			else
			{
				for (int i = 0; i <= ViewManager.OpenFormsCount - 1; i++)
				{
					if ( ViewManager.GetOpenFormAt(i).ViewModel.Name == "frmWeekly")
					{
						FocusDate = frmWeekly.DefInstance.ViewModel.calWeek.Value.Date.ToString("M/d/yyyy");
					}
				}
			}

			//Otherwise find last Monday
			if (FocusDate == "")
			{
				if (DateAndTime.Weekday(DateTime.Now, FirstDayOfWeek.Sunday) == 1)
				{
					UDays = -6;
				}
				else
				{
					UDays = (DateAndTime.Weekday(DateTime.Now, FirstDayOfWeek.Sunday) - 2) * -1;
				}
				FocusDate = DateTime.Now.AddDays(UDays).ToString("M/d/yyyy");
			}


			//Disable all days on Date Control
			//Enable and highlight PayPeriod starting dates
			//Set Date for current Week

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSDateCombo property calWeek.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member DayOfWeek is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calWeek.getX().DayOfWeek(2).Enabled = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSDateCombo property calWeek.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member DayOfWeek is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calWeek.getX().DayOfWeek(3).Enabled = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSDateCombo property calWeek.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member DayOfWeek is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calWeek.getX().DayOfWeek(4).Enabled = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSDateCombo property calWeek.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member DayOfWeek is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calWeek.getX().DayOfWeek(5).Enabled = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSDateCombo property calWeek.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member DayOfWeek is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calWeek.getX().DayOfWeek(6).Enabled = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSDateCombo property calWeek.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member DayOfWeek is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calWeek.getX().DayOfWeek(7).Enabled = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSDateCombo property calWeek.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calWeek.getX().StyleSets("PayStart").BackColor = modGlobal.CREGULAR;

			oCmd.CommandText = "sp_GetPayPeriod '" + StartDate + "','" + EndDate + "'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			while(!oRec.EOF)
			{
				bool tempBool = false;
				string auxVar = Convert.ToString(oRec["cycle_day_ind"]).Trim();
				if ((Boolean.TryParse(auxVar, out tempBool)) ? tempBool : Convert.ToBoolean(Double.Parse(auxVar)))
				{
					//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSDateCombo property calWeek.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					//UPGRADE_TODO: (1067) Member Day is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
					ViewModel.calWeek.getX().Day(Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy")).StyleSet = "PayStart";
				}
				NextWeek = Convert.ToDateTime(oRec["shift_start"]).AddDays(7).ToString("M/d/yyyy");
				if (FocusDate == NextWeek)
				{
					FocusDate = DateTime.Parse(NextWeek).AddDays(-7).ToString("M/d/yyyy");
				}
				//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSDateCombo property calWeek.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				//UPGRADE_TODO: (1067) Member Day is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				ViewModel.calWeek.getX().Day(NextWeek).Enabled = false;
				oRec.MoveNext();
			};

			System.DateTime TempDate = DateTime.FromOADate(0);
			ViewModel.calWeek.Value = DateTime.Parse((DateTime.TryParse(FocusDate, out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : FocusDate);
			ViewModel.sprWeek.Col = 1;
			ViewModel.sprWeek.Row = 2;

			switch(modGlobal.Shared.gRType)
			{
				case "PM" :
					frmTimeCardX.DefInstance.ViewModel.Text = frmTimeCardX.DefInstance.ViewModel.Text + " EMS";
					ViewModel.sprWeek.Text = "Payroll Time Card Worksheet - EMS";
					ViewModel.PrintMsg = "Printing EMS Time Card Worksheet - Click Cancel to quit";
					break;
				case "HZM" :
					frmTimeCardX.DefInstance.ViewModel.Text = frmTimeCardX.DefInstance.ViewModel.Text + " HazMat";
					ViewModel.sprWeek.Text = "Payroll Time Card Worksheet - HazMat";
					ViewModel.PrintMsg = "Printing HazMat Time Card Worksheet - Click Cancel to quit";
					break;
				case "MRN" :
					frmTimeCardX.DefInstance.ViewModel.Text = frmTimeCardX.DefInstance.ViewModel.Text + " Marine";
					ViewModel.sprWeek.Text = "Payroll Time Card Worksheet - Marine";
					ViewModel.PrintMsg = "Printing Marine Time Card Worksheet - Click Cancel to quit";
					break;
				case "BAT" :
					frmTimeCardX.DefInstance.ViewModel.Text = frmTimeCardX.DefInstance.ViewModel.Text + " Battalion Staff";
					ViewModel.sprWeek.Text = "Payroll Time Card Worksheet - Battalion";
					ViewModel.PrintMsg = "Printing Battalion Time Card Worksheet - Click Cancel to quit";
					break;
				case "FCC" :
					frmTimeCardX.DefInstance.ViewModel.Text = frmTimeCardX.DefInstance.ViewModel.Text + " Dispatch";
					ViewModel.sprWeek.Text = "Payroll Time Card Worksheet - Dispatch";
					ViewModel.PrintMsg = "Printing Dispatch Time Card Worksheet - Click Cancel to quit";
					break;
				case "RESV" :
					frmTimeCardX.DefInstance.ViewModel.Text = frmTimeCardX.DefInstance.ViewModel.Text + " Battalion 4 Reserve Units";
					ViewModel.sprWeek.Text = "Payroll Time Card Worksheet - Battalion 4 Reserve Units";
					ViewModel.PrintMsg = "Printing Time Card Worksheet - Click Cancel to quit";
					break;
			}

			FillSpread();
			//    'MDIForm1.Arrange vbCascade

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmTimeCardX DefInstance
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

		public static frmTimeCardX CreateInstance()
		{
			PTSProject.frmTimeCardX theInstance = Shared.Container.Resolve< frmTimeCardX>();
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
			ViewModel.sprWeek.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprWeek.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmTimeCardX
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmTimeCardXViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmTimeCardX m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}