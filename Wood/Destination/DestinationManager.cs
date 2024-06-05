using System;
using System.Collections;
using System.Collections.Generic;

namespace Wood.Destination
{
    public class DestinationManager
        : IList<Destination>
    {
        public readonly List<Destination> Destinations = new List<Destination>();
        private object Mutex = new object();

        public int Count => ((ICollection<Destination>)Destinations).Count;
        public bool IsReadOnly => ((ICollection<Destination>)Destinations).IsReadOnly;
        public Destination this[int index] { get => ((IList<Destination>)Destinations)[index]; set => ((IList<Destination>)Destinations)[index] = value; }

        public void Log(int thread, DateTime moment, Severity gravity, Message message)
        {
            lock(Mutex)
                foreach (var d in Destinations)
                    if ((byte)gravity <= d.MinLevelOfLog)
                        d.Log(thread, moment, gravity, message);
        }

        [Obsolete("Worst implementation ever. Was probably drunk when i done this. Pls don't use it :/")]
        public void Add<T>(T destination) where T : Destination
        {
            lock (Mutex)
                Destinations.Add(destination);
        }

        public void Add(Destination destination)
        {
            lock (Mutex)
                Destinations.Add(destination);
        }

        public T Add<T>() where T : Destination, new()
        {
            var ret = new T();
            lock (Mutex)
                Destinations.Add(ret);
            return ret;
        }


        public void Clear()
        {
            lock (Mutex)
                Destinations.Clear();
        }

        public int IndexOf(Destination item)
        {
            lock (Mutex)
                return ((IList<Destination>)Destinations).IndexOf(item);
        }

        public void Insert(int index, Destination item)
        {
            lock (Mutex)
                ((IList<Destination>)Destinations).Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            lock (Mutex)
                ((IList<Destination>)Destinations).RemoveAt(index);
        }

        void ICollection<Destination>.Clear()
        {
            lock (Mutex)
                ((ICollection<Destination>)Destinations).Clear();
        }

        public bool Contains(Destination item)
        {
            lock (Mutex)
                return ((ICollection<Destination>)Destinations).Contains(item);
        }

        public void CopyTo(Destination[] array, int arrayIndex)
        {
            lock (Mutex)
                ((ICollection<Destination>)Destinations).CopyTo(array, arrayIndex);
        }

        public bool Remove(Destination item)
        {
            lock (Mutex)
                return ((ICollection<Destination>)Destinations).Remove(item);
        }

        public IEnumerator<Destination> GetEnumerator()
        {
            lock (Mutex) // i'm not sure if it's pertinent...
                return ((IEnumerable<Destination>)Destinations).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            lock (Mutex) // i'm not sure if it's pertinent...
                return ((IEnumerable)Destinations).GetEnumerator();
        }
    }
}
