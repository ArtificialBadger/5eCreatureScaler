using CreatureScaler.Models;

namespace CreatureScaler.Platform
{
    public interface ICreatureAdjustor
    {
        AdjustmentAttribute AdjustmentAttribute { get; }

        int EstimatedAdjustmentDistance { get; }

        void Adjust(Creature creature);

        bool Qualified(Creature creature);
    }
}