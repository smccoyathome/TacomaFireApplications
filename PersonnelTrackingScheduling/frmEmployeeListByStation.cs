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

	public partial class frmEmployeeListByStation
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmEmployeeListByStationViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmEmployeeListByStation));
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


		private void frmEmployeeListByStation_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//*********************************
		//*  TFD Employee List By Station *
		//*********************************

		public void FormatReport()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			//initialize grid / fields
			ViewModel.sprReport.MaxRows = 500;
			ViewModel.lbCount.Text = "";
			string sCurrStation = "";
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

			if ( ViewModel.FacilityID == 0)
			{
				oCmd.CommandText = "spSelect_PersonnelListByStation NULL";
			}
			else
			{
				oCmd.CommandText = "spSelect_PersonnelListByStation " + ViewModel.FacilityID.ToString() + " ";
			}
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				(ViewModel.CurrRow)++;
				ViewModel.sprReport.Row = ViewModel.CurrRow;

				if (sCurrStation == "")
				{ //first time
					sCurrStation = modGlobal.Clean(oRec["facility_name"]);
				}
				else if (sCurrStation != modGlobal.Clean(oRec["facility_name"]))
				{
					//set page break
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.RowPageBreak was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprReport.setRowPageBreak(true);
					sCurrStation = modGlobal.Clean(oRec["facility_name"]);
				}
				else
				{
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.RowPageBreak was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprReport.setRowPageBreak(false);
				}
				ViewModel.sprReport.Col = 1;
				ViewModel.sprReport.Text = modGlobal.Clean(oRec["name_full"]);
				ViewModel.sprReport.Col = 2;
				ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprReport.Text = modGlobal.Clean(oRec["facility_name"]);
				ViewModel.sprReport.Col = 3;
				ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprReport.Text = modGlobal.Clean(oRec["unit_code"]);
				ViewModel.sprReport.Col = 4;
				ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprReport.Text = modGlobal.Clean(oRec["position_code"]);
				ViewModel.sprReport.Col = 5;
				ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprReport.Text = modGlobal.Clean(oRec["shift_code"]);
				ViewModel.sprReport.Col = 6;
				ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprReport.Text = modGlobal.Clean(oRec["assignment_type_code"]);

				oRec.MoveNext();
			};
			ViewModel.sprReport.MaxRows = ViewModel.CurrRow;
			ViewModel.lbCount.Text = "List Count: " + ViewModel.CurrRow.ToString();

		}

		public void FillLists()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//fill dropdown list for Stations
			string strSQL = "spSelect_TFDFacilityList ";

			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboLocation.Items.Clear();

			while(!oRec.EOF)
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
			if ( ViewModel.cboLocation.SelectedIndex == -1)
			{
				ViewModel.FacilityID = 0;
			}
			else
			{
				ViewModel.FacilityID = ViewModel.cboLocation.GetItemData(ViewModel.cboLocation.SelectedIndex);
				ViewModel.chkSelectAll.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			}
			FormatReport();
		}

		[UpgradeHelpers.Events.Handler]
		internal void chkSelectAll_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{

			if ( ViewModel.chkSelectAll.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				ViewModel.FacilityID = 0;
				ViewModel.cboLocation.Text = "";
				ViewModel.cboLocation.SelectedIndex = -1;
				FormatReport();
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdExit_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This feature is coming soon!", vbOKOnly, "TFD Employee List by Assigned Facility"
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintFooter was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintFooter("/nPrinted on " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "/r Page /p of /pc");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintAbortMsg("Printing TFD Employee List By Station/Facility");
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

			FillLists();
			ViewModel.cboLocation.SelectedIndex = -1;
			ViewModel.chkSelectAll.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
			ViewModel.FacilityID = 0;

			FormatReport();

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmEmployeeListByStation DefInstance
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

		public static frmEmployeeListByStation CreateInstance()
		{
			PTSProject.frmEmployeeListByStation theInstance = Shared.Container.Resolve< frmEmployeeListByStation>();
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

	public partial class frmEmployeeListByStation
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmEmployeeListByStationViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmEmployeeListByStation m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}