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

	public partial class dlgSignOff
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgSignOffViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(dlgSignOff));
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


		private void dlgSignOff_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		public void FillGrid()
		{
			PTSProject.clsFireUpload clPayroll = Container.Resolve< clsFireUpload>();
			ViewModel.sprReport.MaxRows = 500;
			ViewModel.sprPrintList.MaxRows = 500;

			//clear grid
			ViewModel.sprPrintList.Row = 4;
			ViewModel.sprPrintList.Row2 = ViewModel.sprReport.MaxRows;
			ViewModel.sprPrintList.Col = 1;
			ViewModel.sprPrintList.Col2 = ViewModel.sprReport.MaxCols;
			ViewModel.sprPrintList.BlockMode = true;
			ViewModel.sprPrintList.Text = "";
			ViewModel.sprPrintList.BlockMode = false;
			ViewModel.sprPrintList.Row = 1;
			ViewModel.sprPrintList.Col = 1;
			ViewModel.sprPrintList.Text = "Payroll Sign Off for " + ViewModel.cboNameList.Text + " ";
			ViewModel.sprPrintList.Row = 2;
			ViewModel.sprPrintList.Col = 3;
			ViewModel.sprPrintList.Text = "Printed " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
			ViewModel.sprReport.Row = 1;
			ViewModel.sprReport.Row2 = ViewModel.sprReport.MaxRows;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
			ViewModel.sprReport.BlockMode = true;
			ViewModel.sprReport.Text = "";
			ViewModel.sprReport.BlockMode = false;

			if (~clPayroll.GetEmployeePayrollSignOffReport(ViewModel.CurrSAPID) != 0)
			{
				ViewManager.ShowMessage("There is no Sign Off information for this employee.", "Payroll SignOff Information", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			int iRow = 1;
			int iPrintRow = 4;


			while(!clPayroll.PPayrollSignOff.EOF)
			{
				ViewModel.sprReport.Row = iRow;
				ViewModel.sprPrintList.Row = iPrintRow;
				ViewModel.sprPrintList.Col = 1;
				ViewModel.sprPrintList.Text = Convert.ToDateTime(clPayroll.PPayrollSignOff["start_date"]).ToString("M/d/yyyy") +
							" - " + Convert.ToDateTime(clPayroll.PPayrollSignOff["end_date"]).ToString("M/d/yyyy");
				ViewModel.sprReport.Col = 1;
				ViewModel.sprReport.Text = Convert.ToDateTime(clPayroll.PPayrollSignOff["start_date"]).ToString("M/d/yyyy") +
							" - " + Convert.ToDateTime(clPayroll.PPayrollSignOff["end_date"]).ToString("M/d/yyyy");
				ViewModel.sprPrintList.Col = 2;
				ViewModel.sprPrintList.Text = Convert.ToDateTime(clPayroll.PPayrollSignOff["signoff_date"]).ToString("M/d/yyyy HH:mm:ss");
				ViewModel.sprReport.Col = 2;
				ViewModel.sprReport.Text = Convert.ToDateTime(clPayroll.PPayrollSignOff["signoff_date"]).ToString("M/d/yyyy HH:mm:ss");
				ViewModel.sprPrintList.Col = 3;
				ViewModel.sprPrintList.Text = modGlobal.Clean(clPayroll.PPayrollSignOff["Message"]);
				ViewModel.sprReport.Col = 3;
				ViewModel.sprReport.Text = modGlobal.Clean(clPayroll.PPayrollSignOff["Message"]);

				iRow++;
				iPrintRow++;
				clPayroll.PPayrollSignOff.MoveNext();

			}
			;
			ViewModel.sprReport.MaxRows = iRow;
			ViewModel.sprPrintList.MaxRows = iPrintRow;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboNameList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			if ( ViewModel.cboNameList.SelectedIndex < 0)
			{
				return;
			} //no selection

			//Come Here - for employee id change
			ViewModel.CurrEmpID = ViewModel.cboNameList.Text.Substring(Math.Max(ViewModel.cboNameList.Text.Length - 5, 0));
			oCmd.CommandText = "sp_GetPersonnelDetail '" + ViewModel.CurrEmpID + "'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (oRec.EOF)
			{
				ViewManager.ShowMessage("Unable to Recall Employee Information", "Payroll SignOff", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				return;
			}
			ViewModel.CurrPersID = Convert.ToInt32(oRec["per_sys_id"]);

			oCmd.CommandText = "spSelect_SAPConversionByEmployee " + ViewModel.CurrPersID.ToString() + " ";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			if (oRec.EOF)
			{
				ViewManager.ShowMessage("Unable to Get Employee's SAP ID... Not TFD Employee.", "Payroll SignOff", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
			
				return;
			}
			ViewModel.CurrSAPID = Convert.ToInt32(oRec["sap_id"]);
			FillGrid();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Print Employee Grid List
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPrintList.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprPrintList.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPrintList.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprPrintList.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPrintList.PrintColHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprPrintList.setPrintColHeaders(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPrintList.PrintSmartPrint was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprPrintList.setPrintSmartPrint(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPrintList.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprPrintList.setPrintAbortMsg("Printing Employee SignOff Information");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprPrintList.PrintSheet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//object tempRefParam = null;
			//WEBMAP_UPGRADE_ISSUE: (1101) FarPoint.Win.Spread.FpSpread.PrintSheet was not upgraded
			ViewModel.sprPrintList.PrintSheet(null);
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string strName = "";

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spFullNameList";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				strName = Convert.ToString(oRec["name_full"]).Trim() + "  :" + Convert.ToString(oRec["employee_id"]);
				this.ViewModel.cboNameList.AddItem(strName);
				oRec.MoveNext();
			};

			if (modGlobal.Shared.gReportUser != "")
			{
				for (int i = 0; i <= ViewModel.cboNameList.Items.Count - 1; i++)
				{
					//Come Here - for employee id change
					if ( ViewModel.cboNameList.GetListItem(i).Substring(Math.Max(ViewModel.cboNameList.GetListItem(i).Length - 5, 0)) == modGlobal.Shared.gReportUser)
					{
						ViewModel.CurrEmpID = modGlobal.Shared.gReportUser;
						ViewModel.cboNameList.SelectedIndex = i;
						break;
					}
				}
			}


		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static dlgSignOff DefInstance
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

		public static dlgSignOff CreateInstance()
		{
			PTSProject.dlgSignOff theInstance = Shared.Container.Resolve< dlgSignOff>();
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
			ViewModel.sprPrintList.LifeCycleStartup();
			ViewModel.sprReport.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprPrintList.LifeCycleShutdown();
			ViewModel.sprReport.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class dlgSignOff
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgSignOffViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual dlgSignOff m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}