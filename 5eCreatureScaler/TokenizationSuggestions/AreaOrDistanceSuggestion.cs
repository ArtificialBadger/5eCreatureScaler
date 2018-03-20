using CreatureScaler.Models;
using CreatureScaler.Tokenization;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CreatureScaler.TokeizationSuggestions
{
    public class AreaOrDistanceSuggestion : SuggestionProvider
    {
        // ask if area or distance
        public override string Pattern => @"[0-9]+ feet";

        protected override IEnumerable<Suggestion> SuggestReplacements(TokenizationContext context)
        {
            (string before, string token, string after, Creature creature) = context;
            var area = Regex.Match(token, @"[0-9]+").Value;

            var replacement = $"{{area:{area}}} feet";

            return new Suggestion(token, replacement)
                .ToEnumerable();
        }
    }
}
