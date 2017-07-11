using System;
using UpgradeHelpers.DB.ADO;
using UpgradeStubs;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident
{

	public partial class frmQueryResults
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.frmQueryResultsViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmQueryResults));
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


		private void frmQueryResults_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		//UPGRADE_ISSUE: (2068) PrintOrientationConstants object was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2068.aspx
		//UPGRADE_ISSUE: (2064) FPSpread.PrintOrientationConstants property PrintOrientationConstants.PrintOrientationDefault was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx

		private void FillSpread()
		{
			//FillSpread with Results from DataInquiry Recordset
			TFDIncident.clsInquiry InquiryCL = Container.Resolve< clsInquiry>();
			int cWidth = 0, c1stWidth = 0;
			double QueryWidth = 0;
			int QueryCounter = 0;
			//Summary total counters
			int F2Total = 0, F1Total = 0, GrandTotal = 0;
			//Subtotal break parameters
			string F2Title = "", F1Title = "", sWork = "";

			if (~InquiryCL.GetInquiryManager(IncidentMain.Shared.gCurrentQuery) != 0)
			{
				ViewManager.ShowMessage("Error Formating Query Results", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				ViewManager.DisposeView(this);
			}
			if (IncidentMain.Shared.gQueryRecordset.EOF)
			{
				ViewManager.ShowMessage("Error Formating Query Results", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				ViewManager.DisposeView(this);
			}
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
			this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.WaitCursor);
			ViewModel.sprQuery.Row = 3;
			ViewModel.sprQuery.Col = 6;
			ViewModel.sprQuery.Text = DateTime.Now.ToString("M/d/yyyy");
			ViewModel.sprQuery.Row = 4;
			ViewModel.sprQuery.Col = 1;
			ViewModel.sprQuery.Text = InquiryCL.InquiryDisplay;
			ViewModel.sprQuery.Row = 5;
			int TotalColumns = 0;

			for (int i = 0; i <= IncidentMain.Shared.gQueryRecordset.FieldsMetadata.Count - 1; i++)
			{
				TotalColumns++;
				ViewModel.sprQuery.Col = TotalColumns;
				if (IncidentMain.Shared.gQueryRecordset.GetField(i).FieldMetadata.ColumnName == "sum_total")
				{
					ViewModel.sprQuery.Text = "Count";
				}
				else
				{
					ViewModel.sprQuery.Text = InquiryCL.GetFieldDisplay(IncidentMain.Shared.gCurrentQuery, IncidentMain.Shared.gQueryRecordset.GetField(i).FieldMetadata.ColumnName);
				}
				ViewModel.sprQuery.FontBold = true;
			}
			ViewModel.sprQuery.BlockMode = true;
			ViewModel.sprQuery.Row = 5;
			ViewModel.sprQuery.Row2 = 5;
			ViewModel.sprQuery.Col = 1;
			ViewModel.sprQuery.Col2 = TotalColumns;
			ViewModel.sprQuery.Action = FarPoint.ViewModels.FPActionConstants.ActionSetCellBorder;
			ViewModel.sprQuery.Action = FarPoint.ViewModels.FPActionConstants.ActionSetCellBorder;
			ViewModel.sprQuery.BlockMode = false;

			int CurrRow = 6;
			int iFirstRow = -1;
			if (InquiryCL.InquiryOrderBy == "Summary")
			{
				//*************************************************
				//**  Summary Queries                           ***
				//*************************************************
				//Clear Subtotal break parameters
				F1Total = 0;
				F2Total = 0;
				GrandTotal = 0;
				F1Title = "";
				F2Title = "";

				//Reformat Print Date
				ViewModel.sprQuery.Row = 3;
				ViewModel.sprQuery.Col = 5;
				ViewModel.sprQuery.Text = "";
				ViewModel.sprQuery.Col = 6;
				ViewModel.sprQuery.Text = "";
				ViewModel.sprQuery.Col = 2;
				ViewModel.sprQuery.Text = "Print Date:";
				ViewModel.sprQuery.Col = 3;
				ViewModel.sprQuery.Text = DateTime.Now.ToString("M/d/yyyy");

				//If Date parameters used - display
				if (IncidentMain.Shared.gQueryStartDate != "" && IncidentMain.Shared.gQueryEndDate != "")
				{
					ViewModel.sprQuery.Row = 3;
					ViewModel.sprQuery.Col = 2;
					ViewModel.sprQuery.Text = "Start Date: " + IncidentMain.Shared.gQueryStartDate;
					ViewModel.sprQuery.Col = 3;
					ViewModel.sprQuery.Text = "End Date: " + IncidentMain.Shared.gQueryEndDate;
				}
				ViewModel.sprQuery.Row = CurrRow;
				switch(TotalColumns)
				{
					case 2 :
						ViewModel.sprQuery.Col = 1;
						if (IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(0)) != "")
						{
							ViewModel.sprQuery.Text = IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(0));
						}
						else
						{
							ViewModel.sprQuery.Text = "Not Recorded";
						}
						ViewModel.sprQuery.Col = 2;
						ViewModel.sprQuery.Text = Convert.ToString(IncidentMain.Shared.gQueryRecordset[1]);
						GrandTotal = Convert.ToInt32(IncidentMain.Shared.gQueryRecordset[1]);
						//set Column Widths 
						ViewModel.sprQuery.SetColWidth(1, 40);
						ViewModel.sprQuery.SetColWidth(2, 15);
						break;
					case 3 :
						if (IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(0)) != "")
						{
							F1Title = IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(0));
						}
						else
						{
							F1Title = "Not Recorded";
						}
						ViewModel.sprQuery.Col = 1;
						ViewModel.sprQuery.Text = F1Title;
						ViewModel.sprQuery.Col = 2;
						if (IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(1)) != "")
						{
							F2Title = IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(1));
						}
						else
						{
							F2Title = "Not Recorded";
						}
						ViewModel.sprQuery.Text = F2Title;
						ViewModel.sprQuery.Col = 3;
						if (IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(2)) != "")
						{
							ViewModel.sprQuery.Text = IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(2));
						}
						else
						{
							ViewModel.sprQuery.Text = "Not Recorded";
						}
						F1Total = Convert.ToInt32(IncidentMain.Shared.gQueryRecordset[2]);
						GrandTotal = F1Total;
						//set Column Widths 
						ViewModel.sprQuery.SetColWidth(1, 40);
						ViewModel.sprQuery.SetColWidth(2, 40);
						ViewModel.sprQuery.SetColWidth(3, 15);
						break;
					case 4 :
						if (IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(0)) != "")
						{
							F1Title = IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(0));
						}
						else
						{
							F1Title = "Not Recorded";
						}
						ViewModel.sprQuery.Col = 1;
						ViewModel.sprQuery.Text = F1Title;
						if (IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(1)) != "")
						{
							F2Title = IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(1));
						}
						else
						{
							F2Title = "Not Recorded";
						}
						ViewModel.sprQuery.Col = 2;
						ViewModel.sprQuery.Text = F2Title;
						ViewModel.sprQuery.Col = 3;
						if (IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(2)) != "")
						{
							ViewModel.sprQuery.Text = IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(2));
						}
						else
						{
							ViewModel.sprQuery.Text = "Not Recorded";
						}
						ViewModel.sprQuery.Col = 4;
						ViewModel.sprQuery.Text = Convert.ToString(IncidentMain.Shared.gQueryRecordset[3]);
						F1Total = Convert.ToInt32(IncidentMain.Shared.gQueryRecordset[3]);
						F2Total = F1Total;
						GrandTotal = F1Total;
						ViewModel.sprQuery.SetColWidth(1, 40);
						ViewModel.sprQuery.SetColWidth(2, 40);
						ViewModel.sprQuery.SetColWidth(3, 40);
						ViewModel.sprQuery.SetColWidth(4, 15);
						break;
				}

				IncidentMain.Shared.gQueryRecordset.MoveNext();
				CurrRow++;


				while(!IncidentMain.Shared.gQueryRecordset.EOF)
				{
					ViewModel.sprQuery.Row = CurrRow;
					//Test for subtotal breaks
					switch(TotalColumns)
					{
						case 2 :
							//No Subtotals - just Grand Total 
							ViewModel.sprQuery.Col = 1;
							ViewModel.sprQuery.Text = IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(0));
							ViewModel.sprQuery.Col = 2;
							ViewModel.sprQuery.Text = Convert.ToString(IncidentMain.Shared.gQueryRecordset[1]);
							GrandTotal = Convert.ToInt32(GrandTotal + Convert.ToDouble(IncidentMain.Shared.gQueryRecordset[1]));
							break;
						case 3 :
							if (IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(0)) != "")
							{
								sWork = IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(0));
							}
							else
							{
								sWork = "Not Recorded";
							}
							if (sWork != F1Title)
							{
								//Subtotal primary field
								ViewModel.sprQuery.Col = 1;
								ViewModel.sprQuery.Text = F1Title + ": Subtotal";
								ViewModel.sprQuery.Col = 3;
								ViewModel.sprQuery.Text = F1Total.ToString();
								ViewModel.sprQuery.BlockMode = true;
								ViewModel.sprQuery.Row = CurrRow;
								ViewModel.sprQuery.Row2 = CurrRow;
								ViewModel.sprQuery.Col = 1;
								ViewModel.sprQuery.Col2 = TotalColumns;
								ViewModel.sprQuery.Action = FarPoint.ViewModels.FPActionConstants.ActionSetCellBorder;
								ViewModel.sprQuery.Action = FarPoint.ViewModels.FPActionConstants.ActionSetCellBorder;
								ViewModel.sprQuery.BlockMode = false;
								CurrRow += 2;
								ViewModel.sprQuery.Row = CurrRow;
								ViewModel.sprQuery.Col = 1;
								ViewModel.sprQuery.Text = IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(0));
								F1Title = IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(0));
								ViewModel.sprQuery.Col = 2;
								ViewModel.sprQuery.Text = IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(1));
								ViewModel.sprQuery.Col = 3;
								ViewModel.sprQuery.Text = Convert.ToString(IncidentMain.Shared.gQueryRecordset[2]);
								F1Total = Convert.ToInt32(IncidentMain.Shared.gQueryRecordset[2]);
								GrandTotal = Convert.ToInt32(GrandTotal + Convert.ToDouble(IncidentMain.Shared.gQueryRecordset[2]));
							}
							else
							{
								//another row
								ViewModel.sprQuery.Col = 2;
								ViewModel.sprQuery.Text = IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(1));
								ViewModel.sprQuery.Col = 3;
								ViewModel.sprQuery.Text = Convert.ToString(IncidentMain.Shared.gQueryRecordset[2]);
								F1Total = Convert.ToInt32(F1Total + Convert.ToDouble(IncidentMain.Shared.gQueryRecordset[2]));
								GrandTotal = Convert.ToInt32(GrandTotal + Convert.ToDouble(IncidentMain.Shared.gQueryRecordset[2]));
							}
							break;
						case 4 :
							if (IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(0)) != "")
							{
								sWork = IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(0));
							}
							else
							{
								sWork = "Not Recorded";
							}
							if (sWork != F1Title)
							{
								//Subtotal secondary field
								ViewModel.sprQuery.Col = 2;
								ViewModel.sprQuery.Text = F2Title + ": Subtotal";
								ViewModel.sprQuery.Col = 4;
								ViewModel.sprQuery.Text = F2Total.ToString();
								ViewModel.sprQuery.BlockMode = true;
								ViewModel.sprQuery.Row = CurrRow;
								ViewModel.sprQuery.Row2 = CurrRow;
								ViewModel.sprQuery.Col = 2;
								ViewModel.sprQuery.Col2 = TotalColumns;
								ViewModel.sprQuery.Action = FarPoint.ViewModels.FPActionConstants.ActionSetCellBorder;
								ViewModel.sprQuery.Action = FarPoint.ViewModels.FPActionConstants.ActionSetCellBorder;
								ViewModel.sprQuery.BlockMode = false;
								CurrRow++;
								ViewModel.sprQuery.Row = CurrRow;
								//Subtotal primary field
								ViewModel.sprQuery.Col = 1;
								ViewModel.sprQuery.Text = F1Title + ": Subtotal";
								ViewModel.sprQuery.Col = 4;
								ViewModel.sprQuery.Text = F1Total.ToString();
								ViewModel.sprQuery.BlockMode = true;
								ViewModel.sprQuery.Row = CurrRow;
								ViewModel.sprQuery.Row2 = CurrRow;
								ViewModel.sprQuery.Col = 1;
								ViewModel.sprQuery.Col2 = TotalColumns;
								ViewModel.sprQuery.Action = FarPoint.ViewModels.FPActionConstants.ActionSetCellBorder;
								ViewModel.sprQuery.Action = FarPoint.ViewModels.FPActionConstants.ActionSetCellBorder;
								ViewModel.sprQuery.BlockMode = false;
								CurrRow += 2;
								ViewModel.sprQuery.Row = CurrRow;
								ViewModel.sprQuery.Col = 1;
								ViewModel.sprQuery.Text = IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(0));
								F1Title = IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(0));
								ViewModel.sprQuery.Col = 2;
								ViewModel.sprQuery.Text = IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(1));
								F2Title = IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(1));
								ViewModel.sprQuery.Col = 3;
								ViewModel.sprQuery.Text = IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(2));
								ViewModel.sprQuery.Col = 4;
								ViewModel.sprQuery.Text = Convert.ToString(IncidentMain.Shared.gQueryRecordset[3]);
								F2Total = Convert.ToInt32(IncidentMain.Shared.gQueryRecordset[3]);
								F1Total = Convert.ToInt32(IncidentMain.Shared.gQueryRecordset[3]);
								GrandTotal = Convert.ToInt32(GrandTotal + Convert.ToDouble(IncidentMain.Shared.gQueryRecordset[3]));
							}
							else
							{
								if (IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(1)) != "")
								{
									sWork = IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(1));
								}
								else
								{
									sWork = "Not Recorded";
								}
								if (sWork != F2Title)
								{
									//Subtotal Secondary field
									ViewModel.sprQuery.Col = 2;
									ViewModel.sprQuery.Text = F2Title + ": Subtotal";
									ViewModel.sprQuery.Col = 4;
									ViewModel.sprQuery.Text = F2Total.ToString();
									ViewModel.sprQuery.BlockMode = true;
									ViewModel.sprQuery.Row = CurrRow;
									ViewModel.sprQuery.Row2 = CurrRow;
									ViewModel.sprQuery.Col = 2;
									ViewModel.sprQuery.Col2 = TotalColumns;
									ViewModel.sprQuery.Action = FarPoint.ViewModels.FPActionConstants.ActionSetCellBorder;
									ViewModel.sprQuery.Action = FarPoint.ViewModels.FPActionConstants.ActionSetCellBorder;
									ViewModel.sprQuery.BlockMode = false;
									CurrRow += 2;
									ViewModel.sprQuery.Row = CurrRow;
									ViewModel.sprQuery.Col = 2;
									if (IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(1)) != "")
									{
										F2Title = IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(1));
									}
									else
									{
										F2Title = "Not Recorded";
									}
									ViewModel.sprQuery.Text = F2Title;
									ViewModel.sprQuery.Col = 3;
									ViewModel.sprQuery.Text = IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(2));
									ViewModel.sprQuery.Col = 4;
									ViewModel.sprQuery.Text = Convert.ToString(IncidentMain.Shared.gQueryRecordset[3]);
									F2Total = Convert.ToInt32(IncidentMain.Shared.gQueryRecordset[3]);
									F1Total = Convert.ToInt32(F1Total + Convert.ToDouble(IncidentMain.Shared.gQueryRecordset[3]));
									GrandTotal = Convert.ToInt32(GrandTotal + Convert.ToDouble(IncidentMain.Shared.gQueryRecordset[3]));
								}
								else
								{
									//another row
									ViewModel.sprQuery.Col = 3;
									if (IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(2)) != "")
									{
										ViewModel.sprQuery.Text = IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(2));
									}
									else
									{
										ViewModel.sprQuery.Text = "Not Recorded";
									}
									ViewModel.sprQuery.Col = 4;
									ViewModel.sprQuery.Text = Convert.ToString(IncidentMain.Shared.gQueryRecordset[3]);
									F2Total = Convert.ToInt32(F2Total + Convert.ToDouble(IncidentMain.Shared.gQueryRecordset[3]));
									F1Total = Convert.ToInt32(F1Total + Convert.ToDouble(IncidentMain.Shared.gQueryRecordset[3]));
									GrandTotal = Convert.ToInt32(GrandTotal + Convert.ToDouble(IncidentMain.Shared.gQueryRecordset[3]));
								}
							}

							break;
					}

					IncidentMain.Shared.gQueryRecordset.MoveNext();
					CurrRow++;
				};
				//Last set of totals
				ViewModel.sprQuery.Row = CurrRow;
				switch(TotalColumns)
				{
					case 2 :
						//Just Grand Total 
						ViewModel.sprQuery.Row = CurrRow + 1;
						ViewModel.sprQuery.Col = 1;
						ViewModel.sprQuery.Text = "Grand Total";
						ViewModel.sprQuery.Col = 2;
						ViewModel.sprQuery.Text = GrandTotal.ToString();
						ViewModel.sprQuery.BlockMode = true;
						ViewModel.sprQuery.Row = CurrRow;
						ViewModel.sprQuery.Row2 = CurrRow;
						ViewModel.sprQuery.Col = 1;
						ViewModel.sprQuery.Col2 = TotalColumns;
						{
						}
						ViewModel.sprQuery.Action = FarPoint.ViewModels.FPActionConstants.ActionSetCellBorder;
						{
						}
						{
						}
						ViewModel.sprQuery.Action = FarPoint.ViewModels.FPActionConstants.ActionSetCellBorder;
						ViewModel.sprQuery.BlockMode = false;
						break;
					case 3 :
						//Subtotal primary field 
						ViewModel.sprQuery.Col = 1;
						ViewModel.sprQuery.Text = F1Title + ": Subtotal";
						ViewModel.sprQuery.Col = 3;
						ViewModel.sprQuery.Text = F1Total.ToString();
						ViewModel.sprQuery.BlockMode = true;
						ViewModel.sprQuery.Row = CurrRow;
						ViewModel.sprQuery.Row2 = CurrRow;
						ViewModel.sprQuery.Col = 1;
						ViewModel.sprQuery.Col2 = TotalColumns;
						{
						}
						ViewModel.sprQuery.Action = FarPoint.ViewModels.FPActionConstants.ActionSetCellBorder;
						{
						}
						{
						}
						ViewModel.sprQuery.Action = FarPoint.ViewModels.FPActionConstants.ActionSetCellBorder;
						ViewModel.sprQuery.BlockMode = false;
						CurrRow += 2;
						ViewModel.sprQuery.Row = CurrRow;
						ViewModel.sprQuery.Col = 1;
						ViewModel.sprQuery.Text = "Grand Total";
						ViewModel.sprQuery.Col = 3;
						ViewModel.sprQuery.Text = GrandTotal.ToString();
						ViewModel.sprQuery.BlockMode = true;
						ViewModel.sprQuery.Row = CurrRow;
						ViewModel.sprQuery.Row2 = CurrRow;
						ViewModel.sprQuery.Col = 1;
						ViewModel.sprQuery.Col2 = TotalColumns;
						{
						}
						ViewModel.sprQuery.Action = FarPoint.ViewModels.FPActionConstants.ActionSetCellBorder;
						{
						}
						{
						}
						ViewModel.sprQuery.Action = FarPoint.ViewModels.FPActionConstants.ActionSetCellBorder;
						ViewModel.sprQuery.BlockMode = false;
						break;
					case 4 :
						//Subtotal secondary field 
						ViewModel.sprQuery.Col = 2;
						ViewModel.sprQuery.Text = F2Title + ": Subtotal";
						ViewModel.sprQuery.Col = 4;
						ViewModel.sprQuery.Text = F2Total.ToString();
						ViewModel.sprQuery.BlockMode = true;
						ViewModel.sprQuery.Row = CurrRow;
						ViewModel.sprQuery.Row2 = CurrRow;
						ViewModel.sprQuery.Col = 2;
						ViewModel.sprQuery.Col2 = TotalColumns;
						{
						}
						ViewModel.sprQuery.Action = FarPoint.ViewModels.FPActionConstants.ActionSetCellBorder;
						{
						}
						{
						}
						ViewModel.sprQuery.Action = FarPoint.ViewModels.FPActionConstants.ActionSetCellBorder;
						ViewModel.sprQuery.BlockMode = false;
						CurrRow++;
						ViewModel.sprQuery.Row = CurrRow;
						//Subtotal primary field 
						ViewModel.sprQuery.Col = 1;
						ViewModel.sprQuery.Text = F1Title + ": Subtotal";
						ViewModel.sprQuery.Col = 4;
						ViewModel.sprQuery.Text = F1Total.ToString();
						ViewModel.sprQuery.BlockMode = true;
						ViewModel.sprQuery.Row = CurrRow;
						ViewModel.sprQuery.Row2 = CurrRow;
						ViewModel.sprQuery.Col = 1;
						ViewModel.sprQuery.Col2 = TotalColumns;
						{
						}
						ViewModel.sprQuery.Action = FarPoint.ViewModels.FPActionConstants.ActionSetCellBorder;
						{
						}
						{
						}
						ViewModel.sprQuery.Action = FarPoint.ViewModels.FPActionConstants.ActionSetCellBorder;
						ViewModel.sprQuery.BlockMode = false;
						CurrRow += 2;
						ViewModel.sprQuery.Row = CurrRow;
						ViewModel.sprQuery.Col = 1;
						ViewModel.sprQuery.Text = "Grand Total";
						ViewModel.sprQuery.Col = 4;
						ViewModel.sprQuery.Text = GrandTotal.ToString();
						ViewModel.sprQuery.BlockMode = true;
						ViewModel.sprQuery.Row = CurrRow;
						ViewModel.sprQuery.Row2 = CurrRow;
						ViewModel.sprQuery.Col = 1;
						ViewModel.sprQuery.Col2 = TotalColumns;
						{
						}
						ViewModel.sprQuery.Action = FarPoint.ViewModels.FPActionConstants.ActionSetCellBorder;
						{
						}
						{
						}
						ViewModel.sprQuery.Action = FarPoint.ViewModels.FPActionConstants.ActionSetCellBorder;
						ViewModel.sprQuery.BlockMode = false;
						break;
				}

			}
			else
			{
				//*************************************************
				//**  Regular View Queries                      ***
				//*************************************************


				while(!IncidentMain.Shared.gQueryRecordset.EOF)
				{
					ViewModel.sprQuery.Row = CurrRow;
					for (int i = 0; i <= TotalColumns - 1; i++)
					{
						ViewModel.sprQuery.Col = i + 1;
						ViewModel.sprQuery.Text = IncidentMain.Clean(IncidentMain.Shared.gQueryRecordset.GetField(i));
						if (iFirstRow != 0)
						{
							if (i == 0)
							{
								//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprQuery.MaxTextCellWidth was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
								c1stWidth = Convert.ToInt32(ViewModel.sprQuery.getMaxTextCellWidth());
								iFirstRow = 0;
							}
						}
					}
					IncidentMain.Shared.gQueryRecordset.MoveNext();
					CurrRow++;
					QueryCounter++;
					if (QueryCounter > 999)
					{
						ViewManager.ShowMessage("Your Query has exceeded the 1000 record limit", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Information);
						break;
					}
				};
				QueryWidth = 0;
				for (int i = 1; i <= TotalColumns; i++)
				{
					cWidth = Convert.ToInt32(ViewModel.sprQuery.ActiveSheet.GetPreferredColumnWidth(i, true));
					if (i == 1)
					{
						ViewModel.sprQuery.SetColWidth(i, c1stWidth + 5);
						QueryWidth = QueryWidth + c1stWidth + 5;
					}
					else
					{
						ViewModel.sprQuery.SetColWidth(i, cWidth + 1);
						QueryWidth = QueryWidth + cWidth + 1;
					}
				}

				if (QueryWidth > 99)
				{
					//UPGRADE_ISSUE: (2064) FPSpread.PrintOrientationConstants property PrintOrientationConstants.PrintOrientationLandscape was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.PrintOry = UpgradeStubs.FPSpread_PrintOrientationConstants.getPrintOrientationLandscape();
				}
				else
				{
					//UPGRADE_ISSUE: (2064) FPSpread.PrintOrientationConstants property PrintOrientationConstants.PrintOrientationPortrait was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.PrintOry = UpgradeStubs.FPSpread_PrintOrientationConstants.getPrintOrientationPortrait();
				}

			}
			ViewModel.sprQuery.MaxRows = CurrRow + 2;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
			this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.Arrow);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Print Spread
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprQuery.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprQuery.setPrintAbortMsg("Printing Query Results - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprQuery.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprQuery.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprQuery.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprQuery.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprQuery.PrintOrientation was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprQuery.setPrintOrientation(ViewModel.PrintOry);
			ViewModel.sprQuery.Action = FarPoint.ViewModels.FPActionConstants.ActionSmartPrint;

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			FillSpread();
			IncidentMain.MoveForm(frmQueryResults.DefInstance);
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmQueryResults DefInstance
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

		public static frmQueryResults CreateInstance()
		{
			TFDIncident.frmQueryResults theInstance = Shared.Container.Resolve< frmQueryResults>();
			theInstance.Form_Load();
			//The MDI form in the VB6 project had its
			//AutoShowChildren property set to True
			//To simulate the VB6 behavior, we need to
			//automatically Show the form whenever it
			//is loaded.  If you do not want this behavior
			//then delete the following line of code
			//UPGRADE_TODO: (2018) Remove the next line of code to stop form from automatically showing. More Information: http://www.vbtonet.com/ewis/ewi2018.aspx
			Shared.ViewManager.NavigateToView(
				//The MDI form in the VB6 project had its
				//AutoShowChildren property set to True
				//To simulate the VB6 behavior, we need to
				//automatically Show the form whenever it
				//is loaded.  If you do not want this behavior
				//then delete the following line of code
				//UPGRADE_TODO: (2018) Remove the next line of code to stop form from automatically showing. More Information: http://www.vbtonet.com/ewis/ewi2018.aspx
				theInstance
				);
			return theInstance;
		}

		void ReLoadForm(bool addEvents)
		{
			using ( var async1 = this.Async(true) )
			{
				async1.Append<TFDIncident.MDIIncident>(() => TFDIncident.MDIIncident.DefInstance);
				//This form is an MDI child.
				//This code simulates the VB6 
				// functionality of automatically
				// loading and showing an MDI
				// child's parent.
				;
				async1.Append<TFDIncident.MDIIncident>(() =>
					TFDIncident.MDIIncident.DefInstance);
				async1.Append<TFDIncident.MDIIncident>(tempNormalized1 =>
					{
						ViewManager.NavigateToView(tempNormalized1);
					});
			}
		}

		protected override void ExecuteControlsStartup()
		{
			ViewModel.sprQuery.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprQuery.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmQueryResults
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.frmQueryResultsViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmQueryResults m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}