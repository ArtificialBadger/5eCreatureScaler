using System;
using CreatureScaler.Models;

namespace CreatureScaler.Platform
{

    public interface ICreatureResolver
    {
        Creature ResolveCreature(Guid creatureId);

        Creature ResolveCreature(string creatureName);         
    }

}