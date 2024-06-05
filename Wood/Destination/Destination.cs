using System;
using System.Collections.Generic;
using System.Text;

namespace Wood.Destination
{
    public abstract class Destination
    {
        public byte MinLevelOfLog = (byte)Severity.Debugging;

        public abstract void Log(int thread, DateTime moment, Severity gravity, Message content);
    }
}
