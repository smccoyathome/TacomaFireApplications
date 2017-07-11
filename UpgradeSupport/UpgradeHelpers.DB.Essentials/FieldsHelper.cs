using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace UpgradeHelpers.DB
{
    /// <summary>
    /// It simulates a VB6 Field, contains the Value and FieldMetadata
    /// </summary>
    public class FieldsHelper : IEnumerable<FieldHelper>
    {
        protected internal RecordSetHelper rs;

        #region IEnumerator

        private IEnumerable<FieldHelper> Items
        {
            get
            {
                if (rs != null && rs.FieldsMetadata != null)
                    foreach (DataColumn c in rs.FieldsMetadata)
                        yield return new FieldHelper(rs, c.ColumnName);
            }
        }

        /// <summary>
        /// Implements IEnumerator
        /// </summary>
        public IEnumerator<FieldHelper> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        /// <summary>
        /// Implements IEnumerator
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        /// <summary>
        /// Creates a FieldsHelper associated to a RecordsetHelper
        /// </summary>
        /// <param name="rs">The recordset for this Field.</param>
        public FieldsHelper(RecordSetHelper rs)
        {
            this.rs = rs;
        }

        /// <summary>
        /// Add a column
        /// </summary>
        public void Append(string name, System.Data.DbType type, params object[] restParams)
        {
            rs.FieldsMetadata.Add(name, DBUtils.GetType(type));
        }

        /// <summary>
        /// Returns the count for the RecordsetHelper columns
        /// </summary>
        public int Count
        {
            get
            {
                return rs.FieldsMetadata.Count;
            }
        }

        /// <summary>
        /// Removes a column
        /// </summary>
        public void Delete(int index)
        {
            rs.FieldsMetadata.RemoveAt(index);
        }

        /// <summary>
        /// Access a FieldHelper
        /// </summary>
        public FieldHelper this[object colRef]
        {
            get
            {
                return new FieldHelper(rs, colRef);
            }
        }
    }
}
