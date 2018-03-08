using System;
using System.Collections.Generic;
using System.Linq;

namespace CreatureScaler.Models
{
    public static class AbilityScoreExtensions
    {
        public static AbilityScore ByAbility(this IEnumerable<AbilityScore> scores, Ability ability)
        {
            return scores.FirstOrDefault(score => score.Ability == ability);
        }
    }

    public sealed class AbilityScore
    {
        #region creators
        public static List<AbilityScore> CreateStandard(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
        {
            return new List<AbilityScore>
            {
                new AbilityScore { Ability = Ability.Strength, Value = strength },
                new AbilityScore { Ability = Ability.Dexterity, Value = dexterity },
                new AbilityScore { Ability = Ability.Constitution, Value = constitution },
                new AbilityScore { Ability = Ability.Intelligence, Value = intelligence },
                new AbilityScore { Ability = Ability.Wisdom, Value = wisdom },
                new AbilityScore { Ability = Ability.Charisma, Value = charisma },
            };
        }
        #endregion

        public Ability Ability { get; set; }
        public int Value { get; set; }
        public int Modifier => CalculateModifier(this.Value);
        public static int CalculateModifier(int abilityScore) => (int)Math.Floor(((abilityScore - 10) / 2f));
    }
}
