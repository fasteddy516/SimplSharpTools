namespace SimplSharpTools
{
    /// <summary>
    /// Provides version information for SimplSharpTools.
    /// </summary>
    public static class SimplSharpToolsVersion
    {
        /// <summary>
        /// The full version of SimplSharpTools used for Assembly attributes.  Build number is always 0.
        /// </summary>
        public const string Assembly = "0.0.4.0";

        /// <summary>
        /// Gets the official version of SimplSharpTools in major.minor.patch format.
        /// </summary>
        public static string Package => Assembly.Substring(0, Assembly.LastIndexOf('.'));
    }
}
