using Microsoft.VisualBasic;
using System;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class dlgSendRover
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgSendRoverViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(dlgSendRover));
			if ( Shared.m_vb6FormDefInstance == null)
			{
				if ( Shared.m_InitializingDefInstance)
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
		}


		private void dlgSendRover_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		//*******************************************
		//* Dialog to gather info for transfering   *
		//* Staff between Battalions                *
		//*******************************************
		//No Data Access
		[UpgradeHelpers.Events.Handler]
		internal void chkAM_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.chkAM.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				ViewModel.chkPM.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
				ViewModel.chkBoth.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void chkBoth_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.chkBoth.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				ViewModel.chkAM.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
				ViewModel.chkPM.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void chkDebit_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.chkDebit.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				ViewModel.chkRover.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			}
			else
			{
				ViewModel.chkRover.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void chkPM_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.chkPM.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				ViewModel.chkAM.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
				ViewModel.chkBoth.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void chkRover_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.chkRover.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				ViewModel.chkDebit.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			}
			else
			{
				ViewModel.chkDebit.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdCancel_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Clear global variables set by this dialog
			//Unload form
			modGlobal
				.Shared.gLeaveType = "";
			modGlobal.Shared.gStartTrans = "";
			modGlobal.Shared.gEndTrans = "";
			modGlobal.Shared.gAssignment = 0;
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdOK_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Check for valid choices
			//Set values for global variables
			//Unload form

			if ( ViewModel.chkRover.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				if (modGlobal.Shared.gLeaveType == "")
				{
					modGlobal.Shared.gLeaveType = "REG";
				}
				if (modGlobal.Shared.gGoToBatt == "2")
				{
					modGlobal.Shared.gAssignment = modGlobal.ASGN182ROV;
				}
				else if (modGlobal.Shared.gGoToBatt == "1")
				{
					modGlobal.Shared.gAssignment = modGlobal.ASGN181ROV;
				}
				else
				{
					//gGoToBatt = "3"
					modGlobal
						.Shared.gAssignment = modGlobal.ASGN183ROV;
				}
			}
			else if ( ViewModel.chkDebit.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				//        gLeaveType = "DDF"
				if (modGlobal.Shared.gGoToBatt == "2")
				{
					modGlobal.Shared.gAssignment = modGlobal.ASGN182DBT;
				}
				else if (modGlobal.Shared.gGoToBatt == "1")
				{
					modGlobal.Shared.gAssignment = modGlobal.ASGN181DBT;
				}
				else
				{
					//gGoToBatt = "3"
					modGlobal
						.Shared.gAssignment = modGlobal.ASGN183DBT;
				}
			}
			else
			{
				ViewManager.ShowMessage("You must select either Rover or Debit", "Error: Send to Other Battalion", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			if ( ViewModel.chkAM.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				modGlobal.Shared.gEndTrans = modGlobal.Shared.gStartTrans.Substring(0, Math.Min(Strings.Len(modGlobal.Shared.gStartTrans) - 2, modGlobal.Shared.gStartTrans.Length)) + "PM";
			}
			else if ( ViewModel.chkPM.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				modGlobal.Shared.gStartTrans = modGlobal.Shared.gStartTrans.Substring(0, Math.Min(Strings.Len(modGlobal.Shared.gStartTrans) - 2, modGlobal.Shared.gStartTrans.Length)) + "PM";
			}
			else if ( ViewModel.chkBoth.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				//Do nothing dates stay as defaulted
			}
			else
			{
				//no shifts selected
				ViewManager.ShowMessage("You must select a shift", "Error: Send to Other Battalion", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}
			ViewManager.DisposeView(this);

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{

			//Set caption to match calling Battalion
			if (modGlobal.Shared.gGoToBatt == "1")
			{
				dlgSendRover.DefInstance.ViewModel.Text = dlgSendRover.DefInstance.ViewModel.Text + " 1";
			}
			else if (modGlobal.Shared.gGoToBatt == "2")
			{
				dlgSendRover.DefInstance.ViewModel.Text = dlgSendRover.DefInstance.ViewModel.Text + " 2";
			}
			else
			{
				//gGoToBatt = "3"
				dlgSendRover.DefInstance.ViewModel.Text = dlgSendRover.DefInstance.ViewModel.Text + " 3";
			}

			if (modGlobal.Shared.gLeaveType == "DDF" || modGlobal.Shared.gLeaveType == "UDD")
			{
				ViewModel.chkDebit.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
				ViewModel.chkDebit.Enabled = false;
				ViewModel.chkRover.Enabled = false;
			}
			else if (modGlobal.Shared.gLeaveType == "TRD")
			{
				ViewModel.chkDebit.Enabled = false;
				ViewModel.chkRover.Enabled = false;
				ViewModel.chkRover.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
			}
			else if (modGlobal.Shared.gLeaveType == "OTP" || modGlobal.Shared.gLeaveType == "EDT" || modGlobal.Shared.gLeaveType == "EDO" || modGlobal.Shared.gLeaveType == "DOT")
			{
				ViewModel.chkDebit.Enabled = false;
				ViewModel.chkRover.Enabled = false;
				ViewModel.chkRover.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
			}
			else
			{
				ViewModel.chkRover.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
			}

			if (~modGlobal.Shared.gFullShift != 0)
			{
				ViewModel.chkBoth.Enabled = false;
				if (modGlobal.Shared.gTradeEmp == "AM")
				{
					ViewModel.chkPM.Enabled = false;
					ViewModel.chkAM.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
				}
				else
				{
					ViewModel.chkAM.Enabled = false;
					ViewModel.chkPM.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
				}
			}
			else
			{
				ViewModel.chkBoth.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
			}

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static dlgSendRover DefInstance
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

		public static dlgSendRover CreateInstance()
		{
			PTSProject.dlgSendRover theInstance = Shared.Container.Resolve< dlgSendRover>();
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

	public partial class dlgSendRover
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgSendRoverViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual dlgSendRover m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}