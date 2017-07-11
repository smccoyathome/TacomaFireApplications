using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Text;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident
{

	public partial class frmHelp
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.frmHelpViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmHelp));
			if ( Shared.m_vb6FormDefInstance == null)
			{
				if ( Shared.m_InitializingDefInstance)
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
		}


		private void frmHelp_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		private void GetHelpText()
		{
			TFDIncident.clsCommonCodes cCommon = Container.Resolve< clsCommonCodes>();

			if (~cCommon.GetHelpText(IncidentMain.Shared.gHelpScreen, IncidentMain.Shared.gHelpControl) != 0)
			{
				ViewModel.lbHelpTitle.Text = "No Help Topic Found for this Screen";
				ViewModel.txtHelpText.Text = "";
				ViewModel.cmdCode.Enabled = false;
				return;
			}
			ViewModel.lbHelpTitle.Text = IncidentMain.Clean(cCommon.HelpText["help_title"]);
			ViewModel.txtHelpText.Text = IncidentMain.Clean(cCommon.HelpText["help_text"]);
			ViewModel.CurrentHelpID = Convert.ToInt32(cCommon.HelpText["help_id"]);
			ViewModel.cmdCode.Enabled = cCommon.GetHelpCodes(ViewModel.CurrentHelpID) != 0;

		}

		private void FillHelpList()
		{
			//Fill Help List Tree View Control
			TFDIncident.clsCommonCodes cCommon = Container.Resolve< clsCommonCodes>();
			int ClassIndex = 0;
			int ScreenIndex = 0;
			int SelectedIndex = 0;
			UpgradeHelpers.BasicViewModels.TreeNodeViewModel firstnode = null;


			if (~cCommon.GetHelpList() != 0)
			{
				ViewModel.tvHelpList.Visible = false;
				return;
			}

			string CurrentClass = "";
			int CurrentScreen = 0;


			while(!cCommon.HelpList.EOF)
			{
				if (IncidentMain.Clean(cCommon.HelpList["class_title"]) != CurrentClass)
				{
					ViewModel.mNode = ViewModel.tvHelpList.Add("");
					ViewModel.mNode.Text = Convert.ToString(cCommon.HelpList["class_title"]);
					//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.TreeNode.Tag was not upgraded
					ViewModel.mNode.Set_Tag( "0");
					ClassIndex = ViewModel.mNode.Index + 1;
					if ( ViewModel.mNode.Index + 1 == 1)
					{
						firstnode = ViewModel.mNode;
					}
					CurrentClass = IncidentMain.Clean(cCommon.HelpList["class_title"]);
					if (Convert.ToDouble(cCommon.HelpList["screen_id"]) != CurrentScreen)
					{
						ViewModel.mNode = ViewModel.tvHelpList.Items.Find(ClassIndex.ToString(), true)[0].Add("");
						ViewModel.mNode.Text = IncidentMain.Clean(cCommon.HelpList["help_title"]);
						//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.TreeNode.Tag was not upgraded
						ViewModel.mNode.Set_Tag( Conversion.Str(cCommon.HelpList["help_id"]));
						ScreenIndex = ViewModel.mNode.Index + 1;
						CurrentScreen = Convert.ToInt32(cCommon.HelpList["screen_id"]);
						//UPGRADE_WARNING: (1068) mNode.Tag of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						if (Conversion.Val(Convert.ToString(ViewModel.mNode.Get_Tag())) == ViewModel.CurrentHelpID)
						{
							//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.TreeNode.Tag was not upgraded
							SelectedIndex = ViewModel.mNode.Index + 1;
						}
					}
					else
					{
						ViewModel.mNode = ViewModel.tvHelpList.Items.Find(ScreenIndex.ToString(), true)[0].Add("");
						ViewModel.mNode.Text = IncidentMain.Clean(cCommon.HelpList["help_title"]);
						//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.TreeNode.Tag was not upgraded
						ViewModel.mNode.Set_Tag( Conversion.Str(cCommon.HelpList["help_id"]));
						//UPGRADE_WARNING: (1068) mNode.Tag of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						if (Conversion.Val(Convert.ToString(ViewModel.mNode.Get_Tag())) == ViewModel.CurrentHelpID)
						{
							//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.TreeNode.Tag was not upgraded
							SelectedIndex = ViewModel.mNode.Index + 1;
						}
					}
				}
				else
				{
					if (Convert.ToDouble(cCommon.HelpList["screen_id"]) != CurrentScreen)
					{
						ViewModel.mNode = ViewModel.tvHelpList.Items.Find(ClassIndex.ToString(), true)[0].Add("");
						ViewModel.mNode.Text = IncidentMain.Clean(cCommon.HelpList["help_title"]);
						//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.TreeNode.Tag was not upgraded
						ViewModel.mNode.Set_Tag( Conversion.Str(cCommon.HelpList["help_id"]));
						ScreenIndex = ViewModel.mNode.Index + 1;
						CurrentScreen = Convert.ToInt32(cCommon.HelpList["screen_id"]);
						//UPGRADE_WARNING: (1068) mNode.Tag of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						if (Conversion.Val(Convert.ToString(ViewModel.mNode.Get_Tag())) == ViewModel.CurrentHelpID)
						{
							//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.TreeNode.Tag was not upgraded
							SelectedIndex = ViewModel.mNode.Index + 1;
						}
					}
					else
					{
						ViewModel.mNode = ViewModel.tvHelpList.Items.Find(ScreenIndex.ToString(), true)[0].Add("");
						ViewModel.mNode.Text = IncidentMain.Clean(cCommon.HelpList["help_title"]);
						//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.TreeNode.Tag was not upgraded
						ViewModel.mNode.Set_Tag( Conversion.Str(cCommon.HelpList["help_id"]));
						//UPGRADE_WARNING: (1068) mNode.Tag of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						if (Conversion.Val(Convert.ToString(ViewModel.mNode.Get_Tag())) == ViewModel.CurrentHelpID)
						{
							//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.TreeNode.Tag was not upgraded
							SelectedIndex = ViewModel.mNode.Index + 1;
						}
					}
				}
				cCommon.HelpList.MoveNext();
			}
			;
			firstnode.Collapse();
			ViewModel.tvHelpList.Items[SelectedIndex - 1].GetTreeViewModel().SelectedNode = ViewModel.tvHelpList.Items[SelectedIndex - 1];

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdCode_Click(Object eventSender, System.EventArgs eventArgs)
		{
			TFDIncident.clsCommonCodes cCommon = Container.Resolve< clsCommonCodes>();
			string CurrentClass = "";

			if (~cCommon.GetHelpCodes(ViewModel.CurrentHelpID) != 0)
			{
				ViewManager.ShowMessage("Sorry, unable to retrieve Code Table for this field", "TFD Incident Reporting System", UpgradeHelpers.Helpers.
					BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Information);
				return;
			}

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			oCmd.Connection = IncidentMain.oIncident;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = Convert.ToString(cCommon.HelpCode["code_sql"]);
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			if (oRec.EOF)
			{
				ViewManager.ShowMessage("Sorry, unable to retrieve Code Table for this field", "TFD Incident Reporting System", UpgradeHelpers.Helpers.
					BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Information);
				return;
			}

			StringBuilder CodeList = new System.Text.StringBuilder();
			switch(Convert.ToInt32(cCommon.HelpCode["code_type"]))
			{
				case 1 :  // Class Only 

					while(!oRec.EOF)
					{
						CodeList.Append(IncidentMain.Clean(oRec["class"]) + "\n");
						oRec.MoveNext();
					};
					break;
				case 2 :  //Class and Codes 
					CurrentClass = "";
					CurrentClass = "";

					while(!oRec.EOF)
					{
						if (IncidentMain.Clean(oRec["class"]) != CurrentClass)
						{
							CodeList.Append(IncidentMain.Clean(oRec["class"]) + "\n");
							CurrentClass = IncidentMain.Clean(oRec["class"]);
							CodeList.Append("     " + IncidentMain.Clean(oRec["code"]) + "\n");
						}
						else
						{
							CodeList.Append("     " + IncidentMain.Clean(oRec["code"]) + "\n");
						}
						oRec.MoveNext();
					};
					break;
				case 3 :  //Codes Only 

					while(!oRec.EOF)
					{
						CodeList.Append(IncidentMain.Clean(oRec["code"]) + "\n");
						oRec.MoveNext();
					};
					break;
			}

			if (CodeList.ToString() != "")
			{
				ViewModel.txtHelpText.Text = CodeList.ToString();
			}
			else
			{
				ViewManager.ShowMessage("Sorry, unable to retrieve Code Table for this field", "TFD Incident Reporting System", UpgradeHelpers.Helpers.
					BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Information);
				return;
			}
			ViewModel.cmdCode.Enabled = false;

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			//Populate Help Title and Textbox based on global help variables
			GetHelpText();
			FillHelpList();
		}

		[UpgradeHelpers.Events.Handler]
		internal void tvHelpList_AfterSelect(Object eventSender, UpgradeHelpers.BasicViewModels.TreeNodeViewModel eventArgs)
		{
			UpgradeHelpers.BasicViewModels.TreeNodeViewModel Node = eventArgs;
			TFDIncident.clsCommonCodes cCommon = Container.Resolve< clsCommonCodes>();
			int HelpID = 0;

			//UPGRADE_WARNING: (1068) Node.Tag of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			double dbNumericTemp = 0;
			if (Double.TryParse(Convert.ToString(Node.Get_Tag()), NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
			{
				//UPGRADE_WARNING: (1068) Node.Tag of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.TreeNode.Tag was not upgraded
				//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.TreeNode.Tag was not upgraded
				HelpID = Convert.ToInt32(Node.Get_Tag());
				if (HelpID == 0)
				{
					return;
				} //Report Title Node
				if (cCommon.GetHelpByID(HelpID) != 0)
				{
					IncidentMain.Shared.gHelpScreen = Convert.ToInt32(cCommon.HelpText["screen_id"]);
					IncidentMain.Shared.gHelpControl = Convert.ToInt32(cCommon.HelpText["control_id"]);
				}
				else
				{
					IncidentMain.Shared.gHelpScreen = 0;
					IncidentMain.Shared.gHelpControl = 0;
				}
			}
			else
			{
				IncidentMain.Shared.gHelpScreen = 0;
				IncidentMain.Shared.gHelpControl = 0;
			}
			GetHelpText();
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmHelp DefInstance
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

		public static frmHelp CreateInstance()
		{
			TFDIncident.frmHelp theInstance = Shared.Container.Resolve< frmHelp>();
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

	public partial class frmHelp
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.frmHelpViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmHelp m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}