using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeStubs;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class frmLeave
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmLeaveViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmLeave));
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


		private void frmLeave_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//******************************
		//* Daily Leave Report         *
		//******************************
		//ADODB

		public void ClearSpread()
		{
			//Clear Data From Spread Control
			//Titles
			ViewModel.sprLeave.BlockMode = false;
			ViewModel.sprLeave.Col = 5;
			ViewModel.sprLeave.Row = 2;
			ViewModel.sprLeave.Text = "";
			ViewModel.sprLeave.Col = 8;
			ViewModel.sprLeave.Text = "";
			ViewModel.sprLeave.Col = 11;
			ViewModel.sprLeave.Text = "";
			ViewModel.sprLeave.BlockMode = true;

			//Scheduled/Sick Leave
			ViewModel.sprLeave.Col = 1;
			ViewModel.sprLeave.Row = 7;
			ViewModel.sprLeave.Col2 = 11;
			ViewModel.sprLeave.Row2 = 33;
			ViewModel.sprLeave.FontUnderline = false;
			//ViewModel.sprLeave.Action = (FarPoint.ViewModels.FPActionConstants) 12;

			//FCC Leave
			ViewModel.sprLeave.Col = 7;
			ViewModel.sprLeave.Row = 37;
			ViewModel.sprLeave.Col2 = 11;
			ViewModel.sprLeave.Row2 = 44;
			ViewModel.sprLeave.FontUnderline = false;
			//ViewModel.sprLeave.Action = (FarPoint.ViewModels.FPActionConstants) 12;

			//Leave Totals
			ViewModel.sprLeave.Col = 2;
			ViewModel.sprLeave.Row = 36;
			ViewModel.sprLeave.Col2 = 3;
			ViewModel.sprLeave.Row2 = 44;
			//ViewModel.sprLeave.Action = (FarPoint.ViewModels.FPActionConstants) 12;
			ViewModel.sprLeave.BlockMode = false;

		}

		public void FillSpread()
		{
			//Fill Spread Control with Leave Data
			//If FirstTime skip Clearing Data
			string ShiftCode = "";
			string DebitGroup = "";
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string newName = "", CurrName = "";
			string AssType = "";
			float RegCount = 0;

			if ( ViewModel.FirstTime != 0)
			{
				ViewModel.FirstTime = 0;
			}
			else
			{
				ClearSpread();
			}
			ViewModel.sprLeave.BlockMode = false;

			string StartDate = DateTime.Parse(ViewModel.calDate.Text).ToString("M/d/yyyy");
			ViewModel.sprLeave.Col = 5;
			ViewModel.sprLeave.Row = 2;
			ViewModel.sprLeave.Text = StartDate;
			string EndDate = DateTime.Parse(StartDate).AddDays(1).ToString("M/d/yyyy");

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spReport_GetDebitGroup '" + StartDate + "','" + EndDate + "'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
			if (!Convert.IsDBNull(oRec["debit_group_code"]))
			{
				ShiftCode = Convert.ToString(oRec["shift_code"]);
				DebitGroup = Convert.ToString(oRec["debit_group_code"]);
			}
			else
			{
				ShiftCode = "";
				DebitGroup = "";
			}
			ViewModel.sprLeave.Col = 8;
			ViewModel.sprLeave.Text = ShiftCode;
			ViewModel.sprLeave.Col = 11;
			ViewModel.sprLeave.Text = DebitGroup;

			//Get Batt 1 Scheduled Leave
			oCmd.CommandText = "spReport_GetDailySchLvNEW '" + StartDate + "','" + EndDate + "' ";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			int x = 7;

			while(!oRec.EOF)
			{
				if (x >= 32)
				{
					ViewModel.sprLeave.Row = 33;
					ViewModel.sprLeave.Col = 1;
					ViewModel.sprLeave.Text = "more records...";
				}
				else
				{
					newName = Convert.ToString(oRec["name_full"]).Trim();
					if (newName == CurrName)
					{
						ViewModel.sprLeave.Row = x - 1;
						if (Convert.ToString(oRec["AMPM"]) == "PM")
						{
							ViewModel.sprLeave.Col = 3;
						}
						else
						{
							ViewModel.sprLeave.Col = 2;
						}
						if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["sick_leave_flag"])) == 1)
						{
							ViewModel.sprLeave.Text = modGlobal.Clean(oRec["time_code_id"]) + "*";
						}
						else
						{
							ViewModel.sprLeave.Text = modGlobal.Clean(oRec["time_code_id"]);
						}
						if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1)
						{
							ViewModel.sprLeave.FontUnderline = true;
						}
					}
					else
					{
						ViewModel.sprLeave.Row = x;
						ViewModel.sprLeave.Col = 1;
						ViewModel.sprLeave.Text = newName;
						if (Convert.ToString(oRec["AMPM"]) == "AM")
						{
							ViewModel.sprLeave.Col = 2;
						}
						else
						{
							ViewModel.sprLeave.Col = 3;
						}
						if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["sick_leave_flag"])) == 1)
						{
							ViewModel.sprLeave.Text = modGlobal.Clean(oRec["time_code_id"]) + "*";
						}
						else
						{
							ViewModel.sprLeave.Text = modGlobal.Clean(oRec["time_code_id"]);
						}
						if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1)
						{
							ViewModel.sprLeave.FontUnderline = true;
						}
						ViewModel.sprLeave.Col = 4;
						ViewModel.sprLeave.Text = Convert.ToString(oRec["unit_code"]);
						ViewModel.sprLeave.Col = 5;
						ViewModel.sprLeave.Text = modGlobal.Clean(oRec["position_code"]) + " (" + modGlobal.Clean(oRec["battalion_code"]) + ")";
						CurrName = newName;
						x++;
					}
				}
				oRec.MoveNext();
			};

			//    'Get Batt 2 Scheduled Leave
			//    oCmd.CommandText = "spReport_GetDailySchLv '" & StartDate & "','" & EndDate & "','2'"
			//    Set oRec = oCmd.Execute
			//
			//    x = 7
			//    Do Until oRec.EOF
			//        If x >= 23 Then
			//            sprLeave.Row = 23
			//            sprLeave.Col = 7
			//            sprLeave.Text = "more records..."
			//        Else
			//            newName = Trim$(oRec("name_full"])
			//            If newName = CurrName Then
			//                sprLeave.Row = x - 1
			//                If oRec("AMPM") = "PM" Then
			//                    sprLeave.Col = 9
			//                Else
			//                    sprLeave.Col = 8
			//                End If
			//                If Clean(oRec("sick_leave_flag"]) = 1 Then
			//                    sprLeave.Text = Clean(oRec("time_code_id"]) & "*"
			//                Else
			//                    sprLeave.Text = Clean(oRec("time_code_id"])
			//                End If
			//                If Clean(oRec("vacation_bank_flag"]) = 1 Then
			//                    sprLeave.FontUnderline = True
			//                End If
			//            Else
			//                sprLeave.Row = x
			//                sprLeave.Col = 7
			//                sprLeave.Text = newName
			//                If oRec("AMPM") = "AM" Then
			//                    sprLeave.Col = 8
			//                Else
			//                    sprLeave.Col = 9
			//                End If
			//                If Clean(oRec("sick_leave_flag"]) = 1 Then
			//                    sprLeave.Text = Clean(oRec("time_code_id"]) & "*"
			//                Else
			//                    sprLeave.Text = Clean(oRec("time_code_id"])
			//                End If
			//                If Clean(oRec("vacation_bank_flag"]) = 1 Then
			//                    sprLeave.FontUnderline = True
			//                End If
			//                sprLeave.Col = 10
			//                sprLeave.Text = oRec("unit_code")
			//                sprLeave.Col = 11
			//                sprLeave.Text = oRec("position_code")
			//                CurrName = newName
			//                x = x + 1
			//            End If
			//        End If
			//        oRec.MoveNext
			//    Loop

			//Get FCC Scheduled Leave
			oCmd.CommandText = "spReport_GetFCCLeaveSch '" + StartDate + "','" + EndDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			x = 37;

			while(!oRec.EOF)
			{
				if (x >= 43)
				{
					ViewModel.sprLeave.Row = 44;
					ViewModel.sprLeave.Col = 7;
					ViewModel.sprLeave.Text = "more records...";
				}
				else
				{
					newName = Convert.ToString(oRec["name_full"]).Trim();
					if (newName == CurrName)
					{
						ViewModel.sprLeave.Row = x - 1;
						if (Convert.ToString(oRec["AMPM"]) == "PM")
						{
							ViewModel.sprLeave.Col = 9;
						}
						else
						{
							ViewModel.sprLeave.Col = 8;
						}
						if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["sick_leave_flag"])) == 1)
						{
							ViewModel.sprLeave.Text = modGlobal.Clean(oRec["time_code_id"]) + "*";
						}
						else
						{
							ViewModel.sprLeave.Text = modGlobal.Clean(oRec["time_code_id"]);
						}
						if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1)
						{
							ViewModel.sprLeave.FontUnderline = true;
						}
					}
					else
					{
						ViewModel.sprLeave.Row = x;
						ViewModel.sprLeave.Col = 7;
						ViewModel.sprLeave.Text = newName;
						if (Convert.ToString(oRec["AMPM"]) == "AM")
						{
							ViewModel.sprLeave.Col = 8;
						}
						else
						{
							ViewModel.sprLeave.Col = 9;
						}
						if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["sick_leave_flag"])) == 1)
						{
							ViewModel.sprLeave.Text = modGlobal.Clean(oRec["time_code_id"]) + "*";
						}
						else
						{
							ViewModel.sprLeave.Text = modGlobal.Clean(oRec["time_code_id"]);
						}
						if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1)
						{
							ViewModel.sprLeave.FontUnderline = true;
						}
						ViewModel.sprLeave.Col = 10;
						ViewModel.sprLeave.Text = Convert.ToString(oRec["unit_code"]);
						ViewModel.sprLeave.Col = 11;
						ViewModel.sprLeave.Text = Convert.ToString(oRec["position_code"]);
						CurrName = newName;
						x++;
					}
				}
				oRec.MoveNext();
			};

			//Get Leave Summary
			oCmd.CommandText = "spReport_DailyLeaveSum '" + StartDate + "','" + EndDate + "' ";
			oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				AssType = Convert.ToString(oRec["assignment_type_code"]).Trim();
				if (Convert.ToString(oRec["AMPM"]) == "AM")
				{
					ViewModel.sprLeave.Col = 2;
				}
				else
				{
					ViewModel.sprLeave.Col = 3;
				}
				switch(AssType)
				{
					case "REG" :
						ViewModel.sprLeave.Row = 36;
						RegCount = (float) Conversion.Val(ViewModel.sprLeave.Text);
						RegCount = (float) (RegCount + Convert.ToDouble(oRec["leave_count"]));
						ViewModel.sprLeave.Text = RegCount.ToString();
						break;
					case "PM" :
						ViewModel.sprLeave.Row = 37;
						ViewModel.sprLeave.Text = Convert.ToString(oRec["leave_count"]);
						break;
					case "HZM" :
						ViewModel.sprLeave.Row = 38;
						ViewModel.sprLeave.Text = Convert.ToString(oRec["leave_count"]);
						break;
					case "MRN" :
						ViewModel.sprLeave.Row = 39;
						ViewModel.sprLeave.Text = Convert.ToString(oRec["leave_count"]);
						break;
				}
				oRec.MoveNext();
			};

			//Get Battalion Leave
			oCmd.CommandText = "spReport_DailyBCSummary '" + StartDate + "','" + EndDate + "' ";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.sprLeave.Row = 40;

			while(!oRec.EOF)
			{
				if (Convert.ToString(oRec["AMPM"]) == "AM")
				{
					ViewModel.sprLeave.Col = 2;
				}
				else
				{
					ViewModel.sprLeave.Col = 3;
				}
				ViewModel.sprLeave.Text = Convert.ToString(oRec["leave_count"]);
				oRec.MoveNext();
			};

			//Get Batt 1 Sick Leave
			oCmd.CommandText = "spReport_GetDailySckLvNEW '" + StartDate + "','" + EndDate + "' ";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			x = 7;

			while(!oRec.EOF)
			{
				if (x >= 43)
				{
					ViewModel.sprLeave.Row = 50;
					ViewModel.sprLeave.Col = 7;
					ViewModel.sprLeave.Text = "more records...";
				}
				else
				{
					newName = Convert.ToString(oRec["name_full"]).Trim();
					if (newName == CurrName)
					{
						ViewModel.sprLeave.Row = x - 1;
						if (Convert.ToString(oRec["AMPM"]) == "PM")
						{
							ViewModel.sprLeave.Col = 9;
						}
						else
						{
							ViewModel.sprLeave.Col = 8;
						}
						ViewModel.sprLeave.Text = modGlobal.Clean(oRec["time_code_id"]);
					}
					else
					{
						ViewModel.sprLeave.Row = x;
						ViewModel.sprLeave.Col = 7;
						ViewModel.sprLeave.Text = newName;
						if (Convert.ToString(oRec["AMPM"]) == "AM")
						{
							ViewModel.sprLeave.Col = 9;
						}
						else
						{
							ViewModel.sprLeave.Col = 8;
						}
						ViewModel.sprLeave.Text = modGlobal.Clean(oRec["time_code_id"]);
						ViewModel.sprLeave.Col = 10;
						ViewModel.sprLeave.Text = Convert.ToString(oRec["unit_code"]);
						ViewModel.sprLeave.Col = 11;
						ViewModel.sprLeave.Text = modGlobal.Clean(oRec["position_code"]) + " (" + modGlobal.Clean(oRec["battalion_code"]) + ")";
						CurrName = newName;
						x++;
					}
				}
				oRec.MoveNext();
			};

			//    'Get Batt 2 Sick Leave
			//    oCmd.CommandText = "spReport_GetDailySckLv '" & StartDate & "','" & EndDate & "','2'"
			//    Set oRec = oCmd.Execute
			//
			//    x = 34
			//    Do Until oRec.EOF
			//        If x >= 50 Then
			//            sprLeave.Row = 50
			//            sprLeave.Col = 7
			//            sprLeave.Text = "more records..."
			//        Else
			//            newName = Trim$(oRec("name_full"])
			//            If newName = CurrName Then
			//                sprLeave.Row = x - 1
			//                If oRec("AMPM") = "PM" Then
			//                    sprLeave.Col = 9
			//                Else
			//                    sprLeave.Col = 8
			//                End If
			//                sprLeave.Text = Clean(oRec("time_code_id"])
			//            Else
			//                sprLeave.Row = x
			//                sprLeave.Col = 7
			//                sprLeave.Text = newName
			//                If oRec("AMPM") = "AM" Then
			//                    sprLeave.Col = 8
			//                Else
			//                    sprLeave.Col = 9
			//                End If
			//                sprLeave.Text = Clean(oRec("time_code_id"])
			//                sprLeave.Col = 10
			//                sprLeave.Text = oRec("unit_code")
			//                sprLeave.Col = 11
			//                sprLeave.Text = oRec("position_code")
			//                CurrName = newName
			//                x = x + 1
			//            End If
			//        End If
			//        oRec.MoveNext
			//    Loop
			ViewModel.sprLeave.BlockMode = true;

		}

		[UpgradeHelpers.Events.Handler]
		internal void calDate_Click(Object eventSender, System.EventArgs eventArgs)
		{
			FillSpread();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprLeave.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprLeave.setPrintAbortMsg("Printing Daily Leave Report - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprLeave.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprLeave.setPrintBorder(false);
            //    sprLeave.PrintOrientation = 1
            // sprLeave.Action = 32
            ViewModel.sprLeave.PrintSheet(null);
			//ViewModel.sprLeave.Action = (FarPoint.ViewModels.FPActionConstants) 13;
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			//Create Form Level RDO Connection object
			//Fill Spreadsheet with


			for (int i = 0; i <= ViewManager.OpenFormsCount - 1; i++)
			{
				if ( ViewManager.GetOpenFormAt(i).ViewModel.Name == "frmTimeCard1")
				{
					ViewModel.calDate.Value = frmTimeCard1.DefInstance.ViewModel.calDate.Value.Date;
					return;
				}
				else if ( ViewManager.GetOpenFormAt(i).ViewModel.Name == "frmTimeCard2")
				{
					ViewModel.calDate.Value = frmTimeCard2.DefInstance.ViewModel.calDate.Value.Date;
					return;
				}
				else if ( ViewManager.GetOpenFormAt(i).ViewModel.Name == "frmBattSched3")
				{
					ViewModel.calDate.Value = frmBattSched3.DefInstance.ViewModel.calSchedDate.Value.Date;
				}
				else if ( ViewManager.GetOpenFormAt(i).ViewModel.Name == "frmBattSched4")
				{
					ViewModel.calDate.Value = frmBattSched4.DefInstance.ViewModel.calSchedDate.Value.Date;
					return;
				}
			}
			ViewModel.calDate.Value = frmNewBattSched.DefInstance.ViewModel.calSchedDate.Value.Date;
			ViewModel.calDate.Value = frmNewBattSched2.DefInstance.ViewModel.calSchedDate.Value.Date;
			ViewModel.calDate.Value = frmNewBattSched3.DefInstance.ViewModel.calSchedDate.Value.Date;
			ViewModel.FirstTime = -1;
			ViewModel.sprLeave.BlockMode = true;
			FillSpread();

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmLeave DefInstance
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

		public static frmLeave CreateInstance()
		{
			PTSProject.frmLeave theInstance = Shared.Container.Resolve< frmLeave>();
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
			ViewModel.sprLeave.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprLeave.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmLeave
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmLeaveViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmLeave m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}