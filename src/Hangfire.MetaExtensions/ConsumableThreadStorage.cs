using System;
using System.Collections.Generic;
using System.Linq;

using JetBrains.Annotations;

namespace Hangfire.MetaExtensions
{
    internal static class ConsumableThreadStorage<T>
    {
        [ThreadStatic] private static IList<T> _values;

        [NotNull, ItemNotNull]
        private static IList<T> Collection => _values = _values ?? new List<T>();

        public static void Add([NotNull] T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Collection.Add(value);
        }

        public static IList<T> GetAllAndClear()
        {
            var values = Collection.ToList();
            Collection.Clear();
            return values;
        }
    }
}