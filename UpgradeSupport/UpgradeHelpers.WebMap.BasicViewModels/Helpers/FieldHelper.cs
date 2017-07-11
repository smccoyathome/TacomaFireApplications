

namespace UpgradeHelpers.Helpers
{
	public class FieldHelper
	{
		public FieldHelper(DataColumn col, object value, int size)
		{
			this.Value = value;
			this.FieldMetadata = col;
			this.Size = size;
		}
		public object Value { get; set; }

		/// <summary>
		/// Metadata for this Field
		/// </summary>
		public virtual DataColumn FieldMetadata
		{
			get;
			private set;
		}
		public int Size { get; set; }
	}
}
