using CreatureScaler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatureScaler.Platform
{
    public interface IAdjustorSelector
    {
        IEnumerable<ICreatureAdjustor> SelectAdjustors(Creature creature, CreatureAdjustmentOptions creatureAdjustmentOptions);
    }
}
