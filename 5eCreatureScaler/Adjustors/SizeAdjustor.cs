using CreatureScaler.Models;
using CreatureScaler.Platform;

namespace CreatureScaler.Adjustors
{
    public class SizeAdjustor : ICreatureAdjustor
    {
        public uint EstimatedAdjustmentDistance => 2;

        public void AdjustDown(Creature creature)
        {
            creature.Size -= 1;
        }

        public void AdjustUp(Creature creature)
        {
            creature.Size += 1;
        }

        public bool Qualified(Creature creature)
        {
            return true;
        }
    }
}
