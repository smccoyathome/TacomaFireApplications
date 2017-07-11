using System;
using System.Reflection;
using Fasterflect;
using System.Collections;
using System.Data;
using System.IO;
using System.Collections.Specialized;
using System.Xml;
using System.Text.RegularExpressions;
using System.Globalization;
using SimmoTech.Utils.Serialization;
using UpgradeHelpers.Interfaces;

namespace SimmoTech.Utils.Data
{
    /// <summary>
    ///		Uses SimmoTech Binary serialization to generate a Byte Array from an entity
    /// and the other way around.
    /// </summary>
    public class BinaryFastSerializer
	{
		/// <summary>
		/// Serializes a DataSet to a byte[].
		/// </summary>
		/// <param name="dataSet">The DataSet to serialize.</param>
		/// <returns>A byte[] containing the serialized data.</returns>
		public static byte[] SerializeDataSet(ISurrogateContext context,DataSet dataSet, MemoryStream inputStream = null)
		{
			inputStream = inputStream ?? new MemoryStream();
			return new FastSerializer(context).Serialize(dataSet, inputStream);
		}

		/// <summary>
		/// Deserializes data and infrastructure into the supplied DataSet.
		/// </summary>
		/// <param name="dataSet">The DataSet to populate.</param>
		/// <param name="serializedData">A byte[] containing the serialized data.</param>
		/// <returns>The same DataSet passed in.</returns>
		public static DataSet DeserializeDataSet(ISurrogateContext context, Stream inputStream)
		{
			return new FastDeserializer().DeserializeDataSet(context,inputStream);
		}
		/// <summary>
		/// Serializes a DataTable in a Binary format.
		/// </summary>
		/// <param name="table">DataTable to be serialized.</param>
		/// <param name="inputStream">The Stream being used...Otherwise it's not mandatory.</param>
		/// <returns>Array of Bytes representation of the DataTable</returns>
		public static byte[] SerializeDataTable(ISurrogateContext context, DataTable table, MemoryStream inputStream = null)
		{
			inputStream = inputStream ?? new MemoryStream();
			return new FastSerializer(context).Serialize(table, inputStream);
		}
		/// <summary>
		/// Deserializes an Stream containing the Bytes of a DataTable .
		/// </summary>
		/// <param name="inputStream">Stream with the DataTable bytes.</param>
		/// <returns>DataTable result of deserializing the bytes.</returns>
		public static DataTable DeserializeDataTable(ISurrogateContext context,Stream inputStream)
		{
			return new FastDeserializer().DeserializeDataTable(context,inputStream);
		}

        public static T DeserializeDataTable<T>(ISurrogateContext context, Stream inputStream) where T: DataTable, new()
        {
            return new FastDeserializer().DeserializeDataTable<T>(context, inputStream);
        }

        /// <summary>
        /// Deserializes an Array of Bytes into a DataTable .
        /// </summary>
        /// <param name="bytesArray">Bytes representing the DataTable.</param>
        /// <returns>DataTable result of deserializing the bytes.</returns>
        public static DataTable DeserializeDataTable(ISurrogateContext context, byte[] bytesArray)
		{
			return new FastDeserializer().DeserializeDataTable(context, bytesArray);
		}


		#region Fast Serialization
		#region Flags
		#region DataSet
		private static readonly int DataSetHasName = BitVector32.CreateMask();
		private static readonly int DataSetIsCaseSensitive = BitVector32.CreateMask(DataSetHasName);
		private static readonly int DataSetHasTables = BitVector32.CreateMask(DataSetIsCaseSensitive);
		private static readonly int DataSetHasRelationships = BitVector32.CreateMask(DataSetHasTables);
		private static readonly int DataSetHasForeignKeyConstraints = BitVector32.CreateMask(DataSetHasRelationships);
		private static readonly int DataSetHasExtendedProperties = BitVector32.CreateMask(DataSetHasForeignKeyConstraints);
		private static readonly int DataSetAreConstraintsEnabled = BitVector32.CreateMask(DataSetHasExtendedProperties);
		private static readonly int DataSetHasNamespace = BitVector32.CreateMask(DataSetAreConstraintsEnabled);
		private static readonly int DataSetHasPrefix = BitVector32.CreateMask(DataSetHasNamespace);
		private static readonly int[] zeroIntegers = new int[0];

		private static BitVector32 GetDataSetFlags(DataSet dataSet)
		{
			BitVector32 flags = new BitVector32();

			flags[DataSetHasName] = dataSet.DataSetName != "NewDataSet";
			flags[DataSetIsCaseSensitive] = dataSet.CaseSensitive;
			flags[DataSetHasTables] = dataSet.Tables.Count != 0;
			flags[DataSetHasRelationships] = dataSet.Relations.Count != 0;
			flags[DataSetHasForeignKeyConstraints] = getForeignKeyConstraints(dataSet).Length != 0;
			flags[DataSetHasExtendedProperties] = dataSet.ExtendedProperties.Count != 0;
			flags[DataSetAreConstraintsEnabled] = dataSet.EnforceConstraints;
			flags[DataSetHasNamespace] = dataSet.Namespace != string.Empty;
			flags[DataSetHasPrefix] = dataSet.Prefix != string.Empty;

			return flags;
		}
		#endregion DataSet

		#region Table
		private static readonly int TableHasName = BitVector32.CreateMask();
		private static readonly int TableIsCaseSensitive = BitVector32.CreateMask(TableHasName);
		private static readonly int TableIsCaseSensitiveAmbient = BitVector32.CreateMask(TableIsCaseSensitive);
		private static readonly int TableHasSpecificCulture = BitVector32.CreateMask(TableIsCaseSensitiveAmbient);
		private static readonly int TableHasColumns = BitVector32.CreateMask(TableHasSpecificCulture);
		private static readonly int TableHasRows = BitVector32.CreateMask(TableHasColumns);
		private static readonly int TableHasMinimumCapacity = BitVector32.CreateMask(TableHasRows);
		private static readonly int TableHasDisplayExpression = BitVector32.CreateMask(TableHasMinimumCapacity);
		private static readonly int TableHasNoUniqueConstraints = BitVector32.CreateMask(TableHasDisplayExpression);
		private static readonly int TableHasExtendedProperties = BitVector32.CreateMask(TableHasNoUniqueConstraints);
		private static readonly int TableHasNamespace = BitVector32.CreateMask(TableHasExtendedProperties);
		private static readonly int TableHasPrefix = BitVector32.CreateMask(TableHasNamespace);
		private static readonly int TableHasRepeatableElement = BitVector32.CreateMask(TableHasPrefix);
		private static readonly int TableHasTypeName = BitVector32.CreateMask(TableHasRepeatableElement);

#if NET20
		private static readonly FieldInfo TableCultureFieldInfo =
			typeof(DataTable).GetField("_cultureUserSet", BindingFlags.Instance | BindingFlags.NonPublic);
		private static readonly FieldInfo TableCaseSensitiveAmbientFieldInfo =
			typeof(DataTable).GetField("_caseSensitiveUserSet", BindingFlags.Instance | BindingFlags.NonPublic);
#else
		private static readonly FieldInfo TableCultureFieldInfo =
			typeof(DataTable).GetField("_culture", BindingFlags.Instance | BindingFlags.NonPublic);
		private static readonly FieldInfo TableCaseSensitiveAmbientFieldInfo =
			typeof(DataTable).GetField("_caseSensitive", BindingFlags.Instance | BindingFlags.NonPublic);
#endif
		private static readonly FieldInfo TableTypeNameFieldInfo =
			typeof(DataTable).GetField("typeName", BindingFlags.Instance | BindingFlags.NonPublic);
		private static readonly FieldInfo TableRepeatableElementFieldInfo =
			typeof(DataTable).GetField("repeatableElement", BindingFlags.Instance | BindingFlags.NonPublic);

