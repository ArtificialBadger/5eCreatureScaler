using CreatureScaler.Models;

namespace CreatureScaler.Prototype.Model
{
    public interface IRuleToken
    {
        int DifficultyClass(Creature creature);
        int Attack(Creature creature);
        int Damage(Creature creature);
        string Format(Creature creature);
        TokenContext Context { get; }
    }
}
