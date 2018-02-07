using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
