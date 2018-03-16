using CreatureScaler.Models;
using CreatureScaler.Tokenizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CreatureScaler.TokeizationSuggestions
{
    public class DamageRollSuggestion : SuggestionProvider
    {
        public override string Pattern => @"[0-9]+ ?\([0-9]+d[0-9]+( ?\+ ?[0-9]+)?\)";

        protected override IEnumerable<Suggestion> SuggestReplacements(TokenizationContext context)
        {
            (string before, string token, string after, Creature creature) = context;

            var matches = Regex.Matches(token, @"[0-9]+").Cast<Match>().Select(f => f.Value).Skip(1);

            var dieCount = matches.First();
            var dieSize = matches.Skip(1).First();
            var bonusString = matches.Skip(2).FirstOrDefault();
            var suggestSeparateGroup = context.Before.Contains(" or ");

            var baseString = $"{dieCount}d{dieSize}";

            var modifierStrings = new List<string> ();

            var bonus = default(int);
            if (Int32.TryParse(bonusString, out bonus))
            {
                modifierStrings.Add($"+{bonusString}");

                foreach (var statistic in creature.FindMatchingStatistics(bonus))
                {
                    modifierStrings.Add(statistic);
                }
            }

            if (suggestSeparateGroup)
            {
                context.Grouper.CreateNextGroup();
                modifierStrings.AddRange(modifierStrings.Select(f => $"{f}:{context.Grouper.Current}").ToList());
            }

            return modifierStrings.Select(f => new Suggestion(token, $"{{dmg:{f}}}"));
        }
    }
}
