using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.Globalization;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class frmNewPromo
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmNewPromoViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmNewPromo));
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


		private void frmNewPromo_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		//******************************************************
		//New Promotion Form
		//Called from Update Employee or Assign Position forms
		//uses Global gAssignID to determine Employee to promote
		//******************************************************
		//ADODB
		[UpgradeHelpers.Events.Handler]
		internal void cmdAddPromo_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Find Next System Promotion key
			//Validate data entry fields
			//Insert New Promotion Record

			int NewKey = 0;
			int ExclusionDays = 0;
			string PromoType = "";
			byte PromoStatus = 0;
			string PromoDate = "";
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			DbCommand oCmdInsert = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			int OldPromos = 0;

			try
			{

				//Edit new Promotion record fields
				if (Information.IsDate(ViewModel.txtPromotionDate.Text))
				{
					//Valid date
					PromoDate = ViewModel.txtPromotionDate.Text;
				}
				else
				{
					ViewManager.ShowMessage("Promotion Date is invalid", "Add New Promotion Error", UpgradeHelpers.Helpers.BoxButtons.OK);
					ViewManager.SetCurrent(ViewModel.txtPromotionDate);
					ViewModel.txtPromotionDate.SelectionStart = 0;
					ViewModel.txtPromotionDate.SelectionLength = Strings.Len(ViewModel.txtPromotionDate.Text);
					return;
				}

				double dbNumericTemp = 0;
				if (!Double.TryParse(ViewModel.txtEDays.Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
					if (Convert.IsDBNull(ViewModel.txtEDays.Text) || ViewModel.txtEDays.Text == "")
					{
						//no exclusion days entered
						ViewModel.txtEDays.Text = "0";
						ExclusionDays = 0;
					}
					else
					{
						ViewManager.ShowMessage("Exclusion Days must be numeric", "Add New Promotion Error", UpgradeHelpers.Helpers.BoxButtons.OK);
						ViewManager.SetCurrent(ViewModel.txtEDays);
						ViewModel.txtEDays.SelectionStart = 0;
						ViewModel.txtEDays.SelectionLength = Strings.Len(ViewModel.txtEDays.Text);
						return;
					}
				}
				else
				{
					ExclusionDays = Convert.ToInt32(Conversion.Val(ViewModel.txtEDays.Text));
				}
				PromoType = Conversion.Str(ViewModel.cboPromotion.GetItemData(ViewModel.cboPromotion.SelectedIndex)).Trim();
				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "SELECT next_id = MAX(promotion_id) + 1 From Promotion";
				oRec = ADORecordSetHelper.Open(oCmd, "");

				NewKey = Convert.ToInt32(oRec["next_id"]);

				oCmd.CommandType = CommandType.StoredProcedure;

				//If new promotion to be active
				//Determine if older promotions exist and mark them as inactive
				if ( ViewModel.chkStatus.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked)
				{
					oCmd.CommandText = "spUpdatePromotionStatus";
					oCmd.ExecuteNonQuery(new object[] { modGlobal.Shared.gAssignID, 0 });
                    OldPromos = 1;
                    PromoStatus = 1;
				}
				else
				{
					OldPromos = -1;
					PromoStatus = 0;
				}

				//Add New Promotion Record
				oCmdInsert.Connection = modGlobal.oConn;
				oCmdInsert.CommandType = CommandType.Text;

				oCmdInsert.CommandText = "spInsertPromotion " + NewKey.ToString() + ", '" + modGlobal.Shared.gAssignID + "','" + PromoType +
								"','" + PromoDate + "'," + ExclusionDays.ToString() + "," + PromoStatus.ToString() + ",'" + ViewModel.txtComments.Text.Trim() + "'";
				oCmdInsert.ExecuteNonQuery();

				//Display Add New Promotion Results
				if (OldPromos > 0)
				{
					ViewManager.ShowMessage("New Active Promotion Record successfully added, " + "older promotions marked as inactive", "Add New Promotion", UpgradeHelpers.Helpers.BoxButtons.OK);
				}
				else if (OldPromos == 0)
				{
					ViewManager.ShowMessage("New Active Promotion Record successfully added", "Add New Promotion", UpgradeHelpers.Helpers.BoxButtons.OK);
				}
				else if (OldPromos == -1)
				{
					ViewManager.ShowMessage("New Inactive Promotion Record successfully added,", "Add New Promotion", UpgradeHelpers.Helpers.BoxButtons.OK);
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

		[UpgradeHelpers.Events.Handler]
		internal void cmdCancel_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			//Look up Employee Information
			//Load Promotion List box

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			//string strSQL = "";

			try
			{

				//Establish data connection
				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;

				//Retrieve Employee Name
				oCmd.CommandText = "Select * from Personnel Where employee_id = '" + modGlobal.Shared.gAssignID + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				ViewModel.lbName.Text = Convert.ToString(oRec["name_full"]);

				//Load Promotion Lists listbox
				oCmd.CommandText = "select * from Promotion_Code";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				ViewModel.cboPromotion.Items.Clear();

				while(!oRec.EOF)
				{
					ViewModel.cboPromotion.AddItem(Convert.ToString(oRec["description"]));
					ViewModel.cboPromotion.SetItemData(ViewModel.cboPromotion.GetNewIndex(), Convert.ToInt32(Conversion.Val(Convert.ToString(oRec["promotion_code_id"]))));
					oRec.MoveNext();
				};
				ViewModel.txtEDays.Text = "0";
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

		public static frmNewPromo DefInstance
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

		public static frmNewPromo CreateInstance()
		{
			PTSProject.frmNewPromo theInstance = Shared.Container.Resolve< frmNewPromo>();
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
			ViewModel.Shape1.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.Shape1.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmNewPromo
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmNewPromoViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmNewPromo m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}