		private static BitVector32 GetTableFlags(DataTable dataTable)
		{
			BitVector32 flags = new BitVector32();

			flags[TableHasName] = dataTable.TableName != string.Empty;
			flags[TableIsCaseSensitive] = dataTable.CaseSensitive;
#if NET20
			flags[TableIsCaseSensitiveAmbient] = !(bool) TableCaseSensitiveAmbientFieldInfo.GetValue(dataTable);
			flags[TableHasTypeName] = (XmlQualifiedName) TableTypeNameFieldInfo.GetValue(dataTable) != null;
			flags[TableHasSpecificCulture] = (bool) TableCultureFieldInfo.GetValue(dataTable);
#else
			flags[TableIsCaseSensitiveAmbient] = (bool)TableCaseSensitiveAmbientFieldInfo.GetValue(dataTable);
			flags[TableHasTypeName] = (XmlQualifiedName)TableTypeNameFieldInfo.GetValue(dataTable) != XmlQualifiedName.Empty;
			flags[TableHasSpecificCulture] = TableCultureFieldInfo.GetValue(dataTable) != null;
#endif
			flags[TableHasColumns] = dataTable.Columns.Count != 0;
			flags[TableHasRows] = dataTable.Rows.Count != 0;
			flags[TableHasMinimumCapacity] = dataTable.MinimumCapacity != 50;
			flags[TableHasDisplayExpression] = dataTable.DisplayExpression != string.Empty;
			flags[TableHasNoUniqueConstraints] = getUniqueConstraints(dataTable).Length == 0;
			flags[TableHasExtendedProperties] = dataTable.ExtendedProperties.Count != 0;

			flags[TableHasNamespace] = dataTable.Namespace != string.Empty;
			flags[TableHasPrefix] = dataTable.Prefix != string.Empty;
			flags[TableHasRepeatableElement] = (bool)TableRepeatableElementFieldInfo.GetValue(dataTable);

			return flags;
		}
		#endregion Table

		#region Column
		private static readonly int ColumnIsNullable = BitVector32.CreateMask();
		private static readonly int ColumnIsNotStringDataType = BitVector32.CreateMask(ColumnIsNullable);
		private static readonly int ColumnHasCaption = BitVector32.CreateMask(ColumnIsNotStringDataType);
		private static readonly int ColumnHasMaxLength = BitVector32.CreateMask(ColumnHasCaption);
		private static readonly int ColumnHasAutoIncrement = BitVector32.CreateMask(ColumnHasMaxLength);
		private static readonly int ColumnHasAutoIncrementUnusedDefaults = BitVector32.CreateMask(ColumnHasAutoIncrement);
		private static readonly int ColumnHasAutoIncrementNegativeStep = BitVector32.CreateMask(ColumnHasAutoIncrementUnusedDefaults);

		private static readonly int ColumnHasDefaultValue = BitVector32.CreateMask(ColumnHasAutoIncrementNegativeStep);
		private static readonly int ColumnHasExpression = BitVector32.CreateMask(ColumnHasDefaultValue);
		private static readonly int ColumnIsReadOnly = BitVector32.CreateMask(ColumnHasExpression);
		private static readonly int ColumnIsMaxLengthMaxValue = BitVector32.CreateMask(ColumnIsReadOnly);
		private static readonly int ColumnHasExtendedProperties = BitVector32.CreateMask(ColumnIsMaxLengthMaxValue);

		private static readonly int ColumnHasPrefix = BitVector32.CreateMask(ColumnHasExtendedProperties);
		private static readonly int ColumnIsNotElementMappingType = BitVector32.CreateMask(ColumnHasPrefix);
		private static readonly int ColumnHasColumnUri = BitVector32.CreateMask(ColumnIsNotElementMappingType);

		private static readonly FieldInfo ColumnUriFieldInfo =
			typeof(DataColumn).GetField("_columnUri", BindingFlags.Instance | BindingFlags.NonPublic);
		private static readonly FieldInfo AutoIncrementCurrentFieldInfo =
			typeof(DataColumn).GetField("autoInc", BindingFlags.Instance | BindingFlags.NonPublic);

		private static BitVector32 GetColumnFlags(DataColumn dataColumn)
		{
			BitVector32 flags = new BitVector32();

			flags[ColumnIsNullable] = dataColumn.AllowDBNull;
			flags[ColumnIsNotStringDataType] = dataColumn.DataType != typeof(string);
			flags[ColumnHasCaption] = dataColumn.Caption != dataColumn.ColumnName;
			flags[ColumnHasMaxLength] = dataColumn.MaxLength != -1;
			flags[ColumnIsMaxLengthMaxValue] = dataColumn.MaxLength == int.MaxValue;
			flags[ColumnHasAutoIncrement] = dataColumn.AutoIncrement;
			//TOFO	long current = (long) AutoIncrementCurrentFieldInfo.GetValue(dataColumn);
			long step = dataColumn.AutoIncrementStep;
			//TODO flags[ColumnHasAutoIncrementUnusedDefaults] = (current == 0 && step == 1) || (current == -1 && step == -1);
			flags[ColumnHasAutoIncrementNegativeStep] = dataColumn.AutoIncrementStep < 0;
			flags[ColumnHasDefaultValue] = dataColumn.DefaultValue != DBNull.Value;
			flags[ColumnHasExpression] = dataColumn.Expression != string.Empty;
			flags[ColumnIsReadOnly] = dataColumn.ReadOnly;
			flags[ColumnHasExtendedProperties] = dataColumn.ExtendedProperties.Count != 0;

			flags[ColumnHasPrefix] = dataColumn.Prefix != string.Empty;
			flags[ColumnIsNotElementMappingType] = dataColumn.ColumnMapping != MappingType.Element;
			flags[ColumnHasColumnUri] = ColumnUriFieldInfo.GetValue(dataColumn) != null;

			return flags;
		}
		#endregion Column

