using System;
using System.IO;
using System.Linq;

namespace Wood.Destination
{
    /// <summary>
    /// Write log into file. Keeps file open during object existence.
    /// </summary>

    public class FileDestination
        : Destination
        , IDisposable
    {
        private string Path;
        private StreamWriter File;
        public string Format = "[{0}] {1}, {2}: {3}";

        bool Inited = false;

        public FileDestination()
            : this("./logs/")
        {

        }

        public FileDestination(string dirpath)
        {
            Path = dirpath;
        }

        public void Dispose()
        {
            if(Inited)
                File.Dispose();
        }

        private void Init()
        {
            if (!Directory.Exists(Path))
                Directory.CreateDirectory(Path);

            Path += DateTime.Now.ToString("yyyyMMdd-HHmmss-fffffff") + ".txt";

            File = new StreamWriter(Path, true);
            if (File.BaseStream == null)
                LogManager.Log(Severity.Error, $"Cannot open log file: {Path}.");
            else
                File.AutoFlush = true;

            Inited = true;
        }

        public override void Log(int thread, DateTime moment, Severity gravity, Message msg)
        {
            if (!Inited)
                Init();

            string concatMessage = String.Format(
                Format,
                gravity,
                moment.ToString("HH:mm:ss.ff"),
                thread,
                String.Concat(msg.Parameters.Where(x => !(x is Flavor)))
            );

            File.WriteLine(concatMessage);
        }
    }
}
