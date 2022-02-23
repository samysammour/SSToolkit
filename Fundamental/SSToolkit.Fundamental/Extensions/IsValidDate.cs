namespace SSToolkit.Fundamental.Extensions
{
    using System;
    using System.Collections.Generic;

    public static partial class Extensions
    {
        /// <summary>
        /// Validate a string to be a valid date
        /// </summary>
        /// <param name="source">the source string date</param>
        /// <returns></returns>
        public static bool IsValidDate(this string source)
            => DateTime.TryParse(source, out _);
    }
}
