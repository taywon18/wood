using System;
using System.Collections.Generic;
using System.Text;

namespace Wood.Destination
{
    public abstract class Destination
    {
        public byte MinLevelOfLog = (byte)Gravity.Debugging;

        public abstract void Log(int thread, DateTime moment, Gravity gravity, string message);
    }
}
