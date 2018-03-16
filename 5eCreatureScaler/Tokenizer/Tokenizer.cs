using CreatureScaler.Models;
using System.Collections.Generic;
using System.Linq;

namespace CreatureScaler.Tokenizer
{
    public class Tokenizer : ITokenizer
    {
        private readonly IReadOnlyDictionary<string, ISuggestionProvider> rulePatterns;

        public Tokenizer(IEnumerable<ISuggestionProvider> suggestionProviders)
        {
            this.rulePatterns = suggestionProviders.ToDictionary(f => f.Pattern);
        }

        public TokenizableRuleText Tokenize(string name, string ruleText, Creature creature)
        {
            var grouper = new Grouper();

            var matchRecords = ruleText
                .SplitIncludingValuesBetween(rulePatterns.Select(r => r.Key))
                .Select((f, i) => new TokenizationContext(grouper, i, f.pattern, f.before, f.token, f.after, creature))
                .Select(f => (f, rulePatterns[f.Pattern].ProposeSuggestions(f)));

            return new TokenizableRuleText(matchRecords);
        }
    }
}
