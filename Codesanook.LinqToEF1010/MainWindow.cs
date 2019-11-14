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
                Y = Pos.At(10),
                Width = Dim.Fill(),
                Height = 3,
                Text = "OKay\nokay"
            };

            textView2 = new TextView
            {
                X = Pos.Center(),
                Y = Pos.Bottom(textView1),
                Width = Dim.Fill(),
                Height = 3,
                Text = "OKay2\nokay"
            };

            button = new Button(10, 20, "ok");
            button.Clicked = clickAsync;

            this.Add(textView1, textView2, button);


        }

        private async void clickAsync()
        {


            var task1 = ExecuteTransaction(
                IsolationLevel.ReadCommitted,
                (query) =>
                {
                    var keyEvent = new KeyEvent(Key.Esc);
                    button.ProcessKey(keyEvent);
                    textView1.Text += "\n" + query;
                },
                "UPDATE StudentMarks SET marksObtained = 90 WHERE deptId = 101 AND examId = 201",
                "UPDATE Exam SET examDesc = 'Theory Paper and Lab Assignmnet in Data Structure' WHERE examId = 201",
                "UPDATE StudentMarks SET marksObtained = 70 --80 WHERE deptId = 101 AND examId = 201"
            );

            //var task2 = ExecuteTransaction(
            //    textView2,
            //    IsolationLevel.ReadCommitted,
            //    "SELECT marksObtained FROM StudentMarks WHERE deptId = 101 AND examId = 201 AND studentId = 1"
            //);

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
