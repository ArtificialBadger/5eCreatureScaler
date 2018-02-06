using System;
using System.Collections.Generic;
using System.Linq;

namespace CreatureScaler.Models
{
    public static class AbilityScoreExtensions
    {
        public static AbilityScore ByAbility(this IEnumerable<AbilityScore> scores, AbilityType type)
        {
            return scores.FirstOrDefault(score => score.AbilityType == type);
        }
    }

    public class AbilityScore
    {
        #region creators
        public static List<AbilityScore> CreateStandard(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
        {
            return new List<AbilityScore>
            {
                new AbilityScore { AbilityType = AbilityType.Strength, Value = strength },
                new AbilityScore { AbilityType = AbilityType.Dexterity, Value = dexterity },
                new AbilityScore { AbilityType = AbilityType.Constitution, Value = constitution },
                new AbilityScore { AbilityType = AbilityType.Intelligence, Value = intelligence },
                new AbilityScore { AbilityType = AbilityType.Wisdom, Value = wisdom },
                new AbilityScore { AbilityType = AbilityType.Charisma, Value = charisma },
            };
        }
        #endregion

        public AbilityType AbilityType { get; set; }
        public int Value { get; set; }
        public int Modifier => CalculateModifier(this.Value);
        public static int CalculateModifier(int abilityScore) => (int)Math.Floor(((abilityScore - 10) / 2f));
    }
}
