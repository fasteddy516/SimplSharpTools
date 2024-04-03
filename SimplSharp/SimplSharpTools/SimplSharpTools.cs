namespace SimplSharpTools
{
    /// <summary>
    /// Provides utility methods and constants for SimplSharpTools.
    /// </summary>
    public static class SimplSharpTools
    {
        /// <summary>
        /// The full version of SimplSharpTools used for Assembly attributes.  Build number is always 0.
        /// </summary>
        public const string AssemblyVersion = "0.0.1.0";

        /// <summary>
        /// Gets the offcial version of SimplSharpTools in major.minor.patch format.
        /// </summary>
        public static string Version => AssemblyVersion.Substring(0, AssemblyVersion.LastIndexOf('.'));
    }
}
