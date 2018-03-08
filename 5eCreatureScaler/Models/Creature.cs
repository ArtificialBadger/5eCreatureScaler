using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace CreatureScaler.Models
{
    [Serializable]
    public sealed class Creature
    {
        public static Creature Create(String name, Size size, ChallengeRating challengeRating, List<AbilityScore> abilityScores, int hitDieCount)
        {
            return new Creature()
            {
                Name = name,
                ProficiencyBonus = challengeRating.ToProficiencyBonus(),
                ArmorClass = new ArmorClass(10),
                Size = size,

                ChallengeRating = challengeRating,
                Statistics = abilityScores,

                HitDieCount = hitDieCount,
            };
        }

        [IgnoreDataMember]
        public int Health
        {
            get
            {
                return (int)(
                    Math.Floor(HitDieCount * Size.ToHitDie().ToAverageValue())
                    +
                    HitDieCount * Statistics.ByAbility(Ability.Constitution)?.Modifier ?? 0
                    );
            }
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
        public ArmorClass ArmorClass { get; set; }
        public int HitDieCount { get; set; }
        public List<Speed> Speeds { get; set; } = new List<Speed>();
        #endregion

        #region abilities
        public List<AbilityScore> Statistics { get; set; } = new List<AbilityScore>();
        #endregion

        #region statistics
        public List<Ability> SavingThrowProficiencies { get; set; } = new List<Ability>();
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
        public Spellcasting Spellcasting { get; set; }
        public InnateSpellcasting InnateSpellcasting { get; set; }
        #endregion

        #region actions
        public List<Attack> Attacks { get; set; } = new List<Attack>();
        public List<Action> Actions { get; set; } = new List<Action>();
        public List<Reaction> Reactions { get; set; } = new List<Reaction>();
        #endregion

        public int MaxDpr
        {
            get
            {
                return this.Actions.Select(a => a.CalculateDamagePerRound()).Max();
            }
        }

        public int MaxAttack
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public List<string> Tags
        {
            get;
            set; 
        } = new List<string>();

        [IgnoreDataMember]
        public IReadOnlyList<string> AutomaticTags
        {
            get
            {
                return
                    SubTypes
                        .Select(subType => subType.ToString())
                    .Concat(
                        Speeds.Select(speed => speed.Mode.ToString()))
                    .Concat(
                        new[]
                        {
                            Size.ToString(),
                            Type.ToString(),
                            Alignment.ToString(),
                        })
                    .ToList();
            }
        }
    }
}