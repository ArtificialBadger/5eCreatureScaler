using CreatureScaler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatureScaler.Scaler
{
    public interface ICreatureScaler
    {
        Creature ScaleCreature(Creature creature, ChallengeRating desiredRating);

        Creature ScaleCreature(Creature creature, ChallengeRating desiredRating, CreatureScalingOptions scalingOptions);
    }
}
