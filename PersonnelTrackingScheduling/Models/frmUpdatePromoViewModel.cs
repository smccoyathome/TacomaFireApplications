using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmUpdatePromo))]
	public class frmUpdatePromoViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.sprPromoList = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprPromoList.TabIndex = 15;
			this.sprPromoList.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprPromoList.Visible = false;
			this.txtComment = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtComment.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtComment.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtComment.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtComment.Name = "txtComment";
			this.txtComment.TabIndex = 5;
			this.txtComment.Text = "txtComment";
			this.txtComment.Visible = false;
			this.txtExclusion = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtExclusion.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtExclusion.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtExclusion.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtExclusion.Name = "txtExclusion";
			this.txtExclusion.TabIndex = 3;
			this.txtExclusion.Text = "txtExclusion";
			this.txtExclusion.Visible = false;
			this.txtPromoDate = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtPromoDate.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtPromoDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtPromoDate.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtPromoDate.Name = "txtPromoDate";
			this.txtPromoDate.TabIndex = 2;
			this.txtPromoDate.Text = "txtPromoDate";
			this.txtPromoDate.Visible = false;
			this.cboPromotion = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboPromotion
			// 
			this.cboPromotion.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboPromotion.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboPromotion.Name = "cboPromotion";
			this.cboPromotion.TabIndex = 1;
			this.cboPromotion.Text = "cboPromotion";
			this.lbAction = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAction
			// 
			this.lbAction.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.lbAction.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbAction.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.lbAction.Name = "lbAction";
			this.lbAction.TabIndex = 14;
			this.lbAction.Text = "Action";
			this.lbAction.Visible = false;
			this.lbEntry3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEntry3
			// 
			this.lbEntry3.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.lbEntry3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbEntry3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.lbEntry3.Name = "lbEntry3";
			this.lbEntry3.TabIndex = 13;
			this.lbEntry3.Text = "Comments";
			this.lbEntry3.Visible = false;
			this.lbEntry2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEntry2
			// 
			this.lbEntry2.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.lbEntry2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbEntry2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.lbEntry2.Name = "lbEntry2";
			this.lbEntry2.TabIndex = 12;
			this.lbEntry2.Text = "Exclusion Days";
			this.lbEntry2.Visible = false;
			this.lbEntry1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEntry1
			// 
			this.lbEntry1.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.lbEntry1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbEntry1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.lbEntry1.Name = "lbEntry1";
			this.lbEntry1.TabIndex = 11;
			this.lbEntry1.Text = "Promotion Date";
			this.lbEntry1.Visible = false;
			this.lbEmpId = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEmpId
			// 
			this.lbEmpId.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbEmpId.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbEmpId.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.lbEmpId.Name = "lbEmpId";
			this.lbEmpId.TabIndex = 10;
			this.lbEmpId.Visible = false;
			this.lbName = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbName
			// 
			this.lbName.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.lbName.Name = "lbName";
			this.lbName.TabIndex = 9;
			this.lbName.Visible = false;
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 0;
			this.Label1.Text = "Select Promotion List";
			this.Shape1 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this.Shape1.Enabled = false;
			this.Shape1.Name = "Shape1";
			this.Shape1.TabIndex = 17;
			this.sprPromoList_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprPromoList_Sheet1.SheetName = "Sheet1";
			this.sprPromoList_Sheet1.ColumnHeader.Cells[0, 0].Value = "Name";
			this.sprPromoList_Sheet1.ColumnHeader.Cells[0, 1].Value = "Promotion Date";
			this.sprPromoList_Sheet1.ColumnHeader.Cells[0, 2].Value = "ID";
			this.sprPromoList_Sheet1.ColumnHeader.Rows.Get(0).Height = 17F;
			this.sprPromoList_Sheet1.Columns.Get(0).Label = "Name";
			//this.sprPromoList_Sheet1.Columns.Get(0).SortIndicator = FarPoint.ViewModels.SortIndicator.Ascending;
			this.sprPromoList_Sheet1.Columns.Get(0).Width = 226F;
			this.sprPromoList_Sheet1.Columns.Get(1).Label = "Promotion Date";
			this.sprPromoList_Sheet1.Columns.Get(1).Width = 107F;
			this.sprPromoList_Sheet1.Columns.Get(2).Label = "ID";
			this.sprPromoList_Sheet1.Columns.Get(2).Visible = false;
			this.sprPromoList_Sheet1.Columns.Get(2).Width = 0F;
			this.sprPromoList_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.cmdPrint = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrint.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8.25F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrint.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.TabIndex = 16;
			this.cmdPrint.Text = "Print List";
			this.cmdPrint.Visible = false;
			this.cmdRemove = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdRemove
			// 
			this.cmdRemove.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdRemove.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8.25F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdRemove.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdRemove.Name = "cmdRemove";
			this.cmdRemove.TabIndex = 7;
			this.cmdRemove.Text = "&Remove";
			this.cmdRemove.Visible = false;
			this.cmdUpdate = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdUpdate
			// 
			this.cmdUpdate.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdUpdate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8.25F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdUpdate.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdUpdate.Name = "cmdUpdate";
			this.cmdUpdate.TabIndex = 6;
			this.cmdUpdate.Text = "&Update";
			this.cmdUpdate.Visible = false;
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8.25F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 8;
			this.cmdClose.Text = "&Close";
			this.Text = "Update Promotion Lists";
			this.iSelectedRow = 0;
			this.CurrPromoID = 0;
			this.chkActive = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkActive
			// 
			this.chkActive.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.chkActive.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkActive.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.chkActive.Name = "chkActive";
			this.chkActive.TabIndex = 4;
			this.chkActive.Text = "Active for this List?";
			this.chkActive.Visible = false;
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234787629801426", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text307636234787629811191", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			this.Name = "PTSProject.frmUpdatePromo";
			IsMdiChild = true;
			this.sprPromoList.NamedStyles.Add(namedStyle1);
			this.sprPromoList.NamedStyles.Add(namedStyle2);
			this.sprPromoList.Sheets.Add(this.sprPromoList_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprPromoList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtComment { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtExclusion { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtPromoDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboPromotion { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAction { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEntry3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEntry2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEntry1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEmpId { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel Shape1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprPromoList_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdRemove { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdUpdate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 iSelectedRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrPromoID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkActive { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}