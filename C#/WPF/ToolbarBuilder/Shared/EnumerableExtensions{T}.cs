using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Shared
{
    /// <summary>
    /// Extension methods for <see cref="IEnumerable{T}"/> object.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Creates an array from a <see cref="IEnumerable{T}"/>. If the sequence is <c>null</c>, creates an empty array.
        /// </summary>
        /// <typeparam name="TSource">The type of the source enumerable.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to create an array from.</param>
        /// <returns>An array that contains the elements from the input sequence, if the <c>source</c> is not <c>null</c>. Otherwise; An empty array, <c>Array.Empty()</c>.</returns>
        [DebuggerStepThrough]
        public static TSource[] ToSafeArray<TSource>(this IEnumerable<TSource> source)
        {
            if (source is null)
            {
                return Array.Empty<TSource>();
            }

            return source.ToArray();
        }
    }
}
