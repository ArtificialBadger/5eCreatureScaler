using CreatureScaler.Platform;
using CreatureScaler.Tokenization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CreatureScaler
{
    public static class Extensions
    {
        public static bool Has(this string containerString, string containedString)
        {
            return containerString.IndexOf(containedString, StringComparison.OrdinalIgnoreCase) >= 0;
        }
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
        public static IEnumerable<T> ToChosen<T>(this IEnumerable<Choice<T>.Set> sets)
        {
            return sets.Where(set => set.Accepted && !set.Rejected).Select(set => set.SelectedItem);
        }

        public static Choice<T>.Set ChooseFirstIfSingle<T>(this Choice<T>.Set selector)
        {
            if (selector.Choices.Count() == 1)
            {
                selector.Choices.Single().Choose();
            }

            return selector;
        }

        public static Choice<T>.Set ToChoiceSet<T>(this IEnumerable<T> enumerable)
        {
            var set = new Choice<T>.Set(enumerable);
            
            return set;
        }

        internal static IEnumerable<(string pattern, string before, string token, string after)> SplitIncludingValuesBetween(this string text, IEnumerable<string> patterns)
        {
            var workingString = text;

            var matchSets = patterns
                .SelectMany(pattern => Regex
                    .Matches(text, pattern)
                    .Cast<Match>()
                    .Select(match => (pattern: pattern, value: match.Value, index: match.Index)))
                .OrderBy(matchInfo => matchInfo.index)
                .ToArray();

            for (var i = 0; i < matchSets.Length; i++)
            {
                var matchSet = matchSets[i];
                var after = string.Empty;
                var before = string.Empty;

                var index = workingString.IndexOf(matchSet.value);

                if (index >= 0)
                {
                    before = workingString.Substring(0, index);

                    var target = index + matchSet.value.Length;

                    workingString = workingString.Substring(target, workingString.Length - target);
                }

                if (i + 1 < matchSets.Length)
                {
                    var next = matchSets[i + 1];

                    var nextIndex = workingString.IndexOf(next.value);

                    if (nextIndex >= 0)
                    {
                        after = workingString.Substring(0, nextIndex);
                    }
                }
                else
                {
                    after = workingString;
                }

                yield return (matchSet.pattern, before, matchSet.value, after);
            }
        }
    }
}
