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

	public partial class frmImmunizationRecord
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmImmunizationRecordViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmImmunizationRecord));
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


		private void frmImmunizationRecord_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		public void ClearForm()
		{
			ViewModel.sprReport.Row = 8;
			//Name
			ViewModel.sprReport.Col = 2;
			ViewModel.sprReport.Text = "";
			//Date of Hire
			ViewModel.sprReport.Col = 9;
			ViewModel.sprReport.Text = "";
			ViewModel.sprReport.Row = 14;
			//#1
			ViewModel.sprReport.Col = 2;
			ViewModel.sprReport.Text = "_____________";
			//#2
			ViewModel.sprReport.Col = 5;
			ViewModel.sprReport.Text = "_____________";
			//#3
			ViewModel.sprReport.Col = 8;
			ViewModel.sprReport.Text = "_____________";
			//#4
			ViewModel.sprReport.Col = 11;
			ViewModel.sprReport.Text = "_____________";
			ViewModel.sprReport.Row = 17;
			//#1
			ViewModel.sprReport.Col = 2;
			ViewModel.sprReport.Text = "_____________";
			//#2
			ViewModel.sprReport.Col = 5;
			ViewModel.sprReport.Text = "_____________";
			//#3
			ViewModel.sprReport.Col = 8;
			ViewModel.sprReport.Text = "_____________";
			//#4
			ViewModel.sprReport.Col = 11;
			ViewModel.sprReport.Text = "_____________";
			ViewModel.sprReport.Row = 21;
			//#1
			ViewModel.sprReport.Col = 5;
			ViewModel.sprReport.Text = "_____________";
			//#2
			ViewModel.sprReport.Col = 8;
			ViewModel.sprReport.Text = "_____________";
			//#3
			ViewModel.sprReport.Col = 11;
			ViewModel.sprReport.Text = "_____________";
			ViewModel.sprReport.Row = 25;
			//#1
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Text = "Varicella:  _____________";
			//#2
			ViewModel.sprReport.Col = 5;
			ViewModel.sprReport.Text = "_____________";
			//#3
			ViewModel.sprReport.Col = 8;
			ViewModel.sprReport.Text = "_____________";
			//#4
			ViewModel.sprReport.Col = 11;
			ViewModel.sprReport.Text = "_____________";
			ViewModel.sprReport.Row = 29;
			//#1
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Text = "Tetanus:  _____________";
			//#2
			ViewModel.sprReport.Col = 5;
			ViewModel.sprReport.Text = "_____________";
			//#3
			ViewModel.sprReport.Col = 8;
			ViewModel.sprReport.Text = "_____________";

		}

		public void FormatReport()
		{
			//Select Employee Name and Schedule/Leave records for specificed date
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			// Need to prepare the form...
			ClearForm();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spReport_Employee '" + modGlobal.Clean(ViewModel.lbEmpID.Text) + "'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (!oRec.EOF)
			{
				ViewModel.sprReport.Row = 8;
				ViewModel.sprReport.Col = 2;
				ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["name_full"]);
				ViewModel.sprReport.Col = 9;
				ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["TFD_hire_date"]).ToString("M/d/yyyy");
			}
			else
			{
				return;
			}
			ViewModel.sprReport.Row = 14;
			oCmd.CommandText = "spReport_LatestEMSPersonnelImmunizationsByEmpType 1, '" + modGlobal.Clean(ViewModel.lbEmpID.Text) + "' ";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				if (modGlobal.Clean(oRec["immunize_date"]) != "")
				{
					ViewModel.sprReport.Col = 2;
					ViewModel.sprReport.Text = "";
					if (modGlobal.Clean(oRec["result_flag"]) != "")
					{
						if (modGlobal.Clean(oRec["result_flag"]) == "P")
						{
							ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / +";
						}
						else
						{
							ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / -";
						}
					}
					else
					{
						ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy");
					}
				}
				else
				{
					if (modGlobal.Clean(oRec["comments"]) != "")
					{
						ViewModel.sprReport.Col = 2;
						ViewModel.sprReport.Text = "";
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]) + " / POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]) + " / NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]);
						}
					}
					else
					{
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							ViewModel.sprReport.Col = 2;
							ViewModel.sprReport.Text = "";
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "   POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "   NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Col = 2;
							ViewModel.sprReport.Text = "";
							ViewModel.sprReport.Text = "   YES";
						}
					}
				}
			}

			oCmd.CommandText = "spReport_LatestEMSPersonnelImmunizationsByEmpType 2, '" + modGlobal.Clean(ViewModel.lbEmpID.Text) + "' ";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				if (modGlobal.Clean(oRec["immunize_date"]) != "")
				{
					ViewModel.sprReport.Col = 5;
					ViewModel.sprReport.Text = "";
					if (modGlobal.Clean(oRec["result_flag"]) != "")
					{
						if (modGlobal.Clean(oRec["result_flag"]) == "P")
						{
							ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / +";
						}
						else
						{
							ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / -";
						}
					}
					else
					{
						ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy");
					}
				}
				else
				{
					if (modGlobal.Clean(oRec["comments"]) != "")
					{
						ViewModel.sprReport.Col = 5;
						ViewModel.sprReport.Text = "";
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]) + " / POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]) + " / NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]);
						}
					}
					else
					{
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							ViewModel.sprReport.Col = 5;
							ViewModel.sprReport.Text = "";
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "   POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "   NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Col = 5;
							ViewModel.sprReport.Text = "";
							ViewModel.sprReport.Text = "   YES";
						}
					}
				}
			}

			oCmd.CommandText = "spReport_LatestEMSPersonnelImmunizationsByEmpType 3, '" + modGlobal.Clean(ViewModel.lbEmpID.Text) + "' ";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				if (modGlobal.Clean(oRec["immunize_date"]) != "")
				{
					ViewModel.sprReport.Col = 8;
					ViewModel.sprReport.Text = "";
					if (modGlobal.Clean(oRec["result_flag"]) != "")
					{
						if (modGlobal.Clean(oRec["result_flag"]) == "P")
						{
							ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / +";
						}
						else
						{
							ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / -";
						}
					}
					else
					{
						ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy");
					}
				}
				else
				{
					if (modGlobal.Clean(oRec["comments"]) != "")
					{
						ViewModel.sprReport.Col = 8;
						ViewModel.sprReport.Text = "";
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]) + " / POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]) + " / NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]);
						}
					}
					else
					{
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							ViewModel.sprReport.Col = 8;
							ViewModel.sprReport.Text = "";
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "   POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "   NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Col = 8;
							ViewModel.sprReport.Text = "";
							ViewModel.sprReport.Text = "   YES";
						}
					}
				}
			}

			oCmd.CommandText = "spReport_LatestEMSPersonnelImmunizationsByEmpType 7, '" + modGlobal.Clean(ViewModel.lbEmpID.Text) + "' ";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				if (modGlobal.Clean(oRec["immunize_date"]) != "")
				{
					ViewModel.sprReport.Col = 11;
					ViewModel.sprReport.Text = "";
					if (modGlobal.Clean(oRec["result_flag"]) != "")
					{
						if (modGlobal.Clean(oRec["result_flag"]) == "P")
						{
							ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / +";
						}
						else
						{
							ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / -";
						}
					}
					else
					{
						ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy");
					}
				}
				else
				{
					if (modGlobal.Clean(oRec["comments"]) != "")
					{
						ViewModel.sprReport.Col = 11;
						ViewModel.sprReport.Text = "";
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]) + " / POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]) + " / NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]);
						}
					}
					else
					{
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							ViewModel.sprReport.Col = 11;
							ViewModel.sprReport.Text = "";
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "   POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "   NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Col = 11;
							ViewModel.sprReport.Text = "";
							ViewModel.sprReport.Text = "   YES";
						}
					}
				}
			}

			//
			ViewModel.sprReport.Row = 17;
			oCmd.CommandText = "spReport_LatestEMSPersonnelImmunizationsByEmpType 4, '" + modGlobal.Clean(ViewModel.lbEmpID.Text) + "' ";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				if (modGlobal.Clean(oRec["immunize_date"]) != "")
				{
					ViewModel.sprReport.Col = 2;
					ViewModel.sprReport.Text = "";
					if (modGlobal.Clean(oRec["result_flag"]) != "")
					{
						if (modGlobal.Clean(oRec["result_flag"]) == "P")
						{
							ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / +";
						}
						else
						{
							ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / -";
						}
					}
					else
					{
						ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy");
					}
				}
				else
				{
					if (modGlobal.Clean(oRec["comments"]) != "")
					{
						ViewModel.sprReport.Col = 2;
						ViewModel.sprReport.Text = "";
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]) + " / POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]) + " / NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]);
						}
					}
					else
					{
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							ViewModel.sprReport.Col = 2;
							ViewModel.sprReport.Text = "";
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "   POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "   NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Col = 2;
							ViewModel.sprReport.Text = "";
							ViewModel.sprReport.Text = "   YES";
						}
					}
				}
			}

			oCmd.CommandText = "spReport_LatestEMSPersonnelImmunizationsByEmpType 5, '" + modGlobal.Clean(ViewModel.lbEmpID.Text) + "' ";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				if (modGlobal.Clean(oRec["immunize_date"]) != "")
				{
					ViewModel.sprReport.Col = 5;
					ViewModel.sprReport.Text = "";
					if (modGlobal.Clean(oRec["result_flag"]) != "")
					{
						if (modGlobal.Clean(oRec["result_flag"]) == "P")
						{
							ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / +";
						}
						else
						{
							ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / -";
						}
					}
					else
					{
						ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy");
					}
				}
				else
				{
					if (modGlobal.Clean(oRec["comments"]) != "")
					{
						ViewModel.sprReport.Col = 5;
						ViewModel.sprReport.Text = "";
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]) + " / POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]) + " / NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]);
						}
					}
					else
					{
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							ViewModel.sprReport.Col = 5;
							ViewModel.sprReport.Text = "";
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "   POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "   NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Col = 5;
							ViewModel.sprReport.Text = "";
							ViewModel.sprReport.Text = "   YES";
						}
					}
				}
			}

			oCmd.CommandText = "spReport_LatestEMSPersonnelImmunizationsByEmpType 6, '" + modGlobal.Clean(ViewModel.lbEmpID.Text) + "' ";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				if (modGlobal.Clean(oRec["immunize_date"]) != "")
				{
					ViewModel.sprReport.Col = 8;
					ViewModel.sprReport.Text = "";
					if (modGlobal.Clean(oRec["result_flag"]) != "")
					{
						if (modGlobal.Clean(oRec["result_flag"]) == "P")
						{
							ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / +";
						}
						else
						{
							ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / -";
						}
					}
					else
					{
						ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy");
					}
				}
				else
				{
					if (modGlobal.Clean(oRec["comments"]) != "")
					{
						ViewModel.sprReport.Col = 8;
						ViewModel.sprReport.Text = "";
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]) + " / POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]) + " / NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]);
						}
					}
					else
					{
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							ViewModel.sprReport.Col = 8;
							ViewModel.sprReport.Text = "";
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "   POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "   NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Col = 8;
							ViewModel.sprReport.Text = "";
							ViewModel.sprReport.Text = "   YES";
						}
					}
				}
			}

			oCmd.CommandText = "spReport_LatestEMSPersonnelImmunizationsByEmpType 25, '" + modGlobal.Clean(ViewModel.lbEmpID.Text) + "' ";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				if (modGlobal.Clean(oRec["immunize_date"]) != "")
				{
					ViewModel.sprReport.Col = 11;
					ViewModel.sprReport.Text = "";
					if (modGlobal.Clean(oRec["result_flag"]) != "")
					{
						if (modGlobal.Clean(oRec["result_flag"]) == "P")
						{
							ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / +";
						}
						else
						{
							ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / -";
						}
					}
					else
					{
						ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy");
					}
				}
				else
				{
					if (modGlobal.Clean(oRec["comments"]) != "")
					{
						ViewModel.sprReport.Col = 11;
						ViewModel.sprReport.Text = "";
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]) + " / POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]) + " / NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]);
						}
					}
					else
					{
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							ViewModel.sprReport.Col = 11;
							ViewModel.sprReport.Text = "";
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "   POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "   NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Col = 11;
							ViewModel.sprReport.Text = "";
							ViewModel.sprReport.Text = "   YES";
						}
					}
				}
			}
			ViewModel.sprReport.Row = 21;
			oCmd.CommandText = "spReport_LatestEMSPersonnelImmunizationsByEmpType 15, '" + modGlobal.Clean(ViewModel.lbEmpID.Text) + "' ";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				if (modGlobal.Clean(oRec["immunize_date"]) != "")
				{
					ViewModel.sprReport.Col = 5;
					ViewModel.sprReport.Text = "";
					if (modGlobal.Clean(oRec["result_flag"]) != "")
					{
						if (modGlobal.Clean(oRec["result_flag"]) == "P")
						{
							ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / +";
						}
						else
						{
							ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / -";
						}
					}
					else
					{
						ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy");
					}
				}
				else
				{
					if (modGlobal.Clean(oRec["comments"]) != "")
					{
						ViewModel.sprReport.Col = 5;
						ViewModel.sprReport.Text = "";
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]) + " / POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]) + " / NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]);
						}
					}
					else
					{
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							ViewModel.sprReport.Col = 5;
							ViewModel.sprReport.Text = "";
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "   POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "   NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Col = 5;
							ViewModel.sprReport.Text = "";
							ViewModel.sprReport.Text = "   YES";
						}
					}
				}
			}

			oCmd.CommandText = "spReport_LatestEMSPersonnelImmunizationsByEmpType 16, '" + modGlobal.Clean(ViewModel.lbEmpID.Text) + "' ";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				if (modGlobal.Clean(oRec["immunize_date"]) != "")
				{
					ViewModel.sprReport.Col = 8;
					ViewModel.sprReport.Text = "";
					if (modGlobal.Clean(oRec["result_flag"]) != "")
					{
						if (modGlobal.Clean(oRec["result_flag"]) == "P")
						{
							ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / +";
						}
						else
						{
							ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / -";
						}
					}
					else
					{
						ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy");
					}
				}
				else
				{
					if (modGlobal.Clean(oRec["comments"]) != "")
					{
						ViewModel.sprReport.Col = 8;
						ViewModel.sprReport.Text = "";
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]) + " / POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]) + " / NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]);
						}
					}
					else
					{
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							ViewModel.sprReport.Col = 8;
							ViewModel.sprReport.Text = "";
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "   POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "   NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Col = 8;
							ViewModel.sprReport.Text = "";
							ViewModel.sprReport.Text = "   YES";
						}
					}
				}
			}

			oCmd.CommandText = "spReport_LatestEMSPersonnelImmunizationsByEmpType 17, '" + modGlobal.Clean(ViewModel.lbEmpID.Text) + "' ";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				if (modGlobal.Clean(oRec["immunize_date"]) != "")
				{
					ViewModel.sprReport.Col = 11;
					ViewModel.sprReport.Text = "";
					if (modGlobal.Clean(oRec["result_flag"]) != "")
					{
						if (modGlobal.Clean(oRec["result_flag"]) == "P")
						{
							ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / +";
						}
						else
						{
							ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / -";
						}
					}
					else
					{
						ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy");
					}
				}
				else
				{
					if (modGlobal.Clean(oRec["comments"]) != "")
					{
						ViewModel.sprReport.Col = 11;
						ViewModel.sprReport.Text = "";
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]) + " / POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]) + " / NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]);
						}
					}
					else
					{
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							ViewModel.sprReport.Col = 11;
							ViewModel.sprReport.Text = "";
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "   POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "   NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Col = 11;
							ViewModel.sprReport.Text = "";
							ViewModel.sprReport.Text = "   YES";
						}
					}
				}
			}
			ViewModel.sprReport.Row = 25;
			oCmd.CommandText = "spReport_LatestEMSPersonnelImmunizationsByEmpType 13, '" + modGlobal.Clean(ViewModel.lbEmpID.Text) + "' ";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				if (modGlobal.Clean(oRec["immunize_date"]) != "")
				{
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.Text = "";
					if (modGlobal.Clean(oRec["result_flag"]) != "")
					{
						if (modGlobal.Clean(oRec["result_flag"]) == "P")
						{
							ViewModel.sprReport.Text = "Varicella:  " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / +";
						}
						else
						{
							ViewModel.sprReport.Text = "Varicella:  " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / -";
						}
					}
					else
					{
						ViewModel.sprReport.Text = "Varicella:  " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy");
					}
				}
				else
				{
					if (modGlobal.Clean(oRec["comments"]) != "")
					{
						ViewModel.sprReport.Col = 2;
						ViewModel.sprReport.Text = "";
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "Varicella:  " + modGlobal.Clean(oRec["comments"]) + " / POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "Varicella:  " + modGlobal.Clean(oRec["comments"]) + " / NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Text = "Varicella:  " + modGlobal.Clean(oRec["comments"]);
						}
					}
					else
					{
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							ViewModel.sprReport.Col = 2;
							ViewModel.sprReport.Text = "";
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "Varicella:   POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "Varicella:   NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Col = 2;
							ViewModel.sprReport.Text = "";
							ViewModel.sprReport.Text = "Varicella:   YES";
						}
					}
				}
			}

			oCmd.CommandText = "spReport_LatestEMSPersonnelImmunizationsByEmpType 8, '" + modGlobal.Clean(ViewModel.lbEmpID.Text) + "' ";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				if (modGlobal.Clean(oRec["immunize_date"]) != "")
				{
					ViewModel.sprReport.Col = 5;
					ViewModel.sprReport.Text = "";
					if (modGlobal.Clean(oRec["result_flag"]) != "")
					{
						if (modGlobal.Clean(oRec["result_flag"]) == "P")
						{
							ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / +";
						}
						else
						{
							ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / -";
						}
					}
					else
					{
						ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy");
					}
				}
				else
				{
					if (modGlobal.Clean(oRec["comments"]) != "")
					{
						ViewModel.sprReport.Col = 5;
						ViewModel.sprReport.Text = "";
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]) + " / POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]) + " / NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]);
						}
					}
					else
					{
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							ViewModel.sprReport.Col = 5;
							ViewModel.sprReport.Text = "";
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "   POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "   NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Col = 5;
							ViewModel.sprReport.Text = "";
							ViewModel.sprReport.Text = "   YES";
						}
					}
				}
			}

			oCmd.CommandText = "spReport_LatestEMSPersonnelImmunizationsByEmpType 10, '" + modGlobal.Clean(ViewModel.lbEmpID.Text) + "' ";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				if (modGlobal.Clean(oRec["immunize_date"]) != "")
				{
					ViewModel.sprReport.Col = 8;
					ViewModel.sprReport.Text = "";
					if (modGlobal.Clean(oRec["result_flag"]) != "")
					{
						if (modGlobal.Clean(oRec["result_flag"]) == "P")
						{
							ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / +";
						}
						else
						{
							ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / -";
						}
					}
					else
					{
						ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy");
					}
				}
				else
				{
					if (modGlobal.Clean(oRec["comments"]) != "")
					{
						ViewModel.sprReport.Col = 8;
						ViewModel.sprReport.Text = "";
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]) + " / POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]) + " / NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]);
						}
					}
					else
					{
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							ViewModel.sprReport.Col = 8;
							ViewModel.sprReport.Text = "";
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "   POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "   NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Col = 8;
							ViewModel.sprReport.Text = "";
							ViewModel.sprReport.Text = "   YES";
						}
					}
				}
			}

			oCmd.CommandText = "spReport_LatestEMSPersonnelImmunizationsByEmpType 14, '" + modGlobal.Clean(ViewModel.lbEmpID.Text) + "' ";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				if (modGlobal.Clean(oRec["immunize_date"]) != "")
				{
					ViewModel.sprReport.Col = 11;
					ViewModel.sprReport.Text = "";
					if (modGlobal.Clean(oRec["result_flag"]) != "")
					{
						if (modGlobal.Clean(oRec["result_flag"]) == "P")
						{
							ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / +";
						}
						else
						{
							ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / -";
						}
					}
					else
					{
						ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy");
					}
				}
				else
				{
					if (modGlobal.Clean(oRec["comments"]) != "")
					{
						ViewModel.sprReport.Col = 11;
						ViewModel.sprReport.Text = "";
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]) + " / POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]) + " / NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]);
						}
					}
					else
					{
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							ViewModel.sprReport.Col = 11;
							ViewModel.sprReport.Text = "";
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "   POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "   NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Col = 11;
							ViewModel.sprReport.Text = "";
							ViewModel.sprReport.Text = "   YES";
						}
					}
				}
			}
			ViewModel.sprReport.Row = 29;
			oCmd.CommandText = "spReport_LatestEMSPersonnelImmunizationsByEmpType 29, '" + modGlobal.Clean(ViewModel.lbEmpID.Text) + "' ";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				if (modGlobal.Clean(oRec["immunize_date"]) != "")
				{
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.Text = "";
					if (modGlobal.Clean(oRec["result_flag"]) != "")
					{
						if (modGlobal.Clean(oRec["result_flag"]) == "P")
						{
							ViewModel.sprReport.Text = "Tetanus:  " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / +";
						}
						else
						{
							ViewModel.sprReport.Text = "Tetanus:  " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / -";
						}
					}
					else
					{
						ViewModel.sprReport.Text = "Tetanus:  " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy");
					}
				}
				else
				{
					if (modGlobal.Clean(oRec["comments"]) != "")
					{
						ViewModel.sprReport.Col = 2;
						ViewModel.sprReport.Text = "";
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "Tetanus:  " + modGlobal.Clean(oRec["comments"]) + " / POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "Tetanus:  " + modGlobal.Clean(oRec["comments"]) + " / NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Text = "Tetanus:  " + modGlobal.Clean(oRec["comments"]);
						}
					}
					else
					{
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							ViewModel.sprReport.Col = 2;
							ViewModel.sprReport.Text = "";
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "Tetanus:   POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "Tetanus:   NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Col = 2;
							ViewModel.sprReport.Text = "";
							ViewModel.sprReport.Text = "Tetanus:   YES";
						}
					}
				}
			}

			oCmd.CommandText = "spReport_LatestEMSPersonnelImmunizationsByEmpType 12, '" + modGlobal.Clean(ViewModel.lbEmpID.Text) + "' ";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				if (modGlobal.Clean(oRec["immunize_date"]) != "")
				{
					ViewModel.sprReport.Col = 5;
					ViewModel.sprReport.Text = "";
					if (modGlobal.Clean(oRec["result_flag"]) != "")
					{
						if (modGlobal.Clean(oRec["result_flag"]) == "P")
						{
							ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / +";
						}
						else
						{
							ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / -";
						}
					}
					else
					{
						ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy");
					}
				}
				else
				{
					if (modGlobal.Clean(oRec["comments"]) != "")
					{
						ViewModel.sprReport.Col = 5;
						ViewModel.sprReport.Text = "";
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]) + " / POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]) + " / NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]);
						}
					}
					else
					{
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							ViewModel.sprReport.Col = 5;
							ViewModel.sprReport.Text = "";
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "   POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "   NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Col = 5;
							ViewModel.sprReport.Text = "";
							ViewModel.sprReport.Text = "   YES";
						}
					}
				}
			}

			oCmd.CommandText = "spReport_LatestEMSPersonnelImmunizationsByEmpType 9, '" + modGlobal.Clean(ViewModel.lbEmpID.Text) + "' ";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				if (modGlobal.Clean(oRec["immunize_date"]) != "")
				{
					ViewModel.sprReport.Col = 8;
					ViewModel.sprReport.Text = "";
					if (modGlobal.Clean(oRec["result_flag"]) != "")
					{
						if (modGlobal.Clean(oRec["result_flag"]) == "P")
						{
							ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / +";
						}
						else
						{
							ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy") + " / -";
						}
					}
					else
					{
						ViewModel.sprReport.Text = "   " + Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/yyyy");
					}
				}
				else
				{
					if (modGlobal.Clean(oRec["comments"]) != "")
					{
						ViewModel.sprReport.Col = 8;
						ViewModel.sprReport.Text = "";
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]) + " / POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]) + " / NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Text = "   " + modGlobal.Clean(oRec["comments"]);
						}
					}
					else
					{
						if (modGlobal.Clean(oRec["result_flag"]) != "")
						{
							ViewModel.sprReport.Col = 8;
							ViewModel.sprReport.Text = "";
							if (modGlobal.Clean(oRec["result_flag"]) == "P")
							{
								ViewModel.sprReport.Text = "   POS +";
							}
							else
							{
								ViewModel.sprReport.Text = "   NEG -";
							}
						}
						else
						{
							ViewModel.sprReport.Col = 8;
							ViewModel.sprReport.Text = "";
							ViewModel.sprReport.Text = "   YES";
						}
					}
				}
			}



		}

		[UpgradeHelpers.Events.Handler]
		internal void cboEmpList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboEmpList.SelectedIndex == -1)
			{
				return;
			}
			ViewModel.lbEmpID.Text = modGlobal.Clean(ViewModel.cboEmpList.Text.Substring(Math.Max(ViewModel.cboEmpList.Text.Length - 5, 0)));

			FormatReport();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmbClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintAbortMsg("Printing Immunization Record Grid");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintFooter was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintFooter("/nPrinted on " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintColHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintColHeaders(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintOrientation was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//Mobilize: Not supprted: sprReport.setPrintOrientation(FPSpreadADO.PrintOrientationConstants.PrintOrientationPortrait);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintSmartPrint was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintSmartPrint(false);

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprReport.PrintSheet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//object tempRefParam = null;
			//WEBMAP_UPGRADE_ISSUE: (1101) FarPoint.Win.Spread.FpSpread.PrintSheet was not upgraded
			ViewModel.sprReport.PrintSheet(null);
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string sStringText = "";
			ViewModel.cboEmpList.Text = "";
			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//Fill All Staff List box
			oCmd.CommandText = "spFullNameList ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboEmpList.Items.Clear();

			while(!oRec.EOF)
			{
				sStringText = Convert.ToString(oRec["name_full"]).Trim() + "  :" + Convert.ToString(oRec["employee_id"]);
				ViewModel.cboEmpList.AddItem(sStringText);
				oRec.MoveNext();
			};
			ViewModel.cboEmpList.Text = "";
			ViewModel.cboEmpList.SelectedIndex = -1;

			if (modGlobal.Clean(modGlobal.Shared.gEmployeeId) != "")
			{
				ViewModel.lbEmpID.Text = modGlobal.Clean(modGlobal.Shared.gEmployeeId);
				for (int i = 0; i <= ViewModel.cboEmpList.Items.Count - 1; i++)
				{
					if (modGlobal.Clean(ViewModel.cboEmpList.GetListItem(i).Substring(Math.Max(ViewModel.cboEmpList.GetListItem(i).Length - 5, 0))) == modGlobal.Clean(modGlobal.Shared.gEmployeeId))
					{
						ViewModel.cboEmpList.Text = ViewModel.cboEmpList.GetListItem(i);
						break;
					}
				}
			}

			FormatReport();

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmImmunizationRecord DefInstance
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

		public static frmImmunizationRecord CreateInstance()
		{
			PTSProject.frmImmunizationRecord theInstance = Shared.Container.Resolve< frmImmunizationRecord>();
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
			ViewModel.sprReport.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprReport.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmImmunizationRecord
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmImmunizationRecordViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmImmunizationRecord m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}