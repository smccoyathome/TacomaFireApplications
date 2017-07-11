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

	public partial class frmIndTrainReport
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmIndTrainReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmIndTrainReport));
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


		private void frmIndTrainReport_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		public void LoadList()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ViewModel.cboEmployee.Text = "";
			ViewModel.cboEmployee.Items.Clear();

			//Load Employee Name combobox
			oCmd.Connection = modGlobal.oConn;

			if ( ViewModel.chkInactive.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				oCmd.CommandText = "spArchiveNameList";
			}
			else
			{
				if (modGlobal.Shared.gSecurity == "ADM")
				{
					oCmd.CommandText = "spFullNameList";
				}
				else
				{
					oCmd.CommandText = "spOpNameListForField";
				}
			}

			oCmd.CommandType = CommandType.Text;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			while (!oRec.EOF)
			{
				ViewModel.cboEmployee.AddItem(Convert.ToString(oRec["name_full"]).Trim() + " - " + Convert.ToString(oRec["employee_id"]));
				oRec.MoveNext();
			}

		}

		public void ClearGrid()
		{
			if ( ViewModel.TotalRows == 0)
			{
				return;
			}
			ViewModel.sprInd.BlockMode = true;
			ViewModel.sprInd.Row = 6;
			ViewModel.sprInd.Row2 = ViewModel.TotalRows;
			ViewModel.sprInd.Col = 1;
			ViewModel.sprInd.Col2 = 6;
			//ViewModel.sprInd.Action = (FarPoint.ViewModels.FPActionConstants) 12; //Clear Text

			ViewModel.sprInd.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprInd.BlockMode = false;
			ViewModel.sprInd.Col = 5;
			ViewModel.sprInd.Row = 2;
			ViewModel.sprInd.Text = "";

		}

		public void GetYearSummary()
		{
			//Fill Grid with Yearly Summary Data for Current Employee
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			int CurrYear = 0;
			string CurrPrimaryType = "";
			string CurrSecondaryDesc = "";

			int C1 = 0;
			int C2 = 0;
			int C3 = 0;
			float H1 = 0;
			float H2 = 0;
			float H3 = 0;

			oCmd.Connection = modGlobal.oConn;
			string SqlString = "spTrainingNew_ReportIndbyYearSNew '" + ViewModel.CurrEmp + "','";
			SqlString = SqlString + DateTime.Parse(ViewModel.dtStart.Text).ToString("MM/dd/yyyy") + "','" + DateTime.Parse(ViewModel.dtEnd.Text).ToString("MM/dd/yyyy") + "'";
			if ( ViewModel.cboPrimary.ListIndex == -1)
			{
				SqlString = SqlString + ", NULL,";
			}
			else
			{
				//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboPrimary.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				SqlString = SqlString + "," + ViewModel.cboPrimary.ItemData(ViewModel.cboPrimary.ListIndex).ToString() + ",";
			}
			if ( ViewModel.cboSecondary.ListIndex == -1)
			{
				SqlString = SqlString + " NULL,";
			}
			else
			{
				//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboSecondary.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				SqlString = SqlString + ViewModel.cboSecondary.ItemData(ViewModel.cboSecondary.ListIndex).ToString() + ",";
			}
			if ( ViewModel.lSpecificID == 0)
			{
				SqlString = SqlString + " NULL ";
			}
			else
			{
				SqlString = SqlString + ViewModel.lSpecificID.ToString() + " ";
			}

			oCmd.CommandText = SqlString;
			oCmd.CommandType = CommandType.Text;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			int CurrRow = 6;

			while(!oRec.EOF)
			{
				ViewModel.sprInd.Row = CurrRow;
				if (Convert.ToDouble(oRec["training_year"]) != CurrYear)
				{
					if (CurrYear != 0)
					{
						//Totals for Secondary Description
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Text = "Total for " + CurrYear.ToString() + "-" + CurrSecondaryDesc;
						ViewModel.sprInd.Col = 5;
						ViewModel.sprInd.Text = C3.ToString();
						C2 += C3;
						C3 = 0;
						ViewModel.sprInd.Col = 6;
						ViewModel.sprInd.Text = H3.ToString();
						H2 += H3;
						H3 = 0;
						ViewModel.sprInd.BlockMode = true;
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Col2 = 6;
						ViewModel.sprInd.Row2 = CurrRow;
						ViewModel.sprInd.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.PEACH);
						ViewModel.sprInd.BlockMode = false;
						CurrRow++;
						ViewModel.sprInd.Row = CurrRow;
						CurrSecondaryDesc = Convert.ToString(oRec["secondary_description"]);
						//Totals for Primary Type
						ViewModel.sprInd.Col = 2;
						ViewModel.sprInd.Text = "Total for " + CurrYear.ToString() + "-" + CurrPrimaryType;
						ViewModel.sprInd.Col = 5;
						ViewModel.sprInd.Text = C2.ToString();
						C1 += C2;
						C2 = 0;
						ViewModel.sprInd.Col = 6;
						ViewModel.sprInd.Text = H2.ToString();
						H1 += H2;
						H2 = 0;
						ViewModel.sprInd.BlockMode = true;
						ViewModel.sprInd.Col = 2;
						ViewModel.sprInd.Col2 = 6;
						ViewModel.sprInd.Row2 = CurrRow;
						ViewModel.sprInd.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.PEACH);
						ViewModel.sprInd.BlockMode = false;
						CurrRow++;
						ViewModel.sprInd.Row = CurrRow;
						CurrPrimaryType = Convert.ToString(oRec["primary_description"]);
						//Totals for this Year
						ViewModel.sprInd.Col = 1;
						ViewModel.sprInd.Text = "Total for " + CurrYear.ToString();
						ViewModel.sprInd.Col = 5;
						ViewModel.sprInd.Text = C1.ToString();
						C1 = 0;
						ViewModel.sprInd.Col = 6;
						ViewModel.sprInd.Text = H1.ToString();
						H1 = 0;
						ViewModel.sprInd.BlockMode = true;
						ViewModel.sprInd.Col = 1;
						ViewModel.sprInd.Col2 = 6;
						ViewModel.sprInd.Row2 = CurrRow;
						ViewModel.sprInd.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.PUMPKIN);
						ViewModel.sprInd.BlockMode = false;
						CurrRow += 2;
						ViewModel.sprInd.Row = CurrRow;
						ViewModel.sprInd.Col = 1;
						ViewModel.sprInd.Text = Convert.ToString(oRec["training_year"]);
						CurrYear = Convert.ToInt32(oRec["training_year"]);
						ViewModel.sprInd.Col = 2;
						ViewModel.sprInd.Text = CurrPrimaryType;
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Text = CurrSecondaryDesc;
					}
					else
					{
						ViewModel.sprInd.Col = 1;
						ViewModel.sprInd.Text = Convert.ToString(oRec["training_year"]);
						CurrYear = Convert.ToInt32(oRec["training_year"]);
						ViewModel.sprInd.Col = 2;
						ViewModel.sprInd.Text = Convert.ToString(oRec["primary_description"]);
						CurrPrimaryType = Convert.ToString(oRec["primary_description"]);
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Text = Convert.ToString(oRec["secondary_description"]);
						CurrSecondaryDesc = Convert.ToString(oRec["secondary_description"]);
					}
				}
				else if (Convert.ToString(oRec["primary_description"]) != CurrPrimaryType)
				{
					if (CurrPrimaryType != "")
					{
						//Totals for Secondary Description
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Text = "Total for " + CurrYear.ToString() + "-" + CurrSecondaryDesc;
						ViewModel.sprInd.Col = 5;
						ViewModel.sprInd.Text = C3.ToString();
						C2 += C3;
						C3 = 0;
						ViewModel.sprInd.Col = 6;
						ViewModel.sprInd.Text = H3.ToString();
						H2 += H3;
						H3 = 0;
						ViewModel.sprInd.BlockMode = true;
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Col2 = 6;
						ViewModel.sprInd.Row2 = CurrRow;
						ViewModel.sprInd.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.PEACH);
						ViewModel.sprInd.BlockMode = false;
						CurrRow++;
						ViewModel.sprInd.Row = CurrRow;
						CurrSecondaryDesc = Convert.ToString(oRec["secondary_description"]);
						//Totals for Primary Type
						ViewModel.sprInd.Col = 2;
						ViewModel.sprInd.Text = "Total for " + CurrYear.ToString() + "-" + CurrPrimaryType;
						ViewModel.sprInd.Col = 5;
						ViewModel.sprInd.Text = C2.ToString();
						C1 += C2;
						C2 = 0;
						ViewModel.sprInd.Col = 6;
						ViewModel.sprInd.Text = H2.ToString();
						H1 += H2;
						H2 = 0;
						ViewModel.sprInd.BlockMode = true;
						ViewModel.sprInd.Col = 2;
						ViewModel.sprInd.Col2 = 6;
						ViewModel.sprInd.Row2 = CurrRow;
						ViewModel.sprInd.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.PEACH);
						ViewModel.sprInd.BlockMode = false;
						CurrRow++;
						ViewModel.sprInd.Row = CurrRow;
						ViewModel.sprInd.Col = 2;
						ViewModel.sprInd.Text = Convert.ToString(oRec["primary_description"]);
						CurrPrimaryType = Convert.ToString(oRec["primary_description"]);
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Text = Convert.ToString(oRec["secondary_description"]);
						CurrSecondaryDesc = Convert.ToString(oRec["secondary_description"]);
					}
				}
				else if (Convert.ToString(oRec["secondary_description"]) != CurrSecondaryDesc)
				{
					if (CurrSecondaryDesc != "")
					{
						//Totals for Secondary Description
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Text = "Total for " + CurrYear.ToString() + "-" + CurrSecondaryDesc;
						ViewModel.sprInd.Col = 5;
						ViewModel.sprInd.Text = C3.ToString();
						C2 += C3;
						C3 = 0;
						ViewModel.sprInd.Col = 6;
						ViewModel.sprInd.Text = H3.ToString();
						H2 += H3;
						H3 = 0;
						ViewModel.sprInd.BlockMode = true;
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Col2 = 6;
						ViewModel.sprInd.Row2 = CurrRow;
						ViewModel.sprInd.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.PEACH);
						ViewModel.sprInd.BlockMode = false;
						CurrRow++;
						ViewModel.sprInd.Row = CurrRow;
						ViewModel.sprInd.Text = Convert.ToString(oRec["secondary_description"]);
						CurrSecondaryDesc = Convert.ToString(oRec["secondary_description"]);
					}
				}
				ViewModel.sprInd.Col = 4;
				ViewModel.sprInd.Text = Convert.ToString(oRec["specific_description"]);
				ViewModel.sprInd.Col = 5;
				ViewModel.sprInd.Text = Convert.ToString(oRec["total_classes"]);
				C3 = Convert.ToInt32(C3 + Convert.ToDouble(oRec["total_classes"]));
				ViewModel.sprInd.Col = 6;
				ViewModel.sprInd.Text = Convert.ToString(oRec["total_hours"]);
				H3 = (float) (H3 + Convert.ToDouble(oRec["total_hours"]));
				oRec.MoveNext();
				CurrRow++;
			};

			//Totals for Secondary Description
			ViewModel.sprInd.Row = CurrRow;
			ViewModel.sprInd.Col = 3;
			ViewModel.sprInd.Text = "Total for " + CurrYear.ToString() + "-" + CurrSecondaryDesc;
			ViewModel.sprInd.Col = 5;
			ViewModel.sprInd.Text = C3.ToString();
			C2 += C3;
			ViewModel.sprInd.Col = 6;
			ViewModel.sprInd.Text = H3.ToString();
			H2 += H3;
			ViewModel.sprInd.BlockMode = true;
			ViewModel.sprInd.Col = 3;
			ViewModel.sprInd.Col2 = 6;
			ViewModel.sprInd.Row2 = CurrRow;
			ViewModel.sprInd.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.PEACH);
			ViewModel.sprInd.BlockMode = false;
			CurrRow++;
			ViewModel.sprInd.Row = CurrRow;
			//Totals for Primary Type
			ViewModel.sprInd.Col = 2;
			ViewModel.sprInd.Text = "Total for " + CurrYear.ToString() + "-" + CurrPrimaryType;
			ViewModel.sprInd.Col = 5;
			ViewModel.sprInd.Text = C2.ToString();
			C1 += C2;
			ViewModel.sprInd.Col = 6;
			ViewModel.sprInd.Text = H2.ToString();
			H1 += H2;
			ViewModel.sprInd.BlockMode = true;
			ViewModel.sprInd.Col = 2;
			ViewModel.sprInd.Col2 = 6;
			ViewModel.sprInd.Row2 = CurrRow;
			ViewModel.sprInd.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.PEACH);
			ViewModel.sprInd.BlockMode = false;
			CurrRow++;
			ViewModel.sprInd.Row = CurrRow;
			//Totals for this Year
			ViewModel.sprInd.Col = 1;
			ViewModel.sprInd.Text = "Total for " + CurrYear.ToString();
			ViewModel.sprInd.Col = 5;
			ViewModel.sprInd.Text = C1.ToString();
			ViewModel.sprInd.Col = 6;
			ViewModel.sprInd.Text = H1.ToString();
			ViewModel.sprInd.BlockMode = true;
			ViewModel.sprInd.Col = 1;
			ViewModel.sprInd.Col2 = 6;
			ViewModel.sprInd.Row2 = CurrRow;
			ViewModel.sprInd.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.PUMPKIN);
			ViewModel.sprInd.BlockMode = false;
			ViewModel.TotalRows = CurrRow;


		}

		public void GetTypeSummary()
		{
			//Fill Grid with Type Summary Data for Current Employee
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string CurrPrimaryType = "";
			string CurrSecondaryDesc = "";
			string CurrSpecificDesc = "";

			int C1 = 0;
			int C2 = 0;
			int C3 = 0;
			float H1 = 0;
			float H2 = 0;
			float H3 = 0;


			oCmd.Connection = modGlobal.oConn;
			string SqlString = "spTrainingNew_ReportIndbyTypeSNew '" + ViewModel.CurrEmp + "','";
			SqlString = SqlString + DateTime.Parse(ViewModel.dtStart.Text).ToString("MM/dd/yyyy") + "','" + DateTime.Parse(ViewModel.dtEnd.Text).ToString("MM/dd/yyyy") + "'";
			if ( ViewModel.cboPrimary.ListIndex == -1)
			{
				SqlString = SqlString + ", NULL,";
			}
			else
			{
				//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboPrimary.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				SqlString = SqlString + "," + ViewModel.cboPrimary.ItemData(ViewModel.cboPrimary.ListIndex).ToString() + ",";
			}
			if ( ViewModel.cboSecondary.ListIndex == -1)
			{
				SqlString = SqlString + " NULL,";
			}
			else
			{
				//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboSecondary.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				SqlString = SqlString + ViewModel.cboSecondary.ItemData(ViewModel.cboSecondary.ListIndex).ToString() + ",";
			}
			if ( ViewModel.lSpecificID == 0)
			{
				SqlString = SqlString + " NULL ";
			}
			else
			{
				SqlString = SqlString + ViewModel.lSpecificID.ToString() + " ";
			}

			oCmd.CommandText = SqlString;
			oCmd.CommandType = CommandType.Text;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			int CurrRow = 6;

			while(!oRec.EOF)
			{
				ViewModel.sprInd.Row = CurrRow;
				if (Convert.ToString(oRec["primary_description"]) != CurrPrimaryType)
				{
					if (CurrPrimaryType != "")
					{
						//Totals for Current Specific Description
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Text = "Total for " + CurrPrimaryType + "-" + CurrSpecificDesc;
						ViewModel.sprInd.Col = 5;
						ViewModel.sprInd.Text = C3.ToString();
						C2 += C3;
						C3 = 0;
						ViewModel.sprInd.Col = 6;
						ViewModel.sprInd.Text = H3.ToString();
						H2 += H3;
						H3 = 0;
						ViewModel.sprInd.BlockMode = true;
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Col2 = 6;
						ViewModel.sprInd.Row2 = CurrRow;
						ViewModel.sprInd.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.PEACH);
						ViewModel.sprInd.BlockMode = false;
						CurrRow++;
						ViewModel.sprInd.Row = CurrRow;
						CurrSpecificDesc = Convert.ToString(oRec["specific_description"]);
						//Totals for Current Secondary Description
						ViewModel.sprInd.Col = 2;
						ViewModel.sprInd.Text = "Total for " + CurrPrimaryType + "-" + CurrSecondaryDesc;
						ViewModel.sprInd.Col = 5;
						ViewModel.sprInd.Text = C2.ToString();
						C1 += C2;
						C2 = 0;
						ViewModel.sprInd.Col = 6;
						ViewModel.sprInd.Text = H2.ToString();
						H1 += H2;
						H2 = 0;
						ViewModel.sprInd.BlockMode = true;
						ViewModel.sprInd.Col = 2;
						ViewModel.sprInd.Col2 = 6;
						ViewModel.sprInd.Row2 = CurrRow;
						ViewModel.sprInd.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.PEACH);
						ViewModel.sprInd.BlockMode = false;
						CurrRow++;
						ViewModel.sprInd.Row = CurrRow;
						CurrSecondaryDesc = Convert.ToString(oRec["secondary_description"]);
						//Totals for this Primary Type
						ViewModel.sprInd.Col = 1;
						ViewModel.sprInd.Text = "Total for " + CurrPrimaryType;
						ViewModel.sprInd.Col = 5;
						ViewModel.sprInd.Text = C1.ToString();
						C1 = 0;
						ViewModel.sprInd.Col = 6;
						ViewModel.sprInd.Text = H1.ToString();
						H1 = 0;
						ViewModel.sprInd.BlockMode = true;
						ViewModel.sprInd.Col = 1;
						ViewModel.sprInd.Col2 = 6;
						ViewModel.sprInd.Row2 = CurrRow;
						ViewModel.sprInd.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.PUMPKIN);
						ViewModel.sprInd.BlockMode = false;
						CurrRow += 2;
						ViewModel.sprInd.Row = CurrRow;
						ViewModel.sprInd.Col = 1;
						ViewModel.sprInd.Text = Convert.ToString(oRec["primary_description"]);
						CurrPrimaryType = Convert.ToString(oRec["primary_description"]);
						ViewModel.sprInd.Col = 2;
						ViewModel.sprInd.Text = CurrSecondaryDesc;
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Text = CurrSpecificDesc;
					}
					else
					{
						ViewModel.sprInd.Col = 1;
						ViewModel.sprInd.Text = Convert.ToString(oRec["primary_description"]);
						CurrPrimaryType = Convert.ToString(oRec["primary_description"]);
						ViewModel.sprInd.Col = 2;
						ViewModel.sprInd.Text = Convert.ToString(oRec["secondary_description"]);
						CurrSecondaryDesc = Convert.ToString(oRec["secondary_description"]);
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Text = Convert.ToString(oRec["specific_description"]);
						CurrSpecificDesc = Convert.ToString(oRec["specific_description"]);
					}
				}
				else if (Convert.ToString(oRec["secondary_description"]) != CurrSecondaryDesc)
				{
					if (CurrSecondaryDesc != "")
					{
						//Totals for This Specific Description
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Text = "Total for " + CurrPrimaryType + "-" + CurrSpecificDesc;
						ViewModel.sprInd.Col = 5;
						ViewModel.sprInd.Text = C3.ToString();
						C2 += C3;
						C3 = 0;
						ViewModel.sprInd.Col = 6;
						ViewModel.sprInd.Text = H3.ToString();
						H2 += H3;
						H3 = 0;
						ViewModel.sprInd.BlockMode = true;
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Col2 = 6;
						ViewModel.sprInd.Row2 = CurrRow;
						ViewModel.sprInd.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.PEACH);
						ViewModel.sprInd.BlockMode = false;
						CurrRow++;
						ViewModel.sprInd.Row = CurrRow;
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Text = Convert.ToString(oRec["specific_description"]);
						CurrSpecificDesc = Convert.ToString(oRec["specific_description"]);
						//Totals for This Secondary Description
						ViewModel.sprInd.Col = 2;
						ViewModel.sprInd.Text = "Total for " + CurrPrimaryType + "-" + CurrSecondaryDesc;
						ViewModel.sprInd.Col = 5;
						ViewModel.sprInd.Text = C2.ToString();
						C1 += C2;
						C2 = 0;
						ViewModel.sprInd.Col = 6;
						ViewModel.sprInd.Text = H2.ToString();
						H1 += H2;
						H2 = 0;
						ViewModel.sprInd.BlockMode = true;
						ViewModel.sprInd.Col = 2;
						ViewModel.sprInd.Col2 = 6;
						ViewModel.sprInd.Row2 = CurrRow;
						ViewModel.sprInd.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.PEACH);
						ViewModel.sprInd.BlockMode = false;
						CurrRow++;
						ViewModel.sprInd.Row = CurrRow;
						ViewModel.sprInd.Col = 2;
						ViewModel.sprInd.Text = Convert.ToString(oRec["secondary_description"]);
						CurrSecondaryDesc = Convert.ToString(oRec["secondary_description"]);
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Text = Convert.ToString(oRec["specific_description"]);
						CurrSecondaryDesc = Convert.ToString(oRec["specific_description"]);
					}
				}
				else if (Convert.ToString(oRec["specific_description"]) != CurrSpecificDesc)
				{
					if (CurrSpecificDesc != "")
					{
						//Totals for This Specific Description
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Text = "Total for " + CurrPrimaryType + "-" + CurrSpecificDesc;
						ViewModel.sprInd.Col = 5;
						ViewModel.sprInd.Text = C3.ToString();
						C2 += C3;
						C3 = 0;
						ViewModel.sprInd.Col = 6;
						ViewModel.sprInd.Text = H3.ToString();
						H2 += H3;
						H3 = 0;
						ViewModel.sprInd.BlockMode = true;
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Col2 = 6;
						ViewModel.sprInd.Row2 = CurrRow;
						ViewModel.sprInd.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.PEACH);
						ViewModel.sprInd.BlockMode = false;
						CurrRow++;
						ViewModel.sprInd.Row = CurrRow;
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Text = Convert.ToString(oRec["specific_description"]);
						CurrSpecificDesc = Convert.ToString(oRec["specific_description"]);
					}
				}
				ViewModel.sprInd.Col = 4;
				ViewModel.sprInd.Text = Convert.ToString(oRec["training_year"]);
				ViewModel.sprInd.Col = 5;
				ViewModel.sprInd.Text = Convert.ToString(oRec["total_classes"]);
				C3 = Convert.ToInt32(C3 + Convert.ToDouble(oRec["total_classes"]));
				ViewModel.sprInd.Col = 6;
				ViewModel.sprInd.Text = Convert.ToString(oRec["total_hours"]);
				H3 = (float) (H3 + Convert.ToDouble(oRec["total_hours"]));
				oRec.MoveNext();
				CurrRow++;
			};
			ViewModel.sprInd.Row = CurrRow;
			//Totals for Current Specific Description
			ViewModel.sprInd.Col = 3;
			ViewModel.sprInd.Text = "Total for " + CurrPrimaryType + "-" + CurrSpecificDesc;
			ViewModel.sprInd.Col = 5;
			ViewModel.sprInd.Text = C3.ToString();
			C2 += C3;
			ViewModel.sprInd.Col = 6;
			ViewModel.sprInd.Text = H3.ToString();
			H2 += H3;
			ViewModel.sprInd.BlockMode = true;
			ViewModel.sprInd.Col = 3;
			ViewModel.sprInd.Col2 = 6;
			ViewModel.sprInd.Row2 = CurrRow;
			ViewModel.sprInd.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.PEACH);
			ViewModel.sprInd.BlockMode = false;
			CurrRow++;
			ViewModel.sprInd.Row = CurrRow;
			//Totals for Current Secondary Description
			ViewModel.sprInd.Col = 2;
			ViewModel.sprInd.Text = "Total for " + CurrPrimaryType + "-" + CurrSecondaryDesc;
			ViewModel.sprInd.Col = 5;
			ViewModel.sprInd.Text = C2.ToString();
			C1 += C2;
			ViewModel.sprInd.Col = 6;
			ViewModel.sprInd.Text = H2.ToString();
			H1 += H2;
			ViewModel.sprInd.BlockMode = true;
			ViewModel.sprInd.Col = 2;
			ViewModel.sprInd.Col2 = 6;
			ViewModel.sprInd.Row2 = CurrRow;
			ViewModel.sprInd.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.PEACH);
			ViewModel.sprInd.BlockMode = false;
			CurrRow++;
			ViewModel.sprInd.Row = CurrRow;
			//Totals for this Primary Type
			ViewModel.sprInd.Col = 1;
			ViewModel.sprInd.Text = "Total for " + CurrPrimaryType;
			ViewModel.sprInd.Col = 5;
			ViewModel.sprInd.Text = C1.ToString();
			ViewModel.sprInd.Col = 6;
			ViewModel.sprInd.Text = H1.ToString();
			ViewModel.sprInd.BlockMode = true;
			ViewModel.sprInd.Col = 1;
			ViewModel.sprInd.Col2 = 6;
			ViewModel.sprInd.Row2 = CurrRow;
			ViewModel.sprInd.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.PUMPKIN);
			ViewModel.sprInd.BlockMode = false;
			ViewModel.TotalRows = CurrRow;

		}

		public void GetYearDetail()
		{
			//Fill Grid with Yearly Detail Data for Current Employee
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			int CurrYear = 0;
			string CurrPrimaryType = "";
			string CurrSecondaryDesc = "";
			string CurrSpecificDesc = "";

			int C1 = 0;
			int C2 = 0;
			int C3 = 0;
			int C4 = 0;
			float H1 = 0;
			float H2 = 0;
			float H3 = 0;
			float H4 = 0;

			oCmd.Connection = modGlobal.oConn;
			string SqlString = "spTrainingNew_ReportIndbyYearNew '" + ViewModel.CurrEmp + "','";
			SqlString = SqlString + DateTime.Parse(ViewModel.dtStart.Text).ToString("MM/dd/yyyy") + "','" + DateTime.Parse(ViewModel.dtEnd.Text).ToString("MM/dd/yyyy") + "'";
			if ( ViewModel.cboPrimary.ListIndex == -1)
			{
				SqlString = SqlString + ", NULL,";
			}
			else
			{
				//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboPrimary.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				SqlString = SqlString + "," + ViewModel.cboPrimary.ItemData(ViewModel.cboPrimary.ListIndex).ToString() + ",";
			}
			if ( ViewModel.cboSecondary.ListIndex == -1)
			{
				SqlString = SqlString + " NULL,";
			}
			else
			{
				//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboSecondary.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				SqlString = SqlString + ViewModel.cboSecondary.ItemData(ViewModel.cboSecondary.ListIndex).ToString() + ",";
			}
			if ( ViewModel.lSpecificID == 0)
			{
				SqlString = SqlString + " NULL ";
			}
			else
			{
				SqlString = SqlString + ViewModel.lSpecificID.ToString() + " ";
			}

			oCmd.CommandText = SqlString;
			oCmd.CommandType = CommandType.Text;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			int CurrRow = 6;

			while(!oRec.EOF)
			{
				ViewModel.sprInd.Row = CurrRow;
				if (Convert.ToDouble(oRec["training_year"]) != CurrYear)
				{
					if (CurrYear != 0)
					{
						//Totals for Specific Description
						ViewModel.sprInd.Col = 4;
						ViewModel.sprInd.Text = "Total for " + CurrYear.ToString() + "-" + CurrSpecificDesc;
						ViewModel.sprInd.Col = 5;
						ViewModel.sprInd.Text = C4.ToString();
						C3 += C4;
						C4 = 0;
						ViewModel.sprInd.Col = 6;
						ViewModel.sprInd.Text = H4.ToString();
						H3 = H2 + H4;
						H4 = 0;
						ViewModel.sprInd.BlockMode = true;
						ViewModel.sprInd.Col = 4;
						ViewModel.sprInd.Col2 = 6;
						ViewModel.sprInd.Row2 = CurrRow;
						ViewModel.sprInd.BackColor = modGlobal.Shared.PARCHMENT;
						ViewModel.sprInd.BlockMode = false;
						CurrRow++;
						ViewModel.sprInd.Row = CurrRow;
						CurrSpecificDesc = Convert.ToString(oRec["specific_description"]);
						//Totals for Secondary Description
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Text = "Total for " + CurrYear.ToString() + "-" + CurrSecondaryDesc;
						ViewModel.sprInd.Col = 5;
						ViewModel.sprInd.Text = C3.ToString();
						C2 += C3;
						C3 = 0;
						ViewModel.sprInd.Col = 6;
						ViewModel.sprInd.Text = H3.ToString();
						H2 += H3;
						H3 = 0;
						ViewModel.sprInd.BlockMode = true;
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Col2 = 6;
						ViewModel.sprInd.Row2 = CurrRow;
						ViewModel.sprInd.BackColor = modGlobal.Shared.PARCHMENT;
						ViewModel.sprInd.BlockMode = false;
						CurrRow++;
						ViewModel.sprInd.Row = CurrRow;
						CurrSecondaryDesc = Convert.ToString(oRec["secondary_description"]);
						//Totals for Primary Type
						ViewModel.sprInd.Col = 2;
						ViewModel.sprInd.Text = "Total for " + CurrYear.ToString() + "-" + CurrPrimaryType;
						ViewModel.sprInd.Col = 5;
						ViewModel.sprInd.Text = C2.ToString();
						C1 += C2;
						C2 = 0;
						ViewModel.sprInd.Col = 6;
						ViewModel.sprInd.Text = H2.ToString();
						H1 += H2;
						H2 = 0;
						ViewModel.sprInd.BlockMode = true;
						ViewModel.sprInd.Col = 2;
						ViewModel.sprInd.Col2 = 6;
						ViewModel.sprInd.Row2 = CurrRow;
						ViewModel.sprInd.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.PEACH);
						ViewModel.sprInd.BlockMode = false;
						CurrRow++;
						ViewModel.sprInd.Row = CurrRow;
						CurrPrimaryType = Convert.ToString(oRec["primary_description"]);
						//Totals for this Year
						ViewModel.sprInd.Col = 1;
						ViewModel.sprInd.Text = "Total for " + CurrYear.ToString();
						ViewModel.sprInd.Col = 5;
						ViewModel.sprInd.Text = C1.ToString();
						C1 = 0;
						ViewModel.sprInd.Col = 6;
						ViewModel.sprInd.Text = H1.ToString();
						H1 = 0;
						ViewModel.sprInd.BlockMode = true;
						ViewModel.sprInd.Col = 1;
						ViewModel.sprInd.Col2 = 6;
						ViewModel.sprInd.Row2 = CurrRow;
						ViewModel.sprInd.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.PUMPKIN);
						ViewModel.sprInd.BlockMode = false;
						CurrRow += 2;
						ViewModel.sprInd.Row = CurrRow;
						ViewModel.sprInd.Col = 1;
						ViewModel.sprInd.Text = Convert.ToString(oRec["training_year"]);
						CurrYear = Convert.ToInt32(oRec["training_year"]);
						ViewModel.sprInd.Col = 2;
						ViewModel.sprInd.Text = CurrPrimaryType;
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Text = CurrSecondaryDesc;
						ViewModel.sprInd.Col = 4;
						ViewModel.sprInd.Text = CurrSpecificDesc;
					}
					else
					{
						ViewModel.sprInd.Col = 1;
						ViewModel.sprInd.Text = Convert.ToString(oRec["training_year"]);
						CurrYear = Convert.ToInt32(oRec["training_year"]);
						ViewModel.sprInd.Col = 2;
						ViewModel.sprInd.Text = Convert.ToString(oRec["primary_description"]);
						CurrPrimaryType = Convert.ToString(oRec["primary_description"]);
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Text = Convert.ToString(oRec["secondary_description"]);
						CurrSecondaryDesc = Convert.ToString(oRec["secondary_description"]);
						ViewModel.sprInd.Col = 4;
						ViewModel.sprInd.Text = Convert.ToString(oRec["specific_description"]);
						CurrSpecificDesc = Convert.ToString(oRec["specific_description"]);
					}
				}
				else if (Convert.ToString(oRec["primary_description"]) != CurrPrimaryType)
				{
					if (CurrPrimaryType != "")
					{
						//Totals for Specific Descripiton
						ViewModel.sprInd.Col = 4;
						ViewModel.sprInd.Text = "Total for " + CurrYear.ToString() + "-" + CurrSpecificDesc;
						ViewModel.sprInd.Col = 5;
						ViewModel.sprInd.Text = C4.ToString();
						C3 += C4;
						C4 = 0;
						ViewModel.sprInd.Col = 6;
						ViewModel.sprInd.Text = H4.ToString();
						H3 += H4;
						H4 = 0;
						ViewModel.sprInd.BlockMode = true;
						ViewModel.sprInd.Col = 4;
						ViewModel.sprInd.Col2 = 6;
						ViewModel.sprInd.Row2 = CurrRow;
						ViewModel.sprInd.BackColor = modGlobal.Shared.PARCHMENT;
						ViewModel.sprInd.BlockMode = false;
						CurrRow++;
						ViewModel.sprInd.Row = CurrRow;
						CurrSpecificDesc = Convert.ToString(oRec["specific_description"]);
						//Totals for Secondary Descripiton
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Text = "Total for " + CurrYear.ToString() + "-" + CurrSecondaryDesc;
						ViewModel.sprInd.Col = 5;
						ViewModel.sprInd.Text = C3.ToString();
						C2 += C3;
						C3 = 0;
						ViewModel.sprInd.Col = 6;
						ViewModel.sprInd.Text = H3.ToString();
						H2 += H3;
						H3 = 0;
						ViewModel.sprInd.BlockMode = true;
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Col2 = 6;
						ViewModel.sprInd.Row2 = CurrRow;
						ViewModel.sprInd.BackColor = modGlobal.Shared.PARCHMENT;
						ViewModel.sprInd.BlockMode = false;
						CurrRow++;
						ViewModel.sprInd.Row = CurrRow;
						CurrSecondaryDesc = Convert.ToString(oRec["secondary_description"]);
						//Totals for Primary Type
						ViewModel.sprInd.Col = 2;
						ViewModel.sprInd.Text = "Total for " + CurrYear.ToString() + "-" + CurrPrimaryType;
						ViewModel.sprInd.Col = 5;
						ViewModel.sprInd.Text = C2.ToString();
						C1 += C2;
						C2 = 0;
						ViewModel.sprInd.Col = 6;
						ViewModel.sprInd.Text = H2.ToString();
						H1 += H2;
						H2 = 0;
						ViewModel.sprInd.BlockMode = true;
						ViewModel.sprInd.Col = 2;
						ViewModel.sprInd.Col2 = 6;
						ViewModel.sprInd.Row2 = CurrRow;
						ViewModel.sprInd.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.PEACH);
						ViewModel.sprInd.BlockMode = false;
						CurrRow++;
						ViewModel.sprInd.Row = CurrRow;
						ViewModel.sprInd.Col = 2;
						ViewModel.sprInd.Text = Convert.ToString(oRec["primary_description"]);
						CurrPrimaryType = Convert.ToString(oRec["primary_description"]);
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Text = CurrSecondaryDesc;
						ViewModel.sprInd.Col = 4;
						ViewModel.sprInd.Text = CurrSpecificDesc;
					}
				}
				else if (Convert.ToString(oRec["secondary_description"]) != CurrSecondaryDesc)
				{
					if (CurrSecondaryDesc != "")
					{
						//Totals for Specific Descripiton
						ViewModel.sprInd.Col = 4;
						ViewModel.sprInd.Text = "Total for " + CurrYear.ToString() + "-" + CurrSpecificDesc;
						ViewModel.sprInd.Col = 5;
						ViewModel.sprInd.Text = C4.ToString();
						C3 += C4;
						C4 = 0;
						ViewModel.sprInd.Col = 6;
						ViewModel.sprInd.Text = H4.ToString();
						H3 += H4;
						H4 = 0;
						ViewModel.sprInd.BlockMode = true;
						ViewModel.sprInd.Col = 4;
						ViewModel.sprInd.Col2 = 6;
						ViewModel.sprInd.Row2 = CurrRow;
						ViewModel.sprInd.BackColor = modGlobal.Shared.PARCHMENT;
						ViewModel.sprInd.BlockMode = false;
						CurrRow++;
						ViewModel.sprInd.Row = CurrRow;
						CurrSpecificDesc = Convert.ToString(oRec["specific_description"]);
						//Totals for Secondary Description
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Text = "Total for " + CurrYear.ToString() + "-" + CurrSecondaryDesc;
						ViewModel.sprInd.Col = 5;
						ViewModel.sprInd.Text = C3.ToString();
						C2 += C3;
						C3 = 0;
						ViewModel.sprInd.Col = 6;
						ViewModel.sprInd.Text = H3.ToString();
						H2 += H3;
						H3 = 0;
						ViewModel.sprInd.BlockMode = true;
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Col2 = 6;
						ViewModel.sprInd.Row2 = CurrRow;
						ViewModel.sprInd.BackColor = modGlobal.Shared.PARCHMENT;
						ViewModel.sprInd.BlockMode = false;
						CurrRow++;
						ViewModel.sprInd.Row = CurrRow;
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Text = Convert.ToString(oRec["secondary_description"]);
						CurrSecondaryDesc = Convert.ToString(oRec["secondary_description"]);
						ViewModel.sprInd.Col = 4;
						ViewModel.sprInd.Text = CurrSpecificDesc;
					}
				}
				else if (Convert.ToString(oRec["specific_description"]) != CurrSpecificDesc)
				{
					if (CurrSpecificDesc != "")
					{
						//Totals for Specific Descripiton
						ViewModel.sprInd.Col = 4;
						ViewModel.sprInd.Text = "Total for " + CurrYear.ToString() + "-" + CurrSpecificDesc;
						ViewModel.sprInd.Col = 5;
						ViewModel.sprInd.Text = C4.ToString();
						C3 += C4;
						C4 = 0;
						ViewModel.sprInd.Col = 6;
						ViewModel.sprInd.Text = H4.ToString();
						H3 += H4;
						H4 = 0;
						ViewModel.sprInd.BlockMode = true;
						ViewModel.sprInd.Col = 4;
						ViewModel.sprInd.Col2 = 6;
						ViewModel.sprInd.Row2 = CurrRow;
						ViewModel.sprInd.BackColor = modGlobal.Shared.PARCHMENT;
						ViewModel.sprInd.BlockMode = false;
						CurrRow++;
						ViewModel.sprInd.Row = CurrRow;
						ViewModel.sprInd.Text = Convert.ToString(oRec["specific_description"]);
						CurrSpecificDesc = Convert.ToString(oRec["specific_description"]);
					}
				}
				ViewModel.sprInd.Col = 5;
				ViewModel.sprInd.Text = Convert.ToDateTime(oRec["training_date"]).ToString("M/d/yyyy");
				C4++;
				ViewModel.sprInd.Col = 6;
				ViewModel.sprInd.Text = Convert.ToString(oRec["training_hours"]);
				H4 = (float) (H4 + Convert.ToDouble(oRec["training_hours"]));
				if (modGlobal.Clean(oRec["comments"]) != "")
				{
					//            sprInd.Col = 4
					//            sprInd.Text = Clean(sprInd.Text) & " - " & _
					//'                Clean(orec("comments"])
					CurrRow++;
					ViewModel.sprInd.BlockMode = true;
					ViewModel.sprInd.Row = CurrRow;
					ViewModel.sprInd.Row2 = CurrRow;
					ViewModel.sprInd.Col = 4;
					ViewModel.sprInd.Col2 = 6;
					ViewModel.sprInd.BackColor = modGlobal.Shared.YELLOW;
					ViewModel.sprInd.BlockMode = false;
					ViewModel.sprInd.Row = CurrRow;
					ViewModel.sprInd.Col = 4;
					ViewModel.sprInd.Text = "   -  " + modGlobal.Clean(oRec["comments"]);
				}
				oRec.MoveNext();
				CurrRow++;
			};

			//Totals for Specific Description
			ViewModel.sprInd.Row = CurrRow;
			ViewModel.sprInd.Col = 4;
			ViewModel.sprInd.Text = "Total for " + CurrYear.ToString() + "-" + CurrSpecificDesc;
			ViewModel.sprInd.Col = 5;
			ViewModel.sprInd.Text = C4.ToString();
			C3 += C4;
			ViewModel.sprInd.Col = 6;
			ViewModel.sprInd.Text = H4.ToString();
			H3 += H4;
			ViewModel.sprInd.BlockMode = true;
			ViewModel.sprInd.Col = 4;
			ViewModel.sprInd.Col2 = 6;
			ViewModel.sprInd.Row2 = CurrRow;
			ViewModel.sprInd.BackColor = modGlobal.Shared.PARCHMENT;
			ViewModel.sprInd.BlockMode = false;
			CurrRow++;
			ViewModel.sprInd.Row = CurrRow;

			//Totals for Secondary Description
			ViewModel.sprInd.Row = CurrRow;
			ViewModel.sprInd.Col = 3;
			ViewModel.sprInd.Text = "Total for " + CurrYear.ToString() + "-" + CurrSecondaryDesc;
			ViewModel.sprInd.Col = 5;
			ViewModel.sprInd.Text = C3.ToString();
			C2 += C3;
			ViewModel.sprInd.Col = 6;
			ViewModel.sprInd.Text = H3.ToString();
			H2 += H3;
			ViewModel.sprInd.BlockMode = true;
			ViewModel.sprInd.Col = 3;
			ViewModel.sprInd.Col2 = 6;
			ViewModel.sprInd.Row2 = CurrRow;
			ViewModel.sprInd.BackColor = modGlobal.Shared.PARCHMENT;
			ViewModel.sprInd.BlockMode = false;
			CurrRow++;
			ViewModel.sprInd.Row = CurrRow;

			//Totals for Primary Type
			ViewModel.sprInd.Col = 2;
			ViewModel.sprInd.Text = "Total for " + CurrYear.ToString() + "-" + CurrPrimaryType;
			ViewModel.sprInd.Col = 5;
			ViewModel.sprInd.Text = C2.ToString();
			C1 += C2;
			ViewModel.sprInd.Col = 6;
			ViewModel.sprInd.Text = H2.ToString();
			H1 += H2;
			ViewModel.sprInd.BlockMode = true;
			ViewModel.sprInd.Col = 2;
			ViewModel.sprInd.Col2 = 6;
			ViewModel.sprInd.Row2 = CurrRow;
			ViewModel.sprInd.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.PEACH);
			ViewModel.sprInd.BlockMode = false;
			CurrRow++;
			ViewModel.sprInd.Row = CurrRow;

			//Totals for this Year
			ViewModel.sprInd.Col = 1;
			ViewModel.sprInd.Text = "Total for " + CurrYear.ToString();
			ViewModel.sprInd.Col = 5;
			ViewModel.sprInd.Text = C1.ToString();
			ViewModel.sprInd.Col = 6;
			ViewModel.sprInd.Text = H1.ToString();
			ViewModel.sprInd.BlockMode = true;
			ViewModel.sprInd.Col = 1;
			ViewModel.sprInd.Col2 = 6;
			ViewModel.sprInd.Row2 = CurrRow;
			ViewModel.sprInd.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.PUMPKIN);
			ViewModel.sprInd.BlockMode = false;
			ViewModel.TotalRows = CurrRow;

		}

		public void GetTypeDetail()
		{
			//Fill Grid with Type Detail Data for Current Employee
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string CurrPrimaryType = "";
			string CurrSecondaryDesc = "";
			string CurrSpecificDesc = "";
			int CurrYear = 0;


			int C1 = 0;
			int C2 = 0;
			int C3 = 0;
			int C4 = 0;
			float H1 = 0;
			float H2 = 0;
			float H3 = 0;
			float H4 = 0;

			oCmd.Connection = modGlobal.oConn;
			string SqlString = "spTrainingNew_ReportIndbyTypeNew '" + ViewModel.CurrEmp + "','";
			SqlString = SqlString + DateTime.Parse(ViewModel.dtStart.Text).ToString("MM/dd/yyyy") + "','" + DateTime.Parse(ViewModel.dtEnd.Text).ToString("MM/dd/yyyy") + "'";
			if ( ViewModel.cboPrimary.ListIndex == -1)
			{
				SqlString = SqlString + ", NULL,";
			}
			else
			{
				//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboPrimary.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				SqlString = SqlString + "," + ViewModel.cboPrimary.ItemData(ViewModel.cboPrimary.ListIndex).ToString() + ",";
			}
			if ( ViewModel.cboSecondary.ListIndex == -1)
			{
				SqlString = SqlString + " NULL,";
			}
			else
			{
				//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboSecondary.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				SqlString = SqlString + ViewModel.cboSecondary.ItemData(ViewModel.cboSecondary.ListIndex).ToString() + ",";
			}
			if ( ViewModel.lSpecificID == 0)
			{
				SqlString = SqlString + " NULL ";
			}
			else
			{
				SqlString = SqlString + ViewModel.lSpecificID.ToString() + " ";
			}

			oCmd.CommandText = SqlString;
			oCmd.CommandType = CommandType.Text;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			int CurrRow = 6;

			while(!oRec.EOF)
			{
				ViewModel.sprInd.Row = CurrRow;
				if (Convert.ToString(oRec["primary_description"]) != CurrPrimaryType)
				{
					if (CurrPrimaryType != "")
					{
						//Totals for Curr Year
						ViewModel.sprInd.Col = 4;
						ViewModel.sprInd.Text = "Total for " + CurrYear.ToString();
						ViewModel.sprInd.Col = 5;
						ViewModel.sprInd.Text = C4.ToString();
						C3 += C4;
						C4 = 0;
						ViewModel.sprInd.Col = 6;
						ViewModel.sprInd.Text = H4.ToString();
						H3 += H4;
						H4 = 0;
						ViewModel.sprInd.BlockMode = true;
						ViewModel.sprInd.Col = 4;
						ViewModel.sprInd.Col2 = 6;
						ViewModel.sprInd.Row2 = CurrRow;
						ViewModel.sprInd.BackColor = modGlobal.Shared.PARCHMENT;
						ViewModel.sprInd.BlockMode = false;
						CurrRow++;
						ViewModel.sprInd.Row = CurrRow;
						CurrYear = Convert.ToInt32(oRec["training_year"]);
						//Totals for Specific Description
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Text = "Total for " + CurrPrimaryType + "-" + CurrSpecificDesc;
						ViewModel.sprInd.Col = 5;
						ViewModel.sprInd.Text = C3.ToString();
						C2 += C3;
						C3 = 0;
						ViewModel.sprInd.Col = 6;
						ViewModel.sprInd.Text = H3.ToString();
						H2 += H3;
						H3 = 0;
						ViewModel.sprInd.BlockMode = true;
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Col2 = 6;
						ViewModel.sprInd.Row2 = CurrRow;
						ViewModel.sprInd.BackColor = modGlobal.Shared.PARCHMENT;
						ViewModel.sprInd.BlockMode = false;
						CurrRow++;
						ViewModel.sprInd.Row = CurrRow;
						CurrSpecificDesc = Convert.ToString(oRec["specific_description"]);
						//Totals for Secondary Description
						ViewModel.sprInd.Col = 2;
						ViewModel.sprInd.Text = "Total for " + CurrPrimaryType + "-" + CurrSecondaryDesc;
						ViewModel.sprInd.Col = 5;
						ViewModel.sprInd.Text = C2.ToString();
						C1 += C2;
						C2 = 0;
						ViewModel.sprInd.Col = 6;
						ViewModel.sprInd.Text = H2.ToString();
						H1 += H2;
						H2 = 0;
						ViewModel.sprInd.BlockMode = true;
						ViewModel.sprInd.Col = 2;
						ViewModel.sprInd.Col2 = 6;
						ViewModel.sprInd.Row2 = CurrRow;
						ViewModel.sprInd.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.PEACH);
						ViewModel.sprInd.BlockMode = false;
						CurrRow++;
						ViewModel.sprInd.Row = CurrRow;
						CurrSecondaryDesc = Convert.ToString(oRec["secondary_description"]);
						//Totals for this Primary Type
						ViewModel.sprInd.Col = 1;
						ViewModel.sprInd.Text = "Total for " + CurrPrimaryType;
						ViewModel.sprInd.Col = 5;
						ViewModel.sprInd.Text = C1.ToString();
						C1 = 0;
						ViewModel.sprInd.Col = 6;
						ViewModel.sprInd.Text = H1.ToString();
						H1 = 0;
						ViewModel.sprInd.BlockMode = true;
						ViewModel.sprInd.Col = 1;
						ViewModel.sprInd.Col2 = 6;
						ViewModel.sprInd.Row2 = CurrRow;
						ViewModel.sprInd.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.PUMPKIN);
						ViewModel.sprInd.BlockMode = false;
						CurrRow += 2;
						ViewModel.sprInd.Row = CurrRow;
						ViewModel.sprInd.Col = 1;
						ViewModel.sprInd.Text = Convert.ToString(oRec["primary_description"]);
						CurrPrimaryType = Convert.ToString(oRec["primary_description"]);
						ViewModel.sprInd.Col = 2;
						ViewModel.sprInd.Text = CurrSecondaryDesc;
						ViewModel.sprInd.Col = 4;
						ViewModel.sprInd.Text = CurrYear.ToString();
					}
					else
					{
						ViewModel.sprInd.Col = 1;
						ViewModel.sprInd.Text = Convert.ToString(oRec["primary_description"]);
						CurrPrimaryType = Convert.ToString(oRec["primary_description"]);
						ViewModel.sprInd.Col = 2;
						ViewModel.sprInd.Text = Convert.ToString(oRec["secondary_description"]);
						CurrSecondaryDesc = Convert.ToString(oRec["secondary_description"]);
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Text = Convert.ToString(oRec["specific_description"]);
						CurrSpecificDesc = Convert.ToString(oRec["specific_description"]);
						ViewModel.sprInd.Col = 4;
						ViewModel.sprInd.Text = Convert.ToString(oRec["training_year"]);
						CurrYear = Convert.ToInt32(oRec["training_year"]);
					}
				}
				else if (Convert.ToString(oRec["secondary_description"]) != CurrSecondaryDesc)
				{
					if (CurrSecondaryDesc != "")
					{
						//Totals for Curr Year
						ViewModel.sprInd.Col = 4;
						ViewModel.sprInd.Text = "Total for " + CurrYear.ToString();
						ViewModel.sprInd.Col = 5;
						ViewModel.sprInd.Text = C4.ToString();
						C3 += C4;
						C4 = 0;
						ViewModel.sprInd.Col = 6;
						ViewModel.sprInd.Text = H4.ToString();
						H3 += H4;
						H4 = 0;
						ViewModel.sprInd.BlockMode = true;
						ViewModel.sprInd.Col = 4;
						ViewModel.sprInd.Col2 = 6;
						ViewModel.sprInd.Row2 = CurrRow;
						ViewModel.sprInd.BackColor = modGlobal.Shared.PARCHMENT;
						ViewModel.sprInd.BlockMode = false;
						CurrRow++;
						ViewModel.sprInd.Row = CurrRow;
						CurrYear = Convert.ToInt32(oRec["training_year"]);
						//Totals for Specific Description
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Text = "Total for " + CurrPrimaryType + "-" + CurrSpecificDesc;
						ViewModel.sprInd.Col = 5;
						ViewModel.sprInd.Text = C3.ToString();
						C2 += C3;
						C3 = 0;
						ViewModel.sprInd.Col = 6;
						ViewModel.sprInd.Text = H3.ToString();
						H2 += H3;
						H3 = 0;
						ViewModel.sprInd.BlockMode = true;
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Col2 = 6;
						ViewModel.sprInd.Row2 = CurrRow;
						ViewModel.sprInd.BackColor = modGlobal.Shared.PARCHMENT;
						ViewModel.sprInd.BlockMode = false;
						CurrRow++;
						ViewModel.sprInd.Row = CurrRow;
						CurrSpecificDesc = Convert.ToString(oRec["specific_description"]);
						//Totals for this Secondary Description
						ViewModel.sprInd.Col = 2;
						ViewModel.sprInd.Text = "Total for " + CurrPrimaryType + "-" + CurrSecondaryDesc;
						ViewModel.sprInd.Col = 5;
						ViewModel.sprInd.Text = C2.ToString();
						C1 += C2;
						C2 = 0;
						ViewModel.sprInd.Col = 6;
						ViewModel.sprInd.Text = H2.ToString();
						H1 += H2;
						H2 = 0;
						ViewModel.sprInd.BlockMode = true;
						ViewModel.sprInd.Col = 2;
						ViewModel.sprInd.Col2 = 6;
						ViewModel.sprInd.Row2 = CurrRow;
						ViewModel.sprInd.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.PEACH);
						ViewModel.sprInd.BlockMode = false;
						CurrRow++;
						ViewModel.sprInd.Row = CurrRow;
						ViewModel.sprInd.Col = 2;
						ViewModel.sprInd.Text = Convert.ToString(oRec["secondary_description"]);
						CurrSecondaryDesc = Convert.ToString(oRec["secondary_description"]);
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Text = Convert.ToString(oRec["specific_description"]);
						CurrSpecificDesc = Convert.ToString(oRec["specific_description"]);
						ViewModel.sprInd.Col = 4;
						ViewModel.sprInd.Text = CurrYear.ToString();
					}
				}
				else if (Convert.ToString(oRec["specific_description"]) != CurrSpecificDesc)
				{
					if (CurrSpecificDesc != "")
					{
						//Totals for Curr Year
						ViewModel.sprInd.Col = 4;
						ViewModel.sprInd.Text = "Total for " + CurrYear.ToString();
						ViewModel.sprInd.Col = 5;
						ViewModel.sprInd.Text = C4.ToString();
						C3 += C4;
						C4 = 0;
						ViewModel.sprInd.Col = 6;
						ViewModel.sprInd.Text = H4.ToString();
						H3 += H4;
						H4 = 0;
						ViewModel.sprInd.BlockMode = true;
						ViewModel.sprInd.Col = 4;
						ViewModel.sprInd.Col2 = 6;
						ViewModel.sprInd.Row2 = CurrRow;
						ViewModel.sprInd.BackColor = modGlobal.Shared.PARCHMENT;
						ViewModel.sprInd.BlockMode = false;
						CurrRow++;
						ViewModel.sprInd.Row = CurrRow;
						//Totals for Specific Description
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Text = "Total for " + CurrPrimaryType + "-" + CurrSpecificDesc;
						ViewModel.sprInd.Col = 5;
						ViewModel.sprInd.Text = C3.ToString();
						C2 += C3;
						C3 = 0;
						ViewModel.sprInd.Col = 6;
						ViewModel.sprInd.Text = H3.ToString();
						H2 += H3;
						H3 = 0;
						ViewModel.sprInd.BlockMode = true;
						ViewModel.sprInd.Col = 3;
						ViewModel.sprInd.Col2 = 6;
						ViewModel.sprInd.Row2 = CurrRow;
						ViewModel.sprInd.BackColor = modGlobal.Shared.PARCHMENT;
						ViewModel.sprInd.BlockMode = false;
						CurrRow++;
						ViewModel.sprInd.Row = CurrRow;
						ViewModel.sprInd.Text = Convert.ToString(oRec["specific_description"]);
						CurrSpecificDesc = Convert.ToString(oRec["specific_description"]);
						ViewModel.sprInd.Col = 4;
						ViewModel.sprInd.Text = CurrYear.ToString();
						CurrYear = Convert.ToInt32(oRec["training_year"]);
					}
				}
				else if (Convert.ToDouble(oRec["training_year"]) != CurrYear)
				{
					if (CurrYear != 0)
					{
						//Totals for This Year
						ViewModel.sprInd.Col = 4;
						ViewModel.sprInd.Text = "Total for " + CurrYear.ToString();
						ViewModel.sprInd.Col = 5;
						ViewModel.sprInd.Text = C4.ToString();
						C3 += C4;
						C4 = 0;
						ViewModel.sprInd.Col = 6;
						ViewModel.sprInd.Text = H4.ToString();
						H3 += H4;
						H4 = 0;
						ViewModel.sprInd.BlockMode = true;
						ViewModel.sprInd.Col = 4;
						ViewModel.sprInd.Col2 = 6;
						ViewModel.sprInd.Row2 = CurrRow;
						ViewModel.sprInd.BackColor = modGlobal.Shared.PARCHMENT;
						ViewModel.sprInd.BlockMode = false;
						CurrRow++;
						ViewModel.sprInd.Row = CurrRow;
						ViewModel.sprInd.Col = 4;
						ViewModel.sprInd.Text = Convert.ToString(oRec["training_year"]);
						CurrYear = Convert.ToInt32(oRec["training_year"]);
					}
				}
				ViewModel.sprInd.Col = 5;
				ViewModel.sprInd.Text = Convert.ToDateTime(oRec["training_date"]).ToString("M/d/yyyy");
				C4++;
				ViewModel.sprInd.Col = 6;
				ViewModel.sprInd.Text = Convert.ToString(oRec["training_hours"]);
				H4 = (float) (H4 + Convert.ToDouble(oRec["training_hours"]));
				if (modGlobal.Clean(oRec["comments"]) != "")
				{
					//            sprInd.Col = 3
					//            sprInd.Text = Clean(sprInd.Text) & " - " & _
					//'                Clean(orec("comments"])
					CurrRow++;
					ViewModel.sprInd.BlockMode = true;
					ViewModel.sprInd.Row = CurrRow;
					ViewModel.sprInd.Row2 = CurrRow;
					ViewModel.sprInd.Col = 3;
					ViewModel.sprInd.Col2 = 6;
					ViewModel.sprInd.BackColor = modGlobal.Shared.YELLOW;
					ViewModel.sprInd.BlockMode = false;
					ViewModel.sprInd.Row = CurrRow;
					ViewModel.sprInd.Col = 3;
					ViewModel.sprInd.Text = "   -  " + modGlobal.Clean(oRec["comments"]);
				}
				oRec.MoveNext();
				CurrRow++;
			};
			ViewModel.sprInd.Row = CurrRow;
			ViewModel.sprInd.Col = 4;
			ViewModel.sprInd.Text = "Total for " + CurrYear.ToString();
			ViewModel.sprInd.Col = 5;
			ViewModel.sprInd.Text = C4.ToString();
			C3 += C4;
			ViewModel.sprInd.Col = 6;
			ViewModel.sprInd.Text = H4.ToString();
			H3 += H4;
			ViewModel.sprInd.BlockMode = true;
			ViewModel.sprInd.Col = 4;
			ViewModel.sprInd.Col2 = 6;
			ViewModel.sprInd.Row2 = CurrRow;
			ViewModel.sprInd.BackColor = modGlobal.Shared.PARCHMENT;
			ViewModel.sprInd.BlockMode = false;
			CurrRow++;
			ViewModel.sprInd.Row = CurrRow;
			//Totals for SpecificDescription
			ViewModel.sprInd.Col = 3;
			ViewModel.sprInd.Text = "Total for " + CurrPrimaryType + "-" + CurrSpecificDesc;
			ViewModel.sprInd.Col = 5;
			ViewModel.sprInd.Text = C3.ToString();
			C2 += C3;
			ViewModel.sprInd.Col = 6;
			ViewModel.sprInd.Text = H3.ToString();
			H2 += H3;
			ViewModel.sprInd.BlockMode = true;
			ViewModel.sprInd.Col = 3;
			ViewModel.sprInd.Col2 = 6;
			ViewModel.sprInd.Row2 = CurrRow;
			ViewModel.sprInd.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.PEACH);
			ViewModel.sprInd.BlockMode = false;
			CurrRow++;
			ViewModel.sprInd.Row = CurrRow;
			//Totals for Secondary Description
			ViewModel.sprInd.Col = 2;
			ViewModel.sprInd.Text = "Total for " + CurrPrimaryType + "-" + CurrSecondaryDesc;
			ViewModel.sprInd.Col = 5;
			ViewModel.sprInd.Text = C2.ToString();
			C1 += C2;
			ViewModel.sprInd.Col = 6;
			ViewModel.sprInd.Text = H2.ToString();
			H1 += H2;
			ViewModel.sprInd.BlockMode = true;
			ViewModel.sprInd.Col = 2;
			ViewModel.sprInd.Col2 = 6;
			ViewModel.sprInd.Row2 = CurrRow;
			ViewModel.sprInd.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.PEACH);
			ViewModel.sprInd.BlockMode = false;
			CurrRow++;
			ViewModel.sprInd.Row = CurrRow;
			//Totals for this Primary Type
			ViewModel.sprInd.Col = 1;
			ViewModel.sprInd.Text = "Total for " + CurrPrimaryType;
			ViewModel.sprInd.Col = 5;
			ViewModel.sprInd.Text = C1.ToString();
			ViewModel.sprInd.Col = 6;
			ViewModel.sprInd.Text = H1.ToString();
			ViewModel.sprInd.BlockMode = true;
			ViewModel.sprInd.Col = 1;
			ViewModel.sprInd.Col2 = 6;
			ViewModel.sprInd.Row2 = CurrRow;
			ViewModel.sprInd.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.PUMPKIN);
			ViewModel.sprInd.BlockMode = false;
			ViewModel.TotalRows = CurrRow;

		}


		public void FillGrid()
		{
			//Determine the appropriate subroutine to call

			ClearGrid();
			ViewModel.sprInd.Row = 2;
			ViewModel.sprInd.Col = 5;
			ViewModel.sprInd.Text = ViewModel.lbEmpName.Text;

			if ( ViewModel.ReportMode == "Year")
			{
				ViewModel.sprInd.Row = 5;
				ViewModel.sprInd.Col = 1;
				ViewModel.sprInd.Text = "Year";
				ViewModel.sprInd.Col = 2;
				ViewModel.sprInd.Text = "Training Type Description(s)";
				ViewModel.sprInd.Col = 3;
				ViewModel.sprInd.Text = "";
				ViewModel.sprInd.Col = 4;
				ViewModel.sprInd.Text = "";
				ViewModel.sprInd.SetColWidth(1, 4.6f);
				ViewModel.sprInd.SetColWidth(2, 21.6f);
				ViewModel.sprInd.SetColWidth(3, 28.2f);
				ViewModel.sprInd.SetColWidth(4, 28.2f);
				if ( ViewModel.ReportLevel == "Summary")
				{
					ViewModel.sprInd.Col = 5;
					ViewModel.sprInd.Text = "Total Occurances";
					ViewModel.sprInd.Col = 6;
					ViewModel.sprInd.Text = "Total Hours";
					ViewModel.sprInd.Row = 3;
					ViewModel.sprInd.Col = 1;
					ViewModel.sprInd.Text = "Training by Year - Summary";
					GetYearSummary();
				}
				else
				{
					ViewModel.sprInd.Col = 5;
					ViewModel.sprInd.Text = "Training Date";
					ViewModel.sprInd.Col = 6;
					ViewModel.sprInd.Text = "Training Hours";
					ViewModel.sprInd.Row = 3;
					ViewModel.sprInd.Col = 1;
					ViewModel.sprInd.Text = "Training by Year";
					GetYearDetail();
				}
			}
			else
			{
				ViewModel.sprInd.Row = 5;
				ViewModel.sprInd.Col = 1;
				ViewModel.sprInd.Text = "Training Type Description(s)";
				ViewModel.sprInd.Col = 2;
				ViewModel.sprInd.Text = "";
				ViewModel.sprInd.Col = 4;
				ViewModel.sprInd.Text = "Year";
				ViewModel.sprInd.SetColWidth(1, 21.6f);
				ViewModel.sprInd.SetColWidth(2, 28.2f);
				ViewModel.sprInd.SetColWidth(3, 28.2f);
				ViewModel.sprInd.SetColWidth(4, 9.3f);
				ViewModel.sprInd.Col = 5;
				ViewModel.sprInd.Text = "Training Date";
				ViewModel.sprInd.Col = 6;
				ViewModel.sprInd.Text = "Training Hours";
				if ( ViewModel.ReportLevel == "Summary")
				{
					ViewModel.sprInd.Col = 5;
					ViewModel.sprInd.Text = "Total Occurances";
					ViewModel.sprInd.Col = 6;
					ViewModel.sprInd.Text = "Total Hours";
					ViewModel.sprInd.Row = 3;
					ViewModel.sprInd.Col = 1;
					ViewModel.sprInd.Text = "Training by Type - Summary";
					GetTypeSummary();
				}
				else
				{
					ViewModel.sprInd.Row = 3;
					ViewModel.sprInd.Col = 1;
					ViewModel.sprInd.Text = "Training by Type";
					GetTypeDetail();
				}
			}


		}

		[UpgradeHelpers.Events.Handler]
		internal void cboEmployee_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Select new employee
			//Refill Grid
			ViewModel.CurrEmp = ViewModel.cboEmployee.Text.Substring(Math.Max(ViewModel.cboEmployee.Text.Length - 5, 0));
			ViewModel.lbEmpName.Text = ViewModel.cboEmployee.Text.Substring(0, Math.Min(Strings.Len(ViewModel.cboEmployee.Text) - 8, ViewModel.cboEmployee.Text.Length));

			FillGrid();

		}

		private void cboPrimary_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboPrimary.Clicked)
			{
				//Load cboSecondary combobox
				PTSProject.clsTraining TrainCL = Container.Resolve< clsTraining>();

				if ( ViewModel.cboPrimary.ListIndex == -1)
				{
					return;
				}
				ViewModel.cboSecondary.ListIndex = -1;
				ViewModel.cboSecondary.Clear();
				ViewModel.lstSpecific.Items.Clear();
				//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboPrimary.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				TrainCL.GetSecondaryCodes(ViewModel.cboPrimary.ItemData(ViewModel.cboPrimary.ListIndex));

				while(!TrainCL.TrainingSecondaryCode.EOF)
				{
					ViewModel.cboSecondary.AddItem(modGlobal.Clean(TrainCL.TrainingSecondaryCode["description"]));
					//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboSecondary.NewIndex was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboSecondary.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.cboSecondary.setItemData(Convert.ToInt32(TrainCL.TrainingSecondaryCode["trn_secondary_code"]), ViewModel.cboSecondary.getNewIndex());
					TrainCL.TrainingSecondaryCode.MoveNext();
				}
				;

				FillGrid();
			}
			ViewModel.cboPrimary.Clicked = false;
		}

		private void cboSecondary_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboSecondary.Clicked)
			{
				//Load lst combobox
				PTSProject.clsTraining TrainCL = Container.Resolve< clsTraining>();

				if ( ViewModel.cboSecondary.ListIndex == -1)
				{
					return;
				}
				ViewModel.lstSpecific.Items.Clear();
				//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboSecondary.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				TrainCL.GetSpecificCodes(ViewModel.cboSecondary.ItemData(ViewModel.cboSecondary.ListIndex));

				while(!TrainCL.TrainingSpecificCode.EOF)
				{
					//UPGRADE_WARNING: (2081) AddItem has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
					ViewModel.lstSpecific.Items.Add(modGlobal.Clean(TrainCL.TrainingSpecificCode["description"]));
					//UPGRADE_ISSUE: (2064) LpADOLib.fpListAdo property lstSpecific.NewIndex was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					//UPGRADE_ISSUE: (2064) LpADOLib.fpListAdo property lstSpecific.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.lstSpecific.setItemData(Convert.ToInt32(TrainCL.TrainingSpecificCode["trn_specific_code"]), ViewModel.lstSpecific.getNewIndex());
					TrainCL.TrainingSpecificCode.MoveNext();
				}
				;

				FillGrid();
			}
			ViewModel.cboSecondary.Clicked = false;
		}

		[UpgradeHelpers.Events.Handler]
		internal void chkInactive_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			ClearGrid();
			LoadList();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdByDate_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Toggle ReportMode and Refill Grid
			if (Convert.ToString(ViewModel.cmdByDate.Tag) == "T")
			{
				ViewModel.ReportMode = "Type";
				ViewModel.cmdByDate.Text = "Sort by &Year";
				ViewModel.cmdByDate.Tag = "Y";
			}
			else
			{
				ViewModel.ReportMode = "Year";
				ViewModel.cmdByDate.Text = "Sort by &Type";
				ViewModel.cmdByDate.Tag = "T";
			}

			FillGrid();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClear_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.cboPrimary.Text = "";
			ViewModel.cboPrimary.ListIndex = -1;
			ViewModel.cboSecondary.Text = "";
			ViewModel.cboSecondary.Clear();
			ViewModel.cboPrimary.ListIndex = -1;
			ViewModel.lstSpecific.Items.Clear();
			ViewModel.lSpecificID = 0;
			ViewModel.dtStart.Text = "01/01/" + DateTime.Now.Year.ToString();
			ViewModel.dtEnd.Text = DateTime.Now.ToString("MM/dd/yyyy");

			FillGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdExit_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Print Individual Training Report

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprInd.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprInd.setPrintAbortMsg("Printing Individual Training Report - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprInd.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprInd.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprInd.PrintColHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprInd.setPrintColHeaders(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprInd.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprInd.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprInd.PrintMarginTop was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprInd.setPrintMarginTop(720);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprInd.PrintMarginLeft was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprInd.setPrintMarginLeft(500);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprInd.PrintRowHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprInd.setPrintRowHeaders(false);
            //Perform the printing action
            ViewModel.sprInd.PrintSheet(null);
			//ViewModel.sprInd.Action = (FarPoint.ViewModels.FPActionConstants) 32;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdReportLevel_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Toggle ReportLevel and Refill Grid
			if (Convert.ToString(ViewModel.cmdReportLevel.Tag) == "S")
			{
				ViewModel.ReportLevel = "Summary";
				ViewModel.cmdReportLevel.Text = "&Detail";
				ViewModel.cmdReportLevel.Tag = "D";
			}
			else
			{
				ViewModel.ReportLevel = "Detail";
				ViewModel.cmdReportLevel.Text = "&Summary";
				ViewModel.cmdReportLevel.Tag = "S";
			}

			FillGrid();

		}

		[UpgradeHelpers.Events.Handler]
		internal void dtEnd_ValueChanged(Object eventSender, System.EventArgs eventArgs)
		{
			FillGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void dtEnd_Click(Object eventSender, System.EventArgs eventArgs)
		{
			FillGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void dtStart_ValueChanged(Object eventSender, System.EventArgs eventArgs)
		{
			FillGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void dtStart_Click(Object eventSender, System.EventArgs eventArgs)
		{
			FillGrid();
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			PTSProject.clsTraining TrainCL = Container.Resolve< clsTraining>();
			ViewModel.dtStart.Text = "01/01/" + DateTime.Now.Year.ToString();
			ViewModel.dtEnd.Text = DateTime.Now.ToString("MM/dd/yyyy");
			ViewModel.cboPrimary.Clear();
			TrainCL.GetPrimaryCodes();

			while(!TrainCL.TrainingPrimaryCode.EOF)
			{
				ViewModel.cboPrimary.AddItem(modGlobal.Clean(TrainCL.TrainingPrimaryCode["description"]));
				//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboPrimary.NewIndex was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboPrimary.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.cboPrimary.setItemData(Convert.ToInt32(TrainCL.TrainingPrimaryCode["trn_primary_code"]), ViewModel.cboPrimary.getNewIndex());
				TrainCL.TrainingPrimaryCode.MoveNext();
			}
			;
			ViewModel.cboPrimary.Text = "";
			ViewModel.cboPrimary.ListIndex = -1;
			ViewModel.cboSecondary.Text = "";
			ViewModel.cboSecondary.Clear();
			ViewModel.cboPrimary.ListIndex = -1;
			ViewModel.lstSpecific.Items.Clear();
			ViewModel.lSpecificID = 0;

			LoadList();
			ViewModel.ReportMode = "Year";
			ViewModel.ReportLevel = "Detail";

		}

		[UpgradeHelpers.Events.Handler]
		internal void lstSpecific_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.lSpecificID = 0;

			for (int i = 0; i <= ViewModel.lstSpecific.Items.Count - 1; i++)
			{
				if ( ViewModel.lstSpecific.SelectedIndices.Contains(i))
				{
					//UPGRADE_ISSUE: (2064) LpADOLib.fpListAdo property lstSpecific.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.lSpecificID = ViewModel.lstSpecific.ItemData(i);
				}
			}

			FillGrid();
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmIndTrainReport DefInstance
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

		public static frmIndTrainReport CreateInstance()
		{
			PTSProject.frmIndTrainReport theInstance = Shared.Container.Resolve< frmIndTrainReport>();
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
			ViewModel.sprInd.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprInd.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmIndTrainReport
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmIndTrainReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmIndTrainReport m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}