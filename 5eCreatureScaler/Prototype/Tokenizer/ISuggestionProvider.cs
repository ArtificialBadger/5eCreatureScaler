using CreatureScaler.Models;
using CreatureScaler.Platform;
using System.Collections.Generic;

namespace CreatureScaler.Prototype.Tokenizer
{
    public interface ISuggestionProvider
    {
        string Pattern { get; }
        IEnumerable<Choice<Suggestion>.Set> ProposeSuggestions(string ruleText, Creature creature);
    }
}
