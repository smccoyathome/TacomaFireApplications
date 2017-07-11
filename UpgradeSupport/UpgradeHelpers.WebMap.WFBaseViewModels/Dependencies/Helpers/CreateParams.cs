using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpgradeHelpers.Helpers
{
    public class CreateParams
    {
        private string className;
        private string caption;
        private int style;
        private int exStyle;
        private int classStyle;
        private int x;
        private int y;
        private int width;
        private int height;
        private IntPtr parent;
        private object param;

        public string ClassName
        {
            get
            {
                return this.className;
            }
            set
            {
                this.className = value;
            }
        }

        public string Caption
        {
            get
            {
                return this.caption;
            }
            set
            {
                this.caption = value;
            }
        }

        public int Style
        {
            get
            {
                return this.style;
            }
            set
            {
                this.style = value;
            }
        }

        public int ExStyle
        {
            get
            {
                return this.exStyle;
            }
            set
            {
                this.exStyle = value;
            }
        }

        public int ClassStyle
        {
            get
            {
                return this.classStyle;
            }
            set
            {
                this.classStyle = value;
            }
        }

        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }

        public int Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
            }
        }

        public IntPtr Parent
        {
            get
            {
                return this.parent;
            }
            set
            {
                this.parent = value;
            }
        }

        public object Param
        {
            get
            {
                return this.param;
            }
            set
            {
                this.param = value;
            }
        }

        public CreateParams()
        {
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder(64);
            stringBuilder.Append("CreateParams {'");
            stringBuilder.Append(this.className);
            stringBuilder.Append("', '");
            stringBuilder.Append(this.caption);
            stringBuilder.Append("', 0x");
            stringBuilder.Append(Convert.ToString(this.style, 16));
            stringBuilder.Append(", 0x");
            stringBuilder.Append(Convert.ToString(this.exStyle, 16));
            stringBuilder.Append(", {");
            stringBuilder.Append(this.x);
            stringBuilder.Append(", ");
            stringBuilder.Append(this.y);
            stringBuilder.Append(", ");
            stringBuilder.Append(this.width);
            stringBuilder.Append(", ");
            stringBuilder.Append(this.height);
            stringBuilder.Append("}");
            stringBuilder.Append("}");
            return stringBuilder.ToString();
        }
    }
}
