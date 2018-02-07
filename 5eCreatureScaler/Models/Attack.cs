using System.Collections.Generic;

namespace CreatureScaler.Models
{
    public class Attack
    {
        public string Name { get; set; }

        public List<DamageRoll> DamageRolls { get; set; }

        public AbilityType AttackRollAbility { get; set; }

        public int Reach { get; set; }
    }
}