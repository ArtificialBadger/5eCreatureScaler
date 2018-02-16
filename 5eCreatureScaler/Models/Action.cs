using System.Collections.Generic;

namespace CreatureScaler.Models
{
    public abstract class Action
    {
        public string Name { get; set; }

        public IDictionary<int, int> MultiGroups { get; set; }

        public abstract int CalculateDamagePerRound();
    }
}
