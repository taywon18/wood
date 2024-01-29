namespace Wood
{
    /// <summary>
    /// Gravity is analog as Syslog severity levels
    /// </summary>
    public enum Gravity : byte
    {
        /// <summary>
        /// System is unusable
        /// </summary>
        Emergency,

        /// <summary>
        /// Action must be taken immediately
        /// </summary>
        Alert,

        /// <summary>
        /// Critical conditions
        /// </summary>
        Critical,

        /// <summary>
        /// Error conditions
        /// </summary>
        Error,

        /// <summary>
        /// Warning conditions
        /// </summary>
        Warning,

        /// <summary>
        /// Normal but significant conditions
        /// </summary>
        Notice,

        /// <summary>
        /// Informational messages
        /// </summary>
        Informational,

        /// <summary>
        /// Debug-level messages
        /// </summary>
        Debugging // Message de débug
    };
}
