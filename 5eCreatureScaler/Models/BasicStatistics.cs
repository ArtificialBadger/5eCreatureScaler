using System;

namespace CreatureScaler.Models
{
    public class BasicStatistics
    {
        public static BasicStatistics Create(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
        {
            return new BasicStatistics()
            {
                Strength = strength,
                Dexterity = dexterity,
                Constitution = constitution,
                Intelligence = intelligence,
                Wisdom = wisdom,
                Charisma = charisma,
            };
        }

        public static int CalculateModifier(int abilityScore)
        {
            return (int)Math.Floor(((abilityScore - 10) / 2f));
        }

        public int Strength { get; set; }

        public int Dexterity { get; set; }

        public int Constitution { get; set; }

        public int Intelligence { get; set; }

        public int Wisdom { get; set; }

        public int Charisma { get; set; }

        public int Score(AbilityScore abilityScore)
        {
            switch (abilityScore)
            {
                case AbilityScore.Strength:
                    return this.Strength;
                case AbilityScore.Dexterity:
                    return this.Dexterity;
                case AbilityScore.Constitution:
                    return this.Constitution;
                case AbilityScore.Intelligence:
                    return this.Intelligence;
                case AbilityScore.Wisdom:
                    return this.Wisdom;
                case AbilityScore.Charisma:
                    return this.Charisma;
                default:
                    throw new ArgumentException(nameof(abilityScore));
            }
        }

        public int Modifier(AbilityScore abilityScore)
        {
            return CalculateModifier(Score(abilityScore));
        }
    }
}
