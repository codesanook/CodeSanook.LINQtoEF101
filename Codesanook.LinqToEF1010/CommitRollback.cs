using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using NStack;
using Terminal.Gui;

namespace Codesanook.LinqToEF101
{
    public class CommitRollback : Window
    {
        public CommitRollback() : base("Transaction commit rollback")
        {
            X = 0;
            Y = 0; // Leave one row for the toplevel menu
            //// By using Dim.Fill(), it will automatically resize without manual intervention
            Width = Dim.Fill();
            Height = Dim.Fill();
        }

        private async void clickAsync()
        {

            var task1 = ExecuteTransaction(
                IsolationLevel.ReadCommitted,
                (query) =>
                {
                },
                "UPDATE StudentMarks SET marksObtained = 90 WHERE deptId = 101 AND examId = 201",
                "UPDATE Exam SET examDesc = 'Theory Paper and Lab Assignmnet in Data Structure' WHERE examId = 201",
                "UPDATE StudentMarks SET marksObtained = 70 --80 WHERE deptId = 101 AND examId = 201"
            );
            await Task.WhenAll(task1);
        }

        private async Task ExecuteTransaction(IsolationLevel isolationLevel, Action<string> action, params string[] queries)
        {
            using var connection = new SqlConnection(
                ConfigurationManager.ConnectionStrings["defaultConnectionString"].ConnectionString
            );

            await connection.OpenAsync();
            using var transaction = await connection.BeginTransactionAsync(isolationLevel);

            foreach (var query in queries)
            {
                var command = new SqlCommand(query, connection, (SqlTransaction)transaction);
                await Task.Delay(100);
                await command.ExecuteNonQueryAsync();
                action(query);
            }
            transaction.Commit();
        }


    }
}
