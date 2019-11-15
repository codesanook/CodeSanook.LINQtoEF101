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
    public class MainWindow : Window
    {
        private TextView textView1;
        private TextView textView2;
        private Button button;

        public MainWindow() : base("testxx")
        {
            X = 0;
            Y = 1; // Leave one row for the toplevel menu
            //// By using Dim.Fill(), it will automatically resize without manual intervention
            Width = Dim.Fill();
            Height = Dim.Fill();

            var menu = new MenuBar(new MenuBarItem[] {
            new MenuBarItem ("_File", new MenuItem [] {
                    new MenuItem ("_Quit", "", () => {
                        Application.RequestStop ();
                    })
                }),
            });

            textView1 = new TextView
            {
                X = Pos.Center(),
                Y = Pos.At(5),
                Width = Dim.Fill(),
                Height = 3,
                Text = "OKay\nokay"
            };

            textView2 = new TextView
            {
                X = Pos.Center(),
                Y = Pos.Bottom(textView1) + 5,
                Width = Dim.Fill(),
                Height = 3,
                Text = "OKay2\nokay"
            };

            button = new Button(10, 20, "ok");
            button.Clicked = clickAsync;

            this.Add(textView1, textView2, button);


        }

        private void clickAsync() => Task.Run(async () =>
        {
            var output1 = new StringBuilder();
            var output2 = new StringBuilder();

            var task1 = ExecuteTransaction(
                IsolationLevel.ReadCommitted,
                (query) =>
                {
                    Application.MainLoop.Invoke(() =>
                    {
                        output1.AppendLine(query);
                        textView1.Text = output1.ToString();
                    });
                },
                "UPDATE StudentMarks SET marksObtained = 90 WHERE deptId = 101 AND examId = 201",
                "UPDATE Exam SET examDesc = 'Theory Paper and Lab Assignmnet in Data Structure' WHERE examId = 201",
                "UPDATE StudentMarks SET marksObtained = 70 --80 WHERE deptId = 101 AND examId = 201"
            );

            var task2 = Task.Run(async () =>
            {
                await Task.Delay(500);
                await ExecuteTransaction(
                    IsolationLevel.ReadCommitted,
                    (query) =>
                    {
                        Application.MainLoop.Invoke(() =>
                        {
                            output2.AppendLine(query);
                            textView2.Text = output2.ToString();
                        });
                    },
                    "SELECT marksObtained FROM StudentMarks WHERE deptId = 101 AND examId = 201 AND studentId = 1"
                );
            });

            await Task.WhenAll(task1, task2);
        });

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
                await Task.Delay(1000);
                await command.ExecuteNonQueryAsync();
                action(query);
            }
            transaction.Commit();
        }


    }
}
