using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmEmployeeSizes))]
	public class frmEmployeeSizesViewModel
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
			this.optUniform = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optUniform
			// 
			this.optUniform.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.optUniform.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optUniform.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.optUniform.Name = "optUniform";
			this.optUniform.TabIndex = 24;
			this.optUniform.Text = "Uniform";
			this.optBunker = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optBunker
			// 
			this.optBunker.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.optBunker.Checked = true;
			this.optBunker.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optBunker.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.optBunker.Name = "optBunker";
			this.optBunker.TabIndex = 23;
			this.optBunker.Text = "Bunker Gear";
			this.cboEmpList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboEmpList
			// 
			this.cboEmpList.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboEmpList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboEmpList.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboEmpList.Name = "cboEmpList";
			this.cboEmpList.TabIndex = 0;
			this.cboEmpList.Text = "cboEmpList";
			this.sprUniformList = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprUniformList.TabIndex = 27;
			this.sprUniformList.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprUniformList.Visible = false;
			this.txtItemSizeDesc = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtItemSizeDesc.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtItemSizeDesc.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtItemSizeDesc.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtItemSizeDesc.Name = "txtItemSizeDesc";
			this.txtItemSizeDesc.TabIndex = 34;
			this.txtItemSizeDesc.Text = "txtItemSizeDesc";
			this.cboUniformItem = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboUniformItem
			// 
			this.cboUniformItem.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboUniformItem.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboUniformItem.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboUniformItem.Name = "cboUniformItem";
			this.cboUniformItem.TabIndex = 30;
			this.cboUniformItem.Text = "cboUniformItem";
			this.dteDateSized = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dteDateSized.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.dteDateSized.Name = "dteDateSized";
			this.dteDateSized.TabIndex = 33;
			this.Label6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label6
			// 
			this.Label6.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label6.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label6.Name = "Label6";
			this.Label6.TabIndex = 35;
			this.Label6.Text = "Uniform Item Size Description";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 31;
			this.Label1.Text = "Select Item";
			this.lbRecordID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRecordID
			// 
			this.lbRecordID.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbRecordID.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbRecordID.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbRecordID.Name = "lbRecordID";
			this.lbRecordID.TabIndex = 29;
			this.lbRecordID.Text = "lbRecordID";
			this.lbRecordID.Visible = false;
			this.txtBootSizeDesc = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtBootSizeDesc.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtBootSizeDesc.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtBootSizeDesc.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtBootSizeDesc.Name = "txtBootSizeDesc";
			this.txtBootSizeDesc.TabIndex = 8;
			this.txtBootSizeDesc.Text = "txtBootSizeDesc";
			this.cboBootSize = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboBootSize
			// 
			this.cboBootSize.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboBootSize.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboBootSize.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboBootSize.Name = "cboBootSize";
			this.cboBootSize.TabIndex = 7;
			this.cboBootSize.Text = "cboBootSize";
			this.cboBootBrand = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboBootBrand
			// 
			this.cboBootBrand.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboBootBrand.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboBootBrand.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboBootBrand.Name = "cboBootBrand";
			this.cboBootBrand.TabIndex = 6;
			this.cboBootBrand.Text = "cboBootBrand";
			this.cboGloveSize = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboGloveSize
			// 
			this.cboGloveSize.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboGloveSize.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboGloveSize.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboGloveSize.Name = "cboGloveSize";
			this.cboGloveSize.TabIndex = 5;
			this.cboGloveSize.Text = "cboGloveSize";
			this.cboPantSize = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboPantSize
			// 
			this.cboPantSize.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboPantSize.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboPantSize.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboPantSize.Name = "cboPantSize";
			this.cboPantSize.TabIndex = 4;
			this.cboPantSize.Text = "cboPantSize";
			this.txtCoatSizeDesc = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtCoatSizeDesc.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtCoatSizeDesc.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtCoatSizeDesc.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtCoatSizeDesc.Name = "txtCoatSizeDesc";
			this.txtCoatSizeDesc.TabIndex = 3;
			this.txtCoatSizeDesc.Text = "txtCoatSizeDesc";
			this.cboCoatSize = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboCoatSize
			// 
			this.cboCoatSize.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboCoatSize.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboCoatSize.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboCoatSize.Name = "cboCoatSize";
			this.cboCoatSize.TabIndex = 2;
			this.cboCoatSize.Text = "cboCoatSize";
			this.dteInDate = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dteInDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.dteInDate.Name = "dteInDate";
			this.dteInDate.TabIndex = 1;
			this.Label5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label5
			// 
			this.Label5.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label5.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label5.Name = "Label5";
			this.Label5.TabIndex = 20;
			this.Label5.Text = "Boot Size Information";
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 19;
			this.Label4.Text = "Boot Brand";
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 18;
			this.Label3.Text = "Glove Size";
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 17;
			this.Label2.Text = "Pant Size";
			this.Label14 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label14
			// 
			this.Label14.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label14.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label14.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label14.Name = "Label14";
			this.Label14.TabIndex = 16;
			this.Label14.Text = "Coat/Jacket Size Information";
			this.sprBunkerList = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprBunkerList.TabIndex = 13;
			this.sprBunkerList.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.lbEmpID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEmpID
			// 
			this.lbEmpID.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbEmpID.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbEmpID.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbEmpID.Name = "lbEmpID";
			this.lbEmpID.TabIndex = 28;
			this.lbEmpID.Text = "lbEmpID";
			this.lbEmpID.Visible = false;
			this.lbTotalCount = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbTotalCount
			// 
			this.lbTotalCount.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbTotalCount.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbTotalCount.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.lbTotalCount.Name = "lbTotalCount";
			this.lbTotalCount.TabIndex = 14;
			this.lbTotalCount.Text = "List Count:  0";
			this.Label11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label11
			// 
			this.Label11.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label11.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label11.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.Label11.Name = "Label11";
			this.Label11.TabIndex = 12;
			this.Label11.Text = "Select Employee:";
			this.sprBunkerList_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprBunkerList_Sheet1.SheetName = "Sheet1";
			this.sprBunkerList_Sheet1.ColumnHeader.Cells[0, 0].Value = "Name";
			this.sprBunkerList_Sheet1.ColumnHeader.Cells[0, 1].Value = "Date";
			this.sprBunkerList_Sheet1.ColumnHeader.Cells[0, 2].Value = "Pants";
			this.sprBunkerList_Sheet1.ColumnHeader.Cells[0, 3].Value = "Coat";
			this.sprBunkerList_Sheet1.ColumnHeader.Cells[0, 4].Value = "Boots Brand";
			this.sprBunkerList_Sheet1.ColumnHeader.Cells[0, 5].Value = "Boots";
			this.sprBunkerList_Sheet1.ColumnHeader.Cells[0, 6].Value = "Gloves";
			this.sprBunkerList_Sheet1.ColumnHeader.Cells[0, 7].Value = "ID";
			this.sprBunkerList_Sheet1.Columns.Get(0).Label = "Name";
			this.sprBunkerList_Sheet1.Columns.Get(0).Width = 143F;
			this.sprBunkerList_Sheet1.Columns.Get(1).Label = "Date";
			this.sprBunkerList_Sheet1.Columns.Get(1).Width = 58F;
			this.sprBunkerList_Sheet1.Columns.Get(2).Label = "Pants";
			this.sprBunkerList_Sheet1.Columns.Get(2).Width = 54F;
			this.sprBunkerList_Sheet1.Columns.Get(3).Label = "Coat";
			this.sprBunkerList_Sheet1.Columns.Get(3).Width = 54F;
			this.sprBunkerList_Sheet1.Columns.Get(4).Label = "Boots Brand";
			this.sprBunkerList_Sheet1.Columns.Get(4).Width = 100F;
			this.sprBunkerList_Sheet1.Columns.Get(5).Label = "Boots";
			this.sprBunkerList_Sheet1.Columns.Get(5).Width = 48F;
			this.sprBunkerList_Sheet1.Columns.Get(6).Label = "Gloves";
			this.sprBunkerList_Sheet1.Columns.Get(6).Width = 50F;
			this.sprBunkerList_Sheet1.Columns.Get(7).Label = "ID";
			this.sprBunkerList_Sheet1.Columns.Get(7).Visible = false;
			this.sprBunkerList_Sheet1.Columns.Get(7).Width = 0F;
			this.sprBunkerList_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprUniformList_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprUniformList_Sheet1.SheetName = "Sheet1";
			this.sprUniformList_Sheet1.ColumnHeader.Cells[0, 0].Value = "Name";
			this.sprUniformList_Sheet1.ColumnHeader.Cells[0, 1].Value = "T-Shirt";
			this.sprUniformList_Sheet1.ColumnHeader.Cells[0, 2].Value = "Polo";
			this.sprUniformList_Sheet1.ColumnHeader.Cells[0, 3].Value = "Shirt";
			this.sprUniformList_Sheet1.ColumnHeader.Cells[0, 4].Value = "Pants";
			this.sprUniformList_Sheet1.ColumnHeader.Cells[0, 5].Value = "ID";
			this.sprUniformList_Sheet1.Columns.Get(0).Label = "Name";
			this.sprUniformList_Sheet1.Columns.Get(0).Width = 158F;
			this.sprUniformList_Sheet1.Columns.Get(1).Label = "T-Shirt";
			this.sprUniformList_Sheet1.Columns.Get(1).Width = 87F;
			this.sprUniformList_Sheet1.Columns.Get(2).Label = "Polo";
			this.sprUniformList_Sheet1.Columns.Get(2).Width = 87F;
			this.sprUniformList_Sheet1.Columns.Get(3).Label = "Shirt";
			this.sprUniformList_Sheet1.Columns.Get(3).Width = 87F;
			this.sprUniformList_Sheet1.Columns.Get(4).Label = "Pants";
			this.sprUniformList_Sheet1.Columns.Get(4).Width = 87F;
			this.sprUniformList_Sheet1.Columns.Get(5).Label = "ID";
			this.sprUniformList_Sheet1.Columns.Get(5).Visible = false;
			this.sprUniformList_Sheet1.Columns.Get(5).Width = 0F;
			this.sprUniformList_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.6F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 11;
			this.cmdClose.Text = "&Close";
			this.chkChangeDate = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkChangeDate
			// 
			this.chkChangeDate.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.chkChangeDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkChangeDate.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.chkChangeDate.Name = "chkChangeDate";
			this.chkChangeDate.TabIndex = 32;
			this.chkChangeDate.Text = "Check to Change Date";
			this.cmdEditUniformSize = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdEditUniformSize
			// 
			this.cmdEditUniformSize.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdEditUniformSize.Enabled = false;
			this.cmdEditUniformSize.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdEditUniformSize.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdEditUniformSize.Name = "cmdEditUniformSize";
			this.cmdEditUniformSize.TabIndex = 26;
			this.cmdEditUniformSize.Tag = "1";
			this.cmdEditUniformSize.Text = "Add";
			this.chkInDate = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkInDate
			// 
			this.chkInDate.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.chkInDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkInDate.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.chkInDate.Name = "chkInDate";
			this.chkInDate.TabIndex = 21;
			this.chkInDate.Text = "Date";
			this.cmdNewRecord = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdNewRecord
			// 
			this.cmdNewRecord.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdNewRecord.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdNewRecord.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdNewRecord.Name = "cmdNewRecord";
			this.cmdNewRecord.TabIndex = 10;
			this.cmdNewRecord.Text = "New Record";
			this.cmdEdit = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdEdit
			// 
			this.cmdEdit.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdEdit.Enabled = false;
			this.cmdEdit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdEdit.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.TabIndex = 9;
			this.cmdEdit.Tag = "1";
			this.cmdEdit.Text = "Add";
			this.Text = "Employee PPE Sizes";
			this.CurrEmpID = "";
			this.frmBunkerDetail = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmBunkerDetail
			// 
			this.frmBunkerDetail.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.frmBunkerDetail.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmBunkerDetail.Name = "frmBunkerDetail";
			this.frmBunkerDetail.TabIndex = 15;
			this.frmUniformDetail = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmUniformDetail
			// 
			this.frmUniformDetail.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.frmUniformDetail.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmUniformDetail.Name = "frmUniformDetail";
			this.frmUniformDetail.TabIndex = 25;
			this.frmUniformDetail.Visible = false;
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234701423839071", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text299636234701423858601", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234701557424271", "DataAreaDefault");
			namedStyle3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.Parent = "DataAreaDefault";
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text299636234701557443801", "DataAreaDefault");
			namedStyle4.CellType = textCellType2;
			namedStyle4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.Parent = "DataAreaDefault";
			namedStyle4.Renderer = textCellType2;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			this.Name = "PTSProject.frmEmployeeSizes";
			IsMdiChild = true;
			this.sprUniformList.NamedStyles.Add(namedStyle1);
			this.sprUniformList.NamedStyles.Add(namedStyle2);
			this.sprUniformList.Sheets.Add(this.sprUniformList_Sheet1);
			this.sprBunkerList.NamedStyles.Add(namedStyle3);
			this.sprBunkerList.NamedStyles.Add(namedStyle4);
			this.sprBunkerList.Sheets.Add(this.sprBunkerList_Sheet1);
		}

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optUniform { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optBunker { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboEmpList { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprUniformList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtItemSizeDesc { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboUniformItem { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dteDateSized { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRecordID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtBootSizeDesc { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboBootSize { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboBootBrand { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboGloveSize { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboPantSize { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtCoatSizeDesc { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboCoatSize { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dteInDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label14 { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprBunkerList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEmpID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbTotalCount { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label11 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprBunkerList_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprUniformList_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkChangeDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdEditUniformSize { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkInDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdNewRecord { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdEdit { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean isInitializingComponent { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrEmpID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmBunkerDetail { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmUniformDetail { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

		public void OntxtItemSizeDesc_TextChanged()
		{
			if ( _txtItemSizeDesc_TextChanged != null )
				_txtItemSizeDesc_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtItemSizeDesc_TextChanged;
	}

}