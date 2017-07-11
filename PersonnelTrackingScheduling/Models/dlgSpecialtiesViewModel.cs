using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.dlgSpecialties))]
	public class dlgSpecialtiesViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType2 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle4;
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.sprSpecialtyList = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprSpecialtyList.TabIndex = 5;
			this.sprSpecialtyList.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.OptOmitBCList = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// OptOmitBCList
			// 
			this.OptOmitBCList.BackColor = UpgradeHelpers.Helpers.Color.Teal;
			this.OptOmitBCList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.OptOmitBCList.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.OptOmitBCList.Name = "OptOmitBCList";
			this.OptOmitBCList.TabIndex = 4;
			this.OptOmitBCList.Text = "Omit From Battalion Payroll list";
			this.OptTempUpgrade = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// OptTempUpgrade
			// 
			this.OptTempUpgrade.BackColor = UpgradeHelpers.Helpers.Color.Teal;
			this.OptTempUpgrade.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.OptTempUpgrade.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.OptTempUpgrade.Name = "OptTempUpgrade";
			this.OptTempUpgrade.TabIndex = 3;
			this.OptTempUpgrade.Text = "Temporary Payroll Upgrades";
			this.optFCCDispatcher = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optFCCDispatcher
			// 
			this.optFCCDispatcher.BackColor = UpgradeHelpers.Helpers.Color.Teal;
			this.optFCCDispatcher.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optFCCDispatcher.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.optFCCDispatcher.Name = "optFCCDispatcher";
			this.optFCCDispatcher.TabIndex = 2;
			this.optFCCDispatcher.Text = "FCC Field Relief Dispatchers";
			this.OptParamedic = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// OptParamedic
			// 
			this.OptParamedic.BackColor = UpgradeHelpers.Helpers.Color.Teal;
			this.OptParamedic.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.OptParamedic.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.OptParamedic.Name = "OptParamedic";
			this.OptParamedic.TabIndex = 1;
			this.OptParamedic.Text = "Paramedic";
			this.sprEmployeeList = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprEmployeeList.TabIndex = 8;
			this.sprEmployeeList.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.cboStep = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboStep
			// 
			this.cboStep.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboStep.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboStep.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboStep.Name = "cboStep";
			this.cboStep.TabIndex = 15;
			this.cboStep.Text = "cboStep";
			this.cboJobCode = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboJobCode
			// 
			this.cboJobCode.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboJobCode.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboJobCode.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboJobCode.Name = "cboJobCode";
			this.cboJobCode.TabIndex = 14;
			this.cboJobCode.Text = "cboJobCode";
			this.lbUpgradeName = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbUpgradeName
			// 
			this.lbUpgradeName.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbUpgradeName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbUpgradeName.ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			this.lbUpgradeName.Name = "lbUpgradeName";
			this.lbUpgradeName.TabIndex = 19;
			this.lbUpgradeName.Text = "Employee\'s Name";
			this.Label12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label12
			// 
			this.Label12.BackColor = UpgradeHelpers.Helpers.Color.Teal;
			this.Label12.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label12.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.Label12.Name = "Label12";
			this.Label12.TabIndex = 17;
			this.Label12.Text = "Level";
			this.Label9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label9
			// 
			this.Label9.BackColor = UpgradeHelpers.Helpers.Color.Teal;
			this.Label9.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label9.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.Label9.Name = "Label9";
			this.Label9.TabIndex = 16;
			this.Label9.Text = "PS Group";
			this.txtComment = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtComment.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtComment.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtComment.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtComment.Name = "txtComment";
			this.txtComment.TabIndex = 21;
			this.txtComment.Text = "txtComment";
			this.cboRemoveCode = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboRemoveCode
			// 
			this.cboRemoveCode.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboRemoveCode.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboRemoveCode.Name = "cboRemoveCode";
			this.cboRemoveCode.TabIndex = 20;
			this.cboRemoveCode.Text = "cboRemoveCode";
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.Teal;
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 25;
			this.Label3.Text = "Comment:";
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Teal;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 24;
			this.Label2.Text = "Select Reason:";
			this.lbRemoveName = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRemoveName
			// 
			this.lbRemoveName.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRemoveName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbRemoveName.ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			this.lbRemoveName.Name = "lbRemoveName";
			this.lbRemoveName.TabIndex = 22;
			this.lbRemoveName.Text = "Employee\'s Name";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 7;
			this.Label1.Text = "TFD Emloyees";
			this.lbGroup = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbGroup
			// 
			this.lbGroup.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbGroup.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbGroup.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.lbGroup.Name = "lbGroup";
			this.lbGroup.TabIndex = 6;
			this.lbGroup.Text = "lbGroup";
			this.sprEmployeeList_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprEmployeeList_Sheet1.SheetName = "Sheet1";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 0].Value = "Name";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 1].Value = "Emp ID";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 2].Value = "ID";
			this.sprEmployeeList_Sheet1.Columns.Get(0).Label = "Name";
			this.sprEmployeeList_Sheet1.Columns.Get(0).Width = 151F;
			this.sprEmployeeList_Sheet1.Columns.Get(1).Label = "Emp ID";
			this.sprEmployeeList_Sheet1.Columns.Get(1).Width = 59F;
			this.sprEmployeeList_Sheet1.Columns.Get(2).Label = "ID";
			this.sprEmployeeList_Sheet1.Columns.Get(2).Visible = false;
			this.sprEmployeeList_Sheet1.Columns.Get(2).Width = 0F;
			this.sprEmployeeList_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprSpecialtyList_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprSpecialtyList_Sheet1.SheetName = "Sheet1";
			this.sprSpecialtyList_Sheet1.ColumnHeader.Cells[0, 0].Value = "Name";
			this.sprSpecialtyList_Sheet1.ColumnHeader.Cells[0, 1].Value = "Emp ID";
			this.sprSpecialtyList_Sheet1.ColumnHeader.Cells[0, 2].Value = "ID";
			this.sprSpecialtyList_Sheet1.Columns.Get(0).Label = "Name";
			this.sprSpecialtyList_Sheet1.Columns.Get(0).Width = 151F;
			this.sprSpecialtyList_Sheet1.Columns.Get(1).Label = "Emp ID";
			this.sprSpecialtyList_Sheet1.Columns.Get(1).Width = 59F;
			this.sprSpecialtyList_Sheet1.Columns.Get(2).Label = "ID";
			this.sprSpecialtyList_Sheet1.Columns.Get(2).Visible = false;
			this.sprSpecialtyList_Sheet1.Columns.Get(2).Width = 0F;
			this.sprSpecialtyList_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 11;
			this.cmdClose.Text = "Close";
			this.cmdRemove = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdRemove
			// 
			this.cmdRemove.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdRemove.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdRemove.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdRemove.Name = "cmdRemove";
			this.cmdRemove.TabIndex = 10;
			this.cmdRemove.Text = "Remove >";
			this.cmdAdd = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAdd
			// 
			this.cmdAdd.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAdd.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdAdd.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.TabIndex = 9;
			this.cmdAdd.Text = "< Add";
			this.cmdSaveUpdate = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdSaveUpdate
			// 
			this.cmdSaveUpdate.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdSaveUpdate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdSaveUpdate.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdSaveUpdate.Name = "cmdSaveUpdate";
			this.cmdSaveUpdate.TabIndex = 18;
			this.cmdSaveUpdate.Text = "Save";
			this.cmdSaveReason = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdSaveReason
			// 
			this.cmdSaveReason.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdSaveReason.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdSaveReason.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdSaveReason.Name = "cmdSaveReason";
			this.cmdSaveReason.TabIndex = 23;
			this.cmdSaveReason.Text = "Save";
			this.Text = "Personnel Specialty Groups";
			this.EmployeeID = "";
			this.PersonnelID = 0;
			this.EmployeeRow = 0;
			this.SpecialtyRow = 0;
			this.frmUpgradeInfo = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmUpgradeInfo
			// 
			this.frmUpgradeInfo.BackColor = UpgradeHelpers.Helpers.Color.Teal;
			this.frmUpgradeInfo.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, ((UpgradeHelpers
					.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.frmUpgradeInfo.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.frmUpgradeInfo.Name = "frmUpgradeInfo";
			this.frmUpgradeInfo.TabIndex = 12;
			this.frmUpgradeInfo.Text = "Employee Upgrade Information ";
			this.frmUpgradeInfo.Visible = false;
			this.frmRemoveReason = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmRemoveReason
			// 
			this.frmRemoveReason.BackColor = UpgradeHelpers.Helpers.Color.Teal;
			this.frmRemoveReason.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, ((UpgradeHelpers
						.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.frmRemoveReason.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.frmRemoveReason.Name = "frmRemoveReason";
			this.frmRemoveReason.TabIndex = 13;
			this.frmRemoveReason.Text = "Employee Omit Reason/Comment ";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234661054825776", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text288636234661054835541", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234661136822481", "DataAreaDefault");
			namedStyle3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.Parent = "DataAreaDefault";
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text299636234661136832246", "DataAreaDefault");
			namedStyle4.CellType = textCellType2;
			namedStyle4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.Parent = "DataAreaDefault";
			namedStyle4.Renderer = textCellType2;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			this.Name = "PTSProject.dlgSpecialties";
			IsMdiChild = true;
			this.sprSpecialtyList.NamedStyles.Add(namedStyle1);
			this.sprSpecialtyList.NamedStyles.Add(namedStyle2);
			this.sprSpecialtyList.Sheets.Add(this.sprSpecialtyList_Sheet1);
			this.sprEmployeeList.NamedStyles.Add(namedStyle3);
			this.sprEmployeeList.NamedStyles.Add(namedStyle4);
			this.sprEmployeeList.Sheets.Add(this.sprEmployeeList_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprSpecialtyList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel OptOmitBCList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel OptTempUpgrade { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optFCCDispatcher { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel OptParamedic { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprEmployeeList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboStep { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboJobCode { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbUpgradeName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtComment { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboRemoveCode { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRemoveName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbGroup { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprEmployeeList_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprSpecialtyList_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdRemove { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAdd { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdSaveUpdate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdSaveReason { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean isInitializingComponent { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String EmployeeID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 PersonnelID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 EmployeeRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 SpecialtyRow { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmUpgradeInfo { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmRemoveReason { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}