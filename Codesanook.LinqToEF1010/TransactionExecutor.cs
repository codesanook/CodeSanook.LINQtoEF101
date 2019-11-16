using Microsoft.Data.SqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Codesanook.LinqToEF101
{
    public class TransactionExecutor
    {
        private readonly IsolationLevel isolationLevel;
        private readonly bool isCommitted;
        private readonly string connectionString;

        public Action<string> OnExecuting { get; set; }
        public Action<string, string> OnExecuted { get; set; }

        public TransactionExecutor(IsolationLevel isolationLevel, bool isCommitted)
        {
            this.isolationLevel = isolationLevel;
            this.isCommitted = isCommitted;
            connectionString = ConfigurationManager.ConnectionStrings["defaultConnectionString"].ConnectionString;
        }

        public async Task ExecuteAsync(params SqlCommandBase[] commands)
        {
            using var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();
            using var transaction = await connection.BeginTransactionAsync(isolationLevel);

            foreach (var command in commands)
            {
                if (OnExecuting != null)
                {
                    Application.MainLoop.Invoke(() =>
                    {
                        OnExecuting(command.Query);
                    });
                }

                if (command.DelayBeforeRunningCommadnInMilliseconds.HasValue)
                {
                    await Task.Delay(command.DelayBeforeRunningCommadnInMilliseconds.Value);
                }
                var result = await command.ExectuteAsync(connection, (SqlTransaction)transaction);
                if (command.DelayAfterRunningCommadnInMilliseconds.HasValue)
                {
                    await Task.Delay(command.DelayAfterRunningCommadnInMilliseconds.Value);
                }

                if (OnExecuted != null)
                {
                    Application.MainLoop.Invoke(() =>
                    {
                        OnExecuted(command.Query, result);
                    });
                }
            }
            if (isCommitted)
            {
                transaction.Commit();
            }
            else
            {
                transaction.Rollback();
            }
        }
    }
}
