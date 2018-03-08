using CreatureScaler.Models;

namespace CreatureScaler.Platform
{
    internal interface ICreatureScaler
    {
        Creature ScaleCreature(Creature baseCreature, int targetCR);
    }
}