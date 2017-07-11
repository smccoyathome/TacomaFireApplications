using Microsoft.VisualBasic;
using System;
using UpgradeHelpers.DB.ADO;
using UpgradeStubs;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class frmPMCertification
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmPMCertificationViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmPMCertification));
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


		private void frmPMCertification_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//*******************************************
		//*** Paramedic Certification Information ***
		//*******************************************

		clsTraining clCerts
		{
			get
			{
				if ( ViewModel._clCerts == null)
				{
					ViewModel._clCerts = Container.Resolve< clsTraining>();
				}
				return ViewModel._clCerts;
			}
			set
			{
				ViewModel._clCerts = value;
			}
		}

		public void SaveRecertificationInfo()
		{

			clCerts.PMRecertPerSysID = ViewModel.CurrPersID;
			clCerts.PMRecertLastUpdateBy = modGlobal.Shared.gUser;
			clCerts.PMRecertLastUpdated = DateTime.Now.ToString("M/d/yyyy HH:mm:ss");
			for (int i = 0; i <= 3; i++)
			{
				if ( ViewModel.optGroup[i].Checked)
				{
					clCerts.PMRecertGroupNumber = i;
				}
			}

			if (modGlobal.Clean(ViewModel.txtExpireDate.Text) != "")
			{
				if (!Information.IsDate(ViewModel.txtExpireDate.Text))
				{
					ViewManager.ShowMessage("Please enter a valid Recertification Date.", "Save Recertification Info", UpgradeHelpers.Helpers.BoxButtons.OK);
					return;
				}
				else
				{
					clCerts.PMRecertDate = DateTime.Parse(ViewModel.txtExpireDate.Text).ToString("M/d/yyyy");
				}
			}
			else
			{
				ViewManager.ShowMessage("Please enter an Recertification Date.", "Save Recertification Info", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			clCerts.PMRecertNRNumber = modGlobal.Clean(ViewModel.txtNRNumber.Text);
			clCerts.PMRecertStateNumber = modGlobal.Clean(ViewModel.txtStateNumber.Text);
			clCerts.PMRecertCountyNumber = modGlobal.Clean(ViewModel.txtCountyNumber.Text);

			if ( ViewModel.RecordExists)
			{
				if (clCerts.UpdateParamedicRecertificationInfo() != 0)
				{
					ViewManager.ShowMessage("The Paramedic Recertification Info was successfully added.", "Save Recertification Info", UpgradeHelpers.Helpers.BoxButtons.OK);
				}
				else
				{
					ViewManager.ShowMessage("Oooops! Something went wrong when trying to ADD record.", "Save Recertification Info", UpgradeHelpers.Helpers.BoxButtons.OK);
				}
			}
			else
			{
				if (clCerts.AddParamedicRecertificationInfo() != 0)
				{
					ViewManager.ShowMessage("The Paramedic Recertification Info was successfully updated.", "Save Recertification Info", UpgradeHelpers.Helpers.BoxButtons.OK);
					return;
				}
				else
				{
					ViewManager.ShowMessage("Oooops! Something went wrong when trying to UPDATE record.", "Save Recertification Info", UpgradeHelpers.Helpers.BoxButtons.OK);
					return;
				}
			}
			ViewModel.cmdDone.Enabled = false;

		}

		public void GetEmployeeInfo()
		{
			ViewModel.FirstTime = true;
			ClearFields();
			ViewModel.RecordExists = false;

			if (clCerts.GetParamedicRecertificationInfo(ViewModel.CurrPersID) != 0)
			{
				ViewModel.CurrPersID = clCerts.PMRecertPerSysID;
				ViewModel.txtExpireDate.Text = clCerts.PMRecertDate;
				ViewModel.txtNRNumber.Text = clCerts.PMRecertNRNumber;
				ViewModel.txtStateNumber.Text = clCerts.PMRecertStateNumber;
				ViewModel.txtCountyNumber.Text = clCerts.PMRecertCountyNumber;

				for (int i = 0; i <= 3; i++)
				{
					if (i == clCerts.PMRecertGroupNumber)
					{
						ViewModel.optGroup[i].Checked = true;
					}
				}

				if (clCerts.WorkAsMedicFlag == "Yes")
				{
					ViewModel.chkMedicFlag.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
				}
				else
				{
					ViewModel.chkMedicFlag.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
				}
				ViewModel.cmdDone.Enabled = true;
				ViewModel.RecordExists = true;
			}
			ViewModel.FirstTime = false;
		}

		public void ClearFields()
		{
			ViewModel.txtExpireDate.Text = "";
			ViewModel.txtNRNumber.Text = "";
			ViewModel.txtStateNumber.Text = "";
			ViewModel.txtCountyNumber.Text = "";
			ViewModel.optGroup[0].Checked = true;
			ViewModel.chkMedicFlag.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.cmdDone.Enabled = false;

		}

		public void RefreshEmployeeGrid()
		{
			PTSProject.clsTraining clEmployee = Container.Resolve< clsTraining>();
			int iGroup = 0;
			int iYear = 0;

			//Clear Employee Grid
			ViewModel.sprEmployeeList.MaxRows = 500;
			ViewModel.sprEmployeeList.Row = 1;
			ViewModel.sprEmployeeList.Row2 = ViewModel.sprEmployeeList.MaxRows;
			ViewModel.sprEmployeeList.Col = 1;
			ViewModel.sprEmployeeList.Col2 = ViewModel.sprEmployeeList.MaxCols;
			ViewModel.sprEmployeeList.BlockMode = true;
			ViewModel.sprEmployeeList.Text = "";
			ViewModel.sprEmployeeList.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprEmployeeList.BlockMode = false;

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprEmployeeList.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeList.ClearSelection();

			//    'Fill Employee Grid

			if ( ViewModel.cboYear.SelectedIndex == -1)
			{
				iYear = 0;
			}
			else
			{
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				iYear = Convert.ToInt32(modGlobal.GetVal(ViewModel.cboYear.Text));
			}

			if ( ViewModel.optFGrp[0].Checked)
			{
				iGroup = 0;
			}
			else if ( ViewModel.optFGrp[1].Checked)
			{
				iGroup = 1;
			}
			else if ( ViewModel.optFGrp[2].Checked)
			{
				iGroup = 2;
			}
			else if ( ViewModel.optFGrp[3].Checked)
			{
				iGroup = 3;
			}
			else
			{
				iGroup = 0;
			}

			if (clEmployee.GetParamedicList(iGroup, iYear) != 0)
			{

			}
			else
			{
				ViewManager.ShowMessage("Oooops! There were no Paramedics retrieved.", "No Paramedics ??", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			int GridRow = 0;

			while(!clEmployee.Employee.EOF)
			{
				GridRow++;
				ViewModel.sprEmployeeList.MaxRows = GridRow;
				ViewModel.sprEmployeeList.Row = GridRow;
				ViewModel.sprEmployeeList.Col = 1;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(clEmployee.Employee["sap_id"]);
				ViewModel.sprEmployeeList.Col = 2;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(clEmployee.Employee["name_full"]);
				ViewModel.sprEmployeeList.Col = 3;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				//UPGRADE_WARNING: (1068) GetVal(clEmployee.Employee(group_number)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				if (modGlobal.Clean(clEmployee.Employee["group_number"]) == "")
				{
					ViewModel.sprEmployeeList.Text = "";
				}
				else if (Convert.ToDouble(modGlobal.GetVal(clEmployee.Employee["group_number"])) == 0)
				{
					ViewModel.sprEmployeeList.Text = "";
				}
				else
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.sprEmployeeList.Text = Convert.ToString(modGlobal.GetVal(clEmployee.Employee["group_number"]));
				}
				ViewModel.sprEmployeeList.Col = 4;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(clEmployee.Employee["unit_code"]);
				ViewModel.sprEmployeeList.Col = 5;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(clEmployee.Employee["shift_code"]);
				ViewModel.sprEmployeeList.Col = 6;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(clEmployee.Employee["position_code"]);
				ViewModel.sprEmployeeList.Col = 7;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				if (modGlobal.Clean(clEmployee.Employee["recert_date"]) == "")
				{
					ViewModel.sprEmployeeList.Text = "";
				}
				else
				{
					ViewModel.sprEmployeeList.Text = Convert.ToDateTime(clEmployee.Employee["recert_date"]).ToString("M/d/yyyy");
				}
				ViewModel.sprEmployeeList.Col = 8;
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.sprEmployeeList.Text = Convert.ToString(modGlobal.GetVal(clEmployee.Employee["per_sys_id"]));

				clEmployee.Employee.MoveNext();
			}
			;

			if (GridRow > 0)
			{
				ViewModel.sprEmployeeList.MaxRows = GridRow;
			}
			else
			{
				ViewModel.sprEmployeeList.MaxRows = 1;
			}
			ViewModel.lbCount.Text = "List Count: " + GridRow.ToString();
			ViewModel.sprEmployeeList.Protect = true;
			ViewModel.CurrPersID = 0;
			ViewModel.SelectedEmpRow = 0;
			ViewModel.RecordExists = false;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboYear_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			RefreshEmployeeGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void chkMedicFlag_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			PTSProject.clsTraining clMedicFlag = Container.Resolve< clsTraining>();
			bool AddNewRecord = false;

			if ( ViewModel.CurrPersID == 0)
			{
				return;
			}
			if ( ViewModel.FirstTime)
			{
				return;
			}

			AddNewRecord = !(clMedicFlag.GetPersonnelWorkAsParamedicByID(ViewModel.CurrPersID) != 0);

			clMedicFlag.WAMPerSysID = ViewModel.CurrPersID;
			if ( ViewModel.chkMedicFlag.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				clMedicFlag.WAMInactivateDate = "";
			}
			else
			{
				clMedicFlag.WAMInactivateDate = DateTime.Now.ToString("MM/dd/yyyy");
			}
			clMedicFlag.WAMUpdateDate = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
			clMedicFlag.WAMUpdateBy = modGlobal.Shared.gUser;

			if (AddNewRecord)
			{
				if (clMedicFlag.AddPersonnelWorkAsParamedic() != 0)
				{
					//All is well
				}
				else
				{
					ViewManager.ShowMessage("Oooops!  Something went wrong with the Insert.", "Insert Medic Flag", UpgradeHelpers.Helpers.BoxButtons.OK);
				}
			}
			else
			{
				if (clMedicFlag.UpdatePersonnelWorkAsParamedic() != 0)
				{
					//All is well
				}
				else
				{
					ViewManager.ShowMessage("Oooops!  Something went wrong with the Update.", "Update Medic Flag", UpgradeHelpers.Helpers.BoxButtons.OK);
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClear_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.txtNameSearch.Text = "";
			ViewModel.optFGrp[0].Checked = true;
			ViewModel.cboYear.SelectedIndex = -1;
			ViewModel.FirstTime = true;
			ClearFields();
			ViewModel.FirstTime = false;
			RefreshEmployeeGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdDone_Click(Object eventSender, System.EventArgs eventArgs)
		{

			if ( ViewModel.CurrPersID == 0)
			{
				return;
			}
			SaveRecertificationInfo();
			//    RefreshEmployeeGrid

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdExit_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			ViewModel.CurrPersID = 0;
			ClearFields();
			ViewModel.txtNameSearch.Text = "";
			ViewModel.optFGrp[0].Checked = true;
			ViewModel.cboYear.Items.Clear();
			ViewModel.cboYear.AddItem("2005");
			ViewModel.cboYear.AddItem("2006");
			ViewModel.cboYear.AddItem("2007");
			ViewModel.cboYear.AddItem("2008");
			ViewModel.cboYear.AddItem("2009");
			ViewModel.cboYear.AddItem("2010");
			ViewModel.cboYear.AddItem("2011");
			ViewModel.cboYear.AddItem("2012");
			ViewModel.cboYear.AddItem("2013");
			ViewModel.cboYear.AddItem("2014");
			ViewModel.cboYear.AddItem("2015");
			ViewModel.cboYear.AddItem("2016");
			ViewModel.cboYear.AddItem("2017");
			ViewModel.cboYear.AddItem("2018");
			ViewModel.cboYear.AddItem("2019");
			ViewModel.cboYear.AddItem("2020");

			RefreshEmployeeGrid();

		}

		[UpgradeHelpers.Events.Handler]
		internal void optFGrp_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				RefreshEmployeeGrid();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optGroup_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				//    If Index <> 0 Then
				//        cmdDone.Enabled = True
				//    End If
			}
		}

		private void sprEmployeeList_CellClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
		{
			int Col = eventArgs.Column;
			int Row = eventArgs.Row;
			ViewModel.CurrPersID = 0;
			if (Row == 0)
			{
				//    Exit Sub
				Row = 1;
			}
			ViewModel.SelectedEmpRow = Row;

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprEmployeeList.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeList.ClearSelection();
			ViewModel.sprEmployeeList.Row = 1;
			ViewModel.sprEmployeeList.Row2 = ViewModel.sprEmployeeList.MaxRows;
			ViewModel.sprEmployeeList.Col = 1;
			ViewModel.sprEmployeeList.Col2 = ViewModel.sprEmployeeList.MaxCols;
			ViewModel.sprEmployeeList.BlockMode = true;
			ViewModel.sprEmployeeList.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprEmployeeList.BlockMode = false;
			//ViewModel.sprEmployeeList.SetSelection(1, Row, ViewModel.sprEmployeeList.MaxCols, Row);
			ViewModel.sprEmployeeList.Row = Row;
			ViewModel.sprEmployeeList.Row2 = Row;
			ViewModel.sprEmployeeList.Col = 1;
			ViewModel.sprEmployeeList.Col2 = ViewModel.sprEmployeeList.MaxCols;
			ViewModel.sprEmployeeList.BlockMode = true;
			ViewModel.sprEmployeeList.BackColor = modGlobal.Shared.YELLOW;
			ViewModel.sprEmployeeList.BlockMode = false;
			ViewModel.sprEmployeeList.Row = Row;
			ViewModel.sprEmployeeList.Col = 8;
			ViewModel.CurrPersID = Convert.ToInt32(Double.Parse(modGlobal.Clean(ViewModel.sprEmployeeList.Text)));

			GetEmployeeInfo();

		}

		[UpgradeHelpers.Events.Handler]
		internal void txtExpireDate_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.cmdDone.Enabled = Information.IsDate(ViewModel.txtExpireDate.Text);
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtNameSearch_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprEmployeeList.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeList.ClearSelection();
			ViewModel.sprEmployeeList.Row = 1;
			ViewModel.sprEmployeeList.Row2 = ViewModel.sprEmployeeList.MaxRows;
			ViewModel.sprEmployeeList.Col = 1;
			ViewModel.sprEmployeeList.Col2 = ViewModel.sprEmployeeList.MaxCols;
			ViewModel.sprEmployeeList.BlockMode = true;
			ViewModel.sprEmployeeList.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprEmployeeList.BlockMode = false;
			ViewModel.CurrPersID = 0;
			ClearFields();

			int iLength = Strings.Len(ViewModel.txtNameSearch.Text);
			if (iLength == 0)
			{
				return;
			}

			int tempForVar = ViewModel.sprEmployeeList.DataRowCnt;
			for (int i = 1; i <= tempForVar; i++)
			{
				ViewModel.sprEmployeeList.Col = 2;
				ViewModel.sprEmployeeList.Row = i;
				if ( ViewModel.sprEmployeeList.Text.Substring(0, Math.Min(iLength, ViewModel.sprEmployeeList.Text.Length)).ToUpper() == modGlobal.Clean(ViewModel.txtNameSearch.Text).ToUpper())
				{
					//ViewModel.sprEmployeeList.SetSelection(1, i, ViewModel.sprEmployeeList.MaxCols, i);
					ViewModel.sprEmployeeList.Row = i;
					ViewModel.sprEmployeeList.Row2 = i;
					ViewModel.sprEmployeeList.Col = 1;
					ViewModel.sprEmployeeList.Col2 = ViewModel.sprEmployeeList.MaxCols;
					ViewModel.sprEmployeeList.BlockMode = true;
					ViewModel.sprEmployeeList.BackColor = modGlobal.Shared.YELLOW;
					ViewModel.sprEmployeeList.BlockMode = false;
					ViewModel.sprEmployeeList.Row = i;
					ViewModel.sprEmployeeList.Col = 8;
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.CurrPersID = Convert.ToInt32(modGlobal.GetVal(ViewModel.sprEmployeeList.Text));
					ViewModel.SelectedEmpRow = i;

					GetEmployeeInfo();
					return;
				}
			}

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmPMCertification DefInstance
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

		public static frmPMCertification CreateInstance()
		{
			PTSProject.frmPMCertification theInstance = Shared.Container.Resolve< frmPMCertification>();
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
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprEmployeeList.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmPMCertification
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmPMCertificationViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmPMCertification m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}