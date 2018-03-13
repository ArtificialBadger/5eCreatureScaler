using CreatureScaler.Models;
using CreatureScaler.Prototype.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CreatureScaler.Prototype.Tokenizer
{
    public class AreaSuggestion : SuggestionProvider
    {
        public override string Pattern => @"[0-9]+ ?- ?foot";

        protected override IEnumerable<Suggestion> SuggestReplacements(TokenizationContext context)
        {
            (string before, string token, string after, Creature creature) = context;
            var area = Regex.Match(token, @"[0-9]+");

            var remainder = Regex.Split(token, @"[0-9]+").Last();

            var replacement = $"{{area:{area}}}{remainder}";

            return new Suggestion(token, replacement)
                .ToEnumerable();
        }
    }
}
