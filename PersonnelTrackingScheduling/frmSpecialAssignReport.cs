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

	public partial class frmSpecialAssignReport
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmSpecialAssignReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmSpecialAssignReport));
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


		private void frmSpecialAssignReport_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//************************************
		//* Annual Special Assignment Report *
		//************************************
		//ADODB

		public void FormatReport()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			//initialize grid / fields
			ViewModel.sprReport.MaxRows = 5000;
			ViewModel.lbTotal.Text = "";
			ViewModel.sprReport.Row = 1;
			ViewModel.sprReport.Row2 = ViewModel.sprReport.MaxRows;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
			ViewModel.sprReport.BlockMode = true;
			ViewModel.sprReport.Text = "";
			ViewModel.sprReport.BlockMode = false;
			ViewModel.CurrRow = 0;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			oCmd.CommandText = "spReport_SpecialAssignmentsByYear " + "'" + modGlobal.Clean(ViewModel.cboYear.Text) + "' ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				(ViewModel.CurrRow)++;
				ViewModel.sprReport.Row = ViewModel.CurrRow;
				ViewModel.sprReport.Col = 1;
				ViewModel.sprReport.Text = modGlobal.Clean(oRec["EmployeeName"]);
				ViewModel.sprReport.Col = 2;
				ViewModel.sprReport.Text = Convert.ToDateTime(oRec["shift_start"]).ToString("MM/dd/yyyy HH:mm");
				ViewModel.sprReport.Col = 3;
				ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprReport.Text = modGlobal.Clean(oRec["time_code_id"]);
				ViewModel.sprReport.Col = 4;
				ViewModel.sprReport.Text = modGlobal.Clean(oRec["AuthorName"]);
				ViewModel.sprReport.Col = 5;
				ViewModel.sprReport.Text = modGlobal.Clean(oRec["note"]);

				oRec.MoveNext();
			};
			ViewModel.sprReport.MaxRows = ViewModel.CurrRow;
			ViewModel.lbTotal.Text = "Total Rows = " + ViewModel.CurrRow.ToString();


		}

		[UpgradeHelpers.Events.Handler]
		internal void cboYear_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			FormatReport();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This feature is coming soon!", vbOKOnly, "TFD Special Assignment Report By Year"
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintFooter was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintFooter("/nPrinted on " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "/r Page /p of /pc");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintAbortMsg("Printing FD Special Assignment Report");
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

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			//int i = 0, x = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

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
			ViewModel.cboYear.Text = Conversion.Str(DateTime.Now.Year);
			ViewModel.ReportYear = Convert.ToInt32(Double.Parse(modGlobal.Clean(ViewModel.cboYear.Text)));

			FormatReport();

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmSpecialAssignReport DefInstance
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

		public static frmSpecialAssignReport CreateInstance()
		{
			PTSProject.frmSpecialAssignReport theInstance = Shared.Container.Resolve< frmSpecialAssignReport>();
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

	public partial class frmSpecialAssignReport
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmSpecialAssignReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmSpecialAssignReport m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}