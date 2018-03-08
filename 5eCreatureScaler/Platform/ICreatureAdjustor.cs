using CreatureScaler.Models;

namespace CreatureScaler.Platform
{
    internal interface ICreatureAdjustor
    {
        uint EstimatedAdjustmentDistance { get; }
        void AdjustUp(Creature creature);
        void AdjustDown(Creature creature);
        bool Qualified(Creature creature);
    }
}