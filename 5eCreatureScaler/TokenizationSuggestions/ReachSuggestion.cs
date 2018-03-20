using CreatureScaler.Models;
using CreatureScaler.Tokenization;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CreatureScaler.TokeizationSuggestions
{
    public class ReachSuggestion : SuggestionProvider
    {
        public override string Pattern => @"reach [0-9]+ ft";
        
        protected override IEnumerable<Suggestion> SuggestReplacements(TokenizationContext context)
        {
            (string before, string token, string after, Creature creature) = context;
            var value = Regex.Match(token, @"[0-9]+").Value;

            return new Suggestion(token, $"reach {{reach:{value}}} ft")
                .ToEnumerable();
        }
    }
}
