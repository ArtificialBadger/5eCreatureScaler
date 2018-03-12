using System;
using System.Collections.Generic;
using System.Linq;

namespace CreatureScaler.Prototype.Model
{
    public static class Extensions
    {
        public static IEnumerable<T> ConcatenateItem<T>(this IEnumerable<T> enumerable, T item)
        {
            return enumerable.Concat(new[] { item });
        }

        public static IEnumerable<T> ToEnumerable<T>(this T item)
        {
            return new[] { item };
        }

        private static double PositiveOperationOrZero<T>(this IEnumerable<T> items, Func<T, int> selector, Func<IEnumerable<int>, double> operation)
        {
            var remaining = items.Select(item => selector(item)).Where(value => value >= 0).ToList();
            if (remaining.Any())
            {
                return operation(remaining);
            }
            else
            {
                return 0;
            }
        }
        public static double PositiveAverageOrZero<T>(this IEnumerable<T> items, Func<T, int> selector) => items.PositiveOperationOrZero(selector, f => f.Average());
        public static double PositiveSumOrZero<T>(this IEnumerable<T> items, Func<T, int> selector) => items.PositiveOperationOrZero(selector, f => f.Sum());
    }
}
