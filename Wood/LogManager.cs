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
        }

        public void DefaultConfiguration()
        {
            Destinations.AddDestination(new ConsoleDestination());
            Destinations.AddDestination(new FileDestination());
        }

        #region Helpers
        private void Message(Gravity g, string message)
        {
            Destinations.Log(Thread.CurrentThread.ManagedThreadId, DateTime.Now, g, message);
        }

        public static void Log(Gravity g, string message)
        {
            Instance.Message(g, message);
        }

        public static void Debug(string message)
        {
            Instance.Message(Gravity.Debugging, message);
        }

        public static void Information(string message)
        {
            Instance.Message(Gravity.Informational, message);
        }

        public static void Notice(string message)
        {
            Instance.Message(Gravity.Notice, message);
        }

        public static void Warn(string message)
        {
            Instance.Message(Gravity.Warning, message);
        }

        public static void Error(string message)
        {
            Instance.Message(Gravity.Error, message);
        }

        public static void Critical(string message)
        {
            Instance.Message(Gravity.Critical, message);
        }

        public static void Alert(string message)
        {
            Instance.Message(Gravity.Alert, message);
        }

        public static void Emergency(string message)
        {
            Instance.Message(Gravity.Emergency, message);
        }
        #endregion
    }
}
