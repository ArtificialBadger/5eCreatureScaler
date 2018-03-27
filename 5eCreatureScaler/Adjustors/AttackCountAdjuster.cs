using CreatureScaler.Models;
using CreatureScaler.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatureScaler.Adjustors
{
    public class AttackCountAdjustor : ICreatureAdjustor
    {
        public uint EstimatedAdjustmentDistance => throw new NotImplementedException();

        public void AdjustDown(Creature creature)
        {
            throw new NotImplementedException();
        }

        public void AdjustUp(Creature creature)
        {
            throw new NotImplementedException();
        }

        public bool Qualified(Creature creature)
        {
            return creature.Actions.Any();
        }
    }
}
