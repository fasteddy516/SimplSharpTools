using Crestron.SimplSharp;
using Independentsoft.Exchange;
using System;

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
        /// This method logs messages to the error log on Crestron platforms or the Console on other platforms.
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
        /// </remarks>
        public static void Log(string msg, LogLevel level)
        {
            switch (level)
            {
                case LogLevel.NOTICE:
                    if (Platform.IsCrestron)
                        ErrorLog.Notice(msg);
                    else
                        Console.WriteLine($"\u001b[{(int)DebugColor.Info}mNOTICE: {msg}\u001b[0m");
                    break;
                case LogLevel.WARNING:
                    if (Platform.IsCrestron)
                        ErrorLog.Warn(msg);
                    else
                        Console.WriteLine($"\u001b[{(int)DebugColor.Warning}mWARNING: {msg}\u001b[0m");
                    break;
                case LogLevel.ERROR:
                    if (Platform.IsCrestron)
                        ErrorLog.Error(msg);
                    else
                        Console.WriteLine($"\u001b[{(int)DebugColor.Error}mERROR: {msg}\u001b[0m");
                    break;
            }
        }
    }
}
