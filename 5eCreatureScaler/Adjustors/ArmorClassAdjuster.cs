using CreatureScaler.Models;
using CreatureScaler.Platform;

namespace CreatureScaler.Adjustors
{
    public class ArmorClassAdjustor : ICreatureAdjustor
    {
        public AdjustmentAttribute AdjustmentAttribute => AdjustmentAttribute.Defensive;

        public int EstimatedAdjustmentDistance => 1;

        public void Adjust(Creature creature)
        {
            creature.ArmorClass.Value += 2;
        }

        public bool Qualified(Creature creature)
        {
            return true;
        }
    }
}