		#region Row
		private static readonly int RowHasOldData = BitVector32.CreateMask();
		private static readonly int RowHasNewData = BitVector32.CreateMask(RowHasOldData);
		private static readonly int RowHasRowError = BitVector32.CreateMask(RowHasNewData);
		private static readonly int RowHasColumnErrors = BitVector32.CreateMask(RowHasRowError);

		private static BitVector32 GetRowFlags(DataRow row)
		{
			BitVector32 flags = new BitVector32();

			DataRowState state = row.RowState;
			flags[RowHasOldData] = state == DataRowState.Deleted || state == DataRowState.Modified;
			flags[RowHasNewData] = state == DataRowState.Added || state == DataRowState.Modified;
			flags[RowHasRowError] = row.RowError.Length != 0;
			flags[RowHasColumnErrors] = row.GetColumnsInError().Length != 0;

			return flags;
		}
		#endregion Row

		#region Constraints
		#region Common
		private static readonly FieldInfo ConstraintSchemaNameFieldInfo =
			typeof(Constraint).GetField("_schemaName", BindingFlags.Instance | BindingFlags.NonPublic);
		private static readonly Regex DefaultConstraintNameMatcher = new Regex(@"^Constraint(\d+)$");
		#endregion Common

		#region Unique
		private static readonly int UniqueConstraintHasDefaultName = BitVector32.CreateMask();
		private static readonly int UniqueConstraintHasSchemaName = BitVector32.CreateMask(UniqueConstraintHasDefaultName);
		private static readonly int UniqueConstraintHasMultipleColumns = BitVector32.CreateMask(UniqueConstraintHasSchemaName);
		private static readonly int UniqueConstraintHasExtendedProperties = BitVector32.CreateMask(UniqueConstraintHasMultipleColumns);
		private static readonly int UniqueConstraintIsPrimaryKey = BitVector32.CreateMask(UniqueConstraintHasExtendedProperties);

		private static BitVector32 GetUniqueConstraintFlags(UniqueConstraint uniqueConstraint)
		{
			BitVector32 flags = new BitVector32();

			flags[UniqueConstraintHasDefaultName] = DefaultConstraintNameMatcher.IsMatch(uniqueConstraint.ConstraintName);

			flags[UniqueConstraintHasSchemaName] = (string)ConstraintSchemaNameFieldInfo.GetValue(uniqueConstraint) != string.Empty;
			flags[UniqueConstraintHasMultipleColumns] = uniqueConstraint.Columns.Length > 1;
			flags[UniqueConstraintHasExtendedProperties] = uniqueConstraint.ExtendedProperties.Count != 0;
			flags[UniqueConstraintIsPrimaryKey] = uniqueConstraint.IsPrimaryKey;

			return flags;
		}

		private static UniqueConstraint[] getUniqueConstraints(DataTable dataTable)
		{
			if (dataTable.Constraints.Count == 0) return new UniqueConstraint[0];
			ArrayList constraints = new ArrayList();
			foreach (Constraint constraint in dataTable.Constraints)
			{
				if (constraint is UniqueConstraint) constraints.Add(constraint);
			}

			return (UniqueConstraint[])constraints.ToArray(typeof(UniqueConstraint));
		}
		#endregion Unique

		#region Foreign Key
		private static readonly int ForeignKeyConstraintHasDefaultName = BitVector32.CreateMask();
		private static readonly int ForeignKeyConstraintIsPrimaryKeyOnParentTable =
			BitVector32.CreateMask(ForeignKeyConstraintHasDefaultName);
		private static readonly int ForeignKeyConstraintHasMultipleColumns =
			BitVector32.CreateMask(ForeignKeyConstraintIsPrimaryKeyOnParentTable);
		private static readonly int ForeignKeyConstraintHasAcceptRejectRule = BitVector32.CreateMask(ForeignKeyConstraintHasMultipleColumns);
		private static readonly int ForeignKeyConstraintHasNonCascadeDeleteRule =
			BitVector32.CreateMask(ForeignKeyConstraintHasAcceptRejectRule);
		private static readonly int ForeignKeyConstraintHasNonCascadeUpdateRule =
			BitVector32.CreateMask(ForeignKeyConstraintHasNonCascadeDeleteRule);
		private static readonly int ForeignKeyConstraintHasExtendedProperties =
			BitVector32.CreateMask(ForeignKeyConstraintHasNonCascadeUpdateRule);
		private static readonly int ForeignKeyConstraintHasSchemaName = BitVector32.CreateMask(ForeignKeyConstraintHasExtendedProperties);

		private static BitVector32 GetForeignKeyConstraintFlags(ForeignKeyConstraint foreignKeyConstraint)
		{
			BitVector32 flags = new BitVector32();

			flags[ForeignKeyConstraintHasDefaultName] = DefaultConstraintNameMatcher.IsMatch(foreignKeyConstraint.ConstraintName);
			flags[ForeignKeyConstraintIsPrimaryKeyOnParentTable] =
				ColumnOrdinalsMatch(foreignKeyConstraint.RelatedColumns, foreignKeyConstraint.RelatedTable.PrimaryKey);
			flags[ForeignKeyConstraintHasMultipleColumns] = foreignKeyConstraint.Columns.Length > 1;
			flags[ForeignKeyConstraintHasAcceptRejectRule] = foreignKeyConstraint.AcceptRejectRule != AcceptRejectRule.None;
			flags[ForeignKeyConstraintHasNonCascadeUpdateRule] = foreignKeyConstraint.UpdateRule != Rule.Cascade;
			flags[ForeignKeyConstraintHasNonCascadeDeleteRule] = foreignKeyConstraint.DeleteRule != Rule.Cascade;
			flags[ForeignKeyConstraintHasExtendedProperties] = foreignKeyConstraint.ExtendedProperties.Count != 0;
			flags[ForeignKeyConstraintHasSchemaName] = (string)ConstraintSchemaNameFieldInfo.GetValue(foreignKeyConstraint) != string.Empty;

			return flags;
		}

		private static ForeignKeyConstraint[] getForeignKeyConstraints(DataSet dataSet)
		{
			ArrayList constraints = new ArrayList();
			foreach (DataTable dataTable in dataSet.Tables)
			{
				foreach (Constraint constraint in dataTable.Constraints)
				{
					if (constraint is ForeignKeyConstraint) constraints.Add(constraint);
				}
			}
			return (ForeignKeyConstraint[])constraints.ToArray(typeof(ForeignKeyConstraint));
		}

