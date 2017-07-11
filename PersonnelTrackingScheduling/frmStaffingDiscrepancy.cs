using System;
using UpgradeHelpers.DB.ADO;
using UpgradeStubs;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class frmStaffingDiscrepancy
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmStaffingDiscrepancyViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmStaffingDiscrepancy));
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


		private void frmStaffingDiscrepancy_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//**************************************
		//  PTS -vs- CAD Staffing Discrepancy
		//  Displays StaffingErrorLog Table
		//   which lists staff descrepancies
		//   between PTS and CAD...
		//**************************************

		public void FillReportGrid()
		{
			PTSProject.clsScheduler cSched = Container.Resolve< clsScheduler>();
			string sStartDate = "";
			string sEndDate = "";

			ViewModel.lbTotal.Text = "";
			ViewModel.sprReport.MaxRows = 50000;
			ViewModel.sprReport.Row = 1;
			ViewModel.sprReport.Row2 = ViewModel.sprReport.MaxRows;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
			ViewModel.sprReport.BlockMode = true;
			ViewModel.sprReport.Text = "";
			ViewModel.sprReport.BlockMode = false;

			if ( ViewModel.chkDateFilter.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				sStartDate = "";
				sEndDate = "";
			}
			else
			{
				sStartDate = ViewModel.dtStartDate.Text;
				sEndDate = ViewModel.dtEndDate.Text;
			}

			int iCADRow = 0;
			int iPTSRow = 0;
			string CurrUnit = "";
			string CurrIncident = "";
			bool FirstPTS = false;

			if (cSched.GetStaffingDiscrepancyList(sStartDate, sEndDate) != 0)
			{
				//continue
			}
			else
			{
				ViewManager.ShowMessage("There were no records found.", "Staffing Discrepancy List", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}


			while(!cSched.ScheduleRecord.EOF)
			{
				if (CurrUnit == "")
				{ //First Time
					iCADRow++;
					ViewModel.sprReport.Row = iCADRow;

					CurrUnit = modGlobal.Clean(cSched.ScheduleRecord["unit_id"]);
					CurrIncident = modGlobal.Clean(cSched.ScheduleRecord["incident_number"]);
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprReport.Text = CurrUnit;
					ViewModel.sprReport.Col = 2; //Incident #

					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprReport.Text = CurrIncident;
					ViewModel.sprReport.Col = 3; //Datetime

					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					ViewModel.sprReport.Text = Convert.ToDateTime(cSched.ScheduleRecord["error_time"]).ToString("MM/dd/yy HH:mm:ss");

					if (modGlobal.Clean(cSched.ScheduleRecord["staffed_in"]) == "CAD")
					{
						ViewModel.sprReport.Col = 4; //CAD Name

						ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
						ViewModel.sprReport.Text = modGlobal.Clean(cSched.ScheduleRecord["name_full"]);
					}
					else
					{
						ViewModel.sprReport.Col = 5; //PTS Name

						ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
						ViewModel.sprReport.Text = modGlobal.Clean(cSched.ScheduleRecord["name_full"]);

					}

					iPTSRow = iCADRow;
					FirstPTS = true;
				}
				else if (CurrUnit == modGlobal.Clean(cSched.ScheduleRecord["unit_id"]))
				{
					if (CurrIncident == modGlobal.Clean(cSched.ScheduleRecord["incident_number"]))
					{
						//SAME Unit / Incident
						if (modGlobal.Clean(cSched.ScheduleRecord["staffed_in"]) == "CAD")
						{
							iCADRow++;
							ViewModel.sprReport.Row = iCADRow;
							ViewModel.sprReport.Col = 4; //CAD Name

							ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
							ViewModel.sprReport.Text = modGlobal.Clean(cSched.ScheduleRecord["name_full"]);
						}
						else
						{
							if (FirstPTS)
							{
								iPTSRow = iCADRow;
								FirstPTS = false;
							}
							else
							{
								iPTSRow++;
							}
							ViewModel.sprReport.Row = iPTSRow;
							ViewModel.sprReport.Col = 5; //PTS Name

							ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
							ViewModel.sprReport.Text = modGlobal.Clean(cSched.ScheduleRecord["name_full"]);
						}
					}
					else
					{
						//SAME Unit, Different Incident
						iCADRow++;
						if (iCADRow > iPTSRow)
						{
							iPTSRow = iCADRow - 1; //because will be adding a row later
							//                    iPTSRow = iCADRow
						}
						else if (iPTSRow > iCADRow)
						{
							iCADRow = iPTSRow;
						}
						ViewModel.sprReport.Row = iCADRow;
						CurrIncident = modGlobal.Clean(cSched.ScheduleRecord["incident_number"]);
						ViewModel.sprReport.Col = 2; //Incident #

						ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
						ViewModel.sprReport.Text = CurrIncident;
						ViewModel.sprReport.Col = 3; //Datetime

						ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
						ViewModel.sprReport.Text = Convert.ToDateTime(cSched.ScheduleRecord["error_time"]).ToString("MM/dd/yy HH:mm:ss");

						if (modGlobal.Clean(cSched.ScheduleRecord["staffed_in"]) == "CAD")
						{
							ViewModel.sprReport.Col = 4; //CAD Name

							ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
							ViewModel.sprReport.Text = modGlobal.Clean(cSched.ScheduleRecord["name_full"]);
						}
						else
						{
							iPTSRow++;
							ViewModel.sprReport.Row = iPTSRow;
							ViewModel.sprReport.Col = 5; //PTS Name

							ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
							ViewModel.sprReport.Text = modGlobal.Clean(cSched.ScheduleRecord["name_full"]);
						}
					}
				}
				else
				{
					//Change both Unit / Inceident

					iCADRow++;
					if (iCADRow > iPTSRow)
					{
						iPTSRow = iCADRow - 1; //because will be adding a row later
						//                iPTSRow = iCADRow
					}
					else if (iPTSRow > iCADRow)
					{
						iCADRow = iPTSRow;
						iCADRow++;
					}
					ViewModel.sprReport.Row = iCADRow;

					CurrUnit = modGlobal.Clean(cSched.ScheduleRecord["unit_id"]);
					CurrIncident = modGlobal.Clean(cSched.ScheduleRecord["incident_number"]);
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprReport.Text = CurrUnit;
					ViewModel.sprReport.Col = 2; //Incident #

					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprReport.Text = CurrIncident;
					ViewModel.sprReport.Col = 3; //Datetime

					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					ViewModel.sprReport.Text = Convert.ToDateTime(cSched.ScheduleRecord["error_time"]).ToString("MM/dd/yy HH:mm:ss");

					if (modGlobal.Clean(cSched.ScheduleRecord["staffed_in"]) == "CAD")
					{
						ViewModel.sprReport.Col = 4; //CAD Name

						ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
						ViewModel.sprReport.Text = modGlobal.Clean(cSched.ScheduleRecord["name_full"]);
					}
					else
					{
						iPTSRow++;
						ViewModel.sprReport.Row = iPTSRow;
						ViewModel.sprReport.Col = 5; //PTS Name

						ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
						ViewModel.sprReport.Text = modGlobal.Clean(cSched.ScheduleRecord["name_full"]);
					}
				}
				cSched.ScheduleRecord.MoveNext();
			}
			;

			if (iCADRow > iPTSRow)
			{
				ViewModel.sprReport.MaxRows = iCADRow;
			}
			else if (iPTSRow > iCADRow)
			{
				ViewModel.sprReport.MaxRows = iPTSRow;
			}
			else
			{
				ViewModel.sprReport.MaxRows = iCADRow;
			}
			ViewModel.lbTotal.Text = "";

		}


		public void FillReport2Grid()
		{
			PTSProject.clsScheduler cSched = Container.Resolve< clsScheduler>();
			string sStartDate = "";
			string sEndDate = "";

			ViewModel.lbTotal.Text = "";
			ViewModel.sprReport2.MaxRows = 50000;
			ViewModel.sprReport2.Row = 1;
			ViewModel.sprReport2.Row2 = ViewModel.sprReport2.MaxRows;
			ViewModel.sprReport2.Col = 1;
			ViewModel.sprReport2.Col2 = ViewModel.sprReport2.MaxCols;
			ViewModel.sprReport2.BlockMode = true;
			ViewModel.sprReport2.Text = "";
			ViewModel.sprReport2.BlockMode = false;

			if ( ViewModel.chkDateFilter.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				sStartDate = "";
				sEndDate = "";
			}
			else
			{
				ViewModel.dtStartDate.Text = DateTime.Now.AddDays(-1).ToString("MM/dd/yyyy");
				ViewModel.dtEndDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
			}

			int iRow = 0;
			if (cSched.GetStaffingDiscrepancyList(sStartDate, sEndDate) != 0)
			{
				//continue
			}
			else
			{
				ViewManager.ShowMessage("There were no records found.", "Staffing Discrepancy List", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}


			while(!cSched.ScheduleRecord.EOF)
			{
				iRow++;
				ViewModel.sprReport2.Row = iRow;
				ViewModel.sprReport2.Col = 1; //Name

				ViewModel.sprReport2.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
				ViewModel.sprReport2.Text = modGlobal.Clean(cSched.ScheduleRecord["name_full"]);
				ViewModel.sprReport2.Col = 2; //Unit

				ViewModel.sprReport2.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprReport2.Text = modGlobal.Clean(cSched.ScheduleRecord["unit_id"]);
				ViewModel.sprReport2.Col = 3; //Incident #

				ViewModel.sprReport2.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprReport2.Text = modGlobal.Clean(cSched.ScheduleRecord["incident_number"]);
				ViewModel.sprReport2.Col = 4; //Datetime

				ViewModel.sprReport2.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
				ViewModel.sprReport2.Text = Convert.ToDateTime(cSched.ScheduleRecord["error_time"]).ToString("MM/dd/yy HH:mm:ss");
				ViewModel.sprReport2.Col = 5; //Staffed In

				ViewModel.sprReport2.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprReport2.Text = modGlobal.Clean(cSched.ScheduleRecord["staffed_in"]);
				ViewModel.sprReport2.Col = 6; //Record ID

				ViewModel.sprReport2.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.sprReport2.Text = Convert.ToString(modGlobal.GetVal(cSched.ScheduleRecord["staff_error_id"]));

				cSched.ScheduleRecord.MoveNext();
			}
			;
			ViewModel.sprReport2.MaxRows = iRow;
			ViewModel.lbTotal.Text = "Total Rows = " + iRow.ToString();

		}

		[UpgradeHelpers.Events.Handler]
		internal void chkDateFilter_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{

			if ( ViewModel.chkDateFilter.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				ViewModel.dtStartDate.Visible = false;
				ViewModel.dtEndDate.Visible = false;
				ViewModel.lbEnd.Visible = false;
				ViewModel.lbStart.Visible = false;
				ViewModel.dtStartDate.Text = DateTime.Now.AddDays(-1).ToString("MM/dd/yyyy");
				ViewModel.dtEndDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
			}
			else
			{
				ViewModel.dtStartDate.Visible = true;
				ViewModel.dtEndDate.Visible = true;
				ViewModel.lbEnd.Visible = true;
				ViewModel.lbStart.Visible = true;
			}

			//    FillReport2Grid
			FillReportGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdExit_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintFooter was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintFooter("/nPrinted on " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "/r Page /p of /pc");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintAbortMsg("Printing PTS -vs- CAD Staffing Discrepancy List");
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
		internal void cmdRefresh_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    FillReport2Grid
			FillReportGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void dtEndDate_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    FillReport2Grid
			FillReportGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void dtStartDate_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    FillReport2Grid
			FillReportGrid();
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			ViewModel.dtStartDate.Text = DateTime.Now.AddDays(-1).ToString("MM/dd/yyyy");
			ViewModel.dtEndDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
			//    FillReport2Grid
			FillReportGrid();
		}

		//UPGRADE_NOTE: (7001) The following declaration (fpSpread1_Advance) seems to be dead code More Information: http://www.vbtonet.com/ewis/ewi7001.aspx
		//private void fpSpread1_Advance(bool AdvanceNext)
		//{
			//
		//}
		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmStaffingDiscrepancy DefInstance
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

		public static frmStaffingDiscrepancy CreateInstance()
		{
			PTSProject.frmStaffingDiscrepancy theInstance = Shared.Container.Resolve< frmStaffingDiscrepancy>();
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
			ViewModel.sprReport2.LifeCycleStartup();
			ViewModel.sprReport.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprReport2.LifeCycleShutdown();
			ViewModel.sprReport.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmStaffingDiscrepancy
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmStaffingDiscrepancyViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmStaffingDiscrepancy m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}