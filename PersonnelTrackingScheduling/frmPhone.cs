using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class frmPhone
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmPhoneViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmPhone));
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


		private void frmPhone_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}


		public void LoadPhoneList()
		{
			//Determine if Employee or Resource
			//Load lstPhone with numbers

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			//clear fields
			ViewModel.lstPhone.Items.Clear();
			ViewModel.cboType.SelectedIndex = -1;
			ViewModel.cboType.Text = "";
			ViewModel.txtPhone.Text = "";
			ViewModel.txtComment.Text = "";
			ViewModel.chkCallBack.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			if ( ViewModel.lbEmpID.Text == "")
			{
				oCmd.CommandText = "sp_GetPhoneListR " + Conversion.Val(ViewModel.lbResID.Text).ToString();
			}
			else
			{
				oCmd.CommandText = "sp_GetPhoneList '" + ViewModel.lbEmpID.Text + "'";
			}

			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				ViewModel.lstPhone.AddItem(Convert.ToString(oRec["phone_type"]) + " " + Convert.ToString(oRec["phone_number"]));
				ViewModel.lstPhone.SetItemData(ViewModel.lstPhone.GetNewIndex(), Convert.ToInt32(oRec["phone_id"]));
				oRec.MoveNext();
			};

		}

		public void FindEmployee()
		{
			//If called from Update Screens bring up selected Employee


			for (int i = 0; i <= ViewModel.cboEmpList.Items.Count - 1; i++)
			{
				//Come Here - for employee id change
				if ( ViewModel.cboEmpList.GetListItem(i).Substring(Math.Max(ViewModel.cboEmpList.GetListItem(i).Length - 5, 0)) == modGlobal.Shared.gAssignID)
				{
					ViewModel.cboEmpList.Text = ViewModel.cboEmpList.GetListItem(i);
					break;
				}
			}
			//Come Here - for employee id change
			ViewModel.lbEmpID.Text = ViewModel.cboEmpList.Text.Substring(Math.Max(ViewModel.cboEmpList.Text.Length - 5, 0));
			LoadPhoneList();

		}

		public void FillResourceList()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ViewModel.cboResource.Items.Clear();
			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "sp_GetResourceList";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			while(!oRec.EOF)
			{
				ViewModel.cboResource.AddItem(Convert.ToString(oRec["resource_name"]));
				ViewModel.cboResource.SetItemData(ViewModel.cboResource.GetNewIndex(), Convert.ToInt32(oRec["resourse_id"]));
				oRec.MoveNext();
			};




		}

		public void FillNameList()
		{
			//Fill Employee Name List

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string strName = "";

			try
			{
				ViewModel.cboEmpList.Items.Clear();

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				switch(modGlobal.Shared.gSecurity)
				{
					case "HAZ" :
						oCmd.CommandText = "sp_FillXList 'HZM'";
						break;
					case "ADM" : case "PER" :
						oCmd.CommandText = "spFullNameList";
						break;
					case "BAT" : case "AID" :
						oCmd.CommandText = "spOpNameList";
						break;
					default:
						oCmd.CommandText = "sp_FillXList '" + modGlobal.Shared.gSecurity + "'";
						break;
				}
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (modGlobal.Shared.gSecurity != "RO")
				{

					while(!oRec.EOF)
					{
						strName = Convert.ToString(oRec["name_full"]).Trim() + "  :" + Convert.ToString(oRec["employee_id"]);
						ViewModel.cboEmpList.AddItem(strName);
						oRec.MoveNext();
					};

				}
				else
				{
					strName = modGlobal.Shared.gUserName + "  :" + modGlobal.Shared.gUser;
					ViewModel.cboEmpList.AddItem(strName);
				}
				ViewModel.cboType.Items.Clear();
				ViewModel.cboType.Text = "";
				oCmd.CommandText = "spSelect_PhoneTypeList";
				oRec = ADORecordSetHelper.Open(oCmd, "");

				while(!oRec.EOF)
				{
					ViewModel.cboType.AddItem(Convert.ToString(oRec["phone_type"]));
					oRec.MoveNext();
				}
				;
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
			//Load Phone Number listbox for selected Employee

			if ( ViewModel.cboEmpList.SelectedIndex == -1)
			{
				return;
			}
			//Come Here - for employee id change
			ViewModel.lbEmpID.Text = ViewModel.cboEmpList.Text.Substring(Math.Max(ViewModel.cboEmpList.Text.Length - 5, 0));
			ViewModel.lbResID.Text = "";
			LoadPhoneList();


		}

		[UpgradeHelpers.Events.Handler]
		internal void cboResource_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Load lstPhone with Resource Numbers
			if ( ViewModel.cboResource.SelectedIndex == -1)
			{
				return;
			}
			ViewModel.lbResID.Text = ViewModel.cboResource.GetItemData(ViewModel.cboResource.SelectedIndex).ToString();
			ViewModel.lbEmpID.Text = "";
			LoadPhoneList();
		}

		[UpgradeHelpers.Events.Handler]
		internal void chkCallBack_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.chkCallBack.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				ViewModel.CallBackFlag = "Y";
			}
			else
			{
				ViewModel.CallBackFlag = "N";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAdd_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display Phone Entry Controls
			if (Convert.ToString(ViewModel.cmdAdd.Tag) == "Display")
			{
				ViewModel.lbType.Visible = true;
				ViewModel.cboType.Visible = true;
				ViewModel.cboType.SelectedIndex = -1;
				ViewModel.lbNumber.Visible = true;
				ViewModel.txtPhone.Visible = true;
				ViewModel.txtPhone.Text = "";
				ViewModel.lbComment.Visible = true;
				ViewModel.txtComment.Visible = true;
				ViewModel.txtComment.Text = "";
				ViewModel.chkCallBack.Visible = true;
				ViewModel.chkCallBack.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
				ViewModel.CallBackFlag = "N";
				ViewModel.cmdAdd.Tag = "Add";
				ViewModel.cmdAdd.Text = "Add";
				ViewManager.SetCurrent(ViewModel.cboType);
				return;
			}

			//Or Edit and Add New Phone Number
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			//ADORecordSetHelper oRec = null;
			//int i = 0;
			//string str1 = "", CommStr = "", str2 = "";

			if ( ViewModel.cboType.SelectedIndex == -1)
			{
				ViewManager.ShowMessage("You must select a Phone Type", "Update Phone List", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				ViewManager.SetCurrent(ViewModel.cboType);
				return;
			}
			ViewModel.txtPhone.Text = ViewModel.txtPhone.Text.Trim();
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
			if ( ViewModel.txtPhone.Text == "" || Convert.IsDBNull(ViewModel.txtPhone.Text))
			{
				ViewManager.ShowMessage("You must enter a phone number", "Update Phone List", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				ViewManager.SetCurrent(ViewModel.txtPhone);
				ViewModel.txtPhone.SelectionStart = 0;
				ViewModel.txtPhone.SelectionLength = Strings.Len(ViewModel.txtPhone.Text);
				return;
				//    ElseIf Len(txtPhone.Text) < 8 Then
				//        MsgBox "Phone Number must be at least 8 characters in length", vbCritical, "Update Phone List"
				//        txtPhone.SetFocus
				//        txtPhone.SelStart = 0
				//        txtPhone.SelLength = Len(txtPhone.Text)
				//        Exit Sub
			}
			else if (Strings.Len(ViewModel.txtPhone.Text) > 50)
			{
				ViewManager.ShowMessage("Phone Number to long (50 character limit)", "Update Phone List", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				ViewManager.SetCurrent(ViewModel.txtPhone);
				ViewModel.txtPhone.SelectionStart = 0;
				ViewModel.txtPhone.SelectionLength = Strings.Len(ViewModel.txtPhone.Text);
				return;
			}

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//Insert New Phone Record
			if ( ViewModel.lbEmpID.Text == "")
			{
				oCmd.CommandText = "spInsertPhoneNumber ''," + Conversion.Val(ViewModel.lbResID.Text).ToString() + ",'" +
											ViewModel.cboType.Text + "','" + ViewModel.txtPhone.Text + "','" + Strings.Replace(ViewModel.txtComment.Text,
								"'", "''", 1, -1, CompareMethod.Binary).Trim() + "', '" + modGlobal.Clean(ViewModel.CallBackFlag) + "' ";
			}
			else
			{
				oCmd.CommandText = "spInsertPhoneNumber '" + ViewModel.lbEmpID.Text + "',0,'" + ViewModel.cboType.Text + "','" + ViewModel.txtPhone.Text + "','" + Strings.Replace
								(ViewModel.txtComment.Text, "'", "''", 1, -1, CompareMethod.Binary).Trim() + "', '" + modGlobal.Clean(ViewModel.CallBackFlag) + "' ";
			}
			oCmd.ExecuteNonQuery();
			ViewModel.cmdAdd.Tag = "Display";
			ViewModel.cmdAdd.Text = "&Add New Number";
			ViewModel.lbType.Visible = false;
			ViewModel.cboType.Visible = false;
			ViewModel.lbNumber.Visible = false;
			ViewModel.txtPhone.Visible = false;
			ViewModel.txtPhone.Text = "";
			ViewModel.lbComment.Visible = false;
			ViewModel.txtComment.Visible = false;
			ViewModel.txtComment.Text = "";
			ViewModel.chkCallBack.Visible = false;
			ViewModel.chkCallBack.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.cmdUpdate.Enabled = false;
			ViewModel.cmdDelete.Enabled = false;

			LoadPhoneList();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdDelete_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Delete Current Phone Number

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			//ADORecordSetHelper oRec = null;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//Delete Existing Phone Record
			oCmd.CommandText = "spDelete_PhoneNumber " + ViewModel.CurrNumber.ToString();
			oCmd.ExecuteNonQuery();
			ViewModel.cmdAdd.Tag = "Display";
			ViewModel.cmdAdd.Text = "&Add New Number";
			ViewModel.lbType.Visible = false;
			ViewModel.cboType.Visible = false;
			ViewModel.lbNumber.Visible = false;
			ViewModel.txtPhone.Visible = false;
			ViewModel.txtPhone.Text = "";
			ViewModel.lbComment.Visible = false;
			ViewModel.txtComment.Visible = false;
			ViewModel.txtComment.Text = "";
			ViewModel.chkCallBack.Visible = false;
			ViewModel.chkCallBack.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.CallBackFlag = "N";
			ViewModel.CurrNumber = 0;
			ViewModel.cmdUpdate.Enabled = false;
			ViewModel.cmdDelete.Enabled = false;
			LoadPhoneList();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdUpdate_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Or Edit and Update Phone Number
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			//ADORecordSetHelper oRec = null;
			//string str1 = "", CommStr = "", str2 = "";
			//int i = 0;
			ViewModel.cboType.Text = ViewModel.cboType.Text.Trim();
			if ( ViewModel.cboType.Text == "")
			{
				ViewManager.ShowMessage("You must select a Phone Type", "Update Phone List", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				ViewManager.SetCurrent(ViewModel.cboType);
				return;
			}
			ViewModel.txtPhone.Text = ViewModel.txtPhone.Text.Trim();
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
			if ( ViewModel.txtPhone.Text == "" || Convert.IsDBNull(ViewModel.txtPhone.Text))
			{
				ViewManager.ShowMessage("You must enter a phone number", "Update Phone List", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				ViewManager.SetCurrent(ViewModel.txtPhone);
				ViewModel.txtPhone.SelectionStart = 0;
				ViewModel.txtPhone.SelectionLength = Strings.Len(ViewModel.txtPhone.Text);
				return;
			}
			else if (Strings.Len(ViewModel.txtPhone.Text) > 50)
			{
				ViewManager.ShowMessage("Phone Number to long (50 character limit)", "Update Phone List", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				ViewManager.SetCurrent(ViewModel.txtPhone);
				ViewModel.txtPhone.SelectionStart = 0;
				ViewModel.txtPhone.SelectionLength = Strings.Len(ViewModel.txtPhone.Text);
				return;
			}

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//Delete Existing Phone Record
			oCmd.CommandText = "spDelete_PhoneNumber " + ViewModel.CurrNumber.ToString();
			oCmd.ExecuteNonQuery();

			//Insert New Phone Record
			if ( ViewModel.lbEmpID.Text == "")
			{
				oCmd.CommandText = "spInsertPhoneNumber ''," + Conversion.Val(ViewModel.lbResID.Text).ToString() + ",'" +
											ViewModel.cboType.Text + "','" + ViewModel.txtPhone.Text + "','" + Strings.Replace(ViewModel.txtComment.Text,
								"'", "''", 1, -1, CompareMethod.Binary).Trim() + "', '" + modGlobal.Clean(ViewModel.CallBackFlag) + "' ";
			}
			else
			{
				oCmd.CommandText = "spInsertPhoneNumber '" + ViewModel.lbEmpID.Text + "',0,'" + ViewModel.cboType.Text + "','" + ViewModel.txtPhone.Text + "','" + Strings.Replace
								(ViewModel.txtComment.Text, "'", "''", 1, -1, CompareMethod.Binary).Trim() + "', '" + modGlobal.Clean(ViewModel.CallBackFlag) + "' ";
			}
			oCmd.ExecuteNonQuery();
			ViewModel.cmdAdd.Tag = "Display";
			ViewModel.cmdAdd.Text = "&Add New Number";
			ViewModel.lbType.Visible = false;
			ViewModel.cboType.Visible = false;
			ViewModel.lbNumber.Visible = false;
			ViewModel.txtPhone.Visible = false;
			ViewModel.txtPhone.Text = "";
			ViewModel.lbComment.Visible = false;
			ViewModel.txtComment.Visible = false;
			ViewModel.txtComment.Text = "";
			ViewModel.chkCallBack.Visible = false;
			ViewModel.chkCallBack.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.CallBackFlag = "N";
			ViewModel.CurrNumber = 0;
			ViewModel.cmdUpdate.Enabled = false;
			ViewModel.cmdDelete.Enabled = false;
			LoadPhoneList();

		}


		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			//Load Listbox
			//Set to Current Employee if called from Update Screen
			ViewModel.CallBackFlag = "N";
			FillNameList();
			if (modGlobal.Shared.gAssignID != "")
			{
				FindEmployee();
				ViewModel.lbOr.Visible = false;
				ViewModel.lbResource.Visible = false;
				ViewModel.cboResource.Visible = false;
			}
			else
			{
				FillResourceList();
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lstPhone_SelectedIndexChanged(Object eventSender, System.EventArgs eventArgs)
		{
			//Load Selected Record into Edit Boxes
			//string PhoneType = "";
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			//PhoneType = Trim$(Left$(lstPhone.Text, 10))
			ViewModel.CurrNumber = ViewModel.lstPhone.GetItemData(ViewModel.lstPhone.SelectedIndex);

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "sp_GetPhoneNumber " + ViewModel.CurrNumber.ToString();
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (oRec.EOF)
			{
				ViewManager.ShowMessage("Unable to retreive requested record", "Update Phone List Error", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				return;
			}
			ViewModel.lbType.Visible = true;
			ViewModel.cboType.Visible = true;
			ViewModel.lbNumber.Visible = true;
			ViewModel.txtPhone.Visible = true;
			ViewModel.lbComment.Visible = true;
			ViewModel.txtComment.Visible = true;
			ViewModel.chkCallBack.Visible = true;
			ViewModel.txtPhone.Text = Convert.ToString(oRec["phone_number"]);
			ViewModel.txtComment.Text = modGlobal.Clean(oRec["comment"]);
			if (modGlobal.Clean(oRec["call_back_flag"]) == "Y")
			{
				ViewModel.chkCallBack.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
				ViewModel.CallBackFlag = "Y";
			}
			else
			{
				ViewModel.chkCallBack.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
				ViewModel.CallBackFlag = "N";
			}
			for (int i = 0; i <= ViewModel.cboType.Items.Count - 1; i++)
			{
				if ( ViewModel.cboType.GetListItem(i) == Convert.ToString(oRec["phone_type"]).Trim())
				{
					ViewModel.cboType.Text = ViewModel.cboType.GetListItem(i);
					break;
				}
			}
			ViewModel.cmdUpdate.Enabled = true;
			ViewModel.cmdDelete.Enabled = true;
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmPhone DefInstance
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

		public static frmPhone CreateInstance()
		{
			PTSProject.frmPhone theInstance = Shared.Container.Resolve< frmPhone>();
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

	public partial class frmPhone
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmPhoneViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmPhone m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}