using CreatureScaler.Platform;
using System.Collections.Generic;
using System.Linq;

namespace CreatureScaler.Tokenization
{
    public sealed class TokenizableRuleText
    {
        internal TokenizableRuleText(IEnumerable<(TokenizationContext context, Choice<Suggestion>.Set choices)> sets)
        {
            this.Sets = sets.ToList();
        }

        public IReadOnlyList<(TokenizationContext context, Choice<Suggestion>.Set choices)> Sets { get; }
        public IReadOnlyList<Choice<Suggestion>.Set> Suggestions => Sets.Select(set => set.choices).ToList();

        public string Format()
        {
            var formattedString = Sets.First().context.Before 
                + Sets.Select(choice => 
                    choice.choices.Accepted && !choice.choices.Rejected 
                    ? choice.choices.SelectedItem.Replacement 
                    : choice.context.Token 
                    + choice.context.After);

            return formattedString;
        }
    }
}
