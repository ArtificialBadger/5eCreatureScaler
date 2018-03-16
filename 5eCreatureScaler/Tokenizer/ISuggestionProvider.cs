using CreatureScaler.Platform;

namespace CreatureScaler.Tokenizer
{
    public interface ISuggestionProvider
    {
        string Pattern { get; }
        Choice<Suggestion>.Set ProposeSuggestions(TokenizationContext context);
    }
}
