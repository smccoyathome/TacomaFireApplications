using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class frmAddImmunizations
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmAddImmunizationsViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmAddImmunizations));
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


		private void frmAddImmunizations_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		public void RefreshSelectedStaff()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string ListString = "";

			ViewModel.lstUnitStaff.Items.Clear();
			ViewModel.lstSelectedStaff.Items.Clear();
			ViewModel.lstSelectedStaff.BackColor = modGlobal.Shared.REQUIRED;

			//    'Fill Employee Grid
			string sStringText = "";

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			sStringText = "spSelect_EMSPersonnelGridList ";
			if (modGlobal.Clean(ViewModel.CurrBatt) == "")
			{
				sStringText = sStringText + "NULL, ";
			}
			else
			{
				sStringText = sStringText + "'" + ViewModel.CurrBatt + "', ";
			}
			if (modGlobal.Clean(ViewModel.CurrUnit) == "")
			{
				sStringText = sStringText + "NULL, ";
			}
			else
			{
				sStringText = sStringText + "'" + ViewModel.CurrUnit + "', ";
			}
			if (modGlobal.Clean(ViewModel.CurrShift) == "")
			{
				sStringText = sStringText + "NULL, ";
			}
			else
			{
				sStringText = sStringText + "'" + ViewModel.CurrShift + "', ";
			}
			if (modGlobal.Clean(ViewModel.CurrGroup) == "")
			{
				sStringText = sStringText + "NULL, ";
			}
			else
			{
				sStringText = sStringText + "'" + ViewModel.CurrGroup + "', ";
			}
			sStringText = sStringText + "NULL ";

			oCmd.CommandText = sStringText;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				ListString = modGlobal.Clean(oRec["name_full"]) + " :" + modGlobal.Clean(oRec["employee_id"]);
				ViewModel.lstUnitStaff.AddItem(ListString);
				oRec.MoveNext();
			};
		
		}

		public void LoadLists()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string strName = "";
			PTSProject.clsUnit UnitCL = Container.Resolve< clsUnit>();
			oCmd.Connection = modGlobal.oConn;

			oCmd.CommandType = CommandType.Text;

			//Fill Assignment Type List box
			oCmd.CommandText = "spSelect_AssignmentTypeList ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboAssignmentCode.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboAssignmentCode.AddItem(modGlobal.Clean(oRec["assignment_type_code"]));
				oRec.MoveNext();
			};

			//Fill Unit List box
			ViewModel.cboUnit.Items.Clear();
			oCmd.CommandText = "spUnitList ";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboUnit.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboUnit.AddItem(Convert.ToString(oRec["unit_code"]));
				oRec.MoveNext();
			};

			//Fill Immunization List box
			oCmd.CommandText = "spSelect_EMSImmunizationTypeList ";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboType.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboType.AddItem(Convert.ToString(oRec["immunize_type"]));
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.cboType.SetItemData(ViewModel.cboType.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["immunize_id"])));
				oRec.MoveNext();
			};
			ViewModel.cboType.BackColor = modGlobal.Shared.REQUIRED;

			//Fill All Staff List box
			oCmd.CommandText = "spFullNameList ";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboAllStaff.Items.Clear();

			while(!oRec.EOF)
			{
				strName = Convert.ToString(oRec["name_full"]).Trim() + "  :" + Convert.ToString(oRec["employee_id"]);
				this.ViewModel.cboAllStaff.AddItem(strName);
				oRec.MoveNext();
			};
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboAssignmentCode_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{

			if ( ViewModel.cboAssignmentCode.SelectedIndex == -1)
			{
				return;
			}
			ViewModel.CurrGroup = modGlobal.Clean(ViewModel.cboAssignmentCode.Text);
			ViewModel.CurrBatt = "";
			ViewModel.CurrShift = "";
			ViewModel.CurrUnit = "";
			ViewModel.cboUnit.SelectedIndex = -1;
			ViewModel.cboUnit.Text = "";
			ViewModel.optAll.Checked = false;
			ViewModel.opt181.Checked = false;
			ViewModel.opt182.Checked = false;
			ViewModel.optA.Checked = false;
			ViewModel.optB.Checked = false;
			ViewModel.optC.Checked = false;
			ViewModel.optD.Checked = false;
			RefreshSelectedStaff();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboType.SelectedIndex == -1)
			{
				return;
			}
			ViewModel.cboType.BackColor = modGlobal.Shared.WHITE;
			ViewModel.cmdAddRecord.Enabled = true;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboUnit_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{

			if ( ViewModel.cboUnit.SelectedIndex == -1)
			{
				return;
			}
			ViewModel.CurrUnit = modGlobal.Clean(ViewModel.cboUnit.Text);
			RefreshSelectedStaff();

		}

		[UpgradeHelpers.Events.Handler]
		internal void chkImmuneDate_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.dteShotDate.Visible = ViewModel.chkImmuneDate.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked;
		}

		[UpgradeHelpers.Events.Handler]
		internal void chkResults_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.frmResults.Visible = ViewModel.chkResults.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAdd_Click(Object eventSender, System.EventArgs eventArgs)
		{
			int Index =this.ViewModel.cmdAdd.IndexOf((UpgradeHelpers.BasicViewModels.ButtonViewModel) eventSender);
			//Add selected names to lstSelectedStaff listbox
			string TestString = "";

			switch(Index)
			{
				case 0 :  //Add Selected Employee 
					for (int i = 0; i <= ViewModel.lstUnitStaff.Items.Count - 1; i++)
					{
						if ( ViewModel.lstUnitStaff.GetSelected( i))
						{
							TestString = ViewModel.lstUnitStaff.GetListItem(i);
							ViewModel.lstSelectedStaff.AddItem(TestString);
							ViewModel.lstUnitStaff.RemoveItem(i);
							break;
						}
					}
					break;
				case 1 :  //Add All Employees listed 
					for (int i = 0; i <= ViewModel.lstUnitStaff.Items.Count - 1; i++)
					{
						ViewModel.lstSelectedStaff.AddItem(ViewModel.lstUnitStaff.GetListItem(i));
					}
					ViewModel.lstUnitStaff.Items.Clear();
					break;
				case 2 :  //Add other staff 
					if ( ViewModel.cboAllStaff.SelectedIndex == -1)
					{
						return;
					}
					ViewModel.lstSelectedStaff.AddItem(ViewModel.cboAllStaff.Text);
					ViewModel.cboAllStaff.SelectedIndex = -1;
					break;
			}
			if ( ViewModel.lstSelectedStaff.Items.Count == 0)
			{
				ViewModel.lstSelectedStaff.BackColor = modGlobal.Shared.REQUIRED;
				ViewModel.lstSelectedStaff.ForeColor = modGlobal.Shared.WHITE;
			}
			else
			{
				ViewModel.lstSelectedStaff.BackColor = modGlobal.Shared.WHITE;
				ViewModel.lstSelectedStaff.ForeColor = modGlobal.Shared.BLACK;
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAddRecord_Click(Object eventSender, System.EventArgs eventArgs)
		{
			PTSProject.clsEMSInformation cImmune = Container.Resolve< clsEMSInformation>();

			if ( ViewModel.cboType.SelectedIndex == -1)
			{
				return;
			}
			if ( ViewModel.lstSelectedStaff.Items.Count == 0)
			{
				return;
			}
			ViewModel.cmdAddRecord.Enabled = false;

			//Need to edit and fill fields
			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			cImmune.EMSImmunizeID = Convert.ToInt32(modGlobal.GetVal(ViewModel.cboType.GetItemData(ViewModel.cboType.SelectedIndex)));

			if ( ViewModel.chkImmuneDate.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				cImmune.EMSImmunizeDate = "";
			}
			else
			{
				cImmune.EMSImmunizeDate = DateTime.Parse(ViewModel.dteShotDate.Text).ToString("M/d/yyyy");
			}

			cImmune.EMSCreatedDate = DateTime.Now.ToString("M/d/yyyy HH:mm:ss");
			cImmune.EMSCreatedBy = modGlobal.Shared.gUser;

			if ( ViewModel.chkResults.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				cImmune.EMSResultflag = "";
			}
			else if ( ViewModel.optPositive.Checked)
			{
				cImmune.EMSResultflag = "P";
			}
			else
			{
				cImmune.EMSResultflag = "N";
			}

			cImmune.EMSComments = modGlobal.Clean(ViewModel.txtComments.Text);

			//will need to loop through the lstSelectedStaff
			for (int i = 0; i <= ViewModel.lstSelectedStaff.Items.Count - 1; i++)
			{
				cImmune.EMSEmployeeID = ViewModel.lstSelectedStaff.GetListItem(i).Substring(Math.Max(ViewModel.lstSelectedStaff.GetListItem(i).Length - 5, 0));
				if (~cImmune.InsertEMSPersonnelImmunizations() != 0)
				{
					ViewManager.ShowMessage("Ooops! Something is wrong!!  Immunization Record was not added.", "Add New Immunization Record", UpgradeHelpers.Helpers.BoxButtons.OK);
					ViewModel.cmdAddRecord.Enabled = true;
				}
			}

			ViewModel.lbSaveMsg.Visible = true;
			UpgradeSolution1Support.PInvoke.SafeNative.kernel32.Sleep(1500);
			ViewModel.lbSaveMsg.Visible = false;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClear_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.FirstTime = true;
			ViewModel.lstUnitStaff.Items.Clear();
			ViewModel.lstSelectedStaff.Items.Clear();
			ViewModel.lstSelectedStaff.BackColor = modGlobal.Shared.REQUIRED;
			ViewModel.cboAllStaff.Text = "";
			ViewModel.cboAllStaff.SelectedIndex = -1;
			ViewModel.cboUnit.Text = "";
			ViewModel.cboUnit.SelectedIndex = -1;
			ViewModel.cboAssignmentCode.Text = "";
			ViewModel.cboAssignmentCode.SelectedIndex = -1;
			ViewModel.optAll.Checked = false;
			ViewModel.opt181.Checked = false;
			ViewModel.opt182.Checked = false;
			ViewModel.CurrBatt = "";
			ViewModel.CurrShift = "";
			ViewModel.CurrGroup = "";
			ViewModel.CurrUnit = "";
			ViewModel.optA.Checked = false;
			ViewModel.optB.Checked = false;
			ViewModel.optC.Checked = false;
			ViewModel.optD.Checked = false;
			ViewModel.FirstTime = false;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdNewRecord_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.cboType.Text = "";
			ViewModel.cboType.SelectedIndex = -1;
			ViewModel.cboType.BackColor = modGlobal.Shared.REQUIRED;
			ViewModel.txtComments.Text = "";

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdRemove_Click(Object eventSender, System.EventArgs eventArgs)
		{
			int Index =this.ViewModel.cmdRemove.IndexOf((UpgradeHelpers.BasicViewModels.ButtonViewModel) eventSender);
			//Remove selected names from lstSelectedStaff listbox and add back to lstUnitStaff listbox
			string TestString = "";

			switch(Index)
			{
				case 0 :  //Move Selected Employee 
					for (int i = 0; i <= ViewModel.lstSelectedStaff.Items.Count - 1; i++)
					{
						if ( ViewModel.lstSelectedStaff.GetSelected( i))
						{
							TestString = ViewModel.lstSelectedStaff.GetListItem(i);
							ViewModel.lstUnitStaff.AddItem(TestString);
							ViewModel.lstSelectedStaff.RemoveItem(i);
							break;
						}
					}
					break;
				case 1 :  //Remove All Employees listed 
					for (int i = 0; i <= ViewModel.lstSelectedStaff.Items.Count - 1; i++)
					{
						ViewModel.lstUnitStaff.AddItem(ViewModel.lstSelectedStaff.GetListItem(i));
					}
					ViewModel.lstSelectedStaff.Items.Clear();
					break;
			}
			if ( ViewModel.lstSelectedStaff.Items.Count == 0)
			{
				ViewModel.lstSelectedStaff.BackColor = modGlobal.Shared.REQUIRED;
				ViewModel.lstSelectedStaff.ForeColor = modGlobal.Shared.WHITE;
			}
			else
			{
				ViewModel.lstSelectedStaff.BackColor = modGlobal.Shared.WHITE;
				ViewModel.lstSelectedStaff.ForeColor = modGlobal.Shared.BLACK;
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			ViewModel.txtComments.Text = "";
			LoadLists();

		}

		[UpgradeHelpers.Events.Handler]
		internal void opt181_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.CurrBatt = "1";
				RefreshSelectedStaff();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void opt182_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.CurrBatt = "2";
				RefreshSelectedStaff();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void opt183_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.CurrBatt = "3";
				RefreshSelectedStaff();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optA_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.CurrShift = "A";
				RefreshSelectedStaff();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optAll_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				if ( ViewModel.optAll.Checked)
				{
					ViewModel.CurrBatt = "";
					ViewModel.CurrShift = "";
					ViewModel.CurrUnit = "";
					ViewModel.CurrGroup = "";
					ViewModel.cboUnit.SelectedIndex = -1;
					ViewModel.cboUnit.Text = "";
					ViewModel.cboAssignmentCode.SelectedIndex = -1;
					ViewModel.cboAssignmentCode.Text = "";
					ViewModel.optA.Checked = false;
					ViewModel.optB.Checked = false;
					ViewModel.optC.Checked = false;
					ViewModel.optD.Checked = false;

					RefreshSelectedStaff();
				}
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optB_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.CurrShift = "B";
				RefreshSelectedStaff();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optC_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.CurrShift = "C";
				RefreshSelectedStaff();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optD_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.CurrShift = "D";
				RefreshSelectedStaff();
			}
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmAddImmunizations DefInstance
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

		public static frmAddImmunizations CreateInstance()
		{
			PTSProject.frmAddImmunizations theInstance = Shared.Container.Resolve< frmAddImmunizations>();
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
			ViewModel.frmResults.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.frmResults.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmAddImmunizations
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmAddImmunizationsViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmAddImmunizations m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}