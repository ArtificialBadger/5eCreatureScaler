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

        protected override IEnumerable<Suggestion> SuggestReplacements((string before, string token, string after) record, Creature creature)
        {
            var tokenText = record.token;
            var bonus = Convert.ToInt32(Regex.Match(tokenText, @"[0-9]+"));

            var output = creature.FindMatchingStatisticsWithProficiency(bonus);

            return output
                .Select(o => (combo: o, modString: o.ToModString()))
                .Where(o => !string.IsNullOrWhiteSpace(o.modString))
                .Select(o => (combo: o.combo, value: o.modString == default(string) ? tokenText : $"{{attack:{o.modString}}} to hit"))
                .Select(o => new Suggestion(record.token, o.value))
                .Concat(new[] { new Suggestion(record.token, $"{{attack:{bonus}}} to hit") });
        }
    }
}