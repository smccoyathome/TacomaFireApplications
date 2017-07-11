using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class frmAdjustAssign
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmAdjustAssignViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		//*********************************************
		//frmAdjustAssign    -   AdjustAssig.frm
		//Called from Assignment form
		//Used to select which OP Employee is active
		//For a given assignment (only one active allowed)
		//*********************************************
		//ADODB
		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmAdjustAssign));
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



		public void FillOptionFrame()
		{
			//Request set of Employees having this assignment and load option Frame

			string strSQL = "";
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;


			try
			{

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;

				strSQL = "select employee_id, name_full, assignment_status ";
				strSQL = strSQL + "From Personnel where assignment_id = ";
				strSQL = strSQL + ViewModel.CurrentAssignment.ToString() + ";";
				oCmd.CommandText = strSQL;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				for (int i = 0; i <= 7; i++)
				{
					if (oRec.EOF)
					{
						break;
					}
					ViewModel.opbEmp[i].Text = Convert.ToString(oRec["name_full"]);
					ViewModel.opbEmp[i].Tag = Convert.ToString(oRec["employee_id"]);
					ViewModel.opbEmp[i].Checked = Convert.ToBoolean(oRec["assignment_status"]);
					if (Convert.ToBoolean(oRec["assignment_status"]))
					{
						ViewModel.CurrentActive = i;
					}
					ViewModel.opbEmp[i].Visible = true;
					oRec.MoveNext();
				}
			}
			catch
			{

				if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
				{
					return;
				}
			}
		}

		public void FindAssignment()
		{

			//Find Assignment to be Adjusted based on current selected Employee
			//In Assignment form

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string strSQL = "";

			try
			{
				ViewModel.lbUnit.Text = "";
				ViewModel.lbPosition.Text = "";
				ViewModel.lbShift.Text = "";

				strSQL = "spSelect_PersonnelByEmpID '" + modGlobal.Shared.gAssignID + "' ";
				//    strSQL = "SELECT * from Personnel WHERE employee_id ='"
				//    strSQL = strSQL & gAssignID & "' "

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = strSQL;
				oRec = ADORecordSetHelper.Open(oCmd, "");
				ViewModel.CurrentAssignment = Convert.ToInt32(oRec["assignment_id"]);
				strSQL = "spSelect_AssignmentByID " + ViewModel.CurrentAssignment.ToString() + " ";

				//    strSQL = "select assignment_id, unit_code, position_code, "
				//    strSQL = strSQL & "shift_code from Assignment where assignment_id = "
				//    strSQL = strSQL & CurrentAssignment & ";"

				oCmd.CommandText = strSQL;
				oRec = ADORecordSetHelper.Open(oCmd, "");
				ViewModel.lbUnit.Text = Convert.ToString(oRec["unit_code"]);
				ViewModel.lbPosition.Text = Convert.ToString(oRec["position_code"]);
				ViewModel.lbShift.Text = Convert.ToString(oRec["shift_code"]);
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
		internal void cmdDone_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{

			try
			{
				FindAssignment();
				ViewModel.CurrentActive = 99;
				FillOptionFrame();
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
		internal void opbEmp_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				int Index =this.ViewModel.opbEmp.IndexOf((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender);

				//Change Active Employee for this assignment

				int opValue = (ViewModel.opbEmp[Index].Checked) ? -1 : 0;

				if (Index == ViewModel.CurrentActive)
				{
					return;
				} //currently active employee was clicked
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				try
				{

					oCmd.Connection = modGlobal.oConn;
					oCmd.CommandType = CommandType.StoredProcedure;
					oCmd.CommandText = "spUpdatePersonnelAssignment";

					//if there was an active employee
					//Inactivate Previously Active Employee
					if ( ViewModel.CurrentActive != 99)
					{
						oCmd.ExecuteNonQuery(new object[] { Convert.ToString(ViewModel.opbEmp[ViewModel.CurrentActive].Tag), ViewModel.CurrentAssignment, 0, DateTime.Now });
					}

					//Activate Selected Employee
					oCmd.ExecuteNonQuery(new object[] { Convert.ToString(ViewModel.opbEmp[Index].Tag), ViewModel.CurrentAssignment, 1, DateTime.Now });
					ViewModel.CurrentActive = Index;
					return;
				}
				catch
				{

					if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
					{
						return;
					}
				}
			}
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmAdjustAssign DefInstance
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

		public static frmAdjustAssign CreateInstance()
		{
			PTSProject.frmAdjustAssign theInstance = Shared.Container.Resolve< frmAdjustAssign>();
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
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmAdjustAssign
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmAdjustAssignViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmAdjustAssign m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}