		private static bool ColumnOrdinalsMatch(DataColumn[] columns1, DataColumn[] columns2)
		{
			if (columns1 != columns2)
			{
				if (columns1 == null || columns2 == null) return false;
				if (columns1.Length != columns2.Length) return false;

				for (int i = 0; i < columns1.Length; i++)
				{
					int matchingColumn = 0;
					while (matchingColumn < columns2.Length)
					{
						if (columns1[i].Equals(columns2[matchingColumn])) break;
						matchingColumn++;
					}
					if (matchingColumn == columns2.Length)
					{
						return false;
					}
				}
			}

			return true;
		}
		#endregion Foreign Key
		#endregion Constraints

		#region Relation
		private static readonly int RelationHasDefaultName = BitVector32.CreateMask();
		private static readonly int RelationIsNested = BitVector32.CreateMask(RelationHasDefaultName);
		private static readonly int RelationHasMultipleColumns = BitVector32.CreateMask(RelationIsNested);
		private static readonly int RelationIsPrimaryKeyOnParentTable = BitVector32.CreateMask(RelationHasMultipleColumns);
		private static readonly int RelationHasExtendedProperties = BitVector32.CreateMask(RelationIsPrimaryKeyOnParentTable);

		private static BitVector32 GetRelationFlags(DataRelation relation)
		{
			BitVector32 flags = new BitVector32();

			flags[RelationHasDefaultName] = relation.RelationName != string.Empty;
			flags[RelationIsNested] = relation.Nested;
			flags[RelationHasMultipleColumns] = relation.ParentColumns.Length > 1;
			flags[RelationIsPrimaryKeyOnParentTable] = relation.ParentKeyConstraint != null && relation.ParentKeyConstraint.IsPrimaryKey;
			flags[RelationHasExtendedProperties] = relation.ExtendedProperties.Count != 0;

			return flags;
		}
		#endregion Relation
		#endregion Flags

		#region Serializer
		private class FastSerializer
		{

			#region Fields
			private DataSet dataSet;
			private SerializationWriter writer;
			#endregion Fields

			#region Methods

			public byte[] Serialize(DataTable dataTable)
			{
				writer = new SerializationWriter(this.context);

				serializeTable(dataTable);

				return getSerializedBytes();
			}

			public byte[] Serialize(DataTable dataTable, MemoryStream stream)
			{
				writer = new SerializationWriter(this.context,stream);

				serializeTable(dataTable);

				return getSerializedBytes();
			}
			public byte[] Serialize(DataSet dataSet, MemoryStream stream)
			{
				this.dataSet = dataSet;
				writer = new SerializationWriter(this.context,stream);

				BitVector32 flags = GetDataSetFlags(dataSet);
				writer.WriteOptimized(flags);

				if (flags[DataSetHasName]) writer.WriteOptimized(dataSet.DataSetName);
				writer.WriteOptimized(dataSet.Locale.LCID);
				if (flags[DataSetHasNamespace]) writer.WriteOptimized(dataSet.Namespace);
				if (flags[DataSetHasPrefix]) writer.WriteOptimized(dataSet.Prefix);
				if (flags[DataSetHasTables]) serializeTables();
				if (flags[DataSetHasForeignKeyConstraints]) serializeForeignKeyConstraints(getForeignKeyConstraints(dataSet));
				if (flags[DataSetHasRelationships]) serializeRelationships();
				if (flags[DataSetHasExtendedProperties]) serializeExtendedProperties(dataSet.ExtendedProperties);

				return getSerializedBytes();
			}
			private void serializeRelationships()
			{
				DataRelationCollection relations = dataSet.Relations;
				writer.WriteOptimized(relations.Count);

				foreach (DataRelation relation in relations)
				{
					BitVector32 flags = GetRelationFlags(relation);
					writer.WriteOptimized(flags);

					if (flags[RelationHasDefaultName]) writer.WriteOptimized(relation.RelationName);

					// Write Parent Table column info
					writer.WriteOptimized(dataSet.Tables.IndexOf(relation.ParentTable));
					if (!flags[RelationIsPrimaryKeyOnParentTable]) writeColumnOrdinals(relation.ParentColumns);

					// Write Child Table column info
					writeTableAndColumnOrdinals(relation.ChildColumns);

					if (flags[RelationHasExtendedProperties]) serializeExtendedProperties(relation.ExtendedProperties);
				}
			}
			private void serializeForeignKeyConstraints(ForeignKeyConstraint[] foreignKeyConstraints)
			{
				writer.WriteOptimized(foreignKeyConstraints.Length);
				foreach (ForeignKeyConstraint foreignKeyConstraint in foreignKeyConstraints)
				{
					BitVector32 flags = GetForeignKeyConstraintFlags(foreignKeyConstraint);
					writer.WriteOptimized(flags);

					if (!flags[ForeignKeyConstraintHasDefaultName])
						writer.WriteOptimized(foreignKeyConstraint.ConstraintName);
					else
					{
						writer.WriteOptimized(int.Parse(DefaultConstraintNameMatcher.Match(foreignKeyConstraint.ConstraintName).Groups[1].Value));
					}

					// Save Child Table column info
					writeTableAndColumnOrdinals(foreignKeyConstraint.Columns);

					// Save Related (parent) Table column info
					writer.WriteOptimized(dataSet.Tables.IndexOf(foreignKeyConstraint.RelatedTable));
					if (!flags[ForeignKeyConstraintIsPrimaryKeyOnParentTable]) writeColumnOrdinals(foreignKeyConstraint.RelatedColumns);

					if (flags[ForeignKeyConstraintHasAcceptRejectRule]) writer.WriteOptimized((int)foreignKeyConstraint.AcceptRejectRule);
					if (flags[ForeignKeyConstraintHasNonCascadeDeleteRule]) writer.WriteOptimized((int)foreignKeyConstraint.DeleteRule);
					if (flags[ForeignKeyConstraintHasNonCascadeUpdateRule]) writer.WriteOptimized((int)foreignKeyConstraint.UpdateRule);

					if (flags[ForeignKeyConstraintHasSchemaName]) writer.WriteOptimized((string)ConstraintSchemaNameFieldInfo.GetValue(foreignKeyConstraint));
					if (flags[ForeignKeyConstraintHasExtendedProperties]) serializeExtendedProperties(foreignKeyConstraint.ExtendedProperties);

				}
			}
			private void writeTableAndColumnOrdinals(DataColumn[] columns)
			{
				writer.WriteOptimized(dataSet.Tables.IndexOf(columns[0].Table));
				writeColumnOrdinals(columns);
			}
			private void serializeTables()
			{
				DataTableCollection tables = dataSet.Tables;
				writer.WriteOptimized(tables.Count);

				foreach (DataTable dataTable in tables)
				{
					serializeTable(dataTable);
				}
			}

			#endregion Methods

			#region Private Methods
			private byte[] getSerializedBytes()
			{
				byte[] result = writer.ToArray();
				writer = null;
				dataSet = null;
				return result;
			}
			
