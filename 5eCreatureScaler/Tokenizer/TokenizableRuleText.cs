using CreatureScaler.Platform;
using System.Collections.Generic;
using System.Linq;

namespace CreatureScaler.Tokenizer
{
    public sealed class TokenizableRuleText
    {
        private readonly IEnumerable<(TokenizationContext context, Choice<Suggestion>.Set choices)> choices;

        internal TokenizableRuleText(IEnumerable<(TokenizationContext context, Choice<Suggestion>.Set choices)> choices)
        {
            this.choices = choices;
        }

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
