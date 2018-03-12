using CreatureScaler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CreatureScaler.Prototype.Tokenizer
{
    public class DamageRollSuggestion : SuggestionProvider
    {
        public override string Pattern => @"[0-9]+ ?\([0-9]+d[0-9]+( ?\+ ?[0-9]+)?\)";

        protected override IEnumerable<Suggestion> SuggestReplacements((string before, string token, string after) record, Creature creature)
        {
            var tokenText = record.token;

            var matches = Regex.Matches(tokenText, @"[0-9]+").Cast<Match>().Select(f => f.Value).Skip(1);

            var dieCount = matches.First();
            var dieSize = matches.Skip(1).First();
            var bonusString = matches.Skip(2).FirstOrDefault();
            var dieMightBeBasedOnSize = ((int)creature.Size.ToHitDie()).ToString() == dieSize;

            var bonus = default(int);
            if (Int32.TryParse(bonusString, out bonus))
            {
                foreach (var statistic in creature.FindMatchingStatistics(bonus))
                {
                    if (dieMightBeBasedOnSize)
                    {
                        yield return new Suggestion(record.token, $"{{dmg:{dieCount}dS+{statistic}}}");
                        yield return new Suggestion(record.token, $"{{dmg:{dieCount}dS+{bonusString}}}");
                    }

                    yield return new Suggestion(record.token, $"{{dmg:{dieCount}d{dieSize}+{statistic}}}");
                    yield return new Suggestion(record.token, $"{{dmg:{dieCount}d{dieSize}+{bonusString}}}");
                }

                yield return new Suggestion(record.token, $"{{dmg:{dieCount}d{dieSize}+{bonusString}}}");
            }
            else
            {
                if (dieMightBeBasedOnSize)
                {
                    yield return new Suggestion(record.token, $"{{dmg:{dieCount}dS}}");
                }

                yield return new Suggestion(record.token, $"{{dmg:{dieCount}d{dieSize}}}");
            }
        }
    }
}
