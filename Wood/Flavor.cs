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
}
