using Crestron.SimplSharp;
using System;

namespace SimplSharpTools
{
    /// <summary>
    /// Provides information about the platform on which the application is running.
    /// </summary>
    public static class Platform
    {
        /// <summary>
        /// Stores the platform name determined at runtime.
        /// </summary>
        private static string _platform = _getPlatform();

        /// <summary>
        /// Gets the name of the platform on which the application is running.
        /// </summary>
        public static string Name => _platform;

        /// <summary>
        /// Indicates whether the application is running on a Crestron device (Appliance or Virtual).
        /// </summary>
        public static bool IsCrestron => _platform.Contains("Crestron");

        /// <summary>
        /// Indicates whether the application is running on a Crestron Appliance platform.
        /// </summary>
        public static bool IsAppliance => _platform.Contains("Appliance");

        /// <summary>
        /// Indicates whether the application is running on a Crestron Virtual Control platform.
        /// </summary>
        public static bool IsVirtualControl => _platform.Contains("Virtual");

        /// <summary>
        /// Indicates whether the application is running on a non-Crestron platform.
        /// </summary>
        public static bool IsOther => _platform.Contains("Other");

        /// <summary>
        /// Determines the platform on which the application is running.
        /// </summary>
        /// <returns>
        /// A string representing the platform:
        /// - "Crestron Appliance" for Crestron Appliance platforms.
        /// - "Crestron Virtual" for Crestron Virtual Control platforms.
        /// - "Other" for non-Crestron platforms.
        /// </returns>
        private static string _getPlatform()
        {
            try
            {
                eDevicePlatform platform = CrestronEnvironment.DevicePlatform;
                if (platform == eDevicePlatform.Appliance)
                {
                    return "Crestron Appliance";
                }
                else if (platform == eDevicePlatform.Server)
                {
                    return "Crestron Virtual";
                }
                else
                    throw new NotSupportedException();
            }
            catch
            {
                return "Other";
            }
        }
    }
}
