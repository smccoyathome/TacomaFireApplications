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

	public partial class dlgTime
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgTimeViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(dlgTime));
			if ( Shared.m_vb6FormDefInstance == null)
			{
				if ( Shared.m_InitializingDefInstance)
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
		}


		private void dlgTime_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		//**********************************************************
		//Dual usage Dialog for requesting Type of Leave
		//Or Scheduling Type of Time
		//**********************************************************
		//ADODB

		public void FindNotes()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();


			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			string SQLScript = "Select * from PersonnelScheduleNotes Where employee_id = '";
			SQLScript = SQLScript + modGlobal.Shared.gReportUser + "' and datediff(day,'";
			System.DateTime TempDate = DateTime.FromOADate(0);
			SQLScript = SQLScript + ((DateTime.TryParse(modGlobal.Shared.gStartTrans, out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : modGlobal.Shared.gStartTrans);
			SQLScript = SQLScript + "',shift_start) >= 0 and datediff(day,'";
			System.DateTime TempDate2 = DateTime.FromOADate(0);
			SQLScript = SQLScript + ((DateTime.TryParse(modGlobal.Shared.gEndTrans, out TempDate2)) ? TempDate2.ToString("MM/dd/yyyy") : modGlobal.Shared.gEndTrans);
			SQLScript = SQLScript + "',shift_start) <= 0";

			oCmd.CommandText = SQLScript;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (!oRec.EOF)
			{
				ViewModel.txtLeaveNotes.Text = "";

				while(!oRec.EOF)
				{
					ViewModel.txtLeaveNotes.Text = modGlobal.Clean(ViewModel.txtLeaveNotes.Text) + modGlobal.Clean(oRec["note"]).Trim() + ";  ";
					oRec.MoveNext();
				}
				;
							}

						}

		public void FindJobCode()
		{
			//If default jobcode was provided -- make it display


			for (int i = 0; i <= ViewModel.cboJob.Items.Count - 1; i++)
			{
				if ( ViewModel.cboJob.GetListItem(i).Substring(Math.Max(ViewModel.cboJob.GetListItem(i).Length - 5, 0)) == modGlobal.Shared.gPayType)
				{
					ViewModel.cboJob.Text = ViewModel.cboJob.GetListItem(i);
					break;
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboJob_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Selection canceled
			if ( ViewModel.cboJob.SelectedIndex < 0)
			{
				return;
			}
			//Pay upgrade selected
			modGlobal.Shared.gPayType = dlgTime.DefInstance.ViewModel.cboJob.Text.Substring(Math.Max(dlgTime.DefInstance.ViewModel.cboJob.Text.Length - 5, 0));

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboLeave_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Load Selected TimeCode into Global Variable
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();


			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			int iPos = (ViewModel.cboLeave.Text.IndexOf(':') + 1);
			iPos++;
			modGlobal.Shared.gLeaveType = ViewModel.cboLeave.Text.Substring(Math.Max(ViewModel.cboLeave.Text.Length - (Strings.Len(ViewModel.cboLeave.Text) - iPos), 0));
			//    gLeaveType = Right$(cboLeave.Text, 3)
			if (modGlobal.Shared.gLeaveType == "VAC" || modGlobal.Shared.gLeaveType == "VACFML")
			{
				ViewModel.boxVacBank.Visible = true;
				ViewModel.chkVacBank.Visible = true;
			}

			if (modGlobal.Shared.gLeaveType == "VAC" || modGlobal.Shared.gLeaveType == "FHL" || modGlobal.Shared.gLeaveType
						== "KEL" || modGlobal.Shared.gLeaveType == "PTO" || modGlobal.Shared.gLeaveType == "VACFML" || modGlobal.Shared.gLeaveType == "FHLFML" || modGlobal.Shared.gLeaveType == "PTOFML")
			{
				ViewModel.boxVacBank.Visible = true;
				ViewModel.chkSCKflag.Visible = true;
			}

			oCmd.CommandText = "select notes_available From Time_Code Where time_code_id = '" + modGlobal.Shared.gLeaveType + "'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (!oRec.EOF)
			{
				if (Convert.ToBoolean(oRec["notes_available"]))
				{
					ViewModel.lbLeaveNotes.Visible = true;
					ViewModel.txtLeaveNotes.Visible = true;
					ViewModel.txtLeaveNotes.Text = "";
				}
				else
				{
					ViewModel.lbLeaveNotes.Visible = false;
					ViewModel.txtLeaveNotes.Visible = false;
					ViewModel.txtLeaveNotes.Text = "";
					modGlobal.Shared.gLeaveNotes = "";
				}
			}
			else
			{
				ViewModel.lbLeaveNotes.Visible = false;
				ViewModel.txtLeaveNotes.Visible = false;
				ViewModel.txtLeaveNotes.Text = "";
				modGlobal.Shared.gLeaveNotes = "";
			}


		}

		[UpgradeHelpers.Events.Handler]
		internal void chkExtend_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.chkExtend.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				ViewModel.chkAMPM.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
				ViewModel.chkAMPM.Enabled = false;
				ViewModel.lbStart.Visible = true;
				ViewModel.lbEnd.Visible = true;
				ViewModel.calStartLeave.Visible = true;
				ViewModel.calEndLeave.Visible = true;
				ViewModel.calStartLeave.MinDate = DateTime.Parse("1/1/" + DateTime.Parse(modGlobal.Shared.gStartTrans).Year.ToString());
				//Start Max is the last day of Schedule Year
				ViewModel.calStartLeave.MaxDate = DateTime.Parse("12/31/" + DateTime.Parse(modGlobal.Shared.gEndTrans).Year.ToString());
				ViewModel.calEndLeave.MinDate = ViewModel.calStartLeave.MinDate;
				//End Max is the day after the Start Max
				ViewModel.calEndLeave.MaxDate = DateTime.Parse(ViewModel.calStartLeave.MaxDate.AddDays(1).ToString("M/d/yyyy"));
				ViewModel.calStartLeave.Value = DateTime.Parse(modGlobal.Shared.gStartTrans);
				ViewModel.calEndLeave.Value = DateTime.Parse(modGlobal.Shared.gEndTrans);
				modGlobal.Shared.gExtendLeave = -1;
			}
			else
			{
				ViewModel.lbStart.Visible = false;
				ViewModel.lbEnd.Visible = false;
				ViewModel.calStartLeave.Visible = false;
				ViewModel.calEndLeave.Visible = false;
				modGlobal.Shared.gExtendLeave = 0;
				if (modGlobal.Shared.gFullShift == (-1))
				{
					ViewModel.chkAMPM.Enabled = true;
					ViewModel.chkAMPM.Visible = true;
					ViewModel.boxAMPM.Visible = true;
					ViewModel.chkAMPM.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
					modGlobal.Shared.gFullShift = 0;
				}
			}



		}

		[UpgradeHelpers.Events.Handler]
		internal void chkSCKflag_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{

			if ( ViewModel.chkSCKflag.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
                modGlobal.Shared.gSCKFlag = -1;
			}
			else
			{
				modGlobal.Shared.gSCKFlag = 0;
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void chkVacBank_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.chkVacBank.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				modGlobal.Shared.gVacBank = -1;
			}
			else
			{
				modGlobal.Shared.gVacBank = 0;
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdCancel_Click(Object eventSender, System.EventArgs eventArgs)
		{

			modGlobal.Shared.gLeaveType = "";
			modGlobal.Shared.gPayType = "";
			modGlobal.Shared.gSCKFlag = 0;
			modGlobal.Shared.gVacBank = 0;

			if ( ViewModel.txtLeaveNotes.Visible)
			{
				modGlobal.Shared.gLeaveNotes = Strings.Replace(ViewModel.txtLeaveNotes.Text, "'", "''", 1, -1, CompareMethod.Binary).Trim();
			}
			if ( ViewModel.NotesRequired && modGlobal.Shared.gLeaveNotes == "")
			{
				FindNotes();
				if (modGlobal.Clean(ViewModel.txtLeaveNotes.Text) == "")
				{
					ViewManager.ShowMessage("Notes are required for this schedule change", this.ViewModel.Text, UpgradeHelpers.Helpers.BoxButtons.OK);
					ViewManager.SetCurrent(ViewModel.txtLeaveNotes);
					return;
				}
			}
			ViewManager.DisposeView(

				dlgTime.DefInstance);

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdOK_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Closes form
			if ( ViewModel.chkAMPM.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				modGlobal.Shared.gFullShift = -1;
			}
			if (modGlobal.Shared.gExtendLeave != 0)
			{
				modGlobal.Shared.gStartTrans = ViewModel.calStartLeave.Value.Date.ToString("M/d/yyyy");
				if ( ViewModel.calEndLeave.Value.Date.AddDays(1).ToString("M/d/yyyy") != modGlobal.Shared.gEndTrans)
				{
					modGlobal.Shared.gEndTrans = ViewModel.calEndLeave.Value.Date.AddDays(1).ToString("M/d/yyyy");
				}
			}

			if ( ViewModel.txtLeaveNotes.Visible)
			{
				modGlobal.Shared.gLeaveNotes = Strings.Replace(ViewModel.txtLeaveNotes.Text, "'", "''", 1, -1, CompareMethod.Binary).Trim();
			}
			if ( ViewModel.NotesRequired && modGlobal.Shared.gLeaveNotes == "")
			{
				FindNotes();
				if (modGlobal.Clean(ViewModel.txtLeaveNotes.Text) == "")
				{
					ViewManager.ShowMessage("Notes are required for this schedule change", this.ViewModel.Text, UpgradeHelpers.Helpers.BoxButtons.OK);
					ViewManager.SetCurrent(ViewModel.txtLeaveNotes);
					return;
				}
			}
			ViewManager.HideView(this);
			ViewManager.DisposeView(

				dlgTime.DefInstance);

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			string strName = "";
			//Load gLeaveType and JobClass listboxes

			string strLeave = "";
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string ListType = "";
			string sText = "";

			try
			{

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;

				//gLType = (L) for Leave Request
				//gLType = (S) for Schedule Time Request
				//gLType = (T) for Transfer
				//gLType = (K) for Change KOT only
				//gLType = (P) for Pay Upgrade only

				sText = "";
				if (modGlobal.Clean(modGlobal.Shared.gEmployeeId) != "")
				{
					oCmd.CommandText = "spSelect_EmployeeBenefitInfo '" + modGlobal.Clean(modGlobal.Shared.gEmployeeId) + "' ";
					oRec = ADORecordSetHelper.Open(oCmd, "");
					if (!oRec.EOF)
					{
						sText = modGlobal.Clean(oRec["name_full"]) + ":  " + modGlobal.Clean(oRec["benefit_program"]) + "; ";
						if (modGlobal.Clean(oRec["job_code_id"]) != "")
						{
							//                sText = sText & "w/ 25+ yrs"
							sText = sText + " " + modGlobal.Clean(oRec["job_code_id"]) + " - " + modGlobal.Clean(oRec["job_title"]);
						}
					}
				}
				ViewModel.lbEmpInfo.Text = sText;
				ViewModel.chkExtend.Visible = false;
				ViewModel.lbStart.Visible = false;
				ViewModel.lbEnd.Visible = false;
				ViewModel.calStartLeave.Visible = false;
				ViewModel.calEndLeave.Visible = false;
				ViewModel.lbLeaveNotes.Visible = false;
				ViewModel.txtLeaveNotes.Visible = false;
				modGlobal.Shared.gExtendLeave = 0;
				modGlobal.Shared.gLeaveNotes = "";
				ViewModel.NotesRequired = false;

				if (modGlobal.Shared.gLType == "L")
				{
					ViewModel.lbTitle.Text = "Leave Type";
					dlgTime.DefInstance.ViewModel.Text = "Select Leave Type";
					ListType = "L";
					ViewModel.chkExtend.Visible = true;
					ViewModel.chkExtend.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
				}
				else if (modGlobal.Shared.gLType == "S")
				{
					ViewModel.lbTitle.Text = "Time Type";
					dlgTime.DefInstance.ViewModel.Text = "Select Time Type";
					ViewModel.lbJob.Visible = true;
					ViewModel.cboJob.Visible = true;
					ViewModel.lblDefault.Visible = true;
					ListType = "S";
				}
				else if (modGlobal.Shared.gLType == "K")
				{
					ViewModel.lbTitle.Text = "Time Type";
					dlgTime.DefInstance.ViewModel.Text = "Select Time Type";
					ViewModel.lbJob.Visible = false;
					ViewModel.cboJob.Visible = false;
					ViewModel.lblDefault.Visible = false;
					ListType = "S";
				}
				else if (modGlobal.Shared.gLType == "T")
				{
					dlgTime.DefInstance.ViewModel.Text = "Special Assignment PayUpgrade";
					ViewModel.cmdOK.Text = "&Done";
					ViewModel.lbJob.Visible = true;
					ViewModel.cboJob.Visible = true;
					ViewModel.lblDefault.Visible = false;
					ViewModel.lbTitle.Visible = false;
					ViewModel.cboLeave.Visible = false;
					ListType = "";
					ViewModel.lbLeaveNotes.Visible = true;
					ViewModel.txtLeaveNotes.Visible = true;
					modGlobal.Shared.gLeaveNotes = "";
					ViewModel.NotesRequired = true;
				}
				else if (modGlobal.Shared.gLType == "P")
				{
					dlgTime.DefInstance.ViewModel.Text = "Pay Upgrade";
					ViewModel.cmdOK.Text = "&Done";
					ViewModel.lbJob.Visible = true;
					ViewModel.cboJob.Visible = true;
					ViewModel.lblDefault.Visible = false;
					ViewModel.lbTitle.Visible = false;
					ViewModel.cboLeave.Visible = false;
					ListType = "";
				}

				//Requesting Form will allow both shifts to be sched.
				if (modGlobal.Shared.gFullShift == (-1))
				{
					ViewModel.chkAMPM.Visible = true;
					ViewModel.boxAMPM.Visible = true;
					ViewModel.chkAMPM.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
					modGlobal.Shared.gFullShift = 0;
				}

				if (ListType != "")
				{
					ViewModel.cboLeave.Items.Clear();
					oCmd.CommandText = "select time_code_id, description From Time_Code Where time_type_code = '" + ListType + "' order by time_code_id";
					oRec = ADORecordSetHelper.Open(oCmd, "");

					while(!oRec.EOF)
					{
						strLeave = Convert.ToString(oRec["description"]).Trim();
						strLeave = strLeave + new System.String(' ', 30 - Strings.Len(strLeave)) + ": " + modGlobal.Clean(oRec["time_code_id"]);
						ViewModel.cboLeave.AddItem(strLeave);
						oRec.MoveNext();
					}
					;
									}

									if (modGlobal.Shared.gLType != "L" && modGlobal.Shared.gLType != "K")
									{
										//Fill Job Title List box
										if ( ViewModel.lblDefault.Visible)
					{
						if (modGlobal.Shared.gPayType != "")
						{
							ViewModel.lblDefault.Text = "Position Job Code:   " + modGlobal.Shared.gPayType.Trim();
						}
						else
						{
							ViewModel.lblDefault.Text = "Position Job Code:   " + modGlobal.Shared.gAssignID.Trim();
						}
					}
					dlgTime.DefInstance.ViewModel.cboJob.Items.Clear();
					oCmd.CommandText = "spJobCodeList";
					oRec = ADORecordSetHelper.Open(oCmd, "");

					while(!oRec.EOF)
					{
						strName = Convert.ToString(oRec["job_title"]).Trim() + " :" + Convert.ToString(oRec["job_code_id"]);
						dlgTime.DefInstance.ViewModel.cboJob.AddItem(strName);
						oRec.MoveNext();
					};
					if (modGlobal.Shared.gPayType != "")
					{
						FindJobCode();
					}
				}

				if (modGlobal.Shared.gLType == "L")
				{
					//Set Default Leave listbox to Sick
					//cboLeave.Text = cboLeave.ListIndex = 12
					for (int i = 0; i <= ViewModel.cboLeave.Items.Count - 1; i++)
					{
						if ( ViewModel.cboLeave.GetListItem(i).Substring(Math.Max(ViewModel.cboLeave.GetListItem(i).Length - 3, 0)) == "SCK")
						{
							ViewModel.cboLeave.SelectedIndex = i;
							ViewModel.lbLeaveNotes.Visible = true;
							ViewModel.txtLeaveNotes.Visible = true;
							break;
						}
					}
				}
				else if (modGlobal.Shared.gLType == "S")
				{
					if (modGlobal.Shared.gDebitDefault != 0)
					{
						//Set Default Time Code to Debit
						//cboLeave.ListIndex = 1
						if (modGlobal.Shared.UnschedDebit)
						{
							for (int i = 0; i <= ViewModel.cboLeave.Items.Count - 1; i++)
							{
								if ( ViewModel.cboLeave.GetListItem(i).Substring(Math.Max(ViewModel.cboLeave.GetListItem(i).Length - 3, 0)) == "UDD")
								{
									ViewModel.cboLeave.SelectedIndex = i;
									break;
								}
							}
						}
						else
						{
							for (int i = 0; i <= ViewModel.cboLeave.Items.Count - 1; i++)
							{
								if ( ViewModel.cboLeave.GetListItem(i).Substring(Math.Max(ViewModel.cboLeave.GetListItem(i).Length - 3, 0)) == "DDF")
								{
									ViewModel.cboLeave.SelectedIndex = i;
									break;
								}
							}
						}
					}
					else if (modGlobal.Shared.gOTimeDefault != 0)
					{
						//Set Default Time Code to OTP
						for (int i = 0; i <= ViewModel.cboLeave.Items.Count - 1; i++)
						{
							if ( ViewModel.cboLeave.GetListItem(i).Substring(Math.Max(ViewModel.cboLeave.GetListItem(i).Length - 3, 0)) == "OTP")
							{
								ViewModel.cboLeave.SelectedIndex = i;
								break;
							}
						}
					}
					else
					{
						//Set Default Time Code to Regular
						//cboLeave.ListIndex = 3
						for (int i = 0; i <= ViewModel.cboLeave.Items.Count - 1; i++)
						{
							if ( ViewModel.cboLeave.GetListItem(i).Substring(Math.Max(ViewModel.cboLeave.GetListItem(i).Length - 3, 0)) == "REG")
							{
								ViewModel.cboLeave.SelectedIndex = i;
								break;
							}
						}
					}
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

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static dlgTime DefInstance
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

		public static dlgTime CreateInstance()
		{
			PTSProject.dlgTime theInstance = Shared.Container.Resolve< dlgTime>();
			theInstance.Form_Load();
			return theInstance;
		}

		protected override void ExecuteControlsStartup()
		{
			ViewModel.boxAMPM.LifeCycleStartup();
			ViewModel.boxVacBank.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.boxAMPM.LifeCycleShutdown();
			ViewModel.boxVacBank.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class dlgTime
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgTimeViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual dlgTime m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}