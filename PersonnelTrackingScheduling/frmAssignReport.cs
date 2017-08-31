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

	public partial class frmAssignReport
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmAssignReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmAssignReport));
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


		private void frmAssignReport_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//*******************************************
		// Assignment Report
		// Uses vaSpread Control
		//*******************************************
		//ADODB

		public void FillSpread()
		{

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string CurrBatt = "", CurrUnit = "";
			int ATot = 0, BTot = 0;
			int CTot = 0, DTot = 0;
			int AAll = 0, BAll = 0;
			int CAlltot = 0, DAll = 0;
			int CSRtot = 0, FCCtot = 0;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spReport_Assignments";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			ViewModel.sprAssign.Row = 1;
			ViewModel.sprAssign.Col = 8 - 1;
			ViewModel.sprAssign.Text = DateTime.Now.ToString("M/d/yyyy HH:mm");
            ViewModel.sprAssign.FontBold = true;
            ViewModel.CurrRow = 4;
			ViewModel.PageCountRow = 4;

			while(!oRec.EOF)
			{
				if (Convert.ToString(oRec["batt_code"]) != CurrBatt)
				{
					if (ATot > 1)
					{
						(ViewModel.CurrRow)++;
						(ViewModel.PageCountRow)++;
						ViewModel.sprAssign.Row = ViewModel.CurrRow;
						ViewModel.sprAssign.Col = 1 - 1;
						if (CurrBatt.Trim() == "3")
						{
							ViewModel.sprAssign.Text = "Battalion 3 Totals";
						}
						else if (CurrBatt.Trim() == "2")
						{
							ViewModel.sprAssign.Text = "Battalion 2 Totals";
						}
						else
						{
							ViewModel.sprAssign.Text = "Battalion 1 Totals";
						}
						ViewModel.sprAssign.FontBold = true;
						ViewModel.sprAssign.FontItalic = true;
						ViewModel.sprAssign.FontSize = 14;
						ViewModel.sprAssign.SetRowHeight(ViewModel.CurrRow, 15);
						ViewModel.sprAssign.Col = 5 - 1;
						ViewModel.sprAssign.Text = ATot.ToString();
						AAll += ATot;
						ATot = 0;
						ViewModel.sprAssign.Col = 6 - 1;
						ViewModel.sprAssign.Text = BTot.ToString();
						BAll += BTot;
						BTot = 0;
						ViewModel.sprAssign.Col = 7 - 1;
						ViewModel.sprAssign.Text = CTot.ToString();
						CAlltot += CTot;
						CTot = 0;
						ViewModel.sprAssign.Col = 8 - 1;
						ViewModel.sprAssign.Text = DTot.ToString();
						DAll += DTot;
						DTot = 0;
						ViewModel.sprAssign.BlockMode = true;
                        ViewModel.sprAssign.HideCellBorders = true;
						ViewModel.sprAssign.Col = 1 - 1;
						ViewModel.sprAssign.Col2 = 8;
						ViewModel.sprAssign.Row2 = ViewModel.CurrRow;
						ViewModel.sprAssign.CellBorderColor = modGlobal.Shared.WHITE;
						ViewModel.sprAssign.BlockMode = false;
						(

//New Page
                    ViewModel.CurrRow)++;
						DisplayHeadings();
					}
					ViewModel.sprAssign.Row = ViewModel.CurrRow;
					ViewModel.sprAssign.Col = 1 - 1;
					if (Convert.ToString(oRec["batt_code"]).Trim() == "3")
					{
						ViewModel.sprAssign.Text = "Battalion 3";
					}
					else if (Convert.ToString(oRec["batt_code"]).Trim() == "2")
					{
						ViewModel.sprAssign.Text = "Battalion 2";
					}
					else
					{
						ViewModel.sprAssign.Text = "Battalion 1";
					}
					ViewModel.sprAssign.FontBold = true;
					ViewModel.sprAssign.FontItalic = true;
					ViewModel.sprAssign.FontSize = 14;
					CurrBatt = Convert.ToString(oRec["batt_code"]);
					(ViewModel.CurrRow)++;
					(ViewModel.PageCountRow)++;
					CurrUnit = "";
				}
				ViewModel.sprAssign.Row = ViewModel.CurrRow;
				if (CurrUnit != modGlobal.Clean(oRec["u_code"]))
				{
					if ( ViewModel.PageCountRow > 42)
					{
						DisplayHeadings();
					}
					else if (CurrUnit != "")
					{
						ViewModel.sprAssign.BlockMode = true;
						ViewModel.sprAssign.Row = ViewModel.CurrRow;
						ViewModel.sprAssign.Row2 = ViewModel.CurrRow;
						ViewModel.sprAssign.Col = 1 - 1;
						ViewModel.sprAssign.Col2 = 8;
						ViewModel.sprAssign.BackColor = modGlobal.Shared.LT_GRAY;
						ViewModel.sprAssign.BlockMode = false;
					}
					(ViewModel.CurrRow)++;
					(ViewModel.PageCountRow)++;
					ViewModel.sprAssign.Row = ViewModel.CurrRow;
					ViewModel.sprAssign.Col = 1 - 1;
					ViewModel.sprAssign.Text = modGlobal.Clean(oRec["u_code"]);
					CurrUnit = modGlobal.Clean(oRec["u_code"]);
				}
				ViewModel.sprAssign.Col = 2 - 1;
				ViewModel.sprAssign.Text = modGlobal.Clean(oRec["p_code"]);
				ViewModel.sprAssign.Col = 3 - 1;
				ViewModel.sprAssign.Text = modGlobal.Clean(oRec["debit_group"]);
				ViewModel.sprAssign.Col = 4 - 1;
				ViewModel.sprAssign.Text = modGlobal.Clean(oRec["p_assignment"]);

				//A shift
				ViewModel.sprAssign.Col = 5 - 1;
				ViewModel.sprAssign.Text = modGlobal.Clean(oRec["ashift"]);
				if (!modGlobal.Clean(oRec["u_code"]).StartsWith("CSR"))
				{
					if (String.CompareOrdinal(ViewModel.sprAssign.Text, " ") > 0)
					{
						ATot++;
					}
				}
				else
				{
					if (String.CompareOrdinal(ViewModel.sprAssign.Text, " ") > 0)
					{
						CSRtot++;
					}
				}

				//B shift
				ViewModel.sprAssign.Col = 6 - 1;
				ViewModel.sprAssign.Text = modGlobal.Clean(oRec["bshift"]);
				if (!modGlobal.Clean(oRec["u_code"]).StartsWith("CSR"))
				{
					if (String.CompareOrdinal(ViewModel.sprAssign.Text, " ") > 0)
					{
						BTot++;
					}
				}
				else
				{
					if (String.CompareOrdinal(ViewModel.sprAssign.Text, " ") > 0)
					{
						CSRtot++;
					}
				}

				//C shift
				ViewModel.sprAssign.Col = 7 - 1;
				ViewModel.sprAssign.Text = modGlobal.Clean(oRec["cshift"]);
				if (!modGlobal.Clean(oRec["u_code"]).StartsWith("CSR"))
				{
					if (String.CompareOrdinal(ViewModel.sprAssign.Text, " ") > 0)
					{
						CTot++;
					}
				}
				else
				{
					if (String.CompareOrdinal(ViewModel.sprAssign.Text, " ") > 0)
					{
						CSRtot++;
					}
				}

				//D shift
				ViewModel.sprAssign.Col = 8 - 1;
				ViewModel.sprAssign.Text = modGlobal.Clean(oRec["dshift"]);
				if (!modGlobal.Clean(oRec["u_code"]).StartsWith("CSR"))
				{
					if (String.CompareOrdinal(ViewModel.sprAssign.Text, " ") > 0)
					{
						DTot++;
					}
				}
				else
				{
					if (String.CompareOrdinal(ViewModel.sprAssign.Text, " ") > 0)
					{
						CSRtot++;
					}
				}

				oRec.MoveNext();
				(ViewModel.CurrRow)++;
				(ViewModel.PageCountRow)++;
				if ( ViewModel.PageCountRow > 45)
				{
					DisplayHeadings();
				}
			};
			(

//Display Last Battalion Totals
//And Shift Totals
ViewModel.CurrRow)++;
			ViewModel.sprAssign.Row = ViewModel.CurrRow;
			ViewModel.sprAssign.Col = 1 - 1;
			ViewModel.sprAssign.FontBold = true;
			ViewModel.sprAssign.FontItalic = true;
			ViewModel.sprAssign.FontSize = 14;
			ViewModel.sprAssign.SetRowHeight(ViewModel.CurrRow, 15);

			if (CurrBatt.Trim() == "3")
			{
				ViewModel.sprAssign.Text = "Battalion 3 Totals";
			}
			else if (CurrBatt.Trim() == "2")
			{
				ViewModel.sprAssign.Text = "Battalion 2 Totals";
			}
			else
			{
				ViewModel.sprAssign.Text = "Battalion 1 Totals";
			}
			ViewModel.sprAssign.Col = 5 - 1;
			ViewModel.sprAssign.Text = ATot.ToString();
			AAll += ATot;
			ATot = 0;
			ViewModel.sprAssign.Col = 6 - 1;
			ViewModel.sprAssign.Text = BTot.ToString();
			BAll += BTot;
			BTot = 0;
			ViewModel.sprAssign.Col = 7 - 1;
			ViewModel.sprAssign.Text = CTot.ToString();
			CAlltot += CTot;
			CTot = 0;
			ViewModel.sprAssign.Col = 8 - 1;
			ViewModel.sprAssign.Text = DTot.ToString();
			DAll += DTot;
			DTot = 0;
			ViewModel.sprAssign.BlockMode = true;
			ViewModel.sprAssign.Col = 1 - 1;
			ViewModel.sprAssign.Col2 = 8;
			ViewModel.sprAssign.Row2 = ViewModel.CurrRow;
			//ViewModel.sprAssign.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprAssign.CellBorderColor = modGlobal.Shared.BLACK;
			//ViewModel.sprAssign.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprAssign.BlockMode = false;
			ViewModel.sprAssign.BlockMode = true;
			ViewModel.sprAssign.Col = 1 - 1;
			ViewModel.sprAssign.Col2 = 8;
			ViewModel.sprAssign.Row2 = ViewModel.CurrRow;
			//ViewModel.sprAssign.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprAssign.CellBorderColor = modGlobal.Shared.BLACK;
			//ViewModel.sprAssign.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			(ViewModel.CurrRow)++;
			ViewModel.sprAssign.Row = ViewModel.CurrRow;
			ViewModel.sprAssign.Row2 = ViewModel.CurrRow;
			ViewModel.sprAssign.BackColor = modGlobal.Shared.LT_GRAY;
			ViewModel.sprAssign.BlockMode = false;
			//===========================================
			//SAF03 SAFLT
			ViewModel.CurrRow += 5;
			ViewModel.sprAssign.Row = ViewModel.CurrRow;
			ViewModel.sprAssign.Col = 1 - 1;
			ViewModel.sprAssign.Text = "SAF03 Safety Lieutenant";
			ViewModel.sprAssign.FontBold = true;
			ViewModel.sprAssign.FontItalic = true;
			ViewModel.sprAssign.FontSize = 14;
			(ViewModel.CurrRow)++;
			ViewModel.sprAssign.Row = ViewModel.CurrRow;
			ViewModel.sprAssign.SetRowHeight(ViewModel.CurrRow, 15);
			ViewModel.sprAssign.Text = "Unit";
			ViewModel.sprAssign.FontSize = 14;
			ViewModel.sprAssign.Col = 2 - 1;
			ViewModel.sprAssign.Text = "Position";
			ViewModel.sprAssign.FontSize = 14;
			ViewModel.sprAssign.Col = 3 - 1;
			ViewModel.sprAssign.Text = "Debit Group";
			ViewModel.sprAssign.FontSize = 14;
			ViewModel.sprAssign.Col = 4 - 1;
			ViewModel.sprAssign.Text = "House Fund";
			ViewModel.sprAssign.FontSize = 14;
			ViewModel.sprAssign.Col = 5 - 1;
			ViewModel.sprAssign.Text = "A Shift";
			ViewModel.sprAssign.FontSize = 14;
			ViewModel.sprAssign.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprAssign.Col = 6 - 1;
			ViewModel.sprAssign.Text = "B Shift";
			ViewModel.sprAssign.FontSize = 14;
			ViewModel.sprAssign.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprAssign.Col = 7 - 1;
			ViewModel.sprAssign.Text = "C Shift";
			ViewModel.sprAssign.FontSize = 14;
			ViewModel.sprAssign.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprAssign.Col = 8 - 1;
			ViewModel.sprAssign.Text = "D Shift";
			ViewModel.sprAssign.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprAssign.FontSize = 14;
			ViewModel.sprAssign.BlockMode = true;
			ViewModel.sprAssign.Col = 1 - 1;
			ViewModel.sprAssign.Col2 = 8;
			ViewModel.sprAssign.Row = ViewModel.CurrRow;
			ViewModel.sprAssign.Row2 = ViewModel.CurrRow;
			//ViewModel.sprAssign.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			//ViewModel.sprAssign.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprAssign.BlockMode = false;
			(ViewModel.CurrRow)++;
			oCmd.CommandText = "spReport_Assign142";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.sprAssign.Row = ViewModel.CurrRow;

			// CurrRow = CurrRow + 1


			while(!oRec.EOF)
			{
				ViewModel.sprAssign.Row = ViewModel.CurrRow;
				ViewModel.sprAssign.Col = 1 - 1;
				ViewModel.sprAssign.Text = modGlobal.Clean(oRec["u_code"]);
				ViewModel.sprAssign.Col = 2 - 1;
				ViewModel.sprAssign.Text = modGlobal.Clean(oRec["p_code"]);
				ViewModel.sprAssign.Col = 5 - 1;
				ViewModel.sprAssign.Text = modGlobal.Clean(oRec["a_shift"]);

				if (String.CompareOrdinal(ViewModel.sprAssign.Text, " ") > 0)
				{
					ATot++;
				}
				ViewModel.sprAssign.Col = 6 - 1;
				ViewModel.sprAssign.Text = modGlobal.Clean(oRec["b_shift"]);

				if (String.CompareOrdinal(ViewModel.sprAssign.Text, " ") > 0)
				{
					BTot++;
				}
				ViewModel.sprAssign.Col = 7 - 1;
				ViewModel.sprAssign.Text = modGlobal.Clean(oRec["c_shift"]);

				if (String.CompareOrdinal(ViewModel.sprAssign.Text, " ") > 0)
				{
					CTot++;
				}
				ViewModel.sprAssign.Col = 8 - 1;
				ViewModel.sprAssign.Text = modGlobal.Clean(oRec["d_shift"]);

				if (String.CompareOrdinal(ViewModel.sprAssign.Text, " ") > 0)
				{
					DTot++;
				}
				(ViewModel.CurrRow)++;
				oRec.MoveNext();
			};
			(

//SAF03 Totals
ViewModel.CurrRow)++;
			ViewModel.sprAssign.Row = ViewModel.CurrRow;
			ViewModel.sprAssign.Col = 1 - 1;
			ViewModel.sprAssign.FontBold = true;
			ViewModel.sprAssign.FontItalic = true;
			ViewModel.sprAssign.FontSize = 14;
			ViewModel.sprAssign.SetRowHeight(ViewModel.CurrRow, 15);
			ViewModel.sprAssign.Text = "SAF03 Safety Lieutenant Totals";
			ViewModel.sprAssign.Col = 5 - 1;
			ViewModel.sprAssign.Text = ATot.ToString();
			AAll += ATot;
			ATot = 0;
			ViewModel.sprAssign.Col = 6 - 1;
			ViewModel.sprAssign.Text = BTot.ToString();
			BAll += BTot;
			BTot = 0;
			ViewModel.sprAssign.Col = 7 - 1;
			ViewModel.sprAssign.Text = CTot.ToString();
			CAlltot += CTot;
			CTot = 0;
			ViewModel.sprAssign.Col = 8 - 1;
			ViewModel.sprAssign.Text = DTot.ToString();
			DAll += DTot;
			DTot = 0;

			//===========================================

			//Shift Totals
            ViewModel.sprAssign.Row = ViewModel.CurrRow + 1;
			ViewModel.sprAssign.Col = 1 - 1;
			ViewModel.sprAssign.FontBold = true;
			ViewModel.sprAssign.FontItalic = true;
			ViewModel.sprAssign.FontSize = 14;
			ViewModel.sprAssign.SetRowHeight(ViewModel.CurrRow, 15);
			ViewModel.sprAssign.Text = "Shift Totals";
			ViewModel.sprAssign.Col = 5 - 1;
			ViewModel.sprAssign.Text = AAll.ToString();
			ViewModel.sprAssign.Col = 6 - 1;
			ViewModel.sprAssign.Text = BAll.ToString();
			ViewModel.sprAssign.Col = 7 - 1;
			ViewModel.sprAssign.Text = CAlltot.ToString();
			ViewModel.sprAssign.Col = 8 - 1;
			ViewModel.sprAssign.Text = DAll.ToString();
			ViewModel.sprAssign.BlockMode = true;
			ViewModel.sprAssign.Col = 1 - 1;
			ViewModel.sprAssign.Col2 = 8;
			ViewModel.sprAssign.Row = ViewModel.CurrRow;
			ViewModel.sprAssign.Row2 = ViewModel.CurrRow + 1;
			//ViewModel.sprAssign.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprAssign.CellBorderColor = modGlobal.Shared.BLACK;
			//ViewModel.sprAssign.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprAssign.Row = ViewModel.CurrRow + 1;
			ViewModel.sprAssign.BackColor = modGlobal.Shared.LT_GRAY;
			ViewModel.sprAssign.BlockMode = false;

			int TotalOp = AAll + BAll + CAlltot + DAll;

			//FCC Page
			ViewModel.CurrRow += 3;
			DisplayHeadings();
			oCmd.CommandText = "spReport_AssignFCC";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.sprAssign.Row = ViewModel.CurrRow;
			ViewModel.sprAssign.Col = 1 - 1;
			ViewModel.sprAssign.Text = "Fire Communications";
			ViewModel.sprAssign.FontBold = true;
			ViewModel.sprAssign.FontItalic = true;
			ViewModel.sprAssign.FontSize = 14;
			(ViewModel.CurrRow)++;


			while(!oRec.EOF)
			{
				ViewModel.sprAssign.Row = ViewModel.CurrRow;
				ViewModel.sprAssign.Col = 2 - 1;
				ViewModel.sprAssign.Text = modGlobal.Clean(oRec["p_code"]);
				ViewModel.sprAssign.Col = 5 - 1;
				ViewModel.sprAssign.Text = modGlobal.Clean(oRec["a_shift"]);
				if (!modGlobal.Clean(oRec["u_code"]).StartsWith("CSR"))
				{
					if (String.CompareOrdinal(ViewModel.sprAssign.Text, " ") > 0)
					{
						ATot++;
					}
				}
				else
				{
					if (String.CompareOrdinal(ViewModel.sprAssign.Text, " ") > 0)
					{
						CSRtot++;
					}
				}
				ViewModel.sprAssign.Col = 6 - 1;
				ViewModel.sprAssign.Text = modGlobal.Clean(oRec["b_shift"]);
				if (!modGlobal.Clean(oRec["u_code"]).StartsWith("CSR"))
				{
					if (String.CompareOrdinal(ViewModel.sprAssign.Text, " ") > 0)
					{
						BTot++;
					}
				}
				else
				{
					if (String.CompareOrdinal(ViewModel.sprAssign.Text, " ") > 0)
					{
						CSRtot++;
					}
				}
				ViewModel.sprAssign.Col = 7 - 1;
				ViewModel.sprAssign.Text = modGlobal.Clean(oRec["c_shift"]);
				if (!modGlobal.Clean(oRec["u_code"]).StartsWith("CSR"))
				{
					if (String.CompareOrdinal(ViewModel.sprAssign.Text, " ") > 0)
					{
						CTot++;
					}
				}
				else
				{
					if (String.CompareOrdinal(ViewModel.sprAssign.Text, " ") > 0)
					{
						CSRtot++;
					}
				}
				ViewModel.sprAssign.Col = 8 - 1;
				ViewModel.sprAssign.Text = modGlobal.Clean(oRec["d_shift"]);
				if (!modGlobal.Clean(oRec["u_code"]).StartsWith("CSR"))
				{
					if (String.CompareOrdinal(ViewModel.sprAssign.Text, " ") > 0)
					{
						DTot++;
					}
				}
				else
				{
					if (String.CompareOrdinal(ViewModel.sprAssign.Text, " ") > 0)
					{
						CSRtot++;
					}
				}
				(ViewModel.CurrRow)++;
				oRec.MoveNext();
			};
			(

//FCC Totals
ViewModel.CurrRow)++;
			ViewModel.sprAssign.Row = ViewModel.CurrRow;
			ViewModel.sprAssign.Col = 1 - 1;
			ViewModel.sprAssign.FontBold = true;
			ViewModel.sprAssign.FontItalic = true;
			ViewModel.sprAssign.FontSize = 14;
			ViewModel.sprAssign.SetRowHeight(ViewModel.CurrRow, 15);
			ViewModel.sprAssign.Text = "Fire Communication Totals";
			ViewModel.sprAssign.Col = 5 - 1;
			ViewModel.sprAssign.Text = ATot.ToString();
			FCCtot += ATot;
			ATot = 0;
			ViewModel.sprAssign.Col = 6 - 1;
			ViewModel.sprAssign.Text = BTot.ToString();
			FCCtot += BTot;
			BTot = 0;
			ViewModel.sprAssign.Col = 7 - 1;
			ViewModel.sprAssign.Text = CTot.ToString();
			FCCtot += CTot;
			CTot = 0;
			ViewModel.sprAssign.Col = 8 - 1;
			ViewModel.sprAssign.Text = DTot.ToString();
			FCCtot += DTot;
			DTot = 0;
			ViewModel.sprAssign.BlockMode = true;
			ViewModel.sprAssign.Col = 1 - 1;
			ViewModel.sprAssign.Col2 = 8;
			ViewModel.sprAssign.Row2 = ViewModel.CurrRow;
			//ViewModel.sprAssign.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprAssign.CellBorderColor = modGlobal.Shared.BLACK;
			//ViewModel.sprAssign.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			(ViewModel.CurrRow)++;
			ViewModel.sprAssign.Row = ViewModel.CurrRow;
			ViewModel.sprAssign.Row2 = ViewModel.CurrRow;
			ViewModel.sprAssign.BackColor = modGlobal.Shared.LT_GRAY;
			ViewModel.sprAssign.BlockMode = false;

			//Fire Prevention
			ViewModel.CurrRow += 2;
			ViewModel.PageCountRow = ViewModel.CurrRow;
			ViewModel.sprAssign.Row = ViewModel.CurrRow;
			ViewModel.sprAssign.Col = 1 - 1;
			ViewModel.sprAssign.FontBold = true;
			ViewModel.sprAssign.FontItalic = true;
			ViewModel.sprAssign.FontSize = 14;
			ViewModel.sprAssign.SetRowHeight(ViewModel.CurrRow, 15);
			ViewModel.sprAssign.Text = "Fire Prevention";
			(ViewModel.CurrRow)++;
			oCmd.CommandText = "spReport_AssignOther 'FPB'";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			while(!oRec.EOF)
			{
				ViewModel.sprAssign.Row = ViewModel.CurrRow;
				ViewModel.sprAssign.Col = 1 - 1;
				ViewModel.sprAssign.Text = modGlobal.Clean(oRec["position_code"]);
				ViewModel.sprAssign.Col = 2 - 1;
				ViewModel.sprAssign.Text = modGlobal.Clean(oRec["name_full"]);
				if (String.CompareOrdinal(ViewModel.sprAssign.Text, " ") > 0)
				{
					ATot++;
				}
				(ViewModel.CurrRow)++;
				oRec.MoveNext();
			};
			ViewModel.MaxRow = ViewModel.CurrRow + 1;
			ViewModel.CurrRow = ViewModel.PageCountRow;

			//Training
			ViewModel.sprAssign.Row = ViewModel.CurrRow;
			ViewModel.sprAssign.Col = 4 - 1;
			ViewModel.sprAssign.FontBold = true;
			ViewModel.sprAssign.FontItalic = true;
			ViewModel.sprAssign.FontSize = 14;
			ViewModel.sprAssign.SetRowHeight(ViewModel.CurrRow, 15);
			ViewModel.sprAssign.Text = "Fire Training";
			(ViewModel.CurrRow)++;
			oCmd.CommandText = "spReport_AssignOther 'TRN'";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			while(!oRec.EOF)
			{
				ViewModel.sprAssign.Row = ViewModel.CurrRow;
				ViewModel.sprAssign.Col = 4 - 1;
				ViewModel.sprAssign.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
				ViewModel.sprAssign.Text = modGlobal.Clean(oRec["position_code"]);
				ViewModel.sprAssign.Col = 5 - 1;
				ViewModel.sprAssign.Text = modGlobal.Clean(oRec["name_full"]);
				if (String.CompareOrdinal(ViewModel.sprAssign.Text, " ") > 0)
				{
					BTot++;
				}
				(ViewModel.CurrRow)++;
				oRec.MoveNext();
			};
			if ( ViewModel.CurrRow + 1 > ViewModel.MaxRow)
			{
				ViewModel.MaxRow = ViewModel.CurrRow + 1;
			}
			ViewModel.CurrRow = ViewModel.PageCountRow;

			//Administration
			ViewModel.sprAssign.Row = ViewModel.CurrRow;
			ViewModel.sprAssign.Col = 6 - 1;
			ViewModel.sprAssign.FontBold = true;
			ViewModel.sprAssign.FontItalic = true;
			ViewModel.sprAssign.FontSize = 14;
			ViewModel.sprAssign.SetRowHeight(ViewModel.CurrRow, 15);
			ViewModel.sprAssign.Text = "Fire Administration";
			(ViewModel.CurrRow)++;
			oCmd.CommandText = "spReport_AssignOther 'ADM'";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			while(!oRec.EOF)
			{
				ViewModel.sprAssign.Row = ViewModel.CurrRow;
				ViewModel.sprAssign.Col = 6 - 1;
				ViewModel.sprAssign.Text = modGlobal.Clean(oRec["position_code"]);
				ViewModel.sprAssign.Col = 7 - 1;
				ViewModel.sprAssign.Text = modGlobal.Clean(oRec["name_full"]);
				if (String.CompareOrdinal(ViewModel.sprAssign.Text, " ") > 0)
				{
					CTot++;
				}
				(ViewModel.CurrRow)++;
				oRec.MoveNext();
			};
			(ViewModel.CurrRow)++;

			//Special Assignment
			ViewModel.sprAssign.Row = ViewModel.CurrRow;
			ViewModel.sprAssign.Col = 6 - 1;
			ViewModel.sprAssign.FontBold = true;
			ViewModel.sprAssign.FontItalic = true;
			ViewModel.sprAssign.FontSize = 14;
			ViewModel.sprAssign.SetRowHeight(ViewModel.CurrRow, 15);
			ViewModel.sprAssign.Text = "Special Assignment";
			(ViewModel.CurrRow)++;
			oCmd.CommandText = "spReport_AssignOther 'OPER'";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			while(!oRec.EOF)
			{
				ViewModel.sprAssign.Row = ViewModel.CurrRow;
				ViewModel.sprAssign.Col = 6 - 1;
				if (String.CompareOrdinal(modGlobal.Clean(oRec["name_full"]), "") > 0)
				{
					ViewModel.sprAssign.Text = modGlobal.Clean(oRec["position_code"]);
					ViewModel.sprAssign.Col = 7 - 1;
					ViewModel.sprAssign.Text = modGlobal.Clean(oRec["name_full"]);
					if (String.CompareOrdinal(ViewModel.sprAssign.Text, " ") > 0)
					{
						DTot++;
					}
					(ViewModel.CurrRow)++;
				}
				oRec.MoveNext();
			};
			if ( ViewModel.CurrRow + 1 > ViewModel.MaxRow)
			{
				ViewModel.MaxRow = ViewModel.CurrRow + 1;
			}
			ViewModel.CurrRow = ViewModel.MaxRow;
			ViewModel.sprAssign.BlockMode = true;
			ViewModel.sprAssign.Row = ViewModel.CurrRow;
			ViewModel.sprAssign.Row2 = ViewModel.CurrRow;
			ViewModel.sprAssign.Col = 1 - 1;
			ViewModel.sprAssign.Col2 = 8;
			ViewModel.sprAssign.BackColor = modGlobal.Shared.LT_GRAY;
			ViewModel.sprAssign.BlockMode = false;
			//    CurrRow = CurrRow + 2

			//Commissioned Staff Totals
			//new page
			DisplayHeadings();
			ViewModel.sprAssign.Row = ViewModel.CurrRow;
			ViewModel.sprAssign.Col = 1 - 1;
			ViewModel.sprAssign.FontBold = true;
			ViewModel.sprAssign.FontItalic = true;
			ViewModel.sprAssign.FontSize = 14;
			ViewModel.sprAssign.SetRowHeight(ViewModel.CurrRow, 15);
			ViewModel.sprAssign.Text = "Commissioned Staff Totals";
			(ViewModel.CurrRow)++;
			ViewModel.sprAssign.Row = ViewModel.CurrRow;
			ViewModel.sprAssign.Col = 1 - 1;
			ViewModel.sprAssign.Text = "Operations:";
			ViewModel.sprAssign.Col = 4 - 1;
			ViewModel.sprAssign.Text = TotalOp.ToString();
			(ViewModel.CurrRow)++;
			ViewModel.sprAssign.Row = ViewModel.CurrRow;
			ViewModel.sprAssign.Col = 1 - 1;
			ViewModel.sprAssign.Text = "Cross Shift Rovers:";
			ViewModel.sprAssign.Col = 4 - 1;
			ViewModel.sprAssign.Text = CSRtot.ToString();
			(ViewModel.CurrRow)++;
			ViewModel.sprAssign.Row = ViewModel.CurrRow;
			ViewModel.sprAssign.Col = 1 - 1;
			ViewModel.sprAssign.Text = "Fire Communications:";
			ViewModel.sprAssign.Col = 4 - 1;
			ViewModel.sprAssign.Text = FCCtot.ToString();
			(ViewModel.CurrRow)++;
			ViewModel.sprAssign.Row = ViewModel.CurrRow;
			ViewModel.sprAssign.Col = 1 - 1;
			ViewModel.sprAssign.Text = "Fire Prevention:";
			ViewModel.sprAssign.Col = 4 - 1;
			ViewModel.sprAssign.Text = ATot.ToString();
			(ViewModel.CurrRow)++;
			ViewModel.sprAssign.Row = ViewModel.CurrRow;
			ViewModel.sprAssign.Col = 1 - 1;
			ViewModel.sprAssign.Text = "Fire Training:";
			ViewModel.sprAssign.Col = 4 - 1;
			ViewModel.sprAssign.Text = BTot.ToString();
			(ViewModel.CurrRow)++;
			ViewModel.sprAssign.Row = ViewModel.CurrRow;
			ViewModel.sprAssign.Col = 1 - 1;
			ViewModel.sprAssign.Text = "Fire Administration:";
			ViewModel.sprAssign.Col = 4 - 1;
			ViewModel.sprAssign.Text = CTot.ToString();
			(ViewModel.CurrRow)++;
			ViewModel.sprAssign.Row = ViewModel.CurrRow;
			ViewModel.sprAssign.Col = 1 - 1;
			ViewModel.sprAssign.Text = "Special Assignment:";
			ViewModel.sprAssign.Col = 4 - 1;
			ViewModel.sprAssign.Text = DTot.ToString();
			(ViewModel.CurrRow)++;
			ViewModel.sprAssign.Row = ViewModel.CurrRow;
			ViewModel.sprAssign.Col = 1 - 1;
			ViewModel.sprAssign.Text = "Total Commissioned Staff:";
			ViewModel.sprAssign.Col = 4 - 1;
			ViewModel.sprAssign.Text = (TotalOp + CSRtot + FCCtot + ATot + BTot + CTot + DTot).ToString();
			ViewModel.sprAssign.BlockMode = true;
			ViewModel.sprAssign.Row2 = ViewModel.CurrRow;
			ViewModel.sprAssign.Col = 1 - 1;
			ViewModel.sprAssign.Col2 = 4;
			ViewModel.sprAssign.FontBold = true;
			//ViewModel.sprAssign.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			//ViewModel.sprAssign.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprAssign.BlockMode = false;
			(ViewModel.CurrRow)++;
			ViewModel.sprAssign.Row = ViewModel.CurrRow;
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprAssign.RowPageBreak was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprAssign.setRowPageBreak(true);
			(

//Civilian Assignments
ViewModel.CurrRow)++;
			ViewModel.sprAssign.Row = ViewModel.CurrRow;
			ViewModel.sprAssign.Col = 1 - 1;
			ViewModel.sprAssign.Text = "Tacoma Fire Department";
			ViewModel.sprAssign.FontBold = true;
			ViewModel.sprAssign.FontSize = 14;
			ViewModel.sprAssign.SetRowHeight(ViewModel.CurrRow, 15);
			(ViewModel.CurrRow)++;
			ViewModel.sprAssign.Row = ViewModel.CurrRow;
			ViewModel.sprAssign.Text = "Assignment Report - Civilian";
			ViewModel.sprAssign.FontBold = true;
			ViewModel.sprAssign.FontSize = 14;
			ViewModel.sprAssign.SetRowHeight(ViewModel.CurrRow, 15);
			(ViewModel.CurrRow)++;
			ViewModel.sprAssign.Row = ViewModel.CurrRow;
			ViewModel.sprAssign.SetRowHeight(ViewModel.CurrRow, 15);
			ViewModel.sprAssign.Text = "Position";
			ViewModel.sprAssign.FontSize = 14;
			ViewModel.sprAssign.Col = 4 - 1;
			ViewModel.sprAssign.Text = "Employee";
			ViewModel.sprAssign.FontSize = 14;
			ViewModel.sprAssign.BlockMode = true;
			ViewModel.sprAssign.Col = 1 - 1;
			ViewModel.sprAssign.Col2 = 8;
			ViewModel.sprAssign.Row = ViewModel.CurrRow;
			ViewModel.sprAssign.Row2 = ViewModel.CurrRow;
			//ViewModel.sprAssign.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			//ViewModel.sprAssign.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprAssign.BlockMode = false;
			(ViewModel.CurrRow)++;
			ViewModel.PageCountRow = 4;
			CTot = 0;
			oCmd.CommandText = "spReport_AssignCiv";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			while(!oRec.EOF)
			{
				ViewModel.sprAssign.Row = ViewModel.CurrRow;
				ViewModel.sprAssign.Col = 1 - 1;
				ViewModel.sprAssign.Text = modGlobal.Clean(oRec["job_title"]);
				ViewModel.sprAssign.Col = 4 - 1;
				ViewModel.sprAssign.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
				ViewModel.sprAssign.Text = modGlobal.Clean(oRec["name_full"]);
				CTot++;
				(ViewModel.CurrRow)++;
				(ViewModel.PageCountRow)++;
				oRec.MoveNext();
			};
			ViewModel.sprAssign.Row = ViewModel.CurrRow;
			ViewModel.sprAssign.Col = 1 - 1;
			ViewModel.sprAssign.Text = "Total Civilian Staff:";
			ViewModel.sprAssign.Col = 4 - 1;
			ViewModel.sprAssign.Text = CTot.ToString();
			ViewModel.sprAssign.BlockMode = true;
			ViewModel.sprAssign.Row2 = ViewModel.CurrRow;
			ViewModel.sprAssign.Col = 1 - 1;
			ViewModel.sprAssign.Col2 = 4;
			ViewModel.sprAssign.FontBold = true;
			//ViewModel.sprAssign.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			//ViewModel.sprAssign.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprAssign.BlockMode = false;

		}

		public void DisplayHeadings()
		{
			//New Headings after Page Break
			ViewModel.sprAssign.Row = ViewModel.CurrRow;
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprAssign.RowPageBreak was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprAssign.setRowPageBreak(true);
			(ViewModel.CurrRow)++;
			ViewModel.sprAssign.Row = ViewModel.CurrRow;
			ViewModel.sprAssign.Col = 1 - 1;
			ViewModel.sprAssign.Text = "Tacoma Fire Department";
			ViewModel.sprAssign.FontBold = true;
			ViewModel.sprAssign.FontSize = 14;
			ViewModel.sprAssign.SetRowHeight(ViewModel.CurrRow, 15);
			(ViewModel.CurrRow)++;
			ViewModel.sprAssign.Row = ViewModel.CurrRow;
			ViewModel.sprAssign.Text = "Assignment Report";
			ViewModel.sprAssign.FontBold = true;
			ViewModel.sprAssign.FontSize = 14;
			ViewModel.sprAssign.SetRowHeight(ViewModel.CurrRow, 15);
			(ViewModel.CurrRow)++;
			ViewModel.sprAssign.Row = ViewModel.CurrRow;
			ViewModel.sprAssign.SetRowHeight(ViewModel.CurrRow, 15);
			ViewModel.sprAssign.Text = "Unit";
			ViewModel.sprAssign.FontSize = 14;
			ViewModel.sprAssign.Col = 2 - 1;
			ViewModel.sprAssign.Text = "Position";
			ViewModel.sprAssign.FontSize = 14;
			ViewModel.sprAssign.Col = 3 - 1;
			ViewModel.sprAssign.Text = "Debit Group";
			ViewModel.sprAssign.FontSize = 14;
			ViewModel.sprAssign.Col = 4 - 1;
			ViewModel.sprAssign.Text = "House Fund";
			ViewModel.sprAssign.FontSize = 14;
			ViewModel.sprAssign.Col = 5 - 1;
			ViewModel.sprAssign.Text = "A Shift";
			ViewModel.sprAssign.FontSize = 14;
			ViewModel.sprAssign.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprAssign.Col = 6 - 1;
			ViewModel.sprAssign.Text = "B Shift";
			ViewModel.sprAssign.FontSize = 14;
			ViewModel.sprAssign.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprAssign.Col = 7 - 1;
			ViewModel.sprAssign.Text = "C Shift";
			ViewModel.sprAssign.FontSize = 14;
			ViewModel.sprAssign.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprAssign.Col = 8 - 1;
			ViewModel.sprAssign.Text = "D Shift";
			ViewModel.sprAssign.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprAssign.FontSize = 14;
			ViewModel.sprAssign.BlockMode = true;
			ViewModel.sprAssign.Col = 1 - 1;
			ViewModel.sprAssign.Col2 = 8;
			ViewModel.sprAssign.Row = ViewModel.CurrRow;
			ViewModel.sprAssign.Row2 = ViewModel.CurrRow;
			//ViewModel.sprAssign.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			//ViewModel.sprAssign.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprAssign.BlockMode = false;
			(ViewModel.CurrRow)++;
			ViewModel.PageCountRow = 4;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Print Assignment Report to Default Printer

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprAssign.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprAssign.setPrintAbortMsg("Printing Assignment Report - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprAssign.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprAssign.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprAssign.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprAssign.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprAssign.PrintMarginRight was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprAssign.setPrintMarginRight(Convert.ToInt32(0.5d));
            //    sprAssign.PrintOrientation = 2
            ViewModel.sprAssign.PrintSheet(null);

            //ViewModel.sprAssign.Action = (FarPoint.ViewModels.FPActionConstants) 32;

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			FillSpread();
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmAssignReport DefInstance
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

		public static frmAssignReport CreateInstance()
		{
			PTSProject.frmAssignReport theInstance = Shared.Container.Resolve< frmAssignReport>();
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
			ViewModel.sprAssign.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprAssign.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmAssignReport
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmAssignReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmAssignReport m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}