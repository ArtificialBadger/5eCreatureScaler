using CreatureScaler.Models;
using CreatureScaler.Platform;

namespace CreatureScaler.Prototype.Tokenizer
{
    public interface ISuggestionProvider
    {
        string Pattern { get; }
        Choice<Suggestion>.Set ProposeSuggestions((string pattern, string before, string token, string after) record, Creature creature);
    }
}
