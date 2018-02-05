using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatureScaler.Models
{
    public sealed class ChallengeRating
    {
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
            get;
            set;
        }
    }
}
