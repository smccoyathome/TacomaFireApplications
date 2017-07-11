using System;

namespace UpgradeHelpers.Helpers
{
	public class BindingsCollection : UpgradeHelpers.Interfaces.IDependentModel
    {
        public string UniqueID { get; set; }
        
        private DataSourceUpdateMode defaultDataSourceUpdateMode;

        public virtual int Count
        {
            get { return 0; }
        }

        public void Remove(Binding binding)
        {
           
        }

        public DataSourceUpdateMode DefaultDataSourceUpdateMode
        {
            get
            {
                return this.defaultDataSourceUpdateMode;
            }
            set
            {
                this.defaultDataSourceUpdateMode = value;
            }
        }

        public Binding this[int index]
        {
            get
            {
                return null;
            }
        }

        public void Add(Binding binding)
        {
            //this.Add(binding);
        }

        public Binding Add(string propertyName, object dataSource, string dataMember)
        {
            //return this.Add(propertyName, dataSource, dataMember, false, this.DefaultDataSourceUpdateMode, (object)null, string.Empty, (IFormatProvider)null);
            return null;
        }

        public Binding Add(string propertyName, object dataSource, string dataMember, bool formattingEnabled)
        {
            //return this.Add(propertyName, dataSource, dataMember, formattingEnabled, this.DefaultDataSourceUpdateMode, (object)null, string.Empty, (IFormatProvider)null);
            return null;
        }

        public Binding Add(string propertyName, object dataSource, string dataMember, bool formattingEnabled, DataSourceUpdateMode updateMode)
        {
            //return this.Add(propertyName, dataSource, dataMember, formattingEnabled, updateMode, (object)null, string.Empty, (IFormatProvider)null);
            return null;
        }

        public Binding Add(string propertyName, object dataSource, string dataMember, bool formattingEnabled, DataSourceUpdateMode updateMode, object nullValue)
        {
            //return this.Add(propertyName, dataSource, dataMember, formattingEnabled, updateMode, nullValue, string.Empty, (IFormatProvider)null);
            return null;
        }

        public Binding Add(string propertyName, object dataSource, string dataMember, bool formattingEnabled, DataSourceUpdateMode updateMode, object nullValue, string formatString)
        {
            //return this.Add(propertyName, dataSource, dataMember, formattingEnabled, updateMode, nullValue, formatString, (IFormatProvider)null);
            return null;
        }

        public Binding Add(string propertyName, object dataSource, string dataMember, bool formattingEnabled, DataSourceUpdateMode updateMode, object nullValue, string formatString, IFormatProvider formatInfo)
        {
            //if (dataSource == null)
            //    throw new ArgumentNullException("dataSource");
            //Binding binding = new Binding(propertyName, dataSource, dataMember, formattingEnabled, updateMode, nullValue, formatString, formatInfo);
            //this.Add(binding);
            //return binding;
            return null;
        }

        public void Clear() { 
        
        }
        
    }
}
