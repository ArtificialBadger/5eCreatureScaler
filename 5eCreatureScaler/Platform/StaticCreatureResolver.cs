using System;
using System.Collections.Generic;
using CreatureScaler.Models;

namespace CreatureScaler.Platform
{
    public class StaticCreatureResolver : ICreatureResolver
    {
        private static readonly IDictionary<string, Guid> CreatureNameDicationary = new Dictionary<string, Guid>()
        {
            {"brownbear", Guid.Parse("d7ddf099-6587-440c-96dc-290c111c829c")},
        };

        private static readonly IDictionary<Guid, Creature> CreatureIdDictionary = new Dictionary<Guid, Creature>()
        {
            {Guid.Parse("d7ddf099-6587-440c-96dc-290c111c829c"), StaticCreatureList.BrownBear},
        };

        public Creature ResolveCreature(Guid creatureId)
        {
            return CreatureIdDictionary[creatureId];
        }

        public Creature ResolveCreature(string creatureName)
        {
            var creatureId = CreatureNameDicationary[creatureName.ToLowerInvariant()];
            return this.ResolveCreature(creatureId);
        }         
    }

}