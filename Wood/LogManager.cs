using System;
using System.Threading;
using Wood.Destination;

namespace Wood
{
    public class LogManager
    {
        public readonly static LogManager Instance = new LogManager();
        public readonly DestinationManager Destinations = new DestinationManager();

        private LogManager()
        {
            DefaultConfiguration();
        }

        public void ClearConfiguration()
        {
            Destinations.Clear();
        }

        public void DefaultConfiguration()
        {
            Destinations.Add<ConsoleDestination>();
            Destinations.Add<FileDestination>();
        }

        #region Helpers
        private void Message(Severity g, params object[] message)
        {
            Destinations.Log(Thread.CurrentThread.ManagedThreadId, DateTime.Now, g, new Message
            {
                Parameters = message
            });
        }

        public static void Log(Severity g, params object[] message)
        {
            Instance.Message(g, message);
        }

        public static void Debug(params object[] message)
        {
            Instance.Message(Severity.Debugging, message);
        }

        public static void Information(params object[] message)
        {
            Instance.Message(Severity.Informational, message);
        }

        public static void Notice(params object[] message)
        {
            Instance.Message(Severity.Notice, message);
        }

        public static void Warn(params object[] message)
        {
            Instance.Message(Severity.Warning, message);
        }

        public static void Error(params object[] message)
        {
            Instance.Message(Severity.Error, message);
        }

        public static void Critical(params object[] message)
        {
            Instance.Message(Severity.Critical, message);
        }

        public static void Alert(params object[] message)
        {
            Instance.Message(Severity.Alert, message);
        }

        public static void Emergency(params object[] message)
        {
            Instance.Message(Severity.Emergency, message);
        }
        #endregion
    }
}
