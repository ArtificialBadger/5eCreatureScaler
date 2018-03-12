using CreatureScaler.Models;
using CreatureScaler.Platform;
using CreatureScaler.Prototype.Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CreatureScaler.Prototype.Tokenizer
{
    public class ReachSuggestion : SuggestionProvider
    {
        public override string Pattern => @"reach [0-9]+ ft";
        
        protected override IEnumerable<Suggestion> SuggestReplacements(Match match, Creature creature)
        {
            var tokenText = match.Value;
            var value = Regex.Match(tokenText, @"[0-9]+").Value;

            return match
                .ToSuggestion(Pattern, $"reach {{reach:{value}}} ft")
                .ToEnumerable();
        }
    }
}
