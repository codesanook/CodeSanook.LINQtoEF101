using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Xml;
// https://dotnetthoughts.net/how-to-use-log4net-with-aspnetcore-for-logging/
namespace CodeSanook.StackOverflowEFQuery.ConsoleApp.Logging
{
    public sealed class Log4NetProvider : ILoggerProvider, IDisposable
    {
        private readonly string log4NetConfigFile;
        private readonly ConcurrentDictionary<string, Log4NetLogger> loggers = new ConcurrentDictionary<string, Log4NetLogger>();
        public Log4NetProvider(string log4NetConfigFile) => this.log4NetConfigFile = log4NetConfigFile;

        public ILogger CreateLogger(string categoryName)
        {
            return loggers.GetOrAdd(categoryName, CreateLoggerImplementation);
        }

        public void Dispose()
        {
            loggers.Clear();
        }

        private Log4NetLogger CreateLoggerImplementation(string name)
        {
            return new Log4NetLogger(name, Parselog4NetConfigFile(log4NetConfigFile));
        }

        private static XmlElement Parselog4NetConfigFile(string filename)
        {
            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead(filename));
            return log4netConfig["log4net"];
        }
    }

}