			private MemberGetter _rowIDFieldGetter = null;
			private void serializeRowAditionalData(SerializationWriter wroter, DataRow row)
			{
				if (_rowIDFieldGetter == null)
					_rowIDFieldGetter = row.GetType().DelegateForGetFieldValue("_rowID", Flags.Instance | Flags.InstancePrivate);

				long _rowID = Convert.ToInt64(_rowIDFieldGetter(row));
				writer.WriteOptimized(_rowID);
			}
			private void serializeRows(DataTable dataTable)
			{
				int rowCount = dataTable.Rows.Count;
				writer.WriteOptimized(rowCount);

				if (rowCount != 0)
				{
					int[] calculatedColumnOrdinals = getCalculatedColumnOrdinals(dataTable);
					DataRow row = null;

					for (int i = 0; i < rowCount; i++)
					{
						row = dataTable.Rows[i];
						BitVector32 flags = GetRowFlags(row);
						writer.WriteOptimized(flags);

						if (!flags[RowHasOldData])
							writer.WriteOptimized(getNonCalculatedValuesFromRowVersion(row, DataRowVersion.Current, calculatedColumnOrdinals));
						else if (!flags[RowHasNewData])
							writer.WriteOptimized(getNonCalculatedValuesFromRowVersion(row, DataRowVersion.Original, calculatedColumnOrdinals));
						else
						{
							writer.WriteOptimized(
								getNonCalculatedValuesFromRowVersion(row, DataRowVersion.Current, calculatedColumnOrdinals),
								getNonCalculatedValuesFromRowVersion(row, DataRowVersion.Original, calculatedColumnOrdinals));
						}

						if (flags[RowHasRowError]) writer.WriteOptimized(row.RowError);
						if (flags[RowHasColumnErrors])
						{
							DataColumn[] columnsInError = row.GetColumnsInError();
							writer.WriteOptimized(columnsInError.Length);
							for (int j = 0; j < columnsInError.Length; j++)
							{
								writer.WriteOptimized(columnsInError[j].Ordinal);
								writer.WriteOptimized(row.GetColumnError(columnsInError[j]));
							}
						}

						serializeRowAditionalData(writer, row);

					}
				}
			}

			private int[] getCalculatedColumnOrdinals(DataTable dataTable)
			{
				ArrayList result = null;
				foreach (DataColumn column in dataTable.Columns)
				{
					if (column.Expression.Length != 0)
					{
						if (result == null) result = new ArrayList();
						result.Add(column.Ordinal);
					}
				}

				return (int[])(result == null ? zeroIntegers : result.ToArray(typeof(int)));
			}

			/// <summary>
			/// Returns an object[] of all the row values for the specified version
			/// </summary>
			/// <param name="row">The row from which to extract values</param>
			/// <param name="version"></param>
			/// <returns>An object[] holding the values.</returns>
			public static object[] GetValuesFromRowVersion(DataRow row, DataRowVersion version)
			{
				int columnCount = row.Table.Columns.Count;
				object[] result = new object[columnCount];
				for (int j = 0; j < columnCount; j++)
				{
					result[j] = row[j, version];
				}
				return result;
			}

			private object[] getNonCalculatedValuesFromRowVersion(DataRow row, DataRowVersion version, int[] calculatedColumnOrdinals)
			{
				object[] result = GetValuesFromRowVersion(row, version);
				if (calculatedColumnOrdinals.Length != 0)
				{
					foreach (int calculatedColumnOrdinal in calculatedColumnOrdinals)
					{
						result[calculatedColumnOrdinal] = null;
					}
				}
				return result;
			}

			MemberGetter _nextRowIDGetter = null;
			MemberGetter _objectIDGetter = null;
			private void serializeTableAditionalData(SerializationWriter writer, DataTable dataTable)
			{
				if (_nextRowIDGetter == null)
					_nextRowIDGetter = dataTable.GetType().DelegateForGetFieldValue("nextRowID");

				long nextRowID = Convert.ToInt64(_nextRowIDGetter(dataTable));
				writer.WriteOptimized(nextRowID);

				if (_objectIDGetter == null)
					_objectIDGetter = dataTable.GetType().DelegateForGetFieldValue("_objectID");

				long objectID = Convert.ToInt32(_objectIDGetter(dataTable));
				writer.WriteOptimized(objectID);
			}

			private void serializeTable(DataTable dataTable)
			{
				#region Flags
				BitVector32 flags = GetTableFlags(dataTable);
				writer.WriteOptimized(flags);

				if (flags[TableHasName]) writer.WriteOptimized(dataTable.TableName);
				if (flags[TableHasNamespace]) writer.WriteOptimized(dataTable.Namespace);
				if (flags[TableHasPrefix]) writer.WriteOptimized(dataTable.Prefix);
				if (flags[TableHasSpecificCulture]) writer.WriteOptimized(dataTable.Locale.LCID);
				if (flags[TableHasTypeName])
				{
					XmlQualifiedName xmlQualifiedName = (XmlQualifiedName)TableTypeNameFieldInfo.GetValue(dataTable);
					if (xmlQualifiedName == null)
					{
						writer.WriteOptimized(String.Empty);
						writer.WriteOptimized(string.Empty);
					}
					else
					{
						writer.WriteOptimized(xmlQualifiedName.Name);
						writer.WriteOptimized(xmlQualifiedName.Namespace);
					}
				}
				if (flags[TableHasMinimumCapacity]) writer.WriteOptimized(dataTable.MinimumCapacity);
				#endregion Flags

				#region Columns
				if (flags[TableHasColumns])
				{
					serializeColumns(dataTable);
					if (flags[TableHasDisplayExpression]) writer.WriteOptimized(dataTable.DisplayExpression);
				}
				#endregion Columns

				#region Extended Properties
				if (flags[TableHasExtendedProperties]) serializeExtendedProperties(dataTable.ExtendedProperties);
				#endregion Extended Properties

				#region Data Rows
				if (flags[TableHasRows]) serializeRows(dataTable);
				#endregion Data Rows

				#region UniqueConstraints
				if (!flags[TableHasNoUniqueConstraints]) serializeUniqueConstraints(getUniqueConstraints(dataTable));
				#endregion UniqueConstraints

				serializeTableAditionalData(writer, dataTable);

			}

