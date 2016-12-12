using System;
using System.Collections.Generic;

using JetBrains.Annotations;

namespace Hangfire.MetaExtensions
{
    internal class ThreadStorage<T>
    {
        [ThreadStatic] private static IList<T> _values;

        [NotNull, ItemNotNull]
        public static IList<T> Collection => _values = _values ?? new List<T>();

        public static void Add([NotNull] T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Collection.Add(value);
        }
    }
}