using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.Globalization;
using UpgradeHelpers.DB.ADO;
using UpgradeStubs;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class frmUpdatePromo
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmUpdatePromoViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		//********************************************************
		//Update Promotion Lists Form
		//********************************************************
		//ADODB
		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmUpdatePromo));
			if ( Shared.m_vb6FormDefInstance == null )
			{
				if ( Shared.m_InitializingDefInstance )
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
			ReLoadForm(false);
		}



		public void LoadForm()
		{
				//Load promotion detail fields with selected employee

				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;
				string strSQL = "";

				try
				{

					//Clear current data
					ClearForm();
					//    CurrPromoID = lstPromo.ItemData(lstPromo.ListIndex)
					ViewModel.sprPromoList.Row = ViewModel.iSelectedRow;
					ViewModel.sprPromoList.Col = 3;
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.CurrPromoID = Convert.ToInt32(modGlobal.GetVal(ViewModel.sprPromoList.Text));

					oCmd.Connection = modGlobal.oConn;
					oCmd.CommandType = CommandType.Text;
					strSQL = "SELECT promotion_id,Promotion.employee_id, name_full, promotion_date, ";
					strSQL = strSQL + "exclusion_days,Promotion.status,Promotion.comments ";
					strSQL = strSQL + "FROM Promotion INNER JOIN Personnel ON Promotion.employee_id = Personnel.employee_id ";
					strSQL = strSQL + "WHERE Promotion.promotion_id = " + ViewModel.CurrPromoID.ToString();
					oCmd.CommandText = strSQL;
					oRec = ADORecordSetHelper.Open(oCmd, "");
					ViewModel.lbName.Text = Convert.ToString(oRec["name_full"]);
					ViewModel.lbName.Visible = true;
					ViewModel.lbEmpId.Text = Convert.ToString(oRec["employee_id"]);
					ViewModel.lbEmpId.Visible = true;
					ViewModel.txtPromoDate.Text = Convert.ToDateTime(oRec["promotion_date"]).ToString("M/d/yyyy");
					ViewModel.txtPromoDate.Visible = true;
					ViewModel.txtExclusion.Text = Convert.ToString(oRec["exclusion_days"]);
					ViewModel.txtExclusion.Visible = true;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
					if ( !Convert.IsDBNull(oRec["comments"]) )
					{
						ViewModel.txtComment.Text = Convert.ToString(oRec["comments"]);
					}
					if ( Convert.ToBoolean(oRec["status"]) )
					{
						ViewModel.chkActive.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
					}
					else
					{
						ViewModel.chkActive.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
					}
					ViewModel.chkActive.Visible = true;
					ViewModel.txtComment.Visible = true;
					ViewModel.lbEntry1.Visible = true;
					ViewModel.lbEntry2.Visible = true;
					ViewModel.lbEntry3.Visible = true;
					ViewModel.cmdUpdate.Visible = true;
					ViewModel.cmdRemove.Visible = true;
				}
				catch
				{

				if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
								return ;
							}
				}

			}

		public void ClearForm()
		{
			//Clear & Hide Promotion Detail fields
			ViewModel.lbName.Visible = false;
			ViewModel.lbName.Text = "";
			ViewModel.lbEmpId.Visible = false;
			ViewModel.lbEmpId.Text = "";
			ViewModel.txtPromoDate.Visible = false;
			ViewModel.txtPromoDate.Text = "";
			ViewModel.txtExclusion.Visible = false;
			ViewModel.txtExclusion.Text = "";
			ViewModel.txtComment.Visible = false;
			ViewModel.txtComment.Text = "";
			ViewModel.chkActive.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.chkActive.Visible = false;
			ViewModel.lbEntry1.Visible = false;
			ViewModel.lbEntry2.Visible = false;
			ViewModel.lbEntry3.Visible = false;
			ViewModel.cmdUpdate.Visible = false;
			ViewModel.cmdRemove.Visible = false;
			ViewModel.lbAction.Text = "";
			ViewModel.lbAction.Visible = false;

		}

		public void LoadList(string PromoCode)
		{
				//Load lstPromo listbox with selected Promotion List

				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;
				string strSQL = "";
				int CurrRow = 0;

				try
				{

					oCmd.Connection = modGlobal.oConn;
					oCmd.CommandType = CommandType.Text;
					strSQL = "spSelect_PersonnelPromotionList '" + modGlobal.Clean(PromoCode) + "' ";
					oCmd.CommandText = strSQL;
					oRec = ADORecordSetHelper.Open(oCmd, "");

					CurrRow = 0;

					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprPromoList.ClearRange was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprPromoList.ClearRange(1, 1, ViewModel.sprPromoList.MaxCols, ViewModel.sprPromoList.MaxRows, false);


					while ( !oRec.EOF )
					{

						CurrRow++;
						ViewModel.sprPromoList.Row = CurrRow;
						ViewModel.sprPromoList.Col = 1;
						ViewModel.sprPromoList.Text = modGlobal.Clean(oRec["name_full"]);
						ViewModel.sprPromoList.Col = 2;
						ViewModel.sprPromoList.Text = Convert.ToDateTime(oRec["promotion_date"]).ToString("M/d/yyyy");
						ViewModel.sprPromoList.Col = 3;
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprPromoList.Text = Convert.ToString(modGlobal.GetVal(oRec["promotion_id"]));


						oRec.MoveNext();
				};
					ViewModel.cmdPrint.Visible = true;
					ViewModel.sprPromoList.Visible = true;
				}
				catch
				{

				if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
								return ;
							}
				}

			}

		[UpgradeHelpers.Events.Handler]
		internal void cboPromotion_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
				//Promotion List selected
				//Load list box with Employees for selected Promotion


				ClearForm();
				string PromoCode = Conversion.Str(ViewModel.cboPromotion.GetItemData(ViewModel.cboPromotion.SelectedIndex)).Trim();

						LoadList(PromoCode);

			}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Close form
			ViewManager.DisposeView(this);

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPromoList.PrintHeader was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprPromoList.setPrintHeader("/lPTS Promotion List For/n" + modGlobal.Clean(ViewModel.cboPromotion.Text));
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPromoList.PrintFooter was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprPromoList.setPrintFooter("/nPrinted on " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "/rPage /p of /pc");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPromoList.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprPromoList.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPromoList.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprPromoList.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPromoList.PrintColHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprPromoList.setPrintColHeaders(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPromoList.PrintSmartPrint was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprPromoList.setPrintSmartPrint(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPromoList.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprPromoList.setPrintAbortMsg("Printing Promotion List");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprPromoList.PrintSheet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//object tempRefParam = null;
			//WEBMAP_UPGRADE_ISSUE: (1101) FarPoint.Win.Spread.FpSpread.PrintSheet was not upgraded
			ViewModel.sprPromoList.PrintSheet(null);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdRemove_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				//Remove currently selected employee from
				//currently selected Promotion list

				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				string PromoCode = "";
				UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;

				try
				{
					{
						async1.Append<UpgradeHelpers.Helpers.DialogResult>(() =>
								ViewManager.ShowMessage("This will permanently delete all record of this Promotion!" + "\r" + "Do you wish to continue?",
									"Delete Promotion Record", UpgradeHelpers.Helpers.BoxButtons.YesNo, UpgradeHelpers.Helpers.BoxIcons.Question));
						async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
						async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
							{

								//Warn user on delete request
								Response = tempNormalized1;
							});
						async1.Append(() =>
							{
									if ( Response == UpgradeHelpers.Helpers.DialogResult.No )
									{
										this.Return();
										return ;
									}

									oCmd.Connection = modGlobal.oConn;
									oCmd.CommandType = CommandType.StoredProcedure;
									oCmd.CommandText = "spDeletePromotion";
									oCmd.ExecuteNonQuery(new object[] { ViewModel.CurrPromoID });

									ClearForm();
									ViewModel.lbAction.Visible = true;
									ViewModel.lbAction.Text = "Promotion Record Removed";

									//Refresh Promotion List
									PromoCode = Conversion.Str(ViewModel.cboPromotion.GetItemData(ViewModel.cboPromotion.SelectedIndex)).Trim();
											LoadList(PromoCode);
										});
								}
					}
				catch
				{

								if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
								this.Return();
								return ;
							}
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdUpdate_Click(Object eventSender, System.EventArgs eventArgs)
		{
				//Update selected Promotion detail

				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				//int Exclusion = 0;
				byte Pstatus = 0;
				string PDate = "";
				string sComment = "";

				try
				{

						//Edits
						double dbNumericTemp = 0;
						if ( !Information.IsDate(ViewModel.txtPromoDate.Text) )
						{
							ViewManager.ShowMessage("Promotion Date is invalid, Please try again", "Update Promotion", UpgradeHelpers.Helpers.BoxButtons.OK);
							ViewManager.SetCurrent(ViewModel.txtPromoDate);
							ViewModel.txtPromoDate.SelectionStart = 0;
							ViewModel.txtPromoDate.SelectionLength = Strings.Len(ViewModel.txtPromoDate.Text);
							return ;
						}
						else if ( !Double.TryParse(ViewModel.txtExclusion.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp) )
						{
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
							if ( Convert.IsDBNull(ViewModel.txtExclusion.Text) || ViewModel.txtExclusion.Text == "" )
							{
								//Exclusion days blank, set to 0
								ViewModel.txtExclusion.Text = "0";
							}
							else
							{
								ViewManager.ShowMessage("Exclusion Days must be numeric, Please try again", "Update Promotion", UpgradeHelpers.Helpers.BoxButtons.OK);
								ViewManager.SetCurrent(ViewModel.txtExclusion);
								ViewModel.txtExclusion.SelectionStart = 0;
								ViewModel.txtExclusion.SelectionLength = Strings.Len(ViewModel.txtExclusion.Text);
								return ;
							}
						}

						if ( ViewModel.chkActive.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked )
						{
							Pstatus = 1;
						}
						else
						{
							Pstatus = 0;
						}
						PDate = DateTime.Parse(ViewModel.txtPromoDate.Text).ToString("M/d/yyyy");
						sComment = ViewModel.txtComment.Text.Trim().Substring(0, Math.Min(255, ViewModel.txtComment.Text.Trim().Length));
						oCmd.Connection = modGlobal.oConn;
						oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spUpdatePromotion " + ViewModel.CurrPromoID.ToString() + ",'" + PDate + "'," + Conversion.Val(ViewModel.txtExclusion.Text).ToString() + "," + Pstatus.ToString() + ",'" + sComment + "'";
						oCmd.ExecuteNonQuery();

								LoadForm();
								ViewModel.lbAction.Visible = true;
								ViewModel.lbAction.Text = "Promotion Record Updated";
					}
				catch
				{

				if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
								return ;
							}
				}

			}


		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
				//Load Promotion List box with Promotion Lists

				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;
				//string strSQL = "";

				try
				{

					oCmd.Connection = modGlobal.oConn;
					oCmd.CommandType = CommandType.Text;
					oCmd.CommandText = "Select * from Promotion_Code";
					oRec = ADORecordSetHelper.Open(oCmd, "");
					ViewModel.cboPromotion.Items.Clear();


					while ( !oRec.EOF )
					{
						ViewModel.cboPromotion.AddItem(Convert.ToString(oRec["description"]));
						ViewModel.cboPromotion.SetItemData(ViewModel.cboPromotion.GetNewIndex(), Convert.ToInt32(Conversion.Val(Convert.ToString(oRec["promotion_code_id"]))));
						oRec.MoveNext();
				};
					}
				catch
				{

				if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
								return ;
							}
				}

			}

		private void sprPromoList_CellClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
		{
				int Col = eventArgs.Column;
				int Row = eventArgs.Row;

				if ( Row == 0 )
				{
					return ;
				}
				ViewModel.sprPromoList.Row = Row;
				ViewModel.sprPromoList.Col = 1;
				if ( modGlobal.Clean(ViewModel.sprPromoList.Text) == "" )
				{
					return ;
				}
				ViewModel.iSelectedRow = Row;
						LoadForm();

			}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmUpdatePromo DefInstance
		{
			get
			{
					if ( Shared.m_vb6FormDefInstance == null )
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

		public static frmUpdatePromo CreateInstance()
		{
				PTSProject.frmUpdatePromo theInstance = Shared.Container.Resolve<frmUpdatePromo>();
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
			ViewModel.Shape1.LifeCycleStartup();
			ViewModel.sprPromoList.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.Shape1.LifeCycleShutdown();
			ViewModel.sprPromoList.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmUpdatePromo
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmUpdatePromoViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmUpdatePromo m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}