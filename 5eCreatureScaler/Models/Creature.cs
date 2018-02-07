using System;
using System.Collections.Generic;

namespace CreatureScaler.Models
{
    public sealed class Creature
    {
        private static int CalculateHitPoints(Size size, List<AbilityScore> statistics, int hitDieCount)
        {
            return (int)(
                Math.Floor(hitDieCount * size.ToHitDie().ToHitPointPerLevel())
                + 
                hitDieCount * statistics.ByAbility(Ability.Constitution)?.Modifier ?? 0
                );
        }

        public static Creature Create(String name, Size size, ChallengeRating challengeRating, int armorClass, List<AbilityScore> abilityScores, int hitDieCount)
        {
            return new Creature()
            {
                Name = name,
                ProficiencyBonus = challengeRating.ToProficiencyBonus(),
                ArmorClass = armorClass,
                Size = size,
                HitDieSize = size.ToHitDie(),
                ChallengeRating = challengeRating,
                Statistics = abilityScores,
                HitDie = hitDieCount,
                HitPointMaximum = CalculateHitPoints(size, abilityScores, hitDieCount),
            };
        }

        public int ProficiencyBonus { get; set; }

        #region header
        public String Name { get; set; }
        public Size Size { get; set; }
        public CreatureType Type { get; set; }
        public List<SubType> SubTypes { get; set; } = new List<SubType>();
        public Alignment Alignment { get; set; }
        #endregion

        #region general stats
        public int ArmorClass { get; set; }
        public int HitPointMaximum { get; set; }
        public int HitDie { get; set; }
        public Die HitDieSize { get; set; }
        public List<Speed> Speeds { get; set; } = new List<Speed>();
        #endregion

        #region abilities
        public List<AbilityScore> Statistics { get; set; } = new List<AbilityScore>();
        #endregion

        #region statistics
        public List<Ability> SavingThrowProficiencies { get; set; }
        public List<Skill> SkillProficiencies { get; set; } = new List<Skill>();
        public List<DamageType> DamageResistances { get; set; } = new List<DamageType>();
        public List<DamageType> DamageImmunities { get; set; } = new List<DamageType>();
        public List<Condition> ConditionImmunities { get; set; } = new List<Condition>();
        public List<Sense> Senses { get; set; } = new List<Sense>();
        public List<Language> Languages { get; set; } = new List<Language>();
        public ChallengeRating ChallengeRating { get; set; }
        #endregion

        #region monster features
        public List<Feature> Features { get; set; } = new List<Feature>();
        #endregion

        #region actions
        public List<Models.Action> Actions { get; set; } = new List<Models.Action>();
        public List<Attack> Attacks { get; set; } = new List<Attack>();
        #endregion
    }
}
