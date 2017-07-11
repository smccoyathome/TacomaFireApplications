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

	public partial class frmQclass
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmQclassViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmQclass));
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


		private void frmQclass_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		public void ClearReport()
		{
			if ( ViewModel.TotalRows == 0)
			{
				return;
			}
			ViewModel.sprQ1.BlockMode = true;
			ViewModel.sprQ1.Row = 3;
			ViewModel.sprQ1.Row2 = ViewModel.TotalRows;
			ViewModel.sprQ1.Col = 1;
			ViewModel.sprQ1.Col2 = 2;
			//ViewModel.sprQ1.Action = (FarPoint.ViewModels.FPActionConstants) 12; //Clear Text

			ViewModel.sprQ1.BlockMode = false;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClear_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ClearReport();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Print Individual Training Report

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprQ1.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprQ1.setPrintAbortMsg("Printing Class Participation Query Results");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprQ1.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprQ1.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprQ1.PrintColHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprQ1.setPrintColHeaders(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprQ1.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprQ1.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprQ1.PrintMarginTop was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprQ1.setPrintMarginTop(720);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprQ1.PrintMarginLeft was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprQ1.setPrintMarginLeft(500);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprQ1.PrintRowHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprQ1.setPrintRowHeaders(false);
            //Perform the printing action
            ViewModel.sprQ1.PrintSheet(null);
			//ViewModel.sprQ1.Action = (FarPoint.ViewModels.FPActionConstants) 32;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdQuery_Click(Object eventSender, System.EventArgs eventArgs)
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string DateHold = "", BattHold = "";
			string ClassID = "";
			int CurrRow = 0;
			//int LineCount = 0;

			//Check for Query Parameters
			if ( ViewModel.cboClass.SelectedIndex == -1)
			{
				ViewManager.ShowMessage("Please select a class", "Class Query Message", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}
			else
			{
				ClassID = ViewModel.cboClass.Text.Substring(Math.Max(ViewModel.cboClass.Text.Length - 10, 0));
			}

			if ( ViewModel.cboPersonnel.SelectedIndex == -1)
			{
				ViewManager.ShowMessage("Please select Personnel Type", "Class Query Message", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			string StartDate = DateTime.Parse(ViewModel.calStart.Text).ToString("MM/dd/yyyy");
			string EndDate = DateTime.Parse(ViewModel.calEnd.Text).ToString("MM/dd/yyyy");
			string ClassSdate = DateTime.Parse(ViewModel.calClassStart.Text).ToString("MM/dd/yyyy");
			string ClassEdate = DateTime.Parse(ViewModel.calClassEnd.Text).AddDays(1).ToString("MM/dd/yyyy");

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			ClearReport();
			string Qdesc = ViewModel.cboPersonnel.Text.Trim() + " ";

			//Create Query
			if ( ViewModel.optParam[0].Checked)
			{
				Qdesc = Qdesc + "attending " + ViewModel.cboClass.Text.Substring(0, Math.Min(ViewModel.cboClass.Text.IndexOf(':'), ViewModel.cboClass.Text.Length)) + " ";
				ViewModel.sprQ1.Col = 1;
				ViewModel.sprQ1.Row = 3;
				ViewModel.sprQ1.Text = Qdesc;
				Qdesc = "Between " + StartDate + " and " + EndDate;
				ViewModel.sprQ1.Row = 4;
				ViewModel.sprQ1.Text = Qdesc;
				ViewModel.sprQ1.Row = 5;
				ViewModel.sprQ1.Text = "Employee";
				ViewModel.sprQ1.Col = 2;
				ViewModel.sprQ1.Text = "Last Class Attended";
				switch( ViewModel.cboPersonnel.SelectedIndex)
				{
					case 0 :
						oCmd.CommandText = "spTraining_CQAttendance '" + ClassID + "','" + StartDate + "','" + EndDate + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						CurrRow = 6;

						while(!oRec.EOF)
						{
							ViewModel.sprQ1.Row = CurrRow;
							ViewModel.sprQ1.Col = 1;
							ViewModel.sprQ1.Text = Convert.ToString(oRec["name_full"]).Trim();
							ViewModel.sprQ1.Col = 2;
							ViewModel.sprQ1.Text = Convert.ToDateTime(oRec["last_date"]).ToString("M/d/yyyy");
							oRec.MoveNext();
							CurrRow++;
						};
						break;
					case 1 :
						//All Operations Staff (Non Civilian) 
						oCmd.CommandText = "spTraining_CQAttendOps '" + ClassID + "','" + StartDate + "','" + EndDate + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						CurrRow = 6;

						while(!oRec.EOF)
						{
							ViewModel.sprQ1.Row = CurrRow;
							ViewModel.sprQ1.Col = 1;
							ViewModel.sprQ1.Text = Convert.ToString(oRec["name_full"]).Trim();
							ViewModel.sprQ1.Col = 2;
							ViewModel.sprQ1.Text = Convert.ToDateTime(oRec["last_date"]).ToString("M/d/yyyy");
							oRec.MoveNext();
							CurrRow++;
						};
						break;
					case 2 :
						//Civilian Staff 
						oCmd.CommandText = "spTraining_CQAttendCiv '" + ClassID + "','" + StartDate + "','" + EndDate + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						CurrRow = 6;

						while(!oRec.EOF)
						{
							ViewModel.sprQ1.Row = CurrRow;
							ViewModel.sprQ1.Col = 1;
							ViewModel.sprQ1.Text = Convert.ToString(oRec["name_full"]).Trim();
							ViewModel.sprQ1.Col = 2;
							ViewModel.sprQ1.Text = Convert.ToDateTime(oRec["last_date"]).ToString("M/d/yyyy");
							oRec.MoveNext();
							CurrRow++;
						};
						break;
					case 3 :
						//Firefighters - Pilots 
						oCmd.CommandText = "spTraining_CQAttendByRank '" + ClassID + "','" + StartDate + "','" + EndDate + "','FF'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						CurrRow = 6;

						while(!oRec.EOF)
						{
							ViewModel.sprQ1.Row = CurrRow;
							ViewModel.sprQ1.Col = 1;
							ViewModel.sprQ1.Text = Convert.ToString(oRec["name_full"]).Trim();
							ViewModel.sprQ1.Col = 2;
							ViewModel.sprQ1.Text = Convert.ToDateTime(oRec["last_date"]).ToString("M/d/yyyy");
							oRec.MoveNext();
							CurrRow++;
						};
						oCmd.CommandText = "spTraining_CQAttendByRank '" + ClassID + "','" + StartDate + "','" + EndDate + "','PILOT'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						while(!oRec.EOF)
						{
							ViewModel.sprQ1.Row = CurrRow;
							ViewModel.sprQ1.Col = 1;
							ViewModel.sprQ1.Text = Convert.ToString(oRec["name_full"]).Trim();
							ViewModel.sprQ1.Col = 2;
							ViewModel.sprQ1.Text = Convert.ToDateTime(oRec["last_date"]).ToString("M/d/yyyy");
							oRec.MoveNext();
							CurrRow++;
						};
						break;
					case 4 :
						//Paramedics, Paramedic Supervisors 
						oCmd.CommandText = "spTraining_CQAttendByRank '" + ClassID + "','" + StartDate + "','" + EndDate + "','FF/PM'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						CurrRow = 6;

						while(!oRec.EOF)
						{
							ViewModel.sprQ1.Row = CurrRow;
							ViewModel.sprQ1.Col = 1;
							ViewModel.sprQ1.Text = Convert.ToString(oRec["name_full"]).Trim();
							ViewModel.sprQ1.Col = 2;
							ViewModel.sprQ1.Text = Convert.ToDateTime(oRec["last_date"]).ToString("M/d/yyyy");
							oRec.MoveNext();
							CurrRow++;
						};
						oCmd.CommandText = "spTraining_CQAttendByRank '" + ClassID + "','" + StartDate + "','" + EndDate + "','PM SUPV'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						while(!oRec.EOF)
						{
							ViewModel.sprQ1.Row = CurrRow;
							ViewModel.sprQ1.Col = 1;
							ViewModel.sprQ1.Text = Convert.ToString(oRec["name_full"]).Trim();
							ViewModel.sprQ1.Col = 2;
							ViewModel.sprQ1.Text = Convert.ToDateTime(oRec["last_date"]).ToString("M/d/yyyy");
							oRec.MoveNext();
							CurrRow++;
						};
						break;
					case 5 :
						//Dispatchers 
						oCmd.CommandText = "spTraining_CQAttendByRank '" + ClassID + "','" + StartDate + "','" + EndDate + "','LT DISP'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						CurrRow = 6;

						while(!oRec.EOF)
						{
							ViewModel.sprQ1.Row = CurrRow;
							ViewModel.sprQ1.Col = 1;
							ViewModel.sprQ1.Text = Convert.ToString(oRec["name_full"]).Trim();
							ViewModel.sprQ1.Col = 2;
							ViewModel.sprQ1.Text = Convert.ToDateTime(oRec["last_date"]).ToString("M/d/yyyy");
							oRec.MoveNext();
							CurrRow++;
						};
						oCmd.CommandText = "spTraining_CQAttendByRank '" + ClassID + "','" + StartDate + "','" + EndDate + "','CPT DISP'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						while(!oRec.EOF)
						{
							ViewModel.sprQ1.Row = CurrRow;
							ViewModel.sprQ1.Col = 1;
							ViewModel.sprQ1.Text = Convert.ToString(oRec["name_full"]).Trim();
							ViewModel.sprQ1.Col = 2;
							ViewModel.sprQ1.Text = Convert.ToDateTime(oRec["last_date"]).ToString("M/d/yyyy");
							oRec.MoveNext();
							CurrRow++;
						};

						break;
					case 6 :
						//Inspectors 
						oCmd.CommandText = "spTraining_CQAttend40 '" + ClassID + "','FPB','" + StartDate + "','" + EndDate + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						CurrRow = 6;

						while(!oRec.EOF)
						{
							ViewModel.sprQ1.Row = CurrRow;
							ViewModel.sprQ1.Col = 1;
							ViewModel.sprQ1.Text = Convert.ToString(oRec["name_full"]).Trim();
							ViewModel.sprQ1.Col = 2;
							ViewModel.sprQ1.Text = Convert.ToDateTime(oRec["last_date"]).ToString("M/d/yyyy");
							oRec.MoveNext();
							CurrRow++;
						};
						break;
					case 7 :
						//Officers 
						oCmd.CommandText = "spTraining_CQAttendByRank '" + ClassID + "','" + StartDate + "','" + EndDate + "','LT'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						CurrRow = 6;

						while(!oRec.EOF)
						{
							ViewModel.sprQ1.Row = CurrRow;
							ViewModel.sprQ1.Col = 1;
							ViewModel.sprQ1.Text = Convert.ToString(oRec["name_full"]).Trim();
							ViewModel.sprQ1.Col = 2;
							ViewModel.sprQ1.Text = Convert.ToDateTime(oRec["last_date"]).ToString("M/d/yyyy");
							oRec.MoveNext();
							CurrRow++;
						};
						oCmd.CommandText = "spTraining_CQAttendByRank '" + ClassID + "','" + StartDate + "','" + EndDate + "','CAPT'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						while(!oRec.EOF)
						{
							ViewModel.sprQ1.Row = CurrRow;
							ViewModel.sprQ1.Col = 1;
							ViewModel.sprQ1.Text = Convert.ToString(oRec["name_full"]).Trim();
							ViewModel.sprQ1.Col = 2;
							ViewModel.sprQ1.Text = Convert.ToDateTime(oRec["last_date"]).ToString("M/d/yyyy");
							oRec.MoveNext();
							CurrRow++;
						};
						oCmd.CommandText = "spTraining_CQAttendByRank '" + ClassID + "','" + StartDate + "','" + EndDate + "','CPT DISP'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						while(!oRec.EOF)
						{
							ViewModel.sprQ1.Row = CurrRow;
							ViewModel.sprQ1.Col = 1;
							ViewModel.sprQ1.Text = Convert.ToString(oRec["name_full"]).Trim();
							ViewModel.sprQ1.Col = 2;
							ViewModel.sprQ1.Text = Convert.ToDateTime(oRec["last_date"]).ToString("M/d/yyyy");
							oRec.MoveNext();
							CurrRow++;
						};
						oCmd.CommandText = "spTraining_CQAttendByRank '" + ClassID + "','" + StartDate + "','" + EndDate + "','LT DISP'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						while(!oRec.EOF)
						{
							ViewModel.sprQ1.Row = CurrRow;
							ViewModel.sprQ1.Col = 1;
							ViewModel.sprQ1.Text = Convert.ToString(oRec["name_full"]).Trim();
							ViewModel.sprQ1.Col = 2;
							ViewModel.sprQ1.Text = Convert.ToDateTime(oRec["last_date"]).ToString("M/d/yyyy");
							oRec.MoveNext();
							CurrRow++;
						};

						break;
					case 8 :
						//Command Staff 
						oCmd.CommandText = "spTraining_CQAttendByRank '" + ClassID + "','" + StartDate + "','" + EndDate + "','BC'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						CurrRow = 6;

						while(!oRec.EOF)
						{
							ViewModel.sprQ1.Row = CurrRow;
							ViewModel.sprQ1.Col = 1;
							ViewModel.sprQ1.Text = Convert.ToString(oRec["name_full"]).Trim();
							ViewModel.sprQ1.Col = 2;
							ViewModel.sprQ1.Text = Convert.ToDateTime(oRec["last_date"]).ToString("M/d/yyyy");
							oRec.MoveNext();
							CurrRow++;
						};
						oCmd.CommandText = "spTraining_CQAttendByRank '" + ClassID + "','" + StartDate + "','" + EndDate + "','DEP FM'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						while(!oRec.EOF)
						{
							ViewModel.sprQ1.Row = CurrRow;
							ViewModel.sprQ1.Col = 1;
							ViewModel.sprQ1.Text = Convert.ToString(oRec["name_full"]).Trim();
							ViewModel.sprQ1.Col = 2;
							ViewModel.sprQ1.Text = Convert.ToDateTime(oRec["last_date"]).ToString("M/d/yyyy");
							oRec.MoveNext();
							CurrRow++;
						};
						oCmd.CommandText = "spTraining_CQAttendByRank '" + ClassID + "','" + StartDate + "','" + EndDate + "','ASST CHF'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						while(!oRec.EOF)
						{
							ViewModel.sprQ1.Row = CurrRow;
							ViewModel.sprQ1.Col = 1;
							ViewModel.sprQ1.Text = Convert.ToString(oRec["name_full"]).Trim();
							ViewModel.sprQ1.Col = 2;
							ViewModel.sprQ1.Text = Convert.ToDateTime(oRec["last_date"]).ToString("M/d/yyyy");
							oRec.MoveNext();
							CurrRow++;
						};
						oCmd.CommandText = "spTraining_CQAttendByRank '" + ClassID + "','" + StartDate + "','" + EndDate + "','DC'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						while(!oRec.EOF)
						{
							ViewModel.sprQ1.Row = CurrRow;
							ViewModel.sprQ1.Col = 1;
							ViewModel.sprQ1.Text = Convert.ToString(oRec["name_full"]).Trim();
							ViewModel.sprQ1.Col = 2;
							ViewModel.sprQ1.Text = Convert.ToDateTime(oRec["last_date"]).ToString("M/d/yyyy");
							oRec.MoveNext();
							CurrRow++;
						};
						oCmd.CommandText = "spTraining_CQAttendByRank '" + ClassID + "','" + StartDate + "','" + EndDate + "','CHIEF'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						while(!oRec.EOF)
						{
							ViewModel.sprQ1.Row = CurrRow;
							ViewModel.sprQ1.Col = 1;
							ViewModel.sprQ1.Text = Convert.ToString(oRec["name_full"]).Trim();
							ViewModel.sprQ1.Col = 2;
							ViewModel.sprQ1.Text = Convert.ToDateTime(oRec["last_date"]).ToString("M/d/yyyy");
							oRec.MoveNext();
							CurrRow++;
						};

						break;
				}
			}
			else
			{
				//Query requesting those who have NOT Attended selected Class
				Qdesc = Qdesc + "missing " + ViewModel.cboClass.Text.Substring(0, Math.Min(ViewModel.cboClass.Text.IndexOf(':'), ViewModel.cboClass.Text.Length)) + " ";
				ViewModel.sprQ1.Col = 1;
				ViewModel.sprQ1.Row = 3;
				ViewModel.sprQ1.Text = Qdesc;
				Qdesc = "Between " + StartDate + " and " + EndDate;
				ViewModel.sprQ1.Row = 4;
				ViewModel.sprQ1.Text = Qdesc;
				ViewModel.sprQ1.Row = 5;
				if ( ViewModel.cboPersonnel.SelectedIndex == 0 || ViewModel.cboPersonnel.SelectedIndex == 1 ||
						ViewModel.cboPersonnel.SelectedIndex == 2 || ViewModel.cboPersonnel.SelectedIndex == 6 || ViewModel.cboPersonnel.SelectedIndex == 8)
				{
					ViewModel.sprQ1.Text = "Employee";
				}
				else
				{
					ViewModel.sprQ1.Text = "Shift Date";
				}
				ViewModel.sprQ1.Col = 2;
				ViewModel.sprQ1.Text = "Availability for Training";
				CurrRow = 6;
				DateHold = "";
				BattHold = "";
				Qdesc = "";
				//LineCount = 0;
				switch( ViewModel.cboPersonnel.SelectedIndex)
				{
					case 0 :
						//All TFD Staff 
						//First 40 and Civ staff 
						oCmd.CommandText = "spTraining_CQMissing40Ops '" + ClassID + "','" + StartDate + "','" + EndDate + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						while(!oRec.EOF)
						{
							ViewModel.sprQ1.Row = CurrRow;
							ViewModel.sprQ1.Col = 1;
							ViewModel.sprQ1.Text = Convert.ToString(oRec["name_full"]).Trim();
							ViewModel.sprQ1.Col = 2;
							ViewModel.sprQ1.Text = "40hr. Employee";
							oRec.MoveNext();
							CurrRow++;
						};
						oCmd.CommandText = "spTraining_CQMissingCiv '" + ClassID + "','" + StartDate + "','" + EndDate + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						while(!oRec.EOF)
						{
							ViewModel.sprQ1.Row = CurrRow;
							ViewModel.sprQ1.Col = 1;
							ViewModel.sprQ1.Text = Convert.ToString(oRec["name_full"]).Trim();
							ViewModel.sprQ1.Col = 2;
							ViewModel.sprQ1.Text = "40hr. Employee";
							oRec.MoveNext();
							CurrRow++;
						};
						CurrRow++;
						ViewModel.sprQ1.Row = CurrRow;
						ViewModel.sprQ1.Col = 1;
						ViewModel.sprQ1.Text = "Shift Date";
						ViewModel.sprQ1.Col = 2;
						ViewModel.sprQ1.Text = "Available for Training";
						CurrRow++;
						oCmd.CommandText = "spTraining_CQMissingOps '" + ClassID + "','" + StartDate + "','" + EndDate + "','" + ClassSdate + "','" + ClassEdate + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						if (!oRec.EOF)
						{
							DateHold = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
							BattHold = Convert.ToString(oRec["batt_code"]);
							if (BattHold == "1 ")
							{
								Qdesc = "Battalion 1- ";
							}
							else
							{
								Qdesc = "Battalion 2- ";
							}
							ViewModel.sprQ1.Row = CurrRow;
							ViewModel.sprQ1.Col = 1;
							ViewModel.sprQ1.Text = DateHold;
							//LineCount = 0;
						}

						while(!oRec.EOF)
						{
							if (DateHold != Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy"))
							{
								ViewModel.sprQ1.Row = CurrRow;
								ViewModel.sprQ1.Col = 2;
								ViewModel.sprQ1.Text = Qdesc;
								CurrRow++;
								DateHold = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
								ViewModel.sprQ1.Row = CurrRow;
								ViewModel.sprQ1.Col = 1;
								ViewModel.sprQ1.Text = DateHold;
								BattHold = Convert.ToString(oRec["batt_code"]);
								if (BattHold == "1 ")
								{
									Qdesc = "Battalion 1- ";
								}
								else
								{
									Qdesc = "Battalion 2- ";
								}
								Qdesc = Qdesc + Convert.ToString(oRec["name_full"]).Trim() + ", ";
							}
							else if (BattHold != Convert.ToString(oRec["batt_code"]))
							{
								ViewModel.sprQ1.Row = CurrRow;
								ViewModel.sprQ1.Col = 2;
								ViewModel.sprQ1.Text = Qdesc;
								CurrRow++;
								BattHold = Convert.ToString(oRec["batt_code"]);
								if (BattHold == "1 ")
								{
									Qdesc = "Battalion 1- ";
								}
								else
								{
									Qdesc = "Battalion 2- ";
								}
								Qdesc = Qdesc + Convert.ToString(oRec["name_full"]).Trim();
							}
							else
							{
								if (Strings.Len(Qdesc) + Strings.Len(Convert.ToString(oRec["name_full"]).Trim()) > 58)
								{
									ViewModel.sprQ1.Row = CurrRow;
									ViewModel.sprQ1.Col = 2;
									ViewModel.sprQ1.Text = Qdesc;
									CurrRow++;
									Qdesc = Convert.ToString(oRec["name_full"]).Trim() + ", ";
								}
								else
								{
									Qdesc = Qdesc + Convert.ToString(oRec["name_full"]).Trim() + ", ";
								}
							}
							oRec.MoveNext();
						};
						ViewModel.sprQ1.Row = CurrRow;
						ViewModel.sprQ1.Col = 2;
						ViewModel.sprQ1.Text = Qdesc;
						CurrRow++;
						break;
					case 1 :
						//All Operations Staff 
						//COMMENTING OUT THE 40 hour Op Staff for now January 2005 - DKL 
						//                oCmd.CommandText = "spTraining_CQMissing40Ops '" & ClassID & "','" & StartDate & "','" & EndDate & "'" 
						//                Set oRec = oCmd.Execute 
						//                Do Until oRec.EOF 
						//                    sprQ1.Row = CurrRow 
						//                    sprQ1.Col = 1 
						//                    sprQ1.Text = Trim$(oRec("name_full"]) 
						//                    sprQ1.Col = 2 
						//                    sprQ1.Text = "40hr. Employee" 
						//                    oRec.MoveNext 
						//                    CurrRow = CurrRow + 1 
						//                Loop 
						//                CurrRow = CurrRow + 1 
						//                sprQ1.Row = CurrRow 
						//                sprQ1.Col = 1 
						//                sprQ1.Text = "Shift Date" 
						//                sprQ1.Col = 2 
						ViewModel.sprQ1.Text = "Available for Training";
						CurrRow++;
						oCmd.CommandText = "spTraining_CQMissingOps '" + ClassID + "','" + StartDate + "','" + EndDate + "','" + ClassSdate + "','" + ClassEdate + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						if (!oRec.EOF)
						{
							DateHold = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
							BattHold = Convert.ToString(oRec["batt_code"]);
							if (BattHold == "1 ")
							{
								Qdesc = "Battalion 1- ";
							}
							else
							{
								Qdesc = "Battalion 2- ";
							}
							ViewModel.sprQ1.Row = CurrRow;
							ViewModel.sprQ1.Col = 1;
							ViewModel.sprQ1.Text = DateHold;
							//LineCount = 0;
						}

						while(!oRec.EOF)
						{
							if (DateHold != Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy"))
							{
								ViewModel.sprQ1.Row = CurrRow;
								ViewModel.sprQ1.Col = 2;
								ViewModel.sprQ1.Text = Qdesc;
								CurrRow++;
								DateHold = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
								ViewModel.sprQ1.Row = CurrRow;
								ViewModel.sprQ1.Col = 1;
								ViewModel.sprQ1.Text = DateHold;
								BattHold = Convert.ToString(oRec["batt_code"]);
								if (BattHold == "1 ")
								{
									Qdesc = "Battalion 1- ";
								}
								else
								{
									Qdesc = "Battalion 2- ";
								}
								Qdesc = Qdesc + Convert.ToString(oRec["name_full"]).Trim() + ", ";
							}
							else if (BattHold != Convert.ToString(oRec["batt_code"]))
							{
								ViewModel.sprQ1.Row = CurrRow;
								ViewModel.sprQ1.Col = 2;
								ViewModel.sprQ1.Text = Qdesc;
								CurrRow++;
								BattHold = Convert.ToString(oRec["batt_code"]);
								if (BattHold == "1 ")
								{
									Qdesc = "Battalion 1- ";
								}
								else
								{
									Qdesc = "Battalion 2- ";
								}
								Qdesc = Qdesc + Convert.ToString(oRec["name_full"]).Trim();
							}
							else
							{
								if (Strings.Len(Qdesc) + Strings.Len(Convert.ToString(oRec["name_full"]).Trim()) > 58)
								{
									ViewModel.sprQ1.Row = CurrRow;
									ViewModel.sprQ1.Col = 2;
									ViewModel.sprQ1.Text = Qdesc;
									CurrRow++;
									Qdesc = Convert.ToString(oRec["name_full"]).Trim() + ", ";
								}
								else
								{
									Qdesc = Qdesc + Convert.ToString(oRec["name_full"]).Trim() + ", ";
								}
							}
							oRec.MoveNext();
						}
						;
						ViewModel.sprQ1.Row = CurrRow;
						ViewModel.sprQ1.Col = 2;
						ViewModel.sprQ1.Text = Qdesc;
						CurrRow++;
						break;
					case 2 :
						//All Civilian Staff 
						oCmd.CommandText = "spTraining_CQMissingCiv '" + ClassID + "','" + StartDate + "','" + EndDate + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						while(!oRec.EOF)
						{
							ViewModel.sprQ1.Row = CurrRow;
							ViewModel.sprQ1.Col = 1;
							ViewModel.sprQ1.Text = Convert.ToString(oRec["name_full"]).Trim();
							ViewModel.sprQ1.Col = 2;
							ViewModel.sprQ1.Text = "40hr. Employee";
							oRec.MoveNext();
							CurrRow++;
						};
						break;
					case 3 :
						//Firefighters - Pilots 
						oCmd.CommandText = "spTraining_CQMissingByRank '" + ClassID + "','FF','PILOT','','','" + StartDate + "','" + EndDate + "','" + ClassSdate + "','" + ClassEdate + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						if (!oRec.EOF)
						{
							DateHold = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
							BattHold = Convert.ToString(oRec["battalion_code"]);
							if (BattHold == "1 ")
							{
								Qdesc = "Battalion 1- ";
							}
							else
							{
								Qdesc = "Battalion 2- ";
							}
							ViewModel.sprQ1.Row = CurrRow;
							ViewModel.sprQ1.Col = 1;
							ViewModel.sprQ1.Text = DateHold;
							//LineCount = 0;
						}

						while(!oRec.EOF)
						{
							if (DateHold != Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy"))
							{
								ViewModel.sprQ1.Row = CurrRow;
								ViewModel.sprQ1.Col = 2;
								ViewModel.sprQ1.Text = Qdesc;
								CurrRow++;
								DateHold = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
								ViewModel.sprQ1.Row = CurrRow;
								ViewModel.sprQ1.Col = 1;
								ViewModel.sprQ1.Text = DateHold;
								BattHold = Convert.ToString(oRec["battalion_code"]);
								if (BattHold == "1 ")
								{
									Qdesc = "Battalion 1- ";
								}
								else
								{
									Qdesc = "Battalion 2- ";
								}
								Qdesc = Qdesc + Convert.ToString(oRec["name_full"]).Trim() + ", ";
							}
							else if (BattHold != Convert.ToString(oRec["battalion_code"]))
							{
								ViewModel.sprQ1.Row = CurrRow;
								ViewModel.sprQ1.Col = 2;
								ViewModel.sprQ1.Text = Qdesc;
								CurrRow++;
								BattHold = Convert.ToString(oRec["battalion_code"]);
								if (BattHold == "1 ")
								{
									Qdesc = "Battalion 1- ";
								}
								else
								{
									Qdesc = "Battalion 2- ";
								}
								Qdesc = Qdesc + Convert.ToString(oRec["name_full"]).Trim();
							}
							else
							{
								if (Strings.Len(Qdesc) + Strings.Len(Convert.ToString(oRec["name_full"]).Trim()) > 58)
								{
									ViewModel.sprQ1.Row = CurrRow;
									ViewModel.sprQ1.Col = 2;
									ViewModel.sprQ1.Text = Qdesc;
									CurrRow++;
									Qdesc = Convert.ToString(oRec["name_full"]).Trim() + ", ";
								}
								else
								{
									Qdesc = Qdesc + Convert.ToString(oRec["name_full"]).Trim() + ", ";
								}
							}
							oRec.MoveNext();
						};
						ViewModel.sprQ1.Row = CurrRow;
						ViewModel.sprQ1.Col = 2;
						ViewModel.sprQ1.Text = Qdesc;
						CurrRow++;
						break;
					case 4 :
						//Paramedics - Paramedic Supervisors 
						oCmd.CommandText = "spTraining_CQMissingByRank '" + ClassID + "','FF/PM','PM SUPV','','','" + StartDate + "','" + EndDate + "','" + ClassSdate + "','" + ClassEdate + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						if (!oRec.EOF)
						{
							DateHold = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
							BattHold = Convert.ToString(oRec["battalion_code"]);
							if (BattHold == "1 ")
							{
								Qdesc = "Battalion 1- ";
							}
							else
							{
								Qdesc = "Battalion 2- ";
							}
							ViewModel.sprQ1.Row = CurrRow;
							ViewModel.sprQ1.Col = 1;
							ViewModel.sprQ1.Text = DateHold;
							//LineCount = 0;
						}

						while(!oRec.EOF)
						{
							if (DateHold != Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy"))
							{
								ViewModel.sprQ1.Row = CurrRow;
								ViewModel.sprQ1.Col = 2;
								ViewModel.sprQ1.Text = Qdesc;
								CurrRow++;
								DateHold = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
								ViewModel.sprQ1.Row = CurrRow;
								ViewModel.sprQ1.Col = 1;
								ViewModel.sprQ1.Text = DateHold;
								BattHold = Convert.ToString(oRec["battalion_code"]);
								if (BattHold == "1 ")
								{
									Qdesc = "Battalion 1- ";
								}
								else
								{
									Qdesc = "Battalion 2- ";
								}
								Qdesc = Qdesc + Convert.ToString(oRec["name_full"]).Trim() + ", ";
							}
							else if (BattHold != Convert.ToString(oRec["battalion_code"]))
							{
								ViewModel.sprQ1.Row = CurrRow;
								ViewModel.sprQ1.Col = 2;
								ViewModel.sprQ1.Text = Qdesc;
								CurrRow++;
								BattHold = Convert.ToString(oRec["battalion_code"]);
								if (BattHold == "1 ")
								{
									Qdesc = "Battalion 1- ";
								}
								else
								{
									Qdesc = "Battalion 2- ";
								}
								Qdesc = Qdesc + Convert.ToString(oRec["name_full"]).Trim();
							}
							else
							{
								if (Strings.Len(Qdesc) + Strings.Len(Convert.ToString(oRec["name_full"]).Trim()) > 58)
								{
									ViewModel.sprQ1.Row = CurrRow;
									ViewModel.sprQ1.Col = 2;
									ViewModel.sprQ1.Text = Qdesc;
									CurrRow++;
									Qdesc = Convert.ToString(oRec["name_full"]).Trim() + ", ";
								}
								else
								{
									Qdesc = Qdesc + Convert.ToString(oRec["name_full"]).Trim() + ", ";
								}
							}
							oRec.MoveNext();
						};
						ViewModel.sprQ1.Row = CurrRow;
						ViewModel.sprQ1.Col = 2;
						ViewModel.sprQ1.Text = Qdesc;
						CurrRow++;
						break;
					case 5 :
						//Dispatchers - Lt, Capt 
						oCmd.CommandText = "spTraining_CQMissingByRank '" + ClassID + "','LT DISP','CPT DISP','','','" + StartDate + "','" + EndDate + "','" + ClassSdate + "','" + ClassEdate + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						if (!oRec.EOF)
						{
							DateHold = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
							BattHold = Convert.ToString(oRec["battalion_code"]);
							if (BattHold == "1 ")
							{
								Qdesc = "Battalion 1- ";
							}
							else
							{
								Qdesc = "Battalion 2- ";
							}
							ViewModel.sprQ1.Row = CurrRow;
							ViewModel.sprQ1.Col = 1;
							ViewModel.sprQ1.Text = DateHold;
							//LineCount = 0;
						}

						while(!oRec.EOF)
						{
							if (DateHold != Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy"))
							{
								ViewModel.sprQ1.Row = CurrRow;
								ViewModel.sprQ1.Col = 2;
								ViewModel.sprQ1.Text = Qdesc;
								CurrRow++;
								DateHold = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
								ViewModel.sprQ1.Row = CurrRow;
								ViewModel.sprQ1.Col = 1;
								ViewModel.sprQ1.Text = DateHold;
								BattHold = Convert.ToString(oRec["battalion_code"]);
								if (BattHold == "1 ")
								{
									Qdesc = "Battalion 1- ";
								}
								else
								{
									Qdesc = "Battalion 2- ";
								}
								Qdesc = Qdesc + Convert.ToString(oRec["name_full"]).Trim() + ", ";
							}
							else if (BattHold != Convert.ToString(oRec["battalion_code"]))
							{
								ViewModel.sprQ1.Row = CurrRow;
								ViewModel.sprQ1.Col = 2;
								ViewModel.sprQ1.Text = Qdesc;
								CurrRow++;
								BattHold = Convert.ToString(oRec["battalion_code"]);
								if (BattHold == "1 ")
								{
									Qdesc = "Battalion 1- ";
								}
								else
								{
									Qdesc = "Battalion 2- ";
								}
								Qdesc = Qdesc + Convert.ToString(oRec["name_full"]).Trim();
							}
							else
							{
								if (Strings.Len(Qdesc) + Strings.Len(Convert.ToString(oRec["name_full"]).Trim()) > 58)
								{
									ViewModel.sprQ1.Row = CurrRow;
									ViewModel.sprQ1.Col = 2;
									ViewModel.sprQ1.Text = Qdesc;
									CurrRow++;
									Qdesc = Convert.ToString(oRec["name_full"]).Trim() + ", ";
								}
								else
								{
									Qdesc = Qdesc + Convert.ToString(oRec["name_full"]).Trim() + ", ";
								}
							}
							oRec.MoveNext();
						};
						ViewModel.sprQ1.Row = CurrRow;
						ViewModel.sprQ1.Col = 2;
						ViewModel.sprQ1.Text = Qdesc;
						CurrRow++;
						break;
					case 6 :
						//Inspectors 
						oCmd.CommandText = "spTraining_CQMissing40 '" + ClassID + "','FPB','" + StartDate + "','" + EndDate + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						while(!oRec.EOF)
						{
							ViewModel.sprQ1.Row = CurrRow;
							ViewModel.sprQ1.Col = 1;
							ViewModel.sprQ1.Text = Convert.ToString(oRec["name_full"]).Trim();
							ViewModel.sprQ1.Col = 2;
							ViewModel.sprQ1.Text = "40hr. Employee";
							oRec.MoveNext();
							CurrRow++;
						};
						break;
					case 7 :
						//Officers - Lt, Capt, Lt Disp, Cpt Disp 
						oCmd.CommandText = "spTraining_CQMissingByRank '" + ClassID + "','LT','CAPT','LT DISP','CPT DISP','" + StartDate + "','" + EndDate + "','" + ClassSdate + "','" + ClassEdate + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						if (!oRec.EOF)
						{
							DateHold = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
							BattHold = Convert.ToString(oRec["battalion_code"]);
							if (BattHold == "1 ")
							{
								Qdesc = "Battalion 1- ";
							}
							else
							{
								Qdesc = "Battalion 2- ";
							}
							ViewModel.sprQ1.Row = CurrRow;
							ViewModel.sprQ1.Col = 1;
							ViewModel.sprQ1.Text = DateHold;
							//LineCount = 0;
						}

						while(!oRec.EOF)
						{
							if (DateHold != Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy"))
							{
								ViewModel.sprQ1.Row = CurrRow;
								ViewModel.sprQ1.Col = 2;
								ViewModel.sprQ1.Text = Qdesc;
								CurrRow++;
								DateHold = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
								ViewModel.sprQ1.Row = CurrRow;
								ViewModel.sprQ1.Col = 1;
								ViewModel.sprQ1.Text = DateHold;
								BattHold = Convert.ToString(oRec["battalion_code"]);
								if (BattHold == "1 ")
								{
									Qdesc = "Battalion 1- ";
								}
								else
								{
									Qdesc = "Battalion 2- ";
								}
								Qdesc = Qdesc + Convert.ToString(oRec["name_full"]).Trim() + ", ";
							}
							else if (BattHold != Convert.ToString(oRec["battalion_code"]))
							{
								ViewModel.sprQ1.Row = CurrRow;
								ViewModel.sprQ1.Col = 2;
								ViewModel.sprQ1.Text = Qdesc;
								CurrRow++;
								BattHold = Convert.ToString(oRec["battalion_code"]);
								if (BattHold == "1 ")
								{
									Qdesc = "Battalion 1- ";
								}
								else
								{
									Qdesc = "Battalion 2- ";
								}
								Qdesc = Qdesc + Convert.ToString(oRec["name_full"]).Trim();
							}
							else
							{
								if (Strings.Len(Qdesc) + Strings.Len(Convert.ToString(oRec["name_full"]).Trim()) > 58)
								{
									ViewModel.sprQ1.Row = CurrRow;
									ViewModel.sprQ1.Col = 2;
									ViewModel.sprQ1.Text = Qdesc;
									CurrRow++;
									Qdesc = Convert.ToString(oRec["name_full"]).Trim() + ", ";
								}
								else
								{
									Qdesc = Qdesc + Convert.ToString(oRec["name_full"]).Trim() + ", ";
								}
							}
							oRec.MoveNext();
						};
						ViewModel.sprQ1.Row = CurrRow;
						ViewModel.sprQ1.Col = 2;
						ViewModel.sprQ1.Text = Qdesc;
						CurrRow++;
						break;
					case 8 :
						//Command Staff - BC,DC,ASST CHF,CHIEF 
						oCmd.CommandText = "spTraining_CQMissing40 '" + ClassID + "','HQ','" + StartDate + "','" + EndDate + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						while(!oRec.EOF)
						{
							ViewModel.sprQ1.Row = CurrRow;
							ViewModel.sprQ1.Col = 1;
							ViewModel.sprQ1.Text = Convert.ToString(oRec["name_full"]).Trim();
							ViewModel.sprQ1.Col = 2;
							ViewModel.sprQ1.Text = "40hr. Employee";
							oRec.MoveNext();
							CurrRow++;
						};
						CurrRow++;
						ViewModel.sprQ1.Row = CurrRow;
						ViewModel.sprQ1.Col = 1;
						ViewModel.sprQ1.Text = "Shift Date";
						ViewModel.sprQ1.Col = 2;
						ViewModel.sprQ1.Text = "Available for Training";
						CurrRow++;
						oCmd.CommandText = "spTraining_CQMissingByRank '" + ClassID + "','BC','','','','" + StartDate + "','" + EndDate + "','" + ClassSdate + "','" + ClassEdate + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						if (!oRec.EOF)
						{
							DateHold = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
							BattHold = Convert.ToString(oRec["battalion_code"]);
							if (BattHold == "1 ")
							{
								Qdesc = "Battalion 1- ";
							}
							else
							{
								Qdesc = "Battalion 2- ";
							}
							ViewModel.sprQ1.Row = CurrRow;
							ViewModel.sprQ1.Col = 1;
							ViewModel.sprQ1.Text = DateHold;
							//LineCount = 0;
						}

						while(!oRec.EOF)
						{
							if (DateHold != Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy"))
							{
								ViewModel.sprQ1.Row = CurrRow;
								ViewModel.sprQ1.Col = 2;
								ViewModel.sprQ1.Text = Qdesc;
								CurrRow++;
								DateHold = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
								ViewModel.sprQ1.Row = CurrRow;
								ViewModel.sprQ1.Col = 1;
								ViewModel.sprQ1.Text = DateHold;
								BattHold = Convert.ToString(oRec["battalion_code"]);
								if (BattHold == "1 ")
								{
									Qdesc = "Battalion 1- ";
								}
								else
								{
									Qdesc = "Battalion 2- ";
								}
								Qdesc = Qdesc + Convert.ToString(oRec["name_full"]).Trim() + ", ";
							}
							else if (BattHold != Convert.ToString(oRec["battalion_code"]))
							{
								ViewModel.sprQ1.Row = CurrRow;
								ViewModel.sprQ1.Col = 2;
								ViewModel.sprQ1.Text = Qdesc;
								CurrRow++;
								BattHold = Convert.ToString(oRec["battalion_code"]);
								if (BattHold == "1 ")
								{
									Qdesc = "Battalion 1- ";
								}
								else
								{
									Qdesc = "Battalion 2- ";
								}
								Qdesc = Qdesc + Convert.ToString(oRec["name_full"]).Trim();
							}
							else
							{
								if (Strings.Len(Qdesc) + Strings.Len(Convert.ToString(oRec["name_full"]).Trim()) > 58)
								{
									ViewModel.sprQ1.Row = CurrRow;
									ViewModel.sprQ1.Col = 2;
									ViewModel.sprQ1.Text = Qdesc;
									CurrRow++;
									Qdesc = Convert.ToString(oRec["name_full"]).Trim() + ", ";
								}
								else
								{
									Qdesc = Qdesc + Convert.ToString(oRec["name_full"]).Trim() + ", ";
								}
							}
							oRec.MoveNext();
						};
						ViewModel.sprQ1.Row = CurrRow;
						ViewModel.sprQ1.Col = 2;
						ViewModel.sprQ1.Text = Qdesc;
						CurrRow++;
						break;
				}

			}
			ViewModel.TotalRows = CurrRow;

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			//Load Classes Combobox
			ViewModel.cboClass.Items.Clear();
			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spTraining_ListByType 'CLS'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			while(!oRec.EOF)
			{
				ViewModel.cboClass.AddItem(Convert.ToString(oRec["description"]).Trim() + ": " + Convert.ToString(oRec["training_id"]));

				oRec.MoveNext();
			};
			ViewModel.TotalRows = 0;
			ViewModel.calStart.Text = "1/1/" + DateTime.Now.Year.ToString();

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmQclass DefInstance
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

		public static frmQclass CreateInstance()
		{
			PTSProject.frmQclass theInstance = Shared.Container.Resolve< frmQclass>();
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
			ViewModel.frmParam1.LifeCycleStartup();
			ViewModel.sprQ1.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.frmParam1.LifeCycleShutdown();
			ViewModel.sprQ1.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmQclass
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmQclassViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmQclass m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}