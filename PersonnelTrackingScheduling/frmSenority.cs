using System;
using System.Data;
using System.Data.Common;
using System.Text;
using UpgradeHelpers.DB.ADO;
using UpgradeStubs;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class frmSenority
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmSenorityViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmSenority));
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


		private void frmSenority_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		//*******************************************************
		//Senority Ranking Inquiry Form
		//Opened from main menu or Individual Leave Schedule form
		//*******************************************************
		//ADODB

		public void RefreshGrid()
		{
			//Add Selected Employees (SelectedName Array) to grdSenority

			string strSQL = "";
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			StringBuilder Criteria = new System.Text.StringBuilder();
			int i = 0;
			int iRow = 0;

			try
			{

				// Clear Flex Grid -- displayed list of
				// Selected Employees
				//    grdSenority.Clear
				//    grdSenority.Rows = 0
				//    grdSenority.ColWidth(0) = 2400
				//    grdSenority.ColWidth(1) = 1200

				// Clear the Spreadsheet Report
				// the hidden view of selected Employees
				//    sprSeniority.BlockMode = True
				//    sprSeniority.Row = 1
				//    sprSeniority.Row2 = 500
				//    sprSeniority.Col = 1
				//    sprSeniority.Col2 = 2
				//    sprSeniority.Action = 12
				//    sprSeniority.BlockMode = False
				ViewModel.sprGrid.MaxRows = 500;
				ViewModel.sprGrid.BlockMode = true;
				ViewModel.sprGrid.Row = 1;
				ViewModel.sprGrid.Row2 = ViewModel.sprGrid.MaxRows;
				ViewModel.sprGrid.Col = 1;
				ViewModel.sprGrid.Col2 = ViewModel.sprGrid.MaxCols;
				ViewModel.sprGrid.Text = "";
				ViewModel.sprGrid.BlockMode = false;

				i = 0;

				// String together the "WHERE" criteria for SQL query
				Criteria = new System.Text.StringBuilder("employee_id = '" + ViewModel.SelectedName[i] + "'");
				for (i = 1; i <= ViewModel.TotalNames; i++)
				{
					Criteria.Append(" OR employee_id = '" + ViewModel.SelectedName[i] + "'");
				}

				//Retreive Senority Listing
				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				strSQL = "SELECT * FROM vSenorityListing WHERE " + Criteria.ToString() + " ORDER BY AdjustedDate";
				oCmd.CommandText = strSQL;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				// Start filling the spreadsheet report on line 4
				iRow = 0;

				//Load Senority Grid

				while(!oRec.EOF)
				{
					iRow++;
					// Add to the Flex Grid
					//        grdRow = oRec("name_full") & vbTab & oRec("AdjustedDate")
					//        grdSenority.ADDItem grdRow
					// Add to the Spreadsheet
					//        sprSeniority.Col = 1
					//        sprSeniority.Row = iRow
					//        sprSeniority.Text = oRec("name_full")
					//        sprSeniority.Col = 2
					//        sprSeniority.Text = oRec("AdjustedDate")
					ViewModel.sprGrid.Col = 1;
					ViewModel.sprGrid.Row = iRow;
					ViewModel.sprGrid.Text = Convert.ToString(oRec["name_full"]);
					ViewModel.sprGrid.Col = 2;
					ViewModel.sprGrid.Text = Convert.ToString(oRec["AdjustedDate"]);
					// loop to next record

					oRec.MoveNext();
				}
				;
				ViewModel.sprGrid.MaxRows = iRow;
				ViewModel.sprGrid.Visible = true;
				ViewModel.cmdPrint.Visible = true;
				ViewModel.TotalNames = iRow;
			}
			catch
			{

				if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
				{
					return;
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboName_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Add Selected Employee to SelectedNames Array
			//Refresh Senority Grid
			string Empid = "";

			try
			{
				//Come Here - for employee id change
				Empid = ViewModel.cboName.Text.Substring(Math.Max(ViewModel.cboName.Text.Length - 5, 0));
				//Check to make sure this is not a duplicate Employee
				for (int i = 0; i <= ViewModel.TotalNames; i++)
				{
					if ( ViewModel.SelectedName[i] == Empid)
					{
						return;
					}
				}

				//Add selected employee to SelectedName Array
				ViewModel.SelectedName[ViewModel.TotalNames] = Empid;
				RefreshGrid();
			}
			catch
			{

				if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
				{
					return;
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClear_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Clear Senority Grid

			// Clear the Flex Grid
			//    grdSenority.Clear
			//    grdSenority.Rows = 0

			// Clear the Spreadsheet
			//    sprSeniority.BlockMode = True
			//    sprSeniority.Row = 1
			//    sprSeniority.Row2 = 500
			//    sprSeniority.Col = 1
			//    sprSeniority.Col2 = 2
			//    sprSeniority.Action = 12
			//    sprSeniority.BlockMode = False
			ViewModel.sprGrid.MaxRows = 500;
			ViewModel.sprGrid.BlockMode = true;
			ViewModel.sprGrid.Row = 1;
			ViewModel.sprGrid.Row2 = ViewModel.sprGrid.MaxRows;
			ViewModel.sprGrid.Col = 1;
			ViewModel.sprGrid.Col2 = ViewModel.sprGrid.MaxCols;
			ViewModel.sprGrid.Text = "";
			ViewModel.sprGrid.BlockMode = false;

			for (int i = 0; i <= ViewModel.TotalNames; i++)
			{
				ViewModel.SelectedName[i] = "";
			}
			ViewModel.TotalNames = 0;
			ViewModel.sprGrid.Visible = false;
			ViewModel.cmdPrint.Visible = false;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Close Senority Form
			ViewManager.DisposeView(this);

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{


			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprGrid.PrintHeader was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprGrid.setPrintHeader("/lPTS - Seniority Ranking /rPage /p of /pc");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprGrid.PrintFooter was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprGrid.setPrintFooter("/nPrinted on " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprGrid.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprGrid.setPrintAbortMsg("Printing Seniority Ranking List");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprGrid.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprGrid.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprGrid.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprGrid.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprGrid.PrintColHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprGrid.setPrintColHeaders(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprGrid.PrintSmartPrint was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprGrid.setPrintSmartPrint(true);

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprGrid.PrintSheet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//object tempRefParam = null;
			//WEBMAP_UPGRADE_ISSUE: (1101) FarPoint.Win.Spread.FpSpread.PrintSheet was not upgraded
			ViewModel.sprGrid.PrintSheet(null);



			//    Dim i As Integer
			//    Dim iRow As Integer
			//    Dim iTotalRows As Integer
			//
			//    iTotalRows = grdSenority.Rows
			//    If iTotalRows < 1 Then Exit Sub
			//
			//    ' Add Headings to the Report
			//    sprSeniority.Row = 1
			//    sprSeniority.Col = 1
			//    sprSeniority.Text = "PTS - Seniority Ranking"
			//    sprSeniority.Col = 2
			//    sprSeniority.Text = "Printed " + Format$(Now(), "m/d/yy hh:nn")
			//    sprSeniority.Col = 1
			//    sprSeniority.Row = 3
			//    sprSeniority.Text = "Employee"
			//    sprSeniority.Col = 2
			//    sprSeniority.Text = "Adjusted Date"
			//
			//    ' Print the Report
			//    sprSeniority.PrintAbortMsg = "Printing Seniority Ranking List - Click Cancel to quit"
			//    sprSeniority.PrintBorder = False
			//    sprSeniority.Action = 32

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			//Load Name list box with Operations Staff

			string strName = "";
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				frmSenority.DefInstance.ViewModel.cboName.Items.Clear();

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spOpNameList";
				oRec = ADORecordSetHelper.Open(oCmd, "");

				while(!oRec.EOF)
				{
					strName = Convert.ToString(oRec["name_full"]).Trim() + "  :" + Convert.ToString(oRec["employee_id"]);
					frmSenority.DefInstance.ViewModel.cboName.AddItem(strName);
					oRec.MoveNext();
				};
				ViewModel.TotalNames = 0;
				ViewModel.cmdPrint.Visible = false;
			}
			catch
			{

				if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
				{
					return;
				}
			}

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmSenority DefInstance
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

		public static frmSenority CreateInstance()
		{
			PTSProject.frmSenority theInstance = Shared.Container.Resolve< frmSenority>();
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
			ViewModel.grdSenority.LifeCycleStartup();
			ViewModel.sprGrid.LifeCycleStartup();
			ViewModel.sprSeniority.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.grdSenority.LifeCycleShutdown();
			ViewModel.sprGrid.LifeCycleShutdown();
			ViewModel.sprSeniority.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmSenority
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmSenorityViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmSenority m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}