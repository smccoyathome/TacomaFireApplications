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

	public partial class frmTransfReqAssign
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmTransfReqAssignViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmTransfReqAssign));
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


		private void frmTransfReqAssign_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		//************************************************
		// TFD Assignments From Request This Last Year ***
		//************************************************
		[UpgradeHelpers.Events.Handler]
		internal void cboName_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboName.SelectedIndex == -1)
			{
				return;
			}

			int GoRow = ViewModel.cboName.GetItemData(ViewModel.cboName.SelectedIndex);
			ViewModel.sprReport.Row = 1;
			ViewModel.sprReport.Row2 = ViewModel.sprReport.MaxRows;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
			ViewModel.sprReport.BlockMode = true;
			ViewModel.sprReport.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprReport.BlockMode = false;
			ViewModel.sprReport.BlockMode = true;
			ViewModel.sprReport.Row = GoRow;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Row2 = GoRow;
			ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
			ViewModel.sprReport.BackColor = modGlobal.Shared.PARCHMENT;
			ViewModel.sprReport.BlockMode = false;
			//ViewModel.sprReport.SetSelection(1, GoRow, ViewModel.sprReport.MaxCols, GoRow);


		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.sprReport.Row = 1;
			ViewModel.sprReport.Row2 = ViewModel.sprReport.MaxRows;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
			ViewModel.sprReport.BlockMode = true;
			ViewModel.sprReport.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprReport.BlockMode = false;

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintFooter was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintFooter("/nPrinted on " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "/r Page /p of /pc");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintAbortMsg("Printing TFD Assignments From Request This Last Year");
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
			//Load Roster form
			//Load Find Employee Listbox
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spSelect_PersonnelTransferAssignmentChangeWithinYear ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.CurrRow = 0;
			string sName = "";
			ViewModel.cboName.Items.Clear();


			while(!oRec.EOF)
			{
				(ViewModel.CurrRow)++;

				if ( ViewModel.CurrRow == 1)
				{ //First time
					sName = modGlobal.Clean(oRec["name_full"]);
					ViewModel.cboName.AddItem(modGlobal.Clean(oRec["name_full"]));
					ViewModel.cboName.SetItemData(ViewModel.cboName.GetNewIndex(), ViewModel.CurrRow);
				}

				if (sName != modGlobal.Clean(oRec["name_full"]))
				{
					sName = modGlobal.Clean(oRec["name_full"]);
					ViewModel.cboName.AddItem(modGlobal.Clean(oRec["name_full"]));
					ViewModel.cboName.SetItemData(ViewModel.cboName.GetNewIndex(), ViewModel.CurrRow);
				}
				ViewModel.sprReport.Row = ViewModel.CurrRow;
				ViewModel.sprReport.Col = 1;
				ViewModel.sprReport.Text = modGlobal.Clean(oRec["name_full"]);
				ViewModel.sprReport.Col = 2;
				ViewModel.sprReport.Text = modGlobal.Clean(oRec["AssignPosition"]);
				ViewModel.sprReport.Col = 3;
				System.DateTime TempDate = DateTime.FromOADate(0);
				ViewModel.sprReport.Text = (DateTime.TryParse(modGlobal.Clean(oRec["min_assigned"]), out TempDate)) ? TempDate.ToString("M/d/yyyy") : modGlobal.Clean(oRec["min_assigned"]);
				ViewModel.sprReport.Col = 4;
				System.DateTime TempDate2 = DateTime.FromOADate(0);
				ViewModel.sprReport.Text = (DateTime.TryParse(modGlobal.Clean(oRec["max_closed"]), out TempDate2)) ? TempDate2.ToString("M/d/yyyy") : modGlobal.Clean(oRec["max_closed"]);
				ViewModel.sprReport.Col = 5;
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.sprReport.Text = Convert.ToString(modGlobal.GetVal(oRec["per_sys_id"]));


				oRec.MoveNext();
			};

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmTransfReqAssign DefInstance
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

		public static frmTransfReqAssign CreateInstance()
		{
			PTSProject.frmTransfReqAssign theInstance = Shared.Container.Resolve< frmTransfReqAssign>();
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

	public partial class frmTransfReqAssign
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmTransfReqAssignViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmTransfReqAssign m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}