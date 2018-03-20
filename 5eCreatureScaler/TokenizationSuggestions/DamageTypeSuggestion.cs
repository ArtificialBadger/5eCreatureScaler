using CreatureScaler.Models;
using CreatureScaler.Tokenization;
using System.Collections.Generic;

namespace CreatureScaler.TokeizationSuggestions
{
    public class DamageTypeSuggestion : SuggestionProvider
    {
        public override string Pattern => @"(acid|bludgeoning|cold|fire|force|lightning|necrotic|piercing|poison|psychic|radiant|slashing|thunder) damage";
        
        protected override IEnumerable<Suggestion> SuggestReplacements(TokenizationContext context)
        {
            (string before, string token, string after, Creature creature) = context;
            var type = token.Split(' ')[0];

            return new Suggestion(token, $"{{type:{type}}} damage")
                .ToEnumerable();
        }
    }
}
