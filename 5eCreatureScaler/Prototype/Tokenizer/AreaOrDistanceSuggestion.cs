using CreatureScaler.Models;
using CreatureScaler.Prototype.Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CreatureScaler.Prototype.Tokenizer
{
    public class AreaOrDistanceSuggestion : SuggestionProvider
    {
        // ask if area or distance
        public override string Pattern => @"[0-9]+ feet";

        protected override IEnumerable<Suggestion> SuggestReplacements((string before, string token, string after) record, Creature creature)
        {
            var tokenText = record.token;
            var area = Regex.Match(tokenText, @"[0-9]+").Value;

            var replacement = $"{{area:{area}}} feet";

            return new Suggestion(record.token, replacement)
                .ToEnumerable();
        }
    }
}