			private void serializeUniqueConstraints(UniqueConstraint[] uniqueConstraints)
			{
				writer.WriteOptimized(uniqueConstraints.Length);
				foreach (UniqueConstraint uniqueConstraint in uniqueConstraints)
				{
					BitVector32 flags = GetUniqueConstraintFlags(uniqueConstraint);
					writer.WriteOptimized(flags);

					if (!flags[UniqueConstraintHasDefaultName])
						writer.WriteOptimized(uniqueConstraint.ConstraintName);
					else
					{
						writer.WriteOptimized(int.Parse(DefaultConstraintNameMatcher.Match(uniqueConstraint.ConstraintName).Groups[1].Value));
					}
					writeColumnOrdinals(uniqueConstraint.Columns);

					if (flags[UniqueConstraintHasSchemaName]) writer.WriteOptimized((string)ConstraintSchemaNameFieldInfo.GetValue(uniqueConstraint));
					if (flags[UniqueConstraintHasExtendedProperties]) serializeExtendedProperties(uniqueConstraint.ExtendedProperties);

				}
			}

			private void serializeExtendedProperties(PropertyCollection properties)
			{
				object[] keys = new object[properties.Count];
				properties.Keys.CopyTo(keys, 0);
				writer.WriteOptimized(keys);

				object[] values = new object[properties.Count];
				properties.Values.CopyTo(values, 0);
				writer.WriteOptimized(values);

			}

			private void writeColumnOrdinals(DataColumn[] columns)
			{
				if (columns.Length == 1)
					writer.WriteOptimized(columns[0].Ordinal);
				else
				{
					int count = columns.Length;
					writer.WriteOptimized(count);
					foreach (DataColumn column in columns)
					{
						writer.WriteOptimized(column.Ordinal);
					}
				}
			}

			private void serializeColumns(DataTable dataTable)
			{
				DataColumnCollection columns = dataTable.Columns;
				writer.WriteOptimized(columns.Count);

				foreach (DataColumn column in columns)
				{
					BitVector32 flags = GetColumnFlags(column);
					writer.WriteOptimized(flags);

					writer.WriteOptimized(column.ColumnName);
					if (flags[ColumnIsNotStringDataType]) writer.WriteOptimized(column.DataType);
					if (flags[ColumnHasExpression]) writer.WriteOptimized(column.Expression);
					if (flags[ColumnIsNotElementMappingType]) writer.WriteOptimized((int)column.ColumnMapping);

					if (!flags[ColumnHasAutoIncrementUnusedDefaults])
					{
						writer.WriteOptimized(Math.Abs(column.AutoIncrementSeed));
						writer.WriteOptimized(Math.Abs(column.AutoIncrementStep));
					}
					if (flags[ColumnHasCaption]) writer.WriteOptimized(column.Caption);
					if (flags[ColumnHasColumnUri]) writer.WriteOptimized((string)ColumnUriFieldInfo.GetValue(column));
					if (flags[ColumnHasPrefix]) writer.WriteOptimized(column.Prefix);
					if (flags[ColumnHasDefaultValue]) writer.WriteObject(column.DefaultValue);
					if (flags[ColumnHasMaxLength] && !flags[ColumnIsMaxLengthMaxValue]) writer.WriteOptimized(column.MaxLength);
					if (flags[ColumnHasExtendedProperties]) serializeExtendedProperties(column.ExtendedProperties);

				}

			}
            #endregion Private Methods

            private readonly ISurrogateContext context;

            public FastSerializer(ISurrogateContext context)
            {
                this.context = context;
            }
		}

		#endregion Serializer

		#region Deserializer
		private class FastDeserializer
		{
			#region Fields
			private DataSet dataSet;
			private SerializationReader reader;
			#endregion Fields

			#region Methods
	  
			public DataTable DeserializeDataTable(ISurrogateContext context, byte[] serializedData)
			{
				DataTable dataTable = new DataTable();
				reader = new SerializationReader(context,serializedData);
				deserializeTable(dataTable);

				throwIfRemainingBytes();
				return dataTable;
			}

            public T DeserializeDataTable<T>(ISurrogateContext context, Stream stream) where T:DataTable, new()
            {
                var dataTable = new T();
                reader = new SerializationReader(context, stream);
                deserializeTable(dataTable);

                throwIfRemainingBytes();
                return dataTable;
            }


			public DataTable DeserializeDataTable(ISurrogateContext context,Stream stream)
			{
				DataTable dataTable = new DataTable();
				reader = new SerializationReader(context, stream);
				deserializeTable(dataTable);

				throwIfRemainingBytes();
				return dataTable;
			}

