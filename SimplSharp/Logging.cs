using Crestron.SimplSharp;

namespace SimplSharpTools
{
    /// <summary>
    /// Represents the log levels on a Crestron control system.
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Notice log level.
        /// </summary>
        NOTICE,

        /// <summary>
        /// Warning log level.
        /// </summary>
        WARNING,

        /// <summary>
        /// Error log level.
        /// </summary>
        ERROR,
    }

    /// <summary>
    /// Provides logging functionality for Crestron control systems.
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Logs a message with the specified log level. 
        /// This method only logs messages if the application is running on a Crestron platform.
        /// </summary>
        /// <param name="msg">The message to log.</param>
        /// <param name="level">The log level indicating the severity of the message.</param>
        /// <remarks>
        /// Supported log levels are:
        /// <list type="bullet">
        /// <item><description><see cref="LogLevel.NOTICE"/>: Logs informational messages.</description></item>
        /// <item><description><see cref="LogLevel.WARNING"/>: Logs warning messages.</description></item>
        /// <item><description><see cref="LogLevel.ERROR"/>: Logs error messages.</description></item>
        /// </list>
        /// If the application is not running on a Crestron platform, this method does nothing.
        /// </remarks>
        public static void Log(string msg, LogLevel level)
        {
            if (Platform.IsCrestron)
            {
                switch (level)
                {
                    case LogLevel.NOTICE:
                        ErrorLog.Notice(msg);
                        break;
                    case LogLevel.WARNING:
                        ErrorLog.Warn(msg);
                        break;
                    case LogLevel.ERROR:
                        ErrorLog.Error(msg);
                        break;
                }
            }
        }
    }
}
