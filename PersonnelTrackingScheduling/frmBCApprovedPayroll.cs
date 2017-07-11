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

	public partial class frmBCApprovedPayroll
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmBCApprovedPayrollViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmBCApprovedPayroll));
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


		private void frmBCApprovedPayroll_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		public void FormatReport()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			ViewModel.sprEmployeeList.MaxRows = 50;
			ViewModel.sprEmployeeList.Row = 1;
			ViewModel.sprEmployeeList.Row2 = ViewModel.sprEmployeeList.MaxRows;
			ViewModel.sprEmployeeList.Col = 1;
			ViewModel.sprEmployeeList.Col2 = ViewModel.sprEmployeeList.MaxCols;
			ViewModel.sprEmployeeList.BlockMode = true;
			ViewModel.sprEmployeeList.Text = "";
			ViewModel.sprEmployeeList.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprEmployeeList.BlockMode = false;

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprEmployeeList.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeList.ClearSelection();

			//Fill Employee Grid
			string sStringText = "";

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			sStringText = "spReport_ApprovedTimecardsForBCs ";
			sStringText = sStringText + modGlobal.Shared.gPayrollYear.ToString() + "," + modGlobal.Shared.gPayPeriod.ToString();

			oCmd.CommandText = sStringText;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			int GridRow = 0;

			while(!oRec.EOF)
			{
				GridRow++;
				ViewModel.sprEmployeeList.Row = GridRow;
				ViewModel.sprEmployeeList.Col = 1;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["employee"]);
				ViewModel.sprEmployeeList.Col = 2;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["approved_by"]);
				ViewModel.sprEmployeeList.Col = 3;
				if (modGlobal.Clean(oRec["approve_datetime"]) == "")
				{
					ViewModel.sprEmployeeList.Text = "";
				}
				else
				{
					ViewModel.sprEmployeeList.Text = Convert.ToDateTime(oRec["approve_datetime"]).ToString("MM/dd/yyyy");
				}
				ViewModel.sprEmployeeList.Col = 4;
				if (modGlobal.Clean(oRec["ApprovedStatus"]) == "")
				{
					ViewModel.sprEmployeeList.Text = "";
				}
				else
				{
					ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["ApprovedStatus"]) + " on " +
									Convert.ToDateTime(oRec["LastUpdate"]).ToString("M/d/yy");
				}

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

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPayroll_Click(Object eventSender, System.EventArgs eventArgs)
		{
			modGlobal.Shared.gStartTrans = DateTime.Now.ToString("M/d/yyyy") + " 7:00AM";
			modGlobal.Shared.gPayPeriod = 0;
			ViewManager.NavigateToView(

				frmPayrollBCStaff.DefInstance);
			/*			frmPayrollBCStaff.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Print Employee Grid List
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprEmployeeList.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeList.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprEmployeeList.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeList.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprEmployeeList.PrintColHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeList.setPrintColHeaders(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprEmployeeList.PrintSmartPrint was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeList.setPrintSmartPrint(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprEmployeeList.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeList.setPrintAbortMsg("Printing PTS Payroll Sign Off Report");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprEmployeeList.PrintSheet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//object tempRefParam = null;
			//WEBMAP_UPGRADE_ISSUE: (1101) FarPoint.Win.Spread.FpSpread.PrintSheet was not upgraded
			ViewModel.sprEmployeeList.PrintSheet(null);

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			//string strName = "";
			//bool DoThis = false;

			modGlobal.Shared.gPayrollYear = modGlobal.Shared.gCurrentYear;
			ViewModel.FirstTime = true;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			oCmd.CommandText = "spSelect_PayRollYearPayPeriod '" + DateTime.Now.ToString("M/d/yyyy") + "' ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				modGlobal.Shared.gPayrollYear = Convert.ToInt32(oRec["calendar_year"]);
				modGlobal.Shared.gPayPeriod = Convert.ToInt32(oRec["pay_period"]);
			}
			ViewModel.cboPayPeriod.Items.Clear();
			oCmd.CommandText = "sp_GetPayRollPeriods " + modGlobal.Shared.gPayrollYear.ToString();
			oRec = ADORecordSetHelper.Open(oCmd, "");

			while(!oRec.EOF)
			{
				ViewModel.cboPayPeriod.AddItem(Convert.ToString(oRec["start_date"]) + " - " + Convert.ToString(oRec["end_date"]));
				ViewModel.cboPayPeriod.SetItemData(ViewModel.cboPayPeriod.GetNewIndex(), Convert.ToInt32(oRec["pay_period"]));
				if (modGlobal.Shared.gPayPeriod == Convert.ToDouble(oRec["pay_period"]))
				{
					ViewModel.CurrStartDate = Convert.ToDateTime(oRec["start_date"]).ToString("M/d/yyyy");
					ViewModel.CurrEndDate = Convert.ToDateTime(oRec["end_date"]).AddDays(1).ToString("M/d/yyyy");
				}
				oRec.MoveNext();
			};

			if (modGlobal.Shared.gPayPeriod > 0)
			{
				for (int i = 0; i <= ViewModel.cboPayPeriod.Items.Count - 1; i++)
				{
					if ( ViewModel.cboPayPeriod.GetItemData(i) == modGlobal.Shared.gPayPeriod)
					{
						ViewModel.cboPayPeriod.SelectedIndex = i;
						break;
					}
				}
			}

			oCmd.CommandText = "sp_GetYearList ";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			//Initialize Year Combobox
			ViewModel.cboYear.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboYear.AddItem(Convert.ToString(oRec["cal_year"]).Trim());
				oRec.MoveNext();
			};
			ViewModel.cboYear.Text = modGlobal.Shared.gPayrollYear.ToString();

			if (modGlobal.Shared.gSecurity == "ADM")
			{
				ViewModel.cmdPayroll.Visible = true;
				ViewModel.cmdPayroll.Enabled = true;
			}

			FormatReport();
			ViewModel.FirstTime = false;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboPayPeriod_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Recall start and end dates for Pay Period

			if ( ViewModel.cboPayPeriod.SelectedIndex < 0)
			{
				return;
			} //no selection

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "sp_GetPPDates " + ViewModel.cboPayPeriod.GetItemData(ViewModel.cboPayPeriod.SelectedIndex).ToString() + "," + modGlobal.Shared.gPayrollYear.ToString();
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (!oRec.EOF)
			{
				modGlobal.Shared.gPayPeriod = ViewModel.cboPayPeriod.GetItemData(ViewModel.cboPayPeriod.SelectedIndex);
				ViewModel.CurrStartDate = Convert.ToDateTime(oRec["start_date"]).ToString("M/d/yyyy");
				ViewModel.CurrEndDate = Convert.ToDateTime(oRec["end_date"]).AddDays(1).ToString("M/d/yyyy");
			}
			else
			{
				ViewModel.CurrStartDate = "";
				ViewModel.CurrEndDate = "";
				ViewManager.ShowMessage("Unable to recall Pay Period Data", "Individual Time Card Reporting", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				return;
			}
			FormatReport();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboYear_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(ViewModel.cboYear.Text) == modGlobal.Shared.gPayrollYear)
			{
				return;
			}

			modGlobal.Shared.gPayrollYear = Convert.ToInt32(Double.Parse(ViewModel.cboYear.Text));
			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			ViewModel.cboPayPeriod.Items.Clear();
			oCmd.CommandText = "sp_GetPayRollPeriods " + modGlobal.Shared.gPayrollYear.ToString();
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			while(!oRec.EOF)
			{
				ViewModel.cboPayPeriod.AddItem(Convert.ToString(oRec["start_date"]) + " - " + Convert.ToString(oRec["end_date"]));
				ViewModel.cboPayPeriod.SetItemData(ViewModel.cboPayPeriod.GetNewIndex(), Convert.ToInt32(oRec["pay_period"]));
				oRec.MoveNext();
			};

			modGlobal.Shared.gPayPeriod = 0;

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmBCApprovedPayroll DefInstance
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

		public static frmBCApprovedPayroll CreateInstance()
		{
			PTSProject.frmBCApprovedPayroll theInstance = Shared.Container.Resolve< frmBCApprovedPayroll>();
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

	public partial class frmBCApprovedPayroll
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmBCApprovedPayrollViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmBCApprovedPayroll m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}