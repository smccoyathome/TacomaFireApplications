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

	public partial class frmAddress
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmAddressViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmAddress));
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


		private void frmAddress_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		public void GetAddressDetail()
		{
			//Get Address Detail
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			//clear detail information
			ViewModel.txtAddress.Text = "";
			ViewModel.txtCity.Text = "";
			ViewModel.txtState.Text = "";
			ViewModel.txtZip.Text = "";
			ViewModel.txtComment.Text = "";
			ViewModel.cboType.Text = "";

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "sp_GetAddressDetail '" + ViewModel.lbAddressID.Text + "'";

			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (oRec.EOF)
			{
				ViewManager.ShowMessage("Unable to retrieve record !", "Get Address Detail", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}
			ViewModel.txtAddress.Text = Convert.ToString(oRec["address_full"]).Trim();
			ViewModel.txtCity.Text = Convert.ToString(oRec["city"]).Trim();
			ViewModel.txtState.Text = Convert.ToString(oRec["state"]).Trim();
			ViewModel.txtZip.Text = Convert.ToString(oRec["zip_code"]).Trim();
			ViewModel.txtComment.Text = Convert.ToString(oRec["comment"]);
			ViewModel.cboType.Text = Convert.ToString(oRec["address_type"]).Trim();


		}

		public void LoadAddressList()
		{
			//Fill Address List Box for selected employee
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string strName = "";

			//Clear Address fields...
			ViewModel.lstAddress.Items.Clear();
			ViewModel.txtAddress.Text = "";
			ViewModel.txtCity.Text = "";
			ViewModel.txtState.Text = "";
			ViewModel.txtZip.Text = "";
			ViewModel.txtComment.Text = "";
			ViewModel.cboType.Text = "";

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "sp_GetAddressList '" + ViewModel.lbEmpID.Text + "'";

			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				strName = Convert.ToString(oRec["address_full"]).Trim() + ", " + Convert.ToString(oRec["city"]).Trim() + "  " + Convert.ToString(oRec["state"]).Trim() + "  " + Convert.ToString(oRec["zip_code"]).Trim();
				//Add Home Address to the Top of the list...  a
				if (Convert.ToString(oRec["address_type"]).Trim() == "Home")
				{
					ViewModel.lstAddress.AddItem(strName, 0);
					ViewModel.txtAddress.Text = Convert.ToString(oRec["address_full"]).Trim();
					ViewModel.txtCity.Text = Convert.ToString(oRec["city"]).Trim();
					ViewModel.txtState.Text = Convert.ToString(oRec["state"]).Trim();
					ViewModel.txtZip.Text = Convert.ToString(oRec["zip_code"]).Trim();
					ViewModel.txtComment.Text = Convert.ToString(oRec["comment"]);
					ViewModel.cboType.Text = Convert.ToString(oRec["address_type"]).Trim();
				}
				else
				{
					ViewModel.lstAddress.AddItem(strName);
				}
				ViewModel.lstAddress.SetItemData(ViewModel.lstAddress.GetNewIndex(), Convert.ToInt32(oRec["address_id"]));
				oRec.MoveNext();
			};

			if ( ViewModel.lstAddress.GetListItem(0) != "")
			{
				//highlight the default...
				ViewModel.lbAddressID.Text = ViewModel.lstAddress.GetItemData(0).ToString();
				UpgradeHelpers.Helpers.ListBoxHelper.SetSelected(ViewModel.lstAddress, 0, true);
				//set command buttons appropriately...
				ViewModel.cmdUpdate.Visible = true;
				ViewModel.cmdDelete.Visible = true;
				ViewModel.cmdAdd.Text = "New &Address";
				ViewModel.cmdAdd.Tag = "1";
				ViewModel.cmdAdd.Visible = true;
			}
			else
			{
				//load the lstAddress no records exist...
				ViewModel.lstAddress.AddItem("No Address Exist", 0);
				ViewModel.lbAddressID.Text = "0";

				//set command buttons appropriately...
				ViewModel.cmdUpdate.Visible = false;
				ViewModel.cmdDelete.Visible = false;
				ViewModel.cmdAdd.Tag = "2";
				ViewModel.cmdAdd.Text = "&Add New Address";
				ViewModel.cmdAdd.Visible = true;

			}
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
			}
			catch
			{

				if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
				{
					return;
				}
			}

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

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboEmpList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboEmpList.SelectedIndex == -1)
			{
				return;
			}
			//Come Here - for employee id change
			ViewModel.lbEmpID.Text = ViewModel.cboEmpList.Text.Substring(Math.Max(ViewModel.cboEmpList.Text.Length - 5, 0));
			ViewModel.lbAddressID.Text = "";
			LoadAddressList();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAdd_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				int str1 = 0;
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult) 0;
				//DbCommand oRec = null;
				//string strl = "";
				string str2 = "";
				int i = 0;

				//Check cmdAdd.Tag to see if fields need cleared...
				if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(Convert.ToString(ViewModel.cmdAdd.Tag)) == 1)
				{
					//Unselect row in the Address List Box
					for (i = 0; i <= ViewModel.lstAddress.Items.Count - 1; i++)
					{
						UpgradeHelpers.Helpers.ListBoxHelper.SetSelected(ViewModel.lstAddress, i, false);
					}

					// Clear fields
					ViewModel.txtAddress.Text = "";
					ViewModel.txtCity.Text = "";
					ViewModel.txtState.Text = "";
					ViewModel.txtZip.Text = "";
					ViewModel.txtComment.Text = "";
					ViewModel.cboType.Text = "";

					// Reset buttons...
					ViewModel.cmdAdd.Tag = "2";
					ViewModel.cmdAdd.Text = "&Add New Address";
					ViewModel.cmdDelete.Visible = false;
					ViewModel.cmdUpdate.Visible = false;

					//Set Focus
					ViewManager.SetCurrent(

//Set Focus
ViewModel.txtAddress);
					this.Return();
					return ;
				}

				//Edit Fields
				ViewModel.txtAddress.Text = ViewModel.txtAddress.Text.Trim();
				if ( ViewModel.txtAddress.Text == "")
				{
					ViewManager.ShowMessage("You must enter a Address !!", "Insert New Address", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					ViewManager.SetCurrent(ViewModel.txtAddress);
					this.Return();
					return ;
				}
				ViewModel.cboType.Text = ViewModel.cboType.Text.Trim();
				if ( ViewModel.cboType.Text == "")
				{
					async1.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager
							.ShowMessage("No Address Type was selected. Default to 'Unknown' " + "?? ", "Insert New Address", UpgradeHelpers.Helpers.BoxButtons.OKCancel));
					async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
					async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
						{
							Response = tempNormalized1;
						});
					async1.Append(() =>
						{
							if (Response == UpgradeHelpers.Helpers.DialogResult.Cancel)
							{
								ViewManager.SetCurrent(ViewModel.cboType);
								this.Return();
								return ;
							}
							else
							{
								ViewModel.cboType.Text = "Unknown";
							}
						});
						}
				async1.Append(() =>
					{
						ViewModel.txtCity.Text = ViewModel.txtCity.Text.Trim();
						if ( ViewModel.txtCity.Text == "")
						{
							ViewManager.ShowMessage("You must enter a City !!", "Insert New Address", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							ViewManager.SetCurrent(ViewModel.txtCity);
							this.Return();
							return ;
						}
						ViewModel.txtState.Text = ViewModel.txtState.Text.Trim();
						if ( ViewModel.txtState.Text == "")
						{
							ViewManager.ShowMessage("You must enter a State !!", "Insert New Address", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							ViewManager.SetCurrent(ViewModel.txtState);
							this.Return();
							return ;
						}
						ViewModel.txtZip.Text = ViewModel.txtZip.Text.Trim();
						if ( ViewModel.txtCity.Text == "")
						{
							ViewManager.ShowMessage("You must enter a Zip Code !!", "Insert New Address", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							ViewManager.SetCurrent(ViewModel.txtZip);
							this.Return();
							return ;
						}

						string CommStr = ViewModel.txtComment.Text.Trim();

						while((CommStr.IndexOf('\'') + 1) != 0)
						{
							i = (CommStr.IndexOf('\'') + 1);
							str1 = Convert.ToInt32(Double.Parse(CommStr.Substring(0, Math.Min(i - 1, CommStr.Length))));
							str2 = CommStr.Substring(Math.Max(CommStr.Length - (Strings.Len(CommStr) - i), 0));
							CommStr = str1.ToString() + "-" + str2;
						}
						;
						ViewModel.txtComment.Text = CommStr.Substring(0, Math.Min(255, CommStr.Length));

						//Execute spInsertPersonnelAddress
						oCmd.Connection = modGlobal.oConn;
						oCmd.CommandType = CommandType.Text;

						oCmd.CommandText = "spInsertPersonnelAddress '" + ViewModel.lbEmpID.Text + "','" + ViewModel.txtAddress.Text +
													"','" + ViewModel.txtCity.Text + "','" + ViewModel.txtZip.Text + "','" + ViewModel.txtComment.Text + "','" + ViewModel.cboType.Text + "','" + ViewModel.txtState.Text + "'";
						oCmd.ExecuteNonQuery();

						//Refresh Screen
						LoadAddressList();
					});
			}

					}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdDelete_Click(Object eventSender, System.EventArgs eventArgs)
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			//DbCommand oRec = null;

			if ( ViewModel.lbAddressID.Text == "0")
			{
				return;
			}

			//Execute spDeletePersonnelAddress
			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			oCmd.CommandText = "spDeletePersonnelAddress '" + ViewModel.lbAddressID.Text + "'";
			oCmd.ExecuteNonQuery();

			//Refresh Screen
			LoadAddressList();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdUpdate_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				int str1 = 0;
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult) 0;
				//DbCommand oRec = null;
				//string strl = "";
				string str2 = "";
				int i = 0;

				//Edit Fields
				ViewModel.txtAddress.Text = ViewModel.txtAddress.Text.Trim();
				if ( ViewModel.txtAddress.Text == "")
				{
					ViewManager.ShowMessage("You must enter a Address !!", "Insert New Address", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					ViewManager.SetCurrent(ViewModel.txtAddress);
					this.Return();
					return ;
				}
				ViewModel.cboType.Text = ViewModel.cboType.Text.Trim();
				if ( ViewModel.cboType.Text == "")
				{
					async1.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager
							.ShowMessage("No Address Type was selected. Default to 'Unknown' " + "?? ", "Insert New Address", UpgradeHelpers.Helpers.BoxButtons.OKCancel));
					async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
					async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
						{
							Response = tempNormalized1;
						});
					async1.Append(() =>
						{
							if (Response == UpgradeHelpers.Helpers.DialogResult.Cancel)
							{
								ViewManager.SetCurrent(ViewModel.cboType);
								this.Return();
								return ;
							}
							else
							{
								ViewModel.cboType.Text = "Unknown";
							}
						});
						}
				async1.Append(() =>
					{
						ViewModel.txtCity.Text = ViewModel.txtCity.Text.Trim();
						if ( ViewModel.txtCity.Text == "")
						{
							ViewManager.ShowMessage("You must enter a City !!", "Insert New Address", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							ViewManager.SetCurrent(ViewModel.txtCity);
							this.Return();
							return ;
						}
						ViewModel.txtState.Text = ViewModel.txtState.Text.Trim();
						if ( ViewModel.txtState.Text == "")
						{
							ViewManager.ShowMessage("You must enter a State !!", "Insert New Address", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							ViewManager.SetCurrent(ViewModel.txtState);
							this.Return();
							return ;
						}
						ViewModel.txtZip.Text = ViewModel.txtZip.Text.Trim();
						if ( ViewModel.txtCity.Text == "")
						{
							ViewManager.ShowMessage("You must enter a Zip Code !!", "Insert New Address", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							ViewManager.SetCurrent(ViewModel.txtZip);
							this.Return();
							return ;
						}

						string CommStr = ViewModel.txtComment.Text.Trim();

						while((CommStr.IndexOf('\'') + 1) != 0)
						{
							i = (CommStr.IndexOf('\'') + 1);
							str1 = Convert.ToInt32(Double.Parse(CommStr.Substring(0, Math.Min(i - 1, CommStr.Length))));
							str2 = CommStr.Substring(Math.Max(CommStr.Length - (Strings.Len(CommStr) - i), 0));
							CommStr = str1.ToString() + "-" + str2;
						}
						;
						ViewModel.txtComment.Text = CommStr.Substring(0, Math.Min(255, CommStr.Length));

						//Execute spUpdatePersonnelAddress
						oCmd.Connection = modGlobal.oConn;
						oCmd.CommandType = CommandType.Text;

						oCmd.CommandText = "spUpdatePersonnelAddress '" + ViewModel.lbAddressID.Text + "','" + ViewModel.lbEmpID.Text + "','" + Strings.Replace
																	(ViewModel.txtAddress.Text, "'", "''", 1, -1, CompareMethod.Binary) + "','" +
													ViewModel.txtCity.Text + "','" + ViewModel.txtZip.Text + "','" + ViewModel.txtComment.Text + "','" + ViewModel.cboType.Text + "','" + ViewModel.txtState.Text + "'";
						oCmd.ExecuteNonQuery();

						//Refresh Screen
						LoadAddressList();
					});
			}

					}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			// Set to Current Employee if called from Update Screen

			FillNameList();

			if (modGlobal.Shared.gAssignID != "")
			{
				FindEmployee();
				LoadAddressList();
			}
			else
			{
				// clear fields
				ViewModel.txtAddress.Text = "";
				ViewModel.txtCity.Text = "";
				ViewModel.txtState.Text = "";
				ViewModel.txtZip.Text = "";
				ViewModel.txtComment.Text = "";
				ViewModel.cboType.Text = "";
			}

			//fill Address Type dropdown list
			ViewModel.cboType.AddItem("Home", 0);
			ViewModel.cboType.AddItem("Mailing", 1);
			ViewModel.cboType.AddItem("Unknown", 2);

		}

		[UpgradeHelpers.Events.Handler]
		internal void lstAddress_SelectedIndexChanged(Object eventSender, System.EventArgs eventArgs)
		{

			if ( ViewModel.lstAddress.SelectedIndex == -1)
			{
				return;
			}
			ViewModel.lbAddressID.Text = ViewModel.lstAddress.GetItemData(ViewModel.lstAddress.SelectedIndex).ToString();

			GetAddressDetail();

			//Reset Buttons
			ViewModel.cmdUpdate.Visible = true;
			ViewModel.cmdDelete.Visible = true;
			ViewModel.cmdAdd.Visible = true;
			ViewModel.cmdAdd.Tag = "1";
			ViewModel.cmdAdd.Text = "New &Address";

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmAddress DefInstance
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

		public static frmAddress CreateInstance()
		{
			PTSProject.frmAddress theInstance = Shared.Container.Resolve< frmAddress>();
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

	public partial class frmAddress
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmAddressViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmAddress m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}