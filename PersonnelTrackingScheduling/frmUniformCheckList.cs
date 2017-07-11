using System;
using System.Data;
using System.Data.Common;
using System.Text;
using UpgradeHelpers.DB.ADO;
using UpgradeStubs;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class frmUniformCheckList
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmUniformCheckListViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmUniformCheckList));
			if ( Shared.m_vb6FormDefInstance == null)
			{
				if ( Shared.m_InitializingDefInstance)
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
		}


		private void frmUniformCheckList_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		public void FormatPPECheckList2()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ViewModel.cmdPrintChecklist.Enabled = false;
			string SaveName = "";
			bool EmployeeBreak = false;
			int EmployeeCount = 0;
			//int PageCount = 0;
			ViewModel.sprCheckList2.Row = 1;
			ViewModel.sprCheckList2.Row = ViewModel.sprCheckList2.MaxRows;
			ViewModel.sprCheckList2.Col = 1;
			ViewModel.sprCheckList2.Col2 = ViewModel.sprCheckList2.MaxCols;
			ViewModel.sprCheckList2.BlockMode = true;
			ViewModel.sprCheckList2.Text = "";
			ViewModel.sprCheckList2.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprCheckList2.BlockMode = false;
			ViewModel.sprCheckList2.Row = 1;
			ViewModel.sprCheckList2.Col = 1;
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCheckList2.AllowCellOverflow was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprCheckList2.setAllowCellOverflow(true);
			ViewModel.sprCheckList2.FontBold = true;
			ViewModel.sprCheckList2.Text = "TFD PPE Inspection Checklist For 18" + ViewModel.CurrBatt + " - Shift " + ViewModel.CurrShift;
			ViewModel.sprCheckList2.Col = 5;
			ViewModel.sprCheckList2.Text = DateTime.Now.ToString("MM/dd/yyyy");
			ViewModel.sprCheckList2.FontBold = false;
			ViewModel.sprCheckList2.Row = 3;
			ViewModel.sprCheckList2.Col = 1;
			int lRow = 3;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			oCmd.CommandText = "spReport_PPEInspectionCheckList '" + ViewModel.CurrBatt + "','" + ViewModel.CurrShift + "' ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (oRec.EOF)
			{
				return;
			}

			SaveName = modGlobal.Clean(oRec["name_full"]);
			EmployeeBreak = true;
			//PageCount = 1;
			EmployeeCount = 1;


			while(!oRec.EOF)
			{
				if (EmployeeBreak)
				{
					//            If EmployeeCount = 6 Then
					//                sprCheckList2.Row = lRow
					//                sprCheckList2.RowPageBreak = True
					//                EmployeeCount = 1
					//                PageCount = PageCount + 1
					//                lRow = lRow + 1
					//                sprCheckList2.Row = lRow
					//                sprCheckList2.Col = 5
					//                sprCheckList2.Text = "Page " & PageCount
					//                lRow = lRow + 1
					//            End If
					ViewModel.sprCheckList2.Row = lRow;
					ViewModel.sprCheckList2.Col = 1;
					ViewModel.sprCheckList2.Text = "Name";
					ViewModel.sprCheckList2.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
					ViewModel.sprCheckList2.Col = 2;
					ViewModel.sprCheckList2.Text = "WDL #";
					ViewModel.sprCheckList2.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
					ViewModel.sprCheckList2.Col = 3;
					ViewModel.sprCheckList2.Text = "Expiration Date";
					ViewModel.sprCheckList2.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
					ViewModel.sprCheckList2.Col = 4;
					ViewModel.sprCheckList2.Text = "";
					ViewModel.sprCheckList2.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
					ViewModel.sprCheckList2.Col = 5;
					ViewModel.sprCheckList2.Text = "";
					ViewModel.sprCheckList2.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);

					lRow++;
					ViewModel.sprCheckList2.Row = lRow;
					ViewModel.sprCheckList2.Col = 1;
					ViewModel.sprCheckList2.Text = SaveName;
					ViewModel.sprCheckList2.BackColor = modGlobal.Shared.WHITE;
					ViewModel.sprCheckList2.Col = 2;
					ViewModel.sprCheckList2.Text = modGlobal.Clean(oRec["license_number"]);
					ViewModel.sprCheckList2.BackColor = modGlobal.Shared.WHITE;
					ViewModel.sprCheckList2.Col = 3;
					if (modGlobal.Clean(oRec["expiration_date"]) != "")
					{
						ViewModel.sprCheckList2.Text = Convert.ToDateTime(oRec["expiration_date"]).ToString("MM/dd/yyyy");
					}
					else
					{
						ViewModel.sprCheckList2.Text = modGlobal.Clean(oRec["expiration_date"]);
					}
					ViewModel.sprCheckList2.BackColor = modGlobal.Shared.WHITE;

					lRow++;
					ViewModel.sprCheckList2.Row = lRow;
					ViewModel.sprCheckList2.Col = 1;
					ViewModel.sprCheckList2.Text = "";
					ViewModel.sprCheckList2.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
					ViewModel.sprCheckList2.Col = 2;
					ViewModel.sprCheckList2.Text = "Issued Date";
					ViewModel.sprCheckList2.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
					ViewModel.sprCheckList2.Col = 3;
					ViewModel.sprCheckList2.Text = "Brand";
					ViewModel.sprCheckList2.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
					ViewModel.sprCheckList2.Col = 4;
					ViewModel.sprCheckList2.Text = "Size/Color";
					ViewModel.sprCheckList2.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
					ViewModel.sprCheckList2.Col = 5;
					ViewModel.sprCheckList2.Text = "Tracking Number";
					ViewModel.sprCheckList2.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);

					EmployeeBreak = false;
				}

				lRow++;
				ViewModel.sprCheckList2.Row = lRow;
				ViewModel.sprCheckList2.Col = 1;
				ViewModel.sprCheckList2.Text = modGlobal.Clean(oRec["TurnOut"]);
				ViewModel.sprCheckList2.BackColor = modGlobal.Shared.WHITE;
				ViewModel.sprCheckList2.Col = 2;
				if (modGlobal.Clean(oRec["issued_date"]) != "")
				{
					ViewModel.sprCheckList2.Text = Convert.ToDateTime(oRec["issued_date"]).ToString("MM/dd/yyyy");
				}
				else
				{
					ViewModel.sprCheckList2.Text = "";
				}
				ViewModel.sprCheckList2.BackColor = modGlobal.Shared.WHITE;
				ViewModel.sprCheckList2.Col = 3;
				ViewModel.sprCheckList2.Text = modGlobal.Clean(oRec["manufacturer_name"]);
				ViewModel.sprCheckList2.BackColor = modGlobal.Shared.WHITE;
				ViewModel.sprCheckList2.Col = 4;
				if (modGlobal.Clean(oRec["TurnOut"]) == "Helmet")
				{
					ViewModel.sprCheckList2.Text = modGlobal.Clean(oRec["ColorType"]);
				}
				else
				{
					ViewModel.sprCheckList2.Text = modGlobal.Clean(oRec["SizeType"]);
				}
				ViewModel.sprCheckList2.BackColor = modGlobal.Shared.WHITE;
				ViewModel.sprCheckList2.Col = 5;
				ViewModel.sprCheckList2.Text = modGlobal.Clean(oRec["tracking_number"]);
				ViewModel.sprCheckList2.BackColor = modGlobal.Shared.WHITE;

				oRec.MoveNext();
				if (!oRec.EOF)
				{
					if (SaveName != modGlobal.Clean(oRec["name_full"]))
					{
						SaveName = modGlobal.Clean(oRec["name_full"]);
						EmployeeBreak = true;
						lRow += 2;
						EmployeeCount++;
					}
				}

			};
			ViewModel.cmdPrintChecklist.Enabled = true;

		}

		public void FormatHeadings()
		{
			//    Dim oCmd As New ADODB.Command
			//    Dim oRec As ADODB.Recordset
			//    Dim i As Integer
			//    Dim iCol As Integer
			//    Dim sHeading As String
			//
			//    sHeadingFilter = ""
			//
			//    sprCheckList.Row = 1
			//    sprCheckList.Row2 = 3
			//    sprCheckList.Col = 1
			//    sprCheckList.Col2 = sprCheckList.MaxCols
			//    sprCheckList.BlockMode = True
			//    sprCheckList.Text = ""
			//    sprCheckList.BlockMode = False
			//
			//    sprCheckList.Row = 1
			//
			//    sprCheckList.Col = 1
			//    sprCheckList.Text = "Name / WDL #"
			//
			//    sprCheckList.Col = 2
			//    sprCheckList.Text = "WDL Exp Date"
			//
			//    iCol = 2
			//    sprCheckList.Row = 1
			//    sHeading = ""
			//
			//    oCmd.ActiveConnection = oConn
			//    oCmd.CommandType = adCmdText
			//
			//    oCmd.CommandText = "spReport_PPEChecklistItems "
			//    Set oRec = oCmd.Execute
			//
			//    If oRec.EOF Then
			//        Exit Sub
			//    End If
			//
			//    Do Until oRec.EOF
			//        iCol = iCol + 1
			//        sprCheckList.Col = iCol
			//        sprCheckList.Row = 0
			//
			//        sHeading = Clean(oRec("description"]) & "     Tracking#     Issued Date"
			//        sprCheckList.Text = sHeading
			//
			//        sprCheckList.Row = 1
			//        sprCheckList.Text = Clean(oRec("description"])
			//
			//
			//        If Clean(oRec("Brand"]) = "" And Clean(oRec("ColorData"]) = "" And Clean(oRec("SizeData"]) = "" Then
			//                'continue
			//        Else
			//            iCol = iCol + 1
			//            sprCheckList.Col = iCol
			//            sprCheckList.Row = 0
			//            sHeading = ""
			//            If Clean(oRec("Brand"]) <> "" Then
			//                sHeading = Clean(oRec("description"]) & "   Brand     "
			//            End If
			//            If Clean(oRec("ColorData"]) <> "" Then
			//                sHeading = sHeading & "   Color"
			//            ElseIf Clean(oRec("SizeData"]) <> "" Then
			//                sHeading = sHeading & "   Size"
			//            End If
			//            sprCheckList.Text = sHeading
			//
			//            sprCheckList.Row = 1
			//            sprCheckList.Text = Clean(oRec("description"])
			//        End If
			//
			//        oRec.MoveNext
			//    Loop
			//
			//    sprCheckList.MaxCols = iCol

		}

		public void FormatPPECheckList()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			int CellHeight = 0;
			ViewModel.cmdPrintChecklist.Enabled = false;
			string SaveName = "";
			string SaveItem = "";
			int EmployeeCount = 0;
			int iCodeRow = 3;
			ViewModel.sprCheckList.Row = 4;
			ViewModel.sprCheckList.Row = ViewModel.sprCheckList.MaxRows;
			ViewModel.sprCheckList.Col = 1;
			ViewModel.sprCheckList.Col2 = ViewModel.sprCheckList.MaxCols;
			ViewModel.sprCheckList.BlockMode = true;
			ViewModel.sprCheckList.Text = "";
			ViewModel.sprCheckList.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprCheckList.BlockMode = false;
			ViewModel.sHeadingFilter = "TFD PPE Inspection Checklist For 18" + ViewModel.CurrBatt + " - Shift " + ViewModel.CurrShift;
			this.ViewModel.Text = ViewModel.sHeadingFilter;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			oCmd.CommandText = "spReport_PPEInspectionCheckList '" + ViewModel.CurrBatt + "','" + ViewModel.CurrShift + "' ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (oRec.EOF)
			{
				return;
			}
			ViewModel.sprCheckList.Col = 1;
			int lRow = 4;
			EmployeeCount = 1;
			StringBuilder sCellText = new System.Text.StringBuilder();
			int iPageRow = 2;


			while(!oRec.EOF)
			{
				//Clean(oRec("name_full"])
				if (SaveName == "" && SaveItem == "")
				{ //Firsttime

					ViewModel.sprCheckList.Row = lRow;
					iPageRow++;
					ViewModel.sprCheckList.Col = 1;
					SaveName = modGlobal.Clean(oRec["name_full"]);
					ViewModel.sprCheckList.Text = SaveName + "   " + modGlobal.Clean(oRec["license_number"]);
					CellHeight = 20;
					ViewModel.sprCheckList.SetRowHeight(ViewModel.sprCheckList.Row, CellHeight);
					ViewModel.sprCheckList.Col = 2;
					if (modGlobal.Clean(oRec["expiration_date"]) != "")
					{
						ViewModel.sprCheckList.Text = Convert.ToDateTime(oRec["expiration_date"]).ToString("MM/dd/yyyy");
					}
					else
					{
						ViewModel.sprCheckList.Text = modGlobal.Clean(oRec["expiration_date"]);
					}
					CellHeight = 20;
					ViewModel.sprCheckList.SetRowHeight(ViewModel.sprCheckList.Row, CellHeight);

					SaveItem = modGlobal.Clean(oRec["TurnOut"]);
					ViewModel.sprCheckList.Row = iCodeRow;
					int tempForVar = ViewModel.sprCheckList.MaxCols;
					for (int i = 3; i <= tempForVar; i++)
					{
						ViewModel.sprCheckList.Col = i;
						if (SaveItem == modGlobal.Clean(ViewModel.sprCheckList.Text))
						{
							ViewModel.sprCheckList.Row = lRow;

							sCellText = new System.Text.StringBuilder(modGlobal.Clean(oRec["tracking_number"]));
							if (modGlobal.Clean(oRec["issued_date"]) != "")
							{
								if (modGlobal.Clean(oRec["tracking_number"]) != "")
								{
									sCellText.Append("     ");
									sCellText.Append(Convert.ToDateTime(oRec["issued_date"]).ToString("M/d/yyyy"));
								}
								else
								{
									sCellText = new System.Text.StringBuilder(Convert.ToDateTime(oRec["issued_date"]).ToString("M/d/yyyy"));
								}
							}
							ViewModel.sprCheckList.Text = sCellText.ToString();
							//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCheckList.MaxTextCellHeight was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							CellHeight = Convert.ToInt32(ViewModel.sprCheckList.getMaxTextCellHeight());
							ViewModel.sprCheckList.SetRowHeight(ViewModel.sprCheckList.Row, CellHeight);

							//check to see if we need Brand, etc info...
							ViewModel.sprCheckList.Row = iCodeRow;
							ViewModel.sprCheckList.Col = i + 1;
							if (SaveItem == modGlobal.Clean(ViewModel.sprCheckList.Text))
							{
								ViewModel.sprCheckList.Row = lRow;

								sCellText = new System.Text.StringBuilder(modGlobal.Clean(oRec["manufacturer_name"]));
								if (modGlobal.Clean(oRec["ColorType"]) != "")
								{
									if (modGlobal.Clean(oRec["manufacturer_name"]) != "")
									{
										sCellText.Append(" / ");
										sCellText.Append(modGlobal.Clean(oRec["ColorType"]));
									}
									else
									{
										sCellText = new System.Text.StringBuilder(modGlobal.Clean(oRec["ColorType"]));
									}
								}
								else if (modGlobal.Clean(oRec["SizeType"]) != "")
								{
									if (modGlobal.Clean(oRec["manufacturer_name"]) != "")
									{
										sCellText.Append("   ");
										sCellText.Append(modGlobal.Clean(oRec["SizeType"]));
									}
									else
									{
										sCellText = new System.Text.StringBuilder(modGlobal.Clean(oRec["SizeType"]));
									}
								}
								ViewModel.sprCheckList.Text = sCellText.ToString();
								//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCheckList.MaxTextCellHeight was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
								if (CellHeight < ViewModel.sprCheckList.getMaxTextCellHeight())
								{
									//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCheckList.MaxTextCellHeight was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
									CellHeight = Convert.ToInt32(ViewModel.sprCheckList.getMaxTextCellHeight());
									ViewModel.sprCheckList.SetRowHeight(ViewModel.sprCheckList.Row, CellHeight);
								}
							}
							break;
						}
					}
				}
				else if (SaveName != modGlobal.Clean(oRec["name_full"]))
				{
					if (iPageRow > 25)
					{
						lRow++;
						ViewModel.sprCheckList.Row = lRow;

						//print headings
						ViewModel.sprCheckList.Col = 1;
						ViewModel.sprCheckList.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
						ViewModel.sprCheckList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
						ViewModel.sprCheckList.Text = "Name / WDL #";
						ViewModel.sprCheckList.Col = 2;
						ViewModel.sprCheckList.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
						ViewModel.sprCheckList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
						ViewModel.sprCheckList.Text = "Exp Date";

						//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprCheckList.AddCellSpan was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.sprCheckList.AddCellSpan(3, lRow, 2, 1);
						ViewModel.sprCheckList.Col = 3;
						ViewModel.sprCheckList.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
						ViewModel.sprCheckList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
						ViewModel.sprCheckList.Text = "Coat";

						//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprCheckList.AddCellSpan was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.sprCheckList.AddCellSpan(5, lRow, 2, 1);
						ViewModel.sprCheckList.Col = 5;
						ViewModel.sprCheckList.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
						ViewModel.sprCheckList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
						ViewModel.sprCheckList.Text = "Pants";

						//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprCheckList.AddCellSpan was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.sprCheckList.AddCellSpan(7, lRow, 2, 1);
						ViewModel.sprCheckList.Col = 7;
						ViewModel.sprCheckList.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
						ViewModel.sprCheckList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
						ViewModel.sprCheckList.Text = "Helment";

						//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprCheckList.AddCellSpan was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.sprCheckList.AddCellSpan(10, lRow, 2, 1);
						ViewModel.sprCheckList.Col = 10;
						ViewModel.sprCheckList.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
						ViewModel.sprCheckList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
						ViewModel.sprCheckList.Text = "Flash Hood";

						//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprCheckList.AddCellSpan was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.sprCheckList.AddCellSpan(12, lRow, 2, 1);
						ViewModel.sprCheckList.Col = 12;
						ViewModel.sprCheckList.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
						ViewModel.sprCheckList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
						ViewModel.sprCheckList.Text = "Gloves";

						//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprCheckList.AddCellSpan was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.sprCheckList.AddCellSpan(14, lRow, 2, 1);
						ViewModel.sprCheckList.Col = 14;
						ViewModel.sprCheckList.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
						ViewModel.sprCheckList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
						ViewModel.sprCheckList.Text = "Boots";

						//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprCheckList.AddCellSpan was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.sprCheckList.AddCellSpan(16, lRow, 2, 1);
						ViewModel.sprCheckList.Col = 16;
						ViewModel.sprCheckList.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
						ViewModel.sprCheckList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
						ViewModel.sprCheckList.Text = "Flash Jacket";

						//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCheckList.RowPageBreak was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.sprCheckList.setRowPageBreak(true);
						iPageRow = 1;
					}
					iPageRow++;
					lRow++;
					ViewModel.sprCheckList.Row = lRow;
					sCellText = new System.Text.StringBuilder("");
					ViewModel.sprCheckList.Row = lRow;
					ViewModel.sprCheckList.Col = 1;
					SaveName = modGlobal.Clean(oRec["name_full"]);
					EmployeeCount++;
					ViewModel.sprCheckList.Text = SaveName + "   " + modGlobal.Clean(oRec["license_number"]);
					CellHeight = 20;
					ViewModel.sprCheckList.SetRowHeight(ViewModel.sprCheckList.Row, CellHeight);
					ViewModel.sprCheckList.Col = 2;
					if (modGlobal.Clean(oRec["expiration_date"]) != "")
					{
						ViewModel.sprCheckList.Text = Convert.ToDateTime(oRec["expiration_date"]).ToString("MM/dd/yyyy");
					}
					else
					{
						ViewModel.sprCheckList.Text = modGlobal.Clean(oRec["expiration_date"]);
					}

					SaveItem = modGlobal.Clean(oRec["TurnOut"]);
					ViewModel.sprCheckList.Row = iCodeRow;
					int tempForVar2 = ViewModel.sprCheckList.MaxCols;
					for (int i = 3; i <= tempForVar2; i++)
					{
						ViewModel.sprCheckList.Col = i;
						if (SaveItem == modGlobal.Clean(ViewModel.sprCheckList.Text))
						{
							ViewModel.sprCheckList.Row = lRow;

							sCellText = new System.Text.StringBuilder(modGlobal.Clean(oRec["tracking_number"]));
							if (modGlobal.Clean(oRec["issued_date"]) != "")
							{
								if (modGlobal.Clean(oRec["tracking_number"]) != "")
								{
									sCellText.Append("     ");
									sCellText.Append(Convert.ToDateTime(oRec["issued_date"]).ToString("M/d/yyyy"));
								}
								else
								{
									sCellText = new System.Text.StringBuilder(Convert.ToDateTime(oRec["issued_date"]).ToString("M/d/yyyy"));
								}
							}
							ViewModel.sprCheckList.Text = sCellText.ToString();
							//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCheckList.MaxTextCellHeight was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							CellHeight = Convert.ToInt32(ViewModel.sprCheckList.getMaxTextCellHeight());
							ViewModel.sprCheckList.SetRowHeight(ViewModel.sprCheckList.Row, CellHeight);

							//check to see if we need Brand, etc info...
							ViewModel.sprCheckList.Row = iCodeRow;
							ViewModel.sprCheckList.Col = i + 1;
							if (SaveItem == modGlobal.Clean(ViewModel.sprCheckList.Text))
							{
								ViewModel.sprCheckList.Row = lRow;

								sCellText = new System.Text.StringBuilder(modGlobal.Clean(oRec["manufacturer_name"]));
								if (modGlobal.Clean(oRec["ColorType"]) != "")
								{
									if (modGlobal.Clean(oRec["manufacturer_name"]) != "")
									{
										sCellText.Append(" / ");
										sCellText.Append(modGlobal.Clean(oRec["ColorType"]));
									}
									else
									{
										sCellText = new System.Text.StringBuilder(modGlobal.Clean(oRec["ColorType"]));
									}
								}
								else if (modGlobal.Clean(oRec["SizeType"]) != "")
								{
									if (modGlobal.Clean(oRec["manufacturer_name"]) != "")
									{
										sCellText.Append("   ");
										sCellText.Append(modGlobal.Clean(oRec["SizeType"]));
									}
									else
									{
										sCellText = new System.Text.StringBuilder(modGlobal.Clean(oRec["SizeType"]));
									}
								}
								ViewModel.sprCheckList.Text = sCellText.ToString();
								//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCheckList.MaxTextCellHeight was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
								if (CellHeight < ViewModel.sprCheckList.getMaxTextCellHeight())
								{
									//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCheckList.MaxTextCellHeight was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
									CellHeight = Convert.ToInt32(ViewModel.sprCheckList.getMaxTextCellHeight());
									ViewModel.sprCheckList.SetRowHeight(ViewModel.sprCheckList.Row, CellHeight);
								}
							}
							break;
						}
					}

				}
				else if (SaveItem == modGlobal.Clean(oRec["TurnOut"]))
				{  //same person with 2 of same item
					iPageRow += 2;
					sCellText = new System.Text.StringBuilder("");
					ViewModel.sprCheckList.Row = iCodeRow;
					int tempForVar3 = ViewModel.sprCheckList.MaxCols;
					for (int i = 3; i <= tempForVar3; i++)
					{
						ViewModel.sprCheckList.Col = i;
						if (SaveItem == modGlobal.Clean(ViewModel.sprCheckList.Text))
						{
							ViewModel.sprCheckList.Row = lRow;
							sCellText = new System.Text.StringBuilder(modGlobal.Clean(ViewModel.sprCheckList.Text) + "     ------------");
							sCellText.Append("     " + modGlobal.Clean(oRec["tracking_number"]));
							if (modGlobal.Clean(oRec["issued_date"]) != "")
							{
								if (modGlobal.Clean(oRec["tracking_number"]) != "")
								{
									sCellText.Append("     ");
									sCellText.Append(Convert.ToDateTime(oRec["issued_date"]).ToString("M/d/yyyy"));
								}
								else
								{
									sCellText.Append("     " + Convert.ToDateTime(oRec["issued_date"]).ToString("M/d/yyyy"));
								}
							}
							ViewModel.sprCheckList.Text = sCellText.ToString();
							//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCheckList.MaxTextCellHeight was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							if (CellHeight < ViewModel.sprCheckList.getMaxTextCellHeight())
							{
								//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCheckList.MaxTextCellHeight was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
								CellHeight = Convert.ToInt32(ViewModel.sprCheckList.getMaxTextCellHeight());
								ViewModel.sprCheckList.SetRowHeight(ViewModel.sprCheckList.Row, CellHeight);
							}

							//check to see if we need Brand, etc info...
							ViewModel.sprCheckList.Row = iCodeRow;
							ViewModel.sprCheckList.Col = i + 1;
							if (SaveItem == modGlobal.Clean(ViewModel.sprCheckList.Text))
							{
								ViewModel.sprCheckList.Row = lRow;
								sCellText = new System.Text.StringBuilder(modGlobal.Clean(ViewModel.sprCheckList.Text) + "          ------------");
								sCellText.Append("     " + modGlobal.Clean(oRec["manufacturer_name"]));
								if (modGlobal.Clean(oRec["ColorType"]) != "")
								{
									if (modGlobal.Clean(oRec["manufacturer_name"]) != "")
									{
										sCellText.Append(" / ");
										sCellText.Append(modGlobal.Clean(oRec["ColorType"]));
									}
									else
									{
										sCellText.Append("     " + modGlobal.Clean(oRec["ColorType"]));
									}
								}
								else if (modGlobal.Clean(oRec["SizeType"]) != "")
								{
									if (modGlobal.Clean(oRec["manufacturer_name"]) != "")
									{
										sCellText.Append("   ");
										sCellText.Append(modGlobal.Clean(oRec["SizeType"]));
									}
									else
									{
										sCellText.Append("     " + modGlobal.Clean(oRec["SizeType"]));
									}
								}
								ViewModel.sprCheckList.Text = sCellText.ToString();
								//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCheckList.MaxTextCellHeight was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
								if (CellHeight < ViewModel.sprCheckList.getMaxTextCellHeight())
								{
									//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCheckList.MaxTextCellHeight was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
									CellHeight = Convert.ToInt32(ViewModel.sprCheckList.getMaxTextCellHeight());
									ViewModel.sprCheckList.SetRowHeight(ViewModel.sprCheckList.Row, CellHeight);
								}
							}
							break;
						}
					}

				}
				else
				{
					sCellText = new System.Text.StringBuilder("");
					SaveItem = modGlobal.Clean(oRec["TurnOut"]);
					ViewModel.sprCheckList.Row = iCodeRow;
					int tempForVar4 = ViewModel.sprCheckList.MaxCols;
					for (int i = 3; i <= tempForVar4; i++)
					{
						ViewModel.sprCheckList.Col = i;
						if (SaveItem == modGlobal.Clean(ViewModel.sprCheckList.Text))
						{
							ViewModel.sprCheckList.Row = lRow;

							sCellText = new System.Text.StringBuilder(modGlobal.Clean(oRec["tracking_number"]));
							if (modGlobal.Clean(oRec["issued_date"]) != "")
							{
								if (modGlobal.Clean(oRec["tracking_number"]) != "")
								{
									sCellText.Append("     ");
									sCellText.Append(Convert.ToDateTime(oRec["issued_date"]).ToString("M/d/yyyy"));
								}
								else
								{
									sCellText = new System.Text.StringBuilder(Convert.ToDateTime(oRec["issued_date"]).ToString("M/d/yyyy"));
								}
							}
							ViewModel.sprCheckList.Text = sCellText.ToString();
							//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCheckList.MaxTextCellHeight was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							if (CellHeight < ViewModel.sprCheckList.getMaxTextCellHeight())
							{
								//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCheckList.MaxTextCellHeight was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
								CellHeight = Convert.ToInt32(ViewModel.sprCheckList.getMaxTextCellHeight());
								ViewModel.sprCheckList.SetRowHeight(ViewModel.sprCheckList.Row, CellHeight);
							}

							//check to see if we need Brand, etc info...
							ViewModel.sprCheckList.Row = iCodeRow;
							ViewModel.sprCheckList.Col = i + 1;
							if (SaveItem == modGlobal.Clean(ViewModel.sprCheckList.Text))
							{
								ViewModel.sprCheckList.Row = lRow;

								sCellText = new System.Text.StringBuilder(modGlobal.Clean(oRec["manufacturer_name"]));
								if (modGlobal.Clean(oRec["ColorType"]) != "")
								{
									if (modGlobal.Clean(oRec["manufacturer_name"]) != "")
									{
										sCellText.Append(" / ");
										sCellText.Append(modGlobal.Clean(oRec["ColorType"]));
									}
									else
									{
										sCellText = new System.Text.StringBuilder(modGlobal.Clean(oRec["ColorType"]));
									}
								}
								else if (modGlobal.Clean(oRec["SizeType"]) != "")
								{
									if (modGlobal.Clean(oRec["manufacturer_name"]) != "")
									{
										sCellText.Append("   ");
										sCellText.Append(modGlobal.Clean(oRec["SizeType"]));
									}
									else
									{
										sCellText = new System.Text.StringBuilder(modGlobal.Clean(oRec["SizeType"]));
									}
								}
								ViewModel.sprCheckList.Text = sCellText.ToString();
								//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCheckList.MaxTextCellHeight was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
								if (CellHeight < ViewModel.sprCheckList.getMaxTextCellHeight())
								{
									//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCheckList.MaxTextCellHeight was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
									CellHeight = Convert.ToInt32(ViewModel.sprCheckList.getMaxTextCellHeight());
									ViewModel.sprCheckList.SetRowHeight(ViewModel.sprCheckList.Row, CellHeight);
								}
							}
							break;
						}
					}

				}

				oRec.MoveNext();
			};
			ViewModel.lbCount.Text = "Total Employees = " + EmployeeCount.ToString();
			ViewModel.sprCheckList.MaxRows = ViewModel.sprCheckList.DataRowCnt;
			ViewModel.cmdPrintChecklist.Enabled = true;

		}

		[UpgradeHelpers.Events.Handler]
		internal void chkOldFormat_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.PrintOldFormat = ViewModel.chkOldFormat.CheckState == UpgradeHelpers.Helpers.CheckState.Checked;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdExit_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrintChecklist_Click(Object eventSender, System.EventArgs eventArgs)
		{

			if ( ViewModel.PrintOldFormat)
			{
				FormatPPECheckList2();
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCheckList2.PrintFooter was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprCheckList2.setPrintFooter("/nPrinted on " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "/c Page /p of /pc");
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCheckList2.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprCheckList2.setPrintAbortMsg("Printing older version PPE Inspection Checklist - Click Cancel to quit");
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCheckList2.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprCheckList2.setPrintBorder(false);
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCheckList2.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprCheckList2.setPrintColor(true);
				//        sprCheckList2.PrintOrientation = 1
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCheckList2.PrintSmartPrint was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprCheckList2.setPrintSmartPrint(true);
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprCheckList2.PrintSheet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				//object tempRefParam = null;
				//WEBMAP_UPGRADE_ISSUE: (1101) FarPoint.Win.Spread.FpSpread.PrintSheet was not upgraded
				ViewModel.sprCheckList2.PrintSheet(null);
			}
			else
			{
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCheckList.PrintHeader was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprCheckList.setPrintHeader("/l" + ViewModel.sHeadingFilter);
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCheckList.PrintFooter was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprCheckList.setPrintFooter("/nPrinted on " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "/c Page /p of /pc");
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCheckList.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprCheckList.setPrintAbortMsg("Printing new PPE Inspection Checklist - Click Cancel to quit");
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCheckList.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprCheckList.setPrintColor(true);
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCheckList.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprCheckList.setPrintBorder(false);
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCheckList.PrintColHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprCheckList.setPrintColHeaders(true);
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCheckList.PrintSmartPrint was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprCheckList.setPrintSmartPrint(true);
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprCheckList.PrintSheet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				//object tempRefParam2 = null;
				//WEBMAP_UPGRADE_ISSUE: (1101) FarPoint.Win.Spread.FpSpread.PrintSheet was not upgraded
				ViewModel.sprCheckList.PrintSheet(null);
			}


		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			ViewModel.CurrBatt = modGlobal.Shared.gUniformBatt;
			ViewModel.CurrShift = modGlobal.Shared.gUniformShift;
			ViewModel.PrintOldFormat = false;

			FormatHeadings();
			FormatPPECheckList();


		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmUniformCheckList DefInstance
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

		public static frmUniformCheckList CreateInstance()
		{
			PTSProject.frmUniformCheckList theInstance = Shared.Container.Resolve< frmUniformCheckList>();
			theInstance.Form_Load();
			return theInstance;
		}

		protected override void ExecuteControlsStartup()
		{
			ViewModel.sprCheckList2.LifeCycleStartup();
			ViewModel.sprCheckList.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprCheckList2.LifeCycleShutdown();
			ViewModel.sprCheckList.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmUniformCheckList
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmUniformCheckListViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmUniformCheckList m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}