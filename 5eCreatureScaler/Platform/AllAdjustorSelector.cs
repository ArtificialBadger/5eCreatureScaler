using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreatureScaler.Models;

namespace CreatureScaler.Platform
{
    public class AllAdjustorSelector : IAdjustorSelector
    {
        private IEnumerable<ICreatureAdjustor> creatureAdjustors;

        public AllAdjustorSelector(IEnumerable<ICreatureAdjustor> creatureAdjustors)
        {
            this.creatureAdjustors = creatureAdjustors;
        }

        public IEnumerable<ICreatureAdjustor> SelectAdjustors(Creature creature, CreatureAdjustmentOptions creatureAdjustmentOptions)
        {
            return this.creatureAdjustors;
        }
    }
}
