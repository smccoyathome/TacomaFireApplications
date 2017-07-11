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

	public partial class frmChangeCallBackNum
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmChangeCallBackNumViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmChangeCallBackNum));
			if ( Shared.m_vb6FormDefInstance == null)
			{
				if ( Shared.m_InitializingDefInstance)
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
		}


		private void frmChangeCallBackNum_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		clsScheduler cScheduler
		{
			get
			{
				if ( ViewModel._cScheduler == null)
				{
					ViewModel._cScheduler = Container.Resolve< clsScheduler>();
				}
				return ViewModel._cScheduler;
			}
			set
			{
				ViewModel._cScheduler = value;
			}
		}

		public void ChangeCallbackNumber()
		{

			string sText = "";
			//UPGRADE_WARNING: (1068) GetVal(lbRecordID.Caption) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			if (Convert.ToDouble(modGlobal.GetVal(ViewModel.lbRecordID.Text)) > 0)
			{
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				if (cScheduler.GetPersonnelCallBackNumberByID(Convert.ToInt32(modGlobal.GetVal(ViewModel.lbRecordID.Text))) != 0)
				{
					//successful
				}
				else
				{
					ViewManager.ShowMessage("Oooops! There was a problem retrieving the current CallBackNumber.", "Selecting PersonnelCallBackNumber", UpgradeHelpers.Helpers.BoxButtons.OK);
					return;
				}
			}
			else
			{
				cScheduler.CallBackEmployeeID = modGlobal.Clean(ViewModel.sEmpID);
			}

			cScheduler.CallBackShift = modGlobal.Clean(ViewModel.cboShift.Text);
			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			cScheduler.CallBackNumber = Convert.ToInt32(modGlobal.GetVal(ViewModel.cboNumber.Text));
			cScheduler.CallBackDebitGroup = modGlobal.Clean(ViewModel.cboDebitGroup.Text);

			if ( ViewModel.chkAvailSpecEvent.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				cScheduler.CallBackSpecEventFlag = "N";
			}
			else
			{
				cScheduler.CallBackSpecEventFlag = "Y";
			}

			if ( ViewModel.chkAvailMedic6.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				cScheduler.CallBackMedicFlag = "N";
			}
			else
			{
				cScheduler.CallBackMedicFlag = "Y";
			}

			if (Strings.Len(modGlobal.Clean(ViewModel.cboNumber.Text)) > 2)
			{
				sText = modGlobal.Clean(ViewModel.cboShift.Text) + "-" + modGlobal.Clean(ViewModel.cboNumber.Text);
				cScheduler.CallBackNumberFormatted = sText;
			}
			else if (Strings.Len(modGlobal.Clean(ViewModel.cboNumber.Text)) == 2)
			{
				sText = modGlobal.Clean(ViewModel.cboShift.Text) + "-0" + modGlobal.Clean(ViewModel.cboNumber.Text);
				cScheduler.CallBackNumberFormatted = sText;
			}
			else
			{
				sText = modGlobal.Clean(ViewModel.cboShift.Text) + "-00" + modGlobal.Clean(ViewModel.cboNumber.Text);
				cScheduler.CallBackNumberFormatted = sText;
			}

			//UPGRADE_WARNING: (1068) GetVal(lbRecordID.Caption) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			if (Convert.ToDouble(modGlobal.GetVal(ViewModel.lbRecordID.Text)) == 0)
			{
				if (cScheduler.InsertPersonnelCallBackNumber())
				{
					//successful
				}
				else
				{
					ViewManager.ShowMessage("Oooops! There was a problem Inserting the CallBackNumber.", "Inserting PersonnelCallBackNumber", UpgradeHelpers.Helpers.BoxButtons.OK);
					return;
				}
			}
			else
			{
				if (cScheduler.UpdatePersonnelCallBackNumber())
				{
					//successful
				}
				else
				{
					ViewManager.ShowMessage("Oooops! There was a problem Updating CallBackNumber.", "Updating PersonnelCallBackNumber", UpgradeHelpers.Helpers.BoxButtons.OK);
					return;
				}
			}

		}

		public void GetEmployeeInformation()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string sString = "";
			ViewModel.cboShift.SelectedIndex = -1;
			ViewModel.cboShift.Text = "";
			ViewModel.cboDebitGroup.SelectedIndex = -1;
			ViewModel.cboDebitGroup.Text = "";
			ViewModel.cboNumber.SelectedIndex = -1;
			ViewModel.cboNumber.Text = "";
			ViewModel.lbRecordID.Text = "0";

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			oCmd.CommandText = "spSelect_EmployeeCallBackInfo '" + modGlobal.Clean(ViewModel.sEmpID) + "' ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				if (modGlobal.Clean(oRec["call_back_id"]) != "")
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.lbRecordID.Text = Convert.ToString(modGlobal.GetVal(oRec["call_back_id"]));
				}
				sString = modGlobal.Clean(oRec["name_full"]) + "  ~  " + modGlobal.Clean(oRec["call_back_number"]);
				if (modGlobal.Clean(oRec["assignment_type_code"]) != "REG")
				{
					if (modGlobal.Clean(oRec["debit_group"]) == "")
					{
						sString = sString + "     " + modGlobal.Clean(oRec["assignment_type_code"]);
					}
					else
					{
						sString = sString + "     " + modGlobal.Clean(oRec["assignment_type_code"]) + "/" + modGlobal.Clean(oRec["debit_group"]);
					}
				}
				else if (modGlobal.Clean(oRec["debit_group"]) == "")
				{
					sString = sString + "     " + modGlobal.Clean(oRec["debit_group"]);
				}
				else
				{
					sString = sString + "     " + modGlobal.Clean(oRec["debit_group_code"]);
				}
				ViewModel.lblEmployeeName.Text = sString;
				double dbNumericTemp = 0;
				if (Double.TryParse(Convert.ToString(oRec["number"]), NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.cboNumber.Text = Convert.ToString(modGlobal.GetVal(oRec["number"]));
				}
				if (modGlobal.Clean(oRec["shift"]) != "")
				{
					for (int i = 0; i <= ViewModel.cboShift.Items.Count - 1; i++)
					{
						if ( ViewModel.cboShift.GetListItem(i) == modGlobal.Clean(oRec["shift"]))
						{
							ViewModel.cboShift.SelectedIndex = i;
							break;
						}
					}
				}
				if (modGlobal.Clean(oRec["shift_code"]) != "")
				{
					if (modGlobal.Clean(oRec["shift"]) != modGlobal.Clean(oRec["shift_code"]))
					{
						for (int i = 0; i <= ViewModel.cboShift.Items.Count - 1; i++)
						{
							if ( ViewModel.cboShift.GetListItem(i) == modGlobal.Clean(oRec["shift_code"]))
							{
								ViewModel.cboShift.SelectedIndex = i;
								break;
							}
						}
					}
				}
				ViewModel.cboDebitGroup.Text = modGlobal.Clean(oRec["debit_group"]);
				if (modGlobal.Clean(oRec["assignment_type_code"]) == "REG" || modGlobal.Clean(oRec["assignment_type_code"]) == "MRN")
				{
					if (modGlobal.Clean(oRec["debit_group_code"]) != "")
					{
						if (modGlobal.Clean(oRec["debit_group"]) != modGlobal.Clean(oRec["debit_group_code"]))
						{
							ViewModel.cboDebitGroup.Text = modGlobal.Clean(oRec["debit_group_code"]);
						}
					}
				}
				if (modGlobal.Clean(oRec["special_event"]) == "N")
				{
					ViewModel.chkAvailSpecEvent.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
				}
				else
				{
					ViewModel.chkAvailSpecEvent.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
				}

				//UPGRADE_WARNING: (1068) GetVal(oRec(recert_flag)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				if (Convert.ToDouble(modGlobal.GetVal(oRec["recert_flag"])) == 0)
				{
					ViewModel.chkAvailMedic6.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
					ViewModel.chkAvailMedic6.Enabled = false;
				}
				else if (modGlobal.Clean(oRec["medic_flag"]) == "N")
				{
					ViewModel.chkAvailMedic6.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
					ViewModel.chkAvailMedic6.Enabled = true;
				}
				else
				{
					ViewModel.chkAvailMedic6.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
					ViewModel.chkAvailMedic6.Enabled = true;
				}

			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void CancelButton_Renamed_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboDebitGroup_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboDebitGroup.SelectedIndex == -1)
			{
				return;
			}
			if ( ViewModel.FirstTime)
			{
				return;
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboShift_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			if ( ViewModel.FirstTime)
			{
				return;
			}
			if (modGlobal.Clean(ViewModel.cboShift.Text) == "")
			{
				return;
			}

			//add logic to the cboDebitGroup list with appropriate groups...
			ViewModel.cboDebitGroup.Items.Clear();
			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spSelect_DebitGroupListByShift '" + modGlobal.Clean(ViewModel.cboShift.Text) + "' ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (oRec.EOF)
			{
				return;
			}


			while(!oRec.EOF)
			{
				ViewModel.cboDebitGroup.AddItem(modGlobal.Clean(oRec["debit_group_code"]));
				oRec.MoveNext();
			};


		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			ViewModel.FirstTime = true;
			ViewModel.cboShift.AddItem("A");
			ViewModel.cboShift.AddItem("B");
			ViewModel.cboShift.AddItem("C");
			ViewModel.cboShift.AddItem("D");
			ViewModel.cboShift.SelectedIndex = -1;

			for (int i = 1; i <= 120; i++)
			{
				ViewModel.cboNumber.AddItem(i.ToString());
			}
			ViewModel.cboNumber.SelectedIndex = -1;
			ViewModel.sEmpID = modGlobal.Shared.gReportUser;
			ViewModel.FirstTime = false;
			ViewModel.cboDebitGroup.Items.Clear();
			GetEmployeeInformation();

		}

		[UpgradeHelpers.Events.Handler]
		internal void OKButton_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.DialogResult resp = (UpgradeHelpers.Helpers.DialogResult) 0;

				string sName = "";
				//Do some editing and check for delete...
				//UPGRADE_WARNING: (1068) GetVal(lbRecordID.Caption) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				if (Convert.ToDouble(modGlobal.GetVal(ViewModel.lbRecordID.Text)) != 0 && modGlobal.Clean(ViewModel.
							cboShift.Text) == "" && modGlobal.Clean(ViewModel.cboNumber.Text) == "" && modGlobal.Clean(ViewModel.cboDebitGroup.Text) == "")
				{
					async1.Append<UpgradeHelpers.Helpers.DialogResult>(() =>
							ViewManager.ShowMessage("Do you want to Delete the Callback # for this Employee?", "Delete Callback Number", UpgradeHelpers.Helpers.BoxButtons.YesNo));
					async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
					async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
						{
							resp = tempNormalized1;
						});
					async1.Append(() =>
						{
							if (resp == UpgradeHelpers.Helpers.DialogResult.No)
							{
								this.Return();
								return ;
							}
							else
							{
								//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								if (cScheduler.DeletePersonnelCallBackNumber(Convert.ToInt32(modGlobal.GetVal(ViewModel.lbRecordID.Text))) != 0)
								{
									//success
									ViewManager.DisposeView(this);
									this.Return();
									return ;
								}
								else
								{
									ViewManager.ShowMessage("Oooops! There was a problem deleting CallBackNumber.", "Delete Callback Number Error", UpgradeHelpers.Helpers.BoxButtons.OK);
									this.Return();
									return ;
								}
							}
						});
						}
				async1.Append(() =>
					{
						using ( var async2 = this.Async() )
						{

							if (modGlobal.Clean(ViewModel.cboShift.Text) == "")
							{
								ViewManager.ShowMessage("Please select a Shift... or Click Cancel to Exit.", "Edit Callback Number Error", UpgradeHelpers.Helpers.BoxButtons.OK);
								this.Return();
								return ;
							}

							if (modGlobal.Clean(ViewModel.cboNumber.Text) == "")
							{
								ViewManager.ShowMessage("Please select a Number... or Click Cancel to Exit.", "Edit Callback Number Error", UpgradeHelpers.Helpers.BoxButtons.OK);
								this.Return();
								return ;
							}

							//UPGRADE_WARNING: (1068) GetVal(cboNumber.Text) of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
							if (cScheduler.CheckCallBackNumberInUse(modGlobal.Clean(ViewModel.cboShift.Text), Convert.ToInt32(modGlobal.GetVal(ViewModel.cboNumber.Text)), modGlobal.Clean(ViewModel.sEmpID)) != 0)
							{
								if (!cScheduler.PersonnelCallBackNumber.EOF)
								{
									sName = modGlobal.Clean(cScheduler.PersonnelCallBackNumber["name_full"]);
									async2.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage("This Callback # currently belongs to " + sName + "." + "\r" +
												"Do you want to continue anyway?", "Check Callback Number In Use", UpgradeHelpers.Helpers.BoxButtons.YesNo));
									async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized2 => tempNormalized2);
									async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized3 =>
										{
											resp = tempNormalized3;
										});
									async2.Append(() =>
										{
											if (resp == UpgradeHelpers.Helpers.DialogResult.Yes)
											{
												//continue...
											}
											else
											{
												this.Return();
												return ;
											}
										});
										}
									}
							async2.Append(() =>
								{

									ChangeCallbackNumber();
									ViewManager.DisposeView(this);
								});
						}
					});
			}

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmChangeCallBackNum DefInstance
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

		public static frmChangeCallBackNum CreateInstance()
		{
			PTSProject.frmChangeCallBackNum theInstance = Shared.Container.Resolve< frmChangeCallBackNum>();
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

	public partial class frmChangeCallBackNum
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmChangeCallBackNumViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmChangeCallBackNum m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}