			public DataSet DeserializeDataSet(ISurrogateContext context, Stream stream)
			{
				this.dataSet = new DataSet();
				reader = new SerializationReader(context, stream);

				dataSet.EnforceConstraints = false;

				BitVector32 flags = reader.ReadOptimizedBitVector32();

				if (flags[DataSetHasName]) dataSet.DataSetName = reader.ReadOptimizedString();

				dataSet.Locale = new CultureInfo(reader.ReadOptimizedInt32());
				dataSet.CaseSensitive = flags[DataSetIsCaseSensitive];

				if (flags[DataSetHasNamespace]) dataSet.Namespace = reader.ReadOptimizedString();

				if (flags[DataSetHasPrefix]) dataSet.Prefix = reader.ReadOptimizedString();


				if (flags[DataSetHasTables]) deserializeTables();
				if (flags[DataSetHasForeignKeyConstraints]) deserializeForeignKeyConstraints();

				if (flags[DataSetHasRelationships]) deserializeRelationships();
				if (flags[DataSetHasExtendedProperties]) deserializeExtendedProperties(dataSet.ExtendedProperties);

				dataSet.EnforceConstraints = flags[DataSetAreConstraintsEnabled];

				throwIfRemainingBytes();
				return dataSet;
			}
			private void deserializeRelationships()
			{
				int count = reader.ReadOptimizedInt32();
				for (int i = 0; i < count; i++)
				{
					BitVector32 flags = reader.ReadOptimizedBitVector32();
					DataColumn[] parentColumns;
					DataColumn[] childColumns;

					string relationName = flags[RelationHasDefaultName] ? reader.ReadOptimizedString() : string.Empty;
					DataTable parentTable = dataSet.Tables[reader.ReadOptimizedInt32()];

					if (flags[RelationIsPrimaryKeyOnParentTable])
						parentColumns = parentTable.PrimaryKey;
					else
					{
						parentColumns = readColumnOrdinals(parentTable, flags[RelationHasMultipleColumns]);
					}

					childColumns = readTableAndColumnOrdinals(flags[RelationHasMultipleColumns]);

					DataRelation relation = new DataRelation(relationName, parentColumns, childColumns, false);
					relation.Nested = flags[RelationIsNested];
					if (flags[RelationHasExtendedProperties]) deserializeExtendedProperties(relation.ExtendedProperties);

					if (!dataSet.Relations.Contains(relation.RelationName)) dataSet.Relations.Add(relation);
				}

			}
			private void deserializeForeignKeyConstraints()
			{
				int count = reader.ReadOptimizedInt32();
				for (int i = 0; i < count; i++)
				{
					ForeignKeyConstraint foreignKeyConstraint;
					BitVector32 flags;
					string constraintName = string.Empty;
					DataColumn[] childColumns;
					DataColumn[] parentColumns;

					flags = reader.ReadOptimizedBitVector32();
					if (!flags[ForeignKeyConstraintHasDefaultName])
						constraintName = reader.ReadOptimizedString();
					else
					{
						constraintName = "Constraint" + reader.ReadOptimizedInt32();
					}
					childColumns = readTableAndColumnOrdinals(flags[ForeignKeyConstraintHasMultipleColumns]);

					DataTable relatedTable = dataSet.Tables[reader.ReadOptimizedInt32()];
					if (flags[ForeignKeyConstraintIsPrimaryKeyOnParentTable])
						parentColumns = relatedTable.PrimaryKey;
					else
					{
						parentColumns = readColumnOrdinals(relatedTable, flags[ForeignKeyConstraintHasMultipleColumns]);
					}

					AcceptRejectRule acceptRejectRule = flags[ForeignKeyConstraintHasAcceptRejectRule]
															? (AcceptRejectRule)reader.ReadOptimizedInt32()
															: AcceptRejectRule.None;
					Rule deleteRule = flags[ForeignKeyConstraintHasNonCascadeDeleteRule] ? (Rule)reader.ReadOptimizedInt32() : Rule.Cascade;
					Rule updateRule = flags[ForeignKeyConstraintHasNonCascadeUpdateRule] ? (Rule)reader.ReadOptimizedInt32() : Rule.Cascade;

					foreignKeyConstraint = new ForeignKeyConstraint(constraintName, parentColumns, childColumns);
					foreignKeyConstraint.AcceptRejectRule = acceptRejectRule;
					foreignKeyConstraint.DeleteRule = deleteRule;
					foreignKeyConstraint.UpdateRule = updateRule;

					if (flags[ForeignKeyConstraintHasSchemaName]) ConstraintSchemaNameFieldInfo.SetValue(foreignKeyConstraint, reader.ReadOptimizedString());
					if (flags[ForeignKeyConstraintHasExtendedProperties]) deserializeExtendedProperties(foreignKeyConstraint.ExtendedProperties);

					if (!foreignKeyConstraint.Table.Constraints.Contains(foreignKeyConstraint.ConstraintName))
						foreignKeyConstraint.Table.Constraints.Add(foreignKeyConstraint);
				}
			}
			private DataColumn[] readTableAndColumnOrdinals(bool multipleColumns)
			{
				DataTable dataTable = dataSet.Tables[reader.ReadOptimizedInt32()];
				return readColumnOrdinals(dataTable, multipleColumns);
			}
			private void deserializeTables()
			{
				int precreatedTableCount = dataSet.Tables.Count;
				int count = reader.ReadOptimizedInt32();

				for (int i = 0; i < count; i++)
				{
					DataTable dataTable;
					if (i >= precreatedTableCount)
						dataTable = new DataTable();
					else
					{
						dataTable = dataSet.Tables[i];
					}

					deserializeTable(dataTable);

					if (!dataSet.Tables.Contains(dataTable.TableName)) dataSet.Tables.Add(dataTable);
				}

			}
			#endregion Methods

			#region Private Methods
			private void throwIfRemainingBytes()
			{
				if (reader.BytesRemaining != 0)
				{
					throw new InvalidOperationException(string.Format("FastDeserializer did not deserialize {0:n} bytes", reader.BytesRemaining));
				}
			}

			private MemberSetter _rowIDFieldSetter = null;
			private void derializeRowAditionalData(SerializationReader reader, DataRow row)
			{
				if (_rowIDFieldSetter == null)
					_rowIDFieldSetter = row.GetType().DelegateForSetFieldValue("_rowID");
				_rowIDFieldSetter(row, reader.ReadOptimizedInt64());
			}
			private void deserializeRows(DataTable dataTable)
			{
				ArrayList readOnlyColumns = null;
				int rowCount = reader.ReadOptimizedInt32();

				dataTable.BeginLoadData();
				for (int i = 0; i < rowCount; i++)
				{
					BitVector32 flags = reader.ReadOptimizedBitVector32();
					DataRow row;

					if (!flags[RowHasOldData])
						row = dataTable.LoadDataRow(reader.ReadOptimizedObjectArray(), !flags[RowHasNewData]);
					else if (!flags[RowHasNewData])
					{
						row = dataTable.LoadDataRow(reader.ReadOptimizedObjectArray(), true);
						row.Delete();
					}
					else
					{
						// LoadDataRow doesn't care about ReadOnly columns but ItemArray does
						// Since only deserialization of Modified rows uses ItemArray we do this
						// only if a modified row is detected and just once
						if (readOnlyColumns == null)
						{
							readOnlyColumns = new ArrayList();
							foreach (DataColumn column in dataTable.Columns)
							{
								if (column.ReadOnly && column.Expression.Length == 0)
								{
									readOnlyColumns.Add(column);
									column.ReadOnly = false;
								}
							}
						}

						object[] currentValues;
						object[] originalValues;
						reader.ReadOptimizedObjectArrayPair(out currentValues, out originalValues);
						row = dataTable.LoadDataRow(originalValues, true);
						row.ItemArray = currentValues;
					}

					if (flags[RowHasRowError]) row.RowError = reader.ReadOptimizedString();
					if (flags[RowHasColumnErrors])
					{
						int columnsInErrorCount = reader.ReadOptimizedInt32();
						for (int j = 0; j < columnsInErrorCount; j++)
						{
							row.SetColumnError(reader.ReadOptimizedInt32(), reader.ReadOptimizedString());
						}
					}
					derializeRowAditionalData(reader, row);

				}

				// Must restore ReadOnly columns if any were found when deserializing a Modified row
				if (readOnlyColumns != null && readOnlyColumns.Count != 0)
				{
					foreach (DataColumn column in readOnlyColumns)
					{
						column.ReadOnly = true;
					}
				}

				dataTable.EndLoadData();

			}
			
			private void deserializeUniqueConstraints(DataTable dataTable)
			{
				int count = reader.ReadOptimizedInt32();
				for (int i = 0; i < count; i++)
				{
					UniqueConstraint uniqueConstraint;
					BitVector32 flags;
					string constraintName = string.Empty;
					DataColumn[] dataColumns;

					flags = reader.ReadOptimizedBitVector32();
					if (!flags[UniqueConstraintHasDefaultName])
						constraintName = reader.ReadOptimizedString();
					else
					{
						constraintName = "Constraint" + reader.ReadOptimizedInt32();
					}
					dataColumns = readColumnOrdinals(dataTable, flags[UniqueConstraintHasMultipleColumns]);
					uniqueConstraint = new UniqueConstraint(constraintName, dataColumns, flags[UniqueConstraintIsPrimaryKey]);

					if (flags[UniqueConstraintHasSchemaName]) ConstraintSchemaNameFieldInfo.SetValue(uniqueConstraint, reader.ReadOptimizedString());
					if (flags[UniqueConstraintHasExtendedProperties]) deserializeExtendedProperties(uniqueConstraint.ExtendedProperties);

					if (!uniqueConstraint.Table.Constraints.Contains(uniqueConstraint.ConstraintName))
						uniqueConstraint.Table.Constraints.Add(uniqueConstraint);
				}
			}
			
