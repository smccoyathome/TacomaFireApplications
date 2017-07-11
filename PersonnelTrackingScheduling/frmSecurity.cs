using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class frmSecurity
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmSecurityViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmSecurity));
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


		private void frmSecurity_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//**********************************
		//* Utility Form for Updating      *
		//* Application Security Clearance *
		//**********************************
		//ADODB

		public void AddNewRecord()
		{
			//Insert new security record
			string Empid = "";
			string SecurityCode = "";
			string UserID = "";
			int EmpIndex = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{
				//Come Here - for employee id change
				Empid = ViewModel.cboEmpList.Text.Substring(Math.Max(ViewModel.cboEmpList.Text.Length - 5, 0));
				EmpIndex = ViewModel.cboEmpList.SelectedIndex;
				if ( ViewModel.cboSecurity.SelectedIndex == -1)
				{
					ViewManager.ShowMessage("You must select Security Clearance", "Add New Security Record", UpgradeHelpers.Helpers.BoxButtons.OK);
					return;
				}
				else
				{
					SecurityCode = ViewModel.cboSecurity.Text.Substring(Math.Max(ViewModel.cboSecurity.Text.Length - 3, 0));
				}
				if ( ViewModel.txtUserID.Text == "")
				{
					ViewManager.ShowMessage("You must enter a User ID", "Add New Security Record", UpgradeHelpers.Helpers.BoxButtons.OK);
					return;
				}
				else
				{
					UserID = ViewModel.txtUserID.Text.ToUpper();
				}

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spInsertSecurity";
				oCmd.ExecuteNonQuery(new object[] { Empid, UserID, SecurityCode });

				ViewModel.cmdUpdate.Text = "&Update";
				ViewManager.ShowMessage("Employee Security Record Added", "Edit Security", UpgradeHelpers.Helpers.BoxButtons.OK);
				ViewModel.cboEmpList.SelectedIndex = -1;
				ViewModel.cboEmpList.SelectedIndex = EmpIndex;
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
		internal void cboEmpList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Load form labels with selected Employees
			//Security info
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string MultiMsg = "";

			if ( ViewModel.cboEmpList.SelectedIndex < 0)
			{
				return;
			}

			//On Error GoTo ErrHandler
			//Come Here - for employee id change
			string Empid = ViewModel.cboEmpList.Text.Substring(Math.Max(ViewModel.cboEmpList.Text.Length - 5, 0));
			//UPGRADE_NOTE: (1061) Erase was upgraded to System.Array.Clear. More Information: http://www.vbtonet.com/ewis/ewi1061.aspx
			if ( ViewModel.UserArray != null)
			{
				Array.Clear(ViewModel.UserArray, 0, ViewModel.UserArray.Length);
			}
			ViewModel.CurrUser = 0;
			ViewModel.cmdNext.Visible = false;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "sp_GetSecurity '" + Empid + "'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (oRec.EOF)
			{
				ViewManager.ShowMessage("No Security Record available for this employee", "Edit Security", UpgradeHelpers.Helpers.BoxButtons.OK);
				ViewModel.lbName.Text = "";
				ViewModel.lbEmpID.Text = "";
				ViewModel.txtUserID.Text = "";
				ViewModel.cboSecurity.SelectedIndex = -1;
				ViewModel.cmdUpdate.Text = "&Add";
				return;
			}
			else
			{
				ViewModel.lbName.Text = Convert.ToString(oRec["name_full"]);
				ViewModel.lbEmpID.Text = Convert.ToString(oRec["SecID"]);
				ViewModel.txtUserID.Text = Convert.ToString(oRec["user_id"]).Trim();
				ViewModel.UserArray[ViewModel.CurrUser] = ViewModel.txtUserID.Text;
				(ViewModel.CurrUser)++;
				for (int i = 0; i <= ViewModel.cboSecurity.Items.Count - 1; i++)
				{
					if (Convert.ToString(oRec["security_code"]) == ViewModel.cboSecurity.GetListItem(i).Substring(Math.Max(ViewModel.cboSecurity.GetListItem(i).Length - 3, 0)))
					{
						ViewModel.cboSecurity.SelectedIndex = i;
						break;
					}
				}
			}

			oRec.MoveNext();
			if (!oRec.EOF)
			{
				MultiMsg = "This Employee has multiple Security Records" + "\n";
				MultiMsg = MultiMsg + "All records will reflect changes made to this User ID";
				ViewModel.cmdNext.Visible = true;
				ViewManager.ShowMessage(MultiMsg, "Edit Security", UpgradeHelpers.Helpers.BoxButtons.OK);

				while(!oRec.EOF)
				{
					if ( ViewModel.txtUserID.Text != "SA")
					{
						ViewModel.txtUserID.Text = Convert.ToString(oRec["user_id"]).Trim();
					}
					ViewModel.UserArray[ViewModel.CurrUser] = Convert.ToString(oRec["user_id"]).Trim();
					(ViewModel.CurrUser)++;
					oRec.MoveNext();
				};
				ViewModel.TotalUsers = ViewModel.CurrUser - 1;
			}

			return;


			//if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
			//{
			//	return;
			//}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdNext_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Switch text in User ID Text box
			//int i = 0;

			for ( ViewModel.CurrUser = 0; ViewModel.CurrUser <= 5; (ViewModel.CurrUser)++)
			{
				if ( ViewModel.txtUserID.Text == ViewModel.UserArray[ViewModel.CurrUser])
				{
					if ( ViewModel.CurrUser == ViewModel.TotalUsers)
					{
						ViewModel.CurrUser = 0;
					}
					else
					{
						(ViewModel.CurrUser)++;
					}
					break;
				}
			}
			ViewModel.txtUserID.Text = ViewModel.UserArray[ViewModel.CurrUser];
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdUpdate_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Update Selected Employee's Security Record
			string Empid = "";
			string SecurityCode = "";
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				if ( ViewModel.cmdUpdate.Text == "&Add")
				{
					AddNewRecord();
					return;
				}

				Empid = ViewModel.lbEmpID.Text;
				SecurityCode = ViewModel.cboSecurity.Text.Substring(Math.Max(ViewModel.cboSecurity.Text.Length - 3, 0));

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.CommandText = "spUpdateSecurity";
				oCmd.ExecuteNonQuery(new object[] { Empid, SecurityCode });
				ViewManager.ShowMessage("Employee Security Updated", "Edit Security", UpgradeHelpers.Helpers.BoxButtons.OK);
			}
			catch
			{

				if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
				{
					return;
				}
			}

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			//Load Employee Listbox

			string strName = "";
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spFullNameList";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				ViewModel.cboEmpList.Items.Clear();

				while(!oRec.EOF)
				{
					strName = Convert.ToString(oRec["name_full"]).Trim() + " - " + Convert.ToString(oRec["employee_id"]);
					ViewModel.cboEmpList.AddItem(strName);
					oRec.MoveNext();
				};

				oCmd.CommandText = "sp_GetSecurityCodes";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				ViewModel.cboSecurity.Items.Clear();

				while(!oRec.EOF)
				{
					strName = Convert.ToString(oRec["security_description"]).Trim() + " - " + Convert.ToString(oRec["security_code"]);
					ViewModel.cboSecurity.AddItem(strName);
					oRec.MoveNext();
				};
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

		public static frmSecurity DefInstance
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

		public static frmSecurity CreateInstance()
		{
			PTSProject.frmSecurity theInstance = Shared.Container.Resolve< frmSecurity>();
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

	public partial class frmSecurity
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmSecurityViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmSecurity m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}