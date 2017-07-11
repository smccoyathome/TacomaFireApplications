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

	public partial class frmMasterPhoneLists
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmMasterPhoneListsViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmMasterPhoneLists));
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


		private void frmMasterPhoneLists_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//************************************
		//***     Master Phone List        ***
		//************************************

		public void FillLists()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			string strSQL = "sp_GetResourceList ";
			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboFFacility.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboFFacility.AddItem(modGlobal.Clean(oRec["resource_name"]));
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.cboFFacility.SetItemData(ViewModel.cboFFacility.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["resourse_id"])));
				oRec.MoveNext();
			};

			strSQL = "spSelect_PhoneTypeList ";
			oCmd.CommandText = strSQL;
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboFType.Items.Clear();
			ViewModel.cboEType.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboFType.AddItem(modGlobal.Clean(oRec["phone_type"]));
				ViewModel.cboEType.AddItem(modGlobal.Clean(oRec["phone_type"]));
				oRec.MoveNext();
			};

			strSQL = "spSelect_TFDFacilityList ";
			oCmd.CommandText = strSQL;
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboEFacility.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboEFacility.AddItem(modGlobal.Clean(oRec["facility_name"]));
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.cboEFacility.SetItemData(ViewModel.cboEFacility.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["facility"])));
				oRec.MoveNext();
			};

			strSQL = "spSelect_TFDUnitList ";
			oCmd.CommandText = strSQL;
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboUnit.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboUnit.AddItem(modGlobal.Clean(oRec["unit_code"]));
				oRec.MoveNext();
			};

			strSQL = "spSelect_AssignmentTypeList ";
			oCmd.CommandText = strSQL;
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboAssignType.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboAssignType.AddItem(modGlobal.Clean(oRec["assignment_type_code"]));
				oRec.MoveNext();
			};

			strSQL = "spSelect_AssignmentGroupList ";
			oCmd.CommandText = strSQL;
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboGroup.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboGroup.AddItem(modGlobal.Clean(oRec["group_code"]));
				oRec.MoveNext();
			};


		}

		public void FillFacilityGrid()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ViewModel.sprResource.MaxRows = 5000;
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprResource.ClearRange was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprResource.ClearRange(1, 1, ViewModel.sprResource.MaxCols, ViewModel.sprResource.MaxRows, true);

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			string strSQL = "spSelect_MasterFacilityPhoneList ";

			if ( ViewModel.cboFFacility.SelectedIndex == -1)
			{
				strSQL = strSQL + "NULL, ";
			}
			else
			{
				strSQL = strSQL + ViewModel.cboFFacility.GetItemData(ViewModel.cboFFacility.SelectedIndex).ToString() + ", ";
			}

			if (modGlobal.Clean(ViewModel.cboFType.Text) == "")
			{
				strSQL = strSQL + "NULL ";
			}
			else
			{
				strSQL = strSQL + "'" + modGlobal.Clean(ViewModel.cboFType.Text) + "' ";
			}

			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			int iRow = 0;

			while(!oRec.EOF)
			{
				iRow++;
				ViewModel.sprResource.Row = iRow;

				//Name
				ViewModel.sprResource.Col = 1;
				ViewModel.sprResource.Text = modGlobal.Clean(oRec["facility_name"]);

				//Type
				ViewModel.sprResource.Col = 2;
				ViewModel.sprResource.Text = modGlobal.Clean(oRec["phone_type"]);

				//Number
				ViewModel.sprResource.Col = 3;
				ViewModel.sprResource.Text = modGlobal.Clean(oRec["phone_number"]);

				//Comments
				ViewModel.sprResource.Col = 4;
				ViewModel.sprResource.Text = modGlobal.Clean(oRec["comment"]);

				//PhoneID
				ViewModel.sprResource.Col = 5;
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.sprResource.Text = Convert.ToString(modGlobal.GetVal(oRec["phone_id"]));

				//FacilityID
				ViewModel.sprResource.Col = 6;
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.sprResource.Text = Convert.ToString(modGlobal.GetVal(oRec["facility_id"]));

				oRec.MoveNext();
			};
			ViewModel.lbFacilityCount.Text = "Total Rows = " + iRow.ToString();


		}

		public void FillEmployeeGrid()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ViewModel.sprEmployeeList.MaxRows = 5000;
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprEmployeeList.ClearRange was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeList.ClearRange(1, 1, ViewModel.sprEmployeeList.MaxCols, ViewModel.sprEmployeeList.MaxRows, true);

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			string strSQL = "spSelect_MasterEmployeePhoneList ";

			if ( ViewModel.cboEFacility.SelectedIndex < 0)
			{
				strSQL = strSQL + "NULL, ";
			}
			else
			{
				strSQL = strSQL + ViewModel.cboEFacility.GetItemData(ViewModel.cboEFacility.SelectedIndex).ToString() + ", ";
			}

			if (modGlobal.Clean(ViewModel.cboAssignType.Text) == "")
			{
				strSQL = strSQL + "NULL, ";
			}
			else
			{
				strSQL = strSQL + "'" + modGlobal.Clean(ViewModel.cboAssignType.Text) + "', ";
			}


			if (modGlobal.Clean(ViewModel.cboGroup.Text) == "")
			{
				strSQL = strSQL + "NULL, ";
			}
			else
			{
				strSQL = strSQL + "'" + modGlobal.Clean(ViewModel.cboGroup.Text) + "', ";
			}

			if (modGlobal.Clean(ViewModel.cboUnit.Text) == "")
			{
				strSQL = strSQL + "NULL, ";
			}
			else
			{
				strSQL = strSQL + "'" + modGlobal.Clean(ViewModel.cboUnit.Text) + "', ";
			}

			if (modGlobal.Clean(ViewModel.cboEType.Text) == "")
			{
				strSQL = strSQL + "NULL, ";
			}
			else
			{
				strSQL = strSQL + "'" + modGlobal.Clean(ViewModel.cboEType.Text) + "', ";
			}

			if ( ViewModel.chkCBOnly.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				strSQL = strSQL + "'Y' ";
			}
			else
			{
				strSQL = strSQL + "NULL ";
			}

			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			int iRow = 0;

			while(!oRec.EOF)
			{
				iRow++;
				ViewModel.sprEmployeeList.Row = iRow;

				//Name
				ViewModel.sprEmployeeList.Col = 1;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["name_full"]);

				//Facility
				ViewModel.sprEmployeeList.Col = 2;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["facility_name"]);
				ViewModel.sprEmployeeList.Col = 3;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["unit_code"]);
				ViewModel.sprEmployeeList.Col = 4;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["position_code"]);
				ViewModel.sprEmployeeList.Col = 5;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["shift_code"]);
				ViewModel.sprEmployeeList.Col = 6;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["assignment_type_code"]);
				ViewModel.sprEmployeeList.Col = 7;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["group_code"]);
				ViewModel.sprEmployeeList.Col = 8;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["phone_type"]);
				ViewModel.sprEmployeeList.Col = 9;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["phone_number"]);
				ViewModel.sprEmployeeList.Col = 10;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["comment"]);
				ViewModel.sprEmployeeList.Col = 11;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["call_back_flag"]);
				ViewModel.sprEmployeeList.Col = 12;
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.sprEmployeeList.Text = Convert.ToString(modGlobal.GetVal(oRec["phone_id"]));
				ViewModel.sprEmployeeList.Col = 13;
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.sprEmployeeList.Text = Convert.ToString(modGlobal.GetVal(oRec["per_sys_id"]));

				oRec.MoveNext();
			};
			ViewModel.lbEmployeeCount.Text = "Total Rows = " + iRow.ToString();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboAssignType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboAssignType.SelectedIndex == -1)
			{
				return;
			}

			FillEmployeeGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboEFacility_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboEFacility.SelectedIndex == -1)
			{
				return;
			}

			FillEmployeeGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboEType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboEType.SelectedIndex == -1)
			{
				return;
			}

			FillEmployeeGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboFFacility_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboFFacility.SelectedIndex == -1)
			{
				return;
			}

			FillFacilityGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboFType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboFType.SelectedIndex == -1)
			{
				return;
			}

			FillFacilityGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboGroup_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboGroup.SelectedIndex == -1)
			{
				return;
			}
			FillEmployeeGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboUnit_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboUnit.SelectedIndex == -1)
			{
				return;
			}

			FillEmployeeGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void chkCBOnly_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			FillEmployeeGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClearEmployee_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.cboEFacility.SelectedIndex = -1;
			ViewModel.cboEType.SelectedIndex = -1;
			ViewModel.cboAssignType.SelectedIndex = -1;
			ViewModel.cboGroup.SelectedIndex = -1;
			ViewModel.cboUnit.SelectedIndex = -1;
			ViewModel.chkCBOnly.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;

			FillEmployeeGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClearFacility_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.cboFFacility.SelectedIndex = -1;
			ViewModel.cboFType.SelectedIndex = -1;

			FillFacilityGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrintEmployee_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprEmployeeList.PrintFooter was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeList.setPrintFooter("/nPrinted on " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "/r Page /p of /pc");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprEmployeeList.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeList.setPrintAbortMsg("Printing TFD Employee Phone List");
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

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrintFacility_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprResource.PrintFooter was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprResource.setPrintFooter("/nPrinted on " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "/r Page /p of /pc");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprResource.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprResource.setPrintAbortMsg("Printing TFD Facility Phone List");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprResource.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprResource.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprResource.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprResource.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprResource.PrintColHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprResource.setPrintColHeaders(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprResource.PrintSmartPrint was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprResource.setPrintSmartPrint(true);

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprResource.PrintSheet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//object tempRefParam = null;
			//WEBMAP_UPGRADE_ISSUE: (1101) FarPoint.Win.Spread.FpSpread.PrintSheet was not upgraded
			ViewModel.sprResource.PrintSheet(null);
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			ViewModel.frmEmployee.Visible = true;
			ViewModel.frmResource.Visible = false;

			FillLists();
			FillEmployeeGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void optList_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				int Index =this.ViewModel.optList.IndexOf((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender);
				if (Index == 0)
				{
					ViewModel.frmEmployee.Visible = false;
					ViewModel.frmResource.Visible = true;

					FillFacilityGrid();
				}
				else
				{
					ViewModel.frmEmployee.Visible = true;
					ViewModel.frmResource.Visible = false;

					FillEmployeeGrid();
				}
			}
		}

		//UPGRADE_NOTE: (7001) The following declaration (smdClearFacility_Click) seems to be dead code More Information: http://www.vbtonet.com/ewis/ewi7001.aspx
		//private void smdClearFacility_Click()
		//{
			//
		//}
		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmMasterPhoneLists DefInstance
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

		public static frmMasterPhoneLists CreateInstance()
		{
			PTSProject.frmMasterPhoneLists theInstance = Shared.Container.Resolve< frmMasterPhoneLists>();
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
			ViewModel.frmEmployee.LifeCycleStartup();
			ViewModel.sprEmployeeList.LifeCycleStartup();
			ViewModel.frmResource.LifeCycleStartup();
			ViewModel.sprResource.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.frmEmployee.LifeCycleShutdown();
			ViewModel.sprEmployeeList.LifeCycleShutdown();
			ViewModel.frmResource.LifeCycleShutdown();
			ViewModel.sprResource.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmMasterPhoneLists
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmMasterPhoneListsViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmMasterPhoneLists m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}