namespace CreatureScaler.Prototype.Model
{
    public interface IRuleToken
    {
        int Attack(Creature creature);

        int DifficultyClass(Creature creature);

        int Damage(Creature creature);

        string Format(Creature creature);

        TokenContext Context { get; }

        string TokenText { get; }
    }
}
