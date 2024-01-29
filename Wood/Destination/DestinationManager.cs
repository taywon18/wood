using System;
using System.Collections.Generic;
using System.Text;

namespace Wood.Destination
{
    public class DestinationManager
    {
        public readonly List<Destination> Destinations = new List<Destination>();

        public void Log(int thread, DateTime moment, Gravity gravity, string message)
        {
            foreach (var d in Destinations)
                if ((byte)gravity <= d.MinLevelOfLog)
                    d.Log(thread, moment, gravity, message);
        }

        public void AddDestination<T>(T destination) where T : Destination
        {
            Destinations.Add(destination);
        }
    }
}
