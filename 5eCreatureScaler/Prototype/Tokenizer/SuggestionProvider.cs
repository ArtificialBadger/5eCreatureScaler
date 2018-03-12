using CreatureScaler.Models;
using CreatureScaler.Platform;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CreatureScaler.Prototype.Tokenizer
{
    public abstract class SuggestionProvider : ISuggestionProvider
    {
        public abstract string Pattern { get; }

        public IEnumerable<Choice<Suggestion>.Set> ProposeSuggestions(string ruleText, Creature creature)
        {
            var matches = Regex.Matches(ruleText, Pattern);

            var suggestions = Enumerable.Empty<Suggestion>();

            foreach (var match in matches.Cast<Match>())
            {
                suggestions = suggestions.Concat(SuggestReplacements(match, creature));
            }

            return suggestions
                .GroupBy(f => f.Index)
                .Select(f => f
                    .ToChoiceSet()
                    .ChooseFirstIfSingle());
        }

        protected abstract IEnumerable<Suggestion> SuggestReplacements(Match match, Creature creature);
    }
}
