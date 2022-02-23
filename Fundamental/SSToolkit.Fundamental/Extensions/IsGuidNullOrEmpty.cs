namespace SSToolkit.Fundamental.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static partial class Extensions
    {
        /// <summary>
        /// Check if Guid is null or empty
        /// </summary>
        /// <param name="source">the original guid</param >
        /// <returns>true when Guid null or empty</returns>
        public static bool IsGuidNullOrEmpty(this Guid source)
        {
            return source == null || source == Guid.Empty;
        }

        /// <summary>
        /// Check if Guid is null or empty
        /// </summary>
        /// <param name="source">the original guid</param >
        /// <returns>true when Guid null or empty</returns>
        public static bool IsGuidNullOrEmpty(this Guid? source)
        {
            return source.HasValue ? source.Value.IsGuidNullOrEmpty() : true;
        }
    }
}
