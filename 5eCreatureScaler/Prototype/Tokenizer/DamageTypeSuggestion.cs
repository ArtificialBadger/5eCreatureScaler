using CreatureScaler.Models;
using CreatureScaler.Prototype.Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CreatureScaler.Prototype.Tokenizer
{
    public class DamageTypeSuggestion : SuggestionProvider
    {
        public override string Pattern => @"(acid|bludgeoning|cold|fire|force|lightning|necrotic|piercing|poison|psychic|radiant|slashing|thunder) damage";
        
        protected override IEnumerable<Suggestion> SuggestReplacements(Match match, Creature creature)
        {
            var tokenText = match.Value;
            var type = tokenText.Split(' ')[0];

            return new Suggestion(match.Index, match.Value, Pattern, $"{{type:{type}}} damage")
                .ToEnumerable();
        }
    }
}
