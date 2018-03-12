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
        private readonly IEnumerable<(int index, (string pattern, string before, string token, string after) record, Choice<Suggestion>.Set choices)> choices;

        public Tokenizer(string name, string ruleText, Creature creature)
        {
            this.creature = creature;
            this.name = name;
            this.ruleText = ruleText;
            this.choices = ExtractTokens(ruleText).ToList();
        }

        private IEnumerable<(int index, (string pattern, string before, string token, string after) record, Choice<Suggestion>.Set choices)> ExtractTokens(string ruleText)
        {
            var matchRecords = ruleText
                .SplitIncludingValuesBetween(rulePatterns.Select(r => r.Key))
                .Select((f, i) => (i, f, rulePatterns[f.pattern].ProposeSuggestions(f, creature)));

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
            var formattedString = choices.First().record.before 
                + choices.Select(choice => 
                    choice.choices.Accepted && !choice.choices.Rejected 
                    ? choice.choices.SelectedItem.Replacement 
                    : choice.record.token 
                    + choice.record.after);

            return formattedString;
        }
    }
}
