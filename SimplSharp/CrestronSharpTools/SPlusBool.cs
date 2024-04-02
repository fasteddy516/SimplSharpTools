namespace CrestronSharpTools
{
    /// <summary>
    /// Provides utility methods for working with Simpl+ ushort representations of boolean values.
    /// </summary>
    public static class SPlusBool
    {
        /// <summary>
        /// Represents the Simpl+ ushort boolean value for false.
        /// </summary>
        public const ushort FALSE = 0;

        /// <summary>
        /// Represents the Simpl+ ushort boolean value for true.
        /// </summary>
        public const ushort TRUE = 1;

        /// <summary>
        /// Determines whether the specified Simpl+ ushort boolean value is true.
        /// </summary>
        /// <param name="value">The Simpl+ ushort boolean value to check.</param>
        /// <returns>true if the value is greater than 0; otherwise, false.</returns>
        public static bool IsTrue(ushort value) => (value != FALSE);

        /// <summary>
        /// Determines whether the specified Simpl+ ushort boolean value is false.
        /// </summary>
        /// <param name="value">The Simpl+ ushort boolean value to check.</param>
        /// <returns>true if the value is 0; otherwise, false.</returns>
        public static bool IsFalse(ushort value) => (value == FALSE);

        /// <summary>
        /// Converts a boolean value to the corresponding Simpl+ ushort boolean value.
        /// </summary>
        /// <param name="value">The boolean value to convert.</param>
        /// <returns>The corresponding Simpl+ ushort boolean value.</returns>
        public static ushort FromBool(bool value) => (value) ? TRUE : FALSE;

        /// <summary>
        /// Converts a Simpl+ ushort boolean value to the corresponding boolean value.
        /// </summary>
        /// <param name="value">The Simpl+ ushort boolean value to convert.</param>
        /// <returns>The corresponding boolean value.</returns>
        public static bool ToBool(ushort value) => (value > FALSE) ? true : false;
    }
}