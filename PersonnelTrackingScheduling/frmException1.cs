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

	public partial class frmException1
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmException1ViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmException1));
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


		private void frmException1_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//**************************************
		//* Batt 1 Time Card Exception Report  *
		//**************************************
		//ADODB

		public void ClearSpread()
		{
			//Clear Spread Control
			ViewModel.sprExcept.BlockMode = false;
			ViewModel.sprExcept.Col = 5;
			ViewModel.sprExcept.Row = 2;
			ViewModel.sprExcept.Text = "";
			ViewModel.sprExcept.BlockMode = true;
			ViewModel.sprExcept.Col = 1;
			ViewModel.sprExcept.Row = 5;
			ViewModel.sprExcept.Col2 = 7;
			ViewModel.sprExcept.Row2 = 80;
			ViewModel.sprExcept.FontUnderline = false;
			//ViewModel.sprExcept.Action = (FarPoint.ViewModels.FPActionConstants) 12;
			ViewModel.sprExcept.BlockMode = false;

		}

		public void FillSpread()
		{
			//Fill Spread with new days Exceptions
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string CurrEmp = "";
			string CurrKOT = "";
			string CurrLeave = "";
			int CurrPayUp = 0;
			string CurrJobCode = "";
			string strAMPM = "";
			string Note2 = "", Note1 = "", NoteChar = "";

			if ( ViewModel.FirstTime != 0)
			{
				ViewModel.FirstTime = 0;
			}
			else
			{
				ClearSpread();
			}

			string StartDate = DateTime.Parse(ViewModel.calDate.Text).ToString("M/d/yyyy");
			string EndDate = DateTime.Parse(StartDate).AddDays(1).ToString("M/d/yyyy");
			ViewModel.sprExcept.Col = 5;
			ViewModel.sprExcept.Row = 2;
			ViewModel.sprExcept.Text = StartDate;
			int CurrRow = 5;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spReport_BattExcept '" + StartDate + "','" + EndDate + "','1'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				if (CurrEmp != Convert.ToString(oRec["name_full"]))
				{
					ViewModel.sprExcept.Row = CurrRow;
					ViewModel.sprExcept.Col = 1;
					ViewModel.sprExcept.Text = Convert.ToString(oRec["name_full"]);
					ViewModel.sprExcept.Col = 2;
					ViewModel.sprExcept.Text = modGlobal.Clean(oRec["work_time"]);
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
					if (!Convert.IsDBNull(oRec["leave_time"]) && modGlobal.Clean(oRec["leave_time"]) != "TRD")
					{
						ViewModel.sprExcept.Col = 3;
						ViewModel.sprExcept.Text = modGlobal.Clean(oRec["leave_time"]);
						if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1)
						{
							ViewModel.sprExcept.FontUnderline = true;
						}
					}
					if (Convert.ToBoolean(oRec["pay_upgrade"]))
					{
						ViewModel.sprExcept.Col = 4;
						ViewModel.sprExcept.Text = "X";
						ViewModel.sprExcept.Col = 5;
						ViewModel.sprExcept.Text = Convert.ToString(oRec["job_code_id"]);
						ViewModel.sprExcept.Col = 6;
						ViewModel.sprExcept.Text = modGlobal.Clean(oRec["step"]);
					}
					ViewModel.sprExcept.Col = 7;
					ViewModel.sprExcept.Text = Convert.ToString(oRec["AMPM"]);
					CurrEmp = Convert.ToString(oRec["name_full"]);
					CurrKOT = modGlobal.Clean(oRec["work_time"]);
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
					if (!Convert.IsDBNull(oRec["leave_time"]))
					{
						CurrLeave = modGlobal.Clean(oRec["leave_time"]);
					}
					else
					{
						CurrLeave = "";
					}
					CurrPayUp = Convert.ToInt32(oRec["pay_upgrade"]);
					if (CurrPayUp != 0)
					{
						CurrJobCode = Convert.ToString(oRec["job_code_id"]);
					}
					else
					{
						CurrJobCode = "";
					}
					CurrRow++;
				}
				else if (CurrKOT == modGlobal.Clean(oRec["work_time"]))
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
					if (Convert.IsDBNull(oRec["leave_time"]))
					{
						if (CurrLeave == "")
						{
							if (Convert.ToDouble(oRec["pay_upgrade"]) == CurrPayUp)
							{
								if (Convert.ToBoolean(oRec["pay_upgrade"]))
								{
									if (CurrJobCode == Convert.ToString(oRec["job_code_id"]))
									{
										ViewModel.sprExcept.Col = 7;
										strAMPM = ViewModel.sprExcept.Text + "/" + Convert.ToString(oRec["AMPM"]);
										ViewModel.sprExcept.Text = strAMPM;
									}
									else
									{
										ViewModel.sprExcept.Row = CurrRow;
										ViewModel.sprExcept.Col = 1;
										ViewModel.sprExcept.Text = Convert.ToString(oRec["name_full"]);
										ViewModel.sprExcept.Col = 2;
										ViewModel.sprExcept.Text = modGlobal.Clean(oRec["work_time"]);
										//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
										if (!Convert.IsDBNull(oRec["leave_time"]) && modGlobal.Clean(oRec["leave_time"]) != "TRD")
										{
											ViewModel.sprExcept.Col = 3;
											ViewModel.sprExcept.Text = modGlobal.Clean(oRec["leave_time"]);
											if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1)
											{
												ViewModel.sprExcept.FontUnderline = true;
											}
										}
										if (Convert.ToBoolean(oRec["pay_upgrade"]))
										{
											ViewModel.sprExcept.Col = 4;
											ViewModel.sprExcept.Text = "X";
											ViewModel.sprExcept.Col = 5;
											ViewModel.sprExcept.Text = Convert.ToString(oRec["job_code_id"]);
											ViewModel.sprExcept.Col = 6;
											ViewModel.sprExcept.Text = modGlobal.Clean(oRec["step"]);
										}
										ViewModel.sprExcept.Col = 7;
										ViewModel.sprExcept.Text = Convert.ToString(oRec["AMPM"]);
										CurrEmp = Convert.ToString(oRec["name_full"]);
										CurrKOT = modGlobal.Clean(oRec["work_time"]);
										//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
										if (!Convert.IsDBNull(oRec["leave_time"]))
										{
											CurrLeave = modGlobal.Clean(oRec["leave_time"]);
										}
										else
										{
											CurrLeave = "";
										}
										CurrPayUp = Convert.ToInt32(oRec["pay_upgrade"]);
										if (CurrPayUp != 0)
										{
											CurrJobCode = Convert.ToString(oRec["job_code_id"]);
										}
										else
										{
											CurrJobCode = "";
										}
										CurrRow++;
									}
								}
								else
								{
									ViewModel.sprExcept.Col = 7;
									strAMPM = ViewModel.sprExcept.Text + "/" + Convert.ToString(oRec["AMPM"]);
									ViewModel.sprExcept.Text = strAMPM;
								}
							}
							else
							{
								ViewModel.sprExcept.Row = CurrRow;
								ViewModel.sprExcept.Col = 1;
								ViewModel.sprExcept.Text = Convert.ToString(oRec["name_full"]);
								ViewModel.sprExcept.Col = 2;
								ViewModel.sprExcept.Text = modGlobal.Clean(oRec["work_time"]);
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
								if (!Convert.IsDBNull(oRec["leave_time"]) && modGlobal.Clean(oRec["leave_time"]) != "TRD")
								{
									ViewModel.sprExcept.Col = 3;
									ViewModel.sprExcept.Text = modGlobal.Clean(oRec["leave_time"]);
									if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1)
									{
										ViewModel.sprExcept.FontUnderline = true;
									}
								}
								if (Convert.ToBoolean(oRec["pay_upgrade"]))
								{
									ViewModel.sprExcept.Col = 4;
									ViewModel.sprExcept.Text = "X";
									ViewModel.sprExcept.Col = 5;
									ViewModel.sprExcept.Text = Convert.ToString(oRec["job_code_id"]);
									ViewModel.sprExcept.Col = 6;
									ViewModel.sprExcept.Text = modGlobal.Clean(oRec["step"]);
								}
								ViewModel.sprExcept.Col = 7;
								ViewModel.sprExcept.Text = Convert.ToString(oRec["AMPM"]);
								CurrEmp = Convert.ToString(oRec["name_full"]);
								CurrKOT = modGlobal.Clean(oRec["work_time"]);
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
								if (!Convert.IsDBNull(oRec["leave_time"]))
								{
									CurrLeave = modGlobal.Clean(oRec["leave_time"]);
								}
								else
								{
									CurrLeave = "";
								}
								CurrPayUp = Convert.ToInt32(oRec["pay_upgrade"]);
								if (CurrPayUp != 0)
								{
									CurrJobCode = Convert.ToString(oRec["job_code_id"]);
								}
								else
								{
									CurrJobCode = "";
								}
								CurrRow++;
							}
						}
						else
						{
							ViewModel.sprExcept.Row = CurrRow;
							ViewModel.sprExcept.Col = 1;
							ViewModel.sprExcept.Text = Convert.ToString(oRec["name_full"]);
							ViewModel.sprExcept.Col = 2;
							ViewModel.sprExcept.Text = modGlobal.Clean(oRec["work_time"]);
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
							if (!Convert.IsDBNull(oRec["leave_time"]) && modGlobal.Clean(oRec["leave_time"]) != "TRD")
							{
								ViewModel.sprExcept.Col = 3;
								ViewModel.sprExcept.Text = modGlobal.Clean(oRec["leave_time"]);
								if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1)
								{
									ViewModel.sprExcept.FontUnderline = true;
								}
							}
							if (Convert.ToBoolean(oRec["pay_upgrade"]))
							{
								ViewModel.sprExcept.Col = 4;
								ViewModel.sprExcept.Text = "X";
								ViewModel.sprExcept.Col = 5;
								ViewModel.sprExcept.Text = Convert.ToString(oRec["job_code_id"]);
								ViewModel.sprExcept.Col = 6;
								ViewModel.sprExcept.Text = modGlobal.Clean(oRec["step"]);
							}
							ViewModel.sprExcept.Col = 7;
							ViewModel.sprExcept.Text = Convert.ToString(oRec["AMPM"]);
							CurrEmp = Convert.ToString(oRec["name_full"]);
							CurrKOT = modGlobal.Clean(oRec["work_time"]);
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
							if (!Convert.IsDBNull(oRec["leave_time"]))
							{
								CurrLeave = modGlobal.Clean(oRec["leave_time"]);
							}
							else
							{
								CurrLeave = "";
							}
							CurrPayUp = Convert.ToInt32(oRec["pay_upgrade"]);
							if (CurrPayUp != 0)
							{
								CurrJobCode = Convert.ToString(oRec["job_code_id"]);
							}
							else
							{
								CurrJobCode = "";
							}
							CurrRow++;
						}
					}
					else if (modGlobal.Clean(oRec["leave_time"]) == CurrLeave)
					{
						ViewModel.sprExcept.Col = 7;
						strAMPM = ViewModel.sprExcept.Text + "/" + Convert.ToString(oRec["AMPM"]);
						ViewModel.sprExcept.Text = strAMPM;
					}
					else
					{
						ViewModel.sprExcept.Row = CurrRow;
						ViewModel.sprExcept.Col = 1;
						ViewModel.sprExcept.Text = Convert.ToString(oRec["name_full"]);
						ViewModel.sprExcept.Col = 2;
						ViewModel.sprExcept.Text = modGlobal.Clean(oRec["work_time"]);
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
						if (!Convert.IsDBNull(oRec["leave_time"]) && modGlobal.Clean(oRec["leave_time"]) != "TRD")
						{
							ViewModel.sprExcept.Col = 3;
							ViewModel.sprExcept.Text = modGlobal.Clean(oRec["leave_time"]);
							if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1)
							{
								ViewModel.sprExcept.FontUnderline = true;
							}
						}
						if (Convert.ToBoolean(oRec["pay_upgrade"]))
						{
							ViewModel.sprExcept.Col = 4;
							ViewModel.sprExcept.Text = "X";
							ViewModel.sprExcept.Col = 5;
							ViewModel.sprExcept.Text = Convert.ToString(oRec["job_code_id"]);
							ViewModel.sprExcept.Col = 6;
							ViewModel.sprExcept.Text = modGlobal.Clean(oRec["step"]);
						}
						ViewModel.sprExcept.Col = 7;
						ViewModel.sprExcept.Text = Convert.ToString(oRec["AMPM"]);
						CurrEmp = Convert.ToString(oRec["name_full"]);
						CurrKOT = modGlobal.Clean(oRec["work_time"]);
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
						if (!Convert.IsDBNull(oRec["leave_time"]))
						{
							CurrLeave = modGlobal.Clean(oRec["leave_time"]);
						}
						else
						{
							CurrLeave = "";
						}
						CurrPayUp = Convert.ToInt32(oRec["pay_upgrade"]);
						if (CurrPayUp != 0)
						{
							CurrJobCode = Convert.ToString(oRec["job_code_id"]);
						}
						else
						{
							CurrJobCode = "";
						}
						CurrRow++;
					}
				}
				else
				{
					ViewModel.sprExcept.Row = CurrRow;
					ViewModel.sprExcept.Col = 1;
					ViewModel.sprExcept.Text = Convert.ToString(oRec["name_full"]);
					ViewModel.sprExcept.Col = 2;
					ViewModel.sprExcept.Text = modGlobal.Clean(oRec["work_time"]);
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
					if (!Convert.IsDBNull(oRec["leave_time"]) && modGlobal.Clean(oRec["leave_time"]) != "TRD")
					{
						ViewModel.sprExcept.Col = 3;
						ViewModel.sprExcept.Text = modGlobal.Clean(oRec["leave_time"]);
						if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1)
						{
							ViewModel.sprExcept.FontUnderline = true;
						}
					}
					if (Convert.ToBoolean(oRec["pay_upgrade"]))
					{
						ViewModel.sprExcept.Col = 4;
						ViewModel.sprExcept.Text = "X";
						ViewModel.sprExcept.Col = 5;
						ViewModel.sprExcept.Text = Convert.ToString(oRec["job_code_id"]);
						ViewModel.sprExcept.Col = 6;
						ViewModel.sprExcept.Text = modGlobal.Clean(oRec["step"]);
					}
					ViewModel.sprExcept.Col = 7;
					ViewModel.sprExcept.Text = Convert.ToString(oRec["AMPM"]);
					CurrEmp = Convert.ToString(oRec["name_full"]);
					CurrKOT = modGlobal.Clean(oRec["work_time"]);
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
					if (!Convert.IsDBNull(oRec["leave_time"]))
					{
						CurrLeave = modGlobal.Clean(oRec["leave_time"]);
					}
					else
					{
						CurrLeave = "";
					}
					CurrPayUp = Convert.ToInt32(oRec["pay_upgrade"]);
					if (CurrPayUp != 0)
					{
						CurrJobCode = Convert.ToString(oRec["job_code_id"]);
					}
					else
					{
						CurrJobCode = "";
					}
					CurrRow++;
				}
				oRec.MoveNext();
			};

			//FCC Payroll Exceptions
			CurrRow++;
			ViewModel.sprExcept.Row = CurrRow;
			ViewModel.sprExcept.Col = 1;
			ViewModel.sprExcept.Text = "FCC Payroll Exceptions";
			CurrRow++;
			ViewModel.sprExcept.Row = CurrRow;
			oCmd.CommandText = "spReport_FCCExcept '" + StartDate + "','" + EndDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				if (CurrEmp != Convert.ToString(oRec["name_full"]))
				{
					ViewModel.sprExcept.Row = CurrRow;
					ViewModel.sprExcept.Col = 1;
					ViewModel.sprExcept.Text = Convert.ToString(oRec["name_full"]);
					ViewModel.sprExcept.Col = 2;
					ViewModel.sprExcept.Text = modGlobal.Clean(oRec["work_time"]);
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
					if (!Convert.IsDBNull(oRec["leave_time"]) && modGlobal.Clean(oRec["leave_time"]) != "TRD")
					{
						ViewModel.sprExcept.Col = 3;
						ViewModel.sprExcept.Text = modGlobal.Clean(oRec["leave_time"]);
						if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1)
						{
							ViewModel.sprExcept.FontUnderline = true;
						}
					}
					if (Convert.ToBoolean(oRec["pay_upgrade"]))
					{
						ViewModel.sprExcept.Col = 4;
						ViewModel.sprExcept.Text = "X";
						ViewModel.sprExcept.Col = 5;
						ViewModel.sprExcept.Text = Convert.ToString(oRec["job_code_id"]);
						ViewModel.sprExcept.Col = 6;
						ViewModel.sprExcept.Text = modGlobal.Clean(oRec["step"]);
					}
					ViewModel.sprExcept.Col = 7;
					ViewModel.sprExcept.Text = Convert.ToString(oRec["AMPM"]);
					CurrEmp = Convert.ToString(oRec["name_full"]);
					CurrKOT = modGlobal.Clean(oRec["work_time"]);
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
					if (!Convert.IsDBNull(oRec["leave_time"]))
					{
						CurrLeave = modGlobal.Clean(oRec["leave_time"]);
					}
					else
					{
						CurrLeave = "";
					}
					CurrPayUp = Convert.ToInt32(oRec["pay_upgrade"]);
					if (CurrPayUp != 0)
					{
						CurrJobCode = Convert.ToString(oRec["job_code_id"]);
					}
					else
					{
						CurrJobCode = "";
					}
					CurrRow++;
				}
				else if (CurrKOT == modGlobal.Clean(oRec["work_time"]))
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
					if (Convert.IsDBNull(oRec["leave_time"]))
					{
						if (CurrLeave == "")
						{
							if (Convert.ToDouble(oRec["pay_upgrade"]) == CurrPayUp)
							{
								if (Convert.ToBoolean(oRec["pay_upgrade"]))
								{
									if (CurrJobCode == Convert.ToString(oRec["job_code_id"]))
									{
										ViewModel.sprExcept.Col = 7;
										strAMPM = ViewModel.sprExcept.Text + "/" + Convert.ToString(oRec["AMPM"]);
										ViewModel.sprExcept.Text = strAMPM;
									}
									else
									{
										ViewModel.sprExcept.Row = CurrRow;
										ViewModel.sprExcept.Col = 1;
										ViewModel.sprExcept.Text = Convert.ToString(oRec["name_full"]);
										ViewModel.sprExcept.Col = 2;
										ViewModel.sprExcept.Text = modGlobal.Clean(oRec["work_time"]);
										//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
										if (!Convert.IsDBNull(oRec["leave_time"]) && modGlobal.Clean(oRec["leave_time"]) != "TRD")
										{
											ViewModel.sprExcept.Col = 3;
											ViewModel.sprExcept.Text = modGlobal.Clean(oRec["leave_time"]);
											if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1)
											{
												ViewModel.sprExcept.FontUnderline = true;
											}
										}
										if (Convert.ToBoolean(oRec["pay_upgrade"]))
										{
											ViewModel.sprExcept.Col = 4;
											ViewModel.sprExcept.Text = "X";
											ViewModel.sprExcept.Col = 5;
											ViewModel.sprExcept.Text = Convert.ToString(oRec["job_code_id"]);
											ViewModel.sprExcept.Col = 6;
											ViewModel.sprExcept.Text = modGlobal.Clean(oRec["step"]);
										}
										ViewModel.sprExcept.Col = 7;
										ViewModel.sprExcept.Text = Convert.ToString(oRec["AMPM"]);
										CurrEmp = Convert.ToString(oRec["name_full"]);
										CurrKOT = modGlobal.Clean(oRec["work_time"]);
										//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
										if (!Convert.IsDBNull(oRec["leave_time"]))
										{
											CurrLeave = modGlobal.Clean(oRec["leave_time"]);
										}
										else
										{
											CurrLeave = "";
										}
										CurrPayUp = Convert.ToInt32(oRec["pay_upgrade"]);
										if (CurrPayUp != 0)
										{
											CurrJobCode = Convert.ToString(oRec["job_code_id"]);
										}
										else
										{
											CurrJobCode = "";
										}
										CurrRow++;
									}
								}
								else
								{
									ViewModel.sprExcept.Col = 7;
									strAMPM = ViewModel.sprExcept.Text + "/" + Convert.ToString(oRec["AMPM"]);
									ViewModel.sprExcept.Text = strAMPM;
								}
							}
							else
							{
								ViewModel.sprExcept.Row = CurrRow;
								ViewModel.sprExcept.Col = 1;
								ViewModel.sprExcept.Text = Convert.ToString(oRec["name_full"]);
								ViewModel.sprExcept.Col = 2;
								ViewModel.sprExcept.Text = modGlobal.Clean(oRec["work_time"]);
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
								if (!Convert.IsDBNull(oRec["leave_time"]) && modGlobal.Clean(oRec["leave_time"]) != "TRD")
								{
									ViewModel.sprExcept.Col = 3;
									ViewModel.sprExcept.Text = modGlobal.Clean(oRec["leave_time"]);
									if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1)
									{
										ViewModel.sprExcept.FontUnderline = true;
									}
								}
								if (Convert.ToBoolean(oRec["pay_upgrade"]))
								{
									ViewModel.sprExcept.Col = 4;
									ViewModel.sprExcept.Text = "X";
									ViewModel.sprExcept.Col = 5;
									ViewModel.sprExcept.Text = Convert.ToString(oRec["job_code_id"]);
									ViewModel.sprExcept.Col = 6;
									ViewModel.sprExcept.Text = modGlobal.Clean(oRec["step"]);
								}
								ViewModel.sprExcept.Col = 7;
								ViewModel.sprExcept.Text = Convert.ToString(oRec["AMPM"]);
								CurrEmp = Convert.ToString(oRec["name_full"]);
								CurrKOT = modGlobal.Clean(oRec["work_time"]);
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
								if (!Convert.IsDBNull(oRec["leave_time"]))
								{
									CurrLeave = modGlobal.Clean(oRec["leave_time"]);
								}
								else
								{
									CurrLeave = "";
								}
								CurrPayUp = Convert.ToInt32(oRec["pay_upgrade"]);
								if (CurrPayUp != 0)
								{
									CurrJobCode = Convert.ToString(oRec["job_code_id"]);
								}
								else
								{
									CurrJobCode = "";
								}
								CurrRow++;
							}
						}
						else
						{
							ViewModel.sprExcept.Row = CurrRow;
							ViewModel.sprExcept.Col = 1;
							ViewModel.sprExcept.Text = Convert.ToString(oRec["name_full"]);
							ViewModel.sprExcept.Col = 2;
							ViewModel.sprExcept.Text = modGlobal.Clean(oRec["work_time"]);
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
							if (!Convert.IsDBNull(oRec["leave_time"]) && modGlobal.Clean(oRec["leave_time"]) != "TRD")
							{
								ViewModel.sprExcept.Col = 3;
								ViewModel.sprExcept.Text = modGlobal.Clean(oRec["leave_time"]);
								if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1)
								{
									ViewModel.sprExcept.FontUnderline = true;
								}
							}
							if (Convert.ToBoolean(oRec["pay_upgrade"]))
							{
								ViewModel.sprExcept.Col = 4;
								ViewModel.sprExcept.Text = "X";
								ViewModel.sprExcept.Col = 5;
								ViewModel.sprExcept.Text = Convert.ToString(oRec["job_code_id"]);
								ViewModel.sprExcept.Col = 6;
								ViewModel.sprExcept.Text = modGlobal.Clean(oRec["step"]);
							}
							ViewModel.sprExcept.Col = 7;
							ViewModel.sprExcept.Text = Convert.ToString(oRec["AMPM"]);
							CurrEmp = Convert.ToString(oRec["name_full"]);
							CurrKOT = modGlobal.Clean(oRec["work_time"]);
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
							if (!Convert.IsDBNull(oRec["leave_time"]))
							{
								CurrLeave = modGlobal.Clean(oRec["leave_time"]);
							}
							else
							{
								CurrLeave = "";
							}
							CurrPayUp = Convert.ToInt32(oRec["pay_upgrade"]);
							if (CurrPayUp != 0)
							{
								CurrJobCode = Convert.ToString(oRec["job_code_id"]);
							}
							else
							{
								CurrJobCode = "";
							}
							CurrRow++;
						}
					}
					else if (modGlobal.Clean(oRec["leave_time"]) == CurrLeave)
					{
						ViewModel.sprExcept.Col = 7;
						strAMPM = ViewModel.sprExcept.Text + "/" + Convert.ToString(oRec["AMPM"]);
						ViewModel.sprExcept.Text = strAMPM;
					}
					else
					{
						ViewModel.sprExcept.Row = CurrRow;
						ViewModel.sprExcept.Col = 1;
						ViewModel.sprExcept.Text = Convert.ToString(oRec["name_full"]);
						ViewModel.sprExcept.Col = 2;
						ViewModel.sprExcept.Text = modGlobal.Clean(oRec["work_time"]);
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
						if (!Convert.IsDBNull(oRec["leave_time"]) && modGlobal.Clean(oRec["leave_time"]) != "TRD")
						{
							ViewModel.sprExcept.Col = 3;
							ViewModel.sprExcept.Text = modGlobal.Clean(oRec["leave_time"]);
							if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1)
							{
								ViewModel.sprExcept.FontUnderline = true;
							}
						}
						if (Convert.ToBoolean(oRec["pay_upgrade"]))
						{
							ViewModel.sprExcept.Col = 4;
							ViewModel.sprExcept.Text = "X";
							ViewModel.sprExcept.Col = 5;
							ViewModel.sprExcept.Text = Convert.ToString(oRec["job_code_id"]);
							ViewModel.sprExcept.Col = 6;
							ViewModel.sprExcept.Text = modGlobal.Clean(oRec["step"]);
						}
						ViewModel.sprExcept.Col = 7;
						ViewModel.sprExcept.Text = Convert.ToString(oRec["AMPM"]);
						CurrEmp = Convert.ToString(oRec["name_full"]);
						CurrKOT = modGlobal.Clean(oRec["work_time"]);
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
						if (!Convert.IsDBNull(oRec["leave_time"]))
						{
							CurrLeave = modGlobal.Clean(oRec["leave_time"]);
						}
						else
						{
							CurrLeave = "";
						}
						CurrPayUp = Convert.ToInt32(oRec["pay_upgrade"]);
						if (CurrPayUp != 0)
						{
							CurrJobCode = Convert.ToString(oRec["job_code_id"]);
						}
						else
						{
							CurrJobCode = "";
						}
						CurrRow++;
					}
				}
				else
				{
					ViewModel.sprExcept.Row = CurrRow;
					ViewModel.sprExcept.Col = 1;
					ViewModel.sprExcept.Text = Convert.ToString(oRec["name_full"]);
					ViewModel.sprExcept.Col = 2;
					ViewModel.sprExcept.Text = modGlobal.Clean(oRec["work_time"]);
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
					if (!Convert.IsDBNull(oRec["leave_time"]) && modGlobal.Clean(oRec["leave_time"]) != "TRD")
					{
						ViewModel.sprExcept.Col = 3;
						ViewModel.sprExcept.Text = modGlobal.Clean(oRec["leave_time"]);
						if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1)
						{
							ViewModel.sprExcept.FontUnderline = true;
						}
					}
					if (Convert.ToBoolean(oRec["pay_upgrade"]))
					{
						ViewModel.sprExcept.Col = 4;
						ViewModel.sprExcept.Text = "X";
						ViewModel.sprExcept.Col = 5;
						ViewModel.sprExcept.Text = Convert.ToString(oRec["job_code_id"]);
						ViewModel.sprExcept.Col = 6;
						ViewModel.sprExcept.Text = modGlobal.Clean(oRec["step"]);
					}
					ViewModel.sprExcept.Col = 7;
					ViewModel.sprExcept.Text = Convert.ToString(oRec["AMPM"]);
					CurrEmp = Convert.ToString(oRec["name_full"]);
					CurrKOT = modGlobal.Clean(oRec["work_time"]);
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
					if (!Convert.IsDBNull(oRec["leave_time"]))
					{
						CurrLeave = modGlobal.Clean(oRec["leave_time"]);
					}
					else
					{
						CurrLeave = "";
					}
					CurrPayUp = Convert.ToInt32(oRec["pay_upgrade"]);
					if (CurrPayUp != 0)
					{
						CurrJobCode = Convert.ToString(oRec["job_code_id"]);
					}
					else
					{
						CurrJobCode = "";
					}
					CurrRow++;
				}
				oRec.MoveNext();
			};
			//************************
			oCmd.CommandText = "spReport_BattExcept '" + StartDate + "','" + EndDate + "','3'";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			if (!oRec.EOF)
			{
				//Batt 3 Reserve Units Payroll Exceptions
				CurrRow++;
				ViewModel.sprExcept.Row = CurrRow;
				ViewModel.sprExcept.Col = 1;
				ViewModel.sprExcept.Text = "Battalion 4/Reserve Unit Payroll Exceptions";
				CurrRow++;
				ViewModel.sprExcept.Row = CurrRow;
			}


			while(!oRec.EOF)
			{
				if (CurrEmp != Convert.ToString(oRec["name_full"]))
				{
					ViewModel.sprExcept.Row = CurrRow;
					ViewModel.sprExcept.Col = 1;
					ViewModel.sprExcept.Text = Convert.ToString(oRec["name_full"]);
					ViewModel.sprExcept.Col = 2;
					ViewModel.sprExcept.Text = modGlobal.Clean(oRec["work_time"]);
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
					if (!Convert.IsDBNull(oRec["leave_time"]) && modGlobal.Clean(oRec["leave_time"]) != "TRD")
					{
						ViewModel.sprExcept.Col = 3;
						ViewModel.sprExcept.Text = modGlobal.Clean(oRec["leave_time"]);
						if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1)
						{
							ViewModel.sprExcept.FontUnderline = true;
						}
					}
					if (Convert.ToBoolean(oRec["pay_upgrade"]))
					{
						ViewModel.sprExcept.Col = 4;
						ViewModel.sprExcept.Text = "X";
						ViewModel.sprExcept.Col = 5;
						ViewModel.sprExcept.Text = Convert.ToString(oRec["job_code_id"]);
						ViewModel.sprExcept.Col = 6;
						ViewModel.sprExcept.Text = modGlobal.Clean(oRec["step"]);
					}
					ViewModel.sprExcept.Col = 7;
					ViewModel.sprExcept.Text = Convert.ToString(oRec["AMPM"]);
					CurrEmp = Convert.ToString(oRec["name_full"]);
					CurrKOT = modGlobal.Clean(oRec["work_time"]);
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
					if (!Convert.IsDBNull(oRec["leave_time"]))
					{
						CurrLeave = modGlobal.Clean(oRec["leave_time"]);
					}
					else
					{
						CurrLeave = "";
					}
					CurrPayUp = Convert.ToInt32(oRec["pay_upgrade"]);
					if (CurrPayUp != 0)
					{
						CurrJobCode = Convert.ToString(oRec["job_code_id"]);
					}
					else
					{
						CurrJobCode = "";
					}
					CurrRow++;
				}
				else if (CurrKOT == modGlobal.Clean(oRec["work_time"]))
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
					if (Convert.IsDBNull(oRec["leave_time"]))
					{
						if (CurrLeave == "")
						{
							if (Convert.ToDouble(oRec["pay_upgrade"]) == CurrPayUp)
							{
								if (Convert.ToBoolean(oRec["pay_upgrade"]))
								{
									if (CurrJobCode == Convert.ToString(oRec["job_code_id"]))
									{
										ViewModel.sprExcept.Col = 7;
										strAMPM = ViewModel.sprExcept.Text + "/" + Convert.ToString(oRec["AMPM"]);
										ViewModel.sprExcept.Text = strAMPM;
									}
									else
									{
										ViewModel.sprExcept.Row = CurrRow;
										ViewModel.sprExcept.Col = 1;
										ViewModel.sprExcept.Text = Convert.ToString(oRec["name_full"]);
										ViewModel.sprExcept.Col = 2;
										ViewModel.sprExcept.Text = modGlobal.Clean(oRec["work_time"]);
										//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
										if (!Convert.IsDBNull(oRec["leave_time"]) && modGlobal.Clean(oRec["leave_time"]) != "TRD")
										{
											ViewModel.sprExcept.Col = 3;
											ViewModel.sprExcept.Text = modGlobal.Clean(oRec["leave_time"]);
											if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1)
											{
												ViewModel.sprExcept.FontUnderline = true;
											}
										}
										if (Convert.ToBoolean(oRec["pay_upgrade"]))
										{
											ViewModel.sprExcept.Col = 4;
											ViewModel.sprExcept.Text = "X";
											ViewModel.sprExcept.Col = 5;
											ViewModel.sprExcept.Text = Convert.ToString(oRec["job_code_id"]);
											ViewModel.sprExcept.Col = 6;
											ViewModel.sprExcept.Text = modGlobal.Clean(oRec["step"]);
										}
										ViewModel.sprExcept.Col = 7;
										ViewModel.sprExcept.Text = Convert.ToString(oRec["AMPM"]);
										CurrEmp = Convert.ToString(oRec["name_full"]);
										CurrKOT = modGlobal.Clean(oRec["work_time"]);
										//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
										if (!Convert.IsDBNull(oRec["leave_time"]))
										{
											CurrLeave = modGlobal.Clean(oRec["leave_time"]);
										}
										else
										{
											CurrLeave = "";
										}
										CurrPayUp = Convert.ToInt32(oRec["pay_upgrade"]);
										if (CurrPayUp != 0)
										{
											CurrJobCode = Convert.ToString(oRec["job_code_id"]);
										}
										else
										{
											CurrJobCode = "";
										}
										CurrRow++;
									}
								}
								else
								{
									ViewModel.sprExcept.Col = 7;
									strAMPM = ViewModel.sprExcept.Text + "/" + Convert.ToString(oRec["AMPM"]);
									ViewModel.sprExcept.Text = strAMPM;
								}
							}
							else
							{
								ViewModel.sprExcept.Row = CurrRow;
								ViewModel.sprExcept.Col = 1;
								ViewModel.sprExcept.Text = Convert.ToString(oRec["name_full"]);
								ViewModel.sprExcept.Col = 2;
								ViewModel.sprExcept.Text = modGlobal.Clean(oRec["work_time"]);
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
								if (!Convert.IsDBNull(oRec["leave_time"]) && modGlobal.Clean(oRec["leave_time"]) != "TRD")
								{
									ViewModel.sprExcept.Col = 3;
									ViewModel.sprExcept.Text = modGlobal.Clean(oRec["leave_time"]);
									if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1)
									{
										ViewModel.sprExcept.FontUnderline = true;
									}
								}
								if (Convert.ToBoolean(oRec["pay_upgrade"]))
								{
									ViewModel.sprExcept.Col = 4;
									ViewModel.sprExcept.Text = "X";
									ViewModel.sprExcept.Col = 5;
									ViewModel.sprExcept.Text = Convert.ToString(oRec["job_code_id"]);
									ViewModel.sprExcept.Col = 6;
									ViewModel.sprExcept.Text = modGlobal.Clean(oRec["step"]);
								}
								ViewModel.sprExcept.Col = 7;
								ViewModel.sprExcept.Text = Convert.ToString(oRec["AMPM"]);
								CurrEmp = Convert.ToString(oRec["name_full"]);
								CurrKOT = modGlobal.Clean(oRec["work_time"]);
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
								if (!Convert.IsDBNull(oRec["leave_time"]))
								{
									CurrLeave = modGlobal.Clean(oRec["leave_time"]);
								}
								else
								{
									CurrLeave = "";
								}
								CurrPayUp = Convert.ToInt32(oRec["pay_upgrade"]);
								if (CurrPayUp != 0)
								{
									CurrJobCode = Convert.ToString(oRec["job_code_id"]);
								}
								else
								{
									CurrJobCode = "";
								}
								CurrRow++;
							}
						}
						else
						{
							ViewModel.sprExcept.Row = CurrRow;
							ViewModel.sprExcept.Col = 1;
							ViewModel.sprExcept.Text = Convert.ToString(oRec["name_full"]);
							ViewModel.sprExcept.Col = 2;
							ViewModel.sprExcept.Text = modGlobal.Clean(oRec["work_time"]);
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
							if (!Convert.IsDBNull(oRec["leave_time"]) && modGlobal.Clean(oRec["leave_time"]) != "TRD")
							{
								ViewModel.sprExcept.Col = 3;
								ViewModel.sprExcept.Text = modGlobal.Clean(oRec["leave_time"]);
								if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1)
								{
									ViewModel.sprExcept.FontUnderline = true;
								}
							}
							if (Convert.ToBoolean(oRec["pay_upgrade"]))
							{
								ViewModel.sprExcept.Col = 4;
								ViewModel.sprExcept.Text = "X";
								ViewModel.sprExcept.Col = 5;
								ViewModel.sprExcept.Text = Convert.ToString(oRec["job_code_id"]);
								ViewModel.sprExcept.Col = 6;
								ViewModel.sprExcept.Text = modGlobal.Clean(oRec["step"]);
							}
							ViewModel.sprExcept.Col = 7;
							ViewModel.sprExcept.Text = Convert.ToString(oRec["AMPM"]);
							CurrEmp = Convert.ToString(oRec["name_full"]);
							CurrKOT = modGlobal.Clean(oRec["work_time"]);
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
							if (!Convert.IsDBNull(oRec["leave_time"]))
							{
								CurrLeave = modGlobal.Clean(oRec["leave_time"]);
							}
							else
							{
								CurrLeave = "";
							}
							CurrPayUp = Convert.ToInt32(oRec["pay_upgrade"]);
							if (CurrPayUp != 0)
							{
								CurrJobCode = Convert.ToString(oRec["job_code_id"]);
							}
							else
							{
								CurrJobCode = "";
							}
							CurrRow++;
						}
					}
					else if (modGlobal.Clean(oRec["leave_time"]) == CurrLeave)
					{
						ViewModel.sprExcept.Col = 7;
						strAMPM = ViewModel.sprExcept.Text + "/" + Convert.ToString(oRec["AMPM"]);
						ViewModel.sprExcept.Text = strAMPM;
					}
					else
					{
						ViewModel.sprExcept.Row = CurrRow;
						ViewModel.sprExcept.Col = 1;
						ViewModel.sprExcept.Text = Convert.ToString(oRec["name_full"]);
						ViewModel.sprExcept.Col = 2;
						ViewModel.sprExcept.Text = modGlobal.Clean(oRec["work_time"]);
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
						if (!Convert.IsDBNull(oRec["leave_time"]) && modGlobal.Clean(oRec["leave_time"]) != "TRD")
						{
							ViewModel.sprExcept.Col = 3;
							ViewModel.sprExcept.Text = modGlobal.Clean(oRec["leave_time"]);
							if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1)
							{
								ViewModel.sprExcept.FontUnderline = true;
							}
						}
						if (Convert.ToBoolean(oRec["pay_upgrade"]))
						{
							ViewModel.sprExcept.Col = 4;
							ViewModel.sprExcept.Text = "X";
							ViewModel.sprExcept.Col = 5;
							ViewModel.sprExcept.Text = Convert.ToString(oRec["job_code_id"]);
							ViewModel.sprExcept.Col = 6;
							ViewModel.sprExcept.Text = modGlobal.Clean(oRec["step"]);
						}
						ViewModel.sprExcept.Col = 7;
						ViewModel.sprExcept.Text = Convert.ToString(oRec["AMPM"]);
						CurrEmp = Convert.ToString(oRec["name_full"]);
						CurrKOT = modGlobal.Clean(oRec["work_time"]);
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
						if (!Convert.IsDBNull(oRec["leave_time"]))
						{
							CurrLeave = modGlobal.Clean(oRec["leave_time"]);
						}
						else
						{
							CurrLeave = "";
						}
						CurrPayUp = Convert.ToInt32(oRec["pay_upgrade"]);
						if (CurrPayUp != 0)
						{
							CurrJobCode = Convert.ToString(oRec["job_code_id"]);
						}
						else
						{
							CurrJobCode = "";
						}
						CurrRow++;
					}
				}
				else
				{
					ViewModel.sprExcept.Row = CurrRow;
					ViewModel.sprExcept.Col = 1;
					ViewModel.sprExcept.Text = Convert.ToString(oRec["name_full"]);
					ViewModel.sprExcept.Col = 2;
					ViewModel.sprExcept.Text = modGlobal.Clean(oRec["work_time"]);
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
					if (!Convert.IsDBNull(oRec["leave_time"]) && modGlobal.Clean(oRec["leave_time"]) != "TRD")
					{
						ViewModel.sprExcept.Col = 3;
						ViewModel.sprExcept.Text = modGlobal.Clean(oRec["leave_time"]);
						if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1)
						{
							ViewModel.sprExcept.FontUnderline = true;
						}
					}
					if (Convert.ToBoolean(oRec["pay_upgrade"]))
					{
						ViewModel.sprExcept.Col = 4;
						ViewModel.sprExcept.Text = "X";
						ViewModel.sprExcept.Col = 5;
						ViewModel.sprExcept.Text = Convert.ToString(oRec["job_code_id"]);
						ViewModel.sprExcept.Col = 6;
						ViewModel.sprExcept.Text = modGlobal.Clean(oRec["step"]);
					}
					ViewModel.sprExcept.Col = 7;
					ViewModel.sprExcept.Text = Convert.ToString(oRec["AMPM"]);
					CurrEmp = Convert.ToString(oRec["name_full"]);
					CurrKOT = modGlobal.Clean(oRec["work_time"]);
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
					if (!Convert.IsDBNull(oRec["leave_time"]))
					{
						CurrLeave = modGlobal.Clean(oRec["leave_time"]);
					}
					else
					{
						CurrLeave = "";
					}
					CurrPayUp = Convert.ToInt32(oRec["pay_upgrade"]);
					if (CurrPayUp != 0)
					{
						CurrJobCode = Convert.ToString(oRec["job_code_id"]);
					}
					else
					{
						CurrJobCode = "";
					}
					CurrRow++;
				}
				oRec.MoveNext();
			};

			//************************

			//Retrieve Battalion Schedule Notes
			oCmd.CommandText = "spReport_GetBattNote '" + StartDate + "','" + EndDate + "','1'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.sprExcept.Col = 1;
			CurrRow += 2;
			ViewModel.sprExcept.Row = CurrRow;
			ViewModel.sprExcept.Text = "Battalion Notes:";
			CurrRow++;


			while(!oRec.EOF)
			{
				Note1 = Convert.ToString(oRec["note"]).Trim();
				for (int L = 1; L <= Strings.Len(Note1); L++)
				{
					NoteChar = Note1.Substring(L - 1, Math.Min(1, Note1.Length - (L - 1)));
					if (Strings.Asc(NoteChar[0]) == 13)
					{
						ViewModel.sprExcept.Row = CurrRow;
						ViewModel.sprExcept.Text = Note2;
						Note2 = "";
						CurrRow++;
						//L = L + 1
					}
					else if (Strings.Len(Note2) > 80)
					{
						Note2 = Note2 + NoteChar;
						ViewModel.sprExcept.Row = CurrRow;
						ViewModel.sprExcept.Text = Note2;
						Note2 = "";
						CurrRow++;
					}
					else
					{
						Note2 = Note2 + NoteChar;
					}
				}
				ViewModel.sprExcept.Row = CurrRow;
				ViewModel.sprExcept.Text = Note2;
				oRec.MoveNext();
			};

			//************************

			//Retrieve Personnel Schedule Notes
			oCmd.CommandText = "spSelect_PersonnelScheduleNotesList '" + StartDate + "', '1' ";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.sprExcept.Col = 1;
			CurrRow += 2;
			ViewModel.sprExcept.Row = CurrRow;
			ViewModel.sprExcept.Text = "Employee Schedule Notes:";
			CurrRow++;


			while(!oRec.EOF)
			{
				Note1 = "  For " + Convert.ToString(oRec["name_full"]).Trim();
				Note1 = Note1 + " authored by " + Convert.ToString(oRec["author"]).Trim();
				ViewModel.sprExcept.Row = CurrRow;
				ViewModel.sprExcept.Text = Note1;
				CurrRow++;
				Note1 = Convert.ToString(oRec["note"]).Trim();
				Note2 = "";
				for (int L = 1; L <= Strings.Len(Note1); L++)
				{
					NoteChar = Note1.Substring(L - 1, Math.Min(1, Note1.Length - (L - 1)));
					if (Strings.Asc(NoteChar[0]) == 13)
					{
						ViewModel.sprExcept.Row = CurrRow;
						ViewModel.sprExcept.Text = Note2;
						Note2 = "";
						CurrRow++;
						//L = L + 1
					}
					else if (Strings.Len(Note2) > 80)
					{
						Note2 = Note2 + NoteChar;
						ViewModel.sprExcept.Row = CurrRow;
						ViewModel.sprExcept.Text = Note2;
						Note2 = "";
						CurrRow++;
					}
					else
					{
						Note2 = Note2 + NoteChar;
					}
				}
				ViewModel.sprExcept.Row = CurrRow;
				ViewModel.sprExcept.Text = Note2;
				CurrRow++;
				oRec.MoveNext();
			};

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
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprExcept.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprExcept.setPrintAbortMsg("Printing Battalion 1 Exception Report - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprExcept.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprExcept.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprExcept.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprExcept.setPrintColor(true);
            //    sprExcept.PrintOrientation = 1
            ViewModel.sprExcept.PrintSheet(null);
            //ViewModel.sprExcept.Action = (FarPoint.ViewModels.FPActionConstants) 32;

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{

			for (int i = 0; i <= ViewManager.OpenFormsCount - 1; i++)
			{
				if ( ViewManager.GetOpenFormAt(i).ViewModel.Name == "frmTimeCard1")
				{
					ViewModel.calDate.Value = frmTimeCard1.DefInstance.ViewModel.calDate.Value.Date;
					return;
					//        Else
					//            calDate.Date = gBattSwitchDate
					//            Exit Sub
				}
				else if ( ViewManager.GetOpenFormAt(i).ViewModel.Name == "frmNewBattSched")
				{
					ViewModel.calDate.Value = frmNewBattSched.DefInstance.ViewModel.calSchedDate.Value.Date;
				}
			}
			ViewModel.FirstTime = -1;
			FillSpread();
			//    'MDIForm1.Arrange vbCascade
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmException1 DefInstance
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

		public static frmException1 CreateInstance()
		{
			PTSProject.frmException1 theInstance = Shared.Container.Resolve< frmException1>();
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
			ViewModel.sprExcept.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprExcept.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmException1
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmException1ViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmException1 m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}