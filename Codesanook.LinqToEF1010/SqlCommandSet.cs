using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;

namespace Codesanook.LinqToEF101
{
    public class SqlCommandSet
    {
        public SqlCommandSet(
           IsolationLevel isolationLevel,
           bool isCommitted,
           params SqlCommandBase[] commands
        )
        {
            Commands = commands;
            IsolationLevel = isolationLevel;
            IsCommitted = isCommitted;
        }

        public SqlCommandBase[] Commands { get; }
        public IsolationLevel IsolationLevel { get; }
        public bool IsCommitted { get; }
    }
}
