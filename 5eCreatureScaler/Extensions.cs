using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CreatureScaler
{
    internal static class Extensions
    {
        public static IEnumerable<T> ToSelection<T>(this IEnumerable<SingleSelector<T>.Set> sets)
        {
            return sets.Where(set => set.Accepted && !set.Rejected).Select(set => set.SelectedItem);
        }

        public static SingleSelector<T>.Set ToSingleSelector<T>(this IEnumerable<T> enumerable)
        {
            var set = new SingleSelector<T>.Set(enumerable);
            
            return set;
        }

        public sealed class SingleSelector<T>
        {
            Action<SingleSelector<T>> selectFunc;
            
            private SingleSelector(T item, Action<SingleSelector<T>> selectFunc)
            {
                Item = item;
                this.selectFunc = selectFunc;
            }

            public T Item { get; }

            public void Select()
            {
                selectFunc(this);
            }

            public sealed class Set
            {
                private List<SingleSelector<T>> selections;
                private SingleSelector<T> selected;

                public Set(IEnumerable<T> items)
                {
                    this.selections = items.Select(item => new SingleSelector<T>(item, Select)).ToList();
                }

                public bool Accepted { get; private set; } = false;
                public bool Rejected { get; private set; } = false;

                public IReadOnlyList<SingleSelector<T>> PossibleSelections => selections;
                public T SelectedItem => selected.Item;

                public void Reject()
                {
                    selected = null;
                    Accepted = false;
                    Rejected = true;
                }

                private void Select(SingleSelector<T> selected)
                {
                    this.selected = selected;
                    Accepted = true;
                    Rejected = false;
                }
            }
        }

        internal static IEnumerable<(string pattern, string before, string token, string after)> SplitIncludingValuesBetween(this string text, string[] patterns)
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
