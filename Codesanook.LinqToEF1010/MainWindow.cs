using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Codesanook.LinqToEF101.Components;
using Terminal.Gui;
/*
https://www.interfacett.com/blogs/understanding-isolation-levels-sql-server-2008-r2-2012-examples/
https://en.wikipedia.org/wiki/Isolation_(database_systems)
https://docs.microsoft.com/en-us/sql/odbc/reference/develop-app/transaction-isolation-levels?view=sql-server-ver15
https://www.mssqltips.com/sqlservertip/2977/demonstrations-of-transaction-isolation-levels-in-sql-server/
https://www.sqlservercentral.com/articles/isolation-levels-in-sql-server
 */
namespace Codesanook.LinqToEF101
{
    public class MainWindow : Window
    {
        private readonly Panel leftPanel;
        private readonly Panel rightPanel;
        private readonly RadioGroup radioGroup;

        public MainWindow() : base("Codesanook")
        {
            X = 0;
            Y = 0;
            Width = Dim.Fill();
            Height = Dim.Fill();

            var topContainer = new View()
            {
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Percent(25),
            };

            var middleContainer = new View()
            {
                X = 0,
                Y = Pos.Bottom(topContainer),
                Width = Dim.Fill(),
                Height = Dim.Percent(80),
            };

            var bottomContainer = new View()
            {
                X = 0,
                Y = Pos.Bottom(middleContainer),
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            var leftContainer = new View()
            {
                X = 0,
                Y = 0,
                Width = Dim.Percent(50),
                Height = Dim.Fill(),
            };

            leftPanel = new Panel("Left Panel");
            leftContainer.Add(leftPanel);

            var rightContainer = new View()
            {
                X = Pos.Right(leftContainer),// Read as "position at right of left container"
                Y = 0,
                Width = Dim.Fill(), //fill of left area
                Height = Dim.Fill(),
            };

            rightPanel = new Panel("right Panel");
            rightContainer.Add(rightPanel);

            middleContainer.Add(leftContainer, rightContainer);

            var button = new Button("ok")
            {
                X = Pos.Center(),
                Y = Pos.Center(),
            };
            bottomContainer.Add(button);

            //https://github.com/migueldeicaza/gui.cs/blob/master/Terminal.Gui/Views/RadioGroup.cs
            radioGroup = new RadioGroup(0, 0, new[] {
                "Read Uncommited",
                "Read Committed",
                "Non Repeatable Read",
                "Repeatable Read",
                "Phantom New Row",
                "Serializable",
                "Snapshot",
                "Read Committed Snapshot",
            });

            topContainer.Add(radioGroup);
            Add(topContainer, middleContainer, bottomContainer);
            button.Clicked = ClickAsync;
        }

        private void ClickAsync()
        {
            var task = Task.Run(async () =>
            {
                switch (radioGroup.Selected)
                {
                    case 0:
                        foreach (var task in ReadUncommitted())
                        {
                            await task;
                        }
                        break;
                    case 1:
                        foreach (var task in ReadCommitted())
                        {
                            await task;
                        }
                        break;
                    case 2:
                        foreach (var task in NonRepeatableRead())
                        {
                            await task;
                        }
                        break;
                    case 3:
                        foreach (var task in RepeatableRead())
                        {
                            await task;
                        }
                        break;
                    case 4:
                        foreach (var task in PhantomRow())
                        {
                            await task;
                        }
                        break;
                    case 5:
                        foreach (var task in Serealizable())
                        {
                            await task;
                        }
                        break;
                    case 6:
                        foreach (var task in Snapshot())
                        {
                            await task;
                        }
                        break;
                    case 7:
                        foreach (var task in ReadCommittedSnapshot())
                        {
                            await task;
                        }
                        break;
                }
            });

            task.ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    Application.MainLoop.Invoke(() => 
                        leftPanel.AppendText($"exception: {t.Exception.Message}"));
                }

                if (t.IsCompleted)
                {
                    //optionally do some work);
                }
            });
        }

        private IEnumerable<Task> ReadCommittedSnapshot()
        {
            return ExecuteTransaction(new[] {
                (
                    new SqlCommandSet(
                        IsolationLevel.ReadCommitted,
                        isCommitted: true,
                        new SqlCommandExecuteReader(@"SELECT Id, FirstName, Salary FROM EMPLOYEES", 1000),
                        new SqlCommandExecuteReader(@"SELECT Id, FirstName, Salary FROM EMPLOYEES", 1000),
                        new SqlCommandExecuteNonQuery("UPDATE Employees SET Salary = 9000 WHERE Id = 1", 2000)
                    ),
                    new SqlCommandSet(
                        IsolationLevel.ReadCommitted,
                        isCommitted: true,
                        new SqlCommandExecuteNonQuery("UPDATE Employees SET Salary = 25000 WHERE Id = 1", 500, 1000)
                    )
                ),
                (
                    new SqlCommandSet(
                        IsolationLevel.ReadCommitted,
                        isCommitted: true,
                        new SqlCommandExecuteReader(@"SELECT Id, FirstName, Salary FROM EMPLOYEES")
                    ),
                    null
                )
            });
        }

        private IEnumerable<Task> Snapshot()
        {
            return ExecuteTransaction(new[] {
                (
                    new SqlCommandSet(
                        IsolationLevel.Snapshot,
                        isCommitted: true,
                        new SqlCommandExecuteReader(@"SELECT Id, FirstName, Salary FROM EMPLOYEES", 1000),
                        new SqlCommandExecuteReader(@"SELECT Id, FirstName, Salary FROM EMPLOYEES", 1000),
                        new SqlCommandExecuteNonQuery("UPDATE Employees SET Salary = 9000 WHERE Id = 1", 2000)
                    ),
                    new SqlCommandSet(
                        IsolationLevel.ReadCommitted,
                        isCommitted: true,
                        new SqlCommandExecuteNonQuery("UPDATE Employees SET Salary = 25000 WHERE Id = 1", 500, 1000)
                    )
                ),
                (
                    new SqlCommandSet(
                        IsolationLevel.ReadCommitted,
                        isCommitted: true,
                        new SqlCommandExecuteReader(@"SELECT Id, FirstName, Salary FROM EMPLOYEES")
                    ),
                    null
                )
            });
        }

        private IEnumerable<Task> Serealizable()
        {
            return ExecuteTransaction(new[] {
                (
                    new SqlCommandSet(
                        IsolationLevel.Serializable,
                        isCommitted: true,
                        new SqlCommandExecuteReader(@"SELECT Id, FirstName, Salary FROM EMPLOYEES"),
                        new SqlCommandExecuteReader(@"SELECT Id, FirstName, Salary FROM EMPLOYEES", 2000)
                    ),
                    new SqlCommandSet(
                        IsolationLevel.ReadCommitted,
                        isCommitted: true,
                        new SqlCommandExecuteNonQuery(
                            $"INSERT INTO Employees VALUES ('pong{new Random().Next(0, 1000)}@example.com', 'Pong', 'Codesanook', '1984-07-20', 9000)",
                            500
                        )
                    )
                ),
            });
        }

        private IEnumerable<Task> PhantomRow()
        {
            return ExecuteTransaction(new[] {
                (
                    new SqlCommandSet(
                        IsolationLevel.RepeatableRead,
                        isCommitted: true,
                        new SqlCommandExecuteReader(@"SELECT Id, FirstName, Salary FROM EMPLOYEES"),
                        new SqlCommandExecuteReader(@"SELECT Id, FirstName, Salary FROM EMPLOYEES", 2000)
                    ),
                    new SqlCommandSet(
                        IsolationLevel.ReadCommitted,
                        isCommitted: true,
                        new SqlCommandExecuteNonQuery(
                            $"INSERT INTO Employees VALUES ('pong{new Random().Next(0, 1000)}@example.com', 'Pong', 'Codesanook', '1984-07-20', 9000)",
                            500
                        )
                    )
                ),
            });
        }

        private IEnumerable<Task> RepeatableRead()
        {
            return ExecuteTransaction(new[] {
                (
                    new SqlCommandSet(
                        IsolationLevel.RepeatableRead,
                        isCommitted: true,
                        new SqlCommandExecuteReader(@"SELECT Id, FirstName, Salary FROM EMPLOYEES"),
                        new SqlCommandExecuteReader(@"SELECT Id, FirstName, Salary FROM EMPLOYEES", 2000)
                    ),
                    new SqlCommandSet(
                        IsolationLevel.ReadCommitted,
                        isCommitted: true,
                        new SqlCommandExecuteNonQuery("UPDATE Employees SET Salary = 9000 WHERE Id = 1", 500, 0)
                    )
                ),
            });
        }

        private IEnumerable<Task> NonRepeatableRead()
        {
            return ExecuteTransaction(new[] {
                (
                    new SqlCommandSet(
                        IsolationLevel.ReadCommitted,
                        isCommitted: true,
                        new SqlCommandExecuteReader(@"SELECT Id, FirstName, Salary FROM EMPLOYEES"),
                        new SqlCommandExecuteReader(@"SELECT Id, FirstName, Salary FROM EMPLOYEES", 2000)
                    ),
                    new SqlCommandSet(
                        IsolationLevel.ReadUncommitted,
                        isCommitted: true,
                        new SqlCommandExecuteNonQuery("UPDATE Employees SET Salary = 25000 WHERE Id = 1", 500, 0)
                    )
                ),
            });
        }

        private IEnumerable<Task> ReadUncommitted()
        {
            return ExecuteTransaction(new[] {
                (
                    new SqlCommandSet(
                        IsolationLevel.ReadCommitted,
                        isCommitted: false,
                        new SqlCommandExecuteNonQuery("UPDATE Employees SET Salary = 25000 WHERE Id = 1", 0, 5000)
                    ),
                    new SqlCommandSet(
                        IsolationLevel.ReadUncommitted,
                        isCommitted: true,
                        new SqlCommandExecuteReader(@"SELECT Id, FirstName, Salary FROM EMPLOYEES", 500)
                    )
                ),
                (
                    new SqlCommandSet(
                        IsolationLevel.ReadCommitted,
                        isCommitted: true,
                        new SqlCommandExecuteReader(@"SELECT Id, FirstName, Salary FROM EMPLOYEES", 1000)
                    ),
                    null
                ),
            });
        }

        private IEnumerable<Task> ReadCommitted()
        {
            return ExecuteTransaction(new[] {
                (
                    new SqlCommandSet(
                        IsolationLevel.ReadCommitted,
                        isCommitted: false,
                        new SqlCommandExecuteNonQuery("UPDATE Employees SET Salary = 25000 WHERE Id = 1", 0, 5000)
                    ),
                    new SqlCommandSet(
                        IsolationLevel.ReadCommitted,
                        isCommitted: true,
                        new SqlCommandExecuteReader(@"SELECT Id, FirstName, Salary FROM EMPLOYEES", 500)
                    )
                ),
                (
                    new SqlCommandSet(
                        IsolationLevel.ReadCommitted,
                        isCommitted: true,
                        new SqlCommandExecuteReader(@"SELECT Id, FirstName, Salary FROM EMPLOYEES")
                    ),
                    null
                )
            });
        }


        private IEnumerable<Task> ExecuteTransaction(
            IReadOnlyCollection<(SqlCommandSet CommandsForFirstTransaction, SqlCommandSet CommandsForSecondTransaction)>
            sqlCommandTransactionPair
        )
        {
            if (sqlCommandTransactionPair is null)
            {
                throw new ArgumentNullException(nameof(sqlCommandTransactionPair));
            }

            foreach (var command in sqlCommandTransactionPair)
            {
                var tasks = new List<Task>();
                if (command.CommandsForFirstTransaction != null)
                {
                    tasks.Add(CreateTransactionTask(
                        command.CommandsForFirstTransaction.Commands,
                        command.CommandsForFirstTransaction.IsolationLevel,
                        command.CommandsForFirstTransaction.IsCommitted,
                        leftPanel
                    ));
                }
                if (command.CommandsForSecondTransaction != null)
                {
                    tasks.Add(CreateTransactionTask(
                        command.CommandsForSecondTransaction.Commands,
                        command.CommandsForSecondTransaction.IsolationLevel,
                        command.CommandsForSecondTransaction.IsCommitted,
                        rightPanel
                    ));
                }
                yield return Task.WhenAll(tasks);
            }
        }

        private Task CreateTransactionTask(
            SqlCommandBase[] commands,
            IsolationLevel isolationLevel,
            bool isCommitted,
            Panel panel
        )
        {
            var transactionExecutor = new TransactionExecutor(
                isolationLevel,
                isCommitted: isCommitted
            );
            transactionExecutor.OnExecuting = query => panel.AppendText($"Executing: ${query}");
            transactionExecutor.OnExecuted = (query, result) =>
            {
                panel.AppendText($"Executed: ${query}");
                panel.AppendText(result);
                panel.AppendText("");
            };

            return transactionExecutor.ExecuteAsync(commands);
        }
    }
}
