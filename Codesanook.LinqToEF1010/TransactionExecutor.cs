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
        private readonly bool isRollback;
        private readonly string connectionString;

        public Action<string> OnExecuting { get; set; }
        public Action<string, string> OnExecuted { get; set; }

        public TransactionExecutor(IsolationLevel isolationLevel, bool isRollback = false)
        {
            this.isolationLevel = isolationLevel;
            this.isRollback = isRollback;
            connectionString = ConfigurationManager.ConnectionStrings["defaultConnectionString"].ConnectionString;
        }

        public async Task Execute(params SqlCommandBase[] commands)
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
            if (isRollback)
            {
                transaction.Rollback();
            }
            else
            {
                transaction.Commit();
            }
        }
    }
}
