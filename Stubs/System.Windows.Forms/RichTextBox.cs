using System;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;
using Stubs._System.Drawing;
using Stubs._System.Windows.Forms;

namespace Stubs._System.Windows.Forms
{

	public class RichTextBox : IDependentViewModel
    {

		public bool Enabled { get; set; }

		public UpgradeHelpers.Helpers.Font Font { get; set; }

		public Stubs._System.Drawing.Point Location { get; set; }

		public string Name { get; set; }

		public string Rtf { get; set; }

		public RichTextBoxScrollBars ScrollBars { get; set; }

		public Stubs._System.Drawing.Size Size { get; set; }

		public int TabIndex { get; set; }
		public virtual string Text { get; set; }
        public string Tag { get; set; }
        public Color BackColor { get; set; }
        public bool Focus()
		{
            //throw new NotImplementedException("This is an automatic generated code, please implement the requested logic.");
            return false;
		}

        public void Build(IIocContainer ctx)
        {
        }

        public bool Visible { get; set; }

        public string UniqueID
        {
            get;

            set;
        }
    }

}