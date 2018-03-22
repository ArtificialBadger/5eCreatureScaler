using CreatureScaler.Models;

namespace CreatureScaler.Rules
{
    public interface IRuleToken
    {
        string Format(Creature creature);

        TokenContext Context { get; }

        string TokenText { get; }
    }
}
