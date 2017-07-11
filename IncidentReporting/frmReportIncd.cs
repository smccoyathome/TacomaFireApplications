using System;
using UpgradeHelpers.DB.ADO;
using UpgradeStubs;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident
{

	public partial class frmReportIncd
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.frmReportIncdViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmReportIncd));
			if ( Shared.m_vb6FormDefInstance == null)
			{
				if ( Shared.m_InitializingDefInstance)
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
		}


		private void frmReportIncd_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		private void LoadIncidentReport()
		{
			//Format IncidentReport
			TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();
			TFDIncident.clsUnit UnitCL = Container.Resolve< clsUnit>();
			TFDIncident.clsReportLog ReportCL = Container.Resolve< clsReportLog>();
			//   Dim sDisplay As String
			ViewModel.sprIncidentRpt.Row = 1;
			ViewModel.sprIncidentRpt.Col = 9;
			ViewModel.sprIncidentRpt.FontSize = 8;
			ViewModel.sprIncidentRpt.Text = UpgradeHelpers.Helpers.StringsHelper.Format(DateTime.Now, "m/d/yyyy h:nn AM/PM");
			if (IncidentCL.GetIncident(ViewModel.CurrIncident) != 0)
			{
				if ( ViewModel.PageCountRow > 56)
				{
					DisplayHeadings();
				}
				else
				{
					ViewModel.CurrRow = 5;
					ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
					ViewModel.sprIncidentRpt.Col = 2;
					ViewModel.sprIncidentRpt.FontSize = 7;
					ViewModel.sprIncidentRpt.Text = IncidentCL.IncidentNumber;
					ViewModel.sDisplay = IncidentCL.IncidentNumber;
					(ViewModel.CurrRow)++;
					ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
					ViewModel.sprIncidentRpt.Col = 2;
					ViewModel.sprIncidentRpt.FontSize = 7;
					IncidentCL.GetIncidentReport(IncidentCL.IncidentID);
					ViewModel.sprIncidentRpt.Text = Convert.ToString(IncidentCL.IncidentRS["initial_type_desc"]);
					(ViewModel.CurrRow)++;
					ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
					ViewModel.sprIncidentRpt.Col = 2;
					ViewModel.sprIncidentRpt.FontSize = 7;
					ViewModel.sprIncidentRpt.Text = Convert.ToString(IncidentCL.IncidentRS["final_type_desc"]);
					(ViewModel.CurrRow)++;
					ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
					ViewModel.sprIncidentRpt.Col = 2;
					ViewModel.sprIncidentRpt.FontSize = 7;
					ViewModel.sprIncidentRpt.Text = IncidentCL.NumberOfPatients.ToString();
					ViewModel.CurrRow = 5;
					ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
					ViewModel.sprIncidentRpt.Col = 6;
					ViewModel.sprIncidentRpt.FontSize = 7;
					ViewModel.sprIncidentRpt.Text = IncidentCL.Location;
					(ViewModel.CurrRow)++;
					ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
					ViewModel.sprIncidentRpt.Col = 6;
					ViewModel.sprIncidentRpt.FontSize = 7;
					ViewModel.sprIncidentRpt.Text = IncidentCL.CommonPlace;
					(ViewModel.CurrRow)++;
					ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
					ViewModel.sprIncidentRpt.Col = 6;
					ViewModel.sprIncidentRpt.FontSize = 7;
					ViewModel.sprIncidentRpt.Text = IncidentCL.InitialAlarmLevel;
					(ViewModel.CurrRow)++;
					ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
					ViewModel.sprIncidentRpt.Col = 6;
					ViewModel.sprIncidentRpt.FontSize = 7;
					ViewModel.sprIncidentRpt.Text = IncidentCL.FinalAlarmLevel;
					(ViewModel.CurrRow)++;
					ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
					ViewModel.sprIncidentRpt.Col = 6;
					ViewModel.sprIncidentRpt.FontSize = 7;
					if (IncidentCL.FlagMutualAid == UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe("1"))
					{
						ViewModel.sprIncidentRpt.Text = "Y";
					}
					(ViewModel.CurrRow)++;
					ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
					ViewModel.sprIncidentRpt.Col = 6;
					ViewModel.sprIncidentRpt.FontSize = 7;
					if (IncidentCL.FlagCatchUp == UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe("1"))
					{
						ViewModel.sprIncidentRpt.Text = "Y";
					}
					ViewModel.CurrRow -= 5;
					ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
					ViewModel.sprIncidentRpt.Col = 10;
					ViewModel.sprIncidentRpt.FontSize = 7;
					ViewModel.sprIncidentRpt.Text = IncidentCL.ClearingUnit;
					ViewModel.CurrRow += 2;
					ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
					ViewModel.sprIncidentRpt.Col = 10;
					ViewModel.sprIncidentRpt.FontSize = 7;
					ViewModel.sprIncidentRpt.Text = IncidentCL.Dispatcher1ID;
					(ViewModel.CurrRow)++;
					ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
					ViewModel.sprIncidentRpt.Col = 10;
					ViewModel.sprIncidentRpt.FontSize = 7;
					ViewModel.sprIncidentRpt.Text = IncidentCL.Dispatcher2ID;
					ViewModel.CurrRow += 4;
					ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
					ViewModel.sprIncidentRpt.Col = 2;
					ViewModel.sprIncidentRpt.FontSize = 7;
					ViewModel.sprIncidentRpt.Text = DateTime.Parse(IncidentCL.DateReceivedE911).ToString("M/d/yyyy");
					ViewModel.sprIncidentRpt.Col = 3;
					ViewModel.sprIncidentRpt.FontSize = 7;
					ViewModel.sprIncidentRpt.Text = DateTime.Parse(IncidentCL.DateReceivedE911).ToString("HH:mm");
					(ViewModel.CurrRow)++;
					ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
					ViewModel.sprIncidentRpt.Col = 2;
					ViewModel.sprIncidentRpt.FontSize = 7;
					ViewModel.sprIncidentRpt.Text = DateTime.Parse(IncidentCL.DateIncidentCreated).ToString("M/d/yyyy");
					ViewModel.sprIncidentRpt.Col = 3;
					ViewModel.sprIncidentRpt.FontSize = 7;
					ViewModel.sprIncidentRpt.Text = DateTime.Parse(IncidentCL.DateIncidentCreated).ToString("HH:mm");
					(ViewModel.CurrRow)++;
					ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
					ViewModel.sprIncidentRpt.Col = 2;
					ViewModel.sprIncidentRpt.FontSize = 7;
					ViewModel.sprIncidentRpt.Text = DateTime.Parse(IncidentCL.DateFirstUnitDispatched).ToString("M/d/yyyy");
					ViewModel.sprIncidentRpt.Col = 3;
					ViewModel.sprIncidentRpt.FontSize = 7;
					ViewModel.sprIncidentRpt.Text = DateTime.Parse(IncidentCL.DateFirstUnitDispatched).ToString("HH:mm");
					(ViewModel.CurrRow)++;
					ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
					ViewModel.sprIncidentRpt.Col = 2;
					ViewModel.sprIncidentRpt.FontSize = 7;
					ViewModel.sprIncidentRpt.Text = DateTime.Parse(IncidentCL.DateFirstUnitEnroute).ToString("M/d/yyyy");
					ViewModel.sprIncidentRpt.Col = 3;
					ViewModel.sprIncidentRpt.FontSize = 7;
					ViewModel.sprIncidentRpt.Text = DateTime.Parse(IncidentCL.DateFirstUnitEnroute).ToString("HH:mm");
					(ViewModel.CurrRow)++;
					ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
					ViewModel.sprIncidentRpt.Col = 2;
					ViewModel.sprIncidentRpt.FontSize = 7;
					ViewModel.sprIncidentRpt.Text = DateTime.Parse(IncidentCL.DateFirstUnitOnscene).ToString("M/d/yyyy");
					ViewModel.sprIncidentRpt.Col = 3;
					ViewModel.sprIncidentRpt.FontSize = 7;
					ViewModel.sprIncidentRpt.Text = DateTime.Parse(IncidentCL.DateFirstUnitOnscene).ToString("HH:mm");
					(ViewModel.CurrRow)++;
					ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
					ViewModel.sprIncidentRpt.Col = 2;
					ViewModel.sprIncidentRpt.FontSize = 7;
					ViewModel.sprIncidentRpt.Text = DateTime.Parse(IncidentCL.DateFirstUnitTransport).ToString("M/d/yyyy");
					ViewModel.sprIncidentRpt.Col = 3;
					ViewModel.sprIncidentRpt.FontSize = 7;
					ViewModel.sprIncidentRpt.Text = DateTime.Parse(IncidentCL.DateFirstUnitTransport).ToString("HH:mm");
					(ViewModel.CurrRow)++;
					ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
					ViewModel.sprIncidentRpt.Col = 2;
					ViewModel.sprIncidentRpt.FontSize = 7;
					ViewModel.sprIncidentRpt.Text = DateTime.Parse(IncidentCL.DateFirstUnitTransComplete).ToString("M/d/yyyy");
					ViewModel.sprIncidentRpt.Col = 3;
					ViewModel.sprIncidentRpt.FontSize = 7;
					ViewModel.sprIncidentRpt.Text = DateTime.Parse(IncidentCL.DateFirstUnitTransComplete).ToString("HH:mm");
					(ViewModel.CurrRow)++;
					ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
					ViewModel.sprIncidentRpt.Col = 2;
					ViewModel.sprIncidentRpt.FontSize = 7;
					ViewModel.sprIncidentRpt.Text = DateTime.Parse(IncidentCL.DateIncidentClosed).ToString("M/d/yyyy");
					ViewModel.sprIncidentRpt.Col = 3;
					ViewModel.sprIncidentRpt.FontSize = 7;
					ViewModel.sprIncidentRpt.Text = DateTime.Parse(IncidentCL.DateIncidentClosed).ToString("HH:mm");
					ViewModel.CurrRow -= 7;
					ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
					ViewModel.sprIncidentRpt.Col = 8;
					ViewModel.sprIncidentRpt.FontSize = 7;
					ViewModel.sprIncidentRpt.Text = IncidentCL.ReportingName;
					(ViewModel.CurrRow)++;
					ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
					ViewModel.sprIncidentRpt.Col = 8;
					ViewModel.sprIncidentRpt.FontSize = 7;
					ViewModel.sprIncidentRpt.Text = IncidentCL.ReportingAddress;
					(ViewModel.CurrRow)++;
					ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
					ViewModel.sprIncidentRpt.Col = 8;
					ViewModel.sprIncidentRpt.FontSize = 7;
					ViewModel.sprIncidentRpt.Text = IncidentCL.ReportingPhone;
					ViewModel.CurrRow = 18;
					ViewModel.PageCountRow = 18;
					if (ReportCL.GetReportLogReport(ViewModel.CurrIncident) != 0)
					{

						while(!ReportCL.ReportLogRS.EOF)
						{
							ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
							ViewModel.sprIncidentRpt.Col = 4;
							ViewModel.sprIncidentRpt.FontSize = 7;
							ViewModel.sprIncidentRpt.Text = Convert.ToString(ReportCL.ReportLogRS["report_type_desc"]);
							ViewModel.sprIncidentRpt.Col = 6;
							ViewModel.sprIncidentRpt.FontSize = 7;
							ViewModel.sprIncidentRpt.Text = Convert.ToString(ReportCL.ReportLogRS["report_status_desc"]);
							ViewModel.sprIncidentRpt.Col = 8;
							ViewModel.sprIncidentRpt.FontSize = 7;
							ViewModel.sprIncidentRpt.Text = Convert.ToString(ReportCL.ReportLogRS["responsible_unit"]);
							ReportCL.ReportLogRS.MoveNext();
							(ViewModel.CurrRow)++;
							(
//                   SaveRow = CurrRow
ViewModel.PageCountRow)++;
						};
					}
					ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
					ViewModel.sprIncidentRpt.Col = 1;
					ViewModel.sprIncidentRpt.Text = "Incident History";
					ViewModel.sprIncidentRpt.FontSize = 10;
					ViewModel.sprIncidentRpt.FontBold = true;
					ViewModel.sprIncidentRpt.FontItalic = true;
					ViewModel.sprIncidentRpt.BlockMode = true;
					ViewModel.sprIncidentRpt.Row2 = ViewModel.CurrRow;
					ViewModel.sprIncidentRpt.Col2 = 11;
					ViewModel.sprIncidentRpt.BackColor = IncidentMain.Shared.LTGRAY;
					ViewModel.sprIncidentRpt.BlockMode = false;
					(ViewModel.CurrRow)++;
					(ViewModel.PageCountRow)++;
					ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
					ViewModel.sprIncidentRpt.Col = 1;
					ViewModel.sprIncidentRpt.FontSize = 8;
					ViewModel.sprIncidentRpt.FontBold = true;
					ViewModel.sprIncidentRpt.Text = "Time";
					ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
					ViewModel.sprIncidentRpt.Col = 2;
					ViewModel.sprIncidentRpt.FontSize = 8;
					ViewModel.sprIncidentRpt.FontBold = true;
					ViewModel.sprIncidentRpt.Text = "Sending";
					ViewModel.sprIncidentRpt.Col = 3;
					ViewModel.sprIncidentRpt.FontSize = 8;
					ViewModel.sprIncidentRpt.FontBold = true;
					ViewModel.sprIncidentRpt.Text = "Action";
					ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
					ViewModel.sprIncidentRpt.Col = 4;
					ViewModel.sprIncidentRpt.FontSize = 8;
					ViewModel.sprIncidentRpt.FontBold = true;
					ViewModel.sprIncidentRpt.Text = "Receiving";
					(ViewModel.CurrRow)++;
					(ViewModel.PageCountRow)++;
					if (IncidentCL.GetIncidentEventReport(ViewModel.CurrIncident) != 0)
					{

						while(!IncidentCL.EventRS.EOF)
						{
							ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
							ViewModel.sprIncidentRpt.Col = 1;
							ViewModel.sprIncidentRpt.FontSize = 7;
							ViewModel.sprIncidentRpt.FontBold = true;
							System.DateTime TempDate = DateTime.FromOADate(0);
							ViewModel.sprIncidentRpt.Text = (DateTime.TryParse(IncidentMain.Clean(IncidentCL.EventRS["event_time"]), out TempDate)) ? TempDate.ToString("HH:mm") : IncidentMain.Clean(IncidentCL.EventRS["event_time"]);
							ViewModel.sprIncidentRpt.Col = 2;
							ViewModel.sprIncidentRpt.FontSize = 7;
							ViewModel.sprIncidentRpt.FontBold = true;
							ViewModel.sprIncidentRpt.Text = IncidentMain.Clean(IncidentCL.EventRS["sending_unit"]);
							ViewModel.sprIncidentRpt.Col = 3;
							ViewModel.sprIncidentRpt.FontBold = true;
							ViewModel.sprIncidentRpt.FontSize = 7;
							ViewModel.sprIncidentRpt.Text = IncidentMain.Clean(IncidentCL.EventRS["event"]);
							ViewModel.sprIncidentRpt.Col = 4;
							ViewModel.sprIncidentRpt.FontBold = true;
							ViewModel.sprIncidentRpt.FontSize = 7;
							ViewModel.sprIncidentRpt.Text = IncidentMain.Clean(IncidentCL.EventRS["receiving_unit"]);
							(ViewModel.CurrRow)++;
							(ViewModel.PageCountRow)++;
							ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
							ViewModel.sprIncidentRpt.Col = 1;
							ViewModel.sprIncidentRpt.FontSize = 7;
							ViewModel.sprIncidentRpt.FontBold = false;
							ViewModel.sprIncidentRpt.Text = IncidentMain.Clean(IncidentCL.EventRS["event_text"]);
							IncidentCL.EventRS.MoveNext();
							(ViewModel.CurrRow)++;
							(ViewModel.PageCountRow)++;
							if ( ViewModel.PageCountRow > 56)
							{
								DisplayHeadings();
							}
						};
					}
				}
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{

			//***************************************************
			//   Data Access Code for Development testing
			//   Not Used for Production
			//***************************************************
			//    oIncident.Open "Provider=SQLOLEDB; Data Source=TFDSQL3; Initial Catalog=Incident; Integrated Security=SSPI"
			//    oPTSdata.Open "Provider=SQLOLEDB; Data Source=TFDSQL3; Initial Catalog=PTSdata; Integrated Security=SSPI"
			TFDIncident.clsReportLog ReportLog = Container.Resolve< clsReportLog>();

			//Unit Report
			//************ Testing Code ********************
			//    ReportLog.GetReportLog 84205
			ReportLog.GetReportLog(IncidentMain.Shared.gEditReportID);
			ViewModel.ReportType = ReportLog.ReportType;
			ViewModel.IncidentReportID = ReportLog.ReportReferenceID;
			ViewModel.CurrIncident = ReportLog.RLIncidentID;
			LoadIncidentReport();
			IncidentMain.MoveForm(frmReportIncd.DefInstance);

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprIncidentRpt.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprIncidentRpt.setPrintAbortMsg("Printing Incident Report - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprIncidentRpt.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprIncidentRpt.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprIncidentRpt.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprIncidentRpt.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpread.PrintOrientationConstants property PrintOrientationConstants.PrintOrientationPortrait was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprIncidentRpt.PrintOrientation was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprIncidentRpt.setPrintOrientation(UpgradeStubs.FPSpread_PrintOrientationConstants.getPrintOrientationPortrait());
			ViewModel.sprIncidentRpt.Action = FarPoint.ViewModels.FPActionConstants.ActionSmartPrint;
		}

		private void DisplayHeadings()
		{
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprIncidentRpt.RowPageBreak was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprIncidentRpt.setRowPageBreak(true);
			ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
			ViewModel.sprIncidentRpt.Col = 8;
			ViewModel.sprIncidentRpt.FontSize = 8;
			ViewModel.sprIncidentRpt.FontBold = true;
			ViewModel.sprIncidentRpt.Text = "Print Date:";
			ViewModel.sprIncidentRpt.Col = 10;
			ViewModel.sprIncidentRpt.FontSize = 8;
			ViewModel.sprIncidentRpt.FontBold = false;
			ViewModel.sprIncidentRpt.Text = UpgradeHelpers.Helpers.StringsHelper.Format(DateTime.Now, "m/d/yyyy h:nn AM/PM");
			(ViewModel.CurrRow)++;
			ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
			ViewModel.sprIncidentRpt.Col = 8;
			ViewModel.sprIncidentRpt.FontSize = 8;
			ViewModel.sprIncidentRpt.FontBold = true;
			ViewModel.sprIncidentRpt.Text = "Incident Number:";
			ViewModel.sprIncidentRpt.Col = 10;
			ViewModel.sprIncidentRpt.FontSize = 8;
			ViewModel.sprIncidentRpt.FontBold = false;
			ViewModel.sprIncidentRpt.Text = ViewModel.sDisplay;
			(ViewModel.CurrRow)++;
			ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
			ViewModel.sprIncidentRpt.Col = 1;
			ViewModel.sprIncidentRpt.Text = "Incident History";
			ViewModel.sprIncidentRpt.FontSize = 10;
			ViewModel.sprIncidentRpt.FontBold = true;
			ViewModel.sprIncidentRpt.FontItalic = true;
			ViewModel.sprIncidentRpt.BlockMode = true;
			ViewModel.sprIncidentRpt.Row2 = ViewModel.CurrRow;
			ViewModel.sprIncidentRpt.Col2 = 11;
			ViewModel.sprIncidentRpt.BackColor = IncidentMain.Shared.LTGRAY;
			ViewModel.sprIncidentRpt.BlockMode = false;
			(ViewModel.CurrRow)++;
			ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
			ViewModel.sprIncidentRpt.Col = 1;
			ViewModel.sprIncidentRpt.FontSize = 8;
			ViewModel.sprIncidentRpt.FontBold = true;
			ViewModel.sprIncidentRpt.Text = "Time";
			ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
			ViewModel.sprIncidentRpt.Col = 2;
			ViewModel.sprIncidentRpt.FontSize = 8;
			ViewModel.sprIncidentRpt.FontBold = true;
			ViewModel.sprIncidentRpt.Text = "Sending";
			ViewModel.sprIncidentRpt.Col = 3;
			ViewModel.sprIncidentRpt.FontSize = 8;
			ViewModel.sprIncidentRpt.FontBold = true;
			ViewModel.sprIncidentRpt.Text = "Action";
			ViewModel.sprIncidentRpt.Row = ViewModel.CurrRow;
			ViewModel.sprIncidentRpt.Col = 4;
			ViewModel.sprIncidentRpt.FontSize = 8;
			ViewModel.sprIncidentRpt.FontBold = true;
			ViewModel.sprIncidentRpt.Text = "Receiving";
			(ViewModel.CurrRow)++;
			ViewModel.PageCountRow = 4;
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmReportIncd DefInstance
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

		public static frmReportIncd CreateInstance()
		{
			TFDIncident.frmReportIncd theInstance = Shared.Container.Resolve< frmReportIncd>();
			theInstance.Form_Load();
			return theInstance;
		}

		protected override void ExecuteControlsStartup()
		{
			ViewModel.sprIncidentRpt.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprIncidentRpt.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmReportIncd
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.frmReportIncdViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmReportIncd m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}