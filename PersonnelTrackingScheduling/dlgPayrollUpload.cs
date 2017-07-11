using System;
using UpgradeHelpers.DB.ADO;
using UpgradeStubs;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class dlgPayrollUpload
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgPayrollUploadViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(dlgPayrollUpload));
			if ( Shared.m_vb6FormDefInstance == null)
			{
				if ( Shared.m_InitializingDefInstance)
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
		}


		private void dlgPayrollUpload_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}


		public void FormatPayPeriodReport()
		{
			PTSProject.clsFireUpload clPayroll = Container.Resolve< clsFireUpload>();

			//initialize fields
			ViewModel.sprReport.Col = 2;
			ViewModel.sprReport.Row = 4;
			ViewModel.sprReport.Text = "0";
			ViewModel.sprReport.Row = 5;
			ViewModel.sprReport.Text = "0";
			ViewModel.sprReport.Row = 6;
			ViewModel.sprReport.Text = "0";
			ViewModel.sprReport.Row = 7;
			ViewModel.sprReport.Text = "N/A";
			ViewModel.sprReport.Row = 8;
			ViewModel.sprReport.Text = "0";

			int TotalRecords = 0;
			if (clPayroll.GetPayPeriodReconciliationSummary(modGlobal.Shared.gPayrollYear, modGlobal.Shared.gPayPeriod) != 0)
			{


				while(!clPayroll.PayrollReconciliation.EOF)
				{
					//Print Summary Upload Totals
					ViewModel.sprReport.Col = 2;

					TotalRecords += Convert.ToInt32(clPayroll.PayrollReconciliation["total"]);

					switch(modGlobal.Clean(clPayroll.PayrollReconciliation["status"]))
					{
						case "S" :
							ViewModel.sprReport.Row = 5;
							ViewModel.sprReport.Text = (Convert.ToInt32(Double.Parse(ViewModel.sprReport.Text)) + Convert.ToInt32(clPayroll.PayrollReconciliation["total"])).ToString();

							break;
						case "D" :
							ViewModel.sprReport.Row = 6;
							ViewModel.sprReport.Text = (Convert.ToInt32(Double.Parse(ViewModel.sprReport.Text)) + Convert.ToInt32(clPayroll.PayrollReconciliation["total"])).ToString();

							break;
						default:
							ViewModel.sprReport.Row = 8;
							ViewModel.sprReport.Text = (Convert.ToInt32(Double.Parse(ViewModel.sprReport.Text)) + Convert.ToInt32(clPayroll.PayrollReconciliation["total"])).ToString();

							break;
					}
					clPayroll.PayrollReconciliation.MoveNext();
				};
				ViewModel.sprReport.Row = 4;
				ViewModel.sprReport.Text = TotalRecords.ToString();
			}

			int RowCount = 12;

			if (clPayroll.GetPayPeriodReconciliationErrors(modGlobal.Shared.gPayrollYear, modGlobal.Shared.gPayPeriod) != 0)
			{

				while(!clPayroll.PayrollReconciliation.EOF)
				{
					ViewModel.sprReport.Row = RowCount;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.Text = modGlobal.Clean(clPayroll.PayrollReconciliation["name_full"]) + " (" +
									Convert.ToString(clPayroll.PayrollReconciliation["sap_id"]) + ") ";
					ViewModel.sprReport.Col = 2;
					ViewModel.sprReport.Text = Convert.ToDateTime(clPayroll.PayrollReconciliation["payroll_date"]).ToString("MM/dd/yyyy");
					ViewModel.sprReport.Col = 3;
					ViewModel.sprReport.Text = modGlobal.Clean(clPayroll.PayrollReconciliation["abs_att_type"]);
					ViewModel.sprReport.Col = 4;
					ViewModel.sprReport.Text = modGlobal.Clean(clPayroll.PayrollReconciliation["payscalegroup"]);
					ViewModel.sprReport.Col = 5;
					ViewModel.sprReport.Text = modGlobal.Clean(clPayroll.PayrollReconciliation["payscalelevel"]);
					ViewModel.sprReport.Col = 6;
					ViewModel.sprReport.Text = Math.Round((double) Convert.ToDouble(clPayroll.PayrollReconciliation["catshours"]), 2).ToString();

					RowCount++;
					ViewModel.sprReport.Row = RowCount;
					ViewModel.sprReport.Col = 1;
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprReport.AddCellSpan was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprReport.AddCellSpan(1, RowCount, ViewModel.sprReport.MaxCols, 1);
					ViewModel.sprReport.Text = modGlobal.Clean(clPayroll.PayrollReconciliation["return_msg"]);

					clPayroll.PayrollReconciliation.MoveNext();
					RowCount += 2;
				};
			}
			else
			{
				ViewModel.sprReport.Row = RowCount;
				ViewModel.sprReport.Col = 1;
				ViewModel.sprReport.FontBold = true;
				ViewModel.sprReport.Text = "NO ERRORS TO REPORT";
				RowCount++;
			}

			RowCount += 3;
			ViewModel.sprReport.Row = RowCount;
			ViewModel.sprReport.Col = 1;
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprReport.AddCellSpan was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.AddCellSpan(1, RowCount, ViewModel.sprReport.MaxCols, 1);
			ViewModel.sprReport.Text = "Printed On:  " + DateTime.Now.ToString("MM/dd/yyyy HH:mm") + " for " + modGlobal.Shared.gUserName;
			ViewModel.sprReport.MaxRows = RowCount;

		}

		public void FormatReport()
		{
			PTSProject.clsFireUpload clPayroll = Container.Resolve< clsFireUpload>();

			//Print Summary Upload Totals
			ViewModel.sprReport.Col = 2;
			ViewModel.sprReport.Row = 4;
			ViewModel.sprReport.Text = modPTSPayroll.Shared.gTotalSAPRecords.ToString();
			ViewModel.sprReport.Row = 5;
			ViewModel.sprReport.Text = modPTSPayroll.Shared.gTotalSAPInserts.ToString();
			ViewModel.sprReport.Row = 6;
			ViewModel.sprReport.Text = modPTSPayroll.Shared.gTotalSAPDeletes.ToString();
			ViewModel.sprReport.Row = 7;
			ViewModel.sprReport.Text = modPTSPayroll.Shared.gTotalSAPChanges.ToString();
			ViewModel.sprReport.Row = 8;
			ViewModel.sprReport.Text = modPTSPayroll.Shared.gTotalSAPErrors.ToString();

			int RowCount = 12;

			if (clPayroll.GetPayrollReconciliationReport(modPTSPayroll.Shared.gUserSAPid, modGlobal.Shared.gPayrollYear, modGlobal.Shared.gPayPeriod) != 0)
			{

				while(!clPayroll.PayrollReconciliation.EOF)
				{
					ViewModel.sprReport.Row = RowCount;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.Text = modGlobal.Clean(clPayroll.PayrollReconciliation["name_full"]);
					ViewModel.sprReport.Col = 2;
					ViewModel.sprReport.Text = Convert.ToDateTime(clPayroll.PayrollReconciliation["payroll_date"]).ToString("MM/dd/yyyy");
					ViewModel.sprReport.Col = 3;
					ViewModel.sprReport.Text = modGlobal.Clean(clPayroll.PayrollReconciliation["abs_att_type"]);
					ViewModel.sprReport.Col = 4;
					ViewModel.sprReport.Text = modGlobal.Clean(clPayroll.PayrollReconciliation["payscalegroup"]);
					ViewModel.sprReport.Col = 5;
					ViewModel.sprReport.Text = modGlobal.Clean(clPayroll.PayrollReconciliation["payscalelevel"]);
					ViewModel.sprReport.Col = 6;
					ViewModel.sprReport.Text = Math.Round((double) Convert.ToDouble(clPayroll.PayrollReconciliation["catshours"]), 2).ToString();

					RowCount++;
					ViewModel.sprReport.Row = RowCount;
					ViewModel.sprReport.Col = 1;
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprReport.AddCellSpan was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprReport.AddCellSpan(1, RowCount, ViewModel.sprReport.MaxCols, 1);
					ViewModel.sprReport.Text = modGlobal.Clean(clPayroll.PayrollReconciliation["return_msg"]);

					clPayroll.PayrollReconciliation.MoveNext();
					RowCount += 2;
				};
			}
			else
			{
				ViewModel.sprReport.Row = RowCount;
				ViewModel.sprReport.Col = 1;
				ViewModel.sprReport.FontBold = true;
				ViewModel.sprReport.Text = "NO ERRORS TO REPORT";
				RowCount++;
			}

			RowCount += 3;
			ViewModel.sprReport.Row = RowCount;
			ViewModel.sprReport.Col = 1;
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprReport.AddCellSpan was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.AddCellSpan(1, RowCount, ViewModel.sprReport.MaxCols, 1);
			ViewModel.sprReport.Text = "Printed On:  " + DateTime.Now.ToString("MM/dd/yyyy HH:mm") + " for " + modGlobal.Shared.gUserName;
			ViewModel.sprReport.MaxRows = RowCount;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This option is under construction", vbOKOnly, "Print SAP Upload Summary/Error Report"
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintAbortMsg("Printing SAP Upload Summary/Error Report - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintJobName was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintJobName("PTS SAP Payroll Summary Report");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintMarginLeft was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintMarginLeft(360);
			//    sprReport.PrintOrientation = 1
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintSmartPrint was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintSmartPrint(true);
            //UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprReport.PrintSheet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
            // VALUE NOT USED
            //object tempRefParam = null;
			//WEBMAP_UPGRADE_ISSUE: (1101) FarPoint.Win.Spread.FpSpread.PrintSheet was not upgraded
			ViewModel.sprReport.PrintSheet(null);

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{

			if (modPTSPayroll.Shared.gPayPeriodReportFlag)
			{
				FormatPayPeriodReport();
			}
			else
			{
				FormatReport();
			}
		}

		private void sprReport_Advance(object eventSender, Stubs._FarPoint.Win.Spread.AdvanceEventArgs eventArgs)
		{
			bool AdvanceNext = eventArgs.AdvanceNext;

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static dlgPayrollUpload DefInstance
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

		public static dlgPayrollUpload CreateInstance()
		{
			PTSProject.dlgPayrollUpload theInstance = Shared.Container.Resolve< dlgPayrollUpload>();
			theInstance.Form_Load();
			return theInstance;
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

	public partial class dlgPayrollUpload
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgPayrollUploadViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual dlgPayrollUpload m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}