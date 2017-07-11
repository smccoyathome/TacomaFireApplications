using System;

namespace UpgradeHelpers.Helpers
{
	public class Binding: BindingBase
    {
        private string p1;
        private System.Data.DataTable dtItems;
        private string p2;
        private bool p3;

        public void ReadValue()
        {
            //this.PushData(true);
        }


        public string PropertyName { get; set; }

        public DataSourceUpdateMode DataSourceUpdateMode { get; set; }

        public Binding(string propertyName, object dataSource, string dataMember, bool formattingEnabled, DataSourceUpdateMode dataSourceUpdateMode, object nullValue, string formatString, IFormatProvider formatInfo)
        {

        }

        public Binding(string p1, System.Data.DataTable dtItems, string p2, bool p3)
        {
            // TODO: Complete member initialization
            this.p1 = p1;
            this.dtItems = dtItems;
            this.p2 = p2;
            this.p3 = p3;
        }

        public Binding(string path) { throw new NotImplementedException(); }


        public event UpgradeHelpers.Events.ConvertEventHandler Format;
    }
}
