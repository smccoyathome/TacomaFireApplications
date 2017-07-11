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

	public partial class frmTimeCard3
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmTimeCard3ViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmTimeCard3));
			if ( Shared.m_vb6FormDefInstance == null)
			{
				if ( Shared.m_InitializingDefInstance)
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
		}


		private void frmTimeCard3_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//**********************************
		//*  Battalion 3                 *
		//*  Time Card Worksheet           *
		//**********************************
		//ADODB

		public void ClearSpread()
		{
			//Clear Spread Fields
			ViewModel.sprBatt.BlockMode = false;
			ViewModel.sprBatt.Col = 8;
			ViewModel.sprBatt.Row = 2;
			ViewModel.sprBatt.Text = "";
			ViewModel.sprBatt.Col = 14;
			ViewModel.sprBatt.Text = "";
			ViewModel.sprBatt.Col = 20;
			ViewModel.sprBatt.Text = "";
			//    sprBatt.Row = 39
			//    sprBatt.Col = 25
			//    sprBatt.Text = ""
			//    sprBatt.Col = 26
			//    sprBatt.Row = 41
			//    sprBatt.Text = ""
			ViewModel.sprBatt.BlockMode = true;
			//1st Row
			ViewModel.sprBatt.Col = 1;
			ViewModel.sprBatt.Row = 4;
			ViewModel.sprBatt.Col2 = 6;
			ViewModel.sprBatt.Row2 = 15;
			//ViewModel.sprBatt.Action = (FarPoint.ViewModels.FPActionConstants) 12;
			ViewModel.sprBatt.FontBold = false;
			ViewModel.sprBatt.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprBatt.Col = 7;
			ViewModel.sprBatt.Row = 4;
			ViewModel.sprBatt.Col2 = 12;
			ViewModel.sprBatt.Row2 = 15;
			//ViewModel.sprBatt.Action = (FarPoint.ViewModels.FPActionConstants) 12;
			ViewModel.sprBatt.FontBold = false;
			ViewModel.sprBatt.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprBatt.Col = 13;
			ViewModel.sprBatt.Row = 4;
			ViewModel.sprBatt.Col2 = 18;
			ViewModel.sprBatt.Row2 = 15;
			//ViewModel.sprBatt.Action = (FarPoint.ViewModels.FPActionConstants) 12;
			ViewModel.sprBatt.FontBold = false;
			ViewModel.sprBatt.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprBatt.Col = 19;
			ViewModel.sprBatt.Row = 4;
			ViewModel.sprBatt.Col2 = 24;
			ViewModel.sprBatt.Row2 = 15;
			//ViewModel.sprBatt.Action = (FarPoint.ViewModels.FPActionConstants) 12;
			ViewModel.sprBatt.FontBold = false;
			ViewModel.sprBatt.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprBatt.Col = 25;
			ViewModel.sprBatt.Row = 4;
			ViewModel.sprBatt.Col2 = 30;
			ViewModel.sprBatt.Row2 = 15;
			//ViewModel.sprBatt.Action = (FarPoint.ViewModels.FPActionConstants) 12;
			ViewModel.sprBatt.FontBold = false;
			ViewModel.sprBatt.BackColor = modGlobal.Shared.WHITE;

			//2nd Row
			ViewModel.sprBatt.Col = 1;
			ViewModel.sprBatt.Row = 17;
			ViewModel.sprBatt.Col2 = 6;
			ViewModel.sprBatt.Row2 = 26;
			//ViewModel.sprBatt.Action = (FarPoint.ViewModels.FPActionConstants) 12;
			ViewModel.sprBatt.FontBold = false;
			ViewModel.sprBatt.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprBatt.Col = 7;
			ViewModel.sprBatt.Row = 17;
			ViewModel.sprBatt.Col2 = 12;
			ViewModel.sprBatt.Row2 = 26;
			//ViewModel.sprBatt.Action = (FarPoint.ViewModels.FPActionConstants) 12;
			ViewModel.sprBatt.FontBold = false;
			ViewModel.sprBatt.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprBatt.Col = 13;
			ViewModel.sprBatt.Row = 17;
			ViewModel.sprBatt.Col2 = 18;
			ViewModel.sprBatt.Row2 = 26;
			//ViewModel.sprBatt.Action = (FarPoint.ViewModels.FPActionConstants) 12;
			ViewModel.sprBatt.FontBold = false;
			ViewModel.sprBatt.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprBatt.Col = 19;
			ViewModel.sprBatt.Row = 17;
			ViewModel.sprBatt.Col2 = 24;
			ViewModel.sprBatt.Row2 = 26;
			//ViewModel.sprBatt.Action = (FarPoint.ViewModels.FPActionConstants) 12;
			ViewModel.sprBatt.FontBold = false;
			ViewModel.sprBatt.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprBatt.Col = 25;
			ViewModel.sprBatt.Row = 17;
			ViewModel.sprBatt.Col2 = 30;
			ViewModel.sprBatt.Row2 = 26;
			//ViewModel.sprBatt.Action = (FarPoint.ViewModels.FPActionConstants) 12;
			ViewModel.sprBatt.FontBold = false;
			ViewModel.sprBatt.BackColor = modGlobal.Shared.WHITE;

			//3rd Row
			ViewModel.sprBatt.Col = 1;
			ViewModel.sprBatt.Row = 28;
			ViewModel.sprBatt.Col2 = 6;
			ViewModel.sprBatt.Row2 = 37;
			//ViewModel.sprBatt.Action = (FarPoint.ViewModels.FPActionConstants) 12;
			ViewModel.sprBatt.FontBold = false;
			ViewModel.sprBatt.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprBatt.Col = 7;
			ViewModel.sprBatt.Row = 28;
			ViewModel.sprBatt.Col2 = 12;
			ViewModel.sprBatt.Row2 = 37;
			//ViewModel.sprBatt.Action = (FarPoint.ViewModels.FPActionConstants) 12;
			ViewModel.sprBatt.FontBold = false;
			ViewModel.sprBatt.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprBatt.Col = 13;
			ViewModel.sprBatt.Row = 28;
			ViewModel.sprBatt.Col2 = 18;
			ViewModel.sprBatt.Row2 = 37;
			//ViewModel.sprBatt.Action = (FarPoint.ViewModels.FPActionConstants) 12;
			ViewModel.sprBatt.FontBold = false;
			ViewModel.sprBatt.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprBatt.Col = 19;
			ViewModel.sprBatt.Row = 28;
			ViewModel.sprBatt.Col2 = 24;
			ViewModel.sprBatt.Row2 = 37;
			//ViewModel.sprBatt.Action = (FarPoint.ViewModels.FPActionConstants) 12;
			ViewModel.sprBatt.FontBold = false;
			ViewModel.sprBatt.BackColor = modGlobal.Shared.WHITE;

			//Notes
			ViewModel.sprBatt.Col = 25;
			ViewModel.sprBatt.Row = 28;
			ViewModel.sprBatt.Col2 = 30;
			ViewModel.sprBatt.Row2 = 42;
			//ViewModel.sprBatt.Action = (FarPoint.ViewModels.FPActionConstants) 12;
			ViewModel.sprBatt.FontBold = false;
			ViewModel.sprBatt.BackColor = modGlobal.Shared.WHITE;

			//4th Row
			ViewModel.sprBatt.Col = 1;
			ViewModel.sprBatt.Row = 39;
			ViewModel.sprBatt.Col2 = 6;
			ViewModel.sprBatt.Row2 = 48;
			//ViewModel.sprBatt.Action = (FarPoint.ViewModels.FPActionConstants) 12;
			ViewModel.sprBatt.FontBold = false;
			ViewModel.sprBatt.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprBatt.Col = 7;
			ViewModel.sprBatt.Row = 39;
			ViewModel.sprBatt.Col2 = 12;
			ViewModel.sprBatt.Row2 = 48;
			//ViewModel.sprBatt.Action = (FarPoint.ViewModels.FPActionConstants) 12;
			ViewModel.sprBatt.FontBold = false;
			ViewModel.sprBatt.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprBatt.Col = 13;
			ViewModel.sprBatt.Row = 39;
			ViewModel.sprBatt.Col2 = 18;
			ViewModel.sprBatt.Row2 = 48;
			//ViewModel.sprBatt.Action = (FarPoint.ViewModels.FPActionConstants) 12;
			ViewModel.sprBatt.FontBold = false;
			ViewModel.sprBatt.BackColor = modGlobal.Shared.WHITE;

			//Notes
			//    sprBatt.Col = 19
			//    sprBatt.Row = 39
			//    sprBatt.Col2 = 30
			//    sprBatt.Row2 = 48
			//    sprBatt.Action = 12
			//    sprBatt.BackColor = WHITE
			//    sprBatt.ForeColor = BLACK
			//Sign off area
			//    sprBatt.Row = 40
			//    sprBatt.Row2 = 40
			//    sprBatt.Col = 19
			//    sprBatt.Col2 = 30
			//    sprBatt.Action = 12

			//Anything extra...
			ViewModel.sprBatt.Col = 1;
			ViewModel.sprBatt.Row = 50;
			ViewModel.sprBatt.Col2 = 6;
			ViewModel.sprBatt.Row2 = 499;
			//ViewModel.sprBatt.Action = (FarPoint.ViewModels.FPActionConstants) 12;
			ViewModel.sprBatt.FontBold = false;
			ViewModel.sprBatt.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprBatt.Col = 7;
			ViewModel.sprBatt.Row = 49;
			ViewModel.sprBatt.Col2 = 30;
			ViewModel.sprBatt.Row2 = 499;
			//ViewModel.sprBatt.Action = (FarPoint.ViewModels.FPActionConstants) 12;
			ViewModel.sprBatt.FontBold = false;
			ViewModel.sprBatt.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprBatt.BlockMode = false;


		}

		public void FillSpread()
		{
			//Clear spreadsheet
			//Fill with data
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec2 = null;
			int x = 0;
			string CurrName = "", newName = "";
			string CurrTime = "", newTime = "";
			int CurrPayUp = 0, newPayUp = 0;
			string Note2 = "", Note1 = "", NoteChar = "";

			if (~ViewModel.FirstTime != 0)
			{
				ClearSpread();
			}
			else
			{
				ViewModel.FirstTime = 0;
			}
			bool ChangeFont = false;
			ViewModel.sprBatt.BlockMode = false;

			string StartDate = DateTime.Parse(ViewModel.calDate.Text).ToString("M/d/yyyy");
			ViewModel.sprBatt.Col = 8;
			ViewModel.sprBatt.Row = 2;
			ViewModel.sprBatt.Text = StartDate;

			string EndDate = DateTime.Parse(StartDate).AddDays(1).ToString("M/d/yyyy");
			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spReport_GetDebitGroup '" + StartDate + "','" + EndDate + "'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			string ShiftCode = modGlobal.Clean(oRec["shift_code"]);
			string DebitGroup = modGlobal.Clean(oRec["debit_group_code"]);
			ViewModel.sprBatt.Col = 14;
			ViewModel.sprBatt.Text = ShiftCode;
			ViewModel.sprBatt.Col = 20;
			ViewModel.sprBatt.Text = DebitGroup;

			//Load individual Units
			for (int i = 1; i <= 20; i++)
			{
				switch(i)
				{
					case 1 :
						oCmd.CommandText = "spReport_GetUnitBATT '" + StartDate + "','" + EndDate + "','BC03'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						x = 4;
						CurrName = "";
						CurrTime = "";
						CurrPayUp = 0;

						while(!oRec.EOF)
						{
							ViewModel.sprBatt.Col = 1;
							ViewModel.sprBatt.Row = x;
							newName = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
							newTime = modGlobal.Clean(oRec["TimeCode"]);
							newPayUp = Convert.ToInt32(oRec["pay_upgrade"]);
							if (CurrName == newName && CurrTime == newTime && CurrPayUp == newPayUp)
							{
								ViewModel.sprBatt.Col = 3;
								ViewModel.sprBatt.Row = x - 1;
								ViewModel.sprBatt.Text = "1";
							}
							else
							{
								ViewModel.sprBatt.Text = newName;
								ViewModel.sprBatt.Col = 2;
								ViewModel.sprBatt.Text = newTime;
								if (newTime == "OTP" || newTime == "EDO")
								{
									ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
								}
								else if (newTime == "DDF" || newTime == "UDD")
								{
									ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
								}
								else if (newTime == "TRD")
								{
									ViewModel.sprBatt.BackColor = modGlobal.Shared.GREEN;
								}
								ViewModel.sprBatt.Col = 3;
								ViewModel.sprBatt.Text = ".5";
								ViewModel.sprBatt.Col = 4;
								if (Convert.ToBoolean(oRec["pay_upgrade"]))
								{
									ViewModel.sprBatt.Text = "X";
									ViewModel.sprBatt.Col = 5;
									ViewModel.sprBatt.Text = Convert.ToString(oRec["job_code_id"]);
									ViewModel.sprBatt.Col = 6;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["up_step"]);
								}
								x++;
							}
							CurrName = newName;
							CurrTime = newTime;
							CurrPayUp = newPayUp;
							oRec.MoveNext();
						};
						oCmd.CommandText = "spReport_GetUnitLvBATT '" + StartDate + "','" + EndDate + "','BC03'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						while(!oRec.EOF)
						{
							ViewModel.sprBatt.Col = 1;
							ViewModel.sprBatt.Row = x;
							newName = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
							newTime = modGlobal.Clean(oRec["LeaveCode"]);
							if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1)
							{
								ChangeFont = true;
							}
							if (CurrName == newName && CurrTime == newTime)
							{
								ViewModel.sprBatt.Col = 3;
								ViewModel.sprBatt.Row = x - 1;
								ViewModel.sprBatt.Text = "1";
								if (ChangeFont)
								{
									ViewModel.sprBatt.Col = 2;
									ViewModel.sprBatt.FontBold = true;
									ChangeFont = false;
								}
							}
							else
							{
								ViewModel.sprBatt.Text = newName;
								ViewModel.sprBatt.Col = 2;
								ViewModel.sprBatt.Text = newTime;
								ViewModel.sprBatt.BackColor = modGlobal.Shared.WINE;
								if (ChangeFont)
								{
									ViewModel.sprBatt.FontBold = true;
									ChangeFont = false;
								}
								ViewModel.sprBatt.Col = 3;
								ViewModel.sprBatt.Text = ".5";
								if (modGlobal.Clean(oRec["LeaveCode"]) == "TRD")
								{
									ViewModel.sprBatt.Col = 2;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["TimeCode"]);
									if (modGlobal.Clean(oRec["TimeCode"]) == "OTP" || modGlobal.Clean(oRec["TimeCode"]) == "EDO")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
									}
									else if (modGlobal.Clean(oRec["TimeCode"]) == "DDF" || modGlobal.Clean(oRec["TimeCode"]) == "UDD")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
									}
									else
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.WHITE;
									}
									ViewModel.sprBatt.Col = 5;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["LeaveCode"]);
									ViewModel.sprBatt.BackColor = modGlobal.Shared.GREEN;
								}
								else if (modGlobal.Clean(oRec["TimeCode"]) != "REG")
								{
									ViewModel.sprBatt.Col = 5;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["TimeCode"]);
									if (modGlobal.Clean(oRec["TimeCode"]) == "OTP" || modGlobal.Clean(oRec["TimeCode"]) == "EDO")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
									}
									else if (modGlobal.Clean(oRec["TimeCode"]) == "DDF" || modGlobal.Clean(oRec["TimeCode"]) == "UDD")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
									}
								}
								x++;
							}
							CurrName = newName;
							CurrTime = newTime;
							oRec.MoveNext();
						};
						break;
					case 2 :
						oCmd.CommandText = "spReport_GetUnit '" + StartDate + "','" + EndDate + "','E07'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						x = 4;
						CurrName = "";
						CurrTime = "";
						CurrPayUp = 0;

						while(!oRec.EOF)
						{
							ViewModel.sprBatt.Col = 7;
							ViewModel.sprBatt.Row = x;
							newName = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
							newTime = modGlobal.Clean(oRec["TimeCode"]);
							newPayUp = Convert.ToInt32(oRec["pay_upgrade"]);
							if (CurrName == newName && CurrTime == newTime && CurrPayUp == newPayUp)
							{
								ViewModel.sprBatt.Col = 9;
								ViewModel.sprBatt.Row = x - 1;
								ViewModel.sprBatt.Text = "1";
							}
							else
							{
								ViewModel.sprBatt.Text = newName;
								ViewModel.sprBatt.Col = 8;
								ViewModel.sprBatt.Text = newTime;
								if (newTime == "OTP" || newTime == "EDO")
								{
									ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
								}
								else if (newTime == "DDF" || newTime == "UDD")
								{
									ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
								}
								else if (newTime == "TRD")
								{
									ViewModel.sprBatt.BackColor = modGlobal.Shared.GREEN;
								}
								ViewModel.sprBatt.Col = 9;
								ViewModel.sprBatt.Text = ".5";
								ViewModel.sprBatt.Col = 10;
								if (Convert.ToBoolean(oRec["pay_upgrade"]))
								{
									ViewModel.sprBatt.Text = "X";
									ViewModel.sprBatt.Col = 11;
									ViewModel.sprBatt.Text = Convert.ToString(oRec["job_code_id"]);
									ViewModel.sprBatt.Col = 12;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["up_step"]);
								}
								x++;
							}
							CurrName = newName;
							CurrTime = newTime;
							CurrPayUp = newPayUp;
							oRec.MoveNext();
						};
						oCmd.CommandText = "spReport_GetUnitLv '" + StartDate + "','" + EndDate + "','E07'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						while(!oRec.EOF)
						{
							ViewModel.sprBatt.Col = 7;
							ViewModel.sprBatt.Row = x;
							newName = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
							newTime = modGlobal.Clean(oRec["LeaveCode"]);
							if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1)
							{
								ChangeFont = true;
							}
							if (CurrName == newName && CurrTime == newTime)
							{
								ViewModel.sprBatt.Col = 9;
								ViewModel.sprBatt.Row = x - 1;
								ViewModel.sprBatt.Text = "1";
								if (ChangeFont)
								{
									ViewModel.sprBatt.Col = 8;
									ViewModel.sprBatt.FontBold = true;
									ChangeFont = false;
								}
							}
							else
							{
								ViewModel.sprBatt.Text = newName;
								ViewModel.sprBatt.Col = 8;
								ViewModel.sprBatt.Text = newTime;
								ViewModel.sprBatt.BackColor = modGlobal.Shared.WINE;
								if (ChangeFont)
								{
									ViewModel.sprBatt.FontBold = true;
									ChangeFont = false;
								}
								ViewModel.sprBatt.Col = 9;
								ViewModel.sprBatt.Text = ".5";
								if (modGlobal.Clean(oRec["LeaveCode"]) == "TRD")
								{
									ViewModel.sprBatt.Col = 8;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["TimeCode"]);
									if (modGlobal.Clean(oRec["TimeCode"]) == "OTP" || modGlobal.Clean(oRec["TimeCode"]) == "EDO")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
									}
									else if (modGlobal.Clean(oRec["TimeCode"]) == "DDF" || modGlobal.Clean(oRec["TimeCode"]) == "UDD")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
									}
									else
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.WHITE;
									}
									ViewModel.sprBatt.Col = 11;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["LeaveCode"]);
									ViewModel.sprBatt.BackColor = modGlobal.Shared.GREEN;
								}
								else if (modGlobal.Clean(oRec["TimeCode"]) != "REG")
								{
									ViewModel.sprBatt.Col = 11;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["TimeCode"]);
									if (modGlobal.Clean(oRec["TimeCode"]) == "OTP" || modGlobal.Clean(oRec["TimeCode"]) == "EDO")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
									}
									else if (modGlobal.Clean(oRec["TimeCode"]) == "DDF" || modGlobal.Clean(oRec["TimeCode"]) == "UDD")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
									}
								}
								x++;
							}
							CurrName = newName;
							CurrTime = newTime;
							oRec.MoveNext();
						};
						break;
					case 3 :
						oCmd.CommandText = "spReport_GetUnit '" + StartDate + "','" + EndDate + "','E08'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						x = 4;
						CurrName = "";
						CurrTime = "";
						CurrPayUp = 0;

						while(!oRec.EOF)
						{
							ViewModel.sprBatt.Col = 13;
							ViewModel.sprBatt.Row = x;
							newName = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
							newTime = modGlobal.Clean(oRec["TimeCode"]);
							newPayUp = Convert.ToInt32(oRec["pay_upgrade"]);
							if (CurrName == newName && CurrTime == newTime && CurrPayUp == newPayUp)
							{
								ViewModel.sprBatt.Col = 15;
								ViewModel.sprBatt.Row = x - 1;
								ViewModel.sprBatt.Text = "1";
							}
							else
							{
								ViewModel.sprBatt.Text = newName;
								ViewModel.sprBatt.Col = 14;
								ViewModel.sprBatt.Text = newTime;
								if (newTime == "OTP" || newTime == "EDO")
								{
									ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
								}
								else if (newTime == "DDF" || newTime == "UDD")
								{
									ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
								}
								else if (newTime == "TRD")
								{
									ViewModel.sprBatt.BackColor = modGlobal.Shared.GREEN;
								}
								ViewModel.sprBatt.Col = 15;
								ViewModel.sprBatt.Text = ".5";
								ViewModel.sprBatt.Col = 16;
								if (Convert.ToBoolean(oRec["pay_upgrade"]))
								{
									ViewModel.sprBatt.Text = "X";
									ViewModel.sprBatt.Col = 17;
									ViewModel.sprBatt.Text = Convert.ToString(oRec["job_code_id"]);
									ViewModel.sprBatt.Col = 18;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["up_step"]);
								}
								x++;
							}
							CurrName = newName;
							CurrTime = newTime;
							CurrPayUp = newPayUp;
							oRec.MoveNext();
						};
						oCmd.CommandText = "spReport_GetUnitLv '" + StartDate + "','" + EndDate + "','E08'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						while(!oRec.EOF)
						{
							ViewModel.sprBatt.Col = 13;
							ViewModel.sprBatt.Row = x;
							newName = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
							newTime = modGlobal.Clean(oRec["LeaveCode"]);
							if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1)
							{
								ChangeFont = true;
							}
							if (CurrName == newName && CurrTime == newTime)
							{
								ViewModel.sprBatt.Col = 15;
								ViewModel.sprBatt.Row = x - 1;
								ViewModel.sprBatt.Text = "1";
								if (ChangeFont)
								{
									ViewModel.sprBatt.Col = 14;
									ViewModel.sprBatt.FontBold = true;
									ChangeFont = false;
								}
							}
							else
							{
								ViewModel.sprBatt.Text = newName;
								ViewModel.sprBatt.Col = 14;
								ViewModel.sprBatt.Text = newTime;
								ViewModel.sprBatt.BackColor = modGlobal.Shared.WINE;
								if (ChangeFont)
								{
									ViewModel.sprBatt.FontBold = true;
									ChangeFont = false;
								}
								ViewModel.sprBatt.Col = 15;
								ViewModel.sprBatt.Text = ".5";
								if (modGlobal.Clean(oRec["LeaveCode"]) == "TRD")
								{
									ViewModel.sprBatt.Col = 14;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["TimeCode"]);
									if (modGlobal.Clean(oRec["TimeCode"]) == "EDO" || modGlobal.Clean(oRec["TimeCode"]) == "OTP")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
									}
									else if (modGlobal.Clean(oRec["TimeCode"]) == "DDF" || modGlobal.Clean(oRec["TimeCode"]) == "UDD")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
									}
									else
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.WHITE;
									}
									ViewModel.sprBatt.Col = 17;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["LeaveCode"]);
									ViewModel.sprBatt.BackColor = modGlobal.Shared.GREEN;
								}
								else if (modGlobal.Clean(oRec["TimeCode"]) != "REG")
								{
									ViewModel.sprBatt.Col = 17;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["TimeCode"]);
									if (modGlobal.Clean(oRec["TimeCode"]) == "EDO" || modGlobal.Clean(oRec["TimeCode"]) == "OTP")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
									}
									else if (modGlobal.Clean(oRec["TimeCode"]) == "DDF" || modGlobal.Clean(oRec["TimeCode"]) == "UDD")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
									}
								}
								x++;
							}
							CurrName = newName;
							CurrTime = newTime;
							oRec.MoveNext();
						};
						break;
					case 4 :
						oCmd.CommandText = "spReport_GetUnit '" + StartDate + "','" + EndDate + "','L02'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						x = 4;
						CurrName = "";
						CurrTime = "";
						CurrPayUp = 0;

						while(!oRec.EOF)
						{
							ViewModel.sprBatt.Col = 19;
							ViewModel.sprBatt.Row = x;
							newName = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
							newTime = modGlobal.Clean(oRec["TimeCode"]);
							newPayUp = Convert.ToInt32(oRec["pay_upgrade"]);
							if (CurrName == newName && CurrTime == newTime && CurrPayUp == newPayUp)
							{
								ViewModel.sprBatt.Col = 21;
								ViewModel.sprBatt.Row = x - 1;
								ViewModel.sprBatt.Text = "1";
							}
							else
							{
								ViewModel.sprBatt.Text = newName;
								ViewModel.sprBatt.Col = 20;
								ViewModel.sprBatt.Text = newTime;
								if (newTime == "OTP" || newTime == "EDO")
								{
									ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
								}
								else if (newTime == "DDF" || newTime == "UDD")
								{
									ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
								}
								else if (newTime == "TRD")
								{
									ViewModel.sprBatt.BackColor = modGlobal.Shared.GREEN;
								}
								ViewModel.sprBatt.Col = 21;
								ViewModel.sprBatt.Text = ".5";
								ViewModel.sprBatt.Col = 22;
								if (Convert.ToBoolean(oRec["pay_upgrade"]))
								{
									ViewModel.sprBatt.Text = "X";
									ViewModel.sprBatt.Col = 23;
									ViewModel.sprBatt.Text = Convert.ToString(oRec["job_code_id"]);
									ViewModel.sprBatt.Col = 24;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["up_step"]);
								}
								x++;
							}
							CurrName = newName;
							CurrTime = newTime;
							CurrPayUp = newPayUp;
							oRec.MoveNext();
						};
						oCmd.CommandText = "spReport_GetUnitLv '" + StartDate + "','" + EndDate + "','L02'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						while(!oRec.EOF)
						{
							ViewModel.sprBatt.Col = 19;
							ViewModel.sprBatt.Row = x;
							newName = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
							newTime = modGlobal.Clean(oRec["LeaveCode"]);
							if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1)
							{
								ChangeFont = true;
							}
							if (CurrName == newName && CurrTime == newTime)
							{
								ViewModel.sprBatt.Col = 21;
								ViewModel.sprBatt.Row = x - 1;
								ViewModel.sprBatt.Text = "1";
								if (ChangeFont)
								{
									ViewModel.sprBatt.Col = 20;
									ViewModel.sprBatt.FontBold = true;
									ChangeFont = false;
								}
							}
							else
							{
								ViewModel.sprBatt.Text = newName;
								ViewModel.sprBatt.Col = 20;
								ViewModel.sprBatt.Text = newTime;
								ViewModel.sprBatt.BackColor = modGlobal.Shared.WINE;
								if (ChangeFont)
								{
									ViewModel.sprBatt.FontBold = true;
									ChangeFont = false;
								}
								ViewModel.sprBatt.Col = 21;
								ViewModel.sprBatt.Text = ".5";
								ViewModel.sprBatt.Col = 23;
								ViewModel.sprBatt.Text = modGlobal.Clean(oRec["TimeCode"]);
								if (modGlobal.Clean(oRec["LeaveCode"]) == "TRD")
								{
									ViewModel.sprBatt.Col = 20;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["TimeCode"]);
									if (modGlobal.Clean(oRec["TimeCode"]) == "EDO" || modGlobal.Clean(oRec["TimeCode"]) == "OTP")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
									}
									else if (modGlobal.Clean(oRec["TimeCode"]) == "DDF" || modGlobal.Clean(oRec["TimeCode"]) == "UDD")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
									}
									else
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.WHITE;
									}
									ViewModel.sprBatt.Col = 23;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["LeaveCode"]);
									ViewModel.sprBatt.BackColor = modGlobal.Shared.GREEN;
								}
								else
								{
									if (modGlobal.Clean(oRec["TimeCode"]) == "OTP" || modGlobal.Clean(oRec["TimeCode"]) == "EDO")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
									}
									else if (modGlobal.Clean(oRec["TimeCode"]) == "DDF" || modGlobal.Clean(oRec["TimeCode"]) == "UDD")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
									}
								}
								x++;
							}
							CurrName = newName;
							CurrTime = newTime;
							oRec.MoveNext();
						};
						break;
					case 5 :
						oCmd.CommandText = "spReport_GetUnit '" + StartDate + "','" + EndDate + "','E10'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						x = 4;
						CurrName = "";
						CurrTime = "";
						CurrPayUp = 0;

						while(!oRec.EOF)
						{
							ViewModel.sprBatt.Col = 25;
							ViewModel.sprBatt.Row = x;
							newName = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
							newTime = modGlobal.Clean(oRec["TimeCode"]);
							newPayUp = Convert.ToInt32(oRec["pay_upgrade"]);
							if (CurrName == newName && CurrTime == newTime && CurrPayUp == newPayUp)
							{
								ViewModel.sprBatt.Col = 27;
								ViewModel.sprBatt.Row = x - 1;
								ViewModel.sprBatt.Text = "1";
							}
							else
							{
								ViewModel.sprBatt.Text = newName;
								ViewModel.sprBatt.Col = 26;
								ViewModel.sprBatt.Text = newTime;
								if (newTime == "EDO" || newTime == "OTP")
								{
									ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
								}
								else if (newTime == "DDF" || newTime == "UDD")
								{
									ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
								}
								else if (newTime == "TRD")
								{
									ViewModel.sprBatt.BackColor = modGlobal.Shared.GREEN;
								}
								ViewModel.sprBatt.Col = 27;
								ViewModel.sprBatt.Text = ".5";
								ViewModel.sprBatt.Col = 28;
								if (Convert.ToBoolean(oRec["pay_upgrade"]))
								{
									ViewModel.sprBatt.Text = "X";
									ViewModel.sprBatt.Col = 29;
									ViewModel.sprBatt.Text = Convert.ToString(oRec["job_code_id"]);
									ViewModel.sprBatt.Col = 30;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["up_step"]);
								}
								x++;
							}
							CurrName = newName;
							CurrTime = newTime;
							CurrPayUp = newPayUp;
							oRec.MoveNext();
						};
						oCmd.CommandText = "spReport_GetUnitLv '" + StartDate + "','" + EndDate + "','E10'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						while(!oRec.EOF)
						{
							ViewModel.sprBatt.Col = 25;
							ViewModel.sprBatt.Row = x;
							newName = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
							newTime = modGlobal.Clean(oRec["LeaveCode"]);
							if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1)
							{
								ChangeFont = true;
							}
							if (CurrName == newName && CurrTime == newTime)
							{
								ViewModel.sprBatt.Col = 27;
								ViewModel.sprBatt.Row = x - 1;
								ViewModel.sprBatt.Text = "1";
								if (ChangeFont)
								{
									ViewModel.sprBatt.Col = 26;
									ViewModel.sprBatt.FontBold = true;
									ChangeFont = false;
								}
							}
							else
							{
								ViewModel.sprBatt.Text = newName;
								ViewModel.sprBatt.Col = 26;
								ViewModel.sprBatt.Text = newTime;
								ViewModel.sprBatt.BackColor = modGlobal.Shared.WINE;
								if (ChangeFont)
								{
									ViewModel.sprBatt.FontBold = true;
									ChangeFont = false;
								}
								ViewModel.sprBatt.Col = 27;
								ViewModel.sprBatt.Text = ".5";
								if (modGlobal.Clean(oRec["LeaveCode"]) == "TRD")
								{
									ViewModel.sprBatt.Col = 26;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["TimeCode"]);
									if (modGlobal.Clean(oRec["TimeCode"]) == "OTP" || modGlobal.Clean(oRec["TimeCode"]) == "EDO")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
									}
									else if (modGlobal.Clean(oRec["TimeCode"]) == "DDF" || modGlobal.Clean(oRec["TimeCode"]) == "UDD")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
									}
									else
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.WHITE;
									}
									ViewModel.sprBatt.Col = 29;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["LeaveCode"]);
									ViewModel.sprBatt.BackColor = modGlobal.Shared.GREEN;
								}
								else if (modGlobal.Clean(oRec["TimeCode"]) != "REG")
								{
									ViewModel.sprBatt.Col = 29;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["TimeCode"]);
									if (modGlobal.Clean(oRec["TimeCode"]) == "OTP" || modGlobal.Clean(oRec["TimeCode"]) == "EDO")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
									}
									else if (modGlobal.Clean(oRec["TimeCode"]) == "DDF" || modGlobal.Clean(oRec["TimeCode"]) == "UDD")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
									}
								}
								x++;
							}
							CurrName = newName;
							CurrTime = newTime;
							oRec.MoveNext();
						};
						break;
					case 6 :
						oCmd.CommandText = "spReport_GetUnit '" + StartDate + "','" + EndDate + "','E11'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						x = 17;
						CurrName = "";
						CurrTime = "";
						CurrPayUp = 0;

						while(!oRec.EOF)
						{
							ViewModel.sprBatt.Col = 1;
							ViewModel.sprBatt.Row = x;
							newName = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
							newTime = modGlobal.Clean(oRec["TimeCode"]);
							newPayUp = Convert.ToInt32(oRec["pay_upgrade"]);
							if (CurrName == newName && CurrTime == newTime && CurrPayUp == newPayUp)
							{
								ViewModel.sprBatt.Col = 3;
								ViewModel.sprBatt.Row = x - 1;
								ViewModel.sprBatt.Text = "1";
							}
							else
							{
								ViewModel.sprBatt.Text = newName;
								ViewModel.sprBatt.Col = 2;
								ViewModel.sprBatt.Text = newTime;
								if (newTime == "OTP" || newTime == "EDO")
								{
									ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
								}
								else if (newTime == "DDF" || newTime == "UDD")
								{
									ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
								}
								else if (newTime == "TRD")
								{
									ViewModel.sprBatt.BackColor = modGlobal.Shared.GREEN;
								}
								ViewModel.sprBatt.Col = 3;
								ViewModel.sprBatt.Text = ".5";
								ViewModel.sprBatt.Col = 4;
								if (Convert.ToBoolean(oRec["pay_upgrade"]))
								{
									ViewModel.sprBatt.Text = "X";
									ViewModel.sprBatt.Col = 5;
									ViewModel.sprBatt.Text = Convert.ToString(oRec["job_code_id"]);
									ViewModel.sprBatt.Col = 6;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["up_step"]);
								}
								x++;
							}
							CurrName = newName;
							CurrTime = newTime;
							CurrPayUp = newPayUp;
							oRec.MoveNext();
						};
						oCmd.CommandText = "spReport_GetUnitLv '" + StartDate + "','" + EndDate + "','E11'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						while(!oRec.EOF)
						{
							ViewModel.sprBatt.Col = 1;
							ViewModel.sprBatt.Row = x;
							newName = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
							newTime = modGlobal.Clean(oRec["LeaveCode"]);
							if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1)
							{
								ChangeFont = true;
							}
							if (CurrName == newName && CurrTime == newTime)
							{
								ViewModel.sprBatt.Col = 3;
								ViewModel.sprBatt.Row = x - 1;
								ViewModel.sprBatt.Text = "1";
								if (ChangeFont)
								{
									ViewModel.sprBatt.Col = 2;
									ViewModel.sprBatt.FontBold = true;
									ChangeFont = false;
								}
							}
							else
							{
								ViewModel.sprBatt.Text = newName;
								ViewModel.sprBatt.Col = 2;
								ViewModel.sprBatt.Text = newTime;
								ViewModel.sprBatt.BackColor = modGlobal.Shared.WINE;
								if (ChangeFont)
								{
									ViewModel.sprBatt.FontBold = true;
									ChangeFont = false;
								}
								ViewModel.sprBatt.Col = 3;
								ViewModel.sprBatt.Text = ".5";
								if (modGlobal.Clean(oRec["LeaveCode"]) == "TRD")
								{
									ViewModel.sprBatt.Col = 2;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["TimeCode"]);
									if (modGlobal.Clean(oRec["TimeCode"]) == "OTP" || modGlobal.Clean(oRec["TimeCode"]) == "EDO")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
									}
									else if (modGlobal.Clean(oRec["TimeCode"]) == "DDF" || modGlobal.Clean(oRec["TimeCode"]) == "UDD")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
									}
									else
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.WHITE;
									}
									ViewModel.sprBatt.Col = 5;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["LeaveCode"]);
									ViewModel.sprBatt.BackColor = modGlobal.Shared.GREEN;
								}
								else if (modGlobal.Clean(oRec["TimeCode"]) != "REG")
								{
									ViewModel.sprBatt.Col = 5;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["TimeCode"]);
									if (modGlobal.Clean(oRec["TimeCode"]) == "OTP" || modGlobal.Clean(oRec["TimeCode"]) == "EDO")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
									}
									else if (modGlobal.Clean(oRec["TimeCode"]) == "DDF" || modGlobal.Clean(oRec["TimeCode"]) == "UDD")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
									}
								}
								x++;
							}
							CurrName = newName;
							CurrTime = newTime;
							oRec.MoveNext();
						};
						break;
					case 7 :
						oCmd.CommandText = "spReport_GetUnit '" + StartDate + "','" + EndDate + "','E15'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						x = 17;
						CurrName = "";
						CurrTime = "";
						CurrPayUp = 0;

						while(!oRec.EOF)
						{
							ViewModel.sprBatt.Col = 7;
							ViewModel.sprBatt.Row = x;
							newName = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
							newTime = modGlobal.Clean(oRec["TimeCode"]);
							newPayUp = Convert.ToInt32(oRec["pay_upgrade"]);
							if (CurrName == newName && CurrTime == newTime && CurrPayUp == newPayUp)
							{
								ViewModel.sprBatt.Col = 9;
								ViewModel.sprBatt.Row = x - 1;
								ViewModel.sprBatt.Text = "1";
							}
							else
							{
								ViewModel.sprBatt.Text = newName;
								ViewModel.sprBatt.Col = 8;
								ViewModel.sprBatt.Text = newTime;
								if (newTime == "OTP" || newTime == "EDO")
								{
									ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
								}
								else if (newTime == "DDF" || newTime == "UDD")
								{
									ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
								}
								else if (newTime == "TRD")
								{
									ViewModel.sprBatt.BackColor = modGlobal.Shared.GREEN;
								}
								ViewModel.sprBatt.Col = 9;
								ViewModel.sprBatt.Text = ".5";
								ViewModel.sprBatt.Col = 10;
								if (Convert.ToBoolean(oRec["pay_upgrade"]))
								{
									ViewModel.sprBatt.Text = "X";
									ViewModel.sprBatt.Col = 11;
									ViewModel.sprBatt.Text = Convert.ToString(oRec["job_code_id"]);
									ViewModel.sprBatt.Col = 12;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["up_step"]);
								}
								x++;
							}
							CurrName = newName;
							CurrTime = newTime;
							CurrPayUp = newPayUp;
							oRec.MoveNext();
						};
						oCmd.CommandText = "spReport_GetUnitLv '" + StartDate + "','" + EndDate + "','E15'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						while(!oRec.EOF)
						{
							ViewModel.sprBatt.Col = 7;
							ViewModel.sprBatt.Row = x;
							newName = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
							newTime = modGlobal.Clean(oRec["LeaveCode"]);
							if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1)
							{
								ChangeFont = true;
							}
							if (CurrName == newName && CurrTime == newTime)
							{
								ViewModel.sprBatt.Col = 9;
								ViewModel.sprBatt.Row = x - 1;
								ViewModel.sprBatt.Text = "1";
								if (ChangeFont)
								{
									ViewModel.sprBatt.Col = 8;
									ViewModel.sprBatt.FontBold = true;
									ChangeFont = false;
								}
							}
							else
							{
								ViewModel.sprBatt.Text = newName;
								ViewModel.sprBatt.Col = 8;
								ViewModel.sprBatt.Text = newTime;
								ViewModel.sprBatt.BackColor = modGlobal.Shared.WINE;
								if (ChangeFont)
								{
									ViewModel.sprBatt.FontBold = true;
									ChangeFont = false;
								}
								ViewModel.sprBatt.Col = 9;
								ViewModel.sprBatt.Text = ".5";
								if (modGlobal.Clean(oRec["LeaveCode"]) == "TRD")
								{
									ViewModel.sprBatt.Col = 8;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["TimeCode"]);
									if (modGlobal.Clean(oRec["TimeCode"]) == "EDO" || modGlobal.Clean(oRec["TimeCode"]) == "OTP")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
									}
									else if (modGlobal.Clean(oRec["TimeCode"]) == "DDF" || modGlobal.Clean(oRec["TimeCode"]) == "UDD")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
									}
									else
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.WHITE;
									}
									ViewModel.sprBatt.Col = 11;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["LeaveCode"]);
									ViewModel.sprBatt.BackColor = modGlobal.Shared.GREEN;
								}
								else if (modGlobal.Clean(oRec["TimeCode"]) != "REG")
								{
									ViewModel.sprBatt.Col = 11;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["TimeCode"]);
									if (modGlobal.Clean(oRec["TimeCode"]) == "OTP" || modGlobal.Clean(oRec["TimeCode"]) == "EDO")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
									}
									else if (modGlobal.Clean(oRec["TimeCode"]) == "DDF" || modGlobal.Clean(oRec["TimeCode"]) == "UDD")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
									}
								}
								x++;
							}
							CurrName = newName;
							CurrTime = newTime;
							oRec.MoveNext();
						};
						break;
					case 8 :
						oCmd.CommandText = "spReport_GetUnit '" + StartDate + "','" + EndDate + "','M02'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						x = 17;
						CurrName = "";
						CurrTime = "";
						CurrPayUp = 0;

						while(!oRec.EOF)
						{
							ViewModel.sprBatt.Col = 13;
							ViewModel.sprBatt.Row = x;
							newName = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
							newTime = modGlobal.Clean(oRec["TimeCode"]);
							newPayUp = Convert.ToInt32(oRec["pay_upgrade"]);
							if (CurrName == newName && CurrTime == newTime && CurrPayUp == newPayUp)
							{
								ViewModel.sprBatt.Col = 15;
								ViewModel.sprBatt.Row = x - 1;
								ViewModel.sprBatt.Text = "1";
							}
							else
							{
								ViewModel.sprBatt.Text = newName;
								ViewModel.sprBatt.Col = 14;
								ViewModel.sprBatt.Text = newTime;
								if (newTime == "OTP" || newTime == "EDO")
								{
									ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
								}
								else if (newTime == "DDF" || newTime == "UDD")
								{
									ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
								}
								else if (newTime == "TRD")
								{
									ViewModel.sprBatt.BackColor = modGlobal.Shared.GREEN;
								}
								ViewModel.sprBatt.Col = 15;
								ViewModel.sprBatt.Text = ".5";
								ViewModel.sprBatt.Col = 16;
								if (Convert.ToBoolean(oRec["pay_upgrade"]))
								{
									ViewModel.sprBatt.Text = "X";
									ViewModel.sprBatt.Col = 17;
									ViewModel.sprBatt.Text = Convert.ToString(oRec["job_code_id"]);
									ViewModel.sprBatt.Col = 18;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["up_step"]);
								}
								x++;
							}
							CurrName = newName;
							CurrTime = newTime;
							CurrPayUp = newPayUp;
							oRec.MoveNext();
						};
						oCmd.CommandText = "spReport_GetUnitLv '" + StartDate + "','" + EndDate + "','M02'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						while(!oRec.EOF)
						{
							ViewModel.sprBatt.Col = 13;
							ViewModel.sprBatt.Row = x;
							newName = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
							newTime = modGlobal.Clean(oRec["LeaveCode"]);
							if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1)
							{
								ChangeFont = true;
							}
							if (CurrName == newName && CurrTime == newTime)
							{
								ViewModel.sprBatt.Col = 15;
								ViewModel.sprBatt.Row = x - 1;
								ViewModel.sprBatt.Text = "1";
								if (ChangeFont)
								{
									ViewModel.sprBatt.Col = 14;
									ViewModel.sprBatt.FontBold = true;
									ChangeFont = false;
								}
							}
							else
							{
								ViewModel.sprBatt.Text = newName;
								ViewModel.sprBatt.Col = 14;
								ViewModel.sprBatt.Text = newTime;
								ViewModel.sprBatt.BackColor = modGlobal.Shared.WINE;
								if (ChangeFont)
								{
									ViewModel.sprBatt.FontBold = true;
									ChangeFont = false;
								}
								ViewModel.sprBatt.Col = 15;
								ViewModel.sprBatt.Text = ".5";
								if (modGlobal.Clean(oRec["LeaveCode"]) == "TRD")
								{
									ViewModel.sprBatt.Col = 14;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["TimeCode"]);
									if (modGlobal.Clean(oRec["TimeCode"]) == "OTP" || modGlobal.Clean(oRec["TimeCode"]) == "EDO")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
									}
									else if (modGlobal.Clean(oRec["TimeCode"]) == "DDF" || modGlobal.Clean(oRec["TimeCode"]) == "UDD")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
									}
									else
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.WHITE;
									}
									ViewModel.sprBatt.Col = 17;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["LeaveCode"]);
									ViewModel.sprBatt.BackColor = modGlobal.Shared.GREEN;
								}
								else if (modGlobal.Clean(oRec["TimeCode"]) != "REG")
								{
									ViewModel.sprBatt.Col = 17;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["TimeCode"]);
									if (modGlobal.Clean(oRec["TimeCode"]) == "OTP" || modGlobal.Clean(oRec["TimeCode"]) == "EDO")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
									}
									else if (modGlobal.Clean(oRec["TimeCode"]) == "DDF" || modGlobal.Clean(oRec["TimeCode"]) == "UDD")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
									}
								}
								x++;
							}
							CurrName = newName;
							CurrTime = newTime;
							oRec.MoveNext();
						};
						break;
					case 9 :
						oCmd.CommandText = "spReport_GetUnit '" + StartDate + "','" + EndDate + "','M05'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						x = 17;
						CurrName = "";
						CurrTime = "";
						CurrPayUp = 0;

						while(!oRec.EOF)
						{
							ViewModel.sprBatt.Col = 19;
							ViewModel.sprBatt.Row = x;
							newName = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
							newTime = modGlobal.Clean(oRec["TimeCode"]);
							newPayUp = Convert.ToInt32(oRec["pay_upgrade"]);
							if (CurrName == newName && CurrTime == newTime && CurrPayUp == newPayUp)
							{
								ViewModel.sprBatt.Col = 21;
								ViewModel.sprBatt.Row = x - 1;
								ViewModel.sprBatt.Text = "1";
							}
							else
							{
								ViewModel.sprBatt.Text = newName;
								ViewModel.sprBatt.Col = 20;
								ViewModel.sprBatt.Text = newTime;
								if (newTime == "EDO" || newTime == "OTP")
								{
									ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
								}
								else if (newTime == "DDF" || newTime == "UDD")
								{
									ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
								}
								else if (newTime == "TRD")
								{
									ViewModel.sprBatt.BackColor = modGlobal.Shared.GREEN;
								}
								ViewModel.sprBatt.Col = 21;
								ViewModel.sprBatt.Text = ".5";
								ViewModel.sprBatt.Col = 22;
								if (Convert.ToBoolean(oRec["pay_upgrade"]))
								{
									ViewModel.sprBatt.Text = "X";
									ViewModel.sprBatt.Col = 23;
									ViewModel.sprBatt.Text = Convert.ToString(oRec["job_code_id"]);
									ViewModel.sprBatt.Col = 24;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["up_step"]);
								}
								x++;
							}
							CurrName = newName;
							CurrTime = newTime;
							CurrPayUp = newPayUp;
							oRec.MoveNext();
						};
						oCmd.CommandText = "spReport_GetUnitLv '" + StartDate + "','" + EndDate + "','M05'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						while(!oRec.EOF)
						{
							ViewModel.sprBatt.Col = 19;
							ViewModel.sprBatt.Row = x;
							newName = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
							newTime = modGlobal.Clean(oRec["LeaveCode"]);
							if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1)
							{
								ChangeFont = true;
							}
							if (CurrName == newName && CurrTime == newTime)
							{
								ViewModel.sprBatt.Col = 21;
								ViewModel.sprBatt.Row = x - 1;
								ViewModel.sprBatt.Text = "1";
								if (ChangeFont)
								{
									ViewModel.sprBatt.Col = 20;
									ViewModel.sprBatt.FontBold = true;
									ChangeFont = false;
								}
							}
							else
							{
								ViewModel.sprBatt.Text = newName;
								ViewModel.sprBatt.Col = 20;
								ViewModel.sprBatt.Text = newTime;
								ViewModel.sprBatt.BackColor = modGlobal.Shared.WINE;
								if (ChangeFont)
								{
									ViewModel.sprBatt.FontBold = true;
									ChangeFont = false;
								}
								ViewModel.sprBatt.Col = 21;
								ViewModel.sprBatt.Text = ".5";
								if (modGlobal.Clean(oRec["LeaveCode"]) == "TRD")
								{
									ViewModel.sprBatt.Col = 20;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["TimeCode"]);
									if (modGlobal.Clean(oRec["TimeCode"]) == "OTP" || modGlobal.Clean(oRec["TimeCode"]) == "EDO")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
									}
									else if (modGlobal.Clean(oRec["TimeCode"]) == "DDF" || modGlobal.Clean(oRec["TimeCode"]) == "UDD")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
									}
									else
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.WHITE;
									}
									ViewModel.sprBatt.Col = 23;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["LeaveCode"]);
									ViewModel.sprBatt.BackColor = modGlobal.Shared.GREEN;
								}
								else if (modGlobal.Clean(oRec["TimeCode"]) != "REG")
								{
									ViewModel.sprBatt.Col = 23;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["TimeCode"]);
									if (modGlobal.Clean(oRec["TimeCode"]) == "EDO" || modGlobal.Clean(oRec["TimeCode"]) == "OTP")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
									}
									else if (modGlobal.Clean(oRec["TimeCode"]) == "DDF" || modGlobal.Clean(oRec["TimeCode"]) == "UDD")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
									}
								}
								x++;
							}
							CurrName = newName;
							CurrTime = newTime;
							oRec.MoveNext();
						};
						break;
					case 10 :
						//                oCmd.CommandText = "spReport_GetUnit '" & StartDate & "','" & EndDate & "','M04'" 
						//                Set oRec = oCmd.Execute 
						//                x = 17 
						//                CurrName = "" 
						//                CurrTime = "" 
						//                CurrPayUp = False 
						//                Do Until oRec.EOF 
						//                    sprBatt.Col = 25 
						//                    sprBatt.Row = x 
						//                    newName = Trim$(oRec("name_last"]) & " " & Left$(oRec("name_first"), 1) & "." 
						//                    newTime = Clean(oRec("TimeCode"]) 
						//                    newPayUp = oRec("pay_upgrade") 
						//                    If CurrName = newName And CurrTime = newTime And CurrPayUp = newPayUp Then 
						//                        sprBatt.Col = 27 
						//                        sprBatt.Row = x - 1 
						//                        sprBatt.Text = "1" 
						//                    Else 
						//                        sprBatt.Text = newName 
						//                        sprBatt.Col = 26 
						//                        sprBatt.Text = newTime 
						//                        If newTime = "EDO" Or newTime = "OTP" Then 
						//                            sprBatt.ForeColor = WHITE 
						//                            sprBatt.BackColor = RED 
						//                        ElseIf newTime = "DDF" Or newTime = "UDD" Then 
						//                            sprBatt.ForeColor = WHITE 
						//                            sprBatt.BackColor = BLUE 
						//                        ElseIf newTime = "TRD" Then 
						//                            sprBatt.ForeColor = WHITE 
						//                            sprBatt.BackColor = GREEN 
						//                        End If 
						//                        sprBatt.Col = 27 
						//                        sprBatt.Text = ".5" 
						//                        sprBatt.Col = 28 
						//                        If oRec("pay_upgrade") Then 
						//                            sprBatt.Text = "X" 
						//                            sprBatt.ForeColor = RED 
						//                            sprBatt.Col = 29 
						//                            sprBatt.Text = oRec("job_code_id") 
						//                            sprBatt.ForeColor = RED 
						//                            sprBatt.Col = 30 
						//                            sprBatt.Text = Clean(oRec("up_step"]) 
						//                            sprBatt.ForeColor = RED 
						//                        End If 
						//                        x = x + 1 
						//                    End If 
						//                    CurrName = newName 
						//                    CurrTime = newTime 
						//                    CurrPayUp = newPayUp 
						//                    oRec.MoveNext 
						//                Loop 
						//                oCmd.CommandText = "spReport_GetUnitLv '" & StartDate & "','" & EndDate & "','M04'" 
						//                Set oRec = oCmd.Execute 
						//                Do Until oRec.EOF 
						//                    sprBatt.Col = 25 
						//                    sprBatt.Row = x 
						//                    newName = Trim$(oRec("name_last"]) & " " & Left$(oRec("name_first"), 1) & "." 
						//                    newTime = Clean(oRec("LeaveCode"]) 
						//                    If Clean(oRec("vacation_bank_flag"]) = 1 Then 
						//                        ChangeFont = True 
						//                    End If 
						//                    If CurrName = newName And CurrTime = newTime Then 
						//                        sprBatt.Col = 27 
						//                        sprBatt.Row = x - 1 
						//                        sprBatt.Text = "1" 
						//                        If ChangeFont Then 
						//                            sprBatt.Col = 26 
						//                            sprBatt.FontBold = True 
						//                            sprBatt.ForeColor = YELLOW 
						//                            ChangeFont = False 
						//                        End If 
						//                    Else 
						//                        sprBatt.Text = newName 
						//                        sprBatt.Col = 26 
						//                        sprBatt.Text = newTime 
						//                        sprBatt.ForeColor = WHITE 
						//                        sprBatt.BackColor = WINE 
						//                        If ChangeFont Then 
						//                            sprBatt.FontBold = True 
						//                            sprBatt.ForeColor = YELLOW 
						//                            ChangeFont = False 
						//                        End If 
						//                        sprBatt.Col = 27 
						//                        sprBatt.Text = ".5" 
						//                        If Clean(oRec("LeaveCode"]) = "TRD" Then 
						//                                sprBatt.Col = 26 
						//                                sprBatt.Text = Clean(oRec("TimeCode"]) 
						//                                If Clean(oRec("TimeCode"]) = "OTP" Or Clean(oRec("TimeCode"]) = "EDO" Then 
						//                                    sprBatt.ForeColor = WHITE 
						//                                    sprBatt.BackColor = RED 
						//                                ElseIf Clean(oRec("TimeCode"]) = "DDF" Or Clean(oRec("TimeCode"]) = "UDD" Then 
						//                                    sprBatt.ForeColor = WHITE 
						//                                    sprBatt.BackColor = BLUE 
						//                                Else 
						//                                    sprBatt.ForeColor = BLACK 
						//                                    sprBatt.BackColor = WHITE 
						//                                End If 
						//                                sprBatt.Col = 29 
						//                                sprBatt.Text = Clean(oRec("LeaveCode"]) 
						//                                sprBatt.ForeColor = WHITE 
						//                                sprBatt.BackColor = GREEN 
						//                        ElseIf Clean(oRec("TimeCode"]) <> "REG" Then 
						//                            sprBatt.Col = 29 
						//                            sprBatt.Text = Clean(oRec("TimeCode"]) 
						//                            If Clean(oRec("TimeCode"]) = "OTP" Or Clean(oRec("TimeCode"]) = "EDO" Then 
						//                                sprBatt.ForeColor = WHITE 
						//                                sprBatt.BackColor = RED 
						//                            ElseIf Clean(oRec("TimeCode"]) = "DDF" Or Clean(oRec("TimeCode"]) = "UDD" Then 
						//                                sprBatt.ForeColor = WHITE 
						//                                sprBatt.BackColor = BLUE 
						//                            End If 
						//                        End If 
						//                        x = x + 1 
						//                    End If 
						//                    CurrName = newName 
						//                    CurrTime = newTime 
						//                    oRec.MoveNext 
						//                Loop 
						break;
					case 12 :
						oCmd.CommandText = "spReport_GetUnit '" + StartDate + "','" + EndDate + "','SAF03'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						x = 28;
						CurrName = "";
						CurrTime = "";
						CurrPayUp = 0;

						while(!oRec.EOF)
						{
							ViewModel.sprBatt.Col = 1;
							ViewModel.sprBatt.Row = x;
							newName = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
							newTime = modGlobal.Clean(oRec["TimeCode"]);
							newPayUp = Convert.ToInt32(oRec["pay_upgrade"]);
							if (CurrName == newName && CurrTime == newTime && CurrPayUp == newPayUp)
							{
								ViewModel.sprBatt.Col = 3;
								ViewModel.sprBatt.Row = x - 1;
								ViewModel.sprBatt.Text = "1";
							}
							else
							{
								ViewModel.sprBatt.Text = newName;
								ViewModel.sprBatt.Col = 2;
								ViewModel.sprBatt.Text = newTime;
								if (newTime == "EDO" || newTime == "OTP")
								{
									ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
								}
								else if (newTime == "DDF" || newTime == "UDD")
								{
									ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
								}
								else if (newTime == "TRD")
								{
									ViewModel.sprBatt.BackColor = modGlobal.Shared.GREEN;
								}
								ViewModel.sprBatt.Col = 3;
								ViewModel.sprBatt.Text = ".5";
								ViewModel.sprBatt.Col = 4;
								if (Convert.ToBoolean(oRec["pay_upgrade"]))
								{
									ViewModel.sprBatt.Text = "X";
									ViewModel.sprBatt.Col = 5;
									ViewModel.sprBatt.Text = Convert.ToString(oRec["job_code_id"]);
									ViewModel.sprBatt.Col = 6;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["up_step"]);
								}
								x++;
							}
							CurrName = newName;
							CurrTime = newTime;
							CurrPayUp = newPayUp;
							oRec.MoveNext();
						};
						oCmd.CommandText = "spReport_GetUnitLv '" + StartDate + "','" + EndDate + "','SAF03'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						while(!oRec.EOF)
						{
							ViewModel.sprBatt.Col = 1;
							ViewModel.sprBatt.Row = x;
							newName = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
							newTime = modGlobal.Clean(oRec["LeaveCode"]);
							if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1)
							{
								ChangeFont = true;
							}
							if (CurrName == newName && CurrTime == newTime)
							{
								ViewModel.sprBatt.Col = 3;
								ViewModel.sprBatt.Row = x - 1;
								ViewModel.sprBatt.Text = "1";
								if (ChangeFont)
								{
									ViewModel.sprBatt.Col = 2;
									ViewModel.sprBatt.FontBold = true;
									ChangeFont = false;
								}
							}
							else
							{
								ViewModel.sprBatt.Text = newName;
								ViewModel.sprBatt.Col = 2;
								ViewModel.sprBatt.Text = newTime;
								ViewModel.sprBatt.BackColor = modGlobal.Shared.WINE;
								if (ChangeFont)
								{
									ViewModel.sprBatt.FontBold = true;
									ChangeFont = false;
								}
								ViewModel.sprBatt.Col = 3;
								ViewModel.sprBatt.Text = ".5";
								if (modGlobal.Clean(oRec["LeaveCode"]) == "TRD")
								{
									ViewModel.sprBatt.Col = 2;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["TimeCode"]);
									if (modGlobal.Clean(oRec["TimeCode"]) == "OTP" || modGlobal.Clean(oRec["TimeCode"]) == "EDO")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
									}
									else if (modGlobal.Clean(oRec["TimeCode"]) == "DDF" || modGlobal.Clean(oRec["TimeCode"]) == "UDD")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
									}
									else
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.WHITE;
									}
									ViewModel.sprBatt.Col = 5;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["LeaveCode"]);
									ViewModel.sprBatt.BackColor = modGlobal.Shared.GREEN;
								}
								else if (modGlobal.Clean(oRec["TimeCode"]) != "REG")
								{
									ViewModel.sprBatt.Col = 5;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["TimeCode"]);
									if (modGlobal.Clean(oRec["TimeCode"]) == "EDO" || modGlobal.Clean(oRec["TimeCode"]) == "OTP")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
									}
									else if (modGlobal.Clean(oRec["TimeCode"]) == "DDF" || modGlobal.Clean(oRec["TimeCode"]) == "UDD")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
									}
								}
								x++;
							}
							CurrName = newName;
							CurrTime = newTime;
							oRec.MoveNext();
						};
						break;
					case 13 :
						//                oCmd.CommandText = "spReport_GetUnit '" & StartDate & "','" & EndDate & "','M01'" 
						//                Set oRec = oCmd.Execute 
						//                x = 28 
						//                CurrName = "" 
						//                CurrTime = "" 
						//                CurrPayUp = False 
						//                Do Until oRec.EOF 
						//                    sprBatt.Col = 7 
						//                    sprBatt.Row = x 
						//                    newName = Trim$(oRec("name_last"]) & " " & Left$(oRec("name_first"), 1) & "." 
						//                    newTime = Clean(oRec("TimeCode"]) 
						//                    newPayUp = oRec("pay_upgrade") 
						//                    If CurrName = newName And CurrTime = newTime And CurrPayUp = newPayUp Then 
						//                        sprBatt.Col = 9 
						//                        sprBatt.Row = x - 1 
						//                        sprBatt.Text = "1" 
						//                    Else 
						//                        sprBatt.Text = newName 
						//                        sprBatt.Col = 8 
						//                        sprBatt.Text = newTime 
						//                        If newTime = "OTP" Or newTime = "EDO" Then 
						//                            sprBatt.ForeColor = WHITE 
						//                            sprBatt.BackColor = RED 
						//                        ElseIf newTime = "DDF" Or newTime = "UDD" Then 
						//                            sprBatt.ForeColor = WHITE 
						//                            sprBatt.BackColor = BLUE 
						//                        ElseIf newTime = "TRD" Then 
						//                            sprBatt.ForeColor = WHITE 
						//                            sprBatt.BackColor = GREEN 
						//                        End If 
						//                        sprBatt.Col = 9 
						//                        sprBatt.Text = ".5" 
						//                        sprBatt.Col = 10 
						//                        If oRec("pay_upgrade") Then 
						//                            sprBatt.Text = "X" 
						//                            sprBatt.ForeColor = RED 
						//                            sprBatt.Col = 11 
						//                            sprBatt.Text = oRec("job_code_id") 
						//                            sprBatt.ForeColor = RED 
						//                            sprBatt.Col = 12 
						//                            sprBatt.Text = Clean(oRec("up_step"]) 
						//                            sprBatt.ForeColor = RED 
						//                        End If 
						//                        x = x + 1 
						//                    End If 
						//                    CurrName = newName 
						//                    CurrTime = newTime 
						//                    CurrPayUp = newPayUp 
						//                    oRec.MoveNext 
						//                Loop 
						//                oCmd.CommandText = "spReport_GetUnitLv '" & StartDate & "','" & EndDate & "','M01'" 
						//                Set oRec = oCmd.Execute 
						//                Do Until oRec.EOF 
						//                    sprBatt.Col = 7 
						//                    sprBatt.Row = x 
						//                    newName = Trim$(oRec("name_last"]) & " " & Left$(oRec("name_first"), 1) & "." 
						//                    newTime = Clean(oRec("LeaveCode"]) 
						//                    If Clean(oRec("vacation_bank_flag"]) = 1 Then 
						//                        ChangeFont = True 
						//                    End If 
						//                    If CurrName = newName And CurrTime = newTime Then 
						//                        sprBatt.Col = 9 
						//                        sprBatt.Row = x - 1 
						//                        sprBatt.Text = "1" 
						//                        If ChangeFont Then 
						//                            sprBatt.Col = 8 
						//                            sprBatt.FontBold = True 
						//                            sprBatt.ForeColor = YELLOW 
						//                            ChangeFont = False 
						//                        End If 
						//                    Else 
						//                        sprBatt.Text = newName 
						//                        sprBatt.Col = 8 
						//                        sprBatt.Text = newTime 
						//                        sprBatt.ForeColor = WHITE 
						//                        sprBatt.BackColor = WINE 
						//                        If ChangeFont Then 
						//                            sprBatt.FontBold = True 
						//                            sprBatt.ForeColor = YELLOW 
						//                            ChangeFont = False 
						//                        End If 
						//                        sprBatt.Col = 9 
						//                        sprBatt.Text = ".5" 
						//                        If Clean(oRec("LeaveCode"]) = "TRD" Then 
						//                                sprBatt.Col = 8 
						//                                sprBatt.Text = Clean(oRec("TimeCode"]) 
						//                                If Clean(oRec("TimeCode"]) = "EDO" Or Clean(oRec("TimeCode"]) = "OTP" Then 
						//                                    sprBatt.ForeColor = WHITE 
						//                                    sprBatt.BackColor = RED 
						//                                ElseIf Clean(oRec("TimeCode"]) = "DDF" Or Clean(oRec("TimeCode"]) = "UDD" Then 
						//                                    sprBatt.ForeColor = WHITE 
						//                                    sprBatt.BackColor = BLUE 
						//                                Else 
						//                                    sprBatt.ForeColor = BLACK 
						//                                    sprBatt.BackColor = WHITE 
						//                                End If 
						//                                sprBatt.Col = 11 
						//                                sprBatt.Text = Clean(oRec("LeaveCode"]) 
						//                                sprBatt.ForeColor = WHITE 
						//                                sprBatt.BackColor = GREEN 
						//                        ElseIf Clean(oRec("TimeCode"]) <> "REG" Then 
						//                            sprBatt.Col = 11 
						//                            sprBatt.Text = Clean(oRec("TimeCode"]) 
						//                            If Clean(oRec("TimeCode"]) = "EDO" Or Clean(oRec("TimeCode"]) = "OTP" Then 
						//                                sprBatt.ForeColor = WHITE 
						//                                sprBatt.BackColor = RED 
						//                            ElseIf Clean(oRec("TimeCode"]) = "DDF" Or Clean(oRec("TimeCode"]) = "UDD" Then 
						//                                sprBatt.ForeColor = WHITE 
						//                                sprBatt.BackColor = BLUE 
						//                            End If 
						//                        End If 
						//                        x = x + 1 
						//                    End If 
						//                    CurrName = newName 
						//                    CurrTime = newTime 
						//                    oRec.MoveNext 
						//                Loop 
						break;
					case 14 :
						//                oCmd.CommandText = "spReport_GetUnit '" & StartDate & "','" & EndDate & "','M04'" 
						//                Set oRec = oCmd.Execute 
						//                x = 28 
						//                CurrName = "" 
						//                CurrTime = "" 
						//                CurrPayUp = False 
						//                Do Until oRec.EOF 
						//                    sprBatt.Col = 13 
						//                    sprBatt.Row = x 
						//                    newName = Trim$(oRec("name_last"]) & " " & Left$(oRec("name_first"), 1) & "." 
						//                    newTime = Clean(oRec("TimeCode"]) 
						//                    newPayUp = oRec("pay_upgrade") 
						//                    If CurrName = newName And CurrTime = newTime And CurrPayUp = newPayUp Then 
						//                        sprBatt.Col = 15 
						//                        sprBatt.Row = x - 1 
						//                        sprBatt.Text = "1" 
						//                    Else 
						//                        sprBatt.Text = newName 
						//                        sprBatt.Col = 14 
						//                        sprBatt.Text = newTime 
						//                        If newTime = "EDO" Or newTime = "OTP" Then 
						//                            sprBatt.ForeColor = WHITE 
						//                            sprBatt.BackColor = RED 
						//                        ElseIf newTime = "DDF" Or newTime = "UDD" Then 
						//                            sprBatt.ForeColor = WHITE 
						//                            sprBatt.BackColor = BLUE 
						//                        ElseIf newTime = "TRD" Then 
						//                            sprBatt.ForeColor = WHITE 
						//                            sprBatt.BackColor = GREEN 
						//                        End If 
						//                        sprBatt.Col = 15 
						//                        sprBatt.Text = ".5" 
						//                        sprBatt.Col = 16 
						//                        If oRec("pay_upgrade") Then 
						//                            sprBatt.Text = "X" 
						//                            sprBatt.ForeColor = RED 
						//                            sprBatt.Col = 17 
						//                            sprBatt.Text = oRec("job_code_id") 
						//                            sprBatt.ForeColor = RED 
						//                            sprBatt.Col = 18 
						//                            sprBatt.Text = Clean(oRec("up_step"]) 
						//                            sprBatt.ForeColor = RED 
						//                        End If 
						//                        x = x + 1 
						//                    End If 
						//                    CurrName = newName 
						//                    CurrTime = newTime 
						//                    CurrPayUp = newPayUp 
						//                    oRec.MoveNext 
						//                Loop 
						//                oCmd.CommandText = "spReport_GetUnitLv '" & StartDate & "','" & EndDate & "','M04'" 
						//                Set oRec = oCmd.Execute 
						//                Do Until oRec.EOF 
						//                    sprBatt.Col = 13 
						//                    sprBatt.Row = x 
						//                    newName = Trim$(oRec("name_last"]) & " " & Left$(oRec("name_first"), 1) & "." 
						//                    newTime = Clean(oRec("LeaveCode"]) 
						//                    If Clean(oRec("vacation_bank_flag"]) = 1 Then 
						//                        ChangeFont = True 
						//                    End If 
						//                    If CurrName = newName And CurrTime = newTime Then 
						//                        sprBatt.Col = 15 
						//                        sprBatt.Row = x - 1 
						//                        sprBatt.Text = "1" 
						//                        If ChangeFont Then 
						//                            sprBatt.Col = 14 
						//                            sprBatt.FontBold = True 
						//                            sprBatt.ForeColor = YELLOW 
						//                            ChangeFont = False 
						//                        End If 
						//                    Else 
						//                        sprBatt.Text = newName 
						//                        sprBatt.Col = 14 
						//                        sprBatt.Text = newTime 
						//                        sprBatt.ForeColor = WHITE 
						//                        sprBatt.BackColor = WINE 
						//                        If ChangeFont Then 
						//                            sprBatt.FontBold = True 
						//                            sprBatt.ForeColor = YELLOW 
						//                            ChangeFont = False 
						//                        End If 
						//                         sprBatt.Col = 15 
						//                        sprBatt.Text = ".5" 
						//                        If Clean(oRec("LeaveCode"]) = "TRD" Then 
						//                                sprBatt.Col = 14 
						//                                sprBatt.Text = Clean(oRec("TimeCode"]) 
						//                                If Clean(oRec("TimeCode"]) = "OTP" Or Clean(oRec("TimeCode"]) = "EDO" Then 
						//                                    sprBatt.ForeColor = WHITE 
						//                                    sprBatt.BackColor = RED 
						//                                ElseIf Clean(oRec("TimeCode"]) = "DDF" Or Clean(oRec("TimeCode"]) = "UDD" Then 
						//                                    sprBatt.ForeColor = WHITE 
						//                                    sprBatt.BackColor = BLUE 
						//                                Else 
						//                                    sprBatt.ForeColor = BLACK 
						//                                    sprBatt.BackColor = WHITE 
						//                                End If 
						//                                sprBatt.Col = 17 
						//                                sprBatt.Text = Clean(oRec("LeaveCode"]) 
						//                                sprBatt.ForeColor = WHITE 
						//                                sprBatt.BackColor = GREEN 
						//                        ElseIf Clean(oRec("TimeCode"]) <> "REG" Then 
						//                            sprBatt.Col = 17 
						//                            sprBatt.Text = Clean(oRec("TimeCode"]) 
						//                            If Clean(oRec("TimeCode"]) = "EDO" Or Clean(oRec("TimeCode"]) = "OTP" Then 
						//                                sprBatt.ForeColor = WHITE 
						//                                sprBatt.BackColor = RED 
						//                            ElseIf Clean(oRec("TimeCode"]) = "DDF" Or Clean(oRec("TimeCode"]) = "UDD" Then 
						//                                sprBatt.ForeColor = WHITE 
						//                                sprBatt.BackColor = BLUE 
						//                            End If 
						//                        End If 
						//                        x = x + 1 
						//                    End If 
						//                    CurrName = newName 
						//                    CurrTime = newTime 
						//                    oRec.MoveNext 
						//                Loop 
						break;
					case 15 :
						oCmd.CommandText = "spReport_GetUnit '" + StartDate + "','" + EndDate + "','FCC'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						x = 28;
						CurrName = "";
						CurrTime = "";
						CurrPayUp = 0;

						while(!oRec.EOF)
						{
							ViewModel.sprBatt.Col = 19;
							ViewModel.sprBatt.Row = x;
							newName = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
							newTime = modGlobal.Clean(oRec["TimeCode"]);
							newPayUp = Convert.ToInt32(oRec["pay_upgrade"]);
							if (CurrName == newName && CurrTime == newTime && CurrPayUp == newPayUp)
							{
								ViewModel.sprBatt.Col = 21;
								ViewModel.sprBatt.Row = x - 1;
								ViewModel.sprBatt.Text = "1";
							}
							else
							{
								ViewModel.sprBatt.Text = newName;
								ViewModel.sprBatt.Col = 20;
								ViewModel.sprBatt.Text = newTime;
								if (newTime == "EDO" || newTime == "OTP")
								{
									ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
								}
								else if (newTime == "DDF" || newTime == "UDD")
								{
									ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
								}
								else if (newTime == "TRD")
								{
									ViewModel.sprBatt.BackColor = modGlobal.Shared.GREEN;
								}
								ViewModel.sprBatt.Col = 21;
								ViewModel.sprBatt.Text = ".5";
								ViewModel.sprBatt.Col = 22;
								if (Convert.ToBoolean(oRec["pay_upgrade"]))
								{
									ViewModel.sprBatt.Text = "X";
									ViewModel.sprBatt.Col = 23;
									ViewModel.sprBatt.Text = Convert.ToString(oRec["job_code_id"]);
									ViewModel.sprBatt.Col = 24;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["up_step"]);
								}
								x++;
							}
							CurrName = newName;
							CurrTime = newTime;
							CurrPayUp = newPayUp;
							oRec.MoveNext();
						};
						oCmd.CommandText = "spReport_GetUnitLv '" + StartDate + "','" + EndDate + "','FCC'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						while(!oRec.EOF)
						{
							ViewModel.sprBatt.Col = 19;
							ViewModel.sprBatt.Row = x;
							newName = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
							newTime = modGlobal.Clean(oRec["LeaveCode"]);
							if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1)
							{
								ChangeFont = true;
							}
							if (CurrName == newName && CurrTime == newTime)
							{
								ViewModel.sprBatt.Col = 21;
								ViewModel.sprBatt.Row = x - 1;
								ViewModel.sprBatt.Text = "1";
								if (ChangeFont)
								{
									ViewModel.sprBatt.Col = 20;
									ViewModel.sprBatt.FontBold = true;
									ChangeFont = false;
								}
							}
							else
							{
								ViewModel.sprBatt.Text = newName;
								ViewModel.sprBatt.Col = 20;
								ViewModel.sprBatt.Text = newTime;
								ViewModel.sprBatt.BackColor = modGlobal.Shared.WINE;
								if (ChangeFont)
								{
									ViewModel.sprBatt.FontBold = true;
									ChangeFont = false;
								}
								ViewModel.sprBatt.Col = 21;
								ViewModel.sprBatt.Text = ".5";
								if (modGlobal.Clean(oRec["LeaveCode"]) == "TRD")
								{
									ViewModel.sprBatt.Col = 20;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["TimeCode"]);
									if (modGlobal.Clean(oRec["TimeCode"]) == "OTP" || modGlobal.Clean(oRec["TimeCode"]) == "EDO")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
									}
									else if (modGlobal.Clean(oRec["TimeCode"]) == "DDF" || modGlobal.Clean(oRec["TimeCode"]) == "UDD")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
									}
									else
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.WHITE;
									}
									ViewModel.sprBatt.Col = 23;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["LeaveCode"]);
									ViewModel.sprBatt.BackColor = modGlobal.Shared.GREEN;
								}
								else if (modGlobal.Clean(oRec["TimeCode"]) != "REG")
								{
									ViewModel.sprBatt.Col = 23;
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["TimeCode"]);
									if (modGlobal.Clean(oRec["TimeCode"]) == "OTP" || modGlobal.Clean(oRec["TimeCode"]) == "EDO")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
									}
									else if (modGlobal.Clean(oRec["TimeCode"]) == "DDF" || modGlobal.Clean(oRec["TimeCode"]) == "UDD")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
									}
								}
								x++;
							}
							CurrName = newName;
							CurrTime = newTime;
							oRec.MoveNext();
						};
						break;
					case 16 :
						//Rovers List 
						oCmd.CommandText = "spReport_GetRovers '3','" + ShiftCode + "'";
						orec2 = ADORecordSetHelper.Open(oCmd, "");
						x = 39;

						while(!orec2.EOF)
						{
							oCmd.CommandText = "spReport_FindRover '" + StartDate + "','" + EndDate + "','" + Convert.ToString(orec2["employee_id"]) + "'";
							oRec = ADORecordSetHelper.Open(oCmd, "");

							while(!oRec.EOF)
							{
								ViewModel.sprBatt.Col = 1;
								ViewModel.sprBatt.Row = x;
								if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1)
								{
									ChangeFont = true;
								}
								CurrName = Convert.ToString(orec2["name_last"]).Trim() + " " + Convert.ToString(orec2["name_first"]).Substring(0, Math.Min(1, Convert.ToString(orec2["name_first"]).Length)) + ".";
								ViewModel.sprBatt.Text = CurrName;
								ViewModel.sprBatt.Col = 2;
								if (ChangeFont)
								{
									ViewModel.sprBatt.FontBold = true;
									ChangeFont = false;
								}
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
								if (Convert.IsDBNull(oRec["LeaveCode"]))
								{
									ViewModel.sprBatt.Text = modGlobal.Clean(oRec["TimeCode"]);
									if (modGlobal.Clean(oRec["TimeCode"]) == "OTP" || modGlobal.Clean(oRec["TimeCode"]) == "EDO")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
									}
									else if (modGlobal.Clean(oRec["TimeCode"]) == "DDF" || modGlobal.Clean(oRec["TimeCode"]) == "UDD")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
									}
									ViewModel.sprBatt.Col = 5;
									ViewModel.sprBatt.Text = Convert.ToString(oRec["unit_code"]);
								}
								else
								{
									if (modGlobal.Clean(oRec["LeaveCode"]) == "TRD")
									{
										ViewModel.sprBatt.Text = modGlobal.Clean(oRec["TimeCode"]);
										if (modGlobal.Clean(oRec["TimeCode"]) == "EDO" || modGlobal.Clean(oRec["TimeCode"]) == "OTP")
										{
											ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
										}
										else if (modGlobal.Clean(oRec["TimeCode"]) == "DDF" || modGlobal.Clean(oRec["TimeCode"]) == "UDD")
										{
											ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
										}
										ViewModel.sprBatt.Col = 5;
										ViewModel.sprBatt.Text = modGlobal.Clean(oRec["LeaveCode"]);
										ViewModel.sprBatt.BackColor = modGlobal.Shared.GREEN;
									}
									else
									{
										ViewModel.sprBatt.Text = modGlobal.Clean(oRec["LeaveCode"]);
										ViewModel.sprBatt.BackColor = modGlobal.Shared.WINE;
										ViewModel.sprBatt.Col = 5;
										ViewModel.sprBatt.Text = modGlobal.Clean(oRec["TimeCode"]);
										if (modGlobal.Clean(oRec["TimeCode"]) == "OTP" || modGlobal.Clean(oRec["TimeCode"]) == "EDO")
										{
											ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
										}
										else if (modGlobal.Clean(oRec["TimeCode"]) == "DDF" || modGlobal.Clean(oRec["TimeCode"]) == "UDD")
										{
											ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
										}
									}
								}
								x++;
								oRec.MoveNext();
							};
							orec2.MoveNext();
						};
						break;
					case 17 :
						//Debit List 
						oCmd.CommandText = "spReport_GetDebits '" + StartDate + "','" + EndDate + "','3'";
						orec2 = ADORecordSetHelper.Open(oCmd, "");
						x = 39;

						while(!orec2.EOF)
						{
							ViewModel.sprBatt.Col = 7;
							ViewModel.sprBatt.Row = x;
							if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(orec2["vacation_bank_flag"])) == 1)
							{
								ChangeFont = true;
							}
							CurrName = Convert.ToString(orec2["name_last"]).Trim() + " " + Convert.ToString(orec2["name_first"]).Substring(0, Math.Min(1, Convert.ToString(orec2["name_first"]).Length)) + ".";
							ViewModel.sprBatt.Text = CurrName;
							ViewModel.sprBatt.Col = 8;
							if (ChangeFont)
							{
								ViewModel.sprBatt.FontBold = true;
								ChangeFont = false;
							}
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
							if (Convert.IsDBNull(orec2["LeaveCode"]))
							{
								ViewModel.sprBatt.Text = modGlobal.Clean(orec2["TimeCode"]);
								if (modGlobal.Clean(orec2["TimeCode"]) == "EDO" || modGlobal.Clean(orec2["TimeCode"]) == "OTP")
								{
									ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
								}
								else if (modGlobal.Clean(orec2["TimeCode"]) == "DDF" || modGlobal.Clean(orec2["TimeCode"]) == "UDD")
								{
									ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
								}
								ViewModel.sprBatt.Col = 11;
								ViewModel.sprBatt.Text = Convert.ToString(orec2["unit_code"]);
							}
							else
							{
								if (modGlobal.Clean(orec2["LeaveCode"]) == "TRD")
								{
									ViewModel.sprBatt.Text = modGlobal.Clean(orec2["TimeCode"]);
									if (modGlobal.Clean(orec2["TimeCode"]) == "OTP" || modGlobal.Clean(orec2["TimeCode"]) == "EDO")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
									}
									else if (modGlobal.Clean(orec2["TimeCode"]) == "DDF" || modGlobal.Clean(orec2["TimeCode"]) == "UDD")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
									}
									ViewModel.sprBatt.Col = 11;
									ViewModel.sprBatt.Text = modGlobal.Clean(orec2["LeaveCode"]);
									ViewModel.sprBatt.BackColor = modGlobal.Shared.GREEN;
								}
								else
								{
									ViewModel.sprBatt.Text = modGlobal.Clean(orec2["LeaveCode"]);
									ViewModel.sprBatt.BackColor = modGlobal.Shared.WINE;
									ViewModel.sprBatt.Col = 11;
									ViewModel.sprBatt.Text = modGlobal.Clean(orec2["TimeCode"]).Trim();
									if (modGlobal.Clean(orec2["TimeCode"]) == "OTP" || modGlobal.Clean(orec2["TimeCode"]) == "EDO")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.RED;
									}
									else if (modGlobal.Clean(orec2["TimeCode"]) == "DDF" || modGlobal.Clean(orec2["TimeCode"]) == "UDD")
									{
										ViewModel.sprBatt.BackColor = modGlobal.Shared.BLUE;
									}
								}
							}
							x++;
							orec2.MoveNext();
						};
						break;
					case 18 :
						//Special Assignment 
						oCmd.CommandText = "spReport_GetSAs '" + StartDate + "','" + EndDate + "'";
						orec2 = ADORecordSetHelper.Open(oCmd, "");
						x = 39;

						while(!orec2.EOF)
						{
							oCmd.CommandText = "spReport_Employee '" + Convert.ToString(orec2["employee_id"]) + "'";
							oRec = ADORecordSetHelper.Open(oCmd, "");

							while(!oRec.EOF)
							{
								if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(orec2["vacation_bank_flag"])) == 1)
								{
									ChangeFont = true;
								}
								if (modGlobal.Clean(oRec["battalion_code"]).Trim() == "1")
								{
									ViewModel.sprBatt.Col = 13;
									ViewModel.sprBatt.Row = x;
									CurrName = Convert.ToString(orec2["name_last"]).Trim() + " " + Convert.ToString(orec2["name_first"]).Substring(0, Math.Min(1, Convert.ToString(orec2["name_first"]).Length)) + ".";
									ViewModel.sprBatt.Text = CurrName;
									ViewModel.sprBatt.Col = 14;
									ViewModel.sprBatt.Text = modGlobal.Clean(orec2["TimeCode"]);
									if (ChangeFont)
									{
										ViewModel.sprBatt.FontBold = true;
										ChangeFont = false;
									}
									x++;
								}
								oRec.MoveNext();
							};
							orec2.MoveNext();
						};
						break;
					case 19 :
						//Retrieve Notes 
						oCmd.CommandText = "spReport_GetBattNote '" + StartDate + "','" + EndDate + "','3'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						x = 28;
						ViewModel.sprBatt.Col = 25;

						while(!oRec.EOF)
						{
							Note1 = Convert.ToString(oRec["note"]).Trim();
							for (int L = 1; L <= Strings.Len(Note1); L++)
							{
								NoteChar = Note1.Substring(L - 1, Math.Min(1, Note1.Length - (L - 1)));
								if (Strings.Asc(NoteChar[0]) == 13)
								{
									NoteChar = " ";
									Note2 = Note2 + NoteChar;
									ViewModel.sprBatt.Row = x;
									ViewModel.sprBatt.Text = Note2;
									Note2 = "";
									x++;
									L++;
								}
								else if (Strings.Len(Note2) > 27 && NoteChar == " ")
								{
									ViewModel.sprBatt.Row = x;
									ViewModel.sprBatt.Text = Note2;
									Note2 = "";
									x++;
								}
								else if (Strings.Len(Note2) > 34)
								{
									Note2 = Note2 + NoteChar;
									ViewModel.sprBatt.Row = x;
									ViewModel.sprBatt.Text = Note2;
									Note2 = "";
									x++;
								}
								else
								{
									Note2 = Note2 + NoteChar;
								}
								if (x > 41)
								{
									if (Strings.Len(Note1.Substring(Math.Max(Note1.Length - (Strings.Len(Note1) - L), 0))) > 1)
									{
										ViewModel.sprBatt.Col = 29;
										ViewModel.sprBatt.Text = "More...";
										break;
									}
								}
							}
							if (x > 41)
							{
								break;
							}
							ViewModel.sprBatt.Row = x;
							ViewModel.sprBatt.Text = Note2;
							oRec.MoveNext();
						};
						break;
					case 20 :
						//Sign off Info 
						//                oCmd.CommandText = "sp_GetSignOff '" & StartDate & " 7:00AM" & "','1'" 
						//                Set oRec = oCmd.Execute 
						//                If Not oRec.EOF Then 
						//                    If oRec("shift_status") Then 
						//                        sprBatt.Row = 39 
						//                        sprBatt.Col = 25 
						//                        sprBatt.Text = "Locked" 
						//                        sprBatt.Row = 40 
						//                        sprBatt.Col = 19 
						//                        sprBatt.Text = "Locked By:" 
						//                        sprBatt.Col = 20 
						//                        sprBatt.Text = oRec("name_full") 
						//                        sprBatt.Col = 25 
						//                        sprBatt.Text = "On:" 
						//                        sprBatt.Col = 26 
						//                        sprBatt.Text = oRec("last_update_date") 
						//                    Else 
						//                        sprBatt.Row = 39 
						//                        sprBatt.Col = 25 
						//                        sprBatt.Text = "Unlocked" 
						//                    End If 
						//                Else 
						//                    sprBatt.Row = 39 
						//                    sprBatt.Col = 25 
						//                    sprBatt.Text = "No Data" 
						//                End If 
						break;
				}
			}

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
		internal void cmdExcept_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmException3.DefInstance);
			/*			frmException3.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdLeave_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmLeave.DefInstance);
			/*			frmLeave.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Timestamp report and print
			ViewModel.sprBatt.Col = 22;
			ViewModel.sprBatt.Row = 49;
			ViewModel.sprBatt.Text = DateTime.Now.ToString("M/d/yy HH:mm");

			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprBatt.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprBatt.setPrintAbortMsg("Printing Batt 3 Time Card Worksheet - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprBatt.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprBatt.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprBatt.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprBatt.setPrintColor(true);
            //    sprBatt.PrintOrientation = 2
            ViewModel.sprBatt.PrintSheet(null);
			//ViewModel.sprBatt.Action = (FarPoint.ViewModels.FPActionConstants) 32;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrintAll_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Print TimeCard Spread
			//open Exception and Leave forms hidden
			//and print
			ViewManager.HideView(
				//Print TimeCard Spread
				//open Exception and Leave forms hidden
				//and print

				frmException3.DefInstance);
			ViewManager.HideView(
				frmLeave.DefInstance);

			//Timestamp report and print
			ViewModel.sprBatt.Col = 22;
			ViewModel.sprBatt.Row = 49;
			ViewModel.sprBatt.Text = DateTime.Now.ToString("M/d/yy HH:mm:ss");

			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprBatt.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprBatt.setPrintAbortMsg("Printing Batt 3 Time Card Worksheet - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprBatt.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprBatt.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprBatt.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprBatt.setPrintColor(true);
            //    sprBatt.PrintOrientation = 2
            ViewModel.sprBatt.PrintSheet(null);
			//ViewModel.sprBatt.Action = (FarPoint.ViewModels.FPActionConstants) 32;

			//Print Exception Report
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprExcept.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			frmException3.DefInstance.ViewModel.sprExcept.setPrintAbortMsg("Printing Exception Report - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprExcept.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			frmException3.DefInstance.ViewModel.sprExcept.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprExcept.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			frmException3.DefInstance.ViewModel.sprExcept.setPrintColor(true);
            //    frmException3.sprExcept.PrintOrientation = 1
            frmException3.DefInstance.ViewModel.sprExcept.PrintSheet(null);
            //frmException3.DefInstance.ViewModel.sprExcept.Action = (FarPoint.ViewModels.FPActionConstants) 32;

			//Print Leave Report
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprLeave.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			frmLeave.DefInstance.ViewModel.sprLeave.setPrintAbortMsg("Printing Leave Report - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprLeave.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			frmLeave.DefInstance.ViewModel.sprLeave.setPrintBorder(false);
            //    frmLeave.sprLeave.PrintOrientation = 1
            frmLeave.DefInstance.ViewModel.sprLeave.PrintSheet(null);
            //frmLeave.DefInstance.ViewModel.sprLeave.Action = (FarPoint.ViewModels.FPActionConstants) 13;

            //close hidden forms
            ViewManager.DisposeView(

				//close hidden forms
				frmException3.DefInstance);
			ViewManager.DisposeView(
				frmLeave.DefInstance);

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			//Retrieve Batt 1 Time Card data  for today

			//    calDate.Date = gBattSwitchDate
			for (int i = 0; i <= ViewManager.OpenFormsCount - 1; i++)
			{
				if ( ViewManager.GetOpenFormAt(i).ViewModel.Name == "frmNewBattSched3")
				{
					ViewModel.calDate.Value = frmNewBattSched3.DefInstance.ViewModel.calSchedDate.Value.Date;
					return;
				}
			}
			ViewModel.FirstTime = -1;
			FillSpread();

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmTimeCard3 DefInstance
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

		public static frmTimeCard3 CreateInstance()
		{
			PTSProject.frmTimeCard3 theInstance = Shared.Container.Resolve< frmTimeCard3>();
			theInstance.Form_Load();
			return theInstance;
		}

		protected override void ExecuteControlsStartup()
		{
			ViewModel.sprBatt.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprBatt.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmTimeCard3
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmTimeCard3ViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmTimeCard3 m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}