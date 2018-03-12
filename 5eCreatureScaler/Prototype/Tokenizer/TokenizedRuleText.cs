using CreatureScaler.Models;
using CreatureScaler.Platform;
using System.Collections.Generic;
using System.Linq;

namespace CreatureScaler.Prototype.Tokenizer
{
    public class TokenizedRuleText
    {
        private string name;
        private string ruleText;
        private Creature creature;

        public TokenizedRuleText(string name, string ruleText, Creature creature)
        {
            this.creature = creature;
            this.name = name;
            this.ruleText = ruleText;

            Choices = ExtractTokens(ruleText).ToList();
        }

        private IEnumerable<Choice<Suggestion>.Set> ExtractTokens(string ruleText)
        {
            var choices = rulePatterns
                .SelectMany(r => r.ProposeSuggestions(ruleText, creature))
                .ToList();

            return choices;
        }

        private static IEnumerable<ISuggestionProvider> rulePatterns = new ISuggestionProvider[]
        {
            new AttackBonusSuggestion(),
            new ReachSuggestion(),
            new DamageRollSuggestion(),
            new DCSuggestion(),
            new AreaOrDistanceSuggestion(),
            new AreaSuggestion(),
            new DamageTypeSuggestion(),
        };

        public IEnumerable<Choice<Suggestion>.Set> Choices { get; }

        //public string Format()
        //{
        //    var newText = this.ruleText;

        //    foreach (var token in Choices.Where(token => token.Accepted))
        //    {
        //        var tokenized = token.Format(creature);

        //        if (token.TokenText != tokenized)
        //        {
        //            newText = newText.Replace(token.TokenText, token.Format(creature));
        //        }
        //    }

        //    return newText;
        //}
    }
}
