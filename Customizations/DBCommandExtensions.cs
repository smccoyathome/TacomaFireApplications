using System.Data.Common;

namespace UpgradeHelpers.Extensions
{
    public static class DBCommandExtensions
    {
        public static void AddParameter(this DbCommand command, object value)
        {
            var parameter = command.CreateParameter();
            parameter.Value = value;
            command.Parameters.Add(parameter);
        }

        public static void ExecuteNonQuery(this DbCommand command, object[] parametersvalues)
        {
            command.Parameters.Clear();
            foreach (var value in parametersvalues)
            {
                var parameter = command.CreateParameter();
                parameter.Value = value;
                command.Parameters.Add(parameter);
            }
            command.ExecuteNonQuery();
        }
    }
}