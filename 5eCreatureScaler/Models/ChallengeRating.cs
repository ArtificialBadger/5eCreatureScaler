using System;

namespace CreatureScaler.Models
{
    public sealed class ChallengeRating
    {
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
