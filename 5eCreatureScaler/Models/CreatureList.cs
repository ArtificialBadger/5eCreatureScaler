using System;
using System.Collections.Generic;
using System.Linq;

namespace CreatureScaler.Models
{
    public sealed class CreatureList
    {
        public IEnumerable<Creature> Creatures
        {
            get;
            set;
        }
    }
}