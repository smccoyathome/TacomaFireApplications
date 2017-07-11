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

	public partial class frmUniformRepairHistory
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmUniformRepairHistoryViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmUniformRepairHistory));
			if ( Shared.m_vb6FormDefInstance == null )
			{
				if ( Shared.m_InitializingDefInstance )
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
			ReLoadForm(false);
		}


		private void frmUniformRepairHistory_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender )
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>)eventSender;
			}
		}

		public void EditRepairRecord()
		{
			PTSProject.clsUniform UniformCL = Container.Resolve<clsUniform>();
			int RecordID = 0;

			if ( modGlobal.Clean(ViewModel.lbRepairID.Text) == "" )
			{
				RecordID = 0;
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				UniformCL.UniformRepairUniformID = Convert.ToInt32(modGlobal.GetVal(ViewModel.lbUniformID.Text));
			}
			else
			{
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				RecordID = Convert.ToInt32(modGlobal.GetVal(ViewModel.lbRepairID.Text));
				if ( UniformCL.GetUniformRepairByID(RecordID) != 0 )
				{
				//continue...
				}
				else
				{
					ViewManager.ShowMessage("Ooooops!  The UniformRepair record could not be found!", "Error Could not find Record for Update", UpgradeHelpers.Helpers.BoxButtons.OK);
					return ;
				}
			}

			//edit the rest of the fields
			if ( ViewModel.chkDateIn.CheckState == UpgradeHelpers.Helpers.CheckState.Checked )
			{
				UniformCL.UniformRepairDateIn = DateTime.Parse(ViewModel.dteDateIn.Text).ToString("M/d/yyyy");
			}
			else
			{
				UniformCL.UniformRepairDateIn = "";
			}

			if ( ViewModel.chkDateOut.CheckState == UpgradeHelpers.Helpers.CheckState.Checked )
			{
				UniformCL.UniformRepairDateOut = DateTime.Parse(ViewModel.dteDateOut.Text).ToString("M/d/yyyy");
			}
			else
			{
				UniformCL.UniformRepairDateOut = "";
			}

			UniformCL.UniformRepairComment = modGlobal.Clean(ViewModel.txtComment.Text);

			if ( ViewModel.cboRepairer.SelectedIndex == -1 )
			{
				UniformCL.UniformRepairerID = 0;
			}
			else
			{
				UniformCL.UniformRepairerID = ViewModel.cboRepairer.GetItemData(ViewModel.cboRepairer.SelectedIndex);
			}

			if ( RecordID == 0 )
			{ //Add
				if ( UniformCL.InsertUniformRepair() != 0 )
				{
					RecordID = UniformCL.UniformRepairID;
				}
				else
				{
					ViewManager.ShowMessage("Oooops!  Something went wrong when trying to Insert Repair Record!", "Error Inserting UniformRepair", UpgradeHelpers.Helpers.BoxButtons.OK);
				}
			}
			else
			{
				//Update
				if ( UniformCL.UpdateUniformRepair() != 0 )
				{

				}
				else
				{
					ViewManager.ShowMessage("Oooops!  Something went wrong when trying to Update Repair Record!", "Error Updating UniformRepair", UpgradeHelpers.Helpers.BoxButtons.OK);
				}
			}

			if ( !ViewModel.LaundryRecordExists )
			{
				if ( ViewModel.chkVendor.CheckState == UpgradeHelpers.Helpers.CheckState.Checked )
				{
					//proceed
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					UniformCL.UniformLaunderUniformID = Convert.ToInt32(modGlobal.GetVal(ViewModel.lbUniformID.Text));
					//default dates to now
					UniformCL.UniformLaunderDateFlagged = DateTime.Now.ToString("M/d/yyyy HH:mm:ss");
					UniformCL.UniformLaunderDateApproved = DateTime.Now.ToString("M/d/yyyy HH:mm:ss");
					UniformCL.UniformLaunderDateCleaned = DateTime.Now.ToString("M/d/yyyy HH:mm:ss");

					//default flagged by to current user
					UniformCL.UniformLaunderFlaggedBy = modGlobal.Shared.gUser;
					UniformCL.UniformLaunderApprovedBy = modGlobal.Shared.gUser;
					UniformCL.UniformLaunderCleanedBy = "";
					UniformCL.UniformLaunderVendorCleaned = "Y";

					UniformCL.UniformLaunderComment = "Item was IN for cleaning ON: " + UniformCL.UniformRepairDateIn + "; ";
					UniformCL.UniformLaunderComment = UniformCL.UniformLaunderComment + " OUT ON: " + UniformCL.UniformRepairDateOut + "; ";

					UniformCL.UniformLaunderCleaningComments = "Item was cleaned by Vendor while in for repairs.";

					if ( UniformCL.InsertUniformLaunderInfo() != 0 )
					{
						if ( UniformCL.InsertUniformRepairLaunderInfo() != 0 )
						{
						//success
						}
						else
						{
							ViewManager.ShowMessage("Oooops!  Something went wrong when trying to Insert UniformRepairLaunderInfo.  Call Debra Lewandowsky x5068."
								, "Insert UniformRepairLaunderInfo Record", UpgradeHelpers.Helpers.BoxButtons.OK);
						}
					}
					else
					{
						ViewManager.ShowMessage("Oooops!  Something went wrong when trying to Insert UniformLaunderInfo.  Call Debra Lewandowsky x5068.", "Insert UniformLaunderInfo Record"
							, UpgradeHelpers.Helpers.BoxButtons.OK);
					}
				}
			}

		}

		public void ClearDetail()
		{
			ViewModel.dteDateIn.Text = DateTime.Now.ToString("MM/dd/yyyy");
			ViewModel.dteDateOut.Text = DateTime.Now.ToString("MM/dd/yyyy");
			ViewModel.dteDateIn.Visible = false;
			ViewModel.dteDateOut.Visible = false;
			ViewModel.chkDateIn.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.chkDateOut.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.cboRepairer.SelectedIndex = -1;
			ViewModel.cboRepairer.Text = "";
			ViewModel.chkVendor.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.chkVendor.Enabled = true;
			ViewModel.LaundryRecordExists = false;
			ViewModel.txtComment.Text = "";
			ViewModel.lbRepairID.Text = "";

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprRepairGrid.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprRepairGrid.ClearSelection();

		}

		public void FillRepairGrid()
		{
			PTSProject.clsUniform UniformCL = Container.Resolve<clsUniform>();

			if ( UniformCL.GetPPERepairHistoryByItem(modGlobal.Shared.gUniformID) != 0 )
			{
			//continue
			}
			else
			{
				ViewManager.ShowMessage("This Item has no Repair History.", "Uniform Repair History", UpgradeHelpers.Helpers.BoxButtons.OK);
				return ;
			}

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprRepairGrid.ClearRange was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprRepairGrid.ClearRange(1, 1, ViewModel.sprRepairGrid.MaxCols, ViewModel.sprRepairGrid.MaxRows, false);
			ViewModel.iCurrRow = 0;


			while ( !UniformCL.UniformRepair.EOF )
			{
				(ViewModel.iCurrRow)++;
				ViewModel.sprRepairGrid.Row = ViewModel.iCurrRow;
				ViewModel.sprRepairGrid.Col = 1;
				if ( modGlobal.Clean(UniformCL.UniformRepair["date_in"]) == "" )
				{
					ViewModel.sprRepairGrid.Text = "";
				}
				else
				{
					ViewModel.sprRepairGrid.Text = Convert.ToDateTime(UniformCL.UniformRepair["date_in"]).ToString("M/d/yyyy");
				}
				ViewModel.sprRepairGrid.Col = 2;
				if ( modGlobal.Clean(UniformCL.UniformRepair["date_out"]) == "" )
				{
					ViewModel.sprRepairGrid.Text = "";
				}
				else
				{
					ViewModel.sprRepairGrid.Text = Convert.ToDateTime(UniformCL.UniformRepair["date_out"]).ToString("M/d/yyyy");
				}
				ViewModel.sprRepairGrid.Col = 3;
				ViewModel.sprRepairGrid.Text = modGlobal.Clean(UniformCL.UniformRepair["repairer_name"]);
				ViewModel.sprRepairGrid.Col = 4;
				ViewModel.sprRepairGrid.Text = modGlobal.Clean(UniformCL.UniformRepair["comment"]);
				ViewModel.sprRepairGrid.Col = 5;
				ViewModel.sprRepairGrid.CellType = FarPoint.ViewModels.Cells.FpCellType.CellTypeCheckBox;
				ViewModel.sprRepairGrid.TypeCheckCenter = true;
				if ( modGlobal.Clean(UniformCL.UniformRepair["launder_id"]) == "" )
				{
					ViewModel.sprRepairGrid.Value = 0;
				}
				else
				{
					ViewModel.sprRepairGrid.Value = 1;
				}
				ViewModel.sprRepairGrid.Col = 6;
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.sprRepairGrid.Text = Convert.ToString(modGlobal.GetVal(UniformCL.UniformRepair["repair_id"]));

				UniformCL.UniformRepair.MoveNext();
			}
			;

		}

		public void GetUniformDetail()
		{
			PTSProject.clsUniform UniformCL = Container.Resolve<clsUniform>();

			if ( UniformCL.GetUniformDetailByID(modGlobal.Shared.gUniformID) != 0 )
			{
			//continue
			}
			else
			{
				ViewManager.ShowMessage("Oooops! Can't find any Uniform Information based on ID = " + modGlobal.Shared.gUniformID
					.ToString() + "!  Call Debra Lewandowsky x5068.", "Uniform Repair History", UpgradeHelpers.Helpers.BoxButtons.OK);
			}
			ViewModel.lbItem.Text = modGlobal.Clean(UniformCL.Uniform["Item"]);
			ViewModel.lbTrackingNumber.Text = modGlobal.Clean(UniformCL.Uniform["tracking_number"]);
			ViewModel.lbRetiredReason.Text = modGlobal.Clean(UniformCL.Uniform["reason_description"]);

			if ( modGlobal.Clean(UniformCL.Uniform["retired_date"]) != "" )
			{
				ViewModel.lbRetiredDate.Text = Convert.ToDateTime(UniformCL.Uniform["retired_date"]).ToString("M/d/yyyy");
			}
			else
			{
				ViewModel.lbRetiredDate.Text = "";
			}

			if ( modGlobal.Clean(UniformCL.Uniform["InspDate"]) != "" )
			{
				ViewModel.lbLastInspDate.Text = Convert.ToDateTime(UniformCL.Uniform["InspDate"]).ToString("M/d/yyyy");
			}
			else
			{
				ViewModel.lbLastInspDate.Text = "";
			}
			ViewModel.lbBrand.Text = modGlobal.Clean(UniformCL.Uniform["manufacturer_name"]);

			if ( modGlobal.Clean(UniformCL.Uniform["manufactured_date"]) != "" )
			{
				ViewModel.lbManufDate.Text = Convert.ToDateTime(UniformCL.Uniform["manufactured_date"]).ToString("M/d/yyyy");
			}
			else
			{
				ViewModel.lbManufDate.Text = "";
			}

			if ( modGlobal.Clean(UniformCL.Uniform["ItemSize"]) != "" )
			{
				ViewModel.lbColorSize.Text = modGlobal.Clean(UniformCL.Uniform["ItemSize"]);
			}
			else if ( modGlobal.Clean(UniformCL.Uniform["ItemColor"]) != "" )
			{
				ViewModel.lbColorSize.Text = modGlobal.Clean(UniformCL.Uniform["ItemColor"]);
			}
			else
			{
				ViewModel.lbColorSize.Text = "";
			}

			if ( modGlobal.Clean(UniformCL.Uniform["name_full"]) != "" )
			{
				ViewModel.lbLocation.Text = "Issued to " + modGlobal.Clean(UniformCL.Uniform["name_full"]);
			}
			else if ( modGlobal.Clean(UniformCL.Uniform["station"]) != "" )
			{
				ViewModel.lbLocation.Text = "Station " + modGlobal.Clean(UniformCL.Uniform["station"]);
			}
			else
			{
				ViewModel.lbLocation.Text = "";
			}

			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			ViewModel.lbUniformID.Text = Convert.ToString(modGlobal.GetVal(UniformCL.Uniform["uniform_id"]));
			modGlobal.Shared.gUniformID = Convert.ToInt32(Double.Parse(ViewModel.lbUniformID.Text));

			FillRepairGrid();

		}

		[UpgradeHelpers.Events.Handler]
		internal void chkDateIn_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{

			if ( ViewModel.chkDateIn.CheckState == UpgradeHelpers.Helpers.CheckState.Checked )
			{
				ViewModel.dteDateIn.Text = DateTime.Now.ToString("MM/dd/yyyy");
				ViewModel.dteDateIn.Visible = true;
				ViewModel.cmdEdit.Enabled = true;
			}
			else
			{
				ViewModel.dteDateIn.Visible = false;
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void chkDateOut_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{

			if ( ViewModel.chkDateOut.CheckState == UpgradeHelpers.Helpers.CheckState.Checked )
			{
				ViewModel.dteDateOut.Text = DateTime.Now.ToString("MM/dd/yyyy");
				ViewModel.dteDateOut.Visible = true;
				ViewModel.cmdEdit.Enabled = true;
			}
			else
			{
				ViewModel.dteDateOut.Visible = false;
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdEdit_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This feature is under construction.", vbOKOnly, "Add/Updating Repair Record"

			if ( modGlobal.Clean(ViewModel.lbUniformID.Text) == "" )
			{
				return ;
			}
			ViewModel.cmdEdit.Enabled = false;

			//Edit Fields and Add/Update Record
			EditRepairRecord();

			FillRepairGrid();

			cmdNewItem_Click(ViewModel.cmdNewItem, new System.EventArgs());

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdFind_Click(Object eventSender, System.EventArgs eventArgs)
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			if ( modGlobal.Clean(ViewModel.txtTrackingNumber.Text) == "" )
			{
				return ;
			}

			ClearDetail();
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprRepairGrid.ClearRange was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprRepairGrid.ClearRange(1, 1, ViewModel.sprRepairGrid.MaxCols, ViewModel.sprRepairGrid.MaxRows, false);
			ViewModel.iCurrRow = 0;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			string strSQL = "spSelect_UniformByTrackingNumber '" + modGlobal.Clean(ViewModel.txtTrackingNumber.Text) + "' ";
			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if ( oRec.EOF )
			{
				ViewManager.ShowMessage("Item could not be found.", "Search on Tracking/Barcode Number", UpgradeHelpers.Helpers.BoxButtons.OK);
				return ;
			}

			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			ViewModel.lbUniformID.Text = Convert.ToString(modGlobal.GetVal(oRec["uniform_id"]));
			modGlobal.Shared.gUniformID = Convert.ToInt32(Double.Parse(ViewModel.lbUniformID.Text));

			GetUniformDetail();


		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdNewItem_Click(Object eventSender, System.EventArgs eventArgs)
		{

			ClearDetail();
			ViewModel.cmdEdit.Text = "Add";
			ViewModel.cmdEdit.Enabled = false;
			ViewModel.cmdEdit.Tag = "1";

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ViewModel.cboRepairer.Items.Clear();
			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			string strSQL = "spSelect_UniformRepairerList ";
			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");


			while ( !oRec.EOF )
			{
				ViewModel.cboRepairer.AddItem(modGlobal.Clean(oRec["repairer_name"]));
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.cboRepairer.SetItemData(ViewModel.cboRepairer.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["repairer_id"])));

				oRec.MoveNext();
			};
			ViewModel.txtTrackingNumber.Text = "";
			GetUniformDetail();

			ClearDetail();
			ViewModel.cmdEdit.Text = "Add";
			ViewModel.cmdEdit.Enabled = false;
			ViewModel.cmdEdit.Tag = "1";

		}

		private void sprRepairGrid_CellClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
		{
			int Col = eventArgs.Column;
			int Row = eventArgs.Row;
			PTSProject.clsUniform UniformCL = Container.Resolve<clsUniform>();

			if ( Row == 0 )
			{
				return ;
			}
			ViewModel.iCurrRow = Row;
			ViewModel.sprRepairGrid.Row = ViewModel.iCurrRow;
			//ViewModel.sprRepairGrid.SetSelection(1, ViewModel.iCurrRow, ViewModel.sprRepairGrid.MaxCols, ViewModel.iCurrRow);
			ViewModel.sprRepairGrid.Col = 6;
			if ( modGlobal.Clean(ViewModel.sprRepairGrid.Text) == "" )
			{
				return ;
			}
			else
			{
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.lbRepairID.Text = Convert.ToString(modGlobal.GetVal(ViewModel.sprRepairGrid.Text));
			}

			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			if ( UniformCL.GetUniformRepairByID(Convert.ToInt32(modGlobal.GetVal(ViewModel.lbRepairID.Text))) != 0 )
			{
			//continue
			}
			else
			{
				ViewManager.ShowMessage("Oooops! No Uniform Repair Record was found!", "Get Repair Record", UpgradeHelpers.Helpers.BoxButtons.OK);
				return ;
			}
			ViewModel.lbRepairID.Text = UniformCL.UniformRepairID.ToString();

			if ( UniformCL.UniformRepairDateIn == "" )
			{
				ViewModel.dteDateIn.Visible = false;
				ViewModel.chkDateIn.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			}
			else
			{
				ViewModel.chkDateIn.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
				ViewModel.dteDateIn.Visible = true;
				ViewModel.dteDateIn.Text = UniformCL.UniformRepairDateIn;
			}

			if ( UniformCL.UniformRepairDateOut == "" )
			{
				ViewModel.dteDateOut.Visible = false;
				ViewModel.chkDateOut.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			}
			else
			{
				ViewModel.chkDateOut.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
				ViewModel.dteDateOut.Visible = true;
				ViewModel.dteDateOut.Text = UniformCL.UniformRepairDateOut;
			}

			for ( int i = 0; i <= ViewModel.cboRepairer.Items.Count - 1; i++ )
			{
				if ( ViewModel.cboRepairer.GetItemData(i) == UniformCL.UniformRepairerID )
				{
					ViewModel.cboRepairer.SelectedIndex = i;
					break;
				}
			}
			ViewModel.txtComment.Text = UniformCL.UniformRepairComment;

			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			if ( UniformCL.GetUniformRepairLaunderInfoByID(Convert.ToInt32(modGlobal.GetVal(ViewModel.lbRepairID.Text))) != 0 )
			{
				ViewModel.chkVendor.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
				ViewModel.chkVendor.Enabled = false;
				ViewModel.LaundryRecordExists = true;
			}
			else
			{
				ViewModel.chkVendor.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
				ViewModel.chkVendor.Enabled = true;
				ViewModel.LaundryRecordExists = false;
			}
			ViewModel.cmdEdit.Text = "Update";
			ViewModel.cmdEdit.Tag = "0";
			ViewModel.cmdEdit.Enabled = true;

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmUniformRepairHistory DefInstance
		{
			get
			{
				if ( Shared.m_vb6FormDefInstance == null )
				{
					Shared.
						m_InitializingDefInstance = true;
					Shared.
						m_vb6FormDefInstance = CreateInstance();
					Shared.
						m_InitializingDefInstance = false;
				}
				return Shared.m_vb6FormDefInstance;
			}
			set
			{
				Shared.
					m_vb6FormDefInstance = value;
			}
		}

		public static frmUniformRepairHistory CreateInstance()
		{
			PTSProject.frmUniformRepairHistory theInstance = Shared.Container.Resolve<frmUniformRepairHistory>();
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
			ViewModel.sprRepairGrid.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprRepairGrid.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmUniformRepairHistory
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmUniformRepairHistoryViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmUniformRepairHistory m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}