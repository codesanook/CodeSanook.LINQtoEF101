using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesanook.LinqToEF101
{
    public abstract class SqlCommandBase
    {
        public string Query { get; }
        public int? DelayAfterRunningCommadnInMilliseconds { get; }
        public int? DelayBeforeRunningCommadnInMilliseconds { get; }

        public SqlCommandBase(
            string query,
            int? delayBeforeRunningCommadnInMilliseconds = null,
            int? delayAfterRunningCommadnInMilliseconds = null)
        {
            Query = query;
            DelayBeforeRunningCommadnInMilliseconds = delayBeforeRunningCommadnInMilliseconds;
            DelayAfterRunningCommadnInMilliseconds = delayAfterRunningCommadnInMilliseconds;
        }

        public abstract Task<string> ExectuteAsync(SqlConnection connection, SqlTransaction transaction);
    }

    public class SqlCommandExecuteReader : SqlCommandBase
    {
        public SqlCommandExecuteReader(
            string query,
            int? delayBeforeRunningCommadnInMilliseconds = null,
            int? delayAfterRunningCommadnInMilliseconds = null
        ) : base(
            query,
            delayBeforeRunningCommadnInMilliseconds,
            delayAfterRunningCommadnInMilliseconds)
        { }

        public override async Task<string> ExectuteAsync(SqlConnection connection, SqlTransaction transaction)
        {
            var stringBuilder = new StringBuilder();
            var command = new SqlCommand(this.Query, connection, transaction);
            using var reader = await command.ExecuteReaderAsync();
            //Get All column 
            var columnNames = Enumerable.Range(0, reader.FieldCount)
                .Select(reader.GetName)
                .ToArray();

            //Create headers
            stringBuilder.AppendLine(string.Join(", ", columnNames));

            while (reader.Read())
            {
                var values = columnNames
                    .Select(column => reader.GetValue(reader.GetOrdinal(column)).ToString())
                    .ToArray();
                stringBuilder.AppendLine(string.Join(", ", values));
            }
            return stringBuilder.ToString();
        }
    }

    public class SqlCommandExecuteNonQuery : SqlCommandBase
    {
        public SqlCommandExecuteNonQuery(
            string query,
            int? delayBeforeRunningCommadnInMilliseconds = null,
            int? delayAfterRunningCommadnInMilliseconds = null
        ) : base(
            query,
            delayBeforeRunningCommadnInMilliseconds,
            delayAfterRunningCommadnInMilliseconds)
        { }

        public override async Task<string> ExectuteAsync(SqlConnection connection, SqlTransaction transaction)
        {
            var command = new SqlCommand(this.Query, connection, transaction);
            var rowEffect = await command.ExecuteNonQueryAsync();
            return $"{rowEffect} row effect";
        }
    }
}
