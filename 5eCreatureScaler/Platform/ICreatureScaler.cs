using CreatureScaler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatureScaler.Platform
{
    public interface ICreatureScaler
    {
        Creature ScaleCreature(Creature baseCreature, int targetCR);
    }
}
