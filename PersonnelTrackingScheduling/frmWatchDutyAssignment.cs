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

	public partial class frmWatchDutyAssignment
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmWatchDutyAssignmentViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmWatchDutyAssignment));
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


		private void frmWatchDutyAssignment_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender )
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>)eventSender;
			}
		}
		//*******************************
		//*  TFD Watch Duty Assignment  *
		//*******************************

		private int DetermineSecurity()
		{
			int result = 0;
			PTSProject.clsScheduler cSched = Container.Resolve<clsScheduler>();
			//This should always be NoLimitUpdate = True... because
			//GetEMSForSecurity is done before loading the screen...

			result = 0;
			if ( cSched.GetWatchDutySecurity(modGlobal.Shared.gUser) != 0 )
			{
				result = -1;
			}

			return result;
		}

		public void FillGrid()
		{
			string AssignOnly = "";
			PTSProject.clsScheduler cSched = Container.Resolve<clsScheduler>();
			ViewModel.FillingTheGrid = true;
			//clear grid
			ViewModel.sprReport.MaxRows = 500;
			ViewModel.sprReport.Row = 1;
			ViewModel.sprReport.Row2 = ViewModel.sprReport.MaxRows;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Col2 = 1;
			ViewModel.sprReport.BlockMode = true;
			ViewModel.sprReport.CellType = FarPoint.ViewModels.Cells.FpCellType.CellTypeCheckBox;
			ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprReport.Value = 0;
			ViewModel.sprReport.BlockMode = false;
			ViewModel.sprReport.Row = 1;
			ViewModel.sprReport.Row2 = ViewModel.sprReport.MaxRows;
			ViewModel.sprReport.Col = 2;
			ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
			ViewModel.sprReport.BlockMode = true;
			ViewModel.sprReport.Text = "";
			ViewModel.sprReport.BlockMode = false;

			string sDate = DateTime.Parse(ViewModel.dtReportDate.Text).ToString("MM/dd/yyyy");
			if ( ViewModel.chkOnlyAssigned.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked )
			{
				AssignOnly = "N";
			}
			else
			{
				AssignOnly = "Y";
			}

			if ( cSched.GetEmployeeWatchDutyList(sDate, ViewModel.FacilityID, AssignOnly) != 0 )
			{
			//continue
			}
			else
			{
				ViewManager.ShowMessage("Oooops!  No records were retrieved.  Clear filters and try again.", "Employee Watch Duty Assignment", UpgradeHelpers.Helpers.BoxButtons.OK);
				return ;
			}
			ViewModel.CurrRow = 0;

			while ( !cSched.WatchDutyAssignment.EOF )
			{
				(ViewModel.CurrRow)++;
				ViewModel.sprReport.Row = ViewModel.CurrRow;
				if ( modGlobal.Clean(cSched.WatchDutyAssignment["duty_id"]) != "" )
				{
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.Value = 1;
					ViewModel.sprReport.Col = 7;
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.sprReport.Text = Convert.ToString(modGlobal.GetVal(cSched.WatchDutyAssignment["duty_id"]));
				}
				else
				{
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.Value = 0;
					ViewModel.sprReport.Col = 7;
					ViewModel.sprReport.Text = "";
				}
				ViewModel.sprReport.Col = 2;
				ViewModel.sprReport.Text = modGlobal.Clean(cSched.WatchDutyAssignment["name_full"]);
				ViewModel.sprReport.Col = 3;
				ViewModel.sprReport.Text = modGlobal.Clean(cSched.WatchDutyAssignment["facility_name"]);
				ViewModel.sprReport.Col = 4;
				ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprReport.Text = modGlobal.Clean(cSched.WatchDutyAssignment["unit_code"]);
				ViewModel.sprReport.Col = 5;
				ViewModel.sprReport.Text = modGlobal.Clean(cSched.WatchDutyAssignment["position_code"]);
				ViewModel.sprReport.Col = 6;
				ViewModel.sprReport.Text = modGlobal.Clean(cSched.WatchDutyAssignment["employee_id"]);


				cSched.WatchDutyAssignment.MoveNext();
			};
			ViewModel.sprReport.MaxRows = ViewModel.CurrRow;
			ViewModel.lbCount.Text = "List Count: " + ViewModel.CurrRow.ToString();
			ViewModel.FillingTheGrid = false;

		}

		public void LoadLists()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//fill dropdown list for Stations
			string strSQL = "spSelect_WatchDutyStationList ";

			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboLocation.Items.Clear();

			while ( !oRec.EOF )
			{
				ViewModel.cboLocation.AddItem(modGlobal.Clean(oRec["facility_name"]));
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.cboLocation.SetItemData(ViewModel.cboLocation.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["facility"])));

				oRec.MoveNext();
			};
			}

		[UpgradeHelpers.Events.Handler]
		internal void cboLocation_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboLocation.SelectedIndex == -1 )
			{
				ViewModel.FacilityID = 0;
			}
			else
			{
				ViewModel.FacilityID = ViewModel.cboLocation.GetItemData(ViewModel.cboLocation.SelectedIndex);
			}
			FillGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void chkOnlyAssigned_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			FillGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClear_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.cboLocation.SelectedIndex = -1;
			ViewModel.FacilityID = 0;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdExit_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This feature is coming soon!", vbOKOnly, "TFD Watch Duty Assignment"
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintFooter was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintFooter("/nPrinted on " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "/r Page /p of /pc");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintAbortMsg("Printing TFD Watch Duty Assignment");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintColHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintColHeaders(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintSmartPrint was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintSmartPrint(true);

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprReport.PrintSheet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//object tempRefParam = null;
			//WEBMAP_UPGRADE_ISSUE: (1101) FarPoint.Win.Spread.FpSpread.PrintSheet was not upgraded
			ViewModel.sprReport.PrintSheet(null);
		}

		[UpgradeHelpers.Events.Handler]
		internal void dtReportDate_ValueChanged(Object eventSender, System.EventArgs eventArgs)
		{
			FillGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void dtReportDate_Click(Object eventSender, System.EventArgs eventArgs)
		{
			FillGrid();
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			ViewModel.dtReportDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
			ViewModel.FacilityID = 0;
			ViewModel.FillingTheGrid = false;
			ViewModel.UpdateJustHappened = false;
			LoadLists();
			FillGrid();

			if ( modGlobal.Shared.gSecurity == "PER" || modGlobal.Shared.gSecurity == "RO" )
			{
				if ( DetermineSecurity() != 0 )
				{
				//continue
				}
				else
				{
					ViewModel.sprReport.Enabled = false;
				}
			}

		}

		private void sprReport_ButtonClicked(object eventSender, Stubs._FarPoint.Win.Spread.EditorNotifyEventArgs eventArgs)
		{
			int Col = eventArgs.Column;
			int Row = eventArgs.Row;
			int ButtonDown = 0;
			PTSProject.clsScheduler cSched = Container.Resolve<clsScheduler>();
			//string sEmpID = "";
			//string sDate = "";
			//do not continue if in the middle of filling the grid
			if ( ViewModel.FillingTheGrid )
			{
				return ;
			}

			//if col = 1 wasn't clicked... no use continuing
			if ( Col != 1 )
			{
				return ;
			}
			ViewModel.CurrRow = Row;
			ViewModel.sprReport.Row = ViewModel.CurrRow;
			ViewModel.sprReport.Col = 6;
			cSched.WatchDutyAssignEmpID = modGlobal.Clean(ViewModel.sprReport.Text);

			cSched.WatchDutyAssignDutyDate = DateTime.Parse(ViewModel.dtReportDate.Text).ToString("MM/dd/yyyy");
			cSched.WatchDutyAssignedBy = modGlobal.Shared.gUser;
			cSched.WatchDutyAssignedDate = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

			if ( ButtonDown != 0 )
			{ //Checkbox = True

				ViewModel.sprReport.Col = 7;
				if ( modGlobal.Clean(ViewModel.sprReport.Text) == "" )
				{
					//Need to Add PersonnelWatchDutyAssignment Record for Employee/Date
					if ( cSched.AddWatchDutyAssignmentRecord() )
					{
						ViewModel.UpdateJustHappened = true;
						ViewModel.sprReport.Col = 7;
						ViewModel.sprReport.Row = ViewModel.CurrRow;
						ViewModel.sprReport.Text = cSched.WatchDutyAssignDutyID.ToString();
					}
					else
					{
						ViewManager.ShowMessage("Oooops! Something went wrong... record not inserted.", "Add New Record", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
				}
			}
			else
			{
				//Checkbox = False
				if ( ViewModel.UpdateJustHappened )
				{
					ViewModel.UpdateJustHappened = false;
					return ;
				}
				else
				{
					//delete the PersonnelWatchDutyAssignment by RecordID
					ViewModel.sprReport.Col = 7;
					cSched.WatchDutyAssignDutyID = Convert.ToInt32(Double.Parse(ViewModel.sprReport.Text));
					if ( Convert.ToInt32(Double.Parse(ViewModel.sprReport.Text)) != 0 )
					{
						if ( cSched.DeleteWatchDutyAssignmentRecord() != 0 )
						{
							ViewModel.UpdateJustHappened = true;
							FillGrid();
						}
					}
				}
			}
			ViewModel.UpdateJustHappened = false;

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmWatchDutyAssignment DefInstance
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

		public static frmWatchDutyAssignment CreateInstance()
		{
			PTSProject.frmWatchDutyAssignment theInstance = Shared.Container.Resolve<frmWatchDutyAssignment>();
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
			ViewModel.sprReport.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprReport.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmWatchDutyAssignment
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmWatchDutyAssignmentViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmWatchDutyAssignment m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}