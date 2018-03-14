using CreatureScaler.Prototype.Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CreatureScaler.Prototype.Tokenizer
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
