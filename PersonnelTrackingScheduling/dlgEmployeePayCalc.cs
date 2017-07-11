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

	public partial class dlgEmployeePayCalc
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgEmployeePayCalcViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(dlgEmployeePayCalc));
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


		private void dlgEmployeePayCalc_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		public void ClearScreen()
		{
			ViewModel.cboEmpList.SelectedIndex = -1;
			ViewModel.cboJobCode.SelectedIndex = -1;
			ViewModel.lbJobStep.Text = "";
			ViewModel.txtStep.Text = "";
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboEmpList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
            // VALUE NOT USED
			//int i = 0;
			//Come Here - for employee id change
			ViewModel.Empid = this.ViewModel.cboEmpList.Text.Substring(Math.Max(this.ViewModel.cboEmpList.Text.Length - 5, 0));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
			if (Strings.Len(ViewModel.Empid) < 5 || Convert.IsDBNull(ViewModel.Empid) || modGlobal.Clean(ViewModel.Empid) == "")
			{
				return;
			}

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "sp_GetPersonnelDetail '" + ViewModel.Empid + "'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (oRec.EOF)
			{
				ViewManager.ShowMessage("Problem getting Employee Information.", "Job Code / Step Calc", UpgradeHelpers.Helpers.BoxButtons.OK);
				ClearScreen();
				return;
			}
			ViewModel.sJobCode = modGlobal.Clean(oRec["job_code_id"]);
			ViewModel.sStep = modGlobal.Clean(oRec["step"]);
			ViewModel.lbJobStep.Text = "Job Code/Step:  " + ViewModel.sJobCode + " / " + ViewModel.sStep;



		}

		[UpgradeHelpers.Events.Handler]
		internal void cboJobCode_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ViewModel.lbMessage.Visible = false;

			if ( ViewModel.cboJobCode.SelectedIndex == -1)
			{
				return;
			}
			string newJobCode = ViewModel.cboJobCode.Text.Substring(0, Math.Min(5, ViewModel.cboJobCode.Text.Length));
			if (modGlobal.Clean(newJobCode) == "")
			{
				return;
			}

			string newStep = "0";
			decimal LastRate = 0;
			decimal NewPayRate = 0;
			decimal PayRate = 0;

			if ( ViewModel.sJobCode == "")
			{
				return;
			}
			if ( ViewModel.sStep == "")
			{
				return;
			}


			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//Determine Step for PayUp
			oCmd.CommandText = "sp_FindPayRate '" + ViewModel.sJobCode + "'," + ViewModel.sStep;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				PayRate = Convert.ToDecimal(oRec["pay_rate"]);
				NewPayRate = (decimal) Math.Round((double) (PayRate + ((decimal) (((double) PayRate) * 0.05d))), 2);
				for (int i = 1; i <= 11; i++)
				{
					oCmd.CommandText = "sp_FindPayRate '" + newJobCode + "'," + i.ToString();
					oRec = ADORecordSetHelper.Open(oCmd, "");

					if (oRec.EOF)
					{
						if (LastRate > PayRate)
						{
							newStep = (i - 1).ToString();
							break;
						}
						else
						{
							ViewModel.lbMessage.Text = "The Selected Job does not constitute a Pay Upgrade. Please try a different Job Code.";
							ViewModel.lbMessage.Visible = true;
							ViewModel.txtStep.Text = modGlobal.GetStep(ViewModel.Empid);
							return;
						}
					}
					else
					{
						if (((double) NewPayRate) <= Convert.ToDouble(oRec["pay_rate"]))
						{
							newStep = i.ToString();
							break;
						}
						else
						{
							LastRate = Convert.ToDecimal(oRec["pay_rate"]);
						}
					}
				}
			}

			//    06/02/2015 Per Peggy D. When Upgrade to 4001B: Firefighter +5% +5%
			//    calculated step should be the same
			if (newJobCode == "4001B")
			{
				if ( ViewModel.sJobCode != "40010")
				{
					newStep = modGlobal.GetStep(ViewModel.Empid);
				}
				else
				{
					newStep = (Double.Parse(modGlobal.GetStep(ViewModel.Empid)) - 1).ToString();
				}
			}

			//10/8/2002 Per Peggy A. Upgrade to Fire Lieutenant FCC or 40hr keeps Step
			if (newJobCode == "4002F" || newJobCode == "4002M" || newJobCode == "41010" || newJobCode == "4002P" || newJobCode == "4002S")
			{
				if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.GetStep(ViewModel.Empid)) < 3)
				{
					newStep = modGlobal.GetStep(ViewModel.Empid);
				}
			}

			//1/14/2013 Per Peggy D. Upgrade For Tiller Pay is only 1%... so keep step
			if (newJobCode == "4001V")
			{
				if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.GetStep(ViewModel.Empid)) == 1)
				{
					newStep = modGlobal.GetStep(ViewModel.Empid);
				}
				else
				{
					newStep = (Double.Parse(modGlobal.GetStep(ViewModel.Empid)) - 1).ToString();
				}
			}

			if (newJobCode == "4001U")
			{
				if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.GetStep(ViewModel.Empid)) == 1)
				{
					newStep = modGlobal.GetStep(ViewModel.Empid);
				}
				else
				{
					newStep = (Double.Parse(modGlobal.GetStep(ViewModel.Empid)) - 1).ToString();
				}
			}

			//1/27/2014 Per Peggy D. Upgrade is only 2.5%... so need following logic
			if (newJobCode == "4001S")
			{
				if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.GetStep(ViewModel.Empid)) == 1)
				{
					newStep = modGlobal.GetStep(ViewModel.Empid);
				}
				else
				{
					newStep = (Double.Parse(modGlobal.GetStep(ViewModel.Empid)) - 1).ToString();
				}
			}

			//    If newJobCode = "4001T" Then
			//        If GetStep(Empid) = 1 Then
			//            newStep = GetStep(Empid)
			//        Else
			//            newStep = GetStep(Empid) - 1
			//        End If
			//    End If
			ViewModel.txtStep.Text = newStep;
			ViewModel.lbMessage.Text = "PayRate/newPayRate/LastRate =  " + PayRate.ToString() + " / " +
									NewPayRate.ToString() + " / " + LastRate.ToString() + ".";
			ViewModel.lbMessage.Visible = false;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			string strName = "";
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			//Fill Job Title List box
			this.ViewModel.cboJobCode.Items.Clear();
			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "select job_code_id,job_title from Job_Code where active_flag <> 0 order by job_title";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			while(!oRec.EOF)
			{
				strName = Convert.ToString(oRec["job_code_id"]).Trim() + ": " + Convert.ToString(oRec["job_title"]).Trim();
				this.ViewModel.cboJobCode.AddItem(strName);
				oRec.MoveNext();
			};

			this.ViewModel.cboEmpList.Items.Clear();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spFullNameList";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			while(!oRec.EOF)
			{
				strName = Convert.ToString(oRec["name_full"]).Trim() + "  :" + Convert.ToString(oRec["employee_id"]);
				this.ViewModel.cboEmpList.AddItem(strName);
				oRec.MoveNext();
			};

			ClearScreen();

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static dlgEmployeePayCalc DefInstance
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

		public static dlgEmployeePayCalc CreateInstance()
		{
			PTSProject.dlgEmployeePayCalc theInstance = Shared.Container.Resolve< dlgEmployeePayCalc>();
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

	public partial class dlgEmployeePayCalc
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgEmployeePayCalcViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual dlgEmployeePayCalc m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}