			private DataColumn[] readColumnOrdinals(DataTable dataTable, bool multipleColumns)
			{
				int count = multipleColumns ? reader.ReadOptimizedInt32() : 1;
				DataColumn[] columns = new DataColumn[count];
				for (int i = 0; i < count; i++)
				{
					columns[i] = dataTable.Columns[reader.ReadOptimizedInt32()];
				}
				return columns;
			}

			private void deserializeColumns(DataTable dataTable)
			{
				int precreatedCount = dataTable.Columns.Count;
				int count = reader.ReadOptimizedInt32();

				for (int i = 0; i < count; i++)
				{
					DataColumn column = null;
					string columnName;
					Type dataType;
					string expression;
					MappingType mappingType;

					BitVector32 flags = reader.ReadOptimizedBitVector32();

					columnName = reader.ReadOptimizedString();
					dataType = flags[ColumnIsNotStringDataType] ? reader.ReadOptimizedType() : typeof(string);
					expression = flags[ColumnHasExpression] ? reader.ReadOptimizedString() : string.Empty;
					mappingType = flags[ColumnIsNotElementMappingType] ? (MappingType)reader.ReadOptimizedInt32() : MappingType.Element;
					column = new DataColumn(columnName, dataType, expression, mappingType);

					column.AllowDBNull = flags[ColumnIsNullable];

					column.AutoIncrement = flags[ColumnHasAutoIncrement];

					if (flags[ColumnHasAutoIncrementUnusedDefaults])
					{
						if (flags[ColumnHasAutoIncrementNegativeStep])
						{
							column.AutoIncrementSeed = -1;
							column.AutoIncrementStep = -1;
						}
						else
						{
							column.AutoIncrementSeed = 0;
							column.AutoIncrementStep = 1;
						}
					}
					else
					{
						long seed = reader.ReadOptimizedInt64();
						long step = reader.ReadOptimizedInt64();
						if (flags[ColumnHasAutoIncrementNegativeStep])
						{
							column.AutoIncrementSeed = -seed;
							column.AutoIncrementStep = -step;
						}
						else
						{
							column.AutoIncrementSeed = seed;
							column.AutoIncrementStep = step;
						}
					}

					if (flags[ColumnHasCaption]) column.Caption = reader.ReadOptimizedString();
					if (flags[ColumnHasColumnUri]) ColumnUriFieldInfo.SetValue(column, reader.ReadOptimizedString());
					if (flags[ColumnHasPrefix]) column.Prefix = reader.ReadOptimizedString();
					if (flags[ColumnHasDefaultValue]) column.DefaultValue = reader.ReadObject();
					column.ReadOnly = flags[ColumnIsReadOnly];
					if (flags[ColumnHasMaxLength])
					{
						column.MaxLength = flags[ColumnIsMaxLengthMaxValue] ? int.MaxValue : reader.ReadOptimizedInt32();
					}
					if (flags[ColumnHasExtendedProperties]) deserializeExtendedProperties(column.ExtendedProperties);

					if (i >= precreatedCount) dataTable.Columns.Add(column);
				}

			}

			private void deserializeExtendedProperties(PropertyCollection properties)
			{
				object[] keys = reader.ReadOptimizedObjectArray();
				object[] values = reader.ReadOptimizedObjectArray();
				for (int i = 0; i < keys.Length; i++)
				{
					properties.Add(keys[i], values[i]);
				}
			}

			MemberSetter _nextRowIDSetter = null;
			MemberSetter _objectIDSetter = null;
			private void deserializeTableAditionalData(SerializationReader reader, DataTable dataTable)
			{
				if (_nextRowIDSetter == null)
					_nextRowIDSetter = dataTable.GetType().DelegateForSetFieldValue("nextRowID");

				_nextRowIDSetter(dataTable, reader.ReadOptimizedInt64());

				if (_objectIDSetter == null)
					_objectIDSetter = dataTable.GetType().DelegateForSetFieldValue("_objectID");

				_objectIDSetter(dataTable, reader.ReadOptimizedInt32());
			}

			private void deserializeTable(DataTable dataTable)
			{

				#region Flags
				BitVector32 flags = reader.ReadOptimizedBitVector32();

				dataTable.TableName = (flags[TableHasName]) ? reader.ReadOptimizedString() : string.Empty;

				if (flags[TableHasNamespace]) dataTable.Namespace = reader.ReadOptimizedString();
				if (flags[TableHasPrefix]) dataTable.Prefix = reader.ReadOptimizedString();
				dataTable.CaseSensitive = flags[TableIsCaseSensitive];
#if NET20
				TableCaseSensitiveAmbientFieldInfo.SetValue(dataTable, !flags[TableIsCaseSensitiveAmbient]);
#else
				TableCaseSensitiveAmbientFieldInfo.SetValue(dataTable, flags[TableIsCaseSensitiveAmbient]);
#endif
				if (flags[TableHasSpecificCulture]) dataTable.Locale = new CultureInfo(reader.ReadOptimizedInt32());
				if (flags[TableHasTypeName])
				{
					TableTypeNameFieldInfo.SetValue(dataTable, new XmlQualifiedName(reader.ReadOptimizedString(), reader.ReadOptimizedString()));
				}
				TableRepeatableElementFieldInfo.SetValue(dataTable, flags[TableHasRepeatableElement]);
				if (flags[TableHasMinimumCapacity]) dataTable.MinimumCapacity = reader.ReadOptimizedInt32();
				#endregion Flags

				#region Columns
				if (flags[TableHasColumns])
				{
					deserializeColumns(dataTable);
					if (flags[TableHasDisplayExpression]) dataTable.DisplayExpression = reader.ReadOptimizedString();
				}
				#endregion Columns

				#region Extended Properties
				if (flags[TableHasExtendedProperties]) deserializeExtendedProperties(dataTable.ExtendedProperties);
				#endregion Extended Properties

				#region Rows
				if (flags[TableHasRows]) deserializeRows(dataTable);
				#endregion Rows

				#region Unique Constraints
				if (!flags[TableHasNoUniqueConstraints])
				{
					deserializeUniqueConstraints(dataTable);
				}
				#endregion Unique Constraints

				deserializeTableAditionalData(reader, dataTable);


			}
			#endregion Private Methods
		}
		#endregion Deserializer
		#endregion Fast Serialization

	}



}