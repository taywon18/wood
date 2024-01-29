using System;
using System.IO;

namespace Wood.Destination;
{
    /// <summary>
    /// Write log into file. Keeps file open during object existence.
    /// </summary>

    public class FileDestination
        : Destination
    ,   , IDisposable
    {
        public readonly string Path;
        public readonly StreamWriter File; 

        public FileDestination(string dirpath = "./logs/")
        {
            Path = dirpath;

            if (!Directory.Exists(Path))
                Directory.CreateDirectory(Path);

            Path += DateTime.Now.ToString("yyyyMMdd-HHmmss-fffffff") + ".txt";

            File = new StreamWriter(Path, true);
            if (File.BaseStream == null)
                LogManager.Log(Gravity.Error, $"Cannot open log file: {Path}.");
            else
                File.AutoFlush = true;
        }

    public void Dispose()
    {
        File.Dispose();
    }

    public override void Log(int thread, DateTime moment, Gravity gravity, string message)
        {
            File.WriteLine("[" + gravity.ToString() + "] " + moment.ToString("HH:mm:ss.ff") + ", " + thread + ": " + message);
        }
    }
}
