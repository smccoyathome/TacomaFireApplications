using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmEmployeeNotes))]
	public class frmEmployeeNotesViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType2 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.sprPastComments = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprPastComments.MaxRows = 20;
			this.sprPastComments.TabIndex = 6;
			this.sprPastComments.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.txtNewNote = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtNewNote.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtNewNote.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtNewNote.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtNewNote.Name = "txtNewNote";
			this.txtNewNote.TabIndex = 5;
			this.txtNewNote.Text = "txtNewNote";
			this.cboEmpList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboEmpList
			// 
			this.cboEmpList.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboEmpList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboEmpList.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboEmpList.Name = "cboEmpList";
			this.cboEmpList.TabIndex = 1;
			this.cboEmpList.Text = "cboEmpList";
			this.lbNoteID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbNoteID
			// 
			this.lbNoteID.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbNoteID.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbNoteID.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbNoteID.Name = "lbNoteID";
			this.lbNoteID.TabIndex = 7;
			this.lbNoteID.Text = "lbNoteID";
			this.lbNoteID.Visible = false;
			this.Label11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label11
			// 
			this.Label11.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label11.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label11.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label11.Name = "Label11";
			this.Label11.TabIndex = 3;
			this.Label11.Text = "Select Employee:";
			this.lbEmpID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEmpID
			// 
			this.lbEmpID.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbEmpID.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbEmpID.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbEmpID.Name = "lbEmpID";
			this.lbEmpID.TabIndex = 2;
			this.lbEmpID.Text = "lbEmpID";
			this.lbEmpID.Visible = false;
			this.sprPastComments_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprPastComments_Sheet1.SheetName = "Sheet1";
			this.sprPastComments_Sheet1.ColumnHeader.Cells[0, 0].Value = "Previous Notes";
			this.sprPastComments_Sheet1.ColumnHeader.Cells[0, 1].Value = "ID";
			this.sprPastComments_Sheet1.Columns.Get(0).Label = "Previous Notes";
			this.sprPastComments_Sheet1.Columns.Get(0).Width = 431F;
			this.sprPastComments_Sheet1.Columns.Get(1).Label = "ID";
			this.sprPastComments_Sheet1.Columns.Get(1).Visible = false;
			this.sprPastComments_Sheet1.Columns.Get(1).Width = 0F;
			this.sprPastComments_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.cmdNewNote = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdNewNote
			// 
			this.cmdNewNote.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdNewNote.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdNewNote.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdNewNote.Name = "cmdNewNote";
			this.cmdNewNote.TabIndex = 8;
			this.cmdNewNote.Text = "Add New Note";
			this.cmdAddUpdate = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAddUpdate
			// 
			this.cmdAddUpdate.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAddUpdate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdAddUpdate.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAddUpdate.Name = "cmdAddUpdate";
			this.cmdAddUpdate.TabIndex = 4;
			this.cmdAddUpdate.Text = "Save Note";
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 0;
			this.cmdClose.Text = "&Close";
			this.Text = "Employee Notes For:  ";
			this.CurrEmpID = "";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx58636234699016327146", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text329636234699016346676", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text892636234699016395501");
			namedStyle3.CellType = textCellType2;
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.Renderer = textCellType2;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			this.Name = "PTSProject.frmEmployeeNotes";
			IsMdiChild = true;
			this.sprPastComments.NamedStyles.Add(namedStyle1);
			this.sprPastComments.NamedStyles.Add(namedStyle2);
			this.sprPastComments.NamedStyles.Add(namedStyle3);
			this.sprPastComments.Sheets.Add(this.sprPastComments_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprPastComments { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtNewNote { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboEmpList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbNoteID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEmpID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprPastComments_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdNewNote { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAddUpdate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrEmpID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}