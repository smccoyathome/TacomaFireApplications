using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmPMCertification))]
	public class frmPMCertificationViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.cboYear = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboYear
			// 
			this.cboYear.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboYear.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboYear.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboYear.Name = "cboYear";
			this.cboYear.TabIndex = 28;
			this.cboYear.Text = "cboYear";
			this._optFGrp_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optFGrp_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optFGrp_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optFGrp_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.txtNameSearch = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtNameSearch.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtNameSearch.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtNameSearch.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtNameSearch.Name = "txtNameSearch";
			this.txtNameSearch.TabIndex = 19;
			this.txtNameSearch.Text = "txtNameSearch";
			this._lbSubTitle_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbCount = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbCount
			// 
			this.lbCount.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.lbCount.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbCount.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.lbCount.Name = "lbCount";
			this.lbCount.TabIndex = 22;
			this.lbCount.Text = "List Count:  ";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 20;
			this.Label1.Text = "Employee Name Search:";
			this._optGroup_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optGroup_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optGroup_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optGroup_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.txtExpireDate = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtExpireDate.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtExpireDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtExpireDate.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtExpireDate.Name = "txtExpireDate";
			this.txtExpireDate.TabIndex = 4;
			this.txtExpireDate.Text = "txtExpireDate";
			this.txtNRNumber = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtNRNumber.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtNRNumber.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtNRNumber.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtNRNumber.Name = "txtNRNumber";
			this.txtNRNumber.TabIndex = 3;
			this.txtNRNumber.Text = "txtNRNumber";
			this.txtStateNumber = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtStateNumber.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtStateNumber.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtStateNumber.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtStateNumber.Name = "txtStateNumber";
			this.txtStateNumber.TabIndex = 2;
			this.txtStateNumber.Text = "txtStateNumber";
			this.txtCountyNumber = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtCountyNumber.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtCountyNumber.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtCountyNumber.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtCountyNumber.Name = "txtCountyNumber";
			this.txtCountyNumber.TabIndex = 1;
			this.txtCountyNumber.Text = "txtCountyNumber";
			this.Label7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label7
			// 
			this.Label7.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label7.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label7.Name = "Label7";
			this.Label7.TabIndex = 9;
			this.Label7.Text = "Cert Expiration Date:";
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 8;
			this.Label2.Text = "N R #:";
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 7;
			this.Label3.Text = "State #:";
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 6;
			this.Label4.Text = "County #:";
			this.Label5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label5
			// 
			this.Label5.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label5.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.Label5.Name = "Label5";
			this.Label5.TabIndex = 5;
			this.Label5.Text = "M/D/YYYY";
			this.sprEmployeeList = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprEmployeeList.MaxRows = 600;
			this.sprEmployeeList.TabIndex = 10;
			this.sprEmployeeList.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprEmployeeList_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprEmployeeList_Sheet1.SheetName = "Sheet1";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 0].Value = "Empl #";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 1].Value = "Name";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 2].Value = "Grp #";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 3].Value = "Unit";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 4].Value = "Shft";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 5].Value = "Position";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 6].Value = "Cert Exp";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 7].Value = "ID";
			this.sprEmployeeList_Sheet1.ColumnHeader.Rows.Get(0).Height = 27F;
			this.sprEmployeeList_Sheet1.Columns.Get(0).Label = "Empl #";
			this.sprEmployeeList_Sheet1.Columns.Get(0).Width = 49F;
			this.sprEmployeeList_Sheet1.Columns.Get(1).Label = "Name";
			this.sprEmployeeList_Sheet1.Columns.Get(1).Width = 154F;
			this.sprEmployeeList_Sheet1.Columns.Get(2).Label = "Grp #";
			this.sprEmployeeList_Sheet1.Columns.Get(2).Width = 33F;
			this.sprEmployeeList_Sheet1.Columns.Get(3).Label = "Unit";
			//this.sprEmployeeList_Sheet1.Columns.Get(3).SortIndicator = FarPoint.ViewModels.SortIndicator.Ascending;
			this.sprEmployeeList_Sheet1.Columns.Get(3).Width = 34F;
			this.sprEmployeeList_Sheet1.Columns.Get(4).Label = "Shft";
			this.sprEmployeeList_Sheet1.Columns.Get(4).Width = 26F;
			this.sprEmployeeList_Sheet1.Columns.Get(5).Label = "Position";
			this.sprEmployeeList_Sheet1.Columns.Get(5).Width = 51F;
			this.sprEmployeeList_Sheet1.Columns.Get(6).Label = "Cert Exp";
			this.sprEmployeeList_Sheet1.Columns.Get(6).Width = 58F;
			this.sprEmployeeList_Sheet1.Columns.Get(7).Label = "ID";
			this.sprEmployeeList_Sheet1.Columns.Get(7).Visible = false;
			this.sprEmployeeList_Sheet1.Columns.Get(7).Width = 0F;
			this.sprEmployeeList_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprEmployeeList_Sheet1.Rows.Get(0).Height = 14F;
			this.cmdClear = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClear
			// 
			this.cmdClear.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClear.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClear.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClear.Name = "cmdClear";
			this.cmdClear.TabIndex = 21;
			this.cmdClear.Text = "Clear and Refresh";
			this.cmdExit = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdExit
			// 
			this.cmdExit.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdExit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdExit.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdExit.Name = "cmdExit";
			this.cmdExit.TabIndex = 18;
			this.cmdExit.Text = "Exit";
			this.chkMedicFlag = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkMedicFlag
			// 
			this.chkMedicFlag.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.chkMedicFlag.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkMedicFlag.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.chkMedicFlag.Name = "chkMedicFlag";
			this.chkMedicFlag.TabIndex = 30;
			this.chkMedicFlag.Text = "Available to Work As Medic?";
			this.cmdDone = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdDone
			// 
			this.cmdDone.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdDone.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdDone.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdDone.Name = "cmdDone";
			this.cmdDone.TabIndex = 11;
			this.cmdDone.Text = "Done";
			this.Text = "TFD EMS Certification Information";
			this._clCerts = null;
			this.CurrPersID = 0;
			optGroup = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(4);
			optGroup[3] = _optGroup_3;
			optGroup[2] = _optGroup_2;
			optGroup[1] = _optGroup_1;
			optGroup[0] = _optGroup_0;
			optGroup[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			optGroup[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optGroup[3].ForeColor = UpgradeHelpers.Helpers.Color.Lime;
			optGroup[3].Name = "_optGroup_3";
			optGroup[3].TabIndex = 16;
			optGroup[3].Text = "Group 3";
			optGroup[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			optGroup[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optGroup[2].ForeColor = UpgradeHelpers.Helpers.Color.Lime;
			optGroup[2].Name = "_optGroup_2";
			optGroup[2].TabIndex = 15;
			optGroup[2].Text = "Group 2";
			optGroup[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			optGroup[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optGroup[1].ForeColor = UpgradeHelpers.Helpers.Color.Lime;
			optGroup[1].Name = "_optGroup_1";
			optGroup[1].TabIndex = 14;
			optGroup[1].Text = "Group1";
			optGroup[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			optGroup[0].Checked = true;
			optGroup[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optGroup[0].ForeColor = UpgradeHelpers.Helpers.Color.Lime;
			optGroup[0].Name = "_optGroup_0";
			optGroup[0].TabIndex = 13;
			optGroup[0].Text = "No Group";
			this.RecordExists = false;
			this.FirstTime = false;
			optFGrp = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(4);
			optFGrp[0] = _optFGrp_0;
			optFGrp[1] = _optFGrp_1;
			optFGrp[2] = _optFGrp_2;
			optFGrp[3] = _optFGrp_3;
			optFGrp[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			optFGrp[0].Checked = true;
			optFGrp[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optFGrp[0].ForeColor = UpgradeHelpers.Helpers.Color.Lime;
			optFGrp[0].Name = "_optFGrp_0";
			optFGrp[0].TabIndex = 27;
			optFGrp[0].Text = "ALL";
			optFGrp[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			optFGrp[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optFGrp[1].ForeColor = UpgradeHelpers.Helpers.Color.Lime;
			optFGrp[1].Name = "_optFGrp_1";
			optFGrp[1].TabIndex = 26;
			optFGrp[1].Text = "Group1";
			optFGrp[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			optFGrp[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optFGrp[2].ForeColor = UpgradeHelpers.Helpers.Color.Lime;
			optFGrp[2].Name = "_optFGrp_2";
			optFGrp[2].TabIndex = 25;
			optFGrp[2].Text = "Group 2";
			optFGrp[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			optFGrp[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optFGrp[3].ForeColor = UpgradeHelpers.Helpers.Color.Lime;
			optFGrp[3].Name = "_optFGrp_3";
			optFGrp[3].TabIndex = 24;
			optFGrp[3].Text = "Group 3";
			this.SelectedEmpRow = 0;
			lbSubTitle = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(3);
			lbSubTitle[2] = _lbSubTitle_2;
			lbSubTitle[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbSubTitle[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbSubTitle[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			lbSubTitle[2].Name = "_lbSubTitle_2";
			lbSubTitle[2].TabIndex = 29;
			lbSubTitle[2].Text = "Filter by Cert Exp Year:";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234755222598276", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8F);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text273636234755222598276", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8F);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			this.Name = "PTSProject.frmPMCertification";
			IsMdiChild = true;
			this.sprEmployeeList.NamedStyles.Add(namedStyle1);
			this.sprEmployeeList.NamedStyles.Add(namedStyle2);
			this.sprEmployeeList.Sheets.Add(this.sprEmployeeList_Sheet1);
		}

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboYear { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optFGrp_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optFGrp_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optFGrp_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optFGrp_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtNameSearch { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbSubTitle_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbCount { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optGroup_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optGroup_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optGroup_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optGroup_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtExpireDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtNRNumber { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtStateNumber { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtCountyNumber { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label5 { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprEmployeeList { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprEmployeeList_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClear { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdExit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkMedicFlag { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdDone { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean isInitializingComponent { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual PTSProject.clsTraining _clCerts { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrPersID { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optGroup { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean RecordExists { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean FirstTime { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optFGrp { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 SelectedEmpRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbSubTitle { get; set; }

		public virtual bool IsMdiChild { get; set; }

		public void OntxtNameSearch_TextChanged()
		{
			if ( _txtNameSearch_TextChanged != null )
				_txtNameSearch_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtNameSearch_TextChanged;

		public void OntxtExpireDate_TextChanged()
		{
			if ( _txtExpireDate_TextChanged != null )
				_txtExpireDate_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtExpireDate_TextChanged;
	}

}