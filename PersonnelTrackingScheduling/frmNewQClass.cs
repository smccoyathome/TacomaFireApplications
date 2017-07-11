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

	public partial class frmNewQClass
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmNewQClassViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmNewQClass));
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


		private void frmNewQClass_Activated(System.Object eventSender, System.EventArgs eventArgs)
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
		internal void cboClass_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboClass.SelectedIndex == -1)
			{
				return;
			}
			ViewModel.cboClass.BackColor = modGlobal.Shared.WHITE;
			ViewModel.cboClass.ForeColor = modGlobal.Shared.BLACK;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboPrimary_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Load cboSecondary combobox
			PTSProject.clsTraining TrainCL = Container.Resolve< clsTraining>();

			if ( ViewModel.cboPrimary.SelectedIndex == -1)
			{
				return;
			}
			ViewModel.cboSecondary.Items.Clear();
			ViewModel.cboSecondary.SelectedIndex = -1;
			ViewModel.cboSecondary.BackColor = modGlobal.Shared.REQCOLOR;
			ViewModel.cboSecondary.ForeColor = modGlobal.Shared.WHITE;
			ViewModel.cboClass.Items.Clear();
			ViewModel.cboClass.SelectedIndex = -1;
			ViewModel.cboClass.BackColor = modGlobal.Shared.REQCOLOR;
			ViewModel.cboClass.ForeColor = modGlobal.Shared.WHITE;

			TrainCL.GetSecondaryCodes(ViewModel.cboPrimary.GetItemData(ViewModel.cboPrimary.SelectedIndex));

			while(!TrainCL.TrainingSecondaryCode.EOF)
			{
				ViewModel.cboSecondary.AddItem(modGlobal.Clean(TrainCL.TrainingSecondaryCode["description"]));
				ViewModel.cboSecondary.SetItemData(ViewModel.cboSecondary.GetNewIndex(), Convert.ToInt32(TrainCL.TrainingSecondaryCode["trn_secondary_code"]));
				TrainCL.TrainingSecondaryCode.MoveNext();
			}
			;
			ViewModel.cboPrimary.BackColor = modGlobal.Shared.WHITE;
			ViewModel.cboPrimary.ForeColor = modGlobal.Shared.BLACK;



		}

		[UpgradeHelpers.Events.Handler]
		internal void cboSecondary_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Load lst combobox
			PTSProject.clsTraining TrainCL = Container.Resolve< clsTraining>();

			if ( ViewModel.cboSecondary.SelectedIndex == -1)
			{
				return;
			}
			ViewModel.cboClass.Items.Clear();
			TrainCL.GetSpecificCodes(ViewModel.cboSecondary.GetItemData(ViewModel.cboSecondary.SelectedIndex));

			while(!TrainCL.TrainingSpecificCode.EOF)
			{
				ViewModel.cboClass.AddItem(modGlobal.Clean(TrainCL.TrainingSpecificCode["description"]));
				ViewModel.cboClass.SetItemData(ViewModel.cboClass.GetNewIndex(), Convert.ToInt32(TrainCL.TrainingSpecificCode["trn_specific_code"]));
				TrainCL.TrainingSpecificCode.MoveNext();
			}
			;
			ViewModel.cboSecondary.BackColor = modGlobal.Shared.WHITE;
			ViewModel.cboSecondary.ForeColor = modGlobal.Shared.BLACK;

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
			int ClassID = 0;
			int CurrRow = 0;
			//int LineCount = 0;

			//Check for Query Parameters
			if ( ViewModel.cboClass.SelectedIndex == -1)
			{
				ViewManager.ShowMessage("Please select a specific training type", "Class Query Message", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}
			else
			{
				ClassID = ViewModel.cboClass.GetItemData(ViewModel.cboClass.SelectedIndex);
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
				Qdesc = Qdesc + "attending " + modGlobal.Clean(ViewModel.cboClass.Text) + " ";
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
						oCmd.CommandText = "spTrainingNew_CQAttendance " + ClassID.ToString() + ",'" + StartDate + "','" + EndDate + "'";
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
						oCmd.CommandText = "spTrainingNew_CQAttendOps " + ClassID.ToString() + ",'" + StartDate + "','" + EndDate + "'";
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
						oCmd.CommandText = "spTrainingNew_CQAttendCiv " + ClassID.ToString() + ",'" + StartDate + "','" + EndDate + "'";
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
						oCmd.CommandText = "spTrainingNew_CQAttendByRank " + ClassID.ToString() + ",'" + StartDate + "','" + EndDate + "','FF'";
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
						oCmd.CommandText = "spTrainingNew_CQAttendByRank " + ClassID.ToString() + ",'" + StartDate + "','" + EndDate + "','PILOT'";
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
						oCmd.CommandText = "spTrainingNew_CQAttendByRank " + ClassID.ToString() + ",'" + StartDate + "','" + EndDate + "','FF/PM'";
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
						oCmd.CommandText = "spTrainingNew_CQAttendByRank " + ClassID.ToString() + ",'" + StartDate + "','" + EndDate + "','PM SUPV'";
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
						oCmd.CommandText = "spTrainingNew_CQAttendByRank " + ClassID.ToString() + ",'" + StartDate + "','" + EndDate + "','LT DISP'";
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
						oCmd.CommandText = "spTrainingNew_CQAttendByRank " + ClassID.ToString() + ",'" + StartDate + "','" + EndDate + "','CPT DISP'";
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
						oCmd.CommandText = "spTrainingNew_CQAttend40 " + ClassID.ToString() + ",'FPB','" + StartDate + "','" + EndDate + "'";
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
						oCmd.CommandText = "spTrainingNew_CQAttendByRank " + ClassID.ToString() + ",'" + StartDate + "','" + EndDate + "','LT'";
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
						oCmd.CommandText = "spTrainingNew_CQAttendByRank " + ClassID.ToString() + ",'" + StartDate + "','" + EndDate + "','CAPT'";
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
						oCmd.CommandText = "spTrainingNew_CQAttendByRank " + ClassID.ToString() + ",'" + StartDate + "','" + EndDate + "','CPT DISP'";
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
						oCmd.CommandText = "spTrainingNew_CQAttendByRank " + ClassID.ToString() + ",'" + StartDate + "','" + EndDate + "','LT DISP'";
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
						oCmd.CommandText = "spTrainingNew_CQAttendByRank " + ClassID.ToString() + ",'" + StartDate + "','" + EndDate + "','BC'";
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
						oCmd.CommandText = "spTrainingNew_CQAttendByRank " + ClassID.ToString() + ",'" + StartDate + "','" + EndDate + "','DEP FM'";
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
						oCmd.CommandText = "spTrainingNew_CQAttendByRank " + ClassID.ToString() + ",'" + StartDate + "','" + EndDate + "','ASST CHF'";
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
						oCmd.CommandText = "spTrainingNew_CQAttendByRank " + ClassID.ToString() + ",'" + StartDate + "','" + EndDate + "','DC'";
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
						oCmd.CommandText = "spTrainingNew_CQAttendByRank " + ClassID.ToString() + ",'" + StartDate + "','" + EndDate + "','CHIEF'";
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
				Qdesc = Qdesc + "missing " + modGlobal.Clean(ViewModel.cboClass.Text) + " ";
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
						oCmd.CommandText = "spTrainingNew_CQMissing40Ops " + ClassID.ToString() + ",'" + StartDate + "','" + EndDate + "'";
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
						oCmd.CommandText = "spTrainingNew_CQMissingCiv '" + ClassID.ToString() + "','" + StartDate + "','" + EndDate + "'";
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
						oCmd.CommandText = "spTrainingNew_CQMissingOps '" + ClassID.ToString() + "','" + StartDate + "','" + EndDate + "','" + ClassSdate + "','" + ClassEdate + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						if (!oRec.EOF)
						{
							DateHold = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
							BattHold = Convert.ToString(oRec["batt_code"]);
							if (BattHold == "1 ")
							{
								Qdesc = "181- ";
							}
							else
							{
								Qdesc = "182- ";
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
									Qdesc = "181- ";
								}
								else
								{
									Qdesc = "182- ";
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
									Qdesc = "181- ";
								}
								else
								{
									Qdesc = "182- ";
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
						//                ocmd.CommandText = "spTrainingNew_CQMissing40Ops " & ClassID & ",'" & StartDate & "','" & EndDate & "'" 
						//                Set orec = ocmd.Execute 
						//                Do Until orec.EOF 
						//                    sprQ1.Row = CurrRow 
						//                    sprQ1.Col = 1 
						//                    sprQ1.Text = Trim$(orec("name_full"]) 
						//                    sprQ1.Col = 2 
						//                    sprQ1.Text = "40hr. Employee" 
						//                    orec.MoveNext 
						//                    CurrRow = CurrRow + 1 
						//                Loop 
						//                CurrRow = CurrRow + 1 
						//                sprQ1.Row = CurrRow 
						//                sprQ1.Col = 1 
						//                sprQ1.Text = "Shift Date" 
						//                sprQ1.Col = 2 
						//                sprQ1.Text = "Available for Training" 
						//                CurrRow = CurrRow + 1 
						oCmd.CommandText = "spTrainingNew_CQMissingOps " + ClassID.ToString() + ",'" + StartDate + "','" + EndDate + "','" + ClassSdate + "','" + ClassEdate + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						if (!oRec.EOF)
						{
							DateHold = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
							BattHold = Convert.ToString(oRec["batt_code"]);
							if (BattHold == "1 ")
							{
								Qdesc = "181- ";
							}
							else
							{
								Qdesc = "182- ";
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
									Qdesc = "181- ";
								}
								else
								{
									Qdesc = "182- ";
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
									Qdesc = "181- ";
								}
								else
								{
									Qdesc = "182- ";
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
					case 2 :
						//All Civilian Staff 
						oCmd.CommandText = "spTrainingNew_CQMissingCiv " + ClassID.ToString() + ",'" + StartDate + "','" + EndDate + "'";
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
						oCmd.CommandText = "spTrainingNew_CQMissingByRank " + ClassID.ToString() + ",'FF','PILOT','','','" + StartDate + "','" + EndDate + "','" + ClassSdate + "','" + ClassEdate + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						if (!oRec.EOF)
						{
							DateHold = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
							BattHold = Convert.ToString(oRec["battalion_code"]);
							if (BattHold == "1 ")
							{
								Qdesc = "181- ";
							}
							else
							{
								Qdesc = "182- ";
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
									Qdesc = "181- ";
								}
								else
								{
									Qdesc = "182- ";
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
									Qdesc = "181- ";
								}
								else
								{
									Qdesc = "182- ";
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
						oCmd.CommandText = "spTrainingNew_CQMissingByRank " + ClassID.ToString() + ",'FF/PM','PM SUPV','','','" + StartDate + "','" + EndDate + "','" + ClassSdate + "','" + ClassEdate + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						if (!oRec.EOF)
						{
							DateHold = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
							BattHold = Convert.ToString(oRec["battalion_code"]);
							if (BattHold == "1 ")
							{
								Qdesc = "181- ";
							}
							else
							{
								Qdesc = "182- ";
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
									Qdesc = "181- ";
								}
								else
								{
									Qdesc = "182- ";
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
									Qdesc = "181- ";
								}
								else
								{
									Qdesc = "182- ";
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
						oCmd.CommandText = "spTrainingNew_CQMissingByRank " + ClassID.ToString() + ",'LT DISP','CPT DISP','','','" + StartDate + "','" + EndDate + "','" + ClassSdate + "','" + ClassEdate + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						if (!oRec.EOF)
						{
							DateHold = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
							BattHold = Convert.ToString(oRec["battalion_code"]);
							if (BattHold == "1 ")
							{
								Qdesc = "181- ";
							}
							else
							{
								Qdesc = "182- ";
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
									Qdesc = "181- ";
								}
								else
								{
									Qdesc = "182- ";
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
									Qdesc = "181- ";
								}
								else
								{
									Qdesc = "182- ";
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
						oCmd.CommandText = "spTrainingNew_CQMissing40 " + ClassID.ToString() + ",'FPB','" + StartDate + "','" + EndDate + "'";
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
						oCmd.CommandText = "spTrainingNew_CQMissingByRank " + ClassID.ToString() + ",'LT','CAPT','LT DISP','CPT DISP','" + StartDate + "','" + EndDate + "','" + ClassSdate + "','" + ClassEdate + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						if (!oRec.EOF)
						{
							DateHold = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
							BattHold = Convert.ToString(oRec["battalion_code"]);
							if (BattHold == "1 ")
							{
								Qdesc = "181- ";
							}
							else
							{
								Qdesc = "182- ";
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
									Qdesc = "181- ";
								}
								else
								{
									Qdesc = "182- ";
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
									Qdesc = "181- ";
								}
								else
								{
									Qdesc = "182- ";
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
						oCmd.CommandText = "spTrainingNew_CQMissing40 " + ClassID.ToString() + ",'HQ','" + StartDate + "','" + EndDate + "'";
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
						oCmd.CommandText = "spTrainingNew_CQMissingByRank " + ClassID.ToString() + ",'BC','','','','" + StartDate + "','" + EndDate + "','" + ClassSdate + "','" + ClassEdate + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						if (!oRec.EOF)
						{
							DateHold = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
							BattHold = Convert.ToString(oRec["battalion_code"]);
							if (BattHold == "1 ")
							{
								Qdesc = "181- ";
							}
							else
							{
								Qdesc = "182- ";
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
									Qdesc = "181- ";
								}
								else
								{
									Qdesc = "182- ";
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
									Qdesc = "181- ";
								}
								else
								{
									Qdesc = "182- ";
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

			//    Dim ocmd As New ADODB.Command
			//    Dim orec As ADODB.Recordset
			PTSProject.clsTraining TrainCL = Container.Resolve< clsTraining>();
			ViewModel.cboPrimary.Items.Clear();
			TrainCL.GetPrimaryCodes();

			while(!TrainCL.TrainingPrimaryCode.EOF)
			{
				ViewModel.cboPrimary.AddItem(modGlobal.Clean(TrainCL.TrainingPrimaryCode["description"]));
				ViewModel.cboPrimary.SetItemData(ViewModel.cboPrimary.GetNewIndex(), Convert.ToInt32(TrainCL.TrainingPrimaryCode["trn_primary_code"]));
				TrainCL.TrainingPrimaryCode.MoveNext();
			}
			;
			ViewModel.cboPrimary.Text = "";
			ViewModel.cboPrimary.SelectedIndex = -1;
			ViewModel.cboPrimary.BackColor = modGlobal.Shared.REQCOLOR;
			ViewModel.cboPrimary.ForeColor = modGlobal.Shared.WHITE;
			ViewModel.cboSecondary.Text = "";
			ViewModel.cboSecondary.Items.Clear();
			ViewModel.cboSecondary.BackColor = modGlobal.Shared.REQCOLOR;
			ViewModel.cboSecondary.ForeColor = modGlobal.Shared.WHITE;
			ViewModel.cboClass.Items.Clear();
			ViewModel.cboClass.BackColor = modGlobal.Shared.REQCOLOR;
			ViewModel.cboClass.ForeColor = modGlobal.Shared.WHITE;
			ViewModel.TotalRows = 0;
			ViewModel.calStart.Text = "1/1/" + DateTime.Now.Year.ToString();

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmNewQClass DefInstance
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

		public static frmNewQClass CreateInstance()
		{
			PTSProject.frmNewQClass theInstance = Shared.Container.Resolve< frmNewQClass>();
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

	public partial class frmNewQClass
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmNewQClassViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmNewQClass m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}