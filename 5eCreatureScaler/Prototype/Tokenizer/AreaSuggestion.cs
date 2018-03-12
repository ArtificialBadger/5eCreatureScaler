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

        protected override IEnumerable<Suggestion> SuggestReplacements((string before, string token, string after) record, Creature creature)
        {
            var tokenText = record.token;
            var area = Regex.Match(tokenText, @"[0-9]+");

            var remainder = Regex.Split(tokenText, @"[0-9]+").Last();

            var replacement = $"{{area:{area}}}{remainder}";

            return new Suggestion(record.token, replacement)
                .ToEnumerable();
        }
    }
}
