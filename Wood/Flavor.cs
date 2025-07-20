using System.Collections.Generic;

namespace Wood
{
    /// <summary>
    /// Flavor should enhance readability of logs messages
    /// </summary>
    public enum Flavor
    {
        /// <summary>
        /// Used by default
        /// </summary>
        Normal = 0,

        /// <summary>
        /// Used for importants elements
        /// </summary>
        Important,

        /// <summary>
        /// Used for success
        /// </summary>
        Ok,

        /// <summary>
        /// Used for fails
        /// </summary>
        Failed,

        /// <summary>
        /// Used for progress
        /// </summary>
        Progress
    }

    static class Flavored
    {
        static object[] Important(params object[] parameters)
        {
            List<object> result = new List<object>(parameters.Length + 2);
            result.Add(Flavor.Important);
            result.AddRange(parameters);
            result.Add(Flavor.Normal);
            return result.ToArray();
        }

        static object[] Ok(params object[] parameters)
        {
            List<object> result = new List<object>(parameters.Length + 2);
            result.Add(Flavor.Ok);
            result.AddRange(parameters);
            result.Add(Flavor.Normal);
            return result.ToArray();
        }

        static object[] Failed(params object[] parameters)
        {
            List<object> result = new List<object>(parameters.Length + 2);
            result.Add(Flavor.Failed);
            result.AddRange(parameters);
            result.Add(Flavor.Normal);
            return result.ToArray();
        }

        static object[] Progress(params object[] parameters)
        {
            List<object> result = new List<object>(parameters.Length + 2);
            result.Add(Flavor.Progress);
            result.AddRange(parameters);
            result.Add(Flavor.Normal);
            return result.ToArray();
        }
    }
}