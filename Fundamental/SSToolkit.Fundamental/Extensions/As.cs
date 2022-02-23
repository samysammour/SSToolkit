namespace SSToolkit.Fundamental.Extensions
{
    using System;
    using System.Diagnostics;

    public static partial class Extensions
    {
        /// <summary>
        /// Simplifies casting an object to a type.
        /// </summary>
        /// <typeparam name="T">The type to be casted.</typeparam>
        /// <param name="source">The object to cast.</param>
        /// <returns>Casted object.</returns>
        [DebuggerStepThrough]
        public static T As<T>(this object source)
            where T : class
        {
            if (source == null)
            {
                return default;
            }

            try
            {
                return (T)source;
            }
            catch (InvalidCastException)
            {
                return default;
            }
        }

        /// <summary>
        /// Check type of an object.
        /// </summary>
        /// <typeparam name="T">The type to be checked.</typeparam>
        /// <param name="source">The object to check.</param>
        /// <returns><see langword="true"/> if the object is type of <typeparamref name="T"/>.</returns>
        public static bool Is<T>(this object source)
        {
            if(source == null)
            {
                return false;
            }

            return source is T;
        }
    }
}