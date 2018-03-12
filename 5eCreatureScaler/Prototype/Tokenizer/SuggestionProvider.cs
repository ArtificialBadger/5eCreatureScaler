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

        public Choice<Suggestion>.Set ProposeSuggestions((string pattern, string before, string token, string after) record, Creature creature)
        {
            return SuggestReplacements((record.before, record.token, record.after), creature)
                .ToChoiceSet()
                .ChooseFirstIfSingle();
        }

        protected abstract IEnumerable<Suggestion> SuggestReplacements((string before, string token, string after) record, Creature creature);
    }
}
