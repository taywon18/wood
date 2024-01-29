using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Wood.Destination
{
    public class FileDestination
        : Destination
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

        public override void Log(int thread, DateTime moment, Gravity gravity, string message)
        {
            File.WriteLine("[" + gravity.ToString() + "] " + moment.ToString("HH:mm:ss.ff") + ", " + thread + ": " + message);
        }
    }
}
