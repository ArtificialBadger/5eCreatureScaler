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
                StrengthModifier = CalculateModifier(strength),
                DexterityModifier = CalculateModifier(dexterity),
                ConstitutionModifier = CalculateModifier(constitution),
                IntelligenceModifier = CalculateModifier(intelligence),
                WisdomModifier = CalculateModifier(wisdom),
                CharismaModifier = CalculateModifier(charisma),
            };
        }

        public static int CalculateModifier(int abilityScore)
        {
            return (int)Math.Floor(((abilityScore - 10) / 2f));
        }

        public int StrengthModifier { get; set; }

        public int DexterityModifier { get; set; }

        public int ConstitutionModifier { get; set; }

        public int IntelligenceModifier { get; set; }

        public int WisdomModifier { get; set; }

        public int CharismaModifier { get; set; }

        public int Strength {get; set;}

        public int Dexterity { get; set; }

        public int Constitution { get; set; }

        public int Intelligence { get; set; }

        public int Wisdom { get; set; }

        public int Charisma { get; set; }

    }
}
