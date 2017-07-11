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

	public partial class frmRoster
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmRosterViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmRoster));
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


		private void frmRoster_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		public void DisplayHeadings()
		{
			ViewModel.sprRoster.Row = ViewModel.CurrRow;
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprRoster.RowPageBreak was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprRoster.setRowPageBreak(true);
			(ViewModel.CurrRow)++;
			ViewModel.sprRoster.Row = ViewModel.CurrRow;
			ViewModel.sprRoster.Col = 1;
			ViewModel.sprRoster.Text = "Tacoma Fire Department";
			ViewModel.sprRoster.FontSize = 12;
			ViewModel.sprRoster.FontBold = true;
			ViewModel.sprRoster.Col = 9;
			ViewModel.sprRoster.Text = "Page";
			ViewModel.sprRoster.FontSize = 12;
			ViewModel.sprRoster.FontBold = true;
			ViewModel.sprRoster.Col = 10;
			(ViewModel.PageNo)++;
			ViewModel.sprRoster.Text = ViewModel.PageNo.ToString();
			ViewModel.sprRoster.FontSize = 12;
			ViewModel.sprRoster.FontBold = true;
			ViewModel.sprRoster.SetRowHeight(ViewModel.CurrRow, 15);
			(ViewModel.CurrRow)++;
			ViewModel.sprRoster.Row = ViewModel.CurrRow;
			ViewModel.sprRoster.Col = 1;
			ViewModel.sprRoster.Text = "Personnel Roster";
			ViewModel.sprRoster.FontSize = 12;
			ViewModel.sprRoster.FontBold = true;
			ViewModel.sprRoster.SetRowHeight(ViewModel.CurrRow, 15);
			(ViewModel.CurrRow)++;
			ViewModel.sprRoster.Row = ViewModel.CurrRow;
			ViewModel.sprRoster.Col = 1;
			ViewModel.sprRoster.Text = "Name";
			ViewModel.sprRoster.Col = 2;
			ViewModel.sprRoster.Text = "Rank";
			ViewModel.sprRoster.Col = 3;
			ViewModel.sprRoster.Text = "Emp ID";
			ViewModel.sprRoster.Col = 4;
			ViewModel.sprRoster.Text = "Bat";
			ViewModel.sprRoster.Col = 5;
			ViewModel.sprRoster.Text = "Unit";
			ViewModel.sprRoster.Col = 6;
			ViewModel.sprRoster.Text = "Position";
			ViewModel.sprRoster.Col = 7;
			ViewModel.sprRoster.Text = "Shift";
			ViewModel.sprRoster.Col = 8;
			ViewModel.sprRoster.Text = "Address";
			ViewModel.sprRoster.Col = 9;
			ViewModel.sprRoster.Text = "Home Phone";
			ViewModel.sprRoster.Col = 10;
			ViewModel.sprRoster.Text = "COT Serv Date";
			ViewModel.sprRoster.Col = 11;
			ViewModel.sprRoster.Text = "Benefit";
			ViewModel.sprRoster.BlockMode = true;
			ViewModel.sprRoster.Col = 1;
			ViewModel.sprRoster.Col2 = 11;
			ViewModel.sprRoster.Row = ViewModel.CurrRow;
			ViewModel.sprRoster.Row2 = ViewModel.CurrRow;
			//ViewModel.sprRoster.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			//ViewModel.sprRoster.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprRoster.FontSize = 10;
			ViewModel.sprRoster.BlockMode = false;
			(ViewModel.CurrRow)++;
			ViewModel.PageRow = 4;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboName_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{

			int GoRow = ViewModel.cboName.GetItemData(ViewModel.cboName.SelectedIndex);
			ViewModel.sprRoster.BlockMode = true;
			ViewModel.sprRoster.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprRoster.Row = GoRow;
			ViewModel.sprRoster.Col = 1;
			ViewModel.sprRoster.Row2 = GoRow;
			ViewModel.sprRoster.Col2 = 11;
			ViewModel.sprRoster.BackColor = modGlobal.Shared.PARCHMENT;
			ViewModel.sprRoster.BlockMode = false;
			//ViewModel.sprRoster.Action = (FarPoint.ViewModels.FPActionConstants) 0;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Print Roster
			ViewModel.sprRoster.BlockMode = true;
			ViewModel.sprRoster.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprRoster.BlockMode = false;

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprRoster.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprRoster.setPrintAbortMsg("Printing Personnel Roster - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprRoster.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprRoster.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprRoster.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprRoster.setPrintColor(true);
            //    sprRoster.PrintOrientation = 2
            ViewModel.sprRoster.PrintSheet(null);
			//ViewModel.sprRoster.Action = (FarPoint.ViewModels.FPActionConstants) 32;


		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			//Load Roster form
			//Load Find Employee Listbox
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			StringBuilder AddString = new System.Text.StringBuilder();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spReport_RosterNew";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboName.Items.Clear();
			ViewModel.PageNo = 1;
			ViewModel.CurrRow = 4;
			ViewModel.PageRow = 4;
			ViewModel.sprRoster.Row = 1;
			ViewModel.sprRoster.Col = 8;
			ViewModel.sprRoster.Text = DateTime.Now.ToString("M/d/yyyy HH:mm");
			ViewModel.sprRoster.Col = 10;
			ViewModel.sprRoster.Text = ViewModel.PageNo.ToString();


			while(!oRec.EOF)
			{
				ViewModel.sprRoster.Row = ViewModel.CurrRow;
				ViewModel.sprRoster.Col = 1;
				ViewModel.sprRoster.Text = modGlobal.Clean(oRec["name_full"]);
				ViewModel.cboName.AddItem(modGlobal.Clean(oRec["name_full"]));
				ViewModel.cboName.SetItemData(ViewModel.cboName.GetNewIndex(), ViewModel.CurrRow);
				ViewModel.sprRoster.Col = 2;
				ViewModel.sprRoster.Text = modGlobal.Clean(oRec["rank_code"]);
				ViewModel.sprRoster.Col = 3;
				ViewModel.sprRoster.Text = modGlobal.Clean(oRec["employee_id"]);
				ViewModel.sprRoster.Col = 4;
				ViewModel.sprRoster.Text = modGlobal.Clean(oRec["battalion_code"]);
				ViewModel.sprRoster.Col = 5;
				ViewModel.sprRoster.Text = modGlobal.Clean(oRec["unit_code"]);
				ViewModel.sprRoster.Col = 6;
				ViewModel.sprRoster.Text = modGlobal.Clean(oRec["position_code"]);
				ViewModel.sprRoster.Col = 7;
				ViewModel.sprRoster.Text = modGlobal.Clean(oRec["shift_code"]);
				AddString = new System.Text.StringBuilder(modGlobal.Clean(oRec["address_full"]).Trim());
				AddString.Append(" " + modGlobal.Clean(oRec["city"]).Trim() + ", ");
				AddString.Append(modGlobal.Clean(oRec["state"]) + "  " + modGlobal.Clean(oRec["zip_code"]).Trim());
				ViewModel.sprRoster.Col = 8;
				ViewModel.sprRoster.Text = AddString.ToString();
				ViewModel.sprRoster.Col = 9;
				ViewModel.sprRoster.Text = modGlobal.Clean(oRec["home_phone"]);
				ViewModel.sprRoster.Col = 10;
				System.DateTime TempDate = DateTime.FromOADate(0);
				ViewModel.sprRoster.Text = (DateTime.TryParse(modGlobal.Clean(oRec["COT_hire_date"]), out TempDate)) ? TempDate.ToString("M/d/yyyy") : modGlobal.Clean(oRec["COT_hire_date"]);
				ViewModel.sprRoster.Col = 11;
				ViewModel.sprRoster.Text = modGlobal.Clean(oRec["benefit_program"]);
				oRec.MoveNext();
				(ViewModel.CurrRow)++;
				(ViewModel.PageRow)++;
				if ( ViewModel.PageRow == 45)
				{
					DisplayHeadings();
				}
			};

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmRoster DefInstance
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

		public static frmRoster CreateInstance()
		{
			PTSProject.frmRoster theInstance = Shared.Container.Resolve< frmRoster>();
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
			ViewModel.sprRoster.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprRoster.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmRoster
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmRosterViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmRoster m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}