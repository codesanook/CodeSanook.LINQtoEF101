using System.Data;
using System.Threading.Tasks;
using Codesanook.LinqToEF101.Components;
using Terminal.Gui;

namespace Codesanook.LinqToEF101
{
    public class MainWindow : Window
    {
        private readonly Panel leftPanel;
        private readonly Panel rightPanel;

        public MainWindow() : base("Codesanook")
        {
            X = 0;
            Y = 0; // Leave one row for the toplevel menu
            Width = Dim.Fill();
            Height = Dim.Fill();

            var topContainer = new View()
            {
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Percent(80),
            };

            var bottomContainer = new View()
            {
                X = 0,
                Y = Pos.Bottom(topContainer),
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

            topContainer.Add(leftContainer, rightContainer);

            var button = new Button("ok")
            {
                X = Pos.Center(),
                Y = Pos.Center(),
            };
            bottomContainer.Add(button);

            Add(topContainer, bottomContainer);
            button.Clicked = ClickAsync;
        }

        private void ClickAsync() => Task.Run(async () =>
        {
            await Task.WhenAll(RunFirstTransaction(), RunSecondTransaction());
            await RunThirdTransaction();
        });

        private Task RunFirstTransaction()
        {
            var commands = new[]
            {
                new SqlCommandExecuteNonQuery("UPDATE Employees SET Salary = 25000 WHERE Id = 1", 0, 5000)
            };

            var transactionExecutor = new TransactionExecutor(IsolationLevel.ReadCommitted, isRollback: true);
            transactionExecutor.OnExecuting = query => leftPanel.AppendText($"Executing: ${query}");
            transactionExecutor.OnExecuted = (query, result) =>
            {
                leftPanel.AppendText($"Executed: ${query}");
                leftPanel.AppendText(result);
            };

            return transactionExecutor.Execute(commands);
        }

        private Task RunSecondTransaction()
        {
            var commands = new[]
            {
               new SqlCommandExecuteReader(@"SELECT Id, FirstName, Salary FROM EMPLOYEES", 1000)
            };

            var transactionExecutor = new TransactionExecutor(IsolationLevel.ReadUncommitted);
            transactionExecutor.OnExecuting = query =>
            {
                rightPanel.AppendText($"Executing: ${query}");
            };

            transactionExecutor.OnExecuted = (query, result) =>
            {
                rightPanel.AppendText($"Executed: ${query}");
                rightPanel.AppendText(result);
            };

            return transactionExecutor.Execute(commands);
        }

        private Task RunThirdTransaction()
        {
            var commands = new[]
            {
               new SqlCommandExecuteReader(@"SELECT Id, FirstName, Salary FROM EMPLOYEES", 1000)
            };

            var transactionExecutor = new TransactionExecutor(IsolationLevel.ReadCommitted);
            transactionExecutor.OnExecuting = query =>
            {
                leftPanel.AppendText("");
                leftPanel.AppendText("");
                leftPanel.AppendText($"Executing after rollback: ${query}");
            };

            transactionExecutor.OnExecuted = (query, result) =>
            {
                leftPanel.AppendText($"Executed after rollback: ${query}");
                leftPanel.AppendText(result);
            };

            return transactionExecutor.Execute(commands);
        }
    }
}
