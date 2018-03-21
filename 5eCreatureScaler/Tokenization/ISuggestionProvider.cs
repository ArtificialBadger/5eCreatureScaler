using CreatureScaler.Platform;

namespace CreatureScaler.Tokenization
{
    public interface ISuggestionProvider
    {
        string Pattern { get; }
        Choice<Suggestion>.Set ProposeSuggestions(TokenizationContext context);
    }
}
