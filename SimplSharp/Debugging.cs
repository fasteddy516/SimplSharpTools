using Crestron.SimplSharp;
using System;

namespace SimplSharpTools
{
    /// <summary>
    /// Provides predefined ANSI color codes for use in debugging output.
    /// </summary>
    /// <remarks>
    /// The colors are intended to represent specific types of debug messages, such as 
    /// transmissions, receptions, errors, and informational messages, to improve readability 
    /// and clarity in terminal output.
    /// </remarks>
    public static class DebugColor
    {
        public const ANSIColor TX = ANSIColor.BrightYellow;
        public const ANSIColor RX = ANSIColor.BrightCyan;
        public const ANSIColor Error = ANSIColor.Red;
        public const ANSIColor Start = ANSIColor.Green;
        public const ANSIColor Stop = ANSIColor.Magenta;
        public const ANSIColor Info = ANSIColor.BrightWhite;
        public const ANSIColor Warning = ANSIColor.BrightYellow;
    }


    /// <summary>
    /// Provides a flexible debugging utility for outputting messages to the console or Crestron console.
    /// </summary>
    /// <remarks>
    /// The <see cref="ConsoleDebugger"/> class supports features such as enabling or disabling debugging, 
    /// using ANSI colors for message formatting, including timestamps, and adding custom identifiers to messages.
    /// It automatically adapts to the platform, using the Crestron console on Crestron devices or the standard console otherwise.
    /// </remarks>
    public class ConsoleDebugger
    {
        private Action<string> _output = null;

        private bool _enable = false;
        private ushort _programSlot = 0;
        private ushort _moduleId = 0;
        private string _moduleName = "DBG";

        /// <summary>
        /// Gets or sets the program slot associated with the module.
        /// </summary>
        /// <remarks>Once the program slot is set, it cannot be changed. Attempting to set the value again
        /// will result in an error. A value of 0 or a value exceeding <see cref="Platform.MaxProgramSlots"/> is
        /// considered invalid and will not be accepted.</remarks>
        public ushort ProgramSlot
        {
            get { return _programSlot; }
            set
            {
                if (_programSlot == value) return;
                if (_programSlot > 0)
                {
                    Print($"! ProgramSlot already set to {_programSlot}, cannot change to {value}", DebugColor.Error);
                    return;
                }
                else if (value == 0 || value > Platform.MaxProgramSlots)
                {
                    Print($"! Requested ProgramSlot ({value}) is out of range (1-{Platform.MaxProgramSlots})", DebugColor.Error);
                    return;
                }
                _programSlot = value;
                Print($"@ ProgramSlot set to {_programSlot}", DebugColor.Info);
            }
        }
        
        /// <summary>
        /// Gets or sets the unique identifier for the module.
        /// </summary>
        public ushort ModuleID
        {
            get { return _moduleId; }
            set
            {
                if (_moduleId == value) return;
                _moduleId = value;
                Print($"@ ModuleID set to {_moduleId}", DebugColor.Info);
            }
        }

        /// <summary>
        /// Gets or sets the name of the module.
        /// </summary>
        public string ModuleName
        {
            get { return _moduleName; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (_moduleName == value) return;
                    _moduleName = value.Substring(0,3).ToUpper();
                    Print($"@ ModuleName set to '{_moduleName}'", DebugColor.Info);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether debugging is enabled.
        /// </summary>
        /// <remarks>
        /// When enabled, messages are output to the console or Crestron console, depending on the platform.
        /// </remarks>
        public bool Enable
        {
            get
            {
                return _enable;
            }
            set
            {
                if (value)
                {
                    if (Platform.IsCrestron)
                    {
                        _output = CrestronConsole.PrintLine;
                    }
                    else
                    {
                        _output = Console.WriteLine;
                    }
                    _enable = true;
                    Print($"+ Debugging ENABLED, platform = {Platform.Name}", DebugColor.Start);
                }
                else
                {
                    if (_enable && _output != null)
                        Print("- Debugging DISABLED", DebugColor.Stop);
                    _enable = false;
                    _output = null;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether ANSI colors should be used in the output.
        /// </summary>
        public bool UseColor { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether timestamps should be included in the output.
        /// </summary>
        public bool IncludeTimestamp { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether a custom identifier should be included in the output.
        /// </summary>
        public bool IncludeID { get; set; } = true;

        /// <summary>
        /// Gets the custom identifier for this debugger instance to include in the output.
        /// </summary>
        public string ID => $"{ModuleName}-{ProgramSlot:D2}:{ModuleID:D2}";

        /// <summary>
        /// Outputs a debug message to the console or Crestron console.
        /// </summary>
        /// <param name="msg">The message to output.</param>
        /// <param name="color">The ANSI color to use
        public void Print(string msg, ANSIColor color = ANSIColor.None)
        {
            if (_enable)
            {
                const string reset = "\u001b[0m";

                string device = (IncludeID) ? $"({ID}) " : "";
                string timestamp = (IncludeTimestamp) ? $"{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")} " : "";

                if (UseColor)
                {
                    string msgcolor = (color == ANSIColor.None) ? $"\u001b[97m" : $"\u001b[{(int)color}m";
                    _output($"\u001b[90m{timestamp}{device}{msgcolor}{msg}{reset}");
                }
                else
                {
                    _output($"{timestamp}{device}{msg}");
                }
            }
        }

        /// <summary>
        /// Configures debugging options using ushort values for compatibility with SIMPL+.
        /// </summary>
        /// <param name="time">A value indicating whether to include timestamps.</param>
        /// <param name="id">A value indicating whether to include a custom identifier.</param>
        /// <param name="color">A value indicating whether to use ANSI colors.</param>
        public void SetOptions(ushort time, ushort id, ushort color)
        {
            IncludeTimestamp = SPlusBool.IsTrue(time);
            IncludeID = SPlusBool.IsTrue(id);
            UseColor = SPlusBool.IsTrue(color);
        }
    }
}
