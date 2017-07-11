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

	public partial class frmHazmatLeave
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmHazmatLeaveViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmHazmatLeave));
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


		private void frmHazmatLeave_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		public void FormatReport2()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			int CurrRow = 3;
			int PrevCol = 0;
			int WeekRow = 4;
			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			oCmd.CommandText = "spSelect_HazmatMonthlySchedLeave " + ViewModel.ThisYear.ToString() + ", " + ViewModel.ThisMonth.ToString() + " ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (oRec.EOF)
			{
				ViewManager.ShowMessage("There are no Staffing Records for this month", "Hazmat Monthly Scheduled Leave Report", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			while(!oRec.EOF)
			{
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.sprMonth2.Col = Convert.ToInt32(modGlobal.GetVal(oRec["DayColumn"]));
				if (modGlobal.Clean(oRec["TimeCode"]) == "")
				{ //Header Row
					if (PrevCol == 0)
					{ //First Time
						//set up Day/Shift
						PrevCol = ViewModel.sprMonth2.Col;
						ViewModel.sprMonth2.Col = PrevCol;
						ViewModel.sprMonth2.Row = CurrRow;
						ViewModel.sprMonth2.FontBold = true;
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprMonth2.Text = Convert.ToString(modGlobal.GetVal(oRec["DayNum"])) + "  " + modGlobal.Clean(oRec["shift_code"]);
						WeekRow = CurrRow;
						CurrRow++;

					}
					else if ( ViewModel.sprMonth2.Col < PrevCol)
					{  //need to move to next row
						//set up Day/Shift and fill in name
						PrevCol = ViewModel.sprMonth2.Col;
						ViewModel.sprMonth2.Col = PrevCol;
						CurrRow += 12;
						ViewModel.sprMonth2.Row = CurrRow;
						ViewModel.sprMonth2.FontBold = true;
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprMonth2.Text = Convert.ToString(modGlobal.GetVal(oRec["DayNum"])) + "  " + modGlobal.Clean(oRec["shift_code"]);
						WeekRow = CurrRow;
						CurrRow++;

					}
					else if ( ViewModel.sprMonth2.Col > PrevCol)
					{
						PrevCol = ViewModel.sprMonth2.Col;
						ViewModel.sprMonth2.Col = PrevCol;
						CurrRow--;
						ViewModel.sprMonth2.Row = CurrRow;
						ViewModel.sprMonth2.FontBold = true;
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprMonth2.Text = Convert.ToString(modGlobal.GetVal(oRec["DayNum"])) + "  " + modGlobal.Clean(oRec["shift_code"]);
						WeekRow = CurrRow;
						CurrRow++;

					} //same column/row... fall through and read next record
				}
				else
				{
					ViewModel.sprMonth2.Col = PrevCol;
					WeekRow++;
					ViewModel.sprMonth2.Row = WeekRow;
					ViewModel.sprMonth2.FontBold = false;
					ViewModel.sprMonth2.Text = modGlobal.Clean(oRec["Employee"]);
					switch(modGlobal.Clean(oRec["TimeCode"]))
					{
						case "DDF" :
							{
							}
							break;
						case "VAC" : case "PTO" : case "VACFML" : case "PTOFML" :
							{
							}
							break;
						case "FHL" : case "FHLFML" :
							{
							}
							break;
						default:
							{
							}
							break;
					}
				}
				oRec.MoveNext();
			};
		}

		public void ClearReport()
		{
			ViewModel.sprMonth2.Row = 3;
			ViewModel.sprMonth2.Row2 = ViewModel.sprMonth2.MaxRows;
			ViewModel.sprMonth2.Col = 1;
			ViewModel.sprMonth2.Col2 = ViewModel.sprMonth2.MaxCols;
			ViewModel.sprMonth2.BlockMode = true;
			ViewModel.sprMonth2.Text = "";
			ViewModel.sprMonth2.BlockMode = false;

		}

		public void FormatReport()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			int CurrRow = 3;
			int PrevCol = 0;
			int WeekRow = 4;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			oCmd.CommandText = "spSelect_HazmatMonthlySchedLeave " + ViewModel.ThisYear.ToString() + ", " + ViewModel.ThisMonth.ToString() + " ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (oRec.EOF)
			{
				ViewManager.ShowMessage("There are no Staffing Records for this month", "Hazmat Monthly Scheduled Leav Report", UpgradeHelpers.Helpers.BoxButtons.OK);

				return;
			}

			while(!oRec.EOF)
			{

				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.sprMonth2.Col = Convert.ToInt32(modGlobal.GetVal(oRec["DayColumn"]));

				if (PrevCol == 0)
				{ //First Time
					//set up Day/Shift and fill in name
					PrevCol = ViewModel.sprMonth2.Col;
					ViewModel.sprMonth2.Col = PrevCol;
					ViewModel.sprMonth2.Row = CurrRow;
					ViewModel.sprMonth2.FontBold = true;
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.sprMonth2.Text = Convert.ToString(modGlobal.GetVal(oRec["DayNum"])) + "  " + modGlobal.Clean(oRec["shift_code"]);

					CurrRow++;
					WeekRow = CurrRow;
					ViewModel.sprMonth2.Row = WeekRow;
					ViewModel.sprMonth2.FontBold = false;
					if (modGlobal.Clean(oRec["TimeCode"]) != "")
					{
						ViewModel.sprMonth2.Text = modGlobal.Clean(oRec["Employee"]);
						switch(modGlobal.Clean(oRec["TimeCode"]))
						{
							case "DDF" :
								{
								}
								break;
							case "VAC" : case "PTO" : case "VACFML" : case "PTOFML" :
								{
								}
								break;
							case "FHL" : case "FHLFML" :
								{
								}
								break;
							default:
								{
								}
								break;
						}
					}
					else
					{
						//                sprMonth2.Text = ""
					}

				}
				else if ( ViewModel.sprMonth2.Col < PrevCol)
				{  //need to move to next row
					//set up Day/Shift and fill in name
					PrevCol = ViewModel.sprMonth2.Col;
					ViewModel.sprMonth2.Col = PrevCol;
					CurrRow += 12;
					ViewModel.sprMonth2.Row = CurrRow;
					ViewModel.sprMonth2.FontBold = true;
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.sprMonth2.Text = Convert.ToString(modGlobal.GetVal(oRec["DayNum"])) + "  " + modGlobal.Clean(oRec["shift_code"]);

					CurrRow++;
					WeekRow = CurrRow;
					ViewModel.sprMonth2.Row = WeekRow;
					ViewModel.sprMonth2.FontBold = false;
					if (modGlobal.Clean(oRec["TimeCode"]) != "")
					{
						ViewModel.sprMonth2.Text = modGlobal.Clean(oRec["Employee"]);
						switch(modGlobal.Clean(oRec["TimeCode"]))
						{
							case "DDF" :
								{
								}
								break;
							case "VAC" : case "PTO" : case "VACFML" : case "PTOFML" :
								{
								}
								break;
							case "FHL" : case "FHLFML" :
								{
								}
								break;
							default:
								{
								}
								break;
						}
					}
					else
					{
						//                sprMonth2.Text = ""
					}

				}
				else if ( ViewModel.sprMonth2.Col > PrevCol)
				{
					PrevCol = ViewModel.sprMonth2.Col;
					ViewModel.sprMonth2.Col = PrevCol;
					CurrRow--;
					ViewModel.sprMonth2.Row = CurrRow;
					ViewModel.sprMonth2.FontBold = true;
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.sprMonth2.Text = Convert.ToString(modGlobal.GetVal(oRec["DayNum"])) + "  " + modGlobal.Clean(oRec["shift_code"]);

					CurrRow++;
					WeekRow = CurrRow;
					ViewModel.sprMonth2.Row = WeekRow;
					ViewModel.sprMonth2.FontBold = false;
					if (modGlobal.Clean(oRec["TimeCode"]) != "")
					{
						ViewModel.sprMonth2.Text = modGlobal.Clean(oRec["Employee"]);
						switch(modGlobal.Clean(oRec["TimeCode"]))
						{
							case "DDF" :
								{
								}
								break;
							case "VAC" : case "PTO" : case "VACFML" : case "PTOFML" :
								{
								}
								break;
							case "FHL" : case "FHLFML" :
								{
								}
								break;
							default:
								{
								}
								break;
						}
					}
					else
					{
						//                sprMonth2.Text = ""
					}

				}
				else
				{
					//same column/row
					ViewModel.sprMonth2.Col = PrevCol;
					WeekRow++;
					ViewModel.sprMonth2.Row = WeekRow;
					ViewModel.sprMonth2.FontBold = false;
					ViewModel.sprMonth2.Text = modGlobal.Clean(oRec["Employee"]);
					switch(modGlobal.Clean(oRec["TimeCode"]))
					{
						case "DDF" :
							{
							}
							break;
						case "VAC" : case "PTO" : case "VACFML" : case "PTOFML" :
							{
							}
							break;
						case "FHL" : case "FHLFML" :
							{
							}
							break;
						default:
							{
							}
							break;
					}
				}

				oRec.MoveNext();
			};

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboMonth_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboMonth.SelectedIndex < 0)
			{
				return;
			}
			ViewModel.ThisMonth = ViewModel.cboMonth.GetItemData(ViewModel.cboMonth.SelectedIndex);
			ViewModel.sprMonth2.Row = 1;
			ViewModel.sprMonth2.Col = 1;

			switch( ViewModel.ThisMonth)
			{
				case 1 :
					ViewModel.sprMonth2.Text = "JANUARY - " + ViewModel.ThisYear.ToString();
					break;
				case 2 :
					ViewModel.sprMonth2.Text = "FEBRUARY - " + ViewModel.ThisYear.ToString();
					break;
				case 3 :
					ViewModel.sprMonth2.Text = "MARCH - " + ViewModel.ThisYear.ToString();
					break;
				case 4 :
					ViewModel.sprMonth2.Text = "APRIL - " + ViewModel.ThisYear.ToString();
					break;
				case 5 :
					ViewModel.sprMonth2.Text = "MAY - " + ViewModel.ThisYear.ToString();
					break;
				case 6 :
					ViewModel.sprMonth2.Text = "JUNE - " + ViewModel.ThisYear.ToString();
					break;
				case 7 :
					ViewModel.sprMonth2.Text = "JULY - " + ViewModel.ThisYear.ToString();
					break;
				case 8 :
					ViewModel.sprMonth2.Text = "AUGUST - " + ViewModel.ThisYear.ToString();
					break;
				case 9 :
					ViewModel.sprMonth2.Text = "SEPTEMBER - " + ViewModel.ThisYear.ToString();
					break;
				case 10 :
					ViewModel.sprMonth2.Text = "OCTOBER - " + ViewModel.ThisYear.ToString();
					break;
				case 11 :
					ViewModel.sprMonth2.Text = "NOVEMBER - " + ViewModel.ThisYear.ToString();
					break;
				case 12 :
					ViewModel.sprMonth2.Text = "DECEMBER - " + ViewModel.ThisYear.ToString();
					break;
				default:
					ViewModel.sprMonth2.Text = "UNKNOWN - " + ViewModel.ThisYear.ToString();
					break;
			}

			ClearReport();
			FormatReport2();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboYear_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboYear.SelectedIndex == -1)
			{
				return;
			}
			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			ViewModel.ThisYear = Convert.ToInt32(modGlobal.GetVal(ViewModel.cboYear.Text));

			ClearReport();
			//    FormatReport2
			cboMonth_SelectionChangeCommitted(ViewModel.cboMonth, new System.EventArgs());
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprMonth2.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprMonth2.setPrintAbortMsg("Printing Hazmat Monthly Leave Report - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprMonth2.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprMonth2.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprMonth2.PrintGrid was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprMonth2.setPrintGrid(true);
			//    sprMonth2.PrintOrientation = PrintOrientationPortrait
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprMonth2.PrintSmartPrint was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprMonth2.setPrintSmartPrint(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprMonth2.PrintUseDataMax was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprMonth2.setPrintUseDataMax(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprMonth2.PrintSheet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//object tempRefParam = null;
			//WEBMAP_UPGRADE_ISSUE: (1101) FarPoint.Win.Spread.FpSpread.PrintSheet was not upgraded
			ViewModel.sprMonth2.PrintSheet(null);
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "sp_GetYearList ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			//Initialize Year Combobox
			ViewModel.cboYear.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboYear.AddItem(Convert.ToString(oRec["cal_year"]).Trim());
				oRec.MoveNext();
			};
			ViewModel.ThisYear = DateTime.Now.Year;
			ViewModel.cboYear.Text = DateTime.Now.Year.ToString();
			ViewModel.ThisMonth = DateTime.Now.Month;

			//load Month list
			ViewModel.cboMonth.AddItem("January");
			ViewModel.cboMonth.SetItemData(ViewModel.cboMonth.GetNewIndex(), 1);
			ViewModel.cboMonth.AddItem("February");
			ViewModel.cboMonth.SetItemData(ViewModel.cboMonth.GetNewIndex(), 2);
			ViewModel.cboMonth.AddItem("March");
			ViewModel.cboMonth.SetItemData(ViewModel.cboMonth.GetNewIndex(), 3);
			ViewModel.cboMonth.AddItem("April");
			ViewModel.cboMonth.SetItemData(ViewModel.cboMonth.GetNewIndex(), 4);
			ViewModel.cboMonth.AddItem("May");
			ViewModel.cboMonth.SetItemData(ViewModel.cboMonth.GetNewIndex(), 5);
			ViewModel.cboMonth.AddItem("June");
			ViewModel.cboMonth.SetItemData(ViewModel.cboMonth.GetNewIndex(), 6);
			ViewModel.cboMonth.AddItem("July");
			ViewModel.cboMonth.SetItemData(ViewModel.cboMonth.GetNewIndex(), 7);
			ViewModel.cboMonth.AddItem("August");
			ViewModel.cboMonth.SetItemData(ViewModel.cboMonth.GetNewIndex(), 8);
			ViewModel.cboMonth.AddItem("September");
			ViewModel.cboMonth.SetItemData(ViewModel.cboMonth.GetNewIndex(), 9);
			ViewModel.cboMonth.AddItem("October");
			ViewModel.cboMonth.SetItemData(ViewModel.cboMonth.GetNewIndex(), 10);
			ViewModel.cboMonth.AddItem("November");
			ViewModel.cboMonth.SetItemData(ViewModel.cboMonth.GetNewIndex(), 11);
			ViewModel.cboMonth.AddItem("December");
			ViewModel.cboMonth.SetItemData(ViewModel.cboMonth.GetNewIndex(), 12);

			for (int x = 0; x <= ViewModel.cboMonth.Items.Count - 1; x++)
			{
				if ( ViewModel.cboMonth.GetItemData(x) == ViewModel.ThisMonth)
				{
					ViewModel.cboMonth.SelectedIndex = x;
					break;
				}
			}

			FormatReport2();

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmHazmatLeave DefInstance
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

		public static frmHazmatLeave CreateInstance()
		{
			PTSProject.frmHazmatLeave theInstance = Shared.Container.Resolve< frmHazmatLeave>();
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
			ViewModel.sprMonth2.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprMonth2.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmHazmatLeave
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmHazmatLeaveViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmHazmatLeave m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}