using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace UpgradeHelpers.DB
{
    public class DBUtils
    {

        /// <summary>
        /// Determines if a type is numeric.  Nullable numeric types are considered numeric.
        /// </summary>
        protected internal static bool IsNumericType(Type type)
        {
            if (type == null)
            {
                return false;
            }

            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return true;
                case TypeCode.Object:
                    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        return IsNumericType(Nullable.GetUnderlyingType(type));
                    }
                    return false;
            }
            return false;
        }

        /// <summary>
        ///     Converts from DbType to System.Type.
        /// </summary>
        /// <param name="dbType">The DBType to be converted.</param>
        /// <returns>The equivalent System.Type.</returns>
        public static Type GetType(DbType dbType)
        {
            Type result = Type.GetType("System.String");
            switch (dbType)
            {
                case DbType.Byte:
                    result = Type.GetType("System.Byte");
                    break;
                case DbType.Binary:
                    result = Type.GetType("System.Byte[]");
                    break;
                case DbType.Boolean:
                    result = Type.GetType("System.Boolean");
                    break;
                case DbType.DateTime:
                    result = Type.GetType("System.DateTime");
                    break;
                case DbType.Decimal:
                    result = Type.GetType("System.Decimal");
                    break;
                case DbType.Double:
                    result = Type.GetType("System.Double");
                    break;
                case DbType.Guid:
                    result = Type.GetType("System.Guid");
                    break;
                case DbType.Int16:
                    result = Type.GetType("System.Int16");
                    break;
                case DbType.Int32:
                    result = Type.GetType("System.Int32");
                    break;
                case DbType.Int64:
                    result = Type.GetType("System.Int64");
                    break;
                case DbType.Object:
                    result = Type.GetType("System.Object");
                    break;
                case DbType.SByte:
                    result = Type.GetType("System.SByte");
                    break;
                case DbType.Single:
                    result = Type.GetType("System.Single");
                    break;
                case DbType.String:
                    result = Type.GetType("System.String");
                    break;
                case DbType.UInt16:
                    result = Type.GetType("System.UInt16");
                    break;
                case DbType.UInt32:
                    result = Type.GetType("System.UInt32");
                    break;
                case DbType.UInt64:
                    result = Type.GetType("System.UInt64");
                    break;
            }
            return result;
        }

    }
}
