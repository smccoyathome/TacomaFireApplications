using Microsoft.VisualBasic;
using System;
using UpgradeHelpers.DB.ADO;
using UpgradeStubs;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class frmSchedNoteQuery
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmSchedNoteQueryViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmSchedNoteQuery));
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


		private void frmSchedNoteQuery_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//***********************************
		//*  Query Personnel Schedule Notes *
		//*  By Date  / Comment text        *
		//***********************************

		public void FillGrid()
		{
			PTSProject.clsScheduler cSched = Container.Resolve< clsScheduler>();
			ViewModel.sprReport.MaxRows = 10000;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
			ViewModel.sprReport.Row = 1;
			ViewModel.sprReport.Row2 = ViewModel.sprReport.MaxRows;
			ViewModel.sprReport.BlockMode = true;
			ViewModel.sprReport.Text = "";
			ViewModel.sprReport.BlockMode = false;

			string sText = modGlobal.Clean(ViewModel.txtCommentSearch.Text);
			string StartDate = DateTime.Parse(ViewModel.dtStartDate.Text).ToString("MM/dd/yyyy");
			string EndDate = DateTime.Parse(ViewModel.dtEndDate.Text).ToString("MM/dd/yyyy");

			if (!Information.IsDate(StartDate))
			{
				return;
			}
			if (!Information.IsDate(EndDate))
			{
				return;
			}

			int CurrRow = 0;
			if (cSched.GetPersonnelSchedNotesFiltered(StartDate, EndDate, sText) != 0)
			{

			}
			else
			{
				ViewManager.ShowMessage("No Records were found.", "Query Personnel Sched Notes", UpgradeHelpers.Helpers.BoxButtons.OK);
				ViewModel.sprReport.MaxRows = 50;
				ViewModel.lbCount.Text = "List Count: " + "0";
				return;
			}


			while(!cSched.ScheduleRecord.EOF)
			{
				CurrRow++;
				ViewModel.sprReport.Row = CurrRow;
				ViewModel.sprReport.Col = 1;
				ViewModel.sprReport.Text = modGlobal.Clean(cSched.ScheduleRecord["name_full"]);
				ViewModel.sprReport.Col = 2;
				ViewModel.sprReport.Text = Convert.ToDateTime(cSched.ScheduleRecord["shift_start"]).ToString("MM/dd/yyyy");
				ViewModel.sprReport.Col = 3;
				ViewModel.sprReport.Text = modGlobal.Clean(cSched.ScheduleRecord["AuthoredBy"]);
				ViewModel.sprReport.Col = 4;
				ViewModel.sprReport.Text = modGlobal.Clean(cSched.ScheduleRecord["note"]);

				cSched.ScheduleRecord.MoveNext();
			}
			;
			ViewModel.sprReport.MaxRows = CurrRow;
			ViewModel.lbCount.Text = "List Count: " + CurrRow.ToString();




		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClear_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.txtCommentSearch.Text = "";
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdExit_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This option is under construction", vbOKOnly, "Print Schedule Note Grid List"
			//Print Schedule Note Grid List
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintBorder(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintColHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintColHeaders(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintSmartPrint was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintSmartPrint(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintAbortMsg("Printing PTS Personnel Schedule Notes Grid");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprReport.PrintSheet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//object tempRefParam = null;
			//WEBMAP_UPGRADE_ISSUE: (1101) FarPoint.Win.Spread.FpSpread.PrintSheet was not upgraded
			ViewModel.sprReport.PrintSheet(null);
		}

		[UpgradeHelpers.Events.Handler]
		internal void dtEndDate_ValueChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}
			FillGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void dtEndDate_Click(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}
			FillGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void dtStartDate_ValueChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}
			FillGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void dtStartDate_Click(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}
			FillGrid();
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			ViewModel.FirstTime = true;
			System.DateTime TempDate = DateTime.FromOADate(0);
			ViewModel.dtStartDate.Value = DateTime.Parse((DateTime.TryParse("1/1/" + DateTime.Now.Year.ToString(), out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : "1/1/" + DateTime.Now.Year.ToString());
			ViewModel.dtEndDate.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy"));
			ViewModel.txtCommentSearch.Text = "Flu";
			FillGrid();
			ViewModel.FirstTime = false;
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtCommentSearch_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}
			FillGrid();
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmSchedNoteQuery DefInstance
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

		public static frmSchedNoteQuery CreateInstance()
		{
			PTSProject.frmSchedNoteQuery theInstance = Shared.Container.Resolve< frmSchedNoteQuery>();
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

	public partial class frmSchedNoteQuery
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmSchedNoteQueryViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmSchedNoteQuery m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}