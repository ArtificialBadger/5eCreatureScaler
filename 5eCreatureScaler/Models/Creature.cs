﻿using System;
using System.Collections.Generic;

namespace CreatureScaler.Models
{
    public sealed class Creature
    {
        public static Creature Create(String name, Size size, ChallengeRating challengeRating, int armorClass, List<AbilityScore> abilityScores, int hitDieCount)
        {
            return new Creature()
            {
                Name = name,
                ProficiencyBonus = challengeRating.ToProficiencyBonus(),
                ArmorClass = armorClass,
                Size = size,
                
                ChallengeRating = challengeRating,
                Statistics = abilityScores,

                Health = Health.Create(size, hitDieCount, abilityScores),
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
        public Health Health { get; set; }
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
        #endregion

        #region actions
        public List<List<string>> MultiAction { get; set; } = new List<List<string>>();
        public List<Attack> Attacks { get; set; } = new List<Attack>();
        public List<Action> Actions { get; set; } = new List<Action>();
        public List<Action> BonusActions { get; set; } = new List<Action>();
        public List<Reaction> Reactions { get; set; } = new List<Reaction>();
        #endregion
    }
}