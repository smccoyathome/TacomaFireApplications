using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmAssign))]
	public class frmAssignViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.cboNameList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboNameList
			// 
			this.cboNameList.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboNameList.Enabled = true;
			this.cboNameList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboNameList.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboNameList.Name = "cboNameList";
			this.cboNameList.TabIndex = 7;
			this.cboNameList.Text = "cboNameList";
			this.cboNameList.Visible = true;
			this.lbAssign = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAssign
			// 
			this.lbAssign.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbAssign.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbAssign.Name = "lbAssign";
			this.lbAssign.TabIndex = 21;
			this.lbAssign.Text = "lbAssign";
			this.lbAssign.Visible = false;
			this.lbEmpID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEmpID
			// 
			this.lbEmpID.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbEmpID.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbEmpID.Name = "lbEmpID";
			this.lbEmpID.TabIndex = 20;
			this.lbEmpID.Text = "lbEmpID";
			this.lbEmpID.Visible = false;
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 0);
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 19;
			this.Label3.Text = "Unit";
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 0);
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 18;
			this.Label4.Text = "Position";
			this.Label5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label5
			// 
			this.Label5.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label5.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 0);
			this.Label5.Name = "Label5";
			this.Label5.TabIndex = 17;
			this.Label5.Text = "Shift";
			this.Label9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label9
			// 
			this.Label9.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label9.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label9.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 0);
			this.Label9.Name = "Label9";
			this.Label9.TabIndex = 16;
			this.Label9.Text = "Active Assignment";
			this.Label10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label10
			// 
			this.Label10.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label10.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label10.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.Label10.Name = "Label10";
			this.Label10.TabIndex = 15;
			this.Label10.Text = "Full Name";
			this.Line2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Line2
			// 
			this.Line2.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 64);
			this.Line2.Enabled = false;
			this.Line2.Name = "Line2";
			this.Line2.Visible = true;
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 0);
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 14;
			this.Label2.Text = "Batt";
			this.lbUnit = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbUnit
			// 
			this.lbUnit.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbUnit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbUnit.ForeColor = UpgradeHelpers.Helpers.Color.Teal;
			this.lbUnit.Name = "lbUnit";
			this.lbUnit.TabIndex = 13;
			this.lbPosition = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbPosition
			// 
			this.lbPosition.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbPosition.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbPosition.ForeColor = UpgradeHelpers.Helpers.Color.Teal;
			this.lbPosition.Name = "lbPosition";
			this.lbPosition.TabIndex = 12;
			this.lbShift = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbShift
			// 
			this.lbShift.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbShift.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbShift.ForeColor = UpgradeHelpers.Helpers.Color.Teal;
			this.lbShift.Name = "lbShift";
			this.lbShift.TabIndex = 11;
			this.lbAAssign = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAAssign
			// 
			this.lbAAssign.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAAssign.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbAAssign.ForeColor = UpgradeHelpers.Helpers.Color.Teal;
			this.lbAAssign.Name = "lbAAssign";
			this.lbAAssign.TabIndex = 10;
			this.lbBatt = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbBatt
			// 
			this.lbBatt.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbBatt.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbBatt.ForeColor = UpgradeHelpers.Helpers.Color.Teal;
			this.lbBatt.Name = "lbBatt";
			this.lbBatt.TabIndex = 9;
			this.Shape6 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this.Shape6.Enabled = false;
			this.Shape6.Name = "Shape6";
			this.Shape6.Visible = true;
			this.Shape2 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this.Shape2.Enabled = false;
			this.Shape2.Name = "Shape2";
			this.Shape2.Visible = true;
			this.Picture1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>();
			// 
			// Picture1
			// 
			this.Picture1.BackColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.Picture1.Enabled = true;
			this.Picture1.Name = "Picture1";
			this.Picture1.Visible = true;
			this.Picture2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>();
			// 
			// Picture2
			// 
			this.Picture2.BackColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.Picture2.Enabled = true;
			this.Picture2.Name = "Picture2";
			this.Picture2.Visible = true;
			this.cboShiftList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboShiftList
			// 
			this.cboShiftList.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboShiftList.Enabled = true;
			this.cboShiftList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboShiftList.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboShiftList.Name = "cboShiftList";
			this.cboShiftList.TabIndex = 25;
			this.cboShiftList.Text = "cboShiftList";
			this.cboShiftList.Visible = true;
			this.cboPositionList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboPositionList
			// 
			this.cboPositionList.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboPositionList.Enabled = true;
			this.cboPositionList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboPositionList.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboPositionList.Name = "cboPositionList";
			this.cboPositionList.TabIndex = 24;
			this.cboPositionList.Visible = true;
			this.cboUnitList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboUnitList
			// 
			this.cboUnitList.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboUnitList.Enabled = true;
			this.cboUnitList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboUnitList.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboUnitList.Name = "cboUnitList";
			this.cboUnitList.TabIndex = 23;
			this.cboUnitList.Text = "cboUnitList";
			this.cboUnitList.Visible = true;
			this.Label6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label6
			// 
			this.Label6.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label6.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label6.Name = "Label6";
			this.Label6.TabIndex = 28;
			this.Label6.Text = "New Position";
			this.Label7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label7
			// 
			this.Label7.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label7.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label7.Name = "Label7";
			this.Label7.TabIndex = 27;
			this.Label7.Text = "New Unit";
			this.Label8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label8
			// 
			this.Label8.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label8.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label8.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label8.Name = "Label8";
			this.Label8.TabIndex = 26;
			this.Label8.Text = "New Shift";
			this.Picture3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>();
			// 
			// Picture3
			// 
			this.Picture3.BackColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.Picture3.Enabled = true;
			this.Picture3.Name = "Picture3";
			this.Picture3.Visible = true;
			this.cmdRefresh = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdRefresh
			// 
			this.cmdRefresh.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdRefresh.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdRefresh.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdRefresh.Name = "cmdRefresh";
			this.cmdRefresh.TabIndex = 8;
			this.cmdRefresh.Text = "Refresh";
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 5;
			this.cmdClose.Text = "&Close";
			this.cmdNewPromo = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdNewPromo
			// 
			this.cmdNewPromo.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdNewPromo.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdNewPromo.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdNewPromo.Name = "cmdNewPromo";
			this.cmdNewPromo.TabIndex = 4;
			this.cmdNewPromo.Text = "&New Promotion";
			this.cmdUpdate = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdUpdate
			// 
			this.cmdUpdate.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdUpdate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdUpdate.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdUpdate.Name = "cmdUpdate";
			this.cmdUpdate.TabIndex = 3;
			this.cmdUpdate.Text = "&Update Assignment";
			this.cmdAdjust = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAdjust
			// 
			this.cmdAdjust.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAdjust.Enabled = false;
			this.cmdAdjust.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdAdjust.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAdjust.Name = "cmdAdjust";
			this.cmdAdjust.TabIndex = 2;
			this.cmdAdjust.Text = "&Adjust Assignment";
			this.Text = "Assignment Information";
			this.Name = "PTSProject.frmAssign";
			IsMdiChild = true;
		}

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboNameList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAssign { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEmpID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Line2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbUnit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbPosition { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbShift { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAAssign { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbBatt { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel Shape6 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel Shape2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PictureBoxViewModel Picture1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PictureBoxViewModel Picture2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboShiftList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboPositionList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboUnitList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PictureBoxViewModel Picture3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdRefresh { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdNewPromo { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdUpdate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAdjust { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}