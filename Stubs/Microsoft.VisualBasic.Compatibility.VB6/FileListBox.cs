using System;
using Stubs._System.Drawing;
using UpgradeHelpers.Helpers;

namespace Stubs._Microsoft.VisualBasic.Compatibility.VB6
{

	public class FileListBox
		: System.ComponentModel.Component
	{

		public bool Archive { get; set; }

		public bool CausesValidation { get; set; }

		public UpgradeHelpers.Helpers.Cursor Cursor { get; set; }

		public bool Enabled { get; set; }

		public bool Hidden { get; set; }

		public Stubs._System.Drawing.Point Location { get; set; }

		public string Name { get; set; }

		public bool Normal { get; set; }

		public string Pattern { get; set; }

		public bool ReadOnly { get; set; }

		public Stubs._System.Drawing.Size Size { get; set; }

		public bool System { get; set; }

		public int TabIndex { get; set; }

		public bool TabStop { get; set; }

		public bool Visible { get; set; }

		public string Path { get; set; }
        public UpgradeHelpers.BasicViewModels.SelectionMode SelectionMode { get; set; }
		public string FileName { get; set; }

        public Color ForeColor { get; set; }

        public Color BackColor { get; set; }

    }

}