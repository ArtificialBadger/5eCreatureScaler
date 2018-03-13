using CreatureScaler.Models;
using CreatureScaler.Platform;
using System.Collections.Generic;
using System.Linq;

namespace CreatureScaler.Prototype.Tokenizer
{
    public class Tokenizer
    {
        private readonly string name;
        private readonly string ruleText;
        private readonly Creature creature;
        private readonly IEnumerable<(TokenizationContext context, Choice<Suggestion>.Set choices)> choices;

        public Tokenizer(string name, string ruleText, Creature creature)
        {
            this.creature = creature;
            this.name = name;
            this.ruleText = ruleText;
            this.choices = ExtractTokens(ruleText).ToList();
        }

        private IEnumerable<(TokenizationContext context, Choice<Suggestion>.Set choices)> ExtractTokens(string ruleText)
        {
            var grouper = new Grouper();

            var matchRecords = ruleText
                .SplitIncludingValuesBetween(rulePatterns.Select(r => r.Key))
                .Select((f, i) => new TokenizationContext(grouper, i, f.pattern, f.before, f.token, f.after, creature))
                .Select(f => (f, rulePatterns[f.Pattern].ProposeSuggestions(f)));

            return matchRecords;
        }

        private static IReadOnlyDictionary<string, ISuggestionProvider> rulePatterns = new ISuggestionProvider[]
        {
            new AttackBonusSuggestion(),
            new ReachSuggestion(),
            new DamageRollSuggestion(),
            new DCSuggestion(),
            new AreaOrDistanceSuggestion(),
            new AreaSuggestion(),
            new DamageTypeSuggestion(),
        }.ToDictionary(f => f.Pattern);

        public IEnumerable<Choice<Suggestion>.Set> Choices => choices.Select(f => f.choices);

        public string Format()
        {
            var formattedString = choices.First().context.Before 
                + choices.Select(choice => 
                    choice.choices.Accepted && !choice.choices.Rejected 
                    ? choice.choices.SelectedItem.Replacement 
                    : choice.context.Token 
                    + choice.context.After);

            return formattedString;
        }
    }
}
