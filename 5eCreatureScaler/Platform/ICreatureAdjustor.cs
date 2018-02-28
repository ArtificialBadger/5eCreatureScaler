using CreatureScaler.Models;

namespace CreatureScaler.Platform
{
    internal interface ICreatureAdjustor
    {
        AdjustorType Type { get; }
        int EstimatedAdjustmentDistance { get; }
        void Adjust(Creature creature);
    }
}