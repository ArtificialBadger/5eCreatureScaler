using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatureScaler.Models
{
    public sealed class Creature
    {
        public Size Size
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

        public ProficiencyModifier Proficiency
        {
            get;
            set;
        }

        public BasicStatistics Statistics
        {
            get;
            set;
        }

        //TODO: Advanced Statistics: Honor and Sanity, possible boolean method for easy isAdvanced() check?
    }
}
