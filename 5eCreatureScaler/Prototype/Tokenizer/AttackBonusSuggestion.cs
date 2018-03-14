using CreatureScaler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CreatureScaler.Prototype.Tokenizer
{
    public class AttackBonusSuggestion : SuggestionProvider
    {
        public override string Pattern => @"\+[0-9]+ to hit";

        protected override IEnumerable<Suggestion> SuggestReplacements(TokenizationContext context)
        {
            (string before, string token, string after, Prototype.Model.Creature creature) = context;
            var bonus = Convert.ToInt32(Regex.Match(token, @"[0-9]+"));

            var output = creature.FindMatchingStatisticsWithProficiency(bonus);

            return output
                .Select(o => (combo: o, modString: o.ToModString()))
                .Where(o => !string.IsNullOrWhiteSpace(o.modString))
                .Select(o => (combo: o.combo, value: o.modString == default(string) ? token : $"{{attack:{o.modString}}} to hit"))
                .Select(o => new Suggestion(token, o.value))
                .Concat(new[] { new Suggestion(token, $"{{attack:{bonus}}} to hit") });
        }
    }
}