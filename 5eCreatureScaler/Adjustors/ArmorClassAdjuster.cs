using CreatureScaler.Models;
using CreatureScaler.Platform;

namespace CreatureScaler.Adjustors
{
    public class ArmorClassAdjuster : ICreatureAdjustor
    {
        public uint EstimatedAdjustmentDistance => 1;

        public void AdjustDown(Creature creature)
        {
            creature.ArmorClass.Value -= 2;
        }

        public void AdjustUp(Creature creature)
        {
            creature.ArmorClass.Value += 2;
        }

        public bool Qualified(Creature creature)
        {
            return true;
        }
    }
}
