using CreatureScaler.Platform;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CreatureScaler.Tokenization
{
    public abstract class SuggestionProvider : ISuggestionProvider
    {
        public abstract string Pattern { get; }

        public Choice<Suggestion>.Set ProposeSuggestions(TokenizationContext context)
        {
            return SuggestReplacements(context)
                .ToChoiceSet()
                .ChooseFirstIfSingle();
        }

        protected abstract IEnumerable<Suggestion> SuggestReplacements(TokenizationContext context);
    }
}
