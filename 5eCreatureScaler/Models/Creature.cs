using System;
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
                ProficiencyBonus = CalculateProficiencyBonus(challengeRating),
                ArmorClass = armorClass,
                Size = size,
                HitDieSize = SizeToDieMap[size],
                ChallengeRating = challengeRating,
                Statistics = abilityScores,
                HitDie = hitDieCount,
                HitPointMaximum = CalculateHitPoints(size, abilityScores, hitDieCount),
            };
        }

        private static int CalculateProficiencyBonus(ChallengeRating challengeRating)
        {
            return ((challengeRating.ListedChallengeRating - 1) / 4) + 2;
        }

        private static int CalculateHitPoints(Size size, List<AbilityScore> statistics, int hitDieCount)
        {
            return (int)(
                Math.Floor(hitDieCount * DieToHitPointPerLevelMap[SizeToDieMap[size]])
                + 
                hitDieCount * statistics.ByAbility(AbilityType.Constitution)?.Modifier ?? 0
                );
        }

        private static Dictionary<Size, Die> SizeToDieMap = new Dictionary<Size, Die>
        {
            { Size.Tiny, Die.D4 },
            { Size.Small, Die.D6 },
            { Size.Medium, Die.D8 },
            { Size.Large, Die.D10 },
            { Size.Huge, Die.D12 },
            { Size.Gargantuan, Die.D20 },
        };

        private static Dictionary<Die, double> DieToHitPointPerLevelMap = new Dictionary<Die, double>
        {
            { Die.D4, 2.5 },
            { Die.D6, 3.5 },
            { Die.D8, 4.5 },
            { Die.D10, 5.5 },
            { Die.D12, 6.5 },
            { Die.D20, 10.5 },
        };

        public String Name
        {
            get;
            set;
        }

        public Size Size
        {
            get;
            set;
        }

        public Die HitDieSize
        {
            get;
            set;
        }

        public int HitDie
        {
            get;
            set;
        }

        public int HitPointMaximum
        {
            get;
            set;
        }

        public ChallengeRating ChallengeRating
        {
            get;
            set;
        }

        public int ArmorClass
        {
            get;
            set;
        }

        public int ProficiencyBonus
        {
            get;
            set;
        }

        public List<AbilityScore> Statistics
        {
            get;
            set;
        }

        public IList<Feature> Features
        {
            get;
            set;
        } = new List<Feature>();

        public IList<Models.Action> Actions
        {
            get;
            set;
        } = new List<Models.Action>();

        public int AttacksPerRound
        {
            get;
            set;
        }

        public IList<Attack> Attacks
        {
            get;
            set;
        } = new List<Attack>();

        public IList<string> Languages { get; set; } = new List<string>();
    }
}
