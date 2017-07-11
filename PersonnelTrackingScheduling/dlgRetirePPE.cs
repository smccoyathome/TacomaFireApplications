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

	public partial class dlgRetirePPE
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgRetirePPEViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(dlgRetirePPE));
			if ( Shared.m_vb6FormDefInstance == null)
			{
				if ( Shared.m_InitializingDefInstance)
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
		}


		private void dlgRetirePPE_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}


		public void ClearDetailFields()
		{
			ViewModel.txtTrackingNumber.Text = "";
			ViewModel.cboReason.SelectedIndex = -1;
			ViewModel.cboReason.Text = "";
			ViewModel.txtComment.Text = "";
			ViewModel.dteRetired.Text = DateTime.Now.ToString("MM/dd/yyyy");
			ViewModel.cboItemType.SelectedIndex = -1;
			ViewModel.cboItemType.Text = "";
			ViewModel.cboColorSize.SelectedIndex = -1;
			ViewModel.cboColorSize.Text = "";
			ViewModel.cboItemBrand.SelectedIndex = -1;
			ViewModel.cboItemBrand.Text = "";
			ViewModel.chkManufDate.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.dteManufDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
			ViewModel.dteManufDate.Visible = false;

		}


		public void LoadUniformFields()
		{
			PTSProject.clsUniform cUniform = Container.Resolve< clsUniform>();

			if (cUniform.GetUniformByID(Convert.ToInt32(Double.Parse(ViewModel.lbUniformID.Text))) != 0)
			{

			}
			else
			{
				ViewManager.ShowMessage("Could not find the Uniform in the Database.", "Find Uniform", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}
			ViewModel.txtTrackingNumber.Text = cUniform.UniformTrackingNumber;
			if (cUniform.UniformManufacturedDate != "")
			{
				ViewModel.dteManufDate.Text = cUniform.UniformManufacturedDate;
				ViewModel.chkManufDate.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
				ViewModel.dteManufDate.Visible = true;
			}
			else
			{
				ViewModel.dteManufDate.Text = DateTime.Now.AddDays(-30).ToString("MM/dd/yyyy");
				ViewModel.chkManufDate.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
				ViewModel.dteManufDate.Visible = false;
			}

			for (int i = 0; i <= ViewModel.cboItemType.Items.Count - 1; i++)
			{
				if (cUniform.UniformType == ViewModel.cboItemType.GetItemData(i))
				{
					ViewModel.cboItemType.SelectedIndex = i;
					break;
				}
			}

			if (cUniform.UniformManufacturerID != 0)
			{
				for (int i = 0; i <= ViewModel.cboItemBrand.Items.Count - 1; i++)
				{
					if ( ViewModel.cboItemBrand.GetItemData(i) == cUniform.UniformManufacturerID)
					{
						ViewModel.cboItemBrand.SelectedIndex = i;
						break;
					}
				}
			}
			else
			{
				ViewModel.cboItemBrand.SelectedIndex = -1;
			}

			if (cUniform.UniformSizeType != 0)
			{
				for (int i = 0; i <= ViewModel.cboColorSize.Items.Count - 1; i++)
				{
					if ( ViewModel.cboColorSize.GetItemData(i) == cUniform.UniformSizeType)
					{
						ViewModel.cboColorSize.SelectedIndex = i;
						break;
					}
				}
			}
			else if (cUniform.UniformColorType != 0)
			{
				for (int i = 0; i <= ViewModel.cboColorSize.Items.Count - 1; i++)
				{
					if ( ViewModel.cboColorSize.GetItemData(i) == cUniform.UniformColorType)
					{
						ViewModel.cboColorSize.SelectedIndex = i;
						break;
					}
				}
			}
			else
			{
				ViewModel.cboColorSize.SelectedIndex = -1;
			}



		}

		public void FillLists()
		{
			//Retrieve & fill Grid lists for Manuactures & Sizes & Color (Helmet only)
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//fill dropdown list for Uniform Types (Coat, Pants, Boots, etc.)
			string strSQL = "spSelect_UniformTypeList ";

			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboItemType.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboItemType.AddItem(modGlobal.Clean(oRec["description"]));
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.cboItemType.SetItemData(ViewModel.cboItemType.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["uniform_type"])));

				oRec.MoveNext();
			};

			//fill dropdown list for Uniform Inventory Stations
			strSQL = "spSelect_UniformInventoryStationList ";

			oCmd.CommandText = strSQL;
			oRec = ADORecordSetHelper.Open(oCmd, "");


			//fill dropdown list for Uniform Retirement Reason
			strSQL = "spSelect_UniformRetirementReasonList ";

			oCmd.CommandText = strSQL;
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboReason.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboReason.AddItem(modGlobal.Clean(oRec["reason_description"]));
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.cboReason.SetItemData(ViewModel.cboReason.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["reason_id"])));
				oRec.MoveNext();
			};

			//these dropdowns are filled after an PPE Item Type is selected...
			ViewModel.cboItemBrand.Items.Clear();
			ViewModel.cboColorSize.Items.Clear();



		}

		//UPGRADE_WARNING: (2074) ComboBox event cboItemType.Change was upgraded to cboItemType.TextChanged which has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2074.aspx
		[UpgradeHelpers.Events.Handler]
		internal void cboItemType_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.isInitializingComponent)
			{
				return;
			}
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			if ( ViewModel.cboItemType.SelectedIndex == -1)
			{
				return;
			}

			int iItemType = ViewModel.cboItemType.GetItemData(ViewModel.cboItemType.SelectedIndex);
			ViewModel.cboItemBrand.Items.Clear();
			ViewModel.cboColorSize.Items.Clear();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//fill Manufacturer for Selected Uniform Type
			string strSQL = "spSelect_UniformManufacturerByItemType " + iItemType.ToString() + " ";
			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (oRec.EOF)
			{
				ViewModel.lbItemBrand.Text = "";
				ViewModel.cboItemBrand.Enabled = false;
				ViewModel.cboItemBrand.Visible = false;
				ViewModel.cboItemBrand.SelectedIndex = -1;
				ViewModel.cboItemBrand.Text = "";
			}
			else
			{
				ViewModel.lbItemBrand.Text = "Brand/Manufacturer";
				ViewModel.cboItemBrand.Enabled = true;
				ViewModel.cboItemBrand.Visible = true;

				while(!oRec.EOF)
				{
					ViewModel.cboItemBrand.AddItem(modGlobal.Clean(oRec["manufacturer_name"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.cboItemBrand.SetItemData(ViewModel.cboItemBrand.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["manufacturer_id"])));
					oRec.MoveNext();
				}
				;
							}

							//fill in Size  for Selected Uniform Type
							strSQL = "spSelect_UniformSizeCodeByItemType " + iItemType.ToString() + " ";
							oCmd.CommandText = strSQL;
							oRec = ADORecordSetHelper.Open(oCmd, "");

							if (oRec.EOF)
							{
								//fill in Color for Selected Uniform Type
								strSQL = "spSelect_UniformColorCodeByItemType " + iItemType.ToString() + " ";
								oCmd.CommandText = strSQL;
								oRec = ADORecordSetHelper.Open(oCmd, "");
								if (oRec.EOF)
								{
					ViewModel.cboColorSize.Text = "";
					ViewModel.cboColorSize.SelectedIndex = -1;
					ViewModel.cboColorSize.Enabled = false;
					ViewModel.lbItemColorSize.Text = "";
					ViewModel.cboColorSize.Visible = false;
				}
				else
				{
					ViewModel.lbItemColorSize.Text = "Color";
					ViewModel.cboColorSize.Enabled = true;
					ViewModel.cboColorSize.Visible = true;

					while(!oRec.EOF)
					{
						ViewModel.cboColorSize.AddItem(modGlobal.Clean(oRec["description"]));
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.cboColorSize.SetItemData(ViewModel.cboColorSize.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["color_type"])));
						oRec.MoveNext();
					}
					;
									}

								}
								else
								{
				ViewModel.lbItemColorSize.Text = "Size";
				ViewModel.cboColorSize.Enabled = true;
				ViewModel.cboColorSize.Visible = true;

				while(!oRec.EOF)
				{
					ViewModel.cboColorSize.AddItem(modGlobal.Clean(oRec["description"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.cboColorSize.SetItemData(ViewModel.cboColorSize.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["size_type"])));
					oRec.MoveNext();
				}
				;
							}
			ViewModel.cmdEditItem.Enabled = true;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboItemType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			if ( ViewModel.cboItemType.SelectedIndex == -1)
			{
				return;
			}

			int iItemType = ViewModel.cboItemType.GetItemData(ViewModel.cboItemType.SelectedIndex);
			ViewModel.cboItemBrand.Items.Clear();
			ViewModel.cboColorSize.Items.Clear();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//fill Manufacturer for Selected Uniform Type
			string strSQL = "spSelect_UniformManufacturerByItemType " + iItemType.ToString() + " ";
			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (oRec.EOF)
			{
				ViewModel.lbItemBrand.Text = "";
				ViewModel.cboItemBrand.Enabled = false;
				ViewModel.cboItemBrand.Visible = false;
				ViewModel.cboItemBrand.SelectedIndex = -1;
				ViewModel.cboItemBrand.Text = "";
			}
			else
			{
				ViewModel.lbItemBrand.Text = "Brand/Manufacturer";
				ViewModel.cboItemBrand.Enabled = true;
				ViewModel.cboItemBrand.Visible = true;

				while(!oRec.EOF)
				{
					ViewModel.cboItemBrand.AddItem(modGlobal.Clean(oRec["manufacturer_name"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.cboItemBrand.SetItemData(ViewModel.cboItemBrand.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["manufacturer_id"])));
					oRec.MoveNext();
				}
				;
							}

							//fill in Size  for Selected Uniform Type
							strSQL = "spSelect_UniformSizeCodeByItemType " + iItemType.ToString() + " ";
							oCmd.CommandText = strSQL;
							oRec = ADORecordSetHelper.Open(oCmd, "");

							if (oRec.EOF)
							{
								//fill in Color for Selected Uniform Type
								strSQL = "spSelect_UniformColorCodeByItemType " + iItemType.ToString() + " ";
								oCmd.CommandText = strSQL;
								oRec = ADORecordSetHelper.Open(oCmd, "");
								if (oRec.EOF)
								{
					ViewModel.cboColorSize.Text = "";
					ViewModel.cboColorSize.SelectedIndex = -1;
					ViewModel.cboColorSize.Enabled = false;
					ViewModel.lbItemColorSize.Text = "";
					ViewModel.cboColorSize.Visible = false;
				}
				else
				{
					ViewModel.lbItemColorSize.Text = "Color";
					ViewModel.cboColorSize.Enabled = true;
					ViewModel.cboColorSize.Visible = true;

					while(!oRec.EOF)
					{
						ViewModel.cboColorSize.AddItem(modGlobal.Clean(oRec["description"]));
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.cboColorSize.SetItemData(ViewModel.cboColorSize.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["color_type"])));
						oRec.MoveNext();
					}
					;
									}

								}
								else
								{
				ViewModel.lbItemColorSize.Text = "Size";
				ViewModel.cboColorSize.Enabled = true;
				ViewModel.cboColorSize.Visible = true;

				while(!oRec.EOF)
				{
					ViewModel.cboColorSize.AddItem(modGlobal.Clean(oRec["description"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.cboColorSize.SetItemData(ViewModel.cboColorSize.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["size_type"])));
					oRec.MoveNext();
				}
				;
							}
			ViewModel.cmdEditItem.Enabled = true;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdEditItem_Click(Object eventSender, System.EventArgs eventArgs)
		{
			PTSProject.clsUniform cUniform = Container.Resolve< clsUniform>();

			//    MsgBox "This feature is under construction!", vbOKOnly, "Updating Return Date / Inserting Retired Record"

			try
			{

				//if there is no UniformID or EmployeeID... should not be here...
				if (modGlobal.Clean(ViewModel.lbUniformID.Text) == "")
				{
					return;
				}

				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				cUniform.UniformID = Convert.ToInt32(modGlobal.GetVal(ViewModel.lbUniformID.Text));

				//Edit Information & gather variables
				if (cUniform.GetUniformByID(cUniform.UniformID) != 0)
				{
					cUniform.UniformReasonRetiredUniformID = cUniform.UniformID;
					cUniform.UniformReasonRetiredCreatedBy = modGlobal.Shared.gUser;
					cUniform.UniformReasonRetiredCreatedDate = UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now);
					//Get Rid of any UniformInventory record
					if (cUniform.DeleteUniformInventory(cUniform.UniformID) != 0)
					{
						//all is well either way
					}
				}
				else
				{
					ViewManager.ShowMessage("Could not find the Uniform in the Database.", "Find Uniform", UpgradeHelpers.Helpers.BoxButtons.OK);
					return;
				}

				cUniform.UniformRetiredDate = DateTime.Parse(ViewModel.dteRetired.Text).ToString("MM/dd/yyyy");
				cUniform.UniformReasonRetiredReasonID = 0;
				if ( ViewModel.cboReason.SelectedIndex != -1)
				{
					cUniform.UniformReasonRetiredReasonID = ViewModel.cboReason.GetItemData(ViewModel.cboReason.SelectedIndex);
				}
				cUniform.UniformReasonRetiredComment = modGlobal.Clean(ViewModel.txtComment.Text);

				if ( ViewModel.cboItemType.GetItemData(ViewModel.cboItemType.SelectedIndex) != cUniform.UniformType)
				{
					ViewManager.ShowMessage("You can not change the PPE type.", "Update PPE Item", UpgradeHelpers.Helpers.BoxButtons.OK);
					for (int i = 0; i <= ViewModel.cboItemType.Items.Count - 1; i++)
					{
						if ( ViewModel.cboItemType.GetItemData(i) == cUniform.UniformType)
						{
							ViewModel.cboItemType.SelectedIndex = i;
							break;
						}
					}
				}

				cUniform.UniformTrackingNumber = modGlobal.Clean(ViewModel.txtTrackingNumber.Text);

				cUniform.UniformColorType = 0;
				cUniform.UniformSizeType = 0;
				if ( ViewModel.cboColorSize.Visible)
				{
					if ( ViewModel.cboColorSize.SelectedIndex == -1)
					{
						//continue
					}
					else
					{
						if ( ViewModel.lbItemColorSize.Text == "Color")
						{
							cUniform.UniformColorType = ViewModel.cboColorSize.GetItemData(ViewModel.cboColorSize.SelectedIndex);
						}
						else
						{
							cUniform.UniformSizeType = ViewModel.cboColorSize.GetItemData(ViewModel.cboColorSize.SelectedIndex);
						}
					}
				}

				cUniform.UniformManufacturerID = 0;
				if ( ViewModel.cboItemBrand.Visible)
				{
					if ( ViewModel.cboItemBrand.SelectedIndex == -1)
					{
						//continue
					}
					else
					{
						cUniform.UniformManufacturerID = ViewModel.cboItemBrand.GetItemData(ViewModel.cboItemBrand.SelectedIndex);
					}
				}

				if ( ViewModel.chkManufDate.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
				{
					cUniform.UniformManufacturedDate = "";
				}
				else if (((int) DateAndTime.DateDiff("d", DateTime.Now, DateTime.Parse(DateTime.Parse(ViewModel.dteManufDate.Text).ToString("MM/dd/yyyy")), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) > 0)
				{
					ViewManager.ShowMessage("Manufactured Date can not be in the future.", "Manufactured Date Error", UpgradeHelpers.Helpers.BoxButtons.OK);
					return;
				}
				else
				{
					cUniform.UniformManufacturedDate = DateTime.Parse(ViewModel.dteManufDate.Text).ToString("MM/dd/yyyy");
				}


				if (cUniform.UpdateUniform() != 0)
				{
					if (cUniform.InsertUniformReasonRetiredInfo() != 0)
					{
						ViewManager.ShowMessage("PPE Item / Retired Info has been successfully updated.", "Update PPE Item Retired Info", UpgradeHelpers.Helpers.BoxButtons.OK);
					}
					else
					{
						ViewManager.ShowMessage("Ooops!  Error Updating PersonnelUniform record.  Call Debra Lewandowsky x5068.", "Error Updating PersonnelUniform", UpgradeHelpers.Helpers.BoxButtons.OK);
					}
				}
				else
				{
					ViewManager.ShowMessage("Ooops!  Error Updating Uniform record.  Call Debra Lewandowsky x5068.", "Error Updating Uniform", UpgradeHelpers.Helpers.BoxButtons.OK);
				}
				ViewManager.DisposeView(this);
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
			ViewModel.lbUniformID.Text = modGlobal.Shared.gUniformID.ToString();
			FillLists();
			ClearDetailFields();
			LoadUniformFields();
			ViewModel.cmdEditItem.Enabled = true;

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static dlgRetirePPE DefInstance
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

		public static dlgRetirePPE CreateInstance()
		{
			PTSProject.dlgRetirePPE theInstance = Shared.Container.Resolve< dlgRetirePPE>();
			theInstance.Form_Load();
			return theInstance;
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

	public partial class dlgRetirePPE
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgRetirePPEViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual dlgRetirePPE m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}