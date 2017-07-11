using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class dlgTrainingCodes
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgTrainingCodesViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(dlgTrainingCodes));
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


		private void dlgTrainingCodes_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}


		public void FillList()
		{
			//Retrieve & fill Grid lists for Manuactures & Sizes & Color (Helmet only)
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//fill dropdown list for Uniform Types (Coat, Pants, Boots, etc.)
			string strSQL = "spSelect_TrainingSpecificSearchList ";

			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboSpecificCodes.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboSpecificCodes.AddItem(modGlobal.Clean(oRec["SpecificCode"]) + "   (" + modGlobal.Clean(oRec["ParentCodes"]) + ")");
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.cboSpecificCodes.SetItemData(ViewModel.cboSpecificCodes.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["trn_specific_code"])));
				oRec.MoveNext();
			};

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboSpecificCodes_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Add logic to find this code in the tree...


			if ( ViewModel.cboSpecificCodes.SelectedIndex == -1)
			{
				return;
			}

			string sKey = "S2-" + ViewModel.cboSpecificCodes.GetItemData(ViewModel.cboSpecificCodes.SelectedIndex).ToString();

			int tempForVar = ViewModel.tvwTraining.Items.Count;
			for (int i = 1; i <= tempForVar; i++)
			{
				if (modGlobal.Clean(ViewModel.tvwTraining.Items[i - 1].Name) == modGlobal.Clean(sKey))
				{
					ViewModel.tvwTraining.Items[i - 1].Expand();
					ViewModel.tvwTraining.Items[i - 1].GetTreeViewModel().SelectedNode = ViewModel.tvwTraining.Items[i - 1];
					ViewModel.cmdExpand.Tag = "0";
					ViewModel.cmdExpand.Text = "Collapse All";
					break;
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdExit_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdExpand_Click(Object eventSender, System.EventArgs eventArgs)
		{

			if (Convert.ToString(ViewModel.cmdExpand.Tag) == "1")
			{

				int tempForVar = ViewModel.tvwTraining.Items.Count;
				for (int i = 1; i <= tempForVar; i++)
				{
					// Expand all nodes.
					ViewModel.tvwTraining.Items[i - 1].Expand();
				}
				ViewModel.tvwTraining.Items[0].GetTreeViewModel().SelectedNode = ViewModel.tvwTraining.Items[0];
				ViewModel.cmdExpand.Tag = "0";
				ViewModel.cmdExpand.Text = "Collapse All";
			}
			else
			{

				int tempForVar2 = ViewModel.tvwTraining.Items.Count;
				for (int i = 1; i <= tempForVar2; i++)
				{
					// Expand all nodes.
					ViewModel.tvwTraining.Items[i - 1].Collapse();
				}
				ViewModel.tvwTraining.Items[0].GetTreeViewModel().SelectedNode = null;
				ViewModel.cboSpecificCodes.SelectedIndex = -1;
				ViewModel.cmdExpand.Tag = "1";
				ViewModel.cmdExpand.Text = "Expand All";
			}

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRecSecondary = null;
			ADORecordSetHelper oRecSpecific = null;
			string sKey = "";
			int intIndex = 0;
			int intNext = 0;
			UpgradeHelpers.BasicViewModels.TreeNodeViewModel mNode = null;

			//Configure TreeView Control
			ViewModel.tvwTraining.Set_Sorted(false);
			ViewModel.tvwTraining.LabelEdit = true;
			ViewModel.cboSpecificCodes.SelectedIndex = -1;
			ViewModel.cmdExpand.Tag = "1";

			//Load Training Type TreeView Control
			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandText = "spTrainingNew_GetAllPrimaryCodes";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			while(!oRec.EOF)
			{
				mNode = ViewModel.tvwTraining.Add("");
				mNode.Text = Convert.ToString(oRec["description"]);
				sKey = "P-" + Convert.ToString(oRec["trn_primary_code"]);
				mNode.Name = sKey;
				//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.TreeNode.Tag was not upgraded
				mNode.Set_Tag( "Level1");
				intIndex = mNode.Index + 1;
				oCmd.CommandText = "spTrainingNew_GetAllSecondaryCodesByPrimary " + Convert.ToString(oRec["trn_primary_code"]) + " ";
				oRecSecondary = ADORecordSetHelper.Open(oCmd, "");

				while(!oRecSecondary.EOF)
				{
					mNode = ViewModel.tvwTraining.Items.Find(intIndex.ToString(), true)[0].Add("");
					mNode.Text = Convert.ToString(oRecSecondary["description"]).Trim();
					sKey = "S-" + Convert.ToString(oRecSecondary["trn_secondary_code"]);
					mNode.Name = sKey;
					//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.TreeNode.Tag was not upgraded
					mNode.Set_Tag( "Level2");


					intNext = mNode.Index + 1;

					oCmd.CommandText = "spTrainingNew_GetAllSpecificCodesBySecondary " + Convert.ToString(oRecSecondary["trn_secondary_code"]) + " ";
					oRecSpecific = ADORecordSetHelper.Open(oCmd, "");

					while(!oRecSpecific.EOF)
					{
						mNode = ViewModel.tvwTraining.Items.Find(intNext.ToString(), true)[0].Add("");
						mNode.Text = Convert.ToString(oRecSpecific["description"]).Trim();
						sKey = "S2-" + Convert.ToString(oRecSpecific["trn_specific_code"]);
						mNode.Name = sKey;
						//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.TreeNode.Tag was not upgraded
						mNode.Set_Tag( "Level3");
						oRecSpecific.MoveNext();
					};
					oRecSecondary.MoveNext();
				};
				oRec.MoveNext();
			};
			FillList();

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static dlgTrainingCodes DefInstance
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

		public static dlgTrainingCodes CreateInstance()
		{
			PTSProject.dlgTrainingCodes theInstance = Shared.Container.Resolve< dlgTrainingCodes>();
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

	public partial class dlgTrainingCodes
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgTrainingCodesViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual dlgTrainingCodes m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}