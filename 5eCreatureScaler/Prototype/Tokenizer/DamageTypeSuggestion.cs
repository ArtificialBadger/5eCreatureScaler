using CreatureScaler.Models;
using CreatureScaler.Prototype.Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CreatureScaler.Prototype.Tokenizer
{
    public class DamageTypeSuggestion : SuggestionProvider
    {
        public override string Pattern => @"(acid|bludgeoning|cold|fire|force|lightning|necrotic|piercing|poison|psychic|radiant|slashing|thunder) damage";
        
        protected override IEnumerable<Suggestion> SuggestReplacements((string before, string token, string after) record, Creature creature)
        {
            var tokenText = record.token;
            var type = tokenText.Split(' ')[0];

            return new Suggestion(record.token, $"{{type:{type}}} damage")
                .ToEnumerable();
        }
    }
}
