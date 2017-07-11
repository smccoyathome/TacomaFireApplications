using System;
using System.Collections.Generic;
using System.Text;
using UpgradeHelpers.DB.ADO;

namespace UpgradeHelpers.DB
{
	/// <summary>
	/// It simulates a VB6 Field, contains the Value and FieldMetadata
	/// </summary>
	public class FieldsHelper
	{
		protected internal ADORecordSetHelper rs;

		/// <summary>
		/// Creates a FieldsHelper associated to a RecordsetHelper
		/// </summary>
		/// <param name="rs">The recordset for this Field.</param>
		public FieldsHelper(ADORecordSetHelper rs)
		{
			this.rs = rs;
		}

		

		/// <summary>
		/// Access a FieldHelper
		/// </summary>
		public ADOFieldHelper this[string colRef]
		{
			get
			{
				return new ADOFieldHelper(rs, colRef, false);
			}
		}
	}
}
