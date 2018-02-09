using System;
using System.Collections.Generic;

namespace CreatureScaler.Models
{
    public sealed class ChallengeRating
    {
        private static IDictionary<int, int> ChallengeRatingToExperienceMap = new Dictionary<int, int>()
        {
            {0, 10},
            {1, 200},
            {2, 450},
            {3, 700},
            {4, 1100},
            {5, 1800},
            {6, 2300},
            {7, 2900},
            {8, 3900},
            {9, 5000},
            {10, 5900},
            {11, 7200},
            {12, 8400},
            {13, 10000},
            {14, 11500},
            {15, 13000},
            {16, 15000},
            {17, 18000},
            {18, 20000},
            {19, 22000},
            {20, 25000},
            {21, 33000},
            {22, 41000},
            {23, 50000},
            {24, 62000},
            {25, 75000},
            {26, 90000},
            {27, 105000},
            {28, 120000},
            {29, 135000},
            {30, 155000},
        };

        public static ChallengeRating Create(int offensiveChallengeRating, int defensiveChallengeRating)
        {
            return new ChallengeRating() { OffensiveChallengeRating = offensiveChallengeRating, DefensiveChallengeRating = defensiveChallengeRating };
        }

        public static ChallengeRating Create(int challengeRating)
        {
            return new ChallengeRating() { OffensiveChallengeRating = challengeRating, DefensiveChallengeRating = challengeRating };
        }

        public int OffensiveChallengeRating
        {
            get;
            set;
        }

        public int DefensiveChallengeRating
        {
            get;
            set;
        }

        public int ListedChallengeRating
        {
            get
            {
                return (int)Math.Ceiling((this.OffensiveChallengeRating + this.DefensiveChallengeRating) / 2f);
            }
        }

        public int ExperiencePoints
        {
            get
            {
                return ChallengeRatingToExperienceMap[this.ListedChallengeRating];
            }
        }

        public int ToProficiencyBonus()
        {
            return CalculateProficiencyBonus(this);
        }

        public static int CalculateProficiencyBonus(ChallengeRating challengeRating)
        {
            return ((challengeRating.ListedChallengeRating - 1) / 4) + 2;
        }
    }
}
