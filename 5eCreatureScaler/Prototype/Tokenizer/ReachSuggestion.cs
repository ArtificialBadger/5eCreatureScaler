using CreatureScaler.Models;
using CreatureScaler.Prototype.Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CreatureScaler.Prototype.Tokenizer
{
    public class ReachSuggestion : SuggestionProvider
    {
        public override string Pattern => @"reach [0-9]+ ft";
        
        protected override IEnumerable<Suggestion> SuggestReplacements((string before, string token, string after) record, Creature creature)
        {
            var tokenText = record.token;
            var value = Regex.Match(tokenText, @"[0-9]+").Value;

            return new Suggestion(record.token, $"reach {{reach:{value}}} ft")
                .ToEnumerable();
        }
    }
}
