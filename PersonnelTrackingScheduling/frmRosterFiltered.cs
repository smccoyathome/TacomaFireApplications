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

	public partial class frmRosterFiltered
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmRosterFilteredViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmRosterFiltered));
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


		private void frmRosterFiltered_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//************************************
		// Filtered Employee Roster List   ***
		//************************************

		public void GetEmployeeDetail()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ViewModel.sprPhone.Row = 1;
			ViewModel.sprPhone.Row2 = ViewModel.sprPhone.MaxRows;
			ViewModel.sprPhone.Col = 1;
			ViewModel.sprPhone.Col2 = ViewModel.sprPhone.MaxCols;
			ViewModel.sprPhone.BlockMode = true;
			ViewModel.sprPhone.Text = "";
			ViewModel.sprPhone.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprPhone.BlockMode = false;
			ViewModel.sprContact.Row = 1;
			ViewModel.sprContact.Row2 = ViewModel.sprContact.MaxRows;
			ViewModel.sprContact.Col = 1;
			ViewModel.sprContact.Col2 = ViewModel.sprContact.MaxCols;
			ViewModel.sprContact.BlockMode = true;
			ViewModel.sprContact.Text = "";
			ViewModel.sprContact.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprContact.BlockMode = false;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			string strSQL = "spSelect_RosterPhoneListByEmployee " + ViewModel.CurrEmp.ToString();
			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			int iRow = 0;

			while(!oRec.EOF)
			{
				iRow++;
				ViewModel.sprPhone.Row = iRow;
				ViewModel.sprPhone.Col = 1;
				ViewModel.sprPhone.Text = modGlobal.Clean(oRec["phone_type"]);
				ViewModel.sprPhone.Col = 2;
				ViewModel.sprPhone.Text = modGlobal.Clean(oRec["phone_number"]);
				ViewModel.sprPhone.Col = 3;
				ViewModel.sprPhone.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprPhone.Text = modGlobal.Clean(oRec["call_back_flag"]);
				ViewModel.sprPhone.Col = 4;
				ViewModel.sprPhone.Text = modGlobal.Clean(oRec["comment"]);
				ViewModel.sprPhone.Col = 5;
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.sprPhone.Text = Convert.ToString(modGlobal.GetVal(oRec["phone_id"]));

				oRec.MoveNext();
			};

			strSQL = "spSelect_RosterContactListByEmployee " + ViewModel.CurrEmp.ToString();
			oCmd.CommandText = strSQL;
			oRec = ADORecordSetHelper.Open(oCmd, "");

			iRow = 0;

			while(!oRec.EOF)
			{
				iRow++;
				ViewModel.sprContact.Row = iRow;
				ViewModel.sprContact.Col = 1;
				ViewModel.sprContact.Text = modGlobal.Clean(oRec["contact_name"]);
				ViewModel.sprContact.Col = 2;
				ViewModel.sprContact.Text = modGlobal.Clean(oRec["relationship"]);
				ViewModel.sprContact.Col = 3;
				ViewModel.sprContact.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				//UPGRADE_WARNING: (1068) GetVal(oRec(primary_flag)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				if (Convert.ToDouble(modGlobal.GetVal(oRec["primary_flag"])) != 0)
				{
					ViewModel.sprContact.Text = "Y";
				}
				else
				{
					ViewModel.sprContact.Text = "N";
				}
				ViewModel.sprContact.Col = 4;
				ViewModel.sprContact.Text = modGlobal.Clean(oRec["phone_type"]);
				ViewModel.sprContact.Col = 5;
				ViewModel.sprContact.Text = modGlobal.Clean(oRec["phone_number"]);
				ViewModel.sprContact.Col = 6;
				ViewModel.sprContact.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprContact.Text = modGlobal.Clean(oRec["time_of_day"]);
				ViewModel.sprContact.Col = 7;
				ViewModel.sprContact.Text = modGlobal.Clean(oRec["comment"]);
				ViewModel.sprContact.Col = 8;
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.sprContact.Text = Convert.ToString(modGlobal.GetVal(oRec["contact_id"]));

				oRec.MoveNext();
			};



		}

		public void FillLists()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			string strSQL = "spSelect_FilterByRankCode ";
			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboRank.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboRank.AddItem(modGlobal.Clean(oRec["rank_code"]));
				oRec.MoveNext();
			};

			strSQL = "spSelect_FilterByCity ";
			oCmd.CommandText = strSQL;
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboCity.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboCity.AddItem(modGlobal.Clean(oRec["city"]));
				oRec.MoveNext();
			};

			strSQL = "spSelect_FilterByZipCode ";
			oCmd.CommandText = strSQL;
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboZipCode.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboZipCode.AddItem(modGlobal.Clean(oRec["zip_code"]));
				oRec.MoveNext();
			};

			strSQL = "spSelect_FilterByShiftCode ";
			oCmd.CommandText = strSQL;
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboShift.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboShift.AddItem(modGlobal.Clean(oRec["shift_code"]));
				oRec.MoveNext();
			};

			strSQL = "spSelect_FilterByBattCode ";
			oCmd.CommandText = strSQL;
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboBatt.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboBatt.AddItem(modGlobal.Clean(oRec["battalion_code"]));
				oRec.MoveNext();
			};

		}

		public void FillGrid()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string sBatt = "";
			string sShift = "";

			//initialize grid / fields
			ViewModel.sprEmployeeList.MaxRows = 500;
			ViewModel.lbCount.Text = "";
			string sRank = "";
			string sCity = "";
			string sZip = "";

			if ( ViewModel.cboRank.SelectedIndex > -1)
			{
				sRank = modGlobal.Clean(ViewModel.cboRank.Text);
			}

			if ( ViewModel.cboCity.SelectedIndex > -1)
			{
				sCity = modGlobal.Clean(ViewModel.cboCity.Text);
			}

			if ( ViewModel.cboZipCode.SelectedIndex > -1)
			{
				sZip = modGlobal.Clean(ViewModel.cboZipCode.Text);
			}

			if ( ViewModel.cboBatt.SelectedIndex > -1)
			{
				sBatt = modGlobal.Clean(ViewModel.cboBatt.Text);
			}

			if ( ViewModel.cboShift.SelectedIndex > -1)
			{
				sShift = modGlobal.Clean(ViewModel.cboShift.Text);
			}
			ViewModel.cboEmployee.Items.Clear();
			ViewModel.sprEmployeeList.Row = 1;
			ViewModel.sprEmployeeList.Row2 = ViewModel.sprEmployeeList.MaxRows;
			ViewModel.sprEmployeeList.Col = 1;
			ViewModel.sprEmployeeList.Col2 = ViewModel.sprEmployeeList.MaxCols;
			ViewModel.sprEmployeeList.BlockMode = true;
			ViewModel.sprEmployeeList.Text = "";
			ViewModel.sprEmployeeList.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprEmployeeList.BlockMode = false;
			ViewModel.CurrRow = 0;
			ViewModel.CurrEmp = 0;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			string sprString = "spSelect_EmployeeRosterFilteredNew ";

			if (sCity == "")
			{
				sprString = sprString + "NULL, ";
			}
			else
			{
				sprString = sprString + "'" + sCity + "', ";
			}

			if (sZip == "")
			{
				sprString = sprString + "NULL, ";
			}
			else
			{
				sprString = sprString + "'" + sZip + "', ";
			}

			if (sRank == "")
			{
				sprString = sprString + "NULL, ";
			}
			else
			{
				sprString = sprString + "'" + sRank + "', ";
			}

			if (sBatt == "")
			{
				sprString = sprString + "NULL, ";
			}
			else
			{
				sprString = sprString + "'" + sBatt + "', ";
			}

			if (sShift == "")
			{
				sprString = sprString + "NULL ";
			}
			else
			{
				sprString = sprString + "'" + sShift + "' ";
			}

			oCmd.CommandText = sprString;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				(ViewModel.CurrRow)++;
				ViewModel.sprEmployeeList.Row = ViewModel.CurrRow;
				ViewModel.sprEmployeeList.Col = 1;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["name_full"]);
				ViewModel.sprEmployeeList.Col = 2;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["rank_code"]);
				ViewModel.sprEmployeeList.Col = 3;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["EmpID"]);
				ViewModel.sprEmployeeList.Col = 4;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["battalion_code"]);
				ViewModel.sprEmployeeList.Col = 5;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["shift_code"]);
				ViewModel.sprEmployeeList.Col = 6;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["unit_code"]);
				ViewModel.sprEmployeeList.Col = 7;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["position_code"]);
				ViewModel.sprEmployeeList.Col = 8;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["address_full"]);
				ViewModel.sprEmployeeList.Col = 9;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["city"]);
				ViewModel.sprEmployeeList.Col = 10;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["state"]);
				ViewModel.sprEmployeeList.Col = 11;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["zip_code"]);
				ViewModel.sprEmployeeList.Col = 12;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["home_phone"]);
				ViewModel.sprEmployeeList.Col = 13;
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.sprEmployeeList.Text = Convert.ToString(modGlobal.GetVal(oRec["per_sys_id"]));
				if ( ViewModel.CurrRow == 1)
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.CurrEmp = Convert.ToInt32(modGlobal.GetVal(oRec["per_sys_id"]));
				}
				ViewModel.cboEmployee.AddItem(modGlobal.Clean(oRec["name_full"]));
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.cboEmployee.SetItemData(ViewModel.cboEmployee.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["per_sys_id"])));

				oRec.MoveNext();
			};
			ViewModel.sprEmployeeList.MaxRows = ViewModel.CurrRow;
			ViewModel.lbCount.Text = "List Count: " + ViewModel.CurrRow.ToString();
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprEmployeeList.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeList.ClearSelection();
			ViewModel.CurrRow = 1;
			if ( ViewModel.CurrEmp != 0)
			{
				GetEmployeeDetail();
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboBatt_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboBatt.SelectedIndex == -1)
			{
				return;
			}

			FillGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboCity_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{

			if ( ViewModel.cboCity.SelectedIndex == -1)
			{
				return;
			}

			FillGrid();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboEmployee_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{

			if ( ViewModel.cboEmployee.SelectedIndex == -1)
			{
				return;
			}

			//sprEmployeeList.ClearSelection
			ViewModel.sprEmployeeList.Col = 13;
			int tempForVar = ViewModel.sprEmployeeList.MaxRows;
			for (int i = 1; i <= tempForVar; i++)
			{
				ViewModel.sprEmployeeList.Row = i;
				//UPGRADE_WARNING: (1068) GetVal(sprEmployeeList.Text) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				if (Convert.ToDouble(modGlobal.GetVal(ViewModel.sprEmployeeList.Text)) == ViewModel.cboEmployee.GetItemData(ViewModel.cboEmployee.SelectedIndex))
				{
					ViewModel.sprEmployeeList.BlockMode = true;
					ViewModel.sprEmployeeList.Col = 1;
					ViewModel.sprEmployeeList.Col2 = ViewModel.sprEmployeeList.MaxCols;
					ViewModel.sprEmployeeList.Row = i;
					ViewModel.sprEmployeeList.Row2 = i;
					ViewModel.sprEmployeeList.BackColor = modGlobal.Shared.YELLOW;
					ViewModel.sprEmployeeList.BlockMode = false;
					//ViewModel.sprEmployeeList.SetSelection(1, i, ViewModel.sprEmployeeList.MaxCols, i);
					ViewModel.CurrRow = i;
					ViewModel.CurrEmp = ViewModel.cboEmployee.GetItemData(ViewModel.cboEmployee.SelectedIndex);

					GetEmployeeDetail();
					//            sprEmployeeList_Click 1, i
					break;
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboRank_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{

			if ( ViewModel.cboRank.SelectedIndex == -1)
			{
				return;
			}

			FillGrid();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboShift_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboShift.SelectedIndex == -1)
			{
				return;
			}

			FillGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboZipCode_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{

			if ( ViewModel.cboZipCode.SelectedIndex == -1)
			{
				return;
			}

			FillGrid();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClear_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.cboRank.SelectedIndex = -1;
			ViewModel.cboCity.SelectedIndex = -1;
			ViewModel.cboZipCode.SelectedIndex = -1;
			ViewModel.cboBatt.SelectedIndex = -1;
			ViewModel.cboShift.SelectedIndex = -1;

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
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprEmployeeList.PrintFooter was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeList.setPrintFooter("/nPrinted on " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "/r Page /p of /pc");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprEmployeeList.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeList.setPrintAbortMsg("Printing TFD Employee Filtered Roster");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprEmployeeList.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeList.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprEmployeeList.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeList.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprEmployeeList.PrintColHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeList.setPrintColHeaders(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprEmployeeList.PrintSmartPrint was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeList.setPrintSmartPrint(true);

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprEmployeeList.PrintSheet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//object tempRefParam = null;
			//WEBMAP_UPGRADE_ISSUE: (1101) FarPoint.Win.Spread.FpSpread.PrintSheet was not upgraded
			ViewModel.sprEmployeeList.PrintSheet(null);
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			FillLists();
			FillGrid();

		}

		private void sprEmployeeList_CellClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
		{
			int Col = eventArgs.Column;
			int Row = eventArgs.Row;
			if (Row == 0)
			{
				return;
			}
			ViewModel.sprEmployeeList.BlockMode = true;
			ViewModel.sprEmployeeList.Col = 1;
			ViewModel.sprEmployeeList.Col2 = ViewModel.sprEmployeeList.MaxCols;
			ViewModel.sprEmployeeList.Row = ViewModel.CurrRow;
			ViewModel.sprEmployeeList.Row2 = ViewModel.CurrRow;
			ViewModel.sprEmployeeList.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprEmployeeList.BlockMode = false;
			ViewModel.CurrRow = Row;
			ViewModel.sprEmployeeList.Row = ViewModel.CurrRow;
			ViewModel.sprEmployeeList.Col = 13;

			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			ViewModel.CurrEmp = Convert.ToInt32(modGlobal.GetVal(ViewModel.sprEmployeeList.Text));

			GetEmployeeDetail();

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmRosterFiltered DefInstance
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

		public static frmRosterFiltered CreateInstance()
		{
			PTSProject.frmRosterFiltered theInstance = Shared.Container.Resolve< frmRosterFiltered>();
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
			ViewModel.sprEmployeeList.LifeCycleStartup();
			ViewModel.sprContact.LifeCycleStartup();
			ViewModel.sprPhone.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprEmployeeList.LifeCycleShutdown();
			ViewModel.sprContact.LifeCycleShutdown();
			ViewModel.sprPhone.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmRosterFiltered
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmRosterFilteredViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmRosterFiltered m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}