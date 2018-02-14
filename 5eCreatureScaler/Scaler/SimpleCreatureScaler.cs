using CreatureScaler.Models;

namespace CreatureScaler.Scaler
{
    public sealed class SimpleCreatureScaler : ICreatureScaler
    {
        public Creature ScaleCreature(Creature creature, ChallengeRating desiredRating)
        {
            return creature;
        }

        public Creature ScaleCreature(Creature creature, ChallengeRating desiredRating, CreatureScalingOptions scalingOptions)
        {
            return creature;
        }
    }
}