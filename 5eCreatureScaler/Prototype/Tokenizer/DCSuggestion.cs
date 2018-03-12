using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CreatureScaler.Models;
using CreatureScaler.Platform;
using CreatureScaler.Prototype.Model;

namespace CreatureScaler.Prototype.Tokenizer
{
    public class DCSuggestion : SuggestionProvider
    {
        public override string Pattern => @"DC [0-9]+";
        
        protected override IEnumerable<Suggestion> SuggestReplacements((string before, string token, string after) record, Creature creature)
        {
            var tokenText = record.token;
            var bonus = Convert.ToInt32(Regex.Match(tokenText, @"[0-9]+"));

            var output = creature.FindMatchingStatisticsWithProficiency(bonus);
            
            return output
                .Select(o => (combo: o, modString: o.ToModString()))
                .Where(o => !string.IsNullOrWhiteSpace(o.modString))
                .Select(o => (combo: o.combo, value: o.modString == default(string) ? tokenText : $"DC {{dc:{o.modString}}}"))
                .Select(o => o.value)
                .ConcatenateItem($"DC {{dc:{bonus}}} to hit")
                .Select(o => new Suggestion(record.token, o));
        }
    